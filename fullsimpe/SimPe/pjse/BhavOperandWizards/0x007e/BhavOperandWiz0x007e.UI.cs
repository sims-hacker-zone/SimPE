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
 * 0x007E - LUA
 * 
 * See https://www.picknmixmods.com/Sims2/Notes/Primitives/0x007E.html
 */
namespace whse.PrimitiveWizards.Wiz0x007e
{
    public partial class UI : UserControl, pjse.iBhavOperandWizForm
    {
        private Instruction inst;

        private DataOwnerControl doStrRes, doStrEntry, doParam1, doParam2, doParam3;

        private bool internalchg;

        private readonly pjse.Scope[] scopeArray = new pjse.Scope[3]
        {
            pjse.Scope.Private,
            pjse.Scope.SemiGlobal,
            pjse.Scope.Global
        };

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

            Boolset boolset4 = new Boolset(operands[OperandConstants.Operand4]);

            internalchg = true;

            doStrRes = WizardHelpers.CreateDataControl(inst, textStrRes, checkDecimal, operands[OperandConstants.Operand0], operands[OperandConstants.Operand1]);
            comboStrScope.SelectedIndex = (boolset4[OperandConstants.Bit2] ? 0 : (boolset4[OperandConstants.Bit3] ? 1 : 2));
            doStrEntry = WizardHelpers.CreateDataControl(inst, textStrEntry, checkDecimal, operands[OperandConstants.Operand2], operands[OperandConstants.Operand3]);
            comboScriptType.SelectedIndex = (boolset4[OperandConstants.Bit1] ? 0 : 1);

            checkParameters.Checked = boolset4[OperandConstants.Bit4];
            doParam1 = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner1, comboDataPicker1, textDataValue1, checkDecimal, checkAttrPicker, toolTip, operands[OperandConstants.Operand6], operands[OperandConstants.Operand7], reserved1[OperandConstants.Operand8]);
            doParam2 = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner2, comboDataPicker2, textDataValue2, checkDecimal, checkAttrPicker, toolTip, reserved1[OperandConstants.Operand9], reserved1[OperandConstants.Operand10], reserved1[OperandConstants.Operand11]);
            doParam3 = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner3, comboDataPicker3, textDataValue3, checkDecimal, checkAttrPicker, toolTip, reserved1[OperandConstants.Operand12], reserved1[OperandConstants.Operand13], reserved1[OperandConstants.Operand14]);

            internalchg = false;

            // Do these manually, as we want them after the Data Owner control handlers
            textStrRes.TextChanged += new System.EventHandler(OnScriptControlChanged);
            textStrEntry.TextChanged += new System.EventHandler(OnScriptControlChanged);

            UpdateScriptName();
            UpdatePanelState();
        }

        public Instruction Write(Instruction inst)
        {
            if (inst != null)
            {
                wrappedByteArray operands = inst.Operands;
                wrappedByteArray reserved1 = inst.Reserved1;

                operands[OperandConstants.Operand0] = (byte)doStrRes.Value;
                operands[OperandConstants.Operand1] = (byte)(doStrRes.Value >> 8);

                operands[OperandConstants.Operand2] = (byte)doStrEntry.Value;
                operands[OperandConstants.Operand3] = (byte)(doStrEntry.Value >> 8);

                Boolset boolset4 = new Boolset(operands[OperandConstants.Operand4]);
                boolset4[OperandConstants.Bit1] = (comboScriptType.SelectedIndex == 0);
                boolset4[OperandConstants.Bit2] = (comboStrScope.SelectedIndex == 0);
                boolset4[OperandConstants.Bit3] = (comboStrScope.SelectedIndex == 1);
                boolset4[OperandConstants.Bit4] = checkParameters.Checked;
                operands[OperandConstants.Operand4] = boolset4;

                operands[OperandConstants.Operand6] = doParam1.DataOwner;
                operands[OperandConstants.Operand7] = (byte)doParam1.Value;
                reserved1[OperandConstants.Operand8] = (byte)(doParam1.Value >> 8);

                reserved1[OperandConstants.Operand9] = doParam2.DataOwner;
                reserved1[OperandConstants.Operand10] = (byte)doParam2.Value;
                reserved1[OperandConstants.Operand11] = (byte)(doParam2.Value >> 8);

                reserved1[OperandConstants.Operand12] = doParam3.DataOwner;
                reserved1[OperandConstants.Operand13] = (byte)doParam3.Value;
                reserved1[OperandConstants.Operand14] = (byte)(doParam3.Value >> 8);
            }

            return inst;
        }

        private void ShowStrChooser()
        {
            pjse.FileTable.Entry[] entryArray = comboStrScope.SelectedIndex < 0 ? (pjse.FileTable.Entry[])null : pjse.FileTable.GFT[MetaData.STRING_FILE, inst.Parent.GroupForScope(scopeArray[comboStrScope.SelectedIndex]), doStrRes.Value];

            if (entryArray == null || entryArray.Length == 0)
            {
                MessageBox.Show(pjse.Localization.GetString("bow_noStrings") + " (" + pjse.Localization.GetString(scopeArray[comboStrScope.SelectedIndex].ToString()) + ")");
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

                    WizardHelpers.SetValue(textStrEntry, (ushort)(strIndex + 1), checkDecimal);
                    UpdateScriptName();

                    this.internalchg = internalchg;
                }
            }
        }

        private void UpdateScriptName()
        {
            try
            {
                WizardHelpers.SetName(lblScriptName, toolTip, comboStrScope.SelectedIndex < 0 ? "" : ((pjse.BhavWiz)inst).readStr(scopeArray[comboStrScope.SelectedIndex], (pjse.GS.GlobalStr)doStrRes.Value, (ushort)(doStrEntry.Value - 1), -1, pjse.Detail.ErrorNames));
            }
            catch (Exception)
            {
            }
        }

        private void UpdatePanelState()
        {
            panelParameters.Visible = checkParameters.Checked;
        }

        private void OnScriptControlChanged(object sender, EventArgs e)
        {
            if (internalchg) return;

            UpdateScriptName();
        }

        private void OnScriptPickerClicked(object sender, EventArgs e)
        {
            ShowStrChooser();
        }

        private void OnParametersClicked(object sender, EventArgs e)
        {
            if (internalchg) return;

            UpdatePanelState();
        }
    }
}
