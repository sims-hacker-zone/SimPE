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

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for Sims.
	/// </summary>
	public class Sims : Form
	{
		private ImageList ilist;
		private ListView lv;
		private Button button1;
		private ToolTip toolTip1;
		private ImageList iListSmall;
		private ColumnHeader columnHeader1;
		private ColumnHeader columnHeader2;
		private ColumnHeader columnHeader3;
		private ColumnHeader columnHeader4;
		private ColumnHeader columnHeader5;
		private ColumnHeader columnHeader6;
		private ColumnHeader columnHeader7;
		private ColumnHeader columnHeader8;
		private ColumnHeader columnHeader9;
		private Label lbUbi;
		private Panel panel1;
		private Label label1;
		private Label label2;
		private Panel panel2;
		private Label label3;
		private Panel panel3;
		private ColumnHeader chKind;
		private ColumnHeader columnHeader10;
		private System.ComponentModel.IContainer components;
		private FlowLayoutPanel flowLayoutPanel1;
		internal CheckBox cbNpc;
		internal CheckBox cbTownie;
		internal CheckBox ckbPlayable;
		internal CheckBox cbdetail;
		internal CheckBox ckbUnEditable;
		internal CheckBox cbgals;
		internal CheckBox cbmens;
		internal CheckBox cbadults;
		private ColumnHeader columnHeader11;

		SimsRegistry reg;

		public Sims()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();
			sorter = new ColumnSorter();

			reg = new SimsRegistry(this);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (reg != null)
				{
					reg.Dispose();
				}

				reg = null;
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
				new System.ComponentModel.ComponentResourceManager(typeof(Sims));
			this.ilist = new ImageList(this.components);
			this.lv = new ListView();
			this.columnHeader1 = new ColumnHeader();
			this.columnHeader2 = new ColumnHeader();
			this.columnHeader3 = new ColumnHeader();
			this.chKind = new ColumnHeader();
			this.columnHeader10 = new ColumnHeader();
			this.columnHeader4 = new ColumnHeader();
			this.columnHeader5 = new ColumnHeader();
			this.columnHeader6 = new ColumnHeader();
			this.columnHeader9 = new ColumnHeader();
			this.columnHeader7 = new ColumnHeader();
			this.columnHeader8 = new ColumnHeader();
			this.columnHeader11 = new ColumnHeader();
			this.iListSmall = new ImageList(this.components);
			this.button1 = new Button();
			this.toolTip1 = new ToolTip(this.components);
			this.lbUbi = new Label();
			this.panel1 = new Panel();
			this.label1 = new Label();
			this.label2 = new Label();
			this.panel2 = new Panel();
			this.label3 = new Label();
			this.panel3 = new Panel();
			this.flowLayoutPanel1 = new FlowLayoutPanel();
			this.ckbPlayable = new CheckBox();
			this.cbTownie = new CheckBox();
			this.cbNpc = new CheckBox();
			this.ckbUnEditable = new CheckBox();
			this.cbgals = new CheckBox();
			this.cbmens = new CheckBox();
			this.cbadults = new CheckBox();
			this.cbdetail = new CheckBox();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			//
			// ilist
			//
			this.ilist.ColorDepth = ColorDepth.Depth32Bit;
			resources.ApplyResources(this.ilist, "ilist");
			this.ilist.TransparentColor = Color.Transparent;
			//
			// lv
			//
			resources.ApplyResources(this.lv, "lv");
			this.lv.Columns.AddRange(
				new ColumnHeader[]
				{
					this.columnHeader1,
					this.columnHeader2,
					this.columnHeader3,
					this.chKind,
					this.columnHeader10,
					this.columnHeader4,
					this.columnHeader5,
					this.columnHeader6,
					this.columnHeader9,
					this.columnHeader7,
					this.columnHeader8,
					this.columnHeader11,
				}
			);
			this.lv.FullRowSelect = true;
			this.lv.HideSelection = false;
			this.lv.LargeImageList = this.ilist;
			this.lv.MultiSelect = false;
			this.lv.Name = "lv";
			this.lv.SmallImageList = this.iListSmall;
			this.lv.StateImageList = this.iListSmall;
			this.lv.UseCompatibleStateImageBehavior = false;
			this.lv.View = View.Details;
			this.lv.DoubleClick += new EventHandler(this.Open);
			this.lv.ColumnClick += new ColumnClickEventHandler(
				this.SortList
			);
			//
			// columnHeader1
			//
			resources.ApplyResources(this.columnHeader1, "columnHeader1");
			//
			// columnHeader2
			//
			resources.ApplyResources(this.columnHeader2, "columnHeader2");
			//
			// columnHeader3
			//
			resources.ApplyResources(this.columnHeader3, "columnHeader3");
			//
			// chKind
			//
			resources.ApplyResources(this.chKind, "chKind");
			//
			// columnHeader10
			//
			resources.ApplyResources(this.columnHeader10, "columnHeader10");
			//
			// columnHeader4
			//
			resources.ApplyResources(this.columnHeader4, "columnHeader4");
			//
			// columnHeader5
			//
			resources.ApplyResources(this.columnHeader5, "columnHeader5");
			//
			// columnHeader6
			//
			resources.ApplyResources(this.columnHeader6, "columnHeader6");
			//
			// columnHeader9
			//
			resources.ApplyResources(this.columnHeader9, "columnHeader9");
			//
			// columnHeader7
			//
			resources.ApplyResources(this.columnHeader7, "columnHeader7");
			//
			// columnHeader8
			//
			resources.ApplyResources(this.columnHeader8, "columnHeader8");
			//
			// columnHeader11
			//
			resources.ApplyResources(this.columnHeader11, "columnHeader11");
			//
			// iListSmall
			//
			this.iListSmall.ColorDepth = ColorDepth.Depth32Bit;
			resources.ApplyResources(this.iListSmall, "iListSmall");
			this.iListSmall.TransparentColor = Color.Transparent;
			//
			// button1
			//
			resources.ApplyResources(this.button1, "button1");
			this.button1.Name = "button1";
			this.button1.Click += new EventHandler(this.Open);
			//
			// lbUbi
			//
			this.lbUbi.BackColor = SystemColors.Window;
			resources.ApplyResources(this.lbUbi, "lbUbi");
			this.lbUbi.ForeColor = Color.Brown;
			this.lbUbi.Name = "lbUbi";
			//
			// panel1
			//
			resources.ApplyResources(this.panel1, "panel1");
			this.panel1.BackColor = Color.SteelBlue;
			this.panel1.Name = "panel1";
			//
			// label1
			//
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			//
			// label2
			//
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			//
			// panel2
			//
			resources.ApplyResources(this.panel2, "panel2");
			this.panel2.BackColor = Color.LightCoral;
			this.panel2.Name = "panel2";
			//
			// label3
			//
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			//
			// panel3
			//
			resources.ApplyResources(this.panel3, "panel3");
			this.panel3.BackColor = Color.YellowGreen;
			this.panel3.Name = "panel3";
			//
			// flowLayoutPanel1
			//
			resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
			this.flowLayoutPanel1.Controls.Add(this.ckbPlayable);
			this.flowLayoutPanel1.Controls.Add(this.cbTownie);
			this.flowLayoutPanel1.Controls.Add(this.cbNpc);
			this.flowLayoutPanel1.Controls.Add(this.ckbUnEditable);
			this.flowLayoutPanel1.Controls.Add(this.cbgals);
			this.flowLayoutPanel1.Controls.Add(this.cbmens);
			this.flowLayoutPanel1.Controls.Add(this.cbadults);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			//
			// ckbPlayable
			//
			resources.ApplyResources(this.ckbPlayable, "ckbPlayable");
			this.ckbPlayable.Checked = true;
			this.ckbPlayable.CheckState = CheckState.Checked;
			this.ckbPlayable.Name = "ckbPlayable";
			this.ckbPlayable.UseVisualStyleBackColor = true;
			this.ckbPlayable.CheckedChanged += new EventHandler(
				this.ckbFilter_CheckedChanged
			);
			//
			// cbTownie
			//
			resources.ApplyResources(this.cbTownie, "cbTownie");
			this.cbTownie.Name = "cbTownie";
			this.cbTownie.CheckedChanged += new EventHandler(
				this.ckbFilter_CheckedChanged
			);
			//
			// cbNpc
			//
			resources.ApplyResources(this.cbNpc, "cbNpc");
			this.cbNpc.Name = "cbNpc";
			this.cbNpc.CheckedChanged += new EventHandler(
				this.ckbFilter_CheckedChanged
			);
			//
			// ckbUnEditable
			//
			resources.ApplyResources(this.ckbUnEditable, "ckbUnEditable");
			this.ckbUnEditable.Name = "ckbUnEditable";
			this.ckbUnEditable.UseVisualStyleBackColor = true;
			this.ckbUnEditable.CheckedChanged += new EventHandler(
				this.ckbFilter_CheckedChanged
			);
			//
			// cbgals
			//
			resources.ApplyResources(this.cbgals, "cbgals");
			this.cbgals.Name = "cbgals";
			this.cbgals.UseVisualStyleBackColor = true;
			this.cbgals.CheckedChanged += new EventHandler(
				this.ckbFilter_CheckedChanged
			);
			//
			// cbmens
			//
			resources.ApplyResources(this.cbmens, "cbmens");
			this.cbmens.Name = "cbmens";
			this.cbmens.UseVisualStyleBackColor = true;
			this.cbmens.CheckedChanged += new EventHandler(
				this.ckbFilter_CheckedChanged
			);
			//
			// cbadults
			//
			resources.ApplyResources(this.cbadults, "cbadults");
			this.cbadults.Name = "cbadults";
			this.cbadults.UseVisualStyleBackColor = true;
			this.cbadults.CheckedChanged += new EventHandler(
				this.ckbFilter_CheckedChanged
			);
			//
			// cbdetail
			//
			resources.ApplyResources(this.cbdetail, "cbdetail");
			this.cbdetail.Checked = true;
			this.cbdetail.CheckState = CheckState.Checked;
			this.cbdetail.Name = "cbdetail";
			this.cbdetail.CheckedChanged += new EventHandler(
				this.checkBox1_CheckedChanged
			);
			//
			// Sims
			//
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.cbdetail);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.lbUbi);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.lv);
			this.FormBorderStyle =
				FormBorderStyle
				.SizableToolWindow;
			this.Name = "Sims";
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion

		protected void AddImage(PackedFiles.Wrapper.ExtSDesc sdesc)
		{
			Image img = null;
			if (sdesc.Unlinked != 0x00 || !sdesc.AvailableCharacterData || sdesc.IsNPC)
			{
				if (sdesc.HasImage)
				{
					img = ImageLoader.Preview(sdesc.Image, this.ilist.ImageSize);
				}
				else if (
					sdesc.CharacterDescription.Gender
					== Data.MetaData.Gender.Female
				)
				{
					img = ImageLoader.Preview(
						GetImage.SheOne,
						this.ilist.ImageSize
					);
				}
				else
				{
					img = ImageLoader.Preview(
						GetImage.NoOne,
						this.ilist.ImageSize
					);
				}

				Graphics g = Graphics.FromImage(img);
				g.CompositingQuality = System
					.Drawing
					.Drawing2D
					.CompositingQuality
					.HighQuality;
				g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
				//Pen pen = new Pen(Data.MetaData.SpecialSimColor, 3);
				//g.FillRectangle(pen.Brush, 0, 0, img.Width, img.Height); // what for??  makes these dark
				int pos = 2;
				if (sdesc.Unlinked != 0x00)
				{
					g.FillRectangle(
						new SolidBrush(Data.MetaData.UnlinkedSim),
						pos,
						2,
						20,
						20
					);
					pos += 22;
				}
				if (!sdesc.AvailableCharacterData)
				{
					g.FillRectangle(
						new SolidBrush(Data.MetaData.InactiveSim),
						pos,
						2,
						20,
						20
					);
					pos += 22;
				}
				if (sdesc.IsNPC)
				{
					g.FillRectangle(
						new SolidBrush(Data.MetaData.NPCSim),
						pos,
						2,
						20,
						20
					);
					pos += 22;
				}
				this.ilist.Images.Add(img);
				this.iListSmall.Images.Add(
					ImageLoader.Preview(img, iListSmall.ImageSize)
				);
			}
			else if (sdesc.HasImage) // if (sdesc.Image != null) -Chris H
			{
				this.ilist.Images.Add(sdesc.Image);
				this.iListSmall.Images.Add(
					ImageLoader.Preview(sdesc.Image, iListSmall.ImageSize)
				);
			}
			else
			{
				if (
					sdesc.CharacterDescription.Gender
					== Data.MetaData.Gender.Female
				)
				{
					this.ilist.Images.Add(new Bitmap(GetImage.SheOne));
					this.iListSmall.Images.Add(
						ImageLoader.Preview(
							new Bitmap(GetImage.SheOne),
							iListSmall.ImageSize
						)
					);
				}
				else
				{
					this.ilist.Images.Add(new Bitmap(GetImage.NoOne));
					this.iListSmall.Images.Add(
						ImageLoader.Preview(
							new Bitmap(GetImage.NoOne),
							iListSmall.ImageSize
						)
					);
				}
			}
		}

		protected void AddSim(PackedFiles.Wrapper.ExtSDesc sdesc)
		{
			AddImage(sdesc);
			ListViewItem lvi = new ListViewItem();
			lvi.Text = sdesc.SimName + " " + sdesc.SimFamilyName;
			lvi.ImageIndex = ilist.Images.Count - 1;
			lvi.Tag = sdesc;

			if (sdesc.FamilyInstance == 0)
			{
				lvi.SubItems.Add("None");
			}
			else
			{
				lvi.SubItems.Add(sdesc.HouseholdName);
			}

			if (sdesc.University.OnCampus == 0x1)
			{
				lvi.SubItems.Add(Localization.Manager.GetString("YoungAdult"));
			}
			else
			{
				lvi.SubItems.Add(
					new Data.LocalizedLifeSections(
						sdesc.CharacterDescription.LifeSection
					).ToString()
				);
			}

			string kind = "";
			if (
				System.IO.Path.GetFileNameWithoutExtension(sdesc.CharacterFileName)
				== "objects"
			)
			{
				kind = "NPC Unique";
			}
			else if (realIsNPC(sdesc))
			{
				kind = "Service Sim";
			}
			else if (realIsTownie(sdesc))
			{
				kind = "Townie";
			}
			else if (realIsPlayable(sdesc))
			{
				kind = "Playable";
			}
			else if (realIsUneditable(sdesc))
			{
				kind = "No Family";
			}

			lvi.SubItems.Add(kind);

			if (sdesc.CharacterDescription.Gender == Data.MetaData.Gender.Female)
			{
				lvi.SubItems.Add("Female");
			}
			else
			{
				lvi.SubItems.Add("Male");
			}

			if (sdesc.University.OnCampus == 0x1)
			{
				lvi.SubItems.Add(Localization.Manager.GetString("yes"));
			}
			else
			{
				lvi.SubItems.Add(Localization.Manager.GetString("no"));
			}

			lvi.SubItems.Add("0x" + Helper.HexString(sdesc.FileDescriptor.Instance));

			string avl = "";
			if (!sdesc.AvailableCharacterData)
			{
				if (System.IO.File.Exists(sdesc.CharacterFileName))
				{
					avl += "no Character Data";
				}
				else
				{
					avl += "no Character File";
				}
			}
			if (sdesc.Unlinked != 0x00)
			{
				if (avl != "")
				{
					avl += ", ";
				}

				avl += "Unlinked";
			}
			if (sdesc.CharacterDescription.GhostFlag.IsGhost && avl == "")
			{
				avl = "Deceased";
			}

			if (avl == "")
			{
				avl = "OK";
			}

			lvi.SubItems.Add(avl);
			lvi.SubItems.Add("0x" + Helper.HexString(sdesc.SimId));

			if (System.IO.File.Exists(sdesc.CharacterFileName))
			{
				System.IO.Stream s = System.IO.File.OpenRead(sdesc.CharacterFileName);
				double sz = s.Length / 1024.0;
				s.Close();
				s.Dispose();
				s = null;
				lvi.SubItems.Add(
					System.IO.Path.GetFileNameWithoutExtension(sdesc.CharacterFileName)
				);
				lvi.SubItems.Add(sz.ToString("N2") + "kb");
			}
			else
			{
				lvi.SubItems.Add("---");
				lvi.SubItems.Add("---");
			}
			if (
				sdesc.Nightlife.Species
				== PackedFiles.Wrapper.SdscNightlife.SpeciesType.Human
			)
			{
				lvi.SubItems.Add("Human");
			}
			else if (
				sdesc.Version == PackedFiles.Wrapper.SDescVersions.Castaway
				&& sdesc.Castaway.Subspecies == 2
			)
			{
				lvi.SubItems.Add("Orang-utan");
			}
			else if (
				sdesc.Version == PackedFiles.Wrapper.SDescVersions.Castaway
				&& sdesc.Castaway.Subspecies > 0
				&& (int)sdesc.Nightlife.Species == 3
			)
			{
				lvi.SubItems.Add("Leopard");
			}
			else if (
				sdesc.Version == PackedFiles.Wrapper.SDescVersions.Castaway
				&& sdesc.Castaway.Subspecies == 1
				&& (int)sdesc.Nightlife.Species < 3
			)
			{
				lvi.SubItems.Add("Wild Dog");
			}
			else if (
				sdesc.Nightlife.Species
				== PackedFiles.Wrapper.SdscNightlife.SpeciesType.LargeDog
			)
			{
				lvi.SubItems.Add("Large Dog");
			}
			else if (
				sdesc.Nightlife.Species
				== PackedFiles.Wrapper.SdscNightlife.SpeciesType.SmallDog
			)
			{
				lvi.SubItems.Add("Small Dog");
			}
			else if (
				sdesc.Nightlife.Species
				== PackedFiles.Wrapper.SdscNightlife.SpeciesType.Cat
			)
			{
				lvi.SubItems.Add("Cat");
			}
			else
			{
				lvi.SubItems.Add("Unknown");
			}

			lv.Items.Add(lvi);
		}

		protected void FillList()
		{
			this.Cursor = Cursors.WaitCursor;
			WaitingScreen.Wait();
			ilist.Images.Clear();
			this.iListSmall.Images.Clear();
			lv.BeginUpdate();
			lv.Items.Clear();
			Interfaces.Files.IPackedFileDescriptor[] pfds = package.FindFiles(
				Data.MetaData.SIM_DESCRIPTION_FILE
			);
			try
			{
				foreach (Interfaces.Files.IPackedFileDescriptor spfd in pfds)
				{
					Application.DoEvents();
					PackedFiles.Wrapper.ExtSDesc sdesc =
						new PackedFiles.Wrapper.ExtSDesc();
					sdesc.ProcessData(spfd, package);

					bool doAdd = false;
					doAdd |= (this.cbNpc.Checked && realIsNPC(sdesc));
					doAdd |= (this.cbTownie.Checked && realIsTownie(sdesc));
					doAdd |= (this.ckbPlayable.Checked && realIsPlayable(sdesc));
					doAdd |= (this.ckbUnEditable.Checked && realIsUneditable(sdesc));
					doAdd &= (!this.cbmens.Checked || !realIsWoman(sdesc));
					doAdd &= (!this.cbgals.Checked || realIsWoman(sdesc));
					doAdd &= (!this.cbadults.Checked || realIsAdult(sdesc));

					if (doAdd)
					{
						AddSim(sdesc);
					}
				}

				sorter.Sorting = lv.Sorting;
				lv.Sort();
			}
			finally
			{
				lv.EndUpdate();
				WaitingScreen.Stop(this);
				this.Cursor = Cursors.Default;
			}
		}

		private bool realIsNPC(PackedFiles.Wrapper.ExtSDesc sdesc)
		{
			return sdesc.FamilyInstance == 0x7fff;
		}

		private bool realIsTownie(PackedFiles.Wrapper.ExtSDesc sdesc)
		{
			return sdesc.FamilyInstance < 0x7fff && sdesc.FamilyInstance >= 0x7f00;
		}

		private bool realIsPlayable(PackedFiles.Wrapper.ExtSDesc sdesc)
		{
			return sdesc.FamilyInstance < 0x7f00 && sdesc.FamilyInstance > 0;
		}

		private bool realIsUneditable(PackedFiles.Wrapper.ExtSDesc sdesc)
		{
			return sdesc.FamilyInstance == 0 || sdesc.FamilyInstance > 0x7fff;
		}

		private bool realIsWoman(PackedFiles.Wrapper.ExtSDesc sdesc)
		{
			return sdesc.CharacterDescription.Gender == Data.MetaData.Gender.Female;
		}

		private bool realIsAdult(PackedFiles.Wrapper.ExtSDesc sdesc)
		{
			return sdesc.CharacterDescription.LifeSection
				== Data.MetaData.LifeSections.Adult;
		}

		Interfaces.Files.IPackedFileDescriptor pfd;
		Interfaces.Files.IPackageFile package;

		public Interfaces.Plugin.IToolResult Execute(
			ref Interfaces.Files.IPackedFileDescriptor pfd,
			ref Interfaces.Files.IPackageFile package,
			Interfaces.IProviderRegistry prov
		)
		{
			this.package = package;

			lv.ListViewItemSorter = sorter;
			this.Cursor = Cursors.WaitCursor;

			Idno idno = Idno.FromPackage(package);
			if (idno != null)
			{
				this.lbUbi.Visible = (idno.Type != NeighborhoodType.Normal);
			}

			this.pfd = null;

			lv.Sorting = SortOrder.Ascending;
			sorter.CurrentColumn = 3;

			FillList();

			this.Cursor = Cursors.Default;

			RemoteControl.ShowSubForm(this);

			this.package = null;

			if (this.pfd != null)
			{
				pfd = this.pfd;
			}

			return new ToolResult((this.pfd != null), false);
		}

		private void Open(object sender, EventArgs e)
		{
			if (lv.SelectedItems.Count < 1)
			{
				return;
			}

			pfd = (Interfaces.Files.IPackedFileDescriptor)
				((PackedFiles.Wrapper.SDesc)lv.SelectedItems[0].Tag).FileDescriptor;
			Close();
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (cbdetail.Checked)
			{
				lv.View = View.Details;
			}
			else
			{
				lv.View = View.LargeIcon;
			}
		}

		internal ColumnSorter sorter;

		private void SortList(
			object sender,
			ColumnClickEventArgs e
		)
		{
			if (sorter.CurrentColumn == e.Column)
			{
				if (lv.Sorting == SortOrder.Ascending)
				{
					lv.Sorting = SortOrder.Descending;
				}
				else
				{
					lv.Sorting = SortOrder.Ascending;
				}
			}
			else
			{
				sorter.CurrentColumn = e.Column;
				lv.ListViewItemSorter = sorter;
			}
			sorter.Sorting = lv.Sorting;
			lv.Sort();
		}

		private void ckbFilter_CheckedChanged(object sender, EventArgs e)
		{
			this.cbgals.Enabled = !this.cbmens.Checked;
			this.cbmens.Enabled = !this.cbgals.Checked;
			if (package != null)
			{
				this.FillList();
			}
		}

		private bool UseBigIcons
		{
			get
			{
				XmlRegistryKey rkf =
					Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey("SimBrowser");
				object o = rkf.GetValue("UseBiggerIcons", false);
				return Convert.ToBoolean(o);
			}
		}
	}
}
