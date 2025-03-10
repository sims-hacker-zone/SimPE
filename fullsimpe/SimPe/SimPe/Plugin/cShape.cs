// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using SimPe.Data;
using SimPe.Interfaces.Files;
using SimPe.Interfaces.Scenegraph;

namespace SimPe.Plugin
{
	public class ShapePart
	{
		public string Subset
		{
			get; set;
		}

		public string FileName
		{
			get; set;
		}

		byte[] data;
		public byte[] Data
		{
			get => data;
			set
			{
				if (value.Length == 9)
				{
					data = value;
				}
				else if (value.Length > 9)
				{
					data = new byte[9];
					for (int i = 0; i < 9; i++)
					{
						data[i] = value[i];
					}
				}
				else
				{
					data = new byte[9];
					for (int i = 0; i < value.Length; i++)
					{
						data[i] = value[i];
					}
				}
			}
		}

		public ShapePart()
		{
			data = new byte[9];
			Subset = "";
			FileName = "";
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		public void Unserialize(System.IO.BinaryReader reader)
		{
			Subset = reader.ReadString();
			FileName = reader.ReadString();
			data = reader.ReadBytes(9);
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
			writer.Write(Subset);
			writer.Write(FileName);
			writer.Write(data);
		}

		public override string ToString()
		{
			string name = Subset + ": " + FileName;
			return name;
		}
	}

	/// <summary>
	/// A Shape Item
	/// </summary>
	public class ShapeItem
	{
		Shape parent;

		public int Unknown1
		{
			get; set;
		}

		public byte Unknown2
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

		public string FileName
		{
			get; set;
		}

		public ShapeItem(Shape parent)
		{
			this.parent = parent;
			FileName = "";
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		public void Unserialize(System.IO.BinaryReader reader)
		{
			Unknown1 = reader.ReadInt32();
			Unknown2 = reader.ReadByte();
			if ((parent.Version == 0x07) || (parent.Version == 0x06))
			{
				FileName = "";
				Unknown3 = reader.ReadInt32();
				Unknown4 = reader.ReadByte();
			}
			else
			{
				FileName = reader.ReadString();
				Unknown3 = 0;
				Unknown4 = 0;
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
			writer.Write(Unknown1);
			writer.Write(Unknown2);
			if ((parent.Version == 0x07) || (parent.Version == 0x06))
			{
				writer.Write(Unknown3);
				writer.Write(Unknown4);
			}
			else
			{
				writer.Write(FileName);
			}
		}

		public override string ToString()
		{
			string name =
				"0x"
				+ Helper.HexString((uint)Unknown1)
				+ " - 0x"
				+ Helper.HexString(Unknown2);
			return (parent.Version == 0x07) || (parent.Version == 0x06)
				? name
					+ " - 0x"
					+ Helper.HexString((uint)Unknown3)
					+ " - 0x"
					+ Helper.HexString(Unknown4)
				: name + ": " + FileName;
		}
	}

	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class Shape : AbstractRcolBlock, IScenegraphBlock
	{
		#region Attributes
		public uint[] Unknwon
		{
			get; set;
		}

		public ShapeItem[] Items
		{
			get; set;
		}

		public ShapePart[] Parts
		{
			get; set;
		}

		public ObjectGraphNode GraphNode
		{
			get; set;
		}

		public ReferentNode RefNode
		{
			get;
		}
		#endregion
		/*public Rcol Parent
		{
			get { return parent; }
		}*/

		/// <summary>
		/// Constructor
		/// </summary>
		public Shape(Rcol parent)
			: base(parent)
		{
			sgres = new SGResource(null);
			RefNode = new ReferentNode(null);
			GraphNode = new ObjectGraphNode(null);

			Unknwon = new uint[0];
			Items = new ShapeItem[0];
			Parts = new ShapePart[0];
			BlockID = (uint)FileTypes.SHPE;
		}

		#region IRcolBlock Member

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		public override void Unserialize(System.IO.BinaryReader reader)
		{
			version = reader.ReadUInt32();
			string s = reader.ReadString();

			sgres.BlockID = reader.ReadUInt32();
			sgres.Unserialize(reader);

			s = reader.ReadString();
			RefNode.BlockID = reader.ReadUInt32();
			RefNode.Unserialize(reader);

			s = reader.ReadString();
			GraphNode.BlockID = reader.ReadUInt32();
			GraphNode.Unserialize(reader);

			Unknwon = version != 0x06 ? (new uint[reader.ReadUInt32()]) : (new uint[0]);

			for (int i = 0; i < Unknwon.Length; i++)
			{
				Unknwon[i] = reader.ReadUInt32();
			}

			Items = new ShapeItem[reader.ReadUInt32()];
			for (int i = 0; i < Items.Length; i++)
			{
				Items[i] = new ShapeItem(this);
				Items[i].Unserialize(reader);
			}

			Parts = new ShapePart[reader.ReadUInt32()];
			for (int i = 0; i < Parts.Length; i++)
			{
				Parts[i] = new ShapePart();
				Parts[i].Unserialize(reader);
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
		public override void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(version);
			writer.Write(sgres.Register(null));
			writer.Write(sgres.BlockID);
			sgres.Serialize(writer);

			writer.Write(RefNode.Register(null));
			writer.Write(RefNode.BlockID);
			RefNode.Serialize(writer);

			writer.Write(GraphNode.Register(null));
			writer.Write(GraphNode.BlockID);
			GraphNode.Serialize(writer);

			if (version != 0x06)
			{
				writer.Write((uint)Unknwon.Length);
				for (int i = 0; i < Unknwon.Length; i++)
				{
					writer.Write(Unknwon[i]);
				}
			}

			writer.Write((uint)Items.Length);
			for (int i = 0; i < Items.Length; i++)
			{
				Items[i].Serialize(writer);
			}

			writer.Write((uint)Parts.Length);
			for (int i = 0; i < Parts.Length; i++)
			{
				Parts[i].Serialize(writer);
			}
		}

		TabPage.ObjectGraphNode tObjectGraphNode;
		TabPage.GenericRcol tGenericRcol;
		TabPage.ShpeLod tShpeLod;
		TabPage.ShpeItems tShpeItems;
		TabPage.ShpeParts tShpeParts;
		public override System.Windows.Forms.TabPage TabPage
		{
			get
			{
				if (tGenericRcol == null)
				{
					tGenericRcol = new TabPage.GenericRcol();
				}

				return tGenericRcol;
			}
		}
		#endregion

		/// <summary>
		/// You can use this to setop the Controls on a TabPage befor it is dispplayed
		/// </summary>
		protected override void InitTabPage()
		{
			if (tObjectGraphNode == null)
			{
				tObjectGraphNode = new TabPage.ObjectGraphNode();
			}

			if (tGenericRcol == null)
			{
				tGenericRcol = new TabPage.GenericRcol();
			}

			if (tShpeLod == null)
			{
				tShpeLod = new TabPage.ShpeLod();
			}

			if (tShpeItems == null)
			{
				tShpeItems = new TabPage.ShpeItems();
			}

			if (tShpeParts == null)
			{
				tShpeParts = new TabPage.ShpeParts();
			}

			tGenericRcol.tb_ver.Text = "0x" + Helper.HexString(version);
			tGenericRcol.gen_pg.SelectedObject = this;

			tShpeLod.lbunk.Items.Clear();
			tShpeItems.lbitem.Items.Clear();
			tShpeParts.lbpart.Items.Clear();
			try
			{
				Shape wrp = this;

				foreach (uint val in wrp.Unknwon)
				{
					tShpeLod.lbunk.Items.Add(val);
				}

				foreach (ShapeItem item in wrp.Items)
				{
					tShpeItems.lbitem.Items.Add(item);
				}

				foreach (ShapePart part in wrp.Parts)
				{
					tShpeParts.lbpart.Items.Add(part);
				}

				foreach (ObjectGraphNodeItem ogni in wrp.GraphNode.Items)
				{
					tObjectGraphNode.lb_ogn.Items.Add(ogni);
				}

				tObjectGraphNode.tb_ogn_file.Text = wrp.GraphNode.FileName;
				tObjectGraphNode.tb_ogn_ver.Text = Helper.HexString(
					wrp.GraphNode.Version
				);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("erropenfile"),
					ex
				);
			}
		}

		public override void ExtendTabControl(System.Windows.Forms.TabControl tc)
		{
			tShpeLod.Tag = this;
			tc.TabPages.Add(tShpeLod);

			tShpeItems.Tag = this;
			tc.TabPages.Add(tShpeItems);

			tShpeParts.Tag = this;
			tc.TabPages.Add(tShpeParts);

			if (tObjectGraphNode == null)
			{
				tObjectGraphNode = new TabPage.ObjectGraphNode();
			}

			tObjectGraphNode.Tag = GraphNode;
			tc.TabPages.Add(tObjectGraphNode);

			tc.SelectedTab = tShpeParts;
		}

		#region IScenegraphItem Member

		public void ReferencedItems(Dictionary<string, List<IPackedFileDescriptor>> refmap, uint parentgroup)
		{
			refmap["Subsets"] = (from part in Parts
								 select ScenegraphHelper.BuildPfd(
											 part.FileName.Trim() + "_txmt",
											 FileTypes.TXMT,
											 parentgroup
										 )).ToList();
			refmap["Models"] = (from item in Items
								select ScenegraphHelper.BuildPfd(
									item.FileName.Trim(),
									FileTypes.GMND,
									parentgroup
								)).ToList();
		}

		#endregion

		#region IDisposable Member

		public override void Dispose()
		{
			tObjectGraphNode?.Dispose();

			tObjectGraphNode = null;

			tGenericRcol?.Dispose();

			tGenericRcol = null;

			tShpeLod?.Dispose();

			tShpeLod = null;

			tShpeItems?.Dispose();

			tShpeItems = null;

			tShpeParts?.Dispose();

			tShpeParts = null;
		}

		#endregion
	}
}
