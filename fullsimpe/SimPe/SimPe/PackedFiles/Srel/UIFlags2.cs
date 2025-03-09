// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Data;

namespace SimPe.PackedFiles.Srel
{
	public class UIFlags2 : FlagBase
	{
		public UIFlags2(ushort flags)
			: base(flags) { }

		public bool isBFF
		{
			get => GetBit((byte)MetaData.UIFlags2Names.BestFriendForever);
			set => SetBit((byte)MetaData.UIFlags2Names.BestFriendForever, value);
		}
	}
}
