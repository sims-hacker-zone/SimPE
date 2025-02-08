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
using System;
using SimPe.Interfaces;
using SimPe.Interfaces.Plugin;

namespace pjHoodTool
{
    class tObjKeyTool : AbstractWrapperFactory, IToolFactory, IHelpFactory, ICommandLineFactory
    {
        #region IToolFactory Members
        public IToolPlugin[] KnownTools { get { return new IToolPlugin[] { new cHoodTool() }; } }
        #endregion

        #region IHelpFactory Members
        public IHelp[] KnownHelpTopics { get { return new IHelp[] { new hHoodHelp() }; } }
        #endregion

        #region ICommandLineFactory Members

        public ICommandLine[] KnownCommandLines
        {
            get { return new ICommandLine[] { new cHoodTool()}; }
        }

        #endregion
    }
}
