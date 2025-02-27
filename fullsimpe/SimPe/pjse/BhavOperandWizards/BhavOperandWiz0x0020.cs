/***************************************************************************
 *   Copyright (C) 2005 by Peter L Jones                                   *
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
 *   59 Temple Place - Suite 330, Boston, MA  32111-1307, USA.             *
 ***************************************************************************/
using System;
using System.Windows.Forms;

using SimPe.PackedFiles.Wrapper;

namespace pjse.BhavOperandWizards.Wiz0x0020
{
	/// <summary>
	/// Summary description for StrBig.
	/// </summary>
	internal class UI : Form, iBhavOperandWizForm
	{
		#region Form variables

		internal Panel pnWiz0x001f;
		private FlowLayoutPanel flowLayoutPanel1;
		private Label label1;
		private Panel pnObject;
		private CheckBox cbAttrPicker;
		private CheckBox cbDecimal;
		private ComboBox cbPicker1;
		private TextBox tbVal1;
		private ComboBox cbDataOwner1;
		private Label label2;
		private FlowLayoutPanel flowLayoutPanel2;
		private TextBox tbGUID;
		private Label lbGUIDText;
		private CheckBox ckbNID;
		private CheckBox ckbTemp01;
		private CheckBox ckbOrigGUID;

		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public UI()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
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

			inst = null;
		}

		private Instruction inst = null;
		private DataOwnerControl doid1 = null;
		private bool internalchg = false;

		private bool hex32_IsValid(object sender)
		{
			try
			{
				Convert.ToUInt32(((TextBox)sender).Text, 16);
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		private void setGUID(byte[] o, int sub)
		{
			setGUID(
				true,
				(uint)(o[sub] | (o[sub + 1] << 8) | (o[sub + 2] << 16) | (o[sub + 3] << 24))
			);
		}

		private void setGUID(bool setTB, uint guid)
		{
			if (setTB)
			{
				tbGUID.Text = "0x" + SimPe.Helper.HexString(guid);
			}

			lbGUIDText.Text = BhavWiz.FormatGUID(true, guid);
		}

		#region iBhavOperandWizForm
		public Panel WizPanel => pnWiz0x001f;

		public void Execute(Instruction inst)
		{
			this.inst = inst;

			wrappedByteArray ops1 = inst.Operands;
			wrappedByteArray ops2 = inst.Reserved1;

			internalchg = true;

			setGUID(ops1, 0);

			doid1 = new DataOwnerControl(
				inst,
				cbDataOwner1,
				cbPicker1,
				tbVal1,
				cbDecimal,
				cbAttrPicker,
				null,
				ops1[0x06],
				BhavWiz.ToShort(ops1[0x04], ops1[0x05])
			);

			Boolset ops1_7 = ops1[0x07];
			ckbOrigGUID.Checked = ops1_7[0];
			ckbNID.Checked = ops1_7[1];
			ckbTemp01.Checked = ops1_7[2];

			internalchg = false;
		}

		public Instruction Write(Instruction inst)
		{
			if (inst != null)
			{
				wrappedByteArray ops1 = inst.Operands;
				wrappedByteArray ops2 = inst.Reserved1;

				uint val = Convert.ToUInt32(tbGUID.Text, 16);
				ops1[0x00] = (byte)(val & 0xff);
				ops1[0x01] = (byte)((val >> 8) & 0xff);
				ops1[0x02] = (byte)((val >> 16) & 0xff);
				ops1[0x03] = (byte)((val >> 24) & 0xff);

				ops1[0x06] = doid1.DataOwner;
				ops1[0x04] = (byte)(doid1.Value & 0xff);
				ops1[0x05] = (byte)((doid1.Value >> 8) & 0xff);

				Boolset ops1_7 = ops1[0x07];
				ops1_7[0] = ckbOrigGUID.Checked;
				ops1_7[1] = ckbNID.Checked;
				ops1_7[2] = ckbTemp01.Checked;
				ops1[0x07] = ops1_7;
			}
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
			pnWiz0x001f = new Panel();
			flowLayoutPanel1 = new FlowLayoutPanel();
			label1 = new Label();
			pnObject = new Panel();
			cbAttrPicker = new CheckBox();
			cbDecimal = new CheckBox();
			cbPicker1 = new ComboBox();
			tbVal1 = new TextBox();
			cbDataOwner1 = new ComboBox();
			ckbNID = new CheckBox();
			ckbOrigGUID = new CheckBox();
			label2 = new Label();
			flowLayoutPanel2 = new FlowLayoutPanel();
			tbGUID = new TextBox();
			lbGUIDText = new Label();
			ckbTemp01 = new CheckBox();
			pnWiz0x001f.SuspendLayout();
			flowLayoutPanel1.SuspendLayout();
			pnObject.SuspendLayout();
			flowLayoutPanel2.SuspendLayout();
			SuspendLayout();
			//
			// pnWiz0x001f
			//
			pnWiz0x001f.Controls.Add(flowLayoutPanel1);
			resources.ApplyResources(pnWiz0x001f, "pnWiz0x001f");
			pnWiz0x001f.Name = "pnWiz0x001f";
			//
			// flowLayoutPanel1
			//
			flowLayoutPanel1.Controls.Add(label1);
			flowLayoutPanel1.Controls.Add(pnObject);
			flowLayoutPanel1.Controls.Add(ckbNID);
			flowLayoutPanel1.Controls.Add(ckbOrigGUID);
			flowLayoutPanel1.Controls.Add(label2);
			flowLayoutPanel1.Controls.Add(flowLayoutPanel2);
			flowLayoutPanel1.Controls.Add(ckbTemp01);
			resources.ApplyResources(flowLayoutPanel1, "flowLayoutPanel1");
			flowLayoutPanel1.Name = "flowLayoutPanel1";
			//
			// label1
			//
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			//
			// pnObject
			//
			pnObject.BorderStyle = BorderStyle.FixedSingle;
			pnObject.Controls.Add(cbAttrPicker);
			pnObject.Controls.Add(cbDecimal);
			pnObject.Controls.Add(cbPicker1);
			pnObject.Controls.Add(tbVal1);
			pnObject.Controls.Add(cbDataOwner1);
			resources.ApplyResources(pnObject, "pnObject");
			pnObject.Name = "pnObject";
			//
			// cbAttrPicker
			//
			resources.ApplyResources(cbAttrPicker, "cbAttrPicker");
			cbAttrPicker.Name = "cbAttrPicker";
			//
			// cbDecimal
			//
			resources.ApplyResources(cbDecimal, "cbDecimal");
			cbDecimal.Name = "cbDecimal";
			//
			// cbPicker1
			//
			cbPicker1.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbPicker1.DropDownWidth = 384;
			resources.ApplyResources(cbPicker1, "cbPicker1");
			cbPicker1.Name = "cbPicker1";
			//
			// tbVal1
			//
			resources.ApplyResources(tbVal1, "tbVal1");
			tbVal1.Name = "tbVal1";
			//
			// cbDataOwner1
			//
			cbDataOwner1.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbDataOwner1.DropDownWidth = 384;
			resources.ApplyResources(cbDataOwner1, "cbDataOwner1");
			cbDataOwner1.Name = "cbDataOwner1";
			//
			// ckbNID
			//
			resources.ApplyResources(ckbNID, "ckbNID");
			ckbNID.Name = "ckbNID";
			ckbNID.UseVisualStyleBackColor = true;
			//
			// ckbOrigGUID
			//
			resources.ApplyResources(ckbOrigGUID, "ckbOrigGUID");
			flowLayoutPanel1.SetFlowBreak(ckbOrigGUID, true);
			ckbOrigGUID.Name = "ckbOrigGUID";
			ckbOrigGUID.UseVisualStyleBackColor = true;
			//
			// label2
			//
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			//
			// flowLayoutPanel2
			//
			flowLayoutPanel2.Controls.Add(tbGUID);
			flowLayoutPanel2.Controls.Add(lbGUIDText);
			resources.ApplyResources(flowLayoutPanel2, "flowLayoutPanel2");
			flowLayoutPanel2.Name = "flowLayoutPanel2";
			//
			// tbGUID
			//
			resources.ApplyResources(tbGUID, "tbGUID");
			tbGUID.Name = "tbGUID";
			tbGUID.TextChanged += new EventHandler(tbGUID_TextChanged);
			tbGUID.Validated += new EventHandler(hex32_Validated);
			tbGUID.Validating += new System.ComponentModel.CancelEventHandler(
				hex32_Validating
			);
			//
			// lbGUIDText
			//
			resources.ApplyResources(lbGUIDText, "lbGUIDText");
			lbGUIDText.Name = "lbGUIDText";
			//
			// ckbTemp01
			//
			resources.ApplyResources(ckbTemp01, "ckbTemp01");
			ckbTemp01.Name = "ckbTemp01";
			ckbTemp01.UseVisualStyleBackColor = true;
			//
			// UI
			//
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Dpi;
			Controls.Add(pnWiz0x001f);
			Name = "UI";
			pnWiz0x001f.ResumeLayout(false);
			flowLayoutPanel1.ResumeLayout(false);
			flowLayoutPanel1.PerformLayout();
			pnObject.ResumeLayout(false);
			pnObject.PerformLayout();
			flowLayoutPanel2.ResumeLayout(false);
			flowLayoutPanel2.PerformLayout();
			ResumeLayout(false);
		}
		#endregion

		private void tbGUID_TextChanged(object sender, EventArgs e)
		{
			if (!hex32_IsValid(sender))
			{
				return;
			}

			setGUID(false, Convert.ToUInt32(((TextBox)sender).Text, 16));
		}

		private void hex32_Validating(
			object sender,
			System.ComponentModel.CancelEventArgs e
		)
		{
			if (hex32_IsValid(sender))
			{
				return;
			}

			e.Cancel = true;

			bool origstate = internalchg;
			internalchg = true;
			((TextBox)sender).Text =
				"0x"
				+ SimPe.Helper.HexString(
					inst.Operands[0x00]
						| (inst.Operands[0x01] << 8)
						| (inst.Operands[0x02] << 16)
						| (inst.Operands[0x03] << 24)
				);
			((TextBox)sender).SelectAll();
			internalchg = origstate;
		}

		private void hex32_Validated(object sender, EventArgs e)
		{
			bool origstate = internalchg;
			internalchg = true;
			((TextBox)sender).Text =
				"0x"
				+ SimPe.Helper.HexString(Convert.ToUInt32(((TextBox)sender).Text, 16));
			((TextBox)sender).SelectAll();
			internalchg = origstate;
		}
	}
}

namespace pjse.BhavOperandWizards
{
	public class BhavOperandWiz0x0020 : ABhavOperandWiz
	{
		public BhavOperandWiz0x0020(Instruction i)
			: base(i)
		{
			myForm = new Wiz0x0020.UI();
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
