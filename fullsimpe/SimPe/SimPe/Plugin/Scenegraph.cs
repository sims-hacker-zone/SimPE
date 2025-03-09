// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using SimPe.Data;
using SimPe.Interfaces.Plugin;
using SimPe.Interfaces.Scenegraph;
using SimPe.PackedFiles.Cpf;
using SimPe.PackedFiles.Nmap;
using SimPe.PackedFiles.Str;
using SimPe.PackedFiles.ThreeIdr;

namespace SimPe.Plugin
{
	/// <summary>
	/// This class builds the SceneGraph Chain based on a modelname
	/// </summary>
	public class Scenegraph
	{
		/// <summary>
		/// A List of Files the SceneGraph will ignore when following a Reference
		/// </summary>
		public static List<string> FileExcludeList { get; set; } = new List<string>();

		/// <summary>
		/// The Default List for FileExcludeList
		/// </summary>
		public static List<string> DefaultFileExcludeList => new List<string>
				{
					"simple_mirror_reflection_txmt"
				};

		/// <summary>
		/// Contains the base Modelnames
		/// </summary>
		List<string> modelnames = new List<string>();

		/// <summary>
		/// Contains all found Files
		/// </summary>
		List<GenericRcol> files = new List<GenericRcol>();

		/// <summary>
		/// All loaded Items
		/// </summary>
		List<IScenegraphFileIndexItem> itemlist = new List<IScenegraphFileIndexItem>();

		/// <summary>
		/// Returns a List of a References that should be excluded
		/// </summary>
		public ArrayList ExcludedReferences
		{
			get; private set;
		}

		/// <summary>
		/// Create a clone of the Descriptor, so changes won't affect the source Package anymore!
		/// </summary>
		/// <param name="item">Clone the Descriptor in this Item</param>
		public static void Clone(IScenegraphFileIndexItem item)
		{
			Packages.PackedFileDescriptor pfd =
				new Packages.PackedFileDescriptor
				{
					Type = item.FileDescriptor.Type,
					Group = item.FileDescriptor.Group,
					LongInstance = item.FileDescriptor.LongInstance,

					Offset = item.FileDescriptor.Offset,
					Size = item.FileDescriptor.Size,

					UserData = item.FileDescriptor.UserData
				};

			item.FileDescriptor = pfd;
		}

		/// <summary>
		/// Create a clone of the Descriptor, so changes won't affect the source Package anymore!
		/// </summary>
		/// <param name="item">Clone the Descriptor in this Item</param>
		public static Packages.PackedFileDescriptor Clone(
			Interfaces.Files.IPackedFileDescriptor org
		)
		{
			Packages.PackedFileDescriptor pfd =
				new Packages.PackedFileDescriptor
				{
					Type = org.Type,
					Group = org.Group,
					LongInstance = org.LongInstance
				};

			return pfd;
		}

		/// <summary>
		/// Return all Modelnames that can be found in this package
		/// </summary>
		/// <param name="pkg">The Package you want to scan</param>
		/// <returns>a list of Modelnames</returns>
		public static List<string> FindModelNames(Interfaces.Files.IPackageFile pkg)
		{
			List<string> names = new List<string>();

			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pkg.FindFile(
				FileTypes.STR,
				0,
				0x85
			))
			{
				foreach (StrToken item in new PackedFiles.Str.Str().ProcessFile(pfd, pkg).Items)
				{
					string mname = Hashes.StripHashFromName(
						item.Title.Trim().ToLower()
					);
					if (!mname.EndsWith("_cres"))
					{
						mname += "_cres";
					}

					if ((mname != "") && (!names.Contains(mname)))
					{
						names.Add(mname);
					}
				}
			}

			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pkg.FindFiles(FileTypes.MMAT))
			{
				string mname = Hashes.StripHashFromName(
					new Cpf().ProcessFile(pfd, pkg).GetSaveItem("modelName").StringValue.Trim().ToLower()
				);
				if (!mname.EndsWith("_cres"))
				{
					mname += "_cres";
				}

				if ((mname != "") && (!names.Contains(mname)))
				{
					names.Add(mname);
				}
			}
			return names;
		}

		/// <summary>
		/// Load all pending CRES Files
		/// </summary>
		/// <param name="modelnames"></param>
		/// <returns></returns>
		protected List<IScenegraphFileIndexItem> LoadCres(List<string> modelnames)
		{
			List<IScenegraphFileIndexItem> cres = new List<IScenegraphFileIndexItem>();
			for (int i = 0; i < modelnames.Count; i++)
			{
				modelnames[i] = modelnames[i].Trim().ToLower();
				if (!modelnames[i].EndsWith("_cres"))
				{
					modelnames[i] += "_cres";
				}

				IScenegraphFileIndexItem item =
					FileTableBase.FileIndex.FindFileByName(
						modelnames[i],
						FileTypes.CRES,
						MetaData.LOCAL_GROUP,
						true
					);

				if (item != null)
				{
					cres.Add(item);
				}
			}

			return cres;
		}

		/// <summary>
		/// Load all File referenced by the passed rcol File
		/// </summary>
		/// <param name="modelnames">The Modulenames</param>
		/// <param name="exclude">The Exclude List</param>
		/// <param name="list">A List containing all Rcol Files</param>
		/// <param name="itemlist">A List of all FileIndexItems already added</param>
		/// <param name="rcol">The Rcol File (Scenegraph Resource)</param>
		/// <param name="item">The Item that was used to load the rcol</param>
		/// <param name="recursive">true if you want to add all sub Rcols</param>
		protected static void LoadReferenced(
			List<string> modelnames,
			ArrayList exclude,
			List<GenericRcol> list,
			List<IScenegraphFileIndexItem> itemlist,
			GenericRcol rcol,
			IScenegraphFileIndexItem item,
			bool recursive,
			CloneSettings setup
		)
		{
			//if we load a CRES, we also have to add the Modelname!
			if (rcol.FileDescriptor.Type == FileTypes.CRES)
			{
				modelnames.Add(rcol.FileName.Trim().ToLower());
			}

			list.Add(rcol);
			itemlist.Add(item);

			Dictionary<string, List<Interfaces.Files.IPackedFileDescriptor>> map = rcol.ReferenceChains;
			foreach (string s in map.Keys)
			{
				if (exclude.Contains(s))
				{
					continue;
				}

				foreach (Interfaces.Files.IPackedFileDescriptor pfd in map[s])
				{
					if (setup != null
						&& setup.KeepOriginalMesh
						&& (pfd.Type == FileTypes.GMND || pfd.Type == FileTypes.GMDC))
					{
						continue;
					}

					IScenegraphFileIndexItem subitem =
						FileTableBase.FileIndex.FindSingleFile(pfd, null, true);

					if (subitem != null)
					{
						if (!itemlist.Contains(subitem))
						{
							try
							{
								GenericRcol sub = new GenericRcol(
									null,
									false
								).ProcessFile(
									subitem.FileDescriptor,
									subitem.Package,
									false
								);

								if (
									FileExcludeList.Contains(
										sub.FileName.Trim().ToLower()
									)
								)
								{
									continue;
								}

								if (recursive)
								{
									LoadReferenced(
										modelnames,
										exclude,
										list,
										itemlist,
										sub,
										subitem,
										true,
										setup
									);
								}
							}
							catch (Exception ex)
							{
								Helper.ExceptionMessage(
									"",
									new CorruptedFileException(subitem, ex)
								);
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// Create a new Instance and build the CRES chain
		/// </summary>
		/// <param name="modelnames">Name of all Models</param>
		public Scenegraph(string modelname)
			: this(new List<string> { modelname }, new ArrayList(), new CloneSettings()) { }

		/// <summary>
		/// Create a new Instance and build the CRES chain
		/// </summary>
		/// <param name="modelnames">Name of all Models</param>
		public Scenegraph(List<string> modelnames)
			: this(modelnames, new ArrayList(), new CloneSettings()) { }

		CloneSettings setup;

		/// <summary>
		/// Create a new Instance and build the CRES chain
		/// </summary>
		/// <param name="modelnames">Name of all Models</param>
		/// <param name="ex">List of all ReferenceNames that should be excluded from the chain</param>
		public Scenegraph(List<string> modelnames, ArrayList ex, CloneSettings setup)
		{
			this.setup = setup;
			Init(modelnames, ex);
		}

		/// <summary>
		/// Create a new Instance and build the CRES chain
		/// </summary>
		/// <param name="modelnames">Name of all Models</param>
		/// <param name="ex">List of all ReferenceNames that should be excluded from the chain</param>
		public void Init(List<string> modelnames, ArrayList ex)
		{
			ExcludedReferences = ex;
			foreach (IScenegraphFileIndexItem item in LoadCres(modelnames))
			{
				GenericRcol sub = new GenericRcol(null, false).ProcessFile(item);
				LoadReferenced(
					this.modelnames,
					ex,
					files,
					itemlist,
					sub,
					item,
					true,
					setup
				);
			}
			foreach (string s in modelnames)
			{
				this.modelnames.Add(s);
			}
		}

		/// <summary>
		/// returns a unique identifier for the MMAT Files
		/// </summary>
		/// <param name="mmat"></param>
		/// <returns></returns>
		public static string MmatContent(Cpf mmat)
		{
			return mmat.GetSaveItem("modelName").StringValue /*+mmat.GetSaveItem("family").StringValue*/
				+ mmat.GetSaveItem("subsetName").StringValue
				+ mmat.GetSaveItem("name").StringValue
				+ Helper.HexString(mmat.GetSaveItem("objectStateIndex").UIntegerValue)
				+ Helper.HexString(mmat.GetSaveItem("materialStateFlags").UIntegerValue)
				+ Helper.HexString(mmat.GetSaveItem("objectGUID").UIntegerValue);
		}

		/// <summary>
		/// Loads Slave TXMTs by name Replacement
		/// </summary>
		/// <param name="rcol">a TXMT File</param>
		/// <param name="pkg">the package File with the base TXMTs</param>
		/// <param name="slaves">The Hashtable holding als Slave Subsets</param>
		public static void AddSlaveTxmts(
			List<string> modelnames,
			ArrayList ex,
			List<GenericRcol> list,
			List<IScenegraphFileIndexItem> itemlist,
			Rcol rcol,
			Hashtable slaves
		)
		{
			string name = rcol.FileName.Trim().ToLower();
			foreach (string k in slaves.Keys)
			{
				foreach (string sub in (ArrayList)slaves[k])
				{
					string slavename = name.Replace("_" + k + "_", "_" + sub + "_");
					if (slavename != name)
					{
						IScenegraphFileIndexItem item =
							FileTableBase.FileIndex.FindFileByName(
								slavename,
								FileTypes.TXMT,
								MetaData.LOCAL_GROUP,
								true
							);
						if (item != null)
						{
							GenericRcol txmt = new GenericRcol(null, false).ProcessFile(item);
							txmt.FileDescriptor =
								item.FileDescriptor.Clone();

							LoadReferenced(
								modelnames,
								ex,
								list,
								itemlist,
								txmt,
								item,
								true,
								null
							);
						}
					}
				}
			}
		}

		/// <summary>
		/// Loads Slave TXMTs by name Replacement
		/// </summary>
		/// <param name="slaves">The Hashtable holding als Slave Subsets</param>
		public void AddSlaveTxmts(Hashtable slaves)
		{
			for (int i = files.Count - 1; i >= 0; i--)
			{
				GenericRcol rcol = files[i];

				if (rcol.FileDescriptor.Type == FileTypes.TXMT)
				{
					AddSlaveTxmts(
						modelnames,
						ExcludedReferences,
						files,
						itemlist,
						rcol,
						slaves
					);
				}
			}
		}

		/// <summary>
		/// Loads Slave TXMTs by name Replacement
		/// </summary>
		/// <param name="pkg">the package File with the base TXMTs</param>
		/// <param name="slaves">The Hashtable holding als Slave Subsets</param>
		public static void AddSlaveTxmts(
			Interfaces.Files.IPackageFile pkg,
			Hashtable slaves
		)
		{
			List<GenericRcol> files = new List<GenericRcol>();
			List<IScenegraphFileIndexItem> items = new List<IScenegraphFileIndexItem>();

			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pkg.FindFiles(FileTypes.TXMT))
			{
				GenericRcol rcol = new GenericRcol(null, false).ProcessFile(pfd, pkg);

				if (rcol.FileDescriptor.Type == FileTypes.TXMT)
				{
					AddSlaveTxmts(
						new List<string>(),
						new ArrayList(),
						files,
						items,
						rcol,
						slaves
					);
				}
			}

			foreach (GenericRcol rcol in files)
			{
				if (pkg.FindFile(rcol.FileDescriptor) == null)
				{
					rcol.FileDescriptor = rcol.FileDescriptor.Clone();
					rcol.SynchronizeUserData();
					pkg.Add(rcol.FileDescriptor);
				}
			}
		}

		#region Cache Handling
		static Cache.Cache cachefile;

		static void LoadCache()
		{
			if (cachefile != null)
			{
				return;
			}
			if (Helper.WindowsRegistry.Config.UseCache)
			{
				cachefile = Cache.Cache.GlobalCache;
			}
		}

		static void SaveCache()
		{
			if (Helper.WindowsRegistry.Config.UseCache)
			{
				cachefile.Save();
			}
		}
		#endregion

		/// <summary>
		/// Adds all know MMATs that reference one of the models;
		/// </summary>
		/// <param name="pkg"></param>
		/// <param name="onlydefault">true, if you only want to read default MMATS</param>
		/// <param name="subitems">true, if you also want to load MMAT Files that reference Files ouside the passed package</param>
		/// <param name="exception">true if you want to throw an exception when something goes wrong</param>
		/// <returns>List of all referenced GUIDs</returns>
		public void AddMaterialOverrides(
			Interfaces.Files.IPackageFile pkg,
			bool onlydefault,
			bool subitems,
			bool exception
		)
		{
			LoadCache();

			IEnumerable<IScenegraphFileIndexItem> items =
				FileTableBase.FileIndex.FindFile(FileTypes.MMAT, true);
			List<IScenegraphFileIndexItem> itemlist = new List<IScenegraphFileIndexItem>();
			ArrayList contentlist = new ArrayList();
			List<string> defaultfam = new List<string>();
			ArrayList guids = new ArrayList();

			//create an UpTo Date Cache
			bool chgcache = false;

			// Find files which are not already in the cache
			foreach (IScenegraphFileIndexItem item in from item in items
													  from citem in cachefile.MmatCacheFileIndex.FindFile(item.FileDescriptor, item.Package)
													  where citem.FileDescriptor.Filename != item.Package.FileName.Trim().ToLower()
													  select item)
			{
				cachefile.AddMmatItem(new MmatWrapper().ProcessFile(item.FileDescriptor, item.Package));
				chgcache = true;
			}

			if (chgcache)
			{
				SaveCache();
			}

			//collect a list of Default Material Override family values first
			if (onlydefault)
			{
				defaultfam = (from files in cachefile.Items[Cache.ContainerType.MaterialOverride]
							  from Cache.MMATCacheItem mci in files.Value
							  where mci.Default
							  select mci.Family).ToList();
			}

			// callect all files from all modelnames
			foreach (IScenegraphFileIndexItem item in from k in modelnames
													  from files in cachefile.Items[Cache.ContainerType.MaterialOverride]
													  from Cache.MMATCacheItem mci in files.Value
													  from IScenegraphFileIndexItem item in FileTableBase.FileIndex.FindFile(mci.FileDescriptor, null)
													  where mci.ModelName == k.Trim().ToLower()
													  where !onlydefault || defaultfam.Contains(mci.Family)
													  select item)
			{
				if (!itemlist.Contains(item))
				{
					itemlist.Add(item);
					MmatWrapper mmat = new MmatWrapper().ProcessFile(item);

					string content = MmatContent(mmat).Trim().ToLower();
					if (!contentlist.Contains(content))
					{
						mmat.FileDescriptor = Clone(mmat.FileDescriptor);
						mmat.SynchronizeUserData();

						if (subitems)
						{
							if (pkg.FindFile(mmat.FileDescriptor) == null)
							{
								pkg.Add(mmat.FileDescriptor);
							}

							IScenegraphFileIndexItem txmtitem =
								FileTableBase.FileIndex.FindFileByName(
									mmat.GetSaveItem("name").StringValue
										+ "_txmt",
									FileTypes.TXMT,
									MetaData.LOCAL_GROUP,
									true
								);
							if (txmtitem != null)
							{
								try
								{
									GenericRcol sub =
										new GenericRcol(null, false).ProcessFile(
										txmtitem.FileDescriptor,
										txmtitem.Package,
										false
									);
									List<GenericRcol> newfiles = new List<GenericRcol>();
									LoadReferenced(
										modelnames,
										ExcludedReferences,
										newfiles,
										itemlist,
										sub,
										txmtitem,
										true,
										setup
									);
									BuildPackage(newfiles, pkg);
								}
								catch (Exception ex)
								{
									Helper.ExceptionMessage(
										"",
										new CorruptedFileException(txmtitem, ex)
									);
								}
							}
							else
							{
								continue;
								//if (exception) throw new ScenegraphException("Invalid Scenegraph Link", new ScenegraphException("Unable to find Referenced File "+name+"_txmt.", mmat.FileDescriptor), mmat.FileDescriptor);
							}
						}
						else
						{
							if (pkg.FindFile(mmat.FileDescriptor) == null)
							{
								string txmtname = mmat.GetSaveItem("name")
									.StringValue.Trim();
								if (!txmtname.EndsWith("_txmt"))
								{
									txmtname += "_txmt";
								}

								if (
									pkg.FindFile(
										txmtname,
										FileTypes.TXMT
									).Length > 0
								)
								{
									pkg.Add(mmat.FileDescriptor);
								}
							}
						}
						contentlist.Add(content);
					} //if contentlist
				}
			}
		}

		/// <summary>
		/// Will return a List of all SubSets that can be recolored
		/// </summary>
		/// <param name="pkg"></param>
		/// <returns>a List of Subset Names</returns>
		public static ArrayList GetRecolorableSubsets(
			Interfaces.Files.IPackageFile pkg
		)
		{
			return GetSubsets(pkg, "tsdesignmodeenabled");
		}

		/// <summary>
		/// Will return a List of all SubSets that are borrowed from a Parent Object
		/// </summary>
		/// <param name="pkg"></param>
		/// <returns>a List of Subset Names</returns>
		public static ArrayList GetParentSubsets(
			Interfaces.Files.IPackageFile pkg
		)
		{
			return GetSubsets(pkg, "tsMaterialsMeshName");
		}

		/// <summary>
		/// Will return a List of all SubSets that can be recolored
		/// </summary>
		/// <param name="pkg"></param>
		/// <returns>a List of Subset Names</returns>
		public static ArrayList GetSubsets(
			Interfaces.Files.IPackageFile pkg,
			string blockname
		)
		{
			if (blockname == null)
			{
				blockname = "";
			}

			ArrayList list = new ArrayList();

			if (pkg == null)
			{
				return list;
			}

			blockname = blockname.Trim().ToLower();
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pkg.FindFiles(
				FileTypes.GMND
			))
			{
				foreach (IRcolBlock irb in new GenericRcol(null, false).ProcessFile(pfd, pkg).Blocks)
				{
					if (irb.BlockName == "cDataListExtension")
					{
						DataListExtension dle = (DataListExtension)irb;
						if (dle.Extension.VarName.Trim().ToLower() == blockname)
						{
							foreach (ExtensionItem ei in dle.Extension.Items)
							{
								list.Add(ei.Name.Trim().ToLower());
							}
						}
					}
				}
			}
			return list;
		}

		/// <summary>
		/// Adds the Slave definitions of the passed gmnd to the passed map
		/// </summary>
		/// <param name="gmnd">the GMND File</param>
		/// <param name="map">the Map Table (key=master subset name, value= ArrayList of slave subsets</param>
		public static void GetSlaveSubsets(GenericRcol gmnd, Hashtable map)
		{
			foreach (IRcolBlock irb in gmnd.Blocks)
			{
				if (irb.BlockName == "cDataListExtension")
				{
					DataListExtension dle = (DataListExtension)irb;
					if (
						dle.Extension.VarName.Trim().ToLower()
						== "tsdesignmodeslavesubsets"
					)
					{
						foreach (ExtensionItem ei in dle.Extension.Items)
						{
							string[] slaves = ei.String.Split(",".ToCharArray());
							ArrayList slavelist = new ArrayList();
							foreach (string s in slaves)
							{
								slavelist.Add(s.Trim().ToLower());
							}

							map[ei.Name.Trim().ToLower()] = slavelist;
						}
					}
				}
			}
		}

		/// <summary>
		/// Will return a Hashtable (key = subset name) of ArrayLists (slave subset names)
		/// </summary>
		/// <returns>The Hashtable</returns>
		public Hashtable GetSlaveSubsets()
		{
			Hashtable map = new Hashtable();
			foreach (GenericRcol gmnd in files)
			{
				if (gmnd.FileDescriptor.Type == FileTypes.GMND)
				{
					GetSlaveSubsets(gmnd, map);
				}
			}
			return map;
		}

		/// <summary>
		/// Will return a Hashtable (key = subset name) of ArrayLists (slave subset names)
		/// </summary>
		/// <param name="pkg"></param>
		/// <returns></returns>
		public static Hashtable GetSlaveSubsets(Interfaces.Files.IPackageFile pkg)
		{
			Hashtable map = new Hashtable();
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pkg.FindFiles(
				FileTypes.GMND
			))
			{
				GetSlaveSubsets(new GenericRcol(null, false).ProcessFile(pfd, pkg), map);
			}
			return map;
		}

		/// <summary>
		/// Return al Hashtable (subset) of Hashtable (family) of ArrayLists (mmat Files) specifiying all available Material Overrides
		/// </summary>
		/// <param name="pkg">The package you want to scan</param>
		/// <returns>The Hashtable</returns>
		public static Hashtable GetMMATMap(Interfaces.Files.IPackageFile pkg)
		{
			if (pkg == null)
			{
				return new Hashtable();
			}

			Interfaces.Files.IPackedFileDescriptor[] mmats = pkg.FindFiles(
				FileTypes.MMAT
			);
			Hashtable ht = new Hashtable();

			foreach (Interfaces.Files.IPackedFileDescriptor pfd in mmats)
			{
				MmatWrapper mmat = new MmatWrapper().ProcessFile(pfd, pkg);

				string subset = mmat.GetSaveItem("subsetName")
					.StringValue.Trim()
					.ToLower();
				string family = mmat.GetSaveItem("family").StringValue;

				//get the available families
				Hashtable families = null;
				if (!ht.ContainsKey(subset))
				{
					families = new Hashtable();
					ht[subset] = families;
				}
				else
				{
					families = (Hashtable)ht[subset];
				}

				//get listing of the current Family
				ArrayList list = null;
				if (!families.ContainsKey(family))
				{
					list = new ArrayList();
					families[family] = list;
				}
				else
				{
					list = (ArrayList)families[family];
				}

				//add the MMAT File
				list.Add(mmat);
			}

			return ht;
		}

		/// <summary>
		/// Create a package based on the collected Files
		/// </summary>
		/// <returns></returns>
		public Packages.GeneratableFile BuildPackage()
		{
			Packages.GeneratableFile pkg =
				Packages.File.LoadFromFile("simpe_memory");
			BuildPackage(pkg);

			return pkg;
		}

		/// <summary>
		/// Create a package based on the collected Files
		/// </summary>
		/// <returns></returns>
		public void BuildPackage(Interfaces.Files.IPackageFile pkg)
		{
			BuildPackage(files, pkg);
		}

		/// <summary>
		/// Create a package based on the collected Files
		/// </summary>
		/// <returns></returns>
		public static void BuildPackage(
			List<GenericRcol> files,
			Interfaces.Files.IPackageFile pkg
		)
		{
			foreach (GenericRcol rcol in files)
			{
				rcol.FileDescriptor = Clone(rcol.FileDescriptor);
				rcol.SynchronizeUserData();

				if (pkg.FindFile(rcol.FileDescriptor) == null)
				{
					pkg.Add(rcol.FileDescriptor);
				}
			}
		}

		/// <summary>
		/// Loads the ModelNames of the Objects referenced in all tsMaterialsMeshName Block
		/// </summary>
		/// <param name="pkg"></param>
		/// <param name="delete">true, if the tsMaterialsMeshName Blocks should get cleared</param>
		/// <returns>A List of Modelnames</returns>
		public static List<string> LoadParentModelNames(
			Interfaces.Files.IPackageFile pkg,
			bool delete
		)
		{
			if (WaitingScreen.Running)
			{
				WaitingScreen.UpdateMessage("Loading Parent Modelnames");
			}

			List<string> list = new List<string>();

			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pkg.FindFiles(
				FileTypes.GMND
			))
			{
				Rcol rcol = new GenericRcol(null, false).ProcessFile(pfd, pkg);

				foreach (IRcolBlock irb in rcol.Blocks)
				{
					if (irb.BlockName.Trim().ToLower() == "cdatalistextension")
					{
						DataListExtension dle = (DataListExtension)irb;
						if (
							dle.Extension.VarName.Trim().ToLower()
							== "tsmaterialsmeshname"
						)
						{
							foreach (ExtensionItem ei in dle.Extension.Items)
							{
								string mname = ei.String.Trim().ToLower();
								if (mname.EndsWith("_cres"))
								{
									mname += "_cres";
								}

								if (!list.Contains(mname))
								{
									list.Add(mname);
								}
							}

							dle.Extension.Items.Clear();
							rcol.SynchronizeUserData();
							break;
						}
					}
				}
			}
			return list;
		}

		#region Str Linked Resources
		protected ArrayList LoadStrLinked(
			Interfaces.Files.IPackageFile pkg,
			CloneSettings.StrIntsanceAlias instance
		)
		{
			ArrayList list = new ArrayList();
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pkg.FindFile(
				FileTypes.STR,
				0,
				instance.Instance
			))
			{
				foreach (StrToken si in new PackedFiles.Str.Str().ProcessFile(pfd, pkg).Items)
				{
					string name = Hashes.StripHashFromName(si.Title).Trim();
					if (name == "")
					{
						continue;
					}

					name += instance.Extension;
					//Console.WriteLine("Str Linked: "+name);
					IScenegraphFileIndexItem fii =
						FileTableBase.FileIndex.FindFileByName(
							name,
							instance.Type,
							Hashes.GetHashGroupFromName(
								si.Title,
								MetaData.GLOBAL_GROUP
							),
							true
						);
					if (fii != null)
					{
						//Console.WriteLine("    --> found");
						list.Add(fii);
					}
				}
			}
			return list;
		}

		/// <summary>
		/// Add Wallmasks (if available) to the Clone
		/// </summary>
		/// <param name="instances"></param>
		public void AddStrLinked(
			Interfaces.Files.IPackageFile pkg,
			CloneSettings.StrIntsanceAlias[] instances
		)
		{
			foreach (CloneSettings.StrIntsanceAlias instance in instances)
			{
				foreach (
					IScenegraphFileIndexItem item in LoadStrLinked(pkg, instance)
				)
				{
					LoadReferenced(
						modelnames,
						ExcludedReferences,
						files,
						itemlist,
						new GenericRcol(null, false).ProcessFile(item),
						item,
						true,
						setup
					);
				}
			}
		}
		#endregion

		#region Wallmask
		/// <summary>
		/// Load all pending Wallmask Files
		/// </summary>
		/// <param name="modelname"></param>
		/// <returns></returns>
		protected ArrayList LoadWallmask(string modelname)
		{
			ArrayList txmt = new ArrayList();

			//known types (based on a List created by Numenor)
			// string[] list =
			// {
			// 	"0_0_0_n", //for all the straight doors/windows/arches
			// 	"0_1s_0_s", //for all the straight doors/windows/arches
			// 	"1e_0_0_n", //in addition to them, the 2-tile straight doors/windows/arches
			// 	"1e_1s_0_s", //in addition to them, the 2-tile straight doors/windows/arches
			// 	"0_0_0_nw", //all the diagonal doors/window/arches have
			// 	"0_0_0_se", //all the diagonal doors/window/arches have
			// 	"1e_1n_0_nw", // in addition to them, the 2-tile diagonals have
			// 	"1e_1n_0_se", // in addition to them, the 2-tile diagonals have
			// };

			modelname = modelname.Trim().ToLower();
			if (modelname.EndsWith("_cres"))
			{
				modelname = modelname.Substring(0, modelname.Length - 5);
			}

			//no Modelname => no Wallmask
			if (modelname == "")
			{
				return txmt;
			}

			//this applies to all found NameMaps for TXTR Files
			ArrayList foundnames = new ArrayList();
			foreach (
				IScenegraphFileIndexItem namemap in FileTableBase.FileIndex.FindFile(
					FileTypes.NMAP,
					0x52737256,
					(ulong)FileTypes.TXMT,
					null
				)
			)
			{
				foreach (NmapItem ni in new Nmap(null).ProcessFile(namemap).Items)
				{
					string name = ni.Filename.Trim().ToLower();
					if (name.StartsWith(modelname) && name.EndsWith("_wallmask_txmt"))
					{
						IScenegraphFileIndexItem item =
							FileTableBase.FileIndex.FindFileByName(
								name,
								FileTypes.TXMT,
								ni.Group,
								true
							);

						if (item != null)
						{
							if (!foundnames.Contains(item.FileDescriptor))
							{
								foundnames.Add(item.FileDescriptor);
								txmt.Add(item);
							}
						}
					}
				}
			}
			/*foreach (string s in list)
			{
				string nmn = modelname + "_" + s + "_wallmask_txmt";

				Interfaces.Scenegraph.IScenegraphFileIndexItem item = FileTable.FileIndex.FindFileByName(nmn, Data.FileTypes.TXMT, Data.MetaData.LOCAL_GROUP, true);

				if (item!=null) txmt.Add(item);
			}*/

			return txmt;
		}

		/// <summary>
		/// Add Wallmasks (if available) to the Clone
		/// </summary>
		/// <param name="modelnames"></param>
		/// <remarks>based on Instructions By Numenor</remarks>
		public void AddWallmasks(List<string> modelnames)
		{
			foreach (string s in modelnames)
			{
				ArrayList txmt = LoadWallmask(s);

				foreach (
					IScenegraphFileIndexItem item in txmt
				)
				{
					LoadReferenced(
						this.modelnames,
						ExcludedReferences,
						files,
						itemlist,
						new GenericRcol(null, false).ProcessFile(item),
						item,
						true,
						setup
					);
				}
			}
		}
		#endregion

		#region ANIM
		/// <summary>
		/// Load a ANIM Resource
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		protected IEnumerable<IScenegraphFileIndexItem> LoadAnim(string name)
		{
			HashSet<IScenegraphFileIndexItem> anim = new HashSet<IScenegraphFileIndexItem>();

			name = name.Trim().ToLower();
			if (!name.EndsWith("_anim"))
			{
				name += "_anim";
			}

			IScenegraphFileIndexItem item =
				FileTableBase.FileIndex.FindFileByName(
					name,
					FileTypes.ANIM,
					MetaData.LOCAL_GROUP,
					true
				);
			if (item != null)
			{
				anim.Add(item);
			}

			return anim;
		}

		/// <summary>
		/// Add Anim Resources (if available) to the Clone
		/// </summary>
		/// <param name="names"></param>
		public void AddAnims(IEnumerable<string> names)
		{
			foreach (string s in names)
			{
				foreach (
					IScenegraphFileIndexItem item in LoadAnim(s)
				)
				{
					LoadReferenced(
						modelnames,
						ExcludedReferences,
						files,
						itemlist,
						new GenericRcol(null, false).ProcessFile(item),
						item,
						true,
						setup
					);
				}
			}
		}
		#endregion

		#region 3IDR
		/// <summary>
		/// Add Resources referenced from 3IDR Files
		/// </summary>
		/// <param name="names"></param>
		public void AddFrom3IDR(Interfaces.Files.IPackageFile pkg)
		{
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pkg.FindFiles(
				FileTypes.THREE_IDR
			))
			{
				foreach (Interfaces.Files.IPackedFileDescriptor p in new ThreeIdr().ProcessFile(pfd, pkg).Items)
				{
					foreach (
						IScenegraphFileIndexItem item in FileTableBase.FileIndex.FindFile(p, null)
					)
					{
						try
						{
							// if (item.FileDescriptor.Type == Data.FileTypes.STR)
							LoadReferenced(
								modelnames,
								ExcludedReferences,
								files,
								itemlist,
								new GenericRcol(null, false).ProcessFile(item),
								item,
								true,
								setup
							);
						}
						catch (Exception ex)
						{
							if (Helper.WindowsRegistry.Config.HiddenMode)
							{
								Helper.ExceptionMessage("", ex);
							}
						}
					}
				}
			}
		}
		#endregion

		#region Xml
		/// <summary>
		/// Add Resources referenced from XML Files
		/// </summary>
		/// <param name="names"></param>
		public void AddFromXml(Interfaces.Files.IPackageFile pkg)
		{
			Interfaces.Files.IPackedFileDescriptor[] index =
				(Interfaces.Files.IPackedFileDescriptor[])pkg.Index.Clone();
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in index)
			{
				Cpf cpf = new Cpf();
				if (!cpf.CanHandleType(pfd.Type))
				{
					continue;
				}

				cpf.ProcessData(pfd, pkg);

				//xobj
				AddFromXml(cpf.GetItem("material"), "_txmt", FileTypes.TXMT);

				//hood object
				if (pfd.Type == FileTypes.XNGB)
				{
					AddFromXml(cpf.GetItem("modelname"), "_cres", FileTypes.CRES);
				}

				//fences
				AddFromXml(cpf.GetItem("diagrail"), "_cres", FileTypes.CRES);
				AddFromXml(cpf.GetItem("post"), "_cres", FileTypes.CRES);
				AddFromXml(cpf.GetItem("rail"), "_cres", FileTypes.CRES);
				AddFromXml(cpf.GetItem("diagrail"), "_txmt", FileTypes.TXMT);
				AddFromXml(cpf.GetItem("post"), "_txmt", FileTypes.TXMT);
				AddFromXml(cpf.GetItem("rail"), "_txmt", FileTypes.TXMT);

				//terrain
				AddFromXml(cpf.GetItem("texturetname"), "_txtr", FileTypes.TXTR);
				AddFromXml(
					cpf.GetItem("texturetname"),
					"_detail_txtr",
					FileTypes.TXTR
				);
				AddFromXml(
					cpf.GetItem("texturetname"),
					"-bump_txtr",
					FileTypes.TXTR
				);

				//roof
				AddFromXml(cpf.GetItem("textureedges"), "_txtr", FileTypes.TXTR);
				AddFromXml(cpf.GetItem("texturetop"), "_txtr", FileTypes.TXTR);
				AddFromXml(cpf.GetItem("texturetopbump"), "_txtr", FileTypes.TXTR);
				AddFromXml(cpf.GetItem("texturetrim"), "_txtr", FileTypes.TXTR);
				AddFromXml(cpf.GetItem("textureunder"), "_txtr", FileTypes.TXTR);

				AddFromXml(FileTableBase.FileIndex.FindFile(
						(FileTypes)cpf.GetSaveItem("stringsetrestypeid").UIntegerValue,
						cpf.GetSaveItem("stringsetgroupid").UIntegerValue,
						cpf.GetSaveItem("stringsetid").UIntegerValue,
						null
					));
			}
		}

		/// <summary>
		/// Add Resources referenced from XML Files
		/// </summary>
		protected void AddFromXml(
			CpfItem item,
			string prefix,
			FileTypes type
		)
		{
			if (item == null)
			{
				return;
			}

			AddFromXml(item.StringValue + prefix, type);
		}

		/// <summary>
		/// Add Resources referenced from XML Files
		/// </summary>
		protected void AddFromXml(string name, FileTypes type)
		{
			AddFromXml(FileTableBase.FileIndex.FindFileByName(
					name,
					type,
					MetaData.LOCAL_GROUP,
					true
				));
		}

		/// <summary>
		/// Add Resources referenced from XML Files
		/// </summary>
		protected void AddFromXml(
			IScenegraphFileIndexItem item
		)
		{
			if (item == null)
			{
				return;
			}
			AddFromXml(new IScenegraphFileIndexItem[] { item });
		}

		/// <summary>
		/// Add Resources referenced from XML Files
		/// </summary>
		protected void AddFromXml(
			IEnumerable<IScenegraphFileIndexItem> items
		)
		{
			foreach (IScenegraphFileIndexItem item in items)
			{
				try
				{
					LoadReferenced(
						modelnames,
						ExcludedReferences,
						files,
						itemlist,
						new GenericRcol(null, false).ProcessFile(item),
						item,
						true,
						setup
					);
				}
				catch (Exception ex)
				{
					if (Helper.WindowsRegistry.Config.HiddenMode)
					{
						Helper.ExceptionMessage("", ex);
					}
				}
			}
		}
		#endregion
	}
}
