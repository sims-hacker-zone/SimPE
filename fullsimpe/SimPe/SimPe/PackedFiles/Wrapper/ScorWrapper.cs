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

using SimPe.Data;
using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Wrapper
{
	/// <summary>
	/// Summary description for ScorWrapper.
	/// </summary>
	public class Scor
		: AbstractWrapper //Implements some of the default Behaviur of a Handler, you can Implement yourself if you want more flexibility!
			,
			IFileWrapper //This Interface is used when loading a File
			,
			IFileWrapperSaveExtension //This Interface (if available) will be used to store a File
			,
			IMultiplePackedFileWrapper,
			System.Collections.Generic.IEnumerable<ScorItem>
	{
		#region Attributes
		protected ScorItems Items
		{
			get;
		}

		/// <summary>
		/// Returns the Version of this File
		/// </summary>
		public uint Version
		{
			get; private set;
		}

		public uint Unknown1
		{
			get; private set;
		}

		public uint Unknown2
		{
			get; private set;
		}
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public Scor()
			: base()
		{
			Version = 0;
			Items = new ScorItems();
		}

		#region IWrapper member
		public override bool CheckVersion(uint version)
		{
			return true;
		}
		#endregion

		protected override string GetResourceName(TypeAlias ta)
		{
			ExtSDesc sdsc =
				FileTableBase.ProviderRegistry.SimDescriptionProvider.FindSim(
					(ushort)FileDescriptor.Instance
				) as ExtSDesc;
			if (sdsc == null)
			{
				return base.GetResourceName(ta);
			}
			else
			{
				return sdsc.SimName + " " + sdsc.SimFamilyName + " (Scores)";
			}
		}

		#region AbstractWrapper Member
		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new UserInterface.ScorUI();
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Sim Score Wrapper",
				"Quaxi",
				"Seems to contain some sort of Scores for a specific Sim",
				2,
				null
			);
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			Version = reader.ReadUInt32();
			Unknown1 = reader.ReadUInt32();
			Unknown2 = reader.ReadUInt32();

			Items.Clear();
			while (reader.BaseStream.Position < reader.BaseStream.Length)
			{
				ScorItem si = new ScorItem(this);
				si.Unserialize(reader);

				Items.Add(si);
			}

			if (LoadedNewResource != null)
			{
				LoadedNewResource(this, new EventArgs());
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
			writer.Write(Version);
			writer.Write(Unknown1);
			writer.Write(Unknown2);

			for (int i = 0; i < Items.Count; i++)
			{
				ScorItem si = Items[i];
				si.Serialize(writer, (i == Items.Count - 1));
			}
		}
		#endregion

		#region IFileWrapperSaveExtension Member
		//all covered by Serialize()
		#endregion

		#region IFileWrapper Member

		/// <summary>
		/// Returns the Signature that can be used to identify Files processable with this Plugin
		/// </summary>
		public byte[] FileSignature => new byte[0];

		/// <summary>
		/// Returns a list of File Type this Plugin can process
		/// </summary>
		public uint[] AssignableTypes
		{
			get
			{
				uint[] types = { 0x3053CF74 };
				return types;
			}
		}

		#endregion

		public class ChangedListEventArgs : EventArgs
		{
			public ChangedListEventArgs(ScorItem si)
			{
				Item = si;
			}

			public ScorItem Item
			{
				get;
			}
		}

		public delegate void ChangedListHandler(Scor sender, ChangedListEventArgs e);
		public event ChangedListHandler AddedItem;
		public event ChangedListHandler RemovedItem;
		public event EventHandler LoadedNewResource;

		public void Add(string name)
		{
			ChangedListEventArgs e = new ChangedListEventArgs(new ScorItem(name, this));
			Items.Add(e.Item);
			if (AddedItem != null)
			{
				AddedItem(this, e);
			}

			Changed = true;
		}

		public void Remove(ScorItem si)
		{
			if (si == null)
			{
				return;
			}

			Items.Remove(si);
			ChangedListEventArgs e = new ChangedListEventArgs(si);
			if (RemovedItem != null)
			{
				RemovedItem(this, e);
			}

			Changed = true;
		}

		public ScorItem this[int index]
		{
			get
			{
				return Items[index];
			}
		}

		public int Count => Items.Count;

		#region IEnumerable Members

		public IEnumerator GetEnumerator()
		{
			return Items.GetEnumerator();
		}

		#endregion

		#region IEnumerable<ScorItem> Members

		System.Collections.Generic.IEnumerator<ScorItem> System.Collections.Generic.IEnumerable<ScorItem>.GetEnumerator()
		{
			return Items.GetScorItemEnumerator();
		}

		#endregion
	}
}
