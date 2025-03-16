// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.Generic;
using System.IO;

using SimPe.Models.Interfaces;
using SimPe.Models.PackedFile;
using SimPe.Models.PackedFile.Clst;
using SimPe.Models.PackedFile.Idno;

namespace SimPe.Data
{
	public static class Wrappers
	{
		public static Dictionary<FileTypes, Func<BinaryReader, PackedFile, IWrapper>> Unserializers
		{
			get;
		} = new()
		{
			[FileTypes.CLST] = Clst.Unserialize,
			[FileTypes.IDNO] = Idno.Unserialize
		};
	}
}
