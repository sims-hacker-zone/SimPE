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
 * 0x0072 - Assign Loco Animations
 * 
 * See https://www.picknmixmods.com/Sims2/Notes/Primitives/0x0072.html
 */
namespace whse.PrimitiveWizards.Wiz0x0072
{
    public partial class UI : UserControl, pjse.iBhavOperandWizForm
    {
        private Instruction inst;

        private DataOwnerControl doLocoAnim;

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

            Boolset boolset2 = new Boolset(operands[OperandConstants.Operand2]);

            internalchg = true;

            ushort index = pjse.BhavWiz.ToShort(operands[OperandConstants.Operand0], operands[OperandConstants.Operand1]);

            if (index == 0)
            {
                comboAction.SelectedIndex = 0;
                doLocoAnim = WizardHelpers.CreateDataControl(inst, textLocoAnimEntry, checkDecimal, 0);
            }
            else if (index == 1)
            {
                comboAction.SelectedIndex = 1;
                doLocoAnim = WizardHelpers.CreateDataControl(inst, textLocoAnimEntry, checkDecimal, 0);
            }
            else
            {
                comboAction.SelectedIndex = 2;
                doLocoAnim = WizardHelpers.CreateDataControl(inst, textLocoAnimEntry, checkDecimal, (ushort)(index - 2));
            }

            comboLocoAnimScope.SelectedIndex = (boolset2[OperandConstants.Bit2] ? 1 : (boolset2[OperandConstants.Bit3] ? 2 : 0));

            internalchg = false;

            // Do these manually, as we want them after the Data Owner control handlers
            textLocoAnimEntry.TextChanged += new EventHandler(OnLocoAnimControlChanged);

            UpdateLocoAnimName();
            UpdatePanelState();
        }

        public Instruction Write(Instruction inst)
        {
            if (inst != null)
            {
                wrappedByteArray operands = inst.Operands;
                // wrappedByteArray reserved1 = inst.Reserved1;

                ushort index;

                if (comboAction.SelectedIndex == 0)
                {
                    index = 0;
                }
                else if (comboAction.SelectedIndex == 1)
                {
                    index = 1;
                }
                else
                {
                    index = (ushort)(doLocoAnim.Value + 2);
                }

                operands[OperandConstants.Operand0] = (byte)index;
                operands[OperandConstants.Operand1] = (byte)(index >> 8);

                Boolset boolset2 = new Boolset(operands[OperandConstants.Operand2]);
                boolset2[OperandConstants.Bit1] = (comboLocoAnimScope.SelectedIndex == 0);
                boolset2[OperandConstants.Bit2] = (comboLocoAnimScope.SelectedIndex == 1);
                boolset2[OperandConstants.Bit3] = (comboLocoAnimScope.SelectedIndex == 2);
                operands[OperandConstants.Operand2] = boolset2;
            }

            return inst;
        }

        private void ShowStrChooser()
        {
            pjse.FileTable.Entry[] entryArray = comboLocoAnimScope.SelectedIndex < 0 ? (pjse.FileTable.Entry[])null : pjse.FileTable.GFT[MetaData.STRING_FILE, inst.Parent.GroupForScope(scopeArray[comboLocoAnimScope.SelectedIndex]), (ushort)pjse.GS.GlobalStr.LocoAnims];

            if (entryArray == null || entryArray.Length == 0)
            {
                MessageBox.Show(pjse.Localization.GetString("bow_noStrings") + " (" + pjse.Localization.GetString(scopeArray[comboLocoAnimScope.SelectedIndex].ToString()) + ")");
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

                    WizardHelpers.SetValue(textLocoAnimEntry, (ushort)strIndex, checkDecimal);
                    UpdateLocoAnimName();

                    this.internalchg = internalchg;
                }
            }
        }

        private void UpdateLocoAnimName()
        {
            try
            {
                WizardHelpers.SetName(lblLocoAnimName, toolTip, comboLocoAnimScope.SelectedIndex < 0 ? "" : ((pjse.BhavWiz)inst).readStr(scopeArray[comboLocoAnimScope.SelectedIndex], pjse.GS.GlobalStr.LocoAnims, doLocoAnim.Value, -1, pjse.Detail.ErrorNames));
            }
            catch (Exception)
            {
            }
        }

        private void UpdatePanelState()
        {
            panelLocoAnim.Visible = (comboAction.SelectedIndex == 2);
        }

        private void OnControlChanged(object sender, EventArgs e)
        {
            if (internalchg) return;

            UpdatePanelState();
        }

        private void OnLocoAnimControlChanged(object sender, EventArgs e)
        {
            if (internalchg) return;

            UpdateLocoAnimName();
        }

        private void OnLocoAnimPickerClicked(object sender, EventArgs e)
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
