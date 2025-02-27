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
namespace SimPe.Interfaces
{
	/// <summary>
	/// The Interface for custom Settsings
	/// </summary>
	public interface ISettings
	{
		/// <remarks>
		/// This is explicit listed in the Interface description, as you should return a String (best would be Name)
		/// that identifies the Topic. This will resemble the Menuname
		/// </remarks>
		/// <summary>Returns a short describing String</summary>
		/// <returns>A Describing String for the Wrapper</returns>
		string ToString();

		/// <summary>
		/// a 32x32 Image, that is displayed as an Icon for this Custom Setting
		/// </summary>
		/// <returns>null or a valid Image</returns>
		System.Drawing.Image Icon
		{
			get;
		}

		/// <summary>
		/// Called whenever the Settings get displayed. The Object is passed to a PropertyGrid,
		/// which means, that all public properties of that Object can be changed by the Users.
		/// </summary>
		/// <returns>Object that contains the Settings provided to the Users</returns>
		/// <remarks>See <see cref="System.ComponentModel.Category"/>,
		/// <see cref="System.ComponentModel.Description"/>, <see cref="System.ComponentModel.ReadOnly"/>
		/// and <see cref="System.ComponentModel.Browsable"/> for further Options</remarks>
		object GetSettingsObject();

		/*/// <summary>
		/// Called when you shoudl make the Settings persistent, like storing the to Disc
		/// </summary>
		/// <param name="o">The settings Object, that needs to get saved (this is an Object
		/// generated by a call to <see cref="GetSettingsObject"/>.</param>
		void SaveSettings(object o);*/
	}
}
