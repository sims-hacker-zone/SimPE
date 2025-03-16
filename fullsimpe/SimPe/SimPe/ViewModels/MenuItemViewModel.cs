// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.Generic;
using System.Windows.Input;

namespace SimPe.ViewModels
{
	public class MenuItemViewModel
	{
		public string Header
		{
			get; set;
		}
		public ICommand Command
		{
			get; set;
		}
		public object CommandParameter
		{
			get; set;
		}
		public IList<MenuItemViewModel> Items
		{
			get; set;
		}
	}
}
