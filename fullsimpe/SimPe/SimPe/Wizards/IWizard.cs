// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Wizards
{
	public class WizardEventArgs : System.EventArgs
	{
		public WizardStepPanel Step
		{
			get;
		}

		public bool EnableNext
		{
			get; set;
		}

		public bool EnablePrev
		{
			get; set;
		}

		public bool CanFinish
		{
			get; set;
		}

		public bool Cancel
		{
			get; set;
		}

		public WizardEventArgs(
			WizardStepPanel step,
			bool ennext,
			bool enprev,
			bool canfin
		)
		{
			Step = step;
			EnableNext = ennext;
			EnablePrev = enprev;
			CanFinish = canfin;
			Cancel = false;
		}
	}

	public delegate void WizardHandle(Wizard sender);
	public delegate void WizardShowedHandle(Wizard sender, int source);
	public delegate void WizardChangeHandle(Wizard sender, WizardEventArgs e);
	public delegate void WizardStepHandle(Wizard sender, WizardStepPanel step);
	public delegate void WizardStepChangeHandle(
		Wizard sender,
		WizardStepPanel step,
		int target
	);
}
