// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

using TD.SandDock;

namespace Ambertation.Windows.Forms
{
	public class DockManagerDesigner : ParentControlDesigner
	{
		private DesignerVerbCollection actions;

		private DockManager manager;

		public override DesignerVerbCollection Verbs
		{
			get
			{
				if (actions == null)
				{
					actions = new DesignerVerbCollection();
					if (manager != null)
					{
						actions.Add(new DesignerVerb("&Add Container", AddContainer));
					}
				}

				return actions;
			}
		}

		public override void Initialize(IComponent component)
		{
			base.Initialize(component);
			manager = component as DockManager;
			ISelectionService selectionService = (ISelectionService)GetService(typeof(ISelectionService));
			IComponentChangeService componentChangeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
			selectionService.SelectionChanged += s_SelectionChanged;
			componentChangeService.ComponentRemoving += c_ComponentRemoving;
		}

		~DockManagerDesigner()
		{
			ISelectionService selectionService = (ISelectionService)GetService(typeof(ISelectionService));
			IComponentChangeService componentChangeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
			selectionService.SelectionChanged -= s_SelectionChanged;
			componentChangeService.ComponentRemoving -= c_ComponentRemoving;
		}

		private void s_SelectionChanged(object sender, EventArgs e)
		{
		}

		private void c_ComponentRemoving(object sender, ComponentEventArgs e)
		{
		}

		private void AddPanel(object sender, EventArgs e)
		{
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			_ = (IComponentChangeService)GetService(typeof(IComponentChangeService));
			designerHost.CreateTransaction("Add Panel");
			DockPanel dockPanel = (DockPanel)designerHost.CreateComponent(typeof(DockPanel));
			dockPanel.SetManager(manager);
			InitializeNewComponent(null);
			dockPanel.Parent = manager;
		}

		private void AddContainer(object sender, EventArgs e)
		{
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			DesignerTransaction designerTransaction = designerHost.CreateTransaction("Add Container");
			DockContainer dockContainer = (DockContainer)designerHost.CreateComponent(typeof(DockContainer));
			dockContainer.SetManager(manager);
			dockContainer.Dock = DockStyle.Left;
			IDictionary dictionary = new Dictionary<string, object>();
			dictionary.Add("Dock", DockStyle.Right);
			InitializeNewComponent(dictionary);
			manager.Controls.Add(dockContainer);
			designerTransaction.Commit();
		}
	}
}


