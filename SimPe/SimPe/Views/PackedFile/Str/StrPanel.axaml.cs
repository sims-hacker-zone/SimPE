// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using Avalonia.Controls;

namespace SimPe.Views.PackedFile.Str
{
	public partial class StrPanel : UserControl
	{
		public StrPanel(Models.PackedFile.Str.Str str)
		{
			DataContext = str;
			InitializeComponent();
		}
	}
}
