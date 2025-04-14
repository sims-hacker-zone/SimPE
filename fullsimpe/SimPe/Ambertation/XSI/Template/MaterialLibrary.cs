// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace Ambertation.XSI.Template
{
	public sealed class MaterialLibrary : JoinedArgumentContainer
	{
		private TemplateCollection materials;

		public string SceneName
		{
			get
			{
				return base.JoinedArgument2;
			}
			set
			{
				base.JoinedArgument2 = value;
			}
		}

		public TemplateCollection Materials => materials;

		public MaterialLibrary(Container parent, string args)
			: base(parent, args)
		{
			materials = new TemplateCollection(this);
		}

		protected override void ResetArgs()
		{
			ResetArgs("MATLIB", "Scene");
		}

		protected override void CustomClear()
		{
		}

		protected override void FinishDeSerialize()
		{
			base.FinishDeSerialize();
			int num = (int)Line(0).GetFloat(0);
			for (int i = 0; i < num; i++)
			{
				materials.Add(base[i + 1]);
			}

			CustomClear();
		}

		protected override void PrepareSerialize()
		{
			base.PrepareSerialize();
			Clear(rec: false);
			AddLiteral(materials.Count);
			foreach (ITemplate material in materials)
			{
				Add(material);
			}
		}
	}
}
