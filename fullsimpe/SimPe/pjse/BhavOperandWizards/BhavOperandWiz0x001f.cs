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

namespace pjse.BhavOperandWizards.Wiz0x001f
{
	/// <summary>
	/// Summary description for StrBig.
	/// </summary>
	internal class UI : System.Windows.Forms.Form, iBhavOperandWizForm
	{
		#region Form variables

		internal System.Windows.Forms.Panel pnWiz0x001f;
		private CheckBox ckbStackObj;
		private Panel pnObject;
		private CheckBox cbAttrPicker;
		private CheckBox cbDecimal;
		private ComboBox cbPicker1;
		private TextBox tbVal1;
		private ComboBox cbDataOwner1;
		private Label label1;
		private Panel pnNodeVersion;
		private CheckBox ckbDisabled;
		private Panel pnWhere;
		private ComboBox cbWhere;
		private TextBox tbWhereVal;
		private Label label4;
		private CheckBox ckbWhere;
		private ComboBox cbToNext;
		private TextBox tbLocalVar;
		private TextBox tbGUID;
		private Label label2;
		private Label lbGUIDText;

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

			this.tbGUID.Visible = false;
			this.tbGUID.Left = this.cbToNext.Left + this.cbToNext.Width + 3;
			this.tbLocalVar.Visible = false;
			this.tbLocalVar.Left = this.cbToNext.Left + this.cbToNext.Width + 3;

			this.cbToNext.Items.AddRange(
				BhavWiz.readStr(GS.BhavStr.NextObject).ToArray()
			);
			this.cbWhere.Items.AddRange(
				BhavWiz.readStr(GS.BhavStr.DataLabels).ToArray()
			);
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

		private bool hex8_IsValid(object sender)
		{
			try
			{
				Convert.ToByte(((TextBox)sender).Text, 16);
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		private bool hex16_IsValid(object sender)
		{
			try
			{
				Convert.ToUInt16(((TextBox)sender).Text, 16);
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

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

		private void setToNext(byte val)
		{
			bool guid = false;
			bool local = false;
			switch (val)
			{
				case 0x04:
				case 0x07:
					guid = true;
					break;
				case 0x09:
				case 0x22:
					local = true;
					break;
			}
			this.lbGUIDText.Visible = this.tbGUID.Visible = guid;
			this.tbLocalVar.Visible = local;
			if (val == cbToNext.SelectedIndex)
				return;
			cbToNext.SelectedIndex = (val >= cbToNext.Items.Count) ? -1 : val;
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
			get { return this.pnWiz0x001f; }
		}

		public void Execute(Instruction inst)
		{
			this.inst = inst;

			wrappedByteArray ops1 = inst.Operands;
			wrappedByteArray ops2 = inst.Reserved1;

			internalchg = true;

			setGUID(ops1, 0);

			this.cbToNext.SelectedIndex = -1;
			setToNext((byte)(ops1[4] & 0x7f));

			this.ckbStackObj.Checked = (ops1[4] & 0x80) == 0;
			this.pnObject.Enabled = !this.ckbStackObj.Checked;

			doid1 = new DataOwnerControl(
				inst,
				this.cbDataOwner1,
				this.cbPicker1,
				this.tbVal1,
				this.cbDecimal,
				this.cbAttrPicker,
				null,
				ops1[0x05],
				ops1[0x07]
			);

			this.tbLocalVar.Text = "0x" + SimPe.Helper.HexString(ops1[0x06]);

			this.pnNodeVersion.Enabled = (inst.NodeVersion != 0);
			this.ckbDisabled.Checked = (ops2[0x00] & 0x01) != 0;
			this.pnWhere.Enabled = this.ckbWhere.Checked = (ops2[0x00] & 0x02) != 0;

			ushort where = BhavWiz.ToShort(ops2[0x01], ops2[0x02]);
			this.cbWhere.SelectedIndex = -1;
			if (this.cbWhere.Items.Count > where)
				this.cbWhere.SelectedIndex = where;
			this.tbWhereVal.Text =
				"0x" + SimPe.Helper.HexString(BhavWiz.ToShort(ops2[0x03], ops2[0x04]));

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
				if (this.cbToNext.SelectedIndex >= 0)
					ops1[0x04] = (byte)(this.cbToNext.SelectedIndex & 0x7f);
				ops1[0x04] |= (byte)(!this.ckbStackObj.Checked ? 0x80 : 0x00);
				ops1[0x05] = doid1.DataOwner;
				ops1[0x06] = Convert.ToByte(this.tbLocalVar.Text, 16);
				ops1[0x07] = (byte)(doid1.Value & 0xff);

				ops2[0x00] &= 0xfc;
				ops2[0x00] |= (byte)(this.ckbDisabled.Checked ? 0x01 : 0x00);
				ops2[0x00] |= (byte)(this.ckbWhere.Checked ? 0x02 : 0x00);
				if (this.cbWhere.SelectedIndex >= 0)
					BhavWiz.FromShort(ref ops2, 1, (ushort)this.cbWhere.SelectedIndex);
				BhavWiz.FromShort(
					ref ops2,
					3,
					(ushort)Convert.ToUInt32(this.tbWhereVal.Text, 16)
				);
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
			this.cbToNext = new System.Windows.Forms.ComboBox();
			this.tbLocalVar = new System.Windows.Forms.TextBox();
			this.tbGUID = new System.Windows.Forms.TextBox();
			this.lbGUIDText = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.pnNodeVersion = new System.Windows.Forms.Panel();
			this.pnWhere = new System.Windows.Forms.Panel();
			this.cbWhere = new System.Windows.Forms.ComboBox();
			this.tbWhereVal = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.ckbWhere = new System.Windows.Forms.CheckBox();
			this.ckbDisabled = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.pnObject = new System.Windows.Forms.Panel();
			this.cbAttrPicker = new System.Windows.Forms.CheckBox();
			this.cbDecimal = new System.Windows.Forms.CheckBox();
			this.cbPicker1 = new System.Windows.Forms.ComboBox();
			this.tbVal1 = new System.Windows.Forms.TextBox();
			this.cbDataOwner1 = new System.Windows.Forms.ComboBox();
			this.ckbStackObj = new System.Windows.Forms.CheckBox();
			this.pnWiz0x001f.SuspendLayout();
			this.pnNodeVersion.SuspendLayout();
			this.pnWhere.SuspendLayout();
			this.pnObject.SuspendLayout();
			this.SuspendLayout();
			//
			// pnWiz0x001f
			//
			this.pnWiz0x001f.Controls.Add(this.cbToNext);
			this.pnWiz0x001f.Controls.Add(this.tbLocalVar);
			this.pnWiz0x001f.Controls.Add(this.tbGUID);
			this.pnWiz0x001f.Controls.Add(this.lbGUIDText);
			this.pnWiz0x001f.Controls.Add(this.label2);
			this.pnWiz0x001f.Controls.Add(this.pnNodeVersion);
			this.pnWiz0x001f.Controls.Add(this.label1);
			this.pnWiz0x001f.Controls.Add(this.pnObject);
			this.pnWiz0x001f.Controls.Add(this.ckbStackObj);
			resources.ApplyResources(this.pnWiz0x001f, "pnWiz0x001f");
			this.pnWiz0x001f.Name = "pnWiz0x001f";
			//
			// cbToNext
			//
			this.cbToNext.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbToNext.DropDownWidth = 450;
			this.cbToNext.FormattingEnabled = true;
			resources.ApplyResources(this.cbToNext, "cbToNext");
			this.cbToNext.Name = "cbToNext";
			this.cbToNext.SelectedIndexChanged += new System.EventHandler(
				this.cbToNext_SelectedIndexChanged
			);
			//
			// tbLocalVar
			//
			resources.ApplyResources(this.tbLocalVar, "tbLocalVar");
			this.tbLocalVar.Name = "tbLocalVar";
			this.tbLocalVar.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbLocalVar.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// tbGUID
			//
			resources.ApplyResources(this.tbGUID, "tbGUID");
			this.tbGUID.Name = "tbGUID";
			this.tbGUID.Validated += new System.EventHandler(this.hex32_Validated);
			this.tbGUID.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex32_Validating
			);
			this.tbGUID.TextChanged += new System.EventHandler(this.tbGUID_TextChanged);
			//
			// lbGUIDText
			//
			resources.ApplyResources(this.lbGUIDText, "lbGUIDText");
			this.lbGUIDText.Name = "lbGUIDText";
			//
			// label2
			//
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			//
			// pnNodeVersion
			//
			this.pnNodeVersion.Controls.Add(this.pnWhere);
			this.pnNodeVersion.Controls.Add(this.ckbWhere);
			this.pnNodeVersion.Controls.Add(this.ckbDisabled);
			resources.ApplyResources(this.pnNodeVersion, "pnNodeVersion");
			this.pnNodeVersion.Name = "pnNodeVersion";
			//
			// pnWhere
			//
			this.pnWhere.Controls.Add(this.cbWhere);
			this.pnWhere.Controls.Add(this.tbWhereVal);
			this.pnWhere.Controls.Add(this.label4);
			resources.ApplyResources(this.pnWhere, "pnWhere");
			this.pnWhere.Name = "pnWhere";
			//
			// cbWhere
			//
			this.cbWhere.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbWhere.DropDownWidth = 280;
			this.cbWhere.FormattingEnabled = true;
			resources.ApplyResources(this.cbWhere, "cbWhere");
			this.cbWhere.Name = "cbWhere";
			//
			// tbWhereVal
			//
			resources.ApplyResources(this.tbWhereVal, "tbWhereVal");
			this.tbWhereVal.Name = "tbWhereVal";
			this.tbWhereVal.Validated += new System.EventHandler(this.hex16_Validated);
			this.tbWhereVal.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex16_Validating
			);
			//
			// label4
			//
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			//
			// ckbWhere
			//
			resources.ApplyResources(this.ckbWhere, "ckbWhere");
			this.ckbWhere.Name = "ckbWhere";
			this.ckbWhere.UseVisualStyleBackColor = true;
			this.ckbWhere.CheckedChanged += new System.EventHandler(
				this.ckbWhere_CheckedChanged
			);
			//
			// ckbDisabled
			//
			resources.ApplyResources(this.ckbDisabled, "ckbDisabled");
			this.ckbDisabled.Name = "ckbDisabled";
			this.ckbDisabled.UseVisualStyleBackColor = true;
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
			// ckbStackObj
			//
			resources.ApplyResources(this.ckbStackObj, "ckbStackObj");
			this.ckbStackObj.Name = "ckbStackObj";
			this.ckbStackObj.UseVisualStyleBackColor = true;
			this.ckbStackObj.CheckedChanged += new System.EventHandler(
				this.ckbStackObj_CheckedChanged
			);
			//
			// UI
			//
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Controls.Add(this.pnWiz0x001f);
			this.Name = "UI";
			this.pnWiz0x001f.ResumeLayout(false);
			this.pnWiz0x001f.PerformLayout();
			this.pnNodeVersion.ResumeLayout(false);
			this.pnNodeVersion.PerformLayout();
			this.pnWhere.ResumeLayout(false);
			this.pnWhere.PerformLayout();
			this.pnObject.ResumeLayout(false);
			this.pnObject.PerformLayout();
			this.ResumeLayout(false);
		}
		#endregion

		private void hex8_Validating(
			object sender,
			System.ComponentModel.CancelEventArgs e
		)
		{
			if (hex8_IsValid(sender))
				return;

			e.Cancel = true;

			bool origstate = internalchg;
			internalchg = true;
			((TextBox)sender).Text = "0x" + SimPe.Helper.HexString(inst.Operands[0x06]);
			((TextBox)sender).SelectAll();
			internalchg = origstate;
		}

		private void hex8_Validated(object sender, System.EventArgs e)
		{
			bool origstate = internalchg;
			internalchg = true;
			((TextBox)sender).Text =
				"0x"
				+ SimPe.Helper.HexString(Convert.ToByte(((TextBox)sender).Text, 16));
			((TextBox)sender).SelectAll();
			internalchg = origstate;
		}

		private void hex16_Validating(
			object sender,
			System.ComponentModel.CancelEventArgs e
		)
		{
			if (inst.NodeVersion < 2 && hex8_IsValid(sender))
				return;
			else if (hex16_IsValid(sender))
				return;

			e.Cancel = true;

			bool origstate = internalchg;
			internalchg = true;
			((TextBox)sender).Text =
				"0x"
				+ SimPe.Helper.HexString(
					BhavWiz.ToShort(inst.Reserved1[0x03], inst.Reserved1[0x04])
				);
			((TextBox)sender).SelectAll();
			internalchg = origstate;
		}

		private void hex16_Validated(object sender, System.EventArgs e)
		{
			bool origstate = internalchg;
			internalchg = true;
			((TextBox)sender).Text =
				"0x"
				+ SimPe.Helper.HexString(Convert.ToUInt16(((TextBox)sender).Text, 16));
			((TextBox)sender).SelectAll();
			internalchg = origstate;
		}

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

		private void cbToNext_SelectedIndexChanged(object sender, EventArgs e)
		{
			setToNext((byte)((ComboBox)sender).SelectedIndex);
		}

		private void ckbStackObj_CheckedChanged(object sender, EventArgs e)
		{
			this.pnObject.Enabled = !this.ckbStackObj.Checked;
		}

		private void ckbWhere_CheckedChanged(object sender, EventArgs e)
		{
			this.pnWhere.Enabled = this.ckbWhere.Checked;
		}
	}
}

namespace pjse.BhavOperandWizards
{
	public class BhavOperandWiz0x001f : pjse.ABhavOperandWiz
	{
		public BhavOperandWiz0x001f(Instruction i)
			: base(i)
		{
			myForm = new Wiz0x001f.UI();
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
