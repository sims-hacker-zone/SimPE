// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections;
using Ambertation.Geometry;
using Ambertation.Geometry.Collections;

using SimPe.Plugin;

namespace Ambertation.XSI.Template
{
	public sealed class Shape : ShapeBase
	{
		private string matn;

		public string MaterialName
		{
			get
			{
				return matn;
			}
			set
			{
				matn = value;
				if (matn == null)
				{
					matn = "";
				}
			}
		}

		public string PrimitiveName
		{
			get
			{
				return base.Argument1.Replace("SHP-", "").Replace("-ORG", "");
			}
			set
			{
				base.Argument1 = "SHP-" + value + "-ORG";
			}
		}

		public Vector3Collection Vertices => (Vector3Collection)GetElementList(ElementTypes.POSITION);

		public Vector3Collection Normals => (Vector3Collection)GetElementList(ElementTypes.NORMAL);

		public Vector4Collection Colors => (Vector4Collection)GetElementList(ElementTypes.COLOR);

		public Vector2Collection TextureCoords => (Vector2Collection)GetElementList(ElementTypes.TEX_COORD_UV);

		public Vector2Collection TextureCoords1 => (Vector2Collection)GetElementList(ElementTypes.TEX_COORD_UV1);

		public Vector2Collection TextureCoords2 => (Vector2Collection)GetElementList(ElementTypes.TEX_COORD_UV2);

		public Vector2Collection TextureCoords3 => (Vector2Collection)GetElementList(ElementTypes.TEX_COORD_UV3);

		public Vector2Collection TextureCoords0 => (Vector2Collection)GetElementList(ElementTypes.TEX_COORD_UV0);

		public Shape(Container parent, string args)
			: base(parent, args)
		{
			matn = "";
		}

		protected override void ResetArgs()
		{
			ResetArgs("SHP-mesh-ORG");
		}

		private void ReadElementOrdered(ref int index, ElementTypes t, IElementCollection list)
		{
			object obj;
			switch (t)
			{
				case ElementTypes.POSITION:
				case ElementTypes.NORMAL:
					obj = ReadVector3(ref index);
					break;
				case ElementTypes.COLOR:
					obj = ReadVector4(ref index);
					break;
				default:
					obj = ReadVector2(ref index);
					break;
			}

			list.Add(obj);
		}

		private void ReadElementIndexed(ref int index, ElementTypes t, IElementCollection list)
		{
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Expected O, but got Unknown
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Expected O, but got Unknown
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Expected O, but got Unknown
			int ct;
			switch (t)
			{
				case ElementTypes.POSITION:
				case ElementTypes.NORMAL:
					ct = 4;
					break;
				case ElementTypes.COLOR:
					ct = 5;
					break;
				default:
					ct = 3;
					break;
			}

			double[] array = ReadFloatSequence(ref index, ct);
			object zero;
			switch (t)
			{
				case ElementTypes.POSITION:
				case ElementTypes.NORMAL:
					zero = Vector3.Zero;
					break;
				case ElementTypes.COLOR:
					zero = Vector3.Zero;
					break;
				default:
					zero = Vector3.Zero;
					break;
			}

			while (list.Count <= (int)array[0])
			{
				list.Add(zero);
			}

			object obj;
			switch (t)
			{
				case ElementTypes.POSITION:
				case ElementTypes.NORMAL:
					obj = (object)new Vector3(array[1], array[2], array[3]);
					break;
				case ElementTypes.COLOR:
					obj = (object)new Vector4(array[1], array[2], array[3], array[4]);
					break;
				default:
					obj = (object)new Vector2(array[1], array[2]);
					break;
			}

			list.SetItem((int)array[0], obj);
		}

		private void ReadElementArray(ref int index, Layouts l)
		{
			int num = (int)Line(index++).GetFloat(0);
			ElementTypes elementTypes = (ElementTypes)EnumValue(index++, typeof(ElementTypes));
			IElementCollection elementList = GetElementList(elementTypes);
			if (IsNewTexture(elementTypes))
			{
				matn = Line(index++).StripQuotes();
			}

			if (l == Layouts.ORDERED)
			{
				for (int i = 0; i < num; i++)
				{
					ReadElementOrdered(ref index, elementTypes, elementList);
				}
			}
			else
			{
				for (int j = 0; j < num; j++)
				{
					ReadElementIndexed(ref index, elementTypes, elementList);
				}
			}

			map[elementTypes.ToString()] = elementList;
		}

		protected override void FinishDeSerialize()
		{
			base.FinishDeSerialize();
			Reset();
			int index = 0;
			int num = (int)Line(index++).GetFloat(0);
			Layouts l = (Layouts)EnumValue(index++, typeof(Layouts));
			for (int i = 0; i < num; i++)
			{
				ReadElementArray(ref index, l);
			}

			CustomClear();
		}

		protected override void PrepareSerialize()
		{
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_018a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0191: Expected O, but got Unknown
			//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01da: Expected O, but got Unknown
			//IL_0229: Unknown result type (might be due to invalid IL or missing references)
			//IL_0230: Expected O, but got Unknown
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

			int num = 0;
			foreach (string key in map.Keys)
			{
				if (((IElementCollection)map[key]).Count > 0)
				{
					num++;
				}
			}

			Clear(rec: false);
			AddLiteral(num);
			AddLiteral("\"" + Layouts.ORDERED.ToString() + "\"");
			Array values = Enum.GetValues(typeof(ElementTypes));
			foreach (ElementTypes item in values)
			{
				IElementCollection elementList = GetElementList(item);
				if (elementList.Count == 0)
				{
					continue;
				}

				AddLiteral(elementList.Count);
				AddLiteral("\"" + item.ToString() + "\"");
				switch (item)
				{
					case ElementTypes.POSITION:
					case ElementTypes.NORMAL:
						foreach (Vector3 item2 in (IEnumerable)elementList)
						{
							Vector3 v = item2;
							WriteVector3(v, oneline: true);
						}

						continue;
					case ElementTypes.COLOR:
						foreach (Vector4 item3 in (IEnumerable)elementList)
						{
							Vector4 v2 = item3;
							WriteVector4(v2, oneline: true);
						}

						continue;
				}

				if (IsNewTexture(item))
				{
					AddQuotedLiteral(matn);
				}

				foreach (Vector2 item4 in (IEnumerable)elementList)
				{
					Vector2 v3 = item4;
					WriteVector2(v3, oneline: true);
				}
			}
		}

		private static bool IsNewTexture(ElementTypes e)
		{
			if (e != ElementTypes.TEX_COORD_UV0 && e != ElementTypes.TEX_COORD_UV1 && e != ElementTypes.TEX_COORD_UV2)
			{
				return e == ElementTypes.TEX_COORD_UV3;
			}

			return true;
		}
	}
}
