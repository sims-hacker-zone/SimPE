using System;

using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	public partial class SimpleTextPackedFileUI
		: Windows.Forms.WrapperBaseControl,
			IPackedFileUI
	{
		protected new SimpleTextPackedFileWrapper Wrapper => base.Wrapper as SimpleTextPackedFileWrapper;
		public SimpleTextPackedFileWrapper TPFW => (SimpleTextPackedFileWrapper)Wrapper;

		#region WrapperBaseControl Member

		public SimpleTextPackedFileUI()
		{
			InitializeComponent();
		}

		protected override void RefreshGUI()
		{
			base.RefreshGUI();

			this.TBsting.Text = Wrapper.Strung;
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

		private void TBsting_TextChanged(object sender, EventArgs e)
		{
			Wrapper.Strung = TBsting.Text;
		}
	}
}
