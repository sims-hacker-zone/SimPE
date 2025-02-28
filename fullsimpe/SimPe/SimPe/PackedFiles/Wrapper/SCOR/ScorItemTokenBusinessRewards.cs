// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

namespace SimPe.PackedFiles.Wrapper.SCOR
{
	class ScorItemTokenBusinessRewards : IScorItemToken
	{
		ScoreItemBusinessRewards gui;

		public ScorItemTokenBusinessRewards()
		{
			gui = null;
		}

		public byte[] UnserializeToken(ScorItem si, System.IO.BinaryReader reader)
		{
			byte[] data = ScorItem.UnserializeDefaultToken(reader);
			int ct = BitConverter.ToInt16(data, 0);

			gui = new ScoreItemBusinessRewards(si);
			for (int i = 0; i < ct; i++)
			{
				ScoreItemBusinessRewards.Element item =
					new ScoreItemBusinessRewards.Element();
				item.LoadData(reader);
				gui.AddElement(item);
			}

			return data;
		}

		public AScorItem ActivatedGUI => gui;
	}
}
