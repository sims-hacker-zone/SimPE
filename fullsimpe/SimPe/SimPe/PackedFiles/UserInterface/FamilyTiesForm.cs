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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using SimPe.PackedFiles.Wrapper;

namespace SimPe.PackedFiles.UserInterface
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
			ties.Parent = this.panel1;

			this.cbrel.Enum = typeof(Data.MetaData.FamilyTieTypes);
			this.cbrel.ResourceManager = Localization.Manager;
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
			this.components = new Container();
			ComponentResourceManager resources =
				new ComponentResourceManager(
					typeof(FamilyTiesForm)
				);
			this.pnfamt = new Panel();
			this.panel1 = new Panel();
			this.ties = new FamilyTieGraph();
			this.panel4 = new Panel();
			this.cbLock = new CheckBox();
			this.label1 = new Label();
			this.panel3 = new Panel();
			this.xpGradientPanel1 = new SteepValley.Windows.Forms.XPGradientPanel();
			this.xpLine1 = new SteepValley.Windows.Forms.XPLine();
			this.button1 = new Button();
			this.cbkeep = new CheckBox();
			this.cbrel = new Ambertation.Windows.Forms.EnumComboBox();
			this.llrem = new LinkLabel();
			this.label3 = new Label();
			this.lbname = new Label();
			this.label2 = new Label();
			this.panel2 = new Panel();
			this.pool = new SimPoolControl();
			this.miTies = new ContextMenuStrip(this.components);
			this.miAddTie = new ToolStripMenuItem();
			this.miOpenSdesc = new ToolStripMenuItem();
			this.label12 = new Label();
			this.pnfamt.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.xpGradientPanel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.miTies.SuspendLayout();
			this.SuspendLayout();
			//
			// pnfamt
			//
			this.pnfamt.BackColor = System.Drawing.SystemColors.Control;
			this.pnfamt.BackgroundImage = null;
			this.pnfamt.Controls.Add(this.panel1);
			this.pnfamt.Controls.Add(this.panel4);
			this.pnfamt.Controls.Add(this.panel3);
			this.pnfamt.Controls.Add(this.panel2);
			resources.ApplyResources(this.pnfamt, "pnfamt");
			this.pnfamt.Name = "pnfamt";
			//
			// panel1
			//
			resources.ApplyResources(this.panel1, "panel1");
			this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.panel1.Controls.Add(this.ties);
			this.panel1.Name = "panel1";
			//
			// ties
			//
			resources.ApplyResources(this.ties, "ties");
			this.ties.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.ties.LineMode = Ambertation
				.Windows
				.Forms
				.Graph
				.LinkControlLineMode
				.Bezier;
			this.ties.LockItems = false;
			this.ties.MinHeight = 344;
			this.ties.MinWidth = 720;
			this.ties.Name = "ties";
			this.ties.Quality = true;
			this.ties.SaveBounds = true;
			this.ties.SelectedElement = null;
			this.ties.SelectedSimChanged +=
				new SimPoolControl.SelectedSimHandler(
					this.ties_SelectedSimChanged
				);
			this.ties.DoubleClickSim +=
				new SimPoolControl.SelectedSimHandler(
					this.ties_DoubleClickSim
				);
			//
			// panel3
			//
			this.panel4.AccessibleDescription = null;
			this.panel4.AccessibleName = null;
			resources.ApplyResources(this.panel4, "panel4");
			this.panel4.BackColor = System.Drawing.Color.FromArgb(
				((int)(((byte)(120)))),
				((int)(((byte)(0)))),
				((int)(((byte)(0)))),
				((int)(((byte)(0))))
			);
			this.panel4.BackgroundImage = null;
			this.panel4.Controls.Add(this.cbLock);
			this.panel4.Controls.Add(this.label1);
			this.panel4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.panel4.Name = "panel4";
			//
			// cbLock
			//
			resources.ApplyResources(this.cbLock, "cbLock");
			this.cbLock.BackColor = System.Drawing.Color.Transparent;
			this.cbLock.Name = "cbLock";
			this.cbLock.UseVisualStyleBackColor = false;
			//
			// label1
			//
			this.label1.AccessibleDescription = null;
			this.label1.AccessibleName = null;
			resources.ApplyResources(this.label1, "label1");
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = null;
			this.label1.Name = "label1";
			//
			// panel3
			//
			this.panel3.AccessibleDescription = null;
			this.panel3.AccessibleName = null;
			resources.ApplyResources(this.panel3, "panel3");
			this.panel3.BackgroundImage = null;
			this.panel3.Controls.Add(this.xpGradientPanel1);
			this.panel3.Font = null;
			this.panel3.Name = "panel3";
			//
			// xpGradientPanel1
			//
			this.xpGradientPanel1.AccessibleDescription = null;
			this.xpGradientPanel1.AccessibleName = null;
			resources.ApplyResources(this.xpGradientPanel1, "xpGradientPanel1");
			this.xpGradientPanel1.BackgroundImage = null;
			this.xpGradientPanel1.Controls.Add(this.xpLine1);
			this.xpGradientPanel1.Controls.Add(this.button1);
			this.xpGradientPanel1.Controls.Add(this.cbkeep);
			this.xpGradientPanel1.Controls.Add(this.cbrel);
			this.xpGradientPanel1.Controls.Add(this.llrem);
			this.xpGradientPanel1.Controls.Add(this.label3);
			this.xpGradientPanel1.Controls.Add(this.lbname);
			this.xpGradientPanel1.Controls.Add(this.label2);
			this.xpGradientPanel1.Font = null;
			this.xpGradientPanel1.Name = "xpGradientPanel1";
			this.xpGradientPanel1.Watermark = null;
			//
			// xpLine1
			//
			resources.ApplyResources(this.xpLine1, "xpLine1");
			this.xpLine1.BackColor = System.Drawing.Color.Transparent;
			this.xpLine1.BackgroundImage = null;
			this.xpLine1.Font = null;
			this.xpLine1.ForeColor = System.Drawing.Color.Transparent;
			this.xpLine1.LineColor = System.Drawing.Color.FromArgb(
				((int)(((byte)(125)))),
				((int)(((byte)(0)))),
				((int)(((byte)(0)))),
				((int)(((byte)(0))))
			);
			this.xpLine1.Name = "xpLine1";
			this.xpLine1.Orientation = System
				.Drawing
				.Drawing2D
				.LinearGradientMode
				.Vertical;
			//
			// button1
			//
			this.button1.AccessibleDescription = null;
			this.button1.AccessibleName = null;
			resources.ApplyResources(this.button1, "button1");
			this.button1.BackgroundImage = null;
			this.button1.Name = "button1";
			this.button1.Click += new EventHandler(this.button1_Click);
			//
			// cbkeep
			//
			resources.ApplyResources(this.cbkeep, "cbkeep");
			this.cbkeep.BackColor = System.Drawing.Color.Transparent;
			this.cbkeep.Checked = true;
			this.cbkeep.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbkeep.Name = "cbkeep";
			this.cbkeep.UseVisualStyleBackColor = false;
			//
			// cbrel
			//
			this.cbrel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbrel.Enum = null;
			resources.ApplyResources(this.cbrel, "cbrel");
			this.cbrel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cbrel.Name = "cbrel";
			this.cbrel.ResourceManager = null;
			this.cbrel.SelectedIndexChanged += new EventHandler(
				this.cbrel_SelectedIndexChanged
			);
			//
			// llrem
			//
			this.llrem.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.llrem, "llrem");
			this.llrem.Name = "llrem";
			this.llrem.TabStop = true;
			this.llrem.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					this.llrem_LinkClicked
				);
			//
			// label3
			//
			this.label3.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			//
			// lbname
			//
			resources.ApplyResources(this.lbname, "lbname");
			this.lbname.BackColor = System.Drawing.Color.Transparent;
			this.lbname.Name = "lbname";
			//
			// label2
			//
			this.label2.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			//
			// panel2
			//
			this.panel2.BackColor = System.Drawing.SystemColors.Info;
			this.panel2.Controls.Add(this.pool);
			resources.ApplyResources(this.panel2, "panel2");
			this.panel2.Name = "panel2";
			//
			// pool
			//
			this.pool.ContextMenuStrip = this.miTies;
			resources.ApplyResources(this.pool, "pool");
			this.pool.Name = "pool";
			this.pool.Package = null;
			this.pool.RightClickSelect = false;
			this.pool.SelectedElement = null;
			this.pool.SelectedSim = null;
			this.pool.SimDetails = false;
			this.pool.TileColumns = new int[] { 1 };
			this.pool.ClickOverSim +=
				new SimPoolControl.SelectedSimHandler(
					this.pool_ClickOverSim
				);
			this.pool.SelectedSimChanged +=
				new SimPoolControl.SelectedSimHandler(
					this.pool_SelectedSimChanged
				);
			//
			// miTies
			//
			this.miTies.Items.AddRange(
				new ToolStripItem[]
				{
					this.miAddTie,
					this.miOpenSdesc,
				}
			);
			this.miTies.Name = "miTies";
			resources.ApplyResources(this.miTies, "miTies");
			this.miTies.VisibleChanged += new EventHandler(
				this.miAddTie_BeforePopup
			);
			//
			// miAddTie
			//
			this.miAddTie.Name = "miAddTie";
			resources.ApplyResources(this.miAddTie, "miAddTie");
			this.miAddTie.Tag = "\"{name}\" in die Familie von \"{gname}\" aufnehmen";
			this.miAddTie.Click += new EventHandler(this.Activate_miAddTie);
			//
			// miOpenSdesc
			//
			resources.ApplyResources(this.miOpenSdesc, "miOpenSdesc");
			this.miOpenSdesc.Name = "miOpenSdesc";
			this.miOpenSdesc.Click += new EventHandler(
				this.Activate_miOpenSDesc
			);
			//
			// label12
			//
			resources.ApplyResources(this.label12, "label12");
			this.label12.Name = "label12";
			//
			// FamilyTiesForm
			//
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.pnfamt);
			this.Name = "FamilyTiesForm";
			this.pnfamt.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.miTies.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion

		internal Panel pnfamt;
		private Panel panel2;
		private Panel panel4;
		internal Label label12;
		internal SimPoolControl pool;
		private Panel panel1;
		internal FamilyTieGraph ties;

		internal Wrapper.ExtFamilyTies wrapper;
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
			this.miAddTie.Enabled = (
				lastsdsc != null && currentsdsc != null && currentsdsc != lastsdsc
			);
			this.miOpenSdesc.Enabled = (lastsdsc != null);
			this.miAddTie.Image = thumb;
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
				string name = SimPe.Localization.GetString("AddFamilyTieCaption");
				name = name.Replace(
					"{name}",
					lastsdsc.SimName + " " + lastsdsc.SimFamilyName
				);
				name = name.Replace(
					"{gname}",
					currentsdsc.SimName + " " + currentsdsc.SimFamilyName
				);
				this.miAddTie.Text = name;

				Wrapper.Supporting.FamilyTieSim fts =
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
				string name = SimPe.Localization.GetString("OpenSDesc");
				name = name.Replace(
					"{name}",
					lastsdsc.SimName + " " + lastsdsc.SimFamilyName
				);
				this.miOpenSdesc.Text = name;
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
			Wrapper.Supporting.FamilyTieSim fts = wrapper.CreateTie(
				currentsdsc
			);
			Wrapper.Supporting.FamilyTieItem fti = fts.CreateTie(
				lastsdsc,
				Data.MetaData.FamilyTieTypes.MySiblingIs
			);

			ties.AddTieToGraph(lastsdsc, 0, 0, fti.Type);

			if (this.cbkeep.Checked)
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
				this.lbname.Text = sdesc.SimName + " " + sdesc.SimFamilyName;
				this.labelidd.Text = "0x" + Helper.HexString(sdesc.Instance);
				cbrel.Enabled = (sdesc != currentsdsc);
				if (cbrel.Enabled)
				{
					Wrapper.Supporting.FamilyTieSim fts =
						wrapper.FindTies(currentsdsc);
					Wrapper.Supporting.FamilyTieItem fti =
						fts.FindTie(sdesc);
					cbrel.SelectedValue = fti.Type;
					cbrel.Tag = fti;
				}
			}
			else
			{
				cbrel.Enabled = (ties.SelectedElement != null);
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
				Wrapper.Supporting.FamilyTieItem fti =
					(Wrapper.Supporting.FamilyTieItem)cbrel.Tag;
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

				if (this.cbkeep.Checked)
				{
					Wrapper.Supporting.FamilyTieSim fts =
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
				Wrapper.Supporting.FamilyTieSim fts =
					wrapper.FindTies(currentsdsc);
				Wrapper.Supporting.FamilyTieItem fti =
					(Wrapper.Supporting.FamilyTieItem)cbrel.Tag;

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
				SimPe.RemoteControl.OpenPackedFile(
					lastsdsc.FileDescriptor,
					lastsdsc.Package
				);
			}
		}
	}
}
