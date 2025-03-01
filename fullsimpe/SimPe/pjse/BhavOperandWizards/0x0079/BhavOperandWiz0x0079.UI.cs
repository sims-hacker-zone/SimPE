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
 * 0x0079 - Change Outfit
 * 
 * See https://www.picknmixmods.com/Sims2/Notes/Primitives/0x0079.html
 */
namespace whse.PrimitiveWizards.Wiz0x0079
{
    public partial class UI : UserControl, pjse.iBhavOperandWizForm
    {
        private Instruction inst;

        DataOwnerControl doVariable, doTarget;

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

            Boolset boolset0 = (Boolset)operands[OperandConstants.Operand0];

            internalchg = true;

            comboSource.SelectedIndex = (boolset0[OperandConstants.Bit1] ? 3 : (boolset0[OperandConstants.Bit2] ? 1 : (boolset0[OperandConstants.Bit7] ? 2 : 0)));

            checkOutfitVariable.Checked = boolset0[OperandConstants.Bit3];
            checkSave.Checked = boolset0[OperandConstants.Bit4];
            checkRebuild.Checked = boolset0[OperandConstants.Bit5];
            checkClear.Checked = boolset0[OperandConstants.Bit6];

            doVariable = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner2, comboDataPicker2, textDataValue2, checkDecimal, checkAttrPicker, toolTip, operands[OperandConstants.Operand1], operands[OperandConstants.Operand2], operands[OperandConstants.Operand3]);

            WizardHelpers.SetGUID((byte[])operands, OperandConstants.Operand4, textGUID, lblGuid);

            WizardHelpers.ComboSelectIndex(comboOutfitType, reserved1[OperandConstants.Operand8]);

            doTarget = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner1, comboDataPicker1, textDataValue1, checkDecimal, checkAttrPicker, toolTip, reserved1[OperandConstants.Operand9], reserved1[OperandConstants.Operand10], reserved1[OperandConstants.Operand11]);

            internalchg = false;

            UpdatePanelState();
        }

        public Instruction Write(Instruction inst)
        {
            if (inst != null)
            {
                wrappedByteArray operands = inst.Operands;
                wrappedByteArray reserved1 = inst.Reserved1;

                Boolset boolset0 = (Boolset)operands[OperandConstants.Operand0];
                boolset0[OperandConstants.Bit1] = (comboSource.SelectedIndex == 3);
                boolset0[OperandConstants.Bit2] = (comboSource.SelectedIndex == 1);
                boolset0[OperandConstants.Bit3] = checkOutfitVariable.Checked;
                boolset0[OperandConstants.Bit4] = checkSave.Checked;
                boolset0[OperandConstants.Bit5] = checkRebuild.Checked;
                boolset0[OperandConstants.Bit6] = checkClear.Checked;
                boolset0[OperandConstants.Bit7] = (comboSource.SelectedIndex == 2);
                operands[OperandConstants.Operand0] = (byte)boolset0;

                operands[OperandConstants.Operand1] = doVariable.DataOwner;
                operands[OperandConstants.Operand2] = (byte)doVariable.Value;
                operands[OperandConstants.Operand3] = (byte)(doVariable.Value >> 8);

                uint uint32 = Convert.ToUInt32(textGUID.Text, 16);
                operands[OperandConstants.Operand4] = (byte)(uint32 & (uint)byte.MaxValue);
                operands[OperandConstants.Operand5] = (byte)(uint32 >> 8 & (uint)byte.MaxValue);
                operands[OperandConstants.Operand6] = (byte)(uint32 >> 16 & (uint)byte.MaxValue);
                operands[OperandConstants.Operand7] = (byte)(uint32 >> 24 & (uint)byte.MaxValue);

                reserved1[OperandConstants.Operand8] = (byte)comboOutfitType.SelectedIndex;

                reserved1[OperandConstants.Operand9] = doTarget.DataOwner;
                reserved1[OperandConstants.Operand10] = (byte)doTarget.Value;
                reserved1[OperandConstants.Operand11] = (byte)(doTarget.Value >> 8);
            }

            return inst;
        }

        private void UpdatePanelState()
        {
            textGUID.Visible = lblGuid.Visible = (comboSource.SelectedIndex == 1);

            comboOutfitType.Visible = !checkOutfitVariable.Checked;
            panelVariable.Visible = checkOutfitVariable.Checked;
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
