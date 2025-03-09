// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Fcns
{
	public partial class FcnsUI
		: Windows.Forms.WrapperBaseControl,
			IPackedFileUI
	{
		protected new Fcns Wrapper => base.Wrapper as Fcns;
		public Fcns TPFW => Wrapper;

		#region WrapperBaseControl Member

		public FcnsUI()
		{
			InitializeComponent();
		}

		protected override void RefreshGUI()
		{
			base.RefreshGUI();

			ushort numper = Wrapper.Quanty;
			if (numper > 0)
			{
				panel2.Visible = true;
				{
					label1.Text = Wrapper.strung[0];
					textBox1.Text = Wrapper.valwe[0].ToString();
					commnt1.Text = Wrapper.comnt[0];
					label1.Visible = textBox1.Visible = commnt1.Visible = true;
				}
				if (numper > 1)
				{
					label3.Text = Wrapper.strung[1];
					textBox3.Text = Wrapper.valwe[1].ToString();
					commnt3.Text = Wrapper.comnt[1];
					label3.Visible = textBox3.Visible = commnt3.Visible = true;
				}
				else
				{
					label3.Visible = textBox3.Visible = commnt3.Visible = false;
				}
				if (numper > 2)
				{
					label4.Text = Wrapper.strung[2];
					textBox4.Text = Wrapper.valwe[2].ToString();
					commnt4.Text = Wrapper.comnt[2];
					label4.Visible = textBox4.Visible = commnt4.Visible = true;
				}
				else
				{
					label4.Visible = textBox4.Visible = commnt4.Visible = false;
				}
				if (numper > 3)
				{
					label5.Text = Wrapper.strung[3];
					textBox5.Text = Wrapper.valwe[3].ToString();
					commnt5.Text = Wrapper.comnt[3];
					label5.Visible = textBox5.Visible = commnt5.Visible = true;
				}
				else
				{
					label5.Visible = textBox5.Visible = commnt5.Visible = false;
				}
				if (numper > 4)
				{
					label6.Text = Wrapper.strung[4];
					textBox6.Text = Wrapper.valwe[4].ToString();
					commnt6.Text = Wrapper.comnt[4];
					label6.Visible = textBox6.Visible = commnt6.Visible = true;
				}
				else
				{
					label6.Visible = textBox6.Visible = commnt6.Visible = false;
				}
				if (numper > 5)
				{
					label7.Text = Wrapper.strung[5];
					textBox7.Text = Wrapper.valwe[5].ToString();
					commnt7.Text = Wrapper.comnt[5];
					label7.Visible = textBox7.Visible = commnt7.Visible = true;
				}
				else
				{
					label7.Visible = textBox7.Visible = commnt7.Visible = false;
				}
				if (numper > 6)
				{
					label8.Text = Wrapper.strung[6];
					textBox8.Text = Wrapper.valwe[6].ToString();
					commnt8.Text = Wrapper.comnt[6];
					label8.Visible = textBox8.Visible = commnt8.Visible = true;
				}
				else
				{
					label8.Visible = textBox8.Visible = commnt8.Visible = false;
				}
				if (numper > 7)
				{
					label9.Text = Wrapper.strung[7];
					textBox9.Text = Wrapper.valwe[7].ToString();
					commnt9.Text = Wrapper.comnt[7];
					label9.Visible = textBox9.Visible = commnt9.Visible = true;
				}
				else
				{
					label9.Visible = textBox9.Visible = commnt9.Visible = false;
				}
				if (numper > 8)
				{
					label10.Text = Wrapper.strung[8];
					textBox10.Text = Wrapper.valwe[8].ToString();
					commnt10.Text = Wrapper.comnt[8];
					label10.Visible = textBox10.Visible = commnt10.Visible = true;
				}
				else
				{
					label10.Visible = textBox10.Visible = commnt10.Visible = false;
				}
				if (numper > 9)
				{
					label11.Text = Wrapper.strung[9];
					textBox11.Text = Wrapper.valwe[9].ToString();
					commnt11.Text = Wrapper.comnt[9];
					label11.Visible = textBox11.Visible = commnt11.Visible = true;
				}
				else
				{
					label11.Visible = textBox11.Visible = commnt11.Visible = false;
				}
				if (numper > 10)
				{
					label12.Text = Wrapper.strung[10];
					textBox12.Text = Wrapper.valwe[10].ToString();
					commnt12.Text = Wrapper.comnt[10];
					label12.Visible = textBox12.Visible = commnt12.Visible = true;
				}
				else
				{
					label12.Visible = textBox12.Visible = commnt12.Visible = false;
				}
				if (numper > 11)
				{
					label13.Text = Wrapper.strung[11];
					textBox13.Text = Wrapper.valwe[11].ToString();
					commnt13.Text = Wrapper.comnt[11];
					label13.Visible = textBox13.Visible = commnt13.Visible = true;
				}
				else
				{
					label13.Visible = textBox13.Visible = commnt13.Visible = false;
				}
				if (numper > 12)
				{
					label14.Text = Wrapper.strung[12];
					textBox14.Text = Wrapper.valwe[12].ToString();
					commnt14.Text = Wrapper.comnt[12];
					label14.Visible = textBox14.Visible = commnt14.Visible = true;
				}
				else
				{
					label14.Visible = textBox14.Visible = commnt14.Visible = false;
				}
				if (numper > 13)
				{
					label15.Text = Wrapper.strung[13];
					textBox15.Text = Wrapper.valwe[13].ToString();
					commnt15.Text = Wrapper.comnt[13];
					label15.Visible = textBox15.Visible = commnt15.Visible = true;
				}
				else
				{
					label15.Visible = textBox15.Visible = commnt15.Visible = false;
				}
				if (numper > 14)
				{
					label16.Text = Wrapper.strung[14];
					textBox16.Text = Wrapper.valwe[14].ToString();
					commnt16.Text = Wrapper.comnt[14];
					label16.Visible = textBox16.Visible = commnt16.Visible = true;
				}
				else
				{
					label16.Visible = textBox16.Visible = commnt16.Visible = false;
				}
				if (numper > 15)
				{
					label17.Text = Wrapper.strung[15];
					textBox17.Text = Wrapper.valwe[15].ToString();
					commnt17.Text = Wrapper.comnt[15];
					label17.Visible = textBox17.Visible = commnt17.Visible = true;
				}
				else
				{
					label17.Visible = textBox17.Visible = commnt17.Visible = false;
				}
				if (numper > 16)
				{
					label18.Text = Wrapper.strung[16];
					textBox18.Text = Wrapper.valwe[16].ToString();
					commnt18.Text = Wrapper.comnt[16];
					label18.Visible = textBox18.Visible = commnt18.Visible = true;
				}
				else
				{
					label18.Visible = textBox18.Visible = commnt18.Visible = false;
				}
				if (numper > 17)
				{
					label19.Text = Wrapper.strung[17];
					textBox19.Text = Wrapper.valwe[17].ToString();
					commnt19.Text = Wrapper.comnt[17];
					label19.Visible = textBox19.Visible = commnt19.Visible = true;
				}
				else
				{
					label19.Visible = textBox19.Visible = commnt19.Visible = false;
				}
				if (numper > 18)
				{
					label20.Text = Wrapper.strung[18];
					textBox20.Text = Wrapper.valwe[18].ToString();
					commnt20.Text = Wrapper.comnt[18];
					label20.Visible = textBox20.Visible = commnt20.Visible = true;
				}
				else
				{
					label20.Visible = textBox20.Visible = commnt20.Visible = false;
				}
				if (numper > 19)
				{
					label21.Text = Wrapper.strung[19];
					textBox21.Text = Wrapper.valwe[19].ToString();
					commnt21.Text = Wrapper.comnt[19];
					label21.Visible = textBox21.Visible = commnt21.Visible = true;
				}
				else
				{
					label21.Visible = textBox21.Visible = commnt21.Visible = false;
				}
				if (numper > 20)
				{
					label22.Text = Wrapper.strung[20];
					textBox22.Text = Wrapper.valwe[20].ToString();
					commnt22.Text = Wrapper.comnt[20];
					label22.Visible = textBox22.Visible = commnt22.Visible = true;
				}
				else
				{
					label22.Visible = textBox22.Visible = commnt22.Visible = false;
				}
				if (numper > 21)
				{
					label23.Text = Wrapper.strung[21];
					textBox23.Text = Wrapper.valwe[21].ToString();
					commnt23.Text = Wrapper.comnt[21];
					label23.Visible = textBox23.Visible = commnt23.Visible = true;
				}
				else
				{
					label23.Visible = textBox23.Visible = commnt23.Visible = false;
				}
				if (numper > 22)
				{
					label24.Text = Wrapper.strung[22];
					textBox24.Text = Wrapper.valwe[22].ToString();
					commnt24.Text = Wrapper.comnt[22];
					label24.Visible = textBox24.Visible = commnt24.Visible = true;
				}
				else
				{
					label24.Visible = textBox24.Visible = commnt24.Visible = false;
				}
				if (numper > 23)
				{
					label25.Text = Wrapper.strung[23];
					textBox25.Text = Wrapper.valwe[23].ToString();
					commnt25.Text = Wrapper.comnt[23];
					label25.Visible = textBox25.Visible = commnt25.Visible = true;
				}
				else
				{
					label25.Visible = textBox25.Visible = commnt25.Visible = false;
				}
				if (numper > 24)
				{
					label26.Text = Wrapper.strung[24];
					textBox26.Text = Wrapper.valwe[24].ToString();
					commnt26.Text = Wrapper.comnt[24];
					label26.Visible = textBox26.Visible = commnt26.Visible = true;
				}
				else
				{
					label26.Visible = textBox26.Visible = commnt26.Visible = false;
				}
				if (numper > 25)
				{
					label27.Text = Wrapper.strung[25];
					textBox27.Text = Wrapper.valwe[25].ToString();
					commnt27.Text = Wrapper.comnt[25];
					label27.Visible = textBox27.Visible = commnt27.Visible = true;
				}
				else
				{
					label27.Visible = textBox27.Visible = commnt27.Visible = false;
				}
				if (numper > 26)
				{
					label28.Text = Wrapper.strung[26];
					textBox28.Text = Wrapper.valwe[26].ToString();
					commnt28.Text = Wrapper.comnt[26];
					label28.Visible = textBox28.Visible = commnt28.Visible = true;
				}
				else
				{
					label28.Visible = textBox28.Visible = commnt28.Visible = false;
				}
				if (numper > 27)
				{
					label29.Text = Wrapper.strung[27];
					textBox29.Text = Wrapper.valwe[27].ToString();
					commnt29.Text = Wrapper.comnt[27];
					label29.Visible = textBox29.Visible = commnt29.Visible = true;
				}
				else
				{
					label29.Visible = textBox29.Visible = commnt29.Visible = false;
				}
				if (numper > 28)
				{
					label30.Text = Wrapper.strung[28];
					textBox30.Text = Wrapper.valwe[28].ToString();
					commnt30.Text = Wrapper.comnt[28];
					label30.Visible = textBox30.Visible = commnt30.Visible = true;
				}
				else
				{
					label30.Visible = textBox30.Visible = commnt30.Visible = false;
				}
				if (numper > 29)
				{
					label31.Text = Wrapper.strung[29];
					textBox31.Text = Wrapper.valwe[29].ToString();
					commnt31.Text = Wrapper.comnt[29];
					label31.Visible = textBox31.Visible = commnt31.Visible = true;
				}
				else
				{
					label31.Visible = textBox31.Visible = commnt31.Visible = false;
				}
				if (numper > 30)
				{
					label32.Text = Wrapper.strung[30];
					textBox32.Text = Wrapper.valwe[30].ToString();
					commnt32.Text = Wrapper.comnt[30];
					label32.Visible = textBox32.Visible = commnt32.Visible = true;
				}
				else
				{
					label32.Visible = textBox32.Visible = commnt32.Visible = false;
				}
				if (numper > 31)
				{
					label33.Text = Wrapper.strung[31];
					textBox33.Text = Wrapper.valwe[31].ToString();
					commnt33.Text = Wrapper.comnt[31];
					label33.Visible = textBox33.Visible = commnt33.Visible = true;
				}
				else
				{
					label33.Visible = textBox33.Visible = commnt33.Visible = false;
				}
				if (numper > 32)
				{
					label34.Text = Wrapper.strung[32];
					textBox34.Text = Wrapper.valwe[32].ToString();
					commnt34.Text = Wrapper.comnt[32];
					label34.Visible = textBox34.Visible = commnt34.Visible = true;
				}
				else
				{
					label34.Visible = textBox34.Visible = commnt34.Visible = false;
				}
				if (numper > 33)
				{
					label35.Text = Wrapper.strung[33];
					textBox35.Text = Wrapper.valwe[33].ToString();
					commnt35.Text = Wrapper.comnt[33];
					label35.Visible = textBox35.Visible = commnt35.Visible = true;
				}
				else
				{
					label35.Visible = textBox35.Visible = commnt35.Visible = false;
				}
				if (numper > 34)
				{
					label36.Text = Wrapper.strung[34];
					textBox36.Text = Wrapper.valwe[34].ToString();
					commnt36.Text = Wrapper.comnt[34];
					label36.Visible = textBox36.Visible = commnt36.Visible = true;
				}
				else
				{
					label36.Visible = textBox36.Visible = commnt36.Visible = false;
				}
				if (numper > 35)
				{
					label37.Text = Wrapper.strung[35];
					textBox37.Text = Wrapper.valwe[35].ToString();
					commnt37.Text = Wrapper.comnt[35];
					label37.Visible = textBox37.Visible = commnt37.Visible = true;
				}
				else
				{
					label37.Visible = textBox37.Visible = commnt37.Visible = false;
				}
				if (numper > 36)
				{
					label38.Text = Wrapper.strung[36];
					textBox38.Text = Wrapper.valwe[36].ToString();
					commnt38.Text = Wrapper.comnt[36];
					label38.Visible = textBox38.Visible = commnt38.Visible = true;
				}
				else
				{
					label38.Visible = textBox38.Visible = commnt38.Visible = false;
				}
				if (numper > 37)
				{
					label39.Text = Wrapper.strung[37];
					textBox39.Text = Wrapper.valwe[37].ToString();
					commnt39.Text = Wrapper.comnt[37];
					label39.Visible = textBox39.Visible = commnt39.Visible = true;
				}
				else
				{
					label39.Visible = textBox39.Visible = commnt39.Visible = false;
				}
				if (numper > 38)
				{
					label40.Text = Wrapper.strung[38];
					textBox40.Text = Wrapper.valwe[38].ToString();
					commnt40.Text = Wrapper.comnt[38];
					label40.Visible = textBox40.Visible = commnt40.Visible = true;
				}
				else
				{
					label40.Visible = textBox40.Visible = commnt40.Visible = false;
				}
				if (numper > 39)
				{
					label41.Text = Wrapper.strung[39];
					textBox41.Text = Wrapper.valwe[39].ToString();
					commnt41.Text = Wrapper.comnt[39];
					label41.Visible = textBox41.Visible = commnt41.Visible = true;
				}
				else
				{
					label41.Visible = textBox41.Visible = commnt41.Visible = false;
				}
				if (numper > 40)
				{
					label42.Text = Wrapper.strung[40];
					textBox42.Text = Wrapper.valwe[40].ToString();
					commnt42.Text = Wrapper.comnt[40];
					label42.Visible = textBox42.Visible = commnt42.Visible = true;
				}
				else
				{
					label42.Visible = textBox42.Visible = commnt42.Visible = false;
				}
				if (numper > 41)
				{
					label43.Text = Wrapper.strung[41];
					textBox43.Text = Wrapper.valwe[41].ToString();
					commnt43.Text = Wrapper.comnt[41];
					label43.Visible = textBox43.Visible = commnt43.Visible = true;
				}
				else
				{
					label43.Visible = textBox43.Visible = commnt43.Visible = false;
				}
				if (numper > 42)
				{
					label44.Text = Wrapper.strung[42];
					textBox44.Text = Wrapper.valwe[42].ToString();
					commnt44.Text = Wrapper.comnt[42];
					label44.Visible = textBox44.Visible = commnt44.Visible = true;
				}
				else
				{
					label44.Visible = textBox44.Visible = commnt44.Visible = false;
				}
				if (numper > 43)
				{
					label45.Text = Wrapper.strung[43];
					textBox45.Text = Wrapper.valwe[43].ToString();
					commnt45.Text = Wrapper.comnt[43];
					label45.Visible = textBox45.Visible = commnt45.Visible = true;
				}
				else
				{
					label45.Visible = textBox45.Visible = commnt45.Visible = false;
				}
				if (numper > 44)
				{
					label46.Text = Wrapper.strung[44];
					textBox46.Text = Wrapper.valwe[44].ToString();
					commnt46.Text = Wrapper.comnt[44];
					label46.Visible = textBox46.Visible = commnt46.Visible = true;
				}
				else
				{
					label46.Visible = textBox46.Visible = commnt46.Visible = false;
				}
				if (numper > 45)
				{
					label47.Text = Wrapper.strung[45];
					textBox47.Text = Wrapper.valwe[45].ToString();
					commnt47.Text = Wrapper.comnt[45];
					label47.Visible = textBox47.Visible = commnt47.Visible = true;
				}
				else
				{
					label47.Visible = textBox47.Visible = commnt47.Visible = false;
				}
				if (numper > 46)
				{
					label48.Text = Wrapper.strung[46];
					textBox48.Text = Wrapper.valwe[46].ToString();
					commnt48.Text = Wrapper.comnt[46];
					label48.Visible = textBox48.Visible = commnt48.Visible = true;
				}
				else
				{
					label48.Visible = textBox48.Visible = commnt48.Visible = false;
				}
				if (numper > 47)
				{
					label49.Text = Wrapper.strung[47];
					textBox49.Text = Wrapper.valwe[47].ToString();
					commnt49.Text = Wrapper.comnt[47];
					label49.Visible = textBox49.Visible = commnt49.Visible = true;
				}
				else
				{
					label49.Visible = textBox49.Visible = commnt49.Visible = false;
				}
				if (numper > 48)
				{
					label50.Text = Wrapper.strung[48];
					textBox50.Text = Wrapper.valwe[48].ToString();
					commnt50.Text = Wrapper.comnt[48];
					label50.Visible = textBox50.Visible = commnt50.Visible = true;
				}
				else
				{
					label50.Visible = textBox50.Visible = commnt50.Visible = false;
				}
				if (numper > 49)
				{
					label51.Text = Wrapper.strung[49];
					textBox51.Text = Wrapper.valwe[49].ToString();
					commnt51.Text = Wrapper.comnt[49];
					label51.Visible = textBox51.Visible = commnt51.Visible = true;
				}
				else
				{
					label51.Visible = textBox51.Visible = commnt51.Visible = false;
				}
				if (numper > 50)
				{
					label52.Text = Wrapper.strung[50];
					textBox52.Text = Wrapper.valwe[50].ToString();
					commnt52.Text = Wrapper.comnt[50];
					label52.Visible = textBox52.Visible = commnt52.Visible = true;
				}
				else
				{
					label52.Visible = textBox52.Visible = commnt52.Visible = false;
				}
				if (numper > 51)
				{
					label53.Text = Wrapper.strung[51];
					textBox53.Text = Wrapper.valwe[51].ToString();
					commnt53.Text = Wrapper.comnt[51];
					label53.Visible = textBox53.Visible = commnt53.Visible = true;
				}
				else
				{
					label53.Visible = textBox53.Visible = commnt53.Visible = false;
				}
				if (numper > 52)
				{
					label54.Text = Wrapper.strung[52];
					textBox54.Text = Wrapper.valwe[52].ToString();
					commnt54.Text = Wrapper.comnt[52];
					label54.Visible = textBox54.Visible = commnt54.Visible = true;
				}
				else
				{
					label54.Visible = textBox54.Visible = commnt54.Visible = false;
				}
				if (numper > 53)
				{
					label55.Text = Wrapper.strung[53];
					textBox55.Text = Wrapper.valwe[53].ToString();
					commnt55.Text = Wrapper.comnt[53];
					label55.Visible = textBox55.Visible = commnt55.Visible = true;
				}
				else
				{
					label55.Visible = textBox55.Visible = commnt55.Visible = false;
				}
				if (numper > 54)
				{
					label56.Text = Wrapper.strung[54];
					textBox56.Text = Wrapper.valwe[54].ToString();
					commnt56.Text = Wrapper.comnt[54];
					label56.Visible = textBox56.Visible = commnt56.Visible = true;
				}
				else
				{
					label56.Visible = textBox56.Visible = commnt56.Visible = false;
				}
			}
			else
			{
				panel2.Visible = false;
			}
		}

		public override void OnCommit()
		{
			base.OnCommit();
			TPFW.SynchronizeUserData(true, false);
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

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[0] = Convert.ToSingle(textBox1.Text);
		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[1] = Convert.ToSingle(textBox3.Text);
		}

		private void textBox4_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[2] = Convert.ToSingle(textBox4.Text);
		}

		private void textBox5_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[3] = Convert.ToSingle(textBox5.Text);
		}

		private void textBox6_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[4] = Convert.ToSingle(textBox6.Text);
		}

		private void textBox7_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[5] = Convert.ToSingle(textBox7.Text);
		}

		private void textBox8_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[6] = Convert.ToSingle(textBox8.Text);
		}

		private void textBox9_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[7] = Convert.ToSingle(textBox9.Text);
		}

		private void textBox10_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[8] = Convert.ToSingle(textBox10.Text);
		}

		private void textBox11_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[9] = Convert.ToSingle(textBox11.Text);
		}

		private void textBox12_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[10] = Convert.ToSingle(textBox12.Text);
		}

		private void textBox13_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[11] = Convert.ToSingle(textBox13.Text);
		}

		private void textBox14_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[12] = Convert.ToSingle(textBox14.Text);
		}

		private void textBox15_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[13] = Convert.ToSingle(textBox15.Text);
		}

		private void textBox16_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[14] = Convert.ToSingle(textBox16.Text);
		}

		private void textBox17_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[15] = Convert.ToSingle(textBox17.Text);
		}

		private void textBox18_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[16] = Convert.ToSingle(textBox18.Text);
		}

		private void textBox19_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[17] = Convert.ToSingle(textBox19.Text);
		}

		private void textBox20_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[18] = Convert.ToSingle(textBox20.Text);
		}

		private void textBox21_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[19] = Convert.ToSingle(textBox21.Text);
		}

		private void textBox22_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[20] = Convert.ToSingle(textBox22.Text);
		}

		private void textBox23_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[21] = Convert.ToSingle(textBox23.Text);
		}

		private void textBox24_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[22] = Convert.ToSingle(textBox24.Text);
		}

		private void textBox25_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[23] = Convert.ToSingle(textBox25.Text);
		}

		private void textBox26_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[24] = Convert.ToSingle(textBox26.Text);
		}

		private void textBox27_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[25] = Convert.ToSingle(textBox27.Text);
		}

		private void textBox28_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[26] = Convert.ToSingle(textBox28.Text);
		}

		private void textBox29_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[27] = Convert.ToSingle(textBox29.Text);
		}

		private void textBox30_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[28] = Convert.ToSingle(textBox30.Text);
		}

		private void textBox31_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[29] = Convert.ToSingle(textBox31.Text);
		}

		private void textBox32_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[30] = Convert.ToSingle(textBox32.Text);
		}

		private void textBox33_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[31] = Convert.ToSingle(textBox33.Text);
		}

		private void textBox34_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[32] = Convert.ToSingle(textBox34.Text);
		}

		private void textBox35_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[33] = Convert.ToSingle(textBox35.Text);
		}

		private void textBox36_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[34] = Convert.ToSingle(textBox36.Text);
		}

		private void textBox37_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[35] = Convert.ToSingle(textBox37.Text);
		}

		private void textBox38_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[36] = Convert.ToSingle(textBox38.Text);
		}

		private void textBox39_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[37] = Convert.ToSingle(textBox39.Text);
		}

		private void textBox40_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[38] = Convert.ToSingle(textBox40.Text);
		}

		private void textBox41_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[39] = Convert.ToSingle(textBox41.Text);
		}

		private void textBox42_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[40] = Convert.ToSingle(textBox42.Text);
		}

		private void textBox43_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[41] = Convert.ToSingle(textBox43.Text);
		}

		private void textBox44_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[42] = Convert.ToSingle(textBox44.Text);
		}

		private void textBox45_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[43] = Convert.ToSingle(textBox45.Text);
		}

		private void textBox46_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[44] = Convert.ToSingle(textBox46.Text);
		}

		private void textBox47_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[45] = Convert.ToSingle(textBox47.Text);
		}

		private void textBox48_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[46] = Convert.ToSingle(textBox48.Text);
		}

		private void textBox49_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[47] = Convert.ToSingle(textBox49.Text);
		}

		private void textBox50_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[48] = Convert.ToSingle(textBox50.Text);
		}

		private void textBox51_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[49] = Convert.ToSingle(textBox51.Text);
		}

		private void textBox52_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[50] = Convert.ToSingle(textBox52.Text);
		}

		private void textBox53_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[51] = Convert.ToSingle(textBox53.Text);
		}

		private void textBox54_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[52] = Convert.ToSingle(textBox54.Text);
		}

		private void textBox55_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[53] = Convert.ToSingle(textBox55.Text);
		}

		private void textBox56_TextChanged(object sender, EventArgs e)
		{
			Wrapper.valwe[54] = Convert.ToSingle(textBox56.Text);
		}
	}
}
