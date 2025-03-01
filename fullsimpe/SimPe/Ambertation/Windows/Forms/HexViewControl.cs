// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Ambertation.Windows.Forms
{
	/// <summary>
	/// This is a HexView Control
	/// </summary>
	public class HexViewControl : UserControl
	{
		/// <summary>
		/// Determins the ViewState of teh Control
		/// </summary>
		public enum ViewState
		{
			Hex,
			SignedDec,
			UnsignedDec,
		}

		#region Constants
		/// <summary>
		/// The Size of a HexBlock (number of Columsn per Block)
		/// </summary>
		const int BLOCKSIZE = 8;

		/// <summary>
		/// Spacing between two HexBlocks
		/// </summary>
		const int BLOCKSPACING = 4;

		/// <summary>
		/// Spacing between two Columns
		/// </summary>
		const int COLSPACING = 1;

		/// <summary>
		/// Spacing between the diffrent Windows
		/// </summary>
		const int WINDOWSPACING = 4;
		#endregion

		#region public Properties
		ViewState vs;

		/// <summary>
		/// Returns / sets the current ViewState
		/// </summary>
		public ViewState View
		{
			get => vs;
			set
			{
				if (vs != value)
				{
					vs = value;
					RedrawGraphics();
					Refresh();
				}
			}
		}

		bool hs;

		/// <summary>
		/// true, if you want to Highlight Zero Values
		/// </summary>
		public bool HighlightZeros
		{
			get => hs;
			set
			{
				if (hs != value)
				{
					hs = value;
					RedrawGraphics();
					Refresh();
				}
			}
		}

		public override Font Font
		{
			get => base.Font;
			set
			{
				base.Font = value;
				UpdateCharWidth();
				RedrawGraphics();
				Refresh();
			}
		}

		Image[] border;
		int offsetboxwidth;

		/// <summary>
		/// The Width of the Offset Listing Box
		/// </summary>
		public int OffsetBoxWidth
		{
			get => offsetboxwidth;
			set
			{
				offsetboxwidth = Math.Abs(value);

				RedrawGraphics();
				Refresh();
			}
		}

		int charboxwidth;

		/// <summary>
		/// The Width of the Character Listing Box
		/// </summary>
		public int CharBoxWidth
		{
			get => charboxwidth;
			set
			{
				charboxwidth = Math.Abs(value);

				RedrawGraphics();
				Refresh();
			}
		}

		Color fcfcol;

		/// <summary>
		/// Returns the BorderColor
		/// </summary>
		public Color FocusedForeColor
		{
			get => fcfcol;
			set
			{
				if (fcfcol != value)
				{
					fcfcol = value;

					RedrawGraphics();
					Refresh();
				}
			}
		}

		Color highcol;

		/// <summary>
		/// Returns the BorderColor
		/// </summary>
		public Color HighlightColor
		{
			get => highcol;
			set
			{
				if (highcol != value)
				{
					highcol = value;

					RedrawGraphics();
					Refresh();
				}
			}
		}

		Color highfcol;

		/// <summary>
		/// Returns the BorderColor
		/// </summary>
		public Color HighlightForeColor
		{
			get => highfcol;
			set
			{
				if (highfcol != value)
				{
					highfcol = value;

					RedrawGraphics();
					Refresh();
				}
			}
		}

		Color hcol;

		/// <summary>
		/// Save and set the Background Color
		/// </summary>
		public Color HeadColor
		{
			get => hcol;
			set
			{
				if (hcol != value)
				{
					hcol = value;

					RedrawGraphics();
					Refresh();
				}
			}
		}

		Color gcol;

		/// <summary>
		/// Save and set the Background Color
		/// </summary>
		public Color GridColor
		{
			get => gcol;
			set
			{
				if (gcol != value)
				{
					gcol = value;

					RedrawGraphics();
					Refresh();
				}
			}
		}

		Color hfcol;

		/// <summary>
		/// Save and set the Background Color
		/// </summary>
		public Color HeadForeColor
		{
			get => hfcol;
			set
			{
				if (hfcol != value)
				{
					hfcol = value;

					RedrawGraphics();
					Refresh();
				}
			}
		}

		Color hlcol;

		/// <summary>
		/// Save and set the Background Color
		/// </summary>
		public Color SelectionColor
		{
			get => hlcol;
			set
			{
				if (hlcol != value)
				{
					hlcol = value;

					RedrawGraphics();
					Refresh();
				}
			}
		}

		Color fccol;

		/// <summary>
		/// Save and set the Background Color
		/// </summary>
		public Color ZeroCellColor
		{
			get => fccol;
			set
			{
				if (fccol != value)
				{
					fccol = value;

					RedrawGraphics();
					Refresh();
				}
			}
		}

		Color hlfcol;

		/// <summary>
		/// Save and set the Background Color
		/// </summary>
		public Color SelectionForeColor
		{
			get => hlfcol;
			set
			{
				if (hlfcol != value)
				{
					hlfcol = value;

					RedrawGraphics();
					Refresh();
				}
			}
		}

		Color bkgrcol;

		/// <summary>
		/// Save and set the Background Colour
		/// </summary>
		public Color BackGroundColour
		{
			get => bkgrcol;
			set
			{
				if (bkgrcol != value)
				{
					bkgrcol = value;

					RedrawGraphics();
					Refresh();
				}
			}
		}

		Color backcol;

		/// <summary>
		/// Save and set the Background Color
		/// </summary>
		public override Color BackColor
		{
			get => backcol;
			set
			{
				if (backcol != value)
				{
					backcol = value;

					RedrawGraphics();
					Refresh();
				}
			}
		}

		byte cols;

		/// <summary>
		/// Number of 8-Column Blocks to display
		/// </summary>
		public byte Blocks
		{
			get => cols;
			set
			{
				if (cols != value)
				{
					cols = value;
					Refresh();
				}
			}
		}

		bool grid;
		public bool ShowGrid
		{
			get => grid;
			set
			{
				if (value != grid)
				{
					grid = value;

					RedrawGraphics();
					Refresh();
				}
			}
		}

		/// <summary>
		/// Returns the Font used for the Header
		/// </summary>
		public Font HeaderFont
		{
			get;
		}

		#endregion

		#region Properties
		Rectangle bm;

		/// <summary>
		/// Returns the Margin between the Content and the Border of a Box
		/// </summary>
		protected Rectangle BoxMargin
		{
			get => bm;
			set => bm = value;
		}

		byte[] data;

		/// <summary>
		/// The Content that should be displayed
		/// </summary>
		[Browsable(false)]
		public byte[] Data
		{
			get => data;
			set
			{
				data = value;
				if (data == null)
				{
					data = new byte[0];
				}

				UpdateRows(0);
				crow = 0;

				bool pause = this.pause;
				if (!pause)
				{
					BeginUpdate();
				}

				selection.Maximum = data.Length;
				Highlights.Clear();

				DoSelect(-1, 0);
				Refresh();
				if (!pause)
				{
					EndUpdate();
				}

				if (DataChanged != null)
				{
					DataChanged(this, new EventArgs());
				}
			}
		}

		/// <summary>
		/// Current Offset
		/// </summary>
		[Browsable(false)]
		public int Offset
		{
			get => SelectionStart < 0 ? 0 : SelectionStart;
			set => Select(value, 1);
		}

		/// <summary>
		/// Number of Columsn per Line
		/// </summary>
		[Browsable(false)]
		public int Columns => cols * BLOCKSIZE;

		/// <summary>
		/// Returns a Brush in BackgroundColor
		/// </summary>
		protected SolidBrush BackBrush => new SolidBrush(backcol);

		/// <summary>
		/// Returns a Brush in BackgroundColor
		/// </summary>
		protected SolidBrush HeadBackBrush => new SolidBrush(HeadColor);

		/// <summary>
		/// Returns a Brush in ForeColor
		/// </summary>
		protected SolidBrush ForeBrush => new SolidBrush(ForeColor);

		/// <summary>
		/// Returns a Brush in BackgroundColor
		/// </summary>
		protected SolidBrush HeadForeBrush => new SolidBrush(HeadForeColor);

		/// <summary>
		/// Returns the Pen for the Background Color
		/// </summary>
		protected Pen BorderPen => new Pen(fcfcol, 1);

		/// <summary>
		/// The Width of the Hex Listing Box, which is calculated by <see cref="Width"/> - (<see cref="OffsetBoxWidth"/> + <see cref="CharBoxWidth"/> + 8)
		/// </summary>
		protected float HexBoxWidth
		{
			get
			{
				float w =
					Width - (OffsetBoxWidth + CharBoxWidth + (2 * WINDOWSPACING) + 1)
				;
				if (sb != null)
				{
					if (sb.Visible)
					{
						w -= sb.Width + WINDOWSPACING;
					}
				}

				return w;
			}
		}

		/// <summary>
		/// Width of a single Column in the HexBox
		/// </summary>
		protected float HexBoxColumnWidth => (float)(
						HexBoxWidth
						- bm.Width
						- ((Columns - 1) * COLSPACING)
						- bm.Left
						- ((Blocks - 1) * BLOCKSPACING)
					) / Columns;

		/// <summary>
		/// Number of Rows needed to display the Data
		/// </summary>
		[Browsable(false)]
		public int Rows => Columns == 0 ? 0 : (Data.Length / Columns) + 1;

		int crow;

		/// <summary>
		/// Sets / Returns the current Row
		/// </summary>
		[Browsable(false)]
		public int CurrentRow
		{
			get => crow;
			set
			{
				int v = Math.Max(0, Math.Min(value, Rows - 1));
				if (v != crow)
				{
					MoveRows(v - crow);
					crow = v;
					Refresh();
				}
			}
		}

		/// <summary>
		/// Returns the Height of one Row
		/// </summary>
		protected float HexBoxRowHeight
		{
			get; private set;
		}

		Highlight selection;

		/// <summary>
		/// Where does sthe selection start (-1 for nothing)
		/// </summary>
		[Browsable(false)]
		public int SelectionStart => selection.Start;

		/// <summary>
		/// How long is the Selection
		/// </summary>
		[Browsable(false)]
		public int SelectionLength => selection.Length;

		/// <summary>
		/// Where does the Selection End
		/// </summary>
		[Browsable(false)]
		public int SelectionEnd => selection.End;

		float cwidth;

		/// <summary>
		/// Returns the width of one Character in the CHarBox
		/// </summary>
		protected float CharWidth
		{
			get
			{
				if (cwidth == 0)
				{
					UpdateCharWidth();
				}

				return cwidth;
			}
		}

		/// <summary>
		/// Returns the List of Highlighted Elements
		/// </summary>
		[Browsable(false)]
		public Collections.Highlights Highlights
		{
			get;
		}
		#endregion

		#region Fields
		ScrollBar sb;
		#endregion

		#region Events
		/// <summary>
		/// Fires, when the USers Scrolls
		/// </summary>
		public new event ScrollEventHandler Scroll;

		/// <summary>
		/// Fires, whenever the Selection get's changed
		/// </summary>
		public event EventHandler SelectionChanged;

		/// <summary>
		/// Fires, whenever the Data get's changed
		/// </summary>
		public event EventHandler DataChanged;
		#endregion

		#region Calulated Measurement
		/// <summary>
		/// Height of a single Column in the HexBox
		/// </summary>
		protected float UpdateHexBoxRowHeight()
		{
			SizeF layoutSize = new SizeF(HexBoxColumnWidth, 5000.0F);
			System.Drawing.Graphics g = System.Drawing.Graphics.FromHwnd(Handle);
			SizeF stringSize = g.MeasureString("0", Font, layoutSize);

			HexBoxRowHeight = stringSize.Height;
			return stringSize.Height + COLSPACING;
		}

		/// <summary>
		/// Width of a Single Character
		/// </summary>
		protected float UpdateCharWidth()
		{
			cwidth = GetTextWidth("W", Font);
			return cwidth;
		}

		/// <summary>
		/// Width of a Text
		/// </summary>
		protected float GetTextWidth(string s, Font f)
		{
			SizeF layoutSize = new SizeF(HexBoxColumnWidth, 5000.0F);
			System.Drawing.Graphics g = System.Drawing.Graphics.FromHwnd(Handle);
			SizeF stringSize = g.MeasureString(s, f, layoutSize);

			return stringSize.Width;
		}

		/// <summary>
		/// Set the OffsetBox and Character Box to the size defined by the current Font
		/// </summary>
		public void MatchSize()
		{
			offsetboxwidth =
				(int)Math.Ceiling(GetTextWidth("00000000", HeaderFont))
				+ bm.Left
				+ bm.Width;
			//if (DesignMode) this.offsetboxwidth = 83;
			charboxwidth =
				(Columns * ((int)CharWidth + COLSPACING)) + bm.Left + bm.Width;
		}

		/// <summary>
		/// Returns the Number of Rows that can be displayed on one Page
		/// </summary>
		/// <returns></returns>
		protected float GetHexBoxRowsPerPage()
		{
			int h =
				Height - (1 + bm.Top + bm.Height + COLSPACING) - (int)HexBoxRowHeight;
			return (float)(h / Math.Ceiling(HexBoxRowHeight + COLSPACING));
		}

		/// <summary>
		/// Returns the Number of Pages needed to display the Data
		/// </summary>
		/// <returns></returns>
		protected int GetNumberOfPages()
		{
			return Math.Max(0, Rows - (int)Math.Floor(GetHexBoxRowsPerPage()));
		}

		/// <summary>
		/// Returns the Top Location of the given Row
		/// </summary>
		/// <param name="index"></param>
		protected int GetVisibleRowTop(int index)
		{
			index++;
			return (int)((index * (HexBoxRowHeight + COLSPACING)) + bm.Top);
		}

		/// <summary>
		/// Returns the Left Location of the given Columns
		/// </summary>
		/// <param name="index"></param>
		protected int GetHexColLeft(int index)
		{
			return OffsetBoxWidth
				+ WINDOWSPACING
				+ (int)((index * (HexBoxColumnWidth + COLSPACING)) + bm.Left)
				+ (index / BLOCKSIZE * BLOCKSPACING);
		}

		/// <summary>
		/// Returns the Left Location of the given Columns
		/// </summary>
		/// <param name="index"></param>
		protected int GetCharColLeft(int index)
		{
			return OffsetBoxWidth
				+ (int)HexBoxWidth
				+ (2 * WINDOWSPACING)
				+ (index * ((int)CharWidth + COLSPACING)) + bm.Left;
		}

		#endregion

		/// <summary>
		/// Create a new Instance
		/// </summary>
		public HexViewControl()
		{
			data = new byte[0];

			vs = ViewState.Hex;
			offsetboxwidth = 100;
			charboxwidth = 200;
			cols = 2;
			grid = true;
			Highlights = new Collections.Highlights();

			backcol = SystemColors.ControlLightLight;
			bkgrcol = SystemColors.Control;
			fcfcol = Color.FromArgb(0x60, SystemColors.WindowFrame);
			hcol = SystemColors.InactiveCaption;
			gcol = Color.FromArgb(0x60, hcol);
			hfcol = SystemColors.InactiveCaptionText;
			hlcol = SystemColors.Highlight;
			hlfcol = SystemColors.HighlightText;
			fccol = Color.FromArgb(0x30, Color.Red);
			highcol = Color.FromArgb(0xb0, Color.Black);
			highfcol = Color.White;

			selection = new Highlight(0, 0, data.Length);

			bm = new Rectangle(6, 6, 6, 6);
			border = new Image[8];
			border[0] = Image.FromStream(
				GetType().Assembly.GetManifestResourceStream("SimPe.img.tl.png")
			);
			border[1] = Image.FromStream(
				GetType().Assembly.GetManifestResourceStream("SimPe.img.t.png")
			);
			border[2] = Image.FromStream(
				GetType().Assembly.GetManifestResourceStream("SimPe.img.tr.png")
			);
			border[3] = Image.FromStream(
				GetType().Assembly.GetManifestResourceStream("SimPe.img.r.png")
			);
			border[4] = Image.FromStream(
				GetType().Assembly.GetManifestResourceStream("SimPe.img.br.png")
			);
			border[5] = Image.FromStream(
				GetType().Assembly.GetManifestResourceStream("SimPe.img.b.png")
			);
			border[6] = Image.FromStream(
				GetType().Assembly.GetManifestResourceStream("SimPe.img.bl.png")
			);
			border[7] = Image.FromStream(
				GetType().Assembly.GetManifestResourceStream("SimPe.img.l.png")
			);

			#region Add ScrollBar
			sb = new VScrollBar
			{
				Parent = this,
				Dock = DockStyle.Right,
				Minimum = 0,
				Maximum = Math.Max(0, GetNumberOfPages() - 1)
			};
			sb.Visible = sb.Minimum != sb.Maximum;
			sb.Scroll += new ScrollEventHandler(sb_Scroll);
			#endregion


			base.Font = new Font("Courier New", 10, Font.Style, Font.Unit);
			HeaderFont = new Font(Font.FontFamily, Font.Size, FontStyle.Bold, Font.Unit);

			MatchSize();
			RedrawGraphics();
		}

		public void AddHighlightInterval(int start, int end)
		{
			if (start < end)
			{
				AddHighlight(start, end - start);
			}
			else
			{
				AddHighlight(end, start - end);
			}
		}

		public void AddHighlight(int start, int len)
		{
			Highlights.Add(new Highlight(start, len, data.Length));
		}

		public void ClearHighlights()
		{
			Highlights.Clear();
			Refresh(true);
		}

		bool pause;
		bool refresh;

		/// <summary>
		/// No Refresh Evenst will be prcessed until you call <see cref="EndUpdate"/>
		/// </summary>
		public void BeginUpdate()
		{
			refresh = false;

			pause = true;
		}

		/// <summary>
		/// Refresh Events will be process again, if ther were Refresh Events
		/// since the last call to <see cref="BeginUpdate"/>, Refresh will be called once
		/// </summary>
		public void EndUpdate()
		{
			if (!pause)
			{
				return;
			}

			pause = false;
			if (refresh)
			{
				Refresh();
			}
		}

		/// <summary>
		/// Select the passed Range
		/// </summary>
		/// <param name="selstart">Start offset (or -1 for nothing)</param>
		/// <param name="sellen">Length of the Selection</param>
		public void Select(int selstart, int sellen)
		{
			DoSelect(selstart, sellen);
			GoTo(selstart);
		}

		/// <summary>
		/// Select the passed Range
		/// </summary>
		/// <param name="selstart">Start offset (or -1 for nothing)</param>
		/// <param name="sellen">Length of the Selection</param>
		protected void DoSelect(int selstart, int sellen)
		{
			//if (DesignMode) return;
			int olds = SelectionStart;
			int olde = SelectionEnd;
			selection.Length = Math.Min(data.Length - selstart, sellen);
			selection.Start = Math.Min(data.Length - 1, selstart);

			UpdateSelectedRows(olds, olde);
			Refresh();

			if (SelectionChanged != null)
			{
				SelectionChanged(this, new EventArgs());
			}
		}

		/// <summary>
		/// Front fills the String
		/// </summary>
		/// <param name="s"></param>
		/// <param name="len"></param>
		/// <param name="fill"></param>
		/// <returns></returns>
		internal static string SetLength(string s, int len, char fill)
		{
			if (s.Length > len)
			{
				return s.Substring(s.Length - len, len);
			}

			while (s.Length < len)
			{
				s = fill + s;
			}

			return s;
		}

		#region Event Overrides
		protected override void OnVisibleChanged(EventArgs e)
		{
			base.OnVisibleChanged(e);
			if (!Visible)
			{
				BeginUpdate();
			}

			if (Visible)
			{
				EndUpdate();
			}
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			RedrawGraphics();
			if (CurrentRow + GetHexBoxRowsPerPage() >= Rows)
			{
				CurrentRow = (int)Math.Max(0, Rows - GetHexBoxRowsPerPage());
			}

			base.Refresh();
		}

		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Rectangle src = e.ClipRectangle;
			Rectangle dst = e.ClipRectangle;
			e.Graphics.DrawImage(
				cachedimage,
				e.ClipRectangle,
				e.ClipRectangle,
				GraphicsUnit.Pixel
			);
		}

		public override void Refresh()
		{
			Refresh(false);
		}

		public void Refresh(bool rows)
		{
			if (pause)
			{
				refresh = true;
				return;
			}

			bool olvis = sb.Visible;
			SetScrollBar();

			if (olvis != sb.Visible)
			{
				RedrawGraphics();
			}
			else
			{
				if (rows)
				{
					UpdateRows(0);
				}

				UpdateGraphics();
			}

			base.Refresh();
		}

		bool down;

		protected override void OnMouseDown(MouseEventArgs e)
		{
			Point acell = GetLocation(e.X, e.Y);
			DoSelect(GetOffset(acell), 1);
			down = true;
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (down)
			{
				Point acell = GetLocation(e.X, e.Y);
				int of = GetOffset(acell);
				if (of == -1)
				{
					DoSelect(0, -1);
				}
				else if (of <= SelectionStart)
				{
					DoSelect(of, SelectionStart - of + SelectionLength);
				}
				else
				{
					DoSelect(SelectionStart, of - SelectionStart + 1);
				}
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			down = false;
		}

		private void sb_Scroll(object sender, ScrollEventArgs e)
		{
			CurrentRow = e.NewValue;
			//this.Refresh();
			if (Scroll != null)
			{
				Scroll(this, e);
			}
		}

		#endregion

		void SetScrollBar()
		{
			sb.Maximum = Math.Max(0, GetNumberOfPages());
			sb.LargeChange = 1; //(int)this.GetHexBoxRowsPerPage();//sb.Maximum / 20;
								//sb.Maximum += sb.LargeChange+1;
			sb.Visible = sb.Minimum != sb.Maximum;
		}

		#region Manage Drawing

		Bitmap cachedimage;
		Bitmap[] rowimage;

		protected void SetGraphicsMode(System.Drawing.Graphics g, bool fast)
		{
			if (fast)
			{
				g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
				g.CompositingQuality = System
					.Drawing
					.Drawing2D
					.CompositingQuality
					.HighSpeed;
				g.InterpolationMode = System
					.Drawing
					.Drawing2D
					.InterpolationMode
					.Default;
			}
			else
			{
				g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
				g.CompositingQuality = System
					.Drawing
					.Drawing2D
					.CompositingQuality
					.HighQuality;
				g.InterpolationMode = System
					.Drawing
					.Drawing2D
					.InterpolationMode
					.NearestNeighbor;
			}
		}

		protected void RedrawGraphics()
		{
			if (Width == 0)
			{
				return;
			}

			if (Height == 0)
			{
				return;
			}

			SetScrollBar();
			UpdateHexBoxRowHeight();
			UpdateRows(0);
			cachedimage?.Dispose();

			cachedimage = new Bitmap(Width, Height);
			System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(cachedimage);
			SetGraphicsMode(g, true);
			g.FillRectangle(new SolidBrush(BackGroundColour), 0, 0, Width, Height);

			UpdateGraphics(g);
			g.Dispose();
		}

		protected void UpdateGraphics()
		{
			System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(cachedimage);
			SetGraphicsMode(g, true);
			UpdateGraphics(g);
			g.Dispose();
		}

		protected void UpdateGraphics(System.Drawing.Graphics g)
		{
			PaintOffsetBox(g);
			PaintHexBox(g);
			PaintRows(g);
		}

		Point GetLocation(int x, int y)
		{
			x -= OffsetBoxWidth + WINDOWSPACING;
			y -= (int)HexBoxRowHeight;
			y -= bm.Top;
			y = (int)Math.Floor(y / (HexBoxRowHeight + COLSPACING));

			if (x <= HexBoxWidth)
			{
				x -= bm.Left;
				x = (int)Math.Floor(x / (HexBoxColumnWidth + COLSPACING));
			}
			else
			{
				x -= (int)HexBoxWidth + WINDOWSPACING;
				x -= bm.Left;
				x = (int)Math.Floor(x / CharWidth);
			}

			return new Point(
				Math.Max(0, Math.Min(x, Columns - 1)),
				CurrentRow + y
			);
		}

		int GetOffset(Point p)
		{
			return p.X + (p.Y * Columns);
		}

		/// <summary>
		/// Make sure selecte Rows are displayed correct
		/// </summary>
		protected void UpdateSelectedRows()
		{
			int offset = CurrentRow * Columns;

			if (offset > SelectionEnd)
			{
				return;
			}

			if (offset + (GetHexBoxRowsPerPage() * Columns) < SelectionStart)
			{
				return;
			}

			int delta = SelectionStart - offset;
			int first = Math.Min(rowimage.Length - 1, Math.Max(0, delta / Columns));

			delta = SelectionEnd - offset;
			int last = Math.Min(rowimage.Length - 1, Math.Max(0, delta / Columns));

			for (int i = first; i <= last; i++)
			{
				PaintRow(rowimage[i], i);
			}
		}

		/// <summary>
		/// Make sure selecte Rows are displayed correct
		/// </summary>
		protected void UpdateSelectedRows(int olds, int olde)
		{
			int offset = CurrentRow * Columns;

			if (offset > SelectionEnd)
			{
				return;
			}

			if (offset + (GetHexBoxRowsPerPage() * Columns) < SelectionStart)
			{
				return;
			}

			int delta = SelectionStart - offset;
			int first = Math.Min(rowimage.Length - 1, Math.Max(0, delta / Columns));

			delta = SelectionEnd - offset;
			int last = Math.Min(rowimage.Length - 1, Math.Max(0, delta / Columns));

			delta = olds - offset;
			int ofirst = Math.Min(rowimage.Length - 1, Math.Max(0, delta / Columns));

			delta = olde - offset;
			int olast = Math.Min(rowimage.Length - 1, Math.Max(0, delta / Columns));

			if (olast < first || ofirst > last)
			{
				for (int i = ofirst; i <= olast; i++)
				{
					PaintRow(rowimage[i], i);
				}

				for (int i = first; i <= last; i++)
				{
					PaintRow(rowimage[i], i);
				}
			}
			else
			{
				if (olds != SelectionStart)
				{
					int mfirst = Math.Min(ofirst, first);
					int mlast = Math.Max(ofirst, first);
					for (int i = mfirst; i <= mlast; i++)
					{
						PaintRow(rowimage[i], i);
					}
				}

				if (olde != SelectionEnd)
				{
					int mfirst = Math.Min(olast, last);
					int mlast = Math.Max(olast, last);
					for (int i = mfirst; i <= mlast; i++)
					{
						PaintRow(rowimage[i], i);
					}
				}
			}
		}

		/// <summary>
		/// Move the rows by the given Delta
		/// </summary>
		/// <param name="delta"></param>
		protected void MoveRows(int delta)
		{
			if (delta == 0)
			{
				return;
			}

			if (Math.Abs(delta) >= rowimage.Length)
			{
				UpdateRows(delta);
				return;
			}

			int start = 0;
			int end = rowimage.Length;

			int go = start - delta;

			if (delta > 0)
			{
				for (int i = start; i < end; i++)
				{
					go = i - delta;

					if (go >= 0 && go < rowimage.Length)
					{
						rowimage[go] = rowimage[i];
					}
				}
				for (int i = go + 1; i < end; i++)
				{
					rowimage[i] = new Bitmap(
						Width,
						(int)HexBoxRowHeight + COLSPACING
					);
					PaintRow(rowimage[i], i + delta);
				}
			}
			else
			{
				for (int i = end - 1; i >= start; i--)
				{
					go = i - delta;

					if (go >= 0 && go < rowimage.Length)
					{
						rowimage[go] = rowimage[i];
					}
				}
				for (int i = go - 1; i >= 0; i--)
				{
					rowimage[i] = new Bitmap(
						Width,
						(int)HexBoxRowHeight + COLSPACING
					);
					PaintRow(rowimage[i], i + delta);
				}
			}
		}

		/// <summary>
		/// Update the Row Buffer
		/// </summary>
		/// <param name="delta">delta Value to the Current Row Position</param>
		protected void UpdateRows(int delta)
		{
			if (rowimage != null)
			{
				foreach (Bitmap b in rowimage)
				{
					b.Dispose();
				}
			}

			rowimage = new Bitmap[(int)GetHexBoxRowsPerPage() + 2];
			for (int i = 0; i < rowimage.Length; i++)
			{
				rowimage[i] = new Bitmap(Width, (int)HexBoxRowHeight + COLSPACING);
				PaintRow(rowimage[i], i + delta);
			}
		}

		#endregion

		#region Additional Painting Functions
		protected void DrawImageH(
			System.Drawing.Graphics g,
			Image i,
			Rectangle dest,
			Rectangle src
		)
		{
			Rectangle rec = new Rectangle(dest.Left, dest.Top, src.Width, src.Height);

			while (rec.Left + src.Width <= dest.Right)
			{
				g.DrawImage(i, rec, src, GraphicsUnit.Pixel);
				rec = new Rectangle(rec.Right, rec.Top, rec.Width, rec.Height);
			}

			rec = new Rectangle(
				rec.Left,
				rec.Top,
				dest.Left + dest.Width - rec.Left,
				rec.Height
			);
			g.DrawImage(i, rec, src, GraphicsUnit.Pixel);
		}

		protected void DrawImageV(
			System.Drawing.Graphics g,
			Image i,
			Rectangle dest,
			Rectangle src
		)
		{
			Rectangle rec = new Rectangle(dest.Left, dest.Top, src.Width, src.Height);

			while (rec.Top + src.Height <= dest.Bottom)
			{
				g.DrawImage(i, rec, src, GraphicsUnit.Pixel);
				rec = new Rectangle(rec.Left, rec.Bottom, rec.Width, rec.Height);
			}

			rec = new Rectangle(
				rec.Left,
				rec.Top,
				rec.Width,
				dest.Top + dest.Height - rec.Top
			);
			g.DrawImage(i, rec, src, GraphicsUnit.Pixel);
		}

		protected void DrawImageBox(
			System.Drawing.Graphics g,
			int left,
			int top,
			int width,
			int height
		)
		{
			Rectangle src = new Rectangle(0, 0, bm.Left, bm.Top);

			g.DrawImage(
				border[0],
				new Rectangle(left, top, src.Width, src.Height),
				src,
				GraphicsUnit.Pixel
			);
			DrawImageH(
				g,
				border[1],
				new Rectangle(
					left + src.Width,
					top,
					width - (2 * src.Width) + 1,
					src.Height
				),
				src
			);
			g.DrawImage(
				border[2],
				new Rectangle(left + width - src.Width + 1, top, src.Width, src.Height),
				src,
				GraphicsUnit.Pixel
			);
			DrawImageV(
				g,
				border[3],
				new Rectangle(
					left + width - src.Width + 1,
					top + src.Height,
					src.Width,
					height - (2 * src.Height)
				),
				src
			);
			g.DrawImage(
				border[4],
				new Rectangle(
					left + width - src.Width + 1,
					top + height - src.Height,
					src.Width,
					src.Height
				),
				src,
				GraphicsUnit.Pixel
			);
			DrawImageH(
				g,
				border[5],
				new Rectangle(
					left + src.Width,
					top + height - src.Height,
					width - (2 * src.Width),
					src.Height
				),
				src
			);
			g.DrawImage(
				border[6],
				new Rectangle(
					left,
					top + height - src.Height,
					src.Width + 1,
					src.Height
				),
				src,
				GraphicsUnit.Pixel
			);
			DrawImageV(
				g,
				border[7],
				new Rectangle(
					left,
					top + src.Height,
					src.Width,
					height - (2 * src.Height)
				),
				src
			);
		}

		protected void DrawImageSide(
			System.Drawing.Graphics g,
			int left,
			int top,
			int width,
			int height
		)
		{
			Rectangle src = new Rectangle(0, 0, bm.Left, bm.Top);

			DrawImageV(
				g,
				border[3],
				new Rectangle(left + width - src.Width + 1, top, src.Width, height),
				src
			);
			DrawImageV(g, border[7], new Rectangle(left, top, src.Width, height), src);
		}

		protected void DrawBar(
			System.Drawing.Graphics g,
			SolidBrush b,
			int left,
			int top,
			int width,
			int height,
			bool start,
			bool end
		)
		{
			//if (start) g.FillPie(b, left-COLSPACING, top, height-1, height-1, 90, 180);
			//if (end) g.FillPie(b, left+width-height+COLSPACING, top, height-1, height-1, -90, 180);

			Rectangle src = new Rectangle(left, top, width, height);
			int diameter = height - 1;
			int radius = diameter / 2;

			if (start)
			{
				left += radius - COLSPACING;
				width -= radius - COLSPACING;
			}
			if (end)
			{
				width -= diameter - COLSPACING;
			}

			Rectangle rect = new Rectangle(left, top, width, src.Top + diameter);
			int mid = rect.Top + (radius / 2);

			//g.FillRectangle(b, rect);

			System.Drawing.Drawing2D.GraphicsPath gp =
				new System.Drawing.Drawing2D.GraphicsPath();
			if (start)
			{
				gp.AddArc(src.Left, rect.Top, diameter, diameter, 90, 180);
			}
			else
			{
				gp.AddLine(src.Left, rect.Bottom, src.Left, rect.Top);
			}

			gp.AddLine(rect.Left, rect.Top, rect.Right, rect.Top);
			if (end)
			{
				gp.AddArc(rect.Right, rect.Top, diameter, diameter, 270, 180);
			}
			else
			{
				gp.AddLine(rect.Right, rect.Top, rect.Right, rect.Bottom);
			}

			gp.AddLine(rect.Right, rect.Bottom, rect.Left, rect.Bottom);
			/*gp.AddArc(x + width - radius, y + height - radius, radius, radius, 0, 90);
			gp.AddLine(x + width - radius, y + height, x + radius, y + height);
			gp.AddArc(x, y + height - radius, radius, radius, 90, 90);
			gp.AddLine(x, y + height - radius, x, y + radius);
			gp.AddArc(x, y, radius, radius, 180, 90);*/
			gp.CloseFigure();

			g.FillPath(b, gp);
		}

		protected void DrawHighlightedCell(
			System.Drawing.Graphics g,
			int left,
			int top,
			int width,
			int height
		)
		{
			SolidBrush p = new SolidBrush(ZeroCellColor);
			g.FillEllipse(p, left - COLSPACING, top, width, height - 1);
			g.DrawEllipse(BorderPen, left - COLSPACING, top, width, height - 1);
		}

		protected void DrawRowGrid(System.Drawing.Graphics g, int height, int row)
		{
			if (grid)
			{
				Pen p = new Pen(GridColor, 1);
				Rectangle client = new Rectangle(
					OffsetBoxWidth + WINDOWSPACING + bm.Left,
					0,
					(int)HexBoxWidth - bm.Left - 1,
					height - 6
				);

				g.DrawLine(p, client.Left, client.Top, client.Right, client.Top);
				g.DrawLine(
					p,
					client.Right + WINDOWSPACING + 1,
					client.Top,
					client.Right + WINDOWSPACING + 1 + CharBoxWidth - bm.Width,
					client.Top
				);
				for (int i = 0; i < Columns; i++)
				{
					int gleft = GetHexColLeft(i);
					g.DrawLine(p, gleft, client.Top, gleft, client.Bottom);
				}
			}
		}
		#endregion

		#region Custom Drawing

		protected void DrawRowSelection(
			System.Drawing.Graphics g,
			int offset,
			int height
		)
		{
			DrawRowSelection(
				g,
				new SolidBrush(SelectionColor),
				offset,
				height,
				selection
			);
		}

		protected void DrawRowSelection(
			System.Drawing.Graphics g,
			SolidBrush b,
			int offset,
			int height,
			Highlight sel
		)
		{
			int hstart = sel.Start;
			int hlen = sel.Length;
			int hend = sel.End;
			if (hlen < 1 || hstart < 0)
			{
				return;
			}

			if (hstart < offset + Columns && hend >= offset)
			{
				int start = offset;
				if (hstart >= offset && hstart < offset + Columns)
				{
					start = hstart;
				}

				int end = offset + Columns - 1;
				if (hend >= offset && hend < offset + Columns)
				{
					end = hend;
				}

				DrawBar(
					g,
					b,
					GetHexColLeft(start % Columns),
					0,
					GetHexColLeft(end % Columns)
						- GetHexColLeft(start % Columns)
						+ (int)HexBoxColumnWidth,
					height,
					hstart >= offset && hstart < offset + Columns,
					hend >= offset && hend < offset + Columns
				);

				DrawBar(
					g,
					b,
					GetCharColLeft(start % Columns) - (2 * COLSPACING),
					0,
					GetCharColLeft(end % Columns)
						- GetCharColLeft(start % Columns)
						+ (int)CharWidth
						+ (3 * COLSPACING),
					height,
					hstart >= offset && hstart < offset + Columns,
					hend >= offset && hend < offset + Columns
				);
			}
		}

		protected void PaintRow(Bitmap b, int row)
		{
			System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(b);
			SetGraphicsMode(g, true);
			g.FillRectangle(new SolidBrush(base.BackColor), 0, 0, b.Width, b.Height);

			g.FillRectangle(
				BackBrush,
				-2,
				0,
				OffsetBoxWidth + 2,
				b.Height + 2
			);
			g.FillRectangle(
				BackBrush,
				OffsetBoxWidth + WINDOWSPACING,
				-2,
				HexBoxWidth,
				b.Height + 2
			);
			g.FillRectangle(
				BackBrush,
				OffsetBoxWidth + HexBoxWidth + (2 * WINDOWSPACING),
				-2,
				CharBoxWidth,
				b.Height + 2
			);

			//Rectangle clip = new Rectangle(bm.Left, 0, b.Width - bm.Left - bm.Width, b.Height);

			//Offset Number
			int left = bm.Left;
			int width = OffsetBoxWidth - bm.Left - bm.Width;
			int height = (int)HexBoxRowHeight;

			int delta = Columns;
			int offset = (CurrentRow + row) * delta;

			RectangleF dst = new RectangleF(left, 0, width, height);
			if (offset < data.Length)
			{
				g.DrawString(
					SetLength(offset.ToString("x"), 8, '0'),
					HeaderFont,
					ForeBrush,
					dst
				);
			}

			SetGraphicsMode(g, false);
			DrawRowSelection(g, offset, b.Height);
			foreach (Highlight h in Highlights)
			{
				DrawRowSelection(
					g,
					new SolidBrush(HighlightColor),
					offset,
					b.Height,
					h
				);
			}

			SetGraphicsMode(g, true);

			width = (int)HexBoxColumnWidth + COLSPACING;
			int cleft = (int)(
				OffsetBoxWidth + HexBoxWidth + (2 * WINDOWSPACING) + bm.Left
			);
			for (int c = 0; c < Columns; c++)
			{
				if ((offset < data.Length) && offset >= 0)
				{
					SolidBrush brush = selection.Contains(offset) ? new SolidBrush(SelectionForeColor) : ForeBrush;

					foreach (Highlight h in Highlights)
					{
						if (h.Contains(offset))
						{
							brush = new SolidBrush(HighlightForeColor);
							break;
						}
					}

					left = GetHexColLeft(c);
					string txt = vs == ViewState.Hex ? SetLength(data[offset].ToString("x"), 2, '0') : data[offset].ToString();

					dst = new RectangleF(left + COLSPACING, 0, width, height);
					//if ( row == acell.Y && c==acell.X) DrawHighlightedCell(g, left, 0, width, height);
					g.DrawString(txt, Font, brush, dst);

					if (hs && data[offset] == 0)
					{
						SetGraphicsMode(g, false);
						DrawHighlightedCell(g, left, 0, width, height);
						SetGraphicsMode(g, true);
					}

					txt = ((char)data[offset]).ToString();
					dst = new RectangleF(cleft + COLSPACING, 0, CharWidth, height);
					//if ( row == acell.Y && c==acell.X) DrawHighlightedCell(g, left, 0, width, height);
					g.DrawString(txt, Font, brush, dst);

					cleft += (int)CharWidth + COLSPACING;
					offset++;
				}
			}

			DrawRowGrid(g, b.Height, row);

			DrawImageSide(g, 0, 0, OffsetBoxWidth, b.Height);
			DrawImageSide(
				g,
				OffsetBoxWidth + WINDOWSPACING,
				0,
				(int)HexBoxWidth,
				b.Height
			);
			DrawImageSide(
				g,
				(int)(OffsetBoxWidth + HexBoxWidth + (2 * WINDOWSPACING)),
				0,
				CharBoxWidth,
				b.Height
			);
			g.Dispose();
		}

		protected void PaintRows(System.Drawing.Graphics g)
		{
			if (rowimage.Length == 0)
			{
				return;
			}

			Rectangle src = new Rectangle(
				0,
				0,
				rowimage[0].Width - 1,
				rowimage[0].Height - 1
			);
			for (int r = 0; r < rowimage.Length; r++)
			{
				int top = GetVisibleRowTop(r);
				int hg = Math.Min(Height - 1 - bm.Height - top, src.Height);

				if (hg > 0)
				{
					g.DrawImage(
						rowimage[r],
						new Rectangle(0, top, src.Width, hg),
						new Rectangle(src.Left, src.Top, src.Width, hg),
						GraphicsUnit.Pixel
					);
				}
			}
		}

		protected void PaintOffsetBox(System.Drawing.Graphics g)
		{
			g.FillRectangle(BackBrush, 0, 0, OffsetBoxWidth, Height);
			g.FillRectangle(
				HeadBackBrush,
				0,
				0,
				OffsetBoxWidth,
				HexBoxRowHeight + bm.Top - COLSPACING
			);

			int width = OffsetBoxWidth;
			int top = bm.Top - (2 * COLSPACING);
			int height = (int)HexBoxRowHeight;
			int left = bm.Left;

			string txt = SetLength(data.Length.ToString("x"), 8, '0');
			RectangleF dst = new RectangleF(left, top, width, height);
			g.DrawString(txt, HeaderFont, HeadForeBrush, dst);

			DrawImageBox(g, 0, 0, OffsetBoxWidth, Height);
		}

		protected void PaintHexBox(System.Drawing.Graphics g)
		{
			g.FillRectangle(
				BackBrush,
				OffsetBoxWidth + WINDOWSPACING,
				0,
				HexBoxWidth,
				Height - 1
			);
			g.FillRectangle(
				BackBrush,
				OffsetBoxWidth + HexBoxWidth + (2 * WINDOWSPACING),
				0,
				CharBoxWidth,
				Height - 1
			);

			g.FillRectangle(
				HeadBackBrush,
				OffsetBoxWidth + WINDOWSPACING,
				0,
				HexBoxWidth,
				HexBoxRowHeight + bm.Top - COLSPACING
			);
			g.FillRectangle(
				HeadBackBrush,
				OffsetBoxWidth + HexBoxWidth + (2 * WINDOWSPACING),
				0,
				CharBoxWidth,
				HexBoxRowHeight + bm.Top - COLSPACING
			);

			int width = (int)HexBoxColumnWidth + COLSPACING;
			int top = bm.Top - (2 * COLSPACING);
			int height = (int)HexBoxRowHeight;

			for (int c = 0; c < Columns; c++)
			{
				int left = GetHexColLeft(c);
				string txt = SetLength(c.ToString("x"), 2, '0');
				RectangleF dst = new RectangleF(left, top, width, height);
				g.DrawString(txt, HeaderFont, HeadForeBrush, dst);
			}
			DrawImageBox(
				g,
				OffsetBoxWidth + WINDOWSPACING,
				0,
				(int)HexBoxWidth,
				Height - 1
			);
			DrawImageBox(
				g,
				(int)(OffsetBoxWidth + HexBoxWidth + (2 * WINDOWSPACING)),
				0,
				CharBoxWidth,
				Height - 1
			);
		}
		#endregion

		#region Data reading
		public void GoTo(int offset)
		{
			int row = offset / Columns;
			//if (this.GetHexBoxRowsPerPage()>3) row -= 2;
			if (row < 0)
			{
				row = 0;
			}

			if (row >= Rows)
			{
				row = Rows - 1;
			}

			if (
				row < CurrentRow
				|| row > CurrentRow + GetHexBoxRowsPerPage()
			)
			{
				try
				{
					if (row > sb.Maximum)
					{
						row = sb.Maximum;
					}

					if (row < sb.Minimum)
					{
						row = sb.Minimum;
					}

					sb.Value = row;
					CurrentRow = row;
				}
				catch { }
			}
		}

		/// <summary>
		/// Returns/Sets the currently Selected Data
		/// </summary>
		/// <returns></returns>
		[Browsable(false)]
		public byte[] Selection
		{
			get => GetBlock(SelectionStart, SelectionLength);
			set
			{
				if (SelectionStart < 0)
				{
					return;
				}

				for (int i = 0; i < Math.Min(SelectionLength, value.Length); i++)
				{
					data[SelectionStart + i] = value[i];
				}

				UpdateSelectedRows();
				Refresh();
			}
		}

		/// <summary>
		/// Returns/Sets the selected Byte
		/// </summary>
		[Browsable(false)]
		public byte SelectedByte
		{
			get => SelectionStart < 0 ? (byte)0 : data.Length - SelectionStart < 1 ? (byte)0 : data[SelectionStart];
			set
			{
				if (SelectionStart < 0)
				{
					return;
				}

				if (data.Length - SelectionStart < 1)
				{
					return;
				}

				data[SelectionStart] = value;

				UpdateSelectedRows();
				Refresh();

				if (DataChanged != null)
				{
					DataChanged(this, new EventArgs());
				}
			}
		}

		void SetValue(object o)
		{
			if (o == null)
			{
				return;
			}

			if (SelectionStart < 0)
			{
				return;
			}

			byte[] val = o is char
				? BitConverter.GetBytes((char)o)
				: o is ushort
					? BitConverter.GetBytes((ushort)o)
					: o is short
									? BitConverter.GetBytes((short)o)
									: o is uint
													? BitConverter.GetBytes((uint)o)
													: o is int
																	? BitConverter.GetBytes((int)o)
																	: o is ulong
																					? BitConverter.GetBytes((ulong)o)
																					: o is long
																									? BitConverter.GetBytes((long)o)
																									: o is float ? BitConverter.GetBytes((float)o) : o is double ? BitConverter.GetBytes((double)o) : (new byte[0]);

			if (data.Length - SelectionStart < val.Length)
			{
				return;
			}

			int len = Math.Max(val.Length, SelectionLength);

			bool pause = this.pause;
			if (!pause)
			{
				BeginUpdate();
			}

			if (len != SelectionLength)
			{
				DoSelect(SelectionStart, len);
			}

			for (int i = 0; i < val.Length; i++)
			{
				data[SelectionStart + i] = val[i];
			}

			UpdateSelectedRows();
			Refresh();
			if (!pause)
			{
				EndUpdate();
			}

			if (DataChanged != null)
			{
				DataChanged(this, new EventArgs());
			}
		}

		/// <summary>
		/// Returns/Sets the selected Character
		/// </summary>
		[Browsable(false)]
		public char SelectedChar
		{
			get
			{
				if (SelectionStart < 0)
				{
					return (char)0;
				}

				if (data.Length - SelectionStart < 1)
				{
					return (char)0;
				}

				try
				{
					return BitConverter.ToChar(data, SelectionStart);
				}
				catch
				{
					return (char)0;
				}
			}
			set => SetValue(value);
		}

		/// <summary>
		/// Returns/Sets the selected unsigned Short
		/// </summary>
		[Browsable(false)]
		public ushort SelectedUShort
		{
			get => SelectionStart < 0 ? (ushort)0 : data.Length - SelectionStart < 2 ? (ushort)0 : BitConverter.ToUInt16(data, SelectionStart);
			set => SetValue(value);
		}

		/// <summary>
		/// Returns/Sets the selected  Short
		/// </summary>
		[Browsable(false)]
		public short SelectedShort
		{
			get => SelectionStart < 0 ? (short)0 : data.Length - SelectionStart < 2 ? (short)0 : BitConverter.ToInt16(data, SelectionStart);
			set => SetValue(value);
		}

		/// <summary>
		/// Returns/Sets the selected unsigned Integer
		/// </summary>
		[Browsable(false)]
		public uint SelectedUInt
		{
			get => SelectionStart < 0 ? 0 : data.Length - SelectionStart < 4 ? 0 : BitConverter.ToUInt32(data, SelectionStart);
			set => SetValue(value);
		}

		/// <summary>
		/// Returns/Sets the selected Integer
		/// </summary>
		[Browsable(false)]
		public int SelectedInt
		{
			get => SelectionStart < 0 ? 0 : data.Length - SelectionStart < 4 ? 0 : BitConverter.ToInt32(data, SelectionStart);
			set => SetValue(value);
		}

		/// <summary>
		/// Returns/Sets the selected unsigned Long Integer
		/// </summary>
		[Browsable(false)]
		public ulong SelectedULong
		{
			get => SelectionStart < 0 ? 0 : data.Length - SelectionStart < 8 ? 0 : BitConverter.ToUInt64(data, SelectionStart);
			set => SetValue(value);
		}

		/// <summary>
		/// Returns/Sets the selected Long Integer
		/// </summary>
		[Browsable(false)]
		public long SelectedLong
		{
			get => SelectionStart < 0 ? 0 : data.Length - SelectionStart < 8 ? 0 : BitConverter.ToInt64(data, SelectionStart);
			set => SetValue(value);
		}

		/// <summary>
		/// Returns/Sets the selected unsigned Integer
		/// </summary>
		[Browsable(false)]
		public float SelectedFloat
		{
			get => SelectionStart < 0 ? 0 : data.Length - SelectionStart < 4 ? 0 : BitConverter.ToSingle(data, SelectionStart);
			set => SetValue(value);
		}

		/// <summary>
		/// Returns/Sets the selected unsigned Integer
		/// </summary>
		[Browsable(false)]
		public double SelectedDouble
		{
			get => SelectionStart < 0 ? 0 : data.Length - SelectionStart < 8 ? 0 : BitConverter.ToDouble(data, SelectionStart);
			set => SetValue(value);
		}

		/// <summary>
		/// Returns the Data stored in the passed Block
		/// </summary>
		/// <param name="start"></param>
		/// <param name="len"></param>
		/// <returns></returns>
		public byte[] GetBlock(int start, int len)
		{
			if (start < 0)
			{
				len += start;
				start = 0;
			}

			if (len <= 0)
			{
				return new byte[0];
			}

			if (start + len >= data.Length)
			{
				len = data.Length - start;
			}

			byte[] ret = new byte[len];
			for (int i = start; i < start + len; i++)
			{
				ret[i - start] = data[i];
			}

			return ret;
		}

		/// <summary>
		/// Highlights each occurence of the passed Data
		/// </summary>
		/// <param name="hldata"></param>
		public void Highlight(byte[] hldata)
		{
			Highlights.Clear();
			if (hldata.Length == 0)
			{
				Refresh(true);
				return;
			}
			for (int i = 0; i < data.Length - hldata.Length; i++)
			{
				bool check = true;
				for (int j = 0; j < hldata.Length; j++)
				{
					if (hldata[j] != data[i + j])
					{
						check = false;
						break;
					}
				}

				if (check)
				{
					AddHighlight(i, hldata.Length);
				}
			}

			if (Highlights.Length > 0)
			{
				GoTo(Highlights[0].Start);
			}

			Refresh(true);
		}

		public int HighlighCount => Highlights.Count;

		public void SelectNextHighlight()
		{
			foreach (Highlight h in Highlights)
			{
				if (h.Start > SelectionStart)
				{
					GoTo(h.Start);
					Select(h.Start, h.Length);
					return;
				}
			}
		}
		#endregion
	}
}
