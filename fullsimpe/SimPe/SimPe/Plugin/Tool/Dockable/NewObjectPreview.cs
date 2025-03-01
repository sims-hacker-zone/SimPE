// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SimPe.Plugin.Tool.Dockable
{
	public partial class SimpleObjectPreview : UserControl
	{
		public SimpleObjectPreview()
		{
			SetStyle(
				ControlStyles.SupportsTransparentBackColor
					| ControlStyles.AllPaintingInWmPaint
					|
					//ControlStyles.Opaque |
					ControlStyles.UserPaint
					| ControlStyles.ResizeRedraw
					| ControlStyles.DoubleBuffer,
				true
			);

			BackColor = Color.Transparent;
			LoadCustomImage = true;

			InitializeComponent();

			BuildDefaultImage();
			ClearScreen();
		}

		#region Public Properties
		protected PackedFiles.Wrapper.ExtObjd objd;

		[Browsable(false)]
		public PackedFiles.Wrapper.ExtObjd SelectedObject
		{
			get => objd;
			set
			{
				if (objd != value || value == null)
				{
					objd = value;
					UpdateScreen();
				}
			}
		}

		public bool LoadCustomImage
		{
			get; set;
		}

		[Browsable(false)]
		public virtual bool Loaded => objd != null;

		[Browsable(false)]
		public string Title => lbName.Text;

		[Browsable(false)]
		public string Description => lbAbout.Text;

		[Browsable(false)]
		public short Price => Helper.StringToInt16(lbPrice.Text.Replace(" $", ""), 0, 10);
		#endregion

		#region Thumbnails
		/// <summary>
		/// Returns the Instance Number for the assigned Thumbnail
		/// </summary>
		/// <param name="group">The Group of the Object</param>
		/// <param name="modelname">The Name of teh Model (inst 0x86)</param>
		/// <returns>Instance of the Thumbnail</returns>
		public static uint ThumbnailHash(uint group, string modelname)
		{
			string name = group.ToString() + modelname;
			return (uint)
				Hashes.ToLong(
					Hashes.Crc32.ComputeHash(Helper.ToBytes(name.Trim().ToLower()))
				);
		}

		static Packages.File thumbs = null;

		/// <summary>
		/// Returns the Thumbnail of an Object
		/// </summary>
		/// <param name="group"></param>
		/// <param name="modelname"></param>
		/// <returns>The Thumbnail</returns>
		public static Image GetThumbnail(uint group, string modelname)
		{
			return GetThumbnail(group, modelname, null);
		}

		/// <summary>
		/// Returns the Thumbnail of an Object
		/// </summary>
		/// <param name="group"></param>
		/// <param name="modelname"></param>
		/// <returns>The Thumbnail</returns>
		public static Image GetThumbnail(uint group, string modelname, string message)
		{
			if (thumbs == null)
			{
				thumbs = Packages.File.LoadFromFile(
					System.IO.Path.Combine(
						PathProvider.SimSavegameFolder,
						"Thumbnails\\ObjectThumbnails.package"
					)
				);
				thumbs.Persistent = true;
			}

			Image img = GetThumbnail(group, modelname, message, thumbs);
			return img;
		}

		/// <summary>
		/// Returns the Thumbnail of an Object
		/// </summary>
		/// <param name="group"></param>
		/// <param name="modelname"></param>
		/// <returns>The Thumbnail</returns>
		public static Image GetThumbnail(
			uint group,
			string modelname,
			string message,
			Packages.File thumbs
		)
		{
			uint inst = ThumbnailHash(group, modelname);
			Image img = GetThumbnail(
				message,
				new uint[] { 0xAC2950C1 },
				group,
				inst,
				thumbs
			);

			//if (img==null) img = GetThumbnail(message, new uint[] { 0xAC2950C1}, Hashes.GetCrc32(Hashes.StripHashFromName(modelname.Trim().ToLower())), thumbs);

			return img;
		}

		/// <summary>
		/// Returns the Thumbnail of an Object
		/// </summary>
		/// <param name="group"></param>
		/// <param name="modelname"></param>
		/// <returns>The Thumbnail</returns>
		public static Image GetThumbnail(
			string message,
			uint type,
			uint group,
			uint inst,
			Packages.File thumbs
		)
		{
			return GetThumbnail(message, new uint[] { type }, group, inst, thumbs);
		}

		/// <summary>
		/// Returns the Thumbnail of an Object
		/// </summary>
		/// <param name="group"></param>
		/// <param name="modelname"></param>
		/// <returns>The Thumbnail</returns>
		public static Image GetThumbnail(
			string message,
			uint[] types,
			uint group,
			uint inst,
			Packages.File thumbs
		)
		{
			/*ArrayList types = new ArrayList();
			types.Add(0xAC2950C1); // Objects
			types.Add(0xEC3126C4); // Terrain
			types.Add(0xCC48C51F); //chimney
			types.Add(0x2C30E040); //fence Arch
			types.Add(0xCC30CDF8); //fences
			types.Add(0x8C311262); //floors
			types.Add(0x2C43CBD4); //foundtaion / pools
			types.Add(0xCC44B5EC); //modular Stairs
			types.Add(0xCC489E46); //roof
			types.Add(0x8C31125E); //wall*/

			foreach (uint type in types)
			{
				//0x6C2A22C3
				Interfaces.Files.IPackedFileDescriptor[] pfds = thumbs.FindFile(
					type,
					group,
					inst
				);
				if (pfds.Length == 0)
				{
					pfds = thumbs.FindFile(type, 0, inst);
				}

				if (pfds.Length > 0)
				{
					Interfaces.Files.IPackedFileDescriptor pfd = pfds[0];
					try
					{
						PackedFiles.Wrapper.Picture pic =
							new PackedFiles.Wrapper.Picture();
						pic.ProcessData(pfd, thumbs);
						Bitmap bm = (Bitmap)
							ImageLoader.Preview(pic.Image, WaitingScreen.ImageSize);
						if (WaitingScreen.Running)
						{
							WaitingScreen.Update(bm, message);
						}

						return pic.Image;
					}
					catch (Exception) { }
				}
			}
			return null;
		}
		#endregion

		protected void SetupCategories(string[][] catss)
		{
			cbCat.Items.Clear();
			foreach (string[] cats in catss)
			{
				string res = "";
				foreach (string cat in cats)
				{
					if (res != "")
					{
						res += " / ";
					}
					else
					{
						lbCat.Text = cat;
					}

					res += cat.Trim();
				}
				if (res != "")
				{
					cbCat.Items.Add(res);
				}
			}
			cbCat.SelectedIndex = cbCat.Items.Count - 1;
			if (cbCat.Items.Count == 1)
			{
				cbCat.Visible = false;
				lbCat.Visible = true;
			}
			else
			{
				cbCat.Visible = true;
				lbCat.Visible = false;
			}
		}

		public static Image GenerateImage(Size sz, Image img, bool knockout)
		{
			if (img == null)
			{
				return null;
			}

			if (knockout)
			{
				img = Ambertation.Drawing.GraphicRoutines.KnockoutImage(
					img,
					new Point(0, 0),
					Color.Magenta
				);
				return Ambertation.Windows.Forms.Graph.ImagePanel.CreateThumbnail(
					img,
					sz,
					8,
					Color.FromArgb(90, Color.Black),
					Color.FromArgb(10, 10, 40),
					Color.White,
					Color.FromArgb(80, Color.White),
					true,
					3,
					3
				);
			}
			else
			{
				return Ambertation.Windows.Forms.Graph.ImagePanel.CreateThumbnail(
					img,
					sz,
					8,
					Color.FromArgb(90, Color.Black),
					ThemeManager.Global.ThemeColorDark,
					Color.White,
					Color.FromArgb(80, Color.White),
					true,
					3,
					3
				);
			}
		}

		public virtual void SetFromObjectCacheItem(Cache.ObjectCacheItem oci)
		{
			if (oci == null)
			{
				objd = null;
				ClearScreen();
				return;
			}

			objd = null;
			if (oci.Tag != null)
			{
				if (oci.Tag is Interfaces.Scenegraph.IScenegraphFileIndexItem)
				{
					objd = new PackedFiles.Wrapper.ExtObjd();
					objd.ProcessData(
						(Interfaces.Scenegraph.IScenegraphFileIndexItem)oci.Tag
					);
				}
			}

			UpdateScreen();
			pb.Image = oci.Thumbnail == null ? defimg : GenerateImage(pb.Size, oci.Thumbnail, true);

			lbName.Text = oci.Name;
			lbVert.Text = "---";
		}

		public virtual void SetFromPackage(Interfaces.Files.IPackageFile pkg)
		{
			if (pkg == null)
			{
				objd = null;
				ClearScreen();
				return;
			}

			Interfaces.Files.IPackedFileDescriptor[] pfds = pkg.FindFile(
				Data.MetaData.OBJD_FILE,
				0,
				0x41A7
			);
			if (pfds.Length > 0)
			{
				objd = new PackedFiles.Wrapper.ExtObjd();
				objd.ProcessData(pfds[0], pkg);
			}
			int fct = 0;
			int vct = 0;
			pfds = pkg.FindFiles(Data.MetaData.GMDC);
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				Rcol rcol = new GenericRcol();
				rcol.ProcessData(pfd, pkg, true);

				GeometryDataContainer gmdc =
					rcol.Blocks[0] as GeometryDataContainer;
				foreach (Gmdc.GmdcGroup g in gmdc.Groups)
				{
					fct += g.FaceCount;
					vct += g.UsedVertexCount;
				}

				rcol.Dispose();
			}
			UpdateScreen();
			lbVert.Text = fct > 0 ? vct.ToString() + " (" + fct.ToString() + " Faces)" : "---";
		}

		protected void ClearScreen()
		{
			pb.Image = defimg;
			lbAbout.Text = "";
			lbEPList.Text = "";
			lbName.Text = "";
			lbPrice.Text = "";
			lbVert.Text = "";
			lbCat.Text = "";
			cbCat.Items.Clear();
		}

		public void UpdateScreen()
		{
			ClearScreen();
			if (objd == null)
			{
				return;
			}

			string[] mn = GetModelnames();
			if (mn.Length > 0)
			{
				uint grp = objd.FileDescriptor.Group;
				pb.Image = GenerateImage(
					pb.Size,
					GetThumbnail(objd.FileDescriptor.Group, mn[0]),
					true
				);
			}
			else
			{
				pb.Image = null;
			}

			if (pb.Image == null)
			{
				pb.Image = defimg;
			}

			SetupCategories(
				Cache.ObjectCacheItem.GetCategory(
					Cache.ObjectCacheItemVersions.DockableOW,
					objd.FunctionSubSort,
					objd.Type,
					Cache.ObjectClass.Object
				)
			);

			PackedFiles.Wrapper.StrItemList strs = GetCtssItems();
			if (strs != null)
			{
				if (strs.Count > 0)
				{
					lbName.Text = strs[0].Title;
				}

				if (strs.Count > 1)
				{
					lbAbout.Text = strs[1].Title;
				}
			}
			else
			{
				lbName.Text = objd.FileName;
			}

			lbPrice.Text = "$" + objd.Price.ToString();

			Boolset bs = (ushort)objd.Data[0x40]; // EPFlags1
			lbEPList.Text = "";
			for (int i = 0; i < bs.Length; i++)
			{
				if (bs[i])
				{
					lbEPList.Text +=
						(lbEPList.Text.Length == 0 ? "" : "; ")
						+
							new Data.LocalizedNeighborhoodEP(
								(Data.NeighborhoodEP)i
							)
						;
				}
			}

			bs = (ushort)objd.Data[0x41]; // EPFlags2
			for (int i = 0; i < bs.Length; i++)
			{
				if (bs[i])
				{
					if (i > 2 && i < 15)
					{
						lbEPList.Text +=
							(lbEPList.Text.Length == 0 ? "" : "; ")
							+ Localization.Manager.GetString("unknown");
					}
					else
					{
						lbEPList.Text +=
							(lbEPList.Text.Length == 0 ? "" : "; ")
							+
								new Data.LocalizedNeighborhoodEP(
									(Data.NeighborhoodEP)i + 16
								)
							;
					}
				}
			}
		}

		protected string[] GetModelnames()
		{
			if (objd == null)
			{
				return new string[0];
			}

			if (objd.Package == null)
			{
				return new string[0];
			}

			Interfaces.Files.IPackedFileDescriptor pfd = objd.Package.FindFile(
				Data.MetaData.STRING_FILE,
				0,
				objd.FileDescriptor.Group,
				0x85
			);
			ArrayList list = new ArrayList();
			if (pfd != null)
			{
				PackedFiles.Wrapper.Str str = new PackedFiles.Wrapper.Str();
				str.ProcessData(pfd, objd.Package);
				PackedFiles.Wrapper.StrItemList items = str.LanguageItems(1);
				for (int i = 1; i < items.Length; i++)
				{
					list.Add(items[i].Title);
				}
			}
			string[] refname = new string[list.Count];
			list.CopyTo(refname);

			return refname;
		}

		protected virtual PackedFiles.Wrapper.StrItemList GetCtssItems(
			Interfaces.Files.IPackedFileDescriptor ctss,
			Interfaces.Files.IPackageFile pkg
		)
		{
			if (ctss != null)
			{
				PackedFiles.Wrapper.Str str = new PackedFiles.Wrapper.Str();
				str.ProcessData(ctss, pkg);

				return str.FallbackedLanguageItems(Helper.WindowsRegistry.LanguageCode);
			}

			return null;
		}

		protected virtual PackedFiles.Wrapper.StrItemList GetCtssItems()
		{
			if (objd == null)
			{
				return null;
			}

			if (objd.Package == null)
			{
				return null;
			}

			if (objd.FileDescriptor == null)
			{
				return null;
			}

			//Get the Name of the Object
			Interfaces.Files.IPackedFileDescriptor ctss = objd.Package.FindFile(
				Data.MetaData.CTSS_FILE,
				0,
				objd.FileDescriptor.Group,
				objd.CTSSInstance
			);

			return GetCtssItems(ctss, objd.Package);
		}

		protected Image defimg;

		protected void BuildDefaultImage()
		{
			defimg = GetImage.Demo;
		}
	}
}
