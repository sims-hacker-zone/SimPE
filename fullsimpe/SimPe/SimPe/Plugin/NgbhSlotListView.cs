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
			lv = new ListView();
			SuspendLayout();
			//
			// lv
			//
			lv.BorderStyle = BorderStyle.None;
			lv.Dock = DockStyle.Fill;
			lv.HeaderStyle = ColumnHeaderStyle.Nonclickable;
			lv.HideSelection = false;
			lv.Location = new System.Drawing.Point(1, 1);
			lv.MultiSelect = false;
			lv.Name = "lv";
			lv.Size = new System.Drawing.Size(270, 166);
			lv.TabIndex = 1;
			lv.View = View.List;
			lv.SelectedIndexChanged += new EventHandler(
				lv_SelectedIndexChanged
			);
			//
			// NgbhSlotListView
			//
			Controls.Add(lv);
			DockPadding.All = 1;
			Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			Name = "NgbhSlotListView";
			Size = new System.Drawing.Size(272, 168);
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

		Collections.NgbhSlots slots;

		[System.ComponentModel.Browsable(false)]
		public Collections.NgbhSlots Slots
		{
			get => slots;
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
			get => ngbh;
			set
			{
				ngbh = value;
				SetContent();
			}
		}

		Data.NeighborhoodSlots st;
		public Data.NeighborhoodSlots SlotType
		{
			get => st;
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
			lv.BeginUpdate();
			lv.Items.Clear();
			if (slots != null)
			{
				foreach (NgbhSlot s in slots)
				{
					ListViewItem lvi = new ListViewItem
					{
						Text = s.ToString(),
						Tag = s
					};

					lv.Items.Add(lvi);
				}
			}
			lv.EndUpdate();
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
