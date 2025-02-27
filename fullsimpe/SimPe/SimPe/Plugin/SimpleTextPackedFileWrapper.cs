using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	public class SimpleTextPackedFileWrapper
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

		public SimpleTextPackedFileWrapper()
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
			return new SimpleTextPackedFileUI();
		}

		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Simple Text Viewer Wrapper",
				"Chris",
				"To View the Simple Text Files",
				1,
				GetIcon.Writable
			);
		}

		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			reader.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
			strung = "";
			while (reader.BaseStream.Position < reader.BaseStream.Length)
			{
				char b = reader.ReadChar();
				strung += b;
			}
		}

		protected override void Serialize(System.IO.BinaryWriter writer)
		{
			if (strung != null)
			{
				foreach (char c in strung)
				{
					writer.Write(c);
				}
			}
		}
		#endregion

		#region IFileWrapperSaveExtension Member
		//all covered by Serialize()
		#endregion

		#region IFileWrapper Member

		public byte[] FileSignature => new byte[0];

		public uint[] AssignableTypes
		{
			get
			{
				uint[] types =
				{
					0xA2E3D533, //handles the Accelerator Key Definitions
					0x50544250, //handles the Silly Package Text
				};
				return types;
			}
		}

		#endregion
	}
}
