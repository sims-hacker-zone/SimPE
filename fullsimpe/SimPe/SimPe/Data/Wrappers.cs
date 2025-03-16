using System;
using System.Collections.Generic;
using System.IO;

using SimPe.Models.Interfaces;
using SimPe.Models.PackedFile;
using SimPe.Models.PackedFile.Clst;

namespace SimPe.Data
{
	public static class Wrappers
	{
		public static Dictionary<FileTypes, Func<BinaryReader, PackedFile, IWrapper>> Unserializers
		{
			get;
		} = new()
		{
			[FileTypes.CLST] = Clst.Unserialize
		};
	}
}
