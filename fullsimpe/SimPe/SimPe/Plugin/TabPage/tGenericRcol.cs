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
			this.groupBox10 = new GroupBox();
			this.gen_pg = new PropertyGrid();
			this.tb_ver = new TextBox();
			this.label28 = new Label();
			this.groupBox10.SuspendLayout();
			this.SuspendLayout();
			//
			// tGenericRcol
			//
			this.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.Controls.Add(this.groupBox10);
			this.Location = new System.Drawing.Point(4, 22);
			this.Name = "tGenericRcol";
			this.Size = new System.Drawing.Size(792, 262);
			this.TabIndex = 4;
			this.Text = "GenericRcol";
			//
			// groupBox10
			//
			this.groupBox10.Anchor = (
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
			this.groupBox10.Controls.Add(this.gen_pg);
			this.groupBox10.Controls.Add(this.tb_ver);
			this.groupBox10.Controls.Add(this.label28);
			this.groupBox10.FlatStyle = FlatStyle.System;
			this.groupBox10.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.groupBox10.Location = new System.Drawing.Point(8, 8);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(776, 250);
			this.groupBox10.TabIndex = 11;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "Settings";
			//
			// gen_pg
			//
			this.gen_pg.Anchor = (
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
			this.gen_pg.CommandsBackColor = System
				.Drawing
				.SystemColors
				.ControlLightLight;
			this.gen_pg.CommandsVisibleIfAvailable = true;
			this.gen_pg.HelpVisible = false;
			this.gen_pg.LargeButtons = false;
			this.gen_pg.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.gen_pg.Location = new System.Drawing.Point(112, 24);
			this.gen_pg.Name = "gen_pg";
			this.gen_pg.Size = new System.Drawing.Size(656, 218);
			this.gen_pg.TabIndex = 25;
			this.gen_pg.Text = "Generic Properties";
			this.gen_pg.ToolbarVisible = false;
			this.gen_pg.ViewBackColor = System.Drawing.SystemColors.Window;
			this.gen_pg.ViewForeColor = System.Drawing.SystemColors.WindowText;
			//
			// tb_ver
			//
			this.tb_ver.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.tb_ver.Location = new System.Drawing.Point(16, 40);
			this.tb_ver.Name = "tb_ver";
			this.tb_ver.Size = new System.Drawing.Size(88, 21);
			this.tb_ver.TabIndex = 24;
			this.tb_ver.Text = "0x00000000";
			this.tb_ver.TextChanged += new EventHandler(this.GNSettingsChange);
			//
			// label28
			//
			this.label28.AutoSize = true;
			this.label28.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.label28.Location = new System.Drawing.Point(8, 24);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(52, 17);
			this.label28.TabIndex = 23;
			this.label28.Text = "Version:";
			//
			// GenericRcol
			//
			this.groupBox10.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion

		private void GNSettingsChange(object sender, EventArgs e)
		{
			if (this.Tag == null)
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
