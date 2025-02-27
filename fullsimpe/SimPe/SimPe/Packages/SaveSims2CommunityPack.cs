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
	internal class SaveSims2CommunityPack : Form
	{
		private ListBox lblist;
		private GroupBox gbsettings;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label label5;
		private TextBox tbname;
		private TextBox tbauthor;
		private TextBox tbguid;
		private TextBox tbver;
		private TextBox tbdesc;
		private OpenFileDialog ofd;
		private Label label6;
		internal TextBox tbflname;
		private SaveFileDialog sfd;
		private LinkLabel lldep;
		private Button btdelete;
		private Button button4;
		private Button btadd;
		private Button btbrowse;
		private Button btsave;
		private Label label7;
		private ComboBox cbcompress;
		private TextBox tbcontact;
		private Label label8;
		private Label label9;
		private TextBox tbgameguid;
		private TextBox tbtitle;
		private Label label10;
		private CheckBox cb2cp;
		private Panel panel1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SaveSims2CommunityPack()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			cbcompress.Items.Add(Sims2CommunityPack.CompressionStrength.Slowest);
			cbcompress.Items.Add(Sims2CommunityPack.CompressionStrength.Slower);
			cbcompress.Items.Add(Sims2CommunityPack.CompressionStrength.Slow);
			cbcompress.Items.Add(Sims2CommunityPack.CompressionStrength.Default);
			cbcompress.Items.Add(Sims2CommunityPack.CompressionStrength.Fast);
			cbcompress.Items.Add(Sims2CommunityPack.CompressionStrength.Faster);
			cbcompress.Items.Add(Sims2CommunityPack.CompressionStrength.Fastest);
			cbcompress.Items.Add(Sims2CommunityPack.CompressionStrength.None);
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
					typeof(SaveSims2CommunityPack)
				);
			lblist = new ListBox();
			gbsettings = new GroupBox();
			tbtitle = new TextBox();
			label10 = new Label();
			tbgameguid = new TextBox();
			tbcontact = new TextBox();
			label8 = new Label();
			cbcompress = new ComboBox();
			tbdesc = new TextBox();
			tbver = new TextBox();
			tbguid = new TextBox();
			tbauthor = new TextBox();
			tbname = new TextBox();
			label5 = new Label();
			label4 = new Label();
			label3 = new Label();
			label2 = new Label();
			label1 = new Label();
			lldep = new LinkLabel();
			label7 = new Label();
			label9 = new Label();
			cb2cp = new CheckBox();
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

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			lblist.IntegralHeight = false;
			lblist.Location = new System.Drawing.Point(8, 40);
			lblist.Name = "lblist";
			lblist.Size = new System.Drawing.Size(778, 180);
			lblist.TabIndex = 2;
			lblist.SelectedIndexChanged += new EventHandler(Select);
			//
			// gbsettings
			//
			gbsettings.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			gbsettings.BackColor = System.Drawing.Color.Transparent;
			gbsettings.Controls.Add(tbtitle);
			gbsettings.Controls.Add(label10);
			gbsettings.Controls.Add(tbgameguid);
			gbsettings.Controls.Add(tbcontact);
			gbsettings.Controls.Add(label8);
			gbsettings.Controls.Add(cbcompress);
			gbsettings.Controls.Add(tbdesc);
			gbsettings.Controls.Add(tbver);
			gbsettings.Controls.Add(tbguid);
			gbsettings.Controls.Add(tbauthor);
			gbsettings.Controls.Add(tbname);
			gbsettings.Controls.Add(label5);
			gbsettings.Controls.Add(label4);
			gbsettings.Controls.Add(label3);
			gbsettings.Controls.Add(label2);
			gbsettings.Controls.Add(label1);
			gbsettings.Controls.Add(lldep);
			gbsettings.Controls.Add(label7);
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
			gbsettings.Size = new System.Drawing.Size(778, 278);
			gbsettings.TabIndex = 1;
			gbsettings.TabStop = false;
			gbsettings.Text = "Settings";
			//
			// tbtitle
			//
			tbtitle.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			tbtitle.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbtitle.Location = new System.Drawing.Point(72, 48);
			tbtitle.Name = "tbtitle";
			tbtitle.Size = new System.Drawing.Size(698, 21);
			tbtitle.TabIndex = 7;
			tbtitle.TextChanged += new EventHandler(ChangeText);
			//
			// label10
			//
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label10.Location = new System.Drawing.Point(30, 52);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(36, 13);
			label10.TabIndex = 17;
			label10.Text = "Title:";
			//
			// tbgameguid
			//
			tbgameguid.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			tbgameguid.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbgameguid.Location = new System.Drawing.Point(424, 96);
			tbgameguid.Name = "tbgameguid";
			tbgameguid.ReadOnly = true;
			tbgameguid.Size = new System.Drawing.Size(346, 21);
			tbgameguid.TabIndex = 11;
			//
			// tbcontact
			//
			tbcontact.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbcontact.Location = new System.Drawing.Point(72, 96);
			tbcontact.Name = "tbcontact";
			tbcontact.Size = new System.Drawing.Size(257, 21);
			tbcontact.TabIndex = 10;
			tbcontact.TextChanged += new EventHandler(ChangeText);
			//
			// label8
			//
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label8.Location = new System.Drawing.Point(11, 100);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(56, 13);
			label8.TabIndex = 13;
			label8.Text = "Contact:";
			//
			// cbcompress
			//
			cbcompress.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			cbcompress.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbcompress.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbcompress.Location = new System.Drawing.Point(626, 72);
			cbcompress.Name = "cbcompress";
			cbcompress.Size = new System.Drawing.Size(144, 21);
			cbcompress.TabIndex = 9;
			cbcompress.SelectedIndexChanged += new EventHandler(
				SelectCompression
			);
			//
			// tbdesc
			//
			tbdesc.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			tbdesc.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbdesc.Location = new System.Drawing.Point(6, 168);
			tbdesc.Multiline = true;
			tbdesc.Name = "tbdesc";
			tbdesc.Size = new System.Drawing.Size(764, 76);
			tbdesc.TabIndex = 14;
			tbdesc.TextChanged += new EventHandler(ChangeText);
			//
			// tbver
			//
			tbver.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbver.Location = new System.Drawing.Point(118, 124);
			tbver.Name = "tbver";
			tbver.Size = new System.Drawing.Size(72, 21);
			tbver.TabIndex = 12;
			tbver.TextChanged += new EventHandler(ChangeText);
			//
			// tbguid
			//
			tbguid.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			tbguid.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbguid.Location = new System.Drawing.Point(424, 128);
			tbguid.Name = "tbguid";
			tbguid.ReadOnly = true;
			tbguid.Size = new System.Drawing.Size(346, 21);
			tbguid.TabIndex = 13;
			//
			// tbauthor
			//
			tbauthor.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			tbauthor.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbauthor.Location = new System.Drawing.Point(72, 72);
			tbauthor.Name = "tbauthor";
			tbauthor.Size = new System.Drawing.Size(450, 21);
			tbauthor.TabIndex = 8;
			tbauthor.TextChanged += new EventHandler(ChangeText);
			//
			// tbname
			//
			tbname.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			tbname.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbname.Location = new System.Drawing.Point(72, 24);
			tbname.Name = "tbname";
			tbname.Size = new System.Drawing.Size(698, 21);
			tbname.TabIndex = 6;
			tbname.TextChanged += new EventHandler(ChangeText);
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
			label5.Location = new System.Drawing.Point(6, 152);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(76, 13);
			label5.TabIndex = 4;
			label5.Text = "Description:";
			//
			// label4
			//
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label4.Location = new System.Drawing.Point(339, 132);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(79, 13);
			label4.TabIndex = 3;
			label4.Text = "GlobalGUID:";
			//
			// label3
			//
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label3.Location = new System.Drawing.Point(16, 128);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(96, 13);
			label3.TabIndex = 2;
			label3.Text = "Object Version:";
			//
			// label2
			//
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label2.Location = new System.Drawing.Point(16, 76);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(50, 13);
			label2.TabIndex = 1;
			label2.Text = "Author:";
			//
			// label1
			//
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label1.Location = new System.Drawing.Point(22, 28);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(45, 13);
			label1.TabIndex = 0;
			label1.Text = "Name:";
			//
			// lldep
			//
			lldep.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			lldep.AutoSize = true;
			lldep.LinkArea = new LinkArea(7, 12);
			lldep.Location = new System.Drawing.Point(16, 254);
			lldep.Name = "lldep";
			lldep.Size = new System.Drawing.Size(155, 18);
			lldep.TabIndex = 15;
			lldep.TabStop = true;
			lldep.Text = "show 0 Dependencies...";
			lldep.UseCompatibleTextRendering = true;
			lldep.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					ShowDependencies
				);
			//
			// label7
			//
			label7.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label7.Location = new System.Drawing.Point(533, 76);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(87, 13);
			label7.TabIndex = 11;
			label7.Text = "Compression:";
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
			label9.Location = new System.Drawing.Point(335, 99);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(83, 13);
			label9.TabIndex = 15;
			label9.Text = "GameGUIDs:";
			//
			// cb2cp
			//
			cb2cp.FlatStyle = FlatStyle.System;
			cb2cp.Location = new System.Drawing.Point(8, 220);
			cb2cp.Name = "cb2cp";
			cb2cp.Size = new System.Drawing.Size(321, 24);
			cb2cp.TabIndex = 5;
			cb2cp.Text = "create Sim2CommunityPackage (s2cp)";
			cb2cp.CheckedChanged += new EventHandler(Checks2cp);
			//
			// btadd
			//
			btadd.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			btadd.BackColor = System.Drawing.Color.Transparent;
			btadd.FlatStyle = FlatStyle.System;
			btadd.Location = new System.Drawing.Point(618, 222);
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
			label6.Location = new System.Drawing.Point(5, 11);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(72, 13);
			label6.TabIndex = 3;
			label6.Text = "FileName:";
			//
			// tbflname
			//
			tbflname.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

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
			tbflname.Size = new System.Drawing.Size(613, 21);
			tbflname.TabIndex = 0;
			//
			// btbrowse
			//
			btbrowse.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			btbrowse.BackColor = System.Drawing.Color.Transparent;
			btbrowse.FlatStyle = FlatStyle.System;
			btbrowse.Location = new System.Drawing.Point(703, 8);
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

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			btdelete.BackColor = System.Drawing.Color.Transparent;
			btdelete.FlatStyle = FlatStyle.System;
			btdelete.Location = new System.Drawing.Point(703, 222);
			btdelete.Name = "btdelete";
			btdelete.Size = new System.Drawing.Size(75, 23);
			btdelete.TabIndex = 3;
			btdelete.Text = "Delete...";
			btdelete.UseVisualStyleBackColor = false;
			btdelete.Click += new EventHandler(DeletePackage);
			//
			// btsave
			//
			btsave.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)

			;
			btsave.BackColor = System.Drawing.Color.Transparent;
			btsave.FlatStyle = FlatStyle.System;
			btsave.Location = new System.Drawing.Point(618, 530);
			btsave.Name = "btsave";
			btsave.Size = new System.Drawing.Size(75, 23);
			btsave.TabIndex = 16;
			btsave.Text = "Save";
			btsave.UseVisualStyleBackColor = false;
			btsave.Click += new EventHandler(button3_Click);
			//
			// button4
			//
			button4.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)

			;
			button4.BackColor = System.Drawing.Color.Transparent;
			button4.FlatStyle = FlatStyle.System;
			button4.Location = new System.Drawing.Point(703, 530);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(75, 23);
			button4.TabIndex = 17;
			button4.Text = "Cancel";
			button4.UseVisualStyleBackColor = false;
			button4.Click += new EventHandler(button4_Click);
			//
			// panel1
			//
			panel1.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			panel1.Controls.Add(label6);
			panel1.Controls.Add(button4);
			panel1.Controls.Add(btsave);
			panel1.Controls.Add(btdelete);
			panel1.Controls.Add(btbrowse);
			panel1.Controls.Add(tbflname);
			panel1.Controls.Add(btadd);
			panel1.Controls.Add(gbsettings);
			panel1.Controls.Add(lblist);
			panel1.Controls.Add(cb2cp);
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(794, 560);
			panel1.TabIndex = 18;
			//
			// SaveSims2CommunityPack
			//
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			ClientSize = new System.Drawing.Size(794, 560);
			Controls.Add(panel1);
			Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "SaveSims2CommunityPack";
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterScreen;
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

			tbflname.ReadOnly = false;
			tbname.ReadOnly = true;
			tbauthor.ReadOnly = false;
			tbver.ReadOnly = false;
			tbdesc.ReadOnly = false;
			tbtitle.ReadOnly = false;
			tbcontact.ReadOnly = false;
			cb2cp.Checked = extension;
			btadd.Visible = true;
			btdelete.Visible = true;
			btbrowse.Enabled = true;
			cb2cp.Enabled = true;
			btsave.Text = "Save";
			cbcompress.Enabled = true;

			lblist.SelectionMode = SelectionMode.One;

			if (lblist.Items.Count > 0)
			{
				lblist.SelectedIndex = 0;
			}

			btdelete.Enabled = (lblist.SelectedIndex >= 0);

			Checks2cp(cb2cp, null);
			ShowDialog();

			extension = cb2cp.Checked;
			if (ok)
			{
				s2cps = new S2CPDescriptor[lblist.Items.Count];
				for (int i = 0; i < s2cps.Length; i++)
				{
					s2cps[i] = (S2CPDescriptor)lblist.Items[i];
					if (extension)
					{
						s2cps[i].Update();
					}
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
			tbname.ReadOnly = true;
			tbauthor.ReadOnly = true;
			tbver.ReadOnly = true;
			tbdesc.ReadOnly = true;
			tbtitle.ReadOnly = true;
			tbcontact.ReadOnly = true;
			btadd.Visible = false;
			btdelete.Visible = false;
			btbrowse.Enabled = false;

			tbgameguid.Visible = false;
			label9.Visible = false;

			cb2cp.Enabled = false;
			btsave.Text = "Open";
			cbcompress.Enabled = false;

			lblist.SelectionMode = selmode;

			if (lblist.Items.Count > 0)
			{
				lblist.SelectedIndex = 0;
			}

			btdelete.Enabled = (lblist.SelectedIndex >= 0);

			Checks2cp(cb2cp, null);
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
		/// Updates the Link Text for the Dependency Window
		/// </summary>
		/// <param name="s2cp"></param>
		void UpdateDepText(S2CPDescriptor s2cp)
		{
			lldep.Text = "Show " + s2cp.Dependency.Length + " Dependencies...";
			lldep.LinkArea = new LinkArea(lldep.Text.Length - 15, 12);
		}

		/// <summary>
		/// Select a List Item
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Select(object sender, EventArgs e) // CJH
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

				tbname.Text = s2cp.Name;
				tbguid.Text = s2cp.Guid;
				tbauthor.Text = s2cp.Author;
				tbdesc.Text = s2cp.Description;
				tbver.Text = s2cp.ObjectVersion;
				tbcontact.Text = s2cp.Contact;
				tbgameguid.Text = s2cp.GameGuid;
				tbtitle.Text = s2cp.Title;
				lldep.Enabled = cb2cp.Checked || s2cp.Dependency.Length > 0; // CJH
																			 // tbtitle.Color = HotPink;
				cbcompress.SelectedIndex = cbcompress.Items.Count - 1;
				for (int i = 0; i < cbcompress.Items.Count; i++)
				{
					Sims2CommunityPack.CompressionStrength cs =
						(Sims2CommunityPack.CompressionStrength)cbcompress.Items[i];
					if (cs == s2cp.Compressed)
					{
						cbcompress.SelectedIndex = i;
						break;
					}
				}

				UpdateDepText(s2cp);
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

				s2cp.Name = tbname.Text;
				//s2cp.Guid = tbguid.Text;
				s2cp.Author = tbauthor.Text;
				s2cp.Contact = tbcontact.Text;
				s2cp.Description = tbdesc.Text;
				s2cp.ObjectVersion = tbver.Text;
				s2cp.Title = tbtitle.Text;

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
			if (cb2cp.Checked)
			{
				sfd.Filter =
					"Sims 2 Community Package (*.s2cp)|*.s2cp|All Files (*.*)|*.*";
			}
			else
			{
				sfd.Filter =
					"Sims 2 Package (*.sims2pack)|*.sims2pack|All Files (*.*)|*.*";
			}

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
					tbflname.Select();
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

		private void ShowDependencies(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
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

				DepSims2Community form = new DepSims2Community();
				form.Execute(s2cp, tbflname.ReadOnly);
				UpdateDepText(s2cp);
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

		private void SelectCompression(object sender, EventArgs e)
		{
			if (lblist.Tag != null)
			{
				return;
			}

			if (lblist.SelectedIndex < 0)
			{
				return;
			}

			if (cbcompress.SelectedIndex < 0)
			{
				return;
			}

			lblist.Tag = true;
			try
			{
				S2CPDescriptor s2cp = (S2CPDescriptor)
					lblist.Items[lblist.SelectedIndex];

				s2cp.Compressed =
					(Sims2CommunityPack.CompressionStrength)
						cbcompress.Items[cbcompress.SelectedIndex];
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

		private void SaveSims2CommunityPack_Load(object sender, EventArgs e)
		{
		}

		private void Checks2cp(object sender, EventArgs e)
		{
			lldep.Enabled = cb2cp.Checked;
			tbguid.Enabled = cb2cp.Checked;
			cbcompress.Enabled = cb2cp.Checked;
			tbtitle.Enabled = cb2cp.Checked;
			tbauthor.Enabled = cb2cp.Checked;
			tbcontact.Enabled = cb2cp.Checked;
			tbver.Enabled = cb2cp.Checked;

			if (cb2cp.Checked)
			{
				if (tbflname.Text.Trim().ToLower().EndsWith(".sims2pack"))
				{
					tbflname.Text =
						tbflname.Text.Trim()
							.Substring(0, tbflname.Text.Trim().Length - 8)
						+ ".s2cp";
				}
				else if (tbflname.Text.Trim().ToLower().EndsWith(".s2cp"))
				{
					tbflname.Text =
						tbflname.Text.Trim()
							.Substring(0, tbflname.Text.Trim().Length - 5)
						+ ".sims2pack";
				}
			}
		}
	}
}
