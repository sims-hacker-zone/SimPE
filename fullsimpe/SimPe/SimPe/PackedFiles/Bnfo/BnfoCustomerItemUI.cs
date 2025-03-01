// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimPe.PackedFiles.Bnfo
{
	/// <summary>
	/// Summary description for BnfoCustomerItemUI.
	/// </summary>
	public class BnfoCustomerItemUI : UserControl
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private readonly System.ComponentModel.Container components = null;

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
				new System.ComponentModel.ComponentResourceManager(
					typeof(BnfoCustomerItemUI)
				);
			tb = new TextBox();
			pb = new Ambertation.Windows.Forms.LabeledProgressBar();
			SuspendLayout();
			//
			// tb
			//
			resources.ApplyResources(tb, "tb");
			tb.HideSelection = false;
			tb.Name = "tb";
			tb.ReadOnly = true;
			tb.TextChanged += new EventHandler(tb_TextChanged);
			//
			// pb
			//
			pb.BackColor = Color.Transparent;
			pb.DisplayOffset = 0;
			resources.ApplyResources(pb, "pb");
			pb.Maximum = 2000;
			pb.Name = "pb";
			pb.NumberFormat = "N0";
			pb.NumberOffset = -1000;
			pb.NumberScale = 0.005;
			pb.SelectedColor = Color.Gold;
			pb.Style = Ambertation.Windows.Forms.ProgresBarStyle.Balance;
			pb.TokenCount = 11;
			pb.UnselectedColor = Color.Black;
			pb.Value = 1000;
			pb.ChangedValue += new EventHandler(pb_Changed);
			//
			// BnfoCustomerItemUI
			//
			Controls.Add(pb);
			Controls.Add(tb);
			resources.ApplyResources(this, "$this");
			Name = "BnfoCustomerItemUI";
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion

		private BnfoCustomerItem item;
		private TextBox tb;

		[System.ComponentModel.Browsable(false)]
		public BnfoCustomerItem Item
		{
			get => item;
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

		private BnfoCustomerItemsUI ui;
		private Ambertation.Windows.Forms.LabeledProgressBar pb;

		public BnfoCustomerItemsUI BnfoCustomerItemsUI
		{
			get => ui;
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

		private bool intern;

		private void SetContent()
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

		private void tb_TextChanged(object sender, EventArgs e)
		{
		}

		private void pb_Changed(object sender, EventArgs e)
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
