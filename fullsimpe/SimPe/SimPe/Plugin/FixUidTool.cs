// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Threading.Tasks;

using SimPe.Forms.MainUI;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Idno;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for ImportSemiTool.
	/// </summary>
	public class FixUidTool : Interfaces.ITool
	{
		internal FixUidTool()
		{
		}

		#region ITool Member

		public bool IsEnabled(
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile package
		)
		{
			return true;
		}

		public IToolResult ShowDialog(
			ref Interfaces.Files.IPackedFileDescriptor pfd,
			ref Interfaces.Files.IPackageFile package
		)
		{

			try
			{
				System.Collections.Hashtable ht = Idno.FindUids(
					PathProvider.SimSavegameFolder,
					true
				);
				foreach (string file in ht.Keys)
				{
					Packages.GeneratableFile fl =
						Packages.File.LoadFromFile(file);
					Interfaces.Files.IPackedFileDescriptor[] pfds =
						fl.FindFiles(Data.FileTypes.IDNO);
					foreach (
						Interfaces.Files.IPackedFileDescriptor spfd in pfds
					)
					{
						Idno idno = new Idno().ProcessFile(spfd, fl);
						idno.MakeUnique(ht);

						idno.SynchronizeUserData();
					}

					fl.Save();
				}
			}
			catch (Exception ex)
			{
			}
			return new ToolResult(false, false);
		}

		public override string ToString()
		{
			return "Neighbourhood\\Fix Neighbourhood Uid's";
		}

		#endregion
	}
}
