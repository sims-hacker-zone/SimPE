// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

using SimPe.Extensions;
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

		public List<Vector4> Vectors
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

			Vectors = new List<Vector4>();
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
				Vector4 o = new Vector4();
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
			writer.Write(Vectors.Count);
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

		public List<Vector3> Vectors1
		{
			get; set;
		}

		public List<Vector3> Vectors2
		{
			get; set;
		}

		public List<Vector2> Vectors3
		{
			get; set;
		}

		public List<Vector2> Vectors4
		{
			get; set;
		}

		public List<Vector2> Vectors5
		{
			get; set;
		}

		public List<Vector2> Vectors6
		{
			get; set;
		}

		public List<int> Numbers1
		{
			get; set;
		}

		public List<int> Numbers2
		{
			get; set;
		}

		public List<int> Numbers3
		{
			get; set;
		}

		public List<int> Numbers4
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

			Vectors1 = new List<Vector3>();
			Vectors2 = new List<Vector3>();
			Vectors3 = new List<Vector2>();
			Vectors4 = new List<Vector2>();
			Vectors5 = new List<Vector2>();
			Vectors6 = new List<Vector2>();

			Numbers1 = new List<int>();
			Numbers2 = new List<int>();
			Numbers3 = new List<int>();
			Numbers4 = new List<int>();

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
				Vector3 o = new Vector3();
				o.Unserialize(reader);
				Vectors1.Add(o);
			}

			count = reader.ReadInt32();
			Vectors2.Clear();
			for (int i = 0; i < count; i++)
			{
				Vector3 o = new Vector3();
				o.Unserialize(reader);
				Vectors2.Add(o);
			}

			count = reader.ReadInt32();
			Vectors3.Clear();
			for (int i = 0; i < count; i++)
			{
				Vectors3.Add(new Vector2
				{
					X = reader.ReadSingle(),
					Y = reader.ReadSingle()
				});
			}

			Zero1 = reader.ReadBytes(Zero1.Length);
			ReferencedCount = reader.ReadInt32();
			Unknown1 = reader.ReadInt32();
			Zero2 = reader.ReadBytes(Zero2.Length);

			count = reader.ReadInt32();
			Vectors4.Clear();
			for (int i = 0; i < count; i++)
			{
				Vectors4.Add(new Vector2
				{
					X = reader.ReadSingle(),
					Y = reader.ReadSingle()
				});
			}

			count = reader.ReadInt32();
			Vectors5.Clear();
			for (int i = 0; i < count; i++)
			{
				Vectors5.Add(new Vector2
				{
					X = reader.ReadSingle(),
					Y = reader.ReadSingle()
				});
			}

			count = reader.ReadInt32();
			Vectors6.Clear();
			for (int i = 0; i < count; i++)
			{
				Vectors6.Add(new Vector2
				{
					X = reader.ReadSingle(),
					Y = reader.ReadSingle()
				});
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

			writer.Write(Vectors1.Count);
			for (int i = 0; i < Vectors1.Count; i++)
			{
				Vectors1[i].Serialize(writer);
			}

			writer.Write(Vectors2.Count);
			for (int i = 0; i < Vectors2.Count; i++)
			{
				Vectors2[i].Serialize(writer);
			}

			writer.Write(Vectors3.Count);
			for (int i = 0; i < Vectors3.Count; i++)
			{
				Vectors3[i].Serialize(writer);
			}

			writer.Write(Zero1);
			writer.Write(ReferencedCount);
			writer.Write(Unknown1);
			writer.Write(Zero2);

			writer.Write(Vectors4.Count);
			for (int i = 0; i < Vectors4.Count; i++)
			{
				Vectors4[i].Serialize(writer);
			}

			writer.Write(Vectors5.Count);
			for (int i = 0; i < Vectors5.Count; i++)
			{
				Vectors5[i].Serialize(writer);
			}

			writer.Write(Vectors6.Count);
			for (int i = 0; i < Vectors6.Count; i++)
			{
				Vectors6[i].Serialize(writer);
			}

			for (int i = 0; i < Unknown2.Length; i++)
			{
				writer.Write(Unknown2[i]);
			}

			writer.Write(Items.Count);
			for (int i = 0; i < Items.Count; i++)
			{
				Items[i].Serialize(writer);
			}

			writer.Write(Unknown3);
			writer.Write(Unknown4);

			writer.Write(Numbers1.Count);
			for (int i = 0; i < Numbers1.Count; i++)
			{
				writer.Write(Numbers1[i]);
			}

			writer.Write(Numbers2.Count);
			for (int i = 0; i < Numbers2.Count; i++)
			{
				writer.Write(Numbers2[i]);
			}

			writer.Write(Numbers3.Count);
			for (int i = 0; i < Numbers3.Count; i++)
			{
				writer.Write(Numbers3[i]);
			}

			writer.Write(Numbers4.Count);
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
			if (tGenericRcol == null)
			{
				tGenericRcol = new TabPage.GenericRcol();
			}

			tGenericRcol.tb_ver.Text = "0x" + Helper.HexString(version);
			tGenericRcol.gen_pg.SelectedObject = this;
		}

		public override void ExtendTabControl(System.Windows.Forms.TabControl tc)
		{
			base.ExtendTabControl(tc);
			gb.AddToTabControl(tc);
		}

		#region IDisposable Member

		public override void Dispose()
		{
			tGenericRcol?.Dispose();

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
			get => (IndexedMeshBuilderItem)base[index];
			set => base[index] = value;
		}

		/// <summary>
		/// unsigned Integer Indexer
		/// </summary>
		public IndexedMeshBuilderItem this[uint index]
		{
			get => (IndexedMeshBuilderItem)base[(int)index];
			set => base[(int)index] = value;
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
		public int Length => Count;

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
