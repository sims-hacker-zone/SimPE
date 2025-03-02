// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.PackedFiles.ThreeIdr
{
	internal class CpfListItem : SkinChain
	{
		private readonly uint category;

		internal CpfListItem(Cpf.Cpf cpf)
			: base(cpf)
		{
			this.cpf = cpf;
			Name = Localization.Manager.GetString("Unknown");
			category = 0;
			if (cpf != null)
			{
				foreach (Cpf.CpfItem citem in cpf.Items)
				{
					if (citem.Name.ToLower() == "name")
					{
						Name = citem.StringValue;
					}
				}

				foreach (Cpf.CpfItem citem in cpf.Items)
				{
					if (citem.Name.ToLower() == "category")
					{
						category = citem.UIntegerValue;
					}
				}
			}

			Name = Name.Replace("CASIE_", "");
		}

		public new string Name
		{
			get;
		}

		internal Cpf.Cpf File => cpf;

		public override string ToString()
		{
			return "0x" + Helper.HexString((ushort)category) + ": " + Name;
		}
	}
}
