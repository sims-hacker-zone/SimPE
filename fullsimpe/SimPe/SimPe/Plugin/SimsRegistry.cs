// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

namespace SimPe.Plugin
{
	/// <summary>
	/// Registry Keys for the Object Workshop
	/// </summary>
	class SimsRegistry : IDisposable
	{
		XmlRegistryKey xrk;
		Sims form;

		public SimsRegistry(Sims form)
		{
			this.form = form;
			xrk = Helper.WindowsRegistry.PluginRegistryKey;

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

			form.cbgals.Checked = JustGals;
			form.cbgals.CheckedChanged += new EventHandler(cbgals_CheckedChanged);
			form.cbmens.Enabled = !form.cbgals.Checked;

			form.cbadults.Checked = AdultsOnly;
			form.cbadults.CheckedChanged += new EventHandler(cbadults_CheckedChanged);

			form.sorter.CurrentColumn = SortedColumn;
			form.sorter.Sorting = SortOrder;
			form.sorter.Changed += new EventHandler(sorter_Changed);
		}

		#region Properties
		public bool ShowPlayable
		{
			get
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("SimBrowser");
				object o = rkf.GetValue("ShowPlayable", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("SimBrowser");
				rkf.SetValue("ShowPlayable", value);
			}
		}

		public bool ShowTownies
		{
			get
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("SimBrowser");
				object o = rkf.GetValue("ShowTownies", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("SimBrowser");
				rkf.SetValue("ShowTownies", value);
			}
		}

		public bool ShowNPCs
		{
			get
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("SimBrowser");
				object o = rkf.GetValue("ShowNPCs", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("SimBrowser");
				rkf.SetValue("ShowNPCs", value);
			}
		}

		public bool ShowUnEditable
		{
			get
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("SimBrowser");
				object o = rkf.GetValue("ShowUnEditable", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("SimBrowser");
				rkf.SetValue("ShowUnEditable", value);
			}
		}

		public bool ShowDetails
		{
			get
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("SimBrowser");
				object o = rkf.GetValue("ShowDetails", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("SimBrowser");
				rkf.SetValue("ShowDetails", value);
			}
		}

		public bool JustGals
		{
			get
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("SimBrowser");
				object o = rkf.GetValue("JustGals", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("SimBrowser");
				rkf.SetValue("JustGals", value);
			}
		}

		public bool AdultsOnly
		{
			get
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("SimBrowser");
				object o = rkf.GetValue("AdultsOnly", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("SimBrowser");
				rkf.SetValue("AdultsOnly", value);
			}
		}

		public int SortedColumn
		{
			get
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("SimBrowser");
				object o = rkf.GetValue("SortedColumn", 3);
				return Convert.ToInt32(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("SimBrowser");
				rkf.SetValue("SortedColumn", value);
			}
		}

		public System.Windows.Forms.SortOrder SortOrder
		{
			get
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("SimBrowser");
				object o = rkf.GetValue(
					"SortOrder",
					(int)System.Windows.Forms.SortOrder.Ascending
				);
				return (System.Windows.Forms.SortOrder)Convert.ToInt32(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("SimBrowser");
				rkf.SetValue("SortOrder", (int)value);
			}
		}

		#endregion


		#region IDisposable Member

		public void Dispose()
		{
			form = null;
			xrk = null;
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

		private void cbgals_CheckedChanged(object sender, EventArgs e)
		{
			System.Windows.Forms.CheckBox cb = sender as System.Windows.Forms.CheckBox;
			JustGals = cb.Checked;
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
