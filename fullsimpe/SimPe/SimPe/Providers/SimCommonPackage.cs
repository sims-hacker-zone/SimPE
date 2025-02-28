// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

using SimPe.Interfaces.Files;
using SimPe.Interfaces.Providers;

namespace SimPe.Providers
{
	/// <summary>
	/// Summary description for SimCommonPackage.
	/// </summary>
	public abstract class SimCommonPackage : ICommonPackage
	{
		/// <summary>
		/// The Package currently opened
		/// </summary>
		IPackageFile package;

		/// <summary>
		/// Creates the List for the specific Folder
		/// </summary>
		/// <param name="folder">The Folder with the Character Files</param>
		public SimCommonPackage(IPackageFile package)
		{
			BasePackage = package;
		}

		public event EventHandler ChangedPackage;

		/// <summary>
		/// Returns or sets the Folder where the Character Files are stored
		/// </summary>
		/// <remarks>Sets the names List to null</remarks>
		public IPackageFile BasePackage
		{
			get => package;
			set
			{
				if (package != value)
				{
					BasePackageChanged();
				}
				package = value;
			}
		}

		/// <summary>
		/// Called if the BaseBackae was changed
		/// </summary>
		protected void BasePackageChanged()
		{
			OnChangedPackage();
			if (ChangedPackage != null)
			{
				ChangedPackage(this, new EventArgs());
			}
		}

		protected abstract void OnChangedPackage();
	}
}
