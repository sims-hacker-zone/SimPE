// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

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

				cbtype.Enum = typeof(SimMemoryType);
				cbtype.ResourceManager = Localization.Manager;

				SetContent();
				Enabled = false;
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
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(
					typeof(MemoryProperties)
				);
			pg = new PropertyGrid();
			tabControl2 = new TD.SandDock.TabControl();
			tabPage3 = new TD.SandDock.TabPage();
			panel2 = new Panel();
			pnObjectGuid = new Panel();
			cbSubjectObj = new PackedFiles.Wrapper.ObjectComboBox();
			label5 = new Label();
			pnSubject = new Panel();
			label4 = new Label();
			cbSubject = new PackedFiles.Wrapper.SimComboBox();
			llme2 = new LinkLabel();
			pnSub2 = new Panel();
			pnSub1 = new Panel();
			label6 = new Label();
			pnValue = new Panel();
			tbValue = new TextBox();
			label8 = new Label();
			pnInventory = new Panel();
			tbInv = new TextBox();
			label7 = new Label();
			pnOwner = new Panel();
			cbOwner = new PackedFiles.Wrapper.SimComboBox();
			llme = new LinkLabel();
			label3 = new Label();
			pnSelection = new Panel();
			lbtype = new Label();
			label2 = new Label();
			pb = new PictureBox();
			cbtype = new Ambertation.Windows.Forms.EnumComboBox();
			cbObjs = new PackedFiles.Wrapper.ObjectComboBox();
			cbToks = new PackedFiles.Wrapper.ObjectComboBox();
			cbMems = new PackedFiles.Wrapper.ObjectComboBox();
			pnListing = new Panel();
			rbObjs = new RadioButton();
			rbToks = new RadioButton();
			rbMems = new RadioButton();
			label10 = new Label();
			pnFlags = new Panel();
			cbVis = new CheckBox();
			cbCtrl = new CheckBox();
			tbFlag = new TextBox();
			label9 = new Label();
			panel3 = new Panel();
			tabPage4 = new TD.SandDock.TabPage();
			panel1 = new Panel();
			llSetRawLength = new LinkLabel();
			tbRawLength = new TextBox();
			label1 = new Label();
			label11 = new Label();
			tbUnk = new TextBox();
			tabControl2.SuspendLayout();
			tabPage3.SuspendLayout();
			panel2.SuspendLayout();
			pnObjectGuid.SuspendLayout();
			pnSubject.SuspendLayout();
			pnSub1.SuspendLayout();
			pnValue.SuspendLayout();
			pnInventory.SuspendLayout();
			pnOwner.SuspendLayout();
			pnSelection.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pb).BeginInit();
			pnListing.SuspendLayout();
			pnFlags.SuspendLayout();
			panel3.SuspendLayout();
			tabPage4.SuspendLayout();
			panel1.SuspendLayout();
			SuspendLayout();
			//
			// pg
			//
			pg.CommandsBackColor = System.Drawing.SystemColors.ControlLight;
			resources.ApplyResources(pg, "pg");
			pg.LineColor = System.Drawing.SystemColors.ScrollBar;
			pg.Name = "pg";
			pg.PropertySort = PropertySort.Alphabetical;
			pg.ToolbarVisible = false;
			pg.PropertyValueChanged +=
				new PropertyValueChangedEventHandler(
					pg_PropertyValueChanged
				);
			//
			// tabControl2
			//
			tabControl2.BorderStyle = TD.SandDock.Rendering.BorderStyle.None;
			tabControl2.Controls.Add(tabPage3);
			tabControl2.Controls.Add(tabPage4);
			resources.ApplyResources(tabControl2, "tabControl2");
			tabControl2.LayoutSystem = new TD.SandDock.SplitLayoutSystem(
				250,
				400,
				Orientation.Horizontal,
				new TD.SandDock.LayoutSystemBase[]
				{


							new TD.SandDock.DocumentLayoutSystem(
								464,
								430,
								new TD.SandDock.DockControl[]
								{
									tabPage3,
									tabPage4,
								},
								tabPage3
							)

					,
				}
			);
			tabControl2.Name = "tabControl2";
			//
			// tabPage3
			//
			resources.ApplyResources(tabPage3, "tabPage3");
			tabPage3.Controls.Add(panel3);
			tabPage3.Controls.Add(panel2);
			tabPage3.Controls.Add(pnValue);
			tabPage3.Controls.Add(pnInventory);
			tabPage3.Controls.Add(pnOwner);
			tabPage3.Controls.Add(pnSelection);
			tabPage3.Controls.Add(pnListing);
			tabPage3.Controls.Add(pnFlags);
			tabPage3.FloatingSize = new System.Drawing.Size(550, 400);
			tabPage3.Guid = new Guid(
				"4e851d66-304f-4d0f-9896-8d73154946f3"
			);
			tabPage3.Name = "tabPage3";
			tabPage3.VisibleChanged += new EventHandler(
				tabPage3_VisibleChanged
			);
			//
			// panel2
			//
			panel2.Controls.Add(pnObjectGuid);
			panel2.Controls.Add(pnSubject);
			panel2.Controls.Add(pnSub2);
			panel2.Controls.Add(pnSub1);
			resources.ApplyResources(panel2, "panel2");
			panel2.Name = "panel2";
			//
			// pnObjectGuid
			//
			pnObjectGuid.Controls.Add(cbSubjectObj);
			pnObjectGuid.Controls.Add(label5);
			resources.ApplyResources(pnObjectGuid, "pnObjectGuid");
			pnObjectGuid.Name = "pnObjectGuid";
			//
			// cbSubjectObj
			//
			resources.ApplyResources(cbSubjectObj, "cbSubjectObj");
			cbSubjectObj.Name = "cbSubjectObj";
			cbSubjectObj.SelectedGuid = 4294967295u;
			cbSubjectObj.SelectedItem = null;
			cbSubjectObj.ShowAspiration = true;
			cbSubjectObj.ShowBadge = true;
			cbSubjectObj.ShowInventory = true;
			cbSubjectObj.ShowJobData = true;
			cbSubjectObj.ShowMemories = true;
			cbSubjectObj.ShowSkill = true;
			cbSubjectObj.ShowTokens = false;
			cbSubjectObj.SelectedObjectChanged += new EventHandler(
				cbSubjectObj_SelectedObjectChanged
			);
			//
			// label5
			//
			resources.ApplyResources(label5, "label5");
			label5.Name = "label5";
			//
			// pnSubject
			//
			pnSubject.Controls.Add(label4);
			pnSubject.Controls.Add(cbSubject);
			pnSubject.Controls.Add(llme2);
			resources.ApplyResources(pnSubject, "pnSubject");
			pnSubject.Name = "pnSubject";
			//
			// label4
			//
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			//
			// cbSubject
			//
			resources.ApplyResources(cbSubject, "cbSubject");
			cbSubject.Name = "cbSubject";
			cbSubject.SelectedSim = null;
			cbSubject.SelectedSimId = 4294967295u;
			cbSubject.SelectedSimInstance = 65535;
			cbSubject.SelectedSimChanged += new EventHandler(
				cbSubject_SelectedSimChanged
			);
			//
			// llme2
			//
			resources.ApplyResources(llme2, "llme2");
			llme2.Name = "llme2";
			llme2.TabStop = true;
			llme2.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					linkLabel1_LinkClicked
				);
			//
			// pnSub2
			//
			resources.ApplyResources(pnSub2, "pnSub2");
			pnSub2.Name = "pnSub2";
			//
			// pnSub1
			//
			pnSub1.Controls.Add(label6);
			resources.ApplyResources(pnSub1, "pnSub1");
			pnSub1.Name = "pnSub1";
			//
			// label6
			//
			resources.ApplyResources(label6, "label6");
			label6.Name = "label6";
			//
			// pnValue
			//
			pnValue.Controls.Add(tbValue);
			pnValue.Controls.Add(label8);
			resources.ApplyResources(pnValue, "pnValue");
			pnValue.Name = "pnValue";
			//
			// tbValue
			//
			resources.ApplyResources(tbValue, "tbValue");
			tbValue.Name = "tbValue";
			tbValue.TextChanged += new EventHandler(
				tbValue_TextChanged
			);
			//
			// label8
			//
			resources.ApplyResources(label8, "label8");
			label8.Name = "label8";
			//
			// pnInventory
			//
			pnInventory.Controls.Add(tbInv);
			pnInventory.Controls.Add(label7);
			resources.ApplyResources(pnInventory, "pnInventory");
			pnInventory.Name = "pnInventory";
			//
			// tbInv
			//
			resources.ApplyResources(tbInv, "tbInv");
			tbInv.Name = "tbInv";
			tbInv.TextChanged += new EventHandler(tbInv_TextChanged);
			//
			// label7
			//
			resources.ApplyResources(label7, "label7");
			label7.Name = "label7";
			//
			// pnOwner
			//
			pnOwner.Controls.Add(cbOwner);
			pnOwner.Controls.Add(llme);
			pnOwner.Controls.Add(label3);
			resources.ApplyResources(pnOwner, "pnOwner");
			pnOwner.Name = "pnOwner";
			//
			// cbOwner
			//
			resources.ApplyResources(cbOwner, "cbOwner");
			cbOwner.Name = "cbOwner";
			cbOwner.SelectedSim = null;
			cbOwner.SelectedSimId = 4294967295u;
			cbOwner.SelectedSimInstance = 65535;
			cbOwner.SelectedSimChanged += new EventHandler(
				cbOwner_SelectedSimChanged
			);
			//
			// llme
			//
			resources.ApplyResources(llme, "llme");
			llme.Name = "llme";
			llme.TabStop = true;
			llme.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					llme_LinkClicked
				);
			//
			// label3
			//
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			//
			// pnSelection
			//
			pnSelection.Controls.Add(lbtype);
			pnSelection.Controls.Add(label2);
			pnSelection.Controls.Add(pb);
			pnSelection.Controls.Add(cbtype);
			pnSelection.Controls.Add(cbObjs);
			pnSelection.Controls.Add(cbToks);
			pnSelection.Controls.Add(cbMems);
			resources.ApplyResources(pnSelection, "pnSelection");
			pnSelection.Name = "pnSelection";
			//
			// lbtype
			//
			resources.ApplyResources(lbtype, "lbtype");
			lbtype.Name = "lbtype";
			//
			// label2
			//
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			//
			// pb
			//
			resources.ApplyResources(pb, "pb");
			pb.Name = "pb";
			pb.TabStop = false;
			//
			// cbtype
			//
			resources.ApplyResources(cbtype, "cbtype");
			cbtype.DropDownStyle = ComboBoxStyle.DropDownList;
			cbtype.Enum = null;
			cbtype.ForeColor = System.Drawing.SystemColors.ControlText;
			cbtype.Name = "cbtype";
			cbtype.ResourceManager = null;
			cbtype.SelectedIndexChanged += new EventHandler(
				cbtype_SelectedIndexChanged
			);
			//
			// cbObjs
			//
			resources.ApplyResources(cbObjs, "cbObjs");
			cbObjs.Name = "cbObjs";
			cbObjs.SelectedGuid = 4294967295u;
			cbObjs.SelectedItem = null;
			cbObjs.ShowAspiration = false;
			cbObjs.ShowBadge = false;
			cbObjs.ShowInventory = true;
			cbObjs.ShowJobData = false;
			cbObjs.ShowMemories = false;
			cbObjs.ShowSkill = false;
			cbObjs.ShowTokens = false;
			cbObjs.SelectedObjectChanged += new EventHandler(
				ChangeGuid
			);
			//
			// cbToks
			//
			resources.ApplyResources(cbToks, "cbToks");
			cbToks.Name = "cbToks";
			cbToks.SelectedGuid = 4294967295u;
			cbToks.SelectedItem = null;
			cbToks.ShowAspiration = false;
			cbToks.ShowBadge = false;
			cbToks.ShowInventory = false;
			cbToks.ShowJobData = false;
			cbToks.ShowMemories = false;
			cbToks.ShowSkill = false;
			cbToks.ShowTokens = true;
			cbToks.SelectedObjectChanged += new EventHandler(
				ChangeGuid
			);
			//
			// cbMems
			//
			resources.ApplyResources(cbMems, "cbMems");
			cbMems.Name = "cbMems";
			cbMems.SelectedGuid = 4294967295u;
			cbMems.SelectedItem = null;
			cbMems.ShowAspiration = false;
			cbMems.ShowBadge = false;
			cbMems.ShowInventory = false;
			cbMems.ShowJobData = false;
			cbMems.ShowMemories = true;
			cbMems.ShowSkill = false;
			cbMems.ShowTokens = false;
			cbMems.SelectedObjectChanged += new EventHandler(
				ChangeGuid
			);
			//
			// pnListing
			//
			pnListing.Controls.Add(rbObjs);
			pnListing.Controls.Add(rbToks);
			pnListing.Controls.Add(rbMems);
			pnListing.Controls.Add(label10);
			resources.ApplyResources(pnListing, "pnListing");
			pnListing.Name = "pnListing";
			//
			// rbObjs
			//
			resources.ApplyResources(rbObjs, "rbObjs");
			rbObjs.Name = "rbObjs";
			rbObjs.CheckedChanged += new EventHandler(
				rbObjs_CheckedChanged
			);
			//
			// rbToks
			//
			resources.ApplyResources(rbToks, "rbToks");
			rbToks.Name = "rbToks";
			rbToks.CheckedChanged += new EventHandler(
				rbToks_CheckedChanged
			);
			//
			// rbMems
			//
			resources.ApplyResources(rbMems, "rbMems");
			rbMems.Name = "rbMems";
			rbMems.CheckedChanged += new EventHandler(
				rbMems_CheckedChanged
			);
			//
			// label10
			//
			resources.ApplyResources(label10, "label10");
			label10.Name = "label10";
			//
			// pnFlags
			//
			pnFlags.Controls.Add(cbVis);
			pnFlags.Controls.Add(cbCtrl);
			pnFlags.Controls.Add(tbFlag);
			pnFlags.Controls.Add(label9);
			resources.ApplyResources(pnFlags, "pnFlags");
			pnFlags.Name = "pnFlags";
			//
			// cbVis
			//
			resources.ApplyResources(cbVis, "cbVis");
			cbVis.Name = "cbVis";
			cbVis.CheckedChanged += new EventHandler(
				cbVis_CheckedChanged
			);
			//
			// cbCtrl
			//
			resources.ApplyResources(cbCtrl, "cbCtrl");
			cbCtrl.Name = "cbCtrl";
			cbCtrl.CheckedChanged += new EventHandler(
				cbAct_CheckedChanged
			);
			//
			// tbFlag
			//
			resources.ApplyResources(tbFlag, "tbFlag");
			tbFlag.Name = "tbFlag";
			tbFlag.ReadOnly = true;
			tbFlag.TextChanged += new EventHandler(tbFlag_TextChanged);
			//
			// label9
			//
			resources.ApplyResources(label9, "label9");
			label9.Name = "label9";
			//
			// panel3
			//
			panel3.Controls.Add(tbUnk);
			panel3.Controls.Add(label11);
			resources.ApplyResources(panel3, "panel3");
			panel3.Name = "panel3";
			//
			// tabPage4
			//
			tabPage4.BackColor = System.Drawing.SystemColors.ControlLight;
			tabPage4.Controls.Add(pg);
			tabPage4.Controls.Add(panel1);
			tabPage4.FloatingSize = new System.Drawing.Size(550, 400);
			tabPage4.Guid = new Guid(
				"3b0d25ef-e354-4693-8339-f171a2b4f000"
			);
			resources.ApplyResources(tabPage4, "tabPage4");
			tabPage4.Name = "tabPage4";
			//
			// panel1
			//
			panel1.Controls.Add(llSetRawLength);
			panel1.Controls.Add(tbRawLength);
			panel1.Controls.Add(label1);
			resources.ApplyResources(panel1, "panel1");
			panel1.Name = "panel1";
			//
			// llSetRawLength
			//
			resources.ApplyResources(llSetRawLength, "llSetRawLength");
			llSetRawLength.Name = "llSetRawLength";
			llSetRawLength.TabStop = true;
			llSetRawLength.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					llSetRawLength_LinkClicked
				);
			//
			// tbRawLength
			//
			resources.ApplyResources(tbRawLength, "tbRawLength");
			tbRawLength.Name = "tbRawLength";
			//
			// label1
			//
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			//
			// label11
			//
			resources.ApplyResources(label11, "label11");
			label11.Name = "label11";
			//
			// tbUnk
			//
			resources.ApplyResources(tbUnk, "tbUnk");
			tbUnk.Name = "tbUnk";
			tbUnk.ReadOnly = true;
			//
			// MemoryProperties
			//
			Controls.Add(tabControl2);
			resources.ApplyResources(this, "$this");
			Name = "MemoryProperties";
			tabControl2.ResumeLayout(false);
			tabPage3.ResumeLayout(false);
			panel2.ResumeLayout(false);
			pnObjectGuid.ResumeLayout(false);
			pnSubject.ResumeLayout(false);
			pnSub1.ResumeLayout(false);
			pnValue.ResumeLayout(false);
			pnValue.PerformLayout();
			pnInventory.ResumeLayout(false);
			pnInventory.PerformLayout();
			pnOwner.ResumeLayout(false);
			pnSelection.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pb).EndInit();
			pnListing.ResumeLayout(false);
			pnFlags.ResumeLayout(false);
			pnFlags.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			tabPage4.ResumeLayout(false);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
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
			get => item;
			set
			{
				item = value;
				SetContent();
			}
		}

		NgbhItemsListView nilv;
		public NgbhItemsListView NgbhItemsListView
		{
			get => nilv;
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
			nilv?.UpdateSelected(item);
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
				Enabled = true;
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

				tbRawLength.Text = item.Data.Length.ToString();
				cbtype.SelectedValue = item.MemoryType;

				UpdateSelectedItem();

				pb.Image = item.MemoryCacheItem.Image;

				SelectOwner(cbOwner, item);
				SelectSubject(item);

				tbInv.Text = item.InventoryNumber.ToString();
				tbValue.Text = item.Value.ToString();
				tbUnk.Text = Helper.HexString(item.UnknownNumber);
				UpdateFlagsValue();
			}
			else
			{
				Enabled = false;
			}
			inter = false;
		}

		void UpdateFlagsValue()
		{
			tbFlag.Text = "0x" + Helper.HexString(item.Flags.Value);
		}

		void UpdateSelectedItem()
		{
			bool use =
				!item.MemoryCacheItem.IsToken && !item.MemoryCacheItem.IsInventory
			;
			cbMems.Visible = use;
			rbMems.Checked = use;
			if (use)
			{
				SelectNgbhItem(cbMems, item);
			}

			use = item.MemoryCacheItem.IsToken && !item.MemoryCacheItem.IsInventory;
			cbToks.Visible = use;
			rbToks.Checked = use;
			if (use)
			{
				SelectNgbhItem(cbToks, item);
			}

			use = !item.MemoryCacheItem.IsToken && item.MemoryCacheItem.IsInventory;
			cbObjs.Visible = use;
			rbObjs.Checked = use;
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
			cbSubject.SelectedSimId = item.SubjectGuid;
			cbSubjectObj.SelectedGuid = item.MemoryType == SimMemoryType.Object ? item.ReferencedObjectGuid : item.SubjectGuid;
		}

		private void nilv_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (nilv != null)
			{
				NgbhItemsListViewItem lvi = nilv.SelectedItem;
				Item = lvi != null && !nilv.SelectedMultiple ? lvi.Item : null;
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
			if (item != null)
			{
				ushort[] ndata = new ushort[
					Helper.StringToInt32(tbRawLength.Text, item.Data.Length, 10)
				];
				for (int i = 0; i < ndata.Length; i++)
				{
					ndata[i] = i < item.Data.Length ? item.Data[i] : (ushort)0;
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
			FireChangeEvent();
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
			if (tabPage3.Visible && chgraw)
			{
				SetContent();
			}
		}

		private void cbtype_SelectedIndexChanged(object sender, EventArgs e)
		{
			SimMemoryType smt = (SimMemoryType)cbtype.SelectedValue;

			pnOwner.Visible =
				smt == SimMemoryType.Memory
				|| smt == SimMemoryType.Gossip
				|| smt == SimMemoryType.GossipInventory
			;
			pnSub1.Visible =
				smt == SimMemoryType.Memory || smt == SimMemoryType.Gossip
			;
			pnSub2.Visible = pnSub1.Visible;
			pnSubject.Visible =
				smt == SimMemoryType.Memory || smt == SimMemoryType.Gossip
			;
			pnObjectGuid.Visible =
				smt == SimMemoryType.Memory
				|| smt == SimMemoryType.Gossip
				|| smt == SimMemoryType.Object
			;

			pnInventory.Visible =
				smt == SimMemoryType.Inventory || smt == SimMemoryType.GossipInventory
			;
			pnValue.Visible =
				smt == SimMemoryType.Skill
				|| smt == SimMemoryType.Badge
				|| smt == SimMemoryType.ValueToken
			;
			pnFlags.Visible = true;

			pnListing.Visible = Helper.WindowsRegistry.HiddenMode;
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
			SetMe(cbOwner);
		}

		private void linkLabel1_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			SetMe(cbSubject);
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
			FireChangeEvent();
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
			cbSubjectObj.SelectedGuid = 0xffffffff;
			item.SetSubject(
				cbSubject.SelectedSimInstance,
				cbSubject.SelectedSimId
			);
			inter = false;

			SetContent();
			FireChangeEvent();
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

			cbSubject.SelectedSimId = 0xffffffff;
			if (item.MemoryType == SimMemoryType.Object)
			{
				item.ReferencedObjectGuid = cbSubjectObj.SelectedGuid;
			}
			else
			{
				item.SetSubject(0, cbSubjectObj.SelectedGuid);
			}

			inter = false;

			SetContent();
			FireChangeEvent();
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
				tbInv.Text,
				item.InventoryNumber,
				10
			);
			SetContent();
			FireChangeEvent();
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

			item.Value = Helper.StringToUInt16(tbValue.Text, item.Value, 10);
			FireChangeEvent();
		}

		private void tbFlag_TextChanged(object sender, EventArgs e)
		{
			if (item == null)
			{
				return;
			}

			cbCtrl.Checked = item.Flags.IsControler;
			cbVis.Checked = item.Flags.IsVisible;
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
			item.Flags.IsVisible = cbVis.Checked;
			UpdateFlagsValue();
			inter = false;
			SetContent();
			FireChangeEvent();
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
			item.Flags.IsControler = cbCtrl.Checked;
			UpdateFlagsValue();
			inter = false;
			SetContent();
			FireChangeEvent();
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
