// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Data
{
	/// <summary>
	/// Localized Version of the Careers Enum
	/// </summary>
	public class LocalizedCareers
	{
		/// <summary>
		/// Contains the value
		/// </summary>
		Careers data;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="data">The Value of the Enum</param>
		public LocalizedCareers(Careers data)
		{
			this.data = data;
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator LocalizedCareers(Careers item)
		{
			return new LocalizedCareers(item);
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator Careers(LocalizedCareers item)
		{
			return item.data;
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator LocalizedCareers(uint item)
		{
			return new LocalizedCareers((Careers)item);
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator uint(LocalizedCareers item)
		{
			return (uint)item.data;
		}

		/// <summary>
		/// Overrides the Default to string Members
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			string s = Localization.Manager.GetString(data.ToString());
			return s ?? data.ToString();
		}
	}
}
