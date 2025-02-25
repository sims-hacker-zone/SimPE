/***************************************************************************
 *   Copyright (C) 2008 by Peter L Jones                                   *
 *   pljones@users.sf.net                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SimPe.Interfaces.Files;
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
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.FileName = wrapper
				.FileDescriptor.ExportFileName.Replace(" ", "")
				.Replace(":", "_")
				.Replace(@"\", "_");
			sfd.Filter = SimPe.ExtensionProvider.BuildFilterString(
				new SimPe.ExtensionType[]
				{
					SimPe.ExtensionType.ExtractedFile,
					SimPe.ExtensionType.AllFiles,
				}
			);
			sfd.Title = title;

			DialogResult dr = sfd.ShowDialog();
			if (dr != DialogResult.OK)
				return dr;

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
