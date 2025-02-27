/***************************************************************************
 *   Copyright (C) 2007 by Peter L Jones                                   *
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
using System.Windows.Forms;

using SimPe.PackedFiles.Wrapper;

namespace pjse.BhavOperandWizards.Wiz0x0076
{
	/// <summary>
	/// Zusammenfassung f�r BhavInstruction.
	/// </summary>
	internal class UI : Form, iBhavOperandWizForm
	{
		#region Form variables

		internal Panel pnWiz0x0076;
		private RadioButton rb1StackObj;
		private RadioButton rb1My;
		private TableLayoutPanel tableLayoutPanel1;
		private Label lbOp2;
		private Panel pnOp1;
		private Label lbConst1;
		private ComboBox cbPicker1;
		private TextBox tbval1;
		private ComboBox cbDataOwner1;
		private Label lbOp1;
		private Panel pnOp2;
		private Label lbConst2;
		private ComboBox cbPicker2;
		private TextBox tbval2;
		private ComboBox cbDataOwner2;
		private Panel panel1;
		private CheckBox ckbAttrPicker;
		private CheckBox ckbDecimal;
		private Panel pnArray;
		private Panel panel2;
		private Label label1;
		private Label label3;
		private ComboBox cbOperation;
		private ComboBox cbObjectArray;
		private TextBox tbObjectArray;
		private Panel panel3;

		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public UI()
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

			inst = null;
		}

		private Instruction inst = null;
		private DataOwnerControl doidArray = null;
		private DataOwnerControl doidValue = null;
		private DataOwnerControl doidIndex = null;

		static string sIndex = Localization.GetString("Index");
		static string sValue = Localization.GetString("Value");

		private bool[] d1enable =
		{
			false,
			true,
			true,
			true,
			true,
			true,
			true,
			false,
			false,
			false,
			true,
			true,
			false,
			false,
		};
		private bool[] d1IndexValue =
		{
			false,
			false,
			false,
			false,
			false,
			false,
			false,
			false,
			false,
			false,
			false,
			true,
			false,
			false,
		};
		private bool[] d2enable =
		{
			false,
			false,
			false,
			false,
			false,
			false,
			true,
			false,
			false,
			true,
			true,
			true,
			false,
			false,
		};
		private bool[] d2IndexValue =
		{
			true,
			true,
			true,
			true,
			true,
			true,
			true,
			true,
			true,
			true,
			true,
			true,
			true,
			true,
		};

		private void setOperation(int val)
		{
			cbOperation.SelectedIndex = (val < cbOperation.Items.Count) ? val : -1;

			pnOp1.Enabled = (val < d1enable.Length && d1enable[val]);
			lbOp1.Text = pnOp1.Enabled ? (d1IndexValue[val] ? sIndex : sValue) : "";

			pnOp2.Enabled = (val < d2enable.Length && d2enable[val]);
			lbOp2.Text = pnOp2.Enabled ? (d2IndexValue[val] ? sIndex : sValue) : "";
		}

		#region iBhavOperandWizForm
		public Panel WizPanel => pnWiz0x0076;

		public void Execute(Instruction inst)
		{
			this.inst = inst;

			byte[] o = new byte[16];
			((byte[])inst.Operands).CopyTo(o, 0);
			((byte[])inst.Reserved1).CopyTo(o, 8);

			setOperation(o[0x01]);
			// See discussion around whether this is a bit vs boolean:
			// http://simlogical.com/SMF/index.php?topic=917.msg6641#msg6641
			rb1StackObj.Checked = !(rb1My.Checked = (o[0x2] == 0));

			doidArray = new DataOwnerControl(
				inst,
				null,
				cbObjectArray,
				tbObjectArray,
				ckbDecimal,
				ckbAttrPicker,
				null,
				0x29,
				BhavWiz.ToShort(o[0x03], o[0x04])
			);
			doidValue = new DataOwnerControl(
				inst,
				cbDataOwner1,
				cbPicker1,
				tbval1,
				ckbDecimal,
				ckbAttrPicker,
				lbConst1,
				o[0x05],
				BhavWiz.ToShort(o[0x06], o[0x07])
			);
			doidIndex = new DataOwnerControl(
				inst,
				cbDataOwner2,
				cbPicker2,
				tbval2,
				ckbDecimal,
				ckbAttrPicker,
				lbConst2,
				o[0x08],
				BhavWiz.ToShort(o[0x09], o[0x0a])
			);
		}

		public Instruction Write(Instruction inst)
		{
			if (inst != null)
			{
				wrappedByteArray ops1 = inst.Operands;
				wrappedByteArray ops2 = inst.Reserved1;

				if (cbOperation.SelectedIndex >= 0)
				{
					ops1[0x01] = (byte)cbOperation.SelectedIndex;
				}

				ops1[0x02] = (byte)(rb1My.Checked ? 0x00 : 0x02); // Not sure why "0x02" at the game treats as 0 / !0

				BhavWiz.FromShort(ref ops1, 3, doidArray.Value);

				ops1[0x05] = doidValue.DataOwner;
				BhavWiz.FromShort(ref ops1, 6, doidValue.Value);

				ops2[0x00] = doidIndex.DataOwner;
				BhavWiz.FromShort(ref ops2, 1, doidIndex.Value);
			}
			return inst;
		}

		#endregion

		#region Vom Windows Form-Designer generierter Code
		/// <summary>
		/// Erforderliche Methode f�r die Designerunterst�tzung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor ge�ndert werden.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(typeof(UI));
			pnWiz0x0076 = new Panel();
			tableLayoutPanel1 = new TableLayoutPanel();
			pnOp2 = new Panel();
			lbConst2 = new Label();
			cbPicker2 = new ComboBox();
			tbval2 = new TextBox();
			cbDataOwner2 = new ComboBox();
			lbOp2 = new Label();
			pnOp1 = new Panel();
			lbConst1 = new Label();
			cbPicker1 = new ComboBox();
			tbval1 = new TextBox();
			cbDataOwner1 = new ComboBox();
			lbOp1 = new Label();
			panel1 = new Panel();
			ckbAttrPicker = new CheckBox();
			ckbDecimal = new CheckBox();
			rb1StackObj = new RadioButton();
			rb1My = new RadioButton();
			tbObjectArray = new TextBox();
			cbObjectArray = new ComboBox();
			cbOperation = new ComboBox();
			panel2 = new Panel();
			label1 = new Label();
			pnArray = new Panel();
			label3 = new Label();
			panel3 = new Panel();
			pnWiz0x0076.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			pnOp2.SuspendLayout();
			pnOp1.SuspendLayout();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			pnArray.SuspendLayout();
			SuspendLayout();
			//
			// pnWiz0x0076
			//
			resources.ApplyResources(pnWiz0x0076, "pnWiz0x0076");
			pnWiz0x0076.Controls.Add(tableLayoutPanel1);
			pnWiz0x0076.Controls.Add(rb1StackObj);
			pnWiz0x0076.Controls.Add(rb1My);
			pnWiz0x0076.Name = "pnWiz0x0076";
			//
			// tableLayoutPanel1
			//
			resources.ApplyResources(tableLayoutPanel1, "tableLayoutPanel1");
			tableLayoutPanel1.Controls.Add(pnArray, 1, 0);
			tableLayoutPanel1.Controls.Add(pnOp2, 1, 2);
			tableLayoutPanel1.Controls.Add(lbOp2, 0, 2);
			tableLayoutPanel1.Controls.Add(pnOp1, 1, 1);
			tableLayoutPanel1.Controls.Add(lbOp1, 0, 1);
			tableLayoutPanel1.Controls.Add(panel1, 1, 3);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			//
			// pnOp2
			//
			resources.ApplyResources(pnOp2, "pnOp2");
			pnOp2.Controls.Add(lbConst2);
			pnOp2.Controls.Add(cbPicker2);
			pnOp2.Controls.Add(tbval2);
			pnOp2.Controls.Add(cbDataOwner2);
			pnOp2.Name = "pnOp2";
			//
			// lbConst2
			//
			resources.ApplyResources(lbConst2, "lbConst2");
			lbConst2.Name = "lbConst2";
			//
			// cbPicker2
			//
			cbPicker2.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbPicker2.DropDownWidth = 384;
			resources.ApplyResources(cbPicker2, "cbPicker2");
			cbPicker2.Name = "cbPicker2";
			//
			// tbval2
			//
			resources.ApplyResources(tbval2, "tbval2");
			tbval2.Name = "tbval2";
			//
			// cbDataOwner2
			//
			cbDataOwner2.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbDataOwner2.DropDownWidth = 384;
			resources.ApplyResources(cbDataOwner2, "cbDataOwner2");
			cbDataOwner2.Name = "cbDataOwner2";
			//
			// lbOp2
			//
			resources.ApplyResources(lbOp2, "lbOp2");
			lbOp2.Name = "lbOp2";
			//
			// pnOp1
			//
			resources.ApplyResources(pnOp1, "pnOp1");
			pnOp1.Controls.Add(lbConst1);
			pnOp1.Controls.Add(cbPicker1);
			pnOp1.Controls.Add(tbval1);
			pnOp1.Controls.Add(cbDataOwner1);
			pnOp1.Name = "pnOp1";
			//
			// lbConst1
			//
			resources.ApplyResources(lbConst1, "lbConst1");
			lbConst1.Name = "lbConst1";
			//
			// cbPicker1
			//
			cbPicker1.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbPicker1.DropDownWidth = 384;
			resources.ApplyResources(cbPicker1, "cbPicker1");
			cbPicker1.Name = "cbPicker1";
			//
			// tbval1
			//
			resources.ApplyResources(tbval1, "tbval1");
			tbval1.Name = "tbval1";
			//
			// cbDataOwner1
			//
			cbDataOwner1.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbDataOwner1.DropDownWidth = 384;
			resources.ApplyResources(cbDataOwner1, "cbDataOwner1");
			cbDataOwner1.Name = "cbDataOwner1";
			//
			// lbOp1
			//
			resources.ApplyResources(lbOp1, "lbOp1");
			lbOp1.Name = "lbOp1";
			//
			// panel1
			//
			resources.ApplyResources(panel1, "panel1");
			panel1.Controls.Add(ckbAttrPicker);
			panel1.Controls.Add(ckbDecimal);
			panel1.Name = "panel1";
			//
			// ckbAttrPicker
			//
			resources.ApplyResources(ckbAttrPicker, "ckbAttrPicker");
			ckbAttrPicker.Name = "ckbAttrPicker";
			//
			// ckbDecimal
			//
			resources.ApplyResources(ckbDecimal, "ckbDecimal");
			ckbDecimal.Name = "ckbDecimal";
			//
			// rb1StackObj
			//
			resources.ApplyResources(rb1StackObj, "rb1StackObj");
			rb1StackObj.Name = "rb1StackObj";
			rb1StackObj.TabStop = true;
			rb1StackObj.UseVisualStyleBackColor = true;
			//
			// rb1My
			//
			resources.ApplyResources(rb1My, "rb1My");
			rb1My.Name = "rb1My";
			rb1My.TabStop = true;
			rb1My.UseVisualStyleBackColor = true;
			//
			// tbObjectArray
			//
			resources.ApplyResources(tbObjectArray, "tbObjectArray");
			tbObjectArray.Name = "tbObjectArray";
			//
			// cbObjectArray
			//
			cbObjectArray.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbObjectArray.DropDownWidth = 384;
			resources.ApplyResources(cbObjectArray, "cbObjectArray");
			cbObjectArray.Name = "cbObjectArray";
			//
			// cbOperation
			//
			cbOperation.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbOperation.DropDownWidth = 462;
			cbOperation.Items.AddRange(
				new object[]
				{
					resources.GetString("cbOperation.Items"),
					resources.GetString("cbOperation.Items1"),
					resources.GetString("cbOperation.Items2"),
					resources.GetString("cbOperation.Items3"),
					resources.GetString("cbOperation.Items4"),
					resources.GetString("cbOperation.Items5"),
					resources.GetString("cbOperation.Items6"),
					resources.GetString("cbOperation.Items7"),
					resources.GetString("cbOperation.Items8"),
					resources.GetString("cbOperation.Items9"),
					resources.GetString("cbOperation.Items10"),
					resources.GetString("cbOperation.Items11"),
					resources.GetString("cbOperation.Items12"),
					resources.GetString("cbOperation.Items13"),
				}
			);
			resources.ApplyResources(cbOperation, "cbOperation");
			cbOperation.Name = "cbOperation";
			cbOperation.SelectedIndexChanged += new EventHandler(
				cbOperation_SelectedIndexChanged
			);
			//
			// panel2
			//
			resources.ApplyResources(panel2, "panel2");
			panel2.Controls.Add(label1);
			panel2.Controls.Add(label3);
			panel2.Name = "panel2";
			//
			// label1
			//
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			//
			// pnArray
			//
			resources.ApplyResources(pnArray, "pnArray");
			pnArray.Controls.Add(panel3);
			pnArray.Controls.Add(panel2);
			pnArray.Controls.Add(cbOperation);
			pnArray.Controls.Add(cbObjectArray);
			pnArray.Controls.Add(tbObjectArray);
			pnArray.Name = "pnArray";
			//
			// label3
			//
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			//
			// panel3
			//
			panel3.BorderStyle = BorderStyle.FixedSingle;
			resources.ApplyResources(panel3, "panel3");
			panel3.Name = "panel3";
			//
			// UI
			//
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(pnWiz0x0076);
			Name = "UI";
			pnWiz0x0076.ResumeLayout(false);
			pnWiz0x0076.PerformLayout();
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			pnOp2.ResumeLayout(false);
			pnOp2.PerformLayout();
			pnOp1.ResumeLayout(false);
			pnOp1.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			pnArray.ResumeLayout(false);
			pnArray.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion

		private void cbOperation_SelectedIndexChanged(object sender, EventArgs e)
		{
			setOperation(cbOperation.SelectedIndex);
		}
	}
}

namespace pjse.BhavOperandWizards
{
	public class BhavOperandWiz0x0076 : ABhavOperandWiz
	{
		public BhavOperandWiz0x0076(Instruction i)
			: base(i)
		{
			myForm = new Wiz0x0076.UI();
		}

		#region IDisposable Members
		public override void Dispose()
		{
			if (myForm != null)
			{
				myForm = null;
			}
		}
		#endregion
	}
}
