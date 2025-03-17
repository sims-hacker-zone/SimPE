// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Linq;

using Avalonia.Controls;

using Microsoft.VisualBasic;

using SimPe.Data;
using SimPe.Extensions;

namespace SimPe.Views.PackedFile.Idno
{
	public partial class IdnoPanel : UserControl
	{
		public IdnoPanel(Models.PackedFile.Idno.Idno idno)
		{
			DataContext = idno;
			InitializeComponent();
		}
	}
}
