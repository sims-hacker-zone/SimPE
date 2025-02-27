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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Ambertation.Windows.Forms;

using SimPe.Data;
using SimPe.PackedFiles.Wrapper;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for ExtNgbhUI.
	/// </summary>
	public class BnfoUI
		: Windows.Forms.WrapperBaseControl,
			Interfaces.Plugin.IPackedFileUI
	{
		private BnfoCustomerItemsUI lv;
		private BnfoCustomerItemUI bnfoCustomerItemUI1;
		private ToolStrip toolBar1;
		private ToolStripButton biMax;
		private ToolStripButton biReward;
		private ToolStripButton biWorkers;
		private Panel panel1;
		private Panel panel2;
		private Panel Panel3;
		private Panel Panel4;
		private Panel gpreven;
		private Panel gpexpen;
		private ExtProgressBar pbpay;
		private Label label1;
		private Label lblot;
		private Label label2;
		private Label label3;
		private Label lbright;
		private Label lbassi;
		private Label lbsgender;
		private Label lbwages;
		private Label lbsimage;
		private Label lbLaball;
		private Label lbpay;
		private Label lbaward;
		private Label lbadvice;
		private Label lbcashf;
		private Label lbchgender;
		private Label lbchage;
		private Label lbchoose;
		private Label lbOgender;
		private Label lbOage;
		private Label lbOchoos;
		private TextBox tbOgender;
		private TextBox tbOchage;
		private TextBox tbchgender;
		private TextBox tbchage;
		private TextBox tbCur;
		private TextBox tbMax;
		private TextBox tbLeft;
		private TextBox tbright;
		private TextBox tbassi;
		private TextBox tbwages;
		private TextBox tbsgender;
		private TextBox ybsimage;
		private TextBox tbunknown;
		private Button btchcancel;
		private Button btchadd;
		private Button btaddim;
		private Button btchngeOwn;
		private Button btOcancel;
		private Button btOadd;
		private Button btClearim;
		private Button btdelety;
		private ComboBox cbsimselect;
		private ComboBox cbOsimselect;
		private ListView lvEmployees;
		private ImageList ilist;
		private ToolTip toolTip1;
		private PictureBox pbox;
		private IContainer components;
		int[] edatas;
		int[] rdatas;

		public BnfoUI()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			if (Helper.WindowsRegistry.UseBigIcons)
			{
				lv.Font = new Font("Tahoma", 12F);
			}

			string ttip =
				"This info is from the sim\'s character\r\nfile so it can\'t be changed here";
			toolTip1.SetToolTip(tbLeft, ttip);
			toolTip1.SetToolTip(tbright, ttip);
			toolTip1.SetToolTip(ybsimage, ttip);
			toolTip1.SetToolTip(tbsgender, ttip);
			toolTip1.SetToolTip(tbwages, ttip);
			toolTip1.SetToolTip(tbassi, ttip);
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
			components = new Container();
			ComponentResourceManager resources =
				new ComponentResourceManager(typeof(BnfoUI));
			lv = new BnfoCustomerItemsUI();
			bnfoCustomerItemUI1 = new BnfoCustomerItemUI();
			label1 = new Label();
			lblot = new Label();
			toolBar1 = new ToolStrip();
			biMax = new ToolStripButton();
			biReward = new ToolStripButton();
			biWorkers = new ToolStripButton();
			panel1 = new Panel();
			lbcashf = new Label();
			gpexpen = new Panel();
			gpreven = new Panel();
			btClearim = new Button();
			tbMax = new TextBox();
			tbCur = new TextBox();
			label3 = new Label();
			label2 = new Label();
			panel2 = new Panel();
			btaddim = new Button();
			Panel3 = new Panel();
			btchcancel = new Button();
			btchadd = new Button();
			lbchgender = new Label();
			lbchage = new Label();
			tbchgender = new TextBox();
			tbchage = new TextBox();
			lbchoose = new Label();
			cbsimselect = new ComboBox();
			lbadvice = new Label();
			btdelety = new Button();
			pbox = new PictureBox();
			lbaward = new Label();
			tbunknown = new TextBox();
			lbpay = new Label();
			pbpay = new ExtProgressBar();
			tbassi = new TextBox();
			lbassi = new Label();
			tbwages = new TextBox();
			lbwages = new Label();
			tbsgender = new TextBox();
			lbsgender = new Label();
			ybsimage = new TextBox();
			lbsimage = new Label();
			lbLaball = new Label();
			tbright = new TextBox();
			lbright = new Label();
			tbLeft = new TextBox();
			lvEmployees = new ListView();
			ilist = new ImageList(components);
			toolTip1 = new ToolTip(components);
			btchngeOwn = new Button();
			Panel4 = new Panel();
			btOcancel = new Button();
			btOadd = new Button();
			lbOgender = new Label();
			lbOage = new Label();
			tbOgender = new TextBox();
			tbOchage = new TextBox();
			lbOchoos = new Label();
			cbOsimselect = new ComboBox();
			toolBar1.SuspendLayout();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			Panel3.SuspendLayout();
			Panel4.SuspendLayout();
			((ISupportInitialize)(pbox)).BeginInit();
			SuspendLayout();
			//
			// lv
			//
			lv.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Bottom
						) | AnchorStyles.Left
					)

			;
			lv.Font = new Font("Tahoma", 8.25F);
			lv.Items = null;
			lv.Location = new Point(8, 32);
			lv.Name = "lv";
			lv.Size = new Size(328, 229);
			lv.TabIndex = 1;
			//
			// bnfoCustomerItemUI1
			//
			bnfoCustomerItemUI1.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Bottom
						) | AnchorStyles.Left
					)

			;
			bnfoCustomerItemUI1.BackColor = Color.Transparent;
			bnfoCustomerItemUI1.BnfoCustomerItemsUI = lv;
			bnfoCustomerItemUI1.Font = new Font("Tahoma", 8.25F);
			bnfoCustomerItemUI1.Item = null;
			bnfoCustomerItemUI1.Location = new Point(344, 32);
			bnfoCustomerItemUI1.Name = "bnfoCustomerItemUI1";
			bnfoCustomerItemUI1.Size = new Size(408, 140);
			bnfoCustomerItemUI1.TabIndex = 2;
			//
			// label1
			//
			label1.AutoSize = true;
			label1.BackColor = Color.Transparent;
			label1.Font = new Font(
				"Tahoma",
				12F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				0
			);
			label1.ImeMode = ImeMode.NoControl;
			label1.Location = new Point(8, 8);
			label1.Name = "label1";
			label1.Size = new Size(41, 19);
			label1.TabIndex = 5;
			label1.Text = "Lot:";
			label1.TextAlign = ContentAlignment.BottomRight;
			//
			// lblot
			//
			lblot.AutoSize = true;
			lblot.BackColor = Color.Transparent;
			lblot.Font = new Font(
				"Tahoma",
				12F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			lblot.ImeMode = ImeMode.NoControl;
			lblot.Location = new Point(54, 8);
			lblot.Name = "lblot";
			lblot.Size = new Size(0, 19);
			lblot.TabIndex = 6;
			lblot.TextAlign = ContentAlignment.BottomLeft;
			//
			// toolBar1
			//
			toolBar1.GripStyle = ToolStripGripStyle.Hidden;
			toolBar1.Items.AddRange(
				new ToolStripItem[]
				{
					biMax,
					biReward,
					biWorkers,
				}
			);
			toolBar1.Location = new Point(0, 24);
			toolBar1.Name = "toolBar1";
			toolBar1.Size = new Size(760, 54);
			toolBar1.TabIndex = 7;
			toolBar1.Text = "toolBar1";
			//
			// biMax
			//
			biMax.Image = (
				(Image)(resources.GetObject("biMax.Image"))
			);
			biMax.ImageScaling =
				ToolStripItemImageScaling
				.None;
			biMax.Name = "biMax";
			biMax.Size = new Size(62, 51);
			biMax.Text = "Maximize";
			biMax.TextImageRelation =
				TextImageRelation
				.ImageAboveText;
			biMax.Click += new EventHandler(biMax_Activate);
			//
			// biReward
			//
			biReward.Image = (
				(Image)(resources.GetObject("biReward.Image"))
			);
			biReward.ImageScaling =
				ToolStripItemImageScaling
				.None;
			biReward.Name = "biReward";
			biReward.Size = new Size(82, 51);
			biReward.Text = "Reward again";
			biReward.TextImageRelation =
				TextImageRelation
				.ImageAboveText;
			biReward.Click += new EventHandler(biReward_Activate);
			//
			// biWorkers
			//
			biWorkers.Image = (
				(Image)(resources.GetObject("biWorkers.Image"))
			);
			biWorkers.ImageScaling =
				ToolStripItemImageScaling
				.None;
			biWorkers.ImageTransparentColor = Color.Magenta;
			biWorkers.Name = "biWorkers";
			biWorkers.Size = new Size(68, 51);
			biWorkers.Text = "Employees";
			biWorkers.TextImageRelation =
				TextImageRelation
				.ImageAboveText;
			biWorkers.ToolTipText = "Change to Employees or Customers";
			biWorkers.Click += new EventHandler(biWorkers_Click);
			//
			// panel1
			//
			panel1.BackColor = Color.Transparent;
			panel1.Controls.Add(lbcashf);
			panel1.Controls.Add(gpexpen);
			panel1.Controls.Add(gpreven);
			panel1.Controls.Add(btClearim);
			panel1.Controls.Add(tbMax);
			panel1.Controls.Add(tbCur);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(lv);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(bnfoCustomerItemUI1);
			panel1.Controls.Add(lblot);
			panel1.Dock = DockStyle.Fill;
			panel1.Font = new Font("Tahoma", 8.25F);
			panel1.Location = new Point(0, 78);
			panel1.Name = "panel1";
			panel1.Size = new Size(760, 320);
			panel1.TabIndex = 8;
			//
			// lbcashf
			//
			lbcashf.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			lbcashf.AutoSize = true;
			lbcashf.Font = new Font(
				"Tahoma",
				12F,
				FontStyle.Bold
			);
			lbcashf.Location = new Point(359, 182);
			lbcashf.Name = "lbcashf";
			lbcashf.Size = new Size(170, 19);
			lbcashf.TabIndex = 14;
			lbcashf.Text = "Last Cashflow  = $0";
			//
			// gpexpen
			//
			gpexpen.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			gpexpen.BackColor = Color.Transparent;
			gpexpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			gpexpen.Location = new Point(551, 212);
			gpexpen.Name = "gpexpen";
			gpexpen.Size = new Size(201, 105);
			gpexpen.TabIndex = 13;
			//
			// gpreven
			//
			gpreven.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			gpreven.BackColor = Color.Transparent;
			gpreven.Location = new Point(344, 212);
			gpreven.Name = "gpreven";
			gpreven.Size = new Size(201, 105);
			gpreven.TabIndex = 12;
			//
			// btClearim
			//
			btClearim.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			btClearim.Location = new Point(261, 270);
			btClearim.Name = "btClearim";
			btClearim.Size = new Size(75, 25);
			btClearim.TabIndex = 11;
			btClearim.Text = "Clean Up";
			toolTip1.SetToolTip(
				btClearim,
				"Remove Unknown\r\nSims from this list"
			);
			btClearim.UseVisualStyleBackColor = true;
			btClearim.Click += new EventHandler(btClearim_Click);
			//
			// tbMax
			//
			tbMax.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			tbMax.Location = new Point(120, 293);
			tbMax.Name = "tbMax";
			tbMax.Size = new Size(100, 21);
			tbMax.TabIndex = 10;
			tbMax.TextChanged += new EventHandler(tbMax_TextChanged);
			//
			// tbCur
			//
			tbCur.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			tbCur.Location = new Point(120, 269);
			tbCur.Name = "tbCur";
			tbCur.Size = new Size(100, 21);
			tbCur.TabIndex = 9;
			tbCur.TextChanged += new EventHandler(tbCur_TextChanged);
			//
			// label3
			//
			label3.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			label3.BackColor = Color.Transparent;
			label3.Font = new Font(
				"Tahoma",
				8.25F,
				FontStyle.Bold
			);
			label3.ImeMode = ImeMode.NoControl;
			label3.Location = new Point(8, 293);
			label3.Name = "label3";
			label3.Size = new Size(104, 23);
			label3.TabIndex = 8;
			label3.Text = "Rewarded Level:";
			label3.TextAlign = ContentAlignment.BottomRight;
			//
			// label2
			//
			label2.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			label2.BackColor = Color.Transparent;
			label2.Font = new Font(
				"Tahoma",
				8.25F,
				FontStyle.Bold
			);
			label2.ImeMode = ImeMode.NoControl;
			label2.Location = new Point(8, 269);
			label2.Name = "label2";
			label2.Size = new Size(104, 23);
			label2.TabIndex = 7;
			label2.Text = "Current Level:";
			label2.TextAlign = ContentAlignment.BottomRight;
			//
			// panel2
			//
			panel2.BackColor = Color.Transparent;
			panel2.Controls.Add(btchngeOwn);
			panel2.Controls.Add(btaddim);
			panel2.Controls.Add(Panel3);
			panel2.Controls.Add(Panel4);
			panel2.Controls.Add(lbadvice);
			panel2.Controls.Add(btdelety);
			panel2.Controls.Add(pbox);
			panel2.Controls.Add(lbaward);
			panel2.Controls.Add(tbunknown);
			panel2.Controls.Add(lbpay);
			panel2.Controls.Add(pbpay);
			panel2.Controls.Add(tbassi);
			panel2.Controls.Add(lbassi);
			panel2.Controls.Add(tbwages);
			panel2.Controls.Add(lbwages);
			panel2.Controls.Add(tbsgender);
			panel2.Controls.Add(lbsgender);
			panel2.Controls.Add(ybsimage);
			panel2.Controls.Add(lbsimage);
			panel2.Controls.Add(lbLaball);
			panel2.Controls.Add(tbright);
			panel2.Controls.Add(lbright);
			panel2.Controls.Add(tbLeft);
			panel2.Controls.Add(lvEmployees);
			panel2.Dock = DockStyle.Fill;
			panel2.Font = new Font("Tahoma", 8.25F);
			panel2.Location = new Point(0, 78);
			panel2.Name = "panel2";
			panel2.Size = new Size(760, 320);
			panel2.TabIndex = 9;
			panel2.Visible = false;
			//
			// btaddim
			//
			btaddim.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			btaddim.Location = new Point(710, 291);
			btaddim.Name = "btaddim";
			btaddim.Size = new Size(47, 23);
			btaddim.TabIndex = 23;
			btaddim.Text = "Add";
			toolTip1.SetToolTip(
				btaddim,
				"This just adds an employee to\r\nhere. You may need to open\r\nthe sim\'s SDSC file an"
					+ "d add the\r\nbusiness data and career."
			);
			btaddim.UseVisualStyleBackColor = true;
			btaddim.Click += new EventHandler(btaddim_Click);
			//
			// Panel3
			//
			Panel3.BackColor = Color.Transparent;
			Panel3.BorderStyle = BorderStyle.Fixed3D;
			Panel3.Controls.Add(btchcancel);
			Panel3.Controls.Add(btchadd);
			Panel3.Controls.Add(lbchgender);
			Panel3.Controls.Add(lbchage);
			Panel3.Controls.Add(tbchgender);
			Panel3.Controls.Add(tbchage);
			Panel3.Controls.Add(lbchoose);
			Panel3.Controls.Add(cbsimselect);
			Panel3.Font = new Font("Tahoma", 12F);
			Panel3.Location = new Point(357, 46);
			Panel3.Name = "Panel3";
			Panel3.Size = new Size(365, 215);
			Panel3.TabIndex = 22;
			Panel3.Visible = false;
			//
			// btchcancel
			//
			btchcancel.Location = new Point(168, 164);
			btchcancel.Name = "btchcancel";
			btchcancel.Size = new Size(84, 29);
			btchcancel.TabIndex = 13;
			btchcancel.Text = "Cancel";
			btchcancel.UseVisualStyleBackColor = true;
			btchcancel.Click += new EventHandler(btchcancel_Click);
			//
			// btchadd
			//
			btchadd.Location = new Point(269, 164);
			btchadd.Name = "btchadd";
			btchadd.Size = new Size(84, 29);
			btchadd.TabIndex = 12;
			btchadd.Text = "Apply";
			btchadd.UseVisualStyleBackColor = true;
			btchadd.Click += new EventHandler(btchadd_Click);
			//
			// lbchgender
			//
			lbchgender.AutoSize = true;
			lbchgender.Font = new Font(
				"Tahoma",
				12F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			lbchgender.Location = new Point(120, 114);
			lbchgender.Name = "lbchgender";
			lbchgender.Size = new Size(60, 19);
			lbchgender.TabIndex = 11;
			lbchgender.Text = "Gender";
			//
			// lbchage
			//
			lbchage.AutoSize = true;
			lbchage.Font = new Font(
				"Tahoma",
				12F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			lbchage.Location = new Point(143, 80);
			lbchage.Name = "lbchage";
			lbchage.Size = new Size(37, 19);
			lbchage.TabIndex = 10;
			lbchage.Text = "Age";
			//
			// tbchgender
			//
			tbchgender.Location = new Point(186, 110);
			tbchgender.Name = "tbchgender";
			tbchgender.Size = new Size(167, 27);
			tbchgender.TabIndex = 3;
			//
			// tbchage
			//
			tbchage.Location = new Point(186, 76);
			tbchage.Name = "tbchage";
			tbchage.Size = new Size(167, 27);
			tbchage.TabIndex = 2;
			//
			// lbchoose
			//
			lbchoose.AutoSize = true;
			lbchoose.Location = new Point(22, 19);
			lbchoose.Name = "lbchoose";
			lbchoose.Size = new Size(106, 19);
			lbchoose.TabIndex = 1;
			lbchoose.Text = "Choose a Sim";
			//
			// cbsimselect
			//
			cbsimselect.FormattingEnabled = true;
			cbsimselect.Location = new Point(134, 15);
			cbsimselect.Name = "cbsimselect";
			cbsimselect.Size = new Size(219, 27);
			cbsimselect.TabIndex = 0;
			cbsimselect.SelectedIndexChanged += new EventHandler(
				cbsimselect_SelectedIndexChanged
			);

			//
			// Panel4
			//
			Panel4.BackColor = Color.Transparent;
			Panel4.BorderStyle = BorderStyle.Fixed3D;
			Panel4.Controls.Add(btOcancel);
			Panel4.Controls.Add(btOadd);
			Panel4.Controls.Add(lbOgender);
			Panel4.Controls.Add(lbOage);
			Panel4.Controls.Add(tbOgender);
			Panel4.Controls.Add(tbOchage);
			Panel4.Controls.Add(lbOchoos);
			Panel4.Controls.Add(cbOsimselect);
			Panel4.Font = new Font("Tahoma", 12F);
			Panel4.Location = new Point(357, 46);
			Panel4.Name = "Panel4";
			Panel4.Size = new Size(365, 215);
			Panel4.TabIndex = 23;
			Panel4.Visible = false;
			//
			// btOcancel
			//
			btOcancel.Location = new Point(168, 164);
			btOcancel.Name = "btOcancel";
			btOcancel.Size = new Size(84, 29);
			btOcancel.TabIndex = 13;
			btOcancel.Text = "Cancel";
			btOcancel.UseVisualStyleBackColor = true;
			btOcancel.Click += new EventHandler(btOcancel_Click);
			//
			// btOadd
			//
			btOadd.Location = new Point(269, 164);
			btOadd.Name = "btOadd";
			btOadd.Size = new Size(84, 29);
			btOadd.TabIndex = 12;
			btOadd.Text = "Apply";
			btOadd.UseVisualStyleBackColor = true;
			btOadd.Click += new EventHandler(btOadd_Click);
			//
			// lbOgender
			//
			lbOgender.AutoSize = true;
			lbOgender.Font = new Font(
				"Tahoma",
				12F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			lbOgender.Location = new Point(120, 114);
			lbOgender.Name = "lbOgender";
			lbOgender.Size = new Size(60, 19);
			lbOgender.TabIndex = 11;
			lbOgender.Text = "Gender";
			//
			// lbOage
			//
			lbOage.AutoSize = true;
			lbOage.Font = new Font(
				"Tahoma",
				12F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			lbOage.Location = new Point(143, 80);
			lbOage.Name = "lbOage";
			lbOage.Size = new Size(37, 19);
			lbOage.TabIndex = 10;
			lbOage.Text = "Age";
			//
			// tbOgender
			//
			tbOgender.Location = new Point(186, 110);
			tbOgender.Name = "tbOgender";
			tbOgender.Size = new Size(167, 27);
			tbOgender.TabIndex = 3;
			//
			// tbOchage
			//
			tbOchage.Location = new Point(186, 76);
			tbOchage.Name = "tbOchage";
			tbOchage.Size = new Size(167, 27);
			tbOchage.TabIndex = 2;
			//
			// lbOchoos
			//
			lbOchoos.AutoSize = true;
			lbOchoos.Location = new Point(22, 19);
			lbOchoos.Name = "lbOchoos";
			lbOchoos.Size = new Size(106, 19);
			lbOchoos.TabIndex = 1;
			lbOchoos.Text = "Choose a Sim";
			//
			// cbOsimselect
			//
			cbOsimselect.FormattingEnabled = true;
			cbOsimselect.Location = new Point(134, 15);
			cbOsimselect.Name = "cbOsimselect";
			cbOsimselect.Size = new Size(219, 27);
			cbOsimselect.TabIndex = 0;
			cbOsimselect.SelectedIndexChanged += new EventHandler(
				cbOsimselect_SelectedIndexChanged
			);

			//
			// lbadvice
			//
			lbadvice.AutoSize = true;
			lbadvice.Font = new Font(
				"Tahoma",
				12F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				0
			);
			lbadvice.ForeColor = Color.DarkRed;
			lbadvice.Location = new Point(466, 4);
			lbadvice.Name = "lbadvice";
			lbadvice.Size = new Size(77, 19);
			lbadvice.TabIndex = 21;
			lbadvice.Text = "Warning";
			lbadvice.Visible = false;
			//
			// btdelety
			//
			btdelety.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			btdelety.Location = new Point(625, 291);
			btdelety.Name = "btdelety";
			btdelety.Size = new Size(75, 23);
			btdelety.TabIndex = 20;
			btdelety.Text = "Remove";
			toolTip1.SetToolTip(
				btdelety,
				"This just removes the employee\r\nfrom here. You may need to open\r\nthe sim\'s SDSC f"
					+ "ile and clear any\r\nbusiness data and career."
			);
			btdelety.UseVisualStyleBackColor = true;
			btdelety.Click += new EventHandler(btdelety_Click);
			//
			// pbox
			//
			pbox.Location = new Point(646, 32);
			pbox.Name = "pbox";
			pbox.Size = new Size(40, 41);
			pbox.TabIndex = 19;
			pbox.TabStop = false;
			//
			// lbaward
			//
			lbaward.AutoSize = true;
			lbaward.Font = new Font(
				"Tahoma",
				12F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			lbaward.Location = new Point(388, 156);
			lbaward.Name = "lbaward";
			lbaward.Size = new Size(65, 19);
			lbaward.TabIndex = 18;
			lbaward.Text = "Fair Pay";
			//
			// tbunknown
			//
			tbunknown.BackColor = SystemColors.Window;
			tbunknown.Font = new Font("Tahoma", 12F);
			tbunknown.Location = new Point(459, 152);
			tbunknown.Name = "tbunknown";
			tbunknown.Size = new Size(167, 27);
			tbunknown.TabIndex = 17;
			toolTip1.SetToolTip(
				tbunknown,
				resources.GetString("tbunknown.ToolTip")
			);
			tbunknown.TextChanged += new EventHandler(
				tbunknown_TextChanged
			);
			//
			// lbpay
			//
			lbpay.Font = new Font(
				"Tahoma",
				12F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			lbpay.Location = new Point(374, 283);
			lbpay.Name = "lbpay";
			lbpay.Size = new Size(227, 19);
			lbpay.TabIndex = 16;
			lbpay.Text = "Fairly Paid (100%)";
			lbpay.TextAlign = ContentAlignment.TopCenter;
			//
			// pbpay
			//
			pbpay.BackColor = Color.Transparent;
			pbpay.Font = new Font(
				"Tahoma",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			pbpay.ImeMode = ImeMode.Disable;
			pbpay.Location = new Point(363, 245);
			pbpay.Maximum = 7;
			pbpay.Name = "pbpay";
			pbpay.Padding = new Padding(0, 0, 0, 2);
			pbpay.SelectedColor = Color.Gold;
			pbpay.Size = new Size(261, 35);
			pbpay.TabIndex = 15;
			pbpay.TokenCount = 7;
			pbpay.UnselectedColor = Color.Black;
			pbpay.Value = 4;
			//
			// tbassi
			//
			tbassi.BackColor = SystemColors.Window;
			tbassi.Font = new Font(
				"Tahoma",
				12F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			tbassi.Location = new Point(459, 212);
			tbassi.Name = "tbassi";
			tbassi.ReadOnly = true;
			tbassi.Size = new Size(167, 27);
			tbassi.TabIndex = 14;
			//
			// lbassi
			//
			lbassi.AutoSize = true;
			lbassi.Font = new Font(
				"Tahoma",
				12F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			lbassi.Location = new Point(361, 216);
			lbassi.Name = "lbassi";
			lbassi.Size = new Size(92, 19);
			lbassi.TabIndex = 13;
			lbassi.Text = "Assignment";
			//
			// tbwages
			//
			tbwages.BackColor = SystemColors.Window;
			tbwages.Font = new Font(
				"Tahoma",
				12F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			tbwages.Location = new Point(459, 182);
			tbwages.Name = "tbwages";
			tbwages.ReadOnly = true;
			tbwages.Size = new Size(167, 27);
			tbwages.TabIndex = 12;
			//
			// lbwages
			//
			lbwages.AutoSize = true;
			lbwages.Font = new Font(
				"Tahoma",
				12F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			lbwages.Location = new Point(353, 186);
			lbwages.Name = "lbwages";
			lbwages.Size = new Size(100, 19);
			lbwages.TabIndex = 11;
			lbwages.Text = "Hourly Wage";
			//
			// tbsgender
			//
			tbsgender.BackColor = SystemColors.Window;
			tbsgender.Font = new Font(
				"Tahoma",
				12F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			tbsgender.Location = new Point(459, 122);
			tbsgender.Name = "tbsgender";
			tbsgender.ReadOnly = true;
			tbsgender.Size = new Size(167, 27);
			tbsgender.TabIndex = 10;
			//
			// lbsgender
			//
			lbsgender.AutoSize = true;
			lbsgender.Font = new Font(
				"Tahoma",
				12F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			lbsgender.Location = new Point(393, 126);
			lbsgender.Name = "lbsgender";
			lbsgender.Size = new Size(60, 19);
			lbsgender.TabIndex = 9;
			lbsgender.Text = "Gender";
			//
			// ybsimage
			//
			ybsimage.BackColor = SystemColors.Window;
			ybsimage.Font = new Font(
				"Tahoma",
				12F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			ybsimage.Location = new Point(459, 92);
			ybsimage.Name = "ybsimage";
			ybsimage.ReadOnly = true;
			ybsimage.Size = new Size(167, 27);
			ybsimage.TabIndex = 8;
			//
			// lbsimage
			//
			lbsimage.AutoSize = true;
			lbsimage.Font = new Font(
				"Tahoma",
				12F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			lbsimage.Location = new Point(416, 96);
			lbsimage.Name = "lbsimage";
			lbsimage.Size = new Size(37, 19);
			lbsimage.TabIndex = 7;
			lbsimage.Text = "Age";
			//
			// lbLaball
			//
			lbLaball.AutoSize = true;
			lbLaball.Font = new Font(
				"Tahoma",
				12F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			lbLaball.Location = new Point(28, 8);
			lbLaball.Name = "lbLaball";
			lbLaball.Size = new Size(85, 19);
			lbLaball.TabIndex = 6;
			lbLaball.Text = "Employees";
			//
			// tbright
			//
			tbright.BackColor = SystemColors.Window;
			tbright.Font = new Font(
				"Tahoma",
				12F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			tbright.Location = new Point(459, 62);
			tbright.Name = "tbright";
			tbright.ReadOnly = true;
			tbright.Size = new Size(167, 27);
			tbright.TabIndex = 5;
			//
			// lbright
			//
			lbright.AutoSize = true;
			lbright.Font = new Font(
				"Tahoma",
				12F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			lbright.Location = new Point(401, 66);
			lbright.Name = "lbright";
			lbright.Size = new Size(52, 19);
			lbright.TabIndex = 4;
			lbright.Text = "Status";
			//
			// tbLeft
			//
			tbLeft.BackColor = SystemColors.Window;
			tbLeft.Font = new Font(
				"Tahoma",
				12F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			tbLeft.Location = new Point(365, 32);
			tbLeft.Name = "tbLeft";
			tbLeft.ReadOnly = true;
			tbLeft.Size = new Size(261, 27);
			tbLeft.TabIndex = 3;
			tbLeft.TextAlign = HorizontalAlignment.Center;
			//
			// lvEmployees
			//
			lvEmployees.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Bottom
						) | AnchorStyles.Left
					)

			;
			lvEmployees.BorderStyle = BorderStyle.None;
			lvEmployees.FullRowSelect = true;
			lvEmployees.HideSelection = false;
			lvEmployees.LargeImageList = ilist;
			lvEmployees.Location = new Point(8, 32);
			lvEmployees.MultiSelect = false;
			lvEmployees.Name = "lvEmployees";
			lvEmployees.Size = new Size(330, 270);
			lvEmployees.TabIndex = 1;
			lvEmployees.UseCompatibleStateImageBehavior = false;
			lvEmployees.SelectedIndexChanged += new EventHandler(
				lvEmployees_SelectedIndexChanged
			);
			lvEmployees.DoubleClick += new EventHandler(
				lvEmployees_DoubleClick
			);
			//
			// ilist
			//
			ilist.ColorDepth = ColorDepth.Depth32Bit;
			ilist.ImageSize = new Size(96, 96);
			ilist.TransparentColor = Color.Transparent;
			//
			// toolTip1
			//
			toolTip1.AutoPopDelay = 8000;
			toolTip1.InitialDelay = 200;
			toolTip1.IsBalloon = true;
			toolTip1.ReshowDelay = 100;
			toolTip1.ToolTipIcon = ToolTipIcon.Info;
			toolTip1.ToolTipTitle = "Note";
			//
			// btchngeOwn
			//
			btchngeOwn.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			btchngeOwn.Location = new Point(625, 291);
			btchngeOwn.Name = "btchngeOwn";
			btchngeOwn.Size = new Size(75, 23);
			btchngeOwn.TabIndex = 24;
			btchngeOwn.Text = "Change";
			toolTip1.SetToolTip(
				btchngeOwn,
				"Owner information is not held in this BNFO, this changes\r\nthe owner value in the Lot file (LTXT)"
			);
			btchngeOwn.UseVisualStyleBackColor = true;
			btchngeOwn.Visible = false;
			btchngeOwn.Click += new EventHandler(btchngeOwn_Click);
			//
			// BnfoUI
			//
			BackgroundImageLocation = new Point(760, 54);
			BackgroundImageZoomToFit = true;
			Controls.Add(panel1);
			Controls.Add(panel2);
			Controls.Add(toolBar1);
			Font = new Font("Microsoft Sans Serif", 8.25F);
			HeaderText = "Business Info";
			Name = "BnfoUI";
			Size = new Size(760, 398);
			Controls.SetChildIndex(toolBar1, 0);
			Controls.SetChildIndex(panel2, 0);
			Controls.SetChildIndex(panel1, 0);
			toolBar1.ResumeLayout(false);
			toolBar1.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			Panel3.ResumeLayout(false);
			Panel3.PerformLayout();
			Panel4.ResumeLayout(false);
			Panel4.PerformLayout();
			((ISupportInitialize)(pbox)).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion

		public Bnfo Bnfo => (Bnfo)Wrapper;

		bool intern;
		bool employees = false;
		int homeb = 1;
		ushort owner = 0xffff;
		ushort famly = 0;

		protected override void RefreshGUI()
		{
			if (intern)
			{
				return;
			}

			System.Resources.ResourceManager resources =
				new System.Resources.ResourceManager(typeof(BnfoUI));
			HeaderText = resources.GetString("$this.HeaderText") == null ? "Business Info" : resources.GetString("$this.HeaderText");

			intern = true;
			// Clear Panel2 but it doesn't seem to be needed
			/*
			this.panel2.Visible = false;
			this.panel1.Visible = true;
			this.biWorkers.Text = "Employees";
			employees = false;
			panel2_clear();
			*/
			if (Bnfo != null)
			{
				lv.Items = Bnfo.CustomerItems;
				biMax.Enabled = biReward.Enabled = biWorkers.Enabled = true;
				lbcashf.Visible = gpreven.Visible = gpexpen.Visible = true;
				owner = 0xffff;
				string ltname = Localization.GetString("Unknown");

				Interfaces.Files.IPackedFileDescriptor pfd =
					Bnfo.Package.FindFile(
						0x0BF999E7,
						0,
						0xFFFFFFFF,
						Bnfo.FileDescriptor.Instance
					);
				if (pfd != null)
				{
					Ltxt ltx = new Ltxt();
					ltx.ProcessData(pfd, Bnfo.Package);
					owner = (ushort)ltx.OwnerInstance;
					ltname = ltx.LotName;
					homeb = ltx.Type == Ltxt.LotType.Residential ? 0 : 1;

					lblot.Text = ltname + " (" + ltx.Type.ToString() + " Lot)";
				}
				else
				{
					Interfaces.Providers.ILotItem ili =
						FileTableBase.ProviderRegistry.LotProvider.FindLot(
							Bnfo.FileDescriptor.Instance
						);
					if (ili != null)
					{
						ltname = ili.LotName;
						owner = (ushort)ili.Owner;
						lblot.Text = ltname;
					}
					homeb = 1;
				}

				tbCur.Text = Bnfo.CurrentBusinessState.ToString();
				tbMax.Text = Bnfo.MaxSeenBusinessState.ToString();

				HeaderText += ": " + ltname;
				lbLaball.Text = ltname + " Employees";
				GetEmployees();
				RefreshGraphs();
				btClearim.Visible = !AllValid();
			}
			else
			{
				lv.Items = null;
				lblot.Text = "";
				biMax.Enabled = biReward.Enabled = biWorkers.Enabled = false;
				btClearim.Visible =
					lbcashf.Visible =
					gpreven.Visible =
					gpexpen.Visible =
						false;
			}

			tbMax.Enabled = biMax.Enabled;
			tbCur.Enabled = biMax.Enabled;
			intern = false;
		}

		private void GetEmployees()
		{
			ExtSDesc sdsc;

			sdsc =
				FileTableBase.ProviderRegistry.SimDescriptionProvider.SimInstance[owner]
				as ExtSDesc;
			if (sdsc != null)
			{
				AddImage(sdsc);
				ListViewItem lvi = new ListViewItem
				{
					Text = sdsc.SimName + " : Owner",
					ImageIndex = ilist.Images.Count - 1,
					Tag = sdsc
				};
				lvi.SubItems.Add("3"); // payrate
				lvi.SubItems.Add("-1"); // sim index
				lvi.SubItems.Add("0"); // Catched Fair Pay
				lvEmployees.Items.Add(lvi);
				famly = sdsc.FamilyInstance;
			}
			else
			{
				ilist.Images.Add(new Bitmap(GetImage.NoOne));
				ListViewItem lvi = new ListViewItem
				{
					Text = Localization.GetString("Unknown") + " : Owner",
					ImageIndex = ilist.Images.Count - 1,
					Tag = null
				};
				lvi.SubItems.Add("3"); // payrate
				lvi.SubItems.Add("-1"); // sim index
				lvi.SubItems.Add("0"); // Catched Fair Pay
				lvEmployees.Items.Add(lvi);
				famly = 0;
			}

			for (int i = 0; i < Bnfo.EmployeeCount; i++)
			{
				sdsc =
					FileTableBase.ProviderRegistry.SimDescriptionProvider.SimInstance[
						Bnfo.Employees[i]
					] as ExtSDesc;
				if (sdsc != null)
				{
					AddImage(sdsc);
					ListViewItem lvi = new ListViewItem
					{
						Text = sdsc.SimName + " " + sdsc.SimFamilyName,
						ImageIndex = ilist.Images.Count - 1,
						Tag = sdsc
					};
					lvi.SubItems.Add(Convert.ToString(Bnfo.PayRate[i]));
					lvi.SubItems.Add(Convert.ToString(i));
					lvi.SubItems.Add(Convert.ToString(Bnfo.A[i]));
					lvEmployees.Items.Add(lvi);
				}
				else
				{
					ilist.Images.Add(new Bitmap(GetImage.NoOne));
					ListViewItem lvi = new ListViewItem
					{
						Text = Localization.GetString("Unknown"),
						ImageIndex = ilist.Images.Count - 1,
						Tag = null
					};
					lvi.SubItems.Add(Convert.ToString(Bnfo.PayRate[i]));
					lvi.SubItems.Add(Convert.ToString(i));
					lvi.SubItems.Add(Convert.ToString(Bnfo.A[i]));
					lvEmployees.Items.Add(lvi);
				}
			}
			btdelety.Visible = btchngeOwn.Visible = false;
		}

		private void RefreshGraphs()
		{
			int n = 0;
			int historycount = Bnfo.HistoryCount;
			/*
			 * somehow I have to gleen if home business or not - homeb = 0 for home business else = 1
			*/
			if (historycount > homeb)
			{
				int cflo =
					(Bnfo.Revenue[historycount - 1])
					- (Bnfo.Expences[historycount - 1]);
				Array.Resize(ref rdatas, historycount - homeb);
				Array.Resize(ref edatas, historycount - homeb);
				// set both graphs to same max value so a direct comparison between the bar heights is possible
				double mMax = 0;

				for (int i = homeb; i < historycount; i++)
				{
					/*
					 * expences can be negative
					 * negative values get cut off to zero at the graph as it can't display them
					 * therefore I add (subtract because they are negative) to revenue
					*/
					edatas[n] = Bnfo.Expences[i];
					rdatas[n] = Bnfo.Revenue[i];
					if (Bnfo.Expences[i] < 0)
					{
						rdatas[n] -= Bnfo.Expences[i];
					}

					if (edatas[n] > mMax)
					{
						mMax = edatas[n];
					}

					if (rdatas[n] > mMax)
					{
						mMax = rdatas[n];
					}

					n++;
				}
				lbcashf.Text = "Current Cashflow = " + cflo.ToString("c");
			}
			else
			{
				edatas = new int[] { 0, 0 };
				rdatas = new int[] { 0, 0 };
				lbcashf.Text = "Cashflow = $0";
			}
		}

		private void AddImage(ExtSDesc sdesc)
		{
			Image img = sdesc.HasImage
				? Ambertation.Drawing.GraphicRoutines.KnockoutImage(
					sdesc.Image,
					new Point(0, 0),
					Color.Magenta
				)
				: GetImage.NoOne;

			img = Ambertation.Windows.Forms.Graph.ImagePanel.CreateThumbnail(
				img,
				ilist.ImageSize,
				12,
				Color.FromArgb(90, Color.Black),
				SimPoolControl.GetImagePanelColor(sdesc),
				Color.White,
				Color.FromArgb(80, Color.White),
				true,
				4,
				0
			);
			ilist.Images.Add(img);
		}

		public override void OnCommit()
		{
			lbadvice.Visible = false;
			Bnfo.SynchronizeUserData(true, false);
		}

		private void biMax_Activate(object sender, EventArgs e)
		{
			if (lv.Items == null)
			{
				return;
			}

			foreach (BnfoCustomerItem item in lv.Items)
			{
				item.LoyaltyScore = 1000;
			}

			lv.Refresh();
		}

		private void biReward_Activate(object sender, EventArgs e)
		{
			if (Bnfo == null)
			{
				return;
			}

			Bnfo.CurrentBusinessState = 0;
			Bnfo.MaxSeenBusinessState = 0;
			panel2_clear();
			RefreshGUI();
		}

		private void tbCur_TextChanged(object sender, EventArgs e)
		{
			if (intern)
			{
				return;
			}

			if (Bnfo == null)
			{
				return;
			}

			Bnfo.CurrentBusinessState = Helper.StringToUInt32(
				tbCur.Text,
				Bnfo.CurrentBusinessState,
				10
			);
		}

		private void tbMax_TextChanged(object sender, EventArgs e)
		{
			if (intern)
			{
				return;
			}

			if (Bnfo == null)
			{
				return;
			}

			Bnfo.MaxSeenBusinessState = Helper.StringToUInt32(
				tbMax.Text,
				Bnfo.MaxSeenBusinessState,
				10
			);
		}

		private void biWorkers_Click(object sender, EventArgs e)
		{
			if (employees)
			{
				panel2.Visible = false;
				panel1.Visible = true;
				biWorkers.Text = "Employees";
				biMax.Enabled = biReward.Enabled = (Bnfo != null);
				CanCommit = true;
				employees = false;
			}
			else
			{
				panel2.Visible = true;
				panel1.Visible = false;
				biWorkers.Text = "Customers";
				biMax.Enabled = biReward.Enabled = false;
				CanCommit = false;
				employees = true;
			}
		}

		private void lvEmployees_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lvEmployees.SelectedItems.Count < 1)
			{
				return;
			}

			intern = true;
			int payr = 3;
			try
			{
				payr = Convert.ToInt32(lvEmployees.SelectedItems[0].SubItems[1].Text);
			}
			catch { }
			if (payr < 0)
			{
				payr = 0;
			}
			else if (payr > 6)
			{
				payr = 6;
			}

			PayBar(payr);
			try
			{
				tbunknown.Text = Convert
					.ToUInt32(lvEmployees.SelectedItems[0].SubItems[3].Text)
					.ToString("C0");
			}
			catch { }
			if (lvEmployees.SelectedItems[0].Tag != null)
			{
				ExtSDesc sdsc =
					lvEmployees.SelectedItems[0].Tag
					as ExtSDesc;
				tbLeft.Text = sdsc.SimName + " " + sdsc.SimFamilyName;
				ybsimage.Text = Enum.GetName(
					typeof(MetaData.LifeSections),
					(ushort)sdsc.CharacterDescription.LifeSection
				);
				tbsgender.Text = sdsc.CharacterDescription.Gender == MetaData.Gender.Female ? "Female" : "Male";

				if (lvEmployees.SelectedItems[0].Text.Contains(" : Owner"))
				{
					tbright.Text = "Business Owner";
					btdelety.Visible = false;
					pbpay.Visible = pbox.Visible = lbpay.Visible = false;
					btchngeOwn.Visible = true;
				}
				else
				{
					btchngeOwn.Visible = false;
					pbpay.Visible = pbox.Visible = lbpay.Visible = true;
					btdelety.Visible = true;
					tbright.Text = sdsc.CharacterDescription.GhostFlag.IsGhost
						? sdsc.SimName + " has Died"
						: sdsc.FamilyInstance == famly
							? "Family Member"
							: sdsc.CharacterDescription.CareerLevel == 2
																		&& sdsc.CharacterDescription.Career
																			== MetaData.Careers.OwnedBuss
													? "Manager"
													: "Employee";
				}

				tbwages.Text = sdsc.Business.Salary.ToString("C0");
				tbassi.Text = Localization.GetString(
					"SimPe.PackedFiles.Wrapper.JobAssignment."
						+ Enum.GetName(
							typeof(JobAssignment),
							(ushort)sdsc.Business.Assignment
						)
				);
			}
			else
			{
				tbLeft.Text = "Sim not Found!";
				ybsimage.Text = Localization.GetString("Unknown");
				tbsgender.Text = Localization.GetString("Unknown");
				if (lvEmployees.SelectedItems[0].Text.Contains(" : Owner"))
				{
					tbright.Text = "Business Owner";
					btdelety.Visible = false;
					pbpay.Visible = pbox.Visible = lbpay.Visible = false;
					btchngeOwn.Visible = true;
				}
				else
				{
					btchngeOwn.Visible = false;
					tbright.Text = "Employee";
					btdelety.Visible = true;
					pbpay.Visible = pbox.Visible = lbpay.Visible = true;
				}
				tbwages.Text = Localization.GetString("Unknown");
				tbassi.Text = Localization.GetString("Unknown");
			}
			intern = false;
		}

		private void lvEmployees_DoubleClick(object sender, EventArgs e)
		{
			if (lvEmployees.SelectedItems.Count < 1)
			{
				return;
			}

			if (lvEmployees.SelectedItems[0].Tag == null)
			{
				return;
			}

			if (!(lvEmployees.SelectedItems[0].Tag is ExtSDesc sdsc))
			{
				return;
			}

			Interfaces.Files.IPackedFileDescriptor pfd;
			try
			{
				pfd = sdsc.Package == Bnfo.Package
					? sdsc.Package.NewDescriptor(
						0xAACE2EFB,
						sdsc.FileDescriptor.SubType,
						sdsc.FileDescriptor.Group,
						sdsc.FileDescriptor.Instance
					)
					: fixlowercase(sdsc.Package.FileName)
						.NewDescriptor(
							0xAACE2EFB,
							sdsc.FileDescriptor.SubType,
							sdsc.FileDescriptor.Group,
							sdsc.FileDescriptor.Instance
						);

				pfd = sdsc.Package.FindFile(pfd);
				RemoteControl.OpenPackedFile(pfd, sdsc.Package);
			}
			catch { }
		}

		private void PayBar(int PayRate)
		{
			pbpay.Value = PayRate + 1;
			if (PayRate == 0)
			{
				pbpay.SelectedColor = Color.DarkRed;
				lbpay.Text = "Ridiculously Underpaid (25%)";
			}
			if (PayRate == 1)
			{
				pbpay.SelectedColor = Color.Red;
				lbpay.Text = "Very Underpaid (50%)";
			}
			if (PayRate == 2)
			{
				pbpay.SelectedColor = Color.OrangeRed;
				lbpay.Text = "Underpaid (75%)";
			}
			if (PayRate == 3)
			{
				pbpay.SelectedColor = Color.Gold;
				lbpay.Text = "Fairly Paid (100%)";
			}
			if (PayRate == 4)
			{
				pbpay.SelectedColor = Color.YellowGreen;
				lbpay.Text = "Overpaid (125%)";
			}
			if (PayRate == 5)
			{
				pbpay.SelectedColor = Color.LimeGreen;
				lbpay.Text = "Very Overpaid (150%)";
			}
			if (PayRate == 6)
			{
				pbpay.SelectedColor = Color.Green;
				lbpay.Text = "Ridiculously Overpaid (175%)";
			}
			SetSmilyIcon();
		}

		private void pbpay_ChangedValue(object sender, EventArgs e)
		{
			if (intern)
			{
				return;
			}

			if (pbpay.Value < 1)
			{
				pbpay.Value = 1;
			}
			else if (pbpay.Value > 7)
			{
				pbpay.Value = 7;
			}

			PayBar(pbpay.Value - 1);
			if (lvEmployees.SelectedItems.Count < 1)
			{
				return;
			}

			try
			{
				int indects = Convert.ToInt32(
					lvEmployees.SelectedItems[0].SubItems[2].Text
				);
				if (indects > -1)
				{
					Bnfo.PayRate[indects] = pbpay.Value - 1;
					lvEmployees.SelectedItems[0].SubItems[1].Text = Convert.ToString(
						pbpay.Value - 1
					);
					CanCommit = true;
				}
			}
			catch { }
		}

		private void tbunknown_TextChanged(object sender, EventArgs e)
		{
			if (intern)
			{
				return;
			}

			if (lvEmployees.SelectedItems.Count < 1)
			{
				return;
			}

			try
			{
				int indects = Convert.ToInt32(
					lvEmployees.SelectedItems[0].SubItems[2].Text
				);
				if (indects > -1)
				{
					string fp = tbunknown.Text;
					if (fp.StartsWith("$"))
					{
						fp = fp.Substring(1);
					}

					Bnfo.A[indects] = Convert.ToUInt32(fp);
					lvEmployees.SelectedItems[0].SubItems[3].Text = Convert.ToString(
						Bnfo.A[indects]
					);
					CanCommit = true;
				}
			}
			catch { }
		}

		private void SetSmilyIcon()
		{
			uint inst = 0xABBA2585;
			if (pbpay.Value == 1)
			{
				inst = 0xABBA2595;
			}

			if (pbpay.Value == 2)
			{
				inst = 0xABBA2591;
			}

			if (pbpay.Value == 3)
			{
				inst = 0xABBA2588;
			}

			if (pbpay.Value == 4)
			{
				inst = 0xABBA2585;
			}

			if (pbpay.Value == 5)
			{
				inst = 0xABBA2582;
			}

			if (pbpay.Value == 6)
			{
				inst = 0xABBA2578;
			}

			if (pbpay.Value == 7)
			{
				inst = 0xABBA2575;
			}

			Packages.File pkg = Packages.File.LoadFromFile(
				System.IO.Path.Combine(
					PathProvider.Global.Latest.InstallFolder,
					"TSData\\Res\\UI\\ui.package"
				)
			);
			if (pkg != null)
			{
				Interfaces.Files.IPackedFileDescriptor pfd = pkg.FindFile(
					0x856DDBAC,
					0,
					0x499DB772,
					inst
				);
				if (pfd != null)
				{
					Picture pic =
						new Picture();
					pic.ProcessData(pfd, pkg);
					pbox.Image = pic.Image;
				}
				else
				{
					pbox.Image = null;
				}
			}
			else
			{
				pbox.Image = null;
			}
		}

		private void btClearim_Click(object sender, EventArgs e)
		{
			Collections.BnfoCustomerItems bnff =
				new Collections.BnfoCustomerItems(Bnfo);

			foreach (BnfoCustomerItem item in Bnfo.CustomerItems)
			{
				if (item.SimDescription != null)
				{
					bnff.Add(item);
				}
			}
			Bnfo.CustomerItems.Clear();
			foreach (BnfoCustomerItem item in bnff)
			{
				Bnfo.CustomerItems.Add(item);
			}
			lv.Refresh();
			btClearim.Visible = false;
		}

		private void btdelety_Click(object sender, EventArgs e)
		{
			if (lvEmployees.SelectedItems.Count < 1)
			{
				return;
			}

			int indects = Convert.ToInt32(
				lvEmployees.SelectedItems[0].SubItems[2].Text
			);
			if (indects < 0)
			{
				return;
			}

			if (lvEmployees.SelectedItems[0].Tag != null)
			{
				if (lvEmployees.SelectedItems[0].Tag is ExtSDesc sdsc)
				{
					if (Bnfo.Package == sdsc.Package)
					{
						try
						{
							sdsc.CharacterDescription.Career = MetaData
								.Careers
								.Unemployed;
							sdsc.CharacterDescription.CareerLevel = 0;
							sdsc.Business.Assignment = JobAssignment.Nothing;
							sdsc.Business.LotID = 0;
							sdsc.Business.Salary = 0;
							sdsc.Business.Flags = 0;
							sdsc.SynchronizeUserData();
							lbadvice.Text =
								sdsc.SimName
								+ "'s SDSC was changed, be sure to Commit now";
						}
						catch
						{
							lbadvice.Text =
								"You will need to find and make changes to "
								+ sdsc.SimName
								+ "'s SDSC file";
						}
					}
					else
					{
						lbadvice.Text =
							"You will need to find and make changes to "
							+ sdsc.SimName
							+ "'s SDSC file";
					}

					lbadvice.Visible = true;
				}
			}

			if (Bnfo.EmployeeCount < 2)
			{
				Bnfo.EmployeeCount = 0;
			}
			else
			{
				try
				{
					ushort[] empls = new ushort[Bnfo.EmployeeCount - 1];
					int[] pr = new int[Bnfo.EmployeeCount - 1];
					uint[] a = new uint[Bnfo.EmployeeCount - 1];
					int j = 0;
					for (int i = 0; i < Bnfo.EmployeeCount; i++)
					{
						if (i != indects)
						{
							empls[j] = Bnfo.Employees[i];
							pr[j] = Bnfo.PayRate[i];
							a[j] = Bnfo.A[i];
							j++;
						}
					}

					Bnfo.EmployeeCount--;

					for (int i = 0; i < Bnfo.EmployeeCount; i++)
					{
						Bnfo.Employees[i] = empls[i];
						Bnfo.PayRate[i] = pr[i];
						Bnfo.A[i] = a[i];
					}
				}
				catch { }
			}
			panel2_clear();
			GetEmployees();
		}

		private void panel2_clear()
		{
			CanCommit = true;
			PayBar(3);
			tbassi.Text =
				tbwages.Text =
				tbsgender.Text =
				ybsimage.Text =
				tbLeft.Text =
				tbright.Text =
				tbunknown.Text =
					"";
			lvEmployees.Clear();
			ilist.Images.Clear();
		}

		private void btaddim_Click(object sender, EventArgs e)
		{
			if (cbsimselect.Items.Count < 1)
			{
				cbsimselect.Items.Clear();
				cbsimselect.Sorted = false;
				foreach (
					ExtSDesc sdsc in FileTableBase
						.ProviderRegistry
						.SimDescriptionProvider
						.SimInstance
						.Values
				)
				{
					if (canhire(sdsc))
					{
						Interfaces.IAlias a = new StaticAlias(
							sdsc.SimId,
							sdsc.SimName + " " + sdsc.SimFamilyName,
							new object[] { sdsc }
						);
						cbsimselect.Items.Add(a);
					}
				}
				cbsimselect.Sorted = true;
			}
			biWorkers.Enabled = false;
			Panel3.Visible = true;
		}

		private void btchcancel_Click(object sender, EventArgs e)
		{
			Panel3.Visible = false;
			biWorkers.Enabled = true;
		}

		private void btchadd_Click(object sender, EventArgs e)
		{
			if (cbsimselect.SelectedItem == null)
			{
				return;
			}

			Interfaces.IAlias a =
				cbsimselect.SelectedItem as Interfaces.IAlias;
			if (a.Tag[0] is ExtSDesc s)
			{
				ushort[] empls = new ushort[Bnfo.EmployeeCount + 1];
				int[] pr = new int[Bnfo.EmployeeCount + 1];
				uint[] tit = new uint[Bnfo.EmployeeCount + 1];
				int bpy = 15;
				bpy += s.Skills.Body / 100;
				bpy += s.Skills.Charisma / 100;
				bpy += s.Skills.Cleaning / 100;
				bpy += s.Skills.Cooking / 100;
				bpy += s.Skills.Creativity / 100;
				bpy += s.Skills.Logic / 100;
				bpy += s.Skills.Mechanical / 100;
				bpy += s.Skills.Art / 100;
				bpy += s.Skills.Music / 100;
				for (int i = 0; i < Bnfo.EmployeeCount; i++)
				{
					empls[i] = Bnfo.Employees[i];
					pr[i] = Bnfo.PayRate[i];
				}
				empls[Bnfo.EmployeeCount] = s.Instance;
				pr[Bnfo.EmployeeCount] = 3;
				tit[Bnfo.EmployeeCount] = (uint)bpy;

				Bnfo.EmployeeCount++;
				Bnfo.Employees = empls;
				Bnfo.PayRate = pr;

				if (Bnfo.Package == s.Package)
				{
					try
					{
						s.CharacterDescription.Career = MetaData.Careers.OwnedBuss;
						s.CharacterDescription.CareerLevel = 1;
						s.Business.Assignment = JobAssignment.Nothing;
						s.Business.LotID = (ushort)Bnfo.FileDescriptor.Instance;
						s.Business.Salary = (ushort)bpy;
						s.Business.Flags = 0;
						s.SynchronizeUserData();
						lbadvice.Text =
							s.SimName + "'s SDSC was changed, be sure to Commit now";
					}
					catch
					{
						lbadvice.Text =
							"You will need to find and make changes to "
							+ s.SimName
							+ "'s SDSC file";
					}
				}
				else
				{
					lbadvice.Text =
						"You will need to find and make changes to "
						+ s.SimName
						+ "'s SDSC file";
				}

				biWorkers.Enabled = true;
				lbadvice.Visible = true;
				Panel3.Visible = false;
				panel2_clear();
				GetEmployees();
			}
		}

		private void cbsimselect_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (intern)
			{
				return;
			}

			if (cbsimselect.SelectedItem == null)
			{
				return;
			}

			try
			{
				Interfaces.IAlias a =
					cbsimselect.SelectedItem as Interfaces.IAlias;
				if (a.Tag[0] is ExtSDesc s)
				{
					tbchage.Text = Enum.GetName(
						typeof(MetaData.LifeSections),
						(ushort)s.CharacterDescription.LifeSection
					);
					tbchgender.Text = s.CharacterDescription.Gender == MetaData.Gender.Female ? "Female" : "Male";
				}
				else
				{
					tbchage.Text = tbchgender.Text = "";
				}
			}
			catch { }
		}

		private bool canhire(ExtSDesc sdsc)
		{
			foreach (ushort employee in Bnfo.Employees)
			{
				if (sdsc.Instance == employee)
				{
					return false; // already employee
				}
			}

			if (sdsc.CharacterDescription.Realage < 16)
			{
				return false; // younger than teen
			}

			if (sdsc.University.OnCampus == 1)
			{
				return false; // young adult
			}

			if (sdsc.CharacterDescription.GhostFlag.IsGhost)
			{
				return false; // Too dead to work
			}

			if (sdsc.FamilyInstance == famly)
			{
				return false; // same family as owner
			}

			if (sdsc.FamilyInstance == 0)
			{
				return false;
			}

			if (sdsc.FamilyInstance == 0x7FFF)
			{
				return false; // service sim
			}

			if (sdsc.FamilyInstance == 0x7FFD)
			{
				return false; // orphans
			}

			if (sdsc.FamilyInstance == 0x7FE4)
			{
				return false; // Iconic Hobby Sim
			}

			if (sdsc.FamilyInstance == 0x7FF1)
			{
				return false; // Tropical Locals
			}

			if (sdsc.FamilyInstance == 0x7FF2)
			{
				return false; // Mountain Locals
			}

			if (sdsc.FamilyInstance == 0x7FF3)
			{
				return false; // Asian Locals
			}

			if (sdsc.FamilyInstance == 0x7f65)
			{
				return false; // West World Locals
			}

			if (sdsc.FamilyInstance == 0x7f66)
			{
				return false; // Natives (castaway)
			}

			if (sdsc.FamilyInstance == 0x7f67)
			{
				return false; // Tau Ceti Locals
			}

			if (sdsc.FamilyInstance == 0x7f68)
			{
				return false; // Alpine Locals
			}

			if (sdsc.IsNPC)
			{
				return false; // NPC unique
			}
			// not if is NPC repoter - those are in service sim family and already excluded anyway
			return sdsc.Nightlife.IsHuman; // no pets
		}

		private bool AllValid()
		{
			if (lv.Items == null)
			{
				return true;
			}

			foreach (BnfoCustomerItem item in lv.Items)
			{
				if (item.SimDescription == null)
				{
					return false;
				}
			}

			return true;
		}

		private void btchngeOwn_Click(object sender, EventArgs e)
		{
			if (cbOsimselect.Items.Count < 1)
			{
				cbOsimselect.Items.Clear();
				cbOsimselect.Sorted = false;
				foreach (
					ExtSDesc sdsc in FileTableBase
						.ProviderRegistry
						.SimDescriptionProvider
						.SimInstance
						.Values
				)
				{
					if (canownim(sdsc))
					{
						Interfaces.IAlias a = new StaticAlias(
							sdsc.SimId,
							sdsc.SimName + " " + sdsc.SimFamilyName,
							new object[] { sdsc }
						);
						cbOsimselect.Items.Add(a);
					}
				}
				cbOsimselect.Sorted = true;
			}
			biWorkers.Enabled = false;
			Panel4.Visible = true;
		}

		private void cbOsimselect_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (intern)
			{
				return;
			}

			if (cbOsimselect.SelectedItem == null)
			{
				return;
			}

			try
			{
				Interfaces.IAlias a =
					cbOsimselect.SelectedItem as Interfaces.IAlias;
				if (a.Tag[0] is ExtSDesc s)
				{
					tbOchage.Text = Enum.GetName(
						typeof(MetaData.LifeSections),
						(ushort)s.CharacterDescription.LifeSection
					);
					tbOgender.Text = s.CharacterDescription.Gender == MetaData.Gender.Female ? "Female" : "Male";
				}
				else
				{
					tbOchage.Text = tbOgender.Text = "";
				}
			}
			catch { }
		}

		private void btOcancel_Click(object sender, EventArgs e)
		{
			Panel4.Visible = false;
			biWorkers.Enabled = true;
		}

		private void btOadd_Click(object sender, EventArgs e)
		{
			if (cbOsimselect.SelectedItem == null)
			{
				return;
			}

			Interfaces.IAlias a =
				cbOsimselect.SelectedItem as Interfaces.IAlias;
			if (a.Tag[0] is ExtSDesc s)
			{
				if (famly > 0 && homeb == 0 && s.FamilyInstance != famly)
				{
					lbadvice.Text =
						"Only a family member can be the owner of a home business";
					lbadvice.Visible = true;
				}
				else
				{
					Interfaces.Files.IPackedFileDescriptor pfd =
						Bnfo.Package.FindFile(
							0x0BF999E7,
							0,
							0xFFFFFFFF,
							Bnfo.FileDescriptor.Instance
						);
					if (pfd != null)
					{
						Ltxt ltx = new Ltxt();
						ltx.ProcessData(pfd, Bnfo.Package);
						ltx.OwnerInstance = s.Instance;
						ltx.SynchronizeUserData();
					}
					owner = s.Instance;
				}

				biWorkers.Enabled = true;
				Panel4.Visible = false;
				panel2_clear();
				GetEmployees();
			}
		}

		private bool canownim(ExtSDesc sdsc)
		{
			foreach (ushort employee in Bnfo.Employees)
			{
				if (sdsc.Instance == employee)
				{
					return false; // an employee
				}
			}

			if (sdsc.Instance == owner)
			{
				return false; // current Owner
			}

			if (sdsc.CharacterDescription.Realage < 16)
			{
				return false; // younger than teen
			}

			if (sdsc.CharacterDescription.GhostFlag.IsGhost)
			{
				return false; // Too dead to work
			}

			if (sdsc.FamilyInstance == 0 || sdsc.FamilyInstance > 0x7F00)
			{
				return false; // non Playable
			}

			return sdsc.Nightlife.IsHuman; // no pets
		}

		private Packages.File fixlowercase(string filyname)
		{
			return System.IO.File.Exists(filyname) ? Packages.File.LoadFromFile(filyname) : (Packages.File)null;
			/*
			 * SimPe often internally changes filenames to lower case and if re-opening a recently opened file
			 * it can load it from memory causing the lower case filename to remain, this causes it to re-open
			 * the file from disk to refresh the filename
			*/
		}
	}
}
