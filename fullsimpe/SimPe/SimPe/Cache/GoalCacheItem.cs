using System.Drawing;
using System.IO;

namespace SimPe.Cache
{
	/// <summary>
	/// Contains one ObjectCacheItem
	/// </summary>
	public class GoalCacheItem : ICacheItem
	{
		/// <summary>
		/// The current Version
		/// </summary>
		public const byte VERSION = 1;

		public GoalCacheItem()
		{
			Version = VERSION;
			Name = "";
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
			set
			{
				pfd = value;
			}
		}

		public uint Guid
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

		public void Load(System.IO.BinaryReader reader)
		{
			Version = reader.ReadByte();
			if (Version > VERSION)
			{
				throw new CacheException("Unknown CacheItem Version.", null, Version);
			}

			Name = reader.ReadString();
			pfd = new Packages.PackedFileDescriptor();
			pfd.Type = reader.ReadUInt32();
			pfd.Group = reader.ReadUInt32();
			pfd.LongInstance = reader.ReadUInt64();
			Influence = reader.ReadInt32();
			Score = reader.ReadInt32();
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

		public void Save(System.IO.BinaryWriter writer)
		{
			Version = VERSION;
			writer.Write(Version);
			writer.Write(Name);
			writer.Write(pfd.Type);
			writer.Write(pfd.Group);
			writer.Write(pfd.LongInstance);
			writer.Write(Influence);
			writer.Write(Score);
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
	}
}
