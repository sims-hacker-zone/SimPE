// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Drawing;
using Ambertation.Geometry;

namespace Ambertation.XSI.Template
{
	public sealed class Light : ArgumentContainer
	{
		public enum Types
		{
			Point,
			Directional,
			Spot,
			Infinite
		}

		private Types t;

		private Vector3 p;

		private Vector3 i;

		private Vector3 o;

		private Color cl;

		private double ca;

		private double sa;

		public Vector3 Position
		{
			get
			{
				return p;
			}
			set
			{
				p = value;
			}
		}

		public Vector3 PointOfInterest
		{
			get
			{
				return i;
			}
			set
			{
				i = value;
			}
		}

		public Vector3 Orientation
		{
			get
			{
				return o;
			}
			set
			{
				o = value;
			}
		}

		public Color Color
		{
			get
			{
				return cl;
			}
			set
			{
				cl = value;
			}
		}

		public double SpreadAngle
		{
			get
			{
				return sa;
			}
			set
			{
				sa = value;
			}
		}

		public double ConeAngle
		{
			get
			{
				return ca;
			}
			set
			{
				ca = value;
			}
		}

		public Types Type
		{
			get
			{
				return t;
			}
			set
			{
				t = value;
			}
		}

		public string LightName
		{
			get
			{
				return base.Argument1;
			}
			set
			{
				base.Argument1 = value;
			}
		}

		public Light(Container parent, string args)
			: base(parent, args)
		{
			Reset();
			ResetName();
		}

		private void ResetName()
		{
			ResetArgs("Light");
		}

		private void Reset()
		{
			ResetName();
			p = Vector3.Zero;
			i = Vector3.Zero;
			o = Vector3.Zero;
			cl = Color.White;
			ca = 0.0;
			sa = 0.0;
		}

		protected override void FinishDeSerialize()
		{
			base.FinishDeSerialize();
			Reset();
			int startline = 0;
			t = (Types)Line(startline++).GetFloat(0);
			cl = ReadColor(ref startline, inclalpha: false);
			p = ReadVector3(ref startline);
			if (t == Types.Infinite)
			{
				o = ReadVector3(ref startline);
			}
			else if (t == Types.Spot)
			{
				i = ReadVector3(ref startline);
				ca = Line(startline++).GetFloat(0);
				sa = Line(startline++).GetFloat(0);
			}
			else if (t == Types.Directional)
			{
				o = ReadVector3(ref startline);
				ca = Line(startline++).GetFloat(0);
				sa = Line(startline++).GetFloat(0);
			}

			CustomClear();
		}

		protected override void PrepareSerialize()
		{
			base.PrepareSerialize();
			Clear(rec: false);
			AddLiteral((int)t);
			WriteColor(inclalpha: false, cl);
			WriteVector3(p, oneline: false);
			if (t == Types.Infinite)
			{
				WriteVector3(o, oneline: false);
			}
			else if (t == Types.Spot)
			{
				WriteVector3(i, oneline: false);
				AddLiteral(ca);
				AddLiteral(sa);
			}
			else if (t == Types.Directional)
			{
				WriteVector3(o, oneline: false);
				AddLiteral(ca);
				AddLiteral(sa);
			}
		}
	}
}
