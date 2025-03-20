// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

using Avalonia.Controls;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Extensions;
using SimPe.Models.Interfaces;
using SimPe.Views.PackedFile.Sdsc;

namespace SimPe.Models.PackedFile.Sdsc
{
	public partial class Sdsc(PackedFile file) : ObservableObject, IWrapper
	{
		[ObservableProperty]
		private PackedFile file = file;

		[ObservableProperty]
		private uint unknown_00;

		private EnumDisplayNameItem<SdscVersion> version;

		public EnumDisplayNameItem<SdscVersion> Version
		{
			get => version;
			set
			{
				if (SetProperty(ref version, value))
				{
					OnPropertyChanged(nameof(IsUniOrLater));
					OnPropertyChanged(nameof(IsNightlifeOrLater));
					OnPropertyChanged(nameof(IsBusinessOrLater));
					OnPropertyChanged(nameof(IsPetsOrLater));
					OnPropertyChanged(nameof(IsCastaway));
					OnPropertyChanged(nameof(IsVoyageOrLater));
					OnPropertyChanged(nameof(IsFreetimeOrLater));
					OnPropertyChanged(nameof(IsApartmentOrLater));
				}
			}
		}

		public bool IsUniOrLater => Version >= SdscVersion.University;
		public bool IsNightlifeOrLater => Version >= SdscVersion.Nightlife;
		public bool IsBusinessOrLater => Version >= SdscVersion.Business;
		public bool IsPetsOrLater => Version >= SdscVersion.Pets;
		public bool IsCastaway => Version == SdscVersion.Castaway;
		public bool IsVoyageOrLater => Version >= SdscVersion.Voyage;
		public bool IsFreetimeOrLater => Version >= SdscVersion.Freetime;
		public bool IsApartmentOrLater => Version >= SdscVersion.Apartment;

		[ObservableProperty]
		private ushort sitting;

		[ObservableProperty]
		private ushort moneyOverHead;

		[ObservableProperty]
		private SdscPersonality personality = new();

		[ObservableProperty]
		private ushort uniEffort;

		[ObservableProperty]
		private ushort currentOutfit;

		[ObservableProperty]
		private SdscSkills skills = new();

		[ObservableProperty]
		private ushort groupTalkStateFlags;

		[ObservableProperty]
		private ushort currentInteractionIndex;

		[ObservableProperty]
		private short malePreference;

		[ObservableProperty]
		private short femalePreference;

		[ObservableProperty]
		private ushort jobData;

		[ObservableProperty]
		private ushort interactionData1;

		[ObservableProperty]
		private ushort subQueueInteractionCount;

		[ObservableProperty]
		private ushort tickCounter;

		[ObservableProperty]
		private ushort interactionData2;

		[ObservableProperty]
		private ushort staticMotives;

		[ObservableProperty]
		private ushort censorshipFlags;

		[ObservableProperty]
		private ushort neighborID;

		[ObservableProperty]
		private ushort personType;

		[ObservableProperty]
		private ushort priority;

		[ObservableProperty]
		private ushort greetStatus;

		[ObservableProperty]
		private ushort visitorSchedule;

		[ObservableProperty]
		private ushort autonomyLevel;

		[ObservableProperty]
		private ushort routeSlot;

		[ObservableProperty]
		private ushort routeMultiSlotIndex;

		[ObservableProperty]
		private ushort routeStatus;

		[ObservableProperty]
		private ushort routeGoal;

		[ObservableProperty]
		private ushort lookAtObjectID;

		[ObservableProperty]
		private ushort lookAtSlotID;

		[ObservableProperty]
		private ushort lookAtState;

		[ObservableProperty]
		private ushort lookAtTimeRemaining;

		[ObservableProperty]
		private ushort nextQueuedInteractionIndex;

		[ObservableProperty]
		private ushort aspiration;

		[ObservableProperty]
		private SdscPersonality originalPersonality = new();

		[ObservableProperty]
		private ushort simUIIconFlags;

		[ObservableProperty]
		private ushort findBestActionResult;

		[ObservableProperty]
		private ushort memoryScore;

		[ObservableProperty]
		private ushort routeStartSlot;

		[ObservableProperty]
		private ushort schoolGrade;

		[ObservableProperty]
		private ushort jobPromotionLevel;

		[ObservableProperty]
		private ushort personAge;

		[ObservableProperty]
		private ushort socialMenuObjectID;

		[ObservableProperty]
		private ushort skinColor;

		[ObservableProperty]
		private ushort familyInstance;

		[ObservableProperty]
		private ushort routeResult;

		[ObservableProperty]
		private ushort jobPerformance;

		[ObservableProperty]
		private ushort isSwimming;

		[ObservableProperty]
		private EnumDisplayNameItem<SdscGender> gender;

		[ObservableProperty]
		private ushort @private;

		[ObservableProperty]
		private ushort lingeringHouseInstance;

		[ObservableProperty]
		private ushort ghostFlags;

		[ObservableProperty]
		private ushort paidTimeOff;

		[ObservableProperty]
		private ushort zodiacSign;

		[ObservableProperty]
		private ushort nonInterruptible;

		[ObservableProperty]
		private ushort nextQueuedInteractionContinuation;

		[ObservableProperty]
		private ushort footprintExtension;

		[ObservableProperty]
		private ushort renderDisplayFlags;

		[ObservableProperty]
		private ushort subQueueMasterInteractionObjectID;

		[ObservableProperty]
		private ushort subQueueMasterInteractionIndex;

		[ObservableProperty]
		private ushort nextSubQueueInteractionIndex;

		[ObservableProperty]
		private ushort nextSubQueueInteractionObjectID;

		[ObservableProperty]
		private ushort nextQueuedInteractionObjectID;

		[ObservableProperty]
		private ushort currentInteractionObjectID;

		[ObservableProperty]
		private ushort bodyFlags;

		[ObservableProperty]
		private ushort fatness;

		[ObservableProperty]
		private ushort uniGrade;

		[ObservableProperty]
		private ushort voiceType;
		[ObservableProperty]
		private uint jobGUID;

		[ObservableProperty]
		private ushort ageDaysLeft;

		[ObservableProperty]
		private ushort daysInPreviousAge;

		[ObservableProperty]
		private short decayHunger;

		[ObservableProperty]
		private short decayComfort;

		[ObservableProperty]
		private short decayBladder;

		[ObservableProperty]
		private short decayEnergy;

		[ObservableProperty]
		private short decayHygiene;

		[ObservableProperty]
		private short decaySocial;

		[ObservableProperty]
		private short decayFun;

		[ObservableProperty]
		private ushort currentRunningInteractionIndex;

		[ObservableProperty]
		private ushort currentRunningInteractionObjectID;

		[ObservableProperty]
		private ushort genetics1;

		[ObservableProperty]
		private ushort genetics2;

		[ObservableProperty]
		private ushort genetics3;

		[ObservableProperty]
		private uint schoolGUID;

		[ObservableProperty]
		private ushort currentInteractionGUID;

		[ObservableProperty]
		private ushort interactionsLinkedDeleted;

		[ObservableProperty]
		private ushort romanceSkill;

		[ObservableProperty]
		private ushort locoWeight0;

		[ObservableProperty]
		private ushort locoWeight1;

		[ObservableProperty]
		private ushort locoPersonalityIndex;

		[ObservableProperty]
		private ushort locoPersonalityWeight;

		[ObservableProperty]
		private ushort locoMoodIndex;

		[ObservableProperty]
		private ushort locoMoodWeight;

		[ObservableProperty]
		private ushort motivesNotIncludedInMood;

		[ObservableProperty]
		private uint outfitSourceGUID;

		[ObservableProperty]
		private ushort environmentScoreOverride;

		[ObservableProperty]
		private ushort fitnessPreference;

		[ObservableProperty]
		private ushort pension;

		[ObservableProperty]
		private SdscInterests interests = new();

		[ObservableProperty]
		private ushort unselectable;

		[ObservableProperty]
		private ushort nPCType;

		[ObservableProperty]
		private ushort ageDuration;

		[ObservableProperty]
		private ushort subQueueInteractionObjectID;

		[ObservableProperty]
		private ushort selectionFlags;

		[ObservableProperty]
		private ushort personFlags;

		[ObservableProperty]
		private ushort aspirationScore;

		[ObservableProperty]
		private ushort aspirationRewardPointsSpent;

		[ObservableProperty]
		private ushort aspirationScoreRaw;

		[ObservableProperty]
		private ushort moodBooster;

		[ObservableProperty]
		private ushort currentInteractionJoinable;

		[ObservableProperty]
		private ushort unlinked;

		[ObservableProperty]
		private ushort interactionAutonomous;

		[ObservableProperty]
		private uint retiredJobGUID;

		[ObservableProperty]
		private ushort retiredJobLevel;

		[ObservableProperty]
		private uint collegeMajorGUID;

		[ObservableProperty]
		private ushort remainingTimeInSemester;

		[ObservableProperty]
		private ushort uniFlags;

		[ObservableProperty]
		private ushort semester;

		[ObservableProperty]
		private ushort onCampus;

		[ObservableProperty]
		private uint unknown_01;

		[ObservableProperty]
		private ushort influence;

		[ObservableProperty]
		private ushort routeStartSlotOwnerID;

		[ObservableProperty]
		private ushort traits1;

		[ObservableProperty]
		private ushort traits2;

		[ObservableProperty]
		private ushort turnOns1;

		[ObservableProperty]
		private ushort turnOns2;

		[ObservableProperty]
		private ushort turnOffs1;

		[ObservableProperty]
		private ushort turnOffs2;

		[ObservableProperty]
		private ushort species;

		[ObservableProperty]
		private ushort countdown;

		[ObservableProperty]
		private ushort perfumeTimer;

		[ObservableProperty]
		private ushort dateTimer;

		[ObservableProperty]
		private ushort dateScore;

		[ObservableProperty]
		private ushort dateUnlockCounter;

		[ObservableProperty]
		private ushort lovePotionTimer;

		[ObservableProperty]
		private ushort aspirationScoreLock;

		[ObservableProperty]
		private ushort dateUnlockCounter2;

		[ObservableProperty]
		private ushort lotID;

		[ObservableProperty]
		private ushort salary;

		[ObservableProperty]
		private ushort oFBFlags;

		[ObservableProperty]
		private ushort jobAssignment;

		[ObservableProperty]
		private ushort petTraits;

		[ObservableProperty]
		private ushort subspecies;

		[ObservableProperty]
		private ushort daysLeftInVacation;

		[ObservableProperty]
		private ushort turnOns3;

		[ObservableProperty]
		private ushort turnOffs3;

		[ObservableProperty]
		private ushort traits3;

		[ObservableProperty]
		private SdscHobbies hobbies = new();

		[ObservableProperty]
		private ushort predestinedHobby;

		[ObservableProperty]
		private ushort lifetimeAspiration;

		[ObservableProperty]
		private ushort lifetimeAspirationPoints;

		[ObservableProperty]
		private ushort lifetimeAspirationPointsSpent;

		[ObservableProperty]
		private ushort decayHungerModifier;

		[ObservableProperty]
		private ushort decayComfortModifier;

		[ObservableProperty]
		private ushort decayBladderModifier;

		[ObservableProperty]
		private ushort decayEnergyModifier;

		[ObservableProperty]
		private ushort decayHygieneModifier;

		[ObservableProperty]
		private ushort decayFunModifier;

		[ObservableProperty]
		private ushort decaySocialModifier;

		[ObservableProperty]
		private uint bugsCollection;

		[ObservableProperty]
		private ushort reputation;

		[ObservableProperty]
		private ushort probabilityToAppear;

		[ObservableProperty]
		private ushort titlePostName;

		[ObservableProperty]
		private ushort simInstance;

		[ObservableProperty]
		private uint simGUID;

		[ObservableProperty]
		private uint unknown_02;

		[ObservableProperty]
		private ObservableCollection<ushort> relations = [];

		[ObservableProperty]
		private byte[] unknown_03;



		public UserControl Panel
		{
			get;
			private set;
		}

		public static IWrapper Unserialize(BinaryReader reader, PackedFile file)
		{
			Sdsc sdsc = new(file);
			sdsc.Unknown_00 = reader.ReadUInt32();
			sdsc.Version = new((SdscVersion)reader.ReadUInt32());
			reader.ReadUInt32();
			sdsc.Sitting = reader.ReadUInt16();
			sdsc.MoneyOverHead = reader.ReadUInt16();
			sdsc.Personality.Nice = reader.ReadUInt16();
			sdsc.Personality.Active = reader.ReadUInt16();
			sdsc.UniEffort = reader.ReadUInt16();
			sdsc.Personality.Playful = reader.ReadUInt16();
			sdsc.Personality.Outgoing = reader.ReadUInt16();
			sdsc.Personality.Neat = reader.ReadUInt16();
			sdsc.CurrentOutfit = reader.ReadUInt16();
			sdsc.Skills.Cleaning = reader.ReadUInt16();
			sdsc.Skills.Cooking = reader.ReadUInt16();
			sdsc.Skills.Charisma = reader.ReadUInt16();
			sdsc.Skills.Mechanical = reader.ReadUInt16();
			reader.ReadUInt16();
			reader.ReadUInt16();
			sdsc.Skills.Creativity = reader.ReadUInt16();
			reader.ReadUInt16();
			sdsc.Skills.Body = reader.ReadUInt16();
			sdsc.Skills.Logic = reader.ReadUInt16();
			sdsc.GroupTalkStateFlags = reader.ReadUInt16();
			reader.ReadUInt16();
			sdsc.CurrentInteractionIndex = reader.ReadUInt16();
			sdsc.MalePreference = reader.ReadInt16();
			sdsc.FemalePreference = reader.ReadInt16();
			sdsc.JobData = reader.ReadUInt16();
			sdsc.InteractionData1 = reader.ReadUInt16();
			sdsc.SubQueueInteractionCount = reader.ReadUInt16();
			sdsc.TickCounter = reader.ReadUInt16();
			sdsc.InteractionData2 = reader.ReadUInt16();
			sdsc.StaticMotives = reader.ReadUInt16();
			sdsc.CensorshipFlags = reader.ReadUInt16();
			sdsc.NeighborID = reader.ReadUInt16();
			sdsc.PersonType = reader.ReadUInt16();
			sdsc.Priority = reader.ReadUInt16();
			sdsc.GreetStatus = reader.ReadUInt16();
			sdsc.VisitorSchedule = reader.ReadUInt16();
			sdsc.AutonomyLevel = reader.ReadUInt16();
			sdsc.RouteSlot = reader.ReadUInt16();
			sdsc.RouteMultiSlotIndex = reader.ReadUInt16();
			sdsc.RouteStatus = reader.ReadUInt16();
			sdsc.RouteGoal = reader.ReadUInt16();
			sdsc.LookAtObjectID = reader.ReadUInt16();
			sdsc.LookAtSlotID = reader.ReadUInt16();
			sdsc.LookAtState = reader.ReadUInt16();
			sdsc.LookAtTimeRemaining = reader.ReadUInt16();
			sdsc.NextQueuedInteractionIndex = reader.ReadUInt16();
			sdsc.Aspiration = reader.ReadUInt16();
			sdsc.OriginalPersonality.Neat = reader.ReadUInt16();
			sdsc.OriginalPersonality.Nice = reader.ReadUInt16();
			sdsc.OriginalPersonality.Active = reader.ReadUInt16();
			sdsc.OriginalPersonality.Outgoing = reader.ReadUInt16();
			sdsc.OriginalPersonality.Playful = reader.ReadUInt16();
			sdsc.SimUIIconFlags = reader.ReadUInt16();
			sdsc.FindBestActionResult = reader.ReadUInt16();
			sdsc.MemoryScore = reader.ReadUInt16();
			sdsc.RouteStartSlot = reader.ReadUInt16();
			sdsc.SchoolGrade = reader.ReadUInt16();
			sdsc.JobPromotionLevel = reader.ReadUInt16();
			sdsc.PersonAge = reader.ReadUInt16();
			sdsc.SocialMenuObjectID = reader.ReadUInt16();
			sdsc.SkinColor = reader.ReadUInt16();
			sdsc.FamilyInstance = reader.ReadUInt16();
			sdsc.RouteResult = reader.ReadUInt16();
			sdsc.JobPerformance = reader.ReadUInt16();
			sdsc.IsSwimming = reader.ReadUInt16();
			sdsc.Gender = new((SdscGender)reader.ReadUInt16());
			sdsc.Private = reader.ReadUInt16();
			sdsc.LingeringHouseInstance = reader.ReadUInt16();
			sdsc.GhostFlags = reader.ReadUInt16();
			sdsc.PaidTimeOff = reader.ReadUInt16();
			sdsc.ZodiacSign = reader.ReadUInt16();
			sdsc.NonInterruptible = reader.ReadUInt16();
			sdsc.NextQueuedInteractionContinuation = reader.ReadUInt16();
			sdsc.FootprintExtension = reader.ReadUInt16();
			sdsc.RenderDisplayFlags = reader.ReadUInt16();
			sdsc.SubQueueMasterInteractionObjectID = reader.ReadUInt16();
			sdsc.SubQueueMasterInteractionIndex = reader.ReadUInt16();
			sdsc.NextSubQueueInteractionIndex = reader.ReadUInt16();
			sdsc.NextSubQueueInteractionObjectID = reader.ReadUInt16();
			sdsc.NextQueuedInteractionObjectID = reader.ReadUInt16();
			sdsc.CurrentInteractionObjectID = reader.ReadUInt16();
			sdsc.BodyFlags = reader.ReadUInt16();
			sdsc.Fatness = reader.ReadUInt16();
			sdsc.UniGrade = reader.ReadUInt16();
			reader.ReadBytes(8);
			sdsc.VoiceType = reader.ReadUInt16();
			sdsc.JobGUID = reader.ReadUInt32();
			sdsc.AgeDaysLeft = reader.ReadUInt16();
			sdsc.DaysInPreviousAge = reader.ReadUInt16();
			sdsc.DecayHunger = reader.ReadInt16();
			sdsc.DecayComfort = reader.ReadInt16();
			sdsc.DecayBladder = reader.ReadInt16();
			sdsc.DecayEnergy = reader.ReadInt16();
			sdsc.DecayHygiene = reader.ReadInt16();
			reader.ReadUInt16();
			sdsc.DecaySocial = reader.ReadInt16();
			reader.ReadUInt16();
			sdsc.DecayFun = reader.ReadInt16();
			sdsc.CurrentRunningInteractionIndex = reader.ReadUInt16();
			sdsc.CurrentRunningInteractionObjectID = reader.ReadUInt16();
			sdsc.Genetics1 = reader.ReadUInt16();
			sdsc.Genetics2 = reader.ReadUInt16();
			sdsc.Genetics3 = reader.ReadUInt16();
			sdsc.SchoolGUID = reader.ReadUInt32();
			sdsc.CurrentInteractionGUID = reader.ReadUInt16();
			sdsc.InteractionsLinkedDeleted = reader.ReadUInt16();
			sdsc.RomanceSkill = reader.ReadUInt16();
			sdsc.LocoWeight0 = reader.ReadUInt16();
			sdsc.LocoWeight1 = reader.ReadUInt16();
			sdsc.LocoPersonalityIndex = reader.ReadUInt16();
			sdsc.LocoPersonalityWeight = reader.ReadUInt16();
			sdsc.LocoMoodIndex = reader.ReadUInt16();
			sdsc.LocoMoodWeight = reader.ReadUInt16();
			sdsc.MotivesNotIncludedInMood = reader.ReadUInt16();
			sdsc.OutfitSourceGUID = reader.ReadUInt32();
			sdsc.EnvironmentScoreOverride = reader.ReadUInt16();
			sdsc.FitnessPreference = reader.ReadUInt16();
			sdsc.Pension = reader.ReadUInt16();
			sdsc.Interests.Politics = reader.ReadUInt16();
			sdsc.Interests.Money = reader.ReadUInt16();
			sdsc.Interests.Environment = reader.ReadUInt16();
			sdsc.Interests.Crime = reader.ReadUInt16();
			sdsc.Interests.Entertainment = reader.ReadUInt16();
			sdsc.Interests.Culture = reader.ReadUInt16();
			sdsc.Interests.Food = reader.ReadUInt16();
			sdsc.Interests.Health = reader.ReadUInt16();
			sdsc.Interests.Fashion = reader.ReadUInt16();
			sdsc.Interests.Sports = reader.ReadUInt16();
			sdsc.Interests.Paranormal = reader.ReadUInt16();
			sdsc.Interests.Travel = reader.ReadUInt16();
			sdsc.Interests.Work = reader.ReadUInt16();
			sdsc.Interests.Weather = reader.ReadUInt16();
			sdsc.Interests.Animals = reader.ReadUInt16();
			sdsc.Interests.School = reader.ReadUInt16();
			sdsc.Interests.Toys = reader.ReadUInt16();
			sdsc.Interests.Scifi = reader.ReadUInt16();
			sdsc.Interests.Unused01 = reader.ReadUInt16();
			sdsc.Interests.Unused02 = reader.ReadUInt16();
			sdsc.Interests.Unused03 = reader.ReadUInt16();
			sdsc.Interests.Unused04 = reader.ReadUInt16();
			sdsc.Interests.Unused05 = reader.ReadUInt16();
			sdsc.Interests.Unused06 = reader.ReadUInt16();
			sdsc.Interests.Unused07 = reader.ReadUInt16();
			sdsc.Interests.Unused08 = reader.ReadUInt16();
			sdsc.Interests.Unused09 = reader.ReadUInt16();
			sdsc.Interests.Unused10 = reader.ReadUInt16();
			sdsc.Interests.Unused11 = reader.ReadUInt16();
			sdsc.Interests.Unused12 = reader.ReadUInt16();
			sdsc.Interests.Unused13 = reader.ReadUInt16();
			sdsc.NPCType = reader.ReadUInt16();
			sdsc.AgeDuration = reader.ReadUInt16();
			sdsc.SubQueueInteractionObjectID = reader.ReadUInt16();
			sdsc.SelectionFlags = reader.ReadUInt16();
			sdsc.PersonFlags = reader.ReadUInt16();
			sdsc.AspirationScore = reader.ReadUInt16();
			sdsc.AspirationRewardPointsSpent = reader.ReadUInt16();
			sdsc.AspirationScoreRaw = reader.ReadUInt16();
			sdsc.MoodBooster = reader.ReadUInt16();
			sdsc.CurrentInteractionJoinable = reader.ReadUInt16();
			sdsc.Unlinked = reader.ReadUInt16();
			sdsc.InteractionAutonomous = reader.ReadUInt16();
			sdsc.RetiredJobGUID = reader.ReadUInt32();
			sdsc.RetiredJobLevel = reader.ReadUInt16();
			if (sdsc.IsUniOrLater)
			{
				sdsc.CollegeMajorGUID = reader.ReadUInt32();
				sdsc.RemainingTimeInSemester = reader.ReadUInt16();
				sdsc.UniFlags = reader.ReadUInt16();
				sdsc.Semester = reader.ReadUInt16();
				sdsc.OnCampus = reader.ReadUInt16();
				sdsc.Unknown_01 = reader.ReadUInt32();
				sdsc.Influence = reader.ReadUInt16();
			}
			if (sdsc.IsNightlifeOrLater)
			{
				sdsc.RouteStartSlotOwnerID = reader.ReadUInt16();
				sdsc.Traits1 = reader.ReadUInt16();
				sdsc.Traits2 = reader.ReadUInt16();
				sdsc.TurnOns1 = reader.ReadUInt16();
				sdsc.TurnOns2 = reader.ReadUInt16();
				sdsc.TurnOffs1 = reader.ReadUInt16();
				sdsc.TurnOffs2 = reader.ReadUInt16();
				sdsc.Species = reader.ReadUInt16();
				sdsc.Countdown = reader.ReadUInt16();
				sdsc.PerfumeTimer = reader.ReadUInt16();
				sdsc.DateTimer = reader.ReadUInt16();
				sdsc.DateScore = reader.ReadUInt16();
				sdsc.DateUnlockCounter = reader.ReadUInt16();
				sdsc.LovePotionTimer = reader.ReadUInt16();
				sdsc.AspirationScoreLock = reader.ReadUInt16();
				sdsc.DateUnlockCounter2 = reader.ReadUInt16();
			}
			if (sdsc.IsBusinessOrLater)
			{
				sdsc.LotID = reader.ReadUInt16();
				sdsc.Salary = reader.ReadUInt16();
				sdsc.OFBFlags = reader.ReadUInt16();
				sdsc.JobAssignment = reader.ReadUInt16();
			}
			if (sdsc.IsPetsOrLater)
			{
				sdsc.PetTraits = reader.ReadUInt16();
			}
			if (sdsc.IsVoyageOrLater)
			{
				sdsc.DaysLeftInVacation = reader.ReadUInt16();
				sdsc.TurnOns3 = reader.ReadUInt16();
				sdsc.TurnOffs3 = reader.ReadUInt16();
				sdsc.Traits3 = reader.ReadUInt16();
			}
			else if (sdsc.IsCastaway)
			{
				sdsc.Subspecies = reader.ReadUInt16();
			}
			if (sdsc.IsFreetimeOrLater)
			{
				sdsc.Hobbies.Cuisine = reader.ReadUInt16();
				sdsc.Hobbies.Arts = reader.ReadUInt16();
				sdsc.Hobbies.Film = reader.ReadUInt16();
				sdsc.Hobbies.Sports = reader.ReadUInt16();
				sdsc.Hobbies.Games = reader.ReadUInt16();
				sdsc.Hobbies.Nature = reader.ReadUInt16();
				sdsc.Hobbies.Tinkering = reader.ReadUInt16();
				sdsc.Hobbies.Fitness = reader.ReadUInt16();
				sdsc.Hobbies.Science = reader.ReadUInt16();
				sdsc.Hobbies.Music = reader.ReadUInt16();
				reader.ReadUInt16();
				sdsc.PredestinedHobby = reader.ReadUInt16();
				sdsc.LifetimeAspiration = reader.ReadUInt16();
				sdsc.LifetimeAspirationPoints = reader.ReadUInt16();
				sdsc.LifetimeAspirationPointsSpent = reader.ReadUInt16();
				sdsc.DecayHungerModifier = reader.ReadUInt16();
				sdsc.DecayComfortModifier = reader.ReadUInt16();
				sdsc.DecayBladderModifier = reader.ReadUInt16();
				sdsc.DecayEnergyModifier = reader.ReadUInt16();
				sdsc.DecayHygieneModifier = reader.ReadUInt16();
				sdsc.DecayFunModifier = reader.ReadUInt16();
				sdsc.DecaySocialModifier = reader.ReadUInt16();
				sdsc.BugsCollection = reader.ReadUInt32();
			}
			if (sdsc.IsApartmentOrLater)
			{
				sdsc.Reputation = reader.ReadUInt16();
				sdsc.ProbabilityToAppear = reader.ReadUInt16();
				sdsc.TitlePostName = reader.ReadUInt16();
			}
			sdsc.SimInstance = reader.ReadUInt16();
			sdsc.SimGUID = reader.ReadUInt32();
			sdsc.Unknown_02 = reader.ReadUInt32();
			int relationCount = reader.ReadInt32();
			for (int i = 0; i < relationCount; i++)
			{
				sdsc.Relations.Add(reader.ReadUInt16());
			}
			sdsc.Unknown_03 = reader.ReadBytes(9);

			sdsc.Panel = new SdscPanel { DataContext = sdsc };

			return sdsc;
		}

		public void Serialize(BinaryWriter writer)
		{
			throw new NotImplementedException();
		}
	}
}
