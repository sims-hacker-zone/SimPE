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
	public class GeometryNode
		:
		//System.Windows.Forms.UserControl
		System.Windows.Forms.TabPage
	{
		private GroupBox groupBox11;
		internal TextBox tb_gn_ver;
		private Label label29;
		internal TextBox tb_gn_uk3;
		private Label label33;
		internal TextBox tb_gn_uk2;
		private Label label35;
		internal TextBox tb_gn_count;
		private Label label36;
		internal TextBox tb_gn_uk1;
		private Label label37;
		private GroupBox groupBox17;
		internal ComboBox cb_gn_list;
		internal TabControl tc_gn;

		//private System.ComponentModel.IContainer components;

		public GeometryNode()
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
				/*if(components != null)
				{
					components.Dispose();
				}*/
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
			groupBox11 = new GroupBox();
			tb_gn_ver = new TextBox();
			label29 = new Label();
			tb_gn_uk3 = new TextBox();
			label33 = new Label();
			tb_gn_uk2 = new TextBox();
			label35 = new Label();
			tb_gn_count = new TextBox();
			label36 = new Label();
			tb_gn_uk1 = new TextBox();
			label37 = new Label();
			groupBox17 = new GroupBox();
			tc_gn = new TabControl();
			cb_gn_list = new ComboBox();
			groupBox11.SuspendLayout();
			groupBox17.SuspendLayout();
			SuspendLayout();

			//
			// tGeometryNode
			//
			BackColor = System.Drawing.SystemColors.ControlLightLight;
			Controls.Add(groupBox11);
			Controls.Add(groupBox17);
			Location = new System.Drawing.Point(4, 22);
			Name = "tGeometryNode";
			Size = new System.Drawing.Size(792, 262);
			TabIndex = 5;
			Text = "GeometryNode";
			//
			// groupBox11
			//
			groupBox11.Controls.Add(tb_gn_ver);
			groupBox11.Controls.Add(label29);
			groupBox11.Controls.Add(tb_gn_uk3);
			groupBox11.Controls.Add(label33);
			groupBox11.Controls.Add(tb_gn_uk2);
			groupBox11.Controls.Add(label35);
			groupBox11.Controls.Add(tb_gn_count);
			groupBox11.Controls.Add(label36);
			groupBox11.Controls.Add(tb_gn_uk1);
			groupBox11.Controls.Add(label37);
			groupBox11.FlatStyle = FlatStyle.System;
			groupBox11.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			groupBox11.Location = new System.Drawing.Point(8, 8);
			groupBox11.Name = "groupBox11";
			groupBox11.Size = new System.Drawing.Size(224, 152);
			groupBox11.TabIndex = 7;
			groupBox11.TabStop = false;
			groupBox11.Text = "Settings";
			//
			// tb_gn_ver
			//
			tb_gn_ver.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			tb_gn_ver.Location = new System.Drawing.Point(16, 32);
			tb_gn_ver.Name = "tb_gn_ver";
			tb_gn_ver.Size = new System.Drawing.Size(88, 21);
			tb_gn_ver.TabIndex = 22;
			tb_gn_ver.Text = "0x00000000";
			tb_gn_ver.TextChanged += new EventHandler(
				GrNSettingsChange
			);
			//
			// label29
			//
			label29.AutoSize = true;
			label29.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			label29.Location = new System.Drawing.Point(8, 16);
			label29.Name = "label29";
			label29.Size = new System.Drawing.Size(52, 17);
			label29.TabIndex = 21;
			label29.Text = "Version:";
			//
			// tb_gn_uk3
			//
			tb_gn_uk3.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			tb_gn_uk3.Location = new System.Drawing.Point(128, 120);
			tb_gn_uk3.Name = "tb_gn_uk3";
			tb_gn_uk3.Size = new System.Drawing.Size(88, 21);
			tb_gn_uk3.TabIndex = 14;
			tb_gn_uk3.Text = "0x00";
			tb_gn_uk3.TextChanged += new EventHandler(
				GrNSettingsChange
			);
			//
			// label33
			//
			label33.AutoSize = true;
			label33.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			label33.Location = new System.Drawing.Point(120, 104);
			label33.Name = "label33";
			label33.Size = new System.Drawing.Size(73, 17);
			label33.TabIndex = 13;
			label33.Text = "Unknown 3:";
			//
			// tb_gn_uk2
			//
			tb_gn_uk2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			tb_gn_uk2.Location = new System.Drawing.Point(128, 72);
			tb_gn_uk2.Name = "tb_gn_uk2";
			tb_gn_uk2.Size = new System.Drawing.Size(88, 21);
			tb_gn_uk2.TabIndex = 10;
			tb_gn_uk2.Text = "0x0000";
			tb_gn_uk2.TextChanged += new EventHandler(
				GrNSettingsChange
			);
			//
			// label35
			//
			label35.AutoSize = true;
			label35.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			label35.Location = new System.Drawing.Point(120, 56);
			label35.Name = "label35";
			label35.Size = new System.Drawing.Size(73, 17);
			label35.TabIndex = 9;
			label35.Text = "Unknown 2:";
			//
			// tb_gn_count
			//
			tb_gn_count.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			tb_gn_count.Location = new System.Drawing.Point(16, 120);
			tb_gn_count.Name = "tb_gn_count";
			tb_gn_count.ReadOnly = true;
			tb_gn_count.Size = new System.Drawing.Size(88, 21);
			tb_gn_count.TabIndex = 8;
			tb_gn_count.Text = "0x00000000";
			//
			// label36
			//
			label36.AutoSize = true;
			label36.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			label36.Location = new System.Drawing.Point(8, 104);
			label36.Name = "label36";
			label36.Size = new System.Drawing.Size(43, 17);
			label36.TabIndex = 7;
			label36.Text = "Count:";
			//
			// tb_gn_uk1
			//
			tb_gn_uk1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			tb_gn_uk1.Location = new System.Drawing.Point(16, 72);
			tb_gn_uk1.Name = "tb_gn_uk1";
			tb_gn_uk1.Size = new System.Drawing.Size(88, 21);
			tb_gn_uk1.TabIndex = 6;
			tb_gn_uk1.Text = "0x0000";
			tb_gn_uk1.TextChanged += new EventHandler(
				GrNSettingsChange
			);
			//
			// label37
			//
			label37.AutoSize = true;
			label37.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			label37.Location = new System.Drawing.Point(8, 56);
			label37.Name = "label37";
			label37.Size = new System.Drawing.Size(73, 17);
			label37.TabIndex = 5;
			label37.Text = "Unknown 1:";
			//
			// groupBox17
			//
			groupBox17.Anchor = (
				(AnchorStyles)(
					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)
				)
			);
			groupBox17.Controls.Add(tc_gn);
			groupBox17.Controls.Add(cb_gn_list);
			groupBox17.FlatStyle = FlatStyle.System;
			groupBox17.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			groupBox17.Location = new System.Drawing.Point(240, 8);
			groupBox17.Name = "groupBox17";
			groupBox17.Size = new System.Drawing.Size(544, 250);
			groupBox17.TabIndex = 23;
			groupBox17.TabStop = false;
			groupBox17.Text = "Embedded Blocks:";
			//
			// tc_gn
			//
			tc_gn.Anchor = (
				(AnchorStyles)(
					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)
				)
			);
			tc_gn.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			tc_gn.Location = new System.Drawing.Point(8, 56);
			tc_gn.Name = "tc_gn";
			tc_gn.SelectedIndex = 0;
			tc_gn.Size = new System.Drawing.Size(528, 186);
			tc_gn.TabIndex = 10;
			//
			// cb_gn_list
			//
			cb_gn_list.Anchor = (
				(AnchorStyles)(
					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)
				)
			);
			cb_gn_list.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cb_gn_list.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			cb_gn_list.Location = new System.Drawing.Point(8, 24);
			cb_gn_list.Name = "cb_gn_list";
			cb_gn_list.Size = new System.Drawing.Size(528, 21);
			cb_gn_list.TabIndex = 9;
			cb_gn_list.SelectedIndexChanged += new EventHandler(
				SelectGmndChildBlock
			);
			//
			// fShapeRefNode
			//

			groupBox11.ResumeLayout(false);
			groupBox17.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion


		private void GrNSettingsChange(object sender, EventArgs e)
		{
			if (Tag == null)
			{
				return;
			}

			try
			{
				Plugin.GeometryNode arb = (Plugin.GeometryNode)Tag;

				arb.Version = Convert.ToUInt32(tb_gn_ver.Text, 16);
				arb.Unknown1 = (short)Convert.ToUInt16(tb_gn_uk1.Text, 16);
				arb.Unknown2 = (short)Convert.ToUInt16(tb_gn_uk2.Text, 16);
				arb.Unknown3 = Convert.ToByte(tb_gn_uk3.Text, 16);

				arb.Changed = true;
			}
			catch (Exception)
			{
				//Helper.ExceptionMessage("", ex);
			}
		}

		private void SelectGmndChildBlock(object sender, EventArgs e)
		{
			if (cb_gn_list.Tag != null)
			{
				return;
			}

			if (cb_gn_list.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				cb_gn_list.Tag = true;
				CountedListItem cli = (CountedListItem)
					cb_gn_list.Items[cb_gn_list.SelectedIndex];
				AbstractRcolBlock rb = (AbstractRcolBlock)cli.Object;

				BuildChildTabControl(rb);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				cb_gn_list.Tag = null;
			}
		}

		internal void BuildChildTabControl(AbstractRcolBlock rb)
		{
			tc_gn.TabPages.Clear();

			if (rb == null)
			{
				return;
			}

			if (rb.TabPage != null)
			{
				rb.AddToTabControl(tc_gn);
			}
		}
	}
}
