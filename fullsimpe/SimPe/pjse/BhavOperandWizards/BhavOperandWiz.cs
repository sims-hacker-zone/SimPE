/***************************************************************************
 *   Copyright (C) 2005-2008 by Peter L Jones                              *
 *   pljones@users.sf.net                                                  *
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
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
using System.Collections.Generic;
using System.Windows.Forms;

using SimPe.PackedFiles.Wrapper;

namespace pjse
{
	/// <summary>
	/// Container for bhavPrimWizPanel from BhavOperandWizProvider
	/// </summary>
	public class BhavOperandWiz : Form
	{
		#region Form variables

		private Panel panel1;
		private Button OK;
		private Button Cancel;

		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public BhavOperandWiz()
		{
			//
			// Erforderlich f�r die Windows Form-Designerunterst�tzung
			//
			InitializeComponent();
		}

		/// <summary>
		/// Die verwendeten Ressourcen bereinigen.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				components?.Dispose();
			}
			base.Dispose(disposing);
		}

		public Instruction Execute(BhavWiz i, int wizType)
		{
			ABhavOperandWiz wiz = null;
			switch (wizType)
			{
				case 0:
					wiz = new BhavOperandWizards.BhavOperandWizRaw(i);
					break;
				case 1:
					wiz = i.Wizard();
					break;
				default:
					wiz = new BhavOperandWizards.BhavOperandWizDefault(i);
					break;
			}
			if (wiz == null)
			{
				return null;
			}

			Panel pn = wiz.bhavPrimWizPanel;
			pn.Parent = this;
			pn.Top = 0;
			pn.Left = 0;
			pn.TabIndex = 1;
			pn_Resize(pn, null);
			pn.Resize += new EventHandler(pn_Resize);
			wiz.Execute();

			DialogResult dr = ShowDialog();
			Close();

			switch (dr)
			{
				case DialogResult.OK:
					return wiz.Write();
				default:
					return null;
			}
		}

		void pn_Resize(object sender, EventArgs e)
		{
			Panel pn = (Panel)sender;
			int footHeight = Height - panel1.Bottom + 8;
			Width = pn.Width + 8;
			Height = pn.Height + footHeight;
		}

		#region Vom Windows Form-Designer generierter Code
		/// <summary>
		/// Erforderliche Methode f�r die Designerunterst�tzung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor ge�ndert werden.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(
					typeof(BhavOperandWiz)
				);
			panel1 = new Panel();
			OK = new Button();
			Cancel = new Button();
			SuspendLayout();
			//
			// panel1
			//
			resources.ApplyResources(panel1, "panel1");
			panel1.BorderStyle = BorderStyle.FixedSingle;
			panel1.Name = "panel1";
			//
			// OK
			//
			resources.ApplyResources(OK, "OK");
			OK.DialogResult = DialogResult.OK;
			OK.Name = "OK";
			//
			// Cancel
			//
			resources.ApplyResources(Cancel, "Cancel");
			Cancel.DialogResult = DialogResult.Cancel;
			Cancel.Name = "Cancel";
			//
			// BhavOperandWiz
			//
			AcceptButton = OK;
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Dpi;
			CancelButton = Cancel;
			Controls.Add(OK);
			Controls.Add(panel1);
			Controls.Add(Cancel);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Name = "BhavOperandWiz";
			ResumeLayout(false);
		}
		#endregion
	}

	public interface iBhavOperandWizForm
	{
		Panel WizPanel
		{
			get;
		}
		void Execute(Instruction inst);
		Instruction Write(Instruction inst);
	}

	/// <summary>
	/// Provides the operand wizard for a given Bhav Instruction.
	/// </summary>
	/// <summary>
	/// Abstract class for BHAV Operand Wizards to extend
	/// </summary>
	public abstract class ABhavOperandWiz : IDisposable
	{
		protected Instruction instruction = null;
		protected iBhavOperandWizForm myForm = null;

		protected ABhavOperandWiz(Instruction instruction)
		{
			this.instruction = instruction;
		}

		public virtual Panel bhavPrimWizPanel => myForm.WizPanel;

		public virtual void Execute()
		{
			myForm.Execute(instruction);
		}

		public virtual Instruction Write()
		{
			//for (int i = 0; i < 8; i++) instruction.Operands[i] = 0;
			//for (int i = 0; i < 8; i++) instruction.Reserved1[i] = 0;
			return myForm.Write(instruction);
		}

		#region IDisposable Members
		public abstract void Dispose();
		#endregion
	}
}

namespace pjse.BhavOperandWizards
{
	public class DataOwnerControl : IDisposable, IDataOwner
	{
		#region Form variables
		private ComboBox cbDataOwner;
		private ComboBox cbPicker;
		private TextBox tbValue;
		private CheckBox ckbDecimal;
		private CheckBox ckbUseInstancePicker;
		private Label lbInstance;
		#endregion

		#region Form event handlers
		private void cbDataOwner_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			if (cbDataOwner.SelectedIndex != -1)
			{
				SetDataOwner();
			}
		}

		private void cbPicker_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			if (cbPicker.SelectedIndex != -1)
			{
				SetValue((ushort)cbPicker.SelectedIndex);
				tbValue.Text = tbValueConverter(Value);
			}
		}

		private void tbValue_Enter(object sender, EventArgs e)
		{
			((TextBox)sender).SelectAll();
		}

		private void tbValue_TextChanged(object sender, EventArgs ev)
		{
			if (internalchg)
			{
				return;
			}

			if (!tbValue_IsValid((TextBox)sender))
			{
				return;
			}

			SetValue(tbValueConverter((TextBox)sender));
		}

		private void tbValue_Validating(
			object sender,
			System.ComponentModel.CancelEventArgs e
		)
		{
			if (tbValue_IsValid((TextBox)sender))
			{
				return;
			}

			e.Cancel = true;
			tbValue_Validated(sender, null);
		}

		private void tbValue_Validated(object sender, EventArgs e)
		{
			bool origstate = internalchg;
			internalchg = true;
			((TextBox)sender).Text = tbValueConverter(Value);
			internalchg = origstate;
		}

		private void ckbDecimal_CheckedChanged(object sender, EventArgs e)
		{
			if (ckbDecimal.Visible)
			{
				Settings.PJSE.DecimalDOValue = ckbDecimal.Checked;
			}
		}

		private void ckbUseAttrPicker_CheckedChanged(object sender, EventArgs e)
		{
			if (ckbUseInstancePicker.Visible)
			{
				Settings.PJSE.InstancePickerAsText =
					ckbUseInstancePicker.Checked;
			}
		}

		#endregion

		#region Form validation
		private bool tbValue_IsValid(TextBox tb)
		{
			try
			{
				ushort v = tbValueConverter(tb);
				return v < 1 << bitsInValue;
			}
			catch
			{
				return false;
			}
		}

		private string tbValueConverter(ushort v)
		{
			if (DataOwner == 0x1a)
			{
				return BhavWiz.ExpandBCONtoString(v, false);
			}
			else if (DataOwner == 0x2f)
			{
				return BhavWiz.ExpandBCONtoString(v, true);
			}
			else if (isDecimal)
			{
				return ((short)v).ToString();
			}

			String s = SimPe.Helper.HexString(v);
			int i = (bitsInValue + 3) / 4;
			s = s.Substring(s.Length - i);

			return (use0xPrefix ? "0x" : "") + s;
		}

		private ushort tbValueConverter(TextBox sender)
		{
			switch (DataOwner)
			{
				case 0x1a:
					return BhavWiz.StringtoExpandBCON(sender.Text, false);
				case 0x2f:
					return BhavWiz.StringtoExpandBCON(sender.Text, true);
				default:
					return isDecimal ? (ushort)Convert.ToInt16(sender.Text, 10) : Convert.ToUInt16(sender.Text, 16);
			}
		}

		#endregion

		public DataOwnerControl(
			BhavWiz inst,
			ComboBox cbDataOwner,
			ComboBox cbPicker,
			TextBox tbValue,
			CheckBox ckbDecimal,
			CheckBox ckbUseInstancePicker,
			Label lbInstance,
			byte dataOwner,
			ushort instance
		)
		{
			bitsInValue = 16;
			SetDataOwnerControl(
				inst,
				cbDataOwner,
				cbPicker,
				tbValue,
				ckbDecimal,
				ckbUseInstancePicker,
				lbInstance,
				dataOwner,
				instance
			);
		}

		public DataOwnerControl(
			BhavWiz inst,
			ComboBox cbDataOwner,
			ComboBox cbPicker,
			TextBox tbValue,
			CheckBox ckbDecimal,
			CheckBox ckbUseInstancePicker,
			Label lbInstance,
			byte dataOwner,
			byte instance
		)
		{
			bitsInValue = 8;
			SetDataOwnerControl(
				inst,
				cbDataOwner,
				cbPicker,
				tbValue,
				ckbDecimal,
				ckbUseInstancePicker,
				lbInstance,
				dataOwner,
				instance
			);
		}

		public void SetDataOwnerControl(
			BhavWiz inst,
			ComboBox cbDataOwner,
			ComboBox cbPicker,
			TextBox tbValue,
			CheckBox ckbDecimal,
			CheckBox ckbUseInstancePicker,
			Label lbInstance,
			byte dataOwner,
			ushort instance
		)
		{
			Dispose();
			this.inst = inst;
			this.cbDataOwner = cbDataOwner;
			this.cbPicker = cbPicker;
			this.tbValue = tbValue;
			this.ckbDecimal = ckbDecimal;
			this.ckbUseInstancePicker = ckbUseInstancePicker;
			this.lbInstance = lbInstance;
			DataOwner = dataOwner;
			Value = instance;

			flagsFor = null;

			internalchg = true;
			if (this.cbDataOwner != null)
			{
				this.cbDataOwner.Items.Clear();
				this.cbDataOwner.Items.AddRange(
					BhavWiz.readStr(GS.BhavStr.DataOwners).ToArray()
				);
				if (cbDataOwner.Items.Count > dataOwner)
				{
					cbDataOwner.SelectedIndex = dataOwner;
				}

				this.cbDataOwner.SelectedIndexChanged += new EventHandler(
					cbDataOwner_SelectedIndexChanged
				);
			}

			if (this.cbPicker != null)
			{
				this.cbPicker.SelectedIndexChanged += new EventHandler(
					cbPicker_SelectedIndexChanged
				);
			}

			if (this.tbValue != null)
			{
				this.tbValue.Text = tbValueConverter(instance);
				this.tbValue.Validating += new System.ComponentModel.CancelEventHandler(
					tbValue_Validating
				);
				this.tbValue.Validated += new EventHandler(
					tbValue_Validated
				);
				this.tbValue.TextChanged += new EventHandler(
					tbValue_TextChanged
				);
				this.tbValue.Enter += new EventHandler(tbValue_Enter);
			}

			Settings.PJSE.DecimalDOValueChanged += new EventHandler(
				PJSE_DecimalDOValueChanged
			);
			Decimal = Settings.PJSE.DecimalDOValue;
			if (this.ckbDecimal != null)
			{
				this.ckbDecimal.Checked = Decimal;
				this.ckbDecimal.CheckedChanged += new EventHandler(
					ckbDecimal_CheckedChanged
				);
			}

			Settings.PJSE.InstancePickerAsTextChanged += new EventHandler(
				PJSE_InstancePickerAsTextChanged
			);
			UseInstancePicker = Settings.PJSE.InstancePickerAsText;
			if (this.ckbUseInstancePicker != null)
			{
				this.ckbUseInstancePicker.Checked = UseInstancePicker;
				this.ckbUseInstancePicker.CheckedChanged += new EventHandler(
					ckbUseAttrPicker_CheckedChanged
				);
			}

			internalchg = false;

			SetDataOwner();

			setTextBoxLength();
			setInstanceLabel();
		}

		void PJSE_DecimalDOValueChanged(object sender, EventArgs e)
		{
			Decimal = Settings.PJSE.DecimalDOValue;
			if (ckbDecimal != null && ckbDecimal.Checked != Decimal)
			{
				ckbDecimal.Checked = Decimal;
			}
		}

		void PJSE_InstancePickerAsTextChanged(object sender, EventArgs e)
		{
			UseInstancePicker = Settings.PJSE.InstancePickerAsText;
			if (
				ckbUseInstancePicker != null
				&& ckbUseInstancePicker.Checked != UseInstancePicker
			)
			{
				ckbUseInstancePicker.Checked = UseInstancePicker;
			}
		}

		#region IDisposable Members

		public void Dispose()
		{
			if (cbDataOwner != null)
			{
				cbDataOwner.SelectedIndexChanged -= new EventHandler(
					cbDataOwner_SelectedIndexChanged
				);
			}

			if (cbPicker != null)
			{
				cbPicker.SelectedIndexChanged -= new EventHandler(
					cbPicker_SelectedIndexChanged
				);
			}

			if (tbValue != null)
			{
				tbValue.TextChanged -= new EventHandler(
					tbValue_TextChanged
				);
			}

			if (ckbDecimal != null)
			{
				ckbDecimal.CheckedChanged -= new EventHandler(
					ckbDecimal_CheckedChanged
				);
			}

			if (ckbUseInstancePicker != null)
			{
				ckbUseInstancePicker.CheckedChanged -= new EventHandler(
					ckbUseAttrPicker_CheckedChanged
				);
			}

			inst = null;
			cbDataOwner = null;
			cbPicker = null;
			tbValue = null;
			ckbDecimal = null;
			ckbUseInstancePicker = null;
			lbInstance = null;
			flagsFor = null;
		}

		#endregion

		#region IDataOwner Members

		public byte DataOwner { get; private set; } = 0;

		public ushort Value { get; private set; } = 0;

		public event EventHandler DataOwnerControlChanged;

		internal virtual void OnDataOwnerControlChanged(object sender, EventArgs e)
		{
			if (DataOwnerControlChanged != null)
			{
				DataOwnerControlChanged(sender, e);
			}
		}

		#endregion

		private void SetDataOwner()
		{
			if (internalchg)
			{
				return;
			}

			internalchg = true;

			if (cbDataOwner != null && cbDataOwner.SelectedIndex != DataOwner)
			{
				DataOwner = (byte)cbDataOwner.SelectedIndex;
				setTextBoxLength();
				tbValue.Text = tbValueConverter(Value);
				OnDataOwnerControlChanged(this, new EventArgs());
			}

			#region pickerNames
			List<String> pickerNames = null;
			if (useInstancePicker && cbPicker != null)
			{
				if (useFlagNames && DataOwner == 0x07 && flagsFor != null)
				{
					pickerNames = BhavWiz.flagNames(flagsFor.DataOwner, flagsFor.Value);
					if (pickerNames != null)
					{
						pickerNames = new List<string>(pickerNames);
						pickerNames.Insert(
							0,
							"[0: " + Localization.GetString("invalid") + "]"
						);
					}
				}
				else if (
					inst != null
					&& useInstancePicker
					&& (DataOwner == 0x00 || DataOwner == 0x01)
				)
				{
					pickerNames = inst.GetAttrNames(Scope.Private);
				}
				else if (
					inst != null
					&& useInstancePicker
					&& (DataOwner == 0x02 || DataOwner == 0x05)
				)
				{
					pickerNames = inst.GetAttrNames(Scope.SemiGlobal);
				}
				else if (
					inst != null && DataOwner == 0x09
					|| DataOwner == 0x16
					|| DataOwner == 0x32
				) // Param
				{
					pickerNames = inst.GetTPRPnames(false);
				}
				else if (inst != null && DataOwner == 0x19) // Local
				{
					pickerNames = inst.GetTPRPnames(true);
				}
				else if (
					inst != null
					&& useInstancePicker
					&& DataOwner >= 0x29 && DataOwner <= 0x2F
				)
				{
					pickerNames = inst.GetArrayNames();
				}
				else if (BhavWiz.doidGStr[DataOwner] != null)
				{
					pickerNames = BhavWiz.readStr(
						(GS.BhavStr)BhavWiz.doidGStr[DataOwner]
					);
				}
			}
			#endregion


			if (pickerNames != null && pickerNames.Count > 0)
			{
				if (tbValue != null)
				{
					tbValue.TabStop = tbValue.Visible = false;
				}

				cbPicker.TabStop = cbPicker.Visible = true;
				cbPicker.Items.Clear();
				cbPicker.Items.AddRange(pickerNames.ToArray());
				cbPicker.SelectedIndex =
					(cbPicker.Items.Count > Value) ? Value : -1;
			}
			else
			{
				if (cbPicker != null)
				{
					cbPicker.TabStop = cbPicker.Visible = false;
				}

				if (tbValue != null)
				{
					tbValue.TabStop = tbValue.Visible = true;
				}
			}

			setInstanceLabel();

			internalchg = false;
		}

		private void setInstanceLabel()
		{
			if (lbInstance != null)
			{
				string s = "";
				if (inst != null)
				{
					List<string> labels = null;
					if (useFlagNames && DataOwner == 0x07 && flagsFor != null)
					{
						labels = BhavWiz.flagNames(flagsFor.DataOwner, flagsFor.Value);
						if (labels != null)
						{
							labels = new List<string>(labels);
							labels.Insert(
								0,
								"[0: " + Localization.GetString("invalid") + "]"
							);
						}
					}
					else if (DataOwner == 0x00 || DataOwner == 0x01)
					{
						labels = inst.GetAttrNames(Scope.Private);
					}
					else if (DataOwner == 0x02 || DataOwner == 0x05)
					{
						labels = inst.GetAttrNames(Scope.SemiGlobal);
					}
					else if (
						DataOwner == 0x09
						|| DataOwner == 0x16
						|| DataOwner == 0x32
					) // Param
					{
						labels = inst.GetTPRPnames(false);
					}
					else if (DataOwner == 0x19) // Local
					{
						labels = inst.GetTPRPnames(true);
					}
					else if (DataOwner >= 0x29 && DataOwner <= 0x2F)
					{
						labels = inst.GetArrayNames();
					}
					else if (BhavWiz.doidGStr[DataOwner] != null)
					{
						labels = BhavWiz.readStr(
							(GS.BhavStr)BhavWiz.doidGStr[DataOwner]
						);
					}

					if (labels != null)
					{
						if (Value < labels.Count)
						{
							s = cbDataOwner.Text + ": " + labels[Value];
						}
					}
					else if (DataOwner == 0x1a)
					{
						ushort[] bcon = BhavWiz.ExpandBCON(Value, false);
						s = inst.readBcon(bcon[0], bcon[1], false, true);
					}
				}
				lbInstance.Text = s;
			}
		}

		private static int[] decBitToDigits = new int[]
		{
			1,
			1,
			1,
			2,
			2,
			2,
			3,
			3,
			3,
			4,
			4,
			4,
			4,
			5,
			5,
			5,
		};

		private void setTextBoxLength()
		{
			if (tbValue != null)
			{
				tbValue.MaxLength = Convert.ToInt32(
					(DataOwner == 0x1a) ? 13
					: (DataOwner == 0x2f) ? 15
					: isDecimal ? 1 + decBitToDigits[bitsInValue - 1]
					: (use0xPrefix ? 2 : 0) + ((bitsInValue - 1) / 4) + 1
				);
			}
		}

		public BhavWiz Instruction
		{
			get => inst;
			set
			{
				if (inst != value)
				{
					inst = value;
					SetDataOwner();
				}
			}
		}

		private int bitsInValue = 16;
		public bool ValueIsByte
		{
			get => bitsInValue == 8;
			set
			{
				if (bitsInValue == 8 != value)
				{
					bitsInValue = value ? 8 : 16;
					setTextBoxLength();
					//setConstLabel();
					internalchg = true;
					if (tbValue != null)
					{
						tbValue.Text = tbValueConverter(Value);
					}
					internalchg = false;
				}
			}
		}

		private void SetValue(ushort i)
		{
			if (Value != i)
			{
				Value = i;
				setInstanceLabel();
				OnDataOwnerControlChanged(this, new EventArgs());
			}
		}

		private bool internalchg = false;
		private BhavWiz inst;

		private bool use0xPrefix = true;
		public bool Use0xPrefix
		{
			get => use0xPrefix;
			set
			{
				if (use0xPrefix != value)
				{
					use0xPrefix = value;
					setTextBoxLength();
					//setConstLabel();
					internalchg = true;
					if (tbValue != null)
					{
						tbValue.Text = tbValueConverter(Value);
					}
					internalchg = false;
				}
			}
		}

		private bool isDecimal = false;
		public bool Decimal
		{
			get => isDecimal;
			set
			{
				if (isDecimal != value)
				{
					isDecimal = value;
					setTextBoxLength();
					//setConstLabel();
					internalchg = true;
					if (tbValue != null)
					{
						tbValue.Text = tbValueConverter(Value);
					}
					internalchg = false;
				}
			}
		}

		private bool useInstancePicker = true;
		public bool UseInstancePicker
		{
			get => useInstancePicker;
			set
			{
				if (useInstancePicker != value)
				{
					useInstancePicker = value;
					SetDataOwner();
				}
			}
		}

		private bool useFlagNames = false;
		public bool UseFlagNames
		{
			get => useFlagNames;
			set
			{
				if (useFlagNames != value)
				{
					useFlagNames = value;
					SetDataOwner();
				}
			}
		}

		private IDataOwner flagsFor = null;
		public IDataOwner FlagsFor
		{
			get => flagsFor;
			set
			{
				if (flagsFor != value)
				{
					if (flagsFor != null)
					{
						flagsFor.DataOwnerControlChanged -= new EventHandler(
							value_DataOwnerControlChanged
						);
					}

					flagsFor = value;
					flagsFor.DataOwnerControlChanged += new EventHandler(
						value_DataOwnerControlChanged
					);
				}
			}
		}

		void value_DataOwnerControlChanged(object sender, EventArgs e)
		{
			SetDataOwner();
		}
	}
}
