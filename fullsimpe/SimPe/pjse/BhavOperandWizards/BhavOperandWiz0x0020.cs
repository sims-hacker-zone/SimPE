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
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using SimPe.PackedFiles.Wrapper;

namespace pjse.BhavOperandWizards.Wiz0x0020
{
	/// <summary>
	/// Summary description for StrBig.
	/// </summary>
	internal class UI : System.Windows.Forms.Form, iBhavOperandWizForm
	{
		#region Form variables

		internal System.Windows.Forms.Panel pnWiz0x001f;
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
				if (components != null)
				{
					components.Dispose();
				}
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
				(UInt32)(o[sub] | o[sub + 1] << 8 | o[sub + 2] << 16 | o[sub + 3] << 24)
			);
		}

		private void setGUID(bool setTB, UInt32 guid)
		{
			if (setTB)
				this.tbGUID.Text = "0x" + SimPe.Helper.HexString(guid);
			this.lbGUIDText.Text = BhavWiz.FormatGUID(true, guid);
		}

		#region iBhavOperandWizForm
		public Panel WizPanel
		{
			get
			{
				return this.pnWiz0x001f;
			}
		}

		public void Execute(Instruction inst)
		{
			this.inst = inst;

			wrappedByteArray ops1 = inst.Operands;
			wrappedByteArray ops2 = inst.Reserved1;

			internalchg = true;

			setGUID(ops1, 0);

			doid1 = new DataOwnerControl(
				inst,
				this.cbDataOwner1,
				this.cbPicker1,
				this.tbVal1,
				this.cbDecimal,
				this.cbAttrPicker,
				null,
				ops1[0x06],
				BhavWiz.ToShort(ops1[0x04], ops1[0x05])
			);

			Boolset ops1_7 = ops1[0x07];
			this.ckbOrigGUID.Checked = ops1_7[0];
			this.ckbNID.Checked = ops1_7[1];
			this.ckbTemp01.Checked = ops1_7[2];

			internalchg = false;
		}

		public Instruction Write(Instruction inst)
		{
			if (inst != null)
			{
				wrappedByteArray ops1 = inst.Operands;
				wrappedByteArray ops2 = inst.Reserved1;

				UInt32 val = Convert.ToUInt32(this.tbGUID.Text, 16);
				ops1[0x00] = (byte)(val & 0xff);
				ops1[0x01] = (byte)(val >> 8 & 0xff);
				ops1[0x02] = (byte)(val >> 16 & 0xff);
				ops1[0x03] = (byte)(val >> 24 & 0xff);

				ops1[0x06] = doid1.DataOwner;
				ops1[0x04] = (byte)(doid1.Value & 0xff);
				ops1[0x05] = (byte)(doid1.Value >> 8 & 0xff);

				Boolset ops1_7 = ops1[0x07];
				ops1_7[0] = this.ckbOrigGUID.Checked;
				ops1_7[1] = this.ckbNID.Checked;
				ops1_7[2] = this.ckbTemp01.Checked;
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
			this.pnWiz0x001f = new System.Windows.Forms.Panel();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.pnObject = new System.Windows.Forms.Panel();
			this.cbAttrPicker = new System.Windows.Forms.CheckBox();
			this.cbDecimal = new System.Windows.Forms.CheckBox();
			this.cbPicker1 = new System.Windows.Forms.ComboBox();
			this.tbVal1 = new System.Windows.Forms.TextBox();
			this.cbDataOwner1 = new System.Windows.Forms.ComboBox();
			this.ckbNID = new System.Windows.Forms.CheckBox();
			this.ckbOrigGUID = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.tbGUID = new System.Windows.Forms.TextBox();
			this.lbGUIDText = new System.Windows.Forms.Label();
			this.ckbTemp01 = new System.Windows.Forms.CheckBox();
			this.pnWiz0x001f.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.pnObject.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			//
			// pnWiz0x001f
			//
			this.pnWiz0x001f.Controls.Add(this.flowLayoutPanel1);
			resources.ApplyResources(this.pnWiz0x001f, "pnWiz0x001f");
			this.pnWiz0x001f.Name = "pnWiz0x001f";
			//
			// flowLayoutPanel1
			//
			this.flowLayoutPanel1.Controls.Add(this.label1);
			this.flowLayoutPanel1.Controls.Add(this.pnObject);
			this.flowLayoutPanel1.Controls.Add(this.ckbNID);
			this.flowLayoutPanel1.Controls.Add(this.ckbOrigGUID);
			this.flowLayoutPanel1.Controls.Add(this.label2);
			this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
			this.flowLayoutPanel1.Controls.Add(this.ckbTemp01);
			resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			//
			// label1
			//
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			//
			// pnObject
			//
			this.pnObject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnObject.Controls.Add(this.cbAttrPicker);
			this.pnObject.Controls.Add(this.cbDecimal);
			this.pnObject.Controls.Add(this.cbPicker1);
			this.pnObject.Controls.Add(this.tbVal1);
			this.pnObject.Controls.Add(this.cbDataOwner1);
			resources.ApplyResources(this.pnObject, "pnObject");
			this.pnObject.Name = "pnObject";
			//
			// cbAttrPicker
			//
			resources.ApplyResources(this.cbAttrPicker, "cbAttrPicker");
			this.cbAttrPicker.Name = "cbAttrPicker";
			//
			// cbDecimal
			//
			resources.ApplyResources(this.cbDecimal, "cbDecimal");
			this.cbDecimal.Name = "cbDecimal";
			//
			// cbPicker1
			//
			this.cbPicker1.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbPicker1.DropDownWidth = 384;
			resources.ApplyResources(this.cbPicker1, "cbPicker1");
			this.cbPicker1.Name = "cbPicker1";
			//
			// tbVal1
			//
			resources.ApplyResources(this.tbVal1, "tbVal1");
			this.tbVal1.Name = "tbVal1";
			//
			// cbDataOwner1
			//
			this.cbDataOwner1.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbDataOwner1.DropDownWidth = 384;
			resources.ApplyResources(this.cbDataOwner1, "cbDataOwner1");
			this.cbDataOwner1.Name = "cbDataOwner1";
			//
			// ckbNID
			//
			resources.ApplyResources(this.ckbNID, "ckbNID");
			this.ckbNID.Name = "ckbNID";
			this.ckbNID.UseVisualStyleBackColor = true;
			//
			// ckbOrigGUID
			//
			resources.ApplyResources(this.ckbOrigGUID, "ckbOrigGUID");
			this.flowLayoutPanel1.SetFlowBreak(this.ckbOrigGUID, true);
			this.ckbOrigGUID.Name = "ckbOrigGUID";
			this.ckbOrigGUID.UseVisualStyleBackColor = true;
			//
			// label2
			//
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			//
			// flowLayoutPanel2
			//
			this.flowLayoutPanel2.Controls.Add(this.tbGUID);
			this.flowLayoutPanel2.Controls.Add(this.lbGUIDText);
			resources.ApplyResources(this.flowLayoutPanel2, "flowLayoutPanel2");
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			//
			// tbGUID
			//
			resources.ApplyResources(this.tbGUID, "tbGUID");
			this.tbGUID.Name = "tbGUID";
			this.tbGUID.TextChanged += new System.EventHandler(this.tbGUID_TextChanged);
			this.tbGUID.Validated += new System.EventHandler(this.hex32_Validated);
			this.tbGUID.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex32_Validating
			);
			//
			// lbGUIDText
			//
			resources.ApplyResources(this.lbGUIDText, "lbGUIDText");
			this.lbGUIDText.Name = "lbGUIDText";
			//
			// ckbTemp01
			//
			resources.ApplyResources(this.ckbTemp01, "ckbTemp01");
			this.ckbTemp01.Name = "ckbTemp01";
			this.ckbTemp01.UseVisualStyleBackColor = true;
			//
			// UI
			//
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Controls.Add(this.pnWiz0x001f);
			this.Name = "UI";
			this.pnWiz0x001f.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.pnObject.ResumeLayout(false);
			this.pnObject.PerformLayout();
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel2.PerformLayout();
			this.ResumeLayout(false);
		}
		#endregion

		private void tbGUID_TextChanged(object sender, EventArgs e)
		{
			if (!hex32_IsValid(sender))
				return;
			setGUID(false, Convert.ToUInt32(((TextBox)sender).Text, 16));
		}

		private void hex32_Validating(
			object sender,
			System.ComponentModel.CancelEventArgs e
		)
		{
			if (hex32_IsValid(sender))
				return;

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

		private void hex32_Validated(object sender, System.EventArgs e)
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
	public class BhavOperandWiz0x0020 : pjse.ABhavOperandWiz
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
				myForm = null;
		}
		#endregion
	}
}
