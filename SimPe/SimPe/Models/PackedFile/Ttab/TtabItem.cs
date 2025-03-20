// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Data;
using SimPe.Extensions;
using SimPe.Models.PackedFile.Str;

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
		private EnumDisplayNameItem<AttenuationCode> attenuationCode;
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
			item.AttenuationCode = new((AttenuationCode)reader.ReadUInt32());
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

			item.HumanGroups = TtabItemMotiveHumanTable.Unserialize(reader, item);
			if (parent.Version >= 0x54)
			{
				item.AnimalGroups = TtabItemMotiveAnimalTable.Unserialize(reader, item);
			}

			return item;
		}

		public void Serialize(BinaryWriter writer)
		{
			writer.Write(Action);
			writer.Write(Guard);

			if (Parent.Version < 0x44)
			{
				if (!Counts.Any())
				{
					Counts.Add(16);
				}
				writer.Write(Counts[0]);
			}
			else if (Parent.Version < 0x54)
			{
				if (Counts.Count < 7)
				{
					for (int i = Counts.Count; i < 7; i++)
					{
						Counts.Add(16);
					}
				}
				for (int i = 0; i < 7; i++)
				{
					writer.Write(Counts[i]);
				}
			}

			writer.Write(Flags);
			writer.Write(Flags2);
			writer.Write(StrIndex);
			writer.Write((uint)AttenuationCode.Item);
			writer.Write(AttenuationValue);
			writer.Write(Autonomy);
			writer.Write(JoinIndex);

			if (Parent.Version >= 0x45)
			{
				writer.Write(UIDisplayType);
				if (Parent.Version >= 0x46)
				{
					if (Parent.Version >= 0x4A)
					{
						writer.Write(FacialAnimation);
						if (Parent.Version >= 0x4C)
						{
							writer.Write(MemoryIterMult);
							writer.Write(ObjectType);
						}
					}
					writer.Write(ModelTableID);
				}
			}
			HumanGroups.Serialize(writer);
			if (Parent.Version >= 0x54)
			{
				AnimalGroups.Serialize(writer);
			}
		}

		public override string ToString()
		{
			PackedFile ttas_file = Parent.File.Package.FindFile(FileTypes.TTAs, Parent.File.Group, Parent.File.InstanceHigh, Parent.File.Instance);
			ttas_file?.ReadContent();
			ILookup<int, StrItem> index = ((ttas_file?.Wrapper) as Str.Str).ByIndex;
			return index != null && index.Contains((int)StrIndex) && index[(int)StrIndex].Any()
				? index[(int)StrIndex].First().Title
				: "[TTAB Item]";
		}
	}
}
