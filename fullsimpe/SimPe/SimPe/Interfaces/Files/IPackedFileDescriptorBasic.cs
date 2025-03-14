// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

using SimPe.Data;
using SimPe.Extensions;

namespace SimPe.Interfaces.Files
{
	/// <summary>
	/// Interface for PackedFile Descriptors
	/// </summary>
	public interface IPackedFileDescriptorBasic
	{
		/// <summary>
		/// Returns the Offset within the Package File
		/// </summary>
		uint Offset
		{
			get;
		}

		/// <summary>
		/// Returns the Size of the referenced File
		/// </summary>
		/// <remarks>
		/// This must return either the size stored in the Index or the Size of the Userdata (if defined)
		/// </remarks>
		int Size
		{
			get;
		}

		/// <summary>
		/// Returns the Size of the File as stored in the Index
		/// </summary>
		/// <remarks>
		/// This must return the size of the File as it was stored in the Fileindex,
		/// even if the Size did change! (it is used during the IncrementalBuild Methode of a Package File!)
		/// If the file is new, this value must return 0.
		/// </remarks>
		int IndexedSize
		{
			get;
		}

		/// <summary>
		/// Returns the Type of the referenced File
		/// </summary>
		FileTypes Type
		{
			get; set;
		}

		/// <summary>
		/// Returns the Name of the represented Type
		/// </summary>
		FileTypeInformation TypeInfo
		{
			get;
		}

		/// <summary>
		/// Returns the Group the referenced file is assigned to
		/// </summary>
		uint Group
		{
			get; set;
		}

		/// <summary>
		/// Returns the Instance Data
		/// </summary>
		uint Instance
		{
			get; set;
		}

		/// <summary>
		/// Returns the Long Instance
		/// </summary>
		/// <remarks>Combination of SubType and Instance</remarks>
		ulong LongInstance
		{
			get; set;
		}

		/// <summary>
		/// Returns an yet unknown Type
		/// </summary>
		/// <remarks>Only in Version 1.1 of package Files</remarks>
		uint SubType
		{
			get; set;
		}

		/// <summary>
		/// Returns or Sets the Filename
		/// </summary>
		/// <remarks>This is mostly of intrest when you extract packedFiles</remarks>
		string Filename
		{
			get; set;
		}

		/// <summary>
		/// Returns the Filename that should be used when you create a single exported File
		/// </summary>
		string ExportFileName
		{
			get;
		}

		/// <summary>
		/// Returns or Setst the File Path
		/// </summary>
		/// <remarks>This is mostly of intrest when you extract packedFiles</remarks>
		string Path
		{
			get; set;
		}

		/// <summary>
		/// Generates MetInformations about a Packed File
		/// </summary>
		/// <param name="pfd">The description of the File</param>
		/// <returns>A String representing the Description as XML output</returns>
		string GenerateXmlMetaInfo();

		/// <summary>
		/// Returns true if theis File was changed since the last Save
		/// </summary>
		bool Changed
		{
			get; set;
		}

		/// <summary>
		/// Returns true, if Userdate is available
		/// </summary>
		/// <remarks>This happens when a user assigns new Data</remarks>
		bool HasUserdata
		{
			get;
		}

		/// <summary>
		/// Puts Userdefined Data into the File. Setting this Property will fire a <see cref="ChangedUserData"/> Event.
		/// </summary>
		byte[] UserData
		{
			get; set;
		}

		/// <summary>
		/// Returns/sets if this file should be keept in the Index for the next Save
		/// </summary>
		bool MarkForDelete
		{
			get; set;
		}

		/// <summary>
		/// Returns/sets if this File should be Recompressed during the next Save Operation
		/// </summary>
		bool MarkForReCompress
		{
			get; set;
		}

		/// <summary>
		/// Returns true if the Resource was Compressed
		/// </summary>
		bool WasCompressed
		{
			get;
		}

		/// <summary>
		/// Must override the Equals Method!
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		bool Equals(object obj);

		/// <summary>
		/// Same <see cref="Equals"/>, except this Version is also checking the Offset
		/// </summary>
		/// <param name="obj">The Object to compare to</param>
		/// <returns>true if the TGI Values are the same</returns>
		bool SameAs(object obj);

		/// <summary>
		/// additional Data
		/// </summary>
		object Tag
		{
			get; set;
		}

		/// <summary>
		/// Close this Descriptor (make it invalid)
		/// </summary>
		void MarkInvalid();

		/// <summary>
		/// true, if this Descriptor is Invalid
		/// </summary>
		bool Invalid
		{
			get;
		}

		/// <summary>
		/// Derefers <see cref="DescriptionChanged"/> and <see cref="ChangedData"/>
		/// until <see cref="EndUpdate"/> is called
		/// </summary>
		void BeginUpdate();

		/// <summary>
		/// Executes Events Derrefered by <see cref="BeginUpdate"/>
		/// </summary>
		void EndUpdate();

		/// <summary>
		/// Returns the Name of this Descripotr as used in Exception Messages
		/// </summary>
		string ExceptionString
		{
			get;
		}
	}
}
