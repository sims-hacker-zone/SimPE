using System.Windows.Forms;

namespace SimPe
{
	/// <summary>
	/// Summary description for CheckItem.
	/// </summary>
	[System.ComponentModel.DefaultEvent("ClickedFix")]
	public class CheckItem : UserControl
	{
		public delegate CheckItemState FixEventHandler(
			object sender,
			CheckItemState isok
		);
		private LinkLabel llfix;
		private Label lb;
		private PictureBox pb;
		private LinkLabel lldet;
		private Panel pnDetails;
		private LinkLabel linkLabel1;
		private RichTextBox rtb;

		//private System.ComponentModel.IContainer components;

		public CheckItem()
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

			cs = CheckItemState.Unknown;
			txt = "--";
			cf = false;
			det = "";
			pnDetails.Visible = false;
			SetContent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/*protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}*/

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources =
				new System.Resources.ResourceManager(typeof(CheckItem));
			lb = new Label();
			llfix = new LinkLabel();
			pb = new PictureBox();
			lldet = new LinkLabel();
			pnDetails = new Panel();
			linkLabel1 = new LinkLabel();
			rtb = new RichTextBox();
			pnDetails.SuspendLayout();
			SuspendLayout();
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
			// llfix
			//
			llfix.AccessibleDescription = resources.GetString(
				"llfix.AccessibleDescription"
			);
			llfix.AccessibleName = resources.GetString("llfix.AccessibleName");
			llfix.Anchor = (
				(AnchorStyles)(resources.GetObject("llfix.Anchor"))
			);
			llfix.AutoSize = ((bool)(resources.GetObject("llfix.AutoSize")));
			llfix.Dock = (
				(DockStyle)(resources.GetObject("llfix.Dock"))
			);
			llfix.Enabled = ((bool)(resources.GetObject("llfix.Enabled")));
			llfix.Font = (
				(System.Drawing.Font)(resources.GetObject("llfix.Font"))
			);
			llfix.Image = (
				(System.Drawing.Image)(resources.GetObject("llfix.Image"))
			);
			llfix.ImageAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("llfix.ImageAlign")
				)
			);
			llfix.ImageIndex = ((int)(resources.GetObject("llfix.ImageIndex")));
			llfix.ImeMode = (
				(ImeMode)(resources.GetObject("llfix.ImeMode"))
			);
			llfix.LinkArea = (
				(LinkArea)(resources.GetObject("llfix.LinkArea"))
			);
			llfix.Location = (
				(System.Drawing.Point)(resources.GetObject("llfix.Location"))
			);
			llfix.Name = "llfix";
			llfix.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("llfix.RightToLeft")
				)
			);
			llfix.Size = (
				(System.Drawing.Size)(resources.GetObject("llfix.Size"))
			);
			llfix.TabIndex = ((int)(resources.GetObject("llfix.TabIndex")));
			llfix.TabStop = true;
			llfix.Text = resources.GetString("llfix.Text");
			llfix.TextAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("llfix.TextAlign")
				)
			);
			llfix.Visible = ((bool)(resources.GetObject("llfix.Visible")));
			llfix.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					llfix_LinkClicked
				);
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
			pb.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("pb.BackgroundImage"))
			);
			pb.Dock = (
				(DockStyle)(resources.GetObject("pb.Dock"))
			);
			pb.Enabled = ((bool)(resources.GetObject("pb.Enabled")));
			pb.Font = ((System.Drawing.Font)(resources.GetObject("pb.Font")));
			pb.Image = ((System.Drawing.Image)(resources.GetObject("pb.Image")));
			pb.ImeMode = (
				(ImeMode)(resources.GetObject("pb.ImeMode"))
			);
			pb.Location = (
				(System.Drawing.Point)(resources.GetObject("pb.Location"))
			);
			pb.Name = "pb";
			pb.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("pb.RightToLeft")
				)
			);
			pb.Size = ((System.Drawing.Size)(resources.GetObject("pb.Size")));
			pb.SizeMode = (
				(PictureBoxSizeMode)(
					resources.GetObject("pb.SizeMode")
				)
			);
			pb.TabIndex = ((int)(resources.GetObject("pb.TabIndex")));
			pb.TabStop = false;
			pb.Text = resources.GetString("pb.Text");
			pb.Visible = ((bool)(resources.GetObject("pb.Visible")));
			//
			// lldet
			//
			lldet.AccessibleDescription = resources.GetString(
				"lldet.AccessibleDescription"
			);
			lldet.AccessibleName = resources.GetString("lldet.AccessibleName");
			lldet.Anchor = (
				(AnchorStyles)(resources.GetObject("lldet.Anchor"))
			);
			lldet.AutoSize = ((bool)(resources.GetObject("lldet.AutoSize")));
			lldet.Dock = (
				(DockStyle)(resources.GetObject("lldet.Dock"))
			);
			lldet.Enabled = ((bool)(resources.GetObject("lldet.Enabled")));
			lldet.Font = (
				(System.Drawing.Font)(resources.GetObject("lldet.Font"))
			);
			lldet.Image = (
				(System.Drawing.Image)(resources.GetObject("lldet.Image"))
			);
			lldet.ImageAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("lldet.ImageAlign")
				)
			);
			lldet.ImageIndex = ((int)(resources.GetObject("lldet.ImageIndex")));
			lldet.ImeMode = (
				(ImeMode)(resources.GetObject("lldet.ImeMode"))
			);
			lldet.LinkArea = (
				(LinkArea)(resources.GetObject("lldet.LinkArea"))
			);
			lldet.Location = (
				(System.Drawing.Point)(resources.GetObject("lldet.Location"))
			);
			lldet.Name = "lldet";
			lldet.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("lldet.RightToLeft")
				)
			);
			lldet.Size = (
				(System.Drawing.Size)(resources.GetObject("lldet.Size"))
			);
			lldet.TabIndex = ((int)(resources.GetObject("lldet.TabIndex")));
			lldet.TabStop = true;
			lldet.Text = resources.GetString("lldet.Text");
			lldet.TextAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("lldet.TextAlign")
				)
			);
			lldet.Visible = ((bool)(resources.GetObject("lldet.Visible")));
			lldet.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					lldet_LinkClicked
				);
			//
			// pnDetails
			//
			pnDetails.AccessibleDescription = resources.GetString(
				"pnDetails.AccessibleDescription"
			);
			pnDetails.AccessibleName = resources.GetString(
				"pnDetails.AccessibleName"
			);
			pnDetails.Anchor = (
				(AnchorStyles)(
					resources.GetObject("pnDetails.Anchor")
				)
			);
			pnDetails.AutoScroll = (
				(bool)(resources.GetObject("pnDetails.AutoScroll"))
			);
			pnDetails.AutoScrollMargin = (
				(System.Drawing.Size)(resources.GetObject("pnDetails.AutoScrollMargin"))
			);
			pnDetails.AutoScrollMinSize = (
				(System.Drawing.Size)(
					resources.GetObject("pnDetails.AutoScrollMinSize")
				)
			);
			pnDetails.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("pnDetails.BackgroundImage"))
			);
			pnDetails.Controls.Add(linkLabel1);
			pnDetails.Controls.Add(rtb);
			pnDetails.Dock = (
				(DockStyle)(resources.GetObject("pnDetails.Dock"))
			);
			pnDetails.Enabled = ((bool)(resources.GetObject("pnDetails.Enabled")));
			pnDetails.Font = (
				(System.Drawing.Font)(resources.GetObject("pnDetails.Font"))
			);
			pnDetails.ImeMode = (
				(ImeMode)(resources.GetObject("pnDetails.ImeMode"))
			);
			pnDetails.Location = (
				(System.Drawing.Point)(resources.GetObject("pnDetails.Location"))
			);
			pnDetails.Name = "pnDetails";
			pnDetails.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("pnDetails.RightToLeft")
				)
			);
			pnDetails.Size = (
				(System.Drawing.Size)(resources.GetObject("pnDetails.Size"))
			);
			pnDetails.TabIndex = (
				(int)(resources.GetObject("pnDetails.TabIndex"))
			);
			pnDetails.Text = resources.GetString("pnDetails.Text");
			pnDetails.Visible = ((bool)(resources.GetObject("pnDetails.Visible")));
			//
			// linkLabel1
			//
			linkLabel1.AccessibleDescription = resources.GetString(
				"linkLabel1.AccessibleDescription"
			);
			linkLabel1.AccessibleName = resources.GetString(
				"linkLabel1.AccessibleName"
			);
			linkLabel1.Anchor = (
				(AnchorStyles)(
					resources.GetObject("linkLabel1.Anchor")
				)
			);
			linkLabel1.AutoSize = (
				(bool)(resources.GetObject("linkLabel1.AutoSize"))
			);
			linkLabel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			linkLabel1.Dock = (
				(DockStyle)(resources.GetObject("linkLabel1.Dock"))
			);
			linkLabel1.Enabled = (
				(bool)(resources.GetObject("linkLabel1.Enabled"))
			);
			linkLabel1.Font = (
				(System.Drawing.Font)(resources.GetObject("linkLabel1.Font"))
			);
			linkLabel1.Image = (
				(System.Drawing.Image)(resources.GetObject("linkLabel1.Image"))
			);
			linkLabel1.ImageAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("linkLabel1.ImageAlign")
				)
			);
			linkLabel1.ImageIndex = (
				(int)(resources.GetObject("linkLabel1.ImageIndex"))
			);
			linkLabel1.ImeMode = (
				(ImeMode)(
					resources.GetObject("linkLabel1.ImeMode")
				)
			);
			linkLabel1.LinkArea = (
				(LinkArea)(
					resources.GetObject("linkLabel1.LinkArea")
				)
			);
			linkLabel1.Location = (
				(System.Drawing.Point)(resources.GetObject("linkLabel1.Location"))
			);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("linkLabel1.RightToLeft")
				)
			);
			linkLabel1.Size = (
				(System.Drawing.Size)(resources.GetObject("linkLabel1.Size"))
			);
			linkLabel1.TabIndex = (
				(int)(resources.GetObject("linkLabel1.TabIndex"))
			);
			linkLabel1.TabStop = true;
			linkLabel1.Text = resources.GetString("linkLabel1.Text");
			linkLabel1.TextAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("linkLabel1.TextAlign")
				)
			);
			linkLabel1.Visible = (
				(bool)(resources.GetObject("linkLabel1.Visible"))
			);
			linkLabel1.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					linkLabel1_LinkClicked
				);
			//
			// rtb
			//
			rtb.AccessibleDescription = resources.GetString(
				"rtb.AccessibleDescription"
			);
			rtb.AccessibleName = resources.GetString("rtb.AccessibleName");
			rtb.Anchor = (
				(AnchorStyles)(resources.GetObject("rtb.Anchor"))
			);
			rtb.AutoSize = ((bool)(resources.GetObject("rtb.AutoSize")));
			rtb.BackColor = System.Drawing.SystemColors.ControlLightLight;
			rtb.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("rtb.BackgroundImage"))
			);
			rtb.BorderStyle = BorderStyle.None;
			rtb.BulletIndent = ((int)(resources.GetObject("rtb.BulletIndent")));
			rtb.Cursor = Cursors.Default;
			rtb.Dock = (
				(DockStyle)(resources.GetObject("rtb.Dock"))
			);
			rtb.Enabled = ((bool)(resources.GetObject("rtb.Enabled")));
			rtb.Font = ((System.Drawing.Font)(resources.GetObject("rtb.Font")));
			rtb.ForeColor = System.Drawing.SystemColors.AppWorkspace;
			rtb.ImeMode = (
				(ImeMode)(resources.GetObject("rtb.ImeMode"))
			);
			rtb.Location = (
				(System.Drawing.Point)(resources.GetObject("rtb.Location"))
			);
			rtb.MaxLength = ((int)(resources.GetObject("rtb.MaxLength")));
			rtb.Multiline = ((bool)(resources.GetObject("rtb.Multiline")));
			rtb.Name = "rtb";
			rtb.ReadOnly = true;
			rtb.RightMargin = ((int)(resources.GetObject("rtb.RightMargin")));
			rtb.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("rtb.RightToLeft")
				)
			);
			rtb.ScrollBars = (
				(RichTextBoxScrollBars)(
					resources.GetObject("rtb.ScrollBars")
				)
			);
			rtb.Size = ((System.Drawing.Size)(resources.GetObject("rtb.Size")));
			rtb.TabIndex = ((int)(resources.GetObject("rtb.TabIndex")));
			rtb.Text = resources.GetString("rtb.Text");
			rtb.Visible = ((bool)(resources.GetObject("rtb.Visible")));
			rtb.WordWrap = ((bool)(resources.GetObject("rtb.WordWrap")));
			rtb.ZoomFactor = (
				(System.Single)(resources.GetObject("rtb.ZoomFactor"))
			);
			//
			// CheckItem
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
			Controls.Add(pnDetails);
			Controls.Add(lb);
			Controls.Add(pb);
			Controls.Add(llfix);
			Controls.Add(lldet);
			Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
			ImeMode = (
				(ImeMode)(resources.GetObject("$this.ImeMode"))
			);
			Location = (
				(System.Drawing.Point)(resources.GetObject("$this.Location"))
			);
			Name = "CheckItem";
			RightToLeft = (
				(RightToLeft)(
					resources.GetObject("$this.RightToLeft")
				)
			);
			Size = ((System.Drawing.Size)(resources.GetObject("$this.Size")));
			pnDetails.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion

		bool cf;
		public bool CanFix
		{
			get => cf;
			set
			{
				if (cf != value)
				{
					cf = value;
					SetContent();
				}
			}
		}

		string txt;

		[System.ComponentModel.Localizable(true)]
		public string Caption
		{
			get => txt;
			set
			{
				txt = value;
				SetContent();
			}
		}

		CheckItemState cs;
		public CheckItemState CheckState
		{
			get => cs;
			set
			{
				cs = value;
				pb.Image = cs == CheckItemState.Fail
					? CheckControl.FailImage
					: cs == CheckItemState.Ok
						? CheckControl.OKImage
						: cs == CheckItemState.Warning ? CheckControl.WarnImage : CheckControl.UnknownImage;

				SetContent();
			}
		}

		string det;
		public string Details
		{
			get => det;
			set
			{
				det = value;
				SetContent();
			}
		}

		protected virtual void SetContent()
		{
			rtb.Text = det;
			lldet.Visible = det.Trim() != "";
			lb.Text = txt;
			llfix.Visible = cs == CheckItemState.Fail && cf;
			Refresh();
		}

		protected virtual void OnFix()
		{
		}

		public void Reset()
		{
			pnDetails.Visible = false;
			CheckState = CheckItemState.Unknown;
			det = "";
			SetContent();
		}

		public event FixEventHandler CalledCheck;

		protected virtual CheckItemState OnCheck()
		{
			return CheckItemState.Ok;
		}

		public void Check()
		{
			CheckItemState res = OnCheck();
			if (CalledCheck != null)
			{
				res = CalledCheck(this, res);
			}

			CheckState = res;
		}

		public event FixEventHandler ClickedFix;

		private void llfix_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			CheckItemState res = CheckState;
			OnFix();
			if (ClickedFix != null)
			{
				res = ClickedFix(this, res);
			}

			CheckState = res;
		}

		private void lldet_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			pnDetails.Visible = true;
		}

		private void linkLabel1_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			pnDetails.Visible = false;
		}
	}
}
