// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

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

		public Interfaces.Plugin.IToolResult ShowDialog(
			ref Interfaces.Files.IPackedFileDescriptor pfd,
			ref Interfaces.Files.IPackageFile package
		)
		{
			System.Windows.Forms.DialogResult dr = System.Windows.Forms.MessageBox.Show(
				"Using this Tool can serioulsy mess up all of your Neighbourhoods and Neighbourhood Stories, it can acheive nothing usefull.\n\nMake sure you have a Backup of ALL your Neighbourhoods before starting this Tool!\n\nDo you want to start this Tool?",
				"Confirmation",
				System.Windows.Forms.MessageBoxButtons.YesNo
			);

			if (dr == System.Windows.Forms.DialogResult.Yes)
			{
				Wait.SubStop();
				try
				{
					System.Collections.Hashtable ht = Idno.FindUids(
						PathProvider.SimSavegameFolder,
						true
					);
					foreach (string file in ht.Keys)
					{
						Wait.Message = file;

						Packages.GeneratableFile fl =
							Packages.File.LoadFromFile(file);
						Interfaces.Files.IPackedFileDescriptor[] pfds =
							fl.FindFiles(Data.MetaData.IDNO);
						foreach (
							Interfaces.Files.IPackedFileDescriptor spfd in pfds
						)
						{
							Idno idno = new Idno();
							idno.ProcessData(spfd, fl);
							idno.MakeUnique(ht);

							idno.SynchronizeUserData();
						}

						fl.Save();
					}
				}
				catch (Exception ex)
				{
					Helper.ExceptionMessage("", ex);
				}
				finally
				{
					Wait.SubStop();
				}
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
