// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Drawing;
using System.Windows.Forms;

namespace Ambertation.Windows.Forms
{
	public interface IDockPanelRenderer
	{
		BaseDockPanelRenderer.Dimensions Dimension { get; }

		event DockAnimationEventHandler FinishedAnimation;

		DockPanelButtonManager ConstructButtonData(IButtonContainer cnt, NCPaintEventArgs e);

		Rectangle GetButtonsRectangle(ButtonOrientation orient, NCPaintEventArgs e, DockContainer dc);

		Rectangle GetPanelClientRectangle(DockPanel dp, ButtonOrientation orient);

		Rectangle GetPanelClientRectangle(DockContainer dc, NCPaintEventArgs e, ButtonOrientation orient);

		Padding GetGripSize(DockStyle dock);

		Rectangle GetGripRectangle(NCPaintEventArgs e, DockStyle dock);

		void RenderGrip(DockContainer dc, NCPaintEventArgs e, Rectangle r);

		void RenderResizePanel(DockContainer dc, RubberBandHelper rbh, PaintEventArgs e);

		Padding GetPanelBorderSize(DockContainer dc, DockPanel dp, ButtonOrientation orient);

		Padding GetBarBorderSize(ButtonOrientation orient);

		Padding GetBorderSize(IButtonContainer c);

		Size GetButtonSize(DockPanel dp);

		Size GetButtonSize(DockPanel dp, ButtonOrientation orient);

		string GetFittingString(Font font, string caption, ButtonOrientation orient, Size maxsz);

		Rectangle GetCaptionRect(DockPanel dp);

		Rectangle GetCaptionRect(DockPanel dp, ButtonOrientation orient);

		Rectangle GetCloseButtonRect(DockPanel dp, Rectangle caprect);

		Rectangle GetCollapseButtonRect(DockPanel dp, Rectangle caprect);

		Rectangle GetCaptionTextRect(DockPanel dp, Rectangle caprect);

		void RenderButtonBarBackground(NCPaintEventArgs e, Rectangle r, ButtonOrientation orient);

		void RenderButtonBackground(DockPanel dp, NCPaintEventArgs e);

		void RenderButton(System.Drawing.Graphics g, Rectangle r, string caption, Image img, ButtonOrientation orient, ButtonState state, bool renderbackgroundbar);

		void RenderCaption(DockPanel dp, NCPaintEventArgs e);

		void RenderCaptionButton(DockPanel dp, DockPanelCaptionButton but, NCPaintEventArgs e);

		void RenderBorder(DockPanel dp, NCPaintEventArgs e);

		void Animate(DockAnimationEventArgs e);
	}
}
