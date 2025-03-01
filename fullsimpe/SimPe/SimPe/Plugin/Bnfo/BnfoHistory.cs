// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace SimPe.Plugin.Bnfo
{
	public struct BnfoHistory
	{
		public int Revenue
		{
			get; set;
		}
		public int Expenses
		{
			get; set;
		}
		public int Cashflow => Revenue - Expenses;
	}
}
