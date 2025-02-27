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
	/// Summary description for TattUI.
	/// </summary>
	public class TattUI : Windows.Forms.WrapperBaseControl
	//System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbVer;
		private System.Windows.Forms.TextBox tbRes;
		private System.Windows.Forms.TextBox tbFlname;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ListBox lb;
		private System.ComponentModel.IContainer components;

		public TattUI()
		{
			// Required designer variable.
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
			components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources =
				new System.Resources.ResourceManager(typeof(TattUI));
			timer1 = new System.Windows.Forms.Timer(components);
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			tbVer = new System.Windows.Forms.TextBox();
			tbRes = new System.Windows.Forms.TextBox();
			tbFlname = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			lb = new System.Windows.Forms.ListBox();
			SuspendLayout();
			//
			// label1
			//
			label1.AccessibleDescription = resources.GetString(
				"label1.AccessibleDescription"
			);
			label1.AccessibleName = resources.GetString("label1.AccessibleName");
			label1.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					resources.GetObject("label1.Anchor")
				)
			);
			label1.AutoSize = ((bool)(resources.GetObject("label1.AutoSize")));
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.Dock = (
				(System.Windows.Forms.DockStyle)(resources.GetObject("label1.Dock"))
			);
			label1.Enabled = ((bool)(resources.GetObject("label1.Enabled")));
			label1.Font = (
				(System.Drawing.Font)(resources.GetObject("label1.Font"))
			);
			label1.Image = (
				(System.Drawing.Image)(resources.GetObject("label1.Image"))
			);
			label1.ImageAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("label1.ImageAlign")
				)
			);
			label1.ImageIndex = ((int)(resources.GetObject("label1.ImageIndex")));
			label1.ImeMode = (
				(System.Windows.Forms.ImeMode)(resources.GetObject("label1.ImeMode"))
			);
			label1.Location = (
				(System.Drawing.Point)(resources.GetObject("label1.Location"))
			);
			label1.Name = "label1";
			label1.RightToLeft = (
				(System.Windows.Forms.RightToLeft)(
					resources.GetObject("label1.RightToLeft")
				)
			);
			label1.Size = (
				(System.Drawing.Size)(resources.GetObject("label1.Size"))
			);
			label1.TabIndex = ((int)(resources.GetObject("label1.TabIndex")));
			label1.Text = resources.GetString("label1.Text");
			label1.TextAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("label1.TextAlign")
				)
			);
			label1.Visible = ((bool)(resources.GetObject("label1.Visible")));
			//
			// label2
			//
			label2.AccessibleDescription = resources.GetString(
				"label2.AccessibleDescription"
			);
			label2.AccessibleName = resources.GetString("label2.AccessibleName");
			label2.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					resources.GetObject("label2.Anchor")
				)
			);
			label2.AutoSize = ((bool)(resources.GetObject("label2.AutoSize")));
			label2.BackColor = System.Drawing.Color.Transparent;
			label2.Dock = (
				(System.Windows.Forms.DockStyle)(resources.GetObject("label2.Dock"))
			);
			label2.Enabled = ((bool)(resources.GetObject("label2.Enabled")));
			label2.Font = (
				(System.Drawing.Font)(resources.GetObject("label2.Font"))
			);
			label2.Image = (
				(System.Drawing.Image)(resources.GetObject("label2.Image"))
			);
			label2.ImageAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("label2.ImageAlign")
				)
			);
			label2.ImageIndex = ((int)(resources.GetObject("label2.ImageIndex")));
			label2.ImeMode = (
				(System.Windows.Forms.ImeMode)(resources.GetObject("label2.ImeMode"))
			);
			label2.Location = (
				(System.Drawing.Point)(resources.GetObject("label2.Location"))
			);
			label2.Name = "label2";
			label2.RightToLeft = (
				(System.Windows.Forms.RightToLeft)(
					resources.GetObject("label2.RightToLeft")
				)
			);
			label2.Size = (
				(System.Drawing.Size)(resources.GetObject("label2.Size"))
			);
			label2.TabIndex = ((int)(resources.GetObject("label2.TabIndex")));
			label2.Text = resources.GetString("label2.Text");
			label2.TextAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("label2.TextAlign")
				)
			);
			label2.Visible = ((bool)(resources.GetObject("label2.Visible")));
			//
			// label3
			//
			label3.AccessibleDescription = resources.GetString(
				"label3.AccessibleDescription"
			);
			label3.AccessibleName = resources.GetString("label3.AccessibleName");
			label3.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					resources.GetObject("label3.Anchor")
				)
			);
			label3.AutoSize = ((bool)(resources.GetObject("label3.AutoSize")));
			label3.BackColor = System.Drawing.Color.Transparent;
			label3.Dock = (
				(System.Windows.Forms.DockStyle)(resources.GetObject("label3.Dock"))
			);
			label3.Enabled = ((bool)(resources.GetObject("label3.Enabled")));
			label3.Font = (
				(System.Drawing.Font)(resources.GetObject("label3.Font"))
			);
			label3.Image = (
				(System.Drawing.Image)(resources.GetObject("label3.Image"))
			);
			label3.ImageAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("label3.ImageAlign")
				)
			);
			label3.ImageIndex = ((int)(resources.GetObject("label3.ImageIndex")));
			label3.ImeMode = (
				(System.Windows.Forms.ImeMode)(resources.GetObject("label3.ImeMode"))
			);
			label3.Location = (
				(System.Drawing.Point)(resources.GetObject("label3.Location"))
			);
			label3.Name = "label3";
			label3.RightToLeft = (
				(System.Windows.Forms.RightToLeft)(
					resources.GetObject("label3.RightToLeft")
				)
			);
			label3.Size = (
				(System.Drawing.Size)(resources.GetObject("label3.Size"))
			);
			label3.TabIndex = ((int)(resources.GetObject("label3.TabIndex")));
			label3.Text = resources.GetString("label3.Text");
			label3.TextAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("label3.TextAlign")
				)
			);
			label3.Visible = ((bool)(resources.GetObject("label3.Visible")));
			//
			// tbVer
			//
			tbVer.AccessibleDescription = resources.GetString(
				"tbVer.AccessibleDescription"
			);
			tbVer.AccessibleName = resources.GetString("tbVer.AccessibleName");
			tbVer.Anchor = (
				(System.Windows.Forms.AnchorStyles)(resources.GetObject("tbVer.Anchor"))
			);
			tbVer.AutoSize = ((bool)(resources.GetObject("tbVer.AutoSize")));
			tbVer.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("tbVer.BackgroundImage"))
			);
			tbVer.Dock = (
				(System.Windows.Forms.DockStyle)(resources.GetObject("tbVer.Dock"))
			);
			tbVer.Enabled = ((bool)(resources.GetObject("tbVer.Enabled")));
			tbVer.Font = (
				(System.Drawing.Font)(resources.GetObject("tbVer.Font"))
			);
			tbVer.ImeMode = (
				(System.Windows.Forms.ImeMode)(resources.GetObject("tbVer.ImeMode"))
			);
			tbVer.Location = (
				(System.Drawing.Point)(resources.GetObject("tbVer.Location"))
			);
			tbVer.MaxLength = ((int)(resources.GetObject("tbVer.MaxLength")));
			tbVer.Multiline = ((bool)(resources.GetObject("tbVer.Multiline")));
			tbVer.Name = "tbVer";
			tbVer.PasswordChar = (
				(char)(resources.GetObject("tbVer.PasswordChar"))
			);
			tbVer.RightToLeft = (
				(System.Windows.Forms.RightToLeft)(
					resources.GetObject("tbVer.RightToLeft")
				)
			);
			tbVer.ScrollBars = (
				(System.Windows.Forms.ScrollBars)(
					resources.GetObject("tbVer.ScrollBars")
				)
			);
			tbVer.Size = (
				(System.Drawing.Size)(resources.GetObject("tbVer.Size"))
			);
			tbVer.TabIndex = ((int)(resources.GetObject("tbVer.TabIndex")));
			tbVer.Text = resources.GetString("tbVer.Text");
			tbVer.TextAlign = (
				(System.Windows.Forms.HorizontalAlignment)(
					resources.GetObject("tbVer.TextAlign")
				)
			);
			tbVer.Visible = ((bool)(resources.GetObject("tbVer.Visible")));
			tbVer.WordWrap = ((bool)(resources.GetObject("tbVer.WordWrap")));
			//
			// tbRes
			//
			tbRes.AccessibleDescription = resources.GetString(
				"tbRes.AccessibleDescription"
			);
			tbRes.AccessibleName = resources.GetString("tbRes.AccessibleName");
			tbRes.Anchor = (
				(System.Windows.Forms.AnchorStyles)(resources.GetObject("tbRes.Anchor"))
			);
			tbRes.AutoSize = ((bool)(resources.GetObject("tbRes.AutoSize")));
			tbRes.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("tbRes.BackgroundImage"))
			);
			tbRes.Dock = (
				(System.Windows.Forms.DockStyle)(resources.GetObject("tbRes.Dock"))
			);
			tbRes.Enabled = ((bool)(resources.GetObject("tbRes.Enabled")));
			tbRes.Font = (
				(System.Drawing.Font)(resources.GetObject("tbRes.Font"))
			);
			tbRes.ImeMode = (
				(System.Windows.Forms.ImeMode)(resources.GetObject("tbRes.ImeMode"))
			);
			tbRes.Location = (
				(System.Drawing.Point)(resources.GetObject("tbRes.Location"))
			);
			tbRes.MaxLength = ((int)(resources.GetObject("tbRes.MaxLength")));
			tbRes.Multiline = ((bool)(resources.GetObject("tbRes.Multiline")));
			tbRes.Name = "tbRes";
			tbRes.PasswordChar = (
				(char)(resources.GetObject("tbRes.PasswordChar"))
			);
			tbRes.RightToLeft = (
				(System.Windows.Forms.RightToLeft)(
					resources.GetObject("tbRes.RightToLeft")
				)
			);
			tbRes.ScrollBars = (
				(System.Windows.Forms.ScrollBars)(
					resources.GetObject("tbRes.ScrollBars")
				)
			);
			tbRes.Size = (
				(System.Drawing.Size)(resources.GetObject("tbRes.Size"))
			);
			tbRes.TabIndex = ((int)(resources.GetObject("tbRes.TabIndex")));
			tbRes.Text = resources.GetString("tbRes.Text");
			tbRes.TextAlign = (
				(System.Windows.Forms.HorizontalAlignment)(
					resources.GetObject("tbRes.TextAlign")
				)
			);
			tbRes.Visible = ((bool)(resources.GetObject("tbRes.Visible")));
			tbRes.WordWrap = ((bool)(resources.GetObject("tbRes.WordWrap")));
			//
			// tbFlname
			//
			tbFlname.AccessibleDescription = resources.GetString(
				"tbFlname.AccessibleDescription"
			);
			tbFlname.AccessibleName = resources.GetString(
				"tbFlname.AccessibleName"
			);
			tbFlname.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					resources.GetObject("tbFlname.Anchor")
				)
			);
			tbFlname.AutoSize = ((bool)(resources.GetObject("tbFlname.AutoSize")));
			tbFlname.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("tbFlname.BackgroundImage"))
			);
			tbFlname.Dock = (
				(System.Windows.Forms.DockStyle)(resources.GetObject("tbFlname.Dock"))
			);
			tbFlname.Enabled = ((bool)(resources.GetObject("tbFlname.Enabled")));
			tbFlname.Font = (
				(System.Drawing.Font)(resources.GetObject("tbFlname.Font"))
			);
			tbFlname.ImeMode = (
				(System.Windows.Forms.ImeMode)(resources.GetObject("tbFlname.ImeMode"))
			);
			tbFlname.Location = (
				(System.Drawing.Point)(resources.GetObject("tbFlname.Location"))
			);
			tbFlname.MaxLength = (
				(int)(resources.GetObject("tbFlname.MaxLength"))
			);
			tbFlname.Multiline = (
				(bool)(resources.GetObject("tbFlname.Multiline"))
			);
			tbFlname.Name = "tbFlname";
			tbFlname.PasswordChar = (
				(char)(resources.GetObject("tbFlname.PasswordChar"))
			);
			tbFlname.RightToLeft = (
				(System.Windows.Forms.RightToLeft)(
					resources.GetObject("tbFlname.RightToLeft")
				)
			);
			tbFlname.ScrollBars = (
				(System.Windows.Forms.ScrollBars)(
					resources.GetObject("tbFlname.ScrollBars")
				)
			);
			tbFlname.Size = (
				(System.Drawing.Size)(resources.GetObject("tbFlname.Size"))
			);
			tbFlname.TabIndex = ((int)(resources.GetObject("tbFlname.TabIndex")));
			tbFlname.Text = resources.GetString("tbFlname.Text");
			tbFlname.TextAlign = (
				(System.Windows.Forms.HorizontalAlignment)(
					resources.GetObject("tbFlname.TextAlign")
				)
			);
			tbFlname.Visible = ((bool)(resources.GetObject("tbFlname.Visible")));
			tbFlname.WordWrap = ((bool)(resources.GetObject("tbFlname.WordWrap")));
			tbFlname.TextChanged += new System.EventHandler(
				tbFlname_TextChanged
			);
			//
			// label4
			//
			label4.AccessibleDescription = resources.GetString(
				"label4.AccessibleDescription"
			);
			label4.AccessibleName = resources.GetString("label4.AccessibleName");
			label4.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					resources.GetObject("label4.Anchor")
				)
			);
			label4.AutoSize = ((bool)(resources.GetObject("label4.AutoSize")));
			label4.BackColor = System.Drawing.Color.Transparent;
			label4.Dock = (
				(System.Windows.Forms.DockStyle)(resources.GetObject("label4.Dock"))
			);
			label4.Enabled = ((bool)(resources.GetObject("label4.Enabled")));
			label4.Font = (
				(System.Drawing.Font)(resources.GetObject("label4.Font"))
			);
			label4.Image = (
				(System.Drawing.Image)(resources.GetObject("label4.Image"))
			);
			label4.ImageAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("label4.ImageAlign")
				)
			);
			label4.ImageIndex = ((int)(resources.GetObject("label4.ImageIndex")));
			label4.ImeMode = (
				(System.Windows.Forms.ImeMode)(resources.GetObject("label4.ImeMode"))
			);
			label4.Location = (
				(System.Drawing.Point)(resources.GetObject("label4.Location"))
			);
			label4.Name = "label4";
			label4.RightToLeft = (
				(System.Windows.Forms.RightToLeft)(
					resources.GetObject("label4.RightToLeft")
				)
			);
			label4.Size = (
				(System.Drawing.Size)(resources.GetObject("label4.Size"))
			);
			label4.TabIndex = ((int)(resources.GetObject("label4.TabIndex")));
			label4.Text = resources.GetString("label4.Text");
			label4.TextAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("label4.TextAlign")
				)
			);
			label4.Visible = ((bool)(resources.GetObject("label4.Visible")));
			//
			// lb
			//
			lb.AccessibleDescription = resources.GetString(
				"lb.AccessibleDescription"
			);
			lb.AccessibleName = resources.GetString("lb.AccessibleName");
			lb.Anchor = (
				(System.Windows.Forms.AnchorStyles)(resources.GetObject("lb.Anchor"))
			);
			lb.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("lb.BackgroundImage"))
			);
			lb.ColumnWidth = ((int)(resources.GetObject("lb.ColumnWidth")));
			lb.Dock = (
				(System.Windows.Forms.DockStyle)(resources.GetObject("lb.Dock"))
			);
			lb.Enabled = ((bool)(resources.GetObject("lb.Enabled")));
			lb.Font = ((System.Drawing.Font)(resources.GetObject("lb.Font")));
			lb.HorizontalExtent = (
				(int)(resources.GetObject("lb.HorizontalExtent"))
			);
			lb.HorizontalScrollbar = (
				(bool)(resources.GetObject("lb.HorizontalScrollbar"))
			);
			lb.ImeMode = (
				(System.Windows.Forms.ImeMode)(resources.GetObject("lb.ImeMode"))
			);
			lb.IntegralHeight = ((bool)(resources.GetObject("lb.IntegralHeight")));
			lb.ItemHeight = ((int)(resources.GetObject("lb.ItemHeight")));
			lb.Location = (
				(System.Drawing.Point)(resources.GetObject("lb.Location"))
			);
			lb.Name = "lb";
			lb.RightToLeft = (
				(System.Windows.Forms.RightToLeft)(
					resources.GetObject("lb.RightToLeft")
				)
			);
			lb.ScrollAlwaysVisible = (
				(bool)(resources.GetObject("lb.ScrollAlwaysVisible"))
			);
			lb.Size = ((System.Drawing.Size)(resources.GetObject("lb.Size")));
			lb.TabIndex = ((int)(resources.GetObject("lb.TabIndex")));
			lb.Visible = ((bool)(resources.GetObject("lb.Visible")));
			//
			// TattUI
			//
			AccessibleDescription = resources.GetString(
				"$this.AccessibleDescription"
			);
			AccessibleName = resources.GetString("$this.AccessibleName");
			AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			AutoScrollMargin = (
				(System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin"))
			);
			AutoScrollMinSize = (
				(System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize"))
			);
			BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("$this.BackgroundImage"))
			);
			Controls.Add(lb);
			Controls.Add(label4);
			Controls.Add(tbFlname);
			Controls.Add(tbRes);
			Controls.Add(tbVer);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			DockPadding.Top = 24;
			Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
			HeaderText = resources.GetString("$this.HeaderText");
			ImeMode = (
				(System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode"))
			);
			Location = (
				(System.Drawing.Point)(resources.GetObject("$this.Location"))
			);
			Name = "TattUI";
			RightToLeft = (
				(System.Windows.Forms.RightToLeft)(
					resources.GetObject("$this.RightToLeft")
				)
			);
			Size = ((System.Drawing.Size)(resources.GetObject("$this.Size")));
			Commited += new System.EventHandler(TattUI_Commited);
			Controls.SetChildIndex(label1, 0);
			Controls.SetChildIndex(label2, 0);
			Controls.SetChildIndex(label3, 0);
			Controls.SetChildIndex(tbVer, 0);
			Controls.SetChildIndex(tbRes, 0);
			Controls.SetChildIndex(tbFlname, 0);
			Controls.SetChildIndex(label4, 0);
			Controls.SetChildIndex(lb, 0);
			ResumeLayout(false);
		}
		#endregion

		public Tatt Tatt => (Tatt)Wrapper;

		//bool inter;
		protected override void RefreshGUI()
		{
			base.RefreshGUI();

			//inter =true;
			tbFlname.Text = Tatt.FileName;
			tbRes.Text = "0x" + Helper.HexString(Tatt.Reserved);
			tbVer.Text = "0x" + Helper.HexString(Tatt.Version);

			lb.Items.Clear();
			foreach (TattItem ti in Tatt)
			{
				lb.Items.Add(ti);
			}

			//inter = false;
		}

		private void TattUI_Commited(object sender, System.EventArgs e)
		{
			Tatt.SynchronizeUserData();
		}

		private void tbFlname_TextChanged(object sender, System.EventArgs e)
		{
			Tatt.FileName = tbFlname.Text;
			Tatt.Reserved = Helper.StringToUInt32(tbRes.Text, Tatt.Reserved, 16);
			Tatt.Version = Helper.StringToUInt32(tbVer.Text, Tatt.Version, 16);

			Tatt.Changed = true;
		}
	}
}
