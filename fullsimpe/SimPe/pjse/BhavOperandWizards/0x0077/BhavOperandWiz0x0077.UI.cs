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
 * 0x0077 - Message
 * 
 * See http://www.picknmixmods.com/Sims2/Notes/Primitives/0x0077.html
 */
namespace whse.PrimitiveWizards.Wiz0x0077
{
    public partial class UI : UserControl, pjse.iBhavOperandWizForm
    {
        // private Instruction inst;

        private DataOwnerControl doMessage, doVariable, doPriority, doUserData1, doUserData2;

        private bool internalchg;

        public UI()
        {
            InitializeComponent();
        }

        public Panel WizPanel => this.panelMain;

        public void Execute(Instruction inst)
        {
            // this.inst = inst;

            wrappedByteArray operands = inst.Operands;
            wrappedByteArray reserved1 = inst.Reserved1;

            Boolset boolset4 = new Boolset(operands[OperandConstants.Operand4]);

            internalchg = true;

            WizardHelpers.ComboSelectIndex(comboLocation, operands[OperandConstants.Operand0]);

            doMessage = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner1, comboDataPicker1, textDataValue1, checkDecimal, checkAttrPicker, toolTip, reserved1[OperandConstants.Operand15], operands[OperandConstants.Operand1], operands[OperandConstants.Operand2]);

            WizardHelpers.ComboSelectIndex(comboTarget, operands[OperandConstants.Operand3]);

            checkLocation.Checked = boolset4[OperandConstants.Bit1];
            checkTarget.Checked = boolset4[OperandConstants.Bit3];

            doVariable = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner2, comboDataPicker2, textDataValue2, checkDecimal, checkAttrPicker, toolTip, operands[OperandConstants.Operand5], operands[OperandConstants.Operand6], operands[OperandConstants.Operand7]);

            doPriority = WizardHelpers.CreateDataControl(inst, textPriority, checkDecimal, reserved1[OperandConstants.Operand8]);

            doUserData1 = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner3, comboDataPicker3, textDataValue3, checkDecimal, checkAttrPicker, toolTip, reserved1[OperandConstants.Operand9], reserved1[OperandConstants.Operand10], reserved1[OperandConstants.Operand11]);
            doUserData2 = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner4, comboDataPicker4, textDataValue4, checkDecimal, checkAttrPicker, toolTip, reserved1[OperandConstants.Operand12], reserved1[OperandConstants.Operand13], reserved1[OperandConstants.Operand14]);

            internalchg = false;

            UpdatePanelState();
        }

        public Instruction Write(Instruction inst)
        {
            if (inst != null)
            {
                wrappedByteArray operands = inst.Operands;
                wrappedByteArray reserved1 = inst.Reserved1;

                operands[OperandConstants.Operand0] = (byte)(checkLocation.Checked ? 0 : comboLocation.SelectedIndex);

                reserved1[OperandConstants.Operand15] = doMessage.DataOwner;
                operands[OperandConstants.Operand1] = (byte)doMessage.Value;
                operands[OperandConstants.Operand2] = (byte)(doMessage.Value >> 8);

                operands[OperandConstants.Operand3] = (byte)comboTarget.SelectedIndex;

                Boolset boolset4 = new Boolset(operands[OperandConstants.Operand4]);
                boolset4[OperandConstants.Bit1] = checkLocation.Checked;
                boolset4[OperandConstants.Bit3] = checkTarget.Checked;
                operands[OperandConstants.Operand4] = boolset4;

                operands[OperandConstants.Operand5] = doVariable.DataOwner;
                operands[OperandConstants.Operand6] = (byte)doVariable.Value;
                operands[OperandConstants.Operand7] = (byte)(doVariable.Value >> 8);

                reserved1[OperandConstants.Operand8] = (byte)doPriority.Value;

                reserved1[OperandConstants.Operand9] = doUserData1.DataOwner;
                reserved1[OperandConstants.Operand10] = (byte)doUserData1.Value;
                reserved1[OperandConstants.Operand11] = (byte)(doUserData1.Value >> 8);

                reserved1[OperandConstants.Operand12] = doUserData2.DataOwner;
                reserved1[OperandConstants.Operand13] = (byte)doUserData2.Value;
                reserved1[OperandConstants.Operand14] = (byte)(doUserData2.Value >> 8);
            }

            return inst;
        }

        private void UpdatePanelState()
        {
            panelVariable.Visible = checkLocation.Checked || checkTarget.Checked;

            comboLocation.Visible = !checkLocation.Checked;

            comboTarget.Visible = !checkTarget.Checked;
        }

        private void OnLocationChecked(object sender, EventArgs e)
        {
            if (this.internalchg) return;

            bool internalchg = this.internalchg;
            this.internalchg = true;

            if (checkLocation.Checked) checkTarget.Checked = false;

            this.internalchg = internalchg;

            UpdatePanelState();
        }

        private void OnTargetChecked(object sender, EventArgs e)
        {
            if (this.internalchg) return;

            bool internalchg = this.internalchg;
            this.internalchg = true;

            if (checkTarget.Checked) checkLocation.Checked = false;

            this.internalchg = internalchg;

            UpdatePanelState();
        }
    }
}
