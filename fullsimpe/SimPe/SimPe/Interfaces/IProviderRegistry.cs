// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Interfaces
{
	/// <summary>
	/// Stores a List of dedicated Providers
	/// </summary>
	public interface IProviderRegistry
	{
		/// <summary>
		/// Returns the Provider for SimNames
		/// </summary>
		Providers.ISimNames SimNameProvider
		{
			get;
		}

		/// <summary>
		/// Returns the Provider for Sim Family Names
		/// </summary>
		Providers.ISimFamilyNames SimFamilynameProvider
		{
			get;
		}

		/// <summary>
		/// Returns the Provider for SimDescription Files
		/// </summary>
		Providers.ISimDescriptions SimDescriptionProvider
		{
			get;
		}

		/// <summary>
		/// Returns the Provider for Opcode Names
		/// </summary>
		Providers.IOpcodeProvider OpcodeProvider
		{
			get;
		}

		/// <summary>
		/// Returns the Provider for Skin Data
		/// </summary>
		Providers.ISkinProvider SkinProvider
		{
			get;
		}

		Providers.ILotProvider LotProvider
		{
			get;
		}
	}
}
