using System;

using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	public partial class AudioRefPackedFileUI
		: Windows.Forms.WrapperBaseControl,
			IPackedFileUI
	{
		protected new AudioRefPackedFileWrapper Wrapper => base.Wrapper as AudioRefPackedFileWrapper;
		public AudioRefPackedFileWrapper TPFW => Wrapper;

		#region WrapperBaseControl Member

		public AudioRefPackedFileUI()
		{
			InitializeComponent();
		}

		protected override void RefreshGUI()
		{
			base.RefreshGUI();

			TBsting.Text = Wrapper.Strung;
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

		private void TBsting_TextChanged(object sender, EventArgs e)
		{
			Wrapper.Strung = TBsting.Text;
		}
	}
}
