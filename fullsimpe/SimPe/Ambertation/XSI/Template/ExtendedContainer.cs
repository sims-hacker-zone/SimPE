// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using Ambertation.Geometry;

namespace Ambertation.XSI.Template
{
	public class ExtendedContainer : Container
	{
		internal ExtendedContainer(Container parent, string args)
			: base(parent, args)
		{
		}

		protected override void CustomClear()
		{
		}

		protected Vector2 ReadVector2(ref int index)
		{
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0015: Expected O, but got Unknown
			double[] array = ReadFloatSequence(ref index, 2);
			return new Vector2(array[0], array[1]);
		}

		protected Vector3 ReadVector3(ref int index)
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Expected O, but got Unknown
			double[] array = ReadFloatSequence(ref index, 3);
			return new Vector3(array[0], array[1], array[2]);
		}

		protected Vector3i ReadVector3i(ref int index)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Expected O, but got Unknown
			double[] array = ReadFloatSequence(ref index, 3);
			return new Vector3i((int)array[0], (int)array[1], (int)array[2]);
		}

		protected Vector4 ReadVector4(ref int index)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Expected O, but got Unknown
			double[] array = ReadFloatSequence(ref index, 4);
			return new Vector4(array[0], array[1], array[2], array[3]);
		}

		protected double[] ReadFloatSequence(ref int index, int ct)
		{
			double[] array = new double[ct];
			while (ct > 0)
			{
				double[] floats = Line(index).Floats;
				index++;
				int val = ct;
				for (int i = 0; i < Math.Min(val, floats.Length); i++)
				{
					array[array.Length - ct] = floats[i];
					ct--;
				}
			}

			return array;
		}

		protected void WriteVector2(IndexedWeight v, bool oneline)
		{
			AddLiteral(v.Index + "," + Literal.FloatToString(v.Weight * 100.0));
		}

		protected void WriteVector2(Vector2 v, bool oneline)
		{
			WriteFloatSequence(new double[2] { v.X, v.Y }, oneline, asint: false);
		}

		protected void WriteVector3(Vector3 v, bool oneline)
		{
			WriteFloatSequence(new double[3]
			{
			((Vector2)v).X,
			((Vector2)v).Y,
			v.Z
			}, oneline, asint: false);
		}

		protected void WriteVector3i(Vector3i v, bool oneline)
		{
			WriteFloatSequence(new double[3] { v.X, v.Y, v.Z }, oneline, asint: true);
		}

		protected void WriteVector4(Vector4 v, bool oneline)
		{
			WriteFloatSequence(new double[4]
			{
			((Vector2)v).X,
			((Vector2)v).Y,
			((Vector3)v).Z,
			v.W
			}, oneline, asint: false);
		}

		protected void WriteFloatSequence(double[] floats, bool oneline, bool asint)
		{
			if (oneline)
			{
				string text = "";
				for (int i = 0; i < floats.Length; i++)
				{
					if (i > 0)
					{
						text += ",";
					}

					text = (asint ? (text + (int)floats[i]) : (text + Literal.FloatToString(floats[i])));
				}

				AddLiteral(text);
			}
			else
			{
				foreach (double f in floats)
				{
					AddLiteral(f);
				}
			}
		}

		protected object EnumValue(int index, Type enumtype)
		{
			string val = Line(index).StripQuotes();
			return EnumValue(enumtype, val);
		}

		protected static object EnumValue(Type enumtype, string val)
		{
			try
			{
				return Enum.Parse(enumtype, val);
			}
			catch
			{
			}

			Array values = Enum.GetValues(enumtype);
			return values.GetValue(0);
		}

		protected object[] EnumValues(int index, Type enumtype)
		{
			string text = Line(index).StripQuotes();
			string[] array = text.Split('|');
			object[] array2 = new object[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = EnumValue(enumtype, array[i]);
			}

			return array2;
		}

		protected int EnumSetValue(int index, Type enumtype)
		{
			object[] array = EnumValues(index, enumtype);
			int num = 0;
			object[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				int num2 = (int)array2[i];
				num |= num2;
			}

			return num;
		}

		protected Transform FindTransform(Container src, Transform.Types ty)
		{
			int item = src.GetItem(typeof(Transform), 0);
			Transform result = null;
			while (item > -1)
			{
				Transform transform = src[item] as Transform;
				if (transform.Type == ty)
				{
					result = transform;
				}

				item = src.GetItem(typeof(Transform), item + 1);
			}

			return result;
		}
	}
}
