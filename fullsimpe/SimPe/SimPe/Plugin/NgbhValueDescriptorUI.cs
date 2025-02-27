using System;
using System.Windows.Forms;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for NgbhValueDescriptorUI.
	/// </summary>
	[System.ComponentModel.DefaultEvent("AddedNewItem")]
	public class NgbhValueDescriptorUI : UserControl
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NgbhValueDescriptorUI()
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
			System.Resources.ResourceManager resources =
				new System.Resources.ResourceManager(typeof(NgbhValueDescriptorUI));
			panel1 = new Panel();
			pb = new Ambertation.Windows.Forms.LabeledProgressBar();
			panel2 = new Panel();
			cb = new CheckBox();
			panel3 = new Panel();
			lb = new Label();
			ll = new LinkLabel();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			panel3.SuspendLayout();
			SuspendLayout();
			//
			// panel1
			//
			panel1.AccessibleDescription = resources.GetString(
				"panel1.AccessibleDescription"
			);
			panel1.AccessibleName = resources.GetString("panel1.AccessibleName");
			panel1.Anchor = (
				(AnchorStyles)(
					resources.GetObject("panel1.Anchor")
				)
			);
			panel1.AutoScroll = ((bool)(resources.GetObject("panel1.AutoScroll")));
			panel1.AutoScrollMargin = (
				(System.Drawing.Size)(resources.GetObject("panel1.AutoScrollMargin"))
			);
			panel1.AutoScrollMinSize = (
				(System.Drawing.Size)(resources.GetObject("panel1.AutoScrollMinSize"))
			);
			panel1.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage"))
			);
			panel1.Controls.Add(pb);
			panel1.Dock = (
				(DockStyle)(resources.GetObject("panel1.Dock"))
			);
			panel1.Enabled = ((bool)(resources.GetObject("panel1.Enabled")));
			panel1.Font = (
				(System.Drawing.Font)(resources.GetObject("panel1.Font"))
			);
			panel1.ImeMode = (
				(ImeMode)(resources.GetObject("panel1.ImeMode"))
			);
			panel1.Location = (
				(System.Drawing.Point)(resources.GetObject("panel1.Location"))
			);
			panel1.Name = "panel1";
			panel1.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("panel1.RightToLeft")
				)
			);
			panel1.Size = (
				(System.Drawing.Size)(resources.GetObject("panel1.Size"))
			);
			panel1.TabIndex = ((int)(resources.GetObject("panel1.TabIndex")));
			panel1.Text = resources.GetString("panel1.Text");
			panel1.Visible = ((bool)(resources.GetObject("panel1.Visible")));
			//
			// pb
			//
			pb.AccessibleDescription = resources.GetString(
				"pb.AccessibleDescription"
			);
			pb.AccessibleName = resources.GetString("pb.AccessibleName");
			pb.Anchor = (
				(AnchorStyles)(resources.GetObject("pb.Anchor"))
			);
			pb.AutoScroll = ((bool)(resources.GetObject("pb.AutoScroll")));
			pb.AutoScrollMargin = (
				(System.Drawing.Size)(resources.GetObject("pb.AutoScrollMargin"))
			);
			pb.AutoScrollMinSize = (
				(System.Drawing.Size)(resources.GetObject("pb.AutoScrollMinSize"))
			);
			pb.BackColor = System.Drawing.Color.Transparent;
			pb.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("pb.BackgroundImage"))
			);
			pb.DisplayOffset = 0;
			pb.Dock = (
				(DockStyle)(resources.GetObject("pb.Dock"))
			);
			pb.DockPadding.Bottom = 5;
			pb.Enabled = ((bool)(resources.GetObject("pb.Enabled")));
			pb.Font = ((System.Drawing.Font)(resources.GetObject("pb.Font")));
			pb.ImeMode = (
				(ImeMode)(resources.GetObject("pb.ImeMode"))
			);
			pb.LabelText = resources.GetString("pb.LabelText");
			pb.LabelWidth = ((int)(resources.GetObject("pb.LabelWidth")));
			pb.Location = (
				(System.Drawing.Point)(resources.GetObject("pb.Location"))
			);
			pb.Maximum = 100;
			pb.Name = "pb";
			pb.NumberFormat = "N0";
			pb.NumberOffset = 0;
			pb.NumberScale = 1;
			pb.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("pb.RightToLeft")
				)
			);
			pb.SelectedColor = System.Drawing.Color.YellowGreen;
			pb.Size = ((System.Drawing.Size)(resources.GetObject("pb.Size")));
			pb.Style = Ambertation.Windows.Forms.ProgresBarStyle.Increase;
			pb.TabIndex = ((int)(resources.GetObject("pb.TabIndex")));
			pb.TextboxWidth = ((int)(resources.GetObject("pb.TextboxWidth")));
			pb.TokenCount = 10;
			pb.UnselectedColor = System.Drawing.Color.Black;
			pb.Value = 0;
			pb.Visible = ((bool)(resources.GetObject("pb.Visible")));
			pb.Changed += new EventHandler(pb_Changed);
			pb.Resize += new EventHandler(pb_Resize);
			pb.Load += new EventHandler(pb_Load);
			//
			// panel2
			//
			panel2.AccessibleDescription = resources.GetString(
				"panel2.AccessibleDescription"
			);
			panel2.AccessibleName = resources.GetString("panel2.AccessibleName");
			panel2.Anchor = (
				(AnchorStyles)(
					resources.GetObject("panel2.Anchor")
				)
			);
			panel2.AutoScroll = ((bool)(resources.GetObject("panel2.AutoScroll")));
			panel2.AutoScrollMargin = (
				(System.Drawing.Size)(resources.GetObject("panel2.AutoScrollMargin"))
			);
			panel2.AutoScrollMinSize = (
				(System.Drawing.Size)(resources.GetObject("panel2.AutoScrollMinSize"))
			);
			panel2.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage"))
			);
			panel2.Controls.Add(cb);
			panel2.Dock = (
				(DockStyle)(resources.GetObject("panel2.Dock"))
			);
			panel2.Enabled = ((bool)(resources.GetObject("panel2.Enabled")));
			panel2.Font = (
				(System.Drawing.Font)(resources.GetObject("panel2.Font"))
			);
			panel2.ImeMode = (
				(ImeMode)(resources.GetObject("panel2.ImeMode"))
			);
			panel2.Location = (
				(System.Drawing.Point)(resources.GetObject("panel2.Location"))
			);
			panel2.Name = "panel2";
			panel2.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("panel2.RightToLeft")
				)
			);
			panel2.Size = (
				(System.Drawing.Size)(resources.GetObject("panel2.Size"))
			);
			panel2.TabIndex = ((int)(resources.GetObject("panel2.TabIndex")));
			panel2.Text = resources.GetString("panel2.Text");
			panel2.Visible = ((bool)(resources.GetObject("panel2.Visible")));
			//
			// cb
			//
			cb.AccessibleDescription = resources.GetString(
				"cb.AccessibleDescription"
			);
			cb.AccessibleName = resources.GetString("cb.AccessibleName");
			cb.Anchor = (
				(AnchorStyles)(resources.GetObject("cb.Anchor"))
			);
			cb.Appearance = (
				(Appearance)(resources.GetObject("cb.Appearance"))
			);
			cb.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("cb.BackgroundImage"))
			);
			cb.CheckAlign = (
				(System.Drawing.ContentAlignment)(resources.GetObject("cb.CheckAlign"))
			);
			cb.Dock = (
				(DockStyle)(resources.GetObject("cb.Dock"))
			);
			cb.Enabled = ((bool)(resources.GetObject("cb.Enabled")));
			cb.FlatStyle = (
				(FlatStyle)(resources.GetObject("cb.FlatStyle"))
			);
			cb.Font = ((System.Drawing.Font)(resources.GetObject("cb.Font")));
			cb.Image = ((System.Drawing.Image)(resources.GetObject("cb.Image")));
			cb.ImageAlign = (
				(System.Drawing.ContentAlignment)(resources.GetObject("cb.ImageAlign"))
			);
			cb.ImageIndex = ((int)(resources.GetObject("cb.ImageIndex")));
			cb.ImeMode = (
				(ImeMode)(resources.GetObject("cb.ImeMode"))
			);
			cb.Location = (
				(System.Drawing.Point)(resources.GetObject("cb.Location"))
			);
			cb.Name = "cb";
			cb.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("cb.RightToLeft")
				)
			);
			cb.Size = ((System.Drawing.Size)(resources.GetObject("cb.Size")));
			cb.TabIndex = ((int)(resources.GetObject("cb.TabIndex")));
			cb.Text = resources.GetString("cb.Text");
			cb.TextAlign = (
				(System.Drawing.ContentAlignment)(resources.GetObject("cb.TextAlign"))
			);
			cb.Visible = ((bool)(resources.GetObject("cb.Visible")));
			cb.CheckedChanged += new EventHandler(cb_CheckedChanged);
			//
			// panel3
			//
			panel3.AccessibleDescription = resources.GetString(
				"panel3.AccessibleDescription"
			);
			panel3.AccessibleName = resources.GetString("panel3.AccessibleName");
			panel3.Anchor = (
				(AnchorStyles)(
					resources.GetObject("panel3.Anchor")
				)
			);
			panel3.AutoScroll = ((bool)(resources.GetObject("panel3.AutoScroll")));
			panel3.AutoScrollMargin = (
				(System.Drawing.Size)(resources.GetObject("panel3.AutoScrollMargin"))
			);
			panel3.AutoScrollMinSize = (
				(System.Drawing.Size)(resources.GetObject("panel3.AutoScrollMinSize"))
			);
			panel3.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage"))
			);
			panel3.Controls.Add(lb);
			panel3.Controls.Add(ll);
			panel3.Dock = (
				(DockStyle)(resources.GetObject("panel3.Dock"))
			);
			panel3.Enabled = ((bool)(resources.GetObject("panel3.Enabled")));
			panel3.Font = (
				(System.Drawing.Font)(resources.GetObject("panel3.Font"))
			);
			panel3.ImeMode = (
				(ImeMode)(resources.GetObject("panel3.ImeMode"))
			);
			panel3.Location = (
				(System.Drawing.Point)(resources.GetObject("panel3.Location"))
			);
			panel3.Name = "panel3";
			panel3.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("panel3.RightToLeft")
				)
			);
			panel3.Size = (
				(System.Drawing.Size)(resources.GetObject("panel3.Size"))
			);
			panel3.TabIndex = ((int)(resources.GetObject("panel3.TabIndex")));
			panel3.Text = resources.GetString("panel3.Text");
			panel3.Visible = ((bool)(resources.GetObject("panel3.Visible")));
			//
			// lb
			//
			lb.AccessibleDescription = resources.GetString(
				"lb.AccessibleDescription"
			);
			lb.AccessibleName = resources.GetString("lb.AccessibleName");
			lb.Anchor = (
				(AnchorStyles)(resources.GetObject("lb.Anchor"))
			);
			lb.AutoSize = ((bool)(resources.GetObject("lb.AutoSize")));
			lb.Dock = (
				(DockStyle)(resources.GetObject("lb.Dock"))
			);
			lb.Enabled = ((bool)(resources.GetObject("lb.Enabled")));
			lb.Font = ((System.Drawing.Font)(resources.GetObject("lb.Font")));
			lb.Image = ((System.Drawing.Image)(resources.GetObject("lb.Image")));
			lb.ImageAlign = (
				(System.Drawing.ContentAlignment)(resources.GetObject("lb.ImageAlign"))
			);
			lb.ImageIndex = ((int)(resources.GetObject("lb.ImageIndex")));
			lb.ImeMode = (
				(ImeMode)(resources.GetObject("lb.ImeMode"))
			);
			lb.Location = (
				(System.Drawing.Point)(resources.GetObject("lb.Location"))
			);
			lb.Name = "lb";
			lb.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("lb.RightToLeft")
				)
			);
			lb.Size = ((System.Drawing.Size)(resources.GetObject("lb.Size")));
			lb.TabIndex = ((int)(resources.GetObject("lb.TabIndex")));
			lb.Text = resources.GetString("lb.Text");
			lb.TextAlign = (
				(System.Drawing.ContentAlignment)(resources.GetObject("lb.TextAlign"))
			);
			lb.Visible = ((bool)(resources.GetObject("lb.Visible")));
			//
			// ll
			//
			ll.AccessibleDescription = resources.GetString(
				"ll.AccessibleDescription"
			);
			ll.AccessibleName = resources.GetString("ll.AccessibleName");
			ll.Anchor = (
				(AnchorStyles)(resources.GetObject("ll.Anchor"))
			);
			ll.AutoSize = ((bool)(resources.GetObject("ll.AutoSize")));
			ll.Dock = (
				(DockStyle)(resources.GetObject("ll.Dock"))
			);
			ll.Enabled = ((bool)(resources.GetObject("ll.Enabled")));
			ll.Font = ((System.Drawing.Font)(resources.GetObject("ll.Font")));
			ll.Image = ((System.Drawing.Image)(resources.GetObject("ll.Image")));
			ll.ImageAlign = (
				(System.Drawing.ContentAlignment)(resources.GetObject("ll.ImageAlign"))
			);
			ll.ImageIndex = ((int)(resources.GetObject("ll.ImageIndex")));
			ll.ImeMode = (
				(ImeMode)(resources.GetObject("ll.ImeMode"))
			);
			ll.LinkArea = (
				(LinkArea)(resources.GetObject("ll.LinkArea"))
			);
			ll.Location = (
				(System.Drawing.Point)(resources.GetObject("ll.Location"))
			);
			ll.Name = "ll";
			ll.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("ll.RightToLeft")
				)
			);
			ll.Size = ((System.Drawing.Size)(resources.GetObject("ll.Size")));
			ll.TabIndex = ((int)(resources.GetObject("ll.TabIndex")));
			ll.TabStop = true;
			ll.Text = resources.GetString("ll.Text");
			ll.TextAlign = (
				(System.Drawing.ContentAlignment)(resources.GetObject("ll.TextAlign"))
			);
			ll.Visible = ((bool)(resources.GetObject("ll.Visible")));
			ll.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					ll_LinkClicked
				);
			//
			// NgbhValueDescriptorUI
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
			Controls.Add(panel3);
			Controls.Add(panel2);
			Controls.Add(panel1);
			Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
			ImeMode = (
				(ImeMode)(resources.GetObject("$this.ImeMode"))
			);
			Location = (
				(System.Drawing.Point)(resources.GetObject("$this.Location"))
			);
			Name = "NgbhValueDescriptorUI";
			RightToLeft = (
				(RightToLeft)(
					resources.GetObject("$this.RightToLeft")
				)
			);
			Size = ((System.Drawing.Size)(resources.GetObject("$this.Size")));
			panel1.ResumeLayout(false);
			panel2.ResumeLayout(false);
			panel3.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion

		NgbhSlot slot;

		[System.ComponentModel.Browsable(false)]
		public NgbhSlot Slot
		{
			get => slot;
			set
			{
				slot = value;
				SetContent();
			}
		}

		NgbhValueDescriptor des;
		private Panel panel1;
		private Ambertation.Windows.Forms.LabeledProgressBar pb;
		private Panel panel2;
		private CheckBox cb;
		private Panel panel3;
		private LinkLabel ll;
		private Label lb;

		[System.ComponentModel.Browsable(false)]
		public NgbhValueDescriptor NgbhValueDescriptor
		{
			get => des;
			set
			{
				des = value;
				SetContent();
			}
		}

		NgbhValueDescriptorSelection vds;
		public NgbhValueDescriptorSelection NgbhValueDescriptorSelection
		{
			get => vds;
			set
			{
				if (vds != null)
				{
					vds.SelectedDescriptorChanged -= new EventHandler(
						vds_SelectedDescriptorChanged
					);
				}

				vds = value;
				if (vds != null)
				{
					vds.SelectedDescriptorChanged += new EventHandler(
						vds_SelectedDescriptorChanged
					);
				}
			}
		}

		void SetVisible()
		{
			panel1.Visible = item != null;
			if (des != null)
			{
				panel2.Visible = des.HasComplededFlag && item != null;
			}
			else
			{
				panel2.Visible = false;
			}

			panel3.Visible = des != null && item == null;
		}

		NgbhItem item;
		bool inter;

		void SetContent()
		{
			if (inter)
			{
				return;
			}

			inter = true;
			if (des != null && slot != null)
			{
				item = slot.FindItem(des.Guid);
				pb.NumberOffset = des.Minimum;
				pb.Maximum = des.Maximum;

				if (item != null)
				{
					pb.Value = item.GetValue(des.DataNumber);
					if (des.HasComplededFlag)
					{
						cb.Checked = item.GetValue(des.CompletedDataNumber) != 0;
					}
				}
				else
				{
					lb.Text = des.ToString();
				}

				Enabled = true;
			}
			else
			{
				Enabled = false;
			}

			SetVisible();
			inter = false;
		}

		private void vds_SelectedDescriptorChanged(object sender, EventArgs e)
		{
			NgbhValueDescriptor = vds.SelectedDescriptor;
		}

		private void pb_Resize(object sender, EventArgs e)
		{
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			pb.TokenCount = 10;
		}

		public event EventHandler AddedNewItem;
		public event EventHandler ChangedItem;

		private void ll_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (item != null)
			{
				return;
			}

			if (slot == null)
			{
				return;
			}

			if (des == null)
			{
				return;
			}

			if (des.Intern)
			{
				item = slot.ItemsA.AddNew(SimMemoryType.Skill);
			}
			else
			{
				item = slot.ItemsB.AddNew(SimMemoryType.Skill);
			}

			item.Guid = des.Guid;
			item.PutValue(des.DataNumber, 0);
			if (des.HasComplededFlag)
			{
				item.PutValue(des.CompletedDataNumber, 0);
			}

			SetContent();

			if (AddedNewItem != null)
			{
				AddedNewItem(this, new EventArgs());
			}
		}

		private void cb_CheckedChanged(object sender, EventArgs e)
		{
			if (inter)
			{
				return;
			}

			if (item == null)
			{
				return;
			}

			if (des == null)
			{
				return;
			}

			if (!des.HasComplededFlag)
			{
				return;
			}

			if (cb.Checked)
			{
				item.PutValue(des.CompletedDataNumber, 1);
			}
			else
			{
				item.PutValue(des.CompletedDataNumber, 0);
			}

			if (ChangedItem != null)
			{
				ChangedItem(this, new EventArgs());
			}
		}

		private void pb_Changed(object sender, EventArgs e)
		{
			if (inter)
			{
				return;
			}

			if (item == null)
			{
				return;
			}

			if (des == null)
			{
				return;
			}

			item.PutValue(des.DataNumber, (ushort)pb.Value);

			if (ChangedItem != null)
			{
				ChangedItem(this, new EventArgs());
			}
		}

		private void pb_Load(object sender, EventArgs e)
		{
		}
	}
}
