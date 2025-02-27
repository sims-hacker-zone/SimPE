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
using System.Drawing;
using System.IO;

namespace SimPe.Cache
{
	/// <summary>
	/// Contains one ObjectCacheItem
	/// </summary>
	public class WantCacheItem : ICacheItem
	{
		/// <summary>
		/// The current Version
		/// </summary>
		public const byte VERSION = 1;

		public WantCacheItem()
		{
			Version = VERSION;
			Name = "";
			ObjectType = "";
			Folder = "";
			pfd = new Packages.PackedFileDescriptor();
		}

		Interfaces.Files.IPackedFileDescriptor pfd;

		/// <summary>
		/// Returns an (unitialized) FileDescriptor
		/// </summary>
		public Interfaces.Files.IPackedFileDescriptor FileDescriptor
		{
			get
			{
				pfd.Tag = this;
				return pfd;
			}
			set => pfd = value;
		}

		public uint Guid
		{
			get; set;
		}

		public string Folder
		{
			get; set;
		}

		public int Score
		{
			get; set;
		}

		public int Influence
		{
			get; set;
		}

		public string ObjectType
		{
			get; set;
		}

		public string Name
		{
			get; set;
		}

		public Image Icon
		{
			get; set;
		}

		public override string ToString()
		{
			return "name=" + Name;
		}

		#region ICacheItem Member

		public void Load(BinaryReader reader)
		{
			Version = reader.ReadByte();
			if (Version > VERSION)
			{
				throw new CacheException("Unknown CacheItem Version.", null, Version);
			}

			Name = reader.ReadString();
			ObjectType = reader.ReadString();
			pfd = new Packages.PackedFileDescriptor
			{
				Type = reader.ReadUInt32(),
				Group = reader.ReadUInt32(),
				LongInstance = reader.ReadUInt64()
			};
			Influence = reader.ReadInt32();
			Score = reader.ReadInt32();
			Guid = reader.ReadUInt32();
			Folder = reader.ReadString();

			int size = reader.ReadInt32();
			if (size == 0)
			{
				Icon = null;
			}
			else
			{
				byte[] data = reader.ReadBytes(size);
				MemoryStream ms = new MemoryStream(data);

				Icon = Image.FromStream(ms);
			}
		}

		public void Save(BinaryWriter writer)
		{
			Version = VERSION;
			writer.Write(Version);
			writer.Write(Name);
			writer.Write(ObjectType);
			writer.Write(pfd.Type);
			writer.Write(pfd.Group);
			writer.Write(pfd.LongInstance);
			writer.Write(Influence);
			writer.Write(Score);
			writer.Write(Guid);
			writer.Write(Folder);

			if (Icon == null)
			{
				writer.Write(0);
			}
			else
			{
				MemoryStream ms = new MemoryStream();
				Icon.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
				byte[] data = ms.ToArray();
				writer.Write(data.Length);
				writer.Write(data);
			}
		}

		public byte Version
		{
			get; private set;
		}

		#endregion
	}
}
