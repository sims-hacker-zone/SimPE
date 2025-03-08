// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Ambertation.Windows.Forms
{
	public class WhidbeyRenderDockHints : BaseControlRenderer, IRenderDockHints, IControlRenderer
	{
		private Size sz;

		private static Bitmap hintcenter;

		private static Bitmap hintleft;

		private static Bitmap hinttop;

		private static Bitmap hintright;

		private static Bitmap hintbottom;

		private Rectangle rl;

		private Rectangle rt;

		private Rectangle rr;

		private Rectangle rb;

		private Rectangle rc;

		private GraphicsPath pl;

		private GraphicsPath pt;

		private GraphicsPath pr;

		private GraphicsPath pb;

		private GraphicsPath pc;

		public Size HintSize => sz;

		protected virtual Image AllHintsImage
		{
			get
			{
				if (hintcenter == null)
				{
					hintcenter = Image.FromStream(typeof(DockHint).Assembly.GetManifestResourceStream("Ambertation.Windows.Forms.dockhint.PNG")) as Bitmap;
				}

				return hintcenter;
			}
		}

		protected virtual Image LeftHintImage
		{
			get
			{
				if (hintleft == null)
				{
					hintleft = Image.FromStream(typeof(DockHint).Assembly.GetManifestResourceStream("Ambertation.Windows.Forms.left.png")) as Bitmap;
				}

				return hintleft;
			}
		}

		protected virtual Image TopHintImage
		{
			get
			{
				if (hinttop == null)
				{
					hinttop = Image.FromStream(typeof(DockHint).Assembly.GetManifestResourceStream("Ambertation.Windows.Forms.top.png")) as Bitmap;
				}

				return hinttop;
			}
		}

		protected virtual Image RightHintImage
		{
			get
			{
				if (hintright == null)
				{
					hintright = Image.FromStream(typeof(DockHint).Assembly.GetManifestResourceStream("Ambertation.Windows.Forms.right.png")) as Bitmap;
				}

				return hintright;
			}
		}

		protected virtual Image BottomHintImage
		{
			get
			{
				if (hintbottom == null)
				{
					hintbottom = Image.FromStream(typeof(DockHint).Assembly.GetManifestResourceStream("Ambertation.Windows.Forms.bottom.png")) as Bitmap;
				}

				return hintbottom;
			}
		}

		public virtual Rectangle LeftRectangle => rl;

		public virtual Rectangle TopRectangle => rt;

		public virtual Rectangle RightRectangle => rr;

		public virtual Rectangle BottomRectangle => rb;

		public virtual Rectangle CenterRectangle => rc;

		public WhidbeyRenderDockHints(BaseRenderer parent)
			: base(parent)
		{
			sz = new Size(88, 88);
			rl = new Rectangle(0, 29, 31, 28);
			rt = new Rectangle(29, 0, 28, 31);
			rr = new Rectangle(56, 29, 31, 28);
			rb = new Rectangle(29, 56, 28, 31);
			rc = new Rectangle(29, 29, 30, 30);
		}

		public virtual void InitHints(bool l, bool t, bool r, bool b, bool c)
		{
			pl = new GraphicsPath();
			pt = new GraphicsPath();
			pr = new GraphicsPath();
			pb = new GraphicsPath();
			pc = new GraphicsPath();
			if (l && !t && !r && !b && !c)
			{
				InitJustLeft();
			}
			else if (!l && t && !r && !b && !c)
			{
				InitJustTop();
			}
			else if (!l && !t && r && !b && !c)
			{
				InitJustRight();
			}
			else if (!l && !t && !r && b && !c)
			{
				InitJustBottom();
			}
			else
			{
				InitCenter();
			}
		}

		protected virtual void InitCenter()
		{
			pl.AddLine(rl.Left + 21, rl.Top, rl.Left, rl.Top);
			pl.AddLine(rl.Left, rl.Top, rl.Left, rl.Bottom);
			pl.AddLine(rl.Left, rl.Bottom, rl.Left + 21, rl.Bottom);
			pt.AddLine(rt.Left, rt.Top + 21, rt.Left, rt.Top);
			pt.AddLine(rt.Left, rt.Top, rt.Right, rt.Top);
			pt.AddLine(rt.Right, rt.Top, rt.Right, rt.Top + 21);
			pr.AddLine(rr.Right - 22, rr.Top, rr.Right, rr.Top);
			pr.AddLine(rr.Right, rr.Top, rr.Right, rr.Bottom);
			pr.AddLine(rr.Right, rr.Bottom, rr.Right - 22, rr.Bottom);
			pb.AddLine(rb.Left, rb.Bottom - 22, rb.Left, rb.Bottom);
			pb.AddLine(rb.Left, rb.Bottom, rb.Right, rb.Bottom);
			pb.AddLine(rb.Right, rb.Bottom, rb.Right, rb.Bottom - 22);
			pc.AddLine(rt.Left, rt.Top + 21, rl.Left + 21, rl.Top);
			pc.StartFigure();
			pc.AddLine(rl.Left + 21, rl.Bottom, rb.Left, rb.Bottom - 22);
			pc.StartFigure();
			pc.AddLine(rb.Right, rb.Bottom - 22, rr.Right - 22, rr.Bottom);
			pc.StartFigure();
			pc.AddLine(rr.Right - 22, rr.Top, rt.Right, rt.Top + 21);
		}

		protected virtual void InitJustBottom()
		{
			pb.AddRectangle(rb);
		}

		protected virtual void InitJustRight()
		{
			pr.AddRectangle(rr);
		}

		protected virtual void InitJustTop()
		{
			pt.AddRectangle(rt);
		}

		protected virtual void InitJustLeft()
		{
			pl.AddRectangle(rl);
		}

		public virtual void RenderHint(System.Drawing.Graphics g, bool l, bool t, bool r, bool b, bool c, SelectedHint sel)
		{
			InitHints(l, t, r, b, c);
			DrawUnselectedHint(g, l, t, r, b, c);
			DrawSelection(g, sel);
		}

		protected virtual void DrawUnselectedHint(System.Drawing.Graphics g, bool l, bool t, bool r, bool b, bool c)
		{
			if (l && !t && !r && !b && !c)
			{
				g.DrawImage(LeftHintImage, 0, 0, sz.Width, sz.Height);
			}
			else if (!l && t && !r && !b && !c)
			{
				g.DrawImage(TopHintImage, 0, 0, sz.Width, sz.Height);
			}
			else if (!l && !t && r && !b && !c)
			{
				g.DrawImage(RightHintImage, 0, 0, sz.Width, sz.Height);
			}
			else if (!l && !t && !r && b && !c)
			{
				g.DrawImage(BottomHintImage, 0, 0, sz.Width, sz.Height);
			}
			else
			{
				g.DrawImage(AllHintsImage, 0, 0, sz.Width, sz.Height);
			}
		}

		protected virtual void DrawSelection(System.Drawing.Graphics g, SelectedHint sel)
		{
			Pen pen = new Pen(base.ColorTable.DockHintHightlightColor, 1f);
			switch (sel)
			{
				case SelectedHint.Center:
					g.DrawPath(pen, pc);
					break;
				case SelectedHint.Left:
					g.DrawPath(pen, pl);
					break;
				case SelectedHint.Top:
					g.DrawPath(pen, pt);
					break;
				case SelectedHint.Right:
					g.DrawPath(pen, pr);
					break;
				case SelectedHint.Bottom:
					g.DrawPath(pen, pb);
					break;
			}
		}
	}
}
