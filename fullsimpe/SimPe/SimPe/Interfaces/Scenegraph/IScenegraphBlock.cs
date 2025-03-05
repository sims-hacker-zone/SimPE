// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.Generic;

namespace SimPe.Interfaces.Scenegraph
{
	/// <summary>
	/// Specialization of an IRcol Interface, providing additional Methods to find refereced Scenegraph Resources
	/// </summary>
	public interface IScenegraphBlock
	{
		/// <summary>
		/// Adds all Referenced Scenegraph Resources sorted by type of Reference
		/// </summary>
		/// <param name="refmap"></param>
		/// <param name="parentgroup"></param>
		/// <remarks>The Key is the name of the Reference Type, the value is an ArrayList containing all ReferencedFiles</remarks>
		void ReferencedItems(Dictionary<string, List<Files.IPackedFileDescriptor>> refmap, uint parentgroup);
	}
}
