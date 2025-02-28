// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

namespace SimPe.Geometry
{
	/// <summary>
	/// Exception thrown by the Geometry Classes
	/// </summary>
	public class GeometryException : Exception
	{
		/// <summary>
		/// Create a new Instance
		/// </summary>
		/// <param name="message">The Message that should be displayed</param>
		public GeometryException(string message)
			: base(message) { }
	}
}
