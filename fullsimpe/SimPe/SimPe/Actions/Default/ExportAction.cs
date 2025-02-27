/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
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

namespace SimPe.Actions.Default
{
	/// <summary>
	/// Summary description for ExportAction.
	/// </summary>
	public class ExportAction : AbstractActionDefault
	{
		public ExportAction()
		{
		}

		/// <summary>
		/// presents the SaveDialog and returns the selected Filename (or null)
		/// </summary>
		/// <param name="multi"></param>
		/// <returns></returns>
		string SetupSaveDialog(string name, bool multi)
		{
			name = name.Replace(" ", "").Replace(":", "_").Replace(@"\", "_");
			if (!multi)
			{
				System.Windows.Forms.SaveFileDialog sfd =
					new System.Windows.Forms.SaveFileDialog();
				sfd.FileName = name;
				sfd.Filter = ExtensionProvider.BuildFilterString(
					new ExtensionType[]
					{
						ExtensionType.ExtractedFile,
						ExtensionType.AllFiles,
					}
				);
				sfd.Title = Localization.GetString(ToString());
				if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					return sfd.FileName;
				}
			}
			else
			{
				System.Windows.Forms.FolderBrowserDialog fbd =
					new System.Windows.Forms.FolderBrowserDialog();
				if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					return fbd.SelectedPath;
				}
			}

			return null;
		}

		public void ExtractAllFiles(
			string selpath,
			Interfaces.Files.IPackedFileDescriptor[] pfds,
			Packages.ExtractableFile package
		)
		{
			int excount = 0;
			int filecount = 0;
			string xml = "";
			bool run = WaitingScreen.Running;
			if (!run)
			{
				WaitingScreen.Wait();
			}

			try
			{
				if (Helper.Profile == "Short")
				{
					for (int i = 0; i < pfds.Length; i++)
					{
						System.Windows.Forms.Application.DoEvents();
						Packages.PackedFileDescriptor fii =
							(Packages.PackedFileDescriptor)pfds[i];
						fii.Path = null;
						string path = System.IO.Path.Combine(selpath, fii.Path);
						fii.Filename = null;
						string name = System.IO.Path.Combine(path, fii.Filename);
						try
						{
							if (!System.IO.Directory.Exists(path))
							{
								System.IO.Directory.CreateDirectory(path);
							}

							fii.Path = "";
							package.SavePackedFile(name, null, fii, true);
							filecount++;
							fii.Dispose();
						}
						catch (Exception ex)
						{
							Helper.ExceptionMessage(
								Localization.Manager.GetString("errwritingfile")
									+ " "
									+ name,
								ex
							);
						}
					}
				}
				else
				{
					xml += "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>" + Helper.lbr;
					xml +=
						"<package type=\""
						+ ((uint)package.Header.IndexType).ToString()
						+ "\">"
						+ Helper.lbr;
					for (int i = 0; i < pfds.Length; i++)
					{
						System.Windows.Forms.Application.DoEvents();
						Packages.PackedFileDescriptor fii =
							(Packages.PackedFileDescriptor)pfds[i];
						Data.TypeAlias a = fii.TypeName;

						fii.Path = null;
						string path = System.IO.Path.Combine(selpath, fii.Path);

						fii.Filename = null;
						string name = System.IO.Path.Combine(path, fii.Filename);

						try
						{
							if (!System.IO.Directory.Exists(path))
							{
								System.IO.Directory.CreateDirectory(path);
							}

							//make sure the sub xmls don't have a Filename
							fii.Path = "";
							package.SavePackedFile(name, null, fii, true);
							fii.Path = null;

							xml += fii.GenerateXmlMetaInfo();

							filecount++;
						}
						catch (Exception ex)
						{
							excount++;
							Helper.ExceptionMessage(
								Localization.Manager.GetString("errwritingfile")
									+ " "
									+ name,
								ex
							);
							if (excount >= 5)
							{
								if (
									Message.Show(
										Localization.Manager.GetString("ask000"),
										Localization.Manager.GetString("proceed"),
										System.Windows.Forms.MessageBoxButtons.YesNo
									) == System.Windows.Forms.DialogResult.Yes
								)
								{
									i = pfds.Length;
								}
							}
						}
					} //for i
					xml += "</package>" + Helper.lbr;

					System.IO.TextWriter tw = System.IO.File.CreateText(
						System.IO.Path.Combine(selpath, "package.xml")
					);
					try
					{
						tw.Write(xml);
					}
					catch (Exception ex)
					{
						Helper.ExceptionMessage(
							Localization.Manager.GetString("err001"),
							ex
						);
					}
					finally
					{
						tw.Close();
						tw.Dispose();
						tw = null;
					}
				}
			}
			finally
			{
				if (!run)
				{
					WaitingScreen.Stop();
				}
			}

			Message.Show(
				Localization
					.Manager.GetString("nfo000")
					.Replace("{0}", filecount.ToString()),
				"Info",
				System.Windows.Forms.MessageBoxButtons.OK
			);
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

			bool multi = es.Count > 1;
			string flname = SetupSaveDialog(
				es[0].Resource.FileDescriptor.ExportFileName,
				multi
			);

			if (flname == null)
			{
				return;
			}

			try
			{
				if (!multi) //extract one File
				{
					Packages.PackedFileDescriptor pfd =
						(Packages.PackedFileDescriptor)
							es[0].Resource.FileDescriptor;

					ToolLoaderItemExt.SavePackedFile(
						flname,
						true,
						pfd,
						es.LoadedPackage.Package
					);
					pfd.Path = null;
				}
				else //extract multiple Files
				{
					Collections.PackedFileDescriptors pfds =
						new Collections.PackedFileDescriptors();
					foreach (Events.ResourceContainer e in es)
					{
						if (e.HasFileDescriptor)
						{
							pfds.Add(e.Resource.FileDescriptor);
						}
					}

					Interfaces.Files.IPackedFileDescriptor[] ar =
						new Interfaces.Files.IPackedFileDescriptor[pfds.Length];
					pfds.CopyTo(ar);
					ExtractAllFiles(flname, ar, es.LoadedPackage.Package);
				}
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("err002") + flname,
					ex
				);
			}
		}

		#endregion

		#region IToolPlugin Member

		public override string ToString()
		{
			return "Extract...";
		}

		#endregion

		#region IToolExt Member
		public override System.Drawing.Image Icon => GetIcon.actionExport;

		public override System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.ShiftIns;
		#endregion
	}
}
