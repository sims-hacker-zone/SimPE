// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using Ambertation.Geometry;
using Ambertation.Geometry.Collections;

namespace Ambertation.XSI.Template
{
	public sealed class TriangleList : ShapeBase
	{
		private string mat;

		public string PrimitiveName
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

		public Vector3iCollection Vertices => (Vector3iCollection)GetElementList(ElementTypes.POSITION);

		public Vector3iCollection Normals => (Vector3iCollection)GetElementList(ElementTypes.NORMAL);

		public Vector3iCollection Colors => (Vector3iCollection)GetElementList(ElementTypes.COLOR);

		public Vector3iCollection TextureCoords => (Vector3iCollection)GetElementList(ElementTypes.TEX_COORD_UV);

		public Vector3iCollection TextureCoords1 => (Vector3iCollection)GetElementList(ElementTypes.TEX_COORD_UV1);

		public Vector3iCollection TextureCoords2 => (Vector3iCollection)GetElementList(ElementTypes.TEX_COORD_UV2);

		public Vector3iCollection TextureCoords3 => (Vector3iCollection)GetElementList(ElementTypes.TEX_COORD_UV3);

		public Vector3iCollection TextureCoords0 => (Vector3iCollection)GetElementList(ElementTypes.TEX_COORD_UV0);

		public string MaterialName
		{
			get
			{
				return mat;
			}
			set
			{
				mat = value;
				if (mat == null)
				{
					mat = "";
				}
			}
		}

		public TriangleList(Container parent, string args)
			: base(parent, args)
		{
			mat = "";
		}

		protected override void ResetArgs()
		{
			ResetArgs("mesh");
		}

		protected override IElementCollection CreateElementList(ElementTypes t)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Expected O, but got Unknown
			return (IElementCollection)new Vector3iCollection();
		}

		private void ReadElement(ref int index, ElementTypes t, int types, int ct)
		{
			if (((uint)t & (uint)types) == (uint)t)
			{
				IElementCollection elementList = GetElementList(t);
				for (int i = 0; i < ct; i++)
				{
					Vector3i val = ReadVector3i(ref index);
					elementList.Add((object)val);
				}
			}
		}

		private void WriteTypeString(ElementTypes t, int types, ref string ts)
		{
			if (((uint)t & (uint)types) == (uint)t)
			{
				if (ts != "")
				{
					ts += "|";
				}

				ts += t;
			}
		}

		private void WriteElement(ElementTypes t, int types, int parts)
		{
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Expected O, but got Unknown
			if (((uint)t & (uint)types) != (uint)t)
			{
				return;
			}

			IElementCollection elementList = GetElementList(t);
			for (int i = 0; i < parts; i++)
			{
				if (i < elementList.Count)
				{
					WriteVector3i((Vector3i)elementList.GetItem(i), oneline: true);
				}
				else
				{
					WriteVector3i(Vector3i.Zero, oneline: true);
				}
			}
		}

		protected override void FinishDeSerialize()
		{
			base.FinishDeSerialize();
			Reset();
			int index = 0;
			int ct = (int)Line(index++).GetFloat(0);
			int types = EnumSetValue(index++, typeof(ElementTypes)) | 1;
			mat = Line(index++).StripQuotes();
			ReadElement(ref index, ElementTypes.POSITION, types, ct);
			ReadElement(ref index, ElementTypes.NORMAL, types, ct);
			ReadElement(ref index, ElementTypes.COLOR, types, ct);
			ReadElement(ref index, ElementTypes.TEX_COORD_UV, types, ct);
			ReadElement(ref index, ElementTypes.TEX_COORD_UV0, types, ct);
			ReadElement(ref index, ElementTypes.TEX_COORD_UV1, types, ct);
			ReadElement(ref index, ElementTypes.TEX_COORD_UV2, types, ct);
			ReadElement(ref index, ElementTypes.TEX_COORD_UV3, types, ct);
			CustomClear();
		}

		protected override void PrepareSerialize()
		{
			base.PrepareSerialize();
			if (base.Owner.Header.Version < 196688)
			{
				if (TextureCoords.Count == 0 && TextureCoords0.Count >= 0)
				{
					TextureCoords0.CopyTo(TextureCoords, false);
				}

				TextureCoords0.Clear();
				TextureCoords1.Clear();
				TextureCoords2.Clear();
				TextureCoords3.Clear();
			}

			Clear(rec: false);
			int num = 0;
			int count = Vertices.Count;
			Array values = Enum.GetValues(typeof(ElementTypes));
			foreach (ElementTypes item in values)
			{
				IElementCollection elementList = GetElementList(item);
				if (elementList.Count > 0 || item == ElementTypes.POSITION)
				{
					num = (int)(num + item);
				}
			}

			AddLiteral(count);
			string ts = "";
			WriteTypeString(ElementTypes.NORMAL, num, ref ts);
			WriteTypeString(ElementTypes.COLOR, num, ref ts);
			WriteTypeString(ElementTypes.TEX_COORD_UV, num, ref ts);
			WriteTypeString(ElementTypes.TEX_COORD_UV0, num, ref ts);
			WriteTypeString(ElementTypes.TEX_COORD_UV1, num, ref ts);
			WriteTypeString(ElementTypes.TEX_COORD_UV2, num, ref ts);
			WriteTypeString(ElementTypes.TEX_COORD_UV3, num, ref ts);
			AddLiteral("\"" + ts + "\"");
			AddLiteral("\"" + mat.Trim() + "\"");
			WriteElement(ElementTypes.POSITION, num, count);
			WriteElement(ElementTypes.NORMAL, num, count);
			WriteElement(ElementTypes.COLOR, num, count);
			WriteElement(ElementTypes.TEX_COORD_UV, num, count);
			WriteElement(ElementTypes.TEX_COORD_UV0, num, count);
			WriteElement(ElementTypes.TEX_COORD_UV1, num, count);
			WriteElement(ElementTypes.TEX_COORD_UV2, num, count);
			WriteElement(ElementTypes.TEX_COORD_UV3, num, count);
		}
	}
}
