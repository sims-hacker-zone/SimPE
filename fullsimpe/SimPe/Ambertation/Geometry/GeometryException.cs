// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

namespace Ambertation.Geometry
{
	public class GeometryException : Exception
	{
		public GeometryException(string message)
			: base(message)
		{
		}

		public GeometryException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
