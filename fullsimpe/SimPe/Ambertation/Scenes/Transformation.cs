// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using Ambertation.Geometry;

namespace Ambertation.Scenes
{
	public class Transformation
	{
		private Vector3 s;

		private Vector3 t;

		private Vector3 r;

		private object tag;

		public Vector3 Scaling
		{
			get
			{
				return s;
			}
			set
			{
				s = value;
			}
		}

		public Vector3 Translation
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

		public Vector3 Rotation
		{
			get
			{
				return r;
			}
			set
			{
				r = value;
			}
		}

		public object Tag
		{
			get
			{
				return tag;
			}
			set
			{
				tag = value;
			}
		}

		public Transformation()
			: this(1.0, 1.0, 1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0)
		{
		}

		public Transformation(double sx, double sy, double sz, double tx, double ty, double tz, double rx, double ry, double rz)
			: this(new Vector3(sx, sy, sz), new Vector3(tx, ty, tz), new Vector3(rx, ry, rz))
		{
		}

		public Transformation(Vector3 scale, Vector3 translate, Vector3 rotate)
		{
			s = scale;
			t = translate;
			r = rotate;
		}

		public Matrix ToMatrix()
		{
			return Matrix.Translation(t) * Matrix.RotateZ(r.Z) * Matrix.RotateY(r.Y) * Matrix.RotateX(r.X) * Matrix.Scale(s.X, s.Y, s.Z);
		}
	}
}
