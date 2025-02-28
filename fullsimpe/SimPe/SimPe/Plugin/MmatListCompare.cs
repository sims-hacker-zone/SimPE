// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Plugin
{
	internal class MmatListCompare : System.Collections.IComparer
	{
		#region IComparer Member

		public int Compare(object x, object y)
		{
			MmatWrapper mmat1 = (MmatWrapper)x;
			MmatWrapper mmat2 = (MmatWrapper)y;

			int cmp =
				mmat1.GetSaveItem("materialStateFlags").IntegerValue
				- mmat2.GetSaveItem("materialStateFlags").IntegerValue;
			if (cmp == 0)
			{
				cmp =
					mmat1.GetSaveItem("objectStateIndex").IntegerValue
					- mmat2.GetSaveItem("objectStateIndex").IntegerValue;
			}

			return cmp;
		}

		#endregion
	}
}
