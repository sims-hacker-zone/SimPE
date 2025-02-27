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
using System.Drawing;
using System.Windows.Forms;

using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for NeighborhoodForm.
	/// </summary>
	public class NeighborhoodForm : Form
	{
		private Ambertation.Windows.Forms.XPTaskBoxSimple pnBackup;
		private Ambertation.Windows.Forms.XPTaskBoxSimple pnOptions;
		private ListView lv;
		private ImageList ilist;
		private Button btnOpen;
		private Button button2;
		private Button button3;
		private ComboBox cbtypes;
		private Label label1;
		private System.ComponentModel.IContainer components;
		private Button btnClose;
		private Panel pnBoPeep;
		private PictureBox pbox;

		public NeighborhoodForm()
		{
			InitializeComponent();

			if (UserVerification.HaveUserId)
			{
				this.lv.ShowItemToolTips = true;
			}
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(
					typeof(NeighborhoodForm)
				);
			this.lv = new ListView();
			this.ilist = new ImageList(this.components);
			this.btnOpen = new Button();
			this.button2 = new Button();
			this.button3 = new Button();
			this.pnBackup = new Ambertation.Windows.Forms.XPTaskBoxSimple();
			this.pnOptions = new Ambertation.Windows.Forms.XPTaskBoxSimple();
			this.cbtypes = new ComboBox();
			this.label1 = new Label();
			this.btnClose = new Button();
			this.pnBoPeep = new Panel();
			this.pbox = new PictureBox();
			this.pnBackup.SuspendLayout();
			this.pnOptions.SuspendLayout();
			this.pnBoPeep.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbox)).BeginInit();
			this.SuspendLayout();
			//
			// lv
			//
			resources.ApplyResources(this.lv, "lv");
			this.lv.HideSelection = false;
			this.lv.LargeImageList = this.ilist;
			this.lv.MultiSelect = false;
			this.lv.Name = "lv";
			this.lv.UseCompatibleStateImageBehavior = false;
			this.lv.SelectedIndexChanged += new EventHandler(this.NgbSelect);
			this.lv.DoubleClick += new EventHandler(this.NgbOpen);
			//
			// ilist
			//
			this.ilist.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			resources.ApplyResources(this.ilist, "ilist");
			this.ilist.TransparentColor = System.Drawing.Color.Transparent;
			//
			// btnOpen
			//
			resources.ApplyResources(this.btnOpen, "btnOpen");
			this.btnOpen.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Click += new EventHandler(this.NgbOpen);
			//
			// button2
			//
			resources.ApplyResources(this.button2, "button2");
			this.button2.Name = "button2";
			this.button2.Click += new EventHandler(this.NgbBackup);
			//
			// button3
			//
			resources.ApplyResources(this.button3, "button3");
			this.button3.Name = "button3";
			this.button3.Click += new EventHandler(this.NgbRestoreBackup);
			//
			// pnBackup
			//
			resources.ApplyResources(this.pnBackup, "pnBackup");
			this.pnBackup.BackColor = System.Drawing.Color.Transparent;
			this.pnBackup.Controls.Add(this.pbox);
			this.pnBackup.Controls.Add(this.button3);
			this.pnBackup.Controls.Add(this.button2);
			this.pnBackup.HeaderFont = new Font(
				"Microsoft Sans Serif",
				10.25F,
				System.Drawing.FontStyle.Bold
			);
			this.pnBackup.IconLocation = new Point(4, 12);
			this.pnBackup.IconSize = new Size(32, 32);
			this.pnBackup.Name = "pnBackup";
			//
			// pnOptions
			//
			resources.ApplyResources(this.pnOptions, "pnOptions");
			this.pnOptions.BackColor = System.Drawing.Color.Transparent;
			this.pnOptions.Controls.Add(this.cbtypes);
			this.pnOptions.Controls.Add(this.label1);
			this.pnOptions.HeaderFont = new Font(
				"Microsoft Sans Serif",
				10.25F,
				System.Drawing.FontStyle.Bold
			);
			this.pnOptions.IconLocation = new Point(4, 12);
			this.pnOptions.IconSize = new Size(32, 32);
			this.pnOptions.Name = "pnOptions";
			//
			// cbtypes
			//
			this.cbtypes.FormattingEnabled = true;
			resources.ApplyResources(this.cbtypes, "cbtypes");
			this.cbtypes.Name = "cbtypes";
			this.cbtypes.SelectedIndexChanged += new EventHandler(
				this.cbtypes_SelectedIndexChanged
			);
			//
			// label1
			//
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			//
			// btnClose
			//
			resources.ApplyResources(this.btnClose, "btnClose");
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Name = "btnClose";
			//
			// pnBoPeep
			//
			this.pnBoPeep.BackColor = System.Drawing.Color.Transparent;
			this.pnBoPeep.Controls.Add(this.pnOptions);
			this.pnBoPeep.Controls.Add(this.btnClose);
			this.pnBoPeep.Controls.Add(this.btnOpen);
			this.pnBoPeep.Controls.Add(this.lv);
			this.pnBoPeep.Controls.Add(this.pnBackup);
			resources.ApplyResources(this.pnBoPeep, "pnBoPeep");
			this.pnBoPeep.Name = "pnBoPeep";
			//
			// pbox
			//
			resources.ApplyResources(this.pbox, "pbox");
			this.pbox.Name = "pbox";
			this.pbox.TabStop = false;
			//
			// NeighborhoodForm
			//
			this.AcceptButton = this.btnOpen;
			resources.ApplyResources(this, "$this");
			this.CancelButton = this.btnClose;
			this.Controls.Add(this.pnBoPeep);
			this.FormBorderStyle = System
				.Windows
				.Forms
				.FormBorderStyle
				.SizableToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NeighborhoodForm";
			this.pnBackup.ResumeLayout(false);
			this.pnOptions.ResumeLayout(false);
			this.pnOptions.PerformLayout();
			this.pnBoPeep.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbox)).EndInit();
			this.ResumeLayout(false);
		}
		#endregion


		public bool ShowSubHoods { get; set; } = true;

		public bool ShowBackupManager { get; set; } = true;

		public bool LoadNgbh { get; set; } = true;

		NgbhType ngbh = null;
		public string SelectedNgbh => ngbh == null ? null : ngbh.FileName;

		Packages.GeneratableFile package;
		Packages.File source_package;
		Interfaces.IProviderRegistry prov;
		bool changed;

		protected void AddImage(string path)
		{
			string name = System.IO.Path.Combine(
				System.IO.Path.GetDirectoryName(path),
				System.IO.Path.GetFileNameWithoutExtension(path) + ".png"
			);
			//name = System.IO.Path.Combine(path, name);
			if (System.IO.File.Exists(name))
			{
				try
				{
					System.IO.Stream st = System.IO.File.OpenRead(name);
					Image img = Image.FromStream(st);
					st.Close();
					st.Dispose();
					st = null;
					if (WaitingScreen.Running)
					{
						WaitingScreen.UpdateImage(
							ImageLoader.Preview(img, WaitingScreen.ImageSize)
						);
					}

					this.ilist.Images.Add(img);
					return;
				}
				catch (ArgumentException) { }
			}
			this.ilist.Images.Add(new Bitmap(SimPe.GetImage.Network));
		}

		protected void AddNeighborhood(ExpansionItem.NeighborhoodPath np, string path)
		{
			AddNeighborhood(np, path, "_Neighborhood.package");
			/*int i=1;
			while (AddNeighborhood(path, "_University"+Helper.MinStrLength(i.ToString(), 3)+".package"))
			{
				i++;
			}*/
		}

		protected string NeighborhoodIdentifier(string flname)
		{
			return System
				.IO.Path.GetFileNameWithoutExtension(flname)
				.Replace("_Neighborhood", "");
		}

		protected bool AddNeighborhood(
			ExpansionItem.NeighborhoodPath np,
			string path,
			string filename
		)
		{
			Application.DoEvents();
			string flname = System.IO.Path.Combine(
				System.IO.Path.GetDirectoryName(path),
				System.IO.Path.Combine(
					System.IO.Path.GetFileName(path),
					System.IO.Path.GetFileName(path) + filename
				)
			);
			if (!System.IO.File.Exists(flname))
			{
				return false;
			}

			AddImage(flname);
			flname = System.IO.Path.Combine(path, flname);
			string name = flname;
			string actime = "";
			bool ret = false;
			if (System.IO.File.Exists(name))
			{
				actime = " (" + System.IO.File.GetLastWriteTime(name).ToString() + ") ";
				actime += NeighborhoodIdentifier(flname);
				ret = true;
				try
				{
					Packages.File pk = SimPe.Packages.File.LoadFromFile(name);
					NeighborhoodType t;
					name = LoadLabel(pk, out t);
				}
				catch (Exception) { }
			}

			ListViewItem lvi = new ListViewItem();
			lvi.Text = name + actime;
			if (np.Lable != "")
			{
				lvi.Text = np.Lable + ": " + lvi.Text;
			}

			lvi.ImageIndex = ilist.Images.Count - 1;
			lvi.SubItems.Add(flname);
			lvi.SubItems.Add(name);
			lvi.SubItems.Add(np.Lable);
			if (UserVerification.HaveUserId)
			{
				lvi.ToolTipText = flname;
			}

			lv.Items.Add(lvi);

			return ret;
		}

		private static string LoadLabel(
			Packages.File pk,
			out NeighborhoodType type
		)
		{
			string name = SimPe.Localization.GetString("Unknown");
			type = NeighborhoodType.Normal;
			try
			{
				Interfaces.Files.IPackedFileDescriptor pfd = pk.FindFile(
					0x43545353,
					0,
					0xffffffff,
					1
				);
				if (pfd != null)
				{
					PackedFiles.Wrapper.Str str =
						new PackedFiles.Wrapper.Str();
					str.ProcessData(pfd, pk);
					name = str.FallbackedLanguageItem(
						Helper.WindowsRegistry.LanguageCode,
						0
					).Title;
				}
				else if (pk.FileName.Contains("Tutorial"))
				{
					name = "Tutorial"; // CJH
				}

				pfd = pk.FindFile(0xAC8A7A2E, 0, 0xffffffff, 1);
				if (pfd != null)
				{
					Idno idno = new Idno();
					idno.ProcessData(pfd, pk);
					type = idno.Type;
				}
				else if (pk.FileName.Contains("Tutorial"))
				{
					type = NeighborhoodType.Unknown;
				}
				//pk.Reader.Close();
			}
			finally
			{
				//pk.Reader.Close();
			}
			return name;
		}

		protected void UpdateList()
		{
			WaitingScreen.Wait();
			Application.DoEvents();

			try
			{
				lv.Items.Clear();
				ilist.Images.Clear();

				ExpansionItem.NeighborhoodPaths paths =
					PathProvider.Global.GetNeighborhoodsForGroup(
						PathProvider.Global.CurrentGroup
					);
				foreach (ExpansionItem.NeighborhoodPath path in paths)
				{
					string sourcepath = path.Path;
					// string[] dirs = System.IO.Directory.GetDirectories(sourcepath, "????");
					string[] dirs = System.IO.Directory.GetDirectories(sourcepath, "*"); // CJH - removes the 4 char limit
					foreach (string dir in dirs)
					{
						if (!dir.Contains("Tutorial"))
						{
							AddNeighborhood(path, dir);
						}
					}
				}
				if (Helper.WindowsRegistry.LoadAllNeighbourhoods && LoadNgbh)
				{
					if (
						PathProvider
							.Global.GetExpansion(SimPe.Expansions.IslandStories)
							.Exists
					)
					{
						paths = PathProvider.Global.GetNeighborhoodsForGroup(8);
						foreach (ExpansionItem.NeighborhoodPath path in paths)
						{
							string sourcepath = path.Path;
							string[] dirs = System.IO.Directory.GetDirectories(
								sourcepath,
								"*"
							);
							foreach (string dir in dirs)
							{
								if (!dir.Contains("Tutorial"))
								{
									AddNeighborhood(path, dir);
								}
							}
						}
					}
					if (
						PathProvider
							.Global.GetExpansion(SimPe.Expansions.PetStories)
							.Exists
					)
					{
						paths = PathProvider.Global.GetNeighborhoodsForGroup(4);
						foreach (ExpansionItem.NeighborhoodPath path in paths)
						{
							string sourcepath = path.Path;
							string[] dirs = System.IO.Directory.GetDirectories(
								sourcepath,
								"*"
							);
							foreach (string dir in dirs)
							{
								if (!dir.Contains("Tutorial"))
								{
									AddNeighborhood(path, dir);
								}
							}
						}
					}
					if (
						PathProvider
							.Global.GetExpansion(SimPe.Expansions.LifeStories)
							.Exists
					)
					{
						paths = PathProvider.Global.GetNeighborhoodsForGroup(2);
						foreach (ExpansionItem.NeighborhoodPath path in paths)
						{
							string sourcepath = path.Path;
							string[] dirs = System.IO.Directory.GetDirectories(
								sourcepath,
								"*"
							);
							foreach (string dir in dirs)
							{
								if (!dir.Contains("Tutorial"))
								{
									AddNeighborhood(path, dir);
								}
							}
						}
					}
				}
			}
			finally
			{
				WaitingScreen.UpdateImage(null);
				WaitingScreen.Stop(this);
			}
		}

		public IToolResult Execute(
			ref Interfaces.Files.IPackageFile package,
			Interfaces.IProviderRegistry prov
		)
		{
			this.Cursor = Cursors.WaitCursor;
			this.package = null;
			this.prov = prov;
			source_package = (Packages.File)package;
			changed = false;
			UpdateList();
			this.Cursor = Cursors.Default;
			pnBackup.Visible = ShowBackupManager;
			pnOptions.Visible = ShowSubHoods;
			RemoteControl.ShowSubForm(this);
			if (this.package != null)
			{
				package = this.package;
			}

			return new ToolResult(false, ((this.package != null) || (changed)));
		}

		class NgbhType
		{
			string name;
			NeighborhoodType type;

			public string FileName
			{
				get;
			}

			public NgbhType(string file, string name, NeighborhoodType type)
			{
				this.name = name;
				this.type = type;
				this.FileName = file;
			}

			public override string ToString()
			{
				return type.ToString() + ": " + name;
			}
		}

		private void NgbSelect(object sender, EventArgs e)
		{
			//button1.Enabled = (lv.SelectedItems.Count>0);
			button2.Enabled = (lv.SelectedItems.Count > 0);
			button3.Enabled = button2.Enabled;

			cbtypes.Items.Clear();
			if (lv.SelectedItems.Count > 0)
			{
				string path = System.IO.Path.GetDirectoryName(
					lv.SelectedItems[0].SubItems[1].Text
				);
				string[] files = System.IO.Directory.GetFiles(path, "*.package");

				foreach (string file in files)
				{
					Packages.File pk = SimPe.Packages.File.LoadFromFile(file);
					NeighborhoodType type;
					string name = LoadLabel(pk, out type);
					NgbhType nt = new NgbhType(file, name, type);

					cbtypes.Items.Add(nt);
					if (
						Helper.EqualFileName(file, lv.SelectedItems[0].SubItems[1].Text)
					)
					{
						cbtypes.SelectedIndex = cbtypes.Items.Count - 1;
					}
				}
				if (cbtypes.SelectedIndex < 0 && cbtypes.Items.Count > 0)
				{
					cbtypes.SelectedIndex = 0;
				}
			}
			SetSmilyIcon("none");
		}

		private void NgbOpen(object sender, EventArgs e)
		{
			if (lv.SelectedItems.Count <= 0)
			{
				return;
			}

			ngbh = cbtypes.SelectedItem as NgbhType;
			if (ngbh != null)
			{
				if (LoadNgbh)
				{
					package = SimPe.Packages.GeneratableFile.LoadFromFile(
						ngbh.FileName
					);
				}

				this.DialogResult = DialogResult.OK;
				Close();
			}
		}

		protected void CloseIfOpened(string path)
		{
			if (source_package != null)
			{
				if (
					source_package
						.SaveFileName.Trim()
						.ToLower()
						.StartsWith(path.ToLower())
				)
				{
					if (source_package.Reader != null)
					{
						changed = true;
						//source_package.Reader.Close();
					}
				}
			}
		}

		private void NgbBackup(object sender, EventArgs e)
		{
			if (lv.SelectedItems.Count <= 0)
			{
				return;
			}

			SimPe.Packages.StreamFactory.CloseAll();
			string path = System
				.IO.Path.GetDirectoryName(lv.SelectedItems[0].SubItems[1].Text)
				.Trim();
			string lable = lv.SelectedItems[0].SubItems[3].Text;

			//if a File in the current Neighborhood is opened - close it!
			CloseIfOpened(path);
			try
			{
				//create a Backup Folder
				string name = System.IO.Path.GetFileName(path);
				if (lable != "")
				{
					name = lable + "_" + name;
				}

				long grp = PathProvider.Global.SaveGamePathProvidedByGroup(path);
				if (grp > 1)
				{
					name = grp.ToString() + "_" + name;
				}

				string backuppath = System.IO.Path.Combine(
					PathProvider.Global.BackupFolder,
					name
				);
				string subname = DateTime.Now.ToString();
				backuppath = System.IO.Path.Combine(
					backuppath,
					subname.Replace("\\", "-").Replace("/", "-").Replace(":", "-")
				);
				if (!System.IO.Directory.Exists(backuppath))
				{
					System.IO.Directory.CreateDirectory(backuppath);
				}

				Helper.CopyDirectory(path, backuppath, true);
				SetSmilyIcon("happy");
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
				SetSmilyIcon("sad");
			}
		}

		private void NgbRestoreBackup(object sender, EventArgs e)
		{
			if (lv.SelectedItems.Count <= 0)
			{
				return;
			}

			string path = System
				.IO.Path.GetDirectoryName(lv.SelectedItems[0].SubItems[1].Text)
				.Trim();

			//if a File in the current Neighborhood is opened - close it!
			CloseIfOpened(path);

			NgbBackup nb = new NgbBackup();
			nb.Text += " (";
			if (lv.SelectedItems[0].SubItems[3].Text != "")
			{
				nb.Text += lv.SelectedItems[0].SubItems[3].Text + ": ";
			}

			nb.Text += lv.SelectedItems[0].SubItems[2].Text.Trim() + ")";
			if (UserVerification.HaveUserId)
			{
				nb.Text += " " + NeighborhoodIdentifier(path);
			}

			nb.Execute(path, package, prov, lv.SelectedItems[0].SubItems[3].Text);
			UpdateList();
			SetSmilyIcon("none");
		}

		private void cbtypes_SelectedIndexChanged(object sender, EventArgs e)
		{
			btnOpen.Enabled = cbtypes.SelectedItem != null;
			if (cbtypes.SelectedItem != null && ShowSubHoods)
			{
				ngbh = cbtypes.SelectedItem as NgbhType;
				if (ngbh != null)
				{
					string name = System.IO.Path.Combine(
						System.IO.Path.GetDirectoryName(ngbh.FileName),
						System.IO.Path.GetFileNameWithoutExtension(ngbh.FileName)
							+ ".png"
					);
					if (
						System.IO.File.Exists(name)
						&& !Helper.EqualFileName(
							ngbh.FileName,
							lv.SelectedItems[0].SubItems[1].Text
						)
					)
					{
						try
						{
							System.IO.Stream st = System.IO.File.OpenRead(name);
							Image img = Image.FromStream(st);
							st.Close();
							st.Dispose();
							st = null;
							this.pnBoPeep.BackgroundImage = img;
							return;
						}
						catch { }
					}
					this.pnBoPeep.BackgroundImage = null;
				}
			}
			else if (ShowSubHoods)
			{
				this.pnBoPeep.BackgroundImage = null;
			}
		}

		private void SetSmilyIcon(string hapy)
		{
			uint inst = 0xABBA2585;
			if (hapy == "none")
			{
				pbox.Image = null;
				return;
			}
			else if (hapy == "happy")
			{
				inst = 0xABBA2575;
			}
			else if (hapy == "sad")
			{
				inst = 0xABBA2591;
			}
			/*
if (pbpay.Value == 1) inst = 0xABBA2595;
if (pbpay.Value == 2) inst = 0xABBA2591;
if (pbpay.Value == 3) inst = 0xABBA2588;
if (pbpay.Value == 4) inst = 0xABBA2585;
if (pbpay.Value == 5) inst = 0xABBA2582;
if (pbpay.Value == 6) inst = 0xABBA2578;
if (pbpay.Value == 7) inst = 0xABBA2575;
*/
			Packages.File pkg = SimPe.Packages.File.LoadFromFile(
				System.IO.Path.Combine(
					PathProvider.Global.Latest.InstallFolder,
					"TSData\\Res\\UI\\ui.package"
				)
			);
			if (pkg != null)
			{
				Interfaces.Files.IPackedFileDescriptor pfd = pkg.FindFile(
					0x856DDBAC,
					0,
					0x499DB772,
					inst
				);
				if (pfd != null)
				{
					PackedFiles.Wrapper.Picture pic =
						new PackedFiles.Wrapper.Picture();
					pic.ProcessData(pfd, pkg);
					pbox.Image = pic.Image;
				}
				else
				{
					pbox.Image = null;
				}
			}
			else
			{
				pbox.Image = null;
			}
		}
	}
}
