// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Windows.Forms;

using SimPe.Packages;

namespace pjse
{
	class ExtractCurrent
	{
		public static DialogResult Execute(
			SimPe.Interfaces.Plugin.AbstractWrapper wrapper,
			string title
		)
		{
			SaveFileDialog sfd = new SaveFileDialog
			{
				FileName = wrapper
				.FileDescriptor.ExportFileName.Replace(" ", "")
				.Replace(":", "_")
				.Replace(@"\", "_"),
				Filter = SimPe.ExtensionProvider.BuildFilterString(
				new SimPe.ExtensionType[]
				{
					SimPe.ExtensionType.ExtractedFile,
					SimPe.ExtensionType.AllFiles,
				}
			),
				Title = title
			};

			DialogResult dr = sfd.ShowDialog();
			if (dr != DialogResult.OK)
			{
				return dr;
			}

			string path = wrapper.FileDescriptor.Path;
			string filename = wrapper.FileDescriptor.Filename;
			try
			{
				SimPe.ToolLoaderItemExt.SavePackedFile(
					sfd.FileName,
					true,
					(PackedFileDescriptor)wrapper.FileDescriptor,
					(GeneratableFile)wrapper.Package
				);
			}
			finally
			{
				wrapper.FileDescriptor.Path = path;
				wrapper.FileDescriptor.Filename = filename;
			}

			return dr;
		}
	}
}
