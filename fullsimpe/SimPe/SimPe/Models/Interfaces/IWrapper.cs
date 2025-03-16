// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.IO;

using Avalonia.Controls;

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

		public abstract UserControl Panel
		{
			get;
		}
	}
}
