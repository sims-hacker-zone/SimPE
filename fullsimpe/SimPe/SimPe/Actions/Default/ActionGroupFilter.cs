/***************************************************************************
 *   Copyright (C) 2008 by Peter L Jones                                   *
 *   pljones@users.sf.net                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
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
