// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using SimPe.PackedFiles.Sdsc;
using SimPe.PackedFiles.Wrapper;

namespace SimPe.PackedFiles.Famt
{
	/// <summary>
	/// Summary description for FamilyTiesForm.
	/// </summary>
	public class FamilyTiesForm : Form
	{
		private IContainer components;

		public FamilyTiesForm()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			ties.Parent = null;
			ties.Parent = panel1;

			cbrel.Enum = typeof(Data.MetaData.FamilyTieTypes);
			cbrel.ResourceManager = Localization.Manager;
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
				new ComponentResourceManager(
					typeof(FamilyTiesForm)
				);
			pnfamt = new Panel();
			panel1 = new Panel();
			ties = new FamilyTieGraph();
			panel4 = new Panel();
			cbLock = new CheckBox();
			label1 = new Label();
			panel3 = new Panel();
			xpGradientPanel1 = new SteepValley.Windows.Forms.XPGradientPanel();
			xpLine1 = new SteepValley.Windows.Forms.XPLine();
			button1 = new Button();
			cbkeep = new CheckBox();
			cbrel = new Ambertation.Windows.Forms.EnumComboBox();
			llrem = new LinkLabel();
			label3 = new Label();
			lbname = new Label();
			label2 = new Label();
			panel2 = new Panel();
			pool = new SimPoolControl();
			miTies = new ContextMenuStrip(components);
			miAddTie = new ToolStripMenuItem();
			miOpenSdesc = new ToolStripMenuItem();
			label12 = new Label();
			pnfamt.SuspendLayout();
			panel1.SuspendLayout();
			panel4.SuspendLayout();
			panel3.SuspendLayout();
			xpGradientPanel1.SuspendLayout();
			panel2.SuspendLayout();
			miTies.SuspendLayout();
			SuspendLayout();
			//
			// pnfamt
			//
			pnfamt.BackColor = SystemColors.Control;
			pnfamt.BackgroundImage = null;
			pnfamt.Controls.Add(panel1);
			pnfamt.Controls.Add(panel4);
			pnfamt.Controls.Add(panel3);
			pnfamt.Controls.Add(panel2);
			resources.ApplyResources(pnfamt, "pnfamt");
			pnfamt.Name = "pnfamt";
			//
			// panel1
			//
			resources.ApplyResources(panel1, "panel1");
			panel1.BackColor = SystemColors.ControlLightLight;
			panel1.Controls.Add(ties);
			panel1.Name = "panel1";
			//
			// ties
			//
			resources.ApplyResources(ties, "ties");
			ties.BackColor = SystemColors.ControlLightLight;
			ties.LineMode = Ambertation
				.Windows
				.Forms
				.Graph
				.LinkControlLineMode
				.Bezier;
			ties.LockItems = false;
			ties.MinHeight = 344;
			ties.MinWidth = 720;
			ties.Name = "ties";
			ties.Quality = true;
			ties.SaveBounds = true;
			ties.SelectedElement = null;
			ties.SelectedSimChanged +=
				new SimPoolControl.SelectedSimHandler(
					ties_SelectedSimChanged
				);
			ties.DoubleClickSim +=
				new SimPoolControl.SelectedSimHandler(
					ties_DoubleClickSim
				);
			//
			// panel3
			//
			panel4.AccessibleDescription = null;
			panel4.AccessibleName = null;
			resources.ApplyResources(panel4, "panel4");
			panel4.BackColor = Color.FromArgb(
				120,
				0,
				0,
				0
			);
			panel4.BackgroundImage = null;
			panel4.Controls.Add(cbLock);
			panel4.Controls.Add(label1);
			panel4.ForeColor = SystemColors.ActiveCaptionText;
			panel4.Name = "panel4";
			//
			// cbLock
			//
			resources.ApplyResources(cbLock, "cbLock");
			cbLock.BackColor = Color.Transparent;
			cbLock.Name = "cbLock";
			cbLock.UseVisualStyleBackColor = false;
			//
			// label1
			//
			label1.AccessibleDescription = null;
			label1.AccessibleName = null;
			resources.ApplyResources(label1, "label1");
			label1.BackColor = Color.Transparent;
			label1.Font = null;
			label1.Name = "label1";
			//
			// panel3
			//
			panel3.AccessibleDescription = null;
			panel3.AccessibleName = null;
			resources.ApplyResources(panel3, "panel3");
			panel3.BackgroundImage = null;
			panel3.Controls.Add(xpGradientPanel1);
			panel3.Font = null;
			panel3.Name = "panel3";
			//
			// xpGradientPanel1
			//
			xpGradientPanel1.AccessibleDescription = null;
			xpGradientPanel1.AccessibleName = null;
			resources.ApplyResources(xpGradientPanel1, "xpGradientPanel1");
			xpGradientPanel1.BackgroundImage = null;
			xpGradientPanel1.Controls.Add(xpLine1);
			xpGradientPanel1.Controls.Add(button1);
			xpGradientPanel1.Controls.Add(cbkeep);
			xpGradientPanel1.Controls.Add(cbrel);
			xpGradientPanel1.Controls.Add(llrem);
			xpGradientPanel1.Controls.Add(label3);
			xpGradientPanel1.Controls.Add(lbname);
			xpGradientPanel1.Controls.Add(label2);
			xpGradientPanel1.Font = null;
			xpGradientPanel1.Name = "xpGradientPanel1";
			xpGradientPanel1.Watermark = null;
			//
			// xpLine1
			//
			resources.ApplyResources(xpLine1, "xpLine1");
			xpLine1.BackColor = Color.Transparent;
			xpLine1.BackgroundImage = null;
			xpLine1.Font = null;
			xpLine1.ForeColor = Color.Transparent;
			xpLine1.LineColor = Color.FromArgb(
				125,
				0,
				0,
				0
			);
			xpLine1.Name = "xpLine1";
			xpLine1.Orientation = System
				.Drawing
				.Drawing2D
				.LinearGradientMode
				.Vertical;
			//
			// button1
			//
			button1.AccessibleDescription = null;
			button1.AccessibleName = null;
			resources.ApplyResources(button1, "button1");
			button1.BackgroundImage = null;
			button1.Name = "button1";
			button1.Click += new EventHandler(button1_Click);
			//
			// cbkeep
			//
			resources.ApplyResources(cbkeep, "cbkeep");
			cbkeep.BackColor = Color.Transparent;
			cbkeep.Checked = true;
			cbkeep.CheckState = CheckState.Checked;
			cbkeep.Name = "cbkeep";
			cbkeep.UseVisualStyleBackColor = false;
			//
			// cbrel
			//
			cbrel.DropDownStyle = ComboBoxStyle.DropDownList;
			cbrel.Enum = null;
			resources.ApplyResources(cbrel, "cbrel");
			cbrel.ForeColor = SystemColors.ControlText;
			cbrel.Name = "cbrel";
			cbrel.ResourceManager = null;
			cbrel.SelectedIndexChanged += new EventHandler(
				cbrel_SelectedIndexChanged
			);
			//
			// llrem
			//
			llrem.BackColor = Color.Transparent;
			resources.ApplyResources(llrem, "llrem");
			llrem.Name = "llrem";
			llrem.TabStop = true;
			llrem.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					llrem_LinkClicked
				);
			//
			// label3
			//
			label3.BackColor = Color.Transparent;
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			//
			// lbname
			//
			resources.ApplyResources(lbname, "lbname");
			lbname.BackColor = Color.Transparent;
			lbname.Name = "lbname";
			//
			// label2
			//
			label2.BackColor = Color.Transparent;
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			//
			// panel2
			//
			panel2.BackColor = SystemColors.Info;
			panel2.Controls.Add(pool);
			resources.ApplyResources(panel2, "panel2");
			panel2.Name = "panel2";
			//
			// pool
			//
			pool.ContextMenuStrip = miTies;
			resources.ApplyResources(pool, "pool");
			pool.Name = "pool";
			pool.Package = null;
			pool.RightClickSelect = false;
			pool.SelectedElement = null;
			pool.SelectedSim = null;
			pool.SimDetails = false;
			pool.TileColumns = new int[] { 1 };
			pool.ClickOverSim +=
				new SimPoolControl.SelectedSimHandler(
					pool_ClickOverSim
				);
			pool.SelectedSimChanged +=
				new SimPoolControl.SelectedSimHandler(
					pool_SelectedSimChanged
				);
			//
			// miTies
			//
			miTies.Items.AddRange(
				new ToolStripItem[]
				{
					miAddTie,
					miOpenSdesc,
				}
			);
			miTies.Name = "miTies";
			resources.ApplyResources(miTies, "miTies");
			miTies.VisibleChanged += new EventHandler(
				miAddTie_BeforePopup
			);
			//
			// miAddTie
			//
			miAddTie.Name = "miAddTie";
			resources.ApplyResources(miAddTie, "miAddTie");
			miAddTie.Tag = "\"{name}\" in die Familie von \"{gname}\" aufnehmen";
			miAddTie.Click += new EventHandler(Activate_miAddTie);
			//
			// miOpenSdesc
			//
			resources.ApplyResources(miOpenSdesc, "miOpenSdesc");
			miOpenSdesc.Name = "miOpenSdesc";
			miOpenSdesc.Click += new EventHandler(
				Activate_miOpenSDesc
			);
			//
			// label12
			//
			resources.ApplyResources(label12, "label12");
			label12.Name = "label12";
			//
			// FamilyTiesForm
			//
			resources.ApplyResources(this, "$this");
			Controls.Add(pnfamt);
			Name = "FamilyTiesForm";
			pnfamt.ResumeLayout(false);
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel3.ResumeLayout(false);
			panel2.ResumeLayout(false);
			miTies.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion

		internal Panel pnfamt;
		private Panel panel2;
		private Panel panel4;
		internal Label label12;
		internal SimPoolControl pool;
		private Panel panel1;
		internal FamilyTieGraph ties;

		internal ExtFamilyTies wrapper;
		private ContextMenuStrip miTies;
		private ToolStripMenuItem miAddTie;

		SDesc lastsdsc,
			currentsdsc;
		internal Label label1;
		private Panel panel3;
		private SteepValley.Windows.Forms.XPGradientPanel xpGradientPanel1;
		private Label label2;
		private Label lbname;
		private Label label3;

		private Button button1;
		private LinkLabel llrem;
		private Ambertation.Windows.Forms.EnumComboBox cbrel;
		private CheckBox cbkeep;
		private ToolStripMenuItem miOpenSdesc;
		private SteepValley.Windows.Forms.XPLine xpLine1;
		internal CheckBox cbLock;
		private Label labelnid;
		private Label labelidd;
		Image thumb;

		internal void pool_SelectedSimChanged(
			object sender,
			Image thumb,
			SDesc sdesc
		)
		{
			if (cbLock.Checked)
			{
				return;
			}

			thumb = null;
			lastsdsc = null;
			currentsdsc = sdesc;
			ties.UpdateGraph(sdesc, wrapper);
		}

		private void miAddTie_BeforePopup(object sender, EventArgs e)
		{
			miAddTie.Enabled =
				lastsdsc != null && currentsdsc != null && currentsdsc != lastsdsc
			;
			miOpenSdesc.Enabled = lastsdsc != null;
			miAddTie.Image = thumb;
			//this.miOpenSdesc.Image = thumb;
			if (thumb != null)
			{
				miAddTie.Image = Ambertation.Drawing.GraphicRoutines.ScaleImage(
					thumb,
					32,
					32,
					true
				);
			}

			if (lastsdsc != null && currentsdsc != null)
			{
				string name = Localization.GetString("AddFamilyTieCaption");
				name = name.Replace(
					"{name}",
					lastsdsc.SimName + " " + lastsdsc.SimFamilyName
				);
				name = name.Replace(
					"{gname}",
					currentsdsc.SimName + " " + currentsdsc.SimFamilyName
				);
				miAddTie.Text = name;

				FamilyTieSim fts =
					wrapper.FindTies(currentsdsc);
				if (fts != null)
				{
					if (fts.FindTie(lastsdsc) != null)
					{
						miAddTie.Enabled = false;
					}
				}
			}

			if (lastsdsc != null)
			{
				string name = Localization.GetString("OpenSDesc");
				name = name.Replace(
					"{name}",
					lastsdsc.SimName + " " + lastsdsc.SimFamilyName
				);
				miOpenSdesc.Text = name;
			}
		}

		private void pool_ClickOverSim(
			object sender,
			Image thumb,
			SDesc sdesc
		)
		{
			lastsdsc = sdesc;
			this.thumb = thumb;
		}

		private void Activate_miAddTie(object sender, EventArgs e)
		{
			FamilyTieSim fts = wrapper.CreateTie(
				currentsdsc
			);
			FamilyTieItem fti = fts.CreateTie(
				lastsdsc,
				Data.MetaData.FamilyTieTypes.MySiblingIs
			);

			ties.AddTieToGraph(lastsdsc, 0, 0, fti.Type);

			if (cbkeep.Checked)
			{
				fts = wrapper.CreateTie(lastsdsc);
				fti = fts.CreateTie(
					currentsdsc,
					Data.MetaData.FamilyTieTypes.MySiblingIs
				);
			}
			wrapper.Changed = true;
		}

		private void ties_SelectedSimChanged(
			object sender,
			Image thumb,
			SDesc sdesc
		)
		{
			if (sdesc != null)
			{
				cbrel.Tag = null;
				lbname.Text = sdesc.SimName + " " + sdesc.SimFamilyName;
				labelidd.Text = "0x" + Helper.HexString(sdesc.Instance);
				cbrel.Enabled = sdesc != currentsdsc;
				if (cbrel.Enabled)
				{
					FamilyTieSim fts =
						wrapper.FindTies(currentsdsc);
					FamilyTieItem fti =
						fts.FindTie(sdesc);
					cbrel.SelectedValue = fti.Type;
					cbrel.Tag = fti;
				}
			}
			else
			{
				cbrel.Enabled = ties.SelectedElement != null;
				if (!cbrel.Enabled)
				{
					lbname.Text = "";
					labelidd.Text = "";
					cbrel.Tag = null;
				}
			}

			llrem.Enabled = cbrel.Enabled;
		}

		private void ties_DoubleClickSim(
			object sender,
			Image thumb,
			SDesc sdesc
		)
		{
			if (sdesc != null && sdesc != currentsdsc)
			{
				//Ambertation.Windows.Forms.Graph.ImagePanel ip = pool.FindItem(sdesc);
				pool.SelectedElement = sdesc;
			}
		}

		private void cbrel_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbrel.Tag != null)
			{
				FamilyTieItem fti =
					(FamilyTieItem)cbrel.Tag;
				Ambertation.Windows.Forms.Graph.ImagePanel ip =
					(Ambertation.Windows.Forms.Graph.ImagePanel)ties.SelectedElement;
				fti.Type = (Data.MetaData.FamilyTieTypes)cbrel.SelectedValue;
				wrapper.Changed = true;

				Ambertation.Windows.Forms.Graph.LinkGraphic lg =
					ties.MainSimElement.GetChildLink(ip);
				if (lg != null)
				{
					lg.Text = cbrel.Text;
				}

				if (cbkeep.Checked)
				{
					FamilyTieSim fts =
						wrapper.CreateTie(fti.SimDescription);
					fti = fts.CreateTie(
						currentsdsc,
						FamilyTieGraph.GetAntiTie(currentsdsc, fti.Type)
					);
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			wrapper.SynchronizeUserData();
		}

		private void llrem_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (cbrel.Tag != null)
			{
				FamilyTieSim fts =
					wrapper.FindTies(currentsdsc);
				FamilyTieItem fti =
					(FamilyTieItem)cbrel.Tag;

				if (fts.RemoveTie(fti))
				{
					Ambertation.Windows.Forms.Graph.ImagePanel ip =
						(Ambertation.Windows.Forms.Graph.ImagePanel)
							ties.SelectedElement;
					ip.Parent = null;
					ip.Dispose();
					wrapper.Changed = true;
				}
			}
		}

		private void Activate_miOpenSDesc(object sender, EventArgs e)
		{
			if (lastsdsc != null)
			{
				RemoteControl.OpenPackedFile(
					lastsdsc.FileDescriptor,
					lastsdsc.Package
				);
			}
		}
	}
}
