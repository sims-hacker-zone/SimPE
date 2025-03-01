// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;

using SimPe.Data;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Wrapper.Supporting;

namespace SimPe.PackedFiles.Wrapper
{
	/// <summary>
	/// Represents a PackedFile in Fami Format
	/// </summary>
	public class FamilyTies : AbstractWrapper, IFileWrapper, IFileWrapperSaveExtension
	{
		/// <summary>
		/// Returns the Name Provider
		/// </summary>
		internal Interfaces.Providers.ISimNames NameProvider
		{
			get;
		}

		#region Attributes
		/// <summary>
		/// Contains al stored sims as FamilyTieSim Objects
		/// </summary>
		ArrayList sims;

		/// <summary>
		/// Returns/Sets all stored Sims
		/// </summary>
		public FamilyTieSim[] Sims
		{
			get
			{
				FamilyTieSim[] simlist = new FamilyTieSim[sims.Count];
				sims.CopyTo(simlist);
				return simlist;
			}
			set
			{
				sims.Clear();
				foreach (FamilyTieSim sim in value)
				{
					sims.Add(sim);
				}
			}
		}

		#endregion

		#region IWrapper Member
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo("Family Ties Wrapper", "Quaxi", "---", 1);
		}
		#endregion

		#region AbstractWrapper Member
		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new UserInterface.FamilyTies();
		}

		public FamilyTies(Interfaces.Providers.ISimNames names)
			: base()
		{
			NameProvider = names;
			sims = new ArrayList();
		}

		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			uint id = reader.ReadUInt32();
			if (id != 0x00000001)
			{
				throw new Exception(
					"File is not Recognized by the Family Ties Wrapper!"
				);
			}

			int count = reader.ReadInt32();
			sims = new ArrayList(count);

			for (int i = 0; i < count; i++)
			{
				ushort instance = reader.ReadUInt16();
				int blockdel = reader.ReadInt32();
				FamilyTieItem[] items = new FamilyTieItem[reader.ReadInt32()];
				for (int k = 0; k < items.Length; k++)
				{
					MetaData.FamilyTieTypes type = (MetaData.FamilyTieTypes)
						reader.ReadUInt32();
					ushort tinstance = reader.ReadUInt16();
					items[k] = new FamilyTieItem(type, tinstance, this);
				}
				FamilyTieSim simtie = new FamilyTieSim(instance, items, this)
				{
					BlockDelimiter = blockdel
				};
				sims.Add(simtie);
			}
		}

		protected override void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(0x00000001);
			writer.Write(sims.Count);

			foreach (FamilyTieSim sim in sims)
			{
				writer.Write(sim.Instance);
				writer.Write(sim.BlockDelimiter);
				writer.Write(sim.Ties.Length);
				foreach (FamilyTieItem tie in sim.Ties)
				{
					writer.Write((uint)tie.Type);
					writer.Write(tie.Instance);
				}
			}
		}
		#endregion

		#region IPackedFileWrapper Member

		public uint[] AssignableTypes
		{
			get
			{
				uint[] Types = { MetaData.FAMILY_TIES_FILE };
				return Types;
			}
		}

		public byte[] FileSignature
		{
			get
			{
				byte[] sig = { };
				return sig;
			}
		}

		#endregion

		/// <summary>
		/// Returns the avaqilable <see cref="FamilyTieSim"/> for the passed Sim
		/// </summary>
		/// <param name="sdsc"></param>
		/// <returns>null or the <see cref="FamilyTieSim"/> for that Sim</returns>
		public FamilyTieSim FindTies(SDesc sdsc)
		{
			if (sdsc == null)
			{
				return null;
			}

			foreach (FamilyTieSim s in sims)
			{
				if (s.Instance == sdsc.Instance)
				{
					return s;
				}
			}

			return null;
		}

		/// <summary>
		/// Returns the available <see cref="FamilyTieSim"/> for the Sim, or creates a new One
		/// </summary>
		/// <param name="sdsc"></param>
		/// <returns>the <see cref="FamilyTieSim"/> for the passed Sim</returns>
		public FamilyTieSim CreateTie(SDesc sdsc)
		{
			FamilyTieSim s = FindTies(sdsc);
			if (s == null)
			{
				s = new FamilyTieSim(sdsc.Instance, new FamilyTieItem[0], this);
				sims.Add(s);
			}
			return s;
		}
	}
}
