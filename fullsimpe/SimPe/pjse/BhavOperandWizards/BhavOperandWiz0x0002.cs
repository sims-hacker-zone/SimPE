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
using System.Windows.Forms;

using SimPe.PackedFiles.Wrapper;

namespace pjse.BhavOperandWizards.Wiz0x0002
{
	/// <summary>
	/// Zusammenfassung f�r BhavInstruction.
	/// </summary>
	internal class UI : Form, iBhavOperandWizForm
	{
		#region Form variables

		internal Panel pnWiz0x0002;
		private ComboBox cbOperator;
		private LabelledDataOwner labelledDataOwner1;
		private LabelledDataOwner labelledDataOwner2;
		private FlowLayoutPanel flowLayoutPanel1;

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

			cbOperator.Items.Clear();
			cbOperator.Items.AddRange(BhavWiz.readStr(GS.BhavStr.Operators).ToArray());

			labelledDataOwner2.Decimal = labelledDataOwner1.Decimal = Settings
				.PJSE
				.DecimalDOValue;
			labelledDataOwner2.UseInstancePicker =
				labelledDataOwner1.UseInstancePicker = Settings
					.PJSE
					.InstancePickerAsText;
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

		#region iBhavOperandWizForm
		public Panel WizPanel => this.pnWiz0x0002;

		public void Execute(Instruction inst)
		{
			this.inst =
				labelledDataOwner1.Instruction =
				labelledDataOwner2.Instruction =
					inst;

			wrappedByteArray ops = inst.Operands;

			labelledDataOwner1.Value = BhavWiz.ToShort(ops[0x00], ops[0x01]);
			labelledDataOwner1.DataOwner = ops[0x06];

			cbOperator.SelectedIndex =
				(cbOperator.Items.Count > ops[0x05]) ? ops[0x05] : -1;

			labelledDataOwner2.Value = BhavWiz.ToShort(ops[0x02], ops[0x03]);
			labelledDataOwner2.DataOwner = ops[0x07];
		}

		public Instruction Write(Instruction inst)
		{
			if (inst != null)
			{
				wrappedByteArray ops = inst.Operands;

				ops[0x06] = labelledDataOwner1.DataOwner;
				BhavWiz.FromShort(ref ops, 0, labelledDataOwner1.Value);

				ops[0x05] = (byte)cbOperator.SelectedIndex;

				ops[0x07] = labelledDataOwner2.DataOwner;
				BhavWiz.FromShort(ref ops, 2, labelledDataOwner2.Value);
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
			this.pnWiz0x0002 = new Panel();
			this.labelledDataOwner2 = new LabelledDataOwner();
			this.labelledDataOwner1 = new LabelledDataOwner();
			this.cbOperator = new ComboBox();
			this.flowLayoutPanel1 = new FlowLayoutPanel();
			this.pnWiz0x0002.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			//
			// pnWiz0x0002
			//
			resources.ApplyResources(this.pnWiz0x0002, "pnWiz0x0002");
			this.pnWiz0x0002.Controls.Add(this.flowLayoutPanel1);
			this.pnWiz0x0002.Name = "pnWiz0x0002";
			//
			// labelledDataOwner2
			//
			resources.ApplyResources(this.labelledDataOwner2, "labelledDataOwner2");
			this.labelledDataOwner2.DataOwner = ((byte)(255));
			this.labelledDataOwner2.DataOwnerEnabled = true;
			this.labelledDataOwner2.FlagsFor = this.labelledDataOwner1;
			this.labelledDataOwner2.Instruction = null;
			this.labelledDataOwner2.LabelSize = new System.Drawing.Size(35, 13);
			this.labelledDataOwner2.LabelVisible = false;
			this.labelledDataOwner2.Name = "labelledDataOwner2";
			this.labelledDataOwner2.UseFlagNames = false;
			this.labelledDataOwner2.Value = ((ushort)(0));
			//
			// labelledDataOwner1
			//
			resources.ApplyResources(this.labelledDataOwner1, "labelledDataOwner1");
			this.labelledDataOwner1.DataOwner = ((byte)(255));
			this.labelledDataOwner1.DataOwnerEnabled = true;
			this.labelledDataOwner1.DecimalVisible = false;
			this.labelledDataOwner1.Instruction = null;
			this.labelledDataOwner1.LabelSize = new System.Drawing.Size(35, 13);
			this.labelledDataOwner1.LabelVisible = false;
			this.labelledDataOwner1.Name = "labelledDataOwner1";
			this.labelledDataOwner1.UseFlagNames = false;
			this.labelledDataOwner1.UseInstancePickerVisible = false;
			this.labelledDataOwner1.Value = ((ushort)(0));
			//
			// cbOperator
			//
			this.cbOperator.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			resources.ApplyResources(this.cbOperator, "cbOperator");
			this.cbOperator.Name = "cbOperator";
			this.cbOperator.SelectedIndexChanged += new System.EventHandler(
				this.cbOperator_SelectedIndexChanged
			);
			//
			// flowLayoutPanel1
			//
			resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
			this.flowLayoutPanel1.Controls.Add(this.labelledDataOwner1);
			this.flowLayoutPanel1.Controls.Add(this.cbOperator);
			this.flowLayoutPanel1.Controls.Add(this.labelledDataOwner2);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			//
			// UI
			//
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = AutoScaleMode.Dpi;
			this.Controls.Add(this.pnWiz0x0002);
			this.Name = "UI";
			this.pnWiz0x0002.ResumeLayout(false);
			this.pnWiz0x0002.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion

		private void cbOperator_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			labelledDataOwner2.UseFlagNames = (
				cbOperator.SelectedIndex >= 8 && cbOperator.SelectedIndex <= 10
			);
		}
	}
}

namespace pjse.BhavOperandWizards
{
	public class BhavOperandWiz0x0002 : ABhavOperandWiz
	{
		public BhavOperandWiz0x0002(Instruction i)
			: base(i)
		{
			myForm = new Wiz0x0002.UI();
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
