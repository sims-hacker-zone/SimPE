// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Drawing;
using System.Windows.Forms;

using Ambertation.Windows.Forms;

namespace SimPe.Windows.Forms
{
	public partial class SplashForm : TransparentForm
	{
		static Image bg;
		const uint WM_CHANGE_MESSAGE =
			APIHelp.WM_APP + 0x0001;
		const uint WM_SHOW_HIDE = APIHelp.WM_APP + 0x0002;
		IntPtr myhandle;

		public SplashForm()
		{
			msg = "";
			InitializeComponent();
			MinimumSize = new Size(461, 212);
			MaximumSize = new Size(461, 212);
			myhandle = Handle;
			StartPosition = FormStartPosition.CenterScreen;
			FormBorderStyle = FormBorderStyle.None;
			lbtxt.Text = msg;
			lbver.Text = Helper.VersionToString(Helper.SimPeVersion);
			if (Helper.WindowsRegistry.HiddenMode && Helper.QARelease)
			{
				lbver.Text += " [Debug, QA]";
			}
			else if (Helper.WindowsRegistry.HiddenMode)
			{
				lbver.Text += " [Debug]";
			}
			else if (Helper.QARelease)
			{
				lbver.Text += " [QA]";
			}
		}

		protected override void OnCreateBitmap(Graphics g, Bitmap b)
		{
			if (bg == null)
			{
				bg = Image.FromStream(
					typeof(HelpForm).Assembly.GetManifestResourceStream(
						"SimPe.img.splash.png"
					)
				);
			}
			g.DrawImage(bg, new Point(0, 0));
			g.Dispose();
		}

		string msg;
		public string Message
		{
			get => msg;
			set
			{
				lock (msg)
				{
					if (msg != value)
					{
						msg = value ?? "";

						SendMessageChangeSignal();
					}
				}
			}
		}

		protected void SendMessageChangeSignal()
		{
			APIHelp.SendMessage(
				myhandle,
				WM_CHANGE_MESSAGE,
				0,
				0
			);
		}

		protected override void WndProc(ref System.Windows.Forms.Message m)
		{
			if (m.HWnd == Handle)
			{
				if (m.Msg == WM_CHANGE_MESSAGE)
				{
					lbtxt.Text = Message;
				}
				else if (m.Msg == WM_SHOW_HIDE)
				{
					int i = m.WParam.ToInt32();
					if (i == 1)
					{
						if (!Visible)
						{
							ShowDialog();
						}
						else
						{
							Application.DoEvents();
						}
					}
					else
					{
						Close();
					}
				}
			}
			base.WndProc(ref m);
		}

		public void StartSplash()
		{
			APIHelp.SendMessage(myhandle, WM_SHOW_HIDE, 1, 0);
		}

		public void StopSplash()
		{
			APIHelp.SendMessage(myhandle, WM_SHOW_HIDE, 0, 0);
		}
	}
}
