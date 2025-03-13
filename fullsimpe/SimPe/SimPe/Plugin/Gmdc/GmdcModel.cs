// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;
using System.Numerics;

using SimPe.Geometry;

namespace SimPe.Plugin.Gmdc
{
	/// <summary>
	/// Contains the Model Section of a GMDC
	/// </summary>
	public class GmdcModel : GmdcLinkBlock
	{
		#region Attributes
		/// <summary>
		/// Set of Transformations
		/// </summary>
		public List<VectorTransformation> Transformations
		{
			get; set;
		}

		/// <summary>
		/// Groups to BlendGroup assignements
		/// </summary>
		public List<GmdcNamePair> BlendGroupDefinition
		{
			get; set;
		}

		/// <summary>
		/// Some SubSet Data (yet unknown)
		/// </summary>
		public GmdcJoint BoundingMesh
		{
			get; set;
		}
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public GmdcModel(GeometryDataContainer parent)
			: base(parent)
		{
			Transformations = new List<VectorTransformation>();
			BlendGroupDefinition = new List<GmdcNamePair>();
			BoundingMesh = new GmdcJoint(parent);
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		public void Unserialize(System.IO.BinaryReader reader)
		{
			int count = reader.ReadInt32();
			Transformations.Clear();
			for (int i = 0; i < count; i++)
			{
				VectorTransformation t = new VectorTransformation(
					VectorTransformation.TransformOrder.RotateTranslate
				);
				t.Unserialize(reader);
				Transformations.Add(t);
			}

			count = reader.ReadInt32();
			BlendGroupDefinition.Clear();
			for (int i = 0; i < count; i++)
			{
				GmdcNamePair p = new GmdcNamePair();
				p.Unserialize(reader);
				BlendGroupDefinition.Add(p);
			}

			BoundingMesh.Unserialize(reader);
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
			int count = Transformations.Count;
			writer.Write(count);
			for (int i = 0; i < count; i++)
			{
				Transformations[i].Order = VectorTransformation
					.TransformOrder
					.RotateTranslate;
				Transformations[i].Serialize(writer);
			}
			writer.Write(BlendGroupDefinition.Count);
			for (int i = 0; i < BlendGroupDefinition.Count; i++)
			{
				BlendGroupDefinition[i].Serialize(writer);
			}

			BoundingMesh.Serialize(writer);
		}

		/// <summary>
		/// Clear the BoundingMesh definition
		/// </summary>
		public void ClearBoundingMesh()
		{
			BoundingMesh.Items.Clear();
			BoundingMesh.Vertices.Clear();
		}

		/// <summary>
		/// Add the passed Group to the BoundingMesh Definition
		/// </summary>
		/// <param name="g"></param>
		public void AddGroupToBoundingMesh(GmdcGroup g)
		{
			if (g == null)
			{
				return;
			}

			if (g.Link == null)
			{
				return;
			}

			int nr = g.Link.GetElementNr(
				g.Link.FindElementType(ElementIdentity.Vertex)
			);
			int offset = BoundingMesh.VertexCount;

			for (int i = 0; i < g.Link.ReferencedSize; i++)
			{
				Vector3 v = new Vector3(
					g.Link.GetValue(nr, i).Data[0],
					g.Link.GetValue(nr, i).Data[1],
					g.Link.GetValue(nr, i).Data[2]
				);
				BoundingMesh.Vertices.Add(v);
			}

			for (int i = 0; i < g.Faces.Count; i++)
			{
				BoundingMesh.Items.Add(g.Faces[i] + offset);
			}
		}
	}
}
