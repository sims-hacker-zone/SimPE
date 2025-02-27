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
				tabControl1.Controls.Remove(tabPage3);
				tabControl1.LayoutSystem = new TD.SandDock.SplitLayoutSystem(
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
								tabPage1,
								tabPage2,
							},
							tabPage1
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
			tabControl1 = new TD.SandDock.TabControl();
			tabPage1 = new TD.SandDock.TabPage();
			lv = new NgbhItemsListView();
			tabPage2 = new TD.SandDock.TabPage();
			lvint = new NgbhItemsListView();
			tabPage3 = new TD.SandDock.TabPage();
			lvfam = new NgbhItemsListView();
			splitter1 = new Splitter();
			memprop = new MemoryProperties();
			tabControl1.SuspendLayout();
			tabPage1.SuspendLayout();
			tabPage2.SuspendLayout();
			tabPage3.SuspendLayout();
			SuspendLayout();
			//
			// tabControl1
			//
			tabControl1.BorderStyle = TD.SandDock.Rendering.BorderStyle.None;
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage2);
			tabControl1.Controls.Add(tabPage3);
			tabControl1.Dock = DockStyle.Fill;
			tabControl1.LayoutSystem = new TD.SandDock.SplitLayoutSystem(
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
							tabPage1,
							tabPage2,
							tabPage3,
						},
						tabPage1
					),
				}
			);
			tabControl1.Location = new Point(0, 0);
			tabControl1.Name = "tabControl1";
			tabControl1.Size = new Size(504, 165);
			tabControl1.TabIndex = 3;
			//
			// tabPage1
			//
			tabPage1.BackColor = Color.Transparent;
			tabPage1.Controls.Add(lv);
			tabPage1.FloatingSize = new Size(550, 400);
			tabPage1.Guid = new System.Guid(
				"951f2dbf-63ee-4eb5-8342-1e80d72570b8"
			);
			tabPage1.Location = new Point(2, 22);
			tabPage1.Name = "tabPage1";
			tabPage1.Size = new Size(500, 141);
			tabPage1.TabIndex = 0;
			tabPage1.TabText = "Memories";
			tabPage1.Text = "Memories";
			//
			// lv
			//
			lv.BackColor = Color.Transparent;
			lv.Dock = DockStyle.Fill;
			lv.Font = new Font("Tahoma", 8.25F);
			lv.Location = new Point(0, 0);
			lv.Name = "lv";
			lv.NgbhItems = null;
			lv.Size = new Size(500, 141);
			lv.Slot = null;
			lv.ShowGossip = true;
			lv.SlotType = Data.NeighborhoodSlots.Sims;
			lv.TabIndex = 0;
			//
			// tabPage2
			//
			tabPage2.BackColor = Color.Transparent;
			tabPage2.Controls.Add(lvint);
			tabPage2.FloatingSize = new Size(550, 400);
			tabPage2.Guid = new System.Guid(
				"88419e31-43c9-4409-8d97-7ef80e549ee5"
			);
			tabPage2.Location = new Point(2, 22);
			tabPage2.Name = "tabPage2";
			tabPage2.Size = new Size(500, 117);
			tabPage2.TabIndex = 1;
			tabPage2.TabText = "Tokens (Skills, Badges...)";
			tabPage2.Text = "Tokens (Skills, Badges...)";
			tabPage2.Visible = false;
			tabPage2.VisibleChanged += new System.EventHandler(
				tabPage2_VisibleChanged
			);
			//
			// lvint
			//
			lvint.Dock = DockStyle.Fill;
			lvint.Font = new Font("Tahoma", 8.25F);
			lvint.Location = new Point(0, 0);
			lvint.Name = "lvint";
			lvint.NgbhItems = null;
			lvint.Size = new Size(500, 117);
			lvint.Slot = null;
			lvint.SlotType = Data.NeighborhoodSlots.Sims;
			lvint.TabIndex = 1;
			//
			// tabPage3
			//
			tabPage3.BackColor = Color.Transparent;
			tabPage3.Controls.Add(lvfam);
			tabPage3.FloatingSize = new Size(550, 400);
			tabPage3.Guid = new System.Guid(
				"88419e31-43c9-4409-8d97-7ef80e69b00b"
			);
			tabPage3.Location = new Point(2, 22);
			tabPage3.Name = "tabPage3";
			tabPage3.Size = new Size(500, 117);
			tabPage3.TabIndex = 1;
			tabPage3.TabText = "Family Inventory";
			tabPage3.Text = "Family Inventory";
			tabPage3.Visible = false;
			tabPage3.VisibleChanged += new System.EventHandler(
				tabPage2_VisibleChanged
			);
			//
			// lvfam
			//
			lvfam.Dock = DockStyle.Fill;
			lvfam.Font = new Font("Tahoma", 8.25F);
			lvfam.Location = new Point(0, 0);
			lvfam.Name = "lvfam";
			lvfam.NgbhItems = null;
			lvfam.Size = new Size(500, 117);
			lvfam.Slot = null;
			lvfam.SlotType = Data.NeighborhoodSlots.Families;
			lvfam.TabIndex = 2;
			//
			// splitter1
			//
			splitter1.BackColor = SystemColors.AppWorkspace;
			splitter1.Dock = DockStyle.Bottom;
			splitter1.Location = new Point(0, 165);
			splitter1.Name = "splitter1";
			splitter1.Size = new Size(504, 3);
			splitter1.TabIndex = 3;
			splitter1.TabStop = false;
			//
			// memprop
			//
			memprop.BackColor = Color.Transparent;
			memprop.Dock = DockStyle.Bottom;
			memprop.Font = new Font(
				"Tahoma",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				((System.Byte)(0))
			);
			memprop.Item = null;
			memprop.Location = new Point(0, 168);
			memprop.Name = "memprop";
			memprop.NgbhItemsListView = null;
			memprop.Size = new Size(504, 192);
			memprop.TabIndex = 4;
			//
			// NgbhSlotUI
			//
			Controls.Add(tabControl1);
			Controls.Add(splitter1);
			Controls.Add(memprop);
			Font = new Font(
				"Tahoma",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				((System.Byte)(0))
			);
			Name = "NgbhSlotUI";
			Size = new Size(504, 360);
			tabControl1.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage2.ResumeLayout(false);
			tabPage3.ResumeLayout(false);
			ResumeLayout(false);
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
					tabPage1.Text = Localization.GetString(
						"SimPe.Data.NeighborhoodSlots.Sims"
					);
					tabPage2.Text = Localization.GetString(
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
					tabPage1.Text = Localization.GetString(
						"SimPe.Data.NeighborhoodSlots.Families"
					);
					tabPage2.Text = Localization.GetString(
						"SimPe.Data.NeighborhoodSlots.FamiliesIntern"
					);

					lv.SlotType = Data.NeighborhoodSlots.Families;
					lvint.SlotType = Data.NeighborhoodSlots.FamiliesIntern;
				}
				else
				{
					tabPage1.Text = Localization.GetString(
						"SimPe.Data.NeighborhoodSlots.Lots"
					);
					tabPage2.Text = Localization.GetString(
						"SimPe.Data.NeighborhoodSlots.LotsIntern"
					);

					lv.SlotType = Data.NeighborhoodSlots.Lots;
					lvint.SlotType = Data.NeighborhoodSlots.LotsIntern;
				}
				tabPage1.TabText = tabPage1.Text;
				tabPage2.TabText = tabPage2.Text;

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
					Slut = ngbh.GetSlots(Data.NeighborhoodSlots.Families)
						.GetInstanceSlot(pc.SelectedSim.FamilyInstance);
					Slot = ngbh.GetSlots(st)
						.GetInstanceSlot(pc.SelectedSim.FileDescriptor.Instance);
				}
				else
				{
					Slut = null;
					Slot = null;
				}
			}
		}

		private void tabPage2_VisibleChanged(object sender, System.EventArgs e)
		{
			if (tabControl1.SelectedPage == tabPage1)
			{
				memprop.NgbhItemsListView = lv;
			}
			else if (tabControl1.SelectedPage == tabPage3)
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
