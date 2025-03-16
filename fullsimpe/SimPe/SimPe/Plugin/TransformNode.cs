// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;

using SimPe.Geometry;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for cTransformNode.
	/// </summary>
	public class TransformNode : AbstractCresChildren
	{
		/// <summary>
		/// this value in Joint Reference tells us that the
		/// Node is not directly linked to a joint
		/// </summary>
		public const int NO_JOINT = 0x7fffffff;

		#region Attributes

		public List<TransformNodeItem> Items
		{
			get; set;
		}

		public ObjectGraphNode ObjectGraphNode
		{
			get; private set;
		}

		public CompositionTreeNode CompositionTreeNode
		{
			get; private set;
		}

		public VectorTransformation Transformation
		{
			get; set;
		}

		public Vector3 Translation
		{
			get => Transformation.Translation;
			set => Transformation.Translation = value;
		}
		public float TransformX
		{
			get => Translation.X;
			set => Translation = new Vector3(value, Translation.Y, Translation.Z);
		}
		public float TransformY
		{
			get => (float)Translation.Y;
			set => Translation = new Vector3(Translation.X, value, Translation.Z);
		}
		public float TransformZ
		{
			get => (float)Translation.Z;
			set => Translation = new Vector3(Translation.X, Translation.Y, value);
		}

		public float RotationX
		{
			get => (float)Rotation.X;
			set => Rotation = new System.Numerics.Quaternion(value, Rotation.Y, Rotation.Z, Rotation.W);
		}
		public float RotationY
		{
			get => (float)Rotation.Y;
			set => Rotation = new System.Numerics.Quaternion(Rotation.X, value, Rotation.Z, Rotation.W);
		}
		public float RotationZ
		{
			get => (float)Rotation.Z;
			set => Rotation = new System.Numerics.Quaternion(Rotation.X, Rotation.Y, value, Rotation.W);
		}
		public float RotationW
		{
			get => (float)Rotation.W;
			set => Rotation = new System.Numerics.Quaternion(Rotation.X, Rotation.Y, Rotation.Z, value);
		}

		public System.Numerics.Quaternion Rotation
		{
			get => Transformation.Rotation;
			set => Transformation.Rotation = value;
		}

		public int JointReference
		{
			get; set;
		}

		[Browsable(false)]
		public override TransformNode StoredTransformNode => this;
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public TransformNode(Rcol parent)
			: base(parent)
		{
			CompositionTreeNode = new CompositionTreeNode(parent);
			ObjectGraphNode = new ObjectGraphNode(parent);

			Items = new List<TransformNodeItem>();

			Transformation = new VectorTransformation(
				VectorTransformation.TransformOrder.TranslateRotate
			);

			version = 0x07;
			BlockID = 0x65246462;

			JointReference = NO_JOINT;
		}

		#region AbstractCresChildren Member
		public override string GetName()
		{
			return ObjectGraphNode.FileName;
		}

		/// <summary>
		/// Returns a List of all Child Blocks referenced by this Element
		/// </summary>
		[Browsable(false)]
		public override List<int> ChildBlocks
		{
			get
			{
				List<int> l = new List<int>();
				foreach (TransformNodeItem tni in Items)
				{
					l.Add(tni.ChildNode);
				}
				return l;
			}
		}

		[Browsable(false)]
		public override int ImageIndex
		{
			get
			{
				if (JointReference == NO_JOINT)
				{
					return 0; //clear
				}

				return 1; //bone
			}
		}
		#endregion

		#region IRcolBlock Member

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		public override void Unserialize(System.IO.BinaryReader reader)
		{
			version = reader.ReadUInt32();

			string name = reader.ReadString();
			uint myid = reader.ReadUInt32();
			CompositionTreeNode.Unserialize(reader);
			CompositionTreeNode.BlockID = myid;

			name = reader.ReadString();
			myid = reader.ReadUInt32();
			ObjectGraphNode.Unserialize(reader);
			ObjectGraphNode.BlockID = myid;

			//items = new TransformNodeItem[];
			uint count = reader.ReadUInt32();
			Items.Clear();
			for (int i = 0; i < count; i++)
			{
				TransformNodeItem tni = new TransformNodeItem();
				tni.Unserialize(reader);
				Items.Add(tni);
			}

			Transformation.Order = VectorTransformation.TransformOrder.TranslateRotate;
			Transformation.Unserialize(reader);
#if DEBUG
			Transformation.Name = ObjectGraphNode.FileName;
#endif
			//trans.Rotation = Quaternion.FromAxisAngle(trans.Rotation.X, trans.Rotation.Y, trans.Rotation.Z, Quaternion.DegToRad(trans.Rotation.W));


			JointReference = reader.ReadInt32();
		}

		/// <summary>
		/// Serializes a the Attributes stored in this Instance to the BinaryStream
		/// </summary>
		/// <param name="writer">The Stream the Data should be stored to</param>
		/// <remarks>
		/// Be sure that the Position of the stream is Proper on
		/// return (i.e. must point to the first Byte after your actual File)
		/// </remarks>
		public override void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(version);

			writer.Write(CompositionTreeNode.BlockName);
			writer.Write(CompositionTreeNode.BlockID);
			CompositionTreeNode.Serialize(writer);

			writer.Write(ObjectGraphNode.BlockName);
			writer.Write(ObjectGraphNode.BlockID);
			ObjectGraphNode.Serialize(writer);

			writer.Write((uint)Items.Count);
			for (int i = 0; i < Items.Count; i++)
			{
				Items[i].Serialize(writer);
			}

			Transformation.Order = VectorTransformation.TransformOrder.TranslateRotate;
			Transformation.Serialize(writer);

			writer.Write(JointReference);
		}
		#endregion


		public override string ToString()
		{
			string s = "";
			if (JointReference != NO_JOINT)
			{
				s += "[Joint" + JointReference.ToString() + "] - ";
			}

			s += ObjectGraphNode.FileName;

			s += ": " + Transformation.ToString() + " (" + base.ToString() + ")";
			return s;
		}

		/// <summary>
		/// Remove the Child with the given Index from the List
		/// </summary>
		/// <param name="index"></param>
		/// <returns>True, when the Child was found</returns>
		public bool RemoveChild(int index)
		{
			for (int i = 0; i < Items.Count; i++)
			{
				if (Items[i].ChildNode == index)
				{
					Items.RemoveAt(i);
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Add the Child with the given Index from the List
		/// </summary>
		/// <param name="index"></param>
		/// <returns>True, when the Child was added</returns>
		public bool AddChild(int index)
		{
			for (int i = 0; i < Items.Count; i++)
			{
				if (Items[i].ChildNode == index)
				{
					return false;
				}
			}

			TransformNodeItem tni = new TransformNodeItem
			{
				ChildNode = index
			};
			Items.Add(tni);
			return false;
		}

		#region IDisposable Member

		public override void Dispose()
		{
			CompositionTreeNode = null;
			ObjectGraphNode = null;
			Items = null;
			Transformation = null;
		}

		#endregion
	}
}
