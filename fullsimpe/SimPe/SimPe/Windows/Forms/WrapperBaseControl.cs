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
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SimPe.Windows.Forms
{
	/// <summary>
	/// Summary description for WrapperBaseControl.
	/// </summary>
	[ToolboxBitmap(typeof(Panel))]
	public class WrapperBaseControl
		: UserControl,
			Interfaces.Plugin.IPackedFileUI
	{
		/// <summary>
		/// Determines the Anchor Location of the background image.
		/// </summary>
		public enum ImageLayout
		{
			TopLeft = 0,
			TopRight = 1,
			BottomLeft = 2,
			BottomRight = 3,
			Centered = 4,
			CenterLeft = 5,
			CenterRight = 6,
			CenterTop = 7,
			CenterBottom = 8,
		}

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public WrapperBaseControl()
		{
			try
			{
				SetStyle(
					ControlStyles.SupportsTransparentBackColor
						| ControlStyles.AllPaintingInWmPaint
						|
						//ControlStyles.Opaque |
						ControlStyles.UserPaint
						| ControlStyles.ResizeRedraw
						| ControlStyles.DoubleBuffer,
					true
				);

				// Required designer variable.
				InitializeComponent();

				headcol = Color.FromArgb(120, 0, 0, 0);
				headend = Color.FromArgb(120, 0, 0, 0);
				headforecol = Color.White;
				Font = new Font(
					"tahoma",
					Font.Size,
					Font.Style,
					Font.Unit
				);
				headfont = new Font(
					Font.FontFamily,
					9.75f,
					FontStyle.Bold,
					Font.Unit
				);

				Gradient = LinearGradientMode.ForwardDiagonal;
				BackColor = Color.FromArgb(240, 236, 255);
				midcol = Color.FromArgb(192, 192, 255);
				gradcol = Color.FromArgb(252, 248, 255);
				mCentre = 0.7F;
				mPicloc = new Point(0, 0);
				mPicZoom = 1.0F;
				mPicOpacity = 1.0F;
				mPicFit = false;
				bklayout = ImageLayout.TopLeft;

				ThemeManager.Global.AddControl(this);

				txt = "";
				CanCommit = true;
			}
			catch { }
		}

		~WrapperBaseControl()
		{
			if (Wrapper != null)
			{
				SetWrapper(null);
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (Wrapper != null)
				{
					SetWrapper(null);
				}

				if (ThemeManager != null)
				{
					ThemeManager.Parent = null;
					ThemeManager.CreateChild();
					ThemeManager.Dispose();
				}
				ThemeManager = null;
				components?.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Public Properties
		string txt;

		[Localizable(true)]
		public string HeaderText
		{
			get => txt;
			set
			{
				if (txt != value)
				{
					txt = value;
					Refresh();
				}
			}
		}

		public override string Text
		{
			get => base.Text;
			set
			{
				base.Text = value;
				HeaderText = value;
			}
		}

		Color headcol,
			headend,
			headforecol;
		Font headfont;

		public Color HeadBackColor
		{
			get => headcol;
			set
			{
				if (value != headcol)
				{
					headcol = value;
					Invalidate();
				}
			}
		}

		public Color HeadEndColor
		{
			get => headend;
			set
			{
				if (value != headend)
				{
					headend = value;
					Invalidate();
				}
			}
		}

		public Color HeadForeColor
		{
			get => headforecol;
			set
			{
				if (value != headforecol)
				{
					headforecol = value;
					Invalidate();
				}
			}
		}

		public Font HeadFont
		{
			get => headfont;
			set
			{
				if (value != headfont)
				{
					headfont = value;
					Invalidate();
				}
			}
		}

		public int HeaderHeight => 24;

		private Button btCommit;
		Color gradcol;
		Color midcol;
		float mCentre;
		Point mPicloc;
		float mPicZoom;
		float mPicOpacity;
		bool mPicFit;
		ImageLayout bklayout;

		public Color GradientColor
		{
			get => gradcol;
			set
			{
				if (value != gradcol)
				{
					gradcol = value;
					Invalidate();
				}
			}
		}

		public Color MiddleColor
		{
			get => midcol;
			set
			{
				if (value != midcol)
				{
					midcol = value;
					Invalidate();
				}
			}
		}

		public float GradCentre
		{
			get => mCentre;
			set
			{
				mCentre = value;
				Invalidate();
			}
		}

		public LinearGradientMode Gradient
		{
			get; set;
		}

		bool cc;
		public bool CanCommit
		{
			get => cc;
			set
			{
				cc = value;
				btCommit.Visible = cc;
			}
		}

		public bool BackgroundImageZoomToFit
		{
			get => mPicFit;
			set
			{
				mPicFit = value;
				Invalidate();
			}
		}
		public float BackgroundImageScale
		{
			get => mPicZoom;
			set
			{
				if (!mPicFit)
				{
					mPicZoom = value;
					Invalidate();
				}
			}
		}
		public Point BackgroundImageLocation
		{
			get => mPicloc;
			set
			{
				if (bklayout != ImageLayout.Centered)
				{
					mPicloc = value;
					Invalidate();
				}
			}
		}
		public ImageLayout BackgroundImageAnchor
		{
			get => bklayout;
			set
			{
				bklayout = value;
				Invalidate();
			}
		}
		public float BackgroundImageOpacity
		{
			get => mPicOpacity;
			set
			{
				mPicOpacity = value;
				Invalidate();
			}
		}

		[Localizable(false)]
		[Browsable(false)]
		public override System.Windows.Forms.ImageLayout BackgroundImageLayout => System.Windows.Forms.ImageLayout.Zoom;

		#endregion

		#region Properties

		[Browsable(false)]
		public ThemeManager ThemeManager
		{
			get; private set;
		}

		public class WrapperChangedEventArgs : EventArgs
		{
			public WrapperChangedEventArgs(
				Interfaces.Plugin.IFileWrapper owrp,
				Interfaces.Plugin.IFileWrapper nwrp
			)
			{
				OldWrapper = owrp;
				NewWrapper = nwrp;
			}

			public Interfaces.Plugin.IFileWrapper OldWrapper
			{
				get;
			}

			public Interfaces.Plugin.IFileWrapper NewWrapper
			{
				get;
			}
		}

		public delegate void WrapperChangedHandle(
			object sender,
			WrapperChangedEventArgs e
		);
		public event WrapperChangedHandle WrapperChanged;

		[Browsable(false)]
		public Interfaces.Plugin.IFileWrapper Wrapper
		{
			get; private set;
		}
		#endregion

		#region Events
		public event EventHandler Commited;
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources =
				new System.Resources.ResourceManager(typeof(WrapperBaseControl));
			btCommit = new Button();
			SuspendLayout();
			//
			// btCommit
			//
			btCommit.AccessibleDescription = resources.GetString(
				"btCommit.AccessibleDescription"
			);
			btCommit.AccessibleName = resources.GetString(
				"btCommit.AccessibleName"
			);
			btCommit.Anchor = (
				(AnchorStyles)(
					resources.GetObject("btCommit.Anchor")
				)
			);
			btCommit.BackgroundImage = (
				(Image)(resources.GetObject("btCommit.BackgroundImage"))
			);
			btCommit.Dock = (
				(DockStyle)(resources.GetObject("btCommit.Dock"))
			);
			btCommit.Enabled = ((bool)(resources.GetObject("btCommit.Enabled")));
			btCommit.FlatStyle = (
				(FlatStyle)(
					resources.GetObject("btCommit.FlatStyle")
				)
			);
			btCommit.Font = (
				(Font)(resources.GetObject("btCommit.Font"))
			);
			btCommit.Image = (
				(Image)(resources.GetObject("btCommit.Image"))
			);
			btCommit.ImageAlign = (
				(ContentAlignment)(
					resources.GetObject("btCommit.ImageAlign")
				)
			);
			btCommit.ImageIndex = (
				(int)(resources.GetObject("btCommit.ImageIndex"))
			);
			btCommit.ImeMode = (
				(ImeMode)(resources.GetObject("btCommit.ImeMode"))
			);
			btCommit.Location = (
				(Point)(resources.GetObject("btCommit.Location"))
			);
			btCommit.Name = "btCommit";
			btCommit.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("btCommit.RightToLeft")
				)
			);
			btCommit.Size = (
				(Size)(resources.GetObject("btCommit.Size"))
			);
			btCommit.TabIndex = ((int)(resources.GetObject("btCommit.TabIndex")));
			btCommit.Text = resources.GetString("btCommit.Text");
			btCommit.TextAlign = (
				(ContentAlignment)(
					resources.GetObject("btCommit.TextAlign")
				)
			);
			btCommit.Visible = ((bool)(resources.GetObject("btCommit.Visible")));
			btCommit.Click += new EventHandler(btCommit_Click);
			//
			// WrapperBaseControl
			//
			AccessibleDescription = resources.GetString(
				"$this.AccessibleDescription"
			);
			AccessibleName = resources.GetString("$this.AccessibleName");
			AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			AutoScrollMargin = (
				(Size)(resources.GetObject("$this.AutoScrollMargin"))
			);
			AutoScrollMinSize = (
				(Size)(resources.GetObject("$this.AutoScrollMinSize"))
			);
			BackgroundImage = (
				(Image)(resources.GetObject("$this.BackgroundImage"))
			);
			Controls.Add(btCommit);
			DockPadding.Top = 24;
			Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			Font = ((Font)(resources.GetObject("$this.Font")));
			ImeMode = (
				(ImeMode)(resources.GetObject("$this.ImeMode"))
			);
			Location = (
				(Point)(resources.GetObject("$this.Location"))
			);
			Name = "WrapperBaseControl";
			RightToLeft = (
				(RightToLeft)(
					resources.GetObject("$this.RightToLeft")
				)
			);
			Size = ((Size)(resources.GetObject("$this.Size")));
			ResumeLayout(false);
		}
		#endregion

		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			// base.OnPaintBackground (pevent);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			if ((Width > 0) && (Height > 0))
			{
				if (Height - HeaderHeight > 0)
				{
					if (GradCentre < 0.02F)
					{
						GradCentre = mCentre = 0.02F;
					}

					if (GradCentre > 0.98F)
					{
						GradCentre = mCentre = 0.98F;
					}

					Rectangle rec = new Rectangle(
						0,
						HeaderHeight,
						Width,
						Height - HeaderHeight
					);
					LinearGradientBrush b = new LinearGradientBrush(
						rec,
						BackColor,
						MiddleColor,
						Gradient
					);
					ColorBlend cb = new ColorBlend(3)
					{
						Colors = new Color[]
					{
						BackColor,
						MiddleColor,
						GradientColor,
					},
						Positions = new float[] { 0F, GradCentre, 1F }
					};
					b.InterpolationColors = cb;
					e.Graphics.FillRectangle(b, rec);
					b.Dispose();
					if (BackgroundImage != null && mPicOpacity > 0)
					{
						int hyte = Height - HeaderHeight;
						int adjx = Width - mPicloc.X;
						int adjy = hyte - mPicloc.Y;
						if ((adjx > 5) && (adjy > 5))
						{
							if (mPicFit)
							{
								mPicZoom = (
										adjy
										/ BackgroundImage.PhysicalDimension.Height
									)
									< (
										adjx
										/ BackgroundImage.PhysicalDimension.Width
									)
									? adjy
										/ BackgroundImage.PhysicalDimension.Height
									: adjx
										/ BackgroundImage.PhysicalDimension.Width;
							}
							Int32 Widf = Convert.ToInt32(
								BackgroundImage.Width * mPicZoom
							);
							Int32 Hite = Convert.ToInt32(
								BackgroundImage.Height * mPicZoom
							);
							int pyintX = mPicloc.X;
							int pyintY = mPicloc.Y + HeaderHeight;
							if (bklayout == ImageLayout.TopRight)
							{
								pyintX = (Width - Widf) - mPicloc.X;
							}
							else if (bklayout == ImageLayout.BottomRight)
							{
								pyintX = (Width - Widf) - mPicloc.X;
								pyintY = (Height - Hite) - mPicloc.Y;
							}
							else if (bklayout == ImageLayout.BottomLeft)
							{
								pyintY = (Height - Hite) - mPicloc.Y;
							}
							else if (bklayout == ImageLayout.Centered)
							{
								pyintX = (Width - Widf) / 2;
								pyintY = (Height - Hite + HeaderHeight) / 2;
							}
							else if (bklayout == ImageLayout.CenterLeft)
							{
								pyintY = (Height - Hite + HeaderHeight) / 2;
							}
							else if (bklayout == ImageLayout.CenterTop)
							{
								pyintX = (Width - Widf) / 2;
							}
							else if (bklayout == ImageLayout.CenterRight)
							{
								pyintY = (Height - Hite + HeaderHeight) / 2;
								pyintX = (Width - Widf) - mPicloc.X;
							}
							else if (bklayout == ImageLayout.CenterBottom)
							{
								pyintX = (Width - Widf) / 2;
								pyintY = (Height - Hite) - mPicloc.Y;
							}

							// Draw the Background Image
							Rectangle picrect = new Rectangle(
								pyintX,
								pyintY,
								Widf,
								Hite
							);
							if (mPicOpacity >= 1)
							{
								e.Graphics.DrawImage(BackgroundImage, picrect);
							}
							else
							{
								float[][] ptsArray =
								{
									new float[] { 1, 0, 0, 0, 0 },
									new float[] { 0, 1, 0, 0, 0 },
									new float[] { 0, 0, 1, 0, 0 },
									new float[] { 0, 0, 0, mPicOpacity, 0 },
									new float[] { 0, 0, 0, 0, 1 },
								};
								System.Drawing.Imaging.ColorMatrix clrMatrix =
									new System.Drawing.Imaging.ColorMatrix(ptsArray);
								System.Drawing.Imaging.ImageAttributes imgAttributes =
									new System.Drawing.Imaging.ImageAttributes();
								imgAttributes.SetColorMatrix(
									clrMatrix,
									System.Drawing.Imaging.ColorMatrixFlag.Default,
									System.Drawing.Imaging.ColorAdjustType.Bitmap
								);
								e.Graphics.DrawImage(
									BackgroundImage,
									picrect,
									0,
									0,
									BackgroundImage.Width,
									BackgroundImage.Height,
									GraphicsUnit.Pixel,
									imgAttributes
								);
								imgAttributes.Dispose();
							}
						}
					}
				}

				//Draw the HeadLine HeadEndColor
				Rectangle hrec = new Rectangle(0, 0, Width, HeaderHeight);
				LinearGradientBrush bg = new LinearGradientBrush(
					hrec,
					HeadBackColor,
					HeadEndColor,
					LinearGradientMode.Horizontal
				);
				SolidBrush fb = new SolidBrush(HeadForeColor);
				ColorBlend hcb = new ColorBlend(2)
				{
					Colors = new Color[] { HeadBackColor, HeadEndColor },
					Positions = new float[] { 0F, 1F }
				};
				bg.InterpolationColors = hcb;
				e.Graphics.FillRectangle(bg, hrec);
				SizeF sz = e.Graphics.MeasureString(HeaderText, HeadFont);
				int dist = (int)((HeaderHeight - sz.Height) / 2);
				e.Graphics.DrawString(HeaderText, HeadFont, fb, dist, dist);
				bg.Dispose();
				fb.Dispose();
			}
		}

		public virtual void OnCommit()
		{
		}

		private void btCommit_Click(object sender, EventArgs e)
		{
			if (Commited != null)
			{
				Commited(this, e);
			}

			OnCommit();
		}

		#region IPackedFileUI Member
		/// <summary>
		/// Returns the Panel that will be displayed within SimPe
		/// </summary>
		public Control GUIHandle => this;

		protected virtual void OnWrapperChanged(WrapperChangedEventArgs e)
		{
		}

		/// <summary>
		/// Is called by SimPe (through the Wrapper) when the Panel is going to be displayed, so
		/// you should updatet the Data displayed by the Panel with the Attributes stored in the
		/// passed Wrapper.
		/// </summary>
		/// <remarks>attr.Tag is used to let TextChanged event handlers know the change is being
		/// made internally rather than by the users.</remarks>
		/// <param name="wrp">The Attributes of this Wrapper have to be displayed</param>
		public void UpdateGUI(Interfaces.Plugin.IFileWrapper wrp)
		{
			SetWrapper(wrp);
			RefreshGUI();
		}

		private void SetWrapper(Interfaces.Plugin.IFileWrapper wrp)
		{
			Interfaces.Plugin.IFileWrapper old = Wrapper;
			Wrapper = wrp;

			WrapperChangedEventArgs e = new WrapperChangedEventArgs(old, wrp);
			OnWrapperChanged(e);
			if (WrapperChanged != null)
			{
				WrapperChanged(this, e);
			}
		}
		#endregion

		/// <summary>
		/// Implement this Method in derrived classes
		/// </summary>
		protected virtual void RefreshGUI()
		{
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			btCommit.Left = Width - 4 - btCommit.Width;
		}
	}
}
