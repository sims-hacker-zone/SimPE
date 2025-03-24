// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.ObjectModel;
using System.IO;
using System.Text;

using Avalonia.Controls;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Models.Interfaces;
using SimPe.Views.PackedFile.Scor;

namespace SimPe.Models.PackedFile.Scor
{
	public partial class Scor(PackedFile file) : ObservableObject, IWrapper
	{
		[ObservableProperty]
		private PackedFile file = file;

		[ObservableProperty]
		private uint version;

		[ObservableProperty]
		private ObservableCollection<ScorBusinessReward> businessRewards = [];

		[ObservableProperty]
		private ObservableCollection<ScorLearnedBehavior> learnedBehaviors = [];

		[ObservableProperty]
		private ObservableCollection<ScorBestFriendForeverItem> bestFriendForeverList = [];

		[ObservableProperty]
		private ObservableCollection<ScorWitchName> witchNames = [];
		public UserControl Panel
		{
			get; set;
		}

		public string FriendlyName => null;

		public static Scor Unserialize(BinaryReader reader, PackedFile file)
		{
			Scor scor = new(file)
			{
				Version = reader.ReadUInt32()
			};
			int itemCount = reader.ReadInt32();
			for (int i = 0; i < itemCount; i++)
			{
				ScorType type = (ScorType)reader.ReadUInt32();
				int typeNameLen = reader.ReadInt32();
				_ = Encoding.UTF8.GetString(reader.ReadBytes(typeNameLen));
				switch (type)
				{
					case ScorType.BusinessRewards:
						int rewardCount = reader.ReadInt32();
						for (int j = 0; j < rewardCount; j++)
						{
							scor.BusinessRewards.Add(ScorBusinessReward.Unserialize(reader, scor));
						}
						break;
					case ScorType.LearnedBehavior:
						int behaviorCount = reader.ReadInt32();
						for (int j = 0; j < behaviorCount; j++)
						{
							scor.LearnedBehaviors.Add(ScorLearnedBehavior.Unserialize(reader, scor));
						}
						break;
					case ScorType.BestFriendForeverList:
						int bffCount = reader.ReadInt32();
						for (int j = 0; j < bffCount; j++)
						{
							scor.BestFriendForeverList.Add(ScorBestFriendForeverItem.Unserialize(reader, scor));
						}
						break;
					case ScorType.WitchNames:
						int nameCount = reader.ReadInt32();
						for (int j = 0; j < nameCount; j++)
						{
							scor.WitchNames.Add(ScorWitchName.Unserialize(reader, scor));
						}
						break;
					default:
						break;
				}
			}
			scor.Panel = new ScorPanel { DataContext = scor };
			return scor;
		}

		public void Serialize(BinaryWriter writer)
		{
			throw new System.NotImplementedException();
		}
	}
}
