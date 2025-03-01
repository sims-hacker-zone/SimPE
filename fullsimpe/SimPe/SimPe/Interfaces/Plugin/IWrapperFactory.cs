// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Interfaces.Plugin
{
	/// <summary>
	/// If you create a Plugin for SimPe your .dll must implement this interface
	/// give the calling main Application a reference to your Plugin Objects
	/// </summary>
	/// <remarks>
	/// When SimPe tries to load the Wrappers stored here, it will create a new Instance of
	/// the Factory. After taht it will set LinkedRegistry/LinkedProvider to the registry the Objects going
	/// to be linked with.
	/// Last it wil load the list of KnownWrappers.
	/// </remarks>
	public interface IWrapperFactory
	{
		/// <summary>
		/// Returns all Wrappers the Factory knows
		/// </summary>
		IWrapper[] KnownWrappers
		{
			get;
		}

		/// <summary>
		/// Returns or sets the Registry this Plugin was last registred with
		/// </summary>
		IWrapperRegistry LinkedRegistry
		{
			get; set;
		}

		/// <summary>
		/// Returns or sets the Provider this Plugin can use
		/// </summary>
		IProviderRegistry LinkedProvider
		{
			get; set;
		}
	}
}
