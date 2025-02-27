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

namespace pjse.BhavOperandWizards.Wiz0x0032
{
	/// <summary>
	/// Summary description for StrBig.
	/// </summary>
	internal class UI : System.Windows.Forms.Form, iBhavOperandWizForm
	{
		#region Form variables

		internal System.Windows.Forms.Panel pnWiz0x0032;
		private RadioButton rbModeIcon;
		private RadioButton rbModeAction;
		private Panel pnAction;
		private Panel pnIcon;
		private ComboBox cbScope;
		private Label label1;
		private Label lbDisabled;
		private ComboBox cbDisabled;
		private Label label3;
		private Label label4;
		private Panel pnStrIndex;
		private Label label5;
		private Button btnActionString;
		private TextBox tbStrIndex;
		private Label lbActionString;
		private CheckBox tfActionTemp;
		private CheckBox tfIconTemp;
		private Panel pnIconIndex;
		private Label label6;
		private TextBox tbIconIndex;
		private Panel pnThumbnail;
		private CheckBox tfGUIDTemp;
		private Panel pnGUID;
		private Label label8;
		private TextBox tbGUID;
		private Label label7;
		private RadioButton rbIconSourceObj;
		private RadioButton rbIconSourceTN;
		private Label label10;
		private Panel pnObject;
		private Label label9;
		private ComboBox cbPicker1;
		private TextBox tbVal1;
		private ComboBox cbDataOwner1;
		private CheckBox cbAttrPicker;
		private CheckBox cbDecimal;
		private CheckBox tfSubQ;

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

		private Scope Scope
		{
			get
			{
				Scope scope = Scope.Private;
				switch (this.cbScope.SelectedIndex)
				{
					case 1:
						scope = Scope.SemiGlobal;
						break;
					case 2:
						scope = Scope.Global;
						break;
				}
				return scope;
			}
		}

		private void doStrChooser()
		{
			pjse.FileTable.Entry[] items = pjse.FileTable.GFT[
				(uint)SimPe.Data.MetaData.STRING_FILE,
				inst.Parent.GroupForScope(this.Scope),
				(uint)GS.GlobalStr.MakeAction
			];

			if (items == null || items.Length == 0)
			{
				MessageBox.Show(
					pjse.Localization.GetString("bow_noStrings")
						+ " ("
						+ pjse.Localization.GetString(this.Scope.ToString())
						+ ")"
				);
				return; // eek!
			}

			SimPe.PackedFiles.Wrapper.StrWrapper str = new StrWrapper();
			str.ProcessData(items[0].PFD, items[0].Package);

			int i = (new StrChooser(true)).Strnum(str);
			if (i >= 0)
			{
				this.tbStrIndex.Text = "0x" + SimPe.Helper.HexString((byte)(i + 1));
				this.lbActionString.Text = ((BhavWiz)inst).readStr(
					this.Scope,
					GS.GlobalStr.MakeAction,
					(ushort)i,
					-1,
					pjse.Detail.ErrorNames
				);
			}
		}

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

		#region iBhavOperandWizForm
		public Panel WizPanel => this.pnWiz0x0032;

		public void Execute(Instruction inst)
		{
			this.inst = inst;

			wrappedByteArray ops1 = inst.Operands;
			wrappedByteArray ops2 = inst.Reserved1;

			internalchg = true;

			this.lbDisabled.Enabled = this.cbDisabled.Enabled = inst.NodeVersion != 0;
			this.tfSubQ.Enabled = inst.NodeVersion > 2;

			this.cbScope.SelectedIndex = -1;
			switch (ops1[0x02] & 0x0c)
			{
				case 0x00:
					this.cbScope.SelectedIndex = 0;
					break; // Private
				case 0x04:
					this.cbScope.SelectedIndex = 2;
					break; // Global
				case 0x08:
					this.cbScope.SelectedIndex = 1;
					break; // SemiGlobal
			}

			this.tfActionTemp.Checked = (ops1[0x02] & 0x10) != 0;
			this.pnStrIndex.Enabled = !this.tfActionTemp.Checked;

			this.pnThumbnail.Enabled = this.rbIconSourceTN.Checked = (
				(ops1[0x02] & 0x20) != 0
			);
			this.pnObject.Enabled = this.rbIconSourceObj.Checked =
				!this.rbIconSourceTN.Checked;

			this.tfGUIDTemp.Checked = ((ops1[0x02] & 0x40) != 0);
			this.pnGUID.Enabled = !this.tfGUIDTemp.Checked;

			this.tfIconTemp.Checked = (ops1[0x02] & 0x80) != 0;
			this.pnIconIndex.Enabled = !this.tfIconTemp.Checked;

			this.cbDisabled.SelectedIndex = -1;
			switch (ops1[0x03] & 0x03)
			{
				case 0x00:
					this.cbDisabled.SelectedIndex = 2;
					break;
				case 0x01:
					this.cbDisabled.SelectedIndex = 0;
					break;
				case 0x02:
					this.cbDisabled.SelectedIndex = 1;
					break;
			}
			this.tfSubQ.Checked = (ops1[0x03] & 0x10) != 0;

			int val =
				inst.NodeVersion < 2
					? ops1[0x04]
					: BhavWiz.ToShort(ops2[0x06], ops2[0x07]);
			this.tbStrIndex.Text = "0x" + SimPe.Helper.HexString((ushort)val);
			this.lbActionString.Text = ((BhavWiz)inst).readStr(
				this.Scope,
				GS.GlobalStr.MakeAction,
				(ushort)(val - 1),
				-1,
				pjse.Detail.ErrorNames
			);

			this.tbGUID.Text =
				"0x"
				+ SimPe.Helper.HexString(
					ops1[0x05]
						| (ops1[0x06] << 8)
						| (ops1[0x07] << 16)
						| (ops2[0x00] << 24)
				);

			this.pnAction.Enabled = this.rbModeAction.Checked = ops2[0x01] == 0;
			this.pnIcon.Enabled = this.rbModeIcon.Checked = !this.rbModeAction.Checked;

			this.tbIconIndex.Text = "0x" + SimPe.Helper.HexString(ops2[0x03]);

			doid1 = new DataOwnerControl(
				inst,
				this.cbDataOwner1,
				this.cbPicker1,
				this.tbVal1,
				this.cbDecimal,
				this.cbAttrPicker,
				null,
				ops2[0x03],
				BhavWiz.ToShort(ops2[0x04], ops2[0x05])
			);

			internalchg = false;
		}

		public Instruction Write(Instruction inst)
		{
			if (inst != null)
			{
				wrappedByteArray ops1 = inst.Operands;
				wrappedByteArray ops2 = inst.Reserved1;

				if (this.rbModeAction.Checked)
				{
					ops2[0x01] = 0;

					if (this.cbScope.SelectedIndex >= 0)
					{
						ops1[0x02] &= 0xf3;
						if (this.cbScope.SelectedIndex == 2)
						{
							ops1[0x02] |= 0x04;
						}

						if (this.cbScope.SelectedIndex == 1)
						{
							ops1[0x02] |= 0x08;
						}
					}

					ops1[0x02] &= 0xef;
					if (this.tfActionTemp.Checked)
					{
						ops1[0x02] |= 0x10;
					}
					else
					{
						ushort val = Convert.ToUInt16(this.tbStrIndex.Text, 16);
						if (inst.NodeVersion < 2)
						{
							ops1[0x04] = (byte)(val & 0xff);
						}
						else
						{
							BhavWiz.FromShort(ref ops2, 6, val);
						}
					}

					if (inst.NodeVersion != 0 && this.cbDisabled.SelectedIndex != -1)
					{
						ops1[0x03] &= 0xfc;
						if (this.cbDisabled.SelectedIndex == 0)
						{
							ops1[0x03] |= 0x01;
						}
						else if (this.cbDisabled.SelectedIndex == 1)
						{
							ops1[0x03] |= 0x02;
						}
					}
					if (inst.NodeVersion > 2)
					{
						ops1[0x03] &= 0xef;
						if (this.tfSubQ.Checked)
						{
							ops1[0x03] |= 0x10;
						}
					}
				}
				else
				{
					if (ops2[0x01] == 0)
					{
						ops2[0x01] = 1;
					}

					ops1[0x02] &= 0x7f;
					if (this.tfIconTemp.Checked)
					{
						ops1[0x02] |= 0x80;
					}
					else
					{
						ops2[0x03] = Convert.ToByte(this.tbIconIndex.Text, 16);
					}

					ops1[0x02] &= 0xdf;
					if (this.pnThumbnail.Enabled)
					{
						ops1[0x02] |= 0x20;

						ops1[0x02] &= 0xbf;
						if (this.tfGUIDTemp.Checked)
						{
							ops1[0x02] |= 0x40;
						}
						else
						{
							uint val = Convert.ToUInt32(this.tbGUID.Text, 16);
							ops1[0x05] = (byte)(val & 0xff);
							ops1[0x06] = (byte)((val >> 8) & 0xff);
							ops1[0x07] = (byte)((val >> 16) & 0xff);
							ops2[0x00] = (byte)((val >> 24) & 0xff);
						}
					}
					else
					{
						ops2[0x03] = doid1.DataOwner;
						BhavWiz.FromShort(ref ops2, 4, doid1.Value);
					}
				}
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
			this.pnWiz0x0032 = new System.Windows.Forms.Panel();
			this.rbModeIcon = new System.Windows.Forms.RadioButton();
			this.rbModeAction = new System.Windows.Forms.RadioButton();
			this.pnAction = new System.Windows.Forms.Panel();
			this.tfSubQ = new System.Windows.Forms.CheckBox();
			this.pnStrIndex = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.btnActionString = new System.Windows.Forms.Button();
			this.tbStrIndex = new System.Windows.Forms.TextBox();
			this.lbActionString = new System.Windows.Forms.Label();
			this.tfActionTemp = new System.Windows.Forms.CheckBox();
			this.cbDisabled = new System.Windows.Forms.ComboBox();
			this.cbScope = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.lbDisabled = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.pnIcon = new System.Windows.Forms.Panel();
			this.pnObject = new System.Windows.Forms.Panel();
			this.cbAttrPicker = new System.Windows.Forms.CheckBox();
			this.cbDecimal = new System.Windows.Forms.CheckBox();
			this.cbPicker1 = new System.Windows.Forms.ComboBox();
			this.tbVal1 = new System.Windows.Forms.TextBox();
			this.cbDataOwner1 = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.pnThumbnail = new System.Windows.Forms.Panel();
			this.tfGUIDTemp = new System.Windows.Forms.CheckBox();
			this.pnGUID = new System.Windows.Forms.Panel();
			this.label8 = new System.Windows.Forms.Label();
			this.tbGUID = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.rbIconSourceObj = new System.Windows.Forms.RadioButton();
			this.rbIconSourceTN = new System.Windows.Forms.RadioButton();
			this.tfIconTemp = new System.Windows.Forms.CheckBox();
			this.pnIconIndex = new System.Windows.Forms.Panel();
			this.label6 = new System.Windows.Forms.Label();
			this.tbIconIndex = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.pnWiz0x0032.SuspendLayout();
			this.pnAction.SuspendLayout();
			this.pnStrIndex.SuspendLayout();
			this.pnIcon.SuspendLayout();
			this.pnObject.SuspendLayout();
			this.pnThumbnail.SuspendLayout();
			this.pnGUID.SuspendLayout();
			this.pnIconIndex.SuspendLayout();
			this.SuspendLayout();
			//
			// pnWiz0x0032
			//
			this.pnWiz0x0032.Controls.Add(this.rbModeIcon);
			this.pnWiz0x0032.Controls.Add(this.rbModeAction);
			this.pnWiz0x0032.Controls.Add(this.pnAction);
			this.pnWiz0x0032.Controls.Add(this.pnIcon);
			resources.ApplyResources(this.pnWiz0x0032, "pnWiz0x0032");
			this.pnWiz0x0032.Name = "pnWiz0x0032";
			//
			// rbModeIcon
			//
			resources.ApplyResources(this.rbModeIcon, "rbModeIcon");
			this.rbModeIcon.Name = "rbModeIcon";
			this.rbModeIcon.TabStop = true;
			this.rbModeIcon.UseVisualStyleBackColor = true;
			this.rbModeIcon.CheckedChanged += new System.EventHandler(
				this.rbModeIcon_CheckedChanged
			);
			//
			// rbModeAction
			//
			resources.ApplyResources(this.rbModeAction, "rbModeAction");
			this.rbModeAction.Name = "rbModeAction";
			this.rbModeAction.TabStop = true;
			this.rbModeAction.UseVisualStyleBackColor = true;
			this.rbModeAction.CheckedChanged += new System.EventHandler(
				this.rbModeAction_CheckedChanged
			);
			//
			// pnAction
			//
			this.pnAction.Controls.Add(this.tfSubQ);
			this.pnAction.Controls.Add(this.pnStrIndex);
			this.pnAction.Controls.Add(this.tfActionTemp);
			this.pnAction.Controls.Add(this.cbDisabled);
			this.pnAction.Controls.Add(this.cbScope);
			this.pnAction.Controls.Add(this.label3);
			this.pnAction.Controls.Add(this.lbDisabled);
			this.pnAction.Controls.Add(this.label1);
			resources.ApplyResources(this.pnAction, "pnAction");
			this.pnAction.Name = "pnAction";
			//
			// tfSubQ
			//
			resources.ApplyResources(this.tfSubQ, "tfSubQ");
			this.tfSubQ.Name = "tfSubQ";
			this.tfSubQ.UseVisualStyleBackColor = true;
			//
			// pnStrIndex
			//
			resources.ApplyResources(this.pnStrIndex, "pnStrIndex");
			this.pnStrIndex.Controls.Add(this.label5);
			this.pnStrIndex.Controls.Add(this.btnActionString);
			this.pnStrIndex.Controls.Add(this.tbStrIndex);
			this.pnStrIndex.Controls.Add(this.lbActionString);
			this.pnStrIndex.Name = "pnStrIndex";
			//
			// label5
			//
			resources.ApplyResources(this.label5, "label5");
			this.label5.Name = "label5";
			//
			// btnActionString
			//
			resources.ApplyResources(this.btnActionString, "btnActionString");
			this.btnActionString.Name = "btnActionString";
			this.btnActionString.Click += new System.EventHandler(
				this.btnActionString_Click
			);
			//
			// tbStrIndex
			//
			resources.ApplyResources(this.tbStrIndex, "tbStrIndex");
			this.tbStrIndex.Name = "tbStrIndex";
			this.tbStrIndex.TextChanged += new System.EventHandler(
				this.hex16_TextChanged
			);
			this.tbStrIndex.Validated += new System.EventHandler(this.hex16_Validated);
			this.tbStrIndex.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex16_Validating
			);
			//
			// lbActionString
			//
			resources.ApplyResources(this.lbActionString, "lbActionString");
			this.lbActionString.Name = "lbActionString";
			//
			// tfActionTemp
			//
			resources.ApplyResources(this.tfActionTemp, "tfActionTemp");
			this.tfActionTemp.Name = "tfActionTemp";
			this.tfActionTemp.UseVisualStyleBackColor = true;
			this.tfActionTemp.CheckedChanged += new System.EventHandler(
				this.tfActionTemp_CheckedChanged
			);
			//
			// cbDisabled
			//
			this.cbDisabled.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbDisabled.FormattingEnabled = true;
			this.cbDisabled.Items.AddRange(
				new object[]
				{
					resources.GetString("cbDisabled.Items"),
					resources.GetString("cbDisabled.Items1"),
					resources.GetString("cbDisabled.Items2"),
				}
			);
			resources.ApplyResources(this.cbDisabled, "cbDisabled");
			this.cbDisabled.Name = "cbDisabled";
			//
			// cbScope
			//
			this.cbScope.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbScope.FormattingEnabled = true;
			this.cbScope.Items.AddRange(
				new object[]
				{
					resources.GetString("cbScope.Items"),
					resources.GetString("cbScope.Items1"),
					resources.GetString("cbScope.Items2"),
				}
			);
			resources.ApplyResources(this.cbScope, "cbScope");
			this.cbScope.Name = "cbScope";
			this.cbScope.SelectedIndexChanged += new System.EventHandler(
				this.cbScope_SelectedIndexChanged
			);
			//
			// label3
			//
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			//
			// lbDisabled
			//
			resources.ApplyResources(this.lbDisabled, "lbDisabled");
			this.lbDisabled.Name = "lbDisabled";
			//
			// label1
			//
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			//
			// pnIcon
			//
			this.pnIcon.Controls.Add(this.pnObject);
			this.pnIcon.Controls.Add(this.pnThumbnail);
			this.pnIcon.Controls.Add(this.rbIconSourceObj);
			this.pnIcon.Controls.Add(this.rbIconSourceTN);
			this.pnIcon.Controls.Add(this.tfIconTemp);
			this.pnIcon.Controls.Add(this.pnIconIndex);
			this.pnIcon.Controls.Add(this.label10);
			this.pnIcon.Controls.Add(this.label4);
			resources.ApplyResources(this.pnIcon, "pnIcon");
			this.pnIcon.Name = "pnIcon";
			//
			// pnObject
			//
			this.pnObject.Controls.Add(this.cbAttrPicker);
			this.pnObject.Controls.Add(this.cbDecimal);
			this.pnObject.Controls.Add(this.cbPicker1);
			this.pnObject.Controls.Add(this.tbVal1);
			this.pnObject.Controls.Add(this.cbDataOwner1);
			this.pnObject.Controls.Add(this.label9);
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
			// label9
			//
			resources.ApplyResources(this.label9, "label9");
			this.label9.Name = "label9";
			//
			// pnThumbnail
			//
			this.pnThumbnail.Controls.Add(this.tfGUIDTemp);
			this.pnThumbnail.Controls.Add(this.pnGUID);
			this.pnThumbnail.Controls.Add(this.label7);
			resources.ApplyResources(this.pnThumbnail, "pnThumbnail");
			this.pnThumbnail.Name = "pnThumbnail";
			//
			// tfGUIDTemp
			//
			resources.ApplyResources(this.tfGUIDTemp, "tfGUIDTemp");
			this.tfGUIDTemp.Name = "tfGUIDTemp";
			this.tfGUIDTemp.UseVisualStyleBackColor = true;
			this.tfGUIDTemp.CheckedChanged += new System.EventHandler(
				this.tfGUIDTemp_CheckedChanged
			);
			//
			// pnGUID
			//
			this.pnGUID.Controls.Add(this.label8);
			this.pnGUID.Controls.Add(this.tbGUID);
			resources.ApplyResources(this.pnGUID, "pnGUID");
			this.pnGUID.Name = "pnGUID";
			//
			// label8
			//
			resources.ApplyResources(this.label8, "label8");
			this.label8.Name = "label8";
			//
			// tbGUID
			//
			resources.ApplyResources(this.tbGUID, "tbGUID");
			this.tbGUID.Name = "tbGUID";
			this.tbGUID.Validated += new System.EventHandler(this.hex32_Validated);
			this.tbGUID.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex32_Validating
			);
			//
			// label7
			//
			resources.ApplyResources(this.label7, "label7");
			this.label7.Name = "label7";
			//
			// rbIconSourceObj
			//
			resources.ApplyResources(this.rbIconSourceObj, "rbIconSourceObj");
			this.rbIconSourceObj.Name = "rbIconSourceObj";
			this.rbIconSourceObj.TabStop = true;
			this.rbIconSourceObj.UseVisualStyleBackColor = true;
			this.rbIconSourceObj.CheckedChanged += new System.EventHandler(
				this.rbIconSourceObj_CheckedChanged
			);
			//
			// rbIconSourceTN
			//
			resources.ApplyResources(this.rbIconSourceTN, "rbIconSourceTN");
			this.rbIconSourceTN.Name = "rbIconSourceTN";
			this.rbIconSourceTN.TabStop = true;
			this.rbIconSourceTN.UseVisualStyleBackColor = true;
			this.rbIconSourceTN.CheckedChanged += new System.EventHandler(
				this.rbIconSourceTN_CheckedChanged
			);
			//
			// tfIconTemp
			//
			resources.ApplyResources(this.tfIconTemp, "tfIconTemp");
			this.tfIconTemp.Name = "tfIconTemp";
			this.tfIconTemp.UseVisualStyleBackColor = true;
			this.tfIconTemp.CheckedChanged += new System.EventHandler(
				this.tfIconTemp_CheckedChanged
			);
			//
			// pnIconIndex
			//
			this.pnIconIndex.Controls.Add(this.label6);
			this.pnIconIndex.Controls.Add(this.tbIconIndex);
			resources.ApplyResources(this.pnIconIndex, "pnIconIndex");
			this.pnIconIndex.Name = "pnIconIndex";
			//
			// label6
			//
			resources.ApplyResources(this.label6, "label6");
			this.label6.Name = "label6";
			//
			// tbIconIndex
			//
			resources.ApplyResources(this.tbIconIndex, "tbIconIndex");
			this.tbIconIndex.Name = "tbIconIndex";
			this.tbIconIndex.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbIconIndex.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// label10
			//
			resources.ApplyResources(this.label10, "label10");
			this.label10.Name = "label10";
			//
			// label4
			//
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			//
			// UI
			//
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Controls.Add(this.pnWiz0x0032);
			this.Name = "UI";
			this.pnWiz0x0032.ResumeLayout(false);
			this.pnWiz0x0032.PerformLayout();
			this.pnAction.ResumeLayout(false);
			this.pnAction.PerformLayout();
			this.pnStrIndex.ResumeLayout(false);
			this.pnStrIndex.PerformLayout();
			this.pnIcon.ResumeLayout(false);
			this.pnIcon.PerformLayout();
			this.pnObject.ResumeLayout(false);
			this.pnObject.PerformLayout();
			this.pnThumbnail.ResumeLayout(false);
			this.pnThumbnail.PerformLayout();
			this.pnGUID.ResumeLayout(false);
			this.pnGUID.PerformLayout();
			this.pnIconIndex.ResumeLayout(false);
			this.pnIconIndex.PerformLayout();
			this.ResumeLayout(false);
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
			((TextBox)sender).Text =
				"0x" + SimPe.Helper.HexString(inst.Reserved1[0x03]);
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

		private void hex16_TextChanged(object sender, System.EventArgs ev)
		{
			if (internalchg)
			{
				return;
			}

			if (inst.NodeVersion < 2 && !hex8_IsValid(sender))
			{
				return;
			}
			else if (!hex16_IsValid(sender))
			{
				return;
			}

			ushort val = Convert.ToUInt16(((TextBox)sender).Text, 16);
			this.lbActionString.Text = ((BhavWiz)inst).readStr(
				this.Scope,
				GS.GlobalStr.MakeAction,
				(ushort)(val - 1),
				-1,
				pjse.Detail.ErrorNames
			);
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
			ushort val =
				inst.NodeVersion < 2
					? inst.Operands[0x04]
					: BhavWiz.ToShort(inst.Reserved1[0x06], inst.Reserved1[0x07]);
			this.lbActionString.Text = ((BhavWiz)inst).readStr(
				this.Scope,
				GS.GlobalStr.MakeAction,
				(ushort)(val - 1),
				-1,
				pjse.Detail.ErrorNames
			);
			((TextBox)sender).Text = "0x" + SimPe.Helper.HexString(val);
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
					inst.Operands[0x05]
						| (inst.Operands[0x06] << 8)
						| (inst.Operands[0x07] << 16)
						| (inst.Reserved1[0x00] << 24)
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

		private void cbScope_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			this.lbActionString.Text = ((BhavWiz)inst).readStr(
				this.Scope,
				GS.GlobalStr.MakeAction,
				(ushort)(Convert.ToByte(this.tbStrIndex.Text, 16) - 1),
				-1,
				pjse.Detail.ErrorNames
			);
		}

		private void tfActionTemp_CheckedChanged(object sender, EventArgs e)
		{
			this.pnStrIndex.Enabled = !((CheckBox)sender).Checked;
		}

		private void tfIconTemp_CheckedChanged(object sender, EventArgs e)
		{
			this.pnIconIndex.Enabled = !((CheckBox)sender).Checked;
		}

		private void rbModeAction_CheckedChanged(object sender, EventArgs e)
		{
			this.pnAction.Enabled = ((RadioButton)sender).Checked;
		}

		private void rbModeIcon_CheckedChanged(object sender, EventArgs e)
		{
			this.pnIcon.Enabled = ((RadioButton)sender).Checked;
		}

		private void rbIconSourceTN_CheckedChanged(object sender, EventArgs e)
		{
			this.pnThumbnail.Enabled = ((RadioButton)sender).Checked;
		}

		private void rbIconSourceObj_CheckedChanged(object sender, EventArgs e)
		{
			this.pnObject.Enabled = ((RadioButton)sender).Checked;
		}

		private void tfGUIDTemp_CheckedChanged(object sender, EventArgs e)
		{
			this.pnGUID.Enabled = !((CheckBox)sender).Checked;
		}

		private void btnActionString_Click(object sender, EventArgs e)
		{
			doStrChooser();
		}
	}
}

namespace pjse.BhavOperandWizards
{
	public class BhavOperandWiz0x0032 : pjse.ABhavOperandWiz
	{
		public BhavOperandWiz0x0032(Instruction i)
			: base(i)
		{
			myForm = new Wiz0x0032.UI();
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
