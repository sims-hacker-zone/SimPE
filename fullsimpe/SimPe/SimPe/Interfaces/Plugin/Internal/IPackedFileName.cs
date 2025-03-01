// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Interfaces.Plugin.Internal
{
	/// <summary>
	/// This Interface Implements Methods that must be provided by a PackedFile Wrapper
	/// </summary>
	/// <remarks>If you want to Implement a Wrapper you must use the SimPe.Interfaces.Plugin.IFileWrapper</remarks>
	public interface IPackedFileName
	{
		/// <summary>
		/// Get the Name of a Resource
		/// </summary>
		string ResourceName
		{
			get;
		}

		/// <summary>
		/// Get a Description for this Package
		/// </summary>
		string Description
		{
			get;
		}

		/// <summary>
		/// Get the Header for this Description(i.e. Fieldnames)
		/// </summary>
		string DescriptionHeader
		{
			get;
		}
	}
}
