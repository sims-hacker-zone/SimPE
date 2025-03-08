// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace Ambertation.XSI.Template
{
	public sealed class GlobalMaterial : ExtendedContainer
	{
		public enum Propagations
		{
			BRANCH,
			NODE,
			INHERITED
		}

		private string refname;

		private Propagations p;

		public string ReferencedMaterialName
		{
			get
			{
				return refname;
			}
			set
			{
				refname = value;
				if (refname == null)
				{
					refname = "";
				}
			}
		}

		public Propagations Propagation
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

		public GlobalMaterial(Container parent, string args)
			: base(parent, args)
		{
			refname = "DefaultLib.Scene_Material";
			p = Propagations.BRANCH;
		}

		protected override void FinishDeSerialize()
		{
			base.FinishDeSerialize();
			refname = Line(0).StripQuotes();
			Line(1).StripQuotes();
			p = (Propagations)EnumValue(1, typeof(Propagations));
			CustomClear();
		}

		protected override void PrepareSerialize()
		{
			base.PrepareSerialize();
			Clear(rec: false);
			AddLiteral("\"" + refname.Trim() + "\"");
			AddLiteral("\"" + p.ToString() + "\"");
		}
	}
}
