// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using SimPe.Forms.MainUI;

using Message = SimPe.Forms.MainUI.Message;

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
				Console.WriteLine("Exiting Application!");

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
				//Packages.StreamFactory.CloseAll(true); // TODO(autinerd): Let's care another time about closing files cleanly on app shutdown
				Packages.StreamFactory.CleanupTeleport();
			}
			catch { }
		}
	}
}
