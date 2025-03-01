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
 * 0x0023 - Camera Control
 * 
 * See https://www.picknmixmods.com/Sims2/Notes/Primitives/0x0023.html
 */
namespace whse.PrimitiveWizards.Wiz0x0023
{
    public partial class UI : UserControl, pjse.iBhavOperandWizForm
    {
        // private Instruction inst;

        DataOwnerControl doTimeout;

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

            WizardHelpers.ComboSelectIndex(comboTimeout, (boolset4[OperandConstants.Bit6] ? 1 : 0));
            doTimeout = WizardHelpers.CreateDataControl(inst, textTimeout, checkDecimal, operands[OperandConstants.Operand0], operands[OperandConstants.Operand1]);

            WizardHelpers.ComboSelectIndex(comboZoom, operands[OperandConstants.Operand3] - 1);

            checkVisible.Checked = boolset4[OperandConstants.Bit1];
            checkCentre.Checked = boolset4[OperandConstants.Bit4];
            checkSlowDown.Checked = !boolset4[OperandConstants.Bit7];

            internalchg = false;

            UpdatePanelState();
        }

        public Instruction Write(Instruction inst)
        {
            if (inst != null)
            {
                wrappedByteArray operands = inst.Operands;
                // wrappedByteArray reserved1 = inst.Reserved1;

                operands[OperandConstants.Operand0] = (byte)doTimeout.Value;
                operands[OperandConstants.Operand1] = (byte)(doTimeout.Value >> 8);

                operands[OperandConstants.Operand3] = (byte)(comboZoom.SelectedIndex + 1);

                Boolset boolset4 = (Boolset)operands[OperandConstants.Operand4];
                boolset4[OperandConstants.Bit1] = checkVisible.Checked;
                boolset4[OperandConstants.Bit4] = checkCentre.Checked;
                boolset4[OperandConstants.Bit6] = (comboTimeout.SelectedIndex == 1);
                boolset4[OperandConstants.Bit7] = !checkSlowDown.Checked;
                operands[OperandConstants.Operand4] = (byte)boolset4;
            }

            return inst;
        }

        private void UpdatePanelState()
        {
            textTimeout.Visible = (comboTimeout.SelectedIndex == 0);
        }

        private void OnControlChanged(object sender, EventArgs e)
        {
            if (internalchg) return;

            UpdatePanelState();
        }
    }
}
