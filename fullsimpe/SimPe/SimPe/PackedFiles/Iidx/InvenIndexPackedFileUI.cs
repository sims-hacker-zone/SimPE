// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Iidx;

namespace SimPe.PackedFiles.Iidx
{
	public partial class InvenIndexPackedFileUI
		: Windows.Forms.WrapperBaseControl,
			IPackedFileUI
	{
		protected new InvenIndexPackedFileWrapper Wrapper => base.Wrapper as InvenIndexPackedFileWrapper;
		public InvenIndexPackedFileWrapper TPFW => Wrapper;

		uint scinstance;

		#region WrapperBaseControl Member

		public InvenIndexPackedFileUI()
		{
			InitializeComponent();
		}

		protected override void RefreshGUI()
		{
			base.RefreshGUI();
			warnlbl.Visible = false;

			scinstance = Wrapper.Sciname;
			scinst.Text = "0x" + Helper.HexString(scinstance);
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
				scinstance = Convert.ToUInt32(scinst.Text, 16);
				if (scinstance < 1)
				{
					scinstance = 1;
					scinst.Text = "0x00000001";
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
