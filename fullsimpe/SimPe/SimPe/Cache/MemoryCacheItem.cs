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
	public class MemoryCacheItem : ICacheItem, System.IDisposable
	{
		/// <summary>
		/// The current Version
		/// </summary>
		public const byte VERSION = 3;
		internal const byte DISCARD_VERSIONS_SMALLER_THAN = 3;

		public MemoryCacheItem()
		{
			Version = VERSION;
			Name = "";
			pfd = new Packages.PackedFileDescriptor();
			valuenames = new string[0];
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
			set
			{
				pfd = value;
			}
		}

		public uint Guid
		{
			get; set;
		}

		public Data.ObjectTypes ObjectType
		{
			get; set;
		}

		public string Name
		{
			get; set;
		}

		string[] valuenames;
		public string[] ValueNames
		{
			get
			{
				return valuenames;
			}
			set
			{
				valuenames = value;
				if (valuenames == null)
				{
					valuenames = new string[0];
				}
			}
		}

		string objdname;
		public string ObjdName
		{
			get
			{
				if (objdname == null)
				{
					return Name;
				}

				return objdname;
			}
			set
			{
				objdname = value;
			}
		}

		static Image emptyimg;

		/// <summary>
		/// Returns the loaded Icon, or an Empty Image if no Icon was found
		/// </summary>
		public Image Image
		{
			get
			{
				if (Icon == null)
				{
					if (emptyimg == null)
					{
						emptyimg = new Bitmap(1, 1);
					}

					return emptyimg;
				}
				return Icon;
			}
			set
			{
				Icon = value;
			}
		}

		/// <summary>
		/// Returns the loaded Icon, this can be null!
		/// </summary>
		public Image Icon
		{
			get; set;
		}

		public bool IsToken => IsAspiration
					|| (
						(
							ObjdName.Trim().ToLower().StartsWith("token")
							|| ObjdName.Trim().ToLower().StartsWith("cs - token")
						)
						&& (
							this.ObjectType == Data.ObjectTypes.Normal
							|| this.ObjectType == Data.ObjectTypes.Memory
						)
					);

		public bool IsJobData => ObjdName.Trim().ToLower().StartsWith("jobdata")
					&& this.ObjectType == Data.ObjectTypes.Normal;

		public bool IsMemory => IsToken || this.ObjectType == Data.ObjectTypes.Memory;

		public bool IsBadge => (
						ObjdName.ToLower().Trim().StartsWith("token - badge")
						|| ObjdName.ToLower().Trim().StartsWith("cs - token - badge")
					)
					&& this.ObjectType == Data.ObjectTypes.Normal;

		public bool IsSkill => (ObjdName.ToLower().Trim().IndexOf("skill") >= 0)
					&& this.ObjectType == Data.ObjectTypes.Normal
					&& IsToken;

		public bool IsAspiration => ObjdName.Trim().ToLower().StartsWith("aspiration")
					&& this.ObjectType == Data.ObjectTypes.Normal;

		public bool IsInventory => !IsAspiration
					&& !IsToken
					&& !IsJobData
					&& !IsMemory
					&& this.ObjectType == Data.ObjectTypes.Normal;

		public CacheContainer ParentCacheContainer
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
			if (Version >= 2)
			{
				objdname = reader.ReadString();
			}
			else
			{
				objdname = null;
			}

			if (Version >= 3)
			{
				int ct = reader.ReadUInt16();
				valuenames = new string[ct];
				for (int i = 0; i < ct; i++)
				{
					valuenames[i] = reader.ReadString();
				}
			}
			else
			{
				valuenames = new string[0];
			}

			ObjectType = (Data.ObjectTypes)reader.ReadUInt16();
			pfd = new Packages.PackedFileDescriptor();
			pfd.Type = reader.ReadUInt32();
			pfd.Group = reader.ReadUInt32();
			pfd.LongInstance = reader.ReadUInt64();
			Guid = reader.ReadUInt32();

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
			writer.Write(objdname);
			writer.Write((ushort)valuenames.Length);
			foreach (string s in valuenames)
			{
				writer.Write(s);
			}

			writer.Write((ushort)ObjectType);
			writer.Write(pfd.Type);
			writer.Write(pfd.Group);
			writer.Write(pfd.LongInstance);
			writer.Write(Guid);

			if (Icon == null)
			{
				writer.Write((int)0);
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

		#region IDisposable Member

		public void Dispose()
		{
			Icon = null;
			pfd = null;
			Name = null;
		}

		#endregion
	}
}
