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
using System.Windows.Forms;

using SimPe.PackedFiles.Wrapper;

namespace pjse.BhavOperandWizards.Wiz0x0008
{
	/// <summary>
	/// Zusammenfassung f�r BhavInstruction.
	/// </summary>
	internal class UI : Form, iBhavOperandWizForm
	{
		#region Form variables

		private TextBox tbval1;
		private TextBox tbval2;
		internal Panel pnWiz0x0008;
		private ComboBox cbPicker1;
		private ComboBox cbPicker2;
		private ComboBox cbDataOwner1;
		private ComboBox cbDataOwner2;
		private CheckBox cbDecimal;
		private CheckBox cbAttrPicker;
		private Label lbConst2;
		private Label lbConst1;
		private Label label2;
		private Label label1;

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
		private DataOwnerControl doid1 = null;
		private DataOwnerControl doid2 = null;

		#region iBhavOperandWizForm
		public Panel WizPanel => pnWiz0x0008;

		public void Execute(Instruction inst)
		{
			this.inst = inst;

			wrappedByteArray ops = inst.Operands;

			doid1 = new DataOwnerControl(
				inst,
				cbDataOwner1,
				cbPicker1,
				tbval1,
				cbDecimal,
				cbAttrPicker,
				lbConst1,
				ops[0x02],
				(ushort)((ops[0x01] << 8) | ops[0x00])
			);
			doid2 = new DataOwnerControl(
				inst,
				cbDataOwner2,
				cbPicker2,
				tbval2,
				cbDecimal,
				cbAttrPicker,
				lbConst2,
				ops[0x06],
				(ushort)((ops[0x05] << 8) | ops[0x04])
			);
		}

		public Instruction Write(Instruction inst)
		{
			if (inst != null)
			{
				wrappedByteArray ops = inst.Operands;
				ops[0x02] = doid1.DataOwner;
				ops[0x00] = (byte)(doid1.Value & 0xff);
				ops[0x01] = (byte)((doid1.Value >> 8) & 0xff);
				ops[0x06] = doid2.DataOwner;
				ops[0x04] = (byte)(doid2.Value & 0xff);
				ops[0x05] = (byte)((doid2.Value >> 8) & 0xff);
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
			pnWiz0x0008 = new Panel();
			label2 = new Label();
			label1 = new Label();
			lbConst2 = new Label();
			lbConst1 = new Label();
			cbAttrPicker = new CheckBox();
			cbDecimal = new CheckBox();
			cbPicker2 = new ComboBox();
			cbPicker1 = new ComboBox();
			tbval2 = new TextBox();
			cbDataOwner2 = new ComboBox();
			tbval1 = new TextBox();
			cbDataOwner1 = new ComboBox();
			pnWiz0x0008.SuspendLayout();
			SuspendLayout();
			//
			// pnWiz0x0008
			//
			pnWiz0x0008.Controls.Add(label2);
			pnWiz0x0008.Controls.Add(label1);
			pnWiz0x0008.Controls.Add(lbConst2);
			pnWiz0x0008.Controls.Add(lbConst1);
			pnWiz0x0008.Controls.Add(cbAttrPicker);
			pnWiz0x0008.Controls.Add(cbDecimal);
			pnWiz0x0008.Controls.Add(cbPicker2);
			pnWiz0x0008.Controls.Add(cbPicker1);
			pnWiz0x0008.Controls.Add(tbval2);
			pnWiz0x0008.Controls.Add(cbDataOwner2);
			pnWiz0x0008.Controls.Add(tbval1);
			pnWiz0x0008.Controls.Add(cbDataOwner1);
			resources.ApplyResources(pnWiz0x0008, "pnWiz0x0008");
			pnWiz0x0008.Name = "pnWiz0x0008";
			//
			// label2
			//
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			//
			// label1
			//
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			//
			// lbConst2
			//
			resources.ApplyResources(lbConst2, "lbConst2");
			lbConst2.Name = "lbConst2";
			//
			// lbConst1
			//
			resources.ApplyResources(lbConst1, "lbConst1");
			lbConst1.Name = "lbConst1";
			//
			// cbAttrPicker
			//
			resources.ApplyResources(cbAttrPicker, "cbAttrPicker");
			cbAttrPicker.Name = "cbAttrPicker";
			//
			// cbDecimal
			//
			resources.ApplyResources(cbDecimal, "cbDecimal");
			cbDecimal.Name = "cbDecimal";
			//
			// cbPicker2
			//
			resources.ApplyResources(cbPicker2, "cbPicker2");
			cbPicker2.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbPicker2.DropDownWidth = 384;
			cbPicker2.Name = "cbPicker2";
			//
			// cbPicker1
			//
			resources.ApplyResources(cbPicker1, "cbPicker1");
			cbPicker1.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbPicker1.DropDownWidth = 384;
			cbPicker1.Name = "cbPicker1";
			//
			// tbval2
			//
			resources.ApplyResources(tbval2, "tbval2");
			tbval2.Name = "tbval2";
			//
			// cbDataOwner2
			//
			resources.ApplyResources(cbDataOwner2, "cbDataOwner2");
			cbDataOwner2.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbDataOwner2.DropDownWidth = 384;
			cbDataOwner2.Name = "cbDataOwner2";
			//
			// tbval1
			//
			resources.ApplyResources(tbval1, "tbval1");
			tbval1.Name = "tbval1";
			//
			// cbDataOwner1
			//
			resources.ApplyResources(cbDataOwner1, "cbDataOwner1");
			cbDataOwner1.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbDataOwner1.DropDownWidth = 384;
			cbDataOwner1.Name = "cbDataOwner1";
			//
			// UI
			//
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(pnWiz0x0008);
			Name = "UI";
			pnWiz0x0008.ResumeLayout(false);
			pnWiz0x0008.PerformLayout();
			ResumeLayout(false);
		}
		#endregion
	}
}

namespace pjse.BhavOperandWizards
{
	public class BhavOperandWiz0x0008 : ABhavOperandWiz
	{
		public BhavOperandWiz0x0008(Instruction i)
			: base(i)
		{
			myForm = new Wiz0x0008.UI();
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
