// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using Ambertation.Geometry;

namespace Ambertation.XSI.Template
{
	public sealed class Camera : ArgumentContainer
	{
		private Vector3 p;

		private Vector3 i;

		private double roll;

		private double fov;

		private double near;

		private double far;

		public string CameraName
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

		public double Roll
		{
			get
			{
				return roll;
			}
			set
			{
				roll = value;
			}
		}

		public double FoV
		{
			get
			{
				return fov;
			}
			set
			{
				fov = value;
			}
		}

		public double Near
		{
			get
			{
				return near;
			}
			set
			{
				near = value;
			}
		}

		public double Far
		{
			get
			{
				return far;
			}
			set
			{
				far = value;
			}
		}

		public Camera(Container parent, string args)
			: base(parent, args)
		{
			p = Vector3.Zero;
			i = Vector3.Zero;
			fov = Math.PI / 4.0;
			roll = 0.0;
			near = 0.1;
			far = 32767.0;
		}

		protected override void ResetArgs()
		{
			base.ResetArgs("Camera");
		}

		protected override void FinishDeSerialize()
		{
			base.FinishDeSerialize();
			int index = 0;
			p = ReadVector3(ref index);
			i = ReadVector3(ref index);
			roll = Line(index++).GetFloat(0);
			fov = Line(index++).GetFloat(0);
			near = Line(index++).GetFloat(0);
			far = Line(index++).GetFloat(0);
			CustomClear();
		}

		protected override void PrepareSerialize()
		{
			base.PrepareSerialize();
			Clear(rec: false);
			WriteVector3(p, oneline: false);
			WriteVector3(i, oneline: false);
			AddLiteral(roll);
			AddLiteral(fov);
			AddLiteral(near);
			AddLiteral(far);
		}
	}
}
