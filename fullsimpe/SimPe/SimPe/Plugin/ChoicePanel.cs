// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Windows.Forms;

namespace SimPe.Plugin
{
	public partial class ChoicePanel : UserControl
	{
		public ChoicePanel()
		{
			InitializeComponent();
		}
		private const int mm = 100;
		public void setValues(bool labels, string label, string value, PackedFiles.Wrapper.Bcon[] bcon, ushort level)
		{
			Labels = labels;
			lbChoice.Text = label;
			tbChoice.Text = value;
			if (bcon != null)
			{
				lnudCooking.Value = bcon[0][level] / mm;
				lnudMechanical.Value = bcon[1][level] / mm;
				lnudBody.Value = bcon[2][level] / mm;
				lnudCharisma.Value = bcon[3][level] / mm;
				lnudCreativity.Value = bcon[4][level] / mm;
				lnudLogic.Value = bcon[5][level] / mm;
				lnudCleaning.Value = bcon[6][level] / mm;
			}
			else
			{
				lnudCooking.Enabled = lnudMechanical.Enabled = lnudBody.Enabled = lnudCharisma.Enabled =
					lnudCreativity.Enabled = lnudLogic.Enabled = lnudCleaning.Enabled = false;
			}
		}
		public void getValues(PackedFiles.Wrapper.Bcon[] bcon, ushort level)
		{
			bcon[0][level] = (short)(lnudCooking.Value * mm);
			bcon[1][level] = (short)(lnudMechanical.Value * mm);
			bcon[2][level] = (short)(lnudBody.Value * mm);
			bcon[3][level] = (short)(lnudCharisma.Value * mm);
			bcon[4][level] = (short)(lnudCreativity.Value * mm);
			bcon[5][level] = (short)(lnudLogic.Value * mm);
			bcon[6][level] = (short)(lnudCleaning.Value * mm);
		}

		private bool labels = true;
		public bool Labels
		{
			get => labels;
			set
			{
				labels = value;
				lnudCooking.NoLabel = lnudMechanical.NoLabel = lnudBody.NoLabel = lnudCharisma.NoLabel =
					lnudCreativity.NoLabel = lnudLogic.NoLabel = lnudCleaning.NoLabel = !labels;
				MaximumSize = labels ? new System.Drawing.Size(1160, 48) : new System.Drawing.Size(1160, 27);
			}
		}

		private bool hsk = true;
		public bool HaveSkills
		{
			get => hsk;
			set
			{
				if (hsk != value)
				{
					hsk = value;
					lnudCooking.Visible = lnudMechanical.Visible = lnudBody.Visible = lnudCharisma.Visible =
						lnudCreativity.Visible = lnudLogic.Visible = lnudCleaning.Visible = hsk;
				}
			}
		}

		public string Label
		{
			get => lbChoice.Text;
			set => lbChoice.Text = value;
		}
		public string Value
		{
			get => tbChoice.Text;
			set => tbChoice.Text = value;
		}

		public decimal Cooking
		{
			get => lnudCooking.Value;
			set => lnudCooking.Value = value;
		}
		public decimal Mechanical
		{
			get => lnudMechanical.Value;
			set => lnudMechanical.Value = value;
		}
		public decimal Charisma
		{
			get => lnudCharisma.Value;
			set => lnudCharisma.Value = value;
		}
		public decimal Body
		{
			get => lnudBody.Value;
			set => lnudBody.Value = value;
		}
		public decimal Creativity
		{
			get => lnudCreativity.Value;
			set => lnudCreativity.Value = value;
		}
		public decimal Logic
		{
			get => lnudLogic.Value;
			set => lnudLogic.Value = value;
		}
		public decimal Cleaning
		{
			get => lnudCleaning.Value;
			set => lnudCleaning.Value = value;
		}

	}
}
