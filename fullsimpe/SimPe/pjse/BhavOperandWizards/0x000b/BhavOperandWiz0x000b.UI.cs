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
 * 0x000B - Distance
 * 
 * See https://modthesims.info/wiki.php?title=0x000B
 */
namespace whse.PrimitiveWizards.Wiz0x000b
{
    public partial class UI : UserControl, pjse.iBhavOperandWizForm
    {
        // private Instruction inst;

        private DataOwnerControl doTarget, doTemp;

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

            Boolset boolset2 = new Boolset(operands[OperandConstants.Operand2]);
            Boolset boolset6 = new Boolset(operands[OperandConstants.Operand6]);

            internalchg = true;

            doTemp = WizardHelpers.CreateDataControl(inst, textIntoTemp, checkDecimal, operands[OperandConstants.Operand0], operands[OperandConstants.Operand1]);

            comboTarget.SelectedIndex = (boolset2[OperandConstants.Bit1] ? 1 : 0);

            doTarget = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner1, comboDataPicker1, textDataValue1, checkDecimal, checkAttrPicker, toolTip, operands[OperandConstants.Operand3], operands[OperandConstants.Operand4], operands[OperandConstants.Operand5]);

            checkIn100ths.Checked = boolset6[OperandConstants.Bit2];

            internalchg = false;

            UpdatePanelState();
        }

        public Instruction Write(Instruction inst)
        {
            if (inst != null)
            {
                wrappedByteArray operands = inst.Operands;
                // wrappedByteArray reserved1 = inst.Reserved1;

                operands[OperandConstants.Operand0] = (byte)doTemp.Value;
                operands[OperandConstants.Operand1] = (byte)(doTemp.Value >> 8);

                Boolset boolset2 = new Boolset(operands[OperandConstants.Operand2]);
                boolset2[OperandConstants.Bit1] = (comboTarget.SelectedIndex == 1);
                operands[OperandConstants.Operand2] = boolset2;

                operands[OperandConstants.Operand3] = doTarget.DataOwner;
                operands[OperandConstants.Operand4] = (byte)doTarget.Value;
                operands[OperandConstants.Operand5] = (byte)(doTarget.Value >> 8);

                Boolset boolset6 = new Boolset(operands[OperandConstants.Operand6]);
                boolset6[OperandConstants.Bit2] = checkIn100ths.Checked;
                operands[OperandConstants.Operand6] = boolset6;
            }

            return inst;
        }

        private void UpdatePanelState()
        {
            panelDataOwner1.Visible = (comboTarget.SelectedIndex == 1);
        }

        private void OnControlChanged(object sender, EventArgs e)
        {
            if (internalchg) return;

            UpdatePanelState();
        }
    }
}
