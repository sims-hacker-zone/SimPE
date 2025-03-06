// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

using SimPe.Data;
using SimPe.Interfaces.Plugin.Internal;

namespace SimPe.Interfaces.Plugin
{
	/// <summary>
	/// This Interface Implements Methods that must be provided by a PackedFile Wrapper
	/// </summary>
	public interface IFileWrapper : IPackedFileWrapper
	{
		/// <summary>
		/// Returns a List of all File Types this Class can Handel
		/// </summary>
		FileTypes[] AssignableTypes
		{
			get;
		}

		/// <summary>
		/// Some Handler identify theier Target Files not with a Type but by a PackedFile Header, when this
		/// Method does not retun an empty Array, all files starting with the passed Signature will
		/// be passed to the Handler
		/// </summary>
		byte[] FileSignature
		{
			get;
		}
	}

	/// <summary>
	/// This Interface has to be implemented by Wrappers that allow multiple Instance
	/// </summary>
	public interface IMultiplePackedFileWrapper
	{
		/// <summary>
		/// Returns a new Instance of the calling Class
		/// </summary>
		/// <returns>a new Instance of the calling Type</returns>
		IFileWrapper Activate();

		/// <summary>
		/// Returns a list of Arguments that should be passed to the Constructor during <see cref="Activate"/>.
		/// </summary>
		/// <returns></returns>
		object[] GetConstructorArguments();
	}
}
