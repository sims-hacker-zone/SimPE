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

namespace SimPe.Wants
{
    public class WrapperFactory : AbstractWrapperFactory
    {
        /// <summary>
        /// Returns a list of supported File Wrappers
        /// </summary>
        /// <returns>A List of all provided Plugins (=FileType Wrappers)</returns>
        public override IWrapper[] KnownWrappers
        {
            get
            {
                if (Helper.StartedGui == Executable.Classic)
                {
                    return new IWrapper[0];
                }
                else
                {
                    return new IWrapper[] {
                    new SWAFWrapper(),
                    new XWNTWrapper(),};
                }
            }
        }
    }
}
