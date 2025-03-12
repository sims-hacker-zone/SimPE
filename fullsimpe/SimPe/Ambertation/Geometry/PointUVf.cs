// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.ComponentModel;

namespace Ambertation.Geometry
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class PointUVf : Vector2
	{
		public double U
		{
			get
			{
				return base.X;
			}
			set
			{
				base.X = value;
			}
		}

		public double V
		{
			get
			{
				return base.Y;
			}
			set
			{
				base.Y = value;
			}
		}

		public PointUVf(double u, double v)
			: base(u, v)
		{
		}
	}
}
