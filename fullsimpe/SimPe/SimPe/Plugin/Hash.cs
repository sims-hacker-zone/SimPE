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
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(typeof(Hash));
			this.label1 = new Label();
			this.label4 = new Label();
			this.tbtext = new TextBox();
			this.tbhash = new TextBox();
			this.rb24 = new RadioButton();
			this.rb32 = new RadioButton();
			this.radioButton1 = new RadioButton();
			this.panel1 = new Panel();
			this.btcopy = new Button();
			this.cbTrim = new CheckBox();
			this.lbnamer = new Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			//
			// label1
			//
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label1.Location = new System.Drawing.Point(37, 19);
			this.label1.Name = "label1";
			this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label1.Size = new System.Drawing.Size(50, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "String:";
			//
			// label4
			//
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label4.Location = new System.Drawing.Point(4, 83);
			this.label4.Name = "label4";
			this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label4.Size = new System.Drawing.Size(83, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "Hash Value:";
			//
			// tbtext
			//
			this.tbtext.Anchor = (
				(AnchorStyles)(
					(
						(
							System.Windows.Forms.AnchorStyles.Top
							| System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.tbtext.Location = new System.Drawing.Point(92, 15);
			this.tbtext.Name = "tbtext";
			this.tbtext.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.tbtext.Size = new System.Drawing.Size(372, 21);
			this.tbtext.TabIndex = 4;
			this.tbtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbtext.TextChanged += new EventHandler(this.tbtext_TextChanged);
			//
			// tbhash
			//
			this.tbhash.Location = new System.Drawing.Point(92, 79);
			this.tbhash.Name = "tbhash";
			this.tbhash.ReadOnly = true;
			this.tbhash.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.tbhash.Size = new System.Drawing.Size(372, 21);
			this.tbhash.TabIndex = 7;
			this.tbhash.Text = "0xB00B0069";
			this.tbhash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			//
			// rb24
			//
			this.rb24.BackColor = System.Drawing.Color.Transparent;
			this.rb24.Checked = true;
			this.rb24.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rb24.Location = new System.Drawing.Point(240, 42);
			this.rb24.Name = "rb24";
			this.rb24.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.rb24.Size = new System.Drawing.Size(72, 24);
			this.rb24.TabIndex = 8;
			this.rb24.TabStop = true;
			this.rb24.Text = "CRC 24";
			this.rb24.UseVisualStyleBackColor = false;
			this.rb24.Click += new EventHandler(this.tbtext_TextChanged);
			this.rb24.CheckedChanged += new EventHandler(
				this.rb14_CheckedChanged
			);
			//
			// rb32
			//
			this.rb32.BackColor = System.Drawing.Color.Transparent;
			this.rb32.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rb32.Location = new System.Drawing.Point(320, 42);
			this.rb32.Name = "rb32";
			this.rb32.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.rb32.Size = new System.Drawing.Size(72, 24);
			this.rb32.TabIndex = 9;
			this.rb32.Text = "CRC 32";
			this.rb32.UseVisualStyleBackColor = false;
			this.rb32.Click += new EventHandler(this.tbtext_TextChanged);
			this.rb32.CheckedChanged += new EventHandler(
				this.rb32_CheckedChanged
			);
			//
			// radioButton1
			//
			this.radioButton1.BackColor = System.Drawing.Color.Transparent;
			this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radioButton1.Location = new System.Drawing.Point(400, 42);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.radioButton1.Size = new System.Drawing.Size(56, 24);
			this.radioButton1.TabIndex = 10;
			this.radioButton1.Text = "GUID";
			this.radioButton1.UseVisualStyleBackColor = false;
			this.radioButton1.CheckedChanged += new EventHandler(
				this.guid_CheckedChanged
			);
			//
			// panel1
			//
			this.panel1.BackColor = System.Drawing.Color.Transparent;
			this.panel1.Controls.Add(this.lbnamer);
			this.panel1.Controls.Add(this.cbTrim);
			this.panel1.Controls.Add(this.btcopy);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.radioButton1);
			this.panel1.Controls.Add(this.rb32);
			this.panel1.Controls.Add(this.rb24);
			this.panel1.Controls.Add(this.tbhash);
			this.panel1.Controls.Add(this.tbtext);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.panel1.Size = new System.Drawing.Size(496, 146);
			this.panel1.TabIndex = 11;
			//
			// btcopy
			//
			this.btcopy.Location = new System.Drawing.Point(389, 109);
			this.btcopy.Name = "btcopy";
			this.btcopy.Size = new System.Drawing.Size(75, 23);
			this.btcopy.TabIndex = 11;
			this.btcopy.Text = "Copy";
			this.btcopy.UseVisualStyleBackColor = true;
			this.btcopy.Click += new EventHandler(this.btcopy_Click);
			//
			// cbTrim
			//
			this.cbTrim.AutoSize = true;
			this.cbTrim.Checked = true;
			this.cbTrim.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbTrim.Location = new System.Drawing.Point(40, 46);
			this.cbTrim.Name = "cbTrim";
			this.cbTrim.Size = new System.Drawing.Size(148, 17);
			this.cbTrim.TabIndex = 12;
			this.cbTrim.Text = "Use Lower Case Only";
			this.cbTrim.UseVisualStyleBackColor = true;
			this.cbTrim.CheckedChanged += new EventHandler(
				this.cbTrim_CheckedChanged
			);
			//
			// lbnamer
			//
			this.lbnamer.AutoSize = true;
			this.lbnamer.Location = new System.Drawing.Point(4, 114);
			this.lbnamer.Name = "lbnamer";
			this.lbnamer.Size = new System.Drawing.Size(59, 13);
			this.lbnamer.TabIndex = 13;
			this.lbnamer.Text = "Available";
			this.lbnamer.Visible = false;
			//
			// Hash
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(494, 144);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Hash";
			this.Text = "Hash Generator";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
		}
		#endregion

		public void Execute(Interfaces.Files.IPackageFile package)
		{
			if (package != null)
			{
				if (package.FileName != null)
				{
					this.tbtext.Text = System
						.IO.Path.GetFileNameWithoutExtension(package.FileName)
						.ToLower();
				}

				this.tbtext.Text = "Generate Hashes";
			}
			else
			{
				this.tbtext.Text = "Generate Hashes";
			}

			this.Show();
		}

		private void tbtext_TextChanged(object sender, EventArgs e)
		{
			try
			{
				ulong hash = 0;
				if (cbTrim.Checked)
				{
					if (rb24.Checked)
					{
						hash = Hashes.ToLong(
							Hashes.Crc24.ComputeHash(
								Helper.ToBytes(tbtext.Text.ToLower())
							)
						);
					}
					else
					{
						hash = Hashes.ToLong(
							Hashes.Crc32.ComputeHash(
								Helper.ToBytes(tbtext.Text.ToLower())
							)
						);
					}
				}
				else
				{
					if (rb24.Checked)
					{
						hash = Hashes.ToLong(
							Hashes.Crc24.ComputeHash(Helper.ToBytes(tbtext.Text))
						);
					}
					else
					{
						hash = Hashes.ToLong(
							Hashes.Crc32.ComputeHash(Helper.ToBytes(tbtext.Text))
						);
					}
				}
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
			tbhash.Text = System.Guid.NewGuid().ToString();
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
				if (objName != null && objName.Length > 0)
				{
					lbnamer.Text = objName;
				}
				else
				{
					lbnamer.Text = "Available";
				}
			}
			else
			{
				lbnamer.Visible = false;
			}
		}
	}
}
