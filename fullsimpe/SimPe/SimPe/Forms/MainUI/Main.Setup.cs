// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Linq;
using System.Windows.Forms;

using SimPe.Data;
using SimPe.Events;
using SimPe.Forms.MainUI;
using SimPe.Forms.MainUI.Components;

namespace SimPe.Forms.MainUI
{
	partial class MainForm
	{
		private void SetupMainForm()
		{
			if (Helper.WindowsRegistry.Config.HiddenMode)
			{
				ToolStripButton tbDebug = new ToolStripButton
				{
					ToolTipText = "Debug docks",
					Image = GetIcon.Debug
				};
				toolBar1.Items.Add(tbDebug);
				tbDebug.Click += new EventHandler(tbDebug_Click);

				toolBar1.Items.Add(biNewDc);
				menuBarItem1.DropDownItems.Insert(11, miNewDc);
			}
			manager.Visible = false;
			tbContainer.Visible = false;
			createdmenus = false;

			Wait.Bar = waitControl1;

			if (Helper.WindowsRegistry.Config.UseBigIcons)
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

			Splash.Screen.SetMessage(
				Localization.GetString("Building View Filter")
			);
			filter = new ViewFilter();
			Splash.Screen.SetMessage(
				Localization.GetString("Starting Resource Loader")
			);
			resloader = new ResourceLoader(dc, package);
			Splash.Screen.SetMessage(
				Localization.GetString("Enabling RemoteControl")
			);
			remote = new RemoteHandler(this, package, resloader, miWindow);

			Splash.Screen.SetMessage(
				Localization.GetString("Loading Plugins...")
			);
			plugger = new PluginManager(
				miTools,
				tbTools,
				dc,
				package,
				miAction,
				tbAction,
				dockBottom,
				mbiTopics,
				lv
			);
			plugger.ClosedToolPlugin += new ToolMenuItemExt.ExternalToolNotify(
				ClosedToolPlugin
			);
			remote.SetPlugger(plugger);

			remote.LoadedResource += new ChangedResourceEvent(rh_LoadedResource);

			package.UpdateRecentFileMenu(miRecent);

			InitTheme();
			dockBottom.Height = Height * 3 / 4;
			Text =
				"SimPe (Version "
				+ Helper.SimPeVersion.ProductVersion
				+ ") "
				+ PathProvider.Global.Latest.DisplayName;

			TD.SandDock.SandDockManager sdm2 = new TD.SandDock.SandDockManager
			{
				OwnerForm = this,
				Renderer = new TD.SandDock.Rendering.WhidbeyRenderer()
			};

			dc.Manager = sdm2;

			InitMenuItems();
			dcPlugin.Open();
			Ambertation.Windows.Forms.ToolStripRuntimeDesigner.Add(tbContainer);
			Ambertation.Windows.Forms.ToolStripRuntimeDesigner.LineUpToolBars(
				tbContainer
			);
			if (Helper.StartedGui == Executable.Default)
			{
				menuBar1.ContextMenuStrip = tbContainer
					.TopToolStripPanel
					.ContextMenuStrip;
			}

			Ambertation.Windows.Forms.Serializer.Global.Register(tbContainer);
			Ambertation.Windows.Forms.Serializer.Global.Register(manager);

			manager.NoCleanup = false;
			manager.ForceCleanUp();
			lv.Filter = filter;

			if (Helper.WindowsRegistry.Config.LoadTableAtStartup)
			{
				FileTableBase.FileIndex.AllowEvent = false;
				Splash.Screen.SetMessage("Loading the FileTable");
				FileTableBase.FileIndex.Load();
			}
			else
			{
				FileTableBase.FileIndex.AllowEvent = true;
			}

			waitControl1.ShowProgress = false;
			waitControl1.Progress = 0;
			waitControl1.Message = "";
			waitControl1.Visible = Helper.WindowsRegistry.Config.ShowWaitBarPermanent;
		}

		void LoadForm(object sender, EventArgs e)
		{
			Splash.Screen.SetMessage(
				Localization.GetString("Starting Main Form")
			);

			SuspendLayout();

			dcFilter.Collapse(false);

			cbsemig.Items.Add("[Group Filter]");
			cbsemig.Items.Add((0x7FD46CD0, "Globals"));
			cbsemig.Items.Add((0x7FE59FD0, "Behaviour"));
			cbsemig.Items.AddRange((from global in SemiGlobalListing.SemiGlobals
									select (global.Key, global.Value)).Cast<object>().ToArray());

			if (cbsemig.Items.Count > 0)
			{
				cbsemig.SelectedIndex = 0;
			}

			//Set the Lock State of the Docks
			MakeFloatable(!Helper.WindowsRegistry.Config.LockDocks);

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
			miRunSims.Image = GetImage.GetExpansionIcon((byte)eep);
			miRunSims.Text = "Run " + PathProvider.Global.Latest.NameShorter;

			manager.Visible = true;
			tbContainer.Visible = true;

			ResumeLayout();

			Splash.Screen.Stop();

			if (Helper.WindowsRegistry.PreviousVersion != Helper.SimPeVersionLong)
			{
				About.ShowWelcome();
			}
		}
	}
}
