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
using System.Windows.Forms;

/*
 * 0x0007 - Refresh
 * 
 * See https://modthesims.info/wiki.php?title=0x0007
 */
namespace whse.PrimitiveWizards.Wiz0x0007
{
    public partial class UI : UserControl, pjse.iBhavOperandWizForm
    {
        // private Instruction inst;

        // private bool internalchg;

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

            // internalchg = true;

            // WARNING - The data table at https://modthesims.info/wiki.php?title=0x0007 is wrong!
            WizardHelpers.ComboSelectIndex(comboWho, operands[OperandConstants.Operand0]);
            WizardHelpers.ComboSelectIndex(comboWhat, operands[OperandConstants.Operand2]);

            // internalchg = false;
        }

        public Instruction Write(Instruction inst)
        {
            if (inst != null)
            {
                wrappedByteArray operands = inst.Operands;
                // wrappedByteArray reserved1 = inst.Reserved1;

                // WARNING - The data table at https://modthesims.info/wiki.php?title=0x0007 is wrong!
                operands[OperandConstants.Operand0] = (byte)comboWho.SelectedIndex;
                operands[OperandConstants.Operand1] = 0;
                operands[OperandConstants.Operand2] = (byte)comboWhat.SelectedIndex;
                operands[OperandConstants.Operand3] = 0;
            }

            return inst;
        }
    }
}
