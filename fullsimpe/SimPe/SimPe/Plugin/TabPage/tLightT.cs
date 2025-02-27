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
	public class LightT : System.Windows.Forms.TabPage
	//System.Windows.Forms.UserControl
	{
		private GroupBox groupBox14;
		private Label label47;
		internal TextBox tb_lt_ver;
		private Label label48;
		internal TextBox tb_lt_name;

		//private System.ComponentModel.IContainer components;

		public LightT()
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
			groupBox14 = new GroupBox();
			tb_lt_name = new TextBox();
			label48 = new Label();
			tb_lt_ver = new TextBox();
			label47 = new Label();
			groupBox14.SuspendLayout();
			SuspendLayout();
			//
			// tLightT
			//
			BackColor = System.Drawing.Color.White;
			Controls.Add(groupBox14);
			Location = new System.Drawing.Point(4, 22);
			Name = "tLightT";
			Size = new System.Drawing.Size(792, 262);
			TabIndex = 8;
			Text = "LightT";
			//
			// groupBox14
			//
			groupBox14.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			groupBox14.Controls.Add(tb_lt_name);
			groupBox14.Controls.Add(label48);
			groupBox14.Controls.Add(tb_lt_ver);
			groupBox14.Controls.Add(label47);
			groupBox14.FlatStyle = FlatStyle.System;
			groupBox14.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox14.Location = new System.Drawing.Point(8, 8);
			groupBox14.Name = "groupBox14";
			groupBox14.Size = new System.Drawing.Size(776, 128);
			groupBox14.TabIndex = 12;
			groupBox14.TabStop = false;
			groupBox14.Text = "Settings";
			//
			// tb_lt_name
			//
			tb_lt_name.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			tb_lt_name.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_lt_name.Location = new System.Drawing.Point(16, 88);
			tb_lt_name.Name = "tb_lt_name";
			tb_lt_name.Size = new System.Drawing.Size(752, 21);
			tb_lt_name.TabIndex = 26;
			tb_lt_name.Text = "";
			tb_lt_name.TextChanged += new EventHandler(
				LTSettingsChanged
			);
			//
			// label48
			//
			label48.AutoSize = true;
			label48.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label48.Location = new System.Drawing.Point(8, 72);
			label48.Name = "label48";
			label48.Size = new System.Drawing.Size(42, 17);
			label48.TabIndex = 25;
			label48.Text = "Name:";
			//
			// tb_lt_ver
			//
			tb_lt_ver.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_lt_ver.Location = new System.Drawing.Point(16, 40);
			tb_lt_ver.Name = "tb_lt_ver";
			tb_lt_ver.Size = new System.Drawing.Size(88, 21);
			tb_lt_ver.TabIndex = 24;
			tb_lt_ver.Text = "0x00000000";
			tb_lt_ver.TextChanged += new EventHandler(
				LTSettingsChanged
			);
			//
			// label47
			//
			label47.AutoSize = true;
			label47.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label47.Location = new System.Drawing.Point(8, 24);
			label47.Name = "label47";
			label47.Size = new System.Drawing.Size(52, 17);
			label47.TabIndex = 23;
			label47.Text = "Version:";
			//
			// fShapeRefNode
			//
			groupBox14.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion


		private void LTSettingsChanged(object sender, EventArgs e)
		{
			if (Tag == null)
			{
				return;
			}

			try
			{
				Plugin.LightT lt = (Plugin.LightT)Tag;

				lt.Version = Convert.ToUInt32(tb_lt_ver.Text, 16);
				lt.NameResource.FileName = tb_lt_name.Text;

				lt.Changed = true;
			}
			catch (Exception)
			{
				//Helper.ExceptionMessage("", ex);
			}
		}
	}
}
