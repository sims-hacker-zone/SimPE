// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections;

using SimPe.Interfaces.Scenegraph;
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
		public static ArrayList FileExcludeList { get; set; } = new ArrayList();

		/// <summary>
		/// The Default List for FileExcludeList
		/// </summary>
		public static ArrayList DefaultFileExcludeList
		{
			get
			{
				ArrayList ret = new ArrayList
				{
					"simple_mirror_reflection_txmt"
				};
				return ret;
			}
		}

		/// <summary>
		/// Contains the base Modelnames
		/// </summary>
		ArrayList modelnames;

		/// <summary>
		/// Contains all found Files
		/// </summary>
		ArrayList files;

		/// <summary>
		/// All loaded Items
		/// </summary>
		ArrayList itemlist;

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
		public static string[] FindModelNames(Interfaces.Files.IPackageFile pkg)
		{
			ArrayList names = new ArrayList();

			Interfaces.Files.IPackedFileDescriptor[] pfds = pkg.FindFile(
				Data.MetaData.STRING_FILE,
				0,
				0x85
			);
			if (pfds.Length > 0)
			{
				foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
				{
					PackedFiles.Wrapper.Str str =
						new PackedFiles.Wrapper.Str();
					str.ProcessData(pfd, pkg);

					foreach (PackedFiles.Wrapper.StrToken item in str.Items)
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
			}

			pfds = pkg.FindFiles(Data.MetaData.MMAT);
			if (pfds.Length > 0)
			{
				foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
				{
					PackedFiles.Wrapper.Cpf cpf =
						new PackedFiles.Wrapper.Cpf();
					cpf.ProcessData(pfd, pkg);

					string mname = Hashes.StripHashFromName(
						cpf.GetSaveItem("modelName").StringValue.Trim().ToLower()
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

			string[] ret = new string[names.Count];
			names.CopyTo(ret);

			return ret;
		}

		/// <summary>
		/// Load all pending CRES Files
		/// </summary>
		/// <param name="modelnames"></param>
		/// <returns></returns>
		protected ArrayList LoadCres(string[] modelnames)
		{
			ArrayList cres = new ArrayList();
			for (int i = 0; i < modelnames.Length; i++)
			{
				modelnames[i] = modelnames[i].Trim().ToLower();
				if (!modelnames[i].EndsWith("_cres"))
				{
					modelnames[i] += "_cres";
				}

				IScenegraphFileIndexItem item =
					FileTableBase.FileIndex.FindFileByName(
						modelnames[i],
						Data.MetaData.CRES,
						Data.MetaData.LOCAL_GROUP,
						true
					);
				//Clone(item);

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
			ArrayList modelnames,
			ArrayList exclude,
			ArrayList list,
			ArrayList itemlist,
			GenericRcol rcol,
			IScenegraphFileIndexItem item,
			bool recursive,
			CloneSettings setup
		)
		{
			//if we load a CRES, we also have to add the Modelname!
			if (rcol.FileDescriptor.Type == Data.MetaData.CRES)
			{
				modelnames.Add(rcol.FileName.Trim().ToLower());
			}

			list.Add(rcol);
			itemlist.Add(item);

			Hashtable map = rcol.ReferenceChains;
			foreach (string s in map.Keys)
			{
				if (exclude.Contains(s))
				{
					continue;
				}

				ArrayList descs = (ArrayList)map[s];
				foreach (Interfaces.Files.IPackedFileDescriptor pfd in descs)
				{
					if (setup != null)
					{
						if (setup.KeepOriginalMesh)
						{
							if (pfd.Type == Data.MetaData.GMND)
							{
								continue;
							}

							if (pfd.Type == Data.MetaData.GMDC)
							{
								continue;
							}
						}
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
								);
								sub.ProcessData(
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
			: this(new string[] { modelname }, new ArrayList(), new CloneSettings()) { }

		/// <summary>
		/// Create a new Instance and build the CRES chain
		/// </summary>
		/// <param name="modelnames">Name of all Models</param>
		public Scenegraph(string[] modelnames)
			: this(modelnames, new ArrayList(), new CloneSettings()) { }

		CloneSettings setup;

		/// <summary>
		/// Create a new Instance and build the CRES chain
		/// </summary>
		/// <param name="modelnames">Name of all Models</param>
		/// <param name="ex">List of all ReferenceNames that should be excluded from the chain</param>
		public Scenegraph(string[] modelnames, ArrayList ex, CloneSettings setup)
		{
			this.setup = setup;
			Init(modelnames, ex);
		}

		/// <summary>
		/// Create a new Instance and build the CRES chain
		/// </summary>
		/// <param name="modelnames">Name of all Models</param>
		/// <param name="ex">List of all ReferenceNames that should be excluded from the chain</param>
		public void Init(string[] modelnames, ArrayList ex)
		{
			ExcludedReferences = ex;
			this.modelnames = new ArrayList();
			ArrayList cres = LoadCres(modelnames);

			files = new ArrayList();
			itemlist = new ArrayList();
			foreach (IScenegraphFileIndexItem item in cres)
			{
				GenericRcol sub = new GenericRcol(null, false);
				sub.ProcessData(item);
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
		public static string MmatContent(PackedFiles.Wrapper.Cpf mmat)
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
			ArrayList modelnames,
			ArrayList ex,
			ArrayList list,
			ArrayList itemlist,
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
								Data.MetaData.TXMT,
								Data.MetaData.LOCAL_GROUP,
								true
							);
						if (item != null)
						{
							GenericRcol txmt = new GenericRcol(null, false);
							txmt.ProcessData(item);
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
				GenericRcol rcol = (GenericRcol)files[i];

				if (rcol.FileDescriptor.Type == Data.MetaData.TXMT)
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
			ArrayList files = new ArrayList();
			ArrayList items = new ArrayList();

			Interfaces.Files.IPackedFileDescriptor[] pfds = pkg.FindFiles(
				Data.MetaData.TXMT
			);
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				GenericRcol rcol = new GenericRcol(null, false);
				rcol.ProcessData(pfd, pkg);

				if (rcol.FileDescriptor.Type == Data.MetaData.TXMT)
				{
					AddSlaveTxmts(
						new ArrayList(),
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
		static Cache.MMATCacheFile cachefile;

		static void LoadCache()
		{
			if (cachefile != null)
			{
				return;
			}

			cachefile = new Cache.MMATCacheFile();
			if (Helper.WindowsRegistry.UseCache)
			{
				cachefile.Load(Helper.SimPeLanguageCache);
			}
		}

		static void SaveCache()
		{
			if (Helper.WindowsRegistry.UseCache)
			{
				cachefile.Save(Helper.SimPeLanguageCache);
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

			IScenegraphFileIndexItem[] items =
				FileTableBase.FileIndex.FindFile(Data.MetaData.MMAT, true);
			ArrayList itemlist = new ArrayList();
			ArrayList contentlist = new ArrayList();
			ArrayList defaultfam = new ArrayList();
			ArrayList guids = new ArrayList();

			//create an UpTo Date Cache
			bool chgcache = false;
			foreach (IScenegraphFileIndexItem item in items)
			{
				string pname = item.Package.FileName.Trim().ToLower();
				IScenegraphFileIndexItem[] citems =
					cachefile.FileIndex.FindFile(item.FileDescriptor, item.Package);
				bool have = false;
				foreach (
					IScenegraphFileIndexItem citem in citems
				)
				{
					if (citem.FileDescriptor.Filename == pname)
					{
						have = true;
						break;
					}
				}

				//Not in cache, so add that File
				if (!have)
				{
					MmatWrapper mmat = new MmatWrapper();
					mmat.ProcessData(item.FileDescriptor, item.Package);

					cachefile.AddItem(mmat);
					chgcache = true;
				}
			}
			if (chgcache)
			{
				SaveCache();
			}

			//collect a list of Default Material Override family values first
			if (onlydefault)
			{
				foreach (
					Cache.MMATCacheItem mci in (Cache.CacheItems)
						cachefile.DefaultMap[true]
				)
				{
					defaultfam.Add(mci.Family);
				}
			}

			//now do the real collect
			foreach (string k in modelnames)
			{
				Cache.CacheItems list = (Cache.CacheItems)
					cachefile.ModelMap[k.Trim().ToLower()];
				if (list != null)
				{
					foreach (Cache.MMATCacheItem mci in list)
					{
						if (onlydefault && !defaultfam.Contains(mci.Family))
						{
							continue;
						}

						string name = k;
						items = FileTableBase.FileIndex.FindFile(mci.FileDescriptor, null);

						foreach (
							IScenegraphFileIndexItem item in items
						)
						{
							if (itemlist.Contains(item))
							{
								continue;
							}

							itemlist.Add(item);
							MmatWrapper mmat = new MmatWrapper();
							mmat.ProcessData(item);

							string content = MmatContent(mmat);
							content = content.Trim().ToLower();
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
											Data.MetaData.TXMT,
											Data.MetaData.LOCAL_GROUP,
											true
										);
									if (txmtitem != null)
									{
										try
										{
											GenericRcol sub =
												new GenericRcol(null, false);
											sub.ProcessData(
												txmtitem.FileDescriptor,
												txmtitem.Package,
												false
											);
											ArrayList newfiles = new ArrayList();
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
												Data.MetaData.TXMT
											).Length > 0
										)
										{
											pkg.Add(mmat.FileDescriptor);
										}
									}
								}
								contentlist.Add(content);
							} //if contentlist
						} //foreach item
					} //foreach MMATCacheItem
				} // if list !=null
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
			Interfaces.Files.IPackedFileDescriptor[] gmnds = pkg.FindFiles(
				Data.MetaData.GMND
			);
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in gmnds)
			{
				GenericRcol gmnd = new GenericRcol(null, false);
				gmnd.ProcessData(pfd, pkg);

				foreach (IRcolBlock irb in gmnd.Blocks)
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
				if (gmnd.FileDescriptor.Type == Data.MetaData.GMND)
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
			Interfaces.Files.IPackedFileDescriptor[] gmnds = pkg.FindFiles(
				Data.MetaData.GMND
			);
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in gmnds)
			{
				GenericRcol gmnd = new GenericRcol(null, false);
				gmnd.ProcessData(pfd, pkg);

				GetSlaveSubsets(gmnd, map);
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
				Data.MetaData.MMAT
			);
			Hashtable ht = new Hashtable();

			foreach (Interfaces.Files.IPackedFileDescriptor pfd in mmats)
			{
				MmatWrapper mmat = new MmatWrapper();
				mmat.ProcessData(pfd, pkg);

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
			ArrayList files,
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
		public static string[] LoadParentModelNames(
			Interfaces.Files.IPackageFile pkg,
			bool delete
		)
		{
			if (WaitingScreen.Running)
			{
				WaitingScreen.UpdateMessage("Loading Parent Modelnames");
			}

			ArrayList list = new ArrayList();

			Interfaces.Files.IPackedFileDescriptor[] pfds = pkg.FindFiles(
				Data.MetaData.GMND
			);
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				Rcol rcol = new GenericRcol(null, false);
				rcol.ProcessData(pfd, pkg);

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

							dle.Extension.Items = new ExtensionItem[0];
							rcol.SynchronizeUserData();
							break;
						}
					}
				}
			}

			string[] ret = new string[list.Count];
			list.CopyTo(ret);

			return ret;
		}

		#region Str Linked Resources
		protected ArrayList LoadStrLinked(
			Interfaces.Files.IPackageFile pkg,
			CloneSettings.StrIntsanceAlias instance
		)
		{
			ArrayList list = new ArrayList();
			Interfaces.Files.IPackedFileDescriptor[] pfds = pkg.FindFile(
				Data.MetaData.STRING_FILE,
				0,
				instance.Instance
			);
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				PackedFiles.Wrapper.Str str = new PackedFiles.Wrapper.Str();
				str.ProcessData(pfd, pkg);
				foreach (PackedFiles.Wrapper.StrToken si in str.Items)
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
								Data.MetaData.GLOBAL_GROUP
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
				ArrayList rcols = LoadStrLinked(pkg, instance);

				foreach (
					IScenegraphFileIndexItem item in rcols
				)
				{
					GenericRcol sub = new GenericRcol(null, false);
					sub.ProcessData(item);
					LoadReferenced(
						modelnames,
						ExcludedReferences,
						files,
						itemlist,
						sub,
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
			string[] list =
			{
				"0_0_0_n", //for all the straight doors/windows/arches
				"0_1s_0_s", //for all the straight doors/windows/arches
				"1e_0_0_n", //in addition to them, the 2-tile straight doors/windows/arches
				"1e_1s_0_s", //in addition to them, the 2-tile straight doors/windows/arches
				"0_0_0_nw", //all the diagonal doors/window/arches have
				"0_0_0_se", //all the diagonal doors/window/arches have
				"1e_1n_0_nw", // in addition to them, the 2-tile diagonals have
				"1e_1n_0_se", // in addition to them, the 2-tile diagonals have
			};

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
			IScenegraphFileIndexItem[] namemapitems =
				FileTableBase.FileIndex.FindFile(
					Data.MetaData.NAME_MAP,
					0x52737256,
					Data.MetaData.TXMT,
					null
				);
			foreach (
				IScenegraphFileIndexItem namemap in namemapitems
			)
			{
				Nmap nmap = new Nmap(null);
				nmap.ProcessData(namemap);

				foreach (NmapItem ni in nmap.Items)
				{
					string name = ni.Filename.Trim().ToLower();
					if (name.StartsWith(modelname) && name.EndsWith("_wallmask_txmt"))
					{
						IScenegraphFileIndexItem item =
							FileTableBase.FileIndex.FindFileByName(
								name,
								Data.MetaData.TXMT,
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

				Interfaces.Scenegraph.IScenegraphFileIndexItem item = FileTable.FileIndex.FindFileByName(nmn, Data.MetaData.TXMT, Data.MetaData.LOCAL_GROUP, true);

				if (item!=null) txmt.Add(item);
			}*/

			return txmt;
		}

		/// <summary>
		/// Add Wallmasks (if available) to the Clone
		/// </summary>
		/// <param name="modelnames"></param>
		/// <remarks>based on Instructions By Numenor</remarks>
		public void AddWallmasks(string[] modelnames)
		{
			foreach (string s in modelnames)
			{
				ArrayList txmt = LoadWallmask(s);

				foreach (
					IScenegraphFileIndexItem item in txmt
				)
				{
					GenericRcol sub = new GenericRcol(null, false);
					sub.ProcessData(item);
					LoadReferenced(
						this.modelnames,
						ExcludedReferences,
						files,
						itemlist,
						sub,
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
		protected ArrayList LoadAnim(string name)
		{
			ArrayList anim = new ArrayList();

			name = name.Trim().ToLower();
			if (!name.EndsWith("_anim"))
			{
				name += "_anim";
			}

			IScenegraphFileIndexItem item =
				FileTableBase.FileIndex.FindFileByName(
					name,
					Data.MetaData.ANIM,
					Data.MetaData.LOCAL_GROUP,
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
		public void AddAnims(string[] names)
		{
			foreach (string s in names)
			{
				ArrayList anim = LoadAnim(s);

				foreach (
					IScenegraphFileIndexItem item in anim
				)
				{
					GenericRcol sub = new GenericRcol(null, false);
					sub.ProcessData(item);
					LoadReferenced(
						modelnames,
						ExcludedReferences,
						files,
						itemlist,
						sub,
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
			Interfaces.Files.IPackedFileDescriptor[] pfds = pkg.FindFiles(
				Data.MetaData.REF_FILE
			);
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				ThreeIdr re = new ThreeIdr();
				re.ProcessData(pfd, pkg);

				foreach (Interfaces.Files.IPackedFileDescriptor p in re.Items)
				{
					IScenegraphFileIndexItem[] items =
						FileTableBase.FileIndex.FindFile(p, null);
					foreach (
						IScenegraphFileIndexItem item in items
					)
					{
						try
						{
							// if (item.FileDescriptor.Type == Data.MetaData.STRING_FILE)
							GenericRcol sub = new GenericRcol(null, false);
							sub.ProcessData(item);
							LoadReferenced(
								modelnames,
								ExcludedReferences,
								files,
								itemlist,
								sub,
								item,
								true,
								setup
							);
						}
						catch (Exception ex)
						{
							if (Helper.WindowsRegistry.HiddenMode)
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
				PackedFiles.Wrapper.Cpf cpf = new PackedFiles.Wrapper.Cpf();
				if (!cpf.CanHandleType(pfd.Type))
				{
					continue;
				}

				cpf.ProcessData(pfd, pkg);

				//xobj
				AddFromXml(cpf.GetItem("material"), "_txmt", Data.MetaData.TXMT);

				//hood object
				if (pfd.Type == Data.MetaData.XNGB)
				{
					AddFromXml(cpf.GetItem("modelname"), "_cres", Data.MetaData.CRES);
				}

				//fences
				AddFromXml(cpf.GetItem("diagrail"), "_cres", Data.MetaData.CRES);
				AddFromXml(cpf.GetItem("post"), "_cres", Data.MetaData.CRES);
				AddFromXml(cpf.GetItem("rail"), "_cres", Data.MetaData.CRES);
				AddFromXml(cpf.GetItem("diagrail"), "_txmt", Data.MetaData.TXMT);
				AddFromXml(cpf.GetItem("post"), "_txmt", Data.MetaData.TXMT);
				AddFromXml(cpf.GetItem("rail"), "_txmt", Data.MetaData.TXMT);

				//terrain
				AddFromXml(cpf.GetItem("texturetname"), "_txtr", Data.MetaData.TXTR);
				AddFromXml(
					cpf.GetItem("texturetname"),
					"_detail_txtr",
					Data.MetaData.TXTR
				);
				AddFromXml(
					cpf.GetItem("texturetname"),
					"-bump_txtr",
					Data.MetaData.TXTR
				);

				//roof
				AddFromXml(cpf.GetItem("textureedges"), "_txtr", Data.MetaData.TXTR);
				AddFromXml(cpf.GetItem("texturetop"), "_txtr", Data.MetaData.TXTR);
				AddFromXml(cpf.GetItem("texturetopbump"), "_txtr", Data.MetaData.TXTR);
				AddFromXml(cpf.GetItem("texturetrim"), "_txtr", Data.MetaData.TXTR);
				AddFromXml(cpf.GetItem("textureunder"), "_txtr", Data.MetaData.TXTR);

				IScenegraphFileIndexItem[] items =
					FileTableBase.FileIndex.FindFile(
						cpf.GetSaveItem("stringsetrestypeid").UIntegerValue,
						cpf.GetSaveItem("stringsetgroupid").UIntegerValue,
						cpf.GetSaveItem("stringsetid").UIntegerValue,
						null
					);
				AddFromXml(items);
			}
		}

		/// <summary>
		/// Add Resources referenced from XML Files
		/// </summary>
		protected void AddFromXml(
			PackedFiles.Wrapper.CpfItem item,
			string prefix,
			uint type
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
		protected void AddFromXml(string name, uint type)
		{
			IScenegraphFileIndexItem item =
				FileTableBase.FileIndex.FindFileByName(
					name,
					type,
					Data.MetaData.LOCAL_GROUP,
					true
				);
			AddFromXml(item);
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

			IScenegraphFileIndexItem[] items =
				new IScenegraphFileIndexItem[1];
			items[0] = item;
			AddFromXml(items);
		}

		/// <summary>
		/// Add Resources referenced from XML Files
		/// </summary>
		protected void AddFromXml(
			IScenegraphFileIndexItem[] items
		)
		{
			foreach (IScenegraphFileIndexItem item in items)
			{
				try
				{
					GenericRcol sub = new GenericRcol(null, false);
					sub.ProcessData(item);
					LoadReferenced(
						modelnames,
						ExcludedReferences,
						files,
						itemlist,
						sub,
						item,
						true,
						setup
					);
				}
				catch (Exception ex)
				{
					if (Helper.WindowsRegistry.HiddenMode)
					{
						Helper.ExceptionMessage("", ex);
					}
				}
			}
		}
		#endregion
	}
}
