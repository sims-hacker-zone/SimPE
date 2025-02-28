// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Interfaces.Scenegraph
{
	/// <summary>
	/// An Item in the FileIndex
	/// </summary>
	public interface IScenegraphFileIndexItem
	{
		/// <summary>
		/// The Descriptor of that File
		/// </summary>
		/// <remarks>Contains the original Group </remarks>
		Files.IPackedFileDescriptor FileDescriptor
		{
			get; set;
		}

		/// <summary>
		/// The Descriptor of that File, with a real Group value
		/// </summary>
		/// <returns>A Clonde FileDescriptor, that contains the correct Group</returns>
		/// <remarks>Contains the local Group (can never be 0xffffffff)</remarks>
		Files.IPackedFileDescriptor GetLocalFileDescriptor();

		/// <summary>
		/// The package the File is stored in
		/// </summary>
		Files.IPackageFile Package
		{
			get;
		}

		/// <summary>
		/// Get the Local Group alue used for this Package
		/// </summary>
		uint LocalGroup
		{
			get;
		}
	}
}
