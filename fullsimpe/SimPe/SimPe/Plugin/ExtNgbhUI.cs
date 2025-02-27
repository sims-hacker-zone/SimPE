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
using System.Windows.Forms;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for ExtNgbhUI.
	/// </summary>
	public class ExtNgbhUI
		:
		//System.Windows.Forms.UserControl
		Windows.Forms.WrapperBaseControl,
			Interfaces.Plugin.IPackedFileUI
	{
		private IContainer components;
		private Panel pnSims;
		PackedFiles.Wrapper.SimPoolControl spc = null;
		private Panel pnDebug;
		private NgbhSlotSelection nssel;
		private NgbhSlotUI nsui;
		private ToolStrip toolBar1;
		private Panel pnBadge;
		private ToolStripButton biSim;
		private ToolStripButton biBadge;
		private ToolStripButton biDebug;
		private NgbhSkillHelper shelper;
		private MenuStrip menuBar1;
		private ContextMenuStrip menu;
		private ToolStripMenuItem miNuke;
		private ToolStripMenuItem miFix;
		NgbhSlotUI simslot = null;

		public ExtNgbhUI()
		{
			InitializeComponent();

			biSim.Tag = pnSims;
			biDebug.Tag = pnDebug;
			biBadge.Tag = pnBadge;

			biDebug.Visible = Helper.WindowsRegistry.HiddenMode;
			if (!Helper.WindowsRegistry.HiddenMode)
			{
				menu.Items.Remove(miFix);
			}

			SelectButton(biSim);

			biBadge.Enabled = (
				PathProvider.Global.EPInstalled >= 3
				|| PathProvider.Global.STInstalled >= 28
			);

			RemoteControl.HookToMessageQueue(
				0x4E474248,
				new RemoteControl.ControlEvent(ControlEvent)
			);
		}

		protected void ControlEvent(
			object sender,
			RemoteControl.ControlEventArgs e
		)
		{
			if (e.Items is object[] os)
			{
				Data.NeighborhoodSlots st = (Data.NeighborhoodSlots)os[1];
				uint inst = (uint)os[0];

				if (st == Data.NeighborhoodSlots.SimsIntern && biBadge.Enabled)
				{
					ChoosePage(biBadge, null);
				}
				else
				{
					ChoosePage(biSim, null);
				}

				PackedFiles.Wrapper.ExtSDesc sdesc =
					FileTableBase.ProviderRegistry.SimDescriptionProvider.FindSim(
						(ushort)inst
					) as PackedFiles.Wrapper.ExtSDesc;
				bool found = SelectSimByInstance(sdesc);

				if (!found && sdesc != null)
				{
					spc.SelectHousehold(sdesc.HouseholdName);
					SelectSimByInstance(sdesc);
				}

				spc.Refresh(false);
			}
		}

		protected bool SelectSimByInstance(PackedFiles.Wrapper.SDesc sdesc)
		{
			bool ret = false;
			if (sdesc != null)
			{
				spc.SelectedElement = sdesc;
				if (spc.SelectedElement != null)
				{
					return true;
				}
			}

			return ret;
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
				new ComponentResourceManager(typeof(ExtNgbhUI));
			pnSims = new Panel();
			menuBar1 = new MenuStrip();
			spc = new PackedFiles.Wrapper.SimPoolControl();
			menu = new ContextMenuStrip(components);
			miNuke = new ToolStripMenuItem();
			miFix = new ToolStripMenuItem();
			simslot = new NgbhSlotUI();
			pnDebug = new Panel();
			nsui = new NgbhSlotUI();
			nssel = new NgbhSlotSelection();
			pnBadge = new Panel();
			shelper = new NgbhSkillHelper();
			toolBar1 = new ToolStrip();
			biSim = new ToolStripButton();
			biBadge = new ToolStripButton();
			biDebug = new ToolStripButton();
			pnSims.SuspendLayout();
			menu.SuspendLayout();
			pnDebug.SuspendLayout();
			pnBadge.SuspendLayout();
			toolBar1.SuspendLayout();
			SuspendLayout();
			//
			// pnSims
			//
			pnSims.BackColor = System.Drawing.Color.Transparent;
			pnSims.Controls.Add(menuBar1);
			pnSims.Controls.Add(spc);
			pnSims.Controls.Add(simslot);
			pnSims.Dock = DockStyle.Fill;
			pnSims.Location = new System.Drawing.Point(0, 76);
			pnSims.Name = "pnSims";
			pnSims.Size = new System.Drawing.Size(680, 292);
			pnSims.TabIndex = 1;
			pnSims.Visible = false;
			//
			// menuBar1
			//
			menuBar1.Location = new System.Drawing.Point(264, 0);
			menuBar1.Name = "menuBar1";
			menuBar1.Size = new System.Drawing.Size(416, 21);
			menuBar1.TabIndex = 5;
			menuBar1.Text = "menuBar1";
			menuBar1.Visible = false;
			//
			// spc
			//
			spc.BackColor = System.Drawing.Color.White;
			spc.ContextMenuStrip = menu;
			spc.Dock = DockStyle.Left;
			spc.Font = new System.Drawing.Font("Tahoma", 8.25F);
			spc.Location = new System.Drawing.Point(0, 0);
			spc.Name = "spc";
			spc.Package = null;
			spc.Padding = new Padding(1);
			spc.RightClickSelect = false;
			spc.SelectedElement = null;
			spc.SelectedSim = null;
			spc.SimDetails = false;
			spc.Size = new System.Drawing.Size(264, 292);
			spc.TabIndex = 0;
			spc.TileColumns = new int[] { 1 };
			spc.SelectedSimChanged +=
				new PackedFiles.Wrapper.SimPoolControl.SelectedSimHandler(
					spc_SelectedSimChanged
				);
			//
			// menu
			//
			menu.Items.AddRange(
				new ToolStripItem[] { miNuke, miFix }
			);
			menu.Name = "menu";
			menu.Size = new System.Drawing.Size(158, 48);
			menu.Text = "(context menu)";
			menu.VisibleChanged += new EventHandler(
				menu_VisibleChanged
			);
			//
			// miNuke
			//
			miNuke.Image = (
				(System.Drawing.Image)(resources.GetObject("miNuke.Image"))
			);
			miNuke.Name = "miNuke";
			miNuke.Size = new System.Drawing.Size(157, 22);
			miNuke.Text = "Nuke Memories";
			miNuke.Click += new EventHandler(miNuke_Activate);
			//
			// miFix
			//
			miFix.Image = (
				(System.Drawing.Image)(resources.GetObject("miFix.Image"))
			);
			miFix.Name = "miFix";
			miFix.Size = new System.Drawing.Size(157, 22);
			miFix.Text = "Fix Memories";
			miFix.Click += new EventHandler(miFix_Activate);
			//
			// simslot
			//
			simslot.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			simslot.Font = new System.Drawing.Font("Tahoma", 8.25F);
			simslot.Location = new System.Drawing.Point(264, 0);
			simslot.Name = "simslot";
			simslot.NgbhResource = null;
			simslot.SimPoolControl = spc;
			simslot.Size = new System.Drawing.Size(416, 290);
			simslot.Slot = null;
			simslot.SlotType = Data.NeighborhoodSlots.Sims;
			simslot.TabIndex = 2;
			//
			// pnDebug
			//
			pnDebug.Controls.Add(nsui);
			pnDebug.Controls.Add(nssel);
			pnDebug.Dock = DockStyle.Fill;
			pnDebug.Location = new System.Drawing.Point(0, 76);
			pnDebug.Name = "pnDebug";
			pnDebug.Size = new System.Drawing.Size(680, 292);
			pnDebug.TabIndex = 3;
			pnDebug.Visible = false;
			//
			// nsui
			//
			nsui.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			nsui.BackColor = System.Drawing.Color.Transparent;
			nsui.Font = new System.Drawing.Font("Tahoma", 8.25F);
			nsui.Location = new System.Drawing.Point(280, 8);
			nsui.Name = "nsui";
			nsui.NgbhResource = null;
			nsui.SimPoolControl = null;
			nsui.tabPage3.Enabled = false;
			nsui.Size = new System.Drawing.Size(392, 276);
			nsui.Slot = null;
			nsui.SlotType = Data.NeighborhoodSlots.Sims;
			nsui.TabIndex = 1;
			//
			// nssel
			//
			nssel.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Bottom
						) | AnchorStyles.Left
					)

			;
			nssel.Font = new System.Drawing.Font("Tahoma", 8.25F);
			nssel.Location = new System.Drawing.Point(8, 8);
			nssel.Name = "nssel";
			nssel.NgbhResource = null;
			nssel.Size = new System.Drawing.Size(264, 276);
			nssel.TabIndex = 0;
			nssel.SelectedSlotChanged += new EventHandler(
				nssel_SelectedSlotChanged
			);
			//
			// pnBadge
			//
			pnBadge.Controls.Add(shelper);
			pnBadge.Dock = DockStyle.Fill;
			pnBadge.Location = new System.Drawing.Point(0, 76);
			pnBadge.Name = "pnBadge";
			pnBadge.Size = new System.Drawing.Size(680, 292);
			pnBadge.TabIndex = 1;
			pnBadge.VisibleChanged += new EventHandler(
				pnBadge_VisibleChanged
			);
			//
			// shelper
			//
			shelper.BackColor = System.Drawing.Color.Transparent;
			shelper.Dock = DockStyle.Fill;
			shelper.Font = new System.Drawing.Font("Tahoma", 8.25F);
			shelper.Location = new System.Drawing.Point(0, 0);
			shelper.Name = "shelper";
			shelper.NgbhResource = null;
			shelper.Padding = new Padding(8);
			shelper.SimPoolControl = spc;
			shelper.Size = new System.Drawing.Size(680, 292);
			shelper.Slot = null;
			shelper.TabIndex = 0;
			shelper.ChangedItem += new EventHandler(
				shelper_ChangedItem
			);
			shelper.AddedNewItem += new EventHandler(
				shelper_AddedNewItem
			);
			//
			// toolBar1
			//
			toolBar1.Font = new System.Drawing.Font("Tahoma", 8.25F);
			toolBar1.GripStyle = ToolStripGripStyle.Hidden;
			toolBar1.Items.AddRange(
				new ToolStripItem[]
				{
					biSim,
					biBadge,
					biDebug,
				}
			);
			toolBar1.Location = new System.Drawing.Point(0, 24);
			toolBar1.Name = "toolBar1";
			toolBar1.Size = new System.Drawing.Size(680, 52);
			toolBar1.TabIndex = 4;
			toolBar1.Text = "toolBar1";
			//
			// biSim
			//
			biSim.Image = (
				(System.Drawing.Image)(resources.GetObject("biSim.Image"))
			);
			biSim.ImageScaling =
				ToolStripItemImageScaling
				.None;
			biSim.Name = "biSim";
			biSim.Size = new System.Drawing.Size(56, 49);
			biSim.Text = "Memories";
			biSim.TextImageRelation =
				TextImageRelation
				.ImageAboveText;
			biSim.Click += new EventHandler(ChoosePage);
			//
			// biBadge
			//
			biBadge.Image = (
				(System.Drawing.Image)(resources.GetObject("biBadge.Image"))
			);
			biBadge.ImageScaling =
				ToolStripItemImageScaling
				.None;
			biBadge.Name = "biBadge";
			biBadge.Size = new System.Drawing.Size(46, 49);
			biBadge.Text = "Badges";
			biBadge.TextImageRelation =
				TextImageRelation
				.ImageAboveText;
			biBadge.Click += new EventHandler(ChoosePage);
			//
			// biDebug
			//
			biDebug.Image = (
				(System.Drawing.Image)(resources.GetObject("biDebug.Image"))
			);
			biDebug.ImageScaling =
				ToolStripItemImageScaling
				.None;
			biDebug.Name = "biDebug";
			biDebug.Size = new System.Drawing.Size(42, 49);
			biDebug.Text = "Debug";
			biDebug.TextImageRelation =
				TextImageRelation
				.ImageAboveText;
			biDebug.Click += new EventHandler(ChoosePage);
			//
			// ExtNgbhUI
			//
			Controls.Add(pnSims);
			Controls.Add(pnBadge);
			Controls.Add(pnDebug);
			Controls.Add(toolBar1);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			HeaderText = "Sim Memory Editor";
			Name = "ExtNgbhUI";
			Size = new System.Drawing.Size(680, 368);
			Controls.SetChildIndex(toolBar1, 0);
			Controls.SetChildIndex(pnDebug, 0);
			Controls.SetChildIndex(pnBadge, 0);
			Controls.SetChildIndex(pnSims, 0);
			pnSims.ResumeLayout(false);
			pnSims.PerformLayout();
			menu.ResumeLayout(false);
			pnDebug.ResumeLayout(false);
			pnBadge.ResumeLayout(false);
			toolBar1.ResumeLayout(false);
			toolBar1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion

		public ExtNgbh Ngbh => (ExtNgbh)Wrapper;

		protected override void RefreshGUI()
		{
			simslot.NgbhResource = Ngbh;
			spc_SelectedSimChanged(spc, null, null);
			spc.Package = Ngbh.Package;
			nssel.NgbhResource = Ngbh;
			shelper.NgbhResource = Ngbh;
		}

		public override void OnCommit()
		{
			Ngbh.SynchronizeUserData(true, false);
		}

		public void SelectButton(ToolStripButton b)
		{
			for (int i = 0; i < toolBar1.Items.Count; i++)
			{
				if (toolBar1.Items[i] is ToolStripButton item)
				{
					item.Checked = (item == b);

					if (item.Tag != null)
					{
						Panel pn = (Panel)item.Tag;
						pn.Visible = item.Checked;
					}
				}
			}

			UpdateEnabledState();
		}

		void UpdateEnabledState()
		{
		}

		private void ChoosePage(object sender, EventArgs e)
		{
			SelectButton((ToolStripButton)sender);

			if (pnSims.Visible)
			{
				pnSims.Controls.Add(spc);
			}
			else if (pnBadge.Visible)
			{
				pnBadge.Controls.Add(spc);
			}
		}

		private void spc_SelectedSimChanged(
			object sender,
			System.Drawing.Image thumb,
			PackedFiles.Wrapper.SDesc sdesc
		)
		{
			if (spc.SelectedSim != null)
			{
				Collections.NgbhSlots slots = Ngbh.GetSlots(
					Data.NeighborhoodSlots.Sims
				);
				if (slots != null)
				{
					NgbhSlot slot = slots.GetInstanceSlot(spc.SelectedSim.Instance);
					if (slot == null)
					{
						slots.AddNew(spc.SelectedSim.Instance);
					}
				}
			}
		}

		private void nssel_SelectedSlotChanged(object sender, EventArgs e)
		{
			nsui.Slot = nssel.SelectedSlot;
		}

		bool updateitems;

		private void shelper_AddedNewItem(object sender, EventArgs e)
		{
			updateitems = true;
		}

		private void shelper_ChangedItem(object sender, EventArgs e)
		{
			updateitems = true;
		}

		protected void RefreshContent()
		{
			nsui.Refresh();
			simslot.Refresh();
		}

		private void pnBadge_VisibleChanged(object sender, EventArgs e)
		{
			if (pnBadge.Visible == true)
			{
				updateitems = false;
			}
			else if (updateitems)
			{
				RefreshContent();
			}
		}

		#region Extensions by Theo
		void menu_VisibleChanged(object sender, EventArgs e)
		{
			miFix.Enabled = (Ngbh != null) && Helper.WindowsRegistry.HiddenMode;
			miNuke.Enabled = (spc.SelectedSim != null);
		}

		private void miNuke_Activate(object sender, EventArgs e)
		{
			if (spc.SelectedSim != null)
			{
				Collections.NgbhSlots slots = Ngbh.GetSlots(
					Data.NeighborhoodSlots.Sims
				);
				if (slots != null)
				{
					NgbhSlot slot = slots.GetInstanceSlot(spc.SelectedSim.Instance);
					if (slot != null)
					{
						slot.RemoveMyMemories();
						int deletedCount = slot.RemoveMemoriesAboutMe();

						if (deletedCount > 0)
						{
							Message.Show(
								String.Format(
									"Deleted {0} memories from the sim pool",
									deletedCount
								),
								"Advice",
								MessageBoxButtons.OK
							);
						}

						spc.Refresh();
					}
				}
			}
		}

		private void miFix_Activate(object sender, EventArgs e)
		{
			if (Ngbh is EnhancedNgbh ngbh)
			{
				ngbh.FixNeighborhoodMemories();
				RefreshGUI();
			}
		}
		#endregion
	}
}
