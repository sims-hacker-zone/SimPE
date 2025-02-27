using System;
using System.Collections.Generic;
using System.Text;

namespace SimPe.Windows.Forms
{
	public abstract class AResourceTreeNodeBuilder : IResourceTreeNodeBuilder
	{
		public AResourceTreeNodeBuilder()
		{
			LastSelectedId = 0;
		}

		#region IResourceTreeNodeBuilder Member

		public abstract ResourceTreeNodeExt BuildNodes(ResourceMaps maps);

		public ulong LastSelectedId
		{
			get; set;
		}

		#endregion
	}
}
