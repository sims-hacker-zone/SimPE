// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace Ambertation.Scenes.Collections
{
	public class JointCollectionBase : NodeCollectionBase
	{
		public Joint this[int index] => GetItem(index) as Joint;

		public Joint this[string name] => GetItem(name) as Joint;
	}
}
