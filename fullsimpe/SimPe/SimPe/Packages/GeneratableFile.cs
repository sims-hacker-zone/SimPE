// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using SimPe.Interfaces.Files;
using SimPe.PackedFiles.Clst;

namespace SimPe.Packages
{
	/// <summary>
	/// Extends the Packges Files with writing Support
	/// </summary>
	public class GeneratableFile : ExtractableFile
	{
		/// <summary>
		/// Size of the Blocks written to the Filesystem
		/// </summary>
		private const uint BLOCKSIZE = 0x200;

		/// <summary>
		/// Cosntructor of the Class
		/// </summary>
		/// <param name="br">The BinaryReader representing the Package File</param>
		internal GeneratableFile(BinaryReader br)
			: base(br) { }

		internal GeneratableFile(string flname)
			: base(flname) { }

		/// <summary>
		/// Init the Clone for this Package
		/// </summary>
		/// <returns>An INstance of this Class</returns>
		protected override IPackageFile NewCloneBase()
		{
			GeneratableFile fl = new GeneratableFile((BinaryReader)null)
			{
				header = header
			};

			return fl;
		}

		/// <summary>
		/// Checks if the passed File is writable by the System
		/// </summary>
		/// <param name="flname">The FileName</param>
		/// <returns>true, if the File is writable</returns>
		public static bool CanWriteToFile(string flname, bool close)
		{
			if (!System.IO.File.Exists(flname))
			{
				return true;
			}

			StreamItem si = StreamFactory.UseStream(
				flname,
				FileAccess.ReadWrite
			);
			bool res = si.StreamState == StreamState.Opened;

			if (close && res)
			{
				si.Close();
			}

			return res;
		}

		/// <summary>
		/// Stores the internal reader to the passed File (IncrementalBuild() will be called!)
		/// </summary>
		/// <param name="flname">The Filename you want to save the Package to</param>
		/// <remarks>This is Experimental and might not work properly</remarks>
		public override void Save(string flname)
		{
			//can we write to the output File?
			if (!CanWriteToFile(flname, false))
			{
				Helper.ExceptionMessage(
					new Warning(
						"Changes cannot be saved!",
						@"""" + flname + @""" is write protected."
					)
				);
				return;
			}

			//can we write to the .bak File?
			if (Helper.WindowsRegistry.Config.AutoBackup)
			{
				if (!CanWriteToFile(GetBakFileName(flname), true))
				{
					Helper.ExceptionMessage(
						new Warning(
							"Changes cannot be saved!",
							@"""" + GetBakFileName(flname) + @""" is write protected."
						)
					);
					return;
				}
			}

			BeginUpdate();
			bool wasinfileindex = PackageMaintainer.Maintainer.FileIndex.Contains(
				flname
			);
			PackageMaintainer.Maintainer.RemovePackage(flname);
			try
			{
				//this.IncrementalBuild();
				MemoryStream ms = Build();
				Reader?.Close();

				Save(ms, flname);

				//this.reader =  new System.IO.BinaryReader(System.IO.File.OpenRead(flname));
				FileName = flname;
				type = PackageBaseType.Filename;

				OpenReader();
				CloseReader();
			}
			finally
			{
				ForgetUpdate();
				EndUpdate();

				if (wasinfileindex)
				{
					PackageMaintainer.Maintainer.SyncFileIndex(this);
				}

				FireSavedIndexEvent();
			}
		}

		/// <summary>
		/// Returns the suggested name for a .bak File
		/// </summary>
		/// <param name="flname">the initial filename</param>
		/// <returns>the suggested Backup Filename</returns>
		protected string GetBakFileName(string flname)
		{
			return Path.Combine(
				Path.GetDirectoryName(flname),
				Path.GetFileNameWithoutExtension(flname) + ".bak"
			);
			/*
			string dir = System.IO.Path.GetDirectoryName(flname);
			string stem = System.IO.Path.GetFileNameWithoutExtension(flname);
			string bakfile = System.IO.Path.Combine(dir, stem + ".bak");
			if (!System.IO.File.Exists(bakfile)) return bakfile;
			else
			{
				short i = 0;
				while (true)
				{
					bakfile = System.IO.Path.Combine(dir, stem + "." + Helper.HexString(i) + ".bak");
					if (!System.IO.File.Exists(bakfile)) return bakfile;
				}
			}
			*/
		}

		/// <summary>
		/// Compiles a new Package File from the currently stored Information
		/// </summary>
		/// <param name="ms">The Memory Stream you want to write</param>
		/// <param name="flname">Filename for the Package</param>
		protected void Save(MemoryStream ms, string flname)
		{
			StreamFactory.CloseStream(flname);

			string tmpfile = Path.GetTempFileName();
			try
			{
				// Try to save to a temp file
				FileStream fs = new FileStream(tmpfile, FileMode.Create);
				try
				{
					Save(ms, fs);
				}
				finally
				{
					fs.Close();
					fs.Dispose();
					fs = null;
				}

				// If the destination already exists...
				if (System.IO.File.Exists(flname))
				{
					// ...back up the current package content...
					if (Helper.WindowsRegistry.Config.AutoBackup)
					{
						string bakfile = GetBakFileName(flname);
						if (System.IO.File.Exists(bakfile))
						{
							System.IO.File.Delete(bakfile);
						}

						System.IO.File.Copy(flname, bakfile, true);
					}

					// ...and get rid
					System.IO.File.Delete(flname);
				}
			}
			catch (Exception ex)
			{
				System.IO.File.Delete(tmpfile);
				throw ex;
			}

			// At this point we have successfully written tmpfile and deleted flname
			// Rename the temp file to the destination
			System.IO.File.Move(tmpfile, flname);

			StreamFactory.UseStream(flname, FileAccess.Read);
		}

		/// <summary>
		/// Compiles a new Package File from the currently stored Information
		/// </summary>
		/// <param name="ms">The Memory Stream you want to write</param>
		/// <param name="fs">The Filestream you want to write the File to</param>
		protected void Save(MemoryStream ms, FileStream fs)
		{
			fs.Seek(0, SeekOrigin.Begin);
			fs.SetLength(0);
			byte[] b = ms.ToArray();
			//fs.Lock(0, reader.BaseStream.Length);
			fs.Write(b, 0, b.Length);
			//fs.Unlock(0, reader.BaseStream.Length);
		}

		/// <summary>
		/// This is used to enable SimPe to add compressed Resources
		/// </summary>
		void PrepareCompression()
		{
			if (fileindex == null)
			{
				return;
			}

			if (filelistfile != null)
			{
				return;
			}

			filelistfile = new Clst(
				Header.IndexType
			);
			filelist = new PackedFileDescriptor
			{
				Type = Data.FileTypes.CLST,
				LongInstance = 0x286B1F03,
				Group = (uint)Data.FileTypes.CLST
			};

			filelistfile.FileDescriptor = filelist;
			filelistfile.SynchronizeUserData();
			Add(filelist);
		}

		/// <summary>
		/// Compiles a new Package File from the currently stored Information
		/// </summary>
		/// <returns>The MemoryStream representing the new Package File</returns>
		public MemoryStream Build()
		{
			LockStream();
			OpenReader();
			MemoryStream ms = new MemoryStream(16384); // Fuck
													   // was MemoryStream(10000) : 10000 is odd , assuming bigger is faster is now 16kb
													   // But.. out of mem error can be caused by larger caches so increasing this may be not good
			BinaryWriter writer = new BinaryWriter(ms);

			//make sure we write the correct Version!
			if ((header.majorversion == 1) && (header.minorversion == 0))
			{
				header.minorversion = 1;
				header.majorversion = 1;
				filelist = null;
			}

			int oldcount = 0;
			if (Index != null)
			{
				oldcount = Index.Length;
			}

			//now save the stuff
			header.Save(writer);

			//now save the files
			List<IPackedFileDescriptor> tmpindex = new List<IPackedFileDescriptor>();
			List<bool> tmpcmp = new List<bool>();
			if (fileindex == null)
			{
				fileindex = new IPackedFileDescriptor[0];
			}

			PrepareCompression();

			foreach (PackedFileDescriptor pfd in fileindex)
			{
				pfd.Changed = false;

				//we write the filelist as last File
				if (pfd == filelist)
				{
					continue;
				}

				if (pfd.Type == Data.FileTypes.CLST)
				{
					continue;
				}

				if (pfd.MarkForDelete)
				{
					continue;
				}

				//PackedFileDescriptor newpfd = (PackedFileDescriptor)pfd.Clone();
				PackedFileDescriptor newpfd = pfd;

				PackedFile pf;
				if (pfd.MarkForReCompress)
				{
					try
					{
						if (pfd.HasUserdata)
						{
							pf = new PackedFile(PackedFile.Compress(pfd.UserData))
							{
								uncsize = (uint)pfd.UserData.Length
							};
						}
						else
						{
							byte[] data = ((PackedFile)Read(pfd)).UncompressedData;
							pf = new PackedFile(PackedFile.Compress(data))
							{
								uncsize = (uint)data.Length
							};
						}

						pf.size = pf.data.Length;
						pf.signature = Data.MetaData.COMPRESS_SIGNATURE;
						pf.headersize = 9;
						newpfd.size = pf.data.Length;
						newpfd.SetUserData(null, false);

						//recreate the FileList
						filelist = null;
					}
					catch (Exception ex)
					{
						pf = (PackedFile)Read(pfd);
						newpfd.size = pf.data.Length;
						newpfd.SetUserData(pfd.UserData, false);

						if (Helper.WindowsRegistry.Config.HiddenMode)
						{
							Helper.ExceptionMessage(ex);
						}
					}
				}
				else
				{
					pf = (PackedFile)Read(pfd);
					newpfd.size = pf.data.Length;
					newpfd.SetUserData(pfd.UserData, false);
				}

				newpfd.offset = (uint)writer.BaseStream.Position;
				newpfd.Changed = false;
				newpfd.MarkForReCompress = false;
				newpfd.fldata = pf;
				newpfd.WasCompressed = pf.IsCompressed;

				tmpcmp.Add(pf.IsCompressed);
				tmpindex.Add(newpfd);

				writer.Write(pf.data);
			}

			//Last Entry should be the Filelist
			WriteFileList(writer, ref tmpindex, tmpcmp);

			//create a new Index
			IPackedFileDescriptor[] myindex = new PackedFileDescriptor[tmpindex.Count];
			tmpindex.CopyTo(myindex);

			//write the hole index
			header.HoleIndex.Offset = 0;
			header.HoleIndex.Size = header.HoleIndex.ItemSize * 0;
			header.HoleIndex.Count = 0;
			holeindex = new HoleIndexItem[0];

			//write the packed Fileindex
			header.Index.Offset = (uint)writer.BaseStream.Position;
			header.Index.Size = header.Index.ItemSize * myindex.Length;
			header.Index.Count = myindex.Length;
			SaveIndex(writer, myindex);
			Index = myindex;

			//rewrite Header
			ms.Seek(0, SeekOrigin.Begin);
			header.Save(writer);

			ms.Seek(0, SeekOrigin.Begin);
			UnLockStream();
			CloseReader();

			FireIndexEvent();
			if (Index.Length < oldcount)
			{
				FireRemoveEvent();
			}
			else if (Index.Length > oldcount)
			{
				FireAddEvent();
			}

			return ms;
		}

		#region Index and Hole Writing

		/// <summary>
		/// Writes the Index to the Package File
		/// </summary>
		/// <param name="writer">The BinaryWriter to use</param>
		/// <param name="tmpcmp">the index you want to write</param>
		/// <param name="tmpindex">listing of the compressin state for each packed File</param>
		protected void WriteFileList(
			BinaryWriter writer,
			ref List<IPackedFileDescriptor> tmpindex,
			List<bool> tmpcmp
		)
		{
			if (filelist == null)
			{
				filelist = new PackedFileDescriptor
				{
					instance = 0x286B1F03,
					Group = (uint)Data.FileTypes.CLST,
					Type = Data.FileTypes.CLST
				};
			}

			//we use the fact, taht packed files that were altered by SimPe will not be compressed,
			//so we only need to delete entries in the Filelist that do not exist any longer. The Size
			//won't change!
			byte[] b = Read(filelist).UncompressedData;
			Clst fl =
				new Clst(filelist, this);
			if (filelist.MarkForDelete)
			{
				fl.Clear();
			}

			Clst newfl =
				new Clst(Header.IndexType)
				{
					FileDescriptor = filelist
				};

			for (int i = 0; i < tmpcmp.Count; i++)
			{
				if (tmpcmp[i])
				{
					int pos = fl.FindFile(tmpindex[i]);

					if (pos != -1) //the file did already exist, so the size did not change!
					{
						ClstItem fi = fl.Items[pos];
						newfl.Add(fi);
					}
					else //the file is new but compressed
					{
						//IPackedFile pf = this.Read((IPackedFileDescriptor)tmpindex[i]);
						ClstItem fi =
							new ClstItem(newfl.IndexType);
						PackedFileDescriptor pfd = (PackedFileDescriptor)tmpindex[i];
						fi.Type = pfd.Type;
						fi.Group = pfd.Group;
						fi.Instance = pfd.Instance;
						fi.SubType = pfd.SubType;
						fi.UncompressedSize = pfd.fldata.UncompressedSize;
						newfl.Add(fi);
					}
				}
			}

			//no compressed Files, so remove the (empty) Filelist
			if (newfl.Items.Length != 0)
			{
				//tmpindex[tmpindex.Length-1] = filelist;
				tmpindex.Add(filelist);

				newfl.SynchronizeUserData();
				filelist.offset = (uint)writer.BaseStream.Position;
				filelist.size = filelist.UserData.Length;
				writer.Write(filelist.UserData);
				filelist.Changed = false;
			}

			filelistfile = newfl;
		}

		/// <summary>
		/// Writes the Index to the Package File
		/// </summary>
		/// <param name="writer">The BinaryWriter to use</param>
		/// <param name="tmpcmp">the index you want to write</param>
		protected void SaveIndex(BinaryWriter writer, IPackedFileDescriptor[] tmpindex)
		{
			long pos = writer.BaseStream.Position;
			foreach (PackedFileDescriptor item in tmpindex)
			{
				writer.Write((uint)item.Type);
				writer.Write(item.Group);
				writer.Write(item.Instance);
				if (
					Header.IsVersion0101
					&& (Header.IndexType == Data.IndexTypes.ptLongFileIndex)
				)
				{
					writer.Write(item.SubType);
				}

				writer.Write(item.Offset);
				writer.Write(item.Size);
			}

			header.Index.Size = (int)(writer.BaseStream.Position - pos);
		}

		/// <summary>
		/// Writes the HoleIndex to the Package File
		/// </summary>
		/// <param name="writer">The BinaryWriter to use</param>
		/// <param name="tmpcmp">the holeindex you want to write</param>
		protected void SaveHoleIndex(BinaryWriter writer, HoleIndexItem[] tmpindex)
		{
			long pos = writer.BaseStream.Position;
			foreach (HoleIndexItem item in tmpindex)
			{
				writer.Write(item.Offset);
				writer.Write(item.Size);
			}

			header.HoleIndex.Size = (int)(writer.BaseStream.Position - pos);
		}
		#endregion
	}
}
