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

using SimPe.Interfaces;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Wrapper;
using SimPe.Plugin.Tool.Action;

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
		: SimPe.Interfaces.Plugin.AbstractWrapperFactory,
			ICommandLineFactory,
			IToolFactory
	{
		static bool inited = false;

		/// <summary>
		/// Add all other default RCol Extensions
		/// </summary>
		public static void InitRcolBlocks()
		{
			if (!inited)
			{
				Rcol.TokenAssemblies.Add(
					typeof(SimPe.Plugin.GeometryDataContainer).Assembly
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
			if (FileTable.GroupCache != null)
				return;

			SimPe.PackedFiles.Wrapper.GroupCache gc =
				new SimPe.PackedFiles.Wrapper.GroupCache();

			if (!Helper.WindowsRegistry.UseMaxisGroupsCache && !force)
			{
				FileTable.GroupCache = gc;
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
					SimPe.Packages.File pkg = SimPe.Packages.File.LoadFromFile(name);
					SimPe.Interfaces.Files.IPackedFileDescriptor pfd = pkg.FindFile(
						0x54535053,
						0,
						1,
						1
					);
					if (pfd != null)
						gc.ProcessData(pfd, pkg, false);
				}
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					new Warning("Unable to load groups.cache", ex.Message, ex)
				);
			}

			FileTable.GroupCache = gc;
		}

		/// <summary>
		/// Creates the Class
		/// </summary>
		public WrapperFactory()
			: base()
		{
			//prepare the FileIndex
			FileTable.FileIndex = new FileIndex();
			SimPe.Packages.PackageMaintainer.Maintainer.FileIndex =
				FileTable.FileIndex.AddNewChild();
		}

		#region AbstractWrapperFactory Member
		/// <summary>
		/// Returns a List of all available Plugins in this Package
		/// </summary>
		/// <returns>A List of all provided Plugins (=FileType Wrappers)</returns>
		public override SimPe.Interfaces.IWrapper[] KnownWrappers
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
					SimPe.PackedFiles.Wrapper.SdscFreetime.RegisterAsAspirationEditor(
						new SimPe.Plugin.SimAspirationEditor()
					);
					FileTable.ProviderRegistry.LotProvider.LoadingLot +=
						new SimPe.Interfaces.Providers.LoadLotData(
							LotProvider_LoadingLot
						);
					IWrapper[] wrappers =
					{
						new RefFile(),
						new Plugin.Txtr(this.LinkedProvider, false),
						new Plugin.Lifo(this.LinkedProvider, false),
						// new Plugin.Shpe(this.LinkedProvider),
						new Plugin.GenericRcol(this.LinkedProvider, false),
						new Plugin.MmatWrapper(),
						new SimPe.PackedFiles.Wrapper.GroupCache(),
						new SimPe.PackedFiles.Wrapper.Slot(),
						new Nmap(this.LinkedProvider),
						new Plugin.EnhancedNgbh(),
						new Plugin.Ngbh(this.LinkedProvider),
						new Plugin.Ltxt(this.LinkedProvider),
						new Plugin.Want(this.LinkedProvider),
						new Plugin.XWant(),
						new Plugin.Idno(),
						new Plugin.RoadTexture(),
						new Plugin.Tatt(),
						new Plugin.Bnfo(),
						new Plugin.Nhtr(),
						new Plugin.Lot(),
						new Bcon(),
						new Bhav(),
						new Objf(),
						new StrWrapper(),
						new TPRP(),
						new Trcn(),
						new Ttab(),
						new TreesPackedFileWrapper(),
					};
					return wrappers;
				}
			}
		}

		#endregion

		#region IToolFactory Member

		public IToolPlugin[] KnownTools
		{
			get
			{
				IToolPlugin[] tools =
				{
					new NeighborhoodTool(this.LinkedRegistry, this.LinkedProvider),
					new SimsTool(this.LinkedRegistry, this.LinkedProvider),
					new SurgeryTool(this.LinkedRegistry, this.LinkedProvider),
					new HashTool(this.LinkedRegistry, this.LinkedProvider),
					new FixTool(this.LinkedRegistry, this.LinkedProvider),
					new SkinWorkshopTool(),
					new PhotoStudioTool(this.LinkedRegistry, this.LinkedProvider),
					new ActionGlobalFixTGI(),
					new ActionBuildNameMap(),
					new ImportSemiTool(LinkedRegistry, LinkedProvider),
					new OpenLuaTool(),
					new SearchTool(LinkedRegistry, LinkedProvider),
					new ActionIntriguedNeighborhood(),
					new ActionDeleteSim(),
					new GeneticCategorizerTool(),
					new pjse.guidtool.GUIDTool(),
				};
				return tools;
			}
		}

		#endregion


		#region ICommandLineFactory Members

		public ICommandLine[] KnownCommandLines
		{
			get
			{
				return new ICommandLine[] { new BuildTxtr(), new FixPackage() };
			}
		}

		#endregion

		private void LotProvider_LoadingLot(
			object sender,
			SimPe.Interfaces.Providers.ILotItem item
		)
		{
			SimPe.Interfaces.Files.IPackageFile pkg = FileTable
				.ProviderRegistry
				.SimDescriptionProvider
				.BasePackage;
			if (pkg != null)
			{
				SimPe.Providers.LotProvider.LotItem li =
					item as SimPe.Providers.LotProvider.LotItem;
				//SimPe.Interfaces.Files.IPackedFileDescriptor pfd = pkg.FindFile(0x0BF999E7, 0, Data.MetaData.LOCAL_GROUP, item.Instance);
				if (item.LtxtFileIndexItem != null)
				{
					SimPe.Plugin.Ltxt ltxt = new Ltxt();
					ltxt.ProcessData(item.LtxtFileIndexItem);
					item.Tags.Add(ltxt);
					li.Owner = ltxt.OwnerInstance;
				}
			}
		}
	}
}
