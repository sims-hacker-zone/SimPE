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

namespace SimPe.Providers
{
	/// <summary>
	/// Provides an Alias Matching a SimID with it's Name
	/// </summary>
	public class Skins : SimCommonPackage, Interfaces.Providers.ISkinProvider
	{
		/// <summary>
		/// List of known Opcode Names
		/// </summary>
		private ArrayList sets;

		/// <summary>
		/// List of known Opcode Names
		/// </summary>
		private ArrayList matds;

		/// <summary>
		/// List of known Opcode Names
		/// </summary>
		private ArrayList refs;

		/// <summary>
		/// Available Textures
		/// </summary>
		private Hashtable txtrs;

		/// <summary>
		/// Creates the List for the specific Folder
		/// </summary>
		public Skins()
			: base(null) { }

		protected void LoadSkinFormPackage(Interfaces.Files.IPackageFile package)
		{
			Interfaces.Files.IPackedFileDescriptor[] pfds = package.FindFiles(
				0xEBCF3E27
			);

			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				try
				{
					PackedFiles.Wrapper.Cpf cpf =
						new PackedFiles.Wrapper.Cpf();
					cpf.ProcessData(pfd, package);
					sets.Add(cpf);
				}
				catch (Exception) { }
			}
		}

		protected void LoadSkinImageFormPackage(
			Interfaces.Files.IPackageFile package
		)
		{
			Interfaces.Files.IPackedFileDescriptor[] pfds = package.FindFiles(
				0xAC506764
			);
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				try
				{
					Plugin.RefFile reffile = new Plugin.RefFile();
					reffile.ProcessData(pfd, package);
					refs.Add(reffile);
				}
				catch (Exception) { }
			}

			pfds = package.FindFiles(0x49596978);
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				try
				{
					Plugin.Rcol matd = new Plugin.GenericRcol(null, true);
					matd.ProcessData(pfd, package);
					matds.Add(matd);
				}
				catch (Exception) { }
			}

			//Material Files
			Interfaces.Files.IPackedFileDescriptor[] nmap_pfd = package.FindFiles(
				Data.MetaData.NAME_MAP
			);
			pfds = package.FindFiles(0x49596978);
			Plugin.Nmap nmap = new Plugin.Nmap(null);
			if (nmap_pfd.Length > 0)
			{
				nmap.ProcessData(nmap_pfd[0], package);
			}

			bool check = false;

			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				try
				{
					Plugin.Rcol matd = new Plugin.GenericRcol(null, true);
					check = false;

					foreach (Interfaces.Files.IPackedFileDescriptor epfd in nmap.Items)
					{
						if (
							(epfd.Group == pfd.Group) && (epfd.Instance == pfd.Instance)
						)
						{
							matd.FileDescriptor = pfd;
							matd.Package = package;
							matds.Add(matd);
							check = true;
						}
					}

					//not found in the FileMap, so process Normally
					if (!check)
					{
						matd.ProcessData(pfd, package);
						matds.Add(matd);
					}
				}
				catch (Exception) { }
			}

			//Texture Files
			nmap_pfd = package.FindFiles(Data.MetaData.NAME_MAP);
			pfds = package.FindFiles(0x1C4A276C);
			check = false;

			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				try
				{
					Plugin.Txtr txtr = new Plugin.Txtr(null, true);
					check = false;

					foreach (Interfaces.Files.IPackedFileDescriptor epfd in nmap.Items)
					{
						if (
							(epfd.Group == pfd.Group) && (epfd.Instance == pfd.Instance)
						)
						{
							txtr.FileDescriptor = pfd;
							txtr.Package = package;
							txtrs.Add(epfd.Filename, txtr);
							continue;
						}
					}

					//not found in the FileMap, so process Normally
					if (!check)
					{
						txtr.ProcessData(pfd, package);
						foreach (Plugin.ImageData id in txtr.Blocks)
						{
							txtrs.Add(id.NameResource.FileName.ToLower(), txtr);
						}
					}
				}
				catch (Exception) { }
			}
		}

		/// <summary>
		/// Loads available Skin Files
		/// </summary>
		protected void LoadSkins()
		{
			LoadPackage();

			sets = new ArrayList();
			LoadSkinFormPackage(BasePackage);
			LoadUserPackages();
		}

		/// <summary>
		/// Loads available Skin Files
		/// </summary>
		protected void LoadSkinImages()
		{
			LoadPackage();

			matds = new ArrayList();
			refs = new ArrayList();
			txtrs = new Hashtable();
			LoadUserImagePackages();
		}

		protected void LoadUserPackages()
		{
			string path = System.IO.Path.Combine(
				PathProvider.SimSavegameFolder,
				"Downloads"
			);
			if (!System.IO.Directory.Exists(path))
			{
				return;
			}

			string[] files = System.IO.Directory.GetFiles(path, "*.package");
			foreach (string file in files)
			{
				Packages.File package = Packages.File.LoadFromFile(file);
				LoadSkinFormPackage(package);
				//package.Reader.Close();
			}
		}

		protected void LoadUserImagePackages()
		{
			string path = System.IO.Path.Combine(
				PathProvider.SimSavegameFolder,
				"Downloads"
			);
			if (!System.IO.Directory.Exists(path))
			{
				return;
			}

			string[] files = System.IO.Directory.GetFiles(path, "*.package");
			foreach (string file in files)
			{
				Packages.File package = Packages.File.LoadFromFile(file);
				LoadSkinImageFormPackage(package);
				//package.Reader.Close();
			}
		}

		/// <summary>
		/// Loads the ObjectsPackage if not already loaded
		/// </summary>
		public void LoadPackage()
		{
			if (BasePackage == null)
			{
				Registry reg = Helper.WindowsRegistry;
				string file = System.IO.Path.Combine(
					PathProvider.Global.GetExpansion(Expansions.BaseGame).InstallFolder,
					"TSData\\Res\\Catalog\\Skins\\Skins.package"
				);
				if (System.IO.File.Exists(file))
				{
					BasePackage = Packages.File.LoadFromFile(file);
				}
				else
				{
					BasePackage = null;
				}
			}
		}

		/// <summary>
		/// Returns the Property Set (=cpf) of a Skin
		/// </summary>
		/// <param name="spfd">The File Description of the File you are looking for</param>
		/// <returns>null or the Property Set File</returns>
		public object FindSet(Interfaces.Files.IPackedFileDescriptor spfd)
		{
			if (sets == null)
			{
				LoadSkins();
			}

			if (sets == null)
			{
				return null;
			}

			foreach (PackedFiles.Wrapper.Cpf cpf in sets)
			{
				Interfaces.Files.IPackedFileDescriptor pfd = cpf.FileDescriptor;
				if (
					(pfd.Group == spfd.Group)
					&& (pfd.SubType == spfd.SubType)
					&& (pfd.Instance == spfd.Instance)
					&& (pfd.Type == spfd.Type)
				)
				{
					return cpf;
				}
			}

			return null;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="ocpf">The MMAT or Property Set describing the Model</param>
		/// <returns>The Texture or null</returns>
		public object FindTxtrName(object ocpf)
		{
			PackedFiles.Wrapper.Cpf cpf = (PackedFiles.Wrapper.Cpf)ocpf;
			PackedFiles.Wrapper.CpfItem item = cpf.GetSaveItem("name");

			if (cpf.Package != BasePackage)
			{
				string name = FindTxtrName(cpf.FileDescriptor);
				return FindUserTxtr(name);
			}
			else
			{
				string name = FindTxtrName(item.StringValue + "_txmt");
				return FindTxtr(name);
			}
		}

		/// <summary>
		/// Returns the Property Set (=cpf) of a Skin
		/// </summary>
		/// <param name="spfd">The File Description of the File you are looking for</param>
		/// <returns>null or the Property Set File</returns>
		public string FindTxtrName(string matdname)
		{
			if (matdname == null)
			{
				return null;
			}

			string file = System.IO.Path.Combine(
				PathProvider.Global[Expansions.BaseGame].InstallFolder,
				"TSData\\Res\\Sims3D\\Sims02.package"
			);

			if (System.IO.File.Exists(file))
			{
				Interfaces.Files.IPackageFile package =
					Packages.File.LoadFromFile(file);
				Interfaces.Files.IPackedFileDescriptor[] pfds = package.FindFile(
					matdname.Replace("CASIE_", ""),
					0x49596978
				);
				if (pfds.Length == 0)
				{
					pfds = package.FindFile(matdname, 0x49596978);
				}
				//try another Package
				//look for the right one
				foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
				{
					Plugin.Rcol rcol = new Plugin.GenericRcol(null, false);
					rcol.ProcessData(pfd, package);
					if (
						(rcol.FileName.Trim().ToLower() == matdname.Trim().ToLower())
						|| (
							rcol.FileName.Trim().ToLower()
							== matdname.Replace("CASIE_", "").Trim().ToLower()
						)
					)
					{
						foreach (Plugin.MaterialDefinition md in rcol.Blocks)
						{
							return md.GetProperty("stdMatBaseTextureName").Value
								+ "_txtr";
						}
					}
				}
			}
			return null;
		}

		public string FindTxtrName(Interfaces.Files.IPackedFileDescriptor spfd)
		{
			if (matds == null)
			{
				LoadSkinImages();
			}

			if (matds == null)
			{
				return "";
			}

			if (refs == null)
			{
				return "";
			}

			foreach (Plugin.RefFile reff in refs)
			{
				Interfaces.Files.IPackedFileDescriptor pfd = reff.FileDescriptor;
				if (
					(pfd.Group == spfd.Group)
					&& (pfd.SubType == spfd.SubType)
					&& (pfd.Instance == spfd.Instance)
				)
				{
					foreach (
						Interfaces.Files.IPackedFileDescriptor refpfd in reff.Items
					)
					{
						//found a MATD Reference File
						if (refpfd.Type == 0x49596978)
						{
							foreach (Plugin.Rcol matd in matds)
							{
								pfd = matd.FileDescriptor;
								if (
									(pfd.Group == refpfd.Group)
									&& (pfd.SubType == refpfd.SubType)
									&& (pfd.Instance == refpfd.Instance)
								)
								{
									foreach (
										Plugin.MaterialDefinition md in matd.Blocks
									)
									{
										return md.GetProperty(
											"stdMatBaseTextureName"
										).Value;
									}
								}
							}
						}
					} //foreach matd
				}
			}

			return "";
		}

		public object FindTxtr(string name)
		{
			if (name == null)
			{
				return null;
			}

			string file = System.IO.Path.Combine(
				PathProvider.Global[Expansions.BaseGame].InstallFolder,
				"TSData\\Res\\Sims3D\\Sims07.package"
			);
			if (System.IO.File.Exists(file))
			{
				Interfaces.Files.IPackageFile package =
					Packages.File.LoadFromFile(file);
				Interfaces.Files.IPackedFileDescriptor[] pfds = package.FindFile(
					name,
					0x1C4A276C
				);

				//look for the right one
				foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
				{
					Plugin.Txtr rcol = new Plugin.Txtr(null, false);
					rcol.ProcessData(pfd, package);
					if (rcol.FileName.Trim().ToLower() == name.Trim().ToLower())
					{
						return rcol;
					}
				}
			}

			return null;
		}

		public object FindUserTxtr(string name)
		{
			if (txtrs == null)
			{
				LoadSkinImages();
			}

			if (txtrs == null)
			{
				return null;
			}

			name = name.ToLower();
			Plugin.Txtr txtr = (Plugin.Txtr)txtrs[name];
			if (txtr == null)
			{
				txtr = (Plugin.Txtr)txtrs[name + "_txtr"];
			}

			if (txtr == null)
			{
				return null;
			}

			if (txtr.Fast)
			{
				txtr.Fast = false;
				Packages.File fl = Packages.File.LoadFromFile(
					txtr.Package.FileName
				);
				Interfaces.Files.IPackedFileDescriptor pfd = fl.FindFile(
					txtr.FileDescriptor.Type,
					txtr.FileDescriptor.SubType,
					txtr.FileDescriptor.Group,
					txtr.FileDescriptor.Instance
				);
				txtr.ProcessData(pfd, fl);
				//fl.Reader.Close();
			}

			return txtr;
		}

		/// <summary>
		/// Returns a list of all known memories
		/// </summary>
		public ArrayList StoredSkins
		{
			get
			{
				LoadPackage();
				if (sets == null)
				{
					LoadSkins();
				}

				return sets;
			}
		}

		/// <summary>
		/// Called if the BaseBackae was changed
		/// </summary>
		protected override void OnChangedPackage()
		{
			sets = null;
			matds = null;
			txtrs = null;
			refs = null;
		}
	}
}
