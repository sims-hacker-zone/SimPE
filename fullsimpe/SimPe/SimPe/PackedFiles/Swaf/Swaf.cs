// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;
using System.Linq;

using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Swaf
{
	public class Swaf : AbstractWrapper, IFileWrapper, IFileWrapperSaveExtension
	{
		#region Attributes
		public uint Version
		{
			get; set;
		} = 1;

		public List<WantItem> Items { get; private set; } = new List<WantItem>();

		public IEnumerable<WantItem> LifetimeWants => from item in Items
													  where item.ItemType == SwafItemType.LifetimeWants
													  select item;

		public uint MaxWants
		{
			get;
			set;
		}
		public IEnumerable<WantItem> Wants => from item in Items
											  where item.ItemType == SwafItemType.Wants
											  select item;
		public uint MaxFears
		{
			get;
			set;
		}
		public IEnumerable<WantItem> Fears => from item in Items
											  where item.ItemType == SwafItemType.Fears
											  select item;
		public uint Unknown3
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

		public Dictionary<uint, List<WantItem>> History
		{
			get; set;
		} = new Dictionary<uint, List<WantItem>>();

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
						Data.MetaData.SIM_DESCRIPTION_FILE,
						0,
						FileDescriptor.Instance
					);
					if (pfds.Length > 0)
					{
						Wrapper.SDesc sdsc =
							new Wrapper.SDesc(
								Provider.SimNameProvider,
								Provider.SimFamilynameProvider,
								Provider.SimDescriptionProvider
							);
						sdsc.ProcessData(pfds[0], Package);

						return sdsc;
					}
				}
				return null;
			}
		}
		#endregion

		public byte[] Unknown4 { get; set; } = new byte[0];

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
			Items.Clear();
			History.Clear();

			Version = reader.ReadUInt32();

			if (Version >= 0x05)
			{
				uint lwcount = reader.ReadUInt32();
				for (int i = 0; i < lwcount; i++)
				{
					Items.Add(new WantItem(Provider, SwafItemType.LifetimeWants).Unserialize(reader));
				}

				MaxWants = reader.ReadUInt32();
			}
			else
			{
				MaxWants = 4;
			}

			uint wantcount = reader.ReadUInt32();
			for (int i = 0; i < wantcount; i++)
			{
				Items.Add(new WantItem(Provider, SwafItemType.Wants).Unserialize(reader));
			}

			MaxFears = Version >= 0x05 ? reader.ReadUInt32() : 3;

			uint fearcount = reader.ReadUInt32();
			for (int i = 0; i < fearcount; i++)
			{
				Items.Add(new WantItem(Provider, SwafItemType.Fears).Unserialize(reader));
			}

			if (Version >= 0x05)
			{
				Unknown3 = reader.ReadUInt32();
			}

			Unknown1 = reader.ReadUInt32();
			Unknown2 = reader.ReadUInt32();

			uint historycount = reader.ReadUInt32();
			for (int i = 0; i < historycount; i++)
			{
				uint key = reader.ReadUInt32();
				List<WantItem> value = new List<WantItem>();
				uint hcount = reader.ReadUInt32();
				for (int j = 0; j < hcount; j++)
				{
					value.Add(
						new WantItem(Provider, SwafItemType.Fears).Unserialize(reader)
					);
				}

				History.Add(key, value);
			}

			Unknown4 = reader.ReadBytes(
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
				writer.Write((uint)LifetimeWants.Count());
				foreach (WantItem lw in LifetimeWants)
				{
					lw.Serialize(writer);
				}

				writer.Write(MaxWants);
			}

			writer.Write((uint)Wants.Count());
			foreach (WantItem want in Wants)
			{
				want.Serialize(writer);
			}

			if (Version >= 0x05)
			{
				writer.Write(MaxFears);
			}

			writer.Write((uint)Fears.Count());
			foreach (WantItem fear in Fears)
			{
				fear.Serialize(writer);
			}

			if (Version >= 0x05)
			{
				writer.Write(Unknown3);
			}

			writer.Write(Unknown1);
			writer.Write(Unknown2);

			writer.Write((uint)History.Count);
			foreach (KeyValuePair<uint, List<WantItem>> history in History)
			{
				writer.Write(history.Key);
				writer.Write(history.Value.Count);
				foreach (WantItem i in history.Value)
				{
					i.Serialize(writer);
				}
			}

			writer.Write(Unknown4);
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
		public uint[] AssignableTypes => new uint[]
				{
					0xCD95548E, //handles the Want Files
				};
		#endregion
	}
}
