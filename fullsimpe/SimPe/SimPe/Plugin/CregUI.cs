using System;

using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	/// <summary>
	/// This class is used to fill the UI for this FileType with Data
	/// </summary>
	public partial class CregPackedFileUI
		: Windows.Forms.WrapperBaseControl,
			IPackedFileUI
	{
		protected new CregPackedFileWrapper Wrapper => base.Wrapper as CregPackedFileWrapper;
		public CregPackedFileWrapper TPFW => (CregPackedFileWrapper)Wrapper;

		#region WrapperBaseControl Member

		bool intern;

		public CregPackedFileUI()
		{
			InitializeComponent();
		}

		protected override void RefreshGUI()
		{
			base.RefreshGUI();
			intern = true;
			if (Helper.WindowsRegistry.UseBigIcons)
			{
				rtbContent.Size = new System.Drawing.Size(
					530,
					rtbContent.Size.Height
				);
				rtbContent.Font = new System.Drawing.Font(
					rtbContent.Font.FontFamily,
					12F
				);
			}

			rtbContent.Text = "";
			tbGuid.Text = Wrapper.GooiVal;
			tbCrc.Text = Wrapper.CRCVal;
			tbVer.Text = Wrapper.VersVal;

			if (Wrapper.Vesion == 1)
			{
				CanCommit = false;
				rtbContent.Visible = true;
				for (int i = 0; i < Wrapper.Qunty; i++)
				{
					rtbContent.Text += Wrapper.Conent[i] + "\r\n";
				}
			}
			else
			{
				CanCommit = true;
				rtbContent.Visible = false;
			}
			intern = false;
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

		private void tbVer_TextChanged(object sender, EventArgs e)
		{
			if (!intern)
			{
				Wrapper.VersVal = tbVer.Text;
			}
		}
	}
}
