// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace SimPe.Windows.Forms
{
	public class ResourceTreeTypeNodeExt : ResourceTreeNodeExt
	{
		public ResourceTreeTypeNodeExt(
			ResourceViewManager.ResourceNameList list,
			uint type
		)
			: base(type, list, "")
		{
			Type = type;
			ImageIndex = ResourceViewManager.GetIndexForResourceType(type);
			SelectedImageIndex = ImageIndex;
			Data.TypeAlias ta = Data.MetaData.FindTypeAlias(type);
			Text = ta.Name + " (" + ta.shortname + ") (" + list.Count + ")";
		}

		public uint Type
		{
			get;
		}

		#region IComparable<ResResourceTreeNodeExt> Member

		public new int CompareTo(ResourceTreeNodeExt other)
		{
			return Text.CompareTo(other.Text);
		}

		#endregion
	}
}
