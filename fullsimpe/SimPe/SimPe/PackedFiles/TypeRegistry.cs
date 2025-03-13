// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;
using System.Linq;

using pj;

using pjHoodTool;

using pjOBJDTool;

using pjse;
using pjse.guidtool;

using SimPe.Data;
using SimPe.Interfaces;
using SimPe.Interfaces.Plugin;
using SimPe.Interfaces.Plugin.Internal;
using SimPe.Plugin;
using SimPe.Plugin.Tool;
using SimPe.Plugin.Tool.Action;
using SimPe.Plugin.Tool.Dockable;
using SimPe.Plugin.Tool.Window;

namespace SimPe.PackedFiles
{
	/// <summary>
	/// Holds the index of available Handlers
	/// </summary>
	/// <remarks>
	/// The TypeRegistry is the main Communication Point for all Plugins, so if you want to
	/// provide Infoformations from the Main Application to the Plugins, you have to use the
	/// TypeRegistry!
	/// </remarks>
	public sealed class TypeRegistry
		: IWrapperRegistry,
			IProviderRegistry,
			IToolRegistry,
			IHelpRegistry,
			ISettingsRegistry,
			ICommandLineRegistry
	{
		static ResourceDock rd = new ResourceDock();
		/// <summary>
		/// Coontains all available handler Objects
		/// </summary>
		/// <remarks>All handlers are stored as IPackedFileHandler Objects</remarks>
		private readonly HashSet<IFileWrapper> handlers = new HashSet<IFileWrapper>();

		/// <summary>
		/// Used to access the Windows Registry
		/// </summary>
		private readonly Registry reg = Helper.WindowsRegistry;

		/// <summary>
		/// Constructor of the class
		/// </summary>
		public TypeRegistry()
		{
			SimDescriptionProvider = new Providers.SimDescriptions(
				SimNameProvider,
				SimFamilynameProvider
			);
			lotprov = new Providers.LotProvider();
			SimDescriptionProvider.ChangedPackage += new EventHandler(
				lotprov.sdescprovider_ChangedPackage
			);

			WrapperImageList = new System.Windows.Forms.ImageList
			{
				ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
			};

			WrapperImageList.Images.AddRange(new System.Drawing.Image[] {
				System.Drawing.Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.empty.png")
				),
				System.Drawing.Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.binary.png")
				)
			});

			Tools = new HashSet<ITool>
			{
				new NeighborhoodTool(this, this),
				new SimsTool(this, this),
				new SurgeryTool(this, this),
				new HashTool(this, this),
				new FixTool(),
				new SkinWorkshopTool(),
				new PhotoStudioTool(this, this),
				new ImportSemiTool(this, this),
				new OpenLuaTool(),
				new SearchTool(this, this),
				new GeneticCategorizerTool(),
				new GUIDTool(),
				new CareerTool(this, this),
				new tOBJDTool(this, this),
				new cHoodTool(),
				new FileTableTool(),
				new cObjKeyTool(),
				new BodyMeshExtractor(),
				new BodyMeshLinker(),
				new ScannerTool(),
			};
		}

		#region IWrapperRegistry Member
		public void Register(IWrapper wrapper)
		{
			if (wrapper != null && wrapper is IFileWrapper wrapper1 && !handlers.Contains(wrapper1))
			{
				wrapper.Priority = reg.GetWrapperPriority(wrapper.WrapperDescription.UID);
				handlers.Add(wrapper1);
				if (wrapper.WrapperDescription is AbstractWrapperInfo info)
				{
					if (wrapper.WrapperDescription.Icon != null)
					{
						info.IconIndex = WrapperImageList.Images.Count;
						WrapperImageList.Images.Add(wrapper.WrapperDescription.Icon);
					}
					else
					{
						info.IconIndex = 1;
					}
				}
			}
		}

		public void Register(IWrapper[] wrappers, IWrapper[] guiwrappers)
		{
			if (wrappers != null && guiwrappers == null)
			{
				foreach (IWrapper wrapper in wrappers)
				{
					Register(wrapper);
				}
			}
			else if (wrappers != null && guiwrappers != null)
			{
				for (int i = 0; i < wrappers.Length; i++)
				{
					IWrapper wrapper = wrappers[i];
					//make sure whe have two instances of each Wrapper otherwise,
					//AbstractWrapper.ResoureceName could corrupt a open Resource
					if (!wrapper.AllowMultipleInstances && wrapper is AbstractWrapper wrapper1)
					{
						wrapper1.SingleGuiWrapper = (IFileWrapper)
							guiwrappers[i];
					}

					Register(wrapper);
					Register(wrapper);
				}
			}
		}

		/// <summary>
		/// Registers all Wrappers supported by the Factory
		/// </summary>
		/// <param name="factory">The Factory Elements you want to register</param>
		/// <remarks>The wrapper must only be added if the Registry doesnt already contain it</remarks>
		public void Register(IWrapperFactory factory)
		{
			factory.LinkedRegistry = this;
			factory.LinkedProvider = this;
			Register(factory.KnownWrappers, factory.KnownWrappers);

			if (factory is IHelpFactory)
			{
				Register(factory as IHelpFactory);
			}

			if (factory is ISettingsFactory)
			{
				Register(factory as ISettingsFactory);
			}

			if (factory is ICommandLineFactory)
			{
				Register(factory as ICommandLineFactory);
			}
		}

		public IEnumerable<IWrapper> Wrappers => AllWrappers.Where((item) => item.Priority >= 0);

		public IEnumerable<IWrapper> AllWrappers => handlers.OrderByDescending((item) => item.Priority);

		/// <summary>
		/// Contains a Listing of all available Wrapper Icons
		/// </summary>
		public System.Windows.Forms.ImageList WrapperImageList
		{
			get;
		}
		#endregion

		/// <summary>
		/// Returns the first Handler capable of processing a File of the given Type
		/// </summary>
		/// <param name="type">The Type of the PackedFile</param>
		/// <returns>The assigned Handler or null if none was found</returns>
		public IPackedFileWrapper FindHandler(FileTypes type)
		{
			return (IPackedFileWrapper)Wrappers.FirstOrDefault((item) => item is IFileWrapper filewrapper && filewrapper.AssignableTypes.Contains(type));
		}

		/// <summary>
		/// Returns the first Handler capable of processing a File
		/// </summary>
		/// <param name="data">The Data of the PackedFile</param>
		/// <returns>The assigned Handler or null if none was found</returns>
		/// <remarks>
		/// A handler is assigned if the first bytes of the Data are equal
		/// to the signature provided by the Handler
		/// </remarks>
		public IFileWrapper FindHandler(byte[] data)
		{
			IEnumerable<IWrapper> wrappers = Wrappers;
			foreach (IFileWrapper h in wrappers)
			{
				if (h.FileSignature == null || h.FileSignature.Length == 0)
				{
					continue;
				}

				bool check = true;
				for (int i = 0; i < h.FileSignature.Length; i++)
				{
					if (i >= data.Length)
					{
						break;
					}

					if (data[i] != h.FileSignature[i])
					{
						check = false;
						break;
					}
				}

				if (check)
				{
					return h;
				}
			}
			return null;
		}

		#region IProviderRegistry Member

		Providers.LotProvider lotprov;
		public Interfaces.Providers.ILotProvider LotProvider => lotprov;

		/// <summary>
		/// Returns the Provider for SimNames
		/// </summary>
		public Interfaces.Providers.ISimNames SimNameProvider { get; } = new Providers.SimNames(null);

		/// <summary>
		/// Returns the Provider for Sim Family Names
		/// </summary>
		public Interfaces.Providers.ISimFamilyNames SimFamilynameProvider { get; } = new Providers.SimFamilyNames();

		/// <summary>
		/// Returns the Provider for SimDescription Files
		/// </summary>
		public Interfaces.Providers.ISimDescriptions SimDescriptionProvider
		{
			get;
		}

		/// <summary>
		/// Returns the Provider for Opcode Names
		/// </summary>
		public Interfaces.Providers.IOpcodeProvider OpcodeProvider { get; } = new Providers.Opcodes();

		/// <summary>
		/// Returns the Provider for Skin Data
		/// </summary>
		public Interfaces.Providers.ISkinProvider SkinProvider { get; } = new Providers.Skins();
		#endregion

		#region IToolRegistry Member

		public List<IListener> Listeners { get; } = new List<IListener>();

		public HashSet<ITool> Tools
		{
			get;
		}

		public HashSet<IToolPlus> ToolsPlus
		{
			get;
		} = new HashSet<IToolPlus>()
		{

					new CreateListFromPackageTool(),
					new CreateListFromSelectionTool(),
					new InstallerTool(),
					new SaveSims2PackTool(),
					new LoadSims2PackTool(),
					new PackageRepairTool(),
					new AnimTool(),
		};

		public HashSet<IDockableTool> Docks
		{
			get;
		} = new HashSet<IDockableTool>()
		{

					new PackageDockTool(rd),
					new ResourceDockTool(rd),
					new WrapperDockTool(rd),
					new HexDecConverterTool(rd),
					new HexDockTool(rd),
					new FinderDock(),
					new ObectWorkshopDockTool(),
					new PackageDetailDockTool(),
					new DebugDock(),
		};

		public HashSet<IToolAction> Actions
		{
			get;
		} = new HashSet<IToolAction>
		{

					new ActionGlobalFixTGI(),
					new ActionBuildNameMap(),
					new ActionIntriguedNeighborhood(),
					new ActionDeleteSim(),
					new ActionReloadFiletable(),
					new ActionUniqueInstance(),
					new ActionCheckFiletable(),
					new ActionBuildPhpGuidList(),
		};

		#endregion

		#region IHelpRegistry Member
		public void Register(IHelpFactory factory)
		{
			if (factory != null)
			{
				RegisterHelpTopic(factory.KnownHelpTopics);
			}
		}

		public void RegisterHelpTopic(IEnumerable<IHelp> topics)
		{
			if (topics != null)
			{
				HelpTopics.UnionWith(topics);
			}
		}

		public void RegisterHelpTopic(IHelp topic)
		{
			if (topic != null)
			{
				HelpTopics.Add(topic);
			}
		}

		/// <summary>
		/// Returns the List of Known Help Topics
		/// </summary>
		public HashSet<IHelp> HelpTopics { get; } = new HashSet<IHelp>();
		#endregion

		#region ISettingsRegistry Member

		public void Register(ISettingsFactory factory)
		{
			if (factory != null)
			{
				RegisterSettings(factory.KnownSettings);
			}
		}

		public HashSet<ISettings> Settings { get; } = new HashSet<ISettings>();

		public void RegisterSettings(IEnumerable<ISettings> settings)
		{
			if (settings != null)
			{
				Settings.UnionWith(settings);
			}
		}

		public void RegisterSettings(ISettings setting)
		{
			if (setting != null)
			{
				Settings.Add(setting);
			}
		}

		#endregion

		#region ICommandLineRegistry Members

		public void Register(ICommandLineFactory factory)
		{
			if (factory != null)
			{
				RegisterCommandLines(factory.KnownCommandLines);
			}
		}

		public void RegisterCommandLines(IEnumerable<ICommandLine> commandlines)
		{
			if (commandlines != null)
			{
				CommandLines.UnionWith(commandlines);
			}
		}

		public void RegisterCommandLines(ICommandLine cmdline)
		{
			if (cmdline != null)
			{
				CommandLines.Add(cmdline);
			}
		}

		public HashSet<ICommandLine> CommandLines { get; } = new HashSet<ICommandLine>();

		#endregion
	}
}
