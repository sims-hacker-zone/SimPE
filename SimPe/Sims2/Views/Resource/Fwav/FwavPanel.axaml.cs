// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using Avalonia.Controls;

namespace SimPe.Sims2.Views.Resource.Fwav;

public partial class FwavPanel : UserControl
{
	public FwavPanel(Models.Resource.Fwav.Fwav fwav)
	{
		DataContext = fwav;
		InitializeComponent();
	}
}
