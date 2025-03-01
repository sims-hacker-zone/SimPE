// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SimPe.Wizards
{
	/// <summary>
	/// Summary description for FormStep1.
	/// </summary>
	public class FormStep1 : System.Windows.Forms.Form, IWizardForm
	{
		private System.Windows.Forms.Panel pnwizard;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormStep1()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			WizardSelector ws = new WizardSelector();

			int top = 16;
			foreach (IWizardEntry we in ws.Wizards)
			{
				Panel pn = BuildWizardPanel(we);
				pn.Visible = true;
				pn.Top = top;

				top += pn.Height + 8;
			}

			pnwizard.Height = top;
			if (Helper.WindowsRegistry.UseBigIcons)
				this.Font = new System.Drawing.Font("Tahoma", 12F);
		}

		Panel BuildWizardPanel(IWizardEntry we)
		{
			Panel pn = new Panel();

			pn.Parent = pnwizard;
			pn.Width = pnwizard.Width - 148;
			pn.Left = 24;
			pn.Height = 64;

			PictureBox pb = new PictureBox();
			pb.Parent = pn;
			pb.Width = 64;
			pb.Height = 64;
			pb.Left = 0;
			pb.Top = 0;
			pb.Image = we.WizardImage;
			pb.Visible = true;

			LinkLabel lb1 = new LinkLabel();
			lb1.Parent = pn;
			lb1.Left = pb.Width + 8;
			lb1.Top = 0;
			lb1.AutoSize = true;
			lb1.Text = we.WizardCaption;
			lb1.Font = new Font(
				"Georgia",
				(float)10,
				FontStyle.Bold | FontStyle.Italic
			);
			lb1.LinkColor = Color.FromArgb(0xE5, 0x53, 0x00);
			lb1.Tag = we;
			lb1.LinkClicked += new LinkLabelLinkClickedEventHandler(StartWizard);
			lb1.Visible = true;
			//lb1.Enabled = we.CanContinue;

			Label lb2 = new Label();
			lb2.Parent = pn;
			lb2.AutoSize = false;
			lb2.Left = pb.Width + 8;
			lb2.Top = lb1.Top + lb1.Height;
			lb2.Width = pn.Width - lb2.Left - 16;
			lb2.Height = pn.Height - lb2.Top;
			lb2.Font = new Font("Verdana", (float)8);
			lb2.ForeColor = Color.DarkGray;
			lb2.Text = we.WizardDescription;
			lb2.Visible = true;

			return pn;
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
			this.pnwizard = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			//
			// pnwizard
			//
			this.pnwizard.BackColor = System.Drawing.Color.White;
			this.pnwizard.Location = new System.Drawing.Point(0, 0);
			this.pnwizard.Name = "pnwizard";
			this.pnwizard.Size = new System.Drawing.Size(1022, 626);
			this.pnwizard.TabIndex = 8;
			//
			// FormStep1
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(1022, 626);
			this.Controls.Add(this.pnwizard);
			this.Font = new System.Drawing.Font("Verdana", 9.75F);
			this.Name = "FormStep1";
			this.Text = "FormStep1";
			this.ResumeLayout(false);
		}
		#endregion

		#region IWizardWindow Members
		public Panel WizardWindow
		{
			get { return this.pnwizard; }
		}

		public string WizardMessage
		{
			get { return "Please select the Task you want to perform."; }
		}

		public int WizardStep
		{
			get { return 1; }
		}

		public bool Init(ChangedContent fkt)
		{
			return true;
		}

		IWizardForm wizard;
		public IWizardForm Next
		{
			get { return wizard; }
		}

		public bool CanContinue
		{
			get { return false; }
		}
		#endregion

		private void StartWizard(object sender, LinkLabelLinkClickedEventArgs e)
		{
			LinkLabel ll = (LinkLabel)sender;
			wizard = (IWizardForm)ll.Tag;

			Form1.form1.Next();
		}
	}
}
