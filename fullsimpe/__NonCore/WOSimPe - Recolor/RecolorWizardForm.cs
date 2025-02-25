using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SimPe.Wizards
{
	/// <summary>
	/// Zusammenfassung f�r RecolourWizardForm.
	/// </summary>
	public class RecolourWizardForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		internal System.Windows.Forms.Panel pnwizard1;
		internal System.Windows.Forms.Panel pnwizard2;
		private System.Windows.Forms.TabPage tabPage3;
		internal System.Windows.Forms.Panel pnwizard3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TabPage tabPage4;
		internal System.Windows.Forms.PictureBox pb;
		private System.Windows.Forms.PictureBox pbmisc;
		private System.Windows.Forms.PictureBox pbsurfaces;
		private System.Windows.Forms.PictureBox pbplumbing;
		private System.Windows.Forms.PictureBox pbappliances;
		private System.Windows.Forms.PictureBox pblight;
		private System.Windows.Forms.PictureBox pbelectronics;
		private System.Windows.Forms.PictureBox pbdecorations;
		private System.Windows.Forms.PictureBox pbseating;
		private System.Windows.Forms.PictureBox pbgeneral;
		private System.Windows.Forms.Panel pnSelect;
		private System.Windows.Forms.ImageList iObjects;
		internal System.Windows.Forms.ListView lv;
		private System.Windows.Forms.ImageList iTxtrs;
		private System.Windows.Forms.Label lbno;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.SaveFileDialog sfd;
		private System.Windows.Forms.Button llexp;
		private System.Windows.Forms.Button llimp;
		private System.Windows.Forms.CheckBox cbalpha;
		private System.Windows.Forms.OpenFileDialog ofd;
		internal System.Windows.Forms.TextBox tbflname;
		internal System.Windows.Forms.Label lberr;
		internal System.Windows.Forms.CheckBox cbover;
		private System.Windows.Forms.TabPage tabPage5;
		internal System.Windows.Forms.Panel pnwizard1b;
		private System.Windows.Forms.Panel pnwizard1b_sub;
		private System.Windows.Forms.CheckBox cbauto;
		private System.ComponentModel.IContainer components;

		public RecolourWizardForm()
		{
			//
			// Erforderlich f�r die Windows Form-Designerunterst�tzung
			//
			InitializeComponent();

			ShowSelection();
			loaded = false;
			if (Helper.WindowsRegistry.UseBigIcons)
			{
				this.cbalpha.Location = new System.Drawing.Point(395, 105);
				this.cbalpha.Size = new System.Drawing.Size(153, 22);
				this.llexp.Location = new System.Drawing.Point(425, 76);
				this.llexp.Size = new System.Drawing.Size(103, 28);
				this.llimp.Location = new System.Drawing.Point(425, 135);
				this.llimp.Size = new System.Drawing.Size(103, 28);
				this.cbover.Location = new System.Drawing.Point(407, 54);
				this.cbover.Size = new System.Drawing.Size(107, 22);
				this.iObjects.ImageSize = new System.Drawing.Size(120, 120);
			}
		}

		/// <summary>
		/// Die verwendeten Ressourcen bereinigen.
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

		#region Vom Windows Form-Designer generierter Code
		/// <summary>
		/// Erforderliche Methode f�r die Designerunterst�tzung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor ge�ndert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(
					typeof(RecolourWizardForm)
				);
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.pbgeneral = new System.Windows.Forms.PictureBox();
			this.pbseating = new System.Windows.Forms.PictureBox();
			this.pbdecorations = new System.Windows.Forms.PictureBox();
			this.pbelectronics = new System.Windows.Forms.PictureBox();
			this.pblight = new System.Windows.Forms.PictureBox();
			this.pbappliances = new System.Windows.Forms.PictureBox();
			this.pbplumbing = new System.Windows.Forms.PictureBox();
			this.pbsurfaces = new System.Windows.Forms.PictureBox();
			this.pbmisc = new System.Windows.Forms.PictureBox();
			this.pb = new System.Windows.Forms.PictureBox();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.pnwizard1b = new System.Windows.Forms.Panel();
			this.cbauto = new System.Windows.Forms.CheckBox();
			this.pnwizard1b_sub = new System.Windows.Forms.Panel();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.pnwizard1 = new System.Windows.Forms.Panel();
			this.pnSelect = new System.Windows.Forms.Panel();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.pnwizard2 = new System.Windows.Forms.Panel();
			this.cbalpha = new System.Windows.Forms.CheckBox();
			this.llimp = new System.Windows.Forms.Button();
			this.llexp = new System.Windows.Forms.Button();
			this.lbno = new System.Windows.Forms.Label();
			this.lv = new System.Windows.Forms.ListView();
			this.iTxtrs = new System.Windows.Forms.ImageList(this.components);
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.pnwizard3 = new System.Windows.Forms.Panel();
			this.lberr = new System.Windows.Forms.Label();
			this.tbflname = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cbover = new System.Windows.Forms.CheckBox();
			this.iObjects = new System.Windows.Forms.ImageList(this.components);
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.sfd = new System.Windows.Forms.SaveFileDialog();
			this.ofd = new System.Windows.Forms.OpenFileDialog();
			this.tabControl1.SuspendLayout();
			this.tabPage4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbgeneral)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbseating)).BeginInit();
			(
				(System.ComponentModel.ISupportInitialize)(this.pbdecorations)
			).BeginInit();
			(
				(System.ComponentModel.ISupportInitialize)(this.pbelectronics)
			).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pblight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbappliances)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbplumbing)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbsurfaces)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbmisc)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
			this.tabPage5.SuspendLayout();
			this.pnwizard1b.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.pnwizard1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.pnwizard2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.pnwizard3.SuspendLayout();
			this.SuspendLayout();
			//
			// tabControl1
			//
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Controls.Add(this.tabPage5);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(8, 8);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(832, 526);
			this.tabControl1.TabIndex = 0;
			//
			// tabPage4
			//
			this.tabPage4.Controls.Add(this.pbgeneral);
			this.tabPage4.Controls.Add(this.pbseating);
			this.tabPage4.Controls.Add(this.pbdecorations);
			this.tabPage4.Controls.Add(this.pbelectronics);
			this.tabPage4.Controls.Add(this.pblight);
			this.tabPage4.Controls.Add(this.pbappliances);
			this.tabPage4.Controls.Add(this.pbplumbing);
			this.tabPage4.Controls.Add(this.pbsurfaces);
			this.tabPage4.Controls.Add(this.pbmisc);
			this.tabPage4.Controls.Add(this.pb);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(824, 500);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Misc";
			//
			// pbgeneral
			//
			this.pbgeneral.Image = (
				(System.Drawing.Image)(resources.GetObject("pbgeneral.Image"))
			);
			this.pbgeneral.Location = new System.Drawing.Point(391, 97);
			this.pbgeneral.Name = "pbgeneral";
			this.pbgeneral.Size = new System.Drawing.Size(120, 43);
			this.pbgeneral.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbgeneral.TabIndex = 9;
			this.pbgeneral.TabStop = false;
			//
			// pbseating
			//
			this.pbseating.Image = (
				(System.Drawing.Image)(resources.GetObject("pbseating.Image"))
			);
			this.pbseating.Location = new System.Drawing.Point(391, 52);
			this.pbseating.Name = "pbseating";
			this.pbseating.Size = new System.Drawing.Size(120, 43);
			this.pbseating.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbseating.TabIndex = 8;
			this.pbseating.TabStop = false;
			//
			// pbdecorations
			//
			this.pbdecorations.Image = (
				(System.Drawing.Image)(resources.GetObject("pbdecorations.Image"))
			);
			this.pbdecorations.Location = new System.Drawing.Point(391, 7);
			this.pbdecorations.Name = "pbdecorations";
			this.pbdecorations.Size = new System.Drawing.Size(160, 43);
			this.pbdecorations.SizeMode = System
				.Windows
				.Forms
				.PictureBoxSizeMode
				.AutoSize;
			this.pbdecorations.TabIndex = 7;
			this.pbdecorations.TabStop = false;
			//
			// pbelectronics
			//
			this.pbelectronics.Image = (
				(System.Drawing.Image)(resources.GetObject("pbelectronics.Image"))
			);
			this.pbelectronics.Location = new System.Drawing.Point(233, 90);
			this.pbelectronics.Name = "pbelectronics";
			this.pbelectronics.Size = new System.Drawing.Size(80, 40);
			this.pbelectronics.SizeMode = System
				.Windows
				.Forms
				.PictureBoxSizeMode
				.AutoSize;
			this.pbelectronics.TabIndex = 6;
			this.pbelectronics.TabStop = false;
			//
			// pblight
			//
			this.pblight.Image = (
				(System.Drawing.Image)(resources.GetObject("pblight.Image"))
			);
			this.pblight.Location = new System.Drawing.Point(233, 52);
			this.pblight.Name = "pblight";
			this.pblight.Size = new System.Drawing.Size(120, 40);
			this.pblight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pblight.TabIndex = 5;
			this.pblight.TabStop = false;
			//
			// pbappliances
			//
			this.pbappliances.Image = (
				(System.Drawing.Image)(resources.GetObject("pbappliances.Image"))
			);
			this.pbappliances.Location = new System.Drawing.Point(233, 7);
			this.pbappliances.Name = "pbappliances";
			this.pbappliances.Size = new System.Drawing.Size(160, 43);
			this.pbappliances.SizeMode = System
				.Windows
				.Forms
				.PictureBoxSizeMode
				.AutoSize;
			this.pbappliances.TabIndex = 4;
			this.pbappliances.TabStop = false;
			//
			// pbplumbing
			//
			this.pbplumbing.Image = (
				(System.Drawing.Image)(resources.GetObject("pbplumbing.Image"))
			);
			this.pbplumbing.Location = new System.Drawing.Point(69, 82);
			this.pbplumbing.Name = "pbplumbing";
			this.pbplumbing.Size = new System.Drawing.Size(120, 40);
			this.pbplumbing.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbplumbing.TabIndex = 3;
			this.pbplumbing.TabStop = false;
			//
			// pbsurfaces
			//
			this.pbsurfaces.Image = (
				(System.Drawing.Image)(resources.GetObject("pbsurfaces.Image"))
			);
			this.pbsurfaces.Location = new System.Drawing.Point(69, 45);
			this.pbsurfaces.Name = "pbsurfaces";
			this.pbsurfaces.Size = new System.Drawing.Size(160, 38);
			this.pbsurfaces.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbsurfaces.TabIndex = 2;
			this.pbsurfaces.TabStop = false;
			//
			// pbmisc
			//
			this.pbmisc.Image = (
				(System.Drawing.Image)(resources.GetObject("pbmisc.Image"))
			);
			this.pbmisc.Location = new System.Drawing.Point(69, 7);
			this.pbmisc.Name = "pbmisc";
			this.pbmisc.Size = new System.Drawing.Size(160, 40);
			this.pbmisc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbmisc.TabIndex = 1;
			this.pbmisc.TabStop = false;
			//
			// pb
			//
			this.pb.Image = ((System.Drawing.Image)(resources.GetObject("pb.Image")));
			this.pb.Location = new System.Drawing.Point(7, 7);
			this.pb.Name = "pb";
			this.pb.Size = new System.Drawing.Size(64, 58);
			this.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pb.TabIndex = 0;
			this.pb.TabStop = false;
			//
			// tabPage5
			//
			this.tabPage5.BackColor = System.Drawing.Color.White;
			this.tabPage5.Controls.Add(this.pnwizard1b);
			this.tabPage5.Location = new System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Size = new System.Drawing.Size(824, 500);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "Step 1b";
			//
			// pnwizard1b
			//
			this.pnwizard1b.Controls.Add(this.cbauto);
			this.pnwizard1b.Controls.Add(this.pnwizard1b_sub);
			this.pnwizard1b.Location = new System.Drawing.Point(0, 0);
			this.pnwizard1b.Name = "pnwizard1b";
			this.pnwizard1b.Size = new System.Drawing.Size(735, 142);
			this.pnwizard1b.TabIndex = 0;
			//
			// cbauto
			//
			this.cbauto.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Bottom
						| System.Windows.Forms.AnchorStyles.Left
					)
				)
			);
			this.cbauto.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbauto.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cbauto.Location = new System.Drawing.Point(7, 119);
			this.cbauto.Name = "cbauto";
			this.cbauto.Size = new System.Drawing.Size(233, 23);
			this.cbauto.TabIndex = 1;
			this.cbauto.Text = "Autoselect matching Textures";
			this.toolTip1.SetToolTip(
				this.cbauto,
				"When you select a Texture in one of the Subsets and you have this Option checked,"
					+ " WOS will try to select a Texture with the same name in all other enabled Subset"
					+ "s."
			);
			this.cbauto.CheckedChanged += new System.EventHandler(
				this.cbauto_CheckedChanged
			);
			//
			// pnwizard1b_sub
			//
			this.pnwizard1b_sub.Anchor = (
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
			this.pnwizard1b_sub.Location = new System.Drawing.Point(0, 0);
			this.pnwizard1b_sub.Name = "pnwizard1b_sub";
			this.pnwizard1b_sub.Size = new System.Drawing.Size(735, 112);
			this.pnwizard1b_sub.TabIndex = 0;
			//
			// tabPage1
			//
			this.tabPage1.BackColor = System.Drawing.Color.White;
			this.tabPage1.Controls.Add(this.pnwizard1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(824, 500);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Step 1";
			//
			// pnwizard1
			//
			this.pnwizard1.BackColor = System.Drawing.Color.White;
			this.pnwizard1.Controls.Add(this.pnSelect);
			this.pnwizard1.Location = new System.Drawing.Point(0, 0);
			this.pnwizard1.Name = "pnwizard1";
			this.pnwizard1.Size = new System.Drawing.Size(735, 305);
			this.pnwizard1.TabIndex = 10;
			//
			// pnSelect
			//
			this.pnSelect.BackColor = System.Drawing.Color.White;
			this.pnSelect.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnSelect.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.pnSelect.Location = new System.Drawing.Point(0, 0);
			this.pnSelect.Name = "pnSelect";
			this.pnSelect.Size = new System.Drawing.Size(90, 305);
			this.pnSelect.TabIndex = 0;
			//
			// tabPage2
			//
			this.tabPage2.Controls.Add(this.pnwizard2);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(824, 500);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Step 2";
			//
			// pnwizard2
			//
			this.pnwizard2.BackColor = System.Drawing.Color.White;
			this.pnwizard2.Controls.Add(this.cbalpha);
			this.pnwizard2.Controls.Add(this.llimp);
			this.pnwizard2.Controls.Add(this.llexp);
			this.pnwizard2.Controls.Add(this.lbno);
			this.pnwizard2.Controls.Add(this.lv);
			this.pnwizard2.Location = new System.Drawing.Point(0, 2);
			this.pnwizard2.Name = "pnwizard2";
			this.pnwizard2.Size = new System.Drawing.Size(735, 172);
			this.pnwizard2.TabIndex = 10;
			//
			// cbalpha
			//
			this.cbalpha.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Bottom
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.cbalpha.Location = new System.Drawing.Point(632, 105);
			this.cbalpha.Name = "cbalpha";
			this.cbalpha.Size = new System.Drawing.Size(103, 22);
			this.cbalpha.TabIndex = 6;
			this.cbalpha.Text = "seperate Alpha";
			this.toolTip1.SetToolTip(
				this.cbalpha,
				"when checkd, a Seperate File conatining the Alpha Channel will be generated"
			);
			//
			// llimp
			//
			this.llimp.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Bottom
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.llimp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.llimp.Location = new System.Drawing.Point(625, 142);
			this.llimp.Name = "llimp";
			this.llimp.Size = new System.Drawing.Size(103, 21);
			this.llimp.TabIndex = 5;
			this.llimp.Text = "Import";
			this.toolTip1.SetToolTip(
				this.llimp,
				"Import an Image for the selected Texture"
			);
			this.llimp.Click += new System.EventHandler(this.Import);
			//
			// llexp
			//
			this.llexp.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Bottom
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.llexp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.llexp.Location = new System.Drawing.Point(625, 82);
			this.llexp.Name = "llexp";
			this.llexp.Size = new System.Drawing.Size(103, 22);
			this.llexp.TabIndex = 4;
			this.llexp.Text = "Export";
			this.toolTip1.SetToolTip(
				this.llexp,
				"Exports the Texture as an image File"
			);
			this.llexp.Click += new System.EventHandler(this.Export);
			//
			// lbno
			//
			this.lbno.Font = new System.Drawing.Font(
				"Verdana",
				12F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.lbno.ForeColor = System.Drawing.Color.Gray;
			this.lbno.Location = new System.Drawing.Point(27, 30);
			this.lbno.Name = "lbno";
			this.lbno.Size = new System.Drawing.Size(368, 109);
			this.lbno.TabIndex = 3;
			this.lbno.Text =
				"Sorry, the Object you selected can\'t be recoloured (yet).\r\n\r\nMake sure 3D resourc"
				+ "es are enabled in SimPe\'s File Table";
			//
			// lv
			//
			this.lv.Anchor = (
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
			this.lv.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lv.HideSelection = false;
			this.lv.LargeImageList = this.iTxtrs;
			this.lv.Location = new System.Drawing.Point(0, 0);
			this.lv.MultiSelect = false;
			this.lv.Name = "lv";
			this.lv.Size = new System.Drawing.Size(618, 172);
			this.lv.TabIndex = 0;
			this.lv.UseCompatibleStateImageBehavior = false;
			this.lv.SelectedIndexChanged += new System.EventHandler(this.SelectTexture);
			//
			// iTxtrs
			//
			this.iTxtrs.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.iTxtrs.ImageSize = new System.Drawing.Size(128, 128);
			this.iTxtrs.TransparentColor = System.Drawing.Color.Transparent;
			//
			// tabPage3
			//
			this.tabPage3.Controls.Add(this.pnwizard3);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(824, 500);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Step3";
			//
			// pnwizard3
			//
			this.pnwizard3.BackColor = System.Drawing.Color.White;
			this.pnwizard3.Controls.Add(this.lberr);
			this.pnwizard3.Controls.Add(this.tbflname);
			this.pnwizard3.Controls.Add(this.label3);
			this.pnwizard3.Controls.Add(this.cbover);
			this.pnwizard3.Location = new System.Drawing.Point(0, 1);
			this.pnwizard3.Name = "pnwizard3";
			this.pnwizard3.Size = new System.Drawing.Size(735, 172);
			this.pnwizard3.TabIndex = 11;
			//
			// lberr
			//
			this.lberr.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						(
							System.Windows.Forms.AnchorStyles.Top
							| System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.lberr.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.lberr.ForeColor = System.Drawing.Color.Gray;
			this.lberr.Location = new System.Drawing.Point(41, 100);
			this.lberr.Name = "lberr";
			this.lberr.Size = new System.Drawing.Size(666, 30);
			this.lberr.TabIndex = 4;
			this.lberr.Text =
				"There is already a Object with the given Filename. Please use a diffrent Name or "
				+ "select the Overwrite Checkbox.";
			//
			// tbflname
			//
			this.tbflname.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						(
							System.Windows.Forms.AnchorStyles.Top
							| System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.tbflname.Location = new System.Drawing.Point(34, 75);
			this.tbflname.Name = "tbflname";
			this.tbflname.Size = new System.Drawing.Size(680, 21);
			this.tbflname.TabIndex = 1;
			this.tbflname.Text = "CustomPackage";
			this.tbflname.TextChanged += new System.EventHandler(this.ChangeText);
			//
			// label3
			//
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label3.Location = new System.Drawing.Point(21, 60);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(71, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Filename:";
			//
			// cbover
			//
			this.cbover.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.cbover.Location = new System.Drawing.Point(625, 51);
			this.cbover.Name = "cbover";
			this.cbover.Size = new System.Drawing.Size(89, 22);
			this.cbover.TabIndex = 5;
			this.cbover.Text = "Overwrite";
			this.cbover.CheckedChanged += new System.EventHandler(this.OverwriteState);
			//
			// iObjects
			//
			this.iObjects.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.iObjects.ImageSize = new System.Drawing.Size(64, 64);
			this.iObjects.TransparentColor = System.Drawing.Color.Transparent;
			//
			// RecolourWizardForm
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(848, 542);
			this.Controls.Add(this.tabControl1);
			this.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.Name = "RecolourWizardForm";
			this.Padding = new System.Windows.Forms.Padding(8);
			this.Text = "RecolourWizardForm";
			this.tabControl1.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.tabPage4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbgeneral)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbseating)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbdecorations)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbelectronics)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pblight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbappliances)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbplumbing)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbsurfaces)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbmisc)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
			this.tabPage5.ResumeLayout(false);
			this.pnwizard1b.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.pnwizard1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.pnwizard2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.pnwizard3.ResumeLayout(false);
			this.pnwizard3.PerformLayout();
			this.ResumeLayout(false);
		}
		#endregion


		internal Step1 step1;
		internal Step1b step1b;
		internal Step2 step2;
		internal Step3 step3;
		bool loaded;

		#region Image Selection Buttons
		private enum State
		{
			off,
			on,
			over,
		}

		internal PictureBox selected = null;
		internal ListView[] lvobjs;
		internal ListView selectedlv = null;

		/// <summary>
		/// Show a diffrent slice
		/// </summary>
		/// <param name="img"></param>
		/// <param name="select"></param>
		/// <returns></returns>
		Image ShowImage(Image img, State select)
		{
			int wd = img.Width;

			Bitmap bm = new Bitmap(img.Width / 4, img.Height);
			Graphics gr = Graphics.FromImage(bm);

			int mul = 0;
			if (select == State.on)
				mul = 2;
			else if (select == State.over)
				mul = 3;

			Rectangle src = new Rectangle(bm.Width * mul, 0, bm.Width, bm.Height);
			Rectangle dst = new Rectangle(0, 0, bm.Width, bm.Height);
			gr.DrawImage(img, dst, src, GraphicsUnit.Pixel);

			return SimPe.Plugin.ImageLoader.Preview(bm, new Size(40, 40));
		}

		/// <summary>
		/// Bild a PictureBox
		/// </summary>
		/// <param name="top"></param>
		/// <returns></returns>
		public PictureBox BuildImage(int left, ref int top, Image img, int index)
		{
			PictureBox pb = new PictureBox();
			pb.Parent = this.pnSelect;
			pb.Size = new Size(40, 40);
			pb.Left = left;
			pb.Top = top;
			top += pb.Height + 2;

			pb.Image = ShowImage(img, State.off);
			pb.Tag = img;
			pb.Cursor = Cursors.Hand;

			pb.MouseEnter += new EventHandler(SelectButtonEnter);
			pb.MouseLeave += new EventHandler(SelectButtonLeave);
			pb.Click += new EventHandler(SelectButtonClick);

			ListView lv = new ListView();
			lv.Tag = pb;
			lv.Parent = pnwizard1;
			lv.Left = pnSelect.Width + 2;
			lv.Top = 0;
			lv.Height = pnwizard1.Height;
			lv.Width = pnwizard1.Width - lv.Left;
			lv.BorderStyle = BorderStyle.None;
			lv.View = View.LargeIcon;
			lv.LargeImageList = iObjects;
			lv.HideSelection = false;
			lv.MultiSelect = false;

			lv.Anchor =
				AnchorStyles.Left
				| AnchorStyles.Top
				| AnchorStyles.Right
				| AnchorStyles.Bottom;
			lv.SelectedIndexChanged += new EventHandler(ObjectSelectionChanged);
			lv.Visible = false;

			lvobjs[index] = lv;

			return pb;
		}

		/// <summary>
		/// Display the Selection buttons
		/// </summary>
		public void ShowSelection()
		{
			lvobjs = new ListView[9];

			int top = (250 - (42 * 5)) / 2;
			PictureBox pbfirst = BuildImage(0, ref top, this.pbseating.Image, 0);
			BuildImage(0, ref top, this.pbsurfaces.Image, 1);
			BuildImage(0, ref top, this.pbdecorations.Image, 5);
			BuildImage(0, ref top, this.pbplumbing.Image, 4);
			BuildImage(0, ref top, this.pbappliances.Image, 2);
			top = (250 - (42 * 4)) / 2;
			BuildImage(42, ref top, this.pbelectronics.Image, 3);
			BuildImage(42, ref top, this.pblight.Image, 7);
			BuildImage(42, ref top, this.pbgeneral.Image, 6);
			BuildImage(42, ref top, this.pbmisc.Image, 8);

			SelectButtonClick(pbfirst, null);
		}

		private void SelectButtonEnter(object sender, EventArgs e)
		{
			PictureBox pb = (PictureBox)sender;
			if (selected != pb)
				pb.Image = this.ShowImage((Image)pb.Tag, State.over);
		}

		private void SelectButtonLeave(object sender, EventArgs e)
		{
			PictureBox pb = (PictureBox)sender;
			if (selected != pb)
				pb.Image = this.ShowImage((Image)pb.Tag, State.off);
			else
				pb.Image = this.ShowImage((Image)pb.Tag, State.on);
		}

		private void SelectButtonClick(object sender, EventArgs e)
		{
			if (selected != null)
				selected.Image = ShowImage((Image)selected.Tag, State.off);

			PictureBox pb = (PictureBox)sender;
			pb.Image = this.ShowImage((Image)pb.Tag, State.on);

			selected = pb;
			selectedlv = null;
			foreach (Control c in pnwizard1.Controls)
			{
				if (c.GetType() == typeof(ListView))
				{
					ListView lv = (ListView)c;
					lv.Visible = (lv.Tag == selected);

					if (lv.Tag == selected)
						selectedlv = lv;
				}
			}

			if (step1 != null)
				step1.Update();
		}

		private void ObjectSelectionChanged(object sender, EventArgs e)
		{
			step1.Update();
		}
		#endregion

		ListViewItem CreateItem(
			string modelname,
			Image img,
			SimPe.PackedFiles.Wrapper.ExtObjd objd,
			string name
		)
		{
			ListViewItem lvi = new ListViewItem(name);
			lvi.Tag = objd;
			if (img != null)
			{
				lvi.ImageIndex = iObjects.Images.Count;
				iObjects.Images.Add(
					SimPe.Plugin.ImageLoader.Preview(img, iObjects.ImageSize)
				);
				//iObjects.Images.Add(img);
			}

			lvi.SubItems.Add(modelname);
			return lvi;
		}

		SimPe.Packages.File objects;

		/// <summary>
		/// Load all available Objects
		/// </summary>
		public void BuildList()
		{
			if (loaded)
				return;

			string sourcefile = System.IO.Path.Combine(
				PathProvider.Global[Expansions.BaseGame].InstallFolder,
				"TSData"
					+ Helper.PATH_SEP
					+ "Res"
					+ Helper.PATH_SEP
					+ "Objects"
					+ Helper.PATH_SEP
					+ "objects.package"
			);
			if (!System.IO.File.Exists(sourcefile))
			{
				MessageBox.Show(
					"The objects.package was not found.\n\nPlease set the Path to your Sims 2 installation in SimPe in the Extra->Options... Dialog."
				);
				return;
			}

			//initialize the FileTable if needed
			if (SimPe.FileTable.FileIndex == null)
				SimPe.FileTable.FileIndex = new SimPe.Plugin.FileIndex();
			SimPe.FileTable.FileIndex.Load();

			iObjects.Images.Clear();
			objects = SimPe.Packages.File.LoadFromFile(sourcefile);
			SimPe.Plugin.Tool.Dockable.ObjectLoader ol =
				new SimPe.Plugin.Tool.Dockable.ObjectLoader(null);
			ol.Finished += new EventHandler(ol_Finished);
			ol.LoadedItem +=
				new SimPe.Plugin.Tool.Dockable.ObjectLoader.LoadItemHandler(
					ol_LoadedItem
				);
			ol.LoadData();
		}

		protected Image GetImageFile(SimPe.Plugin.Rcol txtr)
		{
			SimPe.Plugin.ImageData id = (SimPe.Plugin.ImageData)txtr.Blocks[0];
			SimPe.Plugin.MipMap mipmap = null;
			foreach (SimPe.Plugin.MipMapBlock mmb in id.MipMapBlocks)
			{
				foreach (SimPe.Plugin.MipMap mm in mmb.MipMaps)
				{
					if (mm.Texture != null)
						mipmap = mm;
				}
			}

			if (mipmap != null)
				return mipmap.Texture;

			return null;
		}

		protected void MakeTexturePreview(SimPe.Packages.GeneratableFile npackage)
		{
			iTxtrs.Images.Clear();
			Interfaces.Files.IPackedFileDescriptor[] txtrs = npackage.FindFiles(
				0x1C4A276C
			);
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in txtrs)
			{
				SimPe.Plugin.Rcol txtr = new SimPe.Plugin.GenericRcol(null, false);
				txtr.ProcessData(pfd, npackage);

				ListViewItem lvi = new ListViewItem(
					Hashes.StripHashFromName(txtr.FileName)
				);
				lvi.Tag = txtr;

				Image img = this.GetImageFile(txtr);

				if (img != null)
				{
					lvi.ImageIndex = iTxtrs.Images.Count;
					iTxtrs.Images.Add(
						SimPe.Plugin.ImageLoader.Preview(img, iTxtrs.ImageSize)
					);
				}

				lv.Items.Add(lvi);
			}
		}

		SimPe.Packages.GeneratableFile npackage;
		internal SimPe.Plugin.SubsetSelectForm ssf;
		internal Hashtable fullmap;
		bool showselect;

		protected void SelectCallback(
			SimPe.Plugin.SubsetSelectForm ssf,
			bool show,
			Hashtable fullmap
		)
		{
			showselect = show;
			this.cbauto.Checked = ssf.cbauto.Checked;
			this.ssf = ssf;
			this.fullmap = fullmap;

			this.pnwizard1b_sub.Controls.Clear();
			ssf.pnselect.Parent = this.pnwizard1b_sub;
			ssf.pnselect.Left = 0;
			ssf.pnselect.Top = 0;
			ssf.pnselect.Width = pnwizard1b_sub.Width;
			ssf.pnselect.Height = pnwizard1b_sub.Height;

			foreach (ListView lv in ssf.ListViews)
			{
				lv.BorderStyle = BorderStyle.None;
				lv.SelectedIndexChanged += new EventHandler(SubsetSelectedIndexChanged);
			}

			//show the next step
			if (!show)
			{
				ssf.button1.Enabled = true;
				step1b.Update(true);
			}
		}

		SimPe.Plugin.ColorOptions cs;

		public bool Recolor()
		{
			if (selectedlv == null)
				return true;
			if (selectedlv.SelectedItems.Count == 0)
				return true;

			llexp.Enabled = false;
			llimp.Enabled = false;

			WaitingScreen.Wait();
			try
			{
				WaitingScreen.UpdateMessage("Preparing Recolour Package");
				lv.Items.Clear();

				SimPe.PackedFiles.Wrapper.ExtObjd objd =
					(SimPe.PackedFiles.Wrapper.ExtObjd)selectedlv.SelectedItems[0].Tag;

				SimPe.Packages.GeneratableFile pkg =
					SimPe.Packages.GeneratableFile.LoadFromStream(
						(System.IO.BinaryReader)null
					);
				pkg.FileName = "WOS";

				//Create the Basic Clone
				WaitingScreen.UpdateMessage("Collecting needed Files");
				string[] modelnames = SimPe.Plugin.Workshop.BaseClone(
					objd.FileDescriptor,
					objd.FileDescriptor.Group,
					pkg
				);
				SimPe.Plugin.ObjectCloner objclone = new SimPe.Plugin.ObjectCloner(pkg);
				objclone.Setup.OnlyDefaultMmats = false;
				objclone.Setup.UpdateMmatGuids = false;
				objclone.RcolModelClone(modelnames);

				WaitingScreen.UpdateMessage("Loading additional References");
				SimPe.Plugin.ObjectRecolor or = new SimPe.Plugin.ObjectRecolor(pkg);
				or.LoadReferencedMATDs();

				//Build the Recolour
				WaitingScreen.UpdateMessage("Building Recolour");
				npackage = SimPe.Packages.GeneratableFile.LoadFromStream(
					(System.IO.BinaryReader)null
				);
				npackage.FileName = "WOS";

				cs = new SimPe.Plugin.ColorOptions(pkg);
				cs.Create(
					npackage,
					new SimPe.Plugin.ColorOptions.CreateSelectionCallback(
						SelectCallback
					)
				);
			}
			finally
			{
				WaitingScreen.Stop();
			}

			return showselect;
		}

		public void Recolor2()
		{
			WaitingScreen.Wait();
			try
			{
				lv.Items.Clear();
				if ((ssf != null) && (fullmap != null))
				{
					Hashtable map = SimPe.Plugin.SubsetSelectForm.Finish(ssf);
					cs.ProcessMmatMap(npackage, map, fullmap);
				}
				//Select all Textures the package Contains
				WaitingScreen.UpdateMessage("Select Textures"); // CJH

				MakeTexturePreview(npackage);

				step2.Update();
				lbno.Visible = !step2.CanContinue;
				cbauto.Visible =
					lv.Visible =
					llexp.Visible =
					llimp.Visible =
					cbalpha.Visible =
						step2.CanContinue;
			}
			finally
			{
				WaitingScreen.Stop();
			}
		}

		private void SelectTexture(object sender, System.EventArgs e)
		{
			llexp.Enabled = (lv.SelectedItems.Count != 0);
			llimp.Enabled = llexp.Enabled;
		}

		private void Export(object sender, System.EventArgs e)
		{
			if (lv.SelectedItems.Count == 0)
				return;

			sfd.Filter =
				"PNG Image (*.png)|*.png|Bitmap (*.bmp)|*.bmp|GIF Image (*.gif)|*.gif|Jpeg Image (*.jpg)|*.jpg|All Files (*.*)|*.*";
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				SimPe.Plugin.Rcol txtr = (SimPe.Plugin.Rcol)lv.SelectedItems[0].Tag;
				Image img = this.GetImageFile(txtr);
				img.Save(
					sfd.FileName,
					SimPe.Plugin.ImageLoader.GetImageFormat(sfd.FileName)
				);

				if (cbalpha.Checked)
				{
					Bitmap bm = new Bitmap(img.Width, img.Height);
					for (int y = 0; y < img.Height; y++)
					{
						for (int x = 0; x < img.Width; x++)
						{
							int a = 0xff;
							try
							{
								a = ((Bitmap)img).GetPixel(x, y).A;
								bm.SetPixel(x, y, Color.FromArgb(a, a, a));
							}
#if DEBUG
							catch (Exception ex)
							{
								Helper.ExceptionMessage("", ex);
#else
							catch (Exception)
							{
#endif
							}
						}
					}
					bm.Save(
						System.IO.Path.Combine(
							System.IO.Path.GetDirectoryName(sfd.FileName),
							System.IO.Path.GetFileNameWithoutExtension(sfd.FileName)
						)
							+ "_alpha"
							+ System.IO.Path.GetExtension(sfd.FileName),
						SimPe.Plugin.ImageLoader.GetImageFormat(sfd.FileName)
					);
				}
			}
		}

		private void Import(object sender, System.EventArgs e)
		{
			if (lv.SelectedItems.Count == 0)
				return;

			ofd.Filter =
				"PNG Image (*.png)|*.png|Bitmap (*.bmp)|*.bmp|GIF Image (*.gif)|*.gif|Jpeg Image (*.jpg)|*.jpg|All Files (*.*)|*.*";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				SimPe.Plugin.Rcol txtr = (SimPe.Plugin.Rcol)lv.SelectedItems[0].Tag;
				SimPe.Plugin.ImageData oldid = (SimPe.Plugin.ImageData)txtr.Blocks[0];

				//build TXTR File
				SimPe.Plugin.ImageData id = new SimPe.Plugin.ImageData(null);
				id.NameResource = oldid.NameResource;
				id.Version = oldid.Version;
				id.BlockID = oldid.BlockID;
				id.BlockName = oldid.BlockName;

				if (
					(System.IO.File.Exists(PathProvider.Global.NvidiaDDSTool))
					&& (
						(
							oldid.Format
							== SimPe.Plugin.ImageLoader.TxtrFormats.DXT1Format
						)
						|| (
							oldid.Format
							== SimPe.Plugin.ImageLoader.TxtrFormats.DXT3Format
						)
						|| (
							oldid.Format
							== SimPe.Plugin.ImageLoader.TxtrFormats.DXT5Format
						)
					)
				)
				{
					SimPe.Plugin.BuildTxtr.LoadDDS(
						id,
						SimPe.Plugin.DDSTool.BuildDDS(
							ofd.FileName,
							(int)oldid.MipMapLevels,
							oldid.Format,
							"-sharpenMethod Smoothen"
						)
					);
				}
				else
				{
					id.Format = oldid.Format;
					if (
						(
							oldid.Format
							== SimPe.Plugin.ImageLoader.TxtrFormats.DXT1Format
						)
						|| (
							oldid.Format
							== SimPe.Plugin.ImageLoader.TxtrFormats.DXT3Format
						)
						|| (
							oldid.Format
							== SimPe.Plugin.ImageLoader.TxtrFormats.DXT5Format
						)
					)
						id.Format = SimPe.Plugin.ImageLoader.TxtrFormats.Raw32Bit;
					SimPe.Plugin.BuildTxtr.LoadTXTR(
						id,
						ofd.FileName,
						oldid.TextureSize,
						(int)oldid.MipMapLevels,
						id.Format
					);
				}

				txtr.Blocks[0] = id;
				txtr.SynchronizeUserData();

				//Update the Image
				if (
					(lv.SelectedItems[0].ImageIndex >= 0)
					&& (lv.SelectedItems[0].ImageIndex < iTxtrs.Images.Count)
				)
				{
					this.iTxtrs.Images[lv.SelectedItems[0].ImageIndex] =
						SimPe.Plugin.ImageLoader.Preview(
							this.GetImageFile(txtr),
							iTxtrs.ImageSize
						);
				}
			}
		}

		internal string GetPackageFilename
		{
			get
			{
				string down = System.IO.Path.Combine(
					PathProvider.SimSavegameFolder,
					"Downloads"
				);
				down = System.IO.Path.Combine(down, tbflname.Text + ".package");
				return down;
			}
		}

		internal void SaveRecolor()
		{
			string down = System.IO.Path.Combine(
				PathProvider.SimSavegameFolder,
				"Downloads"
			);

			if (System.IO.Directory.Exists(down))
			{
				down = GetPackageFilename;
				npackage.Save(down);
			}
			else
			{
				sfd.FileName = tbflname.Text + ".package";
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					npackage.Save(sfd.FileName);
				}
			}

			//npackage.Reader.Close();
		}

		private void ChangeText(object sender, System.EventArgs e)
		{
			lberr.Visible = System.IO.File.Exists(this.GetPackageFilename);
			step3.Update();
		}

		private void OverwriteState(object sender, System.EventArgs e)
		{
			step3.Update();
			lberr.Visible = System.IO.File.Exists(this.GetPackageFilename);
		}

		private void cbauto_CheckedChanged(object sender, System.EventArgs e)
		{
			if (ssf != null)
			{
				ssf.cbauto.Checked = this.cbauto.Checked;
			}
		}

		private void SubsetSelectedIndexChanged(object sender, EventArgs e)
		{
			step1b.Update();
		}

		delegate void InvokeTargetLoad(
			SimPe.Cache.ObjectCacheItem oci,
			SimPe.Interfaces.Scenegraph.IScenegraphFileIndexItem fii,
			Data.Alias a
		);
		delegate void InvokeTargetFinish(object sender, EventArgs e);

		private void ol_Finished(object sender, EventArgs e)
		{
			//this.Invoke(new InvokeTargetFinish(invoke_Finished), new object[] {sender, e});
			invoke_Finished(sender, e);
		}

		private void invoke_Finished(object sender, EventArgs e)
		{
			loaded = true;
		}

		private void ol_LoadedItem(
			SimPe.Cache.ObjectCacheItem oci,
			SimPe.Interfaces.Scenegraph.IScenegraphFileIndexItem fii,
			Data.Alias a
		)
		{
			//this.Invoke(new InvokeTargetLoad(invoke_LoadedItem), new object[] {oci, fii, a});
			invoke_LoadedItem(oci, fii, a);
		}

		private void invoke_LoadedItem(
			SimPe.Cache.ObjectCacheItem oci,
			SimPe.Interfaces.Scenegraph.IScenegraphFileIndexItem fii,
			Data.Alias a
		)
		{
			//WaitingScreen.UpdateMessage(a.Name);
			SimPe.PackedFiles.Wrapper.ExtObjd objd =
				new SimPe.PackedFiles.Wrapper.ExtObjd();
			objd.ProcessData(fii);
			Image img = oci.Thumbnail;
			if (img != null)
			{
				img = Ambertation.Drawing.GraphicRoutines.KnockoutImage(
					img,
					new Point(0, 0),
					Color.Magenta
				);
				img = Ambertation.Windows.Forms.Graph.ImagePanel.CreateThumbnail(
					img,
					this.iObjects.ImageSize,
					8,
					Color.FromArgb(90, Color.Black),
					Color.FromArgb(10, 10, 40),
					Color.White,
					Color.FromArgb(80, Color.White),
					true,
					3,
					3
				);
			}
			ListViewItem item = this.CreateItem(a.Tag[2].ToString(), img, objd, a.Name);

			bool added = false;
			if (objd.FunctionSort.InAppliances)
			{
				lvobjs[(int)Data.ObjFunctionSortBits.Appliances]
					.Items.Add((ListViewItem)item.Clone());
				added = true;
			}
			if (objd.FunctionSort.InDecorative)
			{
				lvobjs[(int)Data.ObjFunctionSortBits.Decorative]
					.Items.Add((ListViewItem)item.Clone());
				added = true;
			}
			if (objd.FunctionSort.InElectronics)
			{
				lvobjs[(int)Data.ObjFunctionSortBits.Electronics]
					.Items.Add((ListViewItem)item.Clone());
				added = true;
			}
			if (objd.FunctionSort.InGeneral)
			{
				lvobjs[(int)Data.ObjFunctionSortBits.General]
					.Items.Add((ListViewItem)item.Clone());
				added = true;
			}
			if (objd.FunctionSort.InLighting)
			{
				lvobjs[(int)Data.ObjFunctionSortBits.Lighting]
					.Items.Add((ListViewItem)item.Clone());
				added = true;
			}
			if (objd.FunctionSort.InPlumbing)
			{
				lvobjs[(int)Data.ObjFunctionSortBits.Plumbing]
					.Items.Add((ListViewItem)item.Clone());
				added = true;
			}
			if (objd.FunctionSort.InSeating)
			{
				lvobjs[(int)Data.ObjFunctionSortBits.Seating]
					.Items.Add((ListViewItem)item.Clone());
				added = true;
			}
			if (objd.FunctionSort.InSurfaces)
			{
				lvobjs[(int)Data.ObjFunctionSortBits.Surfaces]
					.Items.Add((ListViewItem)item.Clone());
				added = true;
			}
			if (!added)
			{
				lvobjs[8].Items.Add(item);
			}
		}
	}
}
