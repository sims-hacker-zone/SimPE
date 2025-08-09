// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Common.Extensions;
using SimPe.Sims2.Data;

namespace SimPe.Sims2.Models.Configuration;

public partial class InstallPath : ObservableObject
{
	[ObservableProperty] private EnumDisplayNameItem<PackageFolders> item = new(PackageFolders.BaseGame);

	[ObservableProperty] private string? path;

	public override string? ToString()
	{
		return Path;
	}
}
