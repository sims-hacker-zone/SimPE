// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using SimPe.Data;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Cpf;
using SimPe.PackedFiles.Txtr;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for DownloadScan.
	/// </summary>
	public class DownloadScan : Form
	{
		const string STR_NOT_EP = "either original Maxis or not EP Ready";
		const string STR_COMP_DIR = "Compressed Dir incomplete";
		const string STR_COMP_SIZE = "Corrupted compressed Size";
		private ComboBox comboBox1;
		private FolderBrowserDialog fbd;
		private GroupBox lbdir;
		private LinkLabel linkLabel1;
		private ListView lv;
		private ColumnHeader columnHeader1;
		private ColumnHeader columnHeader2;
		private ColumnHeader columnHeader3;
		private TextBox tbfilename;
		private LinkLabel llopen;
		private LinkLabel lldis;
		private ColumnHeader columnHeader4;
		private ProgressBar pb;
		private GroupBox groupBox1;
		private CheckBox cbcompress;
		private CheckBox cbguid;
		private ColumnHeader columnHeader5;
		private System.ComponentModel.IContainer components;
		private LinkLabel llfix;
		private Label label1;
		private TextBox tbname;
		private CheckBox cbready;
		private GroupBox groupBox2;
		private LinkLabel llskin;
		private CheckBox cbbaby;
		private CheckBox cbtoddler;
		private CheckBox cbchild;
		private CheckBox cbteen;
		private CheckBox cbyoung;
		private CheckBox cbadult;
		private CheckBox cbelder;
		private GroupBox gbskin;
		private ImageList iList;
		private CheckBox cbprev;
		private PictureBox pbprev;
		private CheckBox cbact;
		private CheckBox cbskin;
		private CheckBox cbformal;
		private CheckBox cbpreg;
		private CheckBox cbundies;
		private CheckBox cbpj;
		private CheckBox cbevery;
		private CheckBox cbswim;
		private LinkLabel llcomp;

		internal Interfaces.IProviderRegistry prov;

		public DownloadScan()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			comboBox1.SelectedIndex = 0;
			Select(null, null);

			sorter = new ColumnSorter();

			if (Helper.WindowsRegistry.Config.UserName.Trim() != "")
			{
				tbname.Text = Helper.WindowsRegistry.Config.UserName + "-";
			}
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
			components = new System.ComponentModel.Container();
			comboBox1 = new ComboBox();
			fbd = new FolderBrowserDialog();
			lbdir = new GroupBox();
			llcomp = new LinkLabel();
			pbprev = new PictureBox();
			gbskin = new GroupBox();
			cbswim = new CheckBox();
			cbact = new CheckBox();
			cbskin = new CheckBox();
			cbformal = new CheckBox();
			cbpreg = new CheckBox();
			cbundies = new CheckBox();
			cbpj = new CheckBox();
			cbevery = new CheckBox();
			cbelder = new CheckBox();
			cbadult = new CheckBox();
			cbyoung = new CheckBox();
			cbteen = new CheckBox();
			cbchild = new CheckBox();
			cbtoddler = new CheckBox();
			cbbaby = new CheckBox();
			llskin = new LinkLabel();
			groupBox2 = new GroupBox();
			llfix = new LinkLabel();
			tbname = new TextBox();
			label1 = new Label();
			lldis = new LinkLabel();
			llopen = new LinkLabel();
			tbfilename = new TextBox();
			lv = new ListView();
			columnHeader1 = new ColumnHeader();
			columnHeader2 = new ColumnHeader();
			columnHeader5 = new ColumnHeader();
			columnHeader4 = new ColumnHeader();
			columnHeader3 = new ColumnHeader();
			linkLabel1 = new LinkLabel();
			pb = new ProgressBar();
			groupBox1 = new GroupBox();
			cbprev = new CheckBox();
			cbready = new CheckBox();
			cbguid = new CheckBox();
			cbcompress = new CheckBox();
			iList = new ImageList(components);
			lbdir.SuspendLayout();
			gbskin.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox1.SuspendLayout();
			SuspendLayout();
			//
			// comboBox1
			//
			comboBox1.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Left
						 | AnchorStyles.Right


			;
			//this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox1.Items.AddRange(
				new object[] { "Download Folder", "Teleport Folder", "..." }
			);
			comboBox1.Location = new Point(8, 8);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new Size(776, 21);
			comboBox1.TabIndex = 0;
			comboBox1.SelectedIndexChanged += new EventHandler(Select);
			//
			// lbdir
			//
			lbdir.Anchor =




								AnchorStyles.Top
								| AnchorStyles.Bottom
							 | AnchorStyles.Left
						 | AnchorStyles.Right


			;
			lbdir.Controls.Add(llcomp);
			lbdir.Controls.Add(pbprev);
			lbdir.Controls.Add(gbskin);
			lbdir.Controls.Add(groupBox2);
			lbdir.Controls.Add(lldis);
			lbdir.Controls.Add(llopen);
			lbdir.Controls.Add(tbfilename);
			lbdir.Controls.Add(lv);
			lbdir.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				0
			);
			lbdir.Location = new Point(8, 104);
			lbdir.Name = "lbdir";
			lbdir.Size = new Size(776, 452);
			lbdir.TabIndex = 1;
			lbdir.TabStop = false;
			lbdir.Text = "---";
			//
			// llcomp
			//
			llcomp.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			llcomp.AutoSize = true;
			llcomp.Enabled = false;
			llcomp.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				0
			);
			llcomp.Location = new Point(584, 80);
			llcomp.Name = "llcomp";
			llcomp.Size = new Size(106, 17);
			llcomp.TabIndex = 11;
			llcomp.TabStop = true;
			llcomp.Text = "fix Compression";
			llcomp.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					FixCompression
				);
			//
			// pbprev
			//
			pbprev.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Bottom
						 | AnchorStyles.Right


			;
			pbprev.BorderStyle = BorderStyle.FixedSingle;
			pbprev.Location = new Point(584, 408);
			pbprev.Name = "pbprev";
			pbprev.Size = new Size(184, 40);
			pbprev.TabIndex = 10;
			pbprev.TabStop = false;
			//
			// gbskin
			//
			gbskin.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			gbskin.Controls.Add(cbswim);
			gbskin.Controls.Add(cbact);
			gbskin.Controls.Add(cbskin);
			gbskin.Controls.Add(cbformal);
			gbskin.Controls.Add(cbpreg);
			gbskin.Controls.Add(cbundies);
			gbskin.Controls.Add(cbpj);
			gbskin.Controls.Add(cbevery);
			gbskin.Controls.Add(cbelder);
			gbskin.Controls.Add(cbadult);
			gbskin.Controls.Add(cbyoung);
			gbskin.Controls.Add(cbteen);
			gbskin.Controls.Add(cbchild);
			gbskin.Controls.Add(cbtoddler);
			gbskin.Controls.Add(cbbaby);
			gbskin.Controls.Add(llskin);
			gbskin.Enabled = false;
			gbskin.FlatStyle = FlatStyle.System;
			gbskin.Location = new Point(584, 192);
			gbskin.Name = "gbskin";
			gbskin.RightToLeft = RightToLeft.No;
			gbskin.Size = new Size(184, 208);
			gbskin.TabIndex = 9;
			gbskin.TabStop = false;
			//
			// cbswim
			//
			cbswim.FlatStyle = FlatStyle.System;
			cbswim.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			cbswim.Location = new Point(96, 120);
			cbswim.Name = "cbswim";
			cbswim.Size = new Size(80, 24);
			cbswim.TabIndex = 21;
			cbswim.Text = "Swim.";
			//
			// cbact
			//
			cbact.FlatStyle = FlatStyle.System;
			cbact.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			cbact.Location = new Point(96, 180);
			cbact.Name = "cbact";
			cbact.Size = new Size(64, 24);
			cbact.TabIndex = 20;
			cbact.Text = "Active";
			//
			// cbskin
			//
			cbskin.FlatStyle = FlatStyle.System;
			cbskin.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			cbskin.Location = new Point(96, 160);
			cbskin.Name = "cbskin";
			cbskin.Size = new Size(64, 24);
			cbskin.TabIndex = 19;
			cbskin.Text = "Skin";
			//
			// cbformal
			//
			cbformal.FlatStyle = FlatStyle.System;
			cbformal.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			cbformal.Location = new Point(96, 140);
			cbformal.Name = "cbformal";
			cbformal.Size = new Size(80, 24);
			cbformal.TabIndex = 18;
			cbformal.Text = "Formal";
			//
			// cbpreg
			//
			cbpreg.FlatStyle = FlatStyle.System;
			cbpreg.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			cbpreg.Location = new Point(16, 180);
			cbpreg.Name = "cbpreg";
			cbpreg.Size = new Size(64, 24);
			cbpreg.TabIndex = 17;
			cbpreg.Text = "Preg.";
			//
			// cbundies
			//
			cbundies.FlatStyle = FlatStyle.System;
			cbundies.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			cbundies.Location = new Point(16, 160);
			cbundies.Name = "cbundies";
			cbundies.Size = new Size(64, 24);
			cbundies.TabIndex = 16;
			cbundies.Text = "Undies";
			//
			// cbpj
			//
			cbpj.FlatStyle = FlatStyle.System;
			cbpj.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			cbpj.Location = new Point(16, 140);
			cbpj.Name = "cbpj";
			cbpj.Size = new Size(64, 24);
			cbpj.TabIndex = 15;
			cbpj.Text = "PJ";
			//
			// cbevery
			//
			cbevery.FlatStyle = FlatStyle.System;
			cbevery.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			cbevery.Location = new Point(16, 120);
			cbevery.Name = "cbevery";
			cbevery.Size = new Size(80, 24);
			cbevery.TabIndex = 14;
			cbevery.Text = "Everyday";
			//
			// cbelder
			//
			cbelder.FlatStyle = FlatStyle.System;
			cbelder.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			cbelder.Location = new Point(96, 84);
			cbelder.Name = "cbelder";
			cbelder.Size = new Size(64, 24);
			cbelder.TabIndex = 13;
			cbelder.Text = "Elder";
			//
			// cbadult
			//
			cbadult.FlatStyle = FlatStyle.System;
			cbadult.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			cbadult.Location = new Point(96, 64);
			cbadult.Name = "cbadult";
			cbadult.Size = new Size(64, 24);
			cbadult.TabIndex = 12;
			cbadult.Text = "Adult";
			//
			// cbyoung
			//
			cbyoung.FlatStyle = FlatStyle.System;
			cbyoung.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			cbyoung.Location = new Point(96, 24);
			cbyoung.Name = "cbyoung";
			cbyoung.Size = new Size(64, 32);
			cbyoung.TabIndex = 11;
			cbyoung.Text = "young Adult";
			//
			// cbteen
			//
			cbteen.FlatStyle = FlatStyle.System;
			cbteen.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			cbteen.Location = new Point(16, 84);
			cbteen.Name = "cbteen";
			cbteen.Size = new Size(64, 24);
			cbteen.TabIndex = 10;
			cbteen.Text = "teen";
			//
			// cbchild
			//
			cbchild.FlatStyle = FlatStyle.System;
			cbchild.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			cbchild.Location = new Point(16, 64);
			cbchild.Name = "cbchild";
			cbchild.Size = new Size(64, 24);
			cbchild.TabIndex = 9;
			cbchild.Text = "child";
			//
			// cbtoddler
			//
			cbtoddler.FlatStyle = FlatStyle.System;
			cbtoddler.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			cbtoddler.Location = new Point(16, 44);
			cbtoddler.Name = "cbtoddler";
			cbtoddler.Size = new Size(64, 24);
			cbtoddler.TabIndex = 8;
			cbtoddler.Text = "toddler";
			//
			// cbbaby
			//
			cbbaby.FlatStyle = FlatStyle.System;
			cbbaby.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			cbbaby.Location = new Point(16, 24);
			cbbaby.Name = "cbbaby";
			cbbaby.Size = new Size(64, 24);
			cbbaby.TabIndex = 7;
			cbbaby.Text = "baby";
			//
			// llskin
			//
			llskin.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			llskin.AutoSize = true;
			llskin.Enabled = false;
			llskin.Location = new Point(8, 0);
			llskin.Name = "llskin";
			llskin.Size = new Size(55, 17);
			llskin.TabIndex = 6;
			llskin.TabStop = true;
			llskin.Text = "set Skin";
			llskin.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					SetSkinAge
				);
			//
			// groupBox2
			//
			groupBox2.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			groupBox2.Controls.Add(llfix);
			groupBox2.Controls.Add(tbname);
			groupBox2.Controls.Add(label1);
			groupBox2.FlatStyle = FlatStyle.System;
			groupBox2.Location = new Point(584, 104);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(184, 72);
			groupBox2.TabIndex = 8;
			groupBox2.TabStop = false;
			//
			// llfix
			//
			llfix.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			llfix.AutoSize = true;
			llfix.Enabled = false;
			llfix.Location = new Point(8, 0);
			llfix.Name = "llfix";
			llfix.Size = new Size(102, 17);
			llfix.TabIndex = 5;
			llfix.TabStop = true;
			llfix.Text = "make EP Ready";
			llfix.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(Fix);
			//
			// tbname
			//
			tbname.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			tbname.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			tbname.Location = new Point(24, 45);
			tbname.Name = "tbname";
			tbname.Size = new Size(152, 21);
			tbname.TabIndex = 7;
			tbname.Text = "SimPe-";
			//
			// label1
			//
			label1.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			label1.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			label1.Location = new Point(8, 29);
			label1.Name = "label1";
			label1.Size = new Size(128, 16);
			label1.TabIndex = 6;
			label1.Text = "using Modelname";
			//
			// lldis
			//
			lldis.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			lldis.AutoSize = true;
			lldis.Enabled = false;
			lldis.Location = new Point(584, 64);
			lldis.Name = "lldis";
			lldis.Size = new Size(50, 17);
			lldis.TabIndex = 4;
			lldis.TabStop = true;
			lldis.Text = "disable";
			lldis.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(Disable);
			//
			// llopen
			//
			llopen.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			llopen.AutoSize = true;
			llopen.Enabled = false;
			llopen.Location = new Point(584, 48);
			llopen.Name = "llopen";
			llopen.Size = new Size(35, 17);
			llopen.TabIndex = 3;
			llopen.TabStop = true;
			llopen.Text = "open";
			llopen.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					Openpackage
				);
			//
			// tbfilename
			//
			tbfilename.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			tbfilename.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			tbfilename.Location = new Point(584, 24);
			tbfilename.Name = "tbfilename";
			tbfilename.ReadOnly = true;
			tbfilename.Size = new Size(184, 21);
			tbfilename.TabIndex = 2;
			tbfilename.Text = "";
			//
			// lv
			//
			lv.Anchor =




								AnchorStyles.Top
								| AnchorStyles.Bottom
							 | AnchorStyles.Left
						 | AnchorStyles.Right


			;
			lv.Columns.AddRange(
				new ColumnHeader[]
				{
					columnHeader1,
					columnHeader2,
					columnHeader5,
					columnHeader4,
					columnHeader3,
				}
			);
			lv.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			lv.FullRowSelect = true;
			lv.HideSelection = false;
			lv.Location = new Point(8, 24);
			lv.Name = "lv";
			lv.Size = new Size(568, 420);
			lv.TabIndex = 1;
			lv.View = View.Details;
			lv.ColumnClick += new ColumnClickEventHandler(
				Sort
			);
			lv.SelectedIndexChanged += new EventHandler(SelectPackage);
			//
			// columnHeader1
			//
			columnHeader1.Text = "Package File";
			columnHeader1.Width = 192;
			//
			// columnHeader2
			//
			columnHeader2.Text = "Content";
			columnHeader2.Width = 146;
			//
			// columnHeader5
			//
			columnHeader5.Text = "GUID";
			columnHeader5.Width = 75;
			//
			// columnHeader4
			//
			columnHeader4.Text = "Enabled";
			//
			// columnHeader3
			//
			columnHeader3.Text = "State";
			columnHeader3.Width = 89;
			//
			// linkLabel1
			//
			linkLabel1.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			linkLabel1.AutoSize = true;
			linkLabel1.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				0
			);
			linkLabel1.Location = new Point(752, 32);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new Size(33, 17);
			linkLabel1.TabIndex = 0;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "scan";
			linkLabel1.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(Scan);
			//
			// pb
			//
			pb.Anchor =



							AnchorStyles.Bottom
							| AnchorStyles.Left
						 | AnchorStyles.Right


			;
			pb.Location = new Point(0, 556);
			pb.Name = "pb";
			pb.Size = new Size(792, 16);
			pb.Step = 1;
			pb.TabIndex = 2;
			//
			// groupBox1
			//
			groupBox1.Controls.Add(cbprev);
			groupBox1.Controls.Add(cbready);
			groupBox1.Controls.Add(cbguid);
			groupBox1.Controls.Add(cbcompress);
			groupBox1.FlatStyle = FlatStyle.System;
			groupBox1.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				0
			);
			groupBox1.Location = new Point(8, 32);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(272, 64);
			groupBox1.TabIndex = 3;
			groupBox1.TabStop = false;
			groupBox1.Text = "Options";
			//
			// cbprev
			//
			cbprev.FlatStyle = FlatStyle.System;
			cbprev.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			cbprev.Location = new Point(168, 36);
			cbprev.Name = "cbprev";
			cbprev.Size = new Size(96, 24);
			cbprev.TabIndex = 3;
			cbprev.Text = "Preview";
			//
			// cbready
			//
			cbready.Checked = true;
			cbready.CheckState = CheckState.Checked;
			cbready.FlatStyle = FlatStyle.System;
			cbready.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			cbready.Location = new Point(168, 16);
			cbready.Name = "cbready";
			cbready.Size = new Size(96, 24);
			cbready.TabIndex = 2;
			cbready.Text = "EP Ready?";
			//
			// cbguid
			//
			cbguid.FlatStyle = FlatStyle.System;
			cbguid.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			cbguid.Location = new Point(16, 36);
			cbguid.Name = "cbguid";
			cbguid.Size = new Size(96, 24);
			cbguid.TabIndex = 1;
			cbguid.Text = "Guid check";
			//
			// cbcompress
			//
			cbcompress.FlatStyle = FlatStyle.System;
			cbcompress.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			cbcompress.Location = new Point(16, 16);
			cbcompress.Name = "cbcompress";
			cbcompress.Size = new Size(136, 24);
			cbcompress.TabIndex = 0;
			cbcompress.Text = "Compression check";
			//
			// iList
			//
			iList.ColorDepth = ColorDepth.Depth32Bit;
			iList.ImageSize = new Size(48, 48);
			iList.TransparentColor = Color.Transparent;
			//
			// DownloadScan
			//
			AutoScaleBaseSize = new Size(6, 14);
			ClientSize = new Size(792, 574);
			Controls.Add(groupBox1);
			Controls.Add(pb);
			Controls.Add(lbdir);
			Controls.Add(comboBox1);
			Controls.Add(linkLabel1);
			Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			FormBorderStyle =
				FormBorderStyle
				.SizableToolWindow;
			Name = "DownloadScan";
			ShowInTaskbar = false;
			Text = "Scan Folders";
			lbdir.ResumeLayout(false);
			gbskin.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion

		public string FileName { get; private set; } = null;

		private void Select(object sender, EventArgs e)
		{
			if (comboBox1.SelectedIndex == 2)
			{
				if (fbd.ShowDialog() == DialogResult.OK)
				{
					lbdir.Text = fbd.SelectedPath;
				}
			}
			else
			{
				lbdir.Text = comboBox1.SelectedIndex == 1
					? System.IO.Path.Combine(
									PathProvider.SimSavegameFolder,
									"Teleport"
								)
					: System.IO.Path.Combine(
									PathProvider.SimSavegameFolder,
									"Downloads"
								);
			}
		}

		/// <summary>
		/// returns true if the packages Compressed Directory is ok
		/// </summary>
		/// <param name="package"></param>
		/// <returns>0 if everything is ok, -1 if the List is incorrect, -2 if the uncompressed Sizes are wrong</returns>
		private int CheckCompressed(Packages.File package)
		{
			bool incomplete = false;
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in package.Index)
			{
				Interfaces.Files.IPackedFile file = package.Read(pfd);

				int nr = -1;
				if (package.FileListFile != null)
				{
					nr = package.FileListFile.FindFile(pfd);
				}

				bool inlist = nr != -1;

				if (inlist)
				{
					byte[] uncdata = file.UncompressedData;
					if (
						package.FileListFile.Items[nr].UncompressedSize
						!= uncdata.Length
					)
					{
						return -2;
					}
				}

				if (inlist != file.IsCompressed)
				{
					incomplete = true;
				}
			}

			return incomplete ? -1 : 0;
		}

		/// <summary>
		/// returns the Guid of this Object (if found)
		/// </summary>
		/// <param name="package"></param>
		/// <returns>0 or a Guid</returns>
		private uint[] CheckGuid(Packages.File package)
		{
			Interfaces.Files.IPackedFileDescriptor[] pfds = package.FindFiles(
				FileTypes.OBJD
			);
			uint[] res = new uint[pfds.Length];

			for (int i = 0; i < res.Length; i++)
			{
				res[i] = new PackedFiles.Wrapper.Objd(null).ProcessFile(pfds[i], package).SimId;
			}
			return res;
		}

		protected void AddFiles(string[] files, string note, int count, int offset)
		{
			ArrayList guids = new ArrayList();
			ArrayList aguids = new ArrayList();
			if (cbguid.Checked && (prov != null))
			{
				foreach (uint g in prov.OpcodeProvider.StoredMemories.Keys)
				{
					if (aguids.Contains(g))
					{
						guids.Add(g);
					}
					else
					{
						aguids.Add(g);
					}
				}
			}

			foreach (string file in files)
			{
				int val = offset++ * pb.Maximum / count;
				if (val > pb.Value)
				{
					pb.PerformStep();
				}

				if (val > pb.Value)
				{
					pb.Value = val;
				}

				string name = System.IO.Path.GetFileNameWithoutExtension(file);
				string desc = Localization.Manager.GetString("Unknown");
				string state = "OK";
				uint[] guid = new uint[0];
				Image img = null;

				try
				{
					Packages.File package = Packages.File.LoadFromFile(
						file
					);

					//find Texture
					Interfaces.Files.IPackedFileDescriptor[] pfds = null;
					try
					{
						if (cbprev.Checked)
						{
							pfds = package.FindFiles(FileTypes.TXTR);
							if (pfds.Length > 0)
							{

								MipMap mm = ((ImageData)
									new Txtr(null, false).ProcessFile(pfds[0], package).Blocks[0]).GetLargestTexture(iList.ImageSize);
								if (mm != null)
								{
									img = ImageLoader.Preview(
										mm.Texture,
										iList.ImageSize
									);
								}
							}
						} //if
					}
					catch { }

					//find Name
					pfds = package.FindFiles(FileTypes.CTSS);
					if (pfds.Length == 0)
					{
						pfds = package.FindFiles(FileTypes.STR);
					}

					if (pfds.Length > 0)
					{
						PackedFiles.Wrapper.StrItemList items =
							new PackedFiles.Wrapper.Str().ProcessFile(pfds[0], package).FallbackedLanguageItems(
								Helper.WindowsRegistry.LanguageCode
							);
						if (items != null)
						{
							if (items.Length > 0)
							{
								desc = items[0].Title;
							}
						}
					}
					else
					{
						//check if Recolor
						pfds = package.FindFiles(FileTypes.TXTR);
						if (pfds.Length > 0)
						{
							pfds = package.FindFiles(FileTypes.TXMT);
							if (pfds.Length > 0)
							{
								pfds = package.FindFiles(FileTypes.MMAT); //MMAT
								if (pfds.Length > 0)
								{
									desc =
										"[recolor] "
										+ new Cpf().ProcessFile(pfds[0], package).GetSaveItem("modelName").StringValue;
								}
							}
						}
					}

					bool isskin = false;
					pfds = package.FindFiles(FileTypes.GZPS);
					foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
					{

						desc = "[" + new Cpf().ProcessFile(pfd, package).GetSaveItem("type").StringValue + "] " + desc;
						isskin = true;
					}

					if (cbcompress.Checked)
					{
						int ret = CheckCompressed(package);
						if (ret == -1)
						{
							state = STR_COMP_DIR;
						}

						if (ret == -2)
						{
							state = STR_COMP_SIZE;
						}
						//if (ret==-3) state = "Corrupted Compressed Dir";
					}

					if (cbready.Checked && (!isskin))
					{
						if (
							(
								System
									.IO.Path.GetFileName(package.FileName)
									.Trim()
									.ToLower()
								!= System
									.IO.Path.GetFileName(ScenegraphHelper.MMAT_PACKAGE)
									.Trim()
									.ToLower()
							)
							&& (
								System
									.IO.Path.GetFileName(package.FileName)
									.Trim()
									.ToLower()
								!= System
									.IO.Path.GetFileName(ScenegraphHelper.GMND_PACKAGE)
									.Trim()
									.ToLower()
							)
							&& (
								package
									.FindFilesByGroup(MetaData.CUSTOM_GROUP)
									.Length == 0
							)
						)
						{
							pfds = package.FindFiles(FileTypes.TXTR);
							if (pfds.Length > 0)
							{
								state = STR_NOT_EP;
							}
						}
					}

					if (cbguid.Checked)
					{
						guid = CheckGuid(package);
						foreach (uint g in guid)
						{
							if (g != 0)
							{
								if (guids.Contains(g))
								{
									state = state == "OK" ? "Duplicate GUID" : "Duplicate GUID, " + state;
								}
								else
								{
									guids.Add(g);
								}
							}
						} //foreach

						//package.Reader.Close();
					}
				}
				catch (Exception ex)
				{
					state = "Not loaded, " + ex.Message;
				}

				ListViewItem lvi = new ListViewItem
				{
					Text = name
				};
				lvi.SubItems.Add(desc);
				lvi.Tag = file;
				if (guid.Length > 0)
				{
					string s = "";
					for (int i = 0; i < guid.Length; i++)
					{
						if (i != 0)
						{
							s += ", ";
						}

						s += "0x" + Helper.HexString(guid[i]);
					}
					lvi.SubItems.Add(s);
				}
				else
				{
					lvi.SubItems.Add("");
				}

				lvi.SubItems.Add(note);
				lvi.SubItems.Add(state);

				if (img != null)
				{
					iList.Images.Add(img);
					lvi.ImageIndex = iList.Images.Count - 1;
				}

				lv.Items.Add(lvi);
				Application.DoEvents();
			}
		}

		private void Scan(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			lv.Items.Clear();
			iList.Images.Clear();
			lv.SmallImageList = null;
			iList.ImageSize = cbprev.Checked ? new Size(48, 48) : new Size(16, 16);

			lv.SmallImageList = iList;

			lv.ListViewItemSorter = null;
			tbfilename.Text = "";
			pb.Value = 0;
			if (!System.IO.Directory.Exists(lbdir.Text))
			{
				return;
			}

			Cursor = Cursors.WaitCursor;
			string[] files = System.IO.Directory.GetFiles(lbdir.Text, "*.package");
			string[] dis_files = System.IO.Directory.GetFiles(lbdir.Text, "*.simpedis");
			AddFiles(files, "yes", files.Length + dis_files.Length, 0);
			AddFiles(
				dis_files,
				"no",
				files.Length + dis_files.Length,
				files.Length
			);
			Cursor = Cursors.Default;
			lv.ListViewItemSorter = sorter;
			pb.Value = 0;
		}

		private ColumnSorter sorter;

		private void Sort(object sender, ColumnClickEventArgs e)
		{
			if (((ListView)sender).ListViewItemSorter == null)
			{
				return;
			}

			sorter.CurrentColumn = e.Column;
			((ListView)sender).Sort();
		}

		void SetSkinBoxes(CheckBox cb, uint age, uint cmp)
		{
			if ((age & cmp) == cmp)
			{
				if (cb.CheckState == CheckState.Unchecked)
				{
					cb.CheckState = CheckState.Checked;
				}
			}
			else
			{
				if (cb.CheckState == CheckState.Checked)
				{
					cb.CheckState = CheckState.Indeterminate;
				}
			}
		}

		void SetSkinBoxes(Cpf cpf)
		{
			uint age = cpf.GetSaveItem("age").UIntegerValue;
			uint cat = cpf.GetSaveItem("category").UIntegerValue;

			SetSkinBoxes(cbbaby, age, (uint)Ages.Baby);
			SetSkinBoxes(cbtoddler, age, (uint)Ages.Toddler);
			SetSkinBoxes(cbchild, age, (uint)Ages.Child);
			SetSkinBoxes(cbteen, age, (uint)Ages.Teen);
			SetSkinBoxes(cbyoung, age, (uint)Ages.YoungAdult);
			SetSkinBoxes(cbadult, age, (uint)Ages.Adult);
			SetSkinBoxes(cbelder, age, (uint)Ages.Elder);

			SetSkinBoxes(cbact, cat, (uint)SkinCategories.Activewear);
			SetSkinBoxes(cbevery, cat, (uint)SkinCategories.Everyday);
			SetSkinBoxes(cbformal, cat, (uint)SkinCategories.Formal);
			SetSkinBoxes(cbpj, cat, (uint)SkinCategories.PJ);
			SetSkinBoxes(cbpreg, cat, (uint)SkinCategories.Pregnant);
			SetSkinBoxes(cbskin, cat, (uint)SkinCategories.Skin);
			SetSkinBoxes(cbswim, cat, (uint)SkinCategories.Swimmwear);
			SetSkinBoxes(cbundies, cat, (uint)SkinCategories.Undies);
		}

		void SetSkinBoxes(ListViewItem lvi)
		{
			if (lvi == null)
			{
				cbbaby.CheckState = CheckState.Unchecked;
				cbtoddler.CheckState = CheckState.Unchecked;
				cbchild.CheckState = CheckState.Unchecked;
				cbteen.CheckState = CheckState.Unchecked;
				cbyoung.CheckState = CheckState.Unchecked;
				cbadult.CheckState = CheckState.Unchecked;
				cbelder.CheckState = CheckState.Unchecked;

				cbact.CheckState = CheckState.Unchecked;
				cbevery.CheckState = CheckState.Unchecked;
				cbformal.CheckState = CheckState.Unchecked;
				cbpj.CheckState = CheckState.Unchecked;
				cbpreg.CheckState = CheckState.Unchecked;
				cbskin.CheckState = CheckState.Unchecked;
				cbswim.CheckState = CheckState.Unchecked;
				cbundies.CheckState = CheckState.Unchecked;
			}
			else
			{
				Packages.File skin = Packages.File.LoadFromFile(
					(string)lvi.Tag
				);
				Interfaces.Files.IPackedFileDescriptor[] pfds = skin.FindFiles(
					FileTypes.GZPS
				);
				foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
				{
					Cpf cpf =
						new Cpf().ProcessFile(pfd, skin);

					if (cpf.GetSaveItem("type").StringValue == "skin")
					{
						SetSkinBoxes(cpf);
					}
				}
			}
		}

		delegate void ShowTextureDelegate(ListViewItem lvi);

		void ShowTexture(ListViewItem lvi)
		{
			if ((lvi == null) || (!cbprev.Checked))
			{
				pbprev.Image = null;
			}
			else
			{
				Packages.File skin = Packages.File.LoadFromFile(
					(string)lvi.Tag
				);
				Interfaces.Files.IPackedFileDescriptor[] pfds = skin.FindFiles(
					FileTypes.TXTR
				);
				foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
				{

					MipMap mm = ((ImageData)new Txtr(null, false).ProcessFile(pfd, skin).Blocks[0]).GetLargestTexture(pb.Size);
					if (mm != null)
					{
						Image img = ImageLoader.Preview(mm.Texture, pbprev.Size);
						pbprev.Image = img;
					}
					break;
				}
			}
		}

		private void SelectPackage(object sender, EventArgs e)
		{
			tbfilename.Text = "";
			llopen.Enabled = false;
			lldis.Enabled = false;
			llfix.Enabled = false;
			llskin.Enabled = false;
			gbskin.Enabled = false;
			llcomp.Enabled = false;
			SetSkinBoxes((ListViewItem)null);

			if (lv.SelectedItems.Count == 0)
			{
				return;
			}

			llopen.Enabled = lv.SelectedItems.Count == 1;
			lldis.Enabled = true;

			foreach (ListViewItem lvi in lv.SelectedItems)
			{
				if (lvi.SubItems[4].Text == STR_NOT_EP)
				{
					llfix.Enabled = true;
				}

				if (
					(lvi.SubItems[4].Text.IndexOf(STR_COMP_DIR) != -1)
					|| (lvi.SubItems[4].Text.IndexOf(STR_COMP_SIZE) != -1)
				)
				{
					llcomp.Enabled = true;
				}
			}

			if (Helper.WindowsRegistry.HiddenMode)
			{
				llfix.Enabled = true;
			}

			bool oner = lv.SelectedItems.Count == 1;
			foreach (ListViewItem lvi in lv.SelectedItems)
			{
				if (lvi.SubItems[1].Text.StartsWith("[skin]"))
				{
					gbskin.Enabled = true;
					llskin.Enabled = true;
					SetSkinBoxes(lvi);
				}

				if (
					lvi.SubItems[1].Text.StartsWith("[skin]")
					|| lvi.SubItems[1].Text.StartsWith("[recolor]")
				)
				{
					if (oner)
					{
						object[] os = new object[1];
						os[0] = lvi;
						BeginInvoke(new ShowTextureDelegate(ShowTexture), os);
					}
				}
			}

			tbfilename.Text = lv.SelectedItems[0].Text;

			lldis.Text = System.IO.File.Exists(
					System.IO.Path.Combine(
						lbdir.Text,
						lv.SelectedItems[0].Text + ".package"
					)
				)
				? "disable"
				: "enable";
		}

		private void Openpackage(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (lv.SelectedItems.Count != 1)
			{
				return;
			}

			FileName = System.IO.Path.Combine(
				lbdir.Text,
				lv.SelectedItems[0].Text + ".package"
			);
			if (!System.IO.File.Exists(FileName))
			{
				FileName = System.IO.Path.Combine(
					lbdir.Text,
					lv.SelectedItems[0].Text + ".simpedis"
				);
			}

			if (!System.IO.File.Exists(FileName))
			{
				FileName = null;
			}
			else
			{
				Close();
			}
		}

		private void Disable(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (lv.SelectedItems.Count == 0)
			{
				return;
			}

			foreach (ListViewItem lvi in lv.SelectedItems)
			{
				string filename = System.IO.Path.Combine(
					lbdir.Text,
					lvi.Text + ".package"
				);
				string target = System.IO.Path.Combine(
					lbdir.Text,
					lvi.Text + ".simpedis"
				);

				Packages.StreamItem si =
					Packages.StreamFactory.GetStreamItem(filename, false);
				si?.Close();

				si = Packages.StreamFactory.GetStreamItem(target, false);
				si?.Close();

				try
				{
					if (System.IO.File.Exists(filename))
					{
						System.IO.File.Move(filename, target);
						lvi.SubItems[3].Text = "no";
					}
					else
					{
						System.IO.File.Move(target, filename);
						lvi.SubItems[3].Text = "yes";
					}
				}
				catch (Exception ex)
				{
					Helper.ExceptionMessage("", ex);
				}
			}

			SelectPackage(null, null);
		}

		private void Fix(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (lv.SelectedItems.Count == 0)
			{
				return;
			}

			string mname = tbname.Text;
			DateTime now = DateTime.Now;
			mname += now.Date.ToShortDateString();
			mname += "-" + now.Hour.ToString("x");
			mname += now.Minute.ToString("x");
			mname += now.Second.ToString("x");
			mname += now.Millisecond.ToString("x");
			//mname += "_"+System.DateTime.Now.Ticks.ToString();
			WaitingScreen.Wait();
			try
			{
				int count = lv.Items.Count;
				int pos = 0;
				foreach (ListViewItem lvi in lv.SelectedItems)
				{
					//only non EP Ready packages
					if (
						(!Helper.WindowsRegistry.HiddenMode)
						&& (lvi.SubItems[4].Text != STR_NOT_EP)
					)
					{
						continue;
					}

					string filename = System.IO.Path.Combine(
						lbdir.Text,
						lvi.Text + ".package"
					);
					pb.Value = pos++ * pb.Maximum / count;
					Application.DoEvents();

					try
					{
						FixPackage.Fix(
							filename,
							mname,
							FixVersion.UniversityReady2
						);
					}
					catch (Exception ex)
					{
						Helper.ExceptionMessage("", ex);
					}
				}
				pb.Value = 0;
			}
			finally
			{
				WaitingScreen.Stop();
			}
			SelectPackage(null, null);
		}

		void SetSkinAge(CheckBox cb, ref uint age, uint cmp)
		{
			if (cb.CheckState == CheckState.Indeterminate)
			{
				return;
			}

			age |= cmp;
			if (cb.CheckState == CheckState.Unchecked)
			{
				age ^= cmp;
			}
		}

		private void FixCompression(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (lv.SelectedItems.Count < 1)
			{
				return;
			}

			for (int i = 0; i < lv.SelectedItems.Count; i++)
			{
				pb.Value = i * pb.Maximum / lv.SelectedItems.Count;
				Application.DoEvents();
				ListViewItem lvi = lv.SelectedItems[i];
				if (
					(lvi.SubItems[4].Text.IndexOf(STR_COMP_DIR) != -1)
					|| (lvi.SubItems[4].Text.IndexOf(STR_COMP_SIZE) != -1)
				)
				{
					FileName = System.IO.Path.Combine(
						lbdir.Text,
						lvi.Text + ".package"
					);
					if (!System.IO.File.Exists(FileName))
					{
						FileName = System.IO.Path.Combine(
							lbdir.Text,
							lvi.Text + ".simpedis"
						);
					}

					if (System.IO.File.Exists(FileName))
					{
						Packages.GeneratableFile pkg =
							Packages.File.LoadFromFile(FileName);
						foreach (
							Interfaces.Files.IPackedFileDescriptor pfd in pkg.Index
						)
						{
							Interfaces.Files.IPackedFile file = pkg.Read(pfd);
							pfd.UserData = file.UncompressedData;

							pfd.MarkForReCompress =
								file.IsCompressed
								|| MetaData.CompressionCandidates.Contains(
									pfd.Type
								)
							;
						}

						pkg.Save();
					}
				}
			}
			pb.Value = 0;
		}

		void AddUniversityFields(Cpf cpf)
		{
			if (cpf.GetItem("product") == null)
			{
				CpfItem i =
					new CpfItem
					{
						Name = "product",
						UIntegerValue = 1
					};
				cpf.AddItem(i);
			}

			if (cpf.GetItem("version") == null)
			{
				CpfItem i =
					new CpfItem
					{
						Name = "version",
						UIntegerValue = 2
					};
				cpf.AddItem(i);
			}
		}

		bool hinted = false;

		private void SetSkinAge(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (lv.SelectedItems.Count == 0)
			{
				return;
			}

			uint age = 0;
			uint cat = 0;

			try
			{
				int count = lv.SelectedItems.Count;
				int pos = 0;
				foreach (ListViewItem lvi in lv.SelectedItems)
				{
					pb.Value = pos++ * pb.Maximum / count;
					Application.DoEvents();

					if (lvi.SubItems[1].Text.StartsWith("[skin]"))
					{
						string name = (string)lvi.Tag;
						Packages.GeneratableFile skin =
							Packages.File.LoadFromFile(name);

						Interfaces.Files.IPackedFileDescriptor[] pfds =
							skin.FindFiles(FileTypes.GZPS);
						foreach (
							Interfaces.Files.IPackedFileDescriptor pfd in pfds
						)
						{
							Cpf cpf =
								new Cpf().ProcessFile(pfd, skin);

							if (cpf.GetSaveItem("type").StringValue == "skin")
							{
								age = cpf.GetSaveItem("age").UIntegerValue;
								cat = cpf.GetSaveItem("category").UIntegerValue;

								SetSkinAge(cbbaby, ref age, (uint)Ages.Baby);
								SetSkinAge(cbtoddler, ref age, (uint)Ages.Toddler);
								SetSkinAge(cbchild, ref age, (uint)Ages.Child);
								SetSkinAge(cbteen, ref age, (uint)Ages.Teen);
								SetSkinAge(
									cbyoung,
									ref age,
									(uint)Ages.YoungAdult
								);
								if (cbyoung.Checked)
								{
									AddUniversityFields(cpf);
								}

								SetSkinAge(cbadult, ref age, (uint)Ages.Adult);
								SetSkinAge(cbelder, ref age, (uint)Ages.Elder);

								SetSkinAge(
									cbact,
									ref cat,
									(uint)SkinCategories.Activewear
								);
								SetSkinAge(
									cbevery,
									ref cat,
									(uint)SkinCategories.Everyday
								);
								SetSkinAge(
									cbformal,
									ref cat,
									(uint)SkinCategories.Formal
								);
								SetSkinAge(cbpj, ref cat, (uint)SkinCategories.PJ);
								SetSkinAge(
									cbpreg,
									ref cat,
									(uint)SkinCategories.Pregnant
								);
								SetSkinAge(
									cbskin,
									ref cat,
									(uint)SkinCategories.Skin
								);
								SetSkinAge(
									cbswim,
									ref cat,
									(uint)SkinCategories.Swimmwear
								);
								SetSkinAge(
									cbundies,
									ref cat,
									(uint)SkinCategories.Undies
								);

								cpf.GetSaveItem("age").UIntegerValue = age;
								cpf.GetSaveItem("category").UIntegerValue = cat;

								cpf.SynchronizeUserData();
							}
						}

						skin.Save();
					}
				}
				pb.Value = 0;
			}
			finally
			{
				WaitingScreen.Stop();
			}

			if (!hinted)
			{
				hinted = true;
				MessageBox.Show(
					"If your Game should crash after converting a Skin, pleas scan the Folder again with the 'check Compression' Option checked.\nIf it reports any Errors, please fix them using 'fix Compression'"
				);
			}
			SelectPackage(null, null);
		}
	}
}
