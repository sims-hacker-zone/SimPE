// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.Data;
using SimPe.Extensions;
using SimPe.PackedFiles.Cpf;

namespace SimPe.PackedFiles.Goal
{
	/// <summary>
	/// Summary description for MmatWrapper.
	/// </summary>
	public class XGoal : Cpf.Cpf
	{
		/// <summary>
		/// creates a new Instance
		/// </summary>
		public XGoal()
			: base() { }

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override Interfaces.Plugin.IWrapperInfo CreateWrapperInfo()
		{
			return new Interfaces.Plugin.AbstractWrapperInfo(
				"Goal Wrapper",
				"Chris",
				"To view Castaway Story Goals",
				1,
				GetIcon.Writable
			);
		}

		/// <summary>
		/// Returns a list of File Type this Plugin can process
		/// </summary>
		public override FileTypes[] AssignableTypes => new FileTypes[] { FileTypes.GOAL };

		#region Default Attribute
		public uint StringInstance
		{
			get => GetSaveItem("stringSet").UIntegerValue;
			set => GetSaveItem("stringSet").UIntegerValue = value;
		}

		public uint Guid
		{
			get => GetSaveItem("id").UIntegerValue;
			set => GetSaveItem("id").UIntegerValue = value;
		}

		public uint IconInstance
		{
			get => GetSaveItem("primaryIcon").UIntegerValue;
			set => GetSaveItem("primaryIcon").UIntegerValue = value;
		}

		public uint SecondaryIconInstance
		{
			get => GetSaveItem("secondaryIcon").UIntegerValue;
			set => GetSaveItem("secondaryIcon").UIntegerValue = value;
		}

		public int Score
		{
			get => GetSaveItem("score").IntegerValue;
			set => GetSaveItem("score").IntegerValue = value;
		}

		public int Influence
		{
			get => GetSaveItem("influence").IntegerValue;
			set => GetSaveItem("influence").IntegerValue = value;
		}
		public string NodeText
		{
			get => GetSaveItem("nodeText").StringValue;
			set => GetSaveItem("nodeText").StringValue = value;
		}

		public Interfaces.Files.IPackedFileDescriptor IconFileDescriptor
		{
			get
			{
				Packages.PackedFileDescriptor pfd =
					new Packages.PackedFileDescriptor
					{
						Type = FileTypes.IMG,
						LongInstance = IconInstance
					};
				if (pfd.Instance == 0)
				{
					pfd.Instance = SecondaryIconInstance;
				}

				pfd.Group = 0x499DB772;

				return pfd;
			}
		}
		#endregion

		public override string Description => "GUID=0x" + Helper.HexString(FileDescriptor.Instance);

		protected override string GetResourceName(FileTypeInformation fti)
		{
			if (!Processed)
			{
				ProcessData(FileDescriptor, Package);
			}

			return NodeText;
		}
	}
}
