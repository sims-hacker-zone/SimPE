// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

namespace SimPe.Data
{

	/// <summary>
	/// Localized Version of the Bodyshape Enum
	/// </summary>
	public class LocalizedBodyshape
	{
		/// <summary>
		/// Contains the value
		/// </summary>
		MetaData.Bodyshape data;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="data">The Value of the Enum</param>
		public LocalizedBodyshape(MetaData.Bodyshape data)
		{
			this.data = data;
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator LocalizedBodyshape(MetaData.Bodyshape item)
		{
			return new LocalizedBodyshape(item);
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator MetaData.Bodyshape(LocalizedBodyshape item)
		{
			return item.data;
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator LocalizedBodyshape(uint item)
		{
			return new LocalizedBodyshape((MetaData.Bodyshape)item);
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator uint(LocalizedBodyshape item)
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

	/// <summary>
	/// Localized Version of the Available EPs
	/// </summary>
	public class LocalizedNeighborhoodEP
	{
		/// <summary>
		/// Contains the value
		/// </summary>
		NeighborhoodEP data;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="data">The Value of the Enum</param>
		public LocalizedNeighborhoodEP(NeighborhoodEP data)
		{
			this.data = data;
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator LocalizedNeighborhoodEP(
			NeighborhoodEP item
		)
		{
			return new LocalizedNeighborhoodEP(item);
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator NeighborhoodEP(
			LocalizedNeighborhoodEP item
		)
		{
			return item.data;
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator LocalizedNeighborhoodEP(uint item)
		{
			return new LocalizedNeighborhoodEP((NeighborhoodEP)item);
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator uint(LocalizedNeighborhoodEP item)
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
			if (s != null)
			{
				if (Helper.WindowsRegistry.LoadOnlySimsStory == 28 && s == "Seasons")
				{
					s = "Castaway";
				}

				return s;
			}
			else
			{
				return data.ToString();
			}
		}
	}

	/// <summary>
	/// Localized Version of the FamilyTieTypes Enum
	/// </summary>
	public class LocalizedFamilyTieTypes
	{
		/// <summary>
		/// Contains the value
		/// </summary>
		MetaData.FamilyTieTypes data;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="data">The Value of the Enum</param>
		public LocalizedFamilyTieTypes(MetaData.FamilyTieTypes data)
		{
			this.data = data;
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator LocalizedFamilyTieTypes(
			MetaData.FamilyTieTypes item
		)
		{
			return new LocalizedFamilyTieTypes(item);
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator MetaData.FamilyTieTypes(
			LocalizedFamilyTieTypes item
		)
		{
			return item.data;
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator LocalizedFamilyTieTypes(uint item)
		{
			return new LocalizedFamilyTieTypes((MetaData.FamilyTieTypes)item);
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator uint(LocalizedFamilyTieTypes item)
		{
			return (uint)item.data;
		}

		/// <summary>
		/// Overrides the Default to string Members
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			if (Helper.StartedGui == Executable.Default)
			{
				Type type = typeof(MetaData.FamilyTieTypes);
				string s = Localization.Manager.GetString(
					type.Namespace + "." + type.Name + "." + data.ToString()
				);
				return s ?? data.ToString();
			}
			else
			{
				string s = Localization.Manager.GetString(data.ToString());
				return s ?? data.ToString();
			}
		}
	}

	/// <summary>
	/// Localized Version of the BuildSubSort Enum
	/// </summary>
	public class LocalizedBuildSubSort
	{
		/// <summary>
		/// Contains the value
		/// </summary>
		BuildFunctionSubSort data;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="data">The Value of the Enum</param>
		public LocalizedBuildSubSort(BuildFunctionSubSort data)
		{
			this.data = data;
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator LocalizedBuildSubSort(BuildFunctionSubSort item)
		{
			return new LocalizedBuildSubSort(item);
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator BuildFunctionSubSort(LocalizedBuildSubSort item)
		{
			return item.data;
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator LocalizedBuildSubSort(uint item)
		{
			return new LocalizedBuildSubSort((BuildFunctionSubSort)item);
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator uint(LocalizedBuildSubSort item)
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
