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
using SimPe.Interfaces;
using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Wrapper.Factory
{
	/// <summary>
	/// The Wrapper Factory for Default Wrappers that ship with SimPe
	/// </summary>
	public class DefaultWrapperFactory : AbstractWrapperFactory
	{
		#region AbstractWrapperFactory Member
		public override IWrapper[] KnownWrappers
		{
			get
			{
				if (Helper.NoPlugins)
				{
					return new IWrapper[0];
				}
				if (Helper.StartedGui == Executable.Classic)
				{
					IWrapper[] wrappers =
					{
						new Picture(),
						new Xml(),
						new Fami(
							LinkedProvider.SimNameProvider
						),
						new SRel(),
						new Cpf(),
						new FamilyTies(
							LinkedProvider.SimNameProvider
						),
						new Nref(),
						new Objd(
							LinkedProvider.OpcodeProvider
						),
						new Plugin.Glob(),
						new ObjLua(),
						new CompressedFileList(),
						new Str(),
					};
					return wrappers;
				}
				else
				{
					IWrapper[] wrappers =
					{

					};
					return wrappers;
				}
			}
		}

		#endregion
	}
}
