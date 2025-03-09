// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

using SimPe.Data;
using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Srel
{

	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class SRel : AbstractWrapper, IFileWrapper, IFileWrapperSaveExtension
	{
		#region Attribute
		/// <summary>
		/// some unknown values
		/// </summary>
		uint[] reserved = new uint[3];

		/// <summary>
		/// Stores the Relationship Values
		/// </summary>
		private int[] values = new int[4];

		/// <summary>
		/// Returns the Shortterm Relationship
		/// </summary>
		public int Shortterm
		{
			get => GetValue(0);
			set => PutValue(0, value);
		}

		/// <summary>
		/// Returns the Relationship Values.
		/// </summary>
		/// <remarks>The Meaning of the Bits is stored in MataData.RelationshipStateBits</remarks>
		public RelationshipFlags RelationState
		{
			get;
		} = new RelationshipFlags(
			1 << (byte)MetaData.RelationshipStateBits.Known
		);

		/// <summary>
		/// Returns the Shortterm Relationship
		/// </summary>
		public int Longterm
		{
			get => GetValue(2);
			set => PutValue(2, value);
		}

		/// <summary>
		/// The Type of Family Relationship the Sim has to another
		/// </summary>
		public RelationshipTypes FamilyRelation
		{
			get => (RelationshipTypes)GetValue(3);
			set => PutValue(3, (int)value);
		}

		UIFlags2 flags2 = new UIFlags2(0);

		/// <summary>
		/// Returns the second set of relationship state flags
		/// </summary>
		/// <remarks>The Meaning of the Bits is given by MetaData.UIFlags2Names</remarks>
		public UIFlags2 RelationState2 => values.Length > 9 ? flags2 : null;
		#endregion

		/// <summary>
		/// Assignes a Value to the given Slot
		/// </summary>
		/// <param name="slot">Slot Number</param>
		/// <param name="val">new Value</param>
		protected void PutValue(int slot, int val)
		{
			if (values.Length <= slot)
			{
				int[] tmp = new int[slot + 1];
				values.CopyTo(tmp, 0);
				values = tmp;
			}
			values[slot] = val;
		}

		/// <summary>
		/// Returns the Value of teh Slot
		/// </summary>
		/// <param name="slot">Slotnumber</param>
		/// <returns>the stored Value</returns>
		protected int GetValue(int slot)
		{
			return values.Length > slot ? values[slot] : 0;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		public SRel()
			: base()
		{
			reserved[0] = 0x00000002;
		}

		#region AbstractWrapper Member
		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new SRelUI();
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			if (reader.BaseStream.Length <= 0)
			{
				return;
			}

			reserved[0] = reader.ReadUInt32(); //unknown
			uint stored = reader.ReadUInt32();
			values = new int[Math.Max(3, stored)];
			for (int i = 0; i < stored; i++)
			{
				values[i] = reader.ReadInt32();
			}

			//set some special Attributes
			RelationState.Value = (ushort)values[1];
			if (9 < values.Length)
			{
				flags2.Value = (ushort)values[9];
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
			//set some special Attributes
			values[1] = (int)(values[1] & 0xffff0000 | RelationState.Value);
			if (9 < values.Length)
			{
				values[9] = (int)(values[9] & 0xffff0000 | flags2.Value);
			}

			//write to file
			writer.Write(reserved[0]);
			writer.Write((uint)values.Length);
			for (int i = 0; i < values.Length; i++)
			{
				writer.Write(values[i]);
			}
		}
		#endregion

		#region IWrapper Member
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Sim Relation Wrapper",
				"Quaxi",
				"This File Contians the Relationship states for two Sims.",
				6,
				System.Drawing.Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.srel.png")
				)
			);
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
		public FileTypes[] AssignableTypes => new FileTypes[] { FileTypes.SREL };

		#endregion
	}
}
