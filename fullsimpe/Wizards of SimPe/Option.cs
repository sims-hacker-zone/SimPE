using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SimPe.Wizards
{
	/// <summary>
	/// Summary description for Option.
	/// </summary>
	public class Option : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pbtop;
		private System.Windows.Forms.PictureBox pbbottom;
		internal System.Windows.Forms.Panel pnopt;
		private System.Windows.Forms.PictureBox pbstretch;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Label lbmsg;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		internal System.Windows.Forms.TextBox tbsims;
		private System.Windows.Forms.LinkLabel linkLabel2;
		private System.Windows.Forms.LinkLabel linkLabel3;
		internal System.Windows.Forms.TextBox tbsave;
		private System.Windows.Forms.LinkLabel linkLabel4;
		internal System.Windows.Forms.TextBox tbdds;
		internal System.Windows.Forms.LinkLabel llsims;
		internal System.Windows.Forms.LinkLabel llsave;
		private System.Windows.Forms.FolderBrowserDialog fbd;
		private System.Windows.Forms.Label lldds;
		private System.Windows.Forms.LinkLabel lldds2;
		private System.Windows.Forms.OpenFileDialog ofd;
		private System.ComponentModel.Container components = null;
		const string FONT_FAMILY = "Verdana";
		const string FONT_FAMILY_SERIF = "Georgia";
		private System.Windows.Forms.GroupBox taskBox1;
		private System.Windows.Forms.LinkLabel linkLabel5;

		public Option()
		{
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(typeof(Option));
			this.pbtop = new System.Windows.Forms.PictureBox();
			this.pbbottom = new System.Windows.Forms.PictureBox();
			this.pnopt = new System.Windows.Forms.Panel();
			this.taskBox1 = new System.Windows.Forms.GroupBox();
			this.linkLabel4 = new System.Windows.Forms.LinkLabel();
			this.tbsims = new System.Windows.Forms.TextBox();
			this.llsave = new System.Windows.Forms.LinkLabel();
			this.lldds2 = new System.Windows.Forms.LinkLabel();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.linkLabel2 = new System.Windows.Forms.LinkLabel();
			this.lbmsg = new System.Windows.Forms.Label();
			this.lldds = new System.Windows.Forms.Label();
			this.tbsave = new System.Windows.Forms.TextBox();
			this.llsims = new System.Windows.Forms.LinkLabel();
			this.linkLabel3 = new System.Windows.Forms.LinkLabel();
			this.tbdds = new System.Windows.Forms.TextBox();
			this.linkLabel5 = new System.Windows.Forms.LinkLabel();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.pbstretch = new System.Windows.Forms.PictureBox();
			this.fbd = new System.Windows.Forms.FolderBrowserDialog();
			this.ofd = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.pbtop)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbbottom)).BeginInit();
			this.pnopt.SuspendLayout();
			this.taskBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbstretch)).BeginInit();
			this.SuspendLayout();
			//
			// pbtop
			//
			this.pbtop.BackColor = System.Drawing.Color.White;
			this.pbtop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pbtop.Image = (
				(System.Drawing.Image)(resources.GetObject("pbtop.Image"))
			);
			this.pbtop.Location = new System.Drawing.Point(0, 0);
			this.pbtop.Name = "pbtop";
			this.pbtop.Size = new System.Drawing.Size(1022, 153);
			this.pbtop.TabIndex = 1;
			this.pbtop.TabStop = false;
			//
			// pbbottom
			//
			this.pbbottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pbbottom.Image = (
				(System.Drawing.Image)(resources.GetObject("pbbottom.Image"))
			);
			this.pbbottom.Location = new System.Drawing.Point(0, 602);
			this.pbbottom.Name = "pbbottom";
			this.pbbottom.Size = new System.Drawing.Size(1022, 24);
			this.pbbottom.TabIndex = 2;
			this.pbbottom.TabStop = false;
			//
			// pnopt
			//
			this.pnopt.Controls.Add(this.taskBox1);
			this.pnopt.Controls.Add(this.linkLabel5);
			this.pnopt.Controls.Add(this.linkLabel1);
			this.pnopt.Controls.Add(this.pbstretch);
			this.pnopt.Location = new System.Drawing.Point(0, 152);
			this.pnopt.Name = "pnopt";
			this.pnopt.Size = new System.Drawing.Size(1036, 452);
			this.pnopt.TabIndex = 3;
			//
			// taskBox1
			//
			this.taskBox1.BackColor = System.Drawing.Color.White;
			this.taskBox1.Controls.Add(this.linkLabel4);
			this.taskBox1.Controls.Add(this.tbsims);
			this.taskBox1.Controls.Add(this.llsave);
			this.taskBox1.Controls.Add(this.lldds2);
			this.taskBox1.Controls.Add(this.label2);
			this.taskBox1.Controls.Add(this.label1);
			this.taskBox1.Controls.Add(this.linkLabel2);
			this.taskBox1.Controls.Add(this.lbmsg);
			this.taskBox1.Controls.Add(this.lldds);
			this.taskBox1.Controls.Add(this.tbsave);
			this.taskBox1.Controls.Add(this.llsims);
			this.taskBox1.Controls.Add(this.linkLabel3);
			this.taskBox1.Controls.Add(this.tbdds);
			this.taskBox1.HeaderFont = new System.Drawing.Font(
				"Microsoft Sans Serif",
				10.25F,
				System.Drawing.FontStyle.Bold
			);
			this.taskBox1.HeaderText = "Options";
			this.taskBox1.IconLocation = new System.Drawing.Point(4, 12);
			this.taskBox1.IconSize = new System.Drawing.Size(32, 32);
			this.taskBox1.Location = new System.Drawing.Point(96, 42);
			this.taskBox1.Name = "taskBox1";
			this.taskBox1.Padding = new System.Windows.Forms.Padding(4, 44, 4, 4);
			this.taskBox1.Size = new System.Drawing.Size(748, 292);
			this.taskBox1.TabIndex = 32;
			//
			// linkLabel4
			//
			this.linkLabel4.AutoSize = true;
			this.linkLabel4.BackColor = System.Drawing.Color.Transparent;
			this.linkLabel4.LinkColor = System.Drawing.Color.Red;
			this.linkLabel4.Location = new System.Drawing.Point(638, 198);
			this.linkLabel4.Name = "linkLabel4";
			this.linkLabel4.Size = new System.Drawing.Size(42, 13);
			this.linkLabel4.TabIndex = 26;
			this.linkLabel4.TabStop = true;
			this.linkLabel4.Text = "Browse";
			this.linkLabel4.VisitedLinkColor = System.Drawing.Color.Maroon;
			this.linkLabel4.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.FldDds);
			//
			// tbsims
			//
			this.tbsims.Location = new System.Drawing.Point(18, 70);
			this.tbsims.Name = "tbsims";
			this.tbsims.Size = new System.Drawing.Size(599, 20);
			this.tbsims.TabIndex = 21;
			this.tbsims.TextChanged += new System.EventHandler(this.Change);
			//
			// llsave
			//
			this.llsave.AutoSize = true;
			this.llsave.BackColor = System.Drawing.Color.Transparent;
			this.llsave.LinkColor = System.Drawing.Color.Red;
			this.llsave.Location = new System.Drawing.Point(150, 118);
			this.llsave.Name = "llsave";
			this.llsave.Size = new System.Drawing.Size(44, 13);
			this.llsave.TabIndex = 28;
			this.llsave.TabStop = true;
			this.llsave.Text = "suggest";
			this.llsave.VisitedLinkColor = System.Drawing.Color.Maroon;
			this.llsave.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SugSave);
			//
			// lldds2
			//
			this.lldds2.BackColor = System.Drawing.Color.Transparent;
			this.lldds2.ForeColor = System.Drawing.Color.Gray;
			this.lldds2.LinkArea = new System.Windows.Forms.LinkArea(22, 4);
			this.lldds2.LinkColor = System.Drawing.Color.Red;
			this.lldds2.Location = new System.Drawing.Point(32, 249);
			this.lldds2.Name = "lldds2";
			this.lldds2.Size = new System.Drawing.Size(152, 23);
			this.lldds2.TabIndex = 30;
			this.lldds2.TabStop = true;
			this.lldds2.Text = "You can download them here";
			this.lldds2.UseCompatibleTextRendering = true;
			this.lldds2.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkDDS);
			//
			// label2
			//
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.Color.FromArgb(
				((int)(((byte)(64)))),
				((int)(((byte)(64)))),
				((int)(((byte)(64))))
			);
			this.label2.Location = new System.Drawing.Point(18, 180);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(102, 13);
			this.label2.TabIndex = 20;
			this.label2.Text = "Nvidia DDS Utilities:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			//
			// label1
			//
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.Color.FromArgb(
				((int)(((byte)(64)))),
				((int)(((byte)(64)))),
				((int)(((byte)(64))))
			);
			this.label1.Location = new System.Drawing.Point(18, 116);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(127, 13);
			this.label1.TabIndex = 19;
			this.label1.Text = "Sims 2 Savegame Folder:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			//
			// linkLabel2
			//
			this.linkLabel2.AutoSize = true;
			this.linkLabel2.BackColor = System.Drawing.Color.Transparent;
			this.linkLabel2.LinkColor = System.Drawing.Color.Red;
			this.linkLabel2.Location = new System.Drawing.Point(638, 70);
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Size = new System.Drawing.Size(42, 13);
			this.linkLabel2.TabIndex = 22;
			this.linkLabel2.TabStop = true;
			this.linkLabel2.Text = "Browse";
			this.linkLabel2.VisitedLinkColor = System.Drawing.Color.Maroon;
			this.linkLabel2.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.FldSims);
			//
			// lbmsg
			//
			this.lbmsg.AutoSize = true;
			this.lbmsg.BackColor = System.Drawing.Color.Transparent;
			this.lbmsg.ForeColor = System.Drawing.Color.FromArgb(
				((int)(((byte)(64)))),
				((int)(((byte)(64)))),
				((int)(((byte)(64))))
			);
			this.lbmsg.Location = new System.Drawing.Point(18, 54);
			this.lbmsg.Name = "lbmsg";
			this.lbmsg.Size = new System.Drawing.Size(126, 13);
			this.lbmsg.TabIndex = 18;
			this.lbmsg.Text = "Sims 2 Installation Folder:";
			this.lbmsg.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			//
			// lldds
			//
			this.lldds.BackColor = System.Drawing.Color.Transparent;
			this.lldds.ForeColor = System.Drawing.Color.Gray;
			this.lldds.Location = new System.Drawing.Point(29, 221);
			this.lldds.Name = "lldds";
			this.lldds.Size = new System.Drawing.Size(549, 18);
			this.lldds.TabIndex = 29;
			this.lldds.Text =
				"The Nvidia DDS Utilities were not found. You should install them in order to get "
				+ "a higher quality for your recolours.";
			//
			// tbsave
			//
			this.tbsave.Location = new System.Drawing.Point(18, 134);
			this.tbsave.Name = "tbsave";
			this.tbsave.Size = new System.Drawing.Size(599, 20);
			this.tbsave.TabIndex = 23;
			this.tbsave.TextChanged += new System.EventHandler(this.Change);
			//
			// llsims
			//
			this.llsims.AutoSize = true;
			this.llsims.BackColor = System.Drawing.Color.Transparent;
			this.llsims.LinkColor = System.Drawing.Color.Red;
			this.llsims.Location = new System.Drawing.Point(150, 54);
			this.llsims.Name = "llsims";
			this.llsims.Size = new System.Drawing.Size(44, 13);
			this.llsims.TabIndex = 27;
			this.llsims.TabStop = true;
			this.llsims.Text = "suggest";
			this.llsims.VisitedLinkColor = System.Drawing.Color.Maroon;
			this.llsims.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SugSims);
			//
			// linkLabel3
			//
			this.linkLabel3.AutoSize = true;
			this.linkLabel3.BackColor = System.Drawing.Color.Transparent;
			this.linkLabel3.Font = new System.Drawing.Font(
				"Microsoft Sans Serif",
				8.25F
			);
			this.linkLabel3.LinkColor = System.Drawing.Color.Red;
			this.linkLabel3.Location = new System.Drawing.Point(638, 134);
			this.linkLabel3.Name = "linkLabel3";
			this.linkLabel3.Size = new System.Drawing.Size(42, 13);
			this.linkLabel3.TabIndex = 24;
			this.linkLabel3.TabStop = true;
			this.linkLabel3.Text = "Browse";
			this.linkLabel3.VisitedLinkColor = System.Drawing.Color.Maroon;
			this.linkLabel3.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.FldSave);
			//
			// tbdds
			//
			this.tbdds.Location = new System.Drawing.Point(18, 198);
			this.tbdds.Name = "tbdds";
			this.tbdds.Size = new System.Drawing.Size(599, 20);
			this.tbdds.TabIndex = 25;
			this.tbdds.TextChanged += new System.EventHandler(this.Change);
			//
			// linkLabel5
			//
			this.linkLabel5.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Bottom
						| System.Windows.Forms.AnchorStyles.Left
					)
				)
			);
			this.linkLabel5.AutoSize = true;
			this.linkLabel5.BackColor = System.Drawing.Color.White;
			this.linkLabel5.Font = new System.Drawing.Font(
				"Microsoft Sans Serif",
				12F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.linkLabel5.LinkColor = System.Drawing.Color.Red;
			this.linkLabel5.Location = new System.Drawing.Point(170, 400);
			this.linkLabel5.Name = "linkLabel5";
			this.linkLabel5.Size = new System.Drawing.Size(97, 20);
			this.linkLabel5.TabIndex = 31;
			this.linkLabel5.TabStop = true;
			this.linkLabel5.Text = "System Test";
			this.linkLabel5.VisitedLinkColor = System.Drawing.Color.Maroon;
			this.linkLabel5.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(
					this.linkLabel5_LinkClicked
				);
			//
			// linkLabel1
			//
			this.linkLabel1.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Bottom
						| System.Windows.Forms.AnchorStyles.Left
					)
				)
			);
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.BackColor = System.Drawing.Color.White;
			this.linkLabel1.Font = new System.Drawing.Font(
				"Microsoft Sans Serif",
				12F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.linkLabel1.LinkColor = System.Drawing.Color.Red;
			this.linkLabel1.Location = new System.Drawing.Point(93, 400);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(49, 20);
			this.linkLabel1.TabIndex = 17;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Close";
			this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Maroon;
			this.linkLabel1.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Hide);
			//
			// pbstretch
			//
			this.pbstretch.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("pbstretch.BackgroundImage"))
			);
			this.pbstretch.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbstretch.Location = new System.Drawing.Point(0, 0);
			this.pbstretch.Name = "pbstretch";
			this.pbstretch.Size = new System.Drawing.Size(1036, 452);
			this.pbstretch.TabIndex = 8;
			this.pbstretch.TabStop = false;
			//
			// ofd
			//
			this.ofd.Filter = "DDS Utilities (nvdxt.exe)|nvdxt.exe";
			this.ofd.Title = "Locate Nvidia DDS Tools";
			//
			// Option
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1022, 626);
			this.Controls.Add(this.pnopt);
			this.Controls.Add(this.pbbottom);
			this.Controls.Add(this.pbtop);
			this.Name = "Option";
			this.Text = "Option";
			((System.ComponentModel.ISupportInitialize)(this.pbtop)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbbottom)).EndInit();
			this.pnopt.ResumeLayout(false);
			this.pnopt.PerformLayout();
			this.taskBox1.ResumeLayout(false);
			this.taskBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbstretch)).EndInit();
			this.ResumeLayout(false);
		}
		#endregion

		internal Form1 form1;

		private void Hide(
			object sender,
			System.Windows.Forms.LinkLabelLinkClickedEventArgs e
		)
		{
			if (PathProvider.RealSavegamePath != tbsave.Text)
				PathProvider.SimSavegameFolder = tbsave.Text;
			if (
				PathProvider.Global[Expansions.BaseGame].RealInstallFolder
				!= tbsims.Text
			)
				PathProvider.Global[Expansions.BaseGame].InstallFolder = tbsims.Text;
			if (PathProvider.Global.NvidiaDDSPath != tbdds.Text)
				PathProvider.Global.NvidiaDDSPath = tbdds.Text;
			form1.HideOptions(sender, e);
		}

		public static bool HaveObjects
		{
			get
			{
				return System.IO.File.Exists(
					System.IO.Path.Combine(
						PathProvider.Global[Expansions.BaseGame].InstallFolder,
						"TSData"
							+ Helper.PATH_SEP
							+ "Res"
							+ Helper.PATH_SEP
							+ "Objects"
							+ Helper.PATH_SEP
							+ "objects.package"
					)
				);
			}
		}

		public static bool HaveSavefolder
		{
			get
			{
				return System.IO.Directory.Exists(
					System.IO.Path.Combine(PathProvider.SimSavegameFolder, "Downloads")
				);
			}
		}

		public static bool HaveDDS
		{
			get { return System.IO.File.Exists(PathProvider.Global.NvidiaDDSTool); }
		}

		private void Change(object sender, System.EventArgs e)
		{
			llsims.Visible = !System.IO.File.Exists(
				System.IO.Path.Combine(
					tbsims.Text,
					"TSData"
						+ Helper.PATH_SEP
						+ "Res"
						+ Helper.PATH_SEP
						+ "Objects"
						+ Helper.PATH_SEP
						+ "objects.package"
				)
			);
			;
			llsave.Visible = !System.IO.Directory.Exists(
				System.IO.Path.Combine(tbsave.Text, "Downloads")
			);
			lldds.Visible = !System.IO.File.Exists(
				System.IO.Path.Combine(tbdds.Text, "nvdxt.exe")
			);
			lldds2.Visible = lldds.Visible;
		}

		private void SugSims(
			object sender,
			System.Windows.Forms.LinkLabelLinkClickedEventArgs e
		)
		{
			tbsims.Text = PathProvider.Global[Expansions.BaseGame].RealInstallFolder;
		}

		private void SugSave(
			object sender,
			System.Windows.Forms.LinkLabelLinkClickedEventArgs e
		)
		{
			tbsave.Text = PathProvider.RealSavegamePath;
		}

		private void FldSims(
			object sender,
			System.Windows.Forms.LinkLabelLinkClickedEventArgs e
		)
		{
			if (
				System.IO.Directory.Exists(
					PathProvider.Global[Expansions.BaseGame].RealInstallFolder
				)
			)
				fbd.SelectedPath = PathProvider
					.Global[Expansions.BaseGame]
					.RealInstallFolder;
			if (fbd.ShowDialog() == DialogResult.OK)
				tbsims.Text = fbd.SelectedPath;
		}

		private void FldSave(
			object sender,
			System.Windows.Forms.LinkLabelLinkClickedEventArgs e
		)
		{
			if (System.IO.Directory.Exists(PathProvider.RealSavegamePath))
				fbd.SelectedPath = PathProvider.RealSavegamePath;
			if (fbd.ShowDialog() == DialogResult.OK)
				tbsave.Text = fbd.SelectedPath;
		}

		private void LinkDDS(
			object sender,
			System.Windows.Forms.LinkLabelLinkClickedEventArgs e
		)
		{
			Help.ShowHelp(this, "https://developer.nvidia.com/legacy-texture-tools");
		}

		private void FldDds(
			object sender,
			System.Windows.Forms.LinkLabelLinkClickedEventArgs e
		)
		{
			if (
				System.IO.File.Exists(
					@"C:\Program Files\NVIDIA Corporation\DDS Utilities\nvdxt.exe"
				)
			)
				ofd.FileName =
					@"C:\Program Files\NVIDIA Corporation\DDS Utilities\nvdxt.exe";
			if (ofd.ShowDialog() == DialogResult.OK)
				tbdds.Text = System.IO.Path.GetDirectoryName(ofd.FileName);
		}

		private void linkLabel5_LinkClicked(
			object sender,
			System.Windows.Forms.LinkLabelLinkClickedEventArgs e
		)
		{
			this.linkLabel5.LinkVisited = true;
			CheckForm f = new CheckForm();
			f.ShowDialog();
		}
	}
}
