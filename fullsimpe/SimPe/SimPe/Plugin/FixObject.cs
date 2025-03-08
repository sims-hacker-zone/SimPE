// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;

using SimPe.Data;
using SimPe.Extensions;
using SimPe.Interfaces.Files;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Cpf;
using SimPe.PackedFiles.Lifo;
using SimPe.PackedFiles.Nref;
using SimPe.PackedFiles.ThreeIdr;

namespace SimPe.Plugin
{
	/// <summary>
	/// Availalbe Fix Version
	/// </summary>
	public enum FixVersion : byte
	{
		UniversityReady = 0x00,
		UniversityReady2 = 0x01,
	}

	/// <summary>
	/// This class can Fix the Integrity of cloned Objects
	/// </summary>
	public class FixObject : FixGuid
	{
		static ArrayList types;
		FixVersion ver;
		public FixVersion FixVersion
		{
			get => ver;
			set => ver = value;
		}

		public bool RemoveNonDefaultTextReferences
		{
			get; set;
		}

		/// <summary>
		/// Creates a new Instance of this class
		/// </summary>
		/// <param name="package">The package you want to fix the Integrity in</param>
		/// <param name="ver">Fix Version that should be used</param>
		/// <param name="remndeftxt">Remove all Text Links that are not assigned to the Default Language</param>
		public FixObject(IPackageFile package, FixVersion ver, bool remndeftxt)
			: base(package)
		{
			this.ver = ver;
			RemoveNonDefaultTextReferences = remndeftxt;
			if (types == null)
			{
				types = new ArrayList
				{
					FileTypes.TXMT,
					FileTypes.TXTR,
					FileTypes.LIFO,
					FileTypes.GMND
				};
				//types.Add(Data.FileTypes.MMAT);
			}
		}

		/// <summary>
		/// Returns a unique name tht is still working
		/// </summary>
		/// <param name="name">The existing Name of the Object</param>
		/// <param name="unique">a unique strung that sould be added</param>
		/// <param name="subsetname">the name of the Subset</param>
		/// <param name="ext">true, if you want the _txmt Extension</param>
		/// <returns>the new Name</returns>
		public static string GetUniqueTxmtName(
			string name,
			string unique,
			string subsetname,
			bool ext
		)
		{
			name = name.Trim();
			name = RenameForm.ReplaceOldUnique(name, "", false);

			if (name.ToLower().EndsWith("_txmt"))
			{
				name = name.Substring(0, name.Length - 5);
			}

			string[] parts = name.Split("_".ToCharArray());
			if (parts.Length > 0)
			{
				//oild method used to assigne the additional Name to the subset Part, now we assign it to the ModelName-Part
				/*
				subsetname = subsetname.Trim().ToLower();
				name = "";
				bool foundsubset = false;
				bool addedunique = false;
				for (int i=0; i<parts.Length; i++)
				{
					if (i!=0) name += "_";
					name += parts[i];

					if (foundsubset && !addedunique)
					{
						name += unique;
						addedunique = true;
					}

					if (parts[i].ToLower()==subsetname) foundsubset=true;

				}
				if (!addedunique) name += unique;				*/

				name = "";
				bool first = true;
				foreach (string s in parts)
				{
					if (!first)
					{
						name += "_";
					}

					name += s;
					if (first)
					{
						first = false;
						name += "-" + unique;
					}
				}
			}
			else
			{
				name += unique;
			}

			if (ext)
			{
				name += "_txmt";
			}

			return name;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="map"></param>
		/// <param name="rcol"></param>
		/// <returns></returns>
		protected string FindReplacementName(Hashtable map, Rcol rcol)
		{
			string name = Hashes.StripHashFromName(rcol.FileName.Trim().ToLower());
			string newname = (string)map[name];
			string ext =
				rcol.FileDescriptor.Type.ToFileTypeInformation()
				.ShortName.Trim()
				.ToLower();

			if (newname == null)
			{
				newname = Hashes.StripHashFromName(name + "_" + ext);
				newname = (string)map[newname];
			}

			if (newname == null)
			{
				newname = name;
			}

			return newname;
		}

		/// <summary>
		/// Fix a Txtr Reference in the Properties of a TXMT File
		/// </summary>
		/// <param name="name"></param>
		/// <param name="matd"></param>
		void FixTxtrRef(
			string propname,
			MaterialDefinition matd,
			Hashtable map,
			Rcol rcol
		)
		{
			string reference = matd.GetProperty(propname).Value.Trim().ToLower();
			string newref = (string)map[Hashes.StripHashFromName(reference) + "_txtr"];

			if (newref != null)
			{
				newref =
					"##0x"
					+ Helper.HexString(MetaData.CUSTOM_GROUP)
					+ "!"
					+ Hashes.StripHashFromName(newref);
				matd.GetProperty(propname).Value = newref.Substring(
					0,
					newref.Length - 5
				);
			}

			for (int i = 0; i < matd.Listing.Count; i++)
			{
				newref = (string)
					map[
						Hashes.StripHashFromName(matd.Listing[i].Trim().ToLower())
							+ "_txtr"
					];
				if (newref != null)
				{
					matd.Listing[i] =
						"##0x"
						+ Helper.HexString(MetaData.CUSTOM_GROUP)
						+ "!"
						+ Hashes.StripHashFromName(
							newref.Substring(0, newref.Length - 5)
						);
				}
			}

			string name = Hashes.StripHashFromName(rcol.FileName);
			if (name.Length > 5)
			{
				name = name.Substring(0, name.Length - 5);
			}

			matd.FileDescription = name;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="map"></param>
		/// <param name="rcol"></param>
		public void FixResource(Hashtable map, Rcol rcol)
		{
			switch (rcol.FileDescriptor.Type)
			{
				case FileTypes.TXMT: //MATD
				{
					MaterialDefinition matd = (MaterialDefinition)rcol.Blocks[0];

					FixTxtrRef("stdMatBaseTextureName", matd, map, rcol);
					FixTxtrRef("stdMatNormalMapTextureName", matd, map, rcol);
					break;
				}

				case FileTypes.SHPE: //SHPE
				{
					Shape shp = (Shape)rcol.Blocks[0];
					foreach (ShapeItem item in shp.Items)
					{
						string newref = (string)
							map[
								Hashes.StripHashFromName(item.FileName.Trim().ToLower())
							];
						if (newref != null)
						{
							item.FileName =
								"##0x"
								+ Helper.HexString(MetaData.CUSTOM_GROUP)
								+ "!"
								+ newref;
						}
					}

					foreach (ShapePart part in shp.Parts)
					{
						string newref = (string)
							map[
								Hashes.StripHashFromName(part.FileName.Trim().ToLower())
									+ "_txmt"
							];
						if (newref != null)
						{
							part.FileName =
								"##0x"
								+ Helper.HexString(MetaData.CUSTOM_GROUP)
								+ "!"
								+ newref.Substring(0, newref.Length - 5);
						}
					}
					break;
				}

				case FileTypes.TXTR: //TXTR
				{
					ImageData id = (ImageData)rcol.Blocks[0];
					foreach (MipMapBlock mmb in id.MipMapBlocks)
					{
						foreach (MipMap mm in mmb.MipMaps)
						{
							//this is a Lifo Reference
							if (mm.Texture == null)
							{
								IPackedFileDescriptor[] pfd =
									package.FindFile(mm.LifoFile, FileTypes.LIFO);
								if (pfd.Length > 0)
								{
									mm.Texture = null;
									mm.Data = ((LevelInfo)new Lifo(null, false).ProcessFile(pfd[0], package).Blocks[0]).Data;

									pfd[0].MarkForDelete = true;
								}
								else
								{
									string newref = Hashes.StripHashFromName(
										(string)map[mm.LifoFile.Trim().ToLower()]
									);
									if (newref != null)
									{
										mm.LifoFile =
											"##0x"
											+ Helper.HexString(
												MetaData.CUSTOM_GROUP
											)
											+ "!"
											+ newref;
									}
								}
							}
						}
					}
					break;
				}

				case FileTypes.CRES: //CRES
				{
					ResourceNode rn = (ResourceNode)rcol.Blocks[0];
					string name = Hashes.StripHashFromName(rcol.FileName);

					if (ver == FixVersion.UniversityReady2)
					{
						rn.GraphNode.FileName = name;
					}
					else if (ver == FixVersion.UniversityReady)
					{
						rn.GraphNode.FileName = "##0x1c050000!" + name;
					}

					break;
				}

				case FileTypes.GMND: //GMND
				{
					GeometryNode gn = (GeometryNode)rcol.Blocks[0];
					string name = Hashes.StripHashFromName(rcol.FileName);

					if (ver == FixVersion.UniversityReady2)
					{
						gn.ObjectGraphNode.FileName = name;
					}
					else if (ver == FixVersion.UniversityReady)
					{
						gn.ObjectGraphNode.FileName = "##0x1c050000!" + name;
					}

					break;
				}

				case FileTypes.LDIR:
				case FileTypes.LAMB:
				case FileTypes.LPNT:
				case FileTypes.LSPT:
				{
					DirectionalLight dl = (DirectionalLight)rcol.Blocks[0];
					dl.LightT.NameResource.FileName = dl.NameResource.FileName;

					break;
				}
			}
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="map"></param>
		public void FixNames(Hashtable map)
		{
			foreach (FileTypes type in MetaData.RcolList)
			{
				IPackedFileDescriptor[] pfds = package.FindFiles(type);
				foreach (IPackedFileDescriptor pfd in pfds)
				{
					Rcol rcol = new GenericRcol(null, false).ProcessFile(pfd, package);

					string name = Hashes.StripHashFromName(
						FindReplacementName(map, rcol)
					);
					//if (rcol.FileDescriptor.Type==Data.MetaData.TXMT || rcol.FileDescriptor.Type==Data.FileTypes.TXTR) name = "##0x"+Helper.HexString(Data.MetaData.CUSTOM_GROUP)+"!"+name;
					rcol.FileName = name;

					FixResource(map, rcol);
					rcol.SynchronizeUserData();
				}
			}
		}

		/// <summary>
		/// Remove some unreferenced and useless Files
		/// </summary>
		public void CleanUp()
		{
			if (WaitingScreen.Running)
			{
				WaitingScreen.UpdateMessage("Cleaning up");
			}

			IPackedFileDescriptor[] mpfds = package.FindFiles(
				FileTypes.MMAT
			); //MMAT
			ArrayList mmats = new ArrayList();
			foreach (IPackedFileDescriptor pfd in mpfds)
			{
				Cpf mmat =
					new Cpf().ProcessFile(pfd, package);

				string content = Scenegraph.MmatContent(mmat);

				if (!mmats.Contains(content))
				{
					string txmtname =

							Hashes.StripHashFromName(
								mmat.GetSaveItem("name").StringValue.Trim().ToLower()
							) + "_txmt";
					string cresname =
						Hashes.StripHashFromName(
							mmat.GetSaveItem("modelName").StringValue.Trim().ToLower()
						);

					if (
						package
							.FindFile(Hashes.StripHashFromName(txmtname), FileTypes.TXMT)
							.Length < 0
					)
					{
						pfd.MarkForDelete = true;
					}

					if (
						package
							.FindFile(Hashes.StripHashFromName(cresname), FileTypes.CRES)
							.Length < 0
					)
					{
						pfd.MarkForDelete = true;
					}

					if (!pfd.MarkForDelete)
					{
						mmats.Add(content);
					}
				}
				else
				{
					pfd.MarkForDelete = true;
				}
			}
		}

		/// <summary>
		/// Fixes the Global Group
		/// </summary>
		public void FixGroup()
		{
			FileTypes[] RCOLs =
			{
				FileTypes.ANIM,
				FileTypes.CINE,
				FileTypes.CRES,
				FileTypes.GMDC,
				FileTypes.GMND,
				FileTypes.LDIR,
				FileTypes.LAMB,
				FileTypes.LPNT,
				FileTypes.LSPT,
				FileTypes.LIFO,
				FileTypes.SHPE,
				FileTypes.TXMT,
				FileTypes.TXTR,
			};

			if (WaitingScreen.Running)
			{
				WaitingScreen.UpdateMessage("Fixing Groups");
			}

			foreach (IPackedFileDescriptor pfd in package.Index)
			{
				bool RCOLcheck = types.Contains(pfd.Type);
				if (ver == FixVersion.UniversityReady)
				{
					RCOLcheck = MetaData.RcolList.Contains(pfd.Type);
				}
				//foreach (uint tp in RCOLs) if (tp==pfd.Type) { RCOLcheck=true; break; }

				if (MetaData.RcolList.Contains(pfd.Type))
				{
					GenericRcol rcol = new GenericRcol(null, false).ProcessFile(pfd, package);

					foreach (
						IPackedFileDescriptor p in rcol.ReferencedFiles
					)
					{
						p.Group = ver == FixVersion.UniversityReady2
							? types.Contains(p.Type) ? MetaData.CUSTOM_GROUP : MetaData.LOCAL_GROUP
							: MetaData.RcolList.Contains(p.Type)
								? p.Type != FileTypes.ANIM ? MetaData.CUSTOM_GROUP : MetaData.GLOBAL_GROUP
								: MetaData.LOCAL_GROUP;
					}
					rcol.SynchronizeUserData();
				}

				pfd.Group = RCOLcheck
					? pfd.Type != FileTypes.ANIM ? MetaData.CUSTOM_GROUP : MetaData.GLOBAL_GROUP
					: MetaData.LOCAL_GROUP;
			}

			//is this a Fence package? If so, do special FenceFixes
			if (
				package.FindFiles(FileTypes.XFNC).Length > 0 /*|| package.FindFiles(Data.FileTypes.XNGB).Length>0*/
			)
			{
				FixFence();
			}
		}

		/// <summary>
		/// Builds a Name map
		/// </summary>
		/// <param name="uniquename">true, if you want to create a unique name</param>
		/// <returns></returns>
		public Hashtable GetNameMap(bool uniquename)
		{
			return RenameForm.Execute(package, uniquename, ref ver);
		}

		string BuildRefString(IPackedFileDescriptor pfd)
		{
			return Helper.HexString(pfd.Group)
				+ Helper.HexString(pfd.Type)
				+ Helper.HexString(pfd.Instance)
				+ Helper.HexString(pfd.SubType);
		}

		/// <summary>
		/// Runs the Fix Operation
		/// </summary>
		/// <param name="map">the map we have to use for name Replacements</param>
		/// <param name="uniquefamily">change the family values in the MMAT Files</param>
		public void Fix(Hashtable map, bool uniquefamily)
		{
			string grouphash =
				"##0x" + Helper.HexString(MetaData.CUSTOM_GROUP) + "!"; //"#0x"+Helper.HexString(package.FileGroupHash)+"!";

			Hashtable refmap = new Hashtable();
			Hashtable completerefmap = new Hashtable();

			if (WaitingScreen.Running)
			{
				WaitingScreen.UpdateMessage("Fixing Names");
			}

			FixNames(map);

			foreach (FileTypes type in MetaData.RcolList)
			{
				IPackedFileDescriptor[] pfds = package.FindFiles(type);

				//build a List of RefItems
				foreach (IPackedFileDescriptor pfd in pfds)
				{

					foreach (
						IPackedFileDescriptor rpfd in new GenericRcol(null, false).ProcessFile(pfd, package).ReferencedFiles
					)
					{
						string refstr = BuildRefString(rpfd);
						if (!refmap.Contains(refstr))
						{
							refmap.Add(refstr, null);
						}
					}
				}
			}

			//Updated TGI Values and update the refmap
			if (WaitingScreen.Running)
			{
				WaitingScreen.UpdateMessage("Updating TGI Values");
			}

			foreach (FileTypes type in MetaData.RcolList)
			{
				IPackedFileDescriptor[] pfds = package.FindFiles(type);

				foreach (IPackedFileDescriptor pfd in pfds)
				{
					string refstr = BuildRefString(pfd);
					Rcol rcol = new GenericRcol(null, false).ProcessFile(pfd, package);

					//rcol.FileName = grouphash + Hashes.StripHashFromName(rcol.);
					rcol.FileDescriptor.Instance = Hashes.InstanceHash(
						Hashes.StripHashFromName(rcol.FileName)
					);
					rcol.FileDescriptor.SubType = Hashes.SubTypeHash(
						Hashes.StripHashFromName(rcol.FileName)
					);

					if (refmap.Contains(refstr))
					{
						refmap[refstr] = rcol.FileDescriptor;
					}

					completerefmap[refstr] = rcol.FileDescriptor;
				}
			}

			//Update the References
			if (WaitingScreen.Running)
			{
				WaitingScreen.UpdateMessage("Updating TGI References");
			}

			foreach (FileTypes type in MetaData.RcolList)
			{
				IPackedFileDescriptor[] pfds = package.FindFiles(type);

				foreach (IPackedFileDescriptor pfd in pfds)
				{
					Rcol rcol = new GenericRcol(null, false).ProcessFile(pfd, package);

					foreach (
						IPackedFileDescriptor rpfd in rcol.ReferencedFiles
					)
					{
						string refstr =
							Helper.HexString(rpfd.Group)
							+ Helper.HexString(rpfd.Type)
							+ Helper.HexString(rpfd.Instance)
							+ Helper.HexString(rpfd.SubType);

						rpfd.Group = ver == FixVersion.UniversityReady2
							? types.Contains(rpfd.Type) ? MetaData.CUSTOM_GROUP : MetaData.LOCAL_GROUP
							: rpfd.Type != FileTypes.ANIM ? MetaData.CUSTOM_GROUP : MetaData.GLOBAL_GROUP;

						if (refmap.Contains(refstr))
						{
							IPackedFileDescriptor npfd =
								(IPackedFileDescriptor)refmap[refstr];
							if (npfd != null)
							{
								rpfd.Instance = npfd.Instance;
								rpfd.SubType = npfd.SubType;
							}
						}
					} //foreach

					rcol.SynchronizeUserData();
				}
			}

			//Make sure XObjects and Skins get Fixed Too
			FixXObject(map, completerefmap, grouphash);
			FixSkin(map, completerefmap, grouphash);

			//Make sure MMATs get fixed
			FixMMAT(map, uniquefamily, grouphash);

			//Make sure OBJd's get fixed too
			FixOBJd();

			//And finally the Root String
			if (WaitingScreen.Running)
			{
				WaitingScreen.UpdateMessage("Updating Root");
			}

			IPackedFileDescriptor[] mpfds = package.FindFiles(
				FileTypes.STR
			);
			string modelname = null;
			foreach (IPackedFileDescriptor pfd in mpfds)
			{
				PackedFiles.Wrapper.Str str = new PackedFiles.Wrapper.Str().ProcessFile(pfd, package);

				foreach (PackedFiles.Wrapper.StrToken i in str.Items)
				{
					string name = Hashes.StripHashFromName(i.Title.Trim().ToLower());

					if (name == "")
					{
						continue;
					}

					if (pfd.Instance == 0x88)
					{
						if (!name.EndsWith("_txmt"))
						{
							name += "_txmt";
						}
					}
					else if (pfd.Instance == 0x85)
					{
						if (!name.EndsWith("_cres"))
						{
							name += "_cres";
						}
					}
					else if (
						(pfd.Instance == 0x81)
						|| (pfd.Instance == 0x82)
						|| (pfd.Instance == 0x86)
						|| (pfd.Instance == 0x192)
					)
					{
						if (!name.EndsWith("_anim"))
						{
							name += "_anim";
						}
					}
					else
					{
						continue;
					}

					string newref = (string)map[name];
					i.Title = newref != null
						? Hashes.StripHashFromName(
							newref.Substring(0, newref.Length - 5)
						)
						: Hashes.StripHashFromName(i.Title);

					if (
						((ver == FixVersion.UniversityReady) || (pfd.Instance == 0x88))
						&& (newref != null)
					)
					{
						i.Title = Hashes.StripHashFromName(i.Title);

						if (
							!(
								(pfd.Instance == 0x81)
								|| (pfd.Instance == 0x82)
								|| (pfd.Instance == 0x86)
								|| (pfd.Instance == 0x192)
							)
						)
						{
							i.Title =
								"##0x"
								+ Helper.HexString(MetaData.CUSTOM_GROUP)
								+ "!"
								+ i.Title;
						}
					}
					else
					{
						FileTypes tp = FileTypes.ANIM;
						if (pfd.Instance == 0x88)
						{
							tp = FileTypes.TXMT;
						}
						else if (pfd.Instance == 0x85)
						{
							tp = FileTypes.CRES;
						}

						Interfaces.Scenegraph.IScenegraphFileIndexItem fii =
							FileTableBase.FileIndex.FindFileByName(
								i.Title,
								tp,
								MetaData.LOCAL_GROUP,
								true
							);
						if (fii != null)
						{
							if (fii.FileDescriptor.Group == MetaData.CUSTOM_GROUP)
							{
								i.Title =
									"##0x"
									+ Helper.HexString(MetaData.CUSTOM_GROUP)
									+ "!"
									+ Hashes.StripHashFromName(i.Title);
							}
						}
					}

					if (
						(modelname == null)
						&& (i.Language.Id == 1)
						&& (pfd.Instance == 0x85)
					)
					{
						modelname = name.ToUpper().Replace("-", "_");
					}
				}

				if (RemoveNonDefaultTextReferences)
				{
					if (
						pfd.Instance == 0x88
						|| pfd.Instance == 0x85
						|| (pfd.Instance == 0x81)
						|| (pfd.Instance == 0x82)
						|| (pfd.Instance == 0x86)
						|| (pfd.Instance == 0x192)
					)
					{
						str.ClearNonDefault();
					}
				}

				str.SynchronizeUserData();
			}

			//Now change the NREF

			if (modelname != null)
			{
				mpfds = package.FindFiles(FileTypes.NREF);
				foreach (IPackedFileDescriptor pfd in mpfds)
				{
					Nref nref =
						new Nref().ProcessFile(pfd, package);
					nref.FileName = ver == FixVersion.UniversityReady ? "SIMPE_" + modelname : "SIMPE_v2_" + modelname;

					nref.SynchronizeUserData();
				}
			}
		}

		/// <summary>
		/// Make sure the fixes for OBJd Resources are considered
		/// </summary>
		/// <remarks>
		/// Currently this implements the Fixes needed for Rugs
		/// </remarks>
		void FixOBJd()
		{
			if (WaitingScreen.Running)
			{
				WaitingScreen.UpdateMessage("Updating Object Descriuptions");
			}

			IPackedFileDescriptor[] pfds = package.FindFiles(
				FileTypes.OBJD
			); //OBJd

			bool updaterugs = false;
			foreach (IPackedFileDescriptor pfd in pfds)
			{
				PackedFiles.Wrapper.ExtObjd objd =
					new PackedFiles.Wrapper.ExtObjd().ProcessFile(pfd, package);

				//is one of the objd's a rug?
				if (
					objd.FunctionSubSort
					== ObjFunctionSubSort.Decorative_Rugs
				)
				{
					updaterugs = true;
					break;
				}
			}

			//found at least one OBJd describing a Rug
			if (updaterugs)
			{
				foreach (IPackedFileDescriptor pfd in pfds)
				{
					PackedFiles.Wrapper.ExtObjd objd =
						new PackedFiles.Wrapper.ExtObjd().ProcessFile(pfd, package);

					//make sure the Type of a Rug is not a Tile, but Normal
					if (objd.Type == ObjectTypes.Tiles)
					{
						objd.Type = ObjectTypes.Normal;
						objd.SynchronizeUserData(true, true);
					}
				}
			}
		}

		/// <summary>
		/// This takes care of the MMAT Resources
		/// </summary>
		/// <param name="map"></param>
		/// <param name="uniquefamily"></param>
		/// <param name="grouphash"></param>
		void FixMMAT(Hashtable map, bool uniquefamily, string grouphash)
		{
			if (WaitingScreen.Running)
			{
				WaitingScreen.UpdateMessage("Updating Material Overrides");
			}

			IPackedFileDescriptor[] mpfds = package.FindFiles(
				FileTypes.MMAT
			); //MMAT
			Hashtable familymap = new Hashtable();
			uint mininst = 0x5000;
			foreach (IPackedFileDescriptor pfd in mpfds)
			{
				MmatWrapper mmat = new MmatWrapper().ProcessFile(pfd, package);
				//make the MMAT Instance number unique
				pfd.Instance = mininst++;

				//get unique family value
				if (uniquefamily)
				{
					string family = mmat.GetSaveItem("family").StringValue;
					string nfamily = (string)familymap[family];

					if (nfamily == null)
					{
						nfamily = Guid.NewGuid().ToString();
						familymap[family] = nfamily;
					}

					mmat.Family = nfamily;
				}

				string newref = (string)
					map[
						Hashes.StripHashFromName(
							mmat.GetSaveItem("name").StringValue.Trim().ToLower()
						) + "_txmt"
					];
				if (newref != null)
				{
					newref = Hashes.StripHashFromName(newref);
					newref = newref.Substring(0, newref.Length - 5);
					mmat.Name = grouphash + newref;
				}
				else
				{
					mmat.Name =
						grouphash
						+ Hashes.StripHashFromName(
							mmat.GetSaveItem("name").StringValue
						);
				}

				newref = (string)
					map[Hashes.StripHashFromName(mmat.ModelName.Trim().ToLower())];
				if (newref != null)
				{
					newref = Hashes.StripHashFromName(newref);
					mmat.ModelName = newref;
				}
				else
				{
					mmat.ModelName = Hashes.StripHashFromName(mmat.ModelName);
				}

				if (ver == FixVersion.UniversityReady)
				{
					Interfaces.Scenegraph.IScenegraphFileIndexItem item =
						FileTableBase.FileIndex.FindFileByName(
							mmat.ModelName,
							FileTypes.CRES,
							MetaData.GLOBAL_GROUP,
							true
						);

					bool addfl = true;
					if (item != null)
					{
						if (item.FileDescriptor.Group == MetaData.GLOBAL_GROUP)
						{
							addfl = false;
						}
					}

					if (addfl)
					{
						mmat.ModelName =
							"##0x"
							+ Helper.HexString(MetaData.CUSTOM_GROUP)
							+ "!"
							+ mmat.ModelName;
					}
				}

				//mmat.FileDescriptor.Group = Data.MetaData.LOCAL_GROUP;
				mmat.SynchronizeUserData();
			}
		}

		#region Fix Skins
		void FixCpfProperties(
			Cpf cpf,
			string[] props,
			Hashtable namemap,
			string prefix,
			string sufix
		)
		{
			foreach (string p in props)
			{
				CpfItem item = cpf.GetItem(p);
				if (item == null)
				{
					continue;
				}

				string name = Hashes.StripHashFromName(
					item.StringValue.Trim().ToLower()
				);
				if (!name.EndsWith(sufix))
				{
					name += sufix;
				}

				string newname = (string)namemap[name];

				if (newname != null)
				{
					if (newname.EndsWith(sufix))
					{
						newname = newname.Substring(0, newname.Length - sufix.Length);
					}

					item.StringValue = prefix + newname;
				}
			}
		}

		void FixCpfProperties(
			Cpf cpf,
			string[] props,
			uint val
		)
		{
			foreach (string p in props)
			{
				CpfItem item = cpf.GetItem(p);
				if (item == null)
				{
					continue;
				}

				item.UIntegerValue = val;
			}
		}

		CpfItem FixCpfProperties(
			Cpf cpf,
			string prop,
			uint val
		)
		{
			CpfItem item = cpf.GetItem(prop);
			if (item == null)
			{
				return null;
			}

			item.UIntegerValue = val;
			return item;
		}

		void FixFence()
		{
			Hashtable shpnamemap = new Hashtable();
			GenericRcol rcol = new GenericRcol();
			FileTypes[] types = new FileTypes[] { FileTypes.SHPE, FileTypes.CRES };

			//now fix the texture References in those Resources
			foreach (FileTypes t in types)
			{
				IPackedFileDescriptor[] pfds = package.FindFiles(
					t
				);

				foreach (IPackedFileDescriptor pfd in pfds)
				{
					//fix the references to the SHPE Resources, to mirror the fact
					//that they are in the Global Group now
					if (t == FileTypes.CRES || t == FileTypes.GMND)
					{
						rcol.ProcessData(pfd, package);

						string shpname = null;

						if (t == FileTypes.CRES)
						{
							ResourceNode rn = (ResourceNode)
								rcol.Blocks[0];
							rn.GraphNode.FileName = Hashes.StripHashFromName(
								rn.GraphNode.FileName
							);

							//generate the name for the connected SHPE Resource
							foreach (
								Interfaces.Scenegraph.IRcolBlock irb in rcol.Blocks
							)
							{
								if (irb is ShapeRefNode srn)
								{
									shpname = rcol
										.FileName.Trim()
										.ToLower()
										.Replace("_cres", "")
										.Replace("_", "")
										.Trim();
									srn.StoredTransformNode.ObjectGraphNode.FileName =
										shpname;
									shpname =
										rcol.FileName.Replace("_cres", "").Trim()
										+ "_"
										+ shpname
										+ "_shpe";
								}
							}
						}
						else if (t == FileTypes.GMND)
						{
							GeometryNode gn = (GeometryNode)
								rcol.Blocks[0];
							gn.ObjectGraphNode.FileName = Hashes.StripHashFromName(
								gn.ObjectGraphNode.FileName
							);
						}

						foreach (
							IPackedFileDescriptor rpfd in rcol.ReferencedFiles
						)
						{
							//SHPE Resources get a new Name, so fix the Instance of the reference at this point
							if (rpfd.Type == FileTypes.SHPE)
							{
								shpnamemap[rpfd.LongInstance] = shpname;
								rpfd.Instance = Hashes.InstanceHash(shpname);
								rpfd.SubType = Hashes.SubTypeHash(shpname);
							}

							rpfd.Group = MetaData.GLOBAL_GROUP;
						}

						rcol.SynchronizeUserData();
					}

					pfd.Group = MetaData.GLOBAL_GROUP;
				}
			}

			//we need some special Adjustments for SHPE Resources, as their name has to match a certain pattern
			IPackedFileDescriptor[] spfds = package.FindFiles(
				FileTypes.SHPE
			);
			foreach (IPackedFileDescriptor pfd in spfds)
			{
				if (shpnamemap[pfd.LongInstance] == null)
				{
					continue;
				}

				rcol.ProcessData(pfd, package);
				rcol.FileName = (string)shpnamemap[pfd.LongInstance];
				rcol.FileDescriptor.Instance = Hashes.InstanceHash(rcol.FileName);
				rcol.FileDescriptor.SubType = Hashes.SubTypeHash(rcol.FileName);

				rcol.SynchronizeUserData();
			}
		}

		protected void FixSkin(Hashtable namemap, Hashtable refmap, string grphash)
		{
			Cpf cpf = new Cpf();
			Random rnd = new Random();

			//set list of critical types
			FileTypes[] types = new FileTypes[]
			{
				FileTypes.XOBJ,
				FileTypes.XFLR,
				FileTypes.XFNC,
				FileTypes.XROF,
				FileTypes.XNGB,
			};
			string[] txtr_props = new string[]
			{
				"textureedges",
				"texturetop",
				"texturetopbump",
				"texturetrim",
				"textureunder",
				"texturetname",
				"texturetname",
			};
			string[] txmt_props = new string[]
			{
				"material",
				"diagrail",
				"post",
				"rail",
			};
			string[] cres_props = new string[] { "diagrail", "post", "rail" };
			string[] cres_props_ngb = new string[] { "modelname" };
			string[] groups = new string[] { "stringsetgroupid", "resourcegroupid" };
			string[] set_to_guid = new string[] { }; //"thumbnailinstanceid"

			//now fix the texture References in those Resources
			foreach (FileTypes t in types)
			{
				IPackedFileDescriptor[] pfds = package.FindFiles(
					t
				);

				foreach (IPackedFileDescriptor pfd in pfds)
				{
					cpf.ProcessData(pfd, package);
					uint guid = (uint)rnd.Next();

					string pfx = grphash;
					if (t == FileTypes.XFNC)
					{
						pfx = "";
					}

					FixCpfProperties(cpf, txtr_props, namemap, pfx, "_txtr");
					FixCpfProperties(cpf, txmt_props, namemap, pfx, "_txmt");
					FixCpfProperties(cpf, cres_props, namemap, pfx, "_cres");
					if (pfd.Type == FileTypes.XNGB)
					{
						FixCpfProperties(cpf, cres_props_ngb, namemap, pfx, "_cres");
					}

					FixCpfProperties(cpf, groups, MetaData.LOCAL_GROUP);
					FixCpfProperties(cpf, set_to_guid, guid);
#if DEBUG
					FixCpfProperties(
						cpf,
						"guid",
						(guid & 0x00fffffe) | 0xfb000001
					);
#else

					FixCpfProperties(
						cpf,
						"guid",
						(uint)((guid & 0xfffffffe) | 0x00000001)
					);
#endif
					cpf.SynchronizeUserData();
				}
			}
		}
		#endregion

		#region Fix Xml Based Objects
		protected void FixXObject(Hashtable namemap, Hashtable refmap, string grphash)
		{
			//set list of critical types
			FileTypes[] types = new FileTypes[] { FileTypes.THREE_IDR };

			ThreeIdr fl = new ThreeIdr();

			//now fix the texture References in those Resources
			foreach (FileTypes t in types)
			{
				IPackedFileDescriptor[] pfds = package.FindFiles(
					t
				);
				foreach (IPackedFileDescriptor pfd in pfds)
				{
					fl.ProcessData(pfd, package);

					foreach (Packages.PackedFileDescriptor rfi in fl.Items)
					{
						string name = BuildRefString(rfi);
						IPackedFileDescriptor npfd =
							(IPackedFileDescriptor)refmap[name];
						if (npfd != null)
						{
							rfi.Group = npfd.Group;
							rfi.LongInstance = npfd.LongInstance;
						}
					}

					fl.SynchronizeUserData();
				}
			}
		}
		#endregion
	}
}
