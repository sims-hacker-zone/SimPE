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
using System.Drawing;
using System.Windows.Forms;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for SlotUI.
	/// </summary>
	public class NgbhSlotUI : UserControl
	{
		private TD.SandDock.TabControl tabControl1;
		private TD.SandDock.TabPage tabPage1;
		private TD.SandDock.TabPage tabPage2;
		internal TD.SandDock.TabPage tabPage3;
		private NgbhItemsListView lv;
		private NgbhItemsListView lvint;
		private NgbhItemsListView lvfam;
		private Splitter splitter1;
		private MemoryProperties memprop;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NgbhSlotUI()
		{
			SetStyle(
				ControlStyles.SupportsTransparentBackColor
					| ControlStyles.AllPaintingInWmPaint
					|
					//ControlStyles.Opaque |
					ControlStyles.UserPaint
					| ControlStyles.ResizeRedraw
					| ControlStyles.DoubleBuffer,
				true
			);

			// Required designer variable.
			InitializeComponent();

			SlotType = Data.NeighborhoodSlots.Sims;
			tabPage2_VisibleChanged(null, null);

			if (Helper.WindowsRegistry.HiddenMode)
			{
				this.tabControl1.Controls.Remove(this.tabPage3);
				this.tabControl1.LayoutSystem = new TD.SandDock.SplitLayoutSystem(
					250,
					400,
					Orientation.Horizontal,
					new TD.SandDock.LayoutSystemBase[]
					{
						new TD.SandDock.DocumentLayoutSystem(
							504,
							165,
							new TD.SandDock.DockControl[]
							{
								this.tabPage1,
								this.tabPage2,
							},
							this.tabPage1
						),
					}
				);
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
			this.tabControl1 = new TD.SandDock.TabControl();
			this.tabPage1 = new TD.SandDock.TabPage();
			this.lv = new NgbhItemsListView();
			this.tabPage2 = new TD.SandDock.TabPage();
			this.lvint = new NgbhItemsListView();
			this.tabPage3 = new TD.SandDock.TabPage();
			this.lvfam = new NgbhItemsListView();
			this.splitter1 = new Splitter();
			this.memprop = new MemoryProperties();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			//
			// tabControl1
			//
			this.tabControl1.BorderStyle = TD.SandDock.Rendering.BorderStyle.None;
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Dock = DockStyle.Fill;
			this.tabControl1.LayoutSystem = new TD.SandDock.SplitLayoutSystem(
				250,
				400,
				Orientation.Horizontal,
				new TD.SandDock.LayoutSystemBase[]
				{
					new TD.SandDock.DocumentLayoutSystem(
						504,
						165,
						new TD.SandDock.DockControl[]
						{
							this.tabPage1,
							this.tabPage2,
							this.tabPage3,
						},
						this.tabPage1
					),
				}
			);
			this.tabControl1.Location = new Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.Size = new Size(504, 165);
			this.tabControl1.TabIndex = 3;
			//
			// tabPage1
			//
			this.tabPage1.BackColor = Color.Transparent;
			this.tabPage1.Controls.Add(this.lv);
			this.tabPage1.FloatingSize = new Size(550, 400);
			this.tabPage1.Guid = new System.Guid(
				"951f2dbf-63ee-4eb5-8342-1e80d72570b8"
			);
			this.tabPage1.Location = new Point(2, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new Size(500, 141);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.TabText = "Memories";
			this.tabPage1.Text = "Memories";
			//
			// lv
			//
			this.lv.BackColor = Color.Transparent;
			this.lv.Dock = DockStyle.Fill;
			this.lv.Font = new Font("Tahoma", 8.25F);
			this.lv.Location = new Point(0, 0);
			this.lv.Name = "lv";
			this.lv.NgbhItems = null;
			this.lv.Size = new Size(500, 141);
			this.lv.Slot = null;
			this.lv.ShowGossip = true;
			this.lv.SlotType = Data.NeighborhoodSlots.Sims;
			this.lv.TabIndex = 0;
			//
			// tabPage2
			//
			this.tabPage2.BackColor = Color.Transparent;
			this.tabPage2.Controls.Add(this.lvint);
			this.tabPage2.FloatingSize = new Size(550, 400);
			this.tabPage2.Guid = new System.Guid(
				"88419e31-43c9-4409-8d97-7ef80e549ee5"
			);
			this.tabPage2.Location = new Point(2, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new Size(500, 117);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.TabText = "Tokens (Skills, Badges...)";
			this.tabPage2.Text = "Tokens (Skills, Badges...)";
			this.tabPage2.Visible = false;
			this.tabPage2.VisibleChanged += new System.EventHandler(
				this.tabPage2_VisibleChanged
			);
			//
			// lvint
			//
			this.lvint.Dock = DockStyle.Fill;
			this.lvint.Font = new Font("Tahoma", 8.25F);
			this.lvint.Location = new Point(0, 0);
			this.lvint.Name = "lvint";
			this.lvint.NgbhItems = null;
			this.lvint.Size = new Size(500, 117);
			this.lvint.Slot = null;
			this.lvint.SlotType = Data.NeighborhoodSlots.Sims;
			this.lvint.TabIndex = 1;
			//
			// tabPage3
			//
			this.tabPage3.BackColor = Color.Transparent;
			this.tabPage3.Controls.Add(this.lvfam);
			this.tabPage3.FloatingSize = new Size(550, 400);
			this.tabPage3.Guid = new System.Guid(
				"88419e31-43c9-4409-8d97-7ef80e69b00b"
			);
			this.tabPage3.Location = new Point(2, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new Size(500, 117);
			this.tabPage3.TabIndex = 1;
			this.tabPage3.TabText = "Family Inventory";
			this.tabPage3.Text = "Family Inventory";
			this.tabPage3.Visible = false;
			this.tabPage3.VisibleChanged += new System.EventHandler(
				this.tabPage2_VisibleChanged
			);
			//
			// lvfam
			//
			this.lvfam.Dock = DockStyle.Fill;
			this.lvfam.Font = new Font("Tahoma", 8.25F);
			this.lvfam.Location = new Point(0, 0);
			this.lvfam.Name = "lvfam";
			this.lvfam.NgbhItems = null;
			this.lvfam.Size = new Size(500, 117);
			this.lvfam.Slot = null;
			this.lvfam.SlotType = Data.NeighborhoodSlots.Families;
			this.lvfam.TabIndex = 2;
			//
			// splitter1
			//
			this.splitter1.BackColor = SystemColors.AppWorkspace;
			this.splitter1.Dock = DockStyle.Bottom;
			this.splitter1.Location = new Point(0, 165);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new Size(504, 3);
			this.splitter1.TabIndex = 3;
			this.splitter1.TabStop = false;
			//
			// memprop
			//
			this.memprop.BackColor = Color.Transparent;
			this.memprop.Dock = DockStyle.Bottom;
			this.memprop.Font = new Font(
				"Tahoma",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.memprop.Item = null;
			this.memprop.Location = new Point(0, 168);
			this.memprop.Name = "memprop";
			this.memprop.NgbhItemsListView = null;
			this.memprop.Size = new Size(504, 192);
			this.memprop.TabIndex = 4;
			//
			// NgbhSlotUI
			//
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.memprop);
			this.Font = new Font(
				"Tahoma",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.Name = "NgbhSlotUI";
			this.Size = new Size(504, 360);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion

		#region Properties
		Data.NeighborhoodSlots st;
		public Data.NeighborhoodSlots SlotType
		{
			get
			{
				return st;
			}
			set
			{
				st = value;
				lv.NgbhItems = null;
				lvint.NgbhItems = null;
				lvfam.NgbhItems = null;
				lvfam.SlotType = Data.NeighborhoodSlots.Families;
				if (
					st == Data.NeighborhoodSlots.Sims
					|| st == Data.NeighborhoodSlots.SimsIntern
				)
				{
					this.tabPage1.Text = Localization.GetString(
						"SimPe.Data.NeighborhoodSlots.Sims"
					);
					this.tabPage2.Text = Localization.GetString(
						"SimPe.Data.NeighborhoodSlots.SimsIntern"
					);

					lv.SlotType = Data.NeighborhoodSlots.Sims;
					lvint.SlotType = Data.NeighborhoodSlots.SimsIntern;
				}
				else if (
					st == Data.NeighborhoodSlots.Families
					|| st == Data.NeighborhoodSlots.FamiliesIntern
				)
				{
					this.tabPage1.Text = Localization.GetString(
						"SimPe.Data.NeighborhoodSlots.Families"
					);
					this.tabPage2.Text = Localization.GetString(
						"SimPe.Data.NeighborhoodSlots.FamiliesIntern"
					);

					lv.SlotType = Data.NeighborhoodSlots.Families;
					lvint.SlotType = Data.NeighborhoodSlots.FamiliesIntern;
				}
				else
				{
					this.tabPage1.Text = Localization.GetString(
						"SimPe.Data.NeighborhoodSlots.Lots"
					);
					this.tabPage2.Text = Localization.GetString(
						"SimPe.Data.NeighborhoodSlots.LotsIntern"
					);

					lv.SlotType = Data.NeighborhoodSlots.Lots;
					lvint.SlotType = Data.NeighborhoodSlots.LotsIntern;
				}
				this.tabPage1.TabText = this.tabPage1.Text;
				this.tabPage2.TabText = this.tabPage2.Text;

				SetContent();
			}
		}

		NgbhSlot slot;
		NgbhSlot Slut;

		[System.ComponentModel.Browsable(false)]
		public NgbhSlot Slot
		{
			get
			{
				return slot;
			}
			set
			{
				slot = value;
				SetContent();
			}
		}

		Ngbh ngbh;

		[System.ComponentModel.Browsable(false)]
		public Ngbh NgbhResource
		{
			get
			{
				return ngbh;
			}
			set
			{
				ngbh = value;
				SetContent();
				pc_SelectedSimChanged(pc, null, null);
			}
		}

		PackedFiles.Wrapper.SimPoolControl pc;
		public PackedFiles.Wrapper.SimPoolControl SimPoolControl
		{
			get
			{
				return pc;
			}
			set
			{
				if (pc != null)
				{
					pc.SelectedSimChanged -=
						new PackedFiles.Wrapper.SimPoolControl.SelectedSimHandler(
							pc_SelectedSimChanged
						);
				}

				pc = value;
				if (pc != null)
				{
					pc.SelectedSimChanged +=
						new PackedFiles.Wrapper.SimPoolControl.SelectedSimHandler(
							pc_SelectedSimChanged
						);
					pc_SelectedSimChanged(pc, null, null);
				}
			}
		}

		#endregion

		void SetContent()
		{
			lv.Slot = slot;
			lvint.Slot = slot;
			lvfam.Slot = Slut;
		}

		public new void Refresh()
		{
			lv.Refresh();
			lvint.Refresh();
			lvfam.Refresh();
			base.Refresh();
		}

		private void pc_SelectedSimChanged(
			object sender,
			Image thumb,
			PackedFiles.Wrapper.SDesc sdesc
		)
		{
			if (ngbh != null && pc != null)
			{
				if (pc.SelectedSim != null)
				{
					this.Slut = ngbh.GetSlots(Data.NeighborhoodSlots.Families)
						.GetInstanceSlot(pc.SelectedSim.FamilyInstance);
					this.Slot = ngbh.GetSlots(st)
						.GetInstanceSlot(pc.SelectedSim.FileDescriptor.Instance);
				}
				else
				{
					this.Slut = null;
					this.Slot = null;
				}
			}
		}

		private void tabPage2_VisibleChanged(object sender, System.EventArgs e)
		{
			if (tabControl1.SelectedPage == this.tabPage1)
			{
				memprop.NgbhItemsListView = lv;
			}
			else if (tabControl1.SelectedPage == this.tabPage3)
			{
				memprop.NgbhItemsListView = lvfam;
			}
			else
			{
				memprop.NgbhItemsListView = lvint;
			}
		}
	}
}
