// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Interfaces.Plugin
{
	/// <summary>
	/// Contains Human Readable Information about a Wrapper
	/// </summary>
	/// <remarks>Never Implement a new Version of this Interface,
	/// use <see cref="AbstractWrapperInfo"/>
	/// as staring Point for a new Implementation. Otherwise the Loader
	/// Wrapper loader won't load the Image Index correct!</remarks>
	public interface IWrapperInfo : System.IDisposable
	{
		/// <summary>
		/// The Name of this Wrapper
		/// </summary>
		string Name
		{
			get;
		}

		/// <summary>
		/// The Description of this Wrapper
		/// </summary>
		string Description
		{
			get;
		}

		/// <summary>
		/// The Author of this Wrapper
		/// </summary>
		string Author
		{
			get;
		}

		/// <summary>
		/// The Version of this Wrapper
		/// </summary>
		int Version
		{
			get;
		}

		/// <summary>
		/// Returns a Unique ID for this Wrapper
		/// </summary>
		ulong UID
		{
			get;
		}

		/// <summary>
		/// Returns a Icon that should be presented for that resource
		/// </summary>
		System.Drawing.Image Icon
		{
			get;
		}

		/// <summary>
		/// Returns the Index of the Wrapepr icon in the ImageList of the Registry
		/// </summary>
		int IconIndex
		{
			get;
		}
	}
}
