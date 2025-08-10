// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Common.Extensions;
using SimPe.Common.Models.Interfaces;
using SimPe.Sims1.Data;
using SimPe.Sims2.Data;

namespace SimPe.Sims1.Models.Configuration;

[ObservableObject]
public partial class InstallPath : Common.Models.Interfaces.InstallPath
{
	[ObservableProperty] private EnumDisplayNameItem<GameFolders> item = new(GameFolders.BaseGame);

	[ObservableProperty] private string? path;

	public override string? ToString()
	{
		return Path;
	}
}
