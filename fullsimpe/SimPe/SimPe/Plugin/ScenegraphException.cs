// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

namespace SimPe.Plugin
{
	/// <summary>
	/// SimPe was unable to load a File
	/// </summary>
	public class CorruptedFileException : Exception
	{
		static string GetFileName(
			Interfaces.Scenegraph.IScenegraphFileIndexItem item
		)
		{
			return item == null || item.Package == null || item.Package.FileName == null ? "" : item.Package.FileName;
		}

		public CorruptedFileException(
			Interfaces.Scenegraph.IScenegraphFileIndexItem item,
			Exception inner
		)
			: base(
				"A corrupted PackedFile was found.",
				new Exception(
					"The File '"
						+ GetFileName(item)
						+ "' contains a Corrupted File ("
						+ item.FileDescriptor.ToString()
						+ ").\n\n SimPe will Ignore this File, but the resulting Package might be broken!",
					inner
				)
			)
		{
			FileTableBase.FileIndex.RemoveItem(item);
		}
	}

	/// <summary>
	/// En Error occurd during the attempt of walking the Scenegraph
	/// </summary>
	public class ScenegraphException : Exception
	{
		Interfaces.Files.IPackedFileDescriptor pfd;

		public ScenegraphException(
			string message,
			Interfaces.Files.IPackedFileDescriptor pfd
		)
			: base(message)
		{
			this.pfd = pfd;
		}

		public ScenegraphException(
			string message,
			Exception inner,
			Interfaces.Files.IPackedFileDescriptor pfd
		)
			: base(message, inner)
		{
			this.pfd = pfd;
		}

		public override string Message => pfd != null ? base.Message + " (in " + pfd + ")" : base.Message;
	}
}
