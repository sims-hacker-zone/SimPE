// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

using SimPe.Interfaces;

namespace Ambertation.Windows.Forms
{
	public class LayeredForm : Form
	{
		private bool colored;

		private Color cl;

		private bool dorefresh;

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.ExStyle |= 524288;
				createParams.ExStyle |= 128;
				return createParams;
			}
		}

		internal Point ScreenLocation => base.Location;

		protected LayeredForm()
			: this(Color.Blue, new Size(300, 400))
		{
		}

		public LayeredForm(Bitmap bitmap)
		{
			Init(bitmap);
		}

		protected virtual void Init(Bitmap bitmap)
		{
			base.TopMost = true;
			base.FormBorderStyle = FormBorderStyle.None;
			base.ControlBox = false;
			base.ShowInTaskbar = false;
			dorefresh = false;
			base.StartPosition = FormStartPosition.Manual;
			if (bitmap != null)
			{
				base.Size = bitmap.Size;
				colored = false;
			}
			else
			{
				colored = true;
			}
		}

		protected Bitmap CreateBitmap(Color cl, Size sz)
		{
			Bitmap bitmap = new Bitmap(sz.Width, sz.Height);
			System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap);
			SolidBrush solidBrush = new SolidBrush(cl);
			graphics.FillRectangle(solidBrush, 0, 0, sz.Width - 1, sz.Height - 1);
			OnCreateBitmap(graphics, bitmap);
			solidBrush.Dispose();
			graphics.Dispose();
			return bitmap;
		}

		protected virtual void OnCreateBitmap(System.Drawing.Graphics g, Bitmap bmp)
		{
		}

		public LayeredForm(Color cl, Size sz)
		{
			Init(CreateBitmap(cl, sz));
			colored = true;
			this.cl = cl;
		}

		public void RefreshBitmap()
		{
			if (!base.Visible)
			{
				dorefresh = true;
				return;
			}

			SelectBitmap(CreateBitmap(cl, base.Size));
			dorefresh = false;
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			if (colored)
			{
				RefreshBitmap();
			}
		}

		protected override void OnVisibleChanged(EventArgs e)
		{
			try
			{
				base.OnVisibleChanged(e);
				if (dorefresh && base.Visible)
				{
					RefreshBitmap();
				}
			}
			catch
			{
			}
		}

		public void SelectBitmap(Bitmap bitmap)
		{
			if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
			{
				throw new ApplicationException("The bitmap must be 32bpp with alpha-channel.");
			}

			IntPtr dC = APIHelp.GetDC(IntPtr.Zero);
			IntPtr intPtr = APIHelp.CreateCompatibleDC(dC);
			IntPtr intPtr2 = IntPtr.Zero;
			IntPtr hObject = IntPtr.Zero;
			try
			{
				intPtr2 = bitmap.GetHbitmap(Color.FromArgb(0));
				hObject = APIHelp.SelectObject(intPtr, intPtr2);
				APIHelp.Size psize = new APIHelp.Size(bitmap.Width, bitmap.Height);
				APIHelp.Point pprSrc = new APIHelp.Point(0, 0);
				APIHelp.Point pptDst = new APIHelp.Point(base.Left, base.Top);
				APIHelp.BLENDFUNCTION pblend = default(APIHelp.BLENDFUNCTION);
				pblend.BlendOp = 0;
				pblend.BlendFlags = 0;
				pblend.SourceConstantAlpha = byte.MaxValue;
				pblend.AlphaFormat = 1;
				APIHelp.CallUpdateLayeredWindow(base.Handle, dC, ref pptDst, ref psize, intPtr, ref pprSrc, 0, ref pblend, 2);
			}
			finally
			{
				APIHelp.ReleaseDC(IntPtr.Zero, dC);
				if (intPtr2 != IntPtr.Zero)
				{
					APIHelp.SelectObject(intPtr, hObject);
					APIHelp.DeleteObject(intPtr2);
				}

				APIHelp.DeleteDC(intPtr);
			}
		}

		internal bool Hit(Point scrpt)
		{
			if (!base.Visible)
			{
				return false;
			}

			Point screenLocation = ScreenLocation;
			if (scrpt.X > screenLocation.X && scrpt.X < screenLocation.X + base.Width && scrpt.Y > screenLocation.Y && scrpt.Y < screenLocation.Y + base.Height)
			{
				return true;
			}

			return false;
		}
	}
}
