using System;
using System.Collections.Generic;
using System.Text;

namespace SimPe.Windows.Forms
{
	public class ResourceMaps
	{
		public class IntMap : Dictionary<uint, ResourceViewManager.ResourceNameList>
		{
		}

		public class LongMap
			: Dictionary<ulong, ResourceViewManager.ResourceNameList>
		{
		}

		public ResourceMaps()
		{
			Everything = new ResourceViewManager.ResourceNameList();
			ByType = new IntMap();
			ByGroup = new IntMap();
			ByInstance = new LongMap();
		}

		public ResourceViewManager.ResourceNameList Everything
		{
			get;
		}

		internal IntMap ByGroup
		{
			get;
		}
		internal IntMap ByType
		{
			get;
		}

		public LongMap ByInstance
		{
			get;
		}

		public void Clear()
		{
			Clear(true);
		}

		public void Clear(bool call)
		{
			ByType.Clear();
			ByGroup.Clear();
			ByInstance.Clear();
			if (call)
			{
				Everything.Clear();
			}
		}
	}
}
