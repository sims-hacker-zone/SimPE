// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Threading;

using Ambertation.Threading;

using SimPe.Data;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Picture;
using SimPe.PackedFiles.Str;

namespace SimPe.Providers
{
	/// <summary>
	/// Summary description for LotProvider.
	/// </summary>
	public class LotProvider : StoppableThread, Interfaces.Providers.ILotProvider
	{
		public class LotItem : Interfaces.Providers.ILotItem, IDisposable
		{
			internal LotItem(
				uint inst,
				string name,
				System.Drawing.Image img,
				Interfaces.Scenegraph.IScenegraphFileIndexItem fii
			)
			{
				Name = name;
				Image = img;
				Instance = inst;
				Owner = 0;
				Tags = new ArrayList();
				LtxtFileIndexItem = fii;
			}

			public object FindTag(Type tp)
			{
				foreach (object o in Tags)
				{
					if (o == null)
					{
						continue;
					}

					if (tp == o.GetType())
					{
						return o;
					}
				}

				return null;
			}

			public ArrayList Tags
			{
				get; private set;
			}

			public uint Owner
			{
				get; set;
			}

			public uint Instance
			{
				get;
			}

			public System.Drawing.Image Image
			{
				get; private set;
			}

			public string Name
			{
				get; private set;
			}

			public override int GetHashCode()
			{
				return (int)Instance;
			}

			public override string ToString()
			{
				return LotName;
			}

			public Interfaces.Scenegraph.IScenegraphFileIndexItem LtxtFileIndexItem
			{
				get; set;
			}

			public Interfaces.Scenegraph.IScenegraphFileIndexItem BnfoFileIndexItem
			{
				get
				{
					if (LtxtFileIndexItem == null)
					{
						return null;
					}

					Interfaces.Files.IPackedFileDescriptor pfd =
						LtxtFileIndexItem.Package.FindFile(
							FileTypes.BNFO,
							0,
							MetaData.LOCAL_GROUP,
							Instance
						);
					return pfd == null
						? null
						: (Interfaces.Scenegraph.IScenegraphFileIndexItem)new Plugin.FileIndexItem(
						pfd,
						LtxtFileIndexItem.Package
					);
				}
			}

			public Interfaces.Scenegraph.IScenegraphFileIndexItem StrFileIndexItem
			{
				get
				{
					if (LtxtFileIndexItem == null)
					{
						return null;
					}

					Interfaces.Files.IPackedFileDescriptor pfd =
						LtxtFileIndexItem.Package.FindFile(
							FileTypes.STR,
							0,
							MetaData.LOCAL_GROUP,
							Instance | 0x8000
						);
					return pfd == null
						? null
						: (Interfaces.Scenegraph.IScenegraphFileIndexItem)new Plugin.FileIndexItem(
						pfd,
						LtxtFileIndexItem.Package
					);
				}
			}

			public string LotName
			{
				get
				{
					Interfaces.Scenegraph.IScenegraphFileIndexItem stri =
						StrFileIndexItem;
					if (stri != null)
					{
						Str str =
							new PackedFiles.Str.Str().ProcessFile(stri);
						StrItemList items =
							str.FallbackedLanguageItems(
								Helper.WindowsRegistry.Config.LanguageCode
							);
						if (items.Length > 0)
						{
							string ret = items[0].Title;
							str.Dispose();
							return ret;
						}
						str.Dispose();
					}
					else if (Instance == 0)
					{
						return "Family Bin";
					}

					return Name;
				}
			}

			#region IDisposable Member

			public void Dispose()
			{
				Image = null;
				Name = null;
				Tags?.Clear();

				Tags = null;
				LtxtFileIndexItem = null;
			}

			#endregion
		}

		Hashtable content;

		/// <summary>
		/// The Folder from where the SimInformation was loaded
		/// </summary>
		private string dir;
		private string ngbh;

		/// <summary>
		/// Additional FileIndex fro template SimNames
		/// </summary>
		Interfaces.Scenegraph.IScenegraphFileIndex lotfi;
		Interfaces.Scenegraph.IScenegraphFileIndex ngbhfi;

		/// <summary>
		/// Creates the List for the specific Folder
		/// </summary>
		/// <param name="folder">The Folder with the Character Files</param>
		public LotProvider(string folder)
			: base()
		{
			BaseFolder = folder;
			lotfi = new Plugin.FileIndex(new System.Collections.Generic.List<FileTableItem>());
			ngbhfi = lotfi.AddNewChild();
		}

		/// <summary>
		/// Creates the List for the specific Folder
		/// </summary>
		public LotProvider()
			: this("") { }

		/// <summary>
		/// Returns or sets the Folder where the Lot Files are stored
		/// </summary>
		/// <remarks>Sets the content List to null</remarks>
		public string BaseFolder
		{
			get => dir;
			set
			{
				if (dir != value)
				{
					WaitForEnd(); // wait for any other stoppable threads to end
					if (dir != value) // if other thread has set dir then it has also set content so lets not wipe it out
					{
						content = null;
					}
				}
				dir = value;
				string[] pe = dir.Split(new char[] { '/', '\\' });
				ngbh = pe.Length > 1 ? pe[pe.Length - 2] : null;
			}
		}

		protected uint GetInstanceFromFilename(string flname)
		{
			flname = Path.GetFileNameWithoutExtension(flname).ToLower();
			int pos = flname.IndexOf("_lot");
			flname = flname.Substring(pos + 4);

			return Helper.StringToUInt32(flname, 0, 10);
		}

		public event Interfaces.Providers.LoadLotData LoadingLot;

		protected override void StartThread()
		{
			lotfi.Load();
			System.Collections.Generic.IEnumerable<Interfaces.Scenegraph.IScenegraphFileIndexItem> items =
				lotfi.FindFile(FileTypes.IMG, MetaData.LOCAL_GROUP, 0x35CA0002, null);
			bool run = Wait.Running;
			if (!run)
			{
				Wait.Start();
			}

			Wait.SubStart(items.Count());
			try
			{
				int ct = 0;
				int step = Math.Max(2, Wait.MaxProgress / 100);
				foreach (
					Interfaces.Scenegraph.IScenegraphFileIndexItem item in items
				)
				{
					if (HaveToStop)
					{
						break;
					}

					Interfaces.Files.IPackageFile pkg = item.Package;

					Interfaces.Files.IPackedFileDescriptor pfd = pkg.FindFile(
						FileTypes.STR,
						0,
						MetaData.LOCAL_GROUP,
						0x00000A46
					);
					string name = Localization.GetString("Unknown");
					if (pfd != null)
					{
						StrItemList list =
							new PackedFiles.Str.Str().ProcessFile(pfd, pkg).FallbackedLanguageItems(
								Helper.WindowsRegistry.Config.LanguageCode
							);
						if (list.Count > 0)
						{
							name = list[0].Title;
						}
					}


					uint inst = GetInstanceFromFilename(pkg.SaveFileName);


					LotItem li = new LotItem(inst, name, new Picture().ProcessFile(item).Image, ngbhfi.FindFile(
							FileTypes.LTXT,
							MetaData.LOCAL_GROUP,
							inst,
							null
						).FirstOrDefault());
					LoadingLot?.Invoke(this, li);

					content[li.Instance] = li;
					ct++;
					if (ct % step == 0)
					{
						Wait.Message = name;
						Wait.Progress = ct;
					}
				} //foreach
			}
#if !DEBUG
			catch (Exception ex)
			{
				Helper.ExceptionMessage(ex);
			}
#endif
			finally
			{
				Wait.SubStop();
				if (!run)
				{
					Wait.Stop(true);
				}
			}

			ended.Set();
		}

		object sync = new object();

		void AddHoodsToFileIndex()
		{
			string mydir = Directory.GetParent(dir).FullName;
			string[] names = Directory.GetFiles(mydir, ngbh + "_*.package");
			foreach (string name in names)
			{
				Packages.GeneratableFile pkg =
					Packages.File.LoadFromFile(name);
				ngbhfi.AddTypesIndexFromPackage(pkg, FileTypes.LTXT, false);
			}
		}

		void AddLotsToFileIndex()
		{
			//ngbhfi.AddIndexFromFolder(dir);
			string[] names = Directory.GetFiles(dir, ngbh + "*_Lot*.package");
			foreach (string name in names)
			{
				Packages.GeneratableFile pkg =
					Packages.File.LoadFromFile(name);
				ngbhfi.AddTypesIndexFromPackage(pkg, FileTypes.IMG, false);
			}
		}

		/// <summary>
		/// Loads all package Files in the directory and scans them for Name Informations
		/// </summary>
		public void LoadLotsFromFolder()
		{
			WaitForEnd(); // wait for any other stoppable threads to end
			if (content != null)
			{
				return; // if content was set by other thread then lets not do it again
			}

			content = new Hashtable();

			if (Helper.StartedGui == Executable.Classic)
			{
				return;
			}

			if (!Directory.Exists(dir))
			{
				return;
			}

			Wait.SubStart();
			ngbhfi.Clear();

			AddLotsToFileIndex();
			AddHoodsToFileIndex();
			Wait.SubStop();

			ExecuteThread(ThreadPriority.AboveNormal, "Lot Provider", true, true);
		}

		public Interfaces.Providers.ILotItem FindLot(uint inst)
		{
			object o = StoredData[inst];
			return o == null
				? new LotItem(
					inst,
					Localization.GetString("Unknown"),
					null,
					null
				)
				: o as Interfaces.Providers.ILotItem;
		}

		public Interfaces.Providers.ILotItem[] FindLotsOwnedBySim(uint siminst)
		{
			ArrayList list = new ArrayList();

			Hashtable ht = StoredData;
			foreach (Interfaces.Providers.ILotItem item in ht.Values)
			{
				if (item.Owner == siminst)
				{
					list.Add(item);
				}
			}

			Interfaces.Providers.ILotItem[] ret =
				new Interfaces.Providers.ILotItem[list.Count];
			list.CopyTo(ret);
			return ret;
		}

		public string[] GetNames()
		{
			Hashtable c = StoredData;
			string[] ret = new string[c.Values.Count];
			int ct = 0;
			foreach (LotItem li in c.Values)
			{
				ret[ct++] = li.Name;
			}

			return ret;
		}

		/// <summary>
		/// Returrns the stored Alias Data
		/// </summary>
		public Hashtable StoredData
		{
			get
			{
				if (content == null)
				{
					LoadLotsFromFolder();
				}

				return content;
			}
			set => content = value;
		}

		internal void sdescprovider_ChangedPackage(object sender, EventArgs e)
		{
		}
	}
}
