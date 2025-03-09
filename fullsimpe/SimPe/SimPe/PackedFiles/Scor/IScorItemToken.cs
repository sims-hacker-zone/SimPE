// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.PackedFiles.Scor;

namespace SimPe.PackedFiles.Scor
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
