// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Drawing;

namespace SimPe.Plugin.Tool.Window
{
	/// <summary>
	/// Tool that should automatically repair corrupted packages
	/// </summary>
	public class InstallerTool : Interfaces.IToolPlus
	{
		public InstallerTool()
		{
		}

		#region IToolPlus Member

		public void Execute(object sender, Events.ResourceEventArgs e)
		{
		}

		public bool ChangeEnabledStateEventHandler(
			object sender,
			Events.ResourceEventArgs e
		)
		{
			return true;
		}

		#endregion

		#region IToolExt Member

		public bool Visible => true;

		public Image Icon => GetIcon.ContentPreview;

		#endregion

		#region IToolPlugin Member

		public override string ToString()
		{
			return "Content Preview...";
		}

		#endregion
	}
}
