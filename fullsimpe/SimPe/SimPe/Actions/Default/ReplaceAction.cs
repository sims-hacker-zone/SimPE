// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;

using SimPe.Interfaces.Files;
namespace SimPe.Actions.Default
{
	/// <summary>
	/// Summary description for ReplaceAction.
	/// </summary>
	public class ReplaceAction : AbstractActionDefault
	{
		public ReplaceAction()
		{
		}

		/// <summary>
		/// Load a list of FIleDescriptors from the disc
		/// </summary>
		/// <param name="add">true if you want to add them lateron</param>
		/// <returns></returns>
		protected List<IPackedFileDescriptor> LoadDescriptors(bool add)
		{
			System.Windows.Forms.OpenFileDialog ofd =
				new System.Windows.Forms.OpenFileDialog();
			ofd.Filter = !add
				? ExtensionProvider.BuildFilterString(
					new ExtensionType[]
					{
						ExtensionType.ExtractedFile,
						ExtensionType.ExtractedFileDescriptor,
						ExtensionType.AllFiles,
					}
				)
				: ExtensionProvider.BuildFilterString(
					new ExtensionType[]
					{
						ExtensionType.ExtractedFileDescriptor,
						ExtensionType.ExtrackedPackageDescriptor,
						ExtensionType.ExtractedFile,
						ExtensionType.Package,
						ExtensionType.DisabledPackage,
						ExtensionType.AllFiles,
					}
				);

			ofd.Title = Localization.GetString(ToString());
			ofd.Multiselect = add;
			if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				List<IPackedFileDescriptor> pfds =
					LoadedPackage.LoadDescriptorsFromDisk(ofd.FileNames);
				return pfds;
			}

			return new List<IPackedFileDescriptor>();
		}

		#region IToolAction Member

		public override bool ChangeEnabledStateEventHandler(
			object sender,
			Events.ResourceEventArgs es
		)
		{
			bool res = base.ChangeEnabledStateEventHandler(sender, es);
			return res && es.Count == 1;
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

			List<IPackedFileDescriptor> pfds = LoadDescriptors(false);
			if (es.Count > 0)
			{
				foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
				{
					if (pfd != null)
					{
						if (es[0].Resource != null)
						{
							if (es[0].Resource.FileDescriptor != null)
							{
								es[0].Resource.FileDescriptor.UserData = pfd.UserData;
							}
						}
					}
				}
			}
		}

		#endregion

		#region IToolPlugin Member

		public override string ToString()
		{
			return "Replace...";
		}

		#endregion

		#region IToolExt Member
		public override System.Drawing.Image Icon => GetIcon.actionReplace;

		public override System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.ShiftIns;
		#endregion
	}
}
