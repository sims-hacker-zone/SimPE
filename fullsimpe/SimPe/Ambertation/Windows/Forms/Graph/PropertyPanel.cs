// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Drawing;

using Ambertation.Collections;

namespace Ambertation.Windows.Forms.Graph
{
	/// <summary>
	/// This is a Rounded Panel
	/// </summary>
	public abstract class PropertyPanel : RoundedPanel
	{
		public PropertyPanel()
			: this(new PropertyItems()) { }

		public PropertyPanel(PropertyItems properties)
			: base()
		{
			this.properties = properties;
			txt = "";
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

		Image thumb;
		public Image Thumbnail
		{
			get => thumb;
			set
			{
				thumb = value;
				Invalidate();
			}
		}

		string txt;
		public string Text
		{
			get => txt;
			set
			{
				txt = value;
				Invalidate();
			}
		}

		#endregion

		#region Basic Draw Methods

		protected override void DrawText(System.Drawing.Graphics gr)
		{
			if (properties == null)
			{
				return;
			}

			SetGraphicsMode(gr, !Quality);

			Pen linepen = new Pen(Color.FromArgb(90, Color.Black));
			gr.DrawLine(linepen, new Point(0, 20), new Point(Width, 20));
			linepen.Dispose();

			StringFormat sf = new StringFormat
			{
				FormatFlags = StringFormatFlags.NoWrap
			};
			Font ftb = new Font(Font.FontFamily, Font.Size, FontStyle.Bold, Font.Unit);
			gr.DrawString(
				Text,
				ftb,
				new Pen(ForeColor).Brush,
				new RectangleF(new PointF(4, 4), new SizeF(Width - 8, Height - 8)),
				sf
			);
			ftb.Dispose();
			int top = 24;
			Size indent = new Size(0, 0);
			if (thumb != null)
			{
				gr.DrawImageUnscaled(thumb, 4, top, thumb.Width, thumb.Height);
				indent = new Size(thumb.Width + 4, top + thumb.Height + 4);
			}

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
					int indentx = 0;
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
							new PointF(indentx + 10, top),
							new SizeF(Width - (24 + indentx), top + 16)
						),
						sf
					);
					SizeF sz = gr.MeasureString(k + ":", ft);

					gr.DrawString(
						val,
						Font,
						new Pen(Color.FromArgb(140, ForeColor)).Brush,
						new RectangleF(
							new PointF(indentx + 12 + sz.Width, top),
							new SizeF(Width - (24 + sz.Width + indentx), top + 16)
						),
						sf
					);
					SizeF sz2 = gr.MeasureString(val, Font);

					Rectangle rect = new Rectangle(
						new Point((int)(indentx + 12 + sz.Width), top),
						new Size((int)(Width - (24 + sz.Width + indentx)), top + 16)
					);

					top += (int)Math.Max(sz.Height, sz2.Height);
					ft.Dispose();
				}
			}
		}

		#endregion
	}
}
