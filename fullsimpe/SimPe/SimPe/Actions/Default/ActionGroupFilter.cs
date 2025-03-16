// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Actions.Default
{
	class ActionGroupFilter : AbstractActionDefault
	{

		public ActionGroupFilter()
		{
		}

		public override bool ChangeEnabledStateEventHandler(
			object sender,
			Events.ResourceEventArgs es
		)
		{
			bool res = base.ChangeEnabledStateEventHandler(sender, es);
			return (res && es.Count == 1);
		}

		#region IToolAction Member

		public override void ExecuteEventHandler(
			object sender,
			Events.ResourceEventArgs es
		)
		{
			if (!ChangeEnabledStateEventHandler(sender, es))
			{
				return;
			}
		}

		#endregion

		#region IToolPlugin Member
		public override string ToString()
		{
			return Localization.GetString("GroupFilterSet");
		}

		#endregion

		#region IToolExt Member
		public override System.Drawing.Image Icon => GetIcon.actionFilter;
		#endregion
	}
}
