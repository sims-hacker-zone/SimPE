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

namespace SimPe.Actions.Default
{
	/// <summary>
	/// Summary description for CloneAction.
	/// </summary>
	public class CloneAction : AbstractActionDefault
	{
		public CloneAction()
		{
		}

		#region IToolAction Member

		public override void ExecuteEventHandler(
			object sender,
			Events.ResourceEventArgs es
		)
		{
			if (!ChangeEnabledStateEventHandler(null, es))
				return;

			foreach (Events.ResourceContainer e in es)
			{
				if (e.HasFileDescriptor)
				{
					Interfaces.Files.IPackedFileDescriptor pfd =
						(Interfaces.Files.IPackedFileDescriptor)
							e.Resource.FileDescriptor.Clone();

					pfd.UserData = es
						.LoadedPackage.Package.Read(e.Resource.FileDescriptor)
						.UncompressedData;
					es.LoadedPackage.Package.Add(pfd, true);
				}
			}
		}

		#endregion

		#region IToolPlugin Member

		public override string ToString()
		{
			return "Clone";
		}

		#endregion

		#region IToolExt Member
		public override System.Drawing.Image Icon => GetIcon.actionClone;

		public override System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.ShiftIns;
		#endregion
	}
}
