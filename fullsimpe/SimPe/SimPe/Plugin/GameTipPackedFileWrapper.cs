using System;

using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	public class GametipPackedFileWrapper
		: AbstractWrapper,
			IFileWrapper,
			IFileWrapperSaveExtension
	{
		#region Gametip Attribute
		private ushort tipname;
		private ushort tipheader;
		private ushort tipbody;
		private ushort tipep;
		private uint tipicon;

		public ushort Tipname
		{
			get
			{
				return tipname;
			}
			set
			{
				tipname = value;
			}
		}
		public ushort Tipheader
		{
			get
			{
				return tipheader;
			}
			set
			{
				tipheader = value;
			}
		}
		public ushort Tipbody
		{
			get
			{
				return tipbody;
			}
			set
			{
				tipbody = value;
			}
		}
		public ushort Tipep
		{
			get
			{
				return tipep;
			}
			set
			{
				tipep = value;
			}
		}
		public uint Tipicon
		{
			get
			{
				return tipicon;
			}
			set
			{
				tipicon = value;
			}
		}
		#endregion

		public GametipPackedFileWrapper()
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
			return new GametipPackedFileUI();
		}

		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Game Tip Wrapper",
				"Chris",
				"To aid unravelling Game Tip files",
				2,
				SimPe.GetIcon.GameTit
			);
		}

		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			reader.BaseStream.Seek(0x2, System.IO.SeekOrigin.Begin);
			tipname = reader.ReadUInt16();
			tipheader = reader.ReadUInt16();
			tipbody = reader.ReadUInt16();
			tipep = reader.ReadUInt16();
			tipicon = reader.ReadUInt32();
		}

		protected override void Serialize(System.IO.BinaryWriter writer)
		{
			ushort vershin = 2;
			writer.Write(vershin);
			writer.Write(tipname);
			writer.Write(tipheader);
			writer.Write(tipbody);
			writer.Write(tipep);
			writer.Write(tipicon);
		}
		#endregion

		#region IFileWrapperSaveExtension Member
		//all covered by Serialize()
		#endregion

		#region IFileWrapper Member

		public byte[] FileSignature
		{
			get
			{
				return new byte[0];
			}
		}

		public uint[] AssignableTypes
		{
			get
			{
				uint[] types = { 0xB1827A47 }; //handles the Game Tip File
				return types;
			}
		}

		#endregion
	}
}
