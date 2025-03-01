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
using SimPe.PackedFiles.UserInterface;
using SimPe.PackedFiles.Wrapper;
using System;
using System.Windows.Forms;

/*
 * 0x007A - On Timer
 * 
 * See https://www.picknmixmods.com/Sims2/Notes/Primitives/0x007A.html
 */
namespace whse.PrimitiveWizards.Wiz0x007a
{
    public partial class UI : UserControl, pjse.iBhavOperandWizForm
    {
        private Instruction inst;

        private DataOwnerControl doTickCount, doEventTree, doParam1, doParam2, doParam3;

        private LinkLabel lblEventTreeLink;

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

            Boolset boolset5 = new Boolset(operands[OperandConstants.Operand5]);

            internalchg = true;

            WizardHelpers.ComboSelectIndex(comboAction, reserved1[OperandConstants.Operand15]);

            comboTickCount.SelectedIndex = (boolset5[OperandConstants.Bit4] ? 1 : 0);
            doTickCount = WizardHelpers.CreateDataControl(inst, textTickCount, checkDecimal, operands[OperandConstants.Operand0], operands[OperandConstants.Operand1]);

            // IDEA - 0x007A, Op2 - correct SimPe for this operand?
            WizardHelpers.ComboSelectIndex(comboEventTreeScope, (operands[OperandConstants.Operand2] & 0x03)); // See comment about this in the operands table
            doEventTree = WizardHelpers.CreateDataControl(inst, textEventTree, checkDecimal, operands[OperandConstants.Operand3], operands[OperandConstants.Operand4]);

            lblEventTreeLink = WizardHelpers.CreateLinkLabel(lblEventTree);
            lblEventTreeLink.Click += new System.EventHandler(OnEventTreeLinkClicked);

            checkLooping.Checked = boolset5[OperandConstants.Bit2];
            checkReset.Checked = boolset5[OperandConstants.Bit3];

            comboParamType.SelectedIndex = (boolset5[OperandConstants.Bit1] ? 0 : 1);
            doParam1 = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner1, comboDataPicker1, textDataValue1, checkDecimal, checkAttrPicker, toolTip, operands[OperandConstants.Operand6], operands[OperandConstants.Operand7], reserved1[OperandConstants.Operand8]);
            doParam2 = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner2, comboDataPicker2, textDataValue2, checkDecimal, checkAttrPicker, toolTip, reserved1[OperandConstants.Operand9], reserved1[OperandConstants.Operand10], reserved1[OperandConstants.Operand11]);
            doParam3 = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner3, comboDataPicker3, textDataValue3, checkDecimal, checkAttrPicker, toolTip, reserved1[OperandConstants.Operand12], reserved1[OperandConstants.Operand13], reserved1[OperandConstants.Operand14]);

            internalchg = false;

            // Do these manually, as we want them after the Data Owner control handlers
            textEventTree.TextChanged += new System.EventHandler(OnEventTreeControlChanged);

            UpdateEventTreeName();
            UpdatePanelState();
        }

        public Instruction Write(Instruction inst)
        {
            if (inst != null)
            {
                wrappedByteArray operands = inst.Operands;
                wrappedByteArray reserved1 = inst.Reserved1;

                operands[OperandConstants.Operand0] = (byte)doTickCount.Value;
                operands[OperandConstants.Operand1] = (byte)(doTickCount.Value >> 8);

                operands[OperandConstants.Operand2] = (byte)comboEventTreeScope.SelectedIndex;

                operands[OperandConstants.Operand3] = (byte)doEventTree.Value;
                operands[OperandConstants.Operand4] = (byte)(doEventTree.Value >> 8);

                Boolset boolset5 = new Boolset(operands[OperandConstants.Operand5]);
                boolset5[OperandConstants.Bit1] = (comboParamType.SelectedIndex == 0);
                boolset5[OperandConstants.Bit2] = checkLooping.Checked;
                boolset5[OperandConstants.Bit3] = checkReset.Checked;
                boolset5[OperandConstants.Bit4] = (comboTickCount.SelectedIndex == 1);
                operands[OperandConstants.Operand5] = boolset5;

                operands[OperandConstants.Operand6] = doParam1.DataOwner;
                operands[OperandConstants.Operand7] = (byte)doParam1.Value;
                reserved1[OperandConstants.Operand8] = (byte)(doParam1.Value >> 8);

                reserved1[OperandConstants.Operand9] = doParam2.DataOwner;
                reserved1[OperandConstants.Operand10] = (byte)doParam2.Value;
                reserved1[OperandConstants.Operand11] = (byte)(doParam2.Value >> 8);

                reserved1[OperandConstants.Operand12] = doParam3.DataOwner;
                reserved1[OperandConstants.Operand13] = (byte)doParam3.Value;
                reserved1[OperandConstants.Operand14] = (byte)(doParam3.Value >> 8);

                reserved1[OperandConstants.Operand15] = (byte)comboAction.SelectedIndex;
            }

            return inst;
        }

        private void UpdateEventTreeName()
        {
            try
            {
                bool found = false;

                WizardHelpers.SetName(lblEventTreeName, toolTip, pjse.BhavWiz.bhavName(inst.Parent, doEventTree.Value, ref found));

                if (!found) WizardHelpers.SetName(lblEventTreeName, toolTip, "---");

                lblEventTreeLink.Enabled = found;
            }
            catch
            {
            }
        }

        private void UpdatePanelState()
        {
            panelStartModify.Visible = (comboAction.SelectedIndex != 2);

            panelTickCount.Visible = (comboTickCount.SelectedIndex == 0);

            lblReset.Visible = checkReset.Visible = (comboAction.SelectedIndex == 1);

            panelParameters.Visible = (comboParamType.SelectedIndex == 1);
        }

        private void OnEventTreeControlChanged(object sender, EventArgs e)
        {
            if (internalchg) return;

            UpdateEventTreeName();
        }

        private void OnEventTreePickerClicked(object sender, EventArgs e)
        {
            pjse.FileTable.Entry entry = new pjse.ResourceChooser().Execute(MetaData.BHAV_FILE, inst.Parent.FileDescriptor.Group, this, false);

            if (entry != null)
            {
                textEventTree.Text = "0x" + SimPe.Helper.HexString((ushort)entry.Instance);
            }
        }

        private void OnEventTreeLinkClicked(object sender, EventArgs e)
        {
            pjse.FileTable.Entry entry = inst.Parent.ResourceByInstance(MetaData.BHAV_FILE, (uint)doEventTree.Value);

            Bhav bhav = new Bhav();
            bhav.ProcessData(entry.PFD, entry.Package);

            BhavForm uiHandler = (BhavForm)bhav.UIHandler;
            uiHandler.Tag = "Popup";
            uiHandler.Text = pjse.Localization.GetString("viewbhav") + ": " + bhav.FileName + " [" + bhav.Package.SaveFileName + "]";

            bhav.RefreshUI();
            uiHandler.Show();
        }

        private void OnControlChanged(object sender, EventArgs e)
        {
            UpdatePanelState();
        }
    }
}
