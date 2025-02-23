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
using SimPe;
using SimPe.Data;
using SimPe.Interfaces;


namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for SkinWorkshop.
	/// </summary>
	public class SkinWorkshop : System.Windows.Forms.Form
    {
		private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.CheckBox cbfix;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox taskBox2;
        private System.Windows.Forms.GroupBox taskBox1;
        private System.Windows.Forms.ListBox lbobj;
        private System.Windows.Forms.Button btclone;
        private System.Windows.Forms.CheckBox cbgid;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.TextBox tbseek;
        private System.Windows.Forms.PictureBox pb;

        SimPe.Packages.GeneratableFile package;
        SimPe.Interfaces.Files.IPackageFile simpe_pkg;

		public SkinWorkshop()
		{
            InitializeComponent();
			btclone.Enabled = false;
			btclone.Refresh();
            lbobj.SelectionMode = SelectionMode.One;
		}

		#region Cache Handling		
		SimPe.Cache.ObjectCacheFile cachefile;
		bool cachechg;

		/// <summary>
		/// Get the Name of the Object Cache File
		/// </summary>
		string CacheFileName 
		{
			get {return Helper.SimPeLanguageCache;}
		}

		/// <summary>
		/// Load the Object Cache
		/// </summary>
		void LoadCachIndex()
		{
			if (cachefile!=null) return;
			
			cachechg = false;
			cachefile = new SimPe.Cache.ObjectCacheFile();
		
			if (!Helper.WindowsRegistry.UseCache) return;
            if (WaitingScreen.Running) WaitingScreen.UpdateMessage("Loading Cache");
			try 
			{
				cachefile.Load(CacheFileName);
			} 
			catch (Exception ex) 
			{
				Helper.ExceptionMessage("", ex);
			}			

			cachefile.LoadObjects();
		}

		/// <summary>
		/// Save the Cache to the Disk
		/// </summary>
		void SaveCacheIndex()
		{
			if (!Helper.WindowsRegistry.UseCache) return;
			if (!cachechg) return;
            if (WaitingScreen.Running) WaitingScreen.UpdateMessage("Saving Cache");

			cachefile.Save(CacheFileName);
		}		
		#endregion

        void BuildListing(uint type)
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
                    FileTable.FileIndex.Load();
                    Interfaces.Scenegraph.IScenegraphFileIndexItem[] nrefitems = FileTable.FileIndex.Sort(FileTable.FileIndex.FindFile(type, true));
                    WaitingScreen.UpdateMessage("Loading Items");
                    foreach (Interfaces.Scenegraph.IScenegraphFileIndexItem nrefitem in nrefitems)
                    {
                        if (nrefitem.LocalGroup == Data.MetaData.LOCAL_GROUP) continue;
                        Interfaces.Scenegraph.IScenegraphFileIndexItem[] cacheitems = cachefile.FileIndex.FindFile(nrefitem.FileDescriptor, nrefitem.Package);
                        //find the correct File
                        int cindex = -1;
                        string pname = nrefitem.Package.FileName.Trim().ToLower();
                        for (int i = 0; i < cacheitems.Length; i++)
                        {
                            Interfaces.Scenegraph.IScenegraphFileIndexItem citem = cacheitems[i];

                            if (citem.FileDescriptor.Filename.Trim().ToLower() == pname)
                            {
                                cindex = i;
                                break;
                            }
                        }

                        if (cindex != -1) //found in the cache
                        {
                            SimPe.Cache.ObjectCacheItem oci = (SimPe.Cache.ObjectCacheItem)cacheitems[cindex].FileDescriptor.Tag;
                            if (oci.Name.Length < 3) continue;
                            if (!oci.Useable) continue;
                            Data.Alias a = new Data.Alias(oci.FileDescriptor.Instance, oci.Name);
                            object[] o = new object[3];
                            o[0] = nrefitem.FileDescriptor;
                            o[1] = nrefitem.LocalGroup;
                            o[2] = nrefitem.FileDescriptor.Instance;
                            a.Tag = o;
                            if (Helper.WindowsRegistry.ShowObjdNames) a.Name = oci.ObjectFileName;
                            else a.Name = oci.Name;
                            Image img = oci.Thumbnail;
                            lbobj.Items.Add(a);
                        }
                        else //not found in chache 
                        {
                            try
                            {
                                SimPe.PackedFiles.Wrapper.Cpf cpf = new SimPe.PackedFiles.Wrapper.Cpf();
                                nrefitem.FileDescriptor.UserData = nrefitem.Package.Read(nrefitem.FileDescriptor).UncompressedData;
                                cpf.ProcessData(nrefitem);
                                if (cpf.GetItem("name").StringValue.Length < 3) continue;

                                SimPe.Cache.ObjectCacheItem oci = new SimPe.Cache.ObjectCacheItem();
                                oci.FileDescriptor = nrefitem.FileDescriptor;
                                oci.LocalGroup = nrefitem.LocalGroup;
                                oci.ObjectType = ObjectTypes.Outfit;
                                oci.ObjectFileName = cpf.GetItem("name").StringValue;
                                oci.Useable = true;
                                oci.Class = SimPe.Cache.ObjectClass.Skin;

                                Data.Alias a = new Data.Alias(nrefitem.FileDescriptor.Instance, cpf.GetItem("name").StringValue);
                                object[] o = new object[3];
                                o[0] = nrefitem.FileDescriptor;
                                o[1] = nrefitem.LocalGroup;
                                o[2] = nrefitem.FileDescriptor.Instance;

                                a.Name = cpf.GetItem("name").StringValue;

                                a.Tag = o;
                                // Image img = GetFumbnail(nrefitem.FileDescriptor.Group, nrefitem.FileDescriptor.SubType, nrefitem.FileDescriptor.Instance);

                                //create a cache Item
                                cachechg = true;
                                oci.Name = a.Name;
                                oci.ModelName = "";
                                oci.Thumbnail = null;

                                cachefile.AddItem(oci, nrefitem.Package.FileName);
                                lbobj.Items.Add(a);
                            }
                            catch { }
                        } // if not in cache
                    } //foreach txt

                    SaveCacheIndex();
                    WaitingScreen.UpdateMessage("Sorting Items");
                    lbobj.Sorted = true;
                    lbobj.EndUpdate();
                }
                finally { WaitingScreen.Stop(this); }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SkinWorkshop));
            this.lbobj = new System.Windows.Forms.ListBox();
            this.btclone = new System.Windows.Forms.Button();
            this.pb = new System.Windows.Forms.PictureBox();
            this.cbfix = new System.Windows.Forms.CheckBox();
            this.cbgid = new System.Windows.Forms.CheckBox();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.tbseek = new System.Windows.Forms.TextBox();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.taskBox2 = new System.Windows.Forms.GroupBox();
            this.taskBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.panel1.SuspendLayout();
            this.taskBox2.SuspendLayout();
            this.taskBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbobj
            // 
            this.lbobj.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbobj.IntegralHeight = false;
            this.lbobj.ItemHeight = 16;
            this.lbobj.Location = new System.Drawing.Point(6, 71);
            this.lbobj.Name = "lbobj";
            this.lbobj.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbobj.Size = new System.Drawing.Size(485, 248);
            this.lbobj.TabIndex = 0;
            this.lbobj.SelectedIndexChanged += new System.EventHandler(this.Select);
            // 
            // btclone
            // 
            this.btclone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btclone.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btclone.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btclone.Location = new System.Drawing.Point(400, 141);
            this.btclone.Name = "btclone";
            this.btclone.Size = new System.Drawing.Size(75, 23);
            this.btclone.TabIndex = 1;
            this.btclone.Text = "Start";
            this.btclone.Click += new System.EventHandler(this.Start);
            // 
            // pb
            // 
            this.pb.BackColor = System.Drawing.Color.Transparent;
            this.pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb.Location = new System.Drawing.Point(7, 40);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(128, 128);
            this.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb.TabIndex = 6;
            this.pb.TabStop = false;
            // 
            // cbfix
            // 
            this.cbfix.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbfix.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbfix.Location = new System.Drawing.Point(152, 77);
            this.cbfix.Name = "cbfix";
            this.cbfix.Size = new System.Drawing.Size(224, 24);
            this.cbfix.TabIndex = 5;
            this.cbfix.Text = "Fix Cloned Files (sug. by.  wes_h)";
            // 
            // cbgid
            // 
            this.cbgid.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbgid.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbgid.Location = new System.Drawing.Point(152, 47);
            this.cbgid.Name = "cbgid";
            this.cbgid.Size = new System.Drawing.Size(248, 24);
            this.cbgid.TabIndex = 2;
            this.cbgid.Text = "Set Custom Group ID (0x1c050000)";
            // 
            // sfd
            // 
            this.sfd.Filter = "Package File (*.package)|*.package|All Files (*.*)|*.*";
            this.sfd.Title = "Alternative Colour Pacakge";
            // 
            // tbseek
            // 
            this.tbseek.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbseek.Location = new System.Drawing.Point(6, 44);
            this.tbseek.Name = "tbseek";
            this.tbseek.Size = new System.Drawing.Size(485, 23);
            this.tbseek.TabIndex = 3;
            this.tbseek.TextChanged += new System.EventHandler(this.SeekItem);
            // 
            // ofd
            // 
            this.ofd.Filter = "Package File (*.package)|*.package|All Files (*.*)|*.*";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.taskBox2);
            this.panel1.Controls.Add(this.taskBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(504, 518);
            this.panel1.TabIndex = 5;
            // 
            // taskBox2
            // 
            this.taskBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.taskBox2.BackColor = System.Drawing.Color.Transparent;
            this.taskBox2.Controls.Add(this.cbfix);
            this.taskBox2.Controls.Add(this.btclone);
            this.taskBox2.Controls.Add(this.pb);
            this.taskBox2.Controls.Add(this.cbgid);
            this.taskBox2.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.taskBox2.HeaderText = "Settings";
            this.taskBox2.IconLocation = new System.Drawing.Point(4, 12);
            this.taskBox2.IconSize = new System.Drawing.Size(32, 32);
            this.taskBox2.Location = new System.Drawing.Point(3, 340);
            this.taskBox2.Name = "taskBox2";
            this.taskBox2.Padding = new System.Windows.Forms.Padding(4, 44, 4, 4);
            this.taskBox2.Size = new System.Drawing.Size(498, 175);
            this.taskBox2.TabIndex = 6;
            // 
            // taskBox1
            // 
            this.taskBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.taskBox1.BackColor = System.Drawing.Color.Transparent;
            this.taskBox1.Controls.Add(this.tbseek);
            this.taskBox1.Controls.Add(this.lbobj);
            this.taskBox1.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.taskBox1.HeaderText = "Clothing Listing";
            this.taskBox1.IconLocation = new System.Drawing.Point(4, 12);
            this.taskBox1.IconSize = new System.Drawing.Size(32, 32);
            this.taskBox1.Location = new System.Drawing.Point(3, 3);
            this.taskBox1.Name = "taskBox1";
            this.taskBox1.Padding = new System.Windows.Forms.Padding(4, 44, 4, 4);
            this.taskBox1.Size = new System.Drawing.Size(498, 326);
            this.taskBox1.TabIndex = 5;
            // 
            // SkinWorkshop
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(504, 518);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(520, 320);
            this.Name = "SkinWorkshop";
            this.Opacity = 0.96;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Skin Workshop (biggest thanks to RGiles and Numenor)";
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.panel1.ResumeLayout(false);
            this.taskBox2.ResumeLayout(false);
            this.taskBox1.ResumeLayout(false);
            this.taskBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
		public Interfaces.Files.IPackageFile Execute(SimPe.Interfaces.Files.IPackageFile simpe_pkg) 		
		{			 			
			this.simpe_pkg = simpe_pkg;

            // WaitingScreen.Wait();
			FileTable.FileIndex.Load();
			package = null;

			BuildListing();			
			RemoteControl.ShowSubForm(this);

			WaitingScreen.Stop(this);
			return package;
		}

		void BuildListing() 
		{
			BuildListing(Data.MetaData.GZPS);
		}
	

		private void Select(object sender, System.EventArgs e) // Fuck
		{
			if (tbseek.Tag != null) return;
			btclone.Enabled = false;
			btclone.Refresh();
			if (lbobj.SelectedIndex<0) return;
			btclone.Enabled = true;
			btclone.Refresh();

			IAlias a = (IAlias)lbobj.Items[lbobj.SelectedIndex];
			tbseek.Tag = true;
			if (sender!=null) tbseek.Text = a.Name;
			tbseek.Tag = null;
            // pb.Image = GetFumbnail((uint)a.Tag[1], 0, (uint)a.Tag[2]);
		}

        private void Start(object sender, System.EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                IAlias a = new Data.Alias(0, "");
                Interfaces.Files.IPackedFileDescriptor pfd = null;
                uint localgroup = Data.MetaData.LOCAL_GROUP;

                if (lbobj.SelectedIndex >= 0)
                {
                    a = (IAlias)lbobj.Items[lbobj.SelectedIndex];
                    pfd = (Interfaces.Files.IPackedFileDescriptor)a.Tag[0];
                    localgroup = (uint)a.Tag[1];
                }
                
                WaitingScreen.Wait();
                try { this.RecolorClone(pfd, localgroup, false, false, false); }
                finally { WaitingScreen.Stop(this); }

                FixObject fo = new FixObject(package, FixVersion.UniversityReady, true);
                System.Collections.Hashtable map = null;

                if (this.cbfix.Checked)
                {
                    map = fo.GetNameMap(true);
                    if (map == null) return;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        WaitingScreen.Wait();
                        try
                        {
                            package.FileName = sfd.FileName;
                            fo.Fix(map, true);
                            package.Save();
                        }
                        finally { WaitingScreen.Stop(this); }

                    }
                    else
                    {
                        package = null;
                    }
                }

                if ((this.cbgid.Checked) && (package != null))
                {
                    WaitingScreen.Wait();
                    try
                    {
                        fo.FixGroup();
                        if (this.cbfix.Checked) package.Save();

                    }
                    finally { WaitingScreen.Stop(this); }
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
                this.Cursor = Cursors.Default;
            }
        }

        #region Thumbnails
        // Not used, I can't resolve FumbnailHash yet
        /*
        public static Image GetFumbnail(uint group, uint instahi, uint instans)
        {
            uint inst = FumbnailHash(group, instahi, instans);

            Interfaces.Files.IPackedFileDescriptor pfd = fumbs.FindFile(0x0C7E9A76, instans, 0xFFFFFFFF, inst);
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

            //0x6C2A22C3 0x0C7E9A76
            Interfaces.Files.IPackedFileDescriptor[] pfds = thumbs.FindFile(0x0C7E9A76, 0, inst);
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
			Interfaces.Files.IPackedFileDescriptor[] pfds = pkg.FindFiles(0x4C697E5A);

			string name = matd.FileName.Trim().ToLower();

			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				pfd.UserData = pkg.Read(pfd).UncompressedData;
				SimPe.PackedFiles.Wrapper.Cpf cpf = new SimPe.PackedFiles.Wrapper.Cpf();
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
		public static string[] BaseClone(Interfaces.Files.IPackedFileDescriptor pfd, uint localgroup, SimPe.Packages.File package) 
		{
			//Get the Base Object Data from the Objects.package File
			
			Interfaces.Scenegraph.IScenegraphFileIndexItem[] files = FileTable.FileIndex.FindFileByGroupAndInstance(localgroup, pfd.LongInstance);

			ArrayList list = new ArrayList();
			foreach (Interfaces.Scenegraph.IScenegraphFileIndexItem item in files) 
			{
				Interfaces.Files.IPackedFile file = item.Package.Read(item.FileDescriptor);

				SimPe.Packages.PackedFileDescriptor npfd = new SimPe.Packages.PackedFileDescriptor();

				npfd.UserData = file.UncompressedData;
				npfd.Group = item.FileDescriptor.Group;
				npfd.Instance = item.FileDescriptor.Instance;
				npfd.SubType = item.FileDescriptor.SubType;
				npfd.Type = item.FileDescriptor.Type;

				if (package.FindFile(npfd)==null)
                    package.Add(npfd);
			}

			string[] refname = new string[0];

			return refname;
		}


		/// <summary>
		/// Clone an object based on way Files are linked
		/// </summary>
		/// <param name="pfd"></param>
		/// <param name="localgroup"></param>
		/// <param name="onlydefault"></param>
		protected void RecolorClone(Interfaces.Files.IPackedFileDescriptor pfd, uint localgroup, bool onlydefault, bool wallmask, bool anim) 
		{
			package = SimPe.Packages.GeneratableFile.LoadFromStream((System.IO.BinaryReader)null);

			//Get the Base Object Data from the Objects.package File
			string[] modelname = BaseClone(pfd, localgroup, package);
			ObjectCloner objclone = new ObjectCloner(package);
			ArrayList exclude = new ArrayList();

            exclude.Add("tsMaterialsMeshName");
            exclude.Add("TXTR");

			//do the recolor
			objclone.Setup.OnlyDefaultMmats = onlydefault;
			objclone.Setup.UpdateMmatGuids = onlydefault;
			objclone.Setup.IncludeWallmask = wallmask;
			objclone.Setup.IncludeAnimationResources = anim;
			objclone.Setup.BaseResource = CloneSettings.BaseResourceType.Ref;
			objclone.RcolModelClone(modelname, exclude);

            string[] modelnames = modelname;
            modelnames = null;
            objclone.RemoveSubsetReferences(Scenegraph.GetParentSubsets(package), modelnames);
		}

        protected void ReColor(Interfaces.Files.IPackedFileDescriptor pfd, uint localgroup)
        {
            if (sfd.ShowDialog() != DialogResult.OK) return;

            //create a Cloned Object to get all needed Files for the Process
            bool old = cbgid.Checked;
            cbgid.Checked = false;
            WaitingScreen.Wait();
            try
            {
                WaitingScreen.UpdateMessage("Collecting needed Files");
                if ((package == null) && (pfd != null)) RecolorClone(pfd, localgroup, false, false, false);
            }
            finally { WaitingScreen.Stop(this); }

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
            SimPe.Packages.GeneratableFile npackage = SimPe.Packages.GeneratableFile.LoadFromStream((System.IO.BinaryReader)null);

            npackage.FileName = sfd.FileName;

            ColorOptions cs = new ColorOptions(package);
            cs.Create(npackage);

            npackage.Save();
            package = npackage;

            WaitingScreen.Stop(this);
            if (package != npackage) package = null;
        }

		private void SeekItem(object sender, System.EventArgs e)
		{
			if (tbseek.Tag!=null) return;

			tbseek.Tag = true;
			try 
			{
				string name = tbseek.Text.TrimStart().ToLower();
				if (lbobj.SelectionMode != SelectionMode.One) lbobj.ClearSelected();
				for (int i=0; i<lbobj.Items.Count; i++)
				{
					IAlias a = (IAlias)lbobj.Items[i];
					if (a.Name!=null) 
					{
						if (a.Name.TrimStart().ToLower().StartsWith(name))
						{
							tbseek.Text = a.Name.TrimStart();
							tbseek.SelectionStart = name.Length;
							tbseek.SelectionLength = Math.Max(0, tbseek.Text.Length - name.Length);
							lbobj.SelectedIndex = i;
							break;
						}

						if (a.Name.TrimStart().ToLower().StartsWith("* "+name))
						{
							tbseek.Text = a.Name.TrimStart();
							tbseek.SelectionStart = name.Length+2;
							tbseek.SelectionLength = Math.Max(0, tbseek.Text.Length - (name.Length+2));
							lbobj.SelectedIndex = i;
							break;
						}
					}
				}
			} 
			catch (Exception) {}
			finally 
			{
				tbseek.Tag = null;
				this.Select(null, null);
			}
		}
	}
}
