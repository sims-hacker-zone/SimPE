/***************************************************************************
 *   Copyright (C) 2005 by Peter L Jones                                   *
 *   pljones@users.sf.net                                                  *
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
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
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SimPe.PackedFiles.Wrapper;

namespace pjse.BhavOperandWizards.WizDefault
{
	/// <summary>
	/// Summary description for BhavPrimWizDefault.
	/// </summary>
	internal class UI : System.Windows.Forms.Form, iBhavOperandWizForm
	{
		#region Form variables

		private System.Windows.Forms.TextBox tbInst_Op01_dec;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox tbInst_Unk7;
		private System.Windows.Forms.TextBox tbInst_Unk6;
		private System.Windows.Forms.TextBox tbInst_Unk5;
		private System.Windows.Forms.TextBox tbInst_Unk4;
		private System.Windows.Forms.TextBox tbInst_Unk3;
		private System.Windows.Forms.TextBox tbInst_Unk2;
		private System.Windows.Forms.TextBox tbInst_Unk1;
		private System.Windows.Forms.TextBox tbInst_Unk0;
		private System.Windows.Forms.TextBox tbInst_Op7;
		private System.Windows.Forms.TextBox tbInst_Op6;
		private System.Windows.Forms.TextBox tbInst_Op5;
		private System.Windows.Forms.TextBox tbInst_Op4;
		private System.Windows.Forms.TextBox tbInst_Op3;
		private System.Windows.Forms.TextBox tbInst_Op2;
		private System.Windows.Forms.TextBox tbInst_Op1;
		private System.Windows.Forms.TextBox tbInst_Op0;
		private System.Windows.Forms.TextBox tbInst_Op23_dec;
		private System.Windows.Forms.Label label2;
		internal System.Windows.Forms.Panel pnWizDefault;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public UI()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			TextBox[] iow = { tbInst_Op01_dec, tbInst_Op23_dec };
			alDec16 = new ArrayList(iow);
			TextBox[] iob =
			{
				tbInst_Op0,
				tbInst_Op1,
				tbInst_Op2,
				tbInst_Op3,
				tbInst_Op4,
				tbInst_Op5,
				tbInst_Op6,
				tbInst_Op7,
				tbInst_Unk0,
				tbInst_Unk1,
				tbInst_Unk2,
				tbInst_Unk3,
				tbInst_Unk4,
				tbInst_Unk5,
				tbInst_Unk6,
				tbInst_Unk7,
			};
			alHex8 = new ArrayList(iob);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private Instruction inst;
		private ArrayList alHex8;
		private ArrayList alDec16;

		#region iBhavOperandWizForm
		public Panel WizPanel
		{
			get { return this.pnWizDefault; }
		}

		public void Execute(Instruction inst)
		{
			this.inst = inst;

			this.tbInst_Op01_dec.Text = (
				inst.Operands[0] + (inst.Operands[1] << 8)
			).ToString();
			this.tbInst_Op23_dec.Text = (
				inst.Operands[2] + (inst.Operands[3] << 8)
			).ToString();

			this.tbInst_Op0.Text = SimPe.Helper.HexString(inst.Operands[0]);
			this.tbInst_Op1.Text = SimPe.Helper.HexString(inst.Operands[1]);
			this.tbInst_Op2.Text = SimPe.Helper.HexString(inst.Operands[2]);
			this.tbInst_Op3.Text = SimPe.Helper.HexString(inst.Operands[3]);
			this.tbInst_Op4.Text = SimPe.Helper.HexString(inst.Operands[4]);
			this.tbInst_Op5.Text = SimPe.Helper.HexString(inst.Operands[5]);
			this.tbInst_Op6.Text = SimPe.Helper.HexString(inst.Operands[6]);
			this.tbInst_Op7.Text = SimPe.Helper.HexString(inst.Operands[7]);

			this.tbInst_Unk0.Text = SimPe.Helper.HexString(inst.Reserved1[0]);
			this.tbInst_Unk1.Text = SimPe.Helper.HexString(inst.Reserved1[1]);
			this.tbInst_Unk2.Text = SimPe.Helper.HexString(inst.Reserved1[2]);
			this.tbInst_Unk3.Text = SimPe.Helper.HexString(inst.Reserved1[3]);
			this.tbInst_Unk4.Text = SimPe.Helper.HexString(inst.Reserved1[4]);
			this.tbInst_Unk5.Text = SimPe.Helper.HexString(inst.Reserved1[5]);
			this.tbInst_Unk6.Text = SimPe.Helper.HexString(inst.Reserved1[6]);
			this.tbInst_Unk7.Text = SimPe.Helper.HexString(inst.Reserved1[7]);
		}

		public Instruction Write(Instruction inst)
		{
			return inst;
		}

		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(typeof(UI));
			this.pnWizDefault = new System.Windows.Forms.Panel();
			this.tbInst_Op01_dec = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.tbInst_Unk7 = new System.Windows.Forms.TextBox();
			this.tbInst_Unk6 = new System.Windows.Forms.TextBox();
			this.tbInst_Unk5 = new System.Windows.Forms.TextBox();
			this.tbInst_Unk4 = new System.Windows.Forms.TextBox();
			this.tbInst_Unk3 = new System.Windows.Forms.TextBox();
			this.tbInst_Unk2 = new System.Windows.Forms.TextBox();
			this.tbInst_Unk1 = new System.Windows.Forms.TextBox();
			this.tbInst_Unk0 = new System.Windows.Forms.TextBox();
			this.tbInst_Op7 = new System.Windows.Forms.TextBox();
			this.tbInst_Op6 = new System.Windows.Forms.TextBox();
			this.tbInst_Op5 = new System.Windows.Forms.TextBox();
			this.tbInst_Op4 = new System.Windows.Forms.TextBox();
			this.tbInst_Op3 = new System.Windows.Forms.TextBox();
			this.tbInst_Op2 = new System.Windows.Forms.TextBox();
			this.tbInst_Op1 = new System.Windows.Forms.TextBox();
			this.tbInst_Op0 = new System.Windows.Forms.TextBox();
			this.tbInst_Op23_dec = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.pnWizDefault.SuspendLayout();
			this.SuspendLayout();
			//
			// pnWizDefault
			//
			this.pnWizDefault.Controls.Add(this.tbInst_Op01_dec);
			this.pnWizDefault.Controls.Add(this.label13);
			this.pnWizDefault.Controls.Add(this.tbInst_Unk7);
			this.pnWizDefault.Controls.Add(this.tbInst_Unk6);
			this.pnWizDefault.Controls.Add(this.tbInst_Unk5);
			this.pnWizDefault.Controls.Add(this.tbInst_Unk4);
			this.pnWizDefault.Controls.Add(this.tbInst_Unk3);
			this.pnWizDefault.Controls.Add(this.tbInst_Unk2);
			this.pnWizDefault.Controls.Add(this.tbInst_Unk1);
			this.pnWizDefault.Controls.Add(this.tbInst_Unk0);
			this.pnWizDefault.Controls.Add(this.tbInst_Op7);
			this.pnWizDefault.Controls.Add(this.tbInst_Op6);
			this.pnWizDefault.Controls.Add(this.tbInst_Op5);
			this.pnWizDefault.Controls.Add(this.tbInst_Op4);
			this.pnWizDefault.Controls.Add(this.tbInst_Op3);
			this.pnWizDefault.Controls.Add(this.tbInst_Op2);
			this.pnWizDefault.Controls.Add(this.tbInst_Op1);
			this.pnWizDefault.Controls.Add(this.tbInst_Op0);
			this.pnWizDefault.Controls.Add(this.tbInst_Op23_dec);
			this.pnWizDefault.Controls.Add(this.label2);
			resources.ApplyResources(this.pnWizDefault, "pnWizDefault");
			this.pnWizDefault.Name = "pnWizDefault";
			//
			// tbInst_Op01_dec
			//
			resources.ApplyResources(this.tbInst_Op01_dec, "tbInst_Op01_dec");
			this.tbInst_Op01_dec.Name = "tbInst_Op01_dec";
			this.tbInst_Op01_dec.Validated += new System.EventHandler(
				this.dec16_Validated
			);
			this.tbInst_Op01_dec.Validating +=
				new System.ComponentModel.CancelEventHandler(this.dec16_Validating);
			//
			// label13
			//
			resources.ApplyResources(this.label13, "label13");
			this.label13.Name = "label13";
			//
			// tbInst_Unk7
			//
			resources.ApplyResources(this.tbInst_Unk7, "tbInst_Unk7");
			this.tbInst_Unk7.Name = "tbInst_Unk7";
			this.tbInst_Unk7.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbInst_Unk7.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// tbInst_Unk6
			//
			resources.ApplyResources(this.tbInst_Unk6, "tbInst_Unk6");
			this.tbInst_Unk6.Name = "tbInst_Unk6";
			this.tbInst_Unk6.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbInst_Unk6.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// tbInst_Unk5
			//
			resources.ApplyResources(this.tbInst_Unk5, "tbInst_Unk5");
			this.tbInst_Unk5.Name = "tbInst_Unk5";
			this.tbInst_Unk5.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbInst_Unk5.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// tbInst_Unk4
			//
			resources.ApplyResources(this.tbInst_Unk4, "tbInst_Unk4");
			this.tbInst_Unk4.Name = "tbInst_Unk4";
			this.tbInst_Unk4.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbInst_Unk4.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// tbInst_Unk3
			//
			resources.ApplyResources(this.tbInst_Unk3, "tbInst_Unk3");
			this.tbInst_Unk3.Name = "tbInst_Unk3";
			this.tbInst_Unk3.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbInst_Unk3.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// tbInst_Unk2
			//
			resources.ApplyResources(this.tbInst_Unk2, "tbInst_Unk2");
			this.tbInst_Unk2.Name = "tbInst_Unk2";
			this.tbInst_Unk2.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbInst_Unk2.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// tbInst_Unk1
			//
			resources.ApplyResources(this.tbInst_Unk1, "tbInst_Unk1");
			this.tbInst_Unk1.Name = "tbInst_Unk1";
			this.tbInst_Unk1.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbInst_Unk1.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// tbInst_Unk0
			//
			resources.ApplyResources(this.tbInst_Unk0, "tbInst_Unk0");
			this.tbInst_Unk0.Name = "tbInst_Unk0";
			this.tbInst_Unk0.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbInst_Unk0.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// tbInst_Op7
			//
			resources.ApplyResources(this.tbInst_Op7, "tbInst_Op7");
			this.tbInst_Op7.Name = "tbInst_Op7";
			this.tbInst_Op7.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbInst_Op7.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// tbInst_Op6
			//
			resources.ApplyResources(this.tbInst_Op6, "tbInst_Op6");
			this.tbInst_Op6.Name = "tbInst_Op6";
			this.tbInst_Op6.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbInst_Op6.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// tbInst_Op5
			//
			resources.ApplyResources(this.tbInst_Op5, "tbInst_Op5");
			this.tbInst_Op5.Name = "tbInst_Op5";
			this.tbInst_Op5.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbInst_Op5.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// tbInst_Op4
			//
			resources.ApplyResources(this.tbInst_Op4, "tbInst_Op4");
			this.tbInst_Op4.Name = "tbInst_Op4";
			this.tbInst_Op4.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbInst_Op4.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// tbInst_Op3
			//
			resources.ApplyResources(this.tbInst_Op3, "tbInst_Op3");
			this.tbInst_Op3.Name = "tbInst_Op3";
			this.tbInst_Op3.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbInst_Op3.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// tbInst_Op2
			//
			resources.ApplyResources(this.tbInst_Op2, "tbInst_Op2");
			this.tbInst_Op2.Name = "tbInst_Op2";
			this.tbInst_Op2.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbInst_Op2.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// tbInst_Op1
			//
			resources.ApplyResources(this.tbInst_Op1, "tbInst_Op1");
			this.tbInst_Op1.Name = "tbInst_Op1";
			this.tbInst_Op1.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbInst_Op1.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// tbInst_Op0
			//
			resources.ApplyResources(this.tbInst_Op0, "tbInst_Op0");
			this.tbInst_Op0.Name = "tbInst_Op0";
			this.tbInst_Op0.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbInst_Op0.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// tbInst_Op23_dec
			//
			resources.ApplyResources(this.tbInst_Op23_dec, "tbInst_Op23_dec");
			this.tbInst_Op23_dec.Name = "tbInst_Op23_dec";
			this.tbInst_Op23_dec.Validated += new System.EventHandler(
				this.dec16_Validated
			);
			this.tbInst_Op23_dec.Validating +=
				new System.ComponentModel.CancelEventHandler(this.dec16_Validating);
			//
			// label2
			//
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			//
			// UI
			//
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.pnWizDefault);
			this.Name = "UI";
			this.pnWizDefault.ResumeLayout(false);
			this.pnWizDefault.PerformLayout();
			this.ResumeLayout(false);
		}
		#endregion

		private void hex8_Validating(
			object sender,
			System.ComponentModel.CancelEventArgs e
		)
		{
			try
			{
				Convert.ToByte(((TextBox)sender).Text, 16);
			}
			catch (Exception)
			{
				e.Cancel = true;
			}
		}

		private void hex8_Validated(object sender, System.EventArgs e)
		{
			byte val = Convert.ToByte(((TextBox)sender).Text, 16);

			int i = alHex8.IndexOf(sender);

			if (i < 8)
			{
				if (inst.Operands[i] != val)
				{
					inst.Operands[i] = val;
				}
				this.tbInst_Op01_dec.Text = (
					inst.Operands[0] + (inst.Operands[1] << 8)
				).ToString();
				this.tbInst_Op23_dec.Text = (
					inst.Operands[2] + (inst.Operands[3] << 8)
				).ToString();
			}
			else
			{
				if (i < 16)
				{
					if (inst.Reserved1[i - 8] != val)
					{
						inst.Reserved1[i - 8] = val;
					}
				}
				else
					throw new Exception(
						"hex8_Validated not applicable to control " + sender.ToString()
					);
			}
		}

		private void dec16_Validating(
			object sender,
			System.ComponentModel.CancelEventArgs e
		)
		{
			try
			{
				Convert.ToUInt16(((TextBox)sender).Text);
			}
			catch (Exception)
			{
				e.Cancel = true;
			}
		}

		private void dec16_Validated(object sender, System.EventArgs e)
		{
			ushort val = Convert.ToUInt16(((TextBox)sender).Text);

			int i = alDec16.IndexOf(sender) * 2;

			if (i > 2)
				throw new Exception(
					"dec16_Validated not applicable to control " + sender.ToString()
				);

			byte v0 = inst.Operands[i];
			byte v1 = inst.Operands[i + 1];
			ushort cv = (ushort)(v0 + (v1 * 256));
			if (cv != val)
			{
				inst.Operands[i] = (byte)(val & 0xFF);
				((TextBox)this.alHex8[i]).Text = SimPe.Helper.HexString(
					inst.Operands[i]
				);
				inst.Operands[i + 1] = (byte)((val >> 8) & 0xFF);
				((TextBox)this.alHex8[i + 1]).Text = SimPe.Helper.HexString(
					inst.Operands[i + 1]
				);
			}
		}
	}
}

namespace pjse.BhavOperandWizards
{
	public class BhavOperandWizDefault : pjse.ABhavOperandWiz
	{
		public BhavOperandWizDefault(Instruction i)
			: base(i)
		{
			myForm = new WizDefault.UI();
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
