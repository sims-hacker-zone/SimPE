/***************************************************************************
 *   Copyright (C) 2005 by Peter L Jones                                   *
 *   pljones@users.sf.net                                                  *
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
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Wrapper;

namespace SimPe.PackedFiles.UserInterface
{
	/// <summary>
	/// Summary description for BconForm.
	/// </summary>
	public class ClstForm : System.Windows.Forms.Form, IPackedFileUI
	{
		#region Form elements
		private System.Windows.Forms.Label lbformat;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ListBox lbclst;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Panel clstPanel;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public ClstForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			if (Helper.WindowsRegistry.UseBigIcons)
				this.lbclst.Font = new System.Drawing.Font("Verdana", 11F);
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

		#region CompressedFileList
		private CompressedFileList wrapper;
		#endregion

		#region IPackedFileUI Member
		/// <summary>
		/// Returns the Panel that will be displayed within SimPe
		/// </summary>
		public System.Windows.Forms.Control GUIHandle
		{
			get
			{
				return clstPanel;
			}
		}

		/// <summary>
		/// Is called by SimPe (through the Wrapper) when the Panel is going to be displayed, so
		/// you should updatet the Data displayed by the Panel with the Attributes stored in the
		/// passed Wrapper.
		/// </summary>
		/// <remarks>attr.Tag is used to let TextChanged event handlers know the change is being
		/// made internally rather than by the users.</remarks>
		/// <param name="wrp">The Attributes of this Wrapper have to be displayed</param>
		public void UpdateGUI(IFileWrapper wrp)
		{
			wrapper = (CompressedFileList)wrp;

			lbformat.Text = wrapper.IndexType.ToString();

			lbclst.Items.Clear();
			foreach (ClstItem i in wrapper.Items)
				if (i != null)
					lbclst.Items.Add(i);
				else
					lbclst.Items.Add("Error");
		}
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(typeof(ClstForm));
			this.clstPanel = new System.Windows.Forms.Panel();
			this.lbformat = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.lbclst = new System.Windows.Forms.ListBox();
			this.panel4 = new System.Windows.Forms.Panel();
			this.clstPanel.SuspendLayout();
			this.SuspendLayout();
			//
			// clstPanel
			//
			this.clstPanel.BackColor = System.Drawing.Color.Transparent;
			this.clstPanel.Controls.Add(this.lbformat);
			this.clstPanel.Controls.Add(this.label9);
			this.clstPanel.Controls.Add(this.lbclst);
			this.clstPanel.Controls.Add(this.panel4);
			resources.ApplyResources(this.clstPanel, "clstPanel");
			this.clstPanel.Name = "clstPanel";
			//
			// lbformat
			//
			resources.ApplyResources(this.lbformat, "lbformat");
			this.lbformat.BackColor = System.Drawing.Color.Transparent;
			this.lbformat.Name = "lbformat";
			//
			// label9
			//
			resources.ApplyResources(this.label9, "label9");
			this.label9.BackColor = System.Drawing.Color.Transparent;
			this.label9.Name = "label9";
			//
			// lbclst
			//
			resources.ApplyResources(this.lbclst, "lbclst");
			this.lbclst.Name = "lbclst";
			this.lbclst.Sorted = true;
			//
			// panel4
			//
			resources.ApplyResources(this.panel4, "panel4");
			this.panel4.Name = "panel4";
			//
			// ClstForm
			//
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.clstPanel);
			this.Name = "ClstForm";
			this.clstPanel.ResumeLayout(false);
			this.clstPanel.PerformLayout();
			this.ResumeLayout(false);
		}

		#endregion
	}
}
