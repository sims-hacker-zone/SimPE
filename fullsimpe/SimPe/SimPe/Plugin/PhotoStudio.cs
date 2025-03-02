// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Drawing;
using System.Windows.Forms;

using SimPe.PackedFiles.Cpf;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for PhotoStudio.
	/// </summary>
	public class PhotoStudio : Form
	{
		private ImageList ilist;
		private ToolTip toolTip1;
		private TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private Label label1;
		private PictureBox pb;
		private Button btopen;
		private OpenFileDialog ofd;
		private SaveFileDialog sfd;
		private Label lbname;
		private Label lbsize;
		private LinkLabel llcreate;
		private System.Windows.Forms.TabPage tabPage2;
		private ListView lv;
		private Label label2;
		private ComboBox cbquality;
		private ListView lvbase;
		private ImageList ibase;
		private PictureBox pbpreview;
		private CheckBox cbprev;
		private CheckBox cbflip;
		private Panel panel1;
		private System.ComponentModel.IContainer components;

		public PhotoStudio()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			//load all additional Package Templates
			string[] files = System.IO.Directory.GetFiles(
				Helper.SimPeDataPath,
				"*.template"
			);

			if (files.Length == 0)
			{
				WaitingScreen.Stop();
				MessageBox.Show(
					"PhotoStudio can't be used because SimPe couldn't\nfind any PhotoStudio Templates in the Data Folder.",
					"Information",
					MessageBoxButtons.OK
				);
			}

			try
			{
				WaitingScreen.Wait();

				if (files.Length > 0)
				{
					foreach (string file in files)
					{
						Packages.File pkg = Packages.File.LoadFromFile(
							file
						);
						PhotoStudioTemplate pst = new PhotoStudioTemplate(pkg);
						ListViewItem lvi = new ListViewItem(pst.ToString())
						{
							ImageIndex = ibase.Images.Count,
							Tag = pst
						};
						Image img = new Bitmap(
							ibase.ImageSize.Width,
							ibase.ImageSize.Height
						);
						img = ImageLoader.Preview(pst.Texture, img.Size);
						WaitingScreen.UpdateImage(img);
						ibase.Images.Add(img);
						lvbase.Items.Add(lvi);
					}
				}

				if (lvbase.Items.Count > 0)
				{
					lvbase.Items[0].Selected = true;
				}

				sfd.InitialDirectory = System.IO.Path.Combine(
					PathProvider.SimSavegameFolder,
					"Downloads"
				);

				cbquality.SelectedIndex = 0;
				if (System.IO.File.Exists(PathProvider.Global.NvidiaDDSTool))
				{
					cbquality.Items.Add("Use Nvidia DDS Tools");
					cbquality.SelectedIndex = cbquality.Items.Count - 1;
				}
			}
			finally
			{
				WaitingScreen.UpdateImage(null);
				WaitingScreen.Stop();
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
				new System.ComponentModel.ComponentResourceManager(typeof(PhotoStudio));
			ilist = new ImageList(components);
			toolTip1 = new ToolTip(components);
			btopen = new Button();
			cbquality = new ComboBox();
			lvbase = new ListView();
			ibase = new ImageList(components);
			pbpreview = new PictureBox();
			cbflip = new CheckBox();
			tabControl1 = new TabControl();
			tabPage1 = new System.Windows.Forms.TabPage();
			lbsize = new Label();
			lbname = new Label();
			pb = new PictureBox();
			tabPage2 = new System.Windows.Forms.TabPage();
			lv = new ListView();
			label1 = new Label();
			llcreate = new LinkLabel();
			label2 = new Label();
			cbprev = new CheckBox();
			ofd = new OpenFileDialog();
			sfd = new SaveFileDialog();
			panel1 = new Panel();
			((System.ComponentModel.ISupportInitialize)pbpreview).BeginInit();
			tabControl1.SuspendLayout();
			tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pb).BeginInit();
			tabPage2.SuspendLayout();
			panel1.SuspendLayout();
			SuspendLayout();
			//
			// ilist
			//
			ilist.ColorDepth = ColorDepth.Depth32Bit;
			resources.ApplyResources(ilist, "ilist");
			ilist.TransparentColor = Color.Transparent;
			//
			// btopen
			//
			resources.ApplyResources(btopen, "btopen");
			btopen.Name = "btopen";
			toolTip1.SetToolTip(
				btopen,
				resources.GetString("btopen.ToolTip")
			);
			btopen.Click += new EventHandler(OpenImage);
			//
			// cbquality
			//
			resources.ApplyResources(cbquality, "cbquality");
			//this.cbquality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbquality.Items.AddRange(
				new object[]
				{
					resources.GetString("cbquality.Items"),
					resources.GetString("cbquality.Items1"),
				}
			);
			cbquality.Name = "cbquality";
			toolTip1.SetToolTip(
				cbquality,
				resources.GetString("cbquality.ToolTip")
			);
			//
			// lvbase
			//
			resources.ApplyResources(lvbase, "lvbase");
			lvbase.HideSelection = false;
			lvbase.LargeImageList = ibase;
			lvbase.MultiSelect = false;
			lvbase.Name = "lvbase";
			toolTip1.SetToolTip(
				lvbase,
				resources.GetString("lvbase.ToolTip")
			);
			lvbase.UseCompatibleStateImageBehavior = false;
			lvbase.SelectedIndexChanged += new EventHandler(
				lvbase_SelectedIndexChanged
			);
			//
			// ibase
			//
			ibase.ColorDepth = ColorDepth.Depth32Bit;
			resources.ApplyResources(ibase, "ibase");
			ibase.TransparentColor = Color.Transparent;
			//
			// pbpreview
			//
			resources.ApplyResources(pbpreview, "pbpreview");
			pbpreview.BorderStyle = BorderStyle.FixedSingle;
			pbpreview.Cursor = Cursors.Hand;
			pbpreview.Name = "pbpreview";
			pbpreview.TabStop = false;
			toolTip1.SetToolTip(
				pbpreview,
				resources.GetString("pbpreview.ToolTip")
			);
			pbpreview.Click += new EventHandler(pbpreview_Click);
			//
			// cbflip
			//
			resources.ApplyResources(cbflip, "cbflip");
			cbflip.BackColor = Color.Transparent;
			cbflip.Checked = true;
			cbflip.CheckState = CheckState.Checked;
			cbflip.Name = "cbflip";
			toolTip1.SetToolTip(
				cbflip,
				resources.GetString("cbflip.ToolTip")
			);
			cbflip.UseVisualStyleBackColor = false;
			cbflip.CheckedChanged += new EventHandler(
				lvbase_SelectedIndexChanged
			);
			//
			// tabControl1
			//
			resources.ApplyResources(tabControl1, "tabControl1");
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage2);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.SelectedIndexChanged += new EventHandler(
				lvbase_SelectedIndexChanged
			);
			//
			// tabPage1
			//
			tabPage1.BackColor = SystemColors.Control;
			tabPage1.Controls.Add(lbsize);
			tabPage1.Controls.Add(lbname);
			tabPage1.Controls.Add(btopen);
			tabPage1.Controls.Add(pb);
			resources.ApplyResources(tabPage1, "tabPage1");
			tabPage1.Name = "tabPage1";
			//
			// lbsize
			//
			resources.ApplyResources(lbsize, "lbsize");
			lbsize.Name = "lbsize";
			//
			// lbname
			//
			resources.ApplyResources(lbname, "lbname");
			lbname.Name = "lbname";
			//
			// pb
			//
			resources.ApplyResources(pb, "pb");
			pb.BorderStyle = BorderStyle.FixedSingle;
			pb.Name = "pb";
			pb.TabStop = false;
			//
			// tabPage2
			//
			tabPage2.BackColor = SystemColors.Control;
			tabPage2.Controls.Add(lv);
			resources.ApplyResources(tabPage2, "tabPage2");
			tabPage2.Name = "tabPage2";
			//
			// lv
			//
			resources.ApplyResources(lv, "lv");
			lv.LargeImageList = ilist;
			lv.Name = "lv";
			lv.UseCompatibleStateImageBehavior = false;
			lv.SelectedIndexChanged += new EventHandler(
				lvbase_SelectedIndexChanged
			);
			//
			// label1
			//
			resources.ApplyResources(label1, "label1");
			label1.BackColor = Color.Transparent;
			label1.Name = "label1";
			//
			// llcreate
			//
			resources.ApplyResources(llcreate, "llcreate");
			llcreate.BackColor = Color.Transparent;
			llcreate.Name = "llcreate";
			llcreate.TabStop = true;
			llcreate.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					CreateImage
				);
			//
			// label2
			//
			resources.ApplyResources(label2, "label2");
			label2.BackColor = Color.Transparent;
			label2.Name = "label2";
			//
			// cbprev
			//
			resources.ApplyResources(cbprev, "cbprev");
			cbprev.BackColor = Color.Transparent;
			cbprev.Name = "cbprev";
			cbprev.UseVisualStyleBackColor = false;
			cbprev.CheckedChanged += new EventHandler(
				lvbase_SelectedIndexChanged
			);
			//
			// ofd
			//
			resources.ApplyResources(ofd, "ofd");
			//
			// sfd
			//
			resources.ApplyResources(sfd, "sfd");
			//
			// panel1
			//
			resources.ApplyResources(panel1, "panel1");
			panel1.BackColor = Color.Transparent;
			panel1.Controls.Add(label2);
			panel1.Controls.Add(pbpreview);
			panel1.Controls.Add(lvbase);
			panel1.Controls.Add(cbquality);
			panel1.Controls.Add(llcreate);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(tabControl1);
			panel1.Controls.Add(cbprev);
			panel1.Controls.Add(cbflip);
			panel1.Name = "panel1";
			//
			// PhotoStudio
			//
			resources.ApplyResources(this, "$this");
			Controls.Add(panel1);
			FormBorderStyle =
				FormBorderStyle
				.SizableToolWindow;
			MaximizeBox = false;
			Name = "PhotoStudio";
			ShowInTaskbar = false;
			((System.ComponentModel.ISupportInitialize)pbpreview).EndInit();
			tabControl1.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pb).EndInit();
			tabPage2.ResumeLayout(false);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}
		#endregion

		protected void AddImage(PackedFiles.Wrapper.SDesc sdesc)
		{
			if (sdesc.HasImage)
			{
				ilist.Images.Add(sdesc.Image);
			}
			else
			{
				ilist.Images.Add(new Bitmap(GetImage.NoOne));
			}
		}

		protected void AddSim(PackedFiles.Wrapper.SDesc sdesc)
		{
			if (!sdesc.AvailableCharacterData || !sdesc.HasImage)
			{
				return;
			}

			AddImage(sdesc);
			ListViewItem lvi = new ListViewItem
			{
				Text = sdesc.SimName + " " + sdesc.SimFamilyName,
				ImageIndex = ilist.Images.Count - 1,
				Tag = sdesc
			};

			lv.Items.Add(lvi);
		}

		Interfaces.Files.IPackedFileDescriptor pfd;
		Interfaces.Files.IPackageFile package;

		public Interfaces.Plugin.IToolResult Execute(
			ref Interfaces.Files.IPackedFileDescriptor pfd,
			ref Interfaces.Files.IPackageFile package,
			Interfaces.IProviderRegistry prov
		)
		{
			Cursor = Cursors.WaitCursor;

			this.pfd = null;
			this.package = null;

			ilist.Images.Clear();
			lv.Items.Clear();

			if (package != null)
			{
				Interfaces.Files.IPackedFileDescriptor[] pfds = package.FindFiles(
					Data.MetaData.SIM_DESCRIPTION_FILE
				);
				if (pfds.Length > 0)
				{
					WaitingScreen.Wait();
				}

				try
				{
					foreach (Interfaces.Files.IPackedFileDescriptor spfd in pfds)
					{
						PackedFiles.Wrapper.SDesc sdesc =
							new PackedFiles.Wrapper.SDesc(
								prov.SimNameProvider,
								prov.SimFamilynameProvider,
								null
							);
						sdesc.ProcessData(spfd, package);

						WaitingScreen.UpdateImage(
							ImageLoader.Preview(
								sdesc.Image,
								new Size(64, 64)
							)
						);
						AddSim(sdesc);
					} //foreach
				}
				finally
				{
					WaitingScreen.UpdateImage(null);
					WaitingScreen.Stop(this);
				}
			}

			Cursor = Cursors.Default;
			RemoteControl.ShowSubForm(this);

			if (this.pfd != null)
			{
				pfd = this.pfd;
			}

			if (this.package != null)
			{
				package = this.package;
			}

			return new ToolResult(this.pfd != null, this.package != null);
		}

		/// <summary>
		/// Returns the selected Format
		/// </summary>
		/// <returns></returns>
		ImageLoader.TxtrFormats SelectedFormat()
		{
			ImageLoader.TxtrFormats format = ImageLoader.TxtrFormats.Raw32Bit;
			if (cbquality.SelectedIndex == 1)
			{
				format = ImageLoader.TxtrFormats.DXT1Format;
			}
			else if (cbquality.SelectedIndex == 2)
			{
				format = ImageLoader.TxtrFormats.DXT1Format;
			}

			return format;
		}

		/// <summary>
		/// builds a preview Image
		/// </summary>
		/// <param name="img">The Image you want to use for the build process</param>
		/// <returns>Preview Image </returns>
		Image ShowPreview(Image img)
		{
			if ((!cbprev.Checked) || (img == null) || (lvbase.SelectedItems.Count == 0))
			{
				return new Bitmap(1, 1);
			}

			Interfaces.Files.IPackageFile pkg = BuildPicture(
				"dummy.package",
				img,
				(PhotoStudioTemplate)lvbase.SelectedItems[0].Tag,
				ImageLoader.TxtrFormats.Raw32Bit,
				false,
				false,
				cbflip.Checked
			);
			try
			{
				Txtr txtr = new Txtr(null, false);

				//load TXTR
				Interfaces.Files.IPackedFileDescriptor[] pfd = pkg.FindFile(
					((PhotoStudioTemplate)lvbase.SelectedItems[0].Tag).TxtrFile
						+ "_txtr",
					0x1C4A276C
				);
				if (pfd.Length > 0)
				{
					txtr.ProcessData(pfd[0], pkg);
				}

				ImageData id = (ImageData)txtr.Blocks[0];
				return id.MipMapBlocks[0]
					.MipMaps[id.MipMapBlocks[0].MipMaps.Length - 1]
					.Texture;
			}
			catch (Exception)
			{
				//((SimPe.Packages.GeneratableFile)pkg).Save("c:\\dummy.package");
				return new Bitmap(1, 1);
			}
		}

		Image loadimg = null;

		private void OpenImage(object sender, EventArgs e)
		{
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				try
				{
					loadimg = Image.FromFile(ofd.FileName);
					lbname.Text = System.IO.Path.GetFileName(ofd.FileName);
					lbsize.Text =
						loadimg.Width.ToString() + "x" + loadimg.Height.ToString();
					pb.Image = ImageLoader.Preview(loadimg, pb.Size);
					preview = ShowPreview(loadimg);
					pbpreview.Image = ImageLoader.Preview(
						preview,
						pbpreview.Size
					);
				}
				catch (Exception)
				{
					pb.Image = null;
				}
			}
		}

		static string BuildName(string name, string unique)
		{
			name = Hashes.StripHashFromName(name);
			name = RenameForm.ReplaceOldUnique(name, unique, true);

			return name;
		}

		/// <summary>
		/// Creates a new Picture using the passed Template and the passed Image
		/// </summary>
		/// <param name="filename">FileName for the new package</param>
		/// <param name="img">The Image you want to use</param>
		/// <param name="template">The Template to use</param>
		/// <param name="format">The Format to save the Imag ein</param>
		/// <param name="ddstool">true if you want to use the DDS Tools (if available)</param>
		/// <param name="rename">true, if the Texture should be renamed</param>
		/// <param name="flip">true if the Image should be flipped</param>
		/// <returns>The package with the Recolor</returns>
		protected static Packages.GeneratableFile BuildPicture(
			string filename,
			Image img,
			PhotoStudioTemplate template,
			ImageLoader.TxtrFormats format,
			bool ddstool,
			bool rename,
			bool flip
		)
		{
			WaitingScreen.Wait();
			try
			{
				Txtr txtr = new Txtr(null, false);
				Rcol matd = new GenericRcol(null, false);
				Cpf mmat =
					new Cpf();

				Packages.GeneratableFile pkg =
					Packages.File.LoadFromStream(
						null
					);
				if (UserVerification.HaveValidUserId)
				{
					pkg.Header.Created = UserVerification.UserId;
				}

				pkg.FileName = filename;

				string family = Guid.NewGuid().ToString();
				string unique = RenameForm.GetUniqueName();

				Packages.GeneratableFile tpkg =
					Packages.File.LoadFromFile(
						template.Package.FileName
					);

				//load MMAT
				WaitingScreen.UpdateMessage("Loading Material Override");
				Interfaces.Files.IPackedFileDescriptor pfd = tpkg.FindFile(
					0x4C697E5A,
					0x0,
					0xffffffff,
					template.MmatInstance
				);
				if (pfd != null)
				{
					mmat.ProcessData(pfd, tpkg);
					mmat.GetSaveItem("family").StringValue = family;
					if (rename)
					{
						mmat.GetSaveItem("name").StringValue =
							"##0x1c050000!" + BuildName(template.MatdFile, unique);
					}

					mmat.SynchronizeUserData();
					pkg.Add(mmat.FileDescriptor);
				}

				//load MATD
				WaitingScreen.UpdateMessage("Loading Material Definition");
				pfd = tpkg.FindFile(
					0x49596978,
					Hashes.SubTypeHash(
						Hashes.StripHashFromName(template.MatdFile + "_txmt")
					),
					0x1c050000,
					Hashes.InstanceHash(
						Hashes.StripHashFromName(template.MatdFile + "_txmt")
					)
				);
				if (pfd == null)
				{
					pfd = tpkg.FindFile(
						0x49596978,
						Hashes.SubTypeHash(
							Hashes.StripHashFromName(template.MatdFile + "_txmt")
						),
						0xffffffff,
						Hashes.InstanceHash(
							Hashes.StripHashFromName(template.MatdFile + "_txmt")
						)
					);
				}

				if (pfd != null)
				{
					matd.ProcessData(pfd, tpkg);
					if (rename)
					{
						matd.FileName =
							"##0x1c050000!"
							+ BuildName(template.MatdFile, unique)
							+ "_txmt";
					}

					MaterialDefinition md =
						(MaterialDefinition)matd.Blocks[0];
					if (rename)
					{
						md.GetProperty("stdMatBaseTextureName").Value =
							"##0x1c050000!" + BuildName(template.TxtrFile, unique);
					}

					if (rename)
					{
						md.Listing[0] = md.GetProperty("stdMatBaseTextureName").Value;
					}

					matd.FileDescriptor = new Packages.PackedFileDescriptor
					{
						Type = 0x49596978, //TXMT
						SubType = Hashes.SubTypeHash(
						Hashes.StripHashFromName(matd.FileName)
					),
						Instance = Hashes.InstanceHash(
						Hashes.StripHashFromName(matd.FileName)
					),
						Group = 0x1c050000
					};
					matd.SynchronizeUserData();
					pkg.Add(matd.FileDescriptor);
				}

				//load TXTR
				WaitingScreen.UpdateMessage("Loading Texture Image");
				pfd = tpkg.FindFile(
					0x1C4A276C,
					Hashes.SubTypeHash(
						Hashes.StripHashFromName(template.TxtrFile + "_txtr")
					),
					0x1c050000,
					Hashes.InstanceHash(
						Hashes.StripHashFromName(template.TxtrFile + "_txtr")
					)
				);
				if (pfd == null)
				{
					pfd = tpkg.FindFile(
						0x1C4A276C,
						Hashes.SubTypeHash(
							Hashes.StripHashFromName(template.TxtrFile + "_txtr")
						),
						0xffffffff,
						Hashes.InstanceHash(
							Hashes.StripHashFromName(template.TxtrFile + "_txtr")
						)
					);
				}

				if (pfd != null)
				{
					txtr.ProcessData(pfd, tpkg);
					if (rename)
					{
						txtr.FileName =
							"##0x1c050000!"
							+ BuildName(template.TxtrFile, unique)
							+ "_txtr";
					}

					ImageData id = (ImageData)txtr.Blocks[0];
					MipMapBlock mmp = id.MipMapBlocks[0];
					MipMap mm = mmp.MipMaps[mmp.MipMaps.Length - 1];
					//mm.Data = null;

					WaitingScreen.UpdateMessage("Updating Image");
					Rectangle rect = new Rectangle(0, 0, img.Width, img.Height);
					Image mmimg = (Image)img.Clone();
					if (flip)
					{
						mmimg.RotateFlip(RotateFlipType.RotateNoneFlipX);
					}

					Graphics g = Graphics.FromImage(mm.Texture);
					g.InterpolationMode = System
						.Drawing
						.Drawing2D
						.InterpolationMode
						.HighQualityBicubic;
					g.DrawImage(
						mmimg,
						template.TargetRectangle,
						rect,
						GraphicsUnit.Pixel
					);

					if (
						System.IO.File.Exists(PathProvider.Global.NvidiaDDSTool)
						&& ddstool
						&& (
							(format == ImageLoader.TxtrFormats.DXT1Format)
							|| (format == ImageLoader.TxtrFormats.DXT3Format)
							|| (format == ImageLoader.TxtrFormats.DXT5Format)
						)
					)
					{
						DDSTool.AddDDsData(
							id,
							DDSTool.BuildDDS(
								mm.Texture,
								(int)id.MipMapLevels,
								format,
								"-sharpenMethod Smoothen"
							)
						);
					}
					else
					{
						for (int i = mmp.MipMaps.Length - 2; i >= 0; i--)
						{
							MipMap newmm = mmp.MipMaps[i];
							Image newimg = new Bitmap(
								newmm.Texture.Width,
								newmm.Texture.Height
							);
							g = Graphics.FromImage(newimg);
							g.InterpolationMode = System
								.Drawing
								.Drawing2D
								.InterpolationMode
								.HighQualityBicubic;
							g.DrawImage(
								mm.Texture,
								new Rectangle(0, 0, newimg.Width, newimg.Height),
								new Rectangle(
									0,
									0,
									mm.Texture.Width,
									mm.Texture.Height
								),
								GraphicsUnit.Pixel
							);

							newmm.Texture = newimg;
						}
						id.Format = format;
					}

					txtr.FileDescriptor = new Packages.PackedFileDescriptor
					{
						Type = 0x1C4A276C, //TXTR
						SubType = Hashes.SubTypeHash(
						Hashes.StripHashFromName(txtr.FileName)
					),
						Instance = Hashes.InstanceHash(
						Hashes.StripHashFromName(txtr.FileName)
					),
						Group = 0x1c050000
					};
					txtr.SynchronizeUserData();
					pkg.Add(txtr.FileDescriptor);
				}

				return pkg;
			}
			finally
			{
				WaitingScreen.Stop();
			}
		}

		private void CreateImage(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (lvbase.SelectedItems.Count == 0)
			{
				return;
			}

			Image img = null;

			//get the Image depending on the Active Tab
			if (tabControl1.SelectedIndex == 0)
			{
				img = loadimg;
			}
			else if (tabControl1.SelectedIndex == 1)
			{
				if (lv.SelectedItems.Count < 1)
				{
					return;
				}

				PackedFiles.Wrapper.SDesc sdesc = (PackedFiles.Wrapper.SDesc)
					lv.SelectedItems[0].Tag;
				img = sdesc.Image;
			}

			if (img == null)
			{
				return;
			}

			if (sfd.ShowDialog() == DialogResult.OK)
			{
				try
				{
					Cursor = Cursors.WaitCursor;
					package = BuildPicture(
						sfd.FileName,
						img,
						(PhotoStudioTemplate)lvbase.SelectedItems[0].Tag,
						SelectedFormat(),
						cbquality.SelectedIndex == 2,
						true,
						cbflip.Checked
					);
					((Packages.GeneratableFile)package).Save();
					Cursor = Cursors.Default;
					Close();
				}
				catch (Exception ex)
				{
					Helper.ExceptionMessage("", ex);
				}
			}
		}

		Image preview;

		private void lvbase_SelectedIndexChanged(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			if (tabControl1.SelectedIndex == 0)
			{
				preview = ShowPreview(loadimg);
			}
			else
			{
				if (lv.SelectedItems.Count > 0)
				{
					PackedFiles.Wrapper.SDesc sdesc = (PackedFiles.Wrapper.SDesc)
						lv.SelectedItems[0].Tag;
					preview = ShowPreview(sdesc.Image);
				}
				else
				{
					preview = null;
				}
			}

			pbpreview.Image = ImageLoader.Preview(preview, pbpreview.Size);
			Cursor = Cursors.Default;
		}

		private void pbpreview_Click(object sender, EventArgs e)
		{
			if (preview == null)
			{
				return;
			}

			Form form = new Form
			{
				Width = preview.Width,
				Height = preview.Height
			};

			PictureBox pb = new PictureBox
			{
				Size = new Size(preview.Width, preview.Height),
				Parent = form,
				Left = 0,
				Top = 0,
				Image = preview
			};

			form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			form.Text = "Preview";

			form.ShowDialog();
		}
	}
}
