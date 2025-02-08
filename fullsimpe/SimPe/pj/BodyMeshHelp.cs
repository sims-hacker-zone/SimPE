/***************************************************************************
 *   Copyright (C) 2005 by Peter L Jones                                   *
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
using System;
using SimPe.Interfaces;

namespace pj
{
    class BodyMeshHelp : IHelp
    {
        #region IHelp Members

        public void ShowHelp(SimPe.ShowHelpEventArgs e)
        {
#if NET1
			string relativePathToHelp = "pjBodyMeshTool_NET1.plugin/pjBodyMeshTool_Help";
#else
			string relativePathToHelp = "pjBodyMeshTool.plugin/pjBodyMeshTool_Help";
#endif
			SimPe.RemoteControl.ShowHelp("file://" + SimPe.Helper.SimPePluginPath + "/" + relativePathToHelp + "/Contents.htm");
        }

        public override string ToString() { return L.Get("pjBMTHelp"); }

        public System.Drawing.Image Icon { get { return null; } }

        #endregion
    }
}
