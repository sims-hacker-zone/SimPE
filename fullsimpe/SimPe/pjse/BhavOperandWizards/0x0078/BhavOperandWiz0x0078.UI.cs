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
 * 0x0078 - Ray Trace
 * 
 * See https://modthesims.info/wiki.php?title=0x0078
 */
namespace whse.PrimitiveWizards.Wiz0x0078
{
    public partial class UI : UserControl, pjse.iBhavOperandWizForm
    {
        // private Instruction inst;

        private DataOwnerControl doObject, doObjectSlot, doTarget, doTargetSlot;

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

            internalchg = true;

            doObject = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner1, comboDataPicker1, textDataValue1, checkDecimal, checkAttrPicker, toolTip, operands[OperandConstants.Operand1], operands[OperandConstants.Operand2], operands[OperandConstants.Operand3]);
            WizardHelpers.ComboSelectIndex(comboObjectSlot, operands[OperandConstants.Operand4]);
            doObjectSlot = WizardHelpers.CreateDataControl(inst, textObjectSlot, checkDecimal, operands[OperandConstants.Operand5]);

            doTarget = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner2, comboDataPicker2, textDataValue2, checkDecimal, checkAttrPicker, toolTip, reserved1[OperandConstants.Operand8], reserved1[OperandConstants.Operand9], reserved1[OperandConstants.Operand10]);
            WizardHelpers.ComboSelectIndex(comboTargetSlot, reserved1[OperandConstants.Operand11]);
            doTargetSlot = WizardHelpers.CreateDataControl(inst, textTagetSlot, checkDecimal, reserved1[OperandConstants.Operand12]);

            checkWindows.Checked = (reserved1[OperandConstants.Operand15] != 0);

            internalchg = false;

            UpdatePanelState();
        }

        public Instruction Write(Instruction inst)
        {
            if (inst != null)
            {
                wrappedByteArray operands = inst.Operands;
                wrappedByteArray reserved1 = inst.Reserved1;

                operands[OperandConstants.Operand1] = doObject.DataOwner;
                operands[OperandConstants.Operand2] = (byte)doObject.Value;
                operands[OperandConstants.Operand3] = (byte)(doObject.Value >> 8);

                operands[OperandConstants.Operand4] = (byte)comboObjectSlot.SelectedIndex;
                operands[OperandConstants.Operand5] = (byte)doObjectSlot.Value;

                reserved1[OperandConstants.Operand8] = doTarget.DataOwner;
                reserved1[OperandConstants.Operand9] = (byte)doTarget.Value;
                reserved1[OperandConstants.Operand10] = (byte)(doTarget.Value >> 8);

                reserved1[OperandConstants.Operand11] = (byte)comboTargetSlot.SelectedIndex;
                reserved1[OperandConstants.Operand12] = (byte)doTargetSlot.Value;

                reserved1[OperandConstants.Operand15] = (byte)(checkWindows.Checked ? 1 : 0);
            }

            return inst;
        }

        private void UpdatePanelState()
        {
            panelObjectSlot.Visible = (comboObjectSlot.SelectedIndex != 0);
            panelTargetSlot.Visible = (comboTargetSlot.SelectedIndex != 0);
        }

        private void OnControlChanged(object sender, EventArgs e)
        {
            if (internalchg) return;

            UpdatePanelState();
        }
    }
}
