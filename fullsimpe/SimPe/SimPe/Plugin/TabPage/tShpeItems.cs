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
	public class ShpeItems
		:
		//System.Windows.Forms.UserControl
		System.Windows.Forms.TabPage
	{
		private TextBox tbitemunk4;
		private TextBox tbitemunk3;
		private TextBox tbitemunk2;
		private TextBox tbitemunk1;
		private Label label4;
		private TextBox tbitemflname;
		private Label label3;
		internal ListBox lbitem;
		private LinkLabel linkLabel5;
		private LinkLabel linkLabel6;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ShpeItems()
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
			this.linkLabel5 = new LinkLabel();
			this.linkLabel6 = new LinkLabel();
			this.tbitemunk4 = new TextBox();
			this.tbitemunk3 = new TextBox();
			this.tbitemunk2 = new TextBox();
			this.tbitemunk1 = new TextBox();
			this.label4 = new Label();
			this.tbitemflname = new TextBox();
			this.label3 = new Label();
			this.lbitem = new ListBox();

			this.SuspendLayout();
			//
			// tabPage2
			//
			this.Controls.Add(this.linkLabel5);
			this.Controls.Add(this.linkLabel6);
			this.Controls.Add(this.tbitemunk4);
			this.Controls.Add(this.tbitemunk3);
			this.Controls.Add(this.tbitemunk2);
			this.Controls.Add(this.tbitemunk1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tbitemflname);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lbitem);
			this.Location = new System.Drawing.Point(4, 22);
			this.Name = "tabPage2";
			this.Size = new System.Drawing.Size(536, 254);
			this.TabIndex = 1;
			this.Text = "Items";
			//
			// linkLabel5
			//
			this.linkLabel5.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.linkLabel5.AutoSize = true;
			this.linkLabel5.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.linkLabel5.Location = new System.Drawing.Point(484, 120);
			this.linkLabel5.Name = "linkLabel5";
			this.linkLabel5.Size = new System.Drawing.Size(44, 17);
			this.linkLabel5.TabIndex = 19;
			this.linkLabel5.TabStop = true;
			this.linkLabel5.Text = "delete";
			this.linkLabel5.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					this.linkLabel5_LinkClicked
				);
			//
			// linkLabel6
			//
			this.linkLabel6.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.linkLabel6.AutoSize = true;
			this.linkLabel6.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.linkLabel6.Location = new System.Drawing.Point(456, 120);
			this.linkLabel6.Name = "linkLabel6";
			this.linkLabel6.Size = new System.Drawing.Size(28, 17);
			this.linkLabel6.TabIndex = 18;
			this.linkLabel6.TabStop = true;
			this.linkLabel6.Text = "add";
			this.linkLabel6.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					this.linkLabel6_LinkClicked
				);
			//
			// tbitemunk4
			//
			this.tbitemunk4.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.tbitemunk4.Location = new System.Drawing.Point(264, 192);
			this.tbitemunk4.Name = "tbitemunk4";
			this.tbitemunk4.Size = new System.Drawing.Size(48, 21);
			this.tbitemunk4.TabIndex = 17;
			this.tbitemunk4.Text = "0x00";
			this.tbitemunk4.TextChanged += new EventHandler(
				this.ChangeItemUnknown
			);
			//
			// tbitemunk3
			//
			this.tbitemunk3.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.tbitemunk3.Location = new System.Drawing.Point(168, 192);
			this.tbitemunk3.Name = "tbitemunk3";
			this.tbitemunk3.Size = new System.Drawing.Size(88, 21);
			this.tbitemunk3.TabIndex = 16;
			this.tbitemunk3.Text = "0x00000000";
			this.tbitemunk3.TextChanged += new EventHandler(
				this.ChangeItemUnknown
			);
			//
			// tbitemunk2
			//
			this.tbitemunk2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.tbitemunk2.Location = new System.Drawing.Point(112, 192);
			this.tbitemunk2.Name = "tbitemunk2";
			this.tbitemunk2.Size = new System.Drawing.Size(48, 21);
			this.tbitemunk2.TabIndex = 15;
			this.tbitemunk2.Text = "0x00";
			this.tbitemunk2.TextChanged += new EventHandler(
				this.ChangeItemUnknown
			);
			//
			// tbitemunk1
			//
			this.tbitemunk1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.tbitemunk1.Location = new System.Drawing.Point(16, 192);
			this.tbitemunk1.Name = "tbitemunk1";
			this.tbitemunk1.Size = new System.Drawing.Size(88, 21);
			this.tbitemunk1.TabIndex = 14;
			this.tbitemunk1.Text = "0x00000000";
			this.tbitemunk1.TextChanged += new EventHandler(
				this.ChangeItemUnknown
			);
			//
			// label4
			//
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.label4.Location = new System.Drawing.Point(8, 176);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(69, 17);
			this.label4.TabIndex = 13;
			this.label4.Text = "Unknown:";
			//
			// tbitemflname
			//
			this.tbitemflname.Anchor = (
				(AnchorStyles)(
					(
						(
							System.Windows.Forms.AnchorStyles.Top
							| System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.tbitemflname.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.tbitemflname.Location = new System.Drawing.Point(16, 144);
			this.tbitemflname.Name = "tbitemflname";
			this.tbitemflname.Size = new System.Drawing.Size(512, 21);
			this.tbitemflname.TabIndex = 11;
			this.tbitemflname.Text = "";
			this.tbitemflname.TextChanged += new EventHandler(
				this.ChangedItemFilename
			);
			//
			// label3
			//
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.label3.Location = new System.Drawing.Point(8, 128);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(67, 17);
			this.label3.TabIndex = 12;
			this.label3.Text = "Filename:";
			//
			// lbitem
			//
			this.lbitem.Anchor = (
				(AnchorStyles)(
					(
						(
							System.Windows.Forms.AnchorStyles.Top
							| System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.lbitem.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.lbitem.HorizontalScrollbar = true;
			this.lbitem.IntegralHeight = false;
			this.lbitem.Location = new System.Drawing.Point(8, 8);
			this.lbitem.Name = "lbitem";
			this.lbitem.Size = new System.Drawing.Size(520, 112);
			this.lbitem.TabIndex = 10;
			this.lbitem.SelectedIndexChanged += new EventHandler(
				this.SelectItems
			);
			//
			// ShpeForm
			//

			this.ResumeLayout(false);
		}
		#endregion

		private void UpdateLists()
		{
			try
			{
				Shape shape = (Shape)this.Tag;

				ShapeItem[] items = new ShapeItem[lbitem.Items.Count];
				for (int i = 0; i < items.Length; i++)
				{
					items[i] = (ShapeItem)lbitem.Items[i];
				}

				shape.Items = items;
			}
			catch (Exception) { }
		}

		private void linkLabel6_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			try
			{
				//Shpe wrp = (Shpe)wrapper;
				Shape shape = (Shape)this.Tag;

				ShapeItem val = new ShapeItem(shape);
				val.FileName = tbitemflname.Text;
				val.Unknown1 = Convert.ToInt32(tbitemunk1.Text, 16);
				val.Unknown2 = Convert.ToByte(tbitemunk2.Text, 16);
				val.Unknown3 = Convert.ToInt32(tbitemunk3.Text, 16);
				val.Unknown4 = Convert.ToByte(tbitemunk4.Text, 16);

				lbitem.Items.Add(val);
				UpdateLists();
			}
			catch (Exception) { }
		}

		private void linkLabel5_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (lbitem.SelectedIndex < 0)
			{
				return;
			}

			lbitem.Items.RemoveAt(lbitem.SelectedIndex);
			UpdateLists();
		}

		private void ChangeItemUnknown(object sender, EventArgs e)
		{
			if (lbitem.Tag != null)
			{
				return;
			}

			if (lbitem.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				lbitem.Tag = true;
				ShapeItem item = (ShapeItem)lbitem.Items[lbitem.SelectedIndex];
				item.Unknown1 = (int)Convert.ToUInt32(tbitemunk1.Text, 16);
				item.Unknown2 = Convert.ToByte(tbitemunk2.Text, 16);
				item.Unknown3 = (int)Convert.ToUInt32(tbitemunk3.Text, 16);
				item.Unknown4 = Convert.ToByte(tbitemunk4.Text, 16);
				lbitem.Items[lbitem.SelectedIndex] = item;
			}
			catch (Exception) { }
			finally
			{
				lbitem.Tag = null;
			}
		}

		private void ChangedItemFilename(object sender, EventArgs e)
		{
			if (lbitem.Tag != null)
			{
				return;
			}

			if (lbitem.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				lbitem.Tag = true;
				ShapeItem item = (ShapeItem)lbitem.Items[lbitem.SelectedIndex];
				item.FileName = tbitemflname.Text;
				lbitem.Items[lbitem.SelectedIndex] = item;
			}
			catch (Exception) { }
			finally
			{
				lbitem.Tag = null;
			}
		}

		private void SelectItems(object sender, EventArgs e)
		{
			if (lbitem.Tag != null)
			{
				return;
			}

			if (lbitem.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				lbitem.Tag = true;
				ShapeItem item = (ShapeItem)lbitem.Items[lbitem.SelectedIndex];
				tbitemflname.Text = item.FileName;

				tbitemunk1.Text = "0x" + Helper.HexString((uint)item.Unknown1);
				tbitemunk2.Text = "0x" + Helper.HexString(item.Unknown2);
				tbitemunk3.Text = "0x" + Helper.HexString((uint)item.Unknown3);
				tbitemunk4.Text = "0x" + Helper.HexString(item.Unknown4);
			}
			catch (Exception) { }
			finally
			{
				lbitem.Tag = null;
			}
		}
	}
}
