using System;

using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class TreesPackedFileWrapper
		: AbstractWrapper,
			IFileWrapper,
			IFileWrapperSaveExtension
	{
		#region Attribute
		/// <summary>
		/// Contains the Data of the File
		/// </summary>
		private uint tmpo;
		private int count = 0;
		private byte len;
		private ushort lon;
		private byte chrc;
		private string[] items;

		public Array vdata = Array.CreateInstance(typeof(uint), 10, 64);

		public uint Vershin { get; set; } = 69;
		internal uint Header { get; set; } = 0x54524545;
		internal uint Unk0 { get; set; } = 5;
		internal uint Unk1 { get; set; } = 0;
		internal uint Unk2 { get; set; } = 0x83;
		internal uint Unk3 { get; set; } = 0x280;
		internal uint Unk4 { get; set; } = 0x490;
		internal uint Unk5 { get; set; } = 0x0f83c946;
		public string FileNam { get; set; } = "";

		/// <summary>
		/// Returns/Sets the Comments in the File
		/// </summary>
		public string[] Items
		{
			get
			{
				return items;
			}
			set
			{
				items = value;
			}
		}

		/// <summary>
		/// Returns/Sets the Amount of data
		/// </summary>
		public int Count
		{
			get
			{
				return count;
			}
			set
			{
				count = value;
				Array.Resize<string>(ref items, value);
			}
		}

		#endregion

		#region external operations

		public void MoveComment(int from, int too)
		{
			if (from < 0 || from > Count - 1)
				return;
			if (too < 0 || too > Count - 1)
				return;
			if (from == too)
				return;
			string twine = Items[from];
			Items[from] = Items[too];
			Items[too] = twine;
		}

		public void WriteComment(int indx, string comment)
		{
			if (indx < 0 || indx > Count - 1)
				return;
			Items[indx] = comment;
		}

		public string ReadComment(int indx)
		{
			if (indx < 0 || indx > Count - 1)
				return "";
			return Items[indx];
		}

		public void AddBlock()
		{
			Count++;
			Array.Resize<string>(ref items, Count);
			items[Count - 1] = "";
		}

		public void DeleteBlock()
		{
			if (Count < 1)
				return;
			Count--;
			Array.Resize<string>(ref items, Count);
		}

		public SimPe.Interfaces.Plugin.Internal.IPackedFileWrapper SiblingResource(
			uint type
		)
		{
			if (FileDescriptor == null)
				return null;
			pjse.FileTable.Entry[] items = pjse.FileTable.GFT[
				type,
				FileDescriptor.Group,
				FileDescriptor.Instance
			];
			if (items == null || items.Length == 0)
				return null;
			SimPe.Interfaces.Plugin.Internal.IPackedFileWrapper wrp =
				SimPe.FileTable.WrapperRegistry.FindHandler(type);
			wrp.ProcessData(items[0].PFD, items[0].Package);
			return wrp;
		}

		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public TreesPackedFileWrapper()
			: base()
		{
			///
			/// Add your Contructor Stuff here (if needed)
			///
		}

		#region IWrapper member
		public override bool CheckVersion(uint version)
		{
			return true;
		}
		#endregion

		#region AbstractWrapper Member
		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new TreesPackedFileUI();
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Edith Flowchart Trees Wrapper",
				"Chris",
				"To Read Edith Flowchart Tree files",
				1,
				SimPe.GetIcon.Writable
			);
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			FileNam = Helper.ToString(reader.ReadBytes(0x40));
			Vershin = reader.ReadUInt32();
			Unk0 = reader.ReadUInt32();
			Header = reader.ReadUInt32();
			Unk1 = reader.ReadUInt32();
			Unk2 = reader.ReadUInt32();
			Unk3 = reader.ReadUInt32();
			Unk4 = reader.ReadUInt32();
			count = reader.ReadInt32();
			Array.Resize<string>(ref items, count);
			Unk5 = reader.ReadUInt32();
			/*
			 * strings always terminate with 0000, the first Zero1 is probably part of the header, after that they are at the end as terminater
			 * some strings have two byte for len, can'r see where that is set, sometimes the two bytes are not correct for the length, just read till the terminater
			 * it is not always following Windows convention for 2 bytes for length, am using two bytes for strings > 128 for now
			*/
			if (Vershin == 69)
			{
				for (int i = 0; i < count; i++)
				{
					items[i] = reader.ReadString();
					tmpo = reader.ReadUInt32(); // terminater Byte
				}
			}
			else
			{
				for (int i = 0; i < Math.Min(64, count); i++)
				{
					vdata.SetValue(reader.ReadUInt32(), 0, i);
					vdata.SetValue(Convert.ToUInt32(reader.ReadUInt16()), 1, i);
					vdata.SetValue(Convert.ToUInt32(reader.ReadUInt16()), 2, i);
					vdata.SetValue(Convert.ToUInt32(reader.ReadUInt16()), 3, i);
					vdata.SetValue(Convert.ToUInt32(reader.ReadUInt16()), 4, i);
					vdata.SetValue(Convert.ToUInt32(reader.ReadUInt16()), 5, i);
					vdata.SetValue(Convert.ToUInt32(reader.ReadUInt16()), 6, i);
					vdata.SetValue(Convert.ToUInt32(reader.ReadUInt16()), 7, i);
					vdata.SetValue(Convert.ToUInt32(reader.ReadUInt16()), 8, i);
					vdata.SetValue(Convert.ToUInt32(reader.ReadUInt16()), 9, i);
					len = reader.ReadByte();
					items[i] = "";
					if (len > 0)
					{
						chrc = 6;
						while (chrc != 0)
						{
							chrc = reader.ReadByte();
							if (chrc != 0)
								items[i] += Convert.ToChar(chrc);
						}
						reader.BaseStream.Seek(3, System.IO.SeekOrigin.Current);
						if (items[i].Length > 128)
							items[i] = items[i].Substring(1, items[i].Length - 1);
					}
					else
						tmpo = reader.ReadUInt32(); // terminater Byte
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
		protected override void Serialize(System.IO.BinaryWriter writer)
		{
			writer.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
			foreach (char c in FileNam)
				writer.Write(c);
			writer.BaseStream.Seek(0x40, System.IO.SeekOrigin.Begin);
			writer.Write(Vershin);
			writer.Write(Unk0);
			writer.Write(Header);
			writer.Write(Unk1);
			writer.Write(Unk2);
			writer.Write(Unk3);
			writer.Write(Unk4);
			writer.Write(count);
			writer.Write(Unk5);
			if (Vershin == 69)
			{
				for (int i = 0; i < count; i++)
				{
					writer.Write(items[i]);
					writer.Write((int)0);
				}
			}
			else
			{
				if (count > 0)
				{
					for (int i = 0; i < count; i++)
					{
						writer.Write(Convert.ToUInt32(vdata.GetValue(0, i)));
						writer.Write(Convert.ToUInt16(vdata.GetValue(1, i)));
						writer.Write(Convert.ToUInt16(vdata.GetValue(2, i)));
						writer.Write(Convert.ToUInt16(vdata.GetValue(3, i)));
						writer.Write(Convert.ToUInt16(vdata.GetValue(4, i)));
						writer.Write(Convert.ToUInt16(vdata.GetValue(5, i)));
						writer.Write(Convert.ToUInt16(vdata.GetValue(6, i)));
						writer.Write(Convert.ToUInt16(vdata.GetValue(7, i)));
						writer.Write(Convert.ToUInt16(vdata.GetValue(8, i)));
						writer.Write(Convert.ToUInt16(vdata.GetValue(9, i)));
						if (items[i].Length > 128)
						{
							lon = Convert.ToUInt16(items[i].Length + 256); // ensure len is not read as zero later
							writer.Write(lon);
							foreach (char c in items[i])
								writer.Write(c);
						}
						else
						{
							len = Convert.ToByte(items[i].Length);
							writer.Write(len);
							foreach (char c in items[i])
								writer.Write(c);
						}
						writer.Write((int)0);
					}
				}
			}
		}

		#endregion

		#region IFileWrapperSaveExtension Member
		//all covered by Serialize()
		#endregion

		#region IFileWrapper Member

		/// <summary>
		/// Returns the Signature that can be used to identify Files processable with this Plugin
		/// </summary>
		public byte[] FileSignature => new byte[0];

		/// <summary>
		/// Returns a list of File Type this Plugin can process
		/// </summary>
		public uint[] AssignableTypes
		{
			get
			{
				uint[] types = { 0x54524545 }; //handles Edith Flowchart Trees
				return types;
			}
		}

		#endregion
	}
}
