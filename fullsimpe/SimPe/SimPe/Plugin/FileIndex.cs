// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using SimPe.Interfaces.Scenegraph;

namespace SimPe.Plugin
{

	/// <summary>
	/// This class contains a Index of all found Files
	/// </summary>
	public class FileIndex
		: Ambertation.Threading.StoppableThread,
			IScenegraphFileIndex,
			IDisposable
	{
		/// <summary>
		/// This Hashtable (FileType) contains a Hashtable (Group) of Hashtables (Instance) of ArrayLists (Files)
		/// </summary>
		Dictionary<uint, Dictionary<uint, Dictionary<ulong, List<IScenegraphFileIndexItem>>>> Index { get; set; } = new Dictionary<uint, Dictionary<uint, Dictionary<ulong, List<IScenegraphFileIndexItem>>>>();

		/// <summary>
		/// Contains a List of the Filenames of all added packages
		/// </summary>
		List<string> addedfilenames = new List<string>();

#if DEBUG
		/// <summary>
		/// Just for Debugging
		/// </summary>
		public ArrayList StoredFiles
		{
			get
			{
				ArrayList ret = new ArrayList();

				foreach (IScenegraphFileIndex fi in Children)
				{
					ret.AddRange(((FileIndex)fi).StoredFiles);
				}

				ret.AddRange(addedfilenames);
				return ret;
			}
		}
#endif

		/// <summary>
		/// Contains the next number the Core can assign as a localGroup
		/// </summary>
		//static uint lastLocalGroup = 0x6f000000;

		/// <summary>
		/// Contains a Listing of all alternate Groups SimPe should check if the first try was no success
		/// </summary>
		private static readonly uint[] ALTERNATIVE_GROUPS = {Data.MetaData.CUSTOM_GROUP,
					Data.MetaData.GLOBAL_GROUP,
					Data.MetaData.LOCAL_GROUP};

		public bool Duplicates
		{
			get; set;
		}

		List<IScenegraphFileIndex> Children { get; set; } = new List<IScenegraphFileIndex>();
		FileIndex parent;

		/// <summary>
		/// Create a new Instance
		/// </summary>
		/// <remarks>Same as a call to FileIndex(null)</remarks>
		public FileIndex()
			: this(null) { }

		/// <summary>
		/// Create a new Instance
		/// </summary>
		/// <param name="folders">The Folders where you want to look for packages, null for the default Set</param>
		/// <remarks>The Default set is read from the Folder.xml File</remarks>
		public FileIndex(List<FileTableItem> folders)
			: base()
		{
			Loaded = false;
			paths = new ArrayList();
			Init(folders);
		}

		/// <summary>
		/// Creates a clone of this Object
		/// </summary>
		/// <returns>The Clone</returns>
		public IScenegraphFileIndex Clone()
		{
			FileIndex ret = new FileIndex(new List<FileTableItem>())
			{
				Index = new Dictionary<uint, Dictionary<uint, Dictionary<ulong, List<IScenegraphFileIndexItem>>>>(Index),
				BaseFolders = new List<FileTableItem>(BaseFolders),
				addedfilenames = new List<string>(addedfilenames),
				Duplicates = Duplicates,
				Loaded = Loaded
			};

			return ret;
		}

		#region StoreState
		List<string> oldnames;
		Dictionary<uint, Dictionary<uint, Dictionary<ulong, List<IScenegraphFileIndexItem>>>> oldindex;
		bool olddup;

		/// <summary>
		/// Stores the current State of the FileIndex.
		///
		/// You can revert to the last stored state by calling RestoreLastState()
		/// </summary>
		public void StoreCurrentState()
		{
			oldnames = new List<string>(addedfilenames);
			oldindex = new Dictionary<uint, Dictionary<uint, Dictionary<ulong, List<IScenegraphFileIndexItem>>>>(Index);
			olddup = Duplicates;
		}

		/// <summary>
		/// Restores the last stored state (if one is available)
		/// </summary>
		public void RestoreLastState()
		{
			if (oldnames == null || oldindex == null)
			{
				return;
			}

			PrepareAllForRemove();

			addedfilenames = oldnames;
			Index = oldindex;
			Duplicates = olddup;

			oldnames = null;
			oldindex = null;

			PrepareAllForAdd();
		}

		#endregion

		/// <summary>
		/// Returns the List of all Folders this FileIndex is processing
		/// </summary>
		public List<FileTableItem> BaseFolders
		{
			get; set;
		}

		IEnumerable<string> IgnoredFiles => from fti in BaseFolders
											where fti.IsFile && fti.IsUseable && fti.Ignore
											select fti.Name.Trim().ToLower();

		/// <summary>
		/// Initialize the instance Data
		/// </summary>
		/// <param name="folders">Fodlers to scan</param>
		protected void Init(List<FileTableItem> folders)
		{
			paths = new ArrayList();
			Duplicates = false;

			StoreCurrentState();

			BaseFolders = folders ?? FileTableBase.DefaultFolders;
		}

		/// <summary>
		/// Return the suggested local Group for the passed package
		/// </summary>
		/// <param name="package">The package File</param>
		/// <returns>the local Group</returns>
		public static uint GetLocalGroup(Interfaces.Files.IPackageFile package)
		{
			return GetLocalGroup(package.SaveFileName);
		}

		/// <summary>
		/// Return the suggested local Group for the passed package
		/// </summary>
		/// <param name="flname">The filename of the package</param>
		/// <returns>the local Group</returns>
		public static uint GetLocalGroup(string flname)
		{
			if (FileTableBase.GroupCache == null)
			{
				WrapperFactory.LoadGroupCache();
			}

			if (flname == null)
			{
				flname = "memoryfile";
			}

			flname = flname.Trim().ToLower();

			return FileTableBase.GroupCache.GetItem(flname).LocalGroup;
		}

		public bool Loaded
		{
			get; private set;
		}

		/// <summary>
		/// Load the FileIndex if it has not previously been loaded and not in LocalMode
		/// </summary>
		/// <remarks>
		/// Use ForceReload() to reload if previously load (for example,
		/// because the files changed) or to override LocalMode.
		/// </remarks>
		public void Load()
		{
			if (Loaded)
			{
				return;
			}

			//We do NOT use the Filetable in LocalMode - a ForceReload is required
			if (Helper.LocalMode)
			{
				return;
			}

			ForceReload();
		}

		/// <summary>
		/// Load the FileIndex whether or not it has previously been loaded or in LocalMode
		/// </summary>
		/// <remarks>
		/// Use Load() to only load if not yet loaded and not in LocalMode.
		/// </remarks>
		public void ForceReload()
		{
			//this.WaitForEnd();
			Loaded = true;

			//this.ExecuteThread(System.Threading.ThreadPriority.Normal, "FileTable Reload", true, true, 1000);
			StartThread();
		}

		public bool AllowEvent
		{
			get; set;
		}

		/// <summary>
		/// This is used to start the Reload Thread
		/// </summary>
		protected override void StartThread()
		{
			Wait.SubStart(BaseFolders.Count);
			Wait.Message = Localization.GetString("Loading") + " Group Cache";
			WrapperFactory.LoadGroupCache();

			Clear();

			int ct = 0;
			foreach (FileTableItem fti in BaseFolders)
			{
				if (HaveToStop)
				{
					break;
				}

				Wait.Progress = ct++;
				AddIndexFromFolder(fti);
			}

			Wait.SubStop();
			if (AllowEvent)
			{
				OnFILoad(this, new EventArgs()); // this triggers loading of PJSE filetable
			}
			else
			{
				AllowEvent = true;
			}
		}

		/// <summary>
		/// Indicates the File Index was loaded
		/// </summary>
		public event EventHandler FILoad;

		public virtual void OnFILoad(object sender, EventArgs e)
		{
			FILoad?.Invoke(sender, e);
		}

		ArrayList paths;

		/// <summary>
		/// True, if the given path was completley added
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public bool ContainsPath(string path)
		{
			if (path == null)
			{
				return false;
			}

			foreach (IScenegraphFileIndex fi in Children)
			{
				if (fi.ContainsPath(path))
				{
					return true;
				}
			}

			return paths.Contains(path);
		}

		/// <summary>
		/// Add all Files stored in all the packages found in the passed Folder
		/// </summary>
		/// <param name="fti">A FileTableItem describing the Location</param>
		public void AddIndexFromFolder(FileTableItem fti)
		{
			//if (fti.Ignore) return;
			if (!fti.Use)
			{
				return;
			}

			if (!paths.Contains(fti.Name))
			{
				paths.Add(fti.Name);
			}


			string err = "";
			foreach (string afile in fti.GetFiles())
			{
				try
				{
					AddIndexFromPackage(afile);
				}
				catch (Exception ex)
				{
					Console.WriteLine(
						"Error in AddIndexFromPackage: "
							+ ex.Message
							+ "\n"
							+ ex.StackTrace
					);
					err += ex.Message + "\n";
				}
			}

			if (fti.IsRecursive)
			{
				string[] folders = System.IO.Directory.GetDirectories(fti.Name);
				foreach (string folder in folders)
				{
					AddIndexFromFolder(":" + folder);
				}
			}

			//if (err!="") throw new Exception(err);
		}

		/// <summary>
		/// Add all Files stored in all the packages found in the passed Folder
		/// </summary>
		/// <param name="path">The Folder you want to scan</param>
		public void AddIndexFromFolder(string path)
		{
			path = path.Trim();
			if (path == "")
			{
				return;
			}

			FileTableItem fti = new FileTableItem(path);
			AddIndexFromFolder(fti);
		}

		/// <summary>
		/// Add all Files stored in the passed package
		/// </summary>
		/// <param name="file">Name of the package File</param>
		/// <remarks>Updates the WaitingScreen Message</remarks>
		public void AddIndexFromPackage(string file)
		{
			if (IgnoredFiles.Contains(file.Trim().ToLower()))
			{
				return;
			}

			Wait.Message =
				Localization.GetString("Loading")
				+ " \""
				+ System.IO.Path.GetFileNameWithoutExtension(file)
				+ "\"";
			try
			{
				Interfaces.Files.IPackageFile package =
					Packages.File.LoadFromFile(file, false);
				AddIndexFromPackage(package, false);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}

		/// <summary>
		/// Add all Files stored in the passed package
		/// </summary>
		/// <param name="package">The package File</param>
		public void AddIndexFromPackage(Interfaces.Files.IPackageFile package)
		{
			AddIndexFromPackage(package, false);
		}

		/// <summary>
		/// Add all Files stored in the passed package
		/// </summary>
		/// <param name="package">The package File</param>
		/// <param name="overwrite">true, if an existing Instance of that File should be overwritten</param>
		public void AddIndexFromPackage(
			Interfaces.Files.IPackageFile package,
			bool overwrite
		)
		{
			if (package == null)
			{
				return;
			}

			package.Persistent = true;
			if (package.FileName != null)
			{
				if (Contains(package.FileName.Trim().ToLower()) && !overwrite)
				{
					return;
				}

				addedfilenames.Add(package.FileName.Trim().ToLower());
			}

			uint local = GetLocalGroup(package);

			foreach (Interfaces.Files.IPackedFileDescriptor pfd in package.Index)
			{
				AddIndexFromPfd(pfd, package, local);
			}

			package.Persistent = false;
		}

		/// <summary>
		/// Add all Files stored in the passed package
		/// </summary>
		/// <param name="package">The package File</param>
		/// <param name="type">Resources of this Type will get added</param>
		/// <param name="overwrite">true, if an existing Instance of that File should be overwritten</param>
		public void AddTypesIndexFromPackage(
			Interfaces.Files.IPackageFile package,
			uint type,
			bool overwrite
		)
		{
			if (package == null)
			{
				return;
			}

			package.Persistent = true;
			if (package.FileName != null)
			{
				if (Contains(package.FileName.Trim().ToLower()) && !overwrite)
				{
					return;
				}

				addedfilenames.Add(package.FileName.Trim().ToLower());
			}

			uint local = GetLocalGroup(package);

			foreach (Interfaces.Files.IPackedFileDescriptor pfd in package.Index)
			{
				if (pfd.Type != type)
				{
					continue;
				}

				AddIndexFromPfd(pfd, package, local);
			}

			package.Persistent = false;
		}

		/// <summary>
		/// Add a Filedescriptor to the Index
		/// </summary>
		/// <param name="pfd">The Descriptor</param>
		/// <param name="package">The File</param>
		public void AddIndexFromPfd(
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile package
		)
		{
			uint local = GetLocalGroup(package);
			AddIndexFromPfd(pfd, package, local);
		}

		/// <summary>
		/// Add a Filedescriptor to the Index
		/// </summary>
		/// <param name="pfd">The Descriptor</param>
		/// <param name="package">The File</param>
		public void AddIndexFromPfd(
			SimPe.Collections.IO.PackedFileDescriptors pfds,
			Interfaces.Files.IPackageFile package
		)
		{
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				AddIndexFromPfd(pfd, package);
			}
		}

		/// <summary>
		/// Make sure the FileTable is empty
		/// </summary>
		public void Clear()
		{
			paths.Clear();
			addedfilenames.Clear();
			/*if (parent!=null)
			{
				foreach (string s in parent.addedfilenames)
					addedfilenames.Add(s);
			}*/

			foreach (Dictionary<uint, Dictionary<ulong, List<IScenegraphFileIndexItem>>> groups in Index.Values)
			{
				foreach (Dictionary<ulong, List<IScenegraphFileIndexItem>> instances in groups.Values)
				{
					foreach (List<IScenegraphFileIndexItem> res in instances.Values)
					{
						foreach (
							IScenegraphFileIndexItem pfd in res
						)
						{
							PrepareForRemove(pfd.FileDescriptor);
						}

						res.Clear();
					}
					instances.Clear();
				}
				groups.Clear();
			}
			Index.Clear();
		}

		protected void PrepareAllForAdd()
		{
			foreach (Dictionary<uint, Dictionary<ulong, List<IScenegraphFileIndexItem>>> groups in Index.Values)
			{
				foreach (Dictionary<ulong, List<IScenegraphFileIndexItem>> instances in groups.Values)
				{
					foreach (List<IScenegraphFileIndexItem> res in instances.Values)
					{
						foreach (
							IScenegraphFileIndexItem item in res
						)
						{
							PrepareForAdd(item.FileDescriptor);
						}
					}
				}
			}
		}

		protected void PrepareAllForRemove()
		{
			PrepareForRemove(from groups in Index.Values
							 from instances in groups.Values
							 from res in instances.Values
							 from item in res
							 select item.FileDescriptor);
		}

		protected void PrepareForRemove(
			Interfaces.Files.IPackedFileDescriptor pfd
		)
		{
			pfd.Closed -= new Events.PackedFileChanged(ClosedDescriptor);
		}

		protected void PrepareForRemove(IEnumerable<Interfaces.Files.IPackedFileDescriptor> pfds)
		{
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				pfd.Closed -= new Events.PackedFileChanged(ClosedDescriptor);
			}
		}

		protected void PrepareForAdd(Interfaces.Files.IPackedFileDescriptor pfd)
		{
			pfd.Closed += new Events.PackedFileChanged(ClosedDescriptor);
		}

		protected void PrepareForAdd(IEnumerable<Interfaces.Files.IPackedFileDescriptor> pfds)
		{
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				pfd.Closed += new Events.PackedFileChanged(ClosedDescriptor);
			}
		}

		/// <summary>
		/// Add a Filedescriptor to the Index
		/// </summary>
		/// <param name="pfd">The Descriptor</param>
		/// <param name="package">The File</param>
		/// <param name="localgroup">use this groupa as replacement for 0xffffffff</param>
		public void AddIndexFromPfd(
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile package,
			uint localgroup
		)
		{
			PrepareForAdd(pfd);
			FileIndexItem item = new FileIndexItem(pfd, package);

			if (!Index.ContainsKey(item.FileDescriptor.Type))
			{
				Index[item.FileDescriptor.Type] = new Dictionary<uint, Dictionary<ulong, List<IScenegraphFileIndexItem>>>();
			}

			if (!Index[item.FileDescriptor.Type].ContainsKey(item.FileDescriptor.Group))
			{
				Index[item.FileDescriptor.Type][item.FileDescriptor.Group] = new Dictionary<ulong, List<IScenegraphFileIndexItem>>();
			}

			if (!Index[item.FileDescriptor.Type][item.FileDescriptor.Group].ContainsKey(item.FileDescriptor.LongInstance))
			{
				Index[item.FileDescriptor.Type][item.FileDescriptor.Group][item.FileDescriptor.LongInstance] = new List<IScenegraphFileIndexItem>();
			}

			List<IScenegraphFileIndexItem> files = Index[item.FileDescriptor.Type][item.FileDescriptor.Group][item.FileDescriptor.LongInstance];

			if (Duplicates || (!files.Contains(item)))
			{
				files.Add(item);
			}

			//add it a second Time if it is a local Group
			if (pfd.Group == 0xffffffff)
			{
				if (!Index[item.FileDescriptor.Type].ContainsKey(localgroup))
				{
					Index[item.FileDescriptor.Type][localgroup] = new Dictionary<ulong, List<IScenegraphFileIndexItem>>();
				}

				if (!Index[item.FileDescriptor.Type][localgroup].ContainsKey(item.FileDescriptor.LongInstance))
				{
					Index[item.FileDescriptor.Type][localgroup][item.FileDescriptor.LongInstance] = new List<IScenegraphFileIndexItem>();
				}

				files = Index[item.FileDescriptor.Type][localgroup][item.FileDescriptor.LongInstance];

				if (Duplicates || (!files.Contains(item)))
				{
					files.Add(item);
				}
			}
		}

		/// <summary>
		/// Removes an Item from the Table
		/// </summary>
		/// <param name="item">The item you want to remove</param>
		public void RemoveItem(IScenegraphFileIndexItem item)
		{

			foreach (List<IScenegraphFileIndexItem> list in from types in Index.Values
															from groups in types.Values
															from instances in groups.Values
															where instances.Contains(item)
															select instances)
			{
				list.Remove(item);
			}
			PrepareForRemove(item.FileDescriptor);
		}

		// <summary>
		/// Returns all matching FileIndexItems for the passed type
		/// </summary>
		/// <param name="type">the Type of the Files</param>
		/// <param name="group">the Group of the Files</param>
		/// <param name="instance">Instance Number of the File</param>
		/// <returns>all FileIndexItems</returns>
		public IEnumerable<IScenegraphFileIndexItem> FindFileDiscardingHighInstance(
			uint type,
			uint grp,
			uint instance,
			Interfaces.Files.IPackageFile pkg
		)
		{
			return (from fi in Children
					from item in fi.FindFileDiscardingHighInstance(type, grp, instance, pkg)
					select item).Union(from types in Index
									   from groups in types.Value
									   from instances in groups.Value
									   from items in instances.Value
									   where types.Key == type
									   where groups.Key == grp
									   where (instances.Key & 0xffffffff) == instance
									   select items);
		}

		/// <summary>
		/// Returns all matching FileIndexItems
		/// </summary>
		/// <param name="pfd">The File you are looking for</param>
		/// <returns>all FileIndexItems</returns>
		public IEnumerable<IScenegraphFileIndexItem> FindFile(
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile pkg
		)
		{
			List<IScenegraphFileIndexItem> list = (from IScenegraphFileIndex fi in Children
												   from item in fi.FindFile(pfd, pkg)
												   select item).ToList();

			if (Index.ContainsKey(pfd.Type)
				&& Index[pfd.Type].ContainsKey(pfd.Group)
				&& Index[pfd.Type][pfd.Group].ContainsKey(pfd.LongInstance))
			{
				list.AddRange(Index[pfd.Type][pfd.Group][pfd.LongInstance]);
			}
			return list;
		}

		public void UpdateListOfAddedFilenames()
		{
			addedfilenames.Clear();
			Hashtable known = new Hashtable();

			addedfilenames = (from types in Index
							  from groups in types.Value
							  from instances in groups.Value
							  from item in instances.Value
							  select item.Package.SaveFileName.Trim().ToLower()).Distinct().ToList();

			foreach (IScenegraphFileIndex fi in Children)
			{
				fi.UpdateListOfAddedFilenames();
			}
		}

		public void WriteContentToConsole()
		{
			System.Windows.Forms.Form f = new System.Windows.Forms.Form();
			System.Windows.Forms.ListBox lb = new System.Windows.Forms.ListBox
			{
				Dock = System.Windows.Forms.DockStyle.Fill
			};
			f.Controls.Add(lb);

			foreach (IScenegraphFileIndex fi in Children)
			{
				if (fi is FileIndex index1)
				{
					index1.WriteContentToConsole();
				}
			}

			lb.Items.AddRange((from types in Index
							   from groups in types.Value
							   from instances in groups.Value
							   from item in instances.Value
							   select $"{item.FileDescriptor} in {item.Package.SaveFileName}").ToArray());

			f.ShowDialog();
			f.Dispose();
		}

		/// <summary>
		/// Returns all matching FileIndexItems for the passed type
		/// </summary>
		/// <param name="type">the Type of the Files</param>
		/// <param name="nolocal">true, if you don't want to get local Files (group=0xffffffff) returned</param>
		/// <returns>all FileIndexItems</returns>
		public IEnumerable<IScenegraphFileIndexItem> FindFile(uint type, bool nolocal)
		{
			return (from fi in Children
					from item in fi.FindFile(type, nolocal)
					select item).Union(from types in Index
									   from groups in types.Value
									   from instances in groups.Value
									   from item in instances.Value
									   where types.Key == type
									   where !nolocal || groups.Key != Data.MetaData.LOCAL_GROUP
									   select item);
		}

		/// <summary>
		/// Returns all matching FileIndexItems for the passed type
		/// </summary>
		/// <param name="type">the Type of the Files</param>
		/// <param name="group">the Group of the Files</param>
		/// <param name="instance">Instance Number of the File</param>
		/// <returns>all FileIndexItems</returns>
		public IEnumerable<IScenegraphFileIndexItem> FindFile(
			uint type,
			uint group,
			ulong instance,
			Interfaces.Files.IPackageFile pkg
		)
		{
			Packages.PackedFileDescriptor pfd =
				new Packages.PackedFileDescriptor
				{
					Group = group,
					Type = type,
					LongInstance = instance
				};

			return FindFile(pfd, pkg);
		}

		/// <summary>
		/// Returns all matching FileIndexItems for the passed type
		/// </summary>
		/// <param name="type">the Type of the Files</param>
		/// <param name="grp">the Group of the Files</param>
		/// <returns>all FileIndexItems</returns>
		public IEnumerable<IScenegraphFileIndexItem> FindFile(uint type, uint grp)
		{
			return (from fi in Children
					from item in fi.FindFile(type, grp)
					select item).Union(from types in Index
									   from groups in types.Value
									   from instances in groups.Value
									   from item in instances.Value
									   where types.Key == type
									   where groups.Key == grp
									   select item);
		}

		/// <summary>
		/// Returns all matching FileIndexItems while Ignoring the Group
		/// </summary>
		/// <param name="pfd">The File you are looking for</param>
		/// <returns>all FileIndexItems</returns>
		public IEnumerable<IScenegraphFileIndexItem> FindFileDiscardingGroup(
			Interfaces.Files.IPackedFileDescriptor pfd
		)
		{
			return FindFileDiscardingGroup(pfd.Type, pfd.LongInstance);
		}

		/// <summary>
		/// Returns all matching FileIndexItems for the passed type
		/// </summary>
		/// <param name="type">the Type of the Files</param>
		/// <param name="instance">Instance Number of the File</param>
		/// <returns>all FileIndexItems</returns>
		public IEnumerable<IScenegraphFileIndexItem> FindFileDiscardingGroup(
			uint type,
			ulong instance
		)
		{
			return (from fi in Children
					from item in fi.FindFileDiscardingGroup(type, instance)
					select item).Union(from types in Index
									   from groups in types.Value
									   from instances in groups.Value
									   from item in instances.Value
									   where types.Key == type
									   where instances.Key == instance
									   select item);
		}

		/// <summary>
		/// Return all matching FileIndexItems (by Instance)
		/// </summary>
		/// <param name="pfd">The File you are looking for</param>
		/// <returns>all FileIndexItems</returns>
		public IEnumerable<IScenegraphFileIndexItem> FindFileByInstance(ulong instance)
		{
			return (from fi in Children
					from item in fi.FindFileByInstance(instance)
					select item).Union(from types in Index
									   from groups in types.Value
									   from instances in groups.Value
									   from item in instances.Value
									   where instances.Key == instance
									   select item);
		}

		/// <summary>
		/// Return all matching FileIndexItems (by Instance)
		/// </summary>
		/// <param name="grp">The Group you are looking for</param>
		/// <param name="instance">The instance you are looking for</param>
		/// <returns>all FileIndexItems</returns>
		public IEnumerable<IScenegraphFileIndexItem> FindFileByGroupAndInstance(
			uint grp,
			ulong instance
		)
		{
			return (from fi in Children
					from item in fi.FindFileByGroupAndInstance(grp, instance)
					select item).Union(from types in Index
									   from groups in types.Value
									   from instances in groups.Value
									   from item in instances.Value
									   where groups.Key == grp
									   where instances.Key == instance
									   select item);
		}

		/// <summary>
		/// Return all matching FileIndexItems (by Instance)
		/// </summary>
		/// <param name="grp">The Group you are looking for</param>
		/// <returns>all FileIndexItems</returns>
		public IEnumerable<IScenegraphFileIndexItem> FindFileByGroup(uint grp)
		{
			return (from fi in Children
					from item in fi.FindFileByGroup(grp)
					select item).Union(from types in Index
									   from groups in types.Value
									   from instances in groups.Value
									   from item in instances.Value
									   where groups.Key == grp
									   select item);
		}

		/// <summary>
		/// Looks for a File based on the Filename
		/// </summary>
		/// <param name="filename">The name of the File (applies only to Scenegraph Resources)</param>
		/// <param name="type">The Type of the File you are looking for</param>
		/// <param name="defgroup">If the Filename has no group Hash, use this one</param>
		/// <param name="betolerant">
		/// set true if you want to enable a
		/// fallback Algorithm in case of the precice Search failing
		/// </param>
		/// <returns>The first matching File or null if none</returns>
		public IScenegraphFileIndexItem FindFileByName(
			string filename,
			uint type,
			uint defgroup,
			bool betolerant
		)
		{
			Interfaces.Files.IPackedFileDescriptor pfd =
				ScenegraphHelper.BuildPfd(filename, type, defgroup);
			IScenegraphFileIndexItem ret = FindSingleFile(pfd, null, betolerant);

			if ((ret == null) && betolerant)
			{
				pfd.SubType = 0;
				ret = FindSingleFile(pfd, null, betolerant);
			}

			return ret;
		}

		/// <summary>
		/// Looks for a File based on the Filename
		/// </summary>
		/// <param name="pfd">The FileDescriptor</param>
		/// <param name="betolerant">
		/// set true if you want to enable a
		/// fallback Algorithm in case of the precice Search failing
		/// </param>
		/// <returns>The first matching File or null if none</returns>
		public IScenegraphFileIndexItem FindSingleFile(
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile pkg,
			bool betolerant
		)
		{
			return FindFile(pfd, pkg).FirstOrDefault()
					?? (from grp in ALTERNATIVE_GROUPS // check alternative groups
						from item in FindFile(pfd.Type, grp, pfd.LongInstance, pkg)
						select item).FirstOrDefault()
					?? FindFileDiscardingGroup(pfd).FirstOrDefault(); // check for any file with the instance
		}

		/// <summary>
		/// Sort the Files in this type ascending by instance value
		/// </summary>
		/// <param name="files">The Files you want to sort</param>
		public IEnumerable<IScenegraphFileIndexItem> Sort(IEnumerable<IScenegraphFileIndexItem> files)
		{
			return files.OrderBy(item => item.FileDescriptor.LongInstance);
		}

		/// <summary>
		/// Remove the trace of a Package from the FileTable
		/// </summary>
		/// <param name="pkg"></param>
		public void ClosePackage(Interfaces.Files.IPackageFile pkg)
		{
			if (pkg == null)
			{
				return;
			}

			string flname = pkg.FileName;
			pkg.Close(true);

			if (flname == null)
			{
				return;
			}

			addedfilenames.Remove(flname.Trim().ToLower());
		}

		/// <summary>
		/// Remove a FileItem from the Tree when it is closed
		/// </summary>
		/// <param name="sender"></param>
		private void ClosedDescriptor(
			Interfaces.Files.IPackedFileDescriptor sender
		)
		{
			///
			/// TODO: This might be critical! Maybe we need to send the parent package along
			/// with this Data, otherwise to many Files could get removed!
			///
			foreach (IScenegraphFileIndexItem sgi in FindFile(sender, null))
			{
				RemoveItem(sgi);
			}
		}

		/// <summary>
		/// Creates a new FileIndexItem
		/// </summary>
		/// <param name="pfd"></param>
		/// <param name="pkg"></param>
		/// <returns></returns>
		public IScenegraphFileIndexItem CreateFileIndexItem(
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile pkg
		)
		{
			return new FileIndexItem(pfd, pkg);
		}

		/// <summary>
		/// Creates a new FileIndex
		/// </summary>
		/// <param name="pfds"></param>
		/// <param name="package"></param>
		/// <returns></returns>
		public IScenegraphFileIndex CreateFileIndex(
			SimPe.Collections.IO.PackedFileDescriptors pfds,
			Interfaces.Files.IPackageFile package
		)
		{
			FileIndex fi = new FileIndex();
			if (pfds != null)
			{
				fi.AddIndexFromPfd(pfds, package);
			}

			return fi;
		}

		/// <summary>
		/// Clear Table and close all assigned Packages
		/// </summary>
		public void CloseAssignedPackages()
		{
			List<string> files = new List<string>(addedfilenames);
			addedfilenames.Clear();
			foreach (string file in files)
			{
				if (parent != null && parent.addedfilenames.Contains(file))
				{
					continue;
				}

				bool close = true;
				if (Children != null)
				{
					foreach (FileIndex fi in Children)
					{
						if (fi.addedfilenames.Contains(file))
						{
							close = false;
							break;
						}
					}
				}
				if (close)
				{
					Packages.StreamFactory.CloseStream(file);
				}
			}

			Clear();
		}

		#region Handle FileTableChains
		public bool Contains(Interfaces.Files.IPackageFile pkg)
		{
			return Contains(pkg.SaveFileName);
		}

		public bool Contains(string flname)
		{
			flname = flname.Trim().ToLower();
			return addedfilenames.Contains(flname) || Children.Any(fi => fi.Contains(flname));
		}

		public IScenegraphFileIndex AddNewChild()
		{
			FileIndex fi = new FileIndex();
			AddChild(fi);

			return fi;
		}

		public void AddChild(IScenegraphFileIndex cld)
		{
			if (!Children.Contains(cld))
			{
				if (cld is FileIndex index1)
				{
					index1.parent = this;
				}

				Children.Add(cld);
			}
		}

		public void ClearChilds()
		{
			Children.Clear();
		}

		public void RemoveChild(IScenegraphFileIndex cld)
		{
			int c = Children.Count;
			Children.Remove(cld);
			if (c != Children.Count)
			{
				if (cld is FileIndex index1)
				{
					index1.parent = null;
				}
			}
		}
		#endregion

		#region IDisposable Member

		public override void Dispose()
		{
			try
			{
				ClearChilds();
				Clear();
			}
			catch { }

			Index = null;
			oldindex = null;
			addedfilenames = null;
			oldnames = null;

			base.Dispose();
		}

		#endregion
	}
}
