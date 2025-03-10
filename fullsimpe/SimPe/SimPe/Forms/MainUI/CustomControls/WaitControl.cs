// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimPe
{
	public partial class WaitControl : UserControl, IWaitingBarControl
	{
		const uint WM_USER_CHANGED_MESSAGE =
			Ambertation.Windows.Forms.APIHelp.WM_APP | 0x0001;
		const uint WM_USER_CHANGED_MAXPROGRESS =
			Ambertation.Windows.Forms.APIHelp.WM_APP | 0x0002;
		const uint WM_USER_CHANGED_PROGRESS =
			Ambertation.Windows.Forms.APIHelp.WM_APP | 0x0003;
		const uint WM_USER_SHOW_HIDE =
			Ambertation.Windows.Forms.APIHelp.WM_APP | 0x0004;
		const uint WM_USER_SHOW_HIDE_PROGRESS =
			Ambertation.Windows.Forms.APIHelp.WM_APP | 0x0005;
		const uint WM_USER_SHOW_HIDE_ANIMATION =
			Ambertation.Windows.Forms.APIHelp.WM_APP | 0x0006;
		const uint WM_USER_SHOW_HIDE_TEXT =
			Ambertation.Windows.Forms.APIHelp.WM_APP | 0x0007;
		IntPtr myhandle;

		public WaitControl()
		{
			msg = "";
			InitializeComponent();
			myhandle = Handle;

			Message = "";
			MaxProgress = 0;
			Waiting = false;
			ShowProgress = false;
			ShowAnimation = true;
			ShowText = true;
			nowp = -1;
		}

		protected override void WndProc(ref System.Windows.Forms.Message m)
		{
			if (m.HWnd == Handle)
			{
				if (m.Msg == WM_USER_SHOW_HIDE)
				{
					if (m.WParam.ToInt32() == 1)
					{
						SetWaiting(true);
					}
					else
					{
						SetWaiting(false);
					}
				}
				else if (m.Msg == WM_USER_CHANGED_MESSAGE)
				{
					tbInfo.Text = Message;
					//this.statusStrip1.Invalidate();
				}
				else if (m.Msg == WM_USER_CHANGED_MAXPROGRESS)
				{
					pb.Value = pb.Minimum;
					pb.Maximum = Math.Max(
						Math.Max(1, pb.Minimum),
						m.WParam.ToInt32()
					);
					DoShowProgress(pb.Maximum > 1);
				}
				else if (m.Msg == WM_USER_CHANGED_PROGRESS)
				{
					SetProgress(m.WParam.ToInt32());
				}
				else if (m.Msg == WM_USER_SHOW_HIDE_PROGRESS)
				{
					if (m.WParam.ToInt32() == 1)
					{
						DoShowProgress(true);
					}
					else
					{
						DoShowProgress(false);
					}
				}
				else if (m.Msg == WM_USER_SHOW_HIDE_ANIMATION)
				{
					if (m.WParam.ToInt32() == 1)
					{
						DoShowAnimation(true);
					}
					else
					{
						DoShowAnimation(false);
					}
				}
				else if (m.Msg == WM_USER_SHOW_HIDE_TEXT)
				{
					if (m.WParam.ToInt32() == 1)
					{
						DoShowText(true);
					}
					else
					{
						DoShowText(false);
					}
				}
			}
			base.WndProc(ref m);
		}

		string msg;
		public string Message
		{
			get
			{
				lock (msg)
				{
					return msg;
				}
			}
			set
			{
				lock (msg)
				{
					msg = value;
				}
				Ambertation.Windows.Forms.APIHelp.SendMessage(
					myhandle,
					WM_USER_CHANGED_MESSAGE,
					0,
					0
				);
			}
		}

		int max;
		public int MaxProgress
		{
			get
			{
				lock (pb)
				{
					return max;
				}
			}
			set
			{
				lock (pb)
				{
					max = value;
				}
				Ambertation.Windows.Forms.APIHelp.SendMessage(
					myhandle,
					WM_USER_CHANGED_MAXPROGRESS,
					value,
					0
				);
			}
		}

		int val;
		int nowp;
		public int Progress
		{
			get => val;
			set => Ambertation.Windows.Forms.APIHelp.SendMessage(
					myhandle,
					WM_USER_CHANGED_PROGRESS,
					value,
					0
				);
		}

		private void SetProgress(int value)
		{
			val = Math.Min(pb.Maximum, value);
			pb.Value = val;

			//float perc = (((float)val / (float)pb.Maximum) * 100);

			int perc = val * 100 / pb.Maximum;
			int diff = Math.Abs(nowp - perc);
			if (diff > 0)
			{
				tbPercent.Text = perc.ToString("N0") + "%";
			}

			if (diff >= 10)
			{
				statusStrip1.Refresh();
				nowp = perc;
			}
		}

		bool wait;
		public bool Waiting
		{
			get => wait;
			set
			{
				int val = 0;
				if (value)
				{
					val = 1;
				}

				Ambertation.Windows.Forms.APIHelp.SendMessage(
					myhandle,
					WM_USER_SHOW_HIDE,
					val,
					0
				);
			}
		}

		private void SetWaiting(bool value)
		{
			wait = value;
			if (wait)
			{
				Visible = true;
			}
			else
			{
				if (!DesignMode && !Helper.WindowsRegistry.Config.ShowWaitBarPermanent)
				{
					Visible = false;
				}

				Message = "";
				Progress = 0;
				ShowProgress = false;
			}
		}

		bool spb;
		public bool ShowProgress
		{
			get => spb;
			set
			{
				int val = 0;
				if (value)
				{
					val = 1;
				}

				Ambertation.Windows.Forms.APIHelp.SendMessage(
					myhandle,
					WM_USER_SHOW_HIDE_PROGRESS,
					val,
					0
				);
			}
		}

		void DoShowProgress(bool value)
		{
			spb = value;
			pb.Visible = spb;
			tbPercent.Visible = spb;
			tbInfo.BorderSides = spb ? ToolStripStatusLabelBorderSides.Left : ToolStripStatusLabelBorderSides.None;
		}

		bool sanim;
		public bool ShowAnimation
		{
			get => sanim;
			set
			{
				sanim = value;
				Ambertation.Windows.Forms.APIHelp.SendMessage(
					myhandle,
					WM_USER_SHOW_HIDE_ANIMATION,
					0,
					0
				);
			}
		}

		private void DoShowAnimation(bool value)
		{
		}

		bool stxt;
		public bool ShowText
		{
			get => stxt;
			set
			{
				int val = 0;
				if (value)
				{
					val = 1;
				}

				Ambertation.Windows.Forms.APIHelp.SendMessage(
					myhandle,
					WM_USER_SHOW_HIDE_TEXT,
					val,
					0
				);
			}
		}

		private void DoShowText(bool value)
		{
			stxt = value;
			tbInfo.Visible = stxt;
		}

		#region IWaitingBarControl Member

		public bool Running => Waiting;

		public Image Image
		{
			get => null;
			set
			{
			}
		}

		public void Wait()
		{
			Message = Localization.GetString("Please Wait");
			Image = null;
			Waiting = true;
		}

		public void Wait(int max)
		{
			ShowProgress = true;
			Message = Localization.GetString("Please Wait");
			Image = null;
			MaxProgress = max;
			Waiting = true;
		}

		public void Stop()
		{
			ShowProgress = false;
			Waiting = false;
		}

		#endregion
	}
}
