// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.Extensions;

namespace SimPe.Models.PackedFile.Scor
{
	public enum ScorType : uint
	{
		[DisplayName("Business Rewards")]
		BusinessRewards = 1,
		[DisplayName("Learned Behavior")]
		LearnedBehavior = 3,
		[DisplayName("Best Friend Forever List")]
		BestFriendForeverList = 5,
		[DisplayName("WitchNames")]
		WitchNames = 7
	}
}
