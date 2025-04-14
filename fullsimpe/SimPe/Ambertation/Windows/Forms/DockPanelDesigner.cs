// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Ambertation.Windows.Forms
{
	public class DockPanelDesigner : ParentControlDesigner
	{
		private DesignerVerbCollection actions;

		private DockPanel dp;

		public override DesignerVerbCollection Verbs
		{
			get
			{
				if (actions == null)
				{
					actions = new DesignerVerbCollection();
					actions.Add(new DesignerVerb("&Add Container", AddContainer));
					actions.Add(new DesignerVerb("&Add Panel", AddPanel));
				}

				return actions;
			}
		}

		public override void Initialize(IComponent component)
		{
			base.Initialize(component);
			dp = component as DockPanel;
		}

		private void AddContainer(object sender, EventArgs e)
		{
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			DesignerTransaction designerTransaction = designerHost.CreateTransaction("Add Container");
			DockContainer dockContainer = (DockContainer)designerHost.CreateComponent(typeof(DockContainer));
			dockContainer.SetManager(dp.DockContainer.Manager);
			dockContainer.Dock = DockStyle.Left;
			dockContainer.Width = Math.Max(dp.DockContainer.Width - 30, dp.DockContainer.MinimumDockSize);
			dockContainer.Height = Math.Max(dp.DockContainer.Height - 30, dp.DockContainer.MinimumDockSize);
			IDictionary dictionary = new Dictionary<string, object>();
			dictionary.Add("Dock", DockStyle.Right);
			InitializeNewComponent(dictionary);
			dp.DockContainer.Controls.Add(dockContainer);
			designerTransaction.Commit();
		}

		private void AddPanel(object sender, EventArgs e)
		{
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			_ = (IComponentChangeService)GetService(typeof(IComponentChangeService));
			DesignerTransaction designerTransaction = designerHost.CreateTransaction("Add Panel");
			DockPanel dockPanel = (DockPanel)designerHost.CreateComponent(typeof(DockPanel));
			dockPanel.SetManager(dp.DockContainer.Manager);
			InitializeNewComponent(null);
			dockPanel.SetManager(dp.DockContainer.Manager);
			dockPanel.DockControl(dp.DockContainer);
			designerTransaction.Commit();
		}

		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
				case 133:
					m.WParam = dp.CallNCPaint(m.WParam);
					break;
				case 160:
				case 161:
				case 162:
				case 164:
				case 165:
				case 167:
				case 168:
					{
						NCMouseEventArgs e = dp.CallGetMouseParams(ref m, getdelta: true);
						if (m.Msg == 161 || m.Msg == 167 || m.Msg == 164)
						{
							dp.CallNcMouseDown(e);
						}

						break;
					}
			}

			base.WndProc(ref m);
		}
	}
}
