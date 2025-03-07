// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Data;

namespace SimPe
{
	/// <summary>
	/// This class will build a virtual .package Resource containing all Lua Scripts
	/// </summary>
	public class ObjLuaLoader
	{
		static Packages.GeneratableFile pkg;

		/// <summary>
		/// Create the virtual Lua Package
		/// </summary>
		static void CreatePackge()
		{
			pkg = Packages.File.CreateNew();

			foreach (ExpansionItem ei in PathProvider.Global.Expansions)
			{
				if (ei.Flag.LuaFolders)
				{
					string path = System.IO.Path.Combine(
						ei.InstallFolder,
						"TSData/Res/ObjectScripts"
					);
					if (System.IO.Directory.Exists(path))
					{
						LoadFromFolder(path, "globalObjLua", true);
						LoadFromFolder(path, "ObjLua", false);
					}
				}
			}
		}

		/// <summary>
		/// Load availabe lua resources from the FileSystem
		/// </summary>
		/// <param name="dir">The directory you want to scan</param>
		/// <param name="ext">The fiel extension to check</param>
		/// <param name="global">true, if this is a global LUA</param>
		/// <remarks>Instance of the loaded resources will be the hash over the FeleName</remarks>
		static void LoadFromFolder(string dir, string ext, bool global)
		{
			if (!System.IO.Directory.Exists(dir))
			{
				return;
			}

			string[] fls = System.IO.Directory.GetFiles(dir, "*." + ext);
			foreach (string fl in fls)
			{
				string name = System.IO.Path.GetFileName(fl);
				System.IO.BinaryWriter bw = new System.IO.BinaryWriter(
					new System.IO.MemoryStream()
				);
				try
				{
					bw.Write(0);
					bw.Write(name.Length);
					bw.Write(Helper.ToBytes(name, name.Length));

					System.IO.FileStream fs = System.IO.File.Open(
						fl,
						System.IO.FileMode.Open
					);
					System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
					try
					{
						bw.Write(br.ReadBytes((int)br.BaseStream.Length));
					}
					finally
					{
						br.Close();
						br = null;
						fs.Close();
						fs.Dispose();
						fs = null;
					}

					br = new System.IO.BinaryReader(bw.BaseStream);
					br.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);

					FileTypes type = Data.FileTypes.OLUA;
					if (global)
					{
						type = Data.FileTypes.GLUA;
					}

					Interfaces.Files.IPackedFileDescriptor pfd =
						pkg.NewDescriptor(
							type,
							Hashes.SubTypeHash(name),
							Data.MetaData.LOCAL_GROUP,
							Hashes.InstanceHash(name)
						);

					pfd.UserData = br.ReadBytes((int)br.BaseStream.Length);
					pfd.Changed = false;
					pkg.Add(pfd);
				}
				finally
				{
					bw.Close();
				}
			}
		}

		/// <summary>
		/// Returns a virtual Package, containing LUA Resources
		/// </summary>
		public static Packages.GeneratableFile VirtualPackage
		{
			get
			{
				if (pkg == null)
				{
					CreatePackge();
				}

				return pkg;
			}
		}
	}
}
