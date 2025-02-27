/***************************************************************************
 *   Copyright (C) 2005 by Peter L Jones                                   *
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
using System.IO;
using System.Resources;

using SimPe.Interfaces;
using SimPe.Interfaces.Files;
using SimPe.Interfaces.Plugin;

namespace pjse
{
	/// <summary>
	/// Summary description for FileTable.
	/// </summary>
	public class FileTable
	{
		public static FileTable gft = null;
		public static FileTable GFT
		{
			get
			{
				if (gft == null)
				{
					if (SimPe.FileTable.FileIndex != null)
					{
						gft = new FileTable();
					}

					if (gft != null && FileTableSettings.FTS.LoadAtStartup)
					{
						gft.Refresh();
					}
				}
				return gft;
			}
		}

		public FileTable()
		{
			if (SimPe.FileTable.FileIndex != null)
			{
				SimPe.FileTable.FileIndex.FILoad += new System.EventHandler(
					this.FileIndex_FILoad
				);
			}
		}

		private void FileIndex_FILoad(object sender, System.EventArgs e)
		{
			UIRefresh();
		}

		void wm(string message)
		{
			SimPe.Wait.Message = message;
			SimPe.Wait.Progress++;
			if (SimPe.Splash.Running)
			{
				SimPe.Splash.Screen.SetMessage(message);
			}

			if (SimPe.WaitingScreen.Running)
			{
				SimPe.WaitingScreen.Message = message;
			}

			System.Windows.Forms.Application.DoEvents();
		}

		public void UIRefresh()
		{
			string SplashScreenSetMessage = ""; //can't get old message
			string SimPeWaitingScreenMessage =
				(SimPe.WaitingScreen.Running) ? SimPe.WaitingScreen.Message : "";
			SimPe.Wait.SubStart();

			try
			{
				this.Refresh(true);
			}
			finally
			{
				SimPe.Wait.SubStop();
				if (SimPe.Splash.Running)
				{
					SimPe.Splash.Screen.SetMessage(SplashScreenSetMessage);
				}

				if (SimPe.WaitingScreen.Running)
				{
					SimPe.WaitingScreen.Message = SimPeWaitingScreenMessage;
				}
			}
		}

		private ArrayList fixedPackages = new ArrayList();
		private ArrayList maxisPackages = new ArrayList();
		protected static Hashtable filenames = new Hashtable();
		private Hashtable packedFiles = new Hashtable();
		private Hashtable pfByPackage = new Hashtable();
		private Hashtable pfByType = new Hashtable();
		private Hashtable pfByGroup = new Hashtable();
		private Hashtable pfByTypeGroup = new Hashtable();
		private Hashtable pfByTypeGroupInstance = new Hashtable();

		private bool hasLoaded = false;

		public void Refresh()
		{
			this.Refresh(!SimPe.Helper.LocalMode);
		}

		private void Refresh(bool loadEverything)
		{
			IPackageFile cp = currentPackage;
			CurrentPackage = null;

			hasLoaded = true;
			fixedPackages = new ArrayList();
			maxisPackages = new ArrayList();
			filenames = new Hashtable();
			packedFiles = new Hashtable();
			pfByPackage = new Hashtable();
			pfByType = new Hashtable();
			pfByGroup = new Hashtable();
			pfByTypeGroup = new Hashtable();
			pfByTypeGroupInstance = new Hashtable();

			if (loadEverything)
			{
				if (SimPe.Wait.Running)
				{
					SimPe.Wait.Progress = 0;
					SimPe.Wait.MaxProgress = SimPe.FileTable.DefaultFolders.Count;
				}
				foreach (SimPe.FileTableItem fii in SimPe.FileTable.DefaultFolders)
				{
					if (fii.Use)
					{
						Add(fii.Name, fii.IsRecursive, fii.Type.AsExpansions, true);
					}
				}

				if (SimPe.Wait.Running)
				{
					SimPe.Wait.MaxProgress = 0;
				}
			}

			this.Add(
				Path.Combine(
					SimPe.Helper.SimPePluginPath,
					"pjse.coder.plugin\\GlobalStrings.package"
				),
				false,
				SimPe.Expansions.Custom,
				true
			);

			if (loadEverything)
			{
				this.Add(
					Path.Combine(
						SimPe.Helper.SimPePluginDataPath,
						"pjse.coder.plugin\\Includes"
					),
					true,
					SimPe.Expansions.Custom,
					true
				);
			}

			string packages_txt = Path.Combine(
				SimPe.Helper.SimPePluginDataPath,
				"pjse.coder.plugin\\packages.txt"
			);
			if (loadEverything)
			{
				if (File.Exists(packages_txt))
				{
					System.IO.StreamReader sr = new StreamReader(packages_txt);
					for (
						string line = sr.ReadLine();
						line != null;
						line = sr.ReadLine()
					)
					{
						this.Add(
							line.TrimEnd(new char[] { '+' }),
							line.EndsWith("+"),
							SimPe.Expansions.Custom,
							true
						);
					}

					sr.Close();
					sr.Dispose();
					sr = null;
				}
			}

			CurrentPackage = cp;
		}

		/// <summary>
		/// Indicates the Refresh() was called
		/// </summary>
		public event EventHandler FiletableRefresh;

		public virtual void OnFiletableRefresh(object sender, EventArgs e)
		{
			if (FiletableRefresh != null)
			{
				FiletableRefresh(sender, e);
			}
		}

		private IPackageFile currentPackage = null;
		public IPackageFile CurrentPackage
		{
			get
			{
				return currentPackage;
			}
			set
			{
				if (currentPackage != value)
				{
					if (currentPackage != null)
					{
						currentPackage.AddedResource -= new EventHandler(
							currentPackage_Changed
						);
						currentPackage.RemovedResource -= new EventHandler(
							currentPackage_Changed
						);
						//currentPackage.IndexChanged -= new EventHandler(currentPackage_Changed);
						if (
							hasLoaded
							&& !IsMaxis(currentPackage)
							&& !IsFixed(currentPackage)
						)
						{
							Remove(currentPackage);
						}
					}
					currentPackage = value;
					if (currentPackage != null)
					{
						if (
							hasLoaded
							&& !IsMaxis(currentPackage)
							&& !IsFixed(currentPackage)
						)
						{
							Add(currentPackage, false, false);
						}

						currentPackage.AddedResource += new EventHandler(
							currentPackage_Changed
						);
						currentPackage.RemovedResource += new EventHandler(
							currentPackage_Changed
						);
						//currentPackage.IndexChanged += new EventHandler(currentPackage_Changed);
					}
					if (hasLoaded)
					{
						OnFiletableRefresh(this, new EventArgs());
					}
				}
			}
		}

		private void currentPackage_Changed(object sender, EventArgs e)
		{
			IPackageFile cp = currentPackage;
			CurrentPackage = null;
			CurrentPackage = cp;
		}

		private bool IsMaxis(IPackageFile package)
		{
			if (!hasLoaded)
			{
				Refresh();
			}

			return (package != null && maxisPackages.Contains(package));
		}

		private bool IsFixed(IPackageFile package)
		{
			if (!hasLoaded)
			{
				Refresh();
			}

			return (package != null && fixedPackages.Contains(package));
		}

		private void Add(string v, bool recurse, SimPe.Expansions ep, bool isFixed)
		{
			wm(
				"Loading "
					+ ep
					+ " "
					+ System.IO.Path.GetFileName(v).Replace(".package", "")
			);
			if (Directory.Exists(v))
			{
				foreach (string i in Directory.GetFiles(v, "*.package"))
				{
					Add(i, false, ep, isFixed);
				}

				if (recurse)
				{
					foreach (string i in Directory.GetDirectories(v))
					{
						Add(i, true, ep, isFixed);
					}
				}
			}
			else if (
				!v.ToLowerInvariant()
					.EndsWith(SimPe.Helper.PATH_SEP + "globalcatbin.bundle.package")
				&& File.Exists(v)
			)
			{
				Add(
					SimPe.Packages.File.LoadFromFile(v),
					ep != SimPe.Expansions.Custom,
					isFixed
				);
			}
		}

		private void Add(IPackageFile package, bool isMaxis, bool isFixed)
		{
			if (package == null)
			{
				return;
			}

			if (pfByPackage[package] != null)
			{
				return;
			}

			foreach (IPackedFileDescriptor i in package.Index)
			{
				Add(new Entry(package, i, isMaxis, isFixed));
			}

			if (isMaxis)
			{
				maxisPackages.Add(package);
			}

			if (isFixed)
			{
				fixedPackages.Add(package);
			}
		}

		private void Add(Entry key)
		{
			object val = true;
			uint T = key.Type;
			uint G = key.Group;
			uint I = key.Instance;
			IPackageFile P = key.Package;

			Hashtable byPackage = (Hashtable)pfByPackage[P];
			if (byPackage == null)
			{
				byPackage = (Hashtable)(pfByPackage[P] = new Hashtable());
			}

			if (byPackage[key] != null)
			{
				throw new Exception("byPackage[key] != null");
			}

			byPackage[key] = true;

			if (packedFiles[key] != null)
			{
				throw new Exception("packedFiles[key] != null");
			}

			packedFiles[key] = new object[] { P, T, G, I };

			if (key.PFD.MarkForDelete)
			{
				return;
			}

			Hashtable byType = (Hashtable)pfByType[T];
			if (byType == null)
			{
				byType = (Hashtable)(pfByType[T] = new Hashtable());
			}

			if (byType[key] != null)
			{
				throw new Exception("byType[key] != null");
			}

			byType[key] = val;

			Hashtable byGroup = (Hashtable)pfByGroup[G];
			if (byGroup == null)
			{
				byGroup = (Hashtable)(pfByGroup[G] = new Hashtable());
			}

			if (byGroup[key] != null)
			{
				throw new Exception("byGroup[key] != null");
			}

			byGroup[key] = val;

			Hashtable tgt = (Hashtable)pfByTypeGroup[T];
			if (tgt == null)
			{
				tgt = (Hashtable)(pfByTypeGroup[T] = new Hashtable());
			}

			Hashtable byTypeGroup = (Hashtable)(
				(tgt[G] == null) ? (tgt[G] = new Hashtable()) : tgt[G]
			);
			if (byTypeGroup[key] != null)
			{
				throw new Exception("byTypeGroup[key] != null");
			}

			byTypeGroup[key] = val;

			Hashtable tgit = (Hashtable)pfByTypeGroupInstance[T];
			if (tgit == null)
			{
				tgit = (Hashtable)(pfByTypeGroupInstance[T] = new Hashtable());
			}

			Hashtable tgitg = (Hashtable)(
				(tgit[G] == null) ? (tgit[G] = new Hashtable()) : tgit[G]
			);
			Hashtable byTypeGroupInstance = (Hashtable)(
				(tgitg[I] == null) ? (tgitg[I] = new Hashtable()) : tgitg[I]
			);
			if (byTypeGroupInstance[key] != null)
			{
				throw new Exception("byTypeGroupInstance[key] != null");
			}

			byTypeGroupInstance[key] = val;

			key.PFD.DescriptionChanged += new EventHandler(PFD_DescriptionChanged);
		}

		void PFD_DescriptionChanged(object sender, EventArgs e)
		{
			IPackedFileDescriptor pfd = (IPackedFileDescriptor)sender;

			Entry key = null;
			foreach (object i in packedFiles.Keys)
			{
				if (((Entry)i).PFD == pfd)
				{
					key = (Entry)i;
					break;
				}
			}

			if (key == null)
			{
				pfd.DescriptionChanged -= new EventHandler(PFD_DescriptionChanged);
				return;
			}

			Remove(key);
			key = new Entry(key.Package, pfd, key.IsMaxis, key.IsFixed);
			Add(key);

			OnFiletableRefresh(this, new EventArgs());
		}

		private void Remove(IPackageFile package)
		{
			Hashtable byPackage = (Hashtable)pfByPackage[package];
			if (byPackage == null)
			{
				return;
			}

			Entry[] keys = new Entry[byPackage.Keys.Count];
			byPackage.Keys.CopyTo(keys, 0);
			try
			{
				foreach (object key in keys)
				{
					Remove((Entry)key);
				}
			}
			catch (Exception e)
			{
				SimPe.Helper.ExceptionMessage(e);
				throw e;
			}

			pfByPackage.Remove(package);
		}

		private void Remove(Entry key)
		{
			key.PFD.DescriptionChanged -= new EventHandler(PFD_DescriptionChanged);

			if (packedFiles.Contains(key))
			{
				object[] o = (object[])packedFiles[key];
				IPackageFile P = (IPackageFile)o[0];
				uint T = (uint)o[1];
				uint G = (uint)o[2];
				uint I = (uint)o[3];

				packedFiles.Remove(key);
				filenames.Remove(key);

				Hashtable byPackage = (Hashtable)pfByPackage[P];
				if (byPackage[key] != null)
				{
					byPackage.Remove(key);
				}

				Hashtable byType = (Hashtable)pfByType[T];
				if (byType != null)
				{
					byType.Remove(key);
				}

				Hashtable byGroup = (Hashtable)pfByGroup[G];
				if (byGroup != null)
				{
					byGroup.Remove(key);
				}

				Hashtable tgt = (Hashtable)pfByTypeGroup[T];
				if (tgt != null)
				{
					Hashtable byTypeGroup = (Hashtable)tgt[G];
					if (byTypeGroup != null)
					{
						byTypeGroup.Remove(key);
					}
				}

				Hashtable tgit = (Hashtable)pfByTypeGroupInstance[T];
				if (tgit != null)
				{
					Hashtable tgitg = (Hashtable)tgit[G];
					if (tgitg != null)
					{
						Hashtable byTypeGroupInstance = (Hashtable)tgitg[I];
						if (byTypeGroupInstance != null)
						{
							byTypeGroupInstance.Remove(key);
						}
					}
				}
			}
		}

		public enum Source
		{
			Any,
			Maxis,
			Fixed,
			Local,
		};

		public class Entry
			: IDisposable,
				IComparable,
				SimPe.Interfaces.Scenegraph.IScenegraphFileIndexItem
		{
			SimPe.Interfaces.Scenegraph.IScenegraphFileIndexItem fii;

			public Entry(
				IPackageFile package,
				IPackedFileDescriptor pfd,
				bool isMaxis,
				bool isFixed
			)
			{
				this.Package = package;
				this.PFD = pfd;
				this.IsMaxis = isMaxis;
				this.IsFixed = isFixed;

				SimPe.Interfaces.Scenegraph.IScenegraphFileIndexItem[] fiis =
					SimPe.FileTable.FileIndex.FindFile(pfd, package);
				this.fii = (fiis.Length == 1) ? fiis[0] : null;

				this.PFD.ChangedData += new SimPe.Events.PackedFileChanged(
					pfd_ChangedData
				);
			}

			void pfd_ChangedData(IPackedFileDescriptor sender)
			{
				if (FileTable.filenames[this] != null)
				{
					FileTable.filenames.Remove(this);
				}

				FileTable.GFT.OnFiletableRefresh(GFT, new EventArgs());
			}

			public IPackageFile Package
			{
				get; private set;
			}

			public IPackedFileDescriptor PFD
			{
				get; private set;
			}

			public uint Type => PFD.Type;

			public uint Group => PFD.Group;

			public uint Instance => PFD.Instance;

			public bool IsMaxis
			{
				get;
			}

			public bool IsFixed
			{
				get;
			}

			public AbstractWrapper Wrapper
			{
				get
				{
					AbstractWrapper wrapper = (AbstractWrapper)
						SimPe.FileTable.WrapperRegistry.FindHandler(Type);
					if (wrapper != null)
					{
						wrapper.ProcessData(PFD, Package);
					}

					return wrapper;
				}
			}

			public override string ToString()
			{
				return this + " (0x" + SimPe.Helper.HexString((ushort)Instance) + ")";
			}

			public static implicit operator string(Entry e)
			{
				if (FileTable.filenames[e] == null)
				{
					AbstractWrapper wrapper = e.Wrapper;
					if (wrapper != null)
					{
						FileTable.filenames[e] = SimPe
							.Helper.ToString(wrapper.StoredData.ReadBytes(64))
							.Trim();
					}
				}

				return (string)FileTable.filenames[e];
			}

			#region IDisposable Members

			public void Dispose()
			{
				this.Package = null;

				this.PFD.ChangedData -= new SimPe.Events.PackedFileChanged(
					pfd_ChangedData
				);
				this.PFD = null;
			}

			#endregion

			#region IComparable Members

			public int CompareTo(object obj)
			{
				if (!(obj is Entry))
				{
					return -1;
				}

				Entry that = (Entry)obj;

				if (this.Type.CompareTo(that.Type) != 0)
				{
					return this.Type.CompareTo(that.Type);
				}

				if (this.Group.CompareTo(that.Group) != 0)
				{
					return this.Group.CompareTo(that.Group);
				}

				return this.Instance.CompareTo(that.Instance);
			}

			#endregion

			#region IScenegraphFileIndexItem Members

			public IPackedFileDescriptor FileDescriptor
			{
				get
				{
					return PFD;
				}
				set
				{
					throw new Exception("The method or operation is not implemented.");
				}
			}

			public IPackedFileDescriptor GetLocalFileDescriptor()
			{
				return fii.GetLocalFileDescriptor();
			}

			public uint LocalGroup => fii.LocalGroup;

			#endregion
		}

		public Entry[] this[IPackageFile package, IPackedFileDescriptor pfd]
		{
			get
			{
				if (package == null || pfd == null)
				{
					return new Entry[0];
				}

				return this[
					pfd.Type,
					pfd.Group,
					pfd.Instance,
					pfd.Group == 0xffffffff
						? Source.Local
						//: IsMaxis(package) ? Source.Maxis
						//: IsFixed(package) ? Source.Fixed
						: Source.Any
				];
			}
		}

		public Entry[] this[IPackageFile package, uint packedFileType]
		{
			get
			{
				if (!hasLoaded)
				{
					Refresh();
				}

				if (package == null || pfByPackage[package] == null)
				{
					return new Entry[0];
				}

				ArrayList result = new ArrayList();
				foreach (Entry e in ((Hashtable)pfByPackage[package]).Keys)
				{
					if (!e.PFD.MarkForDelete && e.PFD.Type == packedFileType)
					{
						result.Add(e);
					}
				}
				Entry[] es = new Entry[result.Count];
				result.CopyTo(es);
				return es;
			}
		}

		public Entry[] this[uint packedFileType]
		{
			get
			{
				return this[packedFileType, Source.Any];
			}
		}
		public Entry[] this[uint packedFileType, Source where]
		{
			get
			{
				if (!hasLoaded)
				{
					Refresh();
				}

				return putLocalFirst((Hashtable)pfByType[packedFileType], where);
			}
		}

		public Entry[] this[uint packedFileType, uint group]
		{
			get
			{
				return this[
					packedFileType,
					group,
					group == 0xffffffff ? Source.Local : Source.Any
				];
			}
		}
		public Entry[] this[uint packedFileType, uint group, Source where]
		{
			get
			{
				if (!hasLoaded)
				{
					Refresh();
				}

				Hashtable tgt = (Hashtable)pfByTypeGroup[packedFileType];
				if (tgt == null)
				{
					return new Entry[0];
				}

				return putLocalFirst((Hashtable)tgt[group], where);
			}
		}

		public Entry[] this[uint packedFileType, uint group, uint instance]
		{
			get
			{
				return this[packedFileType, group, instance, Source.Any];
			}
		}
		public Entry[] this[
			uint packedFileType,
			uint group,
			uint instance,
			Source where
		]
		{
			get
			{
				if (!hasLoaded)
				{
					Refresh();
				}

				Hashtable tgit = (Hashtable)pfByTypeGroupInstance[packedFileType];
				if (tgit == null)
				{
					return new Entry[0];
				}

				Hashtable tgitg = (Hashtable)tgit[group];
				if (tgitg == null)
				{
					return new Entry[0];
				}

				return putLocalFirst(
					(Hashtable)tgitg[instance],
					group == 0xffffffff ? Source.Local : where
				);
			}
		}

		public Entry[] FindGroup(uint group, Source where)
		{
			if (!hasLoaded)
			{
				Refresh();
			}

			if (pfByGroup == null)
			{
				return new Entry[0];
			}

			return putLocalFirst(
				(Hashtable)pfByGroup[group],
				group == 0xffffffff ? Source.Local : where
			);
		}

		private Entry[] putLocalFirst(Hashtable result, Source where)
		{
			if (result == null)
			{
				return new Entry[0];
			}

			ArrayList currpkg = new ArrayList();
			ArrayList maxispkg = new ArrayList();
			ArrayList fixedpkg = new ArrayList();
			ArrayList nonfixed = new ArrayList();

			ArrayList[] resultset =
				where == Source.Local ? new ArrayList[] { currpkg }
				: where == Source.Maxis
					? IsMaxis(currentPackage) ? new ArrayList[] { currpkg, maxispkg }
						: new ArrayList[] { maxispkg }
				: where == Source.Fixed
					? IsFixed(currentPackage) ? new ArrayList[] { currpkg, fixedpkg }
						: new ArrayList[] { fixedpkg }
				: new ArrayList[] { currpkg, nonfixed, fixedpkg, maxispkg };

			foreach (Entry e in result.Keys)
			{
				if (!e.PFD.MarkForDelete)
				{
					(
						(ArrayList)(
							e.Package == currentPackage ? currpkg
							: e.IsMaxis ? maxispkg
							: e.IsFixed ? fixedpkg
							: nonfixed
						)
					).Add(e);
				}
			}

			int i = 0;
			foreach (ArrayList al in resultset)
			{
				i += al.Count;
			}

			Entry[] es = new Entry[i];
			i = 0;
			foreach (ArrayList al in resultset)
			{
				al.CopyTo(es, i);
				i += al.Count;
			}

			return es;
		}
	}

	public class FileTableTool : ITool
	{
		#region ITool Members

		public bool IsEnabled(IPackedFileDescriptor pfd, IPackageFile package)
		{
#if DEBUG
			pjse.FileTable.GFT.CurrentPackage = package;
#else
			try
			{
				pjse.FileTable.GFT.CurrentPackage = package;
			}
			catch (Exception e)
			{
				SimPe.Helper.ExceptionMessage(e);
				throw e;
			}
#endif
			return true;
		}

		public IToolResult ShowDialog(
			ref IPackedFileDescriptor pfd,
			ref IPackageFile package
		)
		{
			SimPe.FileTable.Reload();
			return new SimPe.Plugin.ToolResult(false, false);
		}

		#region IToolPlugin Members

		public override string ToString()
		{
			return "PJSE\\" + pjse.Localization.GetString("ft_Refresh");
		}

		#endregion
		#endregion
	}

	public class FileTableSettings : SimPe.GlobalizedObject, ISettings
	{
		static ResourceManager rm = new ResourceManager(typeof(pjse.Localization));

		public static FileTableSettings FTS
		{
			get; private set;
		}

		static FileTableSettings()
		{
			FTS = new FileTableSettings();
		}

		const string BASENAME = "PJSE\\Bhav";
		SimPe.XmlRegistryKey xrk = SimPe.Helper.WindowsRegistry.PluginRegistryKey;

		public FileTableSettings()
			: base(rm) { }

		[System.ComponentModel.Category("FT")]
		public bool LoadAtStartup
		{
			get
			{
				SimPe.XmlRegistryKey rkf =
					SimPe.Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey(
						BASENAME
					);
				object o = rkf.GetValue("loadAtStartup", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				SimPe.XmlRegistryKey rkf =
					SimPe.Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey(
						BASENAME
					);
				rkf.SetValue("loadAtStartup", value);
			}
		}

		#region ISettings Members

		public object GetSettingsObject()
		{
			return this;
		}

		public override string ToString()
		{
			return pjse.Localization.GetString("ft_Settings");
		}

		[System.ComponentModel.Browsable(false)]
		public System.Drawing.Image Icon => null;

		#endregion
	}

	public class FileTableWrapperFactory
		: AbstractWrapperFactory,
			IToolFactory,
			ISettingsFactory
	{
		#region IToolFactory Members

		public IToolPlugin[] KnownTools => new IToolPlugin[] { new pjse.FileTableTool() };

		#endregion

		#region ISettingsFactory Members

		public ISettings[] KnownSettings => new ISettings[] { FileTableSettings.FTS };

		#endregion
	}
}
