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
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SimPe.Events;

namespace SimPe
{
	partial class MainForm
	{
		void InitTheme()
		{
			this.dcResourceList.Visible = true;
			this.dcResource.Visible = true;
			//setup the Theme Manager

			this.manager.Renderer = new Ambertation.Windows.Forms.GlossyRenderer();
		}

		private void StoreLayout()
		{
			Ambertation.Windows.Forms.Serializer.Global.ToFile(
				Helper.DataFolder.SimPeLayoutW
			);

			MyButtonItem.SetLayoutInformations(this);

			resourceViewManager1.StoreLayout();
		}

		System.IO.Stream defaultlayout;

		/// <summary>
		/// Wrapper needed to call the Layout Change through an Event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ResetLayout(object sender, EventArgs e)
		{
			if (defaultlayout != null)
			{
				Ambertation.Windows.Forms.Serializer.Global.FromStream(defaultlayout);
				Ambertation.Windows.Forms.Serializer.Global.ToFile(
					Helper.DataFolder.SimPeLayoutW
				);
			}

			if (Helper.WindowsRegistry.UseBigIcons)
			{
				toolBar1.ImageScalingSize = new System.Drawing.Size(16, 16);
				tbWindow.ImageScalingSize = new System.Drawing.Size(16, 16);
				tbTools.ImageScalingSize = new System.Drawing.Size(16, 16);
				tbAction.ImageScalingSize = new System.Drawing.Size(16, 16);
			}

			Commandline.ForceDefaultLayout();
			waitControl1.Visible = true;
			// End Force Default Layout

			FixVisibleState(tbTools);
			FixVisibleState(tbAction);
			FixVisibleState(toolBar1);

			ReloadLayout();

			// tbTools.Visible = true;
			tbTools.Visible = !Helper.NoPlugins;
			tbAction.Visible = true;
			toolBar1.Visible = true;
			tbWindow.Visible = false;
			this.dcResourceList.Visible = true;
		}

		/// <summary>
		/// Reload the Layout from the Registry
		/// </summary>
		void ReloadLayout()
		{
			this.SuspendLayout();
			//store defaults
			if (defaultlayout == null)
				defaultlayout = Ambertation.Windows.Forms.Serializer.Global.ToStream();

			try
			{
				Ambertation.Windows.Forms.Serializer.Global.FromFile(
					Helper.DataFolder.SimPeLayout
				);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(ex);
			}

			resourceViewManager1.RestoreLayout();

			UpdateDockMenus();
			MyButtonItem.GetLayoutInformations(this);

			FixCheckedState(tbTools);
			FixCheckedState((tbAction));
			FixCheckedState(toolBar1);

			foreach (ToolStripItem tsi in miWindow.DropDownItems)
			{
				ToolStripMenuItem tsmi = tsi as ToolStripMenuItem;
				if (tsmi == null)
					continue;
				if (tsmi.Tag == null)
					continue;

				Ambertation.Windows.Forms.DockPanel dp =
					tsmi.Tag as Ambertation.Windows.Forms.DockPanel;
				if (dp != null)
					tsmi.Checked = dp.IsOpen;
			}
			this.ResumeLayout();
		}

		private void FixCheckedState(System.Windows.Forms.ToolStrip ts)
		{
			foreach (System.Windows.Forms.ToolStripItem tsi in ts.Items)
			{
				System.Windows.Forms.ToolStripButton tsb =
					tsi as System.Windows.Forms.ToolStripButton;
				if (tsb == null)
					continue;
				if (tsb.Overflow != System.Windows.Forms.ToolStripItemOverflow.Always)
					tsb.Checked = false;
			}
		}

		private void FixVisibleState(System.Windows.Forms.ToolStrip ts)
		{
			foreach (System.Windows.Forms.ToolStripItem tsi in ts.Items)
			{
				System.Windows.Forms.ToolStripButton tsb =
					tsi as System.Windows.Forms.ToolStripButton;
				if (tsb == null)
					continue;
				if (tsb.Image != null)
					tsb.Visible = true;
			}
		}
	}
}
