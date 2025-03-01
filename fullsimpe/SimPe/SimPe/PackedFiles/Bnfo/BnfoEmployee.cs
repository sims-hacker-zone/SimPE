// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace SimPe.PackedFiles.Bnfo
{
	public class BnfoEmployee
	{
		/// <summary>
		/// The Sim instance of the employee
		/// </summary>
		public ushort SimInstance
		{
			get; set;
		}
		/// <summary>
		/// The pay rate of the employee
		/// </summary>
		public BnfoEmployeePayRate PayRate
		{
			get; set;
		}
		/// <summary>
		/// What amount the game considers as "Fairly Paid"
		/// According to the formula:
		/// 15 base
		/// + 1 per skill point
		/// + 5 per bronze talent badge
		/// + 10 per silver talent badge
		/// + 15 per golden talent badge
		/// (+ 70 when manager, but this doesn't work due to a bug in the game)
		/// </summary>
		public uint FairPay
		{
			get; set;
		}

		public BnfoEmployee(System.IO.BinaryReader reader)
		{
			Unserialize(reader);
		}

		public BnfoEmployee()
		{
		}

		public void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(SimInstance);
			writer.Write((uint)PayRate);
			writer.Write(FairPay);
		}

		public void Unserialize(System.IO.BinaryReader reader)
		{
			SimInstance = reader.ReadUInt16();
			PayRate = (BnfoEmployeePayRate)reader.ReadUInt32();
			FairPay = reader.ReadUInt32();
		}
	}
}
