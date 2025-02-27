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
using System.Collections;
using System.Globalization;
using System.IO;

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
		public GmdcLink Link
		{
			get
			{
				if (parent == null)
					return null;
				if (LinkIndex < 0 || LinkIndex >= parent.Links.Count)
					return null;

				return parent.Links[LinkIndex];
			}
		}

		/// <summary>
		/// The Name of this Group
		/// </summary>
		public String Name
		{
			get; set;
		}

		/// <summary>
		/// The Index of the used Vertices
		/// </summary>
		public IntArrayList Faces
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
		public IntArrayList UsedJoints
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
			Faces = new IntArrayList();
			UsedJoints = new IntArrayList();
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

			if (parent.Version != 0x03)
				Opacity = reader.ReadUInt32();
			else
				Opacity = 0;

			if (parent.Version != 0x01)
				ReadBlock(reader, UsedJoints);
			else
				UsedJoints.Clear();
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
				writer.Write((uint)Opacity);

			if (parent.Version != 0x01)
				WriteBlock(writer, UsedJoints);
		}

		/// <summary>
		/// The Face Count for this Group
		/// </summary>
		public int FaceCount => this.Faces.Count / 3;

		/// <summary>
		/// The Number of diffrent Vertices used by this Group
		/// </summary>
		public int UsedVertexCount
		{
			get
			{
				System.Collections.Hashtable refs = new Hashtable();
				foreach (int i in Faces)
					if (!refs.ContainsKey(i))
						refs[i] = 1;
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
				if (this.LinkIndex < parent.Links.Count)
				{
					if (LinkIndex >= 0 && LinkIndex < parent.Links.Count)
						vertcount = parent.Links[LinkIndex].ReferencedSize;
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
			if (this.Faces.Count < 0x2000 || UserVerification.HaveUserId)
				return Name
					+ " (FaceCount="
					+ (FaceCount).ToString()
					+ ", VertexCount="
					+ UsedVertexCount.ToString()
					+ ")";
			else
				return Name
					+ " (FaceCount="
					+ (FaceCount).ToString()
					+ ", VertexCount=too many Faces)";
		}

		/// <summary>
		/// Returns a List with all available Vertices
		/// </summary>
		/// <returns></returns>
		public SimPe.Geometry.Vectors4f GetVectors(ElementIdentity id)
		{
			SimPe.Geometry.Vectors4f ret = new SimPe.Geometry.Vectors4f();
			if (this.Link != null)
			{
				GmdcElement e = this.Link.FindElementType(id);
				if (e != null)
				{
					int nr = this.Link.GetElementNr(e);

					for (int i = 0; i < Link.ReferencedSize; i++)
					{
						GmdcElementValueBase vb = Link.GetValue(nr, i);
						SimPe.Geometry.Vector4f v;
						if (vb is GmdcElementValueOneInt)
						{
							GmdcElementValueOneInt oi = (GmdcElementValueOneInt)vb;
							byte[] data = oi.Bytes;
							if (data.Length == 4)
								v = new SimPe.Geometry.Vector4f(
									data[0],
									data[1],
									data[2],
									data[3]
								);
							else if (data.Length == 3)
								v = new SimPe.Geometry.Vector4f(
									data[0],
									data[1],
									data[2]
								);
							else if (data.Length == 2)
								v = new SimPe.Geometry.Vector4f(data[0], data[1], 0);
							else
								v = new SimPe.Geometry.Vector4f(data[0], 0, 0);
						}
						else if (vb.Data.Length == 3)
							v = new SimPe.Geometry.Vector4f(
								vb.Data[0],
								vb.Data[1],
								vb.Data[2]
							);
						else if (vb.Data.Length == 2)
							v = new SimPe.Geometry.Vector4f(vb.Data[0], vb.Data[1], 0);
						else
							v = new SimPe.Geometry.Vector4f(vb.Data[0], 0, 0);

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
		public SimPe.Geometry.Vectors4f GetVertices()
		{
			return GetVectors(ElementIdentity.Vertex);
		}

		/// <summary>
		/// Returns a List with all available Normals
		/// </summary>
		/// <returns></returns>
		public SimPe.Geometry.Vectors4f GetNormals()
		{
			return GetVectors(ElementIdentity.Normal);
		}

		/// <summary>
		/// Returns a List with all available UV-Coords
		/// </summary>
		/// <returns></returns>
		public SimPe.Geometry.Vectors4f GetUV()
		{
			return GetVectors(ElementIdentity.UVCoordinate);
		}

		/// <summary>
		/// Returns a List with all available UV-Coords
		/// </summary>
		/// <returns></returns>
		public SimPe.Geometry.Vectors4f GetBones()
		{
			SimPe.Geometry.Vectors4f ret = GetVectors(ElementIdentity.BoneAssignment);

			foreach (SimPe.Geometry.Vector4f v in ret)
			{
				if ((int)v.X != 0xff)
					v.X = this.UsedJoints[(byte)v.X];
				if ((int)v.Y != 0xff)
					v.Y = this.UsedJoints[(byte)v.Y];
				if ((int)v.Z != 0xff)
					v.Z = this.UsedJoints[(byte)v.Z];
				if ((int)v.W != 0xff)
					v.W = this.UsedJoints[(byte)v.W];
			}
			return ret;
		}

		/// <summary>
		/// Returns the Face Indices
		/// </summary>
		/// <returns></returns>
		public SimPe.Geometry.Vectors3i GetFaces()
		{
			SimPe.Geometry.Vectors3i ret = new SimPe.Geometry.Vectors3i();
			SimPe.Geometry.Vector3i v = null;
			for (int i = 0; i < Faces.Count; i++)
			{
				if (i % 3 == 0)
				{
					v = new SimPe.Geometry.Vector3i();
					v.X = Faces[i];
				}
				else if (i % 3 == 2)
				{
					ret.Add(v);
					v.Z = Faces[i];
				}
				else
					v.Y = Faces[i];
			}

			return ret;
		}

		public static SimPe.Geometry.Vectors3i GetUsingFaces(
			SimPe.Geometry.Vectors3i faces,
			int vertexid
		)
		{
			SimPe.Geometry.Vectors3i ret = new SimPe.Geometry.Vectors3i();
			foreach (SimPe.Geometry.Vector3i v in faces)
				if (v.X == vertexid || v.Y == vertexid || v.Z == vertexid)
					ret.Add(v);

			return ret;
		}
	}

	#region Container
	/// <summary>
	/// Typesave ArrayList for GmdcGroup Objects
	/// </summary>
	public class GmdcGroups : ArrayList
	{
		/// <summary>
		/// Integer Indexer
		/// </summary>
		public new GmdcGroup this[int index]
		{
			get
			{
				return ((GmdcGroup)base[index]);
			}
			set
			{
				base[index] = value;
			}
		}

		/// <summary>
		/// unsigned Integer Indexer
		/// </summary>
		public GmdcGroup this[uint index]
		{
			get
			{
				return ((GmdcGroup)base[(int)index]);
			}
			set
			{
				base[(int)index] = value;
			}
		}

		/// <summary>
		/// add a new Element
		/// </summary>
		/// <param name="item">The object you want to add</param>
		/// <returns>The index it was added on</returns>
		public int Add(GmdcGroup item)
		{
			return base.Add(item);
		}

		/// <summary>
		/// insert a new Element
		/// </summary>
		/// <param name="index">The Index where the Element should be stored</param>
		/// <param name="item">The object that should be inserted</param>
		public void Insert(int index, GmdcGroup item)
		{
			base.Insert(index, item);
		}

		/// <summary>
		/// remove an Element
		/// </summary>
		/// <param name="item">The object that should be removed</param>
		public void Remove(GmdcGroup item)
		{
			base.Remove(item);
		}

		/// <summary>
		/// Checks wether or not the object is already stored in the List
		/// </summary>
		/// <param name="item">The Object you are looking for</param>
		/// <returns>true, if it was found</returns>
		public bool Contains(GmdcGroup item)
		{
			return base.Contains(item);
		}

		/// <summary>
		/// Number of stored Elements
		/// </summary>
		public int Length => this.Count;

		/// <summary>
		/// Create a clone of this Object
		/// </summary>
		/// <returns>The clone</returns>
		public override object Clone()
		{
			GmdcGroups list = new GmdcGroups();
			foreach (GmdcGroup item in this)
				list.Add(item);

			return list;
		}
	}
	#endregion
}
