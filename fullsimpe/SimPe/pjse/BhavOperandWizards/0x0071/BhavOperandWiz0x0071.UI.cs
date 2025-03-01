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
 * 0x0071 - Snap Into
 * 
 * See https://modthesims.info/wiki.php?title=0x0071
 */
namespace whse.PrimitiveWizards.Wiz0x0071
{
    public partial class UI : UserControl, pjse.iBhavOperandWizForm
    {
        // private Instruction inst;

        private DataOwnerControl doObject, doTarget, doSlot;

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

            Boolset boolset9 = new Boolset(reserved1[OperandConstants.Operand9]);

            internalchg = true;

            doObject = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner1, comboDataPicker1, textDataValue1, checkDecimal, checkAttrPicker, toolTip, operands[OperandConstants.Operand0], operands[OperandConstants.Operand1], operands[OperandConstants.Operand2]);
            doTarget = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner2, comboDataPicker2, textDataValue2, checkDecimal, checkAttrPicker, toolTip, operands[OperandConstants.Operand3], operands[OperandConstants.Operand4], operands[OperandConstants.Operand5]);

            doSlot = WizardHelpers.CreateDataControl(inst, textSlot, checkDecimal, operands[OperandConstants.Operand6]);

            comboSlot.SelectedIndex = (boolset9[OperandConstants.Bit1] ? 1 : 0);
            checkTestOnly.Checked = boolset9[OperandConstants.Bit2];
            checkRootBones.Checked = boolset9[OperandConstants.Bit3];

            internalchg = false;

            UpdatePanelState();
        }

        public Instruction Write(Instruction inst)
        {
            if (inst != null)
            {
                wrappedByteArray operands = inst.Operands;
                wrappedByteArray reserved1 = inst.Reserved1;

                Boolset boolset9 = new Boolset(reserved1[OperandConstants.Operand9]);

                operands[OperandConstants.Operand0] = doObject.DataOwner;
                operands[OperandConstants.Operand1] = (byte)doObject.Value;
                operands[OperandConstants.Operand2] = (byte)(doObject.Value >> 8);

                operands[OperandConstants.Operand3] = doTarget.DataOwner;
                operands[OperandConstants.Operand4] = (byte)doTarget.Value;
                operands[OperandConstants.Operand5] = (byte)(doTarget.Value >> 8);

                operands[OperandConstants.Operand6] = (byte)doSlot.Value;

                boolset9[OperandConstants.Bit1] = (comboSlot.SelectedIndex == 1);
                boolset9[OperandConstants.Bit2] = checkTestOnly.Checked;
                boolset9[OperandConstants.Bit3] = checkRootBones.Checked;
                reserved1[OperandConstants.Operand9] = boolset9;
            }

            return inst;
        }

        private void UpdatePanelState()
        {
            panelSlot.Visible = (comboSlot.SelectedIndex == 0);
        }

        private void OnControlChanged(object sender, EventArgs e)
        {
            if (internalchg) return;

            UpdatePanelState();
        }
    }
}
