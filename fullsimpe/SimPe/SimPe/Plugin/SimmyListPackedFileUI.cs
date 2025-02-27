using System;

using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	public partial class SimmyListPackedFileUI
		: Windows.Forms.WrapperBaseControl,
			IPackedFileUI
	{
		protected new SimmyListPackedFileWrapper Wrapper => base.Wrapper as SimmyListPackedFileWrapper;
		public SimmyListPackedFileWrapper TPFW => Wrapper;

		#region WrapperBaseControl Member

		public SimmyListPackedFileUI()
		{
			InitializeComponent();
		}

		protected override void RefreshGUI()
		{
			base.RefreshGUI();

			checkBox1.Checked = false;
			TBsting.Text = Wrapper.Strung;
		}

		public override void OnCommit()
		{
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

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked == true)
			{
				TBsting.Text = Wrapper.Twine;
			}
			else
			{
				TBsting.Text = Wrapper.Strung;
			}

			TBsting.Refresh();
		}
	}
}
