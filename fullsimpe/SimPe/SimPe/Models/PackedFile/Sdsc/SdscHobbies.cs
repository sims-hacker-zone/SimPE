// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using CommunityToolkit.Mvvm.ComponentModel;

namespace SimPe.Models.PackedFile.Sdsc
{
	public partial class SdscHobbies : ObservableObject
	{
		[ObservableProperty]
		private ushort cuisine;

		[ObservableProperty]
		private ushort arts;

		[ObservableProperty]
		private ushort film;

		[ObservableProperty]
		private ushort sports;

		[ObservableProperty]
		private ushort games;

		[ObservableProperty]
		private ushort nature;

		[ObservableProperty]
		private ushort tinkering;

		[ObservableProperty]
		private ushort fitness;

		[ObservableProperty]
		private ushort science;

		[ObservableProperty]
		private ushort music;
	}
}
