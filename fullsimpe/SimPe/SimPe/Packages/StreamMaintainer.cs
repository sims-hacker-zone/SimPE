// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.IO;

namespace SimPe.Packages
{
	/// <summary>
	/// State of a FileStream
	/// </summary>
	public enum StreamState : byte
	{
		/// <summary>
		/// The Stream is Opene
		/// </summary>
		Opened,

		/// <summary>
		/// The Stream is Closed
		/// </summary>
		Closed,

		/// <summary>
		/// The stream is not available
		/// </summary>
		Removed,
	}

	/// <summary>
	/// Contains one FIleStream
	/// </summary>
	public class StreamItem
	{

		/// <summary>
		/// Creates a new Instance
		/// </summary>
		/// <param name="fs">The FIlestream you want to use</param>
		internal StreamItem(FileStream fs)
		{
			SetFileStream(fs);
		}

		/// <summary>
		/// Returns the FIleStream
		/// </summary>
		public FileStream FileStream
		{
			get; private set;
		}

		/// <summary>
		/// Change the internal FileStream
		/// </summary>
		/// <param name="fs"></param>
		internal void SetFileStream(FileStream fs)
		{
			FileStream = fs;
		}

		/// <summary>
		/// Chnages the Permissions for this Stream
		/// </summary>
		/// <param name="fa">File Acces you need</param>
		/// <remarks>won't do anything if thhe Stream is null!</remarks>
		/// <returns>true if the FIleMode was changed</returns>
		public bool SetFileAccess(FileAccess fa)
		{
			if (FileStream == null)
			{
				return false;
			}

			switch (fa)
			{
				case FileAccess.Read:
				{
					if (FileStream.CanRead)
					{
						return true;
					}

					if (FileStream.CanWrite)
					{
						fa = FileAccess.ReadWrite;
					}

					break;
				}

				case FileAccess.Write:
				{
					if (FileStream.CanWrite)
					{
						return true;
					}

					if (FileStream.CanRead)
					{
						fa = FileAccess.ReadWrite;
					}

					break;
				}

				default:
				{
					if (FileStream.CanRead && FileStream.CanWrite)
					{
						return true;
					}

					break;
				}
			}

			try
			{
				if (StreamState == StreamState.Opened)
				{
					FileStream.Close();
				}

				string name = FileStream.Name;
				FileStream = null;
				FileStream = new FileStream(name, FileMode.OpenOrCreate, fa);
			}
			catch (Exception ex)
			{
				if (Helper.WindowsRegistry.HiddenMode)
				{
					Helper.ExceptionMessage("", ex);
				}

				return false;
			}
			return true;
		}

		/// <summary>
		/// Returns the current State of this Stream
		/// </summary>
		public StreamState StreamState => FileStream == null ? StreamState.Removed : FileStream.CanSeek ? StreamState.Opened : StreamState.Closed;

		/// <summary>
		/// Closes the Stream if opened
		/// </summary>
		public void Close()
		{
			if (FileStream != null)
			{
				FileStream.Close();
				FileStream.Dispose();
				FileStream = null;
			}
		}
	}

	/// <summary>
	/// Holds a list of all Streams SimPe did ever open.
	/// </summary>
	public class StreamFactory
	{
		internal static Hashtable streams;
		static ArrayList locked = new ArrayList();

		/// <summary>
		/// marks a stream locked, which means, that it cannot be closed
		/// </summary>
		/// <param name="filename"></param>
		/// <returns></returns>
		public static bool LockStream(string filename)
		{
			InitTable();
			filename = filename.Trim().ToLower();
			if (streams.ContainsKey(filename))
			{
				if (!locked.Contains(filename))
				{
					locked.Add(filename);
				}

				return true;
			}
			return false;
		}

		/// <summary>
		/// marks a stream unlocked, which means, that it can be closed
		/// </summary>
		/// <param name="filename"></param>
		/// <returns></returns>
		public static bool UnlockStream(string filename)
		{
			InitTable();
			filename = filename.Trim().ToLower();
			if (streams.ContainsKey(filename))
			{
				if (locked.Contains(filename))
				{
					locked.Remove(filename);
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Returns true, if the passed Stream is locked
		/// </summary>
		/// <param name="filename"></param>
		/// <param name="checkfiletable">true, if you want to check the FileTable for references (which counta s locked)</param>
		/// <returns></returns>
		public static bool IsLocked(string filename, bool checkfiletable)
		{
			filename = filename.Trim().ToLower();
			return locked.Contains(filename)
				|| (checkfiletable && FileTableBase.FileIndex.Contains(filename));
		}

		/// <summary>
		/// Unlocks all Streams
		/// </summary>
		public static void UnlockAll()
		{
			InitTable();
			foreach (string k in streams.Keys)
			{
				UnlockStream(k);
			}
		}

		public static void WriteToConsole()
		{
			InitTable();
			System.Windows.Forms.Form f = new System.Windows.Forms.Form();
			System.Windows.Forms.ListBox lb = new System.Windows.Forms.ListBox();
			f.Controls.Add(lb);
			lb.Dock = System.Windows.Forms.DockStyle.Fill;

			foreach (string k in streams.Keys)
			{
				string add = k;
				if (streams[k] is StreamItem si)
				{
					add += " [" + si.StreamState + "]";
				}

				if (IsLocked(k, false))
				{
					add = "[locked] " + add;
				}
				else if (IsLocked(k, true))
				{
					add = "[ftlocked] " + add;
				}

				if (PackageMaintainer.Maintainer.Contains(k))
				{
					add += "[managed]";
				}

				lb.Items.Add(add);
			}

			lb.Sorted = true;
			f.ShowDialog();
			f.Dispose();
		}

		/// <summary>
		/// Removes all Files from the Teleport Folder
		/// </summary>
		public static void CleanupTeleport()
		{
			string[] files = Directory.GetFiles(Helper.SimPeTeleportPath);
			foreach (string file in files)
			{
				try
				{
					CloseStream(file);
					System.IO.File.Delete(file);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex);
				}
			}
			string[] subdirs = Directory.GetDirectories(
				Helper.SimPeTeleportPath
			);
			foreach (string subdir in subdirs)
			{
				try
				{
					Directory.Delete(subdir, true);
				}
				catch { }
			}
		}

		static void InitTable()
		{
			if (streams == null)
			{
				streams = new Hashtable();
			}
		}

		/// <summary>
		/// Returns the Suggested ShareMode for the passed Access Mode
		/// </summary>
		/// <param name="fa">The Acces Mode</param>
		/// <returns>The Suggeste Share Mode</returns>
		/*public static FileShare GetFileShare(FileAccess fa)
		{
			switch (fa)
			{
				case FileAccess.Read:
				{
					return FileShare.Read;
				}
				default:
				{
					return FileShare.Read;
				}
			}
		}*/

		/// <summary>
		/// Returns a valid stream Item for the passed Filename
		/// </summary>
		/// <param name="filename">The name of the FIle you want to open</param>
		/// <returns>a valid StreamItem</returns>
		/// <remarks>
		/// If this File was not know yet, a new StreamItem will
		/// be generated for it and returned. The StreamItem will
		/// not contain a Stream in that case!
		/// </remarks>
		public static StreamItem GetStreamItem(string filename)
		{
			return GetStreamItem(filename, true);
		}

		/// <summary>
		/// Returns a valid stream Item for the passed Filename
		/// </summary>
		/// <param name="filename">The name of the FIle you want to open</param>
		/// <returns>a valid StreamItem or null if not found and createnew was set</returns>
		/// <param name="createnew">
		/// If true and this File was not know yet, a new StreamItem will be generated
		/// for it and returned. The StreamItem will
		/// not contain a Stream in that case!
		/// </param>
		public static StreamItem GetStreamItem(string filename, bool createnew)
		{
			InitTable();
			if (filename == null)
			{
				filename = "";
			}

			filename = filename.Trim().ToLower();
			StreamItem si = (StreamItem)streams[filename];
			if ((si == null) && createnew)
			{
				si = new StreamItem(null);
				streams[filename] = si;
			}

			return si;
		}

		/// <summary>
		/// Returns true if a FileStream for this file exists
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public static bool IsStreamAvailable(string name)
		{
			StreamItem si = GetStreamItem(name, false);
			return si != null;
		}

		/// <summary>
		/// Returns a Usable Stream for that File
		/// </summary>
		/// <param name="filename">The name of the File</param>
		/// <param name="fa">The Acces Attributes</param>
		/// <returns>a StreamItem (StreamState is Removed if the File did not exits!</returns>
		public static StreamItem UseStream(string filename, FileAccess fa)
		{
			return UseStream(filename, fa, false);
		}

		/// <summary>
		/// Returns a Usable Stream for that File
		/// </summary>
		/// <param name="filename">The name of the File</param>
		/// <param name="fa">The Acces Attributes</param>
		/// <param name="create">true if the file should be created if not available</param>
		/// <returns>a StreamItem (StreamState is Removed if the File did not exits!</returns>
		public static StreamItem UseStream(string filename, FileAccess fa, bool create)
		{
			StreamItem si = GetStreamItem(filename);

			//File does not exists, so set State to removed
			if (!System.IO.File.Exists(filename))
			{
				si.Close();
				si.SetFileStream(
					create
						? new FileStream(filename, FileMode.OpenOrCreate, fa)
						: null
				);
				return si;
			}

			// Files does exist -- Removed means never opened here
			if (si.StreamState == StreamState.Removed)
			{
				si.SetFileStream(new FileStream(filename, FileMode.Open, fa));
			}
			else if (!si.SetFileAccess(fa))
			{
				si.Close();
			}

			if (si.StreamState == StreamState.Opened)
			{
				si.FileStream.Seek(0, SeekOrigin.Begin);
			}

			return si;
		}

		/// <summary>
		/// Returns null or a StreamItem that was already created
		/// </summary>
		/// <param name="fs">The Stream you are looking for</param>
		/// <returns>the Stream Item or null if none was found</returns>
		public static StreamItem FindStreamItem(FileStream fs)
		{
			return fs == null ? null : GetStreamItem(fs.Name, false);
		}

		/// <summary>
		/// Closes a FileStream if opened and known by the Factory
		/// </summary>
		/// <param name="filename">The name of the File</param>
		/// <returns>true if the File is closed now</returns>
		public static bool CloseStream(string filename)
		{
			if (IsLocked(filename, false))
			{
				return false;
			}

			StreamItem si = GetStreamItem(filename, false);
			if (si != null)
			{
				si.Close();
				if (!IsLocked(filename, true))
				{
					PackageMaintainer.Maintainer.RemovePackage(filename);
				}

				return si.StreamState != StreamState.Opened;
			}
			return false;
		}

		/// <summary>
		/// Closes all opened Streams (that are not locked and not referenced in the FileTable)
		/// </summary>
		public static void CloseAll()
		{
			CloseAll(false);
		}

		/// <summary>
		/// Closes all opened Streams (that are not locked and not referenced in the FileTable)
		/// </summary>
		/// <param name="force">true, if you want to close all Resources without checking the lock state</param>
		public static void CloseAll(bool force)
		{
			InitTable();
			foreach (string k in streams.Keys)
			{
				if (!IsLocked(k, true) || force)
				{
					StreamItem si = streams[k] as StreamItem;
					si.Close();
					PackageMaintainer.Maintainer.RemovePackage(k);
				}
			}
		}
	}
}
