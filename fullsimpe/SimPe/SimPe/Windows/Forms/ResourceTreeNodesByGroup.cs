// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.Generic;

namespace SimPe.Windows.Forms
{
	class ResourceTreeNodesByGroup : AResourceTreeNodeBuilder
	{
		#region IResourceTreeNodeBuilder Member

		public override ResourceTreeNodeExt BuildNodes(ResourceMaps maps)
		{
			ResourceTreeNodeExt tn = new ResourceTreeNodeExt(
				0,
				maps.Everything,
				Localization.GetString("AllRes")
			);

			AddGroups(maps.ByGroup, tn, true, true);

			tn.ImageIndex = 0;
			return tn;
		}
		#endregion

		public static void AddGroups(
			ResourceMaps.IntMap map,
			ResourceTreeNodeExt tn,
			bool type,
			bool inst
		)
		{
			List<ResourceTreeNodeExt> nodelist = new List<ResourceTreeNodeExt>();
			foreach (uint group in map.Keys)
			{
				ResourceViewManager.ResourceNameList list = map[group];
				ResourceTreeNodeExt node = new ResourceTreeNodeExt(
					group,
					list,
					"0x" + Helper.HexString(group)
				);
				if (type)
				{
					ResourceTreeNodeExt typenode = new ResourceTreeNodeExt(
						group,
						list,
						"Types"
					);
					AddSubNodesForTypes(typenode, list);
					node.Nodes.Add(typenode);
				}

				if (inst)
				{
					ResourceTreeNodeExt instnode = new ResourceTreeNodeExt(
						group,
						list,
						"Instances"
					);
					AddSubNodesForInstances(instnode, list);
					node.Nodes.Add(instnode);
				}

				nodelist.Add(node);
			}

			nodelist.Sort();
			foreach (ResourceTreeNodeExt node in nodelist)
			{
				tn.Nodes.Add(node);
			}
		}

		public static void AddSubNodesForTypes(
			ResourceTreeNodeExt node,
			ResourceViewManager.ResourceNameList resources
		)
		{
			ResourceMaps.TypeMap map = new ResourceMaps.TypeMap();
			foreach (NamedPackedFileDescriptor pfd in resources)
			{
				ResourceViewManager.ResourceNameList list;
				if (!map.ContainsKey(pfd.Descriptor.Type))
				{
					list = new ResourceViewManager.ResourceNameList();
					map.Add(pfd.Descriptor.Type, list);
				}
				else
				{
					list = map[pfd.Descriptor.Type];
				}

				list.Add(pfd);
			}

			ResourceTreeNodesByType.AddType(map, node);
		}

		public static void AddSubNodesForInstances(
			ResourceTreeNodeExt node,
			ResourceViewManager.ResourceNameList resources
		)
		{
			ResourceMaps.LongMap map = new ResourceMaps.LongMap();
			foreach (NamedPackedFileDescriptor pfd in resources)
			{
				ResourceViewManager.ResourceNameList list;
				if (!map.ContainsKey(pfd.Descriptor.LongInstance))
				{
					list = new ResourceViewManager.ResourceNameList();
					map.Add(pfd.Descriptor.LongInstance, list);
				}
				else
				{
					list = map[pfd.Descriptor.LongInstance];
				}

				list.Add(pfd);
			}

			ResourceTreeNodesByInstance.AddInstances(map, node, false, false);
		}
	}
}
