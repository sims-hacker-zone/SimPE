// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.IO;

namespace Ambertation.XSI.Template
{
	public sealed class Literal : ITemplate, IEnumerable, IDisposable
	{
		private string val;

		private double[] flt;

		[Category("Basic")]
		public string Name => val;

		[ReadOnly(true)]
		[Category("Basic")]
		public double[] Floats
		{
			get
			{
				SetFloats();
				return flt;
			}
		}

		public Literal(string val)
		{
			val = val.Trim();
			if (val.EndsWith(","))
			{
				val = val.Substring(0, val.Length - 1).Trim();
			}

			this.val = val;
			flt = null;
		}

		public Literal(double f)
			: this(new double[1] { f })
		{
		}

		public Literal(double[] floats)
		{
			string text = "";
			for (int i = 0; i < floats.Length; i++)
			{
				if (i > 0)
				{
					text += ",";
				}

				text += FloatToString(floats[i]);
			}

			val = text;
			flt = floats;
		}

		public Literal(int i)
			: this(new int[1] { i })
		{
		}

		public Literal(int[] ints)
		{
			string text = "";
			for (int i = 0; i < ints.Length; i++)
			{
				if (i > 0)
				{
					text += ",";
				}

				text += ints[i];
			}

			val = text;
		}

		public static string FloatToString(double d)
		{
			return d.ToString("N6", CultureInfo.InvariantCulture).Replace(",", "");
		}

		private void SetFloats()
		{
			if (flt == null)
			{
				flt = GetFloats();
			}
		}

		public int GetInt(int index)
		{
			return (int)GetFloat(index);
		}

		public double GetFloat(int index)
		{
			SetFloats();
			if (index < 0 || index >= flt.Length)
			{
				return 0.0;
			}

			return flt[index];
		}

		private double[] GetFloats()
		{
			string[] array = Name.Split(',');
			ArrayList arrayList = new ArrayList();
			string[] array2 = array;
			foreach (string value in array2)
			{
				try
				{
					double num = Convert.ToDouble(value, CultureInfo.InvariantCulture);
					arrayList.Add(num);
				}
				catch
				{
				}
			}

			double[] array3 = new double[arrayList.Count];
			arrayList.CopyTo(array3);
			return array3;
		}

		public string StripQuotes()
		{
			string text = val.Trim();
			if (text.StartsWith("\"") && text.EndsWith("\""))
			{
				text = text.Substring(1, text.Length - 2);
			}

			return text;
		}

		public void Dispose()
		{
			val = null;
		}

		public IEnumerator GetEnumerator()
		{
			byte[] array = new byte[0];
			return array.GetEnumerator();
		}

		public void Serialize(StreamWriter sw, string indent)
		{
			sw.WriteLine(indent + val + ",");
		}

		public override string ToString()
		{
			return val;
		}
	}
}
