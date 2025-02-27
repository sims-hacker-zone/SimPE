using System;
using System.Collections;
using System.Windows.Forms;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for MemoryProperties.
	/// </summary>

	public class MemoryProperties : UserControl
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MemoryProperties()
		{
			try
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

				this.cbtype.Enum = typeof(SimMemoryType);
				this.cbtype.ResourceManager = SimPe.Localization.Manager;

				SetContent();
				this.Enabled = false;
				cbCtrl.Enabled = Helper.WindowsRegistry.HiddenMode;
			}
			catch { }
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
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(
					typeof(MemoryProperties)
				);
			this.pg = new PropertyGrid();
			this.tabControl2 = new TD.SandDock.TabControl();
			this.tabPage3 = new TD.SandDock.TabPage();
			this.panel2 = new Panel();
			this.pnObjectGuid = new Panel();
			this.cbSubjectObj = new PackedFiles.Wrapper.ObjectComboBox();
			this.label5 = new Label();
			this.pnSubject = new Panel();
			this.label4 = new Label();
			this.cbSubject = new PackedFiles.Wrapper.SimComboBox();
			this.llme2 = new LinkLabel();
			this.pnSub2 = new Panel();
			this.pnSub1 = new Panel();
			this.label6 = new Label();
			this.pnValue = new Panel();
			this.tbValue = new TextBox();
			this.label8 = new Label();
			this.pnInventory = new Panel();
			this.tbInv = new TextBox();
			this.label7 = new Label();
			this.pnOwner = new Panel();
			this.cbOwner = new PackedFiles.Wrapper.SimComboBox();
			this.llme = new LinkLabel();
			this.label3 = new Label();
			this.pnSelection = new Panel();
			this.lbtype = new Label();
			this.label2 = new Label();
			this.pb = new PictureBox();
			this.cbtype = new Ambertation.Windows.Forms.EnumComboBox();
			this.cbObjs = new PackedFiles.Wrapper.ObjectComboBox();
			this.cbToks = new PackedFiles.Wrapper.ObjectComboBox();
			this.cbMems = new PackedFiles.Wrapper.ObjectComboBox();
			this.pnListing = new Panel();
			this.rbObjs = new RadioButton();
			this.rbToks = new RadioButton();
			this.rbMems = new RadioButton();
			this.label10 = new Label();
			this.pnFlags = new Panel();
			this.cbVis = new CheckBox();
			this.cbCtrl = new CheckBox();
			this.tbFlag = new TextBox();
			this.label9 = new Label();
			this.panel3 = new Panel();
			this.tabPage4 = new TD.SandDock.TabPage();
			this.panel1 = new Panel();
			this.llSetRawLength = new LinkLabel();
			this.tbRawLength = new TextBox();
			this.label1 = new Label();
			this.label11 = new Label();
			this.tbUnk = new TextBox();
			this.tabControl2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.pnObjectGuid.SuspendLayout();
			this.pnSubject.SuspendLayout();
			this.pnSub1.SuspendLayout();
			this.pnValue.SuspendLayout();
			this.pnInventory.SuspendLayout();
			this.pnOwner.SuspendLayout();
			this.pnSelection.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
			this.pnListing.SuspendLayout();
			this.pnFlags.SuspendLayout();
			this.panel3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			//
			// pg
			//
			this.pg.CommandsBackColor = System.Drawing.SystemColors.ControlLight;
			resources.ApplyResources(this.pg, "pg");
			this.pg.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.pg.Name = "pg";
			this.pg.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
			this.pg.ToolbarVisible = false;
			this.pg.PropertyValueChanged +=
				new PropertyValueChangedEventHandler(
					this.pg_PropertyValueChanged
				);
			//
			// tabControl2
			//
			this.tabControl2.BorderStyle = TD.SandDock.Rendering.BorderStyle.None;
			this.tabControl2.Controls.Add(this.tabPage3);
			this.tabControl2.Controls.Add(this.tabPage4);
			resources.ApplyResources(this.tabControl2, "tabControl2");
			this.tabControl2.LayoutSystem = new TD.SandDock.SplitLayoutSystem(
				250,
				400,
				System.Windows.Forms.Orientation.Horizontal,
				new TD.SandDock.LayoutSystemBase[]
				{
					(
						(TD.SandDock.LayoutSystemBase)(
							new TD.SandDock.DocumentLayoutSystem(
								464,
								430,
								new TD.SandDock.DockControl[]
								{
									((TD.SandDock.DockControl)(this.tabPage3)),
									((TD.SandDock.DockControl)(this.tabPage4)),
								},
								this.tabPage3
							)
						)
					),
				}
			);
			this.tabControl2.Name = "tabControl2";
			//
			// tabPage3
			//
			resources.ApplyResources(this.tabPage3, "tabPage3");
			this.tabPage3.Controls.Add(this.panel3);
			this.tabPage3.Controls.Add(this.panel2);
			this.tabPage3.Controls.Add(this.pnValue);
			this.tabPage3.Controls.Add(this.pnInventory);
			this.tabPage3.Controls.Add(this.pnOwner);
			this.tabPage3.Controls.Add(this.pnSelection);
			this.tabPage3.Controls.Add(this.pnListing);
			this.tabPage3.Controls.Add(this.pnFlags);
			this.tabPage3.FloatingSize = new System.Drawing.Size(550, 400);
			this.tabPage3.Guid = new Guid(
				"4e851d66-304f-4d0f-9896-8d73154946f3"
			);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.VisibleChanged += new EventHandler(
				this.tabPage3_VisibleChanged
			);
			//
			// panel2
			//
			this.panel2.Controls.Add(this.pnObjectGuid);
			this.panel2.Controls.Add(this.pnSubject);
			this.panel2.Controls.Add(this.pnSub2);
			this.panel2.Controls.Add(this.pnSub1);
			resources.ApplyResources(this.panel2, "panel2");
			this.panel2.Name = "panel2";
			//
			// pnObjectGuid
			//
			this.pnObjectGuid.Controls.Add(this.cbSubjectObj);
			this.pnObjectGuid.Controls.Add(this.label5);
			resources.ApplyResources(this.pnObjectGuid, "pnObjectGuid");
			this.pnObjectGuid.Name = "pnObjectGuid";
			//
			// cbSubjectObj
			//
			resources.ApplyResources(this.cbSubjectObj, "cbSubjectObj");
			this.cbSubjectObj.Name = "cbSubjectObj";
			this.cbSubjectObj.SelectedGuid = ((uint)(4294967295u));
			this.cbSubjectObj.SelectedItem = null;
			this.cbSubjectObj.ShowAspiration = true;
			this.cbSubjectObj.ShowBadge = true;
			this.cbSubjectObj.ShowInventory = true;
			this.cbSubjectObj.ShowJobData = true;
			this.cbSubjectObj.ShowMemories = true;
			this.cbSubjectObj.ShowSkill = true;
			this.cbSubjectObj.ShowTokens = false;
			this.cbSubjectObj.SelectedObjectChanged += new EventHandler(
				this.cbSubjectObj_SelectedObjectChanged
			);
			//
			// label5
			//
			resources.ApplyResources(this.label5, "label5");
			this.label5.Name = "label5";
			//
			// pnSubject
			//
			this.pnSubject.Controls.Add(this.label4);
			this.pnSubject.Controls.Add(this.cbSubject);
			this.pnSubject.Controls.Add(this.llme2);
			resources.ApplyResources(this.pnSubject, "pnSubject");
			this.pnSubject.Name = "pnSubject";
			//
			// label4
			//
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			//
			// cbSubject
			//
			resources.ApplyResources(this.cbSubject, "cbSubject");
			this.cbSubject.Name = "cbSubject";
			this.cbSubject.SelectedSim = null;
			this.cbSubject.SelectedSimId = ((uint)(4294967295u));
			this.cbSubject.SelectedSimInstance = ((ushort)(65535));
			this.cbSubject.SelectedSimChanged += new EventHandler(
				this.cbSubject_SelectedSimChanged
			);
			//
			// llme2
			//
			resources.ApplyResources(this.llme2, "llme2");
			this.llme2.Name = "llme2";
			this.llme2.TabStop = true;
			this.llme2.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					this.linkLabel1_LinkClicked
				);
			//
			// pnSub2
			//
			resources.ApplyResources(this.pnSub2, "pnSub2");
			this.pnSub2.Name = "pnSub2";
			//
			// pnSub1
			//
			this.pnSub1.Controls.Add(this.label6);
			resources.ApplyResources(this.pnSub1, "pnSub1");
			this.pnSub1.Name = "pnSub1";
			//
			// label6
			//
			resources.ApplyResources(this.label6, "label6");
			this.label6.Name = "label6";
			//
			// pnValue
			//
			this.pnValue.Controls.Add(this.tbValue);
			this.pnValue.Controls.Add(this.label8);
			resources.ApplyResources(this.pnValue, "pnValue");
			this.pnValue.Name = "pnValue";
			//
			// tbValue
			//
			resources.ApplyResources(this.tbValue, "tbValue");
			this.tbValue.Name = "tbValue";
			this.tbValue.TextChanged += new EventHandler(
				this.tbValue_TextChanged
			);
			//
			// label8
			//
			resources.ApplyResources(this.label8, "label8");
			this.label8.Name = "label8";
			//
			// pnInventory
			//
			this.pnInventory.Controls.Add(this.tbInv);
			this.pnInventory.Controls.Add(this.label7);
			resources.ApplyResources(this.pnInventory, "pnInventory");
			this.pnInventory.Name = "pnInventory";
			//
			// tbInv
			//
			resources.ApplyResources(this.tbInv, "tbInv");
			this.tbInv.Name = "tbInv";
			this.tbInv.TextChanged += new EventHandler(this.tbInv_TextChanged);
			//
			// label7
			//
			resources.ApplyResources(this.label7, "label7");
			this.label7.Name = "label7";
			//
			// pnOwner
			//
			this.pnOwner.Controls.Add(this.cbOwner);
			this.pnOwner.Controls.Add(this.llme);
			this.pnOwner.Controls.Add(this.label3);
			resources.ApplyResources(this.pnOwner, "pnOwner");
			this.pnOwner.Name = "pnOwner";
			//
			// cbOwner
			//
			resources.ApplyResources(this.cbOwner, "cbOwner");
			this.cbOwner.Name = "cbOwner";
			this.cbOwner.SelectedSim = null;
			this.cbOwner.SelectedSimId = ((uint)(4294967295u));
			this.cbOwner.SelectedSimInstance = ((ushort)(65535));
			this.cbOwner.SelectedSimChanged += new EventHandler(
				this.cbOwner_SelectedSimChanged
			);
			//
			// llme
			//
			resources.ApplyResources(this.llme, "llme");
			this.llme.Name = "llme";
			this.llme.TabStop = true;
			this.llme.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					this.llme_LinkClicked
				);
			//
			// label3
			//
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			//
			// pnSelection
			//
			this.pnSelection.Controls.Add(this.lbtype);
			this.pnSelection.Controls.Add(this.label2);
			this.pnSelection.Controls.Add(this.pb);
			this.pnSelection.Controls.Add(this.cbtype);
			this.pnSelection.Controls.Add(this.cbObjs);
			this.pnSelection.Controls.Add(this.cbToks);
			this.pnSelection.Controls.Add(this.cbMems);
			resources.ApplyResources(this.pnSelection, "pnSelection");
			this.pnSelection.Name = "pnSelection";
			//
			// lbtype
			//
			resources.ApplyResources(this.lbtype, "lbtype");
			this.lbtype.Name = "lbtype";
			//
			// label2
			//
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			//
			// pb
			//
			resources.ApplyResources(this.pb, "pb");
			this.pb.Name = "pb";
			this.pb.TabStop = false;
			//
			// cbtype
			//
			resources.ApplyResources(this.cbtype, "cbtype");
			this.cbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbtype.Enum = null;
			this.cbtype.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cbtype.Name = "cbtype";
			this.cbtype.ResourceManager = null;
			this.cbtype.SelectedIndexChanged += new EventHandler(
				this.cbtype_SelectedIndexChanged
			);
			//
			// cbObjs
			//
			resources.ApplyResources(this.cbObjs, "cbObjs");
			this.cbObjs.Name = "cbObjs";
			this.cbObjs.SelectedGuid = ((uint)(4294967295u));
			this.cbObjs.SelectedItem = null;
			this.cbObjs.ShowAspiration = false;
			this.cbObjs.ShowBadge = false;
			this.cbObjs.ShowInventory = true;
			this.cbObjs.ShowJobData = false;
			this.cbObjs.ShowMemories = false;
			this.cbObjs.ShowSkill = false;
			this.cbObjs.ShowTokens = false;
			this.cbObjs.SelectedObjectChanged += new EventHandler(
				this.ChangeGuid
			);
			//
			// cbToks
			//
			resources.ApplyResources(this.cbToks, "cbToks");
			this.cbToks.Name = "cbToks";
			this.cbToks.SelectedGuid = ((uint)(4294967295u));
			this.cbToks.SelectedItem = null;
			this.cbToks.ShowAspiration = false;
			this.cbToks.ShowBadge = false;
			this.cbToks.ShowInventory = false;
			this.cbToks.ShowJobData = false;
			this.cbToks.ShowMemories = false;
			this.cbToks.ShowSkill = false;
			this.cbToks.ShowTokens = true;
			this.cbToks.SelectedObjectChanged += new EventHandler(
				this.ChangeGuid
			);
			//
			// cbMems
			//
			resources.ApplyResources(this.cbMems, "cbMems");
			this.cbMems.Name = "cbMems";
			this.cbMems.SelectedGuid = ((uint)(4294967295u));
			this.cbMems.SelectedItem = null;
			this.cbMems.ShowAspiration = false;
			this.cbMems.ShowBadge = false;
			this.cbMems.ShowInventory = false;
			this.cbMems.ShowJobData = false;
			this.cbMems.ShowMemories = true;
			this.cbMems.ShowSkill = false;
			this.cbMems.ShowTokens = false;
			this.cbMems.SelectedObjectChanged += new EventHandler(
				this.ChangeGuid
			);
			//
			// pnListing
			//
			this.pnListing.Controls.Add(this.rbObjs);
			this.pnListing.Controls.Add(this.rbToks);
			this.pnListing.Controls.Add(this.rbMems);
			this.pnListing.Controls.Add(this.label10);
			resources.ApplyResources(this.pnListing, "pnListing");
			this.pnListing.Name = "pnListing";
			//
			// rbObjs
			//
			resources.ApplyResources(this.rbObjs, "rbObjs");
			this.rbObjs.Name = "rbObjs";
			this.rbObjs.CheckedChanged += new EventHandler(
				this.rbObjs_CheckedChanged
			);
			//
			// rbToks
			//
			resources.ApplyResources(this.rbToks, "rbToks");
			this.rbToks.Name = "rbToks";
			this.rbToks.CheckedChanged += new EventHandler(
				this.rbToks_CheckedChanged
			);
			//
			// rbMems
			//
			resources.ApplyResources(this.rbMems, "rbMems");
			this.rbMems.Name = "rbMems";
			this.rbMems.CheckedChanged += new EventHandler(
				this.rbMems_CheckedChanged
			);
			//
			// label10
			//
			resources.ApplyResources(this.label10, "label10");
			this.label10.Name = "label10";
			//
			// pnFlags
			//
			this.pnFlags.Controls.Add(this.cbVis);
			this.pnFlags.Controls.Add(this.cbCtrl);
			this.pnFlags.Controls.Add(this.tbFlag);
			this.pnFlags.Controls.Add(this.label9);
			resources.ApplyResources(this.pnFlags, "pnFlags");
			this.pnFlags.Name = "pnFlags";
			//
			// cbVis
			//
			resources.ApplyResources(this.cbVis, "cbVis");
			this.cbVis.Name = "cbVis";
			this.cbVis.CheckedChanged += new EventHandler(
				this.cbVis_CheckedChanged
			);
			//
			// cbCtrl
			//
			resources.ApplyResources(this.cbCtrl, "cbCtrl");
			this.cbCtrl.Name = "cbCtrl";
			this.cbCtrl.CheckedChanged += new EventHandler(
				this.cbAct_CheckedChanged
			);
			//
			// tbFlag
			//
			resources.ApplyResources(this.tbFlag, "tbFlag");
			this.tbFlag.Name = "tbFlag";
			this.tbFlag.ReadOnly = true;
			this.tbFlag.TextChanged += new EventHandler(this.tbFlag_TextChanged);
			//
			// label9
			//
			resources.ApplyResources(this.label9, "label9");
			this.label9.Name = "label9";
			//
			// panel3
			//
			this.panel3.Controls.Add(this.tbUnk);
			this.panel3.Controls.Add(this.label11);
			resources.ApplyResources(this.panel3, "panel3");
			this.panel3.Name = "panel3";
			//
			// tabPage4
			//
			this.tabPage4.BackColor = System.Drawing.SystemColors.ControlLight;
			this.tabPage4.Controls.Add(this.pg);
			this.tabPage4.Controls.Add(this.panel1);
			this.tabPage4.FloatingSize = new System.Drawing.Size(550, 400);
			this.tabPage4.Guid = new Guid(
				"3b0d25ef-e354-4693-8339-f171a2b4f000"
			);
			resources.ApplyResources(this.tabPage4, "tabPage4");
			this.tabPage4.Name = "tabPage4";
			//
			// panel1
			//
			this.panel1.Controls.Add(this.llSetRawLength);
			this.panel1.Controls.Add(this.tbRawLength);
			this.panel1.Controls.Add(this.label1);
			resources.ApplyResources(this.panel1, "panel1");
			this.panel1.Name = "panel1";
			//
			// llSetRawLength
			//
			resources.ApplyResources(this.llSetRawLength, "llSetRawLength");
			this.llSetRawLength.Name = "llSetRawLength";
			this.llSetRawLength.TabStop = true;
			this.llSetRawLength.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					this.llSetRawLength_LinkClicked
				);
			//
			// tbRawLength
			//
			resources.ApplyResources(this.tbRawLength, "tbRawLength");
			this.tbRawLength.Name = "tbRawLength";
			//
			// label1
			//
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			//
			// label11
			//
			resources.ApplyResources(this.label11, "label11");
			this.label11.Name = "label11";
			//
			// tbUnk
			//
			resources.ApplyResources(this.tbUnk, "tbUnk");
			this.tbUnk.Name = "tbUnk";
			this.tbUnk.ReadOnly = true;
			//
			// MemoryProperties
			//
			this.Controls.Add(this.tabControl2);
			resources.ApplyResources(this, "$this");
			this.Name = "MemoryProperties";
			this.tabControl2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.pnObjectGuid.ResumeLayout(false);
			this.pnSubject.ResumeLayout(false);
			this.pnSub1.ResumeLayout(false);
			this.pnValue.ResumeLayout(false);
			this.pnValue.PerformLayout();
			this.pnInventory.ResumeLayout(false);
			this.pnInventory.PerformLayout();
			this.pnOwner.ResumeLayout(false);
			this.pnSelection.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
			this.pnListing.ResumeLayout(false);
			this.pnFlags.ResumeLayout(false);
			this.pnFlags.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.tabPage4.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
		}
		#endregion


		NgbhItem item;
		private PropertyGrid pg;
		private TD.SandDock.TabControl tabControl2;
		private TD.SandDock.TabPage tabPage3;
		private TD.SandDock.TabPage tabPage4;
		private TextBox tbRawLength;
		private Label label1;
		private Panel panel1;
		private LinkLabel llSetRawLength;
		private Label lbtype;
		private Ambertation.Windows.Forms.EnumComboBox cbtype;
		private PackedFiles.Wrapper.ObjectComboBox cbMems;
		private PackedFiles.Wrapper.ObjectComboBox cbToks;
		private Label label2;
		private PackedFiles.Wrapper.ObjectComboBox cbObjs;
		private PictureBox pb;
		private Panel pnSelection;
		private Panel pnOwner;
		private Label label3;
		private LinkLabel llme;
		PackedFiles.Wrapper.SimComboBox cbOwner;
		private Label label4;
		private Panel pnSubject;
		private PackedFiles.Wrapper.SimComboBox cbSubject;
		private PackedFiles.Wrapper.ObjectComboBox cbSubjectObj;
		private Panel pnObjectGuid;
		private Label label5;
		private LinkLabel llme2;
		private Panel panel2;
		private Panel pnSub2;
		private Panel pnSub1;
		private Label label6;
		private Panel pnInventory;
		private Label label7;
		private TextBox tbInv;
		private Panel pnValue;
		private TextBox tbValue;
		private Label label8;
		private Panel pnFlags;
		private Label label9;
		private CheckBox cbVis;
		private TextBox tbFlag;
		private CheckBox cbCtrl;
		private Panel pnListing;
		private Label label10;
		private RadioButton rbMems;
		private RadioButton rbToks;
		private RadioButton rbObjs;
		private Panel panel3;
		private TextBox tbUnk;
		private Label label11;

		[System.ComponentModel.Browsable(false)]
		public NgbhItem Item
		{
			get
			{
				return item;
			}
			set
			{
				item = value;
				SetContent();
			}
		}

		NgbhItemsListView nilv;
		public NgbhItemsListView NgbhItemsListView
		{
			get
			{
				return nilv;
			}
			set
			{
				if (nilv != null)
				{
					nilv.SelectedIndexChanged -= new EventHandler(
						nilv_SelectedIndexChanged
					);
				}

				nilv = value;
				if (nilv != null)
				{
					nilv.SelectedIndexChanged += new EventHandler(
						nilv_SelectedIndexChanged
					);
				}

				nilv_SelectedIndexChanged(null, null);
			}
		}

		public event EventHandler ChangedItem;

		protected void UpdateNgbhItemsListView()
		{
			if (nilv != null)
			{
				nilv.UpdateSelected(item);
			}
		}

		protected void FireChangeEvent()
		{
			UpdateNgbhItemsListView();
			if (ChangedItem != null)
			{
				ChangedItem(this, new EventArgs());
			}
		}

		bool inter;
		bool chgraw;

		void SetContent()
		{
			if (inter)
			{
				return;
			}

			inter = true;
			chgraw = false;
			pg.SelectedObject = null;
			pb.Image = null;
			if (item != null)
			{
				this.Enabled = true;
				Hashtable ht = new Hashtable();
				byte ct = 0;
				foreach (string v in item.MemoryCacheItem.ValueNames)
				{
					ht[Helper.HexString(ct) + ": " + v] =
						new Ambertation.BaseChangeableNumber(item.GetValue(ct++));
				}

				while (ct < item.Data.Length)
				{
					ht[Helper.HexString(ct) + ":"] =
						new Ambertation.BaseChangeableNumber(item.GetValue(ct++));
				}

				Ambertation.PropertyObjectBuilderExt pob =
					new Ambertation.PropertyObjectBuilderExt(ht);

				pg.SelectedObject = pob.Instance;

				this.tbRawLength.Text = item.Data.Length.ToString();
				this.cbtype.SelectedValue = item.MemoryType;

				UpdateSelectedItem();

				pb.Image = item.MemoryCacheItem.Image;

				SelectOwner(this.cbOwner, item);
				SelectSubject(item);

				tbInv.Text = item.InventoryNumber.ToString();
				this.tbValue.Text = item.Value.ToString();
				tbUnk.Text = SimPe.Helper.HexString(item.UnknownNumber);
				UpdateFlagsValue();
			}
			else
			{
				this.Enabled = false;
			}
			inter = false;
		}

		void UpdateFlagsValue()
		{
			this.tbFlag.Text = "0x" + Helper.HexString(item.Flags.Value);
		}

		void UpdateSelectedItem()
		{
			bool use = (
				!item.MemoryCacheItem.IsToken && !item.MemoryCacheItem.IsInventory
			);
			this.cbMems.Visible = use;
			this.rbMems.Checked = use;
			if (use)
			{
				SelectNgbhItem(cbMems, item);
			}

			use = item.MemoryCacheItem.IsToken && !item.MemoryCacheItem.IsInventory;
			this.cbToks.Visible = use;
			this.rbToks.Checked = use;
			if (use)
			{
				SelectNgbhItem(cbToks, item);
			}

			use = (!item.MemoryCacheItem.IsToken && item.MemoryCacheItem.IsInventory);
			this.cbObjs.Visible = use;
			this.rbObjs.Checked = use;
			if (use)
			{
				SelectNgbhItem(cbObjs, item);
			}
		}

		void SelectNgbhItem(PackedFiles.Wrapper.ObjectComboBox cb, NgbhItem item)
		{
			cb.SelectedGuid = item.Guid;
		}

		void SelectOwner(PackedFiles.Wrapper.SimComboBox cb, NgbhItem item)
		{
			cb.SelectedSimInstance = item.OwnerInstance;
		}

		void SelectSubject(NgbhItem item)
		{
			this.cbSubject.SelectedSimId = item.SubjectGuid;
			if (item.MemoryType == SimMemoryType.Object)
			{
				this.cbSubjectObj.SelectedGuid = item.ReferencedObjectGuid;
			}
			else
			{
				this.cbSubjectObj.SelectedGuid = item.SubjectGuid;
			}
		}

		private void nilv_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (nilv != null)
			{
				NgbhItemsListViewItem lvi = nilv.SelectedItem;
				if (lvi != null && !nilv.SelectedMultiple)
				{
					Item = lvi.Item;
				}
				else
				{
					Item = null;
				}
			}
			else
			{
				Item = null;
			}
		}

		private void llSetRawLength_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (this.item != null)
			{
				ushort[] ndata = new ushort[
					Helper.StringToInt32(this.tbRawLength.Text, item.Data.Length, 10)
				];
				for (int i = 0; i < ndata.Length; i++)
				{
					if (i < item.Data.Length)
					{
						ndata[i] = item.Data[i];
					}
					else
					{
						ndata[i] = 0;
					}
				}

				item.Data = ndata;
				SetContent();
			}
		}

		private void ChangeGuid(object sender, EventArgs e)
		{
			if (inter)
			{
				return;
			}

			if (item == null)
			{
				return;
			}

			PackedFiles.Wrapper.ObjectComboBox cb =
				sender as PackedFiles.Wrapper.ObjectComboBox;
			item.Guid = cb.SelectedGuid;
			SetContent();
			this.FireChangeEvent();
		}

		private void pg_PropertyValueChanged(
			object s,
			PropertyValueChangedEventArgs e
		)
		{
			if (item == null)
			{
				return;
			}

			string[] n = e.ChangedItem.Label.Split(new char[] { ':' }, 2);
			if (n.Length > 0)
			{
				int v = Helper.StringToInt32(n[0], -1, 16);
				if (v >= 0)
				{
					item.PutValue(
						v,
						(ushort)
							(
								(Ambertation.BaseChangeableNumber)e.ChangedItem.Value
							).Value
					);
					chgraw = true;
					UpdateNgbhItemsListView();
				}
			}
		}

		private void tabPage3_VisibleChanged(object sender, EventArgs e)
		{
			if (this.tabPage3.Visible && chgraw)
			{
				SetContent();
			}
		}

		private void cbtype_SelectedIndexChanged(object sender, EventArgs e)
		{
			SimMemoryType smt = (SimMemoryType)cbtype.SelectedValue;

			this.pnOwner.Visible = (
				smt == SimMemoryType.Memory
				|| smt == SimMemoryType.Gossip
				|| smt == SimMemoryType.GossipInventory
			);
			this.pnSub1.Visible = (
				smt == SimMemoryType.Memory || smt == SimMemoryType.Gossip
			);
			this.pnSub2.Visible = this.pnSub1.Visible;
			this.pnSubject.Visible = (
				smt == SimMemoryType.Memory || smt == SimMemoryType.Gossip
			);
			this.pnObjectGuid.Visible = (
				smt == SimMemoryType.Memory
				|| smt == SimMemoryType.Gossip
				|| smt == SimMemoryType.Object
			);

			this.pnInventory.Visible = (
				smt == SimMemoryType.Inventory || smt == SimMemoryType.GossipInventory
			);
			this.pnValue.Visible = (
				smt == SimMemoryType.Skill
				|| smt == SimMemoryType.Badge
				|| smt == SimMemoryType.ValueToken
			);
			this.pnFlags.Visible = true;

			this.pnListing.Visible = Helper.WindowsRegistry.HiddenMode;
		}

		void SetMe(PackedFiles.Wrapper.SimComboBox cb)
		{
			if (item == null)
			{
				return;
			}

			cb.SelectedSimInstance = (ushort)item.ParentSlot.SlotID;
		}

		private void llme_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			SetMe(this.cbOwner);
		}

		private void linkLabel1_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			SetMe(this.cbSubject);
		}

		private void cbOwner_SelectedSimChanged(object sender, EventArgs e)
		{
			if (inter)
			{
				return;
			}

			if (item == null)
			{
				return;
			}

			item.OwnerInstance = cbOwner.SelectedSimInstance;

			SetContent();
			this.FireChangeEvent();
		}

		private void cbSubject_SelectedSimChanged(object sender, EventArgs e)
		{
			if (inter)
			{
				return;
			}

			if (item == null)
			{
				return;
			}

			inter = true;
			this.cbSubjectObj.SelectedGuid = 0xffffffff;
			item.SetSubject(
				this.cbSubject.SelectedSimInstance,
				this.cbSubject.SelectedSimId
			);
			inter = false;

			SetContent();
			this.FireChangeEvent();
		}

		private void cbSubjectObj_SelectedObjectChanged(
			object sender,
			EventArgs e
		)
		{
			if (inter)
			{
				return;
			}

			if (item == null)
			{
				return;
			}

			inter = true;

			this.cbSubject.SelectedSimId = 0xffffffff;
			if (item.MemoryType == SimMemoryType.Object)
			{
				item.ReferencedObjectGuid = this.cbSubjectObj.SelectedGuid;
			}
			else
			{
				item.SetSubject(0, this.cbSubjectObj.SelectedGuid);
			}

			inter = false;

			SetContent();
			this.FireChangeEvent();
		}

		private void tbInv_TextChanged(object sender, EventArgs e)
		{
			if (inter)
			{
				return;
			}

			if (item == null)
			{
				return;
			}

			item.InventoryNumber = Helper.StringToUInt32(
				this.tbInv.Text,
				item.InventoryNumber,
				10
			);
			SetContent();
			this.FireChangeEvent();
		}

		private void tbValue_TextChanged(object sender, EventArgs e)
		{
			if (inter)
			{
				return;
			}

			if (item == null)
			{
				return;
			}

			item.Value = Helper.StringToUInt16(this.tbValue.Text, item.Value, 10);
			this.FireChangeEvent();
		}

		private void tbFlag_TextChanged(object sender, EventArgs e)
		{
			if (item == null)
			{
				return;
			}

			this.cbCtrl.Checked = item.Flags.IsControler;
			this.cbVis.Checked = item.Flags.IsVisible;
		}

		private void cbVis_CheckedChanged(object sender, EventArgs e)
		{
			if (inter)
			{
				return;
			}

			if (item == null)
			{
				return;
			}

			inter = true;
			item.Flags.IsVisible = this.cbVis.Checked;
			UpdateFlagsValue();
			inter = false;
			SetContent();
			this.FireChangeEvent();
		}

		private void cbAct_CheckedChanged(object sender, EventArgs e)
		{
			if (inter)
			{
				return;
			}

			if (item == null)
			{
				return;
			}

			inter = true;
			item.Flags.IsControler = this.cbCtrl.Checked;
			UpdateFlagsValue();
			inter = false;
			SetContent();
			this.FireChangeEvent();
		}

		private void rbObjs_CheckedChanged(object sender, EventArgs e)
		{
			if (inter)
			{
				return;
			}

			cbObjs.Visible = true;
			cbMems.Visible = false;
			cbToks.Visible = false;
		}

		private void rbMems_CheckedChanged(object sender, EventArgs e)
		{
			if (inter)
			{
				return;
			}

			cbObjs.Visible = false;
			cbMems.Visible = true;
			cbToks.Visible = false;
		}

		private void rbToks_CheckedChanged(object sender, EventArgs e)
		{
			if (inter)
			{
				return;
			}

			cbObjs.Visible = false;
			cbMems.Visible = false;
			cbToks.Visible = true;
		}
	}
}
