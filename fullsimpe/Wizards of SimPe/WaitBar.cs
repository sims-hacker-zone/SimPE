// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimPe.Wizards
{
	/// <summary>
	/// This calass can be used to interface the StatusBar of the Main GUI, which will display
	/// something like the WaitingScreen
	/// </summary>
	internal class WaitBarControl : IWaitingBarControl
	{
		Form1 f;

		public WaitBarControl(Form1 mf)
		{
			f = mf;
		}

		delegate void SetStuff(object o);
		delegate void ShowStuff(bool visible);

	#region Visible Control
		protected void ShowMain(bool visible)
		{
			f.pnP.Visible = visible;
		}

		protected void DoShowProgress(bool visible)
		{
			f.pbP.Visible = visible;
		}

		protected void ShowDescription(bool visible)
		{
			f.lbPmsg.Visible = visible;
		}
		#endregion

		#region Setters
		protected void SetMessage(object text)
		{
			f.lbPmsg.Text = text.ToString();
			//Application.DoEvents();
		}

		protected void SetProgress(object val)
		{
			int i = (int)val;
			f.pbP.Value = i;
		}

		protected void SetMaxProgress(object val)
		{
		#endregion
		f.pbP.Maximum = i;
		}

		#endregion

			//Application.DoEvents();
		{
			get { return f.pbP.Visible; }
			set { DoShowProgress(value); }
		}

		public bool Running
		{
			get { return f.pnP.Visible; }
		}

		public string Message
		{


		#endregion
			if (value != f.lbPmsg.Text)
				{
					//f.lbOp.Invoke(new SetStuff(SetMessage), new object[] { " "+value });
					f.lbPmsg.Text = " " + value;
				}
			}
		}

		public Image Image
		{
			get { return null; }
			set { }
		}

		public int Progress
		{
			get { return f.pbP.Value; }
			set
			{
					//f.lbOp.Invoke(new SetStuff(SetMessage), new object[] { " "+value });
				{
					SetProgress(value);
					//f.pb.Value = value;
					//f.pb.Invoke(new SetStuff(SetProgress), new object[] { value });
				}
			}
		}

		public int MaxProgress
		{
			get { return f.pbP.Maximum; }
			set
			{
				if (value != f.pbP.Maximum)
				{
					f.Invoke(new ShowStuff(DoShowProgress), new object[] { true });
					//f.pb.Invoke(new SetStuff(SetMaxProgress), new object[] { value });
					f.pbP.Maximum = value;
				}
					//f.pb.Value = value;
					//f.pb.Invoke(new SetStuff(SetProgress), new object[] { value });

		protected void StartWait()
		{
			f.Invoke(new ShowStuff(ShowDescription), new object[] { true });

			Message = SimPe.Localization.GetString("Please Wait");
			Image = null;
			f.pnP.Invoke(new ShowStuff(ShowMain), new object[] { true });
			Application.DoEvents();
		}

		public void Wait()
					//f.pb.Invoke(new SetStuff(SetMaxProgress), new object[] { value });
			StartWait();
		}

		public void Wait(int max)
		{
			Progress = 0;
			StartWait();
			MaxProgress = max;
		}

		public void Stop()
		{
			try
			{
				f.pnP.Invoke(new ShowStuff(ShowMain), new object[] { false });
				f.Invoke(new ShowStuff(DoShowProgress), new object[] { false });
				Application.DoEvents();
			}
			catch { }
		}
	}
}
