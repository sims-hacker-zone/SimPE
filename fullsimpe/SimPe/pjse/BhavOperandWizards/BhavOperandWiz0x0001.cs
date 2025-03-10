// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Windows.Forms;

using SimPe.PackedFiles.Bhav;
using SimPe.PackedFiles.Wrapper;

namespace pjse.BhavOperandWizards.Wiz0x0001
{
	/// <summary>
	/// Zusammenfassung f�r BhavInstruction.
	/// </summary>
	internal class UI : Form, iBhavOperandWizForm
	{
		#region Form variables

		internal Panel pnWiz0x0001;
		private ComboBox cbGenericSimsCall;
		private Label lbGenericSimsCallparms;

		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		private string genericSimsCallparamText(int i)
		{
			return BhavWiz.readStr(GS.BhavStr.GenericsDesc, (ushort)i);
		}

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
				components?.Dispose();
			}
			base.Dispose(disposing);
		}

		#region iBhavOperandWizForm
		public Panel WizPanel => pnWiz0x0001;

		public void Execute(Instruction inst)
		{
			byte operand0 = inst.Operands[0];

			cbGenericSimsCall.Items.Clear();
			for (byte i = 0; i < BhavWiz.readStr(GS.BhavStr.Generics).Count; i++)
			{
				cbGenericSimsCall.Items.Add(
					"0x"
						+ SimPe.Helper.HexString(i)
						+ ": "
						+ BhavWiz.readStr(GS.BhavStr.Generics, i)
				);
			}

			lbGenericSimsCallparms.Text = "Should never see this";

			lbGenericSimsCallparms.Text = genericSimsCallparamText(operand0);
			cbGenericSimsCall.SelectedIndex =
				(operand0 < cbGenericSimsCall.Items.Count) ? operand0 : -1;
		}

		public Instruction Write(Instruction inst)
		{
			if (cbGenericSimsCall.SelectedIndex >= 0)
			{
				inst.Operands[0] = (byte)cbGenericSimsCall.SelectedIndex;
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
			pnWiz0x0001 = new Panel();
			lbGenericSimsCallparms = new Label();
			cbGenericSimsCall = new ComboBox();
			pnWiz0x0001.SuspendLayout();
			SuspendLayout();
			//
			// pnWiz0x0001
			//
			pnWiz0x0001.Controls.Add(lbGenericSimsCallparms);
			pnWiz0x0001.Controls.Add(cbGenericSimsCall);
			resources.ApplyResources(pnWiz0x0001, "pnWiz0x0001");
			pnWiz0x0001.Name = "pnWiz0x0001";
			//
			// lbGenericSimsCallparms
			//
			resources.ApplyResources(
				lbGenericSimsCallparms,
				"lbGenericSimsCallparms"
			);
			lbGenericSimsCallparms.Name = "lbGenericSimsCallparms";
			//
			// cbGenericSimsCall
			//
			cbGenericSimsCall.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbGenericSimsCall.DropDownWidth = 352;
			resources.ApplyResources(cbGenericSimsCall, "cbGenericSimsCall");
			cbGenericSimsCall.Name = "cbGenericSimsCall";
			cbGenericSimsCall.SelectedIndexChanged += new System.EventHandler(
				cbGenericSimsCall_Changed
			);
			//
			// UI
			//
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Dpi;
			Controls.Add(pnWiz0x0001);
			Name = "UI";
			pnWiz0x0001.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion

		private void cbGenericSimsCall_Changed(object sender, System.EventArgs e)
		{
			lbGenericSimsCallparms.Text =
				(cbGenericSimsCall.SelectedIndex >= 0)
					? genericSimsCallparamText(cbGenericSimsCall.SelectedIndex)
					: "";
		}
	}
}

namespace pjse.BhavOperandWizards
{
	public class BhavOperandWiz0x0001 : ABhavOperandWiz
	{
		public BhavOperandWiz0x0001(Instruction i)
			: base(i)
		{
			myForm = new Wiz0x0001.UI();
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
