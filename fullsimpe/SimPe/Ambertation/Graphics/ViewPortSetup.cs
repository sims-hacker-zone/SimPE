// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Ambertation.Graphics
{
	public class ViewPortSetup : Form
	{
		private IContainer components;

		private PropertyGrid pg;

		private ViewportSetting vp;

		private static bool visible;

		private DirectXPanel panel;

		public new static bool Visible => visible;

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}

			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.pg = new System.Windows.Forms.PropertyGrid();
			base.SuspendLayout();
			this.pg.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pg.HelpVisible = false;
			this.pg.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.pg.Location = new System.Drawing.Point(0, 0);
			this.pg.Name = "pg";
			this.pg.Size = new System.Drawing.Size(248, 429);
			this.pg.TabIndex = 4;
			this.pg.ToolbarVisible = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			base.ClientSize = new System.Drawing.Size(248, 429);
			base.Controls.Add(this.pg);
			this.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "ViewPortSetup";
			this.Text = "ViewPort Setup";
			base.ResumeLayout(false);
		}

		private ViewPortSetup()
		{
			InitializeComponent();
		}

		public static ViewPortSetup Execute(ViewportSetting vp, DirectXPanel panel)
		{
			visible = true;
			ViewPortSetup viewPortSetup = new ViewPortSetup();
			viewPortSetup.vp = vp;
			viewPortSetup.panel = panel;
			viewPortSetup.SetContent(vp);
			viewPortSetup.Show();
			return viewPortSetup;
		}

		private void pg_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
		{
			panel.Reset();
		}

		public static void Hide(ViewPortSetup f)
		{
			try
			{
				f.Close();
				visible = false;
			}
			catch
			{
			}
		}

		private void SetContent(ViewportSetting vp)
		{
			pg.SelectedObject = vp;
		}
	}
}
