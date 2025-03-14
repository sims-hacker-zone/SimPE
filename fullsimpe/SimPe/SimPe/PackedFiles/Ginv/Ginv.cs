// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.Data;
using SimPe.Interfaces.Plugin;
using SimPe.Plugin;

namespace SimPe.PackedFiles.Ginv
{
	public class Ginv
		: AbstractWrapper,
			IFileWrapper,
			IFileWrapperSaveExtension
	{
		#region CreationIndex Attribute
		public ushort[] TipsList = new ushort[200];
		public ushort loweps; // Game edition flags 1
		public ushort hieps; // Game edition flags 2
		private ushort fnde; // Game Tip number found
		private ushort versh; // Vesrion
		private ushort fnd; // temp variable for finding stuff
		private ushort quanty; // amount of data in the token
		private uint guide; // GUID of the token

		public ushort Trunned
		{
			get; set;
		}
		#endregion

		public Ginv()
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
			return new GinvUI();
		}

		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Game Tip Inventory Wrapper",
				"Chris",
				"To View the Game Tip Inventory in NeighborhoodManager.package",
				2,
				GetIcon.ReadOnly
			);
		}

		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			for (int i = 0; i < 200; i++)
			{
				TipsList[i] = 0;
			}
			hieps = 0;
			loweps = 0;
			versh = reader.ReadUInt16(); // Version
			reader.BaseStream.Seek(0xc, System.IO.SeekOrigin.Begin); // move to the Index (Number of tokens)
			Trunned = reader.ReadUInt16(); // Number of Tokens in inventory
			if (Trunned != 0)
			{
				reader.BaseStream.Seek(0x2, System.IO.SeekOrigin.Current); // move to the first Token
				for (int i = 0; i < Trunned; i++)
				{
					guide = reader.ReadUInt32(); // Gets the GUID of the token Game Tip or Novel
					if (guide == 0xaef5633a)
					{
						if (versh > 202)
						{
							reader.BaseStream.Seek(0xa, System.IO.SeekOrigin.Current); // Seasons ++
						}

						if (versh > 190 && versh < 203)
						{
							reader.BaseStream.Seek(0x8, System.IO.SeekOrigin.Current); // OFB to Pets
						}

						if (versh < 191)
						{
							reader.BaseStream.Seek(0x6, System.IO.SeekOrigin.Current); // Nightlife (Base & Uni don't setup the Inventory)
						}

						quanty = reader.ReadUInt16();
						fnd = reader.ReadUInt16();
						fnde = reader.ReadUInt16();
						TipsList[fnde] = 1;
						if (fnde == 1)
						{
							loweps = reader.ReadUInt16();
							if (quanty > 2)
							{
								hieps = reader.ReadUInt16(); // game doesn't set game flags 2
							}
						}
						else
						{
							if (quanty > 1)
							{
								fnd = reader.ReadUInt16(); // move one more if any hold an extra data
							}

							if (quanty > 2)
							{
								fnd = reader.ReadUInt16(); // check for one more just in case
							}
						}
					}
					else
					{
						reader.BaseStream.Seek(0xE, System.IO.SeekOrigin.Current); // move to the end of an 8 byte token, required for Novels
					}
				}
			}
		}

		protected override void Serialize(System.IO.BinaryWriter writer)
		{
		}
		#endregion

		#region IFileWrapperSaveExtension Member
		//all covered by Serialize()
		#endregion

		#region IFileWrapper Member

		public byte[] FileSignature => new byte[0];

		public FileTypes[] AssignableTypes => new FileTypes[] { FileTypes.GINV };

		#endregion
	}
}
