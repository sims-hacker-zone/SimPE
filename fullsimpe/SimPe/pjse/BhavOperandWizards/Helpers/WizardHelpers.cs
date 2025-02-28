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
using System.Windows.Forms;

namespace whse.PrimitiveWizards
{
    public static class WizardHelpers
    {
        public static bool Hex32_IsValid(object sender)
        {
            try
            {
                int uint32 = (int)Convert.ToUInt32(((Control)sender).Text, 16);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static void SetGUID(byte[] op, int sub, TextBox textBox, Label label) => SetGUID((uint)((int)op[sub] | (int)op[sub + 1] << 8 | (int)op[sub + 2] << 16 | (int)op[sub + 3] << 24), textBox, label);

        public static void SetGUID(uint guid, TextBox textBox, Label label)
        {
            if (textBox != null) textBox.Text = "0x" + SimPe.Helper.HexString(guid);
            if (label != null) label.Text = pjse.BhavWiz.FormatGUID(true, guid);
        }

        public static void SetDropDownWidth(ComboBox comboBox)
        {
            int maxWidth = 0;

            foreach (var entry in comboBox.Items)
            {
                int width = TextRenderer.MeasureText(comboBox.GetItemText(entry), comboBox.Font).Width;

                if (width > maxWidth) maxWidth = width;
            }

            if (comboBox.Items.Count > comboBox.MaxDropDownItems)
            {
                maxWidth += SystemInformation.VerticalScrollBarWidth;
            }

            if (maxWidth > comboBox.Width)
            {
                comboBox.DropDownWidth = maxWidth;
            }
        }

        private static void OnDataPickerOpening(object sender, EventArgs e)
        {
            SetDropDownWidth((ComboBox)sender);
        }

        public static DataOwnerControl CreateDataOwnerControl(Instruction inst, ComboBox comboDataOwner, ComboBox comboDataPicker, TextBox textDataValue, CheckBox checkDecimal, CheckBox checkAttrPicker, ToolTip toolTip, byte dataOwner, byte dataLo)
        {
            DataOwnerControl doc = new DataOwnerControl((pjse.BhavWiz)inst, comboDataOwner, comboDataPicker, textDataValue, checkDecimal, checkAttrPicker, null, dataOwner, dataLo);

            return InitDOC(doc, comboDataOwner, comboDataPicker, toolTip);
        }

        public static DataOwnerControl CreateDataOwnerControl(Instruction inst, ComboBox comboDataOwner, ComboBox comboDataPicker, TextBox textDataValue, CheckBox checkDecimal, CheckBox checkAttrPicker, ToolTip toolTip, byte dataOwner, byte dataLo, byte dataHi)
        {
            DataOwnerControl doc = new DataOwnerControl((pjse.BhavWiz)inst, comboDataOwner, comboDataPicker, textDataValue, checkDecimal, checkAttrPicker, null, dataOwner, pjse.BhavWiz.ToShort(dataLo, dataHi));

            return InitDOC(doc, comboDataOwner, comboDataPicker, toolTip);
        }

        private static DataOwnerControl InitDOC(DataOwnerControl doc, ComboBox comboDataOwner, ComboBox comboDataPicker, ToolTip toolTip)
        {
            if (comboDataOwner != null)
            {
                SetDropDownWidth(comboDataOwner);
                comboDataPicker.DropDown += new EventHandler(OnDataPickerOpening);

                comboDataOwner.SelectedIndexChanged += new EventHandler(delegate (object sender, EventArgs e)
                {
                    toolTip.SetToolTip((ComboBox)sender, ((ComboBox)sender).Text);
                });

                toolTip.SetToolTip(comboDataOwner, comboDataOwner.Text);
            }
            else
            {
                SetDropDownWidth(comboDataPicker);
            }

            comboDataPicker.SelectedIndexChanged += new EventHandler(delegate (object sender, EventArgs e)
            {
                toolTip.SetToolTip((ComboBox)sender, ((ComboBox)sender).Text);
            });

            toolTip.SetToolTip(comboDataPicker, comboDataPicker.Text);

            return doc;
        }

        public static DataOwnerControl CreateDataControl(Instruction inst, TextBox textDataValue, CheckBox checkDecimal, ushort data)
        {
            DataOwnerControl doc = new DataOwnerControl((pjse.BhavWiz)inst, null, null, textDataValue, checkDecimal, null, null, DataOwner.Literal, data);

            return doc;
        }

        public static DataOwnerControl CreateDataControl(Instruction inst, TextBox textDataValue, CheckBox checkDecimal, byte dataLo, byte dataHi)
        {
            DataOwnerControl doc = new DataOwnerControl((pjse.BhavWiz)inst, null, null, textDataValue, checkDecimal, null, null, DataOwner.Literal, pjse.BhavWiz.ToShort(dataLo, dataHi));

            return doc;
        }

        public static DataOwnerControl CreateDataControl(Instruction inst, TextBox textDataValue, CheckBox checkDecimal, byte dataLo)
        {
            DataOwnerControl doc = new DataOwnerControl((pjse.BhavWiz)inst, null, null, textDataValue, checkDecimal, null, null, DataOwner.Literal, dataLo);

            return doc;
        }

        public static LinkLabel CreateLinkLabel(Label lblOriginal)
        {
            LinkLabel lblLink = new LinkLabel
            {
                AutoSize = lblOriginal.AutoSize,
                Location = lblOriginal.Location,
                Name = $"{lblOriginal.Name}Link",
                Size = lblOriginal.Size,
                TabIndex = lblOriginal.TabIndex,
                Text = lblOriginal.Text,
                TextAlign = lblOriginal.TextAlign
            };

            lblOriginal.Parent.Controls.Add(lblLink);
            lblOriginal.Visible = false;

            return lblLink;
        }

        public static void ComboSelectIndex(ComboBox combo, int value)
        {
            if (combo.Items.Count > 0)
            {
                if (value < combo.Items.Count)
                {
                    combo.SelectedIndex = value;
                }
                else
                {
                    combo.SelectedIndex = 0;
                }
            }
        }

        public static void SetValue(TextBox textBox, ushort value, CheckBox checkDecimal)
        {
            if (checkDecimal.Checked)
            {
                textBox.Text = value.ToString();
            }
            else
            {
                textBox.Text = "0x" + SimPe.Helper.HexString(value);
            }
        }

        public static void SetValue(TextBox textBox, byte value, CheckBox checkDecimal)
        {
            if (checkDecimal.Checked)
            {
                textBox.Text = value.ToString();
            }
            else
            {
                textBox.Text = "0x" + SimPe.Helper.HexString(value);
            }
        }

        public static void SetName(Label label, ToolTip toolTip, string value)
        {
            label.Text = value;
            toolTip.SetToolTip(label, value);
        }
    }
}
