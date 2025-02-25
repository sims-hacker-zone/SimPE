/***************************************************************************
 *   Copyright (C) 2006 by Peter L Jones                                   *
 *   pljones@users.sf.net                                                  *
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
using System.Globalization;
using System.Resources;
using System.Threading;

namespace pjse
{
	/// <summary>
	/// Supports the Localization
	/// </summary>
	public class Localization
	{
		/// <summary>
		/// The ResourceManager singleton object
		/// </summary>
		private static ResourceManager resource = null;

		/// <summary>
		/// Initializes the ResourceManager
		/// </summary>
		private static void Initialize()
		{
			resource = new ResourceManager(typeof(pjse.Localization));
		}

		/// <summary>
		/// Returns the current Resource Manager
		/// </summary>
		private static ResourceManager Manager
		{
			get
			{
				if (resource == null)
					Initialize();
				return resource;
			}
		}

		/// <summary>
		/// Returns a translated String
		/// </summary>
		/// <param name="name">string to translate</param>
		/// <returns>translated string</returns>
		/// <remarks>If there is no Translation, the passsed string will be returned</remarks>
		public static string GetString(string name)
		{
			string res = pjse.Localization.Manager.GetString(name);
			if (res == null)
				res = name;
			return res;
		}

		/// <summary>
		/// Returns a translated String with parameter substitution
		/// </summary>
		/// <param name="name">string to translate</param>
		/// <returns>translated string</returns>
		/// <remarks>If there is no Translation, the passsed string will be returned</remarks>
		public static string GetString(string name, params object[] args)
		{
			string res = pjse.Localization.Manager.GetString(name);
			if (res == null)
				res = name;
			for (int i = 0; i < args.Length; i++)
				res = res.Replace("{" + i.ToString() + "}", args[i].ToString());

			return res;
		}
	}
}
