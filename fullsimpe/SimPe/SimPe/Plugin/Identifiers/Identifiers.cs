// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Data;
using SimPe.Interfaces.Plugin;
using SimPe.Interfaces.Plugin.Scanner;
using SimPe.PackedFiles.Cpf;

namespace SimPe.Plugin.Identifiers
{
	/// <summary>
	/// Comapers two IIdentifierBase Instances
	/// </summary>
	internal class PluginScannerBaseComparer : System.Collections.Generic.IComparer<IScannerPluginBase>
	{
		#region IComparer Member

		public int Compare(IScannerPluginBase x, IScannerPluginBase y)
		{
			return x.Index - y.Index;
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
			if (pkg.FindFiles(FileTypes.LxNR).Length != 0)
			{
				return Cache.PackageType.Sim; //Facial Structure - Pets don't have
			}

			if (pkg.FindFiles(FileTypes.AGED).Length != 0)
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
			if (pkg.FindFiles(Data.FileTypes.OBJD).Length == 0)
			{
				return Cache.PackageType.Unknown;
			}

			if (pkg.FindFiles(FileTypes.HOUS).Length > 0)
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
				Data.FileTypes.GZPS
			);
			if (pfds.Length == 0)
			{
				pfds = pkg.FindFiles(Data.FileTypes.XOBJ); //Object XML
			}

			if (pfds.Length == 0)
			{
				pfds = pkg.FindFiles(FileTypes.XTOL); //TextureOverlay XML
			}

			if (pfds.Length == 0)
			{
				pfds = pkg.FindFiles(FileTypes.XHTN); //Hairtone XML
			}

			if (pfds.Length == 0)
			{
				pfds = pkg.FindFiles(FileTypes.XMOL); //Mesh Overlay XML
			}

			if (pfds.Length == 0)
			{
				pfds = pkg.FindFiles(Data.FileTypes.XROF); //Object XML
			}

			if (pfds.Length == 0)
			{
				pfds = pkg.FindFiles(Data.FileTypes.XFLR); //Object XML
			}

			if (pfds.Length == 0)
			{
				pfds = pkg.FindFiles(Data.FileTypes.XFNC); //Object XML
			}

			if (pfds.Length > 0)
			{
				Cpf cpf = new Cpf().ProcessFile(pfds[0], pkg, false);


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
			if (pkg.FindFiles(FileTypes.TXMT).Length == 0)
			{
				return Cache.PackageType.Unknown;
			}

			if (pkg.FindFiles(Data.FileTypes.OBJD).Length != 0)
			{
				return Cache.PackageType.Unknown;
			}

			if (pkg.FindFiles(Data.FileTypes.GZPS).Length != 0)
			{
				return Cache.PackageType.Unknown;
			}

			if (pkg.FindFiles(FileTypes.XOBJ).Length != 0)
			{
				return Cache.PackageType.Unknown; //Object XML
			}

			if (pkg.FindFiles(Data.FileTypes.THREE_IDR).Length != 0)
			{
				return Cache.PackageType.Unknown;
			}

			foreach (FileTypes type in Data.MetaData.RcolList)
			{
				if (type == FileTypes.TXMT)
				{
					continue;
				}

				if (type == Data.FileTypes.TXTR)
				{
					continue;
				}

				if (type == Data.FileTypes.LIFO)
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
