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
 * 0x002E - Snap
 * 
 * See https://www.picknmixmods.com/Sims2/Notes/Primitives/0x002E.html
 */
namespace whse.PrimitiveWizards.Wiz0x002e
{
    public partial class UI : UserControl, pjse.iBhavOperandWizForm
    {
        // private Instruction inst;

        DataOwnerControl doSlotNumber;

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

            Boolset boolset4 = (Boolset)operands[OperandConstants.Operand4];

            internalchg = true;

            doSlotNumber = WizardHelpers.CreateDataControl(inst, textSlotNumber, checkDecimal, operands[OperandConstants.Operand0], operands[OperandConstants.Operand1]);

            WizardHelpers.ComboSelectIndex(comboSnapType, pjse.BhavWiz.ToShort(operands[OperandConstants.Operand2], operands[OperandConstants.Operand3]));

            WizardHelpers.ComboSelectIndex(comboSlotNumber, (boolset4[OperandConstants.Bit4] ? 1 : ((pjse.BhavWiz.ToShort(reserved1[OperandConstants.Operand8], reserved1[OperandConstants.Operand9]) == 1) ? 2 : 0)));

            checkMoveSim.Checked = boolset4[OperandConstants.Bit2];
            checkTestOnly.Checked = boolset4[OperandConstants.Bit5];

            internalchg = false;

            UpdatePanelState();
        }

        public Instruction Write(Instruction inst)
        {
            if (inst != null)
            {
                wrappedByteArray operands = inst.Operands;
                wrappedByteArray reserved1 = inst.Reserved1;

                operands[OperandConstants.Operand0] = (byte)doSlotNumber.Value;
                operands[OperandConstants.Operand1] = (byte)(doSlotNumber.Value >> 8);

                operands[OperandConstants.Operand2] = (byte)comboSnapType.SelectedIndex;
                operands[OperandConstants.Operand3] = 0;

                Boolset boolset4 = (Boolset)operands[OperandConstants.Operand4];
                boolset4[OperandConstants.Bit2] = checkMoveSim.Checked;
                boolset4[OperandConstants.Bit4] = (comboSlotNumber.SelectedIndex == 1);
                boolset4[OperandConstants.Bit5] = checkTestOnly.Checked;
                operands[OperandConstants.Operand4] = (byte)boolset4;

                reserved1[OperandConstants.Operand8] = (byte)((comboSlotNumber.SelectedIndex == 2) ? 1 : 0);
                reserved1[OperandConstants.Operand9] = 0;
            }

            return inst;
        }

        private void UpdatePanelState()
        {
            bool slotVisible = (comboSnapType.SelectedIndex == 0 || comboSnapType.SelectedIndex == 3 || comboSnapType.SelectedIndex == 4);

            lblSlotNumber.Visible = comboSlotNumber.Visible = slotVisible;

            textSlotNumber.Visible = slotVisible && (comboSlotNumber.SelectedIndex == 0);
        }

        private void OnControlChanged(object sender, EventArgs e)
        {
            if (internalchg) return;

            UpdatePanelState();
        }
    }
}
