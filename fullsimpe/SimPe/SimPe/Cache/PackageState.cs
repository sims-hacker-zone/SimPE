// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;
using System.IO;

namespace SimPe.Cache
{
	/// <summary>
	/// This class can give Informations about the State of a Package
	/// </summary>
	/// <remarks>
	/// You can save diffrent informations along with a package file, each state (like contains duplicate GUID)
	/// has it's own uid. A TriState::Null measn, that the state was not ionvestigated yet
	/// </remarks>
	public class PackageState
	{
		public PackageState(uint uid, TriState state, string info)
		{
			Uid = uid;
			State = state;
			Info = info;
		}

		internal PackageState()
		{
			State = TriState.Null;
			Info = "";
		}

		public TriState State
		{
			get; set;
		}

		public uint Uid
		{
			get; set;
		}

		public string Info
		{
			get; set;
		}

		public List<uint> Data
		{
			get;
			set;
		} = new List<uint>();

		internal static PackageState Load(BinaryReader reader)
		{
			PackageState ps = new PackageState
			{
				State = (TriState)reader.ReadByte(),
				Uid = reader.ReadUInt32(),
				Info = reader.ReadString()
			};
			byte ct = reader.ReadByte();
			for (int i = 0; i < ct; i++)
			{
				ps.Data.Add(reader.ReadUInt32());
			}
			return ps;
		}

		internal virtual void Save(BinaryWriter writer)
		{
			writer.Write((byte)State);
			writer.Write(Uid);
			writer.Write(Info);

			byte ct = (byte)Data.Count;
			writer.Write(ct);
			foreach (uint item in Data)
			{
				writer.Write(item);
			}
		}
	}
}
