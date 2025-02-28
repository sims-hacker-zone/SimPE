// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Actions.Default
{
	/// <summary>
	/// Summary description for AbstractActionDefault.
	/// </summary>
	public abstract class AbstractActionDefault : Interfaces.IToolAction
	{
		#region IToolAction Member

		public virtual bool ChangeEnabledStateEventHandler(
			object sender,
			Events.ResourceEventArgs es
		)
		{
			return es != null && es.LoadedPackage != null && es.LoadedPackage.Loaded && es.HasResource;
		}

		public abstract void ExecuteEventHandler(
			object sender,
			Events.ResourceEventArgs e
		);

		#endregion

		#region IToolExt Member

		public virtual System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.None;

		public virtual System.Drawing.Image Icon => null;

		public virtual bool Visible => true;

		#endregion
	}
}
