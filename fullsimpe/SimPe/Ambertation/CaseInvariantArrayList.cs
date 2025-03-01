// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace Ambertation
{
	/// <summary>
	/// List that handles Strings case Invariant
	/// </summary>
	public class CaseInvariantArrayList : System.Collections.ArrayList
	{
		/// <summary>
		/// Checks wether or not the object is already stored in the List
		/// </summary>
		/// <param name="item">The Object you are looking for</param>
		/// <returns>true, if it was found</returns>
		public override bool Contains(object o)
		{
			if (o is string s)
			{
				s = s.ToLower();
				foreach (object i in this)
				{
					if (i == null)
					{
						continue;
					}

					if (i is string)
					{
						if (((string)i).ToLower() == s)
						{
							return true;
						}
					}
				}

				return false;
			}
			else
			{
				return base.Contains(o);
			}
		}

		public override void Remove(object obj)
		{
			if (obj is string s)
			{
				s = s.ToLower();
				for (int k = 0; k < Count; k++)
				{
					object i = this[k];
					if (i == null)
					{
						continue;
					}

					if (i is string)
					{
						if (((string)i).ToLower() == s)
						{
							base.RemoveAt(k);
							return;
						}
					}
				}
			}
			else
			{
				base.Remove(obj);
			}
		}
	}
}
