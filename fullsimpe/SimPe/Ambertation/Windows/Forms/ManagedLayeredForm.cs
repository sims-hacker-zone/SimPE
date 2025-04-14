// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Drawing;
using System.Windows.Forms;

namespace Ambertation.Windows.Forms
{
	public class ManagedLayeredForm : LayeredForm
	{
		private DockManager manager;

		internal DockManager Manager => manager;

		protected ManagedLayeredForm(DockManager manager)
		{
			this.manager = manager;
		}

		internal ManagedLayeredForm(DockManager manager, Bitmap bitmap)
			: base(bitmap)
		{
			this.manager = manager;
		}

		internal ManagedLayeredForm(DockManager manager, Color cl, Size sz)
			: base(cl, sz)
		{
			this.manager = manager;
		}

		internal virtual void MouseOver(Point pt, bool hit)
		{
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
		}

		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.ClientSize = new System.Drawing.Size(1115, 759);
			base.Name = "ManagedLayeredForm";
			base.ResumeLayout(false);
		}
	}
}
