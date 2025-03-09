// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.Generic;

namespace SimPe.Plugin
{
	/// <summary>
	/// Registry Keys for the Object Workshop
	/// </summary>
	class SimsRegistry : IDisposable
	{
		Dictionary<string, string> settings;
		Sims form;

		public SimsRegistry()
		{
			if (!Helper.WindowsRegistry.Config.PluginSettings.ContainsKey("SimBrowser"))
			{
				Helper.WindowsRegistry.Config.PluginSettings["SimBrowser"] = new Dictionary<string, string>();
			}
			settings = Helper.WindowsRegistry.Config.PluginSettings["SimBrowser"];
		}

		public SimsRegistry(Sims form)
		{
			this.form = form;

			form.ckbPlayable.Checked = ShowPlayable;
			form.ckbPlayable.CheckedChanged += new EventHandler(
				ckbPlayable_CheckedChanged
			);

			form.cbTownie.Checked = ShowTownies;
			form.cbTownie.CheckedChanged += new EventHandler(cbTownie_CheckedChanged);

			form.cbNpc.Checked = ShowNPCs;
			form.cbNpc.CheckedChanged += new EventHandler(cbNpc_CheckedChanged);

			form.ckbUnEditable.Checked = ShowUnEditable;
			form.ckbUnEditable.CheckedChanged += new EventHandler(
				ckbUnEditable_CheckedChanged
			);

			form.cbdetail.Checked = ShowDetails;
			form.cbdetail.CheckedChanged += new EventHandler(cbdetail_CheckedChanged);

			form.cbgirls.Checked = JustGirls;
			form.cbgirls.CheckedChanged += new EventHandler(cbgirls_CheckedChanged);
			form.cbmens.Enabled = !form.cbgirls.Checked;

			form.cbadults.Checked = AdultsOnly;
			form.cbadults.CheckedChanged += new EventHandler(cbadults_CheckedChanged);

			form.sorter.CurrentColumn = SortedColumn;
			form.sorter.Sorting = SortOrder;
			form.sorter.Changed += new EventHandler(sorter_Changed);

			if (!Helper.WindowsRegistry.Config.PluginSettings.ContainsKey("SimBrowser"))
			{
				Helper.WindowsRegistry.Config.PluginSettings["SimBrowser"] = new Dictionary<string, string>();
			}
			settings = Helper.WindowsRegistry.Config.PluginSettings["SimBrowser"];
		}

		#region Properties
		public bool ShowPlayable
		{
			get
			{
				if (!settings.ContainsKey("ShowPlayable"))
				{
					settings["ShowPlayable"] = true.ToString();
				}
				return bool.Parse(settings["ShowPlayable"]);
			}
			set => settings["ShowPlayable"] = value.ToString();
		}

		public bool ShowTownies
		{
			get
			{
				if (!settings.ContainsKey("ShowTownies"))
				{
					settings["ShowTownies"] = false.ToString();
				}
				return bool.Parse(settings["ShowTownies"]);
			}
			set => settings["ShowTownies"] = value.ToString();
		}

		public bool ShowNPCs
		{
			get
			{
				if (!settings.ContainsKey("ShowNPCs"))
				{
					settings["ShowNPCs"] = false.ToString();
				}
				return bool.Parse(settings["ShowNPCs"]);
			}
			set => settings["ShowNPCs"] = value.ToString();
		}

		public bool ShowUnEditable
		{
			get
			{
				if (!settings.ContainsKey("ShowUnEditable"))
				{
					settings["ShowUnEditable"] = false.ToString();
				}
				return bool.Parse(settings["ShowUnEditable"]);
			}
			set => settings["ShowUnEditable"] = value.ToString();
		}

		public bool ShowDetails
		{
			get
			{
				if (!settings.ContainsKey("ShowDetails"))
				{
					settings["ShowDetails"] = true.ToString();
				}
				return bool.Parse(settings["ShowDetails"]);
			}
			set => settings["ShowDetails"] = value.ToString();
		}

		public bool JustGirls
		{
			get
			{
				if (!settings.ContainsKey("JustGirls"))
				{
					settings["JustGirls"] = false.ToString();
				}
				return bool.Parse(settings["JustGirls"]);
			}
			set => settings["JustGirls"] = value.ToString();
		}

		public bool AdultsOnly
		{
			get
			{
				if (!settings.ContainsKey("AdultsOnly"))
				{
					settings["AdultsOnly"] = false.ToString();
				}
				return bool.Parse(settings["AdultsOnly"]);
			}
			set => settings["AdultsOnly"] = value.ToString();
		}

		public int SortedColumn
		{
			get
			{
				if (!settings.ContainsKey("SortedColumn"))
				{
					settings["SortedColumn"] = 3.ToString();
				}
				return int.Parse(settings["SortedColumn"]);
			}
			set => settings["SortedColumn"] = value.ToString();
		}

		public System.Windows.Forms.SortOrder SortOrder
		{
			get
			{
				if (!settings.ContainsKey("SortOrder"))
				{
					settings["SortOrder"] = System.Windows.Forms.SortOrder.Ascending.ToString();
				}
				return (System.Windows.Forms.SortOrder)Enum.Parse(typeof(System.Windows.Forms.SortOrder), settings["SortOrder"]);
			}
			set => settings["SortOrder"] = value.ToString();
		}

		#endregion


		#region IDisposable Member

		public void Dispose()
		{
			form = null;
		}

		#endregion

		private void ckbPlayable_CheckedChanged(object sender, EventArgs e)
		{
			System.Windows.Forms.CheckBox cb = sender as System.Windows.Forms.CheckBox;
			ShowPlayable = cb.Checked;
		}

		private void cbTownie_CheckedChanged(object sender, EventArgs e)
		{
			System.Windows.Forms.CheckBox cb = sender as System.Windows.Forms.CheckBox;
			ShowTownies = cb.Checked;
		}

		private void cbNpc_CheckedChanged(object sender, EventArgs e)
		{
			System.Windows.Forms.CheckBox cb = sender as System.Windows.Forms.CheckBox;
			ShowNPCs = cb.Checked;
		}

		private void ckbUnEditable_CheckedChanged(object sender, EventArgs e)
		{
			System.Windows.Forms.CheckBox cb = sender as System.Windows.Forms.CheckBox;
			ShowUnEditable = cb.Checked;
		}

		private void cbdetail_CheckedChanged(object sender, EventArgs e)
		{
			System.Windows.Forms.CheckBox cb = sender as System.Windows.Forms.CheckBox;
			ShowDetails = cb.Checked;
		}

		private void cbgirls_CheckedChanged(object sender, EventArgs e)
		{
			System.Windows.Forms.CheckBox cb = sender as System.Windows.Forms.CheckBox;
			JustGirls = cb.Checked;
		}

		private void cbadults_CheckedChanged(object sender, EventArgs e)
		{
			System.Windows.Forms.CheckBox cb = sender as System.Windows.Forms.CheckBox;
			AdultsOnly = cb.Checked;
		}

		private void sorter_Changed(object sender, EventArgs e)
		{
			ColumnSorter cs = sender as ColumnSorter;
			SortedColumn = cs.CurrentColumn;
			SortOrder = cs.Sorting;
		}
	}
}
