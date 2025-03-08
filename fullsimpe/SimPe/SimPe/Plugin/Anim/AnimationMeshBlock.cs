// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;
using System.ComponentModel;

using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin.Anim
{
	/// <summary>
	/// Data is unknown
	/// </summary>
	public class AnimationMeshBlock : AnimBlock
	{
		#region Attributes
		public Rcol Parent
		{
			get;
		}

		public AnimResourceConst Animation => (AnimResourceConst)Parent.Blocks[0];

		[Browsable(false)]
		public List<AnimationFrameBlock> Part2
		{
			get; set;
		}

		[
			Description("Number of loaded AnimationFrameBlock Items"),
			Category("Information")
		]
		public int Part2Count => Part2.Count;

		[Browsable(false)]
		public List<AnimBlock4> Part4
		{
			get; private set;
		}

		[
			Description("Number of loaded AnimBlock4 Items"),
			Category("Information")
		]
		public int Part4Count => Part4.Count;

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

		[
			Description("Reserved"),
			Category("Reserved"),
			DefaultValue(0x11BA05F0)
		]
		public uint Unknown4
		{
			get => datai[3];
			set => datai[3] = value;
		}

		[
			Description("Reserved"),
			Category("Reserved"),
			DefaultValue(0x11BA05F0)
		]
		public uint Unknown5
		{
			get => datai[4];
			set => datai[4] = value;
		}

		short[] datas;
		public short SUnknown1
		{
			get => datas[0];
			set => datas[0] = value;
		}

		[Description("Number of assigned AnimationFrameBlock Items")]
		public short AnimatedBoneCount => datas[1];

		[Description(
			"Lower 6 Bits(?) are reserved for the Number of assigned AnimBlock4 Items"
		)]
		public short SUnknown3
		{
			get => datas[2];
			set => datas[2] = value;
		}
		public short SUnknown4
		{
			get => datas[3];
			set => datas[3] = value;
		}
		#endregion

		internal AnimationMeshBlock(Rcol parent)
		{
			datai = new uint[6];
			datas = new short[4];
			Part2 = new List<AnimationFrameBlock>();
			Part4 = new List<AnimBlock4>();
			Parent = parent;
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		internal void UnserializeData(System.IO.BinaryReader reader)
		{
			datai[0] = reader.ReadUInt32();
			datai[1] = reader.ReadUInt32();

			datas[0] = reader.ReadInt16();
			datas[1] = reader.ReadInt16(); //number of ab2 Items
			datas[2] = reader.ReadInt16(); //number of ab4 Items (and some unknown Bits)
			datas[3] = reader.ReadInt16();

			datai[2] = reader.ReadUInt32();
			datai[3] = reader.ReadUInt32();
			datai[4] = reader.ReadUInt32();
		}

		/// <summary>
		/// Serializes to a BinaryStream from the Attributes of this Instance
		/// </summary>
		/// <param name="writer">The Stream that receives the Data</param>
		internal void SerializeData(System.IO.BinaryWriter writer)
		{
			SetPart2Count(Part2Count);
			SetPart4Count(Part4Count);

			writer.Write(datai[0]);
			writer.Write(datai[1]);

			writer.Write(datas[0]);
			writer.Write(datas[1]);
			writer.Write(datas[2]);
			writer.Write(datas[3]);

			writer.Write(datai[2]);
			writer.Write(datai[3]);
			writer.Write(datai[4]);
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		internal void UnserializePart2Data(System.IO.BinaryReader reader)
		{
			Part2 = new List<AnimationFrameBlock>();
			for (int i = 0; i < GetPart2Count(); i++)
			{
				Part2.Add(new AnimationFrameBlock(this));
				Part2[i].UnserializeData(reader);
			}
		}

		/// <summary>
		/// Serializes to a BinaryStream from the Attributes of this Instance
		/// </summary>
		/// <param name="writer">The Stream that receives the Data</param>
		internal void SerializePart2Data(System.IO.BinaryWriter writer)
		{
			for (int i = 0; i < Part2.Count; i++)
			{
				Part2[i].SerializeData(writer);
			}
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		internal int UnserializePart2Name(System.IO.BinaryReader reader)
		{
			int len = 0;
			for (int i = 0; i < Part2.Count; i++)
			{
				len += Part2[i].UnserializeName(reader);
			}

			return len;
		}

		/// <summary>
		/// Serializes to a BinaryStream from the Attributes of this Instance
		/// </summary>
		/// <param name="writer">The Stream that receives the Data</param>
		internal int SerializePart2Name(System.IO.BinaryWriter writer)
		{
			int len = 0;
			for (int i = 0; i < Part2.Count; i++)
			{
				len += Part2[i].SerializeName(writer);
			}

			return len;
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		internal void UnserializePart3Data(System.IO.BinaryReader reader)
		{
			for (int i = 0; i < Part2.Count; i++)
			{
				Part2[i].UnserializePart3Data(reader);
			}
		}

		/// <summary>
		/// Serializes to a BinaryStream from the Attributes of this Instance
		/// </summary>
		/// <param name="writer">The Stream that receives the Data</param>
		internal void SerializePart3Data(System.IO.BinaryWriter writer)
		{
			for (int i = 0; i < Part2.Count; i++)
			{
				Part2[i].SerializePart3Data(writer);
			}
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		internal void UnserializePart3AddonData(System.IO.BinaryReader reader)
		{
			for (int i = 0; i < Part2.Count; i++)
			{
				Part2[i].UnserializePart3AddonData(reader);
			}
		}

		/// <summary>
		/// Serializes to a BinaryStream from the Attributes of this Instance
		/// </summary>
		/// <param name="writer">The Stream that receives the Data</param>
		internal void SerializePart3AddonData(System.IO.BinaryWriter writer)
		{
			for (int i = 0; i < Part2.Count; i++)
			{
				Part2[i].SerializePart3AddonData(writer);
			}
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		internal void UnserializePart4Data(System.IO.BinaryReader reader)
		{
			Part4 = new List<AnimBlock4>();
			for (int i = 0; i < GetPart4Count(); i++)
			{
				Part4.Add(new AnimBlock4());
				Part4[i].UnserializeData(reader);
			}
		}

		/// <summary>
		/// Serializes to a BinaryStream from the Attributes of this Instance
		/// </summary>
		/// <param name="writer">The Stream that receives the Data</param>
		internal void SerializePart4Data(System.IO.BinaryWriter writer)
		{
			for (int i = 0; i < Part4.Count; i++)
			{
				Part4[i].SerializeData(writer);
			}
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		internal void UnserializePart5Data(System.IO.BinaryReader reader)
		{
			for (int i = 0; i < Part4.Count; i++)
			{
				Part4[i].UnserializePart5Data(reader);
			}
		}

		/// <summary>
		/// Serializes to a BinaryStream from the Attributes of this Instance
		/// </summary>
		/// <param name="writer">The Stream that receives the Data</param>
		internal void SerializePart5Data(System.IO.BinaryWriter writer)
		{
			for (int i = 0; i < Part4.Count; i++)
			{
				Part4[i].SerializePart5Data(writer);
			}
		}

		/// <summary>
		/// Returns the Number of Items for Part 2 assigned to this Object
		/// </summary>
		/// <returns>Number of Items</returns>
		int GetPart2Count()
		{
			return datas[1];
		}

		/// <summary>
		/// Set the count for Part 5 Items
		/// </summary>
		/// <param name="ct">The New Count</param>
		void SetPart2Count(int ct)
		{
			datas[1] = (short)ct;
		}

		/// <summary>
		/// Returns the Number of Items for Part 4 assigned to this Object
		/// </summary>
		/// <returns>Number of Items</returns>
		int GetPart4Count()
		{
			return datas[2] & 0x3f;
		}

		/// <summary>
		/// Set the count for Part 5 Items
		/// </summary>
		/// <param name="ct">The New Count</param>
		void SetPart4Count(int ct)
		{
			if (ct > 0x3f)
			{
				ct = 0x3f;
			}

			ct &= 0x3f;

			datas[2] = (short)(datas[2] & 0x0000FFC0);
			datas[2] = (short)((ushort)datas[2] | (ushort)ct);
		}

		protected GenericRcol FindDefiningCRES(
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile pkg
		)
		{
			GenericRcol rcol = new GenericRcol().ProcessFile(pfd, pkg);

			ResourceNode rn = (ResourceNode)rcol.Blocks[0];
			foreach (int i in rn.ChildBlocks)
			{
				Interfaces.Scenegraph.ICresChildren icc = rn.GetBlock(i);

				if (icc != null && icc.StoredTransformNode != null && icc.StoredTransformNode.ObjectGraphNode.FileName
						== Name
)
				{
					return rcol;
				}
			}
			return null;
		}

		public GenericRcol FindDefiningCRES()
		{
			Interfaces.Files.IPackedFileDescriptor[] pfds =
				Parent.Package.FindFiles(Data.FileTypes.CRES);
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				GenericRcol rcol = FindDefiningCRES(pfd, Parent.Package);
				if (rcol != null)
				{
					return rcol;
				}
			}

			if (
				Name == "auskel"
				|| Name == "tuskel"
				|| Name == "cuskel"
				|| Name == "puskel"
				|| Name == "buskel"
			)
			{
				FileTableBase.FileIndex.Load();
				foreach (
					Interfaces.Scenegraph.IScenegraphFileIndexItem item in FileTableBase.FileIndex.FindFile(Data.FileTypes.CRES, true)
				)
				{
					GenericRcol rcol = FindDefiningCRES(
						item.FileDescriptor,
						item.Package
					);
					if (rcol != null)
					{
						return rcol;
					}
				}
			}
			return null;
		}

		public GenericRcol FindUsedGMDC(GenericRcol cres)
		{
			if (cres == null)
			{
				return null;
			}

			Interfaces.Scenegraph.IScenegraphFileIndexItem item =
				cres.FindReferencedType(Data.FileTypes.SHPE);
			if (item != null)
			{
				GenericRcol rcol = new GenericRcol().ProcessFile(item);

				item = rcol.FindReferencedType(Data.FileTypes.GMND);
				if (item != null)
				{
					rcol.ProcessData(item);
					item = rcol.FindReferencedType(Data.FileTypes.GMDC);
					if (item != null)
					{
						rcol.ProcessData(item);
						return rcol;
					}
				}
			}
			// the 'skel cres used by all sim animations don't have meshes so we point to the default naked body meshes instaed
			if (
				Name == "auskel"
				|| Name == "tuskel"
				|| Name == "cuskel"
				|| Name == "puskel"
				|| Name == "buskel"
			)
			{
				FileTableBase.FileIndex.Load();
				ulong instns = 0xCCBC1AF8FFE2EDE9; //auskel
				if (Name == "tuskel")
				{
					instns = 0x9C1686E9FF68B810;
				}
				else if (Name == "cuskel")
				{
					instns = 0xB7C67187FF38EF7F;
				}
				else if (Name == "puskel")
				{
					instns = 0xFF5F4C89AE871D44;
				}
				else if (Name == "buskel")
				{
					instns = 0x57D5D2CDFF545BA9;
				}

				foreach (
					Interfaces.Scenegraph.IScenegraphFileIndexItem iteme in FileTableBase.FileIndex.FindFile(
						Data.FileTypes.GMDC,
						0x1C0532FA,
						instns,
						Parent.Package
					)
				)
				{
					if (iteme != null)
					{
						return new GenericRcol().ProcessFile(iteme);
					}
				}
			}
			return null;
		}

		/// <summary>
		/// Returns the first transformation for the given name and type
		/// </summary>
		/// <param name="name"></param>
		/// <param name="type"></param>
		/// <returns>null or the matching Block</returns>
		public AnimationFrameBlock GetJointTransformation(string name, FrameType type)
		{
			foreach (AnimationFrameBlock ab in Part2)
			{
				if (
					ab.Name == name
					&& ab.TransformationType == type
					&& ab.AxisCount == 3
				)
				{
					return ab;
				}
			}

			return null;
		}
	}
}
