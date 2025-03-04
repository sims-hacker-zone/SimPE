// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Windows.Forms;

using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Glob
{
	public partial class GlobCtrl : UserControl
	{
		public GlobCtrl()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Stores the currently active Wrapper
		/// </summary>
		internal IFileWrapperSaveExtension wrapper = null;

		#region GLOB
		private void GlobCommit(object sender, EventArgs e)
		{
			try
			{
				Glob wrp = (Glob)wrapper;
				wrp.SemiGlobalName = cbseminame.Text;
				wrp.FileName = tbfilenm.Text;
				lbBloat.Visible = lbBug.Visible = false;
				wrapper.SynchronizeUserData();
				MessageBox.Show(Localization.Manager.GetString("commited"));
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("errwritingfile"),
					ex
				);
			}
		}

		private void SemiGlobalChanged(object sender, EventArgs e)
		{
			if (cbseminame.Tag == null)
			{
				tbgroup.ForeColor = System.Drawing.SystemColors.WindowText;
				tbgroup.Text =
					"0x" + Helper.HexString(Hashes.GroupHash(cbseminame.Text));
				try
				{
					Glob wrp = (Glob)wrapper;
					wrp.SemiGlobalName = cbseminame.Text;
					wrapper.Changed = true;
				}
				catch (Exception ex)
				{
					Helper.ExceptionMessage("", ex);
				}
			}
		}

		private void tbfilenm_TextChanged(object sender, EventArgs e)
		{
			if (cbseminame.Tag == null)
			{
				try
				{
					Glob wrp = (Glob)wrapper;
					wrp.FileName = tbfilenm.Text;
					wrapper.Changed = true;
				}
				catch { }
			}
		}

		#endregion
	}
}
