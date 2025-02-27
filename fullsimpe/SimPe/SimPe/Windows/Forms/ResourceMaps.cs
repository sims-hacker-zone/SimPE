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
			all = new ResourceViewManager.ResourceNameList();
			typemap = new IntMap();
			groupmap = new IntMap();
			instmap = new LongMap();
		}

		IntMap typemap,
			groupmap;
		private LongMap instmap;
		private ResourceViewManager.ResourceNameList all;

		public ResourceViewManager.ResourceNameList Everything => all;

		internal IntMap ByGroup => groupmap;
		internal IntMap ByType => typemap;

		public LongMap ByInstance => instmap;

		public void Clear()
		{
			Clear(true);
		}

		public void Clear(bool call)
		{
			typemap.Clear();
			groupmap.Clear();
			instmap.Clear();
			if (call)
				all.Clear();
		}
	}
}
