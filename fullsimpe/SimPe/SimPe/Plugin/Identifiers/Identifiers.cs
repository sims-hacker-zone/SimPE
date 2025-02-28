// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Interfaces.Plugin.Scanner;

namespace SimPe.Plugin.Identifiers
{
	/// <summary>
	/// Comapers two IIdentifierBase Instances
	/// </summary>
	internal class PluginScannerBaseComparer : System.Collections.IComparer
	{
		#region IComparer Member

		public int Compare(object x, object y)
		{
			if (x == null)
			{
				return y == null ? 0 : 1;
			}

			IScannerPluginBase ix = (IScannerPluginBase)x;
			IScannerPluginBase iy = (IScannerPluginBase)y;

			return ix.Index - iy.Index;
		}

		#endregion
	}

	/// <summary>
	/// Identifies a Cep Package
	/// </summary>
	internal class CepIdentifier : IIdentifier
	{
		public CepIdentifier()
		{
		}

		#region IIdentifierBase Member
		public uint Version => 1;

		public int Index => 100;

		public ScannerPluginType PluginType => ScannerPluginType.Identifier;
		#endregion

		#region IIdentifier Member

		public Cache.PackageType GetType(Interfaces.Files.IPackageFile pkg)
		{
			string name = System.IO.Path.GetFileName(pkg.FileName).Trim().ToLower();
			return name
				== System
					.IO.Path.GetFileName(Data.MetaData.GMND_PACKAGE)
					.Trim()
					.ToLower()
			|| name
				== System
					.IO.Path.GetFileName(Data.MetaData.MMAT_PACKAGE)
					.Trim()
					.ToLower()
				? Cache.PackageType.CEP
				: Cache.PackageType.Unknown;
		}

		#endregion
	}

	/// <summary>
	/// Identifies a Sim Package
	/// </summary>
	internal class SimIdentifier : IIdentifier
	{
		public SimIdentifier()
		{
		}

		#region IIdentifierBase Member
		public uint Version => 1;

		public int Index => 300;

		public ScannerPluginType PluginType => ScannerPluginType.Identifier;
		#endregion

		#region IIdentifier Member

		public Cache.PackageType GetType(Interfaces.Files.IPackageFile pkg)
		{
			if (pkg.FindFiles(0xCCCEF852).Length != 0)
			{
				return Cache.PackageType.Sim; //Facial Structure - Pets don't have
			}

			if (pkg.FindFiles(0xAC598EAC).Length != 0)
			{
				return Cache.PackageType.Sim; //Age Data - Outfits with GUID do have
			}

			return Cache.PackageType.Unknown;
		}

		#endregion
	}

	/// <summary>
	/// Identifies an Object Package
	/// </summary>
	internal class ObjectIdentifier : IIdentifier
	{
		public ObjectIdentifier()
		{
		}

		#region IIdentifierBase Member
		public uint Version => 1;

		public int Index => 600;

		public ScannerPluginType PluginType => ScannerPluginType.Identifier;
		#endregion

		#region IIdentifier Member

		public Cache.PackageType GetType(Interfaces.Files.IPackageFile pkg)
		{
			if (pkg.FindFiles(Data.MetaData.OBJD_FILE).Length == 0)
			{
				return Cache.PackageType.Unknown;
			}

			if (pkg.FindFiles(0x484F5553).Length > 0)
			{
				return Cache.PackageType.Lot; //HOUS Resources - Lots won't get here
			}

			return pkg.FindFilesByGroup(Data.MetaData.CUSTOM_GROUP).Length > 0 ? Cache.PackageType.CustomObject : Cache.PackageType.Object;
		}

		#endregion
	}

	/// <summary>
	/// Identifies a Recolor Package
	/// </summary>
	internal class CpfIdentifier : IIdentifier
	{
		public CpfIdentifier()
		{
		}

		#region IIdentifierBase Member
		public uint Version => 1;

		public int Index => 400;

		public ScannerPluginType PluginType => ScannerPluginType.Identifier;
		#endregion

		#region IIdentifier Member

		public Cache.PackageType GetType(Interfaces.Files.IPackageFile pkg)
		{
			Interfaces.Files.IPackedFileDescriptor[] pfds = pkg.FindFiles(
				Data.MetaData.GZPS
			);
			if (pfds.Length == 0)
			{
				pfds = pkg.FindFiles(Data.MetaData.XOBJ); //Object XML
			}

			if (pfds.Length == 0)
			{
				pfds = pkg.FindFiles(0x2C1FD8A1); //TextureOverlay XML
			}

			if (pfds.Length == 0)
			{
				pfds = pkg.FindFiles(0x8C1580B5); //Hairtone XML
			}

			if (pfds.Length == 0)
			{
				pfds = pkg.FindFiles(0x0C1FE246); //Mesh Overlay XML
			}

			if (pfds.Length == 0)
			{
				pfds = pkg.FindFiles(Data.MetaData.XROF); //Object XML
			}

			if (pfds.Length == 0)
			{
				pfds = pkg.FindFiles(Data.MetaData.XFLR); //Object XML
			}

			if (pfds.Length == 0)
			{
				pfds = pkg.FindFiles(Data.MetaData.XFNC); //Object XML
			}

			if (pfds.Length > 0)
			{
				PackedFiles.Wrapper.Cpf cpf = new PackedFiles.Wrapper.Cpf();
				cpf.ProcessData(pfds[0], pkg, false);


				switch (cpf.GetSaveItem("type").StringValue.Trim().ToLower())
				{
					case "wall":
					{
						return Cache.PackageType.Wallpaper;
					}
					case "terrainpaint":
					{
						return Cache.PackageType.Terrain;
					}
					case "floor":
					{
						return Cache.PackageType.Floor;
					}
					case "roof":
					{
						return Cache.PackageType.Roof;
					}
					case "fence":
					{
						return Cache.PackageType.Fence;
					}
					case "skin":
					{
						uint cat = cpf.GetSaveItem("category").UIntegerValue;

						return (cat & (uint)Data.OutfitCats.Skin) != 0 ? Cache.PackageType.Skin : Cache.PackageType.Clothing;
					}
					case "textureoverlay":
					{
						switch (
							cpf.GetSaveItem("subtype").UIntegerValue
						)
						{
							case (uint)Data.TextureOverlayTypes.Blush:
								return Cache.PackageType.Blush;
							case (uint)Data.TextureOverlayTypes.Eye:
								return Cache.PackageType.Eye;
							case (uint)Data.TextureOverlayTypes.EyeBrow:
								return Cache.PackageType.EyeBrow;
							case (uint)Data.TextureOverlayTypes.EyeShadow:
								return Cache.PackageType.EyeShadow;
							case (uint)Data.TextureOverlayTypes.Glasses:
								return Cache.PackageType.Glasses;
							case (uint)Data.TextureOverlayTypes.Lipstick:
								return Cache.PackageType.Lipstick;
							case (uint)Data.TextureOverlayTypes.Mask:
								return Cache.PackageType.Mask;
							case (uint)Data.TextureOverlayTypes.Beard:
								return Cache.PackageType.Beard;
							default:
								return Cache.PackageType.Makeup;
						}
					}
					case "meshoverlay":
						return Cache.PackageType.Accessory;
					case "hairtone":
					{
						return Cache.PackageType.Hair;
					}

					default:
						break;
				}
			}

			return Cache.PackageType.Unknown;
		}

		#endregion
	}

	/// <summary>
	/// Identifies a Recolor Package
	/// </summary>
	internal class ReColorIdentifier : IIdentifier
	{
		public ReColorIdentifier()
		{
		}

		#region IIdentifierBase Member
		public uint Version => 1;

		public int Index => 200;

		public ScannerPluginType PluginType => ScannerPluginType.Identifier;
		#endregion

		#region IIdentifier Member

		public Cache.PackageType GetType(Interfaces.Files.IPackageFile pkg)
		{
			if (pkg.FindFiles(Data.MetaData.TXMT).Length == 0)
			{
				return Cache.PackageType.Unknown;
			}

			if (pkg.FindFiles(Data.MetaData.OBJD_FILE).Length != 0)
			{
				return Cache.PackageType.Unknown;
			}

			if (pkg.FindFiles(Data.MetaData.GZPS).Length != 0)
			{
				return Cache.PackageType.Unknown;
			}

			if (pkg.FindFiles(0xCCA8E925).Length != 0)
			{
				return Cache.PackageType.Unknown; //Object XML
			}

			if (pkg.FindFiles(Data.MetaData.REF_FILE).Length != 0)
			{
				return Cache.PackageType.Unknown;
			}

			foreach (uint type in Data.MetaData.RcolList)
			{
				if (type == Data.MetaData.TXMT)
				{
					continue;
				}

				if (type == Data.MetaData.TXTR)
				{
					continue;
				}

				if (type == Data.MetaData.LIFO)
				{
					continue;
				}

				if (pkg.FindFiles(type).Length != 0)
				{
					return Cache.PackageType.Unknown;
				}
			}

			return Cache.PackageType.Recolour;
		}

		#endregion
	}
}
