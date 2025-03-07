// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using SimPe.PackedFiles.Wrapper;


namespace SimPe.Interfaces.Providers
{
	/// <summary>
	/// Interface to obtain all SimDescriptions available in a Package
	/// </summary>
	public interface ISimDescriptions : ICommonPackage
	{
		/// <summary>
		/// Find the Description of a Sim using the Instance Number
		/// </summary>
		/// <param name="instance">The Instance Id of the sim</param>
		/// <returns>null or a ISDesc Object</returns>
		Wrapper.ISDesc FindSim(ushort instance);

		/// <summary>
		/// Find the Description of a Sim using the Sim ID
		/// </summary>
		/// <param name="simid">The Sim ID</param>
		/// <returns>null or a ISDesc Object</returns>
		Wrapper.ISDesc FindSim(uint simid);

		/// <summary>
		/// returns the Instance Id for the given Sim
		/// </summary>
		/// <param name="simid">ID of the Sim</param>
		/// <returns>0xffff or a valid Instance Number</returns>
		ushort GetInstance(uint simid);

		/// <summary>
		/// returns the Sim Id for the given Sim
		/// </summary>
		/// <param name="instance">Instance Number of the Sim</param>
		/// <returns>0xffffffff or a valid Sim ID</returns>
		uint GetSimId(ushort instance);

		/// <summary>
		/// Returns availabl SDSC Files by SimGUID
		/// </summary>
		ILookup<uint, Wrapper.ISDesc> SimGuidMap
		{
			get;
		}

		/// <summary>
		/// Returns availabl SDSC Files by Instance
		/// </summary>
		ILookup<ushort, Wrapper.ISDesc> SimInstance
		{
			get;
		}

		/// <summary>
		/// Returns a List containing all Household Names
		/// </summary>
		/// <returns></returns>
		IEnumerable<string> GetHouseholdNames();

		/// <summary>
		/// Returns a List containing all Household Names
		/// </summary>
		/// <param name="firstcustom">Returns the name of the first household with a custom Sim in it</param>
		/// <returns></returns>
		IEnumerable<string> GetHouseholdNames(out string firstcustom);

		#region Nightlife
		/// <summary>
		/// Returns the name of a Turnon/Turnoff
		/// </summary>
		/// <param name="val1">stored Number for TurnOns1</param>
		/// <param name="val2">stored Number for TurnOns2</param>
		/// <param name="val3">stored Number for TurnOns3</param>
		/// <returns></returns>
		string GetTurnOnName(ushort val1, ushort val2, ushort val3);

		/// <summary>
		/// Create the Index from the passed Numbers
		/// </summary>
		/// <param name="val1"></param>
		/// <param name="val2"></param>
		/// <param name="val3"></param>
		/// <returns></returns>
		ulong BuildTurnOnIndex(ushort val1, ushort val2, ushort val3);

		/// <summary>
		/// Invers Operation to <see cref="BuildTurnOnIndex"/>
		/// </summary>
		/// <param name="index"></param>
		/// <returns>val1, val2 and val3</returns>
		ushort[] GetFromTurnOnIndex(ulong index);

		/// <summary>
		/// Returns a List of all available TurnOns
		/// </summary>
		/// <returns></returns>
		SimPe.Providers.TraitAlias[] GetAllTurnOns();
		#endregion

		#region BonVoyage
		/// <summary>
		/// Returns the name of a Vacation Collectibles
		/// </summary>
		/// <param name="val1">stored Number for Collectible1</param>
		/// <param name="val2">stored Number for Collectible2</param>
		/// <param name="val3">stored Number for Collectible3</param>
		/// <param name="val4">stored Number for Collectible4</param>
		/// <returns></returns>
		string GetCollectibleName(ushort val1, ushort val2, ushort val3, ushort val4);

		/// <summary>
		/// Create the Index from the passed Numbers
		/// </summary>
		/// <param name="val1"></param>
		/// <param name="val2"></param>
		/// <param name="val3"></param>
		/// <param name="val4"></param>
		/// <returns></returns>
		ulong BuildCollectibleIndex(ushort val1, ushort val2, ushort val3, ushort val4);

		/// <summary>
		/// Invers Operation to <see cref="BuildCollectibleIndex"/>
		/// </summary>
		/// <param name="index"></param>
		/// <param name="nr"></param>
		/// <returns>val1 - val4</returns>
		ushort[] GetFromCollectibleIndex(ulong index);

		/// <summary>
		/// Returns a List of all available Collectibles
		/// </summary>
		/// <returns></returns>
		SimPe.Providers.CollectibleAlias[] GetAllCollectibles();
		#endregion
	}
}
