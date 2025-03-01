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
 * 0x0017 - Play / Stop Sound Event
 * 
 * See https://www.picknmixmods.com/Sims2/Notes/Primitives/0x0017.html
 */
namespace whse.PrimitiveWizards.Wiz0x0017
{
    public partial class UI : UserControl, pjse.iBhavOperandWizForm
    {
        private Instruction inst;

        private DataOwnerControl doSound, doSampleRate, doVolume;

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
            // wrappedByteArray reserved1 = inst.Reserved1;

            Boolset boolset4 = new Boolset(operands[OperandConstants.Operand4]);

            internalchg = true;

            ushort index = pjse.BhavWiz.ToShort(operands[OperandConstants.Operand0], operands[OperandConstants.Operand1]);

            if (index >= 20000)
            {
                comboSoundScope.SelectedIndex = 1;
                doSound = WizardHelpers.CreateDataControl(inst, textSoundEntry, checkDecimal, (ushort)(index - 20000));
            }
            else if (index >= 10000)
            {
                comboSoundScope.SelectedIndex = 2;
                doSound = WizardHelpers.CreateDataControl(inst, textSoundEntry, checkDecimal, (ushort)(index - 10000));
            }
            else
            {
                comboSoundScope.SelectedIndex = 0;
                doSound = WizardHelpers.CreateDataControl(inst, textSoundEntry, checkDecimal, index);
            }

            doSampleRate = WizardHelpers.CreateDataControl(inst, textSampleRate, checkDecimal, operands[OperandConstants.Operand2], operands[OperandConstants.Operand3]);

            comboSource.SelectedIndex = (boolset4[OperandConstants.Bit2] ? 1 : 0);

            checkAutoVary.Checked = boolset4[OperandConstants.Bit5];

            comboPlayStop.SelectedIndex = (boolset4[OperandConstants.Bit7] ? 1 : 0);

            doVolume = WizardHelpers.CreateDataControl(inst, textVolume, checkDecimal, operands[OperandConstants.Operand5]);

            internalchg = false;

            // Do these manually, as we want them after the Data Owner control handlers
            textSoundEntry.TextChanged += new EventHandler(OnSoundControlChanged);

            UpdateSoundName();
            UpdatePanelState();
        }

        public Instruction Write(Instruction inst)
        {
            if (inst != null)
            {
                wrappedByteArray operands = inst.Operands;
                // wrappedByteArray reserved1 = inst.Reserved1;

                ushort index = doSound.Value;

                if (comboSoundScope.SelectedIndex == 1)
                {
                    index += 20000;
                }
                else if (comboSoundScope.SelectedIndex == 2)
                {
                    index += 10000;
                }

                operands[OperandConstants.Operand0] = (byte)index;
                operands[OperandConstants.Operand1] = (byte)(index >> 8);

                operands[OperandConstants.Operand2] = (byte)doSampleRate.Value;
                operands[OperandConstants.Operand3] = (byte)(doSampleRate.Value >> 8);

                Boolset boolset4 = new Boolset(operands[OperandConstants.Operand4]);
                boolset4[OperandConstants.Bit2] = (comboSource.SelectedIndex == 1);
                boolset4[OperandConstants.Bit5] = checkAutoVary.Checked;
                boolset4[OperandConstants.Bit7] = (comboPlayStop.SelectedIndex == 1);
                operands[OperandConstants.Operand4] = boolset4;

                operands[OperandConstants.Operand5] = (byte)doVolume.Value;
            }

            return inst;
        }

        private void ShowStrChooser()
        {
            pjse.FileTable.Entry[] entryArray = comboSoundScope.SelectedIndex < 0 ? (pjse.FileTable.Entry[])null : pjse.FileTable.GFT[MetaData.STRING_FILE, inst.Parent.GroupForScope(scopeArray[comboSoundScope.SelectedIndex]), (ushort)pjse.GS.GlobalStr.Sound];

            if (entryArray == null || entryArray.Length == 0)
            {
                MessageBox.Show(pjse.Localization.GetString("bow_noStrings") + " (" + pjse.Localization.GetString(scopeArray[comboSoundScope.SelectedIndex].ToString()) + ")");
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

                    WizardHelpers.SetValue(textSoundEntry, (ushort)strIndex, checkDecimal);
                    UpdateSoundName();

                    this.internalchg = internalchg;
                }
            }
        }

        private void UpdateSoundName()
        {
            try
            {
                WizardHelpers.SetName(lblSoundName, toolTip, comboSoundScope.SelectedIndex < 0 ? "" : ((pjse.BhavWiz)inst).readStr(scopeArray[comboSoundScope.SelectedIndex], pjse.GS.GlobalStr.Sound, doSound.Value, -1, pjse.Detail.ErrorNames));
            }
            catch (Exception)
            {
            }
        }

        private void UpdatePanelState()
        {
        }

        private void OnSoundControlChanged(object sender, EventArgs e)
        {
            if (internalchg) return;

            UpdateSoundName();
        }

        private void OnSoundPickerClicked(object sender, EventArgs e)
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
