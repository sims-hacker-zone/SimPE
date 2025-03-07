﻿namespace SimPe.Windows.Forms
{
    partial class ResourceListViewExt
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResourceListViewExt));
            this.clTName = new System.Windows.Forms.ColumnHeader();
            this.clType = new System.Windows.Forms.ColumnHeader();
            this.clGroup = new System.Windows.Forms.ColumnHeader();
            this.clInstHi = new System.Windows.Forms.ColumnHeader();
            this.clInst = new System.Windows.Forms.ColumnHeader();
            this.clOffset = new System.Windows.Forms.ColumnHeader();
            this.clSize = new System.Windows.Forms.ColumnHeader();
            this.lv = new SimPe.Windows.Forms.ListViewDoubleBuffered();
            this.SuspendLayout();
            // 
            // clTName
            // 
            resources.ApplyResources(this.clTName, "clTName");
            // 
            // clType
            // 
            resources.ApplyResources(this.clType, "clType");
            // 
            // clGroup
            // 
            resources.ApplyResources(this.clGroup, "clGroup");
            // 
            // clInstHi
            // 
            resources.ApplyResources(this.clInstHi, "clInstHi");
            // 
            // clInst
            // 
            resources.ApplyResources(this.clInst, "clInst");
            // 
            // clOffset
            // 
            resources.ApplyResources(this.clOffset, "clOffset");
            // 
            // clSize
            // 
            resources.ApplyResources(this.clSize, "clSize");
            // 
            // lv
            // 
            this.lv.AllowColumnReorder = true;
            this.lv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clTName,
            this.clType,
            this.clGroup,
            this.clInstHi,
            this.clInst,
            this.clOffset,
            this.clSize});
            resources.ApplyResources(this.lv, "lv");
            this.lv.FullRowSelect = true;
            this.lv.HideSelection = false;
            this.lv.Name = "lv";
            this.lv.ShowGroups = false;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.VirtualMode = true;
            this.lv.SearchForVirtualItem += new System.Windows.Forms.SearchForVirtualItemEventHandler(this.lv_SearchForVirtualItem);
            this.lv.VirtualItemsSelectionRangeChanged += new System.Windows.Forms.ListViewVirtualItemsSelectionRangeChangedEventHandler(this.lv_VirtualItemsSelectionRangeChanged);
            this.lv.SelectedIndexChanged += new System.EventHandler(this.lv_SelectedIndexChanged);
            this.lv.DoubleClick += new System.EventHandler(this.lv_DoubleClick);
            this.lv.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lv_MouseUp);
            this.lv.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_ColumnClick);
            this.lv.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lv_RetrieveVirtualItem);
            this.lv.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lv_KeyUp);
            this.lv.CacheVirtualItems += new System.Windows.Forms.CacheVirtualItemsEventHandler(this.lv_CacheVirtualItems);
            this.lv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lv_KeyDown);
            this.lv.Click += new System.EventHandler(this.lv_Click);
            // 
            // ResourceListViewExt
            // 
            this.Controls.Add(this.lv);
            resources.ApplyResources(this, "$this");
            this.Name = "ResourceListViewExt";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader clTName;
        private System.Windows.Forms.ColumnHeader clType;
        private System.Windows.Forms.ColumnHeader clGroup;
        private System.Windows.Forms.ColumnHeader clInstHi;
        private System.Windows.Forms.ColumnHeader clInst;
        private System.Windows.Forms.ColumnHeader clOffset;
        private System.Windows.Forms.ColumnHeader clSize;
        private ListViewDoubleBuffered lv;

    }
}
