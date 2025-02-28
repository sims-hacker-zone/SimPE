// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Ambertation.Windows.Forms
{
	/// <summary>
	/// This is an c#-Version of a Control created by www.steepvalley.net.
	/// I translated it to remove the Expand/Collapse feature
	/// </summary>
	[DesignTimeVisible(true), ToolboxBitmap(typeof(GroupBox))]
	public class XPTaskBoxSimple : Panel
	{
		// Methods
		public XPTaskBoxSimple()
		{
			headerh = 22;
			mstrHeaderText = "";
			InitializeComponent();
			SetStyle(ControlStyles.ResizeRedraw, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.DoubleBuffer, true);
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			SetStyle(ControlStyles.ContainerControl, true);
			base.BackColor = Color.Transparent;

			bc = SystemColors.Window;
			lhc = SystemColors.InactiveCaption;
			rhc = SystemColors.Highlight;
			bodc = SystemColors.InactiveCaptionText;
			htc = SystemColors.ActiveCaptionText;

			font = new Font(
				base.Font.Name,
				base.Font.Size + 2,
				FontStyle.Bold,
				base.Font.Unit
			);

			icsz = new Size(32, 32);
			icpt = new Point(4, 12);
		}

		Color lhc,
			rhc,
			bc,
			bodc,
			htc;
		public Color LeftHeaderColor
		{
			get => lhc;
			set
			{
				if (lhc != value)
				{
					lhc = value;
					Invalidate();
				}
			}
		}

		public Color RightHeaderColor
		{
			get => rhc;
			set
			{
				if (rhc != value)
				{
					rhc = value;
					Invalidate();
				}
			}
		}

		public Color BorderColor
		{
			get => bc;
			set
			{
				if (bc != value)
				{
					bc = value;
					Invalidate();
				}
			}
		}

		public Color HeaderTextColor
		{
			get => htc;
			set
			{
				if (htc != value)
				{
					htc = value;
					Invalidate();
				}
			}
		}

		public Color BodyColor
		{
			get => bodc;
			set
			{
				if (bodc != value)
				{
					bodc = value;
					Invalidate();
				}
			}
		}

		Font font;
		public Font HeaderFont
		{
			get => font;
			set
			{
				if (font != value)
				{
					font = value;
					Invalidate();
				}
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				canvas?.Dispose();

				canvas = null;
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		[DebuggerStepThrough]
		private void InitializeComponent()
		{
			components = new Container();

			Size size1 = new Size(0x10, 0x10);

			DockPadding.Bottom = 4;
			DockPadding.Left = 4;
			DockPadding.Right = 4;
			DockPadding.Top = 0x2c;
			Name = "XPTaskBoxSimple";
		}

		private void mThemeFormat_PropertyChanged(
			object sender,
			PropertyChangedEventArgs e
		)
		{
			Invalidate();
		}

		Size icsz;
		public Size IconSize
		{
			get => icsz;
			set
			{
				if (icsz != value)
				{
					icsz = value;
					Invalidate();
				}
			}
		}

		Point icpt;
		public Point IconLocation
		{
			get => icpt;
			set
			{
				if (icpt != value)
				{
					icpt = value;
					Invalidate();
				}
			}
		}

		Bitmap canvas;

		protected void RebuildCanvas()
		{
			canvas?.Dispose();

			if (Width <= 7 || Height <= headerh + 21)
			{
				canvas = null;
				return;
			}
			canvas = new Bitmap(Width, Height);
			System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(canvas);
			Rectangle ef4;
			g.SmoothingMode = SmoothingMode.HighQuality;
			Rectangle ef3 = new Rectangle(0, 16, Width - 1, headerh);
			Rectangle ef3b = new Rectangle(
				3,
				ef3.Bottom,
				Width - 7,
				Height - ef3.Bottom - 4
			);
			Rectangle ef2 = new Rectangle(
				0,
				16 + headerh + 2,
				Width - 1,
				Height - 16 + headerh + 3
			);
			Rectangle ef1 = new Rectangle(0, 16, Width - 1, Height - 0x11);
			GraphicsPath path = new GraphicsPath();
			LinearGradientBrush brush1 = new LinearGradientBrush(
				ef3,
				LeftHeaderColor,
				RightHeaderColor,
				LinearGradientMode.Horizontal
			);
			Pen borderpen = new Pen(BorderColor, 1f);
			StringFormat format1 = new StringFormat
			{
				Alignment = StringAlignment.Near,
				LineAlignment = StringAlignment.Center,
				Trimming = StringTrimming.EllipsisCharacter,
				FormatFlags = StringFormatFlags.NoWrap
			};
			borderpen.Alignment = PenAlignment.Inset;

			path = Drawing.GraphicRoutines.GethRoundRectPath(ef1, 7);
			g.FillPath(brush1, path);

			path = Drawing.GraphicRoutines.GethRoundRectPath(ef3b, 7);
			g.FillPath(new SolidBrush(BodyColor), path);

			path = Drawing.GraphicRoutines.GethRoundRectPath(ef1, 7);
			g.DrawPath(borderpen, path);
			if (mIcon != null)
			{
				Size size1 = mIcon.Size;
				Rectangle rectangle1 = new Rectangle(IconLocation, size1);
				g.DrawImage(
					//Ambertation.Drawing.GraphicRoutines.ScaleImage(mIcon, size1.Width, size1.Height, true)
					mIcon,
					rectangle1,
					new Rectangle(0, 0, mIcon.Width, mIcon.Height),
					GraphicsUnit.Pixel
				);
				ef4 = new Rectangle(
					8 + size1.Width + IconLocation.X,
					16,
					Width - (size1.Width + IconLocation.X),
					headerh
				);
			}
			else
			{
				ef4 = new Rectangle(8, 16, Width - 0x18, headerh);
			}
			g.DrawString(
				mstrHeaderText,
				HeaderFont,
				new SolidBrush(HeaderTextColor),
				ef4,
				format1
			);

			path.Dispose();
			brush1.Dispose();
			borderpen.Dispose();
			format1.Dispose();
			g.Dispose();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (canvas == null)
			{
				RebuildCanvas();
			}

			if (canvas != null)
			{
				e.Graphics.DrawImage(
					canvas,
					e.ClipRectangle,
					e.ClipRectangle,
					GraphicsUnit.Pixel
				);
			}

			base.OnPaint(e);
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			RebuildCanvas();
		}

		public new void Invalidate()
		{
			RebuildCanvas();
			base.Invalidate();
		}

		// Properties
		[
			Category("Appearance"),
			DefaultValue("Title"),
			Localizable(true),
			Browsable(true),
			Description("Caption text.")
		]
		public string HeaderText
		{
			get => mstrHeaderText;
			set
			{
				mstrHeaderText = value;
				Invalidate();
			}
		}

		[
			Localizable(true),
			Description("Icon"),
			Category("Appearance"),
			DefaultValue(typeof(Icon), "")
		]
		public Image Icon
		{
			get => mIcon;
			set
			{
				mIcon = value;
				Invalidate();
			}
		}

		int headerh;

		[
			Localizable(true),
			Description("Hight of the Headline"),
			Category("Appearance"),
			DefaultValue(typeof(int), "22")
		]
		public int HeaderHeight
		{
			get => headerh;
			set
			{
				headerh = value;
				Invalidate();
			}
		}

		[Browsable(false), Description("returns the usable region as Rectangle")]
		internal Rectangle WorkspaceRect => new Rectangle(3, 0x29, Width - 7, Height - 40 - 4);

		// Fields
		private IContainer components;
		private Image mIcon;
		private string mstrHeaderText;
	}
}
