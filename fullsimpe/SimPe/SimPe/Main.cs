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
using System.IO;
using System.Windows.Forms;

using Ambertation.Windows.Forms;

using SimPe.Events;

namespace SimPe
{
	/// <summary>
	/// Summary description for MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();

			SetupMainForm();
		}

		private void ClosingForm(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = !ClosePackage();
			if (!e.Cancel)
			{
				resourceViewManager1.CancelThreads();
				Wait.Stop();
				Wait.Bar = null;

				if (Helper.WindowsRegistry.Layout.AutoStoreLayout)
				{
					StoreLayout();
				}
			}
		}

		#region Custom Attributes
		LoadedPackage package;
		ViewFilter filter;

		//TreeView lasttreeview;
		PluginManager plugger;
		ResourceLoader resloader;
		RemoteHandler remote;
		#endregion

		#region File Handling
		/// <summary>
		/// Commands called before a File is loaded
		/// </summary>
		void BeforeFileLoad(LoadedPackage sender, FileNameEventArg e)
		{
			if (!ClosePackage())
			{
				e.Cancel = true;
			}
		}

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
				Text = "SimPe - " + package.FileName; // CJH
			}

			UpdateMenuItems();
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
			resourceViewManager1.Package = package.Package;
			package.UpdateRecentFileMenu(miRecent);

			UpdateFileInfo();
		}

		/// <summary>
		/// Close the currently opened File
		/// </summary>
		/// <returns>true, if the File was closed</returns>
		bool ClosePackage()
		{
			if (!resloader.Clear())
			{
				return false;
			}

			if (!package.Close())
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

		#region Drag&Drop

		/// <summary>
		/// Returns the Names of the Dropped Files
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		string[] DragDropNames(DragEventArgs e)
		{
			Array a = (Array)e.Data.GetData(DataFormats.FileDrop);

			if (a != null)
			{
				string[] res = new string[a.Length];
				for (int i = 0; i < a.Length; i++)
				{
					res[i] = a.GetValue(i).ToString();
				}

				return res;
			}

			return new string[0];
		}

		/// <summary>
		/// Returns the Effect that should be displayed based on the Files
		/// </summary>
		/// <param name="flname"></param>
		/// <returns></returns>
		DragDropEffects DragDropEffect(string[] names)
		{
			if (names.Length == 0)
			{
				return DragDropEffects.None;
			}

			ExtensionType et = ExtensionProvider.GetExtension(names[0]);
			if (names.Length == 1)
			{
				if (
					et == ExtensionType.Package
					|| et == ExtensionType.DisabledPackage
					|| et == ExtensionType.ExtrackedPackageDescriptor
				)
				{
					return DragDropEffects.Move;
				}
				else if (
					et == ExtensionType.ExtractedFile
					|| et == ExtensionType.ExtractedFileDescriptor
				)
				{
					return DragDropEffects.Copy;
				}
			}

			return DragDropEffects.Copy;
		}

		/// <summary>
		/// Someone tries to throw a File
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DragEnterFile(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				try
				{
					e.Effect = DragDropEffect(DragDropNames(e));
				}
				catch (Exception) { }
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		/// <summary>
		/// A File has been dropped
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DragDropFile(object sender, DragEventArgs e)
		{
			try
			{
				package.LoadOrImportFiles(DragDropNames(e), true);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(ex);
			}
		}
		#endregion

		void Activate_miOpen(object sender, EventArgs e)
		{
			// ofd.Filter = ExtensionProvider.BuildFilterString(
			// 	new SimPe.ExtensionType[] {
			// 								  SimPe.ExtensionType.Package,
			// 								  SimPe.ExtensionType.DisabledPackage,
			// 								  SimPe.ExtensionType.AllFiles
			// 							  }
			// 	);
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				package.LoadFromFile(ofd.FileName);
			}
		}

		private void SetFilter(object sender, EventArgs e)
		{
			try
			{
				filter.Instance = Convert.ToUInt32(tbInst.Text, 16);
				filter.FilterInstance = (tbInst.Text.Trim() != "");
			}
			catch
			{
				filter.FilterInstance = false;
			}

			try
			{
				filter.Group = Convert.ToUInt32(tbGrp.Text, 16);
				filter.FilterGroup = (tbGrp.Text.Trim() != "");
			}
			catch
			{
				filter.FilterGroup = false;
			}
			//if (lastusedtnt!=null) lastusedtnt.Refresh(lv);
		}

		private void miKBase_Clicked(object sender, EventArgs e)
		{
			RemoteControl.ShowHelp(
				Localization.GetString("URLKnowledgeBase")
			);
		}

		private void Activate_miAbout(object sender, EventArgs e)
		{
			About.ShowAbout();
		}

		private void dc_MouseUp(object sender, MouseEventArgs e)
		{
			if (
				e.Button == MouseButtons.Middle
				&& Helper.WindowsRegistry.FirefoxTabbing
				&& dc.SelectedPage != null
			)
			{
				resloader.CloseDocument(dc.SelectedPage);
			}
		}

		private void ResourceListKeyUp(
			object sender,
			KeyEventArgs e
		)
		{
			if (e.KeyCode == Keys.H && e.Control && e.Alt && e.Shift)
			{
				Hidden f = new Hidden();
				f.ShowDialog();
			}
		}

		private void Activate_miNew(object sender, EventArgs e)
		{
			if (ClosePackage())
			{
				package.LoadFromPackage(Packages.File.CreateNew());
				Text =
					"SimPe (Version "
					+ Helper.SimPeVersion.ProductVersion
					+ ") "
					+ PathProvider.Global.Latest.DisplayName;
			}
		}

		private void lv_SelectionChanged(object sender, EventArgs e)
		{
			ResourceEventArgs res = new ResourceEventArgs(
				package
			);
			try
			{
				if (lv.SelectedItems.Count == 0)
				{
					resloader.Clear();
				}
				else
				{
					foreach (
						Windows.Forms.NamedPackedFileDescriptor lvi in lv.SelectedItems
					)
					{
						res.Items.Add(new ResourceContainer(lvi.Resource));
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

			plugger.ChangedGuiResourceEventHandler(this, res);
		}

		private void lv_SelectResource(
			Windows.Forms.ResourceListViewExt sender,
			Windows.Forms.ResourceListViewExt.SelectResourceEventArgs e
		)
		{
			if (lv.SelectedItem != null)
			{
				resloader.AddResource(lv.SelectedItem, !e.CtrlDown);
			}

			lv.Focus();
		}

		private void ShowPreferences(object sender, EventArgs e)
		{
			OptionForm of = new OptionForm();
			of.ResetLayout += new EventHandler(ResetLayout);
			of.UnlockDocks += new EventHandler(UnLockDocks);
			of.LockDocks += new EventHandler(LockDocks);

			System.Drawing.Icon icon = null;
			if (miPref.Image is System.Drawing.Bitmap)
			{
				icon = System.Drawing.Icon.FromHandle(
					((System.Drawing.Bitmap)miPref.Image).GetHicon()
				);
			}

			of.Execute(icon);
			package.UpdateRecentFileMenu(miRecent);
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

		private void CreateNewDocumentContainer(object sender, EventArgs e)
		{
			DockPanel doc = new DockPanel
			{
				Text = "New Container"
			};
			manager.DockPanel(doc, DockStyle.Bottom);
			doc.OpenFloating();
			doc.Closing += new DockPanel.ClosingHandler(CloseAdditionalDocContainer);
			doc.TabImage = dcPlugin.TabImage;
			doc.Text = "New Container";
			doc.TabText = "Container";
			doc.AutoScrollMinSize = dcPlugin.AutoScrollMinSize;

			TD.SandDock.TabControl dc = new TD.SandDock.TabControl
			{
				Manager = this.dc.Manager,
				Text = "New Container",
				Parent = doc,
				Dock = DockStyle.Fill
			};
		}

		private void CloseAdditionalDocContainer(
			object sender,
			DockPanel.DockPanelClosingEvent e
		)
		{
			if (sender is TD.SandDock.DockControl doc)
			{
				if (doc.Controls[0] is TD.SandDock.TabControl dc)
				{
					bool closed = true;
					for (int i = dc.TabPages.Count - 1; i >= 0; i--)
					{
						TD.SandDock.DockControl d = dc.TabPages[i];
						if (!resloader.CloseDocument(d))
						{
							closed = false;
						};
					}
					e.Cancel = !closed;
				}
			}
		}

		private void Activate_miNoMeta(object sender, EventArgs e)
		{
			ToolStripMenuItem mi = (ToolStripMenuItem)sender;
			mi.Checked = !mi.Checked;

			Helper.WindowsRegistry.LoadMetaInfo = !mi.Checked;
		}

		private void Activate_miFileNames(object sender, EventArgs e)
		{
			ToolStripMenuItem mi = (ToolStripMenuItem)sender;
			mi.Checked = !mi.Checked;

			Helper.WindowsRegistry.DecodeFilenamesState = mi.Checked;
		}

		private void Activate_miExit(object sender, EventArgs e)
		{
			Close();
		}

		private void Activate_miRunSims(object sender, EventArgs e)
		{
			if (!File.Exists(PathProvider.Global.SimsApplication))
			{
				return;
			}

			System.Diagnostics.Process p = new System.Diagnostics.Process();
			p.StartInfo.FileName = PathProvider.Global.SimsApplication;
			if (Helper.WindowsRegistry.EnableSound)
			{
				p.StartInfo.Arguments = "-w";
			}
			else
			{
				p.StartInfo.Arguments = "-w -nosound";
			}
			p.Start();
		}

		private void Activate_miSave(object sender, EventArgs e)
		{
			package.Save();
		}

		private void Activate_miSaveAs(object sender, EventArgs e)
		{
			sfd.Filter = ExtensionProvider.BuildFilterString(
				new ExtensionType[]
				{
					ExtensionType.Package,
					ExtensionType.DisabledPackage,
					ExtensionType.AllFiles,
				}
			);
			sfd.FileName = package.FileName;
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				package.Save(sfd.FileName, false);
				package.UpdateRecentFileMenu(miRecent);
			}
		}

		private void Activate_miClose(object sender, EventArgs e)
		{
			if (ClosePackage())
			{
				Packages.StreamFactory.CloseAll(false);
				ShowNewFile(true);
				if (!package.Loaded)
				{
					Text =
						"SimPe (Version "
						+ Helper.SimPeVersion.ProductVersion
						+ ") "
						+ PathProvider.Global.Latest.DisplayName;
				}
			}
		}

		private void rh_LoadedResource(object sender, ResourceEventArgs es)
		{
			foreach (ResourceContainer e in es)
			{
				if (e.HasResource)
				{
					resourceViewManager1.SelectResource(e.Resource);
				}
			}
		}

		private void Activate_miOpenInEp(object sender, EventArgs e)
		{
			if (sender is ToolStripMenuItem mi)
			{
				if (mi.Tag is ExpansionItem ei)
				{
					ofd.InitialDirectory = Path.Combine(
						ei.InstallFolder,
						@"TSData\Res"
					);
					ofd.FileName = "";
					Activate_miOpen(sender, e);
				}
			}
		}

		private void Activate_miOpenSimsRes(object sender, EventArgs e)
		{
			ofd.InitialDirectory = Path.Combine(
				PathProvider.Global[Expansions.BaseGame].InstallFolder,
				@"TSData\Res"
			);
			ofd.FileName = "";
			Activate_miOpen(sender, e);
		}

		private void Activate_miOpenDownloads(object sender, EventArgs e)
		{
			if (

					PathProvider.Global.GetSaveGamePathForGroup(
						PathProvider.Global.CurrentGroup
					)
					.Count > 0
			)
			{
				ofd.InitialDirectory = Path.Combine(
					PathProvider.Global.GetSaveGamePathForGroup(
						PathProvider.Global.CurrentGroup
					)[0],
					"Downloads"
				);
			}
			else
			{
				ofd.InitialDirectory = Path.Combine(
					PathProvider.SimSavegameFolder,
					"Downloads"
				);
			}

			ofd.FileName = "";
			Activate_miOpen(sender, e);
		}

		private void SetRcolNameFilter(object sender, EventArgs e)
		{
			filter.FilterGroup = false;
			try
			{
				string name = Hashes.StripHashFromName(tbRcolName.Text);
				filter.Instance = Hashes.InstanceHash(name);
				//filter.Group = Hashes.GroupHash(this.tbRcolName.Text);
				filter.FilterInstance = (name.Trim() != "");
				//filter.FilterGroup = filter.FilterInstance;
			}
			catch
			{
				filter.FilterInstance = false;
			}
			;
		}

		private void SetSemiGlobalFilter(object sender, EventArgs e)
		{
			filter.FilterInstance = false;
			try
			{
				if (cbsemig.SelectedItem is Data.SemiGlobalAlias sga)
				{
					if (sga != null)
					{
						string name = Hashes.StripHashFromName(tbRcolName.Text);
						filter.Group = sga.Id;
						filter.FilterGroup = (cbsemig.Text.Trim() != "");
					}
				}
				else
				{
					filter.FilterGroup = false;
				}
			}
			catch
			{
				filter.FilterGroup = false;
			}
		}

		private void sdm_DockControlActivated(
			object sender,
			TD.SandDock.DockControlEventArgs e
		)
		{
			if (!e.DockControl.Collapsed)
			{
				lv.BringToFront();
			}
		}

		private void Activate_miSaveCopyAs(object sender, EventArgs e)
		{
			sfd.Filter = ExtensionProvider.BuildFilterString(
				new ExtensionType[]
				{
					ExtensionType.Package,
					ExtensionType.DisabledPackage,
					ExtensionType.AllFiles,
				}
			);

			sfd.FileName = package.FileName;
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				Packages.GeneratableFile gf = (Packages.GeneratableFile)
					package.Package.Clone();
				gf.Save(sfd.FileName);
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

		private void Activate_miReload(object sender, EventArgs e)
		{
			ReloadLayout();
		}

		void MakeFloatable(DockPanel dw, bool fl)
		{
			dw.ShowCloseButton = fl;
			dw.ShowCollapseButton = fl;
			dw.CanUndock = fl;
			dw.CanResize = true;
		}

		void MakeFloatable(bool fl)
		{
			manager.SuspendLayout();
			foreach (object o in miWindow.DropDownItems)
			{
				if (!(o is ToolStripMenuItem mi))
				{
					continue;
				}

				if (mi.Tag == null)
				{
					continue;
				}

				DockPanel dw = mi.Tag as DockPanel;

				MakeFloatable(dw, fl);
			}

			MakeFloatable(dcFilter, fl);
			MakeFloatable(dcResource, fl);
			MakeFloatable(dcPlugin, fl);

			dcPlugin.AllowClose = false;
			manager.ResumeLayout();
		}

		private void UnLockDocks(object sender, EventArgs e)
		{
			MakeFloatable(true);
		}

		private void LockDocks(object sender, EventArgs e)
		{
			MakeFloatable(false);
		}

		private void dcFilter_SizeChanged(object sender, EventArgs e)
		{
			// cbsemig.Width = dcFilter.Width - 24;
		}

		void menuBarItem5_VisibleChanged(object sender, EventArgs e)
		{
			mbiTopics.Visible = mbiTopics.DropDownItems.Count > 0;
		}

		void tbDebug_Click(object sender, EventArgs e)
		{
			Ambertation.Windows.Forms.Debug.StructureTreeView.Execute(manager);
		}

		private void miShowName_Click(object sender, EventArgs e)
		{
			if (package == null)
			{
				return;
			}

			string[] sa = package.FileName.Split(new char[] { '\\' });
			string s = sa[0];
			for (int i = 1; i < sa.Length; i++)
			{
				s += "\\\r\n";
				for (int j = 0; j < i; j++)
				{
					s += "  ";
				}

				s += sa[i];
			}

			MessageBox.Show(
				s,
				"SimPe",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information
			);
		}

		/// <summary>
		/// Write out profile files
		/// </summary>
		private void saveProfile()
		{
			Helper.WindowsRegistry.Flush(); // Writes SimPeXREGW
			StoreLayout(); // Writes SimPeLayoutW
			Helper.WindowsRegistry.Layout.Flush(); // Writes Layout2XREGW
			File.SetLastWriteTime(Helper.DataFolder.FoldersXREGW, DateTime.Now); // It was written by the Options form
		}

		private void tsmiSaveProfile_Click(object sender, EventArgs e)
		{
			ProfileChooser pc = new ProfileChooser();
			if (pc.ShowDialog() != DialogResult.OK)
			{
				return;
			}

			string path = Path.Combine(Helper.DataFolder.Profiles, pc.Value);

			saveProfile();

			File.Copy(
				Helper.DataFolder.SimPeXREGW,
				Path.Combine(path, Path.GetFileName(Helper.DataFolder.SimPeXREG)),
				true
			);
			File.Copy(
				Helper.DataFolder.SimPeLayoutW,
				Path.Combine(path, Path.GetFileName(Helper.DataFolder.SimPeLayout)),
				true
			);
			File.Copy(
				Helper.DataFolder.Layout2XREGW,
				Path.Combine(path, Path.GetFileName(Helper.DataFolder.Layout2XREG)),
				true
			);
			File.Copy(
				Helper.DataFolder.FoldersXREGW,
				Path.Combine(path, Path.GetFileName(Helper.DataFolder.FoldersXREG)),
				true
			);
			if (
				!File.Exists(
					Path.Combine(
						path,
						Path.GetFileName(Helper.DataFolder.ExpansionsXREG)
					)
				)
			)
			{
				File.Copy(
					Helper.DataFolder.ExpansionsXREGW,
					Path.Combine(
						path,
						Path.GetFileName(Helper.DataFolder.ExpansionsXREG)
					),
					true
				);
			}

			MessageBox.Show(
				Localization.GetString("spWrittenDesc"),
				Localization.GetString("spWritten"),
				MessageBoxButtons.OK
			);
		}

		private void tsmiSavePrefs_Click(object sender, EventArgs e)
		{
			saveProfile();

			MessageBox.Show(
				Localization.GetString("Done!"),
				tsmiSavePrefs.Text,
				MessageBoxButtons.OK
			);
		}

		private void tsmiStopWaiting_Click(object sender, EventArgs e)
		{
			Application.UseWaitCursor = false;
			Wait.Stop();
			WaitingScreen.Stop();
			Splash.Screen.Stop();
			Cursor = Cursors.Default;
		}
	}
}
