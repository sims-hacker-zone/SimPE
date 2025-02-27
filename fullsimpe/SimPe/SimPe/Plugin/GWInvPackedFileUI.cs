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
		public GWInvPackedFileWrapper TPFW => Wrapper;

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
			BackgroundImageLocation = new Point(1240, 0);
			ushort epsrun = Wrapper.loweps;
			ushort hiprun = Wrapper.hieps;
			gwinvo.Text = Convert.ToString(Wrapper.Trunned);
			//textBox1.Text = Convert.ToString(Wrapper.novels);
			if (epsrun >= 32768)
			{
				epsrun -= 32768;
				checkBox16.Checked = true;
			}
			else
			{
				checkBox16.Checked = false;
			}

			if (epsrun >= 16384)
			{
				epsrun -= 16384;
				checkBox15.Checked = true;
			}
			else
			{
				checkBox15.Checked = false;
			}

			if (epsrun >= 8192)
			{
				epsrun -= 8192;
				checkBox14.Checked = true;
			}
			else
			{
				checkBox14.Checked = false;
			}

			if (epsrun >= 4096)
			{
				epsrun -= 4096;
				checkBox13.Checked = true;
			}
			else
			{
				checkBox13.Checked = false;
			}

			if (epsrun >= 2048)
			{
				epsrun -= 2048;
				checkBox12.Checked = true;
			}
			else
			{
				checkBox12.Checked = false;
			}

			if (epsrun >= 1024)
			{
				epsrun -= 1024;
				checkBox11.Checked = true;
			}
			else
			{
				checkBox11.Checked = false;
			}

			if (epsrun >= 512)
			{
				epsrun -= 512;
				checkBox10.Checked = true;
			}
			else
			{
				checkBox10.Checked = false;
			}

			if (epsrun >= 256)
			{
				epsrun -= 256;
				checkBox9.Checked = true;
			}
			else
			{
				checkBox9.Checked = false;
			}

			if (epsrun >= 128)
			{
				epsrun -= 128;
				checkBox8.Checked = true;
			}
			else
			{
				checkBox8.Checked = false;
			}

			if (epsrun >= 64)
			{
				epsrun -= 64;
				checkBox7.Checked = true;
			}
			else
			{
				checkBox7.Checked = false;
			}

			if (epsrun >= 32)
			{
				epsrun -= 32;
				checkBox6.Checked = true;
			}
			else
			{
				checkBox6.Checked = false;
			}

			if (epsrun >= 16)
			{
				epsrun -= 16;
				checkBox5.Checked = true;
			}
			else
			{
				checkBox5.Checked = false;
			}

			if (epsrun >= 8)
			{
				epsrun -= 8;
				checkBox4.Checked = true;
			}
			else
			{
				checkBox4.Checked = false;
			}

			if (epsrun >= 4)
			{
				epsrun -= 4;
				checkBox3.Checked = true;
			}
			else
			{
				checkBox3.Checked = false;
			}

			if (epsrun >= 2)
			{
				epsrun -= 2;
				checkBox2.Checked = true;
			}
			else
			{
				checkBox2.Checked = false;
			}

			if (epsrun >= 1)
			{
				checkBox1.Checked = true;
			}
			else
			{
				checkBox1.Checked = false;
			}

			if (hiprun >= 32768)
			{
				hiprun -= 32768;
			}

			if (hiprun >= 2)
			{
				hiprun -= 2;
				checkBox19.Checked = true;
			}
			else
			{
				checkBox19.Checked = false;
			}

			if (hiprun >= 1)
			{
				checkBox18.Checked = true;
			}
			else
			{
				checkBox18.Checked = false;
			}

			if (Wrapper.TipsList[2] == 1)
			{
				checkBox17.Checked = true;
			}
			else
			{
				checkBox17.Checked = false;
			}

			if (Wrapper.TipsList[3] == 1)
			{
				label3.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label3.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[4] == 1)
			{
				label4.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label4.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[5] == 1)
			{
				label5.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label5.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[6] == 1)
			{
				label6.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label6.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[7] == 1)
			{
				label7.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label7.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[8] == 1)
			{
				label8.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label8.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[9] == 1)
			{
				label9.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label9.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[10] == 1)
			{
				label10.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label10.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[11] == 1)
			{
				label11.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label11.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[12] == 1)
			{
				label12.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label12.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[13] == 1)
			{
				label13.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label13.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[14] == 1)
			{
				label14.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label14.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[15] == 1)
			{
				label15.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label15.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[16] == 1)
			{
				label16.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label16.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[17] == 1)
			{
				label17.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label17.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[18] == 1)
			{
				label18.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label18.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[19] == 1)
			{
				label19.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label19.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[20] == 1)
			{
				label20.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label20.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[21] == 1)
			{
				label21.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label21.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[22] == 1)
			{
				label22.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label22.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[23] == 1)
			{
				label23.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label23.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[24] == 1)
			{
				label24.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label24.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[25] == 1)
			{
				label25.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label25.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[26] == 1)
			{
				label26.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label26.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[27] == 1)
			{
				label27.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label27.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[28] == 1)
			{
				label28.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label28.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[29] == 1)
			{
				label29.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label29.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[30] == 1)
			{
				label30.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label30.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[31] == 1)
			{
				label31.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label31.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[32] == 1)
			{
				label32.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label32.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[33] == 1)
			{
				label33.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label33.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[34] == 1)
			{
				label34.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label34.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[35] == 1)
			{
				label35.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label35.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[36] == 1)
			{
				label36.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label36.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[37] == 1)
			{
				label37.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label37.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[38] == 1)
			{
				label38.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label38.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[39] == 1)
			{
				label39.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label39.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[40] == 1)
			{
				label40.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label40.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[41] == 1)
			{
				label41.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label41.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[42] == 1)
			{
				label42.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label42.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[43] == 1)
			{
				label43.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label43.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[44] == 1)
			{
				label44.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label44.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[45] == 1)
			{
				label45.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label45.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[46] == 1)
			{
				label46.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label46.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[47] == 1)
			{
				label47.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label47.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[48] == 1)
			{
				label48.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label48.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[49] == 1)
			{
				label49.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label49.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[50] == 1)
			{
				label50.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label50.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[51] == 1)
			{
				label51.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label51.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[52] == 1)
			{
				label52.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label52.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[53] == 1)
			{
				label53.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label53.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[54] == 1)
			{
				label54.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label54.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[55] == 1)
			{
				label55.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label55.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[56] == 1)
			{
				label56.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label56.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[57] == 1)
			{
				label57.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label57.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[58] == 1)
			{
				label58.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label58.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[59] == 1)
			{
				label59.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label59.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[60] == 1)
			{
				label60.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label60.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[61] == 1)
			{
				label61.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label61.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[62] == 1)
			{
				label62.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label62.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[63] == 1)
			{
				label63.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label63.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[64] == 1)
			{
				label64.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label64.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[65] == 1)
			{
				label65.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label65.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[66] == 1)
			{
				label66.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label66.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[67] == 1)
			{
				label67.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label67.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[68] == 1)
			{
				label68.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label68.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[69] == 1)
			{
				label69.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label69.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[70] == 1)
			{
				label70.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label70.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[71] == 1)
			{
				label71.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label71.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[72] == 1)
			{
				label72.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label72.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[73] == 1)
			{
				label73.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label73.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[74] == 1)
			{
				label74.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label74.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[75] == 1)
			{
				label75.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label75.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[76] == 1)
			{
				label76.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label76.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[77] == 1)
			{
				label77.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label77.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[78] == 1)
			{
				label78.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label78.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[79] == 1)
			{
				label79.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label79.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[80] == 1)
			{
				label80.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label80.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[81] == 1)
			{
				label81.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label81.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[82] == 1)
			{
				label82.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label82.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[83] == 1)
			{
				label83.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label83.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[84] == 1)
			{
				label84.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label84.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[85] == 1)
			{
				label85.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label85.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[86] == 1)
			{
				label86.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label86.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[87] == 1)
			{
				label87.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label87.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[88] == 1)
			{
				label88.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label88.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[89] == 1)
			{
				label89.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label89.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[90] == 1)
			{
				label90.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label90.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[91] == 1)
			{
				label91.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label91.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[92] == 1)
			{
				label92.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label92.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[93] == 1)
			{
				label93.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label93.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[94] == 1)
			{
				label94.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label94.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[95] == 1)
			{
				label95.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label95.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[96] == 1)
			{
				label96.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label96.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[97] == 1)
			{
				label97.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label97.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[98] == 1)
			{
				label98.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label98.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[99] == 1)
			{
				label99.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label99.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[100] == 1)
			{
				label100.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label100.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[101] == 1)
			{
				label101.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label101.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[102] == 1)
			{
				label102.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label102.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[103] == 1)
			{
				label103.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label103.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[104] == 1)
			{
				label104.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label104.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[105] == 1)
			{
				label105.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label105.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[106] == 1)
			{
				label106.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label106.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[107] == 1)
			{
				label107.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label107.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[108] == 1)
			{
				label108.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label108.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[109] == 1)
			{
				label109.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label109.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[110] == 1)
			{
				label110.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label110.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[111] == 1)
			{
				label111.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label111.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[112] == 1)
			{
				label112.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label112.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[113] == 1)
			{
				label113.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label113.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[114] == 1)
			{
				label114.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label114.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[115] == 1)
			{
				label115.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label115.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[116] == 1)
			{
				label116.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label116.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[117] == 1)
			{
				label117.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label117.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[118] == 1)
			{
				label118.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label118.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[119] == 1)
			{
				label119.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label119.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[120] == 1)
			{
				label120.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label120.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[121] == 1)
			{
				label121.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label121.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[122] == 1)
			{
				label122.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label122.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[123] == 1)
			{
				label123.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label123.ForeColor = SystemColors.ControlDark;
			}

			if (Wrapper.TipsList[124] == 1)
			{
				label124.ForeColor = SystemColors.ControlText;
			}
			else
			{
				label124.ForeColor = SystemColors.ControlDark;
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
			TPFW.Dispose();
		}
		#endregion
	}
}
