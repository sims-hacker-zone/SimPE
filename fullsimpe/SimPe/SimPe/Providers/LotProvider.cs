/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
using System;
using System.Collections;
using System.IO;
using System.Threading;

using Ambertation.Threading;

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
							0x104F6A6E,
							0,
							Data.MetaData.LOCAL_GROUP,
							Instance
						);
					if (pfd == null)
					{
						return null;
					}

					return new Plugin.FileIndexItem(
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
							Data.MetaData.STRING_FILE,
							0,
							Data.MetaData.LOCAL_GROUP,
							Instance | 0x8000
						);
					if (pfd == null)
					{
						return null;
					}

					return new Plugin.FileIndexItem(
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
						PackedFiles.Wrapper.Str str =
							new PackedFiles.Wrapper.Str();
						str.ProcessData(stri);
						PackedFiles.Wrapper.StrItemList items =
							str.FallbackedLanguageItems(
								Helper.WindowsRegistry.LanguageCode
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

			ArrayList folders = new ArrayList();
			lotfi = new Plugin.FileIndex(folders);
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
			Interfaces.Scenegraph.IScenegraphFileIndexItem[] items =
				lotfi.FindFile(0x856DDBAC, Data.MetaData.LOCAL_GROUP, 0x35CA0002, null);
			bool run = Wait.Running;
			if (!run)
			{
				Wait.Start();
			}

			Wait.SubStart(items.Length);
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
						Data.MetaData.STRING_FILE,
						0,
						Data.MetaData.LOCAL_GROUP,
						0x00000A46
					);
					string name = Localization.GetString("Unknown");
					if (pfd != null)
					{
						PackedFiles.Wrapper.Str str =
							new PackedFiles.Wrapper.Str();
						str.ProcessData(pfd, pkg);

						PackedFiles.Wrapper.StrItemList list =
							str.FallbackedLanguageItems(
								Helper.WindowsRegistry.LanguageCode
							);
						if (list.Count > 0)
						{
							name = list[0].Title;
						}
					}

					PackedFiles.Wrapper.Picture pic =
						new PackedFiles.Wrapper.Picture();
					pic.ProcessData(item);

					uint inst = GetInstanceFromFilename(pkg.SaveFileName);

					Interfaces.Scenegraph.IScenegraphFileIndexItem[] ltxtitems =
						ngbhfi.FindFile(
							0x0BF999E7,
							Data.MetaData.LOCAL_GROUP,
							inst,
							null
						);
					Interfaces.Scenegraph.IScenegraphFileIndexItem ltxt = null;
					if (ltxtitems.Length > 0)
					{
						ltxt = ltxtitems[0];
					}

					LotItem li = new LotItem(inst, name, pic.Image, ltxt);
					if (LoadingLot != null)
					{
						LoadingLot(this, li);
					}

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
				ngbhfi.AddTypesIndexFromPackage(pkg, 0x0BF999E7, false);
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
				ngbhfi.AddTypesIndexFromPackage(pkg, 0x856DDBAC, false);
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
			if (o == null)
			{
				return new LotItem(
					inst,
					Localization.GetString("Unknown"),
					null,
					null
				);
			}

			return o as Interfaces.Providers.ILotItem;
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
