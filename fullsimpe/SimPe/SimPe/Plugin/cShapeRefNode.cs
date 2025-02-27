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
using System.ComponentModel;

namespace SimPe.Plugin
{
	public class ShapeRefNodeItem_A
	{
		public ShapeRefNodeItem_A()
		{
			Unknown1 = 0x101;
		}

		public ushort Unknown1
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
			Unknown1 = reader.ReadUInt16();
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
				+ Helper.HexString(Unknown1)
				+ " 0x"
				+ Helper.HexString((uint)Unknown2);
		}
	}

	public class ShapeRefNodeItem_B
	{
		public int Unknown1
		{
			get; set;
		}

		public string Name
		{
			get; set;
		}

		public ShapeRefNodeItem_B()
		{
			Name = "";
		}

		public override string ToString()
		{
			return "0x" + Helper.HexString((uint)Unknown1) + ": " + Name;
		}
	}

	/// <summary>
	/// Summary description for cShapeRefNode.
	/// </summary>
	public class ShapeRefNode : AbstractCresChildren
	{
		#region Attributes
		RenderableNode rn;
		BoundedNode bn;
		TransformNode tn;

		public short Unknown1
		{
			get; set;
		}

		public int Unknown2
		{
			get; set;
		}

		public string Name
		{
			get; set;
		}

		public int Unknown3
		{
			get; set;
		}

		public byte Unknown4
		{
			get; set;
		}

		public ShapeRefNodeItem_A[] ItemsA
		{
			get; set;
		}

		public int Unknown5
		{
			get; set;
		}

		public ShapeRefNodeItem_B[] ItemsB
		{
			get; set;
		}

		public byte[] Data
		{
			get; set;
		}

		public int Unknown6
		{
			get; set;
		}

		[Browsable(false)]
		public override TransformNode StoredTransformNode => tn;
		#endregion


		/// <summary>
		/// Constructor
		/// </summary>
		public ShapeRefNode(Rcol parent)
			: base(parent)
		{
			rn = new RenderableNode(null);
			bn = new BoundedNode(null);
			tn = new TransformNode(null);

			ItemsA = new ShapeRefNodeItem_A[0];
			ItemsB = new ShapeRefNodeItem_B[0];

			Data = new byte[0];

			version = 0x15;
			Unknown1 = 1;
			Unknown2 = 1;
			Unknown4 = 1;
			Unknown5 = 0x10;
			Unknown6 = -1;
			Name = "Practical";
			BlockID = 0x65245517;
		}

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
			rn.Unserialize(reader);
			rn.BlockID = myid;

			name = reader.ReadString();
			myid = reader.ReadUInt32();
			bn.Unserialize(reader);
			bn.BlockID = myid;

			name = reader.ReadString();
			myid = reader.ReadUInt32();
			tn.Unserialize(reader);
			tn.BlockID = myid;

			Unknown1 = reader.ReadInt16();
			Unknown2 = reader.ReadInt32();
			Name = reader.ReadString();
			Unknown3 = reader.ReadInt32();
			Unknown4 = reader.ReadByte();

			ItemsA = new ShapeRefNodeItem_A[reader.ReadUInt32()];
			for (int i = 0; i < ItemsA.Length; i++)
			{
				ItemsA[i] = new ShapeRefNodeItem_A();
				ItemsA[i].Unserialize(reader);
			}
			Unknown5 = reader.ReadInt32();

			ItemsB = new ShapeRefNodeItem_B[reader.ReadUInt32()];
			for (int i = 0; i < ItemsB.Length; i++)
			{
				ItemsB[i] = new ShapeRefNodeItem_B
				{
					Unknown1 = reader.ReadInt32()
				};
			}

			int len = 0;
			if (version == 0x15)
			{
				for (int i = 0; i < ItemsB.Length; i++)
				{
					ItemsB[i].Name = reader.ReadString();
				}
			}

			len = reader.ReadInt32();
			Data = reader.ReadBytes(len);
			Unknown6 = reader.ReadInt32();
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

			writer.Write(rn.BlockName);
			writer.Write(rn.BlockID);
			rn.Serialize(writer);

			writer.Write(bn.BlockName);
			writer.Write(bn.BlockID);
			bn.Serialize(writer);

			writer.Write(tn.BlockName);
			writer.Write(tn.BlockID);
			tn.Serialize(writer);

			writer.Write(Unknown1);
			writer.Write(Unknown2);
			writer.Write(Name);
			writer.Write(Unknown3);
			writer.Write(Unknown4);

			writer.Write((uint)ItemsA.Length);
			for (int i = 0; i < ItemsA.Length; i++)
			{
				ItemsA[i].Serialize(writer);
			}

			writer.Write(Unknown5);

			writer.Write((uint)ItemsB.Length);
			for (int i = 0; i < ItemsB.Length; i++)
			{
				writer.Write(ItemsB[i].Unknown1);
			}

			if (version == 0x15)
			{
				for (int i = 0; i < ItemsB.Length; i++)
				{
					writer.Write(ItemsB[i].Name);
				}
			}

			writer.Write(Data.Length);
			writer.Write(Data);
			writer.Write(Unknown6);
		}

		TabPage.ShapeRefNode tShapeRefNode;
		public override System.Windows.Forms.TabPage TabPage
		{
			get
			{
				if (tShapeRefNode == null)
				{
					tShapeRefNode = new TabPage.ShapeRefNode();
				}

				return tShapeRefNode;
			}
		}
		#endregion

		#region AbstractCresChildren Member
		public override string GetName()
		{
			return tn.ObjectGraphNode.FileName;
		}

		/// <summary>
		/// Returns a List of all Child Blocks referenced by this Element
		/// </summary>
		[Browsable(false)]
		public override IntArrayList ChildBlocks => tn.ChildBlocks;

		[Browsable(false)]
		public override int ImageIndex => 3; //mesh
		#endregion

		/// <summary>
		/// You can use this to setop the Controls on a TabPage befor it is dispplayed
		/// </summary>
		protected override void InitTabPage()
		{
			if (tShapeRefNode == null)
			{
				tShapeRefNode = new TabPage.ShapeRefNode();
			}

			tShapeRefNode.lb_srn_a.Items.Clear();
			for (int i = 0; i < ItemsA.Length; i++)
			{
				tShapeRefNode.lb_srn_a.Items.Add(ItemsA[i]);
			}

			tShapeRefNode.lb_srn_b.Items.Clear();
			for (int i = 0; i < ItemsB.Length; i++)
			{
				tShapeRefNode.lb_srn_b.Items.Add(ItemsB[i]);
			}

			tShapeRefNode.tb_srn_uk1.Text =
				"0x" + Helper.HexString((ushort)Unknown1);
			tShapeRefNode.tb_srn_uk2.Text =
				"0x" + Helper.HexString((uint)Unknown2);
			tShapeRefNode.tb_srn_uk3.Text =
				"0x" + Helper.HexString((uint)Unknown3);
			tShapeRefNode.tb_srn_uk4.Text = "0x" + Helper.HexString(Unknown4);
			tShapeRefNode.tb_srn_uk5.Text =
				"0x" + Helper.HexString((uint)Unknown5);
			tShapeRefNode.tb_srn_uk6.Text =
				"0x" + Helper.HexString((uint)Unknown6);

			tShapeRefNode.tb_srn_kind.Text = Name;
			tShapeRefNode.tb_srn_data.Text = Helper.BytesToHexList(Data);

			tShapeRefNode.tb_srn_ver.Text = "0x" + Helper.HexString(version);
		}

		public override void ExtendTabControl(System.Windows.Forms.TabControl tc)
		{
			base.ExtendTabControl(tc);
			rn.AddToTabControl(tc);
			bn.AddToTabControl(tc);
			tn.AddToTabControl(tc);
		}

		public override string ToString()
		{
			return Name
				+ " - "
				+ tn.ObjectGraphNode.FileName
				+ " ("
				+ base.ToString()
				+ ")";
		}

		#region IDisposable Member

		public override void Dispose()
		{
			tShapeRefNode?.Dispose();

			tShapeRefNode = null;
		}

		#endregion
	}
}
