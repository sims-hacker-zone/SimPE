// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

namespace SimPe.PackedFiles.Bnfo
{
	/// <summary>
	/// Summary description for BnfoCustomerItemsUI.
	/// </summary>
	[System.ComponentModel.DefaultEvent("SelectedItemChanged")]
	public class BnfoCustomerItemsUI : System.Windows.Forms.UserControl
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private readonly System.ComponentModel.Container components = null;

		public BnfoCustomerItemsUI()
		{
			InitializeComponent();

			SetContent();
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
			SuspendLayout();
			//
			// lb
			//
			lb.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
			lb.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lb.Dock = System.Windows.Forms.DockStyle.Fill;
			lb.HorizontalScrollbar = true;
			lb.IntegralHeight = false;
			lb.Location = new System.Drawing.Point(0, 0);
			lb.Name = "lb";
			lb.Size = new System.Drawing.Size(304, 104);
			lb.TabIndex = 0;
			lb.SelectedIndexChanged += new EventHandler(
				lb_SelectedIndexChanged
			);
			//
			// BnfoCustomerItemsUI
			//
			Controls.Add(lb);
			Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			Name = "BnfoCustomerItemsUI";
			Size = new System.Drawing.Size(304, 104);
			ResumeLayout(false);
		}
		#endregion

		private System.Windows.Forms.ListBox lb;
		private BnfoCustomerItems items;

		[System.ComponentModel.Browsable(false)]
		public BnfoCustomerItems Items
		{
			get => items;
			set
			{
				items = value;
				SetContent();
			}
		}

		private void SetContent()
		{
			lb.Items.Clear();
			if (items != null)
			{
				foreach (BnfoCustomerItem item in items)
				{
					lb.Items.Add(item);
				}
			}
			lb_SelectedIndexChanged(lb, new EventArgs());
		}

		public BnfoCustomerItem SelectedItem => lb.SelectedItem as BnfoCustomerItem;

		public new void Refresh()
		{
			SetContent();
			base.Refresh();
		}

		public event EventHandler SelectedItemChanged;

		private void lb_SelectedIndexChanged(object sender, EventArgs e)
		{
			SelectedItemChanged?.Invoke(this, new EventArgs());
		}
	}
}
