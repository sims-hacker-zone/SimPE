// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Drawing;

using Ambertation.Collections;

namespace Ambertation.Windows.Forms.Graph
{
	/// <summary>
	/// This is a Image Panel
	/// </summary>
	public class ExtendedImagePanel : ImagePanel
	{
		public ExtendedImagePanel()
			: this(new PropertyItems()) { }

		public ExtendedImagePanel(PropertyItems properties)
			: base()
		{
			this.properties = properties;
		}

		#region public Properties
		PropertyItems properties;
		public PropertyItems Properties
		{
			get => properties;
			set
			{
				if (value != properties)
				{
					properties = value;
					Invalidate();
				}
			}
		}
		#endregion

		#region Basic Draw Methods

		Rectangle ThumbnailRectangle
		{
			get
			{
				int tw = 48;
				int th = 48;
				if (Image != null)
				{
					tw = Image.Width;
					th = Image.Height;
				}

				Rectangle trec = new Rectangle(
					2 + ImageBorderWidth,
					2 + ImageBorderWidth,
					tw,
					th
				);
				return trec;
			}
		}

		Rectangle PanelRectangle => new Rectangle(
					10 + ImageBorderWidth,
					10 + ImageBorderWidth,
					Width - 10 - ImageBorderWidth,
					Height - 10 - ImageBorderWidth
				);

		protected override void UserDraw(System.Drawing.Graphics gr)
		{
			Rectangle prec = PanelRectangle;
			int rad = Math.Min(Math.Min(8, prec.Height / 2), prec.Width / 2);
			DrawNiceRoundRect(
				gr,
				prec.Left,
				prec.Top,
				prec.Width,
				prec.Height,
				rad,
				PanelColor
			);
			Rectangle trec = ThumbnailRectangle;
			rad = Math.Min(Math.Min(8, trec.Height / 2), trec.Width / 2);

			DrawText(gr, prec, trec);
			DrawThumbnail(gr, trec, rad);
		}

		protected void DrawText(
			System.Drawing.Graphics gr,
			Rectangle prec,
			Rectangle trec
		)
		{
			if (properties == null)
			{
				return;
			}

			SetGraphicsMode(gr, !Quality);

			Font ftb = new Font(Font.FontFamily, Font.Size, FontStyle.Bold, Font.Unit);
			DrawCaption(
				gr,
				new Rectangle(
					trec.Right + 2,
					prec.Top,
					prec.Width - (trec.Right - prec.Left) - 4 - ImageBorderWidth,
					16
				),
				ftb,
				false
			);
			Pen linepen = new Pen(Color.FromArgb(90, Color.Black));
			gr.DrawLine(
				linepen,
				new Point(prec.Left, prec.Top + 16),
				new Point(prec.Right, prec.Top + 16)
			);
			linepen.Dispose();

			StringFormat sf = new StringFormat
			{
				FormatFlags = StringFormatFlags.NoWrap
			};
			int top = prec.Top + 24;
			Size indent = new Size(
				trec.Right + 6,
				trec.Bottom - prec.Top + 7 + (2 * ImageBorderWidth)
			);

			//Hashtable ht = new Hashtable();
			foreach (string k in properties.Keys)
			{
				PropertyItem o = properties[k];
				if (o == null)
				{
					continue;
				}

				string val = "";
				val = (string)o.Value;

				if (val != null)
				{
					int indentx = prec.Left + 6;
					if (top < indent.Height)
					{
						indentx = indent.Width;
					}

					Font ft = new Font(
						Font.FontFamily,
						Font.Size,
						FontStyle.Italic,
						Font.Unit
					);

					gr.DrawString(
						k + ":",
						ft,
						new Pen(Color.FromArgb(160, ForeColor)).Brush,
						new RectangleF(
							new PointF(indentx, top),
							new SizeF(prec.Width - indentx, top + 16)
						),
						sf
					);
					SizeF sz = gr.MeasureString(k + ":", ft);

					gr.DrawString(
						val,
						Font,
						new Pen(Color.FromArgb(140, ForeColor)).Brush,
						new RectangleF(
							new PointF(indentx + sz.Width, top),
							new SizeF(prec.Width - indentx - sz.Width, top + 16)
						),
						sf
					);
					SizeF sz2 = gr.MeasureString(val, Font);

					Rectangle rect = new Rectangle(
						new Point((int)(indentx + sz.Width), top),
						new Size((int)(prec.Width - indentx - sz.Width), top + 16)
					);

					top += (int)Math.Max(sz.Height, sz2.Height);
					ft.Dispose();
				}
			}
		}

		#endregion

		protected override void InitDocks()
		{
			if (docks == null)
			{
				docks = new DockPoint[8];

				docks[0] = new DockPoint(0, 0, LinkControlType.MiddleLeft);
				docks[1] = new DockPoint(0, 0, LinkControlType.MiddleRight);

				docks[2] = new DockPoint(0, 0, LinkControlType.TopCenter);
				docks[3] = new DockPoint(0, 0, LinkControlType.TopLeft);
				docks[4] = new DockPoint(0, 0, LinkControlType.TopRight);

				docks[5] = new DockPoint(0, 0, LinkControlType.BottomCenter);
				docks[6] = new DockPoint(0, 0, LinkControlType.BottomLeft);
				docks[7] = new DockPoint(0, 0, LinkControlType.BottomRight);
			}
		}

		protected override void SetupDocks()
		{
			if (docks == null)
			{
				InitDocks();
			}

			Rectangle trec = ThumbnailRectangle;
			trec = new Rectangle(
				trec.Left - ImageBorderWidth - 2,
				trec.Top - ImageBorderWidth - 2,
				trec.Width + (2 * ImageBorderWidth) + 4,
				trec.Height + (2 * ImageBorderWidth) + 4
			);
			;
			Rectangle prec = PanelRectangle;

			docks[0].X = Left + trec.Left;
			docks[0].Y = Top + trec.Bottom;
			docks[1].X = Left + prec.Right;
			docks[1].Y = Top + prec.Top + (prec.Height / 2);

			docks[2].X = Left + trec.Right;
			docks[2].Y = Top + trec.Top;
			docks[3].X = Left + trec.Left;
			docks[3].Y = Top + trec.Top;
			docks[4].X = Left + prec.Right;
			docks[4].Y = Top + prec.Top;

			docks[5].X = Left + prec.Left + (prec.Width / 2);
			docks[5].Y = Top + prec.Bottom;
			docks[6].X = Left + prec.Left;
			docks[6].Y = Top + prec.Bottom;
			docks[7].X = Left + prec.Left + prec.Width;
			docks[7].Y = Top + prec.Bottom;
		}
	}
}
