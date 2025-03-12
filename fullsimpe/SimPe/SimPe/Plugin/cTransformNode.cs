// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;

using SimPe.Geometry;

namespace SimPe.Plugin
{
	public class TransformNodeItem
	{
		public TransformNodeItem()
		{
			Unknown1 = 1;
			ChildNode = 0;
		}

		public ushort Unknown1
		{
			get; set;
		}
		public int ChildNode
		{
			get; set;
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		public void Unserialize(System.IO.BinaryReader reader)
		{
			Unknown1 = reader.ReadUInt16();
			ChildNode = reader.ReadInt32();
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
			writer.Write(Unknown1);
			writer.Write(ChildNode);
		}

		public override string ToString()
		{
			return "0x"
				+ Helper.HexString(Unknown1)
				+ " 0x"
				+ Helper.HexString((uint)ChildNode);
		}
	}

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

		public TransformNodeItems Items
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

			Items = new TransformNodeItems();

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

			writer.Write((uint)Items.Length);
			for (int i = 0; i < Items.Length; i++)
			{
				Items[i].Serialize(writer);
			}

			Transformation.Order = VectorTransformation.TransformOrder.TranslateRotate;
			Transformation.Serialize(writer);

			writer.Write(JointReference);
		}

		TabPage.TransformNode tTransformNode;
		public override System.Windows.Forms.TabPage TabPage
		{
			get
			{
				if (tTransformNode == null)
				{
					tTransformNode = new TabPage.TransformNode();
				}

				return tTransformNode;
			}
		}
		#endregion

		/// <summary>
		/// You can use this to setop the Controls on a TabPage befor it is dispplayed
		/// </summary>
		protected override void InitTabPage()
		{
			if (tTransformNode == null)
			{
				tTransformNode = new TabPage.TransformNode();
			}

			tTransformNode.tb_tn_a.Tag = true;

			tTransformNode.lb_tn.Items.Clear();
			for (int i = 0; i < Items.Length; i++)
			{
				tTransformNode.lb_tn.Items.Add(Items[i]);
			}

			tTransformNode.tb_tn_ver.Text = "0x" + Helper.HexString(version);
			tTransformNode.tb_tn_ukn.Text = "0x" + Helper.HexStringInt(JointReference);

			tTransformNode.tb_tn_tx.Text = Transformation.Translation.X.ToString("N6");
			tTransformNode.tb_tn_ty.Text = Transformation.Translation.Y.ToString("N6");
			tTransformNode.tb_tn_tz.Text = Transformation.Translation.Z.ToString("N6");

			/*form.tb_tn_rx.Text = trans.Rotation.X.ToString("N6");
			form.tb_tn_ry.Text = trans.Rotation.Y.ToString("N6");
			form.tb_tn_rz.Text = trans.Rotation.Z.ToString("N6");
			form.tb_tn_rw.Text = trans.Rotation.W.ToString("N6");

			form.tb_tn_ax.Text = trans.Rotation.Axis.X.ToString("N6");
			form.tb_tn_ay.Text = trans.Rotation.Axis.Y.ToString("N6");
			form.tb_tn_az.Text = trans.Rotation.Axis.Z.ToString("N6");
			form.tb_tn_a.Text = Quaternion.RadToDeg(trans.Rotation.Angle).ToString("N6");*/
			tTransformNode.TNUpdateTextValues(Transformation.Rotation, true, true, true);

			tTransformNode.tb_tn_a.Tag = null;
		}

		public override void ExtendTabControl(System.Windows.Forms.TabControl tc)
		{
			base.ExtendTabControl(tc);
			ObjectGraphNode.AddToTabControl(tc);
			CompositionTreeNode.AddToTabControl(tc);
		}

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
			for (int i = 0; i < Items.Length; i++)
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
			for (int i = 0; i < Items.Length; i++)
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
			tTransformNode?.Dispose();

			tTransformNode = null;
			CompositionTreeNode = null;
			ObjectGraphNode = null;
			Items = null;
			Transformation = null;
		}

		#endregion
	}

	#region Container
	/// <summary>
	/// Typesave ArrayList for TransformNodeItem Objects
	/// </summary>
	public class TransformNodeItems : ArrayList
	{
		/// <summary>
		/// Integer Indexer
		/// </summary>
		public new TransformNodeItem this[int index]
		{
			get => (TransformNodeItem)base[index];
			set => base[index] = value;
		}

		/// <summary>
		/// unsigned Integer Indexer
		/// </summary>
		public TransformNodeItem this[uint index]
		{
			get => (TransformNodeItem)base[(int)index];
			set => base[(int)index] = value;
		}

		/// <summary>
		/// add a new Element
		/// </summary>
		/// <param name="item">The object you want to add</param>
		/// <returns>The index it was added on</returns>
		public int Add(TransformNodeItem item)
		{
			return base.Add(item);
		}

		/// <summary>
		/// insert a new Element
		/// </summary>
		/// <param name="index">The Index where the Element should be stored</param>
		/// <param name="item">The object that should be inserted</param>
		public void Insert(int index, TransformNodeItem item)
		{
			base.Insert(index, item);
		}

		/// <summary>
		/// remove an Element
		/// </summary>
		/// <param name="item">The object that should be removed</param>
		public void Remove(TransformNodeItem item)
		{
			base.Remove(item);
		}

		/// <summary>
		/// Checks wether or not the object is already stored in the List
		/// </summary>
		/// <param name="item">The Object you are looking for</param>
		/// <returns>true, if it was found</returns>
		public bool Contains(TransformNodeItem item)
		{
			return base.Contains(item);
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
			TransformNodeItems list = new TransformNodeItems();
			foreach (TransformNodeItem item in this)
			{
				list.Add(item);
			}

			return list;
		}
	}
	#endregion
}
