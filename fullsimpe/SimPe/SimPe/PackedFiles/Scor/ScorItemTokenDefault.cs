// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.PackedFiles.Scor;

namespace SimPe.PackedFiles.Scor
{
	class ScorItemTokenDefault : IScorItemToken
	{
		public byte[] UnserializeToken(ScorItem si, System.IO.BinaryReader reader)
		{
			return ScorItem.UnserializeDefaultToken(reader);
		}

		public AScorItem ActivatedGUI => null;
	}
}
