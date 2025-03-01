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
 * 0x000E - Find Best Object For Function
 * 
 * See https://modthesims.info/wiki.php?title=0x000E
 */
namespace whse.PrimitiveWizards.Wiz0x000e
{
    public partial class UI : UserControl, pjse.iBhavOperandWizForm
    {
        // private Instruction inst;

        private DataOwnerControl doObject;

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

            internalchg = true;

            WizardHelpers.ComboSelectIndex(comboFunction, operands[OperandConstants.Operand0]);

            comboLocation.SelectedIndex = (boolset2[OperandConstants.Bit1] ? 1 : (boolset2[OperandConstants.Bit2] ? 2 : (boolset2[OperandConstants.Bit3] ? 3 : 0)));
            comboRelativeTo.SelectedIndex = (boolset2[OperandConstants.Bit4] ? 1 : 0);
            checkLineOfSight.Checked = boolset2[OperandConstants.Bit5];
            checkIgnoreLockout.Checked = boolset2[OperandConstants.Bit7];

            doObject = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner1, comboDataPicker1, textDataValue1, checkDecimal, checkAttrPicker, toolTip, operands[OperandConstants.Operand3], operands[OperandConstants.Operand4], operands[OperandConstants.Operand5]);

            internalchg = false;

            UpdatePanelState();
        }

        public Instruction Write(Instruction inst)
        {
            if (inst != null)
            {
                wrappedByteArray operands = inst.Operands;
                // wrappedByteArray reserved1 = inst.Reserved1;

                operands[OperandConstants.Operand0] = (byte)comboFunction.SelectedIndex;

                Boolset boolset2 = new Boolset(operands[OperandConstants.Operand2]);
                boolset2[OperandConstants.Bit1] = (comboLocation.SelectedIndex == 1);
                boolset2[OperandConstants.Bit2] = (comboLocation.SelectedIndex == 2);
                boolset2[OperandConstants.Bit3] = (comboLocation.SelectedIndex == 3);
                boolset2[OperandConstants.Bit4] = (comboRelativeTo.SelectedIndex == 1);
                boolset2[OperandConstants.Bit5] = checkLineOfSight.Checked;
                boolset2[OperandConstants.Bit7] = checkIgnoreLockout.Checked;
                operands[OperandConstants.Operand2] = boolset2;

                operands[OperandConstants.Operand3] = doObject.DataOwner;
                operands[OperandConstants.Operand4] = (byte)doObject.Value;
                operands[OperandConstants.Operand5] = (byte)(doObject.Value >> 8);
            }

            return inst;
        }

        private void UpdatePanelState()
        {
            panelObject.Visible = (comboRelativeTo.SelectedIndex == 1);
        }

        private void OnControlChanged(object sender, EventArgs e)
        {
            if (internalchg) return;

            UpdatePanelState();
        }
    }
}
