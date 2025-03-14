// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using SimPe.Data;
using SimPe.Interfaces;
using SimPe.Interfaces.Files;
using SimPe.PackedFiles.Fami;
using SimPe.PackedFiles.Sdsc;

namespace SimPe.Providers
{
	/// <summary>
	/// Provides an Alias Matching a SimID with it's Name
	/// </summary>
	public class SimFamilyNames
		: SimCommonPackage,
			Interfaces.Providers.ISimFamilyNames
	{
		/// <summary>
		/// List of known Aliases (can be null)
		/// </summary>
		private Hashtable names;

		/// <summary>
		/// Creates the List for the specific Folder
		/// </summary>
		/// <param name="folder">The Base Package</param>
		public SimFamilyNames(IPackageFile package)
			: base(package) { }

		/// <summary>
		/// Creates the List for the specific Folder
		/// </summary>
		public SimFamilyNames()
			: base(null) { }

		/// <summary>
		/// Loads all package Files in the directory and scans them for Name Informations
		/// </summary>
		public void LoadSimsFromFolder()
		{
			names = new Hashtable();
			if (BasePackage == null)
			{
				return;
			}

			Fami fami = new Fami(null);
			Hashtable al = new Hashtable();
			foreach (FileTypes type in fami.AssignableTypes)
			{
				IPackedFileDescriptor[] list = BasePackage.FindFiles(type);

				foreach (IPackedFileDescriptor pfd in list)
				{
					fami.ProcessData(pfd, BasePackage);
					al[(ushort)pfd.Instance] = fami.Name;

					foreach (uint simid in fami.Members)
					{
						Alias a = new Alias(simid, fami.Name);
						if (!names.Contains(simid))
						{
							names.Add(simid, a);
						}
					}
				}
			} //foreach

			///add unlisted Sims
			foreach (
				SDesc sdesc in FileTableBase
					.ProviderRegistry
					.SimDescriptionProvider
					.SimInstance.SelectMany(item => item)
			)
			{
				//load extern Fami Name
				if (!names.Contains(sdesc.SimId))
				{
					if (
						sdesc.Package.SaveFileName.Trim().ToLower()
						!= BasePackage.SaveFileName.Trim().ToLower()
					)
					{
						IPackageFile pkg = sdesc.Package;
						if (pkg != null)
						{
							IPackedFileDescriptor pfd =
								pkg.FindFile(
									fami.AssignableTypes[0],
									0,
									MetaData.LOCAL_GROUP,
									sdesc.FamilyInstance
								);
							if (pfd != null)
							{
								fami.ProcessData(pfd, pkg);
								Alias a = new Alias(sdesc.SimId, fami.Name);
								names.Add(sdesc.SimId, a);
							}
						}
					}
					else
					{
						object o = al[sdesc.FamilyInstance];
						if (o != null)
						{
							Alias a = new Alias(sdesc.SimId, o.ToString());
							names.Add(sdesc.SimId, a);
						}
					}
				}
			}

			al.Clear();
			/*names = new Alias[al.Count];
			al.CopyTo(names);*/
		}

		/// <summary>
		/// Returns the the Alias with the specified Type
		/// </summary>
		/// <param name="id">The id of a Sim</param>
		/// <returns>The Alias of the Sim</returns>
		public IAlias FindName(uint id)
		{
			if (names == null)
			{
				LoadSimsFromFolder();
			}

			object o = names[id];
			return o != null ? (IAlias)o : new Alias(id, "Unknown");
		}

		/// <summary>
		/// Returns a List of All SimID's found in the Package
		/// </summary>
		/// <returns>The List of found SimID's</returns>
		public IEnumerable<(uint SimId, ushort FamilyInstance)> GetAllSimIDs()
		{
			return from items in FileTableBase.ProviderRegistry.SimDescriptionProvider.SimInstance
				   from sdesc in items
				   select (sdesc.SimId, sdesc.FamilyInstance);
		}

		/// <summary>
		/// Called if the BaseBackae was changed
		/// </summary>
		protected override void OnChangedPackage()
		{
			names = null;
		}
	}
}
