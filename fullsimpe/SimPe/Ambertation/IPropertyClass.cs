// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace Ambertation
{
	/// <summary>
	/// This Interface has to be implemented by classes that should be lodable by the class directive
	/// in <see cref="PropertyParser"/>
	/// </summary>
	/// <remarks>
	/// Classes implementing this Interface MUST have a constructur that takes one object as argument!
	/// </remarks>
	public interface IPropertyClass
	{
		/// <summary>
		/// Create a new Instance of this Class
		/// </summary>
		/// <param name="o"></param>
		/// <returns></returns>
		//IPropertyClass Create(object o);
	}
}
