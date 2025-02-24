using System;
using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	/// <summary>
	/// This class is used to fill the UI for this FileType with Data
	/// </summary>
    public partial class WinfoPackedFileUI : SimPe.Windows.Forms.WrapperBaseControl, IPackedFileUI
    {
        protected new WinfoPackedFileWrapper Wrapper
        {
            get { return base.Wrapper as WinfoPackedFileWrapper; }
        }
        public WinfoPackedFileWrapper TPFW
        {
            get { return (WinfoPackedFileWrapper)Wrapper; }
        }

        int WiTemperC;
        int WiTemperF;
        uint WiMisc;

        #region WrapperBaseControl Member

        public WinfoPackedFileUI()
		{
			InitializeComponent();
		}

        protected override void RefreshGUI()
        {
            base.RefreshGUI();

            textBox1.Text = Wrapper.Weaname;
            wiversion.Text = "0x" + Helper.HexString(Wrapper.weaversion);
            if (Wrapper.weaversion != 3)
            {
                this.CanCommit = false;
                this.textBox1.ForeColor = System.Drawing.Color.DarkRed;
                groupBox1.Visible = false;
            }
            else
            {
                this.CanCommit = true;
                this.textBox1.ForeColor = System.Drawing.Color.Black;
                groupBox1.Visible = true;
                WiTemperC = (Wrapper.wetemperature / 3) + 13;
                WiTemperF = (Wrapper.wetemperature * 6) / 10 + 55;
                witemperatelbl.Text = "Temperature (" + Convert.ToString(WiTemperC) + "�c ~ " + Convert.ToString(WiTemperF) + "�f)";
                wiunk2.Text = "0x" + Helper.HexString(Wrapper.unkn2);
                wiunk3.Text = "0x" + Helper.HexString(Wrapper.unkn3);
                wiunk4.Text = "0x" + Helper.HexString(Wrapper.unkn4);
                wiunk5.Text = "0x" + Helper.HexString(Wrapper.unkn5);
                wiunk6.Text = "0x" + Helper.HexString(Wrapper.unkn6);
                wiunk7.Text = "0x" + Helper.HexString(Wrapper.unkn7);
                wiunk8.Text = "0x" + Helper.HexString(Wrapper.unkn8);
                wiunk9.Text = "0x" + Helper.HexString(Wrapper.unkn9);
                wiunk10.Text = "0x" + Helper.HexString(Wrapper.unkn0);
                witemperate.Text = "0x" + Helper.HexString(Wrapper.wetemperature);
            }
        }

        public override void OnCommit()
        {
            base.OnCommit();
            TPFW.SynchronizeUserData(true, false);
        }
        #endregion

        #region IPackedFileUI Member
        System.Windows.Forms.Control IPackedFileUI.GUIHandle
        {
            get { return this; }
        }
        #endregion

        #region IDisposable Member

        void IDisposable.Dispose()
        {
            this.TPFW.Dispose();
        }
        #endregion

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Wrapper.Weaname = textBox1.Text;
        }

        private void wiunk2_TextChanged(object sender, EventArgs e)
        {
            WiMisc = Convert.ToUInt32(wiunk2.Text, 16);
            if (WiMisc >= 0 && WiMisc < 4)
            {
                Wrapper.unkn2 = WiMisc;
                wiunk2.ForeColor = System.Drawing.SystemColors.WindowText;
                WiMisc++; if (WiMisc > 3) WiMisc = 0;
                Wrapper.unkn1 = WiMisc;
            }
            else wiunk2.ForeColor = System.Drawing.Color.DarkRed;
        }

        private void wiunk3_TextChanged(object sender, EventArgs e)
        {
            Wrapper.unkn3 = Convert.ToUInt32(wiunk3.Text, 16);
        }

        private void wiunk4_TextChanged(object sender, EventArgs e)
        {
            Wrapper.unkn4 = Convert.ToUInt32(wiunk4.Text, 16);
        }

        private void wiunk5_TextChanged(object sender, EventArgs e)
        {
            WiMisc = Convert.ToUInt32(wiunk5.Text, 16);
            if (WiMisc >= 0 && WiMisc < 4)
            {
                Wrapper.unkn5 = WiMisc;
                wiunk5.ForeColor = System.Drawing.SystemColors.WindowText;
            }
            else wiunk5.ForeColor = System.Drawing.Color.DarkRed;
        }

        private void wiunk6_TextChanged(object sender, EventArgs e)
        {
            WiMisc = Convert.ToUInt32(wiunk6.Text, 16);
            if (WiMisc >= 0 && WiMisc < 4)
            {
                Wrapper.unkn6 = WiMisc;
                wiunk6.ForeColor = System.Drawing.SystemColors.WindowText;
            }
            else wiunk6.ForeColor = System.Drawing.Color.DarkRed;
        }

        private void wiunk7_TextChanged(object sender, EventArgs e)
        {
            WiMisc = Convert.ToUInt32(wiunk7.Text, 16);
            if (WiMisc >= 0 && WiMisc < 3)
            {
                Wrapper.unkn7 = WiMisc;
                wiunk7.ForeColor = System.Drawing.SystemColors.WindowText;
            }
            else wiunk7.ForeColor = System.Drawing.Color.DarkRed;
        }

        private void wiunk8_TextChanged(object sender, EventArgs e)
        {
            WiMisc = Convert.ToUInt32(wiunk8.Text, 16);
            if (WiMisc >= 0 && WiMisc < 4)
            {
                Wrapper.unkn8 = WiMisc;
                wiunk8.ForeColor = System.Drawing.SystemColors.WindowText;
            }
            else wiunk8.ForeColor = System.Drawing.Color.DarkRed;
        }

        private void wiunk9_TextChanged(object sender, EventArgs e)
        {
            WiMisc = Convert.ToUInt32(wiunk9.Text, 16);
            if (WiMisc == 0 || WiMisc == 1)
            {
                Wrapper.unkn9 = Convert.ToUInt32(wiunk9.Text, 16);
                wiunk9.ForeColor = System.Drawing.SystemColors.WindowText;
            }
            else wiunk9.ForeColor = System.Drawing.Color.DarkRed;
        }

        private void wiunk10_TextChanged(object sender, EventArgs e)
        {
            WiMisc = Convert.ToUInt32(wiunk10.Text, 16);
            if (WiMisc == 0 || WiMisc == 1)
            {
                Wrapper.unkn0 = Convert.ToUInt32(wiunk10.Text, 16);
                wiunk10.ForeColor = System.Drawing.SystemColors.WindowText;
            }
            else wiunk10.ForeColor = System.Drawing.Color.DarkRed;
        }

        private void witemperate_TextChanged(object sender, EventArgs e)
        {
            Wrapper.wetemperature = Convert.ToInt32(witemperate.Text, 16);
            WiTemperC = (Wrapper.wetemperature / 3) + 13;
            WiTemperF = (Wrapper.wetemperature * 6) / 10 + 55;
            witemperatelbl.Text = "Temperature (" + Convert.ToString(WiTemperC) + "�c ~ " + Convert.ToString(WiTemperF) + "�f)";
        }
    }
}
