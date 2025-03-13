// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;

using SimPe.Interfaces.Files;
namespace SimPe.Actions.Default
{
	/// <summary>
	/// Summary description for AddAction.
	/// </summary>
	public class AddAction : ReplaceAction
	{
		public AddAction()
		{
		}

		#region IToolAction Member

		public override bool ChangeEnabledStateEventHandler(
			object sender,
			Events.ResourceEventArgs es
		)
		{
			return es.LoadedPackage != null && es.LoadedPackage.Loaded;
		}

		public override void ExecuteEventHandler(
			object sender,
			Events.ResourceEventArgs es
		)
		{
			if (!ChangeEnabledStateEventHandler(null, es))
			{
				return;
			}

			List<IPackedFileDescriptor> pfds = LoadDescriptors(true);
			es.LoadedPackage.Package.BeginUpdate();
			foreach (IPackedFileDescriptor pfd in pfds)
			{
				es.LoadedPackage.Package.Add(pfd);
			}

			es.LoadedPackage.Package.EndUpdate();
		}

		#endregion

		#region IToolPlugin Member

		public override string ToString()
		{
			return "Add...";
		}

		#endregion

		#region IToolExt Member
		public override System.Drawing.Image Icon => GetIcon.actionImport;
		#endregion
	}
}
