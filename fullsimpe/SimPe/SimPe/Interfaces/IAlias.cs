// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Interfaces
{
	/// <summary>
	/// Interface for Value - Name Aliase
	/// </summary>
	public interface IAlias
	{
		/// <summary>
		/// The id Value
		/// </summary>
		uint Id
		{
			get;
		}

		/// <summary>
		/// The long Name
		/// </summary>
		string Name
		{
			get;
		}

		/// <summary>
		/// Can be used to Store Meta Informations with an Alias Entry
		/// </summary>
		object[] Tag
		{
			get; set;
		}
	}
}
