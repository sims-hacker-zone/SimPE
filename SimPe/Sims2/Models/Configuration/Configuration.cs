// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Avalonia.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Common.Extensions;
using SimPe.Sims2.Data;
using SimPe.Sims2.Extensions;
using SimPe.Sims2.Views;

namespace SimPe.Sims2.Models.Configuration;

public partial class Configuration : ObservableObject
{
	private static Sims2Config? config;

	public static Sims2Config Config => config;


	private static readonly JsonSerializerOptions options = new()
	{
		UnmappedMemberHandling = System.Text.Json.Serialization.JsonUnmappedMemberHandling.Skip,
		DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
		WriteIndented = true
	};

	public static async Task Load()
	{
		if (!options.Converters.OfType<DictionaryTKeyEnumTValueConverter>().Any())
		{
			options.Converters.Add(new DictionaryTKeyEnumTValueConverter());
		}

		string configPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SimPe",
			"config.sims2.json");
		if (File.Exists(configPath))
		{
			try
			{
				string readAllTextAsync = await File.ReadAllTextAsync(configPath, Encoding.UTF8);
				config = JsonSerializer.Deserialize<Sims2Config>(readAllTextAsync,
					options) ?? new Sims2Config();
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
		if (!options.Converters.OfType<DictionaryTKeyEnumTValueConverter>().Any())
		{
			options.Converters.Add(new DictionaryTKeyEnumTValueConverter());
		}

		string configPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SimPe",
			"config.sims2.json");
		try
		{
			await File.WriteAllTextAsync(configPath, JsonSerializer.Serialize(Config, options), Encoding.UTF8);
		}
		catch (Exception ex)
		{
		}
	}
}
