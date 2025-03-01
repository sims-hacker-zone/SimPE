// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;

namespace SimPe.Interfaces.Providers
{
	public interface ILotItem
	{
		uint Instance
		{
			get;
		}

		System.Drawing.Image Image
		{
			get;
		}

		string Name
		{
			get;
		}

		string LotName
		{
			get;
		}

		object FindTag(Type t);
		ArrayList Tags
		{
			get;
		}

		uint Owner
		{
			get;
		}

		Scenegraph.IScenegraphFileIndexItem LtxtFileIndexItem
		{
			get;
		}

		Scenegraph.IScenegraphFileIndexItem BnfoFileIndexItem
		{
			get;
		}

		Scenegraph.IScenegraphFileIndexItem StrFileIndexItem
		{
			get;
		}
	}

	public delegate void LoadLotData(object sender, ILotItem item);

	/// <summary>
	/// Interface to obtain Lot Informations
	/// </summary>
	public interface ILotProvider
	{
		/// <summary>
		/// Returns or sets the Folder where the Character Files are stored
		/// </summary>
		/// <remarks>Sets the names List to null</remarks>
		string BaseFolder
		{
			get; set;
		}

		/// <summary>
		/// returns a List of all Lot Names
		/// </summary>
		/// <returns></returns>
		string[] GetNames();

		Hashtable StoredData
		{
			get;
		}

		ILotItem FindLot(uint inst);
		ILotItem[] FindLotsOwnedBySim(uint siminst);

		event LoadLotData LoadingLot;
	}
}
