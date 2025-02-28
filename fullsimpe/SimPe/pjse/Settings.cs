// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.ComponentModel;
using System.Resources;

namespace pjse
{
	class Settings : SimPe.GlobalizedObject, SimPe.Interfaces.ISettings
	{
		static ResourceManager rm = new ResourceManager(typeof(Localization));

		public static Settings PJSE
		{
			get; private set;
		}

		static Settings()
		{
			PJSE = new Settings();
		}

		const string BASENAME = "PJSE\\Bhav";
		SimPe.XmlRegistryKey xrk = SimPe.Helper.WindowsRegistry.PluginRegistryKey;

		public Settings()
			: base(rm) { }

		public event EventHandler DecimalDOValueChanged;

		public virtual void OnDecimalDOValueChanged(object sender, EventArgs e)
		{
			if (DecimalDOValueChanged != null)
			{
				DecimalDOValueChanged(sender, e);
			}
		}

		[Category("PJSE")]
		public bool DecimalDOValue
		{
			get
			{
				SimPe.XmlRegistryKey rkf =
					SimPe.Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey(
						BASENAME
					);
				object o = rkf.GetValue("decimalDOValue", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				if (DecimalDOValue != value)
				{
					SimPe.XmlRegistryKey rkf =
						SimPe.Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey(
							BASENAME
						);
					rkf.SetValue("decimalDOValue", value);
					OnDecimalDOValueChanged(this, new EventArgs());
				}
			}
		}

		public event EventHandler InstancePickerAsTextChanged;

		public virtual void OnInstancePickerAsTextChanged(object sender, EventArgs e)
		{
			if (InstancePickerAsTextChanged != null)
			{
				InstancePickerAsTextChanged(sender, e);
			}
		}

		[Category("PJSE")]
		public bool InstancePickerAsText
		{
			get
			{
				SimPe.XmlRegistryKey rkf =
					SimPe.Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey(
						BASENAME
					);
				object o = rkf.GetValue("attrPickerAsText", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				if (InstancePickerAsText != value)
				{
					SimPe.XmlRegistryKey rkf =
						SimPe.Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey(
							BASENAME
						);
					rkf.SetValue("attrPickerAsText", value);
					OnInstancePickerAsTextChanged(this, new EventArgs());
				}
			}
		}

		[Category("PJSE")]
		public bool ShowSpecialButtons
		{
			get
			{
				SimPe.XmlRegistryKey rkf =
					SimPe.Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey(
						"PJSE\\Bhav"
					);
				object o = rkf.GetValue("showSpecialButtons", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				SimPe.XmlRegistryKey rkf =
					SimPe.Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey(
						"PJSE\\Bhav"
					);
				rkf.SetValue("showSpecialButtons", value);
			}
		}

		[Category("PJSE")]
		public bool StrShowDefault
		{
			get
			{
				SimPe.XmlRegistryKey rkf =
					SimPe.Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey(
						BASENAME
					);
				object o = rkf.GetValue("strShowDefault", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				SimPe.XmlRegistryKey rkf =
					SimPe.Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey(
						BASENAME
					);
				rkf.SetValue("strShowDefault", value);
			}
		}

		[Category("PJSE")]
		public bool StrShowDesc
		{
			get
			{
				SimPe.XmlRegistryKey rkf =
					SimPe.Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey(
						BASENAME
					);
				object o = rkf.GetValue("strShowDesc", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				SimPe.XmlRegistryKey rkf =
					SimPe.Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey(
						BASENAME
					);
				rkf.SetValue("strShowDesc", value);
			}
		}

		[Category("GI")]
		public bool LoadGUIDIndexAtStartup
		{
			get
			{
				SimPe.XmlRegistryKey rkf =
					SimPe.Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey(
						BASENAME
					);
				object o = rkf.GetValue("loadGUIDIndexAtStartup", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				SimPe.XmlRegistryKey rkf =
					SimPe.Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey(
						BASENAME
					);
				rkf.SetValue("loadGUIDIndexAtStartup", value);
			}
		}

		#region ISettings Members

		public object GetSettingsObject()
		{
			return this;
		}

		public override string ToString()
		{
			return Localization.GetString("pjse_Settings");
		}

		[Browsable(false)]
		public System.Drawing.Image Icon => null;

		#endregion
	}
}
