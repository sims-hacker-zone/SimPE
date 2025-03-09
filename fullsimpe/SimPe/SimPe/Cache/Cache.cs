// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using SimPe.Data;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Mmat;
using SimPe.PackedFiles.Objd;
using SimPe.PackedFiles.Picture;
using SimPe.PackedFiles.Str;
using SimPe.PackedFiles.Swaf;
using SimPe.Plugin;

namespace SimPe.Cache
{
	public class Cache
	{
		private static Cache globalCache;
		public static Cache GlobalCache
		{
			get
			{
				if (globalCache == null)
				{
					globalCache = Load(Helper.SimPeLanguageCache, true);
				}
				return globalCache;
			}
		}

		/// <summary>
		/// This is the obsolete 64-Bit Int, included for backward compatibility
		/// </summary>
		public const ulong OLDSIG = 0x45506d6953;

		/// <summary>
		/// This is the 64-Bit Int, a cache File needs to start with
		/// </summary>
		public const ulong SIGNATURE = 0x7374695420676942;

		/// <summary>
		/// The current Version
		/// </summary>
		public const byte VERSION = 1;

		/// <summary>
		/// Returns the Version of the File
		/// </summary>
		public byte Version
		{
			get; private set;
		}

		/// <summary>
		/// The last used FileName (can be null)
		/// </summary>
		public string FileName
		{
			get; private set;
		}

		/// <summary>
		/// The file Signature
		/// </summary>
		public ulong Signature
		{
			get; private set;
		}

		public Dictionary<ContainerType, Dictionary<string, CacheContainer>> Items
		{
			get;
			private set;
		} = new Dictionary<ContainerType, Dictionary<string, CacheContainer>>
		{
			[ContainerType.Object] = new Dictionary<string, CacheContainer>(),
			[ContainerType.MaterialOverride] = new Dictionary<string, CacheContainer>(),
			[ContainerType.Want] = new Dictionary<string, CacheContainer>(),
			[ContainerType.Memory] = new Dictionary<string, CacheContainer>(),
			[ContainerType.Package] = new Dictionary<string, CacheContainer>(),
			[ContainerType.Rcol] = new Dictionary<string, CacheContainer>(),
			[ContainerType.Goal] = new Dictionary<string, CacheContainer>(),
		};

		public Cache()
		{
			Version = VERSION;
		}

		public static Cache Load(string flname, bool withprogress = false)
		{
			if (!File.Exists(flname))
			{
				return new Cache
				{
					FileName = flname
				};
			}
			Console.WriteLine($"Load Global Cache from {flname}");
			Cache c = new Cache
			{
				FileName = flname
			};
			using (FileStream fs = File.Open(flname, FileMode.Open, FileAccess.Read))
			{
				using (BinaryReader reader = new BinaryReader(fs))
				{
					c.Signature = reader.ReadUInt64();
					if (c.Signature != OLDSIG && c.Signature != SIGNATURE)
					{
						throw new CacheException(
							"Unknown Cache File Signature ("
								+ $"{c.Signature:X16}"
								+ ")",
							flname,
							0
						);
					}

					c.Version = reader.ReadByte();
					if (c.Version > VERSION)
					{
						throw new CacheException(
							"Unable to read Cache",
							flname,
							c.Version
						);
					}

					int count = reader.ReadInt32();
					if (withprogress)
					{
						Wait.MaxProgress = count;
					}

					for (int i = 0; i < count; i++)
					{
						CacheContainer cc = new CacheContainer().Load(reader);
						if (!c.Items.ContainsKey(cc.Type))
						{
							c.Items[cc.Type] = new Dictionary<string, CacheContainer>
							{
								[cc.FileName] = cc
							};
						}
						else
						{
							c.Items[cc.Type][cc.FileName] = cc;
						}
						if (withprogress)
						{
							Wait.Progress = i;
						}

						if (i % 10 == 0)
						{
							System.Windows.Forms.Application.DoEvents();
						}
					}
				}
			}
			return c;
		}

		public void Save()
		{
			SaveAs(FileName);
		}

		public void SaveAs(string flname)
		{
			Console.WriteLine("Saving Cache to " + flname);
			FileName = flname;
			Version = VERSION;

			using (FileStream fs = File.Open(flname, FileMode.OpenOrCreate, FileAccess.Write))
			{
				using (BinaryWriter writer = new BinaryWriter(fs))
				{
					writer.Write(SIGNATURE);
					writer.Write(Version);

					IEnumerable<CacheContainer> containers = from types in Items.Values
															 from c in types.Values
															 select c;
					writer.Write(containers.Count());
					List<long> offsets = new List<long>();
					//prepare the Index
					for (int i = 0; i < containers.Count(); i++)
					{
						offsets.Add(writer.BaseStream.Position);
						containers.ElementAt(i).Save(writer, -1);
					}
					//write the Data
					for (int i = 0; i < containers.Count(); i++)
					{
						long offset = writer.BaseStream.Position;
						writer.BaseStream.Seek(offsets[i], SeekOrigin.Begin);
						containers.ElementAt(i).Save(writer, (int)offset);
					}
				}
			}
		}

		#region Goal Cache

		public void AddGoalItem(GoalInformation goal)
		{
			if (!Items[ContainerType.Goal].ContainsKey(goal.XGoal.Package.FileName))
			{
				Items[ContainerType.Goal][goal.XGoal.Package.FileName] = new CacheContainer(ContainerType.Goal)
				{
					FileName = goal.XGoal.Package.FileName
				};
			}
			Items[ContainerType.Goal][goal.XGoal.Package.FileName].Items.Add(new GoalCacheItem
			{
				FileDescriptor = goal.XGoal.FileDescriptor,
				Guid = goal.Guid,
				Icon = goal.Icon,
				Influence = goal.XGoal.Influence,
				Name = goal.Name,
				Score = goal.XGoal.Score
			});
		}

		#endregion

		#region Memory Cache

		private FileIndex memoryCacheFileIndex;
		public FileIndex MemoryCacheFileIndex
		{
			get
			{
				if (memoryCacheFileIndex == null)
				{
					LoadMemTable();
				}
				return memoryCacheFileIndex;
			}
		}

		private bool memoryCacheInitialized = false;

		public void InitMemoryCache()
		{
			FileTableBase.FileIndex.Load();
			InitMemoryCache(FileTableBase.FileIndex);
		}

		public void InitMemoryCache(Interfaces.Scenegraph.IScenegraphFileIndex fileindex)
		{
			Wait.SubStart();
			Wait.Message = "Loading Memorycache";
			if (!memoryCacheInitialized)
			{
				ReloadMemoryCache(fileindex, true);
				memoryCacheInitialized = true;
			}
			Wait.SubStop();
		}
		public MemoryCacheItem AddMemoryItem(ExtObjd objd)
		{
			if (!Items[ContainerType.Memory].ContainsKey(objd.Package.FileName))
			{
				Items[ContainerType.Memory][objd.Package.FileName] = new CacheContainer(ContainerType.Memory)
				{
					FileName = objd.Package.FileName
				};
			}

			MemoryCacheItem mci = new MemoryCacheItem
			{
				FileDescriptor = objd.FileDescriptor,
				Guid = objd.Guid,
				ObjectType = objd.Type,
				ObjdName = objd.FileName,
				ParentCacheContainer = Items[ContainerType.Memory][objd.Package.FileName]
			};

			try
			{
				Interfaces.Scenegraph.IScenegraphFileIndexItem sitem =
					FileTableBase.FileIndex.FindFile(
						Data.FileTypes.CTSS,
						objd.FileDescriptor.Group,
						objd.CTSSInstance + (ulong)1,
						null
					).FirstOrDefault() ?? FileTableBase.FileIndex.FindFile(
						Data.FileTypes.CTSS,
						objd.FileDescriptor.Group,
						objd.CTSSInstance,
						null
					).FirstOrDefault();

				if (sitem != null)
				{
					Str str =
						new PackedFiles.Str.Str().ProcessFile(sitem);
					StrItemList strs = str.LanguageItems(
						Helper.WindowsRegistry.Config.LanguageCode
					);
					if (strs.Length > 0)
					{
						mci.Name = strs[0].Title;
					}

					//not found?
					if (mci.Name == "")
					{
						strs = str.LanguageItems(1);
						if (strs.Length > 0)
						{
							mci.Name = strs[0].Title;
						}
					}
				}
			}
			catch (Exception) { }

			try
			{
				Interfaces.Scenegraph.IScenegraphFileIndexItem sitem =
					FileTableBase.FileIndex.FindFile(
						Data.FileTypes.STR,
						objd.FileDescriptor.Group,
						0x100,
						null
					).FirstOrDefault();
				if (sitem != null)
				{
					Str str =
						new PackedFiles.Str.Str().ProcessFile(sitem);
					StrItemList strs = str.LanguageItems(
						Data.Languages.English
					);
					mci.ValueNames.AddRange((IEnumerable<string>)strs);
				}
			}
			catch (Exception) { }

			//still no name?
			if (mci.Name == "")
			{
				mci.Name = objd.FileName;
			}
			//having an icon?
			Picture pic =
				new Picture();
			Interfaces.Scenegraph.IScenegraphFileIndexItem iitem = mci.IsBadge
				? FileTableBase.FileIndex.FindFile(
					FileTypes.IMG,
					objd.FileDescriptor.Group,
					3,
					null
				).FirstOrDefault()
				: FileTableBase.FileIndex.FindFile(
					FileTypes.IMG,
					objd.FileDescriptor.Group,
					1,
					null
				).FirstOrDefault();

			if (iitem != null)
			{
				pic.ProcessData(iitem);
				mci.Icon = pic.Image;
				Wait.Image = mci.Icon;
			}

			Wait.Message = $"Initializing Memory Cache ({mci.Name})";
			mci.ParentCacheContainer.Items.Add(mci);

			return mci;
		}

		public void ReloadMemoryCache()
		{
			ReloadMemoryCache(true);
		}

		public void ReloadMemoryCache(bool save)
		{
			FileTableBase.FileIndex.Load();
			ReloadMemoryCache(FileTableBase.FileIndex, save);
		}

		public void ReloadMemoryCache(
			Interfaces.Scenegraph.IScenegraphFileIndex fileindex,
			bool save
		)
		{
			IEnumerable<Interfaces.Scenegraph.IScenegraphFileIndexItem> items = fileindex.FindFile(
				Data.FileTypes.OBJD,
				true
			);

			bool added = false;
			Wait.MaxProgress = items.Count();
			Wait.Message = "Validating Memory Cache";
			int ct = 0;

			foreach (Interfaces.Scenegraph.IScenegraphFileIndexItem item in items)
			{
				IEnumerable<Interfaces.Scenegraph.IScenegraphFileIndexItem> citems =
					MemoryCacheFileIndex.FindFile(item.GetLocalFileDescriptor(), null);
				if (citems.Count() == 0)
				{

					AddMemoryItem(new PackedFiles.Objd.ExtObjd().ProcessFile(item));
					added = true;
				}
				Wait.Progress = ct++;
			}
			if (added)
			{
				Wait.Message = "Saving Chache";
				if (save)
				{
					Save();
				}
			}
		}

		public MemoryCacheItem FindMemoryItem(uint guid)
		{
			return (from items in Items[ContainerType.Memory].Values
					from MemoryCacheItem mci in items
					where mci.Guid == guid
					select mci).FirstOrDefault();
		}
		public void LoadMemTable()
		{
			memoryCacheFileIndex = new FileIndex(new List<FileTableItem>())
			{
				Duplicates = false
			};

			foreach ((string FileName, Interfaces.Files.IPackedFileDescriptor pfd) in from files in Items[ContainerType.Memory]
																					  from MemoryCacheItem mci in files.Value
																					  where files.Value.Valid
																					  select (files.Value.FileName, mci.FileDescriptor))
			{
				pfd.Filename = FileName;
				memoryCacheFileIndex.AddIndexFromPfd(
					pfd,
					null,
					FileIndex.GetLocalGroup(pfd.Filename)
				);
			}
		}
		#endregion

		#region MMAT Cache

		private FileIndex mmatCacheFileIndex;
		public FileIndex MmatCacheFileIndex
		{
			get
			{
				if (mmatCacheFileIndex == null)
				{
					LoadOverrides();
				}
				return mmatCacheFileIndex;
			}
		}

		public void AddMmatItem(MmatWrapper mmat)
		{
			if (!Items[ContainerType.MaterialOverride].ContainsKey(mmat.Package.FileName))
			{
				Items[ContainerType.MaterialOverride][mmat.Package.FileName] = new CacheContainer(ContainerType.MaterialOverride)
				{
					FileName = mmat.Package.FileName
				};
			}
			Items[ContainerType.MaterialOverride][mmat.Package.FileName].Items.Add(new MMATCacheItem
			{
				Default = mmat.DefaultMaterial,
				ModelName = mmat.ModelName.Trim().ToLower(),
				Family = mmat.Family.Trim().ToLower(),
				FileDescriptor = mmat.FileDescriptor
			});
		}

		public void LoadOverrides()
		{
			mmatCacheFileIndex = new FileIndex(new List<FileTableItem>())
			{
				Duplicates = false
			};

			foreach ((string FileName, Interfaces.Files.IPackedFileDescriptor pfd) in from files in Items[ContainerType.MaterialOverride]
																					  from MMATCacheItem mci in files.Value
																					  where files.Value.Valid
																					  select (files.Value.FileName, mci.FileDescriptor))
			{
				pfd.Filename = FileName;
				mmatCacheFileIndex.AddIndexFromPfd(
					pfd,
					null,
					FileIndex.GetLocalGroup(pfd.Filename)
				);
			}
		}
		#endregion

		#region Object Cache
		private FileIndex objectCacheFileIndex;
		public FileIndex ObjectCacheFileIndex
		{
			get
			{
				if (objectCacheFileIndex == null)
				{
					LoadObjects();
				}
				return objectCacheFileIndex;
			}
		}

		public void AddObjectItem(ObjectCacheItem oci, string filename)
		{
			if (!Items[ContainerType.Object].ContainsKey(filename))
			{
				Items[ContainerType.Object][filename] = new CacheContainer(ContainerType.Object)
				{
					FileName = filename
				};
			}
			Items[ContainerType.Object][filename].Items.Add(oci);
		}

		public void LoadObjects()
		{
			objectCacheFileIndex = new FileIndex(new List<FileTableItem>())
			{
				Duplicates = false
			};

			foreach ((string FileName, Interfaces.Files.IPackedFileDescriptor pfd) in from files in Items[ContainerType.Object]
																					  from ObjectCacheItem oci in files.Value
																					  where files.Value.Valid
																					  select (files.Value.FileName, oci.FileDescriptor))
			{
				pfd.Filename = FileName;
				objectCacheFileIndex.AddIndexFromPfd(
					pfd,
					null,
					FileIndex.GetLocalGroup(pfd.Filename)
				);
			}
		}
		#endregion

		#region Package Cache
		public ScannerItem LoadPackageItem(string filename)
		{
			if (!Items[ContainerType.Package].ContainsKey(filename))
			{
				Items[ContainerType.Package][filename] = new CacheContainer(ContainerType.Package)
				{
					FileName = filename
				};
			}

			if (Items[ContainerType.Package][filename].Count() == 0)
			{
				PackageCacheItem pci = new PackageCacheItem
				{
					Name = Path.GetFileNameWithoutExtension(filename)
				};
				Items[ContainerType.Package][filename].Items.Add(pci);

				return new ScannerItem(pci, Items[ContainerType.Package][filename])
				{
					FileName = filename
				};
			}
			else
			{
				return new ScannerItem(
					(PackageCacheItem)Items[ContainerType.Package][filename].Items[0],
					Items[ContainerType.Package][filename]
				)
				{
					FileName = filename
				};
			}
		}
		#endregion

		#region Want Cache

		public void AddWantItem(WantInformation want)
		{

			if (!Items[ContainerType.Want].ContainsKey(want.XWant.Package.FileName))
			{
				Items[ContainerType.Want][want.XWant.Package.FileName] = new CacheContainer(ContainerType.Want)
				{
					FileName = want.XWant.Package.FileName
				};
			}
			Items[ContainerType.Want][want.XWant.Package.FileName].Items.Add(new WantCacheItem
			{
				FileDescriptor = want.XWant.FileDescriptor,
				Folder = want.XWant.Folder,
				Guid = want.Guid,
				Icon = want.Icon,
				Influence = want.XWant.Influence,
				Name = want.Name,
				ObjectType = want.XWant.ObjectType,
				Score = want.XWant.Score
			});
		}

		#endregion
	}
}
