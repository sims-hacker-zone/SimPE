// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using SimPe.Data;
using SimPe.Interfaces.Files;
using SimPe.Interfaces.Plugin;
using SimPe.Packages;
using SimPe.PackedFiles.Mmat;
using SimPe.PackedFiles.Str;

namespace SimPe.Plugin
{
	/// <summary>
	/// Determins the basic Settings for the <see cref="ObjectCloner"/>.
	/// </summary>
	public class CloneSettings
	{
		public class StrIntsanceAlias : Data.Alias
		{
			internal StrIntsanceAlias(uint inst, FileTypes type, string ext)
				: base(inst, ext, new object[] { type }) { }

			public FileTypes Type => (FileTypes)Tag[0];

			public uint Instance => Id;

			public string Extension => Name;
		}

		public enum BaseResourceType : byte
		{
			Objd = 0x01,
			Ref = 0x02,
			Xml = 0x04,
		}

		/// <summary>
		/// true, if you want to load Files referenced by 3IDR Resoures
		/// </summary>
		public BaseResourceType BaseResource
		{
			get; set;
		}

		/// <summary>
		/// true, if you do not want to include the Mesh Data into the package
		/// </summary>
		public bool KeepOriginalMesh
		{
			get; set;
		}

		/// <summary>
		/// true, if the clone should include Wallmasks
		/// </summary>
		public bool IncludeWallmask
		{
			get; set;
		}

		/// <summary>
		/// true if you only want default MMAT Files
		/// </summary>
		public bool OnlyDefaultMmats
		{
			get; set;
		}

		/// <summary>
		/// update the GUIDs in the MMAT Files
		/// </summary>
		public bool UpdateMmatGuids
		{
			get; set;
		}

		/// <summary>
		/// true if you want to throw an exception when something goes wrong
		/// </summary>
		public bool ThrowExceptions
		{
			get; set;
		}

		/// <summary>
		/// true if Animation Resources should be included in the package
		/// </summary>
		public bool IncludeAnimationResources
		{
			get; set;
		}

		/// <summary>
		/// The INstances of StrResources, that can contain valid Links to Scenegraph Resources
		/// </summary>
		public StrIntsanceAlias[] StrInstances
		{
			get; set;
		}

		/// <summary>
		/// If true, SimPe will check all Str resources with the instance listed in <see cref="PullFromStrInstances"/>
		/// and pull all Resources linked from there too
		/// </summary>
		public bool PullResourcesByStr
		{
			get; set;
		}

		/// <summary>
		/// Create a new Instance and set everything to default
		/// </summary>
		public CloneSettings()
		{
			StrInstances = new StrIntsanceAlias[]
			{
				new StrIntsanceAlias(0x88, FileTypes.TXMT, "_txmt"),
			};
			PullResourcesByStr = true;
			IncludeWallmask = true;
			ThrowExceptions = true;
			UpdateMmatGuids = true;
			OnlyDefaultMmats = true;
			IncludeAnimationResources = false;
			KeepOriginalMesh = false;
			BaseResource = BaseResourceType.Objd;
		}
	}

	/// <summary>
	/// This Class provides Methods to clone ingame Objects
	/// </summary>
	public class ObjectCloner
	{
		/// <summary>
		/// The Base Package
		/// </summary>
		public IPackageFile Package
		{
			get;
		}

		/// <summary>
		/// The Settings for this Cloner
		/// </summary>
		public CloneSettings Setup
		{
			get; set;
		}

		/// <summary>
		/// Creates a new Isntance based on an existing Package
		/// </summary>
		/// <param name="package">The Package that should receive the Clone</param>
		public ObjectCloner(IPackageFile package)
		{
			Package = package;
			Setup = new CloneSettings();
		}

		/// <summary>
		/// Creates a new Instance and a new Package
		/// </summary>
		public ObjectCloner()
		{
			Package = File.LoadFromStream(null);
			Setup = new CloneSettings();
		}

		/// <summary>
		/// Find the second MMAT that matches the state
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public static IPackedFileDescriptor[] FindStateMatchingMatd(
			string name,
			IPackageFile package
		)
		{
			IPackedFileDescriptor[] pfds = null;

			//railingleft1 railingleft2 railingleft3 railingleft4
			if (name.EndsWith("_clean"))
			{
				name = name.Substring(0, name.Length - 6) + "_dirty";
				pfds = package.FindFile(name + "_txmt", FileTypes.TXMT);
			}
			else if (name.EndsWith("_dirty"))
			{
				name = name.Substring(0, name.Length - 6) + "_clean";
				pfds = package.FindFile(name + "_txmt", FileTypes.TXMT);
			}
			else if (name.EndsWith("_lit"))
			{
				name = name.Substring(0, name.Length - 4) + "_unlit";
				pfds = package.FindFile(name + "_txmt", FileTypes.TXMT);
			}
			else if (name.EndsWith("_unlit"))
			{
				name = name.Substring(0, name.Length - 6) + "_lit";
				pfds = package.FindFile(name + "_txmt", FileTypes.TXMT);
			}
			else if (name.EndsWith("_on"))
			{
				name = name.Substring(0, name.Length - 3) + "_off";
				pfds = package.FindFile(name + "_txmt", FileTypes.TXMT);
			}
			else if (name.EndsWith("_off"))
			{
				name = name.Substring(0, name.Length - 4) + "_on";
				pfds = package.FindFile(name + "_txmt", FileTypes.TXMT);
			}
			else if (name.EndsWith("_shadeinside"))
			{
				name = name.Substring(0, name.Length - 4) + "_shadeoutside";
				pfds = package.FindFile(name + "_txmt", FileTypes.TXMT);
			}
			else if (name.EndsWith("_shadeoutside"))
			{
				name = name.Substring(0, name.Length - 4) + "_shadeinside";
				pfds = package.FindFile(name + "_txmt", FileTypes.TXMT);
			}
			return pfds;
		}

		/// <summary>
		/// Returns the Primary Guid of the Object
		/// </summary>
		/// <returns>0 or the default guid</returns>
		public uint GetPrimaryGuid()
		{
			uint guid = 0;
			IPackedFileDescriptor[] pfds = Package.FindFile(
				FileTypes.OBJD,
				0,
				0x41A7
			);
			if (pfds.Length == 0)
			{
				pfds = Package.FindFiles(FileTypes.OBJD);
			}

			if (pfds.Length > 0)
			{
				guid = new PackedFiles.Objd.ExtObjd().ProcessFile(pfds[0], Package).Guid;
			}
			return guid;
		}

		/// <summary>
		/// Load a List of all available GUIDs in the package
		/// </summary>
		/// <returns>The list of GUIDs</returns>
		// public IEnumerable<uint> GetGuidList()
		// {
		// 	return from pfd in Package.FindFiles(FileTypes.OBJD)
		// 		   select new PackedFiles.Wrapper.ExtObjd().ProcessFile(pfd, Package).Guid;
		// }

		/// <summary>
		/// Updates the MMATGuids
		/// </summary>
		/// <param name="guids">list of allowed GUIDS</param>
		/// <param name="primary">the guid you want to use if the guid was not allowed</param>
		// public void UpdateMMATGuids(IEnumerable<uint> guids, uint primary)
		// {
		// 	if (primary == 0)
		// 	{
		// 		return;
		// 	}

		// 	IPackedFileDescriptor[] pfds = Package.FindFiles(
		// 		FileTypes.MMAT
		// 	);

		// 	foreach (IPackedFileDescriptor pfd in pfds)
		// 	{
		// 		MmatWrapper mmat = new MmatWrapper();
		// 		mmat.ProcessData(pfd, Package);

		// 		//this seems to cause problems with slave Objects
		// 		/*if (!guids.Contains(mmat.ObjectGUID))
		// 		{
		// 			mmat.ObjectGUID = primary;
		// 			mmat.SynchronizeUserData();
		// 		}*/
		// 	}
		// }

		/// <summary>
		/// Clone a InGame Object based on the relations of the RCOL Files
		/// </summary>
		/// <param name="modelname">The Name of the Model</param>
		/// <param name="onlydefault">true if you want to load Parent Objects</param>
		public void RcolModelClone(string modelname)
		{
			if (modelname == null)
			{
				return;
			}
			RcolModelClone(new List<string> { modelname });
		}

		/// <summary>
		/// Clone a InGame Object based on the relations of the RCOL Files
		/// </summary>
		/// <param name="modelnames">The Name of the Model</param>
		/// <param name="onlydefault">true if you only want default MMAT Files</param>
		public void RcolModelClone(List<string> modelnames)
		{
			RcolModelClone(modelnames, new ArrayList());
		}

		/// <summary>
		/// Returns a List of all stored Anim Resources
		/// </summary>
		/// <param name="instances">Instances of TextLists that should be searched</param>
		/// <param name="ext">extension (in lowercase) that should be added (can be null for none)</param>
		/// <returns>List of found Names</returns>
		public IEnumerable<string> GetNames(IEnumerable<uint> instances, string ext)
		{
			HashSet<string> list = new HashSet<string>();

			foreach (IPackedFileDescriptor pfd in Package.FindFiles(FileTypes.STR))
			{
				if (instances.Contains(pfd.Instance))
				{
					foreach (StrToken si in new PackedFiles.Str.Str().ProcessFile(pfd, Package).Items)
					{
						string s = si.Title.Trim();
						if (s != "")
						{
							if (ext != null)
							{
								if (!s.ToLower().EndsWith(ext))
								{
									s += ext;
								}
							}
							list.Add(s);
						}
					}
				}
			}
			return list;
		}

		/// <summary>
		/// Returns a List of all stored Anim Resources
		/// </summary>
		/// <returns></returns>
		public IEnumerable<string> GetAnimNames()
		{
			return GetNames(new HashSet<uint> { 0x81, 0x82, 0x86, 0x192 }, "_anim");
		}

		/// <summary>
		/// Clone a InGane Object based on the relations of the RCOL Files
		/// </summary>
		/// <param name="onlydefault">true if you only want default MMAT Files</param>
		/// <param name="exclude">List of ReferenceNames that should be excluded</param>
		public void RcolModelClone(List<string> modelnames, ArrayList exclude)
		{
			if (modelnames == null)
			{
				return;
			}

			Scenegraph.FileExcludeList = Scenegraph.DefaultFileExcludeList;

			FileTableBase.FileIndex.Load();
			if (WaitingScreen.Running)
			{
				WaitingScreen.UpdateMessage("Walking Scenegraph");
			}

			Scenegraph sg = new Scenegraph(modelnames, exclude, Setup);
			if (
				(Setup.BaseResource & CloneSettings.BaseResourceType.Ref)
				== CloneSettings.BaseResourceType.Ref
			)
			{
				if (WaitingScreen.Running)
				{
					WaitingScreen.UpdateMessage("Reading 3IDR References");
				}

				sg.AddFrom3IDR(Package);
			}
			if (
				(Setup.BaseResource & CloneSettings.BaseResourceType.Xml)
				== CloneSettings.BaseResourceType.Xml
			)
			{
				if (WaitingScreen.Running)
				{
					WaitingScreen.UpdateMessage("Reading XObject Definition");
				}

				sg.AddFromXml(Package);
			}
			if (Setup.IncludeWallmask)
			{
				if (WaitingScreen.Running)
				{
					WaitingScreen.UpdateMessage("Scanning for Wallmasks");
				}

				sg.AddWallmasks(modelnames);
			}
			if (Setup.PullResourcesByStr)
			{
				if (WaitingScreen.Running)
				{
					WaitingScreen.UpdateMessage("Scanning for #Str-linked Resources");
				}

				sg.AddStrLinked(Package, Setup.StrInstances);
			}
			if (Setup.IncludeAnimationResources)
			{
				if (WaitingScreen.Running)
				{
					WaitingScreen.UpdateMessage("Scanning for Animations");
				}

				sg.AddAnims(GetAnimNames());
			}
			if (WaitingScreen.Running)
			{
				WaitingScreen.UpdateMessage("Collect Slave TXMTs");
			}

			sg.AddSlaveTxmts(sg.GetSlaveSubsets());

			if (WaitingScreen.Running)
			{
				WaitingScreen.UpdateMessage("Building Package");
			}

			sg.BuildPackage(Package);
			if (WaitingScreen.Running)
			{
				WaitingScreen.UpdateMessage("Collect MMAT Files");
			}

			sg.AddMaterialOverrides(
				Package,
				Setup.OnlyDefaultMmats,
				true,
				Setup.ThrowExceptions
			);
			if (WaitingScreen.Running)
			{
				WaitingScreen.UpdateMessage("Collect Slave TXMTs");
			}

			Scenegraph.AddSlaveTxmts(Package, Scenegraph.GetSlaveSubsets(Package));

			if (Setup.UpdateMmatGuids)
			{
				if (WaitingScreen.Running)
				{
					WaitingScreen.UpdateMessage("Fixing MMAT Files");
				}

				// UpdateMMATGuids(GetGuidList(), GetPrimaryGuid()); // TODO(autinerd): This function doesn't do anything
			}
		}

		/// <summary>
		/// Add all Files that could be borrowed from the current package by the passed one, to the passed package
		/// </summary>
		/// <param name="orgmodelnames">List of available modelnames in this package</param>
		/// <param name="pkg">The package that should receive the Files</param>
		/// <remarks>Simply Copies MMAT, LIFO, TXTR and TXMT Files</remarks>
		public void AddParentFiles(
			IEnumerable<string> orgmodelnames,
			IPackageFile pkg
		)
		{
			if (WaitingScreen.Running)
			{
				WaitingScreen.UpdateMessage("Loading Parent Files");
			}

			List<string> names = new List<string>();
			foreach (string s in orgmodelnames)
			{
				names.Add(s);
			}


			foreach (FileTypes type in new List<FileTypes>
			{
				FileTypes.MMAT,
				FileTypes.TXMT,
				FileTypes.TXTR,
				FileTypes.LIFO
			})
			{
				IPackedFileDescriptor[] pfds = Package.FindFiles(
					type
				);
				foreach (IPackedFileDescriptor pfd in pfds)
				{
					if (pkg.FindFile(pfd) != null)
					{
						continue;
					}

					IPackedFile file = Package.Read(pfd);
					pfd.UserData = file.UncompressedData;

					//Update the modeName in the MMAT
					if ((pfd.Type == FileTypes.MMAT) && (names.Count > 0))
					{
						MmatWrapper mmat = new MmatWrapper().ProcessFile(pfd, Package);

						string n = mmat.ModelName.Trim().ToLower();
						if (!n.EndsWith("_cres"))
						{
							n += "_cres";
						}

						if (!names.Contains(n))
						{
							n = names[0].ToString();
							//n = n.Substring(0, n.Length-5);
							mmat.ModelName = n;
							mmat.SynchronizeUserData();
						}
					}

					pkg.Add(pfd);
				}
			} //foreach type
		}

		/// <summary>
		/// Remove all Files that are referenced by a SHPE and belong to a subset as named in the esclude List
		/// </summary>
		/// <param name="exclude">List of subset names</param>
		/// <param name="modelnames">null or a List of allowed Modelnames. If a List is passed, only references to files
		/// starting with one of the passed Modelnames will be keept</param>
		public void RemoveSubsetReferences(ArrayList exclude, IEnumerable<string> modelnames)
		{
			if (WaitingScreen.Running)
			{
				WaitingScreen.UpdateMessage("Removing unwanted Subsets");
			}
			//Build the ModelName List
			ArrayList mn = new ArrayList();
			if (modelnames != null)
			{
				foreach (string s in modelnames)
				{
					string n = s;
					if (s.EndsWith("_cres"))
					{
						n = s.Substring(0, s.Length - 5);
					}

					mn.Add(n);
				}
			}

			bool deleted = false;
			IPackedFileDescriptor[] pfds = Package.FindFiles(
				FileTypes.SHPE
			);
			foreach (IPackedFileDescriptor pfd in pfds)
			{
				Rcol rcol = new GenericRcol(null, false).ProcessFile(pfd, Package);

				foreach (ShapePart p in ((Shape)rcol.Blocks[0]).Parts)
				{
					string s = p.Subset.Trim().ToLower();
					bool remove = exclude.Contains(s);

					if ((modelnames != null) && !remove)
					{
						remove = true;
						string fl = p.FileName.Trim().ToLower();
						foreach (string n in mn)
						{
							if (fl.StartsWith(n))
							{
								remove = false;
								continue;
							}
						}
					}

					if (remove)
					{
						string n = p.FileName.Trim().ToLower();
						if (!n.EndsWith("_txmt"))
						{
							n += "_txmt";
						}

						List<IPackedFileDescriptor> names = new List<IPackedFileDescriptor>();
						foreach (IPackedFileDescriptor rpfd in Package.FindFile(n, FileTypes.TXMT))
						{
							names.Add(rpfd);
						}

						int pos = 0;
						while (pos < names.Count)
						{
							IPackedFileDescriptor rpfd = names[pos++];
							rpfd = Package.FindFile(rpfd);

							if (rpfd != null)
							{
								rpfd.MarkForDelete = true;
								deleted = true;

								names.AddRange((from items in new GenericRcol(null, false).ProcessFile(rpfd, Package).ReferenceChains.Values
												from lpfd in items
												where !names.Contains(lpfd)
												select lpfd).ToArray());
							}
						} //while
					}
				} //foreach p
			} //foreach SHPE

			//now remova all deleted Files from the Index
			if (deleted)
			{
				Package.RemoveMarked();
			}
		}
	}
}
