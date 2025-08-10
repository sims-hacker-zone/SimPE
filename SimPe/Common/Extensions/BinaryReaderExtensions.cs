// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SimPe.Common.Extensions;

public static class BinaryReaderExtensions
{
	public static string ReadUtf8CString(this BinaryReader reader)
	{
		List<byte> bytes = [];
		byte b;
		while ((b = reader.ReadByte()) != 0)
		{
			bytes.Add(b);
		}

		return Encoding.UTF8.GetString([.. bytes]);
	}
}
