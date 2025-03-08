// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Swaf
{
	/// <summary>
	/// This class is able to load the Names for some special Want Items
	/// </summary>
	public class WantNameLoader
	{
		/// <summary>
		/// Returns a List with all known Names
		/// </summary>
		public Dictionary<WantType, Dictionary<uint, string>> Map
		{
			get; private set;
		} = new Dictionary<WantType, Dictionary<uint, string>>();

		/// <summary>
		/// Create a New Instance
		/// </summary>
		public WantNameLoader()
			: this(Wrapper.SDescVersions.Nightlife) { }

		/// <summary>
		/// Create a New Instance
		/// </summary>
		public WantNameLoader(Wrapper.SDescVersions version)
		{
			ParseXml(version);
		}

		/// <summary>
		/// Create a New Instance
		/// </summary>
		/// <param name="xml">The Xml File you want to parse</param>
		public WantNameLoader(string xml)
		{
			ParseXml(xml);
		}

		/// <summary>
		/// Create a HashTable with the needed Names from the UI xml File
		/// </summary>
		/// <param name="version">Version where you want to load the Description from</param>
		private void ParseXml(Wrapper.SDescVersions version)
		{
			// version is Sdsc version - must be converted to EP version
			ExpansionItem ei = Wrapper.SDesc.GetIEVersion(version);
			if (ei != null)
			{
				Packages.File pkg = Packages.File.LoadFromFile(
					System.IO.Path.Combine(
						ei.InstallFolder,
						"TSData\\Res\\Wants\\WantTuning.package"
					)
				);
				if (pkg != null) // if it is null then what?
				{
					Interfaces.Files.IPackedFileDescriptor pfd = pkg.FindFile(
						0x00000000,
						0,
						0xCDA53B6F,
						0x2D7EE26B
					);
					if (pfd != null)
					{
						ParseXml(new Xml.Xml().ProcessFile(pfd, pkg).Text);
					}
				}
			}
		}

		/// <summary>
		/// Create a HashTable with the needed Names from the UI xml File
		/// </summary>
		/// <param name="xml">The Xml File </param>
		private void ParseXml(string xml)
		{
			XElement doc = XElement.Parse(xml);
			System.ComponentModel.UInt32Converter converter = new System.ComponentModel.UInt32Converter();

			Map = new Dictionary<WantType, Dictionary<uint, string>>
			{
				[WantType.Category] = (from el in doc.Element("categories").Elements("category")
									   select new
									   {
										   Id = (uint)converter.ConvertFrom((string)el.Attribute("id")),
										   Name = (string)el.Attribute("name")
									   }).ToDictionary(item => item.Id, item => item.Name),
				[WantType.Skill] = (from el in doc.Element("skills").Elements("skill")
									select new
									{
										Id = (uint)converter.ConvertFrom((string)el.Attribute("id")),
										Name = (string)el.Attribute("name")
									}).ToDictionary(item => item.Id, item => item.Name),
				[WantType.Career] = (from el in doc.Element("careers").Elements("career")
									 select new
									 {
										 Id = (uint)converter.ConvertFrom((string)el.Attribute("id")),
										 Name = (string)el.Attribute("name")
									 }).ToDictionary(item => item.Id, item => item.Name),
				[WantType.Undefined] = (from el in doc.Element("persondata").Elements("persondata")
										select new
										{
											Id = (uint)converter.ConvertFrom((string)el.Attribute("id")),
											Name = (string)el.Attribute("name")
										}).ToDictionary(item => item.Id, item => item.Name),
			};
		}

		/// <summary>
		/// Adds the currently Available SimNames to the Map
		/// </summary>
		/// <remarks>Feeds the IProviderRegistry set in the FileTable!</remarks>
		public void AddSimNames()
		{
			if (FileTableBase.ProviderRegistry == null)
			{
				return;
			}

			Dictionary<uint, string> sims = new Dictionary<uint, string>();

			foreach (
				IGrouping<ushort, Interfaces.Wrapper.ISDesc> inst in FileTableBase
					.ProviderRegistry
					.SimDescriptionProvider
					.SimInstance
			)
			{
				Wrapper.SDesc sdsc =
					(Wrapper.SDesc)FileTableBase.ProviderRegistry.SimDescriptionProvider.FindSim(inst.Key);
				sdsc.SetProviders(FileTableBase.ProviderRegistry);
				sims[inst.Key] = $"{sdsc.SimName} {sdsc.SimFamilyName} ({sdsc.HouseholdName})";
			}
			Map[WantType.Sim] = sims;
		}

		/// <summary>
		/// Adds all available Object Names
		/// </summary>
		/// <param name="list">A List of MemoryCacheItems</param>
		public void AddObjects(IEnumerable<Cache.MemoryCacheItem> list)
		{
			Map[WantType.Object] = (from Cache.MemoryCacheItem mci in list
									where mci.ObjectType == Data.ObjectTypes.Normal
									group mci by mci.Guid into mcigroup
									select new
									{
										Id = mcigroup.First().Guid,
										mcigroup.First().Name
									}).ToDictionary(item => item.Id, item => item.Name);
		}

		/// <summary>
		/// Returns the Name of a Want (or null if none was found)
		/// </summary>
		/// <param name="wt">The Type of the Want</param>
		/// <param name="id">The id of the String</param>
		/// <returns>The Name or null</returns>
		public string FindName(WantType wt, uint id)
		{
			return Map.ContainsKey(wt) && Map[wt].ContainsKey(id) ? Map[wt][id] : null;
		}

		/// <summary>
		/// Returns an ArrayLIst of Alias Object with all available Names for this Type
		/// </summary>
		/// <param name="wt">The Type of the Want</param>
		/// <returns>List of Alias Items</returns>
		public IEnumerable<Data.Alias> GetNames(WantType wt)
		{
			return Map.ContainsKey(wt) ? Map[wt].Select(kv => new Data.Alias(kv.Key, kv.Value, "{name}")) : null;
		}
	}
}
