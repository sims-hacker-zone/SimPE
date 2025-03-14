// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections;
using System.Collections.Generic;

using SimPe.Interfaces.Files;

namespace SimPe.Events
{
	/// <summary>
	/// Used whenever the content
	/// of a <see cref="Interfaces.Files.IPackedFileDescriptor"/> changed
	/// </summary>
	public delegate void PackedFileChanged(
		Interfaces.Files.IPackedFileDescriptor sender
	);

	/*/// <summary>
	/// Used whenever a <see cref="SimPe.Interfaces.Files.IPackedFileDescriptor"/> got closed
	/// </summary>
	public delegate void PackedFileClosed(SimPe.Interfaces.Files.IPackedFileDescriptor sender);*/

	#region Resource Events
	/// <summary>
	/// Fired when a Resource was changed by a ToolPlugin
	/// </summary>
	public delegate void ChangedResourceEvent(object sender, ResourceEventArgs e);

	/// <summary>
	/// Fired when a Resource was changed by a ToolPlugin and the Enabled state needs to be changed
	/// </summary>
	public delegate bool ChangeEnabledStateEvent(object sender, ResourceEventArgs e);

	/// <summary>
	/// Used by <see cref="ChangedResourceEvent"/>
	/// </summary>
	public class ResourceEventArgs
		: System.EventArgs,
			IEnumerable,
			Interfaces.Plugin.IToolResult
	{

		/// <summary>
		/// Create a new Isntance
		/// </summary>
		/// <param name="lp"></param>
		public ResourceEventArgs(LoadedPackage lp)
		{
			LoadedPackage = lp;
			Items = new List<ResourceContainer>();
		}

		/// <summary>
		/// Returns the stored List
		/// </summary>
		public List<ResourceContainer> Items
		{
			get;
		}

		/// <summary>
		/// Integer Indexer
		/// </summary>
		public ResourceContainer this[int index]
		{
			get => Items[index];
			set => Items[index] = value;
		}

		/// <summary>
		/// unsigned Integer Indexer
		/// </summary>
		public ResourceContainer this[uint index]
		{
			get => Items[(int)index];
			set => Items[(int)index] = value;
		}

		/// <summary>
		/// Returns the loaded package
		/// </summary>
		public LoadedPackage LoadedPackage
		{
			get;
		}

		/// <summary>
		/// true if the stored List is Empty
		/// </summary>
		public new bool Empty => Items.Count == 0;

		/// <summary>
		/// true, if at least one of the stored <see cref="ResourceContainer"/> has a valid Resource
		/// </summary>
		public bool HasResource
		{
			get
			{
				foreach (ResourceContainer r in Items)
				{
					if (r.HasResource)
					{
						return true;
					}
				}

				return false;
			}
		}

		/// <summary>
		/// true, if at least one of the stored <see cref="ResourceContainer"/> has a valid FileDescriptor
		/// </summary>
		public bool HasFileDescriptor
		{
			get
			{
				foreach (ResourceContainer r in Items)
				{
					if (r.HasFileDescriptor)
					{
						return true;
					}
				}

				return false;
			}
		}

		/// <summary>
		/// true, if at least one of the stored <see cref="ResourceContainer"/> has a valid Package
		/// </summary>
		public bool HasPackage
		{
			get
			{
				foreach (ResourceContainer r in Items)
				{
					if (r.HasPackage)
					{
						return true;
					}
				}

				return false;
			}
		}

		/// <summary>
		/// true, if a package was loaded
		/// </summary>
		public bool Loaded => LoadedPackage != null && LoadedPackage.Loaded;

		/// <summary>
		/// Number of stored Items
		/// </summary>
		public int Count => Items.Count;

		#region IEnumerable Member

		public IEnumerator GetEnumerator()
		{
			return Items.GetEnumerator();
		}

		#endregion

		#region IToolResult Member

		public bool ChangedPackage
		{
			get
			{
				foreach (ResourceContainer c in Items)
				{
					if (c.ChangedPackage)
					{
						return true;
					}
				}

				return false;
			}
		}

		public bool ChangedFile
		{
			get
			{
				foreach (ResourceContainer c in Items)
				{
					if (c.ChangedFile)
					{
						return true;
					}
				}

				return false;
			}
		}

		public bool ChangedAny => false;

		#endregion

		public List<IPackedFileDescriptor> GetDescriptors()
		{
			List<IPackedFileDescriptor> pfds =
				new List<IPackedFileDescriptor>();
			foreach (ResourceContainer e in Items)
			{
				if (e.HasFileDescriptor)
				{
					pfds.Add(e.Resource.FileDescriptor);
				}
			}
			return pfds;
		}
	}

	/// <summary>
	/// Used as Item in <see cref="ResourceEventArgs"/>
	/// </summary>
	public class ResourceContainer
		: Interfaces.Plugin.IToolResult,
			System.IDisposable
	{
		public ResourceContainer(
			Interfaces.Scenegraph.IScenegraphFileIndexItem item
		)
		{
			Resource = item;
			ChangedFile = false;
			ChangedPackage = false;
		}

		/// <summary>
		/// Returns the Resource
		/// </summary>
		public Interfaces.Scenegraph.IScenegraphFileIndexItem Resource
		{
			get; private set;
		}

		#region IToolResult Member

		public bool ChangedPackage
		{
			get; set;
		}

		public bool ChangedFile
		{
			get; set;
		}

		public bool ChangedAny => ChangedPackage || ChangedFile;

		#endregion

		public override int GetHashCode()
		{
			return Resource == null ? base.GetHashCode() : Resource.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}

			if (!(obj is ResourceContainer))
			{
				return false;
			}

			ResourceContainer e = (ResourceContainer)obj;

			if (e.Resource == null)
			{
				return Resource == null;
			}
			else if (Resource == null)
			{
				return false;
			}

			return e.Resource.Equals(Resource);
		}

		/// <summary>
		/// true if the stored Resource is accessible
		/// </summary>
		public bool HasResource => Resource != null;

		/// <summary>
		/// true if the FileDescriptor of the stored Resource is accessible
		/// </summary>
		public bool HasFileDescriptor => HasResource && Resource.FileDescriptor != null;

		/// <summary>
		/// true if the Package of the stored Resource is accessible
		/// </summary>
		public bool HasPackage => HasResource && Resource.Package != null;

		/// <summary>
		/// Returns the FileName of the store package (will never return null)
		/// </summary>
		public string FileName => !HasPackage ? "" : Resource.Package.FileName ?? "";

		#region IDisposable Member

		public void Dispose()
		{
			Resource = null;
		}

		#endregion
	}
	#endregion

	#region File Events
	/// <summary>
	/// Passed as Event Argument in <see cref="PackageFileLoadEvent"/>
	/// </summary>
	public class FileNameEventArg : System.EventArgs
	{
		public FileNameEventArg(string filename)
		{
			Cancel = false;
			FileName = filename;
		}

		public string FileName
		{
			get; set;
		}

		public bool Cancel
		{
			get; set;
		}
	}

	/// <summary>
	/// A function that can be executed when a new File has to be loaded
	/// </summary>
	public delegate void PackageFileLoadEvent(LoadedPackage sender, FileNameEventArg e);

	/// <summary>
	/// A function that can be executed when a new File has to be closed
	/// </summary>
	public delegate void PackageFileCloseEvent(
		LoadedPackage sender,
		FileNameEventArg e
	);

	/// <summary>
	/// A function that can be executed when a new File hwas loaded
	/// </summary>
	public delegate void PackageFileLoadedEvent(LoadedPackage sender);

	/// <summary>
	/// A function that can be executed when a File has to be saved
	/// </summary>
	public delegate void PackageFileSaveEvent(LoadedPackage sender, FileNameEventArg e);

	/// <summary>
	/// A function that can be executed when a File was saved
	/// </summary>
	public delegate void PackageFileSavedEvent(LoadedPackage sender);
	#endregion
}
