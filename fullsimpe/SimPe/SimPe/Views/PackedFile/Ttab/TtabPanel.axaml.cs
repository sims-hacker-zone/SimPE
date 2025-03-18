// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using Avalonia.Controls;

namespace SimPe.Views.PackedFile.Ttab
{
	public partial class TtabPanel : UserControl
	{
		public TtabPanel(Models.PackedFile.Ttab.Ttab ttab)
		{
			DataContext = ttab;
			InitializeComponent();
		}
	}
}
