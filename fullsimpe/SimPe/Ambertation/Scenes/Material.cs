// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Drawing;

using Microsoft.DirectX.Direct3D;

namespace Ambertation.Scenes
{
	public class Material : IDisposable
	{
		public enum TextureModes
		{
			Default,
			ShadowTexture,
			Material,
			MaterialWithAlpha,
			MaterialWithTexture
		}

		private Texture txt;

		private Color d;

		private Color s;

		private Color e;

		private Color a;

		private double sp;

		private string name;

		private TextureModes blend;

		private object tag;

		public TextureModes Mode
		{
			get
			{
				return blend;
			}
			set
			{
				blend = value;
			}
		}

		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}

		public Texture Texture => txt;

		public Color Diffuse
		{
			get
			{
				return d;
			}
			set
			{
				d = value;
			}
		}

		public Color Specular
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

		public double SpecularPower
		{
			get
			{
				return sp;
			}
			set
			{
				sp = value;
			}
		}

		public Color Ambient
		{
			get
			{
				return a;
			}
			set
			{
				a = value;
			}
		}

		public Color Emmissive
		{
			get
			{
				return e;
			}
			set
			{
				e = value;
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

		internal Material(string name)
		{
			this.name = name;
			blend = TextureModes.Default;
			txt = new Texture(null, new Size(0, 0));
			d = Color.Silver;
			s = Color.White;
			e = Color.Black;
			a = Color.FromArgb(16, 16, 16);
			sp = 50.0;
		}

		public override string ToString()
		{
			return Name + " [" + GetType().Name + "]";
		}

		public void Dispose()
		{
			if (txt != null)
			{
				txt.Dispose();
			}

			txt = null;
			name = null;
		}
	}
}
