// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Windows.Forms;

using SimPe.Forms.MainUI.Components;
using SimPe.Interfaces;

namespace SimPe
{
	/// <summary>
	/// Class that can be used to Load external Filewrappers int the given Registry
	/// </summary>
	public class LoadFileWrappersExt : LoadFileWrappers
	{
		/// <summary>
		/// Constructor of The class
		/// </summary>
		/// <param name="registry">
		/// Registry the External Data should be added to
		/// </param>
		/// <param name="toolreg">Registry the tools should be added to</param>
		public LoadFileWrappersExt()
			: base(FileTableBase.WrapperRegistry, FileTable.ToolRegistry) { }

		static ArrayList exclude;

		static void CreateExcludeList()
		{
			exclude = new ArrayList();
		}

		static LoadFileWrappersExt()
		{
			CreateExcludeList();
		}

		public static void SetShurtcutKey(
			ToolStripMenuItem mi,
			Shortcut sc
		)
		{
			try
			{
				mi.ShortcutKeys = Helper.ToKeys(sc);
			}
			catch (Exception)
			{
				System.Diagnostics.Debug.WriteLine("Conversion Error from " + sc);
			}
		}

		/// <summary>
		/// Add one single MenuItem (and all needed Parents)
		/// </summary>
		/// <param name="item"></param>
		/// <param name="parts"></param>
		public static void AddMenuItem(
			ref Events.ChangedResourceEvent ev,
			ToolStripItemCollection parent,
			ToolMenuItemExt item,
			string[] parts
		)
		{
			System.Reflection.Assembly a = typeof(LoadFileWrappersExt).Assembly;

			for (int i = 0; i < parts.Length - 1; i++)
			{
				string name = Localization.GetString(parts[i]);
				ToolStripMenuItem mi = null;
				//find an existing Menu Item
				if (parent != null)
				{
					foreach (ToolStripMenuItem oi in parent)
					{
						if (oi.Text.ToLower().Trim() == name.ToLower().Trim())
						{
							mi = oi;
							break;
						}
					}
				}
				if (mi == null)
				{
					mi = new ToolStripMenuItem(name);

					if (parent != null)
					{
						System.IO.Stream imgstr = a.GetManifestResourceStream(
							"SimPe.img." + parts[i] + ".png"
						);
						if (imgstr != null)
						{
							mi.Image = System.Drawing.Image.FromStream(imgstr);
						}

						parent.Insert(0, mi);
					}
				}

				parent = mi.DropDownItems;
			}

			if (item.ToolExt != null)
			{
				SetShurtcutKey(item, item.ToolExt.Shortcut);
				item.Image = item.ToolExt.Icon;
				//item.ToolTipText = item.ToolExt.ToString();
			}

			parent.Add(item);
			ev += new Events.ChangedResourceEvent(
				item.ChangeEnabledStateEventHandler
			);
			item.ChangeEnabledStateEventHandler(
				item,
				new Events.ResourceEventArgs(null)
			);
		}

		/// <summary>
		/// Build a ToolBar that matches the Content of a MenuItem
		/// </summary>
		/// <param name="tb"></param>
		/// <param name="mi"></param>
		/// <param name="exclude">List of <see cref="TD.SandBar.MenuButtonItem"/> that should be excluded</param>
		public static void BuildToolBar(ToolStrip tb, ToolStripItemCollection mi)
		{
			BuildToolBar(tb, mi, exclude);
		}

		public static void BuildToolBar(
			ToolStrip tb,
			ToolStripItemCollection mi,
			ArrayList exclude
		)
		{
			System.Collections.Generic.List<ToolStripItemCollection> submenus =
				new System.Collections.Generic.List<ToolStripItemCollection>();
			System.Collections.Generic.List<ToolStripMenuItem> items =
				new System.Collections.Generic.List<ToolStripMenuItem>();
			System.Collections.Generic.List<ToolStripMenuItem> starters =
				new System.Collections.Generic.List<ToolStripMenuItem>();

			for (int i = mi.Count - 1; i >= 0; i--)
			{
				if (!(mi[i] is ToolStripMenuItem tsmi))
				{
					if (i < mi.Count - 1)
					{
						starters.Add(mi[i + 1] as ToolStripMenuItem);
					}

					continue;
				}
				if (tsmi.DropDownItems.Count > 0)
				{
					submenus.Add(tsmi.DropDownItems);
				}
				else
				{
					ToolStripMenuItem item = tsmi;
					if (exclude.Contains(item))
					{
						continue;
					}

					if (item.Image == null)
					{
						items.Add(item);
					}
					else
					{
						items.Insert(0, item);
					}
				}
			}

			System.Collections.Generic.List<int> groupindices =
				new System.Collections.Generic.List<int>();
			for (int i = 0; i < items.Count; i++)
			{
				ToolStripMenuItem item = items[i];
				ToolStripButton bi = new MyButtonItem(item);
				bool beggroup =
					(i == 0 && tb.Items.Count > 0) || starters.Contains(item);
				;
				if (beggroup)
				{
					groupindices.Add(i);
				}

				tb.Items.Add(bi);
			}

			//// RECHECK
			foreach (int i in groupindices)
			{
				ToolStripMenuItem bi = new ToolStripMenuItem("--");
				items.Insert(i, bi);
			}

			for (int i = 0; i < submenus.Count; i++)
			{
				BuildToolBar(tb, submenus[i], exclude);
			}
		}

		/// <summary>
		/// Link all Listeners with the GUI Control
		/// </summary>
		/// <param name="ev"></param>
		public void AddListeners(ref Events.ChangedResourceEvent ev)
		{
			//load Listeners
			foreach (IListener item in FileTable.ToolRegistry.Listeners)
			{
				ev += new Events.ChangedResourceEvent(
					item.SelectionChangedHandler
				);
				item.SelectionChangedHandler(
					item,
					new Events.ResourceEventArgs(null)
				);
			}
		}
	}
}
