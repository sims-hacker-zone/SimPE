using System;
using System.Media;
using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	/// <summary>
	/// This class is used to fill the UI for this FileType with Data
	/// </summary>
	public partial class HugBugPackedFileUI
		: SimPe.Windows.Forms.WrapperBaseControl,
			IPackedFileUI
	{
		protected new HugBugPackedFileWrapper Wrapper
		{
			get { return base.Wrapper as HugBugPackedFileWrapper; }
		}
		public HugBugPackedFileWrapper TPFW
		{
			get { return (HugBugPackedFileWrapper)Wrapper; }
		}

		#region WrapperBaseControl Member

		public HugBugPackedFileUI()
		{
			InitializeComponent();
		}

		protected override void RefreshGUI()
		{
			base.RefreshGUI();
			this.TBsting.Text =
				"There is "
				+ Convert.ToString(Wrapper.isz)
				+ " Items in this List,\n Press 'Show All Items' to display them all"; // clear previous values
			if (Wrapper.HasCustom)
				this.TBsting.Text +=
					"\n Press 'Show Only CC' to display Items not in the pjse GUIDIndex";
			if (Wrapper.IsSims)
				this.TBsting.Text =
					"This Lot has sim(s) on it.\n\n" + this.TBsting.Text;
			this.btcustom.Visible = this.btcustom.Enabled = Wrapper.HasCustom;
			this.btShow.Enabled = true;
			if (Wrapper.IsCorrupt)
			{
				this.label1.Text = "Super Duper Hug Found !!";
				this.lbFail.Visible = true;
				this.lbpass.Visible = false;
			}
			else
			{
				this.label1.Text = "This Lot is Clean";
				this.lbFail.Visible = false;
				this.lbpass.Visible = true;
			}
		}

		public override void OnCommit()
		{
			// base.OnCommit();
			// TPFW.SynchronizeUserData(true, false);
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

		private void btShow_Click(object sender, EventArgs e)
		{
			this.btShow.Enabled = false;
			this.btcustom.Enabled = Wrapper.HasCustom;
			this.TBsting.Text = "";
			for (int i = 0; i < Wrapper.isz; i++)
				this.TBsting.Text += Wrapper.objekts[i];
		}

		private void btcustom_Click(object sender, EventArgs e)
		{
			this.btcustom.Enabled = false;
			this.btShow.Enabled = true;
			this.TBsting.Text = "";
			for (int i = 0; i < Wrapper.isz; i++)
				if (Wrapper.objekts[i].Contains("**"))
					this.TBsting.Text += Wrapper.objekts[i];
			if (this.TBsting.Text == "")
				this.TBsting.Text = " This Lot is CC Free"; // Should never be seen
		}
	}
}
