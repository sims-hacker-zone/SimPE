﻿/*
 * SimpePrimitiveWizards - additional primitive wizards for SimPe
 *                       - see https://www.picknmixmods.com/Sims2/Notes/SimpePrimitiveWizards/SimpePrimitiveWizards.html
 *
 * William Howard - 2023-2023
 *
 * Permission granted to use this code in any way, except to claim it as your own or sell it
 *
 * NOTE: Code should not be "using Simpe;" or "using pjse;" but fully qualifying classes in those high level namespaces
 *
 */

using SimPe.PackedFiles.Bhav;
using SimPe.PackedFiles.Wrapper;

using whse.PrimitiveWizards.Wiz0x007a;

namespace whse.PrimitiveWizards
{
	// 0x007a - On Timer
	public class BhavOperandWiz0x007a : pjse.ABhavOperandWiz
	{
		public BhavOperandWiz0x007a(Instruction i) : base(i)
		{
			this.myForm = new UI();
		}

		public override void Dispose()
		{
			if (this.myForm != null)
			{
				// Clean up as necessary

				this.myForm = null;
			}
		}
	}
}
