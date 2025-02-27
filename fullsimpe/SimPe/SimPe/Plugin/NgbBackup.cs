/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
using System;
using System.Windows.Forms;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for NgbBackup.
	/// </summary>
	public class NgbBackup : Form
	{
		private ListBox lbdirs;
		private Button button1;
		private Button button2;
		private Panel pnNice;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NgbBackup()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				components?.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(typeof(NgbBackup));
			lbdirs = new ListBox();
			button1 = new Button();
			button2 = new Button();
			pnNice = new Panel();
			pnNice.SuspendLayout();
			SuspendLayout();
			//
			// lbdirs
			//
			resources.ApplyResources(lbdirs, "lbdirs");
			lbdirs.Name = "lbdirs";
			lbdirs.SelectedIndexChanged += new EventHandler(
				SelectBackup
			);
			//
			// button1
			//
			resources.ApplyResources(button1, "button1");
			button1.Name = "button1";
			button1.Click += new EventHandler(Restore);
			//
			// button2
			//
			resources.ApplyResources(button2, "button2");
			button2.Name = "button2";
			button2.Click += new EventHandler(Delete);
			//
			// pnNice
			//
			pnNice.BackColor = System.Drawing.Color.Transparent;
			pnNice.Controls.Add(button2);
			pnNice.Controls.Add(button1);
			pnNice.Controls.Add(lbdirs);
			resources.ApplyResources(pnNice, "pnNice");
			pnNice.Name = "pnNice";
			//
			// NgbBackup
			//
			resources.ApplyResources(this, "$this");
			Controls.Add(pnNice);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Name = "NgbBackup";
			ShowInTaskbar = false;
			pnNice.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion

		string path;
		string backuppath;

		protected void UpdateList()
		{
			lbdirs.Items.Clear();
			if (System.IO.Directory.Exists(backuppath))
			{
				string[] dirs = System.IO.Directory.GetDirectories(backuppath, "*");
				foreach (string dir in dirs)
				{
					lbdirs.Items.Add(System.IO.Path.GetFileName(dir));
				}
			}
		}

		Interfaces.Files.IPackageFile package;
		Interfaces.IProviderRegistry prov;

		public void Execute(
			string path,
			Interfaces.Files.IPackageFile package,
			Interfaces.IProviderRegistry prov,
			string lable
		)
		{
			this.path = path;
			this.package = package;
			this.prov = prov;

			string name = System.IO.Path.GetFileName(path);
			if (lable != "")
			{
				name = lable + "_" + name;
			}

			long grp = PathProvider.Global.SaveGamePathProvidedByGroup(path);
			if (grp > 1)
			{
				name = grp.ToString() + "_" + name;
			}

			backuppath = System.IO.Path.Combine(PathProvider.Global.BackupFolder, name);

			UpdateList();

			ShowDialog();
		}

		private void SelectBackup(object sender, EventArgs e)
		{
			button1.Enabled = lbdirs.SelectedIndex >= 0;
			button2.Enabled = button1.Enabled;
		}

		private void Restore(object sender, EventArgs e)
		{
			if (lbdirs.SelectedIndex < 0)
			{
				return;
			}

			prov.SimDescriptionProvider.BasePackage = null;
			prov.SimFamilynameProvider.BasePackage = null;
			prov.SimNameProvider.BaseFolder = null;
			DialogResult dr = MessageBox.Show(
				Localization.Manager.GetString("backuprestore"),
				Localization.Manager.GetString("backup?"),
				MessageBoxButtons.YesNoCancel
			);
			if (dr != DialogResult.Cancel)
			{
				Packages.StreamFactory.CloseAll();
				Cursor = Cursors.WaitCursor;
				WaitingScreen.Wait();

				try
				{
					string source = System.IO.Path.Combine(
						backuppath,
						lbdirs.Items[lbdirs.SelectedIndex].ToString()
					);

					if (dr == DialogResult.Yes)
					{
						//create backup of current
						string newback = System.IO.Path.Combine(
							backuppath,
							"(automatic) "
								+ DateTime
									.Now.ToString()
									.Replace("\\", "-")
									.Replace(":", "-")
									.Replace(".", "-")
						);
						if (!System.IO.Directory.Exists(newback))
						{
							System.IO.Directory.CreateDirectory(newback);
						}

						Helper.CopyDirectory(path, newback, true);
					}

					//remove the Neighborhood
					try
					{
						Packages.PackageMaintainer.Maintainer.RemovePackagesInPath(
							path
						);
						System.IO.Directory.Delete(path, true);
					}
					catch (Exception) { }

					//copy the backup
					System.IO.Directory.CreateDirectory(path);
					Helper.CopyDirectory(source, path, true);

					UpdateList();
					WaitingScreen.Stop(this);
					MessageBox.Show("The backup was restored succesfully!");
				}
				catch (Exception ex)
				{
					Helper.ExceptionMessage("", ex);
				}
				finally
				{
					WaitingScreen.Stop();
					Cursor = Cursors.Default;
				}
			}
		}

		private void Delete(object sender, EventArgs e)
		{
			if (lbdirs.SelectedIndex < 0)
			{
				return;
			}

			string source = System.IO.Path.Combine(
				backuppath,
				lbdirs.Items[lbdirs.SelectedIndex].ToString()
			);
			if (
				MessageBox.Show(
					Localization
						.Manager.GetString("backupdelete")
						.Replace("{0}", source),
					Localization.Manager.GetString("delete?"),
					MessageBoxButtons.YesNo
				) == DialogResult.Yes
			)
			{
				Cursor = Cursors.WaitCursor;

				if (System.IO.Directory.Exists(source))
				{
					System.IO.Directory.Delete(source, true);
				}

				UpdateList();
				Cursor = Cursors.Default;
			}
		}
	}
}
