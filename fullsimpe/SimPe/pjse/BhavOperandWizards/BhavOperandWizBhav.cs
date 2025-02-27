/***************************************************************************
 *   Copyright (C) 2006-2008 by Peter L Jones                              *
 *   pljones@users.sf.net                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using pjse.BhavNameWizards;

using SimPe.PackedFiles.Wrapper;

namespace pjse.BhavOperandWizards.WizBhav
{
	internal partial class UI : Form, iBhavOperandWizForm
	{
		public UI()
		{
			InitializeComponent();

			albArg = new Label[]
			{
				lbArg1,
				lbArg2,
				lbArg3,
				lbArg4,
				lbArg5,
				lbArg6,
				lbArg7,
				lbArg8,
			};
			aldoc = new LabelledDataOwner[]
			{
				ldocArg1,
				ldocArg2,
				ldocArg3,
				ldocArg4,
				ldocArg5,
				ldocArg6,
				ldocArg7,
				ldocArg8,
			};
			arbFormat = new List<RadioButton>(
				new RadioButton[] { rbTemps, rbOld, rbNew, rbCallers }
			);

			internalchg = true;
			try
			{
				foreach (LabelledDataOwner ldoc in aldoc)
				{
					ldoc.Decimal = pjse.Settings.PJSE.DecimalDOValue;
					ldoc.UseInstancePicker = pjse.Settings.PJSE.InstancePickerAsText;
				}
			}
			finally
			{
				internalchg = false;
			}

			pjse.Settings.PJSE.DecimalDOValueChanged += new EventHandler(
				PJSE_DecimalDOValueChanged
			);
			pjse.Settings.PJSE.InstancePickerAsTextChanged += new EventHandler(
				PJSE_InstancePickerAsTextChanged
			);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
			pjse.Settings.PJSE.DecimalDOValueChanged -= new EventHandler(
				PJSE_DecimalDOValueChanged
			);
			pjse.Settings.PJSE.InstancePickerAsTextChanged -= new EventHandler(
				PJSE_InstancePickerAsTextChanged
			);
		}

		void PJSE_DecimalDOValueChanged(object sender, EventArgs e)
		{
			if (internalchg)
				return;
			if (ckbDecimal.Checked == pjse.Settings.PJSE.DecimalDOValue)
				return;
			internalchg = true;
			try
			{
				ckbDecimal.Checked = pjse.Settings.PJSE.DecimalDOValue;
			}
			finally
			{
				internalchg = false;
			}
		}

		void PJSE_InstancePickerAsTextChanged(object sender, EventArgs e)
		{
			if (internalchg)
				return;
			if (ckbUseInstancePicker.Checked == pjse.Settings.PJSE.InstancePickerAsText)
				return;
			internalchg = true;
			try
			{
				ckbUseInstancePicker.Checked = pjse.Settings.PJSE.InstancePickerAsText;
			}
			finally
			{
				internalchg = false;
			}
		}

		private bool internalchg = false;
		private byte[] operands = null;
		private Instruction inst = null;
		private byte nodeVersion = 0;
		private byte nrArgs = 0;
		private BhavWizBhav.dataFormat format = BhavWizBhav.dataFormat.useTemps;
		private Label[] albArg = null;
		private LabelledDataOwner[] aldoc = null;
		private List<RadioButton> arbFormat = null;

		private void doFormat()
		{
			byte[] o = operands; // lazy...
			pnWizBhav.SuspendLayout();
			ckbDecimal.Enabled =
				format != BhavWizBhav.dataFormat.useTemps
				&& format != BhavWizBhav.dataFormat.useParams;
			ckbUseInstancePicker.Enabled = format == BhavWizBhav.dataFormat.newFormat;

			for (int i = 0; i < aldoc.Length; i++)
			{
				aldoc[i].Enabled =
					(
						format != BhavWizBhav.dataFormat.useTemps
						&& format != BhavWizBhav.dataFormat.useParams
					) && !(format == BhavWizBhav.dataFormat.newFormat && i >= 4);
				aldoc[i].DataOwnerEnabled = format == BhavWizBhav.dataFormat.newFormat;
				switch (format)
				{
					case BhavWizBhav.dataFormat.useTemps:
						aldoc[i].Value = (ushort)i;
						aldoc[i].DataOwner = 0x08;
						break;
					case BhavWizBhav.dataFormat.useParams:
						aldoc[i].Value = (ushort)i;
						aldoc[i].DataOwner = 0x09;
						break;
					case BhavWizBhav.dataFormat.oldFormat:
						aldoc[i].Value = BhavWiz.ToShort(o[i * 2], o[i * 2 + 1]);
						aldoc[i].DataOwner = 0x07;
						break;
					case BhavWizBhav.dataFormat.newFormat:
						if (i < 4)
						{
							aldoc[i].Value = BhavWiz.ToShort(
								o[(i * 3) + 1],
								o[(i * 3) + 2]
							);
							aldoc[i].DataOwner = o[i * 3];
						}
						else
						{
							aldoc[i].Value = 0;
							aldoc[i].DataOwner = 0x07;
						}
						break;
				}
			}
			pnWizBhav.ResumeLayout();
		}

		private void setFormat(BhavWizBhav.dataFormat newformat)
		{
			if (format == newformat)
				return;
			format = newformat;
			doFormat();
		}

#if foo
		// NV  X72 X1 X0  Kill  P_out    Method
		//  0    ?  ?  0     0      ?    8C0
		//  0    ?  ?  1     0     <9    4OI

		//  0    ?  ?  0     1      ?    TMP
		//  0    ?  ?  1     1      ?    ---


		//  1    ?  0  0     0      ?    8C1
		//  1    ?  0  1     0     <9    4OI
		//  1    ?  1  0     0     <9    PAR
		//  1    0  1  1     0     <9    4OI
		//  1    1  1  1     0      ?    8C1

		//  1    ?  0  0     1      ?    TMP
		//  1    ?  0  1     1      ?    ---
		//  1    ?  1  0     1      ?    ---
		//  1    0  1  1     1      ?    ---
		//  1    1  1  1     1      ?    TMP
#endif

		private void updateOperands()
		{
			switch (format)
			{
				case BhavWizBhav.dataFormat.useTemps:
				case BhavWizBhav.dataFormat.oldFormat:
					if (format == BhavWizBhav.dataFormat.useTemps)
						for (int i = 0; i < 8; i++)
							operands[i] = 0xff;
					else
						for (int i = 0; i < 8; i++)
							BhavWiz.FromShort(ref operands, i * 2, aldoc[i].Value);
					if (nodeVersion == 0)
						operands[12] &= 0xfe;
					else
					{
						if ((operands[12] & 0xfc) == 0xfc)
							operands[12] = 0xff;
						else
							operands[12] &= 0xfc;
					}
					break;
				case BhavWizBhav.dataFormat.newFormat:
					for (int i = 0; i < 4; i++)
					{
						BhavWiz.FromShort(ref operands, i * 3 + 1, aldoc[i].Value);
						operands[i * 3] = aldoc[i].DataOwner;
					}
					if (nodeVersion > 0)
						operands[12] &= 0xfc;
					operands[12] |= 0x01;
					break;
				case BhavWizBhav.dataFormat.useParams:
					operands[12] &= 0xfe;
					operands[12] |= 0x02;
					break;
			}
		}

		private bool useParams => nodeVersion > 0 && (operands[12] & 0x03) == 0x02;
		private bool newFormat => (operands[12] & 0x01) == 0x01
					&& !(nodeVersion > 0 && operands[12] == 0xff);
		private bool oldFormat => !newFormat && !useParams;
		private bool useTemps
		{
			get
			{
				for (int i = 0; i < 8; i++)
					if (operands[i] != 0xFF)
						return false;
				return oldFormat;
			}
		}

		#region iBhavOperandWizForm
		public Panel WizPanel => this.pnWizBhav;

		public void Execute(Instruction inst)
		{
			internalchg = true;

			ckbDecimal.Checked = pjse.Settings.PJSE.DecimalDOValue;
			ckbUseInstancePicker.Checked = pjse.Settings.PJSE.InstancePickerAsText;

			this.inst = inst;
			foreach (LabelledDataOwner ldoc in aldoc)
				ldoc.Instruction = inst;

			nodeVersion = inst.NodeVersion;

			pjse.FileTable.Entry ftEntry = inst.Parent.ResourceByInstance(
				SimPe.Data.MetaData.BHAV_FILE,
				inst.OpCode
			);
			TPRP tprp = null;
			if (ftEntry != null)
			{
				Bhav wrapper = (Bhav)ftEntry.Wrapper;
				tprp = (TPRP)wrapper.SiblingResource(TPRP.TPRPtype);
				nrArgs = wrapper.Header.ArgumentCount;

				this.lbBhavName.Text =
					"0x"
					+ SimPe.Helper.HexString(inst.OpCode)
					+ ": "
					+ wrapper.FileName;
				this.lbArgC.Text = "0x" + SimPe.Helper.HexString(nrArgs);
			}
			else
			{
				this.lbBhavName.Text =
					"0x"
					+ SimPe.Helper.HexString(inst.OpCode)
					+ ": ["
					+ pjse.Localization.GetString("bhavnotfound")
					+ "]";
				this.lbArgC.Text = "(???)";
			}

			operands = new byte[16];
			((byte[])inst.Operands).CopyTo(operands, 0);
			((byte[])inst.Reserved1).CopyTo(operands, 8);

			for (int i = 0; i < nrArgs; i++)
				if (tprp != null && !tprp.TextOnly && i < tprp.ParamCount)
					albArg[i].Text = tprp[false, i].Label;
				else
					albArg[i].Text = pjse.Localization.GetString("unk");
			for (int i = nrArgs; i < albArg.Length; i++)
				albArg[i].Text = pjse.Localization.GetString("bwb_unused");

			format = pjse.BhavNameWizards.BhavWizBhav.opFormat(
				inst.NodeVersion,
				operands
			);

			rbTemps.Checked = format == BhavWizBhav.dataFormat.useTemps;
			rbOld.Checked = format == BhavWizBhav.dataFormat.oldFormat;
			rbNew.Checked = format == BhavWizBhav.dataFormat.newFormat;
			rbCallers.Enabled = nodeVersion > 0;
			rbCallers.Checked = format == BhavWizBhav.dataFormat.useParams;

			doFormat();

			internalchg = false;

			return;
		}

		public Instruction Write(Instruction inst)
		{
			if (inst != null)
			{
				updateOperands();
				for (int i = 0; i < 8; i++)
					inst.Operands[i] = operands[i];
				for (int i = 0; i < 8; i++)
					inst.Reserved1[i] = operands[i + 8];
			}
			return inst;
		}

		#endregion

		private void rb_CheckedChanged(object sender, EventArgs e)
		{
			if (internalchg)
				return;

			int i = arbFormat.IndexOf((RadioButton)sender);
			if (i < 0 || !arbFormat[i].Checked)
				return;

			setFormat(
				(BhavWizBhav.dataFormat)Enum.Parse(format.GetType(), i.ToString())
			);
		}

		private void ckbDecimal_CheckedChanged(object sender, EventArgs e)
		{
			if (internalchg)
				return;
			internalchg = true;
			try
			{
				pjse.Settings.PJSE.DecimalDOValue = ckbDecimal.Checked;
			}
			finally
			{
				internalchg = false;
			}
		}

		private void ckbUseInstancePicker_CheckedChanged(object sender, EventArgs e)
		{
			if (internalchg)
				return;
			internalchg = true;
			try
			{
				pjse.Settings.PJSE.InstancePickerAsText = ckbUseInstancePicker.Checked;
			}
			finally
			{
				internalchg = false;
			}
		}
	}
}

namespace pjse.BhavOperandWizards
{
	public class BhavOperandWizBhav : pjse.ABhavOperandWiz
	{
		public BhavOperandWizBhav(Instruction i)
			: base(i)
		{
			myForm = new WizBhav.UI();
		}

		#region IDisposable Members
		public override void Dispose()
		{
			if (myForm != null)
				myForm = null;
		}
		#endregion
	}
}
