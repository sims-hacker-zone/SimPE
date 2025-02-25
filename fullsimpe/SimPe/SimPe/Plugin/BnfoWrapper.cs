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
using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	public enum BnfoVersions : uint
	{
		Business = 0x04,
	}

	/// <summary>
	/// Wrapper for 0x104F6A6E , which apear to be the "Business info Resource"
	/// </summary>
	public class Bnfo
		: AbstractWrapper,
			SimPe.Interfaces.Plugin.IFileWrapper,
			SimPe.Interfaces.Plugin.IFileWrapperSaveExtension,
			SimPe.Interfaces.Plugin.IMultiplePackedFileWrapper
	{
		#region Attributes
		uint ver;
		public BnfoVersions Version
		{
			get { return (BnfoVersions)ver; }
			set { ver = (uint)value; }
		}

		uint level1,
			level2;
		public uint CurrentBusinessState
		{
			get { return level1; }
			set { level1 = value; }
		}
		public uint MaxSeenBusinessState
		{
			get { return level2; }
			set { level2 = value; }
		}
		int wt;
		public int EmployeeCount
		{
			get { return wt; }
			set { wt = value; }
		}
		ushort[] empls;
		public ushort[] Employees
		{
			get { return empls; }
			set { empls = value; }
		}
		int[] pr;
		public int[] PayRate //doesn't need to be int, could just be byte but int is easier to work with. 0 to 6 inclusive
		{
			get { return pr; }
			set { pr = value; }
		}
		uint[] a;
		public uint[] A // Fair Pay - should never be below 15
		{
			get { return a; }
			set { a = value; }
		}

		int[] reven;
		public int[] Revenue
		{
			get { return reven; }
		}
		int[] expe;
		public int[] Expences
		{
			get { return expe; }
		}
		int hct;
		public int HistoryCount
		{
			get { return hct; }
		}

		uint unk1,
			unk2;
		uint empct;

		Collections.BnfoCustomerItems citems;
		public Collections.BnfoCustomerItems CustomerItems
		{
			get { return citems; }
		}
		#endregion

		public Bnfo()
			: base()
		{
			Version = BnfoVersions.Business;
			citems = new SimPe.Plugin.Collections.BnfoCustomerItems(this);
		}

		#region IWrapper Member
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Business Info Wrapper",
				"Quaxi",
				"Contains Information about the Business on a Lot (like Customer Loyality)",
				2,
				SimPe.GetIcon.BnfoIco
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
			ver = reader.ReadUInt32();
			level1 = reader.ReadUInt32();
			level2 = reader.ReadUInt32();
			unk1 = reader.ReadUInt32();
			unk2 = reader.ReadUInt32();
			empct = reader.ReadUInt32();

			int ct = reader.ReadInt32();
			citems.Clear();
			for (int i = 0; i < ct; i++)
			{
				BnfoCustomerItem item = new BnfoCustomerItem(this);
				item.Unserialize(reader);
				citems.Add(item);
			}
			/*
			long pos = reader.BaseStream.Position;
			over = reader.ReadBytes((int)(reader.BaseStream.Length - pos));
			reader.BaseStream.Seek(pos, System.IO.SeekOrigin.Begin);
			*/
			wt = reader.ReadInt32();
			Array.Resize<ushort>(ref empls, wt);
			Array.Resize<int>(ref pr, wt);
			Array.Resize<uint>(ref a, wt);
			for (int i = 0; i < wt; i++)
			{
				empls[i] = reader.ReadUInt16();
				pr[i] = reader.ReadInt32();
				a[i] = reader.ReadUInt32();
			}
			long pos = reader.BaseStream.Position;
			over = reader.ReadBytes(
				(int)(reader.BaseStream.Length - reader.BaseStream.Position)
			);

			reader.BaseStream.Seek(pos, System.IO.SeekOrigin.Begin);
			hct = reader.ReadInt32(); // number of History blocks

			if (hct > 0 && over.Length > 60)
			{
				Array.Resize<int>(ref reven, hct);
				Array.Resize<int>(ref expe, hct);
				reader.BaseStream.Seek(-8, System.IO.SeekOrigin.Current);
				// first is + 52, I would jump over it so I must pull back 8?
				for (int i = 0; i < hct; i++)
				{
					reader.BaseStream.Seek(60, System.IO.SeekOrigin.Current);
					reven[i] = reader.ReadInt32(); // Renenue
					reader.BaseStream.Seek(4, System.IO.SeekOrigin.Current); // credited
					expe[i] = reader.ReadInt32(); // Expences
				}
			}
		}

		protected override void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(ver);
			writer.Write(level1);
			writer.Write(level2);
			writer.Write(unk1);
			writer.Write(unk2);
			writer.Write(empct);

			writer.Write((int)citems.Count);
			foreach (BnfoCustomerItem item in citems)
				item.Serialize(writer);

			writer.Write(wt);
			for (int i = 0; i < wt; i++)
			{
				writer.Write(empls[i]);
				writer.Write(pr[i]);
				writer.Write(a[i]);
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

		public Byte[] FileSignature
		{
			get
			{
				Byte[] sig = { };
				return sig;
			}
		}

		#endregion
	}
}
