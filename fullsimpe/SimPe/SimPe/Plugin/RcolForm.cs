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

using SimPe.Interfaces.Scenegraph;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for RcolForm.
	/// </summary>
	public class RcolForm : Windows.Forms.WrapperBaseControl
	{
		private LinkLabel llfix;
		private LinkLabel llhash;
		private TextBox tbflname;
		private Label label2;
		internal ComboBox cbitem;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		internal ListBox lbref;
		private TabControl childtc;
		private Panel pntypes;
		internal LinkLabel lladd;
		internal LinkLabel lldelete;
		internal TextBox tbsubtype;
		internal TextBox tbinstance;
		private Label label11;
		internal TextBox tbtype;
		private Label label8;
		private Label label9;
		private Label label10;
		internal TextBox tbgroup;
		internal ComboBox cbtypes;
		private Button btref;
		private System.Windows.Forms.TabPage tabPage3;
		private ListBox lbblocks;
		private Button btup;
		private Button btdown;
		private Button btadd;
		private Button btdel;
		private ComboBox cbblocks;
		private Label label1;
		internal System.Windows.Forms.TabPage tpref;
		internal TreeView tv;
		private Label label3;
		private Label label4;
		private TextBox tbrefgroup;
		private TextBox tbrefinst;
		private Label label5;
		private TextBox tbfile;
		private LinkLabel linkLabel1;
		internal TabControl tbResource;
		private Ambertation.Windows.Forms.XPTaskBoxSimple xpTaskBoxSimple1;
		private Ambertation.Windows.Forms.XPTaskBoxSimple xpTaskBoxSimple2;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RcolForm()
			: base()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();
			foreach (Interfaces.IAlias alias in Helper.TGILoader.FileTypes)
			{
				cbtypes.Items.Add(alias);
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				ClearControlTags();
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
			tbResource = new TabControl();
			tabPage1 = new System.Windows.Forms.TabPage();
			label2 = new Label();
			tbflname = new TextBox();
			childtc = new TabControl();
			label1 = new Label();
			llhash = new LinkLabel();
			llfix = new LinkLabel();
			cbitem = new ComboBox();
			tabPage2 = new System.Windows.Forms.TabPage();
			lbref = new ListBox();
			xpTaskBoxSimple2 = new Ambertation.Windows.Forms.XPTaskBoxSimple();
			pntypes = new Panel();
			lladd = new LinkLabel();
			lldelete = new LinkLabel();
			tbsubtype = new TextBox();
			tbinstance = new TextBox();
			label11 = new Label();
			tbtype = new TextBox();
			label8 = new Label();
			label9 = new Label();
			label10 = new Label();
			tbgroup = new TextBox();
			cbtypes = new ComboBox();
			btref = new Button();
			tabPage3 = new System.Windows.Forms.TabPage();
			btup = new Button();
			lbblocks = new ListBox();
			btdel = new Button();
			cbblocks = new ComboBox();
			btadd = new Button();
			btdown = new Button();
			tpref = new System.Windows.Forms.TabPage();
			tv = new TreeView();
			xpTaskBoxSimple1 = new Ambertation.Windows.Forms.XPTaskBoxSimple();
			label4 = new Label();
			label3 = new Label();
			tbfile = new TextBox();
			linkLabel1 = new LinkLabel();
			label5 = new Label();
			tbrefinst = new TextBox();
			tbrefgroup = new TextBox();
			tbResource.SuspendLayout();
			tabPage1.SuspendLayout();
			tabPage2.SuspendLayout();
			xpTaskBoxSimple2.SuspendLayout();
			pntypes.SuspendLayout();
			tabPage3.SuspendLayout();
			tpref.SuspendLayout();
			xpTaskBoxSimple1.SuspendLayout();
			SuspendLayout();
			//
			// tbResource
			//
			tbResource.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			tbResource.Controls.Add(tabPage1);
			tbResource.Controls.Add(tabPage2);
			tbResource.Controls.Add(tabPage3);
			tbResource.Controls.Add(tpref);
			tbResource.Location = new System.Drawing.Point(8, 32);
			tbResource.Name = "tbResource";
			tbResource.SelectedIndex = 0;
			tbResource.Size = new System.Drawing.Size(752, 261);
			tbResource.TabIndex = 20;
			tbResource.SelectedIndexChanged += new EventHandler(
				tabControl1_SelectedIndexChanged
			);
			//
			// tabPage1
			//
			tabPage1.Controls.Add(label2);
			tabPage1.Controls.Add(tbflname);
			tabPage1.Controls.Add(childtc);
			tabPage1.Controls.Add(label1);
			tabPage1.Controls.Add(llhash);
			tabPage1.Controls.Add(llfix);
			tabPage1.Controls.Add(cbitem);
			tabPage1.Location = new System.Drawing.Point(4, 24);
			tabPage1.Name = "tabPage1";
			tabPage1.Size = new System.Drawing.Size(744, 233);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "Content";
			tabPage1.UseVisualStyleBackColor = true;
			//
			// label2
			//
			label2.BackColor = System.Drawing.Color.Transparent;
			label2.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label2.Location = new System.Drawing.Point(8, 16);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(63, 17);
			label2.TabIndex = 8;
			label2.Text = "Blocklist:";
			label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
			tbflname.Location = new System.Drawing.Point(72, 32);
			tbflname.Name = "tbflname";
			tbflname.Size = new System.Drawing.Size(510, 23);
			tbflname.TabIndex = 9;
			tbflname.TextChanged += new EventHandler(ChangeFileName);
			//
			// childtc
			//
			childtc.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			childtc.Location = new System.Drawing.Point(8, 64);
			childtc.Multiline = true;
			childtc.Name = "childtc";
			childtc.SelectedIndex = 0;
			childtc.Size = new System.Drawing.Size(728, 166);
			childtc.TabIndex = 20;
			childtc.SelectedIndexChanged += new EventHandler(
				ChildTabPageChanged
			);
			//
			// label1
			//
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label1.Location = new System.Drawing.Point(8, 34);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(63, 17);
			label1.TabIndex = 21;
			label1.Text = "Filename:";
			label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// llhash
			//
			llhash.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			llhash.AutoSize = true;
			llhash.BackColor = System.Drawing.Color.Transparent;
			llhash.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			llhash.Location = new System.Drawing.Point(664, 40);
			llhash.Name = "llhash";
			llhash.Size = new System.Drawing.Size(74, 13);
			llhash.TabIndex = 18;
			llhash.TabStop = true;
			llhash.Text = "assign Hash";
			llhash.Visible = false;
			llhash.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					BuildFilename
				);
			//
			// llfix
			//
			llfix.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			llfix.AutoSize = true;
			llfix.BackColor = System.Drawing.Color.Transparent;
			llfix.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			llfix.Location = new System.Drawing.Point(608, 40);
			llfix.Name = "llfix";
			llfix.Size = new System.Drawing.Size(44, 13);
			llfix.TabIndex = 19;
			llfix.TabStop = true;
			llfix.Text = "fix TGI";
			llfix.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(FixTGI);
			//
			// cbitem
			//
			cbitem.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			cbitem.DropDownStyle = ComboBoxStyle.DropDownList;
			cbitem.Location = new System.Drawing.Point(72, 8);
			cbitem.Name = "cbitem";
			cbitem.Size = new System.Drawing.Size(664, 23);
			cbitem.TabIndex = 7;
			cbitem.SelectedIndexChanged += new EventHandler(
				SelectRcolItem
			);
			//
			// tabPage2
			//
			tabPage2.Controls.Add(lbref);
			tabPage2.Controls.Add(xpTaskBoxSimple2);
			tabPage2.Location = new System.Drawing.Point(4, 22);
			tabPage2.Name = "tabPage2";
			tabPage2.Size = new System.Drawing.Size(744, 233);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "Reference";
			tabPage2.UseVisualStyleBackColor = true;
			//
			// lbref
			//
			lbref.AllowDrop = true;
			lbref.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			lbref.BorderStyle = BorderStyle.None;
			lbref.IntegralHeight = false;
			lbref.Location = new System.Drawing.Point(0, 0);
			lbref.Name = "lbref";
			lbref.Size = new System.Drawing.Size(288, 233);
			lbref.TabIndex = 0;
			lbref.DragEnter += new DragEventHandler(
				PackageItemDragEnter
			);
			lbref.DragDrop += new DragEventHandler(
				PackageItemDrop
			);
			lbref.SelectedIndexChanged += new EventHandler(
				SelectReference
			);
			//
			// xpTaskBoxSimple2
			//
			xpTaskBoxSimple2.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			xpTaskBoxSimple2.BackColor = System.Drawing.Color.Transparent;
			xpTaskBoxSimple2.BodyColor = System.Drawing.SystemColors.ControlLight;
			xpTaskBoxSimple2.BorderColor = System
				.Drawing
				.SystemColors
				.ControlDarkDark;
			xpTaskBoxSimple2.Controls.Add(pntypes);
			xpTaskBoxSimple2.Controls.Add(btref);
			xpTaskBoxSimple2.HeaderFont = new System.Drawing.Font(
				"Microsoft Sans Serif",
				10.25F,
				System.Drawing.FontStyle.Bold
			);
			xpTaskBoxSimple2.HeaderText = "Settings";
			xpTaskBoxSimple2.HeaderTextColor = System
				.Drawing
				.SystemColors
				.ControlText;
			xpTaskBoxSimple2.IconLocation = new System.Drawing.Point(4, 12);
			xpTaskBoxSimple2.IconSize = new System.Drawing.Size(32, 32);
			xpTaskBoxSimple2.LeftHeaderColor = System
				.Drawing
				.SystemColors
				.ControlDark;
			xpTaskBoxSimple2.Location = new System.Drawing.Point(296, 0);
			xpTaskBoxSimple2.Name = "xpTaskBoxSimple2";
			xpTaskBoxSimple2.Padding = new Padding(
				4,
				44,
				4,
				4
			);
			xpTaskBoxSimple2.RightHeaderColor = System
				.Drawing
				.SystemColors
				.ControlDark;
			xpTaskBoxSimple2.Size = new System.Drawing.Size(440, 152);
			xpTaskBoxSimple2.TabIndex = 43;
			//
			// pntypes
			//
			pntypes.Controls.Add(lladd);
			pntypes.Controls.Add(lldelete);
			pntypes.Controls.Add(tbsubtype);
			pntypes.Controls.Add(tbinstance);
			pntypes.Controls.Add(label11);
			pntypes.Controls.Add(tbtype);
			pntypes.Controls.Add(label8);
			pntypes.Controls.Add(label9);
			pntypes.Controls.Add(label10);
			pntypes.Controls.Add(tbgroup);
			pntypes.Controls.Add(cbtypes);
			pntypes.Location = new System.Drawing.Point(8, 48);
			pntypes.Name = "pntypes";
			pntypes.Size = new System.Drawing.Size(424, 96);
			pntypes.TabIndex = 19;
			//
			// lladd
			//
			lladd.AutoSize = true;
			lladd.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lladd.ImeMode = ImeMode.NoControl;
			lladd.LinkArea = new LinkArea(0, 9);
			lladd.Location = new System.Drawing.Point(344, 80);
			lladd.Name = "lladd";
			lladd.Size = new System.Drawing.Size(25, 18);
			lladd.TabIndex = 19;
			lladd.TabStop = true;
			lladd.Text = "add";
			lladd.UseCompatibleTextRendering = true;
			lladd.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					SRNItemsAAdd
				);
			//
			// lldelete
			//
			lldelete.AutoSize = true;
			lldelete.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lldelete.ImeMode = ImeMode.NoControl;
			lldelete.LinkArea = new LinkArea(0, 7);
			lldelete.Location = new System.Drawing.Point(372, 80);
			lldelete.Name = "lldelete";
			lldelete.Size = new System.Drawing.Size(40, 18);
			lldelete.TabIndex = 18;
			lldelete.TabStop = true;
			lldelete.Text = "delete";
			lldelete.UseCompatibleTextRendering = true;
			lldelete.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					SRNItemsADelete
				);
			//
			// tbsubtype
			//
			tbsubtype.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbsubtype.Location = new System.Drawing.Point(72, 24);
			tbsubtype.Name = "tbsubtype";
			tbsubtype.Size = new System.Drawing.Size(100, 21);
			tbsubtype.TabIndex = 12;
			tbsubtype.TextChanged += new EventHandler(
				AutoChangeReference
			);
			//
			// tbinstance
			//
			tbinstance.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbinstance.Location = new System.Drawing.Point(72, 72);
			tbinstance.Name = "tbinstance";
			tbinstance.Size = new System.Drawing.Size(100, 21);
			tbinstance.TabIndex = 14;
			tbinstance.TextChanged += new EventHandler(
				AutoChangeReference
			);
			//
			// label11
			//
			label11.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label11.ImeMode = ImeMode.NoControl;
			label11.Location = new System.Drawing.Point(8, 80);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(60, 17);
			label11.TabIndex = 10;
			label11.Text = "Instance:";
			label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// tbtype
			//
			tbtype.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbtype.Location = new System.Drawing.Point(72, 0);
			tbtype.Name = "tbtype";
			tbtype.Size = new System.Drawing.Size(100, 21);
			tbtype.TabIndex = 11;
			tbtype.TextChanged += new EventHandler(tbtype_TextChanged);
			//
			// label8
			//
			label8.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label8.ImeMode = ImeMode.NoControl;
			label8.Location = new System.Drawing.Point(8, 8);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(60, 17);
			label8.TabIndex = 7;
			label8.Text = "File Type:";
			label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// label9
			//
			label9.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label9.ImeMode = ImeMode.NoControl;
			label9.Location = new System.Drawing.Point(8, 56);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(60, 17);
			label9.TabIndex = 8;
			label9.Text = "Group:";
			label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// label10
			//
			label10.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label10.ImeMode = ImeMode.NoControl;
			label10.Location = new System.Drawing.Point(8, 32);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(60, 17);
			label10.TabIndex = 9;
			label10.Text = "Sub Typ:";
			label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// tbgroup
			//
			tbgroup.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbgroup.Location = new System.Drawing.Point(72, 48);
			tbgroup.Name = "tbgroup";
			tbgroup.Size = new System.Drawing.Size(100, 21);
			tbgroup.TabIndex = 13;
			tbgroup.TextChanged += new EventHandler(
				AutoChangeReference
			);
			//
			// cbtypes
			//
			cbtypes.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbtypes.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbtypes.ItemHeight = 13;
			cbtypes.Location = new System.Drawing.Point(176, 0);
			cbtypes.Name = "cbtypes";
			cbtypes.Size = new System.Drawing.Size(240, 21);
			cbtypes.Sorted = true;
			cbtypes.TabIndex = 16;
			cbtypes.SelectedIndexChanged += new EventHandler(
				SelectType
			);
			//
			// btref
			//
			btref.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			btref.FlatStyle = FlatStyle.Popup;
			btref.Font = new System.Drawing.Font(
				"Microsoft Sans Serif",
				8.25F,
				System.Drawing.FontStyle.Bold
			);
			btref.ForeColor = System.Drawing.SystemColors.Window;
			btref.ImeMode = ImeMode.NoControl;
			btref.Location = new System.Drawing.Point(408, 17);
			btref.Name = "btref";
			btref.Size = new System.Drawing.Size(21, 21);
			btref.TabIndex = 42;
			btref.Text = "u";
			btref.Click += new EventHandler(ShowPackageSelector);
			//
			// tabPage3
			//
			tabPage3.Controls.Add(btup);
			tabPage3.Controls.Add(lbblocks);
			tabPage3.Controls.Add(btdel);
			tabPage3.Controls.Add(cbblocks);
			tabPage3.Controls.Add(btadd);
			tabPage3.Controls.Add(btdown);
			tabPage3.Location = new System.Drawing.Point(4, 22);
			tabPage3.Name = "tabPage3";
			tabPage3.Size = new System.Drawing.Size(744, 233);
			tabPage3.TabIndex = 2;
			tabPage3.Text = "Edit Blocks";
			tabPage3.UseVisualStyleBackColor = true;
			//
			// btup
			//
			btup.FlatStyle = FlatStyle.System;
			btup.Location = new System.Drawing.Point(384, 16);
			btup.Name = "btup";
			btup.Size = new System.Drawing.Size(48, 23);
			btup.TabIndex = 1;
			btup.Text = "Up";
			btup.Click += new EventHandler(btup_Click);
			//
			// lbblocks
			//
			lbblocks.BorderStyle = BorderStyle.None;
			lbblocks.Dock = DockStyle.Left;
			lbblocks.HorizontalScrollbar = true;
			lbblocks.IntegralHeight = false;
			lbblocks.Location = new System.Drawing.Point(0, 0);
			lbblocks.Name = "lbblocks";
			lbblocks.Size = new System.Drawing.Size(549, 233);
			lbblocks.TabIndex = 0;
			lbblocks.SelectedIndexChanged += new EventHandler(
				lbblocks_SelectedIndexChanged
			);
			//
			// btup
			//
			btup.Enabled = false;
			btup.FlatStyle = FlatStyle.System;
			btup.Location = new System.Drawing.Point(555, 3);
			btup.Name = "btup";
			btup.Size = new System.Drawing.Size(48, 23);
			btup.TabIndex = 1;
			btup.Text = "Up";
			btup.Click += new EventHandler(btup_Click);
			//
			// cbblocks
			//
			cbblocks.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			cbblocks.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbblocks.Location = new System.Drawing.Point(555, 127);
			cbblocks.Name = "cbblocks";
			cbblocks.Size = new System.Drawing.Size(183, 21);
			cbblocks.Sorted = true;
			cbblocks.TabIndex = 5;
			//
			// btadd
			//
			btadd.FlatStyle = FlatStyle.System;
			btadd.Location = new System.Drawing.Point(555, 96);
			btadd.Name = "btadd";
			btadd.Size = new System.Drawing.Size(72, 23);
			btadd.TabIndex = 3;
			btadd.Text = "Add";
			btadd.Click += new EventHandler(btadd_Click);
			//
			// btdown
			//
			btdown.Enabled = false;
			btdown.FlatStyle = FlatStyle.System;
			btdown.Location = new System.Drawing.Point(555, 34);
			btdown.Name = "btdown";
			btdown.Size = new System.Drawing.Size(48, 23);
			btdown.TabIndex = 2;
			btdown.Text = "Down";
			btdown.Click += new EventHandler(btdown_Click);
			//
			// btdel
			//
			btdel.Enabled = false;
			btdel.FlatStyle = FlatStyle.System;
			btdel.Location = new System.Drawing.Point(555, 65);
			btdel.Name = "btdel";
			btdel.Size = new System.Drawing.Size(72, 23);
			btdel.TabIndex = 4;
			btdel.Text = "Delete";
			btdel.Click += new EventHandler(btdel_Click);
			//
			// tpref
			//
			tpref.Controls.Add(xpTaskBoxSimple1);
			tpref.Controls.Add(tv);
			tpref.Location = new System.Drawing.Point(4, 22);
			tpref.Name = "tpref";
			tpref.Size = new System.Drawing.Size(744, 233);
			tpref.TabIndex = 3;
			tpref.Text = "All References";
			tpref.UseVisualStyleBackColor = true;
			//
			// xpTaskBoxSimple1
			//
			xpTaskBoxSimple1.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			xpTaskBoxSimple1.BackColor = System.Drawing.Color.Transparent;
			xpTaskBoxSimple1.BodyColor = System.Drawing.SystemColors.ControlLight;
			xpTaskBoxSimple1.BorderColor = System
				.Drawing
				.SystemColors
				.ControlDarkDark;
			xpTaskBoxSimple1.Controls.Add(label4);
			xpTaskBoxSimple1.Controls.Add(label3);
			xpTaskBoxSimple1.Controls.Add(tbfile);
			xpTaskBoxSimple1.Controls.Add(linkLabel1);
			xpTaskBoxSimple1.Controls.Add(label5);
			xpTaskBoxSimple1.Controls.Add(tbrefinst);
			xpTaskBoxSimple1.Controls.Add(tbrefgroup);
			xpTaskBoxSimple1.HeaderFont = new System.Drawing.Font(
				"Microsoft Sans Serif",
				10.25F,
				System.Drawing.FontStyle.Bold
			);
			xpTaskBoxSimple1.HeaderText = "Values";
			xpTaskBoxSimple1.HeaderTextColor = System
				.Drawing
				.SystemColors
				.ControlText;
			xpTaskBoxSimple1.IconLocation = new System.Drawing.Point(4, 12);
			xpTaskBoxSimple1.IconSize = new System.Drawing.Size(32, 32);
			xpTaskBoxSimple1.LeftHeaderColor = System
				.Drawing
				.SystemColors
				.ControlDark;
			xpTaskBoxSimple1.Location = new System.Drawing.Point(296, 0);
			xpTaskBoxSimple1.Name = "xpTaskBoxSimple1";
			xpTaskBoxSimple1.Padding = new Padding(
				4,
				44,
				4,
				4
			);
			xpTaskBoxSimple1.RightHeaderColor = System
				.Drawing
				.SystemColors
				.ControlDark;
			xpTaskBoxSimple1.Size = new System.Drawing.Size(440, 152);
			xpTaskBoxSimple1.TabIndex = 2;
			//
			// label4
			//
			label4.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label4.Location = new System.Drawing.Point(16, 80);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(56, 17);
			label4.TabIndex = 1;
			label4.Text = "Instance:";
			label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// label3
			//
			label3.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label3.Location = new System.Drawing.Point(16, 56);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 0;
			label3.Text = "Group:";
			label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// tbfile
			//
			tbfile.BackColor = System.Drawing.SystemColors.ControlLightLight;
			tbfile.Font = new System.Drawing.Font(
				"Tahoma",
				9.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbfile.Location = new System.Drawing.Point(16, 120);
			tbfile.Name = "tbfile";
			tbfile.ReadOnly = true;
			tbfile.Size = new System.Drawing.Size(406, 22);
			tbfile.TabIndex = 4;
			//
			// linkLabel1
			//
			linkLabel1.AutoSize = true;
			linkLabel1.Location = new System.Drawing.Point(40, 104);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(43, 13);
			linkLabel1.TabIndex = 6;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "reload";
			linkLabel1.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					linkLabel1_LinkClicked
				);
			//
			// label5
			//
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label5.Location = new System.Drawing.Point(8, 104);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(27, 13);
			label5.TabIndex = 5;
			label5.Text = "File:";
			//
			// tbrefinst
			//
			tbrefinst.BackColor = System.Drawing.SystemColors.ControlLightLight;
			tbrefinst.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbrefinst.Location = new System.Drawing.Point(80, 80);
			tbrefinst.Name = "tbrefinst";
			tbrefinst.ReadOnly = true;
			tbrefinst.Size = new System.Drawing.Size(88, 21);
			tbrefinst.TabIndex = 3;
			tbrefinst.Text = "0x00000000";
			//
			// tbrefgroup
			//
			tbrefgroup.BackColor = System.Drawing.SystemColors.ControlLightLight;
			tbrefgroup.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbrefgroup.Location = new System.Drawing.Point(80, 48);
			tbrefgroup.Name = "tbrefgroup";
			tbrefgroup.ReadOnly = true;
			tbrefgroup.Size = new System.Drawing.Size(88, 21);
			tbrefgroup.TabIndex = 2;
			tbrefgroup.Text = "0x00000000";
			//
			// RcolForm
			//
			Controls.Add(tbResource);
			HeaderText = "Generic Rcol Editor";
			Location = new System.Drawing.Point(48, 32);
			Name = "RcolForm";
			Size = new System.Drawing.Size(768, 301);
			Commited += new EventHandler(Commit);
			Controls.SetChildIndex(tbResource, 0);
			tbResource.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage1.PerformLayout();
			tabPage2.ResumeLayout(false);
			xpTaskBoxSimple2.ResumeLayout(false);
			pntypes.ResumeLayout(false);
			pntypes.PerformLayout();
			tabPage3.ResumeLayout(false);
			tpref.ResumeLayout(false);
			xpTaskBoxSimple1.ResumeLayout(false);
			xpTaskBoxSimple1.PerformLayout();
			ResumeLayout(false);
		}
		#endregion

		internal Rcol wrapper = null;

		internal void BuildChildTabControl(AbstractRcolBlock rb)
		{
			childtc.TabPages.Clear();

			if (rb == null)
			{
				return;
			}

			if (rb.TabPage != null)
			{
				rb.AddToTabControl(childtc);
			}
		}

		private void SelectRcolItem(object sender, EventArgs e)
		{
			if (cbitem.Tag != null)
			{
				return;
			}

			if (cbitem.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				cbitem.Tag = true;
				CountedListItem cli = (CountedListItem)
					cbitem.Items[cbitem.SelectedIndex];
				AbstractRcolBlock rb = (AbstractRcolBlock)cli.Object;
				tbflname.Enabled = (rb.NameResource != null);
				llhash.Enabled = tbflname.Enabled;
				llfix.Enabled = tbflname.Enabled;

				if (rb.NameResource != null)
				{
					tbflname.Text = rb.NameResource.FileName;
				}
				else
				{
					tbflname.Text = "";
				}

				BuildChildTabControl(rb);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				cbitem.Tag = null;
			}
		}

		private void ChangeFileName(object sender, EventArgs e)
		{
			if (cbitem.Tag != null)
			{
				return;
			}

			if (cbitem.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				cbitem.Tag = true;
				CountedListItem cli = (CountedListItem)
					cbitem.Items[cbitem.SelectedIndex];
				AbstractRcolBlock rb = (AbstractRcolBlock)cli.Object;
				if (rb.NameResource != null)
				{
					rb.NameResource.FileName = tbflname.Text;
					cbitem.Items[cbitem.SelectedIndex] = cli;
					cbitem.Text = cli.ToString();
				}
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("erropenfile"),
					ex
				);
			}
			finally
			{
				cbitem.Tag = null;
			}
		}

		private void BuildFilename(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			string fl = Hashes.StripHashFromName(tbflname.Text);
			tbflname.Text = Hashes.AssembleHashedFileName(
				wrapper.Package.FileGroupHash,
				fl
			);
		}

		private void FixTGI(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			string fl = Hashes.StripHashFromName(tbflname.Text);
			if (wrapper != null)
			{
				if (wrapper.FileDescriptor != null)
				{
					wrapper.FileDescriptor.Instance = Hashes.InstanceHash(fl);
					wrapper.FileDescriptor.SubType = Hashes.SubTypeHash(fl);
				}
			}
		}

		private void Commit(object sender, EventArgs e)
		{
			try
			{
				wrapper.SynchronizeUserData();
				MessageBox.Show(Localization.Manager.GetString("commited"));
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("errwritingfile"),
					ex
				);
			}
		}

		private void SelectType(object sender, EventArgs e)
		{
			if (cbtypes.Tag != null)
			{
				return;
			}

			tbtype.Text =
				"0x"
				+ Helper.HexString(
					((Data.TypeAlias)cbtypes.Items[cbtypes.SelectedIndex]).Id
				);
		}

		protected void Change()
		{
			if (lbref.Tag != null)
			{
				return;
			}

			if (lbref.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				lbref.Tag = true;
				Interfaces.Files.IPackedFileDescriptor pfd =
					(Interfaces.Files.IPackedFileDescriptor)
						lbref.Items[lbref.SelectedIndex];

				pfd.Type = Convert.ToUInt32(tbtype.Text, 16);
				pfd.SubType = Convert.ToUInt32(tbsubtype.Text, 16);
				pfd.Group = Convert.ToUInt32(tbgroup.Text, 16);
				pfd.Instance = Convert.ToUInt32(tbinstance.Text, 16);

				lbref.Items[lbref.SelectedIndex] = pfd;
			}
			catch (Exception)
			{
				//Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lbref.Tag = null;
			}
		}

		private void tbtype_TextChanged(object sender, EventArgs e)
		{
			Change();

			cbtypes.Tag = true;
			Data.TypeAlias a = Data.MetaData.FindTypeAlias(
				Helper.HexStringToUInt(tbtype.Text)
			);

			int ct = 0;
			foreach (Data.TypeAlias i in cbtypes.Items)
			{
				if (i == a)
				{
					cbtypes.SelectedIndex = ct;
					cbtypes.Tag = null;
					return;
				}
				ct++;
			}

			cbtypes.SelectedIndex = -1;
			cbtypes.Tag = null;
		}

		private void SelectReference(object sender, EventArgs e)
		{
			if (lbref.Tag != null)
			{
				return;
			}

			if (lbref.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				lbref.Tag = true;
				Interfaces.Files.IPackedFileDescriptor pfd =
					(Interfaces.Files.IPackedFileDescriptor)
						lbref.Items[lbref.SelectedIndex];
				tbtype.Text = "0x" + Helper.HexString(pfd.Type);
				tbsubtype.Text = "0x" + Helper.HexString(pfd.SubType);
				tbgroup.Text = "0x" + Helper.HexString(pfd.Group);
				tbinstance.Text = "0x" + Helper.HexString(pfd.Instance);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lbref.Tag = null;
			}
		}

		private void AutoChangeReference(object sender, EventArgs e)
		{
			Change();
		}

		private void SRNItemsAAdd(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			try
			{
				Interfaces.Files.IPackedFileDescriptor pfd =
					new Packages.PackedFileDescriptor
					{
						Type = Convert.ToUInt32(tbtype.Text, 16),
						SubType = Convert.ToUInt32(tbsubtype.Text, 16),
						Group = Convert.ToUInt32(tbgroup.Text, 16),
						Instance = Convert.ToUInt32(tbinstance.Text, 16)
					};

				wrapper.ReferencedFiles = (Interfaces.Files.IPackedFileDescriptor[])
					Helper.Add(wrapper.ReferencedFiles, pfd);
				lbref.Items.Add(pfd);

				wrapper.Changed = true;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}

		private void SRNItemsADelete(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (lbref.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				Interfaces.Files.IPackedFileDescriptor pfd =
					(Interfaces.Files.IPackedFileDescriptor)
						lbref.Items[lbref.SelectedIndex];

				wrapper.ReferencedFiles = (Interfaces.Files.IPackedFileDescriptor[])
					Helper.Delete(wrapper.ReferencedFiles, pfd);
				lbref.Items.Remove(pfd);

				wrapper.Changed = true;

				btup.Enabled = btdown.Enabled = btdel.Enabled = false;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}

		#region Package Selector
		private void ShowPackageSelector(object sender, EventArgs e)
		{
			PackageSelectorForm form = new PackageSelectorForm();
			form.Execute(wrapper.Package);
		}

		private void ItemQueryContinueDragTarget(
			object sender,
			QueryContinueDragEventArgs e
		)
		{
			if (e.KeyState == 0)
			{
				e.Action = DragAction.Drop;
			}
			else
			{
				e.Action = DragAction.Continue;
			}
		}

		private void PackageItemDragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(Packages.PackedFileDescriptor)))
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void PackageItemDrop(
			object sender,
			DragEventArgs e
		)
		{
			try
			{
				lbref.Tag = true;
				Interfaces.Files.IPackedFileDescriptor pfd = null;
				pfd = (Interfaces.Files.IPackedFileDescriptor)
					e.Data.GetData(typeof(Packages.PackedFileDescriptor));

				wrapper.ReferencedFiles = (Interfaces.Files.IPackedFileDescriptor[])
					Helper.Add(wrapper.ReferencedFiles, pfd);
				lbref.Items.Add(pfd);

				wrapper.Changed = true;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lbref.Tag = null;
			}
		}
		#endregion

		protected void UpdateComboBox()
		{
			cbitem.Items.Clear();

			tbflname.Text = "";
			childtc.TabPages.Clear();
			foreach (CountedListItem o in lbblocks.Items)
			{
				cbitem.Items.Add(o);
			}

			if (cbitem.Items.Count > 0)
			{
				cbitem.SelectedIndex = 0;
			}
		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			//Display the Block Editor
			if (tbResource.TabPages[tbResource.SelectedIndex] == tabPage3)
			{
				lbblocks.Items.Clear();
				foreach (IRcolBlock irb in wrapper.Blocks)
				{
					CountedListItem.AddHex(lbblocks, irb);
				}

				cbblocks.Items.Clear();
				foreach (string s in Rcol.Tokens.Keys)
				{
					try
					{
						Type t = (Type)Rcol.Tokens[s];
						IRcolBlock irb = AbstractRcolBlock.Create(t, null);
						cbblocks.Items.Add(irb);
					}
					catch (Exception ex)
					{
						Helper.ExceptionMessage("Error in Block " + s, ex);
					}
				} //foreach
				if (cbblocks.Items.Count > 0)
				{
					cbblocks.SelectedIndex = 0;
				}
			}
		}

		private void btup_Click(object sender, EventArgs e)
		{
			if (lbblocks.SelectedIndex < 1)
			{
				return;
			}

			try
			{
				object o = lbblocks.Items[lbblocks.SelectedIndex - 1];
				lbblocks.Items[lbblocks.SelectedIndex - 1] = lbblocks.Items[
					lbblocks.SelectedIndex
				];
				lbblocks.Items[lbblocks.SelectedIndex] = o;

				wrapper.Blocks[lbblocks.SelectedIndex] = (AbstractRcolBlock)
					(
						(CountedListItem)lbblocks.Items[lbblocks.SelectedIndex]
					).Object;
				wrapper.Blocks[lbblocks.SelectedIndex - 1] = (AbstractRcolBlock)
					(
						(CountedListItem)
							lbblocks.Items[lbblocks.SelectedIndex - 1]
					).Object;
				lbblocks.SelectedIndex--;

				UpdateComboBox();
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}

		private void btdown_Click(object sender, EventArgs e)
		{
			if (lbblocks.SelectedIndex < 0)
			{
				return;
			}

			if (lbblocks.SelectedIndex > lbblocks.Items.Count - 2)
			{
				return;
			}

			try
			{
				object o = lbblocks.Items[lbblocks.SelectedIndex + 1];
				lbblocks.Items[lbblocks.SelectedIndex + 1] = lbblocks.Items[
					lbblocks.SelectedIndex
				];
				lbblocks.Items[lbblocks.SelectedIndex] = o;
				wrapper.Blocks[lbblocks.SelectedIndex] = (AbstractRcolBlock)
					(
						(CountedListItem)lbblocks.Items[lbblocks.SelectedIndex]
					).Object;
				wrapper.Blocks[lbblocks.SelectedIndex + 1] = (AbstractRcolBlock)
					(
						(CountedListItem)
							lbblocks.Items[lbblocks.SelectedIndex + 1]
					).Object;
				lbblocks.SelectedIndex++;

				UpdateComboBox();
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}

		private void btadd_Click(object sender, EventArgs e)
		{
			try
			{
				//SimPe.CountedListItem cli = (SimPe.CountedListItem);
				IRcolBlock irb = (
					(IRcolBlock)cbblocks.Items[cbblocks.SelectedIndex]
				).Create();
				if (irb is AbstractRcolBlock)
				{
					((AbstractRcolBlock)irb).Parent = wrapper;
				}

				CountedListItem.AddHex(lbblocks, irb);
				wrapper.Blocks = (IRcolBlock[])
					Helper.Add(wrapper.Blocks, irb, typeof(IRcolBlock));
				UpdateComboBox();
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}

		private void lbblocks_SelectedIndexChanged(object sender, EventArgs e)
		{
			btup.Enabled = btdown.Enabled = btdel.Enabled = false;
			if (lbblocks.SelectedIndex < 0)
			{
				return;
			}

			btup.Enabled = btdown.Enabled = btdel.Enabled = true;
		}

		private void btdel_Click(object sender, EventArgs e)
		{
			if (lbblocks.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				CountedListItem cli = (CountedListItem)
					lbblocks.Items[lbblocks.SelectedIndex];
				IRcolBlock irb = ((IRcolBlock)cli.Object);
				lbblocks.Items.Remove(cli);
				wrapper.Blocks = (IRcolBlock[])
					Helper.Delete(wrapper.Blocks, irb, typeof(IRcolBlock));

				UpdateComboBox();
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}

		private void SelectRefItem(
			object sender,
			TreeViewEventArgs e
		)
		{
			if (e.Node.Tag != null)
			{
				Interfaces.Files.IPackedFileDescriptor pfd =
					(Interfaces.Files.IPackedFileDescriptor)e.Node.Tag;
				tbrefgroup.Text = "0x" + Helper.HexString(pfd.Group);
				tbrefinst.Text = "0x" + Helper.HexString(pfd.Instance);

				FileTableBase.FileIndex.Load();
				IScenegraphFileIndexItem[] items =
					FileTableBase.FileIndex.FindFile(pfd, null);
				if (items.Length == 0)
				{
					IScenegraphFileIndexItem item =
						FileTableBase.FileIndex.FindFileByName(
							pfd.Filename,
							pfd.Type,
							pfd.Group,
							true
						);
					if (item != null)
					{
						items =
							new IScenegraphFileIndexItem[1];
						items[0] = item;
					}
				}
				if (items.Length == 0)
				{
					Interfaces.Files.IPackedFileDescriptor npfd =
						pfd.Clone();
					npfd.SubType = 0;
					items = FileTableBase.FileIndex.FindFile(npfd, null);
				}

				if (items.Length > 0)
				{
					tbfile.Text = items[0].Package.FileName;
				}
				else
				{
					tbfile.Text = "[unreferenced]";
				}
			}
		}

		private void linkLabel1_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			WaitingScreen.Wait();
			try
			{
				FileTableBase.FileIndex.ForceReload();
			}
			finally
			{
				WaitingScreen.Stop();
			}
		}

		private void ChildTabPageChanged(object sender, EventArgs e)
		{
			wrapper.ChildTabPageChanged(this, e);
		}

		/*private void ChildTabPageChanged(object sender, System.EventArgs e)
		{
			if (lbblocks.SelectedIndex<0) return;
			try
			{
				IRcolBlock irb = (IRcolBlock)lbblocks.Items[lbblocks.SelectedIndex];
				this.lbblocks.Items.Remove(irb);
				wrapper.Blocks = (IRcolBlock[])Helper.Delete(wrapper.Blocks, irb, typeof(IRcolBlock));

				UpdateComboBox();
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}*/

		void ClearControlTags(Control c)
		{
			foreach (Control cc in c.Controls)
			{
				cc.Tag = null;
				ClearControlTags(cc);
			}
		}

		internal void ClearControlTags()
		{
			if (Controls == null)
			{
				return;
			}

			ClearControlTags(this);
		}
	}
}
