// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Drawing;

namespace Ambertation.Windows.Forms
{
	internal class DockOverlay : ManagedLayeredForm
	{
		public DockOverlay(DockManager manager)
			: base(manager, manager.Renderer.ColorTable.DockHintOverlayColor, new Size(1, 1))
		{
		}
	}
}
