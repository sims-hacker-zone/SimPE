// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace SimPe.Cache
{

	/// <summary>
	/// Contains one ObjectCacheItem
	/// </summary>
	public class PackageCacheItem : ICacheItem
	{
		/// <summary>
		/// The current Version
		/// </summary>
		public const byte VERSION = 1;

		public PackageCacheItem()
		{
		}

		protected byte version = VERSION;

		public List<uint> Guids
		{
			get; set;
		} = new List<uint>();

		public PackageType Type
		{
			get; set;
		} = PackageType.Undefined;

		public string Name
		{
			get; set;
		} = "";

		public Image Thumbnail
		{
			get; set;
		}

		public List<PackageState> States
		{
			get; set;
		} = new List<PackageState>();

		/// <summary>
		/// Returns a matching Item for the passed State-uid
		/// </summary>
		/// <param name="uid">the unique ID of the state</param>
		/// <param name="create">true if you want to create a new state (and add it) if it did not exist</param>
		/// <returns></returns>
		public PackageState FindState(uint uid, bool create)
		{
			foreach (PackageState ps in States)
			{
				if (ps.Uid == uid)
				{
					return ps;
				}
			}

			if (create)
			{
				PackageState ps = new PackageState
				{
					Uid = uid
				};

				States.Add(ps);
				return ps;
			}

			return null;
		}

		public bool Enabled
		{
			get; set;
		}

		public override string ToString()
		{
			return "name=" + Name;
		}

		#region ICacheItem Member

		public ICacheItem Load(BinaryReader reader)
		{
			version = reader.ReadByte();
			if (version > VERSION)
			{
				throw new CacheException("Unknown CacheItem Version.", null, version);
			}

			Name = reader.ReadString();
			Type = (PackageType)reader.ReadUInt32();
			Enabled = reader.ReadBoolean();
			int ct = reader.ReadByte();
			for (int i = 0; i < ct; i++)
			{
				Guids.Add(reader.ReadUInt32());
			}

			ct = reader.ReadByte();
			for (int i = 0; i < ct; i++)
			{
				States.Add(PackageState.Load(reader));
			}

			int size = reader.ReadInt32();
			Thumbnail = size == 0 ? null : Image.FromStream(new MemoryStream(reader.ReadBytes(size)));
			return this;
		}

		public void Save(BinaryWriter writer)
		{
			version = VERSION;
			writer.Write(version);
			writer.Write(Name);
			writer.Write((uint)Type);
			writer.Write(Enabled);

			writer.Write((byte)Guids.Count);
			foreach (uint guid in Guids)
			{
				writer.Write(guid);
			}

			byte ct = (byte)States.Count;
			writer.Write(ct);
			foreach (PackageState state in States)
			{
				state.Save(writer);
			}

			if (Thumbnail == null)
			{
				writer.Write(0);
			}
			else
			{
				MemoryStream ms = new MemoryStream();
				Thumbnail.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
				byte[] data = ms.ToArray();
				writer.Write(data.Length);
				writer.Write(data);
			}
		}

		public byte Version => version;

		#endregion
	}
}
