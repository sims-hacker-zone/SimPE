namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for MmatWrapper.
	/// </summary>
	public class XGoal : PackedFiles.Wrapper.Cpf
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
		public override uint[] AssignableTypes
		{
			get
			{
				uint[] types = { 0xBEEF7B4D };

				return types;
			}
		}

		#region Default Attribute
		public uint StringInstance
		{
			get
			{
				return GetSaveItem("stringSet").UIntegerValue;
			}
			set
			{
				GetSaveItem("stringSet").UIntegerValue = value;
			}
		}

		public uint Guid
		{
			get
			{
				return GetSaveItem("id").UIntegerValue;
			}
			set
			{
				GetSaveItem("id").UIntegerValue = value;
			}
		}

		public uint IconInstance
		{
			get
			{
				return GetSaveItem("primaryIcon").UIntegerValue;
			}
			set
			{
				GetSaveItem("primaryIcon").UIntegerValue = value;
			}
		}

		public uint SecondaryIconInstance
		{
			get
			{
				return GetSaveItem("secondaryIcon").UIntegerValue;
			}
			set
			{
				GetSaveItem("secondaryIcon").UIntegerValue = value;
			}
		}

		public int Score
		{
			get
			{
				return GetSaveItem("score").IntegerValue;
			}
			set
			{
				GetSaveItem("score").IntegerValue = value;
			}
		}

		public int Influence
		{
			get
			{
				return GetSaveItem("influence").IntegerValue;
			}
			set
			{
				GetSaveItem("influence").IntegerValue = value;
			}
		}
		public string NodeText
		{
			get
			{
				return GetSaveItem("nodeText").StringValue;
			}
			set
			{
				GetSaveItem("nodeText").StringValue = value;
			}
		}

		public Interfaces.Files.IPackedFileDescriptor IconFileDescriptor
		{
			get
			{
				Packages.PackedFileDescriptor pfd =
					new Packages.PackedFileDescriptor();
				pfd.Type = Data.MetaData.SIM_IMAGE_FILE;
				pfd.LongInstance = IconInstance;
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

		protected override string GetResourceName(Data.TypeAlias ta)
		{
			if (!Processed)
			{
				ProcessData(FileDescriptor, Package);
			}

			return NodeText;
		}
	}
}
