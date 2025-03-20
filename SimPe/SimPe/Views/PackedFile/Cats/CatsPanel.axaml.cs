// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using Avalonia.Controls;

namespace SimPe.Views.PackedFile.Cats
{
	public partial class CatsPanel : UserControl
	{
		public CatsPanel(Models.PackedFile.Cats.Cats cats)
		{
			DataContext = cats;
			InitializeComponent();
		}
	}
}
