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
using System.Collections.Generic;
using System.Windows.Forms;

//using Ambertation.Windows.Forms;

namespace SimPe
{
	partial class MainForm
	{
		public static MainForm Global;

		/// <summary>
		/// Der Haupteinstiegspunkt für die Anwendung.
		/// </summary>
		[STAThread]
		public static void Main(string[] args)
		{
			if (Environment.Version.Major < 4)
			{
				Message.Show(
						Localization.GetString("NoDotNet")
						.Replace("{VERSION}", Environment.Version.ToString())
				);
				return;
			}

			List<string> argv = new List<string>(args);
			if (Commandline.PreSplash(argv))
			{
				return;
			}

			Commandline.CheckFiles();

			/* Test for a New or Unknown EP, probably pointless now  */
			if (Helper.WindowsRegistry.FoundUnknownEP())
			{
				if (
					Message.Show(
							Localization.GetString("Unknown EP found")
							.Replace(
								"{name}",

									PathProvider.Global.GetExpansion(
										PathProvider.Global.LastKnown
									)
									.Name
							),
						Localization.GetString("Warning"),
						MessageBoxButtons.YesNo
					) == DialogResult.No
				)
				{
					return;
				}
			}

			try
			{
				Splash.Screen.SetMessage(
					Localization.GetString("Starting SimPe...")
				);

				Application.DoEvents();

				Helper.WindowsRegistry.UpdateSimPEDirectory();
				Global = new MainForm();
				if (!Commandline.FullEnvStart(argv))
				{
					//load Files passed on the commandline
					Splash.Screen.SetMessage(
						Localization.GetString("Load or Import Files")
					);
					// Tashiketh
					if (argv.Count > 0)
					{
						if (argv[0] != "-load")
						{
							Global.package.LoadOrImportFiles(argv.ToArray(), true);
						}
						else
						{
							Global.package.LoadOrImportFiles(argv.ToArray(), false);
						}
					}
					// Global.package.LoadOrImportFiles(argv.ToArray(), true);
					Application.Run(Global);
				}

				Helper.WindowsRegistry.Flush();
				Helper.WindowsRegistry.Layout.Flush();
				// ExpansionLoader.Global.Flush(); SimPe should not edit this File!
			}
			catch (Exception ex)
			{
				try
				{
					MessageBox.Show(
						"SimPe will shutdown due to an unhandled Exception.\n\nMessage: "
							+ ex.Message + "\n" + ex.StackTrace
					);
					Splash.Screen.Stop();
					Helper.ExceptionMessage(
						"SimPe will shutdown due to an unhandled Exception.",
						ex
					);
				}
				catch (Exception ex2)
				{
					MessageBox.Show(
						"SimPe will shutdown due to an unhandled Exception.\n\nMessage: "
							+ ex2.Message + "\n" + ex2.StackTrace
					);
				}
			}
			finally
			{
				if (Splash.Running)
				{
					Splash.Screen.ShutDown();
				}
			}

			try
			{
				Packages.StreamFactory.UnlockAll();
				Packages.StreamFactory.CloseAll(true);
				Packages.StreamFactory.CleanupTeleport();
			}
			catch { }
		}
	}
}
