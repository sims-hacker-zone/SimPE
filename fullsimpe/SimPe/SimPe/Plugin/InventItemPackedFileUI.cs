using System;

using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	/// <summary>
	/// This class is used to fill the UI for this FileType with Data
	/// </summary>
	public partial class InventItemPackedFileUI
		: Windows.Forms.WrapperBaseControl,
			IPackedFileUI
	{
		protected new InventItemPackedFileWrapper Wrapper => base.Wrapper as InventItemPackedFileWrapper;
		public InventItemPackedFileWrapper TPFW => (InventItemPackedFileWrapper)Wrapper;

		#region WrapperBaseControl Member

		public InventItemPackedFileUI()
		{
			InitializeComponent();
		}

		protected override void RefreshGUI()
		{
			base.RefreshGUI();
			this.lbdisp.Text = Wrapper.DispLabel;
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
			this.TPFW.Dispose();
		}
		#endregion
	}
}
