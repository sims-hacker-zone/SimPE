// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using Ambertation.Collections;
using Ambertation.Geometry;
using Ambertation.Geometry.Collections;
using Ambertation.Scenes;

namespace Ambertation.XSI.Template
{
	public sealed class Envelope : ExtendedContainer
	{
		private string e;

		private string d;

		private IndexedWeightCollection list;

		public string EnvelopModel
		{
			get
			{
				return e.Replace("MDL-", "");
			}
			set
			{
				e = "MDL-" + value;
			}
		}

		public string Deformer
		{
			get
			{
				return d.Replace("MDL-", "");
			}
			set
			{
				d = "MDL-" + value;
			}
		}

		public IndexedWeightCollection Weights => list;

		public Envelope(Container parent, string args)
			: base(parent, args)
		{
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Expected O, but got Unknown
			list = new IndexedWeightCollection();
			Reset();
		}

		private void Reset()
		{
			e = "";
			d = "";
			list.Clear();
		}

		protected override void FinishDeSerialize()
		{
			base.FinishDeSerialize();
			int index = 0;
			e = Line(index++).StripQuotes();
			d = Line(index++).StripQuotes();
			int num = (int)Line(index++).GetFloat(0);
			for (int i = 0; i < num; i++)
			{
				Vector2 val = ReadVector2(ref index);
				val.Y /= 100.0;
				list.Add(val);
			}

			CustomClear();
		}

		protected override void PrepareSerialize()
		{
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Expected O, but got Unknown
			base.PrepareSerialize();
			Clear(rec: false);
			AddQuotedLiteral(e);
			AddQuotedLiteral(d);
			AddLiteral(list.Count);
			foreach (IndexedWeight item in list)
			{
				IndexedWeight v = item;
				WriteVector2(v, oneline: true);
			}
		}

		internal override void ToScene(Ambertation.Scenes.Scene scn)
		{
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Expected O, but got Unknown
			Joint val = scn.RootJoint.FindJoint(Deformer);
			Ambertation.Scenes.Mesh val2 = scn.SceneRoot.FindMesh(EnvelopModel);
			if (val == null || val2 == null)
			{
				return;
			}

			Ambertation.Scenes.Envelope jointEnvelope = val2.GetJointEnvelope(val, val2.Vertices.Count);
			foreach (IndexedWeight weight in Weights)
			{
				IndexedWeight val3 = weight;
				IntCollection val4 = val2.MappedIndices(val3.Index);
				foreach (int item in val4)
				{
					if (item < jointEnvelope.Weights.Count)
					{
						jointEnvelope.Weights[item] = val3.Weight;
					}
				}
			}
		}
	}
}
