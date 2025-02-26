using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

using Ambertation.Windows.Forms;

namespace SimPe.Plugin.Tool.Dockable
{
	/// <summary>
	/// Summary description for DoackableObjectWorkshop.
	/// </summary>
	public class dcObjectWorkshop : Ambertation.Windows.Forms.DockPanel
	{
		class MyTreeView : System.Windows.Forms.TreeView
		{
			public MyTreeView()
				: base() { }

			public void DoBeginUpdate()
			{
				this.BeginUpdate();
				//this.Visible = false;
			}

			public void DoEndUpdate(bool vis)
			{
				this.EndUpdate();
				//this.Visible = vis;
			}
		}

		private SteepValley.Windows.Forms.XPGradientPanel xpGradientPanel1;
		private SimPe.Wizards.Wizard wizard1;
		private SimPe.Wizards.WizardStepPanel wizardStepPanel1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private SimPe.Wizards.WizardStepPanel wizardStepPanel2;
		private System.Windows.Forms.ListBox lb;
		private MyTreeView tv;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel1;
		private Ambertation.Windows.Forms.XPTaskBoxSimple xpTaskBoxSimple2;
		private SimPe.Wizards.WizardStepPanel wizardStepPanel3;
		private Ambertation.Windows.Forms.XPTaskBoxSimple xpTaskBoxSimple1;
		private Ambertation.Windows.Forms.XPTaskBoxSimple gbRecolor;
		private System.Windows.Forms.CheckBox cbColorExt;
		private Ambertation.Windows.Forms.XPTaskBoxSimple gbClone;
		internal System.Windows.Forms.CheckBox cbanim;
		internal System.Windows.Forms.CheckBox cbwallmask;
		internal System.Windows.Forms.CheckBox cbparent;
		internal System.Windows.Forms.CheckBox cbclean;
		internal System.Windows.Forms.CheckBox cbfix;
		internal System.Windows.Forms.CheckBox cbdefault;
		internal System.Windows.Forms.CheckBox cbgid;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button button3;
		internal System.Windows.Forms.ComboBox cbTask;
		private System.Windows.Forms.Label label3;
		private SimPe.Wizards.WizardStepPanel wizardStepPanel4;
		private System.Windows.Forms.Panel pnWait;
		private System.Windows.Forms.Label lberr;
		private System.Windows.Forms.Label lbfinload;
		private System.Windows.Forms.Label lbwait;
		private System.Windows.Forms.PictureBox pbWait;
		private System.Windows.Forms.Label lbfinished;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ImageList ilist;
		private SimPe.Plugin.Tool.Dockable.ObjectPreview op1;
		private SimPe.Plugin.Tool.Dockable.ObjectPreview op2;
		internal System.Windows.Forms.CheckBox cbRemTxt;
		internal System.Windows.Forms.CheckBox cbOrgGmdc;
		private SimPe.Wizards.WizardStepPanel wizardStepPanel5;
		private Ambertation.Windows.Forms.XPTaskBoxSimple xpTaskBoxSimple3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tbName;
		private System.Windows.Forms.TextBox tbPrice;
		private System.Windows.Forms.RichTextBox tbDesc;
		internal System.Windows.Forms.CheckBox cbDesc;
		internal System.Windows.Forms.CheckBox cbstrlink;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Button button4;
		private Ambertation.Windows.Forms.XPTaskBoxSimple xpAdvanced;
		private System.Windows.Forms.TextBox tbGroup;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.TextBox tbCresName;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.TextBox tbGUID;
		private ToolStrip toolStrip1;
		private ToolStripButton biPrev;
		private ToolStripButton biNext;
		private ToolStripButton biFinish;
		private ToolStripButton biAbort;
		private ToolStripButton biCatalog;
		private LinkLabel llCloneDef;
		private ToolTip toolTip1;

		ObjectWorkshopRegistry registry;

		public dcObjectWorkshop()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			this.xpAdvanced.Visible = (UserVerification.HaveUserId);
			this.op1 = new SimPe.Plugin.Tool.Dockable.ObjectPreview();
			this.op2 = new SimPe.Plugin.Tool.Dockable.ObjectPreview();
			// op1.SuspendLayout(); - (prevented op1 layout, causung the title to be scrolled and the description to be cut off) Chris Hatch
			//
			// op1
			//
			this.op1.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						(
							(
								System.Windows.Forms.AnchorStyles.Top
								| System.Windows.Forms.AnchorStyles.Bottom
							) | System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.op1.BackColor = System.Drawing.Color.Transparent;
			this.op1.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.op1.LoadCustomImage = true;
			this.op1.Location = new System.Drawing.Point(8, 44);
			this.op1.Name = "op1";
			this.op1.SelectedObject = null;
			this.op1.Size = new System.Drawing.Size(
				this.xpTaskBoxSimple2.Width - 16,
				this.xpTaskBoxSimple2.Height - 56
			);
			this.op1.TabIndex = 0;
			this.xpTaskBoxSimple2.Controls.Add(this.op1);
			this.xpTaskBoxSimple2.Resize += new EventHandler(xpTaskBoxSimple2_Resize);
			// op2.ResumeLayout(); - (op2 layout was never suspended) Chris Hatch
			//
			// op2
			//
			this.op2.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						(
							(
								System.Windows.Forms.AnchorStyles.Top
								| System.Windows.Forms.AnchorStyles.Bottom
							) | System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.op2.BackColor = System.Drawing.Color.Transparent;
			this.op2.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.op2.LoadCustomImage = true;
			this.op2.Location = new System.Drawing.Point(8, 44);
			this.op2.Name = "op2";
			this.op2.SelectedObject = null;
			this.op2.Size = new System.Drawing.Size(
				this.xpTaskBoxSimple1.Width - 16,
				this.xpTaskBoxSimple1.Height - 56
			);
			this.op2.TabIndex = 1;
			this.xpTaskBoxSimple1.Controls.Add(this.op2);
			xpTaskBoxSimple1.Resize += new EventHandler(xpTaskBoxSimple1_Resize);

			//do the regular initialization Work
			wizard1.Start();

			biFinish.Visible = wizard1.FinishEnabled;
			this.biAbort.Visible = wizard1.PrevEnabled;
			biNext.Enabled = wizard1.NextEnabled;
			biPrev.Enabled = wizard1.PrevEnabled;
			ilist.ImageSize = new Size(
				Helper.WindowsRegistry.OWThumbSize,
				Helper.WindowsRegistry.OWThumbSize
			);
			tv.ItemHeight = Helper.WindowsRegistry.OWThumbSize + 1;
			registry = new ObjectWorkshopRegistry(this);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (registry != null)
					registry.Dispose();
				registry = null;
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		//make sure that this order is maintained after each edit of the GUI
		/*
		 *  this.wizard1.Controls.Add(this.wizardStepPanel1);
			this.wizard1.Controls.Add(this.wizardStepPanel2);
			this.wizard1.Controls.Add(this.wizardStepPanel3);
			this.wizard1.Controls.Add(this.wizardStepPanel5);
			this.wizard1.Controls.Add(this.wizardStepPanel4);
		 */

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(
					typeof(dcObjectWorkshop)
				);
			this.xpGradientPanel1 = new SteepValley.Windows.Forms.XPGradientPanel();
			this.wizard1 = new SimPe.Wizards.Wizard();
			this.wizardStepPanel1 = new SimPe.Wizards.WizardStepPanel();
			this.xpAdvanced = new Ambertation.Windows.Forms.XPTaskBoxSimple();
			this.button6 = new System.Windows.Forms.Button();
			this.tbGUID = new System.Windows.Forms.TextBox();
			this.button5 = new System.Windows.Forms.Button();
			this.tbCresName = new System.Windows.Forms.TextBox();
			this.button4 = new System.Windows.Forms.Button();
			this.tbGroup = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.wizardStepPanel2 = new SimPe.Wizards.WizardStepPanel();
			this.lb = new System.Windows.Forms.ListBox();
			this.tv = new SimPe.Plugin.Tool.Dockable.dcObjectWorkshop.MyTreeView();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel1 = new System.Windows.Forms.Panel();
			this.xpTaskBoxSimple2 = new Ambertation.Windows.Forms.XPTaskBoxSimple();
			this.wizardStepPanel3 = new SimPe.Wizards.WizardStepPanel();
			this.xpTaskBoxSimple1 = new Ambertation.Windows.Forms.XPTaskBoxSimple();
			this.gbRecolor = new Ambertation.Windows.Forms.XPTaskBoxSimple();
			this.cbColorExt = new System.Windows.Forms.CheckBox();
			this.gbClone = new Ambertation.Windows.Forms.XPTaskBoxSimple();
			this.llCloneDef = new System.Windows.Forms.LinkLabel();
			this.cbstrlink = new System.Windows.Forms.CheckBox();
			this.cbDesc = new System.Windows.Forms.CheckBox();
			this.cbOrgGmdc = new System.Windows.Forms.CheckBox();
			this.cbRemTxt = new System.Windows.Forms.CheckBox();
			this.cbanim = new System.Windows.Forms.CheckBox();
			this.cbwallmask = new System.Windows.Forms.CheckBox();
			this.cbparent = new System.Windows.Forms.CheckBox();
			this.cbclean = new System.Windows.Forms.CheckBox();
			this.cbfix = new System.Windows.Forms.CheckBox();
			this.cbdefault = new System.Windows.Forms.CheckBox();
			this.cbgid = new System.Windows.Forms.CheckBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.button3 = new System.Windows.Forms.Button();
			this.cbTask = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.wizardStepPanel5 = new SimPe.Wizards.WizardStepPanel();
			this.xpTaskBoxSimple3 = new Ambertation.Windows.Forms.XPTaskBoxSimple();
			this.tbDesc = new System.Windows.Forms.RichTextBox();
			this.tbPrice = new System.Windows.Forms.TextBox();
			this.tbName = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.wizardStepPanel4 = new SimPe.Wizards.WizardStepPanel();
			this.pnWait = new System.Windows.Forms.Panel();
			this.pbWait = new System.Windows.Forms.PictureBox();
			this.lbfinished = new System.Windows.Forms.Label();
			this.lberr = new System.Windows.Forms.Label();
			this.lbfinload = new System.Windows.Forms.Label();
			this.lbwait = new System.Windows.Forms.Label();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.biPrev = new System.Windows.Forms.ToolStripButton();
			this.biNext = new System.Windows.Forms.ToolStripButton();
			this.biFinish = new System.Windows.Forms.ToolStripButton();
			this.biAbort = new System.Windows.Forms.ToolStripButton();
			this.biCatalog = new System.Windows.Forms.ToolStripButton();
			this.ilist = new System.Windows.Forms.ImageList(this.components);
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.xpGradientPanel1.SuspendLayout();
			this.wizard1.SuspendLayout();
			this.wizardStepPanel1.SuspendLayout();
			this.xpAdvanced.SuspendLayout();
			this.wizardStepPanel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.wizardStepPanel3.SuspendLayout();
			this.gbRecolor.SuspendLayout();
			this.gbClone.SuspendLayout();
			this.panel2.SuspendLayout();
			this.wizardStepPanel5.SuspendLayout();
			this.xpTaskBoxSimple3.SuspendLayout();
			this.wizardStepPanel4.SuspendLayout();
			this.pnWait.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbWait)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			//
			// xpGradientPanel1
			//
			this.xpGradientPanel1.BackColor = System.Drawing.Color.Transparent;
			this.xpGradientPanel1.Controls.Add(this.wizard1);
			this.xpGradientPanel1.Controls.Add(this.toolStrip1);
			resources.ApplyResources(this.xpGradientPanel1, "xpGradientPanel1");
			this.xpGradientPanel1.Name = "xpGradientPanel1";
			//
			// wizard1
			//
			this.wizard1.BackColor = System.Drawing.Color.Transparent;
			this.wizard1.Controls.Add(this.wizardStepPanel1);
			this.wizard1.Controls.Add(this.wizardStepPanel2);
			this.wizard1.Controls.Add(this.wizardStepPanel3);
			this.wizard1.Controls.Add(this.wizardStepPanel5);
			this.wizard1.Controls.Add(this.wizardStepPanel4);
			this.wizard1.CurrentStepNumber = 0;
			resources.ApplyResources(this.wizard1, "wizard1");
			this.wizard1.FinishEnabled = false;
			this.wizard1.Image = null;
			this.wizard1.Name = "wizard1";
			this.wizard1.NextEnabled = false;
			this.wizard1.PrevEnabled = false;
			this.wizard1.ChangedFinishState += new SimPe.Wizards.WizardHandle(
				this.wizard1_ChangedFinishState
			);
			this.wizard1.ShowStep += new SimPe.Wizards.WizardChangeHandle(
				this.wizard1_ShowStep
			);
			this.wizard1.ChangedPrevState += new SimPe.Wizards.WizardHandle(
				this.wizard1_ChangedPrevState
			);
			this.wizard1.PrepareStep += new SimPe.Wizards.WizardStepChangeHandle(
				this.wizard1_PrepareStep
			);
			this.wizard1.ChangedNextState += new SimPe.Wizards.WizardHandle(
				this.wizard1_ChangedNextState
			);
			this.wizard1.ShowedStep += new SimPe.Wizards.WizardShowedHandle(
				this.wizard1_ShowedStep
			);
			//
			// wizardStepPanel1
			//
			this.wizardStepPanel1.BackColor = System.Drawing.Color.Transparent;
			this.wizardStepPanel1.Controls.Add(this.xpAdvanced);
			this.wizardStepPanel1.Controls.Add(this.label4);
			this.wizardStepPanel1.Controls.Add(this.button2);
			this.wizardStepPanel1.Controls.Add(this.label1);
			this.wizardStepPanel1.Controls.Add(this.button1);
			this.wizardStepPanel1.Controls.Add(this.label2);
			resources.ApplyResources(this.wizardStepPanel1, "wizardStepPanel1");
			this.wizardStepPanel1.First = false;
			this.wizardStepPanel1.Last = false;
			this.wizardStepPanel1.Name = "wizardStepPanel1";
			//
			// xpAdvanced
			//
			this.xpAdvanced.BackColor = System.Drawing.Color.Transparent;
			this.xpAdvanced.Controls.Add(this.button6);
			this.xpAdvanced.Controls.Add(this.tbGUID);
			this.xpAdvanced.Controls.Add(this.button5);
			this.xpAdvanced.Controls.Add(this.tbCresName);
			this.xpAdvanced.Controls.Add(this.button4);
			this.xpAdvanced.Controls.Add(this.tbGroup);
			this.xpAdvanced.HeaderFont = new System.Drawing.Font(
				"Microsoft Sans Serif",
				10.25F,
				System.Drawing.FontStyle.Bold
			);
			resources.ApplyResources(this.xpAdvanced, "xpAdvanced");
			this.xpAdvanced.IconLocation = new System.Drawing.Point(4, 12);
			this.xpAdvanced.IconSize = new System.Drawing.Size(32, 32);
			this.xpAdvanced.Name = "xpAdvanced";
			//
			// button6
			//
			resources.ApplyResources(this.button6, "button6");
			this.button6.Name = "button6";
			this.button6.Click += new System.EventHandler(this.button6_Click);
			//
			// tbGUID
			//
			resources.ApplyResources(this.tbGUID, "tbGUID");
			this.tbGUID.Name = "tbGUID";
			//
			// button5
			//
			resources.ApplyResources(this.button5, "button5");
			this.button5.Name = "button5";
			this.button5.Click += new System.EventHandler(this.button5_Click);
			//
			// tbCresName
			//
			resources.ApplyResources(this.tbCresName, "tbCresName");
			this.tbCresName.Name = "tbCresName";
			//
			// button4
			//
			resources.ApplyResources(this.button4, "button4");
			this.button4.Name = "button4";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			//
			// tbGroup
			//
			resources.ApplyResources(this.tbGroup, "tbGroup");
			this.tbGroup.Name = "tbGroup";
			//
			// label4
			//
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			//
			// button2
			//
			resources.ApplyResources(this.button2, "button2");
			this.button2.Name = "button2";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			//
			// label1
			//
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			//
			// button1
			//
			resources.ApplyResources(this.button1, "button1");
			this.button1.Name = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			//
			// label2
			//
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			//
			// wizardStepPanel2
			//
			this.wizardStepPanel2.BackColor = System.Drawing.Color.Transparent;
			this.wizardStepPanel2.Controls.Add(this.lb);
			this.wizardStepPanel2.Controls.Add(this.tv);
			this.wizardStepPanel2.Controls.Add(this.splitter1);
			this.wizardStepPanel2.Controls.Add(this.panel1);
			resources.ApplyResources(this.wizardStepPanel2, "wizardStepPanel2");
			this.wizardStepPanel2.First = false;
			this.wizardStepPanel2.Last = false;
			this.wizardStepPanel2.Name = "wizardStepPanel2";
			this.wizardStepPanel2.Activate += new SimPe.Wizards.WizardChangeHandle(
				this.wizardStepPanel2_Activate
			);
			this.wizardStepPanel2.Prepare += new SimPe.Wizards.WizardStepChangeHandle(
				this.wizardStepPanel2_Prepare
			);
			//
			// lb
			//
			this.lb.BorderStyle = System.Windows.Forms.BorderStyle.None;
			resources.ApplyResources(this.lb, "lb");
			this.lb.Name = "lb";
			this.lb.SelectedIndexChanged += new System.EventHandler(
				this.lb_SelectedIndexChanged
			);
			//
			// tv
			//
			this.tv.BorderStyle = System.Windows.Forms.BorderStyle.None;
			resources.ApplyResources(this.tv, "tv");
			this.tv.ItemHeight = 17;
			this.tv.Name = "tv";
			this.tv.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(
				this.tv_AfterSelect
			);
			//
			// splitter1
			//
			this.splitter1.BackColor = System.Drawing.SystemColors.Highlight;
			resources.ApplyResources(this.splitter1, "splitter1");
			this.splitter1.Name = "splitter1";
			this.splitter1.TabStop = false;
			//
			// panel1
			//
			this.panel1.Controls.Add(this.xpTaskBoxSimple2);
			resources.ApplyResources(this.panel1, "panel1");
			this.panel1.Name = "panel1";
			//
			// xpTaskBoxSimple2
			//
			this.xpTaskBoxSimple2.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.xpTaskBoxSimple2, "xpTaskBoxSimple2");
			this.xpTaskBoxSimple2.HeaderFont = new System.Drawing.Font(
				"Microsoft Sans Serif",
				10.25F,
				System.Drawing.FontStyle.Bold
			);
			this.xpTaskBoxSimple2.IconLocation = new System.Drawing.Point(4, 12);
			this.xpTaskBoxSimple2.IconSize = new System.Drawing.Size(32, 32);
			this.xpTaskBoxSimple2.Name = "xpTaskBoxSimple2";
			//
			// wizardStepPanel3
			//
			this.wizardStepPanel3.BackColor = System.Drawing.Color.Transparent;
			this.wizardStepPanel3.Controls.Add(this.xpTaskBoxSimple1);
			this.wizardStepPanel3.Controls.Add(this.gbRecolor);
			this.wizardStepPanel3.Controls.Add(this.gbClone);
			this.wizardStepPanel3.Controls.Add(this.panel2);
			resources.ApplyResources(this.wizardStepPanel3, "wizardStepPanel3");
			this.wizardStepPanel3.First = false;
			this.wizardStepPanel3.Last = false;
			this.wizardStepPanel3.Name = "wizardStepPanel3";
			this.wizardStepPanel3.Activate += new SimPe.Wizards.WizardChangeHandle(
				this.wizardStepPanel3_Activate
			);
			this.wizardStepPanel3.Activated += new SimPe.Wizards.WizardStepHandle(
				this.wizardStepPanel3_Activated
			);
			//
			// xpTaskBoxSimple1
			//
			this.xpTaskBoxSimple1.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.xpTaskBoxSimple1, "xpTaskBoxSimple1");
			this.xpTaskBoxSimple1.HeaderFont = new System.Drawing.Font(
				"Microsoft Sans Serif",
				10.25F,
				System.Drawing.FontStyle.Bold
			);
			this.xpTaskBoxSimple1.IconLocation = new System.Drawing.Point(4, 12);
			this.xpTaskBoxSimple1.IconSize = new System.Drawing.Size(32, 32);
			this.xpTaskBoxSimple1.Name = "xpTaskBoxSimple1";
			//
			// gbRecolor
			//
			this.gbRecolor.BackColor = System.Drawing.Color.Transparent;
			this.gbRecolor.Controls.Add(this.cbColorExt);
			resources.ApplyResources(this.gbRecolor, "gbRecolor");
			this.gbRecolor.HeaderFont = new System.Drawing.Font(
				"Microsoft Sans Serif",
				10.25F,
				System.Drawing.FontStyle.Bold
			);
			this.gbRecolor.IconLocation = new System.Drawing.Point(4, 12);
			this.gbRecolor.IconSize = new System.Drawing.Size(32, 32);
			this.gbRecolor.Name = "gbRecolor";
			//
			// cbColorExt
			//
			this.cbColorExt.Checked = true;
			this.cbColorExt.CheckState = System.Windows.Forms.CheckState.Checked;
			resources.ApplyResources(this.cbColorExt, "cbColorExt");
			this.cbColorExt.Name = "cbColorExt";
			this.cbColorExt.UseVisualStyleBackColor = false;
			//
			// gbClone
			//
			this.gbClone.BackColor = System.Drawing.Color.Transparent;
			this.gbClone.Controls.Add(this.llCloneDef);
			this.gbClone.Controls.Add(this.cbstrlink);
			this.gbClone.Controls.Add(this.cbDesc);
			this.gbClone.Controls.Add(this.cbOrgGmdc);
			this.gbClone.Controls.Add(this.cbRemTxt);
			this.gbClone.Controls.Add(this.cbanim);
			this.gbClone.Controls.Add(this.cbwallmask);
			this.gbClone.Controls.Add(this.cbparent);
			this.gbClone.Controls.Add(this.cbclean);
			this.gbClone.Controls.Add(this.cbfix);
			this.gbClone.Controls.Add(this.cbdefault);
			this.gbClone.Controls.Add(this.cbgid);
			resources.ApplyResources(this.gbClone, "gbClone");
			this.gbClone.HeaderFont = new System.Drawing.Font(
				"Microsoft Sans Serif",
				10.25F,
				System.Drawing.FontStyle.Bold
			);
			this.gbClone.IconLocation = new System.Drawing.Point(4, 0);
			this.gbClone.IconSize = new System.Drawing.Size(32, 32);
			this.gbClone.Name = "gbClone";
			//
			// llCloneDef
			//
			resources.ApplyResources(this.llCloneDef, "llCloneDef");
			//this.llCloneDef.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.llCloneDef.Name = "llCloneDef";
			this.llCloneDef.TabStop = true;
			this.llCloneDef.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(
					this.SetDefaultsForClone
				);
			//
			// cbstrlink
			//
			resources.ApplyResources(this.cbstrlink, "cbstrlink");
			this.cbstrlink.Name = "cbstrlink";
			this.toolTip1.SetToolTip(
				this.cbstrlink,
				resources.GetString("cbstrlink.ToolTip")
			);
			this.cbstrlink.UseVisualStyleBackColor = false;
			//
			// cbDesc
			//
			this.cbDesc.Checked = true;
			this.cbDesc.CheckState = System.Windows.Forms.CheckState.Checked;
			resources.ApplyResources(this.cbDesc, "cbDesc");
			this.cbDesc.Name = "cbDesc";
			this.toolTip1.SetToolTip(
				this.cbDesc,
				resources.GetString("cbDesc.ToolTip")
			);
			this.cbDesc.UseVisualStyleBackColor = false;
			this.cbDesc.CheckedChanged += new System.EventHandler(
				this.cbDesc_CheckedChanged
			);
			//
			// cbOrgGmdc
			//
			resources.ApplyResources(this.cbOrgGmdc, "cbOrgGmdc");
			this.cbOrgGmdc.Name = "cbOrgGmdc";
			this.toolTip1.SetToolTip(
				this.cbOrgGmdc,
				resources.GetString("cbOrgGmdc.ToolTip")
			);
			this.cbOrgGmdc.UseVisualStyleBackColor = false;
			//
			// cbRemTxt
			//
			this.cbRemTxt.Checked = true;
			this.cbRemTxt.CheckState = System.Windows.Forms.CheckState.Checked;
			resources.ApplyResources(this.cbRemTxt, "cbRemTxt");
			this.cbRemTxt.Name = "cbRemTxt";
			this.toolTip1.SetToolTip(
				this.cbRemTxt,
				resources.GetString("cbRemTxt.ToolTip")
			);
			this.cbRemTxt.UseVisualStyleBackColor = false;
			//
			// cbanim
			//
			resources.ApplyResources(this.cbanim, "cbanim");
			this.cbanim.Name = "cbanim";
			this.toolTip1.SetToolTip(
				this.cbanim,
				resources.GetString("cbanim.ToolTip")
			);
			this.cbanim.UseVisualStyleBackColor = false;
			//
			// cbwallmask
			//
			this.cbwallmask.Checked = true;
			this.cbwallmask.CheckState = System.Windows.Forms.CheckState.Checked;
			resources.ApplyResources(this.cbwallmask, "cbwallmask");
			this.cbwallmask.Name = "cbwallmask";
			this.toolTip1.SetToolTip(
				this.cbwallmask,
				resources.GetString("cbwallmask.ToolTip")
			);
			this.cbwallmask.UseVisualStyleBackColor = false;
			//
			// cbparent
			//
			resources.ApplyResources(this.cbparent, "cbparent");
			this.cbparent.Name = "cbparent";
			this.toolTip1.SetToolTip(
				this.cbparent,
				resources.GetString("cbparent.ToolTip")
			);
			this.cbparent.UseVisualStyleBackColor = false;
			//
			// cbclean
			//
			this.cbclean.Checked = true;
			this.cbclean.CheckState = System.Windows.Forms.CheckState.Checked;
			resources.ApplyResources(this.cbclean, "cbclean");
			this.cbclean.Name = "cbclean";
			this.toolTip1.SetToolTip(
				this.cbclean,
				resources.GetString("cbclean.ToolTip")
			);
			this.cbclean.UseVisualStyleBackColor = false;
			//
			// cbfix
			//
			this.cbfix.Checked = true;
			this.cbfix.CheckState = System.Windows.Forms.CheckState.Checked;
			resources.ApplyResources(this.cbfix, "cbfix");
			this.cbfix.Name = "cbfix";
			this.toolTip1.SetToolTip(this.cbfix, resources.GetString("cbfix.ToolTip"));
			this.cbfix.UseVisualStyleBackColor = false;
			this.cbfix.CheckedChanged += new System.EventHandler(
				this.cbfix_CheckedChanged
			);
			//
			// cbdefault
			//
			this.cbdefault.Checked = true;
			this.cbdefault.CheckState = System.Windows.Forms.CheckState.Checked;
			resources.ApplyResources(this.cbdefault, "cbdefault");
			this.cbdefault.Name = "cbdefault";
			this.toolTip1.SetToolTip(
				this.cbdefault,
				resources.GetString("cbdefault.ToolTip")
			);
			this.cbdefault.UseVisualStyleBackColor = false;
			//
			// cbgid
			//
			this.cbgid.Checked = true;
			this.cbgid.CheckState = System.Windows.Forms.CheckState.Checked;
			resources.ApplyResources(this.cbgid, "cbgid");
			this.cbgid.Name = "cbgid";
			this.toolTip1.SetToolTip(this.cbgid, resources.GetString("cbgid.ToolTip"));
			this.cbgid.UseVisualStyleBackColor = false;
			//
			// panel2
			//
			this.panel2.Controls.Add(this.button3);
			this.panel2.Controls.Add(this.cbTask);
			this.panel2.Controls.Add(this.label3);
			resources.ApplyResources(this.panel2, "panel2");
			this.panel2.Name = "panel2";
			//
			// button3
			//
			resources.ApplyResources(this.button3, "button3");
			this.button3.Name = "button3";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			//
			// cbTask
			//
			resources.ApplyResources(this.cbTask, "cbTask");
			this.cbTask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTask.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cbTask.Items.AddRange(
				new object[]
				{
					resources.GetString("cbTask.Items"),
					resources.GetString("cbTask.Items1"),
				}
			);
			this.cbTask.Name = "cbTask";
			this.cbTask.SelectedIndexChanged += new System.EventHandler(
				this.cbTask_SelectedIndexChanged
			);
			//
			// label3
			//
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			//
			// wizardStepPanel5
			//
			this.wizardStepPanel5.BackColor = System.Drawing.Color.Transparent;
			this.wizardStepPanel5.Controls.Add(this.xpTaskBoxSimple3);
			resources.ApplyResources(this.wizardStepPanel5, "wizardStepPanel5");
			this.wizardStepPanel5.First = false;
			this.wizardStepPanel5.Last = false;
			this.wizardStepPanel5.Name = "wizardStepPanel5";
			this.wizardStepPanel5.Activate += new SimPe.Wizards.WizardChangeHandle(
				this.wizardStepPanel5_Activate
			);
			this.wizardStepPanel5.Activated += new SimPe.Wizards.WizardStepHandle(
				this.wizardStepPanel5_Activated
			);
			//
			// xpTaskBoxSimple3
			//
			this.xpTaskBoxSimple3.BackColor = System.Drawing.Color.Transparent;
			this.xpTaskBoxSimple3.Controls.Add(this.tbDesc);
			this.xpTaskBoxSimple3.Controls.Add(this.tbPrice);
			this.xpTaskBoxSimple3.Controls.Add(this.tbName);
			this.xpTaskBoxSimple3.Controls.Add(this.label7);
			this.xpTaskBoxSimple3.Controls.Add(this.label6);
			this.xpTaskBoxSimple3.Controls.Add(this.label5);
			resources.ApplyResources(this.xpTaskBoxSimple3, "xpTaskBoxSimple3");
			this.xpTaskBoxSimple3.HeaderFont = new System.Drawing.Font(
				"Microsoft Sans Serif",
				10.25F,
				System.Drawing.FontStyle.Bold
			);
			this.xpTaskBoxSimple3.IconLocation = new System.Drawing.Point(4, 12);
			this.xpTaskBoxSimple3.IconSize = new System.Drawing.Size(32, 32);
			this.xpTaskBoxSimple3.Name = "xpTaskBoxSimple3";
			//
			// tbDesc
			//
			resources.ApplyResources(this.tbDesc, "tbDesc");
			this.tbDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbDesc.Name = "tbDesc";
			//
			// tbPrice
			//
			resources.ApplyResources(this.tbPrice, "tbPrice");
			this.tbPrice.Name = "tbPrice";
			//
			// tbName
			//
			resources.ApplyResources(this.tbName, "tbName");
			this.tbName.Name = "tbName";
			//
			// label7
			//
			resources.ApplyResources(this.label7, "label7");
			this.label7.Name = "label7";
			//
			// label6
			//
			resources.ApplyResources(this.label6, "label6");
			this.label6.Name = "label6";
			//
			// label5
			//
			resources.ApplyResources(this.label5, "label5");
			this.label5.Name = "label5";
			//
			// wizardStepPanel4
			//
			this.wizardStepPanel4.BackColor = System.Drawing.Color.Transparent;
			this.wizardStepPanel4.Controls.Add(this.pnWait);
			resources.ApplyResources(this.wizardStepPanel4, "wizardStepPanel4");
			this.wizardStepPanel4.First = false;
			this.wizardStepPanel4.Last = true;
			this.wizardStepPanel4.Name = "wizardStepPanel4";
			this.wizardStepPanel4.Activate += new SimPe.Wizards.WizardChangeHandle(
				this.wizardStepPanel4_Activate
			);
			this.wizardStepPanel4.Activated += new SimPe.Wizards.WizardStepHandle(
				this.wizardStepPanel4_Activated
			);
			//
			// pnWait
			//
			this.pnWait.Controls.Add(this.pbWait);
			this.pnWait.Controls.Add(this.lbfinished);
			this.pnWait.Controls.Add(this.lberr);
			this.pnWait.Controls.Add(this.lbfinload);
			this.pnWait.Controls.Add(this.lbwait);
			resources.ApplyResources(this.pnWait, "pnWait");
			this.pnWait.Name = "pnWait";
			//
			// pbWait
			//
			resources.ApplyResources(this.pbWait, "pbWait");
			this.pbWait.Name = "pbWait";
			this.pbWait.TabStop = false;
			//
			// lbfinished
			//
			resources.ApplyResources(this.lbfinished, "lbfinished");
			this.lbfinished.Name = "lbfinished";
			//
			// lberr
			//
			resources.ApplyResources(this.lberr, "lberr");
			this.lberr.Name = "lberr";
			this.lberr.Click += new System.EventHandler(this.lberr_Click);
			//
			// lbfinload
			//
			resources.ApplyResources(this.lbfinload, "lbfinload");
			this.lbfinload.Name = "lbfinload";
			//
			// lbwait
			//
			resources.ApplyResources(this.lbwait, "lbwait");
			this.lbwait.Name = "lbwait";
			//
			// toolStrip1
			//
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(
				new System.Windows.Forms.ToolStripItem[]
				{
					this.biPrev,
					this.biNext,
					this.biFinish,
					this.biAbort,
					this.biCatalog,
				}
			);
			this.toolStrip1.LayoutStyle = System
				.Windows
				.Forms
				.ToolStripLayoutStyle
				.HorizontalStackWithOverflow;
			resources.ApplyResources(this.toolStrip1, "toolStrip1");
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.ShowItemToolTips = false;
			//
			// biPrev
			//
			resources.ApplyResources(this.biPrev, "biPrev");
			this.biPrev.Name = "biPrev";
			this.biPrev.Click += new System.EventHandler(this.Activate_biPrev);
			//
			// biNext
			//
			resources.ApplyResources(this.biNext, "biNext");
			this.biNext.Name = "biNext";
			this.biNext.Click += new System.EventHandler(this.Activate_biNext);
			//
			// biFinish
			//
			resources.ApplyResources(this.biFinish, "biFinish");
			this.biFinish.Name = "biFinish";
			this.biFinish.Click += new System.EventHandler(this.ActivateFinish);
			//
			// biAbort
			//
			resources.ApplyResources(this.biAbort, "biAbort");
			this.biAbort.Name = "biAbort";
			this.biAbort.Click += new System.EventHandler(this.biAbort_Activate);
			//
			// biCatalog
			//
			this.biCatalog.Alignment = System
				.Windows
				.Forms
				.ToolStripItemAlignment
				.Right;
			this.biCatalog.Checked = true;
			this.biCatalog.CheckOnClick = true;
			this.biCatalog.CheckState = System.Windows.Forms.CheckState.Checked;
			this.biCatalog.DisplayStyle = System
				.Windows
				.Forms
				.ToolStripItemDisplayStyle
				.Text;
			resources.ApplyResources(this.biCatalog, "biCatalog");
			this.biCatalog.Name = "biCatalog";
			this.biCatalog.Click += new System.EventHandler(this.Activate_biCatalog);
			//
			// ilist
			//
			this.ilist.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			resources.ApplyResources(this.ilist, "ilist");
			this.ilist.TransparentColor = System.Drawing.Color.Transparent;
			//
			// dcObjectWorkshop
			//
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.xpGradientPanel1);
			this.FloatingSize = new System.Drawing.Size(640, 480);
			this.Image = ((System.Drawing.Image)(resources.GetObject("$this.Image")));
			this.MinimumSize = new System.Drawing.Size(640, 480);
			this.Name = "dcObjectWorkshop";
			this.TabImage = (
				(System.Drawing.Image)(resources.GetObject("$this.TabImage"))
			);
			this.TabText = "Object Workshop";
			this.xpGradientPanel1.ResumeLayout(false);
			this.xpGradientPanel1.PerformLayout();
			this.wizard1.ResumeLayout(false);
			this.wizardStepPanel1.ResumeLayout(false);
			this.xpAdvanced.ResumeLayout(false);
			this.xpAdvanced.PerformLayout();
			this.wizardStepPanel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.wizardStepPanel3.ResumeLayout(false);
			this.gbRecolor.ResumeLayout(false);
			this.gbClone.ResumeLayout(false);
			this.gbClone.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.wizardStepPanel5.ResumeLayout(false);
			this.xpTaskBoxSimple3.ResumeLayout(false);
			this.xpTaskBoxSimple3.PerformLayout();
			this.wizardStepPanel4.ResumeLayout(false);
			this.pnWait.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbWait)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
		}
		#endregion

		private void wizard1_ChangedFinishState(SimPe.Wizards.Wizard sender)
		{
			biFinish.Visible = sender.FinishEnabled;
		}

		private void wizard1_ChangedNextState(SimPe.Wizards.Wizard sender)
		{
			biNext.Enabled = sender.NextEnabled;
		}

		private void wizard1_ChangedPrevState(SimPe.Wizards.Wizard sender)
		{
			biPrev.Enabled = sender.PrevEnabled;
			this.biAbort.Visible = biPrev.Enabled;
		}

		private void Activate_biPrev(object sender, System.EventArgs e)
		{
			wizard1.GoPrev();
		}

		private void Activate_biNext(object sender, System.EventArgs e)
		{
			wizard1.GoNext();
		}

		private void ActivateFinish(object sender, System.EventArgs e)
		{
			if (
				wizard1.CurrentStep == this.wizardStepPanel3
				|| wizard1.CurrentStep == this.wizardStepPanel5
			)
				Activate_biNext(sender, e);
			else
				wizard1.Finish();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			onlybase = false;
			Activate_biNext(biNext, e);
		}

		delegate void TreeViewSetUpdateHandler(TreeView tv, bool begin);

		protected TreeNode RootNode;

		private void wizardStepPanel2_Prepare(
			SimPe.Wizards.Wizard sender,
			SimPe.Wizards.WizardStepPanel step,
			int target
		)
		{
			if (target == step.Index)
			{
				onlybase = false;
				if (lb.Items.Count == 0 && tv.Nodes.Count == 0)
				{
					if (RootNode == null)
						RootNode = new TreeNode();
					tv.Enabled = false;
					lb.Enabled = false;
					lastselected = null;
					this.ilist.Images.Clear();
					this.ilist.Images.Add(
						new Bitmap(
							this.GetType()
								.Assembly.GetManifestResourceStream(
									"SimPe.img.subitems.png"
								)
						)
					);
					this.ilist.Images.Add(
						new Bitmap(
							this.GetType()
								.Assembly.GetManifestResourceStream(
									"SimPe.img.nothumb.png"
								)
						)
					);
					this.ilist.Images.Add(
						new Bitmap(
							this.GetType()
								.Assembly.GetManifestResourceStream(
									"SimPe.img.custom.png"
								)
						)
					);

					lb.Items.Clear();
					lb.Sorted = false;
					RootNode.Nodes.Clear();
					tv.Nodes.Clear();
					tv.Sorted = true;
					tv.ImageList = ilist;
					lb.BeginUpdate();
					tv.DoBeginUpdate();

					ObjectLoader ol = new ObjectLoader(null);
					ol.LoadedItem +=
						new SimPe.Plugin.Tool.Dockable.ObjectLoader.LoadItemHandler(
							ol_LoadedItem
						);
					ol.Finished += new EventHandler(ol_Finished);
					ol.LoadData();
				}
			}
		}

		delegate TreeNode GetParentNodeHandler(
			TreeNodeCollection nodes,
			string[] names,
			int id,
			SimPe.Cache.ObjectCacheItem oci,
			SimPe.Data.Alias a,
			ImageList ilist
		);

		private void ol_LoadedItem(
			SimPe.Cache.ObjectCacheItem oci,
			SimPe.Interfaces.Scenegraph.IScenegraphFileIndexItem fii,
			SimPe.Data.Alias a
		)
		{
			if (a == null)
				return;

			if (
				oci.Class == SimPe.Cache.ObjectClass.XObject
				&& !Helper.WindowsRegistry.OWincludewalls
			)
				return;

			string[][] cats = oci.ObjectCategory;
			foreach (string[] ss in cats)
			{
				this.tv.Invoke(
					new GetParentNodeHandler(ObjectLoader.GetParentNode),
					new object[] { RootNode.Nodes, ss, 0, oci, a, ilist }
				);
			}

			lb.Invoke(new System.EventHandler(AddItemToListBox), new object[] { a });
		}

		private void AddItemToListBox(object obj, EventArgs e)
		{
			lb.Items.Add(obj);
		}

		private void ol_Finished(object sender, EventArgs e)
		{
			if (tv.InvokeRequired)
				tv.Invoke(
					new System.EventHandler(invoke_ol_Finished),
					new object[] { sender, e }
				);
			else
				invoke_ol_Finished(sender, e);
		}

		private void invoke_ol_Finished(object sender, EventArgs e)
		{
			lb.Sorted = true;
			tv.Enabled = true;

			Wait.SubStart(RootNode.Nodes.Count);
			Wait.Message = "Building List";
			int ct = 0;
			for (int i = RootNode.Nodes.Count - 1; i >= 0; i--)
			{
				Wait.Progress = ct++;
				TreeNode node = RootNode.Nodes[0];
				RootNode.Nodes.RemoveAt(0);
				tv.Nodes.Add(node);
			}

			tv.EndUpdate();
			Wait.SubStop();

			lb.Enabled = true;

			tv.DoEndUpdate(biCatalog.Checked);
			lb.EndUpdate();
		}

		private void Activate_biCatalog(object sender, System.EventArgs e)
		{
			this.tv.Visible = biCatalog.Checked;
			this.lb.Visible = !biCatalog.Checked;

			lb_SelectedIndexChanged(lb, null);
			tv_AfterSelect(tv, null);
		}

		private void wizard1_ShowStep(
			SimPe.Wizards.Wizard sender,
			SimPe.Wizards.WizardEventArgs e
		)
		{
			this.biCatalog.Visible = (e.Step.Index == wizardStepPanel2.Index);
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			onlybase = false;
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = ExtensionProvider.BuildFilterString(
				new SimPe.ExtensionType[]
				{
					SimPe.ExtensionType.Package,
					SimPe.ExtensionType.DisabledPackage,
					SimPe.ExtensionType.AllFiles,
				}
			);

			package = null;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				package = SimPe.Packages.GeneratableFile.LoadFromFile(ofd.FileName);
				wizard1.JumpToStep(2);
			}
		}

		SimPe.Packages.GeneratableFile package;
		Data.Alias lastselected;

		private void tv_AfterSelect(
			object sender,
			System.Windows.Forms.TreeViewEventArgs e
		)
		{
			if (wizard1.CurrentStepNumber == this.wizardStepPanel2.Index && tv.Visible)
			{
				if (tv.SelectedNode == null)
					wizard1.NextEnabled = false;
				else
					wizard1.NextEnabled = tv.SelectedNode.Tag != null;
			}

			if (wizard1.NextEnabled)
			{
				lastselected = (Data.Alias)tv.SelectedNode.Tag;
			}
			else
				lastselected = null;

			UpdateObjectPreview(op1);
		}

		private void lb_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (wizard1.CurrentStepNumber == this.wizardStepPanel2.Index && lb.Visible)
			{
				wizard1.NextEnabled = (lb.SelectedIndex >= 0);
			}

			if (wizard1.NextEnabled)
			{
				lastselected = (Data.Alias)lb.SelectedItem;
			}
			else
				lastselected = null;

			UpdateObjectPreview(op1);
		}

		private void cbTask_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (cbTask.SelectedIndex == 1)
			{
				gbRecolor.Visible = false;
				gbClone.Visible = true;
			}
			else
			{
				gbRecolor.Visible = true;
				gbClone.Visible = false;
			}

			if (cbTask.SelectedIndex == 1 && cbDesc.Checked)
			{
				wizard1.FinishEnabled = false;
				wizard1.NextEnabled = (lastselected != null || package != null);
			}
			else
			{
				wizard1.FinishEnabled = (lastselected != null || package != null);
				wizard1.NextEnabled = false;
			}
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			Activate_biNext(biNext, e);
		}

		private void wizardStepPanel2_Activate(
			SimPe.Wizards.Wizard sender,
			SimPe.Wizards.WizardEventArgs e
		)
		{
			package = null;
			if (tv.Visible)
			{
				if (tv.SelectedNode == null)
					e.EnableNext = false;
				else if (tv.SelectedNode.Tag == null)
					e.EnableNext = false;
				else
					e.EnableNext = true;
			}
			else
			{
				e.EnableNext = lb.SelectedIndex >= 0;
			}

			tv.SelectedNode = null;
			lb.SelectedIndex = -1;
		}

		private void wizardStepPanel4_Activate(
			SimPe.Wizards.Wizard sender,
			SimPe.Wizards.WizardEventArgs e
		)
		{
			e.CanFinish = false;
			this.pbWait.Image = null;
			this.lbwait.Visible = true;
			this.lbfinished.Visible = false;
			this.lbfinload.Visible = false;
			this.lberr.Visible = false;
		}

		private void wizardStepPanel4_Activated(
			SimPe.Wizards.Wizard sender,
			SimPe.Wizards.WizardStepPanel step
		)
		{
			this.pbWait.Image = System.Drawing.Image.FromStream(
				this.GetType().Assembly.GetManifestResourceStream("SimPe.img.timer.gif")
			);
			SimPe.Packages.GeneratableFile package = null;
			if (lastselected == null && this.package == null)
			{
				sender.FinishEnabled = false;
			}
			else
			{
				SimPe.Interfaces.IAlias a;
				Interfaces.Files.IPackedFileDescriptor pfd;
				uint localgroup;
				ObjectWorkshopHelper.PrepareForClone(
					this.package,
					this.lastselected,
					out a,
					out localgroup,
					out pfd
				);

				ObjectWorkshopSettings settings;

				//Clone an Object
				if (this.cbTask.SelectedIndex == 1)
				{
					OWCloneSettings cs = new OWCloneSettings();
					cs.IncludeWallmask = this.cbwallmask.Checked;
					cs.OnlyDefaultMmats = this.cbdefault.Checked;
					cs.IncludeAnimationResources = this.cbanim.Checked;
					cs.CustomGroup = this.cbgid.Checked;
					cs.FixResources = this.cbfix.Checked;
					cs.RemoveUselessResource = this.cbclean.Checked;
					cs.StandAloneObject = this.cbparent.Checked;
					cs.RemoveNonDefaultTextReferences = this.cbRemTxt.Checked;
					cs.KeepOriginalMesh = this.cbOrgGmdc.Checked;
					cs.PullResourcesByStr = this.cbstrlink.Checked;

					cs.ChangeObjectDescription = cbDesc.Checked;
					cs.Title = this.tbName.Text;
					cs.Description = this.tbDesc.Text;
					cs.Price = Helper.StringToInt16(this.tbPrice.Text, 0, 10);

					settings = cs;
				}
				else
				{
					//Recolor a Object
					settings = new OWRecolorSettings();
					settings.RemoveNonDefaultTextReferences = false;
				}

				try
				{
					package = ObjectWorkshopHelper.Start(
						this.package,
						a,
						ref pfd,
						localgroup,
						settings,
						onlybase
					);
				}
				catch (Exception ex)
				{
					Helper.ExceptionMessage(ex);
				}
				this.pbWait.Image = null;
				if (package != null)
					this.lbfinload.Visible = settings.RemoteResult;
				else
					this.lberr.Visible = true;
			}

			this.lbwait.Visible = false;
			this.lbfinished.Visible = !this.lbfinload.Visible && !lberr.Visible;
		}

		private void wizardStepPanel3_Activate(
			SimPe.Wizards.Wizard sender,
			SimPe.Wizards.WizardEventArgs e
		)
		{
			e.CanFinish = (
				(lastselected != null || package != null)
				&& this.cbTask.SelectedIndex == 0
				&& !this.cbDesc.Checked
			);
			e.EnableNext = (
				(lastselected != null || package != null)
				&& !(this.cbTask.SelectedIndex == 0 && !this.cbDesc.Checked)
			);
			UpdateObjectPreview(op2);
			UpdateEnabledOptions();
		}

		void UpdateEnabledOptions()
		{
			if (lastselected != null)
			{
				SimPe.Cache.ObjectCacheItem oci = (SimPe.Cache.ObjectCacheItem)
					lastselected.Tag[3];
				if (oci.Class != SimPe.Cache.ObjectClass.Object)
				{
					cbclean.Enabled = false;
					cbdefault.Enabled = false;
					cbparent.Enabled = false;

					cbTask.SelectedIndex = 1;
#if DEBUG
#else
					cbTask.Enabled = false;
#endif
				}
				else
				{
					cbclean.Enabled = true && cbfix.Checked;
					cbdefault.Enabled = true;
					cbparent.Enabled = true;
					cbTask.Enabled = true;
				}
			}
		}

		void UpdateObjectPreview(ObjectPreview op)
		{
			if (lastselected != null)
				op.SetFromObjectCacheItem(
					(SimPe.Cache.ObjectCacheItem)lastselected.Tag[3]
				);
			else if (package != null)
				op.SetFromPackage(package);
			else
				op.SelectedObject = null;
		}

		private void biAbort_Activate(object sender, System.EventArgs e)
		{
			wizard1.JumpToStep(0);
		}

		private void cbfix_CheckedChanged(object sender, System.EventArgs e)
		{
			cbclean.Enabled = cbfix.Checked;
			cbRemTxt.Enabled = cbfix.Checked;
			UpdateEnabledOptions();
		}

		private void wizardStepPanel3_Activated(
			SimPe.Wizards.Wizard sender,
			SimPe.Wizards.WizardStepPanel step
		)
		{
		}

		private void wizardStepPanel5_Activate(
			SimPe.Wizards.Wizard sender,
			SimPe.Wizards.WizardEventArgs e
		)
		{
			e.CanFinish = true;
			e.EnableNext = false;

			this.tbName.Text = this.op2.Title;
			this.tbDesc.Text = this.op2.Description;
			this.tbPrice.Text = this.op2.Price.ToString();
		}

		private void wizardStepPanel5_Activated(
			SimPe.Wizards.Wizard sender,
			SimPe.Wizards.WizardStepPanel step
		)
		{
		}

		private void wizard1_PrepareStep(
			SimPe.Wizards.Wizard sender,
			SimPe.Wizards.WizardStepPanel step,
			int target
		)
		{
		}

		private void wizard1_ShowedStep(SimPe.Wizards.Wizard sender, int source)
		{
			if (
				sender.CurrentStep == this.wizardStepPanel5
				&& (this.cbTask.SelectedIndex == 0 || this.cbDesc.Checked == false)
			)
			{
				if (source < sender.CurrentStep.Index)
					wizard1.GoNext();
				else
					wizard1.GoPrev();
			}
		}

		private void cbDesc_CheckedChanged(object sender, System.EventArgs e)
		{
			cbTask_SelectedIndexChanged(this.cbTask, null);
		}

		private void lberr_Click(object sender, System.EventArgs e)
		{
		}

		bool onlybase;

		private void button4_Click(object sender, System.EventArgs e)
		{
			lastselected = null;
			this.tv.SelectedNode = null;
			onlybase = false;
			package = ObjectWorkshopHelper.CreatCloneByGroup(
				Helper.StringToUInt32(tbGroup.Text, 0x7f000000, 16)
			);

			wizard1.JumpToStep(2);
		}

		private void button5_Click(object sender, System.EventArgs e)
		{
			lastselected = null;
			this.tv.SelectedNode = null;
			onlybase = false;
			package = ObjectWorkshopHelper.CreatCloneByCres(this.tbCresName.Text);

			wizard1.JumpToStep(2);
		}

		private void button6_Click(object sender, System.EventArgs e)
		{
			lastselected = null;
			this.tv.SelectedNode = null;
			onlybase = false;
			package = ObjectWorkshopHelper.CreatCloneByGuid(
				Helper.StringToUInt32(this.tbGUID.Text, 0x00000000, 16)
			);

			wizard1.JumpToStep(2);
		}

		private void xpTaskBoxSimple1_Resize(object sender, EventArgs e)
		{
			this.op2.Size = new System.Drawing.Size(
				this.xpTaskBoxSimple1.Width - 16,
				this.xpTaskBoxSimple1.Height - 56
			);
		}

		private void xpTaskBoxSimple2_Resize(object sender, EventArgs e)
		{
			this.op1.Size = new System.Drawing.Size(
				this.xpTaskBoxSimple2.Width - 16,
				this.xpTaskBoxSimple2.Height - 56
			);
		}

		private void SetDefaultsForClone(object sender, LinkLabelLinkClickedEventArgs e)
		{
			registry.SetDefaults();
		}
	}
}
