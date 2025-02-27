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
using System;
using System.Collections;

using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	/// <summary>
	/// Available Neighbourhood Types
	/// </summary>
	public enum NeighborhoodType : uint
	{
		Unknown = 0x00,
		Normal = 0x01,
		University = 0x02,
		Downtown = 0x03,
		Suburb = 0x04,
		Village = 0x05,
		Lakes = 0x06,
		Island = 0x07,
		Custom = 0x08,
	}

	/// <summary>
	/// Available EPs
	/// </summary>
	public enum NeighbourhoodEP : uint
	{
		None = 0x00,
		University = 0x01,
		Nightlife = 0x02,
		Business = 0x03,
		FamilyFun = 0x04,
		GlamourLife = 0x05,
		Pets = 0x06,
		Seasons = 0x07,
		Celebration = 0x08,
		Fashion = 0x09,
		BonVoyage = 0x0a,
		TeenStyle = 0x0b,
		StoreEdition_old = 0x0c,
		Freetime = 0x0d,
		KitchenBath = 0x0e,
		IkeaHome = 0x0f,
		ApartmentLife = 0x10,
		MansionGarden = 0x11,
		StoreEdition = 0x1f,
	}

	/// <summary>
	/// Known Neighborhhod Versions
	/// </summary>
	public enum NeighborhoodVersion : uint
	{
		Unknown = 0x00,
		Sims2 = 0x03,
		Sims2_University = 0x05,
		Sims2_Nightlife = 0x07,
		Sims2_Business = 0x08,
		Sims2_Pets = 0x09,
		Sims2_Seasons = 0x0A,
	}

	/// <summary>
	/// Available Seasons
	/// </summary>
	public enum NhSeasons : byte
	{
		Spring = 0,
		Summer = 1,
		Autumn = 2,
		Winter = 3,
	}

	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class Idno
		: AbstractWrapper //Implements some of the default Behaviur of a Handler, you can Implement yourself if you want more flexibility!
			,
			IFileWrapper //This Interface is used when loading a File
			,
			IFileWrapperSaveExtension //This Interface (if available) will be used to store a File
									  //,IPackedFileProperties		//This Interface can be used by thirdparties to retrive the FIleproperties, however you don't have to implement it!
	{
		#region Attributes
		uint version;

		/// <summary>
		/// Returns the Version of this File
		/// </summary>
		public NeighborhoodVersion Version => (NeighborhoodVersion)version;

		/// <summary>
		/// Returns the Type of this Neighbourhood
		/// </summary>
		public NeighborhoodType Type
		{
			get; set;
		}

		/// <summary>
		/// Returns the required EP of this Neighbourhood
		/// </summary>
		public Data.MetaData.NeighbourhoodEP Reqep
		{
			get; set;
		}

		/// <summary>
		/// Returns the affiliated EP of this Neighbourhood
		/// </summary>
		public Data.MetaData.NeighbourhoodEP Subep
		{
			get; set;
		}

		/// <summary>
		/// Returns the 1st season qaudrant of this Neighbourhood
		/// </summary>
		public NhSeasons Quada
		{
			get; set;
		}

		/// <summary>
		/// Returns the 2nd season qaudrant of this Neighbourhood
		/// </summary>
		public NhSeasons Quadb
		{
			get; set;
		}

		/// <summary>
		/// Returns the 3rd season qaudrant of this Neighbourhood
		/// </summary>
		public NhSeasons Quadc
		{
			get; set;
		}

		/// <summary>
		/// Returns the 4th season qaudrant of this Neighbourhood
		/// </summary>
		public NhSeasons Quadd
		{
			get; set;
		}

		/// <summary>
		/// Returns the nametag of this Neighbourhood
		/// </summary>
		public string OwnerName
		{
			get; set;
		}

		/// <summary>
		/// Returns the UID of this owning Neighbourhood
		/// </summary>
		public uint Uid
		{
			get; set;
		}

		/// <summary>
		/// Returns the flag settings of this Neighbourhood
		/// </summary>
		public uint Idflags
		{
			get; set;
		}

		/// <summary>
		/// Returns the subtype of this Neighbourhood
		/// </summary>
		public uint Subtype
		{
			get; set;
		}

		/// <summary>
		/// Returns the nametag of this Neighbourhood
		/// </summary>
		public string SubName
		{
			get; set;
		}

		byte[] over;
		#endregion

		#region static Methods
		/// <summary>
		/// Load the IdNo stored in the passed package
		/// </summary>
		/// <param name="pkg"></param>
		/// <returns></returns>
		public static Idno FromPackage(SimPe.Interfaces.Files.IPackageFile pkg)
		{
			if (pkg == null)
				return null;
			Interfaces.Files.IPackedFileDescriptor idno = pkg.FindFile(
				Data.MetaData.IDNO,
				0,
				Data.MetaData.LOCAL_GROUP,
				1
			);
			if (idno != null)
			{
				SimPe.Plugin.Idno wrp = new Idno();
				wrp.ProcessData(idno, pkg);

				return wrp;
			}

			return null;
		}

		/// <summary>
		/// Assigns a unique uid to the idno
		/// </summary>
		/// <param name="idno">the idno object</param>
		/// <param name="filename">the Filename</param>
		/// <param name="scanall">
		///   true, if you want to scan all package Files in the Folder
		///   (otherwise only Neighbourhood Files are scanned!)
		///  </param>
		/// <remarks>
		/// </remarks>
		public static void MakeUnique(Idno idno, string filename, bool scanall)
		{
			MakeUnique(idno, filename, PathProvider.SimSavegameFolder, scanall);
		}

		/// <summary>
		/// Assigns a unique uid to the idno and breaks neighbourhood story
		/// </summary>
		/// <param name="idno">the idno object</param>
		/// <param name="filename">the Filename</param>
		/// <param name="folder">The folder you want to scan (recursive)</param>
		/// <param name="scanall">
		///   true, if you want to scan all package Files in the Folder
		///   (otherwise only Neighbourhood Files are scanned!)
		///  </param>
		/// <remarks>
		/// </remarks>
		public static void MakeUnique(
			Idno idno,
			string filename,
			string folder,
			bool scanall
		)
		{
			Hashtable ids = FindUids(PathProvider.SimSavegameFolder, scanall);
			MakeUnique(idno, filename, ids);
		}

		/// <summary>
		/// Assigns a unique uid to the idno and breaks neighbourhood story
		/// </summary>
		/// <param name="idno">the idno object</param>
		/// <param name="filename">the Filename</param>
		/// <param name="ids">a Map of all available Group Ids (can be obtained by calling Idno::FindUids())</param>
		/// <remarks>
		/// </remarks>
		public static void MakeUnique(Idno idno, string filename, Hashtable ids)
		{
			if (idno == null)
				return;
			if (filename == null)
				return;

			filename = filename.Trim().ToLower();

			if (ids.ContainsKey(filename))
				idno.Uid = (uint)ids[filename];
			else
				idno.Uid = 1;

			uint max = 0;
			foreach (string flname in ids.Keys)
			{
				uint id = (uint)ids[flname];
				if (id > max)
					max = id;

				if (flname == filename)
					continue;
				if (idno.Uid == id)
					idno.Uid = max + 1;
			}
		}

		/// <summary>
		/// Returns a Idno Object based on the Informations gathered from a FileName
		/// </summary>
		/// <param name="filename">The name of the Neighbourhood File</param>
		/// <returns>
		/// null if the filename was not a valid Neighbourhood name or an instance of the Idno Class
		/// </returns>
		/// <remarks>
		/// This Method will not assign a uid to the Idno. You can assign a unique uid
		/// by calling Idno::MakeUnique
		/// </remarks>
		public static Idno FromName(string filename)
		{
			Idno idno = new Idno();

			filename = System.IO.Path.GetFileNameWithoutExtension(filename.Trim());
			string[] parts = filename.Split("_".ToCharArray(), 2);

			if (parts.Length != 2)
				return null;
			if (!parts[0].StartsWith("N"))
				return null;

			idno.OwnerName = parts[0];

			parts[1] = parts[1].ToLower();
			if (parts[1].StartsWith("university"))
			{
				idno.Type = NeighborhoodType.University;
				parts[1] = "U" + parts[1].Replace("university", "");
				idno.SubName = parts[1];
			}
			return idno;
		}

		/// <summary>
		/// Scan the passed Folder for Neighbourhood Files and collect the assigned IDs
		/// </summary>
		/// <param name="folder">The Folder to scan (recursive)</param>
		/// <param name="scanall">
		///   true, if you want to scan all package Files in the Folder
		///   (otherwise only Neighbourhood Files are scanned!)
		///  </param>
		/// <returns>A Map for ids (key=filename, value=id)</returns>
		public static Hashtable FindUids(string folder, bool scanall)
		{
			Hashtable ids = new Hashtable();
			FindUids(folder, ids, scanall);
			return ids;
		}

		/// <summary>
		/// Scan the passed Folder for Neighbourhood Files and collect the assigned IDs
		/// </summary>
		/// <param name="folder">The Folder to scan (recursive)</param>
		/// <param name="ids">A Map for ids (key=filename, value=id)</param>
		/// <param name="scanall">
		///   true, if you want to scan all package Files in the Folder
		///   (otherwise only Neighbourhood Files are scanned!)
		///  </param>
		static void FindUids(string folder, Hashtable ids, bool scanall)
		{
			Wait.Message = (folder);

			ArrayList names = new ArrayList();
			if (!scanall)
			{
				string[] a = System.IO.Directory.GetFiles(
					folder,
					"N???_Neighborhood.package"
				);
				foreach (string s in a)
					names.Add(s);

				a = System.IO.Directory.GetFiles(folder, "N???_University???.package");
				foreach (string s in a)
					names.Add(s);
			}
			else
			{
				string[] a = System.IO.Directory.GetFiles(folder, "*.package");
				foreach (string s in a)
					names.Add(s);
			}

			foreach (string name in names)
			{
				SimPe.Packages.File fl = SimPe.Packages.File.LoadFromFile(name);
				SimPe.Interfaces.Files.IPackedFileDescriptor[] pfds = fl.FindFiles(
					Data.MetaData.IDNO
				);
				foreach (SimPe.Interfaces.Files.IPackedFileDescriptor pfd in pfds)
				{
					Idno idno = new Idno();
					idno.ProcessData(pfd, fl);

					ids[name.Trim().ToLower()] = idno.Uid;
				}
			}

			string[] d = System.IO.Directory.GetDirectories(folder, "*");
			foreach (string dir in d)
				FindUids(dir, ids, scanall);
		}
		#endregion

		/// <summary>
		/// Make sure this contains a Unique ID!
		/// </summary>
		public void MakeUnique()
		{
			Wait.SubStart();
			Idno.MakeUnique(this, this.Package.FileName, true);
			Wait.SubStop();
		}

		/// <summary>
		/// Make sure this contains a Unique ID!
		/// </summary>
		/// <param name="ids">a Map of all available Group Ids (can be obtained by calling Idno::FindUids())</param>
		public void MakeUnique(Hashtable ids)
		{
			Wait.SubStart();
			Idno.MakeUnique(this, this.Package.FileName, ids);
			Wait.SubStop();
		}

		/// <summary>
		/// Constructor
		/// </summary>
		public Idno()
			: base()
		{
			if (SimPe.PathProvider.Global.EPInstalled >= 1)
				this.version = (uint)NeighborhoodVersion.Sims2_University;
			else
				this.version = (uint)NeighborhoodVersion.Sims2;

			this.Type = NeighborhoodType.Normal;
			over = new byte[0];

			Uid = 0;
			OwnerName = "Nxxx";
			SubName = "";
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
			return new IdnoUI();
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Neighbourhood ID Wrapper",
				"Quaxi",
				"Contains the ID for this Neighbourhood. The Neighbourhood ID must be Unique for all packages the Game is loading.",
				4,
				System.Drawing.Image.FromStream(
					this.GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.idno.png")
				)
			);
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			version = reader.ReadUInt32();
			int ct = reader.ReadInt32();
			OwnerName = Helper.ToString(reader.ReadBytes(ct));
			Uid = reader.ReadUInt32();

			if (version >= (int)NeighborhoodVersion.Sims2_University)
			{
				Type = (NeighborhoodType)reader.ReadUInt32();
				Subtype = reader.ReadUInt32();
				if (Subtype > 0)
					SubName = Helper.ToString(reader.ReadBytes((int)Subtype)); // CJH - was ReadBytes(ct) -ct is parent name length -EndOfStream error when ct is longer than 4 chars
				if (version >= (int)NeighborhoodVersion.Sims2_Seasons)
				{
					ct = reader.ReadInt32();
					Reqep = (Data.MetaData.NeighbourhoodEP)reader.ReadUInt32();
					Subep = (Data.MetaData.NeighbourhoodEP)reader.ReadUInt32();
					Idflags = reader.ReadUInt32();
					Quada = (NhSeasons)reader.ReadByte();
					Quadb = (NhSeasons)reader.ReadByte();
					Quadc = (NhSeasons)reader.ReadByte();
					Quadd = (NhSeasons)reader.ReadByte();
				}
			}
			else
			{
				Type = NeighborhoodType.Normal;
			}
			over = reader.ReadBytes(
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
			writer.Write(version);

			byte[] b = Helper.ToBytes(OwnerName, 0);
			writer.Write((int)b.Length);
			writer.Write(b);
			writer.Write(Uid);

			if (version >= (int)NeighborhoodVersion.Sims2_University)
			{
				writer.Write((uint)Type);
				if (Subtype > 0)
				{
					b = Helper.ToBytes(SubName, 0);
					writer.Write((int)b.Length);
					writer.Write(b);
				}
				else
					writer.Write((int)Subtype);
				if (version >= (int)NeighborhoodVersion.Sims2_Seasons)
				{
					writer.Write((int)0);
					writer.Write((int)Reqep);
					writer.Write((int)Subep);
					writer.Write((int)Idflags);
					writer.Write((byte)Quada);
					writer.Write((byte)Quadb);
					writer.Write((byte)Quadc);
					writer.Write((byte)Quadd);
				}
			}
			writer.Write(over);
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
				uint[] types = { Data.MetaData.IDNO };
				return types;
			}
		}

		#endregion
	}
}
