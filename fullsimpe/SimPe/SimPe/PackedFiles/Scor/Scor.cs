// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;

using SimPe.Data;
using SimPe.Extensions;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Sdsc;

namespace SimPe.PackedFiles.Scor
{
	/// <summary>
	/// Summary description for ScorWrapper.
	/// </summary>
	public class Scor : AbstractWrapper, IFileWrapper, IFileWrapperSaveExtension,
						IMultiplePackedFileWrapper, System.Collections.Generic.IEnumerable<ScorItem>
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

		protected override string GetResourceName(FileTypeInformation fti)
		{
			return !(FileTableBase.ProviderRegistry.SimDescriptionProvider.FindSim(
					(ushort)FileDescriptor.Instance
				) is ExtSDesc sdsc)
				? base.GetResourceName(fti)
				: sdsc.SimName + " " + sdsc.SimFamilyName + " (Scores)";
		}

		#region AbstractWrapper Member
		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new ScorUI();
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
				si.Serialize(writer, i == Items.Count - 1);
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
		public FileTypes[] AssignableTypes => new FileTypes[] { FileTypes.SCOR };

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

		public ScorItem this[int index] => Items[index];

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
