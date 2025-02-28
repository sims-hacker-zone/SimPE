// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.ComponentModel;

namespace SimPe.Plugin.Anim
{
	/// <summary>
	/// What type of Information is stored in the Token
	/// </summary>
	public enum AnimationTokenType : byte
	{
		/// <summary>
		/// One Short Value (0=transform parameter)
		/// </summary>
		TwoByte = 0,

		/// <summary>
		/// three Short Values (0=timecode, 1=transform parameter, 2=???)
		/// </summary>
		SixByte = 1,

		/// <summary>
		/// four short Values (0=timecode, 1=transform parameter, 2=???, 3=???)
		/// </summary>
		EightByte = 2,
	}

	/// <summary>
	/// What type of Information is stored in a Frame
	/// </summary>
	public enum FrameType : byte
	{
		/// <summary>
		/// Translations
		/// </summary>
		Translation = 0x10,

		/// <summary>
		/// Rotations
		/// </summary>
		Rotation = 0x0C,

		/// <summary>
		/// Unknown Type
		/// </summary>
		Unknown = 0xFF,
	}

	/// <summary>
	/// Base Class for common structures in the diffrent AnimBlock Formats
	/// </summary>
	public class AnimBlock
	{
		protected string name;

		[Description("Name of the selected Item")]
		public virtual string Name
		{
			get => name;
			set => name = value;
		}

		internal AnimBlock()
		{
			name = "";
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		internal int UnserializeName(System.IO.BinaryReader reader)
		{
			name = "";
			while (true)
			{
				char ch = reader.ReadChar();
				if (ch == 0)
				{
					break;
				}

				name += ch;
			}

			return name.Length + 1;
		}

		/// <summary>
		/// Serializes to a BinaryStream from the Attributes of this Instance
		/// </summary>
		/// <param name="writer">The Stream that receives the Data</param>
		internal int SerializeName(System.IO.BinaryWriter writer)
		{
			foreach (char c in name)
			{
				writer.Write(c);
			}

			writer.Write((byte)0);

			return name.Length + 1;
		}

		public override string ToString()
		{
			return name;
		}
	}

	/// <summary>
	/// Data is unknown
	/// </summary>
	public class AnimBlock4
	{
		#region Attributes
		[Browsable(false)]
		public AnimBlock5[] Part5
		{
			get; private set;
		}

		[
			Description("Number of loaded AnimBlock4 Items"),
			Category("Information")
		]
		public int Part5Count => Part5.Length;

		uint[] datai;

		[
			Description("Reserved"),
			Category("Reserved"),
			DefaultValue(0x11BA05F0)
		]
		public uint Unknown1
		{
			get => datai[0];
			set => datai[0] = value;
		}

		[
			Description("Reserved"),
			Category("Reserved"),
			DefaultValue(0x11BA05F0)
		]
		public uint Unknown2
		{
			get => datai[1];
			set => datai[1] = value;
		}

		[
			Description("Reserved"),
			Category("Reserved"),
			DefaultValue(0x11BA05F0)
		]
		public uint Unknown3
		{
			get => datai[2];
			set => datai[2] = value;
		}

		[Description(
			"On Index 2 the Number of assigned AnimBlock5 Items is stored"
		)]
		public byte[] AddonData
		{
			get; private set;
		}
		#endregion

		internal AnimBlock4()
		{
			datai = new uint[3];
			AddonData = new byte[0x3A];
			Part5 = new AnimBlock5[0];
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		internal void UnserializeData(System.IO.BinaryReader reader)
		{
			long pos = reader.BaseStream.Position;
			if (reader.BaseStream.Length - pos < 4 + 4 + AddonData.Length + 4)
			{
				return;
			}

			datai[0] = reader.ReadUInt32();
			datai[1] = reader.ReadUInt32();
			AddonData = reader.ReadBytes(AddonData.Length);
			datai[2] = reader.ReadUInt32();

			if (datai[2] != datai[1])
			{
				reader.BaseStream.Seek(pos, System.IO.SeekOrigin.Begin);
				return;
			}
		}

		/// <summary>
		/// Serializes to a BinaryStream from the Attributes of this Instance
		/// </summary>
		/// <param name="writer">The Stream that receives the Data</param>
		internal void SerializeData(System.IO.BinaryWriter writer)
		{
			SetPart5Count(Part5.Length);

			writer.Write(datai[0]);
			writer.Write(datai[1]);
			writer.Write(AddonData);
			writer.Write(datai[2]);
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		internal void UnserializePart5Data(System.IO.BinaryReader reader)
		{
			Part5 = new AnimBlock5[GetPart5Count()];
			for (int i = 0; i < Part5.Length; i++)
			{
				Part5[i] = new AnimBlock5();
				Part5[i].UnserializeData(reader);
			}
		}

		/// <summary>
		/// Serializes to a BinaryStream from the Attributes of this Instance
		/// </summary>
		/// <param name="writer">The Stream that receives the Data</param>
		internal void SerializePart5Data(System.IO.BinaryWriter writer)
		{
			for (int i = 0; i < Part5.Length; i++)
			{
				Part5[i].SerializeData(writer);
			}
		}

		/// <summary>
		/// Returns the Number of Items for Part 5 assigned to this Object
		/// </summary>
		/// <returns>Number of Items</returns>
		int GetPart5Count()
		{
			return AddonData[2];
		}

		/// <summary>
		/// Set the count for Part 5 Items
		/// </summary>
		/// <param name="ct">The New Count</param>
		void SetPart5Count(int ct)
		{
			if (ct > 0xff)
			{
				ct = 0xff;
			}

			AddonData[2] = (byte)(ct & 0xff);
		}

		public override string ToString()
		{
			return "AnimBlock4: "
				+ Part5Count.ToString()
				+ " "
				+ AddonData.Length.ToString();
		}
	}

	/// <summary>
	/// Data is unknown
	/// </summary>
	public class AnimBlock5
	{
		#region Attributes
		uint[] datai;

		[
			Description("Reserved"),
			Category("Reserved"),
			DefaultValue(0x11BA05F0)
		]
		public uint Unknown1
		{
			get => datai[0];
			set => datai[0] = value;
		}

		public uint Unknown2
		{
			get => datai[1];
			set => datai[1] = value;
		}

		public string Unknown2Binary
		{
			get
			{
				string s = Convert.ToString(Unknown2, 2);
				s = Helper.MinStrLength(s, 14);
				int p = s.Length - 4;
				while (p >= 0)
				{
					s = s.Insert(p, " ");
					p -= 4;
				}
				return s.Trim();
			}
		}

		public string Unknown2Hex => "0x" + Helper.HexString(Unknown2);

		public byte[] AddonData
		{
			get; private set;
		}
		#endregion

		internal AnimBlock5()
		{
			datai = new uint[2];
			AddonData = new byte[0x23];
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		/// <remarks>This is only a DEBUG Implementation!</remarks>
		internal void UnserializeData(System.IO.BinaryReader reader)
		{
			long pos = reader.BaseStream.Position;
			/*if (reader.BaseStream.Length-pos < 4+4+data.Length)
				return;*/

			datai[0] = reader.ReadUInt32();
			datai[1] = reader.ReadUInt32();
			AddonData = reader.ReadBytes(AddonData.Length);

			/*if (datai[0]!=0x11BA05F0 || datai[1]!=0x11BA05F0)
			{
				reader.BaseStream.Seek(pos, System.IO.SeekOrigin.Begin);
				return;
			}*/
		}

		/// <summary>
		/// Serializes to a BinaryStream from the Attributes of this Instance
		/// </summary>
		/// <param name="writer">The Stream that receives the Data</param>
		internal void SerializeData(System.IO.BinaryWriter writer)
		{
			writer.Write(datai[0]);
			writer.Write(datai[1]);
			writer.Write(AddonData);
		}

		public override string ToString()
		{
			return "0x"
				+ Helper.HexString(Unknown2)
				+ " "
				+ AddonData.Length.ToString();
		}
	}

	/// <summary>
	/// Data is unknown
	/// </summary>
	public class AnimBlock6 : AnimBlock
	{
		#region Attributes
		uint[] datai;

		[
			Description("Reserved"),
			Category("Reserved"),
			DefaultValue(0x11BA05F0)
		]
		public uint Unknown1
		{
			get => datai[0];
			set => datai[0] = value;
		}

		[
			Description("Reserved"),
			Category("Reserved"),
			DefaultValue(0x11BA05F0)
		]
		public uint Unknown2
		{
			get => datai[1];
			set => datai[1] = value;
		}

		short[] datas;
		public short SUnknown1
		{
			get => datas[0];
			set => datas[0] = value;
		}
		public short SUnknown2
		{
			get => datas[1];
			set => datas[1] = value;
		}
		public short SUnknown3
		{
			get => datas[2];
			set => datas[2] = value;
		}
		#endregion

		internal AnimBlock6()
		{
			datai = new uint[2];
			datas = new short[3];
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		internal void UnserializeData(System.IO.BinaryReader reader)
		{
			datai[0] = reader.ReadUInt32();

			datas[0] = reader.ReadInt16();
			datas[1] = reader.ReadInt16();
			datas[2] = reader.ReadInt16();

			datai[1] = reader.ReadUInt32();
		}

		/// <summary>
		/// Serializes to a BinaryStream from the Attributes of this Instance
		/// </summary>
		/// <param name="writer">The Stream that receives the Data</param>
		internal void SerializeData(System.IO.BinaryWriter writer)
		{
			writer.Write(datai[0]);

			writer.Write(datas[0]);
			writer.Write(datas[1]);
			writer.Write(datas[2]);

			writer.Write(datai[1]);
		}
	}
}
