using System;
using System.Drawing;

using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	public partial class SimmyListPackedFileUI
		: SimPe.Windows.Forms.WrapperBaseControl,
			IPackedFileUI
	{
		protected new SimmyListPackedFileWrapper Wrapper => base.Wrapper as SimmyListPackedFileWrapper;
		public SimmyListPackedFileWrapper TPFW => (SimmyListPackedFileWrapper)Wrapper;

		#region WrapperBaseControl Member

		public SimmyListPackedFileUI()
		{
			InitializeComponent();
		}

		protected override void RefreshGUI()
		{
			base.RefreshGUI();

			this.checkBox1.Checked = false;
			this.TBsting.Text = Wrapper.Strung;
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
			this.TPFW.Dispose();
		}
		#endregion

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked == true)
			{
				this.TBsting.Text = Wrapper.Twine;
			}
			else
			{
				this.TBsting.Text = Wrapper.Strung;
			}

			this.TBsting.Refresh();
		}
	}
}
