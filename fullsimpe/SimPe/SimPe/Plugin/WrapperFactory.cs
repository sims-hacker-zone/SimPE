// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

using pj;

using pjHoodTool;

using pjOBJDTool;

using pjse;

using SimPe.Interfaces;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Bnfo;
using SimPe.PackedFiles.Cpf;
using SimPe.PackedFiles.Idno;
using SimPe.PackedFiles.Ltxt;
using SimPe.PackedFiles.Nmap;
using SimPe.PackedFiles.Nref;
using SimPe.PackedFiles.Scid;
using SimPe.PackedFiles.Tatt;
using SimPe.PackedFiles.ThreeIdr;
using SimPe.PackedFiles.Ttab;
using SimPe.PackedFiles.Txtr;
using SimPe.PackedFiles.Wrapper;
using SimPe.PackedFiles.Xml;
using SimPe.Plugin.Tool;
using SimPe.Plugin.Tool.Action;
using SimPe.Plugin.Tool.Dockable;
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
		static bool inited = false;

		ResourceDock rd = new ResourceDock();

		/// <summary>
		/// Add all other default RCol Extensions
		/// </summary>
		public static void InitRcolBlocks()
		{
			if (!inited)
			{
				Rcol.TokenAssemblies.Add(
					typeof(GeometryDataContainer).Assembly
				);
				inited = true;
			}
		}

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
		/// if <see cref="Helper.WindowsRegistry.UseMaxisGroupsCache"/> is set to false</param>
		public static void LoadGroupCache(bool force)
		{
			if (FileTableBase.GroupCache != null)
			{
				return;
			}

			GroupCache gc =
				new GroupCache();

			if (!Helper.WindowsRegistry.UseMaxisGroupsCache && !force)
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
						0x54535053,
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
					InitRcolBlocks();
					SdscFreetime.RegisterAsAspirationEditor(
						new SimAspirationEditor()
					);
					FileTableBase.ProviderRegistry.LotProvider.LoadingLot +=
						new Interfaces.Providers.LoadLotData(
							LotProvider_LoadingLot
						);
					IWrapper[] wrappers =
					{
						new Picture(),
						new Xml(),
						new Fami(LinkedProvider.SimNameProvider),
						new Cpf(),
						new Nref(),
						new ExtObjd(),
						new Glob(),
						new ObjLua(),
						new CompressedFileList(),
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
						new Want(LinkedProvider),
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
						new FamiuPackedFileWrapper(),
						new ExtFamilyTies(),
						new LinkedSDesc(),
						new ExtSrel(),
						new SimDNA(),
						new Scor(),
						new GametipPackedFileWrapper(),
						new LastEPusePackedFileWrapper(),
						new GWInvPackedFileWrapper(),
						new XGoal(),
						new Scid(),
						new FunctionPackedFileWrapper(),
						new SimpleTextPackedFileWrapper(),
						new SimmyListPackedFileWrapper(),
						new HugBugPackedFileWrapper(),
						new AudioRefPackedFileWrapper(),
						new InvenIndexPackedFileWrapper(),
						new InventItemPackedFileWrapper(),
						new WinfoPackedFileWrapper(),
						new LotexturePackedFileWrapper(),
						new CregPackedFileWrapper(),
						new WallLayerPackedFileWrapper(),
						new StringMapPackedFileWrapper(),
						new SWAFWrapper(),
						new XWNTWrapper(),
					};
					return wrappers;
				}
			}
		}

		#endregion

		#region IToolFactory Member

		public IToolPlugin[] KnownTools => new IToolPlugin[]
				{
					new NeighborhoodTool(LinkedRegistry, LinkedProvider),
					new SimsTool(LinkedRegistry, LinkedProvider),
					new SurgeryTool(LinkedRegistry, LinkedProvider),
					new HashTool(LinkedRegistry, LinkedProvider),
					new FixTool(LinkedRegistry, LinkedProvider),
					new SkinWorkshopTool(),
					new PhotoStudioTool(LinkedRegistry, LinkedProvider),
					new ActionGlobalFixTGI(),
					new ActionBuildNameMap(),
					new ImportSemiTool(LinkedRegistry, LinkedProvider),
					new OpenLuaTool(),
					new SearchTool(LinkedRegistry, LinkedProvider),
					new ActionIntriguedNeighborhood(),
					new ActionDeleteSim(),
					new GeneticCategorizerTool(),
					new pjse.guidtool.GUIDTool(),
					new CareerTool(LinkedRegistry, LinkedProvider),
					new tOBJDTool(LinkedRegistry, LinkedProvider),
					new cHoodTool(),
					new PackageDockTool(rd),
					new ResourceDockTool(rd),
					new WrapperDockTool(rd),
					new HexDecConverterTool(rd),
					new ActionReloadFiletable(),
					new ActionUniqueInstance(),
					new CreateListFromPackageTool(),
					new CreateListFromSelectionTool(),
					new HexDockTool(rd),
					new FinderDock(),
					new Tool.Window.InstallerTool(),
					new SaveSims2PackTool(),
					new LoadSims2PackTool(),
					new ObectWorkshopDockTool(),
					new PackageDetailDockTool(),
					new Tool.Window.PackageRepairTool(),
					new AnimTool(),
					new FileTableTool(),
					new cHoodTool(),
					new cObjKeyTool(),
					new BodyMeshExtractor(),
					new BodyMeshLinker(),
#if DEBUG
					new ActionCheckFiletable(),
					new ActionBuildPhpGuidList(),
					new DebugDock(),
#endif
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
				//SimPe.Interfaces.Files.IPackedFileDescriptor pfd = pkg.FindFile(0x0BF999E7, 0, Data.MetaData.LOCAL_GROUP, item.Instance);
				if (item.LtxtFileIndexItem != null)
				{
					Ltxt ltxt = new Ltxt();
					ltxt.ProcessData(item.LtxtFileIndexItem);
					item.Tags.Add(ltxt);
					li.Owner = ltxt.OwnerInstance;
				}
			}
		}
	}
}
