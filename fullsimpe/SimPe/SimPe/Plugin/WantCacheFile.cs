// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
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
