// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
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
		RelationshipTypes data;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="data">The Value of the Enum</param>
		public LocalizedRelationshipTypes(RelationshipTypes data)
		{
			this.data = data;
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator LocalizedRelationshipTypes(
			RelationshipTypes item
		)
		{
			return new LocalizedRelationshipTypes(item);
		}

		/// <summary>
		/// Implicit Assignement of Enum Values
		/// </summary>
		/// <param name="item">the value</param>
		/// <returns>the new Object</returns>
		public static implicit operator RelationshipTypes(
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
			return new LocalizedRelationshipTypes((RelationshipTypes)item);
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
			RelationshipTypes op1,
			LocalizedRelationshipTypes op2
		)
		{
			return op1 == op2.data;
		}

		public static bool operator !=(
			RelationshipTypes op1,
			LocalizedRelationshipTypes op2
		)
		{
			return op1 != op2.data;
		}

		public static bool operator ==(
			LocalizedRelationshipTypes op1,
			RelationshipTypes op2
		)
		{
			return op1.data == op2;
		}

		public static bool operator !=(
			LocalizedRelationshipTypes op1,
			RelationshipTypes op2
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
}
