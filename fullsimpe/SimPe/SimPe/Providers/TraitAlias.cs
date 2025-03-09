// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Providers
{
	public class TraitAlias
	{
		public string Name
		{
			get;
		}

		public ulong Id
		{
			get;
		}

		public TraitAlias(ulong id, string name)
		{
			Id = id;
			Name = name;
		}

		public override string ToString()
		{
			return Helper.WindowsRegistry.Config.HiddenMode ? Name + $" (0x{Id:X16})" : Name;
		}
	}
}
