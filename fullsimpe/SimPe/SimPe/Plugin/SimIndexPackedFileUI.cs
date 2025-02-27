using System;

using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	public partial class SimindexPackedFileUI
		: Windows.Forms.WrapperBaseControl,
			IPackedFileUI
	{
		protected new SimindexPackedFileWrapper Wrapper => base.Wrapper as SimindexPackedFileWrapper;
		public SimindexPackedFileWrapper TPFW => (SimindexPackedFileWrapper)Wrapper;

		ushort scinstance;

		#region WrapperBaseControl Member

		public SimindexPackedFileUI()
		{
			InitializeComponent();
		}

		protected override void RefreshGUI()
		{
			base.RefreshGUI();
			warnlbl.Visible = false;

			scinstance = Wrapper.Sciname;
			scinst.Text = "0x" + Helper.HexString(scinstance);
			if (!Wrapper.IsOK)
			{
				desclbl.Text =
					"The Sim Creation Index\r\n Is only used in a Primary Neighourhood\r\nnot here!";
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

		private void scinst_TextChanged(object sender, EventArgs e)
		{
			try
			{
				scinstance = Convert.ToUInt16(scinst.Text, 16);
				if (scinstance < 1)
				{
					scinstance = 1;
					scinst.Text = "0x0001";
					warnlbl.Visible = true;
				}
				Wrapper.Sciname = scinstance;
				scinst.ForeColor = System.Drawing.SystemColors.WindowText;
				CanCommit = true;
			}
			catch
			{
				CanCommit = false;
				scinst.ForeColor = System.Drawing.Color.DarkRed;
			}
		}
	}
}
