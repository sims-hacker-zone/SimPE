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
using SimPe.Data;
using SimPe.PackedFiles.Wrapper;
using System;
using System.Windows.Forms;

/*
 * 0x0074 - Reach / Put
 * 
 * See https://modthesims.info/wiki.php?title=0x0074
 * 
 * NOTE: There is an error with operand 10 on that link, it swaps the meaning of the values 1 and 2
 */
namespace whse.PrimitiveWizards.Wiz0x0074
{
    public partial class UI : UserControl, pjse.iBhavOperandWizForm
    {
        private Instruction inst;

        private DataOwnerControl doObject, doSlot, doGraspAnim, doObjectAnim;

        private bool internalchg;

        /* private readonly pjse.Scope[] scopeArray = new pjse.Scope[3]
        {
            pjse.Scope.Private,
            pjse.Scope.SemiGlobal,
            pjse.Scope.Global
        }; */


        public UI()
        {
            InitializeComponent();
        }

        public Panel WizPanel => this.panelMain;

        public void Execute(Instruction inst)
        {
            this.inst = inst;
            wrappedByteArray operands = inst.Operands;
            wrappedByteArray reserved1 = inst.Reserved1;

            Boolset boolset9 = new Boolset(reserved1[OperandConstants.Operand9]);

            internalchg = true;

            doObject = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner1, comboDataPicker1, textDataValue1, checkDecimal, checkAttrPicker, toolTip, operands[OperandConstants.Operand3], operands[OperandConstants.Operand4], operands[OperandConstants.Operand5]);

            doSlot = WizardHelpers.CreateDataControl(inst, textSlot, checkDecimal, operands[OperandConstants.Operand6]);

            comboSlot.SelectedIndex = (boolset9[OperandConstants.Bit1] ? 1 : 0);

            checkHandedness.Checked = boolset9[OperandConstants.Bit2];
            checkUseSimAge.Checked = boolset9[OperandConstants.Bit3];
            checkReachAnims.Checked = boolset9[OperandConstants.Bit4];

            WizardHelpers.ComboSelectIndex(comboAction, reserved1[OperandConstants.Operand10]);

            doGraspAnim = WizardHelpers.CreateDataControl(inst, textGraspAnim, checkDecimal, reserved1[OperandConstants.Operand11], reserved1[OperandConstants.Operand12]);
            checkGraspAnim.Checked = (doGraspAnim.Value != 0xFFFF);

            doObjectAnim = WizardHelpers.CreateDataControl(inst, textObjectAnim, checkDecimal, reserved1[OperandConstants.Operand13], reserved1[OperandConstants.Operand14]);
            checkObjectAnim.Checked = (doObjectAnim.Value != 0xFFFF);

            internalchg = false;

            // Do these manually, as we want them after the Data Owner control handlers
            textGraspAnim.TextChanged += new System.EventHandler(OnAnimsChanged);
            textObjectAnim.TextChanged += new System.EventHandler(OnAnimsChanged);

            UpdateAnimNames();
            UpdatePanelState();
        }

        public Instruction Write(Instruction inst)
        {
            if (inst != null)
            {
                wrappedByteArray operands = inst.Operands;
                wrappedByteArray reserved1 = inst.Reserved1;

                operands[OperandConstants.Operand3] = doObject.DataOwner;
                operands[OperandConstants.Operand4] = (byte)doObject.Value;
                operands[OperandConstants.Operand5] = (byte)(doObject.Value >> 8);

                operands[OperandConstants.Operand6] = (byte)doSlot.Value;

                Boolset boolset9 = new Boolset(reserved1[OperandConstants.Operand9]);
                boolset9[OperandConstants.Bit1] = (comboSlot.SelectedIndex == 1);
                boolset9[OperandConstants.Bit2] = checkHandedness.Checked;
                boolset9[OperandConstants.Bit3] = checkUseSimAge.Checked;
                boolset9[OperandConstants.Bit4] = checkReachAnims.Checked;
                reserved1[OperandConstants.Operand9] = boolset9;

                reserved1[OperandConstants.Operand10] = (byte)comboAction.SelectedIndex;

                if (checkGraspAnim.Checked)
                {
                    reserved1[OperandConstants.Operand11] = (byte)doGraspAnim.Value;
                    reserved1[OperandConstants.Operand12] = (byte)(doGraspAnim.Value >> 8);
                }
                else
                {
                    reserved1[OperandConstants.Operand11] = 0xFF;
                    reserved1[OperandConstants.Operand12] = 0xFF;
                }

                if (checkObjectAnim.Checked)
                {
                    reserved1[OperandConstants.Operand13] = (byte)doObjectAnim.Value;
                    reserved1[OperandConstants.Operand14] = (byte)(doObjectAnim.Value >> 8);
                }
                else
                {
                    reserved1[OperandConstants.Operand13] = 0xFF;
                    reserved1[OperandConstants.Operand14] = 0xFF;
                }
            }

            return inst;
        }

        private void ShowStrChooser(pjse.GS.GlobalStr strResource, TextBox textAnim)
        {
            pjse.FileTable.Entry[] entryArray =
                pjse.FileTable.GFT[MetaData.STRING_FILE, inst.Parent.GroupForScope(pjse.Scope.Private), (uint)strResource] ??
                pjse.FileTable.GFT[MetaData.STRING_FILE, inst.Parent.GroupForScope(pjse.Scope.SemiGlobal), (uint)strResource];

            if (entryArray == null || entryArray.Length == 0)
            {
                MessageBox.Show(pjse.Localization.GetString("bow_noStrings"));
            }
            else
            {
                StrWrapper wrapper = new StrWrapper();

                wrapper.ProcessData(entryArray[0].PFD, entryArray[0].Package);

                int strIndex = new pjse.StrChooser(true).Strnum(wrapper);

                if (strIndex >= 0)
                {
                    bool internalchg = this.internalchg;
                    this.internalchg = true;

                    WizardHelpers.SetValue(textAnim, (ushort)strIndex, checkDecimal);
                    UpdateAnimNames();

                    this.internalchg = internalchg;
                }
            }
        }

        private void UpdateAnimNames()
        {
            try
            {
                WizardHelpers.SetName(lblGraspAnimName, toolTip, checkGraspAnim.Checked ? ((pjse.BhavWiz)inst).readStr(checkReachAnims.Checked? pjse.GS.GlobalStr.ReachAnims : pjse.GS.GlobalStr.AdultAnims, (ushort)(doGraspAnim.Value), -1, pjse.Detail.ErrorNames) : "");
                WizardHelpers.SetName(lblObjectAnimName, toolTip, checkObjectAnim.Checked ? ((pjse.BhavWiz)inst).readStr(pjse.GS.GlobalStr.ObjectAnims, (ushort)(doObjectAnim.Value), -1, pjse.Detail.ErrorNames) : "");
            }
            catch (Exception)
            {
            }
        }

        private void UpdatePanelState()
        {
            bool slotVisible = (comboAction.SelectedIndex == 1);

            lblSlot.Visible = comboSlot.Visible = slotVisible;

            panelSlot.Visible = slotVisible && (comboSlot.SelectedIndex == 0);

            panelObject.Visible = (comboAction.SelectedIndex != 2);

            panelGraspAnim.Visible = checkGraspAnim.Checked;

            panelObjectAnim.Visible = checkObjectAnim.Checked;
        }

        private void OnControlChanged(object sender, EventArgs e)
        {
            if (internalchg) return;

            UpdatePanelState();
        }

        private void OnAnimsChanged(object sender, EventArgs e)
        {
            if (internalchg) return;

            UpdateAnimNames();
        }

        private void OnGraspAnimClicked(object sender, EventArgs e)
        {
            ShowStrChooser(checkReachAnims.Checked ? pjse.GS.GlobalStr.ReachAnims : pjse.GS.GlobalStr.AdultAnims, textGraspAnim);
        }

        private void OnObjectAnimClicked(object sender, EventArgs e)
        {
            ShowStrChooser(pjse.GS.GlobalStr.ObjectAnims, textObjectAnim);
        }
    }
}
