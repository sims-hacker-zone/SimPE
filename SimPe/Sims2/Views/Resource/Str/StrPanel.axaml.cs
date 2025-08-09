// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using Avalonia.Controls;

namespace SimPe.Sims2.Views.Resource.Str;

public partial class StrPanel : UserControl
{
	public StrPanel(Models.Resource.Str.Str str)
	{
		DataContext = str;
		InitializeComponent();
	}
}
