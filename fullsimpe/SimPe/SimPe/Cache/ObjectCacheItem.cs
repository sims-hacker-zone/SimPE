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

	public enum ObjectCacheItemVersions : byte
	{
		Outdated = 0x00,
		ClassicOW = 0x03,
		DockableOW = 0x05,
		Unsupported = 0xff,
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

		Interfaces.Files.IPackedFileDescriptor pfd;

		public Object Tag
		{
			get; set;
		}

		public ObjectCacheItemVersions ObjectVersion
		{
			get
			{
				if (Version == (byte)ObjectCacheItemVersions.ClassicOW)
				{
					return ObjectCacheItemVersions.ClassicOW;
				}

				if (Version == (byte)ObjectCacheItemVersions.DockableOW)
				{
					return ObjectCacheItemVersions.DockableOW;
				}

				if (Version > VERSION)
				{
					return ObjectCacheItemVersions.Unsupported;
				}

				return ObjectCacheItemVersions.Outdated;
			}
			/*set {
				if (value == ObjectCacheItemVersions.Outdated) version = (byte)ObjectCacheItemVersions.ClassicOW;
				else if (value == ObjectCacheItemVersions.Unsupported) version = (byte)ObjectCacheItemVersions.DockableOW;
				version = (byte)value;
			}*/
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
			set
			{
				pfd = value;
			}
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
			string[][] ret = null;

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

		public void Load(BinaryReader reader)
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
				Type = reader.ReadUInt32(),
				Group = reader.ReadUInt32()
			};
			LocalGroup = reader.ReadUInt32();
			pfd.LongInstance = reader.ReadUInt64();

			int size = reader.ReadInt32();
			if (size == 0)
			{
				Thumbnail = null;
			}
			else
			{
				byte[] data = reader.ReadBytes(size);
				MemoryStream ms = new MemoryStream(data);

				Thumbnail = Image.FromStream(ms);
			}

			ObjectType = (Data.ObjectTypes)reader.ReadUInt16();
			if (Version >= 4)
			{
				ObjectFunctionSort = reader.ReadUInt32();
			}
			else
			{
				ObjectFunctionSort = (uint)reader.ReadInt16();
			}

			if (Version >= 5)
			{
				ObjBuildType = reader.ReadUInt32();
			}
			else
			{
				ObjBuildType = 0;
			}

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

			if (Version >= 3)
			{
				Class = (ObjectClass)reader.ReadByte();
			}
			else
			{
				Class = ObjectClass.Object;
			}
		}

		public void Save(BinaryWriter writer)
		{
			Version = VERSION;
			writer.Write(Version);
			writer.Write(Name);
			writer.Write(ModelName);
			writer.Write(pfd.Type);
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
