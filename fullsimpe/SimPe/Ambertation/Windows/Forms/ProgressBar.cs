using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Ambertation.Windows.Forms
{
	public partial class ProgressBar : UserControl
	{
		public ProgressBar()
		{
			InitializeComponent();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			DateTime dt = DateTime.Now;
			//Console.WriteLine("Start");
			LinearGradientBrush b = new LinearGradientBrush(
				Bounds,
				Color.FromArgb(80, Color.Wheat),
				Color.FromArgb(50, Color.White),
				LinearGradientMode.ForwardDiagonal
			);
			for (int i = 0; i < 50000; i++)
			{
				DoThePainting(e, b);
			}

			TimeSpan ts = DateTime.Now - dt;
			//Console.WriteLine("End: "+ts);
		}

		private void DoThePainting(PaintEventArgs e, Brush b)
		{
			Rectangle r1 = new Rectangle(0, 0, Width / 2, Height);
			Rectangle r2 = new Rectangle(Width / 2, 0, Width / 2, Height);
			e.Graphics.FillRectangle(b, r1);
			e.Graphics.FillRectangle(b, r2);
		}
	}
}
