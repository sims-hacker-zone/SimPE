// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimPe.Forms.MainUI.Components
{
	public class MyButtonItem : ToolStripButton
	{
		static int counter = 0;

		#region Layout stuff
		public static void GetLayoutInformations(Control b)
		{
			GetLayoutInformations(b, Helper.WindowsRegistry.Config.Layout.VisibleToolbarButtons);
		}

		static void GetLayoutInformations(Control b, List<string> list)
		{
			foreach (Control c in b.Controls)
			{
				GetLayoutInformations(c, list);
			}

			if (b is ToolStrip tb)
			{
				foreach (object o in tb.Items)
				{
					if (o is MyButtonItem mbi)
					{
						//if (!mbi.HaveDock)
						mbi.Visible = list.Contains(mbi.Name);
					}
				}
			}
		}

		public static void SetLayoutInformations(Control b)
		{
			SetLayoutInformations(b, Helper.WindowsRegistry.Config.Layout.VisibleToolbarButtons);
		}

		static void SetLayoutInformations(Control b, List<string> list)
		{
			list.Clear();
			foreach (Control c in b.Controls)
			{
				SetLayoutInformations(c, list);
			}

			if (b is ToolStrip tb)
			{
				foreach (object o in tb.Items)
				{
					if (o is MyButtonItem mbi)
					{
						if (
							mbi.Visible /*&& !mbi.HaveDock*/
						)
						{
							list.Add(mbi.Name);
						}
					}
				}
			}
		}
		#endregion
		static int namect = 0;

		public new string Name
		{
			get;
		}

		public bool HaveDock
		{
			get;
		}

		public MyButtonItem(string name)
			: this(null, name) { }

		internal MyButtonItem(ToolStripMenuItem item)
			: this(item, null) { }

		ToolStripMenuItem refitem;

		MyButtonItem(ToolStripMenuItem item, string name)
			: base()
		{
			if (name == "")
			{
				name = "AButtonItem_" + namect;
				namect++;
			}

			refitem = item;
			if (item != null)
			{
				Image = item.Image;
				Visible = item.Image != null;
				if (Image == null)
				{
					Text = item.Text;
				}

				ToolTipText = item.Text.Replace("&", "");
				Enabled = item.Enabled;
				Click += new EventHandler(MyButtonItem_Activate);
				item.CheckedChanged += new EventHandler(item_CheckedChanged);
				item.EnabledChanged += new EventHandler(item_EnabledChanged);

				ToolTipText = item.Text;
				Enabled = item.Enabled;
				Checked = item.Checked;

				HaveDock = false;
				if (item is ToolMenuItemExt tmie)
				{
					Name = tmie.Name;
				}
				else
				{
					Ambertation.Windows.Forms.DockPanel dw =
						item.Tag as Ambertation.Windows.Forms.DockPanel;

					if (dw != null)
					{
						Name = dw.Name;
						HaveDock = true;
					}
					else
					{
						Name = "Button_" + counter++;
					}
				}
			}
			else
			{
				HaveDock = false;
				Name = name;
			}
		}

		void item_EnabledChanged(object sender, EventArgs e)
		{
			Enabled = ((ToolStripMenuItem)sender).Enabled;
		}

		void item_CheckedChanged(object sender, EventArgs e)
		{
			Checked = ((ToolStripMenuItem)sender).Checked;
		}

		void MyButtonItem_Activate(object sender, EventArgs e)
		{
			refitem.PerformClick();
		}
	}
}
