// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.Data;
using SimPe.Extensions;

namespace SimPe.Windows.Forms
{
	public class ResourceTreeTypeNodeExt : ResourceTreeNodeExt
	{
		public ResourceTreeTypeNodeExt(
			ResourceViewManager.ResourceNameList list,
			FileTypes type
		)
			: base((uint)type, list, "")
		{
			Type = type;
			ImageIndex = ResourceViewManager.GetIndexForResourceType(type);
			SelectedImageIndex = ImageIndex;
			FileTypeInformation typeinfo = type.ToFileTypeInformation();
			Text = typeinfo.LongName + " (" + typeinfo.ShortName + ") (" + list.Count + ")";
		}

		public FileTypes Type
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
