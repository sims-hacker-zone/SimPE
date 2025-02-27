using System;
using System.Windows.Forms;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for NgbhValueDescriptorSelection.
	/// </summary>
	[System.ComponentModel.DefaultEvent("SelectedDescriptorChanged")]
	public class NgbhValueDescriptorSelection : UserControl
	{
		private ComboBox cb;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NgbhValueDescriptorSelection()
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

			skill = true;
			tskill = true;
			badge = true;

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
			cb = new ComboBox();
			SuspendLayout();
			//
			// cb
			//
			cb.Dock = DockStyle.Top;
			cb.DropDownStyle = ComboBoxStyle.DropDownList;
			cb.Location = new System.Drawing.Point(0, 0);
			cb.Name = "cb";
			cb.Size = new System.Drawing.Size(150, 21);
			cb.TabIndex = 0;
			cb.SelectedIndexChanged += new EventHandler(
				cb_SelectedIndexChanged
			);
			//
			// NgbhValueDescriptorSelection
			//
			Controls.Add(cb);
			Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			Name = "NgbhValueDescriptorSelection";
			Size = new System.Drawing.Size(150, 24);
			ResumeLayout(false);
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
					SetContent();
				}
			}
		}

		void SetContent()
		{
			cb.Items.Clear();
			try
			{
				if (!DesignMode)
				{
					foreach (NgbhValueDescriptor nvd in ExtNgbh.ValueDescriptors)
					{
						if (nvd.Type == NgbhValueDescriptorType.Badge && badge)
						{
							cb.Items.Add(nvd);
						}
						else if (nvd.Type == NgbhValueDescriptorType.Skill && skill)
						{
							cb.Items.Add(nvd);
						}
						else if (
							nvd.Type == NgbhValueDescriptorType.ToddlerSkill
							&& tskill
						)
						{
							cb.Items.Add(nvd);
						}
					}
				}

				if (cb.Items.Count > 0)
				{
					cb.SelectedIndex = 0;
				}
			}
			catch { }
		}

		public NgbhValueDescriptor SelectedDescriptor => cb.SelectedItem as NgbhValueDescriptor;

		public event EventHandler SelectedDescriptorChanged;

		private void cb_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (SelectedDescriptorChanged != null)
			{
				SelectedDescriptorChanged(this, e);
			}
		}
	}
}
