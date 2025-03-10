// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Windows.Forms;

using SimPe.Forms.MainUI;

namespace SimPe
{
	public class WaitingScreen
	{
		/// <summary>
		/// Display a new WaitingScreen image
		/// </summary>
		/// <param name="image">the Image to show</param>
		public static void UpdateImage(System.Drawing.Image image)
		{
			Screen.doUpdate(image);
		}

		/// <summary>
		/// The WaitingScreen image
		/// </summary>
		public static System.Drawing.Image Image
		{
			get => scr?.prevImage;
			set => Screen.doUpdate(value);
		}

		/// <summary>
		/// Display a new WaitingScreen message
		/// </summary>
		/// <param name="msg">The Message to show</param>
		public static void UpdateMessage(string msg)
		{
			Screen.doUpdate(msg);
		}

		/// <summary>
		/// The WaitingScreen message
		/// </summary>
		public static string Message
		{
			get => scr == null ? "" : scr.prevMessage;
			set => Screen.doUpdate(value);
		}

		/// <summary>
		/// Display a new WaitingScreen image and message
		/// </summary>
		/// <param name="both">the MessageAndImage to show</param>
		public static void Update(System.Drawing.Image image, string msg)
		{
			Screen.doUpdate(image, msg);
		}

		/// <summary>
		/// Show the WaitingScreen for a specific form
		/// </summary>
		public static void Wait(Form form)
		{
			Screen.doWait(form);
		}

		/// <summary>
		/// Show the WaitingScreen
		/// </summary>
		public static void Wait()
		{
			Screen.doWait();
		}

		/// <summary>
		/// Stop the WaitingScreen and focus the given Form
		/// </summary>
		/// <param name="form">The form to focus</param>
		public static void Stop(Form form)
		{
			Stop();
			form.Activate();
		}

		/// <summary>
		/// Stop the WaitingScreen
		/// </summary>
		public static void Stop()
		{
			if (Running)
			{
				Screen.doStop();
			}
			else
			{
				Application.UseWaitCursor = false;
			}
		}

		/// <summary>
		/// True if the WaitingScreen is displayed
		/// </summary>
		public static bool Running => count > 0;

		/// <summary>
		/// Returns the Size of the Dispalyed Image
		/// </summary>
		public static System.Drawing.Size ImageSize => new System.Drawing.Size(64, 64);

		static WaitingScreen scr;
		static object lockFrm = new object();
		static object lockScr = new object();
		static uint count = 0;
		static WaitingScreen Screen
		{
			get
			{
				System.Diagnostics.Trace.WriteLine(
					"SimPe.WaitingScreen.getScreen: " + count
				);
				lock (lockScr)
				{
					if (scr == null)
					{
						scr = new WaitingScreen();
					}
				}
				return scr;
			}
		}

		System.Drawing.Image prevImage = null;
		string prevMessage = "";
		WaitingForm frm;

		Form parent = null;

		void doUpdate(System.Drawing.Image image)
		{
			System.Diagnostics.Trace.WriteLine(
				"SimPe.WaitingScreen.doUpdate(image): " + count
			);
			lock (lockFrm)
			{
				prevImage = image;
				frm?.SetImage(image);
			}
			Application.DoEvents();
		}

		void doUpdate(string msg)
		{
			System.Diagnostics.Trace.WriteLine(
				"SimPe.WaitingScreen.doUpdate(message): " + msg + ", " + count
			);
			Console.WriteLine($"WaitingScreen: {msg}");
			lock (lockFrm)
			{
				prevMessage = msg;
				frm?.SetMessage(msg);
			}
			Application.DoEvents();
		}

		void doUpdate(System.Drawing.Image image, string msg)
		{
			doUpdate(image);
			doUpdate(msg);
		}

		void doWait()
		{
			doWait(Form.ActiveForm);
		}

		void doWait(Form form)
		{
			System.Diagnostics.Trace.WriteLine("SimPe.WaitingScreen.doWait(...): ");
			++count;
			if (count > 1)
			{
				return;
			}

			Application.UseWaitCursor = true;
			if (!Helper.WindowsRegistry.Config.WaitingScreen)
			{
				return;
			}

			lock (lockFrm)
			{
				if (parent != form)
				{
					if (parent != null)
					{
						parent.Activated -= new EventHandler(parent_Activated);
					}

					parent = form;
					if (parent != null)
					{
						parent.Activated += new EventHandler(parent_Activated);
					}
				}
				parent_Activated(null, null);
				if (frm != null)
				{
					frm.Owner = form;
				}
			}
		}

		void doStop()
		{
			System.Diagnostics.Trace.WriteLine("SimPe.WaitingScreen.doStop(): ");
			count--;
			if (parent != null && count == 0)
			{
				parent.Activate();
			}

			Application.UseWaitCursor = false;
			lock (lockFrm)
			{
				frm?.StopSplash();
			}
		}

		void parent_Activated(object sender, EventArgs e)
		{
			if (frm != null && count > 0)
			{
				frm.StartSplash();
			}
		}

		private WaitingScreen()
		{
			System.Diagnostics.Trace.WriteLine("SimPe.WaitingScreen..ctor(): " + count);
			if (Helper.WindowsRegistry.Config.WaitingScreen)
			{
				lock (lockFrm)
				{
					frm = new WaitingForm();
					System.Diagnostics.Trace.WriteLine(
						"SimPe.WaitingScreen..ctor() - created new SimPe.WaitingForm()"
					);
					frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
					prevImage = frm.Image;
					prevMessage = frm.Message;
					doUpdate(prevImage, prevMessage);
					System.Diagnostics.Trace.WriteLine(
						"SimPe.WaitingScreen..ctor() - set frm.Image and frm.Message"
					);
					//frm.StartSplash();
					//System.Diagnostics.Trace.WriteLine("SimPe.WaitingScreen..ctor() - returned from frm.StartSplash()");
				}
			}
		}

		void frm_FormClosed(object sender, FormClosedEventArgs e)
		{
			System.Diagnostics.Trace.WriteLine(
				"SimPe.WaitingScreen.frm_FormClosed(...)"
			);
			Application.UseWaitCursor = false;
			lock (lockFrm)
			{
				frm = null;
				lock (lockScr)
				{
					scr = null;
				}
			}
			count = 0;
		}
	}
}
