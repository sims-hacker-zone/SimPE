// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace Ambertation.XSI.Template
{
	public class ArgumentContainer : ColorContainer
	{
		protected string Argument1
		{
			get
			{
				return GetArgument(0);
			}
			set
			{
				ResetArgs();
				string text = value;
				if (text == null)
				{
					text = "";
				}

				SetArgument(0, text);
			}
		}

		internal ArgumentContainer(Container parent, string args)
			: base(parent, args)
		{
			ResetArgs();
		}

		protected virtual void ResetArgs()
		{
			ResetArgs("");
		}

		protected virtual void ResetArgs(string def)
		{
			if (base.Arguments.Length < 1)
			{
				SetArguments(new string[1] { def });
			}
		}
	}
}
