// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
namespace SimPe
{
	public partial class MainForm
	{
		void InitTheme()
		{
			dcResourceList.Visible = true;
			dcResource.Visible = true;
			//setup the Theme Manager

			manager.Renderer = new Ambertation.Windows.Forms.GlossyRenderer();
		}

		/// <summary>
		/// Wrapper needed to call the Layout Change through an Event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ResetLayout(object sender, EventArgs e)
		{
			Helper.WindowsRegistry.Config.Layout = new Registry.LayoutConfiguration();
			Helper.WindowsRegistry.SaveConfig();
		}
	}
}
