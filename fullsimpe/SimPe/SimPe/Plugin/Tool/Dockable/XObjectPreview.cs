// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.ComponentModel;
using System.Drawing;

using SimPe.Data;
using SimPe.PackedFiles.Cpf;

namespace SimPe.Plugin.Tool.Dockable
{
	/// <summary>
	/// Component to display Details about a passed Object
	/// </summary>
	public class ObjectPreview : SimpleObjectPreview
	{
		FileTypes[] xtypes;

		public ObjectPreview()
			: base()
		{
			xtypes = new FileTypes[]
			{
				FileTypes.XFLR,
				FileTypes.XFNC,
				FileTypes.XROF,
				FileTypes.XOBJ,
				FileTypes.XNGB,
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
			if (pkg.FindFiles(FileTypes.OBJD).Length > 0)
			{
				cpf = null;
				base.SetFromPackage(pkg);
				return;
			}

			objd = null;
			cpf = null; // CJH

			foreach (FileTypes t in xtypes)
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
					ObjectTypes.Normal,
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
					(FileTypes)cpf.GetSaveItem("stringsetrestypeid").UIntegerValue,
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
							return XObjFunctionSubSort.Hood_Landmark;
						case "flora":
							return XObjFunctionSubSort.Hood_Flora;
						case "effects":
							return XObjFunctionSubSort.Hood_Effects;
						case "misc":
							return XObjFunctionSubSort.Hood_Misc;
						case "stone":
							return XObjFunctionSubSort.Hood_Stone;
						default:
							return XObjFunctionSubSort.Hood_Other;
					}
				}
				case "wall":
				{
					switch (cpf.GetSaveItem("subsort")
						.StringValue.Trim()
						.ToLower())
					{
						case "brick":
							return XObjFunctionSubSort.Wall_Brick;
						case "masonry":
							return XObjFunctionSubSort.Wall_Masonry;
						case "paint":
							return XObjFunctionSubSort.Wall_Paint;
						case "paneling":
							return XObjFunctionSubSort.Wall_Paneling;
						case "poured":
							return XObjFunctionSubSort.Wall_Poured;
						case "siding":
							return XObjFunctionSubSort.Wall_Siding;
						case "tile":
							return XObjFunctionSubSort.Wall_Tile;
						case "wallpaper":
							return XObjFunctionSubSort.Wall_Wallpaper;
						default:
							return XObjFunctionSubSort.Wall_Other;
					}
				}
				case "terrainpaint":
				{
					return XObjFunctionSubSort.Terrain;
				}
				case "floor":
				{
					switch (cpf.GetSaveItem("subsort")
						.StringValue.Trim()
						.ToLower())
					{
						case "brick":
							return XObjFunctionSubSort.Floor_Brick;
						case "carpet":
							return XObjFunctionSubSort.Floor_Carpet;
						case "lino":
							return XObjFunctionSubSort.Floor_Lino;
						case "poured":
							return XObjFunctionSubSort.Floor_Poured;
						case "stone":
							return XObjFunctionSubSort.Floor_Stone;
						case "tile":
							return XObjFunctionSubSort.Floor_Tile;
						case "wood":
							return XObjFunctionSubSort.Floor_Wood;
						default:
							return XObjFunctionSubSort.Floor_Other;
					}
				}
				case "roof":
				{
					return XObjFunctionSubSort.Roof;
				}
				case "fence":
				{
					return cpf.GetSaveItem("ishalfwall").UIntegerValue == 1
						? XObjFunctionSubSort.Fence_Halfwall
						: XObjFunctionSubSort.Fence_Rail;
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
			FileTypes[] types = new FileTypes[] { }; //{FileTypes.THUMB_FLOOR, FileTypes.THUMB_WALL}; //floors, walls - no point loading these, this can't find these thumbs anyway
			if (fss == XObjFunctionSubSort.Roof)
			{
				types = new FileTypes[] { FileTypes.THUMB_ROOF };
			}
			else if (
				fss == XObjFunctionSubSort.Fence_Rail
				|| fss == XObjFunctionSubSort.Fence_Halfwall
			)
			{
				types = new FileTypes[] { FileTypes.THUMB_FENCE };
			}
			else if (fss == XObjFunctionSubSort.Roof)
			{
				types = new FileTypes[] { FileTypes.THUMB_ROOF };
			}
			else if (fss == XObjFunctionSubSort.Terrain)
			{
				types = new FileTypes[] { FileTypes.THUMB_TERRAIN };
				if (cpf.GetItem("texturetname") != null)
				{
					inst = Hashes.GetCrc32(
						Hashes.StripHashFromName(
							cpf.GetItem("texturetname").StringValue.Trim().ToLower()
						)
					);
				}
			}
			else if (cpf.FileDescriptor.Type == FileTypes.XNGB)
			{
				types = new FileTypes[] { FileTypes.THUMB_NHOBJ };
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
