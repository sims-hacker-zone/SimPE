// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Drawing;
using Ambertation.Geometry;

namespace Ambertation.XSI.Template
{
	public class ColorContainer : ExtendedContainer
	{
		public ColorContainer(Container parent, string args)
			: base(parent, args)
		{
		}

		protected Color ReadColor(ref int startline, bool inclalpha)
		{
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			Vector3 val = (Vector3)((!inclalpha) ? ((object)ReadVector3(ref startline)) : ((object)ReadVector4(ref startline)));
			int red = (int)(((Vector2)val).X * 255.0);
			int green = (int)(((Vector2)val).Y * 255.0);
			int blue = (int)(val.Z * 255.0);
			int alpha = 255;
			if (inclalpha)
			{
				alpha = (int)(((Vector4)val).W * 255.0);
			}

			return Color.FromArgb(alpha, red, green, blue);
		}

		protected void WriteColor(bool inclalpha, Color cl)
		{
			AddLiteral((float)(int)cl.R / 255f);
			AddLiteral((float)(int)cl.G / 255f);
			AddLiteral((float)(int)cl.B / 255f);
			if (inclalpha)
			{
				AddLiteral((float)(int)cl.A / 255f);
			}
		}
	}
}
