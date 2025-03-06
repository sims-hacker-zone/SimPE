// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using SimPe.Data;
using SimPe.Extensions;
using SimPe.Interfaces.Files;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Wrapper;

namespace SimPe.PackedFiles.Fami
{

	/// <summary>
	/// Represents a PackedFile in Fami Format
	/// </summary>
	public class Fami : AbstractWrapper, IFileWrapper, IFileWrapperSaveExtension
	{
		#region Properties
		public FileTypes Id { get; set; } = FileTypes.FAMI;
		public FamiVersions Version { get; private set; } = FamiVersions.Original;
		public uint Unknown { get; set; } = 0;

		/// <summary>
		/// Returns a Descriptor for the Lot the Family lives in, or null if none assigned
		/// </summary>
		public uint LotInstance
		{
			get; set;
		}

		/// <summary>
		/// Returns the INstance of the Lot, where the Player last left the Family
		/// </summary>
		public uint CurrentlyOnLotInstance
		{
			get; set;
		}

		/// <summary>
		/// Returns a Descriptor for the Lot where the family stays for vacation
		/// </summary>
		public uint VacationLotInstance
		{
			get; set;
		}

		/// <summary>
		/// The STR instance, which contains the family name
		/// </summary>
		public uint FamilyNameStrInstance
		{
			get;
			set;
		}

		/// <summary>
		/// Returns/Sets the amount of Money the Family posesses
		/// </summary>
		public int Money
		{
			get; set;
		}

		public int CastAwayFoodDecay
		{
			get; set;
		}

		/// <summary>
		/// Returns the Number of Family friends
		/// </summary>
		public uint Friends
		{
			get; set;
		}

		/// <summary>
		/// Returns/Sets the Flags
		/// </summary>
		public FamiFlags Flags
		{
			get; set;
		} = FamiFlags.NewLot;

		/// <summary>
		/// The Members of this Family as Sim IDs
		/// </summary>
		public List<uint> Members { get; set; } = new List<uint>();

		/// <summary>
		/// Returns/Sets the Story Telling Album GUID
		/// </summary>
		public uint AlbumGUID
		{
			get; set;
		}

		public uint SubHoodNumber
		{
			get; set;
		}

		public int CastAwayResources
		{
			get; set;
		}

		public int CastAwayFood
		{
			get; set;
		}

		/// <summary>
		/// Returns/Sets the Business Money (???)
		/// </summary>
		public int BusinessMoney
		{
			get; set;
		}


		/// <summary>
		/// Returns the FirstName of a Sim the Sims
		/// </summary>
		/// <remarks>If no SimName Provider is available, all Names will be empty</remarks>
		public IEnumerable<string> SimNames => NameProvider != null
					? from member in Members select NameProvider.FindName(member).Name
					: from member in Members select default(string);

		/// <summary>
		/// Returns the Name of the Family
		/// </summary>
		public string Name
		{
			get
			{
				//string name = Localization.Manager.GetString("Unknown");
				string name = Data.MetaData.NPCFamily(FileDescriptor.Instance);
				try
				{
					IPackedFileDescriptor pfd = package.FindFile(
						Data.FileTypes.STR,
						0,
						FileDescriptor.Group,
						FileDescriptor.Instance
					);

					//found a Text Resource
					if (pfd != null)
					{
						Str str = new Str();
						str.ProcessData(pfd, package);

						StrItemList items =
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
			set
			{
				try
				{
					IPackedFileDescriptor pfd = package.FindFile(
						Data.FileTypes.STR,
						0,
						FileDescriptor.Group,
						FileDescriptor.Instance
					);

					// found a Text Resource
					if (pfd != null)
					{
						Str str = new Str();
						str.ProcessData(pfd, package);

						foreach (
							StrLanguage lng in str.Languages
						)
						{
							if (lng == null)
							{
								continue;
							}

							if (str.LanguageItems(lng)[0x0] != null)
							{
								str.LanguageItems(lng)[0x0].Title = value;
							}
						}

						str.SynchronizeUserData();
					}
				}
				catch (Exception) { }
			}
		}

		/// <summary>
		/// Returns the Image for the Family
		/// </summary>
		public Image FamiThumb
		{
			get
			{
				if (Helper.IsLotCatalogFile(package.FileName))
				{
					IPackedFileDescriptor pfc = package.FindFile(
						FileTypes.IMG,
						0,
						0xFFFFFFFF,
						0x6CD85218
					);
					if (pfc != null)
					{
						try
						{
							Picture.Picture pic =
								new Picture.Picture();
							pic.ProcessData(pfc, package);
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
				}
				else
				{
					if (
						Helper.StartedGui == Executable.Classic
						|| FileDescriptor.Instance > 32511
						|| package.FileName == null
					)
					{
						return null;
					}

					int inxy =
						System
							.IO.Path.GetFileNameWithoutExtension(package.FileName)
							.IndexOf("_") + 1;
					string suyt = System
						.IO.Path.GetFileNameWithoutExtension(package.FileName)
						.Substring(0, inxy);
					Packages.File fumbs = Packages.File.LoadFromFile(
						System.IO.Path.Combine(
							System.IO.Path.GetDirectoryName(package.FileName),
							"Thumbnails\\" + suyt + "FamilyThumbnails.package"
						)
					);
					IPackedFileDescriptor pfd = fumbs.FindFileAnyGroup(
						FileTypes.THUMB_FAMILY,
						0,
						FileDescriptor.Instance
					);
					if (pfd != null)
					{
						try
						{
							Picture.Picture pic = new Picture.Picture();
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
				}
				return null;
			}
		}

		/// <summary>
		/// Returns the Name Provider
		/// </summary>
		internal Interfaces.Providers.ISimNames NameProvider
		{
			get; private set;
		}
		#endregion

		/// <summary>
		/// Returns the Description File for the passed Sim id
		/// </summary>
		/// <param name="simid">id of the Sim</param>
		/// <returns>The Description file for the Sim</returns>
		/// <remarks>
		/// If the Description file does not exist in
		/// the current Package, it will be added!
		/// </remarks>
		/// <exception cref="Exception">Thrown when ProcessData was not called.</exception>
		public SDesc GetDescriptionFile(uint simid)
		{
			if (package == null)
			{
				throw new Exception("No package loaded!");
			}

			SDesc sdesc = SDesc.FindForSimId(simid, package);
			if (sdesc == null)
			{
				sdesc = new SDesc(null, null, null)
				{
					SimId = simid
				};
				sdesc.CharacterDescription.Age = 28;
				sdesc.CharacterDescription.Gender = Data.MetaData.Gender.Female;

				IPackedFileDescriptor[] files = package.FindFiles(
					Data.FileTypes.SDSC
				);
				sdesc.Instance = 0;
				foreach (IPackedFileDescriptor pfd in files)
				{
					if (pfd.Instance > sdesc.Instance)
					{
						sdesc.Instance = (ushort)pfd.Instance;
					}
				}
				sdesc.Instance++;

				IPackedFileDescriptor fd = package.Add(
					Data.FileTypes.SDSC,
					0x0,
					FileDescriptor.Group,
					sdesc.Instance
				);
				sdesc.Save(fd);
			}

			return sdesc;
		}

		#region AbstractWrapper Member
		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new FamiUI();
		}

		public Fami(Interfaces.Providers.ISimNames names)
			: base()
		{
			NameProvider = names;
		}

		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			Id = (FileTypes)reader.ReadUInt32();
			Version = (FamiVersions)reader.ReadUInt32();
			Unknown = reader.ReadUInt32(); // Always 0x0000
			LotInstance = reader.ReadUInt32();
			if ((int)Version >= (int)FamiVersions.Business)
			{
				CurrentlyOnLotInstance = reader.ReadUInt32();
			}

			if ((int)Version >= (int)FamiVersions.Voyage)
			{
				VacationLotInstance = reader.ReadUInt32();
			}

			if ((int)Version >= (int)FamiVersions.Castaway)
			{
				CastAwayResources = reader.ReadInt32();
				CastAwayFood = reader.ReadInt32();
				CastAwayFoodDecay = reader.ReadInt32();
			}
			else
			{
				FamilyNameStrInstance = reader.ReadUInt32();
				Money = reader.ReadInt32();
			}

			Friends = reader.ReadUInt32();
			Flags = (FamiFlags)reader.ReadUInt32();

			uint count = reader.ReadUInt32();
			Members.Clear();
			Members.Capacity = (int)count;
			for (int i = 0; i < count; i++)
			{
				Members.Add(reader.ReadUInt32());
			}

			AlbumGUID = reader.ReadUInt32(); //relations??
			if ((int)Version >= (int)FamiVersions.University)
			{
				SubHoodNumber = reader.ReadUInt32();
			}

			if ((int)Version >= (int)FamiVersions.Castaway)
			{
				CastAwayResources = reader.ReadInt32();
				CastAwayFood = reader.ReadInt32();
				CastAwayFoodDecay = reader.ReadInt32();
			}
			else if ((int)Version >= (int)FamiVersions.Business)
			{
				BusinessMoney = reader.ReadInt32();
			}
		}

		protected override void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write((uint)Id);
			writer.Write((uint)Version);
			writer.Write(Unknown);
			writer.Write(LotInstance);
			if ((int)Version >= (int)FamiVersions.Business)
			{
				writer.Write(CurrentlyOnLotInstance);
			}

			if ((int)Version >= (int)FamiVersions.Voyage)
			{
				writer.Write(VacationLotInstance);
			}

			if ((int)Version >= (int)FamiVersions.Castaway)
			{
				writer.Write(CastAwayResources);
				writer.Write(CastAwayFood);
				writer.Write(CastAwayFoodDecay);
			}
			else
			{
				writer.Write(FamilyNameStrInstance);
				writer.Write(Money);
			}
			writer.Write(Friends);
			writer.Write((uint)Flags);

			writer.Write((uint)Members.Count);
			foreach (uint member in Members)
			{
				writer.Write(member);
			}

			writer.Write(AlbumGUID);

			if ((int)Version >= (int)FamiVersions.University)
			{
				writer.Write(SubHoodNumber);
			}

			if ((int)Version >= (int)FamiVersions.Castaway)
			{
				writer.Write(CastAwayResources);
				writer.Write(CastAwayFood);
				writer.Write(CastAwayFoodDecay);
			}
			else if ((int)Version >= (int)FamiVersions.Business)
			{
				writer.Write(BusinessMoney);
			}
		}
		#endregion

		#region IWrapper Member
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"FAMi Wrapper",
				"Quaxi",
				"This File contains Informations about one Sim Family.",
				7,
				Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.fami.png")
				)
			);
		}

		protected override string GetResourceName(FileTypeInformation fti)
		{
			if (!Processed)
			{
				ProcessData(FileDescriptor, Package);
			}

			return Name;
		}

		#endregion

		#region IPackedFileWrapper Member

		public FileTypes[] AssignableTypes => new FileTypes[] { FileTypes.FAMI };

		public byte[] FileSignature => new byte[] { (byte)'I', (byte)'M', (byte)'A', (byte)'F' };

		#endregion
	}
}
