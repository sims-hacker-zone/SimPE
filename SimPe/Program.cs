// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Threading.Tasks;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.ViewModels;

namespace SimPe;

public partial class Program : ObservableObject
{
	public static MainWindow MainWindow { get; set; }

	/// <summary>
	/// Der Haupteinstiegspunkt für die Anwendung.
	/// </summary>
	[STAThread]
	public static void Main(string[] args)
	{
		Sims1.Init.Initialize();
		Sims2.Init.Initialize();
		BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
		Console.WriteLine("Exiting Application!");
	}

	// Avalonia configuration, don't remove; also used by visual designer.
	public static AppBuilder BuildAvaloniaApp()
		=> AppBuilder.Configure<App>()
			.UsePlatformDetect()
			.WithInterFont()
			.LogToTrace();
}
