// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

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

			checkBox1.Checked = epsrun >= 1;

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

			checkBox18.Checked = hiprun >= 1;

			checkBox17.Checked = Wrapper.TipsList[2] == 1;

			label3.ForeColor = Wrapper.TipsList[3] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label4.ForeColor = Wrapper.TipsList[4] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label5.ForeColor = Wrapper.TipsList[5] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label6.ForeColor = Wrapper.TipsList[6] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label7.ForeColor = Wrapper.TipsList[7] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label8.ForeColor = Wrapper.TipsList[8] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label9.ForeColor = Wrapper.TipsList[9] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label10.ForeColor = Wrapper.TipsList[10] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label11.ForeColor = Wrapper.TipsList[11] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label12.ForeColor = Wrapper.TipsList[12] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label13.ForeColor = Wrapper.TipsList[13] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label14.ForeColor = Wrapper.TipsList[14] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label15.ForeColor = Wrapper.TipsList[15] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label16.ForeColor = Wrapper.TipsList[16] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label17.ForeColor = Wrapper.TipsList[17] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label18.ForeColor = Wrapper.TipsList[18] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label19.ForeColor = Wrapper.TipsList[19] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label20.ForeColor = Wrapper.TipsList[20] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label21.ForeColor = Wrapper.TipsList[21] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label22.ForeColor = Wrapper.TipsList[22] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label23.ForeColor = Wrapper.TipsList[23] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label24.ForeColor = Wrapper.TipsList[24] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label25.ForeColor = Wrapper.TipsList[25] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label26.ForeColor = Wrapper.TipsList[26] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label27.ForeColor = Wrapper.TipsList[27] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label28.ForeColor = Wrapper.TipsList[28] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label29.ForeColor = Wrapper.TipsList[29] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label30.ForeColor = Wrapper.TipsList[30] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label31.ForeColor = Wrapper.TipsList[31] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label32.ForeColor = Wrapper.TipsList[32] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label33.ForeColor = Wrapper.TipsList[33] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label34.ForeColor = Wrapper.TipsList[34] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label35.ForeColor = Wrapper.TipsList[35] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label36.ForeColor = Wrapper.TipsList[36] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label37.ForeColor = Wrapper.TipsList[37] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label38.ForeColor = Wrapper.TipsList[38] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label39.ForeColor = Wrapper.TipsList[39] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label40.ForeColor = Wrapper.TipsList[40] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label41.ForeColor = Wrapper.TipsList[41] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label42.ForeColor = Wrapper.TipsList[42] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label43.ForeColor = Wrapper.TipsList[43] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label44.ForeColor = Wrapper.TipsList[44] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label45.ForeColor = Wrapper.TipsList[45] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label46.ForeColor = Wrapper.TipsList[46] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label47.ForeColor = Wrapper.TipsList[47] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label48.ForeColor = Wrapper.TipsList[48] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label49.ForeColor = Wrapper.TipsList[49] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label50.ForeColor = Wrapper.TipsList[50] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label51.ForeColor = Wrapper.TipsList[51] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label52.ForeColor = Wrapper.TipsList[52] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label53.ForeColor = Wrapper.TipsList[53] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label54.ForeColor = Wrapper.TipsList[54] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label55.ForeColor = Wrapper.TipsList[55] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label56.ForeColor = Wrapper.TipsList[56] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label57.ForeColor = Wrapper.TipsList[57] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label58.ForeColor = Wrapper.TipsList[58] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label59.ForeColor = Wrapper.TipsList[59] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label60.ForeColor = Wrapper.TipsList[60] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label61.ForeColor = Wrapper.TipsList[61] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label62.ForeColor = Wrapper.TipsList[62] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label63.ForeColor = Wrapper.TipsList[63] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label64.ForeColor = Wrapper.TipsList[64] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label65.ForeColor = Wrapper.TipsList[65] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label66.ForeColor = Wrapper.TipsList[66] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label67.ForeColor = Wrapper.TipsList[67] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label68.ForeColor = Wrapper.TipsList[68] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label69.ForeColor = Wrapper.TipsList[69] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label70.ForeColor = Wrapper.TipsList[70] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label71.ForeColor = Wrapper.TipsList[71] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label72.ForeColor = Wrapper.TipsList[72] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label73.ForeColor = Wrapper.TipsList[73] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label74.ForeColor = Wrapper.TipsList[74] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label75.ForeColor = Wrapper.TipsList[75] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label76.ForeColor = Wrapper.TipsList[76] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label77.ForeColor = Wrapper.TipsList[77] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label78.ForeColor = Wrapper.TipsList[78] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label79.ForeColor = Wrapper.TipsList[79] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label80.ForeColor = Wrapper.TipsList[80] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label81.ForeColor = Wrapper.TipsList[81] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label82.ForeColor = Wrapper.TipsList[82] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label83.ForeColor = Wrapper.TipsList[83] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label84.ForeColor = Wrapper.TipsList[84] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label85.ForeColor = Wrapper.TipsList[85] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label86.ForeColor = Wrapper.TipsList[86] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label87.ForeColor = Wrapper.TipsList[87] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label88.ForeColor = Wrapper.TipsList[88] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label89.ForeColor = Wrapper.TipsList[89] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label90.ForeColor = Wrapper.TipsList[90] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label91.ForeColor = Wrapper.TipsList[91] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label92.ForeColor = Wrapper.TipsList[92] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label93.ForeColor = Wrapper.TipsList[93] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label94.ForeColor = Wrapper.TipsList[94] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label95.ForeColor = Wrapper.TipsList[95] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label96.ForeColor = Wrapper.TipsList[96] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label97.ForeColor = Wrapper.TipsList[97] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label98.ForeColor = Wrapper.TipsList[98] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label99.ForeColor = Wrapper.TipsList[99] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label100.ForeColor = Wrapper.TipsList[100] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label101.ForeColor = Wrapper.TipsList[101] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label102.ForeColor = Wrapper.TipsList[102] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label103.ForeColor = Wrapper.TipsList[103] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label104.ForeColor = Wrapper.TipsList[104] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label105.ForeColor = Wrapper.TipsList[105] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label106.ForeColor = Wrapper.TipsList[106] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label107.ForeColor = Wrapper.TipsList[107] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label108.ForeColor = Wrapper.TipsList[108] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label109.ForeColor = Wrapper.TipsList[109] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label110.ForeColor = Wrapper.TipsList[110] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label111.ForeColor = Wrapper.TipsList[111] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label112.ForeColor = Wrapper.TipsList[112] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label113.ForeColor = Wrapper.TipsList[113] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label114.ForeColor = Wrapper.TipsList[114] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label115.ForeColor = Wrapper.TipsList[115] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label116.ForeColor = Wrapper.TipsList[116] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label117.ForeColor = Wrapper.TipsList[117] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label118.ForeColor = Wrapper.TipsList[118] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label119.ForeColor = Wrapper.TipsList[119] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label120.ForeColor = Wrapper.TipsList[120] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label121.ForeColor = Wrapper.TipsList[121] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label122.ForeColor = Wrapper.TipsList[122] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label123.ForeColor = Wrapper.TipsList[123] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;

			label124.ForeColor = Wrapper.TipsList[124] == 1 ? SystemColors.ControlText : SystemColors.ControlDark;
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
