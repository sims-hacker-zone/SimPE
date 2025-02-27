using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimPe.Plugin.Tool.Dockable
{
	/// <summary>
	/// Summary description for DoackableObjectWorkshop.
	/// </summary>
	public class dcObjectWorkshop : Ambertation.Windows.Forms.DockPanel
	{
		class MyTreeView : TreeView
		{
			public MyTreeView()
				: base() { }

			public void DoBeginUpdate()
			{
				BeginUpdate();
				//this.Visible = false;
			}

			public void DoEndUpdate(bool vis)
			{
				EndUpdate();
				//this.Visible = vis;
			}
		}

		private SteepValley.Windows.Forms.XPGradientPanel xpGradientPanel1;
		private Wizards.Wizard wizard1;
		private Wizards.WizardStepPanel wizardStepPanel1;
		private Button button2;
		private Label label1;
		private Label label2;
		private Button button1;
		private Wizards.WizardStepPanel wizardStepPanel2;
		private ListBox lb;
		private MyTreeView tv;
		private Splitter splitter1;
		private Panel panel1;
		private Ambertation.Windows.Forms.XPTaskBoxSimple xpTaskBoxSimple2;
		private Wizards.WizardStepPanel wizardStepPanel3;
		private Ambertation.Windows.Forms.XPTaskBoxSimple xpTaskBoxSimple1;
		private Ambertation.Windows.Forms.XPTaskBoxSimple gbRecolor;
		private CheckBox cbColorExt;
		private Ambertation.Windows.Forms.XPTaskBoxSimple gbClone;
		internal CheckBox cbanim;
		internal CheckBox cbwallmask;
		internal CheckBox cbparent;
		internal CheckBox cbclean;
		internal CheckBox cbfix;
		internal CheckBox cbdefault;
		internal CheckBox cbgid;
		private Panel panel2;
		private Button button3;
		internal ComboBox cbTask;
		private Label label3;
		private Wizards.WizardStepPanel wizardStepPanel4;
		private Panel pnWait;
		private Label lberr;
		private Label lbfinload;
		private Label lbwait;
		private PictureBox pbWait;
		private Label lbfinished;
		private Label label4;
		private ImageList ilist;
		private ObjectPreview op1;
		private ObjectPreview op2;
		internal CheckBox cbRemTxt;
		internal CheckBox cbOrgGmdc;
		private Wizards.WizardStepPanel wizardStepPanel5;
		private Ambertation.Windows.Forms.XPTaskBoxSimple xpTaskBoxSimple3;
		private Label label5;
		private Label label6;
		private Label label7;
		private TextBox tbName;
		private TextBox tbPrice;
		private RichTextBox tbDesc;
		internal CheckBox cbDesc;
		internal CheckBox cbstrlink;
		private System.ComponentModel.IContainer components;
		private Button button4;
		private Ambertation.Windows.Forms.XPTaskBoxSimple xpAdvanced;
		private TextBox tbGroup;
		private Button button5;
		private TextBox tbCresName;
		private Button button6;
		private TextBox tbGUID;
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
			xpAdvanced.Visible = (UserVerification.HaveUserId);
			op1 = new ObjectPreview();
			op2 = new ObjectPreview();
			// op1.SuspendLayout(); - (prevented op1 layout, causung the title to be scrolled and the description to be cut off) Chris Hatch
			//
			// op1
			//
			op1.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			op1.BackColor = Color.Transparent;
			op1.Font = new Font("Tahoma", 8.25F);
			op1.LoadCustomImage = true;
			op1.Location = new Point(8, 44);
			op1.Name = "op1";
			op1.SelectedObject = null;
			op1.Size = new Size(
				xpTaskBoxSimple2.Width - 16,
				xpTaskBoxSimple2.Height - 56
			);
			op1.TabIndex = 0;
			xpTaskBoxSimple2.Controls.Add(op1);
			xpTaskBoxSimple2.Resize += new EventHandler(xpTaskBoxSimple2_Resize);
			// op2.ResumeLayout(); - (op2 layout was never suspended) Chris Hatch
			//
			// op2
			//
			op2.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			op2.BackColor = Color.Transparent;
			op2.Font = new Font("Tahoma", 8.25F);
			op2.LoadCustomImage = true;
			op2.Location = new Point(8, 44);
			op2.Name = "op2";
			op2.SelectedObject = null;
			op2.Size = new Size(
				xpTaskBoxSimple1.Width - 16,
				xpTaskBoxSimple1.Height - 56
			);
			op2.TabIndex = 1;
			xpTaskBoxSimple1.Controls.Add(op2);
			xpTaskBoxSimple1.Resize += new EventHandler(xpTaskBoxSimple1_Resize);

			//do the regular initialization Work
			wizard1.Start();

			biFinish.Visible = wizard1.FinishEnabled;
			biAbort.Visible = wizard1.PrevEnabled;
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
				{
					registry.Dispose();
				}

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
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(
					typeof(dcObjectWorkshop)
				);
			xpGradientPanel1 = new SteepValley.Windows.Forms.XPGradientPanel();
			wizard1 = new Wizards.Wizard();
			wizardStepPanel1 = new Wizards.WizardStepPanel();
			xpAdvanced = new Ambertation.Windows.Forms.XPTaskBoxSimple();
			button6 = new Button();
			tbGUID = new TextBox();
			button5 = new Button();
			tbCresName = new TextBox();
			button4 = new Button();
			tbGroup = new TextBox();
			label4 = new Label();
			button2 = new Button();
			label1 = new Label();
			button1 = new Button();
			label2 = new Label();
			wizardStepPanel2 = new Wizards.WizardStepPanel();
			lb = new ListBox();
			tv = new MyTreeView();
			splitter1 = new Splitter();
			panel1 = new Panel();
			xpTaskBoxSimple2 = new Ambertation.Windows.Forms.XPTaskBoxSimple();
			wizardStepPanel3 = new Wizards.WizardStepPanel();
			xpTaskBoxSimple1 = new Ambertation.Windows.Forms.XPTaskBoxSimple();
			gbRecolor = new Ambertation.Windows.Forms.XPTaskBoxSimple();
			cbColorExt = new CheckBox();
			gbClone = new Ambertation.Windows.Forms.XPTaskBoxSimple();
			llCloneDef = new LinkLabel();
			cbstrlink = new CheckBox();
			cbDesc = new CheckBox();
			cbOrgGmdc = new CheckBox();
			cbRemTxt = new CheckBox();
			cbanim = new CheckBox();
			cbwallmask = new CheckBox();
			cbparent = new CheckBox();
			cbclean = new CheckBox();
			cbfix = new CheckBox();
			cbdefault = new CheckBox();
			cbgid = new CheckBox();
			panel2 = new Panel();
			button3 = new Button();
			cbTask = new ComboBox();
			label3 = new Label();
			wizardStepPanel5 = new Wizards.WizardStepPanel();
			xpTaskBoxSimple3 = new Ambertation.Windows.Forms.XPTaskBoxSimple();
			tbDesc = new RichTextBox();
			tbPrice = new TextBox();
			tbName = new TextBox();
			label7 = new Label();
			label6 = new Label();
			label5 = new Label();
			wizardStepPanel4 = new Wizards.WizardStepPanel();
			pnWait = new Panel();
			pbWait = new PictureBox();
			lbfinished = new Label();
			lberr = new Label();
			lbfinload = new Label();
			lbwait = new Label();
			toolStrip1 = new ToolStrip();
			biPrev = new ToolStripButton();
			biNext = new ToolStripButton();
			biFinish = new ToolStripButton();
			biAbort = new ToolStripButton();
			biCatalog = new ToolStripButton();
			ilist = new ImageList(components);
			toolTip1 = new ToolTip(components);
			xpGradientPanel1.SuspendLayout();
			wizard1.SuspendLayout();
			wizardStepPanel1.SuspendLayout();
			xpAdvanced.SuspendLayout();
			wizardStepPanel2.SuspendLayout();
			panel1.SuspendLayout();
			wizardStepPanel3.SuspendLayout();
			gbRecolor.SuspendLayout();
			gbClone.SuspendLayout();
			panel2.SuspendLayout();
			wizardStepPanel5.SuspendLayout();
			xpTaskBoxSimple3.SuspendLayout();
			wizardStepPanel4.SuspendLayout();
			pnWait.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(pbWait)).BeginInit();
			toolStrip1.SuspendLayout();
			SuspendLayout();
			//
			// xpGradientPanel1
			//
			xpGradientPanel1.BackColor = Color.Transparent;
			xpGradientPanel1.Controls.Add(wizard1);
			xpGradientPanel1.Controls.Add(toolStrip1);
			resources.ApplyResources(xpGradientPanel1, "xpGradientPanel1");
			xpGradientPanel1.Name = "xpGradientPanel1";
			//
			// wizard1
			//
			wizard1.BackColor = Color.Transparent;
			wizard1.Controls.Add(wizardStepPanel1);
			wizard1.Controls.Add(wizardStepPanel2);
			wizard1.Controls.Add(wizardStepPanel3);
			wizard1.Controls.Add(wizardStepPanel5);
			wizard1.Controls.Add(wizardStepPanel4);
			wizard1.CurrentStepNumber = 0;
			resources.ApplyResources(wizard1, "wizard1");
			wizard1.FinishEnabled = false;
			wizard1.Image = null;
			wizard1.Name = "wizard1";
			wizard1.NextEnabled = false;
			wizard1.PrevEnabled = false;
			wizard1.ChangedFinishState += new Wizards.WizardHandle(
				wizard1_ChangedFinishState
			);
			wizard1.ShowStep += new Wizards.WizardChangeHandle(
				wizard1_ShowStep
			);
			wizard1.ChangedPrevState += new Wizards.WizardHandle(
				wizard1_ChangedPrevState
			);
			wizard1.PrepareStep += new Wizards.WizardStepChangeHandle(
				wizard1_PrepareStep
			);
			wizard1.ChangedNextState += new Wizards.WizardHandle(
				wizard1_ChangedNextState
			);
			wizard1.ShowedStep += new Wizards.WizardShowedHandle(
				wizard1_ShowedStep
			);
			//
			// wizardStepPanel1
			//
			wizardStepPanel1.BackColor = Color.Transparent;
			wizardStepPanel1.Controls.Add(xpAdvanced);
			wizardStepPanel1.Controls.Add(label4);
			wizardStepPanel1.Controls.Add(button2);
			wizardStepPanel1.Controls.Add(label1);
			wizardStepPanel1.Controls.Add(button1);
			wizardStepPanel1.Controls.Add(label2);
			resources.ApplyResources(wizardStepPanel1, "wizardStepPanel1");
			wizardStepPanel1.First = false;
			wizardStepPanel1.Last = false;
			wizardStepPanel1.Name = "wizardStepPanel1";
			//
			// xpAdvanced
			//
			xpAdvanced.BackColor = Color.Transparent;
			xpAdvanced.Controls.Add(button6);
			xpAdvanced.Controls.Add(tbGUID);
			xpAdvanced.Controls.Add(button5);
			xpAdvanced.Controls.Add(tbCresName);
			xpAdvanced.Controls.Add(button4);
			xpAdvanced.Controls.Add(tbGroup);
			xpAdvanced.HeaderFont = new Font(
				"Microsoft Sans Serif",
				10.25F,
				FontStyle.Bold
			);
			resources.ApplyResources(xpAdvanced, "xpAdvanced");
			xpAdvanced.IconLocation = new Point(4, 12);
			xpAdvanced.IconSize = new Size(32, 32);
			xpAdvanced.Name = "xpAdvanced";
			//
			// button6
			//
			resources.ApplyResources(button6, "button6");
			button6.Name = "button6";
			button6.Click += new EventHandler(button6_Click);
			//
			// tbGUID
			//
			resources.ApplyResources(tbGUID, "tbGUID");
			tbGUID.Name = "tbGUID";
			//
			// button5
			//
			resources.ApplyResources(button5, "button5");
			button5.Name = "button5";
			button5.Click += new EventHandler(button5_Click);
			//
			// tbCresName
			//
			resources.ApplyResources(tbCresName, "tbCresName");
			tbCresName.Name = "tbCresName";
			//
			// button4
			//
			resources.ApplyResources(button4, "button4");
			button4.Name = "button4";
			button4.Click += new EventHandler(button4_Click);
			//
			// tbGroup
			//
			resources.ApplyResources(tbGroup, "tbGroup");
			tbGroup.Name = "tbGroup";
			//
			// label4
			//
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			//
			// button2
			//
			resources.ApplyResources(button2, "button2");
			button2.Name = "button2";
			button2.Click += new EventHandler(button2_Click);
			//
			// label1
			//
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			//
			// button1
			//
			resources.ApplyResources(button1, "button1");
			button1.Name = "button1";
			button1.Click += new EventHandler(button1_Click);
			//
			// label2
			//
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			//
			// wizardStepPanel2
			//
			wizardStepPanel2.BackColor = Color.Transparent;
			wizardStepPanel2.Controls.Add(lb);
			wizardStepPanel2.Controls.Add(tv);
			wizardStepPanel2.Controls.Add(splitter1);
			wizardStepPanel2.Controls.Add(panel1);
			resources.ApplyResources(wizardStepPanel2, "wizardStepPanel2");
			wizardStepPanel2.First = false;
			wizardStepPanel2.Last = false;
			wizardStepPanel2.Name = "wizardStepPanel2";
			wizardStepPanel2.Activate += new Wizards.WizardChangeHandle(
				wizardStepPanel2_Activate
			);
			wizardStepPanel2.Prepare += new Wizards.WizardStepChangeHandle(
				wizardStepPanel2_Prepare
			);
			//
			// lb
			//
			lb.BorderStyle = BorderStyle.None;
			resources.ApplyResources(lb, "lb");
			lb.Name = "lb";
			lb.SelectedIndexChanged += new EventHandler(
				lb_SelectedIndexChanged
			);
			//
			// tv
			//
			tv.BorderStyle = BorderStyle.None;
			resources.ApplyResources(tv, "tv");
			tv.ItemHeight = 17;
			tv.Name = "tv";
			tv.AfterSelect += new TreeViewEventHandler(
				tv_AfterSelect
			);
			//
			// splitter1
			//
			splitter1.BackColor = SystemColors.Highlight;
			resources.ApplyResources(splitter1, "splitter1");
			splitter1.Name = "splitter1";
			splitter1.TabStop = false;
			//
			// panel1
			//
			panel1.Controls.Add(xpTaskBoxSimple2);
			resources.ApplyResources(panel1, "panel1");
			panel1.Name = "panel1";
			//
			// xpTaskBoxSimple2
			//
			xpTaskBoxSimple2.BackColor = Color.Transparent;
			resources.ApplyResources(xpTaskBoxSimple2, "xpTaskBoxSimple2");
			xpTaskBoxSimple2.HeaderFont = new Font(
				"Microsoft Sans Serif",
				10.25F,
				FontStyle.Bold
			);
			xpTaskBoxSimple2.IconLocation = new Point(4, 12);
			xpTaskBoxSimple2.IconSize = new Size(32, 32);
			xpTaskBoxSimple2.Name = "xpTaskBoxSimple2";
			//
			// wizardStepPanel3
			//
			wizardStepPanel3.BackColor = Color.Transparent;
			wizardStepPanel3.Controls.Add(xpTaskBoxSimple1);
			wizardStepPanel3.Controls.Add(gbRecolor);
			wizardStepPanel3.Controls.Add(gbClone);
			wizardStepPanel3.Controls.Add(panel2);
			resources.ApplyResources(wizardStepPanel3, "wizardStepPanel3");
			wizardStepPanel3.First = false;
			wizardStepPanel3.Last = false;
			wizardStepPanel3.Name = "wizardStepPanel3";
			wizardStepPanel3.Activate += new Wizards.WizardChangeHandle(
				wizardStepPanel3_Activate
			);
			wizardStepPanel3.Activated += new Wizards.WizardStepHandle(
				wizardStepPanel3_Activated
			);
			//
			// xpTaskBoxSimple1
			//
			xpTaskBoxSimple1.BackColor = Color.Transparent;
			resources.ApplyResources(xpTaskBoxSimple1, "xpTaskBoxSimple1");
			xpTaskBoxSimple1.HeaderFont = new Font(
				"Microsoft Sans Serif",
				10.25F,
				FontStyle.Bold
			);
			xpTaskBoxSimple1.IconLocation = new Point(4, 12);
			xpTaskBoxSimple1.IconSize = new Size(32, 32);
			xpTaskBoxSimple1.Name = "xpTaskBoxSimple1";
			//
			// gbRecolor
			//
			gbRecolor.BackColor = Color.Transparent;
			gbRecolor.Controls.Add(cbColorExt);
			resources.ApplyResources(gbRecolor, "gbRecolor");
			gbRecolor.HeaderFont = new Font(
				"Microsoft Sans Serif",
				10.25F,
				FontStyle.Bold
			);
			gbRecolor.IconLocation = new Point(4, 12);
			gbRecolor.IconSize = new Size(32, 32);
			gbRecolor.Name = "gbRecolor";
			//
			// cbColorExt
			//
			cbColorExt.Checked = true;
			cbColorExt.CheckState = CheckState.Checked;
			resources.ApplyResources(cbColorExt, "cbColorExt");
			cbColorExt.Name = "cbColorExt";
			cbColorExt.UseVisualStyleBackColor = false;
			//
			// gbClone
			//
			gbClone.BackColor = Color.Transparent;
			gbClone.Controls.Add(llCloneDef);
			gbClone.Controls.Add(cbstrlink);
			gbClone.Controls.Add(cbDesc);
			gbClone.Controls.Add(cbOrgGmdc);
			gbClone.Controls.Add(cbRemTxt);
			gbClone.Controls.Add(cbanim);
			gbClone.Controls.Add(cbwallmask);
			gbClone.Controls.Add(cbparent);
			gbClone.Controls.Add(cbclean);
			gbClone.Controls.Add(cbfix);
			gbClone.Controls.Add(cbdefault);
			gbClone.Controls.Add(cbgid);
			resources.ApplyResources(gbClone, "gbClone");
			gbClone.HeaderFont = new Font(
				"Microsoft Sans Serif",
				10.25F,
				FontStyle.Bold
			);
			gbClone.IconLocation = new Point(4, 0);
			gbClone.IconSize = new Size(32, 32);
			gbClone.Name = "gbClone";
			//
			// llCloneDef
			//
			resources.ApplyResources(llCloneDef, "llCloneDef");
			//this.llCloneDef.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			llCloneDef.Name = "llCloneDef";
			llCloneDef.TabStop = true;
			llCloneDef.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					SetDefaultsForClone
				);
			//
			// cbstrlink
			//
			resources.ApplyResources(cbstrlink, "cbstrlink");
			cbstrlink.Name = "cbstrlink";
			toolTip1.SetToolTip(
				cbstrlink,
				resources.GetString("cbstrlink.ToolTip")
			);
			cbstrlink.UseVisualStyleBackColor = false;
			//
			// cbDesc
			//
			cbDesc.Checked = true;
			cbDesc.CheckState = CheckState.Checked;
			resources.ApplyResources(cbDesc, "cbDesc");
			cbDesc.Name = "cbDesc";
			toolTip1.SetToolTip(
				cbDesc,
				resources.GetString("cbDesc.ToolTip")
			);
			cbDesc.UseVisualStyleBackColor = false;
			cbDesc.CheckedChanged += new EventHandler(
				cbDesc_CheckedChanged
			);
			//
			// cbOrgGmdc
			//
			resources.ApplyResources(cbOrgGmdc, "cbOrgGmdc");
			cbOrgGmdc.Name = "cbOrgGmdc";
			toolTip1.SetToolTip(
				cbOrgGmdc,
				resources.GetString("cbOrgGmdc.ToolTip")
			);
			cbOrgGmdc.UseVisualStyleBackColor = false;
			//
			// cbRemTxt
			//
			cbRemTxt.Checked = true;
			cbRemTxt.CheckState = CheckState.Checked;
			resources.ApplyResources(cbRemTxt, "cbRemTxt");
			cbRemTxt.Name = "cbRemTxt";
			toolTip1.SetToolTip(
				cbRemTxt,
				resources.GetString("cbRemTxt.ToolTip")
			);
			cbRemTxt.UseVisualStyleBackColor = false;
			//
			// cbanim
			//
			resources.ApplyResources(cbanim, "cbanim");
			cbanim.Name = "cbanim";
			toolTip1.SetToolTip(
				cbanim,
				resources.GetString("cbanim.ToolTip")
			);
			cbanim.UseVisualStyleBackColor = false;
			//
			// cbwallmask
			//
			cbwallmask.Checked = true;
			cbwallmask.CheckState = CheckState.Checked;
			resources.ApplyResources(cbwallmask, "cbwallmask");
			cbwallmask.Name = "cbwallmask";
			toolTip1.SetToolTip(
				cbwallmask,
				resources.GetString("cbwallmask.ToolTip")
			);
			cbwallmask.UseVisualStyleBackColor = false;
			//
			// cbparent
			//
			resources.ApplyResources(cbparent, "cbparent");
			cbparent.Name = "cbparent";
			toolTip1.SetToolTip(
				cbparent,
				resources.GetString("cbparent.ToolTip")
			);
			cbparent.UseVisualStyleBackColor = false;
			//
			// cbclean
			//
			cbclean.Checked = true;
			cbclean.CheckState = CheckState.Checked;
			resources.ApplyResources(cbclean, "cbclean");
			cbclean.Name = "cbclean";
			toolTip1.SetToolTip(
				cbclean,
				resources.GetString("cbclean.ToolTip")
			);
			cbclean.UseVisualStyleBackColor = false;
			//
			// cbfix
			//
			cbfix.Checked = true;
			cbfix.CheckState = CheckState.Checked;
			resources.ApplyResources(cbfix, "cbfix");
			cbfix.Name = "cbfix";
			toolTip1.SetToolTip(cbfix, resources.GetString("cbfix.ToolTip"));
			cbfix.UseVisualStyleBackColor = false;
			cbfix.CheckedChanged += new EventHandler(
				cbfix_CheckedChanged
			);
			//
			// cbdefault
			//
			cbdefault.Checked = true;
			cbdefault.CheckState = CheckState.Checked;
			resources.ApplyResources(cbdefault, "cbdefault");
			cbdefault.Name = "cbdefault";
			toolTip1.SetToolTip(
				cbdefault,
				resources.GetString("cbdefault.ToolTip")
			);
			cbdefault.UseVisualStyleBackColor = false;
			//
			// cbgid
			//
			cbgid.Checked = true;
			cbgid.CheckState = CheckState.Checked;
			resources.ApplyResources(cbgid, "cbgid");
			cbgid.Name = "cbgid";
			toolTip1.SetToolTip(cbgid, resources.GetString("cbgid.ToolTip"));
			cbgid.UseVisualStyleBackColor = false;
			//
			// panel2
			//
			panel2.Controls.Add(button3);
			panel2.Controls.Add(cbTask);
			panel2.Controls.Add(label3);
			resources.ApplyResources(panel2, "panel2");
			panel2.Name = "panel2";
			//
			// button3
			//
			resources.ApplyResources(button3, "button3");
			button3.Name = "button3";
			button3.Click += new EventHandler(button3_Click);
			//
			// cbTask
			//
			resources.ApplyResources(cbTask, "cbTask");
			cbTask.DropDownStyle = ComboBoxStyle.DropDownList;
			cbTask.ForeColor = SystemColors.ControlText;
			cbTask.Items.AddRange(
				new object[]
				{
					resources.GetString("cbTask.Items"),
					resources.GetString("cbTask.Items1"),
				}
			);
			cbTask.Name = "cbTask";
			cbTask.SelectedIndexChanged += new EventHandler(
				cbTask_SelectedIndexChanged
			);
			//
			// label3
			//
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			//
			// wizardStepPanel5
			//
			wizardStepPanel5.BackColor = Color.Transparent;
			wizardStepPanel5.Controls.Add(xpTaskBoxSimple3);
			resources.ApplyResources(wizardStepPanel5, "wizardStepPanel5");
			wizardStepPanel5.First = false;
			wizardStepPanel5.Last = false;
			wizardStepPanel5.Name = "wizardStepPanel5";
			wizardStepPanel5.Activate += new Wizards.WizardChangeHandle(
				wizardStepPanel5_Activate
			);
			wizardStepPanel5.Activated += new Wizards.WizardStepHandle(
				wizardStepPanel5_Activated
			);
			//
			// xpTaskBoxSimple3
			//
			xpTaskBoxSimple3.BackColor = Color.Transparent;
			xpTaskBoxSimple3.Controls.Add(tbDesc);
			xpTaskBoxSimple3.Controls.Add(tbPrice);
			xpTaskBoxSimple3.Controls.Add(tbName);
			xpTaskBoxSimple3.Controls.Add(label7);
			xpTaskBoxSimple3.Controls.Add(label6);
			xpTaskBoxSimple3.Controls.Add(label5);
			resources.ApplyResources(xpTaskBoxSimple3, "xpTaskBoxSimple3");
			xpTaskBoxSimple3.HeaderFont = new Font(
				"Microsoft Sans Serif",
				10.25F,
				FontStyle.Bold
			);
			xpTaskBoxSimple3.IconLocation = new Point(4, 12);
			xpTaskBoxSimple3.IconSize = new Size(32, 32);
			xpTaskBoxSimple3.Name = "xpTaskBoxSimple3";
			//
			// tbDesc
			//
			resources.ApplyResources(tbDesc, "tbDesc");
			tbDesc.BorderStyle = BorderStyle.None;
			tbDesc.Name = "tbDesc";
			//
			// tbPrice
			//
			resources.ApplyResources(tbPrice, "tbPrice");
			tbPrice.Name = "tbPrice";
			//
			// tbName
			//
			resources.ApplyResources(tbName, "tbName");
			tbName.Name = "tbName";
			//
			// label7
			//
			resources.ApplyResources(label7, "label7");
			label7.Name = "label7";
			//
			// label6
			//
			resources.ApplyResources(label6, "label6");
			label6.Name = "label6";
			//
			// label5
			//
			resources.ApplyResources(label5, "label5");
			label5.Name = "label5";
			//
			// wizardStepPanel4
			//
			wizardStepPanel4.BackColor = Color.Transparent;
			wizardStepPanel4.Controls.Add(pnWait);
			resources.ApplyResources(wizardStepPanel4, "wizardStepPanel4");
			wizardStepPanel4.First = false;
			wizardStepPanel4.Last = true;
			wizardStepPanel4.Name = "wizardStepPanel4";
			wizardStepPanel4.Activate += new Wizards.WizardChangeHandle(
				wizardStepPanel4_Activate
			);
			wizardStepPanel4.Activated += new Wizards.WizardStepHandle(
				wizardStepPanel4_Activated
			);
			//
			// pnWait
			//
			pnWait.Controls.Add(pbWait);
			pnWait.Controls.Add(lbfinished);
			pnWait.Controls.Add(lberr);
			pnWait.Controls.Add(lbfinload);
			pnWait.Controls.Add(lbwait);
			resources.ApplyResources(pnWait, "pnWait");
			pnWait.Name = "pnWait";
			//
			// pbWait
			//
			resources.ApplyResources(pbWait, "pbWait");
			pbWait.Name = "pbWait";
			pbWait.TabStop = false;
			//
			// lbfinished
			//
			resources.ApplyResources(lbfinished, "lbfinished");
			lbfinished.Name = "lbfinished";
			//
			// lberr
			//
			resources.ApplyResources(lberr, "lberr");
			lberr.Name = "lberr";
			lberr.Click += new EventHandler(lberr_Click);
			//
			// lbfinload
			//
			resources.ApplyResources(lbfinload, "lbfinload");
			lbfinload.Name = "lbfinload";
			//
			// lbwait
			//
			resources.ApplyResources(lbwait, "lbwait");
			lbwait.Name = "lbwait";
			//
			// toolStrip1
			//
			toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
			toolStrip1.Items.AddRange(
				new ToolStripItem[]
				{
					biPrev,
					biNext,
					biFinish,
					biAbort,
					biCatalog,
				}
			);
			toolStrip1.LayoutStyle =
				ToolStripLayoutStyle
				.HorizontalStackWithOverflow;
			resources.ApplyResources(toolStrip1, "toolStrip1");
			toolStrip1.Name = "toolStrip1";
			toolStrip1.ShowItemToolTips = false;
			//
			// biPrev
			//
			resources.ApplyResources(biPrev, "biPrev");
			biPrev.Name = "biPrev";
			biPrev.Click += new EventHandler(Activate_biPrev);
			//
			// biNext
			//
			resources.ApplyResources(biNext, "biNext");
			biNext.Name = "biNext";
			biNext.Click += new EventHandler(Activate_biNext);
			//
			// biFinish
			//
			resources.ApplyResources(biFinish, "biFinish");
			biFinish.Name = "biFinish";
			biFinish.Click += new EventHandler(ActivateFinish);
			//
			// biAbort
			//
			resources.ApplyResources(biAbort, "biAbort");
			biAbort.Name = "biAbort";
			biAbort.Click += new EventHandler(biAbort_Activate);
			//
			// biCatalog
			//
			biCatalog.Alignment =
				ToolStripItemAlignment
				.Right;
			biCatalog.Checked = true;
			biCatalog.CheckOnClick = true;
			biCatalog.CheckState = CheckState.Checked;
			biCatalog.DisplayStyle =
				ToolStripItemDisplayStyle
				.Text;
			resources.ApplyResources(biCatalog, "biCatalog");
			biCatalog.Name = "biCatalog";
			biCatalog.Click += new EventHandler(Activate_biCatalog);
			//
			// ilist
			//
			ilist.ColorDepth = ColorDepth.Depth32Bit;
			resources.ApplyResources(ilist, "ilist");
			ilist.TransparentColor = Color.Transparent;
			//
			// dcObjectWorkshop
			//
			resources.ApplyResources(this, "$this");
			Controls.Add(xpGradientPanel1);
			FloatingSize = new Size(640, 480);
			Image = ((Image)(resources.GetObject("$this.Image")));
			MinimumSize = new Size(640, 480);
			Name = "dcObjectWorkshop";
			TabImage = (
				(Image)(resources.GetObject("$this.TabImage"))
			);
			TabText = "Object Workshop";
			xpGradientPanel1.ResumeLayout(false);
			xpGradientPanel1.PerformLayout();
			wizard1.ResumeLayout(false);
			wizardStepPanel1.ResumeLayout(false);
			xpAdvanced.ResumeLayout(false);
			xpAdvanced.PerformLayout();
			wizardStepPanel2.ResumeLayout(false);
			panel1.ResumeLayout(false);
			wizardStepPanel3.ResumeLayout(false);
			gbRecolor.ResumeLayout(false);
			gbClone.ResumeLayout(false);
			gbClone.PerformLayout();
			panel2.ResumeLayout(false);
			wizardStepPanel5.ResumeLayout(false);
			xpTaskBoxSimple3.ResumeLayout(false);
			xpTaskBoxSimple3.PerformLayout();
			wizardStepPanel4.ResumeLayout(false);
			pnWait.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(pbWait)).EndInit();
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			ResumeLayout(false);
		}
		#endregion

		private void wizard1_ChangedFinishState(Wizards.Wizard sender)
		{
			biFinish.Visible = sender.FinishEnabled;
		}

		private void wizard1_ChangedNextState(Wizards.Wizard sender)
		{
			biNext.Enabled = sender.NextEnabled;
		}

		private void wizard1_ChangedPrevState(Wizards.Wizard sender)
		{
			biPrev.Enabled = sender.PrevEnabled;
			biAbort.Visible = biPrev.Enabled;
		}

		private void Activate_biPrev(object sender, EventArgs e)
		{
			wizard1.GoPrev();
		}

		private void Activate_biNext(object sender, EventArgs e)
		{
			wizard1.GoNext();
		}

		private void ActivateFinish(object sender, EventArgs e)
		{
			if (
				wizard1.CurrentStep == wizardStepPanel3
				|| wizard1.CurrentStep == wizardStepPanel5
			)
			{
				Activate_biNext(sender, e);
			}
			else
			{
				wizard1.Finish();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			onlybase = false;
			Activate_biNext(biNext, e);
		}

		delegate void TreeViewSetUpdateHandler(TreeView tv, bool begin);

		protected TreeNode RootNode;

		private void wizardStepPanel2_Prepare(
			Wizards.Wizard sender,
			Wizards.WizardStepPanel step,
			int target
		)
		{
			if (target == step.Index)
			{
				onlybase = false;
				if (lb.Items.Count == 0 && tv.Nodes.Count == 0)
				{
					if (RootNode == null)
					{
						RootNode = new TreeNode();
					}

					tv.Enabled = false;
					lb.Enabled = false;
					lastselected = null;
					ilist.Images.Clear();
					ilist.Images.Add(
						new Bitmap(
							GetType()
								.Assembly.GetManifestResourceStream(
									"SimPe.img.subitems.png"
								)
						)
					);
					ilist.Images.Add(
						new Bitmap(
							GetType()
								.Assembly.GetManifestResourceStream(
									"SimPe.img.nothumb.png"
								)
						)
					);
					ilist.Images.Add(
						new Bitmap(
							GetType()
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
						new ObjectLoader.LoadItemHandler(
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
			Cache.ObjectCacheItem oci,
			Data.Alias a,
			ImageList ilist
		);

		private void ol_LoadedItem(
			Cache.ObjectCacheItem oci,
			Interfaces.Scenegraph.IScenegraphFileIndexItem fii,
			Data.Alias a
		)
		{
			if (a == null)
			{
				return;
			}

			if (
				oci.Class == Cache.ObjectClass.XObject
				&& !Helper.WindowsRegistry.OWincludewalls
			)
			{
				return;
			}

			string[][] cats = oci.ObjectCategory;
			foreach (string[] ss in cats)
			{
				tv.Invoke(
					new GetParentNodeHandler(ObjectLoader.GetParentNode),
					new object[] { RootNode.Nodes, ss, 0, oci, a, ilist }
				);
			}

			lb.Invoke(new EventHandler(AddItemToListBox), new object[] { a });
		}

		private void AddItemToListBox(object obj, EventArgs e)
		{
			lb.Items.Add(obj);
		}

		private void ol_Finished(object sender, EventArgs e)
		{
			if (tv.InvokeRequired)
			{
				tv.Invoke(
					new EventHandler(invoke_ol_Finished),
					new object[] { sender, e }
				);
			}
			else
			{
				invoke_ol_Finished(sender, e);
			}
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

		private void Activate_biCatalog(object sender, EventArgs e)
		{
			tv.Visible = biCatalog.Checked;
			lb.Visible = !biCatalog.Checked;

			lb_SelectedIndexChanged(lb, null);
			tv_AfterSelect(tv, null);
		}

		private void wizard1_ShowStep(
			Wizards.Wizard sender,
			Wizards.WizardEventArgs e
		)
		{
			biCatalog.Visible = (e.Step.Index == wizardStepPanel2.Index);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			onlybase = false;
			OpenFileDialog ofd = new OpenFileDialog
			{
				Filter = ExtensionProvider.BuildFilterString(
				new ExtensionType[]
				{
					ExtensionType.Package,
					ExtensionType.DisabledPackage,
					ExtensionType.AllFiles,
				}
			)
			};

			package = null;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				package = Packages.File.LoadFromFile(ofd.FileName);
				wizard1.JumpToStep(2);
			}
		}

		Packages.GeneratableFile package;
		Data.Alias lastselected;

		private void tv_AfterSelect(
			object sender,
			TreeViewEventArgs e
		)
		{
			if (wizard1.CurrentStepNumber == wizardStepPanel2.Index && tv.Visible)
			{
				if (tv.SelectedNode == null)
				{
					wizard1.NextEnabled = false;
				}
				else
				{
					wizard1.NextEnabled = tv.SelectedNode.Tag != null;
				}
			}

			if (wizard1.NextEnabled)
			{
				lastselected = (Data.Alias)tv.SelectedNode.Tag;
			}
			else
			{
				lastselected = null;
			}

			UpdateObjectPreview(op1);
		}

		private void lb_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (wizard1.CurrentStepNumber == wizardStepPanel2.Index && lb.Visible)
			{
				wizard1.NextEnabled = (lb.SelectedIndex >= 0);
			}

			if (wizard1.NextEnabled)
			{
				lastselected = (Data.Alias)lb.SelectedItem;
			}
			else
			{
				lastselected = null;
			}

			UpdateObjectPreview(op1);
		}

		private void cbTask_SelectedIndexChanged(object sender, EventArgs e)
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

		private void button3_Click(object sender, EventArgs e)
		{
			Activate_biNext(biNext, e);
		}

		private void wizardStepPanel2_Activate(
			Wizards.Wizard sender,
			Wizards.WizardEventArgs e
		)
		{
			package = null;
			if (tv.Visible)
			{
				if (tv.SelectedNode == null)
				{
					e.EnableNext = false;
				}
				else if (tv.SelectedNode.Tag == null)
				{
					e.EnableNext = false;
				}
				else
				{
					e.EnableNext = true;
				}
			}
			else
			{
				e.EnableNext = lb.SelectedIndex >= 0;
			}

			tv.SelectedNode = null;
			lb.SelectedIndex = -1;
		}

		private void wizardStepPanel4_Activate(
			Wizards.Wizard sender,
			Wizards.WizardEventArgs e
		)
		{
			e.CanFinish = false;
			pbWait.Image = null;
			lbwait.Visible = true;
			lbfinished.Visible = false;
			lbfinload.Visible = false;
			lberr.Visible = false;
		}

		private void wizardStepPanel4_Activated(
			Wizards.Wizard sender,
			Wizards.WizardStepPanel step
		)
		{
			pbWait.Image = Image.FromStream(
				GetType().Assembly.GetManifestResourceStream("SimPe.img.timer.gif")
			);
			Packages.GeneratableFile package = null;
			if (lastselected == null && this.package == null)
			{
				sender.FinishEnabled = false;
			}
			else
			{
				ObjectWorkshopHelper.PrepareForClone(
					this.package,
					lastselected,
					out Interfaces.IAlias a,
					out uint localgroup,
					out Interfaces.Files.IPackedFileDescriptor pfd
				);

				ObjectWorkshopSettings settings;

				//Clone an Object
				if (cbTask.SelectedIndex == 1)
				{
					OWCloneSettings cs = new OWCloneSettings
					{
						IncludeWallmask = cbwallmask.Checked,
						OnlyDefaultMmats = cbdefault.Checked,
						IncludeAnimationResources = cbanim.Checked,
						CustomGroup = cbgid.Checked,
						FixResources = cbfix.Checked,
						RemoveUselessResource = cbclean.Checked,
						StandAloneObject = cbparent.Checked,
						RemoveNonDefaultTextReferences = cbRemTxt.Checked,
						KeepOriginalMesh = cbOrgGmdc.Checked,
						PullResourcesByStr = cbstrlink.Checked,

						ChangeObjectDescription = cbDesc.Checked,
						Title = tbName.Text,
						Description = tbDesc.Text,
						Price = Helper.StringToInt16(tbPrice.Text, 0, 10)
					};

					settings = cs;
				}
				else
				{
					//Recolor a Object
					settings = new OWRecolorSettings
					{
						RemoveNonDefaultTextReferences = false
					};
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
				pbWait.Image = null;
				if (package != null)
				{
					lbfinload.Visible = settings.RemoteResult;
				}
				else
				{
					lberr.Visible = true;
				}
			}

			lbwait.Visible = false;
			lbfinished.Visible = !lbfinload.Visible && !lberr.Visible;
		}

		private void wizardStepPanel3_Activate(
			Wizards.Wizard sender,
			Wizards.WizardEventArgs e
		)
		{
			e.CanFinish = (
				(lastselected != null || package != null)
				&& cbTask.SelectedIndex == 0
				&& !cbDesc.Checked
			);
			e.EnableNext = (
				(lastselected != null || package != null)
				&& !(cbTask.SelectedIndex == 0 && !cbDesc.Checked)
			);
			UpdateObjectPreview(op2);
			UpdateEnabledOptions();
		}

		void UpdateEnabledOptions()
		{
			if (lastselected != null)
			{
				Cache.ObjectCacheItem oci = (Cache.ObjectCacheItem)
					lastselected.Tag[3];
				if (oci.Class != Cache.ObjectClass.Object)
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
			{
				op.SetFromObjectCacheItem(
					(Cache.ObjectCacheItem)lastselected.Tag[3]
				);
			}
			else if (package != null)
			{
				op.SetFromPackage(package);
			}
			else
			{
				op.SelectedObject = null;
			}
		}

		private void biAbort_Activate(object sender, EventArgs e)
		{
			wizard1.JumpToStep(0);
		}

		private void cbfix_CheckedChanged(object sender, EventArgs e)
		{
			cbclean.Enabled = cbfix.Checked;
			cbRemTxt.Enabled = cbfix.Checked;
			UpdateEnabledOptions();
		}

		private void wizardStepPanel3_Activated(
			Wizards.Wizard sender,
			Wizards.WizardStepPanel step
		)
		{
		}

		private void wizardStepPanel5_Activate(
			Wizards.Wizard sender,
			Wizards.WizardEventArgs e
		)
		{
			e.CanFinish = true;
			e.EnableNext = false;

			tbName.Text = op2.Title;
			tbDesc.Text = op2.Description;
			tbPrice.Text = op2.Price.ToString();
		}

		private void wizardStepPanel5_Activated(
			Wizards.Wizard sender,
			Wizards.WizardStepPanel step
		)
		{
		}

		private void wizard1_PrepareStep(
			Wizards.Wizard sender,
			Wizards.WizardStepPanel step,
			int target
		)
		{
		}

		private void wizard1_ShowedStep(Wizards.Wizard sender, int source)
		{
			if (
				sender.CurrentStep == wizardStepPanel5
				&& (cbTask.SelectedIndex == 0 || cbDesc.Checked == false)
			)
			{
				if (source < sender.CurrentStep.Index)
				{
					wizard1.GoNext();
				}
				else
				{
					wizard1.GoPrev();
				}
			}
		}

		private void cbDesc_CheckedChanged(object sender, EventArgs e)
		{
			cbTask_SelectedIndexChanged(cbTask, null);
		}

		private void lberr_Click(object sender, EventArgs e)
		{
		}

		bool onlybase;

		private void button4_Click(object sender, EventArgs e)
		{
			lastselected = null;
			tv.SelectedNode = null;
			onlybase = false;
			package = ObjectWorkshopHelper.CreatCloneByGroup(
				Helper.StringToUInt32(tbGroup.Text, 0x7f000000, 16)
			);

			wizard1.JumpToStep(2);
		}

		private void button5_Click(object sender, EventArgs e)
		{
			lastselected = null;
			tv.SelectedNode = null;
			onlybase = false;
			package = ObjectWorkshopHelper.CreatCloneByCres(tbCresName.Text);

			wizard1.JumpToStep(2);
		}

		private void button6_Click(object sender, EventArgs e)
		{
			lastselected = null;
			tv.SelectedNode = null;
			onlybase = false;
			package = ObjectWorkshopHelper.CreatCloneByGuid(
				Helper.StringToUInt32(tbGUID.Text, 0x00000000, 16)
			);

			wizard1.JumpToStep(2);
		}

		private void xpTaskBoxSimple1_Resize(object sender, EventArgs e)
		{
			op2.Size = new Size(
				xpTaskBoxSimple1.Width - 16,
				xpTaskBoxSimple1.Height - 56
			);
		}

		private void xpTaskBoxSimple2_Resize(object sender, EventArgs e)
		{
			op1.Size = new Size(
				xpTaskBoxSimple2.Width - 16,
				xpTaskBoxSimple2.Height - 56
			);
		}

		private void SetDefaultsForClone(object sender, LinkLabelLinkClickedEventArgs e)
		{
			registry.SetDefaults();
		}
	}
}
