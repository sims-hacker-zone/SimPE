// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

using Ambertation.Threading;

using SimPe.Data;
using SimPe.Interfaces;
using SimPe.Interfaces.Files;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Picture;

namespace SimPe.Providers
{
	/// <summary>
	/// Provides an Alias Matching a SimID with it's Name
	/// </summary>
	/// <remarks>
	/// The Tag of the NameProvider is an Object Array with the following content:
	///  0: The Name of the Character File
	///  1: Image of the Sim (if available)
	///  2: Familyname of the Sim
	/// </remarks>
	public class SimNames : StoppableThread, Interfaces.Providers.ISimNames
	{
		/// <summary>
		/// List of known Aliases (can be null)
		/// </summary>
		private Hashtable names;

		/// <summary>
		/// This is needed for the OBJD to work
		/// </summary>
		Interfaces.Providers.IOpcodeProvider opcodes;

		/// <summary>
		/// The Folder from where the SimInformation was loaded
		/// </summary>
		private string dir;

		/// <summary>
		/// Additional FileIndex fro template SimNames
		/// </summary>
		Interfaces.Scenegraph.IScenegraphFileIndex characterfi;

		/// <summary>
		/// Creates the List for the specific Folder
		/// </summary>
		/// <param name="folder">The Folder with the Character Files</param>
		public SimNames(string folder, Interfaces.Providers.IOpcodeProvider opcodes)
			: base()
		{
			BaseFolder = folder;
			this.opcodes = opcodes;

			List<FileTableItem> folders = new List<FileTableItem>();
			foreach (ExpansionItem ei in PathProvider.Global.Expansions)
			{
				if (!ei.Exists)
				{
					continue;
				}

				foreach (string s in ei.SimNameDeepSearch)
				{
					string path = Path.Combine(
						PathProvider.Global.Latest.InstallFolder,
						s
					);
					if (!Directory.Exists(path))
					{
						path = Path.Combine(ei.InstallFolder, s);
					}

					if (Directory.Exists(path))
					{
						folders.Add(new FileTableItem(path));
					}
				}
			}
			characterfi = new Plugin.FileIndex(folders);
		}

		/// <summary>
		/// Creates the List for the specific Folder
		/// </summary>
		public SimNames(Interfaces.Providers.IOpcodeProvider opcodes)
			: this("", opcodes) { }

		/// <summary>
		/// Returns or sets the Folder where the Character Files are stored
		/// </summary>
		/// <remarks>Sets the names List to null</remarks>
		public string BaseFolder
		{
			get => dir;
			set
			{
				if (dir != value)
				{
					WaitForEnd(); // wait for any other stoppable threads to end
					if (dir != value) // if other thread has set dir then it has also set names so lets not wippe them out
					{
						names = null;
					}
				}
				dir = value;
			}
		}

		protected Alias AddSim(
			IPackageFile fl,
			IPackedFileDescriptor objdpfd,
			ref int ct,
			int step
		)
		{

			return AddSim(new PackedFiles.Wrapper.ExtObjd().ProcessFile(objdpfd, fl), ref ct, step, false);
		}

		/// <summary>
		/// Adds a Sim to the List
		/// </summary>
		/// <param name="objd"></param>
		/// <param name="ct"></param>
		/// <param name="step"></param>
		/// <param name="npc"></param>
		/// <returns>The Alias for that Sim</returns>
		/// <remarks>
		/// Alias.Tag has the following Structure:
		/// [0] : FileName of Character File (if NPC, this will be null)
		/// [1] : Thumbnail
		/// [2] : FamilyName
		/// [3] : Contains Age Data
		/// [4] : When NPC, this will get the Filename
		/// </remarks>
		protected Alias AddSim(
			PackedFiles.Wrapper.ExtObjd objd,
			ref int ct,
			int step,
			bool npc
		)
		{
			IPackageFile fl = objd.Package;
			//BinaryReader br = new BinaryReader(File.OpenRead(file));//new StreamReader(file)
			bool hasagedata = fl.FindFiles(FileTypes.AGED).Length > 0; //has Age Data
			object[] tags = new object[5];
			tags[0] = fl.FileName;
			tags[1] = null;
			tags[2] = Localization.Manager.GetString("Unknown");
			tags[3] = hasagedata;
			tags[4] = null;
			/*if (Helper.WindowsRegistry.Config.HiddenMode)
				tags[5] = (!hasagedata) && (fl.FindFiles(FileTypes.THREE_IDR).Length>0); //if this is true, the Sim has a Problem, and the package was probably split
			else
				tags[5] = false;*/

			//set stuff for NPCs
			if (npc)
			{
				tags[4] = tags[0];
				tags[0] = "";
				tags[2] += "(NPC)";
			}

			Alias a = null;

			IPackedFileDescriptor str_pfd = fl.FindFile(
				FileTypes.CTSS,
				0,
				objd.FileDescriptor.Group,
				objd.CTSSInstance
			);

			if (str_pfd != null)
			{
				PackedFiles.Wrapper.StrItemList its = new PackedFiles.Wrapper.Str().ProcessFile(str_pfd, fl).FallbackedLanguageItems(
					Helper.WindowsRegistry.Config.LanguageCode
				);
				if (its.Length > 0)
				{
					a = new Alias(objd.Guid, its[0].Title, "{name} {2} (0x{id})");
					if (its.Length > 2)
					{
						tags[2] = its[2].Title;
					}
				}
			}

			if (a != null)
			{
				IPackedFileDescriptor[] piclist = fl.FindFiles(
					FileTypes.IMG
				);
				foreach (IPackedFileDescriptor pfd in piclist)
				{
					if (pfd.Group != objd.FileDescriptor.Group)
					{
						continue;
					}

					if (pfd.Instance < 0x200)
					{
						tags[1] = new Picture().ProcessFile(pfd, fl).Image;
						break;
					}
				}

				a.Tag = tags;
				//if (Helper.StartedGui!=Executable.Classic)
				{
					ct++;
					if (ct % step == 1)
					{
						Wait.Message = a.ToString();
						Wait.Progress = ct;
					}
				}

				//set stuff for NPCs
				if (npc && a.Tag[2].ToString() != "(NPC)")
				{
					a.Tag[2] = a.Tag[2].ToString() + " (NPC)";
				}

				if (names == null)
				{
					return null;
				}

				if (!names.Contains(objd.Guid))
				{
					names.Add(objd.Guid, a);
				}
			}
			return a;
		}

		protected void ScanFileTable()
		{
			if (
				Helper.StartedGui == Executable.Classic
				|| !Helper.WindowsRegistry.Config.DeepSimScan
			)
			{
				return;
			}

			if (Helper.WindowsRegistry.Config.DeepSimTemplateScan)
			{
				characterfi.Load();
			}

			FileTableBase.FileIndex.AddChild(characterfi); // why if not DeepSimTemplateScan
			try
			{
				ScanFileTable(0x80);
				if (Helper.WindowsRegistry.Config.DeepSimTemplateScan)
				{
					ScanFileTable(0x81); // some templates are instance 0x81
				}
			}
			finally
			{
				FileTableBase.FileIndex.RemoveChild(characterfi);
			}
		}

		protected void ScanFileTable(uint inst)
		{
			// Mystery Sim - Girl GUID 0x6DD33865 group 0x7FBA59DA, Instance 0x000041A7 / Mystery Sim - Boy GUID 0x006D2D59 group 0x7FCB2EBC img instance 1 - Type normal
			if (
				Helper.StartedGui == Executable.Classic
				|| !Helper.WindowsRegistry.Config.DeepSimScan
			)
			{
				return;
			}

			IEnumerable<Interfaces.Scenegraph.IScenegraphFileIndexItem> items =
				FileTableBase.FileIndex.FindFileDiscardingGroup(
					FileTypes.OBJD,
					inst
				);
			Wait.MaxProgress = items.Count();
			int ct = 0;
			int step = Math.Max(2, Wait.MaxProgress / 100);
			foreach (Interfaces.Scenegraph.IScenegraphFileIndexItem item in items)
			{
				if (HaveToStop)
				{
					break;
				}

				PackedFiles.Wrapper.ExtObjd objd =
					new PackedFiles.Wrapper.ExtObjd().ProcessFile(item);
				if (
					(Helper.WindowsRegistry.Config.DeepSimTemplateScan
					&& objd.Type == ObjectTypes.Template)
					|| objd.Type == ObjectTypes.Person
				)
				{
					AddSim(objd, ref ct, step, true);
				}
			}
		}

		protected override void StartThread()
		{
			if (Directory.Exists(dir))
			{
				string[] files = Directory.GetFiles(dir, "*.package");
				if (Helper.StartedGui == Executable.Classic)
				{
					WaitingScreen.Wait();
				}
				else
				{
					Wait.SubStart(files.Length);
				}

				try
				{
					bool breaked = false;
					PackedFiles.Wrapper.ExtObjd objd =
						new PackedFiles.Wrapper.ExtObjd();
					PackedFiles.Wrapper.Str str =
						new PackedFiles.Wrapper.Str();
					//ArrayList al = new ArrayList();
					int ct = 0;
					int step = Math.Max(2, Wait.MaxProgress / 100);
					foreach (string file in files)
					{
						if (HaveToStop)
						{
							breaked = true;
							break;
						}

						Packages.File fl = null;
						try
						{
							fl = Packages.File.LoadFromFile(file);
						}
						catch
						{
							break;
						}

						IPackedFileDescriptor[] list = fl.FindFiles(
							FileTypes.OBJD
						);
						if (list.Length > 0)
						{
							AddSim(fl, list[0], ref ct, step);
						}
						//fl.Reader.Close();
					} //foreach

					if (!breaked)
					{
						ScanFileTable();
					}
				}
				catch (Exception ex)
				{
					Helper.ExceptionMessage(ex);
				}
				finally
				{
					if (Helper.StartedGui == Executable.Classic)
					{
						WaitingScreen.Stop();
					}
					else
					{
						Wait.Stop(true);
					}
				}
				ended.Set();
			}
			else
			{
				ScanFileTable();
				ended.Set();
			}
		}

		object sync = new object();

		/// <summary>
		/// Loads all package Files in the directory and scans them for Name Informations
		/// </summary>
		public void LoadSimsFromFolder()
		{
			WaitForEnd(); // wait for any other stoppable threads to end
			if (names != null)
			{
				return; // if names were set by other thread then lets not do it again (and again, and again etc.)
			}

			names = new Hashtable();
			if (!Directory.Exists(dir))
			{
				return;
			}

			if (
				Helper.WindowsRegistry.Config.DeepSimScan
				&& Helper.StartedGui != Executable.Classic
			)
			{
				FileTableBase.FileIndex.Load();
			}

			ExecuteThread(
				ThreadPriority.AboveNormal,
				"Sim Name Provider",
				true,
				true
			);
		}

		/// <summary>
		/// Returns the the Alias with the specified Type
		/// </summary>
		/// <param name="id">The id of a Sim</param>
		/// <returns>The Alias of the Sim</returns>
		/// <remarks>
		/// Alias.Tag has the following Structure:
		/// [0] : FileName of Character File (if NPC, this will be null)
		/// [1] : Thumbnail
		/// [2] : FamilyName
		/// [3] : Contains Age Data
		/// [4] : When NPC, this will get the Flename
		/// </remarks>
		public IAlias FindName(uint id)
		{
			if (names == null)
			{
				LoadSimsFromFolder();
			}

			object o = names[id];
			if (o != null)
			{
				return (IAlias)o;
			}

			string es = MetaData.GetKnownNPC(id);
			return es != "not found" ? new Alias(id, es) : (IAlias)new Alias(id, Localization.Manager.GetString("unknown"));
		}

		/// <summary>
		/// Returrns the stored Alias Data
		/// </summary>
		public Hashtable StoredData
		{
			get
			{
				if (names == null)
				{
					LoadSimsFromFolder();
				}

				return names;
			}
			set => names = value;
		}
	}
}
