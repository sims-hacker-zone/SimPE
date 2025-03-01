// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for PackedFileItem.
	/// </summary>
	public class NmapItem : Packages.PackedFileDescriptor
	{
		Nmap parent;

		public NmapItem(Nmap parent)
		{
			this.parent = parent;
		}

		public override string ToString()
		{
			string name =
				Filename
				+ ": 0x"
				+ Helper.HexString(Group)
				+ " - 0x"
				+ Helper.HexString(Instance);
			return name;
		}
	}
}
