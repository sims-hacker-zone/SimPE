// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
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
				new System.ComponentModel.ComponentResourceManager(
					typeof(SaveSims2Pack)
				);
			lblist = new ListBox();
			gbsettings = new GroupBox();
			tbname = new TextBox();
			tbdesc = new TextBox();
			label5 = new Label();
			label9 = new Label();
			btadd = new Button();
			ofd = new OpenFileDialog();
			label6 = new Label();
			tbflname = new TextBox();
			btbrowse = new Button();
			sfd = new SaveFileDialog();
			btdelete = new Button();
			btsave = new Button();
			button4 = new Button();
			panel1 = new Panel();
			gbsettings.SuspendLayout();
			panel1.SuspendLayout();
			SuspendLayout();
			//
			// lblist
			//
			lblist.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Left
						 | AnchorStyles.Right


			;
			lblist.IntegralHeight = false;
			lblist.Location = new System.Drawing.Point(8, 40);
			lblist.Name = "lblist";
			lblist.Size = new System.Drawing.Size(560, 180);
			lblist.TabIndex = 2;
			lblist.SelectedIndexChanged += new EventHandler(Select);
			//
			// gbsettings
			//
			gbsettings.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Left
						 | AnchorStyles.Right


			;
			gbsettings.BackColor = System.Drawing.Color.Transparent;
			gbsettings.Controls.Add(tbname);
			gbsettings.Controls.Add(tbdesc);
			gbsettings.Controls.Add(label5);
			gbsettings.Controls.Add(label9);
			gbsettings.Enabled = false;
			gbsettings.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			gbsettings.Location = new System.Drawing.Point(8, 244);
			gbsettings.Name = "gbsettings";
			gbsettings.Size = new System.Drawing.Size(560, 176);
			gbsettings.TabIndex = 1;
			gbsettings.TabStop = false;
			gbsettings.Text = "Settings";
			//
			// tbname
			//
			tbname.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Left
						 | AnchorStyles.Right


			;
			tbname.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbname.Location = new System.Drawing.Point(16, 144);
			tbname.Name = "tbname";
			tbname.ReadOnly = true;
			tbname.Size = new System.Drawing.Size(528, 21);
			tbname.TabIndex = 11;
			//
			// tbdesc
			//
			tbdesc.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Left
						 | AnchorStyles.Right


			;
			tbdesc.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbdesc.Location = new System.Drawing.Point(16, 40);
			tbdesc.Multiline = true;
			tbdesc.Name = "tbdesc";
			tbdesc.Size = new System.Drawing.Size(528, 78);
			tbdesc.TabIndex = 14;
			tbdesc.TextChanged += new EventHandler(ChangeText);
			//
			// label5
			//
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label5.Location = new System.Drawing.Point(8, 24);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(76, 13);
			label5.TabIndex = 4;
			label5.Text = "Description:";
			//
			// label9
			//
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label9.Location = new System.Drawing.Point(8, 128);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(63, 13);
			label9.TabIndex = 15;
			label9.Text = "File Name";
			//
			// btadd
			//
			btadd.BackColor = System.Drawing.Color.Transparent;
			btadd.FlatStyle = FlatStyle.System;
			btadd.Location = new System.Drawing.Point(415, 222);
			btadd.Name = "btadd";
			btadd.Size = new System.Drawing.Size(72, 23);
			btadd.TabIndex = 4;
			btadd.Text = "Add...";
			btadd.UseVisualStyleBackColor = false;
			btadd.Click += new EventHandler(AddPackage);
			//
			// ofd
			//
			ofd.Filter =
				"Sims 2 Package (*.package)|*.package|All Files (*.*)|*.*";
			//
			// label6
			//
			label6.AutoSize = true;
			label6.BackColor = System.Drawing.Color.Transparent;
			label6.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label6.Location = new System.Drawing.Point(8, 16);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(72, 13);
			label6.TabIndex = 3;
			label6.Text = "FileName:";
			//
			// tbflname
			//
			tbflname.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Left
						 | AnchorStyles.Right


			;
			tbflname.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbflname.Location = new System.Drawing.Point(80, 8);
			tbflname.Name = "tbflname";
			tbflname.Size = new System.Drawing.Size(407, 21);
			tbflname.TabIndex = 0;
			//
			// btbrowse
			//
			btbrowse.BackColor = System.Drawing.Color.Transparent;
			btbrowse.FlatStyle = FlatStyle.System;
			btbrowse.Location = new System.Drawing.Point(493, 8);
			btbrowse.Name = "btbrowse";
			btbrowse.Size = new System.Drawing.Size(75, 23);
			btbrowse.TabIndex = 1;
			btbrowse.Text = "Browse...";
			btbrowse.UseVisualStyleBackColor = false;
			btbrowse.Click += new EventHandler(S2CPFilename);
			//
			// btdelete
			//
			btdelete.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			btdelete.BackColor = System.Drawing.Color.Transparent;
			btdelete.FlatStyle = FlatStyle.System;
			btdelete.Location = new System.Drawing.Point(493, 222);
			btdelete.Name = "btdelete";
			btdelete.Size = new System.Drawing.Size(75, 23);
			btdelete.TabIndex = 3;
			btdelete.Text = "Remove...";
			btdelete.UseVisualStyleBackColor = false;
			btdelete.Click += new EventHandler(DeletePackage);
			//
			// btsave
			//
			btsave.Anchor =


						AnchorStyles.Bottom
						| AnchorStyles.Right


			;
			btsave.FlatStyle = FlatStyle.System;
			btsave.Location = new System.Drawing.Point(493, 434);
			btsave.Name = "btsave";
			btsave.Size = new System.Drawing.Size(75, 23);
			btsave.TabIndex = 16;
			btsave.Text = "Save";
			btsave.Click += new EventHandler(button3_Click);
			//
			// button4
			//
			button4.Anchor =


						AnchorStyles.Bottom
						| AnchorStyles.Right


			;
			button4.FlatStyle = FlatStyle.System;
			button4.Location = new System.Drawing.Point(412, 434);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(75, 23);
			button4.TabIndex = 17;
			button4.Text = "Cancel";
			button4.Click += new EventHandler(button4_Click);
			//
			// panel1
			//
			panel1.Anchor =




								AnchorStyles.Top
								| AnchorStyles.Bottom
							 | AnchorStyles.Left
						 | AnchorStyles.Right


			;
			panel1.Controls.Add(button4);
			panel1.Controls.Add(btsave);
			panel1.Controls.Add(btdelete);
			panel1.Controls.Add(btbrowse);
			panel1.Controls.Add(tbflname);
			panel1.Controls.Add(label6);
			panel1.Controls.Add(btadd);
			panel1.Controls.Add(gbsettings);
			panel1.Controls.Add(lblist);
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(578, 460);
			panel1.TabIndex = 18;
			//
			// SaveSims2Pack
			//
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			ClientSize = new System.Drawing.Size(576, 460);
			Controls.Add(panel1);
			Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "SaveSims2Pack";
			ShowInTaskbar = false;
			Text = "Sims 2 Pack File Browser";
			Load += new EventHandler(SaveSims2CommunityPack_Load);
			Closing += new System.ComponentModel.CancelEventHandler(
				AllowClose
			);
			gbsettings.ResumeLayout(false);
			gbsettings.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
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

			lblist.SelectionMode = SelectionMode.One;

			if (lblist.Items.Count > 0)
			{
				lblist.SelectedIndex = 0;
			}

			btdelete.Enabled = lblist.SelectedIndex >= 0;

			ShowDialog();

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
			extension = false;
			ok = false;

			for (int i = 0; i < files.Length; i++)
			{
				lblist.Items.Add(files[i]);
			}

			tbflname.ReadOnly = true;
			tbdesc.ReadOnly = true;
			btadd.Visible = false;
			btdelete.Visible = false;
			btbrowse.Enabled = false;
			btsave.Text = "Open";

			lblist.SelectionMode = selmode;

			if (lblist.Items.Count > 0)
			{
				lblist.SelectedIndex = 0;
			}

			btdelete.Enabled = lblist.SelectedIndex >= 0;

			ShowDialog();

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
				GeneratableFile package = File.LoadFromFile(
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
				if ((lblist.SelectedItems.Count == 0) && ok)
				{
					MessageBox.Show("You have to select at Least one Package");
					btadd.Select();
					e.Cancel = true;
				}
			}
			else
			{
				if ((tbflname.Text.Trim() == "") && ok)
				{
					MessageBox.Show(
						"You have to specify a Filename for the Sims2Community Pack File."
					);
					tbflname.Select();
					e.Cancel = true;
				}

				if ((lblist.Items.Count == 0) && ok)
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
