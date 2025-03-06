// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Data;

namespace SimPe.Actions.Default
{
	/// <summary>
	/// Summary description for ReplaceAction.
	/// </summary>
	public class StartExternalToolAction : ReplaceAction
	{
		ToolLoaderItemExt item;

		public StartExternalToolAction(ToolLoaderItemExt item)
		{
			this.item = item;
		}

		#region IToolAction Member

		public override bool ChangeEnabledStateEventHandler(
			object sender,
			Events.ResourceEventArgs es
		)
		{
			if (es.LoadedPackage == null)
			{
				return false;
			}

			if (es.Count != 1)
			{
				return false;
			}

			foreach (Events.ResourceContainer e in es)
			{
				if (e.HasFileDescriptor && (item.Type == FileTypes.ALL_TYPES || item.Type == e.Resource.FileDescriptor.Type))
				{
					return true;
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
				item.Execute(e.Resource);
			}
		}

		#endregion

		#region IToolPlugin Member

		public override string ToString()
		{
			return item.Name + "...";
		}

		#endregion

		#region IToolExt Member
		public override System.Drawing.Image Icon => GetIcon.actionStart;
		#endregion
	}
}
