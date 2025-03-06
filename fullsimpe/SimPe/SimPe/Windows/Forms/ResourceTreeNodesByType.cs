// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.Generic;
using System.Linq;

using SimPe.Data;

namespace SimPe.Windows.Forms
{
	class ResourceTreeNodesByType : AResourceTreeNodeBuilder
	{
		#region IResourceTreeNodeBuilder Member

		public override ResourceTreeNodeExt BuildNodes(ResourceMaps maps)
		{
			ResourceTreeNodeExt tn = new ResourceTreeNodeExt(
				0,
				maps.Everything,
				Localization.GetString("AllRes")
			);

			AddType(maps.ByType, tn);

			tn.ImageIndex = 0;
			return tn;
		}

		#endregion

		public static void AddType(ResourceMaps.TypeMap map, ResourceTreeNodeExt tn)
		{
			tn.Nodes.AddRange((from item in map
							   select new ResourceTreeTypeNodeExt(item.Value, item.Key))
							   .OrderBy(item => item.Text).ToArray());
		}
	}
}
