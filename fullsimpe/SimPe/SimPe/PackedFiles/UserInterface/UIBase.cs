// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.PackedFiles.UserInterface
{
	/// <summary>
	/// Abstract Base for some UIHandlers
	/// </summary>
	public abstract class UIBase
	{
		/// <summary>
		/// The Form containing the Panel
		/// </summary>
		internal static Elements form = null;

		/// <summary>
		/// Constructor for the Class
		/// </summary>
		public UIBase()
		{
			if (form == null)
			{
				form = new Elements();
			}
		}

		#region IDisposable Member
		public virtual void Dispose()
		{
		}
		#endregion
	}
}
