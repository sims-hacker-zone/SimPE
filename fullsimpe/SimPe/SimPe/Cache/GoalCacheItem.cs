using System;
using System.Drawing;
using System.IO;
using SimPe;

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
			version = VERSION;
			name = "";
			pfd = new Packages.PackedFileDescriptor();
		}

		byte version;		
		Interfaces.Files.IPackedFileDescriptor pfd;		

		/// <summary>
		/// Returns an (unitialized) FileDescriptor
		/// </summary>
		public Interfaces.Files.IPackedFileDescriptor FileDescriptor
		{
			get { pfd.Tag = this; return pfd; }
			set { pfd = value; }
		}

		uint guid;
		public uint Guid
		{
			get { return guid; }
			set { guid = value; }
		}

		int score;
		public int Score
		{
			get { return score; }
			set { score = value; }
		}

		int influence;
		public int Influence
		{
			get { return influence; }
			set { influence = value; }
		}

		string name;
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		Image thumb;
		public Image Icon
		{
			get { return thumb; }
			set { thumb = value; }
		}


		public override string ToString()
		{
			return "name="+Name;
		}

		#region ICacheItem Member

		public void Load(System.IO.BinaryReader reader) 
		{
			version = reader.ReadByte();
			if (version>VERSION) throw new CacheException("Unknown CacheItem Version.", null, version);
							
			name = reader.ReadString();
			pfd = new Packages.PackedFileDescriptor();
			pfd.Type = reader.ReadUInt32();
			pfd.Group = reader.ReadUInt32();			
			pfd.LongInstance = reader.ReadUInt64();
			influence = reader.ReadInt32();
			score = reader.ReadInt32();
			guid = reader.ReadUInt32();			

			int size = reader.ReadInt32();
			if (size==0) 
			{
				thumb = null;
			} 
			else 
			{
				byte[] data = reader.ReadBytes(size);
				MemoryStream ms = new MemoryStream(data);

				thumb = Image.FromStream(ms);				
			}
		}

		public void Save(System.IO.BinaryWriter writer) 
		{
			version = VERSION;
			writer.Write(version);
			writer.Write(name);
			writer.Write(pfd.Type);
			writer.Write(pfd.Group);
			writer.Write(pfd.LongInstance);
			writer.Write(influence);
			writer.Write(score);
			writer.Write(guid);

			if (thumb==null) 
			{
				writer.Write((int)0);
			} 
			else 
			{
				MemoryStream ms = new MemoryStream();
				thumb.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
				byte[] data = ms.ToArray();
				writer.Write(data.Length);
				writer.Write(data);
			}
		}

		public byte Version
		{
			get
			{
				return version;
			}
		}

		#endregion
	}
}
