// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Pops;

namespace SimPe.PackedFiles.Pops
{
	public partial class SimmyListPackedFileUI
		: Windows.Forms.WrapperBaseControl,
			IPackedFileUI
	{
		protected new SimListPackedFileWrapper Wrapper => base.Wrapper as SimListPackedFileWrapper;
		public SimListPackedFileWrapper TPFW => Wrapper;

		#region WrapperBaseControl Member

		public SimmyListPackedFileUI()
		{
			InitializeComponent();
		}

		protected override void RefreshGUI()
		{
			base.RefreshGUI();

			checkBox1.Checked = false;
			TBsting.Text = Wrapper.DisplayString;
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
			TBsting.Text = checkBox1.Checked ? Wrapper.DisplayStringAll : Wrapper.DisplayString;

			TBsting.Refresh();
		}
	}
}
