// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.ComponentModel;
using System.Drawing;

using SimPe.PackedFiles.Cpf;

namespace SimPe.Plugin.Tool.Dockable
{
	/// <summary>
	/// Component to display Details about a passed Object
	/// </summary>
	public class ObjectPreview : SimpleObjectPreview
	{
		uint[] xtypes;

		public ObjectPreview()
			: base()
		{
			xtypes = new uint[]
			{
				Data.MetaData.XFLR,
				Data.MetaData.XFNC,
				Data.MetaData.XROF,
				Data.MetaData.XOBJ,
				Data.MetaData.XNGB,
			};
		}

		public override bool Loaded => base.Loaded || (cpf != null);

		Cpf cpf;

		[Browsable(false)]
		public Cpf SelectedXObject
		{
			get => cpf;
			set
			{
				if (cpf != value)
				{
					cpf = value;
					UpdateXObjScreen();
				}
			}
		}

		public override void SetFromObjectCacheItem(Cache.ObjectCacheItem oci)
		{
			if (oci == null)
			{
				objd = null;
				ClearScreen();
				return;
			}

			//Original Implementation
			if (oci.Class == Cache.ObjectClass.Object)
			{
				cpf = null;
				base.SetFromObjectCacheItem(oci);
				return;
			}

			objd = null;
			cpf = null;
			if (oci.Tag != null)
			{
				if (oci.Tag is Interfaces.Scenegraph.IScenegraphFileIndexItem)
				{
					cpf = new Cpf();
					cpf.ProcessData(
						(Interfaces.Scenegraph.IScenegraphFileIndexItem)oci.Tag
					);
				}
			}

			UpdateXObjScreen();
			if (pb.Image == null)
			{
				pb.Image = oci.Thumbnail == null ? defimg : GenerateImage(pb.Size, oci.Thumbnail, true);
			}
			lbName.Text = oci.Name;
		}

		public override void SetFromPackage(Interfaces.Files.IPackageFile pkg)
		{
			if (pkg == null)
			{
				cpf = null; // CJH
				objd = null;
				ClearScreen();
				return;
			}

			//this is a regular Object?
			if (pkg.FindFiles(Data.MetaData.OBJD_FILE).Length > 0)
			{
				cpf = null;
				base.SetFromPackage(pkg);
				return;
			}

			objd = null;
			cpf = null; // CJH

			foreach (uint t in xtypes)
			{
				Interfaces.Files.IPackedFileDescriptor[] pfds = pkg.FindFiles(t);
				if (pfds.Length > 0)
				{
					cpf = new Cpf();
					cpf.ProcessData(pfds[0], pkg);
					break;
				}
			}

			UpdateXObjScreen();
		}

		public void SetFromXObject(Cpf cpf)
		{
			this.cpf = cpf;
			UpdateXObjScreen();
		}

		protected void UpdateXObjScreen()
		{
			ClearScreen();
			if (cpf == null)
			{
				return;
			}

			lbEPs.Visible = lbEPList.Visible = false;

			SetupCategories(
				Cache.ObjectCacheItem.GetCategory(
					Cache.ObjectCacheItemVersions.DockableOW,
					(Data.ObjFunctionSubSort)GetFunctionSort(cpf),
					Data.ObjectTypes.Normal,
					Cache.ObjectClass.XObject
				)
			);

			pb.Image = null;
			pb.Image = GenerateImage(pb.Size, GetXThumbnail(cpf), true);

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
				lbName.Text = cpf.GetSaveItem("name").StringValue;
				lbAbout.Text = cpf.GetSaveItem("description").StringValue;
			}

			lbPrice.Text = cpf.GetSaveItem("cost").UIntegerValue.ToString() + " $";

			if (pb.Image == null)
			{
				pb.Image = defimg;
			}
		}

		protected override PackedFiles.Wrapper.StrItemList GetCtssItems()
		{
			if (cpf != null)
			{
				//Get the Name of the Object
				Interfaces.Files.IPackedFileDescriptor ctss = cpf.Package.FindFile(
					cpf.GetSaveItem("stringsetrestypeid").UIntegerValue,
					0,
					cpf.GetSaveItem("stringsetgroupid").UIntegerValue,
					cpf.GetSaveItem("stringsetid").UIntegerValue
				);

				return base.GetCtssItems(ctss, cpf.Package);
			}
			else
			{
				return base.GetCtssItems();
			}
		}

		public static Data.XObjFunctionSubSort GetFunctionSort(
			Cpf cpf
		)
		{
			string type = cpf.GetSaveItem("type").StringValue.Trim().ToLower();
			switch (type)
			{
				case "":
				case "canh":
				{
					switch (cpf.GetSaveItem("sort").StringValue.Trim().ToLower())
					{
						case "landmark":
							return Data.XObjFunctionSubSort.Hood_Landmark;
						case "flora":
							return Data.XObjFunctionSubSort.Hood_Flora;
						case "effects":
							return Data.XObjFunctionSubSort.Hood_Effects;
						case "misc":
							return Data.XObjFunctionSubSort.Hood_Misc;
						case "stone":
							return Data.XObjFunctionSubSort.Hood_Stone;
						default:
							return Data.XObjFunctionSubSort.Hood_Other;
					}
				}
				case "wall":
				{
					switch (cpf.GetSaveItem("subsort")
						.StringValue.Trim()
						.ToLower())
					{
						case "brick":
							return Data.XObjFunctionSubSort.Wall_Brick;
						case "masonry":
							return Data.XObjFunctionSubSort.Wall_Masonry;
						case "paint":
							return Data.XObjFunctionSubSort.Wall_Paint;
						case "paneling":
							return Data.XObjFunctionSubSort.Wall_Paneling;
						case "poured":
							return Data.XObjFunctionSubSort.Wall_Poured;
						case "siding":
							return Data.XObjFunctionSubSort.Wall_Siding;
						case "tile":
							return Data.XObjFunctionSubSort.Wall_Tile;
						case "wallpaper":
							return Data.XObjFunctionSubSort.Wall_Wallpaper;
						default:
							return Data.XObjFunctionSubSort.Wall_Other;
					}
				}
				case "terrainpaint":
				{
					return Data.XObjFunctionSubSort.Terrain;
				}
				case "floor":
				{
					switch (cpf.GetSaveItem("subsort")
						.StringValue.Trim()
						.ToLower())
					{
						case "brick":
							return Data.XObjFunctionSubSort.Floor_Brick;
						case "carpet":
							return Data.XObjFunctionSubSort.Floor_Carpet;
						case "lino":
							return Data.XObjFunctionSubSort.Floor_Lino;
						case "poured":
							return Data.XObjFunctionSubSort.Floor_Poured;
						case "stone":
							return Data.XObjFunctionSubSort.Floor_Stone;
						case "tile":
							return Data.XObjFunctionSubSort.Floor_Tile;
						case "wood":
							return Data.XObjFunctionSubSort.Floor_Wood;
						default:
							return Data.XObjFunctionSubSort.Floor_Other;
					}
				}
				case "roof":
				{
					return Data.XObjFunctionSubSort.Roof;
				}
				case "fence":
				{
					return cpf.GetSaveItem("ishalfwall").UIntegerValue == 1
						? Data.XObjFunctionSubSort.Fence_Halfwall
						: Data.XObjFunctionSubSort.Fence_Rail;
				}
				default:
				{
					return 0;
				}
			}
		}

		#region Thumbnails
		static Packages.File xthumbs,
			nthumbs;

		public static Image GetXThumbnail(Cpf cpf)
		{
			if (xthumbs == null)
			{
				xthumbs = Packages.File.LoadFromFile(
					System.IO.Path.Combine(
						PathProvider.SimSavegameFolder,
						"Thumbnails\\BuildModeThumbnails.package"
					)
				);
			}

			Packages.File tmbs = xthumbs;
			Data.XObjFunctionSubSort fss = GetFunctionSort(cpf);
			uint inst = cpf.GetSaveItem("guid").UIntegerValue;
			uint grp = cpf.FileDescriptor.Group;
			if (cpf.GetItem("thumbnailinstanceid") != null)
			{
				inst = cpf.GetSaveItem("thumbnailinstanceid").UIntegerValue;
				grp = cpf.GetSaveItem("thumbnailgroupid").UIntegerValue;
			}

			//get Thumbnail Type
			uint[] types = new uint[] { }; //{0x8C311262, 0x8C31125E}; //floors, walls - no point loading these, this can't find these thumbs anyway
			if (fss == Data.XObjFunctionSubSort.Roof)
			{
				types = new uint[] { 0xCC489E46 };
			}
			else if (
				fss == Data.XObjFunctionSubSort.Fence_Rail
				|| fss == Data.XObjFunctionSubSort.Fence_Halfwall
			)
			{
				types = new uint[] { 0xCC30CDF8 };
			}
			else if (fss == Data.XObjFunctionSubSort.Roof)
			{
				types = new uint[] { 0xCC489E46 };
			}
			else if (fss == Data.XObjFunctionSubSort.Terrain)
			{
				types = new uint[] { 0xEC3126C4 };
				if (cpf.GetItem("texturetname") != null)
				{
					inst = Hashes.GetCrc32(
						Hashes.StripHashFromName(
							cpf.GetItem("texturetname").StringValue.Trim().ToLower()
						)
					);
				}
			}
			else if (cpf.FileDescriptor.Type == Data.MetaData.XNGB)
			{
				types = new uint[] { 0x4D533EDD };
				if (nthumbs == null)
				{
					nthumbs = Packages.File.LoadFromFile(
						System.IO.Path.Combine(
							PathProvider.SimSavegameFolder,
							"Thumbnails\\CANHObjectsThumbnails.package"
						)
					);
				}

				tmbs = nthumbs;
			}

			return GetThumbnail(
				cpf.GetSaveItem("name").StringValue,
				types,
				grp,
				inst,
				tmbs
			);
		}
		#endregion
		/*
		private void InitializeComponent()
		{
			((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
			this.SuspendLayout();
			//
			// ObjectPreview
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.Name = "ObjectPreview";
			this.Size = new System.Drawing.Size(550, 231);
			((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}*/
	}
}
