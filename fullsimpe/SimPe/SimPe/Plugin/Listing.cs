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
namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for Listing.
	/// </summary>
	public class Listing : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox lb;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.LinkLabel linkLabel1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Listing()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			//
			// TODO: F�gen Sie den Konstruktorcode nach dem Aufruf von InitializeComponent hinzu
			//
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
			lb = new System.Windows.Forms.ListBox();
			label1 = new System.Windows.Forms.Label();
			linkLabel1 = new System.Windows.Forms.LinkLabel();
			SuspendLayout();
			//
			// lb
			//
			lb.Anchor =

					(
						(
							(
								System.Windows.Forms.AnchorStyles.Top
								| System.Windows.Forms.AnchorStyles.Bottom
							) | System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)

			;
			lb.HorizontalScrollbar = true;
			lb.IntegralHeight = false;
			lb.Location = new System.Drawing.Point(8, 40);
			lb.Name = "lb";
			lb.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			lb.Size = new System.Drawing.Size(232, 200);
			lb.Sorted = true;
			lb.TabIndex = 0;
			//
			// label1
			//
			label1.Anchor =

					(
						(
							System.Windows.Forms.AnchorStyles.Top
							| System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)

			;
			label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			label1.Location = new System.Drawing.Point(8, 8);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(224, 32);
			label1.TabIndex = 1;
			label1.Text =
				"Select the SubSet you want to create a new Colour Option for.";
			//
			// linkLabel1
			//
			linkLabel1.Anchor =

					(
						System.Windows.Forms.AnchorStyles.Bottom
						| System.Windows.Forms.AnchorStyles.Right
					)

			;
			linkLabel1.AutoSize = true;
			linkLabel1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			linkLabel1.Location = new System.Drawing.Point(197, 240);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(43, 17);
			linkLabel1.TabIndex = 2;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "Select";
			linkLabel1.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(
					linkLabel1_LinkClicked
				);
			//
			// Listing
			//
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			ClientSize = new System.Drawing.Size(248, 270);
			Controls.Add(linkLabel1);
			Controls.Add(label1);
			Controls.Add(lb);
			Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			FormBorderStyle = System
				.Windows
				.Forms
				.FormBorderStyle
				.SizableToolWindow;
			Name = "Listing";
			ShowInTaskbar = false;
			Text = "Listing";
			ResumeLayout(false);
		}
		#endregion

		public WorkshopMMAT[] Execute(WorkshopMMAT[] list)
		{
			lb.Items.Clear();
			foreach (WorkshopMMAT s in list)
			{
				lb.Items.Add(s);
			}
			if (lb.Items.Count > 0)
			{
				lb.SelectedIndex = 0;
			}

			ShowDialog();

			WorkshopMMAT[] str;
			if (lb.SelectedItems.Count > 0)
			{
				str = new WorkshopMMAT[lb.SelectedItems.Count];
				for (int i = 0; i < lb.SelectedItems.Count; i++)
				{
					str[i] = (WorkshopMMAT)lb.SelectedItems[i];
				}
			}
			else
			{
				str = new WorkshopMMAT[0];
			}
			return str;
		}

		public string[] Execute(string[] list)
		{
			lb.Items.Clear();
			foreach (string s in list)
			{
				lb.Items.Add(s);
			}
			if (lb.Items.Count > 0)
			{
				lb.SelectedIndex = 0;
			}

			ShowDialog();

			string[] str;
			if (lb.SelectedItems.Count > 0)
			{
				str = new string[lb.SelectedItems.Count];
				for (int i = 0; i < lb.SelectedItems.Count; i++)
				{
					str[i] = (string)lb.SelectedItems[i];
				}
			}
			else
			{
				str = new string[0];
			}
			return str;
		}

		private void linkLabel1_LinkClicked(
			object sender,
			System.Windows.Forms.LinkLabelLinkClickedEventArgs e
		)
		{
			Close();
		}
	}
}
