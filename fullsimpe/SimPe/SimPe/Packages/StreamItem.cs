// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.IO;

namespace SimPe.Packages
{
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
			FileStream = fs;
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
				FileStream.Dispose();
				FileStream = null;
			}
		}
	}
}
