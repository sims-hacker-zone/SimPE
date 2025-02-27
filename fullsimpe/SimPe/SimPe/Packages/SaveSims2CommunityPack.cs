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

			this.cbcompress.Items.Add(Sims2CommunityPack.CompressionStrength.Slowest);
			this.cbcompress.Items.Add(Sims2CommunityPack.CompressionStrength.Slower);
			this.cbcompress.Items.Add(Sims2CommunityPack.CompressionStrength.Slow);
			this.cbcompress.Items.Add(Sims2CommunityPack.CompressionStrength.Default);
			this.cbcompress.Items.Add(Sims2CommunityPack.CompressionStrength.Fast);
			this.cbcompress.Items.Add(Sims2CommunityPack.CompressionStrength.Faster);
			this.cbcompress.Items.Add(Sims2CommunityPack.CompressionStrength.Fastest);
			this.cbcompress.Items.Add(Sims2CommunityPack.CompressionStrength.None);
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
			this.lblist = new ListBox();
			this.gbsettings = new GroupBox();
			this.tbtitle = new TextBox();
			this.label10 = new Label();
			this.tbgameguid = new TextBox();
			this.tbcontact = new TextBox();
			this.label8 = new Label();
			this.cbcompress = new ComboBox();
			this.tbdesc = new TextBox();
			this.tbver = new TextBox();
			this.tbguid = new TextBox();
			this.tbauthor = new TextBox();
			this.tbname = new TextBox();
			this.label5 = new Label();
			this.label4 = new Label();
			this.label3 = new Label();
			this.label2 = new Label();
			this.label1 = new Label();
			this.lldep = new LinkLabel();
			this.label7 = new Label();
			this.label9 = new Label();
			this.cb2cp = new CheckBox();
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
			this.lblist.Size = new System.Drawing.Size(778, 180);
			this.lblist.TabIndex = 2;
			this.lblist.SelectedIndexChanged += new EventHandler(this.Select);
			//
			// gbsettings
			//
			this.gbsettings.Anchor = (
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
			this.gbsettings.BackColor = System.Drawing.Color.Transparent;
			this.gbsettings.Controls.Add(this.tbtitle);
			this.gbsettings.Controls.Add(this.label10);
			this.gbsettings.Controls.Add(this.tbgameguid);
			this.gbsettings.Controls.Add(this.tbcontact);
			this.gbsettings.Controls.Add(this.label8);
			this.gbsettings.Controls.Add(this.cbcompress);
			this.gbsettings.Controls.Add(this.tbdesc);
			this.gbsettings.Controls.Add(this.tbver);
			this.gbsettings.Controls.Add(this.tbguid);
			this.gbsettings.Controls.Add(this.tbauthor);
			this.gbsettings.Controls.Add(this.tbname);
			this.gbsettings.Controls.Add(this.label5);
			this.gbsettings.Controls.Add(this.label4);
			this.gbsettings.Controls.Add(this.label3);
			this.gbsettings.Controls.Add(this.label2);
			this.gbsettings.Controls.Add(this.label1);
			this.gbsettings.Controls.Add(this.lldep);
			this.gbsettings.Controls.Add(this.label7);
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
			this.gbsettings.Size = new System.Drawing.Size(778, 278);
			this.gbsettings.TabIndex = 1;
			this.gbsettings.TabStop = false;
			this.gbsettings.Text = "Settings";
			//
			// tbtitle
			//
			this.tbtitle.Anchor = (
				(AnchorStyles)(
					(
						(
							System.Windows.Forms.AnchorStyles.Top
							| System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.tbtitle.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.tbtitle.Location = new System.Drawing.Point(72, 48);
			this.tbtitle.Name = "tbtitle";
			this.tbtitle.Size = new System.Drawing.Size(698, 21);
			this.tbtitle.TabIndex = 7;
			this.tbtitle.TextChanged += new EventHandler(this.ChangeText);
			//
			// label10
			//
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label10.Location = new System.Drawing.Point(30, 52);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(36, 13);
			this.label10.TabIndex = 17;
			this.label10.Text = "Title:";
			//
			// tbgameguid
			//
			this.tbgameguid.Anchor = (
				(AnchorStyles)(
					(
						(
							System.Windows.Forms.AnchorStyles.Top
							| System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.tbgameguid.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.tbgameguid.Location = new System.Drawing.Point(424, 96);
			this.tbgameguid.Name = "tbgameguid";
			this.tbgameguid.ReadOnly = true;
			this.tbgameguid.Size = new System.Drawing.Size(346, 21);
			this.tbgameguid.TabIndex = 11;
			//
			// tbcontact
			//
			this.tbcontact.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.tbcontact.Location = new System.Drawing.Point(72, 96);
			this.tbcontact.Name = "tbcontact";
			this.tbcontact.Size = new System.Drawing.Size(257, 21);
			this.tbcontact.TabIndex = 10;
			this.tbcontact.TextChanged += new EventHandler(this.ChangeText);
			//
			// label8
			//
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label8.Location = new System.Drawing.Point(11, 100);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(56, 13);
			this.label8.TabIndex = 13;
			this.label8.Text = "Contact:";
			//
			// cbcompress
			//
			this.cbcompress.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.cbcompress.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbcompress.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cbcompress.Location = new System.Drawing.Point(626, 72);
			this.cbcompress.Name = "cbcompress";
			this.cbcompress.Size = new System.Drawing.Size(144, 21);
			this.cbcompress.TabIndex = 9;
			this.cbcompress.SelectedIndexChanged += new EventHandler(
				this.SelectCompression
			);
			//
			// tbdesc
			//
			this.tbdesc.Anchor = (
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
			this.tbdesc.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.tbdesc.Location = new System.Drawing.Point(6, 168);
			this.tbdesc.Multiline = true;
			this.tbdesc.Name = "tbdesc";
			this.tbdesc.Size = new System.Drawing.Size(764, 76);
			this.tbdesc.TabIndex = 14;
			this.tbdesc.TextChanged += new EventHandler(this.ChangeText);
			//
			// tbver
			//
			this.tbver.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.tbver.Location = new System.Drawing.Point(118, 124);
			this.tbver.Name = "tbver";
			this.tbver.Size = new System.Drawing.Size(72, 21);
			this.tbver.TabIndex = 12;
			this.tbver.TextChanged += new EventHandler(this.ChangeText);
			//
			// tbguid
			//
			this.tbguid.Anchor = (
				(AnchorStyles)(
					(
						(
							System.Windows.Forms.AnchorStyles.Top
							| System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.tbguid.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.tbguid.Location = new System.Drawing.Point(424, 128);
			this.tbguid.Name = "tbguid";
			this.tbguid.ReadOnly = true;
			this.tbguid.Size = new System.Drawing.Size(346, 21);
			this.tbguid.TabIndex = 13;
			//
			// tbauthor
			//
			this.tbauthor.Anchor = (
				(AnchorStyles)(
					(
						(
							System.Windows.Forms.AnchorStyles.Top
							| System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.tbauthor.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.tbauthor.Location = new System.Drawing.Point(72, 72);
			this.tbauthor.Name = "tbauthor";
			this.tbauthor.Size = new System.Drawing.Size(450, 21);
			this.tbauthor.TabIndex = 8;
			this.tbauthor.TextChanged += new EventHandler(this.ChangeText);
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
			this.tbname.Location = new System.Drawing.Point(72, 24);
			this.tbname.Name = "tbname";
			this.tbname.Size = new System.Drawing.Size(698, 21);
			this.tbname.TabIndex = 6;
			this.tbname.TextChanged += new EventHandler(this.ChangeText);
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
			this.label5.Location = new System.Drawing.Point(6, 152);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(76, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "Description:";
			//
			// label4
			//
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label4.Location = new System.Drawing.Point(339, 132);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(79, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "GlobalGUID:";
			//
			// label3
			//
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label3.Location = new System.Drawing.Point(16, 128);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Object Version:";
			//
			// label2
			//
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label2.Location = new System.Drawing.Point(16, 76);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Author:";
			//
			// label1
			//
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label1.Location = new System.Drawing.Point(22, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(45, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name:";
			//
			// lldep
			//
			this.lldep.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Bottom
						| System.Windows.Forms.AnchorStyles.Left
					)
				)
			);
			this.lldep.AutoSize = true;
			this.lldep.LinkArea = new LinkArea(7, 12);
			this.lldep.Location = new System.Drawing.Point(16, 254);
			this.lldep.Name = "lldep";
			this.lldep.Size = new System.Drawing.Size(155, 18);
			this.lldep.TabIndex = 15;
			this.lldep.TabStop = true;
			this.lldep.Text = "show 0 Dependencies...";
			this.lldep.UseCompatibleTextRendering = true;
			this.lldep.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					this.ShowDependencies
				);
			//
			// label7
			//
			this.label7.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label7.Location = new System.Drawing.Point(533, 76);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(87, 13);
			this.label7.TabIndex = 11;
			this.label7.Text = "Compression:";
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
			this.label9.Location = new System.Drawing.Point(335, 99);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(83, 13);
			this.label9.TabIndex = 15;
			this.label9.Text = "GameGUIDs:";
			//
			// cb2cp
			//
			this.cb2cp.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cb2cp.Location = new System.Drawing.Point(8, 220);
			this.cb2cp.Name = "cb2cp";
			this.cb2cp.Size = new System.Drawing.Size(321, 24);
			this.cb2cp.TabIndex = 5;
			this.cb2cp.Text = "create Sim2CommunityPackage (s2cp)";
			this.cb2cp.CheckedChanged += new EventHandler(this.Checks2cp);
			//
			// btadd
			//
			this.btadd.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.btadd.BackColor = System.Drawing.Color.Transparent;
			this.btadd.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btadd.Location = new System.Drawing.Point(618, 222);
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
			this.label6.Location = new System.Drawing.Point(5, 11);
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
			this.tbflname.Size = new System.Drawing.Size(613, 21);
			this.tbflname.TabIndex = 0;
			//
			// btbrowse
			//
			this.btbrowse.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.btbrowse.BackColor = System.Drawing.Color.Transparent;
			this.btbrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btbrowse.Location = new System.Drawing.Point(703, 8);
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
			this.btdelete.Location = new System.Drawing.Point(703, 222);
			this.btdelete.Name = "btdelete";
			this.btdelete.Size = new System.Drawing.Size(75, 23);
			this.btdelete.TabIndex = 3;
			this.btdelete.Text = "Delete...";
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
			this.btsave.BackColor = System.Drawing.Color.Transparent;
			this.btsave.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btsave.Location = new System.Drawing.Point(618, 530);
			this.btsave.Name = "btsave";
			this.btsave.Size = new System.Drawing.Size(75, 23);
			this.btsave.TabIndex = 16;
			this.btsave.Text = "Save";
			this.btsave.UseVisualStyleBackColor = false;
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
			this.button4.BackColor = System.Drawing.Color.Transparent;
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button4.Location = new System.Drawing.Point(703, 530);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 17;
			this.button4.Text = "Cancel";
			this.button4.UseVisualStyleBackColor = false;
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
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.button4);
			this.panel1.Controls.Add(this.btsave);
			this.panel1.Controls.Add(this.btdelete);
			this.panel1.Controls.Add(this.btbrowse);
			this.panel1.Controls.Add(this.tbflname);
			this.panel1.Controls.Add(this.btadd);
			this.panel1.Controls.Add(this.gbsettings);
			this.panel1.Controls.Add(this.lblist);
			this.panel1.Controls.Add(this.cb2cp);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(794, 560);
			this.panel1.TabIndex = 18;
			//
			// SaveSims2CommunityPack
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(794, 560);
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
			this.Name = "SaveSims2CommunityPack";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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

			this.tbflname.ReadOnly = false;
			this.tbname.ReadOnly = true;
			this.tbauthor.ReadOnly = false;
			this.tbver.ReadOnly = false;
			this.tbdesc.ReadOnly = false;
			this.tbtitle.ReadOnly = false;
			this.tbcontact.ReadOnly = false;
			this.cb2cp.Checked = extension;
			btadd.Visible = true;
			btdelete.Visible = true;
			btbrowse.Enabled = true;
			cb2cp.Enabled = true;
			btsave.Text = "Save";
			cbcompress.Enabled = true;

			this.lblist.SelectionMode = SelectionMode.One;

			if (lblist.Items.Count > 0)
			{
				lblist.SelectedIndex = 0;
			}

			btdelete.Enabled = (lblist.SelectedIndex >= 0);

			this.Checks2cp(this.cb2cp, null);
			this.ShowDialog();

			extension = this.cb2cp.Checked;
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
			this.extension = false;
			ok = false;

			for (int i = 0; i < files.Length; i++)
			{
				lblist.Items.Add(files[i]);
			}

			this.tbflname.ReadOnly = true;
			this.tbname.ReadOnly = true;
			this.tbauthor.ReadOnly = true;
			this.tbver.ReadOnly = true;
			this.tbdesc.ReadOnly = true;
			this.tbtitle.ReadOnly = true;
			this.tbcontact.ReadOnly = true;
			btadd.Visible = false;
			btdelete.Visible = false;
			btbrowse.Enabled = false;

			tbgameguid.Visible = false;
			label9.Visible = false;

			cb2cp.Enabled = false;
			btsave.Text = "Open";
			cbcompress.Enabled = false;

			this.lblist.SelectionMode = selmode;

			if (lblist.Items.Count > 0)
			{
				lblist.SelectedIndex = 0;
			}

			btdelete.Enabled = (lblist.SelectedIndex >= 0);

			this.Checks2cp(this.cb2cp, null);
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
			if (this.cb2cp.Checked)
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
			lldep.Enabled = this.cb2cp.Checked;
			tbguid.Enabled = this.cb2cp.Checked;
			cbcompress.Enabled = this.cb2cp.Checked;
			tbtitle.Enabled = this.cb2cp.Checked;
			tbauthor.Enabled = this.cb2cp.Checked;
			tbcontact.Enabled = this.cb2cp.Checked;
			tbver.Enabled = this.cb2cp.Checked;

			if (cb2cp.Checked)
			{
				if (this.tbflname.Text.Trim().ToLower().EndsWith(".sims2pack"))
				{
					this.tbflname.Text =
						this.tbflname.Text.Trim()
							.Substring(0, this.tbflname.Text.Trim().Length - 8)
						+ ".s2cp";
				}
				else if (this.tbflname.Text.Trim().ToLower().EndsWith(".s2cp"))
				{
					this.tbflname.Text =
						this.tbflname.Text.Trim()
							.Substring(0, this.tbflname.Text.Trim().Length - 5)
						+ ".sims2pack";
				}
			}
		}
	}
}
