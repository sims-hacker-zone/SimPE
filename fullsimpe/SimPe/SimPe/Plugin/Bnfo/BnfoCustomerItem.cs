// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

namespace SimPe.Plugin.Bnfo
{
	/// <summary>
	/// Summary description for BnfoCustomerItem.
	/// </summary>
	public class BnfoCustomerItem
	{
		public ushort SimInstance
		{
			get;
			set;
		}

		public int LoyaltyScore
		{
			get => LoadedLoyalty;
			set => LoadedLoyalty = value;
		}

		public int LoyaltyStars
		{
			get => (int)Math.Ceiling(LoyaltyScore / 200.0);
			set => LoyaltyScore = value * 200;
		}

		public int LoadedLoyalty
		{
			get; set;
		}

		internal byte[] Data
		{
			get; private set;
		} = new byte[0x60];

		private readonly Bnfo parent;
		public PackedFiles.Wrapper.ExtSDesc SimDescription => FileTableBase.ProviderRegistry.SimDescriptionProvider.SimInstance[SimInstance] as PackedFiles.Wrapper.ExtSDesc;

		internal BnfoCustomerItem(Bnfo parent)
		{
			this.parent = parent;
		}


		internal void Unserialize(System.IO.BinaryReader reader)
		{
			SimInstance = reader.ReadUInt16();
			LoadedLoyalty = reader.ReadInt32();
			Data = reader.ReadBytes(Data.Length);
			LoyaltyStars = reader.ReadInt32();
		}

		internal void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(SimInstance);
			writer.Write(LoadedLoyalty);
			writer.Write(Data);
			writer.Write(LoyaltyStars);
		}

		public override string ToString()
		{
			string s;
			if (SimDescription != null)
			{
				s = SimDescription.SimName + " " + SimDescription.SimFamilyName;
				if (SimDescription.CharacterDescription.NPCType == 41)
				{
					s += " [Reporter]";
				}
			}
			else
			{
				s = Localization.GetString("Unknown");
			}

			return Helper.WindowsRegistry.HiddenMode
				? s
					+ " (0x"
					+ Helper.HexString(SimInstance)
					+ "): "
					+ " "
					+ LoadedLoyalty.ToString()
					+ " ("
					+ LoyaltyStars.ToString()
					+ ")"
				: s + ": " + " " + LoyaltyStars.ToString();
		}
	}
}
