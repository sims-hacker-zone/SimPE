// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

namespace Ambertation.SevenZip.Exceptions
{
	public class SevenZipException : Exception
	{
		public SevenZipException(string message)
			: this(message, null)
		{
		}

		public SevenZipException(Exception inner)
			: this(inner.Message, inner)
		{
		}

		public SevenZipException(string message, Exception inner)
			: base(message, inner)
		{
			Console.WriteLine("Exception: " + ToString());
		}
	}
}
