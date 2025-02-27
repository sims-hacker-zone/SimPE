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

namespace SimPe
{
	/// <summary>
	/// Summary description for AddExtTool.
	/// </summary>
	public class AddExtTool : Form
	{
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Button button1;
		private TextBox tbname;
		private TextBox tbfile;
		private TextBox tbattr;
		private Button button2;
		private OpenFileDialog ofd;
		private TextBox tbtype;
		private ComboBox cbtypes;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AddExtTool()
		{
			InitializeComponent();

			foreach (Data.TypeAlias a in Helper.TGILoader.FileTypes)
			{
				if (a.Id == 0xffffffff)
				{
					Data.TypeAlias an = new Data.TypeAlias(
						false,
						"ALL",
						0xffffffff,
						"---  All Types ---",
						true,
						true
					);
					cbtypes.Items.Add(an);
				}
				else
				{
					cbtypes.Items.Add(a);
				}
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			button1 = new Button();
			tbname = new TextBox();
			tbfile = new TextBox();
			tbattr = new TextBox();
			button2 = new Button();
			ofd = new OpenFileDialog();
			tbtype = new TextBox();
			cbtypes = new ComboBox();
			SuspendLayout();
			//
			// label1
			//
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label1.Location = new System.Drawing.Point(61, 16);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(45, 17);
			label1.TabIndex = 0;
			label1.Text = "Name:";
			//
			// label2
			//
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label2.Location = new System.Drawing.Point(67, 40);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(39, 17);
			label2.TabIndex = 1;
			label2.Text = "Type:";
			//
			// label3
			//
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label3.Location = new System.Drawing.Point(38, 64);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(68, 17);
			label3.TabIndex = 2;
			label3.Text = "FileName:";
			//
			// label4
			//
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label4.Location = new System.Drawing.Point(24, 88);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(82, 17);
			label4.TabIndex = 3;
			label4.Text = "Parameters:";
			//
			// button1
			//
			button1.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)

			;
			button1.FlatStyle = FlatStyle.System;
			button1.Location = new System.Drawing.Point(472, 112);
			button1.Name = "button1";
			button1.TabIndex = 4;
			button1.Text = "OK";
			button1.Click += new EventHandler(button1_Click);
			//
			// tbname
			//
			tbname.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			tbname.Location = new System.Drawing.Point(112, 8);
			tbname.Name = "tbname";
			tbname.Size = new System.Drawing.Size(432, 21);
			tbname.TabIndex = 5;
			tbname.Text = "";
			//
			// tbfile
			//
			tbfile.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			tbfile.Location = new System.Drawing.Point(112, 56);
			tbfile.Name = "tbfile";
			tbfile.Size = new System.Drawing.Size(352, 21);
			tbfile.TabIndex = 6;
			tbfile.Text = "";
			//
			// tbattr
			//
			tbattr.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			tbattr.Location = new System.Drawing.Point(112, 80);
			tbattr.Name = "tbattr";
			tbattr.Size = new System.Drawing.Size(432, 21);
			tbattr.TabIndex = 7;
			tbattr.Text = "";
			//
			// button2
			//
			button2.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			button2.FlatStyle = FlatStyle.System;
			button2.Location = new System.Drawing.Point(472, 56);
			button2.Name = "button2";
			button2.TabIndex = 8;
			button2.Text = "Browse...";
			button2.Click += new EventHandler(button2_Click);
			//
			// ofd
			//
			ofd.Filter =
				"Application (*.exe;*.bat;*.com;*.cmd)|*.exe;*.bat;*.com;*.cmd|All Files (*.*)|*.*"
				+ "";
			//
			// tbtype
			//
			tbtype.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			tbtype.Location = new System.Drawing.Point(112, 32);
			tbtype.Name = "tbtype";
			tbtype.TabIndex = 17;
			tbtype.Text = "";
			tbtype.TextChanged += new EventHandler(
				SelectTypeByNameClick
			);
			//
			// cbtypes
			//
			cbtypes.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			cbtypes.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbtypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			cbtypes.ItemHeight = 13;
			cbtypes.Location = new System.Drawing.Point(216, 32);
			cbtypes.Name = "cbtypes";
			cbtypes.Size = new System.Drawing.Size(248, 21);
			cbtypes.TabIndex = 18;
			cbtypes.SelectedIndexChanged += new EventHandler(
				TypeSelectClick
			);
			//
			// AddExtTool
			//
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			ClientSize = new System.Drawing.Size(554, 142);
			Controls.Add(tbtype);
			Controls.Add(cbtypes);
			Controls.Add(button2);
			Controls.Add(tbattr);
			Controls.Add(tbfile);
			Controls.Add(tbname);
			Controls.Add(button1);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Name = "AddExtTool";
			ShowInTaskbar = false;
			Text = "Add External Tool";
			ResumeLayout(false);
		}
		#endregion

		ToolLoaderItemExt tli;

		public ToolLoaderItemExt Execute()
		{
			tli = null;

			tbname.Text = Localization.Manager.GetString("Unknown");
			tbtype.Text = "0xffffffff";
			tbattr.Text = "{tempfile}";
			tbfile.Text = "";

			ShowDialog();
			return tli;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			ofd.FileName = tbfile.Text;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				tbfile.Text = ofd.FileName;
			}
		}

		private void TypeSelectClick(object sender, EventArgs e)
		{
			if (cbtypes.Tag != null)
			{
				return;
			}

			tbtype.Text =
				"0x"
				+ Helper.HexString(
					((Data.TypeAlias)cbtypes.Items[cbtypes.SelectedIndex]).Id
				);
		}

		private void SelectTypeByNameClick(object sender, EventArgs e)
		{
			cbtypes.Tag = true;
			Data.TypeAlias a = Data.MetaData.FindTypeAlias(
				Helper.HexStringToUInt(tbtype.Text)
			);

			int ct = 0;
			foreach (Data.TypeAlias i in cbtypes.Items)
			{
				if (i == a)
				{
					cbtypes.SelectedIndex = ct;
					cbtypes.Tag = null;
					return;
				}
				ct++;
			}

			cbtypes.SelectedIndex = -1;
			cbtypes.Tag = null;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			tli = new ToolLoaderItemExt(tbname.Text)
			{
				Attributes = tbattr.Text,
				FileName = tbfile.Text
			};
			try
			{
				tli.Type = Convert.ToUInt32(tbtype.Text);
			}
			catch (Exception)
			{
				tli.Type = 0xffffffff;
			}

			Close();
		}
	}
}
