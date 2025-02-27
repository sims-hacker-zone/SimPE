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

namespace pjse.BhavOperandWizards.Wiz0x001f
{
	/// <summary>
	/// Summary description for StrBig.
	/// </summary>
	internal class UI : Form, iBhavOperandWizForm
	{
		#region Form variables

		internal Panel pnWiz0x001f;
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

			tbGUID.Visible = false;
			tbGUID.Left = cbToNext.Left + cbToNext.Width + 3;
			tbLocalVar.Visible = false;
			tbLocalVar.Left = cbToNext.Left + cbToNext.Width + 3;

			cbToNext.Items.AddRange(
				BhavWiz.readStr(GS.BhavStr.NextObject).ToArray()
			);
			cbWhere.Items.AddRange(
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
			lbGUIDText.Visible = tbGUID.Visible = guid;
			tbLocalVar.Visible = local;
			if (val == cbToNext.SelectedIndex)
			{
				return;
			}

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

			cbToNext.SelectedIndex = -1;
			setToNext((byte)(ops1[4] & 0x7f));

			ckbStackObj.Checked = (ops1[4] & 0x80) == 0;
			pnObject.Enabled = !ckbStackObj.Checked;

			doid1 = new DataOwnerControl(
				inst,
				cbDataOwner1,
				cbPicker1,
				tbVal1,
				cbDecimal,
				cbAttrPicker,
				null,
				ops1[0x05],
				ops1[0x07]
			);

			tbLocalVar.Text = "0x" + SimPe.Helper.HexString(ops1[0x06]);

			pnNodeVersion.Enabled = (inst.NodeVersion != 0);
			ckbDisabled.Checked = (ops2[0x00] & 0x01) != 0;
			pnWhere.Enabled = ckbWhere.Checked = (ops2[0x00] & 0x02) != 0;

			ushort where = BhavWiz.ToShort(ops2[0x01], ops2[0x02]);
			cbWhere.SelectedIndex = -1;
			if (cbWhere.Items.Count > where)
			{
				cbWhere.SelectedIndex = where;
			}

			tbWhereVal.Text =
				"0x" + SimPe.Helper.HexString(BhavWiz.ToShort(ops2[0x03], ops2[0x04]));

			internalchg = false;
		}

		public Instruction Write(Instruction inst)
		{
			if (inst != null)
			{
				wrappedByteArray ops1 = inst.Operands;
				wrappedByteArray ops2 = inst.Reserved1;

				UInt32 val = Convert.ToUInt32(tbGUID.Text, 16);
				ops1[0x00] = (byte)(val & 0xff);
				ops1[0x01] = (byte)(val >> 8 & 0xff);
				ops1[0x02] = (byte)(val >> 16 & 0xff);
				ops1[0x03] = (byte)(val >> 24 & 0xff);
				if (cbToNext.SelectedIndex >= 0)
				{
					ops1[0x04] = (byte)(cbToNext.SelectedIndex & 0x7f);
				}

				ops1[0x04] |= (byte)(!ckbStackObj.Checked ? 0x80 : 0x00);
				ops1[0x05] = doid1.DataOwner;
				ops1[0x06] = Convert.ToByte(tbLocalVar.Text, 16);
				ops1[0x07] = (byte)(doid1.Value & 0xff);

				ops2[0x00] &= 0xfc;
				ops2[0x00] |= (byte)(ckbDisabled.Checked ? 0x01 : 0x00);
				ops2[0x00] |= (byte)(ckbWhere.Checked ? 0x02 : 0x00);
				if (cbWhere.SelectedIndex >= 0)
				{
					BhavWiz.FromShort(ref ops2, 1, (ushort)cbWhere.SelectedIndex);
				}

				BhavWiz.FromShort(
					ref ops2,
					3,
					(ushort)Convert.ToUInt32(tbWhereVal.Text, 16)
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
			pnWiz0x001f = new Panel();
			cbToNext = new ComboBox();
			tbLocalVar = new TextBox();
			tbGUID = new TextBox();
			lbGUIDText = new Label();
			label2 = new Label();
			pnNodeVersion = new Panel();
			pnWhere = new Panel();
			cbWhere = new ComboBox();
			tbWhereVal = new TextBox();
			label4 = new Label();
			ckbWhere = new CheckBox();
			ckbDisabled = new CheckBox();
			label1 = new Label();
			pnObject = new Panel();
			cbAttrPicker = new CheckBox();
			cbDecimal = new CheckBox();
			cbPicker1 = new ComboBox();
			tbVal1 = new TextBox();
			cbDataOwner1 = new ComboBox();
			ckbStackObj = new CheckBox();
			pnWiz0x001f.SuspendLayout();
			pnNodeVersion.SuspendLayout();
			pnWhere.SuspendLayout();
			pnObject.SuspendLayout();
			SuspendLayout();
			//
			// pnWiz0x001f
			//
			pnWiz0x001f.Controls.Add(cbToNext);
			pnWiz0x001f.Controls.Add(tbLocalVar);
			pnWiz0x001f.Controls.Add(tbGUID);
			pnWiz0x001f.Controls.Add(lbGUIDText);
			pnWiz0x001f.Controls.Add(label2);
			pnWiz0x001f.Controls.Add(pnNodeVersion);
			pnWiz0x001f.Controls.Add(label1);
			pnWiz0x001f.Controls.Add(pnObject);
			pnWiz0x001f.Controls.Add(ckbStackObj);
			resources.ApplyResources(pnWiz0x001f, "pnWiz0x001f");
			pnWiz0x001f.Name = "pnWiz0x001f";
			//
			// cbToNext
			//
			cbToNext.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbToNext.DropDownWidth = 450;
			cbToNext.FormattingEnabled = true;
			resources.ApplyResources(cbToNext, "cbToNext");
			cbToNext.Name = "cbToNext";
			cbToNext.SelectedIndexChanged += new EventHandler(
				cbToNext_SelectedIndexChanged
			);
			//
			// tbLocalVar
			//
			resources.ApplyResources(tbLocalVar, "tbLocalVar");
			tbLocalVar.Name = "tbLocalVar";
			tbLocalVar.Validated += new EventHandler(hex8_Validated);
			tbLocalVar.Validating += new System.ComponentModel.CancelEventHandler(
				hex8_Validating
			);
			//
			// tbGUID
			//
			resources.ApplyResources(tbGUID, "tbGUID");
			tbGUID.Name = "tbGUID";
			tbGUID.Validated += new EventHandler(hex32_Validated);
			tbGUID.Validating += new System.ComponentModel.CancelEventHandler(
				hex32_Validating
			);
			tbGUID.TextChanged += new EventHandler(tbGUID_TextChanged);
			//
			// lbGUIDText
			//
			resources.ApplyResources(lbGUIDText, "lbGUIDText");
			lbGUIDText.Name = "lbGUIDText";
			//
			// label2
			//
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			//
			// pnNodeVersion
			//
			pnNodeVersion.Controls.Add(pnWhere);
			pnNodeVersion.Controls.Add(ckbWhere);
			pnNodeVersion.Controls.Add(ckbDisabled);
			resources.ApplyResources(pnNodeVersion, "pnNodeVersion");
			pnNodeVersion.Name = "pnNodeVersion";
			//
			// pnWhere
			//
			pnWhere.Controls.Add(cbWhere);
			pnWhere.Controls.Add(tbWhereVal);
			pnWhere.Controls.Add(label4);
			resources.ApplyResources(pnWhere, "pnWhere");
			pnWhere.Name = "pnWhere";
			//
			// cbWhere
			//
			cbWhere.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbWhere.DropDownWidth = 280;
			cbWhere.FormattingEnabled = true;
			resources.ApplyResources(cbWhere, "cbWhere");
			cbWhere.Name = "cbWhere";
			//
			// tbWhereVal
			//
			resources.ApplyResources(tbWhereVal, "tbWhereVal");
			tbWhereVal.Name = "tbWhereVal";
			tbWhereVal.Validated += new EventHandler(hex16_Validated);
			tbWhereVal.Validating += new System.ComponentModel.CancelEventHandler(
				hex16_Validating
			);
			//
			// label4
			//
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			//
			// ckbWhere
			//
			resources.ApplyResources(ckbWhere, "ckbWhere");
			ckbWhere.Name = "ckbWhere";
			ckbWhere.UseVisualStyleBackColor = true;
			ckbWhere.CheckedChanged += new EventHandler(
				ckbWhere_CheckedChanged
			);
			//
			// ckbDisabled
			//
			resources.ApplyResources(ckbDisabled, "ckbDisabled");
			ckbDisabled.Name = "ckbDisabled";
			ckbDisabled.UseVisualStyleBackColor = true;
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
			// ckbStackObj
			//
			resources.ApplyResources(ckbStackObj, "ckbStackObj");
			ckbStackObj.Name = "ckbStackObj";
			ckbStackObj.UseVisualStyleBackColor = true;
			ckbStackObj.CheckedChanged += new EventHandler(
				ckbStackObj_CheckedChanged
			);
			//
			// UI
			//
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Dpi;
			Controls.Add(pnWiz0x001f);
			Name = "UI";
			pnWiz0x001f.ResumeLayout(false);
			pnWiz0x001f.PerformLayout();
			pnNodeVersion.ResumeLayout(false);
			pnNodeVersion.PerformLayout();
			pnWhere.ResumeLayout(false);
			pnWhere.PerformLayout();
			pnObject.ResumeLayout(false);
			pnObject.PerformLayout();
			ResumeLayout(false);
		}
		#endregion

		private void hex8_Validating(
			object sender,
			System.ComponentModel.CancelEventArgs e
		)
		{
			if (hex8_IsValid(sender))
			{
				return;
			}

			e.Cancel = true;

			bool origstate = internalchg;
			internalchg = true;
			((TextBox)sender).Text = "0x" + SimPe.Helper.HexString(inst.Operands[0x06]);
			((TextBox)sender).SelectAll();
			internalchg = origstate;
		}

		private void hex8_Validated(object sender, EventArgs e)
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
			{
				return;
			}
			else if (hex16_IsValid(sender))
			{
				return;
			}

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

		private void hex16_Validated(object sender, EventArgs e)
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

		private void cbToNext_SelectedIndexChanged(object sender, EventArgs e)
		{
			setToNext((byte)((ComboBox)sender).SelectedIndex);
		}

		private void ckbStackObj_CheckedChanged(object sender, EventArgs e)
		{
			pnObject.Enabled = !ckbStackObj.Checked;
		}

		private void ckbWhere_CheckedChanged(object sender, EventArgs e)
		{
			pnWhere.Enabled = ckbWhere.Checked;
		}
	}
}

namespace pjse.BhavOperandWizards
{
	public class BhavOperandWiz0x001f : ABhavOperandWiz
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
			{
				myForm = null;
			}
		}
		#endregion
	}
}
