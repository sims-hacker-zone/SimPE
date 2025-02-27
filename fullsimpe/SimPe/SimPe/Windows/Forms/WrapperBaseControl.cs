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
	[ToolboxBitmapAttribute(typeof(Panel))]
	public class WrapperBaseControl
		: System.Windows.Forms.UserControl,
			SimPe.Interfaces.Plugin.IPackedFileUI
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
		private System.ComponentModel.Container components = null;

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
					this.Font.Size,
					this.Font.Style,
					this.Font.Unit
				);
				headfont = new Font(
					this.Font.FontFamily,
					9.75f,
					FontStyle.Bold,
					this.Font.Unit
				);

				this.Gradient = LinearGradientMode.ForwardDiagonal;
				BackColor = Color.FromArgb(240, 236, 255);
				midcol = Color.FromArgb(192, 192, 255);
				gradcol = Color.FromArgb(252, 248, 255);
				mCentre = 0.7F;
				mPicloc = new System.Drawing.Point(0, 0);
				mPicZoom = 1.0F;
				mPicOpacity = 1.0F;
				mPicFit = false;
				bklayout = ImageLayout.TopLeft;

				SimPe.ThemeManager.Global.AddControl(this);

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
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Public Properties
		string txt;

		[Localizable(true)]
		public string HeaderText
		{
			get
			{
				return txt;
			}
			set
			{
				if (txt != value)
				{
					txt = value;
					this.Refresh();
				}
			}
		}

		public override string Text
		{
			get
			{
				return base.Text;
			}
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
			get
			{
				return headcol;
			}
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
			get
			{
				return headend;
			}
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
			get
			{
				return headforecol;
			}
			set
			{
				if (value != headforecol)
				{
					headforecol = value;
					this.Invalidate();
				}
			}
		}

		public Font HeadFont
		{
			get
			{
				return headfont;
			}
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

		private System.Windows.Forms.Button btCommit;
		Color gradcol;
		Color midcol;
		float mCentre;
		System.Drawing.Point mPicloc;
		float mPicZoom;
		float mPicOpacity;
		bool mPicFit;
		ImageLayout bklayout;

		public Color GradientColor
		{
			get
			{
				return gradcol;
			}
			set
			{
				if (value != gradcol)
				{
					gradcol = value;
					this.Invalidate();
				}
			}
		}

		public Color MiddleColor
		{
			get
			{
				return midcol;
			}
			set
			{
				if (value != midcol)
				{
					midcol = value;
					this.Invalidate();
				}
			}
		}

		public float GradCentre
		{
			get
			{
				return mCentre;
			}
			set
			{
				mCentre = value;
				this.Invalidate();
			}
		}

		public LinearGradientMode Gradient
		{
			get; set;
		}

		bool cc;
		public bool CanCommit
		{
			get
			{
				return cc;
			}
			set
			{
				cc = value;
				this.btCommit.Visible = cc;
			}
		}

		public bool BackgroundImageZoomToFit
		{
			get
			{
				return mPicFit;
			}
			set
			{
				mPicFit = value;
				this.Invalidate();
			}
		}
		public float BackgroundImageScale
		{
			get
			{
				return mPicZoom;
			}
			set
			{
				if (!mPicFit)
				{
					mPicZoom = value;
					this.Invalidate();
				}
			}
		}
		public System.Drawing.Point BackgroundImageLocation
		{
			get
			{
				return mPicloc;
			}
			set
			{
				if (bklayout != ImageLayout.Centered)
				{
					mPicloc = value;
					this.Invalidate();
				}
			}
		}
		public ImageLayout BackgroundImageAnchor
		{
			get
			{
				return bklayout;
			}
			set
			{
				bklayout = value;
				this.Invalidate();
			}
		}
		public float BackgroundImageOpacity
		{
			get
			{
				return mPicOpacity;
			}
			set
			{
				mPicOpacity = value;
				this.Invalidate();
			}
		}

		[Localizable(false)]
		[Browsable(false)]
		public override System.Windows.Forms.ImageLayout BackgroundImageLayout => System.Windows.Forms.ImageLayout.Zoom;

		#endregion

		#region Properties

		[Browsable(false)]
		public SimPe.ThemeManager ThemeManager
		{
			get; private set;
		}

		public class WrapperChangedEventArgs : EventArgs
		{
			public WrapperChangedEventArgs(
				SimPe.Interfaces.Plugin.IFileWrapper owrp,
				SimPe.Interfaces.Plugin.IFileWrapper nwrp
			)
			{
				this.OldWrapper = owrp;
				this.NewWrapper = nwrp;
			}

			public SimPe.Interfaces.Plugin.IFileWrapper OldWrapper
			{
				get;
			}

			public SimPe.Interfaces.Plugin.IFileWrapper NewWrapper
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
		public SimPe.Interfaces.Plugin.IFileWrapper Wrapper
		{
			get; private set;
		}
		#endregion

		#region Events
		public event System.EventHandler Commited;
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
			this.btCommit = new System.Windows.Forms.Button();
			this.SuspendLayout();
			//
			// btCommit
			//
			this.btCommit.AccessibleDescription = resources.GetString(
				"btCommit.AccessibleDescription"
			);
			this.btCommit.AccessibleName = resources.GetString(
				"btCommit.AccessibleName"
			);
			this.btCommit.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					resources.GetObject("btCommit.Anchor")
				)
			);
			this.btCommit.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("btCommit.BackgroundImage"))
			);
			this.btCommit.Dock = (
				(System.Windows.Forms.DockStyle)(resources.GetObject("btCommit.Dock"))
			);
			this.btCommit.Enabled = ((bool)(resources.GetObject("btCommit.Enabled")));
			this.btCommit.FlatStyle = (
				(System.Windows.Forms.FlatStyle)(
					resources.GetObject("btCommit.FlatStyle")
				)
			);
			this.btCommit.Font = (
				(System.Drawing.Font)(resources.GetObject("btCommit.Font"))
			);
			this.btCommit.Image = (
				(System.Drawing.Image)(resources.GetObject("btCommit.Image"))
			);
			this.btCommit.ImageAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("btCommit.ImageAlign")
				)
			);
			this.btCommit.ImageIndex = (
				(int)(resources.GetObject("btCommit.ImageIndex"))
			);
			this.btCommit.ImeMode = (
				(System.Windows.Forms.ImeMode)(resources.GetObject("btCommit.ImeMode"))
			);
			this.btCommit.Location = (
				(System.Drawing.Point)(resources.GetObject("btCommit.Location"))
			);
			this.btCommit.Name = "btCommit";
			this.btCommit.RightToLeft = (
				(System.Windows.Forms.RightToLeft)(
					resources.GetObject("btCommit.RightToLeft")
				)
			);
			this.btCommit.Size = (
				(System.Drawing.Size)(resources.GetObject("btCommit.Size"))
			);
			this.btCommit.TabIndex = ((int)(resources.GetObject("btCommit.TabIndex")));
			this.btCommit.Text = resources.GetString("btCommit.Text");
			this.btCommit.TextAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("btCommit.TextAlign")
				)
			);
			this.btCommit.Visible = ((bool)(resources.GetObject("btCommit.Visible")));
			this.btCommit.Click += new System.EventHandler(this.btCommit_Click);
			//
			// WrapperBaseControl
			//
			this.AccessibleDescription = resources.GetString(
				"$this.AccessibleDescription"
			);
			this.AccessibleName = resources.GetString("$this.AccessibleName");
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoScrollMargin = (
				(System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin"))
			);
			this.AutoScrollMinSize = (
				(System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize"))
			);
			this.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("$this.BackgroundImage"))
			);
			this.Controls.Add(this.btCommit);
			this.DockPadding.Top = 24;
			this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
			this.ImeMode = (
				(System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode"))
			);
			this.Location = (
				(System.Drawing.Point)(resources.GetObject("$this.Location"))
			);
			this.Name = "WrapperBaseControl";
			this.RightToLeft = (
				(System.Windows.Forms.RightToLeft)(
					resources.GetObject("$this.RightToLeft")
				)
			);
			this.Size = ((System.Drawing.Size)(resources.GetObject("$this.Size")));
			this.ResumeLayout(false);
		}
		#endregion

		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			// base.OnPaintBackground (pevent);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			if ((this.Width > 0) && (this.Height > 0))
			{
				if (this.Height - this.HeaderHeight > 0)
				{
					if (this.GradCentre < 0.02F)
					{
						this.GradCentre = this.mCentre = 0.02F;
					}

					if (this.GradCentre > 0.98F)
					{
						this.GradCentre = this.mCentre = 0.98F;
					}

					Rectangle rec = new Rectangle(
						0,
						this.HeaderHeight,
						this.Width,
						this.Height - this.HeaderHeight
					);
					LinearGradientBrush b = new LinearGradientBrush(
						rec,
						this.BackColor,
						this.MiddleColor,
						this.Gradient
					);
					ColorBlend cb = new ColorBlend(3);
					cb.Colors = new Color[]
					{
						this.BackColor,
						this.MiddleColor,
						this.GradientColor,
					};
					cb.Positions = new float[] { 0F, this.GradCentre, 1F };
					b.InterpolationColors = cb;
					e.Graphics.FillRectangle(b, rec);
					b.Dispose();
					if (this.BackgroundImage != null && mPicOpacity > 0)
					{
						int hyte = this.Height - this.HeaderHeight;
						int adjx = this.Width - mPicloc.X;
						int adjy = hyte - mPicloc.Y;
						if ((adjx > 5) && (adjy > 5))
						{
							if (mPicFit)
							{
								if (
									(
										adjy
										/ this.BackgroundImage.PhysicalDimension.Height
									)
									< (
										adjx
										/ this.BackgroundImage.PhysicalDimension.Width
									)
								)
								{
									mPicZoom =
										adjy
										/ this.BackgroundImage.PhysicalDimension.Height;
								}
								else
								{
									mPicZoom =
										adjx
										/ this.BackgroundImage.PhysicalDimension.Width;
								}
							}
							Int32 Widf = Convert.ToInt32(
								this.BackgroundImage.Width * mPicZoom
							);
							Int32 Hite = Convert.ToInt32(
								this.BackgroundImage.Height * mPicZoom
							);
							int pyintX = mPicloc.X;
							int pyintY = mPicloc.Y + this.HeaderHeight;
							if (bklayout == ImageLayout.TopRight)
							{
								pyintX = (this.Width - Widf) - mPicloc.X;
							}
							else if (bklayout == ImageLayout.BottomRight)
							{
								pyintX = (this.Width - Widf) - mPicloc.X;
								pyintY = (this.Height - Hite) - mPicloc.Y;
							}
							else if (bklayout == ImageLayout.BottomLeft)
							{
								pyintY = (this.Height - Hite) - mPicloc.Y;
							}
							else if (bklayout == ImageLayout.Centered)
							{
								pyintX = (this.Width - Widf) / 2;
								pyintY = (this.Height - Hite + this.HeaderHeight) / 2;
							}
							else if (bklayout == ImageLayout.CenterLeft)
							{
								pyintY = (this.Height - Hite + this.HeaderHeight) / 2;
							}
							else if (bklayout == ImageLayout.CenterTop)
							{
								pyintX = (this.Width - Widf) / 2;
							}
							else if (bklayout == ImageLayout.CenterRight)
							{
								pyintY = (this.Height - Hite + this.HeaderHeight) / 2;
								pyintX = (this.Width - Widf) - mPicloc.X;
							}
							else if (bklayout == ImageLayout.CenterBottom)
							{
								pyintX = (this.Width - Widf) / 2;
								pyintY = (this.Height - Hite) - mPicloc.Y;
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
								e.Graphics.DrawImage(this.BackgroundImage, picrect);
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
									this.BackgroundImage,
									picrect,
									0,
									0,
									this.BackgroundImage.Width,
									this.BackgroundImage.Height,
									System.Drawing.GraphicsUnit.Pixel,
									imgAttributes
								);
								imgAttributes.Dispose();
							}
						}
					}
				}

				//Draw the HeadLine HeadEndColor
				Rectangle hrec = new Rectangle(0, 0, this.Width, this.HeaderHeight);
				LinearGradientBrush bg = new LinearGradientBrush(
					hrec,
					HeadBackColor,
					HeadEndColor,
					System.Drawing.Drawing2D.LinearGradientMode.Horizontal
				);
				SolidBrush fb = new SolidBrush(this.HeadForeColor);
				ColorBlend hcb = new ColorBlend(2);
				hcb.Colors = new Color[] { HeadBackColor, HeadEndColor };
				hcb.Positions = new float[] { 0F, 1F };
				bg.InterpolationColors = hcb;
				e.Graphics.FillRectangle(bg, hrec);
				SizeF sz = e.Graphics.MeasureString(HeaderText, this.HeadFont);
				int dist = (int)((HeaderHeight - sz.Height) / 2);
				e.Graphics.DrawString(HeaderText, this.HeadFont, fb, dist, dist);
				bg.Dispose();
				fb.Dispose();
			}
		}

		public virtual void OnCommit()
		{
		}

		private void btCommit_Click(object sender, System.EventArgs e)
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
		public System.Windows.Forms.Control GUIHandle => this;

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
		public void UpdateGUI(SimPe.Interfaces.Plugin.IFileWrapper wrp)
		{
			SetWrapper(wrp);
			RefreshGUI();
		}

		private void SetWrapper(SimPe.Interfaces.Plugin.IFileWrapper wrp)
		{
			SimPe.Interfaces.Plugin.IFileWrapper old = this.Wrapper;
			this.Wrapper = wrp;

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
			this.btCommit.Left = this.Width - 4 - btCommit.Width;
		}
	}
}
