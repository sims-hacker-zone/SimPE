// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Interfaces.Plugin.Scanner;

namespace SimPe.Plugin
{
	/// <summary>
	/// Identifies a Recolor Package
	/// </summary>
	internal class NeighborhoodIdentifier : IIdentifier
	{
		public NeighborhoodIdentifier()
		{
		}

		#region IIdentifierBase Member
		public uint Version => 1;

		public int Index => 500;

		public ScannerPluginType PluginType => ScannerPluginType.Identifier;
		#endregion

		#region IIdentifier Member

		public Cache.PackageType GetType(Interfaces.Files.IPackageFile pkg)
		{
			return pkg.FindFiles(Data.MetaData.IDNO).Length != 0
				? Cache.PackageType.Neighbourhood
				: pkg.FileName.Contains("Tutorial_Neighborhood")
				? Cache.PackageType.Neighbourhood
				: pkg.FindFiles(Data.MetaData.HOUS).Length != 0
				? Cache.PackageType.Lot
				: pkg.FindFiles(Data.MetaData.GINV).Length != 0 ? Cache.PackageType.GameInventory : Cache.PackageType.Unknown;
		}

		#endregion
	}
}
