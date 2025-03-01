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

using SimPe.PackedFiles.Wrapper;
using System;
using System.Windows.Forms;

/*
 * 0x0014 - Run Functional Tree
 * 
 * See https://modthesims.info/wiki.php?title=0x0014
 */
namespace whse.PrimitiveWizards.Wiz0x0014
{
    public partial class UI : UserControl, pjse.iBhavOperandWizForm
    {
        // private Instruction inst;

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
            // this.inst = inst;

            wrappedByteArray operands = inst.Operands;
            // wrappedByteArray reserved1 = inst.Reserved1;

            Boolset boolset2 = new Boolset(operands[OperandConstants.Operand2]);

            internalchg = true;

            WizardHelpers.ComboSelectIndex(comboFunction, operands[OperandConstants.Operand0]);

            checkChangeIcon.Checked = boolset2[OperandConstants.Bit1];
            checkPassParams.Checked = boolset2[OperandConstants.Bit2];
            checkCheckTreeOnly.Checked = boolset2[OperandConstants.Bit3];

            internalchg = false;
        }

        public Instruction Write(Instruction inst)
        {
            if (inst != null)
            {
                wrappedByteArray operands = inst.Operands;
                // wrappedByteArray reserved1 = inst.Reserved1;

                operands[OperandConstants.Operand0] = (byte)comboFunction.SelectedIndex;

                Boolset boolset2 = new Boolset(operands[OperandConstants.Operand2]);
                boolset2[OperandConstants.Bit1] = checkChangeIcon.Checked;
                boolset2[OperandConstants.Bit2] = checkPassParams.Checked;
                boolset2[OperandConstants.Bit3] = checkCheckTreeOnly.Checked;
                operands[OperandConstants.Operand2] = boolset2;
            }

            return inst;
        }
    }
}
