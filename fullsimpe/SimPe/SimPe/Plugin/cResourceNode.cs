// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;
using System.ComponentModel;

using SimPe.Data;

namespace SimPe.Plugin
{
	public class ResourceNodeItem
	{
		public short Unknown1
		{
			get; set;
		}

		public int Unknown2
		{
			get; set;
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		public void Unserialize(System.IO.BinaryReader reader)
		{
			Unknown1 = reader.ReadInt16();
			Unknown2 = reader.ReadInt32();
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
			writer.Write(Unknown2);
		}

		public override string ToString()
		{
			return "0x"
				+ Helper.HexString((ushort)Unknown1)
				+ " 0x"
				+ Helper.HexString((uint)Unknown2);
		}
	}

	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class ResourceNode : AbstractCresChildren
	{
		#region Attributes
		public byte TypeCode
		{
			get; private set;
		}

		public ObjectGraphNode GraphNode
		{
			get; private set;
		}

		public CompositionTreeNode TreeNode
		{
			get; private set;
		}

		public ResourceNodeItem[] Items
		{
			get; set;
		}

		public int Unknown1
		{
			get; set;
		}

		public int Unknown2
		{
			get; set;
		}

		[Browsable(false)]
		public override TransformNode StoredTransformNode => null;
		#endregion


		/// <summary>
		/// Constructor
		/// </summary>
		public ResourceNode(Rcol parent)
			: base(parent)
		{
			sgres = new SGResource(null);
			GraphNode = new ObjectGraphNode(null);
			TreeNode = new CompositionTreeNode(null);
			Items = new ResourceNodeItem[0];

			version = 0x07;
			TypeCode = 0x01;
			BlockID = (uint)FileTypes.CRES;
		}

		#region AbstractCresChildren Member
		public override string GetName()
		{
			return GraphNode.FileName;
		}

		/// <summary>
		/// Returns a List of all Child Blocks referenced by this Element
		/// </summary>
		public override List<int> ChildBlocks
		{
			get
			{
				List<int> l = new List<int>();
				foreach (ResourceNodeItem rni in Items)
				{
					l.Add((rni.Unknown2 >> 24) & 0xff);
				}
				return l;
			}
		}

		[Browsable(false)]
		public override int ImageIndex => 3; //mesh

		/// <summary>
		/// Add a ChildNode (and all it's subChilds) to a TreeNode
		/// </summary>
		/// <param name="parent">The parent TreeNode</param>
		/// <param name="index">The Index of the Child Block in the Parent</param>
		/// <param name="child">The ChildBlock (can be null)</param>
		protected void AddChildNode(
			System.Windows.Forms.TreeNodeCollection parent,
			int index,
			Interfaces.Scenegraph.ICresChildren child
		)
		{
			//Make the user aware, that a Node was left out!
			if (child == null)
			{
				System.Windows.Forms.TreeNode unode = new System.Windows.Forms.TreeNode(
					"[Error: Unsupported Child on Index " + index.ToString() + "]"
				)
				{
					Tag = index,
					ImageIndex = 4,
					SelectedImageIndex = 4
				};
				parent.Add(unode);
				return;
			}

			System.Windows.Forms.TreeNode node = new System.Windows.Forms.TreeNode(
				"0x" + index.ToString("X") + ": " + child.ToString()
			)
			{
				Tag = index,
				ImageIndex = child.ImageIndex
			};
			node.SelectedImageIndex = node.ImageIndex;
			parent.Add(node);

			foreach (int i in child.ChildBlocks)
			{
				AddChildNode(node.Nodes, i, child.GetBlock(i));
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
			TypeCode = reader.ReadByte();

			string fldsc = reader.ReadString();
			uint myid = reader.ReadUInt32();

			if (TypeCode == 0x01)
			{
				sgres.Unserialize(reader);
				sgres.BlockID = myid;

				fldsc = reader.ReadString();
				myid = reader.ReadUInt32();
				TreeNode.Unserialize(reader);
				TreeNode.BlockID = myid;

				fldsc = reader.ReadString();
				myid = reader.ReadUInt32();
				GraphNode.Unserialize(reader);
				GraphNode.BlockID = myid;

				Items = new ResourceNodeItem[reader.ReadByte()];
				for (int i = 0; i < Items.Length; i++)
				{
					Items[i] = new ResourceNodeItem();
					Items[i].Unserialize(reader);
				}
				Unknown1 = reader.ReadInt32();
			}
			else if (TypeCode == 0x00)
			{
				GraphNode.Unserialize(reader);
				GraphNode.BlockID = myid;

				Items = new ResourceNodeItem[1];
				Items[0] = new ResourceNodeItem();
				Items[0].Unserialize(reader);
			}
			else
			{
				throw new Exception(
					"Unknown ResourceNode 0x"
						+ Helper.HexString(version)
						+ ", 0x"
						+ Helper.HexString(TypeCode)
				);
			}
			Unknown2 = reader.ReadInt32();
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
			writer.Write(TypeCode);

			if (TypeCode == 0x01)
			{
				writer.Write(sgres.BlockName);
				writer.Write(sgres.BlockID);
				sgres.Serialize(writer);

				writer.Write(TreeNode.BlockName);
				writer.Write(TreeNode.BlockID);
				TreeNode.Serialize(writer);

				writer.Write(GraphNode.BlockName);
				writer.Write(GraphNode.BlockID);
				GraphNode.Serialize(writer);

				writer.Write((byte)Items.Length);
				for (int i = 0; i < Items.Length; i++)
				{
					Items[i].Serialize(writer);
				}

				writer.Write(Unknown1);
			}
			else if (TypeCode == 0x00)
			{
				writer.Write(GraphNode.BlockName);
				writer.Write(GraphNode.BlockID);
				GraphNode.Serialize(writer);

				if (Items.Length < 1)
				{
					Items = new ResourceNodeItem[1];
				}

				Items[0].Serialize(writer);
			}
			else
			{
				throw new Exception(
					"Unknown ResourceNode 0x"
						+ Helper.HexString(version)
						+ ", 0x"
						+ Helper.HexString(TypeCode)
				);
			}
			writer.Write(Unknown2);
		}

		TabPage.ResourceNode tResourceNode;
		public override System.Windows.Forms.TabPage TabPage
		{
			get
			{
				if (tResourceNode == null)
				{
					tResourceNode = new TabPage.ResourceNode();
				}

				return tResourceNode;
			}
		}

		TabPage.Cres tCres;
		public override System.Windows.Forms.TabPage ResourceTabPage
		{
			get
			{
				if (tCres == null)
				{
					tCres = new TabPage.Cres();
				}

				return tCres;
			}
		}

		#endregion

		/// <summary>
		/// Init the Ressource Cres
		/// </summary>
		protected override void InitResourceTabPage()
		{
			if (tResourceNode == null)
			{
				tResourceNode = new TabPage.ResourceNode();
			}

			if (tCres == null)
			{
				tCres = new TabPage.Cres();
			}

			tCres.cres_tv.Nodes.Clear();
			tCres.tbfjoint.Text = "";
			AddChildNode(tCres.cres_tv.Nodes, 0, this);
			tCres.cres_tv.ExpandAll();
		}

		/// <summary>
		/// You can use this to setop the Controls on a TabPage befor it is dispplayed
		/// </summary>
		protected override void InitTabPage()
		{
			if (tResourceNode == null)
			{
				tResourceNode = new TabPage.ResourceNode();
			}

			tResourceNode.lb_rn.Items.Clear();
			for (int i = 0; i < Items.Length; i++)
			{
				tResourceNode.lb_rn.Items.Add(Items[i]);
			}

			tResourceNode.tb_rn_uk1.Text = "0x" + Helper.HexString((uint)Unknown1);
			tResourceNode.tb_rn_uk2.Text = "0x" + Helper.HexString((uint)Unknown2);
			tResourceNode.tb_rn_ver.Text = "0x" + Helper.HexString(version);
		}

		public override void ExtendTabControl(System.Windows.Forms.TabControl tc)
		{
			base.ExtendTabControl(tc);
			if (TypeCode == 0x1)
			{
				TreeNode.AddToTabControl(tc);
			}

			GraphNode.AddToTabControl(tc);
		}

		#region IDisposable Member

		public override void Dispose()
		{
			tResourceNode?.Dispose();

			tResourceNode = null;
			tCres?.Dispose();

			tCres = null;
			sgres = null;
			GraphNode = null;
			TreeNode = null;
			Items = new ResourceNodeItem[0];
		}

		#endregion
	}
}
