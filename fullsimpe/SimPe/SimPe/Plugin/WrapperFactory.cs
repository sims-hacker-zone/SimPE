// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

using pj;

using pjHoodTool;

using pjOBJDTool;

using pjse;

using SimPe.Data;
using SimPe.Interfaces;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Bnfo;
using SimPe.PackedFiles.Clst;
using SimPe.PackedFiles.Cpf;
using SimPe.PackedFiles.Creg;
using SimPe.PackedFiles.Famh;
using SimPe.PackedFiles.Fami;
using SimPe.PackedFiles.Famt;
using SimPe.PackedFiles.Fcns;
using SimPe.PackedFiles.Ginv;
using SimPe.PackedFiles.Glob;
using SimPe.PackedFiles.Goal;
using SimPe.PackedFiles.Grop;
using SimPe.PackedFiles.Gtip;
using SimPe.PackedFiles.Idno;
using SimPe.PackedFiles.Iidx;
using SimPe.PackedFiles.Init;
using SimPe.PackedFiles.Lifo;
using SimPe.PackedFiles.Lotd;
using SimPe.PackedFiles.Ltxt;
using SimPe.PackedFiles.Mmat;
using SimPe.PackedFiles.Ngbh;
using SimPe.PackedFiles.Nhtr;
using SimPe.PackedFiles.Nmap;
using SimPe.PackedFiles.Nref;
using SimPe.PackedFiles.Objd;
using SimPe.PackedFiles.Objf;
using SimPe.PackedFiles.Olua;
using SimPe.PackedFiles.Pepv;
using SimPe.PackedFiles.Picture;
using SimPe.PackedFiles.Pops;
using SimPe.PackedFiles.Rtex;
using SimPe.PackedFiles.Scid;
using SimPe.PackedFiles.Scor;
using SimPe.PackedFiles.Sdna;
using SimPe.PackedFiles.Sdsc;
using SimPe.PackedFiles.Slot;
using SimPe.PackedFiles.Smap;
using SimPe.PackedFiles.Str;
using SimPe.PackedFiles.Swaf;
using SimPe.PackedFiles.Tatt;
using SimPe.PackedFiles.ThreeIdr;
using SimPe.PackedFiles.Tprp;
using SimPe.PackedFiles.Trcn;
using SimPe.PackedFiles.Tree;
using SimPe.PackedFiles.Ttab;
using SimPe.PackedFiles.Txtr;
using SimPe.PackedFiles.Wlay;
using SimPe.PackedFiles.Wrapper;
using SimPe.PackedFiles.Wthr;
using SimPe.PackedFiles.Xml;
using SimPe.PackedFiles.Xwnt;
using SimPe.Wants;

namespace SimPe.Plugin
{
	/// <summary>
	/// Lists all Plugins (=FileType Wrappers) available in this Package
	/// </summary>
	/// <remarks>
	/// GetWrappers() has to return a list of all Plugins provided by this Library.
	/// If a Plugin isn't returned, SimPe won't recognize it!
	/// </remarks>
	public class WrapperFactory
		: AbstractWrapperFactory,
			ICommandLineFactory,
			IToolFactory
	{


		/// <summary>
		/// Loads the GroupCache
		/// </summary>
		public static void LoadGroupCache()
		{
			LoadGroupCache(false);
		}

		/// <summary>
		/// Loads the GroupCache
		/// </summary>
		/// <param name="force">Will force the load of the GroupsCache even
		/// if <see cref="Helper.WindowsRegistry.Config.UseMaxisGroupsCache"/> is set to false</param>
		public static void LoadGroupCache(bool force)
		{
			if (FileTableBase.GroupCache != null)
			{
				return;
			}

			GroupCache gc =
				new GroupCache();

			if (!Helper.WindowsRegistry.Config.UseMaxisGroupsCache && !force)
			{
				FileTableBase.GroupCache = gc;
				return;
			}
			try
			{
				string name = System.IO.Path.Combine(
					PathProvider.SimSavegameFolder,
					"Groups.cache"
				);

				if (System.IO.File.Exists(name))
				{
					Packages.File pkg = Packages.File.LoadFromFile(name);
					Interfaces.Files.IPackedFileDescriptor pfd = pkg.FindFile(
						FileTypes.GROP,
						0,
						1,
						1
					);
					if (pfd != null)
					{
						gc.ProcessData(pfd, pkg, false);
					}
				}
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					new Warning("Unable to load groups.cache", ex.Message, ex)
				);
			}

			FileTableBase.GroupCache = gc;
		}

		/// <summary>
		/// Creates the Class
		/// </summary>
		public WrapperFactory()
			: base()
		{
			//prepare the FileIndex
			FileTableBase.FileIndex = new FileIndex();
			Packages.PackageMaintainer.Maintainer.FileIndex =
				FileTableBase.FileIndex.AddNewChild();
		}

		#region AbstractWrapperFactory Member
		/// <summary>
		/// Returns a List of all available Plugins in this Package
		/// </summary>
		/// <returns>A List of all provided Plugins (=FileType Wrappers)</returns>
		public override IWrapper[] KnownWrappers
		{
			get
			{
				if (Helper.NoPlugins)
				{
					return new IWrapper[0];
				}
				else
				{
					SdscFreetime.RegisterAsAspirationEditor(
						new SimAspirationEditor()
					);
					FileTableBase.ProviderRegistry.LotProvider.LoadingLot +=
						new Interfaces.Providers.LoadLotData(
							LotProvider_LoadingLot
						);
					return new IWrapper[]
					{
						new Picture(),
						new Xml(),
						new Fami(LinkedProvider.SimNameProvider),
						new Cpf(),
						new Nref(),
						new ExtObjd(),
						new Glob(),
						new ObjLua(),
						new Clst(),
						new ThreeIdr(),
						new Txtr(LinkedProvider, false),
						new Lifo(LinkedProvider, false),
						// new Plugin.Shpe(this.LinkedProvider),
						new GenericRcol(LinkedProvider, false),
						new MmatWrapper(),
						new GroupCache(),
						new Slot(),
						new Nmap(LinkedProvider),
						new EnhancedNgbh(),
						new Ngbh(LinkedProvider),
						new Ltxt(LinkedProvider),
						new Swaf(LinkedProvider),
						new XWant(),
						new Idno(),
						new RoadTexture(),
						new Tatt(),
						new Bnfo(),
						new Nhtr(),
						new Lot(),
						new Bcon(),
						new Bhav(),
						new Objf(),
						new StrWrapper(),
						new TPRP(),
						new Trcn(),
						new Ttab(),
						new TreesPackedFileWrapper(),
						new Famh(),
						new ExtFamilyTies(),
						new LinkedSDesc(),
						new ExtSrel(),
						new SimDNA(),
						new Scor(),
						new Gtip(),
						new LastEPusePackedFileWrapper(),
						new Ginv(),
						new XGoal(),
						new Scid(),
						new Fcns(),
						new SimpleTextPackedFileWrapper(),
						new SimListPackedFileWrapper(),
						new HugBugPackedFileWrapper(),
						new AudioRefPackedFileWrapper(),
						new InvenIndexPackedFileWrapper(),
						new InventItemPackedFileWrapper(),
						new WinfoPackedFileWrapper(),
						new LotexturePackedFileWrapper(),
						new Creg(),
						new WallLayerPackedFileWrapper(),
						new StringMapPackedFileWrapper(),
						new SWAFWrapper(),
						new XWNTWrapper(),
					};
				}
			}
		}

		#endregion

		#region IToolFactory Member

		public IToolPlugin[] KnownTools => new IToolPlugin[]
				{
				};

		#endregion


		#region ICommandLineFactory Members

		public ICommandLine[] KnownCommandLines => new ICommandLine[] { new BuildTxtr(), new FixPackage(), new cHoodTool() };

		#endregion

		private void LotProvider_LoadingLot(
			object sender,
			Interfaces.Providers.ILotItem item
		)
		{
			Interfaces.Files.IPackageFile pkg = FileTableBase
				.ProviderRegistry
				.SimDescriptionProvider
				.BasePackage;
			if (pkg != null)
			{
				Providers.LotProvider.LotItem li =
					item as Providers.LotProvider.LotItem;
				//SimPe.Interfaces.Files.IPackedFileDescriptor pfd = pkg.FindFile(FileTypes.LTXT, 0, Data.MetaData.LOCAL_GROUP, item.Instance);
				if (item.LtxtFileIndexItem != null)
				{
					Ltxt ltxt = new Ltxt().ProcessFile(item.LtxtFileIndexItem);
					item.Tags.Add(ltxt);
					li.Owner = ltxt.OwnerInstance;
				}
			}
		}
	}
}
