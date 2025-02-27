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
	public class ObjectGraphNode
		:
		//System.Windows.Forms.UserControl
		System.Windows.Forms.TabPage
	{
		private GroupBox groupBox8;
		private GroupBox groupBox9;
		private LinkLabel ll_ogn_add;
		private TextBox tb_ogn_2;
		private Label label20;
		private TextBox tb_ogn_1;
		private Label label21;
		internal ListBox lb_ogn;
		private LinkLabel ll_ogn_delete;
		private TextBox tb_ogn_3;
		private Label label23;
		internal TextBox tb_ogn_file;
		private Label label18;
		internal TextBox tb_ogn_ver;
		private Label label27;
		private ToolTip toolTip1;
		private System.ComponentModel.IContainer components;

		public ObjectGraphNode()
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
			components = new System.ComponentModel.Container();
			groupBox8 = new GroupBox();
			tb_ogn_ver = new TextBox();
			label27 = new Label();
			tb_ogn_file = new TextBox();
			label18 = new Label();
			groupBox9 = new GroupBox();
			tb_ogn_3 = new TextBox();
			label23 = new Label();
			ll_ogn_add = new LinkLabel();
			tb_ogn_2 = new TextBox();
			label20 = new Label();
			tb_ogn_1 = new TextBox();
			label21 = new Label();
			lb_ogn = new ListBox();
			ll_ogn_delete = new LinkLabel();
			toolTip1 = new ToolTip(components);
			groupBox8.SuspendLayout();
			groupBox9.SuspendLayout();
			SuspendLayout();
			//
			// tObjectGraphNode
			//
			BackColor = System.Drawing.SystemColors.ControlLightLight;
			Controls.Add(groupBox8);
			Controls.Add(groupBox9);
			Location = new System.Drawing.Point(4, 22);
			Name = "tObjectGraphNode";
			Size = new System.Drawing.Size(792, 262);
			TabIndex = 3;
			Text = "ObjectGraphNode";
			//
			// groupBox8
			//
			groupBox8.Anchor = (
				(AnchorStyles)(
					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)
				)
			);
			groupBox8.Controls.Add(tb_ogn_ver);
			groupBox8.Controls.Add(label27);
			groupBox8.Controls.Add(tb_ogn_file);
			groupBox8.Controls.Add(label18);
			groupBox8.FlatStyle = FlatStyle.System;
			groupBox8.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			groupBox8.Location = new System.Drawing.Point(8, 7);
			groupBox8.Name = "groupBox8";
			groupBox8.Size = new System.Drawing.Size(512, 113);
			groupBox8.TabIndex = 10;
			groupBox8.TabStop = false;
			groupBox8.Text = "Settings";
			//
			// tb_ogn_ver
			//
			tb_ogn_ver.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			tb_ogn_ver.Location = new System.Drawing.Point(16, 36);
			tb_ogn_ver.Name = "tb_ogn_ver";
			tb_ogn_ver.Size = new System.Drawing.Size(88, 21);
			tb_ogn_ver.TabIndex = 24;
			tb_ogn_ver.Text = "0x00000000";
			tb_ogn_ver.TextChanged += new EventHandler(
				OGNChangeSettings
			);
			//
			// label27
			//
			label27.AutoSize = true;
			label27.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			label27.Location = new System.Drawing.Point(8, 20);
			label27.Name = "label27";
			label27.Size = new System.Drawing.Size(52, 17);
			label27.TabIndex = 23;
			label27.Text = "Version:";
			//
			// tb_ogn_file
			//
			tb_ogn_file.Anchor = (
				(AnchorStyles)(
					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)
				)
			);
			tb_ogn_file.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			tb_ogn_file.Location = new System.Drawing.Point(16, 76);
			tb_ogn_file.Name = "tb_ogn_file";
			tb_ogn_file.Size = new System.Drawing.Size(480, 21);
			tb_ogn_file.TabIndex = 20;
			tb_ogn_file.Text = "0x0000";
			tb_ogn_file.TextChanged += new EventHandler(
				OGNChangeSettings
			);
			//
			// label18
			//
			label18.AutoSize = true;
			label18.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			label18.Location = new System.Drawing.Point(8, 60);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(61, 17);
			label18.TabIndex = 19;
			label18.Text = "Filename:";
			//
			// groupBox9
			//
			groupBox9.Anchor = (
				(AnchorStyles)(
					(
						(
							AnchorStyles.Top
							| AnchorStyles.Bottom
						) | AnchorStyles.Right
					)
				)
			);
			groupBox9.Controls.Add(tb_ogn_3);
			groupBox9.Controls.Add(label23);
			groupBox9.Controls.Add(ll_ogn_add);
			groupBox9.Controls.Add(tb_ogn_2);
			groupBox9.Controls.Add(label20);
			groupBox9.Controls.Add(tb_ogn_1);
			groupBox9.Controls.Add(label21);
			groupBox9.Controls.Add(lb_ogn);
			groupBox9.Controls.Add(ll_ogn_delete);
			groupBox9.FlatStyle = FlatStyle.System;
			groupBox9.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			groupBox9.Location = new System.Drawing.Point(528, 8);
			groupBox9.Name = "groupBox9";
			groupBox9.Size = new System.Drawing.Size(256, 248);
			groupBox9.TabIndex = 9;
			groupBox9.TabStop = false;
			groupBox9.Text = "Datalist Extension Reference";
			//
			// tb_ogn_3
			//
			tb_ogn_3.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			tb_ogn_3.Location = new System.Drawing.Point(160, 112);
			tb_ogn_3.Name = "tb_ogn_3";
			tb_ogn_3.Size = new System.Drawing.Size(88, 21);
			tb_ogn_3.TabIndex = 8;
			tb_ogn_3.Text = "0x00000000";
			toolTip1.SetToolTip(
				tb_ogn_3,
				"Index of the DataList Extenion in the current Blocklist"
			);
			tb_ogn_3.TextChanged += new EventHandler(OGNChangedItems);
			//
			// label23
			//
			label23.AutoSize = true;
			label23.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			label23.Location = new System.Drawing.Point(152, 96);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(42, 17);
			label23.TabIndex = 7;
			label23.Text = "Index:";
			//
			// ll_ogn_add
			//
			ll_ogn_add.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)
				)
			);
			ll_ogn_add.AutoSize = true;
			ll_ogn_add.Location = new System.Drawing.Point(176, 136);
			ll_ogn_add.Name = "ll_ogn_add";
			ll_ogn_add.Size = new System.Drawing.Size(28, 17);
			ll_ogn_add.TabIndex = 6;
			ll_ogn_add.TabStop = true;
			ll_ogn_add.Text = "add";
			ll_ogn_add.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					OGNItemsAdd
				);
			//
			// tb_ogn_2
			//
			tb_ogn_2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			tb_ogn_2.Location = new System.Drawing.Point(160, 72);
			tb_ogn_2.Name = "tb_ogn_2";
			tb_ogn_2.Size = new System.Drawing.Size(88, 21);
			tb_ogn_2.TabIndex = 4;
			tb_ogn_2.Text = "0x00";
			toolTip1.SetToolTip(
				tb_ogn_2,
				"0x00=Independant DatListExtension, 0x01=DataListExtension depends on anthoer RCOL"
					+ ""
			);
			tb_ogn_2.TextChanged += new EventHandler(OGNChangedItems);
			//
			// label20
			//
			label20.AutoSize = true;
			label20.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			label20.Location = new System.Drawing.Point(152, 56);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(71, 17);
			label20.TabIndex = 3;
			label20.Text = "Dependant:";
			//
			// tb_ogn_1
			//
			tb_ogn_1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			tb_ogn_1.Location = new System.Drawing.Point(160, 32);
			tb_ogn_1.Name = "tb_ogn_1";
			tb_ogn_1.Size = new System.Drawing.Size(88, 21);
			tb_ogn_1.TabIndex = 2;
			tb_ogn_1.Text = "0x00";
			toolTip1.SetToolTip(tb_ogn_1, "0x01=Enabled");
			tb_ogn_1.TextChanged += new EventHandler(OGNChangedItems);
			//
			// label21
			//
			label21.AutoSize = true;
			label21.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			label21.Location = new System.Drawing.Point(152, 16);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(54, 17);
			label21.TabIndex = 1;
			label21.Text = "Enabled:";
			//
			// lb_ogn
			//
			lb_ogn.Anchor = (
				(AnchorStyles)(
					(
						(
							AnchorStyles.Top
							| AnchorStyles.Bottom
						) | AnchorStyles.Left
					)
				)
			);
			lb_ogn.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			lb_ogn.IntegralHeight = false;
			lb_ogn.Location = new System.Drawing.Point(8, 24);
			lb_ogn.Name = "lb_ogn";
			lb_ogn.Size = new System.Drawing.Size(136, 216);
			lb_ogn.TabIndex = 0;
			lb_ogn.SelectedIndexChanged += new EventHandler(OGNSelect);
			//
			// ll_ogn_delete
			//
			ll_ogn_delete.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)
				)
			);
			ll_ogn_delete.AutoSize = true;
			ll_ogn_delete.Location = new System.Drawing.Point(204, 136);
			ll_ogn_delete.Name = "ll_ogn_delete";
			ll_ogn_delete.Size = new System.Drawing.Size(44, 17);
			ll_ogn_delete.TabIndex = 5;
			ll_ogn_delete.TabStop = true;
			ll_ogn_delete.Text = "delete";
			ll_ogn_delete.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					OGNItemsDelete
				);
			//
			// fShapeRefNode
			//
			groupBox8.ResumeLayout(false);
			groupBox9.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion

		private void OGNChangeSettings(object sender, EventArgs e)
		{
			if (Tag == null)
			{
				return;
			}

			try
			{
				Plugin.ObjectGraphNode ogn = (Plugin.ObjectGraphNode)Tag;

				ogn.FileName = tb_ogn_file.Text;
				ogn.Version = Convert.ToUInt32(tb_ogn_ver.Text, 16);
				ogn.Changed = true;
			}
			catch (Exception)
			{
				//Helper.ExceptionMessage("", ex);
			}
		}

		#region Select OGN Items
		private void OGNSelect(object sender, EventArgs e)
		{
			if (Tag == null)
			{
				return;
			}

			if (lb_ogn.Tag != null)
			{
				return;
			}

			if (lb_ogn.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				lb_ogn.Tag = true;
				Plugin.ObjectGraphNode ogn = (Plugin.ObjectGraphNode)Tag;
				ObjectGraphNodeItem b = (ObjectGraphNodeItem)
					lb_ogn.Items[lb_ogn.SelectedIndex];

				tb_ogn_1.Text = "0x" + Helper.HexString(b.Enabled);
				tb_ogn_2.Text = "0x" + Helper.HexString(b.Dependant);
				tb_ogn_3.Text = "0x" + Helper.HexString(b.Index);
				ogn.Changed = true;
			}
			catch (Exception)
			{
				//Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lb_ogn.Tag = null;
			}
		}

		private void OGNChangedItems(object sender, EventArgs e)
		{
			if (Tag == null)
			{
				return;
			}

			if (lb_ogn.Tag != null)
			{
				return;
			}

			if (lb_ogn.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				lb_ogn.Tag = true;
				Plugin.ObjectGraphNode ogn = (Plugin.ObjectGraphNode)Tag;
				ObjectGraphNodeItem b = (ObjectGraphNodeItem)
					lb_ogn.Items[lb_ogn.SelectedIndex];

				b.Enabled = Convert.ToByte(tb_ogn_1.Text, 16);
				b.Dependant = Convert.ToByte(tb_ogn_2.Text, 16);
				b.Index = Convert.ToUInt32(tb_ogn_3.Text, 16);

				lb_ogn.Items[lb_ogn.SelectedIndex] = b;
				ogn.Changed = true;
			}
			catch (Exception)
			{
				//Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lb_ogn.Tag = null;
			}
		}

		private void OGNItemsAdd(
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
				lb_ogn.Tag = true;
				Plugin.ObjectGraphNode ogn = (Plugin.ObjectGraphNode)Tag;
				ObjectGraphNodeItem b = new ObjectGraphNodeItem();

				tb_ogn_1.Text = "0x" + Helper.HexString(b.Enabled);
				tb_ogn_2.Text = "0x" + Helper.HexString(b.Dependant);
				tb_ogn_3.Text = "0x" + Helper.HexString(b.Index);

				ogn.Items = (ObjectGraphNodeItem[])Helper.Add(ogn.Items, b);
				lb_ogn.Items.Add(b);
				ogn.Changed = true;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lb_ogn.Tag = null;
			}
		}

		private void OGNItemsDelete(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (Tag == null)
			{
				return;
			}

			if (lb_ogn.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				lb_ogn.Tag = true;
				Plugin.ObjectGraphNode ogn = (Plugin.ObjectGraphNode)Tag;
				ObjectGraphNodeItem b = (ObjectGraphNodeItem)
					lb_ogn.Items[lb_ogn.SelectedIndex];

				ogn.Items = (ObjectGraphNodeItem[])Helper.Delete(ogn.Items, b);
				lb_ogn.Items.Remove(b);
				ogn.Changed = true;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lb_ogn.Tag = null;
			}
		}
		#endregion
	}
}
