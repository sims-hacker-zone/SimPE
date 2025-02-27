/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
using System;

namespace SimPe
{
	/// <summary>
	/// This calss can be used to control SimPe from a Plugin.
	/// </summary>
	public class RemoteControl
	{
		public class ControlEventArgs : EventArgs
		{
			object[] data;

			public ControlEventArgs(uint target)
				: this(target, new object[0]) { }

			public ControlEventArgs(uint target, object data)
				: this(target, new object[] { data }) { }

			public ControlEventArgs(uint target, object[] data)
			{
				if (data == null)
				{
					data = new object[0];
				}

				this.data = data;

				TargetType = target;
			}

			public uint TargetType
			{
				get;
			}

			public object Item
			{
				get
				{
					if (data.Length == 0)
					{
						return null;
					}
					else
					{
						return data[0];
					}
				}
			}

			public object Items => data;
		}

		struct MessageQueueItemInfo
		{
			public uint target;
			public ControlEvent fkt;
		}

		public delegate void ControlEvent(object sender, ControlEventArgs e);
		static System.Collections.ArrayList events = new System.Collections.ArrayList();

		public static void HookToMessageQueue(uint type, ControlEvent fkt)
		{
			MessageQueueItemInfo mqi = new MessageQueueItemInfo
			{
				target = type,
				fkt = fkt
			};

			events.Add(mqi);
		}

		public static void UnhookFromMessageQueue(uint type, ControlEvent fkt)
		{
			for (int i = events.Count - 1; i >= 0; i--)
			{
				MessageQueueItemInfo mqi = (MessageQueueItemInfo)events[i];
				if (mqi.target == type)
				{
					if (mqi.fkt == fkt)
					{
						events.RemoveAt(i);
					}
				}
			}
		}

		public static void AddMessage(object sender, ControlEventArgs e)
		{
			foreach (MessageQueueItemInfo mqi in events)
			{
				if (
					mqi.target == e.TargetType
					|| mqi.target == 0xffffffff
					|| e.TargetType == 0xffffffff
				)
				{
					mqi.fkt(sender, e);
				}
			}
		}

		/// <summary>
		/// Delegate you have to implement for the remote Package opener
		/// </summary>
		public delegate bool OpenPackageDelegate(string filename);

		/// <summary>
		/// Delegate you have to implement for the remote Package opener
		/// </summary>
		public delegate bool OpenMemPackageDelegate(
			Interfaces.Files.IPackageFile pkg
		);

		/// <summary>
		/// Delegate you have to implement for the Remote PackedFile Opener
		/// </summary>
		public delegate bool OpenPackedFileDelegate(
			Interfaces.Scenegraph.IScenegraphFileIndexItem fii
		);

		/// <summary>
		/// Used to show/hide a Dock
		/// </summary>
		public delegate void ShowDockDelegate(
			Ambertation.Windows.Forms.DockPanel doc,
			bool hide
		);

		#region Application Form
		static System.Windows.Forms.Form appform;

		/// <summary>
		/// Returns the Main Application Form
		/// </summary>
		public static System.Windows.Forms.Form ApplicationForm
		{
			get => appform;
			set
			{
				appform = value;
				appstate = appform != null ? appform.WindowState : System.Windows.Forms.FormWindowState.Maximized;
			}
		}

		static bool VisibleForm(System.Windows.Forms.Form form)
		{
			if (!form.ShowInTaskbar)
			{
				return false;
			}

			if (
				form.FormBorderStyle
				== System.Windows.Forms.FormBorderStyle.FixedToolWindow
			)
			{
				return false;
			}

			if (
				form.FormBorderStyle
				== System.Windows.Forms.FormBorderStyle.SizableToolWindow
			)
			{
				return false;
			}

			if (form.MinimizeBox == false)
			{
				return false;
			}

			return true;
		}

		public static void ShowSubForm(System.Windows.Forms.Form form)
		{
			if (VisibleForm(form))
			{
				HideApplicationForm();
			}

			form.ShowDialog(ApplicationForm);
			if (VisibleForm(form))
			{
				ShowApplicationForm();
			}
		}

		public static void HideApplicationForm()
		{
			if (ApplicationForm == null)
			{
				return;
			}

			if (ApplicationForm.Visible)
			{
				ApplicationForm.Hide();
				ApplicationForm.ShowInTaskbar = true;
			}
		}

		public static void ShowApplicationForm()
		{
			if (ApplicationForm == null)
			{
				return;
			}

			if (!ApplicationForm.Visible)
			{
				ApplicationForm.Show();
				ApplicationForm.ShowInTaskbar = true;
			}
		}

		static System.Windows.Forms.FormWindowState appstate;

		public static void MinimizeApplicationForm()
		{
			if (ApplicationForm == null)
			{
				return;
			}

			if (
				ApplicationForm.WindowState
				!= System.Windows.Forms.FormWindowState.Minimized
			)
			{
				appstate = ApplicationForm.WindowState;
				ApplicationForm.WindowState = System
					.Windows
					.Forms
					.FormWindowState
					.Minimized;
			}
		}

		public static void RestoreApplicationForm()
		{
			if (ApplicationForm == null)
			{
				return;
			}

			if (
				ApplicationForm.WindowState
				== System.Windows.Forms.FormWindowState.Minimized
			)
			{
				ApplicationForm.WindowState = appstate;
			}
		}
		#endregion


		/// <summary>
		/// Returns/Sets the ShowDock Delegate
		/// </summary>
		public static ShowDockDelegate ShowDockFkt
		{
			get; set;
		}

		/// <summary>
		/// Returns/Sets the Function that should be called if you want to open a PackedFile
		/// </summary>
		public static OpenPackedFileDelegate OpenPackedFileFkt
		{
			get; set;
		}

		/// <summary>
		/// Returns/Sets the Function that should be called if you want to open a PackedFile
		/// </summary>
		public static OpenPackageDelegate OpenPackageFkt
		{
			get; set;
		}

		/// <summary>
		/// Show/Hide a given Dock
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="hide"></param>
		public static void ShowDock(Ambertation.Windows.Forms.DockPanel doc, bool hide)
		{
			if (ShowDockFkt == null)
			{
				return;
			}

			ShowDockFkt(doc, hide);
		}

		/// <summary>
		/// Open a Package in the main SimPe Gui
		/// </summary>
		/// <param name="filename">The Filename of the package</param>
		/// <returns>true, if the package was opened</returns>
		public static bool OpenPackage(string filename)
		{
			if (OpenPackageFkt == null)
			{
				return false;
			}

			try
			{
				return OpenPackageFkt(filename);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					"Unable to open a Package in the SimPe GUI. (file="
						+ filename
						+ ")",
					ex
				);
			}
			return false;
		}

		/// <summary>
		/// Returns/Sets the Function that should be called if you want to open a PackedFile
		/// </summary>
		public static OpenMemPackageDelegate OpenMemoryPackageFkt
		{
			get; set;
		}

		/// <summary>
		/// Open a Package in the main SimPe Gui
		/// </summary>
		/// <param name="filename">The Filename of the package</param>
		/// <returns>true, if the package was opened</returns>
		public static bool OpenMemoryPackage(Interfaces.Files.IPackageFile pkg)
		{
			if (OpenMemoryPackageFkt == null)
			{
				return false;
			}

			try
			{
				return OpenMemoryPackageFkt(pkg);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					"Unable to open a Package in the SimPe GUI. (package="
						+ pkg.ToString()
						+ ")",
					ex
				);
			}
			return false;
		}

		/// <summary>
		/// Open a Package in the main SimPe Gui
		/// </summary>
		/// <param name="pfd">The FileDescriptor</param>
		/// <param name="pkg">The package the descriptor is in</param>
		/// <returns>true, if the package was opened</returns>
		public static bool OpenPackedFile(
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile pkg
		)
		{
			return OpenPackedFile(FileTableBase.FileIndex.CreateFileIndexItem(pfd, pkg));
		}

		/// <summary>
		/// Open a Package in the main SimPe Gui
		/// </summary>
		/// <param name="pfd">The FileDescriptor</param>
		/// <returns>true, if the package was opened</returns>
		public static bool OpenPackedFile(
			Interfaces.Scenegraph.IScenegraphFileIndexItem fii
		)
		{
			if (OpenPackedFileFkt == null)
			{
				return false;
			}

			try
			{
				return OpenPackedFileFkt(fii);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					"Unable to open a resource in the SimPe GUI. ("
						+ fii.ToString()
						+ ")",
					ex
				);
			}
			return false;
		}

		/// <summary>
		/// Displays a certain Help Topic
		/// </summary>
		/// <param name="url">Url (can be a local File) of the Help Document</param>
		public static void ShowHelp(string url)
		{
			try
			{
				System.Windows.Forms.Help.ShowHelp(ApplicationForm, url);
			}
			catch { }
		}

		/// <summary>
		/// Displays a certain Help Topic
		/// </summary>
		/// <param name="url">Url (can be a local File) of the Help Document</param>
		/// <param name="topic">the Topic in that document</param>
		/// <remarks>Produces an URL like "url#topic"</remarks>
		public static void ShowHelp(string url, string topic)
		{
			try
			{
				System.Windows.Forms.Help.ShowHelp(ApplicationForm, url, topic);
			}
			catch { }
		}

		/// <summary>
		/// Displays a Form, with the passed Custom Settings
		/// </summary>
		/// <param name="settings"></param>
		public static void ShowCustomSettings(Interfaces.ISettings settings)
		{
			System.Windows.Forms.Form f = new System.Windows.Forms.Form
			{
				Text = settings.ToString(),
				Width = 600,
				Height = 450,
				FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow,
				StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
			};

			System.Windows.Forms.PropertyGrid pg =
				new System.Windows.Forms.PropertyGrid();
			f.Controls.Add(pg);
			pg.Dock = System.Windows.Forms.DockStyle.Fill;
			pg.SelectedObject = settings.GetSettingsObject();
			ShowSubForm(f);
			f.Dispose();
		}

		public delegate void ResourceListSelectionChangedHandler(
			object sender,
			Events.ResourceEventArgs e
		);

		public static void FireResourceListSelectionChangedHandler(
			object sender,
			Events.ResourceEventArgs e
		)
		{
			if (ResourceListSelectionChanged != null)
			{
				ResourceListSelectionChanged(sender, e);
			}
		}

		public static event ResourceListSelectionChangedHandler ResourceListSelectionChanged;
	}
}
