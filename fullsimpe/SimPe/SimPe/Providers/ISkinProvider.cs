// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections;

namespace SimPe.Interfaces.Providers
{
	/// <summary>
	/// Interface to obtain Skin Files from the Game Installation
	/// </summary>
	public interface ISkinProvider : ICommonPackage
	{
		void LoadPackage();

		/// <summary>
		/// Returns the roperty Set of a Skin
		/// </summary>
		/// <param name="spfd">The File Description of the File you are looking for</param>
		/// <returns>null or the Property Set File</returns>
		object FindSet(Files.IPackedFileDescriptor spfd);

		/// <summary>
		/// Returns a list of all known memories
		/// </summary>
		ArrayList StoredSkins
		{
			get;
		}

		string FindTxtrName(Files.IPackedFileDescriptor spfd);
		string FindTxtrName(string matdname);

		/// <summary>
		///
		/// </summary>
		/// <param name="ocpf">The MMAT or Property Set describing the Model</param>
		/// <returns>The Texture or null</returns>
		object FindTxtrName(object ocpf);

		object FindTxtr(string name);
		object FindUserTxtr(string name);
	}
}
