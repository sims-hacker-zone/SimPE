// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.Generic;
using System.Drawing;

using SimPe.Data;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Cpf;
using SimPe.PackedFiles.Str;

namespace SimPe.Plugin.Downloads
{
	public class XTypeHandler : DefaultTypeHandler
	{
		static FileTypes[] xtypes = new FileTypes[]
		{
			Data.FileTypes.XFLR,
			Data.FileTypes.XFNC,
			Data.FileTypes.XROF,
			Data.FileTypes.XOBJ,
			Data.FileTypes.XNGB,
		};

		public XTypeHandler(
			Cache.PackageType type,
			Interfaces.Files.IPackageFile pkg,
			bool countvert,
			bool rendergmdc
		)
			: base(type, pkg, countvert, rendergmdc) { }

		public XTypeHandler()
			: base() { }

		Cpf cpf;

		public override void SetFromObjectCacheItem(Cache.ObjectCacheItem oci)
		{
			ClearScreen();
			if (oci == null)
			{
				objd = null;
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
				if (oci.Tag is Interfaces.Scenegraph.IScenegraphFileIndexItem item)
				{
					cpf = new Cpf().ProcessFile(
						item
					);
				}
			}

			UpdateXObjScreen(null, false);
			nfo.Image = oci.Thumbnail;
			nfo.Name = oci.Name;
		}

		public override void SetFromPackage(Interfaces.Files.IPackageFile pkg)
		{
			ClearScreen();
			if (pkg == null)
			{
				objd = null;
				return;
			}

			//this is a regular Object?
			if (pkg.FindFiles(Data.FileTypes.OBJD).Length > 0)
			{
				cpf = null;
				base.SetFromPackage(pkg);
				return;
			}

			objd = null;
			GetCpf(pkg);

			UpdateXObjScreen(pkg, false);
		}

		protected void GetCpf(Interfaces.Files.IPackageFile pkg)
		{
			foreach (FileTypes t in xtypes)
			{
				foreach (Interfaces.Files.IPackedFileDescriptor pfd in pkg.FindFiles(t))
				{
					cpf = new Cpf().ProcessFile(pfd, pkg);

					CpfItem item = cpf.GetItem("guid");
					if (item != null)
					{
						nfo.AddGuid(item.UIntegerValue);
					}
				}
			}
		}

		public void SetFromXObject(Cpf cpf)
		{
			this.cpf = cpf;
			UpdateXObjScreen(cpf.Package, true);
		}

		protected void UpdateXObjScreen(
			Interfaces.Files.IPackageFile pkg,
			bool clear
		)
		{
			if (clear)
			{
				ClearScreen();
			}

			if (cpf == null)
			{
				return;
			}

			nfo.FirstExpansion = PackageInfo.FileFrom(cpf.FileDescriptor);
			SetupCategories(
				Cache.ObjectCacheItem.GetCategory(
					Cache.ObjectCacheItemVersions.DockableOW,
					(Data.ObjFunctionSubSort)GetFunctionSort(cpf),
					Data.ObjectTypes.Normal,
					Cache.ObjectClass.XObject
				)
			);

			nfo.Image = GetXThumbnail(cpf);
			if (pkg != null)
			{
				RenderGmdcPreview(pkg);
			}

			List<StrToken> strs = GetCtssItems();
			if (strs != null)
			{
				if (strs.Count > 0)
				{
					nfo.Name = strs[0].Title;
				}

				if (strs.Count > 1)
				{
					nfo.Description = strs[1].Title;
				}
			}
			else
			{
				nfo.Name = cpf.GetSaveItem("name").StringValue;
				nfo.Description = cpf.GetSaveItem("description").StringValue;
			}

			nfo.Price = (int)cpf.GetSaveItem("cost").UIntegerValue;
			UpdateScreen();
		}

		protected override List<StrToken> GetCtssItems()
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

				return GetCtssItems(ctss, cpf.Package);
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
			FileTypes[] types = new FileTypes[] { FileTypes.THUMB_FLOOR, FileTypes.THUMB_WALL }; //floors, walls
			if (fss == Data.XObjFunctionSubSort.Roof)
			{
				types = new FileTypes[] { FileTypes.THUMB_ROOF };
			}
			else if (
				fss == Data.XObjFunctionSubSort.Fence_Rail
				|| fss == Data.XObjFunctionSubSort.Fence_Halfwall
			)
			{
				types = new FileTypes[] { FileTypes.THUMB_FENCE };
			}
			else if (fss == Data.XObjFunctionSubSort.Roof)
			{
				types = new FileTypes[] { FileTypes.THUMB_ROOF };
			}
			else if (fss == Data.XObjFunctionSubSort.Terrain)
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
			else if (cpf.FileDescriptor.Type == Data.FileTypes.XNGB)
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
			//tmbs = null;
		}
		#endregion
	}
}
