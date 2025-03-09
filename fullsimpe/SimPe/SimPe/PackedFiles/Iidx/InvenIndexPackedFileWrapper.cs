// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.Data;
using SimPe.Interfaces.Plugin;
using SimPe.Plugin;

namespace SimPe.PackedFiles.Iidx
{
	public class InvenIndexPackedFileWrapper
		: AbstractWrapper,
			IFileWrapper,
			IFileWrapperSaveExtension
	{
		#region CreationIndex Attribute
		public uint Sciname
		{
			get; set;
		}
		#endregion

		public InvenIndexPackedFileWrapper()
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
			return new InvenIndexPackedFileUI();
		}

		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Invenory Item Index Wrapper",
				"Chris",
				"To View/Edit the Invenory Item Index",
				2,
				GetIcon.GameTip
			);
		}

		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			reader.BaseStream.Seek(0x4, System.IO.SeekOrigin.Begin);
			Sciname = reader.ReadUInt32();
		}

		protected override void Serialize(System.IO.BinaryWriter writer)
		{
			uint scivers = 0x4;
			writer.Write(scivers);
			writer.Write(Sciname);
		}
		#endregion

		#region IFileWrapperSaveExtension Member
		//all covered by Serialize()
		#endregion

		#region IFileWrapper Member

		public byte[] FileSignature => new byte[0];

		public FileTypes[] AssignableTypes => new FileTypes[] { FileTypes.IIDX };

		#endregion
	}
}
