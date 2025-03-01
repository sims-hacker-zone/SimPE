// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
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
		public IToolExt ToolExt =>
				//if (tool.GetType().GetInterface("SimPe.Interfaces.IToolExt", true) == typeof(SimPe.Interfaces.IToolExt)) return (SimPe.Interfaces.IToolExt)tool;
				tool is IToolExt ext ? ext : null;

		/// <summary>
		/// Return null, or the stored  Tool
		/// </summary>
		public ITool Tool => tool is ITool tool1 ? tool1 : null;

		/// <summary>
		/// Return null, or the stored ToolPlus Item
		/// </summary>
		public IToolPlus ToolPlus => tool is IToolPlus plus ? plus : null;
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
