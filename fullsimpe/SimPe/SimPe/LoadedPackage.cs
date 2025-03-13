// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using SimPe.Data;
using SimPe.Events;
using SimPe.Interfaces.Files;

using Message = SimPe.Forms.MainUI.Message;

namespace SimPe
{
	/// <summary>
	/// Used to load Packages from the FileSystem
	/// </summary>
	public class LoadedPackage : IDisposable
	{
		/// <summary>
		/// Creates a new Instance
		/// </summary>
		public LoadedPackage()
		{
		}

		/// <summary>
		/// Maximum Number of Characters in the Recent File Menu
		/// </summary>
		const int MAX_FILENAME_LENGTH = 75;

		#region Events
		/// <summary>
		/// Called when a Recent File should be loaded
		/// </summary>
		public event PackageFileLoadEvent BeforeRecentFileLoad;

		/// <summary>
		/// Called after a Recent File was sucesfully Loaded
		/// </summary>
		public event PackageFileLoadedEvent AfterRecentFileLoad;

		/// <summary>
		/// Called when a File should be saved
		/// </summary>
		public event PackageFileSaveEvent BeforeFileSave;

		/// <summary>
		/// Called after a File was sucesfully SAved
		/// </summary>
		public event PackageFileSavedEvent AfterFileSave;

		/// <summary>
		/// Called before any File is loaded
		/// </summary>
		public event PackageFileLoadEvent BeforeFileLoad;

		/// <summary>
		/// Called before any File is loaded
		/// </summary>
		public event PackageFileCloseEvent BeforeFileClose;

		/// <summary>
		/// Called After any File was sucesfully loaded
		/// </summary>
		public event PackageFileLoadedEvent AfterFileLoad;

		/// <summary>
		/// Triggered whenever the Content of the Package was changed
		/// </summary>
		public event EventHandler IndexChanged;

		/// <summary>
		/// Triggered after a package got Saved somewhere (not necesarry by this class!)
		/// </summary>
		public event EventHandler SavedIndex;

		/// <summary>
		/// Triggered whenever a new Resource was added
		/// </summary>
		public event EventHandler AddedResource;

		/// <summary>
		/// Triggered whenever a Resource was Removed
		/// </summary>
		public event EventHandler RemovedResource;
		#endregion


		/// <summary>
		/// Returns the current Package or null if it is not loaded
		/// </summary>
		public Packages.GeneratableFile Package
		{
			get; private set;
		}

		/// <summary>
		/// true, if a package was loaded
		/// </summary>
		public bool Loaded => Package != null;

		/// <summary>
		/// returns an empty string or the FileName of the current package
		/// </summary>
		public string FileName => Package == null ? "" : Package.FileName ?? "";

		/// <summary>
		/// Make sure the Events get Linked
		/// </summary>
		/// <param name="add">false, if you want to remove linked Events</param>
		void SetupEvents(bool add)
		{
			if (add)
			{
				Package.IndexChanged += new EventHandler(IndexChangedHandler);
				Package.AddedResource += new EventHandler(AddedResourceHandler);
				Package.RemovedResource += new EventHandler(RemovedResourcehandler);
				Package.SavedIndex += new EventHandler(SavedIndexHandler);

				Packages.StreamFactory.LockStream(Package.SaveFileName);
			}
			else
			{
				Packages.StreamFactory.UnlockStream(Package.SaveFileName);

				Package.IndexChanged -= new EventHandler(IndexChangedHandler);
				Package.AddedResource -= new EventHandler(AddedResourceHandler);
				Package.RemovedResource -= new EventHandler(RemovedResourcehandler);
				Package.SavedIndex -= new EventHandler(SavedIndexHandler);
			}
		}

		/// <summary>
		/// Load a File from the Disc
		/// </summary>
		/// <param name="flname">The Filename</param>
		/// <returns>true, if the file was loaded</returns>
		public bool LoadFromFile(string flname)
		{
			return LoadFromFile(flname, true);
		}

		/// <summary>
		/// Load a File from the Disc
		/// </summary>
		/// <param name="flname">The Filename</param>
		/// <param name="sync">
		/// Only needed if a PackageMaintainer is used. This will tell the Maintainer, that
		/// it should reload the Package from the Disk, and not only get the Package in Memory
		/// </param>
		/// <returns>true, if the file was loaded</returns>
		public bool LoadFromFile(string flname, bool sync)
		{
			bool res = false;
			try
			{
				FileNameEventArg e = new FileNameEventArg(flname);
				if (BeforeFileLoad != null)
				{
					BeforeFileLoad(this, e);
				}

				if (e.Cancel)
				{
					return false;
				}

				Wait.SubStart();
				Wait.Message = "Loading File";

				if (Package != null)
				{
					SetupEvents(false);
				}

				Package = Packages.File.LoadFromFile(e.FileName, sync);

				if (Package.Index.Length < Helper.WindowsRegistry.Config.BigPackageResourceCount)
				{
					Package.LoadCompressedState();
				}

				SetupEvents(true);
				Helper.WindowsRegistry.AddRecentFile(flname);

				Wait.SubStop();

				if (AfterFileLoad != null)
				{
					AfterFileLoad(this);
				}

				res = true;
			}
#if !DEBUG
			catch (Exception ex)
			{
				SimPe.Helper.ExceptionMessage(ex);
			}
#endif
			finally { }
			if (!res)
			{
				Package = null;
			}

			return res;
		}

		/// <summary>
		/// Save the current package
		/// </summary>
		/// <returns></returns>
		public bool Save()
		{
			return FileName.Trim() != "" && Save(FileName, false);
		}

		/// <summary>
		/// Save the current package
		/// </summary>
		/// <param name="filname">the new Filename</param>
		/// <param name="savetocopy">true if you want to save to a copy</param>
		/// <returns></returns>
		public bool Save(string filname, bool savetocopy)
		{
			if (!Loaded)
			{
				return false;
			}

			try
			{
				FileNameEventArg e = new FileNameEventArg(filname);
				if (BeforeFileSave != null)
				{
					BeforeFileSave(this, e);
				}

				if (e.Cancel)
				{
					return false;
				}

				Wait.SubStart();
				Wait.Message = "Saving File";

				string oname = FileName;
				if (Package.Header.Created == 0 && UserVerification.HaveValidUserId)
				{
					Package.Header.Created = UserVerification.UserId;
				}

				Package.Save(e.FileName);

				if (savetocopy)
				{
					Package.FileName = oname;
				}

				Helper.WindowsRegistry.AddRecentFile(e.FileName);

				Wait.SubStop();

				if (AfterFileSave != null)
				{
					AfterFileSave(this);
				}
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(ex);
				return false;
			}

			return true;
		}

		/// <summary>
		/// Load another Package
		/// </summary>
		/// <param name="newpkg">the Package that should be the currently opened</param>
		/// <returns>true, if the file was loaded</returns>
		public bool LoadFromPackage(Packages.GeneratableFile newpkg)
		{
			if (newpkg == null)
			{
				return false;
			}

			string flname = newpkg.FileName ?? "";

			FileNameEventArg e = new FileNameEventArg(flname);
			if (BeforeFileLoad != null)
			{
				BeforeFileLoad(this, e);
			}

			if (e.Cancel)
			{
				return false;
			}

			if (Package != null)
			{
				SetupEvents(false);
			}

			Package = newpkg;
			Package.LoadCompressedState();

			if (Package != null)
			{
				SetupEvents(true);
			}

			if (Package.FileName != null)
			{
				Helper.WindowsRegistry.AddRecentFile(Package.FileName);
			}

			if (AfterFileLoad != null)
			{
				AfterFileLoad(this);
			}

			return true;
		}

		/// <summary>
		/// Update the old Provider Infrastructure
		/// </summary>
		public void UpdateProviders()
		{
			if (
				Helper.IsNeighborhoodFile(FileName)
				&& Helper.WindowsRegistry.Config.LoadMetaInfo
			)
			{
				IPackageFile pkg = Package;
				try
				{
					string mname = Helper.GetMainNeighborhoodFile(pkg.SaveFileName);
					if (mname != pkg.SaveFileName)
					{
						pkg = Packages.File.LoadFromFile(mname);
					}
				}
				catch { }
				FileTableBase.ProviderRegistry.SimFamilynameProvider.BasePackage = pkg;
				FileTableBase.ProviderRegistry.SimDescriptionProvider.BasePackage = pkg;
				FileTableBase.ProviderRegistry.SimNameProvider.BaseFolder =
					System.IO.Path.Combine(
						System.IO.Path.GetDirectoryName(FileName),
						"Characters"
					);
				FileTableBase.ProviderRegistry.LotProvider.BaseFolder =
					System.IO.Path.Combine(
						System.IO.Path.GetDirectoryName(FileName),
						"Lots"
					);
			}
			else
			{
				if (
					Helper.IsLotCatalogFile(FileName)
					&& Helper.WindowsRegistry.Config.LoadMetaInfo
				)
				{
					FileTableBase.ProviderRegistry.SimFamilynameProvider.BasePackage = Package;
					FileTableBase.ProviderRegistry.SimDescriptionProvider.BasePackage = Package;
					FileTableBase.ProviderRegistry.SimNameProvider.BaseFolder =
						System.IO.Path.GetDirectoryName(FileName);
					FileTableBase.ProviderRegistry.LotProvider.BaseFolder =
						System.IO.Path.GetDirectoryName(FileName);
				}
				else
				{
					FileTableBase.ProviderRegistry.SimNameProvider.BaseFolder = "";
					FileTableBase.ProviderRegistry.SimFamilynameProvider.BasePackage = null;
					FileTableBase.ProviderRegistry.SimDescriptionProvider.BasePackage =
						null;
					FileTableBase.ProviderRegistry.LotProvider.BaseFolder = "";
				}
			}
		}

		/// <summary>
		/// Close the current Package
		/// </summary>
		/// <returns>true, if the Package was closed</returns>
		public bool Close()
		{
			if (Package != null)
			{
				bool res = true;
				if (Package.HasUserChanges)
				{
					DialogResult dr = Message.Show(

							Localization.Manager.GetString("savechanges")
							.Replace("{filename}", FileName),
						Localization.Manager.GetString("savechanges?"),
						MessageBoxButtons.YesNoCancel
					);

					if (dr == DialogResult.Yes)
					{
						res = Save();
					}
					else if (dr == DialogResult.Cancel)
					{
						return false;
					}
				}
				if (res)
				{
					FileNameEventArg e = new FileNameEventArg(FileName);
					if (BeforeFileClose != null)
					{
						BeforeFileClose(this, e);
					}

					if (e.Cancel)
					{
						res = false;
					}
				}

				if (res)
				{
					Package.Close();
					SetupEvents(false);
					Package = null;
				}
				else
				{
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// Executed when the user clicks on one of the RecentFiles Menu Items
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OpenRecent(object sender, EventArgs e)
		{
			if (sender is ToolStripMenuItem mbi)
			{
				FileNameEventArg me = new FileNameEventArg(mbi.Tag.ToString());
				if (BeforeRecentFileLoad != null)
				{
					BeforeRecentFileLoad(this, me);
				}

				if (!me.Cancel)
				{
					if (LoadFromFile(me.FileName))
					{
						if (AfterRecentFileLoad != null)
						{
							AfterRecentFileLoad(this);
						}
					}
				}
			}
		}

		/// <summary>
		/// Get a fitting Shortcut
		/// </summary>
		/// <param name="i">Number of the Item</param>
		/// <returns></returns>
		Shortcut GetShortCut(int i)
		{
			switch (i)
			{
				case 1:
					return Shortcut.Ctrl1;
				case 2:
					return Shortcut.Ctrl2;
				case 3:
					return Shortcut.Ctrl3;
				case 4:
					return Shortcut.Ctrl4;
				case 5:
					return Shortcut.Ctrl5;
				case 6:
					return Shortcut.Ctrl6;
				case 7:
					return Shortcut.Ctrl7;
				case 8:
					return Shortcut.Ctrl8;
				case 9:
					return Shortcut.Ctrl9;
				case 10:
					return Shortcut.Ctrl0;
				case 11:
					return Shortcut.Alt1;
				case 12:
					return Shortcut.Alt2;
				case 13:
					return Shortcut.Alt3;
				case 14:
					return Shortcut.Alt4;
				case 15:
					return Shortcut.Alt5;
				case 16:
					return Shortcut.Alt6;
				case 17:
					return Shortcut.Alt7;
				case 18:
					return Shortcut.Alt8;
				case 19:
					return Shortcut.Alt9;
				case 20:
					return Shortcut.Alt0;
				default:
					return Shortcut.None;
			}
		}

		/// <summary>
		/// Add a List of recently Opened Files to the Menu
		/// </summary>
		/// <param name="menu"></param>
		public void UpdateRecentFileMenu(ToolStripMenuItem menu)
		{
			menu.DropDownItems.Clear();

			foreach (string file in Helper.WindowsRegistry.GetRecentFiles())
			{
				if (System.IO.File.Exists(file))
				{
					string sname = file;
					if (sname.Length > MAX_FILENAME_LENGTH)
					{
						sname =
							"..."
							+ sname.Substring(
								file.Length - MAX_FILENAME_LENGTH,
								MAX_FILENAME_LENGTH
							);
					}

					ToolStripMenuItem mbi =
						new ToolStripMenuItem(sname)
						{
							Tag = file
						};
					mbi.Click += new EventHandler(OpenRecent);
					KeysConverter kc = new KeysConverter();

					LoadFileWrappersExt.SetShurtcutKey(
						mbi,
						GetShortCut(menu.DropDownItems.Count + 1)
					);

					menu.DropDownItems.Add(mbi);
				}
			}
		}

		/// <summary>
		/// Load a Package File or add exported Files
		/// </summary>
		/// <param name="names">list of FileNames</param>
		/// <param name="create">true, if you want to create a new Package if none was loaded</param>
		public void LoadOrImportFiles(string[] names, bool create)
		{
			if (names.Length == 0)
			{
				return; // Tashiketh
			}

			if (names.Length == 2 && names[0] == "-load")
			{
				if (System.IO.File.Exists(names[1]))
				{
					LoadFromFile(names[1]);
				}

				return;
			}
			if (!Loaded && !create)
			{
				return;
			}

			if (!Loaded && create)
			{
				LoadFromPackage(Packages.File.CreateNew());
			}

			ExtensionType et = ExtensionProvider.GetExtension(names[0]);
			if (
				names.Length == 1
				&& (et == ExtensionType.Package || et == ExtensionType.DisabledPackage)
			)
			{
				if (System.IO.File.Exists(names[0]))
				{
					LoadFromFile(names[0]);
				}
			}
			else if (
				et == ExtensionType.ExtractedFile
				|| et == ExtensionType.ExtractedFileDescriptor
				|| names.Length > 1
				|| et == ExtensionType.ExtrackedPackageDescriptor
			)
			{
				PauseIndexChangedEvents();
				Package.BeginUpdate();
				try
				{
					for (int i = 0; i < names.Length; i++)
					{
						if (System.IO.File.Exists(names[i]))
						{
							List<IPackedFileDescriptor> pfds = LoadDescriptorsFromDisk(
								names[i]
							);

							foreach (
								IPackedFileDescriptor pfd in pfds
							)
							{
								Package.Add(pfd);
							}
						}
					}
				}
				finally
				{
					Package.EndUpdate();
					RestartIndexChangedEvents();
				}
			}
		}

		#region Statics

		/// <summary>
		/// Load FileDescriptors that are stored in the given File
		/// </summary>
		/// <param name="flnames">List of FileNames</param>
		/// <returns></returns>
		public static List<IPackedFileDescriptor> LoadDescriptorsFromDisk(string[] flnames)
		{
			List<IPackedFileDescriptor> list = new List<IPackedFileDescriptor>();
			foreach (string flname in flnames)
			{
				LoadDescriptorsFromDisk(flname, list);
			}

			return list;
		}

		/// <summary>
		/// Load FileDescriptors that are stored in the given File
		/// </summary>
		/// <param name="flname"></param>
		/// <returns></returns>
		public static List<IPackedFileDescriptor> LoadDescriptorsFromDisk(string flname)
		{
			List<IPackedFileDescriptor> list = new List<IPackedFileDescriptor>();
			LoadDescriptorsFromDisk(flname, list);
			return list;
		}

		/// <summary>
		/// Load FileDescriptors that are stored in the given File
		/// </summary>
		/// <param name="flname"></param>
		/// <param name="list">null or the list that should be used to add the Items</param>
		/// <returns></returns>
		public static void LoadDescriptorsFromDisk(
			string flname,
			List<IPackedFileDescriptor> list
		)
		{
			if (list == null)
			{
				return;
			}

			bool run = WaitingScreen.Running;
			if (!run)
			{
				WaitingScreen.Wait();
			}

			WaitingScreen.UpdateMessage("Load Descriptors From Disk");
			//list = new List<IPackedFileDescriptor>();
			try
			{
				if (flname.ToLower().EndsWith("package.xml"))
				{
					Packages.File pkg = Packages.File.LoadFromStream(
						XmlPackageReader.OpenExtractedPackage(null, flname)
					);
					foreach (IPackedFileDescriptor pfd in pkg.Index)
					{
						IPackedFile file = pkg.Read(pfd);
						pfd.UserData = file.UncompressedData;
						if (!list.Contains(pfd))
						{
							list.Add(pfd);
						}
					}
				}
				else if (flname.ToLower().EndsWith(".xml"))
				{
					IPackedFileDescriptor pfd =
						XmlPackageReader.OpenExtractedPackedFile(flname);
					if (!list.Contains(pfd))
					{
						list.Add(pfd);
					}
				}
				else if (
					flname.ToLower().EndsWith(".package")
					|| flname.ToLower().EndsWith(".simpedis")
				)
				{
					Packages.File pkg = Packages.File.LoadFromFile(flname);
					foreach (IPackedFileDescriptor pfd in pkg.Index)
					{
						IPackedFile file = pkg.Read(pfd);
						pfd.UserData = file.UncompressedData;
						if (!list.Contains(pfd))
						{
							list.Add(pfd);
						}
					}
				}
				else
				{
					Packages.PackedFileDescriptor pfd =
						new Packages.PackedFileDescriptor
						{
							Type = FileTypes.ALL_TYPES
						};
					ToolLoaderItemExt.OpenPackedFile(flname, ref pfd);
					list.Add(pfd);
				}
			}
			finally
			{
				if (!run)
				{
					WaitingScreen.Stop();
				}
			}
		}
		#endregion

		#region IndexChanged Events
		/// <summary>
		/// Triggered whenever the Index of the stored Package was changed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void IndexChangedHandler(object sender, EventArgs e)
		{
			if (paused)
			{
				indexChangedHandler = sender;
			}
			else if (IndexChanged != null)
			{
				IndexChanged(sender, e);
			}
		}

		void SavedIndexHandler(object sender, EventArgs e)
		{
			if (paused)
			{
				savedIndexHandler = sender;
			}
			else if (SavedIndex != null)
			{
				SavedIndex(sender, e);
			}
		}

		object savedIndexHandler;
		object indexChangedHandler;
		object addedResourceHandler;
		object removedResourcehandler;
		bool paused = false;

		/// <summary>
		///Blocks IndexChanged Events until <see cref="RestartIndexChangedEvents"/> is called
		/// </summary>
		public void PauseIndexChangedEvents()
		{
			indexChangedHandler = null;
			addedResourceHandler = null;
			removedResourcehandler = null;
			savedIndexHandler = null;
			paused = true;
		}

		/// <summary>
		/// Unblocks IndexChanged Events. If a Event was fired during the Pause,
		/// the last one will be fired
		/// </summary>
		public void RestartIndexChangedEvents()
		{
			paused = false;
			if (savedIndexHandler != null)
			{
				SavedIndexHandler(savedIndexHandler, null);
			}

			if (indexChangedHandler != null)
			{
				IndexChangedHandler(indexChangedHandler, null);
			}

			if (addedResourceHandler != null)
			{
				AddedResourceHandler(addedResourceHandler, null);
			}

			if (removedResourcehandler != null)
			{
				RemovedResourcehandler(removedResourcehandler, null);
			}
		}

		private void AddedResourceHandler(object sender, EventArgs e)
		{
			if (paused)
			{
				addedResourceHandler = sender;
			}
			else if (AddedResource != null)
			{
				AddedResource(sender, e);
			}
		}

		private void RemovedResourcehandler(object sender, EventArgs e)
		{
			if (paused)
			{
				removedResourcehandler = sender;
			}
			else if (RemovedResource != null)
			{
				RemovedResource(sender, e);
			}
		}
		#endregion

		#region IDisposable Member

		public void Dispose()
		{
		}

		#endregion
	}
}
