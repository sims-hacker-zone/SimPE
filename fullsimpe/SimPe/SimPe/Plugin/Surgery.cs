// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using SimPe.Data;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Cpf;
using SimPe.PackedFiles.Idno;
using SimPe.PackedFiles.Sdsc;
using SimPe.PackedFiles.ThreeIdr;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for Sims.
	/// </summary>
	public class Surgery : Form
	{
		private SimsRegistry reg;
		private ImageList ilist;
		private ListView lv;
		private Button button1;
		private Label label1;
		private GroupBox groupBox1;
		private GroupBox groupBox2;
		private GroupBox groupBox3;
		private PictureBox pbpatient;
		private PictureBox pbarche;
		private LinkLabel llusepatient;
		private LinkLabel llusearche;
		private LinkLabel llexport;
		private SaveFileDialog sfd;
		private ToolTip toolTip1;
		private CheckBox cbskin;
		private ListView lvskin;
		private ImageList iskin;
		private CheckBox cbface;
		private CheckBox cbmakeup;
		private CheckBox cbeye;
		private LinkLabel ctlLoadPackage;
		private OpenFileDialog opd;
		private Label lbUbi;
		private CheckBox cbgirls;
		private CheckBox cbmens;
		private CheckBox cbadults;
		private PropertyGrid pgPatientDetails;
		private PropertyGrid pgArchetypeDetails;
		internal CheckBox cbTownie;
		internal CheckBox cbNpc;
		private IContainer components;

		public Surgery()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			LoadArchetyp();
			reg = new SimsRegistry();
			cbTownie.Checked = reg.ShowTownies;
			cbNpc.Checked = reg.ShowNPCs;
			cbadults.Checked = reg.AdultsOnly;
			cbgirls.Checked = reg.JustGirls;

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
			components = new Container();
			ComponentResourceManager resources =
				new ComponentResourceManager(typeof(Surgery));
			ilist = new ImageList(components);
			lv = new ListView();
			button1 = new Button();
			label1 = new Label();
			lbUbi = new Label();
			groupBox1 = new GroupBox();
			pgPatientDetails = new PropertyGrid();
			cbeye = new CheckBox();
			cbmakeup = new CheckBox();
			llexport = new LinkLabel();
			pbpatient = new PictureBox();
			llusepatient = new LinkLabel();
			cbface = new CheckBox();
			groupBox2 = new GroupBox();
			pgArchetypeDetails = new PropertyGrid();
			ctlLoadPackage = new LinkLabel();
			llusearche = new LinkLabel();
			pbarche = new PictureBox();
			sfd = new SaveFileDialog();
			toolTip1 = new ToolTip(components);
			cbskin = new CheckBox();
			groupBox3 = new GroupBox();
			lvskin = new ListView();
			iskin = new ImageList(components);
			opd = new OpenFileDialog();
			cbgirls = new CheckBox();
			cbmens = new CheckBox();
			cbadults = new CheckBox();
			cbTownie = new CheckBox();
			cbNpc = new CheckBox();
			groupBox1.SuspendLayout();
			((ISupportInitialize)pbpatient).BeginInit();
			groupBox2.SuspendLayout();
			((ISupportInitialize)pbarche).BeginInit();
			groupBox3.SuspendLayout();
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
			lv.BorderStyle = BorderStyle.None;
			lv.HideSelection = false;
			lv.LargeImageList = ilist;
			lv.MultiSelect = false;
			lv.Name = "lv";
			lv.SmallImageList = ilist;
			lv.Sorting = SortOrder.Ascending;
			lv.StateImageList = ilist;
			toolTip1.SetToolTip(lv, resources.GetString("lv.ToolTip"));
			lv.UseCompatibleStateImageBehavior = false;
			lv.SelectedIndexChanged += new EventHandler(SelectSim);
			lv.DoubleClick += new EventHandler(Open);
			//
			// button1
			//
			resources.ApplyResources(button1, "button1");
			button1.Name = "button1";
			toolTip1.SetToolTip(
				button1,
				resources.GetString("button1.ToolTip")
			);
			button1.Click += new EventHandler(Open);
			//
			// label1
			//
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			//
			// lbUbi
			//
			lbUbi.BackColor = SystemColors.Window;
			resources.ApplyResources(lbUbi, "lbUbi");
			lbUbi.ForeColor = Color.Brown;
			lbUbi.Name = "lbUbi";
			//
			// groupBox1
			//
			resources.ApplyResources(groupBox1, "groupBox1");
			groupBox1.BackColor = Color.Transparent;
			groupBox1.Controls.Add(pgPatientDetails);
			groupBox1.Controls.Add(cbeye);
			groupBox1.Controls.Add(cbmakeup);
			groupBox1.Controls.Add(llexport);
			groupBox1.Controls.Add(pbpatient);
			groupBox1.Controls.Add(llusepatient);
			groupBox1.Controls.Add(cbface);
			groupBox1.Name = "groupBox1";
			//
			// pgPatientDetails
			//
			resources.ApplyResources(pgPatientDetails, "pgPatientDetails");
			pgPatientDetails.Name = "pgPatientDetails";
			pgPatientDetails.PropertySort =
				PropertySort
				.Categorized;
			pgPatientDetails.ToolbarVisible = false;
			//
			// cbeye
			//
			resources.ApplyResources(cbeye, "cbeye");
			cbeye.Name = "cbeye";
			toolTip1.SetToolTip(cbeye, resources.GetString("cbeye.ToolTip"));
			cbeye.CheckedChanged += new EventHandler(
				cbskin_CheckedChanged
			);
			//
			// cbmakeup
			//
			resources.ApplyResources(cbmakeup, "cbmakeup");
			cbmakeup.Name = "cbmakeup";
			toolTip1.SetToolTip(
				cbmakeup,
				resources.GetString("cbmakeup.ToolTip")
			);
			cbmakeup.CheckedChanged += new EventHandler(
				cbskin_CheckedChanged
			);
			//
			// llexport
			//
			resources.ApplyResources(llexport, "llexport");
			llexport.Name = "llexport";
			llexport.TabStop = true;
			toolTip1.SetToolTip(
				llexport,
				resources.GetString("llexport.ToolTip")
			);
			llexport.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(Export);
			//
			// pbpatient
			//
			pbpatient.BorderStyle = BorderStyle.FixedSingle;
			resources.ApplyResources(pbpatient, "pbpatient");
			pbpatient.Name = "pbpatient";
			pbpatient.TabStop = false;
			//
			// llusepatient
			//
			resources.ApplyResources(llusepatient, "llusepatient");
			llusepatient.Name = "llusepatient";
			llusepatient.TabStop = true;
			toolTip1.SetToolTip(
				llusepatient,
				resources.GetString("llusepatient.ToolTip")
			);
			llusepatient.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					UsePatient
				);
			//
			// cbface
			//
			resources.ApplyResources(cbface, "cbface");
			cbface.ForeColor = SystemColors.ControlText;
			cbface.Name = "cbface";
			toolTip1.SetToolTip(
				cbface,
				resources.GetString("cbface.ToolTip")
			);
			cbface.CheckedChanged += new EventHandler(
				cbskin_CheckedChanged
			);
			//
			// groupBox2
			//
			resources.ApplyResources(groupBox2, "groupBox2");
			groupBox2.BackColor = Color.Transparent;
			groupBox2.Controls.Add(pgArchetypeDetails);
			groupBox2.Controls.Add(ctlLoadPackage);
			groupBox2.Controls.Add(llusearche);
			groupBox2.Controls.Add(pbarche);
			groupBox2.Name = "groupBox2";
			//
			// pgArchetypeDetails
			//
			resources.ApplyResources(pgArchetypeDetails, "pgArchetypeDetails");
			pgArchetypeDetails.Name = "pgArchetypeDetails";
			pgArchetypeDetails.PropertySort =
				PropertySort
				.Categorized;
			pgArchetypeDetails.ToolbarVisible = false;
			//
			// ctlLoadPackage
			//
			resources.ApplyResources(ctlLoadPackage, "ctlLoadPackage");
			ctlLoadPackage.Name = "ctlLoadPackage";
			ctlLoadPackage.TabStop = true;
			toolTip1.SetToolTip(
				ctlLoadPackage,
				resources.GetString("ctlLoadPackage.ToolTip")
			);
			ctlLoadPackage.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					ctlLoadPackage_LinkClicked
				);
			//
			// llusearche
			//
			resources.ApplyResources(llusearche, "llusearche");
			llusearche.Name = "llusearche";
			llusearche.TabStop = true;
			toolTip1.SetToolTip(
				llusearche,
				resources.GetString("llusearche.ToolTip")
			);
			llusearche.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					UseArchetype
				);
			//
			// pbarche
			//
			resources.ApplyResources(pbarche, "pbarche");
			pbarche.BorderStyle = BorderStyle.FixedSingle;
			pbarche.Name = "pbarche";
			pbarche.TabStop = false;
			//
			// sfd
			//
			resources.ApplyResources(sfd, "sfd");
			//
			// toolTip1
			//
			toolTip1.AutoPopDelay = 30000;
			toolTip1.InitialDelay = 500;
			toolTip1.ReshowDelay = 100;
			//
			// cbskin
			//
			resources.ApplyResources(cbskin, "cbskin");
			cbskin.Name = "cbskin";
			toolTip1.SetToolTip(
				cbskin,
				resources.GetString("cbskin.ToolTip")
			);
			cbskin.CheckedChanged += new EventHandler(
				cbskin_CheckedChanged
			);
			//
			// groupBox3
			//
			resources.ApplyResources(groupBox3, "groupBox3");
			groupBox3.BackColor = Color.Transparent;
			groupBox3.Controls.Add(cbskin);
			groupBox3.Controls.Add(lvskin);
			groupBox3.Name = "groupBox3";
			//
			// lvskin
			//
			resources.ApplyResources(lvskin, "lvskin");
			lvskin.BorderStyle = BorderStyle.None;
			lvskin.HideSelection = false;
			lvskin.LargeImageList = iskin;
			lvskin.MultiSelect = false;
			lvskin.Name = "lvskin";
			lvskin.UseCompatibleStateImageBehavior = false;
			lvskin.SelectedIndexChanged += new EventHandler(
				lvskin_SelectedIndexChanged
			);
			//
			// iskin
			//
			iskin.ColorDepth = ColorDepth.Depth32Bit;
			resources.ApplyResources(iskin, "iskin");
			iskin.TransparentColor = Color.Transparent;
			//
			// opd
			//
			opd.DefaultExt = "package";
			opd.FileOk += new CancelEventHandler(
				opd_FileOk
			);
			//
			// cbgirls
			//
			resources.ApplyResources(cbgirls, "cbgirls");
			cbgirls.Name = "cbgirls";
			cbgirls.UseVisualStyleBackColor = true;
			cbgirls.CheckedChanged += new EventHandler(
				genderFilter_CheckedChanged
			);
			//
			// cbmens
			//
			resources.ApplyResources(cbmens, "cbmens");
			cbmens.Name = "cbmens";
			cbmens.UseVisualStyleBackColor = true;
			cbmens.CheckedChanged += new EventHandler(
				genderFilter_CheckedChanged
			);
			//
			// cbadults
			//
			resources.ApplyResources(cbadults, "cbadults");
			cbadults.Name = "cbadults";
			cbadults.UseVisualStyleBackColor = true;
			cbadults.CheckedChanged += new EventHandler(
				genderFilter_CheckedChanged
			);
			//
			// cbTownie
			//
			resources.ApplyResources(cbTownie, "cbTownie");
			cbTownie.Name = "cbTownie";
			cbTownie.CheckedChanged += new EventHandler(
				genderFilter_CheckedChanged
			);
			//
			// cbNpc
			//
			resources.ApplyResources(cbNpc, "cbNpc");
			cbNpc.Name = "cbNpc";
			cbNpc.CheckedChanged += new EventHandler(
				genderFilter_CheckedChanged
			);
			//
			// Surgery
			//
			resources.ApplyResources(this, "$this");
			Controls.Add(lbUbi);
			Controls.Add(cbTownie);
			Controls.Add(cbNpc);
			Controls.Add(cbgirls);
			Controls.Add(cbmens);
			Controls.Add(cbadults);
			Controls.Add(groupBox2);
			Controls.Add(groupBox1);
			Controls.Add(lv);
			Controls.Add(label1);
			Controls.Add(button1);
			Controls.Add(groupBox3);
			FormBorderStyle =
				FormBorderStyle
				.SizableToolWindow;
			Name = "Surgery";
			SizeGripStyle = SizeGripStyle.Show;
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			((ISupportInitialize)pbpatient).EndInit();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			((ISupportInitialize)pbarche).EndInit();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion

		protected void AddImage(ExtSDesc sdesc)
		{
			if (sdesc.HasImage) // if (sdesc.Image != null) -Chris H
			{
				ilist.Images.Add(sdesc.Image);
			}
			else
			{
				ilist.Images.Add(new Bitmap(GetImage.NoOne));
			}
		}

		private bool realIsNPC(ExtSDesc sdesc)
		{
			return sdesc.FamilyInstance == 0x7fff;
		}

		private bool realIsTownie(ExtSDesc sdesc)
		{
			return sdesc.FamilyInstance < 0x7fff && sdesc.FamilyInstance >= 0x7f00;
		}

		protected void AddSim(ExtSDesc sdesc)
		{
			if (!sdesc.AvailableCharacterData)
			{
				return;
			}

			if (sdesc.Nightlife.Species > 0)
			{
				return;
			}

			if (sdesc.IsNPC)
			{
				return;
			}

			if (
				sdesc.CharacterDescription.ServiceTypes
				== ServiceTypes.TinySim
			)
			{
				return;
			}

			if (
				(int)sdesc.Version
					== (int)SDescVersions.Castaway
				&& sdesc.Castaway.Subspecies > 0
			)
			{
				return;
			}

			if (!cbNpc.Checked && realIsNPC(sdesc))
			{
				return;
			}

			if (!cbTownie.Checked && realIsTownie(sdesc))
			{
				return;
			}

			if (
				cbadults.Checked
				&& sdesc.CharacterDescription.LifeSection
					!= LifeSections.Adult
			)
			{
				return;
			}

			if (
				cbmens.Checked
				&& sdesc.CharacterDescription.Gender == MetaData.Gender.Female
			)
			{
				return;
			}

			if (
				cbgirls.Checked
				&& sdesc.CharacterDescription.Gender == MetaData.Gender.Male
			)
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

		void LoadArchetyp()
		{
			iskin.Images.Add(
				new Bitmap(
					GetImage.SheOne,
					iskin.ImageSize.Width,
					iskin.ImageSize.Height
				)
			);
			ListViewItem lvia = new ListViewItem("From Archetype")
			{
				ImageIndex = 0
			};
			lvskin.Items.Add(lvia);
			lvia.Selected = true;
		}

		Hashtable skinfiles;

		void LoadSkins()
		{
			WaitingScreen.Wait();
			try
			{
				skinfiles = new Hashtable();
				ArrayList tones = new ArrayList();
				FileTableBase.FileIndex.Load();
				System.Collections.Generic.IEnumerable<Interfaces.Scenegraph.IScenegraphFileIndexItem> items =
					FileTableBase.FileIndex.FindFile(FileTypes.GZPS, true);
				foreach (
					Interfaces.Scenegraph.IScenegraphFileIndexItem item in items
				)
				{
					Cpf skin =
						new Cpf().ProcessFile(item);
					if (
						(skin.GetSaveItem("type").StringValue == "skin")
						&& (
							(
								skin.GetSaveItem("category").UIntegerValue
								& (uint)SkinCategories.Skin
							) == (uint)SkinCategories.Skin
						)
					)
					{
						//Maintain a List of all availabe SkinsFiles per skintone
						ArrayList files = null;
						string st = skin.GetSaveItem("skintone").StringValue;
						if (skinfiles.ContainsKey(st))
						{
							files = (ArrayList)skinfiles[st];
						}
						else
						{
							files = new ArrayList();
							skinfiles[st] = files;
						}
						files.Add(skin);

						if (
							(
								skin.GetSaveItem("override0subset").StringValue
									== "body"
								|| skin.GetSaveItem("override0subset").StringValue
									== "top"
							)
							&& skin.GetSaveItem("gender").UIntegerValue == 1
							&& skin.GetSaveItem("age").UIntegerValue
								== (uint)Ages.Adult
						)
						{
							WaitingScreen.UpdateMessage(
								skin.GetSaveItem("name").StringValue
							);

							if (tones.Contains(st))
							{
								continue;
							}
							else
							{
								tones.Add(st);
							}

							Interfaces.Scenegraph.IScenegraphFileIndexItem idr =
								FileTableBase.FileIndex.FindFile(
									FileTypes.THREE_IDR,
									item.FileDescriptor.Group,
									item.FileDescriptor.LongInstance,
									null
								).FirstOrDefault();
							if (idr != null)
							{

								ListViewItem lvi = new ListViewItem(
									skin.GetSaveItem("name").StringValue
								);
								if (Helper.WindowsRegistry.Config.HiddenMode)
								{
									lvi.Text +=
										" ("
										+ skin.GetSaveItem("skintone").StringValue
										+ ")";
								}

								lvi.Tag = skin.GetSaveItem("skintone").StringValue;
								foreach (
									Interfaces.Files.IPackedFileDescriptor pfd in new ThreeIdr().ProcessFile(idr).Items
								)
								{
									if (pfd.Type == FileTypes.TXMT)
									{
										Interfaces.Scenegraph.IScenegraphFileIndexItem txmt =
											FileTableBase.FileIndex.FindFile(pfd, null).FirstOrDefault();
										if (txmt != null)
										{
											Rcol rcol = new GenericRcol(
												null,
												false
											).ProcessFile(txmt);

											string txtrname =
												((MaterialDefinition)
												rcol.Blocks[0]).FindProperty(
													"stdMatBaseTextureName"
												).Value + "_txtr";

											Interfaces.Scenegraph.IScenegraphFileIndexItem txtri =
												FileTableBase.FileIndex.FindFileByName(
													txtrname,
													FileTypes.TXTR,
													MetaData.LOCAL_GROUP,
													true
												);
											if (txtri != null)
											{
												rcol = new GenericRcol(null, false).ProcessFile(txtri);

												MipMap mm = ((ImageData)
													rcol.Blocks[0]).GetLargestTexture(
													iskin.ImageSize
												);

												if (mm != null)
												{
													iskin.Images.Add(
														ImageLoader.Preview(
															mm.Texture,
															iskin.ImageSize
														)
													);
													lvi.ImageIndex =
														iskin.Images.Count - 1;
												}
											}
										}
									}
								} //foreach reffile.Items

								lvskin.Items.Add(lvi);
							} //if idr
						}
					} // Don't need to process evry item of clothing do we
				} //foreach items
			}
			finally
			{
				WaitingScreen.UpdateImage(null);
				WaitingScreen.Stop();
			}
			Application.UseWaitCursor = false;
		}

		Interfaces.Files.IPackedFileDescriptor pfd;
		Interfaces.IProviderRegistry prov;
		Interfaces.Files.IPackageFile ngbh;

		public Interfaces.Plugin.IToolResult Execute(
			ref Interfaces.Files.IPackedFileDescriptor pfd,
			ref Interfaces.Files.IPackageFile package,
			Interfaces.IProviderRegistry prov
		)
		{
			Cursor = Cursors.WaitCursor;

			Idno idno = Idno.FromPackage(package);
			if (idno != null)
			{
				lbUbi.Visible = idno.Type != NeighborhoodType.Normal;
			}

			this.pfd = null;
			this.prov = prov;
			ngbh = package;

			pbarche.Image = null;
			pbpatient.Image = null;

			spatient = null;
			sarche = null;
			tarcheFile = null;

			button1.Enabled = false;

			ilist.Images.Clear();
			lv.Items.Clear();

			WaitingScreen.Wait();
			try
			{
				foreach (Interfaces.Files.IPackedFileDescriptor spfd in package.FindFiles(
				FileTypes.SDSC
			))
				{
					AddSim(new PackedFiles.Sdsc.ExtSDesc().ProcessFile(spfd, package));
				}

				Cursor = Cursors.Default;
				llusearche.Enabled = false;
				llusepatient.Enabled = false;
				llexport.Enabled = false;
				if (lv.Items.Count > 0)
				{
					lv.Items[0].Selected = true;
				}
			}
			finally
			{
				WaitingScreen.Stop(this);
			}
			RemoteControl.ShowSubForm(this);

			if (this.pfd != null)
			{
				pfd = this.pfd;
			}

			return new ToolResult(this.pfd != null, false);
		}

		private void Open(object sender, EventArgs e)
		{
			if (!CanDo())
			{
				return;
			}

			Packages.File patient = Packages.File.LoadFromFile(
				spatient.CharacterFileName
			);
			Packages.File archetype = null;
			if (sarche != null)
			{
				archetype = Packages.File.LoadFromFile(sarche.CharacterFileName);
			}
			else if (tarcheFile != null)
			{
				archetype = Packages.File.LoadFromFile(tarcheFile);
				if (!CheckArchetypeFile(archetype))
				{
					Helper.ExceptionMessage(
						"The selected template file is not valid.",
						new ApplicationException()
					);
					return;
				}
			}
			else
			{
				archetype = Packages.File.LoadFromFile(null);
			}

			Packages.GeneratableFile newpackage = null;
			PlasticSurgery ps = new PlasticSurgery(
				ngbh,
				patient,
				spatient,
				archetype,
				sarche
			);

			if (
				!cbskin.Checked
				&& !cbface.Checked
				&& !cbmakeup.Checked
				&& !cbeye.Checked
			)
			{
				newpackage = ps.CloneSim();
			}

			if (cbskin.Checked)
			{
				if (lvskin.SelectedItems.Count == 0)
				{
					return;
				}

				string skin = (string)lvskin.SelectedItems[0].Tag;
				newpackage = skin == null ? ps.CloneSkinTone(skinfiles) : ps.CloneSkinTone(skin, skinfiles);
			}

			if (cbface.Checked)
			{
				if (cbskin.Checked)
				{
					ps = new PlasticSurgery(
						ngbh,
						newpackage,
						spatient,
						archetype,
						sarche
					);
				}

				newpackage = ps.CloneFace();
			}

			if (cbmakeup.Checked)
			{
				if (cbskin.Checked || cbface.Checked)
				{
					ps = new PlasticSurgery(
						ngbh,
						newpackage,
						spatient,
						archetype,
						sarche
					);
				}

				newpackage = ps.CloneMakeup(false, true);
			}

			if (cbeye.Checked)
			{
				if (
					cbskin.Checked
					|| cbface.Checked
					|| cbmakeup.Checked
				)
				{
					ps = new PlasticSurgery(
						ngbh,
						newpackage,
						spatient,
						archetype,
						sarche
					);
				}

				newpackage = ps.CloneMakeup(true, false);
			}

			if (newpackage != null)
			{
				newpackage.Save(spatient.CharacterFileName);
				prov.SimNameProvider.StoredData = null;
				Close();
			}
		}

		private void SelectSim(object sender, EventArgs e)
		{
			llusearche.Enabled = false;
			llusepatient.Enabled = false;
			if (lv.SelectedItems.Count == 0)
			{
				return;
			}

			llusearche.Enabled = true;
			llusepatient.Enabled = !(
				(ExtSDesc)lv.SelectedItems[0].Tag
			).IsNPC;
		}

		SDesc spatient = null;
		SDesc sarche = null;

		private void UsePatient(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			llexport.Enabled = spatient != null;
			if (lv.SelectedItems.Count == 0)
			{
				return;
			}

			if (lv.SelectedItems[0].ImageIndex >= 0)
			{
				pbpatient.Image = ilist.Images[lv.SelectedItems[0].ImageIndex];
			}

			spatient = (SDesc)lv.SelectedItems[0].Tag;

			button1.Enabled =
				(pbpatient.Image != null)
				&& (sarche != null || tarcheFile != null);
			pfd = spatient.FileDescriptor;
			llexport.Enabled = spatient != null;
			ShowSimDetails(spatient, pgPatientDetails);
		}

		private void UseArchetype(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (lv.SelectedItems.Count == 0)
			{
				return;
			}

			if (lv.SelectedItems[0].ImageIndex >= 0)
			{
				pbarche.Image = ilist.Images[lv.SelectedItems[0].ImageIndex];
			}

			iskin.Images[0] = ImageLoader.Preview(pbarche.Image, iskin.ImageSize);
			lvskin.Refresh();

			sarche = (SDesc)lv.SelectedItems[0].Tag;
			button1.Enabled = (pbpatient.Image != null) && (sarche != null);
			ShowSimDetails(sarche, pgArchetypeDetails);
		}

		protected void FaceSurgery()
		{
			try
			{
				Packages.GeneratableFile patient =
					Packages.File.LoadFromFile(
						spatient.CharacterFileName
					);
				Packages.File archetype = null;
				if (sarche != null)
				{
					archetype = Packages.File.LoadFromFile(
						sarche.CharacterFileName
					);
				}
				else if (tarcheFile != null)
				{
					archetype = Packages.File.LoadFromFile(tarcheFile);
				}

				if (!CheckArchetypeFile(archetype))
				{
					Helper.ExceptionMessage(
						"The selected template file is not valid.",
						new ApplicationException()
					);
					return;
				}

				//Load Facial Data
				Interfaces.Files.IPackedFileDescriptor[] apfds = archetype.FindFiles(
					FileTypes.LxNR
				); //LxNR, Face
				if (apfds.Length == 0)
				{
					return;
				}

				Interfaces.Files.IPackedFile file = archetype.Read(apfds[0]);

				Interfaces.Files.IPackedFileDescriptor[] ppfds = patient.FindFiles(
					FileTypes.LxNR
				); //LxNR, Face
				if (ppfds.Length == 0)
				{
					return;
				}

				ppfds[0].UserData = file.UncompressedData;

				//System.IO.MemoryStream ms = patient.Build();
				//patient.Reader.Close();
				patient.Save(spatient.CharacterFileName);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					"Unable to update the new Character Package.",
					ex
				);
			}
		}

		private void Export(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (spatient == null)
			{
				return;
			}

			try
			{
				//list of all Files top copy from the Archetype
				ArrayList list = new ArrayList
				{
					FileTypes.THREE_IDR, //3IDR
					FileTypes.CRES,
					FileTypes.GZPS,
					FileTypes.AGED, //AGED
					FileTypes.LxNR, //LxNR, Face
					(uint)FileTypes.BINX, //BINX
					FileTypes.GMDC,
					(uint)FileTypes.GMND,
					(uint)FileTypes.TXMT, //MATD
					FileTypes.SHPE
				};

				System.IO.BinaryReader br1 = new System.IO.BinaryReader(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.files.3d.simpe")
				);
				System.IO.BinaryReader br2 = new System.IO.BinaryReader(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.files.bin.simpe")
				);

				Packages.PackedFileDescriptor pfd1 =
					new Packages.PackedFileDescriptor
					{
						Group = 0xffffffff,
						SubType = 0x00000000,
						Instance = 0xFF123456,
						Type = FileTypes.THREE_IDR, //3IDR
						UserData = br1.ReadBytes((int)br1.BaseStream.Length)
					};

				Packages.PackedFileDescriptor pfd2 =
					new Packages.PackedFileDescriptor
					{
						Group = 0xffffffff,
						SubType = 0x00000000,
						Instance = 0xFF123456,
						Type = FileTypes.BINX, //BINX
						UserData = br2.ReadBytes((int)br2.BaseStream.Length)
					};

				sfd.InitialDirectory = System.IO.Path.Combine(
					PathProvider.SimSavegameFolder,
					"SavedSims"
				);
				sfd.FileName = System.IO.Path.GetFileNameWithoutExtension(
					spatient.CharacterFileName
				);

				Packages.GeneratableFile source =
					Packages.File.LoadFromFile(
						spatient.CharacterFileName
					);
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					Packages.GeneratableFile patient =
						Packages.File.LoadFromStream(
							null
						);
					patient.FileName = "";
					patient.Add(pfd1);
					patient.Add(pfd2);

					foreach (Interfaces.Files.IPackedFileDescriptor pfd in source.Index)
					{
						if (list.Contains(pfd.Type))
						{
							Interfaces.Files.IPackedFile file = source.Read(pfd);
							pfd.UserData = file.UncompressedData;
							patient.Add(pfd);

							if (
								(pfd.Type == FileTypes.GZPS)
								|| (pfd.Type == FileTypes.AGED)
							) //property set and 3IDR
							{
								Cpf cpf =
									new Cpf().ProcessFile(pfd, patient);

								CpfItem ci =
									new CpfItem
									{
										Name = "product",
										UIntegerValue = 0
									};
								cpf.AddItem(ci, false);

								ci = cpf.GetItem("version");
								if (ci == null)
								{
									ci = new CpfItem
									{
										Name = "version"
									};
									ci.UIntegerValue = (
											cpf.GetSaveItem("age").UIntegerValue
											& (uint)Ages.YoungAdult
										) != 0
										? 2
										: (uint)1;

									cpf.AddItem(ci);
								}

								cpf.SynchronizeUserData();
							}
						}
					}
					patient.Save(sfd.FileName);
				}
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}

		bool CanDo()
		{
			if (spatient == null)
			{
				return false;
			}

			bool ret = true;
			if (cbskin.Checked)
			{
				ret = lvskin.SelectedItems.Count == 1;
				if (ret)
				{
					if (
						lvskin.Items[0].Selected
						&& sarche == null && tarcheFile == null
					)
					{
						ret = false;
					}
				}
			}

			if (!cbskin.Checked || cbface.Checked || cbmakeup.Checked || cbeye.Checked)
			{
				ret = ret && (sarche != null || tarcheFile != null);
			}

			return ret;
		}

		bool skload = false;

		private void cbskin_CheckedChanged(object sender, EventArgs e) // Fuck
		{
			if (!skload)
			{
				LoadSkins();
			}

			lvskin.Enabled = cbskin.Checked;
			button1.Enabled = CanDo();
			skload = true;
		}

		private void lvskin_SelectedIndexChanged(object sender, EventArgs e)
		{
			button1.Enabled = CanDo();
		}

		private void ctlLoadPackage_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			opd.InitialDirectory = System.IO.Path.Combine(
				PathProvider.SimSavegameFolder,
				"SavedSims"
			);
			opd.ShowDialog();
		}

		private void opd_FileOk(object sender, CancelEventArgs e)
		{
			if (!e.Cancel)
			{
				tarcheFile = opd.FileName;
				if (
					CheckArchetypeFile(
						Packages.File.LoadFromFile(tarcheFile)
					)
				)
				{
					button1.Enabled = spatient != null;
					pbarche.Image = GetImage.NoOne;
					ShowSimDetails(
						Packages.File.LoadFromFile(tarcheFile),
						pgArchetypeDetails
					);
				}
				else
				{
					tarcheFile = null;
					sarche = null;
					button1.Enabled = false;
					pbarche.Image = GetIcon.Fail;
					pgArchetypeDetails.SelectedObject = null;
				}
				iskin.Images[0] = ImageLoader.Preview(pbarche.Image, iskin.ImageSize);
				lvskin.Refresh();
			}
		}

		string tarcheFile = null;

		/// <summary>
		/// Checks if an arbitrary package contains the file types required
		/// for archetype elegibility.
		/// </summary>
		/// <param name="archeFile"></param>
		/// <returns>True if the provided package can be a surgery archetype, otherwise false.</returns>
		bool CheckArchetypeFile(Packages.File archeFile)
		{
			bool ret = false;
			if (archeFile == null)
			{
				return ret;
			}

			// Build a list of required file types.
			// Could this list be static?
			ArrayList list = new ArrayList
			{
				FileTypes.THREE_IDR,
				FileTypes.GZPS,
				FileTypes.AGED,
				FileTypes.LxNR
			};
			// For now we disregard the user options, and consider
			// all these types mandatory.
			for (
				int i = 0;
				i < list.Count && (ret = ContainsType(archeFile.Index, (FileTypes)list[i]));
				i++
			)
			{
				;
			}

			return ret;
		}

		static bool ContainsType(
			Interfaces.Files.IPackedFileDescriptor[] index,
			FileTypes type
		)
		{
			for (int i = 0; i < index.Length; i++)
			{
				if (index[i].Type == type && index[i].Group == 0xffffffff)
				{
					return true;
				}
			}

			return false;
		}

		protected void FillList()
		{
			Cursor = Cursors.WaitCursor;

			pbarche.Image = null;
			pbpatient.Image = null;
			pgPatientDetails.SelectedObject = null;
			pgArchetypeDetails.SelectedObject = null;

			iskin.Images[0] = cbmens.Checked
				? ImageLoader.Preview(
					GetImage.NoOne,
					iskin.ImageSize
				)
				: ImageLoader.Preview(
					GetImage.SheOne,
					iskin.ImageSize
				);

			lvskin.Refresh();

			spatient = null;
			sarche = null;
			tarcheFile = null;

			button1.Enabled = false;
			ilist.Images.Clear();
			lv.Items.Clear();

			WaitingScreen.Wait();
			try
			{
				foreach (Interfaces.Files.IPackedFileDescriptor spfd in ngbh.FindFiles(
				FileTypes.SDSC
			))
				{
					AddSim(new PackedFiles.Sdsc.ExtSDesc().ProcessFile(spfd, ngbh));
				}

				Cursor = Cursors.Default;
				llusearche.Enabled = false;
				llusepatient.Enabled = false;
				llexport.Enabled = false;
				if (lv.Items.Count > 0)
				{
					lv.Items[0].Selected = true;
				}
			}
			finally
			{
				WaitingScreen.Stop(this);
			}
		}

		private void genderFilter_CheckedChanged(object sender, EventArgs e)
		{
			cbgirls.Enabled = !cbmens.Checked;
			cbmens.Enabled = !cbgirls.Checked;
			if (ngbh != null)
			{
				FillList();
			}
		}

		void ShowSimDetails(SDesc sim, PropertyGrid pg)
		{
			Packages.File package = Packages.File.LoadFromFile(
				sim.CharacterFileName
			);
			if (package != null)
			{
				Interfaces.Files.IPackedFileDescriptor pfdAged = package.FindFile(
					FileTypes.AGED,
					0,
					MetaData.LOCAL_GROUP,
					1
				);
				if (pfdAged != null)
				{

					SimInfo nfo = new SimInfo(
						new Cpf().ProcessFile(pfdAged, package, true),
						System.IO.Path.GetFileName(sim.CharacterFileName),
						string.Format("{0} {1}", sim.SimName, sim.SimFamilyName)
					);
					pg.SelectedObject = nfo;
				}
			}
		}

		void ShowSimDetails(Packages.File package, PropertyGrid pg)
		{
			Interfaces.Files.IPackedFileDescriptor pfdAged = package.FindFile(
				FileTypes.AGED,
				0,
				MetaData.LOCAL_GROUP,
				1
			);
			if (pfdAged != null)
			{
				pg.SelectedObject = new SimInfo(
					new Cpf().ProcessFile(pfdAged, package, true),
					System.IO.Path.GetFileName(package.FileName),
					null
				);
			}
		}
	}

	/// <summary>
	/// A simple info object for PropertyGrid presentation purposes.
	/// </summary>
	internal sealed class SimInfo
	{
		Cpf ageData;

		[Category("General")]
		public Ages Age => (Ages)ageData.GetItem("age").UIntegerValue;

		[Category("General")]
		public Data.SimGender Gender => (Data.SimGender)ageData.GetItem("gender").UIntegerValue;

		[Category("General")]
		public string Name
		{
			get;
		}

		[Category("General")]
		public string Filename
		{
			get;
		}

		[Category("Genetics")]
		public string Hair => ageData.GetItem("haircolor").StringValue;

		[Category("Genetics")]
		public string Eyes => ageData.GetItem("eyecolor").StringValue;

		[Category("Genetics")]
		public string Skin => ageData.GetItem("skincolor").StringValue;

		[Category("Genetics")]
		public string Bodyshape => MetaData.GetBodyName(
					MetaData.GetBodyShapeid(
						ageData.GetItem("skincolor").StringValue
					)
				);

		public SimInfo(Cpf aged, string filename, string name)
		{
			ageData = aged ?? throw new ArgumentNullException();
			Filename = filename;
			Name = name;
		}
	}
}
