// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using SimPe.Data;
using SimPe.Interfaces;
using SimPe.PackedFiles.Cpf;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for SkinWorkshop.
	/// </summary>
	public class SkinWorkshop : Form
	{
		private OpenFileDialog ofd;
		private CheckBox cbfix;
		private System.ComponentModel.IContainer components;
		private Panel panel1;
		private GroupBox taskBox2;
		private GroupBox taskBox1;
		private ListBox lbobj;
		private Button btclone;
		private CheckBox cbgid;
		private SaveFileDialog sfd;
		private TextBox tbseek;
		private PictureBox pb;

		Packages.GeneratableFile package;
		Interfaces.Files.IPackageFile simpe_pkg;

		public SkinWorkshop()
		{
			InitializeComponent();
			btclone.Enabled = false;
			btclone.Refresh();
			lbobj.SelectionMode = SelectionMode.One;
		}

		#region Cache Handling
		Cache.Cache cachefile => Cache.Cache.GlobalCache;
		bool cachechg;

		/// <summary>
		/// Get the Name of the Object Cache File
		/// </summary>
		string CacheFileName => Helper.SimPeLanguageCache;

		/// <summary>
		/// Load the Object Cache
		/// </summary>
		void LoadCachIndex()
		{
			cachechg = false;

			if (!Helper.WindowsRegistry.UseCache)
			{
				return;
			}

			if (WaitingScreen.Running)
			{
				WaitingScreen.UpdateMessage("Loading Cache");
			}

			cachefile.LoadObjects();
		}

		/// <summary>
		/// Save the Cache to the Disk
		/// </summary>
		void SaveCacheIndex()
		{
			if (!Helper.WindowsRegistry.UseCache)
			{
				return;
			}

			if (!cachechg)
			{
				return;
			}

			if (WaitingScreen.Running)
			{
				WaitingScreen.UpdateMessage("Saving Cache");
			}

			cachefile.Save();
		}
		#endregion

		void BuildListing(FileTypes type)
		{
			//build Object List
			if (lbobj.Items.Count == 0)
			{
				WaitingScreen.Wait();
				try
				{
					LoadCachIndex();
					lbobj.BeginUpdate();
					lbobj.Items.Clear();
					lbobj.Sorted = false;
					FileTableBase.FileIndex.Load();
					WaitingScreen.UpdateMessage("Loading Items");
					foreach (
						Interfaces.Scenegraph.IScenegraphFileIndexItem nrefitem in FileTableBase.FileIndex.Sort(
							FileTableBase.FileIndex.FindFile(type, true)
						)
					)
					{
						if (nrefitem.LocalGroup != MetaData.LOCAL_GROUP)
						{
							Interfaces.Scenegraph.IScenegraphFileIndexItem citem =
								(from item in cachefile.ObjectCacheFileIndex.FindFile(
									nrefitem.FileDescriptor,
									nrefitem.Package
								)
								 where nrefitem.Package.FileName.Trim().ToLower() == item.FileDescriptor.Filename.Trim().ToLower()
								 select item).FirstOrDefault();
							if (citem != null) //found in the cache
							{
								Cache.ObjectCacheItem oci =
									(Cache.ObjectCacheItem)
										citem.FileDescriptor.Tag;
								if (oci.Name.Length >= 3 && oci.Useable)
								{
									lbobj.Items.Add(new Alias(
										oci.FileDescriptor.Instance,
										oci.Name
									)
									{
										Tag = (new object[3] { nrefitem.FileDescriptor, nrefitem.LocalGroup, nrefitem.FileDescriptor.Instance }),
										Name = Helper.WindowsRegistry.ShowObjdNames ? oci.ObjectFileName : oci.Name
									});
								}
							}
							else //not found in cache
							{
								try
								{
									Cpf cpf =
										new Cpf();
									nrefitem.FileDescriptor.UserData = nrefitem
										.Package.Read(nrefitem.FileDescriptor)
										.UncompressedData;
									cpf.ProcessData(nrefitem);
									if (cpf.GetItem("name").StringValue.Length < 3)
									{
										continue;
									}

									Alias a = new Alias(
										nrefitem.FileDescriptor.Instance,
										cpf.GetItem("name").StringValue
									)
									{
										Name = cpf.GetItem("name").StringValue,
										Tag = (new object[3] { nrefitem.FileDescriptor, nrefitem.LocalGroup, nrefitem.FileDescriptor.Instance })
									};

									cachechg = true;

									cachefile.AddObjectItem(new Cache.ObjectCacheItem
									{
										FileDescriptor = nrefitem.FileDescriptor,
										LocalGroup = nrefitem.LocalGroup,
										ObjectType = ObjectTypes.Outfit,
										ObjectFileName = cpf.GetItem("name").StringValue,
										Useable = true,
										Class = Cache.ObjectClass.Skin,
										Name = a.Name,
										ModelName = "",
										Thumbnail = null
									}, nrefitem.Package.FileName);
									lbobj.Items.Add(a);
								}
								catch { }
							} // if not in cache
						}
					} //foreach txt

					SaveCacheIndex();
					WaitingScreen.UpdateMessage("Sorting Items");
					lbobj.Sorted = true;
					lbobj.EndUpdate();
				}
				finally
				{
					WaitingScreen.Stop(this);
				}
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
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(
					typeof(SkinWorkshop)
				);
			lbobj = new ListBox();
			btclone = new Button();
			pb = new PictureBox();
			cbfix = new CheckBox();
			cbgid = new CheckBox();
			sfd = new SaveFileDialog();
			tbseek = new TextBox();
			ofd = new OpenFileDialog();
			panel1 = new Panel();
			taskBox2 = new GroupBox();
			taskBox1 = new GroupBox();
			((System.ComponentModel.ISupportInitialize)pb).BeginInit();
			panel1.SuspendLayout();
			taskBox2.SuspendLayout();
			taskBox1.SuspendLayout();
			SuspendLayout();
			//
			// lbobj
			//
			lbobj.Anchor =




								AnchorStyles.Top
								| AnchorStyles.Bottom
							 | AnchorStyles.Left
						 | AnchorStyles.Right


			;
			lbobj.IntegralHeight = false;
			lbobj.ItemHeight = 16;
			lbobj.Location = new Point(6, 71);
			lbobj.Name = "lbobj";
			lbobj.SelectionMode = SelectionMode.MultiExtended;
			lbobj.Size = new Size(485, 248);
			lbobj.TabIndex = 0;
			lbobj.SelectedIndexChanged += new EventHandler(Select);
			//
			// btclone
			//
			btclone.Anchor =


						AnchorStyles.Bottom
						| AnchorStyles.Right


			;
			btclone.FlatStyle = FlatStyle.System;
			btclone.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			btclone.Location = new Point(400, 141);
			btclone.Name = "btclone";
			btclone.Size = new Size(75, 23);
			btclone.TabIndex = 1;
			btclone.Text = "Start";
			btclone.Click += new EventHandler(Start);
			//
			// pb
			//
			pb.BackColor = Color.Transparent;
			pb.BorderStyle = BorderStyle.FixedSingle;
			pb.Location = new Point(7, 40);
			pb.Name = "pb";
			pb.Size = new Size(128, 128);
			pb.SizeMode = PictureBoxSizeMode.StretchImage;
			pb.TabIndex = 6;
			pb.TabStop = false;
			//
			// cbfix
			//
			cbfix.FlatStyle = FlatStyle.System;
			cbfix.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			cbfix.Location = new Point(152, 77);
			cbfix.Name = "cbfix";
			cbfix.Size = new Size(224, 24);
			cbfix.TabIndex = 5;
			cbfix.Text = "Fix Cloned Files (sug. by.  wes_h)";
			//
			// cbgid
			//
			cbgid.FlatStyle = FlatStyle.System;
			cbgid.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			cbgid.Location = new Point(152, 47);
			cbgid.Name = "cbgid";
			cbgid.Size = new Size(248, 24);
			cbgid.TabIndex = 2;
			cbgid.Text = "Set Custom Group ID (0x1c050000)";
			//
			// sfd
			//
			sfd.Filter = "Package File (*.package)|*.package|All Files (*.*)|*.*";
			sfd.Title = "Alternative Colour Pacakge";
			//
			// tbseek
			//
			tbseek.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Left
						 | AnchorStyles.Right


			;
			tbseek.Location = new Point(6, 44);
			tbseek.Name = "tbseek";
			tbseek.Size = new Size(485, 23);
			tbseek.TabIndex = 3;
			tbseek.TextChanged += new EventHandler(SeekItem);
			//
			// ofd
			//
			ofd.Filter = "Package File (*.package)|*.package|All Files (*.*)|*.*";
			//
			// panel1
			//
			panel1.BackColor = Color.Transparent;
			panel1.Controls.Add(taskBox2);
			panel1.Controls.Add(taskBox1);
			panel1.Dock = DockStyle.Fill;
			panel1.Font = new Font(
				"Verdana",
				9.75F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			panel1.Location = new Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new Size(504, 518);
			panel1.TabIndex = 5;
			//
			// taskBox2
			//
			taskBox2.Anchor =


						AnchorStyles.Bottom
						| AnchorStyles.Left


			;
			taskBox2.BackColor = Color.Transparent;
			taskBox2.Controls.Add(cbfix);
			taskBox2.Controls.Add(btclone);
			taskBox2.Controls.Add(pb);
			taskBox2.Controls.Add(cbgid);
			taskBox2.Location = new Point(3, 340);
			taskBox2.Name = "taskBox2";
			taskBox2.Padding = new Padding(4, 44, 4, 4);
			taskBox2.Size = new Size(498, 175);
			taskBox2.TabIndex = 6;
			//
			// taskBox1
			//
			taskBox1.Anchor =




								AnchorStyles.Top
								| AnchorStyles.Bottom
							 | AnchorStyles.Left
						 | AnchorStyles.Right


			;
			taskBox1.BackColor = Color.Transparent;
			taskBox1.Controls.Add(tbseek);
			taskBox1.Controls.Add(lbobj);
			taskBox1.Location = new Point(3, 3);
			taskBox1.Name = "taskBox1";
			taskBox1.Padding = new Padding(4, 44, 4, 4);
			taskBox1.Size = new Size(498, 326);
			taskBox1.TabIndex = 5;
			//
			// SkinWorkshop
			//
			AutoScaleBaseSize = new Size(7, 16);
			ClientSize = new Size(504, 518);
			Controls.Add(panel1);
			Font = new Font(
				"Verdana",
				9.75F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			FormBorderStyle =
				FormBorderStyle
				.SizableToolWindow;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MinimumSize = new Size(520, 320);
			Name = "SkinWorkshop";
			Opacity = 0.96;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Skin Workshop (biggest thanks to RGiles and Numenor)";
			((System.ComponentModel.ISupportInitialize)pb).EndInit();
			panel1.ResumeLayout(false);
			taskBox2.ResumeLayout(false);
			taskBox1.ResumeLayout(false);
			taskBox1.PerformLayout();
			ResumeLayout(false);
		}
		#endregion
		public Interfaces.Files.IPackageFile Execute(
			Interfaces.Files.IPackageFile simpe_pkg
		)
		{
			this.simpe_pkg = simpe_pkg;

			// WaitingScreen.Wait();
			FileTableBase.FileIndex.Load();
			package = null;

			BuildListing();
			RemoteControl.ShowSubForm(this);

			WaitingScreen.Stop(this);
			return package;
		}

		void BuildListing()
		{
			BuildListing(FileTypes.GZPS);
		}

		private void Select(object sender, EventArgs e) // Fuck
		{
			if (tbseek.Tag != null)
			{
				return;
			}

			btclone.Enabled = false;
			btclone.Refresh();
			if (lbobj.SelectedIndex < 0)
			{
				return;
			}

			btclone.Enabled = true;
			btclone.Refresh();

			IAlias a = (IAlias)lbobj.Items[lbobj.SelectedIndex];
			tbseek.Tag = true;
			if (sender != null)
			{
				tbseek.Text = a.Name;
			}

			tbseek.Tag = null;
			// pb.Image = GetFumbnail((uint)a.Tag[1], 0, (uint)a.Tag[2]);
		}

		private void Start(object sender, EventArgs e)
		{
			try
			{
				Cursor = Cursors.WaitCursor;
				IAlias a = new Alias(0, "");
				Interfaces.Files.IPackedFileDescriptor pfd = null;
				uint localgroup = MetaData.LOCAL_GROUP;

				if (lbobj.SelectedIndex >= 0)
				{
					a = (IAlias)lbobj.Items[lbobj.SelectedIndex];
					pfd = (Interfaces.Files.IPackedFileDescriptor)a.Tag[0];
					localgroup = (uint)a.Tag[1];
				}

				WaitingScreen.Wait();
				try
				{
					RecolorClone(pfd, localgroup, false, false, false);
				}
				finally
				{
					WaitingScreen.Stop(this);
				}

				FixObject fo = new FixObject(package, FixVersion.UniversityReady, true);
				Hashtable map = null;

				if (cbfix.Checked)
				{
					map = fo.GetNameMap(true);
					if (map == null)
					{
						return;
					}

					if (sfd.ShowDialog() == DialogResult.OK)
					{
						WaitingScreen.Wait();
						try
						{
							package.FileName = sfd.FileName;
							fo.Fix(map, true);
							package.Save();
						}
						finally
						{
							WaitingScreen.Stop(this);
						}
					}
					else
					{
						package = null;
					}
				}

				if (cbgid.Checked && (package != null))
				{
					WaitingScreen.Wait();
					try
					{
						fo.FixGroup();
						if (cbfix.Checked)
						{
							package.Save();
						}
					}
					finally
					{
						WaitingScreen.Stop(this);
					}
				}
				Close();
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				WaitingScreen.Stop(this);
				Cursor = Cursors.Default;
			}
		}

		#region Thumbnails
		// Not used, I can't resolve FumbnailHash yet
		/*
		public static Image GetFumbnail(uint group, uint instahi, uint instans)
		{
			uint inst = FumbnailHash(group, instahi, instans);

			Interfaces.Files.IPackedFileDescriptor pfd = fumbs.FindFile(FileTypes.JPG, instans, 0xFFFFFFFF, inst);
			if (pfd!=null)
			{
				try
				{
					SimPe.PackedFiles.Wrapper.Picture pic = new SimPe.PackedFiles.Wrapper.Picture();
					pic.ProcessData(pfd, fumbs);
					return pic.Image;
				}
				catch (Exception) { }
			}
			return null;
		}

		public static uint FumbnailHash(uint group, uint instahi, uint instans)
		{
			string name = group.ToString() + instahi.ToString() + instans.ToString();
			return (uint)Hashes.ToLong(Hashes.Crc32.ComputeHash(Helper.ToBytes(name.Trim().ToLower())));
		}

		static SimPe.Packages.File fumbs = SimPe.Packages.File.LoadFromFile(System.IO.Path.Combine(PathProvider.SimSavegameFolder, "Thumbnails\\CASThumbnails.package"));
		*/

		/*
		/// <summary>
		/// Returns the Instance Number for the assigned Thumbnail
		/// </summary>
		/// <param name="group">The Group of the Object</param>
		/// <param name="modelname">The Name of teh Model (inst 0x86)</param>
		/// <returns>Instance of the Thumbnail</returns>
		public static uint ThumbnailHash(uint group, string modelname)
		{
			string name = group.ToString()+modelname;
			return (uint)Hashes.ToLong(Hashes.Crc32.ComputeHash(Helper.ToBytes(name.Trim().ToLower())));
		}

		static SimPe.Packages.File thumbs = null;

		/// <summary>
		/// Returns the Thumbnail of an Object
		/// </summary>
		/// <param name="group"></param>
		/// <param name="modelname"></param>
		/// <returns>The Thumbnail</returns>
		public static Image GetThumbnail(uint group, string modelname)
		{
			return GetThumbnail(group, modelname, null);
		}
		/// <summary>
		/// Returns the Thumbnail of an Object
		/// </summary>
		/// <param name="group"></param>
		/// <param name="modelname"></param>
		/// <returns>The Thumbnail</returns>
		public static Image GetThumbnail(uint group, string modelname, string message)
		{
			uint inst = ThumbnailHash(group, modelname);
			if (thumbs==null)
			{
				thumbs = SimPe.Packages.File.LoadFromFile(System.IO.Path.Combine(PathProvider.SimSavegameFolder, "Thumbnails\\CASThumbnails.package"));
				thumbs.Persistent = true;
			}

			//0x6C2A22C3 FileTypes.JPG
			Interfaces.Files.IPackedFileDescriptor[] pfds = thumbs.FindFile(FileTypes.JPG, 0, inst);
			if (pfds.Length>0)
			{
				Interfaces.Files.IPackedFileDescriptor pfd = pfds[0];
				try
				{
					SimPe.PackedFiles.Wrapper.Picture pic = new SimPe.PackedFiles.Wrapper.Picture();
					pic.ProcessData(pfd, thumbs);
					Bitmap bm = (Bitmap)ImageLoader.Preview(pic.Image, WaitingScreen.ImageSize);
					if (WaitingScreen.Running) WaitingScreen.Update(bm, message);
					return pic.Image;
				}
				catch(Exception){}
			}
			return null;
		}
		*/
		#endregion
		/*
		//Returns all MMAT Files in a Package containing a reference to the MATD
		protected static Interfaces.Files.IPackedFileDescriptor[] FindMMAT(SimPe.Plugin.Rcol matd, string filename)
		{
			SimPe.Packages.File pkg = SimPe.Packages.File.LoadFromFile(filename);

			ArrayList list = new ArrayList();
			Interfaces.Files.IPackedFileDescriptor[] pfds = pkg.FindFiles(FileTypes.MMAT);

			string name = matd.FileName.Trim().ToLower();

			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				pfd.UserData = pkg.Read(pfd).UncompressedData;
				Cpf cpf = new Cpf();
				cpf.ProcessData(pfd, pkg);

				string mmatname = cpf.GetItem("name").StringValue.Trim().ToLower()+"_txmt";
				if (mmatname==name) list.Add(pfd);
			}

			pfds = new Interfaces.Files.IPackedFileDescriptor[list.Count];
			list.CopyTo(pfds);

			return pfds;
		}
		*/

		//SimPe.Packages.File[] objpkgs = null;
		/// <summary>
		/// Reads all Data from the Objects.package blonging to the same group as the passed pfd
		/// </summary>
		/// <param name="pfd">Desciptor for one of files belonging to the Object (Name Map)</param>
		/// <param name="objpkg">The Object Package you wanna process</param>
		/// <param name="package">The package that should get the Files</param>
		/// <returns>The Modlename of that Object or null if none</returns>
		public static List<string> BaseClone(
			Interfaces.Files.IPackedFileDescriptor pfd,
			uint localgroup,
			Packages.File package
		)
		{
			//Get the Base Object Data from the Objects.package File
			foreach (Interfaces.Scenegraph.IScenegraphFileIndexItem item in FileTableBase.FileIndex.FindFileByGroupAndInstance(
					localgroup,
					pfd.LongInstance
				))
			{
				Interfaces.Files.IPackedFile file = item.Package.Read(
					item.FileDescriptor
				);

				Packages.PackedFileDescriptor npfd =
					new Packages.PackedFileDescriptor
					{
						UserData = file.UncompressedData,
						Group = item.FileDescriptor.Group,
						Instance = item.FileDescriptor.Instance,
						SubType = item.FileDescriptor.SubType,
						Type = item.FileDescriptor.Type
					};

				if (package.FindFile(npfd) == null)
				{
					package.Add(npfd);
				}
			}


			return new List<string>();
		}

		/// <summary>
		/// Clone an object based on way Files are linked
		/// </summary>
		/// <param name="pfd"></param>
		/// <param name="localgroup"></param>
		/// <param name="onlydefault"></param>
		protected void RecolorClone(
			Interfaces.Files.IPackedFileDescriptor pfd,
			uint localgroup,
			bool onlydefault,
			bool wallmask,
			bool anim
		)
		{
			package = Packages.File.LoadFromStream(
				null
			);

			//Get the Base Object Data from the Objects.package File
			List<string> modelname = BaseClone(pfd, localgroup, package);
			ObjectCloner objclone = new ObjectCloner(package);
			ArrayList exclude = new ArrayList
			{
				"tsMaterialsMeshName",
				"TXTR"
			};

			//do the recolor
			objclone.Setup.OnlyDefaultMmats = onlydefault;
			objclone.Setup.UpdateMmatGuids = onlydefault;
			objclone.Setup.IncludeWallmask = wallmask;
			objclone.Setup.IncludeAnimationResources = anim;
			objclone.Setup.BaseResource = CloneSettings.BaseResourceType.Ref;
			objclone.RcolModelClone(modelname, exclude);

			objclone.RemoveSubsetReferences(
				Scenegraph.GetParentSubsets(package),
				null
			);
		}

		protected void ReColor(
			Interfaces.Files.IPackedFileDescriptor pfd,
			uint localgroup
		)
		{
			if (sfd.ShowDialog() != DialogResult.OK)
			{
				return;
			}

			//create a Cloned Object to get all needed Files for the Process
			bool old = cbgid.Checked;
			cbgid.Checked = false;
			WaitingScreen.Wait();
			try
			{
				WaitingScreen.UpdateMessage("Collecting needed Files");
				if ((package == null) && (pfd != null))
				{
					RecolorClone(pfd, localgroup, false, false, false);
				}
			}
			finally
			{
				WaitingScreen.Stop(this);
			}

			cbgid.Checked = old;
			/*
			SimPe.Packages.GeneratableFile dn_pkg = null;
			if (System.IO.File.Exists(ScenegraphHelper.GMND_PACKAGE)) dn_pkg = SimPe.Packages.GeneratableFile.LoadFromFile(ScenegraphHelper.GMND_PACKAGE);
			else dn_pkg = SimPe.Packages.GeneratableFile.LoadFromStream((System.IO.BinaryReader)null);
			*/
			/*
			SimPe.Packages.GeneratableFile gm_pkg = null;
			if (System.IO.File.Exists(ScenegraphHelper.MMAT_PACKAGE)) gm_pkg = SimPe.Packages.GeneratableFile.LoadFromFile(ScenegraphHelper.MMAT_PACKAGE);
			else gm_pkg = SimPe.Packages.GeneratableFile.LoadFromStream((System.IO.BinaryReader)null);
			*/
			Packages.GeneratableFile npackage =
				Packages.File.LoadFromStream(
					null
				);

			npackage.FileName = sfd.FileName;

			ColorOptions cs = new ColorOptions(package);
			cs.Create(npackage);

			npackage.Save();
			package = npackage;

			WaitingScreen.Stop(this);
			if (package != npackage)
			{
				package = null;
			}
		}

		private void SeekItem(object sender, EventArgs e)
		{
			if (tbseek.Tag != null)
			{
				return;
			}

			tbseek.Tag = true;
			try
			{
				string name = tbseek.Text.TrimStart(new char[] { }).ToLower();
				if (lbobj.SelectionMode != SelectionMode.One)
				{
					lbobj.ClearSelected();
				}

				for (int i = 0; i < lbobj.Items.Count; i++)
				{
					IAlias a = (IAlias)lbobj.Items[i];
					if (a.Name != null)
					{
						if (a.Name.TrimStart(new char[] { }).ToLower().StartsWith(name))
						{
							tbseek.Text = a.Name.TrimStart(new char[] { });
							tbseek.SelectionStart = name.Length;
							tbseek.SelectionLength = Math.Max(
								0,
								tbseek.Text.Length - name.Length
							);
							lbobj.SelectedIndex = i;
							break;
						}

						if (a.Name.TrimStart(new char[] { }).ToLower().StartsWith("* " + name))
						{
							tbseek.Text = a.Name.TrimStart(new char[] { });
							tbseek.SelectionStart = name.Length + 2;
							tbseek.SelectionLength = Math.Max(
								0,
								tbseek.Text.Length - (name.Length + 2)
							);
							lbobj.SelectedIndex = i;
							break;
						}
					}
				}
			}
			catch (Exception) { }
			finally
			{
				tbseek.Tag = null;
				Select(null, null);
			}
		}
	}
}
