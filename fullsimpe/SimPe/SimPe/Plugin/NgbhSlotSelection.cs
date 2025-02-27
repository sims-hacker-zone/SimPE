using System;
using System.Windows.Forms;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for NgbhSlotSelection.
	/// </summary>
	[System.ComponentModel.DefaultEvent("SelectedSlotChanged")]
	public class NgbhSlotSelection : UserControl
	{
		private NgbhSlotListView lv;
		private Ambertation.Windows.Forms.EnumComboBox cb;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NgbhSlotSelection()
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

			cb.Enum = typeof(Data.NeighborhoodSlots);
			cb.ResourceManager = Localization.Manager;
			cb.SelectedIndex = 0;
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
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(
					typeof(NgbhSlotSelection)
				);
			lv = new NgbhSlotListView();
			cb = new Ambertation.Windows.Forms.EnumComboBox();
			SuspendLayout();
			//
			// lv
			//
			resources.ApplyResources(lv, "lv");
			lv.Name = "lv";
			lv.NgbhResource = null;
			lv.Slot = null;
			lv.Slots = null;
			lv.SlotType = Data.NeighborhoodSlots.LotsIntern;
			lv.SelectedSlotChanged += new EventHandler(
				lv_SelectedSlotChanged
			);
			//
			// cb
			//
			resources.ApplyResources(cb, "cb");
			cb.DropDownStyle = ComboBoxStyle.DropDownList;
			cb.Enum = null;
			cb.ForeColor = System.Drawing.SystemColors.ControlText;
			cb.Name = "cb";
			cb.ResourceManager = null;
			cb.SelectedIndexChanged += new EventHandler(
				cb_SelectedIndexChanged
			);
			//
			// NgbhSlotSelection
			//
			Controls.Add(cb);
			Controls.Add(lv);
			resources.ApplyResources(this, "$this");
			Name = "NgbhSlotSelection";
			ResumeLayout(false);
		}
		#endregion

		private void cb_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cb.SelectedIndex >= 0)
			{
				lv.SlotType = SlotType;
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
				lv.NgbhResource = ngbh;
			}
		}

		void SetContent()
		{
			lv.SlotType = SlotType;
		}

		private void lv_SelectedSlotChanged(object sender, EventArgs e)
		{
			if (SelectedSlotChanged != null)
			{
				SelectedSlotChanged(this, e);
			}
		}

		public NgbhSlot SelectedSlot => lv.SelectedSlot;

		public Data.NeighborhoodSlots SlotType
		{
			get
			{
				if (cb.SelectedIndex < 0)
				{
					return Data.NeighborhoodSlots.Lots;
				}

				return (Data.NeighborhoodSlots)cb.SelectedValue;
			}
		}

		public event EventHandler SelectedSlotChanged;
	}
}
