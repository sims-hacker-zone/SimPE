// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

namespace Sims.GUID
{
	/// <summary>
	/// An Item In the Object ListBox
	/// </summary>
	public class ObjectListItem
	{
		internal ObjectListItem(uint guid, string name)
		{
			this.guid = guid;
			this.name = name;
		}

		uint guid;
		public uint GUID
		{
			get { return guid; }
			set { guid = value; }
		}

		string name;
		public string Name
		{
			set { name = value; }
		}

		public override string ToString()
		{
			return name + " (0x" + guid.ToString("X") + ")";
		}
	}
}
