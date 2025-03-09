// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

namespace SimPe.PackedFiles.Ngbh
{
	/// <summary>
	/// A Slot contains a number of NgbhItem Objects
	/// </summary>
	public class NgbhSlotList
	{
		uint version;
		public NgbhVersion Version
		{
			get => (NgbhVersion)version;
			set => version = (uint)value;
		}

		public Ngbh Parent
		{
			get;
		}

		public NgbhSlotList(Ngbh parent)
		{
			Version = parent != null ? parent.Version : NgbhVersion.University;

			Parent = parent;
			itemsa = new NgbhItems(this);
			itemsb = new NgbhItems(this);
		}

		/// <summary>
		/// Id of a Slot
		/// </summary>
		uint slotid;

		/// <summary>
		/// Returns / Sets the ID of this Slot
		/// </summary>
		public uint SlotID
		{
			get => slotid;
			set
			{
				if (slotid != value)
				{
					slotid = value;
					if (Parent != null)
					{
						Parent.Changed = true;
					}
				}
			}
		}

		/// <summary>
		/// stored items
		/// </summary>
		NgbhItems itemsa;

		/// <summary>
		/// Returns / Sets the stored NgbhItem
		/// </summary>
		public NgbhItems ItemsA
		{
			get => itemsa;
			set
			{
				itemsa = value;
				if (Parent != null)
				{
					Parent.Changed = true;
				}
			}
		}

		/// <summary>
		/// stored items
		/// </summary>
		NgbhItems itemsb;

		/// <summary>
		/// Returns / Sets the stored NgbhItem
		/// </summary>
		public NgbhItems ItemsB
		{
			get => itemsb;
			set
			{
				itemsb = value;
				if (Parent != null)
				{
					Parent.Changed = true;
				}
			}
		}

		public NgbhItems GetItems(Data.NeighborhoodSlots id)
		{
			return id == Data.NeighborhoodSlots.Families
				|| id == Data.NeighborhoodSlots.Lots
				|| id == Data.NeighborhoodSlots.Sims
				? ItemsB
				: ItemsA;
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		internal virtual void Unserialize(System.IO.BinaryReader reader)
		{
			if ((uint)Parent.Version >= (uint)NgbhVersion.Nightlife)
			{
				version = reader.ReadUInt32();
			}

			uint ct = reader.ReadUInt32();
			itemsa.Clear();
			for (int j = 0; j < ct; j++)
			{
				NgbhItem item = itemsa.AddNew();
				item.Unserialize(reader);
			}

			ct = reader.ReadUInt32();
			itemsb.Clear();
			for (int j = 0; j < ct; j++)
			{
				NgbhItem item = itemsb.AddNew();
				item.Unserialize(reader);
			}

			if (Parent != null)
			{
				Parent.Changed = false;
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
			if ((uint)Parent.Version >= (uint)NgbhVersion.Nightlife)
			{
				writer.Write(version);
			}

			writer.Write((uint)itemsa.Length);
			for (int j = 0; j < itemsa.Length; j++)
			{
				itemsa[j].Serialize(writer);
			}

			writer.Write((uint)itemsb.Length);
			for (int j = 0; j < itemsb.Length; j++)
			{
				itemsb[j].Serialize(writer);
			}
		}

		public uint GetNextInventoryNumber()
		{
			return Math.Max(
					itemsa.GetMaxInventoryNumber(),
					itemsb.GetMaxInventoryNumber()
				) + 1;
		}

		public NgbhItem FindItem(uint guid)
		{
			return itemsa.FindItemByGuid(guid) ?? itemsb.FindItemByGuid(guid);
		}

		public int CountItem(uint guid)
		{
			int wooh = itemsa.CountItemsByGuid(guid);
			if (wooh == 0)
			{
				wooh = itemsb.CountItemsByGuid(guid);
			}

			return wooh;
		}
	}

	/// <summary>
	/// A Slot contains a number of NgbhItem Objects
	/// </summary>
	public class NgbhSlot : NgbhSlotList
	{
		public Data.NeighborhoodSlots Type
		{
			get;
		}

		internal NgbhSlot(Ngbh parent, Data.NeighborhoodSlots type)
			: base(parent)
		{
			Type = type;
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		internal override void Unserialize(System.IO.BinaryReader reader)
		{
			SlotID = reader.ReadUInt32();

			base.Unserialize(reader);
		}

		/// <summary>
		/// Serializes a the Attributes stored in this Instance to the BinaryStream
		/// </summary>
		/// <param name="writer">The Stream the Data should be stored to</param>
		/// <remarks>
		/// Be sure that the Position of the stream is Proper on
		/// return (i.e. must point to the first Byte after your actual File)
		/// </remarks>
		internal override void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(SlotID);

			base.Serialize(writer);
		}

		public override string ToString()
		{
			return "0x"
				+ Helper.HexString(SlotID)
				+ ": "
				+ ItemsA.Count
				+ ", "
				+ ItemsB.Count;
		}

		#region extension by Theo
		/// <summary>
		/// 1. Delete my memories shared by others,
		/// 2. Delete others' memories whose subject is me
		/// </summary>
		/// <returns>Number of deleted Memories</returns>
		public int RemoveMemoriesAboutMe()
		{
			int deletedCount = 0;
			NgbhItems memoriesToRemove =
				new NgbhItems(null);

			NgbhSlots slots = Parent.GetSlots(Data.NeighborhoodSlots.Sims);
			foreach (NgbhSlot slot in slots)
			{
				memoriesToRemove.Clear();
				foreach (NgbhItem simMemory in slot.ItemsB)
				{
					if (
						simMemory.IsMemory
						&& (
							//1,
							simMemory.SimInstance == SlotID
							||
							//2.
							simMemory.OwnerInstance == SlotID
						)
					)
					{
						memoriesToRemove.Add(simMemory);
					}
				}

				if (memoriesToRemove.Count > 0)
				{
					deletedCount += memoriesToRemove.Count;
					slot.ItemsB.Remove(memoriesToRemove);
				}
			}

			return deletedCount;
		}

		public void RemoveMyMemories()
		{
			ItemsA.Clear();
			ItemsB.Clear();
		}
		#endregion
	}
}
