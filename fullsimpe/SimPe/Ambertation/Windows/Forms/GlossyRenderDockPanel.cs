// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Ambertation.Windows.Forms
{
	public class GlossyRenderDockPanel : WhidbeyRenderDockPanel
	{
		private const int SIZE_DELTA = 10;

		private const int SPEED = 20;

		private ColorBlend butbarbgblend;

		private ColorBlend butbgblendhl;

		private ColorBlend butbgblend;

		public GlossyRenderDockPanel(BaseRenderer parent)
			: base(parent)
		{
			dim = new Dimensions(16, 27, 1, 4, 6, 3, 16, 2, 2);
			butbarbgblend = new ColorBlend();
			butbarbgblend.Colors = new Color[4]
			{
			base.ColorTable.DockButtonBarBackgroundTop,
			base.ColorTable.DockButtonBarBackgroundBottom,
			base.ColorTable.DockButtonBarBackgroundBottom,
			base.ColorTable.DockButtonBarBackgroundTop
			};
			butbarbgblend.Positions = new float[4] { 0f, 0.6f, 0.7f, 1f };
			butbgblendhl = new ColorBlend();
			butbgblendhl.Colors = new Color[4]
			{
			base.Parent.Interpolate(base.ColorTable.DockButtonBackgroundTop, Color.Black, 0.02f),
			base.ColorTable.DockButtonBackgroundTop,
			base.ColorTable.DockButtonBackgroundBottom,
			base.Parent.Interpolate(base.ColorTable.DockButtonBackgroundBottom, Color.White, 0.2f)
			};
			butbgblendhl.Positions = new float[4] { 0f, 0.4f, 0.405f, 1f };
			butbgblend = new ColorBlend();
			butbgblend.Colors = new Color[4]
			{
			base.Parent.Interpolate(base.ColorTable.DockButtonHighlightBackgroundTop, Color.White, 0.1f),
			base.ColorTable.DockButtonHighlightBackgroundTop,
			base.ColorTable.DockButtonHighlightBackgroundBottom,
			base.Parent.Interpolate(base.ColorTable.DockButtonHighlightBackgroundBottom, Color.White, 0.1f)
			};
			butbgblend.Positions = new float[4] { 0f, 0.4f, 0.405f, 1f };
		}

		protected override void RenderCaptionButton(DockPanel dp, DockPanelCaptionButton but, string iname, NCPaintEventArgs e)
		{
			if (but.State != 0)
			{
				Pen pen = new Pen(Color.FromArgb(112, 0, 0, 0));
				SolidBrush brush = new SolidBrush(Color.Transparent);
				if (but.State == CaptionButtonState.Highlight)
				{
					brush = new SolidBrush(Color.FromArgb(112, 255, 255, 255));
				}
				else if (but.State == CaptionButtonState.Selected)
				{
					brush = new SolidBrush(Color.FromArgb(64, 255, 255, 255));
				}

				e.Graphics.FillRectangle(brush, but.Bounds);
				e.Graphics.DrawRectangle(pen, but.Bounds);
			}

			DrawButtonImage(e.Graphics, SetupCaptionButtonName(dp, iname), but.Bounds, dp.CaptionState == CaptionState.Focused);
		}

		protected override void RenderCaptionBackground(CaptionState state, NCPaintEventArgs e, Rectangle caprect)
		{
			base.RenderCaptionBackground(state, e, caprect);
			if (state == CaptionState.Normal)
			{
				Rectangle rectangle = caprect;
				Pen pen = new Pen(Color.FromArgb(64, base.Parent.Interpolate(base.Parent.ColorTable.DockBorderColor, Color.Black, 0.2f)));
				e.Graphics.DrawLine(pen, rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Top);
				e.Graphics.DrawLine(pen, rectangle.Left, rectangle.Top, rectangle.Left, rectangle.Bottom - 1);
			}
		}

		protected override void RenderButtonBackground(NCPaintEventArgs e, Rectangle barr, Rectangle r, Point pt1, Point pt2, DockPanel dp)
		{
			RenderButtonBarBackground(e, r, dp.BestOrientation);
		}

		public override void RenderButtonBarBackground(NCPaintEventArgs e, Rectangle r, ButtonOrientation orient)
		{
			LinearGradientMode gradientMode = GetGradientMode(orient);
			Color dockButtonBarBackgroundTop = base.ColorTable.DockButtonBarBackgroundTop;
			Color dockButtonBarBackgroundBottom = base.ColorTable.DockButtonBarBackgroundBottom;
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(r, dockButtonBarBackgroundTop, dockButtonBarBackgroundBottom, gradientMode);
			linearGradientBrush.InterpolationColors = butbarbgblend;
			e.Graphics.FillRectangle(linearGradientBrush, r);
		}

		protected override void ModifyButtonRectangle(ref Rectangle r, string caption, Image img, ButtonOrientation orient, ButtonState state, bool renderbackgroundbar)
		{
			base.ModifyButtonRectangle(ref r, caption, img, orient, state, renderbackgroundbar);
			switch (orient)
			{
				case ButtonOrientation.Bottom:
					r = new Rectangle(r.Left + 1, r.Top, r.Width - 1, r.Height - 3);
					break;
				case ButtonOrientation.Top:
					r = new Rectangle(r.Left + 1, r.Top + 3, r.Width - 1, r.Height - 3);
					break;
				case ButtonOrientation.Left:
					r = new Rectangle(r.Left + 3, r.Top + 1, r.Width - 3, r.Height - 1);
					break;
				default:
					r = new Rectangle(r.Left, r.Top + 1, r.Width - 3, r.Height - 1);
					break;
			}
		}

		protected override void SetupButtonColors(Rectangle r, Color c, Color ci, Color fontc, ButtonOrientation orient, ButtonState state, out SolidBrush fontbrush, out SolidBrush linebackgroundbrush, out Brush backgroundbrush, out Pen borderpen, out Pen borderpeninner)
		{
			base.SetupButtonColors(r, c, ci, fontc, orient, state, out fontbrush, out linebackgroundbrush, out backgroundbrush, out borderpen, out borderpeninner);
			LinearGradientMode gradientMode = GetGradientMode(orient);
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(r, base.ColorTable.DockButtonBackgroundTop, base.ColorTable.DockButtonBackgroundBottom, gradientMode);
			if (state == ButtonState.Highlight)
			{
				linearGradientBrush.InterpolationColors = butbgblendhl;
			}
			else
			{
				linearGradientBrush.InterpolationColors = butbgblend;
			}

			backgroundbrush = linearGradientBrush;
		}

		protected override void RenderInnerButtonBorder(System.Drawing.Graphics g, Rectangle r, Pen pi, ButtonOrientation orient, ButtonState state, bool renderbackgroundbar)
		{
			Rectangle r2 = r;
			r2.Inflate(-2, -2);
			r2.Offset(1, 1);
			g.DrawPath(path: (state != 0) ? ButtonIndicatorPath(r2, orient) : ButtonFullPath(r2), pen: new Pen(pi.Brush, 2f));
		}
	}
}
