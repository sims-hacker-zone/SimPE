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
	/// Summary description for fShapeRefNode.
	/// </summary>
	public class ShpeLod
		:
		//System.Windows.Forms.UserControl
		System.Windows.Forms.TabPage
	{
		private TextBox tbunk;
		internal ListBox lbunk;
		private Label label1;
		private LinkLabel linkLabel3;
		private LinkLabel linkLabel4;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ShpeLod()
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
			tbunk = new TextBox();
			lbunk = new ListBox();
			label1 = new Label();
			SuspendLayout();
			//
			// tShpeLod
			//
			Controls.Add(linkLabel4);
			Controls.Add(linkLabel3);
			Controls.Add(tbunk);
			Controls.Add(lbunk);
			Controls.Add(label1);
			Location = new System.Drawing.Point(4, 22);
			Name = "tShpeLod";
			Size = new System.Drawing.Size(536, 254);
			TabIndex = 0;
			Text = "Level of Detail Listing";
			//
			// linkLabel4
			//
			linkLabel4.AutoSize = true;
			linkLabel4.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			linkLabel4.Location = new System.Drawing.Point(188, 56);
			linkLabel4.Name = "linkLabel4";
			linkLabel4.Size = new System.Drawing.Size(44, 17);
			linkLabel4.TabIndex = 7;
			linkLabel4.TabStop = true;
			linkLabel4.Text = "delete";
			linkLabel4.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					linkLabel4_LinkClicked
				);
			//
			// linkLabel3
			//
			linkLabel3.AutoSize = true;
			linkLabel3.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			linkLabel3.Location = new System.Drawing.Point(160, 56);
			linkLabel3.Name = "linkLabel3";
			linkLabel3.Size = new System.Drawing.Size(28, 17);
			linkLabel3.TabIndex = 6;
			linkLabel3.TabStop = true;
			linkLabel3.Text = "add";
			linkLabel3.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					linkLabel3_LinkClicked
				);
			//
			// tbunk
			//
			tbunk.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbunk.Location = new System.Drawing.Point(144, 32);
			tbunk.Name = "tbunk";
			tbunk.Size = new System.Drawing.Size(88, 21);
			tbunk.TabIndex = 4;
			tbunk.Text = "0x00000000";
			tbunk.TextChanged += new EventHandler(ChangeUnknown);
			//
			// lbunk
			//
			lbunk.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lbunk.IntegralHeight = false;
			lbunk.Location = new System.Drawing.Point(8, 8);
			lbunk.Name = "lbunk";
			lbunk.Size = new System.Drawing.Size(120, 104);
			lbunk.TabIndex = 3;
			lbunk.SelectedIndexChanged += new EventHandler(
				SelectUnknown
			);
			//
			// label1
			//
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label1.Location = new System.Drawing.Point(136, 16);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(44, 17);
			label1.TabIndex = 5;
			label1.Text = "Value:";
			//
			// ShpeForm
			//

			ResumeLayout(false);
		}
		#endregion

		private void UpdateLists()
		{
			try
			{
				Shape shape = (Shape)Tag;

				uint[] unknown = new uint[lbunk.Items.Count];
				for (int i = 0; i < unknown.Length; i++)
				{
					unknown[i] = (uint)lbunk.Items[i];
				}

				shape.Unknwon = unknown;
			}
			catch (Exception) { }
		}

		private void SelectUnknown(object sender, EventArgs e)
		{
			if (tbunk.Tag != null)
			{
				return;
			}

			if (lbunk.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				tbunk.Tag = true;
				tbunk.Text =
					"0x" + Helper.HexString((uint)lbunk.Items[lbunk.SelectedIndex]);
			}
			catch (Exception) { }
			finally
			{
				tbunk.Tag = null;
			}
		}

		private void ChangeUnknown(object sender, EventArgs e)
		{
			if (tbunk.Tag != null)
			{
				return;
			}

			if (lbunk.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				tbunk.Tag = true;
				lbunk.Items[lbunk.SelectedIndex] = Convert.ToUInt32(tbunk.Text, 16);
			}
			catch (Exception) { }
			finally
			{
				tbunk.Tag = null;
			}
		}

		private void linkLabel3_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			try
			{
				uint val = Convert.ToUInt32(tbunk.Text, 16);
				lbunk.Items.Add(val);
				UpdateLists();
			}
			catch (Exception) { }
		}

		private void linkLabel4_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (lbunk.SelectedIndex < 0)
			{
				return;
			}

			lbunk.Items.RemoveAt(lbunk.SelectedIndex);
			UpdateLists();
		}
	}
}
