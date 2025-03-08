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
				reg?.Dispose();

				reg = null;
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
				new System.ComponentModel.ComponentResourceManager(typeof(Sims));
			ilist = new ImageList(components);
			lv = new ListView();
			columnHeader1 = new ColumnHeader();
			columnHeader2 = new ColumnHeader();
			columnHeader3 = new ColumnHeader();
			chKind = new ColumnHeader();
			columnHeader10 = new ColumnHeader();
			columnHeader4 = new ColumnHeader();
			columnHeader5 = new ColumnHeader();
			columnHeader6 = new ColumnHeader();
			columnHeader9 = new ColumnHeader();
			columnHeader7 = new ColumnHeader();
			columnHeader8 = new ColumnHeader();
			columnHeader11 = new ColumnHeader();
			iListSmall = new ImageList(components);
			button1 = new Button();
			toolTip1 = new ToolTip(components);
			lbUbi = new Label();
			panel1 = new Panel();
			label1 = new Label();
			label2 = new Label();
			panel2 = new Panel();
			label3 = new Label();
			panel3 = new Panel();
			flowLayoutPanel1 = new FlowLayoutPanel();
			ckbPlayable = new CheckBox();
			cbTownie = new CheckBox();
			cbNpc = new CheckBox();
			ckbUnEditable = new CheckBox();
			cbgals = new CheckBox();
			cbmens = new CheckBox();
			cbadults = new CheckBox();
			cbdetail = new CheckBox();
			flowLayoutPanel1.SuspendLayout();
			SuspendLayout();
			//
			// ilist
			//
			ilist.ColorDepth = ColorDepth.Depth32Bit;
			resources.ApplyResources(ilist, "ilist");
			ilist.TransparentColor = Color.Transparent;
			//
			// lv
			//
			resources.ApplyResources(lv, "lv");
			lv.Columns.AddRange(
				new ColumnHeader[]
				{
					columnHeader1,
					columnHeader2,
					columnHeader3,
					chKind,
					columnHeader10,
					columnHeader4,
					columnHeader5,
					columnHeader6,
					columnHeader9,
					columnHeader7,
					columnHeader8,
					columnHeader11,
				}
			);
			lv.FullRowSelect = true;
			lv.HideSelection = false;
			lv.LargeImageList = ilist;
			lv.MultiSelect = false;
			lv.Name = "lv";
			lv.SmallImageList = iListSmall;
			lv.StateImageList = iListSmall;
			lv.UseCompatibleStateImageBehavior = false;
			lv.View = View.Details;
			lv.DoubleClick += new EventHandler(Open);
			lv.ColumnClick += new ColumnClickEventHandler(
				SortList
			);
			//
			// columnHeader1
			//
			resources.ApplyResources(columnHeader1, "columnHeader1");
			//
			// columnHeader2
			//
			resources.ApplyResources(columnHeader2, "columnHeader2");
			//
			// columnHeader3
			//
			resources.ApplyResources(columnHeader3, "columnHeader3");
			//
			// chKind
			//
			resources.ApplyResources(chKind, "chKind");
			//
			// columnHeader10
			//
			resources.ApplyResources(columnHeader10, "columnHeader10");
			//
			// columnHeader4
			//
			resources.ApplyResources(columnHeader4, "columnHeader4");
			//
			// columnHeader5
			//
			resources.ApplyResources(columnHeader5, "columnHeader5");
			//
			// columnHeader6
			//
			resources.ApplyResources(columnHeader6, "columnHeader6");
			//
			// columnHeader9
			//
			resources.ApplyResources(columnHeader9, "columnHeader9");
			//
			// columnHeader7
			//
			resources.ApplyResources(columnHeader7, "columnHeader7");
			//
			// columnHeader8
			//
			resources.ApplyResources(columnHeader8, "columnHeader8");
			//
			// columnHeader11
			//
			resources.ApplyResources(columnHeader11, "columnHeader11");
			//
			// iListSmall
			//
			iListSmall.ColorDepth = ColorDepth.Depth32Bit;
			resources.ApplyResources(iListSmall, "iListSmall");
			iListSmall.TransparentColor = Color.Transparent;
			//
			// button1
			//
			resources.ApplyResources(button1, "button1");
			button1.Name = "button1";
			button1.Click += new EventHandler(Open);
			//
			// lbUbi
			//
			lbUbi.BackColor = SystemColors.Window;
			resources.ApplyResources(lbUbi, "lbUbi");
			lbUbi.ForeColor = Color.Brown;
			lbUbi.Name = "lbUbi";
			//
			// panel1
			//
			resources.ApplyResources(panel1, "panel1");
			panel1.BackColor = Color.SteelBlue;
			panel1.Name = "panel1";
			//
			// label1
			//
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			//
			// label2
			//
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			//
			// panel2
			//
			resources.ApplyResources(panel2, "panel2");
			panel2.BackColor = Color.LightCoral;
			panel2.Name = "panel2";
			//
			// label3
			//
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			//
			// panel3
			//
			resources.ApplyResources(panel3, "panel3");
			panel3.BackColor = Color.YellowGreen;
			panel3.Name = "panel3";
			//
			// flowLayoutPanel1
			//
			resources.ApplyResources(flowLayoutPanel1, "flowLayoutPanel1");
			flowLayoutPanel1.Controls.Add(ckbPlayable);
			flowLayoutPanel1.Controls.Add(cbTownie);
			flowLayoutPanel1.Controls.Add(cbNpc);
			flowLayoutPanel1.Controls.Add(ckbUnEditable);
			flowLayoutPanel1.Controls.Add(cbgals);
			flowLayoutPanel1.Controls.Add(cbmens);
			flowLayoutPanel1.Controls.Add(cbadults);
			flowLayoutPanel1.Name = "flowLayoutPanel1";
			//
			// ckbPlayable
			//
			resources.ApplyResources(ckbPlayable, "ckbPlayable");
			ckbPlayable.Checked = true;
			ckbPlayable.CheckState = CheckState.Checked;
			ckbPlayable.Name = "ckbPlayable";
			ckbPlayable.UseVisualStyleBackColor = true;
			ckbPlayable.CheckedChanged += new EventHandler(
				ckbFilter_CheckedChanged
			);
			//
			// cbTownie
			//
			resources.ApplyResources(cbTownie, "cbTownie");
			cbTownie.Name = "cbTownie";
			cbTownie.CheckedChanged += new EventHandler(
				ckbFilter_CheckedChanged
			);
			//
			// cbNpc
			//
			resources.ApplyResources(cbNpc, "cbNpc");
			cbNpc.Name = "cbNpc";
			cbNpc.CheckedChanged += new EventHandler(
				ckbFilter_CheckedChanged
			);
			//
			// ckbUnEditable
			//
			resources.ApplyResources(ckbUnEditable, "ckbUnEditable");
			ckbUnEditable.Name = "ckbUnEditable";
			ckbUnEditable.UseVisualStyleBackColor = true;
			ckbUnEditable.CheckedChanged += new EventHandler(
				ckbFilter_CheckedChanged
			);
			//
			// cbgals
			//
			resources.ApplyResources(cbgals, "cbgals");
			cbgals.Name = "cbgals";
			cbgals.UseVisualStyleBackColor = true;
			cbgals.CheckedChanged += new EventHandler(
				ckbFilter_CheckedChanged
			);
			//
			// cbmens
			//
			resources.ApplyResources(cbmens, "cbmens");
			cbmens.Name = "cbmens";
			cbmens.UseVisualStyleBackColor = true;
			cbmens.CheckedChanged += new EventHandler(
				ckbFilter_CheckedChanged
			);
			//
			// cbadults
			//
			resources.ApplyResources(cbadults, "cbadults");
			cbadults.Name = "cbadults";
			cbadults.UseVisualStyleBackColor = true;
			cbadults.CheckedChanged += new EventHandler(
				ckbFilter_CheckedChanged
			);
			//
			// cbdetail
			//
			resources.ApplyResources(cbdetail, "cbdetail");
			cbdetail.Checked = true;
			cbdetail.CheckState = CheckState.Checked;
			cbdetail.Name = "cbdetail";
			cbdetail.CheckedChanged += new EventHandler(
				checkBox1_CheckedChanged
			);
			//
			// Sims
			//
			resources.ApplyResources(this, "$this");
			Controls.Add(cbdetail);
			Controls.Add(flowLayoutPanel1);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(panel3);
			Controls.Add(panel2);
			Controls.Add(panel1);
			Controls.Add(lbUbi);
			Controls.Add(button1);
			Controls.Add(lv);
			FormBorderStyle =
				FormBorderStyle
				.SizableToolWindow;
			Name = "Sims";
			flowLayoutPanel1.ResumeLayout(false);
			flowLayoutPanel1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion

		protected void AddImage(PackedFiles.Wrapper.ExtSDesc sdesc)
		{
			Image img = null;
			if (sdesc.Unlinked != 0x00 || !sdesc.AvailableCharacterData || sdesc.IsNPC)
			{
				img = sdesc.HasImage
					? ImageLoader.Preview(sdesc.Image, ilist.ImageSize)
					: sdesc.CharacterDescription.Gender
										== Data.MetaData.Gender.Female
						? ImageLoader.Preview(
											GetImage.SheOne,
											ilist.ImageSize
										)
						: ImageLoader.Preview(
											GetImage.NoOne,
											ilist.ImageSize
										);

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
				ilist.Images.Add(img);
				iListSmall.Images.Add(
					ImageLoader.Preview(img, iListSmall.ImageSize)
				);
			}
			else if (sdesc.HasImage) // if (sdesc.Image != null) -Chris H
			{
				ilist.Images.Add(sdesc.Image);
				iListSmall.Images.Add(
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
					ilist.Images.Add(new Bitmap(GetImage.SheOne));
					iListSmall.Images.Add(
						ImageLoader.Preview(
							new Bitmap(GetImage.SheOne),
							iListSmall.ImageSize
						)
					);
				}
				else
				{
					ilist.Images.Add(new Bitmap(GetImage.NoOne));
					iListSmall.Images.Add(
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
			ListViewItem lvi = new ListViewItem
			{
				Text = sdesc.SimName + " " + sdesc.SimFamilyName,
				ImageIndex = ilist.Images.Count - 1,
				Tag = sdesc
			};

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
			Cursor = Cursors.WaitCursor;
			WaitingScreen.Wait();
			ilist.Images.Clear();
			iListSmall.Images.Clear();
			lv.BeginUpdate();
			lv.Items.Clear();
			Interfaces.Files.IPackedFileDescriptor[] pfds = package.FindFiles(
				Data.FileTypes.SDSC
			);
			try
			{
				foreach (Interfaces.Files.IPackedFileDescriptor spfd in pfds)
				{
					Application.DoEvents();
					PackedFiles.Wrapper.ExtSDesc sdesc =
						new PackedFiles.Wrapper.ExtSDesc().ProcessFile(spfd, package);

					bool doAdd = false;
					doAdd |= cbNpc.Checked && realIsNPC(sdesc);
					doAdd |= cbTownie.Checked && realIsTownie(sdesc);
					doAdd |= ckbPlayable.Checked && realIsPlayable(sdesc);
					doAdd |= ckbUnEditable.Checked && realIsUneditable(sdesc);
					doAdd &= !cbmens.Checked || !realIsWoman(sdesc);
					doAdd &= !cbgals.Checked || realIsWoman(sdesc);
					doAdd &= !cbadults.Checked || realIsAdult(sdesc);

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
				Cursor = Cursors.Default;
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
				== LifeSections.Adult;
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
			Cursor = Cursors.WaitCursor;

			Idno idno = Idno.FromPackage(package);
			if (idno != null)
			{
				lbUbi.Visible = idno.Type != NeighborhoodType.Normal;
			}

			this.pfd = null;

			lv.Sorting = SortOrder.Ascending;
			sorter.CurrentColumn = 3;

			FillList();

			Cursor = Cursors.Default;

			RemoteControl.ShowSubForm(this);

			this.package = null;

			if (this.pfd != null)
			{
				pfd = this.pfd;
			}

			return new ToolResult(this.pfd != null, false);
		}

		private void Open(object sender, EventArgs e)
		{
			if (lv.SelectedItems.Count < 1)
			{
				return;
			}

			pfd =
				((PackedFiles.Wrapper.SDesc)lv.SelectedItems[0].Tag).FileDescriptor;
			Close();
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			lv.View = cbdetail.Checked ? View.Details : View.LargeIcon;
		}

		internal ColumnSorter sorter;

		private void SortList(
			object sender,
			ColumnClickEventArgs e
		)
		{
			if (sorter.CurrentColumn == e.Column)
			{
				lv.Sorting = lv.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
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
			cbgals.Enabled = !cbmens.Checked;
			cbmens.Enabled = !cbgals.Checked;
			if (package != null)
			{
				FillList();
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
