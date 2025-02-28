// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

namespace SimPe.Cache
{
	/// <summary>
	/// What type have the items stored in the container
	/// </summary>
	public enum ContainerType : byte
	{
		None = 0x00,
		Object = 0x01,
		MaterialOverride = 0x02,
		Want = 0x03,
		Memory = 0x04,
		Package = 0x05,
		Rcol = 0x06,
		Goal = 0x07,
	};

	/// <summary>
	/// Detailed Information about the Valid State of the Container
	/// </summary>
	public enum ContainerValid : byte
	{
		Yes = 0x04,
		FileNotFound = 0x01,
		Modified = 0x02,
		UnknownVersion = 0x03,
	}

	/// <summary>
	/// Contains one or more CacheItems
	/// </summary>
	public class CacheContainer : IDisposable
	{
		/// <summary>
		/// The current Version
		/// </summary>
		public const byte VERSION = 1;

		/// <summary>
		/// Create a new Instance
		/// </summary>
		public CacheContainer(ContainerType type)
		{
			Version = VERSION;
			Type = type;
			Added = DateTime.Now;
			filename = "";
			ValidState = ContainerValid.Yes;

			Items = new CacheItems();
		}

		string filename;

		/// <summary>
		/// Returns the Version of the File
		/// </summary>
		public byte Version
		{
			get; private set;
		}

		/// <summary>
		/// Returns the Version of the File
		/// </summary>
		public DateTime Added
		{
			get; set;
		}

		/// <summary>
		/// Return all available Items
		/// </summary>
		public CacheItems Items
		{
			get; private set;
		}

		/// <summary>
		/// Returns the Type of this Container
		/// </summary>
		public ContainerType Type
		{
			get; private set;
		}

		/// <summary>
		/// True if this Container is still valid
		/// </summary>
		public bool Valid => ValidState == ContainerValid.Yes;

		public ContainerValid ValidState
		{
			get; set;
		}

		/// <summary>
		/// Return the Name of the File this Container was used for
		/// </summary>
		public string FileName
		{
			get => filename;
			set => filename = value.Trim().ToLower();
		}

		/// <summary>
		/// Load the Container from the Stream
		/// </summary>
		/// <param name="reader">the Stream Reader</param>
		internal void Load(System.IO.BinaryReader reader)
		{
			ValidState = ContainerValid.FileNotFound;
			Items.Clear();
			int offset = reader.ReadInt32();
			Version = reader.ReadByte();
			Type = (ContainerType)reader.ReadByte();
			int count = reader.ReadInt32();

			long pos = reader.BaseStream.Position;
			try
			{
				if (Version <= VERSION)
				{
					reader.BaseStream.Seek(offset, System.IO.SeekOrigin.Begin);
					Added = DateTime.FromFileTime(reader.ReadInt64());
					filename = reader.ReadString();

					if (System.IO.File.Exists(filename))
					{
						DateTime mod = System.IO.File.GetLastWriteTime(filename);
						ValidState = mod <= Added ? ContainerValid.Yes : ContainerValid.Modified;
					}

					if (
						ValidState == ContainerValid.Yes
						|| System
							.Windows.Forms.Application.ExecutablePath.Trim()
							.ToLower()
							.EndsWith("settingmanager.exe")
					)
					{
						switch (Type)
						{
							case ContainerType.Object:
							{
								for (int i = 0; i < count; i++)
								{
									ObjectCacheItem oci = new ObjectCacheItem();
									oci.Load(reader);
									Items.Add(oci);
								}

								break;
							}
							case ContainerType.MaterialOverride:
							{
								for (int i = 0; i < count; i++)
								{
									MMATCacheItem oci = new MMATCacheItem();
									oci.Load(reader);
									Items.Add(oci);
								}

								break;
							}
							case ContainerType.Rcol:
							{
								for (int i = 0; i < count; i++)
								{
									RcolCacheItem oci = new RcolCacheItem();
									oci.Load(reader);
									Items.Add(oci);
								}

								break;
							}
							case ContainerType.Want:
							{
								for (int i = 0; i < count; i++)
								{
									WantCacheItem oci = new WantCacheItem();
									oci.Load(reader);
									Items.Add(oci);
								}

								break;
							}
							case ContainerType.Goal:
							{
								for (int i = 0; i < count; i++)
								{
									GoalCacheItem oci = new GoalCacheItem();
									oci.Load(reader);
									Items.Add(oci);
								}

								break;
							}
							case ContainerType.Memory:
							{
								for (int i = 0; i < count; i++)
								{
									MemoryCacheItem oci = new MemoryCacheItem();
									oci.Load(reader);
									oci.ParentCacheContainer = this;
									if (
										oci.Version
										>= MemoryCacheItem.DISCARD_VERSIONS_SMALLER_THAN
									)
									{
										Items.Add(oci);
									}
								}

								break;
							}
							case ContainerType.Package:
							{
								for (int i = 0; i < count; i++)
								{
									PackageCacheItem oci = new PackageCacheItem();
									oci.Load(reader);
									Items.Add(oci);
								}

								break;
							}
						} //switch
					} // if valid
				} //if VERSION
				else
				{
					ValidState = ContainerValid.UnknownVersion;
				}
			}
			finally
			{
				reader.BaseStream.Seek(pos, System.IO.SeekOrigin.Begin);
			}
		}

		/// <summary>
		/// Save the Container to the Stream
		/// </summary>
		/// <param name="writer">the Stream Writer</param>
		internal void Save(System.IO.BinaryWriter writer, int offset)
		{
			writer.Write(offset);

			//prewrite Phase
			if (offset == -1)
			{
				Version = VERSION;
				writer.Write(Version);
				writer.Write((byte)Type);
				writer.Write(Items.Count);
			}
			else //Item writing Phase
			{
				writer.Seek(offset, System.IO.SeekOrigin.Begin);
				writer.Write(Added.ToFileTime());
				writer.Write(filename);

				for (int i = 0; i < Items.Count; i++)
				{
					Items[i].Save(writer);
				}
			}
		}

		#region IDisposable Member

		public virtual void Dispose()
		{
			if (Items != null)
			{
				foreach (object o in Items)
				{
					if (o is IDisposable)
					{
						((IDisposable)o).Dispose();
					}
				}

				Items.Clear();
			}
			Items = null;
		}

		#endregion
	}
}
