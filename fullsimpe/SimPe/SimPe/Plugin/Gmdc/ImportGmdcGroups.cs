// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimPe.Plugin.Gmdc
{
	/// <summary>
	/// The Form that is displayed when a Meshgroup is imported
	/// </summary>
	internal class ImportGmdcGroupsForm : Form
	{
		private Label label1;
		private ColumnHeader chName;
		private ColumnHeader chAction;
		private ColumnHeader chTarget;
		private ListView lv;
		private Label label2;
		private Label label3;
		private Label lbname;
		private ComboBox cbaction;
		private TextBox tbname;
		private ComboBox cbnames;
		private Button button1;
		private ColumnHeader chVertex;
		private ColumnHeader chFace;
		private Label label4;
		private TextBox tbscale;
		private Label label5;
		private ComboBox cbopacity;
		private ColumnHeader chBones;
		private Label label9;
		private Label label10;
		private ComboBox cbboneaction;
		private Label lbbonename;
		private ComboBox cbbones;
		private CheckBox cbcleanbn;
		private CheckBox cbcleangrp;
		private CheckBox cbupdatecres;
		private Panel Gradientpanel1;
		private GroupBox gbbones;
		private GroupBox gbgroups;
		private GroupBox gbsettings;
		private CheckBox cbBMesh;
		private ColumnHeader chBMesh;
		private Label label6;
		private Label lbKeepOrder;

		/// <summary>
		/// Needed Designervar.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public ImportGmdcGroupsForm()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			GmdcImporterAction[] actions = (GmdcImporterAction[])
				Enum.GetValues(typeof(GmdcImporterAction));
			foreach (GmdcImporterAction a in actions)
			{
				cbaction.Items.Add(a);
			}

			//cbboneaction.Items.Add(GmdcImporterAction.Nothing);
			cbboneaction.Items.Add(GmdcImporterAction.Add);
			cbboneaction.Items.Add(GmdcImporterAction.Replace);
			cbboneaction.Items.Add(GmdcImporterAction.Update);
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
					typeof(ImportGmdcGroupsForm)
				);
			lv = new ListView();
			chName = new ColumnHeader();
			chAction = new ColumnHeader();
			chTarget = new ColumnHeader();
			chVertex = new ColumnHeader();
			chFace = new ColumnHeader();
			chBones = new ColumnHeader();
			chBMesh = new ColumnHeader();
			label1 = new Label();
			cbopacity = new ComboBox();
			label5 = new Label();
			tbscale = new TextBox();
			label4 = new Label();
			cbaction = new ComboBox();
			lbname = new Label();
			label3 = new Label();
			label2 = new Label();
			cbnames = new ComboBox();
			tbname = new TextBox();
			button1 = new Button();
			cbboneaction = new ComboBox();
			lbbonename = new Label();
			label9 = new Label();
			label10 = new Label();
			cbbones = new ComboBox();
			cbupdatecres = new CheckBox();
			cbcleanbn = new CheckBox();
			cbcleangrp = new CheckBox();
			Gradientpanel1 = new Panel();
			gbbones = new GroupBox();
			gbgroups = new GroupBox();
			lbKeepOrder = new Label();
			label6 = new Label();
			cbBMesh = new CheckBox();
			gbsettings = new GroupBox();
			Gradientpanel1.SuspendLayout();
			gbbones.SuspendLayout();
			gbgroups.SuspendLayout();
			gbsettings.SuspendLayout();
			SuspendLayout();
			//
			// lv
			//
			lv.Anchor =




								AnchorStyles.Top
								| AnchorStyles.Bottom
							 | AnchorStyles.Left
						 | AnchorStyles.Right


			;
			lv.BorderStyle = BorderStyle.None;
			lv.Columns.AddRange(
				new ColumnHeader[]
				{
					chName,
					chAction,
					chTarget,
					chVertex,
					chFace,
					chBones,
					chBMesh,
				}
			);
			lv.FullRowSelect = true;
			lv.HeaderStyle = ColumnHeaderStyle.Nonclickable;
			lv.HideSelection = false;
			lv.Location = new System.Drawing.Point(8, 32);
			lv.Name = "lv";
			lv.Size = new System.Drawing.Size(680, 435);
			lv.TabIndex = 0;
			lv.UseCompatibleStateImageBehavior = false;
			lv.View = View.Details;
			lv.SelectedIndexChanged += new EventHandler(
				listView1_SelectedIndexChanged
			);
			//
			// chName
			//
			chName.Text = "Name";
			chName.Width = 148;
			//
			// chAction
			//
			chAction.Text = "Action";
			chAction.Width = 71;
			//
			// chTarget
			//
			chTarget.Text = "Target";
			chTarget.Width = 114;
			//
			// chVertex
			//
			chVertex.Text = "Vertices/Parent Bone";
			chVertex.TextAlign = HorizontalAlignment.Right;
			chVertex.Width = 140;
			//
			// chFace
			//
			chFace.Text = "Faces";
			chFace.Width = 49;
			//
			// chBones
			//
			chBones.Text = "Joints";
			chBones.Width = 52;
			//
			// chBMesh
			//
			chBMesh.Text = "BoundingMesh";
			chBMesh.Width = 100;
			//
			// label1
			//
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.Font = new System.Drawing.Font(
				"Tahoma",
				9.75F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label1.Location = new System.Drawing.Point(8, 4);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(190, 25);
			label1.TabIndex = 1;
			label1.Text = "Importable Mesh Groups:";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			//
			// cbopacity
			//
			cbopacity.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbopacity.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbopacity.Items.AddRange(
				new object[] { "Opaque (Normal)", "Shadow", "Invisible" }
			);
			cbopacity.Location = new System.Drawing.Point(114, 74);
			cbopacity.Name = "cbopacity";
			cbopacity.Size = new System.Drawing.Size(160, 21);
			cbopacity.TabIndex = 9;
			cbopacity.SelectedIndexChanged += new EventHandler(
				textBox1_TextChanged
			);
			//
			// label5
			//
			label5.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Italic,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label5.Location = new System.Drawing.Point(18, 74);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(88, 23);
			label5.TabIndex = 8;
			label5.Text = "Opacity:";
			label5.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// tbscale
			//
			tbscale.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbscale.Location = new System.Drawing.Point(114, 50);
			tbscale.Name = "tbscale";
			tbscale.ReadOnly = true;
			tbscale.Size = new System.Drawing.Size(136, 21);
			tbscale.TabIndex = 7;
			tbscale.Text = "1";
			tbscale.TextChanged += new EventHandler(
				tbscale_TextChanged
			);
			//
			// label4
			//
			label4.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Italic,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label4.Location = new System.Drawing.Point(18, 50);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(88, 23);
			label4.TabIndex = 6;
			label4.Text = "Scale:";
			label4.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// cbaction
			//
			cbaction.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbaction.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbaction.Location = new System.Drawing.Point(114, 154);
			cbaction.Name = "cbaction";
			cbaction.Size = new System.Drawing.Size(160, 21);
			cbaction.TabIndex = 3;
			cbaction.SelectedIndexChanged += new EventHandler(
				cbaction_SelectedIndexChanged
			);
			//
			// lbname
			//
			lbname.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lbname.Location = new System.Drawing.Point(114, 26);
			lbname.Name = "lbname";
			lbname.Size = new System.Drawing.Size(160, 23);
			lbname.TabIndex = 2;
			lbname.Text = "---";
			lbname.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			//
			// label3
			//
			label3.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Italic,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label3.Location = new System.Drawing.Point(18, 154);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(88, 23);
			label3.TabIndex = 1;
			label3.Text = "Action:";
			label3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// label2
			//
			label2.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Italic,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label2.Location = new System.Drawing.Point(18, 26);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(88, 23);
			label2.TabIndex = 0;
			label2.Text = "Group Name:";
			label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// cbnames
			//
			cbnames.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbnames.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbnames.Location = new System.Drawing.Point(114, 178);
			cbnames.Name = "cbnames";
			cbnames.Size = new System.Drawing.Size(160, 21);
			cbnames.TabIndex = 5;
			cbnames.Visible = false;
			cbnames.SelectedIndexChanged += new EventHandler(
				cbnames_SelectedIndexChanged
			);
			//
			// tbname
			//
			tbname.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbname.Location = new System.Drawing.Point(114, 178);
			tbname.Name = "tbname";
			tbname.Size = new System.Drawing.Size(160, 21);
			tbname.TabIndex = 4;
			tbname.Visible = false;
			tbname.TextChanged += new EventHandler(tbname_TextChanged);
			//
			// button1
			//
			button1.Anchor =


						AnchorStyles.Bottom
						| AnchorStyles.Right


			;
			button1.FlatStyle = FlatStyle.System;
			button1.Font = new System.Drawing.Font(
				"Verdana",
				9.75F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			button1.Location = new System.Drawing.Point(896, 445);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(83, 23);
			button1.TabIndex = 3;
			button1.Text = "OK";
			button1.Click += new EventHandler(button1_Click);
			//
			// cbboneaction
			//
			cbboneaction.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbboneaction.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbboneaction.Location = new System.Drawing.Point(112, 51);
			cbboneaction.Name = "cbboneaction";
			cbboneaction.Size = new System.Drawing.Size(160, 21);
			cbboneaction.TabIndex = 3;
			cbboneaction.SelectedIndexChanged += new EventHandler(
				cbboneaction_SelectedIndexChanged
			);
			//
			// lbbonename
			//
			lbbonename.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lbbonename.Location = new System.Drawing.Point(112, 27);
			lbbonename.Name = "lbbonename";
			lbbonename.Size = new System.Drawing.Size(160, 23);
			lbbonename.TabIndex = 2;
			lbbonename.Text = "---";
			lbbonename.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			//
			// label9
			//
			label9.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Italic,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label9.Location = new System.Drawing.Point(16, 51);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(88, 23);
			label9.TabIndex = 1;
			label9.Text = "Action:";
			label9.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// label10
			//
			label10.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Italic,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label10.Location = new System.Drawing.Point(16, 27);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(88, 23);
			label10.TabIndex = 0;
			label10.Text = "Bone Name:";
			label10.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// cbbones
			//
			cbbones.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbbones.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbbones.Location = new System.Drawing.Point(112, 75);
			cbbones.Name = "cbbones";
			cbbones.Size = new System.Drawing.Size(160, 21);
			cbbones.TabIndex = 5;
			cbbones.Visible = false;
			cbbones.SelectedIndexChanged += new EventHandler(
				cbbones_SelectedIndexChanged
			);
			//
			// cbupdatecres
			//
			cbupdatecres.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Italic,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbupdatecres.Location = new System.Drawing.Point(19, 75);
			cbupdatecres.Name = "cbupdatecres";
			cbupdatecres.Size = new System.Drawing.Size(260, 32);
			cbupdatecres.TabIndex = 2;
			cbupdatecres.Text =
				"Replace initial Bone  Hirarchy. (This can potatially change your Original Game Fi"
				+ "les!)";
			//
			// cbcleanbn
			//
			cbcleanbn.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Italic,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbcleanbn.Location = new System.Drawing.Point(19, 47);
			cbcleanbn.Name = "cbcleanbn";
			cbcleanbn.Size = new System.Drawing.Size(256, 24);
			cbcleanbn.TabIndex = 1;
			cbcleanbn.Text = "Remove unref. Joints after Import";
			//
			// cbcleangrp
			//
			cbcleangrp.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Italic,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbcleangrp.Location = new System.Drawing.Point(19, 27);
			cbcleangrp.Name = "cbcleangrp";
			cbcleangrp.Size = new System.Drawing.Size(224, 24);
			cbcleangrp.TabIndex = 0;
			cbcleangrp.Text = "Remove all Groups before Import";
			//
			// Gradientpanel1
			//
			Gradientpanel1.BackColor = System.Drawing.Color.Transparent;
			Gradientpanel1.Controls.Add(gbbones);
			Gradientpanel1.Controls.Add(gbgroups);
			Gradientpanel1.Controls.Add(gbsettings);
			Gradientpanel1.Controls.Add(button1);
			Gradientpanel1.Controls.Add(lv);
			Gradientpanel1.Controls.Add(label1);
			Gradientpanel1.Dock = DockStyle.Fill;
			Gradientpanel1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			Gradientpanel1.Location = new System.Drawing.Point(0, 0);
			Gradientpanel1.Name = "Gradientpanel1";
			Gradientpanel1.Size = new System.Drawing.Size(984, 473);
			Gradientpanel1.TabIndex = 12;
			//
			// gbbones
			//
			gbbones.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			gbbones.BackColor = System.Drawing.Color.Transparent;
			gbbones.Controls.Add(cbbones);
			gbbones.Controls.Add(label10);
			gbbones.Controls.Add(label9);
			gbbones.Controls.Add(lbbonename);
			gbbones.Controls.Add(cbboneaction);
			gbbones.Location = new System.Drawing.Point(698, 336);
			gbbones.Name = "gbbones";
			gbbones.Padding = new Padding(4, 44, 4, 4);
			gbbones.Size = new System.Drawing.Size(280, 103);
			gbbones.TabIndex = 14;
			//
			// gbgroups
			//
			gbgroups.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			gbgroups.BackColor = System.Drawing.Color.Transparent;
			gbgroups.Controls.Add(lbKeepOrder);
			gbgroups.Controls.Add(label6);
			gbgroups.Controls.Add(cbBMesh);
			gbgroups.Controls.Add(cbnames);
			gbgroups.Controls.Add(label2);
			gbgroups.Controls.Add(label3);
			gbgroups.Controls.Add(lbname);
			gbgroups.Controls.Add(cbaction);
			gbgroups.Controls.Add(label4);
			gbgroups.Controls.Add(tbscale);
			gbgroups.Controls.Add(label5);
			gbgroups.Controls.Add(cbopacity);
			gbgroups.Controls.Add(tbname);
			gbgroups.Location = new System.Drawing.Point(698, 124);
			gbgroups.Name = "gbgroups";
			gbgroups.Padding = new Padding(4, 44, 4, 4);
			gbgroups.Size = new System.Drawing.Size(280, 205);
			gbgroups.TabIndex = 13;
			//
			// lbKeepOrder
			//
			lbKeepOrder.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lbKeepOrder.Location = new System.Drawing.Point(114, 130);
			lbKeepOrder.Name = "lbKeepOrder";
			lbKeepOrder.Size = new System.Drawing.Size(160, 23);
			lbKeepOrder.TabIndex = 12;
			lbKeepOrder.Text = "---";
			lbKeepOrder.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			//
			// label6
			//
			label6.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Italic,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label6.Location = new System.Drawing.Point(18, 130);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(88, 23);
			label6.TabIndex = 11;
			label6.Text = "Keep order:";
			label6.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// cbBMesh
			//
			cbBMesh.Checked = true;
			cbBMesh.CheckState = CheckState.Checked;
			cbBMesh.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Italic,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbBMesh.Location = new System.Drawing.Point(114, 98);
			cbBMesh.Name = "cbBMesh";
			cbBMesh.Size = new System.Drawing.Size(160, 32);
			cbBMesh.TabIndex = 10;
			cbBMesh.Text = "use in bounding Mesh (by Pinhead)";
			cbBMesh.CheckedChanged += new EventHandler(
				cbBMesh_CheckedChanged
			);
			//
			// gbsettings
			//
			gbsettings.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			gbsettings.BackColor = System.Drawing.Color.Transparent;
			gbsettings.Controls.Add(cbupdatecres);
			gbsettings.Controls.Add(cbcleanbn);
			gbsettings.Controls.Add(cbcleangrp);
			gbsettings.Location = new System.Drawing.Point(698, 4);
			gbsettings.Name = "gbsettings";
			gbsettings.Padding = new Padding(4, 44, 4, 4);
			gbsettings.Size = new System.Drawing.Size(280, 113);
			gbsettings.TabIndex = 12;
			//
			// ImportGmdcGroupsForm
			//
			AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			ClientSize = new System.Drawing.Size(984, 473);
			Controls.Add(Gradientpanel1);
			Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Name = "ImportGmdcGroupsForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Mesh Group Importer";
			Load += new EventHandler(ImportGmdcGroupsForm_Load);
			Gradientpanel1.ResumeLayout(false);
			gbbones.ResumeLayout(false);
			gbgroups.ResumeLayout(false);
			gbgroups.PerformLayout();
			gbsettings.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion

		/// <summary>
		/// Der Haupteinstiegspunkt f�r die Anwendung.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.Run(new ImportGmdcGroupsForm());
		}

		/// <summary>
		/// A Group was selected
		/// </summary>
		void SelectGroup()
		{
			gbsettings.Enabled = true;
			Tag = true;
			try
			{
				ImportedGroup a = (ImportedGroup)lv.SelectedItems[0].Tag;

				lbname.Text = a.Group.Name;
				lbKeepOrder.Text = a.KeepOrder.ToString();
				cbaction.SelectedIndex = 0;
				for (int i = 0; i < cbaction.Items.Count; i++)
				{
					GmdcImporterAction ea = (GmdcImporterAction)cbaction.Items[i];
					if (ea == a.Action)
					{
						cbaction.SelectedIndex = i;
						break;
					}
				}
				tbname.Text = a.Target.Name;
				tbscale.Text = a.Scale.ToString("N9");

				cbBMesh.Checked = a.UseInBoundingMesh;

				cbopacity.SelectedIndex = a.Group.Opacity >= 0x10 ? 0 : a.Group.Opacity > 0 ? 1 : 2;
			}
			finally
			{
				Tag = null;
				cbaction_SelectedIndexChanged(cbaction, null);
			}
		}

		/// <summary>
		/// A Bone was selected
		/// </summary>
		void SelectBone()
		{
			gbbones.Enabled = true;
			Tag = true;
			try
			{
				ImportedBone a = (ImportedBone)lv.SelectedItems[0].Tag;

				cbboneaction.SelectedIndex = 0;
				for (int i = 0; i < cbboneaction.Items.Count; i++)
				{
					GmdcImporterAction ea = (GmdcImporterAction)cbboneaction.Items[i];
					if (ea == a.Action)
					{
						cbboneaction.SelectedIndex = i;
						break;
					}
				}
				lbbonename.Text = a.ImportedName;
				try
				{
					cbbones.SelectedIndex = a.TargetIndex;
				}
				catch
				{
					cbbones.SelectedIndex = cbbones.Items.Count - 1;
				}
			}
			finally
			{
				Tag = null;
				cbboneaction_SelectedIndexChanged(cbboneaction, null);
			}
		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			gbsettings.Enabled = false;
			gbbones.Enabled = false;
			if (lv.SelectedItems.Count > 0)
			{
				object o = lv.SelectedItems[0].Tag;
				if (o.GetType() == typeof(ImportedGroup))
				{
					SelectGroup();
				}
				else
				{
					SelectBone();
				}
			}
		}

		public string BuildBoneName(int i)
		{
			return i >= 0 && i < gmdc.Joints.Count ? i.ToString() + ": " + gmdc.Joints[i].Name : "Bone " + i.ToString();
		}

		public string BuildBoneName(ImportedBone a)
		{
			return BuildBoneName(a.TargetIndex);
		}

		GeometryDataContainer gmdc;

		/// <summary>
		/// Show the Group Import Dialog
		/// </summary>
		/// <param name="gmdc">The Target Gmdc File</param>
		/// <param name="actions">An array containing all wanted Import Actions</param>
		/// <param name="joints">An array of all Joints that should be imported</param>
		/// <returns>DialogResult.OK or DialogResult.Cancel</returns>
		public static ImportOptions Execute(
			GeometryDataContainer gmdc,
			List<ImportedGroup> actions,
			List<ImportedBone> joints
		)
		{
			ImportGmdcGroupsForm f = new ImportGmdcGroupsForm
			{
				gmdc = gmdc
			};
			foreach (GmdcGroup g in gmdc.Groups)
			{
				f.cbnames.Items.Add(g.Name);
			}

			for (int i = 0; i < gmdc.Joints.Count; i++)
			{
				f.cbbones.Items.Add(f.BuildBoneName(i));
			}

			bool toobig = false;
			f.cbBMesh.Enabled = joints.Count == 0;
			foreach (ImportedGroup a in actions)
			{
				if (a.Group.Name.ToLower().Trim().IndexOf("shadow") > -1)
				{
					a.Group.Opacity = (uint)MeshOpacity.Shadow;
				}

				if (a.Group.Opacity > 0x10 && f.cbBMesh.Enabled)
				{
					a.UseInBoundingMesh = true;
				}

				if (a.Target.Name == "")
				{
					a.Target.Name = a.Group.Name;
					a.Target.Index = gmdc.FindGroupByName(a.Target.Name);
				}
				ListViewItem lvi = new ListViewItem(a.Group.Name);
				lvi.SubItems.Add(a.Action.ToString());
				lvi.SubItems.Add(a.Target.Name);
				lvi.SubItems.Add(a.VertexCount.ToString());
				lvi.SubItems.Add(a.FaceCount.ToString());
				lvi.SubItems.Add(a.Group.UsedJoints.Count.ToString());
				if (a.UseInBoundingMesh)
				{
					lvi.SubItems.Add("yes");
				}
				else
				{
					lvi.SubItems.Add("no");
				}

				lvi.Tag = a;
				lvi.ForeColor = a.MarkColor;

				if (
					a.VertexCount
					> AbstractGmdcImporter.CRITICAL_VERTEX_AMOUNT
				)
				{
					toobig = true;
				}

				if (
					a.FaceCount
					> AbstractGmdcImporter.CRITICAL_FACE_AMOUNT
				)
				{
					toobig = true;
				}

				f.lv.Items.Add(lvi);
			}

			if (toobig)
			{
				{
					Helper.ExceptionMessage(
						new Warning(
							"One or more of the imported Mesh Groups contain too many Vertices or Faces",
							"If SimPe is not running in Creater Mode, the maximum Number of Vertices is set to "
								+ AbstractGmdcImporter.CRITICAL_VERTEX_AMOUNT.ToString()
								+ " and the maximum amount of Faces to "
								+ AbstractGmdcImporter.CRITICAL_FACE_AMOUNT.ToString()
								+ ".\n\nIf you want to Import this Mesh, you have to create a User Id."
						)
					);
					f.button1.Enabled = false;
				}
			}

			int ct = 0;
			foreach (ImportedBone a in joints)
			{
				a.Action = GmdcImporterAction.Update;
				a.FindBestFitJoint(gmdc);
				if (ct < gmdc.Joints.Count && a.TargetIndex == -1)
				{
					a.TargetIndex = ct;
				}

				ct++;

				ListViewItem lvi = new ListViewItem("(Bone) " + a.ImportedName);
				lvi.SubItems.Add(a.Action.ToString());
				lvi.SubItems.Add(f.BuildBoneName(a));
				lvi.SubItems.Add(a.ParentName);
				lvi.SubItems.Add("-");
				lvi.SubItems.Add("-");
				lvi.Tag = a;
				lvi.ForeColor = a.MarkColor;

				f.lv.Items.Add(lvi);
			}
			if (f.lv.Items.Count > 0)
			{
				f.lv.Items[0].Selected = true;
			}

			f.ok = false;
			f.ShowDialog();

			//Builk the Result
			DialogResult dr = DialogResult.Cancel;
			if (f.ok)
			{
				dr = DialogResult.OK;
			}

			ImportOptions io = new ImportOptions(
				dr,
				f.cbcleangrp.Checked,
				f.cbcleanbn.Checked,
				f.cbupdatecres.Checked
			);
			return io;
		}

		void SetMostLikeName(ImportedGroup a)
		{
			if (a.Target.Name == null)
			{
				a.Target.Name = "";
			}

			if (a.Target.Name.Trim() != "")
			{
				if (a.Target.Index >= 0 && a.Target.Index < cbnames.Items.Count)
				{
					cbnames.SelectedIndex = a.Target.Index;
				}

				return;
			}

			for (int i = 0; i < cbnames.Items.Count; i++)
			{
				string s = (string)cbnames.Items[i];
				s = s.Trim();
				if (a.Group.Name.ToLower().Trim() == s.ToLower())
				{
					a.Target.Name = s;
					a.Target.Index = i;
					cbnames.SelectedIndex = i;
					break;
				}
			}
		}

		private void cbaction_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lv.SelectedItems.Count > 0)
			{
				if (Tag == null)
				{
					try
					{
						for (int i = 0; i < lv.SelectedItems.Count; i++)
						{
							object o = lv.SelectedItems[i].Tag;
							if (o.GetType() != typeof(ImportedGroup))
							{
								continue;
							}

							ImportedGroup a = (ImportedGroup)lv.SelectedItems[i].Tag;

							a.Action = (GmdcImporterAction)
								cbaction.Items[cbaction.SelectedIndex];
							lv.SelectedItems[i].SubItems[1].Text = a.Action.ToString();

							lv.SelectedItems[i].ForeColor = a.MarkColor;

							Tag = true;
							if (i == 0) //change Display ony on the first Selected Item
							{
								switch (a.Action)
								{
									case GmdcImporterAction.Update:
									case GmdcImporterAction.Replace:
									{
										tbname.Visible = false;
										cbnames.Visible = true;
										break;
									}
									case GmdcImporterAction.Rename:
									{
										tbname.Visible = true;
										cbnames.Visible = false;
										break;
									}
									default:
									{
										tbname.Visible = false;
										cbnames.Visible = false;
										break;
									}
								} //switch
							} //if i==0

							//try to find a likley Group for the Replace/Update
							if (
								a.Action == GmdcImporterAction.Replace
								|| a.Action == GmdcImporterAction.Update
							)
							{
								SetMostLikeName(a);
								lv.SelectedItems[i].SubItems[2].Text = cbnames.Text;
							}
						} //for i
					} //try
					finally
					{
						Tag = null;
					}
				} //if Tag
			}
		}

		private void tbname_TextChanged(object sender, EventArgs e)
		{
			if (Tag != null)
			{
				return;
			}

			if (lv.SelectedItems.Count > 0)
			{
				try
				{
					for (int i = 0; i < lv.SelectedItems.Count; i++)
					{
						object o = lv.SelectedItems[i].Tag;
						if (o.GetType() != typeof(ImportedGroup))
						{
							continue;
						}

						GmdcGroupImporterAction a = (GmdcGroupImporterAction)
							lv.SelectedItems[i].Tag;
						a.Target.Name = tbname.Text;

						lv.SelectedItems[i].SubItems[2].Text = a.Target.Name;
					}
				}
				finally
				{
					Tag = null;
				}
			}
		}

		private void cbnames_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Tag != null)
			{
				return;
			}

			if (lv.SelectedItems.Count > 0)
			{
				try
				{
					for (int i = 0; i < lv.SelectedItems.Count; i++)
					{
						object o = lv.SelectedItems[i].Tag;
						if (o.GetType() != typeof(ImportedGroup))
						{
							continue;
						}

						GmdcGroupImporterAction a = (GmdcGroupImporterAction)
							lv.SelectedItems[i].Tag;
						a.Target.Name = cbnames.Text;
						a.Target.Index = cbnames.SelectedIndex;

						lv.SelectedItems[i].SubItems[2].Text = a.Target.Name;
					}
				}
				finally
				{
					Tag = null;
				}
			}
		}

		bool ok;

		private void button1_Click(object sender, EventArgs e)
		{
			ok = true;
			Close();
		}

		private void tbscale_TextChanged(object sender, EventArgs e)
		{
			if (Tag != null)
			{
				return;
			}

			if (lv.SelectedItems.Count > 0)
			{
				try
				{
					for (int i = 0; i < lv.SelectedItems.Count; i++)
					{
						object o = lv.SelectedItems[i].Tag;
						if (o.GetType() != typeof(ImportedGroup))
						{
							continue;
						}

						GmdcGroupImporterAction a = (GmdcGroupImporterAction)
							lv.SelectedItems[i].Tag;
						a.Scale = Convert.ToSingle(tbscale.Text);

						//lv.SelectedItems[i].SubItems[2].Text = a.TargetName;
					}
				}
				catch { }
				finally
				{
					Tag = null;
				}
			}
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			if (Tag != null)
			{
				return;
			}

			if (lv.SelectedItems.Count > 0)
			{
				try
				{
					for (int i = 0; i < lv.SelectedItems.Count; i++)
					{
						object o = lv.SelectedItems[i].Tag;
						if (o.GetType() != typeof(ImportedGroup))
						{
							continue;
						}

						ImportedGroup a = (ImportedGroup)lv.SelectedItems[i].Tag;

						a.Group.Opacity = cbopacity.SelectedIndex == 0
							? (uint)MeshOpacity.Opaque
							: cbopacity.SelectedIndex == 1 ? (uint)MeshOpacity.Shadow : (uint)MeshOpacity.Unknown;

						//lv.SelectedItems[i].SubItems[2].Text = a.TargetName;
					}
				}
				catch { }
				finally
				{
					Tag = null;
				}
			}
		}

		private void cbboneaction_SelectedIndexChanged(
			object sender,
			EventArgs e
		)
		{
			if (lv.SelectedItems.Count > 0)
			{
				if (Tag == null)
				{
					try
					{
						for (int i = 0; i < lv.SelectedItems.Count; i++)
						{
							object o = lv.SelectedItems[i].Tag;
							if (o.GetType() != typeof(ImportedBone))
							{
								continue;
							}

							ImportedBone a = (ImportedBone)o;

							a.Action = (GmdcImporterAction)
								cbboneaction.Items[cbboneaction.SelectedIndex];
							lv.SelectedItems[i].SubItems[1].Text = a.Action.ToString();

							lv.SelectedItems[i].ForeColor = a.MarkColor;

							Tag = true;
							if (i == 0) //change Display ony on the first Selected Item
							{
								switch (a.Action)
								{
									case GmdcImporterAction.Update:
									case GmdcImporterAction.Replace:
									{
										cbbones.Visible = true;
										break;
									}
									default:
									{
										cbbones.Visible = false;
										break;
									}
								} //switch
							} //if i==0

							//try to find a likley Group for the Replace/Update
							/*if (a.Action==GmdcImporterAction.Replace || a.Action==GmdcImporterAction.Update)
							{
								SetMostLikeName(a);
								lv.SelectedItems[i].SubItems[2].Text = cbnames.Text;
							}*/
						} //for i
					} //try
					finally
					{
						Tag = null;
					}
				} //if Tag
			}
		}

		private void cbbones_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Tag != null)
			{
				return;
			}

			if (lv.SelectedItems.Count > 0)
			{
				try
				{
					for (int i = 0; i < lv.SelectedItems.Count; i++)
					{
						object o = lv.SelectedItems[i].Tag;
						if (o.GetType() != typeof(ImportedBone))
						{
							continue;
						}

						ImportedBone a = (ImportedBone)o;
						a.TargetIndex = cbbones.SelectedIndex;

						lv.SelectedItems[i].SubItems[2].Text = BuildBoneName(a);
					}
				}
				finally
				{
					Tag = null;
				}
			}
		}

		private void ImportGmdcGroupsForm_Load(object sender, EventArgs e)
		{
		}

		private void cbBMesh_CheckedChanged(object sender, EventArgs e)
		{
			if (Tag != null)
			{
				return;
			}

			if (lv.SelectedItems.Count > 0)
			{
				try
				{
					for (int i = 0; i < lv.SelectedItems.Count; i++)
					{
						object o = lv.SelectedItems[i].Tag;
						if (o.GetType() != typeof(ImportedGroup))
						{
							continue;
						}

						ImportedGroup a = (ImportedGroup)lv.SelectedItems[i].Tag;

						a.UseInBoundingMesh = cbBMesh.Checked;

						lv.SelectedItems[i].SubItems[6].Text = a.UseInBoundingMesh ? "yes" : "no";
					}
				}
				catch { }
				finally
				{
					Tag = null;
				}
			}
		}
	}
}
