// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.Data;
using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	public class GametipPackedFileWrapper : AbstractWrapper, IFileWrapper, IFileWrapperSaveExtension
	{
		#region Gametip Attribute

		public ushort Tipname
		{
			get; set;
		}
		public ushort Tipheader
		{
			get; set;
		}
		public ushort Tipbody
		{
			get; set;
		}
		public ushort Tipep
		{
			get; set;
		}
		public uint Tipicon
		{
			get; set;
		}
		#endregion

		public GametipPackedFileWrapper()
			: base() { }

		#region IWrapper member
		public override bool CheckVersion(uint version)
		{
			return true;
		}
		#endregion

		#region AbstractWrapper Member
		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new GametipPackedFileUI();
		}

		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Game Tip Wrapper",
				"Chris",
				"To aid unravelling Game Tip files",
				2,
				GetIcon.GameTip
			);
		}

		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			reader.BaseStream.Seek(0x2, System.IO.SeekOrigin.Begin);
			Tipname = reader.ReadUInt16();
			Tipheader = reader.ReadUInt16();
			Tipbody = reader.ReadUInt16();
			Tipep = reader.ReadUInt16();
			Tipicon = reader.ReadUInt32();
		}

		protected override void Serialize(System.IO.BinaryWriter writer)
		{
			ushort vershin = 2;
			writer.Write(vershin);
			writer.Write(Tipname);
			writer.Write(Tipheader);
			writer.Write(Tipbody);
			writer.Write(Tipep);
			writer.Write(Tipicon);
		}
		#endregion

		#region IFileWrapperSaveExtension Member
		//all covered by Serialize()
		#endregion

		#region IFileWrapper Member

		public byte[] FileSignature => new byte[0];

		public FileTypes[] AssignableTypes => new FileTypes[] { FileTypes.GTIP };

		#endregion
	}
}
