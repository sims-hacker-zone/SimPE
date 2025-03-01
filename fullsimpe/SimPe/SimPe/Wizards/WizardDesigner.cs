// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace SimPe.Wizards
{
	internal class WizardDesigner : System.Windows.Forms.Design.ControlDesigner
	{
		public WizardDesigner()
		{
			wz = null;
		}

		private DesignerVerbCollection actions;
		public override DesignerVerbCollection Verbs
		{
			get
			{
				if (actions == null)
				{
					actions = new DesignerVerbCollection
					{
						new DesignerVerb("&Add Step", new EventHandler(AddStep)),
						new DesignerVerb(
							"Show &First Step",
							new EventHandler(ShowFirstStep)
						),
						new DesignerVerb(
							"Show &Prev. Step",
							new EventHandler(ShowPrevStep)
						),
						new DesignerVerb(
							"Show &Next Step",
							new EventHandler(ShowNextStep)
						),
						new DesignerVerb(
							"Show &Last Step",
							new EventHandler(ShowLastStep)
						)
					};
				}

				return actions;
			}
		}

		Wizard wz;

		public override void Initialize(IComponent component)
		{
			base.Initialize(component);
			wz = (Wizard)component;

			// Hook up events
			ISelectionService s = (ISelectionService)GetService(
				typeof(ISelectionService)
			);
			IComponentChangeService c = (IComponentChangeService)GetService(
				typeof(IComponentChangeService)
			);
			s.SelectionChanged += new EventHandler(OnSelectionChanged);
			c.ComponentRemoving += new ComponentEventHandler(OnComponentRemoving);
		}

		private void OnSelectionChanged(object sender, EventArgs e)
		{
			//MyControl.OnSelectionChanged();
		}

		private void OnComponentRemoving(object sender, ComponentEventArgs e)
		{
			IComponentChangeService c = (IComponentChangeService)GetService(
				typeof(IComponentChangeService)
			);
			WizardStepPanel button;
			IDesignerHost h = (IDesignerHost)GetService(typeof(IDesignerHost));

			// If the user is removing a button
			if (e.Component is WizardStepPanel)
			{
				button = (WizardStepPanel)e.Component;
				if (wz.Contains(button))
				{
					c.OnComponentChanging(wz, null);
					wz.Controls.Remove(button);
					c.OnComponentChanged(wz, null, null, null);
					return;
				}
			}
			// If the user is removing the control itself
			if (e.Component == wz)
			{
				for (int i = wz.Controls.Count - 1; i >= 0; i--)
				{
					button = (WizardStepPanel)wz.Controls[i];
					c.OnComponentChanging(wz, null);
					wz.Controls.Remove(button);
					h.DestroyComponent(button);
					c.OnComponentChanged(wz, null, null, null);
				}
			}
		}

		protected override void Dispose(bool disposing)
		{
			ISelectionService s = (ISelectionService)GetService(
				typeof(ISelectionService)
			);
			IComponentChangeService c = (IComponentChangeService)GetService(
				typeof(IComponentChangeService)
			);
			// Unhook events
			s.SelectionChanged -= new EventHandler(OnSelectionChanged);
			c.ComponentRemoving -= new ComponentEventHandler(OnComponentRemoving);
			base.Dispose(disposing);
		}

		public override System.Collections.ICollection AssociatedComponents => wz.Controls;

		private void ShowNextStep(object sender, EventArgs e)
		{
			wz.GoNext();
		}

		private void ShowPrevStep(object sender, EventArgs e)
		{
			wz.GoPrev();
		}

		private void ShowFirstStep(object sender, EventArgs e)
		{
			wz.JumpToStep(0);
		}

		private void ShowLastStep(object sender, EventArgs e)
		{
			wz.JumpToStep(wz.StepCount - 1);
		}

		private void AddStep(object sender, EventArgs e)
		{
			WizardStepPanel pn;
			IDesignerHost h = (IDesignerHost)GetService(typeof(IDesignerHost));

			DesignerTransaction dt;
			IComponentChangeService c = (IComponentChangeService)GetService(
				typeof(IComponentChangeService)
			);

			// Add a new button to the collection
			dt = h.CreateTransaction("Add Step");
			pn = (WizardStepPanel)h.CreateComponent(typeof(WizardStepPanel));
			((ComponentDesigner)h.GetDesigner(pn)).OnSetComponentDefaults();

			c.OnComponentChanging(
				wz,
				TypeDescriptor.GetProperties(wz)["Controls"]
			);
			c.OnComponentChanging(pn, null);
			wz.Controls.Add(pn);
			c.OnComponentChanged(pn, null, null, null);
			c.OnComponentChanged(
				wz,
				TypeDescriptor.GetProperties(wz)["Controls"],
				null,
				null
			);
			dt.Commit();
		}

		/*public override void OnSetComponentDefaults()
		{
			base.OnSetComponentDefaults ();
		}*/
	}
}
