/***************************************************************************
 *   Copyright (C) 2008 by Peter L Jones                                   *
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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace pjse
{
	public class LabelledDataOwnerByte : LabelledDataOwner
	{
		public LabelledDataOwnerByte()
			: base()
		{
			ValueIsByte = true;
		}

		public LabelledDataOwnerByte(BhavWiz inst, byte downer, byte value)
			: base(inst, downer, value)
		{
			ValueIsByte = true;
		}
	}

	public class LabelledDataOwnerXX : LabelledDataOwner
	{
		public LabelledDataOwnerXX()
			: base()
		{
			ValueIsByte = true;
			Use0xPrefix = false;
		}

		public LabelledDataOwnerXX(BhavWiz inst, byte downer, byte value)
			: base(inst, downer, value)
		{
			ValueIsByte = true;
			Use0xPrefix = false;
		}
	}

	public partial class LabelledDataOwner : UserControl, IDataOwner
	{
		protected BhavOperandWizards.DataOwnerControl doc;

		public LabelledDataOwner()
			: this(null, 0, (ushort)0) { }

		public LabelledDataOwner(BhavWiz inst, byte downer, ushort value)
		{
			InitializeComponent();
			doc = new BhavOperandWizards.DataOwnerControl(
				inst,
				cbDataOwner,
				cbPicker,
				tbVal,
				ckbDecimal,
				ckbUseInstancePicker,
				lbInstance,
				downer,
				value
			);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				if (doc != null)
				{
					doc = null;
				}

				components.Dispose();
			}
			base.Dispose(disposing);
		}

		[Category("Appearance")]
		[Description("Text associated with the control.")]
		[Localizable(true)]
		[Browsable(true)]
		[EditorBrowsable(0)]
		public string Label
		{
			get
			{
				return lbLabel.Text;
			}
			set
			{
				lbLabel.Text = value;
			}
		}

		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("True if the Label text should be visible.")]
		public bool LabelVisible
		{
			get
			{
				return lbLabel.Visible;
			}
			set
			{
				lbLabel.Visible = value;
			}
		}

		[Category("Layout")]
		[DefaultValue(true)]
		[Description("True if the Label should resize automatically.")]
		public bool LabelAutoSize
		{
			get
			{
				return lbLabel.AutoSize;
			}
			set
			{
				lbLabel.AutoSize = value;
			}
		}

		[Category("Layout")]
		//[DefaultValue(true)]
		[Description("Size of the label in pixels.")]
		public Size LabelSize
		{
			get
			{
				return lbLabel.Size;
			}
			set
			{
				lbLabel.Size = value;
			}
		}

		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("True if the Instance Label text should be visible.")]
		public bool InstanceLabelVisible
		{
			get
			{
				return lbInstance.Visible;
			}
			set
			{
				lbInstance.Visible = value;
			}
		}

		/// <summary>
		/// True if values should be in Decimal (except Consts).
		/// Bound to pjse.Settings.PJSE.DecimalDOValue
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(
			DesignerSerializationVisibility.Hidden
		)]
		public bool Decimal
		{
			get
			{
				return ckbDecimal.Checked;
			}
			set
			{
				ckbDecimal.Checked = value;
			}
		}

		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("True if the Decimal Checkbox should be visible.")]
		public bool DecimalVisible
		{
			get
			{
				return ckbDecimal.Visible;
			}
			set
			{
				ckbDecimal.Visible = value;
			}
		}

		/// <summary>
		/// True if the Instance Picker should be used (when appropriate) (also Param / Local name).
		/// Bound to pjse.Settings.PJSE.InstancePickerAsText
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(
			DesignerSerializationVisibility.Hidden
		)]
		public bool UseInstancePicker
		{
			get
			{
				return ckbUseInstancePicker.Checked;
			}
			set
			{
				ckbUseInstancePicker.Checked = value;
			}
		}

		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("True if the Instance Picker Checkbox should be visible.")]
		public bool UseInstancePickerVisible
		{
			get
			{
				return ckbUseInstancePicker.Visible;
			}
			set
			{
				ckbUseInstancePicker.Visible = value;
			}
		}

		[Category("Behavior")]
		[DefaultValue(true)]
		[Description(
			"True if Flag Names should be used (where appropriate).\nNote that \"FlagsFor\" must be set correctly."
		)]
		public bool UseFlagNames
		{
			get
			{
				return doc.UseFlagNames;
			}
			set
			{
				doc.UseFlagNames = value;
			}
		}

		/// <summary>
		/// Specifies for which data owner this entry is specifying a flag number
		/// </summary>
		[Category("Data")]
		[DefaultValue(null)]
		[Description(
			"Specifies for which data owner this entry is specifying a flag number."
		)]
		public IDataOwner FlagsFor
		{
			get
			{
				return doc.FlagsFor;
			}
			set
			{
				if (value as LabelledDataOwner != null)
				{
					doc.FlagsFor = ((LabelledDataOwner)value).doc;
				}
				else
				{
					doc.FlagsFor = value;
				}
			}
		}

		/// <summary>
		/// Specifies to which Instruction this data owner applies.  Can be null.
		/// </summary>
		[Browsable(false)]
		public BhavWiz Instruction
		{
			get
			{
				return doc.Instruction;
			}
			set
			{
				doc.Instruction = value;
			}
		}

		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("Indicates whether the Data Owner combo box can be changed.")]
		public bool DataOwnerEnabled
		{
			get
			{
				return cbDataOwner.Enabled;
			}
			set
			{
				cbDataOwner.Enabled = value;
			}
		}

		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("True if hex values should use \"0x\" prefix.")]
		public bool Use0xPrefix
		{
			get
			{
				return doc.Use0xPrefix;
			}
			set
			{
				doc.Use0xPrefix = value;
			}
		}

		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("True if the value should be treated as a byte.")]
		public bool ValueIsByte
		{
			get
			{
				return doc.ValueIsByte;
			}
			set
			{
				doc.ValueIsByte = value;
			}
		}

		#region IDataOwner Members

		[Category("Appearance")]
		[Description("The Data Owner")]
		[Browsable(true)]
		[EditorBrowsable(0)]
		[DefaultValue((byte)0)]
		public byte DataOwner
		{
			get
			{
				return doc.DataOwner;
			}
			set
			{
				if (value >= cbDataOwner.Items.Count)
				{
					cbDataOwner.SelectedIndex = -1;
				}
				else
				{
					cbDataOwner.SelectedIndex = value;
				}
			}
		}

		[Category("Appearance")]
		[Description("The Data Owner Value")]
		[Browsable(true)]
		[EditorBrowsable(0)]
		[DefaultValue((ushort)0)]
		public ushort Value
		{
			get
			{
				return doc.Value;
			}
			set
			{
				if (doc.Decimal)
				{
					tbVal.Text = doc.ValueIsByte
						? ((byte)value).ToString()
						: ((short)value).ToString();
				}
				else
				{
					tbVal.Text =
						"0x"
						+ (
							doc.ValueIsByte
								? SimPe.Helper.HexString((byte)value)
								: SimPe.Helper.HexString(value)
						);
				}
			}
		}

		public event EventHandler DataOwnerControlChanged;

		protected virtual void OnDataOwnerControlChanged(object sender, EventArgs e)
		{
			if (DataOwnerControlChanged != null)
			{
				DataOwnerControlChanged(sender, e);
			}
		}

		#endregion
	}
}
