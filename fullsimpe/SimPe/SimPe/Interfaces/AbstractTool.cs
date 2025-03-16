// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Interfaces
{
	/// <summary>
	/// Abstract Implementation for <see cref="IToolExt"/> classes
	/// </summary>
	public abstract class AbstractTool : IToolExt
	{
		#region IToolExt Member

		public virtual System.Drawing.Image Icon => null;

		public virtual bool Visible => true;
		#endregion
	}
}
