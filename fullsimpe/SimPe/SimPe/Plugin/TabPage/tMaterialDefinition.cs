// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
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
			label5 = new Label();
			label4 = new Label();
			tbtype = new TextBox();
			tbdsc = new TextBox();
			groupBox10 = new GroupBox();
			tb_ver = new TextBox();
			label28 = new Label();
			groupBox10.SuspendLayout();
			SuspendLayout();
			//
			// label5
			//
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label5.Location = new System.Drawing.Point(48, 88);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(37, 17);
			label5.TabIndex = 16;
			label5.Text = "Type:";
			//
			// label4
			//
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label4.Location = new System.Drawing.Point(12, 56);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(73, 17);
			label4.TabIndex = 15;
			label4.Text = "Description:";
			//
			// tbtype
			//
			tbtype.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Left
						 | AnchorStyles.Right


			;
			tbtype.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbtype.Location = new System.Drawing.Point(88, 88);
			tbtype.Name = "tbtype";
			tbtype.Size = new System.Drawing.Size(624, 21);
			tbtype.TabIndex = 14;
			tbtype.Text = "";
			tbtype.TextChanged += new EventHandler(FileNameChanged);
			//
			// tbdsc
			//
			tbdsc.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Left
						 | AnchorStyles.Right


			;
			tbdsc.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbdsc.Location = new System.Drawing.Point(88, 56);
			tbdsc.Name = "tbdsc";
			tbdsc.Size = new System.Drawing.Size(624, 21);
			tbdsc.TabIndex = 13;
			tbdsc.Text = "";
			tbdsc.TextChanged += new EventHandler(FileNameChanged);
			//
			// tabPage3
			//
			BackColor = System.Drawing.Color.White;
			Controls.Add(groupBox10);
			Location = new System.Drawing.Point(4, 22);
			Name = "tabPage3";
			Size = new System.Drawing.Size(744, 238);
			TabIndex = 2;
			Text = "cMeterialDefinition";
			//
			// groupBox10
			//
			groupBox10.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Left
						 | AnchorStyles.Right


			;
			groupBox10.Controls.Add(tb_ver);
			groupBox10.Controls.Add(label28);
			groupBox10.Controls.Add(label4);
			groupBox10.Controls.Add(tbtype);
			groupBox10.Controls.Add(tbdsc);
			groupBox10.Controls.Add(label5);
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
			groupBox10.Size = new System.Drawing.Size(720, 128);
			groupBox10.TabIndex = 17;
			groupBox10.TabStop = false;
			groupBox10.Text = "Settings";
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
			tb_ver.Location = new System.Drawing.Point(88, 24);
			tb_ver.Name = "tb_ver";
			tb_ver.Size = new System.Drawing.Size(88, 21);
			tb_ver.TabIndex = 24;
			tb_ver.Text = "0x00000000";
			tb_ver.TextChanged += new EventHandler(FileNameChanged);
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
			label28.Location = new System.Drawing.Point(33, 24);
			label28.Name = "label28";
			label28.Size = new System.Drawing.Size(52, 17);
			label28.TabIndex = 23;
			label28.Text = "Version:";
			//
			// MatdForm
			//

			groupBox10.ResumeLayout(false);
			ResumeLayout(false);
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
			if (Tag == null)
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
					Tag;

				md.Version = Convert.ToUInt32(tb_ver.Text, 16);
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
			if (Tag == null)
			{
				return;
			}

			Plugin.MaterialDefinition md = (Plugin.MaterialDefinition)
				Tag;
			md.Sort();
			md.Refresh();
		}
	}
}
