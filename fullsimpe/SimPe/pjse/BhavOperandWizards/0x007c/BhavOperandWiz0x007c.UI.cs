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
using SimPe.Plugin;
using System;
using System.ComponentModel;
using System.Windows.Forms;

/*
 * 0x007C - Want Satisfy
 * 
 * See https://modthesims.info/wiki.php?title=0x007C
 */
namespace whse.PrimitiveWizards.Wiz0x007c
{
    public partial class UI : UserControl, pjse.iBhavOperandWizForm
    {
        private Instruction inst;

        private DataOwnerControl doTargetSim, doSubjectSim, doLevel;

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

            internalchg = true;

            doTargetSim = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner1, comboDataPicker1, textDataValue1, checkDecimal, checkAttrPicker, toolTip, operands[OperandConstants.Operand0], operands[OperandConstants.Operand1], operands[OperandConstants.Operand2]);

            WizardHelpers.SetGUID((byte[])operands, OperandConstants.Operand3, textGUID, null);

            doSubjectSim = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner2, comboDataPicker2, textDataValue2, checkDecimal, checkAttrPicker, toolTip, operands[OperandConstants.Operand7], reserved1[OperandConstants.Operand8], reserved1[OperandConstants.Operand9]);

            doLevel = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner3, comboDataPicker3, textDataValue3, checkDecimal, checkAttrPicker, toolTip, reserved1[OperandConstants.Operand10], reserved1[OperandConstants.Operand11], reserved1[OperandConstants.Operand12]);

            WizardHelpers.ComboSelectIndex(comboType, reserved1[OperandConstants.Operand13]);

            internalchg = false;

            UpdateWantName();
            UpdatePanelState();
        }

        public Instruction Write(Instruction inst)
        {
            if (inst != null)
            {
                wrappedByteArray operands = inst.Operands;
                wrappedByteArray reserved1 = inst.Reserved1;

                operands[OperandConstants.Operand0] = doTargetSim.DataOwner;
                operands[OperandConstants.Operand1] = (byte)doTargetSim.Value;
                operands[OperandConstants.Operand2] = (byte)(doTargetSim.Value >> 8);

                uint uint32 = Convert.ToUInt32(textGUID.Text, 16);
                operands[OperandConstants.Operand3] = (byte)(uint32 & (uint)byte.MaxValue);
                operands[OperandConstants.Operand4] = (byte)(uint32 >> 8 & (uint)byte.MaxValue);
                operands[OperandConstants.Operand5] = (byte)(uint32 >> 16 & (uint)byte.MaxValue);
                operands[OperandConstants.Operand6] = (byte)(uint32 >> 24 & (uint)byte.MaxValue);

                operands[OperandConstants.Operand7] = doSubjectSim.DataOwner;
                reserved1[OperandConstants.Operand8] = (byte)doSubjectSim.Value;
                reserved1[OperandConstants.Operand9] = (byte)(doSubjectSim.Value >> 8);

                reserved1[OperandConstants.Operand10] = doLevel.DataOwner;
                reserved1[OperandConstants.Operand11] = (byte)doLevel.Value;
                reserved1[OperandConstants.Operand12] = (byte)(doLevel.Value >> 8);

                reserved1[OperandConstants.Operand13] = (byte)comboType.SelectedIndex;
            }

            return inst;
        }

        private void OnGuidChanged(object sender, EventArgs e)
        {
            if (!WizardHelpers.Hex32_IsValid(sender)) return;

            UpdateWantName();
        }

        private void OnGuidValidating(object sender, CancelEventArgs e)
        {
            if (WizardHelpers.Hex32_IsValid(sender)) return;

            bool internalchg = this.internalchg;
            this.internalchg = true;

            e.Cancel = true;
            ((Control)sender).Text = "0x" + SimPe.Helper.HexString(inst.Operands[OperandConstants.Operand3] | inst.Operands[OperandConstants.Operand4] << 8 | inst.Operands[OperandConstants.Operand5] << 16 | inst.Operands[OperandConstants.Operand6] << 24);
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

        private void UpdateWantName()
        {
            try
            {
                WantInformation wantInfo = WantInformation.LoadWant(Convert.ToUInt32(textGUID.Text, 16));

                // wantInfo.Name doesn't work :(
                WizardHelpers.SetName(lblWantName, toolTip, wantInfo.XWant.NodeText);
            }
            catch (Exception)
            {
                WizardHelpers.SetName(lblWantName, toolTip, textGUID.Text);
            }
        }

        private void UpdatePanelState()
        {
        }

        private void OnWantControlChanged(object sender, EventArgs e)
        {
            if (internalchg) return;

            UpdateWantName();
        }
    }
}
