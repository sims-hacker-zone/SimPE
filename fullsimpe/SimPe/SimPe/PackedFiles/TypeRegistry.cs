/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
 *   Copyright (C) 2008 by Peter L Jones                                   *
 *   pljones@users.sf.net                                                  *
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

using SimPe.Interfaces;
using SimPe.Interfaces.Plugin;
using SimPe.Interfaces.Plugin.Internal;

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
		/// <summary>
		/// Coontains all available handler Objects
		/// </summary>
		/// <remarks>All handlers are stored as IPackedFileHandler Objects</remarks>
		ArrayList handlers;

		/// <summary>
		/// Contains all available Tool Plugins
		/// </summary>
		ArrayList tools,
			toolsp;

		/// <summary>
		/// Contains all available dockable Tool Plugins
		/// </summary>
		ArrayList dtools;

		/// <summary>
		/// Contains all available action Tool Plugins
		/// </summary>
		ArrayList atools;

		/// <summary>
		/// Contains all known CommandLine tools
		/// </summary>
		ArrayList cmdlines;

		/// <summary>
		/// Contains all known Helptopics
		/// </summary>
		ArrayList helptopics;

		/// <summary>
		/// Contains all known Custom Settings
		/// </summary>
		ArrayList settings;

		/// <summary>
		/// Contains all available Listeners
		/// </summary>
		Collections.InternalListeners listeners;

		/// <summary>
		/// Used to access the Windows Registry
		/// </summary>
		Registry reg;

		/// <summary>
		/// Constructor of the class
		/// </summary>
		public TypeRegistry()
		{
			reg = Helper.WindowsRegistry;
			handlers = new ArrayList();
			OpcodeProvider = new Providers.Opcodes();
			SimFamilynameProvider = new Providers.SimFamilyNames();
			SimNameProvider = new Providers.SimNames(null); //opcodeprovider
			SimDescriptionProvider = new Providers.SimDescriptions(
				SimNameProvider,
				SimFamilynameProvider
			);
			SkinProvider = new Providers.Skins();
			lotprov = new Providers.LotProvider();
			SimDescriptionProvider.ChangedPackage += new EventHandler(
				lotprov.sdescprovider_ChangedPackage
			);

			tools = new ArrayList();
			toolsp = new ArrayList();
			dtools = new ArrayList();
			atools = new ArrayList();
			cmdlines = new ArrayList();
			helptopics = new ArrayList();
			settings = new ArrayList();
			listeners = new Collections.InternalListeners();

			WrapperImageList = new System.Windows.Forms.ImageList();
			WrapperImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;

			WrapperImageList.Images.Add(
				System.Drawing.Image.FromStream(
					this.GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.empty.png")
				)
			);
			WrapperImageList.Images.Add(
				System.Drawing.Image.FromStream(
					this.GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.binary.png")
				)
			);
		}

		#region IWrapperRegistry Member
		public void Register(IWrapper wrapper)
		{
			if (wrapper != null)
			{
				if (!handlers.Contains(wrapper))
				{
					((IWrapper)wrapper).Priority =
						reg.GetWrapperPriority(
							((IWrapper)wrapper).WrapperDescription.UID
						);
					handlers.Add((IFileWrapper)wrapper);
					if (wrapper.WrapperDescription is AbstractWrapperInfo)
					{
						if (wrapper.WrapperDescription.Icon != null)
						{
							(
								(AbstractWrapperInfo)wrapper.WrapperDescription
							).IconIndex = WrapperImageList.Images.Count;
							WrapperImageList.Images.Add(wrapper.WrapperDescription.Icon);
						}
						else
						{
							(
								(AbstractWrapperInfo)wrapper.WrapperDescription
							).IconIndex = 1;
						}
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
					if (!wrapper.AllowMultipleInstances && wrapper is AbstractWrapper)
					{
						((AbstractWrapper)wrapper).SingleGuiWrapper = (IFileWrapper)
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

			if (
				factory
					.GetType()
					.GetInterface("SimPe.Interfaces.Plugin.IHelpFactory", false)
				== typeof(IHelpFactory)
			)
			{
				Register((factory as IHelpFactory));
			}

			if (
				factory
					.GetType()
					.GetInterface("SimPe.Interfaces.Plugin.ISettingsFactory", false)
				== typeof(ISettingsFactory)
			)
			{
				Register((factory as ISettingsFactory));
			}

			if (
				factory
					.GetType()
					.GetInterface("SimPe.Interfaces.Plugin.ICommandLineFactory", false)
				== typeof(ICommandLineFactory)
			)
			{
				Register((factory as ICommandLineFactory));
			}
		}

		public IWrapper[] Wrappers
		{
			get
			{
				IWrapper[] wrappers = AllWrappers;
				ArrayList wrap = new ArrayList();

				foreach (IWrapper w in wrappers)
				{
					if (w.Priority >= 0)
					{
						wrap.Add(w);
					}
				}

				wrappers = new IWrapper[wrap.Count];
				wrap.CopyTo(wrappers);
				return wrappers;
			}
		}

		public IWrapper[] AllWrappers
		{
			get
			{
				IWrapper[] wrappers = new IWrapper[handlers.Count];
				handlers.CopyTo(wrappers);

				//sort the wrapper by priority
				for (int i = 0; i < wrappers.Length - 1; i++)
				{
					for (int k = i + 1; k < wrappers.Length; k++)
					{
						if (
							Math.Abs(wrappers[i].Priority)
							> Math.Abs(wrappers[k].Priority)
						)
						{
							IWrapper dum = wrappers[i];
							wrappers[i] = wrappers[k];
							wrappers[k] = dum;
						}
					}
				}
				return wrappers;
			}
		}

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
		public IPackedFileWrapper FindHandler(uint type)
		{
			IWrapper[] wrappers = this.Wrappers;
			foreach (IFileWrapper h in wrappers)
			{
				foreach (uint atype in h.AssignableTypes)
				{
					if (atype == type)
					{
						return h;
					}
				}
			}

			return null;
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
		public IFileWrapper FindHandler(Byte[] data)
		{
			IWrapper[] wrappers = this.Wrappers;
			foreach (IFileWrapper h in wrappers)
			{
				if (h.FileSignature == null)
				{
					continue;
				}

				if (h.FileSignature.Length == 0)
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

				if (check == true)
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
		public Interfaces.Providers.ISimNames SimNameProvider
		{
			get;
		}

		/// <summary>
		/// Returns the Provider for Sim Family Names
		/// </summary>
		public Interfaces.Providers.ISimFamilyNames SimFamilynameProvider
		{
			get;
		}

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
		public Interfaces.Providers.IOpcodeProvider OpcodeProvider
		{
			get;
		}

		/// <summary>
		/// Returns the Provider for Skin Data
		/// </summary>
		public Interfaces.Providers.ISkinProvider SkinProvider
		{
			get;
		}
		#endregion

		#region IToolRegistry Member
		public void Register(IToolPlugin tool)
		{
			if (tool != null)
			{
				if (
					tool.GetType().GetInterface("SimPe.Interfaces.IDockableTool", true)
					== typeof(IDockableTool)
				)
				{
					if (!dtools.Contains(tool))
					{
						dtools.Add((IDockableTool)tool);
					}
				}
				else if (
					tool.GetType().GetInterface("SimPe.Interfaces.IToolAction", true)
					== typeof(IToolAction)
				)
				{
					if (!atools.Contains(tool))
					{
						atools.Add((IToolAction)tool);
					}
				}
				else if (
					tool.GetType().GetInterface("SimPe.Interfaces.IToolPlus", true)
					== typeof(IToolPlus)
				)
				{
					if (!toolsp.Contains(tool))
					{
						toolsp.Add((IToolPlus)tool);
					}
				}
				else if (
					Helper.StartedGui != Executable.Classic
					&& tool.GetType().GetInterface("SimPe.Interfaces.IListener", true)
						== typeof(IListener)
				)
				{
					if (!listeners.Contains((IListener)tool))
					{
						listeners.Add((IListener)tool);
					}
				}
				else if (
					tool.GetType().GetInterface("SimPe.Interfaces.ITool", true)
					== typeof(ITool)
				)
				{
					if (!tools.Contains(tool))
					{
						tools.Add((ITool)tool);
					}
				}
			}
		}

		public void Register(IToolPlugin[] tools)
		{
			if (tools != null)
			{
				foreach (IToolPlugin tool in tools)
				{
					Register(tool);
				}
			}
		}

		public void Register(IToolFactory factory)
		{
			factory.LinkedRegistry = this;
			factory.LinkedProvider = this;
			string s = SimPe.Localization.GetString("Unknown");
#if !DEBUG
			try
#endif
			{
				s = factory.FileName;
				Register(factory.KnownTools);
			}
#if !DEBUG
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					"Unable to load Tool \""
						+ s
						+ "\". You Probaly have a Plugin/Tool installed, that is not compatible with the current SimPe Release.",
					ex
				);
			}
#endif
		}

		public Collections.Listeners Listeners => listeners;

		public ITool[] Tools
		{
			get
			{
				ITool[] rtools = new ITool[tools.Count];
				tools.CopyTo(rtools);
				return rtools;
			}
		}

		public IToolPlus[] ToolsPlus
		{
			get
			{
				IToolPlus[] rtools = new IToolPlus[toolsp.Count];
				toolsp.CopyTo(rtools);
				return rtools;
			}
		}

		public IDockableTool[] Docks
		{
			get
			{
				IDockableTool[] rtools = new IDockableTool[dtools.Count];
				dtools.CopyTo(rtools);
				return rtools;
			}
		}

		public IToolAction[] Actions
		{
			get
			{
				IToolAction[] rtools = new IToolAction[atools.Count];
				atools.CopyTo(rtools);
				return rtools;
			}
		}

		#endregion

		#region IHelpRegistry Member
		public void Register(IHelpFactory factory)
		{
			if (factory == null)
			{
				return;
			}

			RegisterHelpTopic(factory.KnownHelpTopics);
		}

		public void RegisterHelpTopic(IHelp[] topics)
		{
			if (topics == null)
			{
				return;
			}

			foreach (IHelp topic in topics)
			{
				RegisterHelpTopic(topic);
			}
		}

		public void RegisterHelpTopic(IHelp topic)
		{
			if (topic != null && !helptopics.Contains(topic))
			{
				this.helptopics.Add(topic);
			}
		}

		/// <summary>
		/// Returns the List of Known Help Topics
		/// </summary>
		public IHelp[] HelpTopics
		{
			get
			{
				IHelp[] ret = new IHelp[
					helptopics.Count
				];
				helptopics.CopyTo(ret);
				return ret;
			}
		}
		#endregion

		#region ISettingsRegistry Member

		public void Register(ISettingsFactory factory)
		{
			if (factory == null)
			{
				return;
			}

			RegisterSettings(factory.KnownSettings);
		}

		public ISettings[] Settings
		{
			get
			{
				ISettings[] ret = new ISettings[settings.Count];
				settings.CopyTo(ret);
				return ret;
			}
		}

		public void RegisterSettings(ISettings[] settings)
		{
			if (settings == null)
			{
				return;
			}

			foreach (ISettings s in settings)
			{
				RegisterSettings(s as ISettings);
			}
		}

		public void RegisterSettings(ISettings setting)
		{
			if (settings == null)
			{
				return;
			}

			if (!settings.Contains(setting))
			{
				settings.Add(setting);
			}
		}

		#endregion

		#region ICommandLineRegistry Members

		public void Register(ICommandLineFactory factory)
		{
			if (factory == null)
			{
				return;
			}

			RegisterCommandLines(factory.KnownCommandLines);
		}

		public void RegisterCommandLines(ICommandLine[] CommandLines)
		{
			if (cmdlines == null)
			{
				return;
			}

			foreach (ICommandLine c in CommandLines)
			{
				RegisterCommandLines(c as ICommandLine);
			}
		}

		public void RegisterCommandLines(ICommandLine cmdline)
		{
			if (cmdline == null)
			{
				return;
			}

			if (!cmdlines.Contains(cmdline))
			{
				cmdlines.Add(cmdline);
			}
		}

		public ICommandLine[] CommandLines
		{
			get
			{
				ICommandLine[] ret = new ICommandLine[cmdlines.Count];
				cmdlines.CopyTo(ret);
				return ret;
			}
		}

		#endregion

		/// <summary>
		/// This will perform some basic tasks, to bring the SimPe API into an useable state
		/// </summary>
		/* unused ?? ?? ?? -> see SimPe Main\PluginManager.cs LoadStaticWrappers()
		public static void InitDefaultFileTable()
		{
			SimPe.PackedFiles.TypeRegistry tr = new SimPe.PackedFiles.TypeRegistry();

			SimPe.FileTable.ProviderRegistry = tr;
			SimPe.FileTable.ToolRegistry = tr;
			SimPe.FileTable.WrapperRegistry = tr;
			SimPe.FileTable.HelpTopicRegistry = tr;
			SimPe.FileTable.SettingsRegistry = tr;

			SimPe.FileTable.WrapperRegistry.Register(new SimPe.PackedFiles.Wrapper.Factory.SimFactory());
			SimPe.FileTable.WrapperRegistry.Register(new SimPe.PackedFiles.Wrapper.Factory.ExtendedWrapperFactory());
			SimPe.FileTable.WrapperRegistry.Register(new SimPe.PackedFiles.Wrapper.Factory.DefaultWrapperFactory());
			SimPe.FileTable.WrapperRegistry.Register(new SimPe.Plugin.ScenegraphWrapperFactory());
			SimPe.FileTable.WrapperRegistry.Register(new SimPe.PackedFiles.Wrapper.Factory.ClstWrapperFactory());
			SimPe.FileTable.WrapperRegistry.Register(new SimPe.Commandline.Help());

		}
		*/
	}
}
