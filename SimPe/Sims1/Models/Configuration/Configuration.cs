// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Common.Extensions;

namespace SimPe.Sims1.Models.Configuration;

public partial class Configuration : ObservableObject
{
	private static Sims1Config? config;

	public static Sims1Config Config => config;


	private static readonly JsonSerializerOptions Options = new()
	{
		UnmappedMemberHandling = System.Text.Json.Serialization.JsonUnmappedMemberHandling.Skip,
		DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
		WriteIndented = true
	};

	public static async Task Load()
	{
		if (!Options.Converters.OfType<DictionaryTKeyEnumTValueConverter>().Any())
		{
			Options.Converters.Add(new DictionaryTKeyEnumTValueConverter());
		}

		string configPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SimPe",
		                                 "config.sims1.json");
		if (File.Exists(configPath))
		{
			try
			{
				string readAllTextAsync = await File.ReadAllTextAsync(configPath, Encoding.UTF8);
				config = JsonSerializer.Deserialize<Sims1Config>(readAllTextAsync,
				                                                 Options) ?? new Sims1Config();
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
		if (!Options.Converters.OfType<DictionaryTKeyEnumTValueConverter>().Any())
		{
			Options.Converters.Add(new DictionaryTKeyEnumTValueConverter());
		}

		string configPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SimPe",
		                                 "config.sims1.json");
		try
		{
			await File.WriteAllTextAsync(configPath, JsonSerializer.Serialize(Config, Options), Encoding.UTF8);
		}
		catch (Exception ex)
		{
		}
	}
}
