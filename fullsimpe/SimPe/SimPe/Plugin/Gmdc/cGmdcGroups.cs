// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace SimPe.Plugin.Gmdc
{
	/// <summary>
	/// Know Values for Mesh Opacity
	/// </summary>
	public enum MeshOpacity : uint
	{
		/// <summary>
		/// Unknown Format
		/// </summary>
		Unknown = 0,

		/// <summary>
		/// Marks a solid Mesh
		/// </summary>
		Opaque = 0xffffffff,

		/// <summary>
		/// Marks a Shadow or Highlight Mesh
		/// </summary>
		Shadow = 0x00000003,
	}

	/// <summary>
	/// Contains the Group Section of a GMDC
	/// </summary>
	public class GmdcGroup : GmdcLinkBlock
	{
		#region Attributes

		/// <summary>
		/// Determins the Primitive Type of the Faces
		/// </summary>
		public PrimitiveType PrimitiveType
		{
			get; set;
		}

		/// <summary>
		/// The Index of the <see cref="GmdcLink"/> Object that is referenced by this Group. (Index into the <see cref="GeometryDataContainer.Links"/> Property.
		/// </summary>
		public int LinkIndex
		{
			get; set;
		}

		/// <summary>
		/// The Link Element
		/// </summary>
		public GmdcLink Link => parent == null || LinkIndex < 0 || LinkIndex >= parent.Links.Count ? null : parent.Links[LinkIndex];

		/// <summary>
		/// The Name of this Group
		/// </summary>
		public string Name
		{
			get; set;
		}

		/// <summary>
		/// The Index of the used Vertices
		/// </summary>
		public List<int> Faces
		{
			get; set;
		}

		/// <summary>
		/// The opacity of this Group (0=transparent; 3=shadow; -1=opaque)
		/// </summary>
		public uint Opacity
		{
			get; set;
		}

		/// <summary>
		/// List all Joints used by this Group
		/// </summary>
		public List<int> UsedJoints
		{
			get; set;
		}
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public GmdcGroup(GeometryDataContainer parent)
			: base(parent)
		{
			Faces = new List<int>();
			UsedJoints = new List<int>();
			Name = "";
			LinkIndex = -1;
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		public void Unserialize(System.IO.BinaryReader reader)
		{
			PrimitiveType = (PrimitiveType)reader.ReadUInt32();
			LinkIndex = reader.ReadInt32();
			Name = reader.ReadString();

			ReadBlock(reader, Faces);

			Opacity = parent.Version != 0x03 ? reader.ReadUInt32() : 0;

			if (parent.Version != 0x01)
			{
				ReadBlock(reader, UsedJoints);
			}
			else
			{
				UsedJoints.Clear();
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
			writer.Write((uint)PrimitiveType);
			writer.Write(LinkIndex);
			writer.Write(Name);

			WriteBlock(writer, Faces);

			if (parent.Version != 0x03)
			{
				writer.Write(Opacity);
			}

			if (parent.Version != 0x01)
			{
				WriteBlock(writer, UsedJoints);
			}
		}

		/// <summary>
		/// The Face Count for this Group
		/// </summary>
		public int FaceCount => Faces.Count / 3;

		/// <summary>
		/// The Number of diffrent Vertices used by this Group
		/// </summary>
		public int UsedVertexCount
		{
			get
			{
				Hashtable refs = new Hashtable();
				foreach (int i in Faces)
				{
					if (!refs.ContainsKey(i))
					{
						refs[i] = 1;
					}
				}

				int ret = refs.Count;
				refs.Clear();
				refs = null;
				return ret;
			}
		}

		/// <summary>
		/// The Number of referenced Vertices
		/// </summary>
		public int ReferencedVertexCount
		{
			get
			{
				int vertcount = 0;
				if (LinkIndex < parent.Links.Count)
				{
					if (LinkIndex >= 0 && LinkIndex < parent.Links.Count)
					{
						vertcount = parent.Links[LinkIndex].ReferencedSize;
					}
				}
				return vertcount;
			}
		}

		/// <summary>
		/// This output is used in the ListBox View
		/// </summary>
		/// <returns>A String Describing the Data</returns>
		public override string ToString()
		{
			return Faces.Count < 0x2000 || UserVerification.HaveUserId
				? Name
					+ " (FaceCount="
					+ FaceCount.ToString()
					+ ", VertexCount="
					+ UsedVertexCount.ToString()
					+ ")"
				: Name
					+ " (FaceCount="
					+ FaceCount.ToString()
					+ ", VertexCount=too many Faces)";
		}

		/// <summary>
		/// Returns a List with all available Vertices
		/// </summary>
		/// <returns></returns>
		public List<Vector4> GetVectors(ElementIdentity id)
		{
			List<Vector4> ret = new List<Vector4>();
			if (Link != null)
			{
				GmdcElement e = Link.FindElementType(id);
				if (e != null)
				{
					int nr = Link.GetElementNr(e);

					for (int i = 0; i < Link.ReferencedSize; i++)
					{
						GmdcElementValueBase vb = Link.GetValue(nr, i);
						Vector4 v;
						if (vb is GmdcElementValueOneInt oi)
						{
							byte[] data = oi.Bytes;
							v = data.Length == 4
								? new Vector4(
									data[0],
									data[1],
									data[2],
									data[3]
								)
								: data.Length == 3
									? new Vector4(
																	data[0],
																	data[1],
																	data[2], 0
																)
									: data.Length == 2 ? new Vector4(data[0], data[1], 0, 0) : new Vector4(data[0], 0, 0, 0);
						}
						else
						{
							v = vb.Data.Length == 3
								? new Vector4(
															vb.Data[0],
															vb.Data[1],
															vb.Data[2], 0
														)
								: vb.Data.Length == 2 ? new Vector4(vb.Data[0], vb.Data[1], 0, 0) : new Vector4(vb.Data[0], 0, 0, 0);
						}

						ret.Add(v);
					}
				}
			}

			return ret;
		}

		/// <summary>
		/// Returns a List with all available Vertices
		/// </summary>
		/// <returns></returns>
		public List<Vector4> GetVertices()
		{
			return GetVectors(ElementIdentity.Vertex);
		}

		/// <summary>
		/// Returns a List with all available Normals
		/// </summary>
		/// <returns></returns>
		public List<Vector4> GetNormals()
		{
			return GetVectors(ElementIdentity.Normal);
		}

		/// <summary>
		/// Returns a List with all available UV-Coords
		/// </summary>
		/// <returns></returns>
		public List<Vector4> GetUV()
		{
			return GetVectors(ElementIdentity.UVCoordinate);
		}

		/// <summary>
		/// Returns a List with all available UV-Coords
		/// </summary>
		/// <returns></returns>
		public List<Vector4> GetBones()
		{
			List<Vector4> ret = GetVectors(ElementIdentity.BoneAssignment);

			for (int i = 0; i < ret.Count; i++)
			{
				ret[i] = new Vector4(
					(int)ret[i].X != 0xff ? UsedJoints[(byte)ret[i].X] : ret[i].X,
					(int)ret[i].Y != 0xff ? UsedJoints[(byte)ret[i].Y] : ret[i].Y,
					(int)ret[i].Z != 0xff ? UsedJoints[(byte)ret[i].Z] : ret[i].Z,
					(int)ret[i].W != 0xff ? UsedJoints[(byte)ret[i].W] : ret[i].W
				);
			}
			return ret;
		}
	}
}
