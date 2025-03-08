// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.ComponentModel;

namespace Ambertation.Geometry
{
	public class Vector2
	{
		protected double x;

		protected double y;

		public static Vector2 Zero => new Vector2(0.0, 0.0);

		public double X
		{
			get
			{
				return x;
			}
			set
			{
				x = value;
			}
		}

		public double Y
		{
			get
			{
				return y;
			}
			set
			{
				y = value;
			}
		}

		public Vector2(double x, double y)
		{
			this.x = x;
			this.y = y;
		}

		public override string ToString()
		{
			return x + ";" + y;
		}

		public override int GetHashCode()
		{
			return (int)X;
		}

		public override bool Equals(object obj)
		{
			if (obj is Vector2)
			{
				Vector2 vector = obj as Vector2;
				return Math.Abs(vector.x - x) < 1.4012984643248171E-45 && Math.Abs(vector.x - x) < 1.4012984643248171E-45;
			}

			return base.Equals(obj);
		}
	}
}
