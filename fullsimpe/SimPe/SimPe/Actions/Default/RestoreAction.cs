// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Actions.Default
{
	/// <summary>
	/// Summary description for RestoreAction.
	/// </summary>
	public class RestoreAction : AbstractActionDefault
	{
		public RestoreAction()
		{
		}

		#region IToolAction Member

		public override bool ChangeEnabledStateEventHandler(
			object sender,
			Events.ResourceEventArgs es
		)
		{
			bool res = base.ChangeEnabledStateEventHandler(sender, es);
			if (res)
			{
				res = false;
				foreach (Events.ResourceContainer e in es)
				{
					if (e.HasFileDescriptor)
					{
						if (e.Resource.FileDescriptor.MarkForDelete)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		public override void ExecuteEventHandler(
			object sender,
			Events.ResourceEventArgs es
		)
		{
			if (!ChangeEnabledStateEventHandler(null, es))
			{
				return;
			}

			foreach (Events.ResourceContainer e in es)
			{
				e.Resource.FileDescriptor.MarkForDelete = false;
			}
		}

		#endregion

		#region IToolPlugin Member

		public override string ToString()
		{
			return "Restore";
		}

		#endregion

		#region IToolExt Member
		public override System.Drawing.Image Icon => GetIcon.actionRestore;

		public override System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.ShiftIns;
		#endregion
	}
}
