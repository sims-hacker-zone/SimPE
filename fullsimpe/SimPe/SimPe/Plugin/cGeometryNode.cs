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

using SimPe.Interfaces.Scenegraph;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for cGeometryNode.
	/// </summary>
	public class GeometryNode : AbstractRcolBlock
	{
		#region Attributes
		public ObjectGraphNode ObjectGraphNode
		{
			get; set;
		}

		public short Unknown1
		{
			get; set;
		}

		public short Unknown2
		{
			get; set;
		}

		public byte Unknown3
		{
			get; set;
		}

		public int Count => Blocks.Length;
		public IRcolBlock[] Blocks
		{
			get; set;
		}
		#endregion


		/// <summary>
		/// Constructor
		/// </summary>
		public GeometryNode(Rcol parent)
			: base(parent)
		{
			ObjectGraphNode = new ObjectGraphNode(null);
			this.sgres = new SGResource(null);

			version = 0x0c;
			BlockID = 0x7BA3838C;

			Blocks = new IRcolBlock[0];
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
			ObjectGraphNode.Unserialize(reader);
			ObjectGraphNode.BlockID = myid;

			name = reader.ReadString();
			myid = reader.ReadUInt32();
			sgres.Unserialize(reader);
			sgres.BlockID = myid;

			if (version == 0x0b)
			{
				Unknown1 = reader.ReadInt16();
			}

			if ((version == 0x0b) || (version == 0x0c))
			{
				Unknown2 = reader.ReadInt16();
				Unknown3 = reader.ReadByte();
			}

			int count = reader.ReadInt32();
			Blocks = new IRcolBlock[count];
			for (int i = 0; i < count; i++)
			{
				uint id = reader.ReadUInt32();
				Blocks[i] = Parent.ReadBlock(id, reader);
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

			writer.Write(ObjectGraphNode.BlockName);
			writer.Write(ObjectGraphNode.BlockID);
			ObjectGraphNode.Serialize(writer);

			writer.Write(sgres.BlockName);
			writer.Write(sgres.BlockID);
			sgres.Serialize(writer);

			if (version == 0x0b)
			{
				writer.Write(Unknown1);
			}

			if ((version == 0x0b) || (version == 0x0c))
			{
				writer.Write(Unknown2);
				writer.Write(Unknown3);
			}

			writer.Write((int)Blocks.Length);
			for (int i = 0; i < Blocks.Length; i++)
			{
				writer.Write(Blocks[i].BlockID);
				Parent.WriteBlock(Blocks[i], writer);
			}
		}

		TabPage.GeometryNode tGeometryNode;
		public override System.Windows.Forms.TabPage TabPage
		{
			get
			{
				if (tGeometryNode == null)
				{
					tGeometryNode = new SimPe.Plugin.TabPage.GeometryNode();
				}

				return tGeometryNode;
			}
		}
		#endregion

		/// <summary>
		/// You can use this to setop the Controls on a TabPage befor it is dispplayed
		/// </summary>
		protected override void InitTabPage()
		{
			if (tGeometryNode == null)
			{
				tGeometryNode = new SimPe.Plugin.TabPage.GeometryNode();
			}

			tGeometryNode.tb_gn_ver.Text = "0x" + Helper.HexString(this.version);

			tGeometryNode.tb_gn_uk1.Text =
				"0x" + Helper.HexString((ushort)this.Unknown1);
			tGeometryNode.tb_gn_uk2.Text =
				"0x" + Helper.HexString((ushort)this.Unknown2);
			tGeometryNode.tb_gn_uk3.Text = "0x" + Helper.HexString(this.Unknown3);

			tGeometryNode.tb_gn_count.Text = Count.ToString();

			tGeometryNode.cb_gn_list.Items.Clear();

			foreach (IRcolBlock irb in this.Blocks)
			{
				SimPe.CountedListItem.Add(tGeometryNode.cb_gn_list, irb);
			}

			if (tGeometryNode.cb_gn_list.Items.Count > 0)
			{
				tGeometryNode.cb_gn_list.SelectedIndex = 0;
			}
			else
			{
				tGeometryNode.BuildChildTabControl(null);
			}
		}

		public override void ExtendTabControl(System.Windows.Forms.TabControl tc)
		{
			base.ExtendTabControl(tc);
			this.ObjectGraphNode.AddToTabControl(tc);
		}

		#region ReferencingShape
		/// <summary>
		/// Returns the RCOL which lists this Resource in it's ReferencedFiles Attribute
		/// </summary>
		/// <returns>null or the RCOl Ressource</returns>
		public Rcol FindReferencingSHPE()
		{
			FileTable.FileIndex.Load();
			return FindReferencingSHPE_NoLoad();
		}

		/// <summary>
		/// Returns the RCOL which lists this Resource in it's ReferencedFiles Attribute
		/// </summary>
		/// <returns>null or the RCOl Ressource</returns>
		/// <remarks>This Version will not Load the FileTable!</remarks>
		public Rcol FindReferencingSHPE_NoLoad()
		{
			Interfaces.Scenegraph.IScenegraphFileIndexItem[] items =
				FileTable.FileIndex.FindFile(SimPe.Data.MetaData.SHPE, true);
			string mn = Hashes.StripHashFromName(this.Parent.FileName.Trim().ToLower());
			foreach (Interfaces.Scenegraph.IScenegraphFileIndexItem item in items)
			{
				Rcol r = new GenericRcol(null, false);
				//try to open the File in the same package, not in the FileTable Package!
				if (
					item.Package.SaveFileName.Trim().ToLower()
					== parent.Package.SaveFileName.Trim().ToLower()
				)
				{
					r.ProcessData(
						parent.Package.FindFile(item.FileDescriptor),
						parent.Package
					);
				}
				else
				{
					r.ProcessData(item);
				}

				Shape s = (Shape)r.Blocks[0];

				foreach (ShapeItem i in s.Items)
				{
					string n = Hashes.StripHashFromName(i.FileName).Trim().ToLower();
					if (n == mn)
					{
						return r;
					}
				}
			}

			return null;
		}
		#endregion

		#region IDisposable Member

		public override void Dispose()
		{
			if (this.tGeometryNode != null)
			{
				this.tGeometryNode.Dispose();
			}

			tGeometryNode = null;
		}

		#endregion
	}
}
