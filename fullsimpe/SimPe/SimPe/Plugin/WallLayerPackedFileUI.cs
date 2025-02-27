using System;
using System.Collections.Generic;
using System.IO;

using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	/// <summary>
	/// This class is used to fill the UI for this FileType with Data
	/// </summary>
	public partial class WallLayerPackedFileUI
		: Windows.Forms.WrapperBaseControl,
			IPackedFileUI
	{
		protected new WallLayerPackedFileWrapper Wrapper => base.Wrapper as WallLayerPackedFileWrapper;
		public WallLayerPackedFileWrapper TPFW => Wrapper;

		#region WrapperBaseControl Member

		public WallLayerPackedFileUI()
		{
			InitializeComponent();

			string es = Data.MetaData.GetKnownFence(0x8D0B3B3A); // to intialize the dictionary
			foreach (KeyValuePair<uint, string> kvp in Data.MetaData.KnownFences)
			{
				cballFences.Items.Add(kvp.Value);
			}

			cballFences.SelectedIndex = 0;
		}

		private string simtools = Helper.SimPePath + "\\Sims2Tools.exe";

		protected override void RefreshGUI()
		{
			base.RefreshGUI();

			if (File.Exists(simtools))
			{
				lbConvwals.Visible = false;
				llConvwals.Visible = true;
			}
			else
			{
				lbConvwals.Visible = true;
				llConvwals.Visible = false;
			}

			int normal = 0;
			int picket = 0;
			int attic = 0;
			int nrskirt = 0;
			int redskirt = 0;
			int foundation = 0;
			int minskirt = 0;
			int woodfence = 0;
			int pool = 0;
			int unlevel = 0;
			int unlpool = 0;
			int ofbnormal = 0;
			int screenwood = 0;
			int fences = 0;
			int walls = 0;

			cbExistFences.Items.Clear();
			for (int i = 0; i < Wrapper.ItemCount; i++)
			{
				if (Data.MetaData.KnownFences.ContainsKey(Wrapper.bwallid[i]))
				{
					if (
						!cbExistFences.Items.Contains(
							Data.MetaData.GetKnownFence(Wrapper.bwallid[i])
						)
					)
					{
						cbExistFences.Items.Add(
							Data.MetaData.GetKnownFence(Wrapper.bwallid[i])
						);
					}

					fences++;
				}
				else if (KnownWallID(Wrapper.bwallid[i]))
				{
					if (Wrapper.bwallid[i] == 1)
					{
						normal++;
					}

					if (Wrapper.bwallid[i] == 2)
					{
						picket++;
					}

					if (Wrapper.bwallid[i] == 3)
					{
						attic++;
					}

					if (Wrapper.bwallid[i] == 4)
					{
						nrskirt++;
					}

					if (Wrapper.bwallid[i] == 16)
					{
						redskirt++;
					}

					if (Wrapper.bwallid[i] == 23)
					{
						foundation++;
					}

					if (Wrapper.bwallid[i] == 24)
					{
						minskirt++;
					}

					if (Wrapper.bwallid[i] == 26)
					{
						woodfence++;
					}

					if (Wrapper.bwallid[i] == 29)
					{
						pool++;
					}

					if (Wrapper.bwallid[i] == 90)
					{
						unlevel++;
					}

					if (Wrapper.bwallid[i] == 93)
					{
						unlpool++;
					}

					if (Wrapper.bwallid[i] == 300)
					{
						ofbnormal++;
					}

					if (Wrapper.bwallid[i] == 301)
					{
						screenwood++;
					}

					walls++;
				}
				else
				{
					if (
						!cbExistFences.Items.Contains(
							"0x" + Helper.HexString(Wrapper.bwallid[i])
						)
					)
					{
						cbExistFences.Items.Add(
							"0x" + Helper.HexString(Wrapper.bwallid[i])
						);
					}

					fences++;
				}
			}
			if (cbExistFences.Items.Count > 0)
			{
				cbExistFences.SelectedIndex = 0;
			}

			if (fences == 0)
			{
				cbClear.Visible =
					lbwarning.Visible =
					btchanger.Visible =
						false;
			}
			else
			{
				cbClear.Visible =
					lbwarning.Visible =
					btchanger.Visible =
						true;
			}

			lbNormal.Text = Convert.ToString(normal) + " normal walls";
			lbpicket.Text = Convert.ToString(picket) + " picket rail fences";
			lbattic.Text = Convert.ToString(attic) + " attic walls";
			lbnrskirt.Text = Convert.ToString(nrskirt) + " non-rendered deck skirts";
			lbredskirt.Text = Convert.ToString(redskirt) + " deck skirts (redwood)";
			lbfoundation.Text = Convert.ToString(foundation) + " foundation walls";
			lbminskirt.Text = Convert.ToString(minskirt) + " deck skirts (minimal)";
			lbwoodfence.Text = Convert.ToString(woodfence) + " deck aged wood fences";
			lbpool.Text = Convert.ToString(pool) + " pool walls";
			lbunlevel.Text = Convert.ToString(unlevel) + " un-level terrain walls";
			lbunlpool.Text = Convert.ToString(unlpool) + " un-level pool walls";
			lbofbnormal.Text =
				Convert.ToString(ofbnormal) + " abnormal walls (OFB only)";
			lbscreenwood.Text =
				Convert.ToString(screenwood) + " screen wood (OFB or later)";
			lbunlevel.Visible = (unlevel > 0);
			lbunlpool.Visible = (unlpool > 0);
			lbofbnormal.Visible = (ofbnormal > 0);
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

		private bool KnownWallID(uint uWallID)
		{
			if (
				(uWallID == 1) // normal wall
				|| (uWallID == 2) // picket rail fence
				|| (uWallID == 3) // attic wall
				|| (uWallID == 4) // non-rendered deck skirt
				|| (uWallID == 16) // deck skirt (redwood)
				|| (uWallID == 23) // foundation wall (brick)
				|| (uWallID == 24) // deck skirt (minimal)
				|| (uWallID == 26) // deck aged wood fence arch
				|| (uWallID == 29) // pool wall
				|| (uWallID == 90) // un-leveled terrain walls
				|| (uWallID == 93) // un-leveled pool walls
				|| (uWallID == 300) // normal wall (OFB or later)
				|| (uWallID == 301) // screen wood (OFB or later)
			)
			{
				return true;
			}

			return false;
		}

		private void cbExistFences_SelectedIndexChanged(object sender, EventArgs e)
		{
			btchanger.Enabled = (
				cbExistFences.SelectedIndex != -1
				&& cballFences.SelectedIndex != -1
				&& cbExistFences.SelectedItem != cballFences.SelectedItem
			);
		}

		private void cballFences_SelectedIndexChanged(object sender, EventArgs e)
		{
			btchanger.Enabled = (
				cbExistFences.SelectedIndex != -1
				&& cballFences.SelectedIndex != -1
				&& cbExistFences.SelectedItem != cballFences.SelectedItem
			);
		}

		private void btchanger_Click(object sender, EventArgs e)
		{
			uint bfrom;
			if (Data.MetaData.GetFenceId(cbExistFences.SelectedItem) != 0)
			{
				bfrom = Data.MetaData.GetFenceId(cbExistFences.SelectedItem);
			}
			else
			{
				bfrom = Helper.HexStringToUInt(
					Convert.ToString(cbExistFences.SelectedItem)
				);
			}

			uint btoo = Data.MetaData.GetFenceId(cballFences.SelectedItem);
			for (int j = 0; j < Wrapper.ItemCount; j++)
			{
				if (Wrapper.bwallid[j] == bfrom)
				{
					Wrapper.bwallid[j] = btoo;
					if (cbClear.Checked)
					{
						Wrapper.lpaint[j] = Wrapper.rpaint[j] = 0;
					}
				}
			}

			cbExistFences.Items.Clear();
			for (int i = 0; i < Wrapper.ItemCount; i++)
			{
				if (Data.MetaData.KnownFences.ContainsKey(Wrapper.bwallid[i]))
				{
					if (
						!cbExistFences.Items.Contains(
							Data.MetaData.GetKnownFence(Wrapper.bwallid[i])
						)
					)
					{
						cbExistFences.Items.Add(
							Data.MetaData.GetKnownFence(Wrapper.bwallid[i])
						);
					}
				}
				else
				{
					if (
						!cbExistFences.Items.Contains(
							"0x" + Helper.HexString(Wrapper.bwallid[i])
						) && !KnownWallID(Wrapper.bwallid[i])
					)
					{
						cbExistFences.Items.Add(
							"0x" + Helper.HexString(Wrapper.bwallid[i])
						);
					}
				}
			}
			cbExistFences.SelectedIndex = 0;
		}

		private void llConvwals_LinkClicked(
			object sender,
			System.Windows.Forms.LinkLabelLinkClickedEventArgs e
		)
		{
			if (File.Exists(simtools))
			{
				System.Diagnostics.Process p = new System.Diagnostics.Process();
				p.StartInfo.FileName = simtools;
				p.Start();
			}
		}
	}
}
