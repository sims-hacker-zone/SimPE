// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Common.Extensions;
using SimPe.Common.Models.Interfaces;
using SimPe.Sims1.Data;

namespace SimPe.Sims1.Models.Configuration;

[ObservableObject]
public partial class InstalledGame : Common.Models.Interfaces.InstalledGame
{
	[ObservableProperty] private EnumDisplayNameItem<GameTypes> type = new(GameTypes.Sims1);

	[ObservableProperty] private ObservableCollection<InstallPath> paths = [];

	public override string ToString()
	{
		return
			$"{Type.DisplayName}{(Paths.Any(path => path.Item == GameFolders.BaseGame) ? ": " + Paths.Single(path => path.Item == GameFolders.BaseGame) : string.Empty)}";
	}
}
