/***************************************************************************
 *   Copyright (C) 2005 by Peter L Jones                                   *
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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using SimPe.PackedFiles.Wrapper;

namespace pjse.BhavOperandWizards.WizRaw
{
	/// <summary>
	/// Zusammenfassung f�r BhavInstruction.
	/// </summary>
	internal class UI : System.Windows.Forms.Form, iBhavOperandWizForm
	{
		#region Form variables
		internal System.Windows.Forms.Panel pnWizRaw;
		private System.Windows.Forms.TextBox tbRaw;

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
		}

		#region iBhavOperandWizForm
		public Panel WizPanel => this.pnWizRaw;

		public void Execute(Instruction inst)
		{
			string s = "";
			for (int i = 0; i < 8; i++)
				s += SimPe.Helper.HexString(inst.Operands[i]);
			for (int i = 0; i < 8; i++)
				s += SimPe.Helper.HexString(inst.Reserved1[i]);
			tbRaw.Text = s;
		}

		public Instruction Write(Instruction inst)
		{
			try
			{
				string s = tbRaw.Text + "00000000000000000000000000000000";
				for (int i = 0; i < 8; i++)
					inst.Operands[i] = Convert.ToByte(s.Substring(i * 2, 2), 16);
				for (int i = 0; i < 8; i++)
					inst.Reserved1[i] = Convert.ToByte(s.Substring((i + 8) * 2, 2), 16);

				return inst;
			}
			catch (Exception ex)
			{
				SimPe.Helper.ExceptionMessage(
					pjse.Localization.GetString("errconvert"),
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
			this.pnWizRaw = new System.Windows.Forms.Panel();
			this.tbRaw = new System.Windows.Forms.TextBox();
			this.pnWizRaw.SuspendLayout();
			this.SuspendLayout();
			//
			// pnWizRaw
			//
			this.pnWizRaw.Controls.Add(this.tbRaw);
			resources.ApplyResources(this.pnWizRaw, "pnWizRaw");
			this.pnWizRaw.Name = "pnWizRaw";
			//
			// tbRaw
			//
			resources.ApplyResources(this.tbRaw, "tbRaw");
			this.tbRaw.Name = "tbRaw";
			//
			// UI
			//
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Controls.Add(this.pnWizRaw);
			this.Name = "UI";
			this.pnWizRaw.ResumeLayout(false);
			this.pnWizRaw.PerformLayout();
			this.ResumeLayout(false);
		}
		#endregion
	}
}

namespace pjse.BhavOperandWizards
{
	public class BhavOperandWizRaw : pjse.ABhavOperandWiz
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
				myForm = null;
		}
		#endregion
	}
}
