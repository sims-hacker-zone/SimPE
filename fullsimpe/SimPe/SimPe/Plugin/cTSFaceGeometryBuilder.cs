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
using System.Collections;

using SimPe.Geometry;

namespace SimPe.Plugin
{
	/// <summary>
	/// Items for the TSFaceGeometryBuilder class
	/// </summary>
	public class TSFaceGeometryBuilderItem
	{
		#region Attributes
		public Vectors3f Vectors1
		{
			get; set;
		}

		public Vectors3f Vectors2
		{
			get; set;
		}

		public short Unknown1
		{
			get; set;
		}

		public int Unknown2
		{
			get; set;
		}
		#endregion

		public TSFaceGeometryBuilderItem()
		{
			Vectors1 = new Vectors3f();
			Vectors2 = new Vectors3f();
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		internal virtual void Unserialize(System.IO.BinaryReader reader)
		{
			Unknown1 = reader.ReadInt16();
			Unknown2 = reader.ReadInt32();
			int count = reader.ReadInt32();
			Vectors1.Clear();
			for (int i = 0; i < count; i++)
			{
				Vector3f o = new Vector3f();
				o.Unserialize(reader);
				Vectors1.Add(o);
			}

			count = reader.ReadInt32();
			Vectors2.Clear();
			for (int i = 0; i < count; i++)
			{
				Vector3f o = new Vector3f();
				o.Unserialize(reader);
				Vectors2.Add(o);
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
		internal virtual void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(Unknown1);
			writer.Write(Unknown2);

			writer.Write((int)Vectors1.Count);
			for (int i = 0; i < Vectors1.Count; i++)
			{
				Vectors1[i].Serialize(writer);
			}

			writer.Write((int)Vectors2.Count);
			for (int i = 0; i < Vectors2.Count; i++)
			{
				Vectors2[i].Serialize(writer);
			}
		}
	}

	/// <summary>
	/// Summary description for cTSFaceGeometryBuilder.
	/// </summary>
	public class TSFaceGeometryBuilder : AbstractRcolBlock
	{
		#region Attributes
		GeometryBuilder gb;

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

		public TSFaceGeometryBuilderItems Items
		{
			get;
		}
		#endregion


		/// <summary>
		/// Constructor
		/// </summary>
		public TSFaceGeometryBuilder(Rcol parent)
			: base(parent)
		{
			gb = new GeometryBuilder(null);
			BlockID = 0x2b70b86e;

			Items = new TSFaceGeometryBuilderItems();
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
			gb.Unserialize(reader);
			gb.BlockID = myid;

			Unknown1 = reader.ReadInt32();
			Unknown2 = reader.ReadByte();
			Unknown3 = reader.ReadInt32();

			for (int i = 0; i < 10; i++)
			{
				TSFaceGeometryBuilderItem o = new TSFaceGeometryBuilderItem();
				o.Unserialize(reader);
				if (Items.Count <= i)
				{
					Items.IntAdd(o);
				}
				else
				{
					Items[i] = o;
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
		public override void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(version);

			writer.Write(gb.BlockName);
			writer.Write(gb.BlockID);
			gb.Serialize(writer);

			writer.Write(Unknown1);
			writer.Write(Unknown2);
			writer.Write(Unknown3);

			for (int i = 0; i < 10; i++)
			{
				if (i < Items.Count)
				{
					Items[i].Serialize(writer);
				}
				else
				{
					TSFaceGeometryBuilderItem o = new TSFaceGeometryBuilderItem();
					o.Serialize(writer);
				}
			}
		}

		//fShapeRefNode form = null;
		TabPage.GenericRcol tGenericRcol;
		public override System.Windows.Forms.TabPage TabPage
		{
			get
			{
				if (tGenericRcol == null)
				{
					tGenericRcol = new SimPe.Plugin.TabPage.GenericRcol();
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
			if (tGenericRcol == null)
			{
				tGenericRcol = new SimPe.Plugin.TabPage.GenericRcol();
			}

			tGenericRcol.tb_ver.Text = "0x" + Helper.HexString(this.version);
			tGenericRcol.gen_pg.SelectedObject = this;
		}

		public override void ExtendTabControl(System.Windows.Forms.TabControl tc)
		{
			base.ExtendTabControl(tc);
			this.gb.AddToTabControl(tc);
		}

		#region IDisposable Member

		public override void Dispose()
		{
			if (this.tGenericRcol != null)
			{
				this.tGenericRcol.Dispose();
			}

			tGenericRcol = null;
		}

		#endregion
	}

	#region Container

	/// <summary>
	/// Typesave ArrayList for TSFaceGeometryBuilderItem Objects
	/// </summary>
	public class TSFaceGeometryBuilderItems : ArrayList
	{
		/// <summary>
		/// Integer Indexer
		/// </summary>
		public new TSFaceGeometryBuilderItem this[int index]
		{
			get
			{
				return ((TSFaceGeometryBuilderItem)base[index]);
			}
			set
			{
				base[index] = value;
			}
		}

		/// <summary>
		/// unsigned Integer Indexer
		/// </summary>
		public TSFaceGeometryBuilderItem this[uint index]
		{
			get
			{
				return ((TSFaceGeometryBuilderItem)base[(int)index]);
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
		public int Add(TSFaceGeometryBuilderItem item)
		{
			return -1;
		}

		/// <summary>
		/// add a new Element
		/// </summary>
		/// <param name="item">The object you want to add</param>
		/// <returns>The index it was added on</returns>
		internal int IntAdd(TSFaceGeometryBuilderItem item)
		{
			return base.Add(item);
		}

		/// <summary>
		/// insert a new Element
		/// </summary>
		/// <param name="index">The Index where the Element should be stored</param>
		/// <param name="item">The object that should be inserted</param>
		public void Insert(int index, TSFaceGeometryBuilderItem item)
		{
			//base.Insert(index, item);
		}

		/// <summary>
		/// remove an Element
		/// </summary>
		/// <param name="item">The object that should be removed</param>
		public void Remove(TSFaceGeometryBuilderItem item)
		{
			//base.Remove(item);
		}

		/// <summary>
		/// Checks wether or not the object is already stored in the List
		/// </summary>
		/// <param name="item">The Object you are looking for</param>
		/// <returns>true, if it was found</returns>
		public bool Contains(TSFaceGeometryBuilderItem item)
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
			TSFaceGeometryBuilderItems list = new TSFaceGeometryBuilderItems();
			foreach (TSFaceGeometryBuilderItem item in this)
			{
				list.Add(item);
			}

			return list;
		}
	}
	#endregion
}
