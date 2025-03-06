// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

using SimPe.Data;
using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	public class FunctionPackedFileWrapper
		: AbstractWrapper,
			IFileWrapper,
			IFileWrapperSaveExtension
	{
		#region CreationIndex Attribute
		private FileTypes filid; // File ID, must be SNCF (FileTypes.FCNS)
		private ushort fpurpos; // File Purpose, not sure of it's use but should be retained
		public string[] strung; // the actaul string, don't change this
		public float[] valwe; // the actual data or value.
		public string[] comnt; // the comment, can be a very long string
		public ushort Quanty
		{
			get; set;
		}
		#endregion

		public FunctionPackedFileWrapper()
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
			return new FunctionPackedFileUI();
		}

		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Game Function Wrapper",
				"Chris",
				"To View the Game Functions",
				2,
				GetIcon.GameTip
			);
		}

		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			// for (int i = 0; i < 60; i++) { valwe[i] = 0; strung[i] = null; comnt[i] = null;}
			Quanty = 0;
			reader.BaseStream.Seek(0x40, System.IO.SeekOrigin.Begin);
			filid = (FileTypes)reader.ReadUInt32();
			fpurpos = reader.ReadUInt16();
			reader.BaseStream.Seek(0x6, System.IO.SeekOrigin.Current);
			Quanty = reader.ReadUInt16(); // Number of items
			if (filid == FileTypes.FCNS && Quanty > 0) // check for valid file
			{
				Array.Resize(ref strung, Quanty);
				Array.Resize(ref valwe, Quanty);
				Array.Resize(ref comnt, Quanty);
				reader.BaseStream.Seek(0x2, System.IO.SeekOrigin.Current);
				for (int i = 0; i < Quanty; i++)
				{
					strung[i] = reader.ReadString();
					valwe[i] = reader.ReadSingle();
					comnt[i] = reader.ReadString();
				}
			}
		}

		protected override void Serialize(System.IO.BinaryWriter writer)
		{
			writer.BaseStream.Seek(0x40, System.IO.SeekOrigin.Begin);
			writer.Write((uint)filid);
			writer.Write(fpurpos);
			writer.BaseStream.Seek(0x6, System.IO.SeekOrigin.Current);
			writer.Write(Quanty);
			writer.BaseStream.Seek(0x2, System.IO.SeekOrigin.Current);
			for (int i = 0; i < Quanty; i++)
			{
				writer.Write(strung[i]);
				writer.Write(valwe[i]);
				writer.Write(comnt[i]);
			}
		}
		#endregion

		#region IFileWrapperSaveExtension Member
		//all covered by Serialize()
		#endregion

		#region IFileWrapper Member

		public byte[] FileSignature => new byte[0];

		public FileTypes[] AssignableTypes => new FileTypes[] { FileTypes.FCNS };

		#endregion
	}
}
