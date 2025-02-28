// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Actions.Default
{
	/// <summary>
	/// Summary description for CloneAction.
	/// </summary>
	public class CloneAction : AbstractActionDefault
	{
		public CloneAction()
		{
		}

		#region IToolAction Member

		public override void ExecuteEventHandler(
			object sender,
			Events.ResourceEventArgs es
		)
		{
			if (!ChangeEnabledStateEventHandler(null, es))
			{
				return;
			}

			foreach (Events.ResourceContainer e in es)
			{
				if (e.HasFileDescriptor)
				{
					Interfaces.Files.IPackedFileDescriptor pfd =

							e.Resource.FileDescriptor.Clone();

					pfd.UserData = es
						.LoadedPackage.Package.Read(e.Resource.FileDescriptor)
						.UncompressedData;
					es.LoadedPackage.Package.Add(pfd, true);
				}
			}
		}

		#endregion

		#region IToolPlugin Member

		public override string ToString()
		{
			return "Clone";
		}

		#endregion

		#region IToolExt Member
		public override System.Drawing.Image Icon => GetIcon.actionClone;

		public override System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.ShiftIns;
		#endregion
	}
}
