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

using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Wrapper
{
	/// <summary>
	/// Used to decode the Group Cache
	/// </summary>
	public class Slot
		: AbstractWrapper //Implements some of the default Behaviur of a Handler, you can Implement yourself if you want more flexibility!
			,
			IFileWrapper //This Interface is used when loading a File
			,
			IFileWrapperSaveExtension //This Interface (if available) will be used to store a File
	{
		#region Attributes
		uint id;

		/// <summary>
		/// Returns the Items stored in the FIle
		/// </summary>
		/// <remarks>Do not add Items based on this List! use the Add Method!!</remarks>
		public SlotItems Items
		{
			get;
		}

		public string FileName
		{
			get; set;
		}

		public uint Version
		{
			get; set;
		}

		public uint Unknown
		{
			get; set;
		}

		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public Slot()
			: base()
		{
			Items = new SlotItems();
			FileName = "";
			id = 0x534C4F54;
			Version = 4;
		}

		#region IWrapper member
		public override bool CheckVersion(uint version)
		{
			return true;
		}
		#endregion

		#region AbstractWrapper Member
		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new UserInterface.SlotUI();
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Slot Wrapper",
				"Quaxi",
				"",
				1,
				System.Drawing.Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.slot.png")
				)
			);
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			FileName = Helper.ToString(reader.ReadBytes(0x40));
			id = reader.ReadUInt32();
			Version = reader.ReadUInt32();
			Unknown = reader.ReadUInt32();

			int ct = reader.ReadInt32();
			Items.Clear();
			for (int i = 0; i < ct; i++)
			{
				SlotItem item = new SlotItem(this);
				item.Unserialize(reader);

				Items.Add(item);
			}
		}

		/// <summary>
		/// Serializes a the Attributes stored in this Instance to the BinaryStream
		/// </summary>
		/// <param name="writer">The Stream the Data should be stored to</param>
		/// <remarks>
		/// Be sure that the Position of the stream is Proper on
		/// return (i.e. must point to the first Byte after your actual File)
		/// </remarks>
		protected override void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(Helper.ToBytes(FileName, 0x40));
			writer.Write(id);
			writer.Write(Version);
			writer.Write(Unknown);

			writer.Write((int)Items.Length);
			for (int i = 0; i < Items.Length; i++)
			{
				Items[i].Serialize(writer, this);
			}
		}
		#endregion

		#region IFileWrapperSaveExtension Member
		//all covered by Serialize()
		#endregion

		#region IFileWrapper Member
		public override string Description => "FileName="
					+ FileName
					+ ", Version="
					+ Version
					+ ", Items="
					+ Items.Count.ToString();

		/// <summary>
		/// Returns the Signature that can be used to identify Files processable with this Plugin
		/// </summary>
		public byte[] FileSignature
		{
			get
			{
				Byte[] sig = { };
				return sig;
			}
		}

		/// <summary>
		/// Returns a list of File Type this Plugin can process
		/// </summary>
		public uint[] AssignableTypes
		{
			get
			{
				uint[] types = { Data.MetaData.SLOT };

				return types;
			}
		}

		#endregion
	}
}
