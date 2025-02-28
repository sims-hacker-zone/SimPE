// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Windows.Forms;

namespace SimPe
{
	partial class MainForm
	{
		void InitTheme()
		{
			dcResourceList.Visible = true;
			dcResource.Visible = true;
			//setup the Theme Manager

			manager.Renderer = new Ambertation.Windows.Forms.GlossyRenderer();
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
			dcResourceList.Visible = true;
		}

		/// <summary>
		/// Reload the Layout from the Registry
		/// </summary>
		void ReloadLayout()
		{
			SuspendLayout();
			//store defaults
			if (defaultlayout == null)
			{
				defaultlayout = Ambertation.Windows.Forms.Serializer.Global.ToStream();
			}

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
			FixCheckedState(tbAction);
			FixCheckedState(toolBar1);

			foreach (ToolStripItem tsi in miWindow.DropDownItems)
			{
				if (!(tsi is ToolStripMenuItem tsmi))
				{
					continue;
				}

				if (tsmi.Tag == null)
				{
					continue;
				}

				Ambertation.Windows.Forms.DockPanel dp =
					tsmi.Tag as Ambertation.Windows.Forms.DockPanel;
				if (dp != null)
				{
					tsmi.Checked = dp.IsOpen;
				}
			}
			ResumeLayout();
		}

		private void FixCheckedState(ToolStrip ts)
		{
			foreach (ToolStripItem tsi in ts.Items)
			{
				if (!(tsi is ToolStripButton tsb))
				{
					continue;
				}

				if (tsb.Overflow != ToolStripItemOverflow.Always)
				{
					tsb.Checked = false;
				}
			}
		}

		private void FixVisibleState(ToolStrip ts)
		{
			foreach (ToolStripItem tsi in ts.Items)
			{
				if (!(tsi is ToolStripButton tsb))
				{
					continue;
				}

				if (tsb.Image != null)
				{
					tsb.Visible = true;
				}
			}
		}
	}
}
