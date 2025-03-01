// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace Ambertation.Windows.Forms
{
	public abstract class BaseControlRenderer
	{
		private BaseRenderer parent;

		public BaseRenderer Parent => parent;

		public IColorTable ColorTable
		{
			get
			{
				if (parent == null)
				{
					return null;
				}

				return parent.ColorTable;
			}
		}

		public BaseControlRenderer(BaseRenderer parent)
		{
			this.parent = parent;
		}
	}
}
