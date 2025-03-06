// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections;

using SimPe.Data;
using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Idno
{

	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class Idno : AbstractWrapper, IFileWrapper, IFileWrapperSaveExtension
	{
		#region Attributes
		/// <summary>
		/// Returns the Version of this File
		/// </summary>
		public NeighborhoodVersion Version
		{
			get;
			private set;
		}

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
		public NeighborhoodEP Reqep
		{
			get; set;
		}

		/// <summary>
		/// Returns the affiliated EP of this Neighbourhood
		/// </summary>
		public NeighborhoodEP Subep
		{
			get; set;
		}

		/// <summary>
		/// Returns the 1st season qaudrant of this Neighbourhood
		/// </summary>
		public NeighborhoodSeason Quada
		{
			get; set;
		}

		/// <summary>
		/// Returns the 2nd season qaudrant of this Neighbourhood
		/// </summary>
		public NeighborhoodSeason Quadb
		{
			get; set;
		}

		/// <summary>
		/// Returns the 3rd season qaudrant of this Neighbourhood
		/// </summary>
		public NeighborhoodSeason Quadc
		{
			get; set;
		}

		/// <summary>
		/// Returns the 4th season qaudrant of this Neighbourhood
		/// </summary>
		public NeighborhoodSeason Quadd
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

		private byte[] over;
		#endregion

		#region static Methods
		/// <summary>
		/// Load the IdNo stored in the passed package
		/// </summary>
		/// <param name="pkg"></param>
		/// <returns></returns>
		public static Idno FromPackage(Interfaces.Files.IPackageFile pkg)
		{
			if (pkg == null)
			{
				return null;
			}

			Interfaces.Files.IPackedFileDescriptor idno = pkg.FindFile(
				FileTypes.IDNO,
				0,
				MetaData.LOCAL_GROUP,
				1
			);
			if (idno != null)
			{
				Idno wrp = new Idno();
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
			if (idno == null || filename == null)
			{
				return;
			}

			filename = filename.Trim().ToLower();

			idno.Uid = ids.ContainsKey(filename) ? (uint)ids[filename] : 1;

			uint max = 0;
			foreach (string flname in ids.Keys)
			{
				uint id = (uint)ids[flname];
				if (id > max)
				{
					max = id;
				}

				if (flname == filename)
				{
					continue;
				}

				if (idno.Uid == id)
				{
					idno.Uid = max + 1;
				}
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
			{
				return null;
			}

			if (!parts[0].StartsWith("N"))
			{
				return null;
			}

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
		private static void FindUids(string folder, Hashtable ids, bool scanall)
		{
			Wait.Message = folder;

			ArrayList names = new ArrayList();
			if (!scanall)
			{
				string[] a = System.IO.Directory.GetFiles(
					folder,
					"N???_Neighborhood.package"
				);
				foreach (string s in a)
				{
					names.Add(s);
				}

				a = System.IO.Directory.GetFiles(folder, "N???_University???.package");
				foreach (string s in a)
				{
					names.Add(s);
				}
			}
			else
			{
				string[] a = System.IO.Directory.GetFiles(folder, "*.package");
				foreach (string s in a)
				{
					names.Add(s);
				}
			}

			foreach (string name in names)
			{
				Packages.File fl = Packages.File.LoadFromFile(name);
				Interfaces.Files.IPackedFileDescriptor[] pfds = fl.FindFiles(
					FileTypes.IDNO
				);
				foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
				{
					Idno idno = new Idno();
					idno.ProcessData(pfd, fl);

					ids[name.Trim().ToLower()] = idno.Uid;
				}
			}

			string[] d = System.IO.Directory.GetDirectories(folder, "*");
			foreach (string dir in d)
			{
				FindUids(dir, ids, scanall);
			}
		}
		#endregion

		/// <summary>
		/// Make sure this contains a Unique ID!
		/// </summary>
		public void MakeUnique()
		{
			Wait.SubStart();
			MakeUnique(this, Package.FileName, true);
			Wait.SubStop();
		}

		/// <summary>
		/// Make sure this contains a Unique ID!
		/// </summary>
		/// <param name="ids">a Map of all available Group Ids (can be obtained by calling Idno::FindUids())</param>
		public void MakeUnique(Hashtable ids)
		{
			Wait.SubStart();
			MakeUnique(this, Package.FileName, ids);
			Wait.SubStop();
		}

		/// <summary>
		/// Constructor
		/// </summary>
		public Idno() : base()
		{
			Version = PathProvider.Global.EPInstalled >= 1 ? NeighborhoodVersion.Sims2_University : NeighborhoodVersion.Sims2;

			Type = NeighborhoodType.Normal;
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
					GetType()
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
			Version = (NeighborhoodVersion)reader.ReadUInt32();
			int ct = reader.ReadInt32();
			OwnerName = Helper.ToString(reader.ReadBytes(ct));
			Uid = reader.ReadUInt32();

			if (Version >= NeighborhoodVersion.Sims2_University)
			{
				Type = (NeighborhoodType)reader.ReadUInt32();
				Subtype = reader.ReadUInt32();
				if (Subtype > 0)
				{
					SubName = Helper.ToString(reader.ReadBytes((int)Subtype)); // CJH - was ReadBytes(ct) -ct is parent name length -EndOfStream error when ct is longer than 4 chars
				}

				if (Version >= NeighborhoodVersion.Sims2_Seasons)
				{
					_ = reader.ReadInt32();
					Reqep = (NeighborhoodEP)reader.ReadUInt32();
					Subep = (NeighborhoodEP)reader.ReadUInt32();
					Idflags = reader.ReadUInt32();
					Quada = (NeighborhoodSeason)reader.ReadByte();
					Quadb = (NeighborhoodSeason)reader.ReadByte();
					Quadc = (NeighborhoodSeason)reader.ReadByte();
					Quadd = (NeighborhoodSeason)reader.ReadByte();
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
			writer.Write((uint)Version);

			byte[] b = Helper.ToBytes(OwnerName, 0);
			writer.Write(b.Length);
			writer.Write(b);
			writer.Write(Uid);

			if (Version >= NeighborhoodVersion.Sims2_University)
			{
				writer.Write((uint)Type);
				if (Subtype > 0)
				{
					b = Helper.ToBytes(SubName, 0);
					writer.Write(b.Length);
					writer.Write(b);
				}
				else
				{
					writer.Write((int)Subtype);
				}

				if (Version >= NeighborhoodVersion.Sims2_Seasons)
				{
					writer.Write(0);
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
		public FileTypes[] AssignableTypes => new FileTypes[] { FileTypes.IDNO };

		#endregion
	}
}
