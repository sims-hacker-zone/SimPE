// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using Ambertation.Collections;

namespace Ambertation.Windows.Forms.Graph
{
	/// <summary>
	/// This is an Item you can add to a <see cref="GraphPanel"/>.
	/// </summary>
	public class GraphItem : PropertyPanel
	{
		public GraphItem()
			: this(new PropertyItems()) { }

		public GraphItem(PropertyItems properties)
			: base(properties) { }
	}
}
