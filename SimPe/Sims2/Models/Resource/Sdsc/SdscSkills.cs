// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using CommunityToolkit.Mvvm.ComponentModel;

namespace SimPe.Sims2.Models.Resource.Sdsc;

public partial class SdscSkills : ObservableObject
{
	[ObservableProperty] private ushort cleaning;

	[ObservableProperty] private ushort cooking;

	[ObservableProperty] private ushort charisma;

	[ObservableProperty] private ushort mechanical;

	[ObservableProperty] private ushort creativity;

	[ObservableProperty] private ushort body;

	[ObservableProperty] private ushort logic;
}
