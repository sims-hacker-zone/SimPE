// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using ButtonState = Ambertation.Windows.Forms.ButtonState;

namespace Ambertation.Windows.Forms
{
	public abstract class BaseDockPanelRenderer : BaseControlRenderer, IDisposable
	{
		public class Dimensions
		{
			private int caption;

			private int buttons;

			private int gripsz;

			private int border;

			private int dbarspace;

			private int padding;

			private int imgpadding;

			private int iconsz;

			private int shrinkwd;

			public int Caption => caption;

			public int Buttons => buttons;

			public int GripSize => gripsz;

			public int Border => border;

			public int DockBarButtonSpacing => dbarspace;

			public int ButtonTextPadding => padding;

			public int ButtonTextImagePadding => imgpadding;

			public int IconSize => iconsz;

			public int ShrinkWidth => shrinkwd;

			public Dimensions(int capt, int but, int bord, int dbarspace, int pad, int imgpad, int iconsize, int gripsz)
				: this(capt, but, bord, dbarspace, pad, imgpad, iconsize, gripsz, 0)
			{
			}

			public Dimensions(int capt, int but, int bord, int dbarspace, int pad, int imgpad, int iconsize, int gripsz, int shrinkwd)
			{
				caption = capt;
				buttons = but;
				border = bord;
				this.dbarspace = dbarspace;
				padding = pad;
				imgpadding = imgpad;
				iconsz = iconsize;
				this.gripsz = gripsz;
				this.shrinkwd = shrinkwd;
			}
		}

		private System.Drawing.Graphics dg = System.Drawing.Graphics.FromImage(new Bitmap(1, 1));

		public abstract Dimensions Dimension { get; }

		public BaseDockPanelRenderer(BaseRenderer parent)
			: base(parent)
		{
		}

		public virtual DockPanelButtonManager ConstructButtonData(IButtonContainer cnt, NCPaintEventArgs e)
		{
			return new DockPanelButtonManager(base.Parent, e, cnt);
		}

		public virtual Padding GetGripSize(DockStyle dock)
		{
			switch (dock)
			{
				case DockStyle.Right:
					return new Padding(Dimension.GripSize, 0, 0, 0);
				case DockStyle.Bottom:
					return new Padding(0, Dimension.GripSize, 0, 0);
				case DockStyle.Left:
					return new Padding(0, 0, Dimension.GripSize, 0);
				case DockStyle.Top:
					return new Padding(0, 0, 0, Dimension.GripSize);
				default:
					return new Padding(0);
			}
		}

		public virtual Rectangle GetGripRectangle(NCPaintEventArgs e, DockStyle dock)
		{
			switch (dock)
			{
				case DockStyle.Right:
					return new Rectangle(-1, -1, Dimension.GripSize + 1, e.WindowRectangle.Height + 1);
				case DockStyle.Bottom:
					return new Rectangle(-1, -1, e.WindowRectangle.Width + 1, Dimension.GripSize + 1);
				case DockStyle.Left:
					return new Rectangle(e.WindowRectangle.Width - Dimension.GripSize, -1, Dimension.GripSize + 1, e.WindowRectangle.Height + 1);
				case DockStyle.Top:
					return new Rectangle(-1, e.WindowRectangle.Height - Dimension.GripSize, e.WindowRectangle.Width + 1, Dimension.GripSize + 1);
				default:
					return Rectangle.Empty;
			}
		}

		public virtual Padding GetPanelBorderSize(DockContainer dc, DockPanel dp, ButtonOrientation orient)
		{
			Rectangle rectangle = new Rectangle(0, 0, 100, 100);
			Rectangle buttonsRectangle = GetButtonsRectangle(orient, new NCPaintEventArgs(null, rectangle, rectangle, null), dc);
			int num = Dimension.Border;
			int num2 = Dimension.Caption;
			if (dp != null)
			{
				if (dp.Floating && !dp.FloatContainer)
				{
					return new Padding(0);
				}

				if (dp.FloatContainer)
				{
					num = 0;
					num2 = 0;
				}
			}

			Padding padding;

			switch (orient)
			{
				case ButtonOrientation.Bottom:
					padding = new Padding(num, num2 + num, num, num + buttonsRectangle.Height);
					break;
				case ButtonOrientation.Right:
					padding = new Padding(num, num2 + num, num + buttonsRectangle.Width, num);
					break;
				case ButtonOrientation.Top:
					padding = new Padding(num, num2 + num + buttonsRectangle.Height, num, num);
					break;
				default:
					padding = new Padding(num + buttonsRectangle.Width, num2 + num, num, num);
					break;
			}

			return padding;
		}

		public virtual Padding GetBarBorderSize(ButtonOrientation orient)
		{
			return new Padding(0, 0, 0, 0);
		}

		public Padding GetBorderSize(IButtonContainer c)
		{
			return c.GetBorderSize(c.BestOrientation);
		}

		protected int GetButtonCaptionWidth(Font font, string caption)
		{
			return GetButtonCaptionWidth(font, dg, caption, ButtonOrientation.Bottom, int.MaxValue);
		}

		protected int GetButtonCaptionWidth(Font font, string caption, ButtonOrientation orient)
		{
			return GetButtonCaptionWidth(font, dg, caption, orient, int.MaxValue);
		}

		protected int GetButtonCaptionWidth(Font font, string caption, ButtonOrientation orient, int maxwd)
		{
			return GetButtonCaptionWidth(font, dg, caption, orient, maxwd);
		}

		protected virtual int GetButtonCaptionWidth(Font font, System.Drawing.Graphics g, string caption, ButtonOrientation orient, int maxwd)
		{
			StringFormat format = ((orient != 0 && orient != ButtonOrientation.Top) ? new StringFormat(StringFormatFlags.DirectionVertical | StringFormatFlags.NoWrap | StringFormatFlags.NoClip) : new StringFormat(StringFormatFlags.NoWrap | StringFormatFlags.NoClip));
			SizeF sizeF = g.MeasureString(caption, font, int.MaxValue, format);
			if (orient == ButtonOrientation.Bottom || orient == ButtonOrientation.Top)
			{
				return (int)sizeF.Width;
			}

			return (int)sizeF.Height;
		}

		public string GetFittingString(Font font, string caption, ButtonOrientation orient, Size maxsz)
		{
			return GetFittingString(font, dg, caption, orient, maxsz);
		}

		protected virtual string GetFittingString(Font font, System.Drawing.Graphics g, string caption, ButtonOrientation orient, Size maxsz)
		{
			int num = maxsz.Width;
			if (orient == ButtonOrientation.Left || orient == ButtonOrientation.Right)
			{
				num = maxsz.Height;
			}

			int buttonCaptionWidth = GetButtonCaptionWidth(font, g, caption, orient, num);
			bool flag = false;
			while (buttonCaptionWidth > num && caption.Length > 0)
			{
				caption = ((caption.Length > 1) ? caption.Substring(0, caption.Length - 1) : "");
				flag = true;
				buttonCaptionWidth = GetButtonCaptionWidth(font, g, caption + "...", orient, num);
			}

			if (caption.Length > 0 && flag)
			{
				caption += "...";
			}

			return caption;
		}

		public virtual Rectangle GetPanelClientRectangle(DockPanel dp, ButtonOrientation orient)
		{
			Padding panelBorderSize = GetPanelBorderSize(dp.DockContainer, dp, orient);
			return new Rectangle(panelBorderSize.Left, panelBorderSize.Top, dp.Width - panelBorderSize.Horizontal, dp.Height - panelBorderSize.Vertical);
		}

		public virtual Rectangle GetPanelClientRectangle(DockContainer dc, NCPaintEventArgs e, ButtonOrientation orient)
		{
			Padding panelBorderSize = GetPanelBorderSize(dc, null, orient);
			return new Rectangle(panelBorderSize.Left, panelBorderSize.Top, e.WindowRectangle.Width - panelBorderSize.Horizontal, e.WindowRectangle.Height - panelBorderSize.Vertical);
		}

		public Rectangle GetCaptionRect(DockPanel dp)
		{
			return GetCaptionRect(dp, dp.BestOrientation);
		}

		public virtual Rectangle GetCaptionRect(DockPanel dp, ButtonOrientation orient)
		{
			NCPaintEventArgs e = new NCPaintEventArgs(null, dp.ClientRectangle, dp.Bounds, null);
			GetButtonsRectangle(orient, e, dp.DockContainer);
			Rectangle panelClientRectangle = GetPanelClientRectangle(dp, orient);
			return new Rectangle(panelClientRectangle.Left, panelClientRectangle.Top - Dimension.Caption, panelClientRectangle.Width, Dimension.Caption);
		}

		public virtual Rectangle GetCloseButtonRect(DockPanel dp, Rectangle caprect)
		{
			if (!dp.ShowCloseButton)
			{
				return Rectangle.Empty;
			}

			int x = caprect.Right - Dimension.Caption - Dimension.Border;
			return new Rectangle(x, caprect.Top, Dimension.Caption - 2, Dimension.Caption - 2);
		}

		public virtual Rectangle GetCollapseButtonRect(DockPanel dp, Rectangle caprect)
		{
			if (!dp.ShowCollapseButton)
			{
				return Rectangle.Empty;
			}

			int num = caprect.Right - Dimension.Caption - Dimension.Border;
			if (dp.ShowCloseButton)
			{
				num -= Dimension.Caption + 1;
			}

			return new Rectangle(num, caprect.Top, Dimension.Caption - 2, Dimension.Caption - 2);
		}

		public virtual Rectangle GetCaptionTextRect(DockPanel dp, Rectangle caprect)
		{
			int width = caprect.Width;
			Rectangle collapseButtonRect = GetCollapseButtonRect(dp, caprect);
			Rectangle closeButtonRect = GetCloseButtonRect(dp, caprect);
			int num = 0;
			if (collapseButtonRect != Rectangle.Empty)
			{
				num = caprect.Width - collapseButtonRect.Left + 4;
			}

			if (closeButtonRect != Rectangle.Empty)
			{
				num = Math.Max(num, caprect.Width - closeButtonRect.Left + 4);
			}

			width = Math.Max(1, width - num);
			return new Rectangle(caprect.Left, caprect.Top, width, caprect.Height);
		}

		protected virtual void DrawButtonImage(System.Drawing.Graphics g, string name, Rectangle r, bool focused)
		{
			name = "Ambertation.Windows.Forms." + name;
			if (focused)
			{
				name += "_f";
			}

			name += ".png";
			Stream manifestResourceStream = GetType().Assembly.GetManifestResourceStream(name);
			if (manifestResourceStream != null)
			{
				Image image = Image.FromStream(manifestResourceStream);
				int num = (r.Width - image.Width) / 2 + r.Left;
				int num2 = (r.Height - image.Height) / 2 + r.Top;
				g.DrawImage(image, num + 1, num2 + 1);
			}
		}

		protected virtual CaptionState GetCaptionState(DockPanel dp)
		{
			return dp.CaptionState;
		}

		protected virtual void SetupButtonColors(Rectangle r, Color c, Color ci, Color fontc, ButtonOrientation orient, ButtonState state, out SolidBrush fontbrush, out SolidBrush linebackgroundbrush, out Brush backgroundbrush, out Pen borderpen, out Pen borderpeninner)
		{
			fontbrush = new SolidBrush(fontc);
			Color color = base.ColorTable.DockButtonBackgroundTop;
			Color color2 = base.ColorTable.DockButtonBackgroundBottom;
			if (state == ButtonState.Highlight)
			{
				color = base.ColorTable.DockButtonHighlightBackgroundTop;
				color2 = base.ColorTable.DockButtonHighlightBackgroundBottom;
			}

			linebackgroundbrush = new SolidBrush(base.ColorTable.DockButtonHighlightBackgroundTop);
			if (orient == ButtonOrientation.Top || orient == ButtonOrientation.Left)
			{
				Color color3 = color;
				color = color2;
				color2 = color3;
			}

			LinearGradientMode linearGradientMode = LinearGradientMode.Vertical;
			if (orient == ButtonOrientation.Left || orient == ButtonOrientation.Right)
			{
				linearGradientMode = LinearGradientMode.Horizontal;
			}

			backgroundbrush = new LinearGradientBrush(r, color, color2, linearGradientMode);
			borderpen = new Pen(c);
			borderpeninner = new Pen(ci);
		}

		protected virtual Rectangle SetupButtonRectangles(Rectangle r, Rectangle fullr, Font f, ButtonOrientation orient, out Rectangle linerectangle, out Point linept1, out Point linept2, out Rectangle textrect, out Rectangle imgrect)
		{
			switch (orient)
			{
				case ButtonOrientation.Bottom:
					{
						linerectangle = new Rectangle(fullr.Left, fullr.Top - 1, fullr.Width, 3);
						linept1 = new Point(linerectangle.Left, linerectangle.Bottom);
						linept2 = new Point(linerectangle.Right, linerectangle.Bottom);
						int num4 = r.Height - linerectangle.Height;
						imgrect = new Rectangle(r.Left + Dimension.ButtonTextPadding, linerectangle.Bottom + (num4 - Dimension.IconSize) / 2, Dimension.IconSize, Dimension.IconSize);
						textrect = new Rectangle(imgrect.Right + Dimension.ButtonTextImagePadding, linerectangle.Bottom + (num4 - f.Height) / 2, r.Width - imgrect.Width - 2 * Dimension.ButtonTextPadding - Dimension.ButtonTextImagePadding, f.Height);
						r = new Rectangle(r.Left, r.Top, r.Width, r.Height - 2);
						break;
					}
				case ButtonOrientation.Top:
					{
						linerectangle = new Rectangle(fullr.Left, fullr.Bottom - 4, fullr.Width, 4);
						linept1 = new Point(linerectangle.Left, linerectangle.Top);
						linept2 = new Point(linerectangle.Right, linerectangle.Top);
						int num3 = r.Height - linerectangle.Height;
						imgrect = new Rectangle(r.Left + Dimension.ButtonTextPadding, r.Top + (num3 - Dimension.IconSize) / 2, Dimension.IconSize, Dimension.IconSize);
						textrect = new Rectangle(imgrect.Right + Dimension.ButtonTextImagePadding, r.Top + (num3 - f.Height) / 2, r.Width - imgrect.Width - 2 * Dimension.ButtonTextPadding - Dimension.ButtonTextImagePadding, f.Height);
						r = new Rectangle(r.Left, r.Top + 1, r.Width, r.Height - 2);
						break;
					}
				case ButtonOrientation.Right:
					{
						linerectangle = new Rectangle(fullr.Left - 1, fullr.Top, 4, fullr.Height);
						linept1 = new Point(linerectangle.Right, linerectangle.Top);
						linept2 = new Point(linerectangle.Right, linerectangle.Bottom);
						int num2 = r.Width - linerectangle.Width;
						imgrect = new Rectangle(linerectangle.Right + (num2 - Dimension.IconSize) / 2 + 1, r.Top + Dimension.ButtonTextPadding, Dimension.IconSize, Dimension.IconSize);
						textrect = new Rectangle(linerectangle.Right + (num2 - f.Height) / 2 - 1, imgrect.Bottom + Dimension.ButtonTextImagePadding, f.Height, r.Height - imgrect.Height - 2 * Dimension.ButtonTextPadding - Dimension.ButtonTextImagePadding);
						r = new Rectangle(r.Left, r.Top, r.Width - 2, r.Height);
						break;
					}
				default:
					{
						linerectangle = new Rectangle(fullr.Right - 3, fullr.Top, 4, fullr.Height);
						linept1 = new Point(linerectangle.Left, linerectangle.Top);
						linept2 = new Point(linerectangle.Left, linerectangle.Bottom);
						int num = r.Width - linerectangle.Width;
						imgrect = new Rectangle(r.Left + (num - Dimension.IconSize) / 2 + 1, r.Top + Dimension.ButtonTextPadding, Dimension.IconSize, Dimension.IconSize);
						textrect = new Rectangle(r.Left + (num - f.Height) / 2 - 1, imgrect.Bottom + Dimension.ButtonTextImagePadding, f.Height, r.Height - imgrect.Height - 2 * Dimension.ButtonTextPadding - Dimension.ButtonTextImagePadding);
						r = new Rectangle(r.Left + 1, r.Top, r.Width - 2, r.Height);
						break;
					}
			}

			return r;
		}

		public void RenderButton(System.Drawing.Graphics g, Rectangle r, string caption, Image img, ButtonOrientation orient, ButtonState state, bool renderbackgroundbar)
		{
			if (r.Height != 0 && r.Width != 0)
			{
				Rectangle fullr = r;
				ModifyButtonRectangle(ref r, caption, img, orient, state, renderbackgroundbar);
				Color c = base.ColorTable.DockButtonBorderColorOuter;
				Color ci = base.ColorTable.DockButtonBorderColorInner;
				Color fontc = base.ColorTable.DockButtonTextColor;
				Font font = base.Parent.FontTable.ButtonFont;
				if (state == ButtonState.Highlight)
				{
					c = base.ColorTable.DockButtonHighlightBorderColorOuter;
					ci = base.ColorTable.DockButtonHighlightBorderColorInner;
					fontc = base.ColorTable.DockButtonHighlightTextColor;
					font = base.Parent.FontTable.ButtonHighlightFont;
				}

				StringFormat sf = ((orient != 0 && orient != ButtonOrientation.Top) ? new StringFormat(StringFormatFlags.DirectionVertical) : new StringFormat());
				caption = GetFittingString(font, caption, orient, new Size(r.Width, r.Height));
				RenderButton(g, r, fullr, caption, img, c, ci, fontc, font, sf, orient, state, renderbackgroundbar);
			}
		}

		protected virtual void ModifyButtonRectangle(ref Rectangle r, string caption, Image img, ButtonOrientation orient, ButtonState state, bool renderbackgroundbar)
		{
		}

		protected abstract void RenderButton(System.Drawing.Graphics g, Rectangle r, Rectangle fullr, string caption, Image img, Color c, Color ci, Color fontc, Font f, StringFormat sf, ButtonOrientation orient, ButtonState state, bool renderbackgroundbar);

		public void RenderCaption(DockPanel dp, NCPaintEventArgs e)
		{
			Rectangle captionRect = GetCaptionRect(dp);
			Rectangle captionTextRect = GetCaptionTextRect(dp, captionRect);
			string fittingString = GetFittingString(base.Parent.FontTable.CaptionFont, dp.CaptionText, ButtonOrientation.Top, new Size(captionTextRect.Width, captionTextRect.Height));
			if (captionRect.Width > 0 && captionRect.Height > 0)
			{
				RenderCaptionBackground(dp.CaptionState, e, captionRect);
			}

			RenderCaptionText(dp.CaptionState, e, captionTextRect, fittingString);
		}

		public void RenderCaptionButton(DockPanel dp, DockPanelCaptionButton but, NCPaintEventArgs e)
		{
			if (but.Visible)
			{
				RenderCaptionButton(dp, but, but.ImageName, e);
			}
		}

		protected abstract void RenderCaptionButton(DockPanel dp, DockPanelCaptionButton but, string iname, NCPaintEventArgs e);

		protected abstract void RenderCaptionText(CaptionState state, NCPaintEventArgs e, Rectangle txtrect, string caption);

		protected abstract void RenderCaptionBackground(CaptionState state, NCPaintEventArgs e, Rectangle caprect);

		protected virtual LinearGradientMode GetGradientMode(ButtonOrientation orient)
		{
			LinearGradientMode result = LinearGradientMode.Vertical;
			if (orient == ButtonOrientation.Left || orient == ButtonOrientation.Right)
			{
				result = LinearGradientMode.Horizontal;
			}

			return result;
		}

		public virtual void RenderButtonBarBackground(NCPaintEventArgs e, Rectangle r, ButtonOrientation orient)
		{
			LinearGradientMode gradientMode = GetGradientMode(orient);
			Color dockButtonBarBackgroundTop = base.ColorTable.DockButtonBarBackgroundTop;
			Color dockButtonBarBackgroundBottom = base.ColorTable.DockButtonBarBackgroundBottom;
			LinearGradientBrush brush = new LinearGradientBrush(r, dockButtonBarBackgroundTop, dockButtonBarBackgroundBottom, gradientMode);
			e.Graphics.FillRectangle(brush, r);
		}

		public void RenderButtonBackground(DockPanel dp, NCPaintEventArgs e)
		{
			if (!(dp.DockContainer == null))
			{
				Rectangle buttonsRectangle = GetButtonsRectangle(dp.BestOrientation, e, dp.DockContainer);
				ButtonOrientation bestOrientation = dp.BestOrientation;
				Size buttonSize = GetButtonSize(dp, bestOrientation);
				Rectangle rectangle;
				Point pt;
				Point pt2;
				switch (bestOrientation)
				{
					case ButtonOrientation.Top:
						rectangle = new Rectangle(buttonsRectangle.Left, buttonsRectangle.Top + buttonSize.Height - 4, e.WindowRectangle.Width, 3);
						pt = new Point(rectangle.Left, rectangle.Top);
						pt2 = new Point(rectangle.Right, rectangle.Top);
						break;
					case ButtonOrientation.Bottom:
						rectangle = new Rectangle(buttonsRectangle.Left, e.WindowRectangle.Height - buttonSize.Height - 1, e.WindowRectangle.Width, 3);
						pt = new Point(rectangle.Left, rectangle.Bottom);
						pt2 = new Point(rectangle.Right, rectangle.Bottom);
						break;
					case ButtonOrientation.Right:
						rectangle = new Rectangle(buttonsRectangle.Left, buttonsRectangle.Top, 3, buttonsRectangle.Height);
						pt = new Point(rectangle.Right, rectangle.Top);
						pt2 = new Point(rectangle.Right, rectangle.Bottom);
						break;
					default:
						rectangle = new Rectangle(buttonsRectangle.Right - 3, buttonsRectangle.Top, 3, buttonsRectangle.Height);
						pt = new Point(rectangle.Left, rectangle.Top);
						pt2 = new Point(rectangle.Left, rectangle.Bottom);
						break;
				}

				SolidBrush brush = new SolidBrush(base.ColorTable.DockButtonHighlightBackgroundTop);
				Pen pen = new Pen(base.ColorTable.DockButtonHighlightBorderColorOuter);
				RenderButtonBackground(e, rectangle, buttonsRectangle, pt, pt2, dp);
				RenderButtonBackground(e, rectangle, pt, pt2, brush, pen);
			}
		}

		protected virtual void RenderButtonBackground(NCPaintEventArgs e, Rectangle barr, Rectangle r, Point pt1, Point pt2, DockPanel dp)
		{
		}

		protected abstract void RenderButtonBackground(NCPaintEventArgs e, Rectangle r, Point pt1, Point pt2, SolidBrush brush, Pen pen);

		public Rectangle GetButtonsRectangle(ButtonOrientation orient, NCPaintEventArgs e, DockContainer dc)
		{
			bool flag = false;
			if (dc != null)
			{
				flag = dc.OneChild && dc.HideSingleButton;
			}

			int num = Dimension.Buttons;
			if (flag)
			{
				num = 0;
			}

			Rectangle rect;

			switch (orient)
			{
				case ButtonOrientation.Bottom:
					rect = new Rectangle(0, e.WindowRectangle.Height - num, e.WindowRectangle.Width, num);
					break;
				case ButtonOrientation.Top:
					rect = new Rectangle(0, 0, e.WindowRectangle.Width, num);
					break;
				case ButtonOrientation.Left:
					rect = new Rectangle(0, 0, num, e.WindowRectangle.Height);
					break;
				default:
					rect = new Rectangle(e.WindowRectangle.Width - num, 0, num, e.WindowRectangle.Height);
					break;
			}

			return rect;

		}

		public Size GetButtonSize(DockPanel dp)
		{
			return GetButtonSize(dp, dp.BestOrientation);
		}

		public virtual Size GetButtonSize(DockPanel dp, ButtonOrientation orient)
		{
			if (orient == ButtonOrientation.Top || orient == ButtonOrientation.Bottom)
			{
				return new Size(GetButtonCaptionWidth(GetFont(dp), dp.ButtonText, orient) + 1 + Dimension.IconSize + 2 * Dimension.ButtonTextPadding + Dimension.ButtonTextImagePadding + Dimension.ShrinkWidth, Dimension.Buttons);
			}

			return new Size(Dimension.Buttons, GetButtonCaptionWidth(GetFont(dp), dp.ButtonText, orient) + 1 + Dimension.IconSize + 2 * Dimension.ButtonTextPadding + Dimension.ButtonTextImagePadding + Dimension.ShrinkWidth);
		}

		public Font GetFont(DockPanel dp)
		{
			if (dp == null)
			{
				return base.Parent.FontTable.ButtonFont;
			}

			if (dp.DockContainer == null)
			{
				return base.Parent.FontTable.ButtonFont;
			}

			if (dp.DockContainer.Highlight == dp)
			{
				return base.Parent.FontTable.ButtonHighlightFont;
			}

			return base.Parent.FontTable.ButtonFont;
		}

		public void Dispose()
		{
			dg.Dispose();
		}
	}
}
