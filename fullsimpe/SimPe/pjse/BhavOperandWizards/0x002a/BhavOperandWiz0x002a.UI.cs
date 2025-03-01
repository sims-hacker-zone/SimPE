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
using System.ComponentModel;
using System.Windows.Forms;

/*
 * 0x002A - Create New Object Instance (CNOI)
 * 
 * See https://modthesims.info/wiki.php?title=0x002A
 */
namespace whse.PrimitiveWizards.Wiz0x002a
{
    public partial class UI : UserControl, pjse.iBhavOperandWizForm
    {
        private Instruction inst;

        DataOwnerControl doLocal, doSlot;

        private bool internalchg;

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

            Boolset boolset5 = (Boolset)operands[OperandConstants.Operand5];
            Boolset boolset10 = (Boolset)reserved1[OperandConstants.Operand10];

            internalchg = true;

            // Operands 0 thru 3, the GUID
            WizardHelpers.SetGUID((byte[])operands, OperandConstants.Operand0, textGUID, lblGuid);

            // Operand 4, where to create the object
            WizardHelpers.ComboSelectIndex(comboCreateWhere, operands[OperandConstants.Operand4]);

            // Operand 5, bit flags
            WizardHelpers.ComboSelectIndex(comboCreateHow, (operands[OperandConstants.Operand5] & 0x03));
            checkFailIfTileNonEmpty.Checked = boolset5[OperandConstants.Bit4];
            checkPassT0ToMain.Checked = boolset5[OperandConstants.Bit5];
            comboCreateWhat.SelectedIndex = (boolset5[OperandConstants.Bit8] ? 1 : (boolset5[OperandConstants.Bit7] ? 2 : (boolset5[OperandConstants.Bit3] ? 3 : 0)));

            // Operand 6, local variable used when op4 is 0x08 or 0x09
            doLocal = WizardHelpers.CreateDataControl(inst, textLocal, checkDecimal, operands[OperandConstants.Operand6]);

            // Operands 7 thru 8 appear to be unused

            // Operand 9, slot used when op4 is 0x04
            doSlot = WizardHelpers.CreateDataControl(inst, textSlot, checkDecimal, reserved1[OperandConstants.Operand9]);

            // Operand 10, bit flags
            checkMoveInSim.Checked = boolset10[OperandConstants.Bit1];
            checkCopyMaterials.Checked = boolset10[OperandConstants.Bit2];

            // Operands 11 thru 15 appear to be unused

            internalchg = false;

            UpdatePanelState();
        }

        public Instruction Write(Instruction inst)
        {
            if (inst != null)
            {
                wrappedByteArray operands = inst.Operands;
                wrappedByteArray reserved1 = inst.Reserved1;

                // Operands 0 thru 3
                uint uint32 = Convert.ToUInt32(textGUID.Text, 16);
                operands[OperandConstants.Operand0] = (byte)(uint32 & (uint)byte.MaxValue);
                operands[OperandConstants.Operand1] = (byte)(uint32 >> 8 & (uint)byte.MaxValue);
                operands[OperandConstants.Operand2] = (byte)(uint32 >> 16 & (uint)byte.MaxValue);
                operands[OperandConstants.Operand3] = (byte)(uint32 >> 24 & (uint)byte.MaxValue);

                // Operand 4
                operands[OperandConstants.Operand4] = (byte)comboCreateWhere.SelectedIndex;

                // Operand 5
                Boolset boolset5 = (Boolset)operands[OperandConstants.Operand5];
                boolset5[OperandConstants.Bit1] = (comboCreateHow.SelectedIndex == 1);
                boolset5[OperandConstants.Bit2] = (comboCreateHow.SelectedIndex == 2);
                boolset5[OperandConstants.Bit3] = (comboCreateWhat.SelectedIndex == 3);
                boolset5[OperandConstants.Bit4] = checkFailIfTileNonEmpty.Checked;
                boolset5[OperandConstants.Bit5] = checkPassT0ToMain.Checked;
                boolset5[OperandConstants.Bit7] = (comboCreateWhat.SelectedIndex == 2);
                boolset5[OperandConstants.Bit8] = (comboCreateWhat.SelectedIndex == 1);
                operands[OperandConstants.Operand5] = (byte)boolset5;

                // Operand 6
                operands[OperandConstants.Operand6] = (byte)doLocal.Value;

                // Operands 7 thru 8 appear to be unused

                // Operand 9
                reserved1[OperandConstants.Operand9] = (byte)doSlot.Value;

                // Operand 10
                Boolset boolset10 = (Boolset)reserved1[OperandConstants.Operand10];
                boolset10[OperandConstants.Bit1] = checkMoveInSim.Checked;
                boolset10[OperandConstants.Bit2] = checkCopyMaterials.Checked;
                reserved1[OperandConstants.Operand10] = (byte)boolset10;

                // Operands 11 thru 15 appear to be unused
            }

            return inst;
        }

        private void UpdatePanelState()
        {
            textGUID.Visible = lblGuid.Visible = (comboCreateWhat.SelectedIndex == 0);

            textLocal.Visible = (comboCreateWhere.SelectedIndex == 8 || comboCreateWhere.SelectedIndex == 9);
            textSlot.Visible = (comboCreateWhere.SelectedIndex == 4);
        }

        private void OnGuidChanged(object sender, EventArgs e)
        {
            if (!WizardHelpers.Hex32_IsValid(sender)) return;

            WizardHelpers.SetGUID(Convert.ToUInt32(((Control)sender).Text, 16), null, lblGuid);
        }

        private void OnGuidValidating(object sender, CancelEventArgs e)
        {
            if (WizardHelpers.Hex32_IsValid(sender)) return;

            bool internalchg = this.internalchg;
            this.internalchg = true;

            e.Cancel = true;
            ((Control)sender).Text = "0x" + SimPe.Helper.HexString(inst.Operands[OperandConstants.Operand0] | inst.Operands[OperandConstants.Operand1] << 8 | inst.Operands[OperandConstants.Operand2] << 16 | inst.Operands[OperandConstants.Operand3] << 24);
            ((TextBoxBase)sender).SelectAll();

            this.internalchg = internalchg;
        }

        private void OnGuidValidated(object sender, EventArgs e)
        {
            bool internalchg = this.internalchg;
            this.internalchg = true;

            ((Control)sender).Text = "0x" + SimPe.Helper.HexString(Convert.ToUInt32(((Control)sender).Text, 16));
            ((TextBoxBase)sender).SelectAll();

            this.internalchg = internalchg;
        }

        private void OnControlChanged(object sender, EventArgs e)
        {
            if (internalchg) return;

            UpdatePanelState();
        }
    }
}
