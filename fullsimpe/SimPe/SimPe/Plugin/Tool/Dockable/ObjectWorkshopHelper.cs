// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using SimPe.Data;
using SimPe.Forms.MainUI;
using SimPe.PackedFiles.Cpf;

using Message = SimPe.Forms.MainUI.Message;

namespace SimPe.Plugin.Tool.Dockable
{
	/// <summary>
	/// This is a basic Structure that describes what Features should be enabled during  a OW Task
	/// </summary>
	public class ObjectWorkshopSettings : CloneSettings
	{
		internal ObjectWorkshopSettings()
			: base()
		{
			OpenWithRemoteControl = true;
			RemoteResult = false;
		}

		public bool OpenWithRemoteControl
		{
			get; set;
		}

		public bool RemoveNonDefaultTextReferences
		{
			get; set;
		}

		public bool RemoteResult
		{
			get; private set;
		}

		internal void SetRemoteResult(bool res)
		{
			RemoteResult = res;
		}
	}

	/// <summary>
	/// All Settings for a Clone
	/// </summary>
	public class OWCloneSettings : ObjectWorkshopSettings
	{
		public OWCloneSettings()
			: base()
		{
			CustomGroup = true;
			FixResources = true;
			RemoveUselessResource = true;
			StandAloneObject = false;
			ChangeObjectDescription = false;
			Price = 0;
			Title = "";
			Description = "";
			RemoveNonDefaultTextReferences = true;
		}

		public bool CustomGroup
		{
			get; set;
		}

		public bool FixResources
		{
			get; set;
		}

		public bool RemoveUselessResource
		{
			get; set;
		}

		public bool StandAloneObject
		{
			get; set;
		}

		public bool ChangeObjectDescription
		{
			get; set;
		}
		public short Price
		{
			get; set;
		}

		public string Title
		{
			get; set;
		}

		public string Description
		{
			get; set;
		}
	}

	/// <summary>
	/// All Settings for a Recolor
	/// </summary>
	public class OWRecolorSettings : ObjectWorkshopSettings
	{
		public OWRecolorSettings()
			: base()
		{
			IncludeAnimationResources = false;
			IncludeWallmask = false;
			OnlyDefaultMmats = false;
		}
	}

	public class ObjectWorkshopHelper
	{
		internal static void PrepareForClone(
			Interfaces.Files.IPackageFile package,
			Interfaces.IAlias current,
			out Interfaces.IAlias a,
			out uint localgroup,
			out Interfaces.Files.IPackedFileDescriptor pfd
		)
		{
			FileTableBase.FileIndex.Load();
			a = null;
			pfd = null;
			localgroup = Data.MetaData.LOCAL_GROUP;
			if (package != null)
			{
				if (package.FileName != null)
				{
					Interfaces.Wrapper.IGroupCacheItem gci =
						FileTableBase.GroupCache.GetItem(package.FileName);
					if (gci != null)
					{
						localgroup = gci.LocalGroup;
					}
				}
			}
			else
			{
				if (current != null)
				{
					a = current;
					pfd = (Interfaces.Files.IPackedFileDescriptor)a.Tag[0];
					localgroup = (uint)a.Tag[1];
				}
			}
		}

		protected static void PrepareForClone(
			Interfaces.Files.IPackageFile package,
			out Interfaces.IAlias a,
			out uint localgroup,
			out Interfaces.Files.IPackedFileDescriptor pfd,
			out OWCloneSettings cs
		)
		{
			PrepareForClone(
				package,
				null,
				out a,
				out localgroup,
				out pfd
			);

			cs = new OWCloneSettings
			{
				IncludeWallmask = false,
				OnlyDefaultMmats = false,
				IncludeAnimationResources = false,
				CustomGroup = false,
				FixResources = false,
				RemoveUselessResource = false,
				StandAloneObject = false,
				RemoveNonDefaultTextReferences = false,
				KeepOriginalMesh = false,
				PullResourcesByStr = true,
				ChangeObjectDescription = false,
				OpenWithRemoteControl = false
			};
		}

		/// <summary>
		/// Create a 1:1 Clone based on the passed Group Number
		/// </summary>
		/// <param name="gid"></param>
		/// <returns></returns>
		public static Packages.GeneratableFile CreatCloneByGroup(uint gid)
		{
			Packages.GeneratableFile package =
				Packages.File.CreateNew();
			PrepareForClone(
				package,
				out Interfaces.IAlias a,
				out uint localgroup,
				out Interfaces.Files.IPackedFileDescriptor pfd,
				out OWCloneSettings cs
			);

			BaseClone(gid, package, false);

			return Start(
				package,
				a,
				ref pfd,
				localgroup,
				cs,
				true
			);
		}

		/// <summary>
		/// Create a 1:1 Clone based on the passed GUID
		/// </summary>
		/// <param name="guid"></param>
		/// <returns></returns>
		public static Packages.GeneratableFile CreatCloneByGuid(uint guid)
		{
			Packages.GeneratableFile package =
				Packages.File.CreateNew();
			PrepareForClone(
				package,
				out Interfaces.IAlias a,
				out uint localgroup,
				out Interfaces.Files.IPackedFileDescriptor pfd,
				out OWCloneSettings cs
			);
			Interfaces.Scenegraph.IScenegraphFileIndex fii =
				FileTableBase.FileIndex.AddNewChild();

			Cache.MemoryCacheItem mci = Cache.Cache.GlobalCache.FindMemoryItem(guid);
			if (mci != null)
			{
				localgroup = mci.FileDescriptor.Group;
				if (localgroup == Data.MetaData.LOCAL_GROUP)
				{
					Interfaces.Wrapper.IGroupCacheItem gci =
						FileTableBase.GroupCache.GetItem(
							mci.ParentCacheContainer.FileName
						);
					if (gci != null)
					{
						if (
							!FileTableBase.FileIndex.Contains(
								mci.ParentCacheContainer.FileName
							)
						)
						{
							fii.AddIndexFromPackage(mci.ParentCacheContainer.FileName);
						}

						localgroup = gci.LocalGroup;
					}
				}
				BaseClone(localgroup, package, false);
			}

			Packages.GeneratableFile ret = Start(
				package,
				a,
				ref pfd,
				localgroup,
				cs,
				true
			);
			fii.CloseAssignedPackages();
			FileTableBase.FileIndex.RemoveChild(fii);

			return ret;
		}

		/// <summary>
		/// Create a 1:1 Clone based on the CRES Name
		/// </summary>
		/// <param name="cres"></param>
		/// <returns></returns>
		public static Packages.GeneratableFile CreatCloneByCres(string cres)
		{
			Packages.GeneratableFile package =
				Packages.File.CreateNew();
			PrepareForClone(
				package,
				out Interfaces.IAlias a,
				out uint localgroup,
				out Interfaces.Files.IPackedFileDescriptor pfd,
				out OWCloneSettings cs
			);

			PackedFiles.Wrapper.Str str = new PackedFiles.Wrapper.Str
			{
				FileDescriptor = new Packages.PackedFileDescriptor
				{
					Type = Data.FileTypes.STR,
					LongInstance = 0x85,
					Group = 0x7F000000
				}
			};
			package.Add(str.FileDescriptor);

			string name = cres.ToLower().Trim();
			if (!name.EndsWith("_cres"))
			{
				name += "_cres";
			}

			str.FileName = "Model - Names";
			str.Add(
				new PackedFiles.Wrapper.StrToken(
					0,
					(byte)Data.Languages.English,
					"",
					""
				)
			);
			str.Add(
				new PackedFiles.Wrapper.StrToken(
					1,
					(byte)Data.Languages.English,
					name,
					""
				)
			);
			str.SynchronizeUserData();

			str.FileDescriptor.MarkForDelete = true;

			return Start(
				package,
				a,
				ref pfd,
				localgroup,
				cs,
				true
			);
		}

		/// <summary>
		/// Clone an object based on way Files are linked
		/// </summary>
		/// <param name="pfd"></param>
		/// <param name="localgroup"></param>
		/// <param name="onlydefault"></param>
		protected static Packages.GeneratableFile RecolorClone(
			CloneSettings.BaseResourceType br,
			Packages.GeneratableFile ppkg,
			Interfaces.Files.IPackedFileDescriptor pfd,
			uint localgroup,
			ObjectWorkshopSettings settings,
			bool pkgcontainsonlybase
		)
		{
			Packages.GeneratableFile package = null;
			if (ppkg != null)
			{
				package = (Packages.GeneratableFile)ppkg.Clone();
			}

			if (ppkg == null || pkgcontainsonlybase)
			{
				if (!pkgcontainsonlybase)
				{
					package = Packages.File.CreateNew();
				}
				//Get the Base Object Data from the Objects.package File
				List<string> modelname = new List<string>();
				if (br == CloneSettings.BaseResourceType.Objd)
				{
					modelname = BaseClone(localgroup, package, pkgcontainsonlybase);
				}
				else
				{
					Interfaces.Scenegraph.IScenegraphFileIndexItem fii =
						FileTableBase.FileIndex.FindFile(pfd, null).FirstOrDefault();
					if (fii != null)
					{
						Interfaces.Files.IPackedFileDescriptor cpfd = fii.FileDescriptor.Clone();
						cpfd = cpfd.Clone();
						cpfd.UserData = fii.Package.Read(fii.FileDescriptor).UncompressedData;
						package.Add(cpfd);
					}
				}
				ObjectCloner objclone = new ObjectCloner(package);
				ArrayList exclude = new ArrayList();

				//allways for recolors
				if (settings is OWRecolorSettings)
				{
					exclude.Add("stdMatEnvCubeTextureName");
					exclude.Add("TXTR");
				}
				else
				{
					exclude.Add("tsMaterialsMeshName");
					exclude.Add("TXTR");
					exclude.Add("stdMatEnvCubeTextureName");
				}

				//do the recolor
				objclone.Setup = settings;
				objclone.Setup.BaseResource = br;
				objclone.Setup.OnlyDefaultMmats =
					settings.OnlyDefaultMmats
					&& br != CloneSettings.BaseResourceType.Xml
				;
				objclone.Setup.UpdateMmatGuids = objclone.Setup.OnlyDefaultMmats;
				/*objclone.Setup.IncludeWallmask = settings.IncludeWallmask;
				objclone.Setup.IncludeAnimationResources = settings.IncludeAnimationResources;
				objclone.Setup.KeepOriginalMesh = settings.KeepOriginalMesh;
				objclone.Setup.PullResourcesByStr = settings.PullResourcesByStr;
				objclone.Setup.StrInstances = settings.StrInstances;*/


				objclone.RcolModelClone(modelname, exclude);

				//for clones only when cbparent is checked
				if (settings is OWCloneSettings settings1)
				{
					if (
						settings1.StandAloneObject
						|| br == CloneSettings.BaseResourceType.Xml
					)
					{
						List<string> names = Scenegraph.LoadParentModelNames(package, true);
						Packages.File pkg = Packages.File.LoadFromFile(
							null
						);

						ObjectCloner pobj = new ObjectCloner(pkg)
						{
							Setup = settings
						};
						pobj.Setup.BaseResource = br;
						pobj.Setup.OnlyDefaultMmats =
							settings.OnlyDefaultMmats
							&& br != CloneSettings.BaseResourceType.Xml
						;
						pobj.Setup.UpdateMmatGuids = pobj.Setup.OnlyDefaultMmats;
						/*pobj.Setup.IncludeWallmask = settings.IncludeWallmask;
						pobj.Setup.IncludeAnimationResources = settings.IncludeAnimationResources;
						pobj.Setup.KeepOriginalMesh = settings.KeepOriginalMesh;
						pobj.Setup.PullResourcesByStr = settings.PullResourcesByStr;
						pobj.Setup.StrInstances = settings.StrInstances;*/


						pobj.RcolModelClone(names, exclude);
						pobj.AddParentFiles(modelname, package);
					}
					else
					{
						List<string> modelnames = modelname;
						if (!settings1.RemoveUselessResource)
						{
							modelnames = null;
						}

						objclone.RemoveSubsetReferences(
							Scenegraph.GetParentSubsets(package),
							modelnames
						);
					}
				}
			}

			return package;
		}

		static void LoadModelName(
			List<string> list,
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile pkg
		)
		{
			PackedFiles.Wrapper.Str str = new PackedFiles.Wrapper.Str();
			str.ProcessData(pfd, pkg);
			PackedFiles.Wrapper.StrItemList items = str.LanguageItems(1);
			for (int i = 1; i < items.Length; i++)
			{
				list.Add(items[i].Title);
			}

			str.Dispose();
		}

		/// <summary>
		/// Reads all Data from the Objects.package blonging to the same group as the passed pfd
		/// </summary>
		/// <param name="localgroup">Thr Group of the Source Object</param>
		/// <param name="package">The package that should get the Files</param>
		/// <param name="pkgcontainsbase">true, if the package does already contain the Base Object</param>
		/// <returns>The Modlename of that Object or null if none</returns>
		public static List<string> BaseClone(
			uint localgroup,
			Packages.File package,
			bool pkgcontainsbase
		)
		{
			//Get the Base Object Data from the Objects.package File
			List<string> list = new List<string>();
			if (pkgcontainsbase)
			{
				foreach (
					Interfaces.Files.IPackedFileDescriptor pfd in package.Index
				)
				{
					if (
						(pfd.Instance == 0x85)
						&& (pfd.Type == Data.FileTypes.STR)
					)
					{
						LoadModelName(list, pfd, package);
					}
				}
			}
			else
			{
				foreach (Interfaces.Scenegraph.IScenegraphFileIndexItem item in FileTableBase.FileIndex.FindFileByGroup(localgroup))
				{
					Interfaces.Files.IPackedFile file = item.Package.Read(
						item.FileDescriptor
					);

					Packages.PackedFileDescriptor npfd =
						new Packages.PackedFileDescriptor
						{
							UserData = file.UncompressedData,
							Group = item.FileDescriptor.Group,
							Instance = item.FileDescriptor.Instance,
							SubType = item.FileDescriptor.SubType,
							Type = item.FileDescriptor.Type
						};

					if (package.FindFile(npfd) == null)
					{
						package.Add(npfd);
					}

					if (
						(npfd.Instance == 0x85)
						&& (npfd.Type == Data.FileTypes.STR)
					)
					{
						LoadModelName(list, npfd, item.Package);
					}
				}
			}
			return list;
		}

		protected static Packages.GeneratableFile ReColorXObject(
			CloneSettings.BaseResourceType br,
			Packages.GeneratableFile pkg,
			Interfaces.Files.IPackedFileDescriptor pfd,
			uint localgroup,
			ObjectWorkshopSettings settings
		)
		{
			settings.KeepOriginalMesh = true;
			Packages.GeneratableFile package = pkg;
			// Low Eps need packages in the Gmaes and the Download Folder

			if (
				(
					!System.IO.File.Exists(ScenegraphHelper.GMND_PACKAGE)
					|| !System.IO.File.Exists(ScenegraphHelper.MMAT_PACKAGE)
				)
				&& (settings is OWCloneSettings)
				&& (PathProvider.Global.EPInstalled < 16)
			)
			{
				if (
					Message.Show(
						Localization.Manager.GetString("OW_Warning"),
						"Warning",
						MessageBoxButtons.YesNo
					) == DialogResult.No
				)
				{
					return package;
				}
			}

			SaveFileDialog sfd = new SaveFileDialog
			{
				Filter = ExtensionProvider.BuildFilterString(
				new ExtensionType[]
				{
					ExtensionType.Package,
					ExtensionType.AllFiles,
				}
			)
			};
			if (sfd.ShowDialog() != DialogResult.OK)
			{
				return package;
			}

			//create a Cloned Object to get all needed Files for the Process
			WaitingScreen.Wait();
			try
			{
				WaitingScreen.UpdateMessage("Collecting needed Files");

				if ((package == null) && (pfd != null))
				{
					package = RecolorClone(
						br,
						package,
						pfd,
						localgroup,
						settings,
						false
					);
				}
			}
			finally
			{
				WaitingScreen.Stop();
			}

			package.FileName = sfd.FileName;
			package.Save();

			return package;
		}

		protected static Packages.GeneratableFile ReColor(
			CloneSettings.BaseResourceType br,
			Packages.GeneratableFile pkg,
			Interfaces.Files.IPackedFileDescriptor pfd,
			uint localgroup,
			ObjectWorkshopSettings settings,
			bool pkgcontainsonlybase
		)
		{
			Packages.GeneratableFile package = pkg;
			// Low Eps need packages in the Gmaes and the Download Folder

			if (
				(
					!System.IO.File.Exists(ScenegraphHelper.GMND_PACKAGE)
					|| !System.IO.File.Exists(ScenegraphHelper.MMAT_PACKAGE)
				)
				&& (settings is OWCloneSettings)
				&& (PathProvider.Global.EPInstalled < 16)
			)
			{
				if (
					Message.Show(
						Localization.Manager.GetString("OW_Warning"),
						"Warning",
						MessageBoxButtons.YesNo
					) == DialogResult.No
				)
				{
					return package;
				}
			}

			SaveFileDialog sfd = new SaveFileDialog
			{
				Filter = ExtensionProvider.BuildFilterString(
				new ExtensionType[]
				{
					ExtensionType.Package,
					ExtensionType.AllFiles,
				}
			)
			};
			if (sfd.ShowDialog() != DialogResult.OK)
			{
				return package;
			}

			//create a Cloned Object to get all needed Files for the Process
			WaitingScreen.Wait();
			try
			{
				WaitingScreen.UpdateMessage("Collecting needed Files");
				if ((package == null) && (pfd != null))
				{
					package = RecolorClone(
						br,
						package,
						pfd,
						localgroup,
						settings,
						pkgcontainsonlybase
					);
				}
			}
			finally
			{
				WaitingScreen.Stop();
			}

			Packages.GeneratableFile npackage =
				Packages.File.CreateNew(); //.LoadFromStream((System.IO.BinaryReader)null);

			//Create the Templae for an additional MMAT
			npackage.FileName = sfd.FileName;

			ColorOptions cs = new ColorOptions(package);
			cs.Create(npackage);

			npackage.Save();
			package = npackage;

			WaitingScreen.Stop();
#if DEBUG
#else
			if (package != npackage)
				package = null;
#endif

			return package;
		}

		public static Packages.GeneratableFile Start(
			Packages.GeneratableFile pkg,
			Interfaces.IAlias a,
			ref Interfaces.Files.IPackedFileDescriptor pfd,
			uint localgroup,
			ObjectWorkshopSettings settings
		)
		{
			return Start(pkg, a, ref pfd, localgroup, settings, false);
		}

		public static Packages.GeneratableFile Start(
			Packages.GeneratableFile pkg,
			Interfaces.IAlias a,
			ref Interfaces.Files.IPackedFileDescriptor pfd,
			uint localgroup,
			ObjectWorkshopSettings settings,
			bool containsonlybaseclone
		)
		{
			Packages.GeneratableFile package = pkg;
			CloneSettings.BaseResourceType br =

				CloneSettings
				.BaseResourceType
				.Objd;
			if (pfd != null)
			{
				if (pfd.Type != Data.FileTypes.OBJD)
				{
					br = CloneSettings.BaseResourceType.Xml;
				}
			}

			if (settings is OWCloneSettings cs)
			{
				package = RecolorClone(
					br,
					package,
					pfd,
					localgroup,
					settings,
					containsonlybaseclone
				);

				FixObject fo = new FixObject(
					package,
					FixVersion.UniversityReady,
					settings.RemoveNonDefaultTextReferences
				);
				Hashtable map = null;

				if (cs.FixResources)
				{
					map = fo.GetNameMap(true);
					if (map == null)
					{
						return package;
					}

					SaveFileDialog sfd = new SaveFileDialog
					{
						Filter = ExtensionProvider.BuildFilterString(
						new ExtensionType[]
						{
							ExtensionType.Package,
							ExtensionType.AllFiles,
						}
					)
					};
					if (sfd.ShowDialog() == DialogResult.OK)
					{
						WaitingScreen.Wait();
						try
						{
							package.FileName = sfd.FileName;
							fo.Fix(map, true);

							if (
								cs.RemoveUselessResource
								&& br != CloneSettings.BaseResourceType.Xml
							)
							{
								fo.CleanUp();
							}

							package.Save();
						}
						finally
						{
							WaitingScreen.Stop();
						}
					}
					else
					{
						package = null;
					}
				}

				if (cs.CustomGroup && (package != null))
				{
					WaitingScreen.Wait();
					try
					{
						fo.FixGroup();
						if (cs.FixResources)
						{
							package.Save();
						}
					}
					finally
					{
						WaitingScreen.Stop();
					}
				}

				if (cs.ChangeObjectDescription)
				{
					UpdateDescription(cs, package);
				}

				//select a resource to display in SimPe
				pfd = null;
				if (package != null)
				{
					Interfaces.Files.IPackedFileDescriptor[] pfds =
						package.FindFiles(Data.FileTypes.OBJD);
					if (pfds.Length > 0)
					{
						pfd = pfds[0];
					}
				}
			}
			else
			{
				package = ReColor(
					br,
					package,
					pfd,
					localgroup,
					new OWRecolorSettings(),
					containsonlybaseclone
				);

				//select a resource for display in SimPe
				pfd = null;
				if (package != null)
				{
					Interfaces.Files.IPackedFileDescriptor[] pfds =
						package.FindFiles(Data.FileTypes.TXTR);
					if (pfds.Length > 0)
					{
						pfd = pfds[0];
					}
				}
			}

			settings.SetRemoteResult(false);
			if (settings.OpenWithRemoteControl)
			{
				if (package != null)
				{
					if (RemoteControl.OpenMemoryPackage(package) && pfd != null)
					{
						settings.SetRemoteResult(
							RemoteControl.OpenPackedFile(pfd, package)
						);
					}
				}
			}

			return package;
		}

		#region Update Object Description
		/// <summary>
		///
		/// </summary>
		/// <param name="cs"></param>
		/// <param name="cpf"></param>
		/// <returns>ResourceDescriptor for the references String</returns>
		protected static Interfaces.Files.IPackedFileDescriptor UpdateDescription(
			OWCloneSettings cs,
			Packages.GeneratableFile package,
			PackedFiles.Wrapper.ExtObjd obj
		)
		{
			obj.Price = cs.Price;
			obj.Data[0x22] = (short)Math.Floor(cs.Price * 0.035); // sale price
			obj.Data[0x23] = (short)Math.Floor(cs.Price * 0.15); // initial depreciation
			obj.Data[0x24] = (short)Math.Floor(cs.Price * 0.10); // daily depreciation
			obj.Data[0x25] = 0; // self depreciation
			obj.Data[0x26] = (short)Math.Floor(cs.Price * 0.40); // depreciation limit
			obj.SynchronizeUserData();
			Interfaces.Files.IPackedFileDescriptor pfd = package.FindFile(
				Data.FileTypes.CTSS,
				0,
				obj.FileDescriptor.Group,
				obj.CTSSInstance
			);

			return pfd;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="cs"></param>
		/// <param name="cpf"></param>
		/// <returns>ResourceDescriptor for the references String</returns>
		protected static Interfaces.Files.IPackedFileDescriptor UpdateDescription(
			OWCloneSettings cs,
			Packages.GeneratableFile package,
			Cpf cpf
		)
		{
			cpf.GetSaveItem("cost").UIntegerValue = (uint)cs.Price;
			cpf.GetSaveItem("name").StringValue = cs
				.Title.Replace("\n", " ")
				.Replace("\t", "    ")
				.Replace("\r", " ");
			cpf.GetSaveItem("description").StringValue = cs
				.Description.Replace("\n", " ")
				.Replace("\t", "    ")
				.Replace("\r", " ");
			cpf.SynchronizeUserData();

			Interfaces.Files.IPackedFileDescriptor pfd = package.FindFile(
				(FileTypes)cpf.GetSaveItem("stringsetrestypeid").UIntegerValue,
				0,
				cpf.GetSaveItem("stringsetgroupid").UIntegerValue,
				cpf.GetSaveItem("stringsetid").UIntegerValue
			);

			return pfd;
		}

		protected static void UpdateDescription(
			OWCloneSettings cs,
			PackedFiles.Wrapper.Str str
		)
		{
			str.ClearNonDefault();
			while (str.Items.Length < 2)
			{
				str.Add(
					new PackedFiles.Wrapper.StrToken(str.Items.Length, 1, "", "")
				);
			}

			str.Items[0].Title = cs.Title;
			str.Items[1].Title = cs.Description;

			str.SynchronizeUserData();
		}

		protected static void UpdateDescription(
			OWCloneSettings cs,
			Packages.GeneratableFile package
		)
		{
			//change the price in the OBJd
			PackedFiles.Wrapper.ExtObjd obj =
				new PackedFiles.Wrapper.ExtObjd();
			PackedFiles.Wrapper.Str str = new PackedFiles.Wrapper.Str();
			Interfaces.Files.IPackedFileDescriptor[] pfds = package.FindFiles(
				Data.FileTypes.OBJD
			);
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				obj.ProcessData(pfd, package);

				Interfaces.Files.IPackedFileDescriptor spfd = UpdateDescription(
					cs,
					package,
					obj
				);

				if (spfd != null)
				{
					str.ProcessData(spfd, package);
					UpdateDescription(cs, str);
				}
			}

			//change Price, Title, Desc in the XObj Files
			Cpf cpf = new Cpf();
			foreach (FileTypes t in new FileTypes[]
			{
				FileTypes.XFNC,
				FileTypes.XROF,
				FileTypes.XFLR,
				FileTypes.XOBJ,
			})
			{
				pfds = package.FindFiles(t);
				foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
				{
					cpf.ProcessData(pfd, package);
					Interfaces.Files.IPackedFileDescriptor spfd =
						UpdateDescription(cs, package, cpf);

					if (spfd != null)
					{
						str.ProcessData(spfd, package);
						UpdateDescription(cs, str);
					}
				}
			}

			if (package.FileName != null)
			{
				package.Save();
			}
		}
		#endregion
	}
}
