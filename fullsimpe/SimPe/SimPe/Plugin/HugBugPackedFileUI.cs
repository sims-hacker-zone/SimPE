// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	/// <summary>
	/// This class is used to fill the UI for this FileType with Data
	/// </summary>
	public partial class HugBugPackedFileUI
		: Windows.Forms.WrapperBaseControl,
			IPackedFileUI
	{
		protected new HugBugPackedFileWrapper Wrapper => base.Wrapper as HugBugPackedFileWrapper;
		public HugBugPackedFileWrapper TPFW => Wrapper;

		#region WrapperBaseControl Member

		public HugBugPackedFileUI()
		{
			InitializeComponent();
		}

		protected override void RefreshGUI()
		{
			base.RefreshGUI();
			TBsting.Text =
				"There is "
				+ Convert.ToString(Wrapper.isz)
				+ " Items in this List,\n Press 'Show All Items' to display them all"; // clear previous values
			if (Wrapper.HasCustom)
			{
				TBsting.Text +=
					"\n Press 'Show Only CC' to display Items not in the pjse GUIDIndex";
			}

			if (Wrapper.IsSims)
			{
				TBsting.Text =
					"This Lot has sim(s) on it.\n\n" + TBsting.Text;
			}

			btcustom.Visible = btcustom.Enabled = Wrapper.HasCustom;
			btShow.Enabled = true;
			if (Wrapper.IsCorrupt)
			{
				label1.Text = "Super Duper Hug Found !!";
				lbFail.Visible = true;
				lbpass.Visible = false;
			}
			else
			{
				label1.Text = "This Lot is Clean";
				lbFail.Visible = false;
				lbpass.Visible = true;
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

		private void btShow_Click(object sender, EventArgs e)
		{
			btShow.Enabled = false;
			btcustom.Enabled = Wrapper.HasCustom;
			TBsting.Text = "";
			for (int i = 0; i < Wrapper.isz; i++)
			{
				TBsting.Text += Wrapper.objekts[i];
			}
		}

		private void btcustom_Click(object sender, EventArgs e)
		{
			btcustom.Enabled = false;
			btShow.Enabled = true;
			TBsting.Text = "";
			for (int i = 0; i < Wrapper.isz; i++)
			{
				if (Wrapper.objekts[i].Contains("**"))
				{
					TBsting.Text += Wrapper.objekts[i];
				}
			}

			if (TBsting.Text == "")
			{
				TBsting.Text = " This Lot is CC Free"; // Should never be seen
			}
		}
	}
}
