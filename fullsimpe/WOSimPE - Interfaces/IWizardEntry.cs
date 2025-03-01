// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Windows.Forms;

namespace SimPe.Wizards
{
	/// <summary>
	/// Contains a Interface that must be implemented by the FIRST Step of a Wizard Chain
	/// </summary>
	public interface IWizardEntry : IWizardForm
	{
		/// <summary>
		/// Returns a short Description of this Wizard
		/// </summary>
		string WizardDescription { get; }

		/// <summary>
		/// Returns the Title of that Wizard
		/// </summary>
		string WizardCaption { get; }

		/// <summary>
		/// Returns a Image that should be displayed for this wizard
		/// </summary>
		/// <remarks>can be null</remarks>
		System.Drawing.Image WizardImage { get; }
	}
}
