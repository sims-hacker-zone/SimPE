// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Windows.Forms;

using SimPe.Forms.MainUI.Components;

namespace SimPe
{
	/// <summary>
	/// Summary description for ActionToolDescriptor.
	/// </summary>
	internal class ActionToolDescriptor
	{
		Interfaces.IToolAction tool;
		LoadedPackage lp;

		Events.ResourceEventArgs lasteventarg;

		/// <summary>
		/// Returns the generated ToolBar ButtonItem (can be null)
		/// </summary>
		public ToolStripButton ToolBarButton
		{
			get;
		}

		/// <summary>
		/// Returns the generated MenuButtonItem
		/// </summary>
		public ToolStripMenuItem MenuButton
		{
			get;
		}

		/// <summary>
		/// Create a new Instance
		/// </summary>
		/// <param name="tool"></param>
		public ActionToolDescriptor(Interfaces.IToolAction tool)
		{
			//this.lp = lp;
			this.tool = tool;
			MenuButton = new ToolStripMenuItem(Localization.GetString(tool.ToString()));
			MenuButton.Click += new EventHandler(LinkClicked);
			MenuButton.Image = tool.Icon;
			LoadFileWrappersExt.SetShurtcutKey(MenuButton, tool.Shortcut);
			MenuButton.EnabledChanged += new EventHandler(mi_EnabledChanged);
			MenuButton.CheckedChanged += new EventHandler(mi_CheckedChanged);

			if (tool.Icon != null)
			{
				ToolBarButton = new MyButtonItem(
					"action." + tool.GetType().Namespace + "." + tool.GetType().Name
				)
				{
					Text = "",
					//bi.ToolTipText = ll.Label;
					Image = tool.Icon,
					//bi.BuddyMenu = mi;

					Checked = MenuButton.Checked,
					Enabled = MenuButton.Enabled
				};
				ToolBarButton.Click += new EventHandler(LinkClicked);
			}

			//Make Sure the Action is disabled on StartUp
			ChangeEnabledStateEventHandler(
				null,
				new Events.ResourceEventArgs(lp)
			);
		}

		void mi_CheckedChanged(object sender, EventArgs e)
		{
			if (ToolBarButton != null)
			{
				ToolBarButton.Checked = MenuButton.Checked;
			}
		}

		void mi_EnabledChanged(object sender, EventArgs e)
		{
			if (ToolBarButton != null)
			{
				ToolBarButton.Enabled = MenuButton.Enabled;
			}
		}

		/// <summary>
		/// Fired when a Resource was changed by a ToolPlugin and the Enabled state needs to be changed
		/// </summary>
		public void ChangeEnabledStateEventHandler(
			object sender,
			Events.ResourceEventArgs e
		)
		{
			lp = e.LoadedPackage;
			MenuButton.Enabled = tool.ChangeEnabledStateEventHandler(sender, e);

			lasteventarg = e;
		}

		/// <summary>
		/// Fired when a Link is clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void LinkClicked(object sender, EventArgs e)
		{
			lp?.PauseIndexChangedEvents();

			tool.ExecuteEventHandler(sender, lasteventarg);
			lp?.RestartIndexChangedEvents();
		}
	}
}
