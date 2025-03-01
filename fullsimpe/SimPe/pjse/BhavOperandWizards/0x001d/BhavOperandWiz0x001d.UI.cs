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
 * 0x001D - Set Motive Change
 * 
 * See https://modthesims.info/wiki.php?title=0x001D
 */
namespace whse.PrimitiveWizards.Wiz0x001d
{
    public partial class UI : UserControl, pjse.iBhavOperandWizForm
    {
        // private Instruction inst;

        private DataOwnerControl doMotiveDelta, doMotiveMax;

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
            // wrappedByteArray reserved1 = inst.Reserved1;

            Boolset boolset3 = new Boolset(operands[OperandConstants.Operand3]);

            internalchg = true;

            doMotiveDelta = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner1, comboDataPicker1, textDataValue1, checkDecimal, checkAttrPicker, toolTip, operands[OperandConstants.Operand0], operands[OperandConstants.Operand4], operands[OperandConstants.Operand5]);
            doMotiveMax = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner2, comboDataPicker2, textDataValue2, checkDecimal, checkAttrPicker, toolTip, operands[OperandConstants.Operand1], operands[OperandConstants.Operand6], operands[OperandConstants.Operand7]);

            WizardHelpers.ComboSelectIndex(comboMotive, operands[OperandConstants.Operand2]);

            checkClearAll.Checked = boolset3[OperandConstants.Bit1];
            checkAutoClearing.Checked = boolset3[OperandConstants.Bit2];

            internalchg = false;

            UpdatePanelState();
        }

        public Instruction Write(Instruction inst)
        {
            if (inst != null)
            {
                wrappedByteArray operands = inst.Operands;
                // wrappedByteArray reserved1 = inst.Reserved1;

                operands[OperandConstants.Operand0] = doMotiveDelta.DataOwner;
                operands[OperandConstants.Operand4] = (byte)doMotiveDelta.Value;
                operands[OperandConstants.Operand5] = (byte)(doMotiveDelta.Value >> 8);

                operands[OperandConstants.Operand1] = doMotiveMax.DataOwner;
                operands[OperandConstants.Operand6] = (byte)doMotiveMax.Value;
                operands[OperandConstants.Operand7] = (byte)(doMotiveMax.Value >> 8);

                operands[OperandConstants.Operand2] = (byte)comboMotive.SelectedIndex;

                Boolset boolset3 = new Boolset(operands[OperandConstants.Operand3]);
                boolset3[OperandConstants.Bit1] = checkClearAll.Checked;
                boolset3[OperandConstants.Bit2] = checkAutoClearing.Checked;
                operands[OperandConstants.Operand3] = boolset3;
            }

            return inst;
        }

        private void UpdatePanelState()
        {
            panelMotive.Visible = !checkClearAll.Checked;
        }

        private void OnControlChanged(object sender, EventArgs e)
        {
            if (internalchg) return;

            UpdatePanelState();
        }
    }
}
