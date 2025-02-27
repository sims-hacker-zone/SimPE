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
			this.UseVisualStyleBackColor = true;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				Tag = null;
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
			this.lbprop = new ListBox();
			this.gbprop = new GroupBox();
			this.lldel = new LinkLabel();
			this.lladd = new LinkLabel();
			this.tbval = new TextBox();
			this.tbname = new TextBox();
			this.label2 = new Label();
			this.label1 = new Label();
			this.linkLabel1 = new LinkLabel();
			this.btnImport = new Button();
			this.btnExport = new Button();
			this.btnMerge = new Button();
			this.saveFileDialog1 = new SaveFileDialog();
			this.openFileDialog1 = new OpenFileDialog();
			this.gbprop.SuspendLayout();
			this.SuspendLayout();
			//
			// lbprop
			//
			this.lbprop.Anchor = (
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
			this.lbprop.IntegralHeight = false;
			this.lbprop.Location = new System.Drawing.Point(8, 8);
			this.lbprop.Name = "lbprop";
			this.lbprop.Size = new System.Drawing.Size(416, 224);
			this.lbprop.TabIndex = 3;
			this.lbprop.SelectedIndexChanged += new EventHandler(
				this.SelectItem
			);
			//
			// gbprop
			//
			this.gbprop.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.gbprop.Controls.Add(this.lldel);
			this.gbprop.Controls.Add(this.lladd);
			this.gbprop.Controls.Add(this.tbval);
			this.gbprop.Controls.Add(this.tbname);
			this.gbprop.Controls.Add(this.label2);
			this.gbprop.Controls.Add(this.label1);
			this.gbprop.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.gbprop.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.gbprop.Location = new System.Drawing.Point(432, 8);
			this.gbprop.Name = "gbprop";
			this.gbprop.Size = new System.Drawing.Size(296, 104);
			this.gbprop.TabIndex = 4;
			this.gbprop.TabStop = false;
			this.gbprop.Text = "Property";
			//
			// btnExport
			//
			this.btnExport.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.btnExport.AutoSize = true;
			this.btnExport.Location = new System.Drawing.Point(354, 180);
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(75, 27);
			this.btnExport.TabIndex = 8;
			this.btnExport.Text = "Export...";
			this.btnExport.Click += new EventHandler(this.btnExport_Click);
			//
			// btnImport
			//
			this.btnImport.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.btnImport.AutoSize = true;
			this.btnImport.Location = new System.Drawing.Point(390, 180);
			this.btnImport.Name = "btnImport";
			this.btnImport.Size = new System.Drawing.Size(75, 27);
			this.btnImport.TabIndex = 7;
			this.btnImport.Text = "Import...";
			this.btnImport.Click += new EventHandler(this.btnImport_Click);
			//
			// btnMerge
			//
			this.btnMerge.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.btnMerge.AutoSize = true;
			this.btnMerge.Location = new System.Drawing.Point(318, 180);
			this.btnMerge.Name = "btnMerge";
			this.btnMerge.Size = new System.Drawing.Size(75, 27);
			this.btnMerge.TabIndex = 9;
			this.btnMerge.Text = "Merge...";
			this.btnMerge.Click += new EventHandler(this.btnMerge_Click);
			//
			// lldel
			//
			this.lldel.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Bottom
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.lldel.AutoSize = true;
			this.lldel.Location = new System.Drawing.Point(244, 80);
			this.lldel.Name = "lldel";
			this.lldel.Size = new System.Drawing.Size(55, 17);
			this.lldel.TabIndex = 5;
			this.lldel.TabStop = true;
			this.lldel.Text = "delete";
			this.lldel.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					this.DeletItem
				);
			//
			// lladd
			//
			this.lladd.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Bottom
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.lladd.AutoSize = true;
			this.lladd.Location = new System.Drawing.Point(208, 80);
			this.lladd.Name = "lladd";
			this.lladd.Size = new System.Drawing.Size(37, 17);
			this.lladd.TabIndex = 4;
			this.lladd.TabStop = true;
			this.lladd.Text = "add";
			this.lladd.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(this.AddItem);
			//
			// tbval
			//
			this.tbval.Anchor = (
				(AnchorStyles)(
					(
						(
							System.Windows.Forms.AnchorStyles.Top
							| System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.tbval.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.tbval.Location = new System.Drawing.Point(64, 48);
			this.tbval.Name = "tbval";
			this.tbval.Size = new System.Drawing.Size(224, 24);
			this.tbval.TabIndex = 3;
			this.tbval.TextChanged += new EventHandler(this.AutoChange);
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
			this.tbname.Location = new System.Drawing.Point(64, 24);
			this.tbname.Name = "tbname";
			this.tbname.Size = new System.Drawing.Size(224, 24);
			this.tbname.TabIndex = 2;
			this.tbname.TextChanged += new EventHandler(this.AutoChange);
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
			this.label2.Location = new System.Drawing.Point(16, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "Value:";
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
			this.label1.Location = new System.Drawing.Point(16, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name:";
			//
			// linkLabel1
			//
			this.linkLabel1.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Bottom
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(432, 184);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(58, 17);
			this.linkLabel1.TabIndex = 6;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "sort List";
			this.linkLabel1.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					this.linkLabel1_LinkClicked
				);
			//
			// saveFileDialog1
			//
			this.saveFileDialog1.DefaultExt = "xml";
			this.saveFileDialog1.Filter = "Material Definition Properties (xml)|*.xml";
			this.saveFileDialog1.Title = "Export Material Definition Properties";
			//
			// openFileDialog1
			//
			this.openFileDialog1.DefaultExt = "xml";
			this.openFileDialog1.Filter =
				"Material Definition Properties (xml)|*.xml|All files|*.*";
			this.openFileDialog1.Title = "Material Definition Properties";
			//
			// MatdForm
			//
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.lbprop);
			this.Controls.Add(this.btnMerge);
			this.Controls.Add(this.btnImport);
			this.Controls.Add(this.btnExport);
			this.Controls.Add(this.gbprop);
			this.Controls.Add(this.linkLabel1);
			this.Location = new System.Drawing.Point(4, 22);
			this.Name = "tMaterialDefinition";
			this.Size = new System.Drawing.Size(744, 238);
			this.Text = "Properties";
			this.gbprop.ResumeLayout(false);
			this.gbprop.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion

		protected void Change()
		{
			if (this.Tag == null)
			{
				return;
			}

			if (this.lbprop.SelectedIndex < 0)
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
					this.Tag;
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
			if (this.Tag == null)
			{
				return;
			}

			Plugin.MaterialDefinition md = (Plugin.MaterialDefinition)
				this.Tag;
			md.Sort();
			md.Refresh();
		}

		private void AutoChange(object sender, EventArgs e)
		{
			if (tbname.Tag != null)
			{
				return;
			}

			if (this.lbprop.SelectedIndex >= 0)
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
				this.tbname.Text = prop.Name;
				this.tbval.Text = prop.Value;
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
			if (this.Tag == null)
			{
				return;
			}

			MaterialDefinitionProperty prop =
				new MaterialDefinitionProperty();
			lbprop.Items.Add(prop);

			Plugin.MaterialDefinition md = (Plugin.MaterialDefinition)
				this.Tag;
			md.Properties = (MaterialDefinitionProperty[])
				Helper.Add(md.Properties, prop);

			md.Changed = true;
		}

		private void DeletItem(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (this.Tag == null)
			{
				return;
			}

			if (lbprop.SelectedIndex < 0)
			{
				return;
			}

			Plugin.MaterialDefinition md = (Plugin.MaterialDefinition)
				this.Tag;
			md.Properties = (MaterialDefinitionProperty[])
				Helper.Delete(md.Properties, lbprop.Items[lbprop.SelectedIndex]);
			md.Changed = true;
			lbprop.Items.Remove(lbprop.Items[lbprop.SelectedIndex]);
		}

		internal void TxmtChangeTab(object sender, EventArgs e)
		{
			if (this.Tag == null)
			{
				return;
			}

			Plugin.MaterialDefinition md = (Plugin.MaterialDefinition)
				this.Tag;
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
			if (this.Tag == null)
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
				this.Tag;
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
			if (this.Tag == null)
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
				this.Tag;
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
