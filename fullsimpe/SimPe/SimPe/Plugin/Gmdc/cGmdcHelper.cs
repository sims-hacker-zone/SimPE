// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;
namespace SimPe.Plugin.Gmdc
{
	/// <summary>
	/// Sets the Typf of the Items stored in <see cref="GmdcElement.Values"/>.
	/// </summary>
	public enum BlockFormat : uint
	{
		/// <summary>
		/// <see cref="GmdcElement.Values"/> Member contains <see cref="GmdcElementValueOneFloat"/> Items
		/// </summary>
		OneFloat = 0x00,

		/// <summary>
		/// <see cref="GmdcElement.Values"/> Member contains <see cref="GmdcElementValueTwoFloat"/> Items
		/// </summary>
		TwoFloat = 0x01,

		/// <summary>
		/// <see cref="GmdcElement.Values"/> Member contains <see cref="GmdcElementValueThreeFloat"/> Items
		/// </summary>
		ThreeFloat = 0x02,

		/// <summary>
		/// <see cref="GmdcElement.Values"/> Member contains <see cref="GmdcElementValueOneInt"/> Items
		/// </summary>
		OneDword = 0x04,

		/// <summary>
		/// internal used to determin unknown Formats
		/// </summary>
		Unknown = 0xff,
	}

	/// <summary>
	/// The Kind of the stored Faces
	/// </summary>
	public enum PrimitiveType : uint
	{
		/// <summary>
		/// Faces are made from three Vertices (Triangles)
		/// </summary>
		Triangle = 0x02,

		/// <summary>
		/// internal used to determin unknown Formats
		/// </summary>
		Unknown = 0xff,
	}

	/// <summary>
	/// Determins the class of a <see cref="GmdcElement"/> Section
	/// </summary>
	public enum SetFormat : uint
	{
		/// <summary>
		/// Stores Data for the main Mesh
		/// </summary>
		Main = 0x00,

		/// <summary>
		/// Stores Normals
		/// </summary>
		Normals = 0x01,

		/// <summary>
		/// Stores UVCoordinates and Mapping stuff
		/// </summary>
		Mapping = 0x02,

		/// <summary>
		/// Stores undetermined Data
		/// </summary>
		Secondary = 0x03,

		/// <summary>
		/// internal used to determin unknown Formats
		/// </summary>
		Unknown = 0xff,
	}

	/// <summary>
	/// Used to determin what Data is represented by a <see cref="GmdcElement"/>
	/// </summary>
	public enum ElementIdentity : uint
	{
		/// <summary>
		/// internal used to determin unknown Formats
		/// </summary>
		Unknown = 0,

		/// <summary>
		/// ?
		/// </summary>
		BlendIndex = 0x1C4AFC56,

		/// <summary>
		/// Weight of the Blend
		/// </summary>
		BlendWeight = 0x5C4AFC5C,

		/// <summary>
		/// ?
		/// </summary>
		TargetIndex = 0x7C4DEE82,

		/// <summary>
		/// ?
		/// </summary>
		NormalMorphDelta = 0xCB6F3A6A,

		/// <summary>
		/// ?
		/// </summary>
		Color = 0xCB7206A1,

		/// <summary>
		/// ?
		/// </summary>
		ColorDelta = 0xEB720693,

		/// <summary>
		/// Mesh Normals
		/// </summary>
		Normal = 0x3B83078B,

		/// <summary>
		/// Mesh Vertices
		/// </summary>
		Vertex = 0x5B830781,

		/// <summary>
		/// UV-Mapping Coordinates (also known as ST-Coordinates)
		/// </summary>
		UVCoordinate = 0xBB8307AB,

		/// <summary>
		/// ?
		/// </summary>
		UVCoordinateDelta = 0xDB830795,

		/// <summary>
		/// ?
		/// </summary>
		Binormals = 0x9BB38AFB,

		/// <summary>
		/// The influence of a Bone to a Vertex
		/// </summary>
		BoneWeights = 0x3BD70105,

		/// <summary>
		/// The assigned Joints
		/// </summary>
		BoneAssignment = 0xFBD70111,

		/// <summary>
		/// Normals fpr BumpMapping
		/// </summary>
		BumpMapNormal = 0x89D92BA0,

		/// <summary>
		/// ?
		/// </summary>
		BumpMapNormalDelta = 0x69D92B93,

		/// <summary>
		/// ?
		/// </summary>
		MorphVertexDelta = 0x5CF2CFE1,

		/// <summary>
		/// ?
		/// </summary>
		MorphVertexMap = 0xDCF2CFDC,
	}

	/// <summary>
	/// Contains Methods to process typical Gmdc Block Tasks
	/// </summary>
	public class GmdcLinkBlock
	{
		/// <summary>
		/// Contains the <see cref="GeometryDataContainer"/> (=Gmdc Ressource) which is defining this Item
		/// </summary>
		protected GeometryDataContainer parent;

		/// <summary>
		/// Sets the currently assigned Parent
		/// </summary>
		internal GeometryDataContainer Parent
		{
			get => parent;
			set => parent = value;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		public GmdcLinkBlock(GeometryDataContainer parent)
		{
			this.parent = parent;
		}

		/// <summary>
		/// Read the value from the Stream
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		protected int ReadValue(System.IO.BinaryReader reader)
		{
			return parent.Version == 0x04 ? reader.ReadInt16() : reader.ReadInt32();
		}

		/// <summary>
		/// Write the value to the Stream
		/// </summary>
		/// <param name="writer"></param>
		/// <param name="val"></param>
		protected void WriteValue(System.IO.BinaryWriter writer, int val)
		{
			if (parent.Version == 0x04)
			{
				writer.Write((short)val);
			}
			else
			{
				writer.Write(val);
			}
		}

		/// <summary>
		/// Read a Link Block
		/// </summary>
		/// <param name="reader"></param>
		/// <param name="items"></param>
		protected void ReadBlock(System.IO.BinaryReader reader, List<int> items)
		{
			int count = reader.ReadInt32();
			items.Clear();
			for (int i = 0; i < count; i++)
			{
				items.Add(ReadValue(reader));
			};
		}

		/// <summary>
		/// Write a Link Block
		/// </summary>
		/// <param name="writer"></param>
		/// <param name="items"></param>
		protected void WriteBlock(System.IO.BinaryWriter writer, List<int> items)
		{
			writer.Write(items.Count);
			for (int i = 0; i < items.Count; i++)
			{
				WriteValue(writer, items[i]);
			}
		}
	}
}
