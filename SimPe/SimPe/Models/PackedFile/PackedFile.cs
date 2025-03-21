// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Buffers.Binary;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
		private FileTypes type;

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
		public FileTypeInformation TypeInfo => Type.ToFileTypeInformation();

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

		public string ExportFileName => $"{(uint)Type:X8}-{FileName}";

		public string DisplayName
		{
			get
			{
				if (wrapper != null && Wrapper.FriendlyName != null)
				{
					return Wrapper.FriendlyName;
				}
				else if (Type.ToFileTypeInformation().ContainsFileName)
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
					if (Wrappers.Unserializers.TryGetValue(Type, out Func<BinaryReader, PackedFile, IWrapper> func))
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

		public static PackedFile Unserialize(BinaryReader reader, PackageFile package)
		{
			PackedFile file = new(package)
			{
				Type = (FileTypes)reader.ReadUInt32(),
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

		public XElement GenerateXmlMetaInfo()
		{
			return new XElement("packedfile",
				new XAttribute("path", Path),
				new XAttribute("name", FileName),
				new XElement("type", new XElement("number", (uint)Type)),
				new XElement("classid", InstanceHigh),
				new XElement("group", Group),
				new XElement("instance", Instance));
		}

		public override string ToString()
		{
			return $"{TypeInfo.LongName}: {(uint)Type:X8} - {InstanceHigh:X8} - {Group:X8} - {Instance:X8}";
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
			if (Type.ToFileTypeInformation().ContainsFileName)
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
			if ((clstItem = Package.FindFiles(FileTypes.CLST, null, null, null)?.FirstOrDefault()?.Wrapper?.As<Clst.Clst>().Items.FirstOrDefault(item => item.Type == Type && item.Group == Group && item.Instance == Instance && item.InstanceHigh == InstanceHigh)) != null)
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
			if (Type.ToFileTypeInformation().ContainsFileName)
			{
				OnPropertyChanged(nameof(DisplayName));
			}
		}
		#endregion

		internal void Wrapper_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			using MemoryStream memory = new();
			using BinaryWriter writer = new(memory);
			wrapper.Serialize(writer);
			UserData = memory.ToArray();
			if (Type.ToFileTypeInformation().ContainsFileName || wrapper.FriendlyName != null)
			{
				OnPropertyChanged(nameof(DisplayName));
			}
		}
	}
}
