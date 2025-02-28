// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;

using SimPe.Interfaces.Files;

namespace SimPe.Interfaces.Plugin
{
	public class ReferenceList : List<IPackedFileDescriptorSimple>
	{
	}

	public interface IReferenceList : IList<IPackedFileDescriptorSimple>
	{
	}

	public interface IWrapperReferencedResources
	{
		IReferenceList ReferencedResources();
	}
}
