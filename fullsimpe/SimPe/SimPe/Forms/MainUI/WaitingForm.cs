// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Windows.Forms;

namespace SimPe.Forms.MainUI
{
	/// <summary>
	/// Summary description for WaitingForm.
	/// </summary>
	internal class WaitingForm : Form
	{
		#region Form variables
		private Panel panel1;
		internal PictureBox pb;
		private Label lbwait;
		private Label lbmsg;
		internal PictureBox pbsimpe;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public WaitingForm()
		{
			System.Diagnostics.Trace.WriteLine("SimPe.WaitingForm..ctor()");
			//
			// Required designer variable.
			//
			InitializeComponent();
			//this.TopMost = Helper.WindowsRegistry.Config.WaitingScreenTopMost;
			myhandle = Handle;
			image = pbsimpe.Image;
			Message = lbmsg.Text;

			//defimg = true;
			//cycles = 20;
			//alpha = 0xff;
			//timer1.Enabled = true;
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

		IntPtr myhandle;
		internal System.Drawing.Image image = null;
		const uint WM_CHANGE_MESSAGE =
			Ambertation.Windows.Forms.APIHelp.WM_APP + 0x0003;
		const uint WM_CHANGE_IMAGE = Ambertation.Windows.Forms.APIHelp.WM_APP + 0x0004;
		const uint WM_SHOW_HIDE = Ambertation.Windows.Forms.APIHelp.WM_APP + 0x0005;

		object lockObj = new object();

		public void SetImage(System.Drawing.Image image)
		{
			System.Diagnostics.Trace.WriteLine("SimPe.WaitingForm.SetImage()");
			lock (lockObj)
			{
				if (this.image == image)
				{
					return;
				}

				this.image = image;
				Ambertation.Windows.Forms.APIHelp.SendMessage(
					myhandle,
					WM_CHANGE_IMAGE,
					0,
					0
				);
			}
		}

		public System.Drawing.Image Image => image;

		public void SetMessage(string message)
		{
			System.Diagnostics.Trace.WriteLine(
				"SimPe.WaitingForm.SetMessage(): " + message
			);
			lock (lockObj)
			{
				if (Message == message)
				{
					return;
				}

				Message = message;
				Ambertation.Windows.Forms.APIHelp.SendMessage(
					myhandle,
					WM_CHANGE_MESSAGE,
					0,
					0
				);
			}
		}

		public string Message { get; private set; } = "";

		protected override void WndProc(ref System.Windows.Forms.Message m)
		{
			if (m.HWnd == Handle)
			{
				if (m.Msg == WM_CHANGE_MESSAGE)
				{
					System.Diagnostics.Trace.WriteLine(
						"SimPe.WaitingForm.WndProc() - WM_CHANGE_MESSAGE: " + Message
					);
					lbmsg.Text = Message;
				}
				else if (m.Msg == WM_CHANGE_IMAGE)
				{
					System.Diagnostics.Trace.WriteLine(
						"SimPe.WaitingForm.WndProc() - WM_CHANGE_IMAGE"
					);
					pb.Image = image;
					pb.Visible = image != null;
					pbsimpe.Visible = image == null;
				}
				else if (m.Msg == WM_SHOW_HIDE)
				{
					int i = m.WParam.ToInt32();
					System.Diagnostics.Trace.WriteLine(
						"SimPe.WaitingForm.WndProc() - WM_SHOW_HIDE: " + i
					);
					if (i == 1)
					{
						Show();
						Focus();
					}
					else
					{
						Hide();
					}
				}
			}
			base.WndProc(ref m);
		}

		public void StartSplash()
		{
			System.Diagnostics.Trace.WriteLine("SimPe.WaitingForm.StartSplash()");
			Ambertation.Windows.Forms.APIHelp.SendMessage(myhandle, WM_SHOW_HIDE, 1, 0);
		}

		public void StopSplash()
		{
			System.Diagnostics.Trace.WriteLine("SimPe.WaitingForm.StopSplash()");
			Ambertation.Windows.Forms.APIHelp.SendMessage(myhandle, WM_SHOW_HIDE, 0, 0);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(typeof(WaitingForm));
			panel1 = new Panel();
			lbmsg = new Label();
			lbwait = new Label();
			pb = new PictureBox();
			pbsimpe = new PictureBox();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pb).BeginInit();
			((System.ComponentModel.ISupportInitialize)pbsimpe).BeginInit();
			SuspendLayout();
			//
			// panel1
			//
			panel1.AccessibleRole = AccessibleRole.None;
			panel1.BackColor = System.Drawing.Color.Transparent;
			panel1.Controls.Add(lbmsg);
			panel1.Controls.Add(lbwait);
			panel1.Controls.Add(pb);
			panel1.Controls.Add(pbsimpe);
			resources.ApplyResources(panel1, "panel1");
			panel1.Name = "panel1";
			//
			// lbmsg
			//
			lbmsg.AccessibleRole = AccessibleRole.Text;
			lbmsg.ForeColor = System.Drawing.Color.FromArgb(
				204,
				211,
				213
			);
			resources.ApplyResources(lbmsg, "lbmsg");
			lbmsg.Name = "lbmsg";
			//
			// lbwait
			//
			lbwait.AccessibleRole = AccessibleRole.StaticText;
			resources.ApplyResources(lbwait, "lbwait");
			lbwait.ForeColor = System.Drawing.Color.Gray;
			lbwait.Name = "lbwait";
			//
			// pb
			//
			pb.AccessibleRole = AccessibleRole.Graphic;
			resources.ApplyResources(pb, "pb");
			pb.Name = "pb";
			pb.TabStop = false;
			//
			// pbsimpe
			//
			pbsimpe.AccessibleRole = AccessibleRole.Graphic;
			resources.ApplyResources(pbsimpe, "pbsimpe");
			pbsimpe.Name = "pbsimpe";
			pbsimpe.TabStop = false;
			//
			// WaitingForm
			//
			AccessibleRole = AccessibleRole.None;
			resources.ApplyResources(this, "$this");
			BackColor = System.Drawing.Color.FromArgb(
				102,
				102,
				153
			);
			CausesValidation = false;
			Controls.Add(panel1);
			FormBorderStyle = FormBorderStyle.None;
			Name = "WaitingForm";
			ShowInTaskbar = false;
			TransparencyKey = System.Drawing.Color.Fuchsia;
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pb).EndInit();
			((System.ComponentModel.ISupportInitialize)pbsimpe).EndInit();
			ResumeLayout(false);
		}
		#endregion
	}
}
