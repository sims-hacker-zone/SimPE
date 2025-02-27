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

namespace SimPe
{
	/// <summary>
	/// Summary description for ActionToolDescriptor.
	/// </summary>
	internal class ActionToolDescriptor
	{
		SimPe.Interfaces.IToolAction tool;
		LoadedPackage lp;

		SimPe.Events.ResourceEventArgs lasteventarg;

		/// <summary>
		/// Returns the generated LinkLabel
		/// </summary>
		public LinkLabel LinkLabel
		{
			get;
		}

		/// <summary>
		/// Returns the generated ToolBar ButtonItem (can be null)
		/// </summary>
		public System.Windows.Forms.ToolStripButton ToolBarButton
		{
			get;
		}

		/// <summary>
		/// Returns the generated MenuButtonItem
		/// </summary>
		public System.Windows.Forms.ToolStripMenuItem MenuButton
		{
			get;
		}

		/// <summary>
		/// Create a new Instance
		/// </summary>
		/// <param name="tool"></param>
		public ActionToolDescriptor(SimPe.Interfaces.IToolAction tool)
		{
			//this.lp = lp;
			this.tool = tool;

			LinkLabel = new LinkLabel();
			LinkLabel.Name = tool.ToString();
			if (Helper.WindowsRegistry.UseBigIcons)
			{
				LinkLabel.Font = new System.Drawing.Font(
					"Verdana",
					12,
					System.Drawing.FontStyle.Bold
				);
				LinkLabel.Height = 24;
			}
			else
			{
				LinkLabel.Font = new System.Drawing.Font(
					"Verdana",
					LinkLabel.Font.Size,
					System.Drawing.FontStyle.Bold
				);
				LinkLabel.Height = 16;
			}
			if (tool.Icon != null)
				if (tool.Icon is System.Drawing.Bitmap)
					//ll.Icon = System.Drawing.Icon.FromHandle(((System.Drawing.Bitmap)tool.Icon).GetHicon());
					LinkLabel.Text = SimPe.Localization.GetString(tool.ToString());
			LinkLabel.LinkArea = new System.Windows.Forms.LinkArea(0, LinkLabel.Text.Length);
			LinkLabel.Font = new System.Drawing.Font(
				"Verdana",
				LinkLabel.Font.Size,
				System.Drawing.FontStyle.Bold
			);
			LinkLabel.Height = 16;
			LinkLabel.AutoSize = true;

			LinkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(LinkClicked);

			MenuButton = new System.Windows.Forms.ToolStripMenuItem(LinkLabel.Text);
			MenuButton.Click += new EventHandler(LinkClicked);
			MenuButton.Image = tool.Icon;
			LoadFileWrappersExt.SetShurtcutKey(MenuButton, tool.Shortcut);
			MenuButton.EnabledChanged += new EventHandler(mi_EnabledChanged);
			MenuButton.CheckedChanged += new EventHandler(mi_CheckedChanged);

			if (tool.Icon != null)
			{
				ToolBarButton = new MyButtonItem(
					"action." + tool.GetType().Namespace + "." + tool.GetType().Name
				);
				ToolBarButton.Text = "";
				//bi.ToolTipText = ll.Label;
				ToolBarButton.Image = tool.Icon;
				//bi.BuddyMenu = mi;

				ToolBarButton.Checked = MenuButton.Checked;
				ToolBarButton.Enabled = MenuButton.Enabled;
				ToolBarButton.Click += new EventHandler(LinkClicked);
			}

			//Make Sure the Action is disabled on StartUp
			ChangeEnabledStateEventHandler(
				null,
				new SimPe.Events.ResourceEventArgs(lp)
			);
		}

		void mi_CheckedChanged(object sender, EventArgs e)
		{
			if (ToolBarButton != null)
				ToolBarButton.Checked = MenuButton.Checked;
		}

		void mi_EnabledChanged(object sender, EventArgs e)
		{
			if (ToolBarButton != null)
				ToolBarButton.Enabled = MenuButton.Enabled;
		}

		/// <summary>
		/// Fired when a Resource was changed by a ToolPlugin and the Enabled state needs to be changed
		/// </summary>
		public void ChangeEnabledStateEventHandler(
			object sender,
			SimPe.Events.ResourceEventArgs e
		)
		{
			lp = e.LoadedPackage;
			LinkLabel.Links[0].Enabled = tool.ChangeEnabledStateEventHandler(sender, e);
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
			if (lp != null)
				lp.PauseIndexChangedEvents();
			tool.ExecuteEventHandler(sender, lasteventarg);
			if (lp != null)
				lp.RestartIndexChangedEvents();
		}
	}
}
