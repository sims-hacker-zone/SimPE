// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace Ambertation.Windows.Forms.Graph
{
	/// <summary>
	/// Contains a Property
	/// </summary>
	public class PropertyItem
	{
		public string Name
		{
			get;
		}

		public object Value
		{
			get; set;
		}

		public PropertyItem(string name, object val)
		{
			Name = name;
			Value = val;
		}
	}
}
