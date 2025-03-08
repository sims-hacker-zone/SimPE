// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections;
using System.IO;
using Ambertation.XSI.Template;

namespace Ambertation.XSI.IO
{
	public abstract class File
	{
		protected Header header;

		internal Stack meshstack = new Stack();

		internal Header Header => header;

		public abstract Container Root { get; }

		public abstract string FileName { get; }

		internal string Folder => Path.GetDirectoryName(FileName);

		internal string Caption => Path.GetFileNameWithoutExtension(FileName);
	}
}
