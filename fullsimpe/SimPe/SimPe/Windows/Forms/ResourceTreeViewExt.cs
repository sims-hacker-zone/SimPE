// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Windows.Forms;

using SimPe.Data;

namespace SimPe.Windows.Forms
{
	public partial class ResourceTreeViewExt : UserControl
	{
		ResourceTreeNodesByType typebuilder;
		ResourceTreeNodesByGroup groupbuilder;
		ResourceTreeNodesByInstance instbuilder;
		ResourceViewManager manager;
		IResourceTreeNodeBuilder builder;

		public ResourceTreeViewExt()
		{
			allowselectevent = true;
			InitializeComponent();

			typebuilder = new ResourceTreeNodesByType();
			groupbuilder = new ResourceTreeNodesByGroup();
			instbuilder = new ResourceTreeNodesByInstance();
			builder = typebuilder;
			tbType.Checked = true;
			last = null;
		}

		~ResourceTreeViewExt()
		{
		}

		internal void SetManager(ResourceViewManager manager)
		{
			last = null;
			if (this.manager != manager)
			{
				this.manager = manager;
			}
		}

		public void Clear()
		{
			tv.Nodes.Clear();
		}

		ResourceMaps last;

		void SetResourceMaps(bool nosave)
		{
			tv.Nodes.Clear();
			if (last != null)
			{
				SetResourceMaps(last, true, nosave);
			}
		}

		bool allowselectevent;
		TreeNode firstnode;

		public bool SetResourceMaps(
			ResourceMaps maps,
			bool selectevent,
			bool dontselect
		)
		{
			return SetResourceMaps(maps, selectevent, dontselect, false);
		}

		protected bool SetResourceMaps(
			ResourceMaps maps,
			bool selectevent,
			bool dontselect,
			bool nosave
		)
		{
			last = maps;
			if (FileTableBase.WrapperRegistry != null)
			{
				tv.ImageList = FileTableBase.WrapperRegistry.WrapperImageList;
				tv.StateImageList = tv.ImageList;
			}
			if (!nosave)
			{
				SaveLastSelection();
			}

			Clear();
			firstnode = builder.BuildNodes(maps);
			tv.Nodes.Add(firstnode);
			firstnode.Expand();

			allowselectevent = selectevent;
			if (
				!dontselect
				&& (
					maps.Everything.Count
						<= Helper.WindowsRegistry.Config.BigPackageResourceCount
					|| Helper.WindowsRegistry.Config.ResoruceTreeAlwaysAutoselect
				)
			)
			{
				if (!SelectID(firstnode, builder.LastSelectedId))
				{
					SelectAll();
					allowselectevent = true;
					return false;
				}
			}
			else if (dontselect)
			{
				foreach (ResourceTreeNodeExt node in firstnode.Nodes)
				{
					if (node.ID == (uint)FileTypes.FAMI)
					{
						tv.SelectedNode = node;
						break;
					}
				}
			}

			allowselectevent = true;
			return true;
		}

		private void SaveLastSelection()
		{
			builder.LastSelectedId = tv.SelectedNode is ResourceTreeNodeExt node ? node.ID : 0;
		}

		protected bool SelectID(TreeNode node, ulong id)
		{
			if (node is ResourceTreeNodeExt rn)
			{
				if (rn.ID == id)
				{
					tv.SelectedNode = rn;
					rn.EnsureVisible();
					return true;
				}
			}

			foreach (TreeNode sub in node.Nodes)
			{
				if (SelectID(sub, id))
				{
					return true;
				}
			}

			return false;
		}

		public void SelectAll()
		{
			if (firstnode != null)
			{
				tv.SelectedNode = firstnode;
			}
		}

		private void tv_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (!allowselectevent)
			{
				return;
			}

			if (e.Node == null)
			{
				return;
			}

			if (e.Node is ResourceTreeNodeExt node)
			{
				if (manager != null)
				{
					manager.ListView?.SetResources(node.Resources);
				}
			}
		}

		private void SelectTreeBuilder(object sender, EventArgs e)
		{
			tbType.Checked = sender == tbType;
			tbGroup.Checked = sender == tbGroup;
			tbInst.Checked = sender == tbInst;

			SaveLastSelection();

			IResourceTreeNodeBuilder old = builder;
			builder = sender == tbInst ? instbuilder : sender == tbGroup ? groupbuilder : (IResourceTreeNodeBuilder)typebuilder;

			if (old != builder)
			{
				SetResourceMaps(true);
			}
		}

		internal void RestoreLayout()
		{
			SelectTreeBuilder(tbType, null);
		}
	}
}
