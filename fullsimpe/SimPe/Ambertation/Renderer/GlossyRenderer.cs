using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Ambertation.Renderer
{
	public class AdvancedToolStripProfessionalRenderer : ToolStripProfessionalRenderer
	{
		public AdvancedToolStripProfessionalRenderer(ProfessionalColorTable ct)
			: base(ct) { }

		public AdvancedToolStripProfessionalRenderer()
			: base() { }

		protected override void OnRenderMenuItemBackground(
			ToolStripItemRenderEventArgs e
		)
		{
			if (e.Item.Enabled)
			{
				base.OnRenderMenuItemBackground(e);
			}
		}

		static byte Interpolate(byte b1, byte b2, float p)
		{
			return (byte)(b1 * (1 - p) + b2 * (p));
		}

		public static Color InterpolateColors(Color c1, Color c2, float p)
		{
			return Color.FromArgb(
				Interpolate(c1.R, c2.R, p),
				Interpolate(c1.G, c2.G, p),
				Interpolate(c1.B, c2.B, p)
			);
		}
	}

	public class GlossyRenderer : AdvancedToolStripProfessionalRenderer
	{
		public GlossyRenderer()
			: base(GlossyColorTable.Global)
		{
			this.RoundedEdges = false;

			if (menupattern == null)
			{
				menupattern = Image.FromStream(
					this.GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.pattern.gif")
				);
			}
		}

		static Image menupattern;
		protected static Image MenuPattern => menupattern;

		protected GlossyColorTable Colors => this.ColorTable as GlossyColorTable;

		public bool RenderRoundedEdges
		{
			get
			{
				return this.RoundedEdges;
			}
			set
			{
				RoundedEdges = value;
			}
		}

		protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
		{
			OnDrawToolStripDropDownMenu(e, true);
		}

		protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
		{
			if (e.ToolStrip is ToolStripDropDownMenu)
			{
				OnDrawToolStripDropDownMenu(e, false);
			}
			else
			{
				LinearGradientMode direction = LinearGradientMode.Vertical;
				//Console.WriteLine(e.ToolStrip);
				using (
					LinearGradientBrush l = new LinearGradientBrush(
						e.AffectedBounds,
						Colors.ToolStripGradientBegin,
						Colors.ToolStripGradientMiddle,
						direction
					)
				)
				{
					// Set colour values
					ColorBlend cb = new ColorBlend(4);
					cb.Colors = new Color[]
					{
						Colors.ToolStripGradientBegin,
						Colors.ToolStripGradientMiddle,
						Colors.ToolStripGradientMiddleEnd,
						Colors.ToolStripGradientEnd,
					};
					cb.Positions = new float[] { 0F, 0.495F, 0.505F, 1F };
					l.InterpolationColors = cb;

					// Fill background
					e.Graphics.FillRectangle(l, e.AffectedBounds);
					l.Dispose();
				}
			}
		}

		private void OnDrawToolStripDropDownMenu(
			ToolStripRenderEventArgs e,
			bool overlay
		)
		{
			TextureBrush t = new TextureBrush(menupattern);
			t.WrapMode = WrapMode.TileFlipXY;
			SolidBrush b = new SolidBrush(
				Color.FromArgb(50, Colors.ImageMarginGradientMiddle)
			);
			e.Graphics.FillRectangle(t, e.AffectedBounds);
			if (overlay)
			{
				e.Graphics.FillRectangle(b, e.AffectedBounds);
			}

			b.Dispose();
			t.Dispose();
		}

		protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
		{
			if (e.ToolStrip is MenuStrip)
			{
				Pen pen = new Pen(Colors.ToolStripBorder);
				e.Graphics.DrawLine(
					pen,
					new Point(0, e.ToolStrip.Height - 1),
					new Point(e.ToolStrip.Width, e.ToolStrip.Height - 1)
				);
				pen.Dispose();
			}
			else
			{
				base.OnRenderToolStripBorder(e);
			}
		}
	}

	public class GlossyColorTable : ProfessionalColorTable
	{
		private static GlossyColorTable global = new GlossyColorTable();
		public static GlossyColorTable Global => global;

		#region Checker
		public override Color CheckBackground => Color.Transparent;

		public override Color CheckPressedBackground => Color.Transparent;

		public override Color CheckSelectedBackground => CheckPressedBackground;

		#endregion

		#region Seperator
		public override Color SeparatorDark => Color.FromArgb(0xC5, 0xC2, 0xB8);

		public override Color SeparatorLight => Color.FromArgb(0xFC, 0xFC, 0xF9);
		#endregion

		#region MenuStrip

		public override Color MenuStripGradientBegin => Color.FromArgb(0xE5, 0xE5, 0xD7);

		public override Color MenuStripGradientEnd => ToolStripGradientEnd;

		public override Color MenuBorder => ToolStripBorder;
		#endregion

		#region ToolStrip
		/// <summary>
		///
		/// </summary>
		public override Color ToolStripGradientBegin => Color.White;

		/// <summary>
		///
		/// </summary>
		public override Color ToolStripGradientMiddle => Color.FromArgb(0xF1, 0xF1, 0xF1);

		/// <summary>
		///
		/// </summary>
		public Color ToolStripGradientMiddleEnd => Color.FromArgb(0xE9, 0xE9, 0xE9);

		/// <summary>
		///
		/// </summary>
		public override Color ToolStripGradientEnd => Color.FromArgb(0xFE, 0xFF, 0xFF);

		/// <summary>
		///
		/// </summary>
		public override Color ToolStripBorder => Color.FromArgb(0xB5, 0xC1, 0xC1);
		#endregion

		#region Overflow
		public override Color OverflowButtonGradientBegin => Color.FromArgb(0xEF, 0xEE, 0xEB);

		public override Color OverflowButtonGradientMiddle => Color.FromArgb(0xE1, 0xE1, 0xDA);

		public override Color OverflowButtonGradientEnd => Color.FromArgb(0x92, 0x92, 0x76);
		#endregion

		#region Image Margin
		public override Color ImageMarginGradientBegin => Color.FromArgb(0x5E, 0x6A, 0x79);

		public override Color ImageMarginGradientEnd => ImageMarginGradientBegin;

		public override Color ImageMarginGradientMiddle => ImageMarginGradientBegin;

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
		public override Color ToolStripPanelGradientBegin => Color.White;

		public override Color ToolStripPanelGradientEnd => Color.FromArgb(0xef, 0xef, 0xef);
		#endregion
	}
}
