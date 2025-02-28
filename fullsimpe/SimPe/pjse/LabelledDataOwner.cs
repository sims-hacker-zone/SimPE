// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
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
			: this(null, 0, 0) { }

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
			get => lbLabel.Text;
			set => lbLabel.Text = value;
		}

		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("True if the Label text should be visible.")]
		public bool LabelVisible
		{
			get => lbLabel.Visible;
			set => lbLabel.Visible = value;
		}

		[Category("Layout")]
		[DefaultValue(true)]
		[Description("True if the Label should resize automatically.")]
		public bool LabelAutoSize
		{
			get => lbLabel.AutoSize;
			set => lbLabel.AutoSize = value;
		}

		[Category("Layout")]
		//[DefaultValue(true)]
		[Description("Size of the label in pixels.")]
		public Size LabelSize
		{
			get => lbLabel.Size;
			set => lbLabel.Size = value;
		}

		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("True if the Instance Label text should be visible.")]
		public bool InstanceLabelVisible
		{
			get => lbInstance.Visible;
			set => lbInstance.Visible = value;
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
			get => ckbDecimal.Checked;
			set => ckbDecimal.Checked = value;
		}

		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("True if the Decimal Checkbox should be visible.")]
		public bool DecimalVisible
		{
			get => ckbDecimal.Visible;
			set => ckbDecimal.Visible = value;
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
			get => ckbUseInstancePicker.Checked;
			set => ckbUseInstancePicker.Checked = value;
		}

		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("True if the Instance Picker Checkbox should be visible.")]
		public bool UseInstancePickerVisible
		{
			get => ckbUseInstancePicker.Visible;
			set => ckbUseInstancePicker.Visible = value;
		}

		[Category("Behavior")]
		[DefaultValue(true)]
		[Description(
			"True if Flag Names should be used (where appropriate).\nNote that \"FlagsFor\" must be set correctly."
		)]
		public bool UseFlagNames
		{
			get => doc.UseFlagNames;
			set => doc.UseFlagNames = value;
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
			get => doc.FlagsFor;
			set
			{
				doc.FlagsFor = value as LabelledDataOwner != null ? ((LabelledDataOwner)value).doc : value;
			}
		}

		/// <summary>
		/// Specifies to which Instruction this data owner applies.  Can be null.
		/// </summary>
		[Browsable(false)]
		public BhavWiz Instruction
		{
			get => doc.Instruction;
			set => doc.Instruction = value;
		}

		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("Indicates whether the Data Owner combo box can be changed.")]
		public bool DataOwnerEnabled
		{
			get => cbDataOwner.Enabled;
			set => cbDataOwner.Enabled = value;
		}

		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("True if hex values should use \"0x\" prefix.")]
		public bool Use0xPrefix
		{
			get => doc.Use0xPrefix;
			set => doc.Use0xPrefix = value;
		}

		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("True if the value should be treated as a byte.")]
		public bool ValueIsByte
		{
			get => doc.ValueIsByte;
			set => doc.ValueIsByte = value;
		}

		#region IDataOwner Members

		[Category("Appearance")]
		[Description("The Data Owner")]
		[Browsable(true)]
		[EditorBrowsable(0)]
		[DefaultValue((byte)0)]
		public byte DataOwner
		{
			get => doc.DataOwner;
			set
			{
				cbDataOwner.SelectedIndex = value >= cbDataOwner.Items.Count ? -1 : value;
			}
		}

		[Category("Appearance")]
		[Description("The Data Owner Value")]
		[Browsable(true)]
		[EditorBrowsable(0)]
		[DefaultValue((ushort)0)]
		public ushort Value
		{
			get => doc.Value;
			set
			{
				tbVal.Text = doc.Decimal
					? doc.ValueIsByte
						? ((byte)value).ToString()
						: ((short)value).ToString()
					: "0x"
						+ (
							doc.ValueIsByte
								? SimPe.Helper.HexString((byte)value)
								: SimPe.Helper.HexString(value)
						);
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
