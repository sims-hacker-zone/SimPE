using System;
using System.Windows.Forms;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for NgbhSkillHelperElement.
	/// </summary>
	[System.ComponentModel.DefaultEvent("AddedNewItem")]
	public class NgbhSkillHelperElement : UserControl
	{
		private NgbhValueDescriptorSelection cb;
		private NgbhValueDescriptorUI ui;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NgbhSkillHelperElement()
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

			ShowToddlerSkills = true;
			ShowSkills = true;
			ShowBadges = true;
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
			cb = new NgbhValueDescriptorSelection();
			ui = new NgbhValueDescriptorUI();
			SuspendLayout();
			//
			// cb
			//
			cb.Dock = DockStyle.Top;
			cb.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cb.Location = new System.Drawing.Point(0, 0);
			cb.Name = "cb";
			cb.ShowBadges = true;
			cb.ShowSkills = true;
			cb.ShowToddlerSkills = true;
			cb.Size = new System.Drawing.Size(400, 24);
			cb.TabIndex = 0;
			//
			// ui
			//
			ui.Dock = DockStyle.Fill;
			ui.Enabled = false;
			ui.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			ui.Location = new System.Drawing.Point(0, 24);
			ui.Name = "ui";
			ui.NgbhValueDescriptor = null;
			ui.NgbhValueDescriptorSelection = cb;
			ui.Size = new System.Drawing.Size(400, 104);
			ui.Slot = null;
			ui.TabIndex = 1;
			ui.AddedNewItem += new EventHandler(ui_AddedNewItem);
			ui.ChangedItem += new EventHandler(ui_ChangedItem);
			//
			// NgbhSkillHelperElement
			//
			Controls.Add(ui);
			Controls.Add(cb);
			Name = "NgbhSkillHelperElement";
			Size = new System.Drawing.Size(400, 128);
			ResumeLayout(false);
		}
		#endregion

		bool badge,
			skill,
			tskill;
		public bool ShowBadges
		{
			get => badge;
			set
			{
				if (badge != value)
				{
					badge = value;
					cb.ShowBadges = value;
					SetContent();
				}
			}
		}
		public bool ShowSkills
		{
			get => skill;
			set
			{
				if (skill != value)
				{
					skill = value;
					cb.ShowSkills = value;
					SetContent();
				}
			}
		}
		public bool ShowToddlerSkills
		{
			get => tskill;
			set
			{
				if (tskill != value)
				{
					tskill = value;
					cb.ShowToddlerSkills = value;
					SetContent();
				}
			}
		}

		Ngbh ngbh;

		[System.ComponentModel.Browsable(false)]
		public Ngbh NgbhResource
		{
			get => ngbh;
			set
			{
				ngbh = value;
				SetContent();
			}
		}

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

		void SetContent()
		{
			ui.Slot = slot;
		}

		private void ui_AddedNewItem(object sender, EventArgs e)
		{
			if (AddedNewItem != null)
			{
				AddedNewItem(this, e);
			}
		}

		private void ui_ChangedItem(object sender, EventArgs e)
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
