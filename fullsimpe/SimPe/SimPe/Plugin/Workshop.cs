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
			tabControl1.SelectedIndex = 1;
			lbobj.SelectionMode = SelectionMode.One;
			cbColor.Visible = false;
			cbColor.Checked = false;
			cbColorExt.Enabled = true;
			cbColorExt.Checked = true;
			rbColor.Enabled = true;

			tviapl = new TreeNode("Appliances");
			tv.Nodes.Add(tviapl);
			tvideco = new TreeNode("Decorative");
			tv.Nodes.Add(tvideco);
			tvielectro = new TreeNode("Electronics");
			tv.Nodes.Add(tvielectro);
			tvigeneral = new TreeNode("General");
			tv.Nodes.Add(tvigeneral);
			tvilight = new TreeNode("Lights");
			tv.Nodes.Add(tvilight);
			tviplumb = new TreeNode("Plumbing");
			tv.Nodes.Add(tviplumb);
			tviseating = new TreeNode("Seating");
			tv.Nodes.Add(tviseating);
			tvisurfaces = new TreeNode("Surfaces");
			tv.Nodes.Add(tvisurfaces);
			tvihobby = new TreeNode("Hobbies");
			tv.Nodes.Add(tvihobby);
			tviaspiration = new TreeNode("Aspiration Rewards");
			tv.Nodes.Add(tviaspiration);
			tvicareer = new TreeNode("Career Rewards");
			tv.Nodes.Add(tvicareer);
			tviother = new TreeNode("Others");
			tv.Nodes.Add(tviother);

			tvistairs = new TreeNode("Stairs");
			tv.Nodes.Add(tvistairs);
			tviperson = new TreeNode("Persons");
			tv.Nodes.Add(tviperson);
			tviarchsup = new TreeNode("ArchitecturalSupports");
			tv.Nodes.Add(tviarchsup);
			tvisimtype = new TreeNode("SimTypes");
			tv.Nodes.Add(tvisimtype);
			tvidoor = new TreeNode("Doors");
			tv.Nodes.Add(tvidoor);
			tvimodstair = new TreeNode("ModularStairs");
			tv.Nodes.Add(tvimodstair);
			tvimodstairport = new TreeNode("ModularStairPorts");
			tv.Nodes.Add(tvimodstairport);
			tvivehicle = new TreeNode("Vehicles");
			tv.Nodes.Add(tvivehicle);
			tvioutfit = new TreeNode("Outfits");
			tv.Nodes.Add(tvioutfit);
			tvimemory = new TreeNode("Memories");
			tv.Nodes.Add(tvimemory);
			tvitemplate = new TreeNode("Templates");
			tv.Nodes.Add(tvitemplate);
			tviwindow = new TreeNode("Windows");
			tv.Nodes.Add(tviwindow);

			tvigarden = new TreeNode("Garden");
			tv.Nodes.Add(tvigarden);
		}

		/// <summary>
		/// Clean the Group Tree
		/// </summary>
		void CleanTree()
		{
			tviapl.Nodes.Clear();
			tvideco.Nodes.Clear();
			tvielectro.Nodes.Clear();
			tvigeneral.Nodes.Clear();
			tvilight.Nodes.Clear();
			tviplumb.Nodes.Clear();
			tviseating.Nodes.Clear();
			tvisurfaces.Nodes.Clear();
			tvihobby.Nodes.Clear();
			tviaspiration.Nodes.Clear();
			tvicareer.Nodes.Clear();
			tviother.Nodes.Clear();

			tvistairs.Nodes.Clear();
			tviperson.Nodes.Clear();
			tviarchsup.Nodes.Clear();
			tvisimtype.Nodes.Clear();
			tvidoor.Nodes.Clear();
			tvimodstair.Nodes.Clear();
			tvimodstairport.Nodes.Clear();
			tvivehicle.Nodes.Clear();
			tvioutfit.Nodes.Clear();
			tvimemory.Nodes.Clear();
			tvitemplate.Nodes.Clear();
			tviwindow.Nodes.Clear();
			tvigarden.Nodes.Clear();

			ilist.Images.Clear();
			ilist.Images.Add(
				new Bitmap(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.subitems.png")
				)
			);
			ilist.Images.Add(
				new Bitmap(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.nothumb.png")
				)
			);
			ilist.Images.Add(
				new Bitmap(
					GetType()
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
			)
			{
				Tag = a
			};
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

			if (type == ObjectTypes.Stairs)
			{
				tvistairs.Nodes.Add(node);
			}
			else if (type == ObjectTypes.ArchitecturalSupport)
			{
				tviarchsup.Nodes.Add(node);
			}
			else if (type == ObjectTypes.Door)
			{
				tvidoor.Nodes.Add(node);
			}
			else if (type == ObjectTypes.Memory)
			{
				tvimemory.Nodes.Add(node);
			}
			else if (type == ObjectTypes.ModularStairs)
			{
				tvimodstair.Nodes.Add(node);
			}
			else if (type == ObjectTypes.ModularStairsPortal)
			{
				tvimodstairport.Nodes.Add(node);
			}
			else if (type == ObjectTypes.Outfit)
			{
				tvioutfit.Nodes.Add(node);
			}
			else if (type == ObjectTypes.Person)
			{
				tviperson.Nodes.Add(node);
			}
			else if (type == ObjectTypes.SimType)
			{
				tvisimtype.Nodes.Add(node);
			}
			else if (type == ObjectTypes.Template)
			{
				tvitemplate.Nodes.Add(node);
			}
			else if (type == ObjectTypes.Vehicle)
			{
				tvivehicle.Nodes.Add(node);
			}
			else if (type == ObjectTypes.Window)
			{
				tviwindow.Nodes.Add(node);
			}
			else
			{
				bool added = false;
				if (functionsort.InAppliances)
				{
					tviapl.Nodes.Add(node);
					added = true;
				}
				else if (functionsort.InDecorative)
				{
					tvideco.Nodes.Add(node);
					added = true;
				}
				else if (functionsort.InElectronics)
				{
					tvielectro.Nodes.Add(node);
					added = true;
				}
				else if (functionsort.InGeneral)
				{
					tvigeneral.Nodes.Add(node);
					added = true;
				}
				else if (functionsort.InLighting)
				{
					tvilight.Nodes.Add(node);
					added = true;
				}
				else if (functionsort.InPlumbing)
				{
					tviplumb.Nodes.Add(node);
					added = true;
				}
				else if (functionsort.InSeating)
				{
					tviseating.Nodes.Add(node);
					added = true;
				}
				else if (functionsort.InSurfaces)
				{
					tvisurfaces.Nodes.Add(node);
					added = true;
				}
				else if (functionsort.InHobbies)
				{
					tvihobby.Nodes.Add(node);
					added = true;
				}
				else if (functionsort.InAspirationRewards)
				{
					tviaspiration.Nodes.Add(node);
					added = true;
				}
				else if (functionsort.InCareerRewards)
				{
					tvicareer.Nodes.Add(node);
					added = true;
				}
				else if (buildtype.InGarden)
				{
					tvigarden.Nodes.Add(node);
					added = true;
				}

				if (!added)
				{
					tviother.Nodes.Add(node);
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
				ilist.ImageSize = new Size(
					Helper.WindowsRegistry.OWThumbSize,
					Helper.WindowsRegistry.OWThumbSize
				);
				//LoadCachIndex();
				lbobj.BeginUpdate();
				tv.BeginUpdate();
				lbobj.Items.Clear();
				CleanTree();
				lbobj.Sorted = false;
				lbobj.Enabled = false;
				tv.Enabled = false;
				tv.Sorted = false;

				Tool.Dockable.ObjectLoader ol =
					new Tool.Dockable.ObjectLoader(ilist);
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
			resources1 = new System.ComponentModel.ComponentResourceManager(
				typeof(PreviewForm)
			);
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(typeof(Workshop));
			lbobj = new ListBox();
			btclone = new Button();
			groupBox1 = new GroupBox();
			pb = new PictureBox();
			rbColor = new RadioButton();
			rbClone = new RadioButton();
			tabControl1 = new TabControl();
			tClone = new System.Windows.Forms.TabPage();
			cbanim = new CheckBox();
			cbwallmask = new CheckBox();
			cbparent = new CheckBox();
			cbclean = new CheckBox();
			cbfix = new CheckBox();
			cbdefault = new CheckBox();
			cbgid = new CheckBox();
			tColor = new System.Windows.Forms.TabPage();
			cbColorExt = new CheckBox();
			cbColor = new CheckBox();
			sfd = new SaveFileDialog();
			tbseek = new TextBox();
			tabControl2 = new TabControl();
			tabPage1 = new System.Windows.Forms.TabPage();
			tabPage3 = new System.Windows.Forms.TabPage();
			tv = new TreeView();
			ilist = new ImageList(components);
			tabPage2 = new System.Windows.Forms.TabPage();
			button1 = new Button();
			tbflname = new TextBox();
			ofd = new OpenFileDialog();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(pb)).BeginInit();
			tabControl1.SuspendLayout();
			tClone.SuspendLayout();
			tColor.SuspendLayout();
			tabControl2.SuspendLayout();
			tabPage1.SuspendLayout();
			tabPage3.SuspendLayout();
			tabPage2.SuspendLayout();
			SuspendLayout();
			//
			// lbobj
			//
			lbobj.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			lbobj.IntegralHeight = false;
			lbobj.Location = new Point(8, 32);
			lbobj.Name = "lbobj";
			lbobj.SelectionMode = SelectionMode.MultiExtended;
			lbobj.Size = new Size(464, 192);
			lbobj.TabIndex = 0;
			lbobj.SelectedIndexChanged += new EventHandler(Select);
			//
			// btclone
			//
			btclone.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)

			;
			btclone.FlatStyle = FlatStyle.System;
			btclone.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			btclone.Location = new Point(408, 212);
			btclone.Name = "btclone";
			btclone.Size = new Size(75, 23);
			btclone.TabIndex = 1;
			btclone.Text = "Start";
			btclone.Click += new EventHandler(Start);
			//
			// groupBox1
			//
			groupBox1.Anchor =

					(
						(
							AnchorStyles.Bottom
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			groupBox1.Controls.Add(pb);
			groupBox1.Controls.Add(rbColor);
			groupBox1.Controls.Add(rbClone);
			groupBox1.Controls.Add(tabControl1);
			groupBox1.Controls.Add(btclone);
			groupBox1.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				0
			);
			groupBox1.Location = new Point(8, 272);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(488, 240);
			groupBox1.TabIndex = 2;
			groupBox1.TabStop = false;
			groupBox1.Text = "Settings";
			//
			// pb
			//
			pb.BorderStyle = BorderStyle.FixedSingle;
			pb.Location = new Point(8, 24);
			pb.Name = "pb";
			pb.Size = new Size(128, 128);
			pb.SizeMode = PictureBoxSizeMode.StretchImage;
			pb.TabIndex = 6;
			pb.TabStop = false;
			//
			// rbColor
			//
			rbColor.Checked = true;
			rbColor.FlatStyle = FlatStyle.System;
			rbColor.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			rbColor.Location = new Point(16, 176);
			rbColor.Name = "rbColor";
			rbColor.Size = new Size(120, 24);
			rbColor.TabIndex = 5;
			rbColor.TabStop = true;
			rbColor.Text = "Colour Options";
			rbColor.CheckedChanged += new EventHandler(
				rbColor_CheckedChanged
			);
			//
			// rbClone
			//
			rbClone.FlatStyle = FlatStyle.System;
			rbClone.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			rbClone.Location = new Point(16, 156);
			rbClone.Name = "rbClone";
			rbClone.Size = new Size(120, 24);
			rbClone.TabIndex = 4;
			rbClone.Text = "Clone";
			rbClone.CheckedChanged += new EventHandler(
				rbClone_CheckedChanged
			);
			//
			// tabControl1
			//
			tabControl1.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			tabControl1.Controls.Add(tClone);
			tabControl1.Controls.Add(tColor);
			tabControl1.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			tabControl1.Location = new Point(150, 24);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new Size(328, 184);
			tabControl1.TabIndex = 3;
			tabControl1.SelectedIndexChanged += new EventHandler(
				TabChanged
			);
			//
			// tClone
			//
			tClone.Controls.Add(cbanim);
			tClone.Controls.Add(cbwallmask);
			tClone.Controls.Add(cbparent);
			tClone.Controls.Add(cbclean);
			tClone.Controls.Add(cbfix);
			tClone.Controls.Add(cbdefault);
			tClone.Controls.Add(cbgid);
			tClone.Location = new Point(4, 22);
			tClone.Name = "tClone";
			tClone.Size = new Size(320, 158);
			tClone.TabIndex = 0;
			tClone.Text = "Clone Settings";
			//
			// cbanim
			//
			cbanim.FlatStyle = FlatStyle.System;
			cbanim.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			cbanim.Location = new Point(8, 128);
			cbanim.Name = "cbanim";
			cbanim.Size = new Size(120, 24);
			cbanim.TabIndex = 9;
			cbanim.Text = "Pull Animations";
			//
			// cbwallmask
			//
			cbwallmask.Checked = true;
			cbwallmask.CheckState = CheckState.Checked;
			cbwallmask.FlatStyle = FlatStyle.System;
			cbwallmask.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			cbwallmask.Location = new Point(8, 108);
			cbwallmask.Name = "cbwallmask";
			cbwallmask.Size = new Size(272, 24);
			cbwallmask.TabIndex = 8;
			cbwallmask.Text = "Pull Wallmasks (as described by Numenor)";
			//
			// cbparent
			//
			cbparent.FlatStyle = FlatStyle.System;
			cbparent.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			cbparent.Location = new Point(8, 88);
			cbparent.Name = "cbparent";
			cbparent.Size = new Size(192, 24);
			cbparent.TabIndex = 7;
			cbparent.Text = "Create a stand-alone object";
			cbparent.CheckedChanged += new EventHandler(
				cbfix_CheckedChanged
			);
			//
			// cbclean
			//
			cbclean.Checked = true;
			cbclean.CheckState = CheckState.Checked;
			cbclean.FlatStyle = FlatStyle.System;
			cbclean.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			cbclean.Location = new Point(24, 48);
			cbclean.Name = "cbclean";
			cbclean.Size = new Size(272, 24);
			cbclean.TabIndex = 6;
			cbclean.Text = "Remove useless Files (sug. by.  Numenor)";
			//
			// cbfix
			//
			cbfix.Checked = true;
			cbfix.CheckState = CheckState.Checked;
			cbfix.FlatStyle = FlatStyle.System;
			cbfix.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			cbfix.Location = new Point(8, 28);
			cbfix.Name = "cbfix";
			cbfix.Size = new Size(224, 24);
			cbfix.TabIndex = 5;
			cbfix.Text = "Fix Cloned Files (sug. by.  wes_h)";
			cbfix.CheckedChanged += new EventHandler(
				cbfix_CheckedChanged
			);
			//
			// cbdefault
			//
			cbdefault.Checked = true;
			cbdefault.CheckState = CheckState.Checked;
			cbdefault.FlatStyle = FlatStyle.System;
			cbdefault.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			cbdefault.Location = new Point(8, 68);
			cbdefault.Name = "cbdefault";
			cbdefault.Size = new Size(224, 24);
			cbdefault.TabIndex = 3;
			cbdefault.Text = "Pull only default Colour";
			cbdefault.CheckedChanged += new EventHandler(
				cbRCOLClone_CheckedChanged
			);
			//
			// cbgid
			//
			cbgid.Checked = true;
			cbgid.CheckState = CheckState.Checked;
			cbgid.FlatStyle = FlatStyle.System;
			cbgid.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			cbgid.Location = new Point(8, 8);
			cbgid.Name = "cbgid";
			cbgid.Size = new Size(248, 24);
			cbgid.TabIndex = 2;
			cbgid.Text = "Set Custom Group ID (0x1c050000)";
			//
			// tColor
			//
			tColor.Controls.Add(cbColorExt);
			tColor.Controls.Add(cbColor);
			tColor.Location = new Point(4, 22);
			tColor.Name = "tColor";
			tColor.Size = new Size(320, 158);
			tColor.TabIndex = 1;
			tColor.Text = "Colour Options";
			//
			// cbColorExt
			//
			cbColorExt.Checked = true;
			cbColorExt.CheckState = CheckState.Checked;
			cbColorExt.FlatStyle = FlatStyle.System;
			cbColorExt.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			cbColorExt.Location = new Point(8, 8);
			cbColorExt.Name = "cbColorExt";
			cbColorExt.Size = new Size(224, 24);
			cbColorExt.TabIndex = 4;
			cbColorExt.Text = "Create Colour Extension Package";
			//
			// cbColor
			//
			cbColor.FlatStyle = FlatStyle.System;
			cbColor.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			cbColor.Location = new Point(8, 28);
			cbColor.Name = "cbColor";
			cbColor.Size = new Size(224, 24);
			cbColor.TabIndex = 3;
			cbColor.Text = "Enable All Colour Options";
			//
			// sfd
			//
			sfd.Filter = "Package File (*.package)|*.package|All Files (*.*)|*.*";
			sfd.Title = "Alternative Colour Pacakge";
			//
			// tbseek
			//
			tbseek.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			tbseek.Location = new Point(8, 8);
			tbseek.Name = "tbseek";
			tbseek.Size = new Size(464, 21);
			tbseek.TabIndex = 3;
			tbseek.TextChanged += new EventHandler(SeekItem);
			//
			// tabControl2
			//
			tabControl2.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			tabControl2.Controls.Add(tabPage1);
			tabControl2.Controls.Add(tabPage3);
			tabControl2.Controls.Add(tabPage2);
			tabControl2.Location = new Point(8, 8);
			tabControl2.Name = "tabControl2";
			tabControl2.SelectedIndex = 1;
			tabControl2.Size = new Size(488, 256);
			tabControl2.TabIndex = 4;
			tabControl2.SelectedIndexChanged += new EventHandler(
				TabChange
			);
			//
			// tabPage1
			//
			tabPage1.Controls.Add(lbobj);
			tabPage1.Controls.Add(tbseek);
			tabPage1.Location = new Point(4, 22);
			tabPage1.Name = "tabPage1";
			tabPage1.Size = new Size(480, 230);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "Object Listing";
			//
			// tabPage3
			//
			tabPage3.Controls.Add(tv);
			tabPage3.Location = new Point(4, 22);
			tabPage3.Name = "tabPage3";
			tabPage3.Size = new Size(480, 230);
			tabPage3.TabIndex = 2;
			tabPage3.Text = "Grouped Objects";
			//
			// tv
			//
			tv.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			tv.HideSelection = false;
			tv.ImageIndex = 0;
			tv.ImageList = ilist;
			tv.Location = new Point(8, 8);
			tv.Name = "tv";
			tv.SelectedImageIndex = 0;
			tv.Size = new Size(464, 216);
			tv.TabIndex = 0;
			tv.AfterSelect += new TreeViewEventHandler(
				SelectTv
			);
			//
			// ilist
			//
			ilist.ColorDepth = ColorDepth.Depth24Bit;
			ilist.ImageSize = new Size(16, 16);
			ilist.TransparentColor = Color.Transparent;
			//
			// tabPage2
			//
			tabPage2.Controls.Add(button1);
			tabPage2.Controls.Add(tbflname);
			tabPage2.Location = new Point(4, 22);
			tabPage2.Name = "tabPage2";
			tabPage2.Size = new Size(480, 230);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "Load Object";
			//
			// button1
			//
			button1.FlatStyle = FlatStyle.System;
			button1.Location = new Point(397, 32);
			button1.Name = "button1";
			button1.Size = new Size(75, 23);
			button1.TabIndex = 1;
			button1.Text = "Browse...";
			button1.Click += new EventHandler(button1_Click);
			//
			// tbflname
			//
			tbflname.Anchor =

					(
						AnchorStyles.Left
						| AnchorStyles.Right
					)

			;
			tbflname.Location = new Point(8, 12);
			tbflname.Name = "tbflname";
			tbflname.ReadOnly = true;
			tbflname.Size = new Size(464, 21);
			tbflname.TabIndex = 0;
			//
			// ofd
			//
			ofd.Filter = "Package File (*.package)|*.package|All Files (*.*)|*.*";
			//
			// Workshop
			//
			AutoScaleBaseSize = new Size(6, 14);
			ClientSize = new Size(512, 518);
			Controls.Add(tabControl2);
			Controls.Add(groupBox1);
			Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			FormBorderStyle =
				FormBorderStyle
				.SizableToolWindow;
			Icon = ((Icon)(resources1.GetObject("$this.Icon")));
			MinimumSize = new Size(520, 320);
			Name = "Workshop";
			Text = "Object Workshop (biggest thanks to RGiles and Numenor)";
			groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(pb)).EndInit();
			tabControl1.ResumeLayout(false);
			tClone.ResumeLayout(false);
			tColor.ResumeLayout(false);
			tabControl2.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage1.PerformLayout();
			tabPage3.ResumeLayout(false);
			tabPage2.ResumeLayout(false);
			tabPage2.PerformLayout();
			ResumeLayout(false);
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
				Cursor = Cursors.WaitCursor;
				IAlias a = new Alias(0, "");
				Interfaces.Files.IPackedFileDescriptor pfd = null;
				uint localgroup = MetaData.LOCAL_GROUP;

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

				if (rbClone.Checked)
				{
					if (tabControl2.SelectedIndex < 2)
					{
						WaitingScreen.Wait();
						try
						{
							RecolorClone(
								pfd,
								localgroup,
								cbdefault.Checked,
								cbwallmask.Checked,
								cbanim.Checked
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

					if (cbfix.Checked)
					{
						map = fo.GetNameMap(true);
						if (map == null)
						{
							return;
						}
					}

					if (cbfix.Checked)
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

					if ((cbgid.Checked) && (package != null))
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
				}
				else //if Recolor
				{
					if (cbColor.Checked)
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
						ReColor(null, MetaData.LOCAL_GROUP);
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
				thumbs = Packages.File.LoadFromFile(
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
			Packages.File pkg = Packages.File.LoadFromFile(filename);

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
				FileTableBase.FileIndex.FindFileByGroup(localgroup);

			ArrayList list = new ArrayList();
			foreach (Interfaces.Scenegraph.IScenegraphFileIndexItem item in files)
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

				if ((npfd.Instance == 0x85) && (npfd.Type == MetaData.STRING_FILE))
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
			package = Packages.File.LoadFromStream(
				null
			);

			//Get the Base Object Data from the Objects.package File
			string[] modelname = BaseClone(pfd, localgroup, package);
			ObjectCloner objclone = new ObjectCloner(package);
			ArrayList exclude = new ArrayList();

			//allways for recolors
			if (rbColor.Checked)
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
			if ((cbparent.Checked) && (!rbColor.Checked))
			{
				string[] names = Scenegraph.LoadParentModelNames(package, true);
				Packages.File pkg = Packages.File.LoadFromFile(null);

				ObjectCloner pobj = new ObjectCloner(pkg);
				pobj.Setup.OnlyDefaultMmats = onlydefault;
				pobj.Setup.UpdateMmatGuids = onlydefault;
				pobj.Setup.IncludeWallmask = wallmask;
				pobj.Setup.IncludeAnimationResources = anim;
				pobj.RcolModelClone(names, exclude);
				pobj.AddParentFiles(modelname, package);
			}

			//for clones only when cbparent is not checked
			if ((!cbparent.Checked) && (!rbColor.Checked))
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
				PathProvider.Global.EPInstalled < 16
				&& (
					(!System.IO.File.Exists(ScenegraphHelper.GMND_PACKAGE))
					|| (!System.IO.File.Exists(ScenegraphHelper.MMAT_PACKAGE))
				)
				&& (!cbColor.Checked)
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

			if (cbColorExt.Checked)
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

				if (cbColor.Checked)
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
					dn_pkg = Packages.File.LoadFromFile(
						ScenegraphHelper.GMND_PACKAGE
					);
				}
				else
				{
					dn_pkg = Packages.File.LoadFromStream(
						null
					);
				}

				Packages.GeneratableFile gm_pkg = null;
				if (System.IO.File.Exists(ScenegraphHelper.MMAT_PACKAGE))
				{
					gm_pkg = Packages.File.LoadFromFile(
						ScenegraphHelper.MMAT_PACKAGE
					);
				}
				else
				{
					gm_pkg = Packages.File.LoadFromStream(
						null
					);
				}

				Packages.GeneratableFile npackage =
					Packages.File.LoadFromStream(
						null
					);
				//Create the Templae for an additional MMAT
				if (cbColorExt.Checked)
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
				Select(null, null);
			}
		}

		private void TabChanged(object sender, EventArgs e)
		{
			if (tabControl1.Tag != null)
			{
				return;
			}

			tabControl1.Tag = true;
			if (tabControl1.SelectedIndex == 0)
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
				package = Packages.File.LoadFromFile(ofd.FileName);
				tbflname.Text = ofd.FileName;
				btclone.Enabled = System.IO.File.Exists(tbflname.Text);
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
				Select(null, null);
			}
			else if (tabControl2.SelectedIndex == 1)
			{
				BuildListing();
				SelectTv(null, null);
			}
			else
			{
				btclone.Enabled = System.IO.File.Exists(tbflname.Text);
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
			Invoke(
				new InvokeTargetFinish(invoke_Finished),
				new object[] { sender, e }
			);
		}

		private void invoke_Finished(object sender, EventArgs e)
		{
			lbobj.Enabled = true;
			tv.Enabled = true;

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
			Invoke(
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
			if (oci.ObjectVersion == Cache.ObjectCacheItemVersions.DockableOW)
			{
				PutItemToTree(
					a,
					oci.Thumbnail,
					oci.ObjectType,
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
					oci.ObjectType,
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
