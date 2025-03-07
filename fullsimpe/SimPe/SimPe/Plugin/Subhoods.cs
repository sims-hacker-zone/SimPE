// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using SimPe.PackedFiles.Idno;

namespace SimPe.Plugin
{
	public class Subhoods
	{
		public Dictionary<uint, string> SuburbNameFromID =
			new Dictionary<uint, string>();
		public Dictionary<uint, string> SimNamesNids = new Dictionary<uint, string>();

		string fnme = "";

		/// <summary>
		/// Convert the Subhood Id to a name
		/// </summary>
		public string SuburbName(uint id)
		{
			return SuburbNameFromID.ContainsKey(id) ? SuburbNameFromID[id] : "not found";
		}

		/// <summary>
		/// Convert the name to an id for Subhoods, for easy combobox use the string is object
		/// </summary>
		public uint GetSuburbId(object ob)
		{
			string val = Convert.ToString(ob);
			if (SuburbNameFromID.ContainsValue(val))
			{
				foreach (KeyValuePair<uint, string> kvp in SuburbNameFromID)
				{
					if (kvp.Value == val)
					{
						return kvp.Key;
					}
				}
			}

			return 0;
		}

		public void InitializeSuburbNameFromID(string filename)
		{
			if (fnme == filename)
			{
				return;
			}

			fnme = filename;
			SuburbNameFromID.Clear();
			SuburbNameFromID.Add(0, "-none-");
			if (!File.Exists(filename))
			{
				return;
			}

			if (!Helper.IsNeighborhoodFile(filename))
			{
				return;
			}

			string subh;
			string[] overs = Directory.GetFiles(
				Path.GetDirectoryName(filename),
				"*.package",
				SearchOption.TopDirectoryOnly
			);
			if (overs.Length > 0)
			{
				uint uid;
				Packages.GeneratableFile pkg;
				foreach (string file in overs)
				{
					subh = Localization.Manager.GetString("unknown");
					pkg = Packages.File.LoadFromFile(file);
					Interfaces.Files.IPackedFileDescriptor pfd =
						pkg.FindFileAnyGroup(Data.FileTypes.IDNO, 0, 1);
					if (pfd != null)
					{
						Idno idno = new Idno();
						idno.ProcessData(pfd, pkg);
						uid = idno.Uid;

						pfd = pkg.FindFileAnyGroup(Data.FileTypes.CTSS, 0, 1);
						if (pfd != null)
						{
							PackedFiles.Wrapper.Str str =
								new PackedFiles.Wrapper.Str();
							str.ProcessData(pfd, pkg);
							PackedFiles.Wrapper.StrItemList items =
								str.FallbackedLanguageItems(
									Helper.WindowsRegistry.LanguageCode
								);
							if (items.Length > 0)
							{
								subh = items[0].Title;
							}
						}
						if (!SuburbNameFromID.ContainsKey(uid))
						{
							SuburbNameFromID.Add(uid, subh);
						}
					}
				}
			}
		}

		/// <summary>
		/// Convert the Sim Nid to a name
		/// </summary>
		public string SimmyName(uint id)
		{
			return SimNamesNids.ContainsKey(id) ? SimNamesNids[id] : "not found";
		}

		/// <summary>
		/// Convert the sim name to an Nid, for easy combobox use the string is object
		/// </summary>
		public uint GetSimmyId(object ob)
		{
			string val = Convert.ToString(ob);
			if (SimNamesNids.ContainsValue(val))
			{
				foreach (KeyValuePair<uint, string> kvp in SimNamesNids)
				{
					if (kvp.Value == val)
					{
						return kvp.Key;
					}
				}
			}

			return 0;
		}

		public void InitializeSimNamesNids()
		{
			SimNamesNids.Clear();
			SimNamesNids.Add(0, "-none-");
			try
			{
				foreach (
					PackedFiles.Wrapper.SDesc simdesc in FileTableBase
						.ProviderRegistry
						.SimDescriptionProvider
						.SimInstance
						.SelectMany(item => item)
				)
				{
					if (
						!simdesc.SimFamilyName.Contains("(NPC)")
						&& simdesc.Nightlife.IsHuman
						&& !simdesc.CharacterDescription.GhostFlag.IsGhost
					)
					{
						SimNamesNids.Add(
							simdesc.Instance,
							simdesc.SimName + " " + simdesc.SimFamilyName
						);
					}
				}
			}
			catch { }
		}

		public static bool GuidExists(uint gooee)
		{
			if (!pjse.GUIDIndex.TheGUIDIndex.IsLoaded)
			{
				pjse.GUIDIndex.TheGUIDIndex.Load();
			}

			return pjse.GUIDIndex.TheGUIDIndex.ContainsKey(gooee);
		}

		public static bool GuidAdd(uint gooee, uint group, ushort type, string name)
		{
			if (!pjse.GUIDIndex.TheGUIDIndex.IsLoaded)
			{
				pjse.GUIDIndex.TheGUIDIndex.Load();
			}

			if (pjse.GUIDIndex.TheGUIDIndex.ContainsKey(gooee))
			{
				return false;
			}

			try
			{
				pjse.GUIDIndex.TheGUIDIndex.Add(gooee, group, type, name);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static string getgooee(uint gooee)
		{
			if (!pjse.GUIDIndex.TheGUIDIndex.IsLoaded)
			{
				pjse.GUIDIndex.TheGUIDIndex.Load();
			}

			return pjse.GUIDIndex.TheGUIDIndex[gooee] ?? "";
		}
	}
}
