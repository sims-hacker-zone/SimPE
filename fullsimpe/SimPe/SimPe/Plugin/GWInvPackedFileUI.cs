using System;
using System.Drawing;

using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	public partial class GWInvPackedFileUI
		: Windows.Forms.WrapperBaseControl,
			IPackedFileUI
	{
		protected new GWInvPackedFileWrapper Wrapper => base.Wrapper as GWInvPackedFileWrapper;
		public GWInvPackedFileWrapper TPFW => (GWInvPackedFileWrapper)Wrapper;

		#region WrapperBaseControl Member

		public GWInvPackedFileUI()
		{
			InitializeComponent();
		}

		protected override void RefreshGUI()
		{
			base.RefreshGUI();

			label1.Visible = false;
			label108.Visible = false;
			label111.Visible = false;
			label112.Visible = false;
			label113.Visible = false;
			label116.Visible = false;
			label117.Visible = false;
			label119.Visible = false;
			label120.Visible = false;
			label121.Visible = false;
			label122.Visible = false;
			label124.Visible = false;
			textBox1.Visible = false;
			this.BackgroundImageLocation = new Point(1240, 0);
			ushort epsrun = Wrapper.loweps;
			ushort hiprun = Wrapper.hieps;
			gwinvo.Text = Convert.ToString(Wrapper.Trunned);
			//textBox1.Text = Convert.ToString(Wrapper.novels);
			if (epsrun >= 32768)
			{
				epsrun -= 32768;
				this.checkBox16.Checked = true;
			}
			else
			{
				this.checkBox16.Checked = false;
			}

			if (epsrun >= 16384)
			{
				epsrun -= 16384;
				this.checkBox15.Checked = true;
			}
			else
			{
				this.checkBox15.Checked = false;
			}

			if (epsrun >= 8192)
			{
				epsrun -= 8192;
				this.checkBox14.Checked = true;
			}
			else
			{
				this.checkBox14.Checked = false;
			}

			if (epsrun >= 4096)
			{
				epsrun -= 4096;
				this.checkBox13.Checked = true;
			}
			else
			{
				this.checkBox13.Checked = false;
			}

			if (epsrun >= 2048)
			{
				epsrun -= 2048;
				this.checkBox12.Checked = true;
			}
			else
			{
				this.checkBox12.Checked = false;
			}

			if (epsrun >= 1024)
			{
				epsrun -= 1024;
				this.checkBox11.Checked = true;
			}
			else
			{
				this.checkBox11.Checked = false;
			}

			if (epsrun >= 512)
			{
				epsrun -= 512;
				this.checkBox10.Checked = true;
			}
			else
			{
				this.checkBox10.Checked = false;
			}

			if (epsrun >= 256)
			{
				epsrun -= 256;
				this.checkBox9.Checked = true;
			}
			else
			{
				this.checkBox9.Checked = false;
			}

			if (epsrun >= 128)
			{
				epsrun -= 128;
				this.checkBox8.Checked = true;
			}
			else
			{
				this.checkBox8.Checked = false;
			}

			if (epsrun >= 64)
			{
				epsrun -= 64;
				this.checkBox7.Checked = true;
			}
			else
			{
				this.checkBox7.Checked = false;
			}

			if (epsrun >= 32)
			{
				epsrun -= 32;
				this.checkBox6.Checked = true;
			}
			else
			{
				this.checkBox6.Checked = false;
			}

			if (epsrun >= 16)
			{
				epsrun -= 16;
				this.checkBox5.Checked = true;
			}
			else
			{
				this.checkBox5.Checked = false;
			}

			if (epsrun >= 8)
			{
				epsrun -= 8;
				this.checkBox4.Checked = true;
			}
			else
			{
				this.checkBox4.Checked = false;
			}

			if (epsrun >= 4)
			{
				epsrun -= 4;
				this.checkBox3.Checked = true;
			}
			else
			{
				this.checkBox3.Checked = false;
			}

			if (epsrun >= 2)
			{
				epsrun -= 2;
				this.checkBox2.Checked = true;
			}
			else
			{
				this.checkBox2.Checked = false;
			}

			if (epsrun >= 1)
			{
				this.checkBox1.Checked = true;
			}
			else
			{
				this.checkBox1.Checked = false;
			}

			if (hiprun >= 32768)
			{
				hiprun -= 32768;
			}

			if (hiprun >= 2)
			{
				hiprun -= 2;
				this.checkBox19.Checked = true;
			}
			else
			{
				this.checkBox19.Checked = false;
			}

			if (hiprun >= 1)
			{
				this.checkBox18.Checked = true;
			}
			else
			{
				this.checkBox18.Checked = false;
			}

			if (Wrapper.TipsList[2] == 1)
			{
				this.checkBox17.Checked = true;
			}
			else
			{
				this.checkBox17.Checked = false;
			}

			if (Wrapper.TipsList[3] == 1)
			{
				this.label3.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label3.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[4] == 1)
			{
				this.label4.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label4.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[5] == 1)
			{
				this.label5.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label5.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[6] == 1)
			{
				this.label6.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label6.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[7] == 1)
			{
				this.label7.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label7.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[8] == 1)
			{
				this.label8.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label8.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[9] == 1)
			{
				this.label9.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label9.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[10] == 1)
			{
				this.label10.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label10.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[11] == 1)
			{
				this.label11.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label11.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[12] == 1)
			{
				this.label12.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label12.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[13] == 1)
			{
				this.label13.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label13.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[14] == 1)
			{
				this.label14.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label14.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[15] == 1)
			{
				this.label15.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label15.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[16] == 1)
			{
				this.label16.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label16.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[17] == 1)
			{
				this.label17.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label17.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[18] == 1)
			{
				this.label18.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label18.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[19] == 1)
			{
				this.label19.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label19.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[20] == 1)
			{
				this.label20.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label20.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[21] == 1)
			{
				this.label21.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label21.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[22] == 1)
			{
				this.label22.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label22.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[23] == 1)
			{
				this.label23.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label23.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[24] == 1)
			{
				this.label24.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label24.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[25] == 1)
			{
				this.label25.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label25.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[26] == 1)
			{
				this.label26.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label26.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[27] == 1)
			{
				this.label27.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label27.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[28] == 1)
			{
				this.label28.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label28.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[29] == 1)
			{
				this.label29.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label29.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[30] == 1)
			{
				this.label30.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label30.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[31] == 1)
			{
				this.label31.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label31.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[32] == 1)
			{
				this.label32.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label32.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[33] == 1)
			{
				this.label33.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label33.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[34] == 1)
			{
				this.label34.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label34.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[35] == 1)
			{
				this.label35.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label35.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[36] == 1)
			{
				this.label36.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label36.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[37] == 1)
			{
				this.label37.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label37.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[38] == 1)
			{
				this.label38.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label38.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[39] == 1)
			{
				this.label39.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label39.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[40] == 1)
			{
				this.label40.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label40.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[41] == 1)
			{
				this.label41.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label41.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[42] == 1)
			{
				this.label42.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label42.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[43] == 1)
			{
				this.label43.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label43.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[44] == 1)
			{
				this.label44.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label44.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[45] == 1)
			{
				this.label45.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label45.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[46] == 1)
			{
				this.label46.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label46.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[47] == 1)
			{
				this.label47.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label47.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[48] == 1)
			{
				this.label48.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label48.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[49] == 1)
			{
				this.label49.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label49.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[50] == 1)
			{
				this.label50.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label50.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[51] == 1)
			{
				this.label51.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label51.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[52] == 1)
			{
				this.label52.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label52.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[53] == 1)
			{
				this.label53.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label53.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[54] == 1)
			{
				this.label54.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label54.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[55] == 1)
			{
				this.label55.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label55.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[56] == 1)
			{
				this.label56.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label56.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[57] == 1)
			{
				this.label57.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label57.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[58] == 1)
			{
				this.label58.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label58.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[59] == 1)
			{
				this.label59.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label59.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[60] == 1)
			{
				this.label60.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label60.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[61] == 1)
			{
				this.label61.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label61.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[62] == 1)
			{
				this.label62.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label62.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[63] == 1)
			{
				this.label63.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label63.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[64] == 1)
			{
				this.label64.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label64.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[65] == 1)
			{
				this.label65.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label65.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[66] == 1)
			{
				this.label66.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label66.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[67] == 1)
			{
				this.label67.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label67.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[68] == 1)
			{
				this.label68.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label68.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[69] == 1)
			{
				this.label69.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label69.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[70] == 1)
			{
				this.label70.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label70.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[71] == 1)
			{
				this.label71.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label71.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[72] == 1)
			{
				this.label72.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label72.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[73] == 1)
			{
				this.label73.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label73.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[74] == 1)
			{
				this.label74.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label74.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[75] == 1)
			{
				this.label75.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label75.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[76] == 1)
			{
				this.label76.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label76.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[77] == 1)
			{
				this.label77.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label77.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[78] == 1)
			{
				this.label78.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label78.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[79] == 1)
			{
				this.label79.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label79.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[80] == 1)
			{
				this.label80.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label80.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[81] == 1)
			{
				this.label81.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label81.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[82] == 1)
			{
				this.label82.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label82.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[83] == 1)
			{
				this.label83.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label83.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[84] == 1)
			{
				this.label84.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label84.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[85] == 1)
			{
				this.label85.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label85.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[86] == 1)
			{
				this.label86.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label86.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[87] == 1)
			{
				this.label87.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label87.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[88] == 1)
			{
				this.label88.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label88.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[89] == 1)
			{
				this.label89.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label89.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[90] == 1)
			{
				this.label90.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label90.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[91] == 1)
			{
				this.label91.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label91.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[92] == 1)
			{
				this.label92.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label92.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[93] == 1)
			{
				this.label93.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label93.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[94] == 1)
			{
				this.label94.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label94.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[95] == 1)
			{
				this.label95.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label95.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[96] == 1)
			{
				this.label96.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label96.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[97] == 1)
			{
				this.label97.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label97.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[98] == 1)
			{
				this.label98.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label98.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[99] == 1)
			{
				this.label99.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label99.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[100] == 1)
			{
				this.label100.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label100.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[101] == 1)
			{
				this.label101.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label101.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[102] == 1)
			{
				this.label102.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label102.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[103] == 1)
			{
				this.label103.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label103.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[104] == 1)
			{
				this.label104.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label104.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[105] == 1)
			{
				this.label105.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label105.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[106] == 1)
			{
				this.label106.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label106.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[107] == 1)
			{
				this.label107.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label107.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[108] == 1)
			{
				this.label108.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label108.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[109] == 1)
			{
				this.label109.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label109.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[110] == 1)
			{
				this.label110.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label110.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[111] == 1)
			{
				this.label111.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label111.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[112] == 1)
			{
				this.label112.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label112.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[113] == 1)
			{
				this.label113.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label113.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[114] == 1)
			{
				this.label114.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label114.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[115] == 1)
			{
				this.label115.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label115.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[116] == 1)
			{
				this.label116.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label116.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[117] == 1)
			{
				this.label117.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label117.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[118] == 1)
			{
				this.label118.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label118.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[119] == 1)
			{
				this.label119.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label119.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[120] == 1)
			{
				this.label120.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label120.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[121] == 1)
			{
				this.label121.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label121.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[122] == 1)
			{
				this.label122.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label122.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[123] == 1)
			{
				this.label123.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label123.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[124] == 1)
			{
				this.label124.ForeColor = SystemColors.ControlText;
			}
			else
			{
				this.label124.ForeColor = SystemColors.ControlDark;
			}
		}

		public override void OnCommit()
		{
			// base.OnCommit();
			// TPFW.SynchronizeUserData(true, false);
		}
		#endregion

		#region IPackedFileUI Member
		System.Windows.Forms.Control IPackedFileUI.GUIHandle => this;
		#endregion

		#region IDisposable Member

		void IDisposable.Dispose()
		{
			this.TPFW.Dispose();
		}
		#endregion
	}
}
