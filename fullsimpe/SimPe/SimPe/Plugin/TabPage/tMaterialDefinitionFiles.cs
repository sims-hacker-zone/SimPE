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
	public class MaterialDefinitionFiles : System.Windows.Forms.TabPage
	//System.Windows.Forms.UserControl
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MaterialDefinitionFiles()
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
			this.linkLabel4 = new LinkLabel();
			this.linkLabel3 = new LinkLabel();
			this.tblistfile = new TextBox();
			this.label6 = new Label();
			this.lbfl = new ListBox();
			this.SuspendLayout();
			//
			// tMaterialDefinitionFiles
			//
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.linkLabel4);
			this.Controls.Add(this.linkLabel3);
			this.Controls.Add(this.tblistfile);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.lbfl);
			this.Location = new System.Drawing.Point(4, 22);
			this.Name = "tMaterialDefinitionFiles";
			this.Size = new System.Drawing.Size(744, 238);
			this.TabIndex = 1;
			this.Text = "File List";
			//
			// linkLabel4
			//
			this.linkLabel4.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)
				)
			);
			this.linkLabel4.AutoSize = true;
			this.linkLabel4.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.linkLabel4.Location = new System.Drawing.Point(656, 56);
			this.linkLabel4.Name = "linkLabel4";
			this.linkLabel4.Size = new System.Drawing.Size(28, 17);
			this.linkLabel4.TabIndex = 8;
			this.linkLabel4.TabStop = true;
			this.linkLabel4.Text = "add";
			this.linkLabel4.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(this.Add);
			//
			// linkLabel3
			//
			this.linkLabel3.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)
				)
			);
			this.linkLabel3.AutoSize = true;
			this.linkLabel3.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.linkLabel3.Location = new System.Drawing.Point(692, 56);
			this.linkLabel3.Name = "linkLabel3";
			this.linkLabel3.Size = new System.Drawing.Size(44, 17);
			this.linkLabel3.TabIndex = 7;
			this.linkLabel3.TabStop = true;
			this.linkLabel3.Text = "delete";
			this.linkLabel3.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(this.Delete);
			//
			// tblistfile
			//
			this.tblistfile.Anchor = (
				(AnchorStyles)(
					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)
				)
			);
			this.tblistfile.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.tblistfile.Location = new System.Drawing.Point(440, 24);
			this.tblistfile.Name = "tblistfile";
			this.tblistfile.Size = new System.Drawing.Size(296, 21);
			this.tblistfile.TabIndex = 6;
			this.tblistfile.Text = "";
			this.tblistfile.TextChanged += new EventHandler(this.ChangeListFile);
			//
			// label6
			//
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.label6.Location = new System.Drawing.Point(432, 8);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(67, 17);
			this.label6.TabIndex = 5;
			this.label6.Text = "Filename:";
			//
			// lbfl
			//
			this.lbfl.Anchor = (
				(AnchorStyles)(
					(
						(
							AnchorStyles.Top
							| AnchorStyles.Bottom
						) | AnchorStyles.Left
					)
				)
			);
			this.lbfl.HorizontalScrollbar = true;
			this.lbfl.IntegralHeight = false;
			this.lbfl.Location = new System.Drawing.Point(8, 8);
			this.lbfl.Name = "lbfl";
			this.lbfl.Size = new System.Drawing.Size(416, 224);
			this.lbfl.TabIndex = 4;
			this.lbfl.SelectedIndexChanged += new EventHandler(
				this.SelectListFile
			);
			//
			// MatdForm
			//
			this.ResumeLayout(false);
		}
		#endregion

		internal ListBox lbfl;
		private TextBox tblistfile;
		private Label label6;
		private LinkLabel linkLabel3;
		private LinkLabel linkLabel4;

		private void SelectListFile(object sender, EventArgs e)
		{
			if (tblistfile.Tag != null)
			{
				return;
			}

			if (lbfl.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				tblistfile.Tag = true;
				tblistfile.Text = (string)lbfl.Items[lbfl.SelectedIndex];
			}
			catch (Exception) { }
			finally
			{
				tblistfile.Tag = null;
			}
		}

		private void ChangeListFile(object sender, EventArgs e)
		{
			if (this.Tag == null)
			{
				return;
			}

			if (tblistfile.Tag != null)
			{
				return;
			}

			if (lbfl.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				tblistfile.Tag = true;
				lbfl.Items[lbfl.SelectedIndex] = tblistfile.Text;

				Plugin.MaterialDefinition md = (Plugin.MaterialDefinition)
					this.Tag;
				md.Listing[lbfl.SelectedIndex] = tblistfile.Text;

				md.Changed = true;
			}
			catch (Exception) { }
			finally
			{
				tblistfile.Tag = null;
			}
		}

		private void Delete(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (this.Tag == null)
			{
				return;
			}

			if (lbfl.SelectedIndex < 0)
			{
				return;
			}

			Plugin.MaterialDefinition md = (Plugin.MaterialDefinition)
				this.Tag;
			md.Listing = (string[])
				Helper.Delete(md.Listing, lbfl.Items[lbfl.SelectedIndex]);

			lbfl.Items.Remove(lbfl.Items[lbfl.SelectedIndex]);

			md.Changed = true;
		}

		private void Add(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (this.Tag == null)
			{
				return;
			}

			lbfl.Items.Add(tblistfile.Text);
			lbfl.SelectedIndex = lbfl.Items.Count - 1;

			Plugin.MaterialDefinition md = (Plugin.MaterialDefinition)
				this.Tag;
			md.Listing = (string[])Helper.Add(md.Listing, tblistfile.Text);

			md.Changed = true;
		}
	}
}
