// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Linq;

namespace SimPe.Plugin.Tool.Action
{
	/// <summary>
	/// The ReloadFileTable Action
	/// </summary>
	public class ActionCheckFiletable : Interfaces.IToolAction
	{
		#region IToolAction Member

		public virtual bool ChangeEnabledStateEventHandler(
			object sender,
			Events.ResourceEventArgs es
		)
		{
			return es.Loaded;
		}

		string GetString(Interfaces.Files.IPackedFileDescriptor pfd)
		{
			return pfd.ExceptionString
				+ " (o="
				+ Helper.HexString(pfd.Offset)
				+ ", s="
				+ Helper.HexStringInt(pfd.Size)
				+ ")";
		}

		public void ExecuteEventHandler(object sender, Events.ResourceEventArgs e)
		{
			if (!ChangeEnabledStateEventHandler(null, e))
			{
				return;
			}

			FileTableBase.FileIndex.Load();

			System.IO.StreamWriter sw = new System.IO.StreamWriter(
				new System.IO.MemoryStream()
			);
			try
			{
				foreach (
					Interfaces.Files.IPackedFileDescriptor pfd in e.LoadedPackage
						.Package
						.Index
				)
				{
					System.Collections.Generic.IEnumerable<Interfaces.Scenegraph.IScenegraphFileIndexItem> fiis =
						FileTableBase.FileIndex.FindFile(pfd, e.LoadedPackage.Package);

					if (fiis.Count() != 1)
					{
						sw.WriteLine(
							GetString(pfd)
								+ " found "
								+ fiis.Count().ToString()
								+ " times."
						);
						foreach (
							Interfaces.Scenegraph.IScenegraphFileIndexItem fii in fiis
						)
						{
							sw.WriteLine(
								"    "
									+ fii.Package.FileName
									+ ": "
									+ GetString(fii.FileDescriptor)
							);
						}
					}
					else if (
						fiis.First().FileDescriptor.Offset != pfd.Offset
						|| fiis.First().FileDescriptor.Size != pfd.Size
					)
					{
						sw.WriteLine(
							GetString(pfd)
								+ " "
								+ " <> "
								+ GetString(fiis.First().FileDescriptor)
						);
					}
				}

				Report f = new Report();
				f.Execute(sw);
			}
			finally
			{
				sw.Close();
			}
		}

		#endregion


		#region IToolPlugin Member
		public override string ToString()
		{
			return "Check FileTable";
		}
		#endregion

		#region IToolExt Member
		public System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.None;

		public System.Drawing.Image Icon => null;

		public virtual bool Visible => true;

		#endregion
	}
}
