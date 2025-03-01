// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Scid
{
	public partial class ScidUI
		: Windows.Forms.WrapperBaseControl,
			IPackedFileUI
	{
		protected new Scid Wrapper => base.Wrapper as Scid;
		public Scid TPFW => Wrapper;

		#region WrapperBaseControl Member

		public ScidUI()
		{
			InitializeComponent();
		}

		protected override void RefreshGUI()
		{
			base.RefreshGUI();
			warnlbl.Visible = false;

			scinst.Text = "0x" + Helper.HexString(Wrapper.SCID);
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
				Wrapper.SCID = Convert.ToUInt16(scinst.Text, 16);
				if (Wrapper.SCID < 1)
				{
					Wrapper.SCID = 1;
					scinst.Text = "0x0001";
					warnlbl.Visible = true;
				}
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
