// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;
using System.Linq;

using SimPe.Interfaces;
using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Nmap
{
	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class Nmap : AbstractWrapper, IFileWrapper, IFileWrapperSaveExtension
	{
		#region Attributes
		/// <summary>
		/// Stores the Header
		/// </summary>
		/// <summary>
		/// Returns / Sets the Header
		/// </summary>
		public List<Interfaces.Files.IPackedFileDescriptor> Items
		{
			get; set;
		} = new List<Interfaces.Files.IPackedFileDescriptor>();

		#endregion

		public IProviderRegistry Provider
		{
			get;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		public Nmap(IProviderRegistry provider)
			: base()
		{
			Provider = provider;
		}

		/// <summary>
		/// Returns all Filedescriptors for Files starting with the given Value
		/// </summary>
		/// <param name="start">The string the FIlename starts with</param>
		/// <returns>A List of File Descriptors</returns>
		public IEnumerable<Interfaces.Files.IPackedFileDescriptor> FindFiles(string start)
		{
			return from pfd in Items
				   where pfd.Filename.Trim().ToLower().StartsWith(start.Trim().ToLower())
				   select pfd;
		}

		#region IWrapper member
		public override bool CheckVersion(uint version)
		{
			return true;
		}
		#endregion

		#region AbstractWrapper Member
		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new NmapUI();
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Name Map Wrapper",
				"Quaxi",
				"---",
				4,
				System.Drawing.Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.view_tree.png")
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
			uint count = reader.ReadUInt32();
			Items.Capacity = (int)count;

			for (int i = 0; i < count; i++)
			{
				NmapItem pfd = new NmapItem(this)
				{
					Group = reader.ReadUInt32(),
					Instance = reader.ReadUInt32()
				};

				uint len = reader.ReadUInt32();
				pfd.Filename = Helper.ToString(reader.ReadBytes((int)len));

				Items.Add(pfd);
			}
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
			writer.Write((uint)Items.Count);

			foreach (Interfaces.Files.IPackedFileDescriptor pfd in Items)
			{
				writer.Write(pfd.Group);
				writer.Write(pfd.Instance);

				writer.Write((uint)pfd.Filename.Length);
				writer.Write(Helper.ToBytes(pfd.Filename, 0));
			}
		}
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
					Data.MetaData.NAME_MAP, //handles the NMAP File
				};

		#endregion
	}
}
