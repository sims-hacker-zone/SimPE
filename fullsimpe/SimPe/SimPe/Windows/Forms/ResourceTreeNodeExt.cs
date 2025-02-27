using System;
using System.Windows.Forms;

namespace SimPe.Windows.Forms
{
	public class ResourceTreeNodeExt : TreeNode, IComparable<ResourceTreeNodeExt>
	{
		ulong id;

		public ResourceTreeNodeExt(
			ulong id,
			ResourceViewManager.ResourceNameList list,
			string text
		)
			: base()
		{
			this.id = id;
			Resources = list;

			ImageIndex = 0;
			Text = text + " (" + list.Count + ")";
			SelectedImageIndex = ImageIndex;
		}

		public ResourceViewManager.ResourceNameList Resources
		{
			get;
		}

		public virtual ulong ID => id;

		#region IComparable<ResResourceTreeNodeExt> Member

		public int CompareTo(ResourceTreeNodeExt other)
		{
			return Text.CompareTo(other.Text);
		}

		#endregion
	}
}
