// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using Ambertation.Scenes;
using Ambertation.XSI.IO;

namespace Ambertation.XSI.Template
{
	public class Container : TemplateCollection, IDisposable, ITemplate, IEnumerable
	{
		protected const bool CLEARLINES = false;

		private string name;

		private string[] args;

		private Ambertation.XSI.IO.File owner;

		[Browsable(false)]
		public Ambertation.XSI.IO.File Owner => owner;

		[Category("Basic")]
		public string Name => name;

		[Category("Basic")]
		public string[] Arguments => args;

		public Container(Container parent, string args)
			: this(parent.Owner, parent, args)
		{
		}

		internal Container(Ambertation.XSI.IO.File Owner, Container parent, string args)
			: base(parent)
		{
			owner = Owner;
			base.parent = parent;
			InitArguments(args);
		}

		private void InitArguments(string args)
		{
			args = Helpers.RemoveDoubleSpaces(args);
			string[] array = args.Split(" ".ToCharArray());
			if (array.Length == 0)
			{
				name = "";
				SetArguments(new string[0]);
				return;
			}

			if (array.Length == 1)
			{
				name = array[0];
				SetArguments(new string[0]);
				return;
			}

			name = array[0];
			string[] array2 = new string[array.Length - 1];
			for (int i = 1; i < array.Length; i++)
			{
				array2[i - 1] = array[i];
			}

			SetArguments(array2);
		}

		protected Literal Line(int index)
		{
			if (index < 0 || index >= base.Count)
			{
				return new Literal("");
			}

			ITemplate template = base[index];
			if (template is Literal)
			{
				return (Literal)template;
			}

			return new Literal("");
		}

		protected virtual void PrepareSerialize()
		{
		}

		protected virtual void FinishDeSerialize()
		{
		}

		private string ExtractName(string nameline)
		{
			int num = nameline.IndexOf("{");
			if (num > 0)
			{
				nameline = nameline.Substring(0, num);
			}

			return nameline;
		}

		protected void AddLiteral(double f)
		{
			Literal pd = new Literal(f);
			Add(pd);
		}

		protected void AddLiteral(bool b)
		{
			if (b)
			{
				AddLiteral(1);
			}
			else
			{
				AddLiteral(0);
			}
		}

		protected void AddLiteral(int i)
		{
			Literal pd = new Literal(i);
			Add(pd);
		}

		protected void AddLiteral(int[] ints)
		{
			Literal pd = new Literal(ints);
			Add(pd);
		}

		protected void AddLiteral(double[] floats)
		{
			Literal pd = new Literal(floats);
			Add(pd);
		}

		protected void AddQuotedLiteral(string line)
		{
			AddLiteral("\"" + line.Trim() + "\"");
		}

		protected void AddLiteral(string line)
		{
			line = line.Trim();
			if (!(line == ""))
			{
				Literal pd = new Literal(line);
				Add(pd);
			}
		}

		private void AddLines(string[] lines, int first, int last)
		{
			for (int i = first; i <= last; i++)
			{
				AddLiteral(lines[i]);
			}
		}

		protected int DeSerializeLines(string[] lines, int start)
		{
			int num = 0;
			int first = start;
			try
			{
				for (int i = start; i < lines.Length - 1; i++)
				{
					string text = lines[i];
					if (text.IndexOf("SI_") >= 0)
					{
						num = i;
					}

					if (text.IndexOf("XSI_") >= 0)
					{
						num = i;
					}

					int num2 = text.IndexOf("}");
					if (num2 >= 0)
					{
						string line = text.Substring(0, num2).Trim();
						AddLines(lines, first, i - 1);
						AddLiteral(line);
						lines[i] = text.Substring(num2 + 1).Trim();
						return i;
					}

					int num3 = text.IndexOf("{");
					if (num3 >= 0)
					{
						string text2 = "";
						for (int j = num; j <= i; j++)
						{
							text2 = text2 + lines[j] + " ";
						}

						lines[i] = text.Substring(num3 + 1).Trim();
						AddLines(lines, first, num - 1);
						i = CreateFromLines(ExtractName(text2), lines, i) - 1;
						first = i + 1;
					}
					else
					{
						_ = text != "";
						lines[i] = text;
					}
				}

				AddLines(lines, first, lines.Length - 1);
			}
			finally
			{
				FinishDeSerialize();
			}

			return lines.Length - 1;
		}

		private int CreateFromLines(string name, string[] lines, int start)
		{
			Container container = CreateChild(name);
			return container.DeSerializeLines(lines, start);
		}

		public virtual void Serialize(StreamWriter sw, string indent)
		{
			PrepareSerialize();
			sw.Write(indent + name + " ");
			string[] array = args;
			foreach (string text in array)
			{
				sw.Write(text + " ");
			}

			sw.WriteLine("{");
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					ITemplate template = (ITemplate)enumerator.Current;
					template.Serialize(sw, indent + "\t");
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}

			sw.WriteLine(indent + "}");
			sw.WriteLine();
			CustomClear();
		}

		internal virtual void ToScene(Ambertation.Scenes.Scene scn)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					ITemplate template = (ITemplate)enumerator.Current;
					if (template is Container)
					{
						((Container)template).ToScene(scn);
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}

		protected void SetArguments(string[] args)
		{
			this.args = args;
		}

		public string GetArgument(int i)
		{
			if (i < 0 || i >= args.Length)
			{
				return "";
			}

			return args[i];
		}

		public void SetArgument(int i, string s)
		{
			if (i >= 0 && i < args.Length)
			{
				args[i] = s;
			}
		}

		protected virtual void CustomClear()
		{
		}

		public override string ToString()
		{
			string text = name + ":";
			string[] array = args;
			foreach (string text2 in array)
			{
				text = text + " " + text2;
			}

			return text + " [" + GetType().Name + "]";
		}

		public override Container CreateChild(string name)
		{
			ITemplate template = TemplateRegistry.Global.ActivateTemplateClass(this, name);
			if (template != null)
			{
				Add(template);
			}

			return template as Container;
		}
	}
}
