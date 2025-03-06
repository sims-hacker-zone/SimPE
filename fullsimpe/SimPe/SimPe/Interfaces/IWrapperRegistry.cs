// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;

using SimPe.Data;

namespace SimPe.Interfaces
{
	/// <summary>
	/// Summary description for IWrapperRegistry.
	/// </summary>
	public interface IWrapperRegistry
	{
		/// <summary>
		/// Registers a Wrapper to the Registry
		/// </summary>
		/// <param name="wrapper">The wrapper to register</param>
		/// <remarks>The wrapper must only be added if the Registry doesnt already contain it</remarks>
		void Register(IWrapper wrapper);

		/// <summary>
		/// Registers all listed Wrappers with this Registry
		/// </summary>
		/// <param name="wrappers">The Wrappers to register</param>
		/// <param name="guiwrappers">null, or a List of the same Length as wrappers,
		/// with a second Instance of each wrapper</param>
		/// <remarks>The wrapper must only be added if the Registry doesnt already contain it</remarks>
		void Register(IWrapper[] wrappers, IWrapper[] guiwrappers);

		/// <summary>
		/// Registers all Wrappers supported by the Factory
		/// </summary>
		/// <param name="factory">The Factory Elements you want to register</param>
		/// <remarks>The wrapper must only be added if the Registry doesnt already contain it</remarks>
		void Register(Plugin.IWrapperFactory factory);

		/// <summary>
		/// Returns the List of Known Wrappers (without Wrappers having a Priority &lt; 0!)
		/// </summary>
		/// <remarks>The Wrappers should be Returned in Order of Priority starting with the lowest!</remarks>
		IEnumerable<IWrapper> Wrappers
		{
			get;
		}

		/// <summary>
		/// Returns the List of all Known Wrappers including Wrappers with Priority &lt; 0
		/// </summary>
		/// <remarks>The Wrappers should be Returned in Order of Priority starting with the lowest!</remarks>
		IEnumerable<IWrapper> AllWrappers
		{
			get;
		}

		/// <summary>
		/// Returns the first Handler capable of processing a File of the given Type
		/// </summary>
		/// <param name="type">The Type of the PackedFile</param>
		/// <returns>The assigned Handler or null if none was found</returns>
		Plugin.Internal.IPackedFileWrapper FindHandler(FileTypes type);

		/// <summary>
		/// Returns the first Handler capable of processing a File
		/// </summary>
		/// <param name="data">The Data of the PackedFile</param>
		/// <returns>The assigned Handler or null if none was found</returns>
		/// <remarks>
		/// A handler is assigned if the first bytes of the Data are equal
		/// to the signature provided by the Handler
		/// </remarks>
		Plugin.IFileWrapper FindHandler(byte[] data);

		/// <summary>
		/// Contains a Listing of all available Wrapper Icons
		/// </summary>
		System.Windows.Forms.ImageList WrapperImageList
		{
			get;
		}
	}
}
