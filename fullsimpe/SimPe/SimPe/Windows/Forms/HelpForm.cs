// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Drawing;

using Ambertation.Windows.Forms;

namespace SimPe.Windows.Forms
{
	public partial class HelpForm : TransparentForm //Ambertation.Windows.Forms.LayeredForm
	{
		static Image top,
			bottom,
			center;
		Rectangle headerrect;

		public HelpForm()
			: base() //Color.Transparent, new Size(781, 475))
		{
			InitializeComponent();
			MinimumSize = new Size(1024, 661);
			MaximumSize = new Size(1024, 2048);
		}

		protected override void OnCreateBitmap(Graphics g, Bitmap b)
		{
			//base.OnCreateBitmap(g, b);
			if (top == null)
			{
				top = Image.FromStream(
					typeof(HelpForm).Assembly.GetManifestResourceStream(
						"SimPe.img.top.png"
					)
				);
				center = Image.FromStream(
					typeof(HelpForm).Assembly.GetManifestResourceStream(
						"SimPe.img.center.png"
					)
				);
				bottom = Image.FromStream(
					typeof(HelpForm).Assembly.GetManifestResourceStream(
						"SimPe.img.bottom.png"
					)
				);
			}
			headerrect = new Rectangle(0, 0, top.Width, top.Height);

			// g.DrawImage(top, new Point(0, 0)); // this goes wonky if you scale up Windows Fonts
			g.DrawImage(top, headerrect);
			int y = top.Height;
			int my = b.Height - bottom.Height;
			while (y < my)
			{
				g.DrawImage(center, new Point(0, y));
				y += center.Height;
			}
			g.DrawImage(bottom, new Point(0, my));

			g.Dispose();
		}

		protected override Rectangle HeaderRect => headerrect;
	}
}
