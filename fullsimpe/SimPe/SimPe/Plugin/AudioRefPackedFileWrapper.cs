using System;

using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	public class AudioRefPackedFileWrapper
		: AbstractWrapper,
			IFileWrapper,
			IFileWrapperSaveExtension
	{
		#region CreationIndex Attribute
		public string strung; // the actaul string,
		public string Strung
		{
			get
			{
				return strung;
			}
			set
			{
				strung = value;
			}
		}
		#endregion

		public AudioRefPackedFileWrapper()
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
			return new AudioRefPackedFileUI();
		}

		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"FWAV and CATS Wrapper",
				"Chris",
				"To View or Edit (unused) Audio Reference and Catalogue String Files",
				1,
				SimPe.GetIcon.Writable
			);
		}

		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			reader.BaseStream.Seek(0x40, System.IO.SeekOrigin.Begin);
			strung = "";
			while (reader.BaseStream.Position < reader.BaseStream.Length)
			{
				char b = reader.ReadChar();
				if (b != 0)
					strung += b;
				else
					strung += "\n";
			}
		}

		protected override void Serialize(System.IO.BinaryWriter writer)
		{
			byte f = 0;
			writer.BaseStream.Seek(0x40, System.IO.SeekOrigin.Begin);
			if (strung != null)
				foreach (char c in strung)
				{
					if (c != 10)
						writer.Write(c);
					else
						writer.Write(f);
				}
			writer.Write(f);
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
				uint[] types =
				{
					0x43415453, // Catalogue String
					0x46574156, // Audio Reference
				};
				return types;
			}
		}

		#endregion
	}
}
