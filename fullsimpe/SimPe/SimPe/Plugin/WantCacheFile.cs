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
using System.Collections;

using SimPe.Plugin;

namespace SimPe.Cache
{
	/// <summary>
	/// Contains an Instance of a CacheFile
	/// </summary>
	public class WantCacheFile : CacheFile
	{
		/// <summary>
		/// Creaet a new Instance for an empty File
		/// </summary>
		public WantCacheFile()
			: base()
		{
			DEFAULT_TYPE = ContainerType.Want;
		}

		/// <summary>
		/// Add a Want Item to the Cache
		/// </summary>
		/// <param name="want">The Want File</param>
		public void AddItem(WantInformation want)
		{
			CacheContainer mycc = UseConatiner(
				ContainerType.Want,
				want.XWant.Package.FileName
			);

			WantCacheItem wci = new WantCacheItem
			{
				FileDescriptor = want.XWant.FileDescriptor,
				Folder = want.XWant.Folder,
				Guid = want.Guid,
				Icon = want.Icon,
				Influence = want.XWant.Influence,
				Name = want.Name,
				ObjectType = want.XWant.ObjectType,
				Score = want.XWant.Score
			};

			mycc.Items.Add(wci);
		}

		Hashtable map;

		/// <summary>
		/// Return the FileIndex represented by the Cached Files
		/// </summary>
		public Hashtable Map
		{
			get
			{
				if (map == null)
				{
					LoadWants();
				}

				return map;
			}
		}

		public void LoadWants()
		{
			map = new Hashtable();

			foreach (CacheContainer cc in Containers)
			{
				if (cc.Type == ContainerType.Want && cc.Valid)
				{
					foreach (WantCacheItem wci in cc.Items)
					{
						map[wci.Guid] = wci;
					}
				}
			} //foreach
		}
	}
}
