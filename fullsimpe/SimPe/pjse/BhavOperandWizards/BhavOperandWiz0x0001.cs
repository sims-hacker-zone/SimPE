/***************************************************************************
 *   Copyright (C) 2005 by Peter L Jones                                   *
 *   pljones@users.sf.net                                                  *
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

using pjse.BhavNameWizards;

using SimPe.PackedFiles.Wrapper;

namespace pjse.BhavOperandWizards.Wiz0x0001
{
	/// <summary>
	/// Zusammenfassung f�r BhavInstruction.
	/// </summary>
	internal class UI : System.Windows.Forms.Form, iBhavOperandWizForm
	{
		#region Form variables

		internal System.Windows.Forms.Panel pnWiz0x0001;
		private System.Windows.Forms.ComboBox cbGenericSimsCall;
		private System.Windows.Forms.Label lbGenericSimsCallparms;

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
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region iBhavOperandWizForm
		public Panel WizPanel => this.pnWiz0x0001;

		public void Execute(Instruction inst)
		{
			byte operand0 = inst.Operands[0];

			this.cbGenericSimsCall.Items.Clear();
			for (byte i = 0; i < BhavWiz.readStr(GS.BhavStr.Generics).Count; i++)
			{
				this.cbGenericSimsCall.Items.Add(
					"0x"
						+ SimPe.Helper.HexString(i)
						+ ": "
						+ BhavWiz.readStr(GS.BhavStr.Generics, i)
				);
			}

			this.lbGenericSimsCallparms.Text = "Should never see this";

			lbGenericSimsCallparms.Text = genericSimsCallparamText(operand0);
			cbGenericSimsCall.SelectedIndex =
				(operand0 < cbGenericSimsCall.Items.Count) ? operand0 : -1;
		}

		public Instruction Write(Instruction inst)
		{
			if (this.cbGenericSimsCall.SelectedIndex >= 0)
			{
				inst.Operands[0] = (byte)this.cbGenericSimsCall.SelectedIndex;
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
			this.pnWiz0x0001 = new System.Windows.Forms.Panel();
			this.lbGenericSimsCallparms = new System.Windows.Forms.Label();
			this.cbGenericSimsCall = new System.Windows.Forms.ComboBox();
			this.pnWiz0x0001.SuspendLayout();
			this.SuspendLayout();
			//
			// pnWiz0x0001
			//
			this.pnWiz0x0001.Controls.Add(this.lbGenericSimsCallparms);
			this.pnWiz0x0001.Controls.Add(this.cbGenericSimsCall);
			resources.ApplyResources(this.pnWiz0x0001, "pnWiz0x0001");
			this.pnWiz0x0001.Name = "pnWiz0x0001";
			//
			// lbGenericSimsCallparms
			//
			resources.ApplyResources(
				this.lbGenericSimsCallparms,
				"lbGenericSimsCallparms"
			);
			this.lbGenericSimsCallparms.Name = "lbGenericSimsCallparms";
			//
			// cbGenericSimsCall
			//
			this.cbGenericSimsCall.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbGenericSimsCall.DropDownWidth = 352;
			resources.ApplyResources(this.cbGenericSimsCall, "cbGenericSimsCall");
			this.cbGenericSimsCall.Name = "cbGenericSimsCall";
			this.cbGenericSimsCall.SelectedIndexChanged += new System.EventHandler(
				this.cbGenericSimsCall_Changed
			);
			//
			// UI
			//
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Controls.Add(this.pnWiz0x0001);
			this.Name = "UI";
			this.pnWiz0x0001.ResumeLayout(false);
			this.ResumeLayout(false);
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
	public class BhavOperandWiz0x0001 : pjse.ABhavOperandWiz
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
