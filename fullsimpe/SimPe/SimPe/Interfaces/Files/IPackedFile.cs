// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

namespace SimPe.Interfaces.Files
{
	/// <summary>
	/// Interface for a PackedFile object
	/// </summary>
	public interface IPackedFile
	{
		/// <summary>
		/// Returns true if the PackedFile is compressed
		/// </summary>
		bool IsCompressed
		{
			get;
		}

		/// <summary>
		/// Returns the Size of the File
		/// </summary>
		int Size
		{
			get;
		}

		/// <summary>
		/// Returns the Size of the File
		/// </summary>
		ushort Signature
		{
			get;
		}

		/// <summary>
		/// Returns the Uncompressed Filesize
		/// </summary>
		uint UncompressedSize
		{
			get;
		}

		/// <summary>
		/// Returns the Plain File Data (might be compressed)
		/// </summary>
		/// <remarks>
		/// All Header Informations are Cut from the Data, so you really
		/// get the Data Stored in the PackedFile
		/// </remarks>
		byte[] Data
		{
			get;
		}

		/// <summary>
		/// Returns the Plain File Data (might be compressed)
		/// </summary>
		/// <remarks>
		/// Header Informations are Included
		/// </remarks>
		byte[] PlainData
		{
			get;
		}

		/// <summary>
		/// Returns the Plain File Data. If the Packed File is compress it will be decompressed
		/// </summary>
		byte[] UncompressedData
		{
			get;
		}

		/// <summary>
		/// Returns the Uncompressed Data
		/// </summary>
		/// <param name="maxsize">Maximum Number of Bytes that should be returned</param>
		/// <returns></returns>
		byte[] GetUncompressedData(int maxsize);

		/// <summary>
		/// Returns a part of the decompresed File
		/// </summary>
		/// <param name="size">max number of bytes to decompress</param>
		/// <returns>trhe decompressed Value</returns>
		byte[] Decompress(long size);

		/// <summary>
		/// Returns the Plain File Data. If the Packed File is compress it will be decompressed
		/// </summary>
		System.IO.Stream UncompressedStream
		{
			get;
		}
	}
}
