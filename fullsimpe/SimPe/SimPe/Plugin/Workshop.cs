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

using SimPe.Data;
using SimPe.Interfaces;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for Workshop.
	/// </summary>
	public class Workshop : Form
	{
		private TabControl tabControl2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private TextBox tbflname;
		private Button button1;
		private OpenFileDialog ofd;
		private CheckBox cbfix;
		private CheckBox cbclean;
		private CheckBox cbdefault;
		private System.Windows.Forms.TabPage tabPage3;
		private TreeView tv;
		private ImageList ilist;
		private CheckBox cbparent;
		private CheckBox cbwallmask;
		private CheckBox cbanim;
		private System.ComponentModel.IContainer components;
		private System.ComponentModel.ComponentResourceManager resources1;

		TreeNode tviapl;
		TreeNode tvideco;
		TreeNode tvielectro;
		TreeNode tvigeneral;
		TreeNode tvilight;
		TreeNode tviplumb;
		TreeNode tviseating;
		TreeNode tvisurfaces;
		TreeNode tvihobby;
		TreeNode tviaspiration;
		TreeNode tvicareer;
		TreeNode tviother;

		TreeNode tvistairs;
		TreeNode tviperson;
		TreeNode tviarchsup;
		TreeNode tvisimtype;
		TreeNode tvidoor;
		TreeNode tvimodstair;
		TreeNode tvimodstairport;
		TreeNode tvivehicle;
		TreeNode tvioutfit;
		TreeNode tvimemory;
		TreeNode tvitemplate;
		TreeNode tviwindow;

		TreeNode tvigarden;

		public Workshop()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			btclone.Enabled = false;
			btclone.Refresh();
			this.tabControl1.SelectedIndex = 1;
			lbobj.SelectionMode = SelectionMode.One;
			this.cbColor.Visible = false;
			this.cbColor.Checked = false;
			this.cbColorExt.Enabled = true;
			this.cbColorExt.Checked = true;
			this.rbColor.Enabled = true;

			this.tviapl = new TreeNode("Appliances");
			tv.Nodes.Add(tviapl);
			this.tvideco = new TreeNode("Decorative");
			tv.Nodes.Add(tvideco);
			this.tvielectro = new TreeNode("Electronics");
			tv.Nodes.Add(tvielectro);
			this.tvigeneral = new TreeNode("General");
			tv.Nodes.Add(tvigeneral);
			this.tvilight = new TreeNode("Lights");
			tv.Nodes.Add(tvilight);
			this.tviplumb = new TreeNode("Plumbing");
			tv.Nodes.Add(tviplumb);
			this.tviseating = new TreeNode("Seating");
			tv.Nodes.Add(tviseating);
			this.tvisurfaces = new TreeNode("Surfaces");
			tv.Nodes.Add(tvisurfaces);
			this.tvihobby = new TreeNode("Hobbies");
			tv.Nodes.Add(tvihobby);
			this.tviaspiration = new TreeNode("Aspiration Rewards");
			tv.Nodes.Add(tviaspiration);
			this.tvicareer = new TreeNode("Career Rewards");
			tv.Nodes.Add(tvicareer);
			this.tviother = new TreeNode("Others");
			tv.Nodes.Add(tviother);

			this.tvistairs = new TreeNode("Stairs");
			tv.Nodes.Add(tvistairs);
			this.tviperson = new TreeNode("Persons");
			tv.Nodes.Add(tviperson);
			this.tviarchsup = new TreeNode("ArchitecturalSupports");
			tv.Nodes.Add(tviarchsup);
			this.tvisimtype = new TreeNode("SimTypes");
			tv.Nodes.Add(tvisimtype);
			this.tvidoor = new TreeNode("Doors");
			tv.Nodes.Add(tvidoor);
			this.tvimodstair = new TreeNode("ModularStairs");
			tv.Nodes.Add(tvimodstair);
			this.tvimodstairport = new TreeNode("ModularStairPorts");
			tv.Nodes.Add(tvimodstairport);
			this.tvivehicle = new TreeNode("Vehicles");
			tv.Nodes.Add(tvivehicle);
			this.tvioutfit = new TreeNode("Outfits");
			tv.Nodes.Add(tvioutfit);
			this.tvimemory = new TreeNode("Memories");
			tv.Nodes.Add(tvimemory);
			this.tvitemplate = new TreeNode("Templates");
			tv.Nodes.Add(tvitemplate);
			this.tviwindow = new TreeNode("Windows");
			tv.Nodes.Add(tviwindow);

			this.tvigarden = new TreeNode("Garden");
			tv.Nodes.Add(tvigarden);
		}

		/// <summary>
		/// Clean the Group Tree
		/// </summary>
		void CleanTree()
		{
			this.tviapl.Nodes.Clear();
			this.tvideco.Nodes.Clear();
			this.tvielectro.Nodes.Clear();
			this.tvigeneral.Nodes.Clear();
			this.tvilight.Nodes.Clear();
			this.tviplumb.Nodes.Clear();
			this.tviseating.Nodes.Clear();
			this.tvisurfaces.Nodes.Clear();
			this.tvihobby.Nodes.Clear();
			this.tviaspiration.Nodes.Clear();
			this.tvicareer.Nodes.Clear();
			this.tviother.Nodes.Clear();

			this.tvistairs.Nodes.Clear();
			this.tviperson.Nodes.Clear();
			this.tviarchsup.Nodes.Clear();
			this.tvisimtype.Nodes.Clear();
			this.tvidoor.Nodes.Clear();
			this.tvimodstair.Nodes.Clear();
			this.tvimodstairport.Nodes.Clear();
			this.tvivehicle.Nodes.Clear();
			this.tvioutfit.Nodes.Clear();
			this.tvimemory.Nodes.Clear();
			this.tvitemplate.Nodes.Clear();
			this.tviwindow.Nodes.Clear();
			this.tvigarden.Nodes.Clear();

			this.ilist.Images.Clear();
			this.ilist.Images.Add(
				new Bitmap(
					this.GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.subitems.png")
				)
			);
			this.ilist.Images.Add(
				new Bitmap(
					this.GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.nothumb.png")
				)
			);
			this.ilist.Images.Add(
				new Bitmap(
					this.GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.custom.png")
				)
			);
		}

		/// <summary>
		/// Sort this Item to the Tree
		/// </summary>
		/// <param name="a"></param>
		/// <param name="img"></param>
		/// <param name="type">The Type of the Object</param>
		/// <param name="functionsort">The function SOrt Value</param>
		/// <param name="name">The name of the package where this Object was found in</param>
		/// <param name="group">The group for this Object</param>
		void PutItemToTree(
			Alias a,
			Image img,
			ObjectTypes type,
			PackedFiles.Wrapper.ObjFunctionSort functionsort,
			PackedFiles.Wrapper.ObjBuildType buildtype,
			string name,
			uint group
		)
		{
			TreeNode node = new TreeNode(
				a.Name + " (0x" + Helper.HexString(group) + ")"
			);
			node.Tag = a;
			if (img != null)
			{
				node.ImageIndex = ilist.Images.Count;
				node.SelectedImageIndex = ilist.Images.Count;
				ilist.Images.Add(ImageLoader.Preview(img, ilist.ImageSize));
			}
			else
			{
				node.ImageIndex = 1;
				if (name != null)
				{
					name = name.Trim().ToLower();
					if (
						name.StartsWith(PathProvider.SimSavegameFolder.Trim().ToLower())
					)
					{
						node.ImageIndex = 2;
					}
				}
				node.SelectedImageIndex = node.ImageIndex;
			}

			if (type == Data.ObjectTypes.Stairs)
			{
				this.tvistairs.Nodes.Add(node);
			}
			else if (type == Data.ObjectTypes.ArchitecturalSupport)
			{
				this.tviarchsup.Nodes.Add(node);
			}
			else if (type == Data.ObjectTypes.Door)
			{
				this.tvidoor.Nodes.Add(node);
			}
			else if (type == Data.ObjectTypes.Memory)
			{
				this.tvimemory.Nodes.Add(node);
			}
			else if (type == Data.ObjectTypes.ModularStairs)
			{
				this.tvimodstair.Nodes.Add(node);
			}
			else if (type == Data.ObjectTypes.ModularStairsPortal)
			{
				this.tvimodstairport.Nodes.Add(node);
			}
			else if (type == Data.ObjectTypes.Outfit)
			{
				this.tvioutfit.Nodes.Add(node);
			}
			else if (type == Data.ObjectTypes.Person)
			{
				this.tviperson.Nodes.Add(node);
			}
			else if (type == Data.ObjectTypes.SimType)
			{
				this.tvisimtype.Nodes.Add(node);
			}
			else if (type == Data.ObjectTypes.Template)
			{
				this.tvitemplate.Nodes.Add(node);
			}
			else if (type == Data.ObjectTypes.Vehicle)
			{
				this.tvivehicle.Nodes.Add(node);
			}
			else if (type == Data.ObjectTypes.Window)
			{
				this.tviwindow.Nodes.Add(node);
			}
			else
			{
				bool added = false;
				if (functionsort.InAppliances)
				{
					this.tviapl.Nodes.Add(node);
					added = true;
				}
				else if (functionsort.InDecorative)
				{
					this.tvideco.Nodes.Add(node);
					added = true;
				}
				else if (functionsort.InElectronics)
				{
					this.tvielectro.Nodes.Add(node);
					added = true;
				}
				else if (functionsort.InGeneral)
				{
					this.tvigeneral.Nodes.Add(node);
					added = true;
				}
				else if (functionsort.InLighting)
				{
					this.tvilight.Nodes.Add(node);
					added = true;
				}
				else if (functionsort.InPlumbing)
				{
					this.tviplumb.Nodes.Add(node);
					added = true;
				}
				else if (functionsort.InSeating)
				{
					this.tviseating.Nodes.Add(node);
					added = true;
				}
				else if (functionsort.InSurfaces)
				{
					this.tvisurfaces.Nodes.Add(node);
					added = true;
				}
				else if (functionsort.InHobbies)
				{
					this.tvihobby.Nodes.Add(node);
					added = true;
				}
				else if (functionsort.InAspirationRewards)
				{
					this.tviaspiration.Nodes.Add(node);
					added = true;
				}
				else if (functionsort.InCareerRewards)
				{
					this.tvicareer.Nodes.Add(node);
					added = true;
				}
				else if (buildtype.InGarden)
				{
					this.tvigarden.Nodes.Add(node);
					added = true;
				}

				if (!added)
				{
					this.tviother.Nodes.Add(node);
				}
			}
		}

		#region Cache Handling
		Cache.ObjectLoaderCacheFile cachefile;
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
			if (cachefile != null)
			{
				return;
			}

			cachechg = false;
			cachefile = new Cache.ObjectLoaderCacheFile();

			if (!Helper.WindowsRegistry.UseCache)
			{
				return;
			}

			WaitingScreen.UpdateMessage("Loading Cache");
			try
			{
				cachefile.Load(CacheFileName);
				cachefile.LoadObjects();
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				WaitingScreen.Stop();
			}
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

			cachefile.Save(CacheFileName);
		}
		#endregion

		void BuildListing()
		{
			//build Object List
			if (lbobj.Items.Count == 0)
			{
				DateTime start = DateTime.Now;
				WaitingScreen.Wait();
				this.ilist.ImageSize = new Size(
					Helper.WindowsRegistry.OWThumbSize,
					Helper.WindowsRegistry.OWThumbSize
				);
				//LoadCachIndex();
				lbobj.BeginUpdate();
				tv.BeginUpdate();
				lbobj.Items.Clear();
				this.CleanTree();
				lbobj.Sorted = false;
				lbobj.Enabled = false;
				this.tv.Enabled = false;
				tv.Sorted = false;

				Tool.Dockable.ObjectLoader ol =
					new Tool.Dockable.ObjectLoader(this.ilist);
				ol.Finished += new EventHandler(ol_Finished);
				ol.LoadedItem +=
					new Tool.Dockable.ObjectLoader.LoadItemHandler(
						ol_LoadedItem
					);
				ol.LoadData();
				WaitingScreen.Stop();
				return;
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
			this.resources1 = new System.ComponentModel.ComponentResourceManager(
				typeof(PreviewForm)
			);
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(typeof(Workshop));
			this.lbobj = new ListBox();
			this.btclone = new Button();
			this.groupBox1 = new GroupBox();
			this.pb = new PictureBox();
			this.rbColor = new RadioButton();
			this.rbClone = new RadioButton();
			this.tabControl1 = new TabControl();
			this.tClone = new System.Windows.Forms.TabPage();
			this.cbanim = new CheckBox();
			this.cbwallmask = new CheckBox();
			this.cbparent = new CheckBox();
			this.cbclean = new CheckBox();
			this.cbfix = new CheckBox();
			this.cbdefault = new CheckBox();
			this.cbgid = new CheckBox();
			this.tColor = new System.Windows.Forms.TabPage();
			this.cbColorExt = new CheckBox();
			this.cbColor = new CheckBox();
			this.sfd = new SaveFileDialog();
			this.tbseek = new TextBox();
			this.tabControl2 = new TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.tv = new TreeView();
			this.ilist = new ImageList(this.components);
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.button1 = new Button();
			this.tbflname = new TextBox();
			this.ofd = new OpenFileDialog();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tClone.SuspendLayout();
			this.tColor.SuspendLayout();
			this.tabControl2.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			//
			// lbobj
			//
			this.lbobj.Anchor = (
				(AnchorStyles)(
					(
						(
							(
								System.Windows.Forms.AnchorStyles.Top
								| System.Windows.Forms.AnchorStyles.Bottom
							) | System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.lbobj.IntegralHeight = false;
			this.lbobj.Location = new Point(8, 32);
			this.lbobj.Name = "lbobj";
			this.lbobj.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lbobj.Size = new Size(464, 192);
			this.lbobj.TabIndex = 0;
			this.lbobj.SelectedIndexChanged += new EventHandler(this.Select);
			//
			// btclone
			//
			this.btclone.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Bottom
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.btclone.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btclone.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.btclone.Location = new Point(408, 212);
			this.btclone.Name = "btclone";
			this.btclone.Size = new Size(75, 23);
			this.btclone.TabIndex = 1;
			this.btclone.Text = "Start";
			this.btclone.Click += new EventHandler(this.Start);
			//
			// groupBox1
			//
			this.groupBox1.Anchor = (
				(AnchorStyles)(
					(
						(
							System.Windows.Forms.AnchorStyles.Bottom
							| System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.groupBox1.Controls.Add(this.pb);
			this.groupBox1.Controls.Add(this.rbColor);
			this.groupBox1.Controls.Add(this.rbClone);
			this.groupBox1.Controls.Add(this.tabControl1);
			this.groupBox1.Controls.Add(this.btclone);
			this.groupBox1.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.groupBox1.Location = new Point(8, 272);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(488, 240);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Settings";
			//
			// pb
			//
			this.pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pb.Location = new Point(8, 24);
			this.pb.Name = "pb";
			this.pb.Size = new Size(128, 128);
			this.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pb.TabIndex = 6;
			this.pb.TabStop = false;
			//
			// rbColor
			//
			this.rbColor.Checked = true;
			this.rbColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rbColor.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.rbColor.Location = new Point(16, 176);
			this.rbColor.Name = "rbColor";
			this.rbColor.Size = new Size(120, 24);
			this.rbColor.TabIndex = 5;
			this.rbColor.TabStop = true;
			this.rbColor.Text = "Colour Options";
			this.rbColor.CheckedChanged += new EventHandler(
				this.rbColor_CheckedChanged
			);
			//
			// rbClone
			//
			this.rbClone.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rbClone.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.rbClone.Location = new Point(16, 156);
			this.rbClone.Name = "rbClone";
			this.rbClone.Size = new Size(120, 24);
			this.rbClone.TabIndex = 4;
			this.rbClone.Text = "Clone";
			this.rbClone.CheckedChanged += new EventHandler(
				this.rbClone_CheckedChanged
			);
			//
			// tabControl1
			//
			this.tabControl1.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.tabControl1.Controls.Add(this.tClone);
			this.tabControl1.Controls.Add(this.tColor);
			this.tabControl1.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.tabControl1.Location = new Point(150, 24);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new Size(328, 184);
			this.tabControl1.TabIndex = 3;
			this.tabControl1.SelectedIndexChanged += new EventHandler(
				this.TabChanged
			);
			//
			// tClone
			//
			this.tClone.Controls.Add(this.cbanim);
			this.tClone.Controls.Add(this.cbwallmask);
			this.tClone.Controls.Add(this.cbparent);
			this.tClone.Controls.Add(this.cbclean);
			this.tClone.Controls.Add(this.cbfix);
			this.tClone.Controls.Add(this.cbdefault);
			this.tClone.Controls.Add(this.cbgid);
			this.tClone.Location = new Point(4, 22);
			this.tClone.Name = "tClone";
			this.tClone.Size = new Size(320, 158);
			this.tClone.TabIndex = 0;
			this.tClone.Text = "Clone Settings";
			//
			// cbanim
			//
			this.cbanim.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbanim.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cbanim.Location = new Point(8, 128);
			this.cbanim.Name = "cbanim";
			this.cbanim.Size = new Size(120, 24);
			this.cbanim.TabIndex = 9;
			this.cbanim.Text = "Pull Animations";
			//
			// cbwallmask
			//
			this.cbwallmask.Checked = true;
			this.cbwallmask.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbwallmask.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbwallmask.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cbwallmask.Location = new Point(8, 108);
			this.cbwallmask.Name = "cbwallmask";
			this.cbwallmask.Size = new Size(272, 24);
			this.cbwallmask.TabIndex = 8;
			this.cbwallmask.Text = "Pull Wallmasks (as described by Numenor)";
			//
			// cbparent
			//
			this.cbparent.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbparent.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cbparent.Location = new Point(8, 88);
			this.cbparent.Name = "cbparent";
			this.cbparent.Size = new Size(192, 24);
			this.cbparent.TabIndex = 7;
			this.cbparent.Text = "Create a stand-alone object";
			this.cbparent.CheckedChanged += new EventHandler(
				this.cbfix_CheckedChanged
			);
			//
			// cbclean
			//
			this.cbclean.Checked = true;
			this.cbclean.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbclean.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbclean.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cbclean.Location = new Point(24, 48);
			this.cbclean.Name = "cbclean";
			this.cbclean.Size = new Size(272, 24);
			this.cbclean.TabIndex = 6;
			this.cbclean.Text = "Remove useless Files (sug. by.  Numenor)";
			//
			// cbfix
			//
			this.cbfix.Checked = true;
			this.cbfix.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbfix.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbfix.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cbfix.Location = new Point(8, 28);
			this.cbfix.Name = "cbfix";
			this.cbfix.Size = new Size(224, 24);
			this.cbfix.TabIndex = 5;
			this.cbfix.Text = "Fix Cloned Files (sug. by.  wes_h)";
			this.cbfix.CheckedChanged += new EventHandler(
				this.cbfix_CheckedChanged
			);
			//
			// cbdefault
			//
			this.cbdefault.Checked = true;
			this.cbdefault.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbdefault.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbdefault.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cbdefault.Location = new Point(8, 68);
			this.cbdefault.Name = "cbdefault";
			this.cbdefault.Size = new Size(224, 24);
			this.cbdefault.TabIndex = 3;
			this.cbdefault.Text = "Pull only default Colour";
			this.cbdefault.CheckedChanged += new EventHandler(
				this.cbRCOLClone_CheckedChanged
			);
			//
			// cbgid
			//
			this.cbgid.Checked = true;
			this.cbgid.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbgid.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbgid.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cbgid.Location = new Point(8, 8);
			this.cbgid.Name = "cbgid";
			this.cbgid.Size = new Size(248, 24);
			this.cbgid.TabIndex = 2;
			this.cbgid.Text = "Set Custom Group ID (0x1c050000)";
			//
			// tColor
			//
			this.tColor.Controls.Add(this.cbColorExt);
			this.tColor.Controls.Add(this.cbColor);
			this.tColor.Location = new Point(4, 22);
			this.tColor.Name = "tColor";
			this.tColor.Size = new Size(320, 158);
			this.tColor.TabIndex = 1;
			this.tColor.Text = "Colour Options";
			//
			// cbColorExt
			//
			this.cbColorExt.Checked = true;
			this.cbColorExt.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbColorExt.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbColorExt.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cbColorExt.Location = new Point(8, 8);
			this.cbColorExt.Name = "cbColorExt";
			this.cbColorExt.Size = new Size(224, 24);
			this.cbColorExt.TabIndex = 4;
			this.cbColorExt.Text = "Create Colour Extension Package";
			//
			// cbColor
			//
			this.cbColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbColor.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cbColor.Location = new Point(8, 28);
			this.cbColor.Name = "cbColor";
			this.cbColor.Size = new Size(224, 24);
			this.cbColor.TabIndex = 3;
			this.cbColor.Text = "Enable All Colour Options";
			//
			// sfd
			//
			this.sfd.Filter = "Package File (*.package)|*.package|All Files (*.*)|*.*";
			this.sfd.Title = "Alternative Colour Pacakge";
			//
			// tbseek
			//
			this.tbseek.Anchor = (
				(AnchorStyles)(
					(
						(
							System.Windows.Forms.AnchorStyles.Top
							| System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.tbseek.Location = new Point(8, 8);
			this.tbseek.Name = "tbseek";
			this.tbseek.Size = new Size(464, 21);
			this.tbseek.TabIndex = 3;
			this.tbseek.TextChanged += new EventHandler(this.SeekItem);
			//
			// tabControl2
			//
			this.tabControl2.Anchor = (
				(AnchorStyles)(
					(
						(
							(
								System.Windows.Forms.AnchorStyles.Top
								| System.Windows.Forms.AnchorStyles.Bottom
							) | System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.tabControl2.Controls.Add(this.tabPage1);
			this.tabControl2.Controls.Add(this.tabPage3);
			this.tabControl2.Controls.Add(this.tabPage2);
			this.tabControl2.Location = new Point(8, 8);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 1;
			this.tabControl2.Size = new Size(488, 256);
			this.tabControl2.TabIndex = 4;
			this.tabControl2.SelectedIndexChanged += new EventHandler(
				this.TabChange
			);
			//
			// tabPage1
			//
			this.tabPage1.Controls.Add(this.lbobj);
			this.tabPage1.Controls.Add(this.tbseek);
			this.tabPage1.Location = new Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new Size(480, 230);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Object Listing";
			//
			// tabPage3
			//
			this.tabPage3.Controls.Add(this.tv);
			this.tabPage3.Location = new Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new Size(480, 230);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Grouped Objects";
			//
			// tv
			//
			this.tv.Anchor = (
				(AnchorStyles)(
					(
						(
							(
								System.Windows.Forms.AnchorStyles.Top
								| System.Windows.Forms.AnchorStyles.Bottom
							) | System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.tv.HideSelection = false;
			this.tv.ImageIndex = 0;
			this.tv.ImageList = this.ilist;
			this.tv.Location = new Point(8, 8);
			this.tv.Name = "tv";
			this.tv.SelectedImageIndex = 0;
			this.tv.Size = new Size(464, 216);
			this.tv.TabIndex = 0;
			this.tv.AfterSelect += new TreeViewEventHandler(
				this.SelectTv
			);
			//
			// ilist
			//
			this.ilist.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.ilist.ImageSize = new Size(16, 16);
			this.ilist.TransparentColor = System.Drawing.Color.Transparent;
			//
			// tabPage2
			//
			this.tabPage2.Controls.Add(this.button1);
			this.tabPage2.Controls.Add(this.tbflname);
			this.tabPage2.Location = new Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new Size(480, 230);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Load Object";
			//
			// button1
			//
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new Point(397, 32);
			this.button1.Name = "button1";
			this.button1.Size = new Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Browse...";
			this.button1.Click += new EventHandler(this.button1_Click);
			//
			// tbflname
			//
			this.tbflname.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Left
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.tbflname.Location = new Point(8, 12);
			this.tbflname.Name = "tbflname";
			this.tbflname.ReadOnly = true;
			this.tbflname.Size = new Size(464, 21);
			this.tbflname.TabIndex = 0;
			//
			// ofd
			//
			this.ofd.Filter = "Package File (*.package)|*.package|All Files (*.*)|*.*";
			//
			// Workshop
			//
			this.AutoScaleBaseSize = new Size(6, 14);
			this.ClientSize = new Size(512, 518);
			this.Controls.Add(this.tabControl2);
			this.Controls.Add(this.groupBox1);
			this.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.FormBorderStyle = System
				.Windows
				.Forms
				.FormBorderStyle
				.SizableToolWindow;
			this.Icon = ((Icon)(resources1.GetObject("$this.Icon")));
			this.MinimumSize = new Size(520, 320);
			this.Name = "Workshop";
			this.Text = "Object Workshop (biggest thanks to RGiles and Numenor)";
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tClone.ResumeLayout(false);
			this.tColor.ResumeLayout(false);
			this.tabControl2.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.ResumeLayout(false);
		}
		#endregion

		private ListBox lbobj;
		private Button btclone;

		Packages.GeneratableFile package;
		private GroupBox groupBox1;
		private CheckBox cbgid;
		private TabControl tabControl1;
		private System.Windows.Forms.TabPage tClone;
		private System.Windows.Forms.TabPage tColor;
		private RadioButton rbClone;
		private RadioButton rbColor;
		private CheckBox cbColor;
		private CheckBox cbColorExt;
		private SaveFileDialog sfd;
		private TextBox tbseek;
		private PictureBox pb;
		IProviderRegistry prov;
		Interfaces.Files.IPackageFile simpe_pkg;

		public Interfaces.Files.IPackageFile Execute(
			IProviderRegistry prov,
			Interfaces.Files.IPackageFile simpe_pkg
		)
		{
			this.prov = prov;
			this.simpe_pkg = simpe_pkg;

			prov.OpcodeProvider.LoadPackage();
			if (prov.OpcodeProvider.BasePackage == null)
			{
				MessageBox.Show(
					"The objects.package was not found.\n\nPlease set the Path to your Sims 2 installation in the Extra->Options... Dialog."
				);
				return null;
			}
			package = null;

			if (!Helper.WindowsRegistry.LoadOWFast)
			{
				BuildListing();
			}
			else
			{
				tabControl2.SelectedIndex = 2;
			}

			RemoteControl.ShowSubForm(this);

			WaitingScreen.Stop(this);
			return package;
		}

		private void Select(object sender, EventArgs e)
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

			if (a.Tag[2] == null)
			{
				pb.Image = null;
			}
			else
			{
				pb.Image = GetThumbnail((uint)a.Tag[1], (string)a.Tag[2]);
			}
		}

		private void Start(object sender, EventArgs e)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				IAlias a = new Alias(0, "");
				Interfaces.Files.IPackedFileDescriptor pfd = null;
				uint localgroup = Data.MetaData.LOCAL_GROUP;

				if ((lbobj.SelectedIndex >= 0) && (tabControl2.SelectedIndex == 0))
				{
					a = (IAlias)lbobj.Items[lbobj.SelectedIndex];
					pfd = (Interfaces.Files.IPackedFileDescriptor)a.Tag[0];
					localgroup = (uint)a.Tag[1];
				}

				if ((tv.SelectedNode != null) && (tabControl2.SelectedIndex == 1))
				{
					if (tv.SelectedNode.Tag != null)
					{
						a = (IAlias)tv.SelectedNode.Tag;
						pfd = (Interfaces.Files.IPackedFileDescriptor)a.Tag[0];
						localgroup = (uint)a.Tag[1];
					}
					else
					{
						return;
					}
				}

				if (this.rbClone.Checked)
				{
					if (tabControl2.SelectedIndex < 2)
					{
						WaitingScreen.Wait();
						try
						{
							this.RecolorClone(
								pfd,
								localgroup,
								this.cbdefault.Checked,
								this.cbwallmask.Checked,
								this.cbanim.Checked
							);
						}
						finally
						{
							WaitingScreen.Stop(this);
						}
					}

					FixObject fo = new FixObject(
						package,
						FixVersion.UniversityReady,
						true
					);
					Hashtable map = null;

					if (this.cbfix.Checked)
					{
						map = fo.GetNameMap(true);
						if (map == null)
						{
							return;
						}
					}

					if (this.cbfix.Checked)
					{
						if (sfd.ShowDialog() == DialogResult.OK)
						{
							WaitingScreen.Wait();
							try
							{
								package.FileName = sfd.FileName;
								fo.Fix(map, true);

								if (cbclean.Checked)
								{
									fo.CleanUp();
								}

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

					if ((this.cbgid.Checked) && (package != null))
					{
						WaitingScreen.Wait();
						try
						{
							fo.FixGroup();
							if (this.cbfix.Checked)
							{
								package.Save();
							}
						}
						finally
						{
							WaitingScreen.Stop(this);
						}
					}
				}
				else //if Recolor
				{
					if (this.cbColor.Checked)
					{
						cbColorExt.Checked = false;
					}

					if (tabControl2.SelectedIndex == 0)
					{
						foreach (IAlias ia in lbobj.SelectedItems)
						{
							pfd = (Interfaces.Files.IPackedFileDescriptor)ia.Tag[0];
							localgroup = (uint)ia.Tag[1];
							package = null;
							ReColor(pfd, localgroup);
						}
					}
					else if (tabControl2.SelectedIndex == 1)
					{
						package = null;
						ReColor(pfd, localgroup);
					}
					else
					{
						ReColor(null, Data.MetaData.LOCAL_GROUP);
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
				this.Cursor = Cursors.Default;
			}
		}

		#region Thumbnails
		/// <summary>
		/// Returns the Instance Number for the assigned Thumbnail
		/// </summary>
		/// <param name="group">The Group of the Object</param>
		/// <param name="modelname">The Name of teh Model (inst 0x86)</param>
		/// <returns>Instance of the Thumbnail</returns>
		public static uint ThumbnailHash(uint group, string modelname)
		{
			string name = group.ToString() + modelname;
			return (uint)
				Hashes.ToLong(
					Hashes.Crc32.ComputeHash(Helper.ToBytes(name.Trim().ToLower()))
				);
		}

		static Packages.File thumbs = null;

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
			if (thumbs == null)
			{
				thumbs = SimPe.Packages.File.LoadFromFile(
					System.IO.Path.Combine(
						PathProvider.SimSavegameFolder,
						"Thumbnails\\ObjectThumbnails.package"
					)
				);
				thumbs.Persistent = true;
			}

			//0x6C2A22C3
			Interfaces.Files.IPackedFileDescriptor[] pfds = thumbs.FindFile(
				0xAC2950C1,
				0,
				inst
			);
			if (pfds.Length > 0)
			{
				Interfaces.Files.IPackedFileDescriptor pfd = pfds[0];
				try
				{
					PackedFiles.Wrapper.Picture pic =
						new PackedFiles.Wrapper.Picture();
					pic.ProcessData(pfd, thumbs);
					Bitmap bm = (Bitmap)
						ImageLoader.Preview(pic.Image, WaitingScreen.ImageSize);
					if (WaitingScreen.Running)
					{
						WaitingScreen.Update(bm, message);
					}

					return pic.Image;
				}
				catch (Exception) { }
			}
			return null;
		}
		#endregion

		//Returns all MMAT Files in a Package containing a reference to the MATD
		protected static Interfaces.Files.IPackedFileDescriptor[] FindMMAT(
			Rcol matd,
			string filename
		)
		{
			Packages.File pkg = SimPe.Packages.File.LoadFromFile(filename);

			ArrayList list = new ArrayList();
			Interfaces.Files.IPackedFileDescriptor[] pfds = pkg.FindFiles(0x4C697E5A);

			string name = matd.FileName.Trim().ToLower();

			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				pfd.UserData = pkg.Read(pfd).UncompressedData;
				PackedFiles.Wrapper.Cpf cpf = new PackedFiles.Wrapper.Cpf();
				cpf.ProcessData(pfd, pkg);

				string mmatname =
					cpf.GetItem("name").StringValue.Trim().ToLower() + "_txmt";
				if (mmatname == name)
				{
					list.Add(pfd);
				}
			}

			pfds = new Interfaces.Files.IPackedFileDescriptor[list.Count];
			list.CopyTo(pfds);

			return pfds;
		}

		//SimPe.Packages.File[] objpkgs = null;
		/// <summary>
		/// Reads all Data from the Objects.package blonging to the same group as the passed pfd
		/// </summary>
		/// <param name="pfd">Desciptor for one of files belonging to the Object (Name Map)</param>
		/// <param name="objpkg">The Object Package you wanna process</param>
		/// <param name="package">The package that should get the Files</param>
		/// <returns>The Modlename of that Object or null if none</returns>
		public static string[] BaseClone(
			Interfaces.Files.IPackedFileDescriptor pfd,
			uint localgroup,
			Packages.File package
		)
		{
			//Get the Base Object Data from the Objects.package File

			Interfaces.Scenegraph.IScenegraphFileIndexItem[] files =
				FileTable.FileIndex.FindFileByGroup(localgroup);

			ArrayList list = new ArrayList();
			foreach (Interfaces.Scenegraph.IScenegraphFileIndexItem item in files)
			{
				Interfaces.Files.IPackedFile file = item.Package.Read(
					item.FileDescriptor
				);

				Packages.PackedFileDescriptor npfd =
					new Packages.PackedFileDescriptor();

				npfd.UserData = file.UncompressedData;
				npfd.Group = item.FileDescriptor.Group;
				npfd.Instance = item.FileDescriptor.Instance;
				npfd.SubType = item.FileDescriptor.SubType;
				npfd.Type = item.FileDescriptor.Type;

				if (package.FindFile(npfd) == null)
				{
					package.Add(npfd);
				}

				if ((npfd.Instance == 0x85) && (npfd.Type == Data.MetaData.STRING_FILE))
				{
					PackedFiles.Wrapper.Str str =
						new PackedFiles.Wrapper.Str();
					str.ProcessData(npfd, item.Package);
					PackedFiles.Wrapper.StrItemList items = str.LanguageItems(1);
					for (int i = 1; i < items.Length; i++)
					{
						list.Add(items[i].Title);
					}
					//if (items.Length>1) refname = items[1].Title;
				}
			}

			string[] refname = new string[list.Count];
			list.CopyTo(refname);

			return refname;
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
			package = SimPe.Packages.GeneratableFile.LoadFromStream(
				(System.IO.BinaryReader)null
			);

			//Get the Base Object Data from the Objects.package File
			string[] modelname = BaseClone(pfd, localgroup, package);
			ObjectCloner objclone = new ObjectCloner(package);
			ArrayList exclude = new ArrayList();

			//allways for recolors
			if (this.rbColor.Checked)
			{
				exclude.Add("stdMatEnvCubeTextureName");
				exclude.Add("TXTR");
			}
			else
			{
				exclude.Add("tsMaterialsMeshName");

				//for clones only when cbparent is not checked
				//if (!this.cbparent.Checked)
				{
					exclude.Add("TXTR");
					exclude.Add("stdMatEnvCubeTextureName");
				}
			}

			//do the recolor
			objclone.Setup.OnlyDefaultMmats = onlydefault;
			objclone.Setup.UpdateMmatGuids = onlydefault;
			objclone.Setup.IncludeWallmask = wallmask;
			objclone.Setup.IncludeAnimationResources = anim;
			objclone.RcolModelClone(modelname, exclude);

			//for clones only when cbparent is checked
			if ((this.cbparent.Checked) && (!this.rbColor.Checked))
			{
				string[] names = Scenegraph.LoadParentModelNames(package, true);
				Packages.File pkg = SimPe.Packages.File.LoadFromFile(null);

				ObjectCloner pobj = new ObjectCloner(pkg);
				pobj.Setup.OnlyDefaultMmats = onlydefault;
				pobj.Setup.UpdateMmatGuids = onlydefault;
				pobj.Setup.IncludeWallmask = wallmask;
				pobj.Setup.IncludeAnimationResources = anim;
				pobj.RcolModelClone(names, exclude);
				pobj.AddParentFiles(modelname, package);
			}

			//for clones only when cbparent is not checked
			if ((!this.cbparent.Checked) && (!this.rbColor.Checked))
			{
				string[] modelnames = modelname;
				if (!cbclean.Checked)
				{
					modelnames = null;
				}

				objclone.RemoveSubsetReferences(
					Scenegraph.GetParentSubsets(package),
					modelnames
				);
			}
		}

		protected void ReColor(
			Interfaces.Files.IPackedFileDescriptor pfd,
			uint localgroup
		)
		{
			// we need packages in the Gmaes and the Download Folder

			if (
				SimPe.PathProvider.Global.EPInstalled < 16
				&& (
					(!System.IO.File.Exists(ScenegraphHelper.GMND_PACKAGE))
					|| (!System.IO.File.Exists(ScenegraphHelper.MMAT_PACKAGE))
				)
				&& (!this.cbColor.Checked)
			)
			{
				if (
					MessageBox.Show(
						Localization.Manager.GetString("OW_Warning"),
						"Warning",
						MessageBoxButtons.YesNo
					) == DialogResult.No
				)
				{
					return;
				}
			}

			if (this.cbColorExt.Checked)
			{
				if (sfd.ShowDialog() != DialogResult.OK)
				{
					return;
				}
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

				cbgid.Checked = old;

				if (this.cbColor.Checked)
				{
					ObjectRecolor or = new ObjectRecolor(package);
					or.EnableColorOptions();
					or.LoadReferencedMATDs();

					//load all Pending Textures
					ObjectCloner oc = new ObjectCloner(package);
				}

				Packages.GeneratableFile dn_pkg = null;
				if (System.IO.File.Exists(ScenegraphHelper.GMND_PACKAGE))
				{
					dn_pkg = SimPe.Packages.GeneratableFile.LoadFromFile(
						ScenegraphHelper.GMND_PACKAGE
					);
				}
				else
				{
					dn_pkg = SimPe.Packages.GeneratableFile.LoadFromStream(
						(System.IO.BinaryReader)null
					);
				}

				Packages.GeneratableFile gm_pkg = null;
				if (System.IO.File.Exists(ScenegraphHelper.MMAT_PACKAGE))
				{
					gm_pkg = SimPe.Packages.GeneratableFile.LoadFromFile(
						ScenegraphHelper.MMAT_PACKAGE
					);
				}
				else
				{
					gm_pkg = SimPe.Packages.GeneratableFile.LoadFromStream(
						(System.IO.BinaryReader)null
					);
				}

				Packages.GeneratableFile npackage =
					SimPe.Packages.GeneratableFile.LoadFromStream(
						(System.IO.BinaryReader)null
					);
				//Create the Templae for an additional MMAT
				if (this.cbColorExt.Checked)
				{
					npackage.FileName = sfd.FileName;

					ColorOptions cs = new ColorOptions(package);
					cs.Create(npackage);

					npackage.Save();
					package = npackage;
				}
				if (package != npackage)
				{
					package = null;
				}
			}
			finally
			{
				WaitingScreen.Stop(this);
			}
		}

		private void rbClone_CheckedChanged(object sender, EventArgs e)
		{
			if (tabControl1.Tag != null)
			{
				return;
			}

			tabControl1.Tag = true;
			tabControl1.SelectedIndex = 0;
			tabControl1.Tag = null;
		}

		private void rbColor_CheckedChanged(object sender, EventArgs e)
		{
			if (tabControl1.Tag != null)
			{
				return;
			}

			tabControl1.Tag = true;
			tabControl1.SelectedIndex = 1;
			tabControl1.Tag = null;
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
				string name = tbseek.Text.TrimStart().ToLower();
				if (lbobj.SelectionMode != SelectionMode.One)
				{
					lbobj.ClearSelected();
				}

				for (int i = 0; i < lbobj.Items.Count; i++)
				{
					IAlias a = (IAlias)lbobj.Items[i];
					if (a.Name != null)
					{
						if (a.Name.TrimStart().ToLower().StartsWith(name))
						{
							tbseek.Text = a.Name.TrimStart();
							tbseek.SelectionStart = name.Length;
							tbseek.SelectionLength = Math.Max(
								0,
								tbseek.Text.Length - name.Length
							);
							lbobj.SelectedIndex = i;
							break;
						}

						if (a.Name.TrimStart().ToLower().StartsWith("* " + name))
						{
							tbseek.Text = a.Name.TrimStart();
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
				this.Select(null, null);
			}
		}

		private void TabChanged(object sender, EventArgs e)
		{
			if (tabControl1.Tag != null)
			{
				return;
			}

			tabControl1.Tag = true;
			if (this.tabControl1.SelectedIndex == 0)
			{
				rbClone.Checked = true;
			}
			else
			{
				rbColor.Checked = true;
			}

			tabControl1.Tag = null;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				package = SimPe.Packages.GeneratableFile.LoadFromFile(ofd.FileName);
				tbflname.Text = ofd.FileName;
				this.btclone.Enabled = System.IO.File.Exists(tbflname.Text);
				btclone.Refresh();
			}
		}

		private void cbRCOLClone_CheckedChanged(object sender, EventArgs e)
		{
			//cbparent.Enabled = cbRCOLClone.Checked;
		}

		private void cbfix_CheckedChanged(object sender, EventArgs e)
		{
			cbclean.Enabled = (cbfix.Checked || cbparent.Checked);
			cbclean.Refresh();
		}

		private void SelectTv(object sender, TreeViewEventArgs e)
		{
			btclone.Enabled = false;
			btclone.Refresh();
			if (tv.SelectedNode == null)
			{
				return;
			}

			if (tv.SelectedNode.Tag == null)
			{
				return;
			}

			btclone.Enabled = true;
			btclone.Refresh();

			IAlias a = (IAlias)tv.SelectedNode.Tag;

			if (a.Tag[2] == null)
			{
				pb.Image = null;
			}
			else
			{
				pb.Image = GetThumbnail((uint)a.Tag[1], (string)a.Tag[2]);
			}
		}

		private void TabChange(object sender, EventArgs e)
		{
			if (tabControl2.SelectedIndex == 0)
			{
				BuildListing();
				this.Select(null, null);
			}
			else if (tabControl2.SelectedIndex == 1)
			{
				BuildListing();
				this.SelectTv(null, null);
			}
			else
			{
				this.btclone.Enabled = System.IO.File.Exists(tbflname.Text);
			}

			btclone.Refresh();
		}

		delegate void InvokeTargetLoad(
			Cache.ObjectCacheItem oci,
			Interfaces.Scenegraph.IScenegraphFileIndexItem fii,
			Alias a
		);
		delegate void InvokeTargetFinish(object sender, EventArgs e);

		private void ol_Finished(object sender, EventArgs e)
		{
			this.Invoke(
				new InvokeTargetFinish(invoke_Finished),
				new object[] { sender, e }
			);
		}

		private void invoke_Finished(object sender, EventArgs e)
		{
			lbobj.Enabled = true;
			this.tv.Enabled = true;

			lbobj.Sorted = true;
			tv.Sorted = true;
			tv.EndUpdate();
			lbobj.EndUpdate();
			WaitingScreen.Stop(this);
		}

		private void ol_LoadedItem(
			Cache.ObjectCacheItem oci,
			Interfaces.Scenegraph.IScenegraphFileIndexItem fii,
			Alias a
		)
		{
			this.Invoke(
				new InvokeTargetLoad(invoke_LoadedItem),
				new object[] { oci, fii, a }
			);
		}

		private void invoke_LoadedItem(
			Cache.ObjectCacheItem oci,
			Interfaces.Scenegraph.IScenegraphFileIndexItem fii,
			Alias a
		)
		{
			if (oci.ObjectVersion == SimPe.Cache.ObjectCacheItemVersions.DockableOW)
			{
				PutItemToTree(
					a,
					oci.Thumbnail,
					(ObjectTypes)oci.ObjectType,
					new PackedFiles.Wrapper.ObjFunctionSort(
						(oci.ObjectFunctionSort >> 8) & 0xfff
					),
					new PackedFiles.Wrapper.ObjBuildType(oci.ObjBuildType),
					oci.FileDescriptor.Filename,
					oci.FileDescriptor.Group
				);
			}
			else
			{
				PutItemToTree(
					a,
					oci.Thumbnail,
					(ObjectTypes)oci.ObjectType,
					new PackedFiles.Wrapper.ObjFunctionSort(
						oci.ObjectFunctionSort
					),
					new PackedFiles.Wrapper.ObjBuildType(oci.ObjBuildType),
					oci.FileDescriptor.Filename,
					oci.FileDescriptor.Group
				);
			}

			if (oci.Thumbnail != null)
			{
				a.Name = "* " + a.Name;
			}

			lbobj.Items.Add(a);
		}
	}
}
