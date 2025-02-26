using System;

using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	public class SimindexPackedFileWrapper
		: AbstractWrapper,
			IFileWrapper,
			IFileWrapperSaveExtension
	{
		#region CreationIndex Attribute
		private bool isok;
		private ushort sciname;
		public ushort Sciname
		{
			get
			{
				return sciname;
			}
			set
			{
				sciname = value;
			}
		}
		public bool IsOK
		{
			get
			{
				return isok;
			}
		}
		#endregion

		public SimindexPackedFileWrapper()
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
			return new SimindexPackedFileUI();
		}

		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Sim Creation Index Wrapper",
				"Chris",
				"To View/Edit the Index and Neighbour Id of the next sim to be created",
				2,
				SimPe.GetIcon.GameTit
			);
		}

		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			SimPe.Plugin.Idno idno = SimPe.Plugin.Idno.FromPackage(package);
			if (idno == null)
				isok = true;
			else
			{
				if (idno.Type == SimPe.Plugin.NeighborhoodType.Normal)
					isok = true;
				else
					isok = false;
			}

			reader.BaseStream.Seek(0xc, System.IO.SeekOrigin.Begin);
			sciname = reader.ReadUInt16();
		}

		protected override void Serialize(System.IO.BinaryWriter writer)
		{
			uint scitype = 0xcc2a6a34;
			ushort scivers = 0xcb;
			writer.Write(scitype);
			writer.Write(scivers);
			writer.BaseStream.Seek(0xc, System.IO.SeekOrigin.Begin);
			writer.Write(sciname);
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
				uint[] types = { 0xCC2A6A34 }; //handles the Sim Creation Index
				return types;
			}
		}

		#endregion
	}
}
