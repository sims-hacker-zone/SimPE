// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Drawing;
using System.Windows.Forms;

using TD.SandDock;

namespace Ambertation.Windows.Forms
{
	public abstract class BaseDockManager : DockContainer
	{
		private BaseRenderer rnd;

		protected bool dockmode;

		protected DockButtonBar.DockPanelList floatingpanels;

		public BaseRenderer Renderer
		{
			get
			{
				return rnd;
			}
			set
			{
				rnd = value;
			}
		}

		public bool DockMode => dockmode;

		protected abstract bool MeAsCenterDock { get; }

		public BaseDockManager(BaseRenderer renderer)
			: base(null)
		{
			rnd = renderer;
			floatingpanels = new DockButtonBar.DockPanelList();
		}

		internal void NotifyFloating(DockPanel dp)
		{
			if (dp.Floating && !floatingpanels.Contains(dp))
			{
				floatingpanels.Add(dp);
			}
			else if (!dp.Floating && floatingpanels.Contains(dp))
			{
				floatingpanels.Remove(dp);
			}
		}

		internal abstract void StartDockMode(DockPanel dock);

		internal abstract void StopDockMode(DockPanel dock);

		internal abstract void MouseMoved(Point scrpt);

		internal virtual void DockPanelInt(DockPanel dp, DockStyle style)
		{
			bool flag = false;
			SuspendLayout();
			if (style == DockStyle.Fill && MeAsCenterDock)
			{
				flag = true;
				dp.DockControl(this);
				ResumeLayout();
				return;
			}

			foreach (DockContainer container in containers)
			{
				if (container.Dock == style)
				{
					flag = true;
					dp.DockControl(container);
					break;
				}
			}

			if (!flag)
			{
				DockContainer dockContainer = CreateNewContainer(-1, after: false, toplevel: true, style);
				dockContainer.SetNoCleanUpIntern(val: true);
				dockContainer.Visible = true;
				dockContainer.Width = Math.Max(dockContainer.Width, dp.Width);
				dockContainer.Height = Math.Max(dockContainer.Height, dp.Height);
				dp.DockControl(dockContainer);
				dockContainer.SetNoCleanUpIntern(val: false);
			}

			ResumeLayout();
		}
	}
}
