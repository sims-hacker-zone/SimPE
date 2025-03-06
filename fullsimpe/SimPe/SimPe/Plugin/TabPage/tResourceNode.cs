// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
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
			components = new System.ComponentModel.Container();
			groupBox5 = new GroupBox();
			tb_rn_ver = new TextBox();
			label25 = new Label();
			tb_rn_uk2 = new TextBox();
			label15 = new Label();
			tb_rn_uk1 = new TextBox();
			label22 = new Label();
			groupBox4 = new GroupBox();
			ll_rn_add = new LinkLabel();
			tb_rn_2 = new TextBox();
			label13 = new Label();
			tb_rn_1 = new TextBox();
			label14 = new Label();
			lb_rn = new ListBox();
			ll_rn_delete = new LinkLabel();
			toolTip1 = new ToolTip(components);
			groupBox5.SuspendLayout();
			groupBox4.SuspendLayout();
			SuspendLayout();
			//
			// tResourceNode
			//
			BackColor = System.Drawing.SystemColors.ControlLightLight;
			Controls.Add(groupBox5);
			Controls.Add(groupBox4);
			Location = new System.Drawing.Point(4, 22);
			Name = "tResourceNode";
			Size = new System.Drawing.Size(792, 262);
			TabIndex = 1;
			Text = "ResourceNode";
			Visible = false;
			//
			// groupBox5
			//
			groupBox5.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Bottom
						 | AnchorStyles.Left


			;
			groupBox5.Controls.Add(tb_rn_ver);
			groupBox5.Controls.Add(label25);
			groupBox5.Controls.Add(tb_rn_uk2);
			groupBox5.Controls.Add(label15);
			groupBox5.Controls.Add(tb_rn_uk1);
			groupBox5.Controls.Add(label22);
			groupBox5.FlatStyle = FlatStyle.Standard;
			groupBox5.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox5.Location = new System.Drawing.Point(8, 8);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new System.Drawing.Size(120, 248);
			groupBox5.TabIndex = 7;
			groupBox5.TabStop = false;
			groupBox5.Text = "Settings";
			//
			// tb_rn_ver
			//
			tb_rn_ver.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_rn_ver.Location = new System.Drawing.Point(16, 40);
			tb_rn_ver.Name = "tb_rn_ver";
			tb_rn_ver.Size = new System.Drawing.Size(88, 21);
			tb_rn_ver.TabIndex = 24;
			tb_rn_ver.Text = "0x00000000";
			tb_rn_ver.TextChanged += new EventHandler(
				RNChangeSettings
			);
			//
			// label25
			//
			label25.AutoSize = true;
			label25.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label25.Location = new System.Drawing.Point(8, 24);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(52, 17);
			label25.TabIndex = 23;
			label25.Text = "Version:";
			//
			// tb_rn_uk2
			//
			tb_rn_uk2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_rn_uk2.Location = new System.Drawing.Point(16, 120);
			tb_rn_uk2.Name = "tb_rn_uk2";
			tb_rn_uk2.Size = new System.Drawing.Size(88, 21);
			tb_rn_uk2.TabIndex = 8;
			tb_rn_uk2.Text = "0x00000000";
			tb_rn_uk2.TextChanged += new EventHandler(
				RNChangeSettings
			);
			//
			// label15
			//
			label15.AutoSize = true;
			label15.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label15.Location = new System.Drawing.Point(8, 104);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(73, 17);
			label15.TabIndex = 7;
			label15.Text = "Unknown 2:";
			//
			// tb_rn_uk1
			//
			tb_rn_uk1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_rn_uk1.Location = new System.Drawing.Point(16, 80);
			tb_rn_uk1.Name = "tb_rn_uk1";
			tb_rn_uk1.Size = new System.Drawing.Size(88, 21);
			tb_rn_uk1.TabIndex = 6;
			tb_rn_uk1.Text = "0x00000000";
			tb_rn_uk1.TextChanged += new EventHandler(
				RNChangeSettings
			);
			//
			// label22
			//
			label22.AutoSize = true;
			label22.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label22.Location = new System.Drawing.Point(8, 64);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(73, 17);
			label22.TabIndex = 5;
			label22.Text = "Unknown 1:";
			//
			// groupBox4
			//
			groupBox4.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Bottom
						 | AnchorStyles.Left


			;
			groupBox4.Controls.Add(ll_rn_add);
			groupBox4.Controls.Add(tb_rn_2);
			groupBox4.Controls.Add(label13);
			groupBox4.Controls.Add(tb_rn_1);
			groupBox4.Controls.Add(label14);
			groupBox4.Controls.Add(lb_rn);
			groupBox4.Controls.Add(ll_rn_delete);
			groupBox4.FlatStyle = FlatStyle.Standard;
			groupBox4.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox4.Location = new System.Drawing.Point(136, 8);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new System.Drawing.Size(256, 248);
			groupBox4.TabIndex = 5;
			groupBox4.TabStop = false;
			groupBox4.Text = "Child Nodes:";
			//
			// ll_rn_add
			//
			ll_rn_add.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			ll_rn_add.AutoSize = true;
			ll_rn_add.Location = new System.Drawing.Point(176, 96);
			ll_rn_add.Name = "ll_rn_add";
			ll_rn_add.Size = new System.Drawing.Size(28, 17);
			ll_rn_add.TabIndex = 6;
			ll_rn_add.TabStop = true;
			ll_rn_add.Text = "add";
			ll_rn_add.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					RNItemsAdd
				);
			//
			// tb_rn_2
			//
			tb_rn_2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_rn_2.Location = new System.Drawing.Point(160, 72);
			tb_rn_2.Name = "tb_rn_2";
			tb_rn_2.Size = new System.Drawing.Size(88, 21);
			tb_rn_2.TabIndex = 4;
			tb_rn_2.Text = "0x00000000";
			tb_rn_2.TextChanged += new EventHandler(RNChangedItems);
			//
			// label13
			//
			label13.AutoSize = true;
			label13.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label13.Location = new System.Drawing.Point(152, 56);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(73, 17);
			label13.TabIndex = 3;
			label13.Text = "Unknown 2:";
			//
			// tb_rn_1
			//
			tb_rn_1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_rn_1.Location = new System.Drawing.Point(160, 32);
			tb_rn_1.Name = "tb_rn_1";
			tb_rn_1.Size = new System.Drawing.Size(88, 21);
			tb_rn_1.TabIndex = 2;
			tb_rn_1.Text = "0x0000";
			tb_rn_1.TextChanged += new EventHandler(RNChangedItems);
			//
			// label14
			//
			label14.AutoSize = true;
			label14.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label14.Location = new System.Drawing.Point(152, 16);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(73, 17);
			label14.TabIndex = 1;
			label14.Text = "Unknown 1:";
			//
			// lb_rn
			//
			lb_rn.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Bottom
						 | AnchorStyles.Left


			;
			lb_rn.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lb_rn.IntegralHeight = false;
			lb_rn.Location = new System.Drawing.Point(8, 24);
			lb_rn.Name = "lb_rn";
			lb_rn.Size = new System.Drawing.Size(136, 216);
			lb_rn.TabIndex = 0;
			lb_rn.SelectedIndexChanged += new EventHandler(RNSelect);
			//
			// ll_rn_delete
			//
			ll_rn_delete.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			ll_rn_delete.AutoSize = true;
			ll_rn_delete.Location = new System.Drawing.Point(204, 96);
			ll_rn_delete.Name = "ll_rn_delete";
			ll_rn_delete.Size = new System.Drawing.Size(44, 17);
			ll_rn_delete.TabIndex = 5;
			ll_rn_delete.TabStop = true;
			ll_rn_delete.Text = "delete";
			ll_rn_delete.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					RNItemsDelete
				);
			//
			// fShapeRefNode
			//
			groupBox5.ResumeLayout(false);
			groupBox4.ResumeLayout(false);
			ResumeLayout(false);
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

				rn.Unknown1 = Convert.ToInt32(tb_rn_uk1.Text, 16);
				rn.Unknown2 = Convert.ToInt32(tb_rn_uk2.Text, 16);
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

			if (lb_rn.SelectedIndex < 0)
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

			if (lb_rn.SelectedIndex < 0)
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
				ResourceNodeItem b = new ResourceNodeItem
				{
					Unknown1 = (short)Convert.ToUInt16(tb_rn_1.Text, 16),
					Unknown2 = (int)Convert.ToUInt32(tb_rn_2.Text, 16)
				};

				rn.Items.Add(b);
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

				rn.Items.Remove(b);
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
