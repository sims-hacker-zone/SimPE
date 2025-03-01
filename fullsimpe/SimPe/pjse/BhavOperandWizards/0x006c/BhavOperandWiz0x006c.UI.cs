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
 * 0x006C - Animate Stop
 * 
 * See https://modthesims.info/wiki.php?title=0x006C
 */
namespace whse.PrimitiveWizards.Wiz0x006c
{
    public partial class UI : UserControl, pjse.iBhavOperandWizForm
    {
        private Instruction inst;

        private DataOwnerControl doObject, doAnimRes, doAnimEntryLiteral, doAnimEntryParam;

        private bool internalchg;

        public UI()
        {
            InitializeComponent();
        }

        public Panel WizPanel => this.panelMain;

        private bool IsAnim(ushort i)
        {
            try
            {
                return IsAnim((pjse.GS.GlobalStr)i);
            }
            catch
            {
            }
            return false;
        }

        private bool IsAnim(pjse.GS.GlobalStr g) => IsAnim(g.ToString());

        private bool IsAnim(string s) => s.EndsWith("Anims");

        private pjse.Scope AnimScope() => (doAnimRes.Value != 128) ? pjse.Scope.Private : pjse.Scope.Global;

        private pjse.GS.GlobalStr AnimInstance()
        {
            if (doAnimRes.Value == 128)
            {
                return pjse.GS.GlobalStr.AdultAnims;
            }
            else
            {
                return IsAnim(doAnimRes.Value) ? (pjse.GS.GlobalStr)doAnimRes.Value : pjse.GS.GlobalStr.ObjectAnims;
            }
        }

        public void Execute(Instruction inst)
        {
            this.inst = inst;

            wrappedByteArray operands = inst.Operands;
            wrappedByteArray reserved1 = inst.Reserved1;

            Boolset boolset2 = new Boolset(operands[OperandConstants.Operand2]);

            internalchg = true;

            doAnimEntryParam = WizardHelpers.CreateDataOwnerControl(inst, null, comboAnimEntryParam, textAnimEntryParam, checkDecimal, checkAttrPicker, toolTip, DataOwner.Parameter, operands[OperandConstants.Operand0], operands[OperandConstants.Operand1]);
            doAnimEntryLiteral = WizardHelpers.CreateDataControl(inst, textAnimEntryLiteral, checkDecimal, operands[OperandConstants.Operand0], operands[OperandConstants.Operand1]);
            doAnimEntryLiteral.DataOwnerControlChanged += new EventHandler(OnAnimEntryChanged);

            comboFlipFlag.SelectedIndex = (boolset2[OperandConstants.Bit4] ? 2 : (boolset2[OperandConstants.Bit1] ? 1 : 0));
            checkBlendOut.Checked = boolset2[OperandConstants.Bit2];
            comboAnimLiteralOrParam.SelectedIndex = (boolset2[OperandConstants.Bit3] ? 1 : 0);
            checkShortBlendOut.Checked = boolset2[OperandConstants.Bit6];
            checkNormalAndFlipped.Checked = boolset2[OperandConstants.Bit7];

            doObject = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner1, comboDataPicker1, textDataValue1, checkDecimal, checkAttrPicker, toolTip, operands[OperandConstants.Operand3], operands[OperandConstants.Operand4], operands[OperandConstants.Operand5]);

            doAnimRes = WizardHelpers.CreateDataControl(inst, textAnimationRes, checkDecimal, operands[OperandConstants.Operand6]);
            WizardHelpers.SetDropDownWidth(comboAnimationRes);

            WizardHelpers.ComboSelectIndex(comboAnimationType, operands[OperandConstants.Operand7]);

            WizardHelpers.ComboSelectIndex(comboPriority, reserved1[OperandConstants.Operand8]);

            internalchg = false;

            // Do these manually, as we want them after the Data Owner control handlers
            textAnimationRes.TextChanged += new System.EventHandler(OnAnimResChanged);

            UpdateComboAnimationRes();
            UpdateAnimationNames();
            UpdatePanelState();
        }

        public Instruction Write(Instruction inst)
        {
            if (inst != null)
            {
                wrappedByteArray operands = inst.Operands;
                wrappedByteArray reserved1 = inst.Reserved1;

                ushort animValue = (comboAnimLiteralOrParam.SelectedIndex == 0) ? doAnimEntryLiteral.Value : doAnimEntryParam.Value;
                operands[OperandConstants.Operand0] = (byte)animValue;
                operands[OperandConstants.Operand1] = (byte)(animValue >> 8);

                Boolset boolset2 = new Boolset(operands[OperandConstants.Operand2]);
                boolset2[OperandConstants.Bit1] = (comboFlipFlag.SelectedIndex == 1);
                boolset2[OperandConstants.Bit2] = checkBlendOut.Checked;
                boolset2[OperandConstants.Bit3] = (comboAnimLiteralOrParam.SelectedIndex == 1);
                boolset2[OperandConstants.Bit4] = (comboFlipFlag.SelectedIndex == 2);
                boolset2[OperandConstants.Bit6] = checkShortBlendOut.Checked;
                boolset2[OperandConstants.Bit7] = checkNormalAndFlipped.Checked;
                operands[OperandConstants.Operand2] = boolset2;

                operands[OperandConstants.Operand3] = doObject.DataOwner;
                operands[OperandConstants.Operand4] = (byte)doObject.Value;
                operands[OperandConstants.Operand5] = (byte)(doObject.Value >> 8);

                operands[OperandConstants.Operand6] = (byte)doAnimRes.Value;

                operands[OperandConstants.Operand7] = (byte)comboAnimationType.SelectedIndex;

                reserved1[OperandConstants.Operand8] = (byte)comboPriority.SelectedIndex;
            }

            return inst;
        }

        private void ShowStrChooser()
        {
            pjse.FileTable.Entry[] entryArray = pjse.FileTable.GFT[MetaData.STRING_FILE, inst.Parent.GroupForScope(AnimScope()), (uint)AnimInstance()];

            if (entryArray == null || entryArray.Length == 0)
            {
                MessageBox.Show(pjse.Localization.GetString("bow_noStrings") + " (" + pjse.Localization.GetString(AnimScope().ToString()) + ")");
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

                    WizardHelpers.SetValue(textAnimEntryLiteral, (ushort)strIndex, checkDecimal);
                    UpdateAnimationNames();

                    this.internalchg = internalchg;
                }
            }
        }

        private void UpdateComboAnimationRes()
        {
            comboAnimationRes.SelectedIndex = comboAnimationRes.Items.IndexOf(((pjse.GS.GlobalStr)doAnimRes.Value).ToString());
        }

        private void UpdateAnimationNames()
        {
            lblAnimationResName.Text = comboAnimationRes.SelectedIndex >= 0 ? comboAnimationRes.SelectedItem.ToString() : "---";

            try
            {
                WizardHelpers.SetName(lblAnimationEntryName, toolTip, ((pjse.BhavWiz)inst).readStr(AnimScope(), AnimInstance(), doAnimEntryLiteral.Value, -1, pjse.Detail.ErrorNames));
            }
            catch (Exception)
            {
            }
        }

        private void UpdatePanelState()
        {
            panelAnimation.Visible = (comboAnimationType.SelectedIndex == 0);

            panelAnimEntryLiteral.Visible = (comboAnimLiteralOrParam.SelectedIndex == 0);
            panelAnimEntryParam.Visible = (comboAnimLiteralOrParam.SelectedIndex == 1);

            btnAnimationPicker.Visible = lblAnimationEntryName.Visible = (comboAnimLiteralOrParam.SelectedIndex == 0);
        }

        private void OnAnimResChanged(object sender, EventArgs e)
        {
            if (internalchg) return;

            internalchg = true;

            try
            {
                if (sender == comboAnimationRes)
                {
                    if (comboAnimationRes.SelectedIndex >= 0)
                    {
                        textAnimationRes.Text = "0x" + SimPe.Helper.HexString((byte)(pjse.GS.GlobalStr)Enum.Parse(typeof(pjse.GS.GlobalStr), comboAnimationRes.SelectedItem.ToString()));
                    }
                }
                else if (sender == textAnimationRes)
                {
                    UpdateComboAnimationRes();
                }
            }
            finally
            {
                UpdateAnimationNames();
            }

            internalchg = false;
        }

        private void OnAnimEntryChanged(object sender, EventArgs e)
        {
            if (internalchg) return;

            internalchg = true;

            try
            {
                UpdateComboAnimationRes();
            }
            finally
            {
                internalchg = false;

                UpdateAnimationNames();
            }
        }

        private void OnAnimPickerClicked(object sender, EventArgs e)
        {
            ShowStrChooser();
        }

        private void OnControlChanged(object sender, EventArgs e)
        {
            if (internalchg) return;

            UpdateAnimationNames();
            UpdatePanelState();
        }
    }
}
