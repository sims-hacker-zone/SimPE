using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Ambertation.Graphics;

namespace Ambertation.Windows.Forms
{
	public class TransparentForm : Form
	{
		private IContainer components;

		private Rectangle headrect;

		private Form tf;

		private Bitmap bitmap;

		protected virtual Rectangle HeaderRect => headrect;

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				if (!base.DesignMode)
				{
					createParams.ExStyle |= 524288;
					createParams.ExStyle |= 128;
				}

				return createParams;
			}
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
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Text = "HelpForm";
		}

		public TransparentForm()
		{
			base.TopMost = true;
			base.ShowInTaskbar = false;
			headrect = Rectangle.Empty;
			InitializeComponent();
			if (!base.DesignMode)
			{
				CreateHelperForm();
			}
		}

		private void CreateHelperForm()
		{
			if (tf != null || base.DesignMode)
			{
				return;
			}

			tf = new Form();
			tf.SetBounds(base.Left, base.Top, base.Width, base.Height);
			tf.FormBorderStyle = FormBorderStyle.None;
			tf.TransparencyKey = tf.BackColor;
			foreach (Control control in base.Controls)
			{
				tf.Controls.Add(control);
			}

			tf.ShowInTaskbar = false;
			tf.TopMost = true;
			tf.FormClosed += tf_FormClosed;
			if (base.Visible)
			{
				tf.Show(this);
				tf.SetBounds(base.Left, base.Top, base.Width, base.Height);
				tf.Activate();
			}
		}

		private void tf_FormClosed(object sender, FormClosedEventArgs e)
		{
			Close();
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing(e);
			base.Size = new Size(0, 0);
			if (tf != null)
			{
				tf.FormClosed -= tf_FormClosed;
				tf.Close();
			}
		}

		protected override void OnControlAdded(ControlEventArgs e)
		{
			base.OnControlAdded(e);
			if (tf != null && !base.DesignMode)
			{
				tf.Controls.Add(e.Control);
			}
		}

		protected void SelectBitmap()
		{
			if (bitmap == null)
			{
				CreateBitmap();
			}

			if (base.DesignMode)
			{
				return;
			}

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

		protected override void OnLocationChanged(EventArgs e)
		{
			if (tf != null && !base.DesignMode)
			{
				tf.SetBounds(base.Left, base.Top, base.Width, base.Height);
			}

			base.OnLocationChanged(e);
			SelectBitmap();
		}

		protected override void OnResize(EventArgs e)
		{
			if (tf != null && !base.DesignMode)
			{
				tf.SetBounds(base.Left, base.Top, base.Width, base.Height);
			}

			UpdateBitmap(force: false);
			base.OnResize(e);
		}

		protected override void OnVisibleChanged(EventArgs e)
		{
			base.OnVisibleChanged(e);
			if (!base.DesignMode)
			{
				if (base.Visible)
				{
					if (tf != null)
					{
						tf.SetBounds(base.Left, base.Top, base.Width, base.Height);
						tf.Show(this);
						tf.SetBounds(base.Left, base.Top, base.Width, base.Height);
						tf.Activate();
					}
				}
				else if (tf != null)
				{
					tf.Hide();
				}
			}

			SelectBitmap();
		}

		protected void UpdateBitmap(bool force)
		{
			if (bitmap != null)
			{
				if (!force && bitmap.Width == base.Width && bitmap.Height == base.Height)
				{
					return;
				}

				bitmap.Dispose();
				bitmap = null;
			}

			bitmap = CreateBitmap();
		}

		private Bitmap CreateBitmap()
		{
			Bitmap bitmap = new Bitmap(Math.Max(1, base.Width), Math.Max(1, base.Height));
			System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap);
			OnCreateBitmap(graphics, bitmap);
			graphics.Dispose();
			return bitmap;
		}

		protected virtual void OnCreateBitmap(System.Drawing.Graphics g, Bitmap b)
		{
		}

		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 132)
			{
				int num = m.LParam.ToInt32();
				Point p = new Point(num & 0xFFFF, num >> 16);
				Point pt = PointToClient(p);
				if (HeaderRect.Contains(pt))
				{
					m.Result = new IntPtr(2);
					return;
				}
			}

			base.WndProc(ref m);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground(e);
			SelectBitmap();
			if (base.DesignMode)
			{
				base.OnPaintBackground(e);
				if (bitmap != null)
				{
					e.Graphics.DrawImage(bitmap, 0, 0);
				}
			}
		}
	}
}

