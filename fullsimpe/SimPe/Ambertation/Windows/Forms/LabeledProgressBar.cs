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
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Ambertation.Windows.Forms
{
	/// <summary>
	/// Zusammenfassung für LabledProgressBar.
	/// </summary>
	[ToolboxBitmap(typeof(ProgressBar)), DefaultEvent("ChangedValue")]
	public class LabeledProgressBar : UserControl
	{
		private Panel pntb;
		private Panel pnlb;
		private Panel pn;
		private Label lb;
		private SubExtProgressBar pb;
		private TextBox tb;

		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private Container components = null;

		public LabeledProgressBar()
		{
			SetStyle(
				ControlStyles.SupportsTransparentBackColor
					| ControlStyles.AllPaintingInWmPaint
					|
					//ControlStyles.Opaque |
					ControlStyles.UserPaint
					| ControlStyles.DoubleBuffer,
				true
			);

			BackColor = Color.Transparent;
			ns = 1f;

			internalupdate = false;
			nf = "N0";
			nsu = "";
			npre = "";
			no = 0;
			dno = 0;

			// Dieser Aufruf ist für den Windows Form-Designer erforderlich.
			InitializeComponent();

			pb.TokenCount = 10;
			pb.Maximum = 100;
			pb.Value = 0;
			pb.TabStop = false;
			Update();
		}

		#region Public Properties

		public ProgresBarStyle Style
		{
			get => pb.Style;
			set => pb.Style = value;
		}

		public Color SelectedColor
		{
			get => pb.SelectedColor;
			set => pb.SelectedColor = value;
		}

		public Color UnselectedColor
		{
			get => pb.UnselectedColor;
			set => pb.UnselectedColor = value;
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int TokenWidth => pb.TokenWidth;

		public int TokenCount
		{
			get => pb.TokenCount;
			set => pb.TokenCount = value;
		}

		[Localizable(true)]
		public int TextboxWidth
		{
			get => pntb.Width;
			set => pntb.Width = value;
		}

		[Localizable(true)]
		public string LabelText
		{
			get => lb.Text;
			set => lb.Text = value;
		}

		[Localizable(true)]
		public int LabelWidth
		{
			get => pnlb.Width;
			set => pnlb.Width = value;
		}

		public int Maximum
		{
			get => pb.Maximum;
			set
			{
				pb.Maximum = Math.Max(1, value);
				Update();
			}
		}

		public int Value
		{
			get => pb.Value + NumberOffset;
			set
			{
				pb.Value = value - NumberOffset;
				Update();
			}
		}

		double ns;
		public double NumberScale
		{
			get => ns;
			set
			{
				ns = value;
				if (ns == 0)
				{
					ns = 1;
				}

				Update();
			}
		}

		string nf;
		public string NumberFormat
		{
			get => nf;
			set
			{
				nf = value;
				Update();
			}
		}

		string npre;
		string NumberPrefix
		{
			get => npre;
			set
			{
				npre = value;
				Update();
			}
		}

		string nsu;
		string NumberSuffix
		{
			get => nsu;
			set
			{
				nsu = value;
				Update();
			}
		}

		int no;
		public int NumberOffset
		{
			get => no;
			set
			{
				no = value;
				Update();
			}
		}

		int dno;
		public int DisplayOffset
		{
			get => dno;
			set
			{
				dno = value;
				Update();
			}
		}
		#endregion

		#region Events
		public event EventHandler Changed;
		public event EventHandler ChangedValue;

		protected void FireChangedEvent(bool both)
		{
			if (Changed != null && both)
			{
				Changed(this, new EventArgs());
			}

			if (ChangedValue != null)
			{
				ChangedValue(this, new EventArgs());
			}
		}
		#endregion

		/// <summary>
		/// Die verwendeten Ressourcen bereinigen.
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

		#region von Designer
		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			pn = new Panel();
			pb = new SubExtProgressBar();
			lb = new Label();
			pntb = new Panel();
			tb = new TextBox();
			pnlb = new Panel();
			pn.SuspendLayout();
			pntb.SuspendLayout();
			pnlb.SuspendLayout();
			SuspendLayout();
			//
			// pn
			//
			pn.Controls.Add(pb);
			pn.Dock = DockStyle.Fill;
			pn.DockPadding.Left = 8;
			pn.DockPadding.Right = 4;
			pn.Location = new Point(80, 0);
			pn.Name = "pn";
			pn.Size = new Size(280, 15);
			pn.TabIndex = 0;
			//
			// pb
			//
			pb.BackColor = Color.Transparent;
			pb.BorderColor = Color.FromArgb(
				100,
				0,
				0,
				0
			);
			pb.Dock = DockStyle.Fill;
			pb.Gradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			pb.GradientEndColor = Color.White;
			pb.GradientStartColor = Color.White;
			pb.Location = new Point(8, 0);
			pb.Maximum = 100;
			pb.Minimum = 0;
			pb.Name = "pb";
			pb.ProgressBackColor = SystemColors.Window;
			pb.Quality = true;
			pb.SelectedColor = Color.YellowGreen;
			pb.Size = new Size(268, 15);
			pb.Style = ProgresBarStyle.Flat;
			pb.TabIndex = 0;
			pb.UnselectedColor = Color.Black;
			pb.Value = 0;
			pb.MouseUp += new MouseEventHandler(
				pb_MouseUp
			);
			pb.MouseMove += new MouseEventHandler(
				pb_MouseMove
			);
			pb.MouseDown += new MouseEventHandler(
				pb_MouseDown
			);
			//
			// lb
			//
			lb.Dock = DockStyle.Bottom;
			lb.Font = new Font(
				"Tahoma",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				0
			);
			lb.Location = new Point(0, -8);
			lb.Name = "lb";
			lb.Size = new Size(80, 23);
			lb.TabIndex = 0;
			lb.TextAlign = ContentAlignment.BottomRight;
			//
			// pntb
			//
			pntb.Controls.Add(tb);
			pntb.Dock = DockStyle.Right;
			pntb.Location = new Point(360, 0);
			pntb.Name = "pntb";
			pntb.Size = new Size(40, 15);
			pntb.TabIndex = 1;
			//
			// tb
			//
			tb.BorderStyle = BorderStyle.None;
			tb.Dock = DockStyle.Bottom;
			tb.Location = new Point(0, 1);
			tb.Name = "tb";
			tb.Size = new Size(40, 14);
			tb.TabIndex = 0;
			tb.Text = "";
			tb.TextChanged += new EventHandler(tb_TextChanged);
			//
			// pnlb
			//
			pnlb.Controls.Add(lb);
			pnlb.Dock = DockStyle.Left;
			pnlb.Location = new Point(0, 0);
			pnlb.Name = "pnlb";
			pnlb.Size = new Size(80, 15);
			pnlb.TabIndex = 2;
			//
			// LabeledProgressBar
			//
			Controls.Add(pn);
			Controls.Add(pnlb);
			Controls.Add(pntb);
			DockPadding.Bottom = 5;
			Font = new Font(
				"Tahoma",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			Name = "LabeledProgressBar";
			Size = new Size(400, 20);
			pn.ResumeLayout(false);
			pntb.ResumeLayout(false);
			pnlb.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion

		bool internalupdate;

		public new void Update()
		{
			if (internalupdate)
			{
				return;
			}

			internalupdate = true;
			try
			{
				double disp = Value * ns + dno;
				tb.Text = npre + disp.ToString(nf) + nsu;
			}
			catch { }
			finally
			{
				internalupdate = false;
			}
		}

		protected override void OnVisibleChanged(EventArgs e)
		{
			base.OnVisibleChanged(e);
			pb.Visible = Visible;
		}

		private void tb_TextChanged(object sender, EventArgs e)
		{
			if (internalupdate)
			{
				FireChangedEvent(true);
				return;
			}
			internalupdate = true;
			try
			{
				int val = (int)((((Convert.ToDouble(tb.Text) - dno) / ns)));
				Value = Math.Max(pb.Minimum, Math.Min(pb.Maximum, val));
			}
			catch { }
			finally
			{
				FireChangedEvent(true);
				internalupdate = false;
			}
		}

		private void ProgressBarUpdate(MouseEventArgs e)
		{
			if (e != null)
			{
				int nval = Math.Max(
					pb.Minimum,
					Math.Min(
						pb.Maximum,
						Convert.ToInt32(
							Math.Round(
								(e.X / (double)pb.SensitiveWidth) * pb.Maximum
							)
						)
					)
				);
				bool update = nval != pb.Value;
				pb.Value = nval;
				if (update)
				{
					FireChangedEvent(false);
				}

				Update();
			}
		}

		private void pb_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ProgressBarUpdate(e);
			}
		}

		private void pb_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ProgressBarUpdate(e);
			}
		}

		private void pb_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ProgressBarUpdate(e);
			}
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			/*tb.Left = this.Width-tb.Width;
			tb.Top = pb.Bottom-tb.Height+1;
			lb.Top = pb.Bottom-lb.Height+1;
			pb.SetBounds(
				lb.Right+8,
				pb.Top,
				tb.Left - pb.Left - 8,
				pb.Height
				);*/
		}

		public void CompleteRedraw()
		{
			pb.CompleteRedraw();
			pb.Refresh();
		}

		private void lb_SizeChanged(object sender, EventArgs e)
		{
			//OnResize(e);
		}
	}
}
