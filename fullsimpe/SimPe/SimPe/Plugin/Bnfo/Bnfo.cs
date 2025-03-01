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
		public List<BnfoEmployee> Employees { get; set; } = new List<BnfoEmployee>();
		public List<BnfoHistory> History { get; set; } = new List<BnfoHistory>();

		public int HistoryCount
		{
			get; private set;
		}

		private uint unk1,
			unk2;
		private uint empct;

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

		private byte[] over;

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
			for (int i = 0; i < EmployeeCount; i++)
			{
				Employees.Add(new BnfoEmployee(reader));
			}
			long pos = reader.BaseStream.Position;
			over = reader.ReadBytes(
				(int)(reader.BaseStream.Length - reader.BaseStream.Position)
			);

			reader.BaseStream.Seek(pos, System.IO.SeekOrigin.Begin);
			HistoryCount = reader.ReadInt32(); // number of History blocks

			if (HistoryCount > 0 && over.Length > 60)
			{
				History.Capacity = HistoryCount;
				reader.BaseStream.Seek(-8, System.IO.SeekOrigin.Current);
				// first is + 52, I would jump over it so I must pull back 8?
				for (int i = 0; i < HistoryCount; i++)
				{
					reader.BaseStream.Seek(60, System.IO.SeekOrigin.Current); // TODO: Investigate if there is information in this data
					int revenue = reader.ReadInt32();
					reader.BaseStream.Seek(4, System.IO.SeekOrigin.Current); // credited
					int expenses = reader.ReadInt32();
					History.Add(new BnfoHistory
					{
						Expenses = expenses,
						Revenue = revenue
					});
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

			writer.Write(Employees.Count);
			foreach (BnfoEmployee employee in Employees)
			{
				employee.Serialize(writer);
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
