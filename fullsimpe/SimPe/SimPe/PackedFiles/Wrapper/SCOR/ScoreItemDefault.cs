// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace SimPe.PackedFiles.Wrapper.SCOR
{
	public partial class ScoreItemDefault : AScorItem
	{
		public ScoreItemDefault(ScorItem si)
			: base(si)
		{
			InitializeComponent();
			data = new byte[0];
		}

		protected override void DoSetData(string name, System.IO.BinaryReader reader)
		{
			textBox1.Text = name;
			data = reader.ReadBytes((int)reader.BaseStream.Length);

			tb.Text = Helper.BytesToHexList(data, 4);
		}

		byte[] data;

		internal override void Serialize(System.IO.BinaryWriter writer, bool last)
		{
			base.Serialize(writer, last);
			writer.Write(data);
		}
	}
}
