// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

namespace SimPe.Data
{
	/// <summary>
	/// Overrides the Alias class
	/// </summary>
	public class SemiGlobalAlias : Alias, IComparable<SemiGlobalAlias>
	{
		public SemiGlobalAlias(uint id, string name)
			: base(id, name)
		{
			Known = false;
		}

		public SemiGlobalAlias(bool known, uint id, string name)
			: base(id, name)
		{
			Known = known;
		}

		/// <summary>
		/// returns true if this Global is know for certain
		/// </summary>
		public bool Known
		{
			get;
		}

		public override string ToString()
		{
			return Name;
		}

		#region IComparable<SemiGlobalAlias> Member

		public int CompareTo(SemiGlobalAlias other)
		{
			return ToString().CompareTo(other.ToString());
		}

		#endregion
	}
}
