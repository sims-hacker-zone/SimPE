/***************************************************************************
 *   Copyright (C) 2005 by Peter L Jones                                   *
 *   pljones@users.sf.net                                                  *
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
using System.Collections.Generic;

using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Wrapper
{
	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class Objf
		: pjse.ExtendedWrapper<
			ObjfItem,
			Objf
		> //AbstractWrapper				//Implements some of the default Behaviur of a Handler, you can Implement yourself if you want more flexibility!
			,
			IFileWrapper //This Interface is used when loading a File
			,
			IFileWrapperSaveExtension //This Interface (if available) will be used to store a File
									  //,IPackedFileProperties		//This Interface can be used by thirdparties to retrive the FIleproperties, however you don't have to implement it!
	{
		#region Attributes
		/// <summary>
		/// Contains the Filename
		/// </summary>
		private byte[] filename = new byte[64];

		/// <summary>
		/// Header of the File
		/// </summary>
		private uint[] header = { 0x00000000, 0x00000000, 0x4f424a66 }; // 'OBJf'
		#endregion

		#region Accessor methods
		/// <summary>
		/// Returns the Filename
		/// </summary>
		public string FileName
		{
			get
			{
				return Helper.ToString(filename);
			}
			set
			{
				if (!Helper.ToString(filename).Equals(value))
				{
					filename = Helper.ToBytes(value, 0x40);
					OnWrapperChanged(this, new EventArgs());
				}
			}
		}
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public Objf()
			: base() { }

		public new void Add(ObjfItem item)
		{
			Add(item, 0x8000);
		}

		public new void Insert(int index, ObjfItem item)
		{
			Insert(index, item, 0x8000);
		}

		#region AbstractWrapper Member
		public override bool CheckVersion(uint version)
		{
			if (
				(version == 0012) //0.00
				|| (version == 0013) //0.10
			)
			{
				return true;
			}

			return false;
		}

		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new UserInterface.ObjfForm();
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			///
			/// TODO: Change the Description passed here
			///
			return new AbstractWrapperInfo(
				"PJSE OBJf Wrapper",
				"Peter L Jones",
				"Object Function Table Editor",
				1
			);
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
			writer.Write(filename);
			writer.Write(header[0]);
			writer.Write(header[1]);
			writer.Write(header[2]);

			writer.Write((uint)items.Count);

			for (int i = 0; i < items.Count; i++)
				if (items[i] != null)
					((ObjfItem)items[i]).Serialize(writer);
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			// in case we give up...
			// items = null; //throws NullReferenceException
			uint itemCount = 0;

			filename = reader.ReadBytes(64);

			header = new uint[3];
			header[0] = reader.ReadUInt32();
			header[1] = reader.ReadUInt32();
			header[2] = reader.ReadUInt32();
			//if (header[2] != 0x4f424a66)
			//	return; // throws NullReferenceException if items = null

			if (header[2] == 0x4f424a66)
				itemCount = reader.ReadUInt32();
			else
			{
				header[2] = 0x4f424a66; // will be fixed when commited, this allows a corrupt file to load as a blank file
				this.Changed = true; // enable commit button for immediate commit.
			}

			items = new List<ObjfItem>();
			while (items.Count < itemCount)
				items.Add(new ObjfItem(this, reader));
		}

		#endregion

		public const uint Objftype = 0x4F424A66;

		#region IFileWrapper Member
		/// <summary>
		/// Returns a list of File Type this Plugin can process
		/// </summary>
		public uint[] AssignableTypes
		{
			get
			{
				uint[] types = { Objftype }; //handles the OBJf File
				return types;
			}
		}

		/// <summary>
		/// Returns the Signature that can be used to identify Files processable with this Plugin
		/// </summary>
		public byte[] FileSignature => new byte[0];

		#endregion

		#region IFileWrapperSaveExtension Member
		//all covered by AbstractWrapper
		#endregion
	}

	/// <summary>
	/// An Item stored in an OBJf
	/// </summary>
	public class ObjfItem : pjse.ExtendedWrapperItem<Objf, ObjfItem>
	{
		#region Attributes
		private ushort guard = 0;
		private ushort action = 0;
		#endregion

		#region Accessor methods
		public ushort Action
		{
			get
			{
				return action;
			}
			set
			{
				if (action != value)
				{
					action = value;
					parent.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		public ushort Guardian
		{
			get
			{
				return guard;
			}
			set
			{
				if (guard != value)
				{
					guard = value;
					parent.OnWrapperChanged(this, new EventArgs());
				}
			}
		}
		#endregion

		public ObjfItem(Objf parent)
		{
			this.parent = parent;
		}

		public ObjfItem(Objf parent, System.IO.BinaryReader reader)
		{
			this.parent = parent;
			Unserialize(reader);
		}

		public ObjfItem Clone()
		{
			ObjfItem clone = new ObjfItem(this.parent);
			clone.action = this.action;
			clone.guard = this.guard;
			return clone;
		}

		/// <summary>
		/// Reads Data from the Stream
		/// </summary>
		/// <param name="reader"></param>
		internal void Unserialize(System.IO.BinaryReader reader)
		{
			guard = reader.ReadUInt16();
			action = reader.ReadUInt16();
		}

		/// <summary>
		/// Writes Data to the Stream
		/// </summary>
		/// <param name="reader"></param>
		internal void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(guard);
			writer.Write(action);
		}
	}
}
