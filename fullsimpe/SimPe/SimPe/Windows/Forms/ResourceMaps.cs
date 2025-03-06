// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.Generic;

using SimPe.Data;

namespace SimPe.Windows.Forms
{
	public class ResourceMaps
	{
		public class IntMap : Dictionary<uint, ResourceViewManager.ResourceNameList>
		{
		}
		public class TypeMap : Dictionary<FileTypes, ResourceViewManager.ResourceNameList>
		{
		}

		public class LongMap
			: Dictionary<ulong, ResourceViewManager.ResourceNameList>
		{
		}

		public ResourceMaps()
		{
			Everything = new ResourceViewManager.ResourceNameList();
			ByType = new TypeMap();
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
		internal TypeMap ByType
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
