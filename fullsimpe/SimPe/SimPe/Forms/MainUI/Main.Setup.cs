// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Linq;
using System.Windows.Forms;

using SimPe.Data;
using SimPe.Events;

namespace SimPe.Forms.MainUI
{
	partial class MainForm
	{
		private void SetupMainForm()
		{

			package = new LoadedPackage();
			package.AfterFileLoad += new PackageFileLoadedEvent(AfterFileLoad);
			package.BeforeFileSave += new PackageFileSaveEvent(BeforeFileSave);
			package.AfterFileSave += new PackageFileSavedEvent(AfterFileSave);
			package.IndexChanged += new EventHandler(ChangedActiveIndex);

			filter = new ViewFilter();

			plugger = new PluginManager(
				package
			);
			remote.SetPlugger(plugger);

			remote.LoadedResource += new ChangedResourceEvent(rh_LoadedResource);


			InitTheme();

			if (Helper.WindowsRegistry.Config.LoadTableAtStartup)
			{
				FileTableBase.FileIndex.AllowEvent = false;
				FileTableBase.FileIndex.Load();
			}
			else
			{
				FileTableBase.FileIndex.AllowEvent = true;
			}
		}

		void LoadForm(object sender, EventArgs e)
		{

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
		}
	}
}
