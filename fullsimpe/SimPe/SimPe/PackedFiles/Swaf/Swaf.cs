// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;

using SimPe.Data;
using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Swaf
{
	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class Swaf : AbstractWrapper, IFileWrapper, IFileWrapperSaveExtension
	{
		#region Attributes
		public uint Version
		{
			get; private set;
		} = 1;

		public List<WantItem> LifetimeWants
		{
			get; set;
		} = new List<WantItem>();

		public uint MaxWants
		{
			get;
			set;
		}
		public List<WantItem> Wants
		{
			get; set;
		} = new List<WantItem>();
		public uint MaxFears
		{
			get;
			set;
		}
		public List<WantItem> Fears
		{
			get; set;
		} = new List<WantItem>();
		public uint Unknown5
		{
			get;
			set;
		}
		public uint Unknown1
		{
			get;
			set;
		} = 2;
		public uint Unknown2
		{
			get;
			set;
		}

		public List<WantItemContainer> History
		{
			get; set;
		} = new List<WantItemContainer>();

		/// <summary>
		/// Returns null or a loaded SimDescription
		/// </summary>
		public Interfaces.Wrapper.ISDesc SimDescription
		{
			get
			{
				if (Package != null)
				{
					//return provider.SimDescriptionProvider.FindSim((ushort)this.FileDescriptor.Instance);
					Interfaces.Files.IPackedFileDescriptor[] pfds = Package.FindFile(
						FileTypes.SDSC,
						0,
						FileDescriptor.Instance
					);
					if (pfds.Length > 0)
					{
						return new Sdsc.SDesc(
								Provider.SimNameProvider,
								Provider.SimFamilynameProvider,
								Provider.SimDescriptionProvider
							).ProcessFile(pfds[0], Package);
					}
				}
				return null;
			}
		}
		#endregion

		private byte[] overhead = new byte[0];

		public Interfaces.IProviderRegistry Provider
		{
			get;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		public Swaf(Interfaces.IProviderRegistry provider)
			: base()
		{
			Provider = provider;
		}

		#region IWrapper member
		public override bool CheckVersion(uint version)
		{
			return version == 0012 //0.10
				|| version == 0013; //0.12
		}
		#endregion

		#region AbstractWrapper Member
		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new SwafUI();
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Sim Wants and Fear Wrapper",
				"Quaxi",
				"---",
				4,
				System.Drawing.Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.kweather.png")
				)
			);
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			LifetimeWants.Clear();
			Wants.Clear();
			Fears.Clear();
			History.Clear();

			Version = reader.ReadUInt32();

			if (Version >= 0x05)
			{
				uint lwcount = reader.ReadUInt32();
				LifetimeWants.Capacity = (int)lwcount;
				for (int i = 0; i < lwcount; i++)
				{
					WantItem lw = new WantItem(Provider);
					lw.Unserialize(reader);
					LifetimeWants.Add(lw);
				}

				MaxWants = reader.ReadUInt32();
			}
			else
			{
				MaxWants = 4;
			}

			uint wantcount = reader.ReadUInt32();
			Wants.Capacity = (int)wantcount;
			for (int i = 0; i < wantcount; i++)
			{
				WantItem want = new WantItem(Provider);
				want.Unserialize(reader);
				Wants.Add(want);
			}

			MaxFears = Version >= 0x05 ? reader.ReadUInt32() : 3;

			uint fearcount = reader.ReadUInt32();
			Fears.Capacity = (int)fearcount;
			for (int i = 0; i < fearcount; i++)
			{
				WantItem fear = new WantItem(Provider);
				fear.Unserialize(reader);
				Fears.Add(fear);
			}

			if (Version >= 0x05)
			{
				Unknown5 = reader.ReadUInt32();
			}

			Unknown1 = reader.ReadUInt32();
			Unknown2 = reader.ReadUInt32();

			uint historycount = reader.ReadUInt32();
			History.Capacity = (int)historycount;
			for (int i = 0; i < historycount; i++)
			{
				WantItemContainer history = new WantItemContainer(Provider);
				history.Unserialize(reader);
				History.Add(history);
			}

			overhead = reader.ReadBytes(
				(int)(reader.BaseStream.Length - reader.BaseStream.Position)
			);
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

			if (Version >= 0x05)
			{
				writer.Write((uint)LifetimeWants.Count);
				foreach (WantItem lw in LifetimeWants)
				{
					lw.Serialize(writer);
				}

				writer.Write(MaxWants);
			}

			writer.Write((uint)Wants.Count);
			foreach (WantItem want in Wants)
			{
				want.Serialize(writer);
			}

			if (Version >= 0x05)
			{
				writer.Write(MaxFears);
			}

			writer.Write((uint)Fears.Count);
			foreach (WantItem fear in Fears)
			{
				fear.Serialize(writer);
			}

			if (Version >= 0x05)
			{
				writer.Write(Unknown5);
			}

			writer.Write(Unknown1);
			writer.Write(Unknown2);

			writer.Write((uint)History.Count);
			foreach (WantItemContainer history in History)
			{
				history.Serialize(writer);
			}

			writer.Write(overhead);
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
		public FileTypes[] AssignableTypes => new FileTypes[]
				{
					FileTypes.SWAF, //handles the Want Files
				};
		#endregion
	}
}
