// SPDX-FileCopyrightText:© SimPE contributors
// SPDX-License-Identifier:GPL-2.0-or-later

using System;
using System.Collections.ObjectModel;
using SimPe.Common.Extensions;

namespace SimPe.Common.Models.Interfaces;

public abstract class InstalledGame
{
	public EnumDisplayNameItem Type { get; set; }

	public ObservableCollection<InstallPath> Paths { get; set; }
}
