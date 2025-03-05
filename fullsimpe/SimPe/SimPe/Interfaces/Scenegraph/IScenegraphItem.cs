// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;

namespace SimPe.Interfaces.Scenegraph
{
	/// <summary>
	/// Specialization of an IRcol Interface, providing additional Methods to find refereced Scenegraph Resources
	/// </summary>
	public interface IScenegraphItem
	{
		/// <summary>
		/// Returns all Referenced Scenegraph Resources sorted by type of Reference
		/// </summary>
		/// <remarks>The Key is the name of the Reference Type, the value is an ArrayList containing all ReferencedFiles</remarks>
		Dictionary<string, List<Files.IPackedFileDescriptor>> ReferenceChains
		{
			get;
		}

		/// <summary>
		/// Returns the first Referenced RCOL Resource for the passed Type
		/// </summary>
		/// <param name="type">Type of the Resource you are looking for</param>
		/// <returns>Descriptor for the first found RCOL Resource or null</returns>
		//FindReferencedType(uint type);
	}
}
