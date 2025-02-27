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
using System.Collections;
using System.IO;
using System.Windows.Forms;

using SimPe.Geometry;
using SimPe.Plugin.Gmdc;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for fGeometryDataContainer.
	/// </summary>
	internal class fGeometryDataContainer : Form
	{
		private TabControl tabControl1;
		private GroupBox groupBox10;
		internal TextBox tb_ver;
		private Label label28;
		internal System.Windows.Forms.TabPage tGeometryDataContainer;
		private GroupBox groupBox3;
		internal TextBox tb_uk5;
		private Label label10;
		private Label label7;
		private Label label8;
		private Label label5;
		internal TextBox tb_uk1;
		private Label label6;
		internal ListBox lb_itemsa;
		internal TextBox tb_mod2;
		internal TextBox tb_mod1;
		internal TextBox tb_id;
		private GroupBox groupBox1;
		internal ListBox lb_itemsa2;
		private Label label1;
		internal TextBox tb_itemsa2;
		internal System.Windows.Forms.TabPage tGeometryDataContainer2;
		internal System.Windows.Forms.TabPage tGeometryDataContainer3;
		private GroupBox groupBox2;
		internal ListBox lb_itemsc;
		internal TextBox tb_itemsc_name;
		private Label label11;
		internal TextBox tb_opacity;
		private Label label13;
		internal TextBox tb_uk3;
		private Label label2;
		internal TextBox tb_uk2;
		private Label label3;
		private GroupBox groupBox4;
		private Label label4;
		internal ListBox lb_itemsc2;
		private GroupBox groupBox5;
		private Label label9;
		internal ListBox lb_itemsc3;
		internal TextBox tb_itemsc2;
		internal TextBox tb_itemsc3;
		private GroupBox groupBox6;
		internal TextBox tb_itemsb2;
		private Label label14;
		internal ListBox lb_itemsb2;
		private GroupBox groupBox7;
		private Label label16;
		internal ListBox lb_itemsb;
		private Label label18;
		private GroupBox groupBox8;
		internal TextBox tb_itemsb3;
		private Label label19;
		internal ListBox lb_itemsb3;
		private GroupBox groupBox9;
		internal TextBox tb_itemsb4;
		private Label label15;
		internal ListBox lb_itemsb4;
		private GroupBox groupBox11;
		internal TextBox tb_itemsb5;
		private Label label17;
		internal ListBox lb_itemsb5;
		internal TextBox tb_uk4;
		internal TextBox tb_uk6;
		private SaveFileDialog sfd;
		private Button button3;
		internal CheckedListBox lbmodel;
		private Ambertation.Graphics.RenderSelection scenesel;
		private Button button4;
		private ColorDialog cd;
		internal System.Windows.Forms.TabPage tMesh;
		internal System.Windows.Forms.TabPage tAdvncd;
		private PropertyGrid pg;
		internal Label label_elements;
		internal ListBox list_elements;
		internal ListBox list_links;
		internal Label label_links;
		internal ListBox list_groups;
		internal Label label_groups;
		internal ListBox list_subsets;
		internal Label label_subsets;
		private LinkLabel linkLabel1;
		private Button button5;
		private ComboBox cbblock;
		private ComboBox cbset;
		private ComboBox cbid;
		private GroupBox groupBox12;
		internal ListBox lb_itemsa1;
		internal System.Windows.Forms.TabPage tSubset;
		private GroupBox groupBox13;
		private GroupBox groupBox14;
		private GroupBox groupBox15;
		internal ListBox lb_subsets;
		internal ListBox lb_sub_items;
		internal ListBox lb_sub_faces;
		internal System.Windows.Forms.TabPage tModel;
		private GroupBox groupBox16;
		private GroupBox groupBox17;
		private GroupBox groupBox18;
		private GroupBox groupBox19;
		internal ListBox lb_model_trans;
		internal ListBox lb_model_names;
		internal ListBox lb_model_faces;
		internal ListBox lb_model_items;
		private Button button1;
		private OpenFileDialog ofd;
		private LinkLabel linkLabel2;
		private LinkLabel linkLabel3;
		internal Label lb_models;
		private LinkLabel linkLabel4;
		private LinkLabel linkLabel5;
		private Label label12;
		private ComboBox cbaxis;
		private LinkLabel linkLabel6;
		private LinkLabel linkLabel7;
		private Ambertation.Graphics.DirectXPanel dxprev;
		private Label label21;
		internal ComboBox cbGroupJoint;
		private LinkLabel llAssign;
		private CheckBox cbCorrect;
		private LinkLabel llClearBB;
		private LinkLabel llAddBB;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		internal fGeometryDataContainer()
		{
			//
			// Required designer variable.
			//
			try
			{
				InitializeComponent();
				dxprev.Settings.AddAxis = false;
				dxprev.LoadSettings(Helper.SimPeViewportFile);
			}
			catch (FileNotFoundException)
			{
				WaitingScreen.Stop();
				MessageBox.Show(
					"The Microsoft Managed DirectX Extensions were not found on your System. Without them, the Preview is not available.\n\nYou can install them manually, by extracting the content of the DirectX\\ManagedDX.CAB on your Sims 2 Installation CD #1. If you double click on the extracted msi File, all needed Files will be installed.",
					"Warning",
					MessageBoxButtons.OK
				);
				InitializeComponent();
			}

			BlockFormat[] bls = (BlockFormat[])
				Enum.GetValues(typeof(BlockFormat));
			foreach (BlockFormat b in bls)
			{
				cbblock.Items.Add(b);
			}

			SetFormat[] sets = (SetFormat[])
				Enum.GetValues(typeof(SetFormat));
			foreach (SetFormat s in sets)
			{
				cbset.Items.Add(s);
			}

			ElementIdentity[] eis = (ElementIdentity[])
				Enum.GetValues(typeof(ElementIdentity));
			foreach (ElementIdentity e in eis)
			{
				cbid.Items.Add(e);
			}

			cbCorrect.Checked = Helper
				.WindowsRegistry
				.CorrectJointDefinitionOnExport;
			ElementSorting[] vs = (ElementSorting[])
				Enum.GetValues(typeof(ElementSorting));
			foreach (ElementSorting es in vs)
			{
				if (es == ElementSorting.Preview)
				{
					continue;
				}

				cbaxis.Items.Add(es);
				if (es == ElementSorting.XZY)
				{
					cbaxis.SelectedIndex = cbaxis.Items.Count - 1;
				}
			}

			if (
				DefaultSelectedAxisIndex >= 0
				&& DefaultSelectedAxisIndex < cbaxis.Items.Count
			)
			{
				cbaxis.SelectedIndex = DefaultSelectedAxisIndex;
			}

			if (Helper.WindowsRegistry.UseBigIcons)
			{
				lbmodel.Font = new System.Drawing.Font(
					"Microsoft Sans Serif",
					12F
				);
				lb_itemsa.Font = new System.Drawing.Font("Verdana", 12F);
				lb_itemsb.Font = new System.Drawing.Font("Verdana", 12F);
				lb_itemsc.Font = new System.Drawing.Font("Verdana", 12F);
				lb_model_trans.Font = new System.Drawing.Font("Verdana", 12F);
				lb_model_faces.Font = new System.Drawing.Font("Verdana", 12F);
				lb_subsets.Font = new System.Drawing.Font("Verdana", 12F);
			}
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
					typeof(fGeometryDataContainer)
				);
			tabControl1 = new TabControl();
			tGeometryDataContainer = new System.Windows.Forms.TabPage();
			groupBox1 = new GroupBox();
			tb_itemsa2 = new TextBox();
			label1 = new Label();
			lb_itemsa2 = new ListBox();
			groupBox3 = new GroupBox();
			cbid = new ComboBox();
			cbset = new ComboBox();
			cbblock = new ComboBox();
			lb_itemsa = new ListBox();
			tb_uk5 = new TextBox();
			label10 = new Label();
			tb_mod2 = new TextBox();
			label7 = new Label();
			tb_mod1 = new TextBox();
			label8 = new Label();
			tb_id = new TextBox();
			label5 = new Label();
			tb_uk1 = new TextBox();
			label6 = new Label();
			groupBox10 = new GroupBox();
			tb_ver = new TextBox();
			label28 = new Label();
			groupBox12 = new GroupBox();
			lb_itemsa1 = new ListBox();
			tAdvncd = new System.Windows.Forms.TabPage();
			linkLabel1 = new LinkLabel();
			list_subsets = new ListBox();
			label_subsets = new Label();
			list_groups = new ListBox();
			label_groups = new Label();
			list_links = new ListBox();
			label_links = new Label();
			list_elements = new ListBox();
			label_elements = new Label();
			pg = new PropertyGrid();
			tGeometryDataContainer3 = new System.Windows.Forms.TabPage();
			groupBox4 = new GroupBox();
			tb_itemsc2 = new TextBox();
			label4 = new Label();
			lb_itemsc2 = new ListBox();
			groupBox2 = new GroupBox();
			llAddBB = new LinkLabel();
			llAssign = new LinkLabel();
			cbGroupJoint = new ComboBox();
			label21 = new Label();
			linkLabel2 = new LinkLabel();
			tb_opacity = new TextBox();
			tb_uk2 = new TextBox();
			label3 = new Label();
			tb_uk3 = new TextBox();
			label2 = new Label();
			lb_itemsc = new ListBox();
			tb_itemsc_name = new TextBox();
			label11 = new Label();
			label13 = new Label();
			groupBox5 = new GroupBox();
			tb_itemsc3 = new TextBox();
			label9 = new Label();
			lb_itemsc3 = new ListBox();
			tMesh = new System.Windows.Forms.TabPage();
			cbCorrect = new CheckBox();
			dxprev = new Ambertation.Graphics.DirectXPanel();
			cbaxis = new ComboBox();
			label12 = new Label();
			button1 = new Button();
			button5 = new Button();
			scenesel = new Ambertation.Graphics.RenderSelection();
			lbmodel = new CheckedListBox();
			lb_models = new Label();
			button3 = new Button();
			button4 = new Button();
			tModel = new System.Windows.Forms.TabPage();
			groupBox19 = new GroupBox();
			lb_model_items = new ListBox();
			groupBox18 = new GroupBox();
			llClearBB = new LinkLabel();
			lb_model_faces = new ListBox();
			groupBox17 = new GroupBox();
			lb_model_names = new ListBox();
			groupBox16 = new GroupBox();
			linkLabel6 = new LinkLabel();
			lb_model_trans = new ListBox();
			tGeometryDataContainer2 = new System.Windows.Forms.TabPage();
			groupBox9 = new GroupBox();
			tb_itemsb4 = new TextBox();
			label15 = new Label();
			lb_itemsb4 = new ListBox();
			groupBox11 = new GroupBox();
			tb_itemsb5 = new TextBox();
			label17 = new Label();
			lb_itemsb5 = new ListBox();
			groupBox6 = new GroupBox();
			tb_itemsb2 = new TextBox();
			label14 = new Label();
			lb_itemsb2 = new ListBox();
			groupBox7 = new GroupBox();
			linkLabel7 = new LinkLabel();
			tb_uk4 = new TextBox();
			tb_uk6 = new TextBox();
			label16 = new Label();
			lb_itemsb = new ListBox();
			label18 = new Label();
			groupBox8 = new GroupBox();
			tb_itemsb3 = new TextBox();
			label19 = new Label();
			lb_itemsb3 = new ListBox();
			tSubset = new System.Windows.Forms.TabPage();
			groupBox13 = new GroupBox();
			lb_sub_items = new ListBox();
			groupBox14 = new GroupBox();
			lb_sub_faces = new ListBox();
			groupBox15 = new GroupBox();
			linkLabel5 = new LinkLabel();
			linkLabel4 = new LinkLabel();
			lb_subsets = new ListBox();
			sfd = new SaveFileDialog();
			cd = new ColorDialog();
			ofd = new OpenFileDialog();
			tabControl1.SuspendLayout();
			tGeometryDataContainer.SuspendLayout();
			groupBox1.SuspendLayout();
			groupBox3.SuspendLayout();
			groupBox10.SuspendLayout();
			groupBox12.SuspendLayout();
			tAdvncd.SuspendLayout();
			tGeometryDataContainer3.SuspendLayout();
			groupBox4.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox5.SuspendLayout();
			tMesh.SuspendLayout();
			tModel.SuspendLayout();
			groupBox19.SuspendLayout();
			groupBox18.SuspendLayout();
			groupBox17.SuspendLayout();
			groupBox16.SuspendLayout();
			tGeometryDataContainer2.SuspendLayout();
			groupBox9.SuspendLayout();
			groupBox11.SuspendLayout();
			groupBox6.SuspendLayout();
			groupBox7.SuspendLayout();
			groupBox8.SuspendLayout();
			tSubset.SuspendLayout();
			groupBox13.SuspendLayout();
			groupBox14.SuspendLayout();
			groupBox15.SuspendLayout();
			SuspendLayout();
			//
			// tabControl1
			//
			tabControl1.Controls.Add(tGeometryDataContainer);
			tabControl1.Controls.Add(tAdvncd);
			tabControl1.Controls.Add(tGeometryDataContainer3);
			tabControl1.Controls.Add(tMesh);
			tabControl1.Controls.Add(tModel);
			tabControl1.Controls.Add(tGeometryDataContainer2);
			tabControl1.Controls.Add(tSubset);
			tabControl1.Location = new System.Drawing.Point(36, -1);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new System.Drawing.Size(892, 328);
			tabControl1.TabIndex = 1;
			//
			// tGeometryDataContainer
			//
			tGeometryDataContainer.BackColor = System
				.Drawing
				.SystemColors
				.ControlLightLight;
			tGeometryDataContainer.Controls.Add(groupBox1);
			tGeometryDataContainer.Controls.Add(groupBox3);
			tGeometryDataContainer.Controls.Add(groupBox10);
			tGeometryDataContainer.Controls.Add(groupBox12);
			tGeometryDataContainer.Location = new System.Drawing.Point(4, 22);
			tGeometryDataContainer.Name = "tGeometryDataContainer";
			tGeometryDataContainer.Size = new System.Drawing.Size(884, 302);
			tGeometryDataContainer.TabIndex = 0;
			tGeometryDataContainer.Text = "Elements";
			tGeometryDataContainer.UseVisualStyleBackColor = true;
			//
			// groupBox1
			//
			groupBox1.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)

			;
			groupBox1.Controls.Add(tb_itemsa2);
			groupBox1.Controls.Add(label1);
			groupBox1.Controls.Add(lb_itemsa2);
			groupBox1.FlatStyle = FlatStyle.System;
			groupBox1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox1.Location = new System.Drawing.Point(612, 152);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(264, 136);
			groupBox1.TabIndex = 14;
			groupBox1.TabStop = false;
			groupBox1.Text = "Element Section - Items";
			//
			// tb_itemsa2
			//
			tb_itemsa2.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			tb_itemsa2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_itemsa2.Location = new System.Drawing.Point(56, 104);
			tb_itemsa2.Name = "tb_itemsa2";
			tb_itemsa2.ReadOnly = true;
			tb_itemsa2.Size = new System.Drawing.Size(88, 21);
			tb_itemsa2.TabIndex = 24;
			tb_itemsa2.Text = "0x00000000";
			//
			// label1
			//
			label1.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label1.Location = new System.Drawing.Point(8, 112);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(43, 13);
			label1.TabIndex = 23;
			label1.Text = "Value:";
			//
			// lb_itemsa2
			//
			lb_itemsa2.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			lb_itemsa2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lb_itemsa2.HorizontalScrollbar = true;
			lb_itemsa2.IntegralHeight = false;
			lb_itemsa2.Location = new System.Drawing.Point(8, 24);
			lb_itemsa2.Name = "lb_itemsa2";
			lb_itemsa2.Size = new System.Drawing.Size(248, 72);
			lb_itemsa2.TabIndex = 22;
			lb_itemsa2.SelectedIndexChanged += new EventHandler(
				SelectItemsA2
			);
			//
			// groupBox3
			//
			groupBox3.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			groupBox3.Controls.Add(cbid);
			groupBox3.Controls.Add(cbset);
			groupBox3.Controls.Add(cbblock);
			groupBox3.Controls.Add(lb_itemsa);
			groupBox3.Controls.Add(tb_uk5);
			groupBox3.Controls.Add(label10);
			groupBox3.Controls.Add(tb_mod2);
			groupBox3.Controls.Add(label7);
			groupBox3.Controls.Add(tb_mod1);
			groupBox3.Controls.Add(label8);
			groupBox3.Controls.Add(tb_id);
			groupBox3.Controls.Add(label5);
			groupBox3.Controls.Add(tb_uk1);
			groupBox3.Controls.Add(label6);
			groupBox3.FlatStyle = FlatStyle.System;
			groupBox3.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox3.Location = new System.Drawing.Point(8, 88);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(596, 200);
			groupBox3.TabIndex = 13;
			groupBox3.TabStop = false;
			groupBox3.Text = "Element Section";
			//
			// cbid
			//
			cbid.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			cbid.DropDownStyle = ComboBoxStyle.DropDownList;
			cbid.Enabled = false;
			cbid.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbid.Location = new System.Drawing.Point(364, 80);
			cbid.Name = "cbid";
			cbid.Size = new System.Drawing.Size(224, 21);
			cbid.TabIndex = 24;
			//
			// cbset
			//
			cbset.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			cbset.DropDownStyle = ComboBoxStyle.DropDownList;
			cbset.Enabled = false;
			cbset.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbset.Location = new System.Drawing.Point(364, 160);
			cbset.Name = "cbset";
			cbset.Size = new System.Drawing.Size(224, 21);
			cbset.TabIndex = 23;
			//
			// cbblock
			//
			cbblock.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			cbblock.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbblock.Enabled = false;
			cbblock.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbblock.Location = new System.Drawing.Point(364, 120);
			cbblock.Name = "cbblock";
			cbblock.Size = new System.Drawing.Size(224, 21);
			cbblock.TabIndex = 22;
			//
			// lb_itemsa
			//
			lb_itemsa.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			lb_itemsa.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lb_itemsa.HorizontalScrollbar = true;
			lb_itemsa.IntegralHeight = false;
			lb_itemsa.Location = new System.Drawing.Point(8, 24);
			lb_itemsa.Name = "lb_itemsa";
			lb_itemsa.Size = new System.Drawing.Size(244, 168);
			lb_itemsa.TabIndex = 21;
			lb_itemsa.SelectedIndexChanged += new EventHandler(
				SelectItemsA
			);
			//
			// tb_uk5
			//
			tb_uk5.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			tb_uk5.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_uk5.Location = new System.Drawing.Point(372, 40);
			tb_uk5.Name = "tb_uk5";
			tb_uk5.ReadOnly = true;
			tb_uk5.Size = new System.Drawing.Size(88, 21);
			tb_uk5.TabIndex = 14;
			tb_uk5.Text = "0x00000000";
			//
			// label10
			//
			label10.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label10.Location = new System.Drawing.Point(364, 24);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(73, 13);
			label10.TabIndex = 13;
			label10.Text = "Group UID:";
			//
			// tb_mod2
			//
			tb_mod2.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			tb_mod2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_mod2.Location = new System.Drawing.Point(268, 160);
			tb_mod2.Name = "tb_mod2";
			tb_mod2.ReadOnly = true;
			tb_mod2.Size = new System.Drawing.Size(88, 21);
			tb_mod2.TabIndex = 12;
			tb_mod2.Text = "0x00";
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
			label7.Location = new System.Drawing.Point(260, 144);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(75, 13);
			label7.TabIndex = 11;
			label7.Text = "Set Format:";
			//
			// tb_mod1
			//
			tb_mod1.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			tb_mod1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_mod1.Location = new System.Drawing.Point(268, 120);
			tb_mod1.Name = "tb_mod1";
			tb_mod1.ReadOnly = true;
			tb_mod1.Size = new System.Drawing.Size(88, 21);
			tb_mod1.TabIndex = 10;
			tb_mod1.Text = "0x00000000";
			//
			// label8
			//
			label8.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label8.Location = new System.Drawing.Point(260, 104);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(87, 13);
			label8.TabIndex = 9;
			label8.Text = "Block Format:";
			//
			// tb_id
			//
			tb_id.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			tb_id.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_id.Location = new System.Drawing.Point(268, 80);
			tb_id.Name = "tb_id";
			tb_id.ReadOnly = true;
			tb_id.Size = new System.Drawing.Size(88, 21);
			tb_id.TabIndex = 8;
			tb_id.Text = "0x00000000";
			//
			// label5
			//
			label5.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label5.Location = new System.Drawing.Point(260, 64);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(56, 13);
			label5.TabIndex = 7;
			label5.Text = "Identity:";
			//
			// tb_uk1
			//
			tb_uk1.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			tb_uk1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_uk1.Location = new System.Drawing.Point(268, 40);
			tb_uk1.Name = "tb_uk1";
			tb_uk1.ReadOnly = true;
			tb_uk1.Size = new System.Drawing.Size(88, 21);
			tb_uk1.TabIndex = 6;
			tb_uk1.Text = "0x0000";
			//
			// label6
			//
			label6.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label6.Location = new System.Drawing.Point(260, 24);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(57, 13);
			label6.TabIndex = 5;
			label6.Text = "Number:";
			//
			// groupBox10
			//
			groupBox10.Controls.Add(tb_ver);
			groupBox10.Controls.Add(label28);
			groupBox10.FlatStyle = FlatStyle.System;
			groupBox10.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox10.Location = new System.Drawing.Point(8, 8);
			groupBox10.Name = "groupBox10";
			groupBox10.Size = new System.Drawing.Size(120, 72);
			groupBox10.TabIndex = 12;
			groupBox10.TabStop = false;
			groupBox10.Text = "Settings";
			//
			// tb_ver
			//
			tb_ver.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_ver.Location = new System.Drawing.Point(16, 40);
			tb_ver.Name = "tb_ver";
			tb_ver.Size = new System.Drawing.Size(88, 21);
			tb_ver.TabIndex = 24;
			tb_ver.Text = "0x00000000";
			tb_ver.TextChanged += new EventHandler(SettingsChange);
			//
			// label28
			//
			label28.AutoSize = true;
			label28.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label28.Location = new System.Drawing.Point(8, 24);
			label28.Name = "label28";
			label28.Size = new System.Drawing.Size(54, 13);
			label28.TabIndex = 23;
			label28.Text = "Version:";
			//
			// groupBox12
			//
			groupBox12.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Bottom
						) | AnchorStyles.Right
					)

			;
			groupBox12.Controls.Add(lb_itemsa1);
			groupBox12.FlatStyle = FlatStyle.System;
			groupBox12.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox12.Location = new System.Drawing.Point(612, 8);
			groupBox12.Name = "groupBox12";
			groupBox12.Size = new System.Drawing.Size(264, 136);
			groupBox12.TabIndex = 25;
			groupBox12.TabStop = false;
			groupBox12.Text = "Element Section - Values";
			//
			// lb_itemsa1
			//
			lb_itemsa1.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			lb_itemsa1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lb_itemsa1.HorizontalScrollbar = true;
			lb_itemsa1.IntegralHeight = false;
			lb_itemsa1.Location = new System.Drawing.Point(8, 24);
			lb_itemsa1.Name = "lb_itemsa1";
			lb_itemsa1.Size = new System.Drawing.Size(248, 104);
			lb_itemsa1.TabIndex = 22;
			//
			// tAdvncd
			//
			tAdvncd.BackColor = System.Drawing.SystemColors.ControlLightLight;
			tAdvncd.Controls.Add(linkLabel1);
			tAdvncd.Controls.Add(list_subsets);
			tAdvncd.Controls.Add(label_subsets);
			tAdvncd.Controls.Add(list_groups);
			tAdvncd.Controls.Add(label_groups);
			tAdvncd.Controls.Add(list_links);
			tAdvncd.Controls.Add(label_links);
			tAdvncd.Controls.Add(list_elements);
			tAdvncd.Controls.Add(label_elements);
			tAdvncd.Controls.Add(pg);
			tAdvncd.Location = new System.Drawing.Point(4, 22);
			tAdvncd.Name = "tAdvncd";
			tAdvncd.Size = new System.Drawing.Size(884, 302);
			tAdvncd.TabIndex = 5;
			tAdvncd.Text = "Advanced";
			tAdvncd.UseVisualStyleBackColor = true;
			//
			// linkLabel1
			//
			linkLabel1.Location = new System.Drawing.Point(296, 128);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(40, 16);
			linkLabel1.TabIndex = 9;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "Model";
			linkLabel1.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					SeletAdvncdObject
				);
			//
			// list_subsets
			//
			list_subsets.Location = new System.Drawing.Point(296, 24);
			list_subsets.Name = "list_subsets";
			list_subsets.Size = new System.Drawing.Size(264, 95);
			list_subsets.TabIndex = 8;
			list_subsets.SelectedIndexChanged += new EventHandler(
				SeletAdvncdObject
			);
			//
			// label_subsets
			//
			label_subsets.AutoSize = true;
			label_subsets.Location = new System.Drawing.Point(288, 8);
			label_subsets.Name = "label_subsets";
			label_subsets.Size = new System.Drawing.Size(48, 13);
			label_subsets.TabIndex = 7;
			label_subsets.Text = "Subsets:";
			//
			// list_groups
			//
			list_groups.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Bottom
						) | AnchorStyles.Left
					)

			;
			list_groups.Location = new System.Drawing.Point(16, 224);
			list_groups.Name = "list_groups";
			list_groups.Size = new System.Drawing.Size(264, 69);
			list_groups.TabIndex = 6;
			list_groups.SelectedIndexChanged += new EventHandler(
				SeletAdvncdObject
			);
			//
			// label_groups
			//
			label_groups.AutoSize = true;
			label_groups.Location = new System.Drawing.Point(8, 208);
			label_groups.Name = "label_groups";
			label_groups.Size = new System.Drawing.Size(44, 13);
			label_groups.TabIndex = 5;
			label_groups.Text = "Groups:";
			//
			// list_links
			//
			list_links.Location = new System.Drawing.Point(16, 136);
			list_links.Name = "list_links";
			list_links.Size = new System.Drawing.Size(264, 69);
			list_links.TabIndex = 4;
			list_links.SelectedIndexChanged += new EventHandler(
				SeletAdvncdObject
			);
			//
			// label_links
			//
			label_links.AutoSize = true;
			label_links.Location = new System.Drawing.Point(8, 120);
			label_links.Name = "label_links";
			label_links.Size = new System.Drawing.Size(35, 13);
			label_links.TabIndex = 3;
			label_links.Text = "Links:";
			//
			// list_elements
			//
			list_elements.Location = new System.Drawing.Point(16, 24);
			list_elements.Name = "list_elements";
			list_elements.Size = new System.Drawing.Size(264, 95);
			list_elements.TabIndex = 2;
			list_elements.SelectedIndexChanged += new EventHandler(
				SeletAdvncdObject
			);
			//
			// label_elements
			//
			label_elements.AutoSize = true;
			label_elements.Location = new System.Drawing.Point(8, 8);
			label_elements.Name = "label_elements";
			label_elements.Size = new System.Drawing.Size(53, 13);
			label_elements.TabIndex = 1;
			label_elements.Text = "Elements:";
			//
			// pg
			//
			pg.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			pg.CommandsBackColor = System.Drawing.SystemColors.ControlLightLight;
			pg.HelpVisible = false;
			pg.LineColor = System.Drawing.SystemColors.ScrollBar;
			pg.Location = new System.Drawing.Point(560, 8);
			pg.Name = "pg";
			pg.Size = new System.Drawing.Size(316, 288);
			pg.TabIndex = 0;
			pg.ToolbarVisible = false;
			//
			// tGeometryDataContainer3
			//
			tGeometryDataContainer3.BackColor = System
				.Drawing
				.SystemColors
				.ControlLightLight;
			tGeometryDataContainer3.Controls.Add(groupBox4);
			tGeometryDataContainer3.Controls.Add(groupBox2);
			tGeometryDataContainer3.Controls.Add(groupBox5);
			tGeometryDataContainer3.Location = new System.Drawing.Point(4, 22);
			tGeometryDataContainer3.Name = "tGeometryDataContainer3";
			tGeometryDataContainer3.Size = new System.Drawing.Size(884, 302);
			tGeometryDataContainer3.TabIndex = 2;
			tGeometryDataContainer3.Text = "Groups";
			tGeometryDataContainer3.UseVisualStyleBackColor = true;
			//
			// groupBox4
			//
			groupBox4.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			groupBox4.Controls.Add(tb_itemsc2);
			groupBox4.Controls.Add(label4);
			groupBox4.Controls.Add(lb_itemsc2);
			groupBox4.FlatStyle = FlatStyle.System;
			groupBox4.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox4.Location = new System.Drawing.Point(612, 8);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new System.Drawing.Size(264, 136);
			groupBox4.TabIndex = 15;
			groupBox4.TabStop = false;
			groupBox4.Text = "Group Section - Faces";
			//
			// tb_itemsc2
			//
			tb_itemsc2.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			tb_itemsc2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_itemsc2.Location = new System.Drawing.Point(56, 104);
			tb_itemsc2.Name = "tb_itemsc2";
			tb_itemsc2.ReadOnly = true;
			tb_itemsc2.Size = new System.Drawing.Size(88, 21);
			tb_itemsc2.TabIndex = 24;
			tb_itemsc2.Text = "0x00000000";
			//
			// label4
			//
			label4.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label4.Location = new System.Drawing.Point(8, 112);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(43, 13);
			label4.TabIndex = 23;
			label4.Text = "Value:";
			//
			// lb_itemsc2
			//
			lb_itemsc2.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			lb_itemsc2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lb_itemsc2.HorizontalScrollbar = true;
			lb_itemsc2.IntegralHeight = false;
			lb_itemsc2.Location = new System.Drawing.Point(8, 24);
			lb_itemsc2.Name = "lb_itemsc2";
			lb_itemsc2.Size = new System.Drawing.Size(248, 72);
			lb_itemsc2.TabIndex = 22;
			lb_itemsc2.SelectedIndexChanged += new EventHandler(
				SelectItemsC2
			);
			//
			// groupBox2
			//
			groupBox2.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			groupBox2.Controls.Add(llAddBB);
			groupBox2.Controls.Add(llAssign);
			groupBox2.Controls.Add(cbGroupJoint);
			groupBox2.Controls.Add(label21);
			groupBox2.Controls.Add(linkLabel2);
			groupBox2.Controls.Add(tb_opacity);
			groupBox2.Controls.Add(tb_uk2);
			groupBox2.Controls.Add(label3);
			groupBox2.Controls.Add(tb_uk3);
			groupBox2.Controls.Add(label2);
			groupBox2.Controls.Add(lb_itemsc);
			groupBox2.Controls.Add(tb_itemsc_name);
			groupBox2.Controls.Add(label11);
			groupBox2.Controls.Add(label13);
			groupBox2.FlatStyle = FlatStyle.System;
			groupBox2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox2.Location = new System.Drawing.Point(8, 8);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(596, 288);
			groupBox2.TabIndex = 14;
			groupBox2.TabStop = false;
			groupBox2.Text = "Group Section";
			//
			// llAddBB
			//
			llAddBB.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			llAddBB.LinkArea = new LinkArea(0, 20);
			llAddBB.Location = new System.Drawing.Point(268, 128);
			llAddBB.Name = "llAddBB";
			llAddBB.Size = new System.Drawing.Size(236, 23);
			llAddBB.TabIndex = 30;
			llAddBB.TabStop = true;
			llAddBB.Text = "Add to Bounding Mesh (by Pinhead)";
			llAddBB.UseCompatibleTextRendering = true;
			llAddBB.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					llAddBB_LinkClicked
				);
			//
			// llAssign
			//
			llAssign.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			llAssign.LinkArea = new LinkArea(0, 6);
			llAssign.Location = new System.Drawing.Point(456, 208);
			llAssign.Name = "llAssign";
			llAssign.Size = new System.Drawing.Size(120, 23);
			llAssign.TabIndex = 29;
			llAssign.TabStop = true;
			llAssign.Text = "Assign to Joint";
			llAssign.TextAlign = System.Drawing.ContentAlignment.TopRight;
			llAssign.UseCompatibleTextRendering = true;
			llAssign.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					llAssign_LinkClicked
				);
			//
			// cbGroupJoint
			//
			cbGroupJoint.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			cbGroupJoint.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbGroupJoint.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbGroupJoint.Location = new System.Drawing.Point(272, 184);
			cbGroupJoint.Name = "cbGroupJoint";
			cbGroupJoint.Size = new System.Drawing.Size(304, 21);
			cbGroupJoint.TabIndex = 28;
			//
			// label21
			//
			label21.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			label21.AutoSize = true;
			label21.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label21.Location = new System.Drawing.Point(264, 168);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(44, 13);
			label21.TabIndex = 27;
			label21.Text = "Joints:";
			//
			// linkLabel2
			//
			linkLabel2.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			linkLabel2.Location = new System.Drawing.Point(268, 112);
			linkLabel2.Name = "linkLabel2";
			linkLabel2.Size = new System.Drawing.Size(48, 23);
			linkLabel2.TabIndex = 26;
			linkLabel2.TabStop = true;
			linkLabel2.Text = "Delete";
			linkLabel2.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					linkLabel2_LinkClicked
				);
			//
			// tb_opacity
			//
			tb_opacity.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			tb_opacity.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_opacity.Location = new System.Drawing.Point(492, 40);
			tb_opacity.Name = "tb_opacity";
			tb_opacity.Size = new System.Drawing.Size(88, 21);
			tb_opacity.TabIndex = 6;
			tb_opacity.Text = "0x00000000";
			tb_opacity.TextChanged += new EventHandler(ChangeItemsC);
			//
			// tb_uk2
			//
			tb_uk2.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			tb_uk2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_uk2.Location = new System.Drawing.Point(268, 40);
			tb_uk2.Name = "tb_uk2";
			tb_uk2.Size = new System.Drawing.Size(88, 21);
			tb_uk2.TabIndex = 25;
			tb_uk2.Text = "0x00000000";
			tb_uk2.TextChanged += new EventHandler(ChangeItemsC);
			//
			// label3
			//
			label3.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label3.Location = new System.Drawing.Point(484, 24);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(55, 13);
			label3.TabIndex = 24;
			label3.Text = "Opacity:";
			//
			// tb_uk3
			//
			tb_uk3.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			tb_uk3.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_uk3.Location = new System.Drawing.Point(380, 40);
			tb_uk3.Name = "tb_uk3";
			tb_uk3.Size = new System.Drawing.Size(88, 21);
			tb_uk3.TabIndex = 23;
			tb_uk3.Text = "0x00000000";
			tb_uk3.TextChanged += new EventHandler(ChangeItemsC);
			//
			// label2
			//
			label2.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label2.Location = new System.Drawing.Point(372, 24);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(97, 13);
			label2.TabIndex = 22;
			label2.Text = "Link Reference:";
			//
			// lb_itemsc
			//
			lb_itemsc.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			lb_itemsc.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lb_itemsc.HorizontalScrollbar = true;
			lb_itemsc.IntegralHeight = false;
			lb_itemsc.Location = new System.Drawing.Point(8, 24);
			lb_itemsc.Name = "lb_itemsc";
			lb_itemsc.Size = new System.Drawing.Size(244, 256);
			lb_itemsc.TabIndex = 21;
			lb_itemsc.SelectedIndexChanged += new EventHandler(
				SelectItemsC
			);
			//
			// tb_itemsc_name
			//
			tb_itemsc_name.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			tb_itemsc_name.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_itemsc_name.Location = new System.Drawing.Point(268, 80);
			tb_itemsc_name.Name = "tb_itemsc_name";
			tb_itemsc_name.Size = new System.Drawing.Size(312, 21);
			tb_itemsc_name.TabIndex = 8;
			tb_itemsc_name.TextChanged += new EventHandler(
				ChangeItemsC
			);
			//
			// label11
			//
			label11.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			label11.AutoSize = true;
			label11.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label11.Location = new System.Drawing.Point(260, 64);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(45, 13);
			label11.TabIndex = 7;
			label11.Text = "Name:";
			//
			// label13
			//
			label13.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			label13.AutoSize = true;
			label13.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label13.Location = new System.Drawing.Point(260, 24);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(73, 13);
			label13.TabIndex = 5;
			label13.Text = "Prim. Type:";
			//
			// groupBox5
			//
			groupBox5.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Bottom
						) | AnchorStyles.Right
					)

			;
			groupBox5.Controls.Add(tb_itemsc3);
			groupBox5.Controls.Add(label9);
			groupBox5.Controls.Add(lb_itemsc3);
			groupBox5.FlatStyle = FlatStyle.System;
			groupBox5.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox5.Location = new System.Drawing.Point(612, 152);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new System.Drawing.Size(264, 144);
			groupBox5.TabIndex = 25;
			groupBox5.TabStop = false;
			groupBox5.Text = "Group Section - Used Joints";
			//
			// tb_itemsc3
			//
			tb_itemsc3.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			tb_itemsc3.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_itemsc3.Location = new System.Drawing.Point(56, 112);
			tb_itemsc3.Name = "tb_itemsc3";
			tb_itemsc3.ReadOnly = true;
			tb_itemsc3.Size = new System.Drawing.Size(88, 21);
			tb_itemsc3.TabIndex = 24;
			tb_itemsc3.Text = "0x00000000";
			//
			// label9
			//
			label9.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label9.Location = new System.Drawing.Point(8, 120);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(43, 13);
			label9.TabIndex = 23;
			label9.Text = "Value:";
			//
			// lb_itemsc3
			//
			lb_itemsc3.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			lb_itemsc3.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lb_itemsc3.HorizontalScrollbar = true;
			lb_itemsc3.IntegralHeight = false;
			lb_itemsc3.Location = new System.Drawing.Point(8, 24);
			lb_itemsc3.Name = "lb_itemsc3";
			lb_itemsc3.Size = new System.Drawing.Size(248, 80);
			lb_itemsc3.TabIndex = 22;
			lb_itemsc3.SelectedIndexChanged += new EventHandler(
				SelectItemsC3
			);
			//
			// tMesh
			//
			tMesh.BackColor = System.Drawing.SystemColors.ControlLightLight;
			tMesh.Controls.Add(cbCorrect);
			tMesh.Controls.Add(dxprev);
			tMesh.Controls.Add(cbaxis);
			tMesh.Controls.Add(label12);
			tMesh.Controls.Add(button1);
			tMesh.Controls.Add(button5);
			tMesh.Controls.Add(scenesel);
			tMesh.Controls.Add(lbmodel);
			tMesh.Controls.Add(lb_models);
			tMesh.Controls.Add(button3);
			tMesh.Controls.Add(button4);
			tMesh.Location = new System.Drawing.Point(4, 22);
			tMesh.Name = "tMesh";
			tMesh.Size = new System.Drawing.Size(884, 302);
			tMesh.TabIndex = 4;
			tMesh.Text = "3D Mesh";
			tMesh.UseVisualStyleBackColor = true;
			tMesh.SizeChanged += new EventHandler(dxprev_SizeChanged);
			//
			// cbCorrect
			//
			cbCorrect.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			cbCorrect.Location = new System.Drawing.Point(272, 264);
			cbCorrect.Name = "cbCorrect";
			cbCorrect.Size = new System.Drawing.Size(96, 32);
			cbCorrect.TabIndex = 32;
			cbCorrect.Text = "Correct Joint definition";
			cbCorrect.CheckedChanged += new EventHandler(
				cbCorrect_CheckedChanged
			);
			//
			// dxprev
			//
			dxprev.BackColor = System.Drawing.Color.FromArgb(
				((byte)(128)),
				((byte)(128)),
				((byte)(255))
			);
			dxprev.Effect = null;
			dxprev.Location = new System.Drawing.Point(376, 8);
			dxprev.Name = "dxprev";
			dxprev.Size = new System.Drawing.Size(304, 288);
			dxprev.TabIndex = 31;
			dxprev.WorldMatrix = (
				(Microsoft.DirectX.Matrix)(resources.GetObject("dxprev.WorldMatrix"))
			);
			dxprev.ResetDevice += new EventHandler(dxprev_ResetDevice);
			//
			// cbaxis
			//
			cbaxis.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			cbaxis.DropDownStyle = ComboBoxStyle.DropDownList;
			cbaxis.Location = new System.Drawing.Point(272, 240);
			cbaxis.Name = "cbaxis";
			cbaxis.Size = new System.Drawing.Size(96, 21);
			cbaxis.TabIndex = 30;
			cbaxis.SelectedIndexChanged += new EventHandler(
				ChangedAxis
			);
			//
			// label12
			//
			label12.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			label12.Font = new System.Drawing.Font(
				"Microsoft Sans Serif",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label12.Location = new System.Drawing.Point(216, 240);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(48, 20);
			label12.TabIndex = 29;
			label12.Text = "Order:";
			label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			//
			// button1
			//
			button1.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			button1.FlatStyle = FlatStyle.System;
			button1.Location = new System.Drawing.Point(110, 240);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(78, 23);
			button1.TabIndex = 28;
			button1.Text = "Import...";
			button1.Click += new EventHandler(button1_Click);
			//
			// button5
			//
			button5.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			button5.FlatStyle = FlatStyle.System;
			button5.Location = new System.Drawing.Point(16, 240);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(78, 23);
			button5.TabIndex = 27;
			button5.Text = "Export...";
			button5.Click += new EventHandler(Export);
			//
			// scenesel
			//
			scenesel.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Bottom
						) | AnchorStyles.Right
					)

			;
			scenesel.DirectXPanel = dxprev;
			scenesel.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			scenesel.ForeColor = System.Drawing.SystemColors.ControlDark;
			scenesel.Location = new System.Drawing.Point(688, 8);
			scenesel.Name = "scenesel";
			scenesel.Scene = null;
			scenesel.Size = new System.Drawing.Size(184, 288);
			scenesel.TabIndex = 25;
			//
			// lbmodel
			//
			lbmodel.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Bottom
						) | AnchorStyles.Left
					)

			;
			lbmodel.CheckOnClick = true;
			lbmodel.HorizontalScrollbar = true;
			lbmodel.Location = new System.Drawing.Point(16, 24);
			lbmodel.Name = "lbmodel";
			lbmodel.Size = new System.Drawing.Size(352, 214);
			lbmodel.TabIndex = 24;
			//
			// lb_models
			//
			lb_models.AutoSize = true;
			lb_models.Font = new System.Drawing.Font(
				"Microsoft Sans Serif",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lb_models.Location = new System.Drawing.Point(8, 8);
			lb_models.Name = "lb_models";
			lb_models.Size = new System.Drawing.Size(51, 13);
			lb_models.TabIndex = 23;
			lb_models.Text = "Models:";
			//
			// button3
			//
			button3.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			button3.FlatStyle = FlatStyle.System;
			button3.Location = new System.Drawing.Point(16, 272);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(172, 23);
			button3.TabIndex = 4;
			button3.Text = "Preview";
			button3.Click += new EventHandler(Preview);
			//
			// button4
			//
			button4.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			button4.FlatStyle = FlatStyle.System;
			button4.Location = new System.Drawing.Point(219, 272);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(32, 23);
			button4.TabIndex = 26;
			button4.Text = "BG";
			button4.Click += new EventHandler(PickColor);
			//
			// tModel
			//
			tModel.BackColor = System.Drawing.SystemColors.ControlLightLight;
			tModel.Controls.Add(groupBox19);
			tModel.Controls.Add(groupBox18);
			tModel.Controls.Add(groupBox17);
			tModel.Controls.Add(groupBox16);
			tModel.Location = new System.Drawing.Point(4, 22);
			tModel.Name = "tModel";
			tModel.Size = new System.Drawing.Size(884, 302);
			tModel.TabIndex = 7;
			tModel.Text = "Model";
			tModel.UseVisualStyleBackColor = true;
			//
			// groupBox19
			//
			groupBox19.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)

			;
			groupBox19.Controls.Add(lb_model_items);
			groupBox19.FlatStyle = FlatStyle.System;
			groupBox19.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox19.Location = new System.Drawing.Point(648, 200);
			groupBox19.Name = "groupBox19";
			groupBox19.Size = new System.Drawing.Size(224, 96);
			groupBox19.TabIndex = 35;
			groupBox19.TabStop = false;
			groupBox19.Text = "Bounding Mesh Control  - Faces";
			//
			// lb_model_items
			//
			lb_model_items.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			lb_model_items.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lb_model_items.HorizontalScrollbar = true;
			lb_model_items.IntegralHeight = false;
			lb_model_items.Location = new System.Drawing.Point(8, 24);
			lb_model_items.Name = "lb_model_items";
			lb_model_items.Size = new System.Drawing.Size(208, 64);
			lb_model_items.TabIndex = 22;
			//
			// groupBox18
			//
			groupBox18.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			groupBox18.Controls.Add(llClearBB);
			groupBox18.Controls.Add(lb_model_faces);
			groupBox18.FlatStyle = FlatStyle.System;
			groupBox18.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox18.Location = new System.Drawing.Point(584, 8);
			groupBox18.Name = "groupBox18";
			groupBox18.Size = new System.Drawing.Size(292, 184);
			groupBox18.TabIndex = 34;
			groupBox18.TabStop = false;
			groupBox18.Text = "Bounding Mesh Control - Vertices";
			//
			// llClearBB
			//
			llClearBB.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			llClearBB.AutoSize = true;
			llClearBB.Location = new System.Drawing.Point(247, 0);
			llClearBB.Name = "llClearBB";
			llClearBB.Size = new System.Drawing.Size(41, 13);
			llClearBB.TabIndex = 24;
			llClearBB.TabStop = true;
			llClearBB.Text = "Clear";
			llClearBB.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					llClearBB_LinkClicked
				);
			//
			// lb_model_faces
			//
			lb_model_faces.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			lb_model_faces.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lb_model_faces.HorizontalScrollbar = true;
			lb_model_faces.IntegralHeight = false;
			lb_model_faces.Location = new System.Drawing.Point(8, 24);
			lb_model_faces.Name = "lb_model_faces";
			lb_model_faces.Size = new System.Drawing.Size(276, 152);
			lb_model_faces.TabIndex = 22;
			//
			// groupBox17
			//
			groupBox17.Anchor =

					(
						(
							AnchorStyles.Bottom
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			groupBox17.Controls.Add(lb_model_names);
			groupBox17.FlatStyle = FlatStyle.System;
			groupBox17.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox17.Location = new System.Drawing.Point(8, 200);
			groupBox17.Name = "groupBox17";
			groupBox17.Size = new System.Drawing.Size(632, 96);
			groupBox17.TabIndex = 33;
			groupBox17.TabStop = false;
			groupBox17.Text = "Model Section - Names";
			//
			// lb_model_names
			//
			lb_model_names.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			lb_model_names.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lb_model_names.HorizontalScrollbar = true;
			lb_model_names.IntegralHeight = false;
			lb_model_names.Location = new System.Drawing.Point(8, 24);
			lb_model_names.Name = "lb_model_names";
			lb_model_names.Size = new System.Drawing.Size(616, 64);
			lb_model_names.TabIndex = 22;
			//
			// groupBox16
			//
			groupBox16.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Bottom
						) | AnchorStyles.Left
					)

			;
			groupBox16.Controls.Add(linkLabel6);
			groupBox16.Controls.Add(lb_model_trans);
			groupBox16.FlatStyle = FlatStyle.System;
			groupBox16.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox16.Location = new System.Drawing.Point(8, 8);
			groupBox16.Name = "groupBox16";
			groupBox16.Size = new System.Drawing.Size(568, 184);
			groupBox16.TabIndex = 32;
			groupBox16.TabStop = false;
			groupBox16.Text = "Model Section - Transformations";
			//
			// linkLabel6
			//
			linkLabel6.AutoSize = true;
			linkLabel6.Location = new System.Drawing.Point(232, 0);
			linkLabel6.Name = "linkLabel6";
			linkLabel6.Size = new System.Drawing.Size(55, 13);
			linkLabel6.TabIndex = 23;
			linkLabel6.TabStop = true;
			linkLabel6.Text = "Rebuild";
			linkLabel6.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					RebuildAbsTransform
				);
			//
			// lb_model_trans
			//
			lb_model_trans.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Bottom
						) | AnchorStyles.Left
					)

			;
			lb_model_trans.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lb_model_trans.HorizontalScrollbar = true;
			lb_model_trans.IntegralHeight = false;
			lb_model_trans.Location = new System.Drawing.Point(8, 24);
			lb_model_trans.Name = "lb_model_trans";
			lb_model_trans.Size = new System.Drawing.Size(552, 152);
			lb_model_trans.TabIndex = 22;
			//
			// tGeometryDataContainer2
			//
			tGeometryDataContainer2.BackColor = System
				.Drawing
				.SystemColors
				.ControlLightLight;
			tGeometryDataContainer2.Controls.Add(groupBox9);
			tGeometryDataContainer2.Controls.Add(groupBox11);
			tGeometryDataContainer2.Controls.Add(groupBox6);
			tGeometryDataContainer2.Controls.Add(groupBox7);
			tGeometryDataContainer2.Controls.Add(groupBox8);
			tGeometryDataContainer2.Location = new System.Drawing.Point(4, 22);
			tGeometryDataContainer2.Name = "tGeometryDataContainer2";
			tGeometryDataContainer2.Size = new System.Drawing.Size(884, 302);
			tGeometryDataContainer2.TabIndex = 1;
			tGeometryDataContainer2.Text = "Links";
			tGeometryDataContainer2.UseVisualStyleBackColor = true;
			//
			// groupBox9
			//
			groupBox9.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			groupBox9.Controls.Add(tb_itemsb4);
			groupBox9.Controls.Add(label15);
			groupBox9.Controls.Add(lb_itemsb4);
			groupBox9.FlatStyle = FlatStyle.System;
			groupBox9.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox9.Location = new System.Drawing.Point(644, 8);
			groupBox9.Name = "groupBox9";
			groupBox9.Size = new System.Drawing.Size(232, 136);
			groupBox9.TabIndex = 29;
			groupBox9.TabStop = false;
			groupBox9.Text = "Link Section - Normal Alias";
			//
			// tb_itemsb4
			//
			tb_itemsb4.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			tb_itemsb4.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_itemsb4.Location = new System.Drawing.Point(56, 104);
			tb_itemsb4.Name = "tb_itemsb4";
			tb_itemsb4.ReadOnly = true;
			tb_itemsb4.Size = new System.Drawing.Size(88, 21);
			tb_itemsb4.TabIndex = 24;
			tb_itemsb4.Text = "0x00000000";
			//
			// label15
			//
			label15.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			label15.AutoSize = true;
			label15.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label15.Location = new System.Drawing.Point(8, 112);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(43, 13);
			label15.TabIndex = 23;
			label15.Text = "Value:";
			//
			// lb_itemsb4
			//
			lb_itemsb4.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			lb_itemsb4.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lb_itemsb4.HorizontalScrollbar = true;
			lb_itemsb4.IntegralHeight = false;
			lb_itemsb4.Location = new System.Drawing.Point(8, 24);
			lb_itemsb4.Name = "lb_itemsb4";
			lb_itemsb4.Size = new System.Drawing.Size(216, 72);
			lb_itemsb4.TabIndex = 22;
			lb_itemsb4.SelectedIndexChanged += new EventHandler(
				SelectItemsB4
			);
			//
			// groupBox11
			//
			groupBox11.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Bottom
						) | AnchorStyles.Right
					)

			;
			groupBox11.Controls.Add(tb_itemsb5);
			groupBox11.Controls.Add(label17);
			groupBox11.Controls.Add(lb_itemsb5);
			groupBox11.FlatStyle = FlatStyle.System;
			groupBox11.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox11.Location = new System.Drawing.Point(644, 152);
			groupBox11.Name = "groupBox11";
			groupBox11.Size = new System.Drawing.Size(232, 144);
			groupBox11.TabIndex = 30;
			groupBox11.TabStop = false;
			groupBox11.Text = "Link Section - UVCoord. Alias";
			//
			// tb_itemsb5
			//
			tb_itemsb5.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			tb_itemsb5.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_itemsb5.Location = new System.Drawing.Point(56, 112);
			tb_itemsb5.Name = "tb_itemsb5";
			tb_itemsb5.ReadOnly = true;
			tb_itemsb5.Size = new System.Drawing.Size(88, 21);
			tb_itemsb5.TabIndex = 24;
			tb_itemsb5.Text = "0x00000000";
			//
			// label17
			//
			label17.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			label17.AutoSize = true;
			label17.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label17.Location = new System.Drawing.Point(8, 120);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(43, 13);
			label17.TabIndex = 23;
			label17.Text = "Value:";
			//
			// lb_itemsb5
			//
			lb_itemsb5.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			lb_itemsb5.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lb_itemsb5.HorizontalScrollbar = true;
			lb_itemsb5.IntegralHeight = false;
			lb_itemsb5.Location = new System.Drawing.Point(8, 24);
			lb_itemsb5.Name = "lb_itemsb5";
			lb_itemsb5.Size = new System.Drawing.Size(216, 80);
			lb_itemsb5.TabIndex = 22;
			lb_itemsb5.SelectedIndexChanged += new EventHandler(
				SelectItemsB5
			);
			//
			// groupBox6
			//
			groupBox6.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			groupBox6.Controls.Add(tb_itemsb2);
			groupBox6.Controls.Add(label14);
			groupBox6.Controls.Add(lb_itemsb2);
			groupBox6.FlatStyle = FlatStyle.System;
			groupBox6.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox6.Location = new System.Drawing.Point(404, 8);
			groupBox6.Name = "groupBox6";
			groupBox6.Size = new System.Drawing.Size(232, 136);
			groupBox6.TabIndex = 27;
			groupBox6.TabStop = false;
			groupBox6.Text = "Link Section - Elements Ref.";
			//
			// tb_itemsb2
			//
			tb_itemsb2.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			tb_itemsb2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_itemsb2.Location = new System.Drawing.Point(56, 104);
			tb_itemsb2.Name = "tb_itemsb2";
			tb_itemsb2.ReadOnly = true;
			tb_itemsb2.Size = new System.Drawing.Size(88, 21);
			tb_itemsb2.TabIndex = 24;
			tb_itemsb2.Text = "0x00000000";
			//
			// label14
			//
			label14.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			label14.AutoSize = true;
			label14.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label14.Location = new System.Drawing.Point(8, 112);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(43, 13);
			label14.TabIndex = 23;
			label14.Text = "Value:";
			//
			// lb_itemsb2
			//
			lb_itemsb2.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			lb_itemsb2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lb_itemsb2.HorizontalScrollbar = true;
			lb_itemsb2.IntegralHeight = false;
			lb_itemsb2.Location = new System.Drawing.Point(8, 24);
			lb_itemsb2.Name = "lb_itemsb2";
			lb_itemsb2.Size = new System.Drawing.Size(216, 72);
			lb_itemsb2.TabIndex = 22;
			lb_itemsb2.SelectedIndexChanged += new EventHandler(
				SelectItemsB2
			);
			//
			// groupBox7
			//
			groupBox7.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			groupBox7.Controls.Add(linkLabel7);
			groupBox7.Controls.Add(tb_uk4);
			groupBox7.Controls.Add(tb_uk6);
			groupBox7.Controls.Add(label16);
			groupBox7.Controls.Add(lb_itemsb);
			groupBox7.Controls.Add(label18);
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
			groupBox7.Size = new System.Drawing.Size(388, 288);
			groupBox7.TabIndex = 26;
			groupBox7.TabStop = false;
			groupBox7.Text = "Link Section";
			//
			// linkLabel7
			//
			linkLabel7.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			linkLabel7.Location = new System.Drawing.Point(272, 120);
			linkLabel7.Name = "linkLabel7";
			linkLabel7.Size = new System.Drawing.Size(100, 23);
			linkLabel7.TabIndex = 26;
			linkLabel7.TabStop = true;
			linkLabel7.Text = "Flatten";
			linkLabel7.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					FlattenAliasMap
				);
			//
			// tb_uk4
			//
			tb_uk4.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			tb_uk4.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_uk4.Location = new System.Drawing.Point(276, 40);
			tb_uk4.Name = "tb_uk4";
			tb_uk4.ReadOnly = true;
			tb_uk4.Size = new System.Drawing.Size(88, 21);
			tb_uk4.TabIndex = 25;
			tb_uk4.Text = "0x00000000";
			//
			// tb_uk6
			//
			tb_uk6.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			tb_uk6.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_uk6.Location = new System.Drawing.Point(276, 80);
			tb_uk6.Name = "tb_uk6";
			tb_uk6.ReadOnly = true;
			tb_uk6.Size = new System.Drawing.Size(88, 21);
			tb_uk6.TabIndex = 23;
			tb_uk6.Text = "0x00000000";
			//
			// label16
			//
			label16.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			label16.AutoSize = true;
			label16.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label16.Location = new System.Drawing.Point(268, 64);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(103, 13);
			label16.TabIndex = 22;
			label16.Text = "Active Elements:";
			//
			// lb_itemsb
			//
			lb_itemsb.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			lb_itemsb.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lb_itemsb.HorizontalScrollbar = true;
			lb_itemsb.IntegralHeight = false;
			lb_itemsb.Location = new System.Drawing.Point(8, 24);
			lb_itemsb.Name = "lb_itemsb";
			lb_itemsb.Size = new System.Drawing.Size(252, 256);
			lb_itemsb.TabIndex = 21;
			lb_itemsb.SelectedIndexChanged += new EventHandler(
				SelectItemsB
			);
			//
			// label18
			//
			label18.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			label18.AutoSize = true;
			label18.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label18.Location = new System.Drawing.Point(268, 24);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(105, 13);
			label18.TabIndex = 5;
			label18.Text = "Referenced Size:";
			//
			// groupBox8
			//
			groupBox8.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Bottom
						) | AnchorStyles.Right
					)

			;
			groupBox8.Controls.Add(tb_itemsb3);
			groupBox8.Controls.Add(label19);
			groupBox8.Controls.Add(lb_itemsb3);
			groupBox8.FlatStyle = FlatStyle.System;
			groupBox8.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox8.Location = new System.Drawing.Point(404, 152);
			groupBox8.Name = "groupBox8";
			groupBox8.Size = new System.Drawing.Size(232, 144);
			groupBox8.TabIndex = 28;
			groupBox8.TabStop = false;
			groupBox8.Text = "Link Section - Vertex Alias";
			//
			// tb_itemsb3
			//
			tb_itemsb3.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			tb_itemsb3.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_itemsb3.Location = new System.Drawing.Point(56, 112);
			tb_itemsb3.Name = "tb_itemsb3";
			tb_itemsb3.ReadOnly = true;
			tb_itemsb3.Size = new System.Drawing.Size(88, 21);
			tb_itemsb3.TabIndex = 24;
			tb_itemsb3.Text = "0x00000000";
			//
			// label19
			//
			label19.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			label19.AutoSize = true;
			label19.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label19.Location = new System.Drawing.Point(8, 120);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(43, 13);
			label19.TabIndex = 23;
			label19.Text = "Value:";
			//
			// lb_itemsb3
			//
			lb_itemsb3.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			lb_itemsb3.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lb_itemsb3.HorizontalScrollbar = true;
			lb_itemsb3.IntegralHeight = false;
			lb_itemsb3.Location = new System.Drawing.Point(8, 24);
			lb_itemsb3.Name = "lb_itemsb3";
			lb_itemsb3.Size = new System.Drawing.Size(216, 80);
			lb_itemsb3.TabIndex = 22;
			lb_itemsb3.SelectedIndexChanged += new EventHandler(
				SelectItemsB3
			);
			//
			// tSubset
			//
			tSubset.BackColor = System.Drawing.SystemColors.ControlLightLight;
			tSubset.Controls.Add(groupBox13);
			tSubset.Controls.Add(groupBox14);
			tSubset.Controls.Add(groupBox15);
			tSubset.Location = new System.Drawing.Point(4, 22);
			tSubset.Name = "tSubset";
			tSubset.Size = new System.Drawing.Size(884, 302);
			tSubset.TabIndex = 6;
			tSubset.Text = "Joints";
			tSubset.UseVisualStyleBackColor = true;
			//
			// groupBox13
			//
			groupBox13.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)

			;
			groupBox13.Controls.Add(lb_sub_items);
			groupBox13.FlatStyle = FlatStyle.System;
			groupBox13.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox13.Location = new System.Drawing.Point(604, 160);
			groupBox13.Name = "groupBox13";
			groupBox13.Size = new System.Drawing.Size(272, 136);
			groupBox13.TabIndex = 32;
			groupBox13.TabStop = false;
			groupBox13.Text = "Joints Section - Items";
			//
			// lb_sub_items
			//
			lb_sub_items.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			lb_sub_items.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lb_sub_items.HorizontalScrollbar = true;
			lb_sub_items.IntegralHeight = false;
			lb_sub_items.Location = new System.Drawing.Point(8, 24);
			lb_sub_items.Name = "lb_sub_items";
			lb_sub_items.Size = new System.Drawing.Size(256, 96);
			lb_sub_items.TabIndex = 22;
			lb_sub_items.SelectedIndexChanged += new EventHandler(
				lb_sub_item_SelectedIndexChanged
			);
			//
			// groupBox14
			//
			groupBox14.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Bottom
						) | AnchorStyles.Right
					)

			;
			groupBox14.Controls.Add(lb_sub_faces);
			groupBox14.FlatStyle = FlatStyle.System;
			groupBox14.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox14.Location = new System.Drawing.Point(604, 8);
			groupBox14.Name = "groupBox14";
			groupBox14.Size = new System.Drawing.Size(272, 144);
			groupBox14.TabIndex = 31;
			groupBox14.TabStop = false;
			groupBox14.Text = "Joints Section - Vertices";
			//
			// lb_sub_faces
			//
			lb_sub_faces.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			lb_sub_faces.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lb_sub_faces.HorizontalScrollbar = true;
			lb_sub_faces.IntegralHeight = false;
			lb_sub_faces.Location = new System.Drawing.Point(8, 24);
			lb_sub_faces.Name = "lb_sub_faces";
			lb_sub_faces.Size = new System.Drawing.Size(256, 112);
			lb_sub_faces.TabIndex = 22;
			//
			// groupBox15
			//
			groupBox15.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			groupBox15.Controls.Add(linkLabel5);
			groupBox15.Controls.Add(linkLabel4);
			groupBox15.Controls.Add(lb_subsets);
			groupBox15.FlatStyle = FlatStyle.System;
			groupBox15.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox15.Location = new System.Drawing.Point(8, 7);
			groupBox15.Name = "groupBox15";
			groupBox15.Size = new System.Drawing.Size(588, 288);
			groupBox15.TabIndex = 30;
			groupBox15.TabStop = false;
			groupBox15.Text = "Joints Section";
			//
			// linkLabel5
			//
			linkLabel5.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)

			;
			linkLabel5.Location = new System.Drawing.Point(528, 208);
			linkLabel5.Name = "linkLabel5";
			linkLabel5.Size = new System.Drawing.Size(56, 23);
			linkLabel5.TabIndex = 29;
			linkLabel5.TabStop = true;
			linkLabel5.Text = "Rebuild";
			linkLabel5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			linkLabel5.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					RebuildJointVertices
				);
			//
			// linkLabel4
			//
			linkLabel4.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)

			;
			linkLabel4.Location = new System.Drawing.Point(528, 256);
			linkLabel4.Name = "linkLabel4";
			linkLabel4.Size = new System.Drawing.Size(48, 23);
			linkLabel4.TabIndex = 27;
			linkLabel4.TabStop = true;
			linkLabel4.Text = "Delete";
			linkLabel4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			linkLabel4.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					DeleteJoint
				);
			//
			// lb_subsets
			//
			lb_subsets.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			lb_subsets.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lb_subsets.HorizontalScrollbar = true;
			lb_subsets.IntegralHeight = false;
			lb_subsets.Location = new System.Drawing.Point(8, 24);
			lb_subsets.Name = "lb_subsets";
			lb_subsets.Size = new System.Drawing.Size(512, 256);
			lb_subsets.TabIndex = 21;
			lb_subsets.SelectedIndexChanged += new EventHandler(
				lb_subsets_SelectedIndexChanged
			);
			//
			// sfd
			//
			sfd.Title = "Export Mesh";
			//
			// cd
			//
			cd.Color = System.Drawing.Color.FromArgb(
				((byte)(128)),
				((byte)(128)),
				((byte)(255))
			);
			//
			// ofd
			//
			ofd.Title = "Import Mesh";
			//
			// fGeometryDataContainer
			//
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(936, 334);
			Controls.Add(tabControl1);
			Name = "fGeometryDataContainer";
			Text = "fGeometryDataContainer";
			Load += new EventHandler(fGeometryDataContainer_Load);
			tabControl1.ResumeLayout(false);
			tGeometryDataContainer.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			groupBox10.ResumeLayout(false);
			groupBox10.PerformLayout();
			groupBox12.ResumeLayout(false);
			tAdvncd.ResumeLayout(false);
			tAdvncd.PerformLayout();
			tGeometryDataContainer3.ResumeLayout(false);
			groupBox4.ResumeLayout(false);
			groupBox4.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			groupBox5.ResumeLayout(false);
			groupBox5.PerformLayout();
			tMesh.ResumeLayout(false);
			tMesh.PerformLayout();
			tModel.ResumeLayout(false);
			groupBox19.ResumeLayout(false);
			groupBox18.ResumeLayout(false);
			groupBox18.PerformLayout();
			groupBox17.ResumeLayout(false);
			groupBox16.ResumeLayout(false);
			groupBox16.PerformLayout();
			tGeometryDataContainer2.ResumeLayout(false);
			groupBox9.ResumeLayout(false);
			groupBox9.PerformLayout();
			groupBox11.ResumeLayout(false);
			groupBox11.PerformLayout();
			groupBox6.ResumeLayout(false);
			groupBox6.PerformLayout();
			groupBox7.ResumeLayout(false);
			groupBox7.PerformLayout();
			groupBox8.ResumeLayout(false);
			groupBox8.PerformLayout();
			tSubset.ResumeLayout(false);
			groupBox13.ResumeLayout(false);
			groupBox14.ResumeLayout(false);
			groupBox15.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion

		private void SettingsChange(object sender, EventArgs e)
		{
			if (tMesh.Tag == null)
			{
				return;
			}

			try
			{
				GeometryDataContainer gdc = (GeometryDataContainer)tMesh.Tag;

				gdc.Version = Convert.ToUInt32(tb_ver.Text, 16);

				gdc.Changed = true;
			}
			catch (Exception)
			{
				//Helper.ExceptionMessage("", ex);
			}
		}

		private void SelectItemsA(object sender, EventArgs e)
		{
			if (lb_itemsa.Tag != null)
			{
				return;
			}

			if (lb_itemsa.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				lb_itemsa.Tag = true;
				GmdcElement item = (GmdcElement)
					((CountedListItem)lb_itemsa.Items[lb_itemsa.SelectedIndex]).Object;

				tb_id.Text = "0x" + Helper.HexString((uint)item.Identity);
				tb_uk1.Text = item.Number.ToString();
				tb_mod1.Text = "0x" + Helper.HexString((uint)item.BlockFormat);
				tb_mod2.Text = "0x" + Helper.HexString((uint)item.SetFormat);
				tb_uk5.Text = "0x" + Helper.HexString(item.GroupId);

				cbid.SelectedIndex = 0;
				for (int i = 0; i < cbid.Items.Count; i++)
				{
					ElementIdentity b = (ElementIdentity)cbid.Items[i];
					if (b == item.Identity)
					{
						cbid.SelectedIndex = i;
					}
				}

				cbblock.SelectedIndex = cbblock.Items.Count - 1;
				for (int i = 0; i < cbblock.Items.Count; i++)
				{
					BlockFormat b = (BlockFormat)cbblock.Items[i];
					if (b == item.BlockFormat)
					{
						cbblock.SelectedIndex = i;
					}
				}

				cbset.SelectedIndex = cbset.Items.Count - 1;
				for (int i = 0; i < cbset.Items.Count; i++)
				{
					SetFormat b = (SetFormat)cbset.Items[i];
					if (b == item.SetFormat)
					{
						cbset.SelectedIndex = i;
					}
				}

				lb_itemsa1.Items.Clear();
				foreach (GmdcElementValueBase i in item.Values)
				{
					CountedListItem.Add(lb_itemsa1, i);
				}

				lb_itemsa2.Items.Clear();
				foreach (int i in item.Items)
				{
					lb_itemsa2.Items.Add(i);
				}
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lb_itemsa.Tag = null;
			}
		}

		private void SelectItemsA2(object sender, EventArgs e)
		{
			if (lb_itemsa.Tag != null)
			{
				return;
			}

			if (lb_itemsa.SelectedIndex < 0)
			{
				return;
			}

			if (lb_itemsa2.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				lb_itemsa.Tag = true;
				GmdcElement item = (GmdcElement)
					(
						(CountedListItem)lb_itemsa.Items[lb_itemsa.SelectedIndex]
					).Object;

				tb_itemsa2.Text =
					"0x" + Helper.HexString(item.Items[lb_itemsa2.SelectedIndex]);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lb_itemsa.Tag = null;
			}
		}

		private void SelectItemsB(object sender, EventArgs e)
		{
			if (lb_itemsb.Tag != null)
			{
				return;
			}

			if (lb_itemsb.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				lb_itemsb.Tag = true;
				GmdcLink item = (GmdcLink)
					((CountedListItem)lb_itemsb.Items[lb_itemsb.SelectedIndex]).Object;

				tb_uk4.Text = item.ReferencedSize.ToString();
				tb_uk6.Text = item.ActiveElements.ToString();

				lb_itemsb2.Items.Clear();
				foreach (int i in item.ReferencedElement)
				{
					lb_itemsb2.Items.Add(i);
				}

				lb_itemsb3.Items.Clear();
				foreach (int i in item.AliasValues[0])
				{
					lb_itemsb3.Items.Add(i);
				}

				lb_itemsb4.Items.Clear();
				foreach (int i in item.AliasValues[1])
				{
					lb_itemsb4.Items.Add(i);
				}

				lb_itemsb5.Items.Clear();
				foreach (int i in item.AliasValues[2])
				{
					lb_itemsb5.Items.Add(i);
				}
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lb_itemsb.Tag = null;
			}
		}

		private void SelectItemsB2(object sender, EventArgs e)
		{
			if (lb_itemsb.Tag != null)
			{
				return;
			}

			if (lb_itemsb.SelectedIndex < 0)
			{
				return;
			}

			if (lb_itemsb2.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				lb_itemsb.Tag = true;
				GmdcLink item = (GmdcLink)
					((CountedListItem)lb_itemsb.Items[lb_itemsb.SelectedIndex]).Object;
				tb_itemsb2.Text =
					"0x"
					+ Helper.HexString(
						item.ReferencedElement[lb_itemsb2.SelectedIndex]
					);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lb_itemsb.Tag = null;
			}
		}

		private void SelectItemsB3(object sender, EventArgs e)
		{
			if (lb_itemsb.Tag != null)
			{
				return;
			}

			if (lb_itemsb.SelectedIndex < 0)
			{
				return;
			}

			if (lb_itemsb3.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				lb_itemsb.Tag = true;
				GmdcLink item = (GmdcLink)
					((CountedListItem)lb_itemsb.Items[lb_itemsb.SelectedIndex]).Object;
				tb_itemsb3.Text =
					"0x"
					+ Helper.HexString(item.AliasValues[0][lb_itemsb3.SelectedIndex]);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lb_itemsb.Tag = null;
			}
		}

		private void SelectItemsB4(object sender, EventArgs e)
		{
			if (lb_itemsb.Tag != null)
			{
				return;
			}

			if (lb_itemsb.SelectedIndex < 0)
			{
				return;
			}

			if (lb_itemsb4.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				lb_itemsb.Tag = true;
				GmdcLink item = (GmdcLink)
					((CountedListItem)lb_itemsb.Items[lb_itemsb.SelectedIndex]).Object;
				tb_itemsb4.Text =
					"0x"
					+ Helper.HexString(item.AliasValues[1][lb_itemsb4.SelectedIndex]);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lb_itemsb.Tag = null;
			}
		}

		private void SelectItemsB5(object sender, EventArgs e)
		{
			if (lb_itemsb.Tag != null)
			{
				return;
			}

			if (lb_itemsb.SelectedIndex < 0)
			{
				return;
			}

			if (lb_itemsb5.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				lb_itemsb.Tag = true;
				GmdcLink item = (GmdcLink)
					((CountedListItem)lb_itemsb.Items[lb_itemsb.SelectedIndex]).Object;
				tb_itemsb5.Text =
					"0x"
					+ Helper.HexString(item.AliasValues[2][lb_itemsb5.SelectedIndex]);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lb_itemsb.Tag = null;
			}
		}

		private void SelectItemsC(object sender, EventArgs e)
		{
			if (lb_itemsc.Tag != null)
			{
				return;
			}

			if (lb_itemsc.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				lb_itemsc.Tag = true;
				GmdcGroup item = (GmdcGroup)lb_itemsc.Items[lb_itemsc.SelectedIndex];

				tb_uk2.Text = "0x" + Helper.HexString((uint)item.PrimitiveType);
				tb_uk3.Text = "0x" + Helper.HexString(item.LinkIndex);
				tb_opacity.Text = "0x" + Helper.HexString(item.Opacity);
				tb_itemsc_name.Text = item.Name;

				lb_itemsc2.Items.Clear();
				foreach (int i in item.Faces)
				{
					lb_itemsc2.Items.Add(i);
				}

				lb_itemsc3.Items.Clear();
				foreach (int i in item.UsedJoints)
				{
					lb_itemsc3.Items.Add(i);
				}
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lb_itemsc.Tag = null;
			}
		}

		private void SelectItemsC2(object sender, EventArgs e)
		{
			if (lb_itemsc.Tag != null)
			{
				return;
			}

			if (lb_itemsc.SelectedIndex < 0)
			{
				return;
			}

			if (lb_itemsc2.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				lb_itemsc.Tag = true;
				GmdcGroup item = (GmdcGroup)lb_itemsc.Items[lb_itemsc.SelectedIndex];

				tb_itemsc2.Text =
					"0x" + Helper.HexString(item.Faces[lb_itemsc2.SelectedIndex]);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lb_itemsc.Tag = null;
			}
		}

		private void SelectItemsC3(object sender, EventArgs e)
		{
			if (lb_itemsc.Tag != null)
			{
				return;
			}

			if (lb_itemsc.SelectedIndex < 0)
			{
				return;
			}

			if (lb_itemsc3.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				lb_itemsc.Tag = true;
				GmdcGroup item = (GmdcGroup)lb_itemsc.Items[lb_itemsc.SelectedIndex];

				tb_itemsc3.Text =
					"0x" + Helper.HexString(item.UsedJoints[lb_itemsc3.SelectedIndex]);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lb_itemsc.Tag = null;
			}
		}

		private void ChangeItemsC(object sender, EventArgs e)
		{
			if (lb_itemsc.Tag != null)
			{
				return;
			}

			if (lb_itemsc.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				lb_itemsc.Tag = true;
				GmdcGroup item = (GmdcGroup)lb_itemsc.Items[lb_itemsc.SelectedIndex];

				item.PrimitiveType = (PrimitiveType)
					Convert.ToUInt32(tb_uk2.Text, 16);
				item.LinkIndex = (int)Convert.ToUInt32(tb_uk3.Text, 16);
				item.Opacity = Convert.ToUInt32(tb_opacity.Text, 16);
				item.Name = tb_itemsc_name.Text;

				lb_itemsc.Items[lb_itemsc.SelectedIndex] = item;

				GeometryDataContainer gdc = (GeometryDataContainer)tMesh.Tag;
				gdc.Changed = true;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lb_itemsc.Tag = null;
			}
		}

		internal void ResetPreviewCamera(bool weak)
		{
			if (!weak)
			{
				//dxprev.Settings.Aspect = (float)dxprev.Height/(float)dxprev.Width;
				dxprev.ResetDefaultViewport();
				//dxprev.Settings.Aspect = (float)dxprev.Width/(float)dxprev.Height;
			}
			/*dxprev.Viewport.NearPlane = Helper.WindowsRegistry.ImportExportScaleFactor / 10;
			dxprev.Viewport.FarPlane = dxprev.Viewport.NearPlane * 10000;
			dxprev.Viewport.BoundingSphereRadius = Math.Min(dxprev.Viewport.BoundingSphereRadius, Helper.WindowsRegistry.ImportExportScaleFactor);*/
			//dxprev.Viewport.Aspect = (float)dxprev.Width/(float)dxprev.Height;
		}

		internal void ResetPreview()
		{
			scenesel.Scene = null;
		}

		private void Preview(object sender, EventArgs e)
		{
			GeometryDataContainer gmdc = (GeometryDataContainer)tMesh.Tag;
			Wait.SubStart();
			Wait.Message = "Loading Preview...";
			try
			{
				GeometryDataContainerExt gmdcext = new GeometryDataContainerExt(gmdc);
				scenesel.Scene?.Dispose();

				scenesel.Scene = gmdcext.GetScene(
					GetModelsExt(),
					new ElementOrder(ElementSorting.Preview)
				);

				ResetPreviewCamera(false);
				/*if (this.scenesel.Scene!=null)
				{
					Ambertation.Scenes.Mesh m = this.scenesel.Scene.MeshCollection["body"];
					if (m!=null)
					{
						Image img = m.CreateNormalMap();
						img.Save(@"C:\Dokumente und Einstellungen\Wir\Desktop\test.bmp");
						img.Dispose();
					}
				}*/
			}
			catch (FileNotFoundException)
			{
				WaitingScreen.Stop();
				MessageBox.Show(
					"The Microsoft Managed DirectX Extensions were not found on your System. Without them, the Preview is not available.\n\nYou can install them manually, by extracting the content of the DirectX\\ManagedDX.CAB on your Sims 2 Installation CD #1. If you double click on the extracted msi File, all needed Files will be installed.",
					"Warning",
					MessageBoxButtons.OK
				);
				return;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex + "\n" + ex.StackTrace);
			}

			Wait.SubStop();
		}

		/// <summary>
		/// Get all Selected Models
		/// </summary>
		/// <returns></returns>
		ArrayList GetModels()
		{
			ArrayList list = new ArrayList();
			for (int i = 0; i < lbmodel.CheckedItems.Count; i++)
			{
				list.Add(lbmodel.CheckedItems[i]);
			}

			return list;
		}

		/// <summary>
		/// Get all Selected Models
		/// </summary>
		/// <returns></returns>
		GmdcGroups GetModelsExt()
		{
			GmdcGroups list = new GmdcGroups();
			for (int i = 0; i < lbmodel.CheckedItems.Count; i++)
			{
				list.Add(lbmodel.CheckedItems[i]);
			}

			return list;
		}

		private void PickColor(object sender, EventArgs e)
		{
			cd.Color = dxprev.BackColor;
			if (cd.ShowDialog() == DialogResult.OK)
			{
				dxprev.BackColor = cd.Color;
			}
		}

		private void SeletAdvncdObject(object sender, EventArgs e)
		{
			ListBox lb = (ListBox)sender;
			if (lb.SelectedIndex >= 0)
			{
				pg.SelectedObject = (
					(CountedListItem)lb.Items[lb.SelectedIndex]
				).Object;
				pg.Refresh();
			}
		}

		private void dxprev_ResetDevice(object sender, EventArgs e)
		{
			Ambertation.Graphics.DirectXPanel dx =
				sender as Ambertation.Graphics.DirectXPanel;
		}

		private void llAddBB_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (tMesh.Tag != null)
			{
				if (lb_itemsc.SelectedIndex < 0)
				{
					return;
				}

				GeometryDataContainer gmdc = (GeometryDataContainer)tMesh.Tag;
				GmdcGroup g = (GmdcGroup)lb_itemsc.SelectedItem;

				gmdc.Model.AddGroupToBoundingMesh(g);
				gmdc.Refresh();
				gmdc.Changed = true;
			}
		}

		private void llClearBB_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (tMesh.Tag != null)
			{
				GeometryDataContainer gmdc = (GeometryDataContainer)tMesh.Tag;
				gmdc.Model.ClearBoundingMesh();

				lb_model_faces.Items.Clear();
				lb_model_items.Items.Clear();

				gmdc.Changed = true;
			}
		}

		private void cbCorrect_CheckedChanged(object sender, EventArgs e)
		{
			Helper.WindowsRegistry.CorrectJointDefinitionOnExport =
				cbCorrect.Checked;
		}

		private void llAssign_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (cbGroupJoint.SelectedItem != null)
			{
				if (lb_itemsc.SelectedItem != null)
				{
					GmdcJoint j = (GmdcJoint)
						((CountedListItem)cbGroupJoint.SelectedItem).Object;
					GmdcGroup g = (GmdcGroup)lb_itemsc.SelectedItem;

					//Get the assignment Element
					GmdcElement ba = g.Link.FindElementType(
						ElementIdentity.BoneAssignment
					);
					if (ba == null)
					{
						ba = new GmdcElement(g.Parent)
						{
							Identity = ElementIdentity.BoneAssignment
						};
						ba.Parent.Elements.Add(ba);
						g.Link.ReferencedElement.Add(ba.Parent.Elements.Count - 1);
					}

					//Get the Weight Element
					GmdcElement bw = g.Link.FindElementType(
						ElementIdentity.BoneWeights
					);
					if (bw == null)
					{
						bw = new GmdcElement(g.Parent)
						{
							Identity = ElementIdentity.BoneWeights
						};

						bw.Parent.Elements.Add(bw);
						g.Link.ReferencedElement.Add(bw.Parent.Elements.Count - 1);
					}

					//Get the Index of the used joint
					if (!g.UsedJoints.Contains(j.Index))
					{
						g.UsedJoints.Add(j.Index);
						lb_itemsc3.Items.Add(j.Index);
					}
					uint id = 0;
					for (int i = 0; i < g.UsedJoints.Count; i++)
					{
						if (g.UsedJoints[i] == j.Index)
						{
							id = (uint)i;
							break;
						}
					}

					GmdcElement v = g.Link.FindElementType(ElementIdentity.Vertex);
					if (v == null)
					{
						return;
					}

					ba.Values.Clear();
					ba.BlockFormat = BlockFormat.OneDword;

					bw.Values.Clear();
					bw.BlockFormat = BlockFormat.OneFloat;

					//create an assignment for each Vertex
					for (int i = 0; i < v.Values.Length; i++)
					{
						ba.Values.Add(
							new GmdcElementValueOneInt((int)(id | 0xffffff00))
						);
						bw.Values.Add(new GmdcElementValueOneFloat(1.0f));
					}
				}
			}
		}

		private void dxprev_SizeChanged(object sender, EventArgs e)
		{
			int width = scenesel.Left - lbmodel.Right - 16;
			int height = scenesel.Height;

			dxprev.Left = lbmodel.Right + 8;
			dxprev.Top = scenesel.Top;
			dxprev.Width = Math.Max(1, width);
			dxprev.Height = Math.Max(1, height);
			//dxprev.Settings.Aspect = (float)dxprev.Width/(float)dxprev.Height;
		}

		public static int DefaultSelectedAxisIndex
		{
			get
			{
				XmlRegistryKey rkf =
					Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey("SceneGraph");
				object o = rkf.GetValue("DefaultAxis", 1);
				return Convert.ToInt32(o);
			}
			set
			{
				XmlRegistryKey rkf =
					Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey("SceneGraph");
				rkf.SetValue("DefaultAxis", value);
			}
		}

		private void ChangedAxis(object sender, EventArgs e)
		{
			if (tMesh.Tag == null)
			{
				return;
			}

			ComboBox cb = (ComboBox)sender;
			DefaultSelectedAxisIndex = cb.SelectedIndex;
		}

		private void FlattenAliasMap(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (lb_itemsb.SelectedIndex < 0)
			{
				return;
			}

			GmdcLink item = (GmdcLink)
				((CountedListItem)lb_itemsb.Items[lb_itemsb.SelectedIndex]).Object;
			item.Flatten();
			item.Parent.Changed = true;
			item.Parent.Refresh();
		}

		private void RebuildAbsTransform(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (tMesh.Tag != null)
			{
				GeometryDataContainer gmdc = (GeometryDataContainer)tMesh.Tag;
				try
				{
					if (lb_model_trans.SelectedIndex < 0)
					{
						for (int i = 0; i < gmdc.Model.Transformations.Count; i++)
						{
							TransformNode tn = gmdc.Joints[i].AssignedTransformNode;

							if (tn != null)
							{
								gmdc.Model.Transformations[i] =
									tn.GetEffectiveTransformation();
							}
						}
					}
					else
					{
						TransformNode tn = gmdc.Joints[
							lb_model_trans.SelectedIndex
						].AssignedTransformNode;

						if (tn != null)
						{
							gmdc.Model.Transformations[lb_model_trans.SelectedIndex] =
								tn.GetEffectiveTransformation();
						}
					}
				}
				catch (Exception ex)
				{
					Helper.ExceptionMessage("", ex);
				}

				gmdc.Changed = true;

				/*string res = "";
				for (int i=0; i<old.Count; i++)
				{
					if (Math.Abs((float)old[i].Translation.Y-(float)gmdc.Model.Transformations[i].Translation.Y) > 0.01) res += Helper.lbr+i.ToString();
					else if (Math.Abs((float)old[i].Translation.X-(float)gmdc.Model.Transformations[i].Translation.X) > 0.01) res += Helper.lbr+i.ToString();
					else if (Math.Abs((float)old[i].Translation.Z-(float)gmdc.Model.Transformations[i].Translation.Z) > 0.01) res += Helper.lbr+i.ToString();
				}*/

				gmdc.Refresh();
				gmdc.Changed = true;
			}
		}

		private void fGeometryDataContainer_Load(object sender, EventArgs e)
		{
		}

		private void RebuildJointVertices(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (tMesh.Tag != null)
			{
				GeometryDataContainer gmdc = (GeometryDataContainer)tMesh.Tag;

				if (lb_subsets.SelectedIndex < 0)
				{
					return;
				}

				GmdcJoint joint = gmdc.Joints[lb_subsets.SelectedIndex];
				joint.CollectVertices();
				gmdc.Refresh();
			}
		}

		/*
		private void PreviewJoint(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs ea)
		{
			if (this.tMesh.Tag != null)
			{
				GeometryDataContainer gmdc = (GeometryDataContainer) this.tMesh.Tag;

				if (lb_subsets.SelectedIndex<0) return;
				GmdcJoint join = gmdc.Joints[lb_subsets.SelectedIndex];
				
				gmdc = new GeometryDataContainer(null);
				GmdcGroup g = new GmdcGroup(gmdc);
				g.LinkIndex = 0;
				GmdcLink l = new GmdcLink(gmdc);
				GmdcElement e = new GmdcElement(gmdc);
				e.Identity = ElementIdentity.Vertex;
				e.SetFormat = SetFormat.Main;
				e.BlockFormat = BlockFormat.ThreeFloat;
				l.ReferencedElement.Add(0);

				GmdcElement en = new GmdcElement(gmdc);
				en.Identity = ElementIdentity.Normal;
				en.SetFormat = SetFormat.Normals;
				en.BlockFormat = BlockFormat.ThreeFloat;
				l.ReferencedElement.Add(1);

				foreach (Vector3f v in join.Vertices)
				{
					e.Values.Add(new SimPe.Plugin.Gmdc.GmdcElementValueThreeFloat((float)v.X, (float)v.Y, (float)v.Z));
					en.Values.Add(new SimPe.Plugin.Gmdc.GmdcElementValueThreeFloat(0, 0, 0));
				}
				foreach (int i in join.Items) g.Faces.Add(i);


				l.ReferencedSize = e.Values.Length;
				l.ActiveElements = 2;
				gmdc.Elements.Add(e);
				gmdc.Elements.Add(en);
				gmdc.Links.Add(l);
				gmdc.Groups.Add(g);

				Stream xfile = gmdc.GenerateX(gmdc.Groups);
				try
				{
					//stop all running Previews
					//Ambertation.Panel3D.StopAll();

					System.Collections.Hashtable txtrs = new Hashtable();

					//dxprev.LoadMesh(xfile, txtrs);
				}
				catch (Exception ex)
				{
					WaitingScreen.Stop();
					Helper.ExceptionMessage("", ex);
					return;
				}
				dxprev.BackColor = cd.Color;
				WaitingScreen.Stop();
				
				//this.tabControl1.SelectedIndex = 1;
				((TabControl)tMesh.Parent).SelectedTab = tMesh;
				//this.tabControl1.SelectedTab = tMesh;
				
			}
		}
		
		private void linkLabel3_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			if (this.tMesh.Tag != null)
			{
				SimPe.Interfaces.Files.IPackageFile pkg = ((GeometryDataContainer)this.tMesh.Tag).Parent.Package;

				SimPe.Interfaces.Files.IPackedFileDescriptor[] pfds = pkg.FindFiles(Data.MetaData.GMDC);
				int min = int.MaxValue;
				int max = 0;
				int av = 0;
				int ct = 0;

				int vmin = int.MaxValue;
				int vmax = 0;
				int vav = 0;
				int vct = 0;
				foreach (SimPe.Interfaces.Files.IPackedFileDescriptor pfd in pfds)
				{
					GenericRcol rcol = new GenericRcol(null, false);
					rcol.ProcessData(pfd, pkg);

					GeometryDataContainer gmdc = (GeometryDataContainer)rcol.Blocks[0];

					foreach (GmdcGroup g in gmdc.Groups)
					{
						if (g.Faces.Length > max) max = g.Faces.Length;
						if (g.Faces.Length < min) min = g.Faces.Length;
						av += g.Faces.Length;
						ct++;
					}

					foreach (GmdcLink l in gmdc.Links)
					{
						if (l.AliasValues[0].Count + l.AliasValues[1].Count + l.AliasValues[2].Count > 0 && l.ReferencedElement.Length > 2)
						{
							if (MessageBox.Show(l.ReferencedElement.Count.ToString() + " " + pfd.Instance.ToString("X") + "\n\nContinue?", "alt. Links", MessageBoxButtons.YesNo) == DialogResult.No) return;
						}

						if (l.ReferencedSize > vmax) vmax = l.ReferencedSize;
						if (l.ReferencedSize < vmin) vmin = l.ReferencedSize;
						vav += l.ReferencedSize;
						vct++;

						ct = -1;
						foreach (int k in l.ReferencedElement)
						{
							if (ct != -1)
							{
								if (gmdc.Elements[k].Values.Length != ct)
								{
									//MessageBox.Show(pfd.Instance.ToString("X"));
								}
							}

							ct = gmdc.Elements[k].Values.Length;
						}
					}
				}
			}
		}
		*/
		private void DeleteJoint(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (tMesh.Tag != null)
			{
				GeometryDataContainer gmdc = (GeometryDataContainer)tMesh.Tag;

				if (lb_subsets.SelectedIndex < 0)
				{
					return;
				}

				gmdc.RemoveBone(lb_subsets.SelectedIndex);
				gmdc.Refresh();
				gmdc.Changed = true;
			}
		}

		private void linkLabel2_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (tMesh.Tag != null)
			{
				GeometryDataContainer gmdc = (GeometryDataContainer)tMesh.Tag;

				if (lb_itemsc.SelectedIndex < 0)
				{
					return;
				}

				gmdc.RemoveGroup(lb_itemsc.SelectedIndex);
				gmdc.Refresh();
				gmdc.Changed = true;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				if (tMesh.Tag != null)
				{
					GeometryDataContainer gmdc = (GeometryDataContainer)tMesh.Tag;

					StartImport(
						ofd,
						gmdc,
						Helper.WindowsRegistry.GmdcExtension,
						(ElementSorting)cbaxis.Items[cbaxis.SelectedIndex],
						false
					);
				}
			}
			catch (Exception exception1)
			{
				Helper.ExceptionMessage("", exception1);
				return;
			}
		}

		private void lb_sub_item_SelectedIndexChanged(object sender, EventArgs e)
		{
			/*if (lb_sub_items.Tag != null) return;
			if (lb_sub_items.SelectedIndex<0) return;
			if (lb_subsets.SelectedIndex<0) return;
			try
			{
				lb_sub_items.Tag = true;
				GmdcJoint item = (GmdcJoint)((CountedListItem)lb_subsets.Items[lb_subsets.SelectedIndex]).Object;
				this.tb_sub_item.Text = "0x"+Helper.HexString(item.Items[lb_sub_items.SelectedIndex]);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lb_itemsb.Tag = null;
			}*/
		}

		private void lb_subsets_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lb_subsets.Tag != null)
			{
				return;
			}

			if (lb_subsets.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				lb_subsets.Tag = true;
				GmdcJoint item = (GmdcJoint)
					(
						(CountedListItem)lb_subsets.Items[lb_subsets.SelectedIndex]
					).Object;

				lb_sub_faces.Items.Clear();
				foreach (Vector3f i in item.Vertices)
				{
					CountedListItem.Add(lb_sub_faces, i);
				}

				lb_sub_items.Items.Clear();
				foreach (int i in item.Items)
				{
					CountedListItem.Add(lb_sub_items, i);
				}
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lb_subsets.Tag = null;
			}
		}

		public static void StartImport(
			OpenFileDialog ofd,
			GeometryDataContainer gmdc,
			string defext,
			ElementSorting sorting,
			bool animationonly
		)
		{
			//Assemble a List of available Import Modules
			string f = "";
			foreach (IGmdcImporter ex in ExporterLoader.Importers)
			{
				if (f != "")
				{
					f += "|";
				}

				f += ex.FileDescription + " Importer ";
				if (
					(ex.Author != "")
					&& (ex.Author != "Quaxi")
					&& (ex.Author != "Emily")
				)
				{
					f += "by " + ex.Author + " ";
				}

				f += "(*" + ex.FileExtension + ")|*" + ex.FileExtension;
			}

			if (f == "")
			{
				Helper.ExceptionMessage(
					"",
					new Exception("There are no Importer Plugins available!")
				);
				return;
			}
			ofd.Filter = f;
			//Make .obj the Default Extension
			ofd.FilterIndex =
				ExporterLoader.FindFirstImporterIndexByExtension(defext) + 1;

			ofd.AddExtension = true;
			ofd.FileName = Helper.SaveFileName(
				Hashes.StripHashFromName(gmdc.Parent.FileName).Trim().ToLower()
			);
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				//Now perpare the Import
				IGmdcImporter importer = ExporterLoader.Importers[ofd.FilterIndex - 1];
				Helper.WindowsRegistry.GmdcExtension = importer.FileExtension;
				importer.Component.Sorting = sorting;
				FileStream meshreader = File.OpenRead(ofd.FileName);

				try
				{
					importer.FileName = ofd.FileName;
					if (importer.Process(meshreader, gmdc, animationonly))
					{
						if (!animationonly)
						{
							gmdc.Refresh();
							gmdc.Changed = true;
						}

						if (importer.ErrorMessage != "")
						{
							Helper.ExceptionMessage(
								"",
								new Warning(
									"Problems while parsing the File.",
									importer.ErrorMessage
								)
							);
						}
					}
				}
				finally
				{
					meshreader.Close();
					meshreader.Dispose();
					meshreader = null;
				}
			}
		}

		public static void StartExport(
			SaveFileDialog sfd,
			GeometryDataContainer gmdc,
			string defext,
			GmdcGroups groups,
			ElementSorting sorting,
			bool corjoints
		)
		{
			try
			{
				//Assemble a List of available Export Modules
				string f = "";
				foreach (IGmdcExporter ex in ExporterLoader.Exporters)
				{
					if (f != "")
					{
						f += "|";
					}

					f += ex.FileDescription + " Exporter ";
					if (
						(ex.Author != "")
						&& (ex.Author != "Quaxi")
						&& (ex.Author != "Emily")
					)
					{
						f += "by " + ex.Author + " ";
					}

					f += "(*" + ex.FileExtension + ")|*" + ex.FileExtension;
				}

				if (f == "")
				{
					Helper.ExceptionMessage(
						"",
						new Exception("There are no Exporter Plugins available!")
					);
					return;
				}
				sfd.Filter = f;
				//Make .obj the Default Extension
				sfd.FilterIndex = ExporterLoader.FindFirstIndexByExtension(defext) + 1;

				sfd.AddExtension = true;
				sfd.FileName = Helper.SaveFileName(
					Hashes.StripHashFromName(gmdc.Parent.FileName).Trim().ToLower()
				);
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					//Now perfor the Export
					IGmdcExporter exporter = ExporterLoader.Exporters[
						sfd.FilterIndex - 1
					];
					Helper.WindowsRegistry.GmdcExtension = exporter.FileExtension;
					exporter.Component.Sorting = sorting;
					exporter.CorrectJointSetup = corjoints;
					if (
						!sfd
							.FileName.Trim()
							.ToLower()
							.EndsWith(exporter.FileExtension.Trim().ToLower())
					)
					{
						sfd.FileName += exporter.FileExtension;
					}

					exporter.FileName = sfd.FileName;
					Stream s = exporter.Process(gmdc, groups);
					BinaryReader br = new BinaryReader(s);
					br.BaseStream.Seek(0, SeekOrigin.Begin);

					FileStream meshwriter = File.Create(exporter.FileName);
					meshwriter.Write(br.ReadBytes((int)s.Length), 0, (int)s.Length);

					//System.IO.StreamWriter meshwriter = File.CreateText(sfd.FileName);
					//meshwriter.Write(sr.ReadToEnd());
					meshwriter.Close();
					meshwriter.Dispose();
					meshwriter = null;
				}
			}
			catch (Exception exception1)
			{
				Helper.ExceptionMessage("", exception1);
				return;
			}
		}

		private void Export(object sender, EventArgs e)
		{
			try
			{
				if (tMesh.Tag != null)
				{
					GeometryDataContainer gmdc = (GeometryDataContainer)tMesh.Tag;
					StartExport(
						sfd,
						gmdc,
						Helper.WindowsRegistry.GmdcExtension,
						GetModelsExt(),
						(ElementSorting)cbaxis.Items[cbaxis.SelectedIndex],
						cbCorrect.Checked
					);
				}
			}
			catch (Exception exception1)
			{
				Helper.ExceptionMessage("", exception1);
				return;
			}
		}

		private void SeletAdvncdObject(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (tMesh.Tag != null)
			{
				GeometryDataContainer ext1 = (GeometryDataContainer)tMesh.Tag;
				pg.SelectedObject = ext1.Model;
			}
		}
	}
}
