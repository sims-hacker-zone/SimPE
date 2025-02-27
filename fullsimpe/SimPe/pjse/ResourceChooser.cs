/***************************************************************************
 *   Copyright (C) 2005 by Peter L Jones                                   *
 *   pljones@users.sf.net                                                  *
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
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using SimPe.Interfaces.Files;
using SimPe.Plugin;

using Bhav = SimPe.PackedFiles.Wrapper.Bhav;

namespace pjse
{
	/// <summary>
	/// Summary description for ResourceChooser.
	/// </summary>
	public class ResourceChooser : Form
	{
		#region Form variables

		private Button OK;
		private Button Cancel;
		private TabControl tcResources;
		private TabPage tpBuiltIn;
		private TabPage tpGlobalGroup;
		private TabPage tpSemiGroup;
		private TabPage tpGroup;
		private TabPage tpPackage;
		private ListView lvPackage;
		private ColumnHeader chValue;
		private ColumnHeader chName;
		private ListView lvGlobal;
		private ColumnHeader columnHeader1;
		private ColumnHeader columnHeader2;
		private ListView lvGroup;
		private ColumnHeader columnHeader3;
		private ColumnHeader columnHeader4;
		private ListView lvSemi;
		private ColumnHeader columnHeader5;
		private ColumnHeader columnHeader6;
		private ListView lvPrim;
		private ColumnHeader columnHeader7;
		private ColumnHeader columnHeader8;
		private Button btnViewBHAV;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public ResourceChooser()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
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

		#region ResourceChooser

		const string BASENAME = "PJSE\\Bhav";
		private static int ChooserOrder
		{
			get
			{
				SimPe.XmlRegistryKey rkf =
					SimPe.Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey(
						BASENAME
					);
				object o = rkf.GetValue("chooserOrder", 0);
				return (int)Math.Max(Convert.ToUInt32(o), 1);
			}
			set
			{
				SimPe.XmlRegistryKey rkf =
					SimPe.Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey(
						BASENAME
					);
				rkf.SetValue("chooserOrder", value);
			}
		}

		private static Size ChooserSize
		{
			get
			{
				SimPe.XmlRegistryKey rkf =
					SimPe.Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey(
						BASENAME
					);
				ResourceChooser rc = new ResourceChooser();
				object w = rkf.GetValue("chooserSize.Width", rc.Size.Width);
				object h = rkf.GetValue("chooserSize.Height", rc.Size.Height);
				return new Size(Convert.ToInt32(w), Convert.ToInt32(h));
			}
			set
			{
				SimPe.XmlRegistryKey rkf =
					SimPe.Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey(
						BASENAME
					);
				rkf.SetValue("chooserSize.Width", value.Width);
				rkf.SetValue("chooserSize.Height", value.Height);
			}
		}

		private class ListViewItemComparer : IComparer
		{
			private int col;

			public ListViewItemComparer()
			{
				col = ChooserOrder;
			}

			public ListViewItemComparer(int column)
			{
				col = column;
			}

			public int Compare(object x, object y)
			{
				return string.Compare(
					((ListViewItem)x).SubItems[col].Text,
					((ListViewItem)y).SubItems[col].Text
				);
			}
		}

		private bool CanDoEA;

		public static int PersistentTab
		{
			get
			{
				SimPe.XmlRegistryKey rkf =
					SimPe.Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey(
						BASENAME
					);
				object o = rkf.GetValue("rcPersistentTab", false);
				return Convert.ToInt32(o);
			}
			set
			{
				SimPe.XmlRegistryKey rkf =
					SimPe.Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey(
						BASENAME
					);
				rkf.SetValue("rcPersistentTab", value);
			}
		}

		private ListView getListView()
		{
			return tcResources.SelectedTab == tpPackage
				&& lvPackage.SelectedItems != null
				? lvPackage
				: tcResources.SelectedTab == tpGroup
				&& lvGroup.SelectedItems != null
				? lvGroup
				: tcResources.SelectedTab == tpSemiGroup
				&& lvSemi.SelectedItems != null
				? lvSemi
				: tcResources.SelectedTab == tpGlobalGroup
				&& lvGlobal.SelectedItems != null
				? lvGlobal
				: tcResources.SelectedTab == tpBuiltIn
				&& lvPrim.SelectedItems != null
				? lvPrim
				: null;
		}

		/// <summary>
		/// List available resources of a given type, allowing the user to select one.
		/// </summary>
		/// <param name="resourceType">Type of resource to list</param>
		/// <param name="group">Group number of "this" group</param>
		/// <param name="form">Parent form</param>
		/// <param name="canDoEA">Whether to differentiate overriding resources</param>
		/// <returns>The chosen resource entry</returns>
		public FileTable.Entry Execute(
			uint resourceType,
			uint group,
			Control form,
			bool canDoEA
		)
		{
			return Execute(resourceType, group, form, canDoEA, 0);
		}

		/// <summary>
		/// List available resources of a given type, allowing the user to select one.
		/// </summary>
		/// <param name="resourceType">Type of resource to list</param>
		/// <param name="group">Group number of "this" group</param>
		/// <param name="form">Parent form</param>
		/// <param name="skip_pages">A flag per page (this package, private, semi, global, prim) to suppress pages</param>
		/// <param name="canDoEA">Whether to differentiate overriding resources</param>
		/// <returns>The chosen resource entry</returns>
		public FileTable.Entry Execute(
			uint resourceType,
			uint group,
			Control form,
			bool canDoEA,
			Boolset skip_pages
		)
		{
			CanDoEA = canDoEA;

			form.Cursor = Cursors.WaitCursor;
			Cursor = Cursors.WaitCursor;

			List<TabPage> ltp = new List<TabPage>(
				new TabPage[]
				{
					tpPackage,
					tpGroup,
					tpSemiGroup,
					tpGlobalGroup,
					tpBuiltIn,
				}
			);

			btnViewBHAV.Visible = resourceType == SimPe.Data.MetaData.BHAV_FILE;

			tcResources.TabPages.Clear();

			// There doesn't appear to be a way to compare two paths and have the OS decide if they refer to the same object
			if (
				!skip_pages[0]
				&& FileTable.GFT.CurrentPackage != null
				&& FileTable.GFT.CurrentPackage.FileName != null
				&& !
					FileTable.GFT.CurrentPackage.FileName.ToLower()
					.EndsWith("objects.package")
			)
			{
				FillPackage(resourceType, lvPackage, tpPackage);
			}

			if (!skip_pages[1])
			{
				FillGroup(resourceType, group, lvGroup, tpGroup);
			}

			if (!skip_pages[2])
			{
				Glob g = BhavWiz.GlobByGroup(group);
				if (g != null)
				{
					FillGroup(
						resourceType,
						g.SemiGlobalGroup,
						lvSemi,
						tpSemiGroup
					);
					tpSemiGroup.Text = g.SemiGlobalName;
				}
			}

			if (!skip_pages[3] && group != (uint)Group.Global)
			{
				FillGroup(
					resourceType,
					(uint)Group.Global,
					lvGlobal,
					tpGlobalGroup
				);
			}

			if (!skip_pages[4] && resourceType == SimPe.Data.MetaData.BHAV_FILE)
			{
				FillBuiltIn(resourceType, lvPrim, tpBuiltIn);
			}

			if (tcResources.TabCount > 0)
			{
				if (tcResources.Contains(ltp[PersistentTab]))
				{
					tcResources.SelectTab(ltp[PersistentTab]);
				}
				else
				{
					tcResources.SelectedIndex = 0;
				}
			}

			form.Cursor = Cursors.Default;
			Cursor = Cursors.Default;
			Size = ChooserSize;

			DialogResult dr = ShowDialog();
			while (dr == DialogResult.Retry)
			{
				dr = ShowDialog();
			}

			ChooserSize = Size;
			PersistentTab = ltp.IndexOf(tcResources.SelectedTab);
			Close();

			if (dr == DialogResult.OK)
			{
				ListView lv = getListView();

				if (lv != null)
				{
					if (lv != lvPrim)
					{
						return (FileTable.Entry)lv.SelectedItems[0].Tag;
					}
					else
					{
						IPackedFileDescriptor pfd =
							new SimPe.Packages.PackedFileDescriptor
							{
								Instance = (uint)lvPrim.SelectedItems[0].Tag
							};
						return new FileTable.Entry(null, pfd, true, true);
					}
				}
			}
			return null;
		}

		private void FillPackage(uint type, ListView list, TabPage tab)
		{
			Fill(
				FileTable.GFT[FileTable.GFT.CurrentPackage, type],
				list,
				tab
			);
		}

		private void FillGroup(uint type, uint group, ListView list, TabPage tab)
		{
			Fill(FileTable.GFT[type, group], list, tab);
		}

		private void Fill(FileTable.Entry[] items, ListView list, TabPage tab)
		{
			list.Items.Clear();
			ListViewItem lvi;

			foreach (FileTable.Entry item in items)
			{
				lvi = new ListViewItem(
					new string[]
					{
						"0x" + SimPe.Helper.HexString((ushort)item.Instance),
						item,
					}
				)
				{
					Tag = item
				};
				list.Items.Add(lvi);
			}
			tcResources.TabPages.Add(tab);
			list.ListViewItemSorter = new ListViewItemComparer();
			if (list.Items.Count > 0)
			{
				list.SelectedIndices.Add(0);
			}
		}

		private void FillBuiltIn(uint type, ListView list, TabPage tab)
		{
			list.Items.Clear();
			ListViewItem lvi;

			uint i = 0;
			foreach (string s in BhavWiz.readStr(GS.BhavStr.Primitives))
			{
				if (!s.StartsWith("~"))
				{
					lvi = new ListViewItem(
						new string[] { "0x" + SimPe.Helper.HexString((ushort)i), s }
					)
					{
						Tag = i
					};
					list.Items.Add(lvi);
				}
				i++;
			}

			tcResources.TabPages.Add(tab);
			list.ListViewItemSorter = new ListViewItemComparer();
			if (list.Items.Count > 0)
			{
				list.SelectedIndices.Add(0);
			}
		}

		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(
					typeof(ResourceChooser)
				);
			tcResources = new TabControl();
			tpPackage = new TabPage();
			lvPackage = new ListView();
			chValue = new ColumnHeader();
			chName = new ColumnHeader();
			tpGlobalGroup = new TabPage();
			lvGlobal = new ListView();
			columnHeader1 = new ColumnHeader();
			columnHeader2 = new ColumnHeader();
			tpGroup = new TabPage();
			lvGroup = new ListView();
			columnHeader3 = new ColumnHeader();
			columnHeader4 = new ColumnHeader();
			tpSemiGroup = new TabPage();
			lvSemi = new ListView();
			columnHeader5 = new ColumnHeader();
			columnHeader6 = new ColumnHeader();
			tpBuiltIn = new TabPage();
			lvPrim = new ListView();
			columnHeader7 = new ColumnHeader();
			columnHeader8 = new ColumnHeader();
			OK = new Button();
			Cancel = new Button();
			btnViewBHAV = new Button();
			tcResources.SuspendLayout();
			tpPackage.SuspendLayout();
			tpGlobalGroup.SuspendLayout();
			tpGroup.SuspendLayout();
			tpSemiGroup.SuspendLayout();
			tpBuiltIn.SuspendLayout();
			SuspendLayout();
			//
			// tcResources
			//
			resources.ApplyResources(tcResources, "tcResources");
			tcResources.Controls.Add(tpPackage);
			tcResources.Controls.Add(tpGlobalGroup);
			tcResources.Controls.Add(tpGroup);
			tcResources.Controls.Add(tpSemiGroup);
			tcResources.Controls.Add(tpBuiltIn);
			tcResources.Name = "tcResources";
			tcResources.SelectedIndex = 0;
			tcResources.SelectedIndexChanged += new EventHandler(
				tcResources_SelectedIndexChanged
			);
			//
			// tpPackage
			//
			tpPackage.Controls.Add(lvPackage);
			resources.ApplyResources(tpPackage, "tpPackage");
			tpPackage.Name = "tpPackage";
			//
			// lvPackage
			//
			lvPackage.Columns.AddRange(
				new ColumnHeader[] { chValue, chName }
			);
			resources.ApplyResources(lvPackage, "lvPackage");
			lvPackage.FullRowSelect = true;
			lvPackage.HideSelection = false;
			lvPackage.Items.AddRange(
				new ListViewItem[]
				{

						(ListViewItem)
							resources.GetObject("lvPackage.Items")

					,
				}
			);
			lvPackage.MultiSelect = false;
			lvPackage.Name = "lvPackage";
			lvPackage.ShowGroups = false;
			lvPackage.Sorting = SortOrder.Ascending;
			lvPackage.UseCompatibleStateImageBehavior = false;
			lvPackage.View = View.Details;
			lvPackage.DoubleClick += new EventHandler(
				listView_DoubleClick
			);
			lvPackage.ColumnClick +=
				new ColumnClickEventHandler(
					listView_ColumnClick
				);
			//
			// chValue
			//
			resources.ApplyResources(chValue, "chValue");
			//
			// chName
			//
			resources.ApplyResources(chName, "chName");
			//
			// tpGlobalGroup
			//
			tpGlobalGroup.Controls.Add(lvGlobal);
			resources.ApplyResources(tpGlobalGroup, "tpGlobalGroup");
			tpGlobalGroup.Name = "tpGlobalGroup";
			//
			// lvGlobal
			//
			lvGlobal.Columns.AddRange(
				new ColumnHeader[]
				{
					columnHeader1,
					columnHeader2,
				}
			);
			resources.ApplyResources(lvGlobal, "lvGlobal");
			lvGlobal.FullRowSelect = true;
			lvGlobal.HideSelection = false;
			lvGlobal.Items.AddRange(
				new ListViewItem[]
				{

						(ListViewItem)
							resources.GetObject("lvGlobal.Items")

					,
				}
			);
			lvGlobal.MultiSelect = false;
			lvGlobal.Name = "lvGlobal";
			lvGlobal.ShowGroups = false;
			lvGlobal.Sorting = SortOrder.Ascending;
			lvGlobal.UseCompatibleStateImageBehavior = false;
			lvGlobal.View = View.Details;
			lvGlobal.DoubleClick += new EventHandler(
				listView_DoubleClick
			);
			lvGlobal.ColumnClick +=
				new ColumnClickEventHandler(
					listView_ColumnClick
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
			// tpGroup
			//
			tpGroup.Controls.Add(lvGroup);
			resources.ApplyResources(tpGroup, "tpGroup");
			tpGroup.Name = "tpGroup";
			//
			// lvGroup
			//
			lvGroup.Columns.AddRange(
				new ColumnHeader[]
				{
					columnHeader3,
					columnHeader4,
				}
			);
			resources.ApplyResources(lvGroup, "lvGroup");
			lvGroup.FullRowSelect = true;
			lvGroup.HideSelection = false;
			lvGroup.Items.AddRange(
				new ListViewItem[]
				{

						(ListViewItem)
							resources.GetObject("lvGroup.Items")

					,
				}
			);
			lvGroup.MultiSelect = false;
			lvGroup.Name = "lvGroup";
			lvGroup.ShowGroups = false;
			lvGroup.Sorting = SortOrder.Ascending;
			lvGroup.UseCompatibleStateImageBehavior = false;
			lvGroup.View = View.Details;
			lvGroup.DoubleClick += new EventHandler(
				listView_DoubleClick
			);
			lvGroup.ColumnClick +=
				new ColumnClickEventHandler(
					listView_ColumnClick
				);
			//
			// columnHeader3
			//
			resources.ApplyResources(columnHeader3, "columnHeader3");
			//
			// columnHeader4
			//
			resources.ApplyResources(columnHeader4, "columnHeader4");
			//
			// tpSemiGroup
			//
			tpSemiGroup.Controls.Add(lvSemi);
			resources.ApplyResources(tpSemiGroup, "tpSemiGroup");
			tpSemiGroup.Name = "tpSemiGroup";
			//
			// lvSemi
			//
			lvSemi.Columns.AddRange(
				new ColumnHeader[]
				{
					columnHeader5,
					columnHeader6,
				}
			);
			resources.ApplyResources(lvSemi, "lvSemi");
			lvSemi.FullRowSelect = true;
			lvSemi.HideSelection = false;
			lvSemi.Items.AddRange(
				new ListViewItem[]
				{

						(ListViewItem)
							resources.GetObject("lvSemi.Items")

					,
				}
			);
			lvSemi.MultiSelect = false;
			lvSemi.Name = "lvSemi";
			lvSemi.ShowGroups = false;
			lvSemi.Sorting = SortOrder.Ascending;
			lvSemi.UseCompatibleStateImageBehavior = false;
			lvSemi.View = View.Details;
			lvSemi.DoubleClick += new EventHandler(
				listView_DoubleClick
			);
			lvSemi.ColumnClick += new ColumnClickEventHandler(
				listView_ColumnClick
			);
			//
			// columnHeader5
			//
			resources.ApplyResources(columnHeader5, "columnHeader5");
			//
			// columnHeader6
			//
			resources.ApplyResources(columnHeader6, "columnHeader6");
			//
			// tpBuiltIn
			//
			tpBuiltIn.Controls.Add(lvPrim);
			resources.ApplyResources(tpBuiltIn, "tpBuiltIn");
			tpBuiltIn.Name = "tpBuiltIn";
			//
			// lvPrim
			//
			lvPrim.Columns.AddRange(
				new ColumnHeader[]
				{
					columnHeader7,
					columnHeader8,
				}
			);
			resources.ApplyResources(lvPrim, "lvPrim");
			lvPrim.FullRowSelect = true;
			lvPrim.HideSelection = false;
			lvPrim.Items.AddRange(
				new ListViewItem[]
				{

						(ListViewItem)
							resources.GetObject("lvPrim.Items")

					,
				}
			);
			lvPrim.MultiSelect = false;
			lvPrim.Name = "lvPrim";
			lvPrim.ShowGroups = false;
			lvPrim.UseCompatibleStateImageBehavior = false;
			lvPrim.View = View.Details;
			lvPrim.DoubleClick += new EventHandler(
				listView_DoubleClick
			);
			lvPrim.ColumnClick += new ColumnClickEventHandler(
				listView_ColumnClick
			);
			//
			// columnHeader7
			//
			resources.ApplyResources(columnHeader7, "columnHeader7");
			//
			// columnHeader8
			//
			resources.ApplyResources(columnHeader8, "columnHeader8");
			//
			// OK
			//
			resources.ApplyResources(OK, "OK");
			OK.DialogResult = DialogResult.OK;
			OK.Name = "OK";
			OK.Click += new EventHandler(OK_Click);
			//
			// Cancel
			//
			resources.ApplyResources(Cancel, "Cancel");
			Cancel.DialogResult = DialogResult.Cancel;
			Cancel.Name = "Cancel";
			//
			// btnViewBHAV
			//
			resources.ApplyResources(btnViewBHAV, "btnViewBHAV");
			btnViewBHAV.Name = "btnViewBHAV";
			btnViewBHAV.Click += new EventHandler(btnViewBHAV_Click);
			//
			// ResourceChooser
			//
			AcceptButton = OK;
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Dpi;
			CancelButton = Cancel;
			Controls.Add(btnViewBHAV);
			Controls.Add(Cancel);
			Controls.Add(OK);
			Controls.Add(tcResources);
			FormBorderStyle =
				FormBorderStyle
				.SizableToolWindow;
			Name = "ResourceChooser";
			ShowInTaskbar = false;
			tcResources.ResumeLayout(false);
			tpPackage.ResumeLayout(false);
			tpGlobalGroup.ResumeLayout(false);
			tpGroup.ResumeLayout(false);
			tpSemiGroup.ResumeLayout(false);
			tpBuiltIn.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion

		private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			ChooserOrder = e.Column;
			foreach (TabPage tp in tcResources.TabPages)
			{
				foreach (Control c in tp.Controls)
				{
					if (c is ListView)
					{
						((ListView)c).ListViewItemSorter = new ListViewItemComparer(
							e.Column
						);
					}
				}
			}
		}

		private void tcResources_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (btnViewBHAV.Visible)
			{
				btnViewBHAV.Enabled = tcResources.SelectedTab != tpBuiltIn;
			}
		}

		private void listView_DoubleClick(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			OK_Click(sender, e);
			Hide();
		}

		private void OK_Click(object sender, EventArgs ev)
		{
			ListView lv = getListView();

			if (lv != null && lv != lvPrim)
			{
				FileTable.Entry e = (FileTable.Entry)lv.SelectedItems[0].Tag;

				if (CanDoEA && e.Group != 0xffffff && !e.IsFixed)
				{
					foreach (
						FileTable.Entry f in FileTable.GFT[
							e.Type,
							e.Group,
							e.Instance,
							FileTable.Source.Fixed
						]
					)
					{
						if (f.IsFixed)
						{
							DialogResult dr = MessageBox.Show(
								Localization.GetString(
									"rc_override",
									e.Package.FileName
								),
								Localization.GetString("rc_overridesEA"),
								MessageBoxButtons.YesNoCancel,
								MessageBoxIcon.Question,
								MessageBoxDefaultButton.Button3
							);

							if (dr == DialogResult.Yes)
							{
							}
							else if (dr == DialogResult.No)
							{
								lv.SelectedItems[0].Tag = f;
							}
							else
							{
								DialogResult = DialogResult.Retry;
							}

							break;
						}
					}
				}
			}
		}

		private void btnViewBHAV_Click(object sender, EventArgs e)
		{
			ListView lv = getListView();
			if (lv == null)
			{
				return;
			}

			FileTable.Entry item = (FileTable.Entry)lv.SelectedItems[0].Tag;
			Bhav b = new Bhav();
			b.ProcessData(item.PFD, item.Package);

			SimPe.PackedFiles.UserInterface.BhavForm ui =
				(SimPe.PackedFiles.UserInterface.BhavForm)b.UIHandler;
			ui.Tag = "Popup"; // tells the SetReadOnly function it's in a popup - so everything locked down
			ui.Text =
				Localization.GetString("viewbhav")
				+ ": "
				+ b.FileName
				+ " ["
				+ b.Package.SaveFileName
				+ "]";
			b.RefreshUI();
			ui.Show();
		}
	}
}
