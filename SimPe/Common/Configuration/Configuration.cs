// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SimPe.Common.Configuration;

public static partial class Configuration
{
	public static CommonConfig? Config { get; private set; }

	public partial class CommonConfig : ObservableObject
	{
		[ObservableProperty] private ObservableCollection<string> recentFiles = [];
	}


	private static readonly JsonSerializerOptions Options = new()
	{
		UnmappedMemberHandling = System.Text.Json.Serialization.JsonUnmappedMemberHandling.Skip,
		DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
		WriteIndented = true
	};

	public static async Task Load()
	{
		string configPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SimPe",
		                                 "config.common.json");
		if (File.Exists(configPath))
		{
			try
			{
				IStorageFile? file = await TopLevel.GetTopLevel(Program.MainWindow)?.StorageProvider
				                                   .TryGetFileFromPathAsync(new(new("file://"), configPath))!;
				await using Stream stream = await file?.OpenReadAsync()!;
				using StreamReader reader = new(stream);
				Config = JsonSerializer.Deserialize<CommonConfig>(await reader.ReadToEndAsync(),
				                                                  Options) ?? new CommonConfig();
			}
			catch (JsonException)
			{
				// If deserialization fails, return a new config
				Config = new();
			}
		}
		else
		{
			Config = new();
		}
	}

	public static async Task Save()
	{
		string configpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SimPe",
		                                 "config.common.json");
		try
		{
			await File.WriteAllTextAsync(configpath, JsonSerializer.Serialize(Config, Options), Encoding.UTF8);
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error saving configuration: {ex.Message}");
			throw;
		}
	}
}
