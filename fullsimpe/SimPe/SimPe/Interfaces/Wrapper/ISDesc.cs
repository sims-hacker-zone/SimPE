// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Interfaces.Wrapper
{
	/// <summary>
	/// Interface for Sim Description Files
	/// </summary>
	public interface ISDesc
	{
		/// <summary>
		/// Returns/Sets the Sim Id
		/// </summary>
		uint SimId
		{
			get; set;
		}

		/// <summary>
		/// Returns the FirstName of a Sim
		/// </summary>
		/// <remarks>If no SimName Provider is available, '---' will be delivered</remarks>
		string SimName
		{
			get;
		}

		/// <summary>
		/// Returns the Image stored for a specific Sim
		/// </summary>
		System.Drawing.Image Image
		{
			get;
		}

		/// <summary>
		/// Returns the Name of the File the Character is stored in
		/// </summary>
		/// <remarks>null, if no File was found</remarks>
		string CharacterFileName
		{
			get;
		}

		/// <summary>
		/// Returns or Sets the Instance Number
		/// </summary>
		ushort Instance
		{
			get; set;
		}

		/// <summary>
		/// Returs /Sets the Family Instance
		/// </summary>
		ushort FamilyInstance
		{
			get; set;
		}

		/// <summary>
		/// Returns the FamilyName of a Sim
		/// </summary>
		/// <remarks>If no SimFamilyName Provider is available, '---' will be delivered</remarks>
		string SimFamilyName
		{
			get;
		}

		/// <summary>
		/// Returns the FamilyName of a Sim that is stored in the current Package
		/// </summary>
		/// <remarks>If no SimFamilyName Provider is available, '---' will be delivered</remarks>
		string HouseholdName
		{
			get;
		}

		/// <summary>
		/// Returns the Filedescriptor used to obtain the current Data
		/// </summary>
		Files.IPackedFileDescriptor FileDescriptor
		{
			get;
		}
	}
}
