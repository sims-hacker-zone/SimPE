using System;
using System.Drawing;

using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	/// <summary>
	/// This class is used to fill the UI for this FileType with Data
	/// </summary>
	public partial class FamiuPackedFileUI
		: Windows.Forms.WrapperBaseControl,
			IPackedFileUI
	{
		protected new FamiuPackedFileWrapper Wrapper => base.Wrapper as FamiuPackedFileWrapper;
		public FamiuPackedFileWrapper TPFW => (FamiuPackedFileWrapper)Wrapper;

		ushort[] filedata;
		int[] sdatas;
		int[] wdatas;
		int[] mdatas;
		int[] gdatas;
		int[] bdatas;
		int[] fdatas;
		int[] cdatas;
		int sections;
		int currentsection;
		int goodsections;
		bool shwraw = false;
		Interfaces.Providers.ILotItem LotDescription;

		#region WrapperBaseControl Member

		public FamiuPackedFileUI()
		{
			InitializeComponent();
			if (Helper.WindowsRegistry.UseBigIcons)
			{
				pbImage.Size = new Size(168, 168);
				pbImage.Location = new Point(6, 28);
			}
		}

		protected override void RefreshGUI()
		{
			base.RefreshGUI();

			CanCommit = Wrapper.isnew;
			if (Wrapper.FamiThumb != null)
			{
				pbImage.Image =
					Ambertation.Windows.Forms.Graph.ImagePanel.CreateThumbnail(
						Wrapper.FamiThumb,
						pbImage.Size,
						12,
						Color.FromArgb(90, Color.Black),
						SystemColors.ControlDarkDark,
						Color.White,
						Color.FromArgb(80, Color.White),
						true,
						4,
						0
					);
			}
			else
			{
				pbImage.Image = null;
			}

			HeaderText = Wrapper.Name + " Family History";

			filedata = Wrapper.FVal;
			sections = Wrapper.Sections;
			goodsections = Wrapper.GoodSections;
			RefreshGraphs();
			//if (Wrapper.Version == 86) fundGraph.Title = "Resources";
			//else fundGraph.Title = "Family Funds";
			shwraw = Helper.WindowsRegistry.HiddenMode;
			btRawd.Visible = !Helper.WindowsRegistry.HiddenMode;
			lbraw.Text = "Data :";
			btRawd.Text = "Show Raw Data";
			filimuptext();
			rtbAbout.Visible = tbEditer.Visible = false;
			tbBlocks.Visible = gtname.Visible = true;
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

		private void RefreshGraphs()
		{
			lbTota.Text = "Invalid Days " + Convert.ToString(sections - goodsections);
			tbBlocks.HeaderText = "Valid Days " + Convert.ToString(goodsections);
			if (goodsections > 1)
			{
				int n = 0;
				Array.Resize(ref sdatas, goodsections);
				Array.Resize(ref wdatas, goodsections);
				Array.Resize(ref mdatas, goodsections);
				Array.Resize(ref gdatas, goodsections);
				Array.Resize(ref bdatas, goodsections);
				Array.Resize(ref fdatas, goodsections);
				Array.Resize(ref cdatas, goodsections);
				for (int i = 0; i < sections; i++)
				{
					if (TestIsValid(i))
					{
						sdatas[n] = Convert.ToInt32(filedata[(i * 42) + 1]);
						wdatas[n] = Convert.ToInt32(filedata[(i * 42) + 3]);
						mdatas[n] = Convert.ToInt32(filedata[(i * 42) + 2]);
						gdatas[n] = Convert.ToInt32(filedata[(i * 42) + 5]);
						bdatas[n] = Convert.ToInt32(filedata[(i * 42) + 4]);
						fdatas[n] = Convert.ToInt32(filedata[(i * 42) + 35]);
						cdatas[n] = Convert.ToInt32(
							(filedata[(i * 42) + 34] << 16) + filedata[(i * 42) + 33]
						);
						n++;
						if (n > goodsections)
						{
							break; // catch Index was outside the bounds of the array Exception
						}
					}
				}
			}
			else
			{
				sdatas = new int[] { 0, 0 };
				wdatas = new int[] { 0, 0 };
				mdatas = new int[] { 0, 0 };
				gdatas = new int[] { 0, 0 };
				bdatas = new int[] { 0, 0 };
				fdatas = new int[] { 0, 0 };
				cdatas = new int[] { 0, 0 };
			}
			//simGraph.Datas = sdatas;
			//femGraph.Datas = wdatas;
			//menGraph.Datas = mdatas;
			//girlGraph.Datas = gdatas;
			//boyGraph.Datas = bdatas;
			//mateGraph.Datas = fdatas;
			//fundGraph.Datas = cdatas;
			if (sections == 0)
			{
				btediter.Text = "Add a Day";
				currentsection = 0;
				tbValue.Text = "0";
			}
			else
			{
				btediter.Text = "Edit This Day";
				currentsection = 1;
				tbValue.Text = "1";
				buttonset();
			}
			lbTota.Visible = (sections - goodsections > 0);
		}

		private void btprev_Click(object sender, EventArgs e)
		{
			if (sections == 0)
			{
				return;
			}

			if (currentsection > 1)
			{
				currentsection--;
			}
			else
			{
				currentsection = sections;
			}
			tbValue.Text = Convert.ToString(currentsection);
			filimuptext();
			buttonset();
		}

		private void btnext_Click(object sender, EventArgs e)
		{
			if (sections == 0)
			{
				return;
			}

			if (currentsection < sections)
			{
				currentsection++;
			}
			else
			{
				currentsection = 1;
			}
			tbValue.Text = Convert.ToString(currentsection);
			filimuptext();
			buttonset();
		}

		private void buttonset()
		{
			if (currentsection == 1)
			{
				btprev.Text = "<- Last Day";
			}
			else
			{
				btprev.Text = "<- Previous Day";
			}

			if (currentsection == sections)
			{
				btnext.Text = "First Day ->";
			}
			else
			{
				btnext.Text = "Next Day ->";
			}
		}

		private void filimuptext()
		{
			if (sections == 0)
			{
				gtname.Text = "~ No Data Blocks ~";
				btDelete.Visible = false;
				return;
			}
			int currentsectionindex = currentsection - 1;
			btDelete.Visible = (sections > 1); // keep at least one, if we want to delete the last block then it is better to just delete the resource
			if (shwraw)
			{
				if (TestIsValid(currentsectionindex))
				{
					gtname.Text =
						"~ Valid Data Block ~ Number "
						+ Convert.ToString(currentsection)
						+ "\r\n";
				}
				else
				{
					gtname.Text =
						"~ Invalid Data Block ~ Number "
						+ Convert.ToString(currentsection)
						+ "\r\n";
				}
				/* Only Unknown values
gtname.Text += "(0x" + Helper.HexString(filedata[(currentsectionindex * 42) + 7]) + ")  -  (0x" + Helper.HexString(filedata[(currentsectionindex * 42) + 8]) + ")  -  (0x" + Helper.HexString(filedata[(currentsectionindex * 42) + 9]) + ")\r\n";
gtname.Text += "(0x" + Helper.HexString(filedata[(currentsectionindex * 42) + 10]) + ")  -  (0x" + Helper.HexString(filedata[(currentsectionindex * 42) + 11]) + ")  -  (0x" + Helper.HexString(filedata[(currentsectionindex * 42) + 12]) + ")\r\n";
gtname.Text += "(0x" + Helper.HexString(filedata[(currentsectionindex * 42) + 13]) + ")  -  (0x" + Helper.HexString(filedata[(currentsectionindex * 42) + 14]) + ")  -  (0x" + Helper.HexString(filedata[(currentsectionindex * 42) + 15]) + ")\r\n";
gtname.Text += "(0x" + Helper.HexString(filedata[(currentsectionindex * 42) + 16]) + ")  -  (0x" + Helper.HexString(filedata[(currentsectionindex * 42) + 17]) + ")  -  (0x" + Helper.HexString(filedata[(currentsectionindex * 42) + 18]) + ")\r\n";
gtname.Text += "(0x" + Helper.HexString(filedata[(currentsectionindex * 42) + 19]) + ")  -  (0x" + Helper.HexString(filedata[(currentsectionindex * 42) + 20]) + ")  -  (0x" + Helper.HexString(filedata[(currentsectionindex * 42) + 21]) + ")\r\n";
gtname.Text += "(0x" + Helper.HexString(filedata[(currentsectionindex * 42) + 22]) + ")  -  (0x" + Helper.HexString(filedata[(currentsectionindex * 42) + 23]) + ")  -  (0x" + Helper.HexString(filedata[(currentsectionindex * 42) + 24]) + ")\r\n";
gtname.Text += "(0x" + Helper.HexString(filedata[(currentsectionindex * 42) + 25]) + ")  -  (0x" + Helper.HexString(filedata[(currentsectionindex * 42) + 26]) + ")  -  (0x" + Helper.HexString(filedata[(currentsectionindex * 42) + 27]) + ")\r\n";
gtname.Text += "(0x" + Helper.HexString(filedata[(currentsectionindex * 42) + 28]) + ")  -  (0x" + Helper.HexString(filedata[(currentsectionindex * 42) + 29]) + ")  -  (0x" + Helper.HexString(filedata[(currentsectionindex * 42) + 30]) + ")\r\n";
gtname.Text += "(0x" + Helper.HexString(filedata[(currentsectionindex * 42) + 31]) + ")  -  (0x" + Helper.HexString(filedata[(currentsectionindex * 42) + 32]) + ")\r\n";
gtname.Text += "(0x" + Helper.HexString(filedata[(currentsectionindex * 42) + 36]) + ")  -  (0x" + Helper.HexString(filedata[(currentsectionindex * 42) + 37]) + ")\r\n";
*/
				for (int i = 0; i < 42; i += 3)
				{
					gtname.Text +=
						"(0x"
						+ Helper.HexString(filedata[(currentsectionindex * 42) + i])
						+ ")  -  ";
					gtname.Text +=
						"(0x"
						+ Helper.HexString(filedata[(currentsectionindex * 42) + i + 1])
						+ ")  -  ";
					gtname.Text +=
						"(0x"
						+ Helper.HexString(filedata[(currentsectionindex * 42) + i + 2])
						+ ")\r\n";
				}
			}
			else
			{
				if (TestIsValid(currentsectionindex)) // byte pair 1
				{
					LotDescription =
						FileTableBase.ProviderRegistry.LotProvider.FindLot(
							filedata[currentsectionindex * 42]
						);
					int FamFund =
						(filedata[(currentsectionindex * 42) + 34] << 16)
						+ filedata[(currentsectionindex * 42) + 33];
					// long Dyte = (filedata[(currentsectionindex * 42) + 10] << 48) + (filedata[(currentsectionindex * 42) + 9] << 32) + (filedata[(currentsectionindex * 42) + 8] << 16) + filedata[(currentsectionindex * 42) + 7];
					gtname.Text = Wrapper.Name + " family residence\r\n";
					gtname.Text += " " + LotDescription.LotName + ",\r\n";
					gtname.Text +=
						" "
						+ Wrapper.Subhood(filedata[currentsectionindex * 42])
						+ "\r\n\r\n";
					gtname.Text +=
						"Family members present = "
						+ Convert.ToString(filedata[(currentsectionindex * 42) + 1])
						+ "\r\n"; // byte pair 2
					gtname.Text +=
						" Men Present = "
						+ Convert.ToString(filedata[(currentsectionindex * 42) + 2])
						+ "\r\n"; // byte pair 3
					gtname.Text +=
						" Women Present = "
						+ Convert.ToString(filedata[(currentsectionindex * 42) + 3])
						+ "\r\n"; // byte pair 4
					gtname.Text +=
						" Boys Present = "
						+ Convert.ToString(filedata[(currentsectionindex * 42) + 4])
						+ "\r\n"; // byte pair 5
					gtname.Text +=
						" Girls Present = "
						+ Convert.ToString(filedata[(currentsectionindex * 42) + 5])
						+ "\r\n\r\n"; // byte pair 6
					if (Wrapper.Version == 86)
					{
						gtname.Text +=
							"Resources = " + Convert.ToString(FamFund) + "\r\n";
					}
					else
					{
						gtname.Text +=
							"Family Funds = " + FamFund.ToString("C0") + "\r\n";
					}

					gtname.Text +=
						"Family Friends = "
						+ Convert.ToString(filedata[(currentsectionindex * 42) + 35])
						+ "\r\n";
					/*
					if (filedata[(currentsectionindex * 42) + 13] == 0) gtname.Text += " No-One left at Home\r\n";
					else if (filedata[(currentsectionindex * 42) + 13] == 1) gtname.Text += " Everybody at Home\r\n";
					else if (filedata[(currentsectionindex * 42) + 13] == 2) gtname.Text += " Not at Home, At a Community Lot\r\n";
					gtname.Text += "Data of Interest = " + Convert.ToString(filedata[(currentsectionindex * 42) + 9]) + "\r\n";
					 */
					// gtname.Text += "Data of Interest = 0x" + DateTime.FromBinary(Dyte).ToString();
				}
				else
				{
					gtname.Text = "~ Invalid Day Block ~";
				}
			}
		}

		private bool TestIsValid(int currentsectionindex)
		{
			if (
				filedata[currentsectionindex * 42] == 0
				&& !Helper.WindowsRegistry.AllowLotZero
			)
			{
				return false; // Lot Number, only sims in a playable family could age a day
			}

			if (filedata[(currentsectionindex * 42) + 1] > 32)
			{
				return false; // too many sims to be correct
			}

			if (
				filedata[(currentsectionindex * 42) + 2]
					+ filedata[(currentsectionindex * 42) + 3]
					+ filedata[(currentsectionindex * 42) + 4]
					+ filedata[(currentsectionindex * 42) + 5]
				!= filedata[(currentsectionindex * 42) + 1]
			)
			{
				return false; // bad checksum
			}

			return true;
		}

		private void btDelete_Click(object sender, EventArgs e)
		{
			int l = 0;
			int n = 0;
			int currentsectionindex = currentsection - 1;
			if (filedata[(currentsectionindex * 42)] > 0)
			{
				goodsections--;
			}

			sections--;
			Array.Resize(ref filedata, sections * 42);
			foreach (ushort k in Wrapper.FVal)
			{
				if (
					l < currentsectionindex * 42
					|| l + 1 > (currentsectionindex + 1) * 42
				)
				{
					filedata[n] = k;
					n++;
				}
				l++;
			}
			Wrapper.FVal = filedata;
			Wrapper.Sections = sections;
			RefreshGraphs();
			filimuptext();
			buttonset();
			CanCommit = true;
		}

		private void btRawd_Click(object sender, EventArgs e)
		{
			if (shwraw)
			{
				shwraw = false;
				lbraw.Text = "Data :";
				btRawd.Text = "Show Raw Data";
			}
			else
			{
				shwraw = true;
				lbraw.Text = "Raw Data :";
				btRawd.Text = "Show Informaton";
			}
			filimuptext();
		}

		//void linkyabout_LinkClicked(object sender, System.EventArgs e)
		//{
		//    if (rtbAbout.Visible)
		//    {
		//        linkyabout.Links[0].Visited = true;
		//        rtbAbout.Visible = false;
		//    }
		//    else
		//    {
		//        linkyabout.LinkColour = Color.Red;
		//        linkyabout.Links[0].Visited = false;
		//        rtbAbout.Visible = true;
		//    }
		//}

		private void btediter_Click(object sender, EventArgs e)
		{
			lbInvalid.Visible = false;
			tbLotNo.ForeColor =
				tbMenNo.ForeColor =
				tbLadyNo.ForeColor =
				tbBoyNo.ForeColor =
				tbGirlNo.ForeColor =
				tbFriends.ForeColor =
				tbFunds.ForeColor =
					SystemColors.WindowText;
			if (sections == 0)
			{
				tbBlocks.Visible = gtname.Visible = BtGoody.Visible = false;
				tbLotNo.Text = "0x0000";
				tbMenNo.Text = "0";
				tbLadyNo.Text = "0";
				tbBoyNo.Text = "0";
				tbGirlNo.Text = "0";
				tbFunds.Text = "0";
				tbFriends.Text = "0";
				tbEditer.HeaderText = "History Block Editer";
				tbEditer.Visible = true;
			}
			else
			{
				tbBlocks.Visible = gtname.Visible = false;
				int currentsectionindex = currentsection - 1;
				int FamFund =
					(filedata[(currentsectionindex * 42) + 34] << 16)
					+ filedata[(currentsectionindex * 42) + 33];
				tbLotNo.Text =
					"0x" + Helper.HexString(filedata[(currentsectionindex * 42)]);
				tbMenNo.Text = Convert.ToString(
					filedata[(currentsectionindex * 42) + 2]
				);
				tbLadyNo.Text = Convert.ToString(
					filedata[(currentsectionindex * 42) + 3]
				);
				tbBoyNo.Text = Convert.ToString(
					filedata[(currentsectionindex * 42) + 4]
				);
				tbGirlNo.Text = Convert.ToString(
					filedata[(currentsectionindex * 42) + 5]
				);
				tbFunds.Text = Convert.ToString(FamFund);
				tbFriends.Text = Convert.ToString(
					filedata[(currentsectionindex * 42) + 35]
				);
				tbEditer.HeaderText =
					"History Block Editer - Block " + Convert.ToString(currentsection);
				tbEditer.Visible = BtGoody.Visible = true;
			}
		}

		private void btBady_Click(object sender, EventArgs e)
		{
			tbEditer.Visible = false;
			tbBlocks.Visible = gtname.Visible = true;
		}

		private void BtGoody_Click(object sender, EventArgs e)
		{
			int currentsectionindex = currentsection - 1;
			bool wasgood = false;
			if (filedata[(currentsectionindex * 42)] > 0)
			{
				wasgood = true;
			}

			try
			{
				int FamFund = Convert.ToInt32(tbFunds.Text);
				string monee = Helper.HexString(FamFund);
				filedata[(currentsectionindex * 42) + 34] = Convert.ToUInt16(
					monee.Substring(0, 4),
					16
				);
				filedata[(currentsectionindex * 42) + 33] = Convert.ToUInt16(
					monee.Substring(4, 4),
					16
				);
				filedata[(currentsectionindex * 42) + 2] = Convert.ToUInt16(
					tbMenNo.Text
				);
				filedata[(currentsectionindex * 42) + 3] = Convert.ToUInt16(
					tbLadyNo.Text
				);
				filedata[(currentsectionindex * 42) + 4] = Convert.ToUInt16(
					tbBoyNo.Text
				);
				filedata[(currentsectionindex * 42) + 5] = Convert.ToUInt16(
					tbGirlNo.Text
				);
				filedata[(currentsectionindex * 42) + 1] = (ushort)(
					filedata[(currentsectionindex * 42) + 2]
					+ filedata[(currentsectionindex * 42) + 3]
					+ filedata[(currentsectionindex * 42) + 4]
					+ filedata[(currentsectionindex * 42) + 5]
				);
				filedata[(currentsectionindex * 42)] = Convert.ToUInt16(
					tbLotNo.Text,
					16
				);
				filedata[(currentsectionindex * 42) + 35] = Convert.ToUInt16(
					tbFriends.Text
				);
				if (filedata[(currentsectionindex * 42)] > 0 && !wasgood)
				{
					goodsections++;
				}
				else if (filedata[(currentsectionindex * 42)] == 0 && wasgood)
				{
					goodsections--;
				}

				CanCommit = true;
				RefreshGraphs();
				filimuptext();
			}
			catch { }
			tbEditer.Visible = false;
			tbBlocks.Visible = gtname.Visible = true;
		}

		private void btnuver_Click(object sender, EventArgs e)
		{
			try
			{
				int currentsectionindex = sections;
				// read everthing into variables first so if error in a text box no change occurs
				tbLotNo.ForeColor = Color.Red;
				ushort lotno = Convert.ToUInt16(tbLotNo.Text, 16);
				tbLotNo.ForeColor = SystemColors.WindowText;
				tbMenNo.ForeColor = Color.Red;
				ushort meno = Convert.ToUInt16(tbMenNo.Text);
				tbMenNo.ForeColor = SystemColors.WindowText;
				tbLadyNo.ForeColor = Color.Red;
				ushort ladyno = Convert.ToUInt16(tbLadyNo.Text);
				tbLadyNo.ForeColor = SystemColors.WindowText;
				tbBoyNo.ForeColor = Color.Red;
				ushort boyno = Convert.ToUInt16(tbBoyNo.Text);
				tbBoyNo.ForeColor = SystemColors.WindowText;
				tbGirlNo.ForeColor = Color.Red;
				ushort girlno = Convert.ToUInt16(tbGirlNo.Text);
				tbGirlNo.ForeColor = SystemColors.WindowText;
				tbFriends.ForeColor = Color.Red;
				ushort friendno = Convert.ToUInt16(tbFriends.Text);
				tbFriends.ForeColor = SystemColors.WindowText;
				tbFunds.ForeColor = Color.Red;
				int FamFund = Convert.ToInt32(tbFunds.Text);
				string monee = Helper.HexString(FamFund);
				tbFunds.ForeColor = SystemColors.WindowText;

				sections++;
				Array.Resize(ref filedata, sections * 42);
				filedata[(currentsectionindex * 42)] = lotno;
				filedata[(currentsectionindex * 42) + 2] = meno;
				filedata[(currentsectionindex * 42) + 3] = ladyno;
				filedata[(currentsectionindex * 42) + 4] = boyno;
				filedata[(currentsectionindex * 42) + 5] = girlno;
				filedata[(currentsectionindex * 42) + 1] = (ushort)(
					filedata[(currentsectionindex * 42) + 2]
					+ filedata[(currentsectionindex * 42) + 3]
					+ filedata[(currentsectionindex * 42) + 4]
					+ filedata[(currentsectionindex * 42) + 5]
				);
				for (int j = 6; j < 42; j++)
				{
					filedata[(currentsectionindex * 42) + j] = 0;
				}

				filedata[(currentsectionindex * 42) + 33] = Convert.ToUInt16(
					monee.Substring(4, 4),
					16
				);
				filedata[(currentsectionindex * 42) + 34] = Convert.ToUInt16(
					monee.Substring(0, 4),
					16
				);
				filedata[(currentsectionindex * 42) + 35] = friendno;
				filedata[(currentsectionindex * 42) + 38] = 257; // oef marker
				if (filedata[(currentsectionindex * 42)] > 0)
				{
					goodsections++;
				}

				Wrapper.FVal = filedata;
				Wrapper.Sections = sections;
				CanCommit = true;
				RefreshGraphs();
				filimuptext();
				tbEditer.Visible = false;
				tbBlocks.Visible = gtname.Visible = true;
			}
			catch
			{
				lbInvalid.Visible = true;
			}
		}
	}
}
