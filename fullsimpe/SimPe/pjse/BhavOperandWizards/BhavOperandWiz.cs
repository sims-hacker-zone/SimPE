// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using SimPe.PackedFiles.Bhav;
using SimPe.PackedFiles.Wrapper;

namespace pjse
{
	public interface iBhavOperandWizForm
	{
		void Execute(Instruction inst);
		Instruction Write(Instruction inst);
	}

	/// <summary>
	/// Provides the operand wizard for a given Bhav Instruction.
	/// </summary>
	/// <summary>
	/// Abstract class for BHAV Operand Wizards to extend
	/// </summary>
	public abstract class ABhavOperandWiz : IDisposable
	{
		protected Instruction instruction = null;
		protected iBhavOperandWizForm myForm = null;

		protected ABhavOperandWiz(Instruction instruction)
		{
			this.instruction = instruction;
		}

		public virtual void Execute()
		{
			myForm.Execute(instruction);
		}

		public virtual Instruction Write()
		{
			//for (int i = 0; i < 8; i++) instruction.Operands[i] = 0;
			//for (int i = 0; i < 8; i++) instruction.Reserved1[i] = 0;
			return myForm.Write(instruction);
		}

		#region IDisposable Members
		public abstract void Dispose();
		#endregion
	}
}

