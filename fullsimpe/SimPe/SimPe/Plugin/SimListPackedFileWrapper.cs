// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

using SimPe.Data;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Idno;

namespace SimPe.Plugin
{
	public class SimListPackedFileWrapper
		: AbstractWrapper, IFileWrapper, IFileWrapperSaveExtension
	{
		#region CreationIndex Attribute
		public string displaystring_all; // String which contains missing Sims as well
		public uint sims;
		private uint currentsim;
		public string displaystring;
		public string DisplayString
		{
			get => displaystring;
			set => displaystring = value;
		}
		public string DisplayStringAll
		{
			get => displaystring_all;
			set => displaystring_all = value;
		}
		#endregion

		public SimListPackedFileWrapper()
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
			return new SimmyListPackedFileUI();
		}

		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Sim List (Popups) Viewer Wrapper",
				"Chris",
				"To View the List of Neighbours this Neighbourhood has Parsed",
				1,
				GetIcon.Writable
			);
		}

		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			reader.BaseStream.Seek(4, System.IO.SeekOrigin.Begin); // move to the Index (Number of Sims)
			displaystring = "";
			displaystring_all = "";
			Idno idno = Idno.FromPackage(package);
			if (idno != null)
			{
				if (idno.Type != NeighborhoodType.Normal)
				{
					displaystring =
						"-INVALID FILE-\r\nData only Valid in a Primary Neighbourhood\r\n\r\n";
					displaystring_all =
						"-INVALID FILE-\r\nData only Valid in a Primary Neighbourhood\r\n\r\n";
				}
			}
			sims = reader.ReadUInt32(); // Number of Neighbours
			if (sims != 0)
			{
				bool found;
				for (int i = 0; i < sims; i++)
				{
					currentsim = reader.ReadUInt32();
					if (Helper.IsLotCatalogFile(package.FileName)) // Search by Nid, slow but accurate
					{
						found = false;
						PackedFiles.Wrapper.ExtSDesc sdesc =
							new PackedFiles.Wrapper.ExtSDesc();
						Interfaces.Files.IPackedFileDescriptor[] files =
							package.FindFiles(FileTypes.SDSC);
						foreach (
							Interfaces.Files.IPackedFileDescriptor pfd in files
						)
						{
							sdesc.ProcessData(pfd, package);
							if (sdesc.Instance == currentsim)
							{
								displaystring +=
									"0x"
									+ Helper.HexString(Convert.ToInt16(currentsim))
									+ " - "
									+ sdesc.SimName
									+ " "
									+ sdesc.SimFamilyName
									+ "\r\n";
								found = true;
							}
						}
						if (!found)
						{
							displaystring +=
								"0x"
								+ Helper.HexString(Convert.ToInt16(currentsim))
								+ " - MISSING\r\n";
							displaystring_all +=
								"0x"
								+ Helper.HexString(Convert.ToInt16(currentsim))
								+ " - MISSING\r\n";
						}
					}
					else // search by instance, fast but not as accurate
					{
						Interfaces.Files.IPackedFileDescriptor pfd =
							package.FindFile(
								FileTypes.SDSC,
								0,
								0xFFFFFFFF,
								currentsim
							);
						if (pfd == null)
						{
							displaystring +=
								"0x"
								+ Helper.HexString(Convert.ToInt16(currentsim))
								+ " - MISSING\r\n";
							displaystring_all +=
								"0x"
								+ Helper.HexString(Convert.ToInt16(currentsim))
								+ " - MISSING\r\n";
						}
						else
						{
							PackedFiles.Wrapper.ExtSDesc sdesc =
								new PackedFiles.Wrapper.ExtSDesc();
							sdesc.ProcessData(pfd, package);
							displaystring +=
								"0x"
								+ Helper.HexString(Convert.ToInt16(currentsim))
								+ " - "
								+ sdesc.SimName
								+ " "
								+ sdesc.SimFamilyName
								+ "\r\n";
						}
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

		public FileTypes[] AssignableTypes => new FileTypes[] { FileTypes.POPS };

		#endregion
	}
}
