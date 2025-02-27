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
	public class ResourceNode
		:
		//System.Windows.Forms.UserControl
		System.Windows.Forms.TabPage
	{
		private GroupBox groupBox4;
		private LinkLabel ll_rn_add;
		private TextBox tb_rn_2;
		private Label label13;
		private TextBox tb_rn_1;
		private Label label14;
		internal ListBox lb_rn;
		private LinkLabel ll_rn_delete;
		private GroupBox groupBox5;
		internal TextBox tb_rn_uk1;
		private Label label22;
		internal TextBox tb_rn_uk2;
		private Label label15;
		internal TextBox tb_rn_ver;
		private Label label25;
		private ToolTip toolTip1;
		private System.ComponentModel.IContainer components;

		public ResourceNode()
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
				this.Tag = null;
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
			this.components = new System.ComponentModel.Container();
			this.groupBox5 = new GroupBox();
			this.tb_rn_ver = new TextBox();
			this.label25 = new Label();
			this.tb_rn_uk2 = new TextBox();
			this.label15 = new Label();
			this.tb_rn_uk1 = new TextBox();
			this.label22 = new Label();
			this.groupBox4 = new GroupBox();
			this.ll_rn_add = new LinkLabel();
			this.tb_rn_2 = new TextBox();
			this.label13 = new Label();
			this.tb_rn_1 = new TextBox();
			this.label14 = new Label();
			this.lb_rn = new ListBox();
			this.ll_rn_delete = new LinkLabel();
			this.toolTip1 = new ToolTip(this.components);
			this.groupBox5.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			//
			// tResourceNode
			//
			this.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox4);
			this.Location = new System.Drawing.Point(4, 22);
			this.Name = "tResourceNode";
			this.Size = new System.Drawing.Size(792, 262);
			this.TabIndex = 1;
			this.Text = "ResourceNode";
			this.Visible = false;
			//
			// groupBox5
			//
			this.groupBox5.Anchor = (
				(AnchorStyles)(
					(
						(
							AnchorStyles.Top
							| AnchorStyles.Bottom
						) | AnchorStyles.Left
					)
				)
			);
			this.groupBox5.Controls.Add(this.tb_rn_ver);
			this.groupBox5.Controls.Add(this.label25);
			this.groupBox5.Controls.Add(this.tb_rn_uk2);
			this.groupBox5.Controls.Add(this.label15);
			this.groupBox5.Controls.Add(this.tb_rn_uk1);
			this.groupBox5.Controls.Add(this.label22);
			this.groupBox5.FlatStyle = FlatStyle.Standard;
			this.groupBox5.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.groupBox5.Location = new System.Drawing.Point(8, 8);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(120, 248);
			this.groupBox5.TabIndex = 7;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Settings";
			//
			// tb_rn_ver
			//
			this.tb_rn_ver.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.tb_rn_ver.Location = new System.Drawing.Point(16, 40);
			this.tb_rn_ver.Name = "tb_rn_ver";
			this.tb_rn_ver.Size = new System.Drawing.Size(88, 21);
			this.tb_rn_ver.TabIndex = 24;
			this.tb_rn_ver.Text = "0x00000000";
			this.tb_rn_ver.TextChanged += new EventHandler(
				this.RNChangeSettings
			);
			//
			// label25
			//
			this.label25.AutoSize = true;
			this.label25.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.label25.Location = new System.Drawing.Point(8, 24);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(52, 17);
			this.label25.TabIndex = 23;
			this.label25.Text = "Version:";
			//
			// tb_rn_uk2
			//
			this.tb_rn_uk2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.tb_rn_uk2.Location = new System.Drawing.Point(16, 120);
			this.tb_rn_uk2.Name = "tb_rn_uk2";
			this.tb_rn_uk2.Size = new System.Drawing.Size(88, 21);
			this.tb_rn_uk2.TabIndex = 8;
			this.tb_rn_uk2.Text = "0x00000000";
			this.tb_rn_uk2.TextChanged += new EventHandler(
				this.RNChangeSettings
			);
			//
			// label15
			//
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.label15.Location = new System.Drawing.Point(8, 104);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(73, 17);
			this.label15.TabIndex = 7;
			this.label15.Text = "Unknown 2:";
			//
			// tb_rn_uk1
			//
			this.tb_rn_uk1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.tb_rn_uk1.Location = new System.Drawing.Point(16, 80);
			this.tb_rn_uk1.Name = "tb_rn_uk1";
			this.tb_rn_uk1.Size = new System.Drawing.Size(88, 21);
			this.tb_rn_uk1.TabIndex = 6;
			this.tb_rn_uk1.Text = "0x00000000";
			this.tb_rn_uk1.TextChanged += new EventHandler(
				this.RNChangeSettings
			);
			//
			// label22
			//
			this.label22.AutoSize = true;
			this.label22.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.label22.Location = new System.Drawing.Point(8, 64);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(73, 17);
			this.label22.TabIndex = 5;
			this.label22.Text = "Unknown 1:";
			//
			// groupBox4
			//
			this.groupBox4.Anchor = (
				(AnchorStyles)(
					(
						(
							AnchorStyles.Top
							| AnchorStyles.Bottom
						) | AnchorStyles.Left
					)
				)
			);
			this.groupBox4.Controls.Add(this.ll_rn_add);
			this.groupBox4.Controls.Add(this.tb_rn_2);
			this.groupBox4.Controls.Add(this.label13);
			this.groupBox4.Controls.Add(this.tb_rn_1);
			this.groupBox4.Controls.Add(this.label14);
			this.groupBox4.Controls.Add(this.lb_rn);
			this.groupBox4.Controls.Add(this.ll_rn_delete);
			this.groupBox4.FlatStyle = FlatStyle.Standard;
			this.groupBox4.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.groupBox4.Location = new System.Drawing.Point(136, 8);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(256, 248);
			this.groupBox4.TabIndex = 5;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Child Nodes:";
			//
			// ll_rn_add
			//
			this.ll_rn_add.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)
				)
			);
			this.ll_rn_add.AutoSize = true;
			this.ll_rn_add.Location = new System.Drawing.Point(176, 96);
			this.ll_rn_add.Name = "ll_rn_add";
			this.ll_rn_add.Size = new System.Drawing.Size(28, 17);
			this.ll_rn_add.TabIndex = 6;
			this.ll_rn_add.TabStop = true;
			this.ll_rn_add.Text = "add";
			this.ll_rn_add.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					this.RNItemsAdd
				);
			//
			// tb_rn_2
			//
			this.tb_rn_2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.tb_rn_2.Location = new System.Drawing.Point(160, 72);
			this.tb_rn_2.Name = "tb_rn_2";
			this.tb_rn_2.Size = new System.Drawing.Size(88, 21);
			this.tb_rn_2.TabIndex = 4;
			this.tb_rn_2.Text = "0x00000000";
			this.tb_rn_2.TextChanged += new EventHandler(this.RNChangedItems);
			//
			// label13
			//
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.label13.Location = new System.Drawing.Point(152, 56);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(73, 17);
			this.label13.TabIndex = 3;
			this.label13.Text = "Unknown 2:";
			//
			// tb_rn_1
			//
			this.tb_rn_1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.tb_rn_1.Location = new System.Drawing.Point(160, 32);
			this.tb_rn_1.Name = "tb_rn_1";
			this.tb_rn_1.Size = new System.Drawing.Size(88, 21);
			this.tb_rn_1.TabIndex = 2;
			this.tb_rn_1.Text = "0x0000";
			this.tb_rn_1.TextChanged += new EventHandler(this.RNChangedItems);
			//
			// label14
			//
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.label14.Location = new System.Drawing.Point(152, 16);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(73, 17);
			this.label14.TabIndex = 1;
			this.label14.Text = "Unknown 1:";
			//
			// lb_rn
			//
			this.lb_rn.Anchor = (
				(AnchorStyles)(
					(
						(
							AnchorStyles.Top
							| AnchorStyles.Bottom
						) | AnchorStyles.Left
					)
				)
			);
			this.lb_rn.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.lb_rn.IntegralHeight = false;
			this.lb_rn.Location = new System.Drawing.Point(8, 24);
			this.lb_rn.Name = "lb_rn";
			this.lb_rn.Size = new System.Drawing.Size(136, 216);
			this.lb_rn.TabIndex = 0;
			this.lb_rn.SelectedIndexChanged += new EventHandler(this.RNSelect);
			//
			// ll_rn_delete
			//
			this.ll_rn_delete.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)
				)
			);
			this.ll_rn_delete.AutoSize = true;
			this.ll_rn_delete.Location = new System.Drawing.Point(204, 96);
			this.ll_rn_delete.Name = "ll_rn_delete";
			this.ll_rn_delete.Size = new System.Drawing.Size(44, 17);
			this.ll_rn_delete.TabIndex = 5;
			this.ll_rn_delete.TabStop = true;
			this.ll_rn_delete.Text = "delete";
			this.ll_rn_delete.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					this.RNItemsDelete
				);
			//
			// fShapeRefNode
			//
			this.groupBox5.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion

		private void RNChangeSettings(object sender, EventArgs e)
		{
			if (Tag == null)
			{
				return;
			}

			try
			{
				Plugin.ResourceNode rn = (Plugin.ResourceNode)Tag;

				rn.Unknown1 = (int)Convert.ToInt32(this.tb_rn_uk1.Text, 16);
				rn.Unknown2 = (int)Convert.ToInt32(this.tb_rn_uk2.Text, 16);
				rn.Version = Convert.ToUInt32(tb_rn_ver.Text, 16);

				rn.Changed = true;
			}
			catch (Exception)
			{
				//Helper.ExceptionMessage("", ex);
			}
		}

		#region Select RN Items
		private void RNSelect(object sender, EventArgs e)
		{
			if (lb_rn.Tag != null)
			{
				return;
			}

			if (this.lb_rn.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				lb_rn.Tag = true;
				Plugin.ResourceNode rn = (Plugin.ResourceNode)Tag;
				ResourceNodeItem b = (ResourceNodeItem)lb_rn.Items[lb_rn.SelectedIndex];

				tb_rn_1.Text = "0x" + Helper.HexString((ushort)b.Unknown1);
				tb_rn_2.Text = "0x" + Helper.HexString((uint)b.Unknown2);
				rn.Changed = true;
			}
			catch (Exception)
			{
				//Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lb_rn.Tag = null;
			}
		}

		private void RNChangedItems(object sender, EventArgs e)
		{
			if (lb_rn.Tag != null)
			{
				return;
			}

			if (this.lb_rn.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				lb_rn.Tag = true;
				Plugin.ResourceNode rn = (Plugin.ResourceNode)Tag;
				ResourceNodeItem b = (ResourceNodeItem)lb_rn.Items[lb_rn.SelectedIndex];

				b.Unknown1 = (short)Convert.ToUInt16(tb_rn_1.Text, 16);
				b.Unknown2 = (int)Convert.ToUInt32(tb_rn_2.Text, 16);

				lb_rn.Items[lb_rn.SelectedIndex] = b;
				rn.Changed = true;
			}
			catch (Exception)
			{
				//Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lb_rn.Tag = null;
			}
		}

		private void RNItemsAdd(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (Tag == null)
			{
				return;
			}

			try
			{
				lb_rn.Tag = true;
				Plugin.ResourceNode rn = (Plugin.ResourceNode)Tag;
				ResourceNodeItem b = new ResourceNodeItem();

				b.Unknown1 = (short)Convert.ToUInt16(tb_rn_1.Text, 16);
				b.Unknown2 = (int)Convert.ToUInt32(tb_rn_2.Text, 16);

				rn.Items = (ResourceNodeItem[])Helper.Add(rn.Items, b);
				lb_rn.Items.Add(b);
				rn.Changed = true;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lb_rn.Tag = null;
			}
		}

		private void RNItemsDelete(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (Tag == null)
			{
				return;
			}

			if (lb_rn.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				lb_rn.Tag = true;
				Plugin.ResourceNode rn = (Plugin.ResourceNode)Tag;
				ResourceNodeItem b = (ResourceNodeItem)lb_rn.Items[lb_rn.SelectedIndex];

				rn.Items = (ResourceNodeItem[])Helper.Delete(rn.Items, b);
				lb_rn.Items.Remove(b);
				rn.Changed = true;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lb_rn.Tag = null;
			}
		}
		#endregion
	}
}
