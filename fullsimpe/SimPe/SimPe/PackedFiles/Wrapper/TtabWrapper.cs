/***************************************************************************
 *   Copyright (C) 2006 by Peter L Jones                                   *
 *   pljones@users.sf.net                                                  *
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
using System.Collections.Generic;

using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Wrapper
{
	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class Ttab
		: pjse.ExtendedWrapper<
			TtabItem,
			Ttab
		> //AbstractWrapper				//Implements some of the default Behaviur of a Handler, you can Implement yourself if you want more flexibility!
			,
			IFileWrapper //This Interface is used when loading a File
			,
			IFileWrapperSaveExtension //This Interface (if available) will be used to store a File
									  //,IPackedFileProperties		//This Interface can be used by thirdparties to retrive the FIleproperties, however you don't have to implement it!
	{
		#region Attributes
		private byte[] filename = new byte[64];
		private uint[] header = { 0xffffffff, 0x00000054, 0x00000000 };
		private byte[] footer = new byte[0];
		#endregion

		#region Accessor methods
		public string FileName
		{
			get
			{
				return Helper.ToString(filename);
			}
			set
			{
				if (!Helper.ToString(filename).Equals(value))
				{
					filename = Helper.ToBytes(value, 0x40);
					OnWrapperChanged(this, new EventArgs());
				}
			}
		}
		public uint Format
		{
			get
			{
				return header[1];
			}
			set
			{
				if (header[1] != value)
				{
					header[1] = value;
					OnWrapperChanged(this, new EventArgs());
				}
			}
		}
		public uint Unknown
		{
			get
			{
				return header[2];
			}
			set
			{
				if (header[2] != value)
				{
					header[2] = value;
					OnWrapperChanged(this, new EventArgs());
				}
			}
		}
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public Ttab()
			: base() { }

		public new void Add(TtabItem item)
		{
			Add(item, 0x8000);
		}

		public new void Insert(int index, TtabItem item)
		{
			Insert(index, item, 0x8000);
		}

		#region AbstractWrapper Member
		public override bool CheckVersion(uint version)
		{
			if (
				(version == 0012) //0.00
				|| (version == 0013) //0.10
			)
			{
				return true;
			}

			return false;
		}

		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new UserInterface.TtabForm();
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			///
			/// TODO: Change the Description passed here
			///
			return new AbstractWrapperInfo(
				"PJSE TTAB Wrapper",
				"Peter L Jones",
				"Tree Table Editor",
				1
			);
		}

		private static bool isInuse(TtabItem item)
		{
			return item.InUse;
		}

		/// <summary>
		/// Serializes a the Attributes stored in this Instance to the BinaryStream
		/// </summary>
		/// <param name="writer">The Stream the Data should be stored to</param>
		/// <remarks>
		/// Be sure that the Position of the stream is Proper on
		/// return (i.e. must point to the first Byte after your actual File)
		/// </remarks>
		protected override void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(filename);
			writer.Write(header[0]);
			writer.Write(header[1]);
			writer.Write(header[2]);

			List<TtabItem> inUse = items.FindAll(isInuse);
			writer.Write((ushort)inUse.Count);
			foreach (TtabItem item in inUse)
			{
				item.Serialize(writer);
			}

			writer.Write(footer);
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			filename = reader.ReadBytes(0x40);

			header = new uint[3];
			header[0] = reader.ReadUInt32();
			if (header[0] != 0xffffffff)
			{
				throw new Exception(
					"Unexpected data in TTAB header."
						+ "  Read 0x"
						+ Helper.HexString(header[0])
						+ "."
						+ "  Expected 0xFFFFFFFF."
				);
			}

			header[1] = reader.ReadUInt32();
			header[2] = reader.ReadUInt32();

			ushort itemCount = reader.ReadUInt16();
			items = new List<TtabItem>();
			while (items.Count < itemCount)
			{
				items.Add(new TtabItem(this, reader));
			}

			footer = reader.ReadBytes(
				(int)(reader.BaseStream.Length - reader.BaseStream.Position)
			);
		}

		#endregion

		public const uint Ttabtype = 0x54544142;

		#region IFileWrapper Member
		/// <summary>
		/// Returns a list of File Type this Plugin can process
		/// </summary>
		public uint[] AssignableTypes
		{
			get
			{
				uint[] types = { Ttabtype }; //handles the TTAB File
				return types;
			}
		}

		/// <summary>
		/// Returns the Signature that can be used to identify Files processable with this Plugin
		/// </summary>
		public byte[] FileSignature => new byte[0];

		#endregion

		#region IFileWrapperSaveExtension Member
		//all covered by AbstractWrapper
		protected override string GetResourceName(Data.TypeAlias ta)
		{
			if (!Helper.FileFormat)
			{
				return base.GetResourceName(ta);
			}

			Interfaces.Files.IPackedFile pf = Package.Read(FileDescriptor);
			byte[] ab = pf.GetUncompressedData(0x48);
			return (ab.Length > 0x44 ? "0x" + Helper.HexString(ab[0x44]) + ": " : "")
				+ Helper.ToString(pf.GetUncompressedData(0x40));
		}
		#endregion
	}

	/// <summary>
	/// An Item stored in an TTAB
	/// </summary>
	public class TtabItem : pjse.ExtendedWrapperItem<Ttab, TtabItem>
	{
		#region Attributes
		private ushort action = 0;
		private ushort guard = 0;
		private int[] counts = null;

		//private TtabFlags flags = null;
		//private ushort flags2 = 0;
		private ushort flags = 0;
		private ushort flags2 = 0;
		private uint strindex = 0;
		private uint attenuationcode = 0;
		private float attenuationvalue = 0f;
		private uint autonomy = 0;
		private uint joinindex = 0;
		private ushort uidisplaytype = 0;
		private uint facialanimation = 0;
		private float memoryitermult = 0f;
		private uint objecttype = 0;
		private uint modeltableid = 0;
		private TtabItemMotiveTable humanGroups = null;
		private TtabItemMotiveTable animalGroups = null;
		#endregion

		#region Accessor Methods
		public ushort Action
		{
			get
			{
				return action;
			}
			set
			{
				if (action != value)
				{
					action = value;
					if (parent != null)
					{
						parent.OnWrapperChanged(this, new EventArgs());
					}
				}
			}
		}

		public ushort Guardian
		{
			get
			{
				return guard;
			}
			set
			{
				if (guard != value)
				{
					guard = value;
					if (parent != null)
					{
						parent.OnWrapperChanged(this, new EventArgs());
					}
				}
			}
		}

		public ushort Flags
		{
			get
			{
				return flags;
			}
			set
			{
				if (flags != value)
				{
					flags = value;
					if (parent != null)
					{
						parent.OnWrapperChanged(this, new EventArgs());
					}
				}
			}
		}

		public ushort Flags2
		{
			get
			{
				return flags2;
			}
			set
			{
				if (flags2 != value)
				{
					flags2 = value;
					if (parent != null)
					{
						parent.OnWrapperChanged(this, new EventArgs());
					}
				}
			}
		}

		public uint StringIndex
		{
			get
			{
				return strindex;
			}
			set
			{
				if (strindex != value)
				{
					strindex = value;
					if (parent != null)
					{
						parent.OnWrapperChanged(this, new EventArgs());
					}
				}
			}
		}

		public uint AttenuationCode
		{
			get
			{
				return attenuationcode;
			}
			set
			{
				if (attenuationcode != value)
				{
					attenuationcode = value;
					if (parent != null)
					{
						parent.OnWrapperChanged(this, new EventArgs());
					}
				}
			}
		}

		public float AttenuationValue
		{
			get
			{
				return attenuationvalue;
			}
			set
			{
				if (attenuationvalue != value)
				{
					attenuationvalue = value;
					if (parent != null)
					{
						parent.OnWrapperChanged(this, new EventArgs());
					}
				}
			}
		}

		public uint Autonomy
		{
			get
			{
				return autonomy;
			}
			set
			{
				if (autonomy != value)
				{
					autonomy = value;
					if (parent != null)
					{
						parent.OnWrapperChanged(this, new EventArgs());
					}
				}
			}
		}

		public uint JoinIndex
		{
			get
			{
				return joinindex;
			}
			set
			{
				if (joinindex != value)
				{
					joinindex = value;
					if (parent != null)
					{
						parent.OnWrapperChanged(this, new EventArgs());
					}
				}
			}
		}

		public ushort UIDisplayType
		{
			get
			{
				return uidisplaytype;
			}
			set
			{
				if (uidisplaytype != value)
				{
					uidisplaytype = value;
					if (parent != null)
					{
						parent.OnWrapperChanged(this, new EventArgs());
					}
				}
			}
		}

		public uint FacialAnimationID
		{
			get
			{
				return facialanimation;
			}
			set
			{
				if (facialanimation != value)
				{
					facialanimation = value;
					if (parent != null)
					{
						parent.OnWrapperChanged(this, new EventArgs());
					}
				}
			}
		}

		public float MemoryIterativeMultiplier
		{
			get
			{
				return memoryitermult;
			}
			set
			{
				if (!memoryitermult.Equals(value))
				{
					memoryitermult = value;
					if (parent != null)
					{
						parent.OnWrapperChanged(this, new EventArgs());
					}
				}
			}
		}

		public uint ObjectType
		{
			get
			{
				return objecttype;
			}
			set
			{
				if (objecttype != value)
				{
					objecttype = value;
					if (parent != null)
					{
						parent.OnWrapperChanged(this, new EventArgs());
					}
				}
			}
		}

		public uint ModelTableID
		{
			get
			{
				return modeltableid;
			}
			set
			{
				if (modeltableid != value)
				{
					modeltableid = value;
					if (parent != null)
					{
						parent.OnWrapperChanged(this, new EventArgs());
					}
				}
			}
		}

		public TtabItemMotiveTable HumanMotives
		{
			get
			{
				return humanGroups;
			}
			set
			{
				if (humanGroups != value)
				{
					humanGroups = value;
					if (parent != null)
					{
						parent.OnWrapperChanged(this, new EventArgs());
					}
				}
			}
		}

		public TtabItemMotiveTable AnimalMotives
		{
			get
			{
				return animalGroups;
			}
			set
			{
				if (animalGroups != value)
				{
					animalGroups = value;
					if (parent != null)
					{
						parent.OnWrapperChanged(this, new EventArgs());
					}
				}
			}
		}
		#endregion

		public TtabItem(Ttab parent)
		{
			this.parent = parent;

			if (parent.Format < 0x44)
			{
				counts = new int[] { 0x10 };
			}
			else if (parent.Format < 0x54)
			{
				counts = new int[] { 0x10, 0x10, 0x10, 0x10, 0x10, 0x10, 0x10 };
			}

			humanGroups = new TtabItemMotiveTable(
				this,
				counts,
				TtabItemMotiveTableType.Human
			);
			animalGroups = new TtabItemMotiveTable(
				this,
				null,
				TtabItemMotiveTableType.Animal
			);
		}

		public TtabItem(Ttab parent, System.IO.BinaryReader reader)
			: this(parent)
		{
			Unserialize(reader);
		}

		private void CopyTo(TtabItem target)
		{
			target.action = action;
			target.guard = guard;
			target.flags = flags;
			target.flags2 = flags2;
			target.strindex = strindex;
			target.attenuationcode = attenuationcode;
			target.attenuationvalue = attenuationvalue;
			target.autonomy = autonomy;
			target.joinindex = joinindex;
			target.uidisplaytype = uidisplaytype;
			target.facialanimation = facialanimation;
			target.memoryitermult = memoryitermult;
			target.objecttype = objecttype;
			target.modeltableid = modeltableid;
			if (humanGroups != null)
			{
				humanGroups.CopyTo(target.humanGroups);
			}

			if (animalGroups != null)
			{
				animalGroups.CopyTo(target.animalGroups);
			}
		}

		public TtabItem Clone(Ttab parent)
		{
			TtabItem clone = new TtabItem(this.parent);
			clone.parent = parent;
			CopyTo(clone);
			return clone;
		}

		public TtabItem Clone()
		{
			return Clone(parent);
		}

		/// <summary>
		/// Reads Data from the Stream
		/// </summary>
		/// <param name="reader"></param>
		private void Unserialize(System.IO.BinaryReader reader)
		{
			action = reader.ReadUInt16();
			guard = reader.ReadUInt16();

			if (counts != null)
			{
				for (int i = 0; i < counts.Length; i++)
				{
					counts[i] = reader.ReadInt32();
				}
			}

			flags = reader.ReadUInt16();
			flags2 = reader.ReadUInt16();

			strindex = reader.ReadUInt32();
			attenuationcode = reader.ReadUInt32();
			attenuationvalue = reader.ReadSingle(); //float
			autonomy = reader.ReadUInt32();
			joinindex = reader.ReadUInt32();

			uidisplaytype = 0;
			facialanimation = 0;
			memoryitermult = 0f;
			objecttype = 0;
			modeltableid = 0;
			if (parent.Format >= 0x45)
			{
				uidisplaytype = reader.ReadUInt16();
				if (parent.Format >= 0x46)
				{
					if (parent.Format >= 0x4a)
					{
						facialanimation = reader.ReadUInt32();
						if (parent.Format >= 0x4c)
						{
							memoryitermult = reader.ReadSingle(); //float
							objecttype = reader.ReadUInt32();
						}
					}
					modeltableid = reader.ReadUInt32();
				}
			}

			humanGroups = new TtabItemMotiveTable(
				this,
				counts,
				TtabItemMotiveTableType.Human,
				reader
			);
			if (parent.Format >= 0x54)
			{
				animalGroups = new TtabItemMotiveTable(
					this,
					null,
					TtabItemMotiveTableType.Animal,
					reader
				);
			}
		}

		/// <summary>
		/// Writes Data to the Stream
		/// </summary>
		/// <param name="reader"></param>
		internal void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(action);
			writer.Write(guard);

			uint nGroups = 0;
			if (parent.Format < 0x44)
			{
				nGroups = 1;
			}
			else if (parent.Format < 0x54)
			{
				nGroups = 7;
			}

			for (int i = 0; i < nGroups; i++)
			{
				writer.Write(i < humanGroups.Count ? humanGroups[i].EntriesInUse : 0);
			}

			writer.Write(flags);
			writer.Write(flags2);
			writer.Write(strindex);
			writer.Write(attenuationcode);
			writer.Write(attenuationvalue);
			writer.Write(autonomy);
			writer.Write(joinindex);

			if (parent.Format > 0x44)
			{
				writer.Write(uidisplaytype);
				if (parent.Format >= 0x46)
				{
					if (parent.Format >= 0x4a)
					{
						writer.Write(facialanimation);
						if (parent.Format >= 0x4c)
						{
							writer.Write(memoryitermult);
							writer.Write(objecttype);
						}
					}
					writer.Write(modeltableid);
				}
			}
			humanGroups.Serialize(writer);
			if (parent.Format >= 0x54)
			{
				animalGroups.Serialize(writer);
			}
		}

		public bool InUse => true;
	}

	public class TtabItemMotiveTable : ICollection
	{
		#region Attributes
		private int[] counts = null;
		private TtabItemMotiveTableType type;
		private TtabItemMotiveGroupArrayList items = null;
		#endregion

		#region Accessor Methods
		public Ttab Wrapper => Parent == null ? null : Parent.Parent;
		public TtabItem Parent
		{
			get; set;
		}
		public TtabItemMotiveTableType Type
		{
			get
			{
				return type;
			}
			set
			{
				if (type != value)
				{
					type = value;
					if (Wrapper != null)
					{
						Wrapper.OnWrapperChanged(this, new EventArgs());
					}
				}
			}
		}
		#endregion


		public TtabItemMotiveTable(
			TtabItem parent,
			int[] counts,
			TtabItemMotiveTableType type
		)
		{
			Parent = parent;
			this.counts = counts;
			this.type = type;

			int nrGroups = 0;
			if (counts != null)
			{
				nrGroups = counts.Length;
			}
			else
			{
				nrGroups = type == TtabItemMotiveTableType.Human ? 5 : 8;
			}

			items = new TtabItemMotiveGroupArrayList(new TtabItemMotiveGroup[nrGroups]);
			for (int i = 0; i < nrGroups; i++)
			{
				items[i] = new TtabItemMotiveGroup(
					this,
					counts != null ? counts[i] : -1,
					type
				);
			}
		}

		public TtabItemMotiveTable(
			TtabItem parent,
			int[] counts,
			TtabItemMotiveTableType type,
			System.IO.BinaryReader reader
		)
			: this(parent, counts, type)
		{
			Unserialize(reader);
		}

		public void CopyTo(TtabItemMotiveTable target)
		{
			if (target == null)
			{
				return;
			}

			for (int i = 0; i < target.items.Count && i < items.Count; i++)
			{
				target.items[i] = items[i].Clone();
			}

			for (int i = items.Count; i < target.items.Count; i++)
			{
				target.items[i] = items[0].Clone();
			}
		}

		private TtabItemMotiveTable Clone(TtabItem parent)
		{
			TtabItemMotiveTable clone = new TtabItemMotiveTable(parent, counts, type);
			CopyTo(clone);
			return clone;
		}

		private TtabItemMotiveTable Clone()
		{
			return Clone(Parent);
		}

		private void Unserialize(System.IO.BinaryReader reader)
		{
			int nrGroups = 0;
			if (counts != null)
			{
				nrGroups = counts.Length;
			}
			else
			{
				nrGroups = reader.ReadInt32();
			}

			if (items.Capacity < nrGroups)
			{
				items = new TtabItemMotiveGroupArrayList(
					new TtabItemMotiveGroup[nrGroups]
				);
			}

			for (int i = 0; i < nrGroups; i++)
			{
				items[i] = new TtabItemMotiveGroup(
					this,
					counts != null ? counts[i] : 0,
					type,
					reader
				);
			}
		}

		internal void Serialize(System.IO.BinaryWriter writer)
		{
			int entries = Wrapper.Format < 0x54 ? items.Count : items.EntriesInUse;
			if (Wrapper.Format >= 0x54)
			{
				writer.Write(entries);
			}

			for (int i = 0; i < entries; i++)
			{
				items[i].Serialize(writer);
			}
		}

		#region TtabItemMotiveGroupArrayList
		private class TtabItemMotiveGroupArrayList : ArrayList
		{
			public TtabItemMotiveGroupArrayList()
				: base() { }

			public TtabItemMotiveGroupArrayList(TtabItemMotiveGroup[] c)
				: base(c) { }

			public TtabItemMotiveGroupArrayList(int capacity)
				: base(capacity) { }

			public new TtabItemMotiveGroup this[int index]
			{
				get
				{
					return (TtabItemMotiveGroup)base[index];
				}
				set
				{
					base[index] = value;
				}
			}

			public TtabItemMotiveGroupArrayList Clone(TtabItemMotiveTable parent)
			{
				TtabItemMotiveGroupArrayList clone = new TtabItemMotiveGroupArrayList();
				foreach (TtabItemMotiveGroup item in this)
				{
					clone.Add(item.Clone(parent));
				}

				return clone;
			}

			public override object Clone()
			{
				return Clone(null);
			}

			public int EntriesInUse
			{
				get
				{
					for (int i = Count; i > 0; i--)
					{
						if (this[i - 1].InUse)
						{
							return i;
						}
					}

					return 0;
				}
			}
		}
		#endregion

		#region ICollection Members
		public int Add(TtabItemMotiveGroup item)
		{
			//if (items.Count >= 0x08) // we don't really know...
			//return -1;

			item.Parent = this;
			int result = items.Add(item);
			if (result >= 0 && Wrapper != null)
			{
				Wrapper.OnWrapperChanged(this, new EventArgs());
			}

			return result;
		}

		public void Clear()
		{
			items.Clear();
			if (Wrapper != null)
			{
				Wrapper.OnWrapperChanged(this, new EventArgs());
			}
		}

		public void Remove(TtabItemMotiveGroup item)
		{
			RemoveAt(items.IndexOf(item));
		}

		public void RemoveAt(int index)
		{
			if (index < 0 || index >= items.Count)
			{
				return;
			}

			items.RemoveAt(index);
			if (Wrapper != null)
			{
				Wrapper.OnWrapperChanged(this, new EventArgs());
			}
		}

		public TtabItemMotiveGroup this[int index]
		{
			get
			{
				return items[index];
			}
			set
			{
				if (items[index] != value)
				{
					items[index] = value;
					if (items[index] != null)
					{
						items[index].Parent = this;
					}

					if (Wrapper != null)
					{
						Wrapper.OnWrapperChanged(this, new EventArgs());
					}
				}
			}
		}

		public bool Contains(TtabItem item)
		{
			return items.Contains(item);
		}

		public int IndexOf(object item)
		{
			return items.IndexOf(item);
		}

		public void CopyTo(Array a, int i)
		{
			items.CopyTo(a, i);
		}

		public int Count => items.Count;

		public bool IsSynchronized => items.IsSynchronized;

		public object SyncRoot => items.SyncRoot;

		#region IEnumerable Members
		public IEnumerator GetEnumerator()
		{
			return items.GetEnumerator();
		}

		#endregion
		#endregion
	}

	public class TtabItemMotiveGroup : ICollection
	{
		#region Attributes
		private int count;
		private TtabItemMotiveTableType type;
		private TtabItemMotiveItemArrayList items = null;
		#endregion

		#region Accessor Methods
		public Ttab Wrapper => Parent == null ? null : Parent.Wrapper;
		public TtabItemMotiveTable Parent
		{
			get; set;
		}
		#endregion

		public TtabItemMotiveGroup(
			TtabItemMotiveTable parent,
			int count,
			TtabItemMotiveTableType type
		)
		{
			Parent = parent;
			this.count = count;
			this.type = type;

			int nrItems = count != -1 ? count : 16;

			items = new TtabItemMotiveItemArrayList(
				new TtabItemMotiveItem[nrItems < 16 ? 16 : nrItems]
			);
			if (type == TtabItemMotiveTableType.Human)
			{
				for (int i = 0; i < nrItems; i++)
				{
					items[i] = new TtabItemSingleMotiveItem(this);
				}
			}
			else
			{
				for (int i = 0; i < nrItems; i++)
				{
					items[i] = new TtabItemAnimalMotiveItem(this);
				}
			}
		}

		public TtabItemMotiveGroup(
			TtabItemMotiveTable parent,
			int count,
			TtabItemMotiveTableType type,
			System.IO.BinaryReader reader
		)
			: this(parent, count, type)
		{
			Unserialize(reader);
		}

		private void CopyTo(TtabItemMotiveGroup target)
		{
			target.items = items == null ? null : items.Clone(target);
		}

		public TtabItemMotiveGroup Clone(TtabItemMotiveTable parent)
		{
			TtabItemMotiveGroup clone = new TtabItemMotiveGroup(parent, count, type);
			CopyTo(clone);
			return clone;
		}

		public TtabItemMotiveGroup Clone()
		{
			return Clone(Parent);
		}

		private void Unserialize(System.IO.BinaryReader reader)
		{
			int nrItems = Wrapper.Format < 0x54 ? count : reader.ReadInt32();

			if (type == TtabItemMotiveTableType.Human)
			{
				for (int i = 0; i < nrItems; i++)
				{
					items[i] = new TtabItemSingleMotiveItem(this, reader);
				}

				for (int i = nrItems; i < items.Count; i++)
				{
					items[i] = new TtabItemSingleMotiveItem(this);
				}
			}
			else
			{
				for (int i = 0; i < nrItems; i++)
				{
					items[i] = new TtabItemAnimalMotiveItem(this, reader);
				}

				for (int i = nrItems; i < items.Count; i++)
				{
					items[i] = new TtabItemAnimalMotiveItem(this);
				}
			}
		}

		internal void Serialize(System.IO.BinaryWriter writer)
		{
			int entries = items.EntriesInUse;
			if (Wrapper.Format >= 0x54)
			{
				writer.Write(entries);
			}

			for (int i = 0; i < entries; i++)
			{
				items[i].Serialize(writer);
			}
		}

		public bool InUse
		{
			get
			{
				foreach (TtabItemMotiveItem i in items)
				{
					if (i.InUse)
					{
						return true;
					}
				}

				return false;
			}
		}

		public int EntriesInUse => items.EntriesInUse;

		private class TtabItemMotiveItemArrayList : ArrayList
		{
			public TtabItemMotiveItemArrayList()
				: base() { }

			public TtabItemMotiveItemArrayList(TtabItemMotiveItem[] c)
				: base(c) { }

			public TtabItemMotiveItemArrayList(int capacity)
				: base(capacity) { }

			public new TtabItemMotiveItem this[int index]
			{
				get
				{
					return (TtabItemMotiveItem)base[index];
				}
				set
				{
					base[index] = value;
				}
			}

			/// <summary>
			/// Creates a deep copy of the TtabItemMotiveItemArrayList
			/// </summary>
			public TtabItemMotiveItemArrayList Clone(TtabItemMotiveGroup parent)
			{
				TtabItemMotiveItemArrayList clone = new TtabItemMotiveItemArrayList();
				foreach (TtabItemMotiveItem item in this)
				{
					clone.Add(item.Clone(parent));
				}

				return clone;
			}

			public override object Clone()
			{
				return Clone(null);
			}

			public int EntriesInUse
			{
				get
				{
					for (int i = Count; i > 0; i--)
					{
						if (this[i - 1].InUse)
						{
							return i;
						}
					}

					return 0;
				}
			}
		}

		#region ICollection Members
		public int Add(TtabItemMotiveItem item)
		{
			//if (items.Count >= 0x10) // we don't really know...
			//return -1;

			item.Parent = this;
			int result = items.Add(item);
			if (result >= 0 && Wrapper != null)
			{
				Wrapper.OnWrapperChanged(this, new EventArgs());
			}

			return result;
		}

		public void Clear()
		{
			for (int i = 0; i < items.Count; i++)
			{
				items[i] =
					type == TtabItemMotiveTableType.Human
						? (TtabItemMotiveItem)new TtabItemSingleMotiveItem(this)
						: (TtabItemMotiveItem)new TtabItemAnimalMotiveItem(this);
			}

			if (Wrapper != null)
			{
				Wrapper.OnWrapperChanged(this, new EventArgs());
			}
		}

		public void Remove(TtabItemMotiveItem item)
		{
			RemoveAt(items.IndexOf(item));
		}

		public void RemoveAt(int index)
		{
			if (index < 0 || index >= items.Count)
			{
				return;
			}

			items.RemoveAt(index);
			if (Wrapper != null)
			{
				Wrapper.OnWrapperChanged(this, new EventArgs());
			}
		}

		public TtabItemMotiveItem this[int index]
		{
			get
			{
				return items[index];
			}
			set
			{
				if (items[index] != value)
				{
					items[index] = value;
					if (items[index] != null)
					{
						items[index].Parent = this;
					}

					if (Wrapper != null)
					{
						Wrapper.OnWrapperChanged(this, new EventArgs());
					}
				}
			}
		}

		public bool Contains(TtabItemMotiveItem item)
		{
			return items.Contains(item);
		}

		public int IndexOf(object item)
		{
			return items.IndexOf(item);
		}

		public void CopyTo(Array a, int i)
		{
			items.CopyTo(a, i);
		}

		public int Count => items.Count;

		public bool IsSynchronized => items.IsSynchronized;

		public object SyncRoot => items.SyncRoot;

		#region IEnumerable Members
		public IEnumerator GetEnumerator()
		{
			return items.GetEnumerator();
		}

		#endregion
		#endregion
	}

	public abstract class TtabItemMotiveItem
	{
		#region Attributes
		protected TtabItemMotiveGroup parent = null;
		#endregion

		#region Accessor Methods
		public Ttab Wrapper => parent == null ? null : parent.Wrapper;
		public TtabItemMotiveGroup Parent
		{
			get
			{
				return parent;
			}
			set
			{
				parent = value;
			}
		}
		#endregion

		public TtabItemMotiveItem(TtabItemMotiveGroup parent)
		{
			this.parent = parent;
		}

		public TtabItemMotiveItem(
			TtabItemMotiveGroup parent,
			System.IO.BinaryReader reader
		)
			: this(parent)
		{
			Unserialize(reader);
		}

		protected abstract void CopyTo(TtabItemMotiveItem target, bool doEvent);

		public void CopyTo(TtabItemMotiveItem target)
		{
			CopyTo(target, true);
		}

		public abstract TtabItemMotiveItem Clone(TtabItemMotiveGroup parent);

		public TtabItemMotiveItem Clone()
		{
			return Clone(parent);
		}

		protected abstract void Unserialize(System.IO.BinaryReader reader);
		internal abstract void Serialize(System.IO.BinaryWriter writer);
		public abstract bool InUse
		{
			get;
		}
	}

	public class TtabItemAnimalMotiveItem : TtabItemMotiveItem, ICollection
	{
		#region Attributes
		private TtabItemSingleMotiveItemArrayList items =
			new TtabItemSingleMotiveItemArrayList(new TtabItemSingleMotiveItem[0]);
		#endregion

		#region Accessor Methods
		// All covered by ICollection
		#endregion

		public TtabItemAnimalMotiveItem(TtabItemMotiveGroup parent)
			: base(parent) { }

		public TtabItemAnimalMotiveItem(
			TtabItemMotiveGroup parent,
			System.IO.BinaryReader reader
		)
			: base(parent, reader) { }

		protected override void CopyTo(TtabItemMotiveItem target, bool doEvent)
		{
			if (!(target is TtabItemAnimalMotiveItem))
			{
				throw new ArgumentException("Argument must be of same type", "target");
			} ((TtabItemAnimalMotiveItem)target).items =
				items == null ? null : items.Clone((TtabItemAnimalMotiveItem)target);
			if (doEvent && target.Wrapper != null)
			{
				target.Wrapper.OnWrapperChanged(target, new EventArgs());
			}
		}

		public override TtabItemMotiveItem Clone(TtabItemMotiveGroup parent)
		{
			TtabItemAnimalMotiveItem clone = new TtabItemAnimalMotiveItem(parent);
			CopyTo(clone, false);
			return clone;
		}

		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			int count = reader.ReadInt32();
			items = new TtabItemSingleMotiveItemArrayList(
				new TtabItemSingleMotiveItem[count]
			);
			for (int i = 0; i < count; i++)
			{
				items[i] = new TtabItemSingleMotiveItem(parent, reader);
			}
		}

		internal override void Serialize(System.IO.BinaryWriter writer)
		{
			int entries = items.EntriesInUse;
			writer.Write(entries);
			for (int i = 0; i < entries; i++)
			{
				items[i].Serialize(writer);
			}
		}

		public override bool InUse
		{
			get
			{
				foreach (TtabItemSingleMotiveItem i in items)
				{
					if (i.InUse)
					{
						return true;
					}
				}

				return false;
			}
		}

		private class TtabItemSingleMotiveItemArrayList : ArrayList
		{
			public TtabItemSingleMotiveItemArrayList()
				: base() { }

			public TtabItemSingleMotiveItemArrayList(TtabItemSingleMotiveItem[] c)
				: base(c) { }

			public TtabItemSingleMotiveItemArrayList(int capacity)
				: base(capacity) { }

			public new TtabItemSingleMotiveItem this[int index]
			{
				get
				{
					return (TtabItemSingleMotiveItem)base[index];
				}
				set
				{
					base[index] = value;
				}
			}

			/// <summary>
			/// Creates a deep copy of the TtabItemMotiveItemArrayList
			/// </summary>
			public TtabItemSingleMotiveItemArrayList Clone(
				TtabItemAnimalMotiveItem parent
			)
			{
				TtabItemSingleMotiveItemArrayList clone =
					new TtabItemSingleMotiveItemArrayList();
				foreach (TtabItemSingleMotiveItem item in this)
				{
					clone.Add(item.Clone(parent.parent));
				}

				return clone;
			}

			public override object Clone()
			{
				return Clone(null);
			}

			public int EntriesInUse
			{
				get
				{
					for (int i = Count; i > 0; i--)
					{
						if (this[i - 1].InUse)
						{
							return i;
						}
					}

					return 0;
				}
			}
		}

		#region ICollection Members
		public int Add(TtabItemSingleMotiveItem item)
		{
			item.Parent = parent;
			int result = items.Add(item);
			if (result >= 0 && Wrapper != null)
			{
				Wrapper.OnWrapperChanged(this, new EventArgs());
			}

			return result;
		}

		public void Clear()
		{
			for (int i = 0; i < items.Count; i++)
			{
				items[i] = new TtabItemSingleMotiveItem(parent);
			}

			if (Wrapper != null)
			{
				Wrapper.OnWrapperChanged(this, new EventArgs());
			}
		}

		public void Remove(TtabItemSingleMotiveItem item)
		{
			RemoveAt(items.IndexOf(item));
		}

		public void RemoveAt(int index)
		{
			if (index < 0 || index >= items.Count)
			{
				return;
			}

			items.RemoveAt(index);
			if (Wrapper != null)
			{
				Wrapper.OnWrapperChanged(this, new EventArgs());
			}
		}

		public TtabItemSingleMotiveItem this[int index]
		{
			get
			{
				return items[index];
			}
			set
			{
				if (items[index] != value)
				{
					items[index] = value;
					if (items[index] != null)
					{
						items[index].Parent = parent;
					}

					if (Wrapper != null)
					{
						Wrapper.OnWrapperChanged(this, new EventArgs());
					}
				}
			}
		}

		public bool Contains(TtabItemSingleMotiveItem item)
		{
			return items.Contains(item);
		}

		public int IndexOf(object item)
		{
			return items.IndexOf(item);
		}

		public void CopyTo(Array a, int i)
		{
			items.CopyTo(a, i);
		}

		public int Count => items.Count;

		public bool IsSynchronized => items.IsSynchronized;

		public object SyncRoot => items.SyncRoot;

		#region IEnumerable Members
		public IEnumerator GetEnumerator()
		{
			return items.GetEnumerator();
		}

		#endregion
		#endregion
	}

	public class TtabItemSingleMotiveItem : TtabItemMotiveItem
	{
		#region Attributes
		private short[] items = new short[3];
		#endregion

		#region Accessor Methods
		public short Min
		{
			get
			{
				return this[0];
			}
			set
			{
				this[0] = value;
			}
		}
		public short Delta
		{
			get
			{
				return items[1];
			}
			set
			{
				this[1] = value;
			}
		}
		public short Type
		{
			get
			{
				return items[2];
			}
			set
			{
				this[2] = value;
			}
		}
		#endregion

		public TtabItemSingleMotiveItem(TtabItemMotiveGroup parent)
			: base(parent) { }

		public TtabItemSingleMotiveItem(
			TtabItemMotiveGroup parent,
			System.IO.BinaryReader reader
		)
			: base(parent, reader) { }

		protected override void CopyTo(TtabItemMotiveItem target, bool doEvent)
		{
			if (!(target is TtabItemSingleMotiveItem))
			{
				throw new ArgumentException("Argument must be of same type", "target");
			}

			items.CopyTo(((TtabItemSingleMotiveItem)target).items, 0);
			if (doEvent && target.Wrapper != null)
			{
				target.Wrapper.OnWrapperChanged(target, new EventArgs());
			}
		}

		public override TtabItemMotiveItem Clone(TtabItemMotiveGroup parent)
		{
			TtabItemSingleMotiveItem clone = new TtabItemSingleMotiveItem(parent);
			CopyTo(clone, false);
			return clone;
		}

		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			for (int i = 0; i < items.Length; i++)
			{
				items[i] = reader.ReadInt16();
			}
		}

		internal override void Serialize(System.IO.BinaryWriter writer)
		{
			for (int i = 0; i < items.Length; i++)
			{
				writer.Write(items[i]);
			}
		}

		public override bool InUse => (items[0] != 0 || items[1] != 0 || items[2] != 0);

		private short this[int index]
		{
			get
			{
				return items[index];
			}
			set
			{
				if (items[index] != value)
				{
					items[index] = value;
					if (Wrapper != null)
					{
						Wrapper.OnWrapperChanged(this, new EventArgs());
					}
				}
			}
		}
	}

	#region Enums
	public enum TtabItemMotiveTableType : int
	{
		Human,
		Animal,
	}
	#endregion
}
