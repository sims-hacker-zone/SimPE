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
using System.Collections;
using System.IO;
using SimPe;
using SimPe.Plugin;

namespace SimPe.Cache
{
	/// <summary>
	/// Contains an Instance of a CacheFile
	/// </summary>
	public class GoalCacheFile : CacheFile
	{
		/// <summary>
		/// Creaet a new Instance for an empty File
		/// </summary>
		public GoalCacheFile()
			: base()
		{
			DEFAULT_TYPE = ContainerType.Goal;
		}

		/// <summary>
		/// Add a Goal Item to the Cache
		/// </summary>
		/// <param name="goal">The Goal File</param>
		public void AddItem(GoalInformation goal)
		{
			CacheContainer mycc = this.UseConatiner(
				ContainerType.Goal,
				goal.XGoal.Package.FileName
			);

			GoalCacheItem wci = new GoalCacheItem();
			wci.FileDescriptor = goal.XGoal.FileDescriptor;
			wci.Guid = goal.Guid;
			wci.Icon = goal.Icon;
			wci.Influence = goal.XGoal.Influence;
			wci.Name = goal.Name;
			wci.Score = goal.XGoal.Score;

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
					LoadGoals();
				return map;
			}
		}

		public void LoadGoals()
		{
			map = new Hashtable();

			foreach (CacheContainer cc in Containers)
			{
				if (cc.Type == ContainerType.Goal && cc.Valid)
				{
					foreach (GoalCacheItem wci in cc.Items)
					{
						map[wci.Guid] = wci;
					}
				}
			} //foreach
		}
	}
}
