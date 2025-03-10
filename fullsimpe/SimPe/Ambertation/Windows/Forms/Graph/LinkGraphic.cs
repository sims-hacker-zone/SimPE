// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.ComponentModel;
using System.Drawing;

namespace Ambertation.Windows.Forms.Graph
{
	/// <summary>
	/// This calss describes one possible Dock Point for a Controls
	/// </summary>
	public class DockPoint
	{
		public DockPoint(int x, int y, LinkControlType type)
		{
			X = x;
			Y = y;
			Type = type;
		}

		public int X
		{
			get; set;
		}
		public int Y
		{
			get; set;
		}

		public LinkControlType Type
		{
			get;
		}

		public double Distance(DockPoint d)
		{
			return Math.Sqrt(Math.Pow(X - d.X, 2) + Math.Pow(Y - d.Y, 2));
		}

		public bool IsSideDock
		{
			get
			{
				int yl = ((byte)Type >> 2) & 0x3;
				return yl == 0x2;
			}
		}

		public bool IsCenterDock
		{
			get
			{
				int xl = (byte)Type & 0x3;
				int yl = ((byte)Type >> 2) & 0x3;
				return yl == 0x2 || xl == 0x2;
			}
		}
	}

	public enum LinkControlType : byte
	{
		TopLeft = 0x0, //00 00
		TopCenter = 0x2, //00 10
		TopRight = 0x3, // 00 11
		MiddleRight = 0xb, // 10 11
		BottomRight = 0xf, // 11 11
		BottomCenter = 0xe, // 11 10
		BottomLeft = 0xc, // 11 00
		MiddleLeft = 0x8, //10 00
	}

	public enum LinkControlLineMode : byte
	{
		Line = 0x0,
		Stair = 0x1,
		Bezier = 0x2,
	}

	public enum LinkControlCapType : byte
	{
		None = 0xff,
		Disk = 0x0,
		Arrow = 0x1,
	}

	public enum LinkControlSnapAnchor : byte
	{
		None = 0xff,
		Normal = 0x0,
		OnlyCenter = 0x1,
	}

	/// <summary>
	/// This Control draws a LinkLine between two Controls
	/// </summary>
	public class LinkGraphic : GraphPanelElement
	{
		public LinkGraphic()
		{
			sa = 0;
			ea = 0;
			lclm = LinkControlLineMode.Bezier;
			psa = LinkControlCapType.Disk;
			pea = LinkControlCapType.Arrow;
			ssa = LinkControlSnapAnchor.OnlyCenter;
			esa = LinkControlSnapAnchor.Normal;
			txt = "";
			fnt = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);

			tfg = SystemColors.WindowText;
			tbg = SystemColors.Window;
			lw = 2;
		}

		public override void Dispose()
		{
			base.Dispose();
			Clear();
		}

		#region Public Properties
		Font fnt;
		public Font Font
		{
			get => fnt;
			set
			{
				if (fnt != value)
				{
					fnt = value;
					Refresh();
				}
			}
		}

		GraphItemBase sc,
			ec;

		/// <summary>
		/// Returns /Sets the Start Control
		/// </summary>
		public GraphItemBase StartElement
		{
			get => sc;
			set
			{
				if (sc != value)
				{
					SetupAnchor(sc, false);
					sc = value;
					SetupAnchor(sc, true);
					AlignToControl();
					MoveControl();
					CompleteRedraw();
					Refresh();
				}
			}
		}

		/// <summary>
		/// Returns /Sets the End Control
		/// </summary>
		public GraphItemBase EndElement
		{
			get => ec;
			set
			{
				if (ec != value)
				{
					SetupAnchor(ec, false);
					ec = value;
					SetupAnchor(ec, true);
					AlignToControl();
					MoveControl();
					CompleteRedraw();
					Refresh();
				}
			}
		}

		LinkControlSnapAnchor ssa,
			esa;

		/// <summary>
		/// Returns / Sets whether or not the StartAnchor should auto snap to the StartElement
		/// </summary>
		public LinkControlSnapAnchor StartAnchorSnap
		{
			get => ssa;
			set
			{
				if (ssa != value)
				{
					ssa = value;
					AlignToControl();
					MoveControl();
					CompleteRedraw();
					Refresh();
				}
			}
		}

		/// <summary>
		/// Returns / Sets whether or not the EndAnchor should auto snap to the EndElement
		/// </summary>
		public LinkControlSnapAnchor EndAnchorSnap
		{
			get => esa;
			set
			{
				if (esa != value)
				{
					esa = value;
					AlignToControl();
					MoveControl();
					CompleteRedraw();
					Refresh();
				}
			}
		}

		byte sa,
			ea;

		/// <summary>
		/// Returns / Sets the start Anchor
		/// </summary>
		public byte StartAnchor
		{
			get => sa;
			set
			{
				if (sa != value)
				{
					sa = value;
					CompleteRedraw();
					Refresh();
				}
			}
		}

		/// <summary>
		/// Returns / Sets the end Anchor
		/// </summary>
		public byte EndAnchor
		{
			get => ea;
			set
			{
				if (ea != value)
				{
					ea = value;

					CompleteRedraw();
					Refresh();
				}
			}
		}

		int lw;

		/// <summary>
		/// The Width of the Lines this Control draws
		/// </summary>
		public int LineWidth
		{
			get => lw;
			set
			{
				if (lw != value)
				{
					lw = value;
					CompleteRedraw();
					Refresh();
				}
			}
		}

		LinkControlCapType psa,
			pea;

		/// <summary>
		/// Returns / Sets wether or not to draw an Error on the start of the Line
		/// </summary>
		public LinkControlCapType StartCap
		{
			get => psa;
			set
			{
				if (psa != value)
				{
					psa = value;
					CompleteRedraw();
					Refresh();
				}
			}
		}

		/// <summary>
		/// Returns / Sets wether or not to draw an Error on the end of the Line
		/// </summary>
		public LinkControlCapType EndCap
		{
			get => pea;
			set
			{
				if (pea != value)
				{
					pea = value;
					CompleteRedraw();
					Refresh();
				}
			}
		}

		LinkControlLineMode lclm;

		/// <summary>
		/// Returns / Sets the type of the Line
		/// </summary>
		public LinkControlLineMode LineMode
		{
			get => lclm;
			set
			{
				if (lclm != value)
				{
					lclm = value;
					CompleteRedraw();
					Refresh();
				}
			}
		}

		string txt;
		public string Text
		{
			get => txt;
			set
			{
				txt = value;
				SetBounds(Left, Top, Width, Height);
				Invalidate();
			}
		}

		Color tbg,
			tfg;
		public Color TextBackColor
		{
			get => tbg;
			set
			{
				if (tbg != value)
				{
					tbg = value;
					CompleteRedraw();
					Refresh();
				}
			}
		}

		public Color TextForeColor
		{
			get => tfg;
			set
			{
				if (tfg != value)
				{
					tfg = value;
					CompleteRedraw();
					Refresh();
				}
			}
		}
		#endregion

		#region Properties
		[Browsable(false)]
		public int SnapThreshhold => 12;
		#endregion


		#region Drawing Support Methods

		protected System.Drawing.Drawing2D.CustomLineCap PaintCap(
			System.Drawing.Graphics g,
			Pen pen,
			Point loc,
			LinkControlCapType lcct,
			bool start
		)
		{
			Size hasz = HalfArrowSize;
			Size asz = ArrowSize;
			if (lcct == LinkControlCapType.Arrow)
			{
				if (start)
				{
					pen.CustomStartCap =
						new System.Drawing.Drawing2D.AdjustableArrowCap(
							hasz.Width,
							hasz.Height
						);
				}
				else
				{
					pen.CustomEndCap = new System.Drawing.Drawing2D.AdjustableArrowCap(
						hasz.Width,
						hasz.Height
					);
				}
			}
			else if (lcct == LinkControlCapType.Disk)
			{
				g.FillEllipse(
					new SolidBrush(ForeColor),
					loc.X - hasz.Width,
					loc.Y - hasz.Height,
					asz.Width,
					asz.Height
				);
			}

			return null;
		}

		protected void DrawNiceRoundRect(
			System.Drawing.Graphics gr,
			int left,
			int top,
			int width,
			int height,
			int rad
		)
		{
			Rectangle srect = new Rectangle(left, top, width - 1, height - 1);

			Pen linepen = new Pen(ForeColor);
			Brush b = new SolidBrush(TextBackColor);
			Drawing.GraphicRoutines.FillRoundRect(gr, b, srect, rad);
			b.Dispose();

			Drawing.GraphicRoutines.DrawRoundRect(gr, linepen, srect, rad);
			linepen.Dispose();
		}
		#endregion

		#region Placement
		public static Size ArrowSize => new Size(8, 8);

		public static Size HalfArrowSize => new Size(ArrowSize.Width / 2, ArrowSize.Height / 2);

		protected Point GetAnchorLocation(byte lca, GraphItemBase c)
		{
			return GetAnchorLocation(lca, c, new Point(0, 0));
		}

		protected Point GetAnchorLocation(byte lca, GraphItemBase c, Point offset)
		{
			return new Point(c.Docks[lca].X - offset.X, c.Docks[lca].Y - offset.Y);
		}

		protected Point MinPoint(Point p1, Point p2)
		{
			return new Point(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y));
		}

		protected Point MaxPoint(Point p1, Point p2)
		{
			return new Point(Math.Max(p1.X, p2.X), Math.Max(p1.Y, p2.Y));
		}

		protected void MoveControl()
		{
			if (sc == null || ec == null)
			{
				return;
			}

			Point pstart = GetAnchorLocation(sa, sc);
			Point pend = GetAnchorLocation(ea, ec);
			Size asz = HalfArrowSize;

			Point min = MinPoint(pstart, pend);
			Point max = MaxPoint(pstart, pend);
			min.X -= asz.Width;
			min.Y -= asz.Height;
			max.X += asz.Width;
			max.Y += asz.Height;

			int wd = max.X - min.X;
			int hg = max.Y - min.Y;
			int left = min.X;
			int top = min.Y;

			if (Text != "")
			{
				Bitmap b = new Bitmap(1, 1);
				System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(b);
				SizeF sz = g.MeasureString(Text, Font);
				g.Dispose();
				b.Dispose();
				int nwd = (int)Math.Max(sz.Width + 5, wd);
				int nhg = (int)Math.Max(sz.Height + 5, hg);

				left -= (nwd - wd) / 2;
				top -= (nhg - hg) / 2;
				wd = nwd;
				hg = nhg;
			}
			SetBounds(left, top, wd, hg);
		}

		protected void AlignToControl()
		{
			if (
				sc == null
				|| ec == null
				|| (
					ssa == LinkControlSnapAnchor.None
					&& esa == LinkControlSnapAnchor.None
				)
			)
			{
				return;
			}

			Point b = GraphItemBase.FindBestDocks(sc.Docks, ssa, sa, ec.Docks, esa, ea);
			sa = (byte)b.X;
			ea = (byte)b.Y;
		}
		#endregion

		#region Basic Draw Methods
		protected void AddBezierPath(
			System.Drawing.Drawing2D.GraphicsPath path,
			Point pstart,
			Point pend,
			bool sside,
			bool eside
		)
		{
			Point ctrl1 = new Point(pstart.X, pstart.Y + (Height / 2));
			Point ctrl2 = new Point(pend.X, pend.Y - (Height / 2));
			if (sside)
			{
				ctrl1 = pend.X < pstart.X ? new Point(pstart.X - (Width / 2), pstart.Y) : new Point(pstart.X + (Width / 2), pstart.Y);
			}
			else
			{
				if (pend.Y < pstart.Y)
				{
					ctrl1 = new Point(pstart.X, pstart.Y - (Height / 2));
				}
			}
			if (EndElement.Docks[EndAnchor].IsSideDock)
			{
				ctrl2 = pend.X < pstart.X ? new Point(pend.X + (Width / 2), pend.Y) : new Point(pend.X - (Width / 2), pend.Y);
			}
			else
			{
				if (pend.Y < pstart.Y)
				{
					ctrl2 = new Point(pend.X, pend.Y + (Height / 2));
				}
			}

			path.AddBezier(
				pstart.X,
				pstart.Y,
				ctrl1.X,
				ctrl1.Y,
				ctrl2.X,
				ctrl2.Y,
				pend.X,
				pend.Y
			);
		}

		protected override void UserDraw(System.Drawing.Graphics g)
		{
			if (sc == null || ec == null)
			{
				return;
			}

			Size asz = HalfArrowSize;
			Point pstart = GetAnchorLocation(sa, sc, Location);
			Point pend = GetAnchorLocation(ea, ec, Location);

			System.Drawing.Drawing2D.GraphicsPath path =
				new System.Drawing.Drawing2D.GraphicsPath();

			if (lclm == LinkControlLineMode.Line || (pstart.X == pend.X))
			{
				path.AddLine(pstart.X, pstart.Y, pend.X, pend.Y);
			}
			else if (lclm == LinkControlLineMode.Bezier)
			{
				if (
					Text != ""
					&& EndElement.Docks[EndAnchor].IsSideDock
						!= StartElement.Docks[StartAnchor].IsSideDock
				)
				{
					Point pmid = new Point(
						(pstart.X + pend.X) / 2,
						(pstart.Y + pend.Y) / 2
					);
					AddBezierPath(
						path,
						pstart,
						pmid,
						StartElement.Docks[StartAnchor].IsSideDock,
						StartElement.Docks[StartAnchor].IsSideDock
					);
					AddBezierPath(
						path,
						pmid,
						pend,
						EndElement.Docks[EndAnchor].IsSideDock,
						EndElement.Docks[EndAnchor].IsSideDock
					);
				}
				else
				{
					AddBezierPath(
						path,
						pstart,
						pend,
						StartElement.Docks[StartAnchor].IsSideDock,
						EndElement.Docks[EndAnchor].IsSideDock
					);
				}
			}
			else
			{
				if (
					EndElement.Docks[EndAnchor].IsSideDock
					&& StartElement.Docks[StartAnchor].IsSideDock
				)
				{
					path.AddLine(pstart.X, pstart.Y, Width / 2, pstart.Y);
					path.AddLine(Width / 2, pstart.Y, Width / 2, pend.Y);
					path.AddLine(Width / 2, pend.Y, pend.X, pend.Y);
				}
				else
				{
					path.AddLine(pstart.X, pstart.Y, pstart.X, Height / 2);
					path.AddLine(pstart.X, Height / 2, pend.X, Height / 2);
					path.AddLine(pend.X, Height / 2, pend.X, pend.Y);
				}
			}

			Pen pen = new Pen(ForeColor, lw);

			PaintCap(g, pen, pstart, psa, true);
			PaintCap(g, pen, pend, pea, false);
			g.DrawPath(pen, path);

			if (Text != "")
			{
				SizeF sz = g.MeasureString(Text, Font);
				Rectangle trec = new Rectangle(
					(int)((Width - sz.Width + 4) / 2) - 4,
					(int)((Height - sz.Height + 4) / 2) - 4,
					(int)sz.Width + 5,
					(int)sz.Height + 4
				);
				DrawNiceRoundRect(
					g,
					trec.X,
					trec.Y,
					trec.Width,
					trec.Height,
					(int)sz.Height / 2
				);
				SolidBrush b = new SolidBrush(TextForeColor);
				g.DrawString(Text, Font, b, trec.Left + 2, trec.Top + 2);
				b.Dispose();
			}

			pen.Dispose();
		}
		#endregion

		#region Anchor Controls
		protected void SetupAnchor(GraphPanelElement c, bool load)
		{
			if (c == null)
			{
				return;
			}

			if (load)
			{
				c.Move += new EventHandler(c_Move);
				c.SizeChanged += new EventHandler(c_SizeChanged);
			}
			else
			{
				c.Move -= new EventHandler(c_Move);
				c.SizeChanged -= new EventHandler(c_SizeChanged);
			}
		}

		private void c_Move(object sender, EventArgs e)
		{
			AlignToControl();
			MoveControl();
			CompleteRedraw();
		}
		#endregion

		private void c_SizeChanged(object sender, EventArgs e)
		{
			AlignToControl();
			MoveControl();
			CompleteRedraw();
		}

		public override void Clear()
		{
			StartElement = null;
			EndElement = null;
			SetBounds(0, 0, 1, 1);
		}
	}
}
