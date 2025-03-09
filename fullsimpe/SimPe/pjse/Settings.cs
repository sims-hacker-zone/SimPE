// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Resources;

using SimPe;

namespace pjse
{
	class Settings : GlobalizedObject, SimPe.Interfaces.ISettings
	{
		private readonly Dictionary<string, string> options;
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

		public Settings()
			: base(rm)
		{
			if (!Helper.WindowsRegistry.Config.PluginSettings.ContainsKey(BASENAME))
			{
				Helper.WindowsRegistry.Config.PluginSettings[BASENAME] = new Dictionary<string, string>();
			}
			options = Helper.WindowsRegistry.Config.PluginSettings[BASENAME];
		}

		public event EventHandler DecimalDOValueChanged;

		public virtual void OnDecimalDOValueChanged(object sender, EventArgs e)
		{
			DecimalDOValueChanged?.Invoke(sender, e);
		}

		[Category("PJSE")]
		public bool DecimalDOValue
		{
			get
			{
				if (!options.ContainsKey("DecimalDOValue"))
				{
					options["DecimalDOValue"] = false.ToString();
				}
				return bool.Parse(options["DecimalDOValue"]);
			}
			set
			{
				if (DecimalDOValue != value)
				{
					options["DecimalDOValue"] = value.ToString();
					OnDecimalDOValueChanged(this, new EventArgs());
				}
			}
		}

		public event EventHandler InstancePickerAsTextChanged;

		public virtual void OnInstancePickerAsTextChanged(object sender, EventArgs e)
		{
			InstancePickerAsTextChanged?.Invoke(sender, e);
		}

		[Category("PJSE")]
		public bool InstancePickerAsText
		{
			get
			{
				if (!options.ContainsKey("InstancePickerAsText"))
				{
					options["InstancePickerAsText"] = true.ToString();
				}
				return bool.Parse(options["InstancePickerAsText"]);
			}
			set
			{
				if (InstancePickerAsText != value)
				{
					options["InstancePickerAsText"] = value.ToString();
					OnInstancePickerAsTextChanged(this, new EventArgs());
				}
			}
		}

		[Category("PJSE")]
		public bool ShowSpecialButtons
		{
			get
			{
				if (!options.ContainsKey("ShowSpecialButtons"))
				{
					options["ShowSpecialButtons"] = false.ToString();
				}
				return bool.Parse(options["ShowSpecialButtons"]);
			}
			set => options["ShowSpecialButtons"] = value.ToString();
		}

		[Category("PJSE")]
		public bool StrShowDefault
		{
			get
			{
				if (!options.ContainsKey("StrShowDefault"))
				{
					options["StrShowDefault"] = false.ToString();
				}
				return bool.Parse(options["StrShowDefault"]);
			}
			set => options["StrShowDefault"] = value.ToString();
		}

		[Category("PJSE")]
		public bool StrShowDesc
		{
			get
			{
				if (!options.ContainsKey("StrShowDesc"))
				{
					options["StrShowDesc"] = false.ToString();
				}
				return bool.Parse(options["StrShowDesc"]);
			}
			set => options["StrShowDesc"] = value.ToString();
		}

		[Category("GI")]
		public bool LoadGUIDIndexAtStartup
		{
			get
			{
				if (!options.ContainsKey("LoadGUIDIndexAtStartup"))
				{
					options["LoadGUIDIndexAtStartup"] = true.ToString();
				}
				return bool.Parse(options["LoadGUIDIndexAtStartup"]);
			}
			set => options["LoadGUIDIndexAtStartup"] = value.ToString();
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
