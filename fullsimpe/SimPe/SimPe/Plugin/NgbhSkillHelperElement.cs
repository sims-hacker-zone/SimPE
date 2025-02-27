using System;
using System.Windows.Forms;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for NgbhSkillHelperElement.
	/// </summary>
	[System.ComponentModel.DefaultEvent("AddedNewItem")]
	public class NgbhSkillHelperElement : System.Windows.Forms.UserControl
	{
		private SimPe.Plugin.NgbhValueDescriptorSelection cb;
		private SimPe.Plugin.NgbhValueDescriptorUI ui;

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
			this.cb = new SimPe.Plugin.NgbhValueDescriptorSelection();
			this.ui = new SimPe.Plugin.NgbhValueDescriptorUI();
			this.SuspendLayout();
			//
			// cb
			//
			this.cb.Dock = System.Windows.Forms.DockStyle.Top;
			this.cb.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.cb.Location = new System.Drawing.Point(0, 0);
			this.cb.Name = "cb";
			this.cb.ShowBadges = true;
			this.cb.ShowSkills = true;
			this.cb.ShowToddlerSkills = true;
			this.cb.Size = new System.Drawing.Size(400, 24);
			this.cb.TabIndex = 0;
			//
			// ui
			//
			this.ui.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ui.Enabled = false;
			this.ui.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.ui.Location = new System.Drawing.Point(0, 24);
			this.ui.Name = "ui";
			this.ui.NgbhValueDescriptor = null;
			this.ui.NgbhValueDescriptorSelection = this.cb;
			this.ui.Size = new System.Drawing.Size(400, 104);
			this.ui.Slot = null;
			this.ui.TabIndex = 1;
			this.ui.AddedNewItem += new System.EventHandler(this.ui_AddedNewItem);
			this.ui.ChangedItem += new System.EventHandler(this.ui_ChangedItem);
			//
			// NgbhSkillHelperElement
			//
			this.Controls.Add(this.ui);
			this.Controls.Add(this.cb);
			this.Name = "NgbhSkillHelperElement";
			this.Size = new System.Drawing.Size(400, 128);
			this.ResumeLayout(false);
		}
		#endregion

		bool badge,
			skill,
			tskill;
		public bool ShowBadges
		{
			get
			{
				return badge;
			}
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
			get
			{
				return skill;
			}
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
			get
			{
				return tskill;
			}
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
			get
			{
				return ngbh;
			}
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
			get
			{
				return slot;
			}
			set
			{
				slot = value;
				SetContent();
			}
		}

		void SetContent()
		{
			this.ui.Slot = slot;
		}

		private void ui_AddedNewItem(object sender, System.EventArgs e)
		{
			if (AddedNewItem != null)
			{
				AddedNewItem(this, e);
			}
		}

		private void ui_ChangedItem(object sender, System.EventArgs e)
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
