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
		public Panel WizPanel => this.pnWiz0x0076;

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
				this.cbObjectArray,
				this.tbObjectArray,
				this.ckbDecimal,
				this.ckbAttrPicker,
				null,
				0x29,
				BhavWiz.ToShort(o[0x03], o[0x04])
			);
			doidValue = new DataOwnerControl(
				inst,
				this.cbDataOwner1,
				this.cbPicker1,
				this.tbval1,
				this.ckbDecimal,
				this.ckbAttrPicker,
				this.lbConst1,
				o[0x05],
				BhavWiz.ToShort(o[0x06], o[0x07])
			);
			doidIndex = new DataOwnerControl(
				inst,
				this.cbDataOwner2,
				this.cbPicker2,
				this.tbval2,
				this.ckbDecimal,
				this.ckbAttrPicker,
				this.lbConst2,
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
			this.pnWiz0x0076 = new Panel();
			this.tableLayoutPanel1 = new TableLayoutPanel();
			this.pnOp2 = new Panel();
			this.lbConst2 = new Label();
			this.cbPicker2 = new ComboBox();
			this.tbval2 = new TextBox();
			this.cbDataOwner2 = new ComboBox();
			this.lbOp2 = new Label();
			this.pnOp1 = new Panel();
			this.lbConst1 = new Label();
			this.cbPicker1 = new ComboBox();
			this.tbval1 = new TextBox();
			this.cbDataOwner1 = new ComboBox();
			this.lbOp1 = new Label();
			this.panel1 = new Panel();
			this.ckbAttrPicker = new CheckBox();
			this.ckbDecimal = new CheckBox();
			this.rb1StackObj = new RadioButton();
			this.rb1My = new RadioButton();
			this.tbObjectArray = new TextBox();
			this.cbObjectArray = new ComboBox();
			this.cbOperation = new ComboBox();
			this.panel2 = new Panel();
			this.label1 = new Label();
			this.pnArray = new Panel();
			this.label3 = new Label();
			this.panel3 = new Panel();
			this.pnWiz0x0076.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.pnOp2.SuspendLayout();
			this.pnOp1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.pnArray.SuspendLayout();
			this.SuspendLayout();
			//
			// pnWiz0x0076
			//
			resources.ApplyResources(this.pnWiz0x0076, "pnWiz0x0076");
			this.pnWiz0x0076.Controls.Add(this.tableLayoutPanel1);
			this.pnWiz0x0076.Controls.Add(this.rb1StackObj);
			this.pnWiz0x0076.Controls.Add(this.rb1My);
			this.pnWiz0x0076.Name = "pnWiz0x0076";
			//
			// tableLayoutPanel1
			//
			resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
			this.tableLayoutPanel1.Controls.Add(this.pnArray, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.pnOp2, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.lbOp2, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.pnOp1, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.lbOp1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 3);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			//
			// pnOp2
			//
			resources.ApplyResources(this.pnOp2, "pnOp2");
			this.pnOp2.Controls.Add(this.lbConst2);
			this.pnOp2.Controls.Add(this.cbPicker2);
			this.pnOp2.Controls.Add(this.tbval2);
			this.pnOp2.Controls.Add(this.cbDataOwner2);
			this.pnOp2.Name = "pnOp2";
			//
			// lbConst2
			//
			resources.ApplyResources(this.lbConst2, "lbConst2");
			this.lbConst2.Name = "lbConst2";
			//
			// cbPicker2
			//
			this.cbPicker2.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			this.cbPicker2.DropDownWidth = 384;
			resources.ApplyResources(this.cbPicker2, "cbPicker2");
			this.cbPicker2.Name = "cbPicker2";
			//
			// tbval2
			//
			resources.ApplyResources(this.tbval2, "tbval2");
			this.tbval2.Name = "tbval2";
			//
			// cbDataOwner2
			//
			this.cbDataOwner2.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			this.cbDataOwner2.DropDownWidth = 384;
			resources.ApplyResources(this.cbDataOwner2, "cbDataOwner2");
			this.cbDataOwner2.Name = "cbDataOwner2";
			//
			// lbOp2
			//
			resources.ApplyResources(this.lbOp2, "lbOp2");
			this.lbOp2.Name = "lbOp2";
			//
			// pnOp1
			//
			resources.ApplyResources(this.pnOp1, "pnOp1");
			this.pnOp1.Controls.Add(this.lbConst1);
			this.pnOp1.Controls.Add(this.cbPicker1);
			this.pnOp1.Controls.Add(this.tbval1);
			this.pnOp1.Controls.Add(this.cbDataOwner1);
			this.pnOp1.Name = "pnOp1";
			//
			// lbConst1
			//
			resources.ApplyResources(this.lbConst1, "lbConst1");
			this.lbConst1.Name = "lbConst1";
			//
			// cbPicker1
			//
			this.cbPicker1.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			this.cbPicker1.DropDownWidth = 384;
			resources.ApplyResources(this.cbPicker1, "cbPicker1");
			this.cbPicker1.Name = "cbPicker1";
			//
			// tbval1
			//
			resources.ApplyResources(this.tbval1, "tbval1");
			this.tbval1.Name = "tbval1";
			//
			// cbDataOwner1
			//
			this.cbDataOwner1.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			this.cbDataOwner1.DropDownWidth = 384;
			resources.ApplyResources(this.cbDataOwner1, "cbDataOwner1");
			this.cbDataOwner1.Name = "cbDataOwner1";
			//
			// lbOp1
			//
			resources.ApplyResources(this.lbOp1, "lbOp1");
			this.lbOp1.Name = "lbOp1";
			//
			// panel1
			//
			resources.ApplyResources(this.panel1, "panel1");
			this.panel1.Controls.Add(this.ckbAttrPicker);
			this.panel1.Controls.Add(this.ckbDecimal);
			this.panel1.Name = "panel1";
			//
			// ckbAttrPicker
			//
			resources.ApplyResources(this.ckbAttrPicker, "ckbAttrPicker");
			this.ckbAttrPicker.Name = "ckbAttrPicker";
			//
			// ckbDecimal
			//
			resources.ApplyResources(this.ckbDecimal, "ckbDecimal");
			this.ckbDecimal.Name = "ckbDecimal";
			//
			// rb1StackObj
			//
			resources.ApplyResources(this.rb1StackObj, "rb1StackObj");
			this.rb1StackObj.Name = "rb1StackObj";
			this.rb1StackObj.TabStop = true;
			this.rb1StackObj.UseVisualStyleBackColor = true;
			//
			// rb1My
			//
			resources.ApplyResources(this.rb1My, "rb1My");
			this.rb1My.Name = "rb1My";
			this.rb1My.TabStop = true;
			this.rb1My.UseVisualStyleBackColor = true;
			//
			// tbObjectArray
			//
			resources.ApplyResources(this.tbObjectArray, "tbObjectArray");
			this.tbObjectArray.Name = "tbObjectArray";
			//
			// cbObjectArray
			//
			this.cbObjectArray.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			this.cbObjectArray.DropDownWidth = 384;
			resources.ApplyResources(this.cbObjectArray, "cbObjectArray");
			this.cbObjectArray.Name = "cbObjectArray";
			//
			// cbOperation
			//
			this.cbOperation.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			this.cbOperation.DropDownWidth = 462;
			this.cbOperation.Items.AddRange(
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
			resources.ApplyResources(this.cbOperation, "cbOperation");
			this.cbOperation.Name = "cbOperation";
			this.cbOperation.SelectedIndexChanged += new EventHandler(
				this.cbOperation_SelectedIndexChanged
			);
			//
			// panel2
			//
			resources.ApplyResources(this.panel2, "panel2");
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Name = "panel2";
			//
			// label1
			//
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			//
			// pnArray
			//
			resources.ApplyResources(this.pnArray, "pnArray");
			this.pnArray.Controls.Add(this.panel3);
			this.pnArray.Controls.Add(this.panel2);
			this.pnArray.Controls.Add(this.cbOperation);
			this.pnArray.Controls.Add(this.cbObjectArray);
			this.pnArray.Controls.Add(this.tbObjectArray);
			this.pnArray.Name = "pnArray";
			//
			// label3
			//
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			//
			// panel3
			//
			this.panel3.BorderStyle = BorderStyle.FixedSingle;
			resources.ApplyResources(this.panel3, "panel3");
			this.panel3.Name = "panel3";
			//
			// UI
			//
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = AutoScaleMode.Font;
			this.Controls.Add(this.pnWiz0x0076);
			this.Name = "UI";
			this.pnWiz0x0076.ResumeLayout(false);
			this.pnWiz0x0076.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.pnOp2.ResumeLayout(false);
			this.pnOp2.PerformLayout();
			this.pnOp1.ResumeLayout(false);
			this.pnOp1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.pnArray.ResumeLayout(false);
			this.pnArray.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
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
