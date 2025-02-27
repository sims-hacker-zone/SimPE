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

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for Hash.
	/// </summary>
	public class Hash : Form
	{
		private Label label1;
		private Label label4;
		private TextBox tbtext;
		private TextBox tbhash;
		private RadioButton rb24;
		private RadioButton rb32;
		private RadioButton radioButton1;
		private Panel panel1;
		private Button btcopy;
		private CheckBox cbTrim;
		private Label lbnamer;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Hash()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
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
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(typeof(Hash));
			label1 = new Label();
			label4 = new Label();
			tbtext = new TextBox();
			tbhash = new TextBox();
			rb24 = new RadioButton();
			rb32 = new RadioButton();
			radioButton1 = new RadioButton();
			panel1 = new Panel();
			btcopy = new Button();
			cbTrim = new CheckBox();
			lbnamer = new Label();
			panel1.SuspendLayout();
			SuspendLayout();
			//
			// label1
			//
			label1.AutoSize = true;
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label1.Location = new System.Drawing.Point(37, 19);
			label1.Name = "label1";
			label1.RightToLeft = RightToLeft.No;
			label1.Size = new System.Drawing.Size(50, 13);
			label1.TabIndex = 0;
			label1.Text = "String:";
			//
			// label4
			//
			label4.AutoSize = true;
			label4.BackColor = System.Drawing.Color.Transparent;
			label4.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label4.Location = new System.Drawing.Point(4, 83);
			label4.Name = "label4";
			label4.RightToLeft = RightToLeft.No;
			label4.Size = new System.Drawing.Size(83, 13);
			label4.TabIndex = 3;
			label4.Text = "Hash Value:";
			//
			// tbtext
			//
			tbtext.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Left
						 | AnchorStyles.Right


			;
			tbtext.Location = new System.Drawing.Point(92, 15);
			tbtext.Name = "tbtext";
			tbtext.RightToLeft = RightToLeft.No;
			tbtext.Size = new System.Drawing.Size(372, 21);
			tbtext.TabIndex = 4;
			tbtext.TextAlign = HorizontalAlignment.Right;
			tbtext.TextChanged += new EventHandler(tbtext_TextChanged);
			//
			// tbhash
			//
			tbhash.Location = new System.Drawing.Point(92, 79);
			tbhash.Name = "tbhash";
			tbhash.ReadOnly = true;
			tbhash.RightToLeft = RightToLeft.No;
			tbhash.Size = new System.Drawing.Size(372, 21);
			tbhash.TabIndex = 7;
			tbhash.Text = "0xB00B0069";
			tbhash.TextAlign = HorizontalAlignment.Right;
			//
			// rb24
			//
			rb24.BackColor = System.Drawing.Color.Transparent;
			rb24.Checked = true;
			rb24.FlatStyle = FlatStyle.System;
			rb24.Location = new System.Drawing.Point(240, 42);
			rb24.Name = "rb24";
			rb24.RightToLeft = RightToLeft.No;
			rb24.Size = new System.Drawing.Size(72, 24);
			rb24.TabIndex = 8;
			rb24.TabStop = true;
			rb24.Text = "CRC 24";
			rb24.UseVisualStyleBackColor = false;
			rb24.Click += new EventHandler(tbtext_TextChanged);
			rb24.CheckedChanged += new EventHandler(
				rb14_CheckedChanged
			);
			//
			// rb32
			//
			rb32.BackColor = System.Drawing.Color.Transparent;
			rb32.FlatStyle = FlatStyle.System;
			rb32.Location = new System.Drawing.Point(320, 42);
			rb32.Name = "rb32";
			rb32.RightToLeft = RightToLeft.No;
			rb32.Size = new System.Drawing.Size(72, 24);
			rb32.TabIndex = 9;
			rb32.Text = "CRC 32";
			rb32.UseVisualStyleBackColor = false;
			rb32.Click += new EventHandler(tbtext_TextChanged);
			rb32.CheckedChanged += new EventHandler(
				rb32_CheckedChanged
			);
			//
			// radioButton1
			//
			radioButton1.BackColor = System.Drawing.Color.Transparent;
			radioButton1.FlatStyle = FlatStyle.System;
			radioButton1.Location = new System.Drawing.Point(400, 42);
			radioButton1.Name = "radioButton1";
			radioButton1.RightToLeft = RightToLeft.No;
			radioButton1.Size = new System.Drawing.Size(56, 24);
			radioButton1.TabIndex = 10;
			radioButton1.Text = "GUID";
			radioButton1.UseVisualStyleBackColor = false;
			radioButton1.CheckedChanged += new EventHandler(
				guid_CheckedChanged
			);
			//
			// panel1
			//
			panel1.BackColor = System.Drawing.Color.Transparent;
			panel1.Controls.Add(lbnamer);
			panel1.Controls.Add(cbTrim);
			panel1.Controls.Add(btcopy);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(radioButton1);
			panel1.Controls.Add(rb32);
			panel1.Controls.Add(rb24);
			panel1.Controls.Add(tbhash);
			panel1.Controls.Add(tbtext);
			panel1.Controls.Add(label4);
			panel1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.RightToLeft = RightToLeft.No;
			panel1.Size = new System.Drawing.Size(496, 146);
			panel1.TabIndex = 11;
			//
			// btcopy
			//
			btcopy.Location = new System.Drawing.Point(389, 109);
			btcopy.Name = "btcopy";
			btcopy.Size = new System.Drawing.Size(75, 23);
			btcopy.TabIndex = 11;
			btcopy.Text = "Copy";
			btcopy.UseVisualStyleBackColor = true;
			btcopy.Click += new EventHandler(btcopy_Click);
			//
			// cbTrim
			//
			cbTrim.AutoSize = true;
			cbTrim.Checked = true;
			cbTrim.CheckState = CheckState.Checked;
			cbTrim.Location = new System.Drawing.Point(40, 46);
			cbTrim.Name = "cbTrim";
			cbTrim.Size = new System.Drawing.Size(148, 17);
			cbTrim.TabIndex = 12;
			cbTrim.Text = "Use Lower Case Only";
			cbTrim.UseVisualStyleBackColor = true;
			cbTrim.CheckedChanged += new EventHandler(
				cbTrim_CheckedChanged
			);
			//
			// lbnamer
			//
			lbnamer.AutoSize = true;
			lbnamer.Location = new System.Drawing.Point(4, 114);
			lbnamer.Name = "lbnamer";
			lbnamer.Size = new System.Drawing.Size(59, 13);
			lbnamer.TabIndex = 13;
			lbnamer.Text = "Available";
			lbnamer.Visible = false;
			//
			// Hash
			//
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			ClientSize = new System.Drawing.Size(494, 144);
			Controls.Add(panel1);
			Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Name = "Hash";
			Text = "Hash Generator";
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}
		#endregion

		public void Execute(Interfaces.Files.IPackageFile package)
		{
			if (package != null)
			{
				if (package.FileName != null)
				{
					tbtext.Text = System
						.IO.Path.GetFileNameWithoutExtension(package.FileName)
						.ToLower();
				}

				tbtext.Text = "Generate Hashes";
			}
			else
			{
				tbtext.Text = "Generate Hashes";
			}

			Show();
		}

		private void tbtext_TextChanged(object sender, EventArgs e)
		{
			try
			{
				ulong hash = cbTrim.Checked
					? rb24.Checked
						? Hashes.ToLong(
							Hashes.Crc24.ComputeHash(
								Helper.ToBytes(tbtext.Text.ToLower())
							)
						)
						: Hashes.ToLong(
							Hashes.Crc32.ComputeHash(
								Helper.ToBytes(tbtext.Text.ToLower())
							)
						)
					: rb24.Checked
						? Hashes.ToLong(
							Hashes.Crc24.ComputeHash(Helper.ToBytes(tbtext.Text))
						)
						: Hashes.ToLong(
							Hashes.Crc32.ComputeHash(Helper.ToBytes(tbtext.Text))
						);
				tbhash.Text = "0x" + Helper.HexString((uint)hash);
				setupinuse(hash);
			}
			catch (Exception) { }
		}

		private void rb32_CheckedChanged(object sender, EventArgs e)
		{
			tbtext.Enabled = cbTrim.Enabled = true;
		}

		private void guid_CheckedChanged(object sender, EventArgs e)
		{
			tbtext.Enabled = cbTrim.Enabled = false;
			lbnamer.Visible = false;
			tbhash.Text = Guid.NewGuid().ToString();
		}

		private void rb14_CheckedChanged(object sender, EventArgs e)
		{
			tbtext.Enabled = cbTrim.Enabled = true;
		}

		private void btcopy_Click(object sender, EventArgs e)
		{
			Clipboard.SetDataObject(tbhash.Text, true);
		}

		private void cbTrim_CheckedChanged(object sender, EventArgs e)
		{
			if (!radioButton1.Checked)
			{
				tbtext_TextChanged(sender, e);
			}
		}

		private void setupinuse(ulong vid)
		{
			if (rb32.Checked)
			{
				lbnamer.Visible = true;
				string objName = pjse.GUIDIndex.TheGUIDIndex[Convert.ToUInt32(vid)];
				lbnamer.Text = objName != null && objName.Length > 0 ? objName : "Available";
			}
			else
			{
				lbnamer.Visible = false;
			}
		}
	}
}
