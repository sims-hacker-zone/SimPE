// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Data
{
	/// <summary>
	/// Localized Version of the AspirationType Enum
	/// </summary>
	public class LocalizedAspirationTypes
	{
		/// <summary>
		/// Contains the value
		/// </summary>
		AspirationTypes data;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="data">The Value of the Enum</param>
		public LocalizedAspirationTypes(AspirationTypes data)
		{
			this.data = data;
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator LocalizedAspirationTypes(
			AspirationTypes item
		)
		{
			return new LocalizedAspirationTypes(item);
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator AspirationTypes(
			LocalizedAspirationTypes item
		)
		{
			return item.data;
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator LocalizedAspirationTypes(ushort item)
		{
			return new LocalizedAspirationTypes((AspirationTypes)item);
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator ushort(LocalizedAspirationTypes item)
		{
			return (ushort)item.data;
		}

		/// <summary>
		/// Overrides the Default to string Members
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			string s = Localization.Manager.GetString(
				"SimPe.Data.MetaData.AspirationTypes." + data.ToString()
			);
			return s ?? data.ToString();
		}
	}
}
