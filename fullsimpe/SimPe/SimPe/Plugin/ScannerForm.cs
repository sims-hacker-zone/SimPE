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
using System.Windows.Forms;

using Ambertation.Windows.Forms;

using SimPe.Interfaces.Plugin.Scanner;
using SimPe.Plugin.Scanner;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for ScannerForm.
	/// </summary>
	internal class ScannerForm : Form
	{
		#region Windows Form Designer generated code
		private Button btclear;
		private System.Windows.Forms.TabPage tbcache;
		private Button button2;
		private Button button3;
		private Button btscan;
		private System.Windows.Forms.TabPage tbidentify;
		private Label label5;
		private ListBox lbid;
		private ListBox lbscandebug;
		private Label label6;
		private TextBox tbflname;
		private ComboBox lbprop;
		private LinkLabel llSave;
		private SaveFileDialog sfd;
		private CheckBox cbrec;
		private LinkLabel linkLabel1;
		private ComboBox cbfolder;
		private FolderBrowserDialog fbd;
		private ExtProgressBar pb;
		private ListView lv;
		private ColumnHeader columnHeader1;
		private ColumnHeader columnHeader2;
		private ColumnHeader columnHeader3;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tbscanners;
		private CheckedListBox lbscanners;
		private Label label1;
		private ImageList ilist;
		private PictureBox thumb;
		private GroupBox gbinfo;
		private LinkLabel llopen;
		private CheckBox cbenable;
		private Label lbname;
		private Label lbtype;
		private System.Windows.Forms.TabPage tboperations;
		private Panel pnop;
		private ToolTip toolTip1;
		private Panel panel1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components;
		#endregion

		/// <summary>
		/// Create a new Instance
		/// </summary>
		public ScannerForm()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			scanClicked = Scan;

			//hide the Identifier Tab in non Creator Mode
			if (!UserVerification.HaveUserId)
			{
				this.tabControl1.TabPages.Remove(this.tbidentify);
				this.tabControl1.TabIndex = 0;
			}

			//load the Group Cache
			WrapperFactory.LoadGroupCache();

			this.cbfolder.SelectedIndex = 0;

			cachefile = new Cache.PackageCacheFile();
			try
			{
				cachefile.Load(Cache.PackageCacheFile.CacheFileName);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("Unable to reload the Cache File.", ex);
			}

			//display the list of identifiers
			foreach (IIdentifier id in ScannerRegistry.Global.Identifiers)
			{
				lbid.Items.Add(
					id.GetType().Name
						+ " (version="
						+ id.Version.ToString()
						+ ", index="
						+ id.Index.ToString()
						+ ")"
				);
			}

			//add the scanners to the Selection and show the Scanner Controls (if available)
			AbstractScanner.UpdateList finishcallback =
				new AbstractScanner.UpdateList(this.UpdateList);
			ArrayList uids = new ArrayList();
			foreach (IScanner i in ScannerRegistry.Global.Scanners)
			{
				string name =
					i.GetType().Name
					+ " (version="
					+ i.Version.ToString()
					+ ", uid=0x"
					+ Helper.HexString(i.Uid)
					+ ", index="
					+ i.Index.ToString()
					+ ")";
				if (!uids.Contains(i.Uid))
				{
					if (!i.OnTop)
					{
						lbscanners.Items.Add(i, i.IsActiveByDefault);
					}
					else
					{
						lbscanners.Items.Insert(0, i);
						lbscanners.SetItemChecked(0, i.IsActiveByDefault);
					}
					ShowControls(i);
					i.SetFinishCallback(finishcallback);

					uids.Add(i.Uid);
				}
				else
				{
					name = "--- " + name;
				}

				this.lbscandebug.Items.Add(name);
			}

			pnop.Enabled = false;
			sorter = new ColumnSorter();
			lv.ListViewItemSorter = sorter;

			// llSave.Left = lv.Right - llSave.Width;
		}

		Cache.PackageCacheFile cachefile;
		string folder;
		string errorlog;
		bool cachechg;
		ColumnSorter sorter;
		int controltop = 0;

		public string FileName
		{
			get; private set;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// Display a control on the Panel
		/// </summary>
		/// <param name="ctrl">The control you want to show</param>
		/// <param name="indent">should the control be indented?</param>
		/// <param name="space">should we add an additional 8 Pixels to the controltop</param>
		void ShowControl(Control ctrl, bool indent, bool space)
		{
			ctrl.Parent = this.pnop;

			if (indent)
			{
				ctrl.Left = 16;
			}
			else
			{
				ctrl.Left = 0;
			}

			if (ctrl.GetType() == typeof(Panel))
			{
				ctrl.Width = pnop.Width - ctrl.Left;
				//this.visualStyleProvider1.SetVisualStyleSupport(ctrl, true);
			}

			ctrl.Top = controltop;
			controltop += ctrl.Height;
			if (space)
			{
				controltop += 8;
			}

			ctrl.Visible = true;
		}

		/// <summary>
		/// Display the Controls of a Scanner
		/// </summary>
		/// <param name="scanner"></param>
		void ShowControls(IScanner scanner)
		{
			Control ctrl = scanner.OperationControl;
			if (ctrl == null)
			{
				return;
			}

			Label lb = new Label();
			lb.AutoSize = true;
			lb.Text = scanner.ToString() + ":";
			lb.Font = new Font(Font.Name, Font.Size, FontStyle.Bold);
			lb.ForeColor = this.gbinfo.ForeColor;
			//this.visualStyleProvider1.SetVisualStyleSupport(lb, true);

			Panel pn = new Panel();
			pn.Width = pnop.Width - 20;
			pn.Height = 1;
			pn.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
			pn.BackColor = Color.FromArgb(0x77, lb.ForeColor);

			ShowControl(lb, false, false);
			ShowControl(pn, false, true);
			ShowControl(ctrl, true, true);

			controltop += 16;
		}

		/// <summary>
		/// Returns the last selected Scanner Item (can be null)
		/// </summary>
		internal ScannerItem SelectedScannerItem
		{
			get; private set;
		}

		/// <summary>
		/// Displays the Information about this Scanenr Item
		/// </summary>
		/// <param name="si"></param>
		void ShowInfo(ScannerItem si, ListViewItem lvi)
		{
			if (si == null)
			{
				return;
			}

			this.cbenable.Tag = true;
			try
			{
				this.thumb.Image = si.PackageCacheItem.Thumbnail;
				this.cbenable.Checked = si.PackageCacheItem.Enabled;
				this.lbname.Text = si.PackageCacheItem.Name;
				this.lbtype.Text = si.PackageCacheItem.Type.ToString();

				tbflname.Text = si.FileName;
				if (tbflname.Text.Length > 0)
				{
					tbflname.SelectionStart = tbflname.Text.Length - 1;
				}

				lbname.ForeColor = lvi.ForeColor;
				lbtype.ForeColor = lvi.ForeColor;

				lbprop.Items.Clear();
				if (System.IO.File.Exists(si.FileName))
				{
					string mod = " Modification Date: ";
					mod +=
						System.IO.File.GetLastWriteTime(si.FileName).ToShortDateString()
						+ " ";
					mod += System
						.IO.File.GetLastWriteTime(si.FileName)
						.ToLongTimeString();
					lbprop.Items.Add(mod);
				}
				for (int i = 3; i < lv.Columns.Count; i++)
				{
					if (lvi.SubItems[i].Text.Trim() != "")
					{
						lbprop.Items.Add(
							lv.Columns[i].Text + ": " + lvi.SubItems[i].Text
						);
					}
				}
			}
			finally
			{
				this.cbenable.Tag = null;
			}
		}

		private void Scan(string folder, bool rec, ScannerCollection usedscanners)
		{
			//scan all Files
			pb.Value = 0;
			string[] files = System.IO.Directory.GetFiles(folder, "*.package");
			string[] dfiles = System.IO.Directory.GetFiles(folder, "*.simpedis");
			string[] dofiles = System.IO.Directory.GetFiles(
				folder,
				"*.packagedisabled"
			);
			string[] tfiles = System.IO.Directory.GetFiles(folder, "*.Sims2Tmp");

			int ct = files.Length + dfiles.Length + dofiles.Length + tfiles.Length;
			Scan(files, true, 0, ct, usedscanners);
			if (!stopClicked)
			{
				Scan(dfiles, false, files.Length, ct, usedscanners);
			}

			if (!stopClicked)
			{
				Scan(dofiles, false, files.Length + dfiles.Length, ct, usedscanners);
			}

			if (!stopClicked)
			{
				Scan(
					tfiles,
					false,
					files.Length + dfiles.Length + dofiles.Length,
					ct,
					usedscanners
				);
			}

			pb.Value = 0;

			//issue a recursive Scan
			if (!stopClicked && rec)
			{
				string[] dirs = System.IO.Directory.GetDirectories(folder, "*");
				foreach (string dir in dirs)
				{
					Scan(dir, true, usedscanners);
					if (stopClicked)
					{
						break;
					}
				}
			}
		}

		/// <summary>
		/// Scan for all Files and display the Result
		/// </summary>
		/// <param name="files"></param>
		/// <param name="enabled"></param>
		/// <param name="pboffset"></param>
		/// <param name="count"></param>
		void Scan(
			string[] files,
			bool enabled,
			int pboffset,
			int count,
			ScannerCollection usedscanners
		)
		{
			int ct = pboffset;
			foreach (string file in files)
			{
				pb.Value = Math.Max(
					Math.Min(((ct++) * pb.Maximum) / count, pb.Maximum),
					pb.Minimum
				);
				Application.DoEvents();
				try
				{
					//Load the Item from the cache (if possible)
					ScannerItem si = cachefile.LoadItem(file);
					si.PackageCacheItem.Enabled = enabled;
					if (WaitingScreen.Running)
					{
						WaitingScreen.UpdateMessage(si.PackageCacheItem.Name);
					}

					//determine Type
					Cache.PackageType pt = si.PackageCacheItem.Type;
					foreach (IIdentifier id in ScannerRegistry.Global.Identifiers)
					{
						if (
							(
								si.PackageCacheItem.Type
								!= Cache.PackageType.Unknown
							)
							&& (
								si.PackageCacheItem.Type
								!= Cache.PackageType.Undefined
							)
						)
						{
							break;
						}

						if (
							(
								si.PackageCacheItem.Type
								== Cache.PackageType.Unknown
							)
							|| (
								si.PackageCacheItem.Type
								== Cache.PackageType.Undefined
							)
						)
						{
							si.PackageCacheItem.Type = id.GetType(si.Package);
						}
					}

					if (pt != si.PackageCacheItem.Type)
					{
						cachechg = true;
					}

					//setup the ListView Item
					ListViewItem lvi = new ListViewItem();
					si.ListViewItem = lvi;
					lvi.Text = System.IO.Path.GetFileNameWithoutExtension(si.FileName);
					lvi.SubItems.Add(si.PackageCacheItem.Enabled.ToString());
					lvi.SubItems.Add(si.PackageCacheItem.Type.ToString());
					lvi.Tag = si;
					if (!si.PackageCacheItem.Enabled)
					{
						lvi.ForeColor = Color.Gray;
					}

					//run file through available scanners
					foreach (IScanner s in usedscanners)
					{
						Cache.PackageState ps = si.PackageCacheItem.FindState(
							s.Uid,
							true
						);
						if (ps.State == Cache.TriState.Null)
						{
							s.ScanPackage(si, ps, lvi);
							if (ps.State != Cache.TriState.Null)
							{
								cachechg = true;
							}
						}
						else
						{
							s.UpdateState(si, ps, lvi);
						}

						if (stopClicked)
						{
							break;
						}
					}

					lv.Items.Add(lvi);

					Application.DoEvents();
					if (stopClicked)
					{
						break;
					}
				}
				catch (Exception ex)
				{
					errorlog +=
						file
						+ ": "
						+ ex.Message
						+ Helper.lbr
						+ "----------------------------------------"
						+ Helper.lbr;
				}
			} //foreach
		}

		void UpdateList(bool savecache, bool rescan)
		{
			if (Helper.WindowsRegistry.UseCache && savecache)
			{
				cachefile.Save();
			}

			if (rescan)
			{
				Scan(null, (LinkLabelLinkClickedEventArgs)null);
			}
			else
			{
				SelectItem(lv, null);
			}
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(typeof(ScannerForm));
			this.cbfolder = new ComboBox();
			this.linkLabel1 = new LinkLabel();
			this.fbd = new FolderBrowserDialog();
			this.pb = new ExtProgressBar();
			this.lv = new ListView();
			this.columnHeader1 = new ColumnHeader();
			this.columnHeader2 = new ColumnHeader();
			this.columnHeader3 = new ColumnHeader();
			this.ilist = new ImageList(this.components);
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tbscanners = new System.Windows.Forms.TabPage();
			this.lbscanners = new CheckedListBox();
			this.label1 = new Label();
			this.tboperations = new System.Windows.Forms.TabPage();
			this.pnop = new Panel();
			this.tbcache = new System.Windows.Forms.TabPage();
			this.button3 = new Button();
			this.button2 = new Button();
			this.btclear = new Button();
			this.tbidentify = new System.Windows.Forms.TabPage();
			this.lbscandebug = new ListBox();
			this.label6 = new Label();
			this.lbid = new ListBox();
			this.label5 = new Label();
			this.btscan = new Button();
			this.cbrec = new CheckBox();
			this.gbinfo = new GroupBox();
			this.lbprop = new ComboBox();
			this.llSave = new LinkLabel();
			this.tbflname = new TextBox();
			this.cbenable = new CheckBox();
			this.lbtype = new Label();
			this.lbname = new Label();
			this.llopen = new LinkLabel();
			this.thumb = new PictureBox();
			this.sfd = new SaveFileDialog();
			this.toolTip1 = new ToolTip(this.components);
			this.panel1 = new Panel();
			this.tabControl1.SuspendLayout();
			this.tbscanners.SuspendLayout();
			this.tboperations.SuspendLayout();
			this.tbcache.SuspendLayout();
			this.tbidentify.SuspendLayout();
			this.gbinfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.thumb)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			//
			// cbfolder
			//
			this.cbfolder.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			this.cbfolder.Items.AddRange(
				new object[]
				{
					"Download Folder",
					"Teleport Folder",
					"Neighbourhoods Folder",
					"Bodyshop Sim Templates Folder",
					"Browse for Folder...",
				}
			);
			this.cbfolder.Location = new Point(9, 11);
			this.cbfolder.Name = "cbfolder";
			this.cbfolder.Size = new Size(408, 21);
			this.cbfolder.TabIndex = 1;
			this.cbfolder.SelectedIndexChanged += new EventHandler(
				this.SelectFolder
			);
			//
			// linkLabel1
			//
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.BackColor = Color.Transparent;
			this.linkLabel1.Font = new Font(
				"Microsoft Sans Serif",
				11.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				((byte)(0))
			);
			this.linkLabel1.Location = new Point(423, 12);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new Size(40, 18);
			this.linkLabel1.TabIndex = 2;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "scan";
			this.linkLabel1.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(this.Scan);
			//
			// fbd
			//
			this.fbd.ShowNewFolderButton = false;
			//
			// pb
			//
			this.pb.Anchor = (
				(AnchorStyles)(
					(
						(
							AnchorStyles.Bottom
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)
				)
			);
			this.pb.BackColor = Color.Transparent;
			this.pb.Gradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.pb.Location = new Point(9, 583);
			this.pb.Maximum = 1000;
			this.pb.Minimum = 0;
			this.pb.Name = "pb";
			this.pb.Quality = true;
			this.pb.Size = new Size(943, 16);
			this.pb.TabIndex = 7;
			this.pb.TokenCount = 2;
			this.pb.UnselectedColor = Color.Black;
			this.pb.UseTokenBuffer = false;
			this.pb.Value = 0;
			//
			// lv
			//
			this.lv.Anchor = (
				(AnchorStyles)(
					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)
				)
			);
			this.lv.Columns.AddRange(
				new ColumnHeader[]
				{
					this.columnHeader1,
					this.columnHeader2,
					this.columnHeader3,
				}
			);
			this.lv.FullRowSelect = true;
			this.lv.HideSelection = false;
			this.lv.LargeImageList = this.ilist;
			this.lv.Location = new Point(9, 38);
			this.lv.Name = "lv";
			this.lv.Size = new Size(948, 223);
			this.lv.TabIndex = 3;
			this.lv.UseCompatibleStateImageBehavior = false;
			this.lv.View = View.Details;
			this.lv.SelectedIndexChanged += new EventHandler(this.SelectItem);
			this.lv.ColumnClick += new ColumnClickEventHandler(
				this.SortList
			);
			//
			// columnHeader1
			//
			this.columnHeader1.Text = "Filename";
			this.columnHeader1.Width = 281;
			//
			// columnHeader2
			//
			this.columnHeader2.Text = "Enabled";
			this.columnHeader2.Width = 57;
			//
			// columnHeader3
			//
			this.columnHeader3.Text = "Type";
			this.columnHeader3.Width = 104;
			//
			// ilist
			//
			this.ilist.ColorDepth = ColorDepth.Depth32Bit;
			this.ilist.ImageSize = new Size(48, 48);
			this.ilist.TransparentColor = Color.Transparent;
			//
			// tabControl1
			//
			this.tabControl1.Anchor = (
				(AnchorStyles)(
					(
						(
							AnchorStyles.Bottom
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)
				)
			);
			this.tabControl1.Controls.Add(this.tbscanners);
			this.tabControl1.Controls.Add(this.tboperations);
			this.tabControl1.Controls.Add(this.tbcache);
			this.tabControl1.Controls.Add(this.tbidentify);
			this.tabControl1.Location = new Point(9, 267);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new Size(481, 310);
			this.tabControl1.TabIndex = 4;
			//
			// tbscanners
			//
			this.tbscanners.Controls.Add(this.lbscanners);
			this.tbscanners.Controls.Add(this.label1);
			this.tbscanners.Location = new Point(4, 22);
			this.tbscanners.Name = "tbscanners";
			this.tbscanners.Size = new Size(473, 284);
			this.tbscanners.TabIndex = 0;
			this.tbscanners.Text = "Scanner Settings";
			//
			// lbscanners
			//
			this.lbscanners.Anchor = (
				(AnchorStyles)(
					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)
				)
			);
			this.lbscanners.CheckOnClick = true;
			this.lbscanners.HorizontalScrollbar = true;
			this.lbscanners.Location = new Point(12, 34);
			this.lbscanners.Name = "lbscanners";
			this.lbscanners.Size = new Size(450, 226);
			this.lbscanners.TabIndex = 5;
			//
			// label1
			//
			this.label1.AutoSize = true;
			this.label1.Location = new Point(9, 12);
			this.label1.Name = "label1";
			this.label1.Size = new Size(103, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "active Scanners:";
			//
			// tboperations
			//
			this.tboperations.Controls.Add(this.pnop);
			this.tboperations.Location = new Point(4, 22);
			this.tboperations.Name = "tboperations";
			this.tboperations.Size = new Size(433, 284);
			this.tboperations.TabIndex = 1;
			this.tboperations.Text = "Operations";
			//
			// pnop
			//
			this.pnop.Anchor = (
				(AnchorStyles)(
					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)
				)
			);
			this.pnop.AutoScroll = true;
			this.pnop.BackColor = SystemColors.Window;
			this.pnop.BorderStyle = BorderStyle.Fixed3D;
			this.pnop.Location = new Point(-1, 9);
			this.pnop.Name = "pnop";
			this.pnop.Size = new Size(434, 271);
			this.pnop.TabIndex = 0;
			//
			// tbcache
			//
			this.tbcache.Controls.Add(this.button3);
			this.tbcache.Controls.Add(this.button2);
			this.tbcache.Controls.Add(this.btclear);
			this.tbcache.Location = new Point(4, 22);
			this.tbcache.Name = "tbcache";
			this.tbcache.Size = new Size(433, 284);
			this.tbcache.TabIndex = 2;
			this.tbcache.Text = "Cache";
			//
			// button3
			//
			this.button3.Anchor = AnchorStyles.None;
			this.button3.FlatStyle = FlatStyle.System;
			this.button3.Location = new Point(147, 164);
			this.button3.Name = "button3";
			this.button3.Size = new Size(133, 24);
			this.button3.TabIndex = 11;
			this.button3.Text = "Reload FileTable";
			this.toolTip1.SetToolTip(
				this.button3,
				"Press this Button if you want to reload the FileTable."
			);
			this.button3.Click += new EventHandler(this.ReloadFileTable);
			//
			// button2
			//
			this.button2.Anchor = AnchorStyles.None;
			this.button2.FlatStyle = FlatStyle.System;
			this.button2.Location = new Point(147, 134);
			this.button2.Name = "button2";
			this.button2.Size = new Size(133, 24);
			this.button2.TabIndex = 10;
			this.button2.Text = "Reload Cache";
			this.toolTip1.SetToolTip(
				this.button2,
				"Press this Button if you want to reload the Cache from your HD."
			);
			this.button2.Click += new EventHandler(this.ReloadCache);
			//
			// btclear
			//
			this.btclear.Anchor = AnchorStyles.None;
			this.btclear.FlatStyle = FlatStyle.System;
			this.btclear.Location = new Point(147, 105);
			this.btclear.Name = "btclear";
			this.btclear.Size = new Size(133, 24);
			this.btclear.TabIndex = 9;
			this.btclear.Text = "Clear Cache";
			this.toolTip1.SetToolTip(
				this.btclear,
				"Press this Button if you want to clear the Scanner Cache."
			);
			this.btclear.Click += new EventHandler(this.ClearCache);
			//
			// tbidentify
			//
			this.tbidentify.Controls.Add(this.lbscandebug);
			this.tbidentify.Controls.Add(this.label6);
			this.tbidentify.Controls.Add(this.lbid);
			this.tbidentify.Controls.Add(this.label5);
			this.tbidentify.Location = new Point(4, 22);
			this.tbidentify.Name = "tbidentify";
			this.tbidentify.Size = new Size(433, 284);
			this.tbidentify.TabIndex = 3;
			this.tbidentify.Text = "Scanners";
			//
			// lbscandebug
			//
			this.lbscandebug.Anchor = (
				(AnchorStyles)(
					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)
				)
			);
			this.lbscandebug.HorizontalScrollbar = true;
			this.lbscandebug.Location = new Point(-1, 127);
			this.lbscandebug.Name = "lbscandebug";
			this.lbscandebug.Size = new Size(430, 134);
			this.lbscandebug.TabIndex = 5;
			//
			// label6
			//
			this.label6.AutoSize = true;
			this.label6.Location = new Point(-1, 110);
			this.label6.Name = "label6";
			this.label6.Size = new Size(107, 13);
			this.label6.TabIndex = 4;
			this.label6.Text = "loaded Scanners:";
			//
			// lbid
			//
			this.lbid.Anchor = (
				(AnchorStyles)(
					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)
				)
			);
			this.lbid.HorizontalScrollbar = true;
			this.lbid.Location = new Point(2, 25);
			this.lbid.Name = "lbid";
			this.lbid.Size = new Size(430, 69);
			this.lbid.TabIndex = 3;
			//
			// label5
			//
			this.label5.AutoSize = true;
			this.label5.Location = new Point(2, 8);
			this.label5.Name = "label5";
			this.label5.Size = new Size(112, 13);
			this.label5.TabIndex = 2;
			this.label5.Text = "loaded Identifiers:";
			//
			// btscan
			//
			this.btscan.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)
				)
			);
			this.btscan.BackColor = Color.Transparent;
			this.btscan.FlatStyle = FlatStyle.System;
			this.btscan.Location = new Point(506, 549);
			this.btscan.Name = "btscan";
			this.btscan.Size = new Size(80, 24);
			this.btscan.TabIndex = 6;
			this.btscan.Text = "Scan";
			this.btscan.UseVisualStyleBackColor = false;
			this.btscan.Click += new EventHandler(this.Scan);
			//
			// cbrec
			//
			this.cbrec.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)
				)
			);
			this.cbrec.AutoSize = true;
			this.cbrec.BackColor = Color.Transparent;
			this.cbrec.Location = new Point(590, 555);
			this.cbrec.Name = "cbrec";
			this.cbrec.Size = new Size(82, 17);
			this.cbrec.TabIndex = 7;
			this.cbrec.Text = "Recursive";
			this.cbrec.UseVisualStyleBackColor = false;
			//
			// gbinfo
			//
			this.gbinfo.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)
				)
			);
			this.gbinfo.BackColor = Color.Transparent;
			this.gbinfo.Controls.Add(this.lbprop);
			this.gbinfo.Controls.Add(this.llSave);
			this.gbinfo.Controls.Add(this.tbflname);
			this.gbinfo.Controls.Add(this.cbenable);
			this.gbinfo.Controls.Add(this.lbtype);
			this.gbinfo.Controls.Add(this.lbname);
			this.gbinfo.Controls.Add(this.llopen);
			this.gbinfo.Controls.Add(this.thumb);
			this.gbinfo.Location = new Point(506, 280);
			this.gbinfo.Name = "gbinfo";
			this.gbinfo.Size = new Size(451, 243);
			this.gbinfo.TabIndex = 2;
			this.gbinfo.TabStop = false;
			this.gbinfo.Text = "Information";
			//
			// lbprop
			//
			this.lbprop.DropDownStyle = ComboBoxStyle.DropDownList;
			this.lbprop.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				((byte)(0))
			);
			this.lbprop.Location = new Point(9, 190);
			this.lbprop.MaxDropDownItems = 100;
			this.lbprop.Name = "lbprop";
			this.lbprop.Size = new Size(380, 21);
			this.lbprop.Sorted = true;
			this.lbprop.TabIndex = 10;
			//
			// llSave
			//
			this.llSave.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)
				)
			);
			this.llSave.AutoSize = true;
			this.llSave.Font = new Font(
				"Microsoft Sans Serif",
				11.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				((byte)(0))
			);
			this.llSave.Location = new Point(398, 190);
			this.llSave.Name = "llSave";
			this.llSave.Size = new Size(51, 18);
			this.llSave.TabIndex = 8;
			this.llSave.TabStop = true;
			this.llSave.Text = "save...";
			this.llSave.Enabled = false;
			this.llSave.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					this.llSave_LinkClicked
				);
			//
			// tbflname
			//
			this.tbflname.Location = new Point(9, 217);
			this.tbflname.Name = "tbflname";
			this.tbflname.ReadOnly = true;
			this.tbflname.Size = new Size(387, 21);
			this.tbflname.TabIndex = 9;
			//
			// cbenable
			//
			this.cbenable.AutoSize = true;
			this.cbenable.Location = new Point(146, 9);
			this.cbenable.Name = "cbenable";
			this.cbenable.Size = new Size(71, 17);
			this.cbenable.TabIndex = 7;
			this.cbenable.Text = "Enabled";
			this.cbenable.CheckedChanged += new EventHandler(
				this.SetEnabledState
			);
			//
			// lbtype
			//
			this.lbtype.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Italic,
				GraphicsUnit.Point,
				((byte)(0))
			);
			this.lbtype.Location = new Point(143, 45);
			this.lbtype.Name = "lbtype";
			this.lbtype.Size = new Size(225, 20);
			this.lbtype.TabIndex = 8;
			this.lbtype.Text = "Type";
			//
			// lbname
			//
			this.lbname.Font = new Font(
				"Verdana",
				8.25F,
				(
					(FontStyle)(
						(
							FontStyle.Bold
							| FontStyle.Italic
						)
					)
				),
				GraphicsUnit.Point,
				((byte)(0))
			);
			this.lbname.Location = new Point(143, 65);
			this.lbname.Name = "lbname";
			this.lbname.Size = new Size(225, 88);
			this.lbname.TabIndex = 7;
			this.lbname.Text = "Caption";
			//
			// llopen
			//
			this.llopen.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)
				)
			);
			this.llopen.AutoSize = true;
			this.llopen.Font = new Font(
				"Microsoft Sans Serif",
				11.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				((byte)(0))
			);
			this.llopen.Location = new Point(402, 221);
			this.llopen.Name = "llopen";
			this.llopen.Size = new Size(41, 18);
			this.llopen.TabIndex = 8;
			this.llopen.TabStop = true;
			this.llopen.Text = "open";
			this.llopen.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					this.OpenPackage
				);
			//
			// thumb
			//
			this.thumb.BackColor = Color.Transparent;
			this.thumb.BorderStyle = BorderStyle.FixedSingle;
			this.thumb.Location = new Point(9, 25);
			this.thumb.Name = "thumb";
			this.thumb.Size = new Size(128, 128);
			this.thumb.SizeMode = PictureBoxSizeMode.Zoom;
			this.thumb.TabIndex = 0;
			this.thumb.TabStop = false;
			//
			// sfd
			//
			this.sfd.Filter =
				"Comma Seperated Values (*.csv)|*.csv|All Files (*.*)|*.*";
			//
			// panel1
			//
			this.panel1.BackColor = Color.Transparent;
			this.panel1.Controls.Add(this.btscan);
			this.panel1.Controls.Add(this.cbrec);
			this.panel1.Controls.Add(this.tabControl1);
			this.panel1.Controls.Add(this.lv);
			this.panel1.Controls.Add(this.pb);
			this.panel1.Controls.Add(this.cbfolder);
			this.panel1.Controls.Add(this.linkLabel1);
			this.panel1.Controls.Add(this.gbinfo);
			this.panel1.Dock = DockStyle.Fill;
			this.panel1.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				((byte)(0))
			);
			this.panel1.Location = new Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(964, 602);
			this.panel1.TabIndex = 8;
			//
			// ScannerForm
			//
			this.AutoScaleBaseSize = new Size(5, 13);
			this.ClientSize = new Size(964, 602);
			this.Controls.Add(this.panel1);
			this.Icon = ((Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ScannerForm";
			this.StartPosition = FormStartPosition.CenterParent;
			this.Text = "Folder Scanner";
			this.tabControl1.ResumeLayout(false);
			this.tbscanners.ResumeLayout(false);
			this.tbscanners.PerformLayout();
			this.tboperations.ResumeLayout(false);
			this.tbcache.ResumeLayout(false);
			this.tbidentify.ResumeLayout(false);
			this.tbidentify.PerformLayout();
			this.gbinfo.ResumeLayout(false);
			this.gbinfo.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.thumb)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
		}
		#endregion

		private void SelectFolder(object sender, EventArgs e)
		{
			if (cbfolder.SelectedIndex == 0)
			{
				folder = System.IO.Path.Combine(
					PathProvider.SimSavegameFolder,
					"Downloads"
				);
			}
			else if (cbfolder.SelectedIndex == 1)
			{
				folder = System.IO.Path.Combine(
					PathProvider.SimSavegameFolder,
					"Teleport"
				);
			}
			else if (cbfolder.SelectedIndex == 2)
			{
				folder = System.IO.Path.Combine(
					PathProvider.SimSavegameFolder,
					"Neighborhoods"
				);
				cbrec.Checked = true;
			}
			else if (cbfolder.SelectedIndex == 3)
			{
				folder = System.IO.Path.Combine(
					PathProvider.SimSavegameFolder,
					"SavedSims"
				);
			}
			else
			{
				if (fbd.SelectedPath == "")
				{
					fbd.SelectedPath = PathProvider.SimSavegameFolder;
				}

				if (fbd.ShowDialog() == DialogResult.OK)
				{
					folder = fbd.SelectedPath;
				}
			}
		}

		bool stopClicked = false;

		private void Scan(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			errorlog = "";
			cachechg = false;
			lv.Items.Clear();
			lv.Columns.Clear();
			ilist.Images.Clear();

			lv.BeginUpdate();
			WaitingScreen.Wait();
			WaitingScreen.Message = "";
			stopClicked = false;
			try
			{
				btscan.Enabled = false;
				if (Helper.WindowsRegistry.UseCache)
				{
					cachefile.LoadFiles();
				}

				//Setup ListView
				lv.SmallImageList = null;
				lv.Refresh();
				AbstractScanner.AddColumn(lv, "Filename", 180);
				AbstractScanner.AddColumn(lv, "Enabled", 60);
				AbstractScanner.AddColumn(lv, "Type", 80);

				//Select only checked Scanners
				ScannerCollection scanners = new ScannerCollection();
				for (int i = 0; i < lbscanners.Items.Count; i++)
				{
					IScanner scanner = (IScanner)lbscanners.Items[i];
					if (lbscanners.GetItemChecked(i))
					{
						scanners.Add(scanner);
						scanner.EnableControl(true);
					}
					else
					{
						scanner.EnableControl(false);
					}
				}

				AbstractScanner.AssignFileTable();
				//setup Scanners
				foreach (IScanner s in scanners)
				{
					WaitingScreen.Message = s.GetType().Name;
					s.InitScan(this.lv);
				}

				btscan.Text = "Stop";
				scanClicked = StopScan;
				btscan.Enabled = true;
				WaitingScreen.Stop();
				Cursor.Current = Cursors.AppStarting;

				//scan all Files
				Scan(folder, cbrec.Checked, scanners);

				Cursor.Current = Cursors.Default;
				WaitingScreen.Wait();
				WaitingScreen.Message = "Finishing scan";

				//finish Scanners
				foreach (IScanner s in scanners)
				{
					s.FinishScan();
				}

				AbstractScanner.DeAssignFileTable();

				try
				{
					if (Helper.WindowsRegistry.UseCache && cachechg)
					{
						cachefile.Save();
					}
				}
				catch (Exception ex)
				{
					Helper.ExceptionMessage("", ex);
				}
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(ex);
			}
			finally
			{
				btscan.Text = "Scan";
				scanClicked = Scan;
				btscan.Enabled = true;
				llSave.Enabled = true;
				WaitingScreen.UpdateImage(null);
				WaitingScreen.Stop();
				WaitingScreen.Message = "";
				lv.EndUpdate();
			}

			if (errorlog.Trim() != "")
			{
				Helper.ExceptionMessage(
					new Warning("Unreadable Files were found", errorlog)
				);
			}
		}

		private void StopScan(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			btscan.Enabled = false;
			stopClicked = true;
		}

		private void SelectItem(object sender, EventArgs e)
		{
			try
			{
				SelectedScannerItem = null;
				gbinfo.Enabled = (lv.SelectedItems.Count != 0);
				pnop.Enabled = (lv.SelectedItems.Count != 0);

				if (lv.SelectedItems.Count == 0)
				{
					return;
				}

				ScannerItem si = (ScannerItem)lv.SelectedItems[0].Tag;
				ShowInfo(si, lv.SelectedItems[0]);
				SelectedScannerItem = si;

				int encount = 0;

				//do something for all selected Items
				ScannerItem[] items = new ScannerItem[lv.SelectedItems.Count];
				int ct = 0;
				foreach (ListViewItem lvi in lv.SelectedItems)
				{
					si = (ScannerItem)lvi.Tag;
					items[ct++] = si;
					if (si.PackageCacheItem.Enabled)
					{
						encount++;
					}
				}

				if (encount == lv.SelectedItems.Count)
				{
					this.cbenable.CheckState = CheckState.Checked;
				}
				else if (encount == 0)
				{
					this.cbenable.CheckState = CheckState.Unchecked;
				}
				else
				{
					this.cbenable.CheckState = CheckState.Indeterminate;
				}

				//Enable the Scanner Controls
				foreach (IScanner scanner in this.lbscanners.Items)
				{
					scanner.EnableControl(
						items,
						ScannerRegistry.Global.Scanners.Contains(scanner)
					);
				} //foreach
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}

		private void SortList(
			object sender,
			ColumnClickEventArgs e
		)
		{
			if (sorter.CurrentColumn == e.Column)
			{
				if (lv.Sorting == SortOrder.Ascending)
				{
					lv.Sorting = SortOrder.Descending;
				}
				else
				{
					lv.Sorting = SortOrder.Ascending;
				}
			}
			else
			{
				sorter.CurrentColumn = e.Column;
				lv.ListViewItemSorter = sorter;
			}
			sorter.Sorting = lv.Sorting;
			lv.Sort();
		}

		delegate void ScanClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		);
		ScanClicked scanClicked;

		private void Scan(object sender, EventArgs e)
		{
			scanClicked(null, null);
		}

		private void ReloadFileTable(object sender, EventArgs e)
		{
			FileTableBase.FileIndex.ForceReload();
		}

		private void ReloadCache(object sender, EventArgs e)
		{
			if (Helper.WindowsRegistry.UseCache)
			{
				cachefile.Load(Cache.PackageCacheFile.CacheFileName);
			}
		}

		private void SetEnabledState(object sender, EventArgs e)
		{
			if (this.cbenable.Tag != null)
			{
				return;
			}

			if (this.cbenable.CheckState == CheckState.Indeterminate)
			{
				return;
			}

			WaitingScreen.Wait();
			try
			{
				string ext = ".package";
				if (!this.cbenable.Checked)
				{
					ext = ".packagedisabled";
				}

				WaitingScreen.UpdateMessage("Disable/Enable Packges");
				int ct = 0;
				foreach (ListViewItem lvi in lv.SelectedItems)
				{
					pb.Value = ((ct++) * pb.Maximum) / lv.SelectedItems.Count;
					ScannerItem si = (ScannerItem)lvi.Tag;

					string newname = System.IO.Path.Combine(
						System.IO.Path.GetDirectoryName(si.FileName),
						System.IO.Path.GetFileNameWithoutExtension(si.FileName) + ext
					);
					string orgname = si.FileName;

					// string newname = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(si.FileName), System.IO.Path.GetFileNameWithoutExtension(si.FileName) + ext).Trim().ToLower();
					// string orgname = si.FileName.Trim().ToLower();
					//si.Package.Save(newname);
					//remove the old file if the name was changed names
					if (!System.IO.File.Exists(newname))
					{
						Packages.StreamItem stri =
							Packages.StreamFactory.UseStream(
								orgname,
								System.IO.FileAccess.Read
							);
						stri.Close();
						Packages.StreamItem strit =
							Packages.StreamFactory.UseStream(
								newname,
								System.IO.FileAccess.Read
							);
						strit.Close();
						System.IO.File.Move(orgname, newname);

						si.FileName = newname;
						si.PackageCacheItem.Enabled = cbenable.Checked;
						si.ParentContainer.FileName = newname;
						si.ParentContainer.Added = DateTime.Now;
					}

					Application.DoEvents();
				}

				try
				{
					WaitingScreen.UpdateMessage("Writing Cache");
					if (Helper.WindowsRegistry.UseCache)
					{
						cachefile.Save();
					}
				}
				catch (Exception ex)
				{
					Helper.ExceptionMessage("", ex);
				}
			}
			finally
			{
				WaitingScreen.Stop();
				pb.Value = 0;
			}
		}

		private void ClearCache(object sender, EventArgs e)
		{
			DialogResult dr = DialogResult.Yes;

			dr = MessageBox.Show(
				"Do you really want to clear the Cache?",
				"Confirm",
				MessageBoxButtons.YesNo
			);

			if (dr == DialogResult.Yes)
			{
				try
				{
					System.IO.File.Delete(Cache.PackageCacheFile.CacheFileName);
					cachefile.Load(Cache.PackageCacheFile.CacheFileName);
				}
				catch (Exception ex)
				{
					Helper.ExceptionMessage("", ex);
				}
			}
		}

		private void OpenPackage(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (SelectedScannerItem == null)
			{
				return;
			}

			this.FileName = SelectedScannerItem.FileName;
			Close();
		}

		private void llSave_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				try
				{
					System.IO.StreamWriter sw = System.IO.File.CreateText(sfd.FileName);
					try
					{
						foreach (ColumnHeader ch in lv.Columns)
						{
							sw.Write(ch.Text.Replace(",", ";") + ",");
						}

						sw.WriteLine();

						foreach (ListViewItem lvi in lv.Items)
						{
							//sw.Write(lvi.Text.Replace(",", ";")+",");
							foreach (ListViewItem.ListViewSubItem lvsi in lvi.SubItems)
							{
								sw.Write(lvsi.Text.Replace(",", ";") + ",");
							}

							sw.WriteLine();
						}
					}
					finally
					{
						sw.Close();
						sw.Dispose();
						sw = null;
					}
				}
				catch (Exception ex)
				{
					Helper.ExceptionMessage(ex);
				}
			}
		}
	}
}
