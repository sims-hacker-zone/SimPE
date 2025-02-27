/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class Want
		: AbstractWrapper //Implements some of the default Behaviur of a Handler, you can Implement yourself if you want more flexibility!
			,
			IFileWrapper //This Interface is used when loading a File
			,
			IFileWrapperSaveExtension //This Interface (if available) will be used to store a File
									  //,IPackedFileProperties		//This Interface can be used by thirdparties to retrive the FIleproperties, however you don't have to implement it!
	{
		#region Attributes
		public uint Version
		{
			get; private set;
		}

		public WantItem[] LifetimeWants
		{
			get; set;
		}

		public WantItem[] Wants
		{
			get; set;
		}

		public WantItem[] Fears
		{
			get; set;
		}
		uint unknown1;
		uint unknown2;
		uint maxwants;
		uint maxfears;
		uint unknown5;

		public WantItemContainer[] History
		{
			get; set;
		}

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
						this.FileDescriptor.Instance
					);
					if (pfds.Length > 0)
					{
						PackedFiles.Wrapper.SDesc sdsc =
							new PackedFiles.Wrapper.SDesc(
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

		byte[] overhead;

		public Interfaces.IProviderRegistry Provider
		{
			get;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		public Want(Interfaces.IProviderRegistry provider)
			: base()
		{
			this.Provider = provider;

			Version = 1;
			unknown1 = 2;
			Wants = new WantItem[0];
			Fears = new WantItem[0];
			History = new WantItemContainer[0];
			LifetimeWants = new WantItem[0];
			overhead = new byte[0];
		}

		#region IWrapper member
		public override bool CheckVersion(uint version)
		{
			if (
				(version == 0012) //0.10
				|| (version == 0013) //0.12
			)
			{
				return true;
			}

			return false;
		}
		#endregion

		#region AbstractWrapper Member
		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new WantsUI();
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
					this.GetType()
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
			Version = reader.ReadUInt32();

			if (Version >= 0x05)
			{
				LifetimeWants = new WantItem[reader.ReadUInt32()];
				for (int i = 0; i < LifetimeWants.Length; i++)
				{
					LifetimeWants[i] = new WantItem(Provider);
					LifetimeWants[i].Unserialize(reader);
				}

				maxwants = reader.ReadUInt32();
			}
			else
			{
				maxwants = 4;
				LifetimeWants = new WantItem[0];
			}

			Wants = new WantItem[reader.ReadUInt32()];
			for (int i = 0; i < Wants.Length; i++)
			{
				Wants[i] = new WantItem(Provider);
				Wants[i].Unserialize(reader);
			}

			if (Version >= 0x05)
			{
				maxfears = reader.ReadUInt32();
			}
			else
			{
				maxfears = 3;
			}

			Fears = new WantItem[reader.ReadUInt32()];
			for (int i = 0; i < Fears.Length; i++)
			{
				Fears[i] = new WantItem(Provider);
				Fears[i].Unserialize(reader);
			}

			if (Version >= 0x05)
			{
				unknown5 = reader.ReadUInt32();
			}

			unknown1 = reader.ReadUInt32();
			unknown2 = reader.ReadUInt32();

			History = new WantItemContainer[reader.ReadUInt32()];
			for (int i = 0; i < History.Length; i++)
			{
				History[i] = new WantItemContainer(Provider);
				History[i].Unserialize(reader);
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
				writer.Write((uint)LifetimeWants.Length);
				for (int i = 0; i < LifetimeWants.Length; i++)
				{
					LifetimeWants[i].Serialize(writer);
				}

				writer.Write(maxwants);
			}
			else
			{
				maxwants = 4;
				LifetimeWants = new WantItem[0];
			}

			writer.Write((uint)Wants.Length);
			for (int i = 0; i < Wants.Length; i++)
			{
				Wants[i].Serialize(writer);
			}

			if (Version >= 0x05)
			{
				writer.Write(maxfears);
			}
			else
			{
				maxfears = 3;
			}

			writer.Write((uint)Fears.Length);
			for (int i = 0; i < Fears.Length; i++)
			{
				Fears[i].Serialize(writer);
			}

			if (Version >= 0x05)
			{
				writer.Write(unknown5);
			}

			writer.Write(unknown1);
			writer.Write(unknown2);

			writer.Write((uint)History.Length);
			for (int i = 0; i < History.Length; i++)
			{
				History[i].Serialize(writer);
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
		public uint[] AssignableTypes
		{
			get
			{
				uint[] types =
				{
					0xCD95548E, //handles the Want Files
				};
				return types;
			}
		}

		#endregion
	}
}
