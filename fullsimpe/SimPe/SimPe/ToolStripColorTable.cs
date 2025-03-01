// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SimPe
{
	public class ToolStripProfessionalSquareRenderer
		: Ambertation.Renderer.AdvancedToolStripProfessionalRenderer
	{
		public ToolStripProfessionalSquareRenderer(ProfessionalColorTable ct)
			: base(ct)
		{
			RoundedEdges = false;
		}

		public ToolStripProfessionalSquareRenderer()
			: base()
		{
			RoundedEdges = false;
		}
	}

	public class MediaPlayerRenderer : ToolStripProfessionalSquareRenderer
	{
		public MediaPlayerRenderer(ProfessionalColorTable ct)
			: base(ct) { }

		public MediaPlayerRenderer()
			: base() { }

		Color CheckedColor => Color.YellowGreen;

		protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
		{
			Rectangle bounds = new Rectangle(
				Point.Empty,
				new Size(e.Item.Size.Width - 1, e.Item.Size.Height - 1)
			);
			if (e.Item is ToolStripMenuItem && e.Item.Selected && e.Item.Enabled)
			{
				SolidBrush background = new SolidBrush(
					Color.FromArgb(80, ColorTable.MenuItemBorder)
				);
				e.Graphics.FillRectangle(background, bounds);
				background.Dispose();
			}
			else if (e.Item is ToolStripButton)
			{
				SolidBrush background;

				// Create background brush
				if (e.Item.Selected)
				{
					background = new SolidBrush(
						Color.FromArgb(120, ColorTable.MenuItemBorder)
					);
				}
				else if (e.Item.Pressed)
				{
					background = new SolidBrush(
						Color.FromArgb(80, ColorTable.MenuItemBorder)
					);
				}
				else if (((ToolStripButton)e.Item).Checked)
				{
					background = new SolidBrush(Color.FromArgb(120, CheckedColor));
				}
				else
				{
					background = new SolidBrush(
						Color.FromArgb(0, ColorTable.MenuItemBorder)
					);
					base.OnRenderItemBackground(e);
					return;
				}
				e.Graphics.FillRectangle(background, bounds);
				Pen pen = new Pen(ColorTable.ButtonSelectedBorder);
				if (!((ToolStripButton)e.Item).Checked)
				{
					e.Graphics.DrawRectangle(pen, bounds);
				}

				background.Dispose();
			}
			else
			{
				base.OnRenderItemBackground(e);
			}
		}

		protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
		{
			Color color1,
				color2,
				color3,
				color4;

			if (e.ToolStrip is MenuStrip)
			{
				base.OnRenderToolStripBackground(e);
			}
			else
			{
				// Calculate colours used in gradient
				color1 = ColorTable.ToolStripGradientBegin;
				color2 = ColorTable.ToolStripGradientEnd;
				color3 = InterpolateColors(color1, color2, 0.4F);
				color4 = InterpolateColors(color1, color2, 0.8F);

				bool vertical = false;

				// Create linear gradient brush
				LinearGradientMode direction = vertical
					? LinearGradientMode.Horizontal
					: LinearGradientMode.Vertical;
				using (
					LinearGradientBrush l = new LinearGradientBrush(
						e.AffectedBounds,
						color1,
						color2,
						direction
					)
				)
				{
					// Set colour values
					ColorBlend cb = new ColorBlend(5)
					{
						Colors = new Color[] { color1, color2, color2, color3, color4 },
						Positions = new float[] { 0F, 0.47F, 0.53F, 0.75F, 1F }
					};
					l.InterpolationColors = cb;

					// Fill background
					e.Graphics.FillRectangle(l, e.AffectedBounds);
				}
			}
		}
	}

	class MediaPlayerToolStripColorTable : ToolStripColorTable
	{
		public override Color ToolStripGradientBegin => Color.FromArgb(0xFD, 0xFD, 0xFB);
		public override Color ToolStripGradientEnd => Color.FromArgb(0xB9, 0xB9, 0xA3);
	}

	class ToolStripColorTable : ProfessionalColorTable
	{
		#region Checker
		public override Color CheckBackground => Color.FromArgb(0xE1, 0xE6, 0xE8);

		public override Color CheckPressedBackground => Color.FromArgb(0x31, 0x6A, 0xC5);

		public override Color CheckSelectedBackground => CheckPressedBackground;

		#endregion

		#region Seperator
		public override Color SeparatorDark => Color.FromArgb(0xC5, 0xC2, 0xB8);

		public override Color SeparatorLight => Color.FromArgb(0xFC, 0xFC, 0xF9);
		#endregion

		#region MenuStrip

		public override Color MenuStripGradientBegin => Color.FromArgb(0xE5, 0xE5, 0xD7);

		public override Color MenuStripGradientEnd =>
				//return Color.FromArgb(0xF3, 0xF2, 0xE7);
				Color.White;

		public override Color MenuBorder => Color.FromArgb(0x8A, 0x86, 0x7A);
		#endregion

		#region ToolStrip
		public override Color ToolStripGradientBegin => Color.FromArgb(0xFD, 0xFD, 0xFB);

		public override Color ToolStripGradientMiddle => Color.FromArgb(0xEC, 0xEC, 0xE5);

		public override Color ToolStripGradientEnd => Color.FromArgb(0xBE, 0xBE, 0xA7);

		public override Color ToolStripBorder => Color.FromArgb(0xA3, 0xA3, 0x7C);
		#endregion

		#region Overflow
		public override Color OverflowButtonGradientBegin => Color.FromArgb(0xEF, 0xEE, 0xEB);

		public override Color OverflowButtonGradientMiddle => Color.FromArgb(0xE1, 0xE1, 0xDA);

		public override Color OverflowButtonGradientEnd => Color.FromArgb(0x92, 0x92, 0x76);
		#endregion

		#region Image Margin
		public override Color ImageMarginGradientBegin => Color.FromArgb(0xFE, 0xFE, 0xFB);

		public override Color ImageMarginGradientEnd => Color.FromArgb(0xC4, 0xC3, 0xAC);

		public override Color ImageMarginGradientMiddle => Color.FromArgb(0xED, 0xE9, 0xE2);

		public override Color ImageMarginRevealedGradientBegin => ImageMarginGradientBegin;

		public override Color ImageMarginRevealedGradientEnd => ImageMarginGradientEnd;

		public override Color ImageMarginRevealedGradientMiddle => ImageMarginGradientMiddle;

		#endregion

		#region Pressed MenuItem
		public override Color MenuItemPressedGradientBegin => Color.FromArgb(0xFB, 0xFB, 0xF9);

		public override Color MenuItemPressedGradientEnd => Color.FromArgb(0xF7, 0xF5, 0xEF);

		public override Color MenuItemPressedGradientMiddle => Color.FromArgb(0xF9, 0xF8, 0xF4);
		#endregion

		#region Selected MenuItem
		public override Color MenuItemBorder => ButtonSelectedBorder;

		public override Color MenuItemSelected => ButtonSelectedGradientBegin;

		public override Color MenuItemSelectedGradientBegin => ButtonSelectedGradientBegin;

		public override Color MenuItemSelectedGradientEnd => ButtonSelectedGradientBegin;
		#endregion

		#region Selected Button
		public override Color ButtonSelectedGradientBegin => Color.FromArgb(0xC1, 0xD2, 0xEE);

		public override Color ButtonSelectedGradientMiddle => ButtonSelectedGradientBegin;

		public override Color ButtonSelectedGradientEnd => ButtonSelectedGradientBegin;

		public override Color ButtonSelectedBorder => Color.FromArgb(0x31, 0x6A, 0xC5);
		#endregion

		#region Pressed Button
		public override Color ButtonPressedGradientBegin => Color.FromArgb(0x98, 0xB5, 0xE2);

		public override Color ButtonPressedGradientMiddle => ButtonPressedGradientBegin;

		public override Color ButtonPressedGradientEnd => ButtonPressedGradientBegin;

		public override Color ButtonPressedBorder => Color.FromArgb(0x4B, 0x4B, 0x6F);
		#endregion

		#region Checked Button
		public override Color ButtonCheckedGradientBegin => Color.FromArgb(0xE1, 0xE6, 0xE8);

		public override Color ButtonCheckedGradientMiddle => ButtonCheckedGradientBegin;

		public override Color ButtonCheckedGradientEnd => ButtonCheckedGradientBegin;

		public override Color ButtonCheckedHighlightBorder => Color.FromArgb(0x4B, 0x4B, 0x6F);

		public override Color ButtonCheckedHighlight => Color.FromArgb(0x98, 0xB5, 0xE2);
		#endregion

		#region ToolStripPanel
		public override Color ToolStripPanelGradientBegin => MenuStripGradientBegin;

		public override Color ToolStripPanelGradientEnd => MenuStripGradientEnd;
		#endregion
	}
}
