using System;
using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	public class FunctionPackedFileWrapper
		: AbstractWrapper,
			IFileWrapper,
			IFileWrapperSaveExtension
	{
		#region CreationIndex Attribute
		private uint filid; // File ID, must be SNCF (0x46434e53)
		private ushort fpurpos; // File Purpose, not sure of it's use but should be retained
		private ushort quanty; // amount of entries in the file
		public string[] strung; // the actaul string, don't change this
		public float[] valwe; // the actual data or value.
		public string[] comnt; // the comment, can be a very long string
		public ushort Quanty
		{
			get { return quanty; }
			set { quanty = value; }
		}
		#endregion

		public FunctionPackedFileWrapper()
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
			return new FunctionPackedFileUI();
		}

		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Game Function Wrapper",
				"Chris",
				"To View the Game Functions",
				2,
				SimPe.GetIcon.GameTit
			);
		}

		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			// for (int i = 0; i < 60; i++) { valwe[i] = 0; strung[i] = null; comnt[i] = null;}
			quanty = 0;
			reader.BaseStream.Seek(0x40, System.IO.SeekOrigin.Begin);
			filid = reader.ReadUInt32();
			fpurpos = reader.ReadUInt16();
			reader.BaseStream.Seek(0x6, System.IO.SeekOrigin.Current);
			quanty = reader.ReadUInt16(); // Number of items
			if (filid == 0x46434e53 && quanty > 0) // check for valid file
			{
				Array.Resize<string>(ref strung, quanty);
				Array.Resize<float>(ref valwe, quanty);
				Array.Resize<string>(ref comnt, quanty);
				reader.BaseStream.Seek(0x2, System.IO.SeekOrigin.Current);
				for (int i = 0; i < quanty; i++)
				{
					strung[i] = reader.ReadString();
					valwe[i] = reader.ReadSingle();
					comnt[i] = reader.ReadString();
				}
			}
		}

		protected override void Serialize(System.IO.BinaryWriter writer)
		{
			writer.BaseStream.Seek(0x40, System.IO.SeekOrigin.Begin);
			writer.Write(filid);
			writer.Write(fpurpos);
			writer.BaseStream.Seek(0x6, System.IO.SeekOrigin.Current);
			writer.Write(quanty);
			writer.BaseStream.Seek(0x2, System.IO.SeekOrigin.Current);
			for (int i = 0; i < quanty; i++)
			{
				writer.Write(strung[i]);
				writer.Write(valwe[i]);
				writer.Write(comnt[i]);
			}
		}
		#endregion

		#region IFileWrapperSaveExtension Member
		//all covered by Serialize()
		#endregion

		#region IFileWrapper Member

		public byte[] FileSignature
		{
			get { return new byte[0]; }
		}

		public uint[] AssignableTypes
		{
			get
			{
				uint[] types = { 0x46434E53 }; //handles the Game Functions
				return types;
			}
		}

		#endregion
	}
}
