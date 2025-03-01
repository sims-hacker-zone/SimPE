// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.Data;
using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Scid
{
	public class Scid
		: AbstractWrapper,
			IFileWrapper,
			IFileWrapperSaveExtension
	{
		#region CreationIndex Attribute
		public ushort SCID
		{
			get; set;
		}
		public bool IsOK
		{
			get; private set;
		}
		#endregion

		public Scid() : base() { }

		#region IWrapper member
		public override bool CheckVersion(uint version)
		{
			return true;
		}
		#endregion

		#region AbstractWrapper Member
		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new ScidUI();
		}

		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Sim Creation Index Wrapper",
				"Chris",
				"To View/Edit the Index and Neighbour Id of the next sim to be created",
				2,
				GetIcon.GameTip
			);
		}

		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			Idno.Idno idno = Idno.Idno.FromPackage(package);
			IsOK = idno == null || idno.Type == NeighborhoodType.Normal;

			reader.BaseStream.Seek(0xc, System.IO.SeekOrigin.Begin);
			SCID = reader.ReadUInt16();
		}

		protected override void Serialize(System.IO.BinaryWriter writer)
		{
			uint scitype = 0xcc2a6a34;
			ushort scivers = 0xcb;
			writer.Write(scitype);
			writer.Write(scivers);
			writer.BaseStream.Seek(0xc, System.IO.SeekOrigin.Begin);
			writer.Write(SCID);
		}
		#endregion

		#region IFileWrapperSaveExtension Member
		//all covered by Serialize()
		#endregion

		#region IFileWrapper Member

		public byte[] FileSignature => new byte[0];

		public uint[] AssignableTypes
		{
			get
			{
				uint[] types = { 0xCC2A6A34 }; //handles the Sim Creation Index
				return types;
			}
		}

		#endregion
	}
}
