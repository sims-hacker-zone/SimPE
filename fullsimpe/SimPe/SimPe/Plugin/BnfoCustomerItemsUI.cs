using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SimPe.Plugin
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
		private System.ComponentModel.Container components = null;

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
			this.lb = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			//
			// lb
			//
			this.lb.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
			this.lb.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lb.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lb.HorizontalScrollbar = true;
			this.lb.IntegralHeight = false;
			this.lb.Location = new System.Drawing.Point(0, 0);
			this.lb.Name = "lb";
			this.lb.Size = new System.Drawing.Size(304, 104);
			this.lb.TabIndex = 0;
			this.lb.SelectedIndexChanged += new System.EventHandler(
				this.lb_SelectedIndexChanged
			);
			//
			// BnfoCustomerItemsUI
			//
			this.Controls.Add(this.lb);
			this.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.Name = "BnfoCustomerItemsUI";
			this.Size = new System.Drawing.Size(304, 104);
			this.ResumeLayout(false);
		}
		#endregion

		private System.Windows.Forms.ListBox lb;

		Collections.BnfoCustomerItems items;

		[System.ComponentModel.Browsable(false)]
		public Collections.BnfoCustomerItems Items
		{
			get
			{
				return items;
			}
			set
			{
				items = value;
				SetContent();
			}
		}

		void SetContent()
		{
			lb.Items.Clear();
			if (items != null)
			{
				foreach (Plugin.BnfoCustomerItem item in items)
					lb.Items.Add(item);
			}
			lb_SelectedIndexChanged(lb, new EventArgs());
		}

		public BnfoCustomerItem SelectedItem => lb.SelectedItem as BnfoCustomerItem;

		public new void Refresh()
		{
			SetContent();
			base.Refresh();
		}

		public event System.EventHandler SelectedItemChanged;

		private void lb_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (SelectedItemChanged != null)
				SelectedItemChanged(this, new EventArgs());
		}
	}
}
