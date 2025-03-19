// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Avalonia;

using SimPe.Forms.MainUI;
using SimPe.ViewModels;

using Message = SimPe.Forms.MainUI.Message;

//using Ambertation.Windows.Forms;

namespace SimPe
{
	public class Program
	{
		public static MainForm Global;
		public static MainWindow mainWindow;

		/// <summary>
		/// Der Haupteinstiegspunkt für die Anwendung.
		/// </summary>
		[STAThread]
		public static async Task Main(string[] args)
		{
			if (Environment.Version.Major < 4)
			{
				await Message.Show(
						Localization.GetString("NoDotNet")
						.Replace("{VERSION}", Environment.Version.ToString())
				);
				return;
			}

			List<string> argv = new(args);
			if (await Commandline.PreSplash(argv))
			{
				return;
			}

			await Commandline.CheckFiles();

			/* Test for a New or Unknown EP, probably pointless now  */
			if (Helper.WindowsRegistry.FoundUnknownEP())
			{
				if (
					await Message.Show(
							Localization.GetString("Unknown EP found")
							.Replace(
								"{name}",

									PathProvider.Global.GetExpansion(
										PathProvider.Global.LastKnown
									)
									.Name
							),
						Localization.GetString("Warning"),
						MsBox.Avalonia.Enums.ButtonEnum.YesNo
					) == MsBox.Avalonia.Enums.ButtonResult.No
				)
				{
					return;
				}
			}

			// try
			// {
			Helper.WindowsRegistry.UpdateSimPEDirectory();
			if (!await Commandline.FullEnvStart(argv))
			{
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
				BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
			}
			Console.WriteLine("Exiting Application!");

			await (mainWindow.DataContext as MainWindowViewModel).Configuration.Save();
			// }
			// catch (Exception ex)
			// {
			// 	try
			// 	{
			// 		await Message.Show(
			// 			"SimPe will shutdown due to an unhandled Exception.\n\nMessage: "
			// 				+ ex.Message + "\n" + ex.StackTrace
			// 		);
			// 	}
			// 	catch (Exception ex2)
			// 	{
			// 		await Message.Show(
			// 			"SimPe will shutdown due to an unhandled Exception.\n\nMessage: "
			// 				+ ex2.Message + "\n" + ex2.StackTrace
			// 		);
			// 	}
			// }

			try
			{

				Packages.StreamFactory.UnlockAll();
				//Packages.StreamFactory.CloseAll(true); // TODO(autinerd): Let's care another time about closing files cleanly on app shutdown
				Packages.StreamFactory.CleanupTeleport();
			}
			catch { }
		}

		// Avalonia configuration, don't remove; also used by visual designer.
		public static AppBuilder BuildAvaloniaApp()
			=> AppBuilder.Configure<App>()
				.UsePlatformDetect()
				.WithInterFont()
				.LogToTrace();
	}
}
