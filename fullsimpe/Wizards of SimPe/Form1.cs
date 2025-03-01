// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SimPe.Wizards
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pbtop;
		private System.Windows.Forms.PictureBox pbbottom;
		private System.Windows.Forms.Panel pndrop;
		private System.Windows.Forms.PictureBox pbstretch;
		private System.Windows.Forms.Label lbstep;
		private System.Windows.Forms.LinkLabel llnext;
		private System.Windows.Forms.LinkLabel llback;
		private System.Windows.Forms.LinkLabel llopt;
		internal System.Windows.Forms.Panel pnP;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label lbmsg;
		internal System.Windows.Forms.Label lbPmsg;
		internal Ambertation.Windows.Forms.ExtProgressBar pbP;

		FormStep1 step1;

		public Form1()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.lbstep.ForeColor = Color.FromArgb(0x40, this.lbstep.ForeColor);
			this.lbmsg.ForeColor = Color.FromArgb(0xb0, this.lbmsg.ForeColor);

			step1 = new FormStep1();
			prevsteps.Push(step1);
			ShowStep(step1, true);
			if ((!Option.HaveObjects) || (!Option.HaveSavefolder))
			{
				MessageBox.Show(
					"Your Path settings are invalid. Wizards of SimPe will direct you to the Options Page.\n\nYou can just click on the 'Suggest' Buttons there, to get the default Paths. If the 'Suggest' Button disapears, your Path is set correct.",
					"Warning",
					MessageBoxButtons.OK
				);
				this.ShowOptions(null, null);
			}

			Wait.Bar = new SimPe.Wizards.WaitBarControl(this);
			if (SimPe.FileTable.FileIndex == null)
				SimPe.FileTable.FileIndex = new SimPe.Plugin.FileIndex();
			SimPe.Packages.PackageMaintainer.Maintainer.FileIndex = SimPe
				.FileTable
				.FileIndex;
			if (Helper.WindowsRegistry.UseBigIcons)
				this.pndrop.Font = new System.Drawing.Font("Tahoma", 12F);
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
				new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.pbtop = new System.Windows.Forms.PictureBox();
			this.pbbottom = new System.Windows.Forms.PictureBox();
			this.pndrop = new System.Windows.Forms.Panel();
			this.llopt = new System.Windows.Forms.LinkLabel();
			this.llback = new System.Windows.Forms.LinkLabel();
			this.llnext = new System.Windows.Forms.LinkLabel();
			this.pbstretch = new System.Windows.Forms.PictureBox();
			this.lbstep = new System.Windows.Forms.Label();
			this.pnP = new System.Windows.Forms.Panel();
			this.pbP = new Ambertation.Windows.Forms.ExtProgressBar();
			this.lbPmsg = new System.Windows.Forms.Label();
			this.lbmsg = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pbtop)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbbottom)).BeginInit();
			this.pndrop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbstretch)).BeginInit();
			this.pnP.SuspendLayout();
			this.SuspendLayout();
			//
			// pbtop
			//
			this.pbtop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pbtop.Image = (
				(System.Drawing.Image)(resources.GetObject("pbtop.Image"))
			);
			this.pbtop.Location = new System.Drawing.Point(0, 0);
			this.pbtop.Name = "pbtop";
			this.pbtop.Size = new System.Drawing.Size(1032, 153);
			this.pbtop.TabIndex = 0;
			this.pbtop.TabStop = false;
			//
			// pbbottom
			//
			this.pbbottom.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("pbbottom.BackgroundImage"))
			);
			this.pbbottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pbbottom.Location = new System.Drawing.Point(0, 612);
			this.pbbottom.Name = "pbbottom";
			this.pbbottom.Size = new System.Drawing.Size(1032, 24);
			this.pbbottom.TabIndex = 1;
			this.pbbottom.TabStop = false;
			//
			// pndrop
			//
			this.pndrop.Controls.Add(this.llopt);
			this.pndrop.Controls.Add(this.llback);
			this.pndrop.Controls.Add(this.llnext);
			this.pndrop.Controls.Add(this.pbstretch);
			this.pndrop.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pndrop.Location = new System.Drawing.Point(0, 153);
			this.pndrop.Name = "pndrop";
			this.pndrop.Size = new System.Drawing.Size(1032, 459);
			this.pndrop.TabIndex = 4;
			//
			// llopt
			//
			this.llopt.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Bottom
						| System.Windows.Forms.AnchorStyles.Left
					)
				)
			);
			this.llopt.AutoSize = true;
			this.llopt.BackColor = System.Drawing.Color.White;
			this.llopt.Font = new System.Drawing.Font(
				"Verdana",
				9.75F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.llopt.LinkColor = System.Drawing.Color.Red;
			this.llopt.Location = new System.Drawing.Point(24, 444);
			this.llopt.Name = "llopt";
			this.llopt.Size = new System.Drawing.Size(64, 16);
			this.llopt.TabIndex = 16;
			this.llopt.TabStop = true;
			this.llopt.Text = "Options";
			this.llopt.VisitedLinkColor = System.Drawing.Color.Maroon;
			this.llopt.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(
					this.ShowOptions
				);
			//
			// llback
			//
			this.llback.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Bottom
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.llback.AutoSize = true;
			this.llback.BackColor = System.Drawing.Color.White;
			this.llback.Enabled = false;
			this.llback.Font = new System.Drawing.Font(
				"Verdana",
				12F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.llback.LinkColor = System.Drawing.Color.Red;
			this.llback.Location = new System.Drawing.Point(858, 443);
			this.llback.Name = "llback";
			this.llback.Size = new System.Drawing.Size(68, 18);
			this.llback.TabIndex = 13;
			this.llback.TabStop = true;
			this.llback.Text = "< Back";
			this.llback.VisitedLinkColor = System.Drawing.Color.Maroon;
			this.llback.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Back);
			//
			// llnext
			//
			this.llnext.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Bottom
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.llnext.AutoSize = true;
			this.llnext.BackColor = System.Drawing.Color.White;
			this.llnext.Enabled = false;
			this.llnext.Font = new System.Drawing.Font(
				"Verdana",
				12F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.llnext.LinkColor = System.Drawing.Color.Red;
			this.llnext.Location = new System.Drawing.Point(942, 443);
			this.llnext.Name = "llnext";
			this.llnext.Size = new System.Drawing.Size(68, 18);
			this.llnext.TabIndex = 12;
			this.llnext.TabStop = true;
			this.llnext.Text = "Next >";
			this.llnext.VisitedLinkColor = System.Drawing.Color.Maroon;
			this.llnext.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Next);
			//
			// pbstretch
			//
			this.pbstretch.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("pbstretch.BackgroundImage"))
			);
			this.pbstretch.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbstretch.Location = new System.Drawing.Point(0, 0);
			this.pbstretch.Name = "pbstretch";
			this.pbstretch.Size = new System.Drawing.Size(1032, 459);
			this.pbstretch.TabIndex = 5;
			this.pbstretch.TabStop = false;
			//
			// lbstep
			//
			this.lbstep.AutoSize = true;
			this.lbstep.BackColor = System.Drawing.Color.Transparent;
			this.lbstep.Font = new System.Drawing.Font(
				"Georgia",
				60F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.lbstep.ForeColor = System.Drawing.Color.White;
			this.lbstep.Location = new System.Drawing.Point(922, 0);
			this.lbstep.Name = "lbstep";
			this.lbstep.Size = new System.Drawing.Size(98, 96);
			this.lbstep.TabIndex = 10;
			this.lbstep.Text = "0";
			this.lbstep.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// pnP
			//
			this.pnP.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Bottom
						| System.Windows.Forms.AnchorStyles.Left
					)
				)
			);
			this.pnP.BackColor = System.Drawing.Color.White;
			this.pnP.Controls.Add(this.pbP);
			this.pnP.Controls.Add(this.lbPmsg);
			this.pnP.Location = new System.Drawing.Point(24, 596);
			this.pnP.Name = "pnP";
			this.pnP.Size = new System.Drawing.Size(634, 24);
			this.pnP.TabIndex = 5;
			this.pnP.Visible = false;
			//
			// pbP
			//
			this.pbP.BackColor = System.Drawing.Color.Transparent;
			this.pbP.BorderColor = System.Drawing.Color.FromArgb(
				((int)(((byte)(100)))),
				((int)(((byte)(0)))),
				((int)(((byte)(0)))),
				((int)(((byte)(0))))
			);
			this.pbP.Gradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.pbP.GradientEndColor = System.Drawing.Color.White;
			this.pbP.GradientStartColor = System.Drawing.Color.White;
			this.pbP.Location = new System.Drawing.Point(0, 4);
			this.pbP.Maximum = 100;
			this.pbP.Minimum = 0;
			this.pbP.Name = "pbP";
			this.pbP.ProgressBackColor = System.Drawing.SystemColors.Window;
			this.pbP.Quality = true;
			this.pbP.SelectedColor = System.Drawing.Color.Orange;
			this.pbP.Size = new System.Drawing.Size(372, 16);
			this.pbP.TabIndex = 16;
			this.pbP.TokenCount = 20;
			this.pbP.UnselectedColor = System.Drawing.Color.Gray;
			this.pbP.UseTokenBuffer = true;
			this.pbP.Value = 50;
			//
			// lbPmsg
			//
			this.lbPmsg.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						(
							System.Windows.Forms.AnchorStyles.Top
							| System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.lbPmsg.Font = new System.Drawing.Font(
				"Georgia",
				9.75F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.lbPmsg.ForeColor = System.Drawing.Color.Silver;
			this.lbPmsg.Location = new System.Drawing.Point(378, 0);
			this.lbPmsg.Name = "lbPmsg";
			this.lbPmsg.Size = new System.Drawing.Size(256, 24);
			this.lbPmsg.TabIndex = 15;
			this.lbPmsg.Text = "Please Wait";
			this.lbPmsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			//
			// lbmsg
			//
			this.lbmsg.BackColor = System.Drawing.Color.Transparent;
			this.lbmsg.Font = new System.Drawing.Font(
				"Georgia",
				12F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.lbmsg.ForeColor = System.Drawing.Color.DimGray;
			this.lbmsg.Location = new System.Drawing.Point(248, 14);
			this.lbmsg.Name = "lbmsg";
			this.lbmsg.Size = new System.Drawing.Size(598, 72);
			this.lbmsg.TabIndex = 6;
			this.lbmsg.Text = "Description";
			this.lbmsg.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// Form1
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(
				((int)(((byte)(102)))),
				((int)(((byte)(102)))),
				((int)(((byte)(153))))
			);
			this.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("$this.BackgroundImage"))
			);
			this.ClientSize = new System.Drawing.Size(1032, 636);
			this.Controls.Add(this.pnP);
			this.Controls.Add(this.pndrop);
			this.Controls.Add(this.pbbottom);
			this.Controls.Add(this.lbmsg);
			this.Controls.Add(this.lbstep);
			this.Controls.Add(this.pbtop);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Opacity = 0.94;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Wizards of SimPe";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Close);
			((System.ComponentModel.ISupportInitialize)(this.pbtop)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbbottom)).EndInit();
			this.pndrop.ResumeLayout(false);
			this.pndrop.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbstretch)).EndInit();
			this.pnP.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion

		internal static Form1 form1;

		/// <summary>
		/// Der Haupteinstiegspunkt f�r die Anwendung.
		/// </summary>
		[STAThread]
		static void Main()
		{
			try
			{
				bool adv = SimPe.Helper.WindowsRegistry.HiddenMode;
				bool asy = SimPe.Helper.WindowsRegistry.AsynchronLoad;

				SimPe.Helper.WindowsRegistry.HiddenMode = false;
				SimPe.Helper.WindowsRegistry.AsynchronLoad = false;
				SimPe.Plugin.ScenegraphWrapperFactory.InitRcolBlocks();
				form1 = new Form1();
				Application.EnableVisualStyles();
				Application.Run(form1);

				SimPe.Helper.WindowsRegistry.HiddenMode = adv;
				SimPe.Helper.WindowsRegistry.AsynchronLoad = asy;

				SimPe.Helper.WindowsRegistry.Flush();
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"WOS will Shutdown due to an unhandled Exception. \n\nMessage:"
						+ ex.Message
				);
			}
		}

		private void ExitClick(
			object sender,
			System.Windows.Forms.LinkLabelLinkClickedEventArgs e
		)
		{
			Close();
		}

		#region Step Management

		Stack prevsteps = new Stack();

		/// <summary>
		/// Called upon changes in a Step Form
		/// </summary>
		/// <param name="sender">the current Wizard Step</param>
		/// <param name="autonext">true if the page wanted to go to the next Wizard Step NOW</param>
		void ContentChanged(IWizardForm sender, bool autonext)
		{
			llnext.Enabled = sender.CanContinue;
			if (autonext)
				this.Next();
		}

		/// <summary>
		/// Show the Prev Step
		/// </summary>
		internal void Prev()
		{
			IWizardForm now = prevsteps.Pop();
			if (now == null)
				return;
			now.WizardWindow.Visible = false;

			now = prevsteps.Tail();
			if (now == null)
				return;

			ShowStep(now, false);
		}

		/// <summary>
		/// Show the Next Step
		/// </summary>
		internal void Next()
		{
			IWizardForm now = prevsteps.Tail();
			if (now == null)
				return;

			if (
				now.GetType().GetInterface("IWizardFinish", false)
				== typeof(IWizardFinish)
			)
			{
				IWizardFinish wf = (IWizardFinish)now;
				wf.Finit();

				prevsteps = new Stack();
				prevsteps.Push(step1);
				ShowStep(step1, true);
			}
			else
			{
				now.WizardWindow.Visible = false;

				now = now.Next;
				if (now == null)
					return;

				prevsteps.Push(now);
				ShowStep(now, true);
			}
		}

		private void Form1_Load(object sender, System.EventArgs e) { }

		Option op = new Option();

		private void ShowOptions(
			object sender,
			System.Windows.Forms.LinkLabelLinkClickedEventArgs e
		)
		{
			this.llopt.LinkVisited = true;
			op.form1 = this;
			op.Location = pndrop.Location;
			op.Size = pndrop.Size;
			this.Controls.Add(op.pnopt);
			op.pnopt.Parent = this;
			op.tbsims.Text = PathProvider.Global[Expansions.BaseGame].InstallFolder;
			op.tbsave.Text = PathProvider.SimSavegameFolder;
			op.tbdds.Text = PathProvider.Global.NvidiaDDSPath;
			op.pnopt.Visible = true;
			pndrop.Visible = false;
		}

		internal void HideOptions(
			object sender,
			System.Windows.Forms.LinkLabelLinkClickedEventArgs e
		)
		{
			pndrop.Visible = true;
			op.pnopt.Visible = false;
		}

		private void Close(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if ((prevsteps.Count > 1))
			{
				e.Cancel = (
					MessageBox.Show(
						"This Wizard is not finished yet.\n\nDo you want to quit anyway?",
						"Information",
						MessageBoxButtons.YesNo
					) != DialogResult.Yes
				);
			}

			if (!e.Cancel)
				Helper.WindowsRegistry.Flush();
		}

		/// <summary>
		/// Display a new Step
		/// </summary>
		/// <param name="step">The Step you want to Show</param>
		void ShowStep(IWizardForm step, bool init)
		{
			Panel pn = step.WizardWindow;
			//this.Height = pn.Height + 320;

			pn.Visible = false;
			pn.Parent = this.pndrop;
			pn.Dock = DockStyle.None;
			pn.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					AnchorStyles.Left
					| AnchorStyles.Top
					| AnchorStyles.Right
					| AnchorStyles.Bottom
				)
			);
			pn.BackColor = Color.White;
			pn.Left = 16;
			pn.Top = 0;
			pn.Width = pndrop.Width - 2 * pn.Left;
			pn.Height = pndrop.Height - (pn.Top + llnext.Height);

			lbmsg.Text = step.WizardMessage;
			lbstep.Text = step.WizardStep.ToString();
			//lbmsg.Left = lbstep.Left - lbmsg.Width;
			lbmsg.Width = lbstep.Left - lbmsg.Left + 2;

			llback.Enabled = (prevsteps.Count > 1);
			if (
				step.GetType().GetInterface("IWizardFinish", false)
				== typeof(IWizardFinish)
			)
			{
				llnext.Text = "Finish";
				llnext.Enabled = true;
			}
			else
			{
				llnext.Text = "Next >";
				llnext.Enabled = (step.Next != null);
			}

			llnext.Enabled = llnext.Enabled & step.CanContinue;
			llopt.Visible = (prevsteps.Count <= 1);

			bool show = true;
			if (init)
				show = step.Init(new ChangedContent(this.ContentChanged));
			pn.Visible = show;

			lbmsg.SendToBack();
			lbstep.SendToBack();
			pbtop.SendToBack();
			pbstretch.SendToBack();
		}
		#endregion

		private void Back(
			object sender,
			System.Windows.Forms.LinkLabelLinkClickedEventArgs e
		)
		{
			Prev();
		}

		private void Next(
			object sender,
			System.Windows.Forms.LinkLabelLinkClickedEventArgs e
		)
		{
			Next();
		}
	}
}
