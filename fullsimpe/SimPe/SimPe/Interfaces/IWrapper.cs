// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Interfaces
{
	/// <summary>
	/// defines an Object that can be put into a Registry
	/// </summary>
	public interface IWrapper
	{
		/// <summary>
		/// true, if the UIHandler for this Wrapper is able to display more than one Instance at once
		/// </summary>
		bool AllowMultipleInstances
		{
			get;
		}

		/// <summary>
		/// Registers the Wrapper with the passed Registry
		/// </summary>
		/// <param name="registry">The Registry you want to registre this Wrapper with</param>
		void Register(IWrapperRegistry registry);

		/// <summary>
		/// Returns true, if the Plugin can be used with the passed SimPe Version
		/// </summary>
		/// <param name="version">The Version of SimPe Application that requested this Wrapper (0.05 would be 5, while 2.0 would be 2000)</param>
		/// <returns>true, if the Wrapper can be used with this Version</returns>
		/// <remarks>
		/// SimPe will check if the Function does always return true, in order to prevent
		/// possible conflicts, so you should perform a real Version Check.
		/// </remarks>
		bool CheckVersion(uint version);

		/// <summary>
		/// Returns a Human Readable Description of the Wrapper
		/// </summary>
		Plugin.IWrapperInfo WrapperDescription
		{
			get;
		}

		/// <summary>
		/// The Priority of a Wrapper in the Registry
		/// </summary>
		/// <remarks>Wrappers with low Numbers are more likley choosen to handle a specific File</remarks>
		int Priority
		{
			get; set;
		}

		/// <remarks>
		/// This is explicit listed in the Interface description, as you should return a String (best would be Name)
		/// that identifies the Wrapper
		/// </remarks>
		/// <summary>Returns a short describing String</summary>
		/// <returns>A Describing String for the Wrapper</returns>
		string ToString();

		/// <summary>
		/// Returns sets the Name of the File where this wrapper is located in
		/// </summary>
		string WrapperFileName
		{
			get;
		}
	}
}
