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
using System.Collections;
using System.ComponentModel;

using SimPe.Geometry;

namespace SimPe.Plugin
{
	/// <summary>
	/// Items for the IndexedMeshBuilder class
	/// </summary>
	public class IndexedMeshBuilderItem
	{
		#region Attributes
		public string String1
		{
			get; set;
		}

		public string String2
		{
			get; set;
		}

		public Vectors4f Vectors
		{
			get; set;
		}

		public int Unknown1
		{
			get; set;
		}
		#endregion

		public IndexedMeshBuilderItem()
		{
			String1 = "";
			String2 = "";

			Vectors = new Vectors4f();
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		internal virtual void Unserialize(System.IO.BinaryReader reader)
		{
			String1 = reader.ReadString();
			String2 = reader.ReadString();
			int count = reader.ReadInt32();
			Vectors.Clear();
			for (int i = 0; i < count; i++)
			{
				Vector4f o = new Vector4f();
				o.Unserialize(reader);
				Vectors.Add(o);
			}
			Unknown1 = reader.ReadInt32();
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
			writer.Write(String1);
			writer.Write(String2);
			writer.Write((int)Vectors.Count);
			for (int i = 0; i < Vectors.Count; i++)
			{
				Vectors[i].Serialize(writer);
			}

			writer.Write(Unknown1);
		}
	}

	/// <summary>
	/// Summary description for cIndexedMeshBuilder.
	/// </summary>
	public class IndexedMeshBuilder : AbstractRcolBlock
	{
		#region Attributes
		GeometryBuilder gb;

		public Vectors3f Vectors1
		{
			get; set;
		}

		public Vectors3f Vectors2
		{
			get; set;
		}

		public Vectors2f Vectors3
		{
			get; set;
		}

		public Vectors2f Vectors4
		{
			get; set;
		}

		public Vectors2f Vectors5
		{
			get; set;
		}

		public Vectors2f Vectors6
		{
			get; set;
		}

		public IntArrayList Numbers1
		{
			get; set;
		}

		public IntArrayList Numbers2
		{
			get; set;
		}

		public IntArrayList Numbers3
		{
			get; set;
		}

		public IntArrayList Numbers4
		{
			get; set;
		}

		public byte[] Zero1
		{
			get; private set;
		}

		public byte[] Zero2
		{
			get; private set;
		}

		public int ReferencedCount
		{
			get; set;
		}

		public int Unknown1
		{
			get; set;
		}

		public float[] Unknown2
		{
			get;
		}

		public IndexedMeshBuilderItems Items
		{
			get; set;
		}

		public int Unknown3
		{
			get; set;
		}

		public int Unknown4
		{
			get; set;
		}

		public int Unknown5
		{
			get; set;
		}

		public int Unknown6
		{
			get; set;
		}

		public int Unknown7
		{
			get; set;
		}

		public int Unknown8
		{
			get; set;
		}

		public int Unknown9
		{
			get; set;
		}

		public int Unknown10
		{
			get; set;
		}

		public string Name
		{
			get; set;
		}

		#endregion


		/// <summary>
		/// Constructor
		/// </summary>
		public IndexedMeshBuilder(Rcol parent)
			: base(parent)
		{
			gb = new GeometryBuilder(null);
			BlockID = 0x9bffc10d;

			Vectors1 = new Vectors3f();
			Vectors2 = new Vectors3f();
			Vectors3 = new Vectors2f();
			Vectors4 = new Vectors2f();
			Vectors5 = new Vectors2f();
			Vectors6 = new Vectors2f();

			Numbers1 = new IntArrayList();
			Numbers2 = new IntArrayList();
			Numbers3 = new IntArrayList();
			Numbers4 = new IntArrayList();

			Items = new IndexedMeshBuilderItems();

			Zero1 = new byte[0x14];
			Zero2 = new byte[0x14];

			Unknown2 = new float[0x200];
			Name = "face";
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

			count = reader.ReadInt32();
			Vectors3.Clear();
			for (int i = 0; i < count; i++)
			{
				Vector2f o = new Vector2f();
				o.Unserialize(reader);
				Vectors3.Add(o);
			}

			Zero1 = reader.ReadBytes(Zero1.Length);
			ReferencedCount = reader.ReadInt32();
			Unknown1 = reader.ReadInt32();
			Zero2 = reader.ReadBytes(Zero2.Length);

			count = reader.ReadInt32();
			Vectors4.Clear();
			for (int i = 0; i < count; i++)
			{
				Vector2f o = new Vector2f();
				o.Unserialize(reader);
				Vectors4.Add(o);
			}

			count = reader.ReadInt32();
			Vectors5.Clear();
			for (int i = 0; i < count; i++)
			{
				Vector2f o = new Vector2f();
				o.Unserialize(reader);
				Vectors5.Add(o);
			}

			count = reader.ReadInt32();
			Vectors6.Clear();
			for (int i = 0; i < count; i++)
			{
				Vector2f o = new Vector2f();
				o.Unserialize(reader);
				Vectors6.Add(o);
			}

			for (int i = 0; i < Unknown2.Length; i++)
			{
				Unknown2[i] = reader.ReadSingle();
			}

			count = reader.ReadInt32();
			Items.Clear();
			for (int i = 0; i < count; i++)
			{
				IndexedMeshBuilderItem o = new IndexedMeshBuilderItem();
				o.Unserialize(reader);
				Items.Add(o);
			}

			Unknown3 = reader.ReadInt32();
			Unknown4 = reader.ReadInt32();

			count = reader.ReadInt32();
			Numbers1.Clear();
			for (int i = 0; i < count; i++)
			{
				Numbers1.Add(reader.ReadInt32());
			}

			count = reader.ReadInt32();
			Numbers2.Clear();
			for (int i = 0; i < count; i++)
			{
				Numbers2.Add(reader.ReadInt32());
			}

			count = reader.ReadInt32();
			Numbers3.Clear();
			for (int i = 0; i < count; i++)
			{
				Numbers3.Add(reader.ReadInt32());
			}

			count = reader.ReadInt32();
			Numbers4.Clear();
			for (int i = 0; i < count; i++)
			{
				Numbers4.Add(reader.ReadInt32());
			}

			Unknown5 = reader.ReadInt32();
			Unknown6 = reader.ReadInt32();
			Unknown7 = reader.ReadInt32();
			Unknown8 = reader.ReadInt32();
			Unknown9 = reader.ReadInt32();
			Unknown10 = reader.ReadInt32();

			Name = reader.ReadString();
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

			writer.Write((int)Vectors3.Count);
			for (int i = 0; i < Vectors3.Count; i++)
			{
				Vectors3[i].Serialize(writer);
			}

			writer.Write(Zero1);
			writer.Write(ReferencedCount);
			writer.Write(Unknown1);
			writer.Write(Zero2);

			writer.Write((int)Vectors4.Count);
			for (int i = 0; i < Vectors4.Count; i++)
			{
				Vectors4[i].Serialize(writer);
			}

			writer.Write((int)Vectors5.Count);
			for (int i = 0; i < Vectors5.Count; i++)
			{
				Vectors5[i].Serialize(writer);
			}

			writer.Write((int)Vectors6.Count);
			for (int i = 0; i < Vectors6.Count; i++)
			{
				Vectors6[i].Serialize(writer);
			}

			for (int i = 0; i < Unknown2.Length; i++)
			{
				writer.Write(Unknown2[i]);
			}

			writer.Write((int)Items.Count);
			for (int i = 0; i < Items.Count; i++)
			{
				Items[i].Serialize(writer);
			}

			writer.Write(Unknown3);
			writer.Write(Unknown4);

			writer.Write((int)Numbers1.Count);
			for (int i = 0; i < Numbers1.Count; i++)
			{
				writer.Write(Numbers1[i]);
			}

			writer.Write((int)Numbers2.Count);
			for (int i = 0; i < Numbers2.Count; i++)
			{
				writer.Write(Numbers2[i]);
			}

			writer.Write((int)Numbers3.Count);
			for (int i = 0; i < Numbers3.Count; i++)
			{
				writer.Write(Numbers3[i]);
			}

			writer.Write((int)Numbers4.Count);
			for (int i = 0; i < Numbers4.Count; i++)
			{
				writer.Write(Numbers4[i]);
			}

			writer.Write(Unknown5);
			writer.Write(Unknown6);
			writer.Write(Unknown7);
			writer.Write(Unknown8);
			writer.Write(Unknown9);
			writer.Write(Unknown10);

			writer.Write(Name);
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
	/// Typesave ArrayList for IndexedMeshBuilderItem Objects
	/// </summary>
	public class IndexedMeshBuilderItems : ArrayList
	{
		/// <summary>
		/// Integer Indexer
		/// </summary>
		public new IndexedMeshBuilderItem this[int index]
		{
			get
			{
				return ((IndexedMeshBuilderItem)base[index]);
			}
			set
			{
				base[index] = value;
			}
		}

		/// <summary>
		/// unsigned Integer Indexer
		/// </summary>
		public IndexedMeshBuilderItem this[uint index]
		{
			get
			{
				return ((IndexedMeshBuilderItem)base[(int)index]);
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
		public int Add(IndexedMeshBuilderItem item)
		{
			return base.Add(item);
		}

		/// <summary>
		/// insert a new Element
		/// </summary>
		/// <param name="index">The Index where the Element should be stored</param>
		/// <param name="item">The object that should be inserted</param>
		public void Insert(int index, IndexedMeshBuilderItem item)
		{
			base.Insert(index, item);
		}

		/// <summary>
		/// remove an Element
		/// </summary>
		/// <param name="item">The object that should be removed</param>
		public void Remove(IndexedMeshBuilderItem item)
		{
			base.Remove(item);
		}

		/// <summary>
		/// Checks wether or not the object is already stored in the List
		/// </summary>
		/// <param name="item">The Object you are looking for</param>
		/// <returns>true, if it was found</returns>
		public bool Contains(IndexedMeshBuilderItem item)
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
			IndexedMeshBuilderItems list = new IndexedMeshBuilderItems();
			foreach (IndexedMeshBuilderItem item in this)
			{
				list.Add(item);
			}

			return list;
		}
	}
	#endregion
}
