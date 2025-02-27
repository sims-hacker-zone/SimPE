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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using SimPe.Events;

namespace SimPe
{
	partial class MainForm
	{
		private void SetupMainForm()
		{
			if (Helper.WindowsRegistry.HiddenMode)
			{
				ToolStripButton tbDebug = new ToolStripButton();
				tbDebug.ToolTipText = "Debug docks";
				tbDebug.Image = GetIcon.Debug;
				toolBar1.Items.Add(tbDebug);
				tbDebug.Click += new EventHandler(tbDebug_Click);

				toolBar1.Items.Add(biNewDc);
				menuBarItem1.DropDownItems.Insert(11, miNewDc);
			}
			manager.Visible = false;
			tbContainer.Visible = false;
			createdmenus = false;

			Wait.Bar = this.waitControl1;

			if (Helper.WindowsRegistry.UseBigIcons)
			{
				toolBar1.ImageScalingSize = new System.Drawing.Size(32, 32);
				tbWindow.ImageScalingSize = new System.Drawing.Size(32, 32);
				tbTools.ImageScalingSize = new System.Drawing.Size(32, 32);
				tbAction.ImageScalingSize = new System.Drawing.Size(32, 32);

				biNew.Image = GetIcon.New;
				biOpen.Image = GetIcon.Open;
				biSave.Image = GetIcon.Save;
				biSaveAs.Image = GetIcon.SaveAs;
				biClose.Image = GetIcon.Delete;
				biReset.Image = GetIcon.Reset;
			}

			package = new LoadedPackage();
			package.BeforeFileLoad += new PackageFileLoadEvent(BeforeFileLoad);
			package.AfterFileLoad += new PackageFileLoadedEvent(AfterFileLoad);
			package.BeforeFileSave += new PackageFileSaveEvent(BeforeFileSave);
			package.AfterFileSave += new PackageFileSavedEvent(AfterFileSave);
			package.IndexChanged += new EventHandler(ChangedActiveIndex);

			SimPe.Splash.Screen.SetMessage(
				SimPe.Localization.GetString("Building View Filter")
			);
			filter = new ViewFilter();
			SimPe.Splash.Screen.SetMessage(
				SimPe.Localization.GetString("Starting Resource Loader")
			);
			resloader = new ResourceLoader(dc, package);
			SimPe.Splash.Screen.SetMessage(
				SimPe.Localization.GetString("Enabling RemoteControl")
			);
			remote = new RemoteHandler(this, package, resloader, miWindow);

			SimPe.Splash.Screen.SetMessage(
				SimPe.Localization.GetString("Loading Plugins...")
			);
			plugger = new PluginManager(
				miTools,
				tbTools,
				dc,
				package,
				tbDefaultAction,
				miAction,
				tbExtAction,
				tbPlugAction,
				tbAction,
				dockBottom,
				this.mbiTopics,
				lv
			);
			plugger.ClosedToolPlugin += new ToolMenuItemExt.ExternalToolNotify(
				ClosedToolPlugin
			);
			remote.SetPlugger(plugger);

			remote.LoadedResource += new ChangedResourceEvent(rh_LoadedResource);

			package.UpdateRecentFileMenu(this.miRecent);

			InitTheme();
			dockBottom.Height = ((this.Height * 3) / 4);
			this.Text =
				"SimPe (Version "
				+ Helper.SimPeVersion.ProductVersion
				+ ") "
				+ PathProvider.Global.Latest.DisplayName;

			TD.SandDock.SandDockManager sdm2 = new TD.SandDock.SandDockManager();
			sdm2.OwnerForm = this;
			sdm2.Renderer = new TD.SandDock.Rendering.WhidbeyRenderer();

			this.dc.Manager = sdm2;

			InitMenuItems();
			this.dcPlugin.Open();
			Ambertation.Windows.Forms.ToolStripRuntimeDesigner.Add(tbContainer);
			Ambertation.Windows.Forms.ToolStripRuntimeDesigner.LineUpToolBars(
				tbContainer
			);
			if (Helper.StartedGui == Executable.Default)
			{
				this.menuBar1.ContextMenuStrip = tbContainer
					.TopToolStripPanel
					.ContextMenuStrip;
			}

			Ambertation.Windows.Forms.Serializer.Global.Register(tbContainer);
			Ambertation.Windows.Forms.Serializer.Global.Register(manager);

			manager.NoCleanup = false;
			manager.ForceCleanUp();
			lv.Filter = filter;

			if (Helper.WindowsRegistry.LoadTableAtStartup)
			{
				FileTable.FileIndex.AllowEvent = false;
				SimPe.Splash.Screen.SetMessage("Loading the FileTable");
				FileTable.FileIndex.Load();
			}
			else
			{
				FileTable.FileIndex.AllowEvent = true;
			}

			waitControl1.ShowProgress = false;
			waitControl1.Progress = 0;
			waitControl1.Message = "";
			waitControl1.Visible = Helper.WindowsRegistry.ShowWaitBarPermanent;
		}

		void LoadForm(object sender, System.EventArgs e)
		{
			SimPe.Splash.Screen.SetMessage(
				SimPe.Localization.GetString("Starting Main Form")
			);

			this.SuspendLayout();

			dcFilter.Collapse(false);

			cbsemig.Items.Add("[Group Filter]");
			cbsemig.Items.Add(
				new SimPe.Data.SemiGlobalAlias(true, 0x7FD46CD0, "Globals")
			);
			cbsemig.Items.Add(
				new SimPe.Data.SemiGlobalAlias(true, 0x7FE59FD0, "Behaviour")
			);
			foreach (Data.SemiGlobalAlias sga in Data.MetaData.SemiGlobals)
			{
				if (sga.Known)
				{
					this.cbsemig.Items.Add(sga);
				}
			}

			if (cbsemig.Items.Count > 0)
			{
				cbsemig.SelectedIndex = 0;
			}

			if (!System.IO.File.Exists(SimPe.Helper.DataFolder.SimPeLayout))
			{
				ResetLayout(this, null);
			}
			else
			{
				ReloadLayout();
			}

			//Set the Lock State of the Docks
			MakeFloatable(!Helper.WindowsRegistry.LockDocks);

			int eep = PathProvider.Global.Latest.Version;
			if (eep == 20)
			{
				eep = 12; //Store new
			}

			if (eep == 28)
			{
				eep = 6; //Castaway
			}

			if (eep == 29)
			{
				eep = 6; //Pet Stories
			}
			//Life Stories and Base game = No Icon
			//if (GetImage.GetExpansionIcon((byte)eep) == null || Helper.StartedGui == Executable.Classic) this.miRunSims.Image = global::SimPe.Properties.Resources.Sims2;
			//else
			this.miRunSims.Image = GetImage.GetExpansionIcon((byte)eep);
			this.miRunSims.Text = "Run " + PathProvider.Global.Latest.NameShorter;

			manager.Visible = true;
			tbContainer.Visible = true;

			this.ResumeLayout();

			SimPe.Splash.Screen.Stop();

			if (Helper.WindowsRegistry.PreviousVersion != Helper.SimPeVersionLong)
			{
				About.ShowWelcome();
			}
		}
	}
}
