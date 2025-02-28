// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Windows.Forms;

namespace SimPe.Wizards
{
	/// <summary>
	/// This has to be implemented by the last Step in the Wizard Chain
	/// </summary>
	public interface IWizardFinish : IWizardForm
	{
		/// <summary>
		/// This Method is called BEFORE the Panle get's displayed
		/// </summary>
		void Finit();
	}
}
