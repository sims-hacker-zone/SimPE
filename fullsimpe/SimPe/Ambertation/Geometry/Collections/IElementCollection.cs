// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections;

namespace Ambertation.Geometry.Collections
{
	public interface IElementCollection : IEnumerable
	{
		int Count { get; }

		void Add(object v);

		object GetItem(int index);

		void SetItem(int index, object o);
	}
}
