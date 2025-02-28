// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Plugin.Tool.Action
{
	/// <summary>
	/// The Intrigued Neighborhood Action
	/// </summary>
	public class ActionGlobalFixTGI : Interfaces.IToolAction
	{
		#region IToolAction Member

		public virtual bool ChangeEnabledStateEventHandler(
			object sender,
			Events.ResourceEventArgs es
		)
		{
			return es.Loaded;
		}

		public void ExecuteEventHandler(object sender, Events.ResourceEventArgs e)
		{
			if (!ChangeEnabledStateEventHandler(null, e))
			{
				return;
			}

			foreach (
				Interfaces.Files.IPackedFileDescriptor pfd in e.LoadedPackage
					.Package
					.Index
			)
			{
				//Do we have a registred handler?
				Interfaces.Plugin.IFileWrapper wrapper =
					(Interfaces.Plugin.IFileWrapper)
						FileTableBase.WrapperRegistry.FindHandler(pfd.Type);
				Interfaces.Files.IPackedFile file = e.LoadedPackage.Package.Read(
					pfd
				);
				if (wrapper == null)
				{
					wrapper = FileTableBase.WrapperRegistry.FindHandler(
						file.UncompressedData
					);
				}

				if (wrapper != null)
				{
					wrapper.ProcessData(pfd, e.LoadedPackage.Package);
					wrapper.Fix(FileTableBase.WrapperRegistry);
				}
			}
		}

		#endregion


		#region IToolPlugin Member
		public override string ToString()
		{
			return "Set TGI Values";
		}
		#endregion

		#region IToolExt Member
		public System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.None;

		public System.Drawing.Image Icon => GetIcon.actionFixTGI;

		public virtual bool Visible => true;

		#endregion
	}
}
