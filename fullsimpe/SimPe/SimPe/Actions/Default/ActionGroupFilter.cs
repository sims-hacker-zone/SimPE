// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Actions.Default
{
	class ActionGroupFilter : AbstractActionDefault
	{
		private Windows.Forms.ResourceListViewExt lv = null;
		private ViewFilter Filter => (ViewFilter)(lv?.Filter);

		public ActionGroupFilter(Windows.Forms.ResourceListViewExt value)
		{
			lv = value;
		}

		public override bool ChangeEnabledStateEventHandler(
			object sender,
			Events.ResourceEventArgs es
		)
		{
			bool res = base.ChangeEnabledStateEventHandler(sender, es);
			return (Filter != null && Filter.FilterGroup) || (res && es.Count == 1);
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

			if (Filter != null && Filter.FilterGroup)
			{
				Filter.FilterGroup = false;
			}
			else
			{
				Filter.Group = es.GetDescriptors()[0].Group;
				Filter.FilterGroup = true;
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

		public override System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.CtrlT; // for "Toggle"...
		#endregion
	}
}
