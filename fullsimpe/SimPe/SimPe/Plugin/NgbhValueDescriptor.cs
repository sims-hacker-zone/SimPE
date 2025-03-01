// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace SimPe.Plugin
{
	public enum NgbhValueDescriptorType : byte
	{
		Skill,
		ToddlerSkill,
		Badge,
	}

	/// <summary>
	/// Describes Skills, and Badges
	/// </summary>
	public class NgbhValueDescriptor
	{
		string name;

		public NgbhValueDescriptor(
			string name,
			bool intern,
			NgbhValueDescriptorType type,
			uint guid,
			int valuenr,
			short min,
			short max,
			int fullnr
		)
			: this(name, intern, type, guid, valuenr, min, max, guid, fullnr) { }

		public NgbhValueDescriptor(
			string name,
			bool intern,
			NgbhValueDescriptorType type,
			uint guid
		)
			: this(name, intern, type, guid, 0, -1, -1, 0xffffffff, -1) { }

		public NgbhValueDescriptor(
			string name,
			bool intern,
			NgbhValueDescriptorType type,
			uint guid,
			int valuenr
		)
			: this(name, intern, type, guid, valuenr, -1, -1, 0xffffffff, -1) { }

		public NgbhValueDescriptor(
			string name,
			bool intern,
			NgbhValueDescriptorType type,
			uint guid,
			int valuenr,
			short min,
			short max
		)
			: this(name, intern, type, guid, valuenr, min, max, 0xffffffff, -1) { }

		NgbhValueDescriptor(
			string name,
			bool intern,
			NgbhValueDescriptorType type,
			uint guid,
			int valuenr,
			short min,
			short max,
			uint fullguid,
			int fullnr
		)
		{
			this.name = name;
			Guid = guid;
			CompletedGuid = fullguid;
			DataNumber = valuenr;
			CompletedDataNumber = fullnr;
			Maximum = max;
			Minimum = min;
			Type = type;
			Intern = intern;
		}

		public bool Intern
		{
			get;
		}

		public NgbhValueDescriptorType Type
		{
			get;
		}

		public bool HasComplededFlag => CompletedDataNumber >= 0;

		uint CompletedGuid
		{
			get;
		}

		public uint Guid
		{
			get;
		}

		public int CompletedDataNumber
		{
			get;
		}

		public int DataNumber
		{
			get;
		}

		public short Minimum
		{
			get;
		}

		public short Maximum
		{
			get;
		}

		public override string ToString()
		{
			return name;
		}
	}
}
