/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
using System;
using System.IO;

using SimPe.Data;
using SimPe.Interfaces.Files;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Wrapper.Supporting;

namespace SimPe.PackedFiles.Wrapper
{
	/// <summary>
	/// known Versions for SDSC Files
	/// </summary>
	public enum SDescVersions : int
	{
		Unknown = 0,
		BaseGame = 0x20,
		University = 0x22,
		Nightlife = 0x29,
		Business = 0x2a,
		Pets = 0x2c,
		Castaway = 0x2d,
		Voyage = 0x2e,
		VoyageB = 0x2f,
		Freetime = 0x33,
		Apartment = 0x36,
	}

	/// <summary>
	/// ...from Text\Live.package
	/// </summary>
	public enum JobAssignment : ushort
	{
		Nothing = 0x00,
		Chef = 0x01,
		Host = 0x02,
		Server = 0x03,
		Cashier = 0x04,
		Bartender = 0x05,
		Barista = 0x06,
		DJ = 0x07,
		SellLemonade = 0x08,
		Stylist = 0x09,
		Tidy = 0x0A,
		Restock = 0x0B,
		Sales = 0x0C,
		MakeToys = 0x0D,
		ArrangeFlowers = 0x0E,
		BuildRobots = 0x0F,
		MakeFood = 0x10,
		Masseuse = 0x11,
		MakePottery = 0x12,
		Sewing = 0x13,
	}

	public enum Hobbies : ushort
	{
		Cuisine = 0xCC,
		Arts = 0xCD,
		Film = 0xCE,
		Sport = 0xCF,
		Games = 0xD0,
		Nature = 0xD1,
		Tinkering = 0xD2,
		Fitness = 0xD3,
		Science = 0xD4,
		Music = 0xD5,
		Secret = 0xD6,
	}

	#region Ghost Flags
	/// <summary>
	/// Ghost Flag class
	/// </summary>
	public class GhostFlags : FlagBase
	{
		public GhostFlags(ushort flags)
			: base(flags) { }

		public GhostFlags()
			: base(0) { }

		public bool IsGhost
		{
			get => GetBit(0);
			set => SetBit(0, value);
		}

		public bool CanPassThroughObjects
		{
			get => GetBit(1);
			set => SetBit(1, value);
		}

		public bool CanPassThroughWalls
		{
			get => GetBit(2);
			set => SetBit(2, value);
		}

		public bool CanPassThroughPeople
		{
			get => GetBit(3);
			set => SetBit(3, value);
		}

		public bool IgnoreTraversalCosts
		{
			get => GetBit(4);
			set => SetBit(4, value);
		}

		public bool CanFlyOverLowObjects
		{
			get => GetBit(5);
			set => SetBit(5, value);
		}

		public bool ForceRouteRecalc
		{
			get => GetBit(6);
			set => SetBit(6, value);
		}

		public bool CanSwimInOcean
		{
			get => GetBit(7);
			set => SetBit(7, value);
		}
	}
	#endregion

	#region Sim Selectable Flags
	/// <summary>
	/// Ghost Flag class
	/// </summary>
	public class SelectableFlags : FlagBase
	{
		public SelectableFlags(ushort flags)
			: base(flags) { }

		public SelectableFlags()
			: base(0) { }

		public bool Selectable
		{
			get => GetBit(0);
			set => SetBit(0, value);
		}

		public bool NotSelectable
		{
			get => GetBit(1);
			set => SetBit(1, value);
		}

		public bool HideRelationships
		{
			get => GetBit(2);
			set => SetBit(2, value);
		}

		public bool HolidayMate
		{
			get => GetBit(3);
			set => SetBit(3, value);
		}
	}
	#endregion

	#region Body Flags
	/// <summary>
	/// Body Flag class
	/// </summary>
	public class BodyFlags : FlagBase
	{
		public BodyFlags(ushort flags)
			: base(flags) { }

		public BodyFlags()
			: base(0) { }

		public bool Fat
		{
			get => GetBit(0);
			set => SetBit(0, value);
		}

		public bool PregnantFull
		{
			get => GetBit(1);
			set => SetBit(1, value);
		}

		public bool PregnantHalf
		{
			get => GetBit(2);
			set => SetBit(2, value);
		}

		public bool PregnantHidden
		{
			get => GetBit(3);
			set => SetBit(3, value);
		}

		public bool Fit
		{
			get => GetBit(4);
			set => SetBit(4, value);
		}

		public bool Hospital
		{
			get => GetBit(5);
			set => SetBit(5, value);
		}

		public bool BirthControl
		{
			get => GetBit(6);
			set => SetBit(6, value);
		}
	}
	#endregion

	#region Cult Flags
	/// <summary>
	/// Cult Flag class
	/// </summary>
	public class CultFlags : FlagBase
	{
		public CultFlags(ushort flags)
			: base(flags) { }

		public CultFlags()
			: base(0) { }

		public bool AllowFamily
		{
			get => GetBit(0);
			set => SetBit(0, value);
		}
		public bool NoAlcohol
		{
			get => GetBit(1);
			set => SetBit(1, value);
		}
		public bool NoAutoWoohoo
		{
			get => GetBit(2);
			set => SetBit(2, value);
		}
		public bool MarkedSim
		{
			get => GetBit(3);
			set => SetBit(3, value);
		}
		public bool NotUsedf
		{
			get => GetBit(4);
			set => SetBit(4, value);
		}
	}

	#endregion

	#region Pet Traits
	/// <summary>
	/// Flags for PetTraits
	/// </summary>
	public class PetTraits : FlagBase
	{
		public PetTraits(ushort flags)
			: base(flags) { }

		public PetTraits()
			: base(0) { }

		public void SetTrait(int nr, bool val)
		{
			SetBit((byte)Math.Min(Math.Max(nr, 0), 9), val);
		}

		public bool GetTrait(int nr)
		{
			return GetBit((byte)Math.Min(Math.Max(nr, 0), 9));
		}

		public bool Gifted
		{
			get => GetBit(0);
			set => SetBit(0, value);
		}

		public bool Doofus
		{
			get => GetBit(1);
			set => SetBit(1, value);
		}

		public bool Hyper
		{
			get => GetBit(2);
			set => SetBit(2, value);
		}

		public bool Lazy
		{
			get => GetBit(3);
			set => SetBit(3, value);
		}

		public bool Independant
		{
			get => GetBit(4);
			set => SetBit(4, value);
		}

		public bool Friendly
		{
			get => GetBit(5);
			set => SetBit(5, value);
		}

		public bool Aggressive
		{
			get => GetBit(6);
			set => SetBit(6, value);
		}

		public bool Cowardly
		{
			get => GetBit(7);
			set => SetBit(7, value);
		}

		public bool Pigpen
		{
			get => GetBit(8);
			set => SetBit(8, value);
		}

		public bool Finicky
		{
			get => GetBit(9);
			set => SetBit(9, value);
		}
	}
	#endregion

	#region PersonData Flags 1
	/// <summary>
	/// Flags for PersonData Flags 1
	/// </summary>
	public class PersonFlags1 : FlagBase
	{
		public PersonFlags1(ushort flags)
			: base(flags) { }

		public PersonFlags1()
			: base(0) { }

		public bool IsZombie
		{
			get => GetBit(0);
			set => SetBit(0, value);
		}

		public bool PermaPlatinum
		{
			get => GetBit(1);
			set => SetBit(1, value);
		}

		public bool IsVampire
		{
			get => GetBit(2);
			set => SetBit(2, value);
		}

		public bool VampireSmoke
		{
			get => GetBit(3);
			set => SetBit(3, value);
		}

		public bool WantHistory
		{
			get => GetBit(4);
			set => SetBit(4, value);
		}

		public bool LycanCarrier
		{
			get => GetBit(5);
			set => SetBit(5, value);
		}

		public bool LycanActive
		{
			get => GetBit(6);
			set => SetBit(6, value);
		}

		public bool IsRunaway
		{
			get => GetBit(7);
			set => SetBit(7, value);
		}

		public bool IsPlantsim
		{
			get => GetBit(8);
			set => SetBit(8, value);
		}

		public bool IsBigfoot
		{
			get => GetBit(9);
			set => SetBit(9, value);
		}

		public bool IsWitch
		{
			get => GetBit(10);
			set => SetBit(10, value);
		}

		public bool IsRoomate
		{
			get => GetBit(11);
			set => SetBit(11, value);
		}
	}
	#endregion

	#region PersonData Flags 3
	/// <summary>
	/// Flags for PersonData Flags 3
	/// </summary>
	public class PersonFlags3 : FlagBase
	{
		public PersonFlags3(ushort flags)
			: base(flags) { }

		public PersonFlags3()
			: base(0) { }

		public bool IsOwned
		{
			get => GetBit(0);
			set => SetBit(0, value);
		}

		public bool StayNaked
		{
			get => GetBit(1);
			set => SetBit(1, value);
		}

		public bool Reserved01
		{
			get => GetBit(2);
			set => SetBit(2, value);
		}

		public bool Reserved02
		{
			get => GetBit(3);
			set => SetBit(3, value);
		}

		public bool Reserved03
		{
			get => GetBit(4);
			set => SetBit(4, value);
		}

		public bool Reserved04
		{
			get => GetBit(5);
			set => SetBit(5, value);
		}
	}
	#endregion

	#region Semester info flags
	/// <summary>
	/// Flags for Semester info flags
	/// </summary>
	public class SemesterFlags : FlagBase
	{
		public SemesterFlags(ushort flags)
			: base(flags) { }

		public SemesterFlags()
			: base(0) { }

		public bool Freshman
		{
			get => GetBit(0);
			set => SetBit(0, value);
		}

		public bool Sophomore
		{
			get => GetBit(1);
			set => SetBit(1, value);
		}

		public bool Junior
		{
			get => GetBit(2);
			set => SetBit(2, value);
		}

		public bool Senior
		{
			get => GetBit(3);
			set => SetBit(3, value);
		}

		public bool GoodSem
		{
			get => GetBit(4);
			set => SetBit(4, value);
		}

		public bool Probation
		{
			get => GetBit(5);
			set => SetBit(5, value);
		}

		public bool Graduated
		{
			get => GetBit(6);
			set => SetBit(6, value);
		}

		public bool AtClass
		{
			get => GetBit(7);
			set => SetBit(7, value);
		}

		public bool Gates1
		{
			get => GetBit(8);
			set => SetBit(8, value);
		}

		public bool Gates2
		{
			get => GetBit(9);
			set => SetBit(9, value);
		}

		public bool Gates3
		{
			get => GetBit(10);
			set => SetBit(10, value);
		}

		public bool Gates4
		{
			get => GetBit(11);
			set => SetBit(11, value);
		}

		public bool Dropped
		{
			get => GetBit(12);
			set => SetBit(12, value);
		}

		public bool Expelled
		{
			get => GetBit(13);
			set => SetBit(13, value);
		}
	}
	#endregion

	#region CharacterDescription
	/// <summary>
	/// Holds some descriptive Properties about a Character
	/// </summary>
	public class CharacterDescription : Serializer
	{
		public GhostFlags GhostFlag
		{
			get; set;
		}

		public SelectableFlags SelectableFlag
		{
			get; set;
		}

		public BodyFlags BodyFlag
		{
			get; set;
		}

		public CultFlags CultFlag
		{
			get; set;
		}

		public PersonFlags1 PersonFlags1
		{
			get; set;
		}

		public PersonFlags3 PersonFlags3
		{
			get; set;
		}

		public CharacterDescription()
		{
			GhostFlag = new GhostFlags();
			BodyFlag = new BodyFlags();
			CultFlag = new CultFlags();
			SelectableFlag = new SelectableFlags();
			PersonFlags1 = new PersonFlags1();
			PersonFlags3 = new PersonFlags3();
		}

		public ushort AutonomyLevel
		{
			get; set;
		}

		public ushort NPCType
		{
			get; set;
		}

		public short TitlePostName
		{
			get; set;
		}

		public ushort AllocatedSuburb
		{
			get; set;
		}

		public ushort PartnerID
		{
			get; set;
		}

		public ushort ReligionId
		{
			get; set;
		}

		public ushort MotivesStatic
		{
			get; set;
		}

		public ushort PTO
		{
			get; set;
		}

		public ushort VoiceType
		{
			get; set;
		}

		public MetaData.SchoolTypes SchoolType
		{
			get; set;
		}

		public MetaData.Grades Grade
		{
			get; set;
		}

		public short CareerPerformance
		{
			get; set;
		}

		public MetaData.Careers Career
		{
			get; set;
		}

		public ushort Pension
		{
			get; set;
		}

		public ushort CareerLevel
		{
			get; set;
		}

		public MetaData.Careers Retired
		{
			get; set;
		}

		public ushort RetiredLevel
		{
			get; set;
		}

		public MetaData.Bodyshape Bodyshape
		{
			get; set;
		}

		public MetaData.ServiceTypes ServiceTypes
		{
			get; set;
		}

		public MetaData.ZodiacSignes ZodiacSign
		{
			get; set;
		}

		public MetaData.AspirationTypes Aspiration
		{
			get; set;
		}

		public MetaData.Gender Gender
		{
			get; set;
		}

		public MetaData.LifeSections LifeSection
		{
			get; set;
		}

		public ushort Realage
		{
			get; set;
		}

		public ushort Age
		{
			get; set;
		}

		public ushort PrevAgeDays
		{
			get; set;
		}

		public ushort AgeDuration
		{
			get; set;
		}

		private ushort clifeline;
		public ushort BlizLifelinePoints
		{
			get => (ushort)Math.Min(1200, (uint)clifeline);
			set => clifeline = (ushort)Math.Min(1200, (uint)value);
		}

		private short lifeline;
		public short LifelinePoints
		{
			get => (short)Math.Min(600, (int)(lifeline));
			set => lifeline = (short)Math.Min(600, (int)(value));
		}

		private ushort lifelinescore;
		public uint LifelineScore
		{
			get => (uint)(lifelinescore * 10);
			set => lifelinescore = (ushort)(Math.Min(short.MaxValue, value / 10));
		}
	}
	#endregion

	#region CharacterAttributes
	/// <summary>
	/// Stores character Attributes
	/// </summary>
	public class CharacterAttributes : Serializer
	{
		private ushort neat;
		public ushort Neat
		{
			get => (ushort)Math.Min(1000, (uint)neat);
			set => neat = (ushort)Math.Min(1000, (uint)value);
		}

		private ushort outgoing;
		public ushort Outgoing
		{
			get => (ushort)Math.Min(1000, (uint)outgoing);
			set => outgoing = (ushort)Math.Min(1000, (uint)value);
		}

		private ushort active;
		public ushort Active
		{
			get => (ushort)Math.Min(1000, (uint)active);
			set => active = (ushort)Math.Min(1000, (uint)value);
		}

		private ushort playful;
		public ushort Playful
		{
			get => (ushort)Math.Min(1000, (uint)playful);
			set => playful = (ushort)Math.Min(1000, (uint)value);
		}

		private ushort nice;
		public ushort Nice
		{
			get => (ushort)Math.Min(1000, (uint)nice);
			set => nice = (ushort)Math.Min(1000, (uint)value);
		}
	}
	#endregion

	#region Decay
	/// <summary>
	/// Decay Values of a Sim
	/// </summary>
	public class SimDecay : Serializer
	{
		private short hunger;
		public short Hunger
		{
			get => hunger;
			set => hunger = Math.Min((short)0, Math.Max((short)-1000, value));
		}

		private short comfort;
		public short Comfort
		{
			get => comfort;
			set => comfort = Math.Min((short)0, Math.Max((short)-1000, value));
		}

		private short bladder;
		public short Bladder
		{
			get => bladder;
			set => bladder = Math.Min((short)0, Math.Max((short)-1000, value));
		}

		private short energy;
		public short Energy
		{
			get => energy;
			set => energy = Math.Min((short)0, Math.Max((short)-1000, value));
		}

		private short hygiene;
		public short Hygiene
		{
			get => hygiene;
			set => hygiene = Math.Min((short)0, Math.Max((short)-1000, value));
		}

		private short amorous;
		public short Amorous
		{
			get => amorous;
			set => amorous = Math.Min((short)0, Math.Max((short)-1000, value));
		}

		private short shopping;
		public short Shopping
		{
			get => shopping;
			set => shopping = Math.Min((short)0, Math.Max((short)-1000, value));
		}

		private short social;
		public short Social
		{
			get => social;
			set => social = Math.Min((short)0, Math.Max((short)-1000, value));
		}

		private short fun;
		public short Fun
		{
			get => fun;
			set => fun = Math.Min((short)0, Math.Max((short)-1000, value));
		}

		private short scratchy;
		public short ScratchC
		{
			get => scratchy;
			set => scratchy = Math.Min((short)0, Math.Max((short)-1000, value));
		}
	}
	#endregion

	#region SkillAttributes
	/// <summary>
	/// Skill Attributes of a Sim
	/// </summary>
	public class SkillAttributes : Serializer
	{
		private ushort romance;
		public ushort Romance
		{
			get => (ushort)Math.Min(1000, (uint)romance);
			set => romance = (ushort)Math.Min(1000, (uint)value);
		}

		private ushort fatness;
		public ushort Fatness
		{
			get => (ushort)Math.Min(1000, (uint)fatness);
			set => fatness = (ushort)Math.Min(1000, (uint)value);
		}

		private ushort cooking;
		public ushort Cooking
		{
			get => (ushort)Math.Min(1000, (uint)cooking);
			set => cooking = (ushort)Math.Min(1000, (uint)value);
		}

		private ushort mechanical;
		public ushort Mechanical
		{
			get => (ushort)Math.Min(1000, (uint)mechanical);
			set => mechanical = (ushort)Math.Min(1000, (uint)value);
		}

		private ushort music;
		public ushort Music
		{
			get => (ushort)Math.Min(1000, (uint)music);
			set => music = (ushort)Math.Min(1000, (uint)value);
		}

		private ushort art;
		public ushort Art
		{
			get => (ushort)Math.Min(1000, (uint)art);
			set => art = (ushort)Math.Min(1000, (uint)value);
		}

		private ushort charisma;
		public ushort Charisma
		{
			get => (ushort)Math.Min(1000, (uint)charisma);
			set => charisma = (ushort)Math.Min(1000, (uint)value);
		}

		private ushort body;
		public ushort Body
		{
			get => (ushort)Math.Min(1000, (uint)body);
			set => body = (ushort)Math.Min(1000, (uint)value);
		}

		private ushort logic;
		public ushort Logic
		{
			get => (ushort)Math.Min(1000, (uint)logic);
			set => logic = (ushort)Math.Min(1000, (uint)value);
		}

		private ushort creativity;
		public ushort Creativity
		{
			get => (ushort)Math.Min(1000, (uint)creativity);
			set => creativity = (ushort)Math.Min(1000, (uint)value);
		}

		private ushort cleaning;
		public ushort Cleaning
		{
			get => (ushort)Math.Min(1000, (uint)cleaning);
			set => cleaning = (ushort)Math.Min(1000, (uint)value);
		}
	}
	#endregion

	#region Interests
	/// <summary>
	/// What a Sim is interessted in
	/// </summary>
	public class InterestAttributes : Serializer
	{
		private ushort politics;
		public ushort Politics
		{
			get => (ushort)Math.Min(1000, (uint)politics);
			set => politics = (ushort)Math.Min(1000, (uint)value);
		}

		private ushort money;
		public ushort Money
		{
			get => (ushort)Math.Min(1000, (uint)money);
			set => money = (ushort)Math.Min(1000, (uint)value);
		}

		private ushort crime;
		public ushort Crime
		{
			get => (ushort)Math.Min(1000, (uint)crime);
			set => crime = (ushort)Math.Min(1000, (uint)value);
		}

		private ushort environment;
		public ushort Environment
		{
			get => (ushort)Math.Min(1000, (uint)environment);
			set => environment = (ushort)Math.Min(1000, (uint)value);
		}

		private ushort entertainment;
		public ushort Entertainment
		{
			get => (ushort)Math.Min(1000, (uint)entertainment);
			set => entertainment = (ushort)Math.Min(1000, (uint)value);
		}

		private ushort culture;
		public ushort Culture
		{
			get => (ushort)Math.Min(1000, (uint)culture);
			set => culture = (ushort)Math.Min(1000, (uint)value);
		}

		private ushort food;
		public ushort Food
		{
			get => (ushort)Math.Min(1000, (uint)food);
			set => food = (ushort)Math.Min(1000, (uint)value);
		}

		private ushort health;
		public ushort Health
		{
			get => (ushort)Math.Min(1000, (uint)health);
			set => health = (ushort)Math.Min(1000, (uint)value);
		}

		private ushort fashion;
		public ushort Fashion
		{
			get => (ushort)Math.Min(1000, (uint)fashion);
			set => fashion = (ushort)Math.Min(1000, (uint)value);
		}

		private ushort sports;
		public ushort Sports
		{
			get => (ushort)Math.Min(1000, (uint)sports);
			set => sports = (ushort)Math.Min(1000, (uint)value);
		}

		private ushort paranormal;
		public ushort Paranormal
		{
			get => (ushort)Math.Min(1000, (uint)paranormal);
			set => paranormal = (ushort)Math.Min(1000, (uint)value);
		}

		private ushort travel;
		public ushort Travel
		{
			get => (ushort)Math.Min(1000, (uint)travel);
			set => travel = (ushort)Math.Min(1000, (uint)value);
		}

		private ushort work;
		public ushort Work
		{
			get => (ushort)Math.Min(1000, (uint)work);
			set => work = (ushort)Math.Min(1000, (uint)value);
		}

		private ushort weather;
		public ushort Weather
		{
			get => (ushort)Math.Min(1000, (uint)weather);
			set => weather = (ushort)Math.Min(1000, (uint)value);
		}

		private ushort animals;
		public ushort Animals
		{
			get => (ushort)Math.Min(1000, (uint)animals);
			set => animals = (ushort)Math.Min(1000, (uint)value);
		}

		private ushort school;
		public ushort School
		{
			get => (ushort)Math.Min(1000, (uint)school);
			set => school = (ushort)Math.Min(1000, (uint)value);
		}

		private ushort toys;
		public ushort Toys
		{
			get => (ushort)Math.Min(1000, (uint)toys);
			set => toys = (ushort)Math.Min(1000, (uint)value);
		}

		private ushort scifi;
		public ushort Scifi
		{
			get => (ushort)Math.Min(1000, (uint)scifi);
			set => scifi = (ushort)Math.Min(1000, (uint)value);
		}

		private short woman;
		public short FemalePreference
		{
			get => woman;
			set => woman = (short)Math.Max(-1000, Math.Min(1000, (int)value));
		}

		private short man;
		public short MalePreference
		{
			get => man;
			set => man = (short)Math.Max(-1000, Math.Min(1000, (int)value));
		}
	}
	#endregion

	#region Relationships

	/// <summary>
	/// A List of all Sims known to the current one
	/// </summary>
	public class SimRelationAttribute
	{
		SDesc parent;

		internal SimRelationAttribute(SDesc parent)
		{
			this.parent = parent;
			SimInstances = new ushort[0];
		}

		public ushort[] SimInstances
		{
			get; set;
		}

		/// <summary>
		/// Returns the SimDescription of the Sim with the passed Instance
		/// </summary>
		/// <param name="instance">Instance Number</param>
		/// <returns>The SimDescription Object or null if none was found</returns>
		public SDesc GetSimDescription(ushort instance)
		{
			if (instance == parent.FileDescriptor.Instance)
			{
				return null;
			}

			IPackedFileDescriptor pfd = parent.Package.FindFile(
				MetaData.SIM_DESCRIPTION_FILE,
				0,
				parent.FileDescriptor.Group,
				instance
			);

			SDesc sdesc = new SDesc(
				parent.nameprovider,
				parent.familynameprovider,
				parent.sdescprovider
			);
			if (pfd != null)
			{
				sdesc.ProcessData(pfd, parent.Package);
			}

			return sdesc;
		}

		/// <summary>
		/// Returns the Relationship Files for the given instance
		/// </summary>
		/// <param name="instance">The instance of the related Sim</param>
		/// <returns>
		///		null or a SimRelations Object
		///	</returns>
		public SimRelations GetSimRelationships(ushort instance)
		{
			if (instance == parent.FileDescriptor.Instance)
			{
				return null;
			}

			IPackedFileDescriptor pfd1 = parent.Package.FindFile(
				MetaData.RELATION_FILE,
				0,
				parent.FileDescriptor.Group,
				(uint)((instance << 16) + parent.FileDescriptor.Instance)
			);

			IPackedFileDescriptor pfd2 = parent.Package.FindFile(
				MetaData.RELATION_FILE,
				0,
				parent.FileDescriptor.Group,
				(parent.FileDescriptor.Instance << 16) + instance
			);

			SRel[] rels = new SRel[2];
			rels[0] = new SRel();
			rels[1] = new SRel();

			if (pfd1 != null)
			{
				rels[1].ProcessData(pfd1, parent.Package);
			}

			if (pfd2 != null)
			{
				rels[0].ProcessData(pfd2, parent.Package);
			}

			return new SimRelations(rels);
		}
	}
	#endregion

	#region SdscUniversity
	/// <summary>
	/// University specific Data
	/// </summary>
	public class SdscUniversity : Serializer
	{
		internal SdscUniversity()
		{
			Major = Majors.Undeclared;
			Time = 72;
			Semester = 1;
		}

		public SemesterFlags SemesterFlag { get; set; } = new SemesterFlags();

		public ushort Effort
		{
			get; set;
		}

		public ushort Grade
		{
			get; set;
		}

		public ushort Time
		{
			get; set;
		}

		public ushort Semester
		{
			get; set;
		}

		public ushort OnCampus
		{
			get; set;
		}

		public ushort Influence
		{
			get; set;
		}

		public Majors Major
		{
			get; set;
		}

		internal void Unserialize(BinaryReader reader)
		{
			reader.BaseStream.Seek(0x014, SeekOrigin.Begin);
			Effort = reader.ReadUInt16();

			reader.BaseStream.Seek(0x0b2, SeekOrigin.Begin);
			Grade = reader.ReadUInt16();

			reader.BaseStream.Seek(0x160, SeekOrigin.Begin);
			Major = (Majors)reader.ReadUInt32();
			Time = reader.ReadUInt16();
			SemesterFlag.Value = reader.ReadUInt16();
			Semester = reader.ReadUInt16();
			OnCampus = reader.ReadUInt16();
			reader.BaseStream.Seek(0x4, SeekOrigin.Current);
			Influence = reader.ReadUInt16();
		}

		internal void Serialize(BinaryWriter writer)
		{
			writer.BaseStream.Seek(0x014, SeekOrigin.Begin);
			writer.Write(Effort);

			writer.BaseStream.Seek(0x0b2, SeekOrigin.Begin);
			writer.Write(Grade);

			writer.BaseStream.Seek(0x160, SeekOrigin.Begin);
			writer.Write((uint)Major);
			writer.Write(Time);
			writer.Write(SemesterFlag.Value);
			// writer.BaseStream.Seek(0x2, SeekOrigin.Current);
			writer.Write(Semester);
			writer.Write(OnCampus);
			writer.BaseStream.Seek(0x4, SeekOrigin.Current);
			writer.Write(Influence);
		}
	}
	#endregion

	#region SdscNightlife
	/// <summary>
	/// Nightlife specific Data
	/// </summary>
	public class SdscNightlife : Serializer
	{
		public enum SpeciesType : ushort
		{
			Human = 0,
			LargeDog = 1,
			SmallDog = 2,
			Cat = 3,
		}

		internal SdscNightlife()
		{
			Species = SpeciesType.Human;
			AttractionTurnOffs3 = 0;
			AttractionTurnOns3 = 0;
			AttractionTraits3 = 0;

			AttractionTurnOffs1 = 0;
			AttractionTurnOffs2 = 0;
			AttractionTurnOns1 = 0;
			AttractionTurnOns2 = 0;
			AttractionTraits1 = 0;
			AttractionTraits2 = 0;
		}

		public ushort RouteStartSlotOwnerID
		{
			get; set;
		}

		public ushort AttractionTraits1
		{
			get; set;
		}

		public ushort AttractionTraits2
		{
			get; set;
		}

		/// <remarks>
		/// This is only valid if the SDSC Version is at least SDescVersions.Voyage
		/// </remarks>
		public ushort AttractionTraits3
		{
			get; set;
		}

		public ushort AttractionTurnOns1
		{
			get; set;
		}

		public ushort AttractionTurnOffs1
		{
			get; set;
		}

		public ushort AttractionTurnOns2
		{
			get; set;
		}

		public ushort AttractionTurnOffs2
		{
			get; set;
		}

		/// <remarks>
		/// This is only valid if the SDSC Version is at least SDescVersions.Voyage
		/// </remarks>
		public ushort AttractionTurnOns3
		{
			get; set;
		}

		/// <remarks>
		/// This is only valid if the SDSC Version is at least SDescVersions.Voyage
		/// </remarks>
		public ushort AttractionTurnOffs3
		{
			get; set;
		}

		public SpeciesType Species
		{
			get; set;
		}

		public ushort Countdown
		{
			get; set;
		}

		public ushort PerfumeDuration
		{
			get; set;
		}

		public ushort DateTimer
		{
			get; set;
		}

		public ushort DateScore
		{
			get; set;
		}

		public ushort DateUnlockCounter
		{
			get; set;
		}

		public ushort LovePotionDuration
		{
			get; set;
		}

		public ushort AspirationScoreLock
		{
			get; set;
		}

		public bool IsHuman
		{
			get
			{
				if (Species == SpeciesType.Cat)
				{
					return false;
				}

				if (Species == SpeciesType.SmallDog)
				{
					return false;
				}

				if (Species == SpeciesType.LargeDog)
				{
					return false;
				}

				return true;
			}
		}

		internal void Unserialize(BinaryReader reader, SDescVersions ver)
		{
			reader.BaseStream.Seek(0x172, SeekOrigin.Begin);
			RouteStartSlotOwnerID = reader.ReadUInt16();

			AttractionTraits1 = reader.ReadUInt16();
			AttractionTraits2 = reader.ReadUInt16();

			AttractionTurnOns1 = reader.ReadUInt16();
			AttractionTurnOns2 = reader.ReadUInt16();

			AttractionTurnOffs1 = reader.ReadUInt16();
			AttractionTurnOffs2 = reader.ReadUInt16();

			Species = (SpeciesType)reader.ReadUInt16();
			Countdown = reader.ReadUInt16();
			PerfumeDuration = reader.ReadUInt16();

			DateTimer = reader.ReadUInt16();
			DateScore = reader.ReadUInt16();
			DateUnlockCounter = reader.ReadUInt16();

			LovePotionDuration = reader.ReadUInt16();
			AspirationScoreLock = reader.ReadUInt16();

			if ((int)ver >= (int)SDescVersions.Voyage)
			{
				reader.BaseStream.Seek(0x19e, SeekOrigin.Begin);

				AttractionTurnOns3 = reader.ReadUInt16();
				AttractionTurnOffs3 = reader.ReadUInt16();
				AttractionTraits3 = reader.ReadUInt16();
			}
		}

		internal void Serialize(BinaryWriter writer, SDescVersions ver)
		{
			writer.BaseStream.Seek(0x172, SeekOrigin.Begin);
			writer.Write(RouteStartSlotOwnerID);

			writer.Write(AttractionTraits1);
			writer.Write(AttractionTraits2);

			writer.Write(AttractionTurnOns1);
			writer.Write(AttractionTurnOns2);

			writer.Write(AttractionTurnOffs1);
			writer.Write(AttractionTurnOffs2);

			writer.Write((ushort)Species);
			writer.Write(Countdown);
			writer.Write(PerfumeDuration);

			writer.Write(DateTimer);
			writer.Write(DateScore);
			writer.Write(DateUnlockCounter);

			writer.Write(LovePotionDuration);
			writer.Write(AspirationScoreLock);

			if ((int)ver >= (int)SDescVersions.Voyage)
			{
				writer.BaseStream.Seek(0x19e, SeekOrigin.Begin);

				writer.Write(AttractionTurnOns3);
				writer.Write(AttractionTurnOffs3);
				writer.Write(AttractionTraits3);
			}
		}
	}
	#endregion

	#region SdscBusiness
	/// <summary>
	/// Nightlife specific Data
	/// </summary>
	public class SdscBusiness : Serializer
	{
		internal SdscBusiness()
		{
		}

		public ushort LotID
		{
			get; set;
		}

		public ushort Salary
		{
			get; set;
		}

		public ushort Flags
		{
			get; set;
		}

		ushort assignment;
		public JobAssignment Assignment
		{
			get => (JobAssignment)assignment;
			set => assignment = (ushort)value;
		}

		internal void Unserialize(BinaryReader reader)
		{
			reader.BaseStream.Seek(0x192, SeekOrigin.Begin);
			LotID = reader.ReadUInt16();
			Salary = reader.ReadUInt16();
			Flags = reader.ReadUInt16();
			assignment = reader.ReadUInt16();
		}

		internal void Serialize(BinaryWriter writer)
		{
			writer.BaseStream.Seek(0x192, SeekOrigin.Begin);
			writer.Write(LotID);
			writer.Write(Salary);
			writer.Write(Flags);
			writer.Write(assignment);
		}
	}
	#endregion

	#region SdscPets
	/// <summary>
	/// Nightlife specific Data
	/// </summary>
	public class SdscPets : Serializer
	{
		internal SdscPets()
		{
			PetTraits = new PetTraits(0);
		}

		public PetTraits PetTraits
		{
			get;
		}

		internal void Unserialize(BinaryReader reader)
		{
			reader.BaseStream.Seek(0x19A, SeekOrigin.Begin);
			PetTraits.Value = reader.ReadUInt16();
		}

		internal void Serialize(BinaryWriter writer)
		{
			writer.BaseStream.Seek(0x19A, SeekOrigin.Begin);
			writer.Write(PetTraits.Value);
		}
	}
	#endregion

	#region SdscVoyage
	/// <summary>
	/// Nightlife specific Data
	/// </summary>
	public class SdscVoyage : Serializer
	{
		internal SdscVoyage()
		{
			DaysLeft = 0;
			CollectiblesPlain = 0;
		}

		public ushort DaysLeft
		{
			get; set;
		}

		public ulong CollectiblesPlain
		{
			get; set;
		}

		internal void Unserialize(BinaryReader reader)
		{
			reader.BaseStream.Seek(0x19C, SeekOrigin.Begin);
			DaysLeft = reader.ReadUInt16();
		}

		internal void Serialize(BinaryWriter writer)
		{
			writer.BaseStream.Seek(0x19C, SeekOrigin.Begin);
			writer.Write(DaysLeft);
		}

		internal void UnserializeMem(BinaryReader reader)
		{
			CollectiblesPlain = 0;
			if (reader.BaseStream.Position <= reader.BaseStream.Length - 8)
			{
				CollectiblesPlain = reader.ReadUInt64();
			}
		}

		internal void SerializeMem(BinaryWriter writer)
		{
			writer.Write(CollectiblesPlain);
		}
	}
	#endregion

	#region SdscCastaway
	/// <summary>
	/// Castaway specific Data
	/// </summary>
	public class SdscCastaway : Serializer
	{
		internal SdscCastaway()
		{
			Subspecies = 0;
		}

		public ushort Subspecies
		{
			get; set;
		}

		internal void Unserialize(BinaryReader reader)
		{
			reader.BaseStream.Seek(0x19C, SeekOrigin.Begin);
			Subspecies = reader.ReadUInt16();
		}

		internal void Serialize(BinaryWriter writer)
		{
			writer.BaseStream.Seek(0x19C, SeekOrigin.Begin);
			writer.Write(Subspecies);
		}
	}
	#endregion

	#region SdscApartment
	#endregion

	/// <summary>
	/// Represents a PackedFile in SDsc Format
	/// </summary>
	public class SDesc
		: AbstractWrapper,
			IFileWrapper,
			IFileWrapperSaveExtension,
			Interfaces.Wrapper.ISDesc
	{
		#region Local Attributes
		/// <summary>
		/// Number of teh assigned Instance
		/// </summary>

		/// <summary>
		/// Version of the package
		/// </summary>
		int version;

		/// <summary>
		/// Teh Version of this File
		/// </summary>
		public SDescVersions Version => (SDescVersions)version;

		/// <summary>
		/// Spaces of unknown Data
		/// </summary>
		private byte[] reserved_01;

		/// <summary>
		/// Spaces of unknown Data
		/// </summary>
		//private byte[] reserved_02;
		/// <summary>
		/// Spaces of unknown Data
		/// </summary>
		private byte[] backupdata;

		/// <summary>
		/// True if this Sim is only available for Memory Reasons
		/// </summary>
		public ushort Unlinked
		{
			get; set;
		}

		/// <summary>
		/// Don't know what this is :)
		/// </summary>
		public byte EndByte
		{
			get; set;
		}
		#endregion

		#region External Attributes
		//returns / sets the Instance of the Family the Sim lives in
		public ushort FamilyInstance
		{
			get; set;
		}

		/// <summary>
		/// Returns / Sets the Decay Values
		/// </summary>
		public SimDecay Decay
		{
			get; set;
		}

		/// <summary>
		/// Returns the Relationships a sim has
		/// </summary>
		public SimRelationAttribute Relations
		{
			get;
		}

		/// <summary>
		/// Returns the Description of the Character
		/// </summary>
		public CharacterDescription CharacterDescription
		{
			get;
		}

		/// <summary>
		/// Returns University Specific Data
		/// </summary>
		/// <remarks>Only valid if Version == SDescVersions.University or Version == SDescVersions.Nightlife</remarks>
		public SdscUniversity University
		{
			get;
		}

		/// <summary>
		/// Returns Nightlife Specific Data
		/// </summary>
		/// <remarks>Only valid if Version >= SDescVersions.Nightlife</remarks>
		public SdscNightlife Nightlife
		{
			get;
		}

		/// <summary>
		/// Returns Business Specific Data
		/// </summary>
		/// <remarks>Only valid if Version == SDescVersions.Business</remarks>
		public SdscBusiness Business
		{
			get;
		}

		/// <summary>
		/// Returns Pets Specific Data
		/// </summary>
		/// <remarks>Only valid if Version == SDescVersions.Pets</remarks>
		public SdscPets Pets
		{
			get;
		}

		/// <summary>
		/// Returns Voyage Specific Data
		/// </summary>
		/// <remarks>Only valid if Version == SDescVersions.Voyage</remarks>
		public SdscVoyage Voyage
		{
			get;
		}

		/// <summary>
		/// Returns Castaway Specific Data
		/// </summary>
		/// <remarks>Only valid if Version == SDescVersions.Castaway</remarks>
		public SdscCastaway Castaway
		{
			get;
		}

		/// <summary>
		/// Returns Freetime Specific Data
		/// </summary>
		/// <remarks>Only valid if Version == SDescVersions.Freetime</remarks>
		public SdscFreetime Freetime
		{
			get;
		}

		/// <summary>
		/// Returns Apartment Life-specific data
		/// </summary>
		/// <remarks>Only valid if Version >= SDescVersions.Apartment</remarks>
		public SdscApartment Apartment
		{
			get;
		}

		/// <summary>
		/// Returns the Character Attributes
		/// </summary>
		public CharacterAttributes Character
		{
			get;
		}

		/// <summary>
		/// Returns the Character Attributes
		/// </summary>
		public CharacterAttributes GeneticCharacter
		{
			get;
		}

		/// <summary>
		/// Returns the Skill Attributes
		/// </summary>
		public SkillAttributes Skills
		{
			get;
		}

		/// <summary>
		/// Returns the Interests of a Sim
		/// </summary>
		public InterestAttributes Interests
		{
			get;
		}
		#endregion

		#region Local Getters/Setters

		/// <summary>
		/// Returns the Name Provider
		/// </summary>
		internal Interfaces.Providers.ISimNames NameProvider => nameprovider;

		/// <summary>
		/// Returns the Description Provider
		/// </summary>
		internal Interfaces.Providers.ISimDescriptions DescriptionProvider => sdescprovider;

		/// <summary>
		/// Returns/Sets the Sim Id
		/// </summary>
		public uint SimId
		{
			get; set;
		}

		/// <summary>
		/// Returns the FirstName of a Sim
		/// </summary>
		/// <remarks>If no SimName Provider is available, '---' will be delivered</remarks>
		public virtual string SimName
		{
			get
			{
				if (nameprovider != null)
				{
					return nameprovider.FindName(SimId).Name;
				}
				else
				{
					return "---";
				}
			}
			set => throw new Exception("SimFamilyName can't be changed here!");
		}

		/// <summary>
		/// true if an Image for this Sim is available
		/// </summary>
		public bool HasImage
		{
			get
			{
				if (nameprovider != null)
				{
					object o = nameprovider.FindName(SimId).Tag;
					if (o != null)
					{
						object[] tags = (object[])o;
						if ((System.Drawing.Image)tags[1] != null)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		/// <summary>
		/// Returns the Image stored for a specific Sim
		/// </summary>
		public System.Drawing.Image Image
		{
			get
			{
				if (nameprovider != null)
				{
					object o = nameprovider.FindName(SimId).Tag;
					if (o != null)
					{
						object[] tags = (object[])o;
						if ((System.Drawing.Image)tags[1] != null)
						{
							return (System.Drawing.Image)tags[1];
						}
					}
				}
				return new System.Drawing.Bitmap(1, 1);
			}
		}

		/// <summary>
		/// Returns the Name of the File the Character is stored in
		/// </summary>
		/// <remarks>null, if no File was found</remarks>
		public virtual string CharacterFileName
		{
			get
			{
				if (nameprovider != null)
				{
					object o = nameprovider.FindName(SimId).Tag;
					if (o != null)
					{
						object[] tags = (object[])o;
						return Helper.ToString(tags[0]);
					}
				}
				return null;
			}
		}

		public bool IsCharSplit
		{
			get
			{
				if (CharacterFileName == null)
				{
					return false;
				}
				else if (CharacterFileName.Contains(".1"))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		/// <summary>
		/// Returns or Sets the Instance Number
		/// </summary>
		public ushort Instance
		{
			get; set;
		}

		public virtual bool ChangeNames(string name, string familyname)
		{
			if (!File.Exists(CharacterFileName))
			{
				return false;
			}

			try
			{
				Packages.GeneratableFile file =
					Packages.File.LoadFromFile(CharacterFileName);
				IPackedFileDescriptor[] pfds = file.FindFiles(
					MetaData.CTSS_FILE
				);
				if (pfds.Length > 0)
				{
					Str str =
						new Str();
					str.ProcessData(pfds[0], file);
					foreach (StrLanguage lng in str.Languages)
					{
						if (lng == null)
						{
							continue;
						}

						if (str.LanguageItems(lng)[0x0] != null)
						{
							str.LanguageItems(lng)[0x0].Title = name;
						}

						if (str.LanguageItems(lng)[0x2] != null)
						{
							str.LanguageItems(lng)[0x2].Title = familyname;
						}
					}
					str.SynchronizeUserData();
					file.Save();
				}

				//update the Data in the Provider
				Alias a = (Alias)NameProvider.FindName(SimId);
				if (a != null)
				{
					a.Name = name;
					if (a.Tag.Length >= 2)
					{
						a.Tag[2] = familyname;
					}
				}
				return true;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("Unable to change the Sim Name", ex);
			}
			return false;
		}

		/// <summary>
		/// Returns the FamilyName of a Sim
		/// </summary>
		/// <remarks>If no SimFamilyName Provider is available, '---' will be delivered</remarks>
		public virtual string SimFamilyName
		{
			get
			{
				if (nameprovider != null)
				{
					object[] o = nameprovider.FindName(SimId).Tag;
					if (o != null)
					{
						if (o.Length > 2)
						{
							if (o[2] != null)
							{
								return o[2].ToString();
							}
						}
					}
				}
				return Localization.Manager.GetString("Unknown");
			}
			set => throw new Exception("SimFamilyName can't be changed here!");
		}

		/// <summary>
		/// Returns the FamilyName of a Sim that is stored in the current Package
		/// </summary>
		/// <remarks>If no SimFamilyName Provider is available, '---' will be delivered</remarks>
		public string HouseholdName
		{
			get
			{
				if (familynameprovider != null)
				{
					if (
						familynameprovider.FindName(SimId).Name
						== Localization.GetString("Unknown")
					)
					{
						return MetaData.NPCFamily(
							Convert.ToUInt32(FamilyInstance)
						);
					}

					return familynameprovider.FindName(SimId).Name;
				}
				else
				{
					return "---";
				}
			}
		}

		/// <summary>
		/// True if the Character File contains Character Data (AgeData, 3dMesh...)
		/// </summary>
		public bool AvailableCharacterData
		{
			get
			{
				if (nameprovider != null)
				{
					object[] o = nameprovider.FindName(SimId).Tag;
					if (o != null)
					{
						if (o.Length > 3)
						{
							if (o[3] != null)
							{
								return (bool)o[3];
							}
						}
					}
				}
				return false;
			}
		}
		#endregion

		#region SDesc specific Methods/Data
		/// <summary>
		/// Stores null or a valid Name Provider
		/// </summary>
		internal Interfaces.Providers.ISimNames nameprovider;

		/// <summary>
		/// Stores null or a valid FamilyName Provider
		/// </summary>
		internal Interfaces.Providers.ISimFamilyNames familynameprovider;

		/// <summary>
		/// Stores null or a valid SimDescription provider
		/// </summary>
		internal Interfaces.Providers.ISimDescriptions sdescprovider;

		/// <summary>
		/// Scans the passed Package for a Description File containing the SimId
		/// </summary>
		/// <param name="simid">id of your Sim</param>
		/// <param name="package">the package you want to search</param>
		/// <returns>null if none was found, or the Description file describing the Sim</returns>
		///
		public static SDesc FindForSimId(uint simid, IPackageFile package)
		{
			IPackedFileDescriptor[] files = package.FindFiles(
				MetaData.SIM_DESCRIPTION_FILE
			);

			SDesc sdesc = new SDesc(null, null, null);
			foreach (IPackedFileDescriptor pfd in files)
			{
				sdesc.ProcessData(pfd, package);
				if (sdesc.SimId == simid)
				{
					return sdesc;
				}
			}
			return null;
		}
		#endregion

		#region IWrapper Member
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Sim Description Wrapper",
				"Quaxi",
				"This File contains Settings (like interests, friendships, money, age, gender...) for one Sim.",
				17,
				System.Drawing.Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.sdsc.png")
				)
			);
		}

		protected override string GetResourceName(TypeAlias ta)
		{
			if (!Processed)
			{
				ProcessData(FileDescriptor, Package);
			}

			return SimName + " " + SimFamilyName;
		}
		#endregion

		#region AbstractWrapper Member
		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return null;
		}

		/// <summary>
		/// Change the links to the Providers
		/// </summary>
		/// <param name="prov">A Provider Registry</param>
		public void SetProviders(Interfaces.IProviderRegistry prov)
		{
			nameprovider = prov.SimNameProvider;
			familynameprovider = prov.SimFamilynameProvider;
			sdescprovider = prov.SimDescriptionProvider;
		}

		public SDesc()
			: this(
				FileTableBase.ProviderRegistry.SimNameProvider,
				FileTableBase.ProviderRegistry.SimFamilynameProvider,
				FileTableBase.ProviderRegistry.SimDescriptionProvider
			)
		{
		}

		/// <summary>
		/// Creates a new Instance
		/// </summary>
		/// <param name="names">null, or a Sim Name Provider</param>
		/// <param name="famnames">null or a Sim Familyname Provider</param>
		/// <param name="sdesc">nullor a SimD</param>
		public SDesc(
			Interfaces.Providers.ISimNames names,
			Interfaces.Providers.ISimFamilyNames famnames,
			Interfaces.Providers.ISimDescriptions sdesc
		)
			: base()
		{
			reserved_01 = new byte[0xC2];
			//reserved_02 = new byte[0x9A];
			backupdata = new byte[0x9D];

			reserved_01[0x00] = 0x70;
			reserved_01[0x04] = 0x20;
			reserved_01[0x08] = 0x20;
			backupdata[0x00] = 0x02;
			backupdata[0x08] = 0x01;

			nameprovider = names;
			familynameprovider = famnames;
			sdescprovider = sdesc;

			Decay = new SimDecay();
			Character = new CharacterAttributes();
			GeneticCharacter = new CharacterAttributes();
			Skills = new SkillAttributes();
			Interests = new InterestAttributes();
			CharacterDescription = new CharacterDescription();
			Relations = new SimRelationAttribute(this);
			University = new SdscUniversity();
			Nightlife = new SdscNightlife();
			Business = new SdscBusiness();
			Pets = new SdscPets();
			Voyage = new SdscVoyage();
			Castaway = new SdscCastaway();
			Freetime = new SdscFreetime(this);
			Apartment = new SdscApartment(this);

			CharacterDescription.Aspiration = MetaData.AspirationTypes.Romance;
			CharacterDescription.ZodiacSign = MetaData.ZodiacSignes.Virgo;
			CharacterDescription.LifeSection = MetaData.LifeSections.Adult;
			CharacterDescription.Gender = MetaData.Gender.Female;
			CharacterDescription.LifelinePoints = 500;

			Interests.FemalePreference = 50;
			Interests.MalePreference = 50;

			Skills.Fatness = 500;
			version = 0x20;
			EndByte = 0x01;
		}

		/// <summary>
		/// Returns the Offset for the GUID7Instance Data
		/// </summary>
		int GuidDataPosition => RelationPosition - 0xA;

		/// <summary>
		/// Returns the Offset for the Relation COunt Filed
		/// </summary>
		int RelationPosition
		{
			get
			{
				if (version == (int)SDescVersions.Castaway)
				{
					return 0x19E + 0XA;
				}

				if (version >= (int)SDescVersions.Apartment)
				{
					return 0x1DA + 0xA;
				}

				if (version >= (int)SDescVersions.Freetime)
				{
					return 0x1D4 + 0xA;
				}

				if (version >= (int)SDescVersions.VoyageB)
				{
					return 0x1A4 + 0xA; //0x19e + 0xa?
				}

				if (version >= (int)SDescVersions.Voyage)
				{
					return 0x1A4 + 0xA; //0x19e + 0xa?
				}

				if (version >= (int)SDescVersions.Pets)
				{
					return 0x19C + 0xA;
				}

				if (version >= (int)SDescVersions.Business)
				{
					return 0x19A + 0xA;
				}

				if (version >= (int)SDescVersions.Nightlife)
				{
					return 0x192 + 0xA;
				}

				if (version >= (int)SDescVersions.University)
				{
					return 0x16A + 0x12;
				}

				return 0x16A;
			}
		}

		protected override void Unserialize(BinaryReader reader)
		{
			//the formula offset = 0x0a + 2*pid
			long startpos = reader.BaseStream.Position;
			reserved_01 = reader.ReadBytes(0xC2);
			CharacterDescription.Age = reader.ReadUInt16();
			CharacterDescription.PrevAgeDays = reader.ReadUInt16();
			//reserved_02= reader.ReadBytes(0x9A);
			//instancenumber = reader.ReadUInt16();
			//simid = reader.ReadUInt32();
			backupdata = reader.ReadBytes(
				(int)(reader.BaseStream.Length - (reader.BaseStream.Position))
			);
			long endpos = reader.BaseStream.Position;

			///
			/// TODO: This needs to be done more efficient, but for now it will work!
			///
			reader.BaseStream.Seek(startpos + 0x04, SeekOrigin.Begin);
			version = reader.ReadInt32();

			//Read the GUID Data
			reader.BaseStream.Seek(
				startpos + GuidDataPosition,
				SeekOrigin.Begin
			);
			Instance = reader.ReadUInt16();
			SimId = reader.ReadUInt32();

			//decay
			reader.BaseStream.Seek(startpos + 0xC6, SeekOrigin.Begin);
			Decay.Hunger = reader.ReadInt16();
			Decay.Comfort = reader.ReadInt16();
			Decay.Bladder = reader.ReadInt16();
			Decay.Energy = reader.ReadInt16();
			Decay.Hygiene = reader.ReadInt16();
			Decay.Amorous = reader.ReadInt16();
			Decay.Social = reader.ReadInt16();
			Decay.Shopping = reader.ReadInt16();
			Decay.Fun = reader.ReadInt16();
			reader.BaseStream.Seek(startpos + 0xE0, SeekOrigin.Begin);
			Decay.ScratchC = reader.ReadInt16();

			//skills
			reader.BaseStream.Seek(startpos + 0x1E, SeekOrigin.Begin);
			Skills.Cleaning = reader.ReadUInt16();
			Skills.Cooking = reader.ReadUInt16();
			Skills.Charisma = reader.ReadUInt16();
			Skills.Mechanical = reader.ReadUInt16();
			Skills.Music = reader.ReadUInt16();
			CharacterDescription.PartnerID = reader.ReadUInt16();
			Skills.Creativity = reader.ReadUInt16();
			Skills.Art = reader.ReadUInt16();
			Skills.Body = reader.ReadUInt16();
			Skills.Logic = reader.ReadUInt16();
			// Chris H this is Sunshine Motive change to Amorous Personality - reader.BaseStream.Seek(startpos + 0xEA, System.IO.SeekOrigin.Begin);
			reader.BaseStream.Seek(startpos + 0xB6, SeekOrigin.Begin);
			Skills.Romance = reader.ReadUInt16();

			//character (Genetic)
			reader.BaseStream.Seek(startpos + 0x10, SeekOrigin.Begin);
			Character.Nice = reader.ReadUInt16();
			Character.Active = reader.ReadUInt16();
			reader.BaseStream.Seek(0x02, SeekOrigin.Current);

			//reader.BaseStream.Seek(0x014, SeekOrigin.Begin);
			//University.Effort = reader.ReadUInt16();

			Character.Playful = reader.ReadUInt16();
			Character.Outgoing = reader.ReadUInt16();
			Character.Neat = reader.ReadUInt16();

			//random Data
			reader.BaseStream.Seek(startpos + 0xb4, SeekOrigin.Begin);
			CharacterDescription.PersonFlags1.Value = reader.ReadUInt16();

			reader.BaseStream.Seek(startpos + 0x46, SeekOrigin.Begin);
			CharacterDescription.MotivesStatic = reader.ReadUInt16();
			reader.BaseStream.Seek(startpos + 0x68, SeekOrigin.Begin);
			CharacterDescription.Aspiration = (MetaData.AspirationTypes)reader.ReadUInt16();
			reader.BaseStream.Seek(startpos + 0xBC, SeekOrigin.Begin);
			CharacterDescription.VoiceType = reader.ReadUInt16();
			reader.BaseStream.Seek(startpos + 0x7C, SeekOrigin.Begin);
			CharacterDescription.Grade = (MetaData.Grades)reader.ReadUInt16();
			CharacterDescription.CareerLevel = reader.ReadUInt16();
			reader.BaseStream.Seek(startpos + 0x80, SeekOrigin.Begin);
			CharacterDescription.Realage = reader.ReadUInt16();
			reader.BaseStream.Seek(startpos + 0x80, SeekOrigin.Begin);
			CharacterDescription.LifeSection = (MetaData.LifeSections)reader.ReadUInt16();
			reader.BaseStream.Seek(startpos + 0x86, SeekOrigin.Begin);
			FamilyInstance = reader.ReadUInt16();
			reader.BaseStream.Seek(startpos + 0x8A, SeekOrigin.Begin);
			CharacterDescription.CareerPerformance = reader.ReadInt16();
			reader.BaseStream.Seek(startpos + 0x8E, SeekOrigin.Begin);
			CharacterDescription.Gender = (MetaData.Gender)reader.ReadUInt16();
			reader.BaseStream.Seek(startpos + 0x94, SeekOrigin.Begin);
			CharacterDescription.GhostFlag.Value = reader.ReadUInt16();
			reader.BaseStream.Seek(startpos + 0x96, SeekOrigin.Begin);
			CharacterDescription.PTO = reader.ReadUInt16();
			reader.BaseStream.Seek(startpos + 0x98, SeekOrigin.Begin);
			CharacterDescription.ZodiacSign = (MetaData.ZodiacSignes)reader.ReadUInt16();

			reader.BaseStream.Seek(startpos + 0x102, SeekOrigin.Begin);
			CharacterDescription.Pension = reader.ReadUInt16();

			reader.BaseStream.Seek(startpos + 0xAE, SeekOrigin.Begin);
			CharacterDescription.BodyFlag.Value = reader.ReadUInt16();
			reader.BaseStream.Seek(startpos + 0x134, SeekOrigin.Begin);
			CharacterDescription.CultFlag.Value = reader.ReadUInt16();
			reader.BaseStream.Seek(startpos + 0x13C, SeekOrigin.Begin);
			CharacterDescription.ReligionId = reader.ReadUInt16();
			_ = reader.ReadUInt16();
			reader.BaseStream.Seek(startpos + 0x12A, SeekOrigin.Begin);
			_ = reader.ReadUInt16();
			reader.BaseStream.Seek(startpos + 0xBA, SeekOrigin.Begin);
			_ = reader.ReadUInt16();
			reader.BaseStream.Seek(startpos + 0xB0, SeekOrigin.Begin);
			Skills.Fatness = reader.ReadUInt16();
			reader.BaseStream.Seek(startpos + 0xBE, SeekOrigin.Begin);
			CharacterDescription.Career = (MetaData.Careers)reader.ReadUInt32();
			reader.BaseStream.Seek(startpos + 0x12C, SeekOrigin.Begin);
			CharacterDescription.AllocatedSuburb = reader.ReadUInt16();
			CharacterDescription.PersonFlags3.Value = reader.ReadUInt16();
			CharacterDescription.Bodyshape = (MetaData.Bodyshape)reader.ReadUInt16();
			reader.BaseStream.Seek(startpos + 0xE2, SeekOrigin.Begin);
			CharacterDescription.SchoolType = (MetaData.SchoolTypes)reader.ReadUInt32();
			reader.BaseStream.Seek(startpos + 0x14C, SeekOrigin.Begin);
			CharacterDescription.LifelinePoints = reader.ReadInt16();
			CharacterDescription.LifelineScore = (uint)(reader.ReadUInt16() * 10);
			CharacterDescription.BlizLifelinePoints = reader.ReadUInt16();
			reader.BaseStream.Seek(startpos + 0x142, SeekOrigin.Begin);
			CharacterDescription.ServiceTypes = (MetaData.ServiceTypes)reader.ReadUInt16();
			reader.BaseStream.Seek(startpos + 0x142, SeekOrigin.Begin);
			CharacterDescription.NPCType = reader.ReadUInt16();
			CharacterDescription.AgeDuration = reader.ReadUInt16();
			reader.BaseStream.Seek(startpos + 0x148, SeekOrigin.Begin);
			CharacterDescription.SelectableFlag.Value = reader.ReadUInt16();
			reader.BaseStream.Seek(startpos + 0x54, SeekOrigin.Begin);
			CharacterDescription.AutonomyLevel = reader.ReadUInt16();
			reader.BaseStream.Seek(startpos + 0x156, SeekOrigin.Begin);
			Unlinked = reader.ReadUInt16();

			reader.BaseStream.Seek(startpos + 0x15A, SeekOrigin.Begin);
			CharacterDescription.Retired = (MetaData.Careers)reader.ReadUInt32();
			CharacterDescription.RetiredLevel = reader.ReadUInt16();

			//available Relationships
			reader.BaseStream.Seek(
				startpos + RelationPosition,
				SeekOrigin.Begin
			);
			Relations.SimInstances = new ushort[reader.ReadUInt32()];

			int ct = 0;
			for (int i = 0; i < Relations.SimInstances.Length; i++)
			{
				if (reader.BaseStream.Length - reader.BaseStream.Position < 4)
				{
					continue;
				}
				//reader.ReadUInt16();			//yet unknown
				Relations.SimInstances[i] = (ushort)reader.ReadUInt32();
				ct++;
			}

			//something went wrong while reading the SimInstances
			if (ct != Relations.SimInstances.Length)
			{
				ushort[] old = Relations.SimInstances;
				Relations.SimInstances = new ushort[ct];
				for (int i = 0; i < ct; i++)
				{
					Relations.SimInstances[i] = old[i];
				}
			}

			if (reader.BaseStream.Length - reader.BaseStream.Position > 0)
			{
				EndByte = reader.ReadByte();
			}
			else
			{
				EndByte = 0x01;
			}

			if (version >= (int)SDescVersions.Voyage)
			{
				Voyage.UnserializeMem(reader);
			}

			//character (Genetic)
			reader.BaseStream.Seek(startpos + 0x6A, SeekOrigin.Begin);
			GeneticCharacter.Neat = reader.ReadUInt16();
			GeneticCharacter.Nice = reader.ReadUInt16();
			GeneticCharacter.Active = reader.ReadUInt16();
			GeneticCharacter.Outgoing = reader.ReadUInt16();
			GeneticCharacter.Playful = reader.ReadUInt16();

			//interests
			reader.BaseStream.Seek(startpos + 0x038, SeekOrigin.Begin);
			Interests.MalePreference = reader.ReadInt16();
			Interests.FemalePreference = reader.ReadInt16();
			reader.BaseStream.Seek(startpos + 0x104, SeekOrigin.Begin);
			Interests.Politics = reader.ReadUInt16();
			Interests.Money = reader.ReadUInt16();
			Interests.Environment = reader.ReadUInt16();
			Interests.Crime = reader.ReadUInt16();
			Interests.Entertainment = reader.ReadUInt16();
			Interests.Culture = reader.ReadUInt16();
			Interests.Food = reader.ReadUInt16();
			Interests.Health = reader.ReadUInt16();
			Interests.Fashion = reader.ReadUInt16();
			Interests.Sports = reader.ReadUInt16();
			Interests.Paranormal = reader.ReadUInt16();
			Interests.Travel = reader.ReadUInt16();
			Interests.Work = reader.ReadUInt16();
			Interests.Weather = reader.ReadUInt16();
			Interests.Animals = reader.ReadUInt16();
			Interests.School = reader.ReadUInt16();
			Interests.Toys = reader.ReadUInt16();
			Interests.Scifi = reader.ReadUInt16();

			//university only Items
			if (version >= (int)SDescVersions.University)
			{
				University.Unserialize(reader);
			}

			//nightlife only Items
			if (version >= (int)SDescVersions.Nightlife)
			{
				Nightlife.Unserialize(reader, (SDescVersions)version);
			}

			//business only Items
			if (version >= (int)SDescVersions.Business)
			{
				Business.Unserialize(reader);
			}

			//pets only Items
			if (version >= (int)SDescVersions.Pets)
			{
				Pets.Unserialize(reader);
			}

			//voyage only Items
			if (version >= (int)SDescVersions.Voyage)
			{
				Voyage.Unserialize(reader);
			}

			//castway only Items
			if (version == (int)SDescVersions.Castaway)
			{
				Castaway.Unserialize(reader);
			}

			//freetime only Items
			if (version >= (int)SDescVersions.Freetime)
			{
				Freetime.Unserialize(reader);
			}

			//apartment only Items
			if (version >= (int)SDescVersions.Apartment)
			{
				Apartment.Unserialize(reader);
				reader.BaseStream.Seek(startpos + 0x1D8, SeekOrigin.Begin);
				CharacterDescription.TitlePostName = (short)reader.ReadUInt16();
			}

			reader.BaseStream.Seek(endpos, SeekOrigin.Begin);
		}

		protected override void Serialize(BinaryWriter writer)
		{
			// No point in writing different values to the same Position so
			// Realage if used must be preconverted to LifeSection
			// ServiceTypes if used must be preconverted to NPCType

			long startpos = writer.BaseStream.Position;
			writer.Write(reserved_01);
			writer.Write(CharacterDescription.Age);
			writer.Write(CharacterDescription.PrevAgeDays);
			//writer.Write(reserved_02);
			//writer.Write(instancenumber);
			//writer.Write(simid);
			byte[] res03 = Helper.SetLength(
				backupdata,
				(int)(RelationPosition - writer.BaseStream.Position)
			);
			writer.Write(res03);
			while (writer.BaseStream.Length < 0x16D)
			{
				writer.Write((byte)0);
			}

			long endpos = writer.BaseStream.Position;

			///
			/// TODO: This needs to be done more efficient, but for now it will work!
			///
			writer.BaseStream.Seek(startpos + 0x04, SeekOrigin.Begin);
			writer.Write(version); //Version Number

			//Write the Guid Data
			writer.BaseStream.Seek(
				startpos + GuidDataPosition,
				SeekOrigin.Begin
			);
			writer.Write(Instance);
			writer.Write(SimId);

			//character
			writer.BaseStream.Seek(startpos + 0x10, SeekOrigin.Begin);
			writer.Write(Character.Nice); //Nice
			writer.Write(Character.Active); //Active
			writer.BaseStream.Seek(0x02, SeekOrigin.Current);
			writer.Write(Character.Playful); //Playful
			writer.Write(Character.Outgoing); //Outgoing
			writer.Write(Character.Neat); //Neat

			//freetime only Items (has to get processed before the aspiration filed is written)
			if (version >= (int)SDescVersions.Freetime)
			{
				Freetime.Serialize(writer);
			}

			//random Data
			writer.BaseStream.Seek(startpos + 0xb4, SeekOrigin.Begin);
			writer.Write(CharacterDescription.PersonFlags1.Value);

			writer.BaseStream.Seek(startpos + 0x46, SeekOrigin.Begin);
			writer.Write(CharacterDescription.MotivesStatic);
			writer.BaseStream.Seek(startpos + 0x54, SeekOrigin.Begin);
			writer.Write(CharacterDescription.AutonomyLevel);
			writer.BaseStream.Seek(startpos + 0x68, SeekOrigin.Begin);
			writer.Write((ushort)CharacterDescription.Aspiration);
			writer.BaseStream.Seek(startpos + 0xBC, SeekOrigin.Begin);
			writer.Write(CharacterDescription.VoiceType);
			writer.BaseStream.Seek(startpos + 0x7C, SeekOrigin.Begin);
			writer.Write((ushort)CharacterDescription.Grade);
			writer.Write(CharacterDescription.CareerLevel);
			writer.BaseStream.Seek(startpos + 0x80, SeekOrigin.Begin);
			writer.Write((ushort)CharacterDescription.LifeSection);
			writer.BaseStream.Seek(startpos + 0x86, SeekOrigin.Begin);
			writer.Write(FamilyInstance);
			writer.BaseStream.Seek(startpos + 0x8A, SeekOrigin.Begin);
			writer.Write(CharacterDescription.CareerPerformance);
			writer.BaseStream.Seek(startpos + 0x8E, SeekOrigin.Begin);
			writer.Write((ushort)CharacterDescription.Gender);
			writer.BaseStream.Seek(startpos + 0x94, SeekOrigin.Begin);
			writer.Write(CharacterDescription.GhostFlag.Value);
			writer.BaseStream.Seek(startpos + 0x96, SeekOrigin.Begin);
			writer.Write(CharacterDescription.PTO);
			writer.BaseStream.Seek(startpos + 0x98, SeekOrigin.Begin);
			writer.Write((ushort)CharacterDescription.ZodiacSign);

			writer.BaseStream.Seek(startpos + 0x102, SeekOrigin.Begin);
			writer.Write(CharacterDescription.Pension);

			writer.BaseStream.Seek(startpos + 0xAE, SeekOrigin.Begin);
			writer.Write(CharacterDescription.BodyFlag.Value);
			writer.BaseStream.Seek(startpos + 0x134, SeekOrigin.Begin);
			writer.Write(CharacterDescription.CultFlag.Value);
			writer.BaseStream.Seek(startpos + 0x13C, SeekOrigin.Begin);
			writer.Write(CharacterDescription.ReligionId);
			writer.Write((ushort)0);
			writer.BaseStream.Seek(startpos + 0x12A, SeekOrigin.Begin);
			writer.Write((ushort)0);
			writer.BaseStream.Seek(startpos + 0xBA, SeekOrigin.Begin);
			writer.Write((ushort)0);
			writer.BaseStream.Seek(startpos + 0xB0, SeekOrigin.Begin);
			writer.Write(Skills.Fatness);
			writer.BaseStream.Seek(startpos + 0xBE, SeekOrigin.Begin);
			writer.Write((uint)CharacterDescription.Career);
			writer.BaseStream.Seek(startpos + 0x12C, SeekOrigin.Begin);
			writer.Write(CharacterDescription.AllocatedSuburb);
			writer.Write(CharacterDescription.PersonFlags3.Value);
			writer.Write((ushort)CharacterDescription.Bodyshape);
			writer.BaseStream.Seek(startpos + 0xE2, SeekOrigin.Begin);
			writer.Write((uint)CharacterDescription.SchoolType);
			writer.BaseStream.Seek(startpos + 0x14C, SeekOrigin.Begin);
			writer.Write(CharacterDescription.LifelinePoints);
			writer.Write((ushort)(CharacterDescription.LifelineScore / 10));
			writer.Write(CharacterDescription.BlizLifelinePoints);
			writer.BaseStream.Seek(startpos + 0x142, SeekOrigin.Begin);
			writer.Write(CharacterDescription.NPCType);
			writer.Write(CharacterDescription.AgeDuration);
			writer.BaseStream.Seek(startpos + 0x148, SeekOrigin.Begin);
			writer.Write(CharacterDescription.SelectableFlag.Value);
			writer.BaseStream.Seek(startpos + 0x156, SeekOrigin.Begin);
			writer.Write(Unlinked);

			writer.BaseStream.Seek(startpos + 0x15A, SeekOrigin.Begin);
			writer.Write((uint)CharacterDescription.Retired);
			writer.Write(CharacterDescription.RetiredLevel);

			//decay
			writer.BaseStream.Seek(startpos + 0xC6, SeekOrigin.Begin);
			writer.Write(Decay.Hunger);
			writer.Write(Decay.Comfort);
			writer.Write(Decay.Bladder);
			writer.Write(Decay.Energy);
			writer.Write(Decay.Hygiene);
			writer.Write(Decay.Amorous);
			writer.Write(Decay.Social);
			writer.Write(Decay.Shopping);
			writer.Write(Decay.Fun);
			writer.BaseStream.Seek(startpos + 0xE0, SeekOrigin.Begin);
			writer.Write(Decay.ScratchC);

			//available Relationships
			writer.BaseStream.Seek(
				startpos + RelationPosition,
				SeekOrigin.Begin
			);
			writer.Write((uint)Relations.SimInstances.Length);

			for (int i = 0; i < Relations.SimInstances.Length; i++)
			{
				writer.Write((uint)Relations.SimInstances[i]);
			}

			writer.Write(EndByte);
			if (version >= (int)SDescVersions.Voyage)
			{
				Voyage.SerializeMem(writer);
			}

			//skills
			writer.BaseStream.Seek(startpos + 0x1E, SeekOrigin.Begin);
			writer.Write(Skills.Cleaning);
			writer.Write(Skills.Cooking);
			writer.Write(Skills.Charisma);
			writer.Write(Skills.Mechanical);
			writer.Write(Skills.Music);
			writer.Write(CharacterDescription.PartnerID);
			writer.Write(Skills.Creativity);
			writer.Write(Skills.Art);
			writer.Write(Skills.Body);
			writer.Write(Skills.Logic);
			// Chris H this was Sunshine Motive changed to Amorous Personality - writer.BaseStream.Seek(startpos + 0xEA, System.IO.SeekOrigin.Begin);
			writer.BaseStream.Seek(startpos + 0xB6, SeekOrigin.Begin);
			writer.Write(Skills.Romance);

			//character (Genetic)
			writer.BaseStream.Seek(startpos + 0x6A, SeekOrigin.Begin);
			writer.Write(GeneticCharacter.Neat);
			writer.Write(GeneticCharacter.Nice);
			writer.Write(GeneticCharacter.Active);
			writer.Write(GeneticCharacter.Outgoing);
			writer.Write(GeneticCharacter.Playful);

			//interests
			writer.BaseStream.Seek(startpos + 0x038, SeekOrigin.Begin);
			writer.Write(Interests.MalePreference);
			writer.Write(Interests.FemalePreference);
			writer.BaseStream.Seek(startpos + 0x104, SeekOrigin.Begin);
			writer.Write(Interests.Politics);
			writer.Write(Interests.Money);
			writer.Write(Interests.Environment);
			writer.Write(Interests.Crime);
			writer.Write(Interests.Entertainment);
			writer.Write(Interests.Culture);
			writer.Write(Interests.Food);
			writer.Write(Interests.Health);
			writer.Write(Interests.Fashion);
			writer.Write(Interests.Sports);
			writer.Write(Interests.Paranormal);
			writer.Write(Interests.Travel);
			writer.Write(Interests.Work);
			writer.Write(Interests.Weather);
			writer.Write(Interests.Animals);
			writer.Write(Interests.School);
			writer.Write(Interests.Toys);
			writer.Write(Interests.Scifi);

			//university only Items
			if (version >= (int)SDescVersions.University)
			{
				University.Serialize(writer);
			}

			//nightlife only Items
			if (version >= (int)SDescVersions.Nightlife)
			{
				Nightlife.Serialize(writer, (SDescVersions)version);
			}

			//business only Items
			if (version >= (int)SDescVersions.Business)
			{
				Business.Serialize(writer);
			}

			//pets only Items
			if (version >= (int)SDescVersions.Pets)
			{
				Pets.Serialize(writer);
			}

			//voyage only Items
			if (version >= (int)SDescVersions.Voyage)
			{
				Voyage.Serialize(writer);
			}

			//castway only Items
			if (version == (int)SDescVersions.Castaway)
			{
				Castaway.Serialize(writer);
			}

			//apartment only Items
			if (version >= (int)SDescVersions.Apartment)
			{
				Apartment.Serialize(writer);
			}

			writer.BaseStream.Seek(endpos, SeekOrigin.Begin);
		}
		#endregion

		#region IPackedFileWrapper Member
		public override string Description
		{
			get
			{
				string s =
					"GUID=0x"
					+ Helper.HexString(SimId)
					+ ", Filename="
					+ CharacterFileName
					+ ", Name="
					+ SimName
					+ " "
					+ SimFamilyName
					+ ", Age="
					+ CharacterDescription.LifeSection.ToString()
					+ ", Job="
					+ CharacterDescription.Career.ToString()
					+ ", Zodiac="
					+ CharacterDescription.ZodiacSign.ToString()
					+ ", Major="
					+ University.Major
					+ ", Grade="
					+ CharacterDescription.Grade.ToString();
				if ((int)Version >= (int)SDescVersions.Nightlife)
				{
					s += ", Species=" + Nightlife.Species.ToString();
				}

				return s;
			}
		}

		public uint[] AssignableTypes
		{
			get
			{
				uint[] Types = { 0xAACE2EFB };
				return Types;
			}
		}

		public Byte[] FileSignature
		{
			get
			{
				Byte[] sig = { };
				return sig;
			}
		}

		#endregion

		#region static values
		static Interfaces.IAlias[] addoncarrer;

		/// <summary>
		/// Returns a List of Userdefined Add On Careers
		/// </summary>
		public static Interfaces.IAlias[] AddonCarrers
		{
			get
			{
				if (addoncarrer == null)
				{
					addoncarrer = Alias.LoadFromXml(
						Path.Combine(
							Helper.SimPeDataPath,
							"additional_careers.xml"
						)
					);
				}

				return addoncarrer;
			}
		}

		static Interfaces.IAlias[] addonmajor;

		/// <summary>
		/// Returns a List of Userdefined Add On Majors
		/// </summary>
		public static Interfaces.IAlias[] AddonMajors
		{
			get
			{
				if (addonmajor == null)
				{
					addonmajor = Alias.LoadFromXml(
						Path.Combine(
							Helper.SimPeDataPath,
							"additional_majors.xml"
						)
					);
				}

				return addonmajor;
			}
		}

		static Interfaces.IAlias[] addonschool;

		/// <summary>
		/// Returns a List of Userdefined Add On Schools
		/// </summary>
		public static Interfaces.IAlias[] AddonSchools
		{
			get
			{
				if (addonschool == null)
				{
					addonschool = Alias.LoadFromXml(
						Path.Combine(
							Helper.SimPeDataPath,
							"additional_schools.xml"
						)
					);
				}

				return addonschool;
			}
		}
		#endregion

		public static Expansions GetMinExpansion(SDescVersions ver)
		{
			string[] names = Enum.GetNames(typeof(Expansions));
			string name = ver.ToString();
			foreach (string n in names)
			{
				if (name == n)
				{
					return (Expansions)Enum.Parse(typeof(Expansions), n);
				}
			}

			return Expansions.BaseGame;
		}

		/*
		public static SDescVersions GetMinVersion(Expansions exp) // don't need this anymore
		{
			string[] names = Enum.GetNames(typeof(SDescVersions));
			string name = exp.ToString();
			foreach (string n in names)
				if (name == n) return (SDescVersions)Enum.Parse(typeof(SDescVersions), n);

			return SDescVersions.Unknown;
		} */

		public static ExpansionItem GetIEVersion(SDescVersions sv)
		{
			if (sv == SDescVersions.Apartment)
			{
				return PathProvider.Global.Latest;
			}

			if (sv == SDescVersions.Freetime)
			{
				return PathProvider.Global.GetLowestAvailableExpansion(13, 15); // lowest is EP, these SPs lack data so use them last
			}

			if (sv == SDescVersions.Voyage || sv == SDescVersions.VoyageB)
			{
				return PathProvider.Global.GetLowestAvailableExpansion(10, 12);
			}

			if (sv == SDescVersions.Castaway)
			{
				return PathProvider.Global.GetExpansion(28);
			}

			if (sv == SDescVersions.Pets)
			{
				if (Helper.WindowsRegistry.LoadOnlySimsStory == 29)
				{
					return PathProvider.Global.GetExpansion(29);
				}
				else
				{
					return PathProvider.Global.GetHighestAvailableExpansion(6, 9);
				}
			}
			if (sv == SDescVersions.Business)
			{
				if (Helper.WindowsRegistry.LoadOnlySimsStory == 30)
				{
					return PathProvider.Global.GetExpansion(30);
				}
				else
				{
					return (PathProvider.Global.GetHighestAvailableExpansion(3, 5));
				}
			}
			if (sv == SDescVersions.Nightlife)
			{
				return PathProvider.Global.GetExpansion(2);
			}

			if (sv == SDescVersions.University)
			{
				return PathProvider.Global.GetExpansion(1);
			}

			if (sv == SDescVersions.BaseGame)
			{
				return PathProvider.Global.GetExpansion(0);
			}

			return null;
		}

		public override int GetHashCode()
		{
			if (FileDescriptor == null || Package == null)
			{
				return base.GetHashCode();
			}
			else
			{
				return (int)SimId;
			}
		}

		public override bool Equals(object obj)
		{
			if (FileDescriptor == null || Package == null)
			{
				return base.Equals(obj);
			}

			if (obj == null)
			{
				return false;
			}

			if (!(obj is SDesc))
			{
				return false;
			}

			return (((SDesc)obj).SimId == SimId) && (((SDesc)obj).Instance == Instance);
		}

		/*public static bool operator ==(SDesc s1, SDesc s2)
		{
			if (s1==null)
				return s2==null;
			return s1.Equals(s2);
		}

		public static bool operator !=(SDesc s1, SDesc s2)
		{
			if (s1==null)
				return s2!=null;
			return !s1.Equals(s2);
		}*/
	}
}
