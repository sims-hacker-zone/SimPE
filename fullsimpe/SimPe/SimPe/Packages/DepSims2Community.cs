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
			this.btadd = new Button();
			this.lblist = new ListBox();
			this.ofd = new OpenFileDialog();
			this.btdelete = new Button();
			this.button2 = new Button();
			this.panel1 = new Panel();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			//
			// btadd
			//
			this.btadd.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)
				)
			);
			this.btadd.BackColor = System.Drawing.Color.Transparent;
			this.btadd.FlatStyle = FlatStyle.System;
			this.btadd.Location = new System.Drawing.Point(288, 189);
			this.btadd.Name = "btadd";
			this.btadd.Size = new System.Drawing.Size(75, 23);
			this.btadd.TabIndex = 4;
			this.btadd.Text = "Add...";
			this.btadd.UseVisualStyleBackColor = false;
			this.btadd.Click += new System.EventHandler(this.AddPackage);
			//
			// lblist
			//
			this.lblist.Anchor = (
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
			this.lblist.IntegralHeight = false;
			this.lblist.Location = new System.Drawing.Point(8, 8);
			this.lblist.Name = "lblist";
			this.lblist.Size = new System.Drawing.Size(448, 179);
			this.lblist.TabIndex = 3;
			this.lblist.SelectedIndexChanged += new System.EventHandler(this.Select);
			//
			// btdelete
			//
			this.btdelete.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)
				)
			);
			this.btdelete.BackColor = System.Drawing.Color.Transparent;
			this.btdelete.FlatStyle = FlatStyle.System;
			this.btdelete.Location = new System.Drawing.Point(198, 189);
			this.btdelete.Name = "btdelete";
			this.btdelete.Size = new System.Drawing.Size(75, 23);
			this.btdelete.TabIndex = 5;
			this.btdelete.Text = "Delete...";
			this.btdelete.UseVisualStyleBackColor = false;
			this.btdelete.Click += new System.EventHandler(this.DeletePackage);
			//
			// button2
			//
			this.button2.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)
				)
			);
			this.button2.BackColor = System.Drawing.Color.Transparent;
			this.button2.FlatStyle = FlatStyle.System;
			this.button2.Location = new System.Drawing.Point(384, 189);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 6;
			this.button2.Text = "OK";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			//
			// panel1
			//
			this.panel1.Anchor = (
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
			this.panel1.Controls.Add(this.btdelete);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.btadd);
			this.panel1.Controls.Add(this.lblist);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(465, 219);
			this.panel1.TabIndex = 7;
			//
			// DepSims2Community
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(464, 218);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.FormBorderStyle =
				FormBorderStyle
				.SizableToolWindow;
			this.Name = "DepSims2Community";
			this.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Dependencies";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion
		bool ok;

		public void Execute(S2CPDescriptor s2cp, bool ronly)
		{
			lblist.Items.Clear();

			this.btdelete.Visible = !ronly;
			this.btadd.Visible = !ronly;

			foreach (S2CPDescriptorBase s2cpb in s2cp.Dependency)
			{
				lblist.Items.Add(s2cpb);
			}

			if (lblist.Items.Count > 0)
			{
				lblist.SelectedIndex = 0;
			}

			btdelete.Enabled = (lblist.SelectedIndex >= 0);

			this.ShowDialog();

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
