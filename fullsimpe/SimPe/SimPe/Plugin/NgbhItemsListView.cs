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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for NgbhItemsListViewItem.
	/// </summary>
	public class NgbhItemsListView : UserControl
	{
		private IContainer components;
		private Panel panel1;
		private ComboBox cbadd;
		private LinkLabel lladd;
		private LinkLabel lldel;
		private Button btUp;
		private Button btDown;
		private ToolStripMenuItem miCopy;
		private ToolStripMenuItem miPaste;
		private ContextMenuStrip menu;
		private ToolStripMenuItem miPasteGossip;
		private ToolStripMenuItem miClone;
		private ToolStripMenuItem miDelCascade;
		private ToolStripSeparator toolStripMenuItem2;
		private ListView lv;
		private CheckBox cbnogoss;

		ThemeManager tm;

		public NgbhItemsListView()
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

			SmallImageList = new ImageList
			{
				ImageSize = new Size(NgbhItem.ICON_SIZE, NgbhItem.ICON_SIZE),
				ColorDepth = ColorDepth.Depth32Bit
			};

			lv.SelectedIndexChanged += new EventHandler(lv_SelectedIndexChanged);

			SlotType = Data.NeighborhoodSlots.Sims;

			tm = ThemeManager.Global.CreateChild();
			tm.AddControl(menu);
			InitTheo();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (tm != null)
				{
					tm.Clear();
					tm.Parent = null;
					tm = null;
				}
				clipboard?.Clear();

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
					typeof(NgbhItemsListView)
				);
			lv = new ListView();
			menu = new ContextMenuStrip(components);
			miCopy = new ToolStripMenuItem();
			miPaste = new ToolStripMenuItem();
			miPasteGossip = new ToolStripMenuItem();
			toolStripMenuItem2 = new ToolStripSeparator();
			miClone = new ToolStripMenuItem();
			miDelCascade = new ToolStripMenuItem();
			panel1 = new Panel();
			cbnogoss = new CheckBox();
			lladd = new LinkLabel();
			cbadd = new ComboBox();
			lldel = new LinkLabel();
			btUp = new Button();
			btDown = new Button();
			menu.SuspendLayout();
			panel1.SuspendLayout();
			SuspendLayout();
			//
			// lv
			//
			lv.BorderStyle = BorderStyle.FixedSingle;
			lv.ContextMenuStrip = menu;
			resources.ApplyResources(lv, "lv");
			lv.HeaderStyle = ColumnHeaderStyle.Nonclickable;
			lv.HideSelection = false;
			lv.Name = "lv";
			lv.UseCompatibleStateImageBehavior = false;
			lv.View = View.List;
			lv.SelectedIndexChanged += new EventHandler(
				lv_SelectedIndexChanged_1
			);
			//
			// menu
			//
			menu.Items.AddRange(
				new ToolStripItem[]
				{
					miCopy,
					miPaste,
					miPasteGossip,
					toolStripMenuItem2,
					miClone,
					miDelCascade,
				}
			);
			menu.Name = "menu";
			resources.ApplyResources(menu, "menu");
			menu.VisibleChanged += new EventHandler(
				menu_VisibleChanged
			);
			//
			// miCopy
			//
			resources.ApplyResources(miCopy, "miCopy");
			miCopy.Name = "miCopy";
			miCopy.Click += new EventHandler(CopyItems);
			//
			// miPaste
			//
			resources.ApplyResources(miPaste, "miPaste");
			miPaste.Name = "miPaste";
			miPaste.Click += new EventHandler(PasteItems);
			//
			// miPasteGossip
			//
			miPasteGossip.Name = "miPasteGossip";
			resources.ApplyResources(miPasteGossip, "miPasteGossip");
			miPasteGossip.Click += new EventHandler(
				PasteItemsAsGossip
			);
			//
			// toolStripMenuItem2
			//
			toolStripMenuItem2.Name = "toolStripMenuItem2";
			resources.ApplyResources(toolStripMenuItem2, "toolStripMenuItem2");
			//
			// miClone
			//
			miClone.Name = "miClone";
			resources.ApplyResources(miClone, "miClone");
			miClone.Click += new EventHandler(CloneItem);
			//
			// miDelCascade
			//
			resources.ApplyResources(miDelCascade, "miDelCascade");
			miDelCascade.Name = "miDelCascade";
			miDelCascade.Click += new EventHandler(DeleteCascadeItems);
			//
			// panel1
			//
			resources.ApplyResources(panel1, "panel1");
			panel1.BackColor = Color.Transparent;
			panel1.Controls.Add(cbnogoss);
			panel1.Controls.Add(lladd);
			panel1.Controls.Add(cbadd);
			panel1.Controls.Add(lldel);
			panel1.Controls.Add(btUp);
			panel1.Controls.Add(btDown);
			panel1.Name = "panel1";
			//
			// cbnogoss
			//
			resources.ApplyResources(cbnogoss, "cbnogoss");
			cbnogoss.Name = "cbnogoss";
			cbnogoss.UseVisualStyleBackColor = true;
			cbnogoss.CheckedChanged += new EventHandler(
				cbnogoss_CheckedChanged
			);
			//
			// lladd
			//
			resources.ApplyResources(lladd, "lladd");
			lladd.Name = "lladd";
			lladd.TabStop = true;
			lladd.UseCompatibleTextRendering = true;
			lladd.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					lladd_LinkClicked
				);
			//
			// cbadd
			//
			resources.ApplyResources(cbadd, "cbadd");
			cbadd.DropDownStyle = ComboBoxStyle.DropDownList;
			cbadd.ForeColor = SystemColors.ControlText;
			cbadd.Name = "cbadd";
			cbadd.SelectedIndexChanged += new EventHandler(
				cbadd_SelectedIndexChanged
			);
			//
			// lldel
			//
			resources.ApplyResources(lldel, "lldel");
			lldel.Name = "lldel";
			lldel.TabStop = true;
			lldel.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					lldel_LinkClicked
				);
			//
			// btUp
			//
			resources.ApplyResources(btUp, "btUp");
			btUp.Name = "btUp";
			btUp.Click += new EventHandler(btUp_Click);
			//
			// btDown
			//
			resources.ApplyResources(btDown, "btDown");
			btDown.Name = "btDown";
			btDown.Click += new EventHandler(btDown_Click);
			//
			// NgbhItemsListView
			//
			Controls.Add(lv);
			Controls.Add(panel1);
			resources.ApplyResources(this, "$this");
			Name = "NgbhItemsListView";
			menu.ResumeLayout(false);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		Data.NeighborhoodSlots st;
		public Data.NeighborhoodSlots SlotType
		{
			get => st;
			set
			{
				if (st != value)
				{
					st = value;
					SetContent();
				}
			}
		}

		bool cc = false;

		[Category("Appearance")]
		[DefaultValue(typeof(bool), "false")]
		[Browsable(true)]
		public bool ShowGossip
		{
			get => cc;
			set
			{
				cc = value;
				cbnogoss.Visible = cc;
			}
		}

		public NgbhSlotList Slot
		{
			get
			{
				if (NgbhItems == null)
				{
					return null;
				}
				else
				{
					return NgbhItems.Parent;
				}
			}
			set
			{
				NgbhItems = value != null ? value.GetItems(SlotType) : null;
			}
		}

		Collections.NgbhItems items;

		[Browsable(false)]
		public Collections.NgbhItems NgbhItems
		{
			get => items;
			set
			{
				items = value;
				SetContent();
			}
		}

		void SetContent()
		{
			Clear();
			cbadd.Items.Clear();

			if (items != null)
			{
				lv.BeginUpdate();
				foreach (NgbhItem i in items)
				{
					if (cbnogoss.Checked)
					{
						if (!i.IsGossip)
						{
							AddItemToList(i);
						}
					}
					else
					{
						AddItemToList(i);
					}
				}
				lv.EndUpdate();

				SetAvailableAddTypes();
			}
		}

		public void Refresh(bool full)
		{
			if (full)
			{
				SetContent();
			}

			base.Refresh();
		}

		public new void Refresh()
		{
			Refresh(true);
		}

		void AddItemToList(NgbhItem item)
		{
			if (item == null)
			{
				return;
			}

			NgbhItemsListViewItem lvi = new NgbhItemsListViewItem(this, item);
		}

		void InsertItemToList(int index, NgbhItem item)
		{
			if (item == null)
			{
				return;
			}

			NgbhItemsListViewItem lvi = new NgbhItemsListViewItem(this, item, false);
			lv.Items.Insert(index, lvi);
		}

		void SetAvailableAddTypes()
		{
			string prefix =
				typeof(SimMemoryType).Namespace
				+ "."
				+ typeof(SimMemoryType).Name
				+ ".";
			SimMemoryType[] sts = Ngbh.AllowedMemoryTypes(st);
			foreach (SimMemoryType mst in sts)
			{
				cbadd.Items.Add(
					new Data.Alias(
						(uint)mst,
						Localization.GetString(prefix + mst.ToString()),
						"{name}"
					)
				);
			}

			if (cbadd.Items.Count > 0)
			{
				cbadd.SelectedIndex = 0;
			}
		}

		public void Clear()
		{
			lv.Clear();
			lv.SmallImageList?.Images.Clear();
		}

		[Browsable(false)]
		public NgbhItemsListViewItem SelectedItem
		{
			get
			{
				if (lv.SelectedItems.Count == 0)
				{
					return null;
				}

				if (lv.FocusedItem != null)
				{
					if (lv.FocusedItem.Selected)
					{
						return lv.FocusedItem as NgbhItemsListViewItem;
					}
				}

				return lv.SelectedItems[0] as NgbhItemsListViewItem;
			}
		}

		[Browsable(false)]
		public NgbhItem SelectedNgbhItem
		{
			get
			{
				if (SelectedItem == null)
				{
					return null;
				}

				return SelectedItem.Item;
			}
		}

		[Browsable(false)]
		public Collections.NgbhItems SelectedNgbhItems
		{
			get
			{
				NgbhSlotList parent = null;
				if (items != null)
				{
					parent = items.Parent;
				}

				Collections.NgbhItems ret = new Collections.NgbhItems(parent);
				foreach (NgbhItemsListViewItem lvi in lv.SelectedItems)
				{
					ret.Add(lvi.Item);
				}

				return ret;
			}
		}

		[Browsable(false)]
		public bool SelectedMultiple => lv.SelectedItems.Count > 1;

		internal void UpdateSelected(NgbhItem item)
		{
			if (item == null)
			{
				return;
			}

			if (SelectedItem == null)
			{
				return;
			}

			SelectedItem.Update();
			Refresh(false);
		}

		public ListView.ListViewItemCollection Items => lv.Items;

		ImageList sil;
		public ImageList SmallImageList
		{
			get => sil;
			set
			{
				lv.SmallImageList = value;
				sil = value;
			}
		}

		public event EventHandler SelectedIndexChanged;

		private void lv_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (SelectedIndexChanged != null)
			{
				SelectedIndexChanged(this, e);
			}
		}

		private void cbadd_SelectedIndexChanged(object sender, EventArgs e)
		{
			lladd.Enabled = cbadd.SelectedIndex >= 0 && items != null;
		}

		private void lv_SelectedIndexChanged_1(object sender, EventArgs e)
		{
			lldel.Enabled = (lv.SelectedItems.Count > 0 && items != null);
			if (lv.Items.Count == 0 || lv.SelectedItems.Count != 1 || items == null)
			{
				btUp.Enabled = false;
				btDown.Enabled = false;
			}
			else
			{
				btUp.Enabled = lldel.Enabled && !lv.Items[0].Selected;
				btDown.Enabled =
					lldel.Enabled && !lv.Items[lv.Items.Count - 1].Selected;
			}
		}

		private void lladd_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (items == null || cbadd.SelectedIndex < 0)
			{
				return;
			}

			Data.Alias a = cbadd.SelectedItem as Data.Alias;
			SimMemoryType smt = (SimMemoryType)a.Id;

			int index = NextItemIndex(true);
			NgbhItem item = items.InsertNew(index, smt);
			item.SetInitialGuid(smt);
			InsertItemToList(index, item);

			lv.Items[index].Selected = true;
			lv.Items[index].EnsureVisible();
		}

		private void lldel_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (lv.SelectedItems.Count == 0 || items == null)
			{
				return;
			}
			//NgbhItemsListViewItem item = this.SelectedItem;
			Collections.NgbhItems nitems = SelectedNgbhItems;
			items.Remove(nitems);

			for (int i = lv.SelectedItems.Count; i > 0; i--)
			{
				lv.Items.Remove(lv.SelectedItems[0]);
			}
		}

		void SwapListViewItem(int i1, int i2)
		{
			if (i1 < 0 || i2 < 0 || i1 >= lv.Items.Count || i2 >= lv.Items.Count)
			{
				return;
			}

			ListViewItem o1 = lv.Items[i1];
			ListViewItem o2 = lv.Items[i2];

			lv.Items[i1] = new ListViewItem();
			lv.Items[i2] = o1;
			lv.Items[i1] = o2;
		}

		int SelectedIndex
		{
			get
			{
				if (lv.SelectedIndices.Count == 0)
				{
					return -1;
				}

				return lv.SelectedIndices[0];
			}
		}

		private void btUp_Click(object sender, EventArgs e)
		{
			int index = SelectedIndex;
			items.Swap(index, index - 1);
			SwapListViewItem(index, index - 1);
		}

		private void btDown_Click(object sender, EventArgs e)
		{
			int index = SelectedIndex;
			items.Swap(index, index + 1);
			SwapListViewItem(index, index + 1);
		}

		private void cbnogoss_CheckedChanged(object sender, EventArgs e)
		{
			SetContent();
		}

		#region Extensions by Theo
		Queue clipboard;

		void InitTheo()
		{
			clipboard = new Queue();
		}

		void CopyItems(object sender, EventArgs e)
		{
			CopyItems();
		}

		void CopyItems()
		{
			Collections.NgbhItems selitems = SelectedNgbhItems;
			if (selitems.Count > 0)
			{
				Cursor = Cursors.WaitCursor;
				try
				{
					clipboard.Clear();
					foreach (NgbhItem item in selitems)
					{
						clipboard.Enqueue(item);
					}
				}
				catch (Exception exception1)
				{
					Cursor = Cursors.Default;
					Helper.ExceptionMessage(
						Localization.Manager.GetString("errconvert"),
						exception1
					);
				}
				Cursor = Cursors.Default;
			}
		}

		void PasteItems(object sender, EventArgs e)
		{
			PasteItems(false);
		}

		void PasteItemsAsGossip(object sender, EventArgs e)
		{
			PasteItems(true);
		}

		void PasteItems(bool asgossip)
		{
			int itemIndex = NextItemIndex(false);
			Cursor = Cursors.WaitCursor;
			Queue newq = new Queue();
			try
			{
				while (clipboard.Count > 0)
				{
					NgbhItem item = clipboard.Dequeue() as NgbhItem;
					newq.Enqueue(item);

					if (item != null)
					{
						item = item.Clone(Slot);

						if (item.IsMemory && item.OwnerInstance > 0 && !asgossip)
						{
							item.OwnerInstance = (ushort)items.Parent.SlotID;
						}

						if (asgossip)
						{
							item.Flags.IsVisible = false;
						}

						AddItemAfterSelected(item);
					}
				}
			}
			catch (Exception exception1)
			{
				Cursor = Cursors.Default;
				Helper.ExceptionMessage(
					Localization.Manager.GetString("errconvert"),
					exception1
				);
			}

			clipboard.Clear();
			clipboard = newq;
			Cursor = Cursors.Default;
		}

		void AddItemAfterSelected(NgbhItem item)
		{
			//if (this.lv.SelectedItems.Count > 0)
			{
				Cursor = Cursors.WaitCursor;
				try
				{
					int selectedIndex = NextItemIndex(true);

					NgbhItems.Insert(selectedIndex, item);
					AddItemAt(item, selectedIndex);
					lv.Items[selectedIndex].Selected = true;
					lv.Items[selectedIndex].EnsureVisible();
				}
				catch (Exception exception1)
				{
					Cursor = Cursors.Default;
					Helper.ExceptionMessage(
						Localization.Manager.GetString("errconvert"),
						exception1
					);
				}

				Cursor = Cursors.Default;
			}
		}

		private void AddItemAt(NgbhItem item, int index)
		{
			InsertItemToList(index, item);
			lv.SelectedItems.Clear();
			lv.Items[index].Selected = true;
			lv.Items[index].EnsureVisible();
			if (SelectedIndexChanged != null)
			{
				SelectedIndexChanged(this, new EventArgs());
			}
		}

		int NextItemIndex(bool clearSelection)
		{
			int selectedIndex = lv.Items.Count - 1;

			// get index of the last selected item (if any)
			if (lv.SelectedIndices.Count > 0)
			{
				selectedIndex = lv.SelectedIndices[
					lv.SelectedIndices.Count - 1
				];
			}

			// deselect previous (if applicable)
			if (clearSelection)
			{
				lv.SelectedItems.Clear();
			}

			// should not exceed the number of items (?)
			selectedIndex = Math.Min(++selectedIndex, lv.Items.Count);

			return selectedIndex;
		}

		void CloneItem(object sender, EventArgs e)
		{
			CloneItem();
		}

		void CloneItem()
		{
			if (lv.SelectedItems.Count > 0)
			{
				Cursor = Cursors.WaitCursor;
				try
				{
					// this command operates on a single item only;
					// to avoid ambiguity, use the focused item
					NgbhItem item = GetFocusedItem();
					if (item != null)
					{
						int itemIndex = lv.FocusedItem.Index + 1;
						NgbhItem item1 = item.Clone();

						items.Insert(itemIndex, item1);
						AddItemAt(item1, itemIndex);

						lv.FocusedItem.Focused = false;
					}
				}
				catch (Exception exception1)
				{
					Cursor = Cursors.Default;
					Helper.ExceptionMessage(
						Localization.Manager.GetString("errconvert"),
						exception1
					);
				}
				Cursor = Cursors.Default;
			}
		}

		NgbhItem GetFocusedItem()
		{
			NgbhItemsListViewItem li = SelectedItem;
			if (li == null)
			{
				return null;
			}

			return li.Item;
		}

		public void SelectMemoriesByGuid(Collections.NgbhItems items)
		{
			if (items.Length > 0)
			{
				lv.Enabled = false;

				ArrayList guidList = new ArrayList();
				foreach (NgbhItem item in items)
				{
					if (!guidList.Contains(item.Guid))
					{
						guidList.Add(item.Guid);
					}
				}

				foreach (ListViewItem li in lv.Items)
				{
					NgbhItem item = li.Tag as NgbhItem;
					if (guidList.Contains(item.Guid))
					{
						li.Selected = true;
					}
				}

				lv.Enabled = true;
			}
		}

		void DeleteItems(object sender, EventArgs e)
		{
			DeleteItems(false);
		}

		void DeleteCascadeItems(object sender, EventArgs e)
		{
			DeleteItems(true);
		}

		void DeleteItems(bool cascade)
		{
			if (lv.SelectedItems.Count != 0)
			{
				Cursor = Cursors.WaitCursor;
				try
				{
					ArrayList items = new ArrayList();
					foreach (ListViewItem li in lv.SelectedItems)
					{
						items.Add(li);
					}

					Collections.NgbhItems memoryItems = SelectedNgbhItems;

					if (cascade)
					{
						((EnhancedNgbh)Slot.Parent).DeleteMemoryEchoes(
							memoryItems,
							Slot.SlotID
						);
					}

					memoryItems[0].ParentSlot.ItemsB.Remove(memoryItems);

					foreach (ListViewItem li in items)
					{
						lv.Items.Remove(li);
					}

					lv.SelectedItems.Clear();
				}
				catch (Exception exception1)
				{
					Cursor = Cursors.Default;
					Helper.ExceptionMessage(
						Localization.Manager.GetString("errconvert"),
						exception1
					);
				}
				Cursor = Cursors.Default;
			}
		}

		void menu_VisibleChanged(object sender, EventArgs e)
		{
			try
			{
				miCopy.Enabled = lv.SelectedItems.Count > 0;
				miClone.Enabled = miCopy.Enabled;
				miPaste.Enabled = clipboard.Count > 0;

				if (
					((NgbhSlot)items.Parent).Type == Data.NeighborhoodSlots.Sims
					|| ((NgbhSlot)items.Parent).Type
						== Data.NeighborhoodSlots.SimsIntern
				)
				{
					miDelCascade.Enabled = miCopy.Enabled;
					miPasteGossip.Enabled = miPaste.Enabled;
				}
				else
				{
					miDelCascade.Enabled = false;
					miPasteGossip.Enabled = false;
				}
			}
			catch
			{
				miCopy.Enabled =
					miPaste.Enabled =
					miPasteGossip.Enabled =
					miClone.Enabled =
					miDelCascade.Enabled =
						false;
			}
		}
		#endregion
	}
}
