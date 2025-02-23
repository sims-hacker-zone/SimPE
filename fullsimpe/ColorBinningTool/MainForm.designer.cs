
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace SimPe.Plugin.UI
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            SimPe.Plugin.HairtoneSettings hairtoneSettings1 = new SimPe.Plugin.HairtoneSettings();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dlgOpenPackageFile = new System.Windows.Forms.OpenFileDialog();
            this.pbTexturePreview = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cbDeleter = new System.Windows.Forms.CheckBox();
            this.cbCompress = new System.Windows.Forms.CheckBox();
            this.llGuid = new System.Windows.Forms.LinkLabel();
            this.box = new SimPe.Plugin.GeneticCategorizer(this.components);
            this.meshTable = new SimPe.Plugin.MeshTable(this.components);
            this.dlgSavePackageFile = new System.Windows.Forms.SaveFileDialog();
            this.cmListActions = new System.Windows.Forms.ContextMenu();
            this.miOpenPackage = new System.Windows.Forms.MenuItem();
            this.miMoveTo = new System.Windows.Forms.MenuItem();
            this.miClear = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.miLoadMesh = new System.Windows.Forms.MenuItem();
            this.miApplyMesh = new System.Windows.Forms.MenuItem();
            this.cbEnablePreview = new System.Windows.Forms.CheckBox();
            this.lvTxmt = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.lvCresShpe = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.cmTxmtListActions = new System.Windows.Forms.ContextMenu();
            this.miMatUseBaseTxtr = new System.Windows.Forms.MenuItem();
            this.miMatCopyTxtrRef = new System.Windows.Forms.MenuItem();
            this.miMatUseTxtrRef = new System.Windows.Forms.MenuItem();
            this.cmMeshListActions = new System.Windows.Forms.ContextMenu();
            this.miCresAddToMeshList = new System.Windows.Forms.MenuItem();
            this.matPanel = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tcProperties = new System.Windows.Forms.TabControl();
            this.tpMaterials = new System.Windows.Forms.TabPage();
            this.tpMeshes = new System.Windows.Forms.TabPage();
            this.tpClothing = new SimPe.Plugin.UI.ClothingPreferences();
            this.tbHair = new SimPe.Plugin.UI.HairtonePreferences();
            this.tbPackage = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.tbFamGuid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.themepanel = new System.Windows.Forms.Panel();
            this.tbContainer = new System.Windows.Forms.ToolStripContainer();
            ((System.ComponentModel.ISupportInitialize)(this.pbTexturePreview)).BeginInit();
            this.matPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tcProperties.SuspendLayout();
            this.tpMaterials.SuspendLayout();
            this.tpMeshes.SuspendLayout();
            this.tbPackage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.themepanel.SuspendLayout();
            this.tbContainer.TopToolStripPanel.SuspendLayout();
            this.tbContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.ImageList = this.imageList1;
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Multiline = true;
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(704, 276);
            this.tcMain.TabIndex = 0;
            this.tcMain.SelectedIndexChanged += new System.EventHandler(this.tcMain_Selected);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1black.png");
            this.imageList1.Images.SetKeyName(1, "2brown.png");
            this.imageList1.Images.SetKeyName(2, "3blonde.png");
            this.imageList1.Images.SetKeyName(3, "4red.png");
            this.imageList1.Images.SetKeyName(4, "5grey.png");
            this.imageList1.Images.SetKeyName(5, "6Custom.png");
            this.imageList1.Images.SetKeyName(6, "7unbinned.png");
            // 
            // dlgOpenPackageFile
            // 
            this.dlgOpenPackageFile.DefaultExt = "*";
            this.dlgOpenPackageFile.Filter = "Package files (*.package)|*.package|Disabled package files (*.packagedisabled)|*." +
                "packagedisabled|All files (*.*)|*.*";
            this.dlgOpenPackageFile.FilterIndex = 3;
            this.dlgOpenPackageFile.Title = "Open package";
            this.dlgOpenPackageFile.FileOk += new System.ComponentModel.CancelEventHandler(this.dlgOpenPackageFile_FileOk);
            // 
            // pbTexturePreview
            // 
            this.pbTexturePreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbTexturePreview.BackColor = System.Drawing.Color.Transparent;
            this.pbTexturePreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbTexturePreview.Location = new System.Drawing.Point(5, 30);
            this.pbTexturePreview.Name = "pbTexturePreview";
            this.pbTexturePreview.Size = new System.Drawing.Size(164, 164);
            this.pbTexturePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTexturePreview.TabIndex = 2;
            this.pbTexturePreview.TabStop = false;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // cbDeleter
            // 
            this.cbDeleter.AutoSize = true;
            this.cbDeleter.Checked = true;
            this.cbDeleter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDeleter.Location = new System.Drawing.Point(273, 111);
            this.cbDeleter.Name = "cbDeleter";
            this.cbDeleter.Size = new System.Drawing.Size(204, 21);
            this.cbDeleter.TabIndex = 23;
            this.cbDeleter.Text = "Remove Unchecked Parts";
            this.toolTip1.SetToolTip(this.cbDeleter, "The Colour Binning Tool\r\ndeletes anything that\'s not\r\nChecked when this is set");
            this.cbDeleter.UseVisualStyleBackColor = true;
            // 
            // cbCompress
            // 
            this.cbCompress.AutoSize = true;
            this.cbCompress.Location = new System.Drawing.Point(273, 147);
            this.cbCompress.Name = "cbCompress";
            this.cbCompress.Size = new System.Drawing.Size(166, 21);
            this.cbCompress.TabIndex = 22;
            this.cbCompress.Text = "Compress Textures";
            this.toolTip1.SetToolTip(this.cbCompress, "It\'s better to crompress your file with\r\nThe Compressorizer if you have it.");
            this.cbCompress.UseVisualStyleBackColor = true;
            // 
            // llGuid
            // 
            this.llGuid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llGuid.AutoSize = true;
            this.llGuid.BackColor = System.Drawing.Color.Transparent;
            this.llGuid.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llGuid.Location = new System.Drawing.Point(25, 29);
            this.llGuid.Name = "llGuid";
            this.llGuid.Size = new System.Drawing.Size(34, 14);
            this.llGuid.TabIndex = 19;
            this.llGuid.TabStop = true;
            this.llGuid.Text = "Guid";
            this.llGuid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.llGuid, "If you have more than one hair file\r\nloaded this GUID will be applied to\r\nall of " +
                    "them so that they become tied\r\ntogether in game.");
            this.llGuid.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llGuid_LinkClicked);
            // 
            // box
            // 
            this.box.Settings = null;
            // 
            // dlgSavePackageFile
            // 
            this.dlgSavePackageFile.DefaultExt = "package";
            this.dlgSavePackageFile.Filter = "Package files (*.package)|*.package|All files (*.*)|*.*";
            this.dlgSavePackageFile.Title = "Save package";
            // 
            // cmListActions
            // 
            this.cmListActions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miOpenPackage,
            this.miMoveTo,
            this.miClear,
            this.menuItem3,
            this.miLoadMesh,
            this.miApplyMesh});
            // 
            // miOpenPackage
            // 
            this.miOpenPackage.Index = 0;
            this.miOpenPackage.Text = "Open Package...";
            this.miOpenPackage.Click += new System.EventHandler(this.Handle_OpenPackage_Command);
            // 
            // miMoveTo
            // 
            this.miMoveTo.Index = 1;
            this.miMoveTo.Text = "Move To";
            // 
            // miClear
            // 
            this.miClear.Index = 2;
            this.miClear.Text = "Clear";
            this.miClear.Click += new System.EventHandler(this.Handle_ClearPackage_Command);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 3;
            this.menuItem3.Text = "-";
            // 
            // miLoadMesh
            // 
            this.miLoadMesh.Index = 4;
            this.miLoadMesh.Text = "Load Mesh...";
            this.miLoadMesh.Click += new System.EventHandler(this.miLoadMesh_Click);
            // 
            // miApplyMesh
            // 
            this.miApplyMesh.Index = 5;
            this.miApplyMesh.Text = "Apply Mesh";
            this.miApplyMesh.Visible = false;
            // 
            // cbEnablePreview
            // 
            this.cbEnablePreview.AutoSize = true;
            this.cbEnablePreview.Checked = true;
            this.cbEnablePreview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEnablePreview.Location = new System.Drawing.Point(12, 4);
            this.cbEnablePreview.Name = "cbEnablePreview";
            this.cbEnablePreview.Size = new System.Drawing.Size(139, 21);
            this.cbEnablePreview.TabIndex = 5;
            this.cbEnablePreview.Text = "Texture Preview";
            this.cbEnablePreview.CheckedChanged += new System.EventHandler(this.cbEnablePreview_CheckedChanged);
            // 
            // lvTxmt
            // 
            this.lvTxmt.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvTxmt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTxmt.FullRowSelect = true;
            this.lvTxmt.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvTxmt.HideSelection = false;
            this.lvTxmt.Location = new System.Drawing.Point(0, 0);
            this.lvTxmt.Name = "lvTxmt";
            this.lvTxmt.Size = new System.Drawing.Size(515, 186);
            this.lvTxmt.TabIndex = 6;
            this.lvTxmt.UseCompatibleStateImageBehavior = false;
            this.lvTxmt.View = System.Windows.Forms.View.Details;
            this.lvTxmt.SelectedIndexChanged += new System.EventHandler(this.lvTxmt_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 280;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Texture Ref";
            this.columnHeader2.Width = 230;
            // 
            // lvCresShpe
            // 
            this.lvCresShpe.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvCresShpe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCresShpe.FullRowSelect = true;
            this.lvCresShpe.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvCresShpe.Location = new System.Drawing.Point(0, 0);
            this.lvCresShpe.Name = "lvCresShpe";
            this.lvCresShpe.Size = new System.Drawing.Size(515, 186);
            this.lvCresShpe.TabIndex = 7;
            this.lvCresShpe.UseCompatibleStateImageBehavior = false;
            this.lvCresShpe.View = System.Windows.Forms.View.Details;
            this.lvCresShpe.SelectedIndexChanged += new System.EventHandler(this.lvCresShpe_SelectedIndexChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            this.columnHeader3.Width = 235;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Group";
            this.columnHeader4.Width = 90;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Instance";
            this.columnHeader5.Width = 90;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "File";
            this.columnHeader6.Width = 235;
            // 
            // cmTxmtListActions
            // 
            this.cmTxmtListActions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miMatUseBaseTxtr,
            this.miMatCopyTxtrRef,
            this.miMatUseTxtrRef});
            // 
            // miMatUseBaseTxtr
            // 
            this.miMatUseBaseTxtr.Index = 0;
            this.miMatUseBaseTxtr.Text = "Use base texture";
            this.miMatUseBaseTxtr.Click += new System.EventHandler(this.miMatUseBaseTxtr_Click);
            // 
            // miMatCopyTxtrRef
            // 
            this.miMatCopyTxtrRef.Enabled = false;
            this.miMatCopyTxtrRef.Index = 1;
            this.miMatCopyTxtrRef.Text = "Copy texture reference";
            this.miMatCopyTxtrRef.Click += new System.EventHandler(this.miMatCopyTxtrRef_Click);
            // 
            // miMatUseTxtrRef
            // 
            this.miMatUseTxtrRef.Enabled = false;
            this.miMatUseTxtrRef.Index = 2;
            this.miMatUseTxtrRef.Text = "Use texture reference";
            this.miMatUseTxtrRef.Click += new System.EventHandler(this.miMatUseTxtrRef_Click);
            // 
            // cmMeshListActions
            // 
            this.cmMeshListActions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miCresAddToMeshList});
            // 
            // miCresAddToMeshList
            // 
            this.miCresAddToMeshList.Index = 0;
            this.miCresAddToMeshList.Text = "Add To Mesh List";
            this.miCresAddToMeshList.Click += new System.EventHandler(this.miCresAddToMeshList_Click);
            // 
            // matPanel
            // 
            this.matPanel.Controls.Add(this.splitter2);
            this.matPanel.Controls.Add(this.panel2);
            this.matPanel.Controls.Add(this.panel1);
            this.matPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.matPanel.Location = new System.Drawing.Point(0, 280);
            this.matPanel.Name = "matPanel";
            this.matPanel.Size = new System.Drawing.Size(704, 222);
            this.matPanel.TabIndex = 8;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(176, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(5, 222);
            this.splitter2.TabIndex = 10;
            this.splitter2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tcProperties);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(176, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(528, 222);
            this.panel2.TabIndex = 9;
            // 
            // tcProperties
            // 
            this.tcProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcProperties.Controls.Add(this.tpMaterials);
            this.tcProperties.Controls.Add(this.tpMeshes);
            this.tcProperties.Controls.Add(this.tpClothing);
            this.tcProperties.Controls.Add(this.tbHair);
            this.tcProperties.Controls.Add(this.tbPackage);
            this.tcProperties.Location = new System.Drawing.Point(5, 0);
            this.tcProperties.Name = "tcProperties";
            this.tcProperties.SelectedIndex = 0;
            this.tcProperties.Size = new System.Drawing.Size(523, 216);
            this.tcProperties.TabIndex = 0;
            // 
            // tpMaterials
            // 
            this.tpMaterials.Controls.Add(this.lvTxmt);
            this.tpMaterials.Location = new System.Drawing.Point(4, 26);
            this.tpMaterials.Name = "tpMaterials";
            this.tpMaterials.Size = new System.Drawing.Size(515, 186);
            this.tpMaterials.TabIndex = 0;
            this.tpMaterials.Text = "Materials";
            // 
            // tpMeshes
            // 
            this.tpMeshes.Controls.Add(this.lvCresShpe);
            this.tpMeshes.Location = new System.Drawing.Point(4, 26);
            this.tpMeshes.Name = "tpMeshes";
            this.tpMeshes.Size = new System.Drawing.Size(515, 186);
            this.tpMeshes.TabIndex = 1;
            this.tpMeshes.Text = "Meshes";
            // 
            // tpClothing
            // 
            this.tpClothing.Enabled = false;
            this.tpClothing.Location = new System.Drawing.Point(4, 26);
            this.tpClothing.Name = "tpClothing";
            this.tpClothing.Settings = null;
            this.tpClothing.Size = new System.Drawing.Size(515, 186);
            this.tpClothing.TabIndex = 2;
            this.tpClothing.Text = "Properties";
            this.tpClothing.SettingsChanged += new System.EventHandler(this.Handle_PropertiesTab_SettingsChanged);
            // 
            // tbHair
            // 
            this.tbHair.Location = new System.Drawing.Point(4, 26);
            this.tbHair.Name = "tbHair";
            this.tbHair.Padding = new System.Windows.Forms.Padding(3);
            hairtoneSettings1.CompressTextures = false;
            hairtoneSettings1.DefaultProxy = new System.Guid("00000000-0000-0000-0000-000000000000");
            hairtoneSettings1.Description = null;
            hairtoneSettings1.FamilyGuid = new System.Guid("00000000-0000-0000-0000-000000000000");
            hairtoneSettings1.KeepDisabledItems = true;
            this.tbHair.Settings = hairtoneSettings1;
            this.tbHair.Size = new System.Drawing.Size(515, 186);
            this.tbHair.TabIndex = 3;
            this.tbHair.Text = "Hair";
            this.tbHair.UseVisualStyleBackColor = true;
            // 
            // tbPackage
            // 
            this.tbPackage.Controls.Add(this.cbDeleter);
            this.tbPackage.Controls.Add(this.cbCompress);
            this.tbPackage.Controls.Add(this.label1);
            this.tbPackage.Controls.Add(this.numericUpDown1);
            this.tbPackage.Controls.Add(this.llGuid);
            this.tbPackage.Controls.Add(this.tbFamGuid);
            this.tbPackage.Controls.Add(this.label2);
            this.tbPackage.Controls.Add(this.tbDescription);
            this.tbPackage.Location = new System.Drawing.Point(4, 26);
            this.tbPackage.Name = "tbPackage";
            this.tbPackage.Padding = new System.Windows.Forms.Padding(3);
            this.tbPackage.Size = new System.Drawing.Size(515, 186);
            this.tbPackage.TabIndex = 4;
            this.tbPackage.Text = "Package";
            this.tbPackage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(25, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "Genetic Weight";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown1.DecimalPlaces = 2;
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numericUpDown1.Location = new System.Drawing.Point(146, 122);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(96, 24);
            this.numericUpDown1.TabIndex = 20;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // tbFamGuid
            // 
            this.tbFamGuid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFamGuid.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.tbFamGuid.Location = new System.Drawing.Point(74, 29);
            this.tbFamGuid.MaxLength = 36;
            this.tbFamGuid.Name = "tbFamGuid";
            this.tbFamGuid.Size = new System.Drawing.Size(312, 24);
            this.tbFamGuid.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(25, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Text";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbDescription
            // 
            this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescription.Location = new System.Drawing.Point(74, 69);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(312, 24);
            this.tbDescription.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbEnablePreview);
            this.panel1.Controls.Add(this.pbTexturePreview);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(176, 222);
            this.panel1.TabIndex = 8;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Window;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(704, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(143, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripMenuItem.Image")));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 276);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(704, 4);
            this.splitter1.TabIndex = 9;
            this.splitter1.TabStop = false;
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.tcMain);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(704, 276);
            this.mainPanel.TabIndex = 10;
            // 
            // themepanel
            // 
            this.themepanel.BackColor = System.Drawing.Color.Transparent;
            this.themepanel.Controls.Add(this.mainPanel);
            this.themepanel.Controls.Add(this.splitter1);
            this.themepanel.Controls.Add(this.matPanel);
            this.themepanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.themepanel.EndColour = System.Drawing.SystemColors.Control;
            this.themepanel.Font = new System.Drawing.Font("Verdana", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.themepanel.Location = new System.Drawing.Point(0, 24);
            this.themepanel.MiddleColour = System.Drawing.SystemColors.Control;
            this.themepanel.Name = "themepanel";
            this.themepanel.Size = new System.Drawing.Size(704, 502);
            this.themepanel.StartColour = System.Drawing.SystemColors.Control;
            this.themepanel.TabIndex = 7;
            // 
            // tbContainer
            // 
            this.tbContainer.BottomToolStripPanelVisible = false;
            // 
            // tbContainer.ContentPanel
            // 
            this.tbContainer.ContentPanel.Size = new System.Drawing.Size(704, 0);
            this.tbContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbContainer.LeftToolStripPanelVisible = false;
            this.tbContainer.Location = new System.Drawing.Point(0, 0);
            this.tbContainer.Name = "tbContainer";
            this.tbContainer.RightToolStripPanelVisible = false;
            this.tbContainer.Size = new System.Drawing.Size(704, 24);
            this.tbContainer.TabIndex = 8;
            this.tbContainer.Text = "toolStripContainer1";
            // 
            // tbContainer.TopToolStripPanel
            // 
            this.tbContainer.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(704, 526);
            this.Controls.Add(this.themepanel);
            this.Controls.Add(this.tbContainer);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Colour Binning Tool";
            this.Closed += new System.EventHandler(this.Handle_ResetSession_Command);
            ((System.ComponentModel.ISupportInitialize)(this.pbTexturePreview)).EndInit();
            this.matPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tcProperties.ResumeLayout(false);
            this.tpMaterials.ResumeLayout(false);
            this.tpMeshes.ResumeLayout(false);
            this.tbPackage.ResumeLayout(false);
            this.tbPackage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.themepanel.ResumeLayout(false);
            this.tbContainer.TopToolStripPanel.ResumeLayout(false);
            this.tbContainer.TopToolStripPanel.PerformLayout();
            this.tbContainer.ResumeLayout(false);
            this.tbContainer.PerformLayout();
            this.ResumeLayout(false);

		}

		private System.Windows.Forms.ListView lvTxmt;
		private System.Windows.Forms.ListView lvCresShpe;
		private System.Windows.Forms.ContextMenu cmTxmtListActions;
		private System.Windows.Forms.ContextMenu cmMeshListActions;
		private System.Windows.Forms.MenuItem miMoveTo;
		private System.Windows.Forms.MenuItem miMatUseBaseTxtr;
		private System.Windows.Forms.MenuItem miMatCopyTxtrRef;
		private System.Windows.Forms.MenuItem miMatUseTxtrRef;
		private System.Windows.Forms.MenuItem miCresAddToMeshList;
		private System.Windows.Forms.Panel matPanel;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel mainPanel;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.MenuItem miOpenPackage;
		private System.Windows.Forms.MenuItem miClear;
		private System.Windows.Forms.MenuItem miLoadMesh;
		private System.Windows.Forms.MenuItem miApplyMesh;
		private System.Windows.Forms.TabControl tcProperties;
		private System.Windows.Forms.TabPage tpMaterials;
		private System.Windows.Forms.TabPage tpMeshes;
		private ColumnHeader columnHeader1;
		private ColumnHeader columnHeader2;
		private ColumnHeader columnHeader3;
		private ColumnHeader columnHeader4;
		private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private System.Windows.Forms.Panel themepanel;

        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.OpenFileDialog dlgOpenPackageFile;
        private System.Windows.Forms.PictureBox pbTexturePreview;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.SaveFileDialog dlgSavePackageFile;
        private SimPe.Plugin.GeneticCategorizer box;
        private System.Windows.Forms.ContextMenu cmListActions;
        private System.Windows.Forms.CheckBox cbEnablePreview;
        private ClothingPreferences tpClothing;
        private MenuItem menuItem3;
        private MeshTable meshTable;

		#endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripContainer tbContainer;
        private HairtonePreferences tbHair;
        private System.Windows.Forms.TabPage tbPackage;
        private LinkLabel llGuid;
        private TextBox tbFamGuid;
        private Label label2;
        private TextBox tbDescription;
        private Label label1;
        private NumericUpDown numericUpDown1;
        private ImageList imageList1;
        private CheckBox cbDeleter;
        private CheckBox cbCompress;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
	}

}