// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

using SimPe.Interfaces;
using SimPe.Interfaces.Plugin;

namespace SimPe
{
	public class PackageArg : EventArgs
	{
		public Interfaces.Files.IPackageFile Package
		{
			get; set;
		}

		public Interfaces.Files.IPackedFileDescriptor FileDescriptor
		{
			get; set;
		}

		public IToolResult Result
		{
			get; set;
		}
	}

	/// <summary>
	/// Class that can be used to Load external Filewrappers int the given Registry
	/// </summary>
	public class LoadFileWrappers
	{
		/// <summary>
		/// The Type Registry
		/// </summary>
		IWrapperRegistry reg;

		/// <summary>
		/// The Tool Registry
		/// </summary>
		IToolRegistry treg;

		/// <summary>
		/// Constructor of The class
		/// </summary>
		/// <param name="registry">
		/// Registry the External Data should be added to
		/// </param>
		/// <param name="toolreg">Registry the tools should be added to</param>
		public LoadFileWrappers(IWrapperRegistry registry, IToolRegistry toolreg)
		{
			reg = registry;
			treg = toolreg;
		}
	}
}
