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
 * 0x000C - Direction
 * 
 * See https://modthesims.info/wiki.php?title=0x000C
 */
namespace whse.PrimitiveWizards.Wiz0x000c
{
    public partial class UI : UserControl, pjse.iBhavOperandWizForm
    {
        // private Instruction inst;

        private DataOwnerControl doVariable, doInto;

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
            Boolset boolset8 = new Boolset(reserved1[OperandConstants.Operand8]);

            internalchg = true;

            doInto = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner2, comboDataPicker2, textDataValue2, checkDecimal, checkAttrPicker, toolTip, operands[OperandConstants.Operand2], operands[OperandConstants.Operand0], operands[OperandConstants.Operand1]);

            comboFrom.SelectedIndex = (boolset4[OperandConstants.Bit1] ? 1 : 0);

            doVariable = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner1, comboDataPicker1, textDataValue1, checkDecimal, checkAttrPicker, toolTip, operands[OperandConstants.Operand5], operands[OperandConstants.Operand6], operands[OperandConstants.Operand7]);

            // IDEA - 0x000C, Op8, Bit2 - correct SimPe for this bit?
            checkDegrees.Checked = boolset8[OperandConstants.Bit2]; // See comment about this bit in the operands table

            internalchg = false;

            UpdatePanelState();
        }

        public Instruction Write(Instruction inst)
        {
            if (inst != null)
            {
                wrappedByteArray operands = inst.Operands;
                wrappedByteArray reserved1 = inst.Reserved1;

                operands[OperandConstants.Operand2] = doVariable.DataOwner;
                operands[OperandConstants.Operand0] = (byte)doVariable.Value;
                operands[OperandConstants.Operand1] = (byte)(doVariable.Value >> 8);

                Boolset boolset4 = new Boolset(operands[OperandConstants.Operand4]);
                boolset4[OperandConstants.Bit1] = (comboFrom.SelectedIndex == 1);
                operands[OperandConstants.Operand4] = boolset4;

                operands[OperandConstants.Operand5] = doInto.DataOwner;
                operands[OperandConstants.Operand6] = (byte)doInto.Value;
                operands[OperandConstants.Operand7] = (byte)(doInto.Value >> 8);

                Boolset boolset8 = new Boolset(reserved1[OperandConstants.Operand8]);
                boolset8[OperandConstants.Bit2] = checkDegrees.Checked;
                reserved1[OperandConstants.Operand8] = boolset8;
            }

            return inst;
        }

        private void UpdatePanelState()
        {
            panelVariable.Visible = (comboFrom.SelectedIndex == 1);
        }

        private void OnControlChanged(object sender, EventArgs e)
        {
            if (internalchg) return;

            UpdatePanelState();
        }
    }
}
