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
using System.Drawing;

using SimPe.Cache;
using SimPe.Interfaces.Plugin.Scanner;
using SimPe.PackedFiles.Wrapper;

namespace SimPe.Plugin.Scanner
{
	/// <summary>
	/// Abstract Base class for all Scanners
	/// </summary>
	public abstract class AbstractScanner
	{
		public delegate void UpdateList(bool savecache, bool rescan);

		#region Static Methods
		static Size sz;

		/// <summary>
		/// Returns the suggested Size for Thumbnails
		/// </summary>
		public static Size ThumbnailSize
		{
			get
			{
				if (sz.Width == 0)
				{
					sz = new Size(96, 96);
				}

				return sz;
			}
		}

		/// <summary>
		/// Add a new Column to a ListView
		/// </summary>
		/// <param name="lv"></param>
		/// <param name="name"></param>
		public static void AddColumn(
			System.Windows.Forms.ListView lv,
			string name,
			int width
		)
		{
			System.Windows.Forms.ColumnHeader ch =
				new System.Windows.Forms.ColumnHeader();
			ch.Text = name;
			lv.Columns.Add(ch);

			if (width > 0)
			{
				ch.Width = width;
			}
		}

		/// <summary>
		/// Set the Name and color of a Column
		/// </summary>
		/// <param name="lvi">The ListViewItem where you want to add that column</param>
		/// <param name="index">The Index of the Column</param>
		/// <param name="name">The Name you want to display</param>
		public static void SetSubItem(
			System.Windows.Forms.ListViewItem lvi,
			int index,
			string name
		)
		{
			SetSubItem(lvi, index, name, lvi.ForeColor);
		}

		/// <summary>
		/// Set the Name and color of a Column
		/// </summary>
		/// <param name="lvi">The ListViewItem where you want to add that column</param>
		/// <param name="index">The Index of the Column</param>
		/// <param name="name">The Name you want to display</param>
		/// <param name="ps">If state is null, the default color is used, false will be red, true will be green</param>
		public static void SetSubItem(
			System.Windows.Forms.ListViewItem lvi,
			int index,
			string name,
			PackageState ps
		)
		{
			Color cl = lvi.ForeColor;
			if (ps != null)
			{
				if (ps.State == SimPe.Cache.TriState.True)
				{
					cl = System.Drawing.Color.Green;
				}
				else if (ps.State == SimPe.Cache.TriState.False)
				{
					cl = System.Drawing.Color.Red;
				}
			}

			SetSubItem(lvi, index, name, cl);
		}

		/// <summary>
		/// Set the Name and color of a Column
		/// </summary>
		/// <param name="lvi">The ListViewItem where you want to add that column</param>
		/// <param name="index">The Index of the Column</param>
		/// <param name="name">The Name you want to display</param>
		/// <param name="cl">The Color for this Item</param>
		public static void SetSubItem(
			System.Windows.Forms.ListViewItem lvi,
			int index,
			string name,
			Color cl
		)
		{
			if (cl == System.Drawing.Color.Red)
			{
				lvi.ForeColor = cl;
			}

			while (lvi.SubItems.Count <= index)
			{
				lvi.SubItems.Add("");
			}

			lvi.SubItems[index].Text = name;
			lvi.SubItems[index].ForeColor = cl;
		}

		#endregion

		#region IScannerPluginBase Member
		public ScannerPluginType PluginType => ScannerPluginType.Scanner;
		#endregion

		#region FileIndex Addition
		static Interfaces.Scenegraph.IScenegraphFileIndex mfi;

		/// <summary>
		/// Returns a FileTable, that is unly used for the event of scanning Files, and will be removed from the global FileTable afterwards
		/// </summary>
		public static Interfaces.Scenegraph.IScenegraphFileIndex MyFileIndex
		{
			get
			{
				if (mfi == null)
				{
					AssignFileTable();
				}

				return mfi;
			}
		}

		public static void AssignFileTable()
		{
			DeAssignFileTable();
			if (mfi == null)
			{
				mfi = FileTable.FileIndex.AddNewChild();
			}
			else
			{
				FileTable.FileIndex.AddChild(mfi);
			}
		}

		public static void DeAssignFileTable()
		{
			if (mfi != null)
			{
				FileTable.FileIndex.RemoveChild(mfi);
				mfi.Clear();
				mfi.ClearChilds();
			}

			mfi = null;
		}

		protected Interfaces.Scenegraph.IScenegraphFileIndex FileIndex => MyFileIndex;
		#endregion

		#region IScanner Implementations


		/// <summary>
		/// Returns the uid assigned to this specific Scanner
		/// </summary>
		/// <remarks>
		/// the uid is calulated using the Filename, class name, namespace
		/// and visible Name of the Scanner. Changing either one of the, will
		/// result in a new uid and force a rescan of the State
		/// </remarks>
		public uint Uid
		{
			get;
		}

		/// <summary>
		/// Returns true, if this Scanner should be listed on the Top of the List
		/// </summary>
		public virtual bool OnTop => false;

		/// <summary>
		/// Returns the first Colum in the Listview that was used for this Scanner
		/// </summary>
		protected int StartColum
		{
			get; private set;
		}

		/// <summary>
		/// Returns the ListView that was assigned to this Scanner
		/// </summary>
		protected System.Windows.Forms.ListView ListView
		{
			get; private set;
		}

		protected AbstractScanner()
		{
			byte[] b = Helper.ToBytes(this.UniqueName);
			this.Uid = BitConverter.ToUInt32(
				Hashes.Crc32.ComputeHash(b, 0, b.Length),
				0
			);
			this.StartColum = 0;
		}

		public void InitScan(System.Windows.Forms.ListView lv)
		{
			this.ListView = lv;
			this.StartColum = lv.Columns.Count;
			DoInitScan();
		}

		public virtual bool IsActiveByDefault => false;

		System.Windows.Forms.Control mycontrol;
		public virtual System.Windows.Forms.Control OperationControl
		{
			get
			{
				if (mycontrol == null)
				{
					mycontrol = CreateOperationControl();
				}

				return mycontrol;
			}
		}

		public void EnableControl(bool active)
		{
			EnableControl(new ScannerItem[0], active);
		}

		public void EnableControl(ScannerItem item, bool active)
		{
			if (item != null)
			{
				ScannerItem[] items = new ScannerItem[1];
				items[0] = item;

				EnableControl(items, active);
			}
			else
			{
				EnableControl(new ScannerItem[0], active);
			}
		}

		public virtual void EnableControl(ScannerItem[] items, bool active)
		{
			if (OperationControl != null)
			{
				OperationControl.Enabled = active;
			}
		}

		/// <summary>
		/// Retunrs the Function that should be called after a OperatioControl Execution (can be null);
		/// </summary>
		protected UpdateList CallbackFinish
		{
			get; private set;
		}

		public void SetFinishCallback(
			UpdateList fkt
		)
		{
			CallbackFinish = fkt;
		}
		#endregion

		protected string UniqueName
		{
			get
			{
				Type t = GetType();
				string[] parts = t.Assembly.FullName.Split(",".ToCharArray(), 2);

				string ret = ToString() + ";" + t.Namespace + "." + t.Name + ".";
				if (parts.Length > 0)
				{
					ret += ";" + parts[0];
				}

				return ret;
			}
		}

		protected virtual System.Windows.Forms.Control CreateOperationControl()
		{
			return null;
		}

		protected abstract void DoInitScan();
	}

	/// <summary>
	/// This class is retriving the Name of a Package
	/// </summary>
	internal class NameScanner : AbstractScanner, IScanner
	{
		public NameScanner()
			: base() { }

		#region IScannerBase Member
		public uint Version => 1;

		public int Index => 100;
		#endregion

		#region IScanner Member
		public override bool OnTop => true;

		protected override void DoInitScan()
		{
			AbstractScanner.AddColumn(ListView, "Caption", 180);
		}

		public void ScanPackage(
			ScannerItem si,
			PackageState ps,
			System.Windows.Forms.ListViewItem lvi
		)
		{
			ps.State = TriState.False;
			si.PackageCacheItem.Name = Localization.Manager.GetString("unknown");

			Interfaces.Files.IPackedFileDescriptor[] pfds = si.Package.FindFiles(
				Data.MetaData.CTSS_FILE
			);
			if (pfds.Length == 0)
			{
				pfds = si.Package.FindFiles(Data.MetaData.STRING_FILE);
			}

			//Check for Str compatible Items
			if (pfds.Length > 0)
			{
				Str str = new Str();
				str.ProcessData(pfds[0], si.Package, false);

				StrItemList list =
					str.FallbackedLanguageItems(Helper.WindowsRegistry.LanguageCode);
				foreach (StrToken item in list)
				{
					if (item.Title.Trim() != "")
					{
						ps.State = TriState.True;
						si.PackageCacheItem.Name = item.Title;
						break;
					}
				}
			}
			else
			{
				pfds = si.Package.FindFiles(Data.MetaData.GZPS);
				if (pfds.Length == 0)
				{
					pfds = si.Package.FindFiles(0xCCA8E925); //Object XML
				}

				if (pfds.Length == 0)
				{
					pfds = si.Package.FindFiles(Data.MetaData.MMAT);
				}

				//Check for Cpf compatible Items
				if (pfds.Length > 0)
				{
					Cpf cpf =
						new Cpf();
					cpf.ProcessData(pfds[0], si.Package, false);

					si.PackageCacheItem.Name = cpf.GetSaveItem("name").StringValue;
					if (si.PackageCacheItem.Name.Trim() != "")
					{
						ps.State = TriState.True;
					}
				}
			}

			UpdateState(si, ps, lvi);
		}

		public void UpdateState(
			ScannerItem si,
			PackageState ps,
			System.Windows.Forms.ListViewItem lvi
		)
		{
			AbstractScanner.SetSubItem(lvi, this.StartColum, si.PackageCacheItem.Name);
		}

		public void FinishScan()
		{
		}

		public override bool IsActiveByDefault => true;

		#endregion

		public override string ToString()
		{
			return "Caption Scanner";
		}
	}

	/// <summary>
	/// This class is retriving the Name of a Package
	/// </summary>
	internal class ImageScanner : AbstractScanner, IScanner
	{
		public ImageScanner()
			: base() { }

		#region IScannerBase Member
		public uint Version => 1;

		public int Index => 200;
		#endregion

		#region IScanner Member
		public override bool OnTop => true;

		protected override void DoInitScan()
		{
			ListView.SmallImageList = ListView.LargeImageList;
		}

		public void ScanPackage(
			ScannerItem si,
			PackageState ps,
			System.Windows.Forms.ListViewItem lvi
		)
		{
			Size sz = AbstractScanner.ThumbnailSize;
			if (
				si.PackageCacheItem.Type == PackageType.CustomObject
				|| si.PackageCacheItem.Type == PackageType.Object
				|| si.PackageCacheItem.Type == PackageType.Recolour
			)
			{
				Interfaces.Files.IPackedFileDescriptor[] pfds =
					si.Package.FindFiles(Data.MetaData.OBJD_FILE);

				uint group = 0;
				if (pfds.Length > 0)
				{
					group = pfds[0].Group;
				}

				if (group == Data.MetaData.LOCAL_GROUP)
				{
					Interfaces.Wrapper.IGroupCacheItem gci =
						FileTable.GroupCache.GetItem(si.FileName);
					if (gci != null)
					{
						group = gci.LocalGroup;
					}
				}
				string[] modelnames = SimPe.Plugin.Scenegraph.FindModelNames(
					si.Package
				);

				foreach (string modelname in modelnames)
				{
					Image img = GetThumbnail(group, modelname);
					if (img != null)
					{
						si.PackageCacheItem.Thumbnail = img;
						ps.State = TriState.True;
						break;
					}
				}
			}

			//no Thumbnail, do we have a Image File?
			if (ps.State == TriState.Null)
			{
				Picture pic = new Picture();
				uint[] types = pic.AssignableTypes;
				foreach (uint type in types)
				{
					Interfaces.Files.IPackedFileDescriptor[] pfds =
						si.Package.FindFiles(type);
					if (pfds.Length > 0)
					{
						//get image with smallest Instance
						Interfaces.Files.IPackedFileDescriptor pfd = pfds[0];
						foreach (Interfaces.Files.IPackedFileDescriptor p in pfds)
						{
							if (p.Instance < pfd.Instance)
							{
								pfd = p;
							}
						}

						pic.ProcessData(pfd, si.Package, false);

						si.PackageCacheItem.Thumbnail = pic.Image;
						if (si.PackageCacheItem.Thumbnail != null)
						{
							si.PackageCacheItem.Thumbnail = ImageLoader.Preview(
								si.PackageCacheItem.Thumbnail,
								sz
							);
							ps.State = TriState.True;
						}

						break;
					}
				} //foreach
			}

			//no Thumbnail generated by the Game?
			if (ps.State == TriState.Null)
			{
				//load the Texture Image
				Interfaces.Files.IPackedFileDescriptor[] pfds =
					si.Package.FindFiles(Data.MetaData.TXTR);
				if (pfds.Length > 0)
				{
					GenericRcol rcol = new GenericRcol(null, false);

					//get biggest texture
					Interfaces.Files.IPackedFileDescriptor pfd = pfds[0];
					foreach (Interfaces.Files.IPackedFileDescriptor p in pfds)
					{
						if (p.Size > pfd.Size)
						{
							pfd = p;
						}
					}

					rcol.ProcessData(pfd, si.Package, false);

					ImageData id = (ImageData)rcol.Blocks[0];

					MipMap mm = id.GetLargestTexture(sz);

					if (mm.Texture != null)
					{
						si.PackageCacheItem.Thumbnail = ImageLoader.Preview(
							mm.Texture,
							sz
						);
						ps.State = TriState.True;
					}

					rcol.Dispose();
				}
			}

			UpdateState(si, ps, lvi);
		}

		public void UpdateState(
			ScannerItem si,
			PackageState ps,
			System.Windows.Forms.ListViewItem lvi
		)
		{
			//Add the Thumbnail if available
			if (si.PackageCacheItem.Thumbnail != null)
			{
				ListView.SmallImageList.Images.Add(si.PackageCacheItem.Thumbnail);
				lvi.ImageIndex = ListView.SmallImageList.Images.Count - 1;
			}
		}

		public void FinishScan()
		{
		}

		public override bool IsActiveByDefault => true;
		#endregion

		public override string ToString()
		{
			return "Thumbnail Scanner";
		}

		#region Thumbnails

		public static uint ThumbnailHash(uint group, string modelname)
		{
			string name = group.ToString() + modelname;
			return (uint)
				Hashes.ToLong(
					Hashes.Crc32.ComputeHash(Helper.ToBytes(name.Trim().ToLower()))
				);
		}

		static Packages.File thumbs = null;

		public static Image GetThumbnail(uint group, string modelname)
		{
			if (thumbs == null)
			{
				thumbs = SimPe.Packages.File.LoadFromFile(
					System.IO.Path.Combine(
						PathProvider.SimSavegameFolder,
						"Thumbnails\\ObjectThumbnails.package"
					)
				);
				thumbs.Persistent = true;
			}

			if (modelname.EndsWith("_cres", true, null))
			{
				modelname = modelname.Substring(0, modelname.Length - 5);
			};

			uint inst = ThumbnailHash(group, modelname);
			Interfaces.Files.IPackedFileDescriptor ipfd = thumbs.FindFile(
				0xAC2950C1,
				group,
				0xFFFFFFFF,
				inst
			);
			if (ipfd != null)
			{
				try
				{
					Picture pic =
						new Picture();
					pic.ProcessData(ipfd, thumbs);
					return pic.Image;
				}
				catch (Exception) { }
			}
			return null;
		}
		#endregion
	}

	/// <summary>
	/// This class is retriving the Name of a Package
	/// </summary>
	internal class GuidScanner : AbstractScanner, IScanner
	{
		static MemoryCacheFile cachefile;

		public GuidScanner()
			: base() { }

		#region IScannerBase Member
		public uint Version => 1;

		public int Index => 300;
		#endregion

		#region IScanner Member

		Hashtable list;

		protected override void DoInitScan()
		{
			if (list == null)
			{
				list = new Hashtable();
			}
			else
			{
				list.Clear();
			}

			string WaitingScreenMessage = "";
			if (WaitingScreen.Running)
			{
				WaitingScreenMessage = WaitingScreen.Message;
			}

			if (WaitingScreen.Running)
			{
				WaitingScreen.Message = "Init Cache File";
			}

			if (cachefile == null)
			{
				cachefile = MemoryCacheFile.InitCacheFile();
				cachefile.Save();
				cachefile.Dispose();
				GC.Collect();
				GC.WaitForPendingFinalizers();
				cachefile = null;
				cachefile = MemoryCacheFile.InitCacheFile();
			}

			AbstractScanner.AddColumn(ListView, "GUIDs", 180);
			AbstractScanner.AddColumn(ListView, "Duplicate GUID", 80);
			AbstractScanner.AddColumn(ListView, "First found", 80);

			if (WaitingScreen.Running)
			{
				WaitingScreen.Message = "Create hashtable";
			}

			foreach (MemoryCacheItem mci in cachefile.List)
			{
				string flname = null;
				if (mci.ParentCacheContainer == null)
				{
					flname = mci.FileDescriptor.Filename;
				}
				else
				{
					flname = mci.ParentCacheContainer.FileName;
				}

				list[(uint)mci.Guid] = flname;
				// list[(uint)mci.Guid] = flname.Trim().ToLower();
				/*if (mci.Guid == guid)
				{
					if (mci.ParentCacheContainer!=null)
					{
						if (mci.ParentCacheContainer.FileName.Trim().ToLower() != flname)
						{
							ps.State = TriState.False;
							break;
						}
					}
				}*/
			}
			if (WaitingScreen.Running)
			{
				WaitingScreen.Message = WaitingScreenMessage;
			}
		}

		public void ScanPackage(
			ScannerItem si,
			PackageState ps,
			System.Windows.Forms.ListViewItem lvi
		)
		{
			Interfaces.Files.IPackedFileDescriptor[] pfds = si.Package.FindFiles(
				Data.MetaData.OBJD_FILE
			);
			ArrayList mylist = new ArrayList();
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				ExtObjd objd = new ExtObjd();
				objd.ProcessData(pfd, si.Package, false);

				mylist.Add(objd.Guid);
				objd.Dispose();
			}

			uint[] guids = new uint[mylist.Count];
			mylist.CopyTo(guids);
			si.PackageCacheItem.Guids = guids;
			ps.State = TriState.True;

			UpdateState(si, ps, lvi);
		}

		public void UpdateState(
			ScannerItem si,
			PackageState ps,
			System.Windows.Forms.ListViewItem lvi
		)
		{
			ps.State = TriState.True;
			string guids = "";
			string ff = SimPe.Localization.Manager.GetString("unknown");
			foreach (uint guid in si.PackageCacheItem.Guids)
			{
				string flname = si.FileName;
				// string flname = si.FileName.Trim().ToLower();
				if (guids != "")
				{
					guids += ", ";
				}

				guids += "0x" + Helper.HexString(guid);

				/*foreach (MemoryCacheItem mci in cachefile.List)
				{
					if (mci.Guid == guid)
					{
						if (mci.ParentCacheContainer!=null)
						{
							if (mci.ParentCacheContainer.FileName.Trim().ToLower() != flname)
							{
								ps.State = TriState.False;
								break;
							}
						}
					}
				}*/

				string fl = si.Package.FileName;
				// string fl = si.Package.FileName.Trim().ToLower();
				if (list.ContainsKey(guid))
				{
					string cmp = (string)list[guid];
					if (cmp != fl)
					{
						ps.State = TriState.False;
						ff = cmp;
					}
					else
					{
						ps.State = TriState.True;
					}
				}
				else
				{
					list.Add(guid, fl);
				}
			}

			string text = "no";
			if (ps.State == TriState.False)
			{
				text = "yes";
			}

			AbstractScanner.SetSubItem(lvi, this.StartColum, guids);
			AbstractScanner.SetSubItem(lvi, this.StartColum + 1, text, ps);
			AbstractScanner.SetSubItem(lvi, this.StartColum + 2, ff);
		}

		public void FinishScan()
		{
		}

		public override bool IsActiveByDefault => false;
		#endregion

		public override string ToString()
		{
			return "GUID Scanner";
		}
	}

	/// <summary>
	/// This class checks if the Base CRES for the Recolor is still available
	/// </summary>
	internal class RecolorBasemeshScanner : AbstractScanner, IScanner
	{
		static MemoryCacheFile cachefile;

		public RecolorBasemeshScanner()
			: base() { }

		#region IScannerBase Member
		public uint Version => 1;

		public int Index => 900;
		#endregion

		#region IScanner Member

		protected override void DoInitScan()
		{
			if (cachefile == null)
			{
				cachefile = MemoryCacheFile.InitCacheFile();
			}

			AbstractScanner.AddColumn(ListView, "Found Base", 180);
		}

		public void ScanPackage(
			ScannerItem si,
			PackageState ps,
			System.Windows.Forms.ListViewItem lvi
		)
		{
			Interfaces.Files.IPackedFileDescriptor[] pfds = si.Package.FindFiles(
				Data.MetaData.MMAT
			);
			//ArrayList list = new ArrayList();

			ps.State = TriState.True;
			//FileTable.FileIndex.StoreCurrentState();
			if (
				!FileTable.FileIndex.ContainsPath(
					System.IO.Path.GetDirectoryName(si.FileName)
				)
			)
			{
				FileIndex.AddIndexFromFolder(
					System.IO.Path.GetDirectoryName(si.FileName)
				);
			}

			FileIndex.AddIndexFromPackage(si.Package);
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				MmatWrapper mmat = new MmatWrapper();
				mmat.ProcessData(pfd, si.Package, false);

				string m = mmat.ModelName.Trim().ToLower();
				if (!m.EndsWith("_cres"))
				{
					m += "_cres";
				}

				//Add the current package
				Interfaces.Scenegraph.IScenegraphFileIndexItem item =
					FileTable.FileIndex.FindFileByName(
						m,
						Data.MetaData.CRES,
						Data.MetaData.LOCAL_GROUP,
						true
					);

				if (item == null)
				{
					ps.State = TriState.False;
				}

				item = null;
				mmat.Dispose();
				m = null;
			}
			//FileTable.FileIndex.RestoreLastState();

			UpdateState(si, ps, lvi);
		}

		public void UpdateState(
			ScannerItem si,
			PackageState ps,
			System.Windows.Forms.ListViewItem lvi
		)
		{
			string text = "yes";
			if (ps.State == TriState.False)
			{
				text = "no";
			}

			AbstractScanner.SetSubItem(lvi, this.StartColum, text, ps);
		}

		public void FinishScan()
		{
		}

		public override bool IsActiveByDefault => false;
		#endregion

		public override string ToString()
		{
			return "Recolour-Basemesh Scanner";
		}
	}

	/// <summary>
	/// This class checks if the Base CRES for the Recolor is still available
	/// </summary>
	internal class MeshScanner : AbstractScanner, IScanner
	{
		//static SimPe.Cache.MemoryCacheFile cachefile;

		public MeshScanner()
			: base() { }

		#region IScannerBase Member
		public uint Version => 1;

		public int Index => 850;
		#endregion

		#region IScanner Member

		protected override void DoInitScan()
		{
			AbstractScanner.AddColumn(ListView, "Vertices", 60);
			AbstractScanner.AddColumn(ListView, "Faces", 60);
		}

		public void ScanPackage(
			ScannerItem si,
			PackageState ps,
			System.Windows.Forms.ListViewItem lvi
		)
		{
			Interfaces.Files.IPackedFileDescriptor[] pfds = si.Package.FindFiles(
				Data.MetaData.GMDC
			);
			//ArrayList list = new ArrayList();

			ps.State = TriState.True;

			uint fct = 0;
			uint vct = 0;
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				Rcol rcol = new GenericRcol();
				rcol.ProcessData(pfd, si.Package, true);

				GeometryDataContainer gmdc =
					rcol.Blocks[0] as GeometryDataContainer;
				foreach (Gmdc.GmdcGroup g in gmdc.Groups)
				{
					fct += (uint)g.FaceCount;
					vct += (uint)g.UsedVertexCount;
				}
				rcol.Dispose();
			}
			ps.Data = new uint[] { vct, fct };

			UpdateState(si, ps, lvi);
		}

		public void UpdateState(
			ScannerItem si,
			PackageState ps,
			System.Windows.Forms.ListViewItem lvi
		)
		{
			uint fct = ps.Data[1];
			uint vct = ps.Data[0];
			AbstractScanner.SetSubItem(lvi, this.StartColum, vct.ToString(), ps);
			AbstractScanner.SetSubItem(lvi, this.StartColum + 1, fct.ToString(), ps);
		}

		public void FinishScan()
		{
		}

		public override bool IsActiveByDefault => false;
		#endregion

		public override string ToString()
		{
			return "Mesh Scanner";
		}
	}
}
