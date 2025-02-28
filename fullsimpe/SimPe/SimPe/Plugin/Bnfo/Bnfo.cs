// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;

using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin.Bnfo
{
	/// <summary>
	/// Wrapper for 0x104F6A6E , which apear to be the "Business info Resource"
	/// </summary>
	public class Bnfo
		: AbstractWrapper,
			IFileWrapper,
			IFileWrapperSaveExtension,
			IMultiplePackedFileWrapper
	{
		#region Attributes
		public BnfoVersions Version { get; set; } = BnfoVersions.Business;

		public uint CurrentBusinessState
		{
			get; set;
		}
		public uint MaxSeenBusinessState
		{
			get; set;
		}

		public int EmployeeCount
		{
			get; set;
		}
		public List<ushort> Employees { get; set; } = new List<ushort>();
		public List<int> PayRate { get; set; } = new List<int>(); //doesn't need to be int, could just be byte but int is easier to work with. 0 to 6 inclusive
		public List<uint> FairPay { get; set; } = new List<uint>(); // Fair Pay - should never be below 15
		public List<int> Revenue { get; private set; } = new List<int>();
		public List<int> Expenses { get; private set; } = new List<int>();

		public int HistoryCount
		{
			get; private set;
		}

		uint unk1,
			unk2;
		uint empct;

		public Collections.BnfoCustomerItems CustomerItems
		{
			get;
		}
		#endregion

		public Bnfo() : base()
		{
			CustomerItems = new Collections.BnfoCustomerItems(this);
		}

		#region IWrapper Member
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Business Info Wrapper",
				"Quaxi",
				"Contains Information about the Business on a Lot (like Customer Loyality)",
				2,
				GetIcon.BnfoIco
			);
		}
		#endregion

		#region AbstractWrapper Member
		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new BnfoUI();
		}

		byte[] over;

		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			Version = (BnfoVersions)reader.ReadUInt32();
			CurrentBusinessState = reader.ReadUInt32();
			MaxSeenBusinessState = reader.ReadUInt32();
			unk1 = reader.ReadUInt32();
			unk2 = reader.ReadUInt32();
			empct = reader.ReadUInt32();

			int ct = reader.ReadInt32();
			CustomerItems.Clear();
			for (int i = 0; i < ct; i++)
			{
				BnfoCustomerItem item = new BnfoCustomerItem(this);
				item.Unserialize(reader);
				CustomerItems.Add(item);
			}
			/*
			long pos = reader.BaseStream.Position;
			over = reader.ReadBytes((int)(reader.BaseStream.Length - pos));
			reader.BaseStream.Seek(pos, System.IO.SeekOrigin.Begin);
			*/
			EmployeeCount = reader.ReadInt32();
			Employees.Capacity = EmployeeCount;
			PayRate.Capacity = EmployeeCount;
			FairPay.Capacity = EmployeeCount;
			for (int i = 0; i < EmployeeCount; i++)
			{
				Employees.Add(reader.ReadUInt16());
				PayRate.Add(reader.ReadInt32());
				FairPay.Add(reader.ReadUInt32());
			}
			long pos = reader.BaseStream.Position;
			over = reader.ReadBytes(
				(int)(reader.BaseStream.Length - reader.BaseStream.Position)
			);

			reader.BaseStream.Seek(pos, System.IO.SeekOrigin.Begin);
			HistoryCount = reader.ReadInt32(); // number of History blocks

			if (HistoryCount > 0 && over.Length > 60)
			{
				Revenue.Capacity = HistoryCount;
				Expenses.Capacity = HistoryCount;
				reader.BaseStream.Seek(-8, System.IO.SeekOrigin.Current);
				// first is + 52, I would jump over it so I must pull back 8?
				for (int i = 0; i < HistoryCount; i++)
				{
					reader.BaseStream.Seek(60, System.IO.SeekOrigin.Current);
					Revenue.Add(reader.ReadInt32()); // Revenue
					reader.BaseStream.Seek(4, System.IO.SeekOrigin.Current); // credited
					Expenses.Add(reader.ReadInt32()); // Expenses
				}
			}
		}

		protected override void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write((uint)Version);
			writer.Write(CurrentBusinessState);
			writer.Write(MaxSeenBusinessState);
			writer.Write(unk1);
			writer.Write(unk2);
			writer.Write(empct);

			writer.Write(CustomerItems.Count);
			foreach (BnfoCustomerItem item in CustomerItems)
			{
				item.Serialize(writer);
			}

			writer.Write(EmployeeCount);
			for (int i = 0; i < EmployeeCount; i++)
			{
				writer.Write(Employees[i]);
				writer.Write(PayRate[i]);
				writer.Write(FairPay[i]);
			}

			writer.Write(over);
		}
		#endregion

		#region IPackedFileWrapper Member

		public uint[] AssignableTypes
		{
			get
			{
				uint[] Types = { 0x104F6A6E };
				return Types;
			}
		}

		public byte[] FileSignature
		{
			get
			{
				byte[] sig = { };
				return sig;
			}
		}

		#endregion
	}
}
