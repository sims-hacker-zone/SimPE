// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace Ambertation.Windows.Forms
{
	public interface IControlRenderer
	{
		BaseRenderer Parent { get; }
		IColorTable ColorTable { get; }
	}
}
