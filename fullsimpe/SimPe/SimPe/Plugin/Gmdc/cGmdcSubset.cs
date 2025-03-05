// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;

using SimPe.Geometry;

namespace SimPe.Plugin.Gmdc
{
	/// <summary>
	/// Contains the Subset Section of a GMDC
	/// </summary>
	public class GmdcJoint : GmdcLinkBlock
	{
		#region Attributes
		/// <summary>
		/// Number of Vertices stored in this SubSet
		/// </summary>
		public int VertexCount => Vertices.Length;

		/// <summary>
		/// Vertex Definitions for this SubSet
		/// </summary>
		public Vectors3f Vertices
		{
			get; set;
		}

		/// <summary>
		/// Some additional Index Data (yet unknown)
		/// </summary>
		public List<int> Items
		{
			get; set;
		}
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public GmdcJoint(GeometryDataContainer parent)
			: base(parent)
		{
			Vertices = new Vectors3f();
			Items = new List<int>();
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		public void Unserialize(System.IO.BinaryReader reader)
		{
			int vcount = reader.ReadInt32();

			if (vcount > 0)
			{
				try
				{
					int count = reader.ReadInt32();
					Vertices.Clear();
					for (int i = 0; i < vcount; i++)
					{
						Vector3f f = new Vector3f();
						f.Unserialize(reader);
						Vertices.Add(f);
					}

					Items.Clear();
					for (int i = 0; i < count; i++)
					{
						Items.Add(ReadValue(reader));
					}
				}
				catch (Exception ex)
				{
					Helper.ExceptionMessage("", ex);
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
		public void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(Vertices.Count);

			if (Vertices.Count > 0)
			{
				writer.Write(Items.Count);
				for (int i = 0; i < Vertices.Count; i++)
				{
					Vertices[i].Serialize(writer);
				}

				for (int i = 0; i < Items.Count; i++)
				{
					WriteValue(writer, Items[i]);
				}
			}
		}

		/// <summary>
		/// The Index of this Joint in the Parent's joint List (-1 indicates
		/// that the Joint was not found within the Parent)
		/// </summary>
		public int Index
		{
			get
			{
				int index = -1;
				for (int i = 0; i < parent.Joints.Count; i++)
				{
					if (parent.Joints[i] == this)
					{
						index = i;
						break;
					}
				}

				return index;
			}
		}

		TransformNode reftn;

		/// <summary>
		/// Returns the first TransformNode assigned to this Joint or null if none was found
		/// </summary>
		public TransformNode AssignedTransformNode
		{
			get
			{
				if (reftn == null)
				{
					reftn = GetAssignedTransformNode(Index);
				}

				return reftn;
			}
		}

		/// <summary>
		/// Reads the Name from the TransformNode or generates a default Name based on the Index
		/// </summary>
		public string Name => AssignedTransformNode != null ? AssignedTransformNode.ObjectGraphNode.FileName : "Joint" + Index.ToString();

		/// <summary>
		/// Returns the assigned TransformNode
		/// </summary>
		/// <param name="index">the Index of this Joint within the Parent</param>
		/// <returns>null or a TransformNode</returns>
		protected TransformNode GetAssignedTransformNode(int index)
		{
			if (parent.ParentResourceNode == null)
			{
				return null;
			}

			Rcol cres = parent.ParentResourceNode.Parent;

			foreach (Interfaces.Scenegraph.IRcolBlock irb in cres.Blocks)
			{
				if (irb.GetType() == typeof(TransformNode))
				{
					TransformNode tn = (TransformNode)irb;
					if (tn.JointReference == index)
					{
						return tn;
					}
				}
			}

			return null;
		}

		/// <summary>
		/// Applies the initial Joint Transformation to the passed Vertex
		/// </summary>
		/// <param name="index">Index of the current Joint withi it�s parent</param>
		/// <param name="v">The Vertex you want to Transform</param>
		/// <returns>Transformed Vertex</returns>
		protected Vector3f Transform(int index, Vector3f v)
		{
			//no Parent -> no Transform
			if (parent == null)
			{
				return v;
			}

			//Hashtable map = parent.LoadJointRelationMap();
			//TransformNode tn = AssignedTransformNode(index);

			//Get the Transformation Hirarchy
			VectorTransformations t = new VectorTransformations
			{
				parent.Model.Transformations[index]
			};
			/*
			while (index>=0)
			{
				t.Add(parent.Model.Transformations[index]);
				if (map.ContainsKey(index)) index = (int)map[index];
				else index = -1;
			}*/

			//Apply Transformations
			for (int i = t.Count - 1; i >= 0; i--)
			{
				v = t[i].Transform(v);
			}

			return v;
		}

		/// <summary>
		/// Adjusts the Vertex List, from all Elements Vertices that are assigned to this joint
		/// </summary>
		public void CollectVertices()
		{
			//first get my Number in the Parent
			int index = Index;

			Vertices.Clear();
			Items.Clear();

			if (index == -1)
			{
				return; //not within Parent!
			}

			//scan all Groups in the Parent for Joint Assignements
			foreach (GmdcGroup g in parent.Groups)
			{
				GmdcLink l = parent.Links[g.LinkIndex];
				GmdcElement joints = l.FindElementType(ElementIdentity.BoneAssignment);

				GmdcElement vertices = l.FindElementType(ElementIdentity.Vertex);
				int vindex = l.GetElementNr(vertices);

				if (joints == null || vertices == null)
				{
					continue;
				}

				for (int i = 0; i < g.UsedJoints.Count; i++)
				{
					//this Bone is a Match, so add all assigned vertices
					if (g.UsedJoints[i] == index)
					{
						Hashtable indices = new Hashtable();
						Hashtable empty = new Hashtable();

						//load the vertices
						for (int k = 0; k < joints.Values.Count; k++)
						{
							GmdcElementValueOneInt voi = (GmdcElementValueOneInt)
								joints.Values[k];

							//All vertices either are within the empty or indices map
							if (voi.Bytes[0] == (byte)i)
							{
								indices.Add(k, Vertices.Count);
								Vertices.Add(
									Transform(
										index,
										new Vector3f(
											vertices.Values[k].Data[0],
											vertices.Values[k].Data[1],
											vertices.Values[k].Data[2]
										)
									)
								);
							}
							else //all unassigned Vertices get 0
							{
								empty.Add(k, Vertices.Count);
								Vertices.Add(new Vector3f(0, 0, 0));
							}
						}

						//now all faces where at least one vertex is assigned to a Bone
						for (int f = 0; f < g.Faces.Count - 2; f += 3)
						{
							if (
								indices.ContainsKey(l.GetRealIndex(vindex, g.Faces[f]))
								|| indices.ContainsKey(
									l.GetRealIndex(vindex, g.Faces[f + 1])
								)
								|| indices.ContainsKey(
									l.GetRealIndex(vindex, g.Faces[f + 2])
								)
							)
							{
								for (int k = 0; k < 3; k++)
								{
									int nr = l.GetRealIndex(vindex, g.Faces[f + k]);
									int face_index = -1;

									//this Vertex was empty and is now needed,
									//so add it to the available List
									if (!indices.ContainsKey(nr))
									{
										face_index = empty.ContainsKey(nr) ? (int)empty[nr] : nr;

										indices.Add(nr, face_index);
										Vertices[face_index] = Transform(
											index,
											new Vector3f(
												vertices.Values[nr].Data[0],
												vertices.Values[nr].Data[1],
												vertices.Values[nr].Data[2]
											)
										);
									}

									face_index = (int)indices[nr];
									Items.Add(face_index);
								}
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// This output is used in the ListBox View
		/// </summary>
		/// <returns>A String Describing the Data</returns>
		public override string ToString()
		{
			string s = "";
			if (Helper.WindowsRegistry.ShowJointNames)
			{
				s += Name + ": ";
			}

			s += Vertices.Count.ToString() + ", " + Items.Count.ToString();

			return s;
		}
	}

	#region Container
	/// <summary>
	/// Typesave ArrayList for GmdcJoint Objects
	/// </summary>
	public class GmdcJoints : ArrayList
	{
		/// <summary>
		/// Integer Indexer
		/// </summary>
		public new GmdcJoint this[int index]
		{
			get => (GmdcJoint)base[index];
			set => base[index] = value;
		}

		/// <summary>
		/// unsigned Integer Indexer
		/// </summary>
		public GmdcJoint this[uint index]
		{
			get => (GmdcJoint)base[(int)index];
			set => base[(int)index] = value;
		}

		/// <summary>
		/// add a new Element
		/// </summary>
		/// <param name="item">The object you want to add</param>
		/// <returns>The index it was added on</returns>
		public int Add(GmdcJoint item)
		{
			return base.Add(item);
		}

		/// <summary>
		/// insert a new Element
		/// </summary>
		/// <param name="index">The Index where the Element should be stored</param>
		/// <param name="item">The object that should be inserted</param>
		public void Insert(int index, GmdcJoint item)
		{
			base.Insert(index, item);
		}

		/// <summary>
		/// remove an Element
		/// </summary>
		/// <param name="item">The object that should be removed</param>
		public void Remove(GmdcJoint item)
		{
			base.Remove(item);
		}

		/// <summary>
		/// Checks wether or not the object is already stored in the List
		/// </summary>
		/// <param name="item">The Object you are looking for</param>
		/// <returns>true, if it was found</returns>
		public bool Contains(GmdcJoint item)
		{
			return base.Contains(item);
		}

		/// <summary>
		/// Checks weteher or not a Joint with the passed name is stored in the List
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public bool Contains(string name)
		{
			name = name.Trim().ToLower();
			foreach (GmdcJoint gj in this)
			{
				if (gj.Name.Trim().ToLower() == name)
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Number of stored Elements
		/// </summary>
		public int Length => Count;

		/// <summary>
		/// Create a clone of this Object
		/// </summary>
		/// <returns>The clone</returns>
		public override object Clone()
		{
			GmdcJoints list = new GmdcJoints();
			foreach (GmdcJoint item in this)
			{
				list.Add(item);
			}

			return list;
		}
	}
	#endregion
}
