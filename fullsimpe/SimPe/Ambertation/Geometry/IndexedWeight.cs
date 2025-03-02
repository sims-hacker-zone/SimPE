// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.ComponentModel;

namespace Ambertation.Geometry
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class IndexedWeight
	{
		private double w;

		private int index;

		public double Weight
		{
			get
			{
				return w;
			}
			set
			{
				w = value;
			}
		}

		public int Index
		{
			get
			{
				return index;
			}
			set
			{
				index = value;
			}
		}

		public IndexedWeight(Vector2 v)
			: this((int)v.X, v.Y)
		{
		}

		public IndexedWeight(int index, double w)
		{
			this.index = index;
			this.w = w;
		}

		public static implicit operator Vector2(IndexedWeight w)
		{
			return new Vector2(w.Index, w.Weight);
		}

		public static implicit operator IndexedWeight(Vector2 v)
		{
			return new IndexedWeight(v);
		}

		public override string ToString()
		{
			return index + ":" + w;
		}
	}
}
