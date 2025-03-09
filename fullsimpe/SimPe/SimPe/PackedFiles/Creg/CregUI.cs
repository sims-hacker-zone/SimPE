// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Creg;

namespace SimPe.PackedFiles.Creg
{
	/// <summary>
	/// This class is used to fill the UI for this FileType with Data
	/// </summary>
	public partial class CregUI
		: Windows.Forms.WrapperBaseControl,
			IPackedFileUI
	{
		protected new Creg Wrapper => base.Wrapper as Creg;
		public Creg TPFW => Wrapper;

		#region WrapperBaseControl Member

		bool intern;

		public CregUI()
		{
			InitializeComponent();
		}

		protected override void RefreshGUI()
		{
			base.RefreshGUI();
			intern = true;
			if (Helper.WindowsRegistry.Config.UseBigIcons)
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
