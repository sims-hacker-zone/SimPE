// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.ObjectModel;
using System.IO;

using CommunityToolkit.Mvvm.ComponentModel;

namespace SimPe.Models.PackedFile.Ttab
{
	public partial class TtabItem(Ttab parent) : ObservableObject
	{
		[ObservableProperty]
		private Ttab parent = parent;

		[ObservableProperty]
		private ushort action;

		[ObservableProperty]
		private ushort guard;

		[ObservableProperty]
		private ObservableCollection<uint> counts = [];

		[ObservableProperty]
		private ushort flags;
		[ObservableProperty]
		private ushort flags2;
		[ObservableProperty]
		private uint strIndex;
		[ObservableProperty]
		private uint attenuationCode;
		[ObservableProperty]
		private float attenuationValue;
		[ObservableProperty]
		private uint autonomy;
		[ObservableProperty]
		private uint joinIndex;
		[ObservableProperty]
		private ushort uIDisplayType;
		[ObservableProperty]
		private uint facialAnimation;
		[ObservableProperty]
		private float memoryIterMult;
		[ObservableProperty]
		private uint objectType;
		[ObservableProperty]
		private uint modelTableID;
		[ObservableProperty]
		private TtabItemMotiveHumanTable humanGroups;
		[ObservableProperty]
		private TtabItemMotiveAnimalTable animalGroups;

		public static TtabItem Unserialize(BinaryReader reader, Ttab parent)
		{
			TtabItem item = new(parent)
			{
				Action = reader.ReadUInt16(),
				Guard = reader.ReadUInt16()
			};

			if (parent.Version < 0x44)
			{
				item.Counts.Add(reader.ReadUInt32());
			}
			else if (parent.Version < 0x54)
			{
				for (int i = 0; i < 7; i++)
				{
					item.Counts.Add(reader.ReadUInt32());
				}
			}

			item.Flags = reader.ReadUInt16();
			item.Flags2 = reader.ReadUInt16();

			item.StrIndex = reader.ReadUInt32();
			item.AttenuationCode = reader.ReadUInt32();
			item.AttenuationValue = reader.ReadSingle();
			item.Autonomy = reader.ReadUInt32();
			item.JoinIndex = reader.ReadUInt32();

			if (parent.Version >= 0x45)
			{
				item.UIDisplayType = reader.ReadUInt16();
				if (parent.Version >= 0x46)
				{
					if (parent.Version >= 0x4a)
					{
						item.FacialAnimation = reader.ReadUInt32();
						if (parent.Version >= 0x4c)
						{
							item.MemoryIterMult = reader.ReadSingle();
							item.ObjectType = reader.ReadUInt32();
						}
					}
					item.ModelTableID = reader.ReadUInt32();
				}
			}

			return item;
		}

		public override string ToString()
		{
			return $"[TTAB Item]";
		}
	}
}
