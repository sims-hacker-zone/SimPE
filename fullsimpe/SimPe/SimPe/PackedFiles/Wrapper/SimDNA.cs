// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

using SimPe.Data;
using SimPe.Extensions;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Cpf;

namespace SimPe.PackedFiles.Wrapper
{
	public class Gene : Serializer
	{
		Cpf.Cpf dna;
		uint b;

		internal Gene(Cpf.Cpf dna, uint b)
		{
			this.dna = dna;
			this.b = b;
		}

		string GetName(uint line)
		{
			line += b;
			if (b == 0x10000005)
			{
				b = 4;
			}

			if (b == 0x10000007)
			{
				b = 10;
			}

			return line.ToString();
		}

		string GetItem(uint line)
		{
			return dna.GetSaveItem(GetName(line)).StringValue;
		}

		void SetItem(uint line, string val)
		{
			string name = GetName(line);
			CpfItem i = dna.GetItem(name);
			if (i == null)
			{
				i = new CpfItem
				{
					Name = name
				};
				dna.AddItem(i, false);
			}

			i.StringValue = val;
		}

		public string Hair
		{
			get => GetItem(1);
			set => SetItem(1, value);
		}

		public string SkintoneRange
		{
			get => GetItem(2);
			set => SetItem(2, value);
		}

		public string Eye
		{
			get => GetItem(3);
			set => SetItem(3, value);
		}

		public string FacialFeature
		{
			get => GetItem(5);
			set => SetItem(5, value);
		}

		public string Skintone
		{
			get => GetItem(6);
			set => SetItem(6, value);
		}

		internal string Description => Serialize(this);
	}

	/// <summary>
	/// Contains the SimDNA Data
	/// </summary>
	public class SimDNA : Cpf.Cpf
	{
		public SimDNA()
			: base()
		{
			Dominant = new Gene(this, 0);
			Recessive = new Gene(this, 0x10000000);
		}

		public Gene Dominant
		{
			get;
		}

		public Gene Recessive
		{
			get;
		}

		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new UserInterface.SimDNAUI();
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Sim DNA Wrapper",
				"Quaxi",
				"This File contains the DNA of a Sim.",
				1,
				System.Drawing.Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.dna.png")
				)
			);
		}

		public override byte[] FileSignature => new byte[0];

		public override FileTypes[] AssignableTypes => new FileTypes[] { FileTypes.SDNA };

		public override string DescriptionHeader
		{
			get
			{
				System.Collections.ArrayList list = new System.Collections.ArrayList
				{
					"Dominant " + Serializer.SerializeTypeHeader(Dominant),
					"Recessive " + Serializer.SerializeTypeHeader(Recessive)
				};

				return Serializer.ConcatHeader(Serializer.ConvertArrayList(list));
			}
		}

		public override string Description
		{
			get
			{
				System.Collections.ArrayList list = new System.Collections.ArrayList
				{
					Dominant.ToString("Dominant"),
					Recessive.ToString("Recessive")
				};

				return Serializer.Concat(Serializer.ConvertArrayList(list));
			}
		}

		protected override string GetResourceName(FileTypeInformation fti)
		{
			return !(FileTableBase.ProviderRegistry.SimDescriptionProvider.FindSim(
					(ushort)FileDescriptor.Instance
				) is ExtSDesc sdsc)
				? base.GetResourceName(fti)
				: sdsc.SimName + " " + sdsc.SimFamilyName + " (DNA)";
		}
	}
}
