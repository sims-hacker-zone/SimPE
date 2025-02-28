// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
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
			linkLabel5 = new LinkLabel();
			linkLabel6 = new LinkLabel();
			tbitemunk4 = new TextBox();
			tbitemunk3 = new TextBox();
			tbitemunk2 = new TextBox();
			tbitemunk1 = new TextBox();
			label4 = new Label();
			tbitemflname = new TextBox();
			label3 = new Label();
			lbitem = new ListBox();

			SuspendLayout();
			//
			// tabPage2
			//
			Controls.Add(linkLabel5);
			Controls.Add(linkLabel6);
			Controls.Add(tbitemunk4);
			Controls.Add(tbitemunk3);
			Controls.Add(tbitemunk2);
			Controls.Add(tbitemunk1);
			Controls.Add(label4);
			Controls.Add(tbitemflname);
			Controls.Add(label3);
			Controls.Add(lbitem);
			Location = new System.Drawing.Point(4, 22);
			Name = "tabPage2";
			Size = new System.Drawing.Size(536, 254);
			TabIndex = 1;
			Text = "Items";
			//
			// linkLabel5
			//
			linkLabel5.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			linkLabel5.AutoSize = true;
			linkLabel5.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			linkLabel5.Location = new System.Drawing.Point(484, 120);
			linkLabel5.Name = "linkLabel5";
			linkLabel5.Size = new System.Drawing.Size(44, 17);
			linkLabel5.TabIndex = 19;
			linkLabel5.TabStop = true;
			linkLabel5.Text = "delete";
			linkLabel5.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					linkLabel5_LinkClicked
				);
			//
			// linkLabel6
			//
			linkLabel6.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			linkLabel6.AutoSize = true;
			linkLabel6.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			linkLabel6.Location = new System.Drawing.Point(456, 120);
			linkLabel6.Name = "linkLabel6";
			linkLabel6.Size = new System.Drawing.Size(28, 17);
			linkLabel6.TabIndex = 18;
			linkLabel6.TabStop = true;
			linkLabel6.Text = "add";
			linkLabel6.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					linkLabel6_LinkClicked
				);
			//
			// tbitemunk4
			//
			tbitemunk4.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbitemunk4.Location = new System.Drawing.Point(264, 192);
			tbitemunk4.Name = "tbitemunk4";
			tbitemunk4.Size = new System.Drawing.Size(48, 21);
			tbitemunk4.TabIndex = 17;
			tbitemunk4.Text = "0x00";
			tbitemunk4.TextChanged += new EventHandler(
				ChangeItemUnknown
			);
			//
			// tbitemunk3
			//
			tbitemunk3.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbitemunk3.Location = new System.Drawing.Point(168, 192);
			tbitemunk3.Name = "tbitemunk3";
			tbitemunk3.Size = new System.Drawing.Size(88, 21);
			tbitemunk3.TabIndex = 16;
			tbitemunk3.Text = "0x00000000";
			tbitemunk3.TextChanged += new EventHandler(
				ChangeItemUnknown
			);
			//
			// tbitemunk2
			//
			tbitemunk2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbitemunk2.Location = new System.Drawing.Point(112, 192);
			tbitemunk2.Name = "tbitemunk2";
			tbitemunk2.Size = new System.Drawing.Size(48, 21);
			tbitemunk2.TabIndex = 15;
			tbitemunk2.Text = "0x00";
			tbitemunk2.TextChanged += new EventHandler(
				ChangeItemUnknown
			);
			//
			// tbitemunk1
			//
			tbitemunk1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbitemunk1.Location = new System.Drawing.Point(16, 192);
			tbitemunk1.Name = "tbitemunk1";
			tbitemunk1.Size = new System.Drawing.Size(88, 21);
			tbitemunk1.TabIndex = 14;
			tbitemunk1.Text = "0x00000000";
			tbitemunk1.TextChanged += new EventHandler(
				ChangeItemUnknown
			);
			//
			// label4
			//
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label4.Location = new System.Drawing.Point(8, 176);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(69, 17);
			label4.TabIndex = 13;
			label4.Text = "Unknown:";
			//
			// tbitemflname
			//
			tbitemflname.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Left
						 | AnchorStyles.Right


			;
			tbitemflname.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbitemflname.Location = new System.Drawing.Point(16, 144);
			tbitemflname.Name = "tbitemflname";
			tbitemflname.Size = new System.Drawing.Size(512, 21);
			tbitemflname.TabIndex = 11;
			tbitemflname.Text = "";
			tbitemflname.TextChanged += new EventHandler(
				ChangedItemFilename
			);
			//
			// label3
			//
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label3.Location = new System.Drawing.Point(8, 128);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(67, 17);
			label3.TabIndex = 12;
			label3.Text = "Filename:";
			//
			// lbitem
			//
			lbitem.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Left
						 | AnchorStyles.Right


			;
			lbitem.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lbitem.HorizontalScrollbar = true;
			lbitem.IntegralHeight = false;
			lbitem.Location = new System.Drawing.Point(8, 8);
			lbitem.Name = "lbitem";
			lbitem.Size = new System.Drawing.Size(520, 112);
			lbitem.TabIndex = 10;
			lbitem.SelectedIndexChanged += new EventHandler(
				SelectItems
			);
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
				Shape shape = (Shape)Tag;

				ShapeItem val = new ShapeItem(shape)
				{
					FileName = tbitemflname.Text,
					Unknown1 = Convert.ToInt32(tbitemunk1.Text, 16),
					Unknown2 = Convert.ToByte(tbitemunk2.Text, 16),
					Unknown3 = Convert.ToInt32(tbitemunk3.Text, 16),
					Unknown4 = Convert.ToByte(tbitemunk4.Text, 16)
				};

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
