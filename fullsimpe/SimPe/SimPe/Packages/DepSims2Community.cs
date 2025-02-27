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
using System.Windows.Forms;

namespace SimPe.Packages
{
	/// <summary>
	/// Summary description for DepSims2Community.
	/// </summary>
	internal class DepSims2Community : Form
	{
		private ListBox lblist;
		private OpenFileDialog ofd;
		private Button btdelete;
		private Button button2;
		private Button btadd;
		private Panel panel1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DepSims2Community()
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
			btadd = new Button();
			lblist = new ListBox();
			ofd = new OpenFileDialog();
			btdelete = new Button();
			button2 = new Button();
			panel1 = new Panel();
			panel1.SuspendLayout();
			SuspendLayout();
			//
			// btadd
			//
			btadd.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)
				)
			);
			btadd.BackColor = System.Drawing.Color.Transparent;
			btadd.FlatStyle = FlatStyle.System;
			btadd.Location = new System.Drawing.Point(288, 189);
			btadd.Name = "btadd";
			btadd.Size = new System.Drawing.Size(75, 23);
			btadd.TabIndex = 4;
			btadd.Text = "Add...";
			btadd.UseVisualStyleBackColor = false;
			btadd.Click += new System.EventHandler(AddPackage);
			//
			// lblist
			//
			lblist.Anchor = (
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
			lblist.IntegralHeight = false;
			lblist.Location = new System.Drawing.Point(8, 8);
			lblist.Name = "lblist";
			lblist.Size = new System.Drawing.Size(448, 179);
			lblist.TabIndex = 3;
			lblist.SelectedIndexChanged += new System.EventHandler(Select);
			//
			// btdelete
			//
			btdelete.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)
				)
			);
			btdelete.BackColor = System.Drawing.Color.Transparent;
			btdelete.FlatStyle = FlatStyle.System;
			btdelete.Location = new System.Drawing.Point(198, 189);
			btdelete.Name = "btdelete";
			btdelete.Size = new System.Drawing.Size(75, 23);
			btdelete.TabIndex = 5;
			btdelete.Text = "Delete...";
			btdelete.UseVisualStyleBackColor = false;
			btdelete.Click += new System.EventHandler(DeletePackage);
			//
			// button2
			//
			button2.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)
				)
			);
			button2.BackColor = System.Drawing.Color.Transparent;
			button2.FlatStyle = FlatStyle.System;
			button2.Location = new System.Drawing.Point(384, 189);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(75, 23);
			button2.TabIndex = 6;
			button2.Text = "OK";
			button2.UseVisualStyleBackColor = false;
			button2.Click += new System.EventHandler(button2_Click);
			//
			// panel1
			//
			panel1.Anchor = (
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
			panel1.Controls.Add(btdelete);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(btadd);
			panel1.Controls.Add(lblist);
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(465, 219);
			panel1.TabIndex = 7;
			//
			// DepSims2Community
			//
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			ClientSize = new System.Drawing.Size(464, 218);
			Controls.Add(panel1);
			Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			FormBorderStyle =
				FormBorderStyle
				.SizableToolWindow;
			Name = "DepSims2Community";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Dependencies";
			panel1.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion
		bool ok;

		public void Execute(S2CPDescriptor s2cp, bool ronly)
		{
			lblist.Items.Clear();

			btdelete.Visible = !ronly;
			btadd.Visible = !ronly;

			foreach (S2CPDescriptorBase s2cpb in s2cp.Dependency)
			{
				lblist.Items.Add(s2cpb);
			}

			if (lblist.Items.Count > 0)
			{
				lblist.SelectedIndex = 0;
			}

			btdelete.Enabled = (lblist.SelectedIndex >= 0);

			ShowDialog();

			if (ok)
			{
				S2CPDescriptorBase[] s2cpbs = new S2CPDescriptorBase[
					lblist.Items.Count
				];
				for (int i = 0; i < s2cpbs.Length; i++)
				{
					s2cpbs[i] = (S2CPDescriptorBase)lblist.Items[i];
				}

				s2cp.Dependency = s2cpbs;
			}
		}

		private void AddPackage(object sender, System.EventArgs e)
		{
			ofd.Filter = "Sims 2 Package (*.package)|*.package|All Files (*.*)|*.*";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				GeneratableFile package = File.LoadFromFile(
					ofd.FileName
				);
				S2CPDescriptorBase s2cpb = new S2CPDescriptorBase(package);
				if (s2cpb.Guid == null)
				{
					MessageBox.Show(
						"This Package does not contain a valid GlobalGUID.\nYou can create one by including this File in a diffrent Sims2Community Package or by adding a 'Sims2Comunity Identifier' to the Package."
					);
				}
				else
				{
					lblist.Items.Add(s2cpb);
				}
			}
		}

		private void DeletePackage(object sender, System.EventArgs e)
		{
			if (lblist.SelectedIndex < 0)
			{
				return;
			}

			lblist.Items.RemoveAt(lblist.SelectedIndex);
		}

		private void Select(object sender, System.EventArgs e)
		{
			btdelete.Enabled = false;
			if (lblist.SelectedIndex < 0)
			{
				return;
			}

			btdelete.Enabled = true;
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			ok = true;
			Close();
		}
	}
}
