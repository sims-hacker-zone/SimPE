// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Windows.Forms;

namespace SimPe.Plugin.TabPage
{
	/// <summary>
	/// Summary description for MatdForm.
	/// </summary>
	public class MatdForm : System.Windows.Forms.TabPage
	//System.Windows.Forms.UserControl
	{
		#region Form variables
		internal ListBox lbprop;
		internal GroupBox gbprop;
		private Label label1;
		private Label label2;
		internal TextBox tbname;
		private TextBox tbval;
		private LinkLabel lladd;
		internal LinkLabel lldel;
		private LinkLabel linkLabel1;
		private Button btnImport;
		private Button btnExport;
		private Button btnMerge;
		private SaveFileDialog saveFileDialog1;
		private OpenFileDialog openFileDialog1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public MatdForm()
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

			btnExport.Left = gbprop.Left;
			btnImport.Left = btnExport.Right + 12;
			btnMerge.Left = btnImport.Right + 12;
			btnExport.Top = btnImport.Top = btnMerge.Top = gbprop.Bottom + 12;
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
			lbprop = new ListBox();
			gbprop = new GroupBox();
			lldel = new LinkLabel();
			lladd = new LinkLabel();
			tbval = new TextBox();
			tbname = new TextBox();
			label2 = new Label();
			label1 = new Label();
			linkLabel1 = new LinkLabel();
			btnImport = new Button();
			btnExport = new Button();
			btnMerge = new Button();
			saveFileDialog1 = new SaveFileDialog();
			openFileDialog1 = new OpenFileDialog();
			gbprop.SuspendLayout();
			SuspendLayout();
			//
			// lbprop
			//
			lbprop.Anchor =




								AnchorStyles.Top
								| AnchorStyles.Bottom
							 | AnchorStyles.Left
						 | AnchorStyles.Right


			;
			lbprop.IntegralHeight = false;
			lbprop.Location = new System.Drawing.Point(8, 8);
			lbprop.Name = "lbprop";
			lbprop.Size = new System.Drawing.Size(416, 224);
			lbprop.TabIndex = 3;
			lbprop.SelectedIndexChanged += new EventHandler(
				SelectItem
			);
			//
			// gbprop
			//
			gbprop.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			gbprop.Controls.Add(lldel);
			gbprop.Controls.Add(lladd);
			gbprop.Controls.Add(tbval);
			gbprop.Controls.Add(tbname);
			gbprop.Controls.Add(label2);
			gbprop.Controls.Add(label1);
			gbprop.FlatStyle = FlatStyle.System;
			gbprop.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			gbprop.Location = new System.Drawing.Point(432, 8);
			gbprop.Name = "gbprop";
			gbprop.Size = new System.Drawing.Size(296, 104);
			gbprop.TabIndex = 4;
			gbprop.TabStop = false;
			gbprop.Text = "Property";
			//
			// btnExport
			//
			btnExport.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			btnExport.AutoSize = true;
			btnExport.Location = new System.Drawing.Point(354, 180);
			btnExport.Name = "btnExport";
			btnExport.Size = new System.Drawing.Size(75, 27);
			btnExport.TabIndex = 8;
			btnExport.Text = "Export...";
			btnExport.Click += new EventHandler(btnExport_Click);
			//
			// btnImport
			//
			btnImport.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			btnImport.AutoSize = true;
			btnImport.Location = new System.Drawing.Point(390, 180);
			btnImport.Name = "btnImport";
			btnImport.Size = new System.Drawing.Size(75, 27);
			btnImport.TabIndex = 7;
			btnImport.Text = "Import...";
			btnImport.Click += new EventHandler(btnImport_Click);
			//
			// btnMerge
			//
			btnMerge.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			btnMerge.AutoSize = true;
			btnMerge.Location = new System.Drawing.Point(318, 180);
			btnMerge.Name = "btnMerge";
			btnMerge.Size = new System.Drawing.Size(75, 27);
			btnMerge.TabIndex = 9;
			btnMerge.Text = "Merge...";
			btnMerge.Click += new EventHandler(btnMerge_Click);
			//
			// lldel
			//
			lldel.Anchor =


						AnchorStyles.Bottom
						| AnchorStyles.Right


			;
			lldel.AutoSize = true;
			lldel.Location = new System.Drawing.Point(244, 80);
			lldel.Name = "lldel";
			lldel.Size = new System.Drawing.Size(55, 17);
			lldel.TabIndex = 5;
			lldel.TabStop = true;
			lldel.Text = "delete";
			lldel.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					DeletItem
				);
			//
			// lladd
			//
			lladd.Anchor =


						AnchorStyles.Bottom
						| AnchorStyles.Right


			;
			lladd.AutoSize = true;
			lladd.Location = new System.Drawing.Point(208, 80);
			lladd.Name = "lladd";
			lladd.Size = new System.Drawing.Size(37, 17);
			lladd.TabIndex = 4;
			lladd.TabStop = true;
			lladd.Text = "add";
			lladd.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(AddItem);
			//
			// tbval
			//
			tbval.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Left
						 | AnchorStyles.Right


			;
			tbval.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbval.Location = new System.Drawing.Point(64, 48);
			tbval.Name = "tbval";
			tbval.Size = new System.Drawing.Size(224, 24);
			tbval.TabIndex = 3;
			tbval.TextChanged += new EventHandler(AutoChange);
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
			tbname.Location = new System.Drawing.Point(64, 24);
			tbname.Name = "tbname";
			tbname.Size = new System.Drawing.Size(224, 24);
			tbname.TabIndex = 2;
			tbname.TextChanged += new EventHandler(AutoChange);
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
			label2.Location = new System.Drawing.Point(16, 56);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(52, 17);
			label2.TabIndex = 1;
			label2.Text = "Value:";
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
			label1.Location = new System.Drawing.Point(16, 32);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(53, 17);
			label1.TabIndex = 0;
			label1.Text = "Name:";
			//
			// linkLabel1
			//
			linkLabel1.Anchor =


						AnchorStyles.Bottom
						| AnchorStyles.Right


			;
			linkLabel1.AutoSize = true;
			linkLabel1.Location = new System.Drawing.Point(432, 184);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(58, 17);
			linkLabel1.TabIndex = 6;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "sort List";
			linkLabel1.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					linkLabel1_LinkClicked
				);
			//
			// saveFileDialog1
			//
			saveFileDialog1.DefaultExt = "xml";
			saveFileDialog1.Filter = "Material Definition Properties (xml)|*.xml";
			saveFileDialog1.Title = "Export Material Definition Properties";
			//
			// openFileDialog1
			//
			openFileDialog1.DefaultExt = "xml";
			openFileDialog1.Filter =
				"Material Definition Properties (xml)|*.xml|All files|*.*";
			openFileDialog1.Title = "Material Definition Properties";
			//
			// MatdForm
			//
			BackColor = System.Drawing.Color.White;
			Controls.Add(lbprop);
			Controls.Add(btnMerge);
			Controls.Add(btnImport);
			Controls.Add(btnExport);
			Controls.Add(gbprop);
			Controls.Add(linkLabel1);
			Location = new System.Drawing.Point(4, 22);
			Name = "tMaterialDefinition";
			Size = new System.Drawing.Size(744, 238);
			Text = "Properties";
			gbprop.ResumeLayout(false);
			gbprop.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion

		protected void Change()
		{
			if (Tag == null)
			{
				return;
			}

			if (lbprop.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				tbname.Tag = true;
				MaterialDefinitionProperty prop =
					(MaterialDefinitionProperty)
						lbprop.Items[lbprop.SelectedIndex];

				prop.Name = tbname.Text;
				prop.Value = tbval.Text;

				lbprop.Items[lbprop.SelectedIndex] = prop;

				Plugin.MaterialDefinition md = (Plugin.MaterialDefinition)
					Tag;
				md.Changed = true;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("errconvert"),
					ex
				);
			}
			finally
			{
				tbname.Tag = null;
			}
		}

		private void linkLabel1_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (Tag == null)
			{
				return;
			}

			Plugin.MaterialDefinition md = (Plugin.MaterialDefinition)
				Tag;
			md.Sort();
			md.Refresh();
		}

		private void AutoChange(object sender, EventArgs e)
		{
			if (tbname.Tag != null)
			{
				return;
			}

			if (lbprop.SelectedIndex >= 0)
			{
				Change();
			}
		}

		private void SelectItem(object sender, EventArgs e)
		{
			lldel.Enabled = false;
			if (lbprop.SelectedIndex < 0)
			{
				return;
			}

			lldel.Enabled = true;

			try
			{
				tbname.Tag = true;
				MaterialDefinitionProperty prop =
					(MaterialDefinitionProperty)
						lbprop.Items[lbprop.SelectedIndex];
				tbname.Text = prop.Name;
				tbval.Text = prop.Value;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("errconvert"),
					ex
				);
			}
			finally
			{
				tbname.Tag = null;
			}
		}

		private void AddItem(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (Tag == null)
			{
				return;
			}

			MaterialDefinitionProperty prop =
				new MaterialDefinitionProperty();
			lbprop.Items.Add(prop);

			Plugin.MaterialDefinition md = (Plugin.MaterialDefinition)
				Tag;
			md.Properties = (MaterialDefinitionProperty[])
				Helper.Add(md.Properties, prop);

			md.Changed = true;
		}

		private void DeletItem(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (Tag == null)
			{
				return;
			}

			if (lbprop.SelectedIndex < 0)
			{
				return;
			}

			Plugin.MaterialDefinition md = (Plugin.MaterialDefinition)
				Tag;
			md.Properties = (MaterialDefinitionProperty[])
				Helper.Delete(md.Properties, lbprop.Items[lbprop.SelectedIndex]);
			md.Changed = true;
			lbprop.Items.Remove(lbprop.Items[lbprop.SelectedIndex]);
		}

		internal void TxmtChangeTab(object sender, EventArgs e)
		{
			if (Tag == null)
			{
				return;
			}

			Plugin.MaterialDefinition md = (Plugin.MaterialDefinition)
				Tag;
			if (Parent == null)
			{
				return;
			}

			if (((TabControl)Parent).SelectedTab == this)
			{
				md.Refresh();
			}
		}

		private void btnExport_Click(object sender, EventArgs e)
		{
			if (Tag == null)
			{
				return;
			}

			saveFileDialog1.FileName = "";
			DialogResult dr = saveFileDialog1.ShowDialog();
			if (dr != DialogResult.OK)
			{
				return;
			}

			Plugin.MaterialDefinition md = (Plugin.MaterialDefinition)
				Tag;
			md.ExportProperties(saveFileDialog1.FileName);
		}

		private void btnImport_Click(object sender, EventArgs e)
		{
			do_imp_mrg(true);
		}

		private void btnMerge_Click(object sender, EventArgs e)
		{
			do_imp_mrg(false);
		}

		private void do_imp_mrg(bool imp)
		{
			if (Tag == null)
			{
				return;
			}

			openFileDialog1.FileName = "";
			DialogResult dr = openFileDialog1.ShowDialog();
			if (dr != DialogResult.OK)
			{
				return;
			}

			Plugin.MaterialDefinition md = (Plugin.MaterialDefinition)
				Tag;
			if (imp)
			{
				md.ImportProperties(openFileDialog1.FileName);
			}
			else
			{
				md.MergeProperties(openFileDialog1.FileName);
			}

			md.Refresh();
		}
	}
}
