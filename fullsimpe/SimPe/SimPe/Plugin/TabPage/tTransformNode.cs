// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Numerics;
using System.Windows.Forms;

using SimPe.Extensions;

namespace SimPe.Plugin.TabPage
{
	/// <summary>
	/// Summary description for fShapeRefNode.
	/// </summary>
	public class TransformNode
		:
		//System.Windows.Forms.UserControl
		System.Windows.Forms.TabPage
	{
		private GroupBox groupBox6;
		private LinkLabel ll_tn_add;
		private TextBox tb_tn_2;
		private Label label16;
		private TextBox tb_tn_1;
		private Label label17;
		internal ListBox lb_tn;
		private LinkLabel ll_tn_delete;
		private GroupBox groupBox7;
		internal TextBox tb_tn_ver;
		private Label label26;
		private GroupBox groupBox15;
		private GroupBox groupBox16;
		internal TextBox tb_tn_ukn;
		private Label label19;
		internal TextBox tb_tn_tx;
		private Label label49;
		internal TextBox tb_tn_ty;
		private Label label50;
		internal TextBox tb_tn_tz;
		private Label label51;
		internal TextBox tb_tn_rz;
		private Label label52;
		internal TextBox tb_tn_ry;
		private Label label53;
		internal TextBox tb_tn_rx;
		private Label label54;
		internal TextBox tb_tn_rw;
		private Label label55;
		private GroupBox groupBox12;
		internal TextBox tb_tn_a;
		private Label label30;
		internal TextBox tb_tn_az;
		private Label label31;
		internal TextBox tb_tn_ay;
		private Label label56;
		internal TextBox tb_tn_ax;
		private Label label57;
		private GroupBox groupBox18;
		internal TextBox tb_tn_er;
		private Label label60;
		internal TextBox tb_tn_ep;
		private Label label61;
		internal TextBox tb_tn_ey;
		private Label label62;

		//private System.ComponentModel.IContainer components;

		public TransformNode()
		{
			SetStyle(
				ControlStyles.SupportsTransparentBackColor
					| ControlStyles.AllPaintingInWmPaint
					|
					//ControlStyles.Opaque |
					ControlStyles.UserPaint
					| ControlStyles.ResizeRedraw
					| ControlStyles.DoubleBuffer,
				true
			);

			//
			// Required designer variable.
			//
			InitializeComponent();

			UseVisualStyleBackColor = true;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				Tag = null;
				/*if(components != null)
				{
					components.Dispose();
				}*/
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
			groupBox7 = new GroupBox();
			tb_tn_ukn = new TextBox();
			label19 = new Label();
			tb_tn_ver = new TextBox();
			label26 = new Label();
			groupBox6 = new GroupBox();
			ll_tn_add = new LinkLabel();
			tb_tn_2 = new TextBox();
			label16 = new Label();
			tb_tn_1 = new TextBox();
			label17 = new Label();
			lb_tn = new ListBox();
			ll_tn_delete = new LinkLabel();
			groupBox15 = new GroupBox();
			tb_tn_tz = new TextBox();
			label51 = new Label();
			tb_tn_ty = new TextBox();
			label50 = new Label();
			tb_tn_tx = new TextBox();
			label49 = new Label();
			groupBox16 = new GroupBox();
			tb_tn_rw = new TextBox();
			label55 = new Label();
			tb_tn_rz = new TextBox();
			label52 = new Label();
			tb_tn_ry = new TextBox();
			label53 = new Label();
			tb_tn_rx = new TextBox();
			label54 = new Label();
			groupBox12 = new GroupBox();
			tb_tn_a = new TextBox();
			label30 = new Label();
			tb_tn_az = new TextBox();
			label31 = new Label();
			tb_tn_ay = new TextBox();
			label56 = new Label();
			tb_tn_ax = new TextBox();
			label57 = new Label();
			groupBox18 = new GroupBox();
			tb_tn_er = new TextBox();
			label60 = new Label();
			tb_tn_ep = new TextBox();
			label61 = new Label();
			tb_tn_ey = new TextBox();
			label62 = new Label();
			groupBox7.SuspendLayout();
			groupBox6.SuspendLayout();
			groupBox15.SuspendLayout();
			groupBox16.SuspendLayout();
			groupBox12.SuspendLayout();
			groupBox18.SuspendLayout();
			SuspendLayout();
			//
			// tTransformNode
			//
			BackColor = System.Drawing.SystemColors.ControlLightLight;
			Controls.Add(groupBox7);
			Controls.Add(groupBox6);
			Controls.Add(groupBox15);
			Controls.Add(groupBox16);
			Controls.Add(groupBox12);
			Controls.Add(groupBox18);
			Location = new System.Drawing.Point(4, 22);
			Name = "tTransformNode";
			Size = new System.Drawing.Size(792, 262);
			TabIndex = 2;
			Text = "TransformNode";
			//
			// groupBox7
			//
			groupBox7.Controls.Add(tb_tn_ukn);
			groupBox7.Controls.Add(label19);
			groupBox7.Controls.Add(tb_tn_ver);
			groupBox7.Controls.Add(label26);
			groupBox7.FlatStyle = FlatStyle.System;
			groupBox7.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox7.Location = new System.Drawing.Point(8, 7);
			groupBox7.Name = "groupBox7";
			groupBox7.Size = new System.Drawing.Size(296, 73);
			groupBox7.TabIndex = 8;
			groupBox7.TabStop = false;
			groupBox7.Text = "Settings";
			//
			// tb_tn_ukn
			//
			tb_tn_ukn.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_tn_ukn.Location = new System.Drawing.Point(136, 40);
			tb_tn_ukn.Name = "tb_tn_ukn";
			tb_tn_ukn.Size = new System.Drawing.Size(88, 21);
			tb_tn_ukn.TabIndex = 26;
			tb_tn_ukn.Text = "0x00000000";
			tb_tn_ukn.TextChanged += new EventHandler(
				TNChangeSettings
			);
			//
			// label19
			//
			label19.AutoSize = true;
			label19.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label19.Location = new System.Drawing.Point(128, 24);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(109, 17);
			label19.TabIndex = 25;
			label19.Text = "GMDC joint index:";
			//
			// tb_tn_ver
			//
			tb_tn_ver.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_tn_ver.Location = new System.Drawing.Point(16, 40);
			tb_tn_ver.Name = "tb_tn_ver";
			tb_tn_ver.Size = new System.Drawing.Size(88, 21);
			tb_tn_ver.TabIndex = 24;
			tb_tn_ver.Text = "0x00000000";
			tb_tn_ver.TextChanged += new EventHandler(
				TNChangeSettings
			);
			//
			// label26
			//
			label26.AutoSize = true;
			label26.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label26.Location = new System.Drawing.Point(8, 24);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(52, 17);
			label26.TabIndex = 23;
			label26.Text = "Version:";
			//
			// groupBox6
			//
			groupBox6.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Bottom
						 | AnchorStyles.Left


			;
			groupBox6.Controls.Add(ll_tn_add);
			groupBox6.Controls.Add(tb_tn_2);
			groupBox6.Controls.Add(label16);
			groupBox6.Controls.Add(tb_tn_1);
			groupBox6.Controls.Add(label17);
			groupBox6.Controls.Add(lb_tn);
			groupBox6.Controls.Add(ll_tn_delete);
			groupBox6.FlatStyle = FlatStyle.System;
			groupBox6.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox6.Location = new System.Drawing.Point(504, 8);
			groupBox6.Name = "groupBox6";
			groupBox6.Size = new System.Drawing.Size(256, 248);
			groupBox6.TabIndex = 6;
			groupBox6.TabStop = false;
			groupBox6.Text = "Child Nodes:";
			//
			// ll_tn_add
			//
			ll_tn_add.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			ll_tn_add.AutoSize = true;
			ll_tn_add.Location = new System.Drawing.Point(176, 96);
			ll_tn_add.Name = "ll_tn_add";
			ll_tn_add.Size = new System.Drawing.Size(28, 17);
			ll_tn_add.TabIndex = 6;
			ll_tn_add.TabStop = true;
			ll_tn_add.Text = "add";
			ll_tn_add.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					TNItemsAdd
				);
			//
			// tb_tn_2
			//
			tb_tn_2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_tn_2.Location = new System.Drawing.Point(160, 72);
			tb_tn_2.Name = "tb_tn_2";
			tb_tn_2.Size = new System.Drawing.Size(88, 21);
			tb_tn_2.TabIndex = 4;
			tb_tn_2.Text = "0x00000000";
			tb_tn_2.TextChanged += new EventHandler(TNChangedItems);
			//
			// label16
			//
			label16.AutoSize = true;
			label16.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label16.Location = new System.Drawing.Point(152, 56);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(74, 17);
			label16.TabIndex = 3;
			label16.Text = "Child Index:";
			//
			// tb_tn_1
			//
			tb_tn_1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_tn_1.Location = new System.Drawing.Point(160, 32);
			tb_tn_1.Name = "tb_tn_1";
			tb_tn_1.Size = new System.Drawing.Size(88, 21);
			tb_tn_1.TabIndex = 2;
			tb_tn_1.Text = "0x0000";
			tb_tn_1.TextChanged += new EventHandler(TNChangedItems);
			//
			// label17
			//
			label17.AutoSize = true;
			label17.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label17.Location = new System.Drawing.Point(152, 16);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(73, 17);
			label17.TabIndex = 1;
			label17.Text = "Unknown 1:";
			//
			// lb_tn
			//
			lb_tn.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Bottom
						 | AnchorStyles.Left


			;
			lb_tn.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lb_tn.IntegralHeight = false;
			lb_tn.Location = new System.Drawing.Point(8, 24);
			lb_tn.Name = "lb_tn";
			lb_tn.Size = new System.Drawing.Size(136, 216);
			lb_tn.TabIndex = 0;
			lb_tn.SelectedIndexChanged += new EventHandler(TNSelect);
			//
			// ll_tn_delete
			//
			ll_tn_delete.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			ll_tn_delete.AutoSize = true;
			ll_tn_delete.Location = new System.Drawing.Point(204, 96);
			ll_tn_delete.Name = "ll_tn_delete";
			ll_tn_delete.Size = new System.Drawing.Size(44, 17);
			ll_tn_delete.TabIndex = 5;
			ll_tn_delete.TabStop = true;
			ll_tn_delete.Text = "delete";
			ll_tn_delete.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					TNItemsDelete
				);
			//
			// groupBox15
			//
			groupBox15.Controls.Add(tb_tn_tz);
			groupBox15.Controls.Add(label51);
			groupBox15.Controls.Add(tb_tn_ty);
			groupBox15.Controls.Add(label50);
			groupBox15.Controls.Add(tb_tn_tx);
			groupBox15.Controls.Add(label49);
			groupBox15.FlatStyle = FlatStyle.System;
			groupBox15.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox15.Location = new System.Drawing.Point(8, 128);
			groupBox15.Name = "groupBox15";
			groupBox15.Size = new System.Drawing.Size(120, 104);
			groupBox15.TabIndex = 25;
			groupBox15.TabStop = false;
			groupBox15.Text = "Translation:";
			//
			// tb_tn_tz
			//
			tb_tn_tz.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_tn_tz.Location = new System.Drawing.Point(40, 72);
			tb_tn_tz.Name = "tb_tn_tz";
			tb_tn_tz.Size = new System.Drawing.Size(72, 21);
			tb_tn_tz.TabIndex = 32;
			tb_tn_tz.Text = "0x00000000";
			tb_tn_tz.TextChanged += new EventHandler(TNChangeSettings);
			//
			// label51
			//
			label51.AutoSize = true;
			label51.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label51.Location = new System.Drawing.Point(16, 80);
			label51.Name = "label51";
			label51.Size = new System.Drawing.Size(17, 17);
			label51.TabIndex = 31;
			label51.Text = "Z:";
			//
			// tb_tn_ty
			//
			tb_tn_ty.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_tn_ty.Location = new System.Drawing.Point(40, 48);
			tb_tn_ty.Name = "tb_tn_ty";
			tb_tn_ty.Size = new System.Drawing.Size(72, 21);
			tb_tn_ty.TabIndex = 30;
			tb_tn_ty.Text = "0x00000000";
			tb_tn_ty.TextChanged += new EventHandler(TNChangeSettings);
			//
			// label50
			//
			label50.AutoSize = true;
			label50.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label50.Location = new System.Drawing.Point(16, 56);
			label50.Name = "label50";
			label50.Size = new System.Drawing.Size(16, 17);
			label50.TabIndex = 29;
			label50.Text = "Y:";
			//
			// tb_tn_tx
			//
			tb_tn_tx.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_tn_tx.Location = new System.Drawing.Point(40, 24);
			tb_tn_tx.Name = "tb_tn_tx";
			tb_tn_tx.Size = new System.Drawing.Size(72, 21);
			tb_tn_tx.TabIndex = 28;
			tb_tn_tx.Text = "0x00000000";
			tb_tn_tx.TextChanged += new EventHandler(TNChangeSettings);
			//
			// label49
			//
			label49.AutoSize = true;
			label49.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label49.Location = new System.Drawing.Point(16, 32);
			label49.Name = "label49";
			label49.Size = new System.Drawing.Size(17, 17);
			label49.TabIndex = 27;
			label49.Text = "X:";
			//
			// groupBox16
			//
			groupBox16.Controls.Add(tb_tn_rw);
			groupBox16.Controls.Add(label55);
			groupBox16.Controls.Add(tb_tn_rz);
			groupBox16.Controls.Add(label52);
			groupBox16.Controls.Add(tb_tn_ry);
			groupBox16.Controls.Add(label53);
			groupBox16.Controls.Add(tb_tn_rx);
			groupBox16.Controls.Add(label54);
			groupBox16.FlatStyle = FlatStyle.System;
			groupBox16.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox16.Location = new System.Drawing.Point(136, 104);
			groupBox16.Name = "groupBox16";
			groupBox16.Size = new System.Drawing.Size(120, 128);
			groupBox16.TabIndex = 26;
			groupBox16.TabStop = false;
			groupBox16.Text = "Quaternion:";
			//
			// tb_tn_rw
			//
			tb_tn_rw.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_tn_rw.Location = new System.Drawing.Point(40, 96);
			tb_tn_rw.Name = "tb_tn_rw";
			tb_tn_rw.Size = new System.Drawing.Size(72, 21);
			tb_tn_rw.TabIndex = 40;
			tb_tn_rw.Text = "0x00000000";
			tb_tn_rw.TextChanged += new EventHandler(TNChangeSettings);
			//
			// label55
			//
			label55.AutoSize = true;
			label55.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label55.Location = new System.Drawing.Point(16, 104);
			label55.Name = "label55";
			label55.Size = new System.Drawing.Size(21, 17);
			label55.TabIndex = 39;
			label55.Text = "W:";
			//
			// tb_tn_rz
			//
			tb_tn_rz.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_tn_rz.Location = new System.Drawing.Point(40, 72);
			tb_tn_rz.Name = "tb_tn_rz";
			tb_tn_rz.Size = new System.Drawing.Size(72, 21);
			tb_tn_rz.TabIndex = 38;
			tb_tn_rz.Text = "0x00000000";
			tb_tn_rz.TextChanged += new EventHandler(TNChangeSettings);
			//
			// label52
			//
			label52.AutoSize = true;
			label52.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label52.Location = new System.Drawing.Point(16, 80);
			label52.Name = "label52";
			label52.Size = new System.Drawing.Size(17, 17);
			label52.TabIndex = 37;
			label52.Text = "Z:";
			//
			// tb_tn_ry
			//
			tb_tn_ry.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_tn_ry.Location = new System.Drawing.Point(40, 48);
			tb_tn_ry.Name = "tb_tn_ry";
			tb_tn_ry.Size = new System.Drawing.Size(72, 21);
			tb_tn_ry.TabIndex = 36;
			tb_tn_ry.Text = "0x00000000";
			tb_tn_ry.TextChanged += new EventHandler(TNChangeSettings);
			//
			// label53
			//
			label53.AutoSize = true;
			label53.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label53.Location = new System.Drawing.Point(16, 56);
			label53.Name = "label53";
			label53.Size = new System.Drawing.Size(16, 17);
			label53.TabIndex = 35;
			label53.Text = "Y:";
			//
			// tb_tn_rx
			//
			tb_tn_rx.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_tn_rx.Location = new System.Drawing.Point(40, 24);
			tb_tn_rx.Name = "tb_tn_rx";
			tb_tn_rx.Size = new System.Drawing.Size(72, 21);
			tb_tn_rx.TabIndex = 34;
			tb_tn_rx.Text = "0x00000000";
			tb_tn_rx.TextChanged += new EventHandler(TNChangeSettings);
			//
			// label54
			//
			label54.AutoSize = true;
			label54.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label54.Location = new System.Drawing.Point(16, 32);
			label54.Name = "label54";
			label54.Size = new System.Drawing.Size(17, 17);
			label54.TabIndex = 33;
			label54.Text = "X:";
			//
			// groupBox12
			//
			groupBox12.Controls.Add(tb_tn_a);
			groupBox12.Controls.Add(label30);
			groupBox12.Controls.Add(tb_tn_az);
			groupBox12.Controls.Add(label31);
			groupBox12.Controls.Add(tb_tn_ay);
			groupBox12.Controls.Add(label56);
			groupBox12.Controls.Add(tb_tn_ax);
			groupBox12.Controls.Add(label57);
			groupBox12.FlatStyle = FlatStyle.System;
			groupBox12.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox12.Location = new System.Drawing.Point(264, 104);
			groupBox12.Name = "groupBox12";
			groupBox12.Size = new System.Drawing.Size(112, 128);
			groupBox12.TabIndex = 41;
			groupBox12.TabStop = false;
			groupBox12.Text = "Rotation:";
			//
			// tb_tn_a
			//
			tb_tn_a.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_tn_a.Location = new System.Drawing.Point(64, 96);
			tb_tn_a.Name = "tb_tn_a";
			tb_tn_a.Size = new System.Drawing.Size(40, 21);
			tb_tn_a.TabIndex = 40;
			tb_tn_a.Text = "0";
			tb_tn_a.TextChanged += new EventHandler(
				TNChangedQuaternion
			);
			//
			// label30
			//
			label30.AutoSize = true;
			label30.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label30.Location = new System.Drawing.Point(16, 104);
			label30.Name = "label30";
			label30.Size = new System.Drawing.Size(41, 17);
			label30.TabIndex = 39;
			label30.Text = "Angle:";
			//
			// tb_tn_az
			//
			tb_tn_az.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_tn_az.Location = new System.Drawing.Point(40, 72);
			tb_tn_az.Name = "tb_tn_az";
			tb_tn_az.Size = new System.Drawing.Size(64, 21);
			tb_tn_az.TabIndex = 38;
			tb_tn_az.Text = "0";
			tb_tn_az.TextChanged += new EventHandler(
				TNChangedQuaternion
			);
			//
			// label31
			//
			label31.AutoSize = true;
			label31.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label31.Location = new System.Drawing.Point(16, 80);
			label31.Name = "label31";
			label31.Size = new System.Drawing.Size(17, 17);
			label31.TabIndex = 37;
			label31.Text = "Z:";
			//
			// tb_tn_ay
			//
			tb_tn_ay.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_tn_ay.Location = new System.Drawing.Point(40, 48);
			tb_tn_ay.Name = "tb_tn_ay";
			tb_tn_ay.Size = new System.Drawing.Size(64, 21);
			tb_tn_ay.TabIndex = 36;
			tb_tn_ay.Text = "0";
			tb_tn_ay.TextChanged += new EventHandler(
				TNChangedQuaternion
			);
			//
			// label56
			//
			label56.AutoSize = true;
			label56.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label56.Location = new System.Drawing.Point(16, 56);
			label56.Name = "label56";
			label56.Size = new System.Drawing.Size(16, 17);
			label56.TabIndex = 35;
			label56.Text = "Y:";
			//
			// tb_tn_ax
			//
			tb_tn_ax.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_tn_ax.Location = new System.Drawing.Point(40, 24);
			tb_tn_ax.Name = "tb_tn_ax";
			tb_tn_ax.Size = new System.Drawing.Size(64, 21);
			tb_tn_ax.TabIndex = 34;
			tb_tn_ax.Text = "0";
			tb_tn_ax.TextChanged += new EventHandler(
				TNChangedQuaternion
			);
			//
			// label57
			//
			label57.AutoSize = true;
			label57.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label57.Location = new System.Drawing.Point(16, 32);
			label57.Name = "label57";
			label57.Size = new System.Drawing.Size(17, 17);
			label57.TabIndex = 33;
			label57.Text = "X:";
			//
			// groupBox18
			//
			groupBox18.Controls.Add(tb_tn_er);
			groupBox18.Controls.Add(label60);
			groupBox18.Controls.Add(tb_tn_ep);
			groupBox18.Controls.Add(label61);
			groupBox18.Controls.Add(tb_tn_ey);
			groupBox18.Controls.Add(label62);
			groupBox18.FlatStyle = FlatStyle.System;
			groupBox18.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox18.Location = new System.Drawing.Point(384, 128);
			groupBox18.Name = "groupBox18";
			groupBox18.Size = new System.Drawing.Size(112, 104);
			groupBox18.TabIndex = 42;
			groupBox18.TabStop = false;
			groupBox18.Text = "Euler Rotation:";
			//
			// tb_tn_er
			//
			tb_tn_er.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_tn_er.Location = new System.Drawing.Point(40, 72);
			tb_tn_er.Name = "tb_tn_er";
			tb_tn_er.Size = new System.Drawing.Size(64, 21);
			tb_tn_er.TabIndex = 38;
			tb_tn_er.Text = "0";
			tb_tn_er.TextChanged += new EventHandler(
				TNChangedEulerQuaternion
			);
			//
			// label60
			//
			label60.AutoSize = true;
			label60.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label60.Location = new System.Drawing.Point(16, 80);
			label60.Name = "label60";
			label60.Size = new System.Drawing.Size(17, 17);
			label60.TabIndex = 37;
			label60.Text = "R:";
			//
			// tb_tn_ep
			//
			tb_tn_ep.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_tn_ep.Location = new System.Drawing.Point(40, 48);
			tb_tn_ep.Name = "tb_tn_ep";
			tb_tn_ep.Size = new System.Drawing.Size(64, 21);
			tb_tn_ep.TabIndex = 36;
			tb_tn_ep.Text = "0";
			tb_tn_ep.TextChanged += new EventHandler(
				TNChangedEulerQuaternion
			);
			//
			// label61
			//
			label61.AutoSize = true;
			label61.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label61.Location = new System.Drawing.Point(16, 56);
			label61.Name = "label61";
			label61.Size = new System.Drawing.Size(16, 17);
			label61.TabIndex = 35;
			label61.Text = "P:";
			//
			// tb_tn_ey
			//
			tb_tn_ey.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_tn_ey.Location = new System.Drawing.Point(40, 24);
			tb_tn_ey.Name = "tb_tn_ey";
			tb_tn_ey.Size = new System.Drawing.Size(64, 21);
			tb_tn_ey.TabIndex = 34;
			tb_tn_ey.Text = "0";
			tb_tn_ey.TextChanged += new EventHandler(
				TNChangedEulerQuaternion
			);
			//
			// label62
			//
			label62.AutoSize = true;
			label62.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label62.Location = new System.Drawing.Point(16, 32);
			label62.Name = "label62";
			label62.Size = new System.Drawing.Size(16, 17);
			label62.TabIndex = 33;
			label62.Text = "Y:";
			//
			// fShapeRefNode
			//
			groupBox7.ResumeLayout(false);
			groupBox6.ResumeLayout(false);
			groupBox15.ResumeLayout(false);
			groupBox16.ResumeLayout(false);
			groupBox12.ResumeLayout(false);
			groupBox18.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion


		private void TNChangeSettings(object sender, EventArgs e)
		{
			if (tb_tn_a.Tag != null)
			{
				return;
			}

			if (Tag == null)
			{
				return;
			}

			try
			{
				Plugin.TransformNode tn = (Plugin.TransformNode)Tag;

				tn.Version = Convert.ToUInt32(tb_tn_ver.Text, 16);
				tn.JointReference = Convert.ToInt32(tb_tn_ukn.Text, 16);

				tn.TransformX = Convert.ToSingle(tb_tn_tx.Text);
				tn.TransformY = Convert.ToSingle(tb_tn_ty.Text);
				tn.TransformZ = Convert.ToSingle(tb_tn_tz.Text);

				tn.RotationX = Convert.ToSingle(tb_tn_rx.Text);
				tn.RotationY = Convert.ToSingle(tb_tn_ry.Text);
				tn.RotationZ = Convert.ToSingle(tb_tn_rz.Text);
				tn.RotationW = Convert.ToSingle(tb_tn_rw.Text);

				//set Angles


				Quaternion q = tn.Rotation;
				TNUpdateTextValues(q, false, true, true);

				tn.Changed = true;
			}
			catch (Exception)
			{
				//Helper.ExceptionMessage("", ex);
			}
		}

		private void TNChangedQuaternion(object sender, EventArgs e)
		{
			if (tb_tn_a.Tag != null)
			{
				return;
			}

			if (Tag == null)
			{
				return;
			}

			try
			{
				Plugin.TransformNode tn = (Plugin.TransformNode)Tag;
				Quaternion q = Quaternion.CreateFromAxisAngle(
					new Vector3(
						Convert.ToSingle(tb_tn_ax.Text),
						Convert.ToSingle(tb_tn_ay.Text),
						Convert.ToSingle(tb_tn_az.Text)
					),
					Convert.ToSingle(tb_tn_a.Text).DegreesToRadians()
				);

				tn.Rotation = q;

				TNUpdateTextValues(q, true, false, true);
			}
			catch { }
			finally
			{
				tb_tn_a.Tag = null;
			}
		}

		internal void TNUpdateTextValues(
			Quaternion q,
			bool quat,
			bool axis,
			bool euler
		)
		{
			//set Angles
			try
			{
				tb_tn_a.Tag = true;
				if (quat)
				{
					tb_tn_rx.Text = q.X.ToString("N6");
					tb_tn_ry.Text = q.Y.ToString("N6");
					tb_tn_rz.Text = q.Z.ToString("N6");
					tb_tn_rw.Text = q.W.ToString("N6");
				}

				if (axis)
				{
					tb_tn_ax.Text = q.GetAxis().X.ToString("N6");
					tb_tn_ay.Text = q.GetAxis().Y.ToString("N6");
					tb_tn_az.Text = q.GetAxis().Z.ToString("N6");
					tb_tn_a.Text =
						q.GetAngle().RadiansToDegrees()
						.ToString("N6");
				}

				if (euler)
				{
					Vector3 ea = q.GetEulerAnglesZYX();
					tb_tn_ey.Text =
						ea.Y.RadiansToDegrees()
						.ToString("N6");
					tb_tn_ep.Text =
						ea.X.RadiansToDegrees()
						.ToString("N6");
					tb_tn_er.Text =
						ea.Z.RadiansToDegrees()
						.ToString("N6");
				}
			}
			finally
			{
				tb_tn_a.Tag = null;
			}
		}

		private void TNChangedEulerQuaternion(object sender, EventArgs e)
		{
			if (tb_tn_a.Tag != null)
			{
				return;
			}

			if (Tag == null)
			{
				return;
			}

			try
			{
				Plugin.TransformNode tn = (Plugin.TransformNode)Tag;
				Quaternion q = Quaternion.CreateFromYawPitchRoll(
					Convert.ToSingle(tb_tn_ey.Text).DegreesToRadians(),
					Convert.ToSingle(tb_tn_ep.Text).DegreesToRadians(),
					Convert.ToSingle(tb_tn_er.Text).DegreesToRadians()
				);
				tn.Rotation = q;

				TNUpdateTextValues(q, true, true, false);
			}
			catch { }
			finally
			{
				tb_tn_a.Tag = null;
			}
		}

		#region Select TN Items
		private void TNSelect(object sender, EventArgs e)
		{
			if (lb_tn.Tag != null)
			{
				return;
			}

			if (lb_tn.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				lb_tn.Tag = true;
				Plugin.TransformNode tn = (Plugin.TransformNode)Tag;
				TransformNodeItem b = (TransformNodeItem)
					lb_tn.Items[lb_tn.SelectedIndex];

				tb_tn_1.Text = "0x" + Helper.HexString(b.Unknown1);
				tb_tn_2.Text = "0x" + Helper.HexString((uint)b.ChildNode);
				tn.Changed = true;
			}
			catch (Exception)
			{
				//Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lb_tn.Tag = null;
			}
		}

		private void TNChangedItems(object sender, EventArgs e)
		{
			if (lb_tn.Tag != null)
			{
				return;
			}

			if (lb_tn.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				lb_tn.Tag = true;
				Plugin.TransformNode tn = (Plugin.TransformNode)Tag;
				TransformNodeItem b = (TransformNodeItem)
					lb_tn.Items[lb_tn.SelectedIndex];

				b.Unknown1 = Convert.ToUInt16(tb_tn_1.Text, 16);
				b.ChildNode = (int)Convert.ToUInt32(tb_tn_2.Text, 16);

				lb_tn.Items[lb_tn.SelectedIndex] = b;
				tn.Changed = true;
			}
			catch (Exception)
			{
				//Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lb_tn.Tag = null;
			}
		}

		private void TNItemsAdd(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (Tag == null)
			{
				return;
			}

			try
			{
				lb_tn.Tag = true;
				Plugin.TransformNode tn = (Plugin.TransformNode)Tag;
				TransformNodeItem b = new TransformNodeItem
				{
					Unknown1 = Convert.ToUInt16(tb_tn_1.Text, 16),
					ChildNode = (int)Convert.ToUInt32(tb_tn_2.Text, 16)
				};

				tn.Items.Add(b); //= (TransformNodeItem[])Helper.Add(tn.Items, b);
				lb_tn.Items.Add(b);
				tn.Changed = true;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lb_tn.Tag = null;
			}
		}

		private void TNItemsDelete(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (Tag == null)
			{
				return;
			}

			if (lb_tn.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				lb_tn.Tag = true;
				Plugin.TransformNode tn = (Plugin.TransformNode)Tag;
				TransformNodeItem b = (TransformNodeItem)
					lb_tn.Items[lb_tn.SelectedIndex];

				tn.Items.Remove(b); // = (TransformNodeItem[])Helper.Delete(tn.Items, b);
				lb_tn.Items.Remove(b);
				tn.Changed = true;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lb_tn.Tag = null;
			}
		}
		#endregion


		/*private void LSettingsChanged(object sender, System.EventArgs e)
		{
			if (this.tDirectionalLight.Tag==null) return;
			try
			{
				DirectionalLight dl = (DirectionalLight)tDirectionalLight.Tag;

				dl.Version = Convert.ToUInt32(tb_l_ver.Text, 16);
				dl.Name = tb_l_name.Text;
				dl.Val1 = Convert.ToSingle(tb_l_1.Text);
				dl.Val2 = Convert.ToSingle(tb_l_2.Text);
				dl.Red = Convert.ToSingle(tb_l_3.Text);
				dl.Green = Convert.ToSingle(tb_l_4.Text);
				dl.Blue = Convert.ToSingle(tb_l_5.Text);

				if (tDirectionalLight.Tag.GetType() == typeof(PointLight))
				{
					PointLight pl = (PointLight)tDirectionalLight.Tag;

					pl.Val6 = Convert.ToSingle(tb_l_6.Text);
					pl.Val7 = Convert.ToSingle(tb_l_7.Text);
				}

				if (tDirectionalLight.Tag.GetType() == typeof(SpotLight))
				{
					SpotLight sl = (SpotLight)tDirectionalLight.Tag;

					sl.Val6 = Convert.ToSingle(tb_l_6.Text);
					sl.Val7 = Convert.ToSingle(tb_l_7.Text);
					sl.Val8 = Convert.ToSingle(tb_l_8.Text);
					sl.Val9 = Convert.ToSingle(tb_l_9.Text);
				}

				dl.Changed = true;
			}
			catch (Exception)
			{
				//Helper.ExceptionMessage("", ex);
			}
		}

		private void LTSettingsChanged(object sender, System.EventArgs e)
		{
			if (this.tLightT.Tag==null) return;
			try
			{
				LightT lt = (LightT)tLightT.Tag;

				lt.Version = Convert.ToUInt32(tb_lt_ver.Text, 16);
				lt.NameResource.FileName = tb_lt_name.Text;

				lt.Changed = true;
			}
			catch (Exception)
			{
				//Helper.ExceptionMessage("", ex);
			}
		}




		internal void ClearControlTags()
		{
			if (this.Controls==null) return;
			foreach (Control c in this.Controls)
				c.Tag = null;
		}*/
	}
}
