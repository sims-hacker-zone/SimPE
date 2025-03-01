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
 * 0x006F - Change Light
 * 
 * See https://www.picknmixmods.com/Sims2/Notes/Primitives/0x006F.html
 */
namespace whse.PrimitiveWizards.Wiz0x006f
{
    public partial class UI : UserControl, pjse.iBhavOperandWizForm
    {
        private Instruction inst;

        private DataOwnerControl doTarget, doTickCount, doIntensity, doLight;

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

            Boolset boolset1 = new Boolset(operands[OperandConstants.Operand1]);

            internalchg = true;

            comboTickCount.SelectedIndex = (boolset1[OperandConstants.Bit1] ? 1 : 0);
            comboIntensity.SelectedIndex = (boolset1[OperandConstants.Bit2] ? 1 : 0);

            doTarget = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner1, comboDataPicker1, textDataValue1, checkDecimal, checkAttrPicker, toolTip, operands[OperandConstants.Operand2], operands[OperandConstants.Operand3], operands[OperandConstants.Operand4]);

            doTickCount = WizardHelpers.CreateDataControl(inst, textTickCount, checkDecimal, operands[OperandConstants.Operand5], operands[OperandConstants.Operand6]);

            doIntensity = WizardHelpers.CreateDataControl(inst, textIntensity, checkDecimal, operands[OperandConstants.Operand7]);

            checkAllLights.Checked = (reserved1[OperandConstants.Operand8] == 0xFF);
            doLight = WizardHelpers.CreateDataControl(inst, textLight, checkDecimal, reserved1[OperandConstants.Operand8]);

            internalchg = false;

            // Do these manually, as we want them after the Data Owner control handlers
            textLight.TextChanged += new System.EventHandler(OnLightControlChanged);

            UpdateLightName();
            UpdatePanelState();
        }

        public Instruction Write(Instruction inst)
        {
            if (inst != null)
            {
                wrappedByteArray operands = inst.Operands;
                wrappedByteArray reserved1 = inst.Reserved1;

                // Operand 0 is unused

                Boolset boolset1 = new Boolset(operands[OperandConstants.Operand1]);
                boolset1[OperandConstants.Bit1] = (comboTickCount.SelectedIndex == 1);
                boolset1[OperandConstants.Bit2] = (comboIntensity.SelectedIndex == 1);
                operands[OperandConstants.Operand1] = boolset1;

                operands[OperandConstants.Operand2] = doTarget.DataOwner;
                operands[OperandConstants.Operand3] = (byte)doTarget.Value;
                operands[OperandConstants.Operand4] = (byte)(doTarget.Value >> 8);

                operands[OperandConstants.Operand5] = (byte)doTickCount.Value;
                operands[OperandConstants.Operand6] = (byte)(doTickCount.Value >> 8);

                operands[OperandConstants.Operand7] = (byte)doIntensity.Value;

                reserved1[OperandConstants.Operand8] = (byte)(checkAllLights.Checked ? 0xFF : doLight.Value);
            }

            return inst;
        }

        private void ShowStrChooser()
        {
            pjse.FileTable.Entry[] entryArray = pjse.FileTable.GFT[MetaData.STRING_FILE, inst.Parent.GroupForScope(pjse.Scope.Private), (ushort)pjse.GS.GlobalStr.LightSource];

            if (entryArray == null || entryArray.Length == 0)
            {
                MessageBox.Show(pjse.Localization.GetString("bow_noStrings") + " (" + pjse.Localization.GetString(pjse.Scope.Private.ToString()) + ")");
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

                    WizardHelpers.SetValue(textLight, (byte)strIndex, checkDecimal);
                    UpdateLightName();

                    this.internalchg = internalchg;
                }
            }
        }

        private void UpdateLightName()
        {
            try
            {
                WizardHelpers.SetName(lblLightName, toolTip, ((pjse.BhavWiz)inst).readStr(pjse.Scope.Private, pjse.GS.GlobalStr.LightSource, doLight.Value, -1, pjse.Detail.ErrorNames));
            }
            catch (Exception)
            {
            }
        }

        private void UpdatePanelState()
        {
            panelTickCount.Visible = (comboTickCount.SelectedIndex == 0);

            panelIntensity.Visible = (comboIntensity.SelectedIndex == 0);

            panelLight.Visible = !checkAllLights.Checked;
        }

        private void OnLightControlChanged(object sender, EventArgs e)
        {
            if (internalchg) return;

            UpdateLightName();
        }

        private void OnLightPickerClicked(object sender, EventArgs e)
        {
            ShowStrChooser();
        }

        private void OnControlChanged(object sender, EventArgs e)
        {
            if (internalchg) return;

            UpdatePanelState();
        }
    }
}
