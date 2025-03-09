// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Windows.Forms;

using SimPe.PackedFiles.Bhav;
using SimPe.PackedFiles.Wrapper;

namespace pjse.BhavOperandWizards.Wiz0x001b
{
	/// <summary>
	/// Summary description for StrBig.
	/// </summary>
	internal class UI : Form, iBhavOperandWizForm
	{
		#region Form variables

		internal Panel pnWiz0x001b;
		private FlowLayoutPanel flowLayoutPanel1;
		private GroupBox gbLocation;
		private ComboBox cbLocation;
		private GroupBox gbDirection;
		private ComboBox cbDirection;
		private CheckBox ckbNoFailureTrees;
		private CheckBox ckbDifferentAltitudes;

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

			cbLocation.Items.AddRange(
				BhavWiz.readStr(GS.BhavStr.RelativeLocations).ToArray()
			);
			cbDirection.Items.AddRange(
				BhavWiz.readStr(GS.BhavStr.RelativeDirections).ToArray()
			);
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

		//private bool internalchg = false;

		#region iBhavOperandWizForm
		public Panel WizPanel => pnWiz0x001b;

		public void Execute(Instruction inst)
		{
			this.inst = inst;

			wrappedByteArray ops1 = inst.Operands;
			wrappedByteArray ops2 = inst.Reserved1;
			Boolset ops16 = ops1[6];

			//internalchg = true;

			cbLocation.SelectedIndex =
				((byte)(ops1[2] + 2) < cbLocation.Items.Count)
					? (byte)(ops1[2] + 2)
					: -1;
			cbDirection.SelectedIndex =
				((byte)(ops1[3] + 2) < cbDirection.Items.Count)
					? (byte)(ops1[3] + 2)
					: -1;

			ckbNoFailureTrees.Checked = ops16[1];
			ckbDifferentAltitudes.Checked = ops16[2];

			//internalchg = false;
		}

		public Instruction Write(Instruction inst)
		{
			if (inst != null)
			{
				wrappedByteArray ops1 = inst.Operands;
				wrappedByteArray ops2 = inst.Reserved1;
				Boolset ops16 = ops1[6];

				if (cbLocation.SelectedIndex >= 0)
				{
					ops1[2] = (byte)(cbLocation.SelectedIndex - 2);
				}

				if (cbDirection.SelectedIndex >= 0)
				{
					ops1[3] = (byte)(cbDirection.SelectedIndex - 2);
				}

				ops16[1] = ckbNoFailureTrees.Checked;
				ops16[2] = ckbDifferentAltitudes.Checked;
				ops1[6] = ops16;
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
			pnWiz0x001b = new Panel();
			flowLayoutPanel1 = new FlowLayoutPanel();
			gbLocation = new GroupBox();
			cbLocation = new ComboBox();
			gbDirection = new GroupBox();
			cbDirection = new ComboBox();
			ckbNoFailureTrees = new CheckBox();
			ckbDifferentAltitudes = new CheckBox();
			pnWiz0x001b.SuspendLayout();
			flowLayoutPanel1.SuspendLayout();
			gbLocation.SuspendLayout();
			gbDirection.SuspendLayout();
			SuspendLayout();
			//
			// pnWiz0x001b
			//
			resources.ApplyResources(pnWiz0x001b, "pnWiz0x001b");
			pnWiz0x001b.Controls.Add(flowLayoutPanel1);
			pnWiz0x001b.Name = "pnWiz0x001b";
			//
			// flowLayoutPanel1
			//
			resources.ApplyResources(flowLayoutPanel1, "flowLayoutPanel1");
			flowLayoutPanel1.Controls.Add(gbLocation);
			flowLayoutPanel1.Controls.Add(gbDirection);
			flowLayoutPanel1.Controls.Add(ckbNoFailureTrees);
			flowLayoutPanel1.Controls.Add(ckbDifferentAltitudes);
			flowLayoutPanel1.Name = "flowLayoutPanel1";
			//
			// gbLocation
			//
			resources.ApplyResources(gbLocation, "gbLocation");
			gbLocation.Controls.Add(cbLocation);
			gbLocation.Name = "gbLocation";
			gbLocation.TabStop = false;
			//
			// cbLocation
			//
			cbLocation.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbLocation.FormattingEnabled = true;
			resources.ApplyResources(cbLocation, "cbLocation");
			cbLocation.Name = "cbLocation";
			//
			// gbDirection
			//
			resources.ApplyResources(gbDirection, "gbDirection");
			gbDirection.Controls.Add(cbDirection);
			gbDirection.Name = "gbDirection";
			gbDirection.TabStop = false;
			//
			// cbDirection
			//
			cbDirection.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbDirection.FormattingEnabled = true;
			resources.ApplyResources(cbDirection, "cbDirection");
			cbDirection.Name = "cbDirection";
			//
			// ckbNoFailureTrees
			//
			resources.ApplyResources(ckbNoFailureTrees, "ckbNoFailureTrees");
			ckbNoFailureTrees.Name = "ckbNoFailureTrees";
			ckbNoFailureTrees.UseVisualStyleBackColor = true;
			//
			// ckbDifferentAltitudes
			//
			resources.ApplyResources(
				ckbDifferentAltitudes,
				"ckbDifferentAltitudes"
			);
			ckbDifferentAltitudes.Name = "ckbDifferentAltitudes";
			ckbDifferentAltitudes.UseVisualStyleBackColor = true;
			//
			// UI
			//
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Dpi;
			Controls.Add(pnWiz0x001b);
			Name = "UI";
			pnWiz0x001b.ResumeLayout(false);
			pnWiz0x001b.PerformLayout();
			flowLayoutPanel1.ResumeLayout(false);
			flowLayoutPanel1.PerformLayout();
			gbLocation.ResumeLayout(false);
			gbDirection.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion
	}
}

namespace pjse.BhavOperandWizards
{
	public class BhavOperandWiz0x001b : ABhavOperandWiz
	{
		public BhavOperandWiz0x001b(Instruction i)
			: base(i)
		{
			myForm = new Wiz0x001b.UI();
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
