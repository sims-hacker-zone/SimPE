// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace SimPe.Windows.Forms
{
	public interface IResourceTreeNodeBuilder
	{
		ResourceTreeNodeExt BuildNodes(ResourceMaps maps);
		ulong LastSelectedId
		{
			get; set;
		}
	}
}
