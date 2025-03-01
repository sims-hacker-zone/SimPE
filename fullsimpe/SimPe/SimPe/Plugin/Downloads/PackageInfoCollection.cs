// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections;

namespace SimPe.Plugin.Downloads
{
	/// <summary>
	/// Summary description for PackageInfoCollection.
	/// </summary>
	public class PackageInfoCollection
		: System.IDisposable,
			IEnumerable
	{
		ArrayList list;

		public PackageInfoCollection()
		{
			list = new ArrayList();
		}

		public int Count => list.Count;

		public void Clear()
		{
			list.Clear();
		}

		public void Add(IPackageInfo item)
		{
			list.Add(item);
		}

		public void AddRange(IPackageInfo[] items)
		{
			list.AddRange(items);
		}

		public void AddRange(PackageInfoCollection items)
		{
			foreach (PackageInfo item in items)
			{
				list.Add(item);
			}
		}

		public void Remove(IPackageInfo item)
		{
			list.Remove(item);
		}

		public bool Contains(IPackageInfo item)
		{
			return list.Contains(item);
		}

		public IPackageInfo this[int index]
		{
			get => list[index] as IPackageInfo;
			set => list[index] = value;
		}

		public IPackageInfo[] ToArray()
		{
			IPackageInfo[] ret = new IPackageInfo[list.Count];
			list.CopyTo(ret);
			return ret;
		}

		#region IDisposable Member

		public void Dispose()
		{
			list?.Clear();

			list = null;
		}

		#endregion

		#region IEnumerable Member

		public IEnumerator GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion
	}
}
