// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

namespace SimPe.Data
{
	/// <summary>
	/// Localized Version of the Grades Enum
	/// </summary>
	public class LocalizedRelationshipTypes
	{
		/// <summary>
		/// Contains the value
		/// </summary>
		MetaData.RelationshipTypes data;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="data">The Value of the Enum</param>
		public LocalizedRelationshipTypes(MetaData.RelationshipTypes data)
		{
			this.data = data;
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator LocalizedRelationshipTypes(
			MetaData.RelationshipTypes item
		)
		{
			return new LocalizedRelationshipTypes(item);
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator MetaData.RelationshipTypes(
			LocalizedRelationshipTypes item
		)
		{
			return item.data;
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator LocalizedRelationshipTypes(ushort item)
		{
			return new LocalizedRelationshipTypes((MetaData.RelationshipTypes)item);
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator ushort(LocalizedRelationshipTypes item)
		{
			return (ushort)item.data;
		}

		/// <summary>
		/// Overrides the Default to string Members
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			string s = Localization.Manager.GetString("RT_" + data.ToString());
			return s ?? data.ToString();
		}

		public override bool Equals(object obj)
		{
			bool ret = base.Equals(obj);
			if (ret)
			{
				ret = ((LocalizedRelationshipTypes)obj).data == data;
			}

			return ret;
		}

		public static bool operator ==(
			MetaData.RelationshipTypes op1,
			LocalizedRelationshipTypes op2
		)
		{
			return op1 == op2.data;
		}

		public static bool operator !=(
			MetaData.RelationshipTypes op1,
			LocalizedRelationshipTypes op2
		)
		{
			return op1 != op2.data;
		}

		public static bool operator ==(
			LocalizedRelationshipTypes op1,
			MetaData.RelationshipTypes op2
		)
		{
			return op1.data == op2;
		}

		public static bool operator !=(
			LocalizedRelationshipTypes op1,
			MetaData.RelationshipTypes op2
		)
		{
			return op1.data != op2;
		}

		public static bool operator ==(
			LocalizedRelationshipTypes op1,
			LocalizedRelationshipTypes op2
		)
		{
			return op1.data == op2.data;
		}

		public static bool operator !=(
			LocalizedRelationshipTypes op1,
			LocalizedRelationshipTypes op2
		)
		{
			return op1.data != op2.data;
		}

		public static bool operator ==(object op1, LocalizedRelationshipTypes op2)
		{
			if (op1.GetType() != typeof(LocalizedRelationshipTypes))
			{
				return false;
			}

			LocalizedRelationshipTypes op = (LocalizedRelationshipTypes)op1;
			return op.data == op2.data;
		}

		public static bool operator !=(object op1, LocalizedRelationshipTypes op2)
		{
			if (op1.GetType() != typeof(LocalizedRelationshipTypes))
			{
				return true;
			}

			LocalizedRelationshipTypes op = (LocalizedRelationshipTypes)op1;
			return op.data != op2.data;
		}

		public static bool operator ==(LocalizedRelationshipTypes op2, object op1)
		{
			if (op1.GetType() != typeof(LocalizedRelationshipTypes))
			{
				return false;
			}

			LocalizedRelationshipTypes op = (LocalizedRelationshipTypes)op1;
			return op.data == op2.data;
		}

		public static bool operator !=(LocalizedRelationshipTypes op2, object op1)
		{
			if (op1.GetType() != typeof(LocalizedRelationshipTypes))
			{
				return true;
			}

			LocalizedRelationshipTypes op = (LocalizedRelationshipTypes)op1;
			return op.data != op2.data;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}

	/// <summary>
	/// Localized Version of the Grades Enum
	/// </summary>
	public class LocalizedGrades
	{
		/// <summary>
		/// Contains the value
		/// </summary>
		MetaData.Grades data;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="data">The Value of the Enum</param>
		public LocalizedGrades(MetaData.Grades data)
		{
			this.data = data;
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator LocalizedGrades(MetaData.Grades item)
		{
			return new LocalizedGrades(item);
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator MetaData.Grades(LocalizedGrades item)
		{
			return item.data;
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator LocalizedGrades(ushort item)
		{
			return new LocalizedGrades((MetaData.Grades)item);
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator ushort(LocalizedGrades item)
		{
			return (ushort)item.data;
		}

		/// <summary>
		/// Overrides the Default to string Members
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			string s = Localization.Manager.GetString("Grade_" + data.ToString());
			return s ?? data.ToString();
		}
	}

	/// <summary>
	/// Localized Version of the SchoolType Enum
	/// </summary>
	public class LocalizedSchoolType
	{
		/// <summary>
		/// Contains the value
		/// </summary>
		MetaData.SchoolTypes data;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="data">The Value of the Enum</param>
		public LocalizedSchoolType(MetaData.SchoolTypes data)
		{
			this.data = data;
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator LocalizedSchoolType(MetaData.SchoolTypes item)
		{
			return new LocalizedSchoolType(item);
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator MetaData.SchoolTypes(LocalizedSchoolType item)
		{
			return item.data;
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator LocalizedSchoolType(uint item)
		{
			return new LocalizedSchoolType((MetaData.SchoolTypes)item);
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator uint(LocalizedSchoolType item)
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
	/// Localized Version of the ServiceTypes Enum
	/// </summary>
	public class LocalizedServiceTypes
	{
		/// <summary>
		/// Contains the value
		/// </summary>
		MetaData.ServiceTypes data;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="data">The Value of the Enum</param>
		public LocalizedServiceTypes(MetaData.ServiceTypes data)
		{
			this.data = data;
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator LocalizedServiceTypes(
			MetaData.ServiceTypes item
		)
		{
			return new LocalizedServiceTypes(item);
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator MetaData.ServiceTypes(
			LocalizedServiceTypes item
		)
		{
			return item.data;
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator LocalizedServiceTypes(uint item)
		{
			return new LocalizedServiceTypes((MetaData.ServiceTypes)item);
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator uint(LocalizedServiceTypes item)
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
	/// Localized Version of the AspirationType Enum
	/// </summary>
	public class LocalizedAspirationTypes
	{
		/// <summary>
		/// Contains the value
		/// </summary>
		MetaData.AspirationTypes data;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="data">The Value of the Enum</param>
		public LocalizedAspirationTypes(MetaData.AspirationTypes data)
		{
			this.data = data;
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator LocalizedAspirationTypes(
			MetaData.AspirationTypes item
		)
		{
			return new LocalizedAspirationTypes(item);
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator MetaData.AspirationTypes(
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
			return new LocalizedAspirationTypes((MetaData.AspirationTypes)item);
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

	/// <summary>
	/// Localized Version of the ZodiacSignes Enum
	/// </summary>
	public class LocalizedZodiacSignes
	{
		/// <summary>
		/// Contains the value
		/// </summary>
		MetaData.ZodiacSignes data;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="data">The Value of the Enum</param>
		public LocalizedZodiacSignes(MetaData.ZodiacSignes data)
		{
			this.data = data;
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator LocalizedZodiacSignes(
			MetaData.ZodiacSignes item
		)
		{
			return new LocalizedZodiacSignes(item);
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator MetaData.ZodiacSignes(
			LocalizedZodiacSignes item
		)
		{
			return item.data;
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator LocalizedZodiacSignes(ushort item)
		{
			return new LocalizedZodiacSignes((MetaData.ZodiacSignes)item);
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator ushort(LocalizedZodiacSignes item)
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

	/// <summary>
	/// Localized Version of the LifeSections Enum
	/// </summary>
	public class LocalizedLifeSections
	{
		/// <summary>
		/// Contains the value
		/// </summary>
		MetaData.LifeSections data;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="data">The Value of the Enum</param>
		public LocalizedLifeSections(MetaData.LifeSections data)
		{
			this.data = data;
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator LocalizedLifeSections(
			MetaData.LifeSections item
		)
		{
			return new LocalizedLifeSections(item);
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator MetaData.LifeSections(
			LocalizedLifeSections item
		)
		{
			return item.data;
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator LocalizedLifeSections(ushort item)
		{
			return new LocalizedLifeSections((MetaData.LifeSections)item);
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator ushort(LocalizedLifeSections item)
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

	/// <summary>
	/// Localized Version of the Careers Enum
	/// </summary>
	public class LocalizedCareers
	{
		/// <summary>
		/// Contains the value
		/// </summary>
		MetaData.Careers data;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="data">The Value of the Enum</param>
		public LocalizedCareers(MetaData.Careers data)
		{
			this.data = data;
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator LocalizedCareers(MetaData.Careers item)
		{
			return new LocalizedCareers(item);
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator MetaData.Careers(LocalizedCareers item)
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
			return new LocalizedCareers((MetaData.Careers)item);
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
