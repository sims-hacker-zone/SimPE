// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;
using System.Drawing;

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
	public class Lot
		: AbstractWrapper //Implements some of the default Behaviur of a Handler, you can Implement yourself if you want more flexibility!
			,
			IFileWrapper //This Interface is used when loading a File
			,
			IFileWrapperSaveExtension //This Interface (if available) will be used to store a File
									  //,IPackedFileProperties		//This Interface can be used by thirdparties to retrive the FIleproperties, however you don't have to implement it!
	{
		#region Attributes
		byte[] filename = null;
		ushort subver = 0;
		Size sz;
		Ltxt.Rotation rotation = Ltxt.Rotation.toLeft;
		#endregion

		#region Accessor methods
		public string FileName
		{
			get => Helper.ToString(filename);
			set => filename = Helper.ToBytes(value, 0x40);
		}
		public LtxtSubVersion SubVersion
		{
			get => (LtxtSubVersion)subver;
			set => subver = (ushort)value;
		}
		public Size LotSize
		{
			get => sz;
			set => sz = value;
		}
		public Ltxt.LotType Type { get; set; } = Ltxt.LotType.Residential;
		public byte LotRoads { get; set; } = 0x00;
		public byte LotRotation
		{
			get => (byte)rotation;
			set => rotation = (Ltxt.Rotation)value;
		}
		internal uint Unknown0 { get; set; } = 0;
		public string LotName { get; set; } = "";
		public string LotDesc { get; set; } = "";
		internal List<uint> Unknown1
		{
			get; private set;
		}
		internal float Unknown2 { get; private set; } = 0f;
		internal uint Unknown3 { get; private set; } = 0;
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public Lot()
			: base()
		{
			filename = new byte[64];
			sz = new Size(1, 1);
			Unknown1 = new List<uint>();
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
			return new LoteUI();
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Lot Wrapper",
				"Peter L Jones",
				"Lot package lot descriptor.",
				1,
				Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.ltxt.png")
				)
			);
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			filename = reader.ReadBytes(0x40);
			subver = reader.ReadUInt16();
			sz.Width = reader.ReadInt32();
			sz.Height = reader.ReadInt32();
			Type = (Ltxt.LotType)reader.ReadByte();

			LotRoads = reader.ReadByte();
			rotation = (Ltxt.Rotation)reader.ReadByte();
			Unknown0 = reader.ReadUInt32();

			LotName = reader.ReadString();
			LotDesc = reader.ReadString();

			Unknown1 = new List<uint>();
			int len = reader.ReadInt32();
			for (int i = 0; i < len; i++)
			{
				Unknown1.Add(reader.ReadUInt32());
			}

			Unknown2 = subver >= (ushort)LtxtSubVersion.Voyage ? reader.ReadSingle() : 0;

			Unknown3 = subver >= (ushort)LtxtSubVersion.Freetime ? reader.ReadUInt32() : 0;
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
			writer.Write(filename);
			writer.Write(subver);
			writer.Write(sz.Width);
			writer.Write(sz.Height);
			writer.Write((byte)Type);

			writer.Write(LotRoads);
			writer.Write((byte)rotation);
			writer.Write(Unknown0);

			writer.Write(LotName);
			writer.Write(LotDesc);

			writer.Write(Unknown1.Count);
			foreach (uint i in Unknown1)
			{
				writer.Write(i);
			}

			if (subver >= (ushort)LtxtSubVersion.Voyage)
			{
				writer.Write(Unknown2);
			}

			if (subver >= (ushort)LtxtSubVersion.Freetime)
			{
				writer.Write(Unknown3);
			}
		}
		#endregion

		#region IFileWrapperSaveExtension Member
		//all covered by Serialize()
		#endregion

		public const uint Lottype = 0x6C589723;

		#region IFileWrapper Member

		/// <summary>
		/// Returns the Signature that can be used to identify Files processable with this Plugin
		/// </summary>
		public byte[] FileSignature => new byte[0];

		/// <summary>
		/// Returns a list of File Type this Plugin can process
		/// </summary>
		public uint[] AssignableTypes => new uint[] { Lottype };

		#endregion

		protected override string GetResourceName(Data.TypeAlias ta)
		{
			if (!Processed)
			{
				ProcessData(FileDescriptor, Package);
			}

			return LotName;
		}
	}
}
