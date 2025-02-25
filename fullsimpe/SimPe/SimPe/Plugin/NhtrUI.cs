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
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Ambertation.Windows.Forms;
using SimPe.Data;
using SimPe.Interfaces;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Wrapper;
using SimPe.PackedFiles.Wrapper.Supporting;
using SimPe.Windows.Forms;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for NhtrUI.
	/// </summary>
	public class NhtrUI
		:
		//System.Windows.Forms.UserControl
		SimPe.Windows.Forms.WrapperBaseControl,
			SimPe.Interfaces.Plugin.IPackedFileUI
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NhtrUI()
		{
			// Required designer variable.
			InitializeComponent();

			this.CanCommit = Helper.WindowsRegistry.HiddenMode;
			//ThemeManager.AddControl(this.toolBar1);
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
				new System.ComponentModel.ComponentResourceManager(typeof(NhtrUI));
			this.lb = new System.Windows.Forms.ListBox();
			this.tb = new System.Windows.Forms.TextBox();
			this.cb = new System.Windows.Forms.ComboBox();
			this.pg = new System.Windows.Forms.PropertyGrid();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			//
			// lb
			//
			resources.ApplyResources(this.lb, "lb");
			this.lb.Name = "lb";
			this.lb.SelectedIndexChanged += new System.EventHandler(
				this.lb_SelectedIndexChanged
			);
			//
			// tb
			//
			resources.ApplyResources(this.tb, "tb");
			this.tb.Name = "tb";
			this.tb.ReadOnly = true;
			//
			// cb
			//
			resources.ApplyResources(this.cb, "cb");
			this.cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb.Name = "cb";
			this.cb.SelectedIndexChanged += new System.EventHandler(
				this.comboBox1_SelectedIndexChanged
			);
			//
			// pg
			//
			resources.ApplyResources(this.pg, "pg");
			this.pg.BackColor = System.Drawing.SystemColors.Control;
			this.pg.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.pg.Name = "pg";
			this.pg.ToolbarVisible = false;
			//
			// panel1
			//
			this.panel1.BackColor = System.Drawing.Color.Transparent;
			this.panel1.Controls.Add(this.cb);
			this.panel1.Controls.Add(this.lb);
			resources.ApplyResources(this.panel1, "panel1");
			this.panel1.Name = "panel1";
			//
			// panel2
			//
			this.panel2.BackColor = System.Drawing.Color.Transparent;
			this.panel2.Controls.Add(this.tb);
			this.panel2.Controls.Add(this.pg);
			resources.ApplyResources(this.panel2, "panel2");
			this.panel2.Name = "panel2";
			//
			// splitter1
			//
			resources.ApplyResources(this.splitter1, "splitter1");
			this.splitter1.Name = "splitter1";
			this.splitter1.TabStop = false;
			//
			// NhtrUI
			//
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panel1);
			resources.ApplyResources(this, "$this");
			this.Name = "NhtrUI";
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.splitter1, 0);
			this.Controls.SetChildIndex(this.panel2, 0);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);
		}
		#endregion

		private System.Windows.Forms.ListBox lb;
		private System.Windows.Forms.TextBox tb;
		private System.Windows.Forms.ComboBox cb;
		private System.Windows.Forms.PropertyGrid pg;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Splitter splitter1;

		public Nhtr Nhtr
		{
			get { return (Nhtr)Wrapper; }
		}

		bool intern;

		protected override void RefreshGUI()
		{
			if (intern)
				return;

			intern = true;
			lb.Items.Clear();
			cb.Items.Clear();
			if (Nhtr != null)
			{
				foreach (NhtrList list in Nhtr.Items)
					SimPe.CountedListItem.Add(cb, list);

				if (cb.Items.Count > 0)
					cb.SelectedIndex = 0;

				lb.Enabled = true;
				this.Enabled = true;
			}
			else { }

			intern = false;
		}

		public override void OnCommit()
		{
			Nhtr.SynchronizeUserData(true, false);
		}

		private void lb_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lb.SelectedItem == null)
			{
				tb.Text = "";
				pg.SelectedObject = null;
			}
			else
			{
				tb.Text = (
					(lb.SelectedItem as CountedListItem).Object as NhtrItem
				).ToLongString();
				pg.SelectedObject = (
					(lb.SelectedItem as CountedListItem).Object as NhtrItem
				);
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lb.Items.Clear();
			if (cb.SelectedItem == null)
				return;

			NhtrList list = (cb.SelectedItem as CountedListItem).Object as NhtrList;
			foreach (NhtrItem i in list)
				SimPe.CountedListItem.Add(lb, i);
		}
	}
}
