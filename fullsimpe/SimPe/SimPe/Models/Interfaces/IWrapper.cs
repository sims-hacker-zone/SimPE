using System;
using System.Collections.Generic;
using System.IO;

using SimPe.Data;
using SimPe.Models.PackedFile;

namespace SimPe.Models.Interfaces
{
	public interface IWrapper
	{
		public abstract PackedFile.PackedFile File
		{
			get;
			set;
		}
		public static virtual IWrapper Unserialize(BinaryReader reader, PackedFile.PackedFile file)
		{
			throw new NotImplementedException();
		}

		public abstract void Serialize(BinaryWriter writer);

		public T As<T>() where T : IWrapper
		{
			return (T)this;
		}
	}
}
