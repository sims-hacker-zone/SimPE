// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.IO;

using SimPe.Data;
using SimPe.Events;
using SimPe.Interfaces.Files;
using SimPe.PackedFiles.Clst;

namespace SimPe.Packages
{
	/// <summary>
	/// Was the package opend by using a Filename?
	/// </summary>
	public enum PackageBaseType : byte
	{
		Stream = 0x00,
		Filename = 0x01,
	}

	/// <summary>
	/// Header of a .package File
	/// </summary>
	public class File : IPackageFile, IDisposable
	{
		/// <summary>
		/// The Binary reader that has opened the .Package file
		/// </summary>
		protected BinaryReader reader;

		/// <summary>
		/// How was the packaged opened
		/// </summary>
		protected PackageBaseType type;

		/// <summary>
		/// The Data of the Header
		/// </summary>
		protected HeaderData header;

		/// <summary>
		/// Contains the PackedFile representing the FileList
		/// </summary>
		protected PackedFileDescriptor filelist = null;

		/// <summary>
		/// Contains the FileListFile
		/// </summary>
		protected Clst filelistfile = null;

		/// <summary>
		/// Will contain the File Index
		/// </summary>
		protected IPackedFileDescriptor[] fileindex;

		/// <summary>
		/// Will contain the Hole Index
		/// </summary>
		protected HoleIndexItem[] holeindex;

		/// <summary>
		/// The Name of the current File
		/// </summary>
		string flname;

		/// <summary>
		/// true if you want to keep the FileHandle
		/// </summary>
		bool persistent;

		/// <summary>
		/// true if you want to keep the FileHandle
		/// </summary>
		public bool Persistent
		{
			get => persistent;
			set
			{
				/*if (!persistent && value) this.OpenReader();
				else if (persistent && !value) this.CloseReader();

				persistent = value; */
			}
		}

		public void ReloadReader()
		{
			if (Reader != null)
			{
				return;
			}

			if (type == PackageBaseType.Stream)
			{
				return;
			}

			StreamItem si = StreamFactory.UseStream(
				flname,
				FileAccess.Read
			); // seams to be no problem, is after all just a reader, not a writer
			   //StreamItem si = StreamFactory.UseStream(this.flname, System.IO.FileAccess.ReadWrite); // can be an issue with read onlu files, never used to be but suddenly is
			reader = new BinaryReader(si.FileStream);
		}

		/// <summary>
		/// Returns the Stream used to read the Package
		/// </summary>
		public BinaryReader Reader
		{
			get
			{
				if (reader != null)
				{
					if (reader.BaseStream == null)
					{
						reader = null;
					}
					else if (!reader.BaseStream.CanRead)
					{
						reader = null;
					}
				}
				return reader;
			}
		}

		/// <summary>
		/// Creates the Header Datastructure
		/// </summary>
		/// <param name="br">The Binary Reader you want to use</param>
		/// <remarks>
		/// The Reader must be positioned on the first byte of the Header
		/// (mostly that should be Index 0)
		/// </remarks>
		internal File(BinaryReader br)
		{
			pause = false;
			type = PackageBaseType.Stream;
			OpenByStream(br);
		}

		/// <summary>
		/// Dispose this Instance
		/// </summary>
		~File()
		{
			Close(true);
		}

		internal void Reload()
		{
			ReloadFromFile(flname);
		}

		/// <summary>
		/// Opens the Package File represented by a Stream
		/// </summary>
		/// <param name="br">The Stream</param>
		protected void OpenByStream(BinaryReader br)
		{
			LoadedCompressedState = false;
			NextFreeOffset = 0;
			fhg = 0;
			reader = br;
			if (header == null)
			{
				header = new HeaderData();
			}

			if (br != null)
			{
				if (br.BaseStream.Length > 0)
				{
					LockStream();
					header.Load(reader);
					LoadFileIndex();
					LoadHoleIndex();
					UnLockStream();
				}
			}
			CloseReader();
		}

		/// <summary>
		/// Creats a new Object based on the given File
		/// </summary>
		/// <param name="filename"></param>
		internal File(string filename)
		{
			pause = false;
			ReloadFromFile(filename);
		}

		internal void ClearFileIndex()
		{
			if (fileindex != null)
			{
				for (int i = fileindex.Length - 1; i >= 0; i--)
				{
					UnlinkResourceDescriptor(fileindex[i]);
				}
			}
			fileindex = new IPackedFileDescriptor[0];
		}

		/// <summary>
		/// Reload the Data from the File
		/// </summary>
		/// <param name="filename"></param>
		internal void ReloadFromFile(string filename)
		{
			// Not sure exactly what this does...
			persistent = Helper.WindowsRegistry.Config.KeepFilesOpen;
			StreamItem si = StreamFactory.UseStream(
				filename,
				FileAccess.Read
			);

			if (si.StreamState != StreamState.Removed)
			{
				si.FileStream.Seek(0, SeekOrigin.Begin);
				type = PackageBaseType.Filename;
				flname = filename;
				BinaryReader br = new BinaryReader(si.FileStream);
				OpenByStream(br);
			}
			else
			{
				type = PackageBaseType.Stream;
				OpenByStream(null);
			}
		}

		/*/// <summary>
		/// Synchronize the content with Data from the Filesystem
		/// </summary>
		internal void Synchronize()
		{
			if (type==PackageBaseType.Filename)
			{
				File newfl = new File(this.FileName);

				//Synchronize Descriptors
				foreach (SimPe.Packages.PackedFileDescriptor newpfd in newfl.Index)
				{
					SimPe.Packages.PackedFileDescriptor pfd = (SimPe.Packages.PackedFileDescriptor)this.FindFile(newpfd);
					if (pfd!=null)
					{
						pfd.Offset = newpfd.Offset;
						pfd.Size = newpfd.Size;
						pfd.Changed = false;
						pfd.MarkForDelete = false;
						pfd.UserData = null;
					}
					else this.Add(newpfd);
				}

				//Remove files that do not exist in the filesystem Version
				foreach (SimPe.Packages.PackedFileDescriptor pfd in Index)
				{
					SimPe.Packages.PackedFileDescriptor newpfd = (SimPe.Packages.PackedFileDescriptor)newfl.FindFile(pfd);
					if (newpfd==null) this.Remove(pfd);
				}
			}
		}*/

		/// <summary>
		/// Init the Clone for this Package
		/// </summary>
		/// <returns>An INstance of this Class</returns>
		protected virtual IPackageFile NewCloneBase()
		{
			File fl = new File((BinaryReader)null)
			{
				header = header
			};

			return fl;
		}

		/// <summary>
		/// Create a Clone of this Package File
		/// </summary>
		/// <returns>the new Package File</returns>
		public IPackageFile Clone()
		{
			File fl = (File)NewCloneBase();
			foreach (IPackedFileDescriptor pfd in Index)
			{
				IPackedFileDescriptor npfd =
					pfd.Clone();
				npfd.UserData = Read(pfd).UncompressedData;

				fl.Add(npfd);
			}

			fl.header = (HeaderData)Header.Clone();
			fl.LoadedCompressedState = LoadedCompressedState;
			if (filelist != null)
			{
				fl.filelist = (PackedFileDescriptor)
					fl.FindFile(filelist);
				fl.filelistfile = new Clst(
					fl.Header.IndexType
				);
			}

			return fl;
		}

		#region Lock handling
		protected void OpenReader()
		{
			if (persistent)
			{
				StreamItem si = StreamFactory.UseStream(flname, FileAccess.Read);
				si.SetFileAccess(FileAccess.Read);
				if (si.StreamState != StreamState.Removed)
				{
					reader = new BinaryReader(si.FileStream);
				}

				return;
			}
			if (type == PackageBaseType.Filename)
			{
				CloseReader();
				StreamItem si = StreamFactory.UseStream(flname, FileAccess.Read);
				if (si.StreamState == StreamState.Removed)
				{
					throw new Exception(
						"The File was moved or deleted whil SimPe was running.",
						new Exception("Unable to find " + FileName)
					);
				}

				reader = new BinaryReader(si.FileStream);
			}
		}

		protected void CloseReader()
		{
			if (persistent)
			{
				return;
			}

			if ((type == PackageBaseType.Filename) && (reader != null))
			{
				StreamItem si = StreamFactory.FindStreamItem(
					(FileStream)reader.BaseStream
				);
				si?.Close();

				reader = null;
			}
		}
		#endregion

		#region Stream Handling
		/// <summary>
		/// Locks the bas Stream
		/// </summary>
		public void LockStream()
		{
			//if (reader!=null)
			//	((System.IO.FileStream) reader.BaseStream).Lock(0, reader.BaseStream.Length);
		}

		/// <summary>
		/// Unlocks the BaseStream
		/// </summary>
		public void UnLockStream()
		{
			//if (reader!=null)
			//	((System.IO.FileStream) reader.BaseStream).Unlock(0, reader.BaseStream.Length);
		}
		#endregion

		#region Header Handling
		/// <summary>
		/// The Structural Data of the Header
		/// </summary>
		public IPackageHeader Header => header;

		#endregion

		#region FileIndex Handling
		/// <summary>
		/// True if the User has changed a PackedFile
		/// </summary>
		public bool HasUserChanges
		{
			get
			{
				if (Index == null)
				{
					return false;
				}

				foreach (IPackedFileDescriptor pfd in Index)
				{
					if (pfd.Changed)
					{
						return true;
					}
				}
				return false;
			}
		}

		/// <summary>
		/// Creates a new File descriptor
		/// </summary>
		/// <returns>the new File descriptor</returns>
		public IPackedFileDescriptor NewDescriptor(
			FileTypes type,
			uint subtype,
			uint group,
			uint instance
		)
		{
			PackedFileDescriptor pfd = new PackedFileDescriptor
			{
				type = type,
				subtype = subtype,
				group = group,
				instance = instance
			};
			//pfd.ChangedUserData += new SimPe.Events.PackedFileChanged(ResourceChanged);

			return pfd;
		}

		/// <summary>
		/// USed to discconect the Events for a ResourceDescrptor
		/// </summary>
		/// <param name="pfd"></param>
		protected void UnlinkResourceDescriptor(IPackedFileDescriptor pfd)
		{
			((PackedFileDescriptor)pfd).PackageInternalUserDataChange =
				null;
			pfd.DescriptionChanged -= new EventHandler(ResourceDescriptionChanged);
		}

		/// <summary>
		/// Temoves the described File from the Index
		/// </summary>
		/// <param name="pfd">A Packed File Descriptor</param>
		public void Remove(IPackedFileDescriptor pfd)
		{
			if (fileindex == null)
			{
				return;
			}

			ArrayList list = new ArrayList();
			for (int i = 0; i < fileindex.Length; i++)
			{
				if (fileindex[i] != pfd)
				{
					list.Add(fileindex[i]);
				}
			}

			PackedFileDescriptor[] newindex = new PackedFileDescriptor[list.Count];
			list.CopyTo(newindex);
			header.index.count = newindex.Length;
			fileindex = newindex;

			UnlinkResourceDescriptor(pfd);

			FireIndexEvent();
			FireRemoveEvent();
		}

		/// <summary>
		/// Removes all FileDescripotrs that are marked for Deletion
		/// </summary>
		public void RemoveMarked()
		{
			ArrayList list = new ArrayList();
			foreach (IPackedFileDescriptor pfd in fileindex)
			{
				if (!pfd.MarkForDelete)
				{
					list.Add(pfd);
				}
				else
				{
					(
						(PackedFileDescriptor)pfd
					).PackageInternalUserDataChange = null;
					pfd.DescriptionChanged -= new EventHandler(
						ResourceDescriptionChanged
					);
				}
			}

			IPackedFileDescriptor[] pfds =
				new IPackedFileDescriptor[list.Count];
			list.CopyTo(pfds);

			bool changed = fileindex.Length != fileindex.Length;
			fileindex = pfds;
			header.index.count = fileindex.Length;

			if (changed)
			{
				FireRemoveEvent();
				FireIndexEvent();
			}
		}

		/// <summary>
		/// Ads a new Descriptor to the Index
		/// </summary>
		/// <param name="type">The Type of the new File</param>
		/// <param name="subtype">The SubType/classID/ResourceID of the new File</param>
		/// <param name="group">The Group for the File</param>
		/// <param name="instance">The Instance of the FIle</param>
		public IPackedFileDescriptor Add(
			FileTypes type,
			uint subtype,
			uint group,
			uint instance
		)
		{
			PackedFileDescriptor pfd = new PackedFileDescriptor
			{
				Type = type,
				SubType = subtype,
				Group = group,
				Instance = instance
			};

			Add(pfd);

			return pfd;
		}

		/// <summary>
		/// Returns the next free offset in the File
		/// </summary>
		internal long NextFreeOffset
		{
			get; private set;
		}

		/// <summary>
		/// Copies the FileDescriptors form the passed Package to this one. The Method creats
		/// a Clone for each Descriptor, and read it' Userdata form the original package.
		/// </summary>
		/// <param name="package">The package that should get copied into this one</param>
		public void CopyDescriptors(IPackageFile package)
		{
			foreach (IPackedFileDescriptor pfd in package.Index)
			{
				IPackedFileDescriptor npfd = pfd.Clone();
				npfd.UserData = package.Read(pfd).UncompressedData;
				Add(npfd, true);
			}
		}

		/// <summary>
		/// Ads a list of Descriptors to the Index
		/// </summary>
		/// <param name="pfds">List of Descriptors</param>
		public void Add(IPackedFileDescriptor[] pfds)
		{
			foreach (IPackedFileDescriptor pfd in pfds)
			{
				Add(pfd);
			}
		}

		/// <summary>
		/// Ads a new Descriptor to the Index
		/// </summary>
		/// <param name="pfd">The PackedFile Descriptor</param>
		public void Add(IPackedFileDescriptor pfd)
		{
			Add(pfd, false);
		}

		/// <summary>
		/// Ads a new Descriptor to the Index
		/// </summary>
		/// <param name="pfd">The PackedFile Descriptor</param>
		public void Add(IPackedFileDescriptor pfd, bool isnew)
		{
			IPackedFileDescriptor[] newindex = null;
			if (fileindex != null)
			{
				newindex = new IPackedFileDescriptor[fileindex.Length + 1];
				fileindex.CopyTo(newindex, 0);
			}
			else
			{
				newindex = new IPackedFileDescriptor[1];
			}

			if (isnew)
			{
				((PackedFileDescriptor)pfd).offset = (uint)
					NextFreeOffset;
			}

			NextFreeOffset = Math.Max(
				NextFreeOffset,
				((PackedFileDescriptor)pfd).offset
					+ ((PackedFileDescriptor)pfd).size
			);
			newindex[newindex.Length - 1] = pfd;
			header.index.count = newindex.Length;
			fileindex = newindex;

			((PackedFileDescriptor)pfd).PackageInternalUserDataChange =
				new PackedFileChanged(ResourceChanged);
			pfd.DescriptionChanged += new EventHandler(ResourceDescriptionChanged);
			FireIndexEvent();
			FireAddEvent();
		}

		/// <summary>
		/// Returns the FileIndexItem for the given File
		/// </summary>
		/// <param name="item">Number of the File within the FileIndex (0-Based)</param>
		/// <returns>The FileIndexItem for this Entry</returns>
		public IPackedFileDescriptor GetFileIndex(uint item)
		{
			return (item >= fileindex.Length) || (item < 0) ? null : fileindex[item];
		}

		/// <summary>
		/// Returns or Changes the stored Fileindex
		/// </summary>
		public IPackedFileDescriptor[] Index
		{
			get
			{
				if (fileindex == null)
				{
					fileindex = new IPackedFileDescriptor[0];
				}

				return fileindex;
			}
			set
			{
				fileindex = value;
				header.Index.Count = fileindex.Length;
			}
		}

		/// <summary>
		/// Returns or Changes the stored Filelist
		/// </summary>
		public PackedFileDescriptor FileList
		{
			get => filelist;
			set
			{
				filelist = value;

				//get the FileListFile
				if (filelist != null)
				{
					filelistfile = new Clst(
						filelist,
						this
					);
				}
			}
		}

		/// <summary>
		/// Returns the FileListFile
		/// </summary>
		public Clst FileListFile
		{
			get
			{
				//get the FileListFile
				if ((filelist != null) && (filelist == null))
				{
					filelistfile = new Clst(
						filelist,
						this
					);
				}
				return filelistfile;
			}
		}

		/// <summary>
		/// Loads the FileIndex from the Package file
		/// </summary>
		protected void LoadFileIndex()
		{
			fileindex = new PackedFileDescriptor[header.index.Count];
			uint counter = 0;
			reader.BaseStream.Seek(header.index.offset, SeekOrigin.Begin);

			while (counter < fileindex.Length)
			{
				/*reader.BaseStream.Seek(	header.index.offset + counter*header.Index.ItemSize,
										System.IO.SeekOrigin.Begin );*/
				LoadFileIndexItem(counter);

				counter++;
			} //while

			//Load the File Index File
			if (FileList != null)
			{
				FileList = FileList;
			}
		}

		/// <summary>
		/// true if the Compressed State for this package was loaded
		/// </summary>
		public bool LoadedCompressedState
		{
			get; private set;
		}

		/// <summary>
		/// Reads the Compressed State for the package
		/// </summary>
		public void LoadCompressedState()
		{
			//Load the File Index File
			if (fileindex != null)
			{
				BeginUpdate();
				//setup the compression State
				foreach (PackedFileDescriptor pfd in fileindex)
				{
					pfd.WasCompressed = GetPackedFile(
						pfd,
						new byte[0]
					).IsCompressed;
				}

				//now delete all pending Events
				CloseReader();
				ForgetUpdate();
				EndUpdate();
				LoadedCompressedState = true;
			}
		}

		/// <summary>
		/// Loads the FileIndex from the Package file
		/// </summary>
		/// <param name="position">
		/// the number of the fileindex you want to load from the File (0-based).
		/// This Parameter will only effect the position of the Item within
		/// the File:fileindex Attribute. The data will be loaded from the current
		/// position of the File:reader.
		/// </param>
		protected void LoadFileIndexItem(uint position)
		{
			PackedFileDescriptor item = new PackedFileDescriptor();

			item.LoadFromStream(header, reader);
			item.PackageInternalUserDataChange = new PackedFileChanged(
				ResourceChanged
			);
			item.DescriptionChanged += new EventHandler(ResourceDescriptionChanged);

			NextFreeOffset = Math.Max(NextFreeOffset, item.offset + item.size);

			fileindex[position] = item;

			//remeber the filelist;
			if (item.Type == FileTypes.CLST)
			{
				filelist = item;
			}
		}
		#endregion

		#region HoleIndex Handling
		/// <summary>
		/// Returns the FileIndexItem for the given File
		/// </summary>
		/// <param name="item">Number of the File within the FileIndex (0-Based)</param>
		/// <returns>The FileIndexItem for this Entry</returns>
		public HoleIndexItem GetHoleIndex(uint item)
		{
			return holeindex[item];
		}

		/// <summary>
		/// Loads the HoleIndex from the Package file
		/// </summary>
		protected void LoadHoleIndex()
		{
			holeindex = new HoleIndexItem[header.hole.Count];
			uint counter = 0;
			if (reader == null)
			{
				OpenReader();
			}

			reader.BaseStream.Seek(header.hole.offset, SeekOrigin.Begin);

			while (counter < holeindex.Length)
			{
				/*reader.BaseStream.Seek(	header.hole.offset + counter*header.hole.ItemSize,
					System.IO.SeekOrigin.Begin );*/
				LoadHoleIndexItem(counter);

				counter++;
			} //while
		}

		/// <summary>
		/// Loads the HoleIndex from the Package file
		/// </summary>
		/// <param name="position">
		/// the number of the holeindex you want to load from the File (0-based).
		/// This Parameter will only affect the position of the Item within
		/// the File:holeindex Attribute. The data will be loaded from the current
		/// position of the File:reader.
		/// </param>
		protected void LoadHoleIndexItem(uint position)
		{
			HoleIndexItem item = new HoleIndexItem
			{
				offset = reader.ReadUInt32(),
				size = reader.ReadInt32()
			};

			holeindex[position] = item;
		}
		#endregion

		#region File Handling

		/// <summary>
		/// Returns the FileName of the Current Package
		/// </summary>
		public string FileName
		{
			get => flname;
			set
			{
				flname = value;
				fhg = 0;
			}
		}

		/// <summary>
		/// Returns the FileName of the Current Package
		/// </summary>
		public string SaveFileName => flname ?? "";

		uint fhg = 0;

		/// <summary>
		/// Returns the hash Group Value for this File
		/// </summary>
		public uint FileGroupHash
		{
			get
			{
				if (fhg == 0)
				{
					fhg =
						Hashes.FileGroupHash(
							Path.GetFileNameWithoutExtension(FileName)
						) | 0x7f000000
					;
				}

				return fhg;
			}
		}

		/// <summary>
		/// Reads the File specified by the given itemIndex
		/// </summary>
		/// <param name="item">the itemIndex for the File</param>
		/// <returns>The plain Content of the File</returns>
		public IPackedFile Read(uint item)
		{
			IPackedFileDescriptor pfd = fileindex[item];

			return Read(pfd);
		}

		/// <summary>
		/// the packed File Descriptor
		/// </summary>
		/// <param name="pfd"></param>
		/// <returns></returns>
		PackedFile GetPackedFile(IPackedFileDescriptor pfd, byte[] data)
		{
			PackedFile pf = new PackedFile(data);
			if (reader == null)
			{
				ReloadReader();
			}

			try
			{
				reader.BaseStream.Seek(pfd.Offset, SeekOrigin.Begin);
				pf.size = reader.ReadInt32();
				pf.signature = reader.ReadUInt16();
				byte[] dummy = reader.ReadBytes(3);
				pf.uncsize = (uint)(
					(dummy[0] << 0x10) | (dummy[1] << 0x08) | +dummy[2]
				);
				if (pf.Signature == MetaData.COMPRESS_SIGNATURE)
				{
					pf.headersize = 9;
				}

				if ((filelistfile != null) && (pfd.Type != FileTypes.CLST))
				{
					int pos = filelistfile.FindFile(pfd);
					if (pos != -1)
					{
						ClstItem fi =
							filelistfile.Items[pos];
						if (header.Version == 0x100000001)
						{
							pf.uncsize = fi.UncompressedSize;
						}
					}
				}
			}
			catch (Exception)
			{
				pf.size = 0;
				pf.data = new byte[0];
			}
			return pf;
		}

		/// <summary>
		/// the packed File Descriptor
		/// </summary>
		/// <param name="pfd"></param>
		/// <returns></returns>
		PackedFile GetStreamPackedFile(IPackedFileDescriptor pfd)
		{
			PackedFile pf = new PackedFile(reader.BaseStream);
			try
			{
				pf.datastart = pfd.Offset;
				pf.datasize = (uint)pfd.Size;
				reader.BaseStream.Seek(pfd.Offset, SeekOrigin.Begin);
				pf.size = reader.ReadInt32();
				pf.signature = reader.ReadUInt16();
				byte[] dummy = reader.ReadBytes(3);
				pf.uncsize = (uint)(
					(dummy[0] << 0x10) | (dummy[1] << 0x08) | +dummy[2]
				);
				if ( /*(pf.Size == pfd.Size) &&*/
					pf.Signature == MetaData.COMPRESS_SIGNATURE
				)
				{
					pf.headersize = 9;
				}

				if ((filelistfile != null) && (pfd.Type != FileTypes.CLST))
				{
					int pos = filelistfile.FindFile(pfd);
					if (pos != -1)
					{
						ClstItem fi =
							filelistfile.Items[pos];
						if (header.Version == 0x100000001)
						{
							pf.uncsize = fi.UncompressedSize;
						}
					}
				}
			}
			catch (Exception)
			{
				pf.size = 0;
				pf.data = new byte[0];
			}

			reader.BaseStream.Seek(pfd.Offset, SeekOrigin.Begin);
			return pf;
		}

		/// <summary>
		/// Returns the Stream that holds the given Resource
		/// </summary>
		/// <param name="pfd">The PackedFileDescriptor</param>
		/// <returns>The PackedFile containing Stream Infos</returns>
		public IPackedFile GetStream(IPackedFileDescriptor pfd)
		{
			return GetStreamPackedFile(pfd);
		}

		/// <summary>
		/// Reads a File specified by a FileIndexItem
		/// </summary>
		/// <param name="pfd">The PackedFileDescriptor</param>
		/// <returns>The plain Content of the File</returns>
		public IPackedFile Read(IPackedFileDescriptor pfd)
		{
			if (pfd.HasUserdata) //Deliver Userdefined Data
			{
				IPackedFile pf = new PackedFile(pfd.UserData);
				return pf;
			}
			else //no Userdefine data available
			{
				lock (this)
				{
					#region Reload Stream
					OpenReader();

					if (reader == null)
					{
						return new PackedFile(new byte[0]);
					}

					if (reader.BaseStream == null)
					{
						CloseReader();
						return new PackedFile(new byte[0]);
					}
					#endregion

					LockStream();
					reader.BaseStream.Seek(pfd.Offset, SeekOrigin.Begin);

					byte[] data = pfd.Size > 0 ? reader.ReadBytes(pfd.Size) : (new byte[0]);

					PackedFile pf = GetPackedFile(pfd, data);

					UnLockStream();
					CloseReader();
					return pf;
				}
			} // if HasUserdata
		}

		/// <summary>
		/// Returns a List ofa all Files matching the passed type
		/// </summary>
		/// <param name="type">Type you want to look for</param>
		/// <returns>A List of Files</returns>
		public IPackedFileDescriptor[] FindFiles(FileTypes type)
		{
			ArrayList list = new ArrayList();

			if (fileindex != null)
			{
				for (int i = 0; i < fileindex.Length; i++)
				{
					IPackedFileDescriptor pfd = fileindex[i];
					if (pfd.Type == type)
					{
						list.Add(pfd);
					}
				}
			}

			IPackedFileDescriptor[] ret = new IPackedFileDescriptor[list.Count];
			list.CopyTo(ret);
			return ret;
		}

		/// <summary>
		/// Returns a List ofa all Files matching the passed group
		/// </summary>
		/// <param name="group">Group you want to look for</param>
		/// <returns>A List of Files</returns>
		public IPackedFileDescriptor[] FindFilesByGroup(uint group)
		{
			ArrayList list = new ArrayList();

			if (fileindex != null)
			{
				for (int i = 0; i < fileindex.Length; i++)
				{
					IPackedFileDescriptor pfd = fileindex[i];
					if (pfd.Group == group)
					{
						list.Add(pfd);
					}
				}
			}

			IPackedFileDescriptor[] ret = new IPackedFileDescriptor[list.Count];
			list.CopyTo(ret);
			return ret;
		}

		/// <summary>
		/// Returns all Files that could contain a RCOL with the passed Filename
		/// </summary>
		/// <param name="filename">The Filename you are looking for</param>
		/// <returns>List of matching Files</returns>
		/// <remarks>Removes Forced Relocation Strings like #0x12345678!</remarks>
		public IPackedFileDescriptor[] FindFile(string filename)
		{
			filename = Hashes.StripHashFromName(filename);
			uint inst = Hashes.InstanceHash(filename);
			uint st = Hashes.SubTypeHash(filename);

			IPackedFileDescriptor[] ret = FindFile(st, inst);
			if (ret.Length == 0)
			{
				ret = FindFile(0, inst);
			}

			return ret;
		}

		/// <summary>
		/// Returns all Files that could contain a RCOL with the passed Filename
		/// </summary>
		/// <param name="filename">The Filename you are looking for</param>
		/// <returns>List of matching Files</returns>
		public IPackedFileDescriptor[] FindFile(string filename, FileTypes type)
		{
			filename = Hashes.StripHashFromName(filename);
			uint inst = Hashes.InstanceHash(filename);
			uint st = Hashes.SubTypeHash(filename);

			IPackedFileDescriptor[] ret = FindFile(type, st, inst);
			if (ret.Length == 0)
			{
				ret = FindFile(type, 0, inst);
			}

			return ret;
		}

		/// <summary>
		/// Returns the first File matching
		/// </summary>
		/// <param name="subtype">SubType you want to look for</param>
		/// <returns>The descriptor for the matching Dile or null</returns>
		public IPackedFileDescriptor[] FindFile(uint subtype, uint instance)
		{
			ArrayList list = new ArrayList();

			foreach (IPackedFileDescriptor pfd in fileindex)
			{
				if ((pfd.Instance == instance) && (pfd.SubType == subtype))
				{
					list.Add(pfd);
				}
			}

			IPackedFileDescriptor[] ret = new IPackedFileDescriptor[list.Count];
			list.CopyTo(ret);
			return ret;
		}

		/// <summary>
		/// Returns the first File matching
		/// </summary>
		/// <param name="type">Type you want to look for</param>
		/// <returns>The descriptor for the matching Dile or null</returns>
		public IPackedFileDescriptor[] FindFile(FileTypes type, uint subtype, uint instance)
		{
			ArrayList list = new ArrayList();

			if (fileindex != null)
			{
				foreach (IPackedFileDescriptor pfd in fileindex)
				{
					if (
						(pfd.Type == type)
						&& (pfd.Instance == instance)
						&& (pfd.SubType == subtype)
					)
					{
						list.Add(pfd);
					}
				}
			}

			IPackedFileDescriptor[] ret = new IPackedFileDescriptor[list.Count];
			list.CopyTo(ret);
			return ret;
		}

		/// <summary>
		/// Returns the first File matching
		/// </summary>
		/// <param name="pfd">Type you want to look for</param>
		/// <returns>The descriptor for the matching Dile or null</returns>
		public IPackedFileDescriptor FindFile(
			IPackedFileDescriptor pfd
		)
		{
			return FindFile(pfd.Type, pfd.SubType, pfd.Group, pfd.Instance);
		}

		/// <summary>
		/// Returns the first File matching
		/// </summary>
		/// <param name="type">Type you want to look for</param>
		/// <returns>The descriptor for the matching Dile or null</returns>
		public IPackedFileDescriptor FindFile(
			FileTypes type,
			uint subtype,
			uint group,
			uint instance
		)
		{
			if (fileindex != null)
			{
				foreach (IPackedFileDescriptor pfd in fileindex)
				{
					if (
						(pfd.Type == type)
						&& (pfd.SubType == subtype)
						&& (pfd.Group == group)
						&& (pfd.Instance == instance)
					)
					{
						return pfd;
					}
				}
			}

			return null;
		}

		/// <summary>
		/// Returns the first File matching
		/// </summary>
		/// <param name="type">Type you want to look for</param>
		/// <returns>The descriptor for the matching Dile or null</returns>
		public IPackedFileDescriptor FindFileAnyGroup(
			FileTypes type,
			uint subtype,
			uint instance
		)
		{
			if (fileindex != null)
			{
				foreach (IPackedFileDescriptor pfd in fileindex)
				{
					if (
						(pfd.Type == type)
						&& (pfd.SubType == subtype)
						&& (pfd.Instance == instance)
					)
					{
						return pfd;
					}
				}
			}

			return null;
		}

		#endregion

		/// <summary>
		/// Close this Instance, leaving the FileDescripors valid
		/// </summary>
		public void Close()
		{
			Close(false);
		}

		/// <summary>
		/// Close this Instance
		/// </summary>
		/// <param name="total">true, if the FileDescriptors should be marked invalid</param>
		public void Close(bool total)
		{
			Reader?.Close();

			if (total)
			{
				if (Index != null)
				{
					foreach (IPackedFileDescriptor pfd in Index)
					{
						pfd?.MarkInvalid();
					}
				}
			}

			if (PackageMaintainer.Maintainer.FileIndex != null)
			{
				if (
					PackageMaintainer.Maintainer.FileIndex.Contains(
						SaveFileName
					)
				)
				{
					PackageMaintainer.Maintainer.FileIndex.Clear();
				}
			}
		}

		/// <summary>
		/// Converts the given Char Array into a String
		/// </summary>
		/// <param name="array">The Char Array</param>
		/// <returns>The String represented by the Chars stored in the Array</returns>
		public string CharArrayToString(char[] array)
		{
			string s = "";
			foreach (char c in array)
			{
				s += c.ToString();
			}

			return s;
		}

		/// <summary>
		/// Create a new GeneratableFile
		/// </summary>
		/// <param name="flname"></param>
		/// <returns></returns>
		public static GeneratableFile LoadFromFile(string flname)
		{
			return PackageMaintainer.Maintainer.LoadPackageFromFile(flname, false);
		}

		/// <summary>
		/// Create a new GeneratableFile
		/// </summary>
		/// <param name="flname"></param>
		/// <param name="sync">true, if the content should be synced with the FileSystem</param>
		/// <returns></returns>
		public static GeneratableFile LoadFromFile(string flname, bool sync)
		{
			return PackageMaintainer.Maintainer.LoadPackageFromFile(flname, sync);
		}

		/// <summary>
		/// Create a new File
		/// </summary>
		/// <param name="flname"></param>
		/// <returns></returns>
		public static GeneratableFile LoadFromStream(BinaryReader br)
		{
			return new GeneratableFile(br);
		}

		/// <summary>
		/// Creates a new Empty Package File
		/// </summary>
		/// <returns></returns>
		public static GeneratableFile CreateNew()
		{
			GeneratableFile gf = LoadFromStream(
				new BinaryReader(
					LoadFromStream(null).Build()
				)
			);
			if (UserVerification.HaveValidUserId)
			{
				gf.Header.Created = UserVerification.UserId;
			}

			return gf;
		}

		public override int GetHashCode()
		{
			return FileName == null ? Reader == null ? base.GetHashCode() : Reader.GetHashCode() : FileName.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj == null || !(obj is File))
			{
				return false;
			}

			File f = (File)obj;

			if (f.FileName == null)
			{
				//if (this.FileName!=null) return false;
				return base.Equals(obj);
			}
			else if (FileName == null)
			{
				return false;
			}

			return f.FileName == null && FileName == null
				? Reader == null ? f.Reader == null : f.Reader != null && Reader.Equals(f.Reader)
				: FileName.Trim().ToLower() == f.FileName.Trim().ToLower();
		}

		#region Events
		bool pause;
		bool indexevent,
			addevent,
			remevent;

		protected void FireAddEvent()
		{
			if (pause)
			{
				addevent = true;
				return;
			}
			if (AddedResource != null)
			{
				AddedResource(this, new EventArgs());
			}
		}

		protected void FireRemoveEvent()
		{
			if (pause)
			{
				remevent = true;
				return;
			}
			if (RemovedResource != null)
			{
				RemovedResource(this, new EventArgs());
			}
		}

		protected void FireIndexEvent()
		{
			FireIndexEvent(new EventArgs());
		}

		protected void FireSavedIndexEvent()
		{
			if (SavedIndex != null)
			{
				SavedIndex(this, new EventArgs());
			}
		}

		protected void FireIndexEvent(EventArgs e)
		{
			if (pause)
			{
				indexevent = true;
				return;
			}
			if (IndexChanged != null)
			{
				IndexChanged(this, e);
			}
		}

		public void BeginUpdate()
		{
			if (pause)
			{
				return;
			}

			ForgetUpdate();
		}

		public void ForgetUpdate()
		{
			indexevent = false;
			addevent = false;
			remevent = false;
			pause = true;
			if (Index != null)
			{
				foreach (IPackedFileDescriptor pfd in Index)
				{
					pfd?.BeginUpdate();
				}
			}
		}

		public void EndUpdate()
		{
			if (!pause)
			{
				return;
			}

			pause = false;
			foreach (IPackedFileDescriptor pfd in Index)
			{
				pfd.EndUpdate();
			}

			if ((remevent || indexevent || addevent) && EndedUpdate != null)
			{
				EndedUpdate(this, new EventArgs());
			}

			if (indexevent)
			{
				FireIndexEvent();
			}

			if (remevent)
			{
				FireRemoveEvent();
			}

			if (addevent)
			{
				FireAddEvent();
			}
		}

		/// <summary>
		/// Called whenever the content represented by this descripotr was changed
		/// </summary>
		public event PackedFileChanged ChangedResource;

		/// <summary>
		/// Pass the Event fired by one of the attached Resources (pfds) to assigned listeners
		/// </summary>
		/// <param name="sender"></param>
		void ResourceChanged(IPackedFileDescriptor sender)
		{
			if (ChangedResource != null)
			{
				ChangedResource(sender);
			}
		}

		/// <summary>
		/// Triggered whenever EndUpdate is called an the package was changed
		/// </summary>
		public event EventHandler EndedUpdate;

		/// <summary>
		/// Triggered whenever the Content of the Package was changed
		/// </summary>
		public event EventHandler IndexChanged;

		/// <summary>
		/// Triggered whenever the Complete ResourceList should get reloaded
		/// </summary>
		public event EventHandler SavedIndex;

		/// <summary>
		/// Triggered whenever a new Resource was added
		/// </summary>
		public event EventHandler AddedResource;

		/// <summary>
		/// Triggered whenever a Resource was Removed
		/// </summary>
		public event EventHandler RemovedResource;

		/// <summary>
		/// Fired when a Description gets Changed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ResourceDescriptionChanged(object sender, EventArgs e)
		{
			FireIndexEvent(e);
		}
		#endregion

		public virtual void Save()
		{
			Save(FileName);
		}

		public virtual void Save(string filename)
		{
			throw new Exception(
				"Can't save a object of Type "
					+ GetType().Namespace
					+ "."
					+ GetType().Name
			);
		}

		/// <summary>
		/// Determine if the <paramref name="pfd"/> is in the fileindex
		/// </summary>
		/// <param name="pfd">File you want to look for</param>
		/// <returns><paramref name="pfd"/> if found, <value>null</value> otherwise</returns>
		public IPackedFileDescriptor FindExactFile(
			IPackedFileDescriptor pfd
		)
		{
			if (fileindex != null)
			{
				foreach (IPackedFileDescriptor ipfd in fileindex)
				{
					if (ipfd == pfd)
					{
						return pfd;
					}
				}
			}

			return null;
			//return FindExactFile(pfd.Type, pfd.SubType, pfd.Group, pfd.Instance, pfd.Offset);
		}

		/// <summary>
		/// Returns the first File matching
		/// </summary>
		/// <param name="type">Type you want to look for</param>
		/// <returns>The descriptor for the matching Dile or null</returns>
		public IPackedFileDescriptor FindExactFile(
			FileTypes type,
			uint subtype,
			uint group,
			uint instance,
			uint offset
		)
		{
			if (fileindex != null)
			{
				if (fileindex != null)
				{
					foreach (IPackedFileDescriptor pfd in fileindex)
					{
						if (
							(pfd.Type == type)
							&& (pfd.SubType == subtype)
							&& (pfd.Group == group)
							&& (pfd.Instance == instance)
							&& (pfd.Offset == offset)
						)
						{
							return pfd;
						}
					}
				}
			}

			return null;
		}

		#region IDisposable Member

		public void Dispose()
		{
			Close(true);
			if (fileindex != null)
			{
				ClearFileIndex();
			}

			/*if (this is SimPe.Packages.GeneratableFile)
				PackageMaintainer.Maintainer.RemovePackage((SimPe.Packages.GeneratableFile)this);*/

			fileindex = null;
			holeindex = null;
		}

		#endregion
	}
}
