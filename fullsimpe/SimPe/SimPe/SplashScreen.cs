// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

namespace SimPe
{
	public class Splash
	{
		/// <summary>
		/// Event1: StartThread has created frm and sent SetMessage
		/// </summary>
		static System.Threading.ManualResetEvent ev1 =
			new System.Threading.ManualResetEvent(false);

		static Splash scr;
		static object lockObj = new object();
		public static Splash Screen
		{
			get
			{
				lock (lockObj)
				{
					if (scr == null)
					{
						ev1.Reset();
						scr = new Splash();
						ev1.WaitOne();
					}
				}
				return scr;
			}
		}

		public static bool Running => scr != null;

		System.Threading.Thread t = null;

		private Splash()
		{
			mmsg = "";

			if (
				Helper.WindowsRegistry.ShowStartupSplash
				|| (
					Helper.WindowsRegistry.GetPreviousVersion()
					!= Helper.SimPeVersionLong
				)
			)
			{
				t = new System.Threading.Thread(
					new System.Threading.ThreadStart(StartThread)
				);
				t.Start();
				sw.Start();
			}
			else
			{
				ev1.Set();
			}
		}

		Windows.Forms.SplashForm frm = null;

		protected void StartThread()
		{
			frm = new Windows.Forms.SplashForm();
			frm.FormClosed += new System.Windows.Forms.FormClosedEventHandler(
				frm_FormClosed
			);
			SetMessage(mmsg);
			ev1.Set();
			frm.StartSplash();
		}

		void frm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
		{
			lock (lockObj)
			{
				t = null;
				frm = null;
				scr = null;
			}
		}

		string mmsg;
		System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

		public void SetMessage(string msg)
		{
			Console.WriteLine($"Splash: {msg} ({sw.ElapsedMilliseconds} ms)");
			sw.Restart();
			mmsg = msg;
			if (frm != null)
			{
				frm.Message = msg;
			}
		}

		public void Stop()
		{
			frm?.StopSplash();
			sw.Stop();
		}

		public void ShutDown()
		{
			Stop();
			t?.Join();
		}
	}
}
