using System;
using System.Drawing;

using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	public partial class SimpleTextPackedFileUI
		: SimPe.Windows.Forms.WrapperBaseControl,
			IPackedFileUI
	{
		protected new SimpleTextPackedFileWrapper Wrapper
		{
			get
			{
				return base.Wrapper as SimpleTextPackedFileWrapper;
			}
		}
		public SimpleTextPackedFileWrapper TPFW
		{
			get
			{
				return (SimpleTextPackedFileWrapper)Wrapper;
			}
		}

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
		System.Windows.Forms.Control IPackedFileUI.GUIHandle
		{
			get
			{
				return this;
			}
		}
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
