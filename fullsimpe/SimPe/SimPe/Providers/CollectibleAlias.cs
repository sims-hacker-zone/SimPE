// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Providers
{
	public class CollectibleAlias
	{
		public string Name
		{
			get;
		}

		public ulong Id
		{
			get;
		}

		public int Nr
		{
			get;
		}

		public System.Drawing.Image Image
		{
			get;
		}

		public CollectibleAlias(ulong id, int nr, string name, System.Drawing.Image img)
		{
			Id = id;
			Nr = nr;
			Name = name;
			if (img == null)
			{
				img = new System.Drawing.Bitmap(32, 32);
			}
			Image = img;
		}

		public override string ToString()
		{
			return Helper.WindowsRegistry.HiddenMode ? Name + " (0x" + Helper.HexString(Id) + ", " + Nr + ")" : Name;
		}
	}
}
