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
	public class DirectionalLight : System.Windows.Forms.TabPage
	//System.Windows.Forms.UserControl
	{
		private GroupBox groupBox13;
		internal TextBox tb_l_ver;
		private Label label32;
		internal TextBox tb_l_name;
		private Label label34;
		private Label label38;
		internal TextBox tb_l_1;
		internal TextBox tb_l_6;
		internal Label label39;
		internal TextBox tb_l_2;
		private Label label40;
		internal TextBox tb_l_3;
		private Label label41;
		internal TextBox tb_l_4;
		private Label label42;
		internal TextBox tb_l_5;
		private Label label43;
		internal TextBox tb_l_7;
		internal Label label44;
		internal TextBox tb_l_8;
		internal Label label45;
		internal TextBox tb_l_9;
		internal Label label46;

		//private System.ComponentModel.IContainer components;

		public DirectionalLight()
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
			groupBox13 = new GroupBox();
			tb_l_9 = new TextBox();
			label46 = new Label();
			tb_l_8 = new TextBox();
			label45 = new Label();
			tb_l_7 = new TextBox();
			label44 = new Label();
			tb_l_5 = new TextBox();
			label43 = new Label();
			tb_l_4 = new TextBox();
			label42 = new Label();
			tb_l_3 = new TextBox();
			label41 = new Label();
			tb_l_2 = new TextBox();
			label40 = new Label();
			tb_l_6 = new TextBox();
			label39 = new Label();
			tb_l_1 = new TextBox();
			label38 = new Label();
			tb_l_name = new TextBox();
			label34 = new Label();
			tb_l_ver = new TextBox();
			label32 = new Label();
			groupBox13.SuspendLayout();
			SuspendLayout();
			//
			// tDirectionalLight
			//
			BackColor = System.Drawing.Color.White;
			Controls.Add(groupBox13);
			Location = new System.Drawing.Point(4, 22);
			Name = "tDirectionalLight";
			Size = new System.Drawing.Size(792, 262);
			TabIndex = 7;
			Text = "DirectionalLight";
			//
			// groupBox13
			//
			groupBox13.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			groupBox13.Controls.Add(tb_l_9);
			groupBox13.Controls.Add(label46);
			groupBox13.Controls.Add(tb_l_8);
			groupBox13.Controls.Add(label45);
			groupBox13.Controls.Add(tb_l_7);
			groupBox13.Controls.Add(label44);
			groupBox13.Controls.Add(tb_l_5);
			groupBox13.Controls.Add(label43);
			groupBox13.Controls.Add(tb_l_4);
			groupBox13.Controls.Add(label42);
			groupBox13.Controls.Add(tb_l_3);
			groupBox13.Controls.Add(label41);
			groupBox13.Controls.Add(tb_l_2);
			groupBox13.Controls.Add(label40);
			groupBox13.Controls.Add(tb_l_6);
			groupBox13.Controls.Add(label39);
			groupBox13.Controls.Add(tb_l_1);
			groupBox13.Controls.Add(label38);
			groupBox13.Controls.Add(tb_l_name);
			groupBox13.Controls.Add(label34);
			groupBox13.Controls.Add(tb_l_ver);
			groupBox13.Controls.Add(label32);
			groupBox13.FlatStyle = FlatStyle.System;
			groupBox13.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox13.Location = new System.Drawing.Point(8, 8);
			groupBox13.Name = "groupBox13";
			groupBox13.Size = new System.Drawing.Size(776, 208);
			groupBox13.TabIndex = 12;
			groupBox13.TabStop = false;
			groupBox13.Text = "Settings";
			//
			// tb_l_9
			//
			tb_l_9.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_l_9.Location = new System.Drawing.Point(168, 168);
			tb_l_9.Name = "tb_l_9";
			tb_l_9.Size = new System.Drawing.Size(66, 21);
			tb_l_9.TabIndex = 44;
			tb_l_9.Text = "0";
			tb_l_9.TextChanged += new EventHandler(LSettingsChanged);
			//
			// label46
			//
			label46.AutoSize = true;
			label46.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label46.Location = new System.Drawing.Point(128, 176);
			label46.Name = "label46";
			label46.Size = new System.Drawing.Size(34, 17);
			label46.TabIndex = 43;
			label46.Text = "Val9:";
			//
			// tb_l_8
			//
			tb_l_8.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_l_8.Location = new System.Drawing.Point(48, 168);
			tb_l_8.Name = "tb_l_8";
			tb_l_8.Size = new System.Drawing.Size(66, 21);
			tb_l_8.TabIndex = 42;
			tb_l_8.Text = "0";
			tb_l_8.TextChanged += new EventHandler(LSettingsChanged);
			//
			// label45
			//
			label45.AutoSize = true;
			label45.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label45.Location = new System.Drawing.Point(8, 176);
			label45.Name = "label45";
			label45.Size = new System.Drawing.Size(34, 17);
			label45.TabIndex = 41;
			label45.Text = "Val8:";
			//
			// tb_l_7
			//
			tb_l_7.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_l_7.Location = new System.Drawing.Point(168, 144);
			tb_l_7.Name = "tb_l_7";
			tb_l_7.Size = new System.Drawing.Size(66, 21);
			tb_l_7.TabIndex = 40;
			tb_l_7.Text = "0";
			tb_l_7.TextChanged += new EventHandler(LSettingsChanged);
			//
			// label44
			//
			label44.AutoSize = true;
			label44.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label44.Location = new System.Drawing.Point(128, 152);
			label44.Name = "label44";
			label44.Size = new System.Drawing.Size(34, 17);
			label44.TabIndex = 39;
			label44.Text = "Val7:";
			//
			// tb_l_5
			//
			tb_l_5.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_l_5.Location = new System.Drawing.Point(312, 168);
			tb_l_5.Name = "tb_l_5";
			tb_l_5.Size = new System.Drawing.Size(66, 21);
			tb_l_5.TabIndex = 38;
			tb_l_5.Text = "0";
			tb_l_5.TextChanged += new EventHandler(LSettingsChanged);
			//
			// label43
			//
			label43.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label43.Location = new System.Drawing.Point(256, 176);
			label43.Name = "label43";
			label43.Size = new System.Drawing.Size(48, 17);
			label43.TabIndex = 37;
			label43.Text = "Blue:";
			label43.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// tb_l_4
			//
			tb_l_4.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_l_4.Location = new System.Drawing.Point(312, 144);
			tb_l_4.Name = "tb_l_4";
			tb_l_4.Size = new System.Drawing.Size(66, 21);
			tb_l_4.TabIndex = 36;
			tb_l_4.Text = "0";
			tb_l_4.TextChanged += new EventHandler(LSettingsChanged);
			//
			// label42
			//
			label42.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label42.Location = new System.Drawing.Point(256, 152);
			label42.Name = "label42";
			label42.Size = new System.Drawing.Size(48, 17);
			label42.TabIndex = 35;
			label42.Text = "Green:";
			label42.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// tb_l_3
			//
			tb_l_3.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_l_3.Location = new System.Drawing.Point(312, 120);
			tb_l_3.Name = "tb_l_3";
			tb_l_3.Size = new System.Drawing.Size(66, 21);
			tb_l_3.TabIndex = 34;
			tb_l_3.Text = "0";
			tb_l_3.TextChanged += new EventHandler(LSettingsChanged);
			//
			// label41
			//
			label41.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label41.Location = new System.Drawing.Point(256, 128);
			label41.Name = "label41";
			label41.Size = new System.Drawing.Size(48, 17);
			label41.TabIndex = 33;
			label41.Text = "Red:";
			label41.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// tb_l_2
			//
			tb_l_2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_l_2.Location = new System.Drawing.Point(168, 120);
			tb_l_2.Name = "tb_l_2";
			tb_l_2.Size = new System.Drawing.Size(66, 21);
			tb_l_2.TabIndex = 32;
			tb_l_2.Text = "0";
			tb_l_2.TextChanged += new EventHandler(LSettingsChanged);
			//
			// label40
			//
			label40.AutoSize = true;
			label40.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label40.Location = new System.Drawing.Point(128, 128);
			label40.Name = "label40";
			label40.Size = new System.Drawing.Size(34, 17);
			label40.TabIndex = 31;
			label40.Text = "Val2:";
			//
			// tb_l_6
			//
			tb_l_6.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_l_6.Location = new System.Drawing.Point(48, 144);
			tb_l_6.Name = "tb_l_6";
			tb_l_6.Size = new System.Drawing.Size(66, 21);
			tb_l_6.TabIndex = 30;
			tb_l_6.Text = "0";
			tb_l_6.TextChanged += new EventHandler(LSettingsChanged);
			//
			// label39
			//
			label39.AutoSize = true;
			label39.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label39.Location = new System.Drawing.Point(8, 152);
			label39.Name = "label39";
			label39.Size = new System.Drawing.Size(34, 17);
			label39.TabIndex = 29;
			label39.Text = "Val6:";
			//
			// tb_l_1
			//
			tb_l_1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_l_1.Location = new System.Drawing.Point(48, 120);
			tb_l_1.Name = "tb_l_1";
			tb_l_1.Size = new System.Drawing.Size(66, 21);
			tb_l_1.TabIndex = 28;
			tb_l_1.Text = "0";
			tb_l_1.TextChanged += new EventHandler(LSettingsChanged);
			//
			// label38
			//
			label38.AutoSize = true;
			label38.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label38.Location = new System.Drawing.Point(8, 128);
			label38.Name = "label38";
			label38.Size = new System.Drawing.Size(34, 17);
			label38.TabIndex = 27;
			label38.Text = "Val1:";
			//
			// tb_l_name
			//
			tb_l_name.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			tb_l_name.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_l_name.Location = new System.Drawing.Point(16, 88);
			tb_l_name.Name = "tb_l_name";
			tb_l_name.Size = new System.Drawing.Size(752, 21);
			tb_l_name.TabIndex = 26;
			tb_l_name.Text = "";
			tb_l_name.TextChanged += new EventHandler(
				LSettingsChanged
			);
			//
			// label34
			//
			label34.AutoSize = true;
			label34.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label34.Location = new System.Drawing.Point(8, 72);
			label34.Name = "label34";
			label34.Size = new System.Drawing.Size(42, 17);
			label34.TabIndex = 25;
			label34.Text = "Name:";
			//
			// tb_l_ver
			//
			tb_l_ver.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_l_ver.Location = new System.Drawing.Point(16, 40);
			tb_l_ver.Name = "tb_l_ver";
			tb_l_ver.Size = new System.Drawing.Size(88, 21);
			tb_l_ver.TabIndex = 24;
			tb_l_ver.Text = "0x00000000";
			tb_l_ver.TextChanged += new EventHandler(LSettingsChanged);
			//
			// label32
			//
			label32.AutoSize = true;
			label32.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label32.Location = new System.Drawing.Point(8, 24);
			label32.Name = "label32";
			label32.Size = new System.Drawing.Size(52, 17);
			label32.TabIndex = 23;
			label32.Text = "Version:";
			//
			// fShapeRefNode
			//
			groupBox13.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion





		private void LSettingsChanged(object sender, EventArgs e)
		{
			if (Tag == null)
			{
				return;
			}

			try
			{
				Plugin.DirectionalLight dl = (Plugin.DirectionalLight)Tag;

				dl.Version = Convert.ToUInt32(tb_l_ver.Text, 16);
				dl.Name = tb_l_name.Text;
				dl.Val1 = Convert.ToSingle(tb_l_1.Text);
				dl.Val2 = Convert.ToSingle(tb_l_2.Text);
				dl.Red = Convert.ToSingle(tb_l_3.Text);
				dl.Green = Convert.ToSingle(tb_l_4.Text);
				dl.Blue = Convert.ToSingle(tb_l_5.Text);

				if (Tag.GetType() == typeof(PointLight))
				{
					PointLight pl = (PointLight)Tag;

					pl.Val6 = Convert.ToSingle(tb_l_6.Text);
					pl.Val7 = Convert.ToSingle(tb_l_7.Text);
				}

				if (Tag.GetType() == typeof(SpotLight))
				{
					SpotLight sl = (SpotLight)Tag;

					sl.Val6 = Convert.ToSingle(tb_l_6.Text);
					sl.Val7 = Convert.ToSingle(tb_l_7.Text);
					sl.Val8 = Convert.ToSingle(tb_l_8.Text);
					sl.Val9 = Convert.ToSingle(tb_l_9.Text);
				}

				dl.Changed = true;
			}
			catch (Exception)
			{
				//Helper.ExceptionMessage("", ex);
			}
		}
	}
}
