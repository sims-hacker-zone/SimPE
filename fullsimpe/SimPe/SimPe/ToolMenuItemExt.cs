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
using System.Windows.Forms;

using SimPe.Interfaces;

namespace SimPe
{
	public class ToolMenuItemExt : ToolStripMenuItem
	{
		/// <summary>
		/// Those delegates can be called when a Tool want's to notify the Host Application
		/// </summary>
		public delegate void ExternalToolNotify(object sender, PackageArg pk);
		IToolPlugin tool;

		/// <summary>
		/// Return null, or the stored extended Tool
		/// </summary>
		public IToolExt ToolExt
		{
			get
			{
				//if (tool.GetType().GetInterface("SimPe.Interfaces.IToolExt", true) == typeof(SimPe.Interfaces.IToolExt)) return (SimPe.Interfaces.IToolExt)tool;
				if (tool is IToolExt)
				{
					return (IToolExt)tool;
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Return null, or the stored  Tool
		/// </summary>
		public ITool Tool
		{
			get
			{
				if (tool is ITool)
				{
					return (ITool)tool;
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Return null, or the stored ToolPlus Item
		/// </summary>
		public IToolPlus ToolPlus
		{
			get
			{
				if (tool is IToolPlus)
				{
					return (IToolPlus)tool;
				}
				else
				{
					return null;
				}
			}
		}
		Interfaces.Files.IPackedFileDescriptor pfd;
		Interfaces.Files.IPackageFile package;

		ExternalToolNotify ChangeHandler
		{
			get; set;
		}

		public new string Name
		{
			get;
		}

		public ToolMenuItemExt(IToolPlus tool, ExternalToolNotify chghnd)
			: this(tool.ToString(), tool, chghnd) { }

		public ToolMenuItemExt(string text, IToolPlugin tool, ExternalToolNotify chghnd)
		{
			this.tool = tool;
			Text = text;
			ToolTipText = text;
			Checked = false;
			Click += new EventHandler(LinkClicked);
			Click += new EventHandler(ClickItem);
			ChangeHandler = chghnd;

			Name = tool.GetType().Namespace + "." + tool.GetType().Name;
		}

		private void ClickItem(object sender, EventArgs e)
		{
			if (Tool == null)
			{
				return;
			}
#if !DEBUG
			try
#endif
			{
				if (Tool.IsEnabled(pfd, package))
				{
					try
					{
						Interfaces.Plugin.IToolResult tr = Tool.ShowDialog(
							ref pfd,
							ref package
						);
						if (tr.ChangedAny)
						{
							PackageArg p = new PackageArg
							{
								Package = package,
								FileDescriptor = pfd,
								Result = tr
							};
							if (ChangeHandler != null)
							{
								ChangeHandler(this, p);
							}
						}
					}
					finally
					{
						WaitingScreen.Stop();
					}
				}
			}
#if !DEBUG
			catch (Exception ex)
			{
				Helper.ExceptionMessage("Unable to Start ToolPlugin.", ex);
			}
#endif
		}

		#region Event Handler
		Events.ResourceEventArgs lasteventarg;

		/// <summary>
		/// Fired when a Resource was changed by a ToolPlugin and the Enabled state needs to be changed
		/// </summary>
		internal void ChangeEnabledStateEventHandler(
			object sender,
			Events.ResourceEventArgs e
		)
		{
			Package = AbstractToolPlus.ExtractPackage(e);
			FileDescriptor = AbstractToolPlus.ExtractFileDescriptor(e);

			if (Tool != null)
			{
				UpdateEnabledState();
			}
			else if (ToolPlus != null)
			{
				lasteventarg = e;
				Enabled = ToolPlus.ChangeEnabledStateEventHandler(sender, e);
			}
		}

		/// <summary>
		/// Fired when a Link is clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void LinkClicked(object sender, EventArgs e)
		{
			if (ToolPlus == null)
			{
				return;
			}

			lasteventarg.LoadedPackage?.PauseIndexChangedEvents();

			ToolPlus.Execute(sender, lasteventarg);
			lasteventarg.LoadedPackage?.RestartIndexChangedEvents();
		}
		#endregion

		public override string ToString()
		{
			try
			{
				return tool.ToString();
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("Unable to Load ToolPlugin.", ex);
			}

			return "Plugin Error";
		}

		public Interfaces.Files.IPackedFileDescriptor FileDescriptor
		{
			get => pfd;
			set => pfd = value;
		}

		public Interfaces.Files.IPackageFile Package
		{
			get => package;
			set => package = value;
		}

		void UpdateEnabledState()
		{
#if DEBUG
			Enabled = Tool.IsEnabled(pfd, package);
#else
			try
			{
				Enabled = Tool.IsEnabled(pfd, package);
			}
			catch (Exception)
			{
				Enabled = false;
			}
#endif
		}
	}
}
