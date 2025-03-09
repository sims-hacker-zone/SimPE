// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Windows.Forms;

using SimPe.PackedFiles.Bhav;
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
				components?.Dispose();
			}
			base.Dispose(disposing);

			inst = null;
		}

		private Instruction inst = null;

		#region iBhavOperandWizForm
		public Panel WizPanel => pnWiz0x0002;

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
			pnWiz0x0002 = new Panel();
			labelledDataOwner2 = new LabelledDataOwner();
			labelledDataOwner1 = new LabelledDataOwner();
			cbOperator = new ComboBox();
			flowLayoutPanel1 = new FlowLayoutPanel();
			pnWiz0x0002.SuspendLayout();
			flowLayoutPanel1.SuspendLayout();
			SuspendLayout();
			//
			// pnWiz0x0002
			//
			resources.ApplyResources(pnWiz0x0002, "pnWiz0x0002");
			pnWiz0x0002.Controls.Add(flowLayoutPanel1);
			pnWiz0x0002.Name = "pnWiz0x0002";
			//
			// labelledDataOwner2
			//
			resources.ApplyResources(labelledDataOwner2, "labelledDataOwner2");
			labelledDataOwner2.DataOwner = 255;
			labelledDataOwner2.DataOwnerEnabled = true;
			labelledDataOwner2.FlagsFor = labelledDataOwner1;
			labelledDataOwner2.Instruction = null;
			labelledDataOwner2.LabelSize = new System.Drawing.Size(35, 13);
			labelledDataOwner2.LabelVisible = false;
			labelledDataOwner2.Name = "labelledDataOwner2";
			labelledDataOwner2.UseFlagNames = false;
			labelledDataOwner2.Value = 0;
			//
			// labelledDataOwner1
			//
			resources.ApplyResources(labelledDataOwner1, "labelledDataOwner1");
			labelledDataOwner1.DataOwner = 255;
			labelledDataOwner1.DataOwnerEnabled = true;
			labelledDataOwner1.DecimalVisible = false;
			labelledDataOwner1.Instruction = null;
			labelledDataOwner1.LabelSize = new System.Drawing.Size(35, 13);
			labelledDataOwner1.LabelVisible = false;
			labelledDataOwner1.Name = "labelledDataOwner1";
			labelledDataOwner1.UseFlagNames = false;
			labelledDataOwner1.UseInstancePickerVisible = false;
			labelledDataOwner1.Value = 0;
			//
			// cbOperator
			//
			cbOperator.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			resources.ApplyResources(cbOperator, "cbOperator");
			cbOperator.Name = "cbOperator";
			cbOperator.SelectedIndexChanged += new System.EventHandler(
				cbOperator_SelectedIndexChanged
			);
			//
			// flowLayoutPanel1
			//
			resources.ApplyResources(flowLayoutPanel1, "flowLayoutPanel1");
			flowLayoutPanel1.Controls.Add(labelledDataOwner1);
			flowLayoutPanel1.Controls.Add(cbOperator);
			flowLayoutPanel1.Controls.Add(labelledDataOwner2);
			flowLayoutPanel1.Name = "flowLayoutPanel1";
			//
			// UI
			//
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Dpi;
			Controls.Add(pnWiz0x0002);
			Name = "UI";
			pnWiz0x0002.ResumeLayout(false);
			pnWiz0x0002.PerformLayout();
			flowLayoutPanel1.ResumeLayout(false);
			flowLayoutPanel1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion

		private void cbOperator_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			labelledDataOwner2.UseFlagNames =
				cbOperator.SelectedIndex >= 8 && cbOperator.SelectedIndex <= 10
			;
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
