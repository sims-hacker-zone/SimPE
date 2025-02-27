/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
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
using System;

using SimPe.Events;

namespace SimPe.Plugin.Tool
{
	/// <summary>
	/// Toll that can preview Animations
	/// </summary>
	public class AnimTool : Interfaces.IToolPlus
	{
		internal AnimTool()
		{
		}

		#region ITool Member

		public bool ChangeEnabledStateEventHandler(object sender, ResourceEventArgs e)
		{
			if (!e.Loaded)
			{
				return false;
			}

			if (!e.HasResource)
			{
				return false;
			}

			if (e.Count > 1)
			{
				return false;
			}

			return e.Items[0].Resource.FileDescriptor.Type
				== Data.MetaData.ANIM;
		}

		public void Execute(object sender, ResourceEventArgs es)
		{
			if (!ChangeEnabledStateEventHandler(sender, es))
			{
				return;
			}

			try
			{
				AnimPreview.Execute(es.Items[0].Resource);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(ex);
			}
		}

		public override string ToString()
		{
			return "Object Tool\\Animation Preview";
		}

		#endregion

		#region IToolExt Member
		public System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.CtrlShiftA;

		public System.Drawing.Image Icon => GetIcon.AnimCamera;

		public virtual bool Visible => true;

		#endregion
	}
}
