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

namespace SimPe.Packages
{
	/// <summary>
	/// Summary description for SaveSims2CommunityPack.
	/// </summary>
	internal class SaveSims2Pack : Form
	{
		private ListBox lblist;
		private GroupBox gbsettings;
		private Label label5;
		private TextBox tbdesc;
		private OpenFileDialog ofd;
		private Label label6;
		internal TextBox tbflname;
		private SaveFileDialog sfd;
		private Button btdelete;
		private Button button4;
		private Button btadd;
		private Button btbrowse;
		private Button btsave;
		private Label label9;
		private TextBox tbname;
		private Panel panel1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SaveSims2Pack()
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
				if (components != null)
				{
					components.Dispose();
				}
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
				new System.ComponentModel.ComponentResourceManager(
					typeof(SaveSims2Pack)
				);
			this.lblist = new ListBox();
			this.gbsettings = new GroupBox();
			this.tbname = new TextBox();
			this.tbdesc = new TextBox();
			this.label5 = new Label();
			this.label9 = new Label();
			this.btadd = new Button();
			this.ofd = new OpenFileDialog();
			this.label6 = new Label();
			this.tbflname = new TextBox();
			this.btbrowse = new Button();
			this.sfd = new SaveFileDialog();
			this.btdelete = new Button();
			this.btsave = new Button();
			this.button4 = new Button();
			this.panel1 = new Panel();
			this.gbsettings.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			//
			// lblist
			//
			this.lblist.Anchor = (
				(AnchorStyles)(
					(
						(
							System.Windows.Forms.AnchorStyles.Top
							| System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.lblist.IntegralHeight = false;
			this.lblist.Location = new System.Drawing.Point(8, 40);
			this.lblist.Name = "lblist";
			this.lblist.Size = new System.Drawing.Size(560, 180);
			this.lblist.TabIndex = 2;
			this.lblist.SelectedIndexChanged += new EventHandler(this.Select);
			//
			// gbsettings
			//
			this.gbsettings.Anchor = (
				(AnchorStyles)(
					(
						(
							System.Windows.Forms.AnchorStyles.Top
							| System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.gbsettings.BackColor = System.Drawing.Color.Transparent;
			this.gbsettings.Controls.Add(this.tbname);
			this.gbsettings.Controls.Add(this.tbdesc);
			this.gbsettings.Controls.Add(this.label5);
			this.gbsettings.Controls.Add(this.label9);
			this.gbsettings.Enabled = false;
			this.gbsettings.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.gbsettings.Location = new System.Drawing.Point(8, 244);
			this.gbsettings.Name = "gbsettings";
			this.gbsettings.Size = new System.Drawing.Size(560, 176);
			this.gbsettings.TabIndex = 1;
			this.gbsettings.TabStop = false;
			this.gbsettings.Text = "Settings";
			//
			// tbname
			//
			this.tbname.Anchor = (
				(AnchorStyles)(
					(
						(
							System.Windows.Forms.AnchorStyles.Top
							| System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.tbname.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.tbname.Location = new System.Drawing.Point(16, 144);
			this.tbname.Name = "tbname";
			this.tbname.ReadOnly = true;
			this.tbname.Size = new System.Drawing.Size(528, 21);
			this.tbname.TabIndex = 11;
			//
			// tbdesc
			//
			this.tbdesc.Anchor = (
				(AnchorStyles)(
					(
						(
							System.Windows.Forms.AnchorStyles.Top
							| System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.tbdesc.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.tbdesc.Location = new System.Drawing.Point(16, 40);
			this.tbdesc.Multiline = true;
			this.tbdesc.Name = "tbdesc";
			this.tbdesc.Size = new System.Drawing.Size(528, 78);
			this.tbdesc.TabIndex = 14;
			this.tbdesc.TextChanged += new EventHandler(this.ChangeText);
			//
			// label5
			//
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label5.Location = new System.Drawing.Point(8, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(76, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "Description:";
			//
			// label9
			//
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label9.Location = new System.Drawing.Point(8, 128);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(63, 13);
			this.label9.TabIndex = 15;
			this.label9.Text = "File Name";
			//
			// btadd
			//
			this.btadd.BackColor = System.Drawing.Color.Transparent;
			this.btadd.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btadd.Location = new System.Drawing.Point(415, 222);
			this.btadd.Name = "btadd";
			this.btadd.Size = new System.Drawing.Size(72, 23);
			this.btadd.TabIndex = 4;
			this.btadd.Text = "Add...";
			this.btadd.UseVisualStyleBackColor = false;
			this.btadd.Click += new EventHandler(this.AddPackage);
			//
			// ofd
			//
			this.ofd.Filter =
				"Sims 2 Package (*.package)|*.package|All Files (*.*)|*.*";
			//
			// label6
			//
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label6.Location = new System.Drawing.Point(8, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(72, 13);
			this.label6.TabIndex = 3;
			this.label6.Text = "FileName:";
			//
			// tbflname
			//
			this.tbflname.Anchor = (
				(AnchorStyles)(
					(
						(
							System.Windows.Forms.AnchorStyles.Top
							| System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.tbflname.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.tbflname.Location = new System.Drawing.Point(80, 8);
			this.tbflname.Name = "tbflname";
			this.tbflname.Size = new System.Drawing.Size(407, 21);
			this.tbflname.TabIndex = 0;
			//
			// btbrowse
			//
			this.btbrowse.BackColor = System.Drawing.Color.Transparent;
			this.btbrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btbrowse.Location = new System.Drawing.Point(493, 8);
			this.btbrowse.Name = "btbrowse";
			this.btbrowse.Size = new System.Drawing.Size(75, 23);
			this.btbrowse.TabIndex = 1;
			this.btbrowse.Text = "Browse...";
			this.btbrowse.UseVisualStyleBackColor = false;
			this.btbrowse.Click += new EventHandler(this.S2CPFilename);
			//
			// btdelete
			//
			this.btdelete.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.btdelete.BackColor = System.Drawing.Color.Transparent;
			this.btdelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btdelete.Location = new System.Drawing.Point(493, 222);
			this.btdelete.Name = "btdelete";
			this.btdelete.Size = new System.Drawing.Size(75, 23);
			this.btdelete.TabIndex = 3;
			this.btdelete.Text = "Remove...";
			this.btdelete.UseVisualStyleBackColor = false;
			this.btdelete.Click += new EventHandler(this.DeletePackage);
			//
			// btsave
			//
			this.btsave.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Bottom
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.btsave.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btsave.Location = new System.Drawing.Point(493, 434);
			this.btsave.Name = "btsave";
			this.btsave.Size = new System.Drawing.Size(75, 23);
			this.btsave.TabIndex = 16;
			this.btsave.Text = "Save";
			this.btsave.Click += new EventHandler(this.button3_Click);
			//
			// button4
			//
			this.button4.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Bottom
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button4.Location = new System.Drawing.Point(412, 434);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 17;
			this.button4.Text = "Cancel";
			this.button4.Click += new EventHandler(this.button4_Click);
			//
			// panel1
			//
			this.panel1.Anchor = (
				(AnchorStyles)(
					(
						(
							(
								System.Windows.Forms.AnchorStyles.Top
								| System.Windows.Forms.AnchorStyles.Bottom
							) | System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.panel1.Controls.Add(this.button4);
			this.panel1.Controls.Add(this.btsave);
			this.panel1.Controls.Add(this.btdelete);
			this.panel1.Controls.Add(this.btbrowse);
			this.panel1.Controls.Add(this.tbflname);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.btadd);
			this.panel1.Controls.Add(this.gbsettings);
			this.panel1.Controls.Add(this.lblist);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(578, 460);
			this.panel1.TabIndex = 18;
			//
			// SaveSims2Pack
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(576, 460);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SaveSims2Pack";
			this.ShowInTaskbar = false;
			this.Text = "Sims 2 Pack File Browser";
			this.Load += new EventHandler(this.SaveSims2CommunityPack_Load);
			this.Closing += new System.ComponentModel.CancelEventHandler(
				this.AllowClose
			);
			this.gbsettings.ResumeLayout(false);
			this.gbsettings.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
		}
		#endregion

		/// <summary>
		/// true if the communit Extensions should be used
		/// </summary>
		bool extension;

		/// <summary>
		/// true if the File should be saved
		/// </summary>
		bool ok;

		/// <summary>
		/// Shows the Save Dialog
		/// </summary>
		/// <param name="files">all packages that should be initially in the File</param>
		/// <param name="extension">true if you want to add the Community Extension, otherwise
		/// a normal Sims2Pack File will be generated</param>
		/// <returns>A list of all packages this File should contain</returns>
		public S2CPDescriptor[] Execute(
			GeneratableFile[] files,
			ref bool extension
		)
		{
			this.extension = extension;
			ok = false;

			S2CPDescriptor[] s2cps = new S2CPDescriptor[files.Length];
			for (int i = 0; i < files.Length; i++)
			{
				s2cps[i] = new S2CPDescriptor(
					files[i],
					"",
					"",
					"",
					"",
					Sims2CommunityPack.DEFAULT_COMPRESSION_STRENGTH,
					new S2CPDescriptorBase[0],
					extension
				);
				lblist.Items.Add(s2cps[i]);
			}

			btadd.Visible = true;
			btdelete.Visible = true;
			btbrowse.Enabled = true;
			btsave.Text = "Save";

			this.lblist.SelectionMode = SelectionMode.One;

			if (lblist.Items.Count > 0)
			{
				lblist.SelectedIndex = 0;
			}

			btdelete.Enabled = (lblist.SelectedIndex >= 0);

			this.ShowDialog();

			extension = false;
			if (ok)
			{
				s2cps = new S2CPDescriptor[lblist.Items.Count];
				for (int i = 0; i < s2cps.Length; i++)
				{
					s2cps[i] = (S2CPDescriptor)lblist.Items[i];
					//s2cps[i].Update();
				}

				return s2cps;
			}

			return null;
		}

		/// <summary>
		/// Shows the Load Dialog
		/// </summary>
		/// <param name="files">All Descriptors within the S2CP File</param>
		/// <param name="selmode">Selection Mode for the Listbox</param>
		/// <returns>All the Packages the user has selected</returns>
		public S2CPDescriptor[] Execute(S2CPDescriptor[] files, SelectionMode selmode)
		{
			this.extension = false;
			ok = false;

			for (int i = 0; i < files.Length; i++)
			{
				lblist.Items.Add(files[i]);
			}

			this.tbflname.ReadOnly = true;
			this.tbdesc.ReadOnly = true;
			btadd.Visible = false;
			btdelete.Visible = false;
			btbrowse.Enabled = false;
			btsave.Text = "Open";

			this.lblist.SelectionMode = selmode;

			if (lblist.Items.Count > 0)
			{
				lblist.SelectedIndex = 0;
			}

			btdelete.Enabled = (lblist.SelectedIndex >= 0);

			this.ShowDialog();

			if (ok)
			{
				S2CPDescriptor[] fls = new S2CPDescriptor[lblist.SelectedItems.Count];
				for (int i = 0; i < fls.Length; i++)
				{
					fls[i] = (S2CPDescriptor)lblist.SelectedItems[i];
				}

				return fls;
			}

			return null;
		}

		/// <summary>
		/// Select a List Item
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Select(object sender, EventArgs e)
		{
			if (lblist.Tag != null)
			{
				return;
			}

			gbsettings.Enabled = false;
			btdelete.Enabled = false;
			if (lblist.SelectedIndex < 0)
			{
				return;
			}

			gbsettings.Enabled = true;
			btdelete.Enabled = true;

			lblist.Tag = true;
			try
			{
				S2CPDescriptor s2cp = (S2CPDescriptor)
					lblist.Items[lblist.SelectedIndex];

				tbdesc.Text = s2cp.Description;
				tbname.Text = s2cp.Name;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lblist.Tag = null;
			}
		}

		private void ChangeText(object sender, EventArgs e)
		{
			if (lblist.Tag != null)
			{
				return;
			}

			if (lblist.SelectedIndex < 0)
			{
				return;
			}

			lblist.Tag = true;
			try
			{
				S2CPDescriptor s2cp = (S2CPDescriptor)
					lblist.Items[lblist.SelectedIndex];

				s2cp.Description = tbdesc.Text;

				lblist.Items[lblist.SelectedIndex] = s2cp;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lblist.Tag = null;
			}
		}

		private void AddPackage(object sender, EventArgs e)
		{
			ofd.Filter = "Sims 2 Package (*.package)|*.package|All Files (*.*)|*.*";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				GeneratableFile package = GeneratableFile.LoadFromFile(
					ofd.FileName
				);
				S2CPDescriptor s2cp = new S2CPDescriptor(
					package,
					"",
					"",
					"",
					"",
					Sims2CommunityPack.DEFAULT_COMPRESSION_STRENGTH,
					new S2CPDescriptorBase[0],
					extension
				);
				lblist.Items.Add(s2cp);
				lblist.SelectedIndex = lblist.Items.Count - 1;
			}
		}

		private void DeletePackage(object sender, EventArgs e)
		{
			if (lblist.SelectedIndex < 0)
			{
				return;
			}

			lblist.Items.RemoveAt(lblist.SelectedIndex);
		}

		private void S2CPFilename(object sender, EventArgs e)
		{
			sfd.Filter = "Sims 2 Package (*.sims2pack)|*.sims2pack|All Files (*.*)|*.*";
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				tbflname.Text = sfd.FileName;
			}
		}

		private void AllowClose(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (tbflname.ReadOnly)
			{
				if ((lblist.SelectedItems.Count == 0) && (ok))
				{
					MessageBox.Show("You have to select at Least one Package");
					btadd.Select();
					e.Cancel = true;
				}
			}
			else
			{
				if ((tbflname.Text.Trim() == "") && (ok))
				{
					MessageBox.Show(
						"You have to specify a Filename for the Sims2Community Pack File."
					);
					this.tbflname.Select();
					e.Cancel = true;
				}

				if ((lblist.Items.Count == 0) && (ok))
				{
					MessageBox.Show("You have to add at least one Package.");
					btadd.Select();
					e.Cancel = true;
				}
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			ok = false;
			Close();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			ok = true;
			Close();
		}

		private void SaveSims2CommunityPack_Load(object sender, EventArgs e)
		{
		}
	}
}
