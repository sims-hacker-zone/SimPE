// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimPe
{
	public enum CheckItemState
	{
		Unknown,
		Ok,
		Fail,
		Warning,
	}

	/// <summary>
	/// Summary description for CheckControl.
	/// </summary>
	public class CheckControl : UserControl
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CheckControl()
		{
			SetStyle(
				ControlStyles.SupportsTransparentBackColor
					| ControlStyles.AllPaintingInWmPaint
					| ControlStyles.UserPaint
					| ControlStyles.ResizeRedraw
					| ControlStyles.DoubleBuffer,
				true
			);
			// Required designer variable.
			InitializeComponent();
			/*
			try
			{

			}
			catch {}*/
		}

		static Image LoadFromResource(string name)
		{
			switch (name)
			{
				case "fail":
					return GetIcon.Fail;
				case "ok":
					return GetIcon.OK;
				case "warn":
					return GetIcon.Warn;
				default:
					return GetIcon.Unk;
			}
		}

		static Image iok,
			ifail,
			iunk,
			iwarn;
		private Panel panel1;
		private Button button1;
		private CheckItem chkCache;
		private CheckItem chkFileTable;
		private CheckItem chkSimFolder;
		private Panel panel2;
		private Panel panel3;
		private Panel panel4;

		public static Image OKImage
		{
			get
			{
				if (iok == null)
				{
					iok = LoadFromResource("ok");
				}

				return iok;
			}
		}
		public static Image FailImage
		{
			get
			{
				if (ifail == null)
				{
					ifail = LoadFromResource("fail");
				}

				return ifail;
			}
		}
		public static Image UnknownImage
		{
			get
			{
				if (iunk == null)
				{
					iunk = LoadFromResource("unk");
				}

				return iunk;
			}
		}
		public static Image WarnImage
		{
			get
			{
				if (iwarn == null)
				{
					iwarn = LoadFromResource("warn");
				}

				return iwarn;
			}
		}
		public static bool CaCleared { get; set; } = false;

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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources =
				new System.Resources.ResourceManager(typeof(CheckControl));
			chkSimFolder = new CheckItem();
			chkCache = new CheckItem();
			chkFileTable = new CheckItem();
			panel1 = new Panel();
			button1 = new Button();
			panel2 = new Panel();
			panel3 = new Panel();
			panel4 = new Panel();
			panel1.SuspendLayout();
			SuspendLayout();
			//
			// chkSimFolder
			//
			chkSimFolder.AccessibleDescription = resources.GetString(
				"chkSimFolder.AccessibleDescription"
			);
			chkSimFolder.AccessibleName = resources.GetString(
				"chkSimFolder.AccessibleName"
			);
			chkSimFolder.Anchor =
				(AnchorStyles)
					resources.GetObject("chkSimFolder.Anchor")

			;
			chkSimFolder.AutoScroll =
				(bool)resources.GetObject("chkSimFolder.AutoScroll")
			;
			chkSimFolder.AutoScrollMargin =
				(Size)
					resources.GetObject("chkSimFolder.AutoScrollMargin")

			;
			chkSimFolder.AutoScrollMinSize =
				(Size)
					resources.GetObject("chkSimFolder.AutoScrollMinSize")

			;
			chkSimFolder.BackgroundImage =
				(Image)
					resources.GetObject("chkSimFolder.BackgroundImage")

			;
			chkSimFolder.CanFix = true;
			chkSimFolder.Caption = resources.GetString("chkSimFolder.Caption");
			chkSimFolder.CheckState = CheckItemState.Unknown;
			chkSimFolder.Details = "";
			chkSimFolder.Dock =
				(DockStyle)
					resources.GetObject("chkSimFolder.Dock")

			;
			chkSimFolder.Enabled =
				(bool)resources.GetObject("chkSimFolder.Enabled")
			;
			chkSimFolder.Font =
				(Font)resources.GetObject("chkSimFolder.Font")
			;
			chkSimFolder.ImeMode =
				(ImeMode)
					resources.GetObject("chkSimFolder.ImeMode")

			;
			chkSimFolder.Location =
				(Point)resources.GetObject("chkSimFolder.Location")
			;
			chkSimFolder.Name = "chkSimFolder";
			chkSimFolder.RightToLeft =
				(RightToLeft)
					resources.GetObject("chkSimFolder.RightToLeft")

			;
			chkSimFolder.Size =
				(Size)resources.GetObject("chkSimFolder.Size")
			;
			chkSimFolder.TabIndex =
				(int)resources.GetObject("chkSimFolder.TabIndex")
			;
			chkSimFolder.Visible =
				(bool)resources.GetObject("chkSimFolder.Visible")
			;
			chkSimFolder.CalledCheck += new CheckItem.FixEventHandler(
				chkSimFolder_CalledCheck
			);
			chkSimFolder.ClickedFix += new CheckItem.FixEventHandler(
				chkSimFolder_ClickedFix
			);
			//
			// chkCache
			//
			chkCache.AccessibleDescription = resources.GetString(
				"chkCache.AccessibleDescription"
			);
			chkCache.AccessibleName = resources.GetString(
				"chkCache.AccessibleName"
			);
			chkCache.Anchor =
				(AnchorStyles)
					resources.GetObject("chkCache.Anchor")

			;
			chkCache.AutoScroll =
				(bool)resources.GetObject("chkCache.AutoScroll")
			;
			chkCache.AutoScrollMargin =
				(Size)resources.GetObject("chkCache.AutoScrollMargin")
			;
			chkCache.AutoScrollMinSize =
				(Size)resources.GetObject("chkCache.AutoScrollMinSize")
			;
			chkCache.BackgroundImage =
				(Image)resources.GetObject("chkCache.BackgroundImage")
			;
			chkCache.CanFix = true;
			chkCache.Caption = resources.GetString("chkCache.Caption");
			chkCache.CheckState = CheckItemState.Unknown;
			chkCache.Details = "";
			chkCache.Dock =
				(DockStyle)resources.GetObject("chkCache.Dock")
			;
			chkCache.Enabled = (bool)resources.GetObject("chkCache.Enabled");
			chkCache.Font =
				(Font)resources.GetObject("chkCache.Font")
			;
			chkCache.ImeMode =
				(ImeMode)resources.GetObject("chkCache.ImeMode")
			;
			chkCache.Location =
				(Point)resources.GetObject("chkCache.Location")
			;
			chkCache.Name = "chkCache";
			chkCache.RightToLeft =
				(RightToLeft)
					resources.GetObject("chkCache.RightToLeft")

			;
			chkCache.Size =
				(Size)resources.GetObject("chkCache.Size")
			;
			chkCache.TabIndex = (int)resources.GetObject("chkCache.TabIndex");
			chkCache.Visible = (bool)resources.GetObject("chkCache.Visible");
			chkCache.CalledCheck += new CheckItem.FixEventHandler(
				chkCache_CalledCheck
			);
			chkCache.ClickedFix += new CheckItem.FixEventHandler(
				chkCache_ClickedFix
			);
			//
			// chkFileTable
			//
			chkFileTable.AccessibleDescription = resources.GetString(
				"chkFileTable.AccessibleDescription"
			);
			chkFileTable.AccessibleName = resources.GetString(
				"chkFileTable.AccessibleName"
			);
			chkFileTable.Anchor =
				(AnchorStyles)
					resources.GetObject("chkFileTable.Anchor")

			;
			chkFileTable.AutoScroll =
				(bool)resources.GetObject("chkFileTable.AutoScroll")
			;
			chkFileTable.AutoScrollMargin =
				(Size)
					resources.GetObject("chkFileTable.AutoScrollMargin")

			;
			chkFileTable.AutoScrollMinSize =
				(Size)
					resources.GetObject("chkFileTable.AutoScrollMinSize")

			;
			chkFileTable.BackgroundImage =
				(Image)
					resources.GetObject("chkFileTable.BackgroundImage")

			;
			chkFileTable.CanFix = true;
			chkFileTable.Caption = resources.GetString("chkFileTable.Caption");
			chkFileTable.CheckState = CheckItemState.Unknown;
			chkFileTable.Details = "";
			chkFileTable.Dock =
				(DockStyle)
					resources.GetObject("chkFileTable.Dock")

			;
			chkFileTable.Enabled =
				(bool)resources.GetObject("chkFileTable.Enabled")
			;
			chkFileTable.Font =
				(Font)resources.GetObject("chkFileTable.Font")
			;
			chkFileTable.ImeMode =
				(ImeMode)
					resources.GetObject("chkFileTable.ImeMode")

			;
			chkFileTable.Location =
				(Point)resources.GetObject("chkFileTable.Location")
			;
			chkFileTable.Name = "chkFileTable";
			chkFileTable.RightToLeft =
				(RightToLeft)
					resources.GetObject("chkFileTable.RightToLeft")

			;
			chkFileTable.Size =
				(Size)resources.GetObject("chkFileTable.Size")
			;
			chkFileTable.TabIndex =
				(int)resources.GetObject("chkFileTable.TabIndex")
			;
			chkFileTable.Visible =
				(bool)resources.GetObject("chkFileTable.Visible")
			;
			chkFileTable.CalledCheck += new CheckItem.FixEventHandler(
				chkFileTable_CalledCheck
			);
			chkFileTable.ClickedFix += new CheckItem.FixEventHandler(
				chkFileTable_ClickedFix
			);
			//
			// panel1
			//
			panel1.AccessibleDescription = resources.GetString(
				"panel1.AccessibleDescription"
			);
			panel1.AccessibleName = resources.GetString("panel1.AccessibleName");
			panel1.Anchor =
				(AnchorStyles)
					resources.GetObject("panel1.Anchor")

			;
			panel1.AutoScroll = (bool)resources.GetObject("panel1.AutoScroll");
			panel1.AutoScrollMargin =
				(Size)resources.GetObject("panel1.AutoScrollMargin")
			;
			panel1.AutoScrollMinSize =
				(Size)resources.GetObject("panel1.AutoScrollMinSize")
			;
			panel1.BackgroundImage =
				(Image)resources.GetObject("panel1.BackgroundImage")
			;
			panel1.Controls.Add(button1);
			panel1.Dock =
				(DockStyle)resources.GetObject("panel1.Dock")
			;
			panel1.Enabled = (bool)resources.GetObject("panel1.Enabled");
			panel1.Font =
				(Font)resources.GetObject("panel1.Font")
			;
			panel1.ImeMode =
				(ImeMode)resources.GetObject("panel1.ImeMode")
			;
			panel1.Location =
				(Point)resources.GetObject("panel1.Location")
			;
			panel1.Name = "panel1";
			panel1.RightToLeft =
				(RightToLeft)
					resources.GetObject("panel1.RightToLeft")

			;
			panel1.Size =
				(Size)resources.GetObject("panel1.Size")
			;
			panel1.TabIndex = (int)resources.GetObject("panel1.TabIndex");
			panel1.Text = resources.GetString("panel1.Text");
			panel1.Visible = (bool)resources.GetObject("panel1.Visible");
			//
			// button1
			//
			button1.AccessibleDescription = resources.GetString(
				"button1.AccessibleDescription"
			);
			button1.AccessibleName = resources.GetString("button1.AccessibleName");
			button1.Anchor =
				(AnchorStyles)
					resources.GetObject("button1.Anchor")

			;
			button1.BackgroundImage =
				(Image)resources.GetObject("button1.BackgroundImage")
			;
			button1.Dock =
				(DockStyle)resources.GetObject("button1.Dock")
			;
			button1.Enabled = (bool)resources.GetObject("button1.Enabled");
			button1.FlatStyle =
				(FlatStyle)
					resources.GetObject("button1.FlatStyle")

			;
			button1.Font =
				(Font)resources.GetObject("button1.Font")
			;
			button1.Image =
				(Image)resources.GetObject("button1.Image")
			;
			button1.ImageAlign =
				(ContentAlignment)
					resources.GetObject("button1.ImageAlign")

			;
			button1.ImageIndex =
				(int)resources.GetObject("button1.ImageIndex")
			;
			button1.ImeMode =
				(ImeMode)resources.GetObject("button1.ImeMode")
			;
			button1.Location =
				(Point)resources.GetObject("button1.Location")
			;
			button1.Name = "button1";
			button1.RightToLeft =
				(RightToLeft)
					resources.GetObject("button1.RightToLeft")

			;
			button1.Size =
				(Size)resources.GetObject("button1.Size")
			;
			button1.TabIndex = (int)resources.GetObject("button1.TabIndex");
			button1.Text = resources.GetString("button1.Text");
			button1.TextAlign =
				(ContentAlignment)
					resources.GetObject("button1.TextAlign")

			;
			button1.Visible = (bool)resources.GetObject("button1.Visible");
			button1.Click += new EventHandler(button1_Click);
			//
			// panel2
			//
			panel2.AccessibleDescription = resources.GetString(
				"panel2.AccessibleDescription"
			);
			panel2.AccessibleName = resources.GetString("panel2.AccessibleName");
			panel2.Anchor =
				(AnchorStyles)
					resources.GetObject("panel2.Anchor")

			;
			panel2.AutoScroll = (bool)resources.GetObject("panel2.AutoScroll");
			panel2.AutoScrollMargin =
				(Size)resources.GetObject("panel2.AutoScrollMargin")
			;
			panel2.AutoScrollMinSize =
				(Size)resources.GetObject("panel2.AutoScrollMinSize")
			;
			panel2.BackColor = SystemColors.AppWorkspace;
			panel2.BackgroundImage =
				(Image)resources.GetObject("panel2.BackgroundImage")
			;
			panel2.Dock =
				(DockStyle)resources.GetObject("panel2.Dock")
			;
			panel2.Enabled = (bool)resources.GetObject("panel2.Enabled");
			panel2.Font =
				(Font)resources.GetObject("panel2.Font")
			;
			panel2.ImeMode =
				(ImeMode)resources.GetObject("panel2.ImeMode")
			;
			panel2.Location =
				(Point)resources.GetObject("panel2.Location")
			;
			panel2.Name = "panel2";
			panel2.RightToLeft =
				(RightToLeft)
					resources.GetObject("panel2.RightToLeft")

			;
			panel2.Size =
				(Size)resources.GetObject("panel2.Size")
			;
			panel2.TabIndex = (int)resources.GetObject("panel2.TabIndex");
			panel2.Text = resources.GetString("panel2.Text");
			panel2.Visible = (bool)resources.GetObject("panel2.Visible");
			//
			// panel3
			//
			panel3.AccessibleDescription = resources.GetString(
				"panel3.AccessibleDescription"
			);
			panel3.AccessibleName = resources.GetString("panel3.AccessibleName");
			panel3.Anchor =
				(AnchorStyles)
					resources.GetObject("panel3.Anchor")

			;
			panel3.AutoScroll = (bool)resources.GetObject("panel3.AutoScroll");
			panel3.AutoScrollMargin =
				(Size)resources.GetObject("panel3.AutoScrollMargin")
			;
			panel3.AutoScrollMinSize =
				(Size)resources.GetObject("panel3.AutoScrollMinSize")
			;
			panel3.BackColor = SystemColors.AppWorkspace;
			panel3.BackgroundImage =
				(Image)resources.GetObject("panel3.BackgroundImage")
			;
			panel3.Dock =
				(DockStyle)resources.GetObject("panel3.Dock")
			;
			panel3.Enabled = (bool)resources.GetObject("panel3.Enabled");
			panel3.Font =
				(Font)resources.GetObject("panel3.Font")
			;
			panel3.ImeMode =
				(ImeMode)resources.GetObject("panel3.ImeMode")
			;
			panel3.Location =
				(Point)resources.GetObject("panel3.Location")
			;
			panel3.Name = "panel3";
			panel3.RightToLeft =
				(RightToLeft)
					resources.GetObject("panel3.RightToLeft")

			;
			panel3.Size =
				(Size)resources.GetObject("panel3.Size")
			;
			panel3.TabIndex = (int)resources.GetObject("panel3.TabIndex");
			panel3.Text = resources.GetString("panel3.Text");
			panel3.Visible = (bool)resources.GetObject("panel3.Visible");
			//
			// panel4
			//
			panel4.AccessibleDescription = resources.GetString(
				"panel4.AccessibleDescription"
			);
			panel4.AccessibleName = resources.GetString("panel4.AccessibleName");
			panel4.Anchor =
				(AnchorStyles)
					resources.GetObject("panel4.Anchor")

			;
			panel4.AutoScroll = (bool)resources.GetObject("panel4.AutoScroll");
			panel4.AutoScrollMargin =
				(Size)resources.GetObject("panel4.AutoScrollMargin")
			;
			panel4.AutoScrollMinSize =
				(Size)resources.GetObject("panel4.AutoScrollMinSize")
			;
			panel4.BackColor = SystemColors.AppWorkspace;
			panel4.BackgroundImage =
				(Image)resources.GetObject("panel4.BackgroundImage")
			;
			panel4.Dock =
				(DockStyle)resources.GetObject("panel4.Dock")
			;
			panel4.Enabled = (bool)resources.GetObject("panel4.Enabled");
			panel4.Font =
				(Font)resources.GetObject("panel4.Font")
			;
			panel4.ImeMode =
				(ImeMode)resources.GetObject("panel4.ImeMode")
			;
			panel4.Location =
				(Point)resources.GetObject("panel4.Location")
			;
			panel4.Name = "panel4";
			panel4.RightToLeft =
				(RightToLeft)
					resources.GetObject("panel4.RightToLeft")

			;
			panel4.Size =
				(Size)resources.GetObject("panel4.Size")
			;
			panel4.TabIndex = (int)resources.GetObject("panel4.TabIndex");
			panel4.Text = resources.GetString("panel4.Text");
			panel4.Visible = (bool)resources.GetObject("panel4.Visible");
			//
			// CheckControl
			//
			AccessibleDescription = resources.GetString(
				"$this.AccessibleDescription"
			);
			AccessibleName = resources.GetString("$this.AccessibleName");
			AutoScroll = (bool)resources.GetObject("$this.AutoScroll");
			AutoScrollMargin =
				(Size)resources.GetObject("$this.AutoScrollMargin")
			;
			AutoScrollMinSize =
				(Size)resources.GetObject("$this.AutoScrollMinSize")
			;
			BackgroundImage =
				(Image)resources.GetObject("$this.BackgroundImage")
			;
			Controls.Add(panel1);
			Controls.Add(panel4);
			Controls.Add(chkFileTable);
			Controls.Add(panel3);
			Controls.Add(chkCache);
			Controls.Add(panel2);
			Controls.Add(chkSimFolder);
			Enabled = (bool)resources.GetObject("$this.Enabled");
			Font = (Font)resources.GetObject("$this.Font");
			ImeMode =
				(ImeMode)resources.GetObject("$this.ImeMode")
			;
			Location =
				(Point)resources.GetObject("$this.Location")
			;
			Name = "CheckControl";
			RightToLeft =
				(RightToLeft)
					resources.GetObject("$this.RightToLeft")

			;
			Size = (Size)resources.GetObject("$this.Size");
			panel1.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion

		public void Reset()
		{
			foreach (Control c in Controls)
			{
				if (c is CheckItem)
				{
					((CheckItem)c).Reset();
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			button1.Visible = false;
			Cursor = Cursors.WaitCursor;
			Reset();
			foreach (Control c in Controls)
			{
				if (c is CheckItem)
				{
					((CheckItem)c).Check();
				}
			}

			Cursor = Cursors.Default;

			foreach (Control d in Controls)
			{
				if (d is CheckItem)
				{
					if (((CheckItem)d).CheckState != CheckItemState.Ok)
					{
						button1.Visible = true;
					}
				}
			}
		}

		public static void ClearCache()
		{
			string[] files = System.IO.Directory.GetFiles(
				Helper.SimPeDataPath,
				"*.simpepkg"
			);
			foreach (string file in files)
			{
				try
				{
					System.IO.File.Delete(file);
					CaCleared = true;
				}
				catch (Exception ex)
				{
					Helper.ExceptionMessage("", ex);
				}
			}
			if (Helper.StartedGui == Executable.Other)
			{
				Message.Show(
					"The caches are cleared.",
					"Information",
					MessageBoxButtons.OK
				);
			}
			else
			{
				Message.Show(
					Localization.GetString("cache_cleared"),
					"Information",
					MessageBoxButtons.OK
				);
			}
		}

		public event EventHandler FixedFileTable;

		#region Sims Path Test
		private CheckItemState chkSimFolder_CalledCheck(
			object sender,
			CheckItemState isok
		)
		{
			isok = CheckItemState.Ok;
			CheckItem ci = sender as CheckItem;
			try
			{
				string test,
					path;
				foreach (ExpansionItem ei in PathProvider.Global.Expansions)
				{
					if (!ei.Exists)
					{
						continue;
					}

					path = ei.InstallFolder; //Helper.WindowsRegistry.GetExecutableFolder(ep);
					string name = ei.ExeName;

					if (ei == PathProvider.Global.Latest || ei.Flag.SimStory)
					{
						test = System.IO.Path.Combine(
							path,
							"TSBin" + Helper.PATH_SEP + name
						);
						if (!System.IO.File.Exists(test))
						{
							isok = CheckItemState.Fail;
							ci.Details +=

									Localization.GetString("Check: Folder not found")
									.Replace("{name}", ei.Name) + Helper.lbr;
							ci.Details +=
								"    "
								+
									Localization.GetString("Check: Unable to locate")
									.Replace("{name}", test)
								+ Helper.lbr
								+ Helper.lbr;
							continue;
						}

						test = System.IO.Path.Combine(
							path,
							"TSData"
								+ Helper.PATH_SEP
								+ "Res"
								+ Helper.PATH_SEP
								+ "Objects"
								+ Helper.PATH_SEP
								+ "objects.package"
						);
						if (!System.IO.File.Exists(test))
						{
							isok = CheckItemState.Fail;
							ci.Details +=

									Localization.GetString("Check: Folder not found")
									.Replace("{name}", ei.Name) + Helper.lbr;
							ci.Details +=
								"    "
								+
									Localization.GetString("Check: Unable to locate")
									.Replace("{name}", test)
								+ Helper.lbr
								+ Helper.lbr;
							continue;
						} // objects.package is Only used in the Highest EP
					}
					if (!ei.Flag.FullObjectsPackage)
					{
						test = System.IO.Path.Combine(
							path,
							ei.ObjectsSubFolder + Helper.PATH_SEP + "SPObjects.package"
						);
						if (!System.IO.File.Exists(test))
						{
							isok = CheckItemState.Fail;
							ci.Details +=

									Localization.GetString("Check: Folder not found")
									.Replace("{name}", ei.Name) + Helper.lbr;
							ci.Details +=
								"    "
								+
									Localization.GetString("Check: Unable to locate")
									.Replace("{name}", test)
								+ Helper.lbr
								+ Helper.lbr;
							continue;
						}
					}
				}

				path = PathProvider.Global.GetSaveGamePathForGroup(
							PathProvider.Global.CurrentGroup
						)
						.Count > 0
					? PathProvider.Global.GetSaveGamePathForGroup(
						PathProvider.Global.CurrentGroup
					)[0]
					: PathProvider.SimSavegameFolder;

				test = System.IO.Path.Combine(path, "Neighborhoods");
				if (!System.IO.Directory.Exists(test))
				{
					isok = CheckItemState.Fail;
					ci.Details +=

							Localization.GetString("Check: Folder not found")
							.Replace(
								"{name}",
								Localization.GetString("Savegames")
							) + Helper.lbr;
					ci.Details +=
						"    "
						+
							Localization.GetString("Check: Unable to locate")
							.Replace("{name}", test)
						+ Helper.lbr
						+ Helper.lbr;
				}

				if (isok == CheckItemState.Ok)
				{
					if (PathProvider.Global.GameVersion < 16)
					{
						test = Data.MetaData.GMND_PACKAGE;
						if (!System.IO.File.Exists(test))
						{
							isok = CheckItemState.Warning;
							ci.Details +=
								Localization.GetString("Check: CEP not found")
								+ Helper.lbr;
							ci.Details +=
								"    "
								+
									Localization.GetString("Check: Unable to locate")
									.Replace("{name}", test)
								+ Helper.lbr
								+ Helper.lbr;
						}
						test = Data.MetaData.MMAT_PACKAGE;
						if (!System.IO.File.Exists(test))
						{
							isok = CheckItemState.Warning;
							ci.Details +=
								Localization.GetString("Check: CEP not found")
								+ Helper.lbr;
							ci.Details +=
								"    "
								+
									Localization.GetString("Check: Unable to locate")
									.Replace("{name}", test)
								+ Helper.lbr
								+ Helper.lbr;
						}
					}
					else if (PathProvider.Global.GameVersion > 17)
					{
						if (
							System.IO.File.Exists(Data.MetaData.GMND_PACKAGE)
							|| System.IO.File.Exists(Data.MetaData.MMAT_PACKAGE)
							|| System.IO.File.Exists(Data.MetaData.CTLG_FOLDER)
							|| System.IO.File.Exists(Data.MetaData.ZCEP_FOLDER)
						)
						{
							isok = CheckItemState.Warning;
							ci.Details +=
								Localization.GetString("Check: CEP is installed")
								+ Helper.lbr;
						}
					}
				}
			}
			catch (Exception ex)
			{
				isok = CheckItemState.Fail;
				ci.Details = ex.Message;
			}

			return isok;
		}

		private CheckItemState chkSimFolder_ClickedFix(
			object sender,
			CheckItemState isok
		)
		{
			isok = CheckItemState.Unknown;
			PathProvider.Global.SetDefaultPaths();
			if (Helper.Profile.Length > 0)
			{
				MessageBox.Show(
					"You will need to re-save profile " + Helper.Profile,
					"Fix",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
				);
			}

			return isok;
		}
		#endregion

		#region Cache Test
		private CheckItemState chkCache_CalledCheck(
			object sender,
			CheckItemState isok
		)
		{
			isok = CheckItemState.Ok;
			CheckItem ci = sender as CheckItem;
			try
			{
				Cache.CacheFile cf = new Cache.CacheFile();
				string path = System.IO.Path.Combine(
					Helper.SimPeDataPath,
					"objcache.simpepkg"
				);
				try
				{
					if (System.IO.File.Exists(path))
					{
						System.IO.File.Delete(
							System.IO.Path.Combine(
								Helper.SimPeDataPath,
								"objcache.simpepkg"
							)
						);
					}
				}
				catch { }

				path = Helper.SimPeLanguageCache;
				try
				{
					cf.Load(path);
				}
				catch (Exception ex)
				{
					ci.Details +=
						Localization.GetString("Check: Unable to load cache")
						+ Helper.lbr;
					ci.Details +=
						"    "
						+
							Localization.GetString("Check: Error while load")
							.Replace("{name}", path)
						+ Helper.lbr;
					ci.Details += "    " + ex.Message + Helper.lbr + Helper.lbr;
					isok = CheckItemState.Fail;
				}
			}
			catch (Exception ex)
			{
				isok = CheckItemState.Fail;
				ci.Details = ex.Message;
			}

			return isok;
		}

		private CheckItemState chkCache_ClickedFix(
			object sender,
			CheckItemState isok
		)
		{
			isok = CheckItemState.Unknown;
			ClearCache();
			return isok;
		}
		#endregion

		#region Filetable Test
		private CheckItemState chkFileTable_CalledCheck(
			object sender,
			CheckItemState isok
		)
		{
			isok = CheckItemState.Ok;
			FileTableBase.FileIndex.Load();
			CheckItem ci = sender as CheckItem;
			try
			{
				Interfaces.Scenegraph.IScenegraphFileIndexItem[] items =
					FileTableBase.FileIndex.FindFile(Data.MetaData.OBJD_FILE, true);
				if (items.Length < 3000)
				{
					ci.Details +=
						Localization.GetString("Check: No Objects") + Helper.lbr;
					isok = CheckItemState.Fail;
				}
				else
				{
					items = FileTableBase.FileIndex.FindFile(
						Data.MetaData.OBJD_FILE,
						0x7F94AFE8,
						0x000041AB,
						null
					); //Bed - Double - Loft - D
					if (items.Length == 0)
					{
						ci.Details +=
							Localization.GetString("Check: No Objects")
							+ Helper.lbr;
						isok = CheckItemState.Fail;
					}
				}

				items = FileTableBase.FileIndex.FindFile(Data.MetaData.TXMT, true);
				if (items.Length < 100)
				{
					ci.Details +=
						Localization.GetString("Check: No Textures") + Helper.lbr;
					isok = CheckItemState.Fail;
				}
			}
			catch (Exception ex)
			{
				isok = CheckItemState.Fail;
				ci.Details = ex.Message;
			}

			return isok;
		}

		private CheckItemState chkFileTable_ClickedFix(
			object sender,
			CheckItemState isok
		)
		{
			isok = CheckItemState.Unknown;
			try
			{
				string msg = "your file table folder settings will be reset";
				if (Helper.Profile.Length > 0)
				{
					msg += " and you will need to re-save profile " + Helper.Profile;
				}

				if (
					MessageBox.Show(
						"The File table settings file was not correct and you have asked to fix it.\n"
							+ Helper.DataFolder.FoldersXREG
							+ "\n"
							+ "SimPe can generate a new one ("
							+ msg
							+ ").\n\n"
							+ "Should SimPe delete the File table settings File?",
						"Fix",
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Question
					) == DialogResult.Yes
				)
				{
					System.IO.File.Delete(Helper.DataFolder.FoldersXREG);
					FileTable.Reload();
					if (FixedFileTable != null)
					{
						FixedFileTable(this, new EventArgs());
					}
				}
			}
			catch
			{
				isok = CheckItemState.Fail;
			}
			return isok;
		}
		#endregion
	}
}
