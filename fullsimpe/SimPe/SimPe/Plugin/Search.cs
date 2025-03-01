// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Windows.Forms;

using Ambertation.Windows.Forms;

using SimPe.PackedFiles.Wrapper;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for Search.
	/// </summary>
	public class Search : Form
	{
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private ListBox lblist;
		private Button btopen;
		private Label label1;
		private TextBox tbOpcode;
		private LinkLabel llsearch;
		private ExtProgressBar pb;
		private System.Windows.Forms.TabPage tabPage2;
		private LinkLabel linkLabel1;
		private TextBox tbflname;
		private Label label2;
		private System.Windows.Forms.TabPage tabPage3;
		private LinkLabel linkLabel2;
		private Label label3;
		private TextBox tbsimname;
		private System.Windows.Forms.TabPage tabPage4;
		private Label label4;
		private LinkLabel linkLabel3;
		private TextBox tbpropname;
		private TextBox tbbhavgroup;
		private Label label5;
		private ToolTip toolTip1;
		private RadioButton rbfull;
		private RadioButton rbstart;
		private RadioButton rbend;
		private RadioButton rbcont;
		private CheckBox cbusefileindex;
		private System.Windows.Forms.TabPage tabPage5;
		private LinkLabel linkLabel4;
		private TextBox tbguid;
		private Label label6;
		private TextBox tbpropval;
		private Label label7;
		private CheckBox cblastname;
		private Panel panel1;
		private System.ComponentModel.IContainer components;

		public Search()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			prov = null;
			if (Helper.WindowsRegistry.UseBigIcons)
			{
				lblist.Font = new System.Drawing.Font("Verdana", 11F);
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
			tabControl1 = new System.Windows.Forms.TabControl();
			tabPage1 = new System.Windows.Forms.TabPage();
			tbbhavgroup = new TextBox();
			label5 = new Label();
			llsearch = new LinkLabel();
			tbOpcode = new TextBox();
			label1 = new Label();
			tabPage2 = new System.Windows.Forms.TabPage();
			cbusefileindex = new CheckBox();
			linkLabel1 = new LinkLabel();
			tbflname = new TextBox();
			label2 = new Label();
			tabPage3 = new System.Windows.Forms.TabPage();
			cblastname = new CheckBox();
			linkLabel2 = new LinkLabel();
			tbsimname = new TextBox();
			label3 = new Label();
			tabPage4 = new System.Windows.Forms.TabPage();
			tbpropval = new TextBox();
			label7 = new Label();
			rbcont = new RadioButton();
			rbend = new RadioButton();
			rbstart = new RadioButton();
			rbfull = new RadioButton();
			linkLabel3 = new LinkLabel();
			tbpropname = new TextBox();
			label4 = new Label();
			tabPage5 = new System.Windows.Forms.TabPage();
			linkLabel4 = new LinkLabel();
			tbguid = new TextBox();
			label6 = new Label();
			lblist = new ListBox();
			btopen = new Button();
			pb = new ExtProgressBar();
			toolTip1 = new ToolTip(components);
			panel1 = new Panel();
			tabControl1.SuspendLayout();
			tabPage1.SuspendLayout();
			tabPage2.SuspendLayout();
			tabPage3.SuspendLayout();
			tabPage4.SuspendLayout();
			tabPage5.SuspendLayout();
			panel1.SuspendLayout();
			SuspendLayout();
			//
			// tabControl1
			//
			tabControl1.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Left
						 | AnchorStyles.Right


			;
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage2);
			tabControl1.Controls.Add(tabPage3);
			tabControl1.Controls.Add(tabPage4);
			tabControl1.Controls.Add(tabPage5);
			tabControl1.Font = new System.Drawing.Font(
				"Verdana",
				9.75F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tabControl1.Location = new System.Drawing.Point(8, 10);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new System.Drawing.Size(768, 108);
			tabControl1.TabIndex = 0;
			//
			// tabPage1
			//
			tabPage1.Controls.Add(tbbhavgroup);
			tabPage1.Controls.Add(label5);
			tabPage1.Controls.Add(llsearch);
			tabPage1.Controls.Add(tbOpcode);
			tabPage1.Controls.Add(label1);
			tabPage1.Location = new System.Drawing.Point(4, 25);
			tabPage1.Name = "tabPage1";
			tabPage1.Size = new System.Drawing.Size(760, 79);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "BHAV";
			//
			// tbbhavgroup
			//
			tbbhavgroup.Location = new System.Drawing.Point(140, 37);
			tbbhavgroup.Name = "tbbhavgroup";
			tbbhavgroup.Size = new System.Drawing.Size(100, 23);
			tbbhavgroup.TabIndex = 4;
			toolTip1.SetToolTip(
				tbbhavgroup,
				"leave empty to search in all Groups"
			);
			//
			// label5
			//
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label5.Location = new System.Drawing.Point(84, 42);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(50, 13);
			label5.TabIndex = 3;
			label5.Text = "Group:";
			//
			// llsearch
			//
			llsearch.Anchor =


						AnchorStyles.Bottom
						| AnchorStyles.Right


			;
			llsearch.AutoSize = true;
			llsearch.FlatStyle = FlatStyle.System;
			llsearch.Font = new System.Drawing.Font(
				"Verdana",
				9.75F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			llsearch.Location = new System.Drawing.Point(515, 57);
			llsearch.Name = "llsearch";
			llsearch.Size = new System.Drawing.Size(57, 16);
			llsearch.TabIndex = 2;
			llsearch.TabStop = true;
			llsearch.Text = "search";
			llsearch.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					BhavSearch
				);
			//
			// tbOpcode
			//
			tbOpcode.Location = new System.Drawing.Point(140, 8);
			tbOpcode.Name = "tbOpcode";
			tbOpcode.Size = new System.Drawing.Size(100, 23);
			tbOpcode.TabIndex = 1;
			tbOpcode.Text = "0x0000";
			//
			// label1
			//
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label1.Location = new System.Drawing.Point(16, 16);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(119, 13);
			label1.TabIndex = 0;
			label1.Text = "Contains Opcode:";
			//
			// tabPage2
			//
			tabPage2.Controls.Add(cbusefileindex);
			tabPage2.Controls.Add(linkLabel1);
			tabPage2.Controls.Add(tbflname);
			tabPage2.Controls.Add(label2);
			tabPage2.Location = new System.Drawing.Point(4, 25);
			tabPage2.Name = "tabPage2";
			tabPage2.Size = new System.Drawing.Size(760, 79);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "RCOL";
			//
			// cbusefileindex
			//
			cbusefileindex.FlatStyle = FlatStyle.System;
			cbusefileindex.Location = new System.Drawing.Point(80, 35);
			cbusefileindex.Name = "cbusefileindex";
			cbusefileindex.Size = new System.Drawing.Size(120, 24);
			cbusefileindex.TabIndex = 6;
			cbusefileindex.Text = "scan in all Files";
			//
			// linkLabel1
			//
			linkLabel1.Anchor =


						AnchorStyles.Bottom
						| AnchorStyles.Right


			;
			linkLabel1.AutoSize = true;
			linkLabel1.FlatStyle = FlatStyle.System;
			linkLabel1.Font = new System.Drawing.Font(
				"Verdana",
				9.75F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			linkLabel1.Location = new System.Drawing.Point(515, 57);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(57, 16);
			linkLabel1.TabIndex = 5;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "search";
			linkLabel1.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					RcolSearch
				);
			//
			// tbflname
			//
			tbflname.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Left
						 | AnchorStyles.Right


			;
			tbflname.Location = new System.Drawing.Point(90, 8);
			tbflname.Name = "tbflname";
			tbflname.Size = new System.Drawing.Size(653, 23);
			tbflname.TabIndex = 4;
			//
			// label2
			//
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label2.Location = new System.Drawing.Point(13, 15);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(71, 13);
			label2.TabIndex = 3;
			label2.Text = "Filename:";
			//
			// tabPage3
			//
			tabPage3.Controls.Add(cblastname);
			tabPage3.Controls.Add(linkLabel2);
			tabPage3.Controls.Add(tbsimname);
			tabPage3.Controls.Add(label3);
			tabPage3.Location = new System.Drawing.Point(4, 25);
			tabPage3.Name = "tabPage3";
			tabPage3.Size = new System.Drawing.Size(760, 79);
			tabPage3.TabIndex = 2;
			tabPage3.Text = "Sims";
			//
			// cblastname
			//
			cblastname.AutoSize = true;
			cblastname.Location = new System.Drawing.Point(88, 37);
			cblastname.Name = "cblastname";
			cblastname.Size = new System.Drawing.Size(219, 20);
			cblastname.TabIndex = 9;
			cblastname.Text = "Use Last or Family name only";
			cblastname.UseVisualStyleBackColor = true;
			//
			// linkLabel2
			//
			linkLabel2.Anchor =


						AnchorStyles.Bottom
						| AnchorStyles.Right


			;
			linkLabel2.AutoSize = true;
			linkLabel2.FlatStyle = FlatStyle.System;
			linkLabel2.Font = new System.Drawing.Font(
				"Verdana",
				9.75F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			linkLabel2.Location = new System.Drawing.Point(515, 57);
			linkLabel2.Name = "linkLabel2";
			linkLabel2.Size = new System.Drawing.Size(57, 16);
			linkLabel2.TabIndex = 8;
			linkLabel2.TabStop = true;
			linkLabel2.Text = "search";
			linkLabel2.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(FindSim);
			//
			// tbsimname
			//
			tbsimname.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Left
						 | AnchorStyles.Right


			;
			tbsimname.Location = new System.Drawing.Point(95, 8);
			tbsimname.Name = "tbsimname";
			tbsimname.Size = new System.Drawing.Size(648, 23);
			tbsimname.TabIndex = 8;
			//
			// label3
			//
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label3.Location = new System.Drawing.Point(13, 12);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(76, 13);
			label3.TabIndex = 6;
			label3.Text = "Sim Name:";
			//
			// tabPage4
			//
			tabPage4.Controls.Add(tbpropval);
			tabPage4.Controls.Add(label7);
			tabPage4.Controls.Add(rbcont);
			tabPage4.Controls.Add(rbend);
			tabPage4.Controls.Add(rbstart);
			tabPage4.Controls.Add(rbfull);
			tabPage4.Controls.Add(linkLabel3);
			tabPage4.Controls.Add(tbpropname);
			tabPage4.Controls.Add(label4);
			tabPage4.Location = new System.Drawing.Point(4, 25);
			tabPage4.Name = "tabPage4";
			tabPage4.Size = new System.Drawing.Size(760, 79);
			tabPage4.TabIndex = 3;
			tabPage4.Text = "Property Set";
			//
			// tbpropval
			//
			tbpropval.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Left
						 | AnchorStyles.Right


			;
			tbpropval.Location = new System.Drawing.Point(454, 8);
			tbpropval.Name = "tbpropval";
			tbpropval.Size = new System.Drawing.Size(287, 23);
			tbpropval.TabIndex = 16;
			//
			// label7
			//
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label7.Location = new System.Drawing.Point(401, 13);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(47, 13);
			label7.TabIndex = 15;
			label7.Text = "Value:";
			//
			// rbcont
			//
			rbcont.FlatStyle = FlatStyle.System;
			rbcont.Location = new System.Drawing.Point(317, 37);
			rbcont.Name = "rbcont";
			rbcont.Size = new System.Drawing.Size(88, 24);
			rbcont.TabIndex = 14;
			rbcont.Text = "contains";
			//
			// rbend
			//
			rbend.FlatStyle = FlatStyle.System;
			rbend.Location = new System.Drawing.Point(253, 37);
			rbend.Name = "rbend";
			rbend.Size = new System.Drawing.Size(48, 24);
			rbend.TabIndex = 13;
			rbend.Text = "end";
			//
			// rbstart
			//
			rbstart.Checked = true;
			rbstart.FlatStyle = FlatStyle.System;
			rbstart.Location = new System.Drawing.Point(181, 37);
			rbstart.Name = "rbstart";
			rbstart.Size = new System.Drawing.Size(56, 24);
			rbstart.TabIndex = 12;
			rbstart.TabStop = true;
			rbstart.Text = "start";
			//
			// rbfull
			//
			rbfull.FlatStyle = FlatStyle.System;
			rbfull.Location = new System.Drawing.Point(88, 37);
			rbfull.Name = "rbfull";
			rbfull.Size = new System.Drawing.Size(77, 24);
			rbfull.TabIndex = 11;
			rbfull.Text = "match";
			//
			// linkLabel3
			//
			linkLabel3.Anchor =


						AnchorStyles.Bottom
						| AnchorStyles.Right


			;
			linkLabel3.AutoSize = true;
			linkLabel3.FlatStyle = FlatStyle.System;
			linkLabel3.Font = new System.Drawing.Font(
				"Verdana",
				9.75F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			linkLabel3.Location = new System.Drawing.Point(515, 57);
			linkLabel3.Name = "linkLabel3";
			linkLabel3.Size = new System.Drawing.Size(57, 16);
			linkLabel3.TabIndex = 10;
			linkLabel3.TabStop = true;
			linkLabel3.Text = "search";
			linkLabel3.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					GzpsSearch
				);
			//
			// tbpropname
			//
			tbpropname.Location = new System.Drawing.Point(67, 8);
			tbpropname.Name = "tbpropname";
			tbpropname.Size = new System.Drawing.Size(287, 23);
			tbpropname.TabIndex = 9;
			tbpropname.Text = "name";
			//
			// label4
			//
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label4.Location = new System.Drawing.Point(13, 13);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(48, 13);
			label4.TabIndex = 8;
			label4.Text = "Name:";
			//
			// tabPage5
			//
			tabPage5.Controls.Add(linkLabel4);
			tabPage5.Controls.Add(tbguid);
			tabPage5.Controls.Add(label6);
			tabPage5.Location = new System.Drawing.Point(4, 25);
			tabPage5.Name = "tabPage5";
			tabPage5.Size = new System.Drawing.Size(760, 79);
			tabPage5.TabIndex = 4;
			tabPage5.Text = "GUID";
			//
			// linkLabel4
			//
			linkLabel4.Anchor =


						AnchorStyles.Bottom
						| AnchorStyles.Right


			;
			linkLabel4.AutoSize = true;
			linkLabel4.FlatStyle = FlatStyle.System;
			linkLabel4.Font = new System.Drawing.Font(
				"Verdana",
				9.75F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			linkLabel4.Location = new System.Drawing.Point(515, 57);
			linkLabel4.Name = "linkLabel4";
			linkLabel4.Size = new System.Drawing.Size(57, 16);
			linkLabel4.TabIndex = 11;
			linkLabel4.TabStop = true;
			linkLabel4.Text = "search";
			linkLabel4.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					GuidSearch
				);
			//
			// tbguid
			//
			tbguid.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Left
						 | AnchorStyles.Right


			;
			tbguid.Location = new System.Drawing.Point(87, 7);
			tbguid.Name = "tbguid";
			tbguid.Size = new System.Drawing.Size(147, 23);
			tbguid.TabIndex = 10;
			tbguid.Text = "0x00000000";
			//
			// label6
			//
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label6.Location = new System.Drawing.Point(40, 11);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(44, 13);
			label6.TabIndex = 9;
			label6.Text = "GUID:";
			//
			// lblist
			//
			lblist.Anchor =




								AnchorStyles.Top
								| AnchorStyles.Bottom
							 | AnchorStyles.Left
						 | AnchorStyles.Right


			;
			lblist.HorizontalScrollbar = true;
			lblist.IntegralHeight = false;
			lblist.Location = new System.Drawing.Point(8, 124);
			lblist.Name = "lblist";
			lblist.Size = new System.Drawing.Size(768, 344);
			lblist.TabIndex = 1;
			lblist.SelectedIndexChanged += new EventHandler(
				SelectFile
			);
			//
			// btopen
			//
			btopen.Anchor =


						AnchorStyles.Bottom
						| AnchorStyles.Right


			;
			btopen.FlatStyle = FlatStyle.System;
			btopen.Location = new System.Drawing.Point(701, 474);
			btopen.Name = "btopen";
			btopen.Size = new System.Drawing.Size(75, 23);
			btopen.TabIndex = 2;
			btopen.Text = "Open";
			btopen.Click += new EventHandler(Open);
			//
			// pb
			//
			pb.Anchor =



							AnchorStyles.Bottom
							| AnchorStyles.Left
						 | AnchorStyles.Right


			;
			pb.Location = new System.Drawing.Point(8, 481);
			pb.Maximum = 1000;
			pb.Name = "pb";
			pb.Size = new System.Drawing.Size(687, 16);
			pb.TabIndex = 3;
			pb.BackColor = System.Drawing.Color.Transparent;
			pb.BorderColor = System.Drawing.Color.FromArgb(
				(byte)100,
				(byte)0,
				(byte)0,
				(byte)0
			);
			pb.Gradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			pb.Quality = true;
			pb.TokenCount = 2;
			pb.UnselectedColor = System.Drawing.Color.Black;
			pb.UseTokenBuffer = false;
			//
			// panel1
			//
			panel1.Anchor =




								AnchorStyles.Top
								| AnchorStyles.Bottom
							 | AnchorStyles.Left
						 | AnchorStyles.Right


			;
			panel1.BackColor = System.Drawing.Color.Transparent;
			panel1.Controls.Add(pb);
			panel1.Controls.Add(btopen);
			panel1.Controls.Add(lblist);
			panel1.Controls.Add(tabControl1);
			panel1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(786, 503);
			panel1.TabIndex = 4;
			//
			// Search
			//
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			ClientSize = new System.Drawing.Size(784, 501);
			Controls.Add(panel1);
			Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			FormBorderStyle =
				FormBorderStyle
				.SizableToolWindow;
			Name = "Search";
			ShowInTaskbar = false;
			Text = "Search";
			tabControl1.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage1.PerformLayout();
			tabPage2.ResumeLayout(false);
			tabPage2.PerformLayout();
			tabPage3.ResumeLayout(false);
			tabPage3.PerformLayout();
			tabPage4.ResumeLayout(false);
			tabPage4.PerformLayout();
			tabPage5.ResumeLayout(false);
			tabPage5.PerformLayout();
			panel1.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion

		#region Seeker Infrastructure
		/// <summary>
		/// Delegate for Search Functions
		/// </summary>
		public delegate SearchItem SeekerFunction(
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile package,
			Interfaces.IProviderRegistry prov
		);

		protected void StartSearch(
			SeekerFunction fkt,
			Interfaces.Files.IPackedFileDescriptor[] pfds
		)
		{
			try
			{
				pb.Value = 0;
				btopen.Tag = null;
				lblist.Items.Clear();
				//lblist.BeginUpdate();
				btopen.Enabled = false;
				Cursor = Cursors.WaitCursor;

				int count = 0;
				foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
				{
					pb.Value = count++ * pb.Maximum / pfds.Length;
					SearchItem si = fkt(pfd, package, prov);
					if (si != null)
					{
						lblist.Items.Add(si);
					}
				}

				lblist.Sorted = true;
				if (lblist.Items.Count == 0)
				{
					MessageBox.Show("No Files were found");
				}
				else
				{
					lblist.SelectedIndex = 0;
				}
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				Cursor = Cursors.Default;
				pb.Value = 0;
				//lblist.EndUpdate();
			}
		}
		#endregion

		#region Seekers
		/// <summary>
		/// Searches BHAV Files
		/// </summary>
		/// <param name="pfd"></param>
		/// <param name="package"></param>
		/// <param name="prov"></param>
		/// <returns>Null if no match or a valid SearchItem Object</returns>
		public SearchItem BhavSearch(
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile package,
			Interfaces.IProviderRegistry prov
		)
		{
			ushort opcode = Convert.ToUInt16(tbOpcode.Text, 16);

			//group Filter
			if (tbbhavgroup.Text.Trim() != "")
			{
				uint group = Convert.ToUInt32(tbbhavgroup.Text, 16);
				if (pfd.Group != group)
				{
					return null;
				}
			}

			Bhav bhav = new Bhav(prov.OpcodeProvider);
			bhav.ProcessData(pfd, package);

			foreach (Instruction i in bhav)
			{
				if (i.OpCode == opcode)
				{
					return new SearchItem(bhav.FileName, pfd);
				}
			}

			return null;
		}

		/// <summary>
		/// Searches RCOL Files
		/// </summary>
		/// <param name="pfd"></param>
		/// <param name="package"></param>
		/// <param name="prov"></param>
		/// <returns>Null if no match or a valid SearchItem Object</returns>
		public SearchItem RcolSearch(
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile package,
			Interfaces.IProviderRegistry prov
		)
		{
			string flname = Hashes.StripHashFromName(tbflname.Text);
			uint inst = Hashes.InstanceHash(flname);
			uint st = Hashes.SubTypeHash(flname);

			if ((pfd.Instance == inst) && ((pfd.SubType == st) || pfd.SubType == 0))
			{
				Rcol rcol = new GenericRcol(prov, false);
				rcol.ProcessData(pfd, package);
				return new SearchItem(rcol.FileName, pfd);
			}

			return null;
		}

		/// <summary>
		/// Searches Sims
		/// </summary>
		/// <param name="pfd"></param>
		/// <param name="package"></param>
		/// <param name="prov"></param>
		/// <returns>Null if no match or a valid SearchItem Object</returns>
		public SearchItem SdscSearch(
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile package,
			Interfaces.IProviderRegistry prov
		)
		{
			string name = tbsimname.Text.Trim().ToLower();

			SDesc sdesc = new SDesc(
				prov.SimNameProvider,
				prov.SimFamilynameProvider,
				prov.SimDescriptionProvider
			);
			sdesc.ProcessData(pfd, package);

			string ext = "";
			if (sdesc.Unlinked != 0x00)
			{
				ext += "unlinked";
			}

			if (!sdesc.AvailableCharacterData)
			{
				if (ext.Trim() != "")
				{
					ext += ", no Character Data";
				}
			}

			if (ext.Trim() != "")
			{
				ext = " (" + ext + ")";
			}

			string simname = "";

			if (cblastname.Checked)
			{
				simname = sdesc.SimFamilyName;
				simname = simname.Trim().ToLower();
				if (simname == name)
				{
					return new SearchItem(
						sdesc.SimName + " " + sdesc.SimFamilyName + ext,
						pfd
					);
				}

				simname = sdesc.HouseholdName;
				simname = simname.Trim().ToLower();
				if (simname == name)
				{
					return new SearchItem(
						sdesc.SimName + " " + sdesc.SimFamilyName + ext,
						pfd
					);
				}
			}
			else
			{
				simname = sdesc.SimName + " " + sdesc.SimFamilyName;
				simname = simname.Trim().ToLower();
				if (simname == name)
				{
					return new SearchItem(
						sdesc.SimName + " " + sdesc.SimFamilyName + ext,
						pfd
					);
				}

				simname = sdesc.SimName + " " + sdesc.HouseholdName;
				simname = simname.Trim().ToLower();
				if (simname == name)
				{
					return new SearchItem(
						sdesc.SimName + " " + sdesc.SimFamilyName + ext,
						pfd
					);
				}

				simname = sdesc.SimName;
				simname = simname.Trim().ToLower();
				if (simname == name)
				{
					return new SearchItem(
						sdesc.SimName + " " + sdesc.SimFamilyName + ext,
						pfd
					);
				}
			}

			return null;
		}

		/// <summary>
		/// Searches BHAV Files
		/// </summary>
		/// <param name="pfd"></param>
		/// <param name="package"></param>
		/// <param name="prov"></param>
		/// <returns>Null if no match or a valid SearchItem Object</returns>
		public SearchItem GzpsSearch(
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile package,
			Interfaces.IProviderRegistry prov
		)
		{
			ushort opcode = Convert.ToUInt16(tbOpcode.Text, 16);
			Cpf cpf = new Cpf();
			cpf.ProcessData(pfd, package);

			//foreach (SimPe.PackedFiles.Wrapper.CpfItem i in cpf.Items)
			{
				bool check = false;
				string s1 = cpf.GetSaveItem(tbpropname.Text)
					.StringValue.Trim()
					.ToLower(); //i.StringValue.Trim().ToLower();
				string s2 = tbpropval.Text.Trim().ToLower();
				if (rbfull.Checked)
				{
					check = s1 == s2;
				}

				if (rbstart.Checked)
				{
					check = s1.StartsWith(s2);
				}

				if (rbend.Checked)
				{
					check = s1.EndsWith(s2);
				}

				if (rbcont.Checked)
				{
					check = s1.IndexOf(s2) != -1;
				}

				if (check)
				{
					return new SearchItem(cpf.FileDescriptor.ToString(), pfd);
				}
			}

			return null;
		}

		/// <summary>
		/// Searches Sims
		/// </summary>
		/// <param name="pfd"></param>
		/// <param name="package"></param>
		/// <param name="prov"></param>
		/// <returns>Null if no match or a valid SearchItem Object</returns>
		public SearchItem GuidSearch(
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile package,
			Interfaces.IProviderRegistry prov
		)
		{
			uint guid = Convert.ToUInt32(tbguid.Text, 16);

			ExtObjd objd =
				new ExtObjd();
			objd.ProcessData(pfd, package);

			return objd.Guid == guid ? new SearchItem(objd.FileName, pfd) : null;
		}
		#endregion

		private void FindSim(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			StartSearch(
				new SeekerFunction(SdscSearch),
				package.FindFiles(Data.MetaData.SIM_DESCRIPTION_FILE)
			);
		}

		Interfaces.Files.IPackageFile package;
		Interfaces.Files.IPackedFileDescriptor pfd;
		internal Interfaces.IProviderRegistry prov;

		internal Interfaces.Files.IPackedFileDescriptor Execute(
			Interfaces.Files.IPackageFile package
		)
		{
			this.package = package;
			pfd = null;
			RemoteControl.ShowSubForm(this);

			return pfd;
		}

		internal void Reset()
		{
			lblist.Items.Clear();
			btopen.Enabled = false;
		}

		private void BhavSearch(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			StartSearch(
				new SeekerFunction(BhavSearch),
				package.FindFiles(Data.MetaData.BHAV_FILE)
			);
		}

		private void Open(object sender, EventArgs e)
		{
			if (lblist.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				SearchItem si = (SearchItem)lblist.Items[lblist.SelectedIndex];
				pfd = si.Descriptor;
				Close();
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}

		private void SelectFile(object sender, EventArgs e)
		{
			btopen.Enabled = false;
			if (lblist.SelectedIndex < 0)
			{
				return;
			}

			btopen.Enabled = btopen.Tag == null;
		}

		private void GzpsSearch(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			Interfaces.Files.IPackedFileDescriptor[] pfds =
				(Interfaces.Files.IPackedFileDescriptor[])
					Helper.Merge(
						package.FindFiles(0xEBCF3E27),
						package.FindFiles(0x4C697E5A),
						typeof(Interfaces.Files.IPackedFileDescriptor)
					);
			StartSearch(new SeekerFunction(GzpsSearch), pfds);
		}

		private void GuidSearch(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			Interfaces.Files.IPackedFileDescriptor[] pfds = package.FindFiles(
				Data.MetaData.OBJD_FILE
			);
			StartSearch(new SeekerFunction(GuidSearch), pfds);
		}

		private void RcolSearch(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (cbusefileindex.Checked)
			{
				WaitingScreen.Wait();
				try
				{
					FileTableBase.FileIndex.Load();
				}
				finally
				{
					WaitingScreen.Stop(this);
				}

				lblist.Items.Clear();
				Packages.PackedFileDescriptor pfd =
					new Packages.PackedFileDescriptor
					{
						SubType = Hashes.SubTypeHash(
					Hashes.StripHashFromName(tbflname.Text)
				),
						Instance = Hashes.InstanceHash(
					Hashes.StripHashFromName(tbflname.Text)
				)
					};

				Interfaces.Scenegraph.IScenegraphFileIndexItem[] items =
					FileTableBase.FileIndex.FindFileByInstance(pfd.LongInstance);

				//short Index
				if (items.Length == 0)
				{
					pfd.SubType = 0;
					items = FileTableBase.FileIndex.FindFileByInstance(pfd.LongInstance);
				}

				foreach (
					Interfaces.Scenegraph.IScenegraphFileIndexItem item in items
				)
				{
					lblist.Items.Add(item.Package.FileName);
				}

				btopen.Tag = true;
			}
			else
			{
				StartSearch(
					new SeekerFunction(RcolSearch),
					package.FindFile(Hashes.StripHashFromName(tbflname.Text))
				);
			}
		}
	}
}
