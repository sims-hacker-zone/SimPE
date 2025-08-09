// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Common.Extensions;
using SimPe.Sims2.Data;

namespace SimPe.Sims2.Models.Configuration;

public partial class InstalledGame : ObservableObject
{
	[ObservableProperty] private EnumDisplayNameItem<GameTypes> type = new(GameTypes.Sims2);

	[ObservableProperty] private ObservableCollection<InstallPath> paths = [];

	public override string ToString()
	{
		return
			$"{Type.DisplayName}{(Paths.Any(path => path.Item == PackageFolders.BaseGame) ? ": " + Paths.Single(path => path.Item == PackageFolders.BaseGame) : string.Empty)}";
	}
}
