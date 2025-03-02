// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using Ambertation.Collections;

namespace Ambertation.XSI.Template
{
	public sealed class Cluster : ArgumentContainer
	{
		public enum Weightings
		{
			AVERAGE,
			ADDITIVE
		}

		private Weightings w;

		private string mref;

		private string ccref;

		private IntCollection indices;

		public string ClusterName
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

		public IntCollection Indices => indices;

		public Weightings Weighting
		{
			get
			{
				return w;
			}
			set
			{
				w = value;
			}
		}

		public string ReferencedModelName
		{
			get
			{
				return mref;
			}
			set
			{
				mref = value;
				if (mref == null)
				{
					mref = "";
				}
			}
		}

		public string ClusterCenterReference
		{
			get
			{
				return ccref;
			}
			set
			{
				ccref = value;
				if (ccref == null)
				{
					ccref = "";
				}
			}
		}

		public Cluster(Container parent, string args)
			: base(parent, args)
		{
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Expected O, but got Unknown
			indices = new IntCollection();
			w = Weightings.AVERAGE;
			Reset();
		}

		protected override void ResetArgs()
		{
			base.ResetArgs("Point_AUTO");
		}

		private void Reset()
		{
			indices.Clear();
			mref = "";
			ccref = "";
		}

		protected override void FinishDeSerialize()
		{
			base.FinishDeSerialize();
			Reset();
			int num = 0;
			mref = Line(num++).StripQuotes();
			w = (Weightings)EnumValue(num++, typeof(Weightings));
			ccref = Line(num++).StripQuotes();
			int num2 = (int)Line(num++).GetFloat(0);
			for (int i = 0; i < num2; i++)
			{
				indices.Add((int)Line(num++).GetFloat(0));
			}

			CustomClear();
		}

		protected override void PrepareSerialize()
		{
			base.PrepareSerialize();
			Clear(rec: false);
			AddQuotedLiteral(mref);
			AddQuotedLiteral(w.ToString());
			AddQuotedLiteral(ccref);
			AddLiteral(indices.Count);
			foreach (int index in indices)
			{
				AddLiteral(index);
			}
		}
	}
}
