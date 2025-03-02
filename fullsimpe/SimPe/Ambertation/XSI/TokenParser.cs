// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections;
using System.IO;
using Ambertation.XSI.IO;
using Ambertation.XSI.Template;

namespace Ambertation.XSI
{
	internal sealed class TokenParser : Container
	{
		public TokenParser(Ambertation.XSI.IO.File owner, string[] lines)
			: base(owner, null, "[ROOT]")
		{
			DeSerializeLines(lines, 1);
		}

		public override void Serialize(StreamWriter sw, string indent)
		{
			PrepareSerialize();
			sw.WriteLine();
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					ITemplate template = (ITemplate)enumerator.Current;
					template.Serialize(sw, "");
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

			sw.WriteLine();
		}
	}
}
