// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Windows.Forms;

using SimPe.PackedFiles.Wrapper;

namespace pjse.BhavOperandWizards.Wiz0x0032
{
	/// <summary>
	/// Summary description for StrBig.
	/// </summary>
	internal class UI : Form, iBhavOperandWizForm
	{
		#region Form variables

		internal Panel pnWiz0x0032;
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
				components?.Dispose();
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
				switch (cbScope.SelectedIndex)
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
			FileTable.Entry[] items = FileTable.GFT[
				SimPe.Data.FileTypes.STR,
				inst.Parent.GroupForScope(Scope),
				(uint)GS.GlobalStr.MakeAction
			];

			if (items == null || items.Length == 0)
			{
				MessageBox.Show(
					Localization.GetString("bow_noStrings")
						+ " ("
						+ Localization.GetString(Scope.ToString())
						+ ")"
				);
				return; // eek!
			}

			StrWrapper str = new StrWrapper();
			str.ProcessData(items[0].PFD, items[0].Package);

			int i = new StrChooser(true).Strnum(str);
			if (i >= 0)
			{
				tbStrIndex.Text = "0x" + SimPe.Helper.HexString((byte)(i + 1));
				lbActionString.Text = ((BhavWiz)inst).readStr(
					Scope,
					GS.GlobalStr.MakeAction,
					(ushort)i,
					-1,
					Detail.ErrorNames
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
		public Panel WizPanel => pnWiz0x0032;

		public void Execute(Instruction inst)
		{
			this.inst = inst;

			wrappedByteArray ops1 = inst.Operands;
			wrappedByteArray ops2 = inst.Reserved1;

			internalchg = true;

			lbDisabled.Enabled = cbDisabled.Enabled = inst.NodeVersion != 0;
			tfSubQ.Enabled = inst.NodeVersion > 2;

			cbScope.SelectedIndex = -1;
			switch (ops1[0x02] & 0x0c)
			{
				case 0x00:
					cbScope.SelectedIndex = 0;
					break; // Private
				case 0x04:
					cbScope.SelectedIndex = 2;
					break; // Global
				case 0x08:
					cbScope.SelectedIndex = 1;
					break; // SemiGlobal
			}

			tfActionTemp.Checked = (ops1[0x02] & 0x10) != 0;
			pnStrIndex.Enabled = !tfActionTemp.Checked;

			pnThumbnail.Enabled = rbIconSourceTN.Checked =
				(ops1[0x02] & 0x20) != 0
			;
			pnObject.Enabled = rbIconSourceObj.Checked =
				!rbIconSourceTN.Checked;

			tfGUIDTemp.Checked = (ops1[0x02] & 0x40) != 0;
			pnGUID.Enabled = !tfGUIDTemp.Checked;

			tfIconTemp.Checked = (ops1[0x02] & 0x80) != 0;
			pnIconIndex.Enabled = !tfIconTemp.Checked;

			cbDisabled.SelectedIndex = -1;
			switch (ops1[0x03] & 0x03)
			{
				case 0x00:
					cbDisabled.SelectedIndex = 2;
					break;
				case 0x01:
					cbDisabled.SelectedIndex = 0;
					break;
				case 0x02:
					cbDisabled.SelectedIndex = 1;
					break;
			}
			tfSubQ.Checked = (ops1[0x03] & 0x10) != 0;

			int val =
				inst.NodeVersion < 2
					? ops1[0x04]
					: BhavWiz.ToShort(ops2[0x06], ops2[0x07]);
			tbStrIndex.Text = "0x" + SimPe.Helper.HexString((ushort)val);
			lbActionString.Text = ((BhavWiz)inst).readStr(
				Scope,
				GS.GlobalStr.MakeAction,
				(ushort)(val - 1),
				-1,
				Detail.ErrorNames
			);

			tbGUID.Text =
				"0x"
				+ SimPe.Helper.HexStringInt(
					ops1[0x05]
						| (ops1[0x06] << 8)
						| (ops1[0x07] << 16)
						| (ops2[0x00] << 24)
				);

			pnAction.Enabled = rbModeAction.Checked = ops2[0x01] == 0;
			pnIcon.Enabled = rbModeIcon.Checked = !rbModeAction.Checked;

			tbIconIndex.Text = "0x" + SimPe.Helper.HexString(ops2[0x03]);

			doid1 = new DataOwnerControl(
				inst,
				cbDataOwner1,
				cbPicker1,
				tbVal1,
				cbDecimal,
				cbAttrPicker,
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

				if (rbModeAction.Checked)
				{
					ops2[0x01] = 0;

					if (cbScope.SelectedIndex >= 0)
					{
						ops1[0x02] &= 0xf3;
						if (cbScope.SelectedIndex == 2)
						{
							ops1[0x02] |= 0x04;
						}

						if (cbScope.SelectedIndex == 1)
						{
							ops1[0x02] |= 0x08;
						}
					}

					ops1[0x02] &= 0xef;
					if (tfActionTemp.Checked)
					{
						ops1[0x02] |= 0x10;
					}
					else
					{
						ushort val = Convert.ToUInt16(tbStrIndex.Text, 16);
						if (inst.NodeVersion < 2)
						{
							ops1[0x04] = (byte)(val & 0xff);
						}
						else
						{
							BhavWiz.FromShort(ref ops2, 6, val);
						}
					}

					if (inst.NodeVersion != 0 && cbDisabled.SelectedIndex != -1)
					{
						ops1[0x03] &= 0xfc;
						if (cbDisabled.SelectedIndex == 0)
						{
							ops1[0x03] |= 0x01;
						}
						else if (cbDisabled.SelectedIndex == 1)
						{
							ops1[0x03] |= 0x02;
						}
					}
					if (inst.NodeVersion > 2)
					{
						ops1[0x03] &= 0xef;
						if (tfSubQ.Checked)
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
					if (tfIconTemp.Checked)
					{
						ops1[0x02] |= 0x80;
					}
					else
					{
						ops2[0x03] = Convert.ToByte(tbIconIndex.Text, 16);
					}

					ops1[0x02] &= 0xdf;
					if (pnThumbnail.Enabled)
					{
						ops1[0x02] |= 0x20;

						ops1[0x02] &= 0xbf;
						if (tfGUIDTemp.Checked)
						{
							ops1[0x02] |= 0x40;
						}
						else
						{
							uint val = Convert.ToUInt32(tbGUID.Text, 16);
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
			pnWiz0x0032 = new Panel();
			rbModeIcon = new RadioButton();
			rbModeAction = new RadioButton();
			pnAction = new Panel();
			tfSubQ = new CheckBox();
			pnStrIndex = new Panel();
			label5 = new Label();
			btnActionString = new Button();
			tbStrIndex = new TextBox();
			lbActionString = new Label();
			tfActionTemp = new CheckBox();
			cbDisabled = new ComboBox();
			cbScope = new ComboBox();
			label3 = new Label();
			lbDisabled = new Label();
			label1 = new Label();
			pnIcon = new Panel();
			pnObject = new Panel();
			cbAttrPicker = new CheckBox();
			cbDecimal = new CheckBox();
			cbPicker1 = new ComboBox();
			tbVal1 = new TextBox();
			cbDataOwner1 = new ComboBox();
			label9 = new Label();
			pnThumbnail = new Panel();
			tfGUIDTemp = new CheckBox();
			pnGUID = new Panel();
			label8 = new Label();
			tbGUID = new TextBox();
			label7 = new Label();
			rbIconSourceObj = new RadioButton();
			rbIconSourceTN = new RadioButton();
			tfIconTemp = new CheckBox();
			pnIconIndex = new Panel();
			label6 = new Label();
			tbIconIndex = new TextBox();
			label10 = new Label();
			label4 = new Label();
			pnWiz0x0032.SuspendLayout();
			pnAction.SuspendLayout();
			pnStrIndex.SuspendLayout();
			pnIcon.SuspendLayout();
			pnObject.SuspendLayout();
			pnThumbnail.SuspendLayout();
			pnGUID.SuspendLayout();
			pnIconIndex.SuspendLayout();
			SuspendLayout();
			//
			// pnWiz0x0032
			//
			pnWiz0x0032.Controls.Add(rbModeIcon);
			pnWiz0x0032.Controls.Add(rbModeAction);
			pnWiz0x0032.Controls.Add(pnAction);
			pnWiz0x0032.Controls.Add(pnIcon);
			resources.ApplyResources(pnWiz0x0032, "pnWiz0x0032");
			pnWiz0x0032.Name = "pnWiz0x0032";
			//
			// rbModeIcon
			//
			resources.ApplyResources(rbModeIcon, "rbModeIcon");
			rbModeIcon.Name = "rbModeIcon";
			rbModeIcon.TabStop = true;
			rbModeIcon.UseVisualStyleBackColor = true;
			rbModeIcon.CheckedChanged += new EventHandler(
				rbModeIcon_CheckedChanged
			);
			//
			// rbModeAction
			//
			resources.ApplyResources(rbModeAction, "rbModeAction");
			rbModeAction.Name = "rbModeAction";
			rbModeAction.TabStop = true;
			rbModeAction.UseVisualStyleBackColor = true;
			rbModeAction.CheckedChanged += new EventHandler(
				rbModeAction_CheckedChanged
			);
			//
			// pnAction
			//
			pnAction.Controls.Add(tfSubQ);
			pnAction.Controls.Add(pnStrIndex);
			pnAction.Controls.Add(tfActionTemp);
			pnAction.Controls.Add(cbDisabled);
			pnAction.Controls.Add(cbScope);
			pnAction.Controls.Add(label3);
			pnAction.Controls.Add(lbDisabled);
			pnAction.Controls.Add(label1);
			resources.ApplyResources(pnAction, "pnAction");
			pnAction.Name = "pnAction";
			//
			// tfSubQ
			//
			resources.ApplyResources(tfSubQ, "tfSubQ");
			tfSubQ.Name = "tfSubQ";
			tfSubQ.UseVisualStyleBackColor = true;
			//
			// pnStrIndex
			//
			resources.ApplyResources(pnStrIndex, "pnStrIndex");
			pnStrIndex.Controls.Add(label5);
			pnStrIndex.Controls.Add(btnActionString);
			pnStrIndex.Controls.Add(tbStrIndex);
			pnStrIndex.Controls.Add(lbActionString);
			pnStrIndex.Name = "pnStrIndex";
			//
			// label5
			//
			resources.ApplyResources(label5, "label5");
			label5.Name = "label5";
			//
			// btnActionString
			//
			resources.ApplyResources(btnActionString, "btnActionString");
			btnActionString.Name = "btnActionString";
			btnActionString.Click += new EventHandler(
				btnActionString_Click
			);
			//
			// tbStrIndex
			//
			resources.ApplyResources(tbStrIndex, "tbStrIndex");
			tbStrIndex.Name = "tbStrIndex";
			tbStrIndex.TextChanged += new EventHandler(
				hex16_TextChanged
			);
			tbStrIndex.Validated += new EventHandler(hex16_Validated);
			tbStrIndex.Validating += new System.ComponentModel.CancelEventHandler(
				hex16_Validating
			);
			//
			// lbActionString
			//
			resources.ApplyResources(lbActionString, "lbActionString");
			lbActionString.Name = "lbActionString";
			//
			// tfActionTemp
			//
			resources.ApplyResources(tfActionTemp, "tfActionTemp");
			tfActionTemp.Name = "tfActionTemp";
			tfActionTemp.UseVisualStyleBackColor = true;
			tfActionTemp.CheckedChanged += new EventHandler(
				tfActionTemp_CheckedChanged
			);
			//
			// cbDisabled
			//
			cbDisabled.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbDisabled.FormattingEnabled = true;
			cbDisabled.Items.AddRange(
				new object[]
				{
					resources.GetString("cbDisabled.Items"),
					resources.GetString("cbDisabled.Items1"),
					resources.GetString("cbDisabled.Items2"),
				}
			);
			resources.ApplyResources(cbDisabled, "cbDisabled");
			cbDisabled.Name = "cbDisabled";
			//
			// cbScope
			//
			cbScope.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbScope.FormattingEnabled = true;
			cbScope.Items.AddRange(
				new object[]
				{
					resources.GetString("cbScope.Items"),
					resources.GetString("cbScope.Items1"),
					resources.GetString("cbScope.Items2"),
				}
			);
			resources.ApplyResources(cbScope, "cbScope");
			cbScope.Name = "cbScope";
			cbScope.SelectedIndexChanged += new EventHandler(
				cbScope_SelectedIndexChanged
			);
			//
			// label3
			//
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			//
			// lbDisabled
			//
			resources.ApplyResources(lbDisabled, "lbDisabled");
			lbDisabled.Name = "lbDisabled";
			//
			// label1
			//
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			//
			// pnIcon
			//
			pnIcon.Controls.Add(pnObject);
			pnIcon.Controls.Add(pnThumbnail);
			pnIcon.Controls.Add(rbIconSourceObj);
			pnIcon.Controls.Add(rbIconSourceTN);
			pnIcon.Controls.Add(tfIconTemp);
			pnIcon.Controls.Add(pnIconIndex);
			pnIcon.Controls.Add(label10);
			pnIcon.Controls.Add(label4);
			resources.ApplyResources(pnIcon, "pnIcon");
			pnIcon.Name = "pnIcon";
			//
			// pnObject
			//
			pnObject.Controls.Add(cbAttrPicker);
			pnObject.Controls.Add(cbDecimal);
			pnObject.Controls.Add(cbPicker1);
			pnObject.Controls.Add(tbVal1);
			pnObject.Controls.Add(cbDataOwner1);
			pnObject.Controls.Add(label9);
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
			// label9
			//
			resources.ApplyResources(label9, "label9");
			label9.Name = "label9";
			//
			// pnThumbnail
			//
			pnThumbnail.Controls.Add(tfGUIDTemp);
			pnThumbnail.Controls.Add(pnGUID);
			pnThumbnail.Controls.Add(label7);
			resources.ApplyResources(pnThumbnail, "pnThumbnail");
			pnThumbnail.Name = "pnThumbnail";
			//
			// tfGUIDTemp
			//
			resources.ApplyResources(tfGUIDTemp, "tfGUIDTemp");
			tfGUIDTemp.Name = "tfGUIDTemp";
			tfGUIDTemp.UseVisualStyleBackColor = true;
			tfGUIDTemp.CheckedChanged += new EventHandler(
				tfGUIDTemp_CheckedChanged
			);
			//
			// pnGUID
			//
			pnGUID.Controls.Add(label8);
			pnGUID.Controls.Add(tbGUID);
			resources.ApplyResources(pnGUID, "pnGUID");
			pnGUID.Name = "pnGUID";
			//
			// label8
			//
			resources.ApplyResources(label8, "label8");
			label8.Name = "label8";
			//
			// tbGUID
			//
			resources.ApplyResources(tbGUID, "tbGUID");
			tbGUID.Name = "tbGUID";
			tbGUID.Validated += new EventHandler(hex32_Validated);
			tbGUID.Validating += new System.ComponentModel.CancelEventHandler(
				hex32_Validating
			);
			//
			// label7
			//
			resources.ApplyResources(label7, "label7");
			label7.Name = "label7";
			//
			// rbIconSourceObj
			//
			resources.ApplyResources(rbIconSourceObj, "rbIconSourceObj");
			rbIconSourceObj.Name = "rbIconSourceObj";
			rbIconSourceObj.TabStop = true;
			rbIconSourceObj.UseVisualStyleBackColor = true;
			rbIconSourceObj.CheckedChanged += new EventHandler(
				rbIconSourceObj_CheckedChanged
			);
			//
			// rbIconSourceTN
			//
			resources.ApplyResources(rbIconSourceTN, "rbIconSourceTN");
			rbIconSourceTN.Name = "rbIconSourceTN";
			rbIconSourceTN.TabStop = true;
			rbIconSourceTN.UseVisualStyleBackColor = true;
			rbIconSourceTN.CheckedChanged += new EventHandler(
				rbIconSourceTN_CheckedChanged
			);
			//
			// tfIconTemp
			//
			resources.ApplyResources(tfIconTemp, "tfIconTemp");
			tfIconTemp.Name = "tfIconTemp";
			tfIconTemp.UseVisualStyleBackColor = true;
			tfIconTemp.CheckedChanged += new EventHandler(
				tfIconTemp_CheckedChanged
			);
			//
			// pnIconIndex
			//
			pnIconIndex.Controls.Add(label6);
			pnIconIndex.Controls.Add(tbIconIndex);
			resources.ApplyResources(pnIconIndex, "pnIconIndex");
			pnIconIndex.Name = "pnIconIndex";
			//
			// label6
			//
			resources.ApplyResources(label6, "label6");
			label6.Name = "label6";
			//
			// tbIconIndex
			//
			resources.ApplyResources(tbIconIndex, "tbIconIndex");
			tbIconIndex.Name = "tbIconIndex";
			tbIconIndex.Validated += new EventHandler(hex8_Validated);
			tbIconIndex.Validating += new System.ComponentModel.CancelEventHandler(
				hex8_Validating
			);
			//
			// label10
			//
			resources.ApplyResources(label10, "label10");
			label10.Name = "label10";
			//
			// label4
			//
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			//
			// UI
			//
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Dpi;
			Controls.Add(pnWiz0x0032);
			Name = "UI";
			pnWiz0x0032.ResumeLayout(false);
			pnWiz0x0032.PerformLayout();
			pnAction.ResumeLayout(false);
			pnAction.PerformLayout();
			pnStrIndex.ResumeLayout(false);
			pnStrIndex.PerformLayout();
			pnIcon.ResumeLayout(false);
			pnIcon.PerformLayout();
			pnObject.ResumeLayout(false);
			pnObject.PerformLayout();
			pnThumbnail.ResumeLayout(false);
			pnThumbnail.PerformLayout();
			pnGUID.ResumeLayout(false);
			pnGUID.PerformLayout();
			pnIconIndex.ResumeLayout(false);
			pnIconIndex.PerformLayout();
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
			((TextBox)sender).Text =
				"0x" + SimPe.Helper.HexString(inst.Reserved1[0x03]);
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

		private void hex16_TextChanged(object sender, EventArgs ev)
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
			lbActionString.Text = ((BhavWiz)inst).readStr(
				Scope,
				GS.GlobalStr.MakeAction,
				(ushort)(val - 1),
				-1,
				Detail.ErrorNames
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
			lbActionString.Text = ((BhavWiz)inst).readStr(
				Scope,
				GS.GlobalStr.MakeAction,
				(ushort)(val - 1),
				-1,
				Detail.ErrorNames
			);
			((TextBox)sender).Text = "0x" + SimPe.Helper.HexString(val);
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
				+ SimPe.Helper.HexStringInt(
					inst.Operands[0x05]
						| (inst.Operands[0x06] << 8)
						| (inst.Operands[0x07] << 16)
						| (inst.Reserved1[0x00] << 24)
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

		private void cbScope_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			lbActionString.Text = ((BhavWiz)inst).readStr(
				Scope,
				GS.GlobalStr.MakeAction,
				(ushort)(Convert.ToByte(tbStrIndex.Text, 16) - 1),
				-1,
				Detail.ErrorNames
			);
		}

		private void tfActionTemp_CheckedChanged(object sender, EventArgs e)
		{
			pnStrIndex.Enabled = !((CheckBox)sender).Checked;
		}

		private void tfIconTemp_CheckedChanged(object sender, EventArgs e)
		{
			pnIconIndex.Enabled = !((CheckBox)sender).Checked;
		}

		private void rbModeAction_CheckedChanged(object sender, EventArgs e)
		{
			pnAction.Enabled = ((RadioButton)sender).Checked;
		}

		private void rbModeIcon_CheckedChanged(object sender, EventArgs e)
		{
			pnIcon.Enabled = ((RadioButton)sender).Checked;
		}

		private void rbIconSourceTN_CheckedChanged(object sender, EventArgs e)
		{
			pnThumbnail.Enabled = ((RadioButton)sender).Checked;
		}

		private void rbIconSourceObj_CheckedChanged(object sender, EventArgs e)
		{
			pnObject.Enabled = ((RadioButton)sender).Checked;
		}

		private void tfGUIDTemp_CheckedChanged(object sender, EventArgs e)
		{
			pnGUID.Enabled = !((CheckBox)sender).Checked;
		}

		private void btnActionString_Click(object sender, EventArgs e)
		{
			doStrChooser();
		}
	}
}

namespace pjse.BhavOperandWizards
{
	public class BhavOperandWiz0x0032 : ABhavOperandWiz
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
