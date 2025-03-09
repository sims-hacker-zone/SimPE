// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.Generic;

namespace SimPe.Plugin.Tool.Dockable
{
	/// <summary>
	/// Registry Keys for the Object Workshop
	/// </summary>
	class ObjectWorkshopRegistry : IDisposable
	{
		Dictionary<string, string> settings;
		XmlRegistryKey xrk;
		dcObjectWorkshop dock;

		public ObjectWorkshopRegistry(dcObjectWorkshop dock)
		{
			this.dock = dock;
			if (!Helper.WindowsRegistry.Config.PluginSettings.ContainsKey("ObjectWorkshop"))
			{
				Helper.WindowsRegistry.Config.PluginSettings["ObjectWorkshop"] = new Dictionary<string, string>();
			}
			settings = Helper.WindowsRegistry.Config.PluginSettings["ObjectWorkshop"];

			try
			{
				dock.cbTask.SelectedIndex = LastOWAction;
			}
			catch
			{
				dock.cbTask.SelectedIndex = 0;
			}
			dock.cbTask.SelectedIndexChanged += new EventHandler(
				cbTask_SelectedIndexChanged
			);

			dock.cbDesc.Checked = ChangeDescription;
			dock.cbDesc.CheckedChanged += new EventHandler(cbDesc_CheckedChanged);

			dock.cbgid.Checked = SetCustomGroup;
			dock.cbgid.CheckedChanged += new EventHandler(cbgid_CheckedChanged);

			dock.cbfix.Checked = FixCloned;
			dock.cbfix.CheckedChanged += new EventHandler(cbfix_CheckedChanged);

			dock.cbclean.Checked = FixCloned;
			dock.cbclean.CheckedChanged += new EventHandler(cbclean_CheckedChanged);

			dock.cbRemTxt.Checked = RemoveNoneDefaultLanguageStrings;
			dock.cbRemTxt.CheckedChanged += new EventHandler(cbRemTxt_CheckedChanged);

			dock.cbparent.Checked = CreateStandAlone;
			dock.cbparent.CheckedChanged += new EventHandler(cbparent_CheckedChanged);

			dock.cbdefault.Checked = PullDefaultColorOnly;
			dock.cbdefault.CheckedChanged += new EventHandler(cbdefault_CheckedChanged);

			dock.cbwallmask.Checked = PullWallmasks;
			dock.cbwallmask.CheckedChanged += new EventHandler(
				cbwallmask_CheckedChanged
			);

			dock.cbanim.Checked = PullAnimations;
			dock.cbanim.CheckedChanged += new EventHandler(cbanim_CheckedChanged);

			dock.cbstrlink.Checked = PullStrLinkedResources;
			dock.cbstrlink.CheckedChanged += new EventHandler(cbstrlink_CheckedChanged);

			dock.cbOrgGmdc.Checked = ReferenceOriginalMesh;
			dock.cbOrgGmdc.CheckedChanged += new EventHandler(cbOrgGmdc_CheckedChanged);
		}

		public void SetDefaults()
		{
			dock.cbDesc.Checked = true;
			dock.cbgid.Checked = true;
			dock.cbfix.Checked = true;
			dock.cbclean.Checked = true;
			dock.cbRemTxt.Checked = true;
			dock.cbparent.Checked = false;
			dock.cbdefault.Checked = true;
			dock.cbwallmask.Checked = true;
			dock.cbanim.Checked = false;
			dock.cbstrlink.Checked = true;
			dock.cbOrgGmdc.Checked = false;
		}

		#region Properties
		/// <summary>
		/// true, if user wants to show the OBJD Filenames in OW
		/// </summary>
		public int LastOWAction
		{
			get
			{
				if (!settings.ContainsKey("LastOWAction"))
				{
					settings["LastOWAction"] = 0.ToString();
				}
				return int.Parse(settings["LastOWAction"]);
			}
			set => settings["LastOWAction"] = value.ToString();
		}

		public bool ChangeDescription
		{
			get
			{
				if (!settings.ContainsKey("ChangeDescription"))
				{
					settings["ChangeDescription"] = true.ToString();
				}
				return bool.Parse(settings["ChangeDescription"]);
			}
			set => settings["ChangeDescription"] = value.ToString();
		}

		public bool SetCustomGroup
		{
			get
			{
				if (!settings.ContainsKey("SetCustomGroup"))
				{
					settings["SetCustomGroup"] = true.ToString();
				}
				return bool.Parse(settings["SetCustomGroup"]);
			}
			set => settings["SetCustomGroup"] = value.ToString();
		}

		public bool FixCloned
		{
			get
			{
				if (!settings.ContainsKey("FixCloned"))
				{
					settings["FixCloned"] = true.ToString();
				}
				return bool.Parse(settings["FixCloned"]);
			}
			set => settings["FixCloned"] = value.ToString();
		}

		public bool Cleanup
		{
			get
			{
				if (!settings.ContainsKey("Cleanup"))
				{
					settings["Cleanup"] = true.ToString();
				}
				return bool.Parse(settings["Cleanup"]);
			}
			set => settings["Cleanup"] = value.ToString();
		}

		public bool RemoveNoneDefaultLanguageStrings
		{
			get
			{
				if (!settings.ContainsKey("RemoveNoneDefaultLanguageStrings"))
				{
					settings["RemoveNoneDefaultLanguageStrings"] = true.ToString();
				}
				return bool.Parse(settings["RemoveNoneDefaultLanguageStrings"]);
			}
			set => settings["RemoveNoneDefaultLanguageStrings"] = value.ToString();
		}

		public bool CreateStandAlone
		{
			get
			{
				if (!settings.ContainsKey("CreateStandAlone"))
				{
					settings["CreateStandAlone"] = false.ToString();
				}
				return bool.Parse(settings["CreateStandAlone"]);
			}
			set => settings["CreateStandAlone"] = value.ToString();
		}

		public bool PullDefaultColorOnly
		{
			get
			{
				if (!settings.ContainsKey("PullDefaultColorOnly"))
				{
					settings["PullDefaultColorOnly"] = true.ToString();
				}
				return bool.Parse(settings["PullDefaultColorOnly"]);
			}
			set => settings["PullDefaultColorOnly"] = value.ToString();
		}

		public bool PullWallmasks
		{
			get
			{
				if (!settings.ContainsKey("PullWallmasks"))
				{
					settings["PullWallmasks"] = true.ToString();
				}
				return bool.Parse(settings["PullWallmasks"]);
			}
			set => settings["PullWallmasks"] = value.ToString();
		}

		public bool PullAnimations
		{
			get
			{
				if (!settings.ContainsKey("PullAnimations"))
				{
					settings["PullAnimations"] = false.ToString();
				}
				return bool.Parse(settings["PullAnimations"]);
			}
			set => settings["PullAnimations"] = value.ToString();
		}

		public bool PullStrLinkedResources
		{
			get
			{
				if (!settings.ContainsKey("PullStrLinkedResources"))
				{
					settings["PullStrLinkedResources"] = true.ToString();
				}
				return bool.Parse(settings["PullStrLinkedResources"]);
			}
			set => settings["PullStrLinkedResources"] = value.ToString();
		}

		public bool ReferenceOriginalMesh
		{
			get
			{
				if (!settings.ContainsKey("ReferenceOriginalMesh"))
				{
					settings["ReferenceOriginalMesh"] = false.ToString();
				}
				return bool.Parse(settings["ReferenceOriginalMesh"]);
			}
			set => settings["ReferenceOriginalMesh"] = value.ToString();
		}

		#endregion


		#region IDisposable Member

		public void Dispose()
		{
			dock.cbTask.SelectedIndexChanged -= new EventHandler(
				cbTask_SelectedIndexChanged
			);
			dock.cbDesc.CheckedChanged -= new EventHandler(cbDesc_CheckedChanged);
			dock.cbgid.CheckedChanged -= new EventHandler(cbgid_CheckedChanged);
			dock.cbfix.CheckedChanged -= new EventHandler(cbfix_CheckedChanged);
			dock.cbclean.CheckedChanged -= new EventHandler(cbclean_CheckedChanged);
			dock.cbRemTxt.CheckedChanged -= new EventHandler(cbRemTxt_CheckedChanged);
			dock.cbparent.CheckedChanged -= new EventHandler(cbparent_CheckedChanged);
			dock.cbdefault.CheckedChanged -= new EventHandler(cbdefault_CheckedChanged);
			dock.cbwallmask.CheckedChanged -= new EventHandler(
				cbwallmask_CheckedChanged
			);
			dock.cbanim.CheckedChanged -= new EventHandler(cbanim_CheckedChanged);
			dock.cbstrlink.CheckedChanged -= new EventHandler(cbstrlink_CheckedChanged);
			dock.cbOrgGmdc.CheckedChanged -= new EventHandler(cbOrgGmdc_CheckedChanged);

			dock = null;
			xrk = null;
		}

		#endregion


		#region Events
		private void cbDesc_CheckedChanged(object sender, EventArgs e)
		{
			System.Windows.Forms.CheckBox cb = sender as System.Windows.Forms.CheckBox;
			ChangeDescription = cb.Checked;
		}

		private void cbgid_CheckedChanged(object sender, EventArgs e)
		{
			System.Windows.Forms.CheckBox cb = sender as System.Windows.Forms.CheckBox;
			SetCustomGroup = cb.Checked;
		}

		private void cbTask_SelectedIndexChanged(object sender, EventArgs e)
		{
			System.Windows.Forms.ComboBox cb = sender as System.Windows.Forms.ComboBox;
			LastOWAction = cb.SelectedIndex;
		}

		private void cbfix_CheckedChanged(object sender, EventArgs e)
		{
			System.Windows.Forms.CheckBox cb = sender as System.Windows.Forms.CheckBox;
			FixCloned = cb.Checked;
		}

		private void cbclean_CheckedChanged(object sender, EventArgs e)
		{
			System.Windows.Forms.CheckBox cb = sender as System.Windows.Forms.CheckBox;
			Cleanup = cb.Checked;
		}

		private void cbRemTxt_CheckedChanged(object sender, EventArgs e)
		{
			System.Windows.Forms.CheckBox cb = sender as System.Windows.Forms.CheckBox;
			RemoveNoneDefaultLanguageStrings = cb.Checked;
		}

		private void cbparent_CheckedChanged(object sender, EventArgs e)
		{
			System.Windows.Forms.CheckBox cb = sender as System.Windows.Forms.CheckBox;
			CreateStandAlone = cb.Checked;
		}

		private void cbdefault_CheckedChanged(object sender, EventArgs e)
		{
			System.Windows.Forms.CheckBox cb = sender as System.Windows.Forms.CheckBox;
			PullDefaultColorOnly = cb.Checked;
		}

		private void cbwallmask_CheckedChanged(object sender, EventArgs e)
		{
			System.Windows.Forms.CheckBox cb = sender as System.Windows.Forms.CheckBox;
			PullWallmasks = cb.Checked;
		}

		private void cbanim_CheckedChanged(object sender, EventArgs e)
		{
			System.Windows.Forms.CheckBox cb = sender as System.Windows.Forms.CheckBox;
			PullAnimations = cb.Checked;
		}

		private void cbstrlink_CheckedChanged(object sender, EventArgs e)
		{
			System.Windows.Forms.CheckBox cb = sender as System.Windows.Forms.CheckBox;
			PullStrLinkedResources = cb.Checked;
		}

		private void cbOrgGmdc_CheckedChanged(object sender, EventArgs e)
		{
			System.Windows.Forms.CheckBox cb = sender as System.Windows.Forms.CheckBox;
			ReferenceOriginalMesh = cb.Checked;
		}
		#endregion
	}
}
