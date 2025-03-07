// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.PackedFiles.Nmap
{
	/// <summary>
	/// Summary description for PackedFileItem.
	/// </summary>
	public class NmapItem : Packages.PackedFileDescriptor
	{

		public NmapItem(Nmap parent)
		{
			Parent = parent;
		}

		public Nmap Parent
		{
			get;
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
