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
	/// Summary description for MatdForm.
	/// </summary>
	public class MaterialDefinition : System.Windows.Forms.TabPage
	//System.Windows.Forms.UserControl
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MaterialDefinition()
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
			this.label5 = new Label();
			this.label4 = new Label();
			this.tbtype = new TextBox();
			this.tbdsc = new TextBox();
			this.groupBox10 = new GroupBox();
			this.tb_ver = new TextBox();
			this.label28 = new Label();
			this.groupBox10.SuspendLayout();
			this.SuspendLayout();
			//
			// label5
			//
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.label5.Location = new System.Drawing.Point(48, 88);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(37, 17);
			this.label5.TabIndex = 16;
			this.label5.Text = "Type:";
			//
			// label4
			//
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.label4.Location = new System.Drawing.Point(12, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(73, 17);
			this.label4.TabIndex = 15;
			this.label4.Text = "Description:";
			//
			// tbtype
			//
			this.tbtype.Anchor = (
				(AnchorStyles)(
					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)
				)
			);
			this.tbtype.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.tbtype.Location = new System.Drawing.Point(88, 88);
			this.tbtype.Name = "tbtype";
			this.tbtype.Size = new System.Drawing.Size(624, 21);
			this.tbtype.TabIndex = 14;
			this.tbtype.Text = "";
			this.tbtype.TextChanged += new EventHandler(this.FileNameChanged);
			//
			// tbdsc
			//
			this.tbdsc.Anchor = (
				(AnchorStyles)(
					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)
				)
			);
			this.tbdsc.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.tbdsc.Location = new System.Drawing.Point(88, 56);
			this.tbdsc.Name = "tbdsc";
			this.tbdsc.Size = new System.Drawing.Size(624, 21);
			this.tbdsc.TabIndex = 13;
			this.tbdsc.Text = "";
			this.tbdsc.TextChanged += new EventHandler(this.FileNameChanged);
			//
			// tabPage3
			//
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.groupBox10);
			this.Location = new System.Drawing.Point(4, 22);
			this.Name = "tabPage3";
			this.Size = new System.Drawing.Size(744, 238);
			this.TabIndex = 2;
			this.Text = "cMeterialDefinition";
			//
			// groupBox10
			//
			this.groupBox10.Anchor = (
				(AnchorStyles)(
					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)
				)
			);
			this.groupBox10.Controls.Add(this.tb_ver);
			this.groupBox10.Controls.Add(this.label28);
			this.groupBox10.Controls.Add(this.label4);
			this.groupBox10.Controls.Add(this.tbtype);
			this.groupBox10.Controls.Add(this.tbdsc);
			this.groupBox10.Controls.Add(this.label5);
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
			this.groupBox10.Size = new System.Drawing.Size(720, 128);
			this.groupBox10.TabIndex = 17;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "Settings";
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
			this.tb_ver.Location = new System.Drawing.Point(88, 24);
			this.tb_ver.Name = "tb_ver";
			this.tb_ver.Size = new System.Drawing.Size(88, 21);
			this.tb_ver.TabIndex = 24;
			this.tb_ver.Text = "0x00000000";
			this.tb_ver.TextChanged += new EventHandler(this.FileNameChanged);
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
			this.label28.Location = new System.Drawing.Point(33, 24);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(52, 17);
			this.label28.TabIndex = 23;
			this.label28.Text = "Version:";
			//
			// MatdForm
			//

			this.groupBox10.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion

		internal TextBox tbdsc;
		internal TextBox tbtype;
		private Label label4;
		private Label label5;
		private GroupBox groupBox10;
		internal TextBox tb_ver;
		private Label label28;

		private void FileNameChanged(object sender, EventArgs e)
		{
			if (this.Tag == null)
			{
				return;
			}

			if (tbdsc.Tag != null)
			{
				return;
			}

			try
			{
				tbdsc.Tag = true;
				Plugin.MaterialDefinition md = (Plugin.MaterialDefinition)
					this.Tag;

				md.Version = Convert.ToUInt32(this.tb_ver.Text, 16);
				md.FileDescription = tbdsc.Text;
				md.MatterialType = tbtype.Text;

				md.Changed = true;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("erropenfile"),
					ex
				);
			}
			finally
			{
				tbdsc.Tag = null;
			}
		}

		private void linkLabel1_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (this.Tag == null)
			{
				return;
			}

			Plugin.MaterialDefinition md = (Plugin.MaterialDefinition)
				this.Tag;
			md.Sort();
			md.Refresh();
		}
	}
}
