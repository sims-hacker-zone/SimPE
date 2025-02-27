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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using SimPe.PackedFiles.Wrapper;

namespace pjse
{
	/// <summary>
	/// Container for bhavPrimWizPanel from BhavOperandWizProvider
	/// </summary>
	public class BhavOperandWiz : System.Windows.Forms.Form
	{
		#region Form variables

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button OK;
		private System.Windows.Forms.Button Cancel;

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
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		public Instruction Execute(BhavWiz i, int wizType)
		{
			pjse.ABhavOperandWiz wiz = null;
			switch (wizType)
			{
				case 0:
					wiz = new pjse.BhavOperandWizards.BhavOperandWizRaw(i);
					break;
				case 1:
					wiz = i.Wizard();
					break;
				default:
					wiz = new pjse.BhavOperandWizards.BhavOperandWizDefault(i);
					break;
			}
			if (wiz == null)
				return null;

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
			int footHeight = this.Height - this.panel1.Bottom + 8;
			this.Width = pn.Width + 8;
			this.Height = pn.Height + footHeight;
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.OK = new System.Windows.Forms.Button();
			this.Cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			//
			// panel1
			//
			resources.ApplyResources(this.panel1, "panel1");
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Name = "panel1";
			//
			// OK
			//
			resources.ApplyResources(this.OK, "OK");
			this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OK.Name = "OK";
			//
			// Cancel
			//
			resources.ApplyResources(this.Cancel, "Cancel");
			this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel.Name = "Cancel";
			//
			// BhavOperandWiz
			//
			this.AcceptButton = this.OK;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.CancelButton = this.Cancel;
			this.Controls.Add(this.OK);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.Cancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "BhavOperandWiz";
			this.ResumeLayout(false);
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
		private void cbDataOwner_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (internalchg)
				return;
			if (cbDataOwner.SelectedIndex != -1)
				SetDataOwner();
		}

		private void cbPicker_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (internalchg)
				return;
			if (cbPicker.SelectedIndex != -1)
			{
				SetValue((ushort)cbPicker.SelectedIndex);
				tbValue.Text = tbValueConverter(instance);
			}
		}

		private void tbValue_Enter(object sender, System.EventArgs e)
		{
			((TextBox)sender).SelectAll();
		}

		private void tbValue_TextChanged(object sender, System.EventArgs ev)
		{
			if (internalchg)
				return;
			if (!tbValue_IsValid((TextBox)sender))
				return;
			SetValue(tbValueConverter((TextBox)sender));
		}

		private void tbValue_Validating(
			object sender,
			System.ComponentModel.CancelEventArgs e
		)
		{
			if (tbValue_IsValid((TextBox)sender))
				return;
			e.Cancel = true;
			tbValue_Validated(sender, null);
		}

		private void tbValue_Validated(object sender, System.EventArgs e)
		{
			bool origstate = internalchg;
			internalchg = true;
			((TextBox)sender).Text = tbValueConverter(instance);
			internalchg = origstate;
		}

		private void ckbDecimal_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ckbDecimal.Visible)
				pjse.Settings.PJSE.DecimalDOValue = this.ckbDecimal.Checked;
		}

		private void ckbUseAttrPicker_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ckbUseInstancePicker.Visible)
				pjse.Settings.PJSE.InstancePickerAsText =
					this.ckbUseInstancePicker.Checked;
		}

		#endregion

		#region Form validation
		private bool tbValue_IsValid(TextBox tb)
		{
			try
			{
				ushort v = tbValueConverter(tb);
				return (v < 1 << bitsInValue);
			}
			catch
			{
				return false;
			}
		}

		private string tbValueConverter(ushort v)
		{
			if (dataOwner == 0x1a)
				return pjse.BhavWiz.ExpandBCONtoString(v, false);
			else if (dataOwner == 0x2f)
				return pjse.BhavWiz.ExpandBCONtoString(v, true);
			else if (isDecimal)
				return ((short)v).ToString();

			String s = SimPe.Helper.HexString(v);
			int i = (bitsInValue + 3) / 4;
			s = s.Substring(s.Length - i);

			return (use0xPrefix ? "0x" : "") + s;
		}

		private ushort tbValueConverter(TextBox sender)
		{
			if (dataOwner == 0x1a)
				return pjse.BhavWiz.StringtoExpandBCON(sender.Text, false);
			else if (dataOwner == 0x2f)
				return pjse.BhavWiz.StringtoExpandBCON(sender.Text, true);
			else if (isDecimal)
				return (ushort)Convert.ToInt16(sender.Text, 10);
			else
				return Convert.ToUInt16(sender.Text, 16);
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
			this.Dispose();
			this.inst = inst;
			this.cbDataOwner = cbDataOwner;
			this.cbPicker = cbPicker;
			this.tbValue = tbValue;
			this.ckbDecimal = ckbDecimal;
			this.ckbUseInstancePicker = ckbUseInstancePicker;
			this.lbInstance = lbInstance;
			this.dataOwner = dataOwner;
			this.instance = instance;

			this.flagsFor = null;

			internalchg = true;
			if (this.cbDataOwner != null)
			{
				this.cbDataOwner.Items.Clear();
				this.cbDataOwner.Items.AddRange(
					BhavWiz.readStr(GS.BhavStr.DataOwners).ToArray()
				);
				if (cbDataOwner.Items.Count > dataOwner)
					cbDataOwner.SelectedIndex = dataOwner;
				this.cbDataOwner.SelectedIndexChanged += new System.EventHandler(
					this.cbDataOwner_SelectedIndexChanged
				);
			}

			if (this.cbPicker != null)
				this.cbPicker.SelectedIndexChanged += new System.EventHandler(
					this.cbPicker_SelectedIndexChanged
				);

			if (this.tbValue != null)
			{
				this.tbValue.Text = this.tbValueConverter(instance);
				this.tbValue.Validating += new System.ComponentModel.CancelEventHandler(
					this.tbValue_Validating
				);
				this.tbValue.Validated += new System.EventHandler(
					this.tbValue_Validated
				);
				this.tbValue.TextChanged += new System.EventHandler(
					this.tbValue_TextChanged
				);
				this.tbValue.Enter += new System.EventHandler(this.tbValue_Enter);
			}

			pjse.Settings.PJSE.DecimalDOValueChanged += new EventHandler(
				PJSE_DecimalDOValueChanged
			);
			Decimal = pjse.Settings.PJSE.DecimalDOValue;
			if (this.ckbDecimal != null)
			{
				this.ckbDecimal.Checked = Decimal;
				this.ckbDecimal.CheckedChanged += new System.EventHandler(
					this.ckbDecimal_CheckedChanged
				);
			}

			pjse.Settings.PJSE.InstancePickerAsTextChanged += new EventHandler(
				PJSE_InstancePickerAsTextChanged
			);
			UseInstancePicker = pjse.Settings.PJSE.InstancePickerAsText;
			if (this.ckbUseInstancePicker != null)
			{
				this.ckbUseInstancePicker.Checked = UseInstancePicker;
				this.ckbUseInstancePicker.CheckedChanged += new System.EventHandler(
					this.ckbUseAttrPicker_CheckedChanged
				);
			}

			internalchg = false;

			SetDataOwner();

			setTextBoxLength();
			setInstanceLabel();
		}

		void PJSE_DecimalDOValueChanged(object sender, EventArgs e)
		{
			Decimal = pjse.Settings.PJSE.DecimalDOValue;
			if (ckbDecimal != null && this.ckbDecimal.Checked != Decimal)
				this.ckbDecimal.Checked = Decimal;
		}

		void PJSE_InstancePickerAsTextChanged(object sender, EventArgs e)
		{
			UseInstancePicker = pjse.Settings.PJSE.InstancePickerAsText;
			if (
				ckbUseInstancePicker != null
				&& this.ckbUseInstancePicker.Checked != UseInstancePicker
			)
				this.ckbUseInstancePicker.Checked = UseInstancePicker;
		}

		#region IDisposable Members

		public void Dispose()
		{
			if (this.cbDataOwner != null)
				this.cbDataOwner.SelectedIndexChanged -= new System.EventHandler(
					this.cbDataOwner_SelectedIndexChanged
				);
			if (this.cbPicker != null)
				this.cbPicker.SelectedIndexChanged -= new System.EventHandler(
					this.cbPicker_SelectedIndexChanged
				);
			if (this.tbValue != null)
				this.tbValue.TextChanged -= new System.EventHandler(
					this.tbValue_TextChanged
				);
			if (this.ckbDecimal != null)
				this.ckbDecimal.CheckedChanged -= new EventHandler(
					this.ckbDecimal_CheckedChanged
				);
			if (this.ckbUseInstancePicker != null)
				this.ckbUseInstancePicker.CheckedChanged -= new EventHandler(
					this.ckbUseAttrPicker_CheckedChanged
				);
			this.inst = null;
			this.cbDataOwner = null;
			this.cbPicker = null;
			this.tbValue = null;
			this.ckbDecimal = null;
			this.ckbUseInstancePicker = null;
			this.lbInstance = null;
			this.flagsFor = null;
		}

		#endregion

		#region IDataOwner Members

		private byte dataOwner = 0;
		private ushort instance = 0;
		public byte DataOwner => dataOwner;

		public ushort Value => instance;

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
				return;

			internalchg = true;

			if (cbDataOwner != null && cbDataOwner.SelectedIndex != dataOwner)
			{
				dataOwner = (byte)cbDataOwner.SelectedIndex;
				setTextBoxLength();
				tbValue.Text = tbValueConverter(instance);
				OnDataOwnerControlChanged(this, new EventArgs());
			}

			#region pickerNames
			List<String> pickerNames = null;
			if (useInstancePicker && cbPicker != null)
			{
				if (useFlagNames && dataOwner == 0x07 && flagsFor != null)
				{
					pickerNames = BhavWiz.flagNames(flagsFor.DataOwner, flagsFor.Value);
					if (pickerNames != null)
					{
						pickerNames = new List<string>(pickerNames);
						pickerNames.Insert(
							0,
							"[0: " + pjse.Localization.GetString("invalid") + "]"
						);
					}
				}
				else if (
					inst != null
					&& useInstancePicker
					&& (dataOwner == 0x00 || dataOwner == 0x01)
				)
				{
					pickerNames = inst.GetAttrNames(Scope.Private);
				}
				else if (
					inst != null
					&& useInstancePicker
					&& (dataOwner == 0x02 || dataOwner == 0x05)
				)
				{
					pickerNames = inst.GetAttrNames(Scope.SemiGlobal);
				}
				else if (
					inst != null && dataOwner == 0x09
					|| dataOwner == 0x16
					|| dataOwner == 0x32
				) // Param
				{
					pickerNames = inst.GetTPRPnames(false);
				}
				else if (inst != null && dataOwner == 0x19) // Local
				{
					pickerNames = inst.GetTPRPnames(true);
				}
				else if (
					inst != null
					&& useInstancePicker
					&& (dataOwner >= 0x29 && dataOwner <= 0x2F)
				)
				{
					pickerNames = inst.GetArrayNames();
				}
				else if (BhavWiz.doidGStr[dataOwner] != null)
				{
					pickerNames = BhavWiz.readStr(
						(GS.BhavStr)BhavWiz.doidGStr[dataOwner]
					);
				}
			}
			#endregion


			if (pickerNames != null && pickerNames.Count > 0)
			{
				if (tbValue != null)
					tbValue.TabStop = tbValue.Visible = false;
				cbPicker.TabStop = cbPicker.Visible = true;
				cbPicker.Items.Clear();
				cbPicker.Items.AddRange(pickerNames.ToArray());
				cbPicker.SelectedIndex =
					(cbPicker.Items.Count > instance) ? instance : -1;
			}
			else
			{
				if (cbPicker != null)
					cbPicker.TabStop = cbPicker.Visible = false;
				if (tbValue != null)
					tbValue.TabStop = tbValue.Visible = true;
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
					if (useFlagNames && dataOwner == 0x07 && flagsFor != null)
					{
						labels = BhavWiz.flagNames(flagsFor.DataOwner, flagsFor.Value);
						if (labels != null)
						{
							labels = new List<string>(labels);
							labels.Insert(
								0,
								"[0: " + pjse.Localization.GetString("invalid") + "]"
							);
						}
					}
					else if (dataOwner == 0x00 || dataOwner == 0x01)
					{
						labels = inst.GetAttrNames(Scope.Private);
					}
					else if (dataOwner == 0x02 || dataOwner == 0x05)
					{
						labels = inst.GetAttrNames(Scope.SemiGlobal);
					}
					else if (
						dataOwner == 0x09
						|| dataOwner == 0x16
						|| dataOwner == 0x32
					) // Param
					{
						labels = inst.GetTPRPnames(false);
					}
					else if (dataOwner == 0x19) // Local
					{
						labels = inst.GetTPRPnames(true);
					}
					else if (dataOwner >= 0x29 && dataOwner <= 0x2F)
					{
						labels = inst.GetArrayNames();
					}
					else if (BhavWiz.doidGStr[dataOwner] != null)
					{
						labels = BhavWiz.readStr(
							(GS.BhavStr)BhavWiz.doidGStr[dataOwner]
						);
					}

					if (labels != null)
					{
						if (instance < labels.Count)
							s = cbDataOwner.Text + ": " + labels[instance];
					}
					else if (dataOwner == 0x1a)
					{
						ushort[] bcon = BhavWiz.ExpandBCON(instance, false);
						s = ((BhavWiz)inst).readBcon(bcon[0], bcon[1], false, true);
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
			if (this.tbValue != null)
				tbValue.MaxLength = Convert.ToInt32(
					(this.dataOwner == 0x1a) ? 13
					: (this.dataOwner == 0x2f) ? 15
					: isDecimal ? 1 + decBitToDigits[bitsInValue - 1]
					: (use0xPrefix ? 2 : 0) + ((bitsInValue - 1) / 4) + 1
				);
		}

		public BhavWiz Instruction
		{
			get
			{
				return this.inst;
			}
			set
			{
				if (this.inst != value)
				{
					this.inst = value;
					SetDataOwner();
				}
			}
		}

		private int bitsInValue = 16;
		public bool ValueIsByte
		{
			get
			{
				return bitsInValue == 8;
			}
			set
			{
				if ((bitsInValue == 8) != value)
				{
					bitsInValue = value ? 8 : 16;
					setTextBoxLength();
					//setConstLabel();
					internalchg = true;
					if (tbValue != null)
					{
						tbValue.Text = tbValueConverter(instance);
					}
					internalchg = false;
				}
			}
		}

		private void SetValue(ushort i)
		{
			if (instance != i)
			{
				instance = i;
				setInstanceLabel();
				OnDataOwnerControlChanged(this, new EventArgs());
			}
		}

		private bool internalchg = false;
		private BhavWiz inst;

		private bool use0xPrefix = true;
		public bool Use0xPrefix
		{
			get
			{
				return use0xPrefix;
			}
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
						tbValue.Text = tbValueConverter(instance);
					}
					internalchg = false;
				}
			}
		}

		private bool isDecimal = false;
		public bool Decimal
		{
			get
			{
				return this.isDecimal;
			}
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
						tbValue.Text = tbValueConverter(instance);
					}
					internalchg = false;
				}
			}
		}

		private bool useInstancePicker = true;
		public bool UseInstancePicker
		{
			get
			{
				return this.useInstancePicker;
			}
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
			get
			{
				return this.useFlagNames;
			}
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
			get
			{
				return flagsFor;
			}
			set
			{
				if (flagsFor != value)
				{
					if (flagsFor != null)
						flagsFor.DataOwnerControlChanged -= new EventHandler(
							value_DataOwnerControlChanged
						);
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
