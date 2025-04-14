// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Drawing;
using System.IO;
using Ambertation.Scenes;

namespace Ambertation.XSI.Template
{
	public sealed class Material : ArgumentContainer
	{
		public enum ShadingModels
		{
			Constant,
			Lambert,
			Phong,
			Blinn,
			ShadowObject,
			VertexColor
		}

		private TemplateCollection materials;

		private Color d;

		private Color s;

		private Color e;

		private Color a;

		private double p;

		private ShadingModels m;

		public TemplateCollection Textures => materials;

		public string MaterialName
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

		public ShadingModels ShadingModel
		{
			get
			{
				return m;
			}
			set
			{
				m = value;
			}
		}

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
				return p;
			}
			set
			{
				p = value;
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

		public Material(Container parent, string args)
			: base(parent, args)
		{
			materials = new TemplateCollection(this);
			Reset();
		}

		private void Reset()
		{
			materials.Clear(rec: false);
			d = Color.Silver;
			a = Color.Black;
			e = Color.Black;
			s = Color.White;
			p = 50.0;
			m = ShadingModels.Phong;
		}

		protected override void ResetArgs()
		{
			base.ResetArgs("DefaultLib.Scene_Material");
		}

		protected override void CustomClear()
		{
		}

		protected override void FinishDeSerialize()
		{
			base.FinishDeSerialize();
			Reset();
			int startline = 0;
			d = ReadColor(ref startline, inclalpha: true);
			p = Line(startline++).GetFloat(0);
			s = ReadColor(ref startline, inclalpha: false);
			e = ReadColor(ref startline, inclalpha: false);
			m = (ShadingModels)Line(startline++).GetFloat(0);
			a = ReadColor(ref startline, inclalpha: false);
			for (int i = startline; i < base.Count; i++)
			{
				materials.Add(base[i]);
			}

			CustomClear();
		}

		protected override void PrepareSerialize()
		{
			base.PrepareSerialize();
			Clear(rec: false);
			WriteColor(inclalpha: true, d);
			AddLiteral(p);
			WriteColor(inclalpha: false, s);
			WriteColor(inclalpha: false, e);
			AddLiteral((int)m);
			WriteColor(inclalpha: false, a);
			foreach (ITemplate material in materials)
			{
				Add(material);
			}
		}

		internal override void ToScene(Ambertation.Scenes.Scene scn)
		{
			Texture2D texture2D = base[typeof(Texture2D)] as Texture2D;
			Ambertation.Scenes.Material val = scn.CreateMaterial(MaterialName);
			val.Diffuse = Diffuse;
			val.Ambient = Ambient;
			val.Emmissive = Emmissive;
			val.Specular = Specular;
			val.SpecularPower = SpecularPower;
			if (texture2D != null)
			{
				string text = texture2D.ImageFileName;
				if (!File.Exists(text))
				{
					text = Path.GetFileName(text);
					text = Path.Combine(base.Owner.Folder, text);
				}

				if (!File.Exists(text))
				{
					text = Path.GetFileName(text);
					text = Path.Combine(Path.Combine(base.Owner.Folder, base.Owner.Caption), text);
				}

				if (!File.Exists(text))
				{
					text = Path.GetFileName(text);
					text = Path.Combine(Path.Combine(base.Owner.Folder, base.Owner.Caption + ".IMG"), text);
				}

				if (File.Exists(text))
				{
					val.Texture.FileName = text;
				}
			}
		}
	}
}
