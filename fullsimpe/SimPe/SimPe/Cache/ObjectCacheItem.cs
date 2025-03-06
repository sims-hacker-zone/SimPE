// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Drawing;
using System.IO;

namespace SimPe.Cache
{
	/// <summary>
	/// What general class is the Object in
	/// </summary>
	///
	public enum ObjectClass : byte
	{
		/// <summary>
		/// It is a real Object (OBJd-Based)
		/// </summary>
		Object = 0x00,

		/// <summary>
		/// It something like a Skin (cpf based)
		/// </summary>
		Skin = 0x01,

		/// <summary>
		/// Wallpapers, Floors, Fences
		/// </summary>
		XObject = 0x02,
	}

	/// <summary>
	/// Contains one ObjectCacheItem
	/// </summary>
	public class ObjectCacheItem : ICacheItem
	{
		/// <summary>
		/// The current Version
		/// </summary>
		public const byte VERSION = 5;

		public ObjectCacheItem()
		{
			Version = VERSION;
			Name = "";
			ModelName = "";
			ObjectFileName = "";
			Useable = true;
			pfd = new Packages.PackedFileDescriptor();
		}

		private Interfaces.Files.IPackedFileDescriptor pfd;

		public object Tag
		{
			get; set;
		}

		public ObjectCacheItemVersions ObjectVersion
		{
			get
			{
				switch (Version)
				{
					case (byte)ObjectCacheItemVersions.ClassicOW:
						return ObjectCacheItemVersions.ClassicOW;
					case (byte)ObjectCacheItemVersions.DockableOW:
						return ObjectCacheItemVersions.DockableOW;
					default:
						return Version > VERSION ? ObjectCacheItemVersions.Unsupported : ObjectCacheItemVersions.Outdated;
				}
			}
		}

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
		public Data.ObjectTypes ObjectType
		{
			get; set;
		}

		/// <summary>
		/// The class the Object is assigned to
		/// </summary>
		public ObjectClass Class
		{
			get; set;
		}

		/// <summary>
		/// Returns the FunctionSort Field of the Object
		/// </summary>
		public uint ObjectFunctionSort
		{
			get; set;
		}

		/// <summary>
		/// Returns the FunctionSort Field of the Object
		/// </summary>
		public uint ObjBuildType
		{
			get; set;
		}

		public static string[][] GetCategory(
			ObjectCacheItemVersions version,
			Data.ObjFunctionSubSort subsort,
			Data.ObjectTypes type
		)
		{
			return GetCategory(version, subsort, type, ObjectClass.Object);
		}

		public static string[][] GetCategory(
			ObjectCacheItemVersions version,
			Data.ObjFunctionSubSort subsort,
			Data.ObjectTypes type,
			ObjectClass cl
		)
		{
			uint ofss = (uint)subsort;
			string[][] ret;
			if (version == ObjectCacheItemVersions.ClassicOW)
			{
				System.Collections.ArrayList list = new System.Collections.ArrayList();
				Data.ObjFunctionSortBits[] ss = (Data.ObjFunctionSortBits[])
					Enum.GetValues(typeof(Data.ObjFunctionSortBits));
				foreach (Data.ObjFunctionSortBits s in ss)
				{
					if ((ofss & (uint)Math.Pow(2, (byte)s)) != 0)
					{
						list.Add(s.ToString());
					}
				}

				ret = new string[list.Count][];
				for (int i = 0; i < list.Count; i++)
				{
					ret[i] = new string[] { list[i].ToString() };
				}
			}
			else // if (version == ObjectCacheItemVersions.DockableOW)
			{
				if (cl == ObjectClass.XObject)
				{
					Data.XObjFunctionSubSort fss = (Data.XObjFunctionSubSort)subsort;
					ret = new string[1][];
					string[] ps =
						Localization.GetString(
							"SimPe.Data.XObjFunctionSubSort." + fss.ToString()
						)
						.Replace(" / ", "_")
						.Split("_".ToCharArray(), 2);
					if (ps.Length >= 2)
					{
						ret[0] = new string[]
						{
							Localization.GetString("XObject"),
							ps[0],
							ps[1],
						};
					}
					else if (ps.Length == 1)
					{
						ret[0] = new string[]
						{
							Localization.GetString("XObject"),
							ps[0],
						};
					}
				}
				else
				{
					Data.ObjFunctionSubSort fss = subsort;
					uint upper = (ofss >> 8) & 0xfff;
					uint lower = ofss & 0xff;

					System.Collections.ArrayList list =
						new System.Collections.ArrayList();
					Data.ObjFunctionSortBits[] ss = (Data.ObjFunctionSortBits[])
						Enum.GetValues(typeof(Data.ObjFunctionSortBits));

					foreach (Data.ObjFunctionSortBits s in ss)
					{
						int vu = (int)Math.Pow(2, (byte)s);
						if ((upper & vu) != 0)
						{
							bool added = false;
							for (int i = 0; i < 8; i++)
							{
								int v = (int)Math.Pow(2, i);
								if ((lower & v) != 0)
								{
									Data.ObjFunctionSubSort mss =
										(Data.ObjFunctionSubSort)(
											((vu & 0xfff) << 8) | (v & 0xff)
										);
									string[] ps =
										Localization.GetString(
											"SimPe.Data.ObjFunctionSubSort."
												+ mss.ToString()
										)
										.Replace(" / ", "_")
										.Split("_".ToCharArray(), 2);
									if (ps.Length >= 2)
									{
										list.Add(new string[] { ps[0], ps[1] });
										added = true;
									}
									else if (ps.Length == 1)
									{
										list.Add(
											new string[]
											{
												Localization.GetString(
													"SimPe.Data.ObjFunctionSortBits."
														+ s.ToString()
												),
											}
										);
										added = true;
									}
								}
							}

							if (!added)
							{
								list.Add(
									new string[]
									{
										Localization.GetString(
											"SimPe.Data.ObjFunctionSortBits."
												+ s.ToString()
										),
									}
								);
							}
						}
					}

					ret = new string[list.Count][];
					for (int i = 0; i < list.Count; i++)
					{
						string[] ct = (string[])list[i];
						ret[i] = ct;
					}
				}
			}

			if (type != Data.ObjectTypes.Normal)
			{
				System.Collections.ArrayList list = new System.Collections.ArrayList();
				if (ret != null)
				{
					foreach (string[] s in ret)
					{
						list.Add(s);
					}
				}
				list.Add(
					new string[]
					{
						Localization.GetString("Other"),
						Localization.GetString(
							"SimPe.Data.ObjectTypes." + type.ToString()
						),
					}
				);

				ret = new string[list.Count][];
				for (int i = 0; i < list.Count; i++)
				{
					string[] ct = (string[])list[i];
					ret[i] = ct;
				}
			}

			if (ret == null)
			{
				ret = new string[][]
				{
					new string[] { Localization.GetString("Unknown") },
				};
			}

			if (ret.Length == 0)
			{
				ret = new string[][]
				{
					new string[] { Localization.GetString("Unknown") },
				};
			}

			return ret;
		}

		/// <summary>
		/// Returs the Category this Object should get sorted in
		/// </summary>
		public string[][] ObjectCategory => GetCategory(
					ObjectVersion,
					(Data.ObjFunctionSubSort)ObjectFunctionSort,
					ObjectType,
					Class
				);

		/// <summary>
		/// Returns the LocalGroup
		/// </summary>
		public uint LocalGroup
		{
			get; set;
		}

		/// <summary>
		/// Returns the Name of this Object
		/// </summary>
		public string Name
		{
			get; set;
		}

		/// <summary>
		/// Returns the Name of this Object
		/// </summary>
		public string ObjectFileName
		{
			get; set;
		}

		/// <summary>
		/// Returns the Name of this Object
		/// </summary>
		public bool Useable
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
		/// Returns the Thumbnail
		/// </summary>
		public Image Thumbnail
		{
			get; set;
		}

		public override string ToString()
		{
			return Name + " (0x" + Helper.HexString(LocalGroup) + ")";
		}

		#region ICacheItem Member

		public ICacheItem Load(BinaryReader reader)
		{
			Version = reader.ReadByte();
			if (Version > VERSION)
			{
				throw new CacheException("Unknown CacheItem Version.", null, Version);
			}

			Name = reader.ReadString();
			ModelName = reader.ReadString();
			pfd = new Packages.PackedFileDescriptor
			{
				Type = (Data.FileTypes)reader.ReadUInt32(),
				Group = reader.ReadUInt32()
			};
			LocalGroup = reader.ReadUInt32();
			pfd.LongInstance = reader.ReadUInt64();

			int size = reader.ReadInt32();
			Thumbnail = size == 0 ? null : Image.FromStream(new MemoryStream(reader.ReadBytes(size)));

			ObjectType = (Data.ObjectTypes)reader.ReadUInt16();
			ObjectFunctionSort = Version >= 4 ? reader.ReadUInt32() : (uint)reader.ReadInt16();

			ObjBuildType = Version >= 5 ? reader.ReadUInt32() : 0;

			if (Version >= 2)
			{
				ObjectFileName = reader.ReadString();
				Useable = reader.ReadBoolean();
			}
			else
			{
				ObjectFileName = ModelName;
				Useable = true;
			}

			Class = Version >= 3 ? (ObjectClass)reader.ReadByte() : ObjectClass.Object;
			return this;
		}

		public void Save(BinaryWriter writer)
		{
			Version = VERSION;
			writer.Write(Version);
			writer.Write(Name);
			writer.Write(ModelName);
			writer.Write((uint)pfd.Type);
			writer.Write(pfd.Group);
			writer.Write(LocalGroup);
			writer.Write(pfd.LongInstance);

			if (Thumbnail == null)
			{
				writer.Write(0);
			}
			else
			{
				try
				{
					MemoryStream ms = new MemoryStream();
					Thumbnail.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
					byte[] data = ms.ToArray();
					writer.Write(data.Length);
					writer.Write(data);
					ms.Close();
				}
				catch
				{
					writer.Write(0);
				}
			}

			writer.Write((ushort)ObjectType);
			writer.Write(ObjectFunctionSort);
			writer.Write(ObjBuildType);

			writer.Write(ObjectFileName);
			writer.Write(Useable);

			writer.Write((byte)Class);
		}

		public byte Version
		{
			get; private set;
		}

		#endregion
	}
}
