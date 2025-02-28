// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Interfaces;

namespace SimPe.Collections
{
	internal class InternalListeners : Listeners
	{
		internal InternalListeners()
			: base() { }

		internal void Add(IListener lst)
		{
			list.Add(lst);
		}

		internal void Clear()
		{
			list.Clear();
		}
	}
}
