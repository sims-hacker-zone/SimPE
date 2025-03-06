// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Data
{
	/// <summary>
	/// Localized Version of the ZodiacSignes Enum
	/// </summary>
	public class LocalizedZodiacSigns
	{
		/// <summary>
		/// Contains the value
		/// </summary>
		ZodiacSigns data;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="data">The Value of the Enum</param>
		public LocalizedZodiacSigns(ZodiacSigns data)
		{
			this.data = data;
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator LocalizedZodiacSigns(
			ZodiacSigns item
		)
		{
			return new LocalizedZodiacSigns(item);
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator ZodiacSigns(
			LocalizedZodiacSigns item
		)
		{
			return item.data;
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator LocalizedZodiacSigns(ushort item)
		{
			return new LocalizedZodiacSigns((ZodiacSigns)item);
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator ushort(LocalizedZodiacSigns item)
		{
			return (ushort)item.data;
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
