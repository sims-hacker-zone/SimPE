// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;

using SimPe;
using SimPe.Data;
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
					if (FileTableBase.FileIndex != null)
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
			if (FileTableBase.FileIndex != null)
			{
				FileTableBase.FileIndex.FILoad += new EventHandler(
					FileIndex_FILoad
				);
			}
		}

		private void FileIndex_FILoad(object sender, EventArgs e)
		{
			UIRefresh();
		}

		void wm(string message)
		{
			Wait.Message = message;
			Wait.Progress++;
			if (Splash.Running)
			{
				Splash.Screen.SetMessage(message);
			}

			if (WaitingScreen.Running)
			{
				WaitingScreen.Message = message;
			}

			System.Windows.Forms.Application.DoEvents();
		}

		public void UIRefresh()
		{
			string SplashScreenSetMessage = ""; //can't get old message
			string SimPeWaitingScreenMessage =
				WaitingScreen.Running ? WaitingScreen.Message : "";
			Wait.SubStart();

			try
			{
				Refresh(true);
			}
			finally
			{
				Wait.SubStop();
				if (Splash.Running)
				{
					Splash.Screen.SetMessage(SplashScreenSetMessage);
				}

				if (WaitingScreen.Running)
				{
					WaitingScreen.Message = SimPeWaitingScreenMessage;
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
			Refresh(!Helper.LocalMode);
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
				if (Wait.Running)
				{
					Wait.Progress = 0;
					Wait.MaxProgress = FileTableBase.DefaultFolders.Count;
				}
				foreach (FileTableItem fii in FileTableBase.DefaultFolders)
				{
					if (fii.Use)
					{
						Add(fii.Name, fii.IsRecursive, fii.Type.AsExpansions, true);
					}
				}

				if (Wait.Running)
				{
					Wait.MaxProgress = 0;
				}
			}

			Add(
				Path.Combine(
					Helper.SimPePluginPath,
					"pjse.coder.plugin\\GlobalStrings.package"
				),
				false,
				Expansions.Custom,
				true
			);

			if (loadEverything)
			{
				Add(
					Path.Combine(
						Helper.SimPePluginDataPath,
						"pjse.coder.plugin\\Includes"
					),
					true,
					Expansions.Custom,
					true
				);
			}

			string packages_txt = Path.Combine(
				Helper.SimPePluginDataPath,
				"pjse.coder.plugin\\packages.txt"
			);
			if (loadEverything)
			{
				if (File.Exists(packages_txt))
				{
					StreamReader sr = new StreamReader(packages_txt);
					for (
						string line = sr.ReadLine();
						line != null;
						line = sr.ReadLine()
					)
					{
						Add(
							line.TrimEnd(new char[] { '+' }),
							line.EndsWith("+"),
							Expansions.Custom,
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
			get => currentPackage;
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

			return package != null && maxisPackages.Contains(package);
		}

		private bool IsFixed(IPackageFile package)
		{
			if (!hasLoaded)
			{
				Refresh();
			}

			return package != null && fixedPackages.Contains(package);
		}

		private void Add(string v, bool recurse, Expansions ep, bool isFixed)
		{
			wm(
				"Loading "
					+ ep
					+ " "
					+ Path.GetFileName(v).Replace(".package", "")
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
					.EndsWith(Helper.PATH_SEP + "globalcatbin.bundle.package")
				&& File.Exists(v)
			)
			{
				Add(
					SimPe.Packages.File.LoadFromFile(v),
					ep != Expansions.Custom,
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
			FileTypes T = key.Type;
			uint G = key.Group;
			uint I = key.Instance;
			IPackageFile P = key.Package;

			Hashtable byPackage = (Hashtable)pfByPackage[P] ?? (Hashtable)(pfByPackage[P] = new Hashtable());

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

			Hashtable byType = (Hashtable)pfByType[T] ?? (Hashtable)(pfByType[T] = new Hashtable());

			if (byType[key] != null)
			{
				throw new Exception("byType[key] != null");
			}

			byType[key] = val;

			Hashtable byGroup = (Hashtable)pfByGroup[G] ?? (Hashtable)(pfByGroup[G] = new Hashtable());

			if (byGroup[key] != null)
			{
				throw new Exception("byGroup[key] != null");
			}

			byGroup[key] = val;

			Hashtable tgt = (Hashtable)pfByTypeGroup[T] ?? (Hashtable)(pfByTypeGroup[T] = new Hashtable());

			Hashtable byTypeGroup = (Hashtable)(tgt[G] ?? (tgt[G] = new Hashtable()));
			if (byTypeGroup[key] != null)
			{
				throw new Exception("byTypeGroup[key] != null");
			}

			byTypeGroup[key] = val;

			Hashtable tgit = (Hashtable)pfByTypeGroupInstance[T] ?? (Hashtable)(pfByTypeGroupInstance[T] = new Hashtable());

			Hashtable tgitg = (Hashtable)(tgit[G] ?? (tgit[G] = new Hashtable()));
			Hashtable byTypeGroupInstance = (Hashtable)(tgitg[I] ?? (tgitg[I] = new Hashtable()));
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
				Helper.ExceptionMessage(e);
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
				byType?.Remove(key);

				Hashtable byGroup = (Hashtable)pfByGroup[G];
				byGroup?.Remove(key);

				Hashtable tgt = (Hashtable)pfByTypeGroup[T];
				if (tgt != null)
				{
					Hashtable byTypeGroup = (Hashtable)tgt[G];
					byTypeGroup?.Remove(key);
				}

				Hashtable tgit = (Hashtable)pfByTypeGroupInstance[T];
				if (tgit != null)
				{
					Hashtable tgitg = (Hashtable)tgit[G];
					if (tgitg != null)
					{
						Hashtable byTypeGroupInstance = (Hashtable)tgitg[I];
						byTypeGroupInstance?.Remove(key);
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
				Package = package;
				PFD = pfd;
				IsMaxis = isMaxis;
				IsFixed = isFixed;

				fii = FileTableBase.FileIndex.FindFile(pfd, package).FirstOrDefault();

				PFD.ChangedData += new SimPe.Events.PackedFileChanged(
					pfd_ChangedData
				);
			}

			void pfd_ChangedData(IPackedFileDescriptor sender)
			{
				if (filenames[this] != null)
				{
					filenames.Remove(this);
				}

				GFT.OnFiletableRefresh(GFT, new EventArgs());
			}

			public IPackageFile Package
			{
				get; private set;
			}

			public IPackedFileDescriptor PFD
			{
				get; private set;
			}

			public FileTypes Type => PFD.Type;

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
						FileTableBase.WrapperRegistry.FindHandler(Type);
					wrapper?.ProcessData(PFD, Package);

					return wrapper;
				}
			}

			public override string ToString()
			{
				return this + " (0x" + Helper.HexString((ushort)Instance) + ")";
			}

			public static implicit operator string(Entry e)
			{
				if (filenames[e] == null)
				{
					AbstractWrapper wrapper = e.Wrapper;
					if (wrapper != null)
					{
						filenames[e] =
							Helper.ToString(wrapper.StoredData.ReadBytes(64))
							.Trim();
					}
				}

				return (string)filenames[e];
			}

			#region IDisposable Members

			public void Dispose()
			{
				Package = null;

				PFD.ChangedData -= new SimPe.Events.PackedFileChanged(
					pfd_ChangedData
				);
				PFD = null;
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

				return Type.CompareTo(that.Type) != 0
					? Type.CompareTo(that.Type)
					: Group.CompareTo(that.Group) != 0 ? Group.CompareTo(that.Group) : Instance.CompareTo(that.Instance);
			}

			#endregion

			#region IScenegraphFileIndexItem Members

			public IPackedFileDescriptor FileDescriptor
			{
				get => PFD;
				set => throw new Exception("The method or operation is not implemented.");
			}

			public IPackedFileDescriptor GetLocalFileDescriptor()
			{
				return fii.GetLocalFileDescriptor();
			}

			public uint LocalGroup => fii.LocalGroup;

			#endregion
		}

		public Entry[] this[IPackageFile package, IPackedFileDescriptor pfd] => package == null || pfd == null
					? (new Entry[0])
					: this[
					pfd.Type,
					pfd.Group,
					pfd.Instance,
					pfd.Group == 0xffffffff
						? Source.Local
						//: IsMaxis(package) ? Source.Maxis
						//: IsFixed(package) ? Source.Fixed
						: Source.Any
				];

		public Entry[] this[IPackageFile package, FileTypes packedFileType]
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

		public Entry[] this[FileTypes packedFileType] => this[packedFileType, Source.Any];
		public Entry[] this[FileTypes packedFileType, Source where]
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

		public Entry[] this[FileTypes packedFileType, uint group] => this[
					packedFileType,
					group,
					group == 0xffffffff ? Source.Local : Source.Any
				];
		public Entry[] this[FileTypes packedFileType, uint group, Source where]
		{
			get
			{
				if (!hasLoaded)
				{
					Refresh();
				}

				Hashtable tgt = (Hashtable)pfByTypeGroup[packedFileType];
				return tgt == null ? (new Entry[0]) : putLocalFirst((Hashtable)tgt[group], where);
			}
		}

		public Entry[] this[FileTypes packedFileType, uint group, uint instance] => this[packedFileType, group, instance, Source.Any];
		public Entry[] this[
			FileTypes packedFileType,
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
				return tgitg == null
					? (new Entry[0])
					: putLocalFirst(
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

			return pfByGroup == null
				? (new Entry[0])
				: putLocalFirst(
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

							e.Package == currentPackage ? currpkg
							: e.IsMaxis ? maxispkg
							: e.IsFixed ? fixedpkg
							: nonfixed

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
			FileTable.GFT.CurrentPackage = package;
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
			return "PJSE\\" + Localization.GetString("ft_Refresh");
		}

		#endregion
		#endregion
	}

	public class FileTableSettings : GlobalizedObject, ISettings
	{
		private readonly Dictionary<string, string> options;
		static ResourceManager rm = new ResourceManager(typeof(Localization));

		public static FileTableSettings FTS
		{
			get; private set;
		}

		static FileTableSettings()
		{
			FTS = new FileTableSettings();
		}

		const string BASENAME = "PJSE\\Bhav";

		public FileTableSettings()
			: base(rm)
		{
			if (!Helper.WindowsRegistry.Config.PluginSettings.ContainsKey(BASENAME))
			{
				Helper.WindowsRegistry.Config.PluginSettings[BASENAME] = new Dictionary<string, string>();
			}
			options = Helper.WindowsRegistry.Config.PluginSettings[BASENAME];
		}

		[System.ComponentModel.Category("FT")]
		public bool LoadAtStartup
		{
			get
			{
				if (!options.ContainsKey("LoadAtStartup"))
				{
					options["LoadAtStartup"] = true.ToString();
				}
				return bool.Parse(options["LoadAtStartup"]);
			}
			set => options["LoadAtStartup"] = value.ToString();
		}

		#region ISettings Members

		public object GetSettingsObject()
		{
			return this;
		}

		public override string ToString()
		{
			return Localization.GetString("ft_Settings");
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

		public IToolPlugin[] KnownTools => new IToolPlugin[] { };

		#endregion

		#region ISettingsFactory Members

		public ISettings[] KnownSettings => new ISettings[] { FileTableSettings.FTS };

		#endregion
	}
}
