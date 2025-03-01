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
 * 0x0011 - Idle For Input
 * 
 * See https://www.picknmixmods.com/Sims2/Notes/Primitives/0x0011.html
 */
namespace whse.PrimitiveWizards.Wiz0x0011
{
    public partial class UI : UserControl, pjse.iBhavOperandWizForm
    {
        // private Instruction inst;

        DataOwnerControl doTickCount;

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

            Boolset boolset4 = (Boolset)operands[OperandConstants.Operand4];

            internalchg = true;

            doTickCount = WizardHelpers.CreateDataControl(inst, textTickCount, checkDecimal, operands[OperandConstants.Operand0]);

            checkAllowPush.Checked = (pjse.BhavWiz.ToShort(operands[OperandConstants.Operand2], operands[OperandConstants.Operand3]) == 0x0000);

            comboAction.SelectedIndex = (boolset4[OperandConstants.Bit1] ? 1 : 0);

            internalchg = false;

            UpdatePanelState();
        }

        public Instruction Write(Instruction inst)
        {
            if (inst != null)
            {
                wrappedByteArray operands = inst.Operands;
                // wrappedByteArray reserved1 = inst.Reserved1;

                operands[OperandConstants.Operand0] = (byte)doTickCount.Value;

                operands[OperandConstants.Operand2] = (byte)(checkAllowPush.Checked ? 0 : 1);
                operands[OperandConstants.Operand3] = 0;

                Boolset boolset4 = (Boolset)operands[OperandConstants.Operand4];
                boolset4[OperandConstants.Bit1] = (comboAction.SelectedIndex == 1);
                operands[OperandConstants.Operand4] = (byte)boolset4;
            }

            return inst;
        }

        private void UpdatePanelState()
        {
            panelTickCount.Visible = lblAllowPush.Visible = checkAllowPush.Visible = (comboAction.SelectedIndex == 0);
        }

        private void OnControlChanged(object sender, EventArgs e)
        {
            if (internalchg) return;

            UpdatePanelState();
        }
    }
}
