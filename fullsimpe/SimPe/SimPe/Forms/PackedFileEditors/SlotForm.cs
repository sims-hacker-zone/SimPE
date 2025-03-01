// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Windows.Forms;

using SimPe.PackedFiles.Wrapper;

namespace SimPe.Forms.PackedFileEditors
{
	/// <summary>
	/// Summary description for SlotForm.
	/// </summary>
	public class SlotForm : Form
	{
		internal Panel pnslot;
		private Panel panel4;
		internal Label label12;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label label5;
		private Label label6;
		private Label label7;
		private Label label8;
		private TextBox tbf1;
		private TextBox tbf2;
		private TextBox tbf3;
		private TextBox tbi1;
		private TextBox tbi2;
		private TextBox tbi3;
		private TextBox tbi4;
		private TextBox tbi5;
		private Label label9;
		internal ComboBox cbtype;
		internal TabControl tabControl1;
		internal TabPage tabPage1;
		internal TabPage tabPage2;
		internal TabPage tabPage3;
		internal TabPage tabPage4;
		internal TabPage tabPage5;
		internal TabPage tabPageA;
		internal TabPage tabPage6;
		internal TabPage tabPage7;
		private Label label10;
		private TextBox tbf6;
		private Label label11;
		private TextBox tbf5;
		private Label label13;
		private TextBox tbf4;
		private Label label14;
		private TextBox tbi6;
		private Label label15;
		private TextBox tbs2;
		private Label label16;
		private TextBox tbs1;
		private Label label17;
		private TextBox tbf7;
		private Label label18;
		private TextBox tbf8;
		private Label label19;
		private TextBox tbi7;
		private Label label20;
		private Label label0A;
		private TextBox tbi8;
		private TextBox tbs3;
		private Label label21;
		private TextBox tbi10;
		private Label label22;
		private TextBox tbi9;
		private GroupBox groupBox1;
		private Label label23;
		internal TextBox tbver;
		private Label label24;
		internal TextBox tbname;
		internal ListView lv;
		private LinkLabel visualStyleLinkLabel1;
		private LinkLabel visualStyleLinkLabel2;
		private LinkLabel visualStyleLinkLabel3;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SlotForm()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			//
			// TODO: Fügen Sie den Konstruktorcode nach dem Aufruf von InitializeComponent hinzu
			//
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
			pnslot = new Panel();
			visualStyleLinkLabel3 = new LinkLabel();
			visualStyleLinkLabel2 = new LinkLabel();
			visualStyleLinkLabel1 = new LinkLabel();
			lv = new ListView();
			groupBox1 = new GroupBox();
			tbname = new TextBox();
			label24 = new Label();
			label23 = new Label();
			tbver = new TextBox();
			tabControl1 = new TabControl();
			tabPage1 = new TabPage();
			label14 = new Label();
			tbi6 = new TextBox();
			label10 = new Label();
			tbf6 = new TextBox();
			label11 = new Label();
			tbf5 = new TextBox();
			label13 = new Label();
			tbf4 = new TextBox();
			tabPage2 = new TabPage();
			label15 = new Label();
			tbs2 = new TextBox();
			label16 = new Label();
			tbs1 = new TextBox();
			tabPage3 = new TabPage();
			label17 = new Label();
			tbf7 = new TextBox();
			tabPage4 = new TabPage();
			label19 = new Label();
			tbi7 = new TextBox();
			tabPage5 = new TabPage();
			tabPageA = new TabPage();
			label20 = new Label();
			label0A = new Label();
			tbi8 = new TextBox();
			tbs3 = new TextBox();
			tabPage6 = new TabPage();
			label18 = new Label();
			tbf8 = new TextBox();
			tabPage7 = new TabPage();
			label21 = new Label();
			tbi10 = new TextBox();
			label22 = new Label();
			tbi9 = new TextBox();
			cbtype = new ComboBox();
			label9 = new Label();
			label8 = new Label();
			tbi5 = new TextBox();
			label7 = new Label();
			tbi4 = new TextBox();
			label6 = new Label();
			tbi3 = new TextBox();
			label5 = new Label();
			tbi2 = new TextBox();
			label4 = new Label();
			tbi1 = new TextBox();
			label3 = new Label();
			tbf3 = new TextBox();
			label2 = new Label();
			tbf2 = new TextBox();
			label1 = new Label();
			tbf1 = new TextBox();
			panel4 = new Panel();
			label12 = new Label();
			pnslot.SuspendLayout();
			groupBox1.SuspendLayout();
			tabControl1.SuspendLayout();
			tabPage1.SuspendLayout();
			tabPage2.SuspendLayout();
			tabPage3.SuspendLayout();
			tabPage4.SuspendLayout();
			tabPage5.SuspendLayout();
			tabPageA.SuspendLayout();
			tabPage6.SuspendLayout();
			tabPage7.SuspendLayout();
			SuspendLayout();
			//
			// pnslot
			//
			pnslot.BackColor = System.Drawing.Color.Transparent;
			pnslot.Controls.Add(visualStyleLinkLabel3);
			pnslot.Controls.Add(visualStyleLinkLabel2);
			pnslot.Controls.Add(visualStyleLinkLabel1);
			pnslot.Controls.Add(lv);
			pnslot.Controls.Add(groupBox1);
			pnslot.Controls.Add(tabControl1);
			pnslot.Controls.Add(cbtype);
			pnslot.Controls.Add(label9);
			pnslot.Controls.Add(label8);
			pnslot.Controls.Add(tbi5);
			pnslot.Controls.Add(label7);
			pnslot.Controls.Add(tbi4);
			pnslot.Controls.Add(label6);
			pnslot.Controls.Add(tbi3);
			pnslot.Controls.Add(label5);
			pnslot.Controls.Add(tbi2);
			pnslot.Controls.Add(label4);
			pnslot.Controls.Add(tbi1);
			pnslot.Controls.Add(label3);
			pnslot.Controls.Add(tbf3);
			pnslot.Controls.Add(label2);
			pnslot.Controls.Add(tbf2);
			pnslot.Controls.Add(label1);
			pnslot.Controls.Add(tbf1);
			pnslot.Controls.Add(panel4);
			pnslot.Font = new System.Drawing.Font("Verdana", 8.25F);
			pnslot.Location = new System.Drawing.Point(14, 29);
			pnslot.Name = "pnslot";
			pnslot.Size = new System.Drawing.Size(730, 332);
			pnslot.TabIndex = 9;
			//
			// visualStyleLinkLabel3
			//
			visualStyleLinkLabel3.Anchor =


						AnchorStyles.Bottom
						| AnchorStyles.Right


			;
			visualStyleLinkLabel3.BackColor = System.Drawing.Color.Transparent;
			visualStyleLinkLabel3.Font = new System.Drawing.Font(
				"Verdana",
				11.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			visualStyleLinkLabel3.Location = new System.Drawing.Point(100, 305);
			visualStyleLinkLabel3.Name = "visualStyleLinkLabel3";
			visualStyleLinkLabel3.Size = new System.Drawing.Size(54, 23);
			visualStyleLinkLabel3.TabIndex = 28;
			visualStyleLinkLabel3.TabStop = true;
			visualStyleLinkLabel3.Text = "Clone";
			visualStyleLinkLabel3.TextAlign = System
				.Drawing
				.ContentAlignment
				.MiddleRight;
			visualStyleLinkLabel3.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(Clone);
			//
			// visualStyleLinkLabel2
			//
			visualStyleLinkLabel2.Anchor =


						AnchorStyles.Bottom
						| AnchorStyles.Right


			;
			visualStyleLinkLabel2.BackColor = System.Drawing.Color.Transparent;
			visualStyleLinkLabel2.Font = new System.Drawing.Font(
				"Verdana",
				11.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			visualStyleLinkLabel2.Location = new System.Drawing.Point(178, 305);
			visualStyleLinkLabel2.Name = "visualStyleLinkLabel2";
			visualStyleLinkLabel2.Size = new System.Drawing.Size(64, 23);
			visualStyleLinkLabel2.TabIndex = 27;
			visualStyleLinkLabel2.TabStop = true;
			visualStyleLinkLabel2.Text = "Delete";
			visualStyleLinkLabel2.TextAlign = System
				.Drawing
				.ContentAlignment
				.MiddleRight;
			visualStyleLinkLabel2.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(Delete);
			//
			// visualStyleLinkLabel1
			//
			visualStyleLinkLabel1.Anchor =


						AnchorStyles.Bottom
						| AnchorStyles.Right


			;
			visualStyleLinkLabel1.BackColor = System.Drawing.Color.Transparent;
			visualStyleLinkLabel1.Font = new System.Drawing.Font(
				"Verdana",
				11.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			visualStyleLinkLabel1.Location = new System.Drawing.Point(266, 305);
			visualStyleLinkLabel1.Name = "visualStyleLinkLabel1";
			visualStyleLinkLabel1.Size = new System.Drawing.Size(46, 23);
			visualStyleLinkLabel1.TabIndex = 26;
			visualStyleLinkLabel1.TabStop = true;
			visualStyleLinkLabel1.Text = "Add";
			visualStyleLinkLabel1.TextAlign = System
				.Drawing
				.ContentAlignment
				.MiddleRight;
			visualStyleLinkLabel1.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(Add);
			//
			// lv
			//
			lv.Anchor =




								AnchorStyles.Top
								| AnchorStyles.Bottom
							 | AnchorStyles.Left
						 | AnchorStyles.Right


			;
			lv.FullRowSelect = true;
			lv.GridLines = true;
			lv.HideSelection = false;
			lv.Location = new System.Drawing.Point(8, 120);
			lv.MultiSelect = false;
			lv.Name = "lv";
			lv.Size = new System.Drawing.Size(304, 182);
			lv.TabIndex = 24;
			lv.UseCompatibleStateImageBehavior = false;
			lv.View = View.Details;
			lv.SelectedIndexChanged += new EventHandler(Select);
			//
			// groupBox1
			//
			groupBox1.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Left
						 | AnchorStyles.Right


			;
			groupBox1.Controls.Add(tbname);
			groupBox1.Controls.Add(label24);
			groupBox1.Controls.Add(label23);
			groupBox1.Controls.Add(tbver);
			groupBox1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox1.Location = new System.Drawing.Point(8, 32);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(304, 80);
			groupBox1.TabIndex = 23;
			groupBox1.TabStop = false;
			groupBox1.Text = "File Settings:";
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
			tbname.Location = new System.Drawing.Point(72, 48);
			tbname.Name = "tbname";
			tbname.Size = new System.Drawing.Size(224, 21);
			tbname.TabIndex = 9;
			tbname.TextChanged += new EventHandler(ChangeWrp);
			//
			// label24
			//
			label24.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label24.Location = new System.Drawing.Point(8, 48);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(56, 23);
			label24.TabIndex = 8;
			label24.Text = "Name:";
			label24.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// label23
			//
			label23.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label23.Location = new System.Drawing.Point(8, 24);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(56, 23);
			label23.TabIndex = 7;
			label23.Text = "Version:";
			label23.TextAlign = System.Drawing.ContentAlignment.BottomRight;
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
			tbver.Location = new System.Drawing.Point(72, 24);
			tbver.Name = "tbver";
			tbver.Size = new System.Drawing.Size(88, 21);
			tbver.TabIndex = 6;
			tbver.Text = "0";
			tbver.TextChanged += new EventHandler(ChangeWrp);
			//
			// tabControl1
			//
			tabControl1.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage2);
			tabControl1.Controls.Add(tabPage3);
			tabControl1.Controls.Add(tabPage4);
			tabControl1.Controls.Add(tabPage5);
			tabControl1.Controls.Add(tabPageA);
			tabControl1.Controls.Add(tabPage6);
			tabControl1.Controls.Add(tabPage7);
			tabControl1.Location = new System.Drawing.Point(320, 144);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new System.Drawing.Size(400, 114);
			tabControl1.TabIndex = 22;
			//
			// tabPage1
			//
			tabPage1.Controls.Add(label14);
			tabPage1.Controls.Add(tbi6);
			tabPage1.Controls.Add(label10);
			tabPage1.Controls.Add(tbf6);
			tabPage1.Controls.Add(label11);
			tabPage1.Controls.Add(tbf5);
			tabPage1.Controls.Add(label13);
			tabPage1.Controls.Add(tbf4);
			tabPage1.Location = new System.Drawing.Point(4, 22);
			tabPage1.Name = "tabPage1";
			tabPage1.Size = new System.Drawing.Size(392, 88);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "Version 0x05+";
			//
			// label14
			//
			label14.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			label14.Location = new System.Drawing.Point(136, 8);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(56, 23);
			label14.TabIndex = 17;
			label14.Text = "Int 6:";
			label14.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// tbi6
			//
			tbi6.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			tbi6.Location = new System.Drawing.Point(200, 8);
			tbi6.Name = "tbi6";
			tbi6.Size = new System.Drawing.Size(64, 21);
			tbi6.TabIndex = 16;
			tbi6.Text = "0";
			tbi6.TextChanged += new EventHandler(Changed);
			//
			// label10
			//
			label10.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			label10.Location = new System.Drawing.Point(8, 56);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(56, 23);
			label10.TabIndex = 15;
			label10.Text = "Float 6:";
			label10.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// tbf6
			//
			tbf6.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			tbf6.Location = new System.Drawing.Point(72, 56);
			tbf6.Name = "tbf6";
			tbf6.Size = new System.Drawing.Size(64, 21);
			tbf6.TabIndex = 14;
			tbf6.Text = "0";
			tbf6.TextChanged += new EventHandler(Changed);
			//
			// label11
			//
			label11.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			label11.Location = new System.Drawing.Point(8, 32);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(56, 23);
			label11.TabIndex = 13;
			label11.Text = "Float 5:";
			label11.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// tbf5
			//
			tbf5.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			tbf5.Location = new System.Drawing.Point(72, 32);
			tbf5.Name = "tbf5";
			tbf5.Size = new System.Drawing.Size(64, 21);
			tbf5.TabIndex = 12;
			tbf5.Text = "0";
			tbf5.TextChanged += new EventHandler(Changed);
			//
			// label13
			//
			label13.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			label13.Location = new System.Drawing.Point(8, 8);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(56, 23);
			label13.TabIndex = 11;
			label13.Text = "Float 4:";
			label13.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// tbf4
			//
			tbf4.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			tbf4.Location = new System.Drawing.Point(72, 8);
			tbf4.Name = "tbf4";
			tbf4.Size = new System.Drawing.Size(64, 21);
			tbf4.TabIndex = 10;
			tbf4.Text = "0";
			tbf4.TextChanged += new EventHandler(Changed);
			//
			// tabPage2
			//
			tabPage2.Controls.Add(label15);
			tabPage2.Controls.Add(tbs2);
			tabPage2.Controls.Add(label16);
			tabPage2.Controls.Add(tbs1);
			tabPage2.Location = new System.Drawing.Point(4, 22);
			tabPage2.Name = "tabPage2";
			tabPage2.Size = new System.Drawing.Size(392, 88);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "0x06+";
			//
			// label15
			//
			label15.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			label15.Location = new System.Drawing.Point(8, 32);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(56, 23);
			label15.TabIndex = 17;
			label15.Text = "Short 2:";
			label15.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// tbs2
			//
			tbs2.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			tbs2.Location = new System.Drawing.Point(72, 32);
			tbs2.Name = "tbs2";
			tbs2.Size = new System.Drawing.Size(64, 21);
			tbs2.TabIndex = 16;
			tbs2.Text = "0";
			tbs2.TextChanged += new EventHandler(Changed);
			//
			// label16
			//
			label16.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			label16.Location = new System.Drawing.Point(8, 8);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(56, 23);
			label16.TabIndex = 15;
			label16.Text = "Short 1:";
			label16.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// tbs1
			//
			tbs1.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			tbs1.Location = new System.Drawing.Point(72, 8);
			tbs1.Name = "tbs1";
			tbs1.Size = new System.Drawing.Size(64, 21);
			tbs1.TabIndex = 14;
			tbs1.Text = "0";
			tbs1.TextChanged += new EventHandler(Changed);
			//
			// tabPage3
			//
			tabPage3.Controls.Add(label17);
			tabPage3.Controls.Add(tbf7);
			tabPage3.Location = new System.Drawing.Point(4, 22);
			tabPage3.Name = "tabPage3";
			tabPage3.Size = new System.Drawing.Size(392, 88);
			tabPage3.TabIndex = 2;
			tabPage3.Text = "0x07+";
			//
			// label17
			//
			label17.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			label17.Location = new System.Drawing.Point(8, 8);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(56, 23);
			label17.TabIndex = 7;
			label17.Text = "Float 7:";
			label17.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// tbf7
			//
			tbf7.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			tbf7.Location = new System.Drawing.Point(72, 8);
			tbf7.Name = "tbf7";
			tbf7.Size = new System.Drawing.Size(64, 21);
			tbf7.TabIndex = 6;
			tbf7.Text = "0";
			tbf7.TextChanged += new EventHandler(Changed);
			//
			// tabPage4
			//
			tabPage4.Controls.Add(label19);
			tabPage4.Controls.Add(tbi7);
			tabPage4.Location = new System.Drawing.Point(4, 22);
			tabPage4.Name = "tabPage4";
			tabPage4.Size = new System.Drawing.Size(392, 88);
			tabPage4.TabIndex = 3;
			tabPage4.Text = "0x08+";
			//
			// label19
			//
			label19.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			label19.Location = new System.Drawing.Point(8, 8);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(56, 23);
			label19.TabIndex = 13;
			label19.Text = "Int 7:";
			label19.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// tbi7
			//
			tbi7.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			tbi7.Location = new System.Drawing.Point(72, 8);
			tbi7.Name = "tbi7";
			tbi7.Size = new System.Drawing.Size(64, 21);
			tbi7.TabIndex = 12;
			tbi7.Text = "0";
			tbi7.TextChanged += new EventHandler(Changed);
			//
			// tabPageA
			//
			tabPageA.Controls.Add(label0A);
			tabPageA.Controls.Add(tbs3);
			tabPageA.Location = new System.Drawing.Point(4, 22);
			tabPageA.Name = "tabPageA";
			tabPageA.Size = new System.Drawing.Size(392, 88);
			tabPageA.TabIndex = 7;
			tabPageA.Text = "0x0A";
			//
			// label0A
			//
			label0A.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			label0A.Location = new System.Drawing.Point(8, 8);
			label0A.Name = "label0A";
			label0A.Size = new System.Drawing.Size(56, 23);
			label0A.TabIndex = 13;
			label0A.Text = "Short 3:";
			label0A.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// tbs3
			//
			tbs3.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			tbs3.Location = new System.Drawing.Point(72, 8);
			tbs3.Name = "tbs3";
			tbs3.Size = new System.Drawing.Size(64, 21);
			tbs3.TabIndex = 12;
			tbs3.Text = "0";
			tbs3.TextChanged += new EventHandler(Changed);
			//
			// tabPage5
			//
			tabPage5.Controls.Add(label20);
			tabPage5.Controls.Add(tbi8);
			tabPage5.Location = new System.Drawing.Point(4, 22);
			tabPage5.Name = "tabPage5";
			tabPage5.Size = new System.Drawing.Size(392, 88);
			tabPage5.TabIndex = 4;
			tabPage5.Text = "0x09+";
			//
			// label20
			//
			label20.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			label20.Location = new System.Drawing.Point(8, 8);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(56, 23);
			label20.TabIndex = 13;
			label20.Text = "Int 8:";
			label20.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// tbi8
			//
			tbi8.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			tbi8.Location = new System.Drawing.Point(72, 8);
			tbi8.Name = "tbi8";
			tbi8.Size = new System.Drawing.Size(64, 21);
			tbi8.TabIndex = 12;
			tbi8.Text = "0";
			tbi8.TextChanged += new EventHandler(Changed);
			//
			// tabPage6
			//
			tabPage6.Controls.Add(label18);
			tabPage6.Controls.Add(tbf8);
			tabPage6.Location = new System.Drawing.Point(4, 22);
			tabPage6.Name = "tabPage6";
			tabPage6.Size = new System.Drawing.Size(392, 88);
			tabPage6.TabIndex = 5;
			tabPage6.Text = "0x10+";
			//
			// label18
			//
			label18.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			label18.Location = new System.Drawing.Point(8, 8);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(56, 23);
			label18.TabIndex = 7;
			label18.Text = "Float 8:";
			label18.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// tbf8
			//
			tbf8.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			tbf8.Location = new System.Drawing.Point(72, 8);
			tbf8.Name = "tbf8";
			tbf8.Size = new System.Drawing.Size(64, 21);
			tbf8.TabIndex = 6;
			tbf8.Text = "0";
			tbf8.TextChanged += new EventHandler(Changed);
			//
			// tabPage7
			//
			tabPage7.Controls.Add(label21);
			tabPage7.Controls.Add(tbi10);
			tabPage7.Controls.Add(label22);
			tabPage7.Controls.Add(tbi9);
			tabPage7.Location = new System.Drawing.Point(4, 22);
			tabPage7.Name = "tabPage7";
			tabPage7.Size = new System.Drawing.Size(392, 88);
			tabPage7.TabIndex = 6;
			tabPage7.Text = "0x40+";
			//
			// label21
			//
			label21.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			label21.Location = new System.Drawing.Point(8, 32);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(56, 23);
			label21.TabIndex = 23;
			label21.Text = "Int 10:";
			label21.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// tbi10
			//
			tbi10.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			tbi10.Location = new System.Drawing.Point(72, 32);
			tbi10.Name = "tbi10";
			tbi10.Size = new System.Drawing.Size(64, 21);
			tbi10.TabIndex = 22;
			tbi10.Text = "0";
			tbi10.TextChanged += new EventHandler(Changed);
			//
			// label22
			//
			label22.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			label22.Location = new System.Drawing.Point(8, 8);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(56, 23);
			label22.TabIndex = 21;
			label22.Text = "Int 9:";
			label22.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// tbi9
			//
			tbi9.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			tbi9.Location = new System.Drawing.Point(72, 8);
			tbi9.Name = "tbi9";
			tbi9.Size = new System.Drawing.Size(64, 21);
			tbi9.TabIndex = 20;
			tbi9.Text = "0";
			tbi9.TextChanged += new EventHandler(Changed);
			//
			// cbtype
			//
			cbtype.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			cbtype.DropDownStyle = ComboBoxStyle.DropDownList;
			cbtype.Location = new System.Drawing.Point(392, 32);
			cbtype.Name = "cbtype";
			cbtype.Size = new System.Drawing.Size(136, 21);
			cbtype.TabIndex = 21;
			cbtype.SelectedIndexChanged += new EventHandler(Changed);
			//
			// label9
			//
			label9.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			label9.BackColor = System.Drawing.Color.Transparent;
			label9.Location = new System.Drawing.Point(328, 32);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(56, 23);
			label9.TabIndex = 20;
			label9.Text = "Type:";
			label9.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// label8
			//
			label8.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			label8.BackColor = System.Drawing.Color.Transparent;
			label8.Location = new System.Drawing.Point(584, 88);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(56, 23);
			label8.TabIndex = 19;
			label8.Text = "Int 5:";
			label8.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// tbi5
			//
			tbi5.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			tbi5.Location = new System.Drawing.Point(648, 88);
			tbi5.Name = "tbi5";
			tbi5.Size = new System.Drawing.Size(64, 21);
			tbi5.TabIndex = 18;
			tbi5.Text = "0";
			tbi5.TextChanged += new EventHandler(Changed);
			//
			// label7
			//
			label7.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			label7.BackColor = System.Drawing.Color.Transparent;
			label7.Location = new System.Drawing.Point(584, 64);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(56, 23);
			label7.TabIndex = 17;
			label7.Text = "Int 4:";
			label7.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// tbi4
			//
			tbi4.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			tbi4.Location = new System.Drawing.Point(648, 64);
			tbi4.Name = "tbi4";
			tbi4.Size = new System.Drawing.Size(64, 21);
			tbi4.TabIndex = 16;
			tbi4.Text = "0";
			tbi4.TextChanged += new EventHandler(Changed);
			//
			// label6
			//
			label6.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			label6.BackColor = System.Drawing.Color.Transparent;
			label6.Location = new System.Drawing.Point(456, 112);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(56, 23);
			label6.TabIndex = 15;
			label6.Text = "Int 3:";
			label6.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// tbi3
			//
			tbi3.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			tbi3.Location = new System.Drawing.Point(520, 112);
			tbi3.Name = "tbi3";
			tbi3.Size = new System.Drawing.Size(64, 21);
			tbi3.TabIndex = 14;
			tbi3.Text = "0";
			tbi3.TextChanged += new EventHandler(Changed);
			//
			// label5
			//
			label5.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			label5.BackColor = System.Drawing.Color.Transparent;
			label5.Location = new System.Drawing.Point(456, 88);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(56, 23);
			label5.TabIndex = 13;
			label5.Text = "Int 2:";
			label5.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// tbi2
			//
			tbi2.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			tbi2.Location = new System.Drawing.Point(520, 88);
			tbi2.Name = "tbi2";
			tbi2.Size = new System.Drawing.Size(64, 21);
			tbi2.TabIndex = 12;
			tbi2.Text = "0";
			tbi2.TextChanged += new EventHandler(Changed);
			//
			// label4
			//
			label4.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			label4.BackColor = System.Drawing.Color.Transparent;
			label4.Location = new System.Drawing.Point(456, 64);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(56, 23);
			label4.TabIndex = 11;
			label4.Text = "Int 1:";
			label4.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// tbi1
			//
			tbi1.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			tbi1.Location = new System.Drawing.Point(520, 64);
			tbi1.Name = "tbi1";
			tbi1.Size = new System.Drawing.Size(64, 21);
			tbi1.TabIndex = 10;
			tbi1.Text = "0";
			tbi1.TextChanged += new EventHandler(Changed);
			//
			// label3
			//
			label3.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			label3.BackColor = System.Drawing.Color.Transparent;
			label3.Location = new System.Drawing.Point(328, 112);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 23);
			label3.TabIndex = 9;
			label3.Text = "Float 3:";
			label3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// tbf3
			//
			tbf3.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			tbf3.Location = new System.Drawing.Point(392, 112);
			tbf3.Name = "tbf3";
			tbf3.Size = new System.Drawing.Size(64, 21);
			tbf3.TabIndex = 8;
			tbf3.Text = "0";
			tbf3.TextChanged += new EventHandler(Changed);
			//
			// label2
			//
			label2.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			label2.BackColor = System.Drawing.Color.Transparent;
			label2.Location = new System.Drawing.Point(328, 88);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(56, 23);
			label2.TabIndex = 7;
			label2.Text = "Float 2:";
			label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// tbf2
			//
			tbf2.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			tbf2.Location = new System.Drawing.Point(392, 88);
			tbf2.Name = "tbf2";
			tbf2.Size = new System.Drawing.Size(64, 21);
			tbf2.TabIndex = 6;
			tbf2.Text = "0";
			tbf2.TextChanged += new EventHandler(Changed);
			//
			// label1
			//
			label1.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.Location = new System.Drawing.Point(328, 64);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(56, 23);
			label1.TabIndex = 5;
			label1.Text = "Float 1:";
			label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// tbf1
			//
			tbf1.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			tbf1.Location = new System.Drawing.Point(392, 64);
			tbf1.Name = "tbf1";
			tbf1.Size = new System.Drawing.Size(64, 21);
			tbf1.TabIndex = 4;
			tbf1.Text = "0";
			tbf1.TextChanged += new EventHandler(Changed);
			//
			// panel4
			//
			panel4.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Left
						 | AnchorStyles.Right


			;
			panel4.Location = new System.Drawing.Point(0, 0);
			panel4.Margin = new Padding(0);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(730, 24);
			panel4.TabIndex = 0;
			//
			// label12
			//
			label12.AutoSize = true;
			label12.ImeMode = ImeMode.NoControl;
			label12.Location = new System.Drawing.Point(0, 4);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(83, 16);
			label12.TabIndex = 0;
			label12.Text = "Slot Editor";
			//
			// SlotForm
			//
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(920, 406);
			Controls.Add(pnslot);
			Name = "SlotForm";
			Text = "SlotForm";
			pnslot.ResumeLayout(false);
			pnslot.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			tabControl1.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage1.PerformLayout();
			tabPage2.ResumeLayout(false);
			tabPage2.PerformLayout();
			tabPage3.ResumeLayout(false);
			tabPage3.PerformLayout();
			tabPage4.ResumeLayout(false);
			tabPage4.PerformLayout();
			tabPage5.ResumeLayout(false);
			tabPage5.PerformLayout();
			tabPageA.ResumeLayout(false);
			tabPageA.PerformLayout();
			tabPage6.ResumeLayout(false);
			tabPage6.PerformLayout();
			tabPage7.ResumeLayout(false);
			tabPage7.PerformLayout();
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			ResumeLayout(false);
		}
		#endregion

		internal Slot wrapper;

		internal void ShowItem(SlotItem si)
		{
			ListViewItem lvi = new ListViewItem();
			ShowItem(si, lvi);
			lv.Items.Add(lvi);
		}

		void ShowItem(SlotItem si, ListViewItem lvi)
		{
			lvi.Tag = si;
			lvi.SubItems.Clear();

			lvi.Text = si.Type.ToString();

			lvi.SubItems.Add(si.UnknownFloat1.ToString());
			lvi.SubItems.Add(si.UnknownFloat2.ToString());
			lvi.SubItems.Add(si.UnknownFloat3.ToString());

			lvi.SubItems.Add(si.UnknownInt1.ToString());
			lvi.SubItems.Add(si.UnknownInt2.ToString());
			lvi.SubItems.Add(si.UnknownInt3.ToString());
			lvi.SubItems.Add(si.UnknownInt4.ToString());
			lvi.SubItems.Add(si.UnknownInt5.ToString());

			if (wrapper.Version >= 5)
			{
				lvi.SubItems.Add(si.UnknownFloat4.ToString());
				lvi.SubItems.Add(si.UnknownFloat5.ToString());
				lvi.SubItems.Add(si.UnknownFloat6.ToString());

				lvi.SubItems.Add(si.UnknownInt6.ToString());
			}

			if (wrapper.Version >= 6)
			{
				lvi.SubItems.Add(si.UnknownShort1.ToString());
				lvi.SubItems.Add(si.UnknownShort2.ToString());
			}

			if (wrapper.Version >= 7)
			{
				lvi.SubItems.Add(si.UnknownFloat7.ToString());
			}

			if (wrapper.Version >= 8)
			{
				lvi.SubItems.Add(si.UnknownInt7.ToString());
			}

			if (wrapper.Version >= 9)
			{
				lvi.SubItems.Add(si.UnknownInt8.ToString());
			}

			if (wrapper.Version == 10)
			{
				lvi.SubItems.Add(si.UnknownShort3.ToString());
			}

			if (wrapper.Version >= 0x10)
			{
				lvi.SubItems.Add(si.UnknownFloat8.ToString());
			}

			if (wrapper.Version >= 0x40)
			{
				lvi.SubItems.Add(si.UnknownInt9.ToString());
				lvi.SubItems.Add(si.UnknownInt10.ToString());
				;
			}
		}

		private void Select(object sender, EventArgs e)
		{
			if (lv.SelectedItems.Count == 0)
			{
				return;
			}

			Tag = true;
			try
			{
				SlotItem si =
					(SlotItem)lv.SelectedItems[0].Tag;

				int ct = 0;
				foreach (SlotItemType sti in cbtype.Items)
				{
					if (sti == si.Type)
					{
						cbtype.SelectedIndex = ct;
					}

					ct++;
				}

				tbf1.Text = si.UnknownFloat1.ToString();
				tbf2.Text = si.UnknownFloat2.ToString();
				tbf3.Text = si.UnknownFloat3.ToString();
				tbf4.Text = si.UnknownFloat4.ToString();
				tbf5.Text = si.UnknownFloat5.ToString();
				tbf6.Text = si.UnknownFloat6.ToString();
				tbf7.Text = si.UnknownFloat7.ToString();
				tbf8.Text = si.UnknownFloat8.ToString();

				tbi1.Text = si.UnknownInt1.ToString();
				tbi2.Text = si.UnknownInt2.ToString();
				tbi3.Text = si.UnknownInt3.ToString();
				tbi4.Text = si.UnknownInt4.ToString();
				tbi5.Text = si.UnknownInt5.ToString();
				tbi6.Text = si.UnknownInt6.ToString();
				tbi7.Text = si.UnknownInt7.ToString();
				tbi8.Text = si.UnknownInt8.ToString();
				tbi9.Text = si.UnknownInt9.ToString();
				tbi10.Text = si.UnknownInt10.ToString();

				tbs1.Text = si.UnknownShort1.ToString();
				tbs2.Text = si.UnknownShort2.ToString();
				tbs3.Text = si.UnknownShort3.ToString();
			}
			finally
			{
				Tag = null;
			}
		}

		private void Changed(object sender, EventArgs e)
		{
			if (Tag != null)
			{
				return;
			}

			if (lv.SelectedItems.Count == 0)
			{
				return;
			}

			try
			{
				SlotItem si =
					(SlotItem)lv.SelectedItems[0].Tag;

				if (cbtype.SelectedIndex >= 0)
				{
					si.Type = (SlotItemType)cbtype.Items[cbtype.SelectedIndex];
				}

				si.UnknownFloat1 = Convert.ToSingle(tbf1.Text);
				si.UnknownFloat2 = Convert.ToSingle(tbf2.Text);
				si.UnknownFloat3 = Convert.ToSingle(tbf3.Text);
				si.UnknownFloat4 = Convert.ToSingle(tbf4.Text);
				si.UnknownFloat5 = Convert.ToSingle(tbf5.Text);
				si.UnknownFloat6 = Convert.ToSingle(tbf6.Text);
				si.UnknownFloat7 = Convert.ToSingle(tbf7.Text);
				si.UnknownFloat8 = Convert.ToSingle(tbf8.Text);

				si.UnknownInt1 = Convert.ToInt32(tbi1.Text);
				si.UnknownInt2 = Convert.ToInt32(tbi2.Text);
				si.UnknownInt3 = Convert.ToInt32(tbi3.Text);
				si.UnknownInt4 = Convert.ToInt32(tbi4.Text);
				si.UnknownInt5 = Convert.ToInt32(tbi5.Text);
				si.UnknownInt6 = Convert.ToInt32(tbi6.Text);
				si.UnknownInt7 = Convert.ToInt32(tbi7.Text);
				si.UnknownInt8 = Convert.ToInt32(tbi8.Text);
				si.UnknownInt9 = Convert.ToInt32(tbi9.Text);
				si.UnknownInt10 = Convert.ToInt32(tbi10.Text);

				si.UnknownShort1 = Convert.ToInt16(tbs1.Text);
				si.UnknownShort2 = Convert.ToInt16(tbs2.Text);
				si.UnknownShort3 = Convert.ToInt16(tbs3.Text);

				wrapper.Changed = true;

				ShowItem(si, lv.SelectedItems[0]);
			}
			catch { }
		}

		private void ChangeWrp(object sender, EventArgs e)
		{
			if (Tag != null)
			{
				return;
			}

			wrapper.FileName = tbname.Text;
			wrapper.Changed = true;
		}

		private void btcommit_Click(object sender, EventArgs e)
		{
			wrapper.SynchronizeUserData();
		}

		private void Add(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			SlotItem si = new SlotItem(wrapper);
			wrapper.Items.Add(si);
			ShowItem(si);
			wrapper.Changed = true;
		}

		private void Delete(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (lv.SelectedItems.Count == 0)
			{
				return;
			}

			try
			{
				SlotItem si =
					(SlotItem)lv.SelectedItems[0].Tag;

				wrapper.Items.Remove(si);
				lv.Items.Remove(lv.SelectedItems[0]);
				wrapper.Changed = true;
			}
			catch { }
		}

		private void Clone(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (lv.SelectedItems.Count == 0)
			{
				return;
			}

			SlotItem si = new SlotItem(wrapper);
			SlotItem sv = (SlotItem)
				lv.SelectedItems[0].Tag;
			si.Type = sv.Type;
			si.UnknownFloat1 = sv.UnknownFloat1;
			si.UnknownFloat2 = sv.UnknownFloat2;
			si.UnknownFloat3 = sv.UnknownFloat3;
			si.UnknownFloat4 = sv.UnknownFloat4;
			si.UnknownFloat5 = sv.UnknownFloat5;
			si.UnknownFloat6 = sv.UnknownFloat6;
			si.UnknownFloat7 = sv.UnknownFloat7;
			si.UnknownFloat8 = sv.UnknownFloat8;
			si.UnknownInt1 = sv.UnknownInt1;
			si.UnknownInt2 = sv.UnknownInt2;
			si.UnknownInt3 = sv.UnknownInt3;
			si.UnknownInt4 = sv.UnknownInt4;
			si.UnknownInt5 = sv.UnknownInt5;
			si.UnknownInt6 = sv.UnknownInt6;
			si.UnknownInt7 = sv.UnknownInt7;
			si.UnknownInt8 = sv.UnknownInt8;
			si.UnknownInt9 = sv.UnknownInt9;
			si.UnknownInt10 = sv.UnknownInt10;
			si.UnknownShort1 = sv.UnknownShort1;
			si.UnknownShort2 = sv.UnknownShort2;
			si.UnknownShort3 = sv.UnknownShort3;
			wrapper.Items.Add(si);
			ShowItem(si);
			wrapper.Changed = true;
		}
	}
}
