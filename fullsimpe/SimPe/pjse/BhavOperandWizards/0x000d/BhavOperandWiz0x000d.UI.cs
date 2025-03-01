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
using SimPe.PackedFiles.Wrapper;
using System;
using System.Windows.Forms;

/*
 * 0x000D - Push Interaction
 * 
 * See https://modthesims.info/wiki.php?title=0x000D
 */
namespace whse.PrimitiveWizards.Wiz0x000d
{
    public partial class UI : UserControl, pjse.iBhavOperandWizForm
    {
        // private Instruction inst;

        private DataOwnerControl doObjectParam, doObjectLocal, doIntNumber, doIntVariable, doIconLocal, doIconIndex, doLinking, doReturning;

        private bool internalchg;

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

            Boolset boolset3 = new Boolset(operands[OperandConstants.Operand3]);
            Boolset boolset14 = new Boolset(reserved1[OperandConstants.Operand14]);

            internalchg = true;

            comboObjectType.SelectedIndex = (boolset3[OperandConstants.Bit2] ? 1 : 0);
            doObjectParam = WizardHelpers.CreateDataOwnerControl(inst, null, comboObjectParam, textObjectParam, checkDecimal, checkAttrPicker, toolTip, DataOwner.Parameter, operands[OperandConstants.Operand1]);
            doObjectLocal = WizardHelpers.CreateDataOwnerControl(inst, null, comboObjectLocal, textObjectLocal, checkDecimal, checkAttrPicker, toolTip, DataOwner.Local, operands[OperandConstants.Operand1]);

            comboInteractNumber.SelectedIndex = (boolset14[OperandConstants.Bit2] ? 2 : (boolset3[OperandConstants.Bit5] ? 1 : 0));
            doIntNumber = WizardHelpers.CreateDataControl(inst, textInteractNumber, checkDecimal, operands[OperandConstants.Operand0]);
            doIntVariable = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner1, comboDataPicker1, textDataValue1, checkDecimal, checkAttrPicker, toolTip, operands[OperandConstants.Operand5], operands[OperandConstants.Operand6], operands[OperandConstants.Operand7]);

            WizardHelpers.ComboSelectIndex(comboPriority, (operands[OperandConstants.Operand2] & 0x03));

            comboIconType.SelectedIndex = (boolset3[OperandConstants.Bit1] ? 1 : (boolset14[OperandConstants.Bit3] ? 2 : 0));
            doIconLocal = WizardHelpers.CreateDataOwnerControl(inst, null, comboIconObject, textIconObject, checkDecimal, checkAttrPicker, toolTip, DataOwner.Local, operands[OperandConstants.Operand4]);

            comboIconIndexType.SelectedIndex = (boolset14[OperandConstants.Bit4] ? 1 : 0);
            doIconIndex = WizardHelpers.CreateDataControl(inst, textIconIndex, checkDecimal, reserved1[OperandConstants.Operand15]);

            checkCallerParams.Checked = boolset14[OperandConstants.Bit1];
            checkContinuation.Checked = boolset3[OperandConstants.Bit3];
            checkUseName.Checked = boolset3[OperandConstants.Bit4];
            checkRunCheckTree.Checked = boolset3[OperandConstants.Bit6];

            checkLinking.Checked = boolset3[OperandConstants.Bit7];
            doLinking = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner2, comboDataPicker2, textDataValue2, checkDecimal, checkAttrPicker, toolTip, reserved1[OperandConstants.Operand8], reserved1[OperandConstants.Operand9], reserved1[OperandConstants.Operand10]);

            checkReturning.Checked = boolset3[OperandConstants.Bit8];
            doReturning = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner3, comboDataPicker3, textDataValue3, checkDecimal, checkAttrPicker, toolTip, reserved1[OperandConstants.Operand11], reserved1[OperandConstants.Operand12], reserved1[OperandConstants.Operand13]);

            internalchg = false;

            UpdatePanelState();
        }

        public Instruction Write(Instruction inst)
        {
            if (inst != null)
            {
                wrappedByteArray operands = inst.Operands;
                wrappedByteArray reserved1 = inst.Reserved1;

                operands[OperandConstants.Operand0] = (byte)doIntNumber.Value;

                operands[OperandConstants.Operand1] = (byte)(comboObjectType.SelectedIndex == 0 ? doObjectParam.Value : doObjectLocal.Value);

                operands[OperandConstants.Operand2] = (byte)comboPriority.SelectedIndex;

                Boolset boolset3 = new Boolset(operands[OperandConstants.Operand3]);
                boolset3[OperandConstants.Bit1] = (comboIconType.SelectedIndex == 1);
                boolset3[OperandConstants.Bit2] = (comboObjectType.SelectedIndex == 1);
                boolset3[OperandConstants.Bit3] = checkContinuation.Checked;
                boolset3[OperandConstants.Bit4] = checkUseName.Checked;
                boolset3[OperandConstants.Bit5] = (comboInteractNumber.SelectedIndex == 1);
                boolset3[OperandConstants.Bit6] = checkRunCheckTree.Checked;
                boolset3[OperandConstants.Bit7] = checkLinking.Checked;
                boolset3[OperandConstants.Bit8] = checkReturning.Checked;
                operands[OperandConstants.Operand3] = boolset3;

                operands[OperandConstants.Operand4] = (byte)doIconLocal.Value;

                operands[OperandConstants.Operand5] = doIntVariable.DataOwner;
                operands[OperandConstants.Operand6] = (byte)doIntVariable.Value;
                operands[OperandConstants.Operand7] = (byte)(doIntVariable.Value >> 8);

                reserved1[OperandConstants.Operand8] = doLinking.DataOwner;
                reserved1[OperandConstants.Operand9] = (byte)doLinking.Value;
                reserved1[OperandConstants.Operand10] = (byte)(doLinking.Value >> 8);

                reserved1[OperandConstants.Operand11] = doReturning.DataOwner;
                reserved1[OperandConstants.Operand12] = (byte)doReturning.Value;
                reserved1[OperandConstants.Operand13] = (byte)(doReturning.Value >> 8);

                Boolset boolset14 = new Boolset(reserved1[OperandConstants.Operand14]);
                boolset14[OperandConstants.Bit1] = checkCallerParams.Checked;
                boolset14[OperandConstants.Bit2] = (comboInteractNumber.SelectedIndex == 2);
                boolset14[OperandConstants.Bit3] = (comboIconType.SelectedIndex == 2);
                boolset14[OperandConstants.Bit4] = (comboIconIndexType.SelectedIndex == 1);
                reserved1[OperandConstants.Operand14] = boolset14;

                reserved1[OperandConstants.Operand15] = (byte)doIconIndex.Value;
            }

            return inst;
        }

        private void UpdatePanelState()
        {
            panelObjectParam.Visible = (comboObjectType.SelectedIndex == 0);
            panelObjectLocal.Visible = (comboObjectType.SelectedIndex == 1);

            panelInteractNumber.Visible = (comboInteractNumber.SelectedIndex == 0);

            panelDataOwner1.Visible = (comboInteractNumber.SelectedIndex == 1);

            panelIconObject.Visible = (comboIconType.SelectedIndex == 1);

            panelIconIndex.Visible = (comboIconIndexType.SelectedIndex == 0);

            panelDataOwner2.Visible = checkLinking.Checked;

            panelDataOwner3.Visible = checkReturning.Checked;
        }

        private void OnControlChanged(object sender, EventArgs e)
        {
            if (internalchg) return;

            UpdatePanelState();
        }

        private void OnObjectTypeControlChanged(object sender, EventArgs e)
        {
            if (internalchg) return;

            internalchg = true;

            if (comboObjectType.SelectedIndex == 0)
            {
                WizardHelpers.SetValue(textObjectParam, (byte)doObjectLocal.Value, checkDecimal);
                WizardHelpers.ComboSelectIndex(comboObjectParam, doObjectLocal.Value);
            }
            else
            {
                WizardHelpers.SetValue(textObjectLocal, (byte)doObjectParam.Value, checkDecimal);
                WizardHelpers.ComboSelectIndex(comboObjectLocal, doObjectParam.Value);
            }

            internalchg = false;

            UpdatePanelState();
        }
    }
}
