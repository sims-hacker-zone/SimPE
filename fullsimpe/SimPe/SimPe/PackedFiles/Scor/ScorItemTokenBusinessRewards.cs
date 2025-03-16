// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

using SimPe.PackedFiles.Scor;

namespace SimPe.PackedFiles.Scor
{
	class ScorItemTokenBusinessRewards : IScorItemToken
	{

		public ScorItemTokenBusinessRewards()
		{
		}

		public byte[] UnserializeToken(ScorItem si, System.IO.BinaryReader reader)
		{
			byte[] data = ScorItem.UnserializeDefaultToken(reader);
			int ct = BitConverter.ToInt16(data, 0);

			return data;
		}
	}
}
