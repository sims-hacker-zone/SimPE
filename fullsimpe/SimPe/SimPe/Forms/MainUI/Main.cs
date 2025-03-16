// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

using SimPe.Events;
using SimPe.Forms.MainUI;

namespace SimPe.Forms.MainUI
{
	/// <summary>
	/// Summary description for MainForm.
	/// </summary>
	public partial class MainForm
	{
		public MainForm()
		{
			SetupMainForm();
		}

		#region Custom Attributes
		internal LoadedPackage package;
		ViewFilter filter;

		//TreeView lasttreeview;
		PluginManager plugger;
		ResourceLoader resloader;
		RemoteHandler remote;
		#endregion

		#region File Handling

		/// <summary>
		/// Commands that are called after the load
		/// </summary>
		/// <param name="sender"></param>
		void AfterFileLoad(LoadedPackage sender)
		{
			sender.UpdateProviders();
			ShowNewFile(true);
		}

		/// <summary>
		/// Cammans needed before a File is saved
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BeforeFileSave(LoadedPackage sender, FileNameEventArg e)
		{
			if (!resloader.Flush())
			{
				e.Cancel = true;
			}
		}

		/// <summary>
		/// Commands neede after a File Save
		/// </summary>
		/// <param name="sender"></param>
		private void AfterFileSave(LoadedPackage sender)
		{
			UpdateFileInfo();
			package.UpdateProviders();
		}

		/// <summary>
		/// Called, whenever the Index of a Package was changed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ChangedActiveIndex(object sender, EventArgs e)
		{
			//ShowNewFile();
			//SelectResource(this.lv, false, true);
		}

		/// <summary>
		/// This Method displays the content of a File
		/// </summary>
		void UpdateFileInfo()
		{
			if (package.Loaded)
			{
			}
		}

		/// <summary>
		/// This Method displays the content of a File
		/// </summary>
		void ShowNewFile(bool autoselect)
		{
			plugger.ChangedGuiResourceEventHandler(
				this,
				new ResourceEventArgs(package)
			);

			UpdateFileInfo();
		}

		/// <summary>
		/// Close the currently opened File
		/// </summary>
		/// <returns>true, if the File was closed</returns>
		async Task<bool> ClosePackage()
		{
			if (!resloader.Clear())
			{
				return false;
			}

			if (!await package.Close())
			{
				return false;
			}

			plugger.ChangedGuiResourceEventHandler(
				this,
				new ResourceEventArgs(package)
			);
			return true;
		}
		#endregion

		private void Activate_miNew(object sender, EventArgs e)
		{
		}

		private void ClosedToolPlugin(object sender, PackageArg pk)
		{
			try
			{
				if (pk.Result.ChangedPackage)
				{
					package.LoadFromPackage((Packages.GeneratableFile)pk.Package);
				}

				if (pk.Result.ChangedFile)
				{
					Interfaces.Scenegraph.IScenegraphFileIndexItem fii =
						new Plugin.FileIndexItem(pk.FileDescriptor, pk.Package);
					resloader.AddResource(fii, true);
					remote.FireLoadEvent(fii);
				}
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(ex);
			}
		}

		private void Activate_miRunSims(object sender, EventArgs e)
		{
			if (!File.Exists(PathProvider.Global.SimsApplication))
			{
				return;
			}

			System.Diagnostics.Process p = new System.Diagnostics.Process();
			p.StartInfo.FileName = PathProvider.Global.SimsApplication;
			p.StartInfo.Arguments = Helper.WindowsRegistry.Config.EnableSound ? "-w" : "-w -nosound";
			p.Start();
		}

		private void Activate_miSave(object sender, EventArgs e)
		{
			package.Save();
		}

		private void Activate_miClose(object sender, EventArgs e)
		{
		}

		private void rh_LoadedResource(object sender, ResourceEventArgs es)
		{
			foreach (ResourceContainer e in es)
			{
				if (e.HasResource)
				{
				}
			}
		}

		private void Activate_miObjects(object sender, EventArgs e)
		{
			package.LoadFromFile(
				Path.Combine(
					PathProvider.Global.Latest.InstallFolder,
					PathProvider.Global.Latest.ObjectsSubFolder + "\\objects.package"
				)
			);
		}

		private void Activate_biReset(object sender, EventArgs e)
		{
			ResetLayout(null, null);
		}


		private void dcFilter_SizeChanged(object sender, EventArgs e)
		{
			// cbsemig.Width = dcFilter.Width - 24;
		}

		/// <summary>
		/// Write out profile files
		/// </summary>
		private void saveProfile()
		{
			Helper.WindowsRegistry.SaveConfig();
			File.SetLastWriteTime(Helper.DataFolder.FoldersXREGW, DateTime.Now); // It was written by the Options form
		}


		private void tsmiSavePrefs_Click(object sender, EventArgs e)
		{
			saveProfile();
		}
	}
}
