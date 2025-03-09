// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Windows.Forms;

using SimPe.PackedFiles.Scor;

namespace SimPe.PackedFiles.Scor
{
	public partial class ScoreItemBusinessRewards : AScorItem
	{
		public ScoreItemBusinessRewards(ScorItem si)
			: base(si)
		{
			InitializeComponent();
		}

		internal void AddElement(Element e)
		{
			if (e == null)
			{
				return;
			}

			lb.Items.Add(e);
		}

		protected void RemoveElement(Element e)
		{
			if (e == null)
			{
				return;
			}

			int i = lb.SelectedIndex;
			lb.Items.Remove(e);

			if (i < lb.Items.Count)
			{
				lb.SelectedIndex = i;
			}
			else if (i - 1 < lb.Items.Count && i > 0)
			{
				lb.SelectedIndex = i - 1;
			}
		}

		protected override void DoSetData(string name, System.IO.BinaryReader reader)
		{
			throw new Exception("SetData should not get called for a Business Reward!");
		}

		internal override void Serialize(System.IO.BinaryWriter writer, bool last)
		{
			base.Serialize(writer, last);
			writer.Write((short)lb.Items.Count);
			writer.Write((byte)0);
			ScorItem.SerializeDefaultToken(writer, last && lb.Items.Count == 0);
			for (int i = 0; i < lb.Items.Count; i++)
			{
				Element e =
					lb.Items[i] as Element;
				e.SaveData(writer, last && i == lb.Items.Count - 1);
			}
		}

		private void lb_SelectedIndexChanged(object sender, EventArgs e)
		{
			llRemove.Enabled = lb.SelectedItem != null;
		}

		private void llRemove_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			RemoveElement(lb.SelectedItem as Element);
		}
	}
}
