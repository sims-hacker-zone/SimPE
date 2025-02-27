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
			linkLabel4 = new LinkLabel();
			linkLabel3 = new LinkLabel();
			tblistfile = new TextBox();
			label6 = new Label();
			lbfl = new ListBox();
			SuspendLayout();
			//
			// tMaterialDefinitionFiles
			//
			BackColor = System.Drawing.Color.White;
			Controls.Add(linkLabel4);
			Controls.Add(linkLabel3);
			Controls.Add(tblistfile);
			Controls.Add(label6);
			Controls.Add(lbfl);
			Location = new System.Drawing.Point(4, 22);
			Name = "tMaterialDefinitionFiles";
			Size = new System.Drawing.Size(744, 238);
			TabIndex = 1;
			Text = "File List";
			//
			// linkLabel4
			//
			linkLabel4.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			linkLabel4.AutoSize = true;
			linkLabel4.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			linkLabel4.Location = new System.Drawing.Point(656, 56);
			linkLabel4.Name = "linkLabel4";
			linkLabel4.Size = new System.Drawing.Size(28, 17);
			linkLabel4.TabIndex = 8;
			linkLabel4.TabStop = true;
			linkLabel4.Text = "add";
			linkLabel4.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(Add);
			//
			// linkLabel3
			//
			linkLabel3.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			linkLabel3.AutoSize = true;
			linkLabel3.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			linkLabel3.Location = new System.Drawing.Point(692, 56);
			linkLabel3.Name = "linkLabel3";
			linkLabel3.Size = new System.Drawing.Size(44, 17);
			linkLabel3.TabIndex = 7;
			linkLabel3.TabStop = true;
			linkLabel3.Text = "delete";
			linkLabel3.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(Delete);
			//
			// tblistfile
			//
			tblistfile.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			tblistfile.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tblistfile.Location = new System.Drawing.Point(440, 24);
			tblistfile.Name = "tblistfile";
			tblistfile.Size = new System.Drawing.Size(296, 21);
			tblistfile.TabIndex = 6;
			tblistfile.Text = "";
			tblistfile.TextChanged += new EventHandler(ChangeListFile);
			//
			// label6
			//
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label6.Location = new System.Drawing.Point(432, 8);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(67, 17);
			label6.TabIndex = 5;
			label6.Text = "Filename:";
			//
			// lbfl
			//
			lbfl.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Bottom
						) | AnchorStyles.Left
					)

			;
			lbfl.HorizontalScrollbar = true;
			lbfl.IntegralHeight = false;
			lbfl.Location = new System.Drawing.Point(8, 8);
			lbfl.Name = "lbfl";
			lbfl.Size = new System.Drawing.Size(416, 224);
			lbfl.TabIndex = 4;
			lbfl.SelectedIndexChanged += new EventHandler(
				SelectListFile
			);
			//
			// MatdForm
			//
			ResumeLayout(false);
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
			if (Tag == null)
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
					Tag;
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
			if (Tag == null)
			{
				return;
			}

			if (lbfl.SelectedIndex < 0)
			{
				return;
			}

			Plugin.MaterialDefinition md = (Plugin.MaterialDefinition)
				Tag;
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
			if (Tag == null)
			{
				return;
			}

			lbfl.Items.Add(tblistfile.Text);
			lbfl.SelectedIndex = lbfl.Items.Count - 1;

			Plugin.MaterialDefinition md = (Plugin.MaterialDefinition)
				Tag;
			md.Listing = (string[])Helper.Add(md.Listing, tblistfile.Text);

			md.Changed = true;
		}
	}
}
