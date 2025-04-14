// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using SimPe.Interfaces;

namespace Ambertation.Windows.Forms
{
	public abstract class NCUserControl : UserControl
	{
		private Padding ncsz;

		private NCButtons mb;

		private static Point lastsp;

		private NCResizeBorders ersz;

		private bool dborder;

		private bool doublebuffer;

		private Bitmap bmpbuffer;

		private System.Drawing.Graphics gbuffer;

		private bool needrepaint;

		private bool needncrepaint;

		private IContainer components;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[Description("Set all Borders to true, that should allow the User to resize this Control.")]
		public NCResizeBorders ResizeBorder => ersz;

		[Description("true, if you want allow users to drag this Control at runtime, by holding the mouse down over the border")]
		public bool DragBorder
		{
			get
			{
				return dborder;
			}
			set
			{
				dborder = value;
			}
		}

		protected Padding NonClientMargin
		{
			get
			{
				return ncsz;
			}
			set
			{
				if (value != ncsz)
				{
					ncsz = value;
					base.Width++;
					base.Width--;
				}
			}
		}

		protected bool DoubleBuffer
		{
			get
			{
				return doublebuffer;
			}
			set
			{
				doublebuffer = value;
			}
		}

		protected bool NeedRepaint
		{
			get
			{
				return needrepaint;
			}
			set
			{
				needrepaint = value;
			}
		}

		protected bool NCNeedRepaint
		{
			get
			{
				return needncrepaint;
			}
			set
			{
				needncrepaint = value;
			}
		}

		public NCUserControl()
		{
			SetStyle(ControlStyles.OptimizedDoubleBuffer, value: true);
			needrepaint = true;
			needncrepaint = true;
			doublebuffer = true;
			ncsz = new Padding(6, 6, 6, 20);
			mb = new NCButtons();
			InitializeComponent();
			ersz = new NCResizeBorders();
			dborder = true;
		}

		protected void DoInvalidateWindow()
		{
			needncrepaint = true;
			needrepaint = true;
			_ = base.ClientRectangle;
			APIHelp.RECT lprcUpdate = new APIHelp.RECT(0, 0, base.Width, base.Height);
			APIHelp.RedrawWindow(base.Handle, ref lprcUpdate, IntPtr.Zero, 1281u);
		}

		public void NCRefresh()
		{
			NCRefresh(force: false);
		}

		public void NCRefresh(bool force)
		{
			needncrepaint = true;
			if (base.Visible || force)
			{
				NCPaint(new IntPtr(0));
			}
		}

		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
				case 131:
					m = WndProc_WM_NCCALCSIZE(m);
					break;
				case 133:
					m.WParam = NCPaint(m.WParam);
					break;
				case 160:
				case 161:
				case 162:
				case 164:
				case 165:
				case 167:
				case 168:
					m = WndProc_WM_NCMOUSE(m);
					break;
				case 163:
				case 166:
				case 169:
					{
						NCButtons nCButtons = new NCButtons();
						GetMouseButtonState();
						NCMouseEventArgs mouseParams3 = GetMouseParams(ref m, getdelta: false, nCButtons);
						OnNcDoubleClick(mouseParams3);
						break;
					}
				case 672:
					{
						NCMouseEventArgs mouseParams2 = GetMouseParams(ref m, getdelta: false);
						OnNcMouseHover(mouseParams2);
						break;
					}
				case 674:
					{
						NCMouseEventArgs mouseParams = GetMouseParams(ref m, getdelta: false);
						OnNcMouseLeave(mouseParams);
						break;
					}
				case 132:
					m = WndProc_WM_NCHITTEST(m);
					return;
			}

			base.WndProc(ref m);
		}

		internal Message WndProc_WM_NCMOUSE(Message m)
		{
			NCMouseEventArgs mouseParams = GetMouseParams(ref m, getdelta: true);
			if (m.Msg == 162 || m.Msg == 168 || m.Msg == 165)
			{
				OnNcMouseUp(mouseParams);
			}

			GetMouseButtonState();
			if (!mb.Left && !mb.Right && !mb.Middle && (m.Msg == 162 || m.Msg == 168 || m.Msg == 165))
			{
				OnNcClick(mouseParams);
			}

			if (m.Msg == 161 || m.Msg == 167 || m.Msg == 164)
			{
				OnNcMouseDown(mouseParams);
			}

			OnNcMouseChanged(mouseParams);
			return m;
		}

		internal Message WndProc_WM_NCHITTEST(Message m)
		{
			base.WndProc(ref m);
			NCHitTestEventArgs hitTestParams = GetHitTestParams(ref m);
			DoNcHitTest(hitTestParams);
			m.Result = hitTestParams.GetResult();
			return m;
		}

		internal Message WndProc_WM_NCCALCSIZE(Message m)
		{
			if (m.WParam.ToInt32() == 0)
			{
				APIHelp.RECT rECT = (APIHelp.RECT)m.GetLParam(typeof(APIHelp.RECT));
				rECT.Left += ncsz.Left;
				rECT.Top += ncsz.Top;
				rECT.Right -= ncsz.Right;
				rECT.Bottom -= ncsz.Bottom;
				Marshal.StructureToPtr(rECT, m.LParam, fDeleteOld: true);
				m.Result = IntPtr.Zero;
			}
			else
			{
				APIHelp.NCCALCSIZE_PARAMS nCCALCSIZE_PARAMS = (APIHelp.NCCALCSIZE_PARAMS)m.GetLParam(typeof(APIHelp.NCCALCSIZE_PARAMS));
				nCCALCSIZE_PARAMS.rgrc0.Top += ncsz.Top;
				nCCALCSIZE_PARAMS.rgrc0.Bottom -= ncsz.Bottom;
				nCCALCSIZE_PARAMS.rgrc0.Left += ncsz.Left;
				nCCALCSIZE_PARAMS.rgrc0.Right -= ncsz.Right;
				Marshal.StructureToPtr(nCCALCSIZE_PARAMS, m.LParam, fDeleteOld: true);
				m.Result = IntPtr.Zero;
			}

			return m;
		}

		private void GetMouseButtonState()
		{
			mb.LeftInt = APIHelp.GetKeyState(APIHelp.VirtualKeyStates.VK_LBUTTON) < 0;
			mb.MiddleInt = APIHelp.GetKeyState(APIHelp.VirtualKeyStates.VK_MBUTTON) < 0;
			mb.RightInt = APIHelp.GetKeyState(APIHelp.VirtualKeyStates.VK_RBUTTON) < 0;
		}

		protected void ResetNCMouseState()
		{
			mb.Reset();
		}

		private NCHitTestEventArgs GetHitTestParams(ref Message m)
		{
			m = GetNCMessageParams(m, out var screenPoint, out var pt);
			return new NCHitTestEventArgs(screenPoint, pt, new Point(pt.X + ncsz.Left, pt.Y + ncsz.Top), new Point(0), m.Result, mb);
		}

		internal NCMouseEventArgs CallGetMouseParams(ref Message m, bool getdelta)
		{
			GetMouseButtonState();
			return GetMouseParams(ref m, getdelta);
		}

		private NCMouseEventArgs GetMouseParams(ref Message m, bool getdelta)
		{
			return GetMouseParams(ref m, getdelta, mb);
		}

		private NCMouseEventArgs GetMouseParams(ref Message m, bool getdelta, NCButtons mb)
		{
			m = GetNCMessageParams(m, out var screenPoint, out var pt);
			Point delta = new Point(0);
			if (getdelta)
			{
				delta = new Point(screenPoint.X - lastsp.X, screenPoint.Y - lastsp.Y);
				lastsp = screenPoint;
			}

			return new NCMouseEventArgs(m.WParam, screenPoint, pt, new Point(pt.X + ncsz.Left, pt.Y + ncsz.Top), delta, mb);
		}

		private Message GetNCMessageParams(Message m, out Point screenPoint, out Point pt)
		{
			int num = m.LParam.ToInt32();
			screenPoint = new Point(num & 0xFFFF, num >> 16);
			pt = PointToClient(screenPoint);
			return m;
		}

		internal IntPtr CallNCPaint(IntPtr reg)
		{
			return NCPaint(reg);
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			SetupBitmapBuffer();
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			SetupBitmapBuffer();
		}

		private void SetupBitmapBuffer()
		{
			Region UpdateRegion;
			Rectangle windowRectangle = GetWindowRectangle(out UpdateRegion);
			if (bmpbuffer == null || bmpbuffer.Width != windowRectangle.Width || bmpbuffer.Height != windowRectangle.Height)
			{
				if (gbuffer != null)
				{
					gbuffer.Dispose();
				}

				if (bmpbuffer != null)
				{
					bmpbuffer.Dispose();
				}

				needrepaint = true;
				needncrepaint = true;
				bmpbuffer = new Bitmap(Math.Max(1, windowRectangle.Width), Math.Max(1, windowRectangle.Height));
				gbuffer = System.Drawing.Graphics.FromImage(bmpbuffer);
				gbuffer.SmoothingMode = SmoothingMode.HighSpeed;
				gbuffer.InterpolationMode = InterpolationMode.Low;
			}
		}

		protected IntPtr NCPaint(IntPtr region)
		{
			IntPtr windowDC = APIHelp.GetWindowDC(base.Handle);
			if (windowDC != IntPtr.Zero)
			{
				System.Drawing.Graphics graphics = System.Drawing.Graphics.FromHdc(windowDC);
				int verticalScrollBarWidth = SystemInformation.VerticalScrollBarWidth;
				int horizontalScrollBarHeight = SystemInformation.HorizontalScrollBarHeight;
				Region UpdateRegion;
				Rectangle windowRectangle = GetWindowRectangle(out UpdateRegion);
				IntPtr hrgn = UpdateRegion.GetHrgn(graphics);
				Point pos = Point.Empty - (Size)windowRectangle.Location;
				windowRectangle.Offset(pos);
				Rectangle clientArea = GetClientArea();
				Region region2 = new Region(windowRectangle);
				region2.Exclude(clientArea);
				if (base.HScroll && base.VScroll)
				{
					new Rectangle(clientArea.Right - verticalScrollBarWidth, clientArea.Bottom - horizontalScrollBarHeight, verticalScrollBarWidth + 2, horizontalScrollBarHeight + 2).Offset(-1, -1);
				}

				SetupBitmapBuffer();
				if (doublebuffer)
				{
					if (windowRectangle.Width > 0 && windowRectangle.Height > 1 && (ncsz.Horizontal > 0 || ncsz.Vertical > 0))
					{
						if (needncrepaint)
						{
							NCPaintEventArgs e = new NCPaintEventArgs(gbuffer, base.ClientRectangle, windowRectangle, region2);
							OnNcPaint(e);
							needncrepaint = false;
						}

						graphics.DrawImage(bmpbuffer, 0, 0);
					}
				}
				else
				{
					NCPaintEventArgs e2 = new NCPaintEventArgs(graphics, base.ClientRectangle, windowRectangle, region2);
					OnNcPaint(e2);
				}

				APIHelp.ReleaseDC(base.Handle, windowDC);
				graphics.Dispose();
				return hrgn;
			}

			return region;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Rectangle clipRectangle = e.ClipRectangle;
			clipRectangle.Offset(ncsz.Left, ncsz.Top);
			new PaintEventArgs(gbuffer, clipRectangle);
			if (needrepaint)
			{
				OnBufferedPaint(e);
				needrepaint = false;
			}
		}

		protected virtual void OnBufferedPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
		}

		protected Rectangle GetWindowRectangle()
		{
			Region UpdateRegion;
			return GetWindowRectangle(out UpdateRegion);
		}

		protected Rectangle GetWindowRectangle(out Region UpdateRegion)
		{
			APIHelp.WINDOWINFO pwi = default(APIHelp.WINDOWINFO);
			pwi.cbSize = (uint)Marshal.SizeOf(pwi);
			APIHelp.GetWindowInfo(base.Handle, ref pwi);
			pwi.rcClient.Right--;
			pwi.rcClient.Bottom--;
			UpdateRegion = new Region(pwi.rcWindow.ToRectangle());
			UpdateRegion.Exclude(pwi.rcClient.ToRectangle());
			if (base.HScroll && base.VScroll)
			{
				UpdateRegion.Exclude(Rectangle.FromLTRB(pwi.rcClient.Right + 1, pwi.rcClient.Bottom + 1, pwi.rcWindow.Right, pwi.rcWindow.Bottom));
			}

			return pwi.rcWindow.ToRectangle();
		}

		protected virtual void OnNcPaint(NCPaintEventArgs e)
		{
			e.Graphics.FillRegion(SystemBrushes.AppWorkspace, e.PaintRegion);
		}

		public Rectangle GetClientArea()
		{
			_ = SystemInformation.VerticalScrollBarWidth;
			_ = SystemInformation.HorizontalScrollBarHeight;
			Rectangle windowRectangle = GetWindowRectangle();
			return new Rectangle(ncsz.Left, ncsz.Top, windowRectangle.Width - ncsz.Horizontal, windowRectangle.Height - ncsz.Vertical);
		}

		protected virtual void DoNcHitTest(NCHitTestEventArgs e)
		{
			if (!GetClientArea().Contains(e.ControlPosition))
			{
				e.Result = NCHitTestEventArgs.Results.HTBORDER;
				bool flag = e.ControlPosition.X < 2 && ersz.Left;
				bool flag2 = e.ControlPosition.Y < 2 && ersz.Top;
				bool flag3 = e.ControlPosition.X > base.Width - 3 && ersz.Right;
				bool flag4 = e.ControlPosition.Y > base.Height - 3 && ersz.Bottom;
				if (flag && flag2)
				{
					e.Result = NCHitTestEventArgs.Results.HTTOPLEFT;
				}
				else if (flag3 && flag2)
				{
					e.Result = NCHitTestEventArgs.Results.HTTOPRIGHT;
				}
				else if (flag3 && flag4)
				{
					e.Result = NCHitTestEventArgs.Results.HTBOTTOMRIGHT;
				}
				else if (flag && flag4)
				{
					e.Result = NCHitTestEventArgs.Results.HTBOTTOMLEFT;
				}
				else if (flag)
				{
					e.Result = NCHitTestEventArgs.Results.HTLEFT;
				}
				else if (flag2)
				{
					e.Result = NCHitTestEventArgs.Results.HTTOP;
				}
				else if (flag3)
				{
					e.Result = NCHitTestEventArgs.Results.HTRIGHT;
				}
				else if (flag4)
				{
					e.Result = NCHitTestEventArgs.Results.HTBOTTOM;
				}
			}
			else if (e.Result != NCHitTestEventArgs.Results.HTVSCROLL && e.Result != NCHitTestEventArgs.Results.HTHSCROLL)
			{
				e.Result = NCHitTestEventArgs.Results.HTCLIENT;
			}
			else
			{
				mb.Reset();
			}

			OnNcHitTest(e);
		}

		protected virtual void OnNcMouseChanged(NCMouseEventArgs e)
		{
		}

		protected virtual void OnNcMouseDown(NCMouseEventArgs e)
		{
		}

		protected virtual void OnNcMouseUp(NCMouseEventArgs e)
		{
		}

		protected virtual void OnNcClick(NCMouseEventArgs e)
		{
		}

		protected virtual void OnNcMouseLeave(NCMouseEventArgs e)
		{
		}

		protected virtual void OnNcMouseHover(NCMouseEventArgs e)
		{
		}

		protected virtual void OnNcDoubleClick(NCMouseEventArgs e)
		{
		}

		protected virtual void OnNcHitTest(NCHitTestEventArgs e)
		{
			if (dborder && e.Result == NCHitTestEventArgs.Results.HTBORDER)
			{
				e.Result = NCHitTestEventArgs.Results.HTCAPTION;
			}
		}

		protected override void OnVisibleChanged(EventArgs e)
		{
			base.OnVisibleChanged(e);
			NCRefresh();
		}

		public virtual void RefreshAll()
		{
			NCRefresh();
			Refresh();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}

			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
		}
	}
}
