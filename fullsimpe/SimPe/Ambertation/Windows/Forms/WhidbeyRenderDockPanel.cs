// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace Ambertation.Windows.Forms
{
	public class WhidbeyRenderDockPanel : BaseDockPanelRenderer, IDockPanelRenderer
	{
		private struct AnimationData
		{
			public DockAnimationEventArgs e;
		}

		private const int SIZE_DELTA = 10;

		private const int SPEED = 20;

		protected Dimensions dim;

		private DockAnimationEventHandler atc;

		private System.Threading.Timer animtimer;

		private AnimationData animdata;

		public override Dimensions Dimension => dim;

		public event DockAnimationEventHandler FinishedAnimation;

		public WhidbeyRenderDockPanel(BaseRenderer parent)
			: base(parent)
		{
			dim = new Dimensions(16, 24, 1, 4, 4, 2, 16, 2);
			atc = InvokedAnimationTimerCallback;
			animtimer = new System.Threading.Timer(AnimationTimerCallback, null, -1, 20);
		}

		private void InvokedAnimationTimerCallback(IDockPanelRenderer sender, DockAnimationEventArgs e)
		{
			DockContainer container = e.Container;
			if (animdata.e.AnimationType == DockAnimationEventArgs.Type.Collapse)
			{
				if (e.DockAlignment == DockAnimationEventArgs.Alignment.Horizontal)
				{
					if (container.Parent == null)
					{
						DoFinishAnimation(e);
					}
					else if (container.Right <= 0)
					{
						DoFinishAnimation(e);
					}
					else
					{
						container.Left -= 10;
					}
				}
				else if (e.DockAlignment == DockAnimationEventArgs.Alignment.Vertical)
				{
					if (container.Parent == null)
					{
						DoFinishAnimation(e);
					}
					else if (container.Left >= container.Parent.Width)
					{
						DoFinishAnimation(e);
					}
					else
					{
						container.Left += 10;
					}
				}
				else
				{
					DoFinishAnimation(e);
				}
			}
			else if (e.AnimationType == DockAnimationEventArgs.Type.Expand)
			{
				if (e.DockAlignment == DockAnimationEventArgs.Alignment.Horizontal)
				{
					if (container.Parent == null)
					{
						DoFinishAnimation(e);
					}
					else if (container.Left >= 0)
					{
						DoFinishAnimation(e);
					}
					else
					{
						container.Left = Math.Min(0, container.Left + 10);
					}
				}
				else if (e.DockAlignment == DockAnimationEventArgs.Alignment.Vertical)
				{
					if (container.Parent == null)
					{
						DoFinishAnimation(e);
					}
					else if (container.Right <= container.Parent.Width)
					{
						DoFinishAnimation(e);
					}
					else
					{
						container.Left = Math.Max(container.Parent.Width - container.Width, container.Left - 10);
					}
				}
				else
				{
					DoFinishAnimation(e);
				}
			}
			else
			{
				DoFinishAnimation(e);
			}
		}

		private void AnimationTimerCallback(object stateInfo)
		{
			DockContainer container = animdata.e.Container;
			if (container.InvokeRequired)
			{
				object[] args = new object[2] { this, animdata.e };
				container.Invoke(atc, args);
			}
			else
			{
				atc(this, animdata.e);
			}
		}

		private void DoFinishAnimation(DockAnimationEventArgs e)
		{
			animtimer.Change(-1, 20);
			if (this.FinishedAnimation != null)
			{
				this.FinishedAnimation(this, e);
			}

			e.Container.ResumeLayout();
			e.Container.RepaintAll();
		}

		protected string SetupCaptionButtonName(DockPanel dp, string name)
		{
			if (dp.CaptionState == CaptionState.Focused)
			{
				return name;
			}

			return name;
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

			DrawButtonImage(e.Graphics, SetupCaptionButtonName(dp, iname), but.Bounds, focused: false);
		}

		protected override void RenderCaptionText(CaptionState state, NCPaintEventArgs e, Rectangle txtrect, string caption)
		{
			Color color = base.Parent.ColorTable.DockCaptionTextColor;
			if (state == CaptionState.Focused)
			{
				color = base.Parent.ColorTable.DockCaptionFocusTextColor;
			}

			e.Graphics.DrawString(GetFittingString(base.Parent.FontTable.CaptionFont, caption, ButtonOrientation.Top, txtrect.Size), base.Parent.FontTable.CaptionFont, new SolidBrush(color), txtrect);
		}

		protected override void RenderCaptionBackground(CaptionState state, NCPaintEventArgs e, Rectangle caprect)
		{
			caprect.Offset(-1, -1);
			caprect.Inflate(1, 1);
			Color color = base.Parent.ColorTable.DockCaptionColorTop;
			Color color2 = base.Parent.ColorTable.DockCaptionColorBottom;
			if (state == CaptionState.Focused)
			{
				color = base.Parent.ColorTable.DockCaptionFocusColorTop;
				color2 = base.Parent.ColorTable.DockCaptionFocusColorBottom;
			}

			LinearGradientBrush brush = new LinearGradientBrush(caprect, color, color2, LinearGradientMode.Vertical);
			e.Graphics.FillRectangle(brush, caprect);
		}

		protected override void RenderButtonBackground(NCPaintEventArgs e, Rectangle r, Point pt1, Point pt2, SolidBrush brush, Pen pen)
		{
			e.Graphics.FillRectangle(brush, r);
			e.Graphics.DrawLine(pen, pt1, pt2);
		}

		protected virtual GraphicsPath ButtonFullPath(Rectangle r)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddLine(r.Left + 2, r.Top, r.Right - 2, r.Top);
			graphicsPath.AddLine(r.Right - 2, r.Top, r.Right, r.Top + 2);
			graphicsPath.AddLine(r.Right, r.Top + 2, r.Right, r.Bottom - 2);
			graphicsPath.AddLine(r.Right, r.Bottom - 2, r.Right - 2, r.Bottom);
			graphicsPath.AddLine(r.Right - 2, r.Bottom, r.Left + 2, r.Bottom);
			graphicsPath.AddLine(r.Left + 2, r.Bottom, r.Left, r.Bottom - 2);
			graphicsPath.AddLine(r.Left, r.Bottom - 2, r.Left, r.Top + 2);
			graphicsPath.CloseFigure();
			return graphicsPath;
		}

		protected GraphicsPath ButtonIndicatorPath(Rectangle r, ButtonOrientation orient)
		{
			return ButtonFullPath(r);
		}

		protected virtual void RenderInnerButtonBorder(System.Drawing.Graphics g, Rectangle r, Pen pi, ButtonOrientation orient, ButtonState state, bool renderbackgroundbar)
		{
		}

		protected override void RenderButton(System.Drawing.Graphics g, Rectangle r, Rectangle fullr, string caption, Image img, Color c, Color ci, Color fontc, Font f, StringFormat sf, ButtonOrientation orient, ButtonState state, bool renderbackgroundbar)
		{
			SetupButtonColors(r, c, ci, fontc, orient, state, out var fontbrush, out var linebackgroundbrush, out var backgroundbrush, out var borderpen, out var borderpeninner);
			r = SetupButtonRectangles(r, fullr, f, orient, out var linerectangle, out var linept, out var linept2, out var textrect, out var imgrect);
			GraphicsPath graphicsPath = ((state != 0) ? ButtonIndicatorPath(r, orient) : ButtonFullPath(r));
			StringFormat format = new StringFormat(sf.FormatFlags | StringFormatFlags.NoWrap);
			GraphicsPath graphicsPath2 = graphicsPath.Clone() as GraphicsPath;
			graphicsPath2.CloseFigure();
			g.FillPath(backgroundbrush, graphicsPath2);
			RenderButtonIcon(g, img, imgrect);
			g.DrawString(GetFittingString(f, caption, orient, new Size(textrect.Width, textrect.Height)), f, fontbrush, textrect, format);
			RenderInnerButtonBorder(g, r, borderpeninner, orient, state, renderbackgroundbar);
			g.DrawPath(borderpen, graphicsPath);
			Pen pen = new Pen(base.ColorTable.DockButtonHighlightBorderColorOuter);
			if (renderbackgroundbar)
			{
				g.FillRectangle(linebackgroundbrush, linerectangle);
				if (state != ButtonState.Highlight)
				{
					g.DrawLine(pen, linept, linept2);
				}
			}
			else
			{
				FixButtonCorners(g, backgroundbrush, borderpen, ref linerectangle, ref linept, ref linept2, pen);
			}
		}

		protected virtual void FixButtonCorners(System.Drawing.Graphics g, Brush bg, Pen p, ref Rectangle linerectangle, ref Point linept1, ref Point linept2, Pen pp)
		{
			g.FillRectangle(bg, linerectangle);
			g.DrawRectangle(pp, linerectangle);
			g.DrawLine(new Pen(bg), linept1, linept2);
			g.DrawLine(p, linept1, linept1);
			g.DrawLine(p, linept2, linept2);
		}

		protected virtual void RenderButtonIcon(System.Drawing.Graphics g, Image img, Rectangle imgrect)
		{
			g.DrawImage(img, new Rectangle((imgrect.Width - img.Width) / 2 + imgrect.Left + 1, (imgrect.Height - img.Height) / 2 + imgrect.Top + 1, img.Width, img.Height), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
		}

		public void RenderGrip(DockContainer dc, NCPaintEventArgs e, Rectangle r)
		{
			e.Graphics.FillRectangle(new SolidBrush(base.ColorTable.DockGripColor), r);
		}

		public void RenderResizePanel(DockContainer dc, RubberBandHelper rbh, PaintEventArgs e)
		{
			Rectangle clientRectangle = rbh.ClientRectangle;
			e.Graphics.FillRectangle(new SolidBrush(base.ColorTable.DockReSizeBackgroundColor), new Rectangle(clientRectangle.Left, clientRectangle.Top, clientRectangle.Width - 1, clientRectangle.Height - 1));
			if (rbh.ContainerDock == DockStyle.Right)
			{
				e.Graphics.FillRectangle(new SolidBrush(base.ColorTable.DockReSizeGripColor), new Rectangle(clientRectangle.Left, clientRectangle.Top, 3, clientRectangle.Height - 1));
			}
			else if (rbh.ContainerDock == DockStyle.Left)
			{
				e.Graphics.FillRectangle(new SolidBrush(base.ColorTable.DockReSizeGripColor), new Rectangle(clientRectangle.Width - 4, clientRectangle.Top, 3, clientRectangle.Height - 1));
			}
			else if (rbh.ContainerDock == DockStyle.Bottom)
			{
				e.Graphics.FillRectangle(new SolidBrush(base.ColorTable.DockReSizeGripColor), new Rectangle(clientRectangle.Left, clientRectangle.Top, clientRectangle.Width - 1, 3));
			}
			else if (rbh.ContainerDock == DockStyle.Top)
			{
				e.Graphics.FillRectangle(new SolidBrush(base.ColorTable.DockReSizeGripColor), new Rectangle(clientRectangle.Left, clientRectangle.Height - 4, clientRectangle.Width - 1, 3));
			}
		}

		public void RenderBorder(DockPanel dp, NCPaintEventArgs e)
		{
			Pen pen = new Pen(base.Parent.ColorTable.DockBorderColor, Dimension.Border);
			Rectangle panelClientRectangle = GetPanelClientRectangle(dp.DockContainer, e, dp.BestOrientation);
			panelClientRectangle = new Rectangle(panelClientRectangle.Left - Dimension.Border, panelClientRectangle.Top - Dimension.Border - Dimension.Caption, panelClientRectangle.Width + 2 * Dimension.Border - 1, panelClientRectangle.Height + 2 * Dimension.Border - 1 + Dimension.Caption);
			e.Graphics.DrawRectangle(pen, panelClientRectangle);
		}

		public void Animate(DockAnimationEventArgs e)
		{
			animdata.e = e;
			e.Container.SuspendLayout();
			if (e.Container.Dock == DockStyle.Fill)
			{
				DoFinishAnimation(e);
			}
			else
			{
				animtimer.Change(0, 20);
			}
		}
	}
}
