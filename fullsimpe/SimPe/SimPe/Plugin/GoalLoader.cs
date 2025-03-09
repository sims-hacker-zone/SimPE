// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using SimPe.Cache;
using SimPe.Data;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Cpf;
using SimPe.PackedFiles.Picture;

namespace SimPe.Plugin
{
	/// <summary>
	/// This basically is a Class describing the Goals (loaded from the Cache)
	/// </summary>
	public class GoalCacheInformation : GoalInformation
	{
		/// <summary>
		/// Use GoalInformation::LoadGoal() to create a new Instance
		/// </summary>
		/// <param name="guid">The guid of the Goal</param>
		GoalCacheInformation(uint guid)
			: base(guid)
		{
			name = "";
		}

		/// <summary>
		/// Use GoalInformation::LoadGoal() to create a new Instance
		/// </summary>
		GoalCacheInformation()
			: base()
		{
			name = "";
		}

		/// <summary>
		/// Load Informations about a specific Goal
		/// </summary>
		/// <param name="guid">The GUID of the goal</param>
		/// <returns>A Goal Information Structure</returns>
		public static GoalCacheInformation LoadGoal(GoalCacheItem wci)
		{
			GoalCacheInformation ret = new GoalCacheInformation
			{
				icon = wci.Icon,
				name = wci.Name,
				guid = wci.Guid
			};

			XGoal w = new XGoal();
			CpfItem i =
				new CpfItem
				{
					Name = "id",
					UIntegerValue = wci.Guid
				};
			w.AddItem(i, true);
			i = new CpfItem
			{
				Name = "score",
				IntegerValue = wci.Score
			};
			w.AddItem(i, true);
			i = new CpfItem
			{
				Name = "influence",
				IntegerValue = wci.Influence
			};
			w.AddItem(i, true);

			ret.wnt = w;

			return ret;
		}

		System.Drawing.Image icon;
		public override System.Drawing.Image Icon => icon;

		string name;
		public override string Name => name;
	}

	/// <summary>
	/// This basically is a Class describing the Goals
	/// </summary>
	public class GoalInformation
	{
		protected XGoal wnt; // Fuick
		PackedFiles.Wrapper.Str str;
		Picture primicon;
		protected uint guid;
		internal string prefix = "";

		private static ILookup<uint, GoalCacheItem> GoalCache => (from container in Cache.Cache.GlobalCache.Items[ContainerType.Goal].Values
																  from GoalCacheItem gci in container
																  select gci).ToLookup(gci => gci.Guid);

		/// <summary>
		/// Use GoalInformation::LoadGoal() to create a new Instance
		/// </summary>
		protected GoalInformation()
		{
		}

		/// <summary>
		/// Use WGoalInformation::LoadGoal() to create a new Instance
		/// </summary>
		/// <param name="guid">The guid of the Goal</param>
		protected GoalInformation(uint guid)
		{
			this.guid = guid;

			wnt = GoalLoader.GetGoal(guid);
			str = GoalLoader.LoadText(wnt);
			primicon = GoalLoader.LoadIcon(wnt);
		}

		#region Cache
		static bool hasnew = false;

		/// <summary>
		/// Save the Cache to the FileSystem
		/// </summary>
		public static void SaveCache()
		{
			if (!Helper.WindowsRegistry.Config.UseCache && hasnew)
			{
				Cache.Cache.GlobalCache.Save();
			}
		}
		#endregion

		/// <summary>
		/// Load Informations about a specific Goal
		/// </summary>
		/// <param name="guid">The GUID of the goal</param>
		/// <returns>A Goal Information Structure</returns>
		public static GoalInformation LoadGoal(uint guid)
		{
			if (GoalCache.Contains(guid))
			{
				return GoalCacheInformation.LoadGoal(GoalCache[guid].First());
			}
			else
			{
				GoalInformation wf = new GoalInformation(guid);
				Cache.Cache.GlobalCache.AddGoalItem(wf);
				hasnew = true;
				return wf;
			}
		}

		/// <summary>
		/// Returns the XGoal File
		/// </summary>
		public XGoal XGoal => wnt;

		/// <summary>
		/// Returns the Name of this Goal
		/// </summary>
		public virtual string Name
		{
			get
			{
				string stg;
				if (str == null)
				{
					return "0x" + Helper.HexString(guid);
				}

				stg = str.FallbackedLanguageItem(Helper.WindowsRegistry.Config.LanguageCode, 0)
					.Title.Replace("$NeighborLocal:2", "True Love");
				return stg.Replace("$NeighborLocal:3", "Orangutan");
			}
		}

		/// <summary>
		/// Returns Icon for this Goal or null
		/// </summary>
		public virtual System.Drawing.Image Icon => primicon?.Image;

		/// <summary>
		/// The guid of the current Goal
		/// </summary>
		public uint Guid => guid;

		public override string ToString()
		{
			return prefix + Name;
		}
	}

	/// <summary>
	/// This class is used to fill the UI for this FileType with Data
	/// </summary>
	public class GoalLoader
	{
		static Hashtable goals = null;
		static Packages.File txtpkg = null;

		/// <summary>
		/// Returns a Hashtable of all available Goals
		/// </summary>
		/// <remarks>key is the Goal GUID, value is a XGoal object</remarks>
		public static Hashtable Goals
		{
			get
			{
				if (goals == null)
				{
					LoadGoals();
				}

				return goals;
			}
		}

		/// <summary>
		/// Loads the Text Package File
		/// </summary>
		static void LoadTextPackage() // fuck
		{
			txtpkg = Packages.File.LoadFromFile(
				System.IO.Path.Combine(
					PathProvider
						.Global.GetExpansion(Expansions.IslandStories)
						.InstallFolder,
					"TSData\\Res\\Text\\Wants.package"
				)
			);
			if (txtpkg == null)
			{
				txtpkg = Packages.File.LoadFromFile(
					System.IO.Path.Combine(
						PathProvider.Global.Latest.InstallFolder,
						"TSData\\Res\\Text\\Wants.package"
					)
				);
			}
		}

		/// <summary>
		/// Load the availableGoals
		/// </summary>
		static void LoadGoals()
		{
			if (
				PathProvider.Global.GetExpansion(Expansions.IslandStories).Exists
				&& Helper.WindowsRegistry.Config.LoadOnlySimsStory != 28
			)
			{
				string gly =
					System.IO.Path.Combine(
						PathProvider
							.Global.GetExpansion(Expansions.IslandStories)
							.InstallFolder,
						"TSData\\Res\\Wants\\Goals.package"
					)
				;
				FileTableBase.FileIndex.AddIndexFromPackage(gly);
				gly =
					System.IO.Path.Combine(
						PathProvider
							.Global.GetExpansion(Expansions.IslandStories)
							.InstallFolder,
						"TSData\\Res\\UI\\ui.package"
					)
				;
				FileTableBase.FileIndex.AddIndexFromPackage(gly);
			}
			goals = new Hashtable();

			FileTableBase.FileIndex.Load();

			foreach (Interfaces.Scenegraph.IScenegraphFileIndexItem wts in FileTableBase.FileIndex.FindFile(FileTypes.GOAL, true))
			{
				goals[wts.FileDescriptor.Instance] = wts;
			}
		}

		/// <summary>
		/// Returns a XGoal File for this Item or null
		/// </summary>
		/// <param name="guid">The GUID of the Goal</param>
		/// <returns>The XGoal Object representing That Goal (or null if not found)</returns>
		public static XGoal GetGoal(uint guid)
		{
			if (goals == null)
			{
				LoadGoals();
			}

			Interfaces.Scenegraph.IScenegraphFileIndexItem wts =
				(Interfaces.Scenegraph.IScenegraphFileIndexItem)goals[guid];
			if (wts != null)
			{
				wts.FileDescriptor.UserData = wts
					.Package.Read(wts.FileDescriptor)
					.UncompressedData;

				return new XGoal().ProcessFile(wts);

			}

			return null;
		}

		/// <summary>
		/// Returns the String File describing that Goal
		/// </summary>
		/// <param name="wnt">The Goal File</param>
		/// <returns>The Str File or null if none was found</returns>
		public static PackedFiles.Wrapper.Str LoadText(XGoal wnt)
		{
			if (wnt == null)
			{
				return null;
			}

			if (txtpkg == null)
			{
				LoadTextPackage();
			}

			Interfaces.Files.IPackedFileDescriptor[] pfds = txtpkg.FindFile(
				Data.FileTypes.STR,
				0,
				wnt.StringInstance
			);
			if (pfds.Length > 0)
			{
				pfds[0].UserData = txtpkg.Read(pfds[0]).UncompressedData;

				return new PackedFiles.Wrapper.Str().ProcessFile(pfds[0], txtpkg);

			}

			return null;
		}

		/// <summary>
		/// Returns the Icon File for the passed Goal
		/// </summary>
		/// <param name="wnt">The Goal File</param>
		/// <returns>The Picture File or null if none was found</returns>
		public static Picture LoadIcon(XGoal wnt)
		{
			if (wnt == null)
			{
				return null;
			}

			if (txtpkg == null)
			{
				LoadTextPackage();
			}

			Interfaces.Scenegraph.IScenegraphFileIndexItem item =
				FileTableBase.FileIndex.FindFile(wnt.IconFileDescriptor, null).FirstOrDefault();
			if (item != null)
			{
				item.FileDescriptor.UserData = item
					.Package.Read(item.FileDescriptor)
					.UncompressedData;
				Picture pic = new Picture().ProcessFile(item);

				return pic;

			}
			return null;
		}
	}
}
