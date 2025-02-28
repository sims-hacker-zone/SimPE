// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Windows.Forms;

namespace SimPe.Plugin.TabPage
{
	/// <summary>
	/// Summary description for fShapeRefNode.
	/// </summary>
	public class GenericRcol
		:
		//System.Windows.Forms.UserControl
		System.Windows.Forms.TabPage
	{
		private GroupBox groupBox10;
		internal TextBox tb_ver;
		private Label label28;
		internal PropertyGrid gen_pg;

		//private System.ComponentModel.IContainer components;

		public GenericRcol()
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
			groupBox10 = new GroupBox();
			gen_pg = new PropertyGrid();
			tb_ver = new TextBox();
			label28 = new Label();
			groupBox10.SuspendLayout();
			SuspendLayout();
			//
			// tGenericRcol
			//
			BackColor = System.Drawing.SystemColors.ControlLightLight;
			Controls.Add(groupBox10);
			Location = new System.Drawing.Point(4, 22);
			Name = "tGenericRcol";
			Size = new System.Drawing.Size(792, 262);
			TabIndex = 4;
			Text = "GenericRcol";
			//
			// groupBox10
			//
			groupBox10.Anchor =




								AnchorStyles.Top
								| AnchorStyles.Bottom
							 | AnchorStyles.Left
						 | AnchorStyles.Right


			;
			groupBox10.Controls.Add(gen_pg);
			groupBox10.Controls.Add(tb_ver);
			groupBox10.Controls.Add(label28);
			groupBox10.FlatStyle = FlatStyle.System;
			groupBox10.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox10.Location = new System.Drawing.Point(8, 8);
			groupBox10.Name = "groupBox10";
			groupBox10.Size = new System.Drawing.Size(776, 250);
			groupBox10.TabIndex = 11;
			groupBox10.TabStop = false;
			groupBox10.Text = "Settings";
			//
			// gen_pg
			//
			gen_pg.Anchor =




								AnchorStyles.Top
								| AnchorStyles.Bottom
							 | AnchorStyles.Left
						 | AnchorStyles.Right


			;
			gen_pg.CommandsBackColor = System
				.Drawing
				.SystemColors
				.ControlLightLight;
			gen_pg.CommandsVisibleIfAvailable = true;
			gen_pg.HelpVisible = false;
			gen_pg.LargeButtons = false;
			gen_pg.LineColor = System.Drawing.SystemColors.ScrollBar;
			gen_pg.Location = new System.Drawing.Point(112, 24);
			gen_pg.Name = "gen_pg";
			gen_pg.Size = new System.Drawing.Size(656, 218);
			gen_pg.TabIndex = 25;
			gen_pg.Text = "Generic Properties";
			gen_pg.ToolbarVisible = false;
			gen_pg.ViewBackColor = System.Drawing.SystemColors.Window;
			gen_pg.ViewForeColor = System.Drawing.SystemColors.WindowText;
			//
			// tb_ver
			//
			tb_ver.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_ver.Location = new System.Drawing.Point(16, 40);
			tb_ver.Name = "tb_ver";
			tb_ver.Size = new System.Drawing.Size(88, 21);
			tb_ver.TabIndex = 24;
			tb_ver.Text = "0x00000000";
			tb_ver.TextChanged += new EventHandler(GNSettingsChange);
			//
			// label28
			//
			label28.AutoSize = true;
			label28.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label28.Location = new System.Drawing.Point(8, 24);
			label28.Name = "label28";
			label28.Size = new System.Drawing.Size(52, 17);
			label28.TabIndex = 23;
			label28.Text = "Version:";
			//
			// GenericRcol
			//
			groupBox10.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion

		private void GNSettingsChange(object sender, EventArgs e)
		{
			if (Tag == null)
			{
				return;
			}

			try
			{
				AbstractRcolBlock arb = (AbstractRcolBlock)Tag;

				arb.Version = Convert.ToUInt32(tb_ver.Text, 16);
				arb.Changed = true;
			}
			catch (Exception)
			{
				//Helper.ExceptionMessage("", ex);
			}
		}
	}
}
