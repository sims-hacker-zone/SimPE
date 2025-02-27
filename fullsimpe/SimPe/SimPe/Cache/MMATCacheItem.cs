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
namespace SimPe.Cache
{
	/// <summary>
	/// Contains one ObjectCacheItem
	/// </summary>
	public class MMATCacheItem : ICacheItem
	{
		/// <summary>
		/// The current Version
		/// </summary>
		public const byte VERSION = 1;

		public MMATCacheItem()
		{
			Version = VERSION;
			ModelName = "";
			Family = "";
			Default = false;
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

		/// <summary>
		/// Returns the Type Field of the Object
		/// </summary>
		public bool Default
		{
			get; set;
		}

		/// <summary>
		/// Returns the ModeName for this Object
		/// </summary>
		public string ModelName
		{
			get; set;
		}

		/// <summary>
		/// Returns the Familyname for this Object
		/// </summary>
		public string Family
		{
			get; set;
		}

		public override string ToString()
		{
			return "modelname=" + ModelName + ", family=" + Family;
		}

		#region ICacheItem Member

		public void Load(System.IO.BinaryReader reader)
		{
			Version = reader.ReadByte();
			if (Version > VERSION)
			{
				throw new CacheException("Unknown CacheItem Version.", null, Version);
			}

			ModelName = reader.ReadString();
			Family = reader.ReadString();
			Default = reader.ReadBoolean();
			pfd = new Packages.PackedFileDescriptor
			{
				Type = reader.ReadUInt32(),
				Group = reader.ReadUInt32(),
				LongInstance = reader.ReadUInt64()
			};
		}

		public void Save(System.IO.BinaryWriter writer)
		{
			Version = VERSION;
			writer.Write(Version);
			writer.Write(ModelName);
			writer.Write(Family);
			writer.Write(Default);
			writer.Write(pfd.Type);
			writer.Write(pfd.Group);
			writer.Write(pfd.LongInstance);
		}

		public byte Version
		{
			get; private set;
		}

		#endregion
	}
}
