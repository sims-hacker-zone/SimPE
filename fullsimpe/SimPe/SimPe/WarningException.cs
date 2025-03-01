// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

namespace SimPe
{
	/// <summary>
	/// An Exception that is interpreted as Warning
	/// </summary>
	public class Warning : Exception
	{
		string details;
		public string Details => details ?? "";

		public Warning(string message, string details)
			: base(message)
		{
			this.details = details;
		}

		public Warning(string message, string details, Exception inner)
			: base(message, inner)
		{
			this.details = details;
		}
	}
}
