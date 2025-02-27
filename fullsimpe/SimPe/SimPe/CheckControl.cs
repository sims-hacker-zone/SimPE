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
			if (name == "fail")
			{
				return GetIcon.Fail;
			}
			else if (name == "ok")
			{
				return GetIcon.OK;
			}
			else if (name == "warn")
			{
				return GetIcon.Warn;
			}
			else
			{
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
				if (components != null)
				{
					components.Dispose();
				}
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
			this.chkSimFolder = new CheckItem();
			this.chkCache = new CheckItem();
			this.chkFileTable = new CheckItem();
			this.panel1 = new Panel();
			this.button1 = new Button();
			this.panel2 = new Panel();
			this.panel3 = new Panel();
			this.panel4 = new Panel();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			//
			// chkSimFolder
			//
			this.chkSimFolder.AccessibleDescription = resources.GetString(
				"chkSimFolder.AccessibleDescription"
			);
			this.chkSimFolder.AccessibleName = resources.GetString(
				"chkSimFolder.AccessibleName"
			);
			this.chkSimFolder.Anchor = (
				(AnchorStyles)(
					resources.GetObject("chkSimFolder.Anchor")
				)
			);
			this.chkSimFolder.AutoScroll = (
				(bool)(resources.GetObject("chkSimFolder.AutoScroll"))
			);
			this.chkSimFolder.AutoScrollMargin = (
				(Size)(
					resources.GetObject("chkSimFolder.AutoScrollMargin")
				)
			);
			this.chkSimFolder.AutoScrollMinSize = (
				(Size)(
					resources.GetObject("chkSimFolder.AutoScrollMinSize")
				)
			);
			this.chkSimFolder.BackgroundImage = (
				(Image)(
					resources.GetObject("chkSimFolder.BackgroundImage")
				)
			);
			this.chkSimFolder.CanFix = true;
			this.chkSimFolder.Caption = resources.GetString("chkSimFolder.Caption");
			this.chkSimFolder.CheckState = SimPe.CheckItemState.Unknown;
			this.chkSimFolder.Details = "";
			this.chkSimFolder.Dock = (
				(DockStyle)(
					resources.GetObject("chkSimFolder.Dock")
				)
			);
			this.chkSimFolder.Enabled = (
				(bool)(resources.GetObject("chkSimFolder.Enabled"))
			);
			this.chkSimFolder.Font = (
				(Font)(resources.GetObject("chkSimFolder.Font"))
			);
			this.chkSimFolder.ImeMode = (
				(ImeMode)(
					resources.GetObject("chkSimFolder.ImeMode")
				)
			);
			this.chkSimFolder.Location = (
				(Point)(resources.GetObject("chkSimFolder.Location"))
			);
			this.chkSimFolder.Name = "chkSimFolder";
			this.chkSimFolder.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("chkSimFolder.RightToLeft")
				)
			);
			this.chkSimFolder.Size = (
				(Size)(resources.GetObject("chkSimFolder.Size"))
			);
			this.chkSimFolder.TabIndex = (
				(int)(resources.GetObject("chkSimFolder.TabIndex"))
			);
			this.chkSimFolder.Visible = (
				(bool)(resources.GetObject("chkSimFolder.Visible"))
			);
			this.chkSimFolder.CalledCheck += new CheckItem.FixEventHandler(
				this.chkSimFolder_CalledCheck
			);
			this.chkSimFolder.ClickedFix += new CheckItem.FixEventHandler(
				this.chkSimFolder_ClickedFix
			);
			//
			// chkCache
			//
			this.chkCache.AccessibleDescription = resources.GetString(
				"chkCache.AccessibleDescription"
			);
			this.chkCache.AccessibleName = resources.GetString(
				"chkCache.AccessibleName"
			);
			this.chkCache.Anchor = (
				(AnchorStyles)(
					resources.GetObject("chkCache.Anchor")
				)
			);
			this.chkCache.AutoScroll = (
				(bool)(resources.GetObject("chkCache.AutoScroll"))
			);
			this.chkCache.AutoScrollMargin = (
				(Size)(resources.GetObject("chkCache.AutoScrollMargin"))
			);
			this.chkCache.AutoScrollMinSize = (
				(Size)(resources.GetObject("chkCache.AutoScrollMinSize"))
			);
			this.chkCache.BackgroundImage = (
				(Image)(resources.GetObject("chkCache.BackgroundImage"))
			);
			this.chkCache.CanFix = true;
			this.chkCache.Caption = resources.GetString("chkCache.Caption");
			this.chkCache.CheckState = SimPe.CheckItemState.Unknown;
			this.chkCache.Details = "";
			this.chkCache.Dock = (
				(DockStyle)(resources.GetObject("chkCache.Dock"))
			);
			this.chkCache.Enabled = ((bool)(resources.GetObject("chkCache.Enabled")));
			this.chkCache.Font = (
				(Font)(resources.GetObject("chkCache.Font"))
			);
			this.chkCache.ImeMode = (
				(ImeMode)(resources.GetObject("chkCache.ImeMode"))
			);
			this.chkCache.Location = (
				(Point)(resources.GetObject("chkCache.Location"))
			);
			this.chkCache.Name = "chkCache";
			this.chkCache.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("chkCache.RightToLeft")
				)
			);
			this.chkCache.Size = (
				(Size)(resources.GetObject("chkCache.Size"))
			);
			this.chkCache.TabIndex = ((int)(resources.GetObject("chkCache.TabIndex")));
			this.chkCache.Visible = ((bool)(resources.GetObject("chkCache.Visible")));
			this.chkCache.CalledCheck += new CheckItem.FixEventHandler(
				this.chkCache_CalledCheck
			);
			this.chkCache.ClickedFix += new CheckItem.FixEventHandler(
				this.chkCache_ClickedFix
			);
			//
			// chkFileTable
			//
			this.chkFileTable.AccessibleDescription = resources.GetString(
				"chkFileTable.AccessibleDescription"
			);
			this.chkFileTable.AccessibleName = resources.GetString(
				"chkFileTable.AccessibleName"
			);
			this.chkFileTable.Anchor = (
				(AnchorStyles)(
					resources.GetObject("chkFileTable.Anchor")
				)
			);
			this.chkFileTable.AutoScroll = (
				(bool)(resources.GetObject("chkFileTable.AutoScroll"))
			);
			this.chkFileTable.AutoScrollMargin = (
				(Size)(
					resources.GetObject("chkFileTable.AutoScrollMargin")
				)
			);
			this.chkFileTable.AutoScrollMinSize = (
				(Size)(
					resources.GetObject("chkFileTable.AutoScrollMinSize")
				)
			);
			this.chkFileTable.BackgroundImage = (
				(Image)(
					resources.GetObject("chkFileTable.BackgroundImage")
				)
			);
			this.chkFileTable.CanFix = true;
			this.chkFileTable.Caption = resources.GetString("chkFileTable.Caption");
			this.chkFileTable.CheckState = SimPe.CheckItemState.Unknown;
			this.chkFileTable.Details = "";
			this.chkFileTable.Dock = (
				(DockStyle)(
					resources.GetObject("chkFileTable.Dock")
				)
			);
			this.chkFileTable.Enabled = (
				(bool)(resources.GetObject("chkFileTable.Enabled"))
			);
			this.chkFileTable.Font = (
				(Font)(resources.GetObject("chkFileTable.Font"))
			);
			this.chkFileTable.ImeMode = (
				(ImeMode)(
					resources.GetObject("chkFileTable.ImeMode")
				)
			);
			this.chkFileTable.Location = (
				(Point)(resources.GetObject("chkFileTable.Location"))
			);
			this.chkFileTable.Name = "chkFileTable";
			this.chkFileTable.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("chkFileTable.RightToLeft")
				)
			);
			this.chkFileTable.Size = (
				(Size)(resources.GetObject("chkFileTable.Size"))
			);
			this.chkFileTable.TabIndex = (
				(int)(resources.GetObject("chkFileTable.TabIndex"))
			);
			this.chkFileTable.Visible = (
				(bool)(resources.GetObject("chkFileTable.Visible"))
			);
			this.chkFileTable.CalledCheck += new CheckItem.FixEventHandler(
				this.chkFileTable_CalledCheck
			);
			this.chkFileTable.ClickedFix += new CheckItem.FixEventHandler(
				this.chkFileTable_ClickedFix
			);
			//
			// panel1
			//
			this.panel1.AccessibleDescription = resources.GetString(
				"panel1.AccessibleDescription"
			);
			this.panel1.AccessibleName = resources.GetString("panel1.AccessibleName");
			this.panel1.Anchor = (
				(AnchorStyles)(
					resources.GetObject("panel1.Anchor")
				)
			);
			this.panel1.AutoScroll = ((bool)(resources.GetObject("panel1.AutoScroll")));
			this.panel1.AutoScrollMargin = (
				(Size)(resources.GetObject("panel1.AutoScrollMargin"))
			);
			this.panel1.AutoScrollMinSize = (
				(Size)(resources.GetObject("panel1.AutoScrollMinSize"))
			);
			this.panel1.BackgroundImage = (
				(Image)(resources.GetObject("panel1.BackgroundImage"))
			);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Dock = (
				(DockStyle)(resources.GetObject("panel1.Dock"))
			);
			this.panel1.Enabled = ((bool)(resources.GetObject("panel1.Enabled")));
			this.panel1.Font = (
				(Font)(resources.GetObject("panel1.Font"))
			);
			this.panel1.ImeMode = (
				(ImeMode)(resources.GetObject("panel1.ImeMode"))
			);
			this.panel1.Location = (
				(Point)(resources.GetObject("panel1.Location"))
			);
			this.panel1.Name = "panel1";
			this.panel1.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("panel1.RightToLeft")
				)
			);
			this.panel1.Size = (
				(Size)(resources.GetObject("panel1.Size"))
			);
			this.panel1.TabIndex = ((int)(resources.GetObject("panel1.TabIndex")));
			this.panel1.Text = resources.GetString("panel1.Text");
			this.panel1.Visible = ((bool)(resources.GetObject("panel1.Visible")));
			//
			// button1
			//
			this.button1.AccessibleDescription = resources.GetString(
				"button1.AccessibleDescription"
			);
			this.button1.AccessibleName = resources.GetString("button1.AccessibleName");
			this.button1.Anchor = (
				(AnchorStyles)(
					resources.GetObject("button1.Anchor")
				)
			);
			this.button1.BackgroundImage = (
				(Image)(resources.GetObject("button1.BackgroundImage"))
			);
			this.button1.Dock = (
				(DockStyle)(resources.GetObject("button1.Dock"))
			);
			this.button1.Enabled = ((bool)(resources.GetObject("button1.Enabled")));
			this.button1.FlatStyle = (
				(FlatStyle)(
					resources.GetObject("button1.FlatStyle")
				)
			);
			this.button1.Font = (
				(Font)(resources.GetObject("button1.Font"))
			);
			this.button1.Image = (
				(Image)(resources.GetObject("button1.Image"))
			);
			this.button1.ImageAlign = (
				(ContentAlignment)(
					resources.GetObject("button1.ImageAlign")
				)
			);
			this.button1.ImageIndex = (
				(int)(resources.GetObject("button1.ImageIndex"))
			);
			this.button1.ImeMode = (
				(ImeMode)(resources.GetObject("button1.ImeMode"))
			);
			this.button1.Location = (
				(Point)(resources.GetObject("button1.Location"))
			);
			this.button1.Name = "button1";
			this.button1.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("button1.RightToLeft")
				)
			);
			this.button1.Size = (
				(Size)(resources.GetObject("button1.Size"))
			);
			this.button1.TabIndex = ((int)(resources.GetObject("button1.TabIndex")));
			this.button1.Text = resources.GetString("button1.Text");
			this.button1.TextAlign = (
				(ContentAlignment)(
					resources.GetObject("button1.TextAlign")
				)
			);
			this.button1.Visible = ((bool)(resources.GetObject("button1.Visible")));
			this.button1.Click += new EventHandler(this.button1_Click);
			//
			// panel2
			//
			this.panel2.AccessibleDescription = resources.GetString(
				"panel2.AccessibleDescription"
			);
			this.panel2.AccessibleName = resources.GetString("panel2.AccessibleName");
			this.panel2.Anchor = (
				(AnchorStyles)(
					resources.GetObject("panel2.Anchor")
				)
			);
			this.panel2.AutoScroll = ((bool)(resources.GetObject("panel2.AutoScroll")));
			this.panel2.AutoScrollMargin = (
				(Size)(resources.GetObject("panel2.AutoScrollMargin"))
			);
			this.panel2.AutoScrollMinSize = (
				(Size)(resources.GetObject("panel2.AutoScrollMinSize"))
			);
			this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.panel2.BackgroundImage = (
				(Image)(resources.GetObject("panel2.BackgroundImage"))
			);
			this.panel2.Dock = (
				(DockStyle)(resources.GetObject("panel2.Dock"))
			);
			this.panel2.Enabled = ((bool)(resources.GetObject("panel2.Enabled")));
			this.panel2.Font = (
				(Font)(resources.GetObject("panel2.Font"))
			);
			this.panel2.ImeMode = (
				(ImeMode)(resources.GetObject("panel2.ImeMode"))
			);
			this.panel2.Location = (
				(Point)(resources.GetObject("panel2.Location"))
			);
			this.panel2.Name = "panel2";
			this.panel2.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("panel2.RightToLeft")
				)
			);
			this.panel2.Size = (
				(Size)(resources.GetObject("panel2.Size"))
			);
			this.panel2.TabIndex = ((int)(resources.GetObject("panel2.TabIndex")));
			this.panel2.Text = resources.GetString("panel2.Text");
			this.panel2.Visible = ((bool)(resources.GetObject("panel2.Visible")));
			//
			// panel3
			//
			this.panel3.AccessibleDescription = resources.GetString(
				"panel3.AccessibleDescription"
			);
			this.panel3.AccessibleName = resources.GetString("panel3.AccessibleName");
			this.panel3.Anchor = (
				(AnchorStyles)(
					resources.GetObject("panel3.Anchor")
				)
			);
			this.panel3.AutoScroll = ((bool)(resources.GetObject("panel3.AutoScroll")));
			this.panel3.AutoScrollMargin = (
				(Size)(resources.GetObject("panel3.AutoScrollMargin"))
			);
			this.panel3.AutoScrollMinSize = (
				(Size)(resources.GetObject("panel3.AutoScrollMinSize"))
			);
			this.panel3.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.panel3.BackgroundImage = (
				(Image)(resources.GetObject("panel3.BackgroundImage"))
			);
			this.panel3.Dock = (
				(DockStyle)(resources.GetObject("panel3.Dock"))
			);
			this.panel3.Enabled = ((bool)(resources.GetObject("panel3.Enabled")));
			this.panel3.Font = (
				(Font)(resources.GetObject("panel3.Font"))
			);
			this.panel3.ImeMode = (
				(ImeMode)(resources.GetObject("panel3.ImeMode"))
			);
			this.panel3.Location = (
				(Point)(resources.GetObject("panel3.Location"))
			);
			this.panel3.Name = "panel3";
			this.panel3.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("panel3.RightToLeft")
				)
			);
			this.panel3.Size = (
				(Size)(resources.GetObject("panel3.Size"))
			);
			this.panel3.TabIndex = ((int)(resources.GetObject("panel3.TabIndex")));
			this.panel3.Text = resources.GetString("panel3.Text");
			this.panel3.Visible = ((bool)(resources.GetObject("panel3.Visible")));
			//
			// panel4
			//
			this.panel4.AccessibleDescription = resources.GetString(
				"panel4.AccessibleDescription"
			);
			this.panel4.AccessibleName = resources.GetString("panel4.AccessibleName");
			this.panel4.Anchor = (
				(AnchorStyles)(
					resources.GetObject("panel4.Anchor")
				)
			);
			this.panel4.AutoScroll = ((bool)(resources.GetObject("panel4.AutoScroll")));
			this.panel4.AutoScrollMargin = (
				(Size)(resources.GetObject("panel4.AutoScrollMargin"))
			);
			this.panel4.AutoScrollMinSize = (
				(Size)(resources.GetObject("panel4.AutoScrollMinSize"))
			);
			this.panel4.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.panel4.BackgroundImage = (
				(Image)(resources.GetObject("panel4.BackgroundImage"))
			);
			this.panel4.Dock = (
				(DockStyle)(resources.GetObject("panel4.Dock"))
			);
			this.panel4.Enabled = ((bool)(resources.GetObject("panel4.Enabled")));
			this.panel4.Font = (
				(Font)(resources.GetObject("panel4.Font"))
			);
			this.panel4.ImeMode = (
				(ImeMode)(resources.GetObject("panel4.ImeMode"))
			);
			this.panel4.Location = (
				(Point)(resources.GetObject("panel4.Location"))
			);
			this.panel4.Name = "panel4";
			this.panel4.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("panel4.RightToLeft")
				)
			);
			this.panel4.Size = (
				(Size)(resources.GetObject("panel4.Size"))
			);
			this.panel4.TabIndex = ((int)(resources.GetObject("panel4.TabIndex")));
			this.panel4.Text = resources.GetString("panel4.Text");
			this.panel4.Visible = ((bool)(resources.GetObject("panel4.Visible")));
			//
			// CheckControl
			//
			this.AccessibleDescription = resources.GetString(
				"$this.AccessibleDescription"
			);
			this.AccessibleName = resources.GetString("$this.AccessibleName");
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoScrollMargin = (
				(Size)(resources.GetObject("$this.AutoScrollMargin"))
			);
			this.AutoScrollMinSize = (
				(Size)(resources.GetObject("$this.AutoScrollMinSize"))
			);
			this.BackgroundImage = (
				(Image)(resources.GetObject("$this.BackgroundImage"))
			);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.chkFileTable);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.chkCache);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.chkSimFolder);
			this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			this.Font = ((Font)(resources.GetObject("$this.Font")));
			this.ImeMode = (
				(ImeMode)(resources.GetObject("$this.ImeMode"))
			);
			this.Location = (
				(Point)(resources.GetObject("$this.Location"))
			);
			this.Name = "CheckControl";
			this.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("$this.RightToLeft")
				)
			);
			this.Size = ((Size)(resources.GetObject("$this.Size")));
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion

		public void Reset()
		{
			foreach (Control c in this.Controls)
			{
				if (c is CheckItem)
				{
					((CheckItem)c).Reset();
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.button1.Visible = false;
			this.Cursor = Cursors.WaitCursor;
			Reset();
			foreach (Control c in this.Controls)
			{
				if (c is CheckItem)
				{
					((CheckItem)c).Check();
				}
			}

			this.Cursor = Cursors.Default;

			foreach (Control d in this.Controls)
			{
				if (d is CheckItem)
				{
					if (((CheckItem)d).CheckState != CheckItemState.Ok)
					{
						this.button1.Visible = true;
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
					SimPe.Localization.GetString("cache_cleared"),
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
								SimPe
									.Localization.GetString("Check: Folder not found")
									.Replace("{name}", ei.Name) + Helper.lbr;
							ci.Details +=
								"    "
								+ SimPe
									.Localization.GetString("Check: Unable to locate")
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
								SimPe
									.Localization.GetString("Check: Folder not found")
									.Replace("{name}", ei.Name) + Helper.lbr;
							ci.Details +=
								"    "
								+ SimPe
									.Localization.GetString("Check: Unable to locate")
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
								SimPe
									.Localization.GetString("Check: Folder not found")
									.Replace("{name}", ei.Name) + Helper.lbr;
							ci.Details +=
								"    "
								+ SimPe
									.Localization.GetString("Check: Unable to locate")
									.Replace("{name}", test)
								+ Helper.lbr
								+ Helper.lbr;
							continue;
						}
					}
				}

				if (
					SimPe
						.PathProvider.Global.GetSaveGamePathForGroup(
							SimPe.PathProvider.Global.CurrentGroup
						)
						.Count > 0
				)
				{
					path = PathProvider.Global.GetSaveGamePathForGroup(
						SimPe.PathProvider.Global.CurrentGroup
					)[0];
				}
				else
				{
					path = PathProvider.SimSavegameFolder;
				}

				test = System.IO.Path.Combine(path, "Neighborhoods");
				if (!System.IO.Directory.Exists(test))
				{
					isok = CheckItemState.Fail;
					ci.Details +=
						SimPe
							.Localization.GetString("Check: Folder not found")
							.Replace(
								"{name}",
								SimPe.Localization.GetString("Savegames")
							) + Helper.lbr;
					ci.Details +=
						"    "
						+ SimPe
							.Localization.GetString("Check: Unable to locate")
							.Replace("{name}", test)
						+ Helper.lbr
						+ Helper.lbr;
				}

				if (isok == CheckItemState.Ok)
				{
					if (SimPe.PathProvider.Global.GameVersion < 16)
					{
						test = Data.MetaData.GMND_PACKAGE;
						if (!System.IO.File.Exists(test))
						{
							isok = CheckItemState.Warning;
							ci.Details +=
								SimPe.Localization.GetString("Check: CEP not found")
								+ Helper.lbr;
							ci.Details +=
								"    "
								+ SimPe
									.Localization.GetString("Check: Unable to locate")
									.Replace("{name}", test)
								+ Helper.lbr
								+ Helper.lbr;
						}
						test = Data.MetaData.MMAT_PACKAGE;
						if (!System.IO.File.Exists(test))
						{
							isok = CheckItemState.Warning;
							ci.Details +=
								SimPe.Localization.GetString("Check: CEP not found")
								+ Helper.lbr;
							ci.Details +=
								"    "
								+ SimPe
									.Localization.GetString("Check: Unable to locate")
									.Replace("{name}", test)
								+ Helper.lbr
								+ Helper.lbr;
						}
					}
					else if (SimPe.PathProvider.Global.GameVersion > 17)
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
								SimPe.Localization.GetString("Check: CEP is installed")
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
				System.Windows.Forms.MessageBox.Show(
					"You will need to re-save profile " + Helper.Profile,
					"Fix",
					System.Windows.Forms.MessageBoxButtons.OK,
					System.Windows.Forms.MessageBoxIcon.Warning
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
						SimPe.Localization.GetString("Check: Unable to load cache")
						+ Helper.lbr;
					ci.Details +=
						"    "
						+ SimPe
							.Localization.GetString("Check: Error while load")
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
			FileTable.FileIndex.Load();
			CheckItem ci = sender as CheckItem;
			try
			{
				Interfaces.Scenegraph.IScenegraphFileIndexItem[] items =
					FileTable.FileIndex.FindFile(Data.MetaData.OBJD_FILE, true);
				if (items.Length < 3000)
				{
					ci.Details +=
						SimPe.Localization.GetString("Check: No Objects") + Helper.lbr;
					isok = CheckItemState.Fail;
				}
				else
				{
					items = FileTable.FileIndex.FindFile(
						Data.MetaData.OBJD_FILE,
						0x7F94AFE8,
						0x000041AB,
						null
					); //Bed - Double - Loft - D
					if (items.Length == 0)
					{
						ci.Details +=
							SimPe.Localization.GetString("Check: No Objects")
							+ Helper.lbr;
						isok = CheckItemState.Fail;
					}
				}

				items = FileTable.FileIndex.FindFile(Data.MetaData.TXMT, true);
				if (items.Length < 100)
				{
					ci.Details +=
						SimPe.Localization.GetString("Check: No Textures") + Helper.lbr;
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
					System.Windows.Forms.MessageBox.Show(
						"The File table settings file was not correct and you have asked to fix it.\n"
							+ Helper.DataFolder.FoldersXREG
							+ "\n"
							+ "SimPe can generate a new one ("
							+ msg
							+ ").\n\n"
							+ "Should SimPe delete the File table settings File?",
						"Fix",
						System.Windows.Forms.MessageBoxButtons.YesNo,
						System.Windows.Forms.MessageBoxIcon.Question
					) == System.Windows.Forms.DialogResult.Yes
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
