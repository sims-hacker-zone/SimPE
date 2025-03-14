// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Linq;

using SimPe.Cache;
using SimPe.PackedFiles.Ngbh.NgbhMetaData;
using SimPe.PackedFiles.Objd;

namespace SimPe.PackedFiles.Ngbh
{
	public enum SimMemoryType : byte
	{
		Memory,
		Gossip,
		Skill,
		Inventory,
		GossipInventory,
		ValueToken,
		Token,
		Object,
		Badge,
		Aspiration,
	}

	public class NgbhItemFlags : FlagBase
	{
		public NgbhItemFlags(ushort flags)
			: base(flags) { }

		public NgbhItemFlags()
			: base(0) { }

		public bool IsVisible
		{
			get => GetBit(0);
			set => SetBit(0, value);
		}

		public bool IsControler
		{
			get => !GetBit(1);
			set => SetBit(1, !value);
		}
	}

	/// <summary>
	/// Contains an Item in a NghbSlot
	/// </summary>
	public class NgbhItem
	{
		internal const int ICON_SIZE = 24; // was 24
		Ngbh parent;

		internal NgbhItem(NgbhSlotList parentslot)
			: this(parentslot, SimMemoryType.Memory) { }

		internal NgbhItem(NgbhSlotList parentslot, SimMemoryType type)
		{
			ParentSlot = parentslot;
			parent = parentslot.Parent;
			data = new ushort[0];
			flags = new NgbhItemFlags();
			objd = null;

			if (
				type == SimMemoryType.Aspiration
				|| type == SimMemoryType.Skill
				|| type == SimMemoryType.ValueToken
				|| type == SimMemoryType.Badge
			)
			{
				Flags.IsVisible = false;
				Flags.IsControler = true;
				data = new ushort[2];
			}
			else if (type == SimMemoryType.Token)
			{
				Flags.IsVisible = false;
				Flags.IsControler = true;
			}
			else if (type == SimMemoryType.Object)
			{
				Flags.IsVisible = false;
				Flags.IsControler = true;
				data = new ushort[3];
			}
			else if (type == SimMemoryType.Gossip || type == SimMemoryType.Memory)
			{
				PutValue(0x01, 0x07CD);
				PutValue(0x02, 0x0006);
				PutValue(0x0B, 0);
				Flags.IsVisible = true;
				Flags.IsControler = false;
				if (type == SimMemoryType.Gossip)
				{
					SimInstance = 1;
				}
			}
			else if (
				type == SimMemoryType.GossipInventory
				|| type == SimMemoryType.Inventory
			)
			{
				Flags.IsVisible = true;
				Flags.IsControler = true;

				if (type == SimMemoryType.GossipInventory)
				{
					data = new ushort[8];
					PutValue(0x01, 0x0);
				}

				InventoryNumber = ParentSlot.GetNextInventoryNumber();
			}

			//SetGuidForType(type);
		}

		public void SetInitialGuid(SimMemoryType type)
		{
			SetGuidForType(type);
		}

		void SetGuidForType(SimMemoryType type)
		{
			Guid = (from container in Cache.Cache.GlobalCache.Items[ContainerType.Memory].Values
					from MemoryCacheItem mci in container
					where
						(
							type == SimMemoryType.Inventory
					 		|| type == SimMemoryType.GossipInventory
					 		|| type == SimMemoryType.Object
						) && mci.IsInventory && !mci.IsToken
					 ||
							(
								type == SimMemoryType.Memory
								|| type == SimMemoryType.Gossip
							) && !mci.IsInventory && !mci.IsToken && mci.IsMemory
					 || !mci.IsInventory && mci.IsToken
					select mci.Guid).FirstOrDefault();
		}

		uint guid;
		NgbhItemFlags flags;
		uint flags2;
		ushort[] data;

		uint invnr;
		ushort unknown2;
		public uint InventoryNumber
		{
			get => invnr;
			set
			{
				if (invnr != value)
				{
					invnr = value;
					if (parent != null)
					{
						parent.Changed = true;
					}
				}
			}
		}

		public ushort UnknownNumber
		{
			get => unknown2;
			set
			{
				unknown2 = value;
				if (parent != null)
				{
					parent.Changed = true;
				}
			}
		}

		protected ExtObjd objd = null;

		/// <summary>
		/// Returns the Slot that owns this Item
		/// </summary>
		public NgbhSlotList ParentSlot
		{
			get;
		}

		/// <summary>
		/// Return the Guid for this Item
		/// </summary>
		public uint Guid
		{
			get => guid;
			set
			{
				if (guid != value)
				{
					guid = value;
					objd = null;

					if (parent != null)
					{
						parent.Changed = true;
					}
				}
			}
		}

		/// <summary>
		/// Yet unknown, probably a Flag
		/// </summary>
		public NgbhItemFlags Flags
		{
			get => flags;
			set
			{
				flags = value;
				if (parent != null)
				{
					parent.Changed = true;
				}
			}
		}

		/// <summary>
		/// Returns / Sets the storeed Data
		/// </summary>
		public ushort[] Data
		{
			get => data;
			set
			{
				data = value;
				if (parent != null)
				{
					parent.Changed = true;
				}
			}
		}

		/// <summary>
		/// Returns the ObjectData for this Item
		/// </summary>
		public ExtObjd ObjectDataFile
		{
			get
			{
				if (objd != null)
				{
					return objd;
				}

				objd = new ExtObjd();

				MemoryCacheItem mci = Cache.Cache.GlobalCache.FindMemoryItem(guid);
				if (mci != null)
				{
					objd.Type = mci.ObjectType;
					objd.Guid = mci.Guid;
					objd.FileName = Localization.Manager.GetString("unknown");
				}

				return objd;
			}
		}
		public MemoryCacheItem MemoryCacheItem => Cache.Cache.GlobalCache.FindMemoryItem(guid)
			?? new MemoryCacheItem();

		public System.Drawing.Image Icon => Ambertation.Drawing.GraphicRoutines.ScaleImage(
					MemoryCacheItem.Image,
					ICON_SIZE,
					ICON_SIZE,
					true
				);

		public bool IsInventory => InventoryNumber != 0;
		public bool IsGossip
		{
			get
			{
				if (ParentSlot is NgbhSlot)
				{
					if (
						OwnerInstance != ((NgbhSlot)ParentSlot).SlotID
						&& OwnerInstance != 0
					)
					{
						return true;
					}
				}

				return false;
			}
		}
#pragma warning disable IDE0046
		public SimMemoryType MemoryType
		{
			get
			{
				bool gossip = IsGossip;

				if (IsInventory)
				{
					if (gossip)
					{
						return SimMemoryType.GossipInventory;
					}

					return SimMemoryType.Inventory;
				}

				if (Flags.IsControler)
				{
					if (MemoryCacheItem.IsBadge)
					{
						return SimMemoryType.Badge;
					}

					if (MemoryCacheItem.IsSkill)
					{
						return SimMemoryType.Skill;
					}

					if (MemoryCacheItem.IsAspiration)
					{
						return SimMemoryType.Aspiration;
					}

					if (Data.Length < 2)
					{
						return SimMemoryType.Token;
					}

					if (Data.Length < 3)
					{
						return SimMemoryType.ValueToken;
					}

					return SimMemoryType.Object;
				}

				if (gossip)
				{
					return SimMemoryType.Gossip;
				}

				return SimMemoryType.Memory;
			}
		}

		/// <summary>
		/// True if this Item can be processed as a Memory
		/// </summary>
		public bool IsMemory =>
					ObjectDataFile.Type
					== SimPe.Data.ObjectTypes.Memory
				;

		/// <summary>
		/// Extension by Theo. Returns true, if this Memory is a Spam Token
		/// </summary>
		public bool IsSpam => Memory.IsSpamMemory(guid);

		/// <summary>
		/// Returns/Sets the Instance of the Sim that owns the Event (not the Memory!)
		/// </summary>
		public ushort Value
		{
			get => GetValue(0x00);
			set => PutValue(0x00, value);
		}

		/// <summary>
		/// Returns/Sets the Instance of the Sim that owns the Event (not the Memory!)
		/// </summary>
		public ushort OwnerInstance
		{
			get => GetValue(0x04);
			set => PutValue(0x04, value);//flags.IsGossip = this.IsGossip;
		}

		public uint SubjectGuid
		{
			get => SimID;
			set => SimID = value;
		}

		/// <summary>
		/// Returns/Sets the value that is possible the SimID (of a Memory)
		/// </summary>
		public uint SimID
		{
			get
			{
				int sid = (GetValue(0x06) << 16) + GetValue(0x05);
				return (uint)sid;
			}
			set
			{
				PutValue(0x05, (ushort)(value & 0x0000ffff));
				PutValue(0x06, (ushort)(value >> 16 & 0x0000ffff));
			}
		}

		/// <summary>
		/// Returns/Sets the value that is possible a Guid to a referenced Object
		/// </summary>
		/// <remarks>
		/// This is only valid if <see cref="MemoryType"/> is set to <see cref="SimMemoryType.Object"/>
		/// </remarks>
		public uint ReferencedObjectGuid
		{
			get
			{
				if (MemoryType != SimMemoryType.Object)
				{
					return 0;
				}

				int sid = (GetValue(0x02) << 16) + GetValue(0x01);
				return (uint)sid;
			}
			set
			{
				if (MemoryType != SimMemoryType.Object)
				{
					return;
				}

				PutValue(0x01, (ushort)(value & 0x0000ffff));
				PutValue(0x02, (ushort)(value >> 16 & 0x0000ffff));
			}
		}

		/// <summary>
		/// Returns/Sets the value that is possible the Instance of a Sim
		/// </summary>
		public ushort SimInstance
		{
			get => GetValue(0x0C);
			set => PutValue(0x0C, value);
		}

		public bool IsSimSubject => SimInstance > 0;

		public void SetSubject(ushort inst, uint guid)
		{
			if (inst != 0)
			{
				SimInstance = inst;
			}
			else
			{
				if (data.Length == 0xD)
				{
					ushort[] nd = new ushort[data.Length - 1];
					for (int i = 0; i < nd.Length; i++)
					{
						nd[i] = data[i];
					}

					data = nd;
				}
			}
			SimID = guid;
		}

		public void SetSubject(uint guid)
		{
			if (FileTableBase.ProviderRegistry.SimDescriptionProvider.SimGuidMap[guid] is Interfaces.Wrapper.ISDesc sdsc)
			{
				SetSubject(sdsc.Instance, guid);
			}
			else
			{
				SetSubject(0, guid);
			}
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		internal void Unserialize(System.IO.BinaryReader reader)
		{
			Guid = reader.ReadUInt32();

			flags = new NgbhItemFlags(reader.ReadUInt16());
			if ((uint)parent.Version >= (uint)NgbhVersion.Business)
			{
				flags2 = new NgbhItemFlags(reader.ReadUInt16());
			}

			invnr = (uint)parent.Version >= (uint)NgbhVersion.Nightlife ? reader.ReadUInt32() : 0;

			unknown2 = (uint)parent.Version >= (uint)NgbhVersion.Seasons ? reader.ReadUInt16() : (ushort)0;

			data = new ushort[reader.ReadInt32()];
			for (int i = 0; i < data.Length; i++)
			{
				data[i] = reader.ReadUInt16();
			}

			if (parent != null)
			{
				parent.Changed = false;
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
		internal void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(guid);
			writer.Write(flags.Value);
			if ((uint)parent.Version >= (uint)NgbhVersion.Business)
			{
				writer.Write((ushort)flags2);
			}

			if ((uint)parent.Version >= (uint)NgbhVersion.Nightlife)
			{
				writer.Write(invnr);
			}

			if ((uint)parent.Version >= (uint)NgbhVersion.Seasons)
			{
				writer.Write(unknown2);
			}

			writer.Write(data.Length);
			for (int i = 0; i < data.Length; i++)
			{
				writer.Write(data[i]);
			}
		}

		/// <summary>
		/// Assignes a Value to the given Slot
		/// </summary>
		/// <param name="slot">Slot Number</param>
		/// <param name="val">new Value</param>
		public void PutValue(int slot, ushort val)
		{
			if (data.Length <= slot)
			{
				ushort[] tmp = new ushort[slot + 1];
				data.CopyTo(tmp, 0);
				data = tmp;
			}
			data[slot] = val;

			if (parent != null)
			{
				parent.Changed = true;
			}
		}

		/// <summary>
		/// Assignes a Value to the given Slot
		/// </summary>
		/// <param name="slot">Slot Number</param>
		/// <param name="val">new Value</param>
		public void SetValue(int slot, ushort val)
		{
			if (data.Length > slot)
			{
				data[slot] = val;
			}
		}

		/// <summary>
		/// Returns the Value of teh Slot
		/// </summary>
		/// <param name="slot">Slotnumber</param>
		/// <returns>the stored Value</returns>
		internal ushort GetValue(int slot)
		{
			return data.Length > slot ? data[slot] : (ushort)0;
		}

		protected string GetSubjectName()
		{
			string ext = " (0x" + Helper.HexString(SimID) + ")";
			string n = Localization.GetString("Unknown") + ext;
			if (parent.Provider.SimNameProvider.StoredData.ContainsKey(SimID))
			{
				n = parent.Provider.SimNameProvider.FindName(SimID).ToString();
			}
			else
			{
				MemoryCacheItem mci = Cache.Cache.GlobalCache.FindMemoryItem(SimID);
				if (mci != null)
				{
					n = mci.Name + ext;
				}
			}

			return n;
		}

		public override string ToString()
		{
			string name = MemoryCacheItem.Name.Replace(
				"$Subject",
				GetSubjectName()
			);
			name = name.Replace("$Constant:4097:7", "X Number of");
			if (name.Trim() == "")
			{
				name = Helper.WindowsRegistry.Config.HiddenMode ? "---" : "[GUID=0x" + Helper.HexString(guid) + "]";
			}
			if (!Flags.IsVisible)
			{
				name = "[invisible] " + name;
			}

			try
			{
				if (
					OwnerInstance != ParentSlot.SlotID
					&& (
						MemoryType == SimMemoryType.Gossip
						|| MemoryType == SimMemoryType.GossipInventory
					)
				)
				{
					uint sid = parent
						.Provider.SimDescriptionProvider.FindSim(OwnerInstance)
						.SimId;

					name += " (" + Localization.GetString("Gossip about") + " ";
					name += parent.Provider.SimNameProvider.FindName(sid);
					name += ")";
				}
			}
			catch (Exception) { }

			if (MemoryType == SimMemoryType.Object)
			{
				name += " {";
				MemoryCacheItem mci = Cache.Cache.GlobalCache.FindMemoryItem(ReferencedObjectGuid);
				if (mci != null)
				{
					name += mci.Name;
				}

				name += "}";
			}

			if (Helper.WindowsRegistry.Config.HiddenMode)
			{
				name += " [GUID=0x" + Helper.HexString(guid) + "]";
			}

			return /*data.Length.ToString()+" "+*/
			name;
		}

		/// <summary>
		/// removes this Item from its parent
		/// </summary>
		public void RemoveFromParentB()
		{
			ParentSlot.ItemsB.Remove(this); // = NgbhSlot.Remove(parentslot.ItemsB, this);
		}

		/// <summary>
		/// Adds this Item to the assignd Parent Slot
		/// </summary>
		public void AddToParentB()
		{
			ParentSlot.ItemsB.Add(this); // = NgbhSlot.Add(parentslot.ItemsB, this);
		}

		/// <summary>
		/// removes this Item from its parent
		/// </summary>
		public void RemoveFromParentA()
		{
			ParentSlot.ItemsA.Remove(this); // = NgbhSlot.Remove(parentslot.ItemsA, this);
		}

		/// <summary>
		/// Adds this Item to the assignd Parent Slot
		/// </summary>
		public void AddToParentA()
		{
			ParentSlot.ItemsA.Add(this); // = NgbhSlot.Add(parentslot.ItemsA, this);
		}

		public NgbhItem Clone()
		{
			return Clone(parent, ParentSlot);
		}

		public NgbhItem Clone(NgbhSlotList parentslot)
		{
			return Clone(parent, parentslot);
		}

		public NgbhItem Clone(Ngbh parent, NgbhSlotList parentslot)
		{
			NgbhItem ret = new NgbhItem(parentslot)
			{
				guid = guid,
				data = data.Clone() as ushort[],
				flags = flags,
				flags2 = flags2,
				parent = parent,
				invnr = invnr
			};
			return ret;
		}
	}
}
