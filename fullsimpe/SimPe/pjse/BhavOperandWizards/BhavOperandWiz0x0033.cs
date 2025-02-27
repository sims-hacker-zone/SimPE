/***************************************************************************
 *   Copyright (C) 2007 by Peter L Jones                                   *
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
using System.Collections.Generic;
using System.Windows.Forms;

using SimPe.PackedFiles.Wrapper;

namespace pjse.BhavOperandWizards.Wiz0x0033
{
	internal class UI : Form, iBhavOperandWizForm
	{
		#region Form variables

		internal Panel pnWiz0x0033;
		private TableLayoutPanel tlpnGetSetValue;
		private Panel pnDoid1;
		private ComboBox cbPicker1;
		private TextBox tbVal1;
		private ComboBox cbDataOwner1;
		private Label lbDoid2;
		private Label lbDoid1;
		private Label lbDoid3;
		private Panel pnDoid2;
		private ComboBox cbPicker2;
		private TextBox tbVal2;
		private ComboBox cbDataOwner2;
		private Panel pnDoid3;
		private ComboBox cbPicker3;
		private TextBox tbVal3;
		private ComboBox cbDataOwner3;
		private Label lbGUID;
		private ComboBox cbInventory;
		private Label lbInventory;
		private FlowLayoutPanel flpnGUID;
		private TextBox tbGUID;
		private TextBox tbObjName;
		private GroupBox gbTokenTypes;
		private TableLayoutPanel tableLayoutPanel1;
		private CheckBox ckbTTInvShopping;
		private CheckBox ckbTTShopping;
		private CheckBox ckbTTInvMemory;
		private CheckBox ckbTTMemory;
		private CheckBox ckbTTInvVisible;
		private CheckBox ckbTTVisible;
		private GroupBox gbInventoryType;
		private FlowLayoutPanel flpnInventoryType;
		private RadioButton rb1Counted;
		private RadioButton rb1Singular;
		private FlowLayoutPanel flpnDoid0;
		private Label lbDoid0;
		private Panel pnDoid0;
		private ComboBox cbPicker0;
		private TextBox tbVal0;
		private ComboBox cbDataOwner0;
		private Label lbOperation;
		private FlowLayoutPanel flpnOperation;
		private ComboBox cbOperation;
		private CheckBox ckbReversed;
		private ComboBox cbTargetInv;
		private CheckBox ckbTTAll;
		private FlowLayoutPanel flowLayoutPanel1;
		private CheckBox ckbDecimal;
		private CheckBox ckbAttrPicker;

		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion


		/// <summary>
		/// Initialise the Wizard user interface
		/// </summary>
		/// <param name="mode">Specify whether the wizard is for Animate Object, Sim or Overlay</param>
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

		#region static data
		static List<String> aInventoryType = BhavWiz.readStr(GS.BhavStr.InventoryType);
		static List<String> aTokenOpsCounted = BhavWiz.readStr(
			GS.BhavStr.TokenOpsCounted
		);
		static List<String> aTokenOpsSingular = BhavWiz.readStr(
			GS.BhavStr.TokenOpsSingular
		);
		static String[] names =
		{
			"",
			"Object",
			"bwp33_index",
			"bwp33_property",
			"bwp33_count",
			"Value",
		};
		static int[][] aNamesCounted =
		{
			new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // Doid0
			new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // Doid1
			new int[] { 0, 2, 0, 2, 0, 2, 2, 0, 2, 2, 0, 2 }, // Doid2
			new int[] { 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 4, 0 }, // Doid3
		};
		static int[][] aNamesSingular =
		{
			new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // Doid0
			new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 0, 0, 0, 0 }, // Doid1
			new int[] { 0, 2, 0, 2, 2, 2, 2, 3, 3, 0, 0, 0, 2, 0, 3, 3, 0, 2, 2, 0 }, // Doid2
			new int[] { 0, 0, 0, 0, 5, 5, 0, 5, 5, 0, 4, 0, 0, 4, 5, 5, 0, 0, 0, 0 }, // Doid3
		};
		static bool[] aByGUIDCounted = new bool[]
		{
			true,
			false,
			true,
			false,
			true,
			false,
			true,
			true,
			false,
			false,
			true,
			false,
		};
		static bool[] aByGUIDSingular = new bool[]
		{
			true,
			false,
			true,
			true,
			false,
			false,
			false,
			false,
			false,
			false,
			false,
			false,
			false,
			false,
			false,
			false,
			false,
			false,
			false,
			false,
		};
		static bool[] aCategoryCounted = new bool[]
		{
			true,
			false,
			true,
			false,
			true,
			false,
			true,
			true,
			false,
			true,
			true,
			true,
		};
		static bool[] aCategorySingular = new bool[]
		{
			true,
			false,
			true,
			true,
			false,
			false,
			false,
			false,
			false,
			false,
			false,
			true,
			true,
			true,
			false,
			false,
			true,
			false,
			true,
			true,
		};
		#endregion

		private bool internalchg = false;

		private Instruction inst = null;

		private DataOwnerControl doid0 = null; // o[1], o[2], o[3]
		private DataOwnerControl doid1 = null; // o[6], o[7], o[8]
		private DataOwnerControl doid2 = null; // o[10], o[11], o[12]
		private DataOwnerControl doid3 = null; // o[13], o[14], o[15]
		private byte operation = 0;
		private byte[] o5678 = new byte[4];

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
			{
				tbGUID.Text = "0x" + SimPe.Helper.HexString(guid);
			}

			tbObjName.Text =
				(guid == 0) ? BhavWiz.dnStkOb() : BhavWiz.FormatGUID(true, guid);
		}

		private void doTokenOps(List<String> tokenops)
		{
			cbOperation.Items.Clear();
			cbOperation.Items.AddRange(tokenops.ToArray());
			cbOperation.SelectedIndex =
				(operation < cbOperation.Items.Count) ? operation : -1;
		}

		private void doTokenType()
		{
			gbTokenTypes.Enabled = true;
			ckbTTInvVisible.Enabled = !ckbTTVisible.Enabled || ckbTTVisible.Checked;
			ckbTTInvMemory.Enabled = !ckbTTMemory.Enabled || ckbTTMemory.Checked;
			ckbTTInvShopping.Enabled = ckbTTShopping.Checked;
			ckbTTAll.Checked =
				!ckbTTVisible.Checked && !ckbTTMemory.Checked && !ckbTTShopping.Checked;
		}

		private void doFromInventory(bool enable)
		{
			if (enable)
			{
				cbInventory.Enabled = true;
			}

			int i = (o5678[1] & 0x07);
			cbInventory.SelectedIndex = (i < cbInventory.Items.Count) ? i : -1;
			lbDoid3.Text =
				(pnDoid3.Enabled = (i >= 1 && i <= 3))
					? cbInventory.SelectedItem.ToString()
					: "";
		}

		private void doByGUID()
		{
			flpnGUID.Enabled = true;
			setGUID(o5678, 0);
		}

		private void refreshDoid1()
		{
			tbVal1.Text =
				"0x" + SimPe.Helper.HexString(BhavWiz.ToShort(o5678[2], o5678[3]));
			cbDataOwner1.SelectedIndex =
				(cbDataOwner1.Items.Count > o5678[1]) ? o5678[1] : -1;
		}

		private void doBoth(
			List<String> aTokenOps,
			int[][] aNames,
			bool[] aByGUID,
			bool[] aCategory
		)
		{
			doTokenOps(aTokenOps);

			pnDoid1.Enabled = pnDoid2.Enabled = pnDoid3.Enabled = false;
			gbTokenTypes.Enabled = ckbReversed.Enabled = false;
			cbInventory.Enabled = false;
			flpnGUID.Enabled = false;
			tbObjName.Text = tbGUID.Text = "";
			gbInventoryType.Enabled = true;

			if (operation < aByGUID.Length && aByGUID[operation])
			{
				doByGUID();
			}

			if (operation < aCategory.Length && aCategory[operation])
			{
				doTokenType();
			}

			bool doid1Enabled = pnDoid1.Enabled;

			if (operation < aNames[0].Length)
			{
				lbDoid1.Text =
					(pnDoid1.Enabled = (aNames[1][operation] > 0))
						? Localization.GetString(names[aNames[1][operation]])
						: "";
				lbDoid2.Text =
					(pnDoid2.Enabled = (aNames[2][operation] > 0))
						? Localization.GetString(names[aNames[2][operation]])
						: "";
				lbDoid3.Text =
					(pnDoid3.Enabled = (aNames[3][operation] > 0))
						? Localization.GetString(names[aNames[3][operation]])
						: "";
			}

			if (!doid1Enabled && pnDoid1.Enabled)
			{
				refreshDoid1();
			}
		}

		private void doCounted()
		{
			doBoth(aTokenOpsCounted, aNamesCounted, aByGUIDCounted, aCategoryCounted);

			switch (operation)
			{
				case 0x0b:
					doFromInventory(true);
					break;
			}
		}

		private void doSingular()
		{
			doBoth(
				aTokenOpsSingular,
				aNamesSingular,
				aByGUIDSingular,
				aCategorySingular
			);

			switch (operation)
			{
				case 0x03:
					ckbReversed.Enabled = true;
					break;
				case 0x07:
					gbInventoryType.Enabled = false;
					break;
				case 0x08:
					gbInventoryType.Enabled = false;
					break;
				case 0x09:
					gbInventoryType.Enabled = false;
					break;
				case 0x0c:
					ckbReversed.Enabled = true;
					break;
				case 0x12:
					doFromInventory(true);
					break;
			}
		}

		#region iBhavOperandWizForm
		public Panel WizPanel => pnWiz0x0033;

		public void Execute(Instruction inst)
		{
			this.inst = inst;

			wrappedByteArray ops1 = inst.Operands;
			wrappedByteArray ops2 = inst.Reserved1;

			o5678[0] = ops1[5];
			o5678[1] = ops1[6];
			o5678[2] = ops1[7];
			o5678[3] = ops2[0];

			internalchg = true;

			Boolset option1 = ops1[0];
			if (inst.NodeVersion < 1)
			{
				// In the parser we have something like this...
				//option1 = (inst.NodeVersion >= 1) ? ops1[0] : (byte)(((ops1[0] & 0x3C) << 1) | (ops1[0] & 0x83));
				// 8765 4321
				// 0065 4300 <<1 =
				// 0654 3000 |
				// 8000 0021 =
				// 8654 3021

				List<String> aS = new List<string>(aInventoryType.ToArray());
				aS.RemoveRange(4, aS.Count - 4);
				cbTargetInv.Items.Clear();
				cbTargetInv.Items.AddRange(aS.ToArray());
				cbInventory.Items.Clear();
				cbInventory.Items.AddRange(aS.ToArray());
				cbTargetInv.SelectedIndex =
					((option1 & 0x03) < cbTargetInv.Items.Count) ? option1 & 0x03 : -1;

				rb1Counted.Checked = option1[2];
				ckbTTInvVisible.Checked = !option1[3];
				ckbTTInvMemory.Checked = !option1[4];
			}
			else
			{
				cbTargetInv.Items.Clear();
				cbTargetInv.Items.AddRange(aInventoryType.ToArray());
				cbInventory.Items.Clear();
				cbInventory.Items.AddRange(aInventoryType.ToArray());
				cbTargetInv.SelectedIndex =
					((option1 & 0x07) < cbTargetInv.Items.Count) ? option1 & 0x07 : -1;

				rb1Counted.Checked = option1[3];
				ckbTTInvVisible.Checked = !option1[4];
				ckbTTInvMemory.Checked = !option1[5];
			}
			ckbReversed.Checked = option1[7];

			pnDoid0.Enabled = (
				cbTargetInv.SelectedIndex >= 1 && cbTargetInv.SelectedIndex <= 3
			);
			lbDoid0.Text = pnDoid0.Enabled ? cbTargetInv.SelectedItem.ToString() : "";
			rb1Singular.Checked = !rb1Counted.Checked;

			doid0 = new DataOwnerControl(
				inst,
				cbDataOwner0,
				cbPicker0,
				tbVal0,
				ckbDecimal,
				ckbAttrPicker,
				null,
				ops1[1],
				BhavWiz.ToShort(ops1[2], ops1[3])
			);

			operation = ops1[4];

			doid1 = new DataOwnerControl(
				inst,
				cbDataOwner1,
				cbPicker1,
				tbVal1,
				ckbDecimal,
				ckbAttrPicker,
				null,
				o5678[1],
				BhavWiz.ToShort(o5678[2], o5678[3])
			);
			doid1.DataOwnerControlChanged += new EventHandler(
				doid1_DataOwnerControlChanged
			);

			ckbTTVisible.Enabled =
				ckbTTMemory.Enabled =
				ckbTTShopping.Enabled =
					(inst.NodeVersion >= 2);
			if (inst.NodeVersion >= 2)
			{
				Boolset option2 = ops2[1];
				ckbTTInvShopping.Checked = !option2[0];
				ckbTTVisible.Checked = option2[2];
				ckbTTMemory.Checked = option2[3];
				ckbTTShopping.Checked = option2[5];
			}

			doid2 = new DataOwnerControl(
				inst,
				cbDataOwner2,
				cbPicker2,
				tbVal2,
				ckbDecimal,
				ckbAttrPicker,
				null,
				ops2[2],
				BhavWiz.ToShort(ops2[3], ops2[4])
			);

			doid3 = new DataOwnerControl(
				inst,
				cbDataOwner3,
				cbPicker3,
				tbVal3,
				ckbDecimal,
				ckbAttrPicker,
				null,
				ops2[5],
				BhavWiz.ToShort(ops2[6], ops2[7])
			);

			if (rb1Counted.Checked)
			{
				doCounted();
			}
			else
			{
				doSingular();
			}

			cbOperation.SelectedIndex =
				(operation < cbOperation.Items.Count) ? operation : -1;

			internalchg = false;
		}

		void doid1_DataOwnerControlChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			if (doid1.DataOwner >= 0)
			{
				o5678[1] = doid1.DataOwner;
			}

			BhavWiz.FromShort(ref o5678, 2, doid1.Value);
		}

		public Instruction Write(Instruction inst)
		{
			if (inst != null)
			{
				wrappedByteArray ops1 = inst.Operands;
				wrappedByteArray ops2 = inst.Reserved1;

				Boolset option1 = ops1[0];
				if (inst.NodeVersion < 1)
				{
					if (cbTargetInv.SelectedIndex >= 0)
					{
						option1 = (byte)(
							(option1 & 0xfc) | (cbTargetInv.SelectedIndex & 0x03)
						);
					}

					option1[2] = rb1Counted.Checked;
					option1[3] = !ckbTTInvVisible.Checked;
					option1[4] = !ckbTTInvMemory.Checked;
				}
				else
				{
					if (cbTargetInv.SelectedIndex >= 0)
					{
						option1 = (byte)(
							(option1 & 0xf8) | (cbTargetInv.SelectedIndex & 0x07)
						);
					}

					option1[3] = rb1Counted.Checked;
					option1[4] = !ckbTTInvVisible.Checked;
					option1[5] = !ckbTTInvMemory.Checked;
				}
				option1[7] = ckbReversed.Checked;
				ops1[0] = option1;

				ops1[1] = doid0.DataOwner;
				BhavWiz.FromShort(ref ops1, 2, doid0.Value);

				ops1[4] = operation;

				ops1[5] = o5678[0];
				ops1[6] = o5678[1];
				ops1[7] = o5678[2];
				ops2[0] = o5678[3];

				if (inst.NodeVersion >= 2)
				{
					Boolset option2 = ops2[1];
					option2[0] = !ckbTTInvShopping.Checked;
					option2[2] = ckbTTVisible.Checked;
					option2[3] = ckbTTMemory.Checked;
					option2[5] = ckbTTShopping.Checked;
					ops2[1] = option2;
				}

				ops2[2] = doid2.DataOwner;
				BhavWiz.FromShort(ref ops2, 3, doid2.Value);

				ops2[5] = doid3.DataOwner;
				BhavWiz.FromShort(ref ops2, 6, doid3.Value);
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
			pnWiz0x0033 = new Panel();
			tlpnGetSetValue = new TableLayoutPanel();
			flowLayoutPanel1 = new FlowLayoutPanel();
			ckbDecimal = new CheckBox();
			ckbAttrPicker = new CheckBox();
			lbOperation = new Label();
			flpnOperation = new FlowLayoutPanel();
			cbOperation = new ComboBox();
			ckbReversed = new CheckBox();
			gbTokenTypes = new GroupBox();
			tableLayoutPanel1 = new TableLayoutPanel();
			ckbTTAll = new CheckBox();
			ckbTTInvShopping = new CheckBox();
			ckbTTShopping = new CheckBox();
			ckbTTInvMemory = new CheckBox();
			ckbTTMemory = new CheckBox();
			ckbTTInvVisible = new CheckBox();
			ckbTTVisible = new CheckBox();
			gbInventoryType = new GroupBox();
			flpnDoid0 = new FlowLayoutPanel();
			lbDoid0 = new Label();
			pnDoid0 = new Panel();
			cbPicker0 = new ComboBox();
			tbVal0 = new TextBox();
			cbDataOwner0 = new ComboBox();
			flpnInventoryType = new FlowLayoutPanel();
			rb1Counted = new RadioButton();
			rb1Singular = new RadioButton();
			cbTargetInv = new ComboBox();
			lbDoid1 = new Label();
			pnDoid1 = new Panel();
			cbPicker1 = new ComboBox();
			tbVal1 = new TextBox();
			cbDataOwner1 = new ComboBox();
			pnDoid3 = new Panel();
			cbPicker3 = new ComboBox();
			tbVal3 = new TextBox();
			cbDataOwner3 = new ComboBox();
			pnDoid2 = new Panel();
			cbPicker2 = new ComboBox();
			tbVal2 = new TextBox();
			cbDataOwner2 = new ComboBox();
			lbInventory = new Label();
			lbDoid3 = new Label();
			cbInventory = new ComboBox();
			flpnGUID = new FlowLayoutPanel();
			tbGUID = new TextBox();
			tbObjName = new TextBox();
			lbDoid2 = new Label();
			lbGUID = new Label();
			pnWiz0x0033.SuspendLayout();
			tlpnGetSetValue.SuspendLayout();
			flowLayoutPanel1.SuspendLayout();
			flpnOperation.SuspendLayout();
			gbTokenTypes.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			gbInventoryType.SuspendLayout();
			flpnDoid0.SuspendLayout();
			pnDoid0.SuspendLayout();
			flpnInventoryType.SuspendLayout();
			pnDoid1.SuspendLayout();
			pnDoid3.SuspendLayout();
			pnDoid2.SuspendLayout();
			flpnGUID.SuspendLayout();
			SuspendLayout();
			//
			// pnWiz0x0033
			//
			resources.ApplyResources(pnWiz0x0033, "pnWiz0x0033");
			pnWiz0x0033.Controls.Add(tlpnGetSetValue);
			pnWiz0x0033.Name = "pnWiz0x0033";
			//
			// tlpnGetSetValue
			//
			resources.ApplyResources(tlpnGetSetValue, "tlpnGetSetValue");
			tlpnGetSetValue.Controls.Add(flowLayoutPanel1, 1, 7);
			tlpnGetSetValue.Controls.Add(lbOperation, 0, 0);
			tlpnGetSetValue.Controls.Add(flpnOperation, 1, 0);
			tlpnGetSetValue.Controls.Add(gbTokenTypes, 0, 6);
			tlpnGetSetValue.Controls.Add(gbInventoryType, 1, 6);
			tlpnGetSetValue.Controls.Add(lbDoid1, 0, 1);
			tlpnGetSetValue.Controls.Add(pnDoid1, 1, 1);
			tlpnGetSetValue.Controls.Add(pnDoid3, 1, 5);
			tlpnGetSetValue.Controls.Add(pnDoid2, 1, 4);
			tlpnGetSetValue.Controls.Add(lbInventory, 0, 2);
			tlpnGetSetValue.Controls.Add(lbDoid3, 0, 5);
			tlpnGetSetValue.Controls.Add(cbInventory, 1, 2);
			tlpnGetSetValue.Controls.Add(flpnGUID, 1, 3);
			tlpnGetSetValue.Controls.Add(lbDoid2, 0, 4);
			tlpnGetSetValue.Controls.Add(lbGUID, 0, 3);
			tlpnGetSetValue.Name = "tlpnGetSetValue";
			//
			// flowLayoutPanel1
			//
			resources.ApplyResources(flowLayoutPanel1, "flowLayoutPanel1");
			flowLayoutPanel1.Controls.Add(ckbDecimal);
			flowLayoutPanel1.Controls.Add(ckbAttrPicker);
			flowLayoutPanel1.Name = "flowLayoutPanel1";
			//
			// ckbDecimal
			//
			resources.ApplyResources(ckbDecimal, "ckbDecimal");
			ckbDecimal.Name = "ckbDecimal";
			//
			// ckbAttrPicker
			//
			resources.ApplyResources(ckbAttrPicker, "ckbAttrPicker");
			ckbAttrPicker.Name = "ckbAttrPicker";
			//
			// lbOperation
			//
			resources.ApplyResources(lbOperation, "lbOperation");
			lbOperation.Name = "lbOperation";
			//
			// flpnOperation
			//
			resources.ApplyResources(flpnOperation, "flpnOperation");
			flpnOperation.Controls.Add(cbOperation);
			flpnOperation.Controls.Add(ckbReversed);
			flpnOperation.Name = "flpnOperation";
			//
			// cbOperation
			//
			cbOperation.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbOperation.DropDownWidth = 480;
			cbOperation.FormattingEnabled = true;
			resources.ApplyResources(cbOperation, "cbOperation");
			cbOperation.Name = "cbOperation";
			cbOperation.SelectedIndexChanged += new EventHandler(
				cbOperation_SelectedIndexChanged
			);
			//
			// ckbReversed
			//
			resources.ApplyResources(ckbReversed, "ckbReversed");
			ckbReversed.Name = "ckbReversed";
			ckbReversed.UseVisualStyleBackColor = true;
			//
			// gbTokenTypes
			//
			resources.ApplyResources(gbTokenTypes, "gbTokenTypes");
			gbTokenTypes.Controls.Add(tableLayoutPanel1);
			gbTokenTypes.Name = "gbTokenTypes";
			gbTokenTypes.TabStop = false;
			//
			// tableLayoutPanel1
			//
			resources.ApplyResources(tableLayoutPanel1, "tableLayoutPanel1");
			tableLayoutPanel1.Controls.Add(ckbTTAll, 0, 3);
			tableLayoutPanel1.Controls.Add(ckbTTInvShopping, 1, 2);
			tableLayoutPanel1.Controls.Add(ckbTTShopping, 0, 2);
			tableLayoutPanel1.Controls.Add(ckbTTInvMemory, 1, 1);
			tableLayoutPanel1.Controls.Add(ckbTTMemory, 0, 1);
			tableLayoutPanel1.Controls.Add(ckbTTInvVisible, 1, 0);
			tableLayoutPanel1.Controls.Add(ckbTTVisible, 0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			//
			// ckbTTAll
			//
			resources.ApplyResources(ckbTTAll, "ckbTTAll");
			ckbTTAll.Checked = true;
			ckbTTAll.CheckState = CheckState.Checked;
			ckbTTAll.Name = "ckbTTAll";
			ckbTTAll.TabStop = false;
			ckbTTAll.UseVisualStyleBackColor = true;
			//
			// ckbTTInvShopping
			//
			resources.ApplyResources(ckbTTInvShopping, "ckbTTInvShopping");
			ckbTTInvShopping.Name = "ckbTTInvShopping";
			ckbTTInvShopping.UseVisualStyleBackColor = true;
			//
			// ckbTTShopping
			//
			resources.ApplyResources(ckbTTShopping, "ckbTTShopping");
			ckbTTShopping.Name = "ckbTTShopping";
			ckbTTShopping.UseVisualStyleBackColor = true;
			ckbTTShopping.CheckedChanged += new EventHandler(
				ckbTT_CheckedChanged
			);
			//
			// ckbTTInvMemory
			//
			resources.ApplyResources(ckbTTInvMemory, "ckbTTInvMemory");
			ckbTTInvMemory.Name = "ckbTTInvMemory";
			ckbTTInvMemory.UseVisualStyleBackColor = true;
			//
			// ckbTTMemory
			//
			resources.ApplyResources(ckbTTMemory, "ckbTTMemory");
			ckbTTMemory.Name = "ckbTTMemory";
			ckbTTMemory.UseVisualStyleBackColor = true;
			ckbTTMemory.CheckedChanged += new EventHandler(
				ckbTT_CheckedChanged
			);
			//
			// ckbTTInvVisible
			//
			resources.ApplyResources(ckbTTInvVisible, "ckbTTInvVisible");
			ckbTTInvVisible.Name = "ckbTTInvVisible";
			ckbTTInvVisible.UseVisualStyleBackColor = true;
			//
			// ckbTTVisible
			//
			resources.ApplyResources(ckbTTVisible, "ckbTTVisible");
			ckbTTVisible.Name = "ckbTTVisible";
			ckbTTVisible.UseVisualStyleBackColor = true;
			ckbTTVisible.CheckedChanged += new EventHandler(
				ckbTT_CheckedChanged
			);
			//
			// gbInventoryType
			//
			resources.ApplyResources(gbInventoryType, "gbInventoryType");
			gbInventoryType.Controls.Add(flpnDoid0);
			gbInventoryType.Controls.Add(flpnInventoryType);
			gbInventoryType.Name = "gbInventoryType";
			gbInventoryType.TabStop = false;
			//
			// flpnDoid0
			//
			resources.ApplyResources(flpnDoid0, "flpnDoid0");
			flpnDoid0.Controls.Add(lbDoid0);
			flpnDoid0.Controls.Add(pnDoid0);
			flpnDoid0.Name = "flpnDoid0";
			//
			// lbDoid0
			//
			resources.ApplyResources(lbDoid0, "lbDoid0");
			lbDoid0.Name = "lbDoid0";
			lbDoid0.Tag = "";
			//
			// pnDoid0
			//
			resources.ApplyResources(pnDoid0, "pnDoid0");
			pnDoid0.Controls.Add(cbPicker0);
			pnDoid0.Controls.Add(tbVal0);
			pnDoid0.Controls.Add(cbDataOwner0);
			pnDoid0.Name = "pnDoid0";
			//
			// cbPicker0
			//
			cbPicker0.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbPicker0.DropDownWidth = 384;
			resources.ApplyResources(cbPicker0, "cbPicker0");
			cbPicker0.Name = "cbPicker0";
			cbPicker0.TabStop = false;
			//
			// tbVal0
			//
			resources.ApplyResources(tbVal0, "tbVal0");
			tbVal0.Name = "tbVal0";
			tbVal0.TabStop = false;
			//
			// cbDataOwner0
			//
			cbDataOwner0.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbDataOwner0.DropDownWidth = 384;
			resources.ApplyResources(cbDataOwner0, "cbDataOwner0");
			cbDataOwner0.Name = "cbDataOwner0";
			//
			// flpnInventoryType
			//
			resources.ApplyResources(flpnInventoryType, "flpnInventoryType");
			flpnInventoryType.Controls.Add(rb1Counted);
			flpnInventoryType.Controls.Add(rb1Singular);
			flpnInventoryType.Controls.Add(cbTargetInv);
			flpnInventoryType.Name = "flpnInventoryType";
			//
			// rb1Counted
			//
			resources.ApplyResources(rb1Counted, "rb1Counted");
			rb1Counted.Name = "rb1Counted";
			rb1Counted.TabStop = true;
			rb1Counted.UseVisualStyleBackColor = true;
			rb1Counted.CheckedChanged += new EventHandler(
				rb1_CheckedChanged
			);
			//
			// rb1Singular
			//
			resources.ApplyResources(rb1Singular, "rb1Singular");
			rb1Singular.Name = "rb1Singular";
			rb1Singular.TabStop = true;
			rb1Singular.UseVisualStyleBackColor = true;
			rb1Singular.CheckedChanged += new EventHandler(
				rb1_CheckedChanged
			);
			//
			// cbTargetInv
			//
			cbTargetInv.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbTargetInv.FormattingEnabled = true;
			resources.ApplyResources(cbTargetInv, "cbTargetInv");
			cbTargetInv.Name = "cbTargetInv";
			cbTargetInv.SelectedIndexChanged += new EventHandler(
				cbTargetInv_SelectedIndexChanged
			);
			//
			// lbDoid1
			//
			resources.ApplyResources(lbDoid1, "lbDoid1");
			lbDoid1.Name = "lbDoid1";
			//
			// pnDoid1
			//
			resources.ApplyResources(pnDoid1, "pnDoid1");
			pnDoid1.Controls.Add(cbPicker1);
			pnDoid1.Controls.Add(tbVal1);
			pnDoid1.Controls.Add(cbDataOwner1);
			pnDoid1.Name = "pnDoid1";
			//
			// cbPicker1
			//
			cbPicker1.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbPicker1.DropDownWidth = 384;
			resources.ApplyResources(cbPicker1, "cbPicker1");
			cbPicker1.Name = "cbPicker1";
			cbPicker1.TabStop = false;
			//
			// tbVal1
			//
			resources.ApplyResources(tbVal1, "tbVal1");
			tbVal1.Name = "tbVal1";
			tbVal1.TabStop = false;
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
			// pnDoid3
			//
			resources.ApplyResources(pnDoid3, "pnDoid3");
			pnDoid3.Controls.Add(cbPicker3);
			pnDoid3.Controls.Add(tbVal3);
			pnDoid3.Controls.Add(cbDataOwner3);
			pnDoid3.Name = "pnDoid3";
			//
			// cbPicker3
			//
			cbPicker3.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbPicker3.DropDownWidth = 384;
			resources.ApplyResources(cbPicker3, "cbPicker3");
			cbPicker3.Name = "cbPicker3";
			cbPicker3.TabStop = false;
			//
			// tbVal3
			//
			resources.ApplyResources(tbVal3, "tbVal3");
			tbVal3.Name = "tbVal3";
			tbVal3.TabStop = false;
			//
			// cbDataOwner3
			//
			cbDataOwner3.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbDataOwner3.DropDownWidth = 384;
			resources.ApplyResources(cbDataOwner3, "cbDataOwner3");
			cbDataOwner3.Name = "cbDataOwner3";
			//
			// pnDoid2
			//
			resources.ApplyResources(pnDoid2, "pnDoid2");
			pnDoid2.Controls.Add(cbPicker2);
			pnDoid2.Controls.Add(tbVal2);
			pnDoid2.Controls.Add(cbDataOwner2);
			pnDoid2.Name = "pnDoid2";
			//
			// cbPicker2
			//
			cbPicker2.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbPicker2.DropDownWidth = 384;
			resources.ApplyResources(cbPicker2, "cbPicker2");
			cbPicker2.Name = "cbPicker2";
			cbPicker2.TabStop = false;
			//
			// tbVal2
			//
			resources.ApplyResources(tbVal2, "tbVal2");
			tbVal2.Name = "tbVal2";
			tbVal2.TabStop = false;
			//
			// cbDataOwner2
			//
			cbDataOwner2.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbDataOwner2.DropDownWidth = 384;
			resources.ApplyResources(cbDataOwner2, "cbDataOwner2");
			cbDataOwner2.Name = "cbDataOwner2";
			//
			// lbInventory
			//
			resources.ApplyResources(lbInventory, "lbInventory");
			lbInventory.Name = "lbInventory";
			lbInventory.Tag = "";
			//
			// lbDoid3
			//
			resources.ApplyResources(lbDoid3, "lbDoid3");
			lbDoid3.Name = "lbDoid3";
			lbDoid3.Tag = "";
			//
			// cbInventory
			//
			cbInventory.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbInventory.DropDownWidth = 384;
			resources.ApplyResources(cbInventory, "cbInventory");
			cbInventory.Name = "cbInventory";
			cbInventory.SelectedIndexChanged += new EventHandler(
				cbInventory_SelectedIndexChanged
			);
			//
			// flpnGUID
			//
			resources.ApplyResources(flpnGUID, "flpnGUID");
			flpnGUID.Controls.Add(tbGUID);
			flpnGUID.Controls.Add(tbObjName);
			flpnGUID.Name = "flpnGUID";
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
			// tbObjName
			//
			resources.ApplyResources(tbObjName, "tbObjName");
			tbObjName.Name = "tbObjName";
			tbObjName.ReadOnly = true;
			tbObjName.TabStop = false;
			//
			// lbDoid2
			//
			resources.ApplyResources(lbDoid2, "lbDoid2");
			lbDoid2.Name = "lbDoid2";
			lbDoid2.Tag = "";
			//
			// lbGUID
			//
			resources.ApplyResources(lbGUID, "lbGUID");
			lbGUID.Name = "lbGUID";
			lbGUID.Tag = "";
			//
			// UI
			//
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(pnWiz0x0033);
			Name = "UI";
			pnWiz0x0033.ResumeLayout(false);
			pnWiz0x0033.PerformLayout();
			tlpnGetSetValue.ResumeLayout(false);
			tlpnGetSetValue.PerformLayout();
			flowLayoutPanel1.ResumeLayout(false);
			flowLayoutPanel1.PerformLayout();
			flpnOperation.ResumeLayout(false);
			flpnOperation.PerformLayout();
			gbTokenTypes.ResumeLayout(false);
			gbTokenTypes.PerformLayout();
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			gbInventoryType.ResumeLayout(false);
			gbInventoryType.PerformLayout();
			flpnDoid0.ResumeLayout(false);
			flpnDoid0.PerformLayout();
			pnDoid0.ResumeLayout(false);
			pnDoid0.PerformLayout();
			flpnInventoryType.ResumeLayout(false);
			flpnInventoryType.PerformLayout();
			pnDoid1.ResumeLayout(false);
			pnDoid1.PerformLayout();
			pnDoid3.ResumeLayout(false);
			pnDoid3.PerformLayout();
			pnDoid2.ResumeLayout(false);
			pnDoid2.PerformLayout();
			flpnGUID.ResumeLayout(false);
			flpnGUID.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion

		private void rb1_CheckedChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			internalchg = true;

			if (rb1Counted.Checked)
			{
				doCounted();
			}
			else
			{
				doSingular();
			}

			internalchg = false;
		}

		private void cbOperation_SelectedIndexChanged(object sender, EventArgs e)
		{
			operation = (byte)cbOperation.SelectedIndex;
			rb1_CheckedChanged(sender, e);
		}

		private void tbGUID_TextChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

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
			byte[] o =
			{
				inst.Operands[0x05],
				inst.Operands[0x06],
				inst.Operands[0x07],
				inst.Reserved1[0],
			};
			setGUID(o, 0);
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

			UInt32 i = Convert.ToUInt32(((TextBox)sender).Text, 16);
			o5678[0] = (byte)(i & 0xff);
			o5678[1] = (byte)((i >> 8) & 0xff);
			o5678[2] = (byte)((i >> 16) & 0xff);
			o5678[3] = (byte)((i >> 24) & 0xff);
			refreshDoid1();
			doFromInventory(false);

			internalchg = origstate;
		}

		private void ckbTT_CheckedChanged(object sender, EventArgs e)
		{
			List<CheckBox> tt = new List<CheckBox>(
				new CheckBox[] { ckbTTVisible, ckbTTMemory, ckbTTShopping }
			);
			List<CheckBox> tti = new List<CheckBox>(
				new CheckBox[] { ckbTTInvVisible, ckbTTInvMemory, ckbTTInvShopping }
			);
			int i = tt.IndexOf((CheckBox)sender);
			tti[i].Enabled = tt[i].Checked;
			ckbTTAll.Checked =
				!ckbTTVisible.Checked && !ckbTTMemory.Checked && !ckbTTShopping.Checked;
		}

		private void cbTargetInv_SelectedIndexChanged(object sender, EventArgs e)
		{
			pnDoid0.Enabled = (
				cbTargetInv.SelectedIndex >= 1 && cbTargetInv.SelectedIndex <= 3
			);
			lbDoid0.Text = pnDoid0.Enabled ? cbTargetInv.SelectedItem.ToString() : "";
		}

		private void cbInventory_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool origstate = internalchg;
			internalchg = true;

			if (cbInventory.SelectedIndex >= 0 && cbInventory.SelectedIndex <= 7)
			{
				o5678[1] = (byte)((o5678[1] & 0xf8) + cbInventory.SelectedIndex);
			}

			refreshDoid1();

			pnDoid3.Enabled = (
				cbInventory.SelectedIndex >= 1 && cbInventory.SelectedIndex <= 3
			);
			lbDoid3.Text = pnDoid3.Enabled ? cbInventory.SelectedItem.ToString() : "";

			internalchg = origstate;
		}
	}
}

namespace pjse.BhavOperandWizards
{
	public class BhavOperandWiz0x0033 : ABhavOperandWiz
	{
		public BhavOperandWiz0x0033(Instruction i)
			: base(i)
		{
			myForm = new Wiz0x0033.UI();
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
