/***************************************************************************
 *   Copyright (C) 2005-2008 by Peter L Jones                              *
 *   pljones@users.sf.net                                                  *
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
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Resources;
using System.Text;

namespace pjse
{
	class Settings : SimPe.GlobalizedObject, SimPe.Interfaces.ISettings
	{
		static ResourceManager rm = new ResourceManager(typeof(pjse.Localization));

		private static Settings settings;
		public static Settings PJSE
		{
			get
			{
				return settings;
			}
		}

		static Settings()
		{
			settings = new Settings();
		}

		const string BASENAME = "PJSE\\Bhav";
		SimPe.XmlRegistryKey xrk = SimPe.Helper.WindowsRegistry.PluginRegistryKey;

		public Settings()
			: base(rm) { }

		public event EventHandler DecimalDOValueChanged;

		public virtual void OnDecimalDOValueChanged(object sender, EventArgs e)
		{
			if (DecimalDOValueChanged != null)
				DecimalDOValueChanged(sender, e);
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
				InstancePickerAsTextChanged(sender, e);
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
			return pjse.Localization.GetString("pjse_Settings");
		}

		[System.ComponentModel.Browsable(false)]
		public System.Drawing.Image Icon
		{
			get
			{
				return null;
			}
		}

		#endregion
	}
}
