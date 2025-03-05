// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Cache
{
	public enum RcolCacheItemType : byte
	{
		Wallmask = 0,
		Unknown = 0xff,
	};

	/// <summary>
	/// Contains one RcolCacheItem
	/// </summary>
	public class RcolCacheItem : ICacheItem
	{
		/// <summary>
		/// The current Version
		/// </summary>
		public const byte VERSION = 1;

		public RcolCacheItem()
		{
			Version = VERSION;
			ResourceName = "";
			ModelName = "";
			RcolType = RcolCacheItemType.Unknown;

			pfd = new Packages.PackedFileDescriptor();
		}

		//RcolCacheItemType type;
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

		public RcolCacheItemType RcolType
		{
			get; set;
		}

		/// <summary>
		/// Returns the Type Field of the Object
		/// </summary>
		public string ResourceName
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

		public override string ToString()
		{
			return "modelname="
				+ ModelName
				+ ", type="
				+ RcolType
				+ ", name="
				+ ResourceName;
		}

		#region ICacheItem Member

		public ICacheItem Load(System.IO.BinaryReader reader)
		{
			Version = reader.ReadByte();
			if (Version > VERSION)
			{
				throw new CacheException("Unknown CacheItem Version.", null, Version);
			}

			ResourceName = reader.ReadString();
			RcolType = (RcolCacheItemType)reader.ReadByte();
			pfd = new Packages.PackedFileDescriptor
			{
				Type = reader.ReadUInt32(),
				Group = reader.ReadUInt32(),
				LongInstance = reader.ReadUInt64()
			};
			return this;
		}

		public void Save(System.IO.BinaryWriter writer)
		{
			Version = VERSION;
			writer.Write(Version);
			writer.Write(ResourceName);
			writer.Write((byte)RcolType);
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
