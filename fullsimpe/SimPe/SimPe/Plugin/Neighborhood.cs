// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Drawing;
using System.Windows.Forms;

using SimPe.Data;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Idno;

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
				lv.ShowItemToolTips = true;
			}
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(
					typeof(NeighborhoodForm)
				);
			lv = new ListView();
			ilist = new ImageList(components);
			btnOpen = new Button();
			button2 = new Button();
			button3 = new Button();
			pnBackup = new Ambertation.Windows.Forms.XPTaskBoxSimple();
			pnOptions = new Ambertation.Windows.Forms.XPTaskBoxSimple();
			cbtypes = new ComboBox();
			label1 = new Label();
			btnClose = new Button();
			pnBoPeep = new Panel();
			pbox = new PictureBox();
			pnBackup.SuspendLayout();
			pnOptions.SuspendLayout();
			pnBoPeep.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pbox).BeginInit();
			SuspendLayout();
			//
			// lv
			//
			resources.ApplyResources(lv, "lv");
			lv.HideSelection = false;
			lv.LargeImageList = ilist;
			lv.MultiSelect = false;
			lv.Name = "lv";
			lv.UseCompatibleStateImageBehavior = false;
			lv.SelectedIndexChanged += new EventHandler(NgbSelect);
			lv.DoubleClick += new EventHandler(NgbOpen);
			//
			// ilist
			//
			ilist.ColorDepth = ColorDepth.Depth32Bit;
			resources.ApplyResources(ilist, "ilist");
			ilist.TransparentColor = Color.Transparent;
			//
			// btnOpen
			//
			resources.ApplyResources(btnOpen, "btnOpen");
			btnOpen.DialogResult = DialogResult.OK;
			btnOpen.Name = "btnOpen";
			btnOpen.Click += new EventHandler(NgbOpen);
			//
			// button2
			//
			resources.ApplyResources(button2, "button2");
			button2.Name = "button2";
			button2.Click += new EventHandler(NgbBackup);
			//
			// button3
			//
			resources.ApplyResources(button3, "button3");
			button3.Name = "button3";
			button3.Click += new EventHandler(NgbRestoreBackup);
			//
			// pnBackup
			//
			resources.ApplyResources(pnBackup, "pnBackup");
			pnBackup.BackColor = Color.Transparent;
			pnBackup.Controls.Add(pbox);
			pnBackup.Controls.Add(button3);
			pnBackup.Controls.Add(button2);
			pnBackup.HeaderFont = new Font(
				"Microsoft Sans Serif",
				10.25F,
				FontStyle.Bold
			);
			pnBackup.IconLocation = new Point(4, 12);
			pnBackup.IconSize = new Size(32, 32);
			pnBackup.Name = "pnBackup";
			//
			// pnOptions
			//
			resources.ApplyResources(pnOptions, "pnOptions");
			pnOptions.BackColor = Color.Transparent;
			pnOptions.Controls.Add(cbtypes);
			pnOptions.Controls.Add(label1);
			pnOptions.HeaderFont = new Font(
				"Microsoft Sans Serif",
				10.25F,
				FontStyle.Bold
			);
			pnOptions.IconLocation = new Point(4, 12);
			pnOptions.IconSize = new Size(32, 32);
			pnOptions.Name = "pnOptions";
			//
			// cbtypes
			//
			cbtypes.FormattingEnabled = true;
			resources.ApplyResources(cbtypes, "cbtypes");
			cbtypes.Name = "cbtypes";
			cbtypes.SelectedIndexChanged += new EventHandler(
				cbtypes_SelectedIndexChanged
			);
			//
			// label1
			//
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			//
			// btnClose
			//
			resources.ApplyResources(btnClose, "btnClose");
			btnClose.DialogResult = DialogResult.Cancel;
			btnClose.Name = "btnClose";
			//
			// pnBoPeep
			//
			pnBoPeep.BackColor = Color.Transparent;
			pnBoPeep.Controls.Add(pnOptions);
			pnBoPeep.Controls.Add(btnClose);
			pnBoPeep.Controls.Add(btnOpen);
			pnBoPeep.Controls.Add(lv);
			pnBoPeep.Controls.Add(pnBackup);
			resources.ApplyResources(pnBoPeep, "pnBoPeep");
			pnBoPeep.Name = "pnBoPeep";
			//
			// pbox
			//
			resources.ApplyResources(pbox, "pbox");
			pbox.Name = "pbox";
			pbox.TabStop = false;
			//
			// NeighborhoodForm
			//
			AcceptButton = btnOpen;
			resources.ApplyResources(this, "$this");
			CancelButton = btnClose;
			Controls.Add(pnBoPeep);
			FormBorderStyle =
				FormBorderStyle
				.SizableToolWindow;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "NeighborhoodForm";
			pnBackup.ResumeLayout(false);
			pnOptions.ResumeLayout(false);
			pnOptions.PerformLayout();
			pnBoPeep.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pbox).EndInit();
			ResumeLayout(false);
		}
		#endregion


		public bool ShowSubHoods { get; set; } = true;

		public bool ShowBackupManager { get; set; } = true;

		public bool LoadNgbh { get; set; } = true;

		NgbhType ngbh = null;
		public string SelectedNgbh => ngbh?.FileName;

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

					ilist.Images.Add(img);
					return;
				}
				catch (ArgumentException) { }
			}
			ilist.Images.Add(new Bitmap(GetImage.Network));
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
					Packages.File pk = Packages.File.LoadFromFile(name);
					name = LoadLabel(pk, out NeighborhoodType t);
				}
				catch (Exception) { }
			}

			ListViewItem lvi = new ListViewItem
			{
				Text = name + actime
			};
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
			string name = Localization.GetString("Unknown");
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
							.Global.GetExpansion(Expansions.IslandStories)
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
							.Global.GetExpansion(Expansions.PetStories)
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
							.Global.GetExpansion(Expansions.LifeStories)
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
			Cursor = Cursors.WaitCursor;
			this.package = null;
			this.prov = prov;
			source_package = (Packages.File)package;
			changed = false;
			UpdateList();
			Cursor = Cursors.Default;
			pnBackup.Visible = ShowBackupManager;
			pnOptions.Visible = ShowSubHoods;
			RemoteControl.ShowSubForm(this);
			if (this.package != null)
			{
				package = this.package;
			}

			return new ToolResult(false, (this.package != null) || changed);
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
				FileName = file;
			}

			public override string ToString()
			{
				return type.ToString() + ": " + name;
			}
		}

		private void NgbSelect(object sender, EventArgs e)
		{
			//button1.Enabled = (lv.SelectedItems.Count>0);
			button2.Enabled = lv.SelectedItems.Count > 0;
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
					Packages.File pk = Packages.File.LoadFromFile(file);
					string name = LoadLabel(pk, out NeighborhoodType type);
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
					package = Packages.File.LoadFromFile(
						ngbh.FileName
					);
				}

				DialogResult = DialogResult.OK;
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

			Packages.StreamFactory.CloseAll();
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
							pnBoPeep.BackgroundImage = img;
							return;
						}
						catch { }
					}
					pnBoPeep.BackgroundImage = null;
				}
			}
			else if (ShowSubHoods)
			{
				pnBoPeep.BackgroundImage = null;
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
			Packages.File pkg = Packages.File.LoadFromFile(
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
