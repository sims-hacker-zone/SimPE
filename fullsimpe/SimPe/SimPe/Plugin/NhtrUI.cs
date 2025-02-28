// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for NhtrUI.
	/// </summary>
	public class NhtrUI
		:
		//System.Windows.Forms.UserControl
		Windows.Forms.WrapperBaseControl,
			Interfaces.Plugin.IPackedFileUI
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NhtrUI()
		{
			// Required designer variable.
			InitializeComponent();

			CanCommit = Helper.WindowsRegistry.HiddenMode;
			//ThemeManager.AddControl(this.toolBar1);
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
				new System.ComponentModel.ComponentResourceManager(typeof(NhtrUI));
			lb = new System.Windows.Forms.ListBox();
			tb = new System.Windows.Forms.TextBox();
			cb = new System.Windows.Forms.ComboBox();
			pg = new System.Windows.Forms.PropertyGrid();
			panel1 = new System.Windows.Forms.Panel();
			panel2 = new System.Windows.Forms.Panel();
			splitter1 = new System.Windows.Forms.Splitter();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			//
			// lb
			//
			resources.ApplyResources(lb, "lb");
			lb.Name = "lb";
			lb.SelectedIndexChanged += new System.EventHandler(
				lb_SelectedIndexChanged
			);
			//
			// tb
			//
			resources.ApplyResources(tb, "tb");
			tb.Name = "tb";
			tb.ReadOnly = true;
			//
			// cb
			//
			resources.ApplyResources(cb, "cb");
			cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cb.Name = "cb";
			cb.SelectedIndexChanged += new System.EventHandler(
				comboBox1_SelectedIndexChanged
			);
			//
			// pg
			//
			resources.ApplyResources(pg, "pg");
			pg.BackColor = System.Drawing.SystemColors.Control;
			pg.LineColor = System.Drawing.SystemColors.ScrollBar;
			pg.Name = "pg";
			pg.ToolbarVisible = false;
			//
			// panel1
			//
			panel1.BackColor = System.Drawing.Color.Transparent;
			panel1.Controls.Add(cb);
			panel1.Controls.Add(lb);
			resources.ApplyResources(panel1, "panel1");
			panel1.Name = "panel1";
			//
			// panel2
			//
			panel2.BackColor = System.Drawing.Color.Transparent;
			panel2.Controls.Add(tb);
			panel2.Controls.Add(pg);
			resources.ApplyResources(panel2, "panel2");
			panel2.Name = "panel2";
			//
			// splitter1
			//
			resources.ApplyResources(splitter1, "splitter1");
			splitter1.Name = "splitter1";
			splitter1.TabStop = false;
			//
			// NhtrUI
			//
			Controls.Add(panel2);
			Controls.Add(splitter1);
			Controls.Add(panel1);
			resources.ApplyResources(this, "$this");
			Name = "NhtrUI";
			Controls.SetChildIndex(panel1, 0);
			Controls.SetChildIndex(splitter1, 0);
			Controls.SetChildIndex(panel2, 0);
			panel1.ResumeLayout(false);
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
		}
		#endregion

		private System.Windows.Forms.ListBox lb;
		private System.Windows.Forms.TextBox tb;
		private System.Windows.Forms.ComboBox cb;
		private System.Windows.Forms.PropertyGrid pg;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Splitter splitter1;

		public Nhtr Nhtr => (Nhtr)Wrapper;

		bool intern;

		protected override void RefreshGUI()
		{
			if (intern)
			{
				return;
			}

			intern = true;
			lb.Items.Clear();
			cb.Items.Clear();
			if (Nhtr != null)
			{
				foreach (NhtrList list in Nhtr.Items)
				{
					CountedListItem.Add(cb, list);
				}

				if (cb.Items.Count > 0)
				{
					cb.SelectedIndex = 0;
				}

				lb.Enabled = true;
				Enabled = true;
			}
			else
			{
			}

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
				pg.SelectedObject =
					(lb.SelectedItem as CountedListItem).Object as NhtrItem
				;
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lb.Items.Clear();
			if (cb.SelectedItem == null)
			{
				return;
			}

			NhtrList list = (cb.SelectedItem as CountedListItem).Object as NhtrList;
			foreach (NhtrItem i in list)
			{
				CountedListItem.Add(lb, i);
			}
		}
	}
}
