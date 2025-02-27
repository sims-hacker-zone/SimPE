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
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace SimPe.Data
{
	public enum NeighborhoodSlots
	{
		LotsIntern = 0,
		Lots = 1,
		FamiliesIntern = 2,
		Families = 3,
		SimsIntern = 4,
		Sims = 5,
	}

	/// <summary>
	/// Determins the concrete Type of an Overlay Item (texture or mesh overlay)
	/// </summary>
	public enum TextureOverlayTypes : uint
	{
		Beard = 0x00,
		EyeBrow = 0x01,
		Lipstick = 0x02,
		Eye = 0x03,
		Mask = 0x04,
		Glasses = 0x05,
		Blush = 0x06,
		EyeShadow = 0x07,
	}

	/// <summary>
	/// Ages used for Property Sets (Character Data, Skins)
	/// </summary>
	public enum Ages : uint
	{
		Baby = 0x20,
		Toddler = 0x01,
		Child = 0x02,
		Teen = 0x04,
		Adult = 0x08,
		Elder = 0x10,
		YoungAdult = 0x40,
	}

	/// <summary>
	/// Categories used for Property Sets (Skins) (Updated by Theo)
	/// </summary>
	[Flags]
	public enum SkinCategories : uint
	{
		Casual1 = 0x01,
		Casual2 = 0x02,
		Casual3 = 0x04,
		Everyday = Casual1 | Casual2 | Casual3,
		Swimmwear = 0x08,
		PJ = 0x10,
		Formal = 0x20,
		Undies = 0x40,
		Skin = 0x80,
		Pregnant = 0x100,
		Activewear = 0x200,
		TryOn = 0x400,
		NakedOverlay = 0x800,
		Outerwear = 0x1000,
		Hair = 0x2000, // does not exist so won't be used but gives me somewhere to shove hair out of the way when browsing for clothes
	}

	/// <summary>
	/// outfit type used for Property Sets (Skins)
	/// </summary>
	[Flags]
	public enum SkinParts : uint
	{
		Hair = 0x01,
		Face = 0x02,
		Top = 0x04,
		Body = 0x08,
		Bottom = 0x10,
		Jewellery = 0x20,
		LongTail = 0x40,
		Ear_Up = 0x80,
		ShortTail = 0x100,
		Ear_Flop = 0x200,
		LongBrushTail = 0x400,
		ShortBrushTail = 0x800,
		SpitzTail = 0x1000,
		LongFlowingTail = 0x2000,
	}

	/// <summary>
	/// Categories used for the clothing scanner, the naming above appears and is bloody awfull
	/// </summary>
	[Flags]
	public enum OutfitCats : uint
	{
		Everyday = 0x07,
		Swimsuit = 0x08, // Swimmwear
		Pyjamas = 0x10,
		Formal = 0x20,
		Underwear = 0x40, //Undies
		Skin = 0x80,
		Maternity = 0x100, //Pregnant
		Gym = 0x200, //Activewear
		TryOn = 0x400,
		NakedOverlay = 0x800,
		WinterWear = 0x1000, // Outerwear
	}

	/// <summary>
	/// Gender of a Sim used for Property Sets (Skins & Clothing)
	/// </summary>
	public enum Sex : uint
	{
		Male = 0x02,
		Female = 0x01,
	}

	public enum SimGender
	{
		Unspecified = 0,
		Female = 1,
		Male = 2,
		Both = Female | Male,
	}

	/// <summary>
	///
	/// </summary>
	public enum Majors : uint
	{
		Unset = 0,
		Unknown = 0xffffffff,
		Art = 0x2e9cf007,
		Biology = 0x4e9cf02b,
		Drama = 0x4e9cf04d,
		Economics = 0xEe9cf044,
		History = 0x2e9cf074,
		Literature = 0xce9cf085,
		Mathematics = 0xee9cf08d,
		Philosophy = 0x2e9cf057,
		Physics = 0xae9cf063,
		PoliticalScience = 0x4e9cf06d,
		Psychology = 0xCE9CF07C,
		Undeclared = 0x8e97bf1d,
	}

	/// <summary>
	/// Catalogue Use Flag
	/// </summary>
	public enum ObjCatalogueUseBits : byte
	{
		Adults = 0x00,
		Children = 0x01,
		Group = 0x02,
		Teens = 0x03,
		Elders = 0x04,
		Toddlers = 0x05,
	}

	/// <summary>
	/// Room Sort Flag
	/// </summary>
	public enum ObjRoomSortBits : byte
	{
		Kitchen = 0x00,
		Bedroom = 0x01,
		Bathroom = 0x02,
		LivingRoom = 0x03,
		Outside = 0x04,
		DiningRoom = 0x05,
		Misc = 0x06,
		Study = 0x07,
		Kids = 0x08,
	}

	/// <summary>
	/// Build type Flag
	/// </summary>
	public enum ObjBuildTypeBits : byte
	{
		General = 0x00,
		unknown = 0x01,
		Garden = 0x02,
		Openings = 0x03,
	}

	/// <summary>
	/// Build Function Sort Flag
	/// </summary>
	/// <remarks>the higher 2 bytes contains the <see cref="ObjFunctionSortBits"/>, the lower one the actual SubSort</remarks>
	public enum BuildFunctionSubSort : uint
	{
		none = 0x00000,
		General_Columns = 0x10008,
		General_Stairs = 0x10020,
		General_Pool = 0x10040,
		General_TallColumns = 0x10100,
		General_Arch = 0x10200,
		General_Driveway = 0x10400,
		General_Elevator = 0x10800,
		General_Architectural = 0x11000,

		Garden_Trees = 0x40001,
		Garden_Shrubs = 0x40002,
		Garden_Flowers = 0x40004,
		Garden_Objects = 0x40010,

		Openings_Door = 0x80001,
		Openings_TallWindow = 0x80002,
		Openings_Window = 0x80004,
		Openings_Gate = 0x80008,
		Openings_Arch = 0x80010,
		Openings_TallDoor = 0x80100,

		unknown = 0x00069, // just to locate unknown things, is read but not written
	}

	/// <summary>
	/// Community Room Sort Flag
	/// </summary>
	public enum CommRoomSortBits : byte
	{
		Dining = 0x00,
		Shopping = 0x01,
		Outdoor = 0x02,
		Street = 0x03,
		Misc = 0x07,
	}

	/// <summary>
	/// Function Sort Flag
	/// </summary>
	public enum ObjFunctionSortBits : byte
	{
		Seating = 0x00,
		Surfaces = 0x01,
		Appliances = 0x02,
		Electronics = 0x03,
		Plumbing = 0x04,
		Decorative = 0x05,
		General = 0x06,
		Lighting = 0x07,
		Hobbies = 0x08,
		AspirationRewards = 0x0a,
		CareerRewards = 0x0b,
	}

	/// <summary>
	/// Function for xml Based Objects
	/// </summary>
	public enum XObjFunctionSubSort : uint
	{
		Roof = 0x0100,

		Floor_Brick = 0x0201,
		Floor_Carpet = 0x0202,
		Floor_Lino = 0x0204,
		Floor_Poured = 0x0208,
		Floor_Stone = 0x0210,
		Floor_Tile = 0x0220,
		Floor_Wood = 0x0240,
		Floor_Other = 0x0200,

		Fence_Rail = 0x0400,
		Fence_Halfwall = 0x0401,

		Wall_Brick = 0x0501,
		Wall_Masonry = 0x0502,
		Wall_Paint = 0x0504,
		Wall_Paneling = 0x0508,
		Wall_Poured = 0x0510,
		Wall_Siding = 0x0520,
		Wall_Tile = 0x0540,
		Wall_Wallpaper = 0x0580,
		Wall_Other = 0x0500,

		Terrain = 0x0600,

		Hood_Landmark = 0x0701,
		Hood_Flora = 0x0702,
		Hood_Effects = 0x0703,
		Hood_Misc = 0x0704,
		Hood_Stone = 0x0705,
		Hood_Other = 0x0700,
	}

	/// <summary>
	/// Function Sort Flag
	/// </summary>
	/// <remarks>the higher byte contains the <see cref="ObjFunctionSortBits"/>, the lower one the actual SubSort</remarks>
	public enum ObjFunctionSubSort : uint
	{
		none = 0x0000,
		Seating_DiningroomChair = 0x101,
		Seating_LivingroomChair = 0x102,
		Seating_Sofas = 0x104,
		Seating_Beds = 0x108,
		Seating_Recreation = 0x110,
		Seating_UnknownA = 0x120,
		Seating_UnknownB = 0x140,
		Seating_Misc = 0x180,

		Surfaces_Counter = 0x201,
		Surfaces_Table = 0x202,
		Surfaces_EndTable = 0x204,
		Surfaces_Desks = 0x208,
		Surfaces_Coffeetable = 0x210,
		Surfaces_Business = 0x220,
		Surfaces_UnknownB = 0x240,
		Surfaces_Misc = 0x280,

		Decorative_Wall = 0x2001,
		Decorative_Sculpture = 0x2002,
		Decorative_Rugs = 0x2004,
		Decorative_Plants = 0x2008,
		Decorative_Mirror = 0x2010,
		Decorative_Curtain = 0x2020,
		Decorative_UnknownB = 0x2040,
		Decorative_Misc = 0x2080,

		Plumbing_Toilet = 0x1001,
		Plumbing_Shower = 0x1002,
		Plumbing_Sink = 0x1004,
		Plumbing_HotTub = 0x1008,
		Plumbing_UnknownA = 0x1010,
		Plumbing_UnknownB = 0x1020,
		Plumbing_UnknownC = 0x1040,
		Plumbing_Misc = 0x1080,

		Appliances_Cooking = 0x401,
		Appliances_Refrigerator = 0x402,
		Appliances_Small = 0x404,
		Appliances_Large = 0x408,
		Appliances_UnknownA = 0x410,
		Appliances_UnknownB = 0x420,
		Appliances_UnknownC = 0x440,
		Appliances_Misc = 0x480,

		Electronics_Entertainment = 0x801,
		Electronics_TV_and_Computer = 0x802,
		Electronics_Audio = 0x804,
		Electronics_Small = 0x808,
		Electronics_UnknownA = 0x810,
		Electronics_UnknownB = 0x820,
		Electronics_UnknownC = 0x840,
		Electronics_Misc = 0x880,

		Lighting_TableLamp = 0x8001,
		Lighting_FloorLamp = 0x8002,
		Lighting_WallLamp = 0x8004,
		Lighting_CeilingLamp = 0x8008,
		Lighting_Outdoor = 0x8010,
		Lighting_UnknownA = 0x8020,
		Lighting_UnknownB = 0x8040,
		Lighting_Misc = 0x8080,

		Hobbies_Creative = 0x10001,
		Hobbies_Knowledge = 0x10002,
		Hobbies_Excerising = 0x10004,
		Hobbies_Recreation = 0x10008,
		Hobbies_UnknownA = 0x10010,
		Hobbies_UnknownB = 0x10020,
		Hobbies_UnknownC = 0x10040,
		Hobbies_Misc = 0x10080,

		General_UnknownA = 0x4001,
		General_Dresser = 0x4002,
		General_UnknownB = 0x4004,
		General_Party = 0x4008,
		General_Child = 0x4010,
		General_Car = 0x4020,
		General_Pets = 0x4040,
		General_Misc = 0x4080,

		AspirationRewards_UnknownA = 0x40001,
		AspirationRewards_UnknownB = 0x40002,
		AspirationRewards_UnknownC = 0x40004,
		AspirationRewards_UnknownD = 0x40008,
		AspirationRewards_UnknownE = 0x40010,
		AspirationRewards_UnknownF = 0x40020,
		AspirationRewards_UnknownG = 0x40040,
		AspirationRewards_UnknownH = 0x40080,

		CareerRewards_UnknownA = 0x80001,
		CareerRewards_UnknownB = 0x80002,
		CareerRewards_UnknownC = 0x80004,
		CareerRewards_UnknownD = 0x80008,
		CareerRewards_UnknownE = 0x80010,
		CareerRewards_UnknownF = 0x80020,
		CareerRewards_UnknownG = 0x80040,
		CareerRewards_UnknownH = 0x80080,
	}

	/// <summary>
	/// Enumerates known Object Types
	/// </summary>
	public enum ObjectTypes : ushort
	{
		Unknown = 0x0000,
		Person = 0x0002,
		Normal = 0x0004,
		ArchitecturalSupport = 0x0005,
		SimType = 0x0007,
		Door = 0x0008,
		Window = 0x0009,
		Stairs = 0x000A,
		ModularStairs = 0x000B,
		ModularStairsPortal = 0x000C,
		Vehicle = 0x000D,
		Outfit = 0x000E,
		Memory = 0x000F,
		Template = 0x0010,
		UnlinkedSim = 0x0011,
		Tiles = 0x0013,
	}

	/// <summary>
	/// Hold Constants, Enumerations and other Metadata
	/// </summary>
	public class MetaData
	{
		/// <summary>
		/// Color of a Sim that is either Unlinked or does not have Character Data
		/// </summary>
		public static Color SpecialSimColor = Color.FromArgb(0xD0, Color.Black);

		/// <summary>
		/// Color of a Sim that is unlinked
		/// </summary>
		public static Color UnlinkedSim = Color.FromArgb(0xEF, Color.SteelBlue);

		/// <summary>
		/// Color of a NPC Sim
		/// </summary>
		public static Color NPCSim = Color.FromArgb(0xEF, Color.YellowGreen);

		/// <summary>
		/// Color of a Sim that has no Character Data
		/// </summary>
		public static Color InactiveSim = Color.FromArgb(0xEF, Color.LightCoral);

		#region Constants

		/// <summary>
		/// Group for Costum Content
		/// </summary>
		public const UInt32 CUSTOM_GROUP = 0x1C050000;

		/// <summary>
		/// Group for Global Content
		/// </summary>
		public const UInt32 GLOBAL_GROUP = 0x1C0532FA;

		/// <summary>
		/// Group for Local Content
		/// </summary>
		public const UInt32 LOCAL_GROUP = 0xffffffff;

		/// <summary>
		/// A Directory file will have this Type in the fileindex.
		/// </summary>
		public const UInt32 DIRECTORY_FILE = 0xE86B1EEF; //0xEF1E6BE8;

		/// <summary>
		/// Stores the relationship Value for a Sim
		/// </summary>
		public const UInt32 RELATION_FILE = 0xCC364C2A;

		/// <summary>
		/// File Containing Strings
		/// </summary>
		public const UInt32 STRING_FILE = 0x53545223;

		/// <summary>
		/// File Containing Pie Strings
		/// </summary>
		public const UInt32 PIE_STRING_FILE = 0x54544173;

		/// <summary>
		/// File Containing Sim Descriptions
		/// </summary>
		public const UInt32 SIM_DESCRIPTION_FILE = 0xAACE2EFB;

		/// <summary>
		/// Files Containing Sim Images
		/// </summary>
		public const UInt32 SIM_IMAGE_FILE = 0x856DDBAC;

		/// <summary>
		/// The File containing all Family Ties
		/// </summary>
		public const UInt32 FAMILY_TIES_FILE = 0x8C870743;

		/// <summary>
		/// File containing BHAV Informations
		/// </summary>
		public const UInt32 BHAV_FILE = 0x42484156;

		/// <summary>
		/// File containng Global Data
		/// </summary>
		public const UInt32 GLOB_FILE = 0x474C4F42;

		/// <summary>
		/// File Containing Object Data
		/// </summary>
		public const UInt32 OBJD_FILE = 0x4F424A44;

		/// <summary>
		/// File Containing Catalog Strings
		/// </summary>
		public const UInt32 CTSS_FILE = 0x43545353;

		/// <summary>
		/// File Containing Name Maps
		/// </summary>
		public const UInt32 NAME_MAP = 0x4E6D6150;

		/// <summary>
		/// Neighborhood/Memory File Typesss
		/// </summary>
		public const UInt32 MEMORIES = 0x4E474248;

		/// <summary>
		/// Sim DNA
		/// </summary>
		public const uint SDNA = 0xEBFEE33F;

		/// <summary>
		/// Signature identifying a compressed PackedFile
		/// </summary>
		public const ushort COMPRESS_SIGNATURE = 0xFB10;

		public const uint GZPS = 0xEBCF3E27;
		public const uint XWNT = 0xED7D7B4D;
		public const uint REF_FILE = 0xAC506764;
		public const uint IDNO = 0xAC8A7A2E;
		public const uint HOUS = 0x484F5553;
		public const uint SLOT = 0x534C4F54;

		public const uint GMND = 0x7BA3838C;
		public const uint TXMT = 0x49596978;
		public const uint TXTR = 0x1C4A276C;
		public const uint LIFO = 0xED534136;
		public const uint ANIM = 0xFB00791E;
		public const uint SHPE = 0xFC6EB1F7;
		public const uint CRES = 0xE519C933;
		public const uint GMDC = 0xAC4F8687;
		public const uint LDIR = 0xC9C81B9B;
		public const uint LAMB = 0xC9C81BA3;
		public const uint LPNT = 0xC9C81BA9;
		public const uint LSPT = 0xC9C81BAD;

		public const uint MMAT = 0x4C697E5A;
		public const uint XOBJ = 0xCCA8E925;
		public const uint XROF = 0xACA8EA06;
		public const uint XFLR = 0x4DCADB7E;
		public const uint XFNC = 0x2CB230B8;
		public const uint XNGB = 0x6D619378;

		public const uint GLUA = 0x9012468A;
		public const uint OLUA = 0x9012468B;
		public const uint GINV = 0x0ABA73AF;

		public const uint XHTN = 0x8C1580B5;
		public const uint XTOL = 0x2C1FD8A1;
		public const uint XMOL = 0x0C1FE246;
		public const uint XSTN = 0x4C158081;
		public const uint AGED = 0xAC598EAC;
		public const uint LxNR = 0xCCCEF852;
		public const uint BINX = 0x0C560F39;
		#endregion

		#region CEP Strings

		public static string GMND_PACKAGE = System.IO.Path.Combine(
			PathProvider.SimSavegameFolder,
			"Downloads\\_EnableColorOptionsGMND.package"
		);
		public static string MMAT_PACKAGE = System.IO.Path.Combine(
			PathProvider.Global.GetExpansion(Expansions.BaseGame).InstallFolder,
			"TSData\\Res\\Sims3D\\_EnableColorOptionsMMAT.package"
		);
		public static string ZCEP_FOLDER = System.IO.Path.Combine(
			PathProvider.SimSavegameFolder,
			"zCEP-EXTRA"
		);
		public static string CTLG_FOLDER = System.IO.Path.Combine(
			PathProvider.Global.GetExpansion(Expansions.BaseGame).InstallFolder,
			"TSData\\Res\\Catalog\\zCEP-EXTRA"
		);

		#endregion

		#region Enums

		/// <summary>
		/// Type of school a Sim attends
		/// </summary>
		public enum SchoolTypes : uint
		{
			Unknown = 0xFFFFFFFF,
			NoSchool = 0x00000000,
			PublicSchool = 0xD06788B5,
			PrivateSchool = 0xCC8F4C11,
		}

		/// <summary>
		/// Available Grades
		/// </summary>
		public enum Grades : ushort
		{
			Unknown = 0x00,
			F = 0x01,
			DMinus = 0x02,
			D = 0x03,
			DPlus = 0x04,
			CMinus = 0x05,
			C = 0x06,
			CPlus = 0x07,
			BMinus = 0x08,
			B = 0x09,
			BPlus = 0x0A,
			AMinus = 0x0B,
			A = 0x0C,
			APlus = 0x0D,
		}

		/// <summary>
		/// Enumerates known Languages - CJH
		/// </summary>
		public enum Languages : byte
		{
			Unknown = 0x00,
			English = 0x01,
			English_uk = 0x02,
			French = 0x03,
			German = 0x04,
			Italian = 0x05,
			Spanish = 0x06,
			Dutch = 0x07,
			Danish = 0x08,
			Swedish = 0x09,
			Norwegian = 0x0a,
			Finnish = 0x0b,
			Hebrew = 0x0c,
			Russian = 0x0d,
			Portuguese = 0x0e,
			Japanese = 0x0f,
			Polish = 0x10,
			SimplifiedChinese = 0x11,
			TraditionalChinese = 0x12,
			Thai = 0x13,
			Korean = 0x14,
			Hindi = 0x15,
			Arabic = 0x16,
			Bulgarian = 0x17,
			Cyrillic = 0x18,
			Ukranian = 0x19,
			Czech = 0x1a,
			Greek = 0x1b,
			Hungarian = 0x1c,
			Icelandic = 0x1d,
			Romanian = 0x1e,
			Latin = 0x1f,
			Slovak = 0x20,
			Albabian = 0x21,
			Turkish = 0x22,
			Brazilian = 0x23,
			SwissFrench = 0x24,
			CanadianFrench = 0x25,
			BelgianFrench = 0x26,
			SwissGerman = 0x27,
			SwissItalian = 0x28,
			BelgianDutch = 0x29,
			Mexican = 0x2a,
			Tagalog = 0x2b,
			Vietnamese = 0x2c,
		}

		/// <summary>
		/// Enumerates available Datatypes
		/// </summary>
		public enum DataTypes : uint
		{
			dtUInteger = 0xEB61E4F7,
			dtString = 0x0B8BEA18,
			dtSingle = 0xABC78708,
			dtBoolean = 0xCBA908E1,
			dtInteger = 0x0C264712,
		}

		/// <summary>
		/// Available Format Codes
		/// </summary>
		public enum FormatCode : ushort
		{
			normal = 0xFFFD,
		};

		/// <summary>
		/// Is an Item within the PackedFile Index new Alias(0x20 , "or 0x24 Bytes long"),
		/// </summary>
		public enum IndexTypes : uint
		{
			ptShortFileIndex = 0x01,
			ptLongFileIndex = 0x02,
		}

		/// <summary>
		/// Which general apiration does a Sim have
		/// </summary>
		public enum AspirationTypes : ushort
		{
			Nothing = 0x00,
			Romance = 0x01,
			Family = 0x02,
			Fortune = 0x04,

			// Power = 0x08,
			Reputation = 0x10,
			Knowledge = 0x20,
			Growup = 0x40,
			Pleasure = 0x80,
			Chees = 0x100,
		}

		/// <summary>
		/// Relationships a Sim can have
		/// </summary>
		public enum RelationshipStateBits : byte
		{
			Crush = 0x00,
			Love = 0x01,
			Engaged = 0x02,
			Married = 0x03,
			Friends = 0x04,
			Buddies = 0x05,
			Steady = 0x06,
			Enemy = 0x07,
			Family = 0x0E,
			Known = 0x0F,
		}

		/// <summary>
		/// UIFlags2 - more relationship states
		/// </summary>
		public enum UIFlags2Names : byte
		{
			BestFriendForever = 0x00,
		};

		/// <summary>
		/// Available Zodia Signes
		/// </summary>
		public enum ZodiacSignes : ushort
		{
			Aries = 0x01, //de: Widder
			Taurus = 0x02,
			Gemini = 0x03,
			Cancer = 0x04,
			Leo = 0x05,
			Virgo = 0x06, //de: Jungfrau
			Libra = 0x07, //de: Waage
			Scorpio = 0x08,
			Sagittarius = 0x09, //de: Sch�tze
			Capricorn = 0x0A, //de: Steinbock
			Aquarius = 0x0B,
			Pisces = 0x0C, //de: Fische
		}

		/// <summary>
		/// Known Types for Family ties
		/// </summary>
		public enum FamilyTieTypes : uint
		{
			MyMotherIs = 0x00,
			MyFatherIs = 0x01,
			ImMarriedTo = 0x02,
			MySiblingIs = 0x03,
			MyChildIs = 0x04,
		}

		/// <summary>
		/// Detailed Relationships between Sims
		/// </summary>
		public enum RelationshipTypes : uint
		{
			Unset_Unknown = 0x00,
			Parent = 0x01,
			Child = 0x02,
			Sibling = 0x03,
			Gradparent = 0x04,
			Grandchild = 0x05,
			Nice_Nephew = 0x07,
			Aunt = 0x06,
			Cousin = 0x08,
			Spouses = 0x09,
			Child_Inlaw = 0x0a,
			Parent_Inlaw = 0x0b,
			Sibling_Inlaw = 0x0c,
		}

		/// <summary>
		/// Known NPC Types
		/// </summary>
		public enum ServiceTypes : uint
		{
			Normal = 0x00,
			Bartenderb = 0x01,
			Bartenderp = 0x02,
			Boss = 0x03,
			Burglar = 0x04,
			Driver = 0x05,
			Streaker = 0x06,
			Coach = 0x07,
			LunchLady = 0x08,
			Cop = 0x09,
			Delivery = 0x0A,
			Exterminator = 0x0B,
			FireFighter = 0x0C,
			Gardener = 0x0D,
			Barista = 0x0E,
			Grim = 0x0F,
			Handy = 0x10,
			Headmistress = 0x11,
			Matchmaker = 0x12,
			Maid = 0x13,
			MailCarrier = 0x14,
			Nanny = 0x15,
			Paper = 0x16,
			Pizza = 0x17,
			Professor = 0x18,
			EvilMascot = 0x19,
			Repo = 0x1A,
			CheerLeader = 0x1B,
			Mascot = 0x1C,
			SocialBunny = 0x1D,
			SocialWorker = 0x1E,
			Register = 0x1F,
			Therapist = 0x20,
			Chinese = 0x21,
			Podium = 0x22,
			Waitress = 0x23,
			Chef = 0x24,
			DJ = 0x25,
			Crumplebottom = 0x26,
			Vampyre = 0x27,
			Servo = 0x28,
			Reporter = 0x29,
			Salon = 0x2A,
			Wolf = 0x2B,
			WolfLOTP = 0x2C,
			Skunk = 0x2D,
			AnimalControl = 0x2E,
			Obedience = 0x2F,
			Masseuse = 0x30,
			Bellhop = 0x31,
			Villain = 0x32,
			TourGuide = 0x33,
			Hermit = 0x34,
			Ninja = 0x35,
			BigFoot = 0x36,
			Housekeeper = 0x37,
			FoodStandChef = 0x38,
			FireDancer = 0x39,
			WitchDoctor = 0x3A,
			GhostCaptain = 0x3B,
			FoodJudge = 0x3C,
			Genie = 0x3D,
			exDJ = 0x3E,
			exGypsy = 0x3F,
			Witch1 = 0x40,
			Breakdancer = 0x41,
			SpectralCat = 0x42,
			Statue = 0x43,
			Landlord = 0x44,
			Butler = 0x45,
			hotdogchef = 0x46,
			assistant = 0x47,
			exWitch2 = 0x48,
			Mermaid = 0x49,
			MeterMaid = 0x4A,
			Servant = 0x4B,
			Teacher = 0x4C,
			God = 0x4D,
			Preacher = 0x4E,
			TinySim = 0x4F,
			Nurse = 0x50,
			Pandora = 0xAC,
			DMASim = 0xDA,
			icontrol = 0xE9,
		}

		/// <summary>
		/// How old (in Life Sections) is the Sim
		/// </summary>
		public enum LifeSections : ushort
		{
			Unknown = 0x00,
			Baby = 0x01,
			Toddler = 0x02,
			Child = 0x03,
			Teen = 0x10,
			Adult = 0x13,
			Elder = 0x33,
			YoungAdult = 0x40,
		}

		/// <summary>
		/// Gender of a Sim
		/// </summary>
		public enum Gender : ushort
		{
			Male = 0x00,
			Female = 0x01,
		}

		/// <summary>
		/// The Jobs known by SimPe
		/// </summary>
		/// <remarks>Use finder dock object search for JobData*</remarks>
		public enum Careers : uint
		{
			Unknown = 0xFFFFFFFF,
			Unemployed = 0x00000000,
			TeenElderAthletic = 0xAC89E947,
			TeenElderBusiness = 0x4C1E0577,
			TeenElderCriminal = 0xACA07ACD,
			TeenElderCulinary = 0x4CA07B0C,
			TeenElderLawEnforcement = 0x6CA07B39,
			TeenElderMedical = 0xAC89E918,
			TeenElderMilitary = 0xCCA07B66,
			TeenElderPolitics = 0xCCA07B8D,
			TeenElderScience = 0xECA07BB0,
			TeenElderSlacker = 0x6CA07BDC,
			TeenElderAdventurer = 0xF240D235,
			TeenElderEducation = 0xD243BBEC,
			TeenElderGamer = 0x1240C962,
			TeenElderJournalism = 0x5240E212,
			TeenElderLaw = 0x1243BBDE,
			TeenElderMusic = 0xB243BBD2,
			TeenElderConstruction = 0x53E1C30F,
			TeenElderDance = 0xD3E094A5,
			TeenElderEntertainment = 0x53E09494,
			TeenElderIntelligence = 0x93E094C0,
			TeenElderOcenography = 0x13E09443,
			TeenElderSexIndustry = 0x00845D11,
			TeenElderCrafter = 0xF3A37D20,
			TeenElderGatherer = 0xB3A37CE1,
			TeenElderHunter = 0x7383E1DD,
			Military = 0x6C9EBD32,
			Politics = 0x2C945B14,
			Science = 0x0C9EBD47,
			Medical = 0x0C7761FD,
			Athletic = 0x2C89E95F,
			Economy = 0x45196555,
			LawEnforcement = 0xAC9EBCE3,
			Culinary = 0xEC9EBD5F,
			Slacker = 0xEC77620B,
			Criminal = 0x6C9EBD0E,
			Paranormal = 0x2E6FFF87,
			NaturalScientist = 0xEE70001C,
			ShowBiz = 0xAE6FFFB0,
			Artist = 0x4E6FFFBC,
			Adventurer = 0x3240CBA5,
			Education = 0x72428B30,
			Gamer = 0xF240C306,
			Journalism = 0x7240D944,
			Law = 0x12428B19,
			Music = 0xB2428B0C,
			Construction = 0xF3E1C301,
			Dance = 0xD3E09422,
			Entertainment = 0xB3E09417,
			Intelligence = 0x33E0940E,
			Ocenography = 0x73E09404,
			SexIndustry = 0x00845D10,
			LiveInServant = 0x00845D99,
			Crafter = 0xD38D6534,
			Gatherer = 0x738D6245,
			Hunter = 0x93701850,
			EntertainLS = 0x117DF1D4,
			GameDevelopment = 0x713E7857,
			PetSecurity = 0xD188A400,
			PetService = 0xB188A4C1,
			PetShowBiz = 0xD175CC2D,
			OrangutanCrafter = 0xD3ACF0E0,
			OrangutanGatherer = 0x53ACF0CD,
			OrangutanHunter = 0xF3ACF09E,
			OwnedBuss = 0xD08F400A,
			TeenOwnedBuss = 0x316BD91F,
		}

		/// <summary>
		/// Body Shapes
		/// </summary>
		public enum Bodyshape : uint
		{
			// MISC:
			Default = 0x00,
			Tiny = 0x13,
			Elder = 0x15,
			Maxis = 0x1e,
			Holiday = 0x1f,
			Goth = 0x20,
			SteamPunk = 0x21,
			Medieval = 0x22,
			StoneAge = 0x23,
			Pirates = 0x24,
			Grungy = 0x26,
			Castaway = 0x27,
			SuperHeros = 0x29,
			Futuristic = 0x2a,
			Various = 0x2c,
			Werewolves = 0x2d,
			Satyrs = 0x2f,
			Centaurs = 0x30,
			Mermaid = 0x31,
			HugeBBBeast = 0x33,
			Fannystein = 0x35,
			Quarians = 0x36,
		}

		/// <summary>
		/// Available EPs
		/// </summary>
		public enum NeighbourhoodEP : uint
		{
			BaseGame = 0x00,
			University = 0x01,
			Nightlife = 0x02,
			Business = 0x03,
			FamilyFun = 0x04,
			GlamourLife = 0x05,
			Pets = 0x06,
			Seasons = 0x07,
			Celebration = 0x08,
			Fashion = 0x09,
			BonVoyage = 0x0a,
			TeenStyle = 0x0b,
			StoreEdition_old = 0x0c,
			Freetime = 0x0d,
			KitchenBath = 0x0e,
			IkeaHome = 0x0f,
			ApartmentLife = 0x10,
			MansionGarden = 0x11,
			StoreEdition = 0x1f,
		}

		#endregion

		#region Dictionarys
		// Here is me learning & trying out stuff. Dictionary allows spaces and stuff in the returned string
		// whereas enum don't because enum is a nasty poo poo. Dictionary also allows conditional adding of values.
		//  Would be nice if nasty poo poo did that as well, could add careers according to EPs installed.

		public static Dictionary<uint, string> NPCNameFromID =
			new Dictionary<uint, string>();

		/// <summary>
		/// Convert the GUID to a name for known NPCs
		/// </summary>
		public static string GetKnownNPC(uint id)
		{
			if (NPCNameFromID.Count < 2)
			{
				InitializeNPCNameFromID();
			}

			if (NPCNameFromID.ContainsKey(id))
			{
				return NPCNameFromID[id];
			}

			return "not found";
		}

		private static void InitializeNPCNameFromID()
		{
			NPCNameFromID.Clear();
			NPCNameFromID.Add(0x00000000, "-none-");
			NPCNameFromID.Add(0x4D9530C6, "Therapist");
			NPCNameFromID.Add(0x13269F2D, "Bigfoot");
			NPCNameFromID.Add(0x0F67E576, "Mrs. CrumpleBottom");
			NPCNameFromID.Add(0x2E17B9FC, "Pollination Technician");
			NPCNameFromID.Add(0x724CD298, "ideal plantsim");
			NPCNameFromID.Add(0x71B85E0D, "Skunk Skin (not a real sim)");
			NPCNameFromID.Add(0x745B11D1, "Rod Humble");
			NPCNameFromID.Add(0x341FB0E2, "Genie Midlock");
			NPCNameFromID.Add(0x136B1F2A, "Pirate Captain Edward Dregg");
			NPCNameFromID.Add(0xF03AE97B, "Father Time");
			NPCNameFromID.Add(0x7040237A, "Toddler Time");
			NPCNameFromID.Add(0xD55EF625, "Good Witch Cat");
			NPCNameFromID.Add(0x2C996F9C, "Remote Control Car (Controller)");
			NPCNameFromID.Add(0xB38590EB, "Witch Doctor");
			NPCNameFromID.Add(0xF036D5C3, "Santa Claus");
			NPCNameFromID.Add(0x50596292, "Robot (Controller)");
			NPCNameFromID.Add(0x84EC24A8, "Grim Reaper");
			NPCNameFromID.Add(0xF51A5E5B, "Spectral Assistant");
			NPCNameFromID.Add(0x31946C3B, "Bird (Controller)");
			NPCNameFromID.Add(0x7250E297, "Penguin (Controller)");
			NPCNameFromID.Add(0x2D7EB2DC, "Hula Zombie");
			NPCNameFromID.Add(0x51BFB2CD, "Stinky Skunk");
			NPCNameFromID.Add(0xF036D596, "Mrs. Santa Claus");
			NPCNameFromID.Add(0x00845D9E, "Josaphine Prim");
			NPCNameFromID.Add(0x0055FD4B, "Doctor Abbie");
			NPCNameFromID.Add(0x00845D7D, "Barbarella Fonda");
			NPCNameFromID.Add(0x00845DD5, "Devil Man");
			NPCNameFromID.Add(0x006D2D04, "Janice Juggs");
			NPCNameFromID.Add(0x006D2DFD, "Snow Queen");
			NPCNameFromID.Add(0x006D2D02, "Sister Cheeky");
			NPCNameFromID.Add(0x006D2D54, "Peter Little");
			NPCNameFromID.Add(0xF7E4AE00, "Matron Feelgood");
			NPCNameFromID.Add(0x006D2D5B, "Gremlin Girl");
			NPCNameFromID.Add(0x00845D1F, "Madame Effie");
			NPCNameFromID.Add(0xACB58C44, "Demo Dummy");
			NPCNameFromID.Add(0x9985408B, "Guardian Angel Susan");
			NPCNameFromID.Add(0x0055FD71, "Sally Tipple");
			NPCNameFromID.Add(0x00845D42, "Devil Woman");
			NPCNameFromID.Add(0x00845D21, "Fanny Stein");
			NPCNameFromID.Add(0x006D2D53, "Wendy Tiny");
			NPCNameFromID.Add(0x19FD6E87, "Bubbles The Mermaid");
			NPCNameFromID.Add(0x0055FD4D, "Doctor Boobs");
			NPCNameFromID.Add(0x00845D22, "Frankie Stein");
			NPCNameFromID.Add(0x006D2D3A, "Barbie Susyt");
			NPCNameFromID.Add(0x00845D40, "Halle Berry");
			NPCNameFromID.Add(0x00845DD6, "Guardian Angel Larry");
			NPCNameFromID.Add(0x008BB212, "Vicky (Controller)");
			NPCNameFromID.Add(0x008BB257, "Doctor Dick");
			NPCNameFromID.Add(0x008BB27F, "Sheriff Annie");
			// The following is a template from Pet Stories but Maxis left it in as sim so it will exist
			NPCNameFromID.Add(0x926DF19F, "Dog Show Judge");
			// The following are templates from Castaway Stories but Maxis left them in as sims so they will exist
			NPCNameFromID.Add(0x73352057, "Wild Dog Template");
			NPCNameFromID.Add(0x134B4BCC, "Jaguar Template");
			NPCNameFromID.Add(0xB350BB5B, "Orangutan Template");
			NPCNameFromID.Add(0x33F54396, "Penguin Party Template");
			// The following is a templates not a sim but Maxis left it in Bluewater Village as a sim
			NPCNameFromID.Add(0x0F83C946, "Dog Template");
			// The following custom sims may be in Downloads Folder
			NPCNameFromID.Add(0x0000094E, "Bumpercar Controller");
			NPCNameFromID.Add(0x00000950, "Male Clown");
			NPCNameFromID.Add(0x00000956, "Female Clown");
			NPCNameFromID.Add(0x00000957, "Skeleton Controller");
			NPCNameFromID.Add(0x0018F2B7, "Fairy Controller");
			NPCNameFromID.Add(0x001EF116, "Surfing Controller");
			NPCNameFromID.Add(0x001EF11C, "Claira Clairvoyant");
			NPCNameFromID.Add(0x001EF126, "Gunk The Ogre");
			NPCNameFromID.Add(0x00231FA8, "Pig Controller");
			NPCNameFromID.Add(0x00231FC5, "Chicken Controller");
			NPCNameFromID.Add(0x00231FCE, "Cow Controller");
			NPCNameFromID.Add(0x0035B3FC, "Trike Controller");
			NPCNameFromID.Add(0x0043943B, "Unicorn Controller");
			NPCNameFromID.Add(0x00439442, "Unicorn Pony Controller");
			NPCNameFromID.Add(0x0043945C, "Lawnmower Controller");
			NPCNameFromID.Add(0x0043949F, "Dragon Controller");
			NPCNameFromID.Add(0x00671E46, "Brontosaurus Controller");
			NPCNameFromID.Add(0x00671E8B, "Horse Controller");
			NPCNameFromID.Add(0x00671E9E, "Pony Controller");
			NPCNameFromID.Add(0x00671EA1, "Sheep Controller");
			NPCNameFromID.Add(0x0077DB23, "Donkey Controller");
			NPCNameFromID.Add(0x007F88C6, "Quad Bike Controller");
			NPCNameFromID.Add(0x008646F2, "Pet Dragon Controller");
			NPCNameFromID.Add(0x1A3BB406, "Camel Controller");
			NPCNameFromID.Add(0x00498004, "Alien PT951");
			NPCNameFromID.Add(0x00498005, "Alien PT753");
			NPCNameFromID.Add(0x00498006, "Alien PT258");
			NPCNameFromID.Add(0x00498007, "Alien PT456");
			NPCNameFromID.Add(0x004A3D06, "Alien Billie");
			NPCNameFromID.Add(0x004A3D07, "Alien Catherine");
			NPCNameFromID.Add(0x004A3D08, "Alien Chris");
			NPCNameFromID.Add(0x004A3D09, "Alien David");
			NPCNameFromID.Add(0x004BBF00, "Alien Harper");
			NPCNameFromID.Add(0x004BBF02, "Alien Tavv");
			NPCNameFromID.Add(0x004BBF03, "Alien Valerie");
			NPCNameFromID.Add(0x004BBF04, "Alien Quinn");
			NPCNameFromID.Add(0x004C1500, "Alien Eyzo");
			NPCNameFromID.Add(0x004C1501, "Alien Giith");
			NPCNameFromID.Add(0x004C1502, "Alien Miih");
			NPCNameFromID.Add(0x004C1503, "Alien Zhesh");
			NPCNameFromID.Add(0x0052EC00, "Alien Albus713");
			NPCNameFromID.Add(0x0052EC01, "Alien Harry824");
			NPCNameFromID.Add(0x0052EC02, "Alien James515");
			NPCNameFromID.Add(0x0052EC03, "Alien Lily001");
			NPCNameFromID.Add(0x0059E000, "Alien Tarek");
			NPCNameFromID.Add(0x0059E001, "Alien Zienyk");
			NPCNameFromID.Add(0x0059E002, "Alien Xena");
			NPCNameFromID.Add(0x0059E003, "Alien Brequ");
			NPCNameFromID.Add(0x00602904, "Alien Musta202");
			NPCNameFromID.Add(0x00602905, "Alien Pun202");
			NPCNameFromID.Add(0x00602906, "Alien Rusk202");
			NPCNameFromID.Add(0x00602907, "Alien Kelt202");
			NPCNameFromID.Add(0x007CD501, "Alien Robyn");
			NPCNameFromID.Add(0x007CD502, "Alien Lesley");
			NPCNameFromID.Add(0x007CD503, "Alien Nicki");
			NPCNameFromID.Add(0x007CD504, "Alien Sam");
			NPCNameFromID.Add(0x00830B04, "Alien Vienna");
			NPCNameFromID.Add(0x00830B05, "Alien Frood");
			NPCNameFromID.Add(0x00830B06, "Alien Checkers");
			NPCNameFromID.Add(0x00830B07, "Alien Bronagh");
			NPCNameFromID.Add(0x00837F04, "Alien Durante");
			NPCNameFromID.Add(0x00837F05, "Alien Gourdo");
			NPCNameFromID.Add(0x00837F06, "Alien Lisa");
			NPCNameFromID.Add(0x00837F07, "Alien RanaDonna");
			NPCNameFromID.Add(0x008AB400, "Alien Calpurina");
			NPCNameFromID.Add(0x008AB401, "Alien Henry");
			NPCNameFromID.Add(0x008AB402, "Alien Malcolm");
			NPCNameFromID.Add(0x008AB403, "Alien Rainelle");
			NPCNameFromID.Add(0x0063730E, "Pandora Melanie");
			NPCNameFromID.Add(0x00637312, "Pandora Synthia");
			NPCNameFromID.Add(0x00637313, "Pandora Chad");
			NPCNameFromID.Add(0x00637320, "Pandora Cindy");
			NPCNameFromID.Add(0x00637321, "Pandora Trisha");
			NPCNameFromID.Add(0x00637322, "Pandora Craig");
			NPCNameFromID.Add(0x00637323, "Pandora Jason");
			NPCNameFromID.Add(0x00637324, "Pandora Matt");
			NPCNameFromID.Add(0x00637325, "Pandora Rico");
			NPCNameFromID.Add(0x006A325E, "BorgCube Controller");
			NPCNameFromID.Add(0xEC182D02, "DMA Victoria");
			NPCNameFromID.Add(0xEC182D03, "DMA Claudia");
			NPCNameFromID.Add(0xEC182D04, "DMA Anette");
			NPCNameFromID.Add(0xEC182D05, "DMA Jessica");
			NPCNameFromID.Add(0xEC182D06, "DMA Lorraine");
			NPCNameFromID.Add(0xEC182D11, "DMA Monica");
			NPCNameFromID.Add(0xEC182D12, "DMA Cassandra");
			NPCNameFromID.Add(0xEC182D14, "DMA Jon");
			NPCNameFromID.Add(0xEC182D16, "DMA Martin");
			NPCNameFromID.Add(0xEC182D1A, "DMA Jennifer");
			NPCNameFromID.Add(0xEC182D1B, "DMA Nicole");
			NPCNameFromID.Add(0xEC182D25, "DMA Blanca");
			NPCNameFromID.Add(0xEC182D28, "DMA Maureen");
			NPCNameFromID.Add(0xEC182D2A, "DMA Heidi");
			NPCNameFromID.Add(0xEC182D2B, "DMA Marlene");
			NPCNameFromID.Add(0xEC182D2C, "DMA Donna");
			NPCNameFromID.Add(0xEC182D2D, "DMA Linda");
			NPCNameFromID.Add(0xEC182D2E, "DMA Jeannie");
			NPCNameFromID.Add(0xEC182D2F, "DMA Marianne");
			NPCNameFromID.Add(0xEC182D35, "DMA Igor");
			NPCNameFromID.Add(0xEC182D38, "DMA Richard");
			NPCNameFromID.Add(0xEC182D39, "DMA Henry");
			NPCNameFromID.Add(0xEC182D3B, "DMA Phillip");
			NPCNameFromID.Add(0xEC182D3C, "DMA Sonya");
			NPCNameFromID.Add(0xEC182D3E, "DMA Sara");
			NPCNameFromID.Add(0xEC182D3F, "DMA Wendy");
			NPCNameFromID.Add(0xEC182D45, "DMA Winston");
			NPCNameFromID.Add(0xEC182D46, "DMA Gary");
			NPCNameFromID.Add(0xEC182D71, "DMA Felicia");
			NPCNameFromID.Add(0xEC182D72, "DMA Hilary");
			NPCNameFromID.Add(0xEC182D73, "DMA Travis");
			NPCNameFromID.Add(0xEC182D74, "DMA Walter");
			NPCNameFromID.Add(0xEC182D75, "DMA Kaitlyn");
			NPCNameFromID.Add(0xEC182DA1, "DMA Azumi");
			NPCNameFromID.Add(0xEC182DA2, "DMA Hsue");
			NPCNameFromID.Add(0xEC182DA3, "DMA Chan");
			NPCNameFromID.Add(0xEC182DA4, "DMA Lee");
			NPCNameFromID.Add(0xEC182DA5, "DMA Carolyn");
			NPCNameFromID.Add(0xEC182DA6, "DMA Tanya");
			NPCNameFromID.Add(0xEC182DA7, "DMA Dolores");
			NPCNameFromID.Add(0xEC182DA8, "DMA Sophie");
			NPCNameFromID.Add(0xEC182DB6, "DMA Heather");
			NPCNameFromID.Add(0xEC182DBF, "DMA Bettie");
			NPCNameFromID.Add(0xEC182DC1, "DMA Iris");
			NPCNameFromID.Add(0xEC182DC2, "DMA Kayla");
			NPCNameFromID.Add(0xEC182DC3, "DMA Jack");
			NPCNameFromID.Add(0xEC182DC4, "DMA Mark");
			NPCNameFromID.Add(0xEC182DF1, "DMA Ginger");
			NPCNameFromID.Add(0xEC182DF2, "DMA John");
			NPCNameFromID.Add(0xEC182DF3, "DMA Olivia");
			NPCNameFromID.Add(0xEC182DF4, "DMA Randy");
			NPCNameFromID.Add(0x0050D900, "Custom Sim0");
			NPCNameFromID.Add(0x0050D901, "Custom Sim1");
			NPCNameFromID.Add(0x0050D902, "Custom Sim2");
			NPCNameFromID.Add(0x0050D903, "Custom Sim3");
		}

		public static Dictionary<short, string> TitlePostName =
			new Dictionary<short, string>();

		/// <summary>
		/// Convert the id to a name for Post Title Names
		/// </summary>
		public static string GetTitleName(short id)
		{
			if (TitlePostName.Count < 2)
			{
				InitializeTitlePostName();
			}

			if (TitlePostName.ContainsKey(id))
			{
				return TitlePostName[id];
			}

			return "";
		}

		/// <summary>
		/// Convert the name to an id for Post Title Names, for easy combobox use the string is object
		/// </summary>
		public static short GetTitleId(object ob)
		{
			string val = Convert.ToString(ob);
			if (TitlePostName.Count < 2)
			{
				InitializeTitlePostName();
			}

			if (TitlePostName.ContainsValue(val))
			{
				foreach (KeyValuePair<short, string> kvp in TitlePostName)
				{
					if (kvp.Value == val)
					{
						return kvp.Key;
					}
				}
			}

			return 0;
		}

		private static void InitializeTitlePostName()
		{
			TitlePostName.Clear();
			TitlePostName.Add(0, "");
			TitlePostName.Add(1, " (Atrocious Witch)");
			TitlePostName.Add(2, " (Atrocious Warlock)");
			TitlePostName.Add(3, " (Evil Witch)");
			TitlePostName.Add(4, " (Evil Warlock)");
			TitlePostName.Add(5, " (Mean Witch)");
			TitlePostName.Add(6, " (Mean Warlock)");
			TitlePostName.Add(7, " (Witch)");
			TitlePostName.Add(8, " (Warlock)");
			TitlePostName.Add(9, " (Nice Witch)");
			TitlePostName.Add(10, " (Nice Warlock)");
			TitlePostName.Add(11, " (Good Witch)");
			TitlePostName.Add(12, " (Good Warlock)");
			TitlePostName.Add(13, " (Infallible Witch)");
			TitlePostName.Add(14, " (Infallible Warlock)");
		}

		public static Dictionary<uint, string> KnownFences =
			new Dictionary<uint, string>();

		/// <summary>
		/// Convert the GUID to a name for known Fences
		/// </summary>
		public static string GetKnownFence(uint id)
		{
			if (KnownFences.Count < 2)
			{
				InitializeKnownFences();
			}

			if (KnownFences.ContainsKey(id))
			{
				return KnownFences[id];
			}

			return "not found";
		}

		/// <summary>
		/// Convert the name to a GUID for Known Fences, for easy combobox use the string is object
		/// </summary>
		public static uint GetFenceId(object ob)
		{
			string val = Convert.ToString(ob);
			if (KnownFences.Count < 2)
			{
				InitializeKnownFences();
			}

			if (KnownFences.ContainsValue(val))
			{
				foreach (KeyValuePair<uint, string> kvp in KnownFences)
				{
					if (kvp.Value == val)
					{
						return kvp.Key;
					}
				}
			}

			return 0;
		}

		private static void InitializeKnownFences()
		{
			KnownFences.Clear();
			KnownFences.Add(0x8D0B3B3A, "Flowerbed Malabar Black Bamboo Fence");
			KnownFences.Add(0xCD0F1DED, "Flowerbed Malabar Green Bamboo Fence");
			KnownFences.Add(0x8D0B3C31, "Flowerbed Malabar Natural Bamboo Fence");
			KnownFences.Add(0x4CDF8C41, "Tornado Solid Steel Fence");
			KnownFences.Add(0xCCDF918F, "Cut Stump Flowerbed Fence");
			KnownFences.Add(0xAD0DABD2, "PINEGULTCHER Wood Rail in Light Pine");
			KnownFences.Add(0x8D0B34FD, "Longhorn Balustrade in Light Wood");
			if (
				PathProvider.Global.GetExpansion(Expansions.BaseGame).Exists
				|| PathProvider.Global.GetExpansion(Expansions.PetStories).Exists
				|| PathProvider.Global.GetExpansion(Expansions.LifeStories).Exists
			)
			{
				KnownFences.Add(0x6D0B2B38, "Nouvelle Fence in Liberty Green");
				KnownFences.Add(0x6D0B3239, "Nouvelle Fence in The New Black");
				KnownFences.Add(0xAD0B35F2, "Longhorn Balustrade in White");
				KnownFences.Add(0x8CDF8BF6, "Stone Cul-De-Sac Brick Fence");
				KnownFences.Add(0x6D0DA9F9, "PINEGULTCHER Wood Rail in Cedar");
				KnownFences.Add(0x8D0DB64C, "InvisiBarrier Fencing in Ether");
				KnownFences.Add(0x0D0DB771, "InvisiBarrier Fencing in Hallucination");
				KnownFences.Add(0x0D0DB7E1, "InvisiBarrier Fencing in Steam");
				KnownFences.Add(0xCD0DC03C, "Royal Courtyard Fencing");
				KnownFences.Add(0x0D0DBF66, "Windowed Royal Courtyard Fencing");
				KnownFences.Add(0xAD0F207E, "White Royal Courtyard Fencing");
				KnownFences.Add(0xED0EA468, "Short Mortar Brick Wall");
				KnownFences.Add(0x0D0F2115, "Short Mortar Reclaimed Brick Wall");
				KnownFences.Add(0x6D0EA622, "Short Mortar White Brick Wall");
				KnownFences.Add(0x6D0EA75D, "Low Stakes Fencing in Pastoral Green");
				KnownFences.Add(0x2CDF8E7D, "Low Stakes Fencing in Redwood");
				KnownFences.Add(0x2D0EA907, "Classic Arched Picket Fence");
				KnownFences.Add(0xECE5E3C5, "Genuine Railway Tie Fencing");
				KnownFences.Add(0x0D0EABDE, "Ancient Guardian Brick Wall");
				KnownFences.Add(0x6D0EAA68, "Ancient Guardian Rock Wall");
				KnownFences.Add(0x0D0EACC7, "Zig-Jag Flowerbed Fence in Red Brick");
				KnownFences.Add(
					0xED0EAE6A,
					"Zig-Jag Flowerbed Fence with Recycled Bricks"
				);
				KnownFences.Add(0x8D0EB171, "Zig-Jag Flowerbed Fence in White Brick");
				KnownFences.Add(0xAD05BEE9, "FauxStone Wall by Valy");
				KnownFences.Add(0x0CDF8C99, "WroughtWright, Inc. Iron Age Fence");
			}
			if (
				PathProvider.Global.GetExpansion(Expansions.University).Exists
				|| PathProvider.Global.GetExpansion(Expansions.PetStories).Exists
				|| PathProvider.Global.GetExpansion(Expansions.LifeStories).Exists
			)
			{
				KnownFences.Add(0xCEC0E4C4, "Running the Rapids Rock Fence");
				// KnownFences.Add(0x8CDF8BF6, "Stone Cul-De-Sac Brick Fence"); exists in base game, since that must exist for Uni to exist remove this
				KnownFences.Add(0x2ECB56F5, "Academia Red Brick Wall with Stone Rail");
				KnownFences.Add(0x2EBB5127, "Mini-Pediment in Discreet Concrete");
				KnownFences.Add(0xAEBB4FCD, "Mini-Pediment in Red Brick");
				KnownFences.Add(0x8EBB5130, "Mini-Pediment in Stucco");
				KnownFences.Add(
					0x4EBB4DA1,
					"Mini-Pediment in Verdant Green Stone with Brick Accents"
				);
				KnownFences.Add(
					0x4EBB5037,
					"Patrician Balustrade in Discreet Concrete"
				);
				KnownFences.Add(0xCEBB535D, "Patrician Balustrade in Neutral White");
				KnownFences.Add(0x2EC0E553, "Patrician Stone Wall in Concrete");
				KnownFences.Add(0xCEC0E2A8, "Romanesque Wall in Red Stone");
			}
			if (
				PathProvider.Global.GetExpansion(Expansions.Nightlife).Exists
				|| PathProvider.Global.GetExpansion(Expansions.PetStories).Exists
				|| PathProvider.Global.GetExpansion(Expansions.LifeStories).Exists
			)
			{
				KnownFences.Add(0x6FB1CF18, "The Wave Half Wall-DarkWood");
				KnownFences.Add(0x2FB1CF58, "The Wave Half Wall-Stainless");
				KnownFences.Add(0xAF911CBC, "The Wave Half Wall-LightWood");
				KnownFences.Add(0x6FB1CF3B, "The Wave Half Wall-BlackWood");
				KnownFences.Add(0x6F61A564, "Arboreal Wooden Fence");
				KnownFences.Add(0x6FB1CEB6, "Brass n' Glass Half Wall in Florish");
				KnownFences.Add(0x0F911C64, "Brass n' Glass Half Wall in Harvest");
				KnownFences.Add(
					0x2FB1CEDC,
					"Brass n' Glass Half Wall in Sleek-DarkWood"
				);
				KnownFences.Add(
					0xCFD7E823,
					"Brass n' Glass Half Wall in Sleek-WhiteWood"
				);
				KnownFences.Add(0x0FB1CE11, "Nocturnal Rumors Half Wall in Blush");
				KnownFences.Add(0xEFB1CDF1, "Nocturnal Rumors Half Wall in Gossip");
				KnownFences.Add(0x8F911CA3, "Nocturnal Rumors Half Wall in Whisper");
				KnownFences.Add(0x0FB1CE33, "Nocturnal Rumors Half Wall in Wink");
				KnownFences.Add(0x8FB1CD3A, "Perfectly Plank Half Wall in Blue");
				KnownFences.Add(0x0FB1CCEE, "Perfectly Plank Half Wall in Green");
				KnownFences.Add(0x6F911BF2, "Perfectly Plank Half Wall in Pine");
				KnownFences.Add(0x2FB1CD68, "Perfectly Plank Half Wall in Pink");
				KnownFences.Add(0x4FB1CD8C, "Perfectly Plank Half Wall in Red");
				KnownFences.Add(
					0xEFB1CDB3,
					"Perfectly Plank Half Wall in Stainless Steel"
				);
				KnownFences.Add(0x6F851F53, "Quaint Half Wall in Brown");
				KnownFences.Add(0xCF6BD156, "Quaint Half Wall in Cornflower");
				KnownFences.Add(0x8F6BD1DB, "Quaint Half Wall in Green");
				KnownFences.Add(0xCF6BD1FB, "Quaint Half Wall in Light Wood");
				KnownFences.Add(0x8F6BD243, "Quaint Half Wall in White");
				KnownFences.Add(0x8F83EA15, "Quaint Half Wall in Rose");
			}
			if (
				(
					PathProvider.Global.GetExpansion(Expansions.Nightlife).Exists
					|| PathProvider
						.Global.GetExpansion(Expansions.PetStories)
						.Exists
					|| PathProvider
						.Global.GetExpansion(Expansions.LifeStories)
						.Exists
					|| PathProvider
						.Global.GetExpansion(Expansions.Mansions)
						.Exists
				)
				&& Helper.WindowsRegistry.LoadOnlySimsStory != 28
			)
			{
				KnownFences.Add(0xCF61A57E, "Chic Fence");
			}

			if (PathProvider.Global.GetExpansion(Expansions.Nightlife).Exists)
			{
				KnownFences.Add(0x0F584F14, "Relvet Vope Fence");
				KnownFences.Add(0xCF61A594, "Wooden Fence");
			}
			if (
				PathProvider.Global.GetExpansion(Expansions.Business).Exists
				|| PathProvider.Global.GetExpansion(Expansions.PetStories).Exists
			)
			{
				KnownFences.Add(0x309DD1A8, "A Most Splendid Partition in Blue");
				KnownFences.Add(0x709DD1FB, "A Most Splendid Partition in Red");
				KnownFences.Add(0xB09DD226, "A Most Splendid Partition in White");
				KnownFences.Add(0xF09DD638, "Antiquity Fence by Swift Ltd.");
				KnownFences.Add(0x509DD0A5, "Balustrade Minimaal");
				KnownFences.Add(0x709DD0F2, "Balustrade Minimaal in Red");
				KnownFences.Add(0x909DD2C6, "Classical Ascension Railing in Blue");
				KnownFences.Add(0x709DD304, "Classical Ascension Railing in Red");
				KnownFences.Add(0xB09DD32A, "Classical Ascension Railing in White");
				KnownFences.Add(0x309DD49A, "Gelander Railing in Purple");
				KnownFences.Add(0xD09DD350, "Gelander Railing in Rose");
				KnownFences.Add(0x309DD474, "Gelander Railing in Yellow");
				KnownFences.Add(0xF09DD570, "Half Centurion in Blue");
				KnownFences.Add(0x709DD59C, "Half Centurion in Red");
				KnownFences.Add(0x709DD5C5, "Half Centurion in White");
				KnownFences.Add(0x509DD041, "Schifting Partition in Blue");
				KnownFences.Add(0xD09DD03A, "Schifting Partition in Red");
				KnownFences.Add(0x909DD079, "Schifting Partition in Yellow");
				KnownFences.Add(0xF09DD252, "The Iron Gardener Fence");
				KnownFences.Add(0xB09DD180, "Zaunfach Partition Fence in Purple");
				KnownFences.Add(0x109DD113, "Zaunfach Partition Fence in Rose");
				KnownFences.Add(0x309DD155, "Zaunfach Partition Fence in Yellow");
			}
			if (
				PathProvider.Global.GetExpansion(Expansions.Pets).Exists
				|| PathProvider.Global.GetExpansion(Expansions.PetStories).Exists
			)
			{
				KnownFences.Add(0xD1AF063A, "Railing Atomica in Black");
				KnownFences.Add(0x91AF070C, "Railing Atomica in Red");
				KnownFences.Add(0xB1AF074A, "Railing Atomica in Stainless Steel");
				KnownFences.Add(0x71AF07DC, "Space-O-Rama Divider by Spitz in Aqua");
				KnownFences.Add(0x71AF0812, "Space-O-Rama Divider by Spitz in Gold");
				KnownFences.Add(0xB1AF084B, "Space-O-Rama Divider by Spitz in Green");
				KnownFences.Add(0xB1AF0885, "Space-O-Rama Divider by Spitz in Rose");
				KnownFences.Add(
					0x518B4159,
					"The Great Divide by Divisive Divicrats in Black"
				);
				KnownFences.Add(
					0x318B42A4,
					"The Great Divide by Divisive Divicrats in Brass"
				);
				KnownFences.Add(
					0x718B4308,
					"The Great Divide by Divisive Divicrats in Dark Wood"
				);
				KnownFences.Add(
					0x3175D2B6,
					"The Great Divide by Divisive Divicrats in Light Wood"
				);
				KnownFences.Add(
					0x518B436E,
					"The Great Divide by Divisive Divicrats in Medium Wood"
				);
				KnownFences.Add(
					0x518B43B1,
					"The Great Divide by Divisive Divicrats in Silver"
				);
			}
			if (
				PathProvider.Global.GetExpansion(Expansions.Seasons).Exists
				|| PathProvider
					.Global.GetExpansion(Expansions.IslandStories)
					.Exists
			)
			{
				KnownFences.Add(0xF25CF2A4, "Failed Fence of Analogia");
				KnownFences.Add(0xF25CF2FB, "Schellacked Failed Fence of Analogia");
				KnownFences.Add(0xF25CE8FA, "Weathered Failed Fence of Analogia");
				KnownFences.Add(0xB25CF389, "Farmer Thompson's Stone Wall");
			}
			if (PathProvider.Global.GetExpansion(Expansions.Seasons).Exists)
			{
				KnownFences.Add(0x924E0E65, "Green's Greenhouse Wall in Green");
				KnownFences.Add(0x924E0F6B, "Green's Greenhouse Wall in White");
				KnownFences.Add(0x724E0F1B, "Green's Greenhouse Wall in Wood");
			}
			if (
				PathProvider.Global.GetExpansion(Expansions.Voyage).Exists
				|| PathProvider
					.Global.GetExpansion(Expansions.IslandStories)
					.Exists
			)
			{
				KnownFences.Add(
					0xF34D05CF,
					"Dark Bamboo Barricade By Tropical Touches"
				);
				KnownFences.Add(
					0x534D0580,
					"Light Bamboo Barricade By Tropical Touches"
				);
				KnownFences.Add(
					0xD34D053C,
					"Medium Bamboo Barricade By Tropical Touches"
				);
				KnownFences.Add(
					0xB34D0605,
					"Painted Bamboo Barricade By Tropical Touches"
				);
				KnownFences.Add(0x53742EF3, "Green Bamboo Shortie Fence");
			}
			if (PathProvider.Global.GetExpansion(Expansions.Fashion).Exists)
			{
				KnownFences.Add(0xD2F1C049, "Glimmie Black by Irokthis Stage Lamp Co.");
				KnownFences.Add(0xD2F0A4DB, "Glimmie White by Irokthis Stage Lamp Co.");
			}
			if (PathProvider.Global.GetExpansion(Expansions.Voyage).Exists)
			{
				KnownFences.Add(0xB330F5A9, "Fallen Fir Fence-Hickory");
				KnownFences.Add(0x5330F6C7, "Fallen Fir Fence-Rustic");
				KnownFences.Add(0xD354C607, "Please Fence Me In Fence");
			}
			if (
				PathProvider.Global.GetExpansion(Expansions.Extra).Exists
				&& Helper.ECCorNewSEfound
			)
			{
				KnownFences.Add(0x6B4BF4A5, "Stonework Wall (White)");
				KnownFences.Add(0x6899FF71, "Stonework Wall (Pink)");
				KnownFences.Add(0x2E0B65EB, "Stonework Wall (Red)");
				KnownFences.Add(0x1801DAD1, "Stonework Wall (Black)");
			}
			if (PathProvider.Global.GetExpansion(Expansions.Apartments).Exists)
			{
				KnownFences.Add(
					0x753F2D78,
					"Belladonna Beautiful Balustrade in Grey Gold"
				);
				KnownFences.Add(
					0xF53F2DB9,
					"Belladonna Beautiful Balustrade in Grey Patina"
				);
				KnownFences.Add(
					0xB53F2DF1,
					"Belladonna Beautiful Balustrade In Grey Silver"
				);
				KnownFences.Add(
					0xD53F2E64,
					"Belladonna Beautiful Balustrade in White Gold"
				);
				KnownFences.Add(
					0xB53F2EED,
					"Belladonna Beautiful Balustrade in White Patina"
				);
				KnownFences.Add(
					0xD53F2F3B,
					"Belladonna Beautiful Balustrade in White Silver"
				);
				KnownFences.Add(0x352E31BD, "Digit Fence in Black");
				KnownFences.Add(0x152E31E6, "Digit Fence in Grey");
				KnownFences.Add(0x952E320D, "Digit Fence in White");
				KnownFences.Add(0xB51D228B, "Elegant Rails in Bronze");
				KnownFences.Add(0x351D226F, "Elegant Rails in Marble");
				KnownFences.Add(0x351D2233, "Elegant Rails in Silver");
				KnownFences.Add(0x552C7FEA, "Linear Eloquence in Bronze");
				KnownFences.Add(0xB52C7F06, "Linear Eloquence in Copper");
				KnownFences.Add(0xF52C7F61, "Linear Eloquence in Gold");
				KnownFences.Add(0xF52C7FBE, "Linear Eloquence in Silver");
				KnownFences.Add(0xF5387F52, "One Complete Diner Enclosure in Black");
				KnownFences.Add(
					0xF5387FBB,
					"One Complete Diner Enclosure in Dark Wood"
				);
				KnownFences.Add(
					0x55388004,
					"One Complete Diner Enclosure in Medium Wood"
				);
				KnownFences.Add(
					0x15388022,
					"One Complete Diner Enclosure in True White"
				);
				KnownFences.Add(0xD51D22B7, "Rails of Style in Dark Wood");
				KnownFences.Add(0x951D22F5, "Rails of Style in Light Wood");
				KnownFences.Add(0x751D2316, "Rails of Style in Medium Wood");
				KnownFences.Add(0x551D208B, "Sleek and Secure in Black");
				KnownFences.Add(0xB51D2161, "Sleek and Secure in Grey");
				KnownFences.Add(0xD51D21AB, "Sleek and Secure in Silver");
				KnownFences.Add(0xD52C6B99, "Werknothom Half Wall in Black");
				KnownFences.Add(0x352C6C49, "Werknothom Half Wall in Grey");
				KnownFences.Add(0x752C6D51, "Werknothom Half Wall in White");
			}
			if (
				(PathProvider.Global.GetExpansion(Expansions.Mansions).Exists)
				&& Helper.WindowsRegistry.LoadOnlySimsStory == 0
			)
			{
				KnownFences.Add(0x95D75F26, "?Near the Floora? Half Wall-Fieldstone");
				KnownFences.Add(
					0xD5EFCFD7,
					"?Near the Floora? Half Wall-FieldstoneTop"
				);
				KnownFences.Add(
					0x75D75FCA,
					"?Near the Floora? Half Wall-FieldstoneFlowerBox"
				);
				KnownFences.Add(0x15D76044, "?Near the Floora? Half Wall-Yellowstone");
				KnownFences.Add(
					0x35EFD16D,
					"?Near the Floora? Half Wall-YellowstoneTop"
				);
				KnownFences.Add(
					0x15D760D6,
					"?Near the Floora? Half Wall-YellowstoneFlowerBox"
				);
				KnownFences.Add(0xF5D75D2C, "?Near the Floora? Half Wall-Ashlar");
				KnownFences.Add(0x55EFCD6F, "?Near the Floora? Half Wall-AshlarTop");
				KnownFences.Add(
					0xD5D75E5E,
					"?Near the Floora? Half Wall-AshlarFlowerBox"
				);
				KnownFences.Add(0xD5DD7B3A, "A Fence to Keep in Mind-Iron");
				KnownFences.Add(0xD5DD7AD8, "A Fence to Keep in Mind-Gold");
				KnownFences.Add(0x75DD7A4D, "A Fence to Keep in Mind-Butter");
				KnownFences.Add(0x75C1A869, "Antique Colonial Column Fencing-Black");
				KnownFences.Add(0x35C1AE15, "Antique Colonial Column Fencing-Blue");
				KnownFences.Add(0xF5C1AF21, "Antique Colonial Column Fencing-Orange");
				KnownFences.Add(0x55C1AEDB, "Antique Colonial Column Fencing-Green");
				KnownFences.Add(0x95C1B00C, "Antique Colonial Column Fencing-White");
				KnownFences.Add(0x15C1AF5D, "Antique Colonial Column Fencing-Red");
				KnownFences.Add(0xD5CAC1B1, "Border of Helier");
				KnownFences.Add(0xD5D6BCBA, "Border of Helier-Red");
				KnownFences.Add(0x95D6BD4B, "Border of Helier-Yellow");
				KnownFences.Add(
					0x55CAC9AD,
					"Crested Development by Morocco Modern Living"
				);
				KnownFences.Add(
					0x75D6BF82,
					"Crested Development by Morocco Modern Living-Salmon"
				);
				KnownFences.Add(
					0x75D6BF16,
					"Crested Development by Morocco Modern Living-Grey"
				);
				KnownFences.Add(
					0xF5CDA843,
					"Epee Fencing by Elevation Innovations-Blue"
				);
				KnownFences.Add(
					0x75CDA960,
					"Epee Fencing by Elevation Innovations-Green"
				);
				KnownFences.Add(
					0x95CDAAAF,
					"Epee Fencing by Elevation Innovations-Red"
				);
				KnownFences.Add(
					0x95CDAC81,
					"Epee Fencing by Elevation Innovations-Yellow"
				);
				KnownFences.Add(0x35D1613E, "Low Stakes Fencing in Blue");
				KnownFences.Add(0x15D163B2, "Low Stakes Fencing in Light Wood");
				KnownFences.Add(0x15CAC87A, "Metal Cresting by Made-in Iron");
				KnownFences.Add(
					0xB5DDB8B3,
					"Previously Inconceivable Floral Fence-LightWood"
				);
				KnownFences.Add(
					0xF5CD9AB4,
					"Previously Inconceivable Floral Fence-Blue"
				);
				KnownFences.Add(
					0x75CD995A,
					"Previously Inconceivable Floral Fence-Green"
				);
				KnownFences.Add(
					0xD5CD9A85,
					"Previously Inconceivable Floral Fence-Red"
				);
				KnownFences.Add(
					0x15DDB972,
					"Previously Inconceivable Floral Fence-White"
				);
				KnownFences.Add(
					0xF5C1B232,
					"Vector Column Fencing by Dot Products Inc.-White"
				);
				KnownFences.Add(
					0x15C1B1F6,
					"Vector Column Fencing by Dot Products Inc.-Med"
				);
				KnownFences.Add(
					0xF5C1B19A,
					"Vector Column Fencing by Dot Products Inc.-Light"
				);
				KnownFences.Add(
					0xB5C1B0D8,
					"Vector Column Fencing by Dot Products Inc.-Dark"
				);
			}
			if (PathProvider.Global.GetExpansion(Expansions.IslandStories).Exists)
			{
				KnownFences.Add(0x1354A999, "Boarskin Fence");
				KnownFences.Add(0x93BE3964, "Low-Lying Garden Edging Rocks");
				KnownFences.Add(0xD354BA2D, "The Super Sturdy Perimeter Fence");
			}
		}

		public static Dictionary<short, string> LanguageName =
			new Dictionary<short, string>();

		/// <summary>
		/// Convert the Windows registry id to a name for Sims2 Language Names
		/// </summary>
		public static string GetLanguageName(short id)
		{
			if (LanguageName.Count < 2)
			{
				InitializeLanguageName();
			}

			if (LanguageName.ContainsKey(id))
			{
				return LanguageName[id];
			}

			return "Invalid Language Id";
		}

		/// <summary>
		/// Convert the name to an id for Sims2 Language Names, for easy combobox use the string is object
		/// </summary>
		public static short GetLanguageId(object ob)
		{
			string val = Convert.ToString(ob);
			if (LanguageName.Count < 2)
			{
				InitializeLanguageName();
			}

			if (LanguageName.ContainsValue(val))
			{
				foreach (KeyValuePair<short, string> kvp in LanguageName)
				{
					if (kvp.Value == val)
					{
						return kvp.Key;
					}
				}
			}

			return 0;
		}

		private static void InitializeLanguageName()
		{
			LanguageName.Clear();
			LanguageName.Add(0, "Invalid Language Id");
			LanguageName.Add(1, "US English");
			LanguageName.Add(2, "French");
			LanguageName.Add(3, "German");
			LanguageName.Add(4, "Italian");
			LanguageName.Add(5, "Spanish");
			LanguageName.Add(6, "Swedish");
			LanguageName.Add(7, "Finnish");
			LanguageName.Add(8, "Dutch");
			LanguageName.Add(9, "Danish");
			LanguageName.Add(10, "Brazilian Portuguese");
			LanguageName.Add(11, "Czech");
			LanguageName.Add(14, "Japanese");
			LanguageName.Add(15, "Korean");
			LanguageName.Add(16, "Russian");
			LanguageName.Add(17, "Simplified Chinese");
			LanguageName.Add(18, "Traditional Chinese");
			LanguageName.Add(19, "English");
			LanguageName.Add(20, "Polish");
			LanguageName.Add(21, "Thai");
			LanguageName.Add(22, "Norwegian");
			LanguageName.Add(23, "Portuguese");
			LanguageName.Add(24, "Hungarian");
		}

		public static Dictionary<uint, string> NPCFamilyFromInstance =
			new Dictionary<uint, string>();

		/// <summary>
		/// These known families may not have a FAMI entry in the neighbourhood
		/// but they are recognized by the game.
		/// </summary>
		public static string NPCFamily(uint id)
		{
			if (NPCFamilyFromInstance.Count < 2)
			{
				InitializeNPCFamilyFromInstance();
			}

			if (NPCFamilyFromInstance.ContainsKey(id))
			{
				return NPCFamilyFromInstance[id];
			}

			if (id == 0)
			{
				return "No Family";
			}

			if (id < 32512)
			{
				return "Playable Family";
			}

			return "Unknown NPC Family";
		}

		private static void InitializeNPCFamilyFromInstance()
		{
			NPCFamilyFromInstance.Clear();
			NPCFamilyFromInstance.Add(0x7f65, "West World Locals");
			NPCFamilyFromInstance.Add(0x7f66, "Natives (castaway)");
			NPCFamilyFromInstance.Add(0x7f67, "Tau Ceti Locals");
			NPCFamilyFromInstance.Add(0x7f68, "Alpine Locals");
			NPCFamilyFromInstance.Add(0x7f69, "Spare Sims Pool");
			NPCFamilyFromInstance.Add(0x7fdf, "Elite Social Group");
			NPCFamilyFromInstance.Add(0x7fe0, "High Social Group");
			NPCFamilyFromInstance.Add(0x7fe1, "Medium Social Group");
			NPCFamilyFromInstance.Add(0x7fe2, "Low Social Group");
			NPCFamilyFromInstance.Add(0x7fe3, "Bogan Social Group");
			NPCFamilyFromInstance.Add(0x7fe4, "Iconic Hobby Sims");
			NPCFamilyFromInstance.Add(0x7fe5, "Holiday Tourists");
			NPCFamilyFromInstance.Add(0x7fe6, "Holiday Tourists");
			NPCFamilyFromInstance.Add(0x7fe7, "Holiday Tourists");
			NPCFamilyFromInstance.Add(0x7fe8, "Holiday Tourists");
			NPCFamilyFromInstance.Add(0x7fe9, "Holiday Tourists");
			NPCFamilyFromInstance.Add(0x7fea, "Holiday Tourists");
			NPCFamilyFromInstance.Add(0x7feb, "Holiday Tourists");
			NPCFamilyFromInstance.Add(0x7fec, "Holiday Tourists");
			NPCFamilyFromInstance.Add(0x7fed, "Holiday Tourists");
			NPCFamilyFromInstance.Add(0x7fee, "Holiday Tourists");
			NPCFamilyFromInstance.Add(0x7fef, "Holiday Tourists");
			NPCFamilyFromInstance.Add(0x7ff0, "Holiday Tourists");
			NPCFamilyFromInstance.Add(0x7FF1, "Tropical Locals");
			NPCFamilyFromInstance.Add(0x7FF2, "Mountain Locals");
			NPCFamilyFromInstance.Add(0x7FF3, "Asian Locals");
			NPCFamilyFromInstance.Add(0x7FF4, "Tourists");
			NPCFamilyFromInstance.Add(0x7FF5, "Unused - (Castaway)");
			NPCFamilyFromInstance.Add(0x7FF6, "Garden Club");
			NPCFamilyFromInstance.Add(0x7FF7, "Display Pets - In Use");
			NPCFamilyFromInstance.Add(0x7FF8, "Display Pets - Available");
			NPCFamilyFromInstance.Add(0x7FF9, "Orphan Pets");
			NPCFamilyFromInstance.Add(0x7FFA, "Strays");
			NPCFamilyFromInstance.Add(0x7FFB, "Baby Club");
			NPCFamilyFromInstance.Add(0x7FFC, "Downtownies");
			NPCFamilyFromInstance.Add(0x7FFD, "Orphans");
			NPCFamilyFromInstance.Add(0x7FFE, "Townies");
			NPCFamilyFromInstance.Add(0x7FFF, "Service NPCs");
		}

		public static Dictionary<string, uint> GUIDsToBody =
			new Dictionary<string, uint>();

		/// <summary>
		/// Convert the GUID to a female Bodyshape Id for Skin GUIDs
		/// </summary>
		public static uint GetBodyShapeid(string id)
		{
			if (GUIDsToBody.Count < 2)
			{
				InitializeGUIDsToBody();
			}

			if (GUIDsToBody.ContainsKey(id))
			{
				return GUIDsToBody[id];
			}

			return 0;
		}

		private static void InitializeGUIDsToBody()
		{
			GUIDsToBody.Clear();
			GUIDsToBody.Add("02eb51a9-4ec2-4d42-99ce-bdf46f156346", 0x13);
			GUIDsToBody.Add("5d19599a-f182-4499-9d42-70f982230ae3", 0x13);
			GUIDsToBody.Add("c557f36f-3855-45c3-b96a-2f5ec36b87c1", 0x13);
			GUIDsToBody.Add("be4b2fd6-fa64-4a9d-8cc5-a3db3458a228", 0x13);
			GUIDsToBody.Add("cba75b47-1a8f-4793-b7c9-5fbe5817a5ef", 0x13);
			GUIDsToBody.Add("8ea8ec72-422c-4699-bcd8-36993394afe8", 0x13);
			GUIDsToBody.Add("b729ef0f-e2ec-487e-9c29-19a16f76782d", 0x13);
			GUIDsToBody.Add("5755cace-a46c-4fae-8755-f84350d605af", 0x13);
			GUIDsToBody.Add("8906b2f8-6126-48b3-ad03-37cf52231547", 0x13);
			GUIDsToBody.Add("97d901a7-15c9-4e4b-b5d2-321cfb169c19", 0x13);
			GUIDsToBody.Add("a0e0b7d3-9e9f-49e0-91ba-02e304d1a356", 0x13);
			GUIDsToBody.Add("6e9f04b2-4b4b-0082-6ef9-5fbfffee077a", 0x14);
			GUIDsToBody.Add("7c525828-03f5-4830-8bab-556d3fa994d0", 0x14);
			GUIDsToBody.Add("5cd3f493-7bfb-4427-8df0-c90e12b018b3", 0x14);
			GUIDsToBody.Add("8cb73ae7-eb39-473e-a151-4c78ab3280f6", 0x14);
			GUIDsToBody.Add("5ad6c3a1-ed61-4fe9-bbb5-59493c6d7ab1", 0x14);
			GUIDsToBody.Add("08659265-e47e-4de5-b746-bca8c7054c6e", 0x14);
			GUIDsToBody.Add("1f4e686a-489f-492d-bb5f-1174ed022675", 0x14);
			GUIDsToBody.Add("8f356067-f6c0-461e-be75-415b328592c9", 0x14);
			GUIDsToBody.Add("dd2d5ca6-5b04-4400-8f2d-fd626bab3800", 0x14);
			GUIDsToBody.Add("ee0b3c53-6b98-4b1b-a04c-5a14c9980dc3", 0x14);
			GUIDsToBody.Add("8139d137-9da3-4a30-b7cd-67450ee665de", 0x14);
			GUIDsToBody.Add("5128756e-bcc4-4bfb-aad0-9e6c67c4b9a4", 0x14);
			GUIDsToBody.Add("6f0e7f01-8ce3-4adc-b407-45b7ee1aa6c4", 0x14);
			GUIDsToBody.Add("4f40d55e-7caa-4a91-89ee-35a61c79bd60", 0x14);
			GUIDsToBody.Add("c392ad0a-de8b-42e1-913a-9073b017ac33", 0x14);
			GUIDsToBody.Add("c0b88f6e-4cfb-454e-9663-d911c88fcc1e", 0x14);
			GUIDsToBody.Add("11d2d061-b37e-4e39-9b44-b0c86c4b5773", 0x14);
			GUIDsToBody.Add("a497af81-ce60-425c-9b62-c21c795f6cea", 0x14);
			GUIDsToBody.Add("052c4cec-149f-4ee7-999d-0f9c18ccaa67", 0x14);
			GUIDsToBody.Add("5301e48b-9153-49fc-a8b2-b0b9c9514b6b", 0x14);
			GUIDsToBody.Add("a3662356-9401-4d74-a60a-bef8ed34a231", 0x14);
			GUIDsToBody.Add("feaa1c71-923e-42b6-bb27-88beac66e006", 0x14);
			GUIDsToBody.Add("d294f3b8-cdb0-466c-bdb2-baa0b5f45d88", 0x35);
			GUIDsToBody.Add("609cc63f-2d4a-436e-97d4-2645742d829c", 0x35);
			GUIDsToBody.Add("34933675-9c5e-4f2b-b116-87df6788138d", 0x52);
			GUIDsToBody.Add("395b94a3-7d83-4fb0-a0f7-e716b29a6f6d", 0x52);
			GUIDsToBody.Add("a8e5bb1f-a5b6-4843-a859-b7a59dfbc9fd", 0x63);
			GUIDsToBody.Add("898084b8-c8a6-4d48-91d3-607974d479d3", 0x63);
			GUIDsToBody.Add("4d6bb50d-8ec9-4d75-a613-2bce832f5b12", 0x63);
			GUIDsToBody.Add("b1b01f46-2e78-4c6b-91ef-8e208a8b6c86", 0x63);
			GUIDsToBody.Add("cdcd4706-81ff-4d16-9e08-b33a66dfa05a", 0x63);
			GUIDsToBody.Add("c1204963-11a2-4182-99be-32efe0882d2e", 0x63);
			GUIDsToBody.Add("b420ce1e-2e08-4145-a0f1-918d7fe27915", 0x63);
			GUIDsToBody.Add("e4452f41-f8ef-4ca8-9380-7808b1f70673", 0x63);
			GUIDsToBody.Add("30916bdb-3b62-4d6b-b255-523f255844f2", 0x63);
			GUIDsToBody.Add("5f4ecb49-f541-46c8-9506-06c32d0dc4f2", 0x63);
			GUIDsToBody.Add("5f133bec-9e08-4411-8833-c83e4d18bd59", 0x67);
			GUIDsToBody.Add("e3799a2b-7bbe-4f27-a753-93bdb98f6ae6", 0x67);
			GUIDsToBody.Add("0a85b45e-776e-482e-acfd-50f09d7187aa", 0x67);
			GUIDsToBody.Add("8eb76fcb-1d77-4544-8119-57056e7c1423", 0x67);
			GUIDsToBody.Add("fdcd5908-bce2-4fb9-987a-3875c0a8e366", 0x67);
			GUIDsToBody.Add("c6f47eed-8410-4498-ab11-242e12c78cc2", 0x67);
			GUIDsToBody.Add("43748cd1-ae49-4d65-b0f9-c2614183ffcb", 0x67);
			GUIDsToBody.Add("9f484bec-29f0-4b5e-979e-47b37264b1d8", 0x67);
			GUIDsToBody.Add("25ce1372-4914-4333-9e49-7efc586287f1", 0x67);
			GUIDsToBody.Add("ddcb0488-99af-4bd8-b37d-2630f586f384", 0x67);
			GUIDsToBody.Add("6fc88813-c48c-4c79-a133-03ab3b6744b8", 0x6a);
			GUIDsToBody.Add("a0bda141-259f-4b4c-8907-857748abe584", 0x6a);
			GUIDsToBody.Add("86f1d466-1a27-42c7-89cf-b6203479ec76", 0x6a);
			GUIDsToBody.Add("4a73502f-b260-4b04-a494-c63a9c8a7cc7", 0x6a);
			GUIDsToBody.Add("262b2190-bdc9-4654-9afc-a034eceba4eb", 0x6a);
			GUIDsToBody.Add("affd55ef-98c2-41d0-996d-01f9b51842ba", 0x6a);
			GUIDsToBody.Add("539e9777-7630-4579-85f1-27ca29c147ba", 0x6a);
			GUIDsToBody.Add("30ec4c81-fe8d-4f11-9491-de7529dcd0a9", 0x6a);
			GUIDsToBody.Add("58a065f2-2f8b-4759-bcac-363f033e6e5a", 0x6a);
			GUIDsToBody.Add("0465507e-e486-4a41-8c0d-08621114a132", 0x6a);
			GUIDsToBody.Add("fe8db53f-bd16-46fb-b9a6-9363a6e8565e", 0x6a);
			GUIDsToBody.Add("bf702f2e-11ff-4534-be68-88b809511e35", 0x6a);
			GUIDsToBody.Add("5fd7617b-b7bf-4e26-8458-972055a8c0a4", 0x6a);
			GUIDsToBody.Add("c1aded63-0627-4357-9086-a2becb5e0086", 0x6a);
			GUIDsToBody.Add("c7e6825b-a291-477b-b787-4ab9b5260ea0", 0x6b);
			GUIDsToBody.Add("8f94e514-1a82-4e9a-b108-c3a35028e363", 0x6b);
			GUIDsToBody.Add("28a3da7e-14ec-410d-bc23-a96141521620", 0x6b);
			GUIDsToBody.Add("5547ed0d-97ab-4850-b921-d5eadf1bb73e", 0x6b);
			GUIDsToBody.Add("916a7be4-7dc5-499b-b29b-fe2afeab61c8", 0x6b);
			GUIDsToBody.Add("711f46c2-1dfe-4c79-8927-74f27a3654c1", 0x6b);
			GUIDsToBody.Add("ed811b63-880a-492c-9d3c-adddb6919bac", 0x6b);
			GUIDsToBody.Add("b4e099d2-93d5-469c-8800-dbf4f4d3a455", 0x6b);
			GUIDsToBody.Add("7df680fb-2c66-4994-9f64-9c939e51b54d", 0x6b);
			GUIDsToBody.Add("26dfc80b-b700-4d02-bd3a-66886bd86b2d", 0x6b);
			GUIDsToBody.Add("322facc9-c8e9-46bd-bcab-9ded3296a955", 0x6b);
			GUIDsToBody.Add("e501a432-cd83-40af-a29f-3c9e1c4ea088", 0x6b);
			GUIDsToBody.Add("a527848d-38c0-4748-aa01-909edde5ea98", 0x6b);
			GUIDsToBody.Add("d032e54e-5b87-4a7a-9b1a-aaab70690974", 0x6b);
			GUIDsToBody.Add("9bebd519-f0d6-4423-b129-5be12057deca", 0x6d);
			GUIDsToBody.Add("72b3bae5-e9e1-4c49-ab7b-ea4c46602f44", 0x6d);
			GUIDsToBody.Add("457b7b11-0af2-4b55-ab8f-52bc8d357bfc", 0x6d);
			GUIDsToBody.Add("5ad48600-e66e-44e3-8ff1-43aabe26125c", 0x6d);
			GUIDsToBody.Add("3e36bb7d-f0a5-4511-a2f0-ce6c37e3c02b", 0x6d);
			GUIDsToBody.Add("45d844b6-2c6a-4dd0-a782-c69b6ab1610b", 0x6d);
			GUIDsToBody.Add("f260372f-9034-4ae4-9814-27a6935a20b4", 0x6d);
			GUIDsToBody.Add("b28e8009-d5c2-467e-944f-c681fbc38ad6", 0x6d);
			GUIDsToBody.Add("5eca2bd4-37ee-4fc4-8db1-e7a0be426a45", 0x6d);
			GUIDsToBody.Add("9ce68a02-07cc-46a5-9737-e68166ab8225", 0x6d);
			GUIDsToBody.Add("b3f420dd-8205-4232-bc36-028e977293b6", 0x72);
			GUIDsToBody.Add("980d9d67-cac6-476e-9d2d-e0cb1866091b", 0x72);
			GUIDsToBody.Add("41b28e6c-da60-4e38-958b-6ef806527fbb", 0x72);
			GUIDsToBody.Add("bac50a55-3ffc-436b-9381-ced8da1e913f", 0x72);
			GUIDsToBody.Add("1aee3672-6aef-4ef1-bcc2-6e01de97a21e", 0x72);
			GUIDsToBody.Add("d9c9e387-8f93-46b8-945d-4e07f9e6c841", 0x72);
			GUIDsToBody.Add("e0a563c9-e362-4670-bd1d-e0d6e4004908", 0x72);
			GUIDsToBody.Add("d4c912a6-b9c6-4b17-b9eb-be0728144c56", 0x72);
			GUIDsToBody.Add("b01a01ec-d96f-479e-b88a-2ff720d97208", 0x72);
			GUIDsToBody.Add("913f6a18-870b-4186-9da7-43fc98a7a659", 0x72);
			GUIDsToBody.Add("17ee464a-1a28-4866-835d-b8ffc0441843", 0x76);
			GUIDsToBody.Add("06213ac6-accd-4c0f-9a7c-45e83904da0c", 0x76);
			GUIDsToBody.Add("ec494b00-4c52-4d2d-880f-11e6da6c0589", 0x76);
			GUIDsToBody.Add("0d97f052-14a4-4352-a6db-642af38f020a", 0x76);
			GUIDsToBody.Add("5cc2889b-4e5d-4fd6-b402-c06ac5627fcd", 0x76);
			GUIDsToBody.Add("f62bb788-297f-46f2-9e97-3d20bbafb86b", 0x76);
			GUIDsToBody.Add("d7d716c9-8d9d-4832-acb0-03a161400853", 0x76);
			GUIDsToBody.Add("066f81d3-f1a7-4788-84eb-08778c1d13dc", 0x76);
			GUIDsToBody.Add("b1940c85-12e7-4952-ab6a-b69d6120fabb", 0x76);
			GUIDsToBody.Add("c508caa6-9588-4521-ab24-d070dc49b182", 0x76);
			GUIDsToBody.Add("80155fc6-acb6-4a2f-ba2b-808d3be69ad1", 0x76);
			GUIDsToBody.Add("46ee5cf8-3fe3-4aec-8f0f-536d19759db5", 0x76);
			GUIDsToBody.Add("63963e10-8a7f-4eba-8209-978134437844", 0x76);
			GUIDsToBody.Add("5dee9cb9-aefd-42cd-a0b7-ef747dfbaae9", 0x76);
			GUIDsToBody.Add("93003b26-5bba-4406-b8ac-fdf4f885f225", 0x79);
			GUIDsToBody.Add("ed0a6460-dc47-4ecf-8901-46f26ebf0b6c", 0x79);
			GUIDsToBody.Add("e90bdb65-a32c-42cd-8ea2-2b51c40cd245", 0x79);
			GUIDsToBody.Add("64357f2c-1ba3-4feb-8acf-14e63b302b3d", 0x79);
			GUIDsToBody.Add("8ac2756c-7163-4423-883a-02bbdacb87b4", 0x79);
			GUIDsToBody.Add("8df50284-4a25-4000-b71f-26edbc9f7d9f", 0x79);
			GUIDsToBody.Add("9246e732-7e25-4c0f-9e02-202868421a53", 0x79);
			GUIDsToBody.Add("b4e219e7-c380-492d-83dd-83f4272d09d7", 0x79);
			GUIDsToBody.Add("78df44bb-0025-4c90-8804-adabf3608605", 0x79);
			GUIDsToBody.Add("e3fd5c35-d1e7-467d-af46-5db8a5c8c582", 0x79);
			GUIDsToBody.Add("c8f3723f-da73-4cb9-92bf-4744f832c61e", 0x7b);
			GUIDsToBody.Add("05984b16-6da4-4c95-8c09-be1e21176bcc", 0x7b);
			GUIDsToBody.Add("62688d25-6604-4a0d-a505-17d81d0ad571", 0x7b);
			GUIDsToBody.Add("b74b97ab-40b3-4ec7-b9e1-aeec5bb15b52", 0x7b);
			GUIDsToBody.Add("da421b93-1999-4903-bab1-5a5a09d3f489", 0x7b);
			GUIDsToBody.Add("1739bba4-d435-41cf-902a-60b59a5721be", 0x7b);
			GUIDsToBody.Add("4f5af57f-f515-4e05-ae04-9bf80c86d981", 0x7b);
			GUIDsToBody.Add("05002e04-d257-46a6-81b3-ec9f71718957", 0x7b);
			GUIDsToBody.Add("7578a151-b2d2-4ebd-a18d-58796abfade1", 0x7b);
			GUIDsToBody.Add("275ef199-0b36-49f6-a3c1-1ad9c3e2f003", 0x7b);
			GUIDsToBody.Add("d3f0d2ae-2920-4f39-af12-5d5f421a6b89", 0x7d);
			GUIDsToBody.Add("12ad1dfd-b6ff-4260-8001-0e13a14a459b", 0x7d);
			GUIDsToBody.Add("1022a60e-17b4-4015-8b10-27d8b0513eb1", 0x7d);
			GUIDsToBody.Add("c22446ae-568f-4a2d-ba46-aca43f0f4d32", 0x7d);
			GUIDsToBody.Add("b28793a5-28e0-4eb4-b9cb-ca9df5ccf98f", 0x7d);
			GUIDsToBody.Add("d3ae82e3-d96b-4532-9268-8fd28f7528de", 0x7d);
			GUIDsToBody.Add("150cd878-1875-4bba-893a-bfb169971e74", 0x7d);
			GUIDsToBody.Add("8569b553-ee13-46aa-912d-fe8acaed9b89", 0x7d);
			GUIDsToBody.Add("a45d799c-0df2-4fe2-b930-0aed31c16ba7", 0x7d);
			GUIDsToBody.Add("2153a926-92ac-479e-bc5b-4847737157ef", 0x7d);
			GUIDsToBody.Add("2e667eae-3d37-44f3-8000-708c7d63d2ae", 0x7d);
			GUIDsToBody.Add("19dab544-a584-4cb9-aaba-6d7b500ee090", 0x7d);
			GUIDsToBody.Add("b8ca2265-d643-408f-93db-d0f5ff778ee3", 0x7d);
			GUIDsToBody.Add("382684f1-444d-b44d-f41b-e28473e22e29", 0x7d);
			GUIDsToBody.Add("d0bca8a5-d971-4333-be0e-c607cc652860", 0x7d);
			GUIDsToBody.Add("1f64b267-8c34-4c00-9133-0915eb8bb49f", 0x7d);
			GUIDsToBody.Add("35bd9e06-853b-454e-9ea6-b1fb2e3f0643", 0x7d);
			GUIDsToBody.Add("34c1acb6-861e-4c46-8b2f-cca1badd1220", 0x7d);
			GUIDsToBody.Add("265d9c14-ed4e-4250-9ee1-ae0b884a8336", 0x7d);
			GUIDsToBody.Add("c0fc2bb9-683d-486b-8f4d-48a6220aa8d5", 0x7d);
			GUIDsToBody.Add("9b723d2a-8443-4b55-93ae-ea941024ce39", 0x7d);
			GUIDsToBody.Add("e89b3bc2-328d-4e73-9ecb-56e1f7ae4f25", 0x7d);
			GUIDsToBody.Add("93344874-8f60-4c0c-a71c-ad348bb32a7a", 0x7d);
			GUIDsToBody.Add("05e5bae8-020e-4a11-8440-971baa10115e", 0x7d);
			GUIDsToBody.Add("b54fabcc-0166-415b-819b-c1a7350e2a1b", 0x7d);
			GUIDsToBody.Add("5afb3c3f-afed-4686-8f9a-67cd7dfaf4bc", 0x7d);
			GUIDsToBody.Add("af596dc5-b0f0-4ce7-90b3-a386e9e30cb1", 0x7d);
			GUIDsToBody.Add("87a66a56-a0ff-400c-9b8b-07364952458b", 0x7d);
			GUIDsToBody.Add("94742ae5-6e87-4a6a-8afd-24fdd7f281b2", 0x7d);
			GUIDsToBody.Add("82af2f23-46d8-44f1-a507-b59141b728c8", 0x7d);
			GUIDsToBody.Add("b12a66ca-92d1-4227-bc3f-6b8438e3a74f", 0x7d);
			GUIDsToBody.Add("0be95ed7-d99c-4f14-aa30-051c38bd4366", 0x7d);
			GUIDsToBody.Add("109e089e-d9a4-4fca-a586-7665e40c79cd", 0x7d);
			GUIDsToBody.Add("5277f88a-8b56-48d7-adeb-413fb16c110e", 0x7d);
			GUIDsToBody.Add("43edf1c9-bfcc-4acb-bd3e-e0b062999ef7", 0x7d);
			GUIDsToBody.Add("7d6ecc34-9159-4c24-adeb-13607e92f92c", 0x7d);
			GUIDsToBody.Add("2d82a399-349d-4fb7-bd49-8c9d5849cd68", 0x86);
			GUIDsToBody.Add("930dec7b-c572-4b65-90f7-f66187a9c0d4", 0x86);
			GUIDsToBody.Add("ea166587-4399-473a-9338-913d267d66ef", 0x86);
			GUIDsToBody.Add("dff85c93-2ce0-4777-b6bd-faf723daf2a9", 0x86);
			GUIDsToBody.Add("dbc40136-387e-46cb-b880-a79a90ea8e1b", 0x86);
			GUIDsToBody.Add("1605ad83-b161-4464-a9f2-68df46cf814c", 0x86);
			GUIDsToBody.Add("ee4e9698-454d-4ace-952a-794ce9bdb9fa", 0x86);
			GUIDsToBody.Add("728d01b9-5d99-4ae4-827e-73f24847988f", 0x86);
			GUIDsToBody.Add("f8a95e25-c641-4c61-a253-cd3f9a2bff06", 0x86);
			GUIDsToBody.Add("352b18aa-2bdc-4a6b-9cbc-e0d67922328a", 0x86);
			GUIDsToBody.Add("4ed664f9-c27f-4e89-840f-b727dad01c73", 0x86);
			GUIDsToBody.Add("6553496a-e531-468a-9c64-ff8f59aa73ff", 0x86);
			GUIDsToBody.Add("635a8487-5a93-4ec8-a690-0e485448beb6", 0x86);
			GUIDsToBody.Add("2ee13ff0-49b1-467d-8a2c-0bbf5eaf4128", 0x86);
			GUIDsToBody.Add("bd824f18-d4f8-4bb8-8aaf-a60904427ba4", 0x86);
			GUIDsToBody.Add("e48273f3-ab9f-4838-b66d-f7c96f1f10b5", 0x86);
			GUIDsToBody.Add("9f4d3f73-7d6d-4b7e-949a-ca5b42d0b9ac", 0x86);
			GUIDsToBody.Add("38a43b6f-caa9-4188-af4a-dda1b9ec9ec6", 0x86);
			GUIDsToBody.Add("5a6fa8cd-b03e-41b9-99d2-1004784877cd", 0x88);
			GUIDsToBody.Add("8b0c9b55-065c-4d91-89bf-c76d28f2221d", 0x88);
			GUIDsToBody.Add("03f1a7c0-30f4-4dc0-9400-b38142921e7e", 0x88);
			GUIDsToBody.Add("25fded85-4122-497d-bd31-519089a3d9ff", 0x88);
			GUIDsToBody.Add("ddd67aa9-84cf-4324-89ff-51522d784f28", 0x88);
			GUIDsToBody.Add("0c502795-3c99-46ad-a84c-5c978c5bb51c", 0x88);
			GUIDsToBody.Add("0dd2af70-ba86-49ab-a4c6-90c5dd122448", 0x88);
			GUIDsToBody.Add("cb4e30cb-7320-459d-a2c8-d40603e4ec86", 0x88);
			GUIDsToBody.Add("ceb47781-9a2b-40d7-8400-ef4a4e8cf025", 0x88);
			GUIDsToBody.Add("83537a08-41d1-4397-965d-13adf8306bdf", 0x88);
			GUIDsToBody.Add("965e46ba-93a8-44f6-ab38-4330c36917b7", 0x88);
			GUIDsToBody.Add("e1fb2aa8-32ff-4cf3-964b-c43b36c56e28", 0x88);
			GUIDsToBody.Add("3ca5ba30-52b8-425f-be40-6e0e8c341771", 0x88);
			GUIDsToBody.Add("6f40af85-8aca-48ec-b481-56a75d1d4674", 0x88);
			GUIDsToBody.Add("8bba5b82-b2ec-4651-bfe2-686758f7367a", 0x88);
			GUIDsToBody.Add("63f8a1ee-417e-42d5-963d-60fe896cda83", 0x88);
			GUIDsToBody.Add("4ddea6e7-9ff5-4bf0-8af8-c46839ecf08a", 0x88);
			GUIDsToBody.Add("da9cf5d5-4386-4fee-8079-f957b2db03ea", 0x88);
			GUIDsToBody.Add("fd6d3ce0-e9c7-497d-891d-c1d306470295", 0x88);
			GUIDsToBody.Add("348227b6-83ad-4833-9805-9ad9cf9eb250", 0x8b);
			GUIDsToBody.Add("fb84d01c-c57a-4f75-a4a3-92021fceba05", 0x8b);
			GUIDsToBody.Add("3cfcd6cf-aa70-4a9e-a782-1555c918f228", 0x8b);
			GUIDsToBody.Add("24e44599-ad49-45c8-85b3-ecaa40fb600a", 0x8b);
			GUIDsToBody.Add("8f8ede4b-ae97-43e2-8ada-eeb4b21f7525", 0x8b);
			GUIDsToBody.Add("930fdfc8-dc70-42d6-a307-a15e4ba7cf36", 0x8b);
			GUIDsToBody.Add("981b60a8-2de0-46c3-af2f-7927b821e73e", 0x8b);
			GUIDsToBody.Add("40fdda76-52d8-41f5-83eb-140098e585f7", 0x8b);
			GUIDsToBody.Add("220acda4-54bc-4351-b150-68472e053ac5", 0x8b);
			GUIDsToBody.Add("de603e24-9c6a-4621-89e7-78dc1d1d6480", 0x8b);
			GUIDsToBody.Add("df600ecf-f5b8-4290-9a21-3e1ff0ed7852", 0x8b);
			GUIDsToBody.Add("919b3c4a-2a66-4669-8187-a766987620ed", 0x8b);
			GUIDsToBody.Add("2174ac1a-3986-4ace-8836-a0357cf4e39d", 0x8b);
			GUIDsToBody.Add("6f67d054-94d1-480e-bbb5-5118efb29131", 0x8b);
			GUIDsToBody.Add("bc6f8ea5-e429-4b9c-b1f1-7457d65c49d0", 0x8b);
			GUIDsToBody.Add("2f8194cb-9ede-49e8-acd8-998a25f5f915", 0x8b);
			GUIDsToBody.Add("1db56fae-d1d1-4f88-85ac-3beabfa8e594", 0x8b);
			GUIDsToBody.Add("be2bc426-6715-4b6f-b973-2fe4a424a43b", 0x8b);
			GUIDsToBody.Add("a4fa3ee5-67dc-4cbc-998e-b929934d4b45", 0x90);
			GUIDsToBody.Add("d831f811-016a-4fbf-ba4e-57f654754734", 0x90);
			GUIDsToBody.Add("8b626dcb-78f9-4549-86e7-3a5e16d1e613", 0x90);
			GUIDsToBody.Add("c58151f1-0770-4e63-b19b-32d250477ea2", 0x90);
			GUIDsToBody.Add("0f73b3ee-9bce-4e1f-bbe3-6e1cefdf0e1b", 0x90);
			GUIDsToBody.Add("9d7ed28f-b1d8-4ed5-816d-f17886795896", 0x90);
			GUIDsToBody.Add("1b1050ba-4e6a-4a18-a667-69ac06949a6d", 0x90);
			GUIDsToBody.Add("57d1e745-d7f5-4aa0-906f-acf44485d2de", 0x90);
			GUIDsToBody.Add("3e1f83b2-1712-49c7-a5e6-5f508ae00332", 0x90);
			GUIDsToBody.Add("ae6ef7bf-9aa3-4c55-993c-40f7a62f8fb8", 0x90);
			GUIDsToBody.Add("b498d53e-4aa6-4aa0-ab19-2525c1f7d9fe", 0x90);
			GUIDsToBody.Add("bb55a524-6cee-4dfd-9bc2-1657aaf8476c", 0x90);
			GUIDsToBody.Add("a3a94ca4-676a-4300-85f9-a4a444e17b21", 0x90);
			GUIDsToBody.Add("47ecd9a1-6061-457d-96e2-545d0dd9d7fb", 0x90);
			GUIDsToBody.Add("d3a2fd69-9306-4ae3-87b2-927772599f08", 0x90);
			GUIDsToBody.Add("1a8f3de5-2ef5-4d2d-b64d-ac64baec1d33", 0x90);
			GUIDsToBody.Add("82c4f0d3-a7c3-461a-b3f5-6f4037530d8e", 0x90);
			GUIDsToBody.Add("45be341b-3b1e-4177-831a-5bc4f0f8f7f2", 0x90);
			GUIDsToBody.Add("ea5bb3d1-269c-4771-8ef5-07e4d23dd03a", 0x92);
			GUIDsToBody.Add("27295f3a-e409-4d4c-991c-11f8f9ac293d", 0x92);
			GUIDsToBody.Add("3a7bd7c3-58a9-4441-8b33-a0edcfddc4ac", 0x92);
			GUIDsToBody.Add("a9470b52-0760-480c-846d-3d485b290fc1", 0x92);
			GUIDsToBody.Add("e00e7995-752b-47e1-96d5-b0bbf14c9cc2", 0x92);
			GUIDsToBody.Add("902ad323-ebf9-4c7e-87b3-c1ce40e0e4a4", 0x92);
			GUIDsToBody.Add("c232c8f6-3e3f-4762-b617-a489f546c256", 0x92);
			GUIDsToBody.Add("11a5d43c-7cdb-413b-aa52-c8b8f0f63735", 0x92);
			GUIDsToBody.Add("9eae4897-06b8-406c-8514-3c1bdcfa532b", 0x92);
			GUIDsToBody.Add("c8a29a88-a9b8-410b-82f4-b9da297e5050", 0x92);
			GUIDsToBody.Add("76311496-12f0-41ff-b8a8-d617a24b656b", 0x92);
			GUIDsToBody.Add("87ca73c3-b1a0-405b-acf9-70a4571a78ac", 0x92);
			GUIDsToBody.Add("6032826f-4efd-4b5f-bb40-166132340628", 0x92);
			GUIDsToBody.Add("cf5c1466-6a09-482f-9dd1-7b657638df7e", 0x92);
			GUIDsToBody.Add("77e0fe4a-2293-4e29-a056-11e14549b23f", 0x92);
			GUIDsToBody.Add("aa062909-cfd6-446d-95c7-b0d5bc90a038", 0x92);
			GUIDsToBody.Add("e78e22b9-64d9-4242-b8b6-bdb28d404c50", 0x92);
			GUIDsToBody.Add("7b660894-c4ba-4fd9-8220-0fedd542c1eb", 0x92);
			GUIDsToBody.Add("e37c3e11-87d4-4d49-866e-d3bb83db882c", 0x94);
			GUIDsToBody.Add("bde50099-39ae-4d4a-85ba-5df212f6c26c", 0x94);
			GUIDsToBody.Add("0f0a3f61-59d2-4807-a776-04fc3d849c7c", 0x94);
			GUIDsToBody.Add("dd433d34-6883-4418-8d23-d7c3f167c2e0", 0x94);
			GUIDsToBody.Add("0449ef74-4207-4db0-b0a0-410b7e267bbf", 0x94);
			GUIDsToBody.Add("03267c51-4498-4ff9-a021-fafd6d8feb34", 0x94);
			GUIDsToBody.Add("8d13e749-7373-43b2-b74d-2429fbce7d47", 0x94);
			GUIDsToBody.Add("7ff5fb66-8688-423b-9b57-710d879f4958", 0x94);
			GUIDsToBody.Add("08abf3b4-899d-44b8-b07a-896b107da375", 0x94);
			GUIDsToBody.Add("e6ceda28-a1f8-4ea5-994c-6c29ce33014a", 0x94);
			GUIDsToBody.Add("6a52c405-4660-4309-a12c-cb38c724bb55", 0x94);
			GUIDsToBody.Add("e40abf01-95fa-4d15-8984-f59804d5fe87", 0x94);
			GUIDsToBody.Add("af851986-0b56-4140-ab0e-de57dd03e7b8", 0x94);
			GUIDsToBody.Add("f86649eb-e765-4e96-9fd4-fc181759a8c7", 0x94);
			GUIDsToBody.Add("2e80e3e8-8b7e-4bc4-8921-ea0c5abaf510", 0x94);
			GUIDsToBody.Add("7148cf6f-84e3-4540-bb3e-1e4043dbab61", 0x94);
			GUIDsToBody.Add("f8a2b564-946d-4022-83de-3e29482733a6", 0x94);
			GUIDsToBody.Add("14181980-fd13-4a87-b754-9c7aab3c6789", 0x94);
			GUIDsToBody.Add("29dd7162-bcb8-4072-b0a4-3d0e9565d612", 0x94);
			GUIDsToBody.Add("00d6cf2f-bab1-4db8-9afa-57f4a2cb0779", 0x95);
			GUIDsToBody.Add("6ef02f8f-1437-47f5-a346-8d655fdaa486", 0x95);
			GUIDsToBody.Add("7eb2ee50-9eec-426d-8548-0f9643195c36", 0x95);
			GUIDsToBody.Add("f029679e-9904-42a1-bd02-cb8b9d468197", 0x95);
			GUIDsToBody.Add("f3363f51-02ef-40eb-a745-269479bba470", 0x95);
			GUIDsToBody.Add("0f33661d-7e52-4a5c-9a73-66871a4df299", 0x95);
			GUIDsToBody.Add("c148625c-bb1f-425c-8b52-1cc97fb6603c", 0x95);
			GUIDsToBody.Add("d21b4ca7-fe99-4871-aef8-05cb9b0cc609", 0x95);
			GUIDsToBody.Add("4ca75cd6-0de5-4a53-9e33-57567ab6cb8f", 0x95);
			GUIDsToBody.Add("93a90161-67f9-4d62-b3f0-03bfe98b279f", 0x95);
			GUIDsToBody.Add("65b3c32d-cc1a-461d-903f-18dba16ee45e", 0x95);
			GUIDsToBody.Add("4e35f017-24d8-4316-a50d-77fecc228c34", 0x95);
			GUIDsToBody.Add("d65e5a98-d01e-4f30-99c1-f770237783aa", 0x95);
			GUIDsToBody.Add("543b2c2a-723b-44c2-ba68-42740236b150", 0x95);
			GUIDsToBody.Add("5cea85ec-629b-4165-9545-a7c6814c8b8b", 0x95);
			GUIDsToBody.Add("0ba95ba8-3077-4026-bd1e-a396e6ed0b3a", 0x95);
			GUIDsToBody.Add("4af49349-17ff-4383-b619-abf734655964", 0x95);
			GUIDsToBody.Add("81a4f1e8-c9bf-4a71-be32-e224d2953658", 0x95);
			GUIDsToBody.Add("0e9c2351-bd87-4a65-8a02-5cbad8658f8d", 0x96);
			GUIDsToBody.Add("6e2f3788-35ea-4bf6-afb8-bebab5799a60", 0x96);
			GUIDsToBody.Add("0ef4ee62-f52f-4621-a6d9-dd9e6292f090", 0x96);
			GUIDsToBody.Add("e0f4308a-aed3-438e-a1d6-777fa9b74d1f", 0x96);
			GUIDsToBody.Add("ef153aae-ddea-437a-af63-11b276e7472c", 0x96);
			GUIDsToBody.Add("b98592f4-4d9b-4663-a3f3-aba784911237", 0x96);
			GUIDsToBody.Add("5c5bb7eb-a379-4c4a-ba17-d30fb2880325", 0x96);
			GUIDsToBody.Add("a46a5918-0e0b-4eba-b45c-99687c6ee528", 0x96);
			GUIDsToBody.Add("7f974502-4d26-4342-abad-fd0f3d5da69c", 0x96);
			GUIDsToBody.Add("64b5b70e-39eb-4a22-9726-6a4797ff50df", 0x96);
			GUIDsToBody.Add("aa3cb301-42f7-436a-abe1-931dc7e23336", 0x96);
			GUIDsToBody.Add("9bfc5dc2-2160-47d7-a87a-78348ca436a4", 0x96);
			GUIDsToBody.Add("b3cb21ab-f887-496a-8766-4d8f1529f28f", 0x96);
			GUIDsToBody.Add("b4744db6-50a5-483f-8006-4032e291d517", 0x96);
			GUIDsToBody.Add("d855e24f-c688-45eb-ac8a-2aac3c3c9d6e", 0x97);
			GUIDsToBody.Add("6fce4260-7e0e-42bc-a80c-f7a61c92df90", 0x97);
			GUIDsToBody.Add("fc0eb4d1-396f-4ed0-96a3-e99786cd5e84", 0x97);
			GUIDsToBody.Add("e4a1c955-a3e9-4ade-a365-1e7b814a7d76", 0x97);
			GUIDsToBody.Add("8afcbb46-b7b4-46c9-bf55-8d6e3807e1d2", 0x97);
			GUIDsToBody.Add("30c03cc8-5b8a-469b-bc3d-4b6f6a7e754c", 0x97);
			GUIDsToBody.Add("d3484987-f1fb-4ab9-917e-8c40df5aa270", 0x97);
			GUIDsToBody.Add("ed6b8eb1-a1e4-4fb4-8afb-2f5effeaf20d", 0x97);
			GUIDsToBody.Add("0b210fed-55ba-4687-92e6-083167a9963f", 0x97);
			GUIDsToBody.Add("5798a81e-993e-474e-a4be-0fa0ca7b966f", 0x97);
			GUIDsToBody.Add("8e4eaa1b-6616-40c2-bad0-68bd63a599bd", 0x97);
			GUIDsToBody.Add("707e1b5f-b907-45a8-ad81-a5715aa74211", 0x97);
			GUIDsToBody.Add("728d62bc-4da3-4cf6-b39c-d0a7b940455c", 0x97);
			GUIDsToBody.Add("66e5a5ac-7333-4cf6-b308-5f2413573eb7", 0x97);
			GUIDsToBody.Add("b24668a5-f48a-441a-bf8e-2a89fe8331c3", 0x97);
			GUIDsToBody.Add("9b89b9d5-3f27-4a90-af56-9339e73bac51", 0x97);
			GUIDsToBody.Add("48b0848b-f1e9-4a08-9f06-c5ff880ccd3a", 0x97);
			GUIDsToBody.Add("a35872c4-e5ab-4249-b0a9-21dfc71a5cc2", 0x97);
			GUIDsToBody.Add("6119d728-d89d-4f8e-b1ea-8b9b2f87d72b", 0x97);
			GUIDsToBody.Add("47ade7ec-4a51-4ca8-b873-7dc4a1469a0c", 0x9a);
			GUIDsToBody.Add("d1f81d4d-cf73-406f-9c21-60c170b58424", 0x9a);
			GUIDsToBody.Add("f8965e81-4ca9-4d9f-bf84-296fa84ff286", 0x9a);
			GUIDsToBody.Add("2e426681-8100-45c5-8712-908b0abee3a7", 0x9a);
			GUIDsToBody.Add("951cc4cf-63e1-477c-8750-cc954f47d88b", 0x9a);
			GUIDsToBody.Add("edb4be98-871d-4fbb-88ef-faab3ea78b79", 0x9a);
			GUIDsToBody.Add("04165cd6-d441-4fc2-8f97-42fd56c6e401", 0x9a);
			GUIDsToBody.Add("d3208bd2-a825-4f7b-8a84-45aa8b57d79a", 0x9a);
			GUIDsToBody.Add("3f1cc353-61dd-454a-8001-12500416eaf6", 0x9a);
			GUIDsToBody.Add("b0031946-a232-42b6-a1dd-b795808f8d1b", 0x9a);
			GUIDsToBody.Add("7b625319-e9a6-4746-9320-2f9a7e269fcb", 0x9a);
			GUIDsToBody.Add("d8c48ed1-35c5-4791-af1a-1f45a8d437e8", 0x9a);
			GUIDsToBody.Add("623ce9ce-f6b2-43fa-8efa-9c34c0c32fa4", 0x9a);
			GUIDsToBody.Add("372d73ed-1f61-4e2c-8a0c-d90263cbef22", 0x9a);
			GUIDsToBody.Add("c804dccf-aa40-42dd-9d2b-4039ddb29320", 0x9a);
			GUIDsToBody.Add("4346a4a1-2a07-4f16-b1da-efe51b1106b6", 0x9a);
			GUIDsToBody.Add("0bca384f-129a-41a7-900f-f254c73c2f27", 0x9a);
			GUIDsToBody.Add("bef2f8c6-f242-4145-bd7a-a42a5449d473", 0x9a);
			GUIDsToBody.Add("0ee184fb-461a-4e51-83bf-a720616e9f5c", 0x9b);
			GUIDsToBody.Add("3b9d4783-efc9-40c9-bb48-edb758f3e168", 0x9b);
			GUIDsToBody.Add("678bdb0a-8865-44a3-b91e-214ada279f5c", 0x9b);
			GUIDsToBody.Add("f51220b5-c77a-4196-9760-7cc5d9b5cb5e", 0x9b);
			GUIDsToBody.Add("2a9efad0-3ce6-4dba-9b1a-d9687045dc2b", 0x9b);
			GUIDsToBody.Add("1df35cb5-9734-4c51-b2d3-014df18f9920", 0x9b);
			GUIDsToBody.Add("3776ad67-a0ee-495b-87b3-e376db94564a", 0x9b);
			GUIDsToBody.Add("975c1adf-2680-4daf-9294-a0b60fa3680c", 0x9b);
			GUIDsToBody.Add("22f633c3-d157-4a88-a23b-662ea5a40e96", 0x9b);
			GUIDsToBody.Add("18d86b77-c917-4fa4-b8c9-50c7c05f244c", 0x9b);
			GUIDsToBody.Add("3f9262d6-ea5a-42cd-b812-2b43430743d4", 0x9b);
			GUIDsToBody.Add("df9dc94b-d0fe-4e18-8e92-819c75d69371", 0x9b);
			GUIDsToBody.Add("9476f5ca-f73f-4468-9bed-70dc5ef7f1cc", 0x9b);
			GUIDsToBody.Add("6062b427-7a68-430e-bbf1-18ace1cf0fc2", 0x9b);
			GUIDsToBody.Add("faf6daef-cb80-4b33-a590-9172d397cb9f", 0x9b);
			GUIDsToBody.Add("b26ade5c-c115-4ec2-879c-c1735a9bd674", 0x9b);
			GUIDsToBody.Add("b6a34c45-0f8f-4048-95ba-9c8e8cbe1fa9", 0x9b);
			GUIDsToBody.Add("893f3fe0-6c57-4da9-9935-1417d37c36dd", 0x9b);
			GUIDsToBody.Add("4b89a3e4-b774-4da6-a7a7-bc268cdf6635", 0x9c);
			GUIDsToBody.Add("c16395a8-33d8-4667-9106-4413072b9d69", 0x9c);
			GUIDsToBody.Add("5c11d598-7324-4098-afa4-ca3fcceec486", 0x9c);
			GUIDsToBody.Add("381ced49-c611-49dc-a132-bfb9be42376a", 0x9c);
			GUIDsToBody.Add("754fcd44-452b-494d-8ac8-c14df33e5e27", 0x9c);
			GUIDsToBody.Add("4ba9b4ef-d285-44fb-ad81-1bbbbd74697c", 0x9c);
			GUIDsToBody.Add("7432d0a2-a800-42af-a139-5e9d1504ea57", 0x9c);
			GUIDsToBody.Add("620e4c5e-28be-49ad-8798-8d8cdfda97d6", 0x9c);
			GUIDsToBody.Add("1ba3542a-9d41-49ef-a84d-5a4d646deb21", 0x9c);
			GUIDsToBody.Add("28807cc4-5aa4-43bc-95ac-45c1d46f6c31", 0x9c);
			GUIDsToBody.Add("0e21369f-056d-405a-8e9e-d2beb12e2380", 0x9c);
			GUIDsToBody.Add("a36df556-00d1-43b3-941f-53c66dcec06d", 0x9c);
			GUIDsToBody.Add("96179016-5206-44a5-8f3f-7ee1a6a6565a", 0x9c);
			GUIDsToBody.Add("3565a44b-30b7-413b-ba0f-984f950e7c0e", 0x9c);
			GUIDsToBody.Add("2e187fc6-4f76-42df-8a51-d070fe973f5f", 0x9c);
			GUIDsToBody.Add("d7d6b8d9-8b22-4b48-bede-f15d95bf5cc5", 0x9c);
			GUIDsToBody.Add("b8bbf5fa-0ecb-4c3d-b149-a5c9d9338569", 0x9c);
			GUIDsToBody.Add("a432ca7a-8f13-470f-9a24-6e91f519e79d", 0x9c);
			GUIDsToBody.Add("4df062ae-1db0-4426-bfdc-fa1ed36d00f3", 0x9d);
			GUIDsToBody.Add("7c7687f4-f4c0-44a3-85ac-b9aeb5897066", 0x9d);
			GUIDsToBody.Add("bd12acc2-95bb-4743-a4e9-f50a98314b16", 0x9d);
			GUIDsToBody.Add("658321fb-7401-44e3-a85a-8a7ba9413dbb", 0x9d);
			GUIDsToBody.Add("d9b23369-279f-46af-87b4-a01cb46aae19", 0x9d);
			GUIDsToBody.Add("318ae4f2-96e4-42ef-9627-01830e1cbd5c", 0x9d);
			GUIDsToBody.Add("ff485635-c9b9-4224-9eea-51a71c3f3eb2", 0x9d);
			GUIDsToBody.Add("46ec2629-172a-4cb4-99c5-e2252a67b9e1", 0x9d);
			GUIDsToBody.Add("fc76f14d-d03d-44cb-8dd9-6ad1fd376468", 0x9d);
			GUIDsToBody.Add("4f6b916b-fa1c-4c81-9bdf-4e00d6c2ad3d", 0x9d);
			GUIDsToBody.Add("8e6ba2ee-931a-4eb0-9dce-f6715e06b3d1", 0x9d);
			GUIDsToBody.Add("a71dc96c-4fb2-409d-be1d-29eee6adef95", 0x9d);
			GUIDsToBody.Add("c1139d08-eb2d-41f9-bece-9432f239a5e7", 0x9d);
			GUIDsToBody.Add("319e8ff7-7cc2-4781-b226-9df5b0f36025", 0x9d);
			GUIDsToBody.Add("e8f7afd2-8a1d-4d4f-ad87-0fd4d393ecd7", 0x9d);
			GUIDsToBody.Add("133a438f-c28f-423a-b9be-0d05c2a78959", 0x9d);
			GUIDsToBody.Add("b8b11228-77ea-4d47-b729-019c4c715bd8", 0x9d);
			GUIDsToBody.Add("0c039a26-0a56-4300-a945-d444f0652378", 0x9d);
			GUIDsToBody.Add("55cefb77-9106-489c-99e6-fc98eedf3dd3", 0x9f);
			GUIDsToBody.Add("79048f89-02c3-4642-8201-747b3ffee2fa", 0x9f);
			GUIDsToBody.Add("27c3ff14-50ad-4505-983a-78c3ed6c369c", 0x9f);
			GUIDsToBody.Add("e8bff557-fd42-49e9-b8ae-a6b9eaa22794", 0x9f);
			GUIDsToBody.Add("20ecde99-0ef4-4cdb-9eed-3a2c5a6e0cb0", 0x9f);
			GUIDsToBody.Add("51468bbc-30e3-4aec-916d-62dfe97b4005", 0x9f);
			GUIDsToBody.Add("e80c7451-fc19-4872-9329-c3459d3242ec", 0x9f);
			GUIDsToBody.Add("1bc5e90c-2da1-4ca0-b485-81ee665d3f34", 0x9f);
			GUIDsToBody.Add("69bc1312-d1b2-4c06-a4fb-7632bd842e11", 0x9f);
			GUIDsToBody.Add("6261b3a3-257a-432f-8f20-3e36cccaede2", 0x9f);
			GUIDsToBody.Add("eb2998f5-3809-41cd-aa0a-835a042002c9", 0x9f);
			GUIDsToBody.Add("9d23eca1-0a15-4d27-9945-cc635a22d4cc", 0x9f);
			GUIDsToBody.Add("cccaa51d-7ea4-4f1e-9166-26f9a8e3bfc3", 0x9f);
			GUIDsToBody.Add("1a3ac47f-1915-43dc-a078-16cb5aec3954", 0x9f);
			GUIDsToBody.Add("985c4572-b487-4521-a26f-e59e443b6a9a", 0x9f);
			GUIDsToBody.Add("db595385-7993-4d4d-b771-36845317f601", 0x9f);
			GUIDsToBody.Add("980e3f60-c7d1-42d4-a1f7-9f5b00aaefbc", 0x9f);
			GUIDsToBody.Add("3d71f6ff-3e30-4472-9c3f-ce1b3094b96f", 0x9f);
			GUIDsToBody.Add("0964b053-6922-427d-9bdf-01af64457b5e", 0x9f);
			GUIDsToBody.Add("34947a9d-ffc4-4d5b-84c8-2e6d31b3d3c5", 0xb1);
			GUIDsToBody.Add("cb2a398a-f754-42be-a8ed-6d55a916aefa", 0xb1);
			GUIDsToBody.Add("01223375-d00a-45bb-909c-bb2c867e6298", 0xb1);
			GUIDsToBody.Add("66c098b6-cdbf-4050-9da2-03635f3ba0ef", 0xb1);
			GUIDsToBody.Add("cfde9935-6761-403a-9025-b4e13638e5ef", 0xb1);
			GUIDsToBody.Add("0bed3feb-e611-4608-ad7f-e4df89132144", 0xb1);
			GUIDsToBody.Add("47d98ee1-3acd-46b2-b0b4-aadee6405623", 0xb1);
			GUIDsToBody.Add("22df27db-0546-4361-bbe6-c5c5c0bfb83b", 0xb1);
			GUIDsToBody.Add("f9b2b464-3a08-4bdd-99b0-94ff7b10e6ad", 0xb1);
			GUIDsToBody.Add("4cfb72a9-6a0c-400d-8ec1-1269ec8df29a", 0xb1);
			GUIDsToBody.Add("82d0d47a-eac0-411a-89d6-aaa6709f1b96", 0xb1);
			GUIDsToBody.Add("b8c9a45c-528e-42b3-84dc-041c11aae7ad", 0xb1);
			GUIDsToBody.Add("ff5ec564-eab3-4104-8b11-98fe2226d7d6", 0xb1);
			GUIDsToBody.Add("946f8c5a-7a08-4612-9849-3569333e86d7", 0xb1);
			GUIDsToBody.Add("95c37bfa-feaa-420a-b943-cdc42bcaa594", 0xb2);
			GUIDsToBody.Add("7177c053-e665-4cdc-b4c1-f797d3457cb3", 0xb2);
			GUIDsToBody.Add("8ac74358-28c9-408c-9b39-46a177bfeb14", 0xb2);
			GUIDsToBody.Add("116a69ed-066e-4d96-85aa-366a3c603c1d", 0xb2);
			GUIDsToBody.Add("b5687cb9-04be-4fd7-8c90-8ebc77d1a2eb", 0xb2);
			GUIDsToBody.Add("d5aa2bc0-e020-4140-b5e6-6950f1472cf0", 0xb2);
			GUIDsToBody.Add("2f1ce121-53b9-4cb1-9f2d-987b6b2296b8", 0xb2);
			GUIDsToBody.Add("2c468d22-9896-471e-9196-fd09b45dee85", 0xb2);
			GUIDsToBody.Add("15687fab-9f85-48e0-9b92-ab338b6f2c6b", 0xb2);
			GUIDsToBody.Add("d1a1bc8d-f89a-44df-a7a9-a7b41f467557", 0xb2);
			GUIDsToBody.Add("3696daf7-66d6-4151-8706-6db9768576a5", 0xb2);
			GUIDsToBody.Add("2aa6e8ac-cd21-4c82-b42d-49fd48a2afac", 0xb2);
			GUIDsToBody.Add("1029a9fc-2df6-406d-9f60-5e79ec4abce6", 0xb2);
			GUIDsToBody.Add("ceb3d011-0642-4eee-8c16-8982fa513d4e", 0xb2);
			GUIDsToBody.Add("aac164ab-f93d-495f-8d84-9a763f98447c", 0xb2);
			GUIDsToBody.Add("673f9bfa-a0f1-4053-b297-77d36591e02a", 0xb2);
			GUIDsToBody.Add("49d3841d-3f57-4183-b97c-869a440f7f7a", 0xb2);
			GUIDsToBody.Add("e5ac8690-71e7-4a6a-9f8d-c9b7c3ee833d", 0xb2);
			GUIDsToBody.Add("a69ac3ae-88da-4318-b95b-7b613c69c3d4", 0xb4);
			GUIDsToBody.Add("ff31c926-8ba8-4a2f-9090-1ad8b152b6f4", 0xb4);
			GUIDsToBody.Add("c13b7762-9600-43f7-9828-637f9264990f", 0xb4);
			GUIDsToBody.Add("0c62cb01-4935-488a-a7dc-96a9f1876f5b", 0xb4);
			GUIDsToBody.Add("a2ef5048-2580-420a-b45a-e2a1697c7c17", 0xb4);
			GUIDsToBody.Add("8cd0dbab-2282-4f89-9a91-6a14ffb193ae", 0xb4);
			GUIDsToBody.Add("41247e25-fc22-4fed-8451-ba2cb68c607a", 0xb4);
			GUIDsToBody.Add("cc55c0db-ef18-429c-9ffe-05248b7837e0", 0xb4);
			GUIDsToBody.Add("ce4282ff-8f9b-4358-b51a-22426db03cc7", 0xb4);
			GUIDsToBody.Add("4be2dae1-f33d-49bd-8acf-3c6272b9c71d", 0xb4);
			GUIDsToBody.Add("e9e63986-5429-4f2c-ac67-62f2e5fb6d66", 0xb4);
			GUIDsToBody.Add("ae1874d9-e7bd-43a5-8a63-67b97bf34130", 0xb4);
			GUIDsToBody.Add("43474548-f31c-4f27-bd7d-b5f5ce23ec76", 0xb4);
			GUIDsToBody.Add("811af837-0c5b-4d68-bfba-8a1338697302", 0xb4);
			GUIDsToBody.Add("11b42b95-676a-4a9a-bb2d-dbf080c75163", 0xb4);
			GUIDsToBody.Add("052b6776-2176-4fda-b84b-bb3881ebda44", 0xb4);
			GUIDsToBody.Add("0cb2940d-3e23-4253-bb53-6d67aa87250a", 0xb4);
			GUIDsToBody.Add("b355d219-e5c1-4f24-a434-d42727b63b95", 0xb4);
			GUIDsToBody.Add("588366a7-23df-45aa-9b90-af7ac774a668", 0xb8);
			GUIDsToBody.Add("21fb9ea2-7b01-4cd5-a5ec-c50b78caeb50", 0xb8);
			GUIDsToBody.Add("0fbc6e73-5462-4ef8-b262-e0aaa3b98acc", 0xb8);
			GUIDsToBody.Add("c959ec5d-ea31-45c9-b706-f12ca7888bbf", 0xb8);
			GUIDsToBody.Add("c004d349-e6c9-4330-a8f9-4f4e604943ea", 0xb8);
			GUIDsToBody.Add("d398bf67-d30c-4d37-a56a-9e390e5e837e", 0xb8);
			GUIDsToBody.Add("21b9c504-55dc-45ff-98fa-e1dabaa02b50", 0xb8);
			GUIDsToBody.Add("88516199-ff5f-4a32-ba16-73d122fddfc3", 0xb8);
			GUIDsToBody.Add("4e968fca-d566-4a6b-bea9-f73cac2cb40f", 0xb8);
			GUIDsToBody.Add("2a71a69f-9f1b-4a37-80f3-64e1bbc71d4a", 0xb8);
			GUIDsToBody.Add("fe8ef15d-1fb3-43ed-ad19-ec6b80dffbe9", 0xb8);
			GUIDsToBody.Add("7d9515a8-962f-463e-b025-cea3163a4964", 0xb8);
			GUIDsToBody.Add("1fb83e95-2fd1-4eb0-9777-ddac0fabc5af", 0xb8);
			GUIDsToBody.Add("487d2c7a-d9bc-453e-a131-e90f07103656", 0xb8);
			GUIDsToBody.Add("3854cff6-57d2-4106-84cb-c42a325b2dfb", 0xb8);
			GUIDsToBody.Add("a5b58741-2546-42ea-ad3d-bdf80b99bae4", 0xb8);
			GUIDsToBody.Add("6c10236f-354c-4071-8d4c-3db4a37dd638", 0xb8);
			GUIDsToBody.Add("6ee673e5-7443-442f-ad1a-e4af7495d9a0", 0xb8);
			GUIDsToBody.Add("27b93d07-1167-464d-a501-877754124b68", 0xb8);
			GUIDsToBody.Add("b0d99a3f-ce6d-4c01-b603-1a8444f5e787", 0xba);
			GUIDsToBody.Add("d2fa0e75-a66a-4358-baf7-9190cbb4135a", 0xba);
			GUIDsToBody.Add("4df3d8f6-d2a9-462c-8278-6291d25f4789", 0xba);
			GUIDsToBody.Add("37d9500e-9aa3-49e7-add1-7e04b7b7b270", 0xba);
			GUIDsToBody.Add("d181da0e-9d68-4836-9fde-ce2d3ace77c7", 0xba);
			GUIDsToBody.Add("e667f95d-5e3c-41ac-86b0-7bb1b47237ff", 0xba);
			GUIDsToBody.Add("361f4d31-c9ba-4e11-bbcc-b93adc5535f6", 0xba);
			GUIDsToBody.Add("fc933f62-2d12-4f60-a301-2eecb42353d6", 0xba);
			GUIDsToBody.Add("344eaab9-f6d9-4f1a-8625-80f1d4ef1a0d", 0xba);
			GUIDsToBody.Add("78e44210-4d1e-4103-a15d-ccdeb44c2a9f", 0xba);
			GUIDsToBody.Add("f79a7683-5abe-4264-b94c-6bd45ee422bf", 0xba);
			GUIDsToBody.Add("4670f25f-7f3c-43f7-a6ba-132ec7c63e2e", 0xba);
			GUIDsToBody.Add("4d0c72c5-5984-425e-ba64-8af37fd68fcb", 0xba);
			GUIDsToBody.Add("62d1b554-3134-47dd-b327-218b728db136", 0xba);
			GUIDsToBody.Add("6d98dd7c-74bd-4e9c-b777-c8d512a98b6e", 0xba);
			GUIDsToBody.Add("7ee958c9-95b3-41c1-abcc-774940f2d99b", 0xba);
			GUIDsToBody.Add("cd68093e-948c-47b1-8af6-81e57d4e7746", 0xba);
			GUIDsToBody.Add("9185d357-d7ad-4e2a-8284-43ddc4c891cc", 0xba);
			GUIDsToBody.Add("7d005c38-8a02-49fc-89c3-6afb46fc34ab", 0xbe);
			GUIDsToBody.Add("01ce0151-f698-45f2-ba94-0847d926e472", 0xbe);
			GUIDsToBody.Add("b9db2077-dbb2-4f6f-9ef9-98cc0fff1d7b", 0xbe);
			GUIDsToBody.Add("cacf90ad-d02e-4590-9abc-2a20f699b546", 0xbe);
			GUIDsToBody.Add("a1278396-8c27-4ff7-a2a9-418142c69be4", 0xbe);
			GUIDsToBody.Add("59b422ca-9428-4e3c-aa6d-c5729b864fc8", 0xbe);
			GUIDsToBody.Add("59e24016-0cec-4eb6-9107-d1d7f35347ae", 0xbe);
			GUIDsToBody.Add("403b8b2f-2cfe-491c-9322-05eb1a0b5c91", 0xbe);
			GUIDsToBody.Add("4b2a9395-da92-426d-94a2-94a3755c82d9", 0xbe);
			GUIDsToBody.Add("76d43fa1-915f-4362-a7c2-3ff64fd250dd", 0xbe);
			GUIDsToBody.Add("d51cfac4-3531-43ba-ac87-ab52f5524fd5", 0xbe);
			GUIDsToBody.Add("9cc9adf7-9931-4ea1-a2e7-6759ba73a028", 0xbe);
			GUIDsToBody.Add("bcff0b57-0d9a-4b45-a140-9cc8fe9e84e0", 0xbe);
			GUIDsToBody.Add("9dce38bc-77ea-4f2f-bcbe-36751f0a865c", 0xbe);
			GUIDsToBody.Add("c71326c0-f4af-4aeb-ae1a-7cad2e559d1b", 0xdc);
			GUIDsToBody.Add("131591e7-3e6e-4ce3-a2ef-7403d4815418", 0xdc);
			GUIDsToBody.Add("7723194b-cb5c-4e75-9137-51dab5c1a07f", 0xdc);
			GUIDsToBody.Add("3dc711a0-003b-414d-a31d-c187ae51f4f7", 0xdc);
			GUIDsToBody.Add("7bf2fda0-0df2-4354-b658-38c4a1bcfba4", 0xdc);
			GUIDsToBody.Add("d3272ab2-aced-4f5a-8228-7830b727576c", 0xdc);
			GUIDsToBody.Add("5e03dbde-f84b-4d15-b015-de2b571863cf", 0xdc);
			GUIDsToBody.Add("fee815cc-7def-49c4-b659-824c2ddea006", 0xdc);
			GUIDsToBody.Add("a0b74867-3f3d-4f00-9836-382de90ed2f7", 0xdc);
			GUIDsToBody.Add("957ee3e7-a4dd-4c61-9d17-116c0b8778e5", 0xdc);
			GUIDsToBody.Add("101d1088-0019-4e7e-b6b4-357f8dee4ea3", 0xdc);
			GUIDsToBody.Add("774dca6a-5426-4a7f-8225-ab4b308235c9", 0xdc);
			GUIDsToBody.Add("9314daaf-e65e-4147-98bc-c3863dc79ca0", 0xdc);
			GUIDsToBody.Add("ddecb02a-fdfb-4668-b80f-55b269ae367a", 0xdc);
			GUIDsToBody.Add("e0d2116f-cc0d-4ac7-9d74-e25e3afa6f70", 0xdc);
			GUIDsToBody.Add("ed6880a4-3c48-485c-b3a5-34df27954b44", 0xdc);
			GUIDsToBody.Add("69f2d27a-0747-43e1-8a8d-7dc792524b91", 0xdc);
			GUIDsToBody.Add("2ff31fc5-87c5-4860-aa85-3d6403824dae", 0xdc);
			GUIDsToBody.Add("2ec7c928-4c84-473f-982c-3b383b7eddcf", 0xe2);
			GUIDsToBody.Add("9edee0c6-7df9-4697-8f0e-9f726c7a917a", 0xe2);
			GUIDsToBody.Add("fa610813-05f1-419f-be50-a4df6f160aa9", 0xe2);
			GUIDsToBody.Add("70130a0d-56c6-487e-b640-62d66f4a026a", 0xe2);
			GUIDsToBody.Add("65c61229-a54a-4d66-8e8f-7024ea3354f3", 0xe2);
			GUIDsToBody.Add("8d124485-114c-4074-9233-5385ddb24c97", 0xe2);
			GUIDsToBody.Add("0488e6dc-35ba-4d07-a50a-b5ddc6f685eb", 0xe2);
			GUIDsToBody.Add("5a65d05d-c2a4-438e-a9b9-24fb642442d5", 0xe2);
			GUIDsToBody.Add("f46b73c2-c41d-4d8c-9cd1-1f327692a93c", 0xe2);
			GUIDsToBody.Add("3456d856-5d14-4572-b127-b7982af6958b", 0xe2);
			GUIDsToBody.Add("a1eae855-8df0-4962-9261-83307dfddb08", 0xe2);
			GUIDsToBody.Add("0c510dbb-1831-48a6-98f2-36f02fd710a2", 0xe2);
			GUIDsToBody.Add("5922cb39-a9eb-4fd7-a826-eacfd807e484", 0xe2);
			GUIDsToBody.Add("6a54906d-d4d7-4a70-9ef8-c1a2b90e7ea3", 0xe2);
			GUIDsToBody.Add("ad225962-31a4-4e95-9f0f-c44a8a394068", 0xe2);
			GUIDsToBody.Add("47ee1539-3798-4102-abca-925e638d8402", 0xe2);
			GUIDsToBody.Add("8f434818-5670-4e26-8e0d-2198eda8a2c0", 0xe2);
			GUIDsToBody.Add("12b88f38-6e65-41e5-bc08-93735891c56d", 0xe2);
			GUIDsToBody.Add("26308b70-bc2c-46e3-98c2-008a0ac356a1", 0xe2);
			GUIDsToBody.Add("1cd15838-d35c-438b-83c2-90305a0a2bf5", 0xe2);
			GUIDsToBody.Add("1e5da31f-a9a5-4ba1-955b-5fdfad1f5fe8", 0xe2);
			GUIDsToBody.Add("1c41b676-b720-4534-b219-b266d437f24c", 0xe2);
			GUIDsToBody.Add("2e16a776-d952-4dfb-ae92-c53fba12121e", 0xe2);
			GUIDsToBody.Add("830c21c4-0fa6-4cd2-a43e-5b8543bd567d", 0xe2);
			GUIDsToBody.Add("c9ba3bbf-4764-491a-b577-c51328375ec3", 0xe2);
			GUIDsToBody.Add("55a0974a-d8af-4a2f-9968-bbb18b78388f", 0xe2);
			GUIDsToBody.Add("70d5fe19-3494-49ae-9ddb-759a8d69534b", 0xe2);
			GUIDsToBody.Add("bd66e673-478f-6bd6-7602-b7aad7bdc66d", 0xe2);
			GUIDsToBody.Add("d41de7e5-4fc4-1ce9-4ff5-8b83220f180b", 0xe2);
			GUIDsToBody.Add("4ac1df08-4d04-8c16-d94b-d4935d506c90", 0xe2);
			GUIDsToBody.Add("1c3ab440-40e4-99a2-36a3-e89d4f85c790", 0xe2);
			GUIDsToBody.Add("3b1fd940-e99b-40f6-b4a7-0264a9aef3e0", 0x1e);
			GUIDsToBody.Add("19f2f908-9fe1-4300-a18b-855c3fd23b99", 0x1e);
			GUIDsToBody.Add("a672a0c3-a5de-4b8c-996a-92f867a35d14", 0x1e);
			GUIDsToBody.Add("dc68ee73-3f67-4d83-80a4-8ede60536575", 0x1e);
			GUIDsToBody.Add("115b0ddf-9314-40cb-a816-33004381ceb4", 0x1e);
			GUIDsToBody.Add("da8c69fb-d852-4825-a659-238d21348a41", 0x1e);
			GUIDsToBody.Add("52146a86-a5e8-4c77-b891-679b288a3d7a", 0x1e);
			GUIDsToBody.Add("e06abb8c-7f28-467b-b004-6ea0e8bd71db", 0x1e);
			GUIDsToBody.Add("6159e424-2244-44f7-85a9-94b875c33eb3", 0x1e);
			GUIDsToBody.Add("e186fc73-cb51-4e41-87da-d4fc7fdadf60", 0x9e);
			GUIDsToBody.Add("5cfdaba3-eb15-4a24-803d-f7f096b22a8e", 0x9e);
			GUIDsToBody.Add("b05f3a75-a681-41fc-a430-a3a64f447181", 0x9e);
			GUIDsToBody.Add("0d8b4938-3096-4c75-988a-e14e3ce0df00", 0x9e);
			GUIDsToBody.Add("f4e1254f-f325-4361-a735-6bac0aba0cb4", 0x9e);
			GUIDsToBody.Add("eb08bf98-1386-4d49-ab6e-2b8f1bbe56b5", 0x9e);
			GUIDsToBody.Add("a9af48eb-c805-476a-90e3-ac854cb508f5", 0x9e);
			GUIDsToBody.Add("c36a73b1-858e-4ce8-b69c-6422e82486cd", 0x9e);
			GUIDsToBody.Add("46c779b1-af09-44ac-b88b-2c8a41ea455a", 0x9e);
			GUIDsToBody.Add("4d6de11c-89f7-4876-b7f0-ae6afed9fa8b", 0x9e);
			GUIDsToBody.Add("c91db02e-65c2-4d2f-8acc-2d865cc22268", 0x9e);
			GUIDsToBody.Add("8141ba87-df21-4bd9-99ed-94a6d03eb277", 0x9e);
			GUIDsToBody.Add("2b4d8e08-062c-4f56-8ccc-99d29276d428", 0x9e);
			GUIDsToBody.Add("fbd36887-5b8a-4101-9e53-6208e0f5b89a", 0x9e);
			GUIDsToBody.Add("8b234906-d3cc-4201-9c00-6a120434ae36", 0x9e);
			GUIDsToBody.Add("00000001-0000-0000-0000-000000000000", 0x1e);
			GUIDsToBody.Add("00000002-0000-0000-0000-000000000000", 0x1e);
			GUIDsToBody.Add("00000003-0000-0000-0000-000000000000", 0x1e);
			GUIDsToBody.Add("00000004-0000-0000-0000-000000000000", 0x1e);
			GUIDsToBody.Add("00000005-0000-0000-0000-000000000000", 0x1e);
			GUIDsToBody.Add("00000006-0000-0000-0000-000000000000", 0x1e);
			GUIDsToBody.Add("6baf064a-85ad-4e37-8d81-a987e9f8da46", 0x1e);
			GUIDsToBody.Add("b6ee1dbc-5bb3-4146-8315-02bd64eda707", 0x1e);
			GUIDsToBody.Add("b9a94827-7544-450c-a8f4-6f643ae89a71", 0x1e);
			GUIDsToBody.Add("6eea47c7-8a35-4be7-9242-dcd082f53b55", 0x1e);

			foreach (Interfaces.IAlias a in AddonSkins)
			{
				GUIDsToBody.Add(a.Name, a.Id);
			}
		}

		public static Dictionary<uint, string> BodyShapeIds =
			new Dictionary<uint, string>();

		public static string GetBodyName(uint id)
		{
			if (BodyShapeIds.Count < 2)
			{
				InitializeBodyShapes();
			}

			if (BodyShapeIds.ContainsKey(id))
			{
				return BodyShapeIds[id];
			}

			return "Unknown";
		}

		public static uint GetBodyShapeKey(object ob)
		{
			if (BodyShapeIds.Count < 2)
			{
				InitializeBodyShapes();
			}

			string val = Convert.ToString(ob);
			if (BodyShapeIds.ContainsValue(val))
			{
				foreach (KeyValuePair<uint, string> kvp in BodyShapeIds)
				{
					if (kvp.Value == val)
					{
						return kvp.Key;
					}
				}
			}

			return 0;
		}

		public static void InitializeBodyShapes()
		{
			BodyShapeIds.Clear();
			BodyShapeIds.Add(0x00, " Maxis : Default");
			BodyShapeIds.Add(0x16, "Not a Bodyshape : Gold Star");
			BodyShapeIds.Add(0x17, "Not a Bodyshape : Silver Star");
			BodyShapeIds.Add(0x1e, "Maxis : Maxis");
			// BodyShapeIds.Add(0x1f, "Holiday");
			BodyShapeIds.Add(0x20, "SITES : Goth");
			// BodyShapeIds.Add(0x21, "SteamPunk");
			BodyShapeIds.Add(0x22, "SITES : Medieval");
			// BodyShapeIds.Add(0x23, "StoneAge");
			BodyShapeIds.Add(0x24, "SITES : Pirates");
			BodyShapeIds.Add(0x26, "SITES : Grungy");
			BodyShapeIds.Add(0x29, "SITES : Super Heros");
			//BodyShapeIds.Add(0x2a, "Futuristic");
			BodyShapeIds.Add(0x2c, "Various : Various");
			BodyShapeIds.Add(0x2d, "Synaptic Sim : Werewolves");
			BodyShapeIds.Add(0x2f, "Creatures : Satyrs");
			BodyShapeIds.Add(0x30, "Creatures : Centaurs");
			BodyShapeIds.Add(0x31, "Creatures : Mermaid");
			BodyShapeIds.Add(0x33, "Synaptic Sim : Huge Body Builder Beast");
			BodyShapeIds.Add(0x35, "Synaptic Sim : Nightcrawler - Nocturne");
			BodyShapeIds.Add(0x36, "Cynnix : Quarians");
			BodyShapeIds.Add(0x37, "MartaXL : Martaxlm");
			BodyShapeIds.Add(0x38, "DarkPsyFox : Fat Dark PsyFox");
			BodyShapeIds.Add(0x39, "Melodie9 : Fat Family Male");
			BodyShapeIds.Add(0x3a, "Netra : Chubby Guy");
			BodyShapeIds.Add(0x3b, "Consort : Consort's Fat Male");
			BodyShapeIds.Add(0x3d, "Synaptic Sim : Massive Body Builder");
			BodyShapeIds.Add(0x3f, "Montoto : Bear Body Builder");
			BodyShapeIds.Add(0x40, "Boesboxyboy-Marvine : Super Hero");
			BodyShapeIds.Add(0x41, "Boesboxyboy-Marvine : Huge Body Builder");
			BodyShapeIds.Add(0x43, "Boesboxyboy-Marvine : Body Body Builder");
			BodyShapeIds.Add(0x45, "Boesboxyboy-Marvine : Slim Body Builder");
			BodyShapeIds.Add(0x47, "Bloom : Neanderthal");
			BodyShapeIds.Add(0x48, "Zenman : Fit");
			BodyShapeIds.Add(0x49, "Boesboxyboy-Marvine : Athlete");
			BodyShapeIds.Add(0x4b, "Synaptic Sim : Lean Body Builder");
			BodyShapeIds.Add(0x4c, "Transgender(BCup) : Transgender B-Cup");
			BodyShapeIds.Add(0x4d, "Corrine : PunkJunkie");
			BodyShapeIds.Add(0x4e, "July77 : Slim Male");
			BodyShapeIds.Add(0x4f, "Melodie9 : Slim Family Male");
			BodyShapeIds.Add(0x5c, "Bloom : Monster Jugs");
			BodyShapeIds.Add(0x5d, "Bloom : Hyper Busty");
			BodyShapeIds.Add(0x5f, "MartaXL : Martaxl");
			BodyShapeIds.Add(0x60, "Netra : Big Girl");
			BodyShapeIds.Add(0x61, "Melodie9 : Fat Family Female");
			BodyShapeIds.Add(0x62, "Netra : Thick Madame");
			BodyShapeIds.Add(0x63, "Franny Sims : Momma Lisa");
			BodyShapeIds.Add(0x64, "Faeriegurl : Fat Faerie gurl");
			BodyShapeIds.Add(0x65, "Warlokk : Booty Gal");
			BodyShapeIds.Add(0x66, "Telfin : Mountain Girl");
			BodyShapeIds.Add(0x67, "Mia Studios : Booty Cutie");
			BodyShapeIds.Add(0x68, "Netra : Curvy Mama");
			BodyShapeIds.Add(0x69, "Warlokk : Renaissance Gal");
			BodyShapeIds.Add(0x6a, "Jessica : Gypsy Rose Lee");
			BodyShapeIds.Add(0x6b, "Pierre : Teresa Queen");
			BodyShapeIds.Add(0x6c, "Cynnix : Buxum Wench");
			BodyShapeIds.Add(0x6d, "Warlokk : Voluptuous");
			BodyShapeIds.Add(0x6f, "Dr. Pixel : Well Rounded");
			BodyShapeIds.Add(0x70, "Netra : Curvy Girl");
			BodyShapeIds.Add(0x71, "Zenman : Big");
			BodyShapeIds.Add(0x72, "Warlokk : Power Gal");
			BodyShapeIds.Add(0x74, "Warlokk : Xenos Heroine");
			BodyShapeIds.Add(0x75, "Chris H : Body Builder Girl D");
			BodyShapeIds.Add(0x76, "Boesboxyboy-Marvine : Body Builder Girl");
			BodyShapeIds.Add(0x77, "Starangel : Curvy GirlS");
			BodyShapeIds.Add(0x79, "Pierre : Nichon Queen");
			BodyShapeIds.Add(0x7b, "Pierre : Divine Queen");
			BodyShapeIds.Add(0x7d, "Warlokk : Classic Pinup Gal");
			BodyShapeIds.Add(0x7f, "Pierre : Amour Queen");
			BodyShapeIds.Add(0x80, "Zenman : Young Elder");
			BodyShapeIds.Add(0x81, "Pierre : Beaute Queen");
			BodyShapeIds.Add(0x82, "Lipje : Round DCup");
			BodyShapeIds.Add(0x83, "Pierre : Cherie Queen");
			BodyShapeIds.Add(0x84, "Cylais : Swimsuit");
			BodyShapeIds.Add(0x86, "Vanity DeMise : Farmer Daughter");
			BodyShapeIds.Add(0x87, "Zenman : Curvier");
			BodyShapeIds.Add(0x88, "Oph3lia : SC");
			BodyShapeIds.Add(0x89, "Pierre : Olympe Queen");
			BodyShapeIds.Add(0x8b, "Boesboxyboy-Marvine : Athletic Girl");
			BodyShapeIds.Add(0x8e, "Jaccirocker : Statuesque");
			BodyShapeIds.Add(0x90, "Franny Sims : Kurvy K");
			BodyShapeIds.Add(0x92, "Warlokk : Toon Gal");
			BodyShapeIds.Add(0x94, "Bobby TH : Girl Next Door");
			BodyShapeIds.Add(0x95, "Chris H : Naughty Girl");
			BodyShapeIds.Add(0x96, "Warlokk : Rio Girl");
			BodyShapeIds.Add(0x97, "Wooden Bear : Hollywood");
			BodyShapeIds.Add(0x98, "Bloom : Ruben");
			BodyShapeIds.Add(0x99, "Bobby TH : BootyLicious G");
			BodyShapeIds.Add(0x9a, "Sussi : Sussi");
			BodyShapeIds.Add(0x9b, "Bobby TH : BootyLicious DD");
			BodyShapeIds.Add(0x9c, "DL Mulsow : HourGlass");
			BodyShapeIds.Add(0x9d, "Bobby TH : BootyLicious");
			BodyShapeIds.Add(0x9e, "Bobby TH : BootyLicious C");
			BodyShapeIds.Add(0x9f, "Bobby TH : Made Of Dreams");
			BodyShapeIds.Add(0xa3, "Rising Sun : Fantasy Girl");
			BodyShapeIds.Add(0xa6, "Pierre : Modele Queen");
			BodyShapeIds.Add(0xa8, "Pierre : Poupee Queen");
			BodyShapeIds.Add(0xaa, "Pierre : Chaton Queen");
			BodyShapeIds.Add(0xad, "Pierre : Darling Queen");
			BodyShapeIds.Add(0xaf, "Rising Sun : Dream Girl");
			BodyShapeIds.Add(0xb1, "Poppeboy : Fit Chick");
			BodyShapeIds.Add(0xb2, "Nemesis : Natural Beauty");
			BodyShapeIds.Add(0xb4, "Pierre : Petite Queen");
			BodyShapeIds.Add(0xb7, "Inebriant : SexyBum");
			BodyShapeIds.Add(0xb8, "Chris H : Fashion Model D-36");
			BodyShapeIds.Add(0xba, "Warlokk : Fashion Model");
			BodyShapeIds.Add(0xbc, "Gothplague : Androgyny");
			BodyShapeIds.Add(0xbe, "Warlokk : Faerie Gal");
			BodyShapeIds.Add(0xc0, "Gothplague : Miana");
			BodyShapeIds.Add(0xc1, "Melodie9 : SlimFamily Female");
			BodyShapeIds.Add(0xc3, "Warlokk : (teen) D X-Large");
			BodyShapeIds.Add(0xc4, "Warlokk : (teen) D Large");
			BodyShapeIds.Add(0xc5, "Warlokk : (teen) D Medium");
			BodyShapeIds.Add(0xc6, "Warlokk : (teen) C X-Large");
			BodyShapeIds.Add(0xc7, "Warlokk : (teen) C Large");
			BodyShapeIds.Add(0xc8, "Warlokk : (teen) C Medium");
			BodyShapeIds.Add(0xc9, "Warlokk : (teen) C Small");
			BodyShapeIds.Add(0xca, "Warlokk : (teen) B X-Large");
			BodyShapeIds.Add(0xcb, "Warlokk : (teen) B Large");
			BodyShapeIds.Add(0xcc, "Warlokk : (teen) B Small");
			BodyShapeIds.Add(0xcd, "Warlokk : (teen) A X-Large");
			BodyShapeIds.Add(0xce, "Warlokk : (teen) A Large");
			BodyShapeIds.Add(0xcf, "Warlokk : (teen) A Medium");
			BodyShapeIds.Add(0xd0, "Warlokk : (teen) A Small");
			BodyShapeIds.Add(0xd2, "Warlokk : DDD-40");
			BodyShapeIds.Add(0xd3, "Warlokk : DDD-38");
			BodyShapeIds.Add(0xd4, "Warlokk : DDD-36");
			BodyShapeIds.Add(0xd5, "Warlokk : DDD-34");
			BodyShapeIds.Add(0xd6, "Warlokk : DD-40");
			BodyShapeIds.Add(0xd7, "Warlokk : DD-38");
			BodyShapeIds.Add(0xd8, "Warlokk : DD-36");
			BodyShapeIds.Add(0xd9, "Warlokk : DD-34");
			BodyShapeIds.Add(0xda, "Warlokk : D-40");
			BodyShapeIds.Add(0xdb, "Warlokk : D-38");
			BodyShapeIds.Add(0xdc, "Warlokk : D-36");
			BodyShapeIds.Add(0xdd, "Warlokk : D-34");
			BodyShapeIds.Add(0xde, "Warlokk : D-32");
			BodyShapeIds.Add(0xdf, "Warlokk : C-40");
			BodyShapeIds.Add(0xe0, "Warlokk : C-38");
			BodyShapeIds.Add(0xe1, "Warlokk : C-36");
			BodyShapeIds.Add(0xe2, "Warlokk : C-34");
			BodyShapeIds.Add(0xe3, "Warlokk : C-32");
			BodyShapeIds.Add(0xe4, "Warlokk : B-40");
			BodyShapeIds.Add(0xe5, "Warlokk : B-38");
			BodyShapeIds.Add(0xe6, "Warlokk : B-36");
			BodyShapeIds.Add(0xe7, "Warlokk : B-32");
			BodyShapeIds.Add(0xe8, "Warlokk : A-40");
			BodyShapeIds.Add(0xe9, "Warlokk : A-38");
			BodyShapeIds.Add(0xea, "Warlokk : A-36");
			BodyShapeIds.Add(0xeb, "Warlokk : A-34");
			BodyShapeIds.Add(0xec, "Warlokk : A-32");
			BodyShapeIds.Add(0xee, "Warlokk : (tf Bottom) X-Large");
			BodyShapeIds.Add(0xef, "Warlokk : (tf Bottom) Large");
			BodyShapeIds.Add(0xf0, "Warlokk : (tf Bottom) Small");
			BodyShapeIds.Add(0xf2, "Warlokk : (AF Bottom) 40");
			BodyShapeIds.Add(0xf3, "Warlokk : (AF Bottom) 38");
			BodyShapeIds.Add(0xf4, "Warlokk : (AF Bottom) 36");
			BodyShapeIds.Add(0xf5, "Warlokk : (AF Bottom) 32");
			BodyShapeIds.Add(0xf7, "Warlokk : (Top) DDD");
			BodyShapeIds.Add(0xf8, "Warlokk : (Top) DD");
			BodyShapeIds.Add(0xf9, "Warlokk : (Top) D");
			BodyShapeIds.Add(0xfa, "Warlokk : (Top) C");
			BodyShapeIds.Add(0xfb, "Warlokk : (Top) MJ");
			BodyShapeIds.Add(0xfc, "Warlokk : (Top) A");
		}

		#endregion

		#region Arrays

		/// <summary>
		/// all Known SemiGlobal Groups
		/// </summary>

		static SemiGlobalListing sgl;
		public static List<SemiGlobalAlias> SemiGlobals
		{
			get
			{
				if (sgl == null)
				{
					LoadSemGlobList();
				}

				return sgl;
			}
		}

		static void LoadSemGlobList()
		{
			sgl = new SemiGlobalListing();
			sgl.Sort();
		}

		public static uint SemiGlobalID(string sgname)
		{
			foreach (SemiGlobalAlias sga in SemiGlobals)
			{
				if (
					sga
						.Name.Trim()
						.ToLowerInvariant()
						.Equals(sgname.Trim().ToLowerInvariant())
				)
				{
					return sga.Id;
				}
			}

			return 0;
		}

		public static string SemiGlobalName(uint sgid)
		{
			foreach (SemiGlobalAlias sga in SemiGlobals)
			{
				if (sga.Id == sgid)
				{
					return sga.Name;
				}
			}

			return "";
		}

		#endregion

		#region Supporting Methods
		/// <summary>
		/// Returns the describing TypeAlias for the passed Type
		/// </summary>
		/// <param name="type">The type you want to load the TypeAlias for</param>
		/// <returns>The TypeAlias representing the Type</returns>
		public static TypeAlias FindTypeAlias(UInt32 type)
		{
			TypeAlias a = Helper.TGILoader.GetByType(type);
			if (a == null)
			{
				a = new TypeAlias(
					false,
					Localization.Manager.GetString("unk") + "",
					type,
					"0x" + Helper.HexString(type)
				);
			}

			return a;
		}

		/// <summary>
		/// Returns the Group Number of a SemiGlobal File
		/// </summary>
		/// <param name="name">the nme of the semi global</param>
		/// <returns>The group Vlue of the Global</returns>
		public static Alias FindSemiGlobal(string name)
		{
			name = name.ToLower();
			foreach (Alias a in SemiGlobals)
			{
				if (a.Name.ToLower() == name)
				{
					return a;
				}
			} //for

			//unknown SemiGlobal
			return new Alias(0xffffffff, name.ToLower());
		}

		static Interfaces.IAlias[] addonskins;

		/// <summary>
		/// Returns a List of Userdefined Add On Skins
		/// </summary>
		public static Interfaces.IAlias[] AddonSkins
		{
			get
			{
				if (addonskins == null)
				{
					addonskins = Alias.LoadFromXml(
						System.IO.Path.Combine(
							Helper.SimPeDataPath,
							"additional_skins.xml"
						)
					);
				}

				return addonskins;
			}
		}
		#endregion

		#region Map's
		static ArrayList rcollist;
		static ArrayList complist;
		static Hashtable agelist;
		static List<uint> cachedft;

		public static List<uint> CachedFileTypes
		{
			get
			{
				if (cachedft == null)
				{
					cachedft = new List<uint>();

					foreach (uint i in RcolList)
					{
						cachedft.Add(i);
					}

					cachedft.Add(OBJD_FILE);
					cachedft.Add(CTSS_FILE);
					cachedft.Add(STRING_FILE);

					cachedft.Add(XFLR);
					cachedft.Add(XFNC);
					cachedft.Add(XNGB);
					cachedft.Add(XOBJ);
					cachedft.Add(XROF);
					cachedft.Add(XWNT);
				}
				return cachedft;
			}
		}

		//Returns a List of all RCOl Compatible File Types
		public static ArrayList RcolList
		{
			get
			{
				if (rcollist == null)
				{
					rcollist = new ArrayList
					{
						(uint)GMDC, //GMDC
						(uint)TXTR, //TXTR
						(uint)LIFO, //LIFO
						(uint)TXMT, //MATD
						(uint)ANIM, //ANIM
						(uint)GMND, //GMND
						(uint)SHPE, //SHPE
						(uint)CRES, //CRES
						LDIR,
						LAMB,
						LSPT,
						LPNT
					};
				}
				return rcollist;
			}
		}

		//Returns a List of File Types that should be compressed
		public static ArrayList CompressionCandidates
		{
			get
			{
				if (complist == null)
				{
					complist = RcolList;

					complist.Add(STRING_FILE);
					complist.Add((uint)0x0C560F39); //Binary Index
					complist.Add((uint)0xAC506764); //3D IDR
				}
				return complist;
			}
		}

		/// <summary>
		/// translates the Ages from a SDesc to a Property Set age
		/// </summary>
		public static Ages AgeTranslation(LifeSections age)
		{
			agelist = new Hashtable();
			if (age == LifeSections.Adult)
			{
				return Ages.Adult;
			}
			else if (age == LifeSections.Baby)
			{
				return Ages.Baby;
			}
			else if (age == LifeSections.Child)
			{
				return Ages.Child;
			}
			else if (age == LifeSections.Elder)
			{
				return Ages.Elder;
			}
			else if (age == LifeSections.Teen)
			{
				return Ages.Teen;
			}
			else if (age == LifeSections.Toddler)
			{
				return Ages.Toddler;
			}
			else
			{
				return Ages.Adult;
			}
		}
		#endregion
	}
}
