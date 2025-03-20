// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using Avalonia.Controls;

namespace SimPe.Views.PackedFile.Fwav
{
	public partial class FwavPanel : UserControl
	{
		public FwavPanel(Models.PackedFile.Fwav.Fwav fwav)
		{
			DataContext = fwav;
			InitializeComponent();
		}
	}
}
