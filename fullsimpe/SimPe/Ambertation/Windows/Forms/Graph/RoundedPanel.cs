// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Ambertation.Windows.Forms.Graph
{
	/// <summary>
	/// This is a Rounded Panel
	/// </summary>
	public abstract class RoundedPanel : GraphItemBase
	{
		public RoundedPanel()
			: base()
		{
			BackColor = Color.Transparent;
			bg = Color.DarkOrange;
			gradcl = Color.White;
			bdcl = Color.FromArgb(90, Color.Black);
			fadecl = Color.FromArgb(80, Color.White);
			fade = 0.9f;
		}

		#region public Properties

		Color bg;
		public Color PanelColor
		{
			get => bg;
			set
			{
				if (bg != value)
				{
					bg = value;
					Invalidate();
				}
			}
		}

		float fade;
		public float Fade
		{
			get => fade;
			set
			{
				if (fade != value)
				{
					fade = value;
					Invalidate();
				}
			}
		}

		Color fadecl;
		public Color FadeColor
		{
			get => fadecl;
			set
			{
				if (fadecl != value)
				{
					fadecl = value;
					Invalidate();
				}
			}
		}

		Color gradcl;
		public Color GradientColor
		{
			get => gradcl;
			set
			{
				if (gradcl != value)
				{
					gradcl = value;
					Invalidate();
				}
			}
		}

		Color bdcl;
		public Color BorderColor
		{
			get => bdcl;
			set
			{
				if (bdcl != value)
				{
					bdcl = value;
					Invalidate();
				}
			}
		}
		#endregion

		#region Event Override
		protected override void OnPaint(
			System.Drawing.Graphics g,
			Image canvas,
			Rectangle dst,
			Rectangle src
		)
		{
			if (!Focused && fade < 1)
			{
				System.Drawing.Imaging.ImageAttributes imgAttributes = SetupImageAttr(
					fade
				);
				g.DrawImage(
					canvas,
					dst,
					src.Left,
					src.Top,
					src.Width,
					src.Height,
					GraphicsUnit.Pixel,
					imgAttributes
				);
			}
			else
			{
				g.DrawImage(canvas, dst, src, GraphicsUnit.Pixel);
			}
		}

		internal override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);
			CompleteRedraw();
			Refresh();
		}

		internal override void OnGotFocus(EventArgs e)
		{
			//this.SendToFront();
			base.OnGotFocus(e);
			CompleteRedraw();
			Refresh();
		}

		#endregion

		#region Basic Draw Methods
		static System.Drawing.Imaging.ImageAttributes SetupImageAttr(float alpha)
		{
			float[][] ptsArray =
			{
				new float[] { 1, 0, 0, 0, 0 },
				new float[] { 0, 1, 0, 0, 0 },
				new float[] { 0, 0, 1, 0, 0 },
				new float[] { 0, 0, 0, alpha, 0 },
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

			return imgAttributes;
		}

		protected void DrawNiceRoundRect(
			System.Drawing.Graphics gr,
			int left,
			int top,
			int width,
			int height
		)
		{
			int rad = Math.Min(Math.Min(20, height / 2), width / 2);
			DrawNiceRoundRect(gr, left, top, width, height, rad, PanelColor);
		}

		protected void DrawNiceRoundRect(
			System.Drawing.Graphics gr,
			int left,
			int top,
			int width,
			int height,
			int rad,
			Color panelColor
		)
		{
			DrawNiceRoundRectStart(
				gr,
				left,
				top,
				width,
				height,
				rad,
				panelColor,
				BorderColor,
				GradientColor,
				FadeColor,
				Focused
			);
			DrawText(gr);
			DrawNiceRoundRectEnd(
				gr,
				left,
				top,
				width,
				height,
				rad,
				panelColor,
				BorderColor,
				GradientColor,
				FadeColor,
				Focused
			);
		}

		protected static void DrawNiceRoundRectStart(
			System.Drawing.Graphics gr,
			int left,
			int top,
			int width,
			int height,
			int rad,
			Color bg,
			Color borderColor,
			Color gradientColor,
			Color fadeColor,
			bool focused
		)
		{
			Rectangle srect = new Rectangle(left, top, width - 1, height - 1);

			Pen linepen = new Pen(borderColor);
			if (focused)
			{
				LinearGradientBrush linGrBrush = new LinearGradientBrush(
					new Point(left, top + height),
					new Point(left, top),
					bg,
					gradientColor
				);

				float[] relativeIntensities = { 0.0f, 0.05f, 0.3f };
				float[] relativePositions = { 0.0f, 0.65f, 1.0f };

				//Create a Blend object and assign it to linGrBrush.
				Blend blend = new Blend
				{
					Factors = relativeIntensities,
					Positions = relativePositions
				};
				linGrBrush.Blend = blend;

				Drawing.GraphicRoutines.FillRoundRect(
					gr,
					linGrBrush,
					srect,
					rad
				);
				linGrBrush.Dispose();
			}
			else
			{
				Brush b = new SolidBrush(bg);
				Drawing.GraphicRoutines.FillRoundRect(gr, b, srect, rad);
				b.Dispose();
			}

			linepen.Dispose();
		}

		protected static void DrawNiceRoundRectEnd(
			System.Drawing.Graphics gr,
			int left,
			int top,
			int width,
			int height,
			int rad,
			Color bg,
			Color borderColor,
			Color gradientColor,
			Color fadeColor,
			bool focused
		)
		{
			Rectangle srect = new Rectangle(left, top, width - 1, height - 1);
			Pen linepen = new Pen(borderColor);
			Drawing.GraphicRoutines.DrawRoundRect(gr, linepen, srect, rad);
			linepen.Dispose();

			if (!focused)
			{
				Brush b = new SolidBrush(fadeColor);
				Drawing.GraphicRoutines.FillRoundRect(gr, b, srect, rad);
				b.Dispose();
			}
		}

		protected override void UserDraw(System.Drawing.Graphics gr)
		{
			DrawNiceRoundRect(gr, 0, 0, Width, Height);
		}

		protected virtual void DrawText(System.Drawing.Graphics gr)
		{
		}
		#endregion
	}
}
