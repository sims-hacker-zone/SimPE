// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.IO;
using System.Windows.Forms;

namespace SimPe
{
	public partial class ProfileChooser : Form
	{
		public ProfileChooser()
		{
			InitializeComponent();
		}

		public string Value => cbProfiles.Text;

		private void ProfileChooser_Activated(object sender, EventArgs e)
		{
			cbProfiles.BeginUpdate();
			cbProfiles.Items.Clear();
			foreach (
				string s in Directory.GetDirectories(Helper.DataFolder.Profiles)
			)
			{
				cbProfiles.Items.Add(Path.GetFileName(s));
			}

			cbProfiles.EndUpdate();

			btnOK.Enabled = false;
		}

		private void ProfileChooser_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (
				e.CloseReason != CloseReason.UserClosing
				&& e.CloseReason != CloseReason.None
			)
			{
				return;
			}

			if (DialogResult != DialogResult.OK)
			{
				return;
			}

			cbProfiles.Text = cbProfiles.Text.Trim();
			if (cbProfiles.Text.Length == 0)
			{
				e.Cancel = true;
				return;
			}

			string path = Path.Combine(Helper.DataFolder.Profiles, cbProfiles.Text);
			if (!Directory.Exists(path))
			{ /* // Removed at Inge's request
                if (MessageBox.Show(
                    Localization.GetString("spOKCancelCreate")
                    , Localization.GetString("spCreate")
                    , MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.OK) e.Cancel = true;
                else
              */
				try
				{
					Directory.CreateDirectory(path);
				}
				catch (Exception ex)
				{
					MessageBox.Show(
						ex.Message,
						Localization.GetString("spCreate"),
						MessageBoxButtons.OK,
						MessageBoxIcon.Error
					);
					e.Cancel = true;
				}
			}
			else if (
				MessageBox.Show(
					Localization.GetString("spOKCancelExists"),
					Localization.GetString("spExists"),
					MessageBoxButtons.OKCancel,
					MessageBoxIcon.Question,
					MessageBoxDefaultButton.Button1
				) != DialogResult.OK
			)
			{
				e.Cancel = true;
			}
		}

		private void cbProfiles_TextChanged(object sender, EventArgs e)
		{
			btnOK.Enabled = cbProfiles.Text.Trim().Length != 0;
		}
	}
}
