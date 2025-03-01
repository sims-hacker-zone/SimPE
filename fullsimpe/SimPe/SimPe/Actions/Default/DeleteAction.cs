// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Actions.Default
{
	/// <summary>
	/// Summary description for DeleteAction.
	/// </summary>
	public class DeleteAction : AbstractActionDefault
	{
		public DeleteAction()
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
						if (!e.Resource.FileDescriptor.MarkForDelete)
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

			if (es.Loaded)
			{
				es.LoadedPackage.Package.BeginUpdate();
			}

			foreach (Events.ResourceContainer e in es)
			{
				if (es.Loaded)
				{
					es.LoadedPackage.Package.ForgetUpdate();
				}

				e.Resource.FileDescriptor.MarkForDelete = true;
			}

			if (es.Loaded)
			{
				es.LoadedPackage.Package.EndUpdate();
			}
		}

		#endregion

		#region IToolPlugin Member

		public override string ToString()
		{
			return "Delete";
		}

		#endregion

		#region IToolExt Member
		public override System.Drawing.Image Icon => GetIcon.actionDelete;

		public override System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.ShiftDel;

		#endregion
	}
}
