// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections;

using SimPe.Data;
using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Ngbh
{
	public enum NgbhVersion : uint
	{
		University = 0x70,
		Nightlife = 0xbe,
		Business = 0xc2,
		Seasons = 0xcb,
		Castaway = 0xce,
		CastawayItem = 0x100,
	}

	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class Ngbh : AbstractWrapper, IFileWrapper, IFileWrapperSaveExtension
	{
		#region Attributes
		uint version;
		public NgbhVersion Version
		{
			get => (NgbhVersion)version;
			set
			{
				version = (uint)value;
				Changed = true;
			}
		}

		byte[] id;
		byte[] header;
		byte[] zonename;
		byte[] zero;

		NgbhSlotList[] preitems;
		NgbhSlots slota;
		NgbhSlots slotb;
		NgbhSlots slotc;

		/// <summary>
		/// Returns / Sets a Slot
		/// </summary>
		public NgbhSlotList[] PreItems
		{
			get => preitems;
			set
			{
				preitems = value;
				Changed = true;
			}
		}

		/// <summary>
		/// Returns / Sets a Slot
		/// </summary>
		public NgbhSlots Lots //SlotsA
		{
			get => slota;
			set
			{
				slota = value;
				Changed = true;
			}
		}

		/// <summary>
		/// Returns / Sets a Slot
		/// </summary>
		public NgbhSlots Families //SlotsB
		{
			get => slotb;
			set
			{
				slotb = value;
				Changed = true;
			}
		}

		/// <summary>
		/// Returns / Sets a Slot
		/// </summary>
		public NgbhSlots Sims //SlotsC
		{
			get => slotc;
			set
			{
				slotc = value;
				Changed = true;
			}
		}

		#endregion

		public Interfaces.IProviderRegistry Provider
		{
			get;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		public Ngbh(Interfaces.IProviderRegistry provider)
			: base()
		{
			Provider = provider;

			id = new byte[] { (byte)'H', (byte)'B', (byte)'G', (byte)'N' };

			Version = NgbhVersion.University;

			header = new byte[]
			{
				0,
				0,
				0,
				0,
				0x80,
				0x00,
				0x00,
				0x00,
				0x80,
				0x00,
				0x00,
				0x00,
			};
			zonename = Helper.ToBytes("temperate", 9);
			zero = new byte[0x10];
			preitems = new NgbhSlotList[0x02];
			for (int i = 0; i < preitems.Length; i++)
			{
				preitems[i] = new NgbhSlotList(this);
			}

			slota = new NgbhSlots(this, NeighborhoodSlots.Lots);
			slotb = new NgbhSlots(this, NeighborhoodSlots.Families);
			slotc = new NgbhSlots(this, NeighborhoodSlots.Sims);
		}

		public static SimMemoryType[] AllowedMemoryTypes(NeighborhoodSlots type)
		{
			switch (type)
			{
				case NeighborhoodSlots.Sims:
					return new SimMemoryType[]
								{
					SimMemoryType.Memory,
					SimMemoryType.Gossip,
					SimMemoryType.Inventory,
					SimMemoryType.GossipInventory,
					SimMemoryType.Object,
					SimMemoryType.Aspiration,
					SimMemoryType.Token,
					SimMemoryType.ValueToken,
								};
				case NeighborhoodSlots.SimsIntern:
					return new SimMemoryType[]
								{
					SimMemoryType.Badge,
					SimMemoryType.Skill,
					SimMemoryType.Token,
					SimMemoryType.ValueToken,
								};
				case NeighborhoodSlots.Families:
					return new SimMemoryType[] { SimMemoryType.Token };
				default:
					return new SimMemoryType[0];
			}
		}

		#region IWrapper member
		public override bool CheckVersion(uint version)
		{
			return true;
		}
		#endregion

		#region AbstractWrapper Member
		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new NgbhUI();
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Neighbourhood/Memory Wrapper",
				"Quaxi",
				"This File contains the Memories and Inventories of all Sims that Live in this Neighbourhood.",
				12,
				System.Drawing.Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.ngbh.png")
				)
			);
		}

		public NgbhSlots GetSlots(NeighborhoodSlots id)
		{
			switch (id)
			{
				case NeighborhoodSlots.Families:
				case NeighborhoodSlots.FamiliesIntern:
					return Families;
				case NeighborhoodSlots.Lots:
				case NeighborhoodSlots.LotsIntern:
					return Lots;
				default:
					return Sims;
			}
		}

		public NgbhItems GetItems(NeighborhoodSlots id, uint inst)
		{
			NgbhSlots slots = Sims;
			if (
				id == NeighborhoodSlots.Families
				|| id == NeighborhoodSlots.FamiliesIntern
			)
			{
				slots = Families;
			}

			if (
				id == NeighborhoodSlots.Lots
				|| id == NeighborhoodSlots.LotsIntern
			)
			{
				slots = Lots;
			}

			return slots.GetInstanceSlot(inst)?.GetItems(id);
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			ArrayList list = new ArrayList();

			id = reader.ReadBytes(id.Length);
			version = reader.ReadUInt32();
			if (version == (uint)NgbhVersion.Castaway)
			{
				header = new byte[12 + 32];
			}

			header = reader.ReadBytes(header.Length);

			int textlen = reader.ReadInt32();
			zonename = reader.ReadBytes(textlen);
			zero = version >= (uint)NgbhVersion.Nightlife ? reader.ReadBytes(0x14) : reader.ReadBytes(0x18);

			//read preitems
			for (int i = 0; i < preitems.Length; i++)
			{
				preitems[i].Unserialize(reader);
			}

			int blocklen = reader.ReadInt32();
			slota.Clear();
			for (int i = 0; i < blocklen; i++)
			{
				NgbhSlot item = slota.AddNew(0);
				item.Unserialize(reader);
			}

			blocklen = reader.ReadInt32();
			slotb.Clear();
			for (int i = 0; i < blocklen; i++)
			{
				NgbhSlot item = slotb.AddNew(0);
				item.Unserialize(reader);
			}

			blocklen = reader.ReadInt32();
			slotc.Clear();
			for (int i = 0; i < blocklen; i++)
			{
				NgbhSlot item = slotc.AddNew(0);
				item.Unserialize(reader);
			}

			Changed = false;
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
			ArrayList list = new ArrayList();

			writer.Write(id);
			writer.Write(version);
			writer.Write(header);

			writer.Write(zonename.Length);
			writer.Write(zonename);

			zero = version >= (uint)NgbhVersion.Nightlife ? Helper.SetLength(zero, 0x14) : Helper.SetLength(zero, 0x018);

			writer.Write(zero);

			//write preitems
			for (int i = 0; i < preitems.Length; i++)
			{
				preitems[i].Serialize(writer);
			}

			writer.Write(slota.Length);
			for (int i = 0; i < slota.Length; i++)
			{
				slota[i].Serialize(writer);
			}

			writer.Write(slotb.Length);
			for (int i = 0; i < slotb.Length; i++)
			{
				slotb[i].Serialize(writer);
			}

			writer.Write(slotc.Length);
			for (int i = 0; i < slotc.Length; i++)
			{
				slotc[i].Serialize(writer);
			}

			/*writer.Write((int)0);
			writer.Write((int)writer.BaseStream.Position);*/
			writer.Write((byte)0);
			writer.Write((byte)1);
			writer.Write((byte)0);
			writer.Write((byte)0);
			writer.Write((byte)0);
		}
		#endregion

		#region IFileWrapperSaveExtension Member
		//all covered by Serialize()
		#endregion

		#region IFileWrapper Member

		/// <summary>
		/// Returns the Signature that can be used to identify Files processable with this Plugin
		/// </summary>
		public byte[] FileSignature => new byte[0];

		/// <summary>
		/// Returns a list of File Type this Plugin can process
		/// </summary>
		public FileTypes[] AssignableTypes => new FileTypes[] { FileTypes.NGBH };

		#endregion
	}
}
