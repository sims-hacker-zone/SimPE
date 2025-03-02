// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace Ambertation.XSI.Template
{
	public class JoinedArgumentContainer : ArgumentContainer
	{
		protected string JoinedArgument1
		{
			get
			{
				return SplitArgument()[0];
			}
			set
			{
				ResetArgs();
				CombineArgument(value, JoinedArgument2);
			}
		}

		protected string JoinedArgument2
		{
			get
			{
				return SplitArgument()[1];
			}
			set
			{
				ResetArgs();
				CombineArgument(JoinedArgument1, value);
			}
		}

		internal JoinedArgumentContainer(Container parent, string args)
			: base(parent, args)
		{
			ResetArgs();
		}

		protected string[] SplitArgument()
		{
			return SplitArgument(GetArgument(0));
		}

		protected string[] SplitArgument(string s)
		{
			string[] array = s.Split(new char[1] { '-' }, 2);
			if (array.Length >= 2)
			{
				return array;
			}

			string[] array2 = new string[2] { "", "" };
			if (array.Length > 0)
			{
				array2[0] = array[0];
			}

			if (array.Length > 1)
			{
				array2[1] = array[1];
			}

			return array2;
		}

		protected override void ResetArgs()
		{
			ResetArgs("", "");
		}

		protected virtual void ResetArgs(string val1, string val2)
		{
			if (base.Arguments.Length < 1)
			{
				SetArguments(new string[1] { val1 + "-" + val2 });
			}
		}

		protected void CombineArgument(string val1, string val2)
		{
			CombineArgument(0, val1, val2);
		}

		protected void CombineArgument(int index, string val1, string val2)
		{
			SetArgument(index, val1 + "-" + val2);
		}
	}
}
