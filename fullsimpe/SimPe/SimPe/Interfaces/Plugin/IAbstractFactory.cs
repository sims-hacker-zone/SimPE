// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Interfaces.Plugin
{
	/// <summary>
	/// Lists all Plugins (=FileType Wrappers) available in this Package
	/// </summary>
	/// <remarks>
	/// GetWrappers() has to return a list of all Plugins provided by this Library.
	/// If a Plugin isn't returned, SimPe won't recognize it!
	/// </remarks>
	public abstract class AbstractWrapperFactory : IWrapperFactory
	{
		/// <summary>
		/// Holds a referenc to the Registry this Plugin was last registred to (can be null!)
		/// </summary>
		private IWrapperRegistry registry;

		/// <summary>
		/// Holds a reference to available Providers (i.e. for SIm Names or Images)
		/// </summary>
		private IProviderRegistry provider;

		#region IWrapperFactory Member

		/// <summary>
		/// Returns or sets the Registry this Plugin was last registred with
		/// </summary>
		public virtual IWrapperRegistry LinkedRegistry
		{
			get => registry;
			set => registry = value;
		}

		/// <summary>
		/// Returns or sets the Provider this Plugin can use
		/// </summary>
		public virtual IProviderRegistry LinkedProvider
		{
			get => provider;
			set => provider = value;
		}

		/// <summary>
		/// Returns a List of all available Plugins in this Package
		/// </summary>
		/// <returns>A List of all provided Plugins (=FileType Wrappers)</returns>
		public virtual IWrapper[] KnownWrappers
		{
			get
			{
				IWrapper[] wrappers = { };
				return wrappers;
			}
		}

		public string FileName => GetType().Assembly.FullName;

		#endregion
	}
}
