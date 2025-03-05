// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

namespace SimPe.Cache
{
	/// <summary>
	/// a Cache Exception
	/// </summary>
	public class CacheException : Exception
	{
		/// <summary>
		/// Create a new Instance of the Exception
		/// </summary>
		/// <param name="message">The Message</param>
		/// <param name="filename">the Name of the Cache File (can be null)</param>
		/// <param name="version">the Version of the Cache File</param>
		public CacheException(string message, string filename, byte version)
			: base(
				message + " (file=" + filename + ", version=" + version.ToString() + ")"
			)
		{
		}
	}
}
