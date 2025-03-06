// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using SimPe.Data;
using SimPe.Interfaces.Files;
using SimPe.Interfaces.Scenegraph;

namespace SimPe.Plugin
{
	/// <summary>
	/// Describes the Type of a MipMap
	/// </summary>
	public enum MipMapType : byte
	{
		Texture = 0x0,
		LifoReference = 0x1,
		SimPE_PlainData = 0xff,
	}

	/// <summary>
	/// A MipMap contains one Texture in a specific Size
	/// </summary>
	public class MipMap : IDisposable
	{
		#region Attributes
		byte[] data = null;
		Image img = null;
		string lifofile;

		public MipMapType DataType
		{
			get; private set;
		}

		/// <summary>
		/// Force a Reload of the Texture
		/// </summary>
		public void ReloadTexture()
		{
			if ((DataType != MipMapType.LifoReference) && (data != null))
			{
				System.IO.BinaryReader sr = new System.IO.BinaryReader(
					new System.IO.MemoryStream(data)
				);
				img = ImageLoader.Load(
					parent.TextureSize,
					data.Length,
					parent.Format,
					sr,
					index,
					mapcount
				);
			}
		}

		public Image Texture
		{
			get
			{
				if (img == null)
				{
					ReloadTexture();
				}
				return img;
			}
			set
			{
				if (value != null)
				{
					DataType = MipMapType.Texture;
				}

				img = value;
			}
		}

		public byte[] Data
		{
			get => data;
			set
			{
				if (value != null)
				{
					DataType = MipMapType.SimPE_PlainData;
				}

				data = value;
			}
		}

		public string LifoFile
		{
			get => lifofile;
			set
			{
				if (value != null)
				{
					DataType = MipMapType.LifoReference;
				}

				lifofile = value;
			}
		}
		#endregion

		ImageData parent;

		/// <summary>
		/// Constructore
		/// </summary>
		public MipMap(ImageData parent)
		{
			this.parent = parent;
			DataType = MipMapType.SimPE_PlainData;
			data = new byte[0];
		}

		#region IRcolBlock Member
		int index,
			mapcount;

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="index">Index of this Map in the Block</param>
		/// <param name="mapcount">Number of Maps in the block (0 is the smallest map)</param>
		/// <param name="reader">The Stream that contains the FileData</param>
		public void Unserialize(System.IO.BinaryReader reader, int index, int mapcount)
		{
			this.index = index;
			this.mapcount = mapcount;
			DataType = (MipMapType)reader.ReadByte();

			switch (DataType)
			{
				case MipMapType.Texture:
				{
					int imgsize = reader.ReadInt32();
					//data = reader.ReadBytes(imgsize);
					long pos = reader.BaseStream.Position;
					//System.IO.BinaryReader br = new System.IO.BinaryReader(new System.IO.MemoryStream(data));


					if (!parent.Parent.Fast)
					{
						try
						{
							data = reader.ReadBytes(imgsize);
							{
								DataType = MipMapType.SimPE_PlainData;
								img = null;
							}
						}
						catch (Exception ex)
						{
							Helper.ExceptionMessage("", ex);
						}
					}

					byte[] over = reader.ReadBytes(
						(int)Math.Max(0, pos + imgsize - reader.BaseStream.Position)
					);
					reader.BaseStream.Seek(pos + imgsize, System.IO.SeekOrigin.Begin);

					break;
				}
				case MipMapType.LifoReference:
				{
					/*byte len = reader.ReadByte();
					lifofile = Helper.ToString(reader.ReadBytes(len));*/
					lifofile = reader.ReadString();
					break;
				}
				default:
				{
					throw new Exception(
						"Unknown MipMap Datatype 0x" + Helper.HexString((byte)DataType)
					);
				}
			}
		}

		/// <summary>
		/// Serializes a the Attributes stored in this Instance to the BinaryStream
		/// </summary>
		/// <param name="writer">The Stream the Data should be stored to</param>
		/// <remarks>
		/// Be sure that the Position of the stream is Proper on
		/// return (i.e. must point to the first Byte after your actual File)
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer)
		{
			if (DataType == MipMapType.SimPE_PlainData)
			{
				writer.Write((byte)MipMapType.Texture);
			}
			else
			{
				writer.Write((byte)DataType);
			}

			switch (DataType)
			{
				case MipMapType.SimPE_PlainData:
				case MipMapType.Texture:
				{
					try
					{
						if (DataType == MipMapType.Texture)
						{
							data = ImageLoader.Save(parent.Format, img);
						}
					}
					catch (Exception ex)
					{
						Helper.ExceptionMessage("", ex);
					}

					if (data == null)
					{
						data = new byte[0];
					}
					//if (data.Length<0x10) data = Helper.SetLength(data, 0x10);

					writer.Write(data.Length);
					writer.Write(data);

					break;
				}
				case MipMapType.LifoReference:
				{
					/*writer.Write((byte)lifofile.Length);
					writer.Write(Helper.ToBytes(lifofile, 0));*/
					writer.Write(lifofile);
					break;
				}
				default:
				{
					throw new Exception(
						"Unknown MipMap Datatype 0x" + Helper.HexString((byte)DataType)
					);
				}
			}
		}
		#endregion

		public override string ToString()
		{
			if (DataType == MipMapType.LifoReference)
			{
				return LifoFile;
			}

			string name = img == null
				? ""
				: "Image "
					+ img.Size.Width.ToString()
					+ "x"
					+ img.Size.Height.ToString()
					+ " - ";

			name += parent.NameResource.FileName;
			return name;
		}

		/// <summary>
		/// If this MipMap is a LifoReference, then this Method will try to load the Lifo Data
		/// </summary>
		public void GetReferencedLifo()
		{
			if (DataType == MipMapType.LifoReference)
			{
				IScenegraphFileIndex nfi =
					FileTableBase.FileIndex.AddNewChild();
				nfi.AddIndexFromPackage(parent.Parent.Package);
				bool succ = GetReferencedLifo_NoLoad();
				FileTableBase.FileIndex.RemoveChild(nfi);
				nfi.Clear();

				if (!succ && !FileTableBase.FileIndex.Loaded)
				{
					FileTableBase.FileIndex.Load();
					GetReferencedLifo_NoLoad();
				}
			}
		}

		/// <summary>
		/// If this MipMap is a LifoReference, then this Method will try to load the Lifo Data
		/// </summary>
		protected bool GetReferencedLifo_NoLoad()
		{
			if (DataType == MipMapType.LifoReference)
			{
				IScenegraphFileIndexItem item =
					FileTableBase.FileIndex.FindFileByName(
						lifofile,
						SimPe.Data.FileTypes.LIFO,
						SimPe.Data.MetaData.LOCAL_GROUP,
						true
					);
				GenericRcol rcol = null;

				if (item != null) //we have a global LIFO (loads faster)
				{
					rcol = new GenericRcol(null, false);
					rcol.ProcessData(item.FileDescriptor, item.Package);
				}
				else //the lifo wasn't found globaly, so we look for it in the local package
				{
					Interfaces.Files.IPackageFile pkg = parent.Parent.Package;
					Interfaces.Files.IPackedFileDescriptor[] pfds = pkg.FindFile(
						lifofile,
						SimPe.Data.FileTypes.LIFO
					);
					if (pfds.Length > 0)
					{
						rcol = new GenericRcol(null, false);
						rcol.ProcessData(pfds[0], pkg);
					}
				}

				//process the Lifo File if found
				if (rcol != null)
				{
					LevelInfo li = (LevelInfo)rcol.Blocks[0];

					img = null;
					Data = li.Data;

					return true;
				}
			}
			else
			{
				return true;
			}

			return false;
		}

		#region IDisposable Member

		public void Dispose()
		{
			data = new byte[0];
			img?.Dispose();

			img = null;
		}

		#endregion
	}

	/// <summary>
	/// MipMap Blocks contain all MipMaps in given sizes
	/// </summary>
	public class MipMapBlock : IDisposable
	{
		#region Attributes
		uint creator;
		uint unknown_1;

		public MipMap[] MipMaps
		{
			get; set;
		}

		#endregion

		ImageData parent;

		/// <summary>
		/// Constructore
		/// </summary>
		public MipMapBlock(ImageData parent)
		{
			this.parent = parent;
			MipMaps = new MipMap[0];
			creator = 0xffffffff;
			unknown_1 = 0x41200000;
		}

		/// <summary>
		/// Creats MipMaps based on the passed Data
		/// </summary>
		/// <param name="data">the MipMap Data</param>
		public void AddDDSData(DDSData[] data)
		{
			MipMaps = new MipMap[data.Length];
			int ct = 0;
			for (int i = data.Length - 1; i >= 0; i--)
			{
				DDSData item = data[i];
				MipMap mm = new MipMap(parent)
				{
					Texture = item.Texture,
					Data = item.Data
				};

				MipMaps[ct++] = mm;
			}
		}

		#region IRcolBlock Member

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		public void Unserialize(System.IO.BinaryReader reader)
		{
			uint innercount;
			switch (parent.Version)
			{
				case 0x09:
				{
					innercount = reader.ReadUInt32();
					break;
				}
				case 0x07:
				{
					innercount = parent.MipMapLevels;
					break;
				}
				default:
				{
					throw new Exception(
						"Unknown MipMap version 0x" + Helper.HexString(parent.Version)
					);
				}
			}

			MipMaps = new MipMap[innercount];
			for (int i = 0; i < MipMaps.Length; i++)
			{
				MipMaps[i] = new MipMap(parent);
				MipMaps[i].Unserialize(reader, i, MipMaps.Length);
			}

			creator = reader.ReadUInt32();
			if ((parent.Version == 0x08) || (parent.Version == 0x09))
			{
				unknown_1 = reader.ReadUInt32();
			}
		}

		/// <summary>
		/// Serializes a the Attributes stored in this Instance to the BinaryStream
		/// </summary>
		/// <param name="writer">The Stream the Data should be stored to</param>
		/// <remarks>
		/// Be sure that the Position of the stream is Proper on
		/// return (i.e. must point to the first Byte after your actual File)
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer)
		{
			switch (parent.Version)
			{
				case 0x09:
				{
					writer.Write((uint)MipMaps.Length);
					break;
				}
			}

			for (int i = 0; i < MipMaps.Length; i++)
			{
				MipMaps[i].Serialize(writer);
			}

			writer.Write(creator);
			if (parent.Version == 0x09)
			{
				writer.Write(unknown_1);
			}
		}
		#endregion

		/// <summary>
		/// Returns the Biggest MipMap in the first MipMap Block (null if no Texture was available)
		/// </summary>
		public MipMap LargestTexture
		{
			get
			{
				MipMap large = null;
				foreach (MipMap mm in MipMaps)
				{
					if (mm.DataType != MipMapType.LifoReference)
					{
						Image img = mm.Texture;
						if (large != null)
						{
							if (large.Texture.Size.Width < img.Size.Width)
							{
								large = mm;
							}
						}
						else
						{
							large = mm;
						}
					}
				}

				return large;
			}
		}

		/// <summary>
		/// Returns the Biggest MipMap in the first MipMap Block (null if no Texture was available)
		/// </summary>
		/// <param name="zs">The wanted Size for the Texture</param>
		public MipMap GetLargestTexture(Size zs)
		{
			MipMap large = null;
			foreach (MipMap mm in MipMaps)
			{
				if (mm.DataType != MipMapType.LifoReference)
				{
					Image img = mm.Texture;
					if (large != null)
					{
						if (large.Texture.Size.Width < img.Size.Width)
						{
							large = mm;
						}
					}
					else
					{
						large = mm;
					}

					if ((img.Size.Width > zs.Width) || (img.Size.Height > zs.Height))
					{
						break;
					}
				}
			}

			return large;
		}

		/// <summary>
		/// Will try to load all Lifo References in the MipMpas stored in this Block
		/// </summary>
		public void GetReferencedLifos()
		{
			foreach (MipMap mm in MipMaps)
			{
				mm.GetReferencedLifo();
			}
		}

		public override string ToString()
		{
			return MipMaps.Length == 1
				? "0x"
					+ Helper.HexString(creator)
					+ " - 0x"
					+ Helper.HexString(unknown_1)
					+ " (1 Item)"
				: "0x"
				+ Helper.HexString(creator)
				+ " - 0x"
				+ Helper.HexString(unknown_1)
				+ " ("
				+ MipMaps.Length
				+ " Items)";
		}

		#region IDisposable Member

		public void Dispose()
		{
			foreach (MipMap mm in MipMaps)
			{
				mm.Dispose();
			}

			MipMaps = new MipMap[0];
		}

		#endregion
	}

	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class ImageData : AbstractRcolBlock, IScenegraphBlock, IDisposable
	{
		#region Attributes

		Size texturesize;
		ImageLoader.TxtrFormats format;
		float unknown_0;
		uint unknown_1;

		public MipMapBlock[] MipMapBlocks
		{
			get; set;
		}

		public Size TextureSize
		{
			get => texturesize;
			set => texturesize = value;
		}

		public uint MipMapLevels
		{
			get; set;
		}

		public ImageLoader.TxtrFormats Format
		{
			get => format;
			set
			{
				if (format != value)
				{
					//when the Format changes we need to get the Picturedta FIRST
					foreach (MipMapBlock mmp in MipMapBlocks)
					{
						foreach (MipMap mm in mmp.MipMaps)
						{
							Image img = mm.Texture;
							mm.Texture = img;
						}
					}
				}
				format = value;
			}
		}

		public string FileNameRepeat
		{
			get; set;
		}

		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public ImageData(Rcol parent)
			: base(parent)
		{
			texturesize = new Size(1, 1);
			MipMapBlocks = new MipMapBlock[1];
			MipMapBlocks[0] = new MipMapBlock(this);
			MipMapLevels = 1;
			sgres = new SGResource(null);
			BlockID = (uint)FileTypes.TXTR;
			FileNameRepeat = "";
			version = 0x09;
			unknown_0 = (float)1.0;
			format = ImageLoader.TxtrFormats.ExtRaw24Bit;
		}

		#region IRcolBlock Member

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		public override void Unserialize(System.IO.BinaryReader reader)
		{
			version = reader.ReadUInt32();
			/*byte len = reader.ReadByte();
			string s = Helper.ToString(reader.ReadBytes(len));*/
			string s = reader.ReadString();

			sgres.BlockID = reader.ReadUInt32();
			sgres.Unserialize(reader);

			if (Parent.Fast)
			{
				texturesize = new Size(0, 0);
				MipMapBlocks = new MipMapBlock[0];
				return;
			}

			int w = reader.ReadInt32();
			int h = reader.ReadInt32();
			texturesize = new Size(w, h);

			format = (ImageLoader.TxtrFormats)reader.ReadUInt32();
			MipMapLevels = reader.ReadUInt32();
			unknown_0 = reader.ReadSingle();
			MipMapBlocks = new MipMapBlock[reader.ReadUInt32()];
			unknown_1 = reader.ReadUInt32();

			if (version == 0x09)
			{
				FileNameRepeat = reader.ReadString();
			}

			for (int i = 0; i < MipMapBlocks.Length; i++)
			{
				MipMapBlocks[i] = new MipMapBlock(this);
				MipMapBlocks[i].Unserialize(reader);
			}
		}

		/// <summary>
		/// Serializes a the Attributes stored in this Instance to the BinaryStream
		/// </summary>
		/// <param name="writer">The Stream the Data should be stored to</param>
		/// <remarks>
		/// Be sure that the Position of the stream is Proper on
		/// return (i.e. must point to the first Byte after your actual File)
		/// </remarks>
		public override void Serialize(System.IO.BinaryWriter writer)
		{
			switch (version)
			{
				case 0x07:
				{
					MipMapLevels = MipMapBlocks.Length > 0 ? (uint)MipMapBlocks[0].MipMaps.Length : 0;

					break;
				}
			}
			writer.Write(version);
			string s = sgres.Register(null);
			writer.Write(s);
			/*writer.Write((byte)sgres.Register(null).Length);
			writer.Write(Helper.ToBytes(sgres.Register(null), 0));*/

			writer.Write(sgres.BlockID);
			sgres.Serialize(writer);

			writer.Write(texturesize.Width);
			writer.Write(texturesize.Height);

			writer.Write((uint)format);
			writer.Write(MipMapLevels);
			writer.Write(unknown_0);
			writer.Write((uint)MipMapBlocks.Length);
			writer.Write(unknown_1);

			if (version == 0x09)
			{
				writer.Write(FileNameRepeat);
			}

			for (int i = 0; i < MipMapBlocks.Length; i++)
			{
				MipMapBlocks[i].Serialize(writer);
			}
		}
		#endregion

		/*public override string ToString()
		{
			return this.NameResource.FileName;
		}*/

		#region IScenegraphBlock Member

		public void ReferencedItems(Dictionary<string, List<IPackedFileDescriptor>> refmap, uint parentgroup)
		{
			refmap["LIFO"] = (from mmp in MipMapBlocks
							  from mm in mmp.MipMaps
							  where mm.DataType == MipMapType.LifoReference
							  select ScenegraphHelper.BuildPfd(mm.LifoFile,
							  	FileTypes.LIFO,
							  	parentgroup)).ToList();
		}

		#endregion

		/// <summary>
		/// Returns the Biggest MipMap in the first MipMap Block (null if no Texture was available)
		/// </summary>
		public MipMap LargestTexture => MipMapBlocks.Length == 0 ? null : MipMapBlocks[0].LargestTexture;

		/// <summary>
		/// Returns the Biggest MipMap in the first MipMap Block (null if no Texture was available)
		/// </summary>
		/// <param name="zs">The wanted Size for the Texture</param>
		public MipMap GetLargestTexture(Size zs)
		{
			return MipMapBlocks.Length == 0 ? null : MipMapBlocks[0].GetLargestTexture(zs);
		}

		/// <summary>
		/// Will try to load all Lifo References in the MipMpas in all Blocks
		/// </summary>
		public void GetReferencedLifos()
		{
			foreach (MipMapBlock mmp in MipMapBlocks)
			{
				mmp.GetReferencedLifos();
			}
		}

		#region IDisposable Member

		public override void Dispose()
		{
			foreach (MipMapBlock mmb in MipMapBlocks)
			{
				mmb.Dispose();
			}

			MipMapBlocks = new MipMapBlock[0];
		}

		#endregion
	}
}
