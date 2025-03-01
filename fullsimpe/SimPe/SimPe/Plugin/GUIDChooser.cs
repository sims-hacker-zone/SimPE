// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace SimPe.Plugin
{
	public partial class GUIDChooser : UserControl
	{
		public GUIDChooser()
		{
			InitializeComponent();
			internalchg = true;
			cbKnownObjects.SelectedIndex = -1;
			cbKnownObjects.Enabled = false;
			tbGUID.Text = "0x00000000";
			internalchg = false;
		}

		private bool hex32_IsValid(object sender)
		{
			try
			{
				Convert.ToUInt32(((TextBox)sender).Text, 16);
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		bool internalchg = false;
		uint currentValue = 0;
		List<string> knownObjects = null;
		List<uint> knownGUIDs = null;

		[Browsable(true)]
		[EditorBrowsable(0)]
		public int DropDownHeight
		{
			get => cbKnownObjects.DropDownHeight;
			set => cbKnownObjects.DropDownHeight = value;
		}

		[Browsable(true)]
		[EditorBrowsable(0)]
		public int DropDownWidth
		{
			get => cbKnownObjects.DropDownWidth;
			set => cbKnownObjects.DropDownWidth = value;
		}

		[Browsable(true)]
		[EditorBrowsable(0)]
		public int ComboBoxWidth
		{
			get => cbKnownObjects.Width;
			set => cbKnownObjects.Width = value;
		}

		[Browsable(true)]
		[EditorBrowsable(0)]
		public ComboBoxStyle DropDownStyle
		{
			get => cbKnownObjects.DropDownStyle;
			set => cbKnownObjects.DropDownStyle = value;
		}

		[Browsable(true)]
		[EditorBrowsable(0)]
		public string Label
		{
			get => lbLabel.Text;
			set => lbLabel.Text = value;
		}

		[Browsable(true)]
		[EditorBrowsable(0)]
		public uint Value
		{
			get => currentValue;
			set
			{
				if (currentValue == value)
				{
					return;
				}

				setValue(value, true, true);
			}
		}

		private void setValue(uint value, bool cb, bool tb)
		{
			currentValue = value;

			bool origstate = internalchg;
			internalchg = true;

			if (value == 0)
			{
				// "None"
				if (cb)
				{
					cbKnownObjects.SelectedIndex = 0;
				}

				if (tb)
				{
					tbGUID.Text = "0x00000000";
				}
			}
			else if (knownGUIDs != null && knownGUIDs.IndexOf(value) >= 0)
			{
				// Known
				if (cb)
				{
					cbKnownObjects.SelectedIndex = 2 + knownGUIDs.IndexOf(value);
				}

				if (tb)
				{
					tbGUID.Text = "0x" + Helper.HexString(value);
				}
			}
			else
			{
				// Unknown
				if (cb)
				{
					cbKnownObjects.SelectedIndex = (knownGUIDs == null) ? -1 : 1;
				}

				if (tb)
				{
					tbGUID.Text = "0x" + Helper.HexString(value);
				}
			}

			internalchg = origstate;

			OnGUIDChooserValueChanged(this, new EventArgs());
		}

		[Browsable(true)]
		[EditorBrowsable(0)]
		public object[] KnownObjects
		{
			//get { }
			set
			{
				knownObjects = new List<string>((List<string>)value[0]);
				knownObjects.Insert(0, " --None--");
				knownObjects.Insert(1, "  *Other*");
				cbKnownObjects.DataSource = knownObjects;
				cbKnownObjects.Enabled = true;
				knownGUIDs = new List<uint>((List<uint>)value[1]);
			}
		}

		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public event EventHandler GUIDChooserValueChanged;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnGUIDChooserValueChanged(object sender, EventArgs e)
		{
			if (GUIDChooserValueChanged != null)
			{
				GUIDChooserValueChanged(sender, e);
			}
		}

		private void cbKnownObjects_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			if (cbKnownObjects.SelectedIndex == 0) // None
			{
				setValue(0, false, true);
			}
			else if (cbKnownObjects.SelectedIndex > 1) // not Other
			{
				setValue(knownGUIDs[cbKnownObjects.SelectedIndex - 2], false, true);
			}
		}

		private void tbGUID_TextChanged(object sender, EventArgs e)
		{
			if (internalchg || !hex32_IsValid(sender))
			{
				return;
			}

			setValue(Convert.ToUInt32(((TextBox)sender).Text, 16), true, false);
		}

		private void hex32_Validating(
			object sender,
			CancelEventArgs e
		)
		{
			if (hex32_IsValid(sender))
			{
				return;
			}

			e.Cancel = true;

			bool origstate = internalchg;
			internalchg = true;
			((TextBox)sender).Text = "0x" + Helper.HexString(Value);
			((TextBox)sender).SelectAll();
			internalchg = origstate;
		}

		private void hex32_Validated(object sender, EventArgs e)
		{
			bool origstate = internalchg;
			internalchg = true;
			((TextBox)sender).Text = "0x" + Helper.HexString(Value);
			((TextBox)sender).SelectAll();
			internalchg = origstate;
		}
	}
}
