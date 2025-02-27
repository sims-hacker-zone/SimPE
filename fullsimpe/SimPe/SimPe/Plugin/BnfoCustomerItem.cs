using System;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for BnfoCustomerItem.
	/// </summary>
	public class BnfoCustomerItem
	{
		ushort siminst;
		public ushort SimInstance
		{
			get
			{
				return siminst;
			}
			set
			{
				siminst = value;
				sdsc = null;
			}
		}

		public int LoyaltyScore
		{
			get
			{
				return LoadedLoyalty;
			}
			set
			{
				LoadedLoyalty = value;
			}
		}

		public int LoyaltyStars
		{
			get
			{
				return (int)Math.Ceiling((float)LoyaltyScore / 200.0);
			}
			set
			{
				LoyaltyScore = (value * 200);
			}
		}

		int lloyalty;
		public int LoadedLoyalty
		{
			get; set;
		}

		internal byte[] Data
		{
			get; private set;
		}

		Bnfo parent;
		PackedFiles.Wrapper.ExtSDesc sdsc;
		public PackedFiles.Wrapper.ExtSDesc SimDescription
		{
			get
			{
				if (sdsc == null)
				{
					sdsc =
						FileTable.ProviderRegistry.SimDescriptionProvider.SimInstance[
							SimInstance
						] as PackedFiles.Wrapper.ExtSDesc;
				}

				return sdsc;
			}
		}

		internal BnfoCustomerItem(Bnfo parent)
		{
			this.parent = parent;
			Data = new byte[0x60];
		}

		long endpos;

		internal void Unserialize(System.IO.BinaryReader reader)
		{
			SimInstance = reader.ReadUInt16();
			LoadedLoyalty = reader.ReadInt32();
			Data = reader.ReadBytes(Data.Length);
			lloyalty = reader.ReadInt32();
			endpos = reader.BaseStream.Position;
		}

		internal void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(siminst);
			writer.Write(LoadedLoyalty);
			writer.Write(Data);
			writer.Write(this.LoyaltyStars);
		}

		public override string ToString()
		{
			string s = "";
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
				s = SimPe.Localization.GetString("Unknown");
			}

			if (Helper.WindowsRegistry.HiddenMode)
			{
				return s
					+ " (0x"
					+ Helper.HexString(SimInstance)
					+ "): "
					+ " "
					+ LoadedLoyalty.ToString()
					+ " ("
					+ this.LoyaltyStars.ToString()
					+ ")";
			}
			else
			{
				return s + ": " + " " + this.LoyaltyStars.ToString();
			}
		}
	}
}
