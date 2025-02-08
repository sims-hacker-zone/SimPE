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
using System.Drawing;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using SimPe.Plugin;
using SimPe.Interfaces;
using SimPe.Interfaces.Files;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Wrapper;
using Bhav = SimPe.PackedFiles.Wrapper.Bhav;

namespace pjse
{
    /// <summary>
    /// Summary description for ResourceChooser.
    /// </summary>
    public class ResourceChooser : System.Windows.Forms.Form
    {
        #region Form variables

        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.TabControl tcResources;
        private System.Windows.Forms.TabPage tpBuiltIn;
        private System.Windows.Forms.TabPage tpGlobalGroup;
        private System.Windows.Forms.TabPage tpSemiGroup;
        private System.Windows.Forms.TabPage tpGroup;
        private System.Windows.Forms.TabPage tpPackage;
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
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }


        #region ResourceChooser

        const string BASENAME = "PJSE\\Bhav";
        private static int ChooserOrder
        {
            get
            {
                SimPe.XmlRegistryKey rkf = SimPe.Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey(BASENAME);
                object o = rkf.GetValue("chooserOrder", 0);
                return (int)Math.Max(Convert.ToUInt32(o), 1);
            }

            set
            {
                SimPe.XmlRegistryKey rkf = SimPe.Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey(BASENAME);
                rkf.SetValue("chooserOrder", value);
            }
        }

        private static Size ChooserSize
        {
            get
            {
                SimPe.XmlRegistryKey rkf = SimPe.Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey(BASENAME);
                ResourceChooser rc = new ResourceChooser();
                object w = rkf.GetValue("chooserSize.Width", rc.Size.Width);
                object h = rkf.GetValue("chooserSize.Height", rc.Size.Height);
                return new Size(Convert.ToInt32(w), Convert.ToInt32(h));
            }

            set
            {
                SimPe.XmlRegistryKey rkf = SimPe.Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey(BASENAME);
                rkf.SetValue("chooserSize.Width", value.Width);
                rkf.SetValue("chooserSize.Height", value.Height);
            }
        }

        private class ListViewItemComparer : IComparer
        {
            private int col;
            public ListViewItemComparer() { col = ChooserOrder; }
            public ListViewItemComparer(int column) { col = column; }
            public int Compare(object x, object y) { return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text); }
        }

        private bool CanDoEA;

        public static int PersistentTab
        {
            get
            {
                SimPe.XmlRegistryKey rkf = SimPe.Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey(BASENAME);
                object o = rkf.GetValue("rcPersistentTab", false);
                return Convert.ToInt32(o);
            }

            set
            {
                SimPe.XmlRegistryKey rkf = SimPe.Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey(BASENAME);
                rkf.SetValue("rcPersistentTab", value);
            }

        }

        private ListView getListView()
        {
            if (this.tcResources.SelectedTab == this.tpPackage && lvPackage.SelectedItems != null)
                return lvPackage;

            if (this.tcResources.SelectedTab == this.tpGroup && lvGroup.SelectedItems != null)
                return lvGroup;

            if (this.tcResources.SelectedTab == this.tpSemiGroup && lvSemi.SelectedItems != null)
                return lvSemi;

            if (this.tcResources.SelectedTab == this.tpGlobalGroup && lvGlobal.SelectedItems != null)
                return lvGlobal;

            if (this.tcResources.SelectedTab == this.tpBuiltIn && lvPrim.SelectedItems != null)
                return lvPrim;

            return null;
        }

        /// <summary>
        /// List available resources of a given type, allowing the user to select one.
        /// </summary>
        /// <param name="resourceType">Type of resource to list</param>
        /// <param name="group">Group number of "this" group</param>
        /// <param name="form">Parent form</param>
        /// <param name="canDoEA">Whether to differentiate overriding resources</param>
        /// <returns>The chosen resource entry</returns>
        public pjse.FileTable.Entry Execute(uint resourceType, uint group, Control form, bool canDoEA)
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
        public pjse.FileTable.Entry Execute(uint resourceType, uint group, Control form, bool canDoEA, Boolset skip_pages)
        {
            CanDoEA = canDoEA;

            form.Cursor = Cursors.WaitCursor;
            this.Cursor = Cursors.WaitCursor;

            List<TabPage> ltp = new List<TabPage>(new TabPage[] { tpPackage, tpGroup, tpSemiGroup, tpGlobalGroup, tpBuiltIn });

            btnViewBHAV.Visible = resourceType == SimPe.Data.MetaData.BHAV_FILE;

            this.tcResources.TabPages.Clear();

            // There doesn't appear to be a way to compare two paths and have the OS decide if they refer to the same object
            if (!skip_pages[0]
                && pjse.FileTable.GFT.CurrentPackage != null
                && pjse.FileTable.GFT.CurrentPackage.FileName != null
                && !pjse.FileTable.GFT.CurrentPackage.FileName.ToLower().EndsWith("objects.package"))
                FillPackage(resourceType, this.lvPackage, this.tpPackage);

            if (!skip_pages[1])
                FillGroup(resourceType, group, this.lvGroup, this.tpGroup);

            if (!skip_pages[2])
            {
                Glob g = pjse.BhavWiz.GlobByGroup(group);
                if (g != null)
                {
                    FillGroup(resourceType, g.SemiGlobalGroup, this.lvSemi, this.tpSemiGroup);
                    this.tpSemiGroup.Text = g.SemiGlobalName;
                }
            }

            if (!skip_pages[3] && group != (uint)Group.Global)
                FillGroup(resourceType, (uint)Group.Global, this.lvGlobal, this.tpGlobalGroup);

            if (!skip_pages[4] && resourceType == SimPe.Data.MetaData.BHAV_FILE)
                FillBuiltIn(resourceType, this.lvPrim, this.tpBuiltIn);

            if (this.tcResources.TabCount > 0)
            {
                if (tcResources.Contains(ltp[PersistentTab]))
                    tcResources.SelectTab(ltp[PersistentTab]);
                else
                    this.tcResources.SelectedIndex = 0;
            }

            form.Cursor = Cursors.Default;
            this.Cursor = Cursors.Default;
            this.Size = ChooserSize;

            DialogResult dr  = ShowDialog();
            while (dr == DialogResult.Retry)
                dr  = ShowDialog();

            ChooserSize = this.Size;
            PersistentTab = ltp.IndexOf(this.tcResources.SelectedTab);
            Close();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                ListView lv = getListView();

                if (lv != null)
                {
                    if (lv != lvPrim)
                        return (pjse.FileTable.Entry)lv.SelectedItems[0].Tag;
                    else
                    {
                        IPackedFileDescriptor pfd = new SimPe.Packages.PackedFileDescriptor();
                        pfd.Instance = (uint)lvPrim.SelectedItems[0].Tag;
                        return new pjse.FileTable.Entry(null, pfd, true, true);
                    }
                }
            }
            return null;
        }

        private void FillPackage(uint type, ListView list, TabPage tab)
        {
            Fill(pjse.FileTable.GFT[pjse.FileTable.GFT.CurrentPackage, type], list, tab);
        }

        private void FillGroup(uint type, uint group, ListView list, TabPage tab)
        {
            Fill(pjse.FileTable.GFT[type, group], list, tab);
        }

        private void Fill(pjse.FileTable.Entry[] items, ListView list, TabPage tab)
        {
            list.Items.Clear();
            ListViewItem lvi;

            foreach (pjse.FileTable.Entry item in items)
            {
                lvi = new ListViewItem(new string[] { "0x" + SimPe.Helper.HexString((ushort)item.Instance), item });
                lvi.Tag = item;
                list.Items.Add(lvi);
            }
            this.tcResources.TabPages.Add(tab);
            list.ListViewItemSorter = new ListViewItemComparer();
            if (list.Items.Count > 0)
                list.SelectedIndices.Add(0);
        }

        private void FillBuiltIn(uint type, ListView list, TabPage tab)
        {
            list.Items.Clear();
            ListViewItem lvi;

            uint i = 0;
            foreach (string s in BhavWiz.readStr(pjse.GS.BhavStr.Primitives))
            {
                if (!s.StartsWith("~"))
                {
                    lvi = new ListViewItem(new string[] { "0x" + SimPe.Helper.HexString((ushort)i), s });
                    lvi.Tag = i;
                    list.Items.Add(lvi);
                }
                i++;
            }

            this.tcResources.TabPages.Add(tab);
            list.ListViewItemSorter = new ListViewItemComparer();
            if (list.Items.Count > 0)
                list.SelectedIndices.Add(0);
        }

        #endregion

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResourceChooser));
            this.tcResources = new System.Windows.Forms.TabControl();
            this.tpPackage = new System.Windows.Forms.TabPage();
            this.lvPackage = new System.Windows.Forms.ListView();
            this.chValue = new System.Windows.Forms.ColumnHeader();
            this.chName = new System.Windows.Forms.ColumnHeader();
            this.tpGlobalGroup = new System.Windows.Forms.TabPage();
            this.lvGlobal = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.tpGroup = new System.Windows.Forms.TabPage();
            this.lvGroup = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.tpSemiGroup = new System.Windows.Forms.TabPage();
            this.lvSemi = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.tpBuiltIn = new System.Windows.Forms.TabPage();
            this.lvPrim = new System.Windows.Forms.ListView();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.btnViewBHAV = new System.Windows.Forms.Button();
            this.tcResources.SuspendLayout();
            this.tpPackage.SuspendLayout();
            this.tpGlobalGroup.SuspendLayout();
            this.tpGroup.SuspendLayout();
            this.tpSemiGroup.SuspendLayout();
            this.tpBuiltIn.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcResources
            // 
            resources.ApplyResources(this.tcResources, "tcResources");
            this.tcResources.Controls.Add(this.tpPackage);
            this.tcResources.Controls.Add(this.tpGlobalGroup);
            this.tcResources.Controls.Add(this.tpGroup);
            this.tcResources.Controls.Add(this.tpSemiGroup);
            this.tcResources.Controls.Add(this.tpBuiltIn);
            this.tcResources.Name = "tcResources";
            this.tcResources.SelectedIndex = 0;
            this.tcResources.SelectedIndexChanged += new System.EventHandler(this.tcResources_SelectedIndexChanged);
            // 
            // tpPackage
            // 
            this.tpPackage.Controls.Add(this.lvPackage);
            resources.ApplyResources(this.tpPackage, "tpPackage");
            this.tpPackage.Name = "tpPackage";
            // 
            // lvPackage
            // 
            this.lvPackage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chValue,
            this.chName});
            resources.ApplyResources(this.lvPackage, "lvPackage");
            this.lvPackage.FullRowSelect = true;
            this.lvPackage.HideSelection = false;
            this.lvPackage.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lvPackage.Items")))});
            this.lvPackage.MultiSelect = false;
            this.lvPackage.Name = "lvPackage";
            this.lvPackage.ShowGroups = false;
            this.lvPackage.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvPackage.UseCompatibleStateImageBehavior = false;
            this.lvPackage.View = System.Windows.Forms.View.Details;
            this.lvPackage.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            this.lvPackage.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            // 
            // chValue
            // 
            resources.ApplyResources(this.chValue, "chValue");
            // 
            // chName
            // 
            resources.ApplyResources(this.chName, "chName");
            // 
            // tpGlobalGroup
            // 
            this.tpGlobalGroup.Controls.Add(this.lvGlobal);
            resources.ApplyResources(this.tpGlobalGroup, "tpGlobalGroup");
            this.tpGlobalGroup.Name = "tpGlobalGroup";
            // 
            // lvGlobal
            // 
            this.lvGlobal.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            resources.ApplyResources(this.lvGlobal, "lvGlobal");
            this.lvGlobal.FullRowSelect = true;
            this.lvGlobal.HideSelection = false;
            this.lvGlobal.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lvGlobal.Items")))});
            this.lvGlobal.MultiSelect = false;
            this.lvGlobal.Name = "lvGlobal";
            this.lvGlobal.ShowGroups = false;
            this.lvGlobal.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvGlobal.UseCompatibleStateImageBehavior = false;
            this.lvGlobal.View = System.Windows.Forms.View.Details;
            this.lvGlobal.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            this.lvGlobal.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // tpGroup
            // 
            this.tpGroup.Controls.Add(this.lvGroup);
            resources.ApplyResources(this.tpGroup, "tpGroup");
            this.tpGroup.Name = "tpGroup";
            // 
            // lvGroup
            // 
            this.lvGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            resources.ApplyResources(this.lvGroup, "lvGroup");
            this.lvGroup.FullRowSelect = true;
            this.lvGroup.HideSelection = false;
            this.lvGroup.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lvGroup.Items")))});
            this.lvGroup.MultiSelect = false;
            this.lvGroup.Name = "lvGroup";
            this.lvGroup.ShowGroups = false;
            this.lvGroup.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvGroup.UseCompatibleStateImageBehavior = false;
            this.lvGroup.View = System.Windows.Forms.View.Details;
            this.lvGroup.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            this.lvGroup.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // columnHeader4
            // 
            resources.ApplyResources(this.columnHeader4, "columnHeader4");
            // 
            // tpSemiGroup
            // 
            this.tpSemiGroup.Controls.Add(this.lvSemi);
            resources.ApplyResources(this.tpSemiGroup, "tpSemiGroup");
            this.tpSemiGroup.Name = "tpSemiGroup";
            // 
            // lvSemi
            // 
            this.lvSemi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            resources.ApplyResources(this.lvSemi, "lvSemi");
            this.lvSemi.FullRowSelect = true;
            this.lvSemi.HideSelection = false;
            this.lvSemi.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lvSemi.Items")))});
            this.lvSemi.MultiSelect = false;
            this.lvSemi.Name = "lvSemi";
            this.lvSemi.ShowGroups = false;
            this.lvSemi.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvSemi.UseCompatibleStateImageBehavior = false;
            this.lvSemi.View = System.Windows.Forms.View.Details;
            this.lvSemi.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            this.lvSemi.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            // 
            // columnHeader5
            // 
            resources.ApplyResources(this.columnHeader5, "columnHeader5");
            // 
            // columnHeader6
            // 
            resources.ApplyResources(this.columnHeader6, "columnHeader6");
            // 
            // tpBuiltIn
            // 
            this.tpBuiltIn.Controls.Add(this.lvPrim);
            resources.ApplyResources(this.tpBuiltIn, "tpBuiltIn");
            this.tpBuiltIn.Name = "tpBuiltIn";
            // 
            // lvPrim
            // 
            this.lvPrim.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8});
            resources.ApplyResources(this.lvPrim, "lvPrim");
            this.lvPrim.FullRowSelect = true;
            this.lvPrim.HideSelection = false;
            this.lvPrim.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lvPrim.Items")))});
            this.lvPrim.MultiSelect = false;
            this.lvPrim.Name = "lvPrim";
            this.lvPrim.ShowGroups = false;
            this.lvPrim.UseCompatibleStateImageBehavior = false;
            this.lvPrim.View = System.Windows.Forms.View.Details;
            this.lvPrim.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            this.lvPrim.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            // 
            // columnHeader7
            // 
            resources.ApplyResources(this.columnHeader7, "columnHeader7");
            // 
            // columnHeader8
            // 
            resources.ApplyResources(this.columnHeader8, "columnHeader8");
            // 
            // OK
            // 
            resources.ApplyResources(this.OK, "OK");
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Name = "OK";
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            resources.ApplyResources(this.Cancel, "Cancel");
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Name = "Cancel";
            // 
            // btnViewBHAV
            // 
            resources.ApplyResources(this.btnViewBHAV, "btnViewBHAV");
            this.btnViewBHAV.Name = "btnViewBHAV";
            this.btnViewBHAV.Click += new System.EventHandler(this.btnViewBHAV_Click);
            // 
            // ResourceChooser
            // 
            this.AcceptButton = this.OK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.Cancel;
            this.Controls.Add(this.btnViewBHAV);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.tcResources);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ResourceChooser";
            this.ShowInTaskbar = false;
            this.tcResources.ResumeLayout(false);
            this.tpPackage.ResumeLayout(false);
            this.tpGlobalGroup.ResumeLayout(false);
            this.tpGroup.ResumeLayout(false);
            this.tpSemiGroup.ResumeLayout(false);
            this.tpBuiltIn.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ChooserOrder = e.Column;
            foreach (TabPage tp in tcResources.TabPages)
                foreach (Control c in tp.Controls)
                    if (c is ListView)
                        ((ListView)c).ListViewItemSorter = new ListViewItemComparer(e.Column);
        }

        private void tcResources_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btnViewBHAV.Visible)
                btnViewBHAV.Enabled = tcResources.SelectedTab != this.tpBuiltIn;
        }

        private void listView_DoubleClick(object sender, System.EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            OK_Click(sender, e);
            Hide();
        }

        private void OK_Click(object sender, EventArgs ev)
        {
            ListView lv = getListView();

            if (lv != null && lv != lvPrim)
            {
                pjse.FileTable.Entry e = (pjse.FileTable.Entry)lv.SelectedItems[0].Tag;

                if (CanDoEA && e.Group != 0xffffff && !e.IsFixed)
                    foreach (pjse.FileTable.Entry f in pjse.FileTable.GFT[e.Type, e.Group, e.Instance, FileTable.Source.Fixed])
                        if (f.IsFixed)
                        {
                            DialogResult dr = MessageBox.Show(
                                Localization.GetString("rc_override", e.Package.FileName),
                                Localization.GetString("rc_overridesEA"),
                                MessageBoxButtons.YesNoCancel,
                                MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button3
                            );

                            if (dr == DialogResult.Yes) { }
                            else if (dr == DialogResult.No) { lv.SelectedItems[0].Tag = f; }
                            else this.DialogResult = DialogResult.Retry;
                            break;
                        }
            }
        }

        private void btnViewBHAV_Click(object sender, EventArgs e)
        {
            ListView lv = getListView();
            if (lv == null) return;

            pjse.FileTable.Entry item = (pjse.FileTable.Entry)lv.SelectedItems[0].Tag;
            Bhav b = new Bhav();
            b.ProcessData(item.PFD, item.Package);

            SimPe.PackedFiles.UserInterface.BhavForm ui = (SimPe.PackedFiles.UserInterface.BhavForm)b.UIHandler;
            ui.Tag = "Popup"; // tells the SetReadOnly function it's in a popup - so everything locked down
            ui.Text = pjse.Localization.GetString("viewbhav") + ": " + b.FileName + " [" + b.Package.SaveFileName + "]";
            b.RefreshUI();
            ui.Show();
        }

    }

}
