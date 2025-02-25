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
using SimPe.Interfaces.Files;
using SimPe.Packages;

namespace SimPe.Plugin
{
	/// <summary>
	/// Creates a new Color Option package based on the passed package
	/// </summary>
	public class ColorOptions
	{
		/// <summary>
		/// The Base Package
		/// </summary>
		IPackageFile package;

		/// <summary>
		/// The tempory new package
		/// </summary>
		//IPackageFile newpkg;

		/// <summary>
		/// The Base Package
		/// </summary>
		public IPackageFile Package
		{
			get { return package; }
		}

		/// <summary>
		/// Create a new Instance
		/// </summary>
		/// <param name="package">the source package</param>
		public ColorOptions(IPackageFile package)
		{
			this.package = package;
		}

		/// <summary>
		/// Add a small Scenegraph Chain
		/// </summary>
		/// <param name="newpkg"></param>
		/// <param name="mmat">the MAterial override File for this Subset</param>
		/// <param name="txmtname">Name of the MAster TXMT</param>
		/// <param name="unique">A unique String for the Filenames</param>
		void LoadSlaveTxmt(
			IPackageFile newpkg,
			SimPe.Plugin.MmatWrapper mmat,
			string txmtname,
			string unique,
			Hashtable slavemap
		)
		{
			foreach (string k in slavemap.Keys)
			foreach (string slave in (ArrayList)slavemap[k])
			{
				string newname = txmtname.Replace("_" + k + "_", "_" + slave + "_");
				if (newname != txmtname)
				{
					Interfaces.Files.IPackedFileDescriptor[] pfds = package.FindFile(
						newname,
						Data.MetaData.TXMT
					);
					if (pfds.Length > 0)
					{
						GenericRcol txmt = new GenericRcol(null, false);
						txmt.ProcessData(pfds[0], package);

						AddTxmt(newpkg, mmat, txmt, null, unique, null);
					}
				}
			}
		}

		/// <summary>
		/// Add a small Scenegraph Chain
		/// </summary>
		/// <param name="mmat">the MAterial override File for this Subset</param>
		/// <param name="txmt">The Material Definition File for this Subset</param>
		/// <param name="txtr">The Txtr File for this Subset (can be null)</param>
		/// <param name="unique">A unique String for the Filenames</param>
		/// <param name="slavemap">The Slavemap as generated by Scenegraph.GetSlaveSubsets() (if null, no slave txmts are loaded)</param>
		void AddTxmt(
			IPackageFile newpkg,
			SimPe.Plugin.MmatWrapper mmat,
			GenericRcol txmt,
			GenericRcol txtr,
			string unique,
			Hashtable slavemap
		)
		{
			//Get/Update Material Definition
			if (txmt != null)
			{
				string name = Hashes.StripHashFromName(txmt.FileName.Trim());

				//load Slave TXMTs
				if (slavemap != null)
					LoadSlaveTxmt(newpkg, mmat, name, unique, slavemap);

				if (name.ToLower().EndsWith("_txmt"))
					name = name.Substring(0, name.Length - 5);
				txmt.FileName = FixObject.GetUniqueTxmtName(
					name,
					unique,
					mmat.SubsetName,
					true
				);
				///*"##0x"+Helper.HexString(Data.MetaData.CUSTOM_GROUP)+"!"+*/name+"_"+unique+"_txmt";
				txmt.FileDescriptor = ScenegraphHelper.BuildPfd(
					txmt.FileName,
					Data.MetaData.TXMT,
					Data.MetaData.CUSTOM_GROUP
				);

				mmat.Name =
					"##0x"
					+ Helper.HexString(txmt.FileDescriptor.Group)
					+ "!"
					+ FixObject.GetUniqueTxmtName(name, unique, mmat.SubsetName, false);

				MaterialDefinition md = (MaterialDefinition)txmt.Blocks[0];
				if (txtr == null)
				{
					txtr = mmat.GetTxtr(txmt);
					if (txtr != null)
						txtr.FileDescriptor = (Interfaces.Files.IPackedFileDescriptor)
							txtr.FileDescriptor.Clone();
				}

				//Get/Update Texture
				if (txtr != null)
				{
					name = AddTxtr(txtr, unique, txmt, md);

					md.FileDescription = Hashes.StripHashFromName(txmt.FileName).Trim();
					if (md.FileDescription.ToLower().EndsWith("_txmt"))
						md.FileDescription = md.FileDescription.Substring(
							0,
							md.FileDescription.Length - 5
						);
				}

				if (txtr != null)
				{
					txtr.SynchronizeUserData();
					if (newpkg.FindFile(txtr.FileDescriptor) == null)
						newpkg.Add(txtr.FileDescriptor);
				}

				AddReferencedTxtr(newpkg, txmt, md, unique);

				if (txmt != null)
				{
					txmt.SynchronizeUserData();
					if (newpkg.FindFile(txmt.FileDescriptor) == null)
						newpkg.Add(txmt.FileDescriptor);
				}
			}
		}

		protected string AddTxtr(
			GenericRcol txtr,
			string unique,
			GenericRcol txmt,
			MaterialDefinition md
		)
		{
			string old = Hashes.StripHashFromName(txtr.FileName.Trim().ToLower());
			if (old.EndsWith("_txtr"))
				old = old.Substring(0, old.Length - 5);
			//Console.WriteLine("Adding Texture: "+old);

			string name = txtr.FileName.Trim();
			if (name.ToLower().EndsWith("_txtr"))
				name = name.Substring(0, name.Length - 5);

			string tname = RenameForm.ReplaceOldUnique(name, unique, true);
			txtr.FileName = tname + "_txtr";

			txtr.FileDescriptor = ScenegraphHelper.BuildPfd(
				txtr.FileName,
				Data.MetaData.TXTR,
				Data.MetaData.CUSTOM_GROUP
			);

			for (int i = 0; i < md.Listing.Length; i++)
			{
				if (Hashes.StripHashFromName(md.Listing[i].Trim().ToLower()) == old)
					md.Listing[i] =
						"##0x"
						+ Helper.HexString(Data.MetaData.CUSTOM_GROUP)
						+ "!"
						+ tname;
			}

			//update References
			foreach (string k in txmt.ReferenceChains.Keys)
			{
				if (k == "TXTR" || k == "Generic")
					continue;
				//Console.WriteLine("    Checking Property "+k);
				string thisname = Hashes.StripHashFromName(
					md.FindProperty(k).Value.Trim().ToLower()
				);

				if (thisname == old)
				{
					string nname =
						"##0x"
						+ Helper.HexString(Data.MetaData.CUSTOM_GROUP)
						+ "!"
						+ tname;
					//Console.WriteLine("    --> Updating to "+nname);
					md.FindProperty(k).Value = nname;
				}
			}

			//Load the Lifos into the Texture File
			ImageData id = (ImageData)txtr.Blocks[0];
			id.GetReferencedLifos();

			return name;
		}

		protected string AddTxtr(
			IPackageFile newpkg,
			GenericRcol txtr,
			string unique,
			GenericRcol txmt,
			MaterialDefinition md
		)
		{
			string name = AddTxtr(txtr, unique, txmt, md);
			txtr.SynchronizeUserData();
			if (newpkg.FindFile(txtr.FileDescriptor) == null)
				newpkg.Add(txtr.FileDescriptor);

			return name;
		}

		/// <summary>
		/// This adds all second Leve Textures to the Recolor (like normal Maps)
		/// </summary>
		/// <param name="newpkg"></param>
		/// <param name="md"></param>
		protected void AddReferencedTxtr(
			IPackageFile newpkg,
			GenericRcol txmt,
			MaterialDefinition md,
			string unique
		)
		{
			foreach (string k in txmt.ReferenceChains.Keys)
			{
				if (k.ToLower() == "stdmatnormalmaptexturename") //at the moment i only know of NormalMaps that need to be added
				{
					MaterialDefinitionProperty mdp = md.GetProperty(k);
					if (mdp != null)
					{
						string name = Hashes.StripHashFromName(mdp.Value).Trim();
						if (!name.EndsWith("_txtr"))
							name += "_txtr";
						IPackageFile pkg = txmt.Package;
						SimPe.Interfaces.Files.IPackedFileDescriptor[] pfds =
							pkg.FindFile(name, Data.MetaData.TXTR);
						if (pfds.Length > 0)
						{
							SimPe.Interfaces.Files.IPackedFileDescriptor pfd = pfds[0];
							GenericRcol txtr = new GenericRcol();
							txtr.ProcessData(pfd, pkg);
							AddTxtr(newpkg, txtr, unique, txmt, md);
						}
					}
				}
			}
		}

		/// <summary>
		/// Adds the MMAT Files specified in the map to the new package
		/// </summary>
		/// <param name="newpkg"></param>
		/// <param name="map">Contains the MMATs that should be added</param>
		/// <param name="fullmap">Contains a List of all available MMATs</param>
		public void ProcessMmatMap(
			IPackageFile newpkg,
			Hashtable map,
			Hashtable fullmap
		)
		{
			if (WaitingScreen.Running)
				WaitingScreen.UpdateMessage("Loading Slave Subsets");
			AddSlavesSubsets(map, fullmap);
			Hashtable slaves = Scenegraph.GetSlaveSubsets(package);

			uint inst = 0x6000;
			string unique = RenameForm.GetUniqueName(true);
			foreach (Hashtable ht in map.Values)
			{
				foreach (ArrayList list in ht.Values)
				{
					string family = System.Guid.NewGuid().ToString();
					if (unique == null)
						unique = family;

					foreach (SimPe.Plugin.MmatWrapper mmat in list)
					{
						mmat.FileDescriptor = Scenegraph.Clone(mmat.FileDescriptor);
						mmat.FileDescriptor.Instance = inst++;
						mmat.FileDescriptor.Group = Data.MetaData.LOCAL_GROUP;
						mmat.Family = family;
						mmat.DefaultMaterial = false;

						GenericRcol txmt = mmat.TXMT;
						GenericRcol txtr = mmat.TXTR;
						this.AddTxmt(newpkg, mmat, txmt, txtr, unique, slaves);

						mmat.SynchronizeUserData();
						newpkg.Add(mmat.FileDescriptor);
					}
				}
			}
		}

		/// <summary>
		/// Returns the first MMAT file that links to the same Texture File as the passed mmat.
		/// </summary>
		/// <param name="fullmap"></param>
		/// <param name="subset"></param>
		/// <returns></returns>
		/// <param name="mmat">If none was found, the first MMAT will be returned. Can also be null if no MMATS are available</param>
		protected ArrayList FindTxtrMatchingMmat(
			SimPe.Plugin.MmatWrapper mmat,
			Hashtable fullmap,
			string subset
		)
		{
			ArrayList ret = null;

			if ((fullmap.ContainsKey(subset)) && mmat.TXTR != null)
			{
				Hashtable ht = (Hashtable)fullmap[subset];
				foreach (ArrayList list in ht.Values)
				{
					foreach (SimPe.Plugin.MmatWrapper cur in list)
					{
						if (ret == null)
							ret = list;
						if (cur.TXTR == null)
							continue;

						if (mmat.TXTR.FileName == cur.TXTR.FileName)
							return list;
					}
				}
			}
			return ret;
		}

		/// <summary>
		/// Adds the SlaveSubsets to the map
		/// </summary>
		/// <param name="map">Contains the MMATs that should be added</param>
		/// <param name="fullmap">Contains a List of all available MMATs</param>
		/// <remarks>The slave MMAT files will be added to the map</remarks>
		protected void AddSlavesSubsets(Hashtable map, Hashtable fullmap)
		{
			Hashtable slavemap = Scenegraph.GetSlaveSubsets(package);
			Hashtable newmap = new Hashtable();

			int ct = 0;
			foreach (string k in map.Keys)
			{
				if (!fullmap.ContainsKey(k))
					if (slavemap.ContainsKey(k))
					{
						if (map.ContainsKey(k))
						{
							ArrayList slaves = (ArrayList)slavemap[k];
							Hashtable families = (Hashtable)map[k];
							foreach (ArrayList list in families.Values)
							{
								foreach (SimPe.Plugin.MmatWrapper mmat in list)
								{
									foreach (string subset in slaves)
									{
										ArrayList slavemmat = this.FindTxtrMatchingMmat(
											mmat,
											fullmap,
											subset
										);
										if (slavemmat != null)
										{
											Hashtable slaveht = new Hashtable();
											slaveht[
												"simpe_slave_loader_"
													+ subset
													+ "-"
													+ ct.ToString()
											] = slavemmat;
											newmap[subset] = slaveht;
											ct++;
										}
									} //foreach subset
								} //foreach mmat
							} //foreach list
						} //if (map.ContainsKey(k))
					}
			}

			Hashtable nmap = new Hashtable();
			foreach (string k in newmap.Keys)
				if (!map.ContainsKey(k))
					nmap[k] = newmap[k];

			if (newmap.Count > 0)
				AddSlavesSubsets(nmap, fullmap);
			foreach (string k in nmap.Keys)
				map[k] = nmap[k];
		}

		public delegate void CreateSelectionCallback(
			SubsetSelectForm ssf,
			bool userselect,
			Hashtable fullmap
		);

		/// <summary>
		/// Create a new Color Options package
		/// </summary>
		/// <param name="newpkg">The Package the color Option should be added to</param>
		/// <param name="ask">if ask is true, a Dialog will be displayed that lets the
		/// user decide which Subsets to recolor</param>
		public void Create(IPackageFile newpkg)
		{
			WaitingScreen.Wait();
			try
			{
				//this.newpkg = newpkg;

				WaitingScreen.UpdateMessage("Loading available Color Options");
				Hashtable fullmap = Scenegraph.GetMMATMap(package);
				Hashtable map = fullmap;
				ArrayList allowedSubsets = Scenegraph.GetRecolorableSubsets(package);

				//Check if the User can select a Subset
				bool userselect = false;
				if (map.Count > 1)
					userselect = true;
				else
				{
					if (map.Count == 1)
					{
						foreach (string s in map.Keys)
						{
							Hashtable ht = (Hashtable)map[s];
							if (ht.Count > 1)
								userselect = true;
						}
					}
				}

				//let the user Select now
				if (userselect)
					map = SubsetSelectForm.Execute(map, allowedSubsets);

				ProcessMmatMap(newpkg, map, fullmap);
			}
			finally
			{
				WaitingScreen.Stop();
			}
		}

		/// <summary>
		/// Create a new Color Options package
		/// </summary>
		/// <param name="newpkg">The Package the color Option should be added to</param>
		/// <param name="fkt">The function that ahs to be called wne the Selection should be displayed</param>
		public void Create(IPackageFile newpkg, CreateSelectionCallback fkt)
		{
			WaitingScreen.Wait();
			try
			{
				//this.newpkg = newpkg;

				WaitingScreen.UpdateMessage("Loading available Color Options");
				Hashtable fullmap = Scenegraph.GetMMATMap(package);
				Hashtable map = fullmap;
				ArrayList allowedSubsets = Scenegraph.GetRecolorableSubsets(package);

				//Check if the User can select a Subset
				bool userselect = false;
				if (map.Count > 1)
					userselect = true;
				else
				{
					if (map.Count == 1)
					{
						foreach (string s in map.Keys)
						{
							Hashtable ht = (Hashtable)map[s];
							if (ht.Count > 1)
								userselect = true;
						}
					}
				}

				SubsetSelectForm ssf = SubsetSelectForm.Prepare(map, allowedSubsets);
				fkt(ssf, userselect, fullmap);
			}
			finally
			{
				WaitingScreen.Stop();
			}
			return;
			/*string[] subsets = GetSubsets();

			//let the user Select
			if ((subsets.Length>1) && (ask))
			{
				Listing l = new Listing();
				subsets = l.Execute(subsets);
			}

			WaitingScreen.Wait();
			WaitingScreen.UpdateMessage("Getting slave Subsets");
			SubsetItem[] subsetsi = GetSlaveSubsets(subsets);

			WaitingScreen.UpdateMessage("Getting Resource Nodes");
			ArrayList cres = GetCresNames(subsetsi);

			WaitingScreen.UpdateMessage("Getting Material Overrides");
			Hashtable mmats = GetMMATs(subsetsi, cres);
			ArrayList guids = GetGUIDs();

			LoadSubSetList(mmats, guids, subsetsi);

			WaitingScreen.UpdateMessage("Load LIFO Files");
			GetLifoFiles();

			WaitingScreen.Stop();*/
		}
	}
}
