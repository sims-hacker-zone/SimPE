using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for BnfoCustomerItemUI.
	/// </summary>
	public class BnfoCustomerItemUI : System.Windows.Forms.UserControl
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BnfoCustomerItemUI()
		{
			SetStyle(
				ControlStyles.SupportsTransparentBackColor
					| ControlStyles.AllPaintingInWmPaint
					|
					//ControlStyles.Opaque |
					ControlStyles.UserPaint
					| ControlStyles.ResizeRedraw
					| ControlStyles.DoubleBuffer,
				true
			);

			// Required designer variable.
			InitializeComponent();

			try
			{
				tb.Visible = Helper.WindowsRegistry.HiddenMode;
				SetContent();
			}
			catch { }
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				BnfoCustomerItemsUI = null;
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
				new System.ComponentModel.ComponentResourceManager(
					typeof(BnfoCustomerItemUI)
				);
			this.tb = new System.Windows.Forms.TextBox();
			this.pb = new Ambertation.Windows.Forms.LabeledProgressBar();
			this.SuspendLayout();
			//
			// tb
			//
			resources.ApplyResources(this.tb, "tb");
			this.tb.HideSelection = false;
			this.tb.Name = "tb";
			this.tb.ReadOnly = true;
			this.tb.TextChanged += new System.EventHandler(this.tb_TextChanged);
			//
			// pb
			//
			this.pb.BackColor = System.Drawing.Color.Transparent;
			this.pb.DisplayOffset = 0;
			resources.ApplyResources(this.pb, "pb");
			this.pb.Maximum = 2000;
			this.pb.Name = "pb";
			this.pb.NumberFormat = "N0";
			this.pb.NumberOffset = -1000;
			this.pb.NumberScale = 0.005;
			this.pb.SelectedColor = System.Drawing.Color.Gold;
			this.pb.Style = Ambertation.Windows.Forms.ProgresBarStyle.Balance;
			this.pb.TokenCount = 11;
			this.pb.UnselectedColor = System.Drawing.Color.Black;
			this.pb.Value = 1000;
			this.pb.ChangedValue += new System.EventHandler(this.pb_Changed);
			//
			// BnfoCustomerItemUI
			//
			this.Controls.Add(this.pb);
			this.Controls.Add(this.tb);
			resources.ApplyResources(this, "$this");
			this.Name = "BnfoCustomerItemUI";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion

		BnfoCustomerItem item;
		private System.Windows.Forms.TextBox tb;

		[System.ComponentModel.Browsable(false)]
		public BnfoCustomerItem Item
		{
			get
			{
				return item;
			}
			set
			{
				/*if (item!=null)
				{
					item.LoyaltyScore = pb.Value;
				}*/
				item = value;
				SetContent();
			}
		}

		BnfoCustomerItemsUI ui;
		private Ambertation.Windows.Forms.LabeledProgressBar pb;

		public BnfoCustomerItemsUI BnfoCustomerItemsUI
		{
			get
			{
				return ui;
			}
			set
			{
				if (ui != null)
				{
					ui.SelectedItemChanged -= new EventHandler(ui_SelectedItemChanged);
				}

				ui = value;
				if (ui != null)
				{
					ui.SelectedItemChanged += new EventHandler(ui_SelectedItemChanged);
					ui_SelectedItemChanged(ui, null);
				}
			}
		}

		bool intern;

		void SetContent()
		{
			if (intern)
			{
				return;
			}

			intern = true;
			if (item != null)
			{
				tb.Text = Helper.BytesToHexList(item.Data);
				pb.Value = item.LoyaltyScore;
				pb.Enabled = true;
			}
			else
			{
				tb.Text = "";
				pb.Value = 0;
				pb.Enabled = false;
			}
			intern = false;
		}

		private void ui_SelectedItemChanged(object sender, EventArgs e)
		{
			Item = ui.SelectedItem;
		}

		private void tb_TextChanged(object sender, System.EventArgs e)
		{
		}

		private void pb_Changed(object sender, System.EventArgs e)
		{
			if (intern)
			{
				return;
			}

			if (item == null)
			{
				return;
			}

			if (pb.Value < 0 && pb.SelectedColor != Color.Coral)
			{
				pb.SelectedColor = Color.Coral;
				pb.CompleteRedraw();
			}
			else if (pb.Value >= 0 && pb.SelectedColor != Color.Gold)
			{
				pb.SelectedColor = Color.Gold;
				pb.CompleteRedraw();
			}

			item.LoyaltyScore = pb.Value;
		}
	}
}
