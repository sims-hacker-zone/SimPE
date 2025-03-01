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
 * 0x001A - Relationship
 * 
 * See https://modthesims.info/wiki.php?title=0x001A
 */
namespace whse.PrimitiveWizards.Wiz0x001a
{
    public partial class UI : UserControl, pjse.iBhavOperandWizForm
    {
        private Instruction inst;

        private DataOwnerControl doVariable, doFrom, doTo;

#pragma warning disable IDE0052 // Remove unread private members
#pragma warning disable CS0414 // The field 'UI.internalchg' is assigned but its value is never used
        private bool internalchg;
#pragma warning restore CS0414 // The field 'UI.internalchg' is assigned but its value is never used
#pragma warning restore IDE0052 // Remove unread private members

        public UI()
        {
            InitializeComponent();
        }

        public Panel WizPanel => this.panelMain;

        public void Execute(Instruction inst)
        {
            this.inst = inst;

            wrappedByteArray operands = inst.Operands;
            wrappedByteArray reserved1 = inst.Reserved1;

            Boolset boolset1 = new Boolset(operands[OperandConstants.Operand1]);

            internalchg = true;

            // NOTE - This primitive has TWO node versions
            // Common
            WizardHelpers.ComboSelectIndex(comboRelationship, operands[OperandConstants.Operand0]);
            comboAssignment.SelectedIndex = (boolset1[OperandConstants.Bit3] ? 1 : 0);

            if (inst.NodeVersion != 0x01)
            {
                // Node Version 0x00
                WizardHelpers.ComboSelectIndex(comboBetween, (operands[OperandConstants.Operand1] & 0x03));

                Boolset boolset2 = new Boolset(operands[OperandConstants.Operand2]);
                checkFailIfTooSmall.Checked = boolset2[OperandConstants.Bit1];
                checkUseNids.Checked = boolset2[OperandConstants.Bit2];

                doVariable = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner1, comboDataPicker1, textDataValue1, checkDecimal, checkAttrPicker, toolTip, operands[OperandConstants.Operand4], operands[OperandConstants.Operand6], operands[OperandConstants.Operand7]);
            }
            else
            {
                // Node Version 0x01
                checkFailIfTooSmall.Checked = boolset1[OperandConstants.Bit1];
                checkUseNids.Checked = boolset1[OperandConstants.Bit2];
                checkDontCheckSecondObject.Checked = boolset1[OperandConstants.Bit4];

                doFrom = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner2, comboDataPicker2, textDataValue2, checkDecimal, checkAttrPicker, toolTip, operands[OperandConstants.Operand2], operands[OperandConstants.Operand3], operands[OperandConstants.Operand4]);
                doTo = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner3, comboDataPicker3, textDataValue3, checkDecimal, checkAttrPicker, toolTip, operands[OperandConstants.Operand5], operands[OperandConstants.Operand6], operands[OperandConstants.Operand7]);

                doVariable = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner1, comboDataPicker1, textDataValue1, checkDecimal, checkAttrPicker, toolTip, reserved1[OperandConstants.Operand8], reserved1[OperandConstants.Operand9], reserved1[OperandConstants.Operand10]);
            }

            internalchg = false;

            UpdatePanelState();
        }

        public Instruction Write(Instruction inst)
        {
            if (inst != null)
            {
                wrappedByteArray operands = inst.Operands;
                wrappedByteArray reserved1 = inst.Reserved1;

                // NOTE - This primitive has TWO node versions
                // Common
                operands[OperandConstants.Operand0] = (byte)comboRelationship.SelectedIndex;

                if (inst.NodeVersion != 0x01)
                {
                    // Node Version 0x00
                    Boolset boolset1 = new Boolset((uint)((operands[OperandConstants.Operand1] & 0xFC) + (comboBetween.SelectedIndex & 0x03)));
                    boolset1[OperandConstants.Bit3] = (comboAssignment.SelectedIndex == 1);
                    operands[OperandConstants.Operand1] = boolset1;

                    Boolset boolset2 = new Boolset(operands[OperandConstants.Operand2]);
                    boolset2[OperandConstants.Bit1] = checkFailIfTooSmall.Checked;
                    boolset2[OperandConstants.Bit2] = checkUseNids.Checked;
                    operands[OperandConstants.Operand2] = boolset2;

                    operands[OperandConstants.Operand4] = doVariable.DataOwner;
                    operands[OperandConstants.Operand6] = (byte)doVariable.Value;
                    operands[OperandConstants.Operand7] = (byte)(doVariable.Value >> 8);
                }
                else
                {
                    // Node Version 0x01
                    Boolset boolset1 = new Boolset(operands[OperandConstants.Operand1]);
                    boolset1[OperandConstants.Bit1] = checkFailIfTooSmall.Checked;
                    boolset1[OperandConstants.Bit2] = checkUseNids.Checked;
                    boolset1[OperandConstants.Bit3] = (comboAssignment.SelectedIndex == 1);
                    boolset1[OperandConstants.Bit4] = checkDontCheckSecondObject.Checked;
                    operands[OperandConstants.Operand1] = boolset1;

                    operands[OperandConstants.Operand2] = doFrom.DataOwner;
                    operands[OperandConstants.Operand3] = (byte)doFrom.Value;
                    operands[OperandConstants.Operand4] = (byte)(doFrom.Value >> 8);

                    operands[OperandConstants.Operand5] = doTo.DataOwner;
                    operands[OperandConstants.Operand6] = (byte)doTo.Value;
                    operands[OperandConstants.Operand7] = (byte)(doTo.Value >> 8);

                    reserved1[OperandConstants.Operand8] = doVariable.DataOwner;
                    reserved1[OperandConstants.Operand9] = (byte)doVariable.Value;
                    reserved1[OperandConstants.Operand10] = (byte)(doVariable.Value >> 8);
                }
            }

            return inst;
        }

        private void UpdatePanelState()
        {
            // Node Version 0x00
            lblNodeVersion0.Visible = panelBetween.Visible = (inst.NodeVersion != 0x01);

            // Node Version 0x01
            lblNodeVersion1.Visible = panelFromTo.Visible = (inst.NodeVersion == 0x01);
            lblDontCheckSecondObject.Visible = checkDontCheckSecondObject.Visible = (inst.NodeVersion == 0x01);
        }
    }
}
