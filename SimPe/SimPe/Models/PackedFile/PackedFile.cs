// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using AvaloniaHex.Document;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Data;
using SimPe.Extensions;
using SimPe.Models.Interfaces;
using SimPe.Models.Package;
using SimPe.Models.PackedFile.Clst;

namespace SimPe.Models.PackedFile
{
	public partial class PackedFile(PackageFile package) : ObservableObject
	{
		[ObservableProperty]
		private PackageFile package = package;

		[ObservableProperty]
		private EnumDisplayNameItem<FileTypes> type;

		[ObservableProperty]
		private uint group;

		[ObservableProperty]
		private uint instanceHigh;

		[ObservableProperty]
		private uint instance;

		public ulong LongInstance
		{
			get => ((ulong)InstanceHigh << 32) | Instance;
			set
			{
				InstanceHigh = (uint)(value >> 32);
				Instance = (uint)value;
			}
		}

		[ObservableProperty]
		private uint offset;

		[ObservableProperty]
		private int size;

		/// <summary>
		/// Returns the Information of the represented Type
		/// </summary>
		public FileTypeInformation TypeInfo => Type.Item.ToFileTypeInformation();

		[ObservableProperty]
		private byte[] userData;

		public DynamicBinaryDocument UserDataDocument => new(UserData) { IsReadOnly = true };

		[ObservableProperty]
		private bool isCompressed;

		[ObservableProperty]
		private byte[] rawData;

		public DynamicBinaryDocument RawDataDocument => new(RawData) { IsReadOnly = true };

		[ObservableProperty]
		private byte[] uncompressedData;

		public DynamicBinaryDocument UncompressedDataDocument => new(UncompressedData) { IsReadOnly = true };

		[ObservableProperty]
		private uint uncompressedSize;

		private string fileName;
		public string FileName
		{
			get
			{
				fileName ??= $"{InstanceHigh:X8}-{Group:X8}-{Instance:X8}.{TypeInfo.Extension}";
				return fileName;
			}
			set => SetProperty(ref fileName, value);
		}

		public string ExportFileName => $"{(uint)Type.Item:X8}-{FileName}";

		public string DisplayName
		{
			get
			{
				if (wrapper != null && Wrapper.FriendlyName != null)
				{
					return Wrapper.FriendlyName;
				}
				else if (Type.Item.ToFileTypeInformation().ContainsFileName)
				{
					if (UserData != null)
					{
						return Encoding.ASCII.GetString(UserData[..64]);
					}
					else if (UncompressedData != null)
					{
						return Encoding.ASCII.GetString(UncompressedData[..64]);
					}
					else
					{
						return RawData != null ? Encoding.ASCII.GetString(RawData[..64]) : FileName;
					}
				}
				else
				{
					return FileName;
				}
			}
		}


		private string path;
		public string Path
		{
			get
			{
				path ??= $"{Type:X8} - {Helper.RemoveUnlistedCharacters(TypeInfo.LongName)}";
				return path;
			}
			set => path = value;
		}

		private IWrapper wrapper;

		public IWrapper Wrapper
		{
			get
			{
				if (wrapper == null)
				{
					if (Type != FileTypes.CLST)
					{
						ReadContent();
					}
					if (Wrappers.Unserializers.TryGetValue(Type.Item, out Func<BinaryReader, PackedFile, IWrapper> func))
					{
						using MemoryStream memory = new(IsCompressed ? UncompressedData : RawData);
						using BinaryReader reader = new(memory);
						wrapper = func(reader, this);
						wrapper.PropertyChanged += Wrapper_PropertyChanged;
					}
				}
				return wrapper;
			}
		}

		public bool FileChanged => wrapper != null && UserData != null;

		public static PackedFile Unserialize(BinaryReader reader, PackageFile package)
		{
			PackedFile file = new(package)
			{
				Type = new((FileTypes)reader.ReadUInt32()),
				Group = reader.ReadUInt32(),
				Instance = reader.ReadUInt32()
			};
			if (package.Header.IndexType == IndexTypes.ptLongFileIndex)
			{
				file.InstanceHigh = reader.ReadUInt32();
			}
			file.Offset = reader.ReadUInt32();
			file.Size = reader.ReadInt32();
			return file;
		}

		public void Serialize(BinaryWriter writer)
		{
			writer.Write((uint)Type.Item);
			writer.Write(Group);
			writer.Write(Instance);
			if (Package.Header.IndexType == IndexTypes.ptLongFileIndex)
			{
				writer.Write(InstanceHigh);
			}
			writer.Write(Offset);
			writer.Write(Size);
		}

		public XElement GenerateXmlMetaInfo()
		{
			return new XElement("packedfile",
				new XAttribute("path", Path),
				new XAttribute("name", FileName),
				new XElement("type", new XElement("number", (uint)Type.Item)),
				new XElement("classid", InstanceHigh),
				new XElement("group", Group),
				new XElement("instance", Instance));
		}

		public override string ToString()
		{
			return $"{TypeInfo.LongName}: {(uint)Type.Item:X8} - {InstanceHigh:X8} - {Group:X8} - {Instance:X8}";
		}

		public async void ReadContent()
		{
			if (Package.StorageFile == null || Offset == 0 || RawData != null)
			{
				return;
			}
			using Stream stream = await Package.StorageFile.OpenReadAsync();
			using BinaryReader reader = new(stream);
			reader.BaseStream.Seek(Offset, SeekOrigin.Begin);
			RawData = reader.ReadBytes(Size);
			if (Type.Item.ToFileTypeInformation().ContainsFileName)
			{
				OnPropertyChanged(nameof(DisplayName));
			}
			CheckCompressionStatus();
		}

		#region Compression

		public void CheckCompressionStatus()
		{
			if (RawData.Length < 9 || Type == FileTypes.CLST)
			{
				return;
			}
			ClstItem clstItem;
			Package.FindFiles(FileTypes.CLST, null, null, null)?.FirstOrDefault()?.ReadContent();
			if ((clstItem = Package.FindFiles(FileTypes.CLST, null, null, null)?.FirstOrDefault()?.Wrapper?.As<Clst.Clst>().Items.FirstOrDefault(item => item.Type == Type.Item && item.Group == Group && item.Instance == Instance && item.InstanceHigh == InstanceHigh)) != null)
			{
				IsCompressed = true;
				UncompressedSize = clstItem.UncompressedSize;
			}
			uint size = BinaryPrimitives.ReadUInt32LittleEndian(RawData);
			byte[] signature = [.. RawData[4..6]];
			uint uncompressedsize = (uint)((RawData[6] << 16) | (RawData[7] << 8) | RawData[8]);
			if (signature.SequenceEqual(new byte[] { 0x10, 0xFB }) && size == Size)
			{
				IsCompressed = true;
				UncompressedSize = uncompressedsize;
				Decompress();
			}
		}

		public void Decompress()
		{
			UncompressedData = new byte[UncompressedSize];
			int index = 9;
			int uncindex = 0;
			int source;
			int plaincount;

			while ((index < RawData.Length) && (RawData[index] < 0xfc))
			{
				byte cc = RawData[index++];

				int copycount;
				int copyoffset;
				byte cc1;
				byte cc2;
				if ((cc & 0x80) == 0)
				{
					cc1 = RawData[index++];
					plaincount = cc & 0x03;
					copycount = ((cc & 0x1C) >> 2) + 3;
					copyoffset = ((cc & 0x60) << 3) + cc1 + 1;
				}
				else if ((cc & 0x40) == 0)
				{
					cc1 = RawData[index++];
					cc2 = RawData[index++];
					plaincount = (cc1 & 0xC0) >> 6;
					copycount = (cc & 0x3F) + 4;
					copyoffset = ((cc1 & 0x3F) << 8) + cc2 + 1;
				}
				else if ((cc & 0x20) == 0)
				{
					cc1 = RawData[index++];
					cc2 = RawData[index++];
					byte cc3 = RawData[index++];
					plaincount = cc & 0x03;
					copycount = ((cc & 0x0C) << 6) + cc3 + 5;
					copyoffset = ((cc & 0x10) << 12) + (cc1 << 8) + cc2 + 1;
				}
				else
				{
					plaincount = (cc - 0xDF) << 2;
					copycount = 0;
					copyoffset = 0;
				}

				for (int i = 0; i < plaincount; i++)
				{
					UncompressedData[uncindex++] = RawData[index++];
				}

				source = uncindex - copyoffset;
				for (int i = 0; i < copycount; i++)
				{
					UncompressedData[uncindex++] = UncompressedData[source++];
				}
			}

			if (index < RawData.Length)
			{
				plaincount = RawData[index++] & 0x03;
				for (int i = 0; i < plaincount; i++)
				{
					if (uncindex >= UncompressedData.Length)
					{
						break;
					}
					UncompressedData[uncindex++] = RawData[index++];
				}
			}
			OnPropertyChanged(nameof(UncompressedDataDocument));
			if (Type.Item.ToFileTypeInformation().ContainsFileName)
			{
				OnPropertyChanged(nameof(DisplayName));
			}
		}

		public static byte[] Compress(byte[] data)
		{
			const int MAX_OFFSET = 0x20000;
			const int MAX_COPY_COUNT = 0x404;
			const int compstrength = 0x80;
			#region Init Variables
			//contains the latest offset for a combination of two characters
			List<List<int>> cmpmap = [];

			//will contain the compressed Data
			byte[] cdata = new byte[data.Length];

			//init some vars
			int writeindex = 0;
			int lastreadindex = 0;
			List<int> indexlist = null;
			int copyoffset = 0;
			int copycount;
			int index = -1;
			byte[] retdata;
			bool end = false;
			#endregion
			try
			{
				//begin main Compression Loop
				while (index < data.Length - 3)
				{
					#region get all Compression Candidates (list of offsets for all occurances of the current 3 bytes)
					do
					{
						index++;
						if (index >= data.Length - 2)
						{
							end = true;
							break;
						}
						int mapindex = data[index] | (data[index + 1] << 0x08) | (data[index + 2] << 0x10);

						indexlist = cmpmap[mapindex];
						if (indexlist == null)
						{
							indexlist = [];
							cmpmap[mapindex] = indexlist;
						}
						indexlist.Add(index);
					} while (index < lastreadindex);
					if (end)
					{
						break;
					}

					#endregion

					#region find the longest repeating byte sequence in the index List (for offset copy)
					int offsetcopycount = 0;
					int loopcount = 1;
					while ((loopcount < indexlist.Count) && (loopcount < compstrength))
					{
						int foundindex = indexlist[indexlist.Count - 1 - loopcount];
						if ((index - foundindex) >= MAX_OFFSET)
						{
							break;
						}

						loopcount++;
						copycount = 3;
						while ((data.Length > index + copycount) && (data[index + copycount] == data[foundindex + copycount]) && (copycount < MAX_COPY_COUNT))
						{
							copycount++;
						}

						if (copycount > offsetcopycount)
						{
							int cof = index - foundindex;
							offsetcopycount = copycount;
							copyoffset = index - foundindex;
						}
					}
					#endregion

					#region Compression

					//check if we can compress this
					if (offsetcopycount < 3 || ((offsetcopycount < 4) && (copyoffset > 0x400)) || ((offsetcopycount < 5) && (copyoffset > 0x4000)))
					{
						offsetcopycount = 0;
					}


					//this is offset-compressable? so do the compression
					if (offsetcopycount > 0)
					{
						//plaincopy
						while ((index - lastreadindex) > 3)
						{
							copycount = index - lastreadindex;
							while (copycount > 0x71)
							{
								copycount -= 0x71;
							}

							copycount &= 0xfc;
							int realcopycount = copycount >> 2;

							cdata[writeindex++] = (byte)(0xdf + realcopycount);
							for (int i = 0; i < copycount; i++)
							{
								cdata[writeindex++] = data[lastreadindex++];
							}
						}

						//offsetcopy
						copycount = index - lastreadindex;
						copyoffset--;
						if ((offsetcopycount <= 0xa) && (copyoffset < 0x400))
						{
							cdata[writeindex++] = (byte)(((copyoffset >> 3) & 0x60) | ((offsetcopycount - 3) << 2) | copycount);
							cdata[writeindex++] = (byte)(copyoffset & 0xff);
						}
						else if ((offsetcopycount <= 0x43) && (copyoffset < 0x4000))
						{
							cdata[writeindex++] = (byte)(0x80 | (offsetcopycount - 4));
							cdata[writeindex++] = (byte)((copycount << 6) | (copyoffset >> 8));
							cdata[writeindex++] = (byte)(copyoffset & 0xff);
						}
						else if ((offsetcopycount <= MAX_COPY_COUNT) && (copyoffset < MAX_OFFSET))
						{
							cdata[writeindex++] = (byte)(((0xc0 | ((copyoffset >> 0x0c) & 0x10)) + (((offsetcopycount - 5) >> 6) & 0x0c)) | copycount);
							cdata[writeindex++] = (byte)((copyoffset >> 8) & 0xff);
							cdata[writeindex++] = (byte)(copyoffset & 0xff);
							cdata[writeindex++] = (byte)((offsetcopycount - 5) & 0xff);
						}
						else
						{
							copycount = 0;
							offsetcopycount = 0;
						}

						//do the offset copy
						for (int i = 0; i < copycount; i++)
						{
							cdata[writeindex++] = data[lastreadindex++];
						}

						lastreadindex += offsetcopycount;
					}
					#endregion
				} //while (main Loop)

				#region Add remaining Data
				//add the End Record
				index = data.Length;
				lastreadindex = Math.Min(index, lastreadindex);
				while ((index - lastreadindex) > 3)
				{
					copycount = index - lastreadindex;
					while (copycount > 0x71)
					{
						copycount -= 0x71;
					}

					copycount &= 0xfc;
					int realcopycount = copycount >> 2;

					cdata[writeindex++] = (byte)(0xdf + realcopycount);
					for (int i = 0; i < copycount; i++)
					{
						cdata[writeindex++] = data[lastreadindex++];
					}
				}

				copycount = index - lastreadindex;
				cdata[writeindex++] = (byte)(0xfc + copycount);
				for (int i = 0; i < copycount; i++)
				{
					cdata[writeindex++] = data[lastreadindex++];
				}
				#endregion

				#region Trim Data & and add Header
				//make a resulting Array of the apropriate size
				retdata = new byte[writeindex + 9];

				byte[] sz = BitConverter.GetBytes((uint)(retdata.Length));
				for (int i = 0; i < 4; i++)
				{
					retdata[i] = sz[i];
				}

				sz = [0x10, 0xFB];
				for (int i = 0; i < 2; i++)
				{
					retdata[i + 4] = sz[i];
				}

				sz = BitConverter.GetBytes((uint)data.Length);
				for (int i = 0; i < 3; i++)
				{
					retdata[i + 6] = sz[2 - i];
				}

				for (int i = 0; i < writeindex; i++)
				{
					retdata[i + 9] = cdata[i];
				}
				#endregion
				return retdata;
			}
			finally
			{
				foreach (List<int> a in cmpmap)
				{
					a?.Clear();
				}
				indexlist?.Clear();
			}

		}
		#endregion

		internal void Wrapper_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			using MemoryStream memory = new();
			using BinaryWriter writer = new(memory);
			wrapper.Serialize(writer);
			UserData = memory.ToArray();
			if (Type.Item.ToFileTypeInformation().ContainsFileName || wrapper.FriendlyName != null)
			{
				OnPropertyChanged(nameof(DisplayName));
			}
		}
	}
}
