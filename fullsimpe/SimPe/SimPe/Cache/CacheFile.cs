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

using SimPe;
using SimPe.Packages;

namespace SimPe.Cache
{
	/// <summary>
	/// Contains an Instance of a CacheFile
	/// </summary>
	public class CacheFile : System.IDisposable, SimPe.Interfaces.ICacheFileTest
	{
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
		/// The default type for this container
		/// </summary>
		protected ContainerType DEFAULT_TYPE = ContainerType.None;

		/// <summary>
		/// Creaet a new Instance for an empty File
		/// </summary>
		public CacheFile()
		{
			Version = VERSION;
			Containers = new CacheContainers();
		}

		/// <summary>
		/// Load a Cache File from the Disk
		/// </summary>
		/// <param name="flname">the name of the File</param>
		/// <exception cref="CacheException">Thrown if the File is not readable (ie, wrong Version or Signature)</exception>
		public void Load(string flname)
		{
			Load(flname, false);
		}

		/// <summary>
		/// Load a Cache File from the Disk
		/// </summary>
		/// <param name="flname">the name of the File</param>
		/// <param name="withprogress">true if you want  to set the Progress in the current Wait control</param>
		/// <exception cref="CacheException">Thrown if the File is not readable (ie, wrong Version or Signature)</exception>
		public void Load(string flname, bool withprogress)
		{
			this.FileName = flname;
			Containers.Clear();

			if (!System.IO.File.Exists(flname))
				return;

			StreamItem si = StreamFactory.UseStream(flname, FileAccess.Read, true);
			try
			{
				BinaryReader reader = new BinaryReader(si.FileStream);

				try
				{
					Signature = reader.ReadUInt64();
					if (Signature != OLDSIG && Signature != SIGNATURE)
						throw new CacheException(
							"Unknown Cache File Signature ("
								+ Helper.HexString(Signature)
								+ ")",
							flname,
							0
						);

					Version = reader.ReadByte();
					if (Version > VERSION)
						throw new CacheException(
							"Unable to read Cache",
							flname,
							Version
						);

					int count = reader.ReadInt32();
					if (withprogress)
						Wait.MaxProgress = count;
					for (int i = 0; i < count; i++)
					{
						CacheContainer cc = new CacheContainer(DEFAULT_TYPE);
						cc.Load(reader);
						Containers.Add(cc);
						if (withprogress)
							Wait.Progress = i;
						if (i % 10 == 0)
							System.Windows.Forms.Application.DoEvents();
					}
				}
				finally
				{
					reader.Close();
				}
			}
			finally
			{
				si.Close();
			}
		}

		/// <summary>
		/// Save a Cache File to the Disk
		/// </summary>
		public void Save()
		{
			Save(FileName);
		}

		/// <summary>
		/// Save a Cache File to the Disk
		/// </summary>
		/// <param name="flname">the name of the File</param>
		public void Save(string flname)
		{
			this.FileName = flname;
			this.Version = VERSION;

			StreamItem si = StreamFactory.UseStream(flname, FileAccess.Write, true);
			try
			{
				CleanUp();

				si.FileStream.Seek(0, SeekOrigin.Begin);
				si.FileStream.SetLength(0);
				BinaryWriter writer = new BinaryWriter(si.FileStream);

				writer.Write(SIGNATURE);
				writer.Write(Version);

				writer.Write((int)Containers.Count);
				ArrayList offsets = new ArrayList();
				//prepare the Index
				for (int i = 0; i < Containers.Count; i++)
				{
					offsets.Add(writer.BaseStream.Position);
					Containers[i].Save(writer, -1);
				}

				//write the Data
				for (int i = 0; i < Containers.Count; i++)
				{
					long offset = writer.BaseStream.Position;
					writer.BaseStream.Seek((long)offsets[i], SeekOrigin.Begin);
					Containers[i].Save(writer, (int)offset);
				}
			}
			finally
			{
				si.Close();
			}
		}

		public void CleanUp()
		{
			for (int i = Containers.Count - 1; i >= 0; i--)
			{
				if (!Containers[i].Valid)
					Containers.RemoveAt(i);
			}
		}

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

		/// <summary>
		/// Returns all Available Containers
		/// </summary>
		public CacheContainers Containers
		{
			get;
		}

		/// <summary>
		/// Returns a container for the passed type and File
		/// </summary>
		/// <param name="ct">The Container Type</param>
		/// <param name="name">The name of the FIle</param>
		/// <remarks>If no container is Found, a new one will be created for this File and Type!</remarks>
		public CacheContainer UseConatiner(ContainerType ct, string name)
		{
			if (name == null)
				name = "";
			name = name.Trim().ToLower();

			CacheContainer mycc = null;
			foreach (CacheContainer cc in Containers)
			{
				if (cc.Type == ct && cc.Valid && cc.FileName == name)
				{
					mycc = cc;
					break;
				}
			} //foreach

			if (mycc == null)
			{
				mycc = new CacheContainer(ct);
				mycc.FileName = name;
				Containers.Add(mycc);
			}

			return mycc;
		}

		public virtual void Dispose()
		{
			foreach (CacheContainer cc in Containers)
				cc.Dispose();

			Containers.Clear();
		}
	}
}
