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
	/// Summary description for ShpeForm.
	/// </summary>
	public class ShpeParts
		:
		//System.Windows.Forms.UserControl
		System.Windows.Forms.TabPage
	{
		private Label label5;
		internal ListBox lbpart;
		private TextBox tbparttype;
		private TextBox tbpartdsc;
		private Label label6;
		private TextBox tbpartdata;
		private Label label7;
		private LinkLabel linkLabel7;
		private LinkLabel linkLabel8;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ShpeParts()
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
			linkLabel7 = new LinkLabel();
			linkLabel8 = new LinkLabel();
			tbpartdata = new TextBox();
			label7 = new Label();
			tbpartdsc = new TextBox();
			label6 = new Label();
			tbparttype = new TextBox();
			label5 = new Label();
			lbpart = new ListBox();
			SuspendLayout();
			//
			// tabPage3
			//
			Controls.Add(linkLabel7);
			Controls.Add(linkLabel8);
			Controls.Add(tbpartdata);
			Controls.Add(label7);
			Controls.Add(tbpartdsc);
			Controls.Add(label6);
			Controls.Add(tbparttype);
			Controls.Add(label5);
			Controls.Add(lbpart);
			Location = new System.Drawing.Point(4, 22);
			Name = "tabPage3";
			Size = new System.Drawing.Size(536, 254);
			TabIndex = 2;
			Text = "Parts";
			//
			// linkLabel7
			//
			linkLabel7.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			linkLabel7.AutoSize = true;
			linkLabel7.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			linkLabel7.Location = new System.Drawing.Point(484, 120);
			linkLabel7.Name = "linkLabel7";
			linkLabel7.Size = new System.Drawing.Size(44, 17);
			linkLabel7.TabIndex = 21;
			linkLabel7.TabStop = true;
			linkLabel7.Text = "delete";
			linkLabel7.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					linkLabel7_LinkClicked
				);
			//
			// linkLabel8
			//
			linkLabel8.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			linkLabel8.AutoSize = true;
			linkLabel8.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			linkLabel8.Location = new System.Drawing.Point(456, 120);
			linkLabel8.Name = "linkLabel8";
			linkLabel8.Size = new System.Drawing.Size(28, 17);
			linkLabel8.TabIndex = 20;
			linkLabel8.TabStop = true;
			linkLabel8.Text = "add";
			linkLabel8.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					linkLabel8_LinkClicked
				);
			//
			// tbpartdata
			//
			tbpartdata.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			tbpartdata.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbpartdata.Location = new System.Drawing.Point(16, 224);
			tbpartdata.Name = "tbpartdata";
			tbpartdata.Size = new System.Drawing.Size(512, 21);
			tbpartdata.TabIndex = 18;
			tbpartdata.Text = "";
			tbpartdata.TextChanged += new EventHandler(ChangedPart);
			//
			// label7
			//
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label7.Location = new System.Drawing.Point(8, 208);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(38, 17);
			label7.TabIndex = 19;
			label7.Text = "Data:";
			//
			// tbpartdsc
			//
			tbpartdsc.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			tbpartdsc.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbpartdsc.Location = new System.Drawing.Point(16, 184);
			tbpartdsc.Name = "tbpartdsc";
			tbpartdsc.Size = new System.Drawing.Size(512, 21);
			tbpartdsc.TabIndex = 16;
			tbpartdsc.Text = "";
			tbpartdsc.TextChanged += new EventHandler(ChangedPart);
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
			label6.Location = new System.Drawing.Point(8, 168);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(153, 17);
			label6.TabIndex = 17;
			label6.Text = "Material Definition File:";
			//
			// tbparttype
			//
			tbparttype.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			tbparttype.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbparttype.Location = new System.Drawing.Point(16, 144);
			tbparttype.Name = "tbparttype";
			tbparttype.Size = new System.Drawing.Size(512, 21);
			tbparttype.TabIndex = 14;
			tbparttype.Text = "";
			tbparttype.TextChanged += new EventHandler(ChangedPart);
			//
			// label5
			//
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label5.Location = new System.Drawing.Point(8, 128);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(93, 17);
			label5.TabIndex = 15;
			label5.Text = "Subset Name:";
			//
			// lbpart
			//
			lbpart.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			lbpart.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lbpart.HorizontalScrollbar = true;
			lbpart.IntegralHeight = false;
			lbpart.Location = new System.Drawing.Point(8, 8);
			lbpart.Name = "lbpart";
			lbpart.Size = new System.Drawing.Size(520, 112);
			lbpart.TabIndex = 13;
			lbpart.SelectedIndexChanged += new EventHandler(
				SelectPart
			);
			//
			// ShpeParts
			//
			ResumeLayout(false);
		}
		#endregion

		//internal Shpe wrapper;

		private void SelectPart(object sender, EventArgs e)
		{
			if (lbpart.Tag != null)
			{
				return;
			}

			if (lbpart.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				lbpart.Tag = true;
				ShapePart item = (ShapePart)lbpart.Items[lbpart.SelectedIndex];
				tbparttype.Text = item.Subset;
				tbpartdsc.Text = item.FileName;

				string s = "";
				foreach (byte b in item.Data)
				{
					s += Helper.HexString(b) + " ";
				}

				tbpartdata.Text = s;
			}
			catch (Exception) { }
			finally
			{
				lbpart.Tag = null;
			}
		}

		private void ChangedPart(object sender, EventArgs e)
		{
			if (lbpart.Tag != null)
			{
				return;
			}

			if (lbpart.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				lbpart.Tag = true;
				ShapePart item = (ShapePart)lbpart.Items[lbpart.SelectedIndex];
				item.Subset = tbparttype.Text;
				item.FileName = tbpartdsc.Text;

				string[] tokens = tbpartdata.Text.Trim().Split(" ".ToCharArray());
				byte[] data = new byte[tokens.Length];
				for (int i = 0; i < data.Length; i++)
				{
					data[i] = Convert.ToByte(tokens[i]);
				}

				item.Data = data;

				lbpart.Items[lbpart.SelectedIndex] = item;
			}
			catch (Exception) { }
			finally
			{
				lbpart.Tag = null;
			}
		}

		private void UpdateLists()
		{
			try
			{
				Shape shape = (Shape)Tag;

				ShapePart[] parts = new ShapePart[lbpart.Items.Count];
				for (int i = 0; i < parts.Length; i++)
				{
					parts[i] = (ShapePart)lbpart.Items[i];
				}

				shape.Parts = parts;
			}
			catch (Exception) { }
		}

		private void linkLabel8_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			try
			{
				//Shpe wrp = (Shpe)wrapper;
				Shape shape = (Shape)Tag;

				ShapePart val = new ShapePart
				{
					Subset = tbparttype.Text,
					FileName = tbpartdsc.Text,
					Data = Helper.SetLength(Helper.HexListToBytes(tbpartdata.Text), 9)
				};

				lbpart.Items.Add(val);
				UpdateLists();
			}
			catch (Exception) { }
		}

		private void linkLabel7_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (lbpart.SelectedIndex < 0)
			{
				return;
			}

			lbpart.Items.RemoveAt(lbpart.SelectedIndex);
			UpdateLists();
		}
	}
}
