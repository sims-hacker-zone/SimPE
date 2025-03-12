// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections;
using System.IO;

namespace Ambertation.XSI
{
	public interface ITemplate : IEnumerable
	{
		string Name { get; }

		void Serialize(StreamWriter sw, string indent);
	}
}
