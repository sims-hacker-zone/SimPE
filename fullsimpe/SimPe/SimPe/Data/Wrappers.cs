// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.Generic;
using System.IO;

using SimPe.Models.Interfaces;
using SimPe.Models.PackedFile;
using SimPe.Models.PackedFile.Clst;
using SimPe.Models.PackedFile.Fwav;
using SimPe.Models.PackedFile.Idno;
using SimPe.Models.PackedFile.Picture;
using SimPe.Models.PackedFile.Str;
using SimPe.Models.PackedFile.Ttab;

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
			[FileTypes.IDNO] = Idno.Unserialize,
			[FileTypes.STR] = Str.Unserialize,
			[FileTypes.CTSS] = Str.Unserialize,
			[FileTypes.TTAs] = Str.Unserialize,
			[FileTypes.BMP] = Picture.Unserialize,
			[FileTypes.IMG] = Picture.Unserialize,
			[FileTypes.FWAV] = Fwav.Unserialize,
			[FileTypes.TTAB] = Ttab.Unserialize
		};
	}
}
