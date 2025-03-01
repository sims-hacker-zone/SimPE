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
 * 0x0070 - Effect Stop / Start
 * 
 * See https://www.picknmixmods.com/Sims2/Notes/Primitives/0x0070.html
 */
namespace whse.PrimitiveWizards.Wiz0x0070
{
    public partial class UI : UserControl, pjse.iBhavOperandWizForm
    {
        private Instruction inst;

        private DataOwnerControl doTarget, doIcon, doEffect, doSlot, doIconIndex;

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

            Boolset boolset10 = new Boolset(reserved1[OperandConstants.Operand10]);
            Boolset boolset11 = new Boolset(reserved1[OperandConstants.Operand11]);

            internalchg = true;

            WizardHelpers.ComboSelectIndex(comboAction, operands[OperandConstants.Operand0]);

            doTarget = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner1, comboDataPicker1, textDataValue1, checkDecimal, checkAttrPicker, toolTip, operands[OperandConstants.Operand1], operands[OperandConstants.Operand2], operands[OperandConstants.Operand3]);

            comboEffect.SelectedIndex = (boolset10[OperandConstants.Bit7] ? 1 : 0);

            doEffect = WizardHelpers.CreateDataControl(inst, textEffect, checkDecimal, operands[OperandConstants.Operand4]);
            comboEffectScope.SelectedIndex = (boolset10[OperandConstants.Bit1] ? 2 : (boolset10[OperandConstants.Bit2] ? 1 : 0));

            // IDEA - 0x0070, Op9 - correct SimPe for this operand?
            WizardHelpers.ComboSelectIndex(comboSlotType, reserved1[OperandConstants.Operand9]); // See comment about this in the operands table
            doSlot = WizardHelpers.CreateDataControl(inst, textSlot, checkDecimal, operands[OperandConstants.Operand6]);

            comboIconType.SelectedIndex = (boolset11[OperandConstants.Bit5] ? 5 :
                                          (boolset11[OperandConstants.Bit3] ? 4 :
                                          (boolset10[OperandConstants.Bit6] ? 3 :
                                          (boolset10[OperandConstants.Bit5] ? 2 :
                                          (boolset10[OperandConstants.Bit3] ? 1 : 0)))));
            doIcon = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner2, comboDataPicker2, textDataValue2, checkDecimal, checkAttrPicker, toolTip, reserved1[OperandConstants.Operand12], reserved1[OperandConstants.Operand13], reserved1[OperandConstants.Operand14]);
            doIconIndex = WizardHelpers.CreateDataControl(inst, textIconIndex, checkDecimal, reserved1[OperandConstants.Operand15]);

            checkPriority.Checked = boolset10[OperandConstants.Bit8];

            checkModel.Checked = boolset11[OperandConstants.Bit4];

            internalchg = false;

            // Do these manually, as we want them after the Data Owner control handlers
            textEffect.TextChanged += new System.EventHandler(OnEffectControlChanged);

            UpdateEffectName();
            UpdatePanelState();
        }

        public Instruction Write(Instruction inst)
        {
            if (inst != null)
            {
                wrappedByteArray operands = inst.Operands;
                wrappedByteArray reserved1 = inst.Reserved1;

                operands[OperandConstants.Operand0] = (byte)comboAction.SelectedIndex;

                operands[OperandConstants.Operand1] = doTarget.DataOwner;
                operands[OperandConstants.Operand2] = (byte)doTarget.Value;
                operands[OperandConstants.Operand3] = (byte)(doTarget.Value >> 8);

                operands[OperandConstants.Operand4] = (byte)doEffect.Value;

                // Operand 5 is unused

                operands[OperandConstants.Operand6] = (byte)doSlot.Value;

                // Operands 7 & 8 are unused

                reserved1[OperandConstants.Operand9] = (byte)comboSlotType.SelectedIndex;

                Boolset boolset10 = new Boolset(reserved1[OperandConstants.Operand10]);
                boolset10[OperandConstants.Bit1] = (comboEffectScope.SelectedIndex == 2);
                boolset10[OperandConstants.Bit2] = (comboEffectScope.SelectedIndex == 1);
                boolset10[OperandConstants.Bit3] = (comboIconType.SelectedIndex == 1);
                boolset10[OperandConstants.Bit5] = (comboIconType.SelectedIndex == 2);
                boolset10[OperandConstants.Bit6] = (comboIconType.SelectedIndex == 3);
                boolset10[OperandConstants.Bit7] = (comboEffect.SelectedIndex == 1);
                boolset10[OperandConstants.Bit8] = checkPriority.Checked;
                reserved1[OperandConstants.Operand10] = boolset10;

                Boolset boolset11 = new Boolset(reserved1[OperandConstants.Operand11]);
                boolset11[OperandConstants.Bit3] = (comboIconType.SelectedIndex == 4);
                boolset11[OperandConstants.Bit4] = checkModel.Checked;
                boolset11[OperandConstants.Bit5] = (comboIconType.SelectedIndex == 5);
                reserved1[OperandConstants.Operand11] = boolset11;

                reserved1[OperandConstants.Operand12] = doIcon.DataOwner;
                reserved1[OperandConstants.Operand13] = (byte)doIcon.Value;
                reserved1[OperandConstants.Operand14] = (byte)(doIcon.Value >> 8);

                reserved1[OperandConstants.Operand15] = (byte)doIconIndex.Value;
            }

            return inst;
        }

        private void ShowStrChooser()
        {
            pjse.FileTable.Entry[] entryArray = comboEffectScope.SelectedIndex < 0 ? (pjse.FileTable.Entry[])null : pjse.FileTable.GFT[MetaData.STRING_FILE, inst.Parent.GroupForScope(scopeArray[comboEffectScope.SelectedIndex]), (ushort)pjse.GS.GlobalStr.Effect];

            if (entryArray == null || entryArray.Length == 0)
            {
                MessageBox.Show(pjse.Localization.GetString("bow_noStrings") + " (" + pjse.Localization.GetString(scopeArray[comboEffectScope.SelectedIndex].ToString()) + ")");
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

                    WizardHelpers.SetValue(textEffect, (byte)strIndex, checkDecimal);
                    UpdateEffectName();

                    this.internalchg = internalchg;
                }
            }
        }

        private void UpdateEffectName()
        {
            try
            {
                string effectName;

                if (doEffect.Value == 0xFF)
                {
                    effectName = "default effect";
                }
                else
                {
                    effectName = comboEffectScope.SelectedIndex < 0 ? "" : ((pjse.BhavWiz)inst).readStr(scopeArray[comboEffectScope.SelectedIndex], pjse.GS.GlobalStr.Effect, doEffect.Value, -1, pjse.Detail.ErrorNames);
                }

                WizardHelpers.SetName(lblEffectName, toolTip, effectName);
            }
            catch (Exception)
            {
            }
        }

        private void UpdatePanelState()
        {
            comboEffect.Visible = (comboAction.SelectedIndex == 0x04 || comboAction.SelectedIndex == 0x05);

            panelEffect.Visible = ((comboAction.SelectedIndex >= 0x00 && comboAction.SelectedIndex <= 0x06) || comboAction.SelectedIndex == 0x0E);

            panelEffectVariable.Visible = ((comboAction.SelectedIndex >= 0x00 && comboAction.SelectedIndex <= 0x03) || comboAction.SelectedIndex == 0x06 || comboAction.SelectedIndex == 0x0E);

            panelSlot.Visible = !(comboAction.SelectedIndex == 0x09 || comboAction.SelectedIndex == 0x0E);

            panelIconVariable.Visible = (comboIconType.SelectedIndex == 1 || comboIconType.SelectedIndex == 2 || comboIconType.SelectedIndex == 3);

            panelIconIndex.Visible = (comboIconType.SelectedIndex == 3);

            lblModel.Visible = checkModel.Visible = (comboIconType.SelectedIndex != 5);
        }

        private void OnEffectPickerClicked(object sender, EventArgs e)
        {
            ShowStrChooser();
        }

        private void OnEffectControlChanged(object sender, EventArgs e)
        {
            if (internalchg) return;

            UpdateEffectName();
        }

        private void OnControlChanged(object sender, EventArgs e)
        {
            if (internalchg) return;

            UpdatePanelState();
        }
    }
}
