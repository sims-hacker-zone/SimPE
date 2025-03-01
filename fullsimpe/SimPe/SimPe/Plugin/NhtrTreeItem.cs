// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for TileItem.
	/// </summary>
	public class NhtrTreeItem : NhtrDecorationItem
	{
		internal NhtrTreeItem(NhtrList parent)
			: base(parent) { }

		protected override void DoUnserialize(System.IO.BinaryReader reader)
		{
			rot = reader.ReadSingle();
			guid = reader.ReadUInt32();
		}

		protected override void DoSerialize(System.IO.BinaryWriter writer)
		{
			writer.Write(rot);
			writer.Write(guid);
		}
	}
}
