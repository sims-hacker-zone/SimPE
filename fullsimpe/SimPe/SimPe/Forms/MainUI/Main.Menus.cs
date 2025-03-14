// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Windows.Forms;

namespace SimPe.Forms.MainUI
{
	partial class MainForm
	{
		/// <summary>
		/// Add one Dock to the List
		/// </summary>
		/// <param name="c"></param>
		/// <param name="first"></param>
		void AddDockItem(Ambertation.Windows.Forms.DockPanel c, bool first)
		{
			ToolStripMenuItem mi = new ToolStripMenuItem(c.Text);
			if (first)
			{
				miWindow.DropDownItems.Add("-");
			}

			mi.Image = c.TabImage;

			mi.Click += new EventHandler(Activate_miWindowDocks);
			mi.Tag = c;
			mi.Checked = c.IsOpen;

			if (c.Tag != null)
			{
				if (c.Tag is Shortcut)
				{
					LoadFileWrappersExt.SetShurtcutKey(
						mi,
						(Shortcut)c.Tag
					);
				}
			}

			/*c.VisibleChanged += new EventHandler(CloseDockControl);
			c.Closed += new EventHandler(CloseDockControl);*/
			c.OpenedStateChanged += new EventHandler(CloseDockControl);
			c.Tag = mi;

			miWindow.DropDownItems.Add(mi);
		}

		/// <summary>
		/// this will create all needed Dock MenuItems to Display a hidden Dock
		/// </summary>
		void AddDockMenus()
		{
			System.Collections.Generic.List<Ambertation.Windows.Forms.DockPanel> ctrls =
				manager.GetPanels();

			bool first = false; // this was true to seperate new doc container
			foreach (Ambertation.Windows.Forms.DockPanel c in ctrls)
			{
				if (c.Tag != null)
				{
					continue;
				}

				System.Diagnostics.Debug.WriteLine("##1# " + c.ButtonText);
				AddDockItem(c, first);
				first = false;
			}

			first = true;
			foreach (Ambertation.Windows.Forms.DockPanel c in ctrls)
			{
				if (c.Tag == null)
				{
					continue;
				}

				if (c.Tag is ToolStripMenuItem)
				{
					continue;
				}

				System.Diagnostics.Debug.WriteLine("##2# " + c.ButtonText);
				AddDockItem(c, first);
				first = false;
			}
		}

		/// <summary>
		/// this will update the Checked State of a Dock menu Item
		/// </summary>
		void UpdateDockMenus()
		{
			foreach (object o in miWindow.DropDownItems)
			{
				if (!(o is ToolStripMenuItem mi))
				{
					continue;
				}

				if (mi.Tag is Ambertation.Windows.Forms.DockPanel c)
				{
					mi.Checked = c.IsDocked || c.IsFloating;
				}
			}
		}

		/// <summary>
		/// Called when a close Event was sent to a DockControl
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CloseDockControl(object sender, EventArgs e)
		{
			if (sender is Ambertation.Windows.Forms.DockPanel c)
			{
				if (c.Tag is ToolStripMenuItem mi)
				{
					mi.Checked = c.IsOpen;
				}
			}
		}

		/// <summary>
		/// Called when a MenuItem that represents a Dock is clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Activate_miWindowDocks(object sender, EventArgs e)
		{
			if (sender is ToolStripMenuItem mi)
			{
				if (mi.Tag is Ambertation.Windows.Forms.DockPanel c)
				{
					if (mi.Checked)
					{
						c.Close();
						mi.Checked = c.IsOpen;
					}
					else
					{
						c.Open();
						mi.Checked = c.IsOpen;
						plugger.ChangedGuiResourceEventHandler();
					}
				}
			}
		}

		/// <summary>
		/// Called when we need to set up the MenuItems (checked state)
		/// </summary>
		void InitMenuItems()
		{
			miMetaInfo.Checked = !Helper.WindowsRegistry.Config.LoadMetaInfo;
			miFileNames.Checked = Helper.WindowsRegistry.Config.DecodeFilenamesState;

			AddDockMenus();
			UpdateMenuItems();

			tbAction.Visible = true;
			// tbTools.Visible = true;
			tbTools.Visible = !Helper.NoPlugins;
			tbWindow.Visible = false;

			ArrayList exclude = new ArrayList
			{
				miNewDc
			};
			LoadFileWrappersExt.BuildToolBar(
				tbWindow,
				miWindow.DropDownItems,
				exclude
			);
		}

		bool createdmenus;

		/// <summary>
		/// Called whenever we need to set the enabled state of a MenuItem
		/// </summary>
		void UpdateMenuItems()
		{
			miSave.Enabled = System.IO.File.Exists(package.FileName);
			miSaveCopyAs.Enabled = miSave.Enabled;
			miSaveAs.Enabled = package.Loaded;
			miClose.Enabled = package.Loaded;
			miShowName.Enabled = package.Loaded;
			miObjects.Enabled = System.IO.File.Exists(
				System.IO.Path.Combine(
					PathProvider.Global.Latest.InstallFolder,
					PathProvider.Global.Latest.ObjectsSubFolder + "\\objects.package"
				)
			);

			if (!createdmenus)
			{
				foreach (ExpansionItem ei in PathProvider.Global.Expansions)
				{
					if (ei.Flag.Class != ExpansionItem.Classes.BaseGame)
					{
						ToolStripMenuItem mi = new ToolStripMenuItem
						{
							//mi.Text = SimPe.Localization.GetString("OpenInCaption").Replace("{where}", ei.Expansion.ToString());
							Text =
							Localization.GetString("OpenInCaption")
							.Replace("{where}", ei.NameShort),
							Tag = ei
						};
						mi.Click += new EventHandler(Activate_miOpenInEp);
						mi.Enabled = ei.Exists || ei.InstallFolder != ""; // ei.InstallFolder is for where the user manually set the path to this EP

						miOpenIn.DropDownItems.Insert(
							miOpenIn.DropDownItems.Count - 1,
							mi
						);
					}
				}
				createdmenus = true;
			}
		}
	}
}
