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
				tabControl1.TabPages.Remove(tbidentify);
				tabControl1.TabIndex = 0;
			}

			//load the Group Cache
			WrapperFactory.LoadGroupCache();

			cbfolder.SelectedIndex = 0;

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
				new AbstractScanner.UpdateList(UpdateList);
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

				lbscandebug.Items.Add(name);
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
				components?.Dispose();
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
			ctrl.Parent = pnop;

			ctrl.Left = indent ? 16 : 0;

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

			Label lb = new Label
			{
				AutoSize = true,
				Text = scanner.ToString() + ":",
				Font = new Font(Font.Name, Font.Size, FontStyle.Bold),
				ForeColor = gbinfo.ForeColor
			};
			//this.visualStyleProvider1.SetVisualStyleSupport(lb, true);

			Panel pn = new Panel
			{
				Width = pnop.Width - 20,
				Height = 1,
				Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right,
				BackColor = Color.FromArgb(0x77, lb.ForeColor)
			};

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

			cbenable.Tag = true;
			try
			{
				thumb.Image = si.PackageCacheItem.Thumbnail;
				cbenable.Checked = si.PackageCacheItem.Enabled;
				lbname.Text = si.PackageCacheItem.Name;
				lbtype.Text = si.PackageCacheItem.Type.ToString();

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
				cbenable.Tag = null;
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
				Scan(null, null);
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
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(typeof(ScannerForm));
			cbfolder = new ComboBox();
			linkLabel1 = new LinkLabel();
			fbd = new FolderBrowserDialog();
			pb = new ExtProgressBar();
			lv = new ListView();
			columnHeader1 = new ColumnHeader();
			columnHeader2 = new ColumnHeader();
			columnHeader3 = new ColumnHeader();
			ilist = new ImageList(components);
			tabControl1 = new System.Windows.Forms.TabControl();
			tbscanners = new System.Windows.Forms.TabPage();
			lbscanners = new CheckedListBox();
			label1 = new Label();
			tboperations = new System.Windows.Forms.TabPage();
			pnop = new Panel();
			tbcache = new System.Windows.Forms.TabPage();
			button3 = new Button();
			button2 = new Button();
			btclear = new Button();
			tbidentify = new System.Windows.Forms.TabPage();
			lbscandebug = new ListBox();
			label6 = new Label();
			lbid = new ListBox();
			label5 = new Label();
			btscan = new Button();
			cbrec = new CheckBox();
			gbinfo = new GroupBox();
			lbprop = new ComboBox();
			llSave = new LinkLabel();
			tbflname = new TextBox();
			cbenable = new CheckBox();
			lbtype = new Label();
			lbname = new Label();
			llopen = new LinkLabel();
			thumb = new PictureBox();
			sfd = new SaveFileDialog();
			toolTip1 = new ToolTip(components);
			panel1 = new Panel();
			tabControl1.SuspendLayout();
			tbscanners.SuspendLayout();
			tboperations.SuspendLayout();
			tbcache.SuspendLayout();
			tbidentify.SuspendLayout();
			gbinfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(thumb)).BeginInit();
			panel1.SuspendLayout();
			SuspendLayout();
			//
			// cbfolder
			//
			cbfolder.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbfolder.Items.AddRange(
				new object[]
				{
					"Download Folder",
					"Teleport Folder",
					"Neighbourhoods Folder",
					"Bodyshop Sim Templates Folder",
					"Browse for Folder...",
				}
			);
			cbfolder.Location = new Point(9, 11);
			cbfolder.Name = "cbfolder";
			cbfolder.Size = new Size(408, 21);
			cbfolder.TabIndex = 1;
			cbfolder.SelectedIndexChanged += new EventHandler(
				SelectFolder
			);
			//
			// linkLabel1
			//
			linkLabel1.AutoSize = true;
			linkLabel1.BackColor = Color.Transparent;
			linkLabel1.Font = new Font(
				"Microsoft Sans Serif",
				11.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			linkLabel1.Location = new Point(423, 12);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new Size(40, 18);
			linkLabel1.TabIndex = 2;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "scan";
			linkLabel1.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(Scan);
			//
			// fbd
			//
			fbd.ShowNewFolderButton = false;
			//
			// pb
			//
			pb.Anchor =

					(
						(
							AnchorStyles.Bottom
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			pb.BackColor = Color.Transparent;
			pb.Gradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			pb.Location = new Point(9, 583);
			pb.Maximum = 1000;
			pb.Minimum = 0;
			pb.Name = "pb";
			pb.Quality = true;
			pb.Size = new Size(943, 16);
			pb.TabIndex = 7;
			pb.TokenCount = 2;
			pb.UnselectedColor = Color.Black;
			pb.UseTokenBuffer = false;
			pb.Value = 0;
			//
			// lv
			//
			lv.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			lv.Columns.AddRange(
				new ColumnHeader[]
				{
					columnHeader1,
					columnHeader2,
					columnHeader3,
				}
			);
			lv.FullRowSelect = true;
			lv.HideSelection = false;
			lv.LargeImageList = ilist;
			lv.Location = new Point(9, 38);
			lv.Name = "lv";
			lv.Size = new Size(948, 223);
			lv.TabIndex = 3;
			lv.UseCompatibleStateImageBehavior = false;
			lv.View = View.Details;
			lv.SelectedIndexChanged += new EventHandler(SelectItem);
			lv.ColumnClick += new ColumnClickEventHandler(
				SortList
			);
			//
			// columnHeader1
			//
			columnHeader1.Text = "Filename";
			columnHeader1.Width = 281;
			//
			// columnHeader2
			//
			columnHeader2.Text = "Enabled";
			columnHeader2.Width = 57;
			//
			// columnHeader3
			//
			columnHeader3.Text = "Type";
			columnHeader3.Width = 104;
			//
			// ilist
			//
			ilist.ColorDepth = ColorDepth.Depth32Bit;
			ilist.ImageSize = new Size(48, 48);
			ilist.TransparentColor = Color.Transparent;
			//
			// tabControl1
			//
			tabControl1.Anchor =

					(
						(
							AnchorStyles.Bottom
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			tabControl1.Controls.Add(tbscanners);
			tabControl1.Controls.Add(tboperations);
			tabControl1.Controls.Add(tbcache);
			tabControl1.Controls.Add(tbidentify);
			tabControl1.Location = new Point(9, 267);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new Size(481, 310);
			tabControl1.TabIndex = 4;
			//
			// tbscanners
			//
			tbscanners.Controls.Add(lbscanners);
			tbscanners.Controls.Add(label1);
			tbscanners.Location = new Point(4, 22);
			tbscanners.Name = "tbscanners";
			tbscanners.Size = new Size(473, 284);
			tbscanners.TabIndex = 0;
			tbscanners.Text = "Scanner Settings";
			//
			// lbscanners
			//
			lbscanners.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			lbscanners.CheckOnClick = true;
			lbscanners.HorizontalScrollbar = true;
			lbscanners.Location = new Point(12, 34);
			lbscanners.Name = "lbscanners";
			lbscanners.Size = new Size(450, 226);
			lbscanners.TabIndex = 5;
			//
			// label1
			//
			label1.AutoSize = true;
			label1.Location = new Point(9, 12);
			label1.Name = "label1";
			label1.Size = new Size(103, 13);
			label1.TabIndex = 1;
			label1.Text = "active Scanners:";
			//
			// tboperations
			//
			tboperations.Controls.Add(pnop);
			tboperations.Location = new Point(4, 22);
			tboperations.Name = "tboperations";
			tboperations.Size = new Size(433, 284);
			tboperations.TabIndex = 1;
			tboperations.Text = "Operations";
			//
			// pnop
			//
			pnop.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			pnop.AutoScroll = true;
			pnop.BackColor = SystemColors.Window;
			pnop.BorderStyle = BorderStyle.Fixed3D;
			pnop.Location = new Point(-1, 9);
			pnop.Name = "pnop";
			pnop.Size = new Size(434, 271);
			pnop.TabIndex = 0;
			//
			// tbcache
			//
			tbcache.Controls.Add(button3);
			tbcache.Controls.Add(button2);
			tbcache.Controls.Add(btclear);
			tbcache.Location = new Point(4, 22);
			tbcache.Name = "tbcache";
			tbcache.Size = new Size(433, 284);
			tbcache.TabIndex = 2;
			tbcache.Text = "Cache";
			//
			// button3
			//
			button3.Anchor = AnchorStyles.None;
			button3.FlatStyle = FlatStyle.System;
			button3.Location = new Point(147, 164);
			button3.Name = "button3";
			button3.Size = new Size(133, 24);
			button3.TabIndex = 11;
			button3.Text = "Reload FileTable";
			toolTip1.SetToolTip(
				button3,
				"Press this Button if you want to reload the FileTable."
			);
			button3.Click += new EventHandler(ReloadFileTable);
			//
			// button2
			//
			button2.Anchor = AnchorStyles.None;
			button2.FlatStyle = FlatStyle.System;
			button2.Location = new Point(147, 134);
			button2.Name = "button2";
			button2.Size = new Size(133, 24);
			button2.TabIndex = 10;
			button2.Text = "Reload Cache";
			toolTip1.SetToolTip(
				button2,
				"Press this Button if you want to reload the Cache from your HD."
			);
			button2.Click += new EventHandler(ReloadCache);
			//
			// btclear
			//
			btclear.Anchor = AnchorStyles.None;
			btclear.FlatStyle = FlatStyle.System;
			btclear.Location = new Point(147, 105);
			btclear.Name = "btclear";
			btclear.Size = new Size(133, 24);
			btclear.TabIndex = 9;
			btclear.Text = "Clear Cache";
			toolTip1.SetToolTip(
				btclear,
				"Press this Button if you want to clear the Scanner Cache."
			);
			btclear.Click += new EventHandler(ClearCache);
			//
			// tbidentify
			//
			tbidentify.Controls.Add(lbscandebug);
			tbidentify.Controls.Add(label6);
			tbidentify.Controls.Add(lbid);
			tbidentify.Controls.Add(label5);
			tbidentify.Location = new Point(4, 22);
			tbidentify.Name = "tbidentify";
			tbidentify.Size = new Size(433, 284);
			tbidentify.TabIndex = 3;
			tbidentify.Text = "Scanners";
			//
			// lbscandebug
			//
			lbscandebug.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			lbscandebug.HorizontalScrollbar = true;
			lbscandebug.Location = new Point(-1, 127);
			lbscandebug.Name = "lbscandebug";
			lbscandebug.Size = new Size(430, 134);
			lbscandebug.TabIndex = 5;
			//
			// label6
			//
			label6.AutoSize = true;
			label6.Location = new Point(-1, 110);
			label6.Name = "label6";
			label6.Size = new Size(107, 13);
			label6.TabIndex = 4;
			label6.Text = "loaded Scanners:";
			//
			// lbid
			//
			lbid.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			lbid.HorizontalScrollbar = true;
			lbid.Location = new Point(2, 25);
			lbid.Name = "lbid";
			lbid.Size = new Size(430, 69);
			lbid.TabIndex = 3;
			//
			// label5
			//
			label5.AutoSize = true;
			label5.Location = new Point(2, 8);
			label5.Name = "label5";
			label5.Size = new Size(112, 13);
			label5.TabIndex = 2;
			label5.Text = "loaded Identifiers:";
			//
			// btscan
			//
			btscan.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)

			;
			btscan.BackColor = Color.Transparent;
			btscan.FlatStyle = FlatStyle.System;
			btscan.Location = new Point(506, 549);
			btscan.Name = "btscan";
			btscan.Size = new Size(80, 24);
			btscan.TabIndex = 6;
			btscan.Text = "Scan";
			btscan.UseVisualStyleBackColor = false;
			btscan.Click += new EventHandler(Scan);
			//
			// cbrec
			//
			cbrec.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)

			;
			cbrec.AutoSize = true;
			cbrec.BackColor = Color.Transparent;
			cbrec.Location = new Point(590, 555);
			cbrec.Name = "cbrec";
			cbrec.Size = new Size(82, 17);
			cbrec.TabIndex = 7;
			cbrec.Text = "Recursive";
			cbrec.UseVisualStyleBackColor = false;
			//
			// gbinfo
			//
			gbinfo.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)

			;
			gbinfo.BackColor = Color.Transparent;
			gbinfo.Controls.Add(lbprop);
			gbinfo.Controls.Add(llSave);
			gbinfo.Controls.Add(tbflname);
			gbinfo.Controls.Add(cbenable);
			gbinfo.Controls.Add(lbtype);
			gbinfo.Controls.Add(lbname);
			gbinfo.Controls.Add(llopen);
			gbinfo.Controls.Add(thumb);
			gbinfo.Location = new Point(506, 280);
			gbinfo.Name = "gbinfo";
			gbinfo.Size = new Size(451, 243);
			gbinfo.TabIndex = 2;
			gbinfo.TabStop = false;
			gbinfo.Text = "Information";
			//
			// lbprop
			//
			lbprop.DropDownStyle = ComboBoxStyle.DropDownList;
			lbprop.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			lbprop.Location = new Point(9, 190);
			lbprop.MaxDropDownItems = 100;
			lbprop.Name = "lbprop";
			lbprop.Size = new Size(380, 21);
			lbprop.Sorted = true;
			lbprop.TabIndex = 10;
			//
			// llSave
			//
			llSave.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)

			;
			llSave.AutoSize = true;
			llSave.Font = new Font(
				"Microsoft Sans Serif",
				11.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			llSave.Location = new Point(398, 190);
			llSave.Name = "llSave";
			llSave.Size = new Size(51, 18);
			llSave.TabIndex = 8;
			llSave.TabStop = true;
			llSave.Text = "save...";
			llSave.Enabled = false;
			llSave.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					llSave_LinkClicked
				);
			//
			// tbflname
			//
			tbflname.Location = new Point(9, 217);
			tbflname.Name = "tbflname";
			tbflname.ReadOnly = true;
			tbflname.Size = new Size(387, 21);
			tbflname.TabIndex = 9;
			//
			// cbenable
			//
			cbenable.AutoSize = true;
			cbenable.Location = new Point(146, 9);
			cbenable.Name = "cbenable";
			cbenable.Size = new Size(71, 17);
			cbenable.TabIndex = 7;
			cbenable.Text = "Enabled";
			cbenable.CheckedChanged += new EventHandler(
				SetEnabledState
			);
			//
			// lbtype
			//
			lbtype.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Italic,
				GraphicsUnit.Point,
				0
			);
			lbtype.Location = new Point(143, 45);
			lbtype.Name = "lbtype";
			lbtype.Size = new Size(225, 20);
			lbtype.TabIndex = 8;
			lbtype.Text = "Type";
			//
			// lbname
			//
			lbname.Font = new Font(
				"Verdana",
				8.25F,


						(
							FontStyle.Bold
							| FontStyle.Italic
						)

				,
				GraphicsUnit.Point,
				0
			);
			lbname.Location = new Point(143, 65);
			lbname.Name = "lbname";
			lbname.Size = new Size(225, 88);
			lbname.TabIndex = 7;
			lbname.Text = "Caption";
			//
			// llopen
			//
			llopen.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			llopen.AutoSize = true;
			llopen.Font = new Font(
				"Microsoft Sans Serif",
				11.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			llopen.Location = new Point(402, 221);
			llopen.Name = "llopen";
			llopen.Size = new Size(41, 18);
			llopen.TabIndex = 8;
			llopen.TabStop = true;
			llopen.Text = "open";
			llopen.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					OpenPackage
				);
			//
			// thumb
			//
			thumb.BackColor = Color.Transparent;
			thumb.BorderStyle = BorderStyle.FixedSingle;
			thumb.Location = new Point(9, 25);
			thumb.Name = "thumb";
			thumb.Size = new Size(128, 128);
			thumb.SizeMode = PictureBoxSizeMode.Zoom;
			thumb.TabIndex = 0;
			thumb.TabStop = false;
			//
			// sfd
			//
			sfd.Filter =
				"Comma Seperated Values (*.csv)|*.csv|All Files (*.*)|*.*";
			//
			// panel1
			//
			panel1.BackColor = Color.Transparent;
			panel1.Controls.Add(btscan);
			panel1.Controls.Add(cbrec);
			panel1.Controls.Add(tabControl1);
			panel1.Controls.Add(lv);
			panel1.Controls.Add(pb);
			panel1.Controls.Add(cbfolder);
			panel1.Controls.Add(linkLabel1);
			panel1.Controls.Add(gbinfo);
			panel1.Dock = DockStyle.Fill;
			panel1.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			panel1.Location = new Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new Size(964, 602);
			panel1.TabIndex = 8;
			//
			// ScannerForm
			//
			AutoScaleBaseSize = new Size(5, 13);
			ClientSize = new Size(964, 602);
			Controls.Add(panel1);
			Icon = ((Icon)(resources.GetObject("$this.Icon")));
			Name = "ScannerForm";
			StartPosition = FormStartPosition.CenterParent;
			Text = "Folder Scanner";
			tabControl1.ResumeLayout(false);
			tbscanners.ResumeLayout(false);
			tbscanners.PerformLayout();
			tboperations.ResumeLayout(false);
			tbcache.ResumeLayout(false);
			tbidentify.ResumeLayout(false);
			tbidentify.PerformLayout();
			gbinfo.ResumeLayout(false);
			gbinfo.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(thumb)).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
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
					s.InitScan(lv);
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

				cbenable.CheckState = encount == lv.SelectedItems.Count ? CheckState.Checked : encount == 0 ? CheckState.Unchecked : CheckState.Indeterminate;

				//Enable the Scanner Controls
				foreach (IScanner scanner in lbscanners.Items)
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
				lv.Sorting = lv.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
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
			if (cbenable.Tag != null)
			{
				return;
			}

			if (cbenable.CheckState == CheckState.Indeterminate)
			{
				return;
			}

			WaitingScreen.Wait();
			try
			{
				string ext = ".package";
				if (!cbenable.Checked)
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

			FileName = SelectedScannerItem.FileName;
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
