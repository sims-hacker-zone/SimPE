// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;

using SimPe.Data;

namespace SimPe.Interfaces.Scenegraph
{
	/// <summary>
	/// This is a Index over all Files found in all Packages
	/// </summary>
	public interface IScenegraphFileIndex
	{
		// <summary>
		/// Creates a clone of this Object
		/// </summary>
		/// <returns>The Clone</returns>
		IScenegraphFileIndex Clone();

		/// <summary>
		/// Make sure the FileTable is empty
		/// </summary>
		void Clear();

		/// <summary>
		/// Forces a Reload of the FileIndex
		/// </summary>
		/// <remarks>
		/// Use Load() if you want to make sure that the FileIndex is available,
		/// use ForceReload() if you want to reload the FileIndex (for example,
		/// becuase the Files changed)
		/// </remarks>
		void ForceReload();

		/// <summary>
		/// Indicates the File Index was loaded
		/// </summary>
		event EventHandler FILoad;
		void OnFILoad(object sender, EventArgs e);

		/// <summary>
		/// Load the FileIndex if it is not available yet
		/// </summary>
		/// <remarks>
		/// Use Load() if you want to make sure that the FileIndex is available,
		/// use ForceReload() if you want to reload the FileIndex (for example,
		/// becuase the Files changed)
		/// </remarks>
		void Load();

		/// <summary>
		/// Add all Files stored in all the packages found in the passed Folder
		/// </summary>
		/// <param name="path">The Folder you want to scan</param>
		void AddIndexFromFolder(string path);

		/// <summary>
		/// Add all Files stored in the passed package
		/// </summary>
		/// <param name="file">Name of the package File</param>
		/// <remarks>Updates the WaitingScreen Message</remarks>
		void AddIndexFromPackage(string file);

		/// <summary>
		/// Add all Files stored in the passed package
		/// </summary>
		/// <param name="package">The package File</param>
		/// <param name="overwrite">true, if the file should be
		/// added even if it already a Part of the FileIndex</param>
		void AddIndexFromPackage(
			Files.IPackageFile package,
			bool overwrite
		);

		/// <summary>
		/// Add all Files stored in the passed package
		/// </summary>
		/// <param name="package">The package File</param>
		///
		void AddIndexFromPackage(Files.IPackageFile package);

		/// <summary>
		/// Add all Files stored in the passed package
		/// </summary>
		/// <param name="package">The package File</param>
		/// <param name="type">Resources of this Type will get added</param>
		/// <param name="overwrite">true, if an existing Instance of that File should be overwritten</param>
		void AddTypesIndexFromPackage(
			Files.IPackageFile package,
			FileTypes type,
			bool overwrite
		);

		/// <summary>
		/// Add a Filedescriptor to the Index
		/// </summary>
		/// <param name="pfd">The Descriptor</param>
		/// <param name="package">The File</param>
		void AddIndexFromPfd(
			Files.IPackedFileDescriptor pfd,
			Files.IPackageFile package
		);

		/// <summary>
		/// Add a Filedescriptor to the Index
		/// </summary>
		/// <param name="pfd">The Descriptor</param>
		/// <param name="package">The File</param>
		/// <param name="localgroup">use this groupa as replacement for 0xffffffff</param>
		void AddIndexFromPfd(
			Files.IPackedFileDescriptor pfd,
			Files.IPackageFile package,
			uint localgroup
		);

		/// <summary>
		/// Used to Debug the Filetable
		/// </summary>
		void WriteContentToConsole();

		/// <summary>
		/// Recreates the List of added Filenames
		/// </summary>
		void UpdateListOfAddedFilenames();

		/// <summary>
		/// Clears the FileTable, and Closes all packages it did refern to
		/// </summary>
		void CloseAssignedPackages();

		/// <summary>
		/// Removes an Item from the Table
		/// </summary>
		/// <param name="item">The item you want to remove</param>
		void RemoveItem(IScenegraphFileIndexItem item);

		/// <summary>
		/// Return all matching FileIndexItems
		/// </summary>
		/// <param name="pfd">The File you are looking for</param>
		/// <returns>all FileIndexItems</returns>
		IEnumerable<IScenegraphFileIndexItem> FindFile(
			Files.IPackedFileDescriptor pfd,
			Files.IPackageFile pkg
		);

		/// <summary>
		/// Returns all matching FileIndexItems for the passed type
		/// </summary>
		/// <param name="type">the Type of the Files</param>
		/// <param name="nolocal">true, if you don't want to get local Files (group=0xffffffff) returned</param>
		/// <returns>all FileIndexItems</returns>
		IEnumerable<IScenegraphFileIndexItem> FindFile(FileTypes type, bool nolocal);

		/// <summary>
		/// Returns all matching FileIndexItems for the passed type
		/// </summary>
		/// <param name="type">the Type of the Files</param>
		/// <param name="group">the Group of the Files</param>
		/// <returns>all FileIndexItems</returns>
		IEnumerable<IScenegraphFileIndexItem> FindFile(FileTypes type, uint group);

		/// <summary>
		/// Return all matching FileIndexItems (by Instance)
		/// </summary>
		/// <param name="group">The Group you are looking for</param>
		/// <param name="instance">The instance you are looking for</param>
		/// <returns>all FileIndexItems</returns>
		IEnumerable<IScenegraphFileIndexItem> FindFileByGroupAndInstance(
			uint group,
			ulong instance
		);

		/// <summary>
		/// Returns all matching FileIndexItems for the passed type
		/// </summary>
		/// <param name="type">the Type of the Files</param>
		/// <param name="group">the Group of the Files</param>
		/// <param name="instance">Instance Number of the File</param>
		/// <returns>all FileIndexItems</returns>
		IEnumerable<IScenegraphFileIndexItem> FindFile(
			FileTypes type,
			uint group,
			ulong instance,
			Files.IPackageFile pkg
		);

		/// <summary>
		/// Returns all matching FileIndexItems for the passed type
		/// </summary>
		/// <param name="type">the Type of the Files</param>
		/// <param name="group">the Group of the Files</param>
		/// <param name="instance">Instance Number of the File</param>
		/// <returns>all FileIndexItems</returns>
		IEnumerable<IScenegraphFileIndexItem> FindFileDiscardingHighInstance(
			FileTypes type,
			uint group,
			uint instance,
			Files.IPackageFile pkg
		);

		/// <summary>
		/// Returns all matching FileIndexItems while Ignoring the Group
		/// </summary>
		/// <param name="pfd">The File you are looking for</param>
		/// <returns>all FileIndexItems</returns>
		IEnumerable<IScenegraphFileIndexItem> FindFileDiscardingGroup(
			Files.IPackedFileDescriptor pfd
		);

		/// <summary>
		/// Returns all matching FileIndexItems for the passed type
		/// </summary>
		/// <param name="type">the Type of the Files</param>
		/// <param name="instance">Instance Number of the File</param>
		/// <returns>all FileIndexItems</returns>
		IEnumerable<IScenegraphFileIndexItem> FindFileDiscardingGroup(FileTypes type, ulong instance);

		/// <summary>
		/// Return all matching FileIndexItems (by Instance)
		/// </summary>
		/// <param name="pfd">The File you are looking for</param>
		/// <returns>all FileIndexItems</returns>
		IEnumerable<IScenegraphFileIndexItem> FindFileByInstance(ulong instance);

		/// <summary>
		/// Return all matching FileIndexItems (by Instance)
		/// </summary>
		/// <param name="group">The Group you are looking for</param>
		/// <returns>all FileIndexItems</returns>
		IEnumerable<IScenegraphFileIndexItem> FindFileByGroup(uint group);

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
		IScenegraphFileIndexItem FindFileByName(
			string filename,
			FileTypes type,
			uint defgroup,
			bool betolerant
		);

		/// <summary>
		/// Looks for a File based on the Filename
		/// </summary>
		/// <param name="pfd">The FileDescriptor</param>
		/// <param name="betolerant">
		/// set true if you want to enable a
		/// fallback Algorithm in case of the precice Search failing
		/// </param>
		/// <returns>The first matching File or null if none</returns>
		IScenegraphFileIndexItem FindSingleFile(
			Files.IPackedFileDescriptor pfd,
			Files.IPackageFile pkg,
			bool betolerant
		);

		/// <summary>
		/// Sort the Files in this type ascending by instance value
		/// </summary>
		/// <param name="files">The Files you want to sort</param>
		IEnumerable<IScenegraphFileIndexItem> Sort(IEnumerable<IScenegraphFileIndexItem> files);

		/// <summary>
		/// Stores the current State of the FileIndex.
		///
		/// You can revert to the last stored state by calling RestoreLastState()
		/// </summary>
		void StoreCurrentState();

		/// <summary>
		/// Restores the last stored state (if one is available)
		/// </summary>
		void RestoreLastState();

		/// <summary>
		/// Creates a new FileIndexItem
		/// </summary>
		/// <param name="pfd"></param>
		/// <param name="pkg"></param>
		/// <returns></returns>
		IScenegraphFileIndexItem CreateFileIndexItem(
			Files.IPackedFileDescriptor pfd,
			Files.IPackageFile pkg
		);

		/// <summary>
		/// Remove the trace of a Package from the FileTable
		/// </summary>
		/// <param name="pkg"></param>
		void ClosePackage(Files.IPackageFile pkg);

		/// <summary>
		/// Returns the List of all Folders this FileIndex is processing
		/// </summary>
		List<FileTableItem> BaseFolders
		{
			get; set;
		}

		/// <summary>
		/// Returns true, if the FileTable is Loaded
		/// </summary>
		bool Loaded
		{
			get;
		}

		/// <summary>
		/// prevent PJSE FileTable from auto loading with SimPe FileTable
		/// </summary>
		bool AllowEvent
		{
			get; set;
		}

		#region FileTable Childs
		/// <summary>
		/// True, if this Package was already added to the FileTable (or one of its Childs)
		/// </summary>
		/// <param name="flname"></param>
		/// <returns></returns>
		bool Contains(Files.IPackageFile pkg);

		/// <summary>
		/// True, if this File was already added to the FileTable (or one of its Childs)
		/// </summary>
		/// <param name="flname"></param>
		/// <returns></returns>
		bool Contains(string flname);

		/// <summary>
		/// True if the Path was already added as a whole to the FileTable (or one of its Childs)
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		bool ContainsPath(string path);

		/// <summary>
		/// Creates a new FileIndex, adds it as a Child, and returns the new Instance
		/// </summary>
		/// <returns>A new, empty FileIndex</returns>
		IScenegraphFileIndex AddNewChild();

		/// <summary>
		/// Add a new FileIndex as a Child.
		/// </summary>
		/// <param name="cld">The Child Index</param>
		/// <remarks>Make sure, that you do not cretae circular dependecies! When
		/// searchin Resources, all Child FileTables will get search too, so
		/// keep the list small, otherwise you might increas searchtime!</remarks>
		void AddChild(IScenegraphFileIndex cld);

		/// <summary>
		/// Remove all Childs from this Instance
		/// </summary>
		void ClearChilds();

		/// <summary>
		/// Remove the passed Child from the list of Childs
		/// </summary>
		/// <param name="cld">The FileIndex you want to remove</param>
		void RemoveChild(IScenegraphFileIndex cld);
		#endregion
	}
}
