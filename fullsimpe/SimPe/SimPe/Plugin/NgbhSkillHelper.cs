using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for NgbhSkillHelper.
	/// </summary>
	[System.ComponentModel.DefaultEvent("AddedNewItem")]
	public class NgbhSkillHelper : UserControl
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		ThemeManager tm;

		public NgbhSkillHelper()
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
				tm = ThemeManager.Global.CreateChild();
				tm.AddControl(xpBadges);
				tm.AddControl(xpSkills);

				xpBadges.Visible =
					PathProvider.Global.EPInstalled >= 3
					|| PathProvider.Global.STInstalled >= 28
				;
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
				if (tm != null)
				{
					tm.Clear();
					tm.Parent = null;
					tm = null;
				}

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
			System.Resources.ResourceManager resources =
				new System.Resources.ResourceManager(typeof(NgbhSkillHelper));
			badges = new NgbhSkillHelperElement();
			xpBadges = new Ambertation.Windows.Forms.XPTaskBoxSimple();
			xpSkills = new Ambertation.Windows.Forms.XPTaskBoxSimple();
			skills = new NgbhSkillHelperElement();
			xpBadges.SuspendLayout();
			xpSkills.SuspendLayout();
			SuspendLayout();
			//
			// badges
			//
			badges.AccessibleDescription = resources.GetString(
				"badges.AccessibleDescription"
			);
			badges.AccessibleName = resources.GetString("badges.AccessibleName");
			badges.Anchor =
				(AnchorStyles)
					resources.GetObject("badges.Anchor")

			;
			badges.AutoScroll = (bool)resources.GetObject("badges.AutoScroll");
			badges.AutoScrollMargin =
				(Size)resources.GetObject("badges.AutoScrollMargin")
			;
			badges.AutoScrollMinSize =
				(Size)resources.GetObject("badges.AutoScrollMinSize")
			;
			badges.BackgroundImage =
				(Image)resources.GetObject("badges.BackgroundImage")
			;
			badges.Dock =
				(DockStyle)resources.GetObject("badges.Dock")
			;
			badges.Enabled = (bool)resources.GetObject("badges.Enabled");
			badges.Font =
				(Font)resources.GetObject("badges.Font")
			;
			badges.ImeMode =
				(ImeMode)resources.GetObject("badges.ImeMode")
			;
			badges.Location =
				(Point)resources.GetObject("badges.Location")
			;
			badges.Name = "badges";
			badges.NgbhResource = null;
			badges.RightToLeft =
				(RightToLeft)
					resources.GetObject("badges.RightToLeft")

			;
			badges.ShowBadges = true;
			badges.ShowSkills = false;
			badges.ShowToddlerSkills = false;
			badges.Size =
				(Size)resources.GetObject("badges.Size")
			;
			badges.Slot = null;
			badges.TabIndex = (int)resources.GetObject("badges.TabIndex");
			badges.Visible = (bool)resources.GetObject("badges.Visible");
			badges.AddedNewItem += new EventHandler(
				skills_AddedNewItem
			);
			badges.ChangedItem += new EventHandler(skills_ChangedItem);
			//
			// xpBadges
			//
			xpBadges.AccessibleDescription = resources.GetString(
				"xpBadges.AccessibleDescription"
			);
			xpBadges.AccessibleName = resources.GetString(
				"xpBadges.AccessibleName"
			);
			xpBadges.Anchor =
				(AnchorStyles)
					resources.GetObject("xpBadges.Anchor")

			;
			xpBadges.AutoScroll =
				(bool)resources.GetObject("xpBadges.AutoScroll")
			;
			xpBadges.AutoScrollMargin =
				(Size)resources.GetObject("xpBadges.AutoScrollMargin")
			;
			xpBadges.AutoScrollMinSize =
				(Size)resources.GetObject("xpBadges.AutoScrollMinSize")
			;
			xpBadges.BackColor = Color.Transparent;
			xpBadges.BackgroundImage =
				(Image)resources.GetObject("xpBadges.BackgroundImage")
			;
			xpBadges.BodyColor = SystemColors.InactiveCaptionText;
			xpBadges.BorderColor = SystemColors.Window;
			xpBadges.Controls.Add(badges);
			xpBadges.Dock =
				(DockStyle)resources.GetObject("xpBadges.Dock")
			;
			xpBadges.DockPadding.Bottom = 4;
			xpBadges.DockPadding.Left = 4;
			xpBadges.DockPadding.Right = 4;
			xpBadges.DockPadding.Top = 44;
			xpBadges.Enabled = (bool)resources.GetObject("xpBadges.Enabled");
			xpBadges.Font =
				(Font)resources.GetObject("xpBadges.Font")
			;
			xpBadges.HeaderFont = new Font(
				"Microsoft Sans Serif",
				10.25F,
				FontStyle.Bold
			);
			xpBadges.HeaderText = resources.GetString("xpBadges.HeaderText");
			xpBadges.HeaderTextColor = SystemColors.ControlText;
			xpBadges.Icon =
				(Image)resources.GetObject("xpBadges.Icon")
			;
			xpBadges.IconLocation = new Point(4, 0);
			xpBadges.IconSize = new Size(48, 48);
			xpBadges.ImeMode =
				(ImeMode)resources.GetObject("xpBadges.ImeMode")
			;
			xpBadges.LeftHeaderColor = SystemColors.ControlDark;
			xpBadges.Location =
				(Point)resources.GetObject("xpBadges.Location")
			;
			xpBadges.Name = "xpBadges";
			xpBadges.RightHeaderColor = SystemColors.ControlDark;
			xpBadges.RightToLeft =
				(RightToLeft)
					resources.GetObject("xpBadges.RightToLeft")

			;
			xpBadges.Size =
				(Size)resources.GetObject("xpBadges.Size")
			;
			xpBadges.TabIndex = (int)resources.GetObject("xpBadges.TabIndex");
			xpBadges.Text = resources.GetString("xpBadges.Text");
			xpBadges.Visible = (bool)resources.GetObject("xpBadges.Visible");
			//
			// xpSkills
			//
			xpSkills.AccessibleDescription = resources.GetString(
				"xpSkills.AccessibleDescription"
			);
			xpSkills.AccessibleName = resources.GetString(
				"xpSkills.AccessibleName"
			);
			xpSkills.Anchor =
				(AnchorStyles)
					resources.GetObject("xpSkills.Anchor")

			;
			xpSkills.AutoScroll =
				(bool)resources.GetObject("xpSkills.AutoScroll")
			;
			xpSkills.AutoScrollMargin =
				(Size)resources.GetObject("xpSkills.AutoScrollMargin")
			;
			xpSkills.AutoScrollMinSize =
				(Size)resources.GetObject("xpSkills.AutoScrollMinSize")
			;
			xpSkills.BackColor = Color.Transparent;
			xpSkills.BackgroundImage =
				(Image)resources.GetObject("xpSkills.BackgroundImage")
			;
			xpSkills.BodyColor = SystemColors.ControlLight;
			xpSkills.BorderColor = SystemColors.ControlDarkDark;
			xpSkills.Controls.Add(skills);
			xpSkills.Dock =
				(DockStyle)resources.GetObject("xpSkills.Dock")
			;
			xpSkills.DockPadding.Bottom = 4;
			xpSkills.DockPadding.Left = 4;
			xpSkills.DockPadding.Right = 4;
			xpSkills.DockPadding.Top = 44;
			xpSkills.Enabled = (bool)resources.GetObject("xpSkills.Enabled");
			xpSkills.Font =
				(Font)resources.GetObject("xpSkills.Font")
			;
			xpSkills.HeaderFont = new Font(
				"Microsoft Sans Serif",
				10.25F,
				FontStyle.Bold
			);
			xpSkills.HeaderText = resources.GetString("xpSkills.HeaderText");
			xpSkills.HeaderTextColor = SystemColors.ControlText;
			xpSkills.Icon =
				(Image)resources.GetObject("xpSkills.Icon")
			;
			xpSkills.IconLocation = new Point(4, 0);
			xpSkills.IconSize = new Size(48, 48);
			xpSkills.ImeMode =
				(ImeMode)resources.GetObject("xpSkills.ImeMode")
			;
			xpSkills.LeftHeaderColor = SystemColors.ControlDark;
			xpSkills.Location =
				(Point)resources.GetObject("xpSkills.Location")
			;
			xpSkills.Name = "xpSkills";
			xpSkills.RightHeaderColor = SystemColors.ControlDark;
			xpSkills.RightToLeft =
				(RightToLeft)
					resources.GetObject("xpSkills.RightToLeft")

			;
			xpSkills.Size =
				(Size)resources.GetObject("xpSkills.Size")
			;
			xpSkills.TabIndex = (int)resources.GetObject("xpSkills.TabIndex");
			xpSkills.Text = resources.GetString("xpSkills.Text");
			xpSkills.Visible = (bool)resources.GetObject("xpSkills.Visible");
			//
			// skills
			//
			skills.AccessibleDescription = resources.GetString(
				"skills.AccessibleDescription"
			);
			skills.AccessibleName = resources.GetString("skills.AccessibleName");
			skills.Anchor =
				(AnchorStyles)
					resources.GetObject("skills.Anchor")

			;
			skills.AutoScroll = (bool)resources.GetObject("skills.AutoScroll");
			skills.AutoScrollMargin =
				(Size)resources.GetObject("skills.AutoScrollMargin")
			;
			skills.AutoScrollMinSize =
				(Size)resources.GetObject("skills.AutoScrollMinSize")
			;
			skills.BackgroundImage =
				(Image)resources.GetObject("skills.BackgroundImage")
			;
			skills.Dock =
				(DockStyle)resources.GetObject("skills.Dock")
			;
			skills.Enabled = (bool)resources.GetObject("skills.Enabled");
			skills.Font =
				(Font)resources.GetObject("skills.Font")
			;
			skills.ImeMode =
				(ImeMode)resources.GetObject("skills.ImeMode")
			;
			skills.Location =
				(Point)resources.GetObject("skills.Location")
			;
			skills.Name = "skills";
			skills.NgbhResource = null;
			skills.RightToLeft =
				(RightToLeft)
					resources.GetObject("skills.RightToLeft")

			;
			skills.ShowBadges = false;
			skills.ShowSkills = true;
			skills.ShowToddlerSkills = true;
			skills.Size =
				(Size)resources.GetObject("skills.Size")
			;
			skills.Slot = null;
			skills.TabIndex = (int)resources.GetObject("skills.TabIndex");
			skills.Visible = (bool)resources.GetObject("skills.Visible");
			skills.AddedNewItem += new EventHandler(
				skills_AddedNewItem
			);
			skills.ChangedItem += new EventHandler(skills_ChangedItem);
			//
			// NgbhSkillHelper
			//
			AccessibleDescription = resources.GetString(
				"$this.AccessibleDescription"
			);
			AccessibleName = resources.GetString("$this.AccessibleName");
			AutoScroll = (bool)resources.GetObject("$this.AutoScroll");
			AutoScrollMargin =
				(Size)resources.GetObject("$this.AutoScrollMargin")
			;
			AutoScrollMinSize =
				(Size)resources.GetObject("$this.AutoScrollMinSize")
			;
			BackgroundImage =
				(Image)resources.GetObject("$this.BackgroundImage")
			;
			Controls.Add(xpSkills);
			Controls.Add(xpBadges);
			DockPadding.All = 8;
			Enabled = (bool)resources.GetObject("$this.Enabled");
			Font = (Font)resources.GetObject("$this.Font");
			ImeMode =
				(ImeMode)resources.GetObject("$this.ImeMode")
			;
			Location =
				(Point)resources.GetObject("$this.Location")
			;
			Name = "NgbhSkillHelper";
			RightToLeft =
				(RightToLeft)
					resources.GetObject("$this.RightToLeft")

			;
			Size = (Size)resources.GetObject("$this.Size");
			xpBadges.ResumeLayout(false);
			xpSkills.ResumeLayout(false);
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

		Ngbh ngbh;
		private NgbhSkillHelperElement badges;
		private NgbhSkillHelperElement skills;
		private Ambertation.Windows.Forms.XPTaskBoxSimple xpBadges;
		private Ambertation.Windows.Forms.XPTaskBoxSimple xpSkills;

		[System.ComponentModel.Browsable(false)]
		public Ngbh NgbhResource
		{
			get => ngbh;
			set
			{
				ngbh = value;
				pc_SelectedSimChanged(pc, null, null);
				SetContent();
			}
		}

		PackedFiles.Wrapper.SimPoolControl pc;
		public PackedFiles.Wrapper.SimPoolControl SimPoolControl
		{
			get => pc;
			set
			{
				if (pc != null)
				{
					pc.SelectedSimChanged -=
						new PackedFiles.Wrapper.SimPoolControl.SelectedSimHandler(
							pc_SelectedSimChanged
						);
				}

				pc = value;

				if (pc != null)
				{
					pc.SelectedSimChanged +=
						new PackedFiles.Wrapper.SimPoolControl.SelectedSimHandler(
							pc_SelectedSimChanged
						);
					pc_SelectedSimChanged(pc, null, null);
				}
			}
		}

		void SetContent()
		{
			badges.Slot = slot;
			skills.Slot = slot;

			if (pc != null)
			{
				if (pc.SelectedSim != null)
				{
					SetImage(pc.SelectedSim.Image);
				}
				else
				{
					SetImage(new Bitmap(1, 1));
				}
			}
		}

		void SetImage(Image img)
		{
			img = Ambertation.Drawing.GraphicRoutines.KnockoutImage(
				img,
				new Point(0),
				Color.Transparent,
				true
			);
			img = Ambertation.Drawing.GraphicRoutines.ScaleImage(img, 48, 48, true);

			xpBadges.Icon = img;
			xpSkills.Icon = img;
		}

		private void pc_SelectedSimChanged(
			object sender,
			Image thumb,
			PackedFiles.Wrapper.SDesc sdesc
		)
		{
			if (ngbh != null && pc != null)
			{
				if (pc.SelectedSim != null)
				{
					Slot = ngbh.GetSlots(Data.NeighborhoodSlots.SimsIntern)
						.GetInstanceSlot(pc.SelectedSim.FileDescriptor.Instance);
					SetImage(pc.SelectedSim.Image);
				}
				else
				{
					Slot = null;
				}
			}
		}

		private void skills_AddedNewItem(object sender, EventArgs e)
		{
			if (AddedNewItem != null)
			{
				AddedNewItem(this, e);
			}
		}

		private void skills_ChangedItem(object sender, EventArgs e)
		{
			if (ChangedItem != null)
			{
				ChangedItem(this, e);
			}
		}

		public event EventHandler AddedNewItem;
		public event EventHandler ChangedItem;
	}
}
