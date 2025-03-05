// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SimPe
{
	/// <summary>
	/// This calass can be used to interface the StatusBar of the Main GUI, which will display
	/// something like the WaitingScreen
	/// </summary>
	public class Wait
	{
		static IWaitingBarControl bar;
		static Stack2<SessionData> mystack = new Stack2<SessionData>();
		public const int TIMEOUT = 10000;

		public static IWaitingBarControl Bar
		{
			set => bar = value;
		}

		public static bool Running => bar != null && bar.Running;

		public static string Message
		{
			get => bar != null ? bar.Message : "";
			set
			{
				if (bar != null)
				{
					bar.Message = value;
				}
				Console.WriteLine($"Wait: {value}");

				Application.DoEvents();
			}
		}

		public static Image Image
		{
			get => bar?.Image;
			set
			{
				//lock (sync)
				{
					//if (bar!=null) bar.Image = value;
				}
			}
		}

		public static int Progress
		{
			get => bar != null ? bar.Progress : 0;/*if (bar!=null) return bar.Progress;
				return IntMaxProgress;*/
			set
			{
				if (bar != null)
				{
					bar.Progress = value;
				}

				Application.DoEvents();
			}
		}

		public static int MaxProgress
		{
			get => bar != null ? bar.MaxProgress : 1;
			set
			{
				if (bar != null)
				{
					bar.MaxProgress = value;
				}
			}
		}

		public static void SubStart()
		{
			if (bar != null)
			{
				CommonStart();
				if (!bar.Running)
				{
					bar.Wait();
				}
			}
		}

		public static void SubStart(int max)
		{
			Start(max);
		}

		public static void SubStop()
		{
			Stop();
		}

		public static void Start()
		{
			if (bar != null)
			{
				CommonStart();
				bar.ShowProgress = false;
				if (!bar.Running)
				{
					bar.Wait();
				}
			}
		}

		public static void Start(int max)
		{
			if (bar != null)
			{
				CommonStart();
				if (!bar.Running)
				{
					bar.Wait(max);
				}
				else
				{
					bar.MaxProgress = max;
				}
			}
		}

		public static void Stop()
		{
			Stop(false);
		}

		public static void Stop(bool force)
		{
			SessionData sd;
			lock (mystack)
			{
				if (mystack.Count == 0)
				{
					bar?.Stop();

					return;
				}

				sd = mystack.Pop();

				if (mystack.Count == 0)
				{
					bar?.Stop();
				}
			}

			if (force)
			{
				bar?.Stop();
			}

			ReloadSession(sd);

			if (bar != null)
			{
				if (!bar.Running)
				{
					bar.ShowProgress = false;
				}
			}
		}

		static void CommonStart()
		{
			//bar.Message = SimPe.Localization.GetString("Please wait");
			lock (mystack)
			{
				mystack.Push(BuildSessionData());
			}
			Message = "";
			MaxProgress = Progress = 0;
		}

		class SessionData
		{
			public string Message;
			public int Progress;
			public int MaxProgress;
		}

		private static SessionData BuildSessionData()
		{
			SessionData sd = new SessionData
			{
				Message = Message,
				Progress = Progress,
				MaxProgress = (bar == null || !bar.ShowProgress) ? 0 : MaxProgress
			};
			return sd;
		}

		private static void ReloadSession(SessionData sd)
		{
			try
			{
				if (sd != null)
				{
					Message = sd.Message;
					MaxProgress = sd.MaxProgress;
					Progress = sd.Progress;
				}
			}
			catch { }
		}
	}
}
