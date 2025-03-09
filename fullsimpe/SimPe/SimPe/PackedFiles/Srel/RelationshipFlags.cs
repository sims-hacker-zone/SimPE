// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Data;

namespace SimPe.PackedFiles.Srel
{
	public class RelationshipFlags : FlagBase
	{
		public RelationshipFlags(ushort flags)
			: base(flags) { }

		public bool IsEnemy
		{
			get => GetBit((byte)MetaData.RelationshipStateBits.Enemy);
			set => SetBit((byte)MetaData.RelationshipStateBits.Enemy, value);
		}

		public bool IsFriend
		{
			get => GetBit((byte)MetaData.RelationshipStateBits.Friends);
			set => SetBit((byte)MetaData.RelationshipStateBits.Friends, value);
		}

		public bool IsBuddie
		{
			get => GetBit((byte)MetaData.RelationshipStateBits.Buddies);
			set => SetBit((byte)MetaData.RelationshipStateBits.Buddies, value);
		}

		public bool HasCrush
		{
			get => GetBit((byte)MetaData.RelationshipStateBits.Crush);
			set => SetBit((byte)MetaData.RelationshipStateBits.Crush, value);
		}

		public bool InLove
		{
			get => GetBit((byte)MetaData.RelationshipStateBits.Love);
			set => SetBit((byte)MetaData.RelationshipStateBits.Love, value);
		}

		public bool GoSteady
		{
			get => GetBit((byte)MetaData.RelationshipStateBits.Steady);
			set => SetBit((byte)MetaData.RelationshipStateBits.Steady, value);
		}

		public bool IsEngaged
		{
			get => GetBit((byte)MetaData.RelationshipStateBits.Engaged);
			set => SetBit((byte)MetaData.RelationshipStateBits.Engaged, value);
		}

		public bool IsMarried
		{
			get => GetBit((byte)MetaData.RelationshipStateBits.Married);
			set => SetBit((byte)MetaData.RelationshipStateBits.Married, value);
		}

		public bool IsFamilyMember
		{
			get => GetBit((byte)MetaData.RelationshipStateBits.Family);
			set => SetBit((byte)MetaData.RelationshipStateBits.Family, value);
		}

		public bool IsKnown
		{
			get => GetBit((byte)MetaData.RelationshipStateBits.Known);
			set => SetBit((byte)MetaData.RelationshipStateBits.Known, value);
		}
	}
}
