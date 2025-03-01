// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace SimPe.PackedFiles.Wrapper.SCOR
{
	interface IScorItemToken
	{
		byte[] UnserializeToken(ScorItem si, System.IO.BinaryReader reader);

		AScorItem ActivatedGUI
		{
			get;
		}
	}
}
