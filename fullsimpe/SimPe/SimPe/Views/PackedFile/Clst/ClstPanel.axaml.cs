// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using Avalonia.Controls;

namespace SimPe.Views.PackedFile.Clst
{
	public partial class ClstPanel : UserControl
	{
		public ClstPanel(Models.PackedFile.Clst.Clst clst)
		{
			DataContext = clst;
			InitializeComponent();
		}
	}
}
