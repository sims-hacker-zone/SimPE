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

public static class Configuration
{
	private static CommonConfig? config;

	public static CommonConfig Config => config;

	public partial class CommonConfig : ObservableObject
	{
		public ObservableCollection<string> RecentFiles { get; set; } = [];
	}


	private static readonly JsonSerializerOptions options = new()
	{
		UnmappedMemberHandling = System.Text.Json.Serialization.JsonUnmappedMemberHandling.Skip,
		DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
		WriteIndented = true
	};

	public static async Task Load()
	{
		string configpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SimPe",
			"config.common.json");
		if (File.Exists(configpath))
		{
			try
			{
				IStorageFile? file = await TopLevel.GetTopLevel(Program.MainWindow)?.StorageProvider
					.TryGetFileFromPathAsync(new(new("file://"), configpath));
				await using Stream stream = await file?.OpenReadAsync();
				using StreamReader reader = new(stream);
				config = JsonSerializer.Deserialize<CommonConfig>(await reader.ReadToEndAsync(),
					options) ?? new CommonConfig();
			}
			catch (JsonException)
			{
				// If deserialization fails, return a new config
				config = new();
			}
		}
		else
		{
			config = new();
		}
	}

	public static async Task Save()
	{
		string configpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SimPe",
			"config.common.json");
		try
		{
			await File.WriteAllTextAsync(configpath, JsonSerializer.Serialize(Config, options), Encoding.UTF8);
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error saving configuration: {ex.Message}");
			throw;
		}
	}
}
