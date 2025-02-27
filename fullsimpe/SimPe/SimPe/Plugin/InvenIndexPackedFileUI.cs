using System;

using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	public partial class InvenIndexPackedFileUI
		: Windows.Forms.WrapperBaseControl,
			IPackedFileUI
	{
		protected new InvenIndexPackedFileWrapper Wrapper => base.Wrapper as InvenIndexPackedFileWrapper;
		public InvenIndexPackedFileWrapper TPFW => (InvenIndexPackedFileWrapper)Wrapper;

		uint scinstance;

		#region WrapperBaseControl Member

		public InvenIndexPackedFileUI()
		{
			InitializeComponent();
		}

		protected override void RefreshGUI()
		{
			base.RefreshGUI();
			warnlbl.Visible = false;

			scinstance = Wrapper.Sciname;
			scinst.Text = "0x" + Helper.HexString(scinstance);
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
			this.TPFW.Dispose();
		}
		#endregion

		private void scinst_TextChanged(object sender, EventArgs e)
		{
			try
			{
				scinstance = Convert.ToUInt32(scinst.Text, 16);
				if (scinstance < 1)
				{
					scinstance = 1;
					scinst.Text = "0x00000001";
					warnlbl.Visible = true;
				}
				Wrapper.Sciname = scinstance;
				scinst.ForeColor = System.Drawing.SystemColors.WindowText;
				this.CanCommit = true;
			}
			catch
			{
				this.CanCommit = false;
				scinst.ForeColor = System.Drawing.Color.DarkRed;
			}
		}
	}
}
