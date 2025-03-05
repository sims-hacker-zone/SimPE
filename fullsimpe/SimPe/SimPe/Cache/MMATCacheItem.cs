// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
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

		public ICacheItem Load(System.IO.BinaryReader reader)
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
			return this;
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
