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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using SimPe.PackedFiles.Wrapper;

namespace pjse.BhavOperandWizards.Wiz0x0033
{
	internal class UI : System.Windows.Forms.Form, iBhavOperandWizForm
	{
		#region Form variables

		internal System.Windows.Forms.Panel pnWiz0x0033;
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
				this.tbGUID.Text = "0x" + SimPe.Helper.HexString(guid);
			this.tbObjName.Text =
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
				cbInventory.Enabled = true;
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
				doByGUID();

			if (operation < aCategory.Length && aCategory[operation])
				doTokenType();

			bool doid1Enabled = pnDoid1.Enabled;

			if (operation < aNames[0].Length)
			{
				lbDoid1.Text =
					(pnDoid1.Enabled = (aNames[1][operation] > 0))
						? pjse.Localization.GetString(names[aNames[1][operation]])
						: "";
				lbDoid2.Text =
					(pnDoid2.Enabled = (aNames[2][operation] > 0))
						? pjse.Localization.GetString(names[aNames[2][operation]])
						: "";
				lbDoid3.Text =
					(pnDoid3.Enabled = (aNames[3][operation] > 0))
						? pjse.Localization.GetString(names[aNames[3][operation]])
						: "";
			}

			if (!doid1Enabled && pnDoid1.Enabled)
				refreshDoid1();
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
		public Panel WizPanel
		{
			get
			{
				return this.pnWiz0x0033;
			}
		}

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
				doCounted();
			else
				doSingular();

			cbOperation.SelectedIndex =
				(operation < cbOperation.Items.Count) ? operation : -1;

			internalchg = false;
		}

		void doid1_DataOwnerControlChanged(object sender, EventArgs e)
		{
			if (internalchg)
				return;
			if (doid1.DataOwner >= 0)
				o5678[1] = doid1.DataOwner;
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
						option1 = (byte)(
							(option1 & 0xfc) | (cbTargetInv.SelectedIndex & 0x03)
						);

					option1[2] = rb1Counted.Checked;
					option1[3] = !ckbTTInvVisible.Checked;
					option1[4] = !ckbTTInvMemory.Checked;
				}
				else
				{
					if (cbTargetInv.SelectedIndex >= 0)
						option1 = (byte)(
							(option1 & 0xf8) | (cbTargetInv.SelectedIndex & 0x07)
						);

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
			this.pnWiz0x0033 = new System.Windows.Forms.Panel();
			this.tlpnGetSetValue = new System.Windows.Forms.TableLayoutPanel();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.ckbDecimal = new System.Windows.Forms.CheckBox();
			this.ckbAttrPicker = new System.Windows.Forms.CheckBox();
			this.lbOperation = new System.Windows.Forms.Label();
			this.flpnOperation = new System.Windows.Forms.FlowLayoutPanel();
			this.cbOperation = new System.Windows.Forms.ComboBox();
			this.ckbReversed = new System.Windows.Forms.CheckBox();
			this.gbTokenTypes = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.ckbTTAll = new System.Windows.Forms.CheckBox();
			this.ckbTTInvShopping = new System.Windows.Forms.CheckBox();
			this.ckbTTShopping = new System.Windows.Forms.CheckBox();
			this.ckbTTInvMemory = new System.Windows.Forms.CheckBox();
			this.ckbTTMemory = new System.Windows.Forms.CheckBox();
			this.ckbTTInvVisible = new System.Windows.Forms.CheckBox();
			this.ckbTTVisible = new System.Windows.Forms.CheckBox();
			this.gbInventoryType = new System.Windows.Forms.GroupBox();
			this.flpnDoid0 = new System.Windows.Forms.FlowLayoutPanel();
			this.lbDoid0 = new System.Windows.Forms.Label();
			this.pnDoid0 = new System.Windows.Forms.Panel();
			this.cbPicker0 = new System.Windows.Forms.ComboBox();
			this.tbVal0 = new System.Windows.Forms.TextBox();
			this.cbDataOwner0 = new System.Windows.Forms.ComboBox();
			this.flpnInventoryType = new System.Windows.Forms.FlowLayoutPanel();
			this.rb1Counted = new System.Windows.Forms.RadioButton();
			this.rb1Singular = new System.Windows.Forms.RadioButton();
			this.cbTargetInv = new System.Windows.Forms.ComboBox();
			this.lbDoid1 = new System.Windows.Forms.Label();
			this.pnDoid1 = new System.Windows.Forms.Panel();
			this.cbPicker1 = new System.Windows.Forms.ComboBox();
			this.tbVal1 = new System.Windows.Forms.TextBox();
			this.cbDataOwner1 = new System.Windows.Forms.ComboBox();
			this.pnDoid3 = new System.Windows.Forms.Panel();
			this.cbPicker3 = new System.Windows.Forms.ComboBox();
			this.tbVal3 = new System.Windows.Forms.TextBox();
			this.cbDataOwner3 = new System.Windows.Forms.ComboBox();
			this.pnDoid2 = new System.Windows.Forms.Panel();
			this.cbPicker2 = new System.Windows.Forms.ComboBox();
			this.tbVal2 = new System.Windows.Forms.TextBox();
			this.cbDataOwner2 = new System.Windows.Forms.ComboBox();
			this.lbInventory = new System.Windows.Forms.Label();
			this.lbDoid3 = new System.Windows.Forms.Label();
			this.cbInventory = new System.Windows.Forms.ComboBox();
			this.flpnGUID = new System.Windows.Forms.FlowLayoutPanel();
			this.tbGUID = new System.Windows.Forms.TextBox();
			this.tbObjName = new System.Windows.Forms.TextBox();
			this.lbDoid2 = new System.Windows.Forms.Label();
			this.lbGUID = new System.Windows.Forms.Label();
			this.pnWiz0x0033.SuspendLayout();
			this.tlpnGetSetValue.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.flpnOperation.SuspendLayout();
			this.gbTokenTypes.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.gbInventoryType.SuspendLayout();
			this.flpnDoid0.SuspendLayout();
			this.pnDoid0.SuspendLayout();
			this.flpnInventoryType.SuspendLayout();
			this.pnDoid1.SuspendLayout();
			this.pnDoid3.SuspendLayout();
			this.pnDoid2.SuspendLayout();
			this.flpnGUID.SuspendLayout();
			this.SuspendLayout();
			//
			// pnWiz0x0033
			//
			resources.ApplyResources(this.pnWiz0x0033, "pnWiz0x0033");
			this.pnWiz0x0033.Controls.Add(this.tlpnGetSetValue);
			this.pnWiz0x0033.Name = "pnWiz0x0033";
			//
			// tlpnGetSetValue
			//
			resources.ApplyResources(this.tlpnGetSetValue, "tlpnGetSetValue");
			this.tlpnGetSetValue.Controls.Add(this.flowLayoutPanel1, 1, 7);
			this.tlpnGetSetValue.Controls.Add(this.lbOperation, 0, 0);
			this.tlpnGetSetValue.Controls.Add(this.flpnOperation, 1, 0);
			this.tlpnGetSetValue.Controls.Add(this.gbTokenTypes, 0, 6);
			this.tlpnGetSetValue.Controls.Add(this.gbInventoryType, 1, 6);
			this.tlpnGetSetValue.Controls.Add(this.lbDoid1, 0, 1);
			this.tlpnGetSetValue.Controls.Add(this.pnDoid1, 1, 1);
			this.tlpnGetSetValue.Controls.Add(this.pnDoid3, 1, 5);
			this.tlpnGetSetValue.Controls.Add(this.pnDoid2, 1, 4);
			this.tlpnGetSetValue.Controls.Add(this.lbInventory, 0, 2);
			this.tlpnGetSetValue.Controls.Add(this.lbDoid3, 0, 5);
			this.tlpnGetSetValue.Controls.Add(this.cbInventory, 1, 2);
			this.tlpnGetSetValue.Controls.Add(this.flpnGUID, 1, 3);
			this.tlpnGetSetValue.Controls.Add(this.lbDoid2, 0, 4);
			this.tlpnGetSetValue.Controls.Add(this.lbGUID, 0, 3);
			this.tlpnGetSetValue.Name = "tlpnGetSetValue";
			//
			// flowLayoutPanel1
			//
			resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
			this.flowLayoutPanel1.Controls.Add(this.ckbDecimal);
			this.flowLayoutPanel1.Controls.Add(this.ckbAttrPicker);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			//
			// ckbDecimal
			//
			resources.ApplyResources(this.ckbDecimal, "ckbDecimal");
			this.ckbDecimal.Name = "ckbDecimal";
			//
			// ckbAttrPicker
			//
			resources.ApplyResources(this.ckbAttrPicker, "ckbAttrPicker");
			this.ckbAttrPicker.Name = "ckbAttrPicker";
			//
			// lbOperation
			//
			resources.ApplyResources(this.lbOperation, "lbOperation");
			this.lbOperation.Name = "lbOperation";
			//
			// flpnOperation
			//
			resources.ApplyResources(this.flpnOperation, "flpnOperation");
			this.flpnOperation.Controls.Add(this.cbOperation);
			this.flpnOperation.Controls.Add(this.ckbReversed);
			this.flpnOperation.Name = "flpnOperation";
			//
			// cbOperation
			//
			this.cbOperation.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbOperation.DropDownWidth = 480;
			this.cbOperation.FormattingEnabled = true;
			resources.ApplyResources(this.cbOperation, "cbOperation");
			this.cbOperation.Name = "cbOperation";
			this.cbOperation.SelectedIndexChanged += new System.EventHandler(
				this.cbOperation_SelectedIndexChanged
			);
			//
			// ckbReversed
			//
			resources.ApplyResources(this.ckbReversed, "ckbReversed");
			this.ckbReversed.Name = "ckbReversed";
			this.ckbReversed.UseVisualStyleBackColor = true;
			//
			// gbTokenTypes
			//
			resources.ApplyResources(this.gbTokenTypes, "gbTokenTypes");
			this.gbTokenTypes.Controls.Add(this.tableLayoutPanel1);
			this.gbTokenTypes.Name = "gbTokenTypes";
			this.gbTokenTypes.TabStop = false;
			//
			// tableLayoutPanel1
			//
			resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
			this.tableLayoutPanel1.Controls.Add(this.ckbTTAll, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.ckbTTInvShopping, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.ckbTTShopping, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.ckbTTInvMemory, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.ckbTTMemory, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.ckbTTInvVisible, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.ckbTTVisible, 0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			//
			// ckbTTAll
			//
			resources.ApplyResources(this.ckbTTAll, "ckbTTAll");
			this.ckbTTAll.Checked = true;
			this.ckbTTAll.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ckbTTAll.Name = "ckbTTAll";
			this.ckbTTAll.TabStop = false;
			this.ckbTTAll.UseVisualStyleBackColor = true;
			//
			// ckbTTInvShopping
			//
			resources.ApplyResources(this.ckbTTInvShopping, "ckbTTInvShopping");
			this.ckbTTInvShopping.Name = "ckbTTInvShopping";
			this.ckbTTInvShopping.UseVisualStyleBackColor = true;
			//
			// ckbTTShopping
			//
			resources.ApplyResources(this.ckbTTShopping, "ckbTTShopping");
			this.ckbTTShopping.Name = "ckbTTShopping";
			this.ckbTTShopping.UseVisualStyleBackColor = true;
			this.ckbTTShopping.CheckedChanged += new System.EventHandler(
				this.ckbTT_CheckedChanged
			);
			//
			// ckbTTInvMemory
			//
			resources.ApplyResources(this.ckbTTInvMemory, "ckbTTInvMemory");
			this.ckbTTInvMemory.Name = "ckbTTInvMemory";
			this.ckbTTInvMemory.UseVisualStyleBackColor = true;
			//
			// ckbTTMemory
			//
			resources.ApplyResources(this.ckbTTMemory, "ckbTTMemory");
			this.ckbTTMemory.Name = "ckbTTMemory";
			this.ckbTTMemory.UseVisualStyleBackColor = true;
			this.ckbTTMemory.CheckedChanged += new System.EventHandler(
				this.ckbTT_CheckedChanged
			);
			//
			// ckbTTInvVisible
			//
			resources.ApplyResources(this.ckbTTInvVisible, "ckbTTInvVisible");
			this.ckbTTInvVisible.Name = "ckbTTInvVisible";
			this.ckbTTInvVisible.UseVisualStyleBackColor = true;
			//
			// ckbTTVisible
			//
			resources.ApplyResources(this.ckbTTVisible, "ckbTTVisible");
			this.ckbTTVisible.Name = "ckbTTVisible";
			this.ckbTTVisible.UseVisualStyleBackColor = true;
			this.ckbTTVisible.CheckedChanged += new System.EventHandler(
				this.ckbTT_CheckedChanged
			);
			//
			// gbInventoryType
			//
			resources.ApplyResources(this.gbInventoryType, "gbInventoryType");
			this.gbInventoryType.Controls.Add(this.flpnDoid0);
			this.gbInventoryType.Controls.Add(this.flpnInventoryType);
			this.gbInventoryType.Name = "gbInventoryType";
			this.gbInventoryType.TabStop = false;
			//
			// flpnDoid0
			//
			resources.ApplyResources(this.flpnDoid0, "flpnDoid0");
			this.flpnDoid0.Controls.Add(this.lbDoid0);
			this.flpnDoid0.Controls.Add(this.pnDoid0);
			this.flpnDoid0.Name = "flpnDoid0";
			//
			// lbDoid0
			//
			resources.ApplyResources(this.lbDoid0, "lbDoid0");
			this.lbDoid0.Name = "lbDoid0";
			this.lbDoid0.Tag = "";
			//
			// pnDoid0
			//
			resources.ApplyResources(this.pnDoid0, "pnDoid0");
			this.pnDoid0.Controls.Add(this.cbPicker0);
			this.pnDoid0.Controls.Add(this.tbVal0);
			this.pnDoid0.Controls.Add(this.cbDataOwner0);
			this.pnDoid0.Name = "pnDoid0";
			//
			// cbPicker0
			//
			this.cbPicker0.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbPicker0.DropDownWidth = 384;
			resources.ApplyResources(this.cbPicker0, "cbPicker0");
			this.cbPicker0.Name = "cbPicker0";
			this.cbPicker0.TabStop = false;
			//
			// tbVal0
			//
			resources.ApplyResources(this.tbVal0, "tbVal0");
			this.tbVal0.Name = "tbVal0";
			this.tbVal0.TabStop = false;
			//
			// cbDataOwner0
			//
			this.cbDataOwner0.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbDataOwner0.DropDownWidth = 384;
			resources.ApplyResources(this.cbDataOwner0, "cbDataOwner0");
			this.cbDataOwner0.Name = "cbDataOwner0";
			//
			// flpnInventoryType
			//
			resources.ApplyResources(this.flpnInventoryType, "flpnInventoryType");
			this.flpnInventoryType.Controls.Add(this.rb1Counted);
			this.flpnInventoryType.Controls.Add(this.rb1Singular);
			this.flpnInventoryType.Controls.Add(this.cbTargetInv);
			this.flpnInventoryType.Name = "flpnInventoryType";
			//
			// rb1Counted
			//
			resources.ApplyResources(this.rb1Counted, "rb1Counted");
			this.rb1Counted.Name = "rb1Counted";
			this.rb1Counted.TabStop = true;
			this.rb1Counted.UseVisualStyleBackColor = true;
			this.rb1Counted.CheckedChanged += new System.EventHandler(
				this.rb1_CheckedChanged
			);
			//
			// rb1Singular
			//
			resources.ApplyResources(this.rb1Singular, "rb1Singular");
			this.rb1Singular.Name = "rb1Singular";
			this.rb1Singular.TabStop = true;
			this.rb1Singular.UseVisualStyleBackColor = true;
			this.rb1Singular.CheckedChanged += new System.EventHandler(
				this.rb1_CheckedChanged
			);
			//
			// cbTargetInv
			//
			this.cbTargetInv.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbTargetInv.FormattingEnabled = true;
			resources.ApplyResources(this.cbTargetInv, "cbTargetInv");
			this.cbTargetInv.Name = "cbTargetInv";
			this.cbTargetInv.SelectedIndexChanged += new System.EventHandler(
				this.cbTargetInv_SelectedIndexChanged
			);
			//
			// lbDoid1
			//
			resources.ApplyResources(this.lbDoid1, "lbDoid1");
			this.lbDoid1.Name = "lbDoid1";
			//
			// pnDoid1
			//
			resources.ApplyResources(this.pnDoid1, "pnDoid1");
			this.pnDoid1.Controls.Add(this.cbPicker1);
			this.pnDoid1.Controls.Add(this.tbVal1);
			this.pnDoid1.Controls.Add(this.cbDataOwner1);
			this.pnDoid1.Name = "pnDoid1";
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
			this.cbPicker1.TabStop = false;
			//
			// tbVal1
			//
			resources.ApplyResources(this.tbVal1, "tbVal1");
			this.tbVal1.Name = "tbVal1";
			this.tbVal1.TabStop = false;
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
			// pnDoid3
			//
			resources.ApplyResources(this.pnDoid3, "pnDoid3");
			this.pnDoid3.Controls.Add(this.cbPicker3);
			this.pnDoid3.Controls.Add(this.tbVal3);
			this.pnDoid3.Controls.Add(this.cbDataOwner3);
			this.pnDoid3.Name = "pnDoid3";
			//
			// cbPicker3
			//
			this.cbPicker3.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbPicker3.DropDownWidth = 384;
			resources.ApplyResources(this.cbPicker3, "cbPicker3");
			this.cbPicker3.Name = "cbPicker3";
			this.cbPicker3.TabStop = false;
			//
			// tbVal3
			//
			resources.ApplyResources(this.tbVal3, "tbVal3");
			this.tbVal3.Name = "tbVal3";
			this.tbVal3.TabStop = false;
			//
			// cbDataOwner3
			//
			this.cbDataOwner3.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbDataOwner3.DropDownWidth = 384;
			resources.ApplyResources(this.cbDataOwner3, "cbDataOwner3");
			this.cbDataOwner3.Name = "cbDataOwner3";
			//
			// pnDoid2
			//
			resources.ApplyResources(this.pnDoid2, "pnDoid2");
			this.pnDoid2.Controls.Add(this.cbPicker2);
			this.pnDoid2.Controls.Add(this.tbVal2);
			this.pnDoid2.Controls.Add(this.cbDataOwner2);
			this.pnDoid2.Name = "pnDoid2";
			//
			// cbPicker2
			//
			this.cbPicker2.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbPicker2.DropDownWidth = 384;
			resources.ApplyResources(this.cbPicker2, "cbPicker2");
			this.cbPicker2.Name = "cbPicker2";
			this.cbPicker2.TabStop = false;
			//
			// tbVal2
			//
			resources.ApplyResources(this.tbVal2, "tbVal2");
			this.tbVal2.Name = "tbVal2";
			this.tbVal2.TabStop = false;
			//
			// cbDataOwner2
			//
			this.cbDataOwner2.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbDataOwner2.DropDownWidth = 384;
			resources.ApplyResources(this.cbDataOwner2, "cbDataOwner2");
			this.cbDataOwner2.Name = "cbDataOwner2";
			//
			// lbInventory
			//
			resources.ApplyResources(this.lbInventory, "lbInventory");
			this.lbInventory.Name = "lbInventory";
			this.lbInventory.Tag = "";
			//
			// lbDoid3
			//
			resources.ApplyResources(this.lbDoid3, "lbDoid3");
			this.lbDoid3.Name = "lbDoid3";
			this.lbDoid3.Tag = "";
			//
			// cbInventory
			//
			this.cbInventory.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbInventory.DropDownWidth = 384;
			resources.ApplyResources(this.cbInventory, "cbInventory");
			this.cbInventory.Name = "cbInventory";
			this.cbInventory.SelectedIndexChanged += new System.EventHandler(
				this.cbInventory_SelectedIndexChanged
			);
			//
			// flpnGUID
			//
			resources.ApplyResources(this.flpnGUID, "flpnGUID");
			this.flpnGUID.Controls.Add(this.tbGUID);
			this.flpnGUID.Controls.Add(this.tbObjName);
			this.flpnGUID.Name = "flpnGUID";
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
			// tbObjName
			//
			resources.ApplyResources(this.tbObjName, "tbObjName");
			this.tbObjName.Name = "tbObjName";
			this.tbObjName.ReadOnly = true;
			this.tbObjName.TabStop = false;
			//
			// lbDoid2
			//
			resources.ApplyResources(this.lbDoid2, "lbDoid2");
			this.lbDoid2.Name = "lbDoid2";
			this.lbDoid2.Tag = "";
			//
			// lbGUID
			//
			resources.ApplyResources(this.lbGUID, "lbGUID");
			this.lbGUID.Name = "lbGUID";
			this.lbGUID.Tag = "";
			//
			// UI
			//
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.pnWiz0x0033);
			this.Name = "UI";
			this.pnWiz0x0033.ResumeLayout(false);
			this.pnWiz0x0033.PerformLayout();
			this.tlpnGetSetValue.ResumeLayout(false);
			this.tlpnGetSetValue.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.flpnOperation.ResumeLayout(false);
			this.flpnOperation.PerformLayout();
			this.gbTokenTypes.ResumeLayout(false);
			this.gbTokenTypes.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.gbInventoryType.ResumeLayout(false);
			this.gbInventoryType.PerformLayout();
			this.flpnDoid0.ResumeLayout(false);
			this.flpnDoid0.PerformLayout();
			this.pnDoid0.ResumeLayout(false);
			this.pnDoid0.PerformLayout();
			this.flpnInventoryType.ResumeLayout(false);
			this.flpnInventoryType.PerformLayout();
			this.pnDoid1.ResumeLayout(false);
			this.pnDoid1.PerformLayout();
			this.pnDoid3.ResumeLayout(false);
			this.pnDoid3.PerformLayout();
			this.pnDoid2.ResumeLayout(false);
			this.pnDoid2.PerformLayout();
			this.flpnGUID.ResumeLayout(false);
			this.flpnGUID.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion

		private void rb1_CheckedChanged(object sender, EventArgs e)
		{
			if (internalchg)
				return;
			internalchg = true;

			if (rb1Counted.Checked)
				doCounted();
			else
				doSingular();

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
				return;

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

		private void hex32_Validated(object sender, System.EventArgs e)
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
				o5678[1] = (byte)((o5678[1] & 0xf8) + cbInventory.SelectedIndex);
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
	public class BhavOperandWiz0x0033 : pjse.ABhavOperandWiz
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
				myForm = null;
		}
		#endregion
	}
}
