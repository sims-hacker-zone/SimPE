// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections;

using SimPe.Data;
using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	/// <summary>
	/// Used to find the Texture for a given Subset
	/// </summary>
	public class TextureLocator : System.IDisposable
	{
		Interfaces.Files.IPackageFile package;
		Interfaces.Scenegraph.IScenegraphFileIndex fii;

		public TextureLocator(Interfaces.Files.IPackageFile package)
		{
			this.package = package;
			fii = FileTableBase.FileIndex.AddNewChild();

			//fii.AddIndexFromPackage(package);
		}

		/// <summary>
		/// Find the GMND that is referencing the passed gmdc
		/// </summary>
		/// <param name="gmdc"></param>
		/// <param name="flname">null, or the Filename of a package to search in</param>
		/// <returns>null or the found gmnd</returns>
		public Rcol FindReferencingGMND(Rcol gmdc, string flname)
		{
			if (gmdc == null)
			{
				return null;
			}

			Interfaces.Files.IPackageFile lpackage = package;
			if (flname != null)
			{
				lpackage = Packages.File.LoadFromFile(flname);
			}

			foreach (Interfaces.Files.IPackedFileDescriptor pfd in lpackage.FindFiles(
				FileTypes.GMND
			))
			{
				Rcol rcol = new GenericRcol(null, false).ProcessFile(pfd, lpackage);
				foreach (
					Interfaces.Files.IPackedFileDescriptor rpfd in rcol.ReferencedFiles
				)
				{
					if (
						(gmdc.FileDescriptor.Group == rpfd.Group)
						&& (gmdc.FileDescriptor.Instance == rpfd.Instance)
						&& (gmdc.FileDescriptor.SubType == rpfd.SubType)
						&& (gmdc.FileDescriptor.Type == rpfd.Type)
					)
					{
						return rcol;
					}
				}
			}

			return null;
		}

		/// <summary>
		/// Find the SHPE that is referencing the passed GMND
		/// </summary>
		/// <param name="gmnd"></param>
		/// <param name="flname">null, or the Filename of a package to search in</param>
		/// <returns>null or the first found shpe</returns>
		public Rcol FindReferencingSHPE(Rcol gmnd, string flname)
		{
			if (gmnd == null)
			{
				return null;
			}

			Interfaces.Files.IPackageFile lpackage = package;
			if (flname != null)
			{
				lpackage = Packages.File.LoadFromFile(flname);
			}

			foreach (Interfaces.Files.IPackedFileDescriptor pfd in lpackage.FindFiles(
				FileTypes.SHPE
			))
			{
				Rcol rcol = new GenericRcol(null, false).ProcessFile(pfd, lpackage);

				Shape shp = (Shape)rcol.Blocks[0];
				foreach (ShapeItem i in shp.Items)
				{
					if (
						Hashes.StripHashFromName(i.FileName).Trim().ToLower()
						== Hashes.StripHashFromName(gmnd.FileName).Trim().ToLower()
					)
					{
						return rcol;
					}
				}
			}

			return null;
		}

		/// <summary>
		/// Find the TXMTs that are referenced by the passed Shape
		/// </summary>
		/// <param name="shpe"></param>
		/// <param name="flname">null, or the Filename of a package to search in</param>
		/// <returns>null or the first found shpe</returns>
		public Hashtable FindReferencedTXMT(Rcol shpe, string flname)
		{
			Hashtable ht = new Hashtable();
			if (shpe == null)
			{
				return ht;
			}

			Interfaces.Files.IPackageFile lpackage = package;
			if (flname != null)
			{
				lpackage = Packages.File.LoadFromFile(flname);
			}

			Shape shp = (Shape)shpe.Blocks[0];
			foreach (ShapePart p in shp.Parts)
			{
				string txmtflname =
					Hashes.StripHashFromName(p.FileName).Trim().ToLower() + "_txmt";
				string subset = p.Subset.Trim().ToLower();

				foreach (Interfaces.Files.IPackedFileDescriptor pfd in lpackage.FindFile(
					txmtflname,
					FileTypes.TXMT
				))
				{
					Rcol rcol = new GenericRcol(null, false).ProcessFile(pfd, lpackage);

					if (
						Hashes.StripHashFromName(rcol.FileName).Trim().ToLower()
						== txmtflname
					)
					{
						if (!ht.Contains(subset))
						{
							ht.Add(subset, rcol);
						}
					}
				}
			}

			return ht;
		}

		/// <summary>
		/// Find the TXTRs that are referenced by the passed TXMTs
		/// </summary>
		/// <param name="txmts"></param>
		/// <param name="flname">null, or the Filename of a package to search in</param>
		/// <returns>null or the first found shpe</returns>
		public Hashtable FindReferencedTXTR(Hashtable txmts, string flname)
		{
			Hashtable ht = new Hashtable();
			if (txmts == null)
			{
				return ht;
			}

			Interfaces.Files.IPackageFile lpackage = package;
			if (flname != null)
			{
				lpackage = Packages.File.LoadFromFile(flname);
			}

			foreach (string subset in txmts.Keys)
			{
				Rcol rcol = (Rcol)txmts[subset];
				MaterialDefinition txmt = (MaterialDefinition)rcol.Blocks[0];
				string txtrname =
					Hashes.StripHashFromName(
						txmt.GetProperty("stdMatBaseTextureName").Value
					) + "_txtr";
				txtrname = txtrname.Trim().ToLower();

				foreach (Interfaces.Files.IPackedFileDescriptor pfd in lpackage.FindFile(
					txtrname,
					FileTypes.TXTR
				))
				{
					Rcol txtr = new GenericRcol(null, false).ProcessFile(pfd, lpackage);

					if (
						Hashes.StripHashFromName(txtr.FileName).Trim().ToLower()
						== txtrname
					)
					{
						if (!ht.Contains(subset))
						{
							ht.Add(subset, txtr);
						}
					}
				}
			}

			return ht;
		}

		/// <summary>
		/// Collec all Material
		/// </summary>
		/// <param name="gmdc">The GMDC File you want to find the Textures for</param>
		/// <returns>The Keys of the Hashtabel are the Subset names and the Values are the TXTR Files</returns>
		public Hashtable FindMaterials(Rcol gmdc)
		{
			Rcol gmnd = FindReferencingGMND(gmdc, null);
			Rcol shpe = FindReferencingSHPE(gmnd, null);
			Hashtable txmts = FindReferencedTXMT(shpe, null);
			return txmts;
		}

		/// <summary>
		/// Collec all Textures
		/// </summary>
		/// <param name="gmdc">The GMDC File you want to find the Textures for</param>
		/// <returns>The Keys of the Hashtabel are the Subset names and the Values are the TXTR Files</returns>
		public Hashtable FindTextures(Rcol gmdc)
		{
			Rcol gmnd = FindReferencingGMND(gmdc, null);
			Rcol shpe = FindReferencingSHPE(gmnd, null);
			Hashtable txmts = FindReferencedTXMT(shpe, null);
			Hashtable txtrs = FindReferencedTXTR(txmts, null);
			return txtrs;
		}

		public Hashtable GetMaterials(Hashtable txmts, Ambertation.Scenes.Scene scn)
		{
			Hashtable list = new Hashtable();

			foreach (string s in txmts.Keys)
			{
				Rcol rcol = (Rcol)txmts[s];
				MaterialDefinition md = (MaterialDefinition)rcol.Blocks[0];

				list[s] = md.ToSceneMaterial(
					scn,
					Hashes.StripHashFromName(rcol.FileName)
				);
			}
			return list;
		}

		/// <summary>
		/// Retusn a Hashtable that contains the largest Images of the passed Textures
		/// </summary>
		/// <param name="txtrs"></param>
		/// <returns>The Keys of the Hashtabel are the Subset names, the values contain ImageStreams</returns>
		public Hashtable GetLargestImages(Hashtable txtrs)
		{
			Hashtable list = new Hashtable();
			foreach (string s in txtrs.Keys)
			{
				Rcol rcol = (Rcol)txtrs[s];
				ImageData id = (ImageData)rcol.Blocks[0];

				id.GetReferencedLifos();
				System.Drawing.Image img = id.LargestTexture.Texture; //null;
				/*foreach (MipMapBlock mmp in id.MipMapBlocks)
				{
					foreach (MipMap mm in mmp.MipMaps)
					{
						if (mm.Texture!=null) img=mm.Texture;
					}
				}*/


				if (img != null)
				{
					//img.RotateFlip(System.Drawing.RotateFlipType.RotateNoneFlipX);
					System.IO.MemoryStream ms = new System.IO.MemoryStream();
					img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
					ms.Seek(0, System.IO.SeekOrigin.Begin);
					list.Add(s, ms);
				}
			}

			return list;
		}

		#region IDisposable Member

		public void Dispose()
		{
			FileTableBase.FileIndex.RemoveChild(fii);
			fii.Clear();
		}

		#endregion
	}
}
