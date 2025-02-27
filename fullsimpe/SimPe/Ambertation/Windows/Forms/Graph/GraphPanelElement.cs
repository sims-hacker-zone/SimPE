/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ambertation.Windows.Forms.Graph
{
	/// <summary>
	/// This Control draws a LinkLine between two Controls
	/// </summary>
	public abstract class GraphPanelElement : IDisposable
	{
		public GraphPanelElement()
		{
			this.bg = Color.Transparent;
			this.fg = Color.Black;

			quality = true;
			savebound = true;
			Updating = false;
			SourceImage = new Bitmap(1, 1);
			this.Width = 48;
			this.Height = 48;
		}

		public virtual void Dispose()
		{
			this.Parent = null;

			if (this.SourceImage != null)
			{
				this.SourceImage.Dispose();
			}
		}

		#region Public Properties
		Color bg,
			fg;
		public Color BackColor
		{
			get
			{
				return bg;
			}
			set
			{
				if (bg != value)
				{
					bg = value;
					CompleteRedraw();
					Refresh();
				}
			}
		}

		public Color ForeColor
		{
			get
			{
				return fg;
			}
			set
			{
				if (fg != value)
				{
					fg = value;
					CompleteRedraw();
					Refresh();
				}
			}
		}

		public int Left
		{
			get; private set;
		}

		public int Top
		{
			get; private set;
		}

		public int Width
		{
			get; private set;
		}

		public int Height
		{
			get; private set;
		}

		public int Right => this.BoundingRectangle.Right;

		public int Bottom => this.BoundingRectangle.Bottom;
		public Point Location
		{
			get
			{
				return new Point(Left, Top);
			}
			set
			{
				this.SetBounds(value.X, value.Y, Width, Height);
			}
		}

		public Size Size
		{
			get
			{
				return new Size(Width, Height);
			}
			set
			{
				this.SetBounds(Left, Top, value.Width, value.Height);
			}
		}

		public Rectangle BoundingRectangle => new Rectangle(Left, Top, Width, Height);

		GraphPanel parent;
		public GraphPanel Parent
		{
			get
			{
				return parent;
			}
			set
			{
				if (parent != value)
				{
					if (parent != null)
					{
						this.RemoveFromParent();
						Refresh();
					}
					parent = value;
					if (parent != null)
					{
						this.AddToParent();
					}
					ChangedParent();
					this.Invalidate();
				}
			}
		}
		bool quality;

		/// <summary>
		/// true if you want to draw higher Quality Lines
		/// </summary>
		public virtual bool Quality
		{
			get
			{
				return quality;
			}
			set
			{
				if (quality != value)
				{
					quality = value;
					this.Invalidate();
				}
			}
		}

		bool savebound;
		public virtual bool SaveBounds
		{
			get
			{
				return savebound;
			}
			set
			{
				savebound = value;
			}
		}
		#endregion

		#region Properties

		#endregion

		#region Event Override
		internal virtual void OnLostFocus(EventArgs e)
		{
			if (LostFocus != null)
			{
				LostFocus(this, e);
			}
		}

		internal virtual void OnGotFocus(EventArgs e)
		{
			if (GotFocus != null)
			{
				GotFocus(this, e);
			}
		}

		internal void OnPaint(PaintEventArgs e)
		{
			Rectangle irect = Rectangle.Intersect(
				this.BoundingRectangle,
				e.ClipRectangle
			);
			//if (irect==null) return;
			if (irect.Width == 0 || irect.Height == 0)
			{
				return;
			}

			SetGraphicsMode(e.Graphics, true);
			Rectangle src = new Rectangle(
				e.ClipRectangle.Left - Left,
				e.ClipRectangle.Top - Top,
				e.ClipRectangle.Width,
				e.ClipRectangle.Height
			);
			Rectangle dst = new Rectangle(
				e.ClipRectangle.Left,
				e.ClipRectangle.Top,
				e.ClipRectangle.Width,
				e.ClipRectangle.Height
			);

			OnPaint(e.Graphics, SourceImage, dst, src);
		}

		protected virtual void OnPaint(
			System.Drawing.Graphics g,
			Image canvas,
			Rectangle dst,
			Rectangle src
		)
		{
			g.DrawImage(canvas, dst, src, GraphicsUnit.Pixel);
		}

		public void Refresh()
		{
			if (parent != null)
			{
				parent.Invalidate(this.BoundingRectangle);
			}
		}

		public void Invalidate()
		{
			this.CompleteRedraw();
			this.Refresh();
		}

		public void SetBounds(int x, int y, int wd, int hg)
		{
			wd = Math.Max(1, wd);
			hg = Math.Max(1, hg);
			Rectangle src = new Rectangle(x, y, wd, hg);
			Rectangle dst = this.BoundingRectangle;

			Rectangle r = Rectangle.Union(src, dst);

			Left = x;
			Top = y;
			Width = wd;
			Height = hg;

			if (parent != null && this.SaveBounds)
			{
				if (Right > parent.Width)
				{
					Left = parent.Width - Width;
				}

				if (Bottom > parent.Height)
				{
					Top = parent.Height - Height;
				}

				if (Left < 0)
				{
					Left = 0;
				}

				if (Top < 0)
				{
					Top = 0;
				}

				src = new Rectangle(Left, Top, Width, Height);
			}

			if (src.X != dst.X || src.Y != dst.Y)
			{
				OnMove();
			}

			if (src.Width != dst.Width || src.Height != dst.Height)
			{
				OnSizeChanged();
				this.CompleteRedraw();
				if (SizeChanged != null)
				{
					SizeChanged(this, new EventArgs());
				}
			}
			if ((src.X != dst.X || src.Y != dst.Y) && Move != null)
			{
				Move(this, new EventArgs());
			}

			if (parent != null)
			{
				parent.Invalidate(r);
			}
			//Refresh();
		}
		#endregion


		#region Drawing Support Methods
		internal static void SetGraphicsMode(System.Drawing.Graphics g, bool fast)
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
					.HighQualityBicubic;
			}
		}

		#endregion

		#region Basic Draw Methods



		protected void CompleteRedraw()
		{
			if (Updating)
			{
				return;
			}

			if (Width <= 0)
			{
				return;
			}

			if (Height <= 0)
			{
				return;
			}

			if (SourceImage != null)
			{
				SourceImage.Dispose();
			}

			try
			{
				SourceImage = new Bitmap(Width, Height);
			}
			catch
			{
				SourceImage = new Bitmap(1, 1);
				return;
			}
			System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(SourceImage);
			CompleteRedraw(g);
			g.Dispose();
		}

		public Image SourceImage
		{
			get; private set;
		}

		protected void CompleteRedraw(System.Drawing.Graphics g)
		{
			SetGraphicsMode(g, true);
			g.FillRectangle(new SolidBrush(this.BackColor), 0, 0, Width, Height);
			SetGraphicsMode(g, !quality);
			UserDraw(g);
		}

		protected abstract void UserDraw(System.Drawing.Graphics g);

		#endregion

		public void SendToBack()
		{
			if (parent == null)
			{
				return;
			}

			parent.LinkItems.Remove(this);
			parent.LinkItems.Insert(0, this);
			Refresh();
		}

		public void SendToFront()
		{
			if (parent == null)
			{
				return;
			}

			parent.LinkItems.Remove(this);
			parent.LinkItems.Add(this);
			Refresh();
		}

		internal virtual void ChangedParent()
		{
			if (parent != null)
			{
				this.Quality = parent.Quality;
				this.SaveBounds = parent.SaveBounds;
			}
		}

		public abstract void Clear();

		protected virtual void RemoveFromParent()
		{
			parent.LinkItems.Remove(this);
		}

		protected virtual void AddToParent()
		{
			parent.LinkItems.Add(this);
		}

		#region Events
		protected virtual void OnMove()
		{
		}

		protected virtual void OnSizeChanged()
		{
		}

		public event EventHandler GotFocus;
		public event EventHandler LostFocus;
		public event EventHandler Move;
		public event EventHandler SizeChanged;
		#endregion

		#region Update Control
		public bool Updating
		{
			get; private set;
		}

		public void BeginUpdate()
		{
			Updating = true;
		}

		public void EndUpdate()
		{
			Updating = false;
			this.Invalidate();
		}
		#endregion
	}
}
