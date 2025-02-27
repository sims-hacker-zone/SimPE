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
namespace SimPe.Plugin
{
	public class ObjectGraphNodeItem
	{
		public byte Enabled
		{
			get; set;
		}

		public byte Dependant
		{
			get; set;
		}

		public uint Index
		{
			get; set;
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		public void Unserialize(System.IO.BinaryReader reader)
		{
			Enabled = reader.ReadByte();
			Dependant = reader.ReadByte();
			Index = reader.ReadUInt32();
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
			writer.Write(Enabled);
			writer.Write(Dependant);
			writer.Write(Index);
		}

		public override string ToString()
		{
			return Index.ToString()
				+ ": 0x"
				+ Helper.HexString(Enabled)
				+ ", 0x"
				+ Helper.HexString(Dependant);
		}
	}

	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class ObjectGraphNode : AbstractRcolBlock
	{
		#region Attributes


		public ObjectGraphNodeItem[] Items
		{
			get; set;
		}

		public string FileName
		{
			get; set;
		}
		#endregion
		/*public Rcol Parent
		{
			get { return parent; }
		}*/

		/// <summary>
		/// Constructor
		/// </summary>
		public ObjectGraphNode(Rcol parent)
			: base(parent)
		{
			Items = new ObjectGraphNodeItem[0];
			FileName = this.BlockName;
			version = 4;
		}

		#region IRcolBlock Member

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		public override void Unserialize(System.IO.BinaryReader reader)
		{
			version = reader.ReadUInt32();

			Items = new ObjectGraphNodeItem[reader.ReadUInt32()];
			for (int i = 0; i < Items.Length; i++)
			{
				Items[i] = new ObjectGraphNodeItem();
				Items[i].Unserialize(reader);
			}

			if (version == 0x04)
			{
				FileName = reader.ReadString();
			}
			else
			{
				FileName = "cObjectGraphNode";
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

			writer.Write((uint)Items.Length);
			for (int i = 0; i < Items.Length; i++)
			{
				Items[i].Serialize(writer);
			}

			if (version == 0x04)
			{
				writer.Write(FileName);
			}
		}

		TabPage.ObjectGraphNode tObjectGraphNode;
		public override System.Windows.Forms.TabPage TabPage
		{
			get
			{
				if (tObjectGraphNode == null)
				{
					tObjectGraphNode = new TabPage.ObjectGraphNode();
				}

				return tObjectGraphNode;
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

			tObjectGraphNode.lb_ogn.Items.Clear();
			for (int i = 0; i < this.Items.Length; i++)
			{
				tObjectGraphNode.lb_ogn.Items.Add(Items[i]);
			}

			tObjectGraphNode.tb_ogn_file.Text = this.FileName;
			tObjectGraphNode.tb_ogn_ver.Text = "0x" + Helper.HexString(this.version);
		}

		public override string ToString()
		{
			return FileName;
		}

		#region IDisposable Member

		public override void Dispose()
		{
			if (this.tObjectGraphNode != null)
			{
				this.tObjectGraphNode.Dispose();
			}

			tObjectGraphNode = null;
		}

		#endregion
	}
}
