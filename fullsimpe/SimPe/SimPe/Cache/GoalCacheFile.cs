// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections;

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
			CacheContainer mycc = UseConatiner(
				ContainerType.Goal,
				goal.XGoal.Package.FileName
			);

			GoalCacheItem wci = new GoalCacheItem
			{
				FileDescriptor = goal.XGoal.FileDescriptor,
				Guid = goal.Guid,
				Icon = goal.Icon,
				Influence = goal.XGoal.Influence,
				Name = goal.Name,
				Score = goal.XGoal.Score
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
					LoadGoals();
				}

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
