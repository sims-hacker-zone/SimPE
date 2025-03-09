// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

using SimPe.Data;
using SimPe.Interfaces.Plugin;
using SimPe.Plugin;

namespace SimPe.PackedFiles.Nhtr
{
	public enum NhtrVersions : uint
	{
		Business = 0x04,
	}

	/// <summary>
	/// Wrapper for FileTypes.NHTR , which appear to be the "Neighbourhood terrain" Resource
	/// </summary>
	public class Nhtr
		: AbstractWrapper,
			IFileWrapper,
			IFileWrapperSaveExtension,
			IMultiplePackedFileWrapper
	{
		#region Attributes
		uint ver;

		public NhtrVersions Version
		{
			get => (NhtrVersions)ver;
			set => ver = (uint)value;
		}

		public NhtrList[] Items
		{
			get;
		}

		#endregion


		public Nhtr()
			: base()
		{
			Ambertation.BaseChangeableNumber.DigitBase = 16;
			Version = NhtrVersions.Business;
			NhtrListType[] types =
				Enum.GetValues(typeof(NhtrListType)) as NhtrListType[];
			Items = new NhtrList[types.Length];
			foreach (NhtrListType tp in types)
			{
				Items[(int)tp] = new NhtrList(this, tp);
			}
		}

		#region IWrapper Member
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Neighbourhood Terrain Wrapper",
				"TickleOnTheTum, jaxad0127 and Quaxi",
				"Contains Information about the Neighbourhood Terrain.",
				3,
				null
			);
		}
		#endregion



		#region AbstractWrapper Member
		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new NhtrUI();
		}

		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			ver = reader.ReadUInt32();
			foreach (NhtrList list in Items)
			{
				list.Clear();
				list.Unserialize(reader);
			}

			//Console.WriteLine(reader.BaseStream.Position - reader.BaseStream.Length);
		}

		protected override void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(ver);
			foreach (NhtrList list in Items)
			{
				list.Serialize(writer);
			}
		}
		#endregion



		#region IPackedFileWrapper Member

		public FileTypes[] AssignableTypes => new FileTypes[] { FileTypes.NHTR };

		public byte[] FileSignature => new byte[] { };

		#endregion
	}
}
