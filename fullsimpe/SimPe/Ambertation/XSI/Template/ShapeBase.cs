// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections;
using Ambertation.Geometry.Collections;

namespace Ambertation.XSI.Template
{
	public class ShapeBase : ArgumentContainer
	{
		public enum Layouts
		{
			ORDERED,
			INDEXED
		}

		public enum ElementTypes
		{
			POSITION = 1,
			NORMAL = 2,
			COLOR = 4,
			TEX_COORD_UV0 = 8,
			TEX_COORD_UV1 = 0x10,
			TEX_COORD_UV2 = 0x20,
			TEX_COORD_UV3 = 0x40,
			TEX_COORD_UV = 0x80
		}

		protected Hashtable map;

		internal ShapeBase(Container parent, string args)
			: base(parent, args)
		{
			map = new Hashtable();
			Reset();
		}

		protected override void PrepareSerialize()
		{
			base.PrepareSerialize();
		}

		protected virtual void Reset()
		{
			map.Clear();
			Array values = Enum.GetValues(typeof(ElementTypes));
			foreach (ElementTypes item in values)
			{
				map[item.ToString()] = CreateElementList(item);
			}
		}

		protected IElementCollection GetElementList(ElementTypes t)
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected O, but got Unknown
			return (IElementCollection)map[t.ToString()];
		}

		protected virtual IElementCollection CreateElementList(ElementTypes t)
		{
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Expected O, but got Unknown
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Expected O, but got Unknown
			switch (t)
			{
				case ElementTypes.POSITION:
				case ElementTypes.NORMAL:
					return (IElementCollection)new Vector3Collection();
				case ElementTypes.COLOR:
					return (IElementCollection)new Vector4Collection();
				default:
					return (IElementCollection)new Vector2Collection();
			}
		}
	}
}
