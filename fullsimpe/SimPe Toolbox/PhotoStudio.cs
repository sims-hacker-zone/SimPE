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
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for PhotoStudio.
	/// </summary>
	public class PhotoStudio : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ImageList ilist;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pb;
		private System.Windows.Forms.Button btopen;
		private System.Windows.Forms.OpenFileDialog ofd;
		private System.Windows.Forms.SaveFileDialog sfd;
		private System.Windows.Forms.Label lbname;
		private System.Windows.Forms.Label lbsize;
		private System.Windows.Forms.LinkLabel llcreate;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.ListView lv;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbquality;
		private System.Windows.Forms.ListView lvbase;
		private System.Windows.Forms.ImageList ibase;
		private System.Windows.Forms.PictureBox pbpreview;
		private System.Windows.Forms.CheckBox cbprev;
		private System.Windows.Forms.CheckBox cbflip;
		private System.Windows.Forms.Panel panel1;
		private System.ComponentModel.IContainer components;

		public PhotoStudio()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			//load all additional Package Templates
			string[] files = System.IO.Directory.GetFiles(Helper.SimPeDataPath, "*.template");
			
			if (files.Length == 0)
			{
				SimPe.WaitingScreen.Stop();
				MessageBox.Show("PhotoStudio can't be used because SimPe couldn't\nfind any PhotoStudio Templates in the Data Folder.", "Information", MessageBoxButtons.OK);
			}

			try
			{
				SimPe.WaitingScreen.Wait();

				if (files.Length > 0)
				{
					foreach (string file in files)
					{
						SimPe.Packages.File pkg = SimPe.Packages.File.LoadFromFile(file);
						PhotoStudioTemplate pst = new PhotoStudioTemplate(pkg);
						ListViewItem lvi = new ListViewItem(pst.ToString());
						lvi.ImageIndex = ibase.Images.Count;
						lvi.Tag = pst;
						Image img = new Bitmap(ibase.ImageSize.Width, ibase.ImageSize.Height);
						img = ImageLoader.Preview(pst.Texture, img.Size);
						SimPe.WaitingScreen.UpdateImage(img);
						ibase.Images.Add(img);
						lvbase.Items.Add(lvi);
					}
				}

				if (lvbase.Items.Count > 0) lvbase.Items[0].Selected = true;

				sfd.InitialDirectory = System.IO.Path.Combine(PathProvider.SimSavegameFolder, "Downloads");

				cbquality.SelectedIndex = 0;
				if (System.IO.File.Exists(PathProvider.Global.NvidiaDDSTool))
				{
					cbquality.Items.Add("Use Nvidia DDS Tools");
					cbquality.SelectedIndex = cbquality.Items.Count - 1;
				}
			}
			finally
			{
				SimPe.WaitingScreen.UpdateImage(null); SimPe.WaitingScreen.Stop();
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhotoStudio));
			this.ilist = new System.Windows.Forms.ImageList(this.components);
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.btopen = new System.Windows.Forms.Button();
			this.cbquality = new System.Windows.Forms.ComboBox();
			this.lvbase = new System.Windows.Forms.ListView();
			this.ibase = new System.Windows.Forms.ImageList(this.components);
			this.pbpreview = new System.Windows.Forms.PictureBox();
			this.cbflip = new System.Windows.Forms.CheckBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.lbsize = new System.Windows.Forms.Label();
			this.lbname = new System.Windows.Forms.Label();
			this.pb = new System.Windows.Forms.PictureBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.lv = new System.Windows.Forms.ListView();
			this.label1 = new System.Windows.Forms.Label();
			this.llcreate = new System.Windows.Forms.LinkLabel();
			this.label2 = new System.Windows.Forms.Label();
			this.cbprev = new System.Windows.Forms.CheckBox();
			this.ofd = new System.Windows.Forms.OpenFileDialog();
			this.sfd = new System.Windows.Forms.SaveFileDialog();
			this.panel1 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.pbpreview)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// ilist
			// 
			this.ilist.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			resources.ApplyResources(this.ilist, "ilist");
			this.ilist.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// btopen
			// 
			resources.ApplyResources(this.btopen, "btopen");
			this.btopen.Name = "btopen";
			this.toolTip1.SetToolTip(this.btopen, resources.GetString("btopen.ToolTip"));
			this.btopen.Click += new System.EventHandler(this.OpenImage);
			// 
			// cbquality
			// 
			resources.ApplyResources(this.cbquality, "cbquality");
			//this.cbquality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbquality.Items.AddRange(new object[] {
			resources.GetString("cbquality.Items"),
			resources.GetString("cbquality.Items1")});
			this.cbquality.Name = "cbquality";
			this.toolTip1.SetToolTip(this.cbquality, resources.GetString("cbquality.ToolTip"));
			// 
			// lvbase
			// 
			resources.ApplyResources(this.lvbase, "lvbase");
			this.lvbase.HideSelection = false;
			this.lvbase.LargeImageList = this.ibase;
			this.lvbase.MultiSelect = false;
			this.lvbase.Name = "lvbase";
			this.toolTip1.SetToolTip(this.lvbase, resources.GetString("lvbase.ToolTip"));
			this.lvbase.UseCompatibleStateImageBehavior = false;
			this.lvbase.SelectedIndexChanged += new System.EventHandler(this.lvbase_SelectedIndexChanged);
			// 
			// ibase
			// 
			this.ibase.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			resources.ApplyResources(this.ibase, "ibase");
			this.ibase.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// pbpreview
			// 
			resources.ApplyResources(this.pbpreview, "pbpreview");
			this.pbpreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pbpreview.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pbpreview.Name = "pbpreview";
			this.pbpreview.TabStop = false;
			this.toolTip1.SetToolTip(this.pbpreview, resources.GetString("pbpreview.ToolTip"));
			this.pbpreview.Click += new System.EventHandler(this.pbpreview_Click);
			// 
			// cbflip
			// 
			resources.ApplyResources(this.cbflip, "cbflip");
			this.cbflip.BackColor = System.Drawing.Color.Transparent;
			this.cbflip.Checked = true;
			this.cbflip.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbflip.Name = "cbflip";
			this.toolTip1.SetToolTip(this.cbflip, resources.GetString("cbflip.ToolTip"));
			this.cbflip.UseVisualStyleBackColor = false;
			this.cbflip.CheckedChanged += new System.EventHandler(this.lvbase_SelectedIndexChanged);
			// 
			// tabControl1
			// 
			resources.ApplyResources(this.tabControl1, "tabControl1");
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.lvbase_SelectedIndexChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage1.Controls.Add(this.lbsize);
			this.tabPage1.Controls.Add(this.lbname);
			this.tabPage1.Controls.Add(this.btopen);
			this.tabPage1.Controls.Add(this.pb);
			resources.ApplyResources(this.tabPage1, "tabPage1");
			this.tabPage1.Name = "tabPage1";
			// 
			// lbsize
			// 
			resources.ApplyResources(this.lbsize, "lbsize");
			this.lbsize.Name = "lbsize";
			// 
			// lbname
			// 
			resources.ApplyResources(this.lbname, "lbname");
			this.lbname.Name = "lbname";
			// 
			// pb
			// 
			resources.ApplyResources(this.pb, "pb");
			this.pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pb.Name = "pb";
			this.pb.TabStop = false;
			// 
			// tabPage2
			// 
			this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage2.Controls.Add(this.lv);
			resources.ApplyResources(this.tabPage2, "tabPage2");
			this.tabPage2.Name = "tabPage2";
			// 
			// lv
			// 
			resources.ApplyResources(this.lv, "lv");
			this.lv.LargeImageList = this.ilist;
			this.lv.Name = "lv";
			this.lv.UseCompatibleStateImageBehavior = false;
			this.lv.SelectedIndexChanged += new System.EventHandler(this.lvbase_SelectedIndexChanged);
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Name = "label1";
			// 
			// llcreate
			// 
			resources.ApplyResources(this.llcreate, "llcreate");
			this.llcreate.BackColor = System.Drawing.Color.Transparent;
			this.llcreate.Name = "llcreate";
			this.llcreate.TabStop = true;
			this.llcreate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CreateImage);
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Name = "label2";
			// 
			// cbprev
			// 
			resources.ApplyResources(this.cbprev, "cbprev");
			this.cbprev.BackColor = System.Drawing.Color.Transparent;
			this.cbprev.Name = "cbprev";
			this.cbprev.UseVisualStyleBackColor = false;
			this.cbprev.CheckedChanged += new System.EventHandler(this.lvbase_SelectedIndexChanged);
			// 
			// ofd
			// 
			resources.ApplyResources(this.ofd, "ofd");
			// 
			// sfd
			// 
			resources.ApplyResources(this.sfd, "sfd");
			// 
			// panel1
			// 
			resources.ApplyResources(this.panel1, "panel1");
			this.panel1.BackColor = System.Drawing.Color.Transparent;
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.pbpreview);
			this.panel1.Controls.Add(this.lvbase);
			this.panel1.Controls.Add(this.cbquality);
			this.panel1.Controls.Add(this.llcreate);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.tabControl1);
			this.panel1.Controls.Add(this.cbprev);
			this.panel1.Controls.Add(this.cbflip);
			this.panel1.Name = "panel1";
			// 
			// PhotoStudio
			// 
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MaximizeBox = false;
			this.Name = "PhotoStudio";
			this.ShowInTaskbar = false;
			((System.ComponentModel.ISupportInitialize)(this.pbpreview)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion

		protected void AddImage(SimPe.PackedFiles.Wrapper.SDesc sdesc)
		{

			if (sdesc.HasImage)
			{
				this.ilist.Images.Add(sdesc.Image);
			} 
			else 
			{
				this.ilist.Images.Add(new Bitmap(SimPe.GetImage.NoOne));
			}
		}

		protected void AddSim(SimPe.PackedFiles.Wrapper.SDesc sdesc) 
		{
			if (!sdesc.AvailableCharacterData || sdesc.HasImage == false) return;

			AddImage(sdesc);
			ListViewItem lvi = new ListViewItem();
			lvi.Text = sdesc.SimName +" "+sdesc.SimFamilyName;
			lvi.ImageIndex = ilist.Images.Count -1;
			lvi.Tag = sdesc;
		
			
			lv.Items.Add(lvi);
		}

		SimPe.Interfaces.Files.IPackedFileDescriptor pfd;
		SimPe.Interfaces.Files.IPackageFile package;
		public Interfaces.Plugin.IToolResult Execute(ref SimPe.Interfaces.Files.IPackedFileDescriptor pfd, ref SimPe.Interfaces.Files.IPackageFile package, Interfaces.IProviderRegistry prov) 
		{
			this.Cursor = Cursors.WaitCursor;
			
			this.pfd = null;
			this.package = null;

			ilist.Images.Clear();
			lv.Items.Clear();

			if (package!=null) 
			{
				Interfaces.Files.IPackedFileDescriptor[] pfds = package.FindFiles(Data.MetaData.SIM_DESCRIPTION_FILE);
				if (pfds.Length>0) WaitingScreen.Wait();
				try
				{
					foreach (Interfaces.Files.IPackedFileDescriptor spfd in pfds)
					{
						PackedFiles.Wrapper.SDesc sdesc = new SimPe.PackedFiles.Wrapper.SDesc(prov.SimNameProvider, prov.SimFamilynameProvider, null);
						sdesc.ProcessData(spfd, package);

						WaitingScreen.UpdateImage(SimPe.Plugin.ImageLoader.Preview(sdesc.Image, new Size(64, 64)));
						AddSim(sdesc);
					} //foreach
				}
				finally
				{
					WaitingScreen.UpdateImage(null); WaitingScreen.Stop(this);
				}
			}

			this.Cursor = Cursors.Default;
			RemoteControl.ShowSubForm(this);

			if (this.pfd!=null) pfd = this.pfd;
			if (this.package!=null) package = this.package;
			return new Plugin.ToolResult((this.pfd!=null), (this.package!=null));
		}

		/// <summary>
		/// Returns the selected Format
		/// </summary>
		/// <returns></returns>
		ImageLoader.TxtrFormats SelectedFormat() 
		{
			ImageLoader.TxtrFormats format = ImageLoader.TxtrFormats.Raw32Bit;
			if (cbquality.SelectedIndex==1) format = ImageLoader.TxtrFormats.DXT1Format;
			else if (cbquality.SelectedIndex==2) format = ImageLoader.TxtrFormats.DXT1Format;

			return format;
		}

		/// <summary>
		/// builds a preview Image
		/// </summary>
		/// <param name="img">The Image you want to use for the build process</param>
		/// <returns>Preview Image </returns>
		Image ShowPreview(Image img)
		{
			if ((!cbprev.Checked) || (img==null) || (lvbase.SelectedItems.Count==0)) return new Bitmap(1, 1);

			
			SimPe.Interfaces.Files.IPackageFile pkg = BuildPicture("dummy.package", img, (PhotoStudioTemplate)lvbase.SelectedItems[0].Tag, ImageLoader.TxtrFormats.Raw32Bit, false, false, cbflip.Checked);
			try 
			{
				SimPe.Plugin.Txtr txtr = new Txtr(null, false);

				//load TXTR
				Interfaces.Files.IPackedFileDescriptor[] pfd = pkg.FindFile(((PhotoStudioTemplate)lvbase.SelectedItems[0].Tag).TxtrFile+"_txtr", 0x1C4A276C);
				if (pfd.Length>0) 
				{
					txtr.ProcessData(pfd[0], pkg);
				}

				SimPe.Plugin.ImageData id = (SimPe.Plugin.ImageData)txtr.Blocks[0];
				return id.MipMapBlocks[0].MipMaps[id.MipMapBlocks[0].MipMaps.Length-1].Texture;
			} 
			catch (Exception) 
			{
				//((SimPe.Packages.GeneratableFile)pkg).Save("c:\\dummy.package");
				return new Bitmap(1, 1);
			}		

		}

		Image loadimg = null;
		private void OpenImage(object sender, System.EventArgs e)
		{
			if (ofd.ShowDialog()==DialogResult.OK) 
			{
				try 
				{
					loadimg = Image.FromFile(ofd.FileName);
					lbname.Text = System.IO.Path.GetFileName(ofd.FileName);
					lbsize.Text = loadimg.Width.ToString() + "x" + loadimg.Height.ToString();
					pb.Image = SimPe.Plugin.ImageLoader.Preview(loadimg, pb.Size);					
					preview = this.ShowPreview(loadimg);
					pbpreview.Image = SimPe.Plugin.ImageLoader.Preview(preview, pbpreview.Size);
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
		protected static SimPe.Packages.GeneratableFile BuildPicture(string filename, Image img, PhotoStudioTemplate template, ImageLoader.TxtrFormats format, bool ddstool, bool rename, bool flip) 
		{
			WaitingScreen.Wait();
			try
			{
				SimPe.Plugin.Txtr txtr = new Txtr(null, false);
				SimPe.Plugin.Rcol matd = new GenericRcol(null, false);
				SimPe.PackedFiles.Wrapper.Cpf mmat = new SimPe.PackedFiles.Wrapper.Cpf();

				SimPe.Packages.GeneratableFile pkg = SimPe.Packages.GeneratableFile.LoadFromStream((System.IO.BinaryReader)null);
				if (UserVerification.HaveValidUserId)
					pkg.Header.Created = UserVerification.UserId;
				pkg.FileName = filename;

				string family = System.Guid.NewGuid().ToString();
				string unique = RenameForm.GetUniqueName();

				SimPe.Packages.GeneratableFile tpkg = SimPe.Packages.GeneratableFile.LoadFromFile(template.Package.FileName);

				//load MMAT
				WaitingScreen.UpdateMessage("Loading Material Override");
				Interfaces.Files.IPackedFileDescriptor pfd = tpkg.FindFile(0x4C697E5A, 0x0, 0xffffffff, template.MmatInstance);
				if (pfd != null)
				{
					mmat.ProcessData(pfd, tpkg);
					mmat.GetSaveItem("family").StringValue = family;
					if (rename) mmat.GetSaveItem("name").StringValue = "##0x1c050000!" + BuildName(template.MatdFile, unique);

					mmat.SynchronizeUserData();
					pkg.Add(mmat.FileDescriptor);
				}

				//load MATD
				WaitingScreen.UpdateMessage("Loading Material Definition");
				pfd = tpkg.FindFile(0x49596978, Hashes.SubTypeHash(Hashes.StripHashFromName(template.MatdFile + "_txmt")), 0x1c050000, Hashes.InstanceHash(Hashes.StripHashFromName(template.MatdFile + "_txmt")));
				if (pfd == null) pfd = tpkg.FindFile(0x49596978, Hashes.SubTypeHash(Hashes.StripHashFromName(template.MatdFile + "_txmt")), 0xffffffff, Hashes.InstanceHash(Hashes.StripHashFromName(template.MatdFile + "_txmt")));
				if (pfd != null)
				{
					matd.ProcessData(pfd, tpkg);
					if (rename) matd.FileName = "##0x1c050000!" + BuildName(template.MatdFile, unique) + "_txmt";
					SimPe.Plugin.MaterialDefinition md = (SimPe.Plugin.MaterialDefinition)matd.Blocks[0];
					if (rename) md.GetProperty("stdMatBaseTextureName").Value = "##0x1c050000!" + BuildName(template.TxtrFile, unique);
					if (rename) md.Listing[0] = md.GetProperty("stdMatBaseTextureName").Value;

					matd.FileDescriptor = new Packages.PackedFileDescriptor();
					matd.FileDescriptor.Type = 0x49596978; //TXMT
					matd.FileDescriptor.SubType = Hashes.SubTypeHash(Hashes.StripHashFromName(matd.FileName));
					matd.FileDescriptor.Instance = Hashes.InstanceHash(Hashes.StripHashFromName(matd.FileName));
					matd.FileDescriptor.Group = 0x1c050000;
					matd.SynchronizeUserData();
					pkg.Add(matd.FileDescriptor);
				}

				//load TXTR
				WaitingScreen.UpdateMessage("Loading Texture Image");
				pfd = tpkg.FindFile(0x1C4A276C, Hashes.SubTypeHash(Hashes.StripHashFromName(template.TxtrFile + "_txtr")), 0x1c050000, Hashes.InstanceHash(Hashes.StripHashFromName(template.TxtrFile + "_txtr")));
				if (pfd == null) pfd = tpkg.FindFile(0x1C4A276C, Hashes.SubTypeHash(Hashes.StripHashFromName(template.TxtrFile + "_txtr")), 0xffffffff, Hashes.InstanceHash(Hashes.StripHashFromName(template.TxtrFile + "_txtr")));
				if (pfd != null)
				{
					txtr.ProcessData(pfd, tpkg);
					if (rename) txtr.FileName = "##0x1c050000!" + BuildName(template.TxtrFile, unique) + "_txtr";

					SimPe.Plugin.ImageData id = (SimPe.Plugin.ImageData)txtr.Blocks[0];
					SimPe.Plugin.MipMapBlock mmp = id.MipMapBlocks[0];
					SimPe.Plugin.MipMap mm = mmp.MipMaps[mmp.MipMaps.Length - 1];
					//mm.Data = null;

					WaitingScreen.UpdateMessage("Updating Image");
					Rectangle rect = new Rectangle(0, 0, img.Width, img.Height);
					Image mmimg = (Image)img.Clone();
					if (flip) mmimg.RotateFlip(System.Drawing.RotateFlipType.RotateNoneFlipX);
					System.Drawing.Graphics g = Graphics.FromImage(mm.Texture);
					g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
					g.DrawImage(mmimg, template.TargetRectangle, rect, System.Drawing.GraphicsUnit.Pixel);


					if ((System.IO.File.Exists(PathProvider.Global.NvidiaDDSTool)) && (ddstool) && ((format == ImageLoader.TxtrFormats.DXT1Format) || (format == ImageLoader.TxtrFormats.DXT3Format) || (format == ImageLoader.TxtrFormats.DXT5Format)))
					{
						DDSTool.AddDDsData(id, DDSTool.BuildDDS(mm.Texture, (int)id.MipMapLevels, format, "-sharpenMethod Smoothen"));
					}
					else
					{
						for (int i = mmp.MipMaps.Length - 2; i >= 0; i--)
						{
							SimPe.Plugin.MipMap newmm = mmp.MipMaps[i];
							Image newimg = new Bitmap(newmm.Texture.Width, newmm.Texture.Height);
							g = Graphics.FromImage(newimg);
							g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
							g.DrawImage(mm.Texture, new Rectangle(0, 0, newimg.Width, newimg.Height), new Rectangle(0, 0, mm.Texture.Width, mm.Texture.Height), System.Drawing.GraphicsUnit.Pixel);

							newmm.Texture = newimg;
						}
						id.Format = format;
					}

					txtr.FileDescriptor = new Packages.PackedFileDescriptor();
					txtr.FileDescriptor.Type = 0x1C4A276C; //TXTR
					txtr.FileDescriptor.SubType = Hashes.SubTypeHash(Hashes.StripHashFromName(txtr.FileName));
					txtr.FileDescriptor.Instance = Hashes.InstanceHash(Hashes.StripHashFromName(txtr.FileName));
					txtr.FileDescriptor.Group = 0x1c050000;
					txtr.SynchronizeUserData();
					pkg.Add(txtr.FileDescriptor);
				}

				return pkg;
			}
			finally { WaitingScreen.Stop(); }
		}

		private void CreateImage(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			if (lvbase.SelectedItems.Count==0) return;
			Image img = null;

			//get the Image depending on the Active Tab
			if (tabControl1.SelectedIndex==0) 
			{
				img = loadimg;
			} 
			else if (tabControl1.SelectedIndex==1) 
			{
				if (lv.SelectedItems.Count<1) return;
			
				PackedFiles.Wrapper.SDesc sdesc = (PackedFiles.Wrapper.SDesc)lv.SelectedItems[0].Tag;
				img = sdesc.Image;				
			}

			if (img == null) return;
			if (sfd.ShowDialog()==DialogResult.OK) 
			{
				try 
				{
					this.Cursor = Cursors.WaitCursor;
					this.package = BuildPicture(sfd.FileName, img, (PhotoStudioTemplate)lvbase.SelectedItems[0].Tag, SelectedFormat(), (cbquality.SelectedIndex==2), true, cbflip.Checked);
					((SimPe.Packages.GeneratableFile)this.package).Save();
					this.Cursor = Cursors.Default;
					Close();
				} 
				catch (Exception ex) 
				{
					Helper.ExceptionMessage("", ex);
				}
			}
		}

		Image preview;
		private void lvbase_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			if (tabControl1.SelectedIndex==0) 
			{
				preview = this.ShowPreview(loadimg);
			} 
			else 
			{
				if (lv.SelectedItems.Count>0)
				{
					PackedFiles.Wrapper.SDesc sdesc = (PackedFiles.Wrapper.SDesc)lv.SelectedItems[0].Tag;
					preview = this.ShowPreview(sdesc.Image);
				} 
				else 
				{
					preview = null;
				}
			}
			
			
			pbpreview.Image = SimPe.Plugin.ImageLoader.Preview(preview, pbpreview.Size);
			this.Cursor = Cursors.Default;
		}

		private void pbpreview_Click(object sender, System.EventArgs e)
		{
			if (preview==null) return;

			Form form = new Form();
			form.Width = preview.Width;
			form.Height = preview.Height;

			PictureBox pb = new PictureBox();
			pb.Size = new Size(preview.Width, preview.Height);
			pb.Parent = form;
			pb.Left = 0;
			pb.Top = 0;
			pb.Image = preview;
			
			form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			form.Text = "Preview";

			form.ShowDialog();

		}
	}
}
