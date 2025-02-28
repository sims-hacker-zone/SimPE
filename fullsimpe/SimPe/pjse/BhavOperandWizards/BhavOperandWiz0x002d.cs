// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Windows.Forms;

using SimPe.PackedFiles.Wrapper;

namespace pjse.BhavOperandWizards.Wiz0x002d
{
	/// <summary>
	/// Summary description for StrBig.
	/// </summary>
	internal class UI : Form, iBhavOperandWizForm
	{
		#region Form variables

		internal Panel pnWiz0x002d;
		private FlowLayoutPanel flowLayoutPanel1;
		private GroupBox gbRoutingSlot;
		private Panel pnObject;
		private ComboBox cbSlotType;
		private CheckBox ckbDecimal;
		private TextBox tbVal1;
		private CheckBox ckbNFailTrees;
		private CheckBox ckbIgnDstFootprint;
		private CheckBox ckbDiffAlts;

		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public UI()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
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
		private DataOwnerControl doid1 = null;

		//private bool internalchg = false;

		#region iBhavOperandWizForm
		public Panel WizPanel => pnWiz0x002d;

		public void Execute(Instruction inst)
		{
			this.inst = inst;

			wrappedByteArray ops1 = inst.Operands;
			wrappedByteArray ops2 = inst.Reserved1;
			Boolset ops14 = ops1[4];

			//internalchg = true;

			doid1 = new DataOwnerControl(
				inst,
				null,
				null,
				tbVal1,
				ckbDecimal,
				null,
				null,
				0x07,
				BhavWiz.ToShort(ops1[0x00], ops1[0x01])
			); // Literal

			int i = 0;
			if (!ops14[1])
			{
				i = BhavWiz.ToShort(ops1[2], ops1[3]);
			}

			if (i < cbSlotType.Items.Count)
			{
				cbSlotType.SelectedIndex = i;
			}

			ckbNFailTrees.Checked = ops14[0];
			ckbIgnDstFootprint.Checked = ops14[2];
			ckbDiffAlts.Checked = ops14[3];

			//internalchg = false;
		}

		public Instruction Write(Instruction inst)
		{
			if (inst != null)
			{
				wrappedByteArray ops1 = inst.Operands;
				wrappedByteArray ops2 = inst.Reserved1;
				Boolset ops14 = ops1[4];

				ops1[0] = (byte)doid1.Value;
				ops1[1] = (byte)(doid1.Value >> 8);

				if (cbSlotType.SelectedIndex >= 1)
				{
					ops1[2] = (byte)(cbSlotType.SelectedIndex - 1);
					ops1[3] = (byte)((cbSlotType.SelectedIndex - 1) >> 8);
				}

				ops14[0] = ckbNFailTrees.Checked;
				ops14[1] = cbSlotType.SelectedIndex == 0;
				ops14[2] = ckbIgnDstFootprint.Checked;
				ops14[3] = ckbDiffAlts.Checked;
				ops1[4] = ops14;
			}
			return inst;
		}

		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(typeof(UI));
			pnWiz0x002d = new Panel();
			flowLayoutPanel1 = new FlowLayoutPanel();
			gbRoutingSlot = new GroupBox();
			pnObject = new Panel();
			cbSlotType = new ComboBox();
			ckbDecimal = new CheckBox();
			tbVal1 = new TextBox();
			ckbNFailTrees = new CheckBox();
			ckbIgnDstFootprint = new CheckBox();
			ckbDiffAlts = new CheckBox();
			pnWiz0x002d.SuspendLayout();
			flowLayoutPanel1.SuspendLayout();
			gbRoutingSlot.SuspendLayout();
			pnObject.SuspendLayout();
			SuspendLayout();
			//
			// pnWiz0x002d
			//
			resources.ApplyResources(pnWiz0x002d, "pnWiz0x002d");
			pnWiz0x002d.Controls.Add(flowLayoutPanel1);
			pnWiz0x002d.Name = "pnWiz0x002d";
			//
			// flowLayoutPanel1
			//
			resources.ApplyResources(flowLayoutPanel1, "flowLayoutPanel1");
			flowLayoutPanel1.Controls.Add(gbRoutingSlot);
			flowLayoutPanel1.Controls.Add(ckbNFailTrees);
			flowLayoutPanel1.Controls.Add(ckbIgnDstFootprint);
			flowLayoutPanel1.Controls.Add(ckbDiffAlts);
			flowLayoutPanel1.Name = "flowLayoutPanel1";
			//
			// gbRoutingSlot
			//
			resources.ApplyResources(gbRoutingSlot, "gbRoutingSlot");
			gbRoutingSlot.Controls.Add(pnObject);
			gbRoutingSlot.Name = "gbRoutingSlot";
			gbRoutingSlot.TabStop = false;
			//
			// pnObject
			//
			resources.ApplyResources(pnObject, "pnObject");
			pnObject.Controls.Add(cbSlotType);
			pnObject.Controls.Add(ckbDecimal);
			pnObject.Controls.Add(tbVal1);
			pnObject.Name = "pnObject";
			//
			// cbSlotType
			//
			cbSlotType.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbSlotType.FormattingEnabled = true;
			cbSlotType.Items.AddRange(
				new object[]
				{
					resources.GetString("cbSlotType.Items"),
					resources.GetString("cbSlotType.Items1"),
					resources.GetString("cbSlotType.Items2"),
					resources.GetString("cbSlotType.Items3"),
					resources.GetString("cbSlotType.Items4"),
				}
			);
			resources.ApplyResources(cbSlotType, "cbSlotType");
			cbSlotType.Name = "cbSlotType";
			//
			// ckbDecimal
			//
			resources.ApplyResources(ckbDecimal, "ckbDecimal");
			ckbDecimal.Name = "ckbDecimal";
			//
			// tbVal1
			//
			resources.ApplyResources(tbVal1, "tbVal1");
			tbVal1.Name = "tbVal1";
			//
			// ckbNFailTrees
			//
			resources.ApplyResources(ckbNFailTrees, "ckbNFailTrees");
			ckbNFailTrees.Name = "ckbNFailTrees";
			ckbNFailTrees.UseVisualStyleBackColor = true;
			//
			// ckbIgnDstFootprint
			//
			resources.ApplyResources(ckbIgnDstFootprint, "ckbIgnDstFootprint");
			ckbIgnDstFootprint.Name = "ckbIgnDstFootprint";
			ckbIgnDstFootprint.UseVisualStyleBackColor = true;
			//
			// ckbDiffAlts
			//
			resources.ApplyResources(ckbDiffAlts, "ckbDiffAlts");
			ckbDiffAlts.Name = "ckbDiffAlts";
			ckbDiffAlts.UseVisualStyleBackColor = true;
			//
			// UI
			//
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Dpi;
			Controls.Add(pnWiz0x002d);
			Name = "UI";
			pnWiz0x002d.ResumeLayout(false);
			pnWiz0x002d.PerformLayout();
			flowLayoutPanel1.ResumeLayout(false);
			flowLayoutPanel1.PerformLayout();
			gbRoutingSlot.ResumeLayout(false);
			gbRoutingSlot.PerformLayout();
			pnObject.ResumeLayout(false);
			pnObject.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion
	}
}

namespace pjse.BhavOperandWizards
{
	public class BhavOperandWiz0x002d : ABhavOperandWiz
	{
		public BhavOperandWiz0x002d(Instruction i)
			: base(i)
		{
			myForm = new Wiz0x002d.UI();
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
