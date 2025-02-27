using System;
using System.Windows.Forms;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for NgbhSlotListView.
	/// </summary>
	[System.ComponentModel.DefaultEvent("SelectedSlotChanged")]
	public class NgbhSlotListView : UserControl
	{
		private ListView lv;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NgbhSlotListView()
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
			this.lv = new ListView();
			this.SuspendLayout();
			//
			// lv
			//
			this.lv.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lv.HideSelection = false;
			this.lv.Location = new System.Drawing.Point(1, 1);
			this.lv.MultiSelect = false;
			this.lv.Name = "lv";
			this.lv.Size = new System.Drawing.Size(270, 166);
			this.lv.TabIndex = 1;
			this.lv.View = System.Windows.Forms.View.List;
			this.lv.SelectedIndexChanged += new EventHandler(
				this.lv_SelectedIndexChanged
			);
			//
			// NgbhSlotListView
			//
			this.Controls.Add(this.lv);
			this.DockPadding.All = 1;
			this.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.Name = "NgbhSlotListView";
			this.Size = new System.Drawing.Size(272, 168);
			this.ResumeLayout(false);
		}
		#endregion

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

		Collections.NgbhSlots slots;

		[System.ComponentModel.Browsable(false)]
		public Collections.NgbhSlots Slots
		{
			get
			{
				return slots;
			}
			set
			{
				slots = value;
				SetContent();
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

		Data.NeighborhoodSlots st;
		public Data.NeighborhoodSlots SlotType
		{
			get
			{
				return st;
			}
			set
			{
				if (st != value)
				{
					st = value;
					if (ngbh != null)
					{
						Slots = ngbh.GetSlots(st);
					}
				}
			}
		}

		void SetContent()
		{
			this.lv.BeginUpdate();
			this.lv.Items.Clear();
			if (slots != null)
			{
				foreach (NgbhSlot s in slots)
				{
					ListViewItem lvi = new ListViewItem();
					lvi.Text = s.ToString();
					lvi.Tag = s;

					lv.Items.Add(lvi);
				}
			}
			this.lv.EndUpdate();
		}

		private void lv_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (SelectedSlotChanged != null)
			{
				SelectedSlotChanged(this, e);
			}
		}

		public NgbhSlot SelectedSlot
		{
			get
			{
				if (lv.SelectedItems.Count == 0)
				{
					return null;
				}

				return lv.SelectedItems[0].Tag as NgbhSlot;
			}
		}

		public event EventHandler SelectedSlotChanged;
	}
}
