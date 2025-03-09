// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Windows.Forms;

using SimPe.PackedFiles.Bhav;
using SimPe.PackedFiles.Wrapper;

namespace pjse.BhavOperandWizards.WizDefault
{
	/// <summary>
	/// Summary description for BhavPrimWizDefault.
	/// </summary>
	internal class UI : Form, iBhavOperandWizForm
	{
		#region Form variables

		private TextBox tbInst_Op01_dec;
		private Label label13;
		private TextBox tbInst_Unk7;
		private TextBox tbInst_Unk6;
		private TextBox tbInst_Unk5;
		private TextBox tbInst_Unk4;
		private TextBox tbInst_Unk3;
		private TextBox tbInst_Unk2;
		private TextBox tbInst_Unk1;
		private TextBox tbInst_Unk0;
		private TextBox tbInst_Op7;
		private TextBox tbInst_Op6;
		private TextBox tbInst_Op5;
		private TextBox tbInst_Op4;
		private TextBox tbInst_Op3;
		private TextBox tbInst_Op2;
		private TextBox tbInst_Op1;
		private TextBox tbInst_Op0;
		private TextBox tbInst_Op23_dec;
		private Label label2;
		internal Panel pnWizDefault;

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
				components?.Dispose();
			}
			base.Dispose(disposing);
		}

		private Instruction inst;
		private ArrayList alHex8;
		private ArrayList alDec16;

		#region iBhavOperandWizForm
		public Panel WizPanel => pnWizDefault;

		public void Execute(Instruction inst)
		{
			this.inst = inst;

			tbInst_Op01_dec.Text = (
				inst.Operands[0] + (inst.Operands[1] << 8)
			).ToString();
			tbInst_Op23_dec.Text = (
				inst.Operands[2] + (inst.Operands[3] << 8)
			).ToString();

			tbInst_Op0.Text = SimPe.Helper.HexString(inst.Operands[0]);
			tbInst_Op1.Text = SimPe.Helper.HexString(inst.Operands[1]);
			tbInst_Op2.Text = SimPe.Helper.HexString(inst.Operands[2]);
			tbInst_Op3.Text = SimPe.Helper.HexString(inst.Operands[3]);
			tbInst_Op4.Text = SimPe.Helper.HexString(inst.Operands[4]);
			tbInst_Op5.Text = SimPe.Helper.HexString(inst.Operands[5]);
			tbInst_Op6.Text = SimPe.Helper.HexString(inst.Operands[6]);
			tbInst_Op7.Text = SimPe.Helper.HexString(inst.Operands[7]);

			tbInst_Unk0.Text = SimPe.Helper.HexString(inst.Reserved1[0]);
			tbInst_Unk1.Text = SimPe.Helper.HexString(inst.Reserved1[1]);
			tbInst_Unk2.Text = SimPe.Helper.HexString(inst.Reserved1[2]);
			tbInst_Unk3.Text = SimPe.Helper.HexString(inst.Reserved1[3]);
			tbInst_Unk4.Text = SimPe.Helper.HexString(inst.Reserved1[4]);
			tbInst_Unk5.Text = SimPe.Helper.HexString(inst.Reserved1[5]);
			tbInst_Unk6.Text = SimPe.Helper.HexString(inst.Reserved1[6]);
			tbInst_Unk7.Text = SimPe.Helper.HexString(inst.Reserved1[7]);
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
			pnWizDefault = new Panel();
			tbInst_Op01_dec = new TextBox();
			label13 = new Label();
			tbInst_Unk7 = new TextBox();
			tbInst_Unk6 = new TextBox();
			tbInst_Unk5 = new TextBox();
			tbInst_Unk4 = new TextBox();
			tbInst_Unk3 = new TextBox();
			tbInst_Unk2 = new TextBox();
			tbInst_Unk1 = new TextBox();
			tbInst_Unk0 = new TextBox();
			tbInst_Op7 = new TextBox();
			tbInst_Op6 = new TextBox();
			tbInst_Op5 = new TextBox();
			tbInst_Op4 = new TextBox();
			tbInst_Op3 = new TextBox();
			tbInst_Op2 = new TextBox();
			tbInst_Op1 = new TextBox();
			tbInst_Op0 = new TextBox();
			tbInst_Op23_dec = new TextBox();
			label2 = new Label();
			pnWizDefault.SuspendLayout();
			SuspendLayout();
			//
			// pnWizDefault
			//
			pnWizDefault.Controls.Add(tbInst_Op01_dec);
			pnWizDefault.Controls.Add(label13);
			pnWizDefault.Controls.Add(tbInst_Unk7);
			pnWizDefault.Controls.Add(tbInst_Unk6);
			pnWizDefault.Controls.Add(tbInst_Unk5);
			pnWizDefault.Controls.Add(tbInst_Unk4);
			pnWizDefault.Controls.Add(tbInst_Unk3);
			pnWizDefault.Controls.Add(tbInst_Unk2);
			pnWizDefault.Controls.Add(tbInst_Unk1);
			pnWizDefault.Controls.Add(tbInst_Unk0);
			pnWizDefault.Controls.Add(tbInst_Op7);
			pnWizDefault.Controls.Add(tbInst_Op6);
			pnWizDefault.Controls.Add(tbInst_Op5);
			pnWizDefault.Controls.Add(tbInst_Op4);
			pnWizDefault.Controls.Add(tbInst_Op3);
			pnWizDefault.Controls.Add(tbInst_Op2);
			pnWizDefault.Controls.Add(tbInst_Op1);
			pnWizDefault.Controls.Add(tbInst_Op0);
			pnWizDefault.Controls.Add(tbInst_Op23_dec);
			pnWizDefault.Controls.Add(label2);
			resources.ApplyResources(pnWizDefault, "pnWizDefault");
			pnWizDefault.Name = "pnWizDefault";
			//
			// tbInst_Op01_dec
			//
			resources.ApplyResources(tbInst_Op01_dec, "tbInst_Op01_dec");
			tbInst_Op01_dec.Name = "tbInst_Op01_dec";
			tbInst_Op01_dec.Validated += new EventHandler(
				dec16_Validated
			);
			tbInst_Op01_dec.Validating +=
				new System.ComponentModel.CancelEventHandler(dec16_Validating);
			//
			// label13
			//
			resources.ApplyResources(label13, "label13");
			label13.Name = "label13";
			//
			// tbInst_Unk7
			//
			resources.ApplyResources(tbInst_Unk7, "tbInst_Unk7");
			tbInst_Unk7.Name = "tbInst_Unk7";
			tbInst_Unk7.Validated += new EventHandler(hex8_Validated);
			tbInst_Unk7.Validating += new System.ComponentModel.CancelEventHandler(
				hex8_Validating
			);
			//
			// tbInst_Unk6
			//
			resources.ApplyResources(tbInst_Unk6, "tbInst_Unk6");
			tbInst_Unk6.Name = "tbInst_Unk6";
			tbInst_Unk6.Validated += new EventHandler(hex8_Validated);
			tbInst_Unk6.Validating += new System.ComponentModel.CancelEventHandler(
				hex8_Validating
			);
			//
			// tbInst_Unk5
			//
			resources.ApplyResources(tbInst_Unk5, "tbInst_Unk5");
			tbInst_Unk5.Name = "tbInst_Unk5";
			tbInst_Unk5.Validated += new EventHandler(hex8_Validated);
			tbInst_Unk5.Validating += new System.ComponentModel.CancelEventHandler(
				hex8_Validating
			);
			//
			// tbInst_Unk4
			//
			resources.ApplyResources(tbInst_Unk4, "tbInst_Unk4");
			tbInst_Unk4.Name = "tbInst_Unk4";
			tbInst_Unk4.Validated += new EventHandler(hex8_Validated);
			tbInst_Unk4.Validating += new System.ComponentModel.CancelEventHandler(
				hex8_Validating
			);
			//
			// tbInst_Unk3
			//
			resources.ApplyResources(tbInst_Unk3, "tbInst_Unk3");
			tbInst_Unk3.Name = "tbInst_Unk3";
			tbInst_Unk3.Validated += new EventHandler(hex8_Validated);
			tbInst_Unk3.Validating += new System.ComponentModel.CancelEventHandler(
				hex8_Validating
			);
			//
			// tbInst_Unk2
			//
			resources.ApplyResources(tbInst_Unk2, "tbInst_Unk2");
			tbInst_Unk2.Name = "tbInst_Unk2";
			tbInst_Unk2.Validated += new EventHandler(hex8_Validated);
			tbInst_Unk2.Validating += new System.ComponentModel.CancelEventHandler(
				hex8_Validating
			);
			//
			// tbInst_Unk1
			//
			resources.ApplyResources(tbInst_Unk1, "tbInst_Unk1");
			tbInst_Unk1.Name = "tbInst_Unk1";
			tbInst_Unk1.Validated += new EventHandler(hex8_Validated);
			tbInst_Unk1.Validating += new System.ComponentModel.CancelEventHandler(
				hex8_Validating
			);
			//
			// tbInst_Unk0
			//
			resources.ApplyResources(tbInst_Unk0, "tbInst_Unk0");
			tbInst_Unk0.Name = "tbInst_Unk0";
			tbInst_Unk0.Validated += new EventHandler(hex8_Validated);
			tbInst_Unk0.Validating += new System.ComponentModel.CancelEventHandler(
				hex8_Validating
			);
			//
			// tbInst_Op7
			//
			resources.ApplyResources(tbInst_Op7, "tbInst_Op7");
			tbInst_Op7.Name = "tbInst_Op7";
			tbInst_Op7.Validated += new EventHandler(hex8_Validated);
			tbInst_Op7.Validating += new System.ComponentModel.CancelEventHandler(
				hex8_Validating
			);
			//
			// tbInst_Op6
			//
			resources.ApplyResources(tbInst_Op6, "tbInst_Op6");
			tbInst_Op6.Name = "tbInst_Op6";
			tbInst_Op6.Validated += new EventHandler(hex8_Validated);
			tbInst_Op6.Validating += new System.ComponentModel.CancelEventHandler(
				hex8_Validating
			);
			//
			// tbInst_Op5
			//
			resources.ApplyResources(tbInst_Op5, "tbInst_Op5");
			tbInst_Op5.Name = "tbInst_Op5";
			tbInst_Op5.Validated += new EventHandler(hex8_Validated);
			tbInst_Op5.Validating += new System.ComponentModel.CancelEventHandler(
				hex8_Validating
			);
			//
			// tbInst_Op4
			//
			resources.ApplyResources(tbInst_Op4, "tbInst_Op4");
			tbInst_Op4.Name = "tbInst_Op4";
			tbInst_Op4.Validated += new EventHandler(hex8_Validated);
			tbInst_Op4.Validating += new System.ComponentModel.CancelEventHandler(
				hex8_Validating
			);
			//
			// tbInst_Op3
			//
			resources.ApplyResources(tbInst_Op3, "tbInst_Op3");
			tbInst_Op3.Name = "tbInst_Op3";
			tbInst_Op3.Validated += new EventHandler(hex8_Validated);
			tbInst_Op3.Validating += new System.ComponentModel.CancelEventHandler(
				hex8_Validating
			);
			//
			// tbInst_Op2
			//
			resources.ApplyResources(tbInst_Op2, "tbInst_Op2");
			tbInst_Op2.Name = "tbInst_Op2";
			tbInst_Op2.Validated += new EventHandler(hex8_Validated);
			tbInst_Op2.Validating += new System.ComponentModel.CancelEventHandler(
				hex8_Validating
			);
			//
			// tbInst_Op1
			//
			resources.ApplyResources(tbInst_Op1, "tbInst_Op1");
			tbInst_Op1.Name = "tbInst_Op1";
			tbInst_Op1.Validated += new EventHandler(hex8_Validated);
			tbInst_Op1.Validating += new System.ComponentModel.CancelEventHandler(
				hex8_Validating
			);
			//
			// tbInst_Op0
			//
			resources.ApplyResources(tbInst_Op0, "tbInst_Op0");
			tbInst_Op0.Name = "tbInst_Op0";
			tbInst_Op0.Validated += new EventHandler(hex8_Validated);
			tbInst_Op0.Validating += new System.ComponentModel.CancelEventHandler(
				hex8_Validating
			);
			//
			// tbInst_Op23_dec
			//
			resources.ApplyResources(tbInst_Op23_dec, "tbInst_Op23_dec");
			tbInst_Op23_dec.Name = "tbInst_Op23_dec";
			tbInst_Op23_dec.Validated += new EventHandler(
				dec16_Validated
			);
			tbInst_Op23_dec.Validating +=
				new System.ComponentModel.CancelEventHandler(dec16_Validating);
			//
			// label2
			//
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			//
			// UI
			//
			resources.ApplyResources(this, "$this");
			Controls.Add(pnWizDefault);
			Name = "UI";
			pnWizDefault.ResumeLayout(false);
			pnWizDefault.PerformLayout();
			ResumeLayout(false);
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

		private void hex8_Validated(object sender, EventArgs e)
		{
			byte val = Convert.ToByte(((TextBox)sender).Text, 16);

			int i = alHex8.IndexOf(sender);

			if (i < 8)
			{
				if (inst.Operands[i] != val)
				{
					inst.Operands[i] = val;
				}
				tbInst_Op01_dec.Text = (
					inst.Operands[0] + (inst.Operands[1] << 8)
				).ToString();
				tbInst_Op23_dec.Text = (
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
				{
					throw new Exception(
						"hex8_Validated not applicable to control " + sender.ToString()
					);
				}
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

		private void dec16_Validated(object sender, EventArgs e)
		{
			ushort val = Convert.ToUInt16(((TextBox)sender).Text);

			int i = alDec16.IndexOf(sender) * 2;

			if (i > 2)
			{
				throw new Exception(
					"dec16_Validated not applicable to control " + sender.ToString()
				);
			}

			byte v0 = inst.Operands[i];
			byte v1 = inst.Operands[i + 1];
			ushort cv = (ushort)(v0 + (v1 * 256));
			if (cv != val)
			{
				inst.Operands[i] = (byte)(val & 0xFF);
				((TextBox)alHex8[i]).Text = SimPe.Helper.HexString(
					inst.Operands[i]
				);
				inst.Operands[i + 1] = (byte)((val >> 8) & 0xFF);
				((TextBox)alHex8[i + 1]).Text = SimPe.Helper.HexString(
					inst.Operands[i + 1]
				);
			}
		}
	}
}

namespace pjse.BhavOperandWizards
{
	public class BhavOperandWizDefault : ABhavOperandWiz
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
			{
				myForm = null;
			}
		}
		#endregion
	}
}
