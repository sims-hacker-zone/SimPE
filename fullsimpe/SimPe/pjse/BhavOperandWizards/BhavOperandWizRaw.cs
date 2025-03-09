// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Windows.Forms;

using SimPe.PackedFiles.Bhav;
using SimPe.PackedFiles.Wrapper;

namespace pjse.BhavOperandWizards.WizRaw
{
	/// <summary>
	/// Zusammenfassung f�r BhavInstruction.
	/// </summary>
	internal class UI : Form, iBhavOperandWizForm
	{
		#region Form variables
		internal Panel pnWizRaw;
		private TextBox tbRaw;

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
				components?.Dispose();
			}
			base.Dispose(disposing);
		}

		#region iBhavOperandWizForm
		public Panel WizPanel => pnWizRaw;

		public void Execute(Instruction inst)
		{
			string s = "";
			for (int i = 0; i < 8; i++)
			{
				s += SimPe.Helper.HexString(inst.Operands[i]);
			}

			for (int i = 0; i < 8; i++)
			{
				s += SimPe.Helper.HexString(inst.Reserved1[i]);
			}

			tbRaw.Text = s;
		}

		public Instruction Write(Instruction inst)
		{
			try
			{
				string s = tbRaw.Text + "00000000000000000000000000000000";
				for (int i = 0; i < 8; i++)
				{
					inst.Operands[i] = Convert.ToByte(s.Substring(i * 2, 2), 16);
				}

				for (int i = 0; i < 8; i++)
				{
					inst.Reserved1[i] = Convert.ToByte(s.Substring((i + 8) * 2, 2), 16);
				}

				return inst;
			}
			catch (Exception ex)
			{
				SimPe.Helper.ExceptionMessage(
					Localization.GetString("errconvert"),
					ex
				);
				return null;
			}
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
			pnWizRaw = new Panel();
			tbRaw = new TextBox();
			pnWizRaw.SuspendLayout();
			SuspendLayout();
			//
			// pnWizRaw
			//
			pnWizRaw.Controls.Add(tbRaw);
			resources.ApplyResources(pnWizRaw, "pnWizRaw");
			pnWizRaw.Name = "pnWizRaw";
			//
			// tbRaw
			//
			resources.ApplyResources(tbRaw, "tbRaw");
			tbRaw.Name = "tbRaw";
			//
			// UI
			//
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Dpi;
			Controls.Add(pnWizRaw);
			Name = "UI";
			pnWizRaw.ResumeLayout(false);
			pnWizRaw.PerformLayout();
			ResumeLayout(false);
		}
		#endregion
	}
}

namespace pjse.BhavOperandWizards
{
	public class BhavOperandWizRaw : ABhavOperandWiz
	{
		public BhavOperandWizRaw(Instruction i)
			: base(i)
		{
			myForm = new WizRaw.UI();
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
