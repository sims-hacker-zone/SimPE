/*
 * SimpePrimitiveWizards - additional primitive wizards for SimPe
 *                       - see https://www.picknmixmods.com/Sims2/Notes/SimpePrimitiveWizards/SimpePrimitiveWizards.html
 *
 * William Howard - 2023-2023
 *
 * Permission granted to use this code in any way, except to claim it as your own or sell it
 *
 * NOTE: Code should not be "using Simpe;" or "using pjse;" but fully qualifying classes in those high level namespaces
 *
 */

using pjse.BhavOperandWizards;

using SimPe.PackedFiles.Bhav;
using SimPe.PackedFiles.Wrapper;

using System;
using System.Windows.Forms;

/*
 * 0x0010 - Find Location For
 *
 * See https://modthesims.info/wiki.php?title=0x0010
 */
namespace whse.PrimitiveWizards.Wiz0x0010
{
	public partial class UI : UserControl, pjse.iBhavOperandWizForm
	{
		// private Instruction inst;

		private DataOwnerControl doVariable, doRelativeTo, doStartAt, doSlotParam, doSlotLocal, doSlotLiteral;

		private bool internalchg;

		private int lastLocation;

		public UI()
		{
			InitializeComponent();
		}

		public Panel WizPanel => this.panelMain;

		public void Execute(Instruction inst)
		{
			//this.inst = inst;

			wrappedByteArray operands = inst.Operands;
			wrappedByteArray reserved1 = inst.Reserved1;

			Boolset boolset2 = new Boolset(operands[OperandConstants.Operand2]);
			Boolset boolset3 = new Boolset(operands[OperandConstants.Operand3]);

			internalchg = true;

			WizardHelpers.ComboSelectIndex(comboLocation, operands[OperandConstants.Operand0]);
			lastLocation = comboLocation.SelectedIndex;

			doStartAt = WizardHelpers.CreateDataOwnerControl(inst, null, comboDataPicker3, textDataValue3, checkDecimal, checkAttrPicker, toolTip, DataOwner.Local, operands[OperandConstants.Operand1]);

			comboWhat.SelectedIndex = (boolset2[OperandConstants.Bit1] ? 1 : 0);

			checkPreferEmpty.Checked = !boolset2[OperandConstants.Bit2];
			checkUserEditable.Checked = boolset2[OperandConstants.Bit3];
			checkDirection.Checked = boolset2[OperandConstants.Bit4];
			checkOnLevelGround.Checked = boolset2[OperandConstants.Bit5];
			checkWithEmptyBorder.Checked = boolset2[OperandConstants.Bit6];
			checkBeginInFront.Checked = boolset2[OperandConstants.Bit7];
			checkWithLineOfSight.Checked = boolset2[OperandConstants.Bit8];

			checkDirectionN.Checked = boolset3[OperandConstants.Bit1];
			;
			checkDirectionNE.Checked = boolset3[OperandConstants.Bit2];
			;
			checkDirectionE.Checked = boolset3[OperandConstants.Bit3];
			;
			checkDirectionSE.Checked = boolset3[OperandConstants.Bit4];
			;
			checkDirectionS.Checked = boolset3[OperandConstants.Bit5];
			;
			checkDirectionSW.Checked = boolset3[OperandConstants.Bit6];
			;
			checkDirectionW.Checked = boolset3[OperandConstants.Bit7];
			;
			checkDirectionNW.Checked = boolset3[OperandConstants.Bit8];
			;

			doVariable = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner1, comboDataPicker1, textDataValue1, checkDecimal, checkAttrPicker, toolTip, operands[OperandConstants.Operand4], operands[OperandConstants.Operand5], operands[OperandConstants.Operand6]);

			doRelativeTo = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner2, comboDataPicker2, textDataValue2, checkDecimal, checkAttrPicker, toolTip, operands[OperandConstants.Operand7], reserved1[OperandConstants.Operand8], reserved1[OperandConstants.Operand9]);

			doSlotParam = WizardHelpers.CreateDataOwnerControl(inst, null, comboSlotParam, textSlotParam, checkDecimal, checkAttrPicker, toolTip, DataOwner.Parameter, reserved1[OperandConstants.Operand10]);
			doSlotLocal = WizardHelpers.CreateDataOwnerControl(inst, null, comboSlotLocal, textSlotLocal, checkDecimal, checkAttrPicker, toolTip, DataOwner.Local, reserved1[OperandConstants.Operand10]);
			doSlotLiteral = WizardHelpers.CreateDataOwnerControl(inst, null, comboSlotLiteral, textSlotLiteral, checkDecimal, checkAttrPicker, toolTip, DataOwner.Literal, reserved1[OperandConstants.Operand10]);

			internalchg = false;

			UpdatePanelState();
		}

		public Instruction Write(Instruction inst)
		{
			if (inst != null)
			{
				wrappedByteArray operands = inst.Operands;
				wrappedByteArray reserved1 = inst.Reserved1;

				operands[OperandConstants.Operand0] = (byte)comboLocation.SelectedIndex;

				operands[OperandConstants.Operand1] = (byte)doStartAt.Value;

				Boolset boolset2 = new Boolset(operands[OperandConstants.Operand2]);
				boolset2[OperandConstants.Bit1] = (comboWhat.SelectedIndex == 1);
				boolset2[OperandConstants.Bit2] = !checkPreferEmpty.Checked;
				boolset2[OperandConstants.Bit3] = checkUserEditable.Checked;
				boolset2[OperandConstants.Bit4] = checkDirection.Checked;
				boolset2[OperandConstants.Bit5] = checkOnLevelGround.Checked;
				boolset2[OperandConstants.Bit6] = checkWithEmptyBorder.Checked;
				boolset2[OperandConstants.Bit7] = checkBeginInFront.Checked;
				boolset2[OperandConstants.Bit8] = checkWithLineOfSight.Checked;
				operands[OperandConstants.Operand2] = boolset2;

				Boolset boolset3 = new Boolset(operands[OperandConstants.Operand3]);
				boolset3[OperandConstants.Bit1] = checkDirectionN.Checked;
				boolset3[OperandConstants.Bit2] = checkDirectionNE.Checked;
				boolset3[OperandConstants.Bit3] = checkDirectionE.Checked;
				boolset3[OperandConstants.Bit4] = checkDirectionSE.Checked;
				boolset3[OperandConstants.Bit5] = checkDirectionS.Checked;
				boolset3[OperandConstants.Bit6] = checkDirectionSW.Checked;
				boolset3[OperandConstants.Bit7] = checkDirectionW.Checked;
				boolset3[OperandConstants.Bit8] = checkDirectionNW.Checked;
				operands[OperandConstants.Operand3] = boolset3;

				operands[OperandConstants.Operand4] = doVariable.DataOwner;
				operands[OperandConstants.Operand5] = (byte)doVariable.Value;
				operands[OperandConstants.Operand6] = (byte)(doVariable.Value >> 8);

				operands[OperandConstants.Operand7] = doRelativeTo.DataOwner;
				reserved1[OperandConstants.Operand8] = (byte)doRelativeTo.Value;
				reserved1[OperandConstants.Operand9] = (byte)(doRelativeTo.Value >> 8);

				if (lastLocation >= 5)
				{
					reserved1[OperandConstants.Operand10] = (byte)(lastLocation == 5 ? doSlotParam.Value : (lastLocation == 6 ? doSlotLocal.Value : doSlotLiteral.Value));
				}
			}

			return inst;
		}

		private void UpdatePanelState()
		{
			panelVariable.Visible = panelRelativeTo.Visible = (comboWhat.SelectedIndex == 0);

			panelStartAt.Visible = (comboWhat.SelectedIndex == 1);

			panelSlotParam.Visible = (comboLocation.SelectedIndex == 5);
			panelSlotLocal.Visible = (comboLocation.SelectedIndex == 6);
			panelSlotLiteral.Visible = (comboLocation.SelectedIndex == 7 || comboLocation.SelectedIndex == 8);
		}

		private void OnControlChanged(object sender, EventArgs e)
		{
			if (internalchg)
				return;

			UpdatePanelState();
		}

		private void OnLocationChanged(object sender, EventArgs e)
		{
			if (internalchg)
				return;

			internalchg = true;

			if (lastLocation >= 5)
			{
				int value;

				if (lastLocation == 5)
				{
					value = doSlotParam.Value;
				}
				else if (lastLocation == 6)
				{
					value = doSlotLocal.Value;
				}
				else
				{
					value = doSlotLiteral.Value;
				}

				if (comboLocation.SelectedIndex == 5)
				{
					WizardHelpers.SetValue(textSlotParam, (byte)value, checkDecimal);
					WizardHelpers.ComboSelectIndex(comboSlotParam, value);
					;
				}
				else if (comboLocation.SelectedIndex == 6)
				{
					WizardHelpers.SetValue(textSlotLocal, (byte)value, checkDecimal);
					WizardHelpers.ComboSelectIndex(comboSlotLocal, value);
				}
				else if (comboLocation.SelectedIndex == 7 || comboLocation.SelectedIndex == 8)
				{
					WizardHelpers.SetValue(textSlotLiteral, (byte)value, checkDecimal);
					WizardHelpers.ComboSelectIndex(comboSlotLiteral, value);
				}
			}

			internalchg = false;

			if (comboLocation.SelectedIndex >= 5)
				lastLocation = comboLocation.SelectedIndex;

			UpdatePanelState();
		}
	}
}
