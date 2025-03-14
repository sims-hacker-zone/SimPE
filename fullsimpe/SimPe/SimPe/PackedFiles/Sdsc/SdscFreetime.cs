// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.Generic;
using System.IO;

using SimPe.PackedFiles.Wrapper;

namespace SimPe.PackedFiles.Sdsc
{
	/// <summary>
	/// Freetime specific Data
	/// </summary>
	public class SdscFreetime : Serializer
	{
		static IAspirationEditor aspeditor;

		public static void RegisterAsAspirationEditor(IAspirationEditor ed)
		{
			aspeditor = ed;
		}

		internal SdscFreetime(SDesc dsc)
		{
			parent = dsc;
			HobbyEnthusiasm = new List<ushort>();
			decays = new List<ushort>();

			for (int i = 0; i < 11; i++)
			{
				HobbyEnthusiasm.Add(0);
			}

			for (int i = 0; i < 7; i++)
			{
				decays.Add(0);
			}

			predestined = 0;
			LongtermAspiration = 0;
			LongtermAspirationUnlockPoints = 0;
			LongtermAspirationUnlocksSpent = 0;
			BugCollection = 0;
		}

		SDesc parent;
		ushort predestined;
		List<ushort> decays;

		public List<ushort> HobbyEnthusiasm
		{
			get;
		}

		public static ushort HobbiesToIndex(Hobbies hb)
		{
			return (ushort)((ushort)hb - 0xcc);
		}

		public static Hobbies IndexToHobbies(int us)
		{
			return IndexToHobbies((ushort)us);
		}

		public static Hobbies IndexToHobbies(ushort us)
		{
			return (Hobbies)(us + 0xcc);
		}

		public Hobbies HobbyPredistined
		{
			get => (Hobbies)predestined;
			set => predestined = (ushort)value;
		}

		public ushort LongtermAspiration
		{
			get; set;
		}

		public ushort LongtermAspirationUnlockPoints
		{
			get; set;
		}

		public ushort LongtermAspirationUnlocksSpent
		{
			get; set;
		}

		public ushort HungerDecayModifier
		{
			get => decays[0];
			set => decays[0] = value;
		}

		public ushort ComfortDecayModifier
		{
			get => decays[1];
			set => decays[1] = value;
		}

		public ushort BladderDecayModifier
		{
			get => decays[2];
			set => decays[2] = value;
		}

		public ushort EnergyDecayModifier
		{
			get => decays[3];
			set => decays[3] = value;
		}

		public ushort HygieneDecayModifier
		{
			get => decays[4];
			set => decays[4] = value;
		}

		public ushort FunDecayModifier
		{
			get => decays[5];
			set => decays[5] = value;
		}

		public ushort SocialPublicDecayModifier
		{
			get => decays[6];
			set => decays[6] = value;
		}

		public uint BugCollection
		{
			get; set;
		}

		internal void Unserialize(BinaryReader reader)
		{
			reader.BaseStream.Seek(0x1A4, SeekOrigin.Begin);
			for (int i = 0; i < HobbyEnthusiasm.Count; i++)
			{
				HobbyEnthusiasm[i] = reader.ReadUInt16();
			}

			predestined = reader.ReadUInt16();
			LongtermAspiration = reader.ReadUInt16();
			LongtermAspirationUnlockPoints = reader.ReadUInt16();
			LongtermAspirationUnlocksSpent = reader.ReadUInt16();

			for (int i = 0; i < decays.Count; i++)
			{
				decays[i] = reader.ReadUInt16();
			}

			BugCollection = reader.ReadUInt32();

			LoadAspirations();
		}

		internal void Serialize(BinaryWriter writer)
		{
			writer.BaseStream.Seek(0x1A4, SeekOrigin.Begin);

			for (int i = 0; i < HobbyEnthusiasm.Count; i++)
			{
				writer.Write(HobbyEnthusiasm[i]);
			}

			writer.Write(predestined);
			writer.Write(LongtermAspiration);
			writer.Write(LongtermAspirationUnlockPoints);
			writer.Write(LongtermAspirationUnlocksSpent);

			for (int i = 0; i < decays.Count; i++)
			{
				writer.Write(decays[i]);
			}

			writer.Write(BugCollection);

			StoreAspirations();
		}

		Data.AspirationTypes pa;

		protected void LoadAspirations()
		{
			pa = Data.AspirationTypes.Nothing;
			SecondaryAspiration = Data.AspirationTypes.Nothing;
			if (parent == null)
			{
				return;
			}

			pa = parent.CharacterDescription.Aspiration;

			if (aspeditor == null)
			{
				return;
			}

			Data.AspirationTypes[] asps = aspeditor.LoadAspirations(
				parent
			);

			if (asps == null)
			{
				return;
			}

			if (asps.Length > 0)
			{
				pa = asps[0];
			}

			if (asps.Length > 1)
			{
				SecondaryAspiration = asps[1];
			}
		}

		protected void StoreAspirations()
		{
			if (parent == null)
			{
				return;
			}

			if (aspeditor == null)
			{
				return;
			}
			/*
if (pa == SimPe.Data.MetaData.AspirationTypes.Nothing)
{
	pa = SimPe.Data.MetaData.AspirationTypes.Romance;
	sa = SimPe.Data.MetaData.AspirationTypes.Nothing;
}
*/
			Data.AspirationTypes[] asps =
				new Data.AspirationTypes[] { pa, SecondaryAspiration };
			aspeditor.StoreAspirations(asps, parent);
		}

		/// <remarks>
		/// The return value of this attribute is always valid,
		/// no matter which version the loaded SDSC was
		/// </remarks>
		public Data.AspirationTypes PrimaryAspiration
		{
			get => parent == null ? pa : (int)parent.Version >= (int)SDescVersions.Freetime ? pa : parent.CharacterDescription.Aspiration;
			set
			{
				if ((int)parent.Version >= (int)SDescVersions.Freetime)
				{
					pa = value;
				}
				else
				{
					parent.CharacterDescription.Aspiration = value;
				}
			}
		}

		public Data.AspirationTypes SecondaryAspiration
		{
			get; set;
		}
	}
}
