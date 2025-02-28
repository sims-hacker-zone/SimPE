// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Cache;
using SimPe.Interfaces.Files;

namespace SimPe.Interfaces.Plugin.Scanner
{
	/// <summary>
	/// Determins the Type of a Plugin
	/// </summary>
	public enum ScannerPluginType : byte
	{
		None = 0x0,
		Scanner = 0x1,
		Identifier = 0x2,
		Both = 0x03,
	}

	/// <summary>
	/// Implements the very basic Interface for a Scanner/Identifier,
	/// this is used to determin wether or not a Scanner/Identifier can be loaded!
	/// </summary>
	public interface IScannerPluginBase
	{
		/// <summary>
		/// Returns the Version of the IIdentifier Interface the scanner/identifier is implementing
		/// </summary>
		/// <remarks>
		/// The current Scan Folders Plugin will only process Scanners/identifiers
		/// with a Version of 1
		/// </remarks>
		uint Version
		{
			get;
		}

		/// <summary>
		/// Returns the Position of the Index in the ScanList
		/// </summary>
		/// <remarks>
		/// Identifiers are ordere, meaning you can determin in which order the
		/// scanners are called, specifiyinga low index (negative) will make a
		/// Identifier to be executed early, a High Index will execute it later
		/// </remarks>
		int Index
		{
			get;
		}

		/// <summary>
		/// Returns the Interface that is implemented by the Plugin
		/// </summary>
		ScannerPluginType PluginType
		{
			get;
		}
	}

	/// <summary>
	/// Identifies the Type of a Package
	/// </summary>
	public interface IIdentifier : IScannerPluginBase
	{
		/// <summary>
		/// Retunrs the Primary Type of the passed Pacakge
		/// </summary>
		/// <param name="pkg">The Package too check</param>
		/// <returns>The type</returns>
		/// <remarks>Returns Unknown if this Identifier was unable to determin the Type</remarks>
		PackageType GetType(IPackageFile pkg);
	}
}
