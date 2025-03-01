// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Drawing;
using System.IO;

using SimPe.Interfaces.Files;
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
	public class FamiuPackedFileWrapper
		: AbstractWrapper,
			IFileWrapper,
			IFileWrapperSaveExtension
	{
		#region File Attribute
		/// <summary>
		/// Contains the Data of the File
		/// </summary>
		private ushort[] fval;
		private int signate = 0x46414d68;
		public bool isnew = true;

		/// <summary>
		/// Returns/Sets the Data of the File
		/// </summary>
		public ushort[] FVal
		{
			get => fval;
			set => fval = value;
		}

		/// <summary>
		/// Returns/Sets the number of blocks
		/// </summary>
		public int Sections { get; set; } = 0;

		/// <summary>
		/// Returns the  the number of good blocks
		/// </summary>
		public int GoodSections { get; private set; } = 0;

		/// <summary>
		/// Returns the Version of the File
		/// </summary>
		public byte Version { get; private set; } = 85;

		/// <summary>
		/// Returns the Name of the Family
		/// </summary>
		public string Name
		{
			get
			{
				string name = Localization.Manager.GetString("unknown");
				try
				{
					IPackedFileDescriptor pfd = package.FindFile(
						Data.MetaData.STRING_FILE,
						0,
						FileDescriptor.Group,
						FileDescriptor.Instance
					);
					if (pfd != null)
					{
						PackedFiles.Wrapper.Str str =
							new PackedFiles.Wrapper.Str();
						str.ProcessData(pfd, package);
						PackedFiles.Wrapper.StrItemList items =
							str.FallbackedLanguageItems(
								Helper.WindowsRegistry.LanguageCode
							);
						if (items.Length > 0)
						{
							name = items[0].Title;
						}
					}
				}
				catch (Exception) { }
				return name;
			}
		}

		/// <summary>
		/// Returns the Suburb of the Lot
		/// </summary>
		public string Subhood(uint instc)
		{
			if (Helper.StartedGui == Executable.Classic || package.FileName == null)
			{
				return null;
			}

			string subh = Localization.Manager.GetString("unknown");
			if (!Helper.IsNeighborhoodFile(package.FileName))
			{
				return subh;
			}

			if (instc == 0)
			{
				return "-Homeless-";
			}

			string[] overs = Directory.GetFiles(
				Path.GetDirectoryName(package.FileName),
				"*.package",
				SearchOption.TopDirectoryOnly
			);
			if (overs.Length > 0)
			{
				Packages.GeneratableFile pkg;
				foreach (string file in overs)
				{
					pkg = Packages.File.LoadFromFile(file);
					if (pkg.FindFileAnyGroup(0x0BF999E7, 0, instc) != null)
					{
						IPackedFileDescriptor pfd = pkg.FindFileAnyGroup(
							Data.MetaData.CTSS_FILE,
							0,
							1
						);
						if (pfd != null)
						{
							PackedFiles.Wrapper.Str str =
								new PackedFiles.Wrapper.Str();
							str.ProcessData(pfd, pkg);
							PackedFiles.Wrapper.StrItemList items =
								str.FallbackedLanguageItems(
									Helper.WindowsRegistry.LanguageCode
								);
							if (items.Length > 0)
							{
								subh = items[0].Title;
							}
						}
						else
						{
							subh = "Tutorial";
						}

						return subh;
					}
				}
			}
			return subh;
		}

		/// <summary>
		/// Returns the Image for the Family
		/// </summary>
		public Image FamiThumb
		{
			get
			{
				if (Helper.StartedGui == Executable.Classic || package.FileName == null)
				{
					return null;
				}

				if (!Helper.IsNeighborhoodFile(package.FileName))
				{
					return null;
				}

				int inxy =
					Path.GetFileNameWithoutExtension(package.FileName)
						.IndexOf("_") + 1;
				string suyt = Path.GetFileNameWithoutExtension(package.FileName)
					.Substring(0, inxy);
				Packages.File fumbs = Packages.File.LoadFromFile(
					Path.Combine(
						Path.GetDirectoryName(package.FileName),
						"Thumbnails\\" + suyt + "FamilyThumbnails.package"
					)
				);
				IPackedFileDescriptor pfd = fumbs.FindFileAnyGroup(
					0x8C3CE95A,
					0,
					FileDescriptor.Instance
				);
				if (pfd != null)
				{
					try
					{
						PackedFiles.Wrapper.Picture pic =
							new PackedFiles.Wrapper.Picture();
						pic.ProcessData(pfd, fumbs);
						return Ambertation.Drawing.GraphicRoutines.MakeTransparent(
							pic.Image,
							Color.Black,
							0.05f,
							true
						);
					}
					catch (Exception)
					{
						return null;
					}
				}
				return null;
			}
		}

		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public FamiuPackedFileWrapper()
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
			return new FamiuPackedFileUI();
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Family History Wrapper",
				"Chris",
				"Contains the history of a well played family",
				1,
				Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.book.png")
				)
			);
		}

		protected override string GetResourceName(Data.TypeAlias ta)
		{
			if (!Processed)
			{
				ProcessData(FileDescriptor, Package);
			}

			return Name + " History";
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected override void Unserialize(BinaryReader reader)
		{
			isnew = false; // empty files don't get Unserialize, this value shows the file as not empty
			GoodSections = 0;
			signate = reader.ReadInt32();
			Version = reader.ReadByte(); // Versions match Fami Versions
			reader.BaseStream.Seek(13, SeekOrigin.Begin);
			Sections = reader.ReadInt32();
			int siser = Sections * 42; // 83 bytes - 1 byte + 41 two bit bytes
			Array.Resize(ref fval, siser);

			reader.BaseStream.Seek(17, SeekOrigin.Begin);
			try
			{
				for (int i = 0; i < Sections; i++)
				{
					for (int j = 0; j < 41; j++)
					{
						fval[(i * 42) + j] = reader.ReadUInt16();
					}

					fval[(i * 42) + 41] = Convert.ToUInt16(reader.ReadByte());

					if (Helper.WindowsRegistry.AllowLotZero || fval[i * 42] > 0)
					{
						if (
							(fval[(i * 42) + 1] < 33)
							&& (
								fval[(i * 42) + 2]
									+ fval[(i * 42) + 3]
									+ fval[(i * 42) + 4]
									+ fval[(i * 42) + 5]
								== fval[(i * 42) + 1]
							)
						)
						{
							GoodSections++;
						}
					}
				}
			}
			catch { }
		}

		/// <summary>
		/// Serializes a the Attributes stored in this Instance to the BinaryStream
		/// </summary>
		/// <param name="writer">The Stream the Data should be stored to</param>
		/// <remarks>
		/// Be sure that the Position of the stream is Proper on
		/// return (i.e. must point to the first Byte after your actual File)
		/// </remarks>
		protected override void Serialize(BinaryWriter writer)
		{
			writer.Write(signate);
			writer.Write(Version);
			writer.Write(0);
			writer.Write(0);
			writer.Write(Sections);
			for (int i = 0; i < Sections; i++)
			{
				for (int j = 0; j < 41; j++)
				{
					writer.Write(fval[(i * 42) + j]);
				}

				writer.Write(Convert.ToByte(fval[(i * 42) + 41]));
			}
		}
		#endregion

		#region IFileWrapperSaveExtension Member
		//all covered by Serialize()
		#endregion

		#region IFileWrapper Member

		/// <summary>
		/// Returns the Signature that can be used to identify Files processable with this Plugin
		/// </summary>
		public byte[] FileSignature
		{
			get
			{
				byte[] sig = { (byte)'h', (byte)'M', (byte)'A', (byte)'F' };
				return sig;
			}
		}

		/// <summary>
		/// Returns a list of File Type this Plugin can process
		/// </summary>
		public uint[] AssignableTypes
		{
			get
			{
				uint[] types = { 0x46414D68 }; //handles the Family History File
				return types;
			}
		}

		#endregion
	}
}
